using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SystemMaintenance.BIZ;
using EVOFramework.Data;
using SystemMaintenance.DTO;
using SystemMaintenance.UIDataModel;

namespace SystemMaintenance.Controller
{
    class MenuSetMaintenanceController
    {
        internal DataTable LoadAllMenuSet()
        {
            MenuSetMaintenanceBIZ biz = new MenuSetMaintenanceBIZ();
            return DTOUtility.ConvertListToDataTable(biz.LoadAllMenuSet());
        }

        internal DataTable LoadMenuSubByMenuSetCD(string MenuSetCD)
        {
            MenuSetMaintenanceBIZ biz = new MenuSetMaintenanceBIZ();
            return biz.LoadMenuSubByMenuSetCD(MenuSetCD);
        }

        internal void SaveMenuSetDesc(string menuSetCD, string menuSetDesc)
        {
            MenuSetMaintenanceBIZ biz = new MenuSetMaintenanceBIZ();
            MenuSetDTO dto = new MenuSetDTO();
            dto.MENU_SET_CD.Value = menuSetCD;
            dto.MENU_SET_NAME.Value = menuSetDesc;
            dto.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dto.UPD_DATE.Value = DateTime.Now;
            dto.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
            biz.UpdateMenuSetDesc(dto);
        }

        internal int DeleteMenuSet(string menuSetCD)
        {
            MenuSetMaintenanceBIZ biz = new MenuSetMaintenanceBIZ();
            MenuSetDTO dto = new MenuSetDTO();
            dto.MENU_SET_CD.Value = menuSetCD;

            return biz.DeleteMenuSet(dto);
        }

        internal int AddNewMenuSet(MenuSetMaintenanceUIDM uidm)
        {
            MenuSetMaintenanceBIZ biz = new MenuSetMaintenanceBIZ();
            MenuSetDTO dto = new MenuSetDTO();
            dto.MENU_SET_CD = uidm.MenuSetCD;
            dto.MENU_SET_NAME = uidm.MenuSetDesc;
            dto.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dto.CRT_DATE.Value = DateTime.Now;
            dto.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
            dto.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dto.UPD_DATE.Value = DateTime.Now;
            dto.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;

            return biz.AddNewMenuSet(dto);
        }

        internal int DeleteMenuSetDetail(string menuSetCD, string menuSubCD)
        {
            MenuSetMaintenanceBIZ biz = new MenuSetMaintenanceBIZ();
            MenuSetDetailDTO dto = new MenuSetDetailDTO();
            dto.MENU_SET_CD.Value = menuSetCD;
            dto.MENU_SUB_CD.Value = menuSubCD;
            return biz.DeleteMenuSetDetail(dto);
        }

        internal DataTable LoadAllMenuSubNotInMenuSet(string menuSetCD)
        {
            MenuSetMaintenanceBIZ biz = new MenuSetMaintenanceBIZ();
            return DTOUtility.ConvertListToDataTable(biz.LoadAllMenuSubNotInMenuSet(menuSetCD));
        }

        internal int AddMenuSetDetail(string MenuSetCD, string MenuSubCD)
        {
            MenuSetMaintenanceBIZ biz = new MenuSetMaintenanceBIZ();
            MenuSetDetailDTO dto = new MenuSetDetailDTO();
            dto.MENU_SET_CD.Value = MenuSetCD;
            dto.MENU_SUB_CD.Value = MenuSubCD;
            dto.DISP_SEQ.Value = GetLastDisplaySEQ(MenuSetCD) + 1;
            dto.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dto.CRT_DATE.Value = DateTime.Now;
            dto.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
            dto.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dto.UPD_DATE.Value = DateTime.Now;
            dto.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
            return biz.AddMenuSetDetail(dto);
        }

        private int GetLastDisplaySEQ(string MenuSetCD)
        {
            MenuSetMaintenanceBIZ biz = new MenuSetMaintenanceBIZ();
            return biz.GetLastDisplaySEQ(MenuSetCD);
        }

        internal void UpdateDisplaySEQ(string MenuSetCD, string MenuSubCD_UP, string MenuSubCD_DOWN, int DisplaySQ_UP, int DisplaySQ_DOWN)
        {
            MenuSetMaintenanceBIZ biz = new MenuSetMaintenanceBIZ();
            MenuSetDetailDTO dto = new MenuSetDetailDTO();
            dto.MENU_SET_CD.Value = MenuSetCD;
            dto.MENU_SUB_CD.Value = MenuSubCD_UP;
            dto.DISP_SEQ.Value = DisplaySQ_UP;

            dto.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dto.UPD_DATE.Value = DateTime.Now;
            dto.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
            biz.UpdateMenuSetDetailWithoutPK(dto);

            dto.MENU_SET_CD.Value = MenuSetCD;
            dto.MENU_SUB_CD.Value = MenuSubCD_DOWN;
            dto.DISP_SEQ.Value = DisplaySQ_DOWN;
            biz.UpdateMenuSetDetailWithoutPK(dto);
        }
    }
}
