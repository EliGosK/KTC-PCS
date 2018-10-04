using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using EVOFramework.Data;

namespace Rubik.UIDataModel
{
    class DealingUIDM : IUIDataModel
    {
        #region " Enums Columns "
        public enum eColumns {
            CRT_BY,
            CRT_DATE,
            CRT_MACHINE,
            UPD_BY,
            UPD_DATE,
            UPD_MACHINE,
            LOC_CD,
            LOC_DESC,
            LOC_CLS,
            TERM_OF_PAYMENT,
            INVOICE_PATTERN,
            ADDRESS1,
            TEL1,
            FAX1,
            EMAIL1,
            CONTACT_PERSON1,
            REMARK1,
            ADDRESS2,
            TEL2,
            FAX2,
            EMAIL2,
            CONTACT_PERSON2,
            REMARK2,
            ADDRESS3,
            TEL3,
            FAX3,
            EMAIL3,
            CONTACT_PERSON3,
            REMARK3,
            ALLOW_NEGATIVE,
            OLD_DATA
        };
        #endregion

        #region " Variables "
        private NZString m_strCRT_BY = new NZString();
        private NZDateTime m_dtCRT_DATE = new NZDateTime();
        private NZString m_strCRT_MACHINE = new NZString();
        private NZString m_strUPD_BY = new NZString();
        private NZDateTime m_dtUPD_DATE = new NZDateTime();
        private NZString m_strUPD_MACHINE = new NZString();
        private NZString m_strLOC_CD = new NZString();
        private NZString m_strLOC_DESC = new NZString();
        private NZString m_strLOC_CLS = new NZString();
        private NZString m_strTERM_OF_PAYMENT = new NZString();
        private NZString m_strINVOICE_PATTERN = new NZString();
        private NZString m_strADDRESS1 = new NZString();
        private NZString m_strTEL1 = new NZString();
        private NZString m_strFAX1 = new NZString();
        private NZString m_strEMAIL1 = new NZString();
        private NZString m_strCONTACT_PERSON1 = new NZString();
        private NZString m_strREMARK1 = new NZString();
        private NZString m_strADDRESS2 = new NZString();
        private NZString m_strTEL2 = new NZString();
        private NZString m_strFAX2 = new NZString();
        private NZString m_strEMAIL2 = new NZString();
        private NZString m_strCONTACT_PERSON2 = new NZString();
        private NZString m_strREMARK2 = new NZString();
        private NZString m_strADDRESS3 = new NZString();
        private NZString m_strTEL3 = new NZString();
        private NZString m_strFAX3 = new NZString();
        private NZString m_strEMAIL3 = new NZString();
        private NZString m_strCONTACT_PERSON3 = new NZString();
        private NZString m_strREMARK3 = new NZString();
        private NZString m_strALLOW_NEGATIVE = new NZString();
        private NZInt m_iOLD_DATA = new NZInt();
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
        public NZString LOC_CD {
            get { return m_strLOC_CD; }
            set {
                if (value == null)
                    m_strLOC_CD.Value = value;
                else
                    m_strLOC_CD = value;
            }
        }
        public NZString LOC_DESC {
            get { return m_strLOC_DESC; }
            set {
                if (value == null)
                    m_strLOC_DESC.Value = value;
                else
                    m_strLOC_DESC = value;
            }
        }
        public NZString LOC_CLS {
            get { return m_strLOC_CLS; }
            set {
                if (value == null)
                    m_strLOC_CLS.Value = value;
                else
                    m_strLOC_CLS = value;
            }
        }
        public NZString TERM_OF_PAYMENT
        {
            get { return m_strTERM_OF_PAYMENT; }
            set
            {
                if (value == null)
                    m_strTERM_OF_PAYMENT.Value = value;
                else
                    m_strTERM_OF_PAYMENT = value;
            }
        }
        public NZString INVOICE_PATTERN
        {
            get { return m_strINVOICE_PATTERN; }
            set
            {
                if (value == null)
                    m_strINVOICE_PATTERN.Value = value;
                else
                    m_strINVOICE_PATTERN = value;
            }
        }
        public NZString ADDRESS1 {
            get { return m_strADDRESS1; }
            set {
                if (value == null)
                    m_strADDRESS1.Value = value;
                else
                    m_strADDRESS1 = value;
            }
        }

