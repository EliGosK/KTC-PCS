using System.Text;
using System.Data;
using EVOFramework.Database;
using SystemMaintenance.DTO;

namespace SystemMaintenance.Oracle.DAO
{
    internal partial class GroupScreenPermissionDAO
    {
        public DataTable LoadGroupPermissionJoinScreen(Database database, string I_SCREEN_CD)
        {
            Database db = UseDatabase(database);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT");
            sb.AppendLine("   GRP_SCR_PERM.SCREEN_CD,");
            sb.AppendLine("   GRP.GROUP_CD,");
            sb.AppendLine("   NVL(GRP_SCR_PERM.FLG_VIEW, 0) FLG_VIEW,");
            sb.AppendLine("   NVL(GRP_SCR_PERM.FLG_ADD, 0) FLG_ADD,");
            sb.AppendLine("   NVL(GRP_SCR_PERM.FLG_CHG, 0) FLG_CHG,");
            sb.AppendLine("   NVL(GRP_SCR_PERM.FLG_DEL, 0) FLG_DEL,");
            sb.AppendLine("   GRP.GROUP_NAME");
            //sb.AppendLine("   GRP_SCR_PERM.CRT_USER,");
            //sb.AppendLine("   GRP_SCR_PERM.CRT_DATE,");
            //sb.AppendLine("   GRP_SCR_PERM.UPD_USER,");
            //sb.AppendLine("   GRP_SCR_PERM.UPD_DATE");
            sb.AppendLine(" FROM ");
            sb.AppendLine("   TZ_USER_GROUP_MS GRP");
            sb.AppendLine("   LEFT JOIN TZ_GROUP_SCREEN_PERMISSION_MS GRP_SCR_PERM");
            sb.AppendLine("     ON GRP.GROUP_CD = GRP_SCR_PERM.GROUP_CD");
            sb.AppendLine("    AND GRP_SCR_PERM.SCREEN_CD = :I_SCREEN_CD");
            sb.AppendLine(" ORDER BY");
            sb.AppendLine("   GRP.GROUP_CD  ");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("I_SCREEN_CD", DataType.VarChar, I_SCREEN_CD);

            return db.ExecuteQuery(req);
        }

        public int UpdateGroupScreenPermissionFlagVIEW(Database database, GroupScreenPermissionDTO dto)
        {
            Database db = UseDatabase(database);
            string sql = @"UPDATE  TZ_GROUP_SCREEN_PERMISSION_MS
                               SET FLG_VIEW    = :FLG_VIEW,
                                   UPD_BY      = :UPD_BY,
                                   UPD_DATE    = :UPD_DATE,
                                   UPD_MACHINE = :UPD_MACHINE
                             WHERE SCREEN_CD = :SCREEN_CD
                               AND GROUP_CD = :GROUP_CD";

            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("SCREEN_CD", DataType.VarChar, dto.SCREEN_CD.StrongValue);
            req.Parameters.Add("GROUP_CD", DataType.VarChar, dto.GROUP_CD.StrongValue);
            req.Parameters.Add("FLG_VIEW", DataType.VarChar, dto.FLG_VIEW.StrongValue);
            req.Parameters.Add("UPD_BY", DataType.VarChar, dto.UPD_BY.StrongValue);
            req.Parameters.Add("UPD_DATE", DataType.DateTime, dto.UPD_DATE.StrongValue);
            req.Parameters.Add("UPD_MACHINE", DataType.VarChar, dto.UPD_MACHINE.StrongValue);
            return db.ExecuteNonQuery(req);
        }

        public int UpdateGroupScreenPermissionFlagADD(Database database, GroupScreenPermissionDTO dto)
        {
            Database db = UseDatabase(database);
            string sql = @"UPDATE  TZ_GROUP_SCREEN_PERMISSION_MS
                               SET FLG_ADD    = :FLG_ADD,
                                   UPD_BY      = :UPD_BY,
                                   UPD_DATE    = :UPD_DATE,
                                   UPD_MACHINE = :UPD_MACHINE
                             WHERE SCREEN_CD = :SCREEN_CD
                               AND GROUP_CD = :GROUP_CD";

            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("SCREEN_CD", DataType.VarChar, dto.SCREEN_CD.StrongValue);
            req.Parameters.Add("GROUP_CD", DataType.VarChar, dto.GROUP_CD.StrongValue);
            req.Parameters.Add("FLG_ADD", DataType.VarChar, dto.FLG_ADD.StrongValue);
            req.Parameters.Add("UPD_BY", DataType.VarChar, dto.UPD_BY.StrongValue);
            req.Parameters.Add("UPD_DATE", DataType.DateTime, dto.UPD_DATE.StrongValue);
            req.Parameters.Add("UPD_MACHINE", DataType.VarChar, dto.UPD_MACHINE.StrongValue);
            return db.ExecuteNonQuery(req);
        }

        public int UpdateGroupScreenPermissionFlagCHG(Database database, GroupScreenPermissionDTO dto)
        {
            Database db = UseDatabase(database);
            string sql = @"UPDATE  TZ_GROUP_SCREEN_PERMISSION_MS
                               SET FLG_CHG    = :FLG_CHG,
                                   UPD_BY      = :UPD_BY,
                                   UPD_DATE    = :UPD_DATE,
                                   UPD_MACHINE = :UPD_MACHINE
                             WHERE SCREEN_CD = :SCREEN_CD
                               AND GROUP_CD = :GROUP_CD";

            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("SCREEN_CD", DataType.VarChar, dto.SCREEN_CD.StrongValue);
            req.Parameters.Add("GROUP_CD", DataType.VarChar, dto.GROUP_CD.StrongValue);
            req.Parameters.Add("FLG_CHG", DataType.VarChar, dto.FLG_CHG.StrongValue);
            req.Parameters.Add("UPD_BY", DataType.VarChar, dto.UPD_BY.StrongValue);
            req.Parameters.Add("UPD_DATE", DataType.DateTime, dto.UPD_DATE.StrongValue);
            req.Parameters.Add("UPD_MACHINE", DataType.VarChar, dto.UPD_MACHINE.StrongValue);
            return db.ExecuteNonQuery(req);
        }

        public int UpdateGroupScreenPermissionFlagDEL(Database database, GroupScreenPermissionDTO dto)
        {
            Database db = UseDatabase(database);
            string sql = @"UPDATE  TZ_GROUP_SCREEN_PERMISSION_MS
                               SET FLG_DEL    = :FLG_DEL,
                                   UPD_BY      = :UPD_BY,
                                   UPD_DATE    = :UPD_DATE,
                                   UPD_MACHINE = :UPD_MACHINE
                             WHERE SCREEN_CD = :SCREEN_CD
                               AND GROUP_CD = :GROUP_CD";

            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("SCREEN_CD", DataType.VarChar, dto.SCREEN_CD.StrongValue);
            req.Parameters.Add("GROUP_CD", DataType.VarChar, dto.GROUP_CD.StrongValue);
            req.Parameters.Add("FLG_DEL", DataType.VarChar, dto.FLG_DEL.StrongValue);
            req.Parameters.Add("UPD_BY", DataType.VarChar, dto.UPD_BY.StrongValue);
            req.Parameters.Add("UPD_DATE", DataType.DateTime, dto.UPD_DATE.StrongValue);
            req.Parameters.Add("UPD_MACHINE", DataType.VarChar, dto.UPD_MACHINE.StrongValue);
            return db.ExecuteNonQuery(req);
        }
    }
}
