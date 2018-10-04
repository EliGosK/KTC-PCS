using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemMaintenance.DTO;
using EVOFramework;
using EVOFramework.Database;

namespace SystemMaintenance.DAO
{
    partial interface IMenuSubItemDAO
    {
        /// <summary>
        /// Load all registered menu item on the specific MenuSub.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="MENU_SUB_CD"></param>
        /// <returns></returns>
        List<MenuSubItemDTO> LoadAllMenuSubItemsFromMenuSub(Database database, NZString MENU_SUB_CD);

        /// <summary>
        /// Load all screen that not include with screen that is registerd on MenuSubCD.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="MENU_SUB_CD"></param>
        /// <returns></returns>
        List<ScreenDTO> LoadAllScreenExcludeOnMenuSub(Database database, NZString MENU_SUB_CD);

        /// <summary>
        /// Get new sequence no of Menu sub item on MenuSub.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="MENU_SUB_CD"></param>
        /// <returns></returns>
        NZInt GetNewSequenceNo(Database database, NZString MENU_SUB_CD);

        /// <summary>
        /// Update display sequence only.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="MENU_SUB_CD"></param>
        /// <param name="SCREEN_CD"></param>        
        /// <param name="UPD_BY"></param>
        /// <param name="UPD_MACHINE"></param>
        /// <param name="newSEQ"></param>
        /// <returns></returns>
        int UpdateSequence(Database database, NZString MENU_SUB_CD, NZString SCREEN_CD, NZString UPD_BY, NZString UPD_MACHINE, NZInt newSEQ);
    }
}
