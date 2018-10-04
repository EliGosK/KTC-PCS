using System;
using System.Collections.Generic;
using EVOFramework.Windows.Forms;
using EVOFramework;
using Rubik.BIZ;
using Rubik.DTO;
using Rubik.Validators;
using System.Windows.Forms;

namespace Rubik.Inventory
{
    [Screen("INV040", "Inventory Period Closing Process", eShowAction.Normal, eScreenType.Process, "Inventory Period Closing Process")]
    public partial class INV040 : SystemMaintenance.Forms.CustomizeBaseForm
    {
        public INV040()
        {
            InitializeComponent();
        }

        private void INV040_Load(object sender, EventArgs e)
        {
            InitialScreen();
        }

        private void InitialScreen()
        {
            picWaiting.Visible = false;
            switch (CommonLib.Common.CurrentUserInfomation.DateFormat)
            {
                case eDateFormat.DMY:
                case eDateFormat.MDY:
                    dtInventoryMonth.Format = "MM/yyyy";
                    break;

                case eDateFormat.YMD:
                    dtInventoryMonth.Format = "yyyy/MM";
                    break;
            }


            InventoryPeriodBIZ biz = new InventoryPeriodBIZ();
            InventoryPeriodDTO dto = biz.LoadCurrentPeriod();

            DateTime currentYearMonth = new DateTime(
                Convert.ToInt32(dto.YEAR_MONTH.StrongValue.Substring(0, 4)),
                Convert.ToInt32(dto.YEAR_MONTH.StrongValue.Substring(4, 2)), 1);

            dtInventoryMonth.DateValue = currentYearMonth;

            CommonLib.CtrlUtil.EnabledControl(false, txtInfo, dtInventoryMonth);

        }

        private void btnRollingDown_Click(object sender, EventArgs e)
        {
            RollingStart(eMonthlyCloseProcess.ROLLING_DOWN);
        }

        private void btnRollingUp_Click(object sender, EventArgs e)
        {
            RollingStart(eMonthlyCloseProcess.ROLLING_UP);
        }

        private void RollingStart(eMonthlyCloseProcess ProcessType)
        {
            try
            {
                
                NZString YearMonth = Convert.ToDateTime(dtInventoryMonth.DateValue).ToString("yyyyMM").ToNZString();
                InventoryPeriodValidator val = new InventoryPeriodValidator();
                //val.CheckBeforeRunProcess(ProcessType);
                ErrorItem err = val.CheckBeforeRunClosingProcess(ProcessType, YearMonth);

                if (err != null)
                {
                    MessageDialogResult cf = MessageDialog.ShowConfirmation(this, EVOFramework.Message.LoadMessage(TKPMessages.eValidate.VLM0076.ToString()).MessageDescription,MessageDialogButtons.YesNo);
                    if (cf != MessageDialogResult.Yes)
                    {
                        return;
                    }
                }

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new EVOFramework.Message(TKPMessages.eConfirm.CFM0005.ToString()).MessageDescription,MessageDialogButtons.YesNo);
                if (dr == MessageDialogResult.Yes)
                {
                   
                    if (RunProcess(ProcessType))
                    {
                        MessageDialog.ShowBusiness(this, EVOFramework.Message.LoadMessage(SystemMaintenance.Messages.eInformation.INF9003.ToString()));
                    }

                    InventoryPeriodBIZ biz = new InventoryPeriodBIZ();
                    InventoryPeriodDTO dto = biz.LoadCurrentPeriod();

                    DateTime currentYearMonth = new DateTime(
                        Convert.ToInt32(dto.YEAR_MONTH.StrongValue.Substring(0, 4)),
                        Convert.ToInt32(dto.YEAR_MONTH.StrongValue.Substring(4, 2)), 1);

                    dtInventoryMonth.DateValue = currentYearMonth;


                }
            }
            catch (ValidateException ex)
            {
                MessageDialog.ShowBusiness(this, ex.ErrorResults[0].Message);
            }
            catch (BusinessException ex)
            {
                MessageDialog.ShowBusiness(this, ex.Error.Message);
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }

        }

        private bool RunProcess(eMonthlyCloseProcess ePrcsType)
        {
            try {
                this.Cursor = Cursors.WaitCursor;
                picWaiting.Visible = true;

                InventoryBIZ biz = new InventoryBIZ();

                NZString YearMonth = new NZString(null, Convert.ToDateTime(dtInventoryMonth.DateValue).ToString("yyyyMM"));
                //pgbProgress.PerformStep();
                biz.RunInventoryClosingProcess(ePrcsType);
                return true;
            }
            catch (Exception ex) {
                MessageDialog.ShowBusiness(this, ex.Message);

            }
            finally {
                this.Cursor = Cursors.Default;
                picWaiting.Visible = false;
            }
            return false;
        }

        private void INV040_Shown(object sender, EventArgs e)
        {
            this.PerformLayout();
            PermissionControl();
        }

        #region Permission Control
        public virtual void PermissionControl()
        {
            if (!DesignMode)
            {
                //if (!ActivePermission.View)
                //{
                //    EVOFramework.Windows.Forms.MessageDialog.ShowInformation(this, "Permissionn Control"
                //        , EVOFramework.Message.LoadMessage(SystemMaintenance.Messages.eInformation.INF9004.ToString()).MessageDescription);
                //    Close();
                //}
                if (!ActivePermission.Edit)
                {
                    CommonLib.CtrlUtil.EnabledControl(false, Controls);
                }
            }
        }
        #endregion
    }
}
