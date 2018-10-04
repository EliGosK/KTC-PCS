using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemMaintenance.DTO;
using EVOFramework;
using EVOFramework.Database;

namespace SystemMaintenance.Oracle.DAO
{
    partial class MenuSubItemDAO
    {
        /// <summary>
        /// Load all registered menu item on the specific MenuSub.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="MENU_SUB_CD"></param>
        /// <returns></returns>
        public List<MenuSubItemDTO> LoadAllMenuSubItemsFromMenuSub(Database database, NZString MENU_SUB_CD) {
            Database db = UseDatabase(database);

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(MenuSubItemDTO));
            StringBuilder sb= new StringBuilder();
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + MenuSubItemDTO.eColumns.MENU_SUB_CD);
            sb.AppendLine("  ," + MenuSubItemDTO.eColumns.SCREEN_CD);
            sb.AppendLine("  ," + MenuSubItemDTO.eColumns.DISP_SEQ);
            sb.AppendLine("  ," + MenuSubItemDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + MenuSubItemDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + MenuSubItemDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + MenuSubItemDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + MenuSubItemDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + MenuSubItemDTO.eColumns.UPD_MACHINE);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + MenuSubItemDTO.eColumns.MENU_SUB_CD + "=:MENU_SUB_CD");
            sb.AppendLine(" ORDER BY " + MenuSubItemDTO.eColumns.DISP_SEQ + ", " + MenuSubItemDTO.eColumns.SCREEN_CD);

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("MENU_SUB_CD", DataType.NVarChar, MENU_SUB_CD.Value);

            return db.ExecuteForList<MenuSubItemDTO>(req);
        }
        
        /// <summary>
        /// Load all screen that not include with screen that is registerd on MenuSubCD.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="MENU_SUB_CD"></param>
        /// <returns></returns>
        public List<ScreenDTO> LoadAllScreenExcludeOnMenuSub(Database database, NZString MENU_SUB_CD) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT");
            sb.AppendLine("   T.*");
            sb.AppendLine(" FROM TZ_SCREEN_MS T");
            sb.AppendLine(" WHERE");
            sb.AppendLine("   T.SCREEN_CD NOT IN (");
            sb.AppendLine("     SELECT X.SCREEN_CD");
            sb.AppendLine("     FROM TZ_MENU_SUB_ITEM_MS X");
            sb.AppendLine("     WHERE X.MENU_SUB_CD = :MENU_SUB_CD");
            sb.AppendLine("   )");
            sb.AppendLine(" ORDER BY T.SCREEN_CD, T.SCREEN_NAME");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("MENU_SUB_CD", DataType.NVarChar, MENU_SUB_CD.Value);

            return db.ExecuteForList<ScreenDTO>(req);
        }
        /// <summary>
        /// Get new sequence no of Menu sub item on MenuSub.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="MENU_SUB_CD"></param>
        /// <returns></returns>
        public NZInt GetNewSequenceNo(Database database, NZString MENU_SUB_CD) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT");
            sb.AppendLine("   MAX(T.DISP_SEQ) AS \"SEQ\"");
            sb.AppendLine(" FROM TZ_MENU_SUB_ITEM_MS T");
            sb.AppendLine(" WHERE");
            sb.AppendLine("   T.MENU_SUB_CD = :MENU_SUB_CD");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("MENU_SUB_CD", DataType.NVarChar, MENU_SUB_CD.Value);

            object obj = db.ExecuteScalar(req);
            if (obj == null || obj == DBNull.Value)
                return 1.ToNZInt();

            return (Convert.ToInt32(obj) + 1).ToNZInt();
        }

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
        public int UpdateSequence(Database database, NZString MENU_SUB_CD, NZString SCREEN_CD, NZString UPD_BY, NZString UPD_MACHINE, NZInt newSEQ) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" UPDATE TZ_MENU_SUB_ITEM_MS ");
            sb.AppendLine(" SET ");
            sb.AppendLine("  DISP_SEQ=:DISP_SEQ");
            sb.AppendLine("  ,UPD_BY=:UPD_BY");
            sb.AppendLine("  ,UPD_MACHINE=:UPD_MACHINE");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  MENU_SUB_CD=:MENU_SUB_CD");
            sb.AppendLine("  AND SCREEN_CD=:SCREEN_CD");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("DISP_SEQ", DataType.Int32, newSEQ.Value);
            req.Parameters.Add("UPD_BY", DataType.NVarChar, UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, UPD_MACHINE.Value);
            req.Parameters.Add("MENU_SUB_CD", DataType.NVarChar, MENU_SUB_CD.Value);
            req.Parameters.Add("SCREEN_CD", DataType.NVarChar, SCREEN_CD.Value);

            return db.ExecuteNonQuery(req);

        }
    }
}
