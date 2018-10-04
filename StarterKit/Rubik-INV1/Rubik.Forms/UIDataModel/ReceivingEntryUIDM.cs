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
    public class ReceivingEntryUIDM : IUIDataModel
    {
        private NZString m_RECEIVE_NO = new NZString();
        private NZDateTime m_RECEIVE_DATE = new NZDateTime();
        private NZString m_RECEIVE_TYPE = new NZString();
        private NZString m_INVOICE_NO = new NZString();
        private NZString m_PO_NO = new NZString();
        private NZString m_STORED_LOC = new NZString();
        private NZString m_LOT_NO = new NZString();
        private NZString m_REMARK = new NZString();
        private NZString m_DEALING_NO = new NZString();
        // private NZDecimal m_STORED_LOC = new NZDecimal();

        private DataTable m_dtView = null;

        public ReceivingEntryUIDM()
        {
            m_RECEIVE_DATE = new NZDateTime(null, CommonLib.Common.GetDatabaseDateTime());

            InventoryTransactionViewDTO dto = new InventoryTransactionViewDTO();
            dto.CreateDataTableSchema(out m_dtView);
        }

        public NZString RECEIVE_NO
        {
            get { return m_RECEIVE_NO; }
            set { m_RECEIVE_NO = value; }
        }

        public NZDateTime RECEIVE_DATE
        {
            get { return m_RECEIVE_DATE; }
            set { m_RECEIVE_DATE = value; }
        }

        public NZString RECEIVE_TYPE
        {
            get { return m_RECEIVE_TYPE; }
            set { m_RECEIVE_TYPE = value; }
        }

        public NZString INVOICE_NO
        {
            get { return m_INVOICE_NO; }
            set { m_INVOICE_NO = value; }
        }

        public NZString PO_NO
        {
            get { return m_PO_NO; }
            set { m_PO_NO = value; }
        }

        public NZString REMARK
        {
            get { return m_REMARK; }
            set { m_REMARK = value; }
        }

        public NZString STORED_LOC
        {
            get { return m_STORED_LOC; }
            set { m_STORED_LOC = value; }
        }

        public NZString DEALING_NO
        {
            get { return m_DEALING_NO; }
            set { m_DEALING_NO = value; }
        }

        public NZString LOT_NO
        {
            get { return m_LOT_NO; }
            set { m_LOT_NO = value; }
        }

        public DataTable DATA_VIEW
        {
            get { return m_dtView; }
            set { m_dtView = value; }
        }

    }
}
