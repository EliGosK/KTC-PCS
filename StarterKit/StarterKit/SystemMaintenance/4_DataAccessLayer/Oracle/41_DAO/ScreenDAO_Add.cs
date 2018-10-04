using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Database;
using EVOFramework;
using System.Data;
using SystemMaintenance.DTO;
using EVOFramework.Windows.Forms;

namespace SystemMaintenance.Oracle.DAO
{
    partial class ScreenDAO
    {
        // Four steps to add Table Schema
        // 1. Check for already exist table name in TZ_SCREEN_MS
        // 2. If Table not exist then add table to TZ_SCREEN_MS
        // 3. Add Table details (column) to TZ_SCREEN_DETAIL_MS
        // 4. Add Multi Lang for Table details (column)

        public bool isScreenAlreadyExist(Database database, string TableName)
        {
            string sql = @"SELECT 1 FROM TZ_SCREEN_MS T
                            WHERE T.SCREEN_CD = :pTableName ";

            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("pTableName", DataType.VarChar, TableName);

            return (database.ExecuteQuery(req).Rows.Count > 0);
        }

        public int AddTableSchema(Database database, string TableName)
        {
            string sql = @"INSERT INTO TZ_SCREEN_MS
                              (SCREEN_CD,
                               SCREEN_NAME,
                               IMAGE_CD,
                               SCREEN_TYPE,
                               SCREEN_ACTION,
                               EXT_PROGRAM,
                               CRT_USER,
                               CRT_DATE,
                               UPD_USER,
                               UPD_DATE)
                            VALUES
                              (:TableName,
                               :TableName,
                               0,
                               0,
                               0,
                               0,
                               'SYSTEM',
                               SYSDATE,
                               'SYSTEM',
                               SYSDATE);";
            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("TableName", DataType.VarChar, TableName);

            return database.ExecuteNonQuery(req);
        }

        public int AddTableDetail(Database database, string TableName, string Owner)
        {
            string sql = @"INSERT INTO TZ_SCREEN_DETAIL_MS
                                (SELECT TABLE_NAME,
                                        COLUMN_NAME,
                                        'Field',
                                        'SYSTEM',
                                        SYSDATE,
                                        'SYSTEM',
                                        SYSDATE
                                   FROM ALL_TAB_COLUMNS T
                                  WHERE T.OWNER = :Owner
                                    AND T.TABLE_NAME = :TableName
                                    AND T.COLUMN_NAME NOT IN
                                        (SELECT TT.CONTROL_CD
                                           FROM TZ_SCREEN_DETAIL_MS TT
                                          WHERE TT.SCREEN_CD = :TableName))";
            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("TableName", DataType.VarChar, TableName);
            req.Parameters.Add("Owner", DataType.VarChar, Owner);
            return database.ExecuteNonQuery(req);
        }

        public int AddMultiLangforTableDetail(Database database, string TableName, string Owner, string[] LangCD)
        {
            if (LangCD.Length == 0)
                return 0;
            string sql = string.Empty;
            DataRequest req;
            for (int i = 0; i < LangCD.Length; i++)
            {
                sql = @"INSERT INTO TZ_SCREEN_DETAIL_LANG_MS
                            (SELECT T.COLUMN_NAME,
                                    :LangCD,
                                    T.TABLE_NAME,
                                    T.COLUMN_NAME,
                                    'SYSTEM',
                                    SYSDATE,
                                    'SYSTEM',
                                    SYSDATE
                               FROM ALL_TAB_COLUMNS T
                              WHERE T.OWNER = :Owner
                                AND T.TABLE_NAME = :TableName
                                AND T.COLUMN_NAME NOT IN
                                    (SELECT TT.CONTROL_CD
                                       FROM TZ_SCREEN_DETAIL_LANG_MS TT
                                      WHERE TT.SCREEN_CD = :TableName
                                      AND TT.LANG_CD = :LangCD))";
                req = new DataRequest(sql);
                req.Parameters.Add("TableName", DataType.VarChar, TableName);
                req.Parameters.Add("Owner", DataType.VarChar, Owner);
                req.Parameters.Add("LangCD", DataType.VarChar, LangCD[i]);
                database.ExecuteNonQuery(req);
            }
            return 1;
        }

