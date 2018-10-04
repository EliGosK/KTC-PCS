using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemMaintenance.DTO;
using EVOFramework.Database;

namespace SystemMaintenance.DAO
{
    partial interface IMenuSetDetailDAO
    {
        /// <summary>
        /// Key:
        /// <para>MENU_SUB_CD, MENU_SET_CD, DISP_SEQ, MENU_SUB_NAME, CRT_BY, CRT_DATE, CRT_MACHINE, UPD_BY, UPD_DATE, UPD_MACHINE</para>
        /// </summary>
        /// <param name="database"></param>
        /// <param name="MenuSetCD"></param>
        /// <returns></returns>
        System.Data.DataTable LoadMenuSubByMenuSetCD(Database database, string MenuSetCD);

        List<MenuSetDetailDTO> LoadAllMenuSubByMenuSetCD(Database database, string MenuSetCD);
        /// <summary>
        /// Load All Menu Sub that not regist to MenuSet
        /// </summary>
        /// <param name="database"></param>
        /// <param name="MenuSetCD"></param>
        /// <returns></returns>
        List<MenuSubDTO> LoadAllMenuSubNotInMenuSet(Database database, string MenuSetCD);

        /// <summary>
        /// Get Last Display SEQ
        /// </summary>
        /// <param name="database"></param>
        /// <param name="MenuSetCD"></param>
        /// <returns></returns>
        int GetLastDisplaySEQ(Database database, string MenuSetCD);

        int DeleteByMenuSetCD(Database database, string MenuSetCD);
    }
}
