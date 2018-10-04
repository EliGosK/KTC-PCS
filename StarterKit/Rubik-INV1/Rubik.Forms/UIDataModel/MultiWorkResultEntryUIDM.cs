using EVOFramework.Data;
using EVOFramework;
using System.Data;
using Rubik.DTO;

namespace Rubik.UIDataModel
{
    public class MultiWorkResultEntryUIDM : IUIDataModel
    {
        private NZString m_workOrderNo = new NZString();
        private NZString m_workResultGroupNo = new NZString();
        private NZDateTime m_workResultDate = new NZDateTime();
        private NZString m_itemCode = new NZString();
        private NZString m_childItemCode = new NZString();
        private NZString m_itemDesc = new NZString();
        private NZString m_orderLoc = new NZString();
        private NZString m_storedLoc = new NZString();
        private NZString m_lotNo = new NZString();
        private NZString m_remark = new NZString();
        private NZString m_shiftCls = new NZString();
        private NZString m_TRAN_SUB_CLS = new NZString();

        private NZString m_consumptionCls = new NZString();
        private NZString m_forMachine = new NZString();

        /// <summary>
        /// Represent data table for view.
        /// Structure : MultiWorkResultViewDTO
        /// </summary>
        private DataTable m_dataView = null;

        public MultiWorkResultEntryUIDM()
        {
            m_workResultDate = new NZDateTime(null, CommonLib.Common.GetDatabaseDateTime());
            m_TRAN_SUB_CLS = (NZString)DataDefine.eTRAN_SUB_CLS.WR.ToString();

            MultiWorkResultEntryViewDTO dto = new MultiWorkResultEntryViewDTO();
            dto.CreateDataTableSchema(out m_dataView);
        }

        public NZString CONSUMTION_CLS
        {
            get { return m_consumptionCls; }
            set { m_consumptionCls = value; }
        }

        public NZString WorkResultGroupNo
        {
            get { return m_workResultGroupNo; }
            set { m_workResultGroupNo = value; }
        }

        public NZString ShiftClass
        {
            get { return m_shiftCls; }
            set { m_shiftCls = value; }
        }
        public NZString TRAN_SUB_CLS
        {
            get { return m_TRAN_SUB_CLS; }
            set { m_TRAN_SUB_CLS = value; }
        }
        public NZString WorkOrderNo
        {
            get { return m_workOrderNo; }
            set { m_workOrderNo = value; }
        }
        public NZDateTime WorkResultDate
        {
            get { return m_workResultDate; }
            set { m_workResultDate = value; }
        }
        public NZString ItemCode
        {
            get { return m_itemCode; }
            set { m_itemCode = value; }
        }

        public NZString ItemDesc
        {
            get { return m_itemDesc; }
            set { m_itemDesc = value; }
        }

        public NZString OrderLoc
        {
            get { return m_orderLoc; }
            set { m_orderLoc = value; }
        }

        public NZString StoredLoc
        {
            get { return m_storedLoc; }
            set { m_storedLoc = value; }
        }

        public NZString ChildItemCode
        {
            get { return m_childItemCode; }
            set { m_childItemCode = value; }
        }


        public NZString LotNo
        {
            get { return m_lotNo; }
            set { m_lotNo = value; }
        }

        public NZString Remark
        {
            get { return m_remark; }
            set { m_remark = value; }
        }
        public NZString ForMachine
        {
            get { return m_forMachine; }
            set { m_forMachine = value; }
        }

        /// <summary>
        /// Represent data table for view.
        /// Structure : WorkResultViewDTO
        /// </summary>
        public DataTable DataView
        {
            get { return m_dataView; }
            set { m_dataView = value; }
        }


    }
}