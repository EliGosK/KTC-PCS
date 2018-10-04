using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;

namespace Rubik.DTO {
    public class ItemDescriptionDTO 
    {
        public enum eColumns 
        {
            MasterNo,
            PartNo,
            CustomerCode,
            CustomerName
        }

        private NZString m_strMASTER_NO = new NZString();
        private NZString m_strPART_NO = new NZString();
        private NZString m_strCUSTOMER_CD = new NZString();
        private NZString m_strCUSTOMER_NAME = new NZString();

        public NZString MASTER_NO {
            get { return m_strMASTER_NO; }
            set {
                if (value == null)
                    m_strMASTER_NO.Value = value;
                else
                    m_strMASTER_NO = value;
            }
        }
        public NZString PART_NO {
            get { return m_strPART_NO; }
            set {
                if (value == null)
                    m_strPART_NO.Value = value;
                else
                    m_strPART_NO = value;
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

    }
}
