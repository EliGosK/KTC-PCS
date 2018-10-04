using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Database;
using SystemMaintenance.DTO;

namespace SystemMaintenance.SQLServer.DAO
{
    internal partial class UserGroupDAO
    {
        public int UpdateGroupDesc(Database database,UserGroupDTO dto)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" UPDATE TZ_USER_GROUP_MS ");
            sb.AppendLine("    SET GROUP_NAME  = :GROUP_NAME, ");
            sb.AppendLine("        UPD_BY      = :UPD_BY, ");
            sb.AppendLine("        UPD_DATE    = :UPD_DATE, ");
            sb.AppendLine("        UPD_MACHINE = :UPD_MACHINE ");
            sb.AppendLine("  WHERE GROUP_CD = :GROUP_CD ");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("GROUP_NAME", DataType.VarChar, dto.GROUP_NAME.StrongValue);
            req.Parameters.Add("UPD_BY", DataType.VarChar, dto.UPD_BY.StrongValue);
            req.Parameters.Add("UPD_DATE", DataType.DateTime, dto.UPD_DATE.StrongValue);
            req.Parameters.Add("UPD_MACHINE", DataType.VarChar, dto.UPD_MACHINE.StrongValue);
            req.Parameters.Add("GROUP_CD", DataType.VarChar, dto.GROUP_CD.StrongValue);
            return db.ExecuteNonQuery(req);

        }
    }
}
