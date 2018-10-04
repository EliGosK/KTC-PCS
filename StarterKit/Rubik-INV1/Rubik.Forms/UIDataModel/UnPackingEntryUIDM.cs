using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Data;
using EVOFramework;
using System.Data;
using Rubik.DTO;

namespace Rubik.UIDataModel {
    public class UnPackingEntryUIDM : IUIDataModel 
    {
        public enum eColView 
        {
            ITEM_CD,
            LOC_CD,
            PACK_NO,
            FG_NO,
            LOT_NO,
            EXTERNAL_LOT_NO,
            ONHAND_QTY,
        }

        private NZString m_ITEM_CD = new NZString();
        private NZString m_LOC_CD = new NZString();
        private NZDateTime m_UNPACKING_DATE = new NZDateTime();
        private NZString m_SHIFT_CLS = new NZString();
        private NZString m_MASTER_NO = new NZString();
        private NZString m_PART_NO = new NZString();
        private NZString m_CUSTOMER_NAME = new NZString();
        private NZString m_UNPACK_NO = new NZString();
        private NZString m_FG_NO = new NZString();
        private NZString m_LOT_NO = new NZString();
        private NZString m_EXTERNAL_LOT_NO = new NZString();
        private NZString m_PERSON_IN_CHARGE = new NZString();
        private NZDecimal m_TOTAL_QTY = new NZDecimal();
        private NZString m_REMARK = new NZString();
        private NZString m_SOURCE_LOC = new NZString();
        private NZString m_DEST_LOC = new NZString();
        private NZDecimal m_ONHAND_QTY = new NZDecimal();


        private DataTable m_DATA_VIEW = null;

        #region Constructor



        #endregion

        public NZString ITEM_CD
        {
            get { return m_ITEM_CD; }
            set { m_ITEM_CD = value; }
        }
        public NZString LOC_CD
        {
            get { return m_LOC_CD; }
            set { m_LOC_CD = value; }
        }
        public NZString UNPACK_NO {
            get { return m_UNPACK_NO; }
            set { m_UNPACK_NO = value; }
        }
        public NZString FG_NO
        {
            get { return m_FG_NO; }
            set { m_FG_NO = value; }
        }
        public NZString LOT_NO
        {
            get { return m_LOT_NO; }
            set { m_LOT_NO = value; }
        }
        public NZDateTime UNPACKING_DATE {
            get { return m_UNPACKING_DATE; }
            set { m_UNPACKING_DATE = value; }
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
        public NZString EXTERNAL_LOT_NO
        {
            get { return m_EXTERNAL_LOT_NO; }
            set { m_EXTERNAL_LOT_NO = value; }
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
        public NZDecimal ONHAND_QTY
        {
            get { return m_ONHAND_QTY; }
            set { m_ONHAND_QTY = value; }
        }
    }
}
