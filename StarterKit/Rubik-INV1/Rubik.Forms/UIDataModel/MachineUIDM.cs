using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Data;
using EVOFramework;
using EVOFramework.Database;

namespace Rubik.UIDataModel 
{
    [Serializable()]
    [DataTransferObject("MachineUIDM", typeof(eColumns))]
    public class MachineUIDM : AbstractDTO, IUIDataModel
    {    
        #region " Enums Columns "
        public enum eColumns {
            CRT_BY,
            CRT_DATE,
            CRT_MACHINE,
            UPD_BY,
            UPD_DATE,
            UPD_MACHINE,
            MACHINE_CD,
            MACHINE_TYPE,
            PROCESS_CD,
            MACHINE_GROUP,
            PROJECT,
            REMARK
        };
        #endregion

        #region " Variables "
        private NZString m_strCRT_BY = new NZString();
        private NZDateTime m_dtCRT_DATE = new NZDateTime();
        private NZString m_strCRT_MACHINE = new NZString();
        private NZString m_strUPD_BY = new NZString();
        private NZDateTime m_dtUPD_DATE = new NZDateTime();
        private NZString m_strUPD_MACHINE = new NZString();
        private NZString m_strMACHINE_CD = new NZString();
        private NZString m_strMACHINE_TYPE = new NZString();
        private NZString m_strPROCESS_CD = new NZString();
        private NZString m_strMACHINE_GROUP = new NZString();
        private NZString m_strPROJECT = new NZString();
        private NZString m_strREMARK = new NZString();
        #endregion

        #region " Getter and Setter properties "
        public NZString CRT_BY {
            get { return m_strCRT_BY; }
            set {
                if (value == null)
                    m_strCRT_BY.Value = value;
                else
                    m_strCRT_BY = value;
            }
        }
        public NZDateTime CRT_DATE {
            get { return m_dtCRT_DATE; }
            set {
                if (value == null)
                    m_dtCRT_DATE.Value = value;
                else
                    m_dtCRT_DATE = value;
            }
        }
        public NZString CRT_MACHINE {
            get { return m_strCRT_MACHINE; }
            set {
                if (value == null)
                    m_strCRT_MACHINE.Value = value;
                else
                    m_strCRT_MACHINE = value;
            }
        }
        public NZString UPD_BY {
            get { return m_strUPD_BY; }
            set {
                if (value == null)
                    m_strUPD_BY.Value = value;
                else
                    m_strUPD_BY = value;
            }
        }
        public NZDateTime UPD_DATE {
            get { return m_dtUPD_DATE; }
            set {
                if (value == null)
                    m_dtUPD_DATE.Value = value;
                else
                    m_dtUPD_DATE = value;
            }
        }
        public NZString UPD_MACHINE {
            get { return m_strUPD_MACHINE; }
            set {
                if (value == null)
                    m_strUPD_MACHINE.Value = value;
                else
                    m_strUPD_MACHINE = value;
            }
        }
        public NZString MACHINE_CD {
            get { return m_strMACHINE_CD; }
            set {
                if (value == null)
                    m_strMACHINE_CD.Value = value;
                else
                    m_strMACHINE_CD = value;
            }
        }
        public NZString MACHINE_TYPE {
            get { return m_strMACHINE_TYPE; }
            set {
                if (value == null)
                    m_strMACHINE_TYPE.Value = value;
                else
                    m_strMACHINE_TYPE = value;
            }
        }
        public NZString PROCESS_CD {
            get { return m_strPROCESS_CD; }
            set {
                if (value == null)
                    m_strPROCESS_CD.Value = value;
                else
                    m_strPROCESS_CD = value;
            }
        }        
        public NZString MACHINE_GROUP {
            get { return m_strMACHINE_GROUP; }
            set {
                if (value == null)
                    m_strMACHINE_GROUP.Value = value;
                else
                    m_strMACHINE_GROUP = value;
            }
        }        
        public NZString PROJECT {
            get { return m_strPROJECT; }
            set {
                if (value == null)
                    m_strPROJECT.Value = value;
                else
                    m_strPROJECT = value;
            }
        }        
        public NZString REMARK {
            get { return m_strREMARK; }
            set {
                if (value == null)
                    m_strREMARK.Value = value;
                else
                    m_strREMARK = value;
            }
        }

        #endregion
    }
}
