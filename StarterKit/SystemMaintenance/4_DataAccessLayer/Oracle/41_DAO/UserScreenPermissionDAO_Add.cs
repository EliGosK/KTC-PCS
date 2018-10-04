using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SystemMaintenance.DTO;
using EVOFramework.Database;

namespace SystemMaintenance.Oracle.DAO
{
    partial class UserScreenPermissionDAO
    {
        public DataTable LoadUserPermissionJoinScreen(Database database, string I_SCREEN_CD)
        {
            Database db = UseDatabase(database);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT");
            sb.AppendLine("   :I_SCREEN_CD SCREEN_CD,");
            sb.AppendLine("   USR.USER_ACCOUNT USER_CD,");
            sb.AppendLine("   NVL(USR_SCR_PERM.FLG_VIEW, 2) FLG_VIEW,");
            sb.AppendLine("   NVL(USR_SCR_PERM.FLG_ADD, 2) FLG_ADD,");
            sb.AppendLine("   NVL(USR_SCR_PERM.FLG_CHG, 2) FLG_CHG,");
            sb.AppendLine("   NVL(USR_SCR_PERM.FLG_DEL, 2) FLG_DEL,");
            sb.AppendLine("   USR.FULL_NAME USER_ACCOUNT");
     
            sb.AppendLine(" FROM ");
            sb.AppendLine("   TZ_USER_MS USR");
            sb.AppendLine("   LEFT JOIN TZ_USER_SCREEN_PERMISSION_MS USR_SCR_PERM");
            sb.AppendLine("     ON USR.USER_ACCOUNT = USR_SCR_PERM.USER_CD");
            sb.AppendLine("    AND USR_SCR_PERM.SCREEN_CD = :I_SCREEN_CD");
            sb.AppendLine(" ORDER BY");
            sb.AppendLine("   USR.USER_ACCOUNT");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("I_SCREEN_CD", DataType.VarChar, I_SCREEN_CD);

            return db.ExecuteQuery(req);
        }

        public int UpdateUserScreenPermissionFlagVIEW(Database database, UserScreenPermissionDTO dto)
        {
            Database db = UseDatabase(database);
            string sql = @"UPDATE  TZ_USER_SCREEN_PERMISSION_MS
                               SET FLG_VIEW    = :FLG_VIEW,
                                   UPD_BY      = :UPD_BY,
                                   UPD_DATE    = :UPD_DATE,
                                   UPD_MACHINE = :UPD_MACHINE
                             WHERE SCREEN_CD = :SCREEN_CD
                               AND USER_CD = :USER_CD";

            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("SCREEN_CD", DataType.VarChar, dto.SCREEN_CD.StrongValue);
            req.Parameters.Add("USER_CD", DataType.VarChar, dto.USER_CD.StrongValue);
            req.Parameters.Add("FLG_VIEW", DataType.VarChar, dto.FLG_VIEW.StrongValue);
            req.Parameters.Add("UPD_BY", DataType.VarChar, dto.UPD_BY.StrongValue);
            req.Parameters.Add("UPD_DATE", DataType.DateTime, dto.UPD_DATE.StrongValue);
            req.Parameters.Add("UPD_MACHINE", DataType.VarChar, dto.UPD_MACHINE.StrongValue);
            return db.ExecuteNonQuery(req);
        }

        public int UpdateUserScreenPermissionFlagADD(Database database, UserScreenPermissionDTO dto)
        {
            Database db = UseDatabase(database);
            string sql = @"UPDATE  TZ_USER_SCREEN_PERMISSION_MS
                               SET FLG_ADD    = :FLG_ADD,
                                   UPD_BY      = :UPD_BY,
                                   UPD_DATE    = :UPD_DATE,
                                   UPD_MACHINE = :UPD_MACHINE
                             WHERE SCREEN_CD = :SCREEN_CD
                               AND USER_CD = :USER_CD";

            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("SCREEN_CD", DataType.VarChar, dto.SCREEN_CD.StrongValue);
            req.Parameters.Add("USER_CD", DataType.VarChar, dto.USER_CD.StrongValue);
            req.Parameters.Add("FLG_ADD", DataType.VarChar, dto.FLG_ADD.StrongValue);
            req.Parameters.Add("UPD_BY", DataType.VarChar, dto.UPD_BY.StrongValue);
            req.Parameters.Add("UPD_DATE", DataType.DateTime, dto.UPD_DATE.StrongValue);
            req.Parameters.Add("UPD_MACHINE", DataType.VarChar, dto.UPD_MACHINE.StrongValue);
            return db.ExecuteNonQuery(req);
        }

        public int UpdateUserScreenPermissionFlagCHG(Database database, UserScreenPermissionDTO dto)
        {
            Database db = UseDatabase(database);
            string sql = @"UPDATE  TZ_USER_SCREEN_PERMISSION_MS
                               SET FLG_CHG    = :FLG_CHG,
                                   UPD_BY      = :UPD_BY,
                                   UPD_DATE    = :UPD_DATE,
                                   UPD_MACHINE = :UPD_MACHINE
                             WHERE SCREEN_CD = :SCREEN_CD
                               AND USER_CD = :USER_CD";

            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("SCREEN_CD", DataType.VarChar, dto.SCREEN_CD.StrongValue);
            req.Parameters.Add("USER_CD", DataType.VarChar, dto.USER_CD.StrongValue);
            req.Parameters.Add("FLG_CHG", DataType.VarChar, dto.FLG_CHG.StrongValue);
            req.Parameters.Add("UPD_BY", DataType.VarChar, dto.UPD_BY.StrongValue);
            req.Parameters.Add("UPD_DATE", DataType.DateTime, dto.UPD_DATE.StrongValue);
            req.Parameters.Add("UPD_MACHINE", DataType.VarChar, dto.UPD_MACHINE.StrongValue);
            return db.ExecuteNonQuery(req);
        }

        public int UpdateUserScreenPermissionFlagDEL(Database database, UserScreenPermissionDTO dto)
        {
            Database db = UseDatabase(database);
            string sql = @"UPDATE  TZ_USER_SCREEN_PERMISSION_MS
                               SET FLG_DEL    = :FLG_DEL,
                                   UPD_BY      = :UPD_BY,
                                   UPD_DATE    = :UPD_DATE,
                                   UPD_MACHINE = :UPD_MACHINE
                             WHERE SCREEN_CD = :SCREEN_CD
                               AND USER_CD = :USER_CD";

            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("SCREEN_CD", DataType.VarChar, dto.SCREEN_CD.StrongValue);
            req.Parameters.Add("USER_CD", DataType.VarChar, dto.USER_CD.StrongValue);
            req.Parameters.Add("FLG_DEL", DataType.VarChar, dto.FLG_DEL.StrongValue);
            req.Parameters.Add("UPD_BY", DataType.VarChar, dto.UPD_BY.StrongValue);
            req.Parameters.Add("UPD_DATE", DataType.DateTime, dto.UPD_DATE.StrongValue);
            req.Parameters.Add("UPD_MACHINE", DataType.VarChar, dto.UPD_MACHINE.StrongValue);
            return db.ExecuteNonQuery(req);
        }
    }
}
