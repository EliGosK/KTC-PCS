using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using EVOFramework.Data;

namespace Rubik.DTO 
{    
    public class ProductionReportEntryDTO : AbstractDTO 
    {
        #region " Enums Columns "
        public enum eColumns 
        {
            TRANS_ID,
            REF_NO,
            PRODUCTION_REPORT_NO,
            PRODUCTION_REPORT_DATE,
            SHIFT,
            MASTER_NO,
            PART_NO,
            CUSTOMER_NAME,
            PROCESS,
            MACHINE_NO,
            REWORK,
            LOT_NO,
            CUST_LOT_NO,
            SUPPLIER,
            WEIGHT,
            QTY,
            PERSON_IN_CHARGE,
            REMARK,
            NG_WEIGHT,
            NG_QTY
        };
        #endregion


        private NZString m_TRANS_ID = new NZString();
        private NZString m_REF_NO = new NZString();
        private NZString m_PRODUCTION_REPORT_NO = new NZString();
        private NZDateTime m_PRODUCTION_REPORT_DATE = new NZDateTime();
        private NZString m_SHIFT = new NZString();
        private NZString m_MASTER_NO = new NZString();
        private NZString m_PART_NO = new NZString();
        private NZString m_CUSTOMER_NAME = new NZString();
        private NZString m_PROCESS = new NZString();
        private NZString m_MACHINE_NO = new NZString();
        private NZString m_REWORK = new NZString();
        private NZString m_LOT_NO = new NZString();
        private NZString m_CUST_LOT_NO = new NZString();
        private NZString m_SUPPLIER = new NZString();
        private NZDecimal m_WEIGHT = new NZDecimal();
        private NZDecimal m_QTY = new NZDecimal();
        private NZString m_PERSON_IN_CHARGE = new NZString();
        private NZString m_REMARK = new NZString();
        private NZDecimal m_NG_WEIGHT = new NZDecimal();
        private NZDecimal m_NG_QTY = new NZDecimal();

        public NZString TRANS_ID {
            get { return m_TRANS_ID; }
            set { m_TRANS_ID = value; }
        }
        public NZString REF_NO {
            get { return m_REF_NO; }
            set { m_REF_NO = value; }
        }
        public NZString PRODUCTION_REPORT_NO {
            get { return m_PRODUCTION_REPORT_NO; }
            set { m_PRODUCTION_REPORT_NO = value; }
        }
        public NZDateTime PRODUCTION_REPORT_DATE {
            get { return m_PRODUCTION_REPORT_DATE; }
            set { m_PRODUCTION_REPORT_DATE = value; }
        }
        public NZString SHIFT {
            get { return m_SHIFT; }
            set { m_SHIFT = value; }
        }
        public NZString MASTER_NO {
            get { return m_MASTER_NO; }
            set { m_MASTER_NO = value; }
        }
        public NZString PART_NO {
            get { return m_PART_NO; }
            set { m_PART_NO = value; }
        }
        public NZString CUSTOMER_NAME {
            get { return m_CUSTOMER_NAME; }
            set { m_CUSTOMER_NAME = value; }
        }
        public NZString PROCESS {
            get { return m_PROCESS; }
            set { m_PROCESS = value; }
        }
        public NZString MACHINE_NO {
            get { return m_MACHINE_NO; }
            set { m_MACHINE_NO = value; }
        }
        public NZString REWORK {
            get {
                return m_REWORK;
            }
            set {
                m_REWORK = value;
            }
        }
        public NZString LOT_NO {
            get { return m_LOT_NO; }
            set { m_LOT_NO = value; }
        }
        public NZString CUST_LOT_NO {
            get { return m_CUST_LOT_NO; }
            set { m_CUST_LOT_NO = value; }
        }
        public NZString SUPPLIER {
            get { return m_SUPPLIER; }
            set { m_SUPPLIER = value; }
        }
        public NZDecimal WEIGHT {
            get { return m_WEIGHT; }
            set { m_WEIGHT = value; }
        }
        public NZDecimal QTY {
            get { return m_QTY; }
            set { m_QTY = value; }
        }
        public NZString PERSON_IN_CHARGE {
            get { return m_PERSON_IN_CHARGE; }
            set { m_PERSON_IN_CHARGE = value; }
        }
        public NZString REMARK {
            get { return m_REMARK; }
            set { m_REMARK = value; }
        }
        public NZDecimal NG_QTY {
            get { return m_NG_QTY; }
            set { m_NG_QTY = value; }
        }
        public NZDecimal NG_WEIGHT {
            get { return m_NG_WEIGHT; }
            set { m_NG_WEIGHT = value; }
        }
    }
}
