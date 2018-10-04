using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Data;
using EVOFramework;

namespace Rubik.UIDataModel
{
    public class AdjustmentEntryUIDM : IUIDataModel
    {
        private NZString m_TransactionID = new NZString();
        private NZString m_AdjustNo = new NZString();
        private NZDateTime m_AdjustDate = new NZDateTime();
        private NZString m_AdjustType = new NZString();
        private NZString m_itemCode = new NZString();        
        private NZString m_itemDesc = new NZString();
        private NZString m_customerName = new NZString();
        private NZString m_storedLoc = new NZString();
        private NZString m_packNo = new NZString();
        private NZString m_fgNo = new NZString();
        private NZString m_lotNo = new NZString();
        private NZString m_externalLotNo = new NZString();

        private NZDecimal m_onHandQty = new NZDecimal(null, 0);
        private NZDecimal m_adjustQty = new NZDecimal(null, 0);
        private NZDecimal m_adjustWeight = new NZDecimal(null, 0);
        private NZString m_remark = new NZString();
        private NZString m_reasonCode = new NZString();

        private NZString m_groupTransID = new NZString();

        public NZString ReasonCode
        {
            get { return m_reasonCode; }
            set { m_reasonCode = value; }
        }

        public NZString TransactionID {
            get { return m_TransactionID; }
            set { m_TransactionID = value; }
        }

        public NZString AdjustNo {
            get { return m_AdjustNo; }
            set { m_AdjustNo = value; }
        }

        public NZDateTime AdjustDate {
            get { return m_AdjustDate; }
            set { m_AdjustDate = value; }
        }

        public NZString AdjustType {
            get { return m_AdjustType; }
            set { m_AdjustType = value; }
        }

        public NZString ItemCode {
            get { return m_itemCode; }
            set { m_itemCode = value; }
        }

        public NZString ItemDesc {
            get { return m_itemDesc; }
            set { m_itemDesc = value; }
        }

        public NZString CustomerName {
            get { return m_customerName; }
            set { m_customerName = value; }
        }

        public NZString StoredLoc {
            get { return m_storedLoc; }
            set { m_storedLoc = value; }
        }

        public NZString LotNo {
            get { return m_lotNo; }
            set { m_lotNo = value; }
        }

        public NZString ExternalLotNo
        {
            get { return m_externalLotNo; }
            set { m_externalLotNo = value; }
        }

        public NZString PackNo {
            get { return m_packNo; }
            set { m_packNo = value; }
        }

        public NZString FGNo
        {
            get { return m_fgNo; }
            set { m_fgNo = value; }
        }

        public NZDecimal OnHandQty {
            get { return m_onHandQty; }
            set { m_onHandQty = value; }
        }

        public NZDecimal AdjustQty {
            get { return m_adjustQty; }
            set { m_adjustQty = value; }
        }

        public NZDecimal AdjustWeight {
            get { return m_adjustWeight; }
            set { m_adjustWeight = value; }
        }

        public NZString Remark {
            get { return m_remark; }
            set { m_remark = value; }
        }

        public NZString GroupTransID {
            get { return m_groupTransID; }
            set { m_groupTransID = value; }
        }
    }
}
