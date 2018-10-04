using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemMaintenance.DTO;
using EVOFramework.Database;

namespace SystemMaintenance.Oracle.DAO
{
    partial class MenuSetDetailDAO
    {
        /// <summary>
        /// Key:
        /// <para>MENU_SUB_CD, MENU_SET_CD, DISP_SEQ, MENU_SUB_NAME, CRT_BY, CRT_DATE, CRT_MACHINE, UPD_BY, UPD_DATE, UPD_MACHINE</para>
        /// </summary>
        /// <param name="database"></param>
        /// <param name="MenuSetCD"></param>
        /// <returns></returns>
        public System.Data.DataTable LoadMenuSubByMenuSetCD(Database database, string MenuSetCD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine("  SELECT  ");
            sb.AppendLine("    T.MENU_SUB_CD ");
            sb.AppendLine("    ,T.MENU_SET_CD ");
            sb.AppendLine("    ,T.DISP_SEQ ");
            sb.AppendLine("    ,TT.MENU_SUB_NAME ");
            sb.AppendLine("    ,T.CRT_BY ");
            sb.AppendLine("    ,T.CRT_DATE ");
            sb.AppendLine("    ,T.CRT_MACHINE ");
            sb.AppendLine("    ,T.UPD_BY ");
            sb.AppendLine("    ,T.UPD_DATE ");
            sb.AppendLine("    ,T.UPD_MACHINE ");
            sb.AppendLine("  FROM TZ_MENU_SET_DETAIL_MS T ");
            sb.AppendLine("  INNER JOIN TZ_MENU_SUB_MS TT ");
            sb.AppendLine("  ON T.MENU_SUB_CD = TT.MENU_SUB_CD ");
            sb.AppendLine("  WHERE MENU_SET_CD = :MENU_SET_CD ");
            sb.AppendLine("  ORDER BY DISP_SEQ  ");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("MENU_SET_CD", DataType.VarChar, MenuSetCD);
            return db.ExecuteQuery(req);
        }

        public List<MenuSetDetailDTO> LoadAllMenuSubByMenuSetCD(Database database, string MenuSetCD) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();

            #region SQL Statement

            sb.AppendLine(" SELECT ");
            sb.AppendLine("   MENU_SUB_CD");
            sb.AppendLine("   ,MENU_SET_CD");
            sb.AppendLine("   ,DISP_SEQ");
            sb.AppendLine("   ,CRT_BY");
            sb.AppendLine("   ,CRT_DATE");
            sb.AppendLine("   ,CRT_MACHINE");
            sb.AppendLine("   ,UPD_BY");
            sb.AppendLine("   ,UPD_DATE");
            sb.AppendLine("   ,UPD_MACHINE");
            sb.AppendLine(" FROM TZ_MENU_SET_DETAIL_MS ");
            sb.AppendLine(" WHERE MENU_SET_CD = :MENU_SET_CD ");
            sb.AppendLine(" ORDER BY DISP_SEQ ");



            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("MENU_SET_CD", DataType.VarChar, MenuSetCD);
            return db.ExecuteForList<MenuSetDetailDTO>(req);
        }

        /// <summary>
        /// Load All Menu Sub that not regist to MenuSet
        /// </summary>
        /// <param name="database"></param>
        /// <param name="MenuSetCD"></param>
        /// <returns></returns>
        public List<MenuSubDTO> LoadAllMenuSubNotInMenuSet(Database database, string MenuSetCD)
        {
            Database db = UseDatabase(database);

            string sql = @"SELECT T.*
                              FROM TZ_MENU_SUB_MS T
                             WHERE T.MENU_SUB_CD NOT IN
                                   (SELECT TT.MENU_SUB_CD
                                      FROM TZ_MENU_SET_DETAIL_MS TT
                                     WHERE TT.MENU_SET_CD = :MENU_SET_CD)";

            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("MENU_SET_CD", DataType.VarChar, MenuSetCD);
            List<MenuSubDTO> dtoList = db.ExecuteForList<MenuSubDTO>(req);
            return dtoList;
        }

        /// <summary>
        /// Get Last Display SEQ
        /// </summary>
        /// <param name="database"></param>
        /// <param name="MenuSetCD"></param>
        /// <returns></returns>
        public int GetLastDisplaySEQ(Database database, string MenuSetCD)
        {
            Database db = UseDatabase(database);

            string sql = @"SELECT NVL(MAX(T.DISP_SEQ), 0)
                              FROM TZ_MENU_SET_DETAIL_MS T
                             WHERE T.MENU_SET_CD = :MENU_SET_CD";

            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("MENU_SET_CD", DataType.VarChar, MenuSetCD);
            System.Data.DataTable dt = db.ExecuteQuery(req);

            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public int DeleteByMenuSetCD(Database database, string MenuSetCD)
        {
            Database db = UseDatabase(database);

            string sql = @"DELETE FROM TZ_MENU_SET_DETAIL_MS
                             WHERE T.MENU_SET_CD = :MENU_SET_CD";

            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("MENU_SET_CD", DataType.VarChar, MenuSetCD);
           
            return db.ExecuteNonQuery(req);
        }
    }
}
