using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemMaintenance.BIZ;
using EVOFramework;
using System.Data;
using SystemMaintenance.DTO;

namespace SystemMaintenance.Controller
{
    class AuthorizedMaintenanceController
    {
        internal object LoadAllDatabyLangCD(string LangCD)
        {
            ScreenBIZ biz = new ScreenBIZ();
            NZString langCD = new NZString();
            langCD.Value = LangCD;
            DatabaseScreenList screenList = biz.LoadScreensWithAuthorizeAndLangCD(langCD);

            DataTable dt = new DataTable();
            dt.Columns.Add("SCREEN_CD");
            dt.Columns.Add("SCREEN_NAME");
           
            for (int i = 0; i < screenList.Count; i++)
            {
                dt.Rows.Add(screenList[i].ScreenCD.StrongValue,
                    screenList[i].ScreenName.StrongValue);
                 //   screenList[i].ScreenDescription.StrongValue,
                 //   screenList[i].ImageCD.StrongValue);
            }
            return dt;
        }

        internal DataTable LoadUserPermissionJoinScreen(string ScreenCD)
        {
            AuthorizedMaintenanceBIZ biz = new AuthorizedMaintenanceBIZ();
            return biz.LoadUserPermissionJoinScreen(ScreenCD);
        }

        internal DataTable LoadGroupPermissionJoinScreen(string ScreenCD)
        {
            AuthorizedMaintenanceBIZ biz = new AuthorizedMaintenanceBIZ();
            return biz.LoadGroupPermissionJoinScreen(ScreenCD);
        }

        internal bool isExistGroupScreenPermission(string ScreenCD, string GroupCD)
        {
            AuthorizedMaintenanceBIZ biz = new AuthorizedMaintenanceBIZ();
            NZString screenCD = new NZString(null, ScreenCD);
            NZString groupCD = new NZString(null, GroupCD);
            return biz.isExistGroupScreenPermission(screenCD, groupCD);
        }

        internal void AddGroupScreenPermissionFlag(int objFLG_VIEW, int objFLG_ADD, int objFLG_CHG, int objFLG_DEL, string GroupCD, string ScreenCD)
        {
            AuthorizedMaintenanceBIZ biz = new AuthorizedMaintenanceBIZ();

            GroupScreenPermissionDTO dto = new GroupScreenPermissionDTO();
            dto.SCREEN_CD.Value  = ScreenCD;
			dto.GROUP_CD.Value = GroupCD;
			dto.FLG_VIEW.Value = objFLG_VIEW;
			dto.FLG_ADD.Value = objFLG_ADD;
			dto.FLG_CHG.Value = objFLG_CHG;
            dto.FLG_DEL.Value = objFLG_DEL;
			dto.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dto.CRT_DATE.Value = DateTime.Now;
			dto.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
			dto.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dto.UPD_DATE.Value = DateTime.Now;
            dto.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;

            biz.AddGroupScreenPermissionFlag(dto);
        }

        internal void UpdateGroupScreenPermissionFlag(int objFLG_VIEW, int objFLG_ADD, int objFLG_CHG, int objFLG_DEL, string GroupCD, string ScreenCD)
        {
            AuthorizedMaintenanceBIZ biz = new AuthorizedMaintenanceBIZ();

            GroupScreenPermissionDTO dto = new GroupScreenPermissionDTO();
            dto.SCREEN_CD.Value = ScreenCD;
            dto.GROUP_CD.Value = GroupCD;
            dto.FLG_VIEW.Value = objFLG_VIEW;
            dto.FLG_ADD.Value = objFLG_ADD;
            dto.FLG_CHG.Value = objFLG_CHG;
            dto.FLG_DEL.Value = objFLG_DEL;
            dto.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dto.UPD_DATE.Value = DateTime.Now;
            dto.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;

            biz.UpdateGroupScreenPermissionFlag(dto);
        }



