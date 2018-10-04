using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using EVOFramework.Database;
using Rubik.DTO;
using Rubik.Data;
using System.Data;

namespace Rubik.DAO
{
    internal partial class WorkingCalendarDAO
    {
        public WorkingCalendarDTO LoadByLastUpdate(Database database)
        {
            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_MAS100_LoadLastGeneratedCalendar";
            req.CommandType = CommandType.StoredProcedure;

            List<WorkingCalendarDTO> list = db.ExecuteForList<WorkingCalendarDTO>(req);
            if (list != null && list.Count > 0)
                return list[0];
            else
                return null;
        }
        public WorkingCalendarDTO LoadByFirstUpdate(Database database)
        {
            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_MAS101_LoadFirstGeneratedCalendar";
            req.CommandType = CommandType.StoredProcedure;

            List<WorkingCalendarDTO> list = db.ExecuteForList<WorkingCalendarDTO>(req);
            if (list != null && list.Count > 0)
                return list[0];
            else
                return null;
        }
    }
}
