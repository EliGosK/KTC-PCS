using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using EVOFramework.Data;

namespace Rubik.DTO {
    public class PackingEntryDTO : AbstractDTO 
    {
        //public enum eColumns 
        //{
        //    TRANS_ID,
        //    PACKING_NO,
        //    PACKING_DATE,
        //    SHIFT_CLS,
        //    MASTER_NO,
        //    PART_NO,
        //    CUSTOMER_NAME,
        //    PACK_NO,
        //    PERSON_IN_CHARGE,
        //    TOTAL_QTY,
        //    REMARK,
        //    SOURCE_LOC,
        //    DEST_LOC,
        //};

        private NZString m_TRANS_ID = new NZString();
        private NZString m_PACKING_NO = new NZString();
        private NZDateTime m_PACKING_DATE = new NZDateTime();
        private NZString m_SHIFT_CLS = new NZString();
        private NZString m_MASTER_NO = new NZString();
        private NZString m_PART_NO = new NZString();
        private NZString m_CUSTOMER_NAME = new NZString();
        private NZString m_PACK_NO = new NZString();
        private NZString m_PERSON_IN_CHARGE = new NZString();
        private NZDecimal m_TOTAL_QTY = new NZDecimal();
        private NZString m_REMARK = new NZString();
        private NZString m_SOURCE_LOC = new NZString();
        private NZString m_DEST_LOC = new NZString();
        private NZString m_FG_NO = new NZString();

        public NZString TRANS_ID {
            get { return m_TRANS_ID; }
            set { m_TRANS_ID = value; }
        }
        public NZString PACKING_NO {
            get { return m_PACKING_NO; }
            set { m_PACKING_NO = value; }
        }
        public NZDateTime PACKING_DATE {
            get { return m_PACKING_DATE; }
            set { m_PACKING_DATE = value; }
        }
        public NZString SHIFT_CLS {
            get { return m_SHIFT_CLS; }
            set { m_SHIFT_CLS = value; }
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
        public NZString PACK_NO {
            get { return m_PACK_NO; }
            set { m_PACK_NO = value; }
        }
        public NZString PERSON_IN_CHARGE {
            get { return m_PERSON_IN_CHARGE; }
            set { m_PERSON_IN_CHARGE = value; }
        }
        public NZDecimal TOTAL_QTY {
            get { return m_TOTAL_QTY; }
            set { m_TOTAL_QTY = value; }
        }
        public NZString REMARK {
            get { return m_REMARK; }
            set { m_REMARK = value; }
        }        
        public NZString SOURCE_LOC {
            get { return m_SOURCE_LOC; }
            set { m_SOURCE_LOC = value; }
        }
        public NZString DEST_LOC {
            get { return m_DEST_LOC; }
            set { m_DEST_LOC = value; }
        }
        public NZString FG_NO
        {
            get { return m_FG_NO; }
            set { m_FG_NO = value; }
        }
    }
}
