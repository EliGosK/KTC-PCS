using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Database;
using System.Data;
using EVOFramework;
using Rubik.DAO;
using Rubik.DTO;

namespace Rubik.BIZ {
    public class NGCriteriaBIZ 
    {
        public List<ProductionReportEntryViewDTO> LoadNGCriteriaByProcess(Database database, NZString Process, bool IncludeOldData) 
        {
            NGCriteriaDAO dao = new NGCriteriaDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadNGCriteriaByProcess(null, Process, IncludeOldData);
        }
    }
}
