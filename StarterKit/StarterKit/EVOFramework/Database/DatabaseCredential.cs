using System;
using System.Collections.Generic;
using System.Text;

namespace EVOFramework.Database
{
    public class DatabaseCredential
    {
        private string m_strServerName = String.Empty;
        private string m_strDBName = String.Empty;
        private string m_strUsername = String.Empty;
        private string m_strPassword = String.Empty;
        private string m_strConnectionTimeout = String.Empty;
        private DatabaseProvider m_provider = DatabaseProvider.ORACLE;

        public string ServerName
        {
            get { return this.m_strServerName; }
            set { this.m_strServerName = value; }
        }
        public string DatabaseName
        {
            get { return this.m_strDBName; }
            set { this.m_strDBName = value; }
        }
        public string Username
        {
            get { return this.m_strUsername.Trim(); }
            set { this.m_strUsername = value.Trim(); }
        }
        public string Password
        {
            get { return this.m_strPassword; }
            set { this.m_strPassword = value.Trim(); }
        }
        public string ConnectionTimeout
        {
            get { return this.m_strConnectionTimeout; }
            set
            {
                int iValue = 0;
                if (Int32.TryParse(value, out iValue))
                {
                    this.m_strConnectionTimeout = iValue.ToString();
                }
                else
                {
                    this.m_strConnectionTimeout = "30";
                }
            }
        }
        public DatabaseProvider Provider
        {
            get { return this.m_provider; }
            set { this.m_provider = value; }
        }

        /// <summary>
        /// Get connection string.
        /// This will generate connection string following by specified provider.
        /// </summary>
        public string ConnectionString
        {
            get
            {
                string strConn = String.Empty;
                switch (this.m_provider)
                {
                    case DatabaseProvider.ORACLE:
                        strConn = String.Format("Data Source={0};Persist Security Info=True;User ID={1};Password={2};Unicode=True",
                            this.DatabaseName, this.Username, this.Password);
                        break;
                    case DatabaseProvider.SQLSERVER:
                        strConn = String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};Timeout={4};",
                            this.ServerName, this.DatabaseName, this.Username, this.Password, this.ConnectionTimeout);
                        break;
                }
                if (strConn == String.Empty)
                    throw new ApplicationException("Database can't generate ConnectionString");
                return strConn;
            }
        }


        public string OleDbConnectionString
        {
            get
            {
                return

                    string.Format("Provider=SQLOLEDB;Data Source={0};Initial Catalog={1};User ID={2};Password={3};Timeout={4}",
                    this.ServerName, this.DatabaseName, this.Username, this.Password, this.ConnectionTimeout);
            }
        }
    }
}
