using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Database;
using SystemMaintenance.DTO;

namespace SystemMaintenance.Oracle.DAO
{
    internal partial class ScreenLangDAO
    {
        public int DeleteByScreenCD(Database database, string ScreenCD)
        {
            string sql = @"DELETE FROM TZ_SCREEN_LANG_MS WHERE SCREEN_CD = :SCREEN_CD ";

            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("SCREEN_CD", DataType.VarChar, ScreenCD);

            return database.ExecuteNonQuery(req);
        }
        //public int UpdateScreenDisplayText(string ScreenCD, string LangCD, string DisplayTitle)
        //{

        //}

        public void ResetUsageFlag()
        {
            Database db = m_db;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" UPDATE TZ_SCREEN_LANG_MS ");
            sb.AppendLine("    SET IS_USED = 0  ");

            DataRequest req = new DataRequest(sb.ToString());

            db.ExecuteNonQuery(req);
        }

        public void UpdateIsUsed(Database database, ScreenLangDTO argScreenLangDTO)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" UPDATE TZ_SCREEN_LANG_MS ");
            sb.AppendLine("     SET IS_USED = 1  ");
            sb.AppendLine("     WHERE SCREEN_CD = :pSCREEN_CD");
            sb.AppendLine("     AND LANG_CD = :pLANG_CD");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("@pSCREEN_CD", argScreenLangDTO.SCREEN_CD.Value);
            req.Parameters.Add("@pLANG_CD", argScreenLangDTO.LANG_CD.Value);


            db.ExecuteNonQuery(req);
        }
    }
}