        #region Screen Manager
        /// <summary>
        /// Select all screen on database.
        /// </summary>
        /// <returns>All Screens.</returns>
        public DatabaseScreenList SelectScreens(Database database, NZString userLangCD, NZString defLangCD) {
            Database db = this.UseDatabase(database);

            StringBuilder sb = new StringBuilder();            
            sb.AppendLine(" SELECT ");
            sb.AppendLine("   SCREEN_CD ");
            sb.AppendLine("   ,SCREEN_NAME ");
            sb.AppendLine("   ,IMAGE_CD ");
            sb.AppendLine("   ,SCREEN_TYPE ");
            sb.AppendLine("   ,SCREEN_ACTION ");
            sb.AppendLine("   ,EXT_PROGRAM ");
            sb.AppendLine("   ,CRT_BY ");
            sb.AppendLine("   ,CRT_DATE ");
            sb.AppendLine("   ,CRT_MACHINE ");
            sb.AppendLine("   ,UPD_BY ");
            sb.AppendLine("   ,UPD_DATE ");
            sb.AppendLine("   ,UPD_MACHINE ");
            sb.AppendLine(String.Format("   ,{0}FNZ_GET_SCREEN_DESC(T.SCREEN_CD,:LANG_CD, :DEF_LANG_CD) AS SCREEN_DESC",
                (db.Credential.Provider == DatabaseProvider.SQLSERVER) ? "dbo." : string.Empty));
            sb.AppendLine("   ,ORIGINAL_TITLE ");
            sb.AppendLine(" FROM TZ_SCREEN_MS T");
            sb.AppendLine(" ORDER BY T.SCREEN_CD");

            DataRequest request = new DataRequest(sb.ToString());
            request.Parameters.Add("LANG_CD", DataType.NVarChar, userLangCD.Value);
            request.Parameters.Add("DEF_LANG_CD", DataType.NVarChar, defLangCD.Value);
            
            DataTable table = db.ExecuteQuery(request);

            DatabaseScreenList listDatabaseScreen = new DatabaseScreenList();
            for (int i = 0; i < table.Rows.Count; i++) {
                DatabaseScreen screen = new DatabaseScreen();
                screen.ScreenCD.Value = table.Rows[i][ScreenDTO.eColumns.SCREEN_CD.ToString()];
                screen.ScreenName.Value = table.Rows[i][ScreenDTO.eColumns.SCREEN_NAME.ToString()];
                screen.ImageCD.Value = table.Rows[i][ScreenDTO.eColumns.IMAGE_CD.ToString()];
                object obj = table.Rows[i][ScreenDTO.eColumns.SCREEN_TYPE.ToString()];
                screen.ScreenType = (eScreenType) Enum.Parse(typeof (eScreenType), obj.ToString());
                obj = table.Rows[i][ScreenDTO.eColumns.SCREEN_ACTION.ToString()];
                screen.ShowAction = (eShowAction)Enum.Parse(typeof(eShowAction), obj.ToString());
                screen.ExternalProgram.Value = table.Rows[i][ScreenDTO.eColumns.EXT_PROGRAM.ToString()];
                screen.ScreenDescription.Value = table.Rows[i][ScreenLangDTO.eColumns.SCREEN_DESC.ToString()];
                

                listDatabaseScreen.Add(screen);
            }

            return listDatabaseScreen;
        }           

