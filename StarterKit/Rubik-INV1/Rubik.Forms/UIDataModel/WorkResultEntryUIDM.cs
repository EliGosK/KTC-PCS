
using EVOFramework.Data;
using EVOFramework;
using System.Data;
using Rubik.DTO;

namespace Rubik.UIDataModel {
    public class WorkResultEntryUIDM : IUIDataModel {
        private NZString m_transactionID = new NZString();
        private NZString m_NGTransactionID = new NZString();
        private NZString m_ReserveTransactionID = new NZString();

        private NZString m_workOrderNo = new NZString();
        private NZString m_workResultNo = new NZString();
        private NZDateTime m_workResultDate = new NZDateTime();
        private NZString m_itemCode = new NZString();
        private NZString m_itemDesc = new NZString();
        private NZString m_orderLoc = new NZString();
        private NZString m_storedLoc = new NZString();
        private NZString m_lotNo = new NZString();
        private NZDecimal m_workResultQty = new NZDecimal();
        private NZDecimal m_GoodQty = new NZDecimal();
        private NZDecimal m_NGQty = new NZDecimal();
        private NZDecimal m_ReserveQty = new NZDecimal();
        private NZString m_remark = new NZString();
        private NZString m_shipCls = new NZString();
        private NZString m_consumptionCls = new NZString();
        private NZString m_forMachine = new NZString();
        private NZString m_NGReason = new NZString();
        private NZDecimal m_LotSize = new NZDecimal();

        /// <summary>
        /// Represent data table for view.
        /// Structure : WorkResultViewDTO
        /// </summary>
        private DataTable m_dataView = null;
        public WorkResultEntryUIDM() {
            WorkResultEntryViewDTO dto = new WorkResultEntryViewDTO();
            dto.CreateDataTableSchema(out m_dataView);
        }

        public NZString TransactionID {
            get { return m_transactionID; }
            set { m_transactionID = value; }
        }
        public NZString NGTransactionID {
            get { return m_NGTransactionID; }
            set { m_NGTransactionID = value; }
        }
        public NZString ReserveTransactionID {
            get { return m_ReserveTransactionID; }
            set { m_ReserveTransactionID = value; }
        }
        public NZString CONSUMTION_CLS {
            get { return m_consumptionCls; }
            set { m_consumptionCls = value; }
        }

        public NZString ShipClass {
            get { return m_shipCls; }
            set { m_shipCls = value; }
        }

        public NZString WorkOrderNo {
            get { return m_workOrderNo; }
            set { m_workOrderNo = value; }
        }

        public NZDateTime WorkResultDate {
            get { return m_workResultDate; }
            set { m_workResultDate = value; }
        }

        public NZString ItemCode {
            get { return m_itemCode; }
            set { m_itemCode = value; }
        }

        public NZString ItemDesc {
            get { return m_itemDesc; }
            set { m_itemDesc = value; }
        }

        public NZString OrderLoc {
            get { return m_orderLoc; }
            set { m_orderLoc = value; }
        }

        public NZString StoredLoc {
            get { return m_storedLoc; }
            set { m_storedLoc = value; }
        }

        public NZString LotNo {
            get { return m_lotNo; }
            set { m_lotNo = value; }
        }

        public NZDecimal GoodQty {
            get { return m_GoodQty; }
            set { m_GoodQty = value; }
        }

        public NZDecimal WorkResultQty {
            get { return m_workResultQty; }
            set { m_workResultQty = value; }
        }

        public NZDecimal NGQty {
            get { return m_NGQty; }
            set { m_NGQty = value; }
        }

        public NZDecimal ReserveQty {
            get { return m_ReserveQty; }
            set { m_ReserveQty = value; }
        }

        public NZString Remark {
            get { return m_remark; }
            set { m_remark = value; }
        }
        public NZString ForMachine {
            get { return m_forMachine; }
            set { m_forMachine = value; }
        }
        /// <summary>
        /// Represent data table for view.
        /// Structure : WorkResultViewDTO
        /// </summary>
        public DataTable DataView {
            get { return m_dataView; }
            set { m_dataView = value; }
        }

        public NZString WorkResultNo {
            get { return m_workResultNo; }
            set { m_workResultNo = value; }
        }

        public NZString NGReason {
            get { return m_NGReason; }
            set { m_NGReason = value; }
        }

        public NZDecimal LotSize {
            get { return m_LotSize; }
            set { m_LotSize = value; }
        }
    }
}
