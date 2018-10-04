
using System.Data;
using EVOFramework;
using EVOFramework.Data;

namespace Rubik.UIDataModel
{
    public class InvoiceEntryUIDM : IUIDataModel
    {
        public NZString m_strTRANS_ID = new NZString();
        public NZString m_strBILL_NO = new NZString();
        public NZString m_strDELIVERY_NO = new NZString();
        public NZString m_strCUSTOMER_CD = new NZString();
        public NZInt m_iADDRESS_NO = new NZInt();
        public NZString m_strADDRESS = new NZString();
        public NZString m_strINVOICE_NO = new NZString();
        public NZDateTime m_dtINVOICE_DATE = new NZDateTime();
        public NZString m_strTERM_OF_PAYMENT = new NZString();
        public NZDateTime m_dtPAYMENT_DUE_DATE = new NZDateTime();
        public NZString m_strREFER_TEM_NO = new NZString();
        public NZString m_strREMARK = new NZString();
        public NZDecimal m_dSUB_TOTAL = new NZDecimal();
        public NZDecimal m_dVAT = new NZDecimal();
        public NZDecimal m_dVAT_AMOUNT = new NZDecimal();
        public NZDecimal m_dTOTAL = new NZDecimal();
        public NZInt m_iCANCEL_FLAG = new NZInt();

        public NZString m_strCRT_BY = new NZString();
        public NZDateTime m_dtCRT_DATE = new NZDateTime();
        public NZString m_strCRT_MACHINE = new NZString();
        public NZString m_strUPD_BY = new NZString();
        public NZDateTime m_dtUPD_DATE = new NZDateTime();
        public NZString m_strUPD_MACHINE = new NZString();

        public NZString m_strPO_NO = new NZString();
        public NZString m_strORDER_NO = new NZString();
        public NZString m_strORDER_DETAIL_NO = new NZString();
        public NZString m_strITEM_CD = new NZString();
        public NZString m_strSHORT_NAME = new NZString();
        public NZString m_strITEM_DESC = new NZString();
        public NZString m_strUNIT = new NZString();
        public NZDecimal m_dQTY = new NZDecimal();
        public NZDecimal m_dPRICE = new NZDecimal();
        public NZDecimal m_dAMOUNT = new NZDecimal();
        public NZInt m_iOLD_DATA = new NZInt();

        DataTable m_dtView = null;
        

