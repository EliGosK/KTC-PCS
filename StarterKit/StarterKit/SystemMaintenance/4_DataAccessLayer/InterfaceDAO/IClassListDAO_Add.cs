using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemMaintenance.DTO;
using EVOFramework.Database;
using EVOFramework;

namespace SystemMaintenance.DAO
{
    partial interface IClassListDAO
    {
        /// <summary>
        /// Load all ClassType where condition at CLS_INFO_CD.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="CLS_INFO_CD"></param>
        /// <returns></returns>
        List<ClassListDTO> LoadByClassInfo(Database database, NZString CLS_INFO_CD);
    }
}
