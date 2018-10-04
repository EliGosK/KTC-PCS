using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;

namespace CommonLib
{
    /// <summary>
    /// Session user login.
    /// </summary>
    public class UserInfo
    {
        private readonly NZString m_userCD;
        private readonly NZString m_username;
        private readonly NZString m_languageCD;        
        private readonly NZDateTime m_lastLogin;
        private readonly NZString m_machine;
        private readonly NZString m_groupCD;
        private eDateFormat m_dateFormat;

        public UserInfo() {
            m_userCD = new NZString();    
            m_username = new NZString();
            m_languageCD = new NZString();
            m_dateFormat = eDateFormat.YMD;
            m_lastLogin = new NZDateTime();
            m_machine = new NZString();
            m_groupCD = new NZString();
        }

        public NZString UserCD {
            get { return m_userCD; }
        }

        public NZString Username {
            get { return m_username; }
        }

        public NZString LanguageCD {
            get { return m_languageCD; }
        }

        public eDateFormat DateFormat {
            get { return m_dateFormat; }
            set { m_dateFormat = value; }
        }

        public NZDateTime LastLogin {
            get { return m_lastLogin; }
        }

        public NZString Machine {
            get { return m_machine; }
        }

        public NZString GroupCode
        {
            get { return m_groupCD; }
        }

        public string DateFormatString {
            get {
                switch (DateFormat) {
                    case eDateFormat.YMD:
                        return "yyyy/MM/dd";
                    case eDateFormat.MDY:
                        return "MM/dd/yyyy";
                    case eDateFormat.DMY:
                        return "dd/MM/yyyy";
                    default:
                        return "yyyy/MM/dd";
                }
            }
        }
    }
}
