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
using Message=EVOFramework.Message;

namespace SystemMaintenance.Forms
{
    [Screen("SFM0081", "Add Sub Menu", eShowAction.PopupModal, eScreenType.Dialog, "Add Sub Menu")]
    internal partial class SFM0081_AddSubMenu : CustomizeBaseForm
    {
        private readonly SubMenuMaintenanceController m_subMenuController = new SubMenuMaintenanceController();
        public SFM0081_AddSubMenu()
        {
            InitializeComponent();

            //###################
            // Binding event to control (movenext).
            //###################
            txtSubMenuCode.KeyPress += CtrlUtil.SetNextControl;
            txtSubMenuName.KeyPress += CtrlUtil.SetNextControl;
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
                validator.ValidateBeforeSaveAdd(menuSubCD, menuSubName);

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, Message.LoadMessage(Messages.eConfirm.CFM9001.ToString()));
                if (dr == MessageDialogResult.No) {
                    DialogResult = DialogResult.Cancel;
                    return;
                }

                if (dr == MessageDialogResult.Cancel)
                    return;

                m_subMenuController.SaveNewMenuSub(menuSubCD, menuSubName);
                DialogResult = DialogResult.OK;

            }
            catch (ValidateException err) {
                MessageDialog.ShowBusiness(this, err.ErrorResults[0].Message);
                err.ErrorResults[0].FocusOnControl();
            } catch (BusinessException err) {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                err.Error.FocusOnControl();
            } catch (Exception err) {
                MessageDialog.ShowBusiness(this, err.Message);
            }
            
        }
    }
}
