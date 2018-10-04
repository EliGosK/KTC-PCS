using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Database;
using SystemMaintenance.DTO;

namespace SystemMaintenance.Oracle.DAO
{
   partial class MenuSetDAO
   {
       public int UpdateMenuSetDesc(Database database, MenuSetDTO data)
       {
           Database db = UseDatabase(database);

           StringBuilder sb = new StringBuilder();
           #region SQL Statement
           sb.AppendLine(" UPDATE TZ_MENU_SET_MS");
           sb.AppendLine(" SET ");
           sb.AppendLine("    MENU_SET_NAME=:MENU_SET_NAME");
    
           sb.AppendLine("    ,UPD_BY=:UPD_BY");
           sb.AppendLine("    ,UPD_DATE=:UPD_DATE");
           sb.AppendLine("    ,UPD_MACHINE=:UPD_MACHINE");
           sb.AppendLine(" WHERE ");
           sb.AppendLine("    MENU_SET_CD=:MENU_SET_CD");
           #endregion

           DataRequest req = new DataRequest(sb.ToString());
           #region Parameters
           req.Parameters.Add("MENU_SET_CD", DataType.VarChar, data.MENU_SET_CD.Value);
           req.Parameters.Add("MENU_SET_NAME", DataType.VarChar, data.MENU_SET_NAME.Value);
     
           req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
           req.Parameters.Add("UPD_DATE", DataType.DateTime, data.UPD_DATE.Value);
           req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
           #endregion

           return db.ExecuteNonQuery(req);
       }
    }
}
