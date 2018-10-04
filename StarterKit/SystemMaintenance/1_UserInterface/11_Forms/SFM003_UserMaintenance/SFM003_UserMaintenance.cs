using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EVOFramework.Data;
using EVOFramework;
using SystemMaintenance.BIZ;
using SystemMaintenance.UIDataModel;
using SystemMaintenance.Controller;
using EVOFramework.Windows.Forms;

namespace SystemMaintenance.Forms
{
    [Screen("SFM003", "User Maintenance", eShowAction.Normal, eScreenType.Screen, "User Maintenance")]
    public partial class SFM003_UserMaintenance : CustomizeBaseForm
    {
        #region Enum
        enum eColUser
        {
            USER_ACCOUNT,
            FULL_NAME,
            GROUP_CD,
            FLG_ACTIVE,
        }
        enum eColGroup
        {
            GROUP_NAME,
            GROUP_DESC
        }
        #endregion

        #region Constructor
        public SFM003_UserMaintenance()
        {
            InitializeComponent();
        }
        #endregion

        #region Private Method
        private void RefreshUserSpread()
        {
            UserBIZ biz = new UserBIZ();
            fpUser.DataSource = DTOUtility.ConvertListToDataTable(biz.LoadAllUser());

            UserMaintenanceUIDM umd = new UserMaintenanceUIDM();

            //dmcUserMaintenance.LoadData(umd);

            int rows = shtUser.Rows.Count;
            for (int i = 0; i < rows; i++)
            {
                shtUser.Rows[i].Locked = true;
            }
        }
        private void RefreshGroupSpread()
        {
            UserGroupBIZ biz = new UserGroupBIZ();
            fpGroup.DataSource = DTOUtility.ConvertListToDataTable(biz.LoadAllGroup());

            UserMaintenanceUIDM umd = new UserMaintenanceUIDM();

            //dmcUserMaintenance.LoadData(umd);

            int rows = shtGroup.Rows.Count;
            for (int i = 0; i < rows; i++)
            {
                shtGroup.Rows[i].Locked = true;
            }
        }
        private void DeleteGroup()
        {
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
                CreateGroupDomain groupDomain = new CreateGroupDomain();
                groupDomain.GroupCD.Value = shtGroup.Cells[shtGroup.ActiveRowIndex, (int)eColGroup.GROUP_NAME].Text;
                UserMaintenanceController userCtrler = new UserMaintenanceController();
                userCtrler.DeleteGroupController(groupDomain);
                shtGroup.RemoveRows(shtGroup.ActiveRowIndex, 1);
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
        }

        private void DeleteUser()
        {
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
                DeleteUserDomain userDomain = new DeleteUserDomain();
                userDomain.UserAccount.Value = shtUser.Cells[shtUser.ActiveRowIndex, (int)eColUser.USER_ACCOUNT].Text;
                UserMaintenanceController userCtrler = new UserMaintenanceController();
                userCtrler.DeleteUserController(userDomain);
                shtUser.RemoveRows(shtUser.ActiveRowIndex, 1);
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
        }
        private void OpenCreateUserForm()
        {
            if (shtUser.Rows.Count == 0)
            {
                return;
            }
            if (shtUser.ActiveRowIndex < 0)
            {
                return;
            }
            string UserAccount = shtUser.Cells[shtUser.ActiveRowIndex, (int)eColUser.USER_ACCOUNT].Text;
            SFM0031_CreateUser frmCreateUser = new SFM0031_CreateUser(SFM0031_CreateUser.eOperationMode.PROPERTIES_SHOW, UserAccount);
            frmCreateUser.ShowDialog();
            RefreshUserSpread();
        }
        private void OpenCreateGroupForm()
        {
            string GroupCD = shtGroup.Cells[shtUser.ActiveRowIndex, (int)eColGroup.GROUP_NAME].Text;
            SFM0034_CreateGroup frmCreateGroup = new SFM0034_CreateGroup();
            frmCreateGroup.ShowDialog();
            RefreshGroupSpread();
        }
        private MessageDialogResult ShowConfirmMessage(Messages.eConfirm msgCD)
        {
            // show confirm message
            MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new EVOFramework.Message(msgCD.ToString()).MessageDescription);
            return dr;
        }
        #endregion

        #region Control Event
        private void propertiesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenGroupPropertyForm();
        }

        private void OpenGroupPropertyForm()
        {
            if (shtGroup.Rows.Count == 0)
            {
                return;
            }
            if (shtGroup.ActiveRowIndex < 0)
            {
                return;
            }
            string GroupCD = shtGroup.Cells[shtGroup.ActiveRowIndex, (int)eColGroup.GROUP_NAME].Text;
            string GroupDesc = shtGroup.Cells[shtGroup.ActiveRowIndex, (int)eColGroup.GROUP_DESC].Text;
            SFM0033_GroupProperty frmGroupProperty = new SFM0033_GroupProperty(GroupCD, GroupDesc);
            frmGroupProperty.ShowDialog();
            RefreshGroupSpread();
        }

        private void newGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //int row = shtGroup.Rows.Count;
            //shtGroup.Rows.Count = row + 1;
            //shtGroup.AddSelection(row, 0, 1, 2);
            //shtGroup.Rows[row].Locked = false;
            OpenCreateGroupForm();
        }

        private void fpUser_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            OpenCreateUserForm();
        }
        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCreateUserForm();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteUser();
        }

        private void newUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SFM0031_CreateUser frmCreateUser = new SFM0031_CreateUser(SFM0031_CreateUser.eOperationMode.CREATE_ACCOUNT, string.Empty);
            frmCreateUser.ShowDialog();
            RefreshUserSpread();
        }
        #endregion

        #region Form Event
        private void SFM003_UserMaintenance_Load(object sender, EventArgs e)
        {
            shtUser.ActiveSkin = CommonLib.Common.ACTIVE_SKIN;
            shtGroup.ActiveSkin = CommonLib.Common.ACTIVE_SKIN;

            shtUser.Columns[(int)eColUser.USER_ACCOUNT].DataField = "USER_ACCOUNT";
            shtUser.Columns[(int)eColUser.FULL_NAME].DataField = "FULL_NAME";
            shtUser.Columns[(int)eColUser.GROUP_CD].DataField = "GROUP_CD";
            shtUser.Columns[(int)eColUser.FLG_ACTIVE].DataField = "FLG_ACTIVE";

            shtUser.Columns[(int)eColUser.FLG_ACTIVE].CellType = CommonLib.CtrlUtil.CreateCheckboxCellType();

            shtGroup.Columns[(int)eColGroup.GROUP_NAME].DataField = "GROUP_CD";
            shtGroup.Columns[(int)eColGroup.GROUP_DESC].DataField = "GROUP_NAME";

            RefreshUserSpread();
            if (shtUser.Rows.Count > 0)
                shtUser.AddSelection(0, 0, 1, 2);

            RefreshGroupSpread();
            if (shtGroup.Rows.Count > 0)
                shtGroup.AddSelection(0, 0, 1, 2);

        }
        #endregion

        private void fpGroup_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            OpenGroupPropertyForm();
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DeleteGroup();
        }


    }


}
