using System.Data;
using EVOFramework.Database;
using SystemMaintenance.DTO;

namespace SystemMaintenance.DAO
{
    public partial interface IGroupScreenPermissionDAO
    {
        DataTable LoadGroupPermissionJoinScreen(Database database, string I_SCREEN_CD);



        int UpdateGroupScreenPermissionFlagVIEW(Database database, GroupScreenPermissionDTO dto);
        int UpdateGroupScreenPermissionFlagADD(Database database, GroupScreenPermissionDTO dto);
        int UpdateGroupScreenPermissionFlagCHG(Database database, GroupScreenPermissionDTO dto);
        int UpdateGroupScreenPermissionFlagDEL(Database database, GroupScreenPermissionDTO dto);
    }
}
