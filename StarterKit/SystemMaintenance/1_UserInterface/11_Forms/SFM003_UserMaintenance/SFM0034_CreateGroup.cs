using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EVOFramework.Windows.Forms;
using SystemMaintenance.UIDataModel;
using SystemMaintenance.Controller;
using EVOFramework;

namespace SystemMaintenance.Forms
{
    public partial class SFM0034_CreateGroup : CustomizeBaseForm
    {
        public SFM0034_CreateGroup()
        {
            InitializeComponent();
        }

        private void SFM0034_CreateGroup_Load(object sender, EventArgs e)
        {
            dmcCreateGroup.AddControl(txtGroupCD);
            dmcCreateGroup.AddControl(txtGroupDesc);
            txtGroupCD.KeyPress += new KeyPressEventHandler(CommonLib.CtrlUtil.SetNextControl);
            txtGroupDesc.KeyPress += new KeyPressEventHandler(CommonLib.CtrlUtil.SetNextControl);
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }
        private MessageDialogResult ShowConfirmMessage(Messages.eConfirm msgCD)
        {
            // show confirm message
            MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new EVOFramework.Message(msgCD.ToString()).MessageDescription);
            return dr;
        }
        private void SaveData()
        {
            try
            {
                switch (ShowConfirmMessage(Messages.eConfirm.CFM9001))
                {
                    case MessageDialogResult.Cancel:
                        return;

                    case MessageDialogResult.No:
                        this.Close();
                        return;

                    case MessageDialogResult.Yes:
                        break;

                }
                CreateGroupDomain groupDm = dmcCreateGroup.SaveData(new CreateGroupDomain());
                UserMaintenanceController userCtrler = new UserMaintenanceController();

                userCtrler.CreateGroupController(groupDm);
                
                this.Close();
            }
            catch (ValidateException err)
            {
                for (int i = 0; i < err.ErrorResults.Count; i++)
                {
                    MessageBox.Show(err.ErrorResults[i].Message.MessageDescription);
                    err.ErrorResults[i].FocusOnControl();
                }
            }
            catch (BusinessException err)
            {
                MessageBox.Show(err.Error.Message.MessageDescription);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
