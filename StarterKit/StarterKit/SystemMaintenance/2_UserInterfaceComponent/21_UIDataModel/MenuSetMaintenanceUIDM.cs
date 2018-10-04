using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using EVOFramework.Data;

namespace SystemMaintenance.UIDataModel
{
    class MenuSetMaintenanceUIDM : IUIDataModel
    {
        NZString m_MenuSetCD = new NZString ();
        NZString m_MenuSetDesc = new NZString ();

        public NZString MenuSetCD { get { return m_MenuSetCD; } set { m_MenuSetCD = value; } }
        public NZString MenuSetDesc { get { return m_MenuSetDesc; } set { m_MenuSetDesc = value; } }
    }
}
