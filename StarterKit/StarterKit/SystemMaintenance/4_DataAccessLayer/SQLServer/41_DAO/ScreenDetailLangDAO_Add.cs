using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Database;
using SystemMaintenance.DTO;
using System.Data;

namespace SystemMaintenance.SQLServer.DAO
{
    partial class ScreenDetailLangDAO
    {
        public void AddNew()
        {
        }

        public void Delete()
        {
        }

        public void UpdateWithPK()
        {
        }

        public void UpdateWithoutPK()
        {
        }

        public void LoadAll()
        {
        }
        public int DeleteByScreenCD(Database database, string ScreenCD)
        {
            string sql = @"DELETE FROM TZ_SCREEN_DETAIL_LANG_MS WHERE SCREEN_CD = :SCREEN_CD ";

            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("SCREEN_CD", DataType.VarChar, ScreenCD);

            return database.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Load with specified ScreenCode and LangCode.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="SCREEN_CD">Key #1</param>
        /// <param name="LANG_CD">Key #2</param>        
        /// <returns></returns>
        public List<ScreenDetailLangDTO> LoadScreenDetailByLangCD(Database database, string SCREEN_CD, string LANG_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" SELECT ");
            sb.AppendLine("   CONTROL_CD");
            sb.AppendLine("   ,LANG_CD");
            sb.AppendLine("   ,SCREEN_CD");
            sb.AppendLine("   ,CONTROL_CAPTION");

            sb.AppendLine(" FROM TZ_SCREEN_DETAIL_LANG_MS ");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("       SCREEN_CD=:SCREEN_CD");
            sb.AppendLine("   AND LANG_CD=:LANG_CD");

            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("LANG_CD", DataType.VarChar, LANG_CD);
            req.Parameters.Add("SCREEN_CD", DataType.VarChar, SCREEN_CD);
            #endregion

            return db.ExecuteForList<ScreenDetailLangDTO>(req);
        }

        public DataTable LoadScreenDetailWithOriginalCaptionByLangCD(Database database, string SCREEN_CD, string LANG_CD)
        {
            Database db = UseDatabase(database);

            //StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string sql = @"SELECT  T.CONTROL_CD,
                                   T.LANG_CD,
                                   T.SCREEN_CD,
                                   T.CONTROL_CAPTION,
                                   TT.ORIGINAL_TITLE
                              FROM TZ_SCREEN_DETAIL_LANG_MS T
                             INNER JOIN TZ_SCREEN_DETAIL_MS TT ON T.SCREEN_CD = TT.SCREEN_CD
                                                              AND T.CONTROL_CD = TT.CONTROL_CD
                             WHERE T.SCREEN_CD = :SCREEN_CD
                               AND T.LANG_CD = :LANG_CD";
            #endregion

            DataRequest req = new DataRequest(sql);
            #region Parameters
            req.Parameters.Add("LANG_CD", DataType.VarChar, LANG_CD);
            req.Parameters.Add("SCREEN_CD", DataType.VarChar, SCREEN_CD);
            #endregion

            return db.ExecuteQuery(req);
        }

        public void ResetUsageFlag()
        {
            Database db = m_db;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" UPDATE TZ_SCREEN_DETAIL_LANG_MS ");
            sb.AppendLine("    SET IS_USED = 0  ");

            DataRequest req = new DataRequest(sb.ToString());

            db.ExecuteNonQuery(req);
        }

        public void UpdateIsUsed(Database database, ScreenDetailLangDTO argScreenDetailLangDTO)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" UPDATE TZ_SCREEN_DETAIL_LANG_MS ");
            sb.AppendLine("     SET IS_USED = 1  ");
            sb.AppendLine("     WHERE CONTROL_CD = :pCONTROL_CD");
            sb.AppendLine("     AND LANG_CD = :pLANG_CD");
            sb.AppendLine("     AND SCREEN_CD = :pSCREEN_CD");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("@pCONTROL_CD", argScreenDetailLangDTO.CONTROL_CD.Value);
            req.Parameters.Add("@pLANG_CD", argScreenDetailLangDTO.LANG_CD.Value);
            req.Parameters.Add("@pSCREEN_CD", argScreenDetailLangDTO.SCREEN_CD.Value);

            db.ExecuteNonQuery(req);
        }
    }
}
