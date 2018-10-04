using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Data;
using EVOFramework;

namespace Rubik.UIDataModel 
{
    public class MovePartUIDM : IUIDataModel 
    {
        private NZString m_strTRANS_ID_FROM = new NZString();
        private NZString m_strTRANS_ID_TO = new NZString();
        private NZString m_strMOVE_NO = new NZString();
        private NZDateTime m_dtmMOVE_DATE = new NZDateTime();
        private NZString m_strSHIFT_CLS = new NZString();
        private NZString m_strSHIFT_CLS_NAME = new NZString();
        private NZString m_strMASTER_NO = new NZString();
        private NZString m_strPART_NO = new NZString();
        private NZString m_strCUSTOMER_CD = new NZString();
        private NZString m_strCUSTOMER_NAME = new NZString();
        private NZString m_strFROM_PROCESS = new NZString();
        private NZString m_strFROM_PROCESS_NAME = new NZString();
        private NZString m_strTO_PROCESS = new NZString();
        private NZString m_strTO_PROCESS_NAME = new NZString();
        private NZDecimal m_decMOVE_QTY = new NZDecimal();
        private NZString m_strLOT_NO = new NZString();
        private NZString m_strREASON = new NZString();
        private NZString m_strREASON_NAME = new NZString();
        private NZString m_strREMARK = new NZString();
        private NZDecimal m_decWEIGHT = new NZDecimal();

        public NZString TRANS_ID_FROM {
            get { return m_strTRANS_ID_FROM; }
            set { m_strTRANS_ID_FROM = value; }
        }
        public NZString TRANS_ID_TO {
            get { return m_strTRANS_ID_TO; }
            set { m_strTRANS_ID_TO = value; }
        }
        public NZString MOVE_NO {
            get { return m_strMOVE_NO; }
            set { m_strMOVE_NO = value; }
        }
        public NZDateTime MOVE_DATE {
            get { return m_dtmMOVE_DATE; }
            set { m_dtmMOVE_DATE = value; }
        }
        public NZString SHIFT_CLS {
            get { return m_strSHIFT_CLS; }
            set { m_strSHIFT_CLS = value; }
        }
        public NZString SHIFT_CLS_NAME {
            get { return m_strSHIFT_CLS_NAME; }
            set { m_strSHIFT_CLS_NAME = value; }
        }
        public NZString MASTER_NO {
            get { return m_strMASTER_NO; }
            set { m_strMASTER_NO = value; }
        }
        public NZString PART_NO {
            get { return m_strPART_NO; }
            set { m_strPART_NO = value; }
        }
        public NZString CUSTOMER_CD {
            get { return m_strCUSTOMER_CD; }
            set { m_strCUSTOMER_CD = value; }
        }
        public NZString CUSTOMER_NAME {
            get { return m_strCUSTOMER_NAME; }
            set { m_strCUSTOMER_NAME = value; }
        }
        public NZString FROM_PROCESS {
            get { return m_strFROM_PROCESS; }
            set { m_strFROM_PROCESS = value; }
        }
        public NZString FROM_PROCESS_NAME {
            get { return m_strFROM_PROCESS_NAME; }
            set { m_strFROM_PROCESS_NAME = value; }
        }
        public NZString TO_PROCESS {
            get { return m_strTO_PROCESS; }
            set { m_strTO_PROCESS = value; }
        }
        public NZString TO_PROCESS_NAME {
            get { return m_strTO_PROCESS_NAME; }
            set { m_strTO_PROCESS_NAME = value; }
        }
        public NZDecimal MOVE_QTY {
            get { return m_decMOVE_QTY; }
            set { m_decMOVE_QTY = value; }
        }
        public NZString LOT_NO {
            get { return m_strLOT_NO; }
            set { m_strLOT_NO = value; }
        }
        public NZString REASON {
            get { return m_strREASON; }
            set { m_strREASON = value; }
        }
        public NZString REASON_NAME {
            get { return m_strREASON_NAME; }
            set { m_strREASON_NAME = value; }
        }
        public NZString REMARK {
            get { return m_strREMARK; }
            set { m_strREMARK = value; }
        }
        public NZDecimal WEIGHT {
            get { return m_decWEIGHT; }
            set { m_decWEIGHT = value; }
        }
    }
}
