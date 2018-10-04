using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Data;
using EVOFramework;
using System.Data;
using Rubik.DTO;

namespace Rubik.UIDataModel
{
    public class CustomerOrderEntryUIDM : IUIDataModel
    {
        private NZString m_strORDER_NO = new NZString();
        private NZString m_strORDER_DETAIL_NO = new NZString();
        private NZDateTime m_dtRECEIVE_DATE = new NZDateTime();
        private NZString m_strCUSTOMER_CD = new NZString();
        private NZString m_strLOC_CD = new NZString();
        private NZString m_strLOC_DESC = new NZString();
        private NZString m_strORDER_TYPE = new NZString();
        private NZString m_strPO_NO = new NZString();
        private NZDateTime m_dtPO_DATE = new NZDateTime();
        private NZString m_strCURRENCY = new NZString();
        private NZDecimal m_dEXCHANGE_RATE = new NZDecimal();
        private NZString m_strREMARK = new NZString();

        private NZString m_strITEM_CD = new NZString();
        private NZString m_strSHORT_NAME = new NZString();
        private NZDateTime m_dtITEM_DELIVERY_DATE = new NZDateTime();
        private NZDateTime m_dtOLD_ITEM_DELIVERY_DATE = new NZDateTime();
        private NZDecimal m_dQTY = new NZDecimal();
        private NZDecimal m_dOLD_QTY = new NZDecimal();
        private NZDecimal m_dPRICE = new NZDecimal();
        private NZDecimal m_dPRICE_THB = new NZDecimal();
        private NZDecimal m_dAMOUNT = new NZDecimal();
        private NZDecimal m_dAMOUNT_THB = new NZDecimal();

        private NZDecimal m_dTOTAL_QTY = new NZDecimal();
        private NZDecimal m_dTOTAL_AMOUNT = new NZDecimal();
        private NZDecimal m_dTOTAL_AMOUNT_THB = new NZDecimal();

        private NZString m_strCRT_BY = new NZString();
        private NZDateTime m_dtCRT_DATE = new NZDateTime();
        private NZString m_strCRT_MACHINE = new NZString();
        private NZString m_strUPD_BY = new NZString();
        private NZDateTime m_dtUPD_DATE = new NZDateTime();
        private NZString m_strUPD_MACHINE = new NZString();

        private NZString m_strPART_NO = new NZString();

        private DataTable m_dtView = null;

        public CustomerOrderEntryUIDM()
        {
            //m_RECEIVE_DATE = new NZDateTime(null, CommonLib.Common.GetDatabaseDateTime());

            CustomerOrderViewDTO dto = new CustomerOrderViewDTO();
            dto.CreateDataTableSchema(out m_dtView);
        }

        public NZString ORDER_NO { get { return m_strORDER_NO; } set { m_strORDER_NO = value; } }
        public NZString ORDER_DETAIL_NO { get { return m_strORDER_DETAIL_NO; } set { m_strORDER_DETAIL_NO = value; } }
        public NZDateTime RECEIVE_DATE { get { return m_dtRECEIVE_DATE; } set { m_dtRECEIVE_DATE = value; } }
        public NZString CUSTOMER_CD { get { return m_strCUSTOMER_CD; } set { m_strCUSTOMER_CD = value; } }
        public NZString LOC_CD { get { return m_strLOC_CD; } set { m_strLOC_CD = value; } }
        public NZString LOC_DESC { get { return m_strLOC_DESC; } set { m_strLOC_DESC = value; } }
        public NZString ORDER_TYPE { get { return m_strORDER_TYPE; } set { m_strORDER_TYPE = value; } }
        public NZString PO_NO { get { return m_strPO_NO; } set { m_strPO_NO = value; } }
        public NZDateTime PO_DATE { get { return m_dtPO_DATE; } set { m_dtPO_DATE = value; } }
        public NZString CURRENCY { get { return m_strCURRENCY; } set { m_strCURRENCY = value; } }
        public NZDecimal EXCHANGE_RATE { get { return m_dEXCHANGE_RATE; } set { m_dEXCHANGE_RATE = value; } }
        public NZString REMARK { get { return m_strREMARK; } set { m_strREMARK = value; } }
        public NZString ITEM_CD { get { return m_strITEM_CD; } set { m_strITEM_CD = value; } }
        public NZString SHORT_NAME { get { return m_strSHORT_NAME; } set { m_strSHORT_NAME = value; } }
        public NZDateTime ITEM_DELIVERY_DATE { get { return m_dtITEM_DELIVERY_DATE; } set { m_dtITEM_DELIVERY_DATE = value; } }
        public NZDateTime OLD_ITEM_DELIVERY_DATE { get { return m_dtOLD_ITEM_DELIVERY_DATE; } set { m_dtOLD_ITEM_DELIVERY_DATE = value; } }
        public NZDecimal QTY { get { return m_dQTY; } set { m_dQTY = value; } }
        public NZDecimal OLD_QTY { get { return m_dOLD_QTY; } set { m_dOLD_QTY = value; } }
        public NZDecimal PRICE { get { return m_dPRICE; } set { m_dPRICE = value; } }
        public NZDecimal PRICE_THB { get { return m_dPRICE_THB; } set { m_dPRICE_THB = value; } }
        public NZDecimal AMOUNT { get { return m_dAMOUNT; } set { m_dAMOUNT = value; } }
        public NZDecimal AMOUNT_THB { get { return m_dAMOUNT_THB; } set { m_dAMOUNT_THB = value; } }
        public NZDecimal TOTAL_QTY { get { return m_dTOTAL_QTY; } set { m_dTOTAL_QTY = value; } }
        public NZDecimal TOTAL_AMOUNT { get { return m_dTOTAL_AMOUNT; } set { m_dTOTAL_AMOUNT = value; } }
        public NZDecimal TOTAL_AMOUNT_THB { get { return m_dTOTAL_AMOUNT_THB; } set { m_dTOTAL_AMOUNT_THB = value; } }

        public NZString CRT_BY { get { return m_strCRT_BY; } set { m_strCRT_BY = value; } }
        public NZDateTime CRT_DATE { get { return m_dtCRT_DATE; } set { m_dtCRT_DATE = value; } }
        public NZString CRT_MACHINE { get { return m_strCRT_MACHINE; } set { m_strCRT_MACHINE = value; } }
        public NZString UPD_BY { get { return m_strUPD_BY; } set { m_strUPD_BY = value; } }
        public NZDateTime UPD_DATE { get { return m_dtUPD_DATE; } set { m_dtUPD_DATE = value; } }
        public NZString UPD_MACHINE { get { return m_strUPD_MACHINE; } set { m_strUPD_MACHINE = value; } }

        public NZString PART_NO { get { return m_strPART_NO; } set { m_strPART_NO = value; } }

        public DataTable DATA_VIEW
        {
            get { return m_dtView; }
            set { m_dtView = value; }
        }

    }
}
