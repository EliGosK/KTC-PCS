using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using EVOFramework.Data;
using System.Data;

namespace SystemMaintenance.UIDataModel
{
    public class UserMaintenanceUIDM : IUIDataModel
    {
        public DataTable Groups { get; set; }
        public DataTable User { get; set; }
    }

    public class CreateUserDomain : IUIDataModel
    {
        private NZString m_UserAccount = new NZString();
        private NZString m_UserName = new NZString();
        private NZString m_PassWord = new NZString();
        private NZInt m_DefaultDateFormat = new NZInt();
        private NZString m_DefaultLang = new NZString();
        private NZString m_GroupUser = new NZString();
        private NZString m_MenuSet = new NZString();
        private NZInt m_IsActive = new NZInt();
        private NZInt m_IsResign = new NZInt();

        public NZString UserAccount { get { return m_UserAccount; } set { m_UserAccount = value; } }
        public NZString UserName { get { return m_UserName; } set { m_UserName = value; } }
        public NZString PassWord { get { return m_PassWord; } set { m_PassWord = value; } }
        public NZInt DefaultDateFormat { get { return m_DefaultDateFormat; } set { m_DefaultDateFormat = value; } }
        public NZString DefaultLang { get { return m_DefaultLang; } set { m_DefaultLang = value; } }
        public NZString GroupUser { get { return m_GroupUser; } set { m_GroupUser = value; } }
        public NZString MenuSet { get { return m_MenuSet; } set { m_MenuSet = value; } }
        public NZInt IsActive { get { return m_IsActive; } set { m_IsActive = value; } }
        public NZInt IsResign { get { return m_IsResign; } set { m_IsResign = value; } }
    }

    public class DeleteUserDomain : IUIDataModel
    {
        private NZInt m_ActiveRow = new NZInt();
        private NZString m_UserAccount = new NZString();

        public NZString UserAccount { get { return m_UserAccount; } set { m_UserAccount = value; } }
        public NZInt ActiveRow { get { return m_ActiveRow; } set { m_ActiveRow = value; } }
    }

    public class CreateGroupDomain : IUIDataModel
    {
        private NZString m_GroupCD = new NZString();
        private NZString m_GroupDesc = new NZString();

        public NZString GroupCD { get { return m_GroupCD; } set { m_GroupCD = value; } }
        public NZString GroupDesc { get { return m_GroupDesc; } set { m_GroupDesc = value; } }
        
    }
}
