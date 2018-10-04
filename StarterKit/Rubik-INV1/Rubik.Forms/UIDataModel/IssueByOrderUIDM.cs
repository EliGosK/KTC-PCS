using EVOFramework;
using EVOFramework.Data;
using System.Data;


namespace Rubik.UIDataModel
{
    public class IssueByOrderUIDM : IUIDataModel
    {

        public IssueByOrderUIDM()
        {
            DATA_VIEW = new DataTable();
            DATA_VIEW.Columns.Add("ITEM_CODE");
            DATA_VIEW.Columns.Add("ITEM_DESC");
            DATA_VIEW.Columns.Add("LOT_NO");
            DATA_VIEW.Columns.Add("REQUEST_QTY");
            DATA_VIEW.Columns.Add("QTY ISSUE_QTY");
            DATA_VIEW.Columns.Add("ONHAND_QTY");
            DATA_VIEW.Columns.Add("TRANS_ID");
            DATA_VIEW.Columns.Add("REF_NO");
        }

        NZString m_SLIP_NO = new NZString();
        NZDateTime m_ISSUE_DATE = new NZDateTime();
        NZString m_TRANS_CLS = new NZString();
        NZString m_ITEM_CD = new NZString();
        NZString m_ITEM_DESC = new NZString();
        NZString m_FROM_LOC_CD = new NZString();
        NZString m_TO_LOC_CD = new NZString();
        NZDecimal m_QTY = new NZDecimal();
        NZDecimal m_On_OTY = new NZDecimal();
        NZString m_REMARK = new NZString();
        NZString m_TRANS_ID = new NZString();
        NZString m_OBJ_ITEM_CD = new NZString();
        NZDecimal m_OBJ_ORDER_QTY = new NZDecimal();
        NZString m_LOT_NO = new NZString();

        NZString m_TRAN_SUB_CLS = new NZString();
        NZString m_REF_SLIP_NO = new NZString();
        NZString m_REF_SLIP_NO2 = new NZString();
        NZString m_FOR_CUSTOMER = new NZString();
        NZString m_FOR_MACHINE = new NZString();

        public NZString TRANS_ID { get { return m_TRANS_ID; } set { m_TRANS_ID = value; } }
        public NZString ITEM_CD { get { return m_ITEM_CD; } set { m_ITEM_CD = value; } }
        public NZString ITEM_DESC { get { return m_ITEM_DESC; } set { m_ITEM_DESC = value; } }
        public NZString FROM_LOC_CD { get { return m_FROM_LOC_CD; } set { m_FROM_LOC_CD = value; } }
        public NZString TO_LOC_CD { get { return m_TO_LOC_CD; } set { m_TO_LOC_CD = value; } }
        public NZString LOT_NO { get { return m_LOT_NO; } set { m_LOT_NO = value; } }
        public NZDecimal QTY { get { return m_QTY; } set { m_QTY = value; } }
        public NZDecimal On_OTY { get { return m_QTY; } set { m_QTY = value; } }
        public NZString REMARK { get { return m_REMARK; } set { m_REMARK = value; } }
        public NZDateTime TRANS_DATE { get { return m_ISSUE_DATE; } set { m_ISSUE_DATE = value; } }
        public NZString TRANS_CLS { get { return m_TRANS_CLS; } set { m_TRANS_CLS = value; } }
        public NZString SLIP_NO { get { return m_SLIP_NO; } set { m_SLIP_NO = value; } }
        public NZString OBJ_ITEM_CD { get { return m_OBJ_ITEM_CD; } set { m_OBJ_ITEM_CD = value; } }
        public NZDecimal OBJ_ORDER_QTY { get { return m_OBJ_ORDER_QTY; } set { m_OBJ_ORDER_QTY = value; } }
        public DataTable DATA_VIEW { get; set; }

        public NZString TRAN_SUB_CLS { get { return m_TRAN_SUB_CLS; } set { m_TRAN_SUB_CLS = value; } }
        public NZString REF_SLIP_NO { get { return m_REF_SLIP_NO; } set { m_REF_SLIP_NO = value; } }
        public NZString REF_SLIP_NO2 { get { return m_REF_SLIP_NO2; } set { m_REF_SLIP_NO2 = value; } }
        public NZString FOR_CUSTOMER { get { return m_FOR_CUSTOMER; } set { m_FOR_CUSTOMER = value; } }
        public NZString FOR_MACHINE { get { return m_FOR_MACHINE; } set { m_FOR_MACHINE = value; } }
    }
}
