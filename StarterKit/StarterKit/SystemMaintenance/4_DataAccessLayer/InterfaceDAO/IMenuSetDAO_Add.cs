using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Database;
using SystemMaintenance.DTO;

namespace SystemMaintenance.DAO
{
   partial interface IMenuSetDAO
   {
       int UpdateMenuSetDesc(Database database, MenuSetDTO data);
    }
}
