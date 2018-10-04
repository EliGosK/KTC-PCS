using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using EVOFramework.Data;

namespace SystemMaintenance.UIDataModel
{
    public class ScreenImportUIDM : IUIDataModel
    {
        private NZString m_ScreenCD = new NZString();
        private NZString m_ScreenName = new NZString();
        private NZString m_OriginalTitle = new NZString();
        private NZInt m_ScreenType = new NZInt();
        private NZString m_ImportStatus = new NZString();
        public NZString ScreenCD { get { return m_ScreenCD; } set { m_ScreenCD = value; } }
        public NZString OriginalTitle { get { return m_OriginalTitle; } set { m_OriginalTitle = value; } }
        public NZString ScreenName { get { return m_ScreenName; } set { m_ScreenName = value; } }
        public NZInt ScreenType { get { return m_ScreenType; } set { m_ScreenType = value; } }
        public NZString ImportStatus { get { return m_ImportStatus; } set { m_ImportStatus = value; } }
    }

    public class ScreenDetailUIDM : IUIDataModel
    {
        private NZString m_ScreenCD = new NZString();
        private NZString m_OriginalTitle = new NZString();
        private NZString m_ControlCD = new NZString();
        private NZString m_ControlType = new NZString();
        private NZString m_ControlCaption = new NZString();
        public NZString ScreenCD { get { return m_ScreenCD; } set { m_ScreenCD = value; } }
        public NZString OriginalTitle { get { return m_OriginalTitle; } set { m_OriginalTitle = value; } }
        public NZString ControlCD { get { return m_ControlCD; } set { m_ControlCD = value; } }
        public NZString ControlType { get { return m_ControlType; } set { m_ControlType = value; } }
        public NZString ControlCaption { get { return m_ControlCaption; } set { m_ControlCaption = value; } }
    }
  
}
