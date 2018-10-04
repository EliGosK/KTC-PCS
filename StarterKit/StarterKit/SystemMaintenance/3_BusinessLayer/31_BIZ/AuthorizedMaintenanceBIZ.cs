using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using SystemMaintenance.DTO;
using SystemMaintenance.DAO;

namespace SystemMaintenance.BIZ
{
    class AuthorizedMaintenanceBIZ
    {
        internal System.Data.DataTable LoadUserPermissionJoinScreen(string ScreenCD)
        {
            IUserScreenPermissionDAO dao = DAOFactory.CreateUserScreenPermissionDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadUserPermissionJoinScreen(null, ScreenCD);
        }

        internal System.Data.DataTable LoadGroupPermissionJoinScreen(string ScreenCD)
        {
            IGroupScreenPermissionDAO dao = DAOFactory.CreateGroupScreenPermissionDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadGroupPermissionJoinScreen(null, ScreenCD);
        }

        internal bool isExistGroupScreenPermission(NZString ScreenCD, NZString GroupCD)
        {
            IGroupScreenPermissionDAO dao = DAOFactory.CreateGroupScreenPermissionDAO(CommonLib.Common.CurrentDatabase);
            return dao.Exist(null, ScreenCD, GroupCD);
        }

        internal void AddGroupScreenPermissionFlag(GroupScreenPermissionDTO dto)
        {
            IGroupScreenPermissionDAO dao = DAOFactory.CreateGroupScreenPermissionDAO(CommonLib.Common.CurrentDatabase);
            dao.AddNew(null, dto);
        }

        internal void UpdateGroupScreenPermissionFlag(GroupScreenPermissionDTO dto)
        {
            IGroupScreenPermissionDAO dao = DAOFactory.CreateGroupScreenPermissionDAO(CommonLib.Common.CurrentDatabase);
            dao.UpdateWithoutPK(null, dto);
        }

        internal bool isExistUserScreenPermission(NZString screenCD, NZString userCD)
        {
            IUserScreenPermissionDAO dao = DAOFactory.CreateUserScreenPermissionDAO(CommonLib.Common.CurrentDatabase);
            return dao.Exist(null, screenCD, userCD);
        }

        internal void UpdateUserScreenPermissionFlag(UserScreenPermissionDTO dto)
        {
            IUserScreenPermissionDAO dao = DAOFactory.CreateUserScreenPermissionDAO(CommonLib.Common.CurrentDatabase);
            dao.UpdateWithoutPK(null, dto);
        }

        internal void AddUserScreenPermissionFlag(UserScreenPermissionDTO dto)
        {
            IUserScreenPermissionDAO dao = DAOFactory.CreateUserScreenPermissionDAO(CommonLib.Common.CurrentDatabase);
            dao.AddNew(null, dto);
        }

        internal void UpdateUserScreenPermissionFlagVIEW(UserScreenPermissionDTO dto)
        {
            IUserScreenPermissionDAO dao = DAOFactory.CreateUserScreenPermissionDAO(CommonLib.Common.CurrentDatabase);
            dao.UpdateUserScreenPermissionFlagVIEW(null, dto);
        }

        internal void UpdateUserScreenPermissionFlagADD(UserScreenPermissionDTO dto)
        {
            IUserScreenPermissionDAO dao = DAOFactory.CreateUserScreenPermissionDAO(CommonLib.Common.CurrentDatabase);
            dao.UpdateUserScreenPermissionFlagADD(null, dto);
        }

        internal void UpdateUserScreenPermissionFlagCHG(UserScreenPermissionDTO dto)
        {
            IUserScreenPermissionDAO dao = DAOFactory.CreateUserScreenPermissionDAO(CommonLib.Common.CurrentDatabase);
            dao.UpdateUserScreenPermissionFlagCHG(null, dto);
        }

        internal void UpdateUserScreenPermissionFlagDEL(UserScreenPermissionDTO dto)
        {
            IUserScreenPermissionDAO dao = DAOFactory.CreateUserScreenPermissionDAO(CommonLib.Common.CurrentDatabase);
            dao.UpdateUserScreenPermissionFlagDEL(null, dto);
        }

        internal void UpdateGroupScreenPermissionFlagVIEW(GroupScreenPermissionDTO dto)
        {
            IGroupScreenPermissionDAO dao = DAOFactory.CreateGroupScreenPermissionDAO(CommonLib.Common.CurrentDatabase);
            dao.UpdateGroupScreenPermissionFlagVIEW(null, dto);
        }

        internal void UpdateGroupScreenPermissionFlagADD(GroupScreenPermissionDTO dto)
        {
            IGroupScreenPermissionDAO dao = DAOFactory.CreateGroupScreenPermissionDAO(CommonLib.Common.CurrentDatabase);
            dao.UpdateGroupScreenPermissionFlagADD(null, dto);
        }

        internal void UpdateGroupScreenPermissionFlagCHG(GroupScreenPermissionDTO dto)
        {
            IGroupScreenPermissionDAO dao = DAOFactory.CreateGroupScreenPermissionDAO(CommonLib.Common.CurrentDatabase);
            dao.UpdateGroupScreenPermissionFlagCHG(null, dto);
        }

        internal void UpdateGroupScreenPermissionFlagDEL(GroupScreenPermissionDTO dto)
        {
            IGroupScreenPermissionDAO dao = DAOFactory.CreateGroupScreenPermissionDAO(CommonLib.Common.CurrentDatabase);
            dao.UpdateGroupScreenPermissionFlagDEL(null, dto);
        }
    }
}