        /// <summary>
        /// Select the specific screen code.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="screenCD">Screen Code</param>
        /// <param name="userLangCD">User language.</param>
        /// <returns></returns>
        public DatabaseScreen SelectScreen(Database database, NZString screenCD, NZString userLangCD, NZString defLangCD)
        {
            Database db = this.UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT ");
            sb.AppendLine("   SCREEN_CD ");
            sb.AppendLine("   ,SCREEN_NAME ");
            sb.AppendLine("   ,IMAGE_CD ");
            sb.AppendLine("   ,SCREEN_TYPE ");
            sb.AppendLine("   ,SCREEN_ACTION ");
            sb.AppendLine("   ,EXT_PROGRAM ");
            sb.AppendLine("   ,CRT_BY ");
            sb.AppendLine("   ,CRT_DATE ");
            sb.AppendLine("   ,CRT_MACHINE ");
            sb.AppendLine("   ,UPD_BY ");
            sb.AppendLine("   ,UPD_DATE ");
            sb.AppendLine("   ,UPD_MACHINE ");
            sb.AppendLine(String.Format("   ,{0}FNZ_GET_SCREEN_DESC(T.SCREEN_CD,:LANG_CD, :DEF_LANG_CD) AS SCREEN_DESC",
                (db.Credential.Provider == DatabaseProvider.SQLSERVER) ? "dbo." : string.Empty));
            sb.AppendLine(" FROM TZ_SCREEN_MS T");
            sb.AppendLine(" WHERE T.SCREEN_CD = :SCREEN_CD ");

            DataRequest request = new DataRequest(sb.ToString());
            request.Parameters.Add("LANG_CD", DataType.NVarChar, userLangCD.Value);
            request.Parameters.Add("SCREEN_CD", DataType.NVarChar, screenCD.Value);
            request.Parameters.Add("DEF_LANG_CD", DataType.NVarChar, defLangCD.Value);

            
            DataTable table = db.ExecuteQuery(request);

            if (table.Rows.Count > 0)
            {
                DatabaseScreen screen = new DatabaseScreen();
                screen.ScreenCD.Value = table.Rows[0][ScreenDTO.eColumns.SCREEN_CD.ToString()];
                screen.ScreenName.Value = table.Rows[0][ScreenDTO.eColumns.SCREEN_NAME.ToString()];
                screen.ImageCD.Value = table.Rows[0][ScreenDTO.eColumns.IMAGE_CD.ToString()];

                object obj = table.Rows[0][ScreenDTO.eColumns.SCREEN_TYPE.ToString()];
                screen.ScreenType = (eScreenType)Enum.Parse(typeof(eScreenType), obj.ToString());

                obj = table.Rows[0][ScreenDTO.eColumns.SCREEN_ACTION.ToString()];
                screen.ShowAction = (eShowAction)Enum.Parse(typeof(eShowAction), obj.ToString());

                screen.ExternalProgram.Value = table.Rows[0][ScreenDTO.eColumns.EXT_PROGRAM.ToString()];
                screen.ScreenDescription.Value = table.Rows[0]["SCREEN_DESC"];

                return screen;                
            }

            return null;
        }

