using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Data;
using EVOFramework.Database;
using CommonLib;
using System.Data;
using SystemMaintenance.UIDataModel;
using SystemMaintenance.DTO;
using EVOFramework;

namespace SystemMaintenance.DAO
{
    partial interface IMenuDAO
    {
        string GetMenuSetCDFromUser(string USER_ACCOUNT);

        /// <summary>
        /// Get list of MenuSub from specific user code.
        /// </summary>
        /// <param name="USER_ACCOUNT"></param>
        /// <param name="DEF_LANG"></param>
        /// <returns></returns>
        List<MenuSub> GetAllMenuSubFromUser(NZString USER_ACCOUNT, NZString DEF_LANG);

        /// <summary>
        /// Get all menu item that underly on specific MenuSub.
        /// </summary>
        /// <param name="MENU_SUB_CD"></param>
        /// <returns></returns>
        List<MenuSubItemDTO> GetAllMenuSubItem(string MENU_SUB_CD, string USER_ACCOUNT);

        DataTable GetScreenFavorite(string USER_ACCOUNT);

        int GetLastFavoriteSeq(string USER_ACCOUNT);

        void AddNewFavorite(string USER_ACCOUNT, string SCREEN_CD);

        void DeleteFavorite(string USER_ACCOUNT, string SCREEN_CD);
    }
}
