using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using EVOFramework.Database;
using EVOFramework.Data;
using SystemMaintenance.DTO;

namespace SystemMaintenance.Oracle.DAO
{
    partial class MenuSubLangDAO
    {
        /// <summary>
        /// Delete MenuSub on all language.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="MENU_SUB_CD"></param>
        /// <returns></returns>
        public int DeleteOnAllLang(Database database, NZString MENU_SUB_CD) {
            Database db = UseDatabase(database);

            string tableName = DTOUtility.ReadTableName(typeof (MenuSubLangDTO));
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE MENU_SUB_CD=:MENU_SUB_CD");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("MENU_SUB_CD", DataType.NVarChar, MENU_SUB_CD.Value);

            return db.ExecuteNonQuery(req);
        }
    }
}
