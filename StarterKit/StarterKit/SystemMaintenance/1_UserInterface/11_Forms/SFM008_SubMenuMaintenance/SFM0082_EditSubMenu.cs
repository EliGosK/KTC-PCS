using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EVOFramework;
using EVOFramework.Windows.Forms;
using SystemMaintenance.Controller;
using CommonLib;
using SystemMaintenance.Validators;

namespace SystemMaintenance.Forms
{
    [Screen("SFM0082", "Edit Sub Menu", eShowAction.PopupModal, eScreenType.Dialog, "Edit Sub Menu")]
    internal partial class SFM0082_EditSubMenu : CustomizeBaseForm
    {
        private readonly SubMenuMaintenanceController m_subMenuController = new SubMenuMaintenanceController();

        public SFM0082_EditSubMenu()
        {
            InitializeComponent();
        }
        public SFM0082_EditSubMenu(string menuSubCode, string menuSubName)
        {
            InitializeComponent();

            //###################
            // Binding event to control (movenext).
            //###################
            txtSubMenuCode.KeyPress += CtrlUtil.SetNextControl;
            txtSubMenuName.KeyPress += CtrlUtil.SetNextControl;

            txtSubMenuCode.Text = menuSubCode;
            txtSubMenuName.Text = menuSubName;

            CtrlUtil.EnabledControl(false, txtSubMenuCode);
            CtrlUtil.EnabledControl(true, txtSubMenuName);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            try {
                NZString menuSubCD = new NZString(txtSubMenuCode, txtSubMenuCode.Text.Trim());
                NZString menuSubName = new NZString(txtSubMenuName, txtSubMenuName.Text.Trim());

                MenuSubValidator validator = new MenuSubValidator();
                validator.ValidateBeforeSaveEdit(menuSubCD, menuSubName);

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, EVOFramework.Message.LoadMessage(Messages.eConfirm.CFM9001.ToString()));
                if (dr == MessageDialogResult.No)
                {
                    DialogResult = DialogResult.Cancel;
                    return;
                }

                if (dr == MessageDialogResult.Cancel)
                    return;

                m_subMenuController.SaveEditMenuSub(
                    menuSubCD, 
                    menuSubName);

                DialogResult = DialogResult.OK;
            }
            catch (ValidateException err)
            {
                MessageDialog.ShowBusiness(this, err.ErrorResults[0].Message);
                err.ErrorResults[0].FocusOnControl();
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                err.Error.FocusOnControl();
            }
            catch (Exception err)
            {
                MessageDialog.ShowBusiness(this, err.Message);
            }
        }
    }
}
