using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Data;
using EVOFramework;
using System.Data;
using Rubik.DTO;

namespace Rubik.UIDataModel
{
    public class SystemConfigurationUIDM : IUIDataModel
    {
        private NZString m_txtSysGroupId = new NZString();
        private NZString m_txtSysKey = new NZString();
        private NZString m_txtChrData = new NZString();
        private DataTable m_dtView = null;

        public NZString SysGroupId
        {
            get { return m_txtSysGroupId; }
            set { m_txtSysGroupId = value; }
        }
        public NZString SysKey
        {
            get { return m_txtSysKey; }
            set { m_txtSysKey = value; }
        }
        public NZString ChrData
        {
            get { return m_txtChrData; }
            set { m_txtChrData = value; }
        }

        public DataTable DATA_VIEW
        {
            get { return m_dtView; }
            set { m_dtView = value; }
        }
    }
}
