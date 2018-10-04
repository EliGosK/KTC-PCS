
using System.Data;
using EVOFramework;
using EVOFramework.Data;

namespace Rubik.UIDataModel
{
    public class ShipmentEntryUIDM : IUIDataModel
    {
        public NZString m_strCRT_BY = new NZString();
        public NZDateTime m_dtCRT_DATE = new NZDateTime();
        public NZString m_strCRT_MACHINE = new NZString();
        public NZString m_strUPD_BY = new NZString();
        public NZDateTime m_dtUPD_DATE = new NZDateTime();
        public NZString m_strUPD_MACHINE = new NZString();

        public NZString m_TRANS_ID = new NZString();
        public NZString m_REF_NO = new NZString();
        public NZString m_SLIP_NO = new NZString();
        public NZString m_REF_SLIP_NO = new NZString();
        public NZString m_GROUP_TRANS_ID = new NZString();
        public NZString m_ITEM_CD = new NZString();
        public NZString m_LOC_CD = new NZString();
        public NZString m_PACK_NO = new NZString();
        public NZString m_FG_NO = new NZString();
        public NZString m_LOT_NO = new NZString();
        public NZString m_EXTERNAL_LOT_NO = new NZString();
        public NZDateTime m_TRANS_DATE = new NZDateTime();
        public NZString m_TRANS_CLS = new NZString();
        public NZString m_IN_OUT_CLS = new NZString();
        public NZDecimal m_QTY = new NZDecimal();
        public NZString m_REMARK = new NZString();
        public NZString m_DEALING_NO = new NZString();
        public NZString m_SCREEN_TYPE = new NZString();
        public NZInt m_EFFECT_STOCK = new NZInt();
        public NZString m_CURRENCY = new NZString();
        public NZString m_CUSTOMER_CD = new NZString();
        public NZString m_LOC_DESC = new NZString();
        public NZString m_SHORT_NAME = new NZString();
        public NZString m_PO_NO = new NZString();
        public NZString m_ORDER_NO = new NZString();
        public NZDecimal m_SHIP_QTY = new NZDecimal();
        public NZDecimal m_LOT_QTY = new NZDecimal();
        public NZString m_REF_SLIP_NO2 = new NZString();
        //NZString m_PART_NO = new NZString();
        //NZString m_PART_NAME = new NZString();
        
        //NZString m_INVOICE_NO = new NZString();
        
        //NZDecimal m_ONHAND_QTY = new NZDecimal();
        
        
        
        
        
        DataTable m_dtView = null;
        

        public ShipmentEntryUIDM()
        {
            DATA_VIEW = new DataTable();

            DATA_VIEW.Columns.Add("CRT_BY");
            DATA_VIEW.Columns.Add("CRT_DATE");
            DATA_VIEW.Columns.Add("CRT_MACHINE");
            DATA_VIEW.Columns.Add("UPD_BY");
            DATA_VIEW.Columns.Add("UPD_DATE");
            DATA_VIEW.Columns.Add("UPD_MACHINE");
            
            DATA_VIEW.Columns.Add("TRANS_ID");
            DATA_VIEW.Columns.Add("REF_NO");
            DATA_VIEW.Columns.Add("SLIP_NO");
            DATA_VIEW.Columns.Add("REF_SLIP_NO");
            DATA_VIEW.Columns.Add("GROUP_TRANS_ID");
            DATA_VIEW.Columns.Add("ITEM_CD");
            DATA_VIEW.Columns.Add("LOC_CD");
            DATA_VIEW.Columns.Add("PACK_NO");
            DATA_VIEW.Columns.Add("FG_NO");
            DATA_VIEW.Columns.Add("LOT_NO");
            DATA_VIEW.Columns.Add("EXTERNAL_LOT_NO");
            DATA_VIEW.Columns.Add("TRANS_DATE");
            DATA_VIEW.Columns.Add("TRANS_CLS");
            DATA_VIEW.Columns.Add("IN_OUT_CLS");
            DATA_VIEW.Columns.Add("QTY");
            DATA_VIEW.Columns.Add("REMARK");
            DATA_VIEW.Columns.Add("DEALING_NO");
            DATA_VIEW.Columns.Add("SCREEN_TYPE");
            DATA_VIEW.Columns.Add("EFFECT_STOCK");
            DATA_VIEW.Columns.Add("CURRENCY");
            DATA_VIEW.Columns.Add("CUSTOMER_CD");
            DATA_VIEW.Columns.Add("LOC_DESC");
            DATA_VIEW.Columns.Add("SHORT_NAME");
            DATA_VIEW.Columns.Add("PO_NO");
            DATA_VIEW.Columns.Add("ORDER_NO");
            DATA_VIEW.Columns.Add("SHIP_QTY");
            DATA_VIEW.Columns.Add("LOT_QTY");
            DATA_VIEW.Columns.Add("REF_SLIP_NO2");
        }