        internal void UpdateUserScreenPermissionFlagVIEW(int objFLG_VIEW, string UserCD, string ScreenCD)
        {
            AuthorizedMaintenanceBIZ biz = new AuthorizedMaintenanceBIZ();

            UserScreenPermissionDTO dto = new UserScreenPermissionDTO();
            dto.SCREEN_CD.Value = ScreenCD;
            dto.USER_CD.Value = UserCD;
            dto.FLG_VIEW.Value = objFLG_VIEW;
            //dto.FLG_ADD.Value = objFLG_ADD;
            //dto.FLG_CHG.Value = objFLG_CHG;
            //dto.FLG_DEL.Value = objFLG_DEL;
            dto.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dto.UPD_DATE.Value = DateTime.Now;
            dto.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;

            biz.UpdateUserScreenPermissionFlagVIEW(dto);
        }
        internal void UpdateUserScreenPermissionFlagADD(int objFLG_ADD, string UserCD, string ScreenCD)
        {
            AuthorizedMaintenanceBIZ biz = new AuthorizedMaintenanceBIZ();

            UserScreenPermissionDTO dto = new UserScreenPermissionDTO();
            dto.SCREEN_CD.Value = ScreenCD;
            dto.USER_CD.Value = UserCD;
            //dto.FLG_VIEW.Value = objFLG_VIEW;
            dto.FLG_ADD.Value = objFLG_ADD;
            //dto.FLG_CHG.Value = objFLG_CHG;
            //dto.FLG_DEL.Value = objFLG_DEL;
            dto.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dto.UPD_DATE.Value = DateTime.Now;
            dto.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;

            biz.UpdateUserScreenPermissionFlagADD(dto);
        }
        internal void UpdateUserScreenPermissionFlagCHG(int objFLG_CHG, string UserCD, string ScreenCD)
        {
            AuthorizedMaintenanceBIZ biz = new AuthorizedMaintenanceBIZ();

            UserScreenPermissionDTO dto = new UserScreenPermissionDTO();
            dto.SCREEN_CD.Value = ScreenCD;
            dto.USER_CD.Value = UserCD;
            //dto.FLG_VIEW.Value = objFLG_VIEW;
            //dto.FLG_ADD.Value = objFLG_ADD;
            dto.FLG_CHG.Value = objFLG_CHG;
            //dto.FLG_DEL.Value = objFLG_DEL;
            dto.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dto.UPD_DATE.Value = DateTime.Now;
            dto.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;

            biz.UpdateUserScreenPermissionFlagCHG(dto);
        }
        internal void UpdateUserScreenPermissionFlagDEL(int objFLG_DEL, string UserCD, string ScreenCD)
        {
            AuthorizedMaintenanceBIZ biz = new AuthorizedMaintenanceBIZ();

            UserScreenPermissionDTO dto = new UserScreenPermissionDTO();
            dto.SCREEN_CD.Value = ScreenCD;
            dto.USER_CD.Value = UserCD;
            //dto.FLG_VIEW.Value = objFLG_VIEW;
            //dto.FLG_ADD.Value = objFLG_ADD;
            //dto.FLG_CHG.Value = objFLG_CHG;
            dto.FLG_DEL.Value = objFLG_DEL;
            dto.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dto.UPD_DATE.Value = DateTime.Now;
            dto.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;

            biz.UpdateUserScreenPermissionFlagDEL(dto);
        }

        internal void AddUserScreenPermissionFlag(int objFLG_VIEW, int objFLG_ADD, int objFLG_CHG, int objFLG_DEL, string UserCD, string ScreenCD)
        {
            AuthorizedMaintenanceBIZ biz = new AuthorizedMaintenanceBIZ();

            UserScreenPermissionDTO dto = new UserScreenPermissionDTO();
            dto.SCREEN_CD.Value = ScreenCD;
            dto.USER_CD.Value = UserCD;
            dto.FLG_VIEW.Value = objFLG_VIEW;
            dto.FLG_ADD.Value = objFLG_ADD;
            dto.FLG_CHG.Value = objFLG_CHG;
            dto.FLG_DEL.Value = objFLG_DEL;
            dto.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dto.CRT_DATE.Value = DateTime.Now;
            dto.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
            dto.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dto.UPD_DATE.Value = DateTime.Now;
            dto.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;

            biz.AddUserScreenPermissionFlag(dto);
        }



