using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using SystemMaintenance.BIZ;
using SystemMaintenance.UIDM;
using SystemMaintenance.DTO;
using System.Data;

namespace SystemMaintenance.Controller
{
    public class MenuRegisterController
    {
        public MenuRegisterUIDM LoadMenuList() {
            MenuRegisterUIDM model = new MenuRegisterUIDM();

            MenuSetMaintenanceBIZ bizMenuSet = new MenuSetMaintenanceBIZ();
            MenuSubMaintenanceBIZ bizMenuSub = new MenuSubMaintenanceBIZ();
            NZString langCD = CommonLib.Common.CurrentUserInfomation.LanguageCD;

            // Load All MenuSet
            List<MenuSetDTO> listMenuSetDTO = bizMenuSet.LoadAllMenuSet();
            for (int i=0; i<listMenuSetDTO.Count; i++) {
                MenuSetDTO menuSetDTO = listMenuSetDTO[i];
                MenuRegisterUIDM.MenuSet menuSet = new MenuRegisterUIDM.MenuSet();
                menuSet.MENU_SET_CD.Value = menuSetDTO.MENU_SET_CD.Value;
                menuSet.MENU_SET_NAME.Value = menuSetDTO.MENU_SET_NAME.Value;

                

                // Load MenuSub which is child of MenuSet.
                List<MenuSetDetailDTO> listMenuSetDetail = bizMenuSet.LoadAllMenuSubByMenuSetCD(menuSet.MENU_SET_CD.StrongValue);                
                for (int iDetail = 0; iDetail<listMenuSetDetail.Count; iDetail++) {
                    MenuSetDetailDTO menuSetDetailDTO = listMenuSetDetail[iDetail];

                    // Load description of each MenuSub
                    DataTable dtMenuSubDescription = bizMenuSub.LoadMenuSubWithLang(menuSetDetailDTO.MENU_SUB_CD, langCD);


                    MenuRegisterUIDM.MenuSub menuSub = new MenuRegisterUIDM.MenuSub(menuSet);
                    menuSub.MENU_SUB_CD.Value = menuSetDetailDTO.MENU_SUB_CD.Value;                    
                    if (dtMenuSubDescription.Rows.Count > 0) {
                        menuSub.MENU_SUB_NAME.Value = dtMenuSubDescription.Rows[0][(int) MenuSubDTO.eColumns.MENU_SUB_NAME];
                        menuSub.MENU_SUB_DESC.Value = dtMenuSubDescription.Rows[0][(int)MenuSubLangDTO.eColumns.MENU_SUB_DESC];
                    }


                    // Add menuSub object into MenuSet object.
                    menuSet.ListMenuSub.Add(menuSub);
                }

                model.ListMenuHierachy.Add(menuSet);
            }

            return model;
        }

        /// <summary>
        /// Key:
        /// <para>SEL, SCREEN_CD, SCREEN_NAME</para>
        /// </summary>
        /// <param name="menuSubCD"></param>
        /// <returns></returns>
        public DataTable LoadScreenFromMenuSub(NZString menuSubCD) {
            MenuSubItemBIZ bizMenuSubItem = new MenuSubItemBIZ();
            ScreenBIZ bizScreen = new ScreenBIZ();

            //NZString langCD = CommonLib.Common.CurrentUserInfomation.LanguageCD;
            List<MenuSubItemDTO> listMenuSubItem =  bizMenuSubItem.LoadMenuSubItemOfMenuSub(menuSubCD);

            DataTable dtView = new DataTable("SCREEN_LIST");
            dtView.Columns.Add("SEL", typeof (bool));
            dtView.Columns.Add("SCREEN_CD", typeof (string));
            dtView.Columns.Add("SCREEN_NAME", typeof(string));

            for (int i=0; i<listMenuSubItem.Count; i++) {

                // Load screen detail
                NZString screenCD = listMenuSubItem[i].SCREEN_CD;
                DatabaseScreen dbScreen = bizScreen.LoadScreen(screenCD);

                dtView.Rows.Add(
                    false,
                    dbScreen.ScreenCD.StrongValue,
                    dbScreen.ScreenDescription.NVL(string.Empty)
                    );
            }

            return dtView;
        }        

        public DataTable LoadAllScreenForRegister(NZString menuSubCD) {
            MenuSubItemBIZ bizMenuSubItem = new MenuSubItemBIZ();
            ScreenBIZ bizScreen = new ScreenBIZ();

            List<ScreenDTO> listMenuSubItem = bizMenuSubItem.LoadAllScreenForRegister(menuSubCD);

            DataTable dtView = new DataTable("SCREEN_LIST");
            dtView.Columns.Add("SEL", typeof(bool));
            dtView.Columns.Add("SCREEN_CD", typeof(string));
            dtView.Columns.Add("SCREEN_NAME", typeof(string));

            for (int i = 0; i < listMenuSubItem.Count; i++)
            {

                // Load screen detail
                NZString screenCD = listMenuSubItem[i].SCREEN_CD;
                DatabaseScreen dbScreen = bizScreen.LoadScreen(screenCD);

                dtView.Rows.Add(
                    false,
                    dbScreen.ScreenCD.StrongValue,
                    dbScreen.ScreenDescription.NVL(string.Empty)
                    );
            }

            return dtView;
        }

        public void RegisterScreen(NZString menuSubCD, params NZString[] screenCDs) {
            MenuSubItemBIZ biz = new MenuSubItemBIZ();
            biz.AddMenuSubItems(menuSubCD, screenCDs);
        }
        public void RemoveScreen(NZString menuSubCD, params NZString[] screenCDs)
        {
            MenuSubItemBIZ biz = new MenuSubItemBIZ();
            biz.RemoveMenuSubItems(menuSubCD, screenCDs);        
        }

        public void SwapDisplaySequence(NZString sourceMenuSubCD, NZString sourceScreenCD, NZString destMenuSubCD, NZString destScreenCD)
        {
            MenuRegisterBIZ biz = new MenuRegisterBIZ();
            biz.SwapDisplaySequence(sourceMenuSubCD, sourceScreenCD, destMenuSubCD, destScreenCD);
        }
    }
}
