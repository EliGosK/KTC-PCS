using System.Text;
using EVOFramework;
using EVOFramework.Database;
using System.Data;
using System.Collections.Generic;
using SystemMaintenance.DTO;

namespace SystemMaintenance.Oracle.DAO
{
    partial class MenuSubDAO
    {
        /// <summary>
        /// Load all menu sub with own description depend on the specific language.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="langCD"></param>
        /// <returns></returns>
        public DataTable LoadAllMenuSubWithDescription(Database database, NZString langCD) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT");
            sb.AppendLine("  T.MENU_SUB_CD");
            sb.AppendLine("  , T.MENU_SUB_NAME");
            sb.AppendLine("  , TL.MENU_SUB_DESC");
            sb.AppendLine(" FROM");
            sb.AppendLine("  TZ_MENU_SUB_MS T");
            sb.AppendLine("  LEFT JOIN TZ_MENU_SUB_LANG_MS TL");
            sb.AppendLine("    ON T.MENU_SUB_CD = TL.MENU_SUB_CD");
            sb.AppendLine("         AND TL.LANG_CD = :LANG_CD");            
            sb.AppendLine(" ORDER BY T.MENU_SUB_CD, T.MENU_SUB_NAME");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("LANG_CD", DataType.NVarChar, langCD.Value);

            return db.ExecuteQuery(req);
        }

        /// <summary>
        /// Load menu sub with own description depend on the specific language.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="menuSubCD"></param>
        /// <param name="langCD"></param>
        /// <returns></returns>
        public DataTable LoadMenuSubWithDescription(Database database, NZString menuSubCD, NZString langCD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT");
            sb.AppendLine("  T.MENU_SUB_CD");
            sb.AppendLine("  , T.MENU_SUB_NAME");
            sb.AppendLine("  , TL.MENU_SUB_DESC");
            sb.AppendLine(" FROM");
            sb.AppendLine("  TZ_MENU_SUB_MS T");
            sb.AppendLine("  LEFT JOIN TZ_MENU_SUB_LANG_MS TL");
            sb.AppendLine("    ON T.MENU_SUB_CD = TL.MENU_SUB_CD");
            sb.AppendLine("         AND TL.LANG_CD = :LANG_CD");
            sb.AppendLine(" WHERE T.MENU_SUB_CD = :MENU_SUB_CD");
            sb.AppendLine(" ORDER BY T.MENU_SUB_CD, T.MENU_SUB_NAME");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("MENU_SUB_CD", DataType.NVarChar, menuSubCD.Value);
            req.Parameters.Add("LANG_CD", DataType.NVarChar, langCD.Value);

            return db.ExecuteQuery(req);
        }

        /// <summary>
        /// Update menu sub description depend on specific language.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="menuSubCD">Update on MenuSub CD</param>
        /// <param name="langCD">Update on Language CD</param>
        /// <param name="description">Value to update</param>
        /// <returns></returns>
        public int UpdateMenuSubDescription(Database database, NZString menuSubCD, NZString langCD, NZString description) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" UPDATE TZ_MENU_SUB_LANG_MS ");
            sb.AppendLine(" SET MENU_SUB_DESC = :MENU_SUB_DESC");
            sb.AppendLine("    ,UPD_BY = :UPD_BY");
            sb.AppendLine("    ,UPD_MACHINE = :UPD_MACHINE");
            sb.AppendLine("    ,UPD_DATE = SYSDATE");
            sb.AppendLine(" WHERE");
            sb.AppendLine("    MENU_SUB_CD = :MENU_SUB_CD");
            sb.AppendLine("    AND LANG_CD = :LANG_CD");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("MENU_SUB_CD", DataType.NVarChar, menuSubCD.Value);
            req.Parameters.Add("LANG_CD", DataType.NVarChar, langCD.Value);
            req.Parameters.Add("MENU_SUB_DESC", DataType.NVarChar, description.Value);
            req.Parameters.Add("UPD_BY", DataType.NVarChar, CommonLib.Common.CurrentUserInfomation.UserCD.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, CommonLib.Common.CurrentUserInfomation.Machine.Value);


            return db.ExecuteNonQuery(req);
        }

       
    }
}