        public InvoiceEntryUIDM()
        {
            DATA_VIEW = new DataTable();

            DATA_VIEW.Columns.Add("CRT_BY");
            DATA_VIEW.Columns.Add("CRT_DATE");
            DATA_VIEW.Columns.Add("CRT_MACHINE");
            DATA_VIEW.Columns.Add("UPD_BY");
            DATA_VIEW.Columns.Add("UPD_DATE");
            DATA_VIEW.Columns.Add("UPD_MACHINE");
            
            DATA_VIEW.Columns.Add("TRANS_ID");
            DATA_VIEW.Columns.Add("BILL_NO");
            DATA_VIEW.Columns.Add("DELIVERY_NO");
            DATA_VIEW.Columns.Add("ADDRESS_NO");
            DATA_VIEW.Columns.Add("ADDRESS");
            DATA_VIEW.Columns.Add("INVOICE_NO");
            DATA_VIEW.Columns.Add("INVOICE_DATE");
            DATA_VIEW.Columns.Add("TERM_OF_PAYMENT");
            DATA_VIEW.Columns.Add("PAYMENT_DUE_DATE");
            DATA_VIEW.Columns.Add("REFER_TEM_NO");
            DATA_VIEW.Columns.Add("REMARK");
            DATA_VIEW.Columns.Add("SUB_TOTAL");
            DATA_VIEW.Columns.Add("VAT");
            DATA_VIEW.Columns.Add("VAT_AMOUNT");
            DATA_VIEW.Columns.Add("TOTAL");
            DATA_VIEW.Columns.Add("CANCEL_FLAG");
            DATA_VIEW.Columns.Add("PO_NO");
            DATA_VIEW.Columns.Add("ORDER_NO");
            DATA_VIEW.Columns.Add("ORDER_DETAIL_NO");

            DATA_VIEW.Columns.Add("ITEM_CD");
            DATA_VIEW.Columns.Add("SHORT_NAME");
            DATA_VIEW.Columns.Add("ITEM_DESC");
            DATA_VIEW.Columns.Add("UNIT");
            DATA_VIEW.Columns.Add("QTY");
            DATA_VIEW.Columns.Add("PRICE");
            DATA_VIEW.Columns.Add("AMOUNT");
            DATA_VIEW.Columns.Add("OLD_DATA");
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

        public NZString TRANS_ID { get { return m_strTRANS_ID; } set { m_strTRANS_ID = value; } }
        public NZString BILL_NO { get { return m_strBILL_NO; } set { m_strBILL_NO = value; } }
        public NZString DELIVERY_NO { get { return m_strDELIVERY_NO; } set { m_strDELIVERY_NO = value; } }
        public NZInt ADDRESS_NO { get { return m_iADDRESS_NO; } set { m_iADDRESS_NO = value; } }
        public NZString ADDRESS { get { return m_strADDRESS; } set { m_strADDRESS = value; } }
        public NZString INVOICE_NO { get { return m_strINVOICE_NO; } set { m_strINVOICE_NO = value; } }
        public NZDateTime INVOICE_DATE { get { return m_dtINVOICE_DATE; } set { m_dtINVOICE_DATE = value; } }
        public NZString TERM_OF_PAYMENT { get { return m_strTERM_OF_PAYMENT; } set { m_strTERM_OF_PAYMENT = value; } }
        public NZDateTime PAYMENT_DUE_DATE { get { return m_dtPAYMENT_DUE_DATE; } set { m_dtPAYMENT_DUE_DATE = value; } }
        public NZString REFER_TEM_NO { get { return m_strREFER_TEM_NO; } set { m_strREFER_TEM_NO = value; } }
        public NZString REMARK { get { return m_strREMARK; } set { m_strREMARK = value; } }
        public NZDecimal SUB_TOTAL { get { return m_dSUB_TOTAL; } set { m_dSUB_TOTAL = value; } }
        public NZDecimal VAT { get { return m_dVAT; } set { m_dVAT = value; } }
        public NZDecimal VAT_AMOUNT { get { return m_dVAT_AMOUNT; } set { m_dVAT_AMOUNT = value; } }
        public NZDecimal TOTAL { get { return m_dTOTAL; } set { m_dTOTAL = value; } }
        public NZInt CANCEL_FLAG { get { return m_iCANCEL_FLAG; } set { m_iCANCEL_FLAG = value; } }
        public NZString PO_NO { get { return m_strPO_NO; } set { m_strPO_NO = value; } }
        public NZString ORDER_NO { get { return m_strORDER_NO; } set { m_strORDER_NO = value; } }
        public NZString ORDER_DETAIL_NO { get { return m_strORDER_DETAIL_NO; } set { m_strORDER_DETAIL_NO = value; } }
        public NZString ITEM_CD { get { return m_strITEM_CD; } set { m_strITEM_CD = value; } }
        public NZString SHORT_NAME { get { return m_strSHORT_NAME; } set { m_strSHORT_NAME = value; } }
        public NZString ITEM_DESC { get { return m_strITEM_DESC; } set { m_strITEM_DESC = value; } }
        public NZString UNIT { get { return m_strUNIT; } set { m_strUNIT = value; } }
        public NZDecimal QTY { get { return m_dQTY; } set { m_dQTY = value; } }
        public NZDecimal PRICE { get { return m_dPRICE; } set { m_dPRICE = value; } }
        public NZDecimal AMOUNT { get { return m_dAMOUNT; } set { m_dAMOUNT = value; } }
        public NZInt OLD_DATA { get { return m_iOLD_DATA; } set { m_iOLD_DATA = value; } }
        public DataTable DATA_VIEW
        {
            get { return m_dtView; }
            set { m_dtView = value; }
        }
    }
}
