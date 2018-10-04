using System;
using EVOFramework.Data;
using EVOFramework;
using EVOFramework.Database;

namespace Rubik.DTO
{
    [Serializable()]
    [DataTransferObject("INV_ONHAND_VIEW_DTO", typeof(eColumns))]
    public class InventoryOnhandInquiryViewDTO : AbstractDTO
    {
        public enum eColumns
        {
            YEAR_MONTH,
            LOCATION,
            ITEM_CODE,
            SHORT_NAME,
            CUSTOMER_CD,
            PACK_NO,
            LOT_NO,
            EXTERNAL_LOT_NO,
            ONHAND_QTY,
            PREVIOUS_BAL,
            TOTAL_IN_QTY,
            TOTAL_OUT_QTY,
            TOTAL_ADJ_QTY,
            LAST_RECEIVE_DATE,
            QUERY_TYPE,
        }
        private NZString m_YEAR_MONTH = new NZString();
        private NZString m_LOCATION = new NZString();
        private NZString m_ITEM_CODE = new NZString();
        private NZString m_SHORT_NAME = new NZString();
        private NZString m_CUSTOMER_CD = new NZString();
        private NZString m_PACK_NO = new NZString();
        private NZString m_LOT_NO = new NZString();
        private NZString m_EXTERNAL_LOT_NO = new NZString();
        private NZDecimal m_ONHAND_QTY = new NZDecimal();
        private NZDecimal m_PREVIOUS_BAL = new NZDecimal();
        private NZDecimal m_TOTAL_IN_QTY = new NZDecimal();
        private NZDecimal m_TOTAL_OUT_QTY = new NZDecimal();
        private NZDecimal m_TOTAL_ADJ_QTY = new NZDecimal();
        private NZDateTime m_LAST_RECEIVE_DATE = new NZDateTime();
        private NZInt m_QUERY_TYPE = new NZInt();

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "YEAR_MONTH", 0, 0, 6)]
        public NZString YEAR_MONTH
        {
            get { return m_YEAR_MONTH; }
            set { m_YEAR_MONTH = value; }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "LOCATION", 0, 0, 20)]
        public NZString LOCATION
        {
            get { return m_LOCATION; }
            set { m_LOCATION = value; }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ITEM_CD", 0, 0, 20)]
        public NZString ITEM_CODE
        {
            get { return m_ITEM_CODE; }
            set { m_ITEM_CODE = value; }
        }


        public NZString CUSTOMER_CD
        {
            get { return m_CUSTOMER_CD; }
            set { m_CUSTOMER_CD = value; }
        }

        public NZString SHORT_NAME
        {
            get { return m_SHORT_NAME; }
            set { m_SHORT_NAME = value; }
        }

        public NZString PACK_NO
        {
            get { return m_PACK_NO; }
            set { m_PACK_NO = value; }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "LOT_NO", 0, 0, 30)]
        public NZString LOT_NO
        {
            get { return m_LOT_NO; }
            set { m_LOT_NO = value; }
        }

        public NZString EXTERNAL_LOT_NO
        {
            get { return m_EXTERNAL_LOT_NO; }
            set { m_EXTERNAL_LOT_NO = value; }
        }

        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "ONHAND_QTY", 18, 0, 9)]
        public NZDecimal ONHAND_QTY
        {
            get { return m_ONHAND_QTY; }
            set { m_ONHAND_QTY = value; }
        }

        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "PREVIOUS_BAL", 18, 0, 9)]
        public NZDecimal PREVIOUS_BAL
        {
            get { return m_PREVIOUS_BAL; }
            set { m_PREVIOUS_BAL = value; }
        }

        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "TOTAL_IN_QTY", 18, 0, 9)]
        public NZDecimal TOTAL_IN_QTY
        {
            get { return m_TOTAL_IN_QTY; }
            set { m_TOTAL_IN_QTY = value; }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "TOTAL_OUT_QTY", 18, 0, 9)]
        public NZDecimal TOTAL_OUT_QTY
        {
            get { return m_TOTAL_OUT_QTY; }
            set { m_TOTAL_OUT_QTY = value; }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "TOTAL_ADJ_QTY", 18, 0, 9)]
        public NZDecimal TOTAL_ADJ_QTY
        {
            get { return m_TOTAL_ADJ_QTY; }
            set { m_TOTAL_ADJ_QTY = value; }
        }

        public NZDateTime LAST_RECEIVE_DATE
        {
            get { return m_LAST_RECEIVE_DATE; }
            set { m_LAST_RECEIVE_DATE = value; }
        }


        public NZInt QUERY_TYPE
        {
            get { return m_QUERY_TYPE; }
            set { QUERY_TYPE = value; }
        }



    }
}
