using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using EVOFramework.Database;
using EVOFramework.Data;
using SystemMaintenance.DTO;

namespace SystemMaintenance.DAO
{
    partial interface IMenuSubLangDAO
    {
        /// <summary>
        /// Delete MenuSub on all language.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="MENU_SUB_CD"></param>
        /// <returns></returns>
        int DeleteOnAllLang(Database database, NZString MENU_SUB_CD);
    }
}
