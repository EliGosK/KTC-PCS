using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Data;
using EVOFramework;
using System.Data;
using Rubik.DTO;

namespace Rubik.UIDataModel {
    public class PackingEntryUIDM : IUIDataModel 
    {
        public enum eColView 
        {
            TRANS_ID,
            LOT_NO,
            EXTERNAL_LOT_NO,
            QTY,
        }
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

        

        private DataTable m_DATA_VIEW = null;

        #region Constructor

        public PackingEntryUIDM() 
        {
            m_DATA_VIEW = new DataTable();
            m_DATA_VIEW.Columns.Add("TRANS_ID");
            m_DATA_VIEW.Columns.Add("LOT_NO");
            m_DATA_VIEW.Columns.Add("EXTERNAL_LOT_NO");
            m_DATA_VIEW.Columns.Add("QTY");

            for (int i = 0; i < 5; i++)
            {
                DataRow dr = m_DATA_VIEW.NewRow();
                m_DATA_VIEW.Rows.Add(dr);
            }
        }

        #endregion

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
        public DataTable DATA_VIEW {
            get { return m_DATA_VIEW; }
            set { m_DATA_VIEW = value; }
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
