using System;
using EVOFramework.Data;
using EVOFramework.IO;
using System.Windows.Forms;
using System.Data;
using EVOFramework;
using EVOFramework.Database;

namespace SystemMaintenance.Controller
{
    /// <summary>
    /// Configuration process.
    /// </summary>
    public class ConfigurationController
    {
        public const string S_SECTION = "DatabaseSetting";
        public const string S_KEY_PROVIDER_NAME = "Provider";
        public const string S_KEY_SERVER_NAME = "ServerName";
        public const string S_KEY_DATABASE_NAME = "DatabaseName";
        public const string S_KEY_USERNAME = "Username";
        public const string S_KEY_PASSWORD = "Password";
        public const string S_KEY_CONNECTION_TIMEOUT = "ConnectionTimeout";
        public const string S_KEY_COMMAND_TIMEOUT = "CommandTimeout";

        public const string S_SECTION_AUTOUPDATE = "AutoUpdate";
        public const string S_KEY_AUTOUPDATE_PATH = "AutoUpdatePath";
        public const string S_KEY_AUTOUPDATE_FILENAME = "AutoUpdateFileName";

        /// <summary>
        /// ถ้าไม่ต้องการให้ถอดรหัส Password ให้ปรับเป็น false
        /// </summary>
        private bool m_bUseHashPassword = true;

        /// <summary>
        /// Load configuration.
        /// </summary>
        /// <returns></returns>
        public Map<string, string> LoadConfiguration()
        {
            IniFile file = new IniFile(System.IO.Path.Combine(Application.StartupPath, CommonLib.Common.CONFIG_FILENAME));

            Map<string, string> map = new Map<string, string>();
            map.Put(S_KEY_PROVIDER_NAME, file.Read(S_SECTION, S_KEY_PROVIDER_NAME, string.Empty));
            map.Put(S_KEY_SERVER_NAME, file.Read(S_SECTION, S_KEY_SERVER_NAME, string.Empty));
            map.Put(S_KEY_DATABASE_NAME, file.Read(S_SECTION, S_KEY_DATABASE_NAME, string.Empty));
            map.Put(S_KEY_USERNAME, file.Read(S_SECTION, S_KEY_USERNAME, string.Empty));
            map.Put(S_KEY_CONNECTION_TIMEOUT, file.Read(S_SECTION, S_KEY_CONNECTION_TIMEOUT, "10"));
            map.Put(S_KEY_COMMAND_TIMEOUT, file.Read(S_SECTION, S_KEY_COMMAND_TIMEOUT, "120"));
            map.Put(S_KEY_AUTOUPDATE_PATH, file.Read(S_SECTION_AUTOUPDATE, S_KEY_AUTOUPDATE_PATH, string.Empty));
            map.Put(S_KEY_AUTOUPDATE_FILENAME, file.Read(S_SECTION_AUTOUPDATE, S_KEY_AUTOUPDATE_FILENAME, string.Empty));


            string encPass = file.Read(S_SECTION, S_KEY_PASSWORD, string.Empty);

            try
            {
                if (encPass == string.Empty)
                    map.Put(S_KEY_PASSWORD, string.Empty);
                else
                {

                    if (m_bUseHashPassword)
                    {
                        string decPass = Encryption.TwoWayDecryptString(encPass, map[S_KEY_USERNAME].Value.Trim().ToLower());
                        map.Put(S_KEY_PASSWORD, decPass);
                    }
                    else
                    {
                        map.Put(S_KEY_PASSWORD, encPass);
                    }
                }
            }
            catch
            {
                map.Put(S_KEY_PASSWORD, encPass);
            }

            file.Dispose();

            return map;
        }

        /// <summary>
        /// Save configuration.
        /// </summary>        
        /// <param name="providername"></param>
        /// <param name="servername"></param>
        /// <param name="databasename"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void SaveConfiguration(string providername, string servername, string databasename, string username, string password)
        {
            IniFile file = new IniFile(System.IO.Path.Combine(Application.StartupPath, CommonLib.Common.CONFIG_FILENAME));

            string encPass = Encryption.TwoWayEncryptString(password, username.Trim().ToLower());
            file.Write(S_SECTION, S_KEY_PROVIDER_NAME, providername.Trim());
            file.Write(S_SECTION, S_KEY_SERVER_NAME, servername.Trim());
            file.Write(S_SECTION, S_KEY_DATABASE_NAME, databasename.Trim());
            file.Write(S_SECTION, S_KEY_USERNAME, username.Trim());
            file.Write(S_SECTION, S_KEY_PASSWORD, encPass);

            file.Write(S_SECTION, S_KEY_CONNECTION_TIMEOUT, file.Read(S_SECTION, S_KEY_CONNECTION_TIMEOUT, "10"));
            file.Write(S_SECTION, S_KEY_COMMAND_TIMEOUT, file.Read(S_SECTION, S_KEY_COMMAND_TIMEOUT, "30"));
            file.Write(S_SECTION_AUTOUPDATE, S_KEY_AUTOUPDATE_PATH, file.Read(S_SECTION_AUTOUPDATE, S_KEY_AUTOUPDATE_PATH, string.Empty));
            file.Write(S_SECTION_AUTOUPDATE, S_KEY_AUTOUPDATE_FILENAME, file.Read(S_SECTION_AUTOUPDATE, S_KEY_AUTOUPDATE_FILENAME, string.Empty));

            file.Dispose();
        }

        public LookupData LoadLookupDateFormat()
        {
            DataTable dt = new DataTable("DateFormat");
            dt.Columns.Add("Key", typeof(int));
            dt.Columns.Add("Value", typeof(string));

            string[] strNames = Enum.GetNames(typeof(eDateFormat));
            for (int i = 0; i < strNames.Length; i++)
            {
                dt.Rows.Add((int)Enum.Parse(typeof(eDateFormat), strNames[i]), strNames[i]);
            }

            return new LookupData(dt, "Value", "Key");
        }

        public ErrorItem TestConnection(DatabaseProvider eProvider, string servername, string databaseName, string username, string password)
        {
            DatabaseCredential credential = new DatabaseCredential();
            credential.Provider = eProvider;
            credential.ServerName = servername;
            credential.DatabaseName = databaseName;
            credential.Username = username;
            credential.Password = password;

            return DatabaseManager.TestConnection(credential);
        }
    }
}