        public NZString TEL1 {
            get { return m_strTEL1; }
            set {
                if (value == null)
                    m_strTEL1.Value = value;
                else
                    m_strTEL1 = value;
            }
        }
        public NZString FAX1 {
            get { return m_strFAX1; }
            set {
                if (value == null)
                    m_strFAX1.Value = value;
                else
                    m_strFAX1 = value;
            }
        }
        public NZString EMAIL1 {
            get { return m_strEMAIL1; }
            set {
                if (value == null)
                    m_strEMAIL1.Value = value;
                else
                    m_strEMAIL1 = value;
            }
        }
        public NZString CONTACT_PERSON1 {
            get { return m_strCONTACT_PERSON1; }
            set {
                if (value == null)
                    m_strCONTACT_PERSON1.Value = value;
                else
                    m_strCONTACT_PERSON1 = value;
            }
        }
        public NZString REMARK1 {
            get { return m_strREMARK1; }
            set {
                if (value == null)
                    m_strREMARK1.Value = value;
                else
                    m_strREMARK1 = value;
            }
        }
        public NZString ADDRESS2 {
            get { return m_strADDRESS2; }
            set {
                if (value == null)
                    m_strADDRESS2.Value = value;
                else
                    m_strADDRESS2 = value;
            }
        }
        public NZString TEL2 {
            get { return m_strTEL2; }
            set {
                if (value == null)
                    m_strTEL2.Value = value;
                else
                    m_strTEL2 = value;
            }
        }
        public NZString FAX2 {
            get { return m_strFAX2; }
            set {
                if (value == null)
                    m_strFAX2.Value = value;
                else
                    m_strFAX2 = value;
            }
        }
        public NZString EMAIL2 {
            get { return m_strEMAIL2; }
            set {
                if (value == null)
                    m_strEMAIL2.Value = value;
                else
                    m_strEMAIL2 = value;
            }
        }
        public NZString CONTACT_PERSON2 {
            get { return m_strCONTACT_PERSON2; }
            set {
                if (value == null)
                    m_strCONTACT_PERSON2.Value = value;
                else
                    m_strCONTACT_PERSON2 = value;
            }
        }
        public NZString REMARK2 {
            get { return m_strREMARK2; }
            set {
                if (value == null)
                    m_strREMARK2.Value = value;
                else
                    m_strREMARK2 = value;
            }
        }
        public NZString ADDRESS3 {
            get { return m_strADDRESS3; }
            set {
                if (value == null)
                    m_strADDRESS3.Value = value;
                else
                    m_strADDRESS3 = value;
            }
        }
        public NZString TEL3 {
            get { return m_strTEL3; }
            set {
                if (value == null)
                    m_strTEL3.Value = value;
                else
                    m_strTEL3 = value;
            }
        }
        public NZString FAX3 {
            get { return m_strFAX3; }
            set {
                if (value == null)
                    m_strFAX3.Value = value;
                else
                    m_strFAX3 = value;
            }
        }
        public NZString EMAIL3 {
            get { return m_strEMAIL3; }
            set {
                if (value == null)
                    m_strEMAIL3.Value = value;
                else
                    m_strEMAIL3 = value;
            }
        }
        public NZString CONTACT_PERSON3 {
            get { return m_strCONTACT_PERSON3; }
            set {
                if (value == null)
                    m_strCONTACT_PERSON3.Value = value;
                else
                    m_strCONTACT_PERSON3 = value;
            }
        }
        public NZString REMARK3 {
            get { return m_strREMARK3; }
            set {
                if (value == null)
                    m_strREMARK3.Value = value;
                else
                    m_strREMARK3 = value;
            }
        }
        public NZString ALLOW_NEGATIVE {
            get { return m_strALLOW_NEGATIVE; }
            set {
                if (value == null)
                    m_strALLOW_NEGATIVE.Value = value;
                else
                    m_strALLOW_NEGATIVE = value;
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

        #endregion


    }
}
