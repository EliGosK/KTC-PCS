using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Database;
using SystemMaintenance.DTO;

namespace SystemMaintenance.SQLServer.DAO
{
    partial class ScreenDetailDAO
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
            string sql = @"DELETE FROM TZ_SCREEN_DETAIL_MS WHERE SCREEN_CD = :SCREEN_CD ";

            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("SCREEN_CD", DataType.VarChar, ScreenCD);

            return database.ExecuteNonQuery(req);
        }

        public void ResetUsageFlag()
        {
            Database db = m_db;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" UPDATE TZ_SCREEN_DETAIL_MS ");
            sb.AppendLine("    SET IS_USED = 0  ");

            DataRequest req = new DataRequest(sb.ToString());

            db.ExecuteNonQuery(req);
        }

        public void UpdateIsUsed(Database database, ScreenDetailDTO argScreenDetailDTO)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" UPDATE TZ_SCREEN_DETAIL_MS ");
            sb.AppendLine("     SET IS_USED = 1  ");
            sb.AppendLine("     WHERE SCREEN_CD = :pSCREEN_CD");
            sb.AppendLine("     AND CONTROL_CD = :pCONTROL_CD");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("@pSCREEN_CD", argScreenDetailDTO.SCREEN_CD.Value);
            req.Parameters.Add("@pCONTROL_CD", argScreenDetailDTO.CONTROL_CD.Value);

            db.ExecuteNonQuery(req);
        }
    }
}