        /// <summary>
        /// Select all screen on database which is the main screen for set authorize
        /// </summary>
        /// <param name="database"></param>
        /// <param name="userLangCD"></param>
        /// <param name="defLangCD"></param>
        /// <returns></returns>
        public DatabaseScreenList SelectScreenWithAuthorize(Database database, NZString userLangCD, NZString defLangCD)
        {
            Database db = this.UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT ");
            sb.AppendLine("   SCREEN_CD ");
            sb.AppendLine("   ,SCREEN_NAME ");
            sb.AppendLine("   ,IMAGE_CD ");
            sb.AppendLine("   ,SCREEN_TYPE ");
            sb.AppendLine("   ,SCREEN_ACTION ");
            sb.AppendLine("   ,EXT_PROGRAM ");
            sb.AppendLine("   ,CRT_BY ");
            sb.AppendLine("   ,CRT_DATE ");
            sb.AppendLine("   ,CRT_MACHINE ");
            sb.AppendLine("   ,UPD_BY ");
            sb.AppendLine("   ,UPD_DATE ");
            sb.AppendLine("   ,UPD_MACHINE ");
            sb.AppendLine(String.Format("   ,{0}FNZ_GET_SCREEN_DESC(T.SCREEN_CD,:LANG_CD, :DEF_LANG_CD) AS SCREEN_DESC",
                (db.Credential.Provider == DatabaseProvider.SQLSERVER) ? "dbo." : string.Empty));
            sb.AppendLine("   ,ORIGINAL_TITLE ");
            sb.AppendLine(" FROM TZ_SCREEN_MS T");
            sb.AppendLine(" WHERE T.IS_AUTHORIZE = '1' ");
            sb.AppendLine(" ORDER BY T.SCREEN_CD");

            DataRequest request = new DataRequest(sb.ToString());
            request.Parameters.Add("LANG_CD", DataType.NVarChar, userLangCD.Value);
            request.Parameters.Add("DEF_LANG_CD", DataType.NVarChar, defLangCD.Value);

            DataTable table = db.ExecuteQuery(request);

            DatabaseScreenList listDatabaseScreen = new DatabaseScreenList();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DatabaseScreen screen = new DatabaseScreen();
                screen.ScreenCD.Value = table.Rows[i][ScreenDTO.eColumns.SCREEN_CD.ToString()];
                screen.ScreenName.Value = table.Rows[i][ScreenDTO.eColumns.SCREEN_NAME.ToString()];
                screen.ImageCD.Value = table.Rows[i][ScreenDTO.eColumns.IMAGE_CD.ToString()];
                object obj = table.Rows[i][ScreenDTO.eColumns.SCREEN_TYPE.ToString()];
                screen.ScreenType = (eScreenType)Enum.Parse(typeof(eScreenType), obj.ToString());
                obj = table.Rows[i][ScreenDTO.eColumns.SCREEN_ACTION.ToString()];
                screen.ShowAction = (eShowAction)Enum.Parse(typeof(eShowAction), obj.ToString());
                screen.ExternalProgram.Value = table.Rows[i][ScreenDTO.eColumns.EXT_PROGRAM.ToString()];
                screen.ScreenDescription.Value = table.Rows[i][ScreenLangDTO.eColumns.SCREEN_DESC.ToString()];


                listDatabaseScreen.Add(screen);
            }

            return listDatabaseScreen;
        }           
        #endregion

        public int DeleteByScreenCD(Database database, string ScreenCD)
        {
            string sql = @"DELETE FROM TZ_SCREEN_MS WHERE SCREEN_CD = :SCREEN_CD ";

            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("SCREEN_CD", DataType.VarChar, ScreenCD);

            return  database.ExecuteNonQuery(req);
        }

        public int UpdateScreenImage(Database database, ScreenDTO dto)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" UPDATE TZ_SCREEN_MS ");
            sb.AppendLine("    SET IMAGE_CD = :IMAGE_CD,  ");
            sb.AppendLine("        UPD_BY = :UPD_BY,  ");
            sb.AppendLine("        UPD_DATE = :UPD_DATE, ");
            sb.AppendLine("        UPD_MACHINE = :UPD_MACHINE ");
            sb.AppendLine("  WHERE SCREEN_CD = :SCREEN_CD ");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("SCREEN_CD", DataType.NVarChar, dto.SCREEN_CD.Value);
            req.Parameters.Add("IMAGE_CD", DataType.NVarChar, dto.IMAGE_CD.Value);
            req.Parameters.Add("UPD_BY", DataType.NVarChar, dto.UPD_BY.Value);
            req.Parameters.Add("UPD_DATE", DataType.DateTime, dto.UPD_DATE.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, dto.UPD_MACHINE.Value);

            return db.ExecuteNonQuery(req);
        }

        public void ResetUsageFlag()
        {
            Database db = m_db;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" UPDATE TZ_SCREEN_MS ");
            sb.AppendLine("    SET IS_USED = 0  ");

            DataRequest req = new DataRequest(sb.ToString());

            db.ExecuteNonQuery(req);
        }

        public void UpdateIsUsed(Database database, ScreenDTO argScreenDTO)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" UPDATE TZ_SCREEN_MS ");
            sb.AppendLine("     SET IS_USED = 1 ");
            sb.AppendLine("     WHERE SCREEN_CD = :pSCREEN_CD");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("@pSCREEN_CD", argScreenDTO.SCREEN_CD.Value);

            db.ExecuteNonQuery(req);
        }
    }
}
