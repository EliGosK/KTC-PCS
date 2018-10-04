using System;
using System.Windows.Forms;
using SystemMaintenance;
using EVOFramework.Windows.Forms;
using Rubik.Controller;
using EVOFramework;
using Rubik.Validators;
using Rubik.BIZ;
using Rubik.DTO;
using System.Data;

namespace Rubik.Report
{
    //[Screen("RPT010", "Injection Material Balance Report", eShowAction.Normal, eScreenType.Screen, "Injection Material Balance Report")]
    public partial class RPT010 : SystemMaintenance.Forms.CustomizeForm
    {
        #region Contructor

        public RPT010()
        {
            InitializeComponent();
        }

        #endregion



        private void InitialScreen()
        {
            tslControl.Visible = false;
            
        }

        private bool CheckMandatory()
        {
            try
            {
                InventoryPeriodValidator val = new InventoryPeriodValidator();

                #region Mandatory check

                ErrorItem errorItem = null;
                
                errorItem = val.CheckEmptyBeginDate(new NZDateTime(null, dtPeriodFrom.Value));
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                if (dtPeriodTo.Value.HasValue)
                {
                    errorItem = val.CheckPeriodBeginToEndDate(new NZDateTime(null, dtPeriodFrom.Value),
                                                                              new NZDateTime(null, dtPeriodTo.Value));
                    if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);
                }


                #endregion

                return true;
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                err.Error.FocusOnControl();
            }
            catch (ValidateException err)
            {
                MessageDialog.ShowBusiness(this, err.ErrorResults[0].Message);
                err.ErrorResults[0].FocusOnControl();
            }
            return false;
        }



        private void LoadDefaultPeriod()
        {

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (!CheckMandatory())
            {
                return;
            }

            ViewReport();
        }

        private void ViewReport()
        {
            try
            {
                InjectionMaterialBalanceReportController ctrl = new InjectionMaterialBalanceReportController();
                NZDateTime BeginDate = new NZDateTime(dtPeriodFrom, dtPeriodFrom.Value);
                NZDateTime EndDate = new NZDateTime(dtPeriodTo, dtPeriodTo.Value);
                NZString ItemA = txtItemCodeA.Text.ToNZString();
                NZString ItemB = txtItemCodeB.Text.ToNZString();
                DataTable dt = ctrl.GetReportTable(BeginDate, EndDate, ItemA, ItemB);
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageDialog.ShowBusiness(this, new EVOFramework.Message(TKPMessages.eInformation.INF0001.ToString()));
                    return;
                }
                RPT010_PREVIEW preView = new RPT010_PREVIEW(dt, BeginDate, EndDate);
                preView.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }

        private void RPT010_Load(object sender, EventArgs e)
        {
            InitialScreen();
        }

        private void RPT010_Shown(object sender, EventArgs e)
        {
            if (!ActivePermission.View)// || !UserPermission.Edit)
            {
                CommonLib.CtrlUtil.EnabledControl(false, btnRun, dtPeriodFrom
                    , dtPeriodTo, txtItemCodeA, txtItemCodeB);
            }
        }

        #region Form Event


        #endregion

        #region Control Event


        #endregion

        #region Permission Control
        public override void PermissionControl() {
            //if (!DesignMode) {
            //    if (!ActivePermission.Edit) {
            //        CommonLib.CtrlUtil.EnabledControl(false, Controls);
            //    }
            //}

            //tsbSaveAndClose.Enabled = UserPermission.Edit;
            //tsbSaveAndNew.Enabled = UserPermission.Edit;
        }
        #endregion


    }
}
