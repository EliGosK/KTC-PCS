using System;
using System.Text;
using EVOFramework.Database;
using SystemMaintenance.DTO;
using System.Collections.Generic;
using EVOFramework;
using System.Data;

namespace SystemMaintenance.DAO
{
    public partial interface IUserDAO
    {
        int ChangePassword(Database database, NZString UserCD, NZString newPassword, NZString UpdateByUser, NZString updateUserMachine);

        int UpdateUserDefaultValue(Database database, NZString UserCD, NZString username, NZInt dateFormat, NZInt langCD, NZString updateUserCD, NZString updateUserMachine);

        bool IsResetPassword(Database database, string UserCD);

        int DeleteUser(Database database, string UserCD);

        bool Exist_Username(Database database, string UserCD);

        List<UserDTO> LoadAllByGroupCD(Database database, bool ascending, string GroupCD, params UserDTO.eColumns[] orderByColumns);

        int RemoveUserFromGroup(Database database, UserDTO userDTO);

        int AddUserToGroup(Database database, UserDTO userDTO);

        List<UserDTO> LoadAllUserNotInGroup(Database database, bool ascending, string GroupCD, params UserDTO.eColumns[] orderByColumns);

        int UpdateWithoutPK(Database database, UserDTO data, bool isPasswordChange);

        DataTable LoadPermissionTable(string strUsername);

        void RegisterMachine(Database database, string UserCD);
    }
}
