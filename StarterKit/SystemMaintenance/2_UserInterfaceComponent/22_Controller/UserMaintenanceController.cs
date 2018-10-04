using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemMaintenance.UIDataModel;
using SystemMaintenance.DTO;
using SystemMaintenance.BIZ;

namespace SystemMaintenance.Controller
{
    public class UserMaintenanceController
    {
        public bool CreateUserController(CreateUserDomain userDm)
        {
            UserBIZ userBIZ = new UserBIZ();
            UserDTO userDTO = new UserDTO();
            userDTO.APPLY_DATE.Value = DateTime.Now;
            userDTO.CRT_BY = CommonLib.Common.CurrentUserInfomation.Username;
            userDTO.CRT_DATE.Value = DateTime.Now;
            userDTO.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.UserCD;
            userDTO.DATE_FORMAT = userDm.DefaultDateFormat;
            userDTO.FLG_ACTIVE = userDm.IsActive;
            userDTO.FLG_RESIGN = userDm.IsResign;
            userDTO.GROUP_CD = userDm.GroupUser;
            userDTO.LANG_CD = userDm.DefaultLang;
            userDTO.LOWER_USER_ACCOUNT = userDm.UserAccount.ToLower();
            userDTO.PASS.Value = userBIZ.HashUserPassword(userDm.UserAccount.StrongValue, userDm.PassWord.StrongValue, true);//userDm.PassWord;
            userDTO.PASS.Owner = userDm.PassWord.Owner;
            userDTO.UPPER_USER_ACCOUNT = userDm.UserAccount.ToUpper();
            userDTO.UPD_BY = CommonLib.Common.CurrentUserInfomation.Username;
            userDTO.UPD_DATE.Value = DateTime.Now;
            userDTO.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.UserCD;
            userDTO.USER_ACCOUNT = userDm.UserAccount;
            userDTO.FULL_NAME = userDm.UserName;
            userDTO.MENU_SET_CD = userDm.MenuSet;

            userBIZ.AddNewUser(userDTO);
            return true;
        }

        public bool CreateGroupController(CreateGroupDomain groupDm)
        {
            UserGroupBIZ UserGroupBIZ = new UserGroupBIZ();
            UserGroupDTO userGroupDTO = new UserGroupDTO();
            userGroupDTO.CRT_BY = CommonLib.Common.CurrentUserInfomation.Username;
            userGroupDTO.CRT_DATE.Value = DateTime.Now;
            userGroupDTO.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.UserCD;
            userGroupDTO.UPD_BY = CommonLib.Common.CurrentUserInfomation.Username;
            userGroupDTO.UPD_DATE.Value = DateTime.Now;
            userGroupDTO.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.UserCD;
            userGroupDTO.GROUP_CD = groupDm.GroupCD;
            userGroupDTO.GROUP_NAME = groupDm.GroupDesc;


            UserGroupBIZ.AddNewGroup(userGroupDTO);
            return true;
        }

        public CreateUserDomain LoadData(CreateUserDomain userDm)
        {
            UserBIZ userBIZ = new UserBIZ();
            UserDTO userDTO = userBIZ.LoadUser(userDm.UserAccount);

            userDm.DefaultLang.Value = userDTO.LANG_CD.Value;
            userDm.GroupUser.Value = userDTO.GROUP_CD.Value;
            userDm.PassWord.Value = userDTO.PASS.Value;
            userDm.UserName.Value = userDTO.FULL_NAME.Value;
            userDm.DefaultDateFormat.Value = userDTO.DATE_FORMAT.Value;
            userDm.UserAccount.Value = userDTO.USER_ACCOUNT.Value;
            userDm.MenuSet.Value = userDTO.MENU_SET_CD.Value;
            userDm.IsActive.Value = userDTO.FLG_ACTIVE.Value;
            userDm.IsResign.Value = userDTO.FLG_RESIGN.Value;
            return userDm;
        }

