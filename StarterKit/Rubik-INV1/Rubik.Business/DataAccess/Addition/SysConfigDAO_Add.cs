using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Database;
using Rubik.DTO;

namespace Rubik.DAO
{
    public partial class SysConfigDAO
    {
        public DateTime GetDefaultDateForScreen(Database database, SysConfigDTO data)
        {
            Database db = UseDatabase(database);


            DataRequest req = new DataRequest();
            req.CommandText = "S_GetDefaultDateForScreen";
            req.CommandType = System.Data.CommandType.StoredProcedure;

            #region Parameters
            req.Parameters.Add("@pSYS_GROUP_ID", DataType.VarChar, data.SYS_GROUP_ID.Value);
            req.Parameters.Add("@pSYS_KEY", DataType.VarChar, data.SYS_KEY.Value);
            #endregion

            return (DateTime)db.ExecuteScalar(req);
        }

        public DateTime GetDefaultDateForScreen_No_Fix(Database database, SysConfigDTO data)
        {
            Database db = UseDatabase(database);


            DataRequest req = new DataRequest();
            req.CommandText = "S_GetDefaultDateForScreen_No_Fix";
            req.CommandType = System.Data.CommandType.StoredProcedure;

            #region Parameters
            req.Parameters.Add("@pSYS_GROUP_ID", DataType.VarChar, data.SYS_GROUP_ID.Value);
            req.Parameters.Add("@pSYS_KEY", DataType.VarChar, data.SYS_KEY.Value);
            #endregion

            return (DateTime)db.ExecuteScalar(req);
        }
    }
}
