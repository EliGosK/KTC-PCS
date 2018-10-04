using System.Data;
using EVOFramework.Database;
using SystemMaintenance.DTO;

namespace SystemMaintenance.DAO
{
    public partial interface IUserScreenPermissionDAO
    {
        DataTable LoadUserPermissionJoinScreen(Database database, string I_SCREEN_CD);


        int UpdateUserScreenPermissionFlagVIEW(Database database, UserScreenPermissionDTO dto);

        int UpdateUserScreenPermissionFlagADD(Database database, UserScreenPermissionDTO dto);

        int UpdateUserScreenPermissionFlagCHG(Database database, UserScreenPermissionDTO dto);

        int UpdateUserScreenPermissionFlagDEL(Database database, UserScreenPermissionDTO dto);

    }
}


