using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SystemMaintenance.UIDataModel;
using SystemMaintenance.Controller;
using EVOFramework;
using SystemMaintenance.BIZ;
using EVOFramework.Data;
using EVOFramework.Windows.Forms;
using CommonLib;

namespace SystemMaintenance.Forms
{
    public partial class SFM0033_GroupProperty : CustomizeBaseForm
    {
        enum eColUser
        {
            USER_ACCOUNT,
            FULL_NAME
        }
        string m_GroupCD;
        string m_GroupDesc;

        public SFM0033_GroupProperty(String GroupCD, String GroupDesc)
        {
            InitializeComponent();
            m_GroupCD = GroupCD;
            m_GroupDesc = GroupDesc;
        }

        private void SFM0033_GroupProperty_Load(object sender, EventArgs e)
        {
            shtUser.Columns[(int)eColUser.USER_ACCOUNT].DataField = "USER_ACCOUNT";
            shtUser.Columns[(int)eColUser.FULL_NAME].DataField = "FULL_NAME";

            shtUser.ActiveSkin = CommonLib.Common.ACTIVE_SKIN;



            dmcGroupProperty.AddControl(txtGroupCD);
            dmcGroupProperty.AddControl(txtGoupDesc);
            CreateGroupDomain grouppropDomain = new CreateGroupDomain();
            grouppropDomain.GroupCD.Value = m_GroupCD;
            grouppropDomain.GroupDesc.Value = m_GroupDesc;
            dmcGroupProperty.LoadData(grouppropDomain);

            // disable control
            CtrlUtil.EnabledControl(false, txtGroupCD);            
            txtGoupDesc.Focus();
            RefreshUserSpread();
        }

        private void RefreshUserSpread()
        {
            UserBIZ biz = new UserBIZ();
            fpUser.DataSource = DTOUtility.ConvertListToDataTable(biz.LoadUserByGroupCD(m_GroupCD));

            UserMaintenanceUIDM umd = new UserMaintenanceUIDM();

            //dmcUserMaintenance.LoadData(umd);

            int rows = shtUser.Rows.Count;
            for (int i = 0; i < rows; i++)
            {
                shtUser.Rows[i].Locked = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtGoupDesc_Leave(object sender, EventArgs e)
        {
            UpdateGroupDesc();
        }

        private void UpdateGroupDesc()
        {
            try
            {
                CreateGroupDomain groupDm = dmcGroupProperty.SaveData(new CreateGroupDomain());
                UserMaintenanceController userCtrler = new UserMaintenanceController();

                userCtrler.UpdateGroupDescController(groupDm);
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveUserFromGroup();
            RefreshUserSpread();
        }
        private MessageDialogResult ShowConfirmMessage(Messages.eConfirm msgCD)
        {
            // show confirm message
            MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new EVOFramework.Message(msgCD.ToString()).MessageDescription);
            return dr;
        }
        private void RemoveUserFromGroup()
        {
            if (shtUser.Rows.Count == 0)
            {
                return;
            }
            if (shtUser.ActiveRowIndex < 0)
            {
                return;
            }
            try
            {
                switch (ShowConfirmMessage(Messages.eConfirm.CFM9002))
                {
                    case MessageDialogResult.Cancel:
                        return;

                    case MessageDialogResult.No:
                        return;

                    case MessageDialogResult.Yes:
                        break;

                }
                CreateGroupDomain groupDm = dmcGroupProperty.SaveData(new CreateGroupDomain());
                UserMaintenanceController userCtrler = new UserMaintenanceController();
                string userCD = shtUser.Cells[shtUser.ActiveRowIndex, (int)eColUser.USER_ACCOUNT].Text;
                userCtrler.RemoveUserFromGroup(groupDm, userCD);
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenUserListForm();
        }

        private void OpenUserListForm()
        {
            SFM0032_UserList frmUserList = new SFM0032_UserList(m_GroupCD);
            frmUserList.ShowDialog();
            RefreshUserSpread();
        }
    }
}
