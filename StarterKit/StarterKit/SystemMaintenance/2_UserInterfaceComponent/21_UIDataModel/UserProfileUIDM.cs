using EVOFramework;
using EVOFramework.Data;

namespace SystemMaintenance.UIDataModel
{
    public class UserProfileUIDM : IUIDataModel
    {
        private NZString m_userAccount = new NZString();
        private NZString m_username = new NZString();
        private NZString m_password = new NZString();
        private NZString m_confirmPassword = new NZString();
        private NZInt m_defaultDateFormat = new NZInt();
        private NZInt m_defaultLang = new NZInt();
        private NZString m_currentPassword = new NZString();

        public NZString UserAccount
        {
            get { return m_userAccount; }
            set { m_userAccount = value; }
        }

        public NZString Username
        {
            get { return m_username; }
            set { m_username = value; }
        }

        public NZString Password
        {
            get { return m_password; }
            set { m_password = value; }
        }

        public NZString ConfirmPassword
        {
            get { return m_confirmPassword; }
            set { m_confirmPassword = value; }
        }

        public NZInt DefaultDateFormat
        {
            get { return m_defaultDateFormat; }
            set { m_defaultDateFormat = value; }
        }

        public NZInt DefaultLang
        {
            get { return m_defaultLang; }
            set { m_defaultLang = value; }
        }

        public NZString CurrentPassword
        {
            get { return m_currentPassword; }
            set { m_currentPassword = value; }
        }

    }
}

