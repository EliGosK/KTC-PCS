using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SystemMaintenance.BIZ;
using EVOFramework.Data;
using SystemMaintenance.UIDataModel;
using EVOFramework.Windows.Forms;
using SystemMaintenance.Controller;
using EVOFramework;

namespace SystemMaintenance.Forms
{
    public partial class SFM0032_UserList : CustomizeBaseForm
    {
        enum eColUser
        {
            SEL,
            USER_ACCOUNT,
            FULL_NAME
        }

        string m_GroupCD;

        public SFM0032_UserList(string GroupCD)
        {
            InitializeComponent();
            m_GroupCD = GroupCD;
        }


        private void SFM0032_UserList_Load(object sender, EventArgs e)
        {
            shtUser.ActiveSkin = CommonLib.Common.ACTIVE_SKIN;

            shtUser.Columns[(int)eColUser.USER_ACCOUNT].DataField = "USER_ACCOUNT";
            shtUser.Columns[(int)eColUser.FULL_NAME].DataField = "FULL_NAME";

            RefreshUserSpread();
            if (shtUser.Rows.Count > 0)
                shtUser.AddSelection(0, 0, 1, 2);
        }
        private void RefreshUserSpread()
        {
            UserBIZ biz = new UserBIZ();
            fpUser.DataSource = DTOUtility.ConvertListToDataTable(biz.LoadAllUserNotInGroup(m_GroupCD));

            UserMaintenanceUIDM umd = new UserMaintenanceUIDM();

            shtUser.Columns[(int)eColUser.SEL].Locked = false;
            shtUser.Columns[(int)eColUser.USER_ACCOUNT].Locked = true;
            shtUser.Columns[(int)eColUser.FULL_NAME].Locked = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddUserToGroup();
            //this.Close();
        }
        private MessageDialogResult ShowConfirmMessage(Messages.eConfirm msgCD)
        {
            // show confirm message
            MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new EVOFramework.Message(msgCD.ToString()).MessageDescription);
            return dr;
        }
        private void AddUserToGroup()
        {

            switch (ShowConfirmMessage(Messages.eConfirm.CFM9001))
            {
                case MessageDialogResult.Cancel:
                    return;

                case MessageDialogResult.No:
                    return;

                case MessageDialogResult.Yes:
                    break;

            }

            try
            {
                int row = shtUser.Rows.Count;
                for (int i = 0; i < row; i++)
                {

                    if (shtUser.Cells[i, (int)eColUser.SEL].Text == "True")
                    {
                        CreateUserDomain userDm = new CreateUserDomain();
                        userDm.GroupUser.Value = m_GroupCD;
                        userDm.UserAccount.Value = shtUser.Cells[i, (int)eColUser.USER_ACCOUNT].Text;
                        UserMaintenanceController userCtrler = new UserMaintenanceController();

                        userCtrler.AddUserToGroupController(userDm);
                        
                    }
                }
                
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
            this.Close();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int row = shtUser.Rows.Count;
            for (int i = 0; i < row; i++)
            {
                shtUser.Cells[i, (int)eColUser.SEL].Value = true;
            }
        }

        private void selectNoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int row = shtUser.Rows.Count;
            for (int i = 0; i < row; i++)
            {
                shtUser.Cells[i, (int)eColUser.SEL].Value = false;
            }
        }

        private void invertSelectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int row = shtUser.Rows.Count;
            for (int i = 0; i < row; i++)
            {
                if (Convert.ToBoolean(shtUser.Cells[i, (int)eColUser.SEL].Value) == true)
                    shtUser.Cells[i, (int)eColUser.SEL].Value = false;
                else
                    shtUser.Cells[i, (int)eColUser.SEL].Value = true;
            }
        }

        
    }
}
