using System;
using EVOFramework.Data;
using EVOFramework;
using System.Windows.Forms;
using EVOFramework.Database;
using SystemMaintenance.DTO;
using CommonLib;
using SystemMaintenance.Validators;
using SystemMaintenance.BIZ;
using EVOFramework.IO;
using System.Data;

namespace SystemMaintenance.Controller
{
    public class UserController
    {
        public const string S_SECTION = "Application";
        public const string S_USER = "UserLastLogin";

        /// <summary>
        /// Login operation
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Return true if login complete. Otherwise return false.</returns>
        public bool Login(NZString username, NZString password)
        {

            ConfigurationController prc = new ConfigurationController();
            UserValidator userValidator = new UserValidator();
            ErrorItem errorItem = null;

            //== Load last database configuration.
            Map<string, string> mapConfig = prc.LoadConfiguration();
            DatabaseCredential credential = new DatabaseCredential();

            credential.Provider = (DatabaseProvider)Enum.Parse(typeof(DatabaseProvider), mapConfig[ConfigurationController.S_KEY_PROVIDER_NAME].Value);
            credential.ServerName = mapConfig[ConfigurationController.S_KEY_SERVER_NAME].Value;
            credential.DatabaseName = mapConfig[ConfigurationController.S_KEY_DATABASE_NAME].Value;
            credential.Username = mapConfig[ConfigurationController.S_KEY_USERNAME].Value;
            credential.Password = mapConfig[ConfigurationController.S_KEY_PASSWORD].Value;
          
            credential.ConnectionTimeout = mapConfig[ConfigurationController.S_KEY_CONNECTION_TIMEOUT].Value;


            int iCommandTimeout = 0;

            if (Int32.TryParse(mapConfig[ConfigurationController.S_KEY_COMMAND_TIMEOUT].Value, out iCommandTimeout))
            {
                Database.m_iDefaultCommandTimeout = iCommandTimeout;
            }
            else
            {
                Database.m_iDefaultCommandTimeout = 30;
            }

            //== Test database connection ans register current database.
            errorItem = DatabaseManager.TestConnection(credential);
            if (errorItem == null)
            {
                // Initialize DAO Factory.
                SystemMaintenance.DAO.DAOFactory.SetProvider(credential.Provider);

                // Register current database.
                Common.RegisterCurrentDatabase(DatabaseManager.CreateDatabase(credential));

                // Register message loader.
                ApplicationContextManager.RegisterMessageLoader(new DBMessageLoader(Common.CurrentDatabase));
            }
            else
            {
                MessageBox.Show(errorItem.Message.MessageDescription, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Release current database.
                Common.UnregisterUserInformation();
                return false;
            }


            userValidator.ValidateLogin(username, password);

            // Singin user information session.            
            UserBIZ userBiz = new UserBIZ();
            UserDTO userDTO = userBiz.LoadUser(username);

            userBiz.RegisterMachine(username);

            UserInfo userInfo = new UserInfo();
            userInfo.DateFormat = (eDateFormat)userDTO.DATE_FORMAT.StrongValue;
            userInfo.LanguageCD.Value = userDTO.LANG_CD.Value;
            userInfo.LastLogin.Value = DateTime.Now;
            userInfo.UserCD.Value = userDTO.USER_ACCOUNT.Value;
            userInfo.Username.Value = userDTO.FULL_NAME.Value;
            userInfo.Machine.Value = Environment.MachineName;
            userInfo.GroupCode.Value = userDTO.GROUP_CD.Value;
            Common.RegisterUserInformation(userInfo);

            // Store last user login.
            IniFile ini = new IniFile(System.IO.Path.Combine(Application.StartupPath, Common.CONFIG_FILENAME));
            ini.Write(S_SECTION, S_USER, username.StrongValue);
            ini.Dispose();

            return true;
        }

        /// <summary>
        /// Load user account last login.
        /// </summary>
        /// <returns></returns>
        public string LoadUserLastLogin()
        {
            IniFile ini = new IniFile(System.IO.Path.Combine(Application.StartupPath, Common.CONFIG_FILENAME));
            string strResult = ini.Read(S_SECTION, S_USER, string.Empty);
            ini.Dispose();

            return strResult;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Logout()
        {
            Common.UnregisterUserInformation();
            ApplicationContextManager.UnregisterMessageLoader();
            Common.CurrentDatabase = null;

            ImageCache.ReleaseInstance();
            ProgramScreenCache.ReleaseInstance();
            InternalScreenCache.ReleaseIntance();
            DatabaseScreenCache.ReleaseInstance();
            return true;
        }

        public DataTable LoadPermissionTable(string strUserName)
        {
            DataTable dtPermission = null;

            UserBIZ userBiz = new UserBIZ();
            dtPermission = userBiz.LoadPermissionTable(strUserName);

            return dtPermission;
        }
    }
}
