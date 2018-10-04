using System;
using System.Collections.Generic;
using EVOFramework.Windows.Forms;
using EVOFramework;
using Rubik.BIZ;
using Rubik.DTO;
using Rubik.Validators;
using CommonLib;
using EVOFramework.Data;
using System.Windows.Forms;

namespace Rubik.Inventory
{
    //[Screen("INV050", "Negative Lot Clearing Process", eShowAction.Normal, eScreenType.Process, "Negative Lot Clearing Process")]
    public partial class INV050 : SystemMaintenance.Forms.CustomizeBaseForm
    {
        public INV050()
        {
            InitializeComponent();
        }

        private void INV050_Load(object sender, EventArgs e)
        {
            InitialScreen();
        }

        private void InitialScreen()
        {
            picWaiting.Visible = false;

            InitialComboBox();

            CommonLib.CtrlUtil.EnabledControl(true, cboLocation);
            CommonLib.CtrlUtil.EnabledControl(false, txtInfo);
        }

        private void InitialComboBox()
        {

            cboLocation.Format += Common.ComboBox_Format;
            LookupDataBIZ bizLookup = new LookupDataBIZ();
            DealingDTO dto = new DealingDTO();
            dto.LOC_CD = "All".ToNZString();
            dto.LOC_DESC = "All Location".ToNZString();
            LookupData lookupLocation = bizLookup.LoadLookupLocation_AddDummy(dto);

            cboLocation.LoadLookupData(lookupLocation);
        }



        private void INV050_Shown(object sender, EventArgs e)
        {
            tableLayoutPanel1.PerformLayout();
            this.PerformLayout();
            this.PermissionControl();
        }

        private void btnRunProcess_Click(object sender, EventArgs e)
        {
            if (cboLocation.SelectedValue == null || cboLocation.SelectedValue.ToString() == string.Empty)
            {
                MessageDialog.ShowBusiness(this, new EVOFramework.Message(TKPMessages.eValidate.VLM0001.ToString()));
                return;
            }

            MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new EVOFramework.Message(TKPMessages.eConfirm.CFM0005.ToString()).MessageDescription);
            if (dr != MessageDialogResult.Yes)
            {
                return;
            }

            RunProcess(this.cboLocation.SelectedValue.ToString());

        }

        private bool RunProcess(string strLocation)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                picWaiting.Visible = true;
                picWaiting.BringToFront();

                InventoryBIZ biz = new InventoryBIZ();
                biz.NegativeLotClearingProcess(strLocation);

                MessageDialog.ShowBusiness(this, EVOFramework.Message.LoadMessage(SystemMaintenance.Messages.eInformation.INF9003.ToString()));
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
                return false;
            }
            finally
            {
                this.Cursor = Cursors.Default;
                picWaiting.Visible = false;
            }
        }

        #region Permission Control
        public virtual void PermissionControl()
        {
            if (!DesignMode)
            {
                CommonLib.CtrlUtil.EnabledControl(ActivePermission.Edit, this.Controls);
            }

        }
        #endregion
    }
}
