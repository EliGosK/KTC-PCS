using System;
using System.Windows.Forms;
using SystemMaintenance;
using EVOFramework.Windows.Forms;
using Rubik.Controller;
using EVOFramework;
using Rubik.Validators;
using Rubik.BIZ;
using Rubik.DTO;

namespace Rubik.Master
{
   // [Screen("MAS060", "Inventory Period Setup", eShowAction.Normal, eScreenType.Screen, "Inventory Period Setup")]
    public partial class MAS060 : SystemMaintenance.Forms.CustomizeForm
    {
        #region Contructor

        public MAS060()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Method

        private void InitialScreen()
        {
            tsbSaveAndClose.Visible = false;
            tsbSaveAndNew.Visible = false;
            tlsSeperator1.Visible = false;
            tlsSeperator2.Visible = false;
            ToolStripButton tsbSave = new ToolStripButton();
            tsbSave.Image = Rubik.Forms.Properties.Resources.SAVE;
            tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbSave.Margin = new System.Windows.Forms.Padding(4, 2, 0, 2);
            tsbSave.Name = "tsbSave";
            tsbSave.Padding = new System.Windows.Forms.Padding(2);
            tsbSave.Size = new System.Drawing.Size(100, 24);
            tsbSave.Text = "Save";
            tsbSave.ToolTipText = "Save";
            tsbSave.Click += new EventHandler(tsbSave_Click);

            tslControl.Items.Add(tsbSave);



            if (CommonLib.Common.CurrentUserInfomation.DateFormat == eDateFormat.YMD)
                dtInventoryMonth.Format = "yyyy/MM";
            else
                dtInventoryMonth.Format = "MM/yyyy";

            //dtInventoryMonth.Value = CommonLib.Common.GetDatabaseDateTime();
            dtPeriodFrom.Format = CommonLib.Common.CurrentUserInfomation.DateFormatString;
            dtPeriodTo.Format = CommonLib.Common.CurrentUserInfomation.DateFormatString;

            dtInventoryMonth.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            dtPeriodFrom.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            dtPeriodTo.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            LoadDefaultPeriod(true, true);

            CommonLib.CtrlUtil.EnabledControl(false,dtPeriodFrom,dtPeriodTo);
        }

        private bool CheckMandatory()
        {

            try
            {
                InventoryPeriodValidator val = new InventoryPeriodValidator();

                #region Mandatory check

                ErrorItem errorItem = null;
                errorItem = val.CheckEmptyYearMonth(new NZString(null, dtInventoryMonth.Value.HasValue ? dtInventoryMonth.Value.Value.ToString("yyyyMM") : null));
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                errorItem = val.CheckEmptyPeriodBeginDate(new NZDateTime(null, dtPeriodFrom.Value));
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                errorItem = val.CheckEmptyPeriodEndDate(new NZDateTime(null, dtPeriodTo.Value));
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                errorItem = val.CheckPeriodBeginToEndDate(new NZDateTime(null, dtPeriodFrom.Value),
                                                          new NZDateTime(null, dtPeriodTo.Value));
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

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

        private bool SaveData()
        {
            try
            {
                InventoryPeriodController ctlInv = new InventoryPeriodController();
                NZString YearMonth = new NZString(null, dtInventoryMonth.Value.Value.ToString("yyyyMM"));
                NZDateTime PeriodBegin = new NZDateTime(null, dtPeriodFrom.Value);
                NZDateTime PeriodEnd = new NZDateTime(null, dtPeriodTo.Value);
                ctlInv.UpdatePeriod(YearMonth, PeriodBegin, PeriodEnd);
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
            catch (Exception err)
            {
                MessageDialog.ShowBusiness(this, err.Message);
            }
            return false;
        }

        private void LoadDefaultPeriod(bool LoadCurrentPeriod, bool LoadDefaultYearMonth)
        {
            InventoryPeriodBIZ biz = new InventoryPeriodBIZ();
            InventoryPeriodDTO dto;
            if (LoadCurrentPeriod)
                dto = biz.LoadCurrentPeriod();
            else
                dto = biz.LoadPeriodByDate(new NZDateTime(dtInventoryMonth, dtInventoryMonth.Value));
            if (dto != null)
            {
                int year = Convert.ToInt32(dto.YEAR_MONTH.StrongValue.Substring(0, 4));
                int month = Convert.ToInt32(dto.YEAR_MONTH.StrongValue.Substring(4, 2));
                if (LoadDefaultYearMonth)
                    dtInventoryMonth.Value = new DateTime(year, month, 1);
                dtPeriodFrom.Value = dto.PERIOD_BEGIN_DATE.StrongValue;
                dtPeriodTo.Value = dto.PERIOD_END_DATE.StrongValue;
            }
            else
            {
                dtPeriodFrom.Value = new DateTime(dtInventoryMonth.Value.Value.Year, dtInventoryMonth.Value.Value.Month, 1);
                dtPeriodTo.Value = new DateTime(dtInventoryMonth.Value.Value.Year, dtInventoryMonth.Value.Value.Month, DateTime.DaysInMonth(dtInventoryMonth.Value.Value.Year, dtInventoryMonth.Value.Value.Month));
            }

        }

        #endregion

        #region Form Event

        private void MAS060_Load(object sender, EventArgs e)
        {

            InitialScreen();
        }

        #endregion

        #region Control Event

        void tsbSave_Click(object sender, EventArgs e)
        {
            // Validate Before Save
            if (CheckMandatory())
            {
                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new EVOFramework.Message(Messages.eConfirm.CFM9001.ToString()));
                if (dr == MessageDialogResult.Cancel)
                    return;

                if (dr == MessageDialogResult.No)
                    Close();

                if (dr == MessageDialogResult.Yes)
                {
                    if (SaveData())
                        MessageDialog.ShowInformation(this, null, new EVOFramework.Message(Messages.eInformation.INF9003.ToString()).MessageDescription);

                }

            }

        }

        private void dtInventoryMonth_Leave(object sender, EventArgs e)
        {

        }

        private void dtInventoryMonth_ValueChanged(object sender, EventArgs e)
        {
            if (dtInventoryMonth.Value == null) return;

            LoadDefaultPeriod(false, false);
        }

        #endregion
    }
}
