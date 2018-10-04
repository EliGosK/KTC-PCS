using System.Text;
using EVOFramework.Database;
using EVOFramework;
using System.Drawing;
using System;
using System.Data;

namespace CommonLib
{
    public static class Common
    {
        #region Enum
        public enum eScreenMode
        {
            VIEW,
            ADD,
            EDIT,
        }
        #endregion

        #region Theme/Appearance
        #region Speard Color

        /// <summary>
        /// Default skin for all spread sheet.
        /// </summary>
        public static readonly FarPoint.Win.Spread.SheetSkin ACTIVE_SKIN = new FarPoint.Win.Spread.SheetSkin(
            "ERPSkin",
            System.Drawing.Color.Transparent,
            System.Drawing.Color.Empty,
            System.Drawing.Color.Empty,
            System.Drawing.Color.Transparent,
            FarPoint.Win.Spread.GridLines.Both,
            Color.FromArgb(169, 209, 190),
            System.Drawing.Color.DarkGreen,
            System.Drawing.Color.LightSteelBlue,
            System.Drawing.Color.White,
            Color.FromArgb(236, 247, 243),
            System.Drawing.Color.White, false, false, false, true, true);
        /// <summary>
        /// BackColor of SheetView when editing row, column or cell
        /// </summary>
        /// 
        public static Color COLOR_GRID_EDIT_BG = Color.FromArgb(255, 224, 192);

        public static Color SP_LOCK_FG_COLOR = Color.Black;
        public static Color SP_UNLOCK_FG_COLOR = Color.Blue;
        #endregion

        #region COLOR for Control's ReadOnly
        /// <summary>
        /// BackColor of control that use for ReadOnly.
        /// </summary>
        [Obsolete("Use appearance.")]
        public static Color COLOR_READONLY_BG = Color.FromArgb(236, 247, 243);

        /// <summary>
        /// ForeColor of control that use for ReadOnly.
        /// </summary>
        public static Color COLOR_READONLY_FG = Color.Black;
        #endregion

        #region COLOR for Control's NORMAL
        public static Color COLOR_NORMAL_BG = Color.White;
        public static Color COLOR_NORMAL_FG = Color.Black;
        public static Color COLOR_ALTERNATE_BG = Color.FromArgb(236, 247, 243);

        public static Color COLOR_MINUS_CURRENT_MONTH = Color.Red;
        public static Color COLOR_MINUS_NEXT_MONTH = Color.Yellow;
        #endregion

        #region Color for Control's REQUIRE
        public static Color COLOR_REQUIRE_BG = Color.LemonChiffon;
        public static Color COLOR_REQUIRE_FG = Color.Black;
        #endregion


        #endregion

        #region ComboBoxEx event string format.
        /// <summary>
        /// Method signature for bind event format combobox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void ComboBox_Format(object sender, System.Windows.Forms.ListControlConvertEventArgs e)
        {
            System.Windows.Forms.ComboBox combo = sender as System.Windows.Forms.ComboBox;
            if (combo == null)
                return;

            System.Data.DataRowView view = e.ListItem as System.Data.DataRowView;
            if (view != null)
            {
                if ("".Equals(view[combo.DisplayMember]) || DBNull.Value.Equals(view[combo.DisplayMember]))
                {
                    e.Value = view[combo.ValueMember];
                }
                else
                {
                    e.Value = String.Format("{0}{1}{2}", view[combo.ValueMember], COMBOBOX_SEPERATOR_SYMBOL, view[combo.DisplayMember]);
                }
            }

        }
        #endregion

        #region Constant
        public const string CONFIG_FILENAME = "config.ini";
        public const string COMBOBOX_SEPERATOR_SYMBOL = " : ";

        public const string LOT_NO_GROUPBY = "XXXXXXXXXX";
        #endregion

        #region Variables
        /// <summary>
        /// Current database.
        /// </summary>
        private static Database m_currentDatabase;
        /// <summary>
        /// Initialize the system language.
        /// </summary>
        private readonly static NZString m_systemLanguage = new NZString(null, "en-EN");

        /// <summary>
        /// Store current user login information.
        /// </summary>
        private static UserInfo m_userInfo;

        public static NZString Version = new NZString(null, string.Empty);
        public static NZString UpdateDate = new NZString(null, string.Empty);

        private static DataTable m_permissionInfo;

        #endregion

        #region Properties
        /// <summary>
        /// Current database.
        /// </summary>
        public static Database CurrentDatabase
        {
            get { return m_currentDatabase; }
            set
            {
                m_currentDatabase = value;
            }
        }

        /// <summary>
        /// Initialize the system language.
        /// </summary>
        public static NZString SystemLanguage
        {
            get { return m_systemLanguage; }
        }

        /// <summary>
        /// Store current user login information.
        /// </summary>
        public static UserInfo CurrentUserInfomation
        {
            get { return m_userInfo; }
        }

        /// <summary>
        /// Get database system date time.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception">CurrentDatabase just not registration.</exception>
        public static DateTime GetDatabaseDateTime()
        {
            if (CurrentDatabase == null)
            {
                throw new Exception("CurrentDatabase just not registration.");
            }
            string strSql = String.Empty;

            switch (CurrentDatabase.Credential.Provider)
            {
                case DatabaseProvider.ORACLE:
                    strSql = "SELECT SYSDATE FROM DUAL";
                    break;
                case DatabaseProvider.SQLSERVER:
                    strSql = "SELECT GETDATE()";
                    break;
                case DatabaseProvider.ACCESS:
                    break;
            }

            DataRequest req = new DataRequest(strSql);
            return Convert.ToDateTime(CurrentDatabase.ExecuteScalar(req));
        }

        public static DataTable PermissionTable
        {
            get { return m_permissionInfo; }
        }



        #endregion

        #region Public methods
        #region User Information
        /// <summary>
        /// After user login to system, should register user information.
        /// </summary>
        /// <param name="info"></param>
        public static void RegisterUserInformation(UserInfo info)
        {
            m_userInfo = info;
        }
        /// <summary>
        /// Release user information.
        /// </summary>
        public static void UnregisterUserInformation()
        {
            m_userInfo = null;
        }
        #endregion

        #region Current Database registration
        public static void RegisterCurrentDatabase(Database database)
        {
            m_currentDatabase = database;
        }
        public static void UnregisterCurrentDatabase()
        {
            m_currentDatabase = null;
        }
        #endregion

        #region Permission Information
        public static void RegisterPermissionInformation(DataTable dtPermission)
        {
            m_permissionInfo = dtPermission;
        }
        public static void UnregisterPermissionInformation()
        {
            m_permissionInfo = null;
        }
        #endregion
        #endregion


        public const string UserGroupShowFormatButton = "Admins";
    }

    public static class ConfigIniSection
    {
        public const string DatabaseSetting = "DatabaseSetting";
        public const string Application = "Application";
    }
}
