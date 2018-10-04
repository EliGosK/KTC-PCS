using EVOFramework;
using EVOFramework.Data;

namespace SystemMaintenance.UIDataModel
{
    public class SubMenuMaintenanceUIDM : IUIDataModel
    {
        private NZObject m_language = new NZObject();
        private NZString m_findText = new NZString();

        public NZObject Language
        {
            get { return m_language; }
            set { m_language = value; }
        }

        public NZString FindText
        {
            get { return m_findText; }
            set { m_findText = value; }
        }

    }
}

