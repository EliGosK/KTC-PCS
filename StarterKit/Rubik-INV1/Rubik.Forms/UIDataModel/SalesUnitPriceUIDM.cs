using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Data;
using EVOFramework;

namespace Rubik.UIDataModel {

    public class SalesUnitPriceUIDM : IUIDataModel
    {
        #region " Variables "
        private NZString m_strCRT_BY = new NZString();
        private NZDateTime m_dtCRT_DATE = new NZDateTime();
        private NZString m_strCRT_MACHINE = new NZString();
        private NZString m_strUPD_BY = new NZString();
        private NZDateTime m_dtUPD_DATE = new NZDateTime();
        private NZString m_strUPD_MACHINE = new NZString();
        private NZString m_strITEM_CD = new NZString();
        private NZDateTime m_dtSTART_EFFECTIVE_DATE = new NZDateTime();
        private NZDecimal m_dPRICE = new NZDecimal();
        private NZString m_strCURRENCY = new NZString();
        private NZString m_strREMARK = new NZString();
        private NZInt m_iOLD_DATA = new NZInt();

        private NZString m_strSHORT_NAME = new NZString();
        private NZString m_strCUSTOMER_CD = new NZString();
        private NZString m_strCUSTOMER_NAME = new NZString();
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
        public NZString ITEM_CD {
            get { return m_strITEM_CD; }
            set {
                if (value == null)
                    m_strITEM_CD.Value = value;
                else
                    m_strITEM_CD = value;
            }
        }
        public NZDateTime START_EFFECTIVE_DATE {
            get { return m_dtSTART_EFFECTIVE_DATE; }
            set {
                if (value == null)
                    m_dtSTART_EFFECTIVE_DATE.Value = value;
                else
                    m_dtSTART_EFFECTIVE_DATE = value;
            }
        }
        public NZDecimal PRICE {
            get { return m_dPRICE; }
            set {
                if (value == null)
                    m_dPRICE.Value = value;
                else
                    m_dPRICE = value;
            }
        }
        public NZString CURRENCY {
            get { return m_strCURRENCY; }
            set {
                if (value == null)
                    m_strCURRENCY.Value = value;
                else
                    m_strCURRENCY = value;
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
        public NZInt OLD_DATA {
            get { return m_iOLD_DATA; }
            set {
                if (value == null)
                    m_iOLD_DATA.Value = value;
                else
                    m_iOLD_DATA = value;
            }
        }
        
        //Part No on screen
        public NZString SHORT_NAME {
            get { return m_strSHORT_NAME; }
            set {
                if (value == null)
                    m_strSHORT_NAME.Value = value;
                else
                    m_strSHORT_NAME = value;
            }
        }
        public NZString CUSTOMER_CD {
            get { return m_strCUSTOMER_CD; }
            set {
                if (value == null)
                    m_strCUSTOMER_CD.Value = value;
                else
                    m_strCUSTOMER_CD = value;
            }
        }
        public NZString CUSTOMER_NAME {
            get { return m_strCUSTOMER_NAME; }
            set {
                if (value == null)
                    m_strCUSTOMER_NAME.Value = value;
                else
                    m_strCUSTOMER_NAME = value;
            }
        }
        #endregion
    }
}
