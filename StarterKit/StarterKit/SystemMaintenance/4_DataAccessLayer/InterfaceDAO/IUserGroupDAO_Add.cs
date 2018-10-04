using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Database;
using SystemMaintenance.DTO;

namespace SystemMaintenance.DAO
{
    public partial interface IUserGroupDAO
    {
        int UpdateGroupDesc(Database database, UserGroupDTO dto);
    }
}