        public bool UpdateUserController(CreateUserDomain userDm)
        {
            UserBIZ userBIZ = new UserBIZ();
            UserDTO userDTO = new UserDTO();
            userDTO.APPLY_DATE.Value = DateTime.Now;
            userDTO.CRT_BY = CommonLib.Common.CurrentUserInfomation.Username;
            userDTO.CRT_DATE.Value = DateTime.Now;
            userDTO.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.UserCD;
            userDTO.DATE_FORMAT = userDm.DefaultDateFormat;
            userDTO.FLG_ACTIVE = userDm.IsActive;
            userDTO.FLG_RESIGN = userDm.IsResign;
            userDTO.GROUP_CD = userDm.GroupUser;
            userDTO.LANG_CD = userDm.DefaultLang;
            userDTO.LOWER_USER_ACCOUNT = userDm.UserAccount.ToLower();
            userDTO.MENU_SET_CD = userDm.MenuSet;

            if (!userDm.PassWord.IsNull)
            {
                userDTO.PASS.Value = userBIZ.HashUserPassword(userDm.UserAccount.StrongValue, userDm.PassWord.StrongValue, true);//userDm.PassWord;
                userDTO.PASS.Owner = userDm.PassWord.Owner;
            }

            userDTO.UPPER_USER_ACCOUNT = userDm.UserAccount.ToUpper();
            userDTO.UPD_BY = CommonLib.Common.CurrentUserInfomation.Username;
            userDTO.UPD_DATE.Value = DateTime.Now;
            userDTO.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.UserCD;
            userDTO.USER_ACCOUNT = userDm.UserAccount;
            userDTO.FULL_NAME = userDm.UserName;


            userBIZ.UpdateUser(userDTO);
            return true;
        }

        public bool DeleteUserController(DeleteUserDomain userDm)
        {
            UserBIZ userBIZ = new UserBIZ();
            userBIZ.DeleteUser(userDm.UserAccount);
            return true;
        }

        public bool DeleteGroupController(CreateGroupDomain groupDm)
        {
            UserGroupBIZ usergroupBIZ = new UserGroupBIZ();
            usergroupBIZ.DeleteGroup(groupDm.GroupCD);
            return true;
        }

        public bool UpdateGroupDescController(CreateGroupDomain groupDm)
        {
            UserGroupBIZ UserGroupBIZ = new UserGroupBIZ();
            UserGroupDTO userGroupDTO = new UserGroupDTO();

            userGroupDTO.UPD_BY = CommonLib.Common.CurrentUserInfomation.Username;
            userGroupDTO.UPD_DATE.Value = DateTime.Now;
            userGroupDTO.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.UserCD;
            userGroupDTO.GROUP_CD = groupDm.GroupCD;
            userGroupDTO.GROUP_NAME = groupDm.GroupDesc;


            UserGroupBIZ.UpdateGroupDesc(userGroupDTO);
            return true;
        }

        public void RemoveUserFromGroup(CreateGroupDomain groupDm, string userCD)
        {
            UserBIZ userBIZ = new UserBIZ();
            UserDTO userDTO = new UserDTO();

            userDTO.GROUP_CD = groupDm.GroupCD;

            userDTO.UPD_BY = CommonLib.Common.CurrentUserInfomation.Username;
            userDTO.UPD_DATE.Value = DateTime.Now;
            userDTO.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.UserCD;
            userDTO.USER_ACCOUNT.Value = userCD;

            userBIZ.RemoveUserFromGroup(userDTO);

        }

        public bool AddUserToGroupController(CreateUserDomain userDm)
        {
            UserBIZ userBIZ = new UserBIZ();
            UserDTO userDTO = new UserDTO();

            userDTO.GROUP_CD = userDm.GroupUser;

            userDTO.UPD_BY = CommonLib.Common.CurrentUserInfomation.Username;
            userDTO.UPD_DATE.Value = DateTime.Now;
            userDTO.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.UserCD;
            userDTO.USER_ACCOUNT = userDm.UserAccount;

            userBIZ.AddUserToGroup(userDTO);
            return true;
        }
    }
}