        internal bool isExistUserScreenPermission(string ScreenCD, string UserCD)
        {
            AuthorizedMaintenanceBIZ biz = new AuthorizedMaintenanceBIZ();
            NZString screenCD = new NZString(null, ScreenCD);
            NZString userCD = new NZString(null, UserCD);
            return biz.isExistUserScreenPermission(screenCD, userCD);
        }

        internal void UpdateGroupScreenPermissionFlagVIEW(int objFLG_VIEW, string GroupCD, string ScreenCD)
        {
            AuthorizedMaintenanceBIZ biz = new AuthorizedMaintenanceBIZ();

            GroupScreenPermissionDTO dto = new GroupScreenPermissionDTO();
            dto.SCREEN_CD.Value = ScreenCD;
            dto.GROUP_CD.Value = GroupCD;
            dto.FLG_VIEW.Value = objFLG_VIEW;
            //dto.FLG_ADD.Value = objFLG_ADD;
            //dto.FLG_CHG.Value = objFLG_CHG;
            //dto.FLG_DEL.Value = objFLG_DEL;
            dto.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dto.UPD_DATE.Value = DateTime.Now;
            dto.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;

            biz.UpdateGroupScreenPermissionFlagVIEW(dto);
        }
        internal void UpdateGroupScreenPermissionFlagADD(int objFLG_ADD, string GroupCD, string ScreenCD)
        {
            AuthorizedMaintenanceBIZ biz = new AuthorizedMaintenanceBIZ();

            GroupScreenPermissionDTO dto = new GroupScreenPermissionDTO();
            dto.SCREEN_CD.Value = ScreenCD;
            dto.GROUP_CD.Value = GroupCD;
            //dto.FLG_VIEW.Value = objFLG_VIEW;
            dto.FLG_ADD.Value = objFLG_ADD;
            //dto.FLG_CHG.Value = objFLG_CHG;
            //dto.FLG_DEL.Value = objFLG_DEL;
            dto.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dto.UPD_DATE.Value = DateTime.Now;
            dto.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;

            biz.UpdateGroupScreenPermissionFlagADD(dto);
        }
        internal void UpdateGroupScreenPermissionFlagCHG(int objFLG_CHG, string GroupCD, string ScreenCD)
        {
            AuthorizedMaintenanceBIZ biz = new AuthorizedMaintenanceBIZ();

            GroupScreenPermissionDTO dto = new GroupScreenPermissionDTO();
            dto.SCREEN_CD.Value = ScreenCD;
            dto.GROUP_CD.Value = GroupCD;
            //dto.FLG_VIEW.Value = objFLG_VIEW;
            //dto.FLG_ADD.Value = objFLG_ADD;
            dto.FLG_CHG.Value = objFLG_CHG;
            //dto.FLG_DEL.Value = objFLG_DEL;
            dto.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dto.UPD_DATE.Value = DateTime.Now;
            dto.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;

            biz.UpdateGroupScreenPermissionFlagCHG(dto);
        }
        internal void UpdateGroupScreenPermissionFlagDEL(int objFLG_DEL, string GroupCD, string ScreenCD)
        {
            AuthorizedMaintenanceBIZ biz = new AuthorizedMaintenanceBIZ();

            GroupScreenPermissionDTO dto = new GroupScreenPermissionDTO();
            dto.SCREEN_CD.Value = ScreenCD;
            dto.GROUP_CD.Value = GroupCD;
            //dto.FLG_VIEW.Value = objFLG_VIEW;
            //dto.FLG_ADD.Value = objFLG_ADD;
            //dto.FLG_CHG.Value = objFLG_CHG;
            dto.FLG_DEL.Value = objFLG_DEL;
            dto.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dto.UPD_DATE.Value = DateTime.Now;
            dto.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;

            biz.UpdateGroupScreenPermissionFlagDEL(dto);
        }
    }
}
