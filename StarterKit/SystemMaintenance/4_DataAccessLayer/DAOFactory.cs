using System;
using EVOFramework.Database;

namespace SystemMaintenance.DAO
{    
    /// <summary>
    /// 
    /// </summary>
    internal class DAOFactory
    {
        #region Constant

        /// <summary>
        /// Namespace SQLServer Data Access Object.
        /// </summary>
        private const string C_NAMESPACE_SQLSERVER = "SystemMaintenance.SQLServer.DAO";

        /// <summary>
        /// Namespace Oracle Data Access Object.
        /// </summary>
        private const string C_NAMESPACE_ORACLE = "SystemMaintenance.Oracle.DAO";        

        #endregion

        #region Variables
        /// <summary>
        /// Database provider.
        /// </summary>
        private static DatabaseProvider m_dbProvider = DatabaseProvider.ORACLE;
        #endregion

        #region Constructor
        /// <summary>
        /// Initialize database provider.
        /// </summary>
        /// <param name="provider">Database Provider.</param>
        public static void SetProvider(DatabaseProvider provider) {
            m_dbProvider = provider;
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Get class data access object full name : "SystemMaintenance.Oracle.DAO.ScreenDAO" class.
        /// </summary>
        /// <param name="daoName">Class name of DataAccessObject, without namespace.</param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"><c>NotSupportedException</c>.</exception>
        private static string GetClassDAOFullName(string daoName) {
            switch (m_dbProvider) {
                case DatabaseProvider.ORACLE:
                    return String.Format(C_NAMESPACE_ORACLE + ".{0}", daoName);
                case DatabaseProvider.SQLSERVER:
                    return String.Format(C_NAMESPACE_SQLSERVER + ".{0}", daoName);                
                default:
                    throw new NotSupportedException("Not support database provider: " + m_dbProvider);
            }
        }        
        #endregion

        #region Get DAO Instance
        /// <summary>
        /// Create DAO Object (at runtime).
        /// </summary>
        /// <param name="daoName"></param>
        /// <param name="database"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><c>ArgumentException</c>.</exception>
        public static object CreateDAOObject(string daoName, Database database)
        {            
            string fullName = GetClassDAOFullName(daoName);            

            Type typeObj = Type.GetType(fullName);
            if (typeObj == null)
            {
                throw new ArgumentException(String.Format("Not found class type : {0} on database provider: {1}", fullName, m_dbProvider));
            }

            object obj = Activator.CreateInstance(typeObj, new object[] { database });
            if (obj == null)
            {
                throw new ArgumentException(String.Format("Not found class type : {0} on database provider: {1}", fullName, m_dbProvider));
            }

            return obj;
        }

        public static IClassListDAO CreateClassListDAO(Database database)
        {
            return (IClassListDAO)CreateDAOObject(DAOClassList.ClassListDAO, database);
        }
        public static IGroupScreenPermissionDAO CreateGroupScreenPermissionDAO(Database database)
        {
            return (IGroupScreenPermissionDAO)CreateDAOObject(DAOClassList.GroupScreenPermissionDAO, database);
        }
        public static IImageDAO CreateImageDAO(Database database)
        {
            return (IImageDAO)CreateDAOObject(DAOClassList.ImageDAO, database);
        }
        public static ILangDAO CreateLangDAO(Database database)
        {
            return (ILangDAO)CreateDAOObject(DAOClassList.LangDAO, database);
        }
        public static IMenuDAO CreateMenuDAO(Database database)
        {
            return (IMenuDAO)CreateDAOObject(DAOClassList.MenuDAO, database);
        }
        public static IMenuFavoriteDAO CreateMenuFavoriteDAO(Database database)
        {
            return (IMenuFavoriteDAO)CreateDAOObject(DAOClassList.MenuFavoriteDAO, database);
        }
        public static IMenuSetDAO CreateMenuSetDAO(Database database)
        {
            return (IMenuSetDAO)CreateDAOObject(DAOClassList.MenuSetDAO, database);
        }
        public static IMenuSetDetailDAO CreateMenuSetDetailDAO(Database database)
        {
            return (IMenuSetDetailDAO)CreateDAOObject(DAOClassList.MenuSetDetailDAO, database);
        }
        public static IMenuSubDAO CreateMenuSubDAO(Database database)
        {
            return (IMenuSubDAO)CreateDAOObject(DAOClassList.MenuSubDAO, database);
        }
        public static IMenuSubItemDAO CreateMenuSubItemDAO(Database database)
        {
            return (IMenuSubItemDAO)CreateDAOObject(DAOClassList.MenuSubItemDAO, database);
        }
        public static IMenuSubLangDAO CreateMenuSubLangDAO(Database database)
        {
            return (IMenuSubLangDAO)CreateDAOObject(DAOClassList.MenuSubLangDAO, database);
        }
        public static IScreenDAO CreateScreenDAO(Database database)
        {
            return (IScreenDAO)CreateDAOObject(DAOClassList.ScreenDAO, database);
        }
        public static IScreenDetailDAO CreateScreenDetailDAO(Database database)
        {
            return (IScreenDetailDAO)CreateDAOObject(DAOClassList.ScreenDetailDAO, database);
        }
        public static IScreenDetailLangDAO CreateScreenDetailLangDAO(Database database)
        {
            return (IScreenDetailLangDAO)CreateDAOObject(DAOClassList.ScreenDetailLangDAO, database);
        }
        public static IScreenLangDAO CreateScreenLangDAO(Database database)
        {
            return (IScreenLangDAO)CreateDAOObject(DAOClassList.ScreenLangDAO, database);
        }
        public static IUserDAO CreateUserDAO(Database database)
        {
            return (IUserDAO)CreateDAOObject(DAOClassList.UserDAO, database);
        }
        public static IUserGroupDAO CreateUserGroupDAO(Database database)
        {
            return (IUserGroupDAO)CreateDAOObject(DAOClassList.UserGroupDAO, database);
        }
        public static IUserScreenPermissionDAO CreateUserScreenPermissionDAO(Database database)
        {
            return (IUserScreenPermissionDAO)CreateDAOObject(DAOClassList.UserScreenPermissionDAO, database);
        }
        #endregion

    }
}
