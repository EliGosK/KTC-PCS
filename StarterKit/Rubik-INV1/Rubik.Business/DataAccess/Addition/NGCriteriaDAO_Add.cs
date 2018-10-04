using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EVOFramework.Database;
using EVOFramework;
using Rubik.DTO;

namespace Rubik.DAO 
{
    partial class NGCriteriaDAO 
    {
        public List<ProductionReportEntryViewDTO> LoadNGCriteriaByProcess(Database database, NZString Process, bool includeOldData) 
        {
            Database db = UseDatabase(database);

            DataRequest req = new DataRequest("S_TRN210_LoadNGCriteriaByProcess");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_Process", DataType.NVarChar, Process.Value);
            if (!includeOldData)
                req.Parameters.Add("@pInt_OldData", DataType.NVarChar, 0);  //0:New Data

            return db.ExecuteForList<ProductionReportEntryViewDTO>(req);
        }
    }
}