        public NZString CRT_BY
        {
            get { return m_strCRT_BY; }
            set
            {
                if (value == null)
                    m_strCRT_BY.Value = value;
                else
                    m_strCRT_BY = value;
            }
        }
        public NZDateTime CRT_DATE
        {
            get { return m_dtCRT_DATE; }
            set
            {
                if (value == null)
                    m_dtCRT_DATE.Value = value;
                else
                    m_dtCRT_DATE = value;
            }
        }
        public NZString CRT_MACHINE
        {
            get { return m_strCRT_MACHINE; }
            set
            {
                if (value == null)
                    m_strCRT_MACHINE.Value = value;
                else
                    m_strCRT_MACHINE = value;
            }
        }
        public NZString UPD_BY
        {
            get { return m_strUPD_BY; }
            set
            {
                if (value == null)
                    m_strUPD_BY.Value = value;
                else
                    m_strUPD_BY = value;
            }
        }
        public NZDateTime UPD_DATE
        {
            get { return m_dtUPD_DATE; }
            set
            {
                if (value == null)
                    m_dtUPD_DATE.Value = value;
                else
                    m_dtUPD_DATE = value;
            }
        }
        public NZString UPD_MACHINE
        {
            get { return m_strUPD_MACHINE; }
            set
            {
                if (value == null)
                    m_strUPD_MACHINE.Value = value;
                else
                    m_strUPD_MACHINE = value;
            }
        }

        public NZString TRANS_ID { get { return m_TRANS_ID; } set { m_TRANS_ID = value; } }
        public NZString REF_NO { get { return m_REF_NO; } set { m_REF_NO = value; } }
        public NZString SLIP_NO { get { return m_SLIP_NO; } set { m_SLIP_NO = value; } }
        public NZString REF_SLIP_NO { get { return m_REF_SLIP_NO; } set { m_REF_SLIP_NO = value; } }
        public NZString GROUP_TRANS_ID { get { return m_GROUP_TRANS_ID; } set { m_GROUP_TRANS_ID = value; } }
        public NZString ITEM_CD { get { return m_ITEM_CD; } set { m_ITEM_CD = value; } }
        public NZString LOC_CD { get { return m_LOC_CD; } set { m_LOC_CD = value; } }
        public NZString PACK_NO { get { return m_PACK_NO; } set { m_PACK_NO = value; } }
        public NZString FG_NO { get { return m_FG_NO; } set { m_FG_NO = value; } }
        public NZString LOT_NO { get { return m_LOT_NO; } set { m_LOT_NO = value; } }
        public NZString EXTERNAL_LOT_NO { get { return m_EXTERNAL_LOT_NO; } set { m_EXTERNAL_LOT_NO = value; } }
        public NZDateTime TRANS_DATE { get { return m_TRANS_DATE; } set { m_TRANS_DATE = value; } }
        public NZString TRANS_CLS { get { return m_TRANS_CLS; } set { m_TRANS_CLS = value; } }
        public NZString IN_OUT_CLS { get { return m_IN_OUT_CLS; } set { m_IN_OUT_CLS = value; } }
        public NZDecimal QTY { get { return m_QTY; } set { m_QTY = value; } }
        public NZString REMARK { get { return m_REMARK; } set { m_REMARK = value; } }
        public NZString DEALING_NO { get { return m_DEALING_NO; } set { m_DEALING_NO = value; } }
        public NZString SCREEN_TYPE { get { return m_SCREEN_TYPE; } set { m_SCREEN_TYPE = value; } }
        public NZInt EFFECT_STOCK { get { return m_EFFECT_STOCK; } set { m_EFFECT_STOCK = value; } }
        public NZString CURRENCY { get { return m_CURRENCY; } set { m_CURRENCY = value; } }
        public NZString CUSTOMER_CD { get { return m_CUSTOMER_CD; } set { m_CUSTOMER_CD = value; } }
        public NZString LOC_DESC { get { return m_LOC_DESC; } set { m_LOC_DESC = value; } }
        public NZString SHORT_NAME { get { return m_SHORT_NAME; } set { m_SHORT_NAME = value; } }
        public NZString PO_ON { get { return m_PO_NO; } set { m_PO_NO = value; } }
        public NZString ORDER_NO { get { return m_ORDER_NO; } set { m_ORDER_NO = value; } }
        public NZDecimal SHIP_QTY { get { return m_SHIP_QTY; } set { m_SHIP_QTY = value; } }
        public NZDecimal LOT_QTY { get { return m_LOT_QTY; } set { m_LOT_QTY = value; } }
        public NZString REF_SLIP_NO2 { get { return m_REF_SLIP_NO2; } set { m_REF_SLIP_NO2 = value; } }
        //public NZString INVOICE_NO { get { return m_INVOICE_NO; } set { m_INVOICE_NO = value; } }
        //public NZString PART_NO { get { return m_PART_NO; } set { m_PART_NO = value; } }
        //public NZString PART_NAME { get { return m_PART_NAME; } set { m_PART_NAME = value; } }
        
        
        //public NZDecimal ONHAND_QTY { get { return m_ONHAND_QTY; } set { m_ONHAND_QTY = value; } }

        public DataTable DATA_VIEW
        {
            get { return m_dtView; }
            set { m_dtView = value; }
        }
    }
}
