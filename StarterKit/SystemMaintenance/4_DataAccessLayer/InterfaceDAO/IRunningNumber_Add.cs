using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemMaintenance.DTO;
using EVOFramework.Database;

namespace SystemMaintenance.DAO
{
    public partial interface IRunningNumber
    {
        int SetNextRunningNoValue(Database database, RunningNumberDTO data);
    }
}
