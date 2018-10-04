using EVOFramework;
using EVOFramework.Data;

namespace Rubik.UIDataModel
{
    [DataTransferObject("INV_MOVEMENT_INQ", typeof(eColumns))]
    public class InventoryMovementInqUIDM : AbstractDTO
    {
        public enum eColumns
        {
            TRANS_DATE,
            TRANS_ID,
            TRANS_INFO,
            REF_TYPE,
            REF_SLIP_NO,
            LOT_NO,
            IN_QTY,
            OUT_QTY,
            BALANCE,
            NG_CRITERIA,
            NG_QTY,
            REF_NO,
            REMARK,
        }

        private NZDateTime m_TRANS_DATE = new NZDateTime();
        private NZString m_TRANS_ID = new NZString();
        private NZString m_TRANS_INFO = new NZString();
        private NZString m_REF_TYPE = new NZString();
        private NZString m_REF_SLIP_NO = new NZString();
        private NZString m_LOT_NO = new NZString();
        private NZDecimal m_IN_QTY = new NZDecimal();
        private NZDecimal m_OUT_QTY = new NZDecimal();
        private NZDecimal m_BALANCE = new NZDecimal();
        private NZString m_NG_CRITERIA = new NZString();
        private NZDecimal m_NG_QTY = new NZDecimal();
        private NZString m_REF_NO = new NZString();
        private NZString m_REMARK = new NZString();

        public NZDateTime TRANS_DATE
        {
            get { return m_TRANS_DATE; }
            set { m_TRANS_DATE = value; }
        }

        public NZString REMARK
        {
            get { return m_REMARK; }
            set { m_REMARK = value; }
        }
        public NZString REF_NO
        {
            get { return m_REF_NO; }
            set { m_REF_NO = value; }
        }
        public NZString TRANS_ID
        {
            get { return m_TRANS_ID; }
            set { m_TRANS_ID = value; }
        }

        public NZString TRANS_INFO
        {
            get { return m_TRANS_INFO; }
            set { m_TRANS_INFO = value; }
        }

        public NZString REF_TYPE
        {
            get { return m_REF_TYPE; }
            set { m_REF_TYPE = value; }
        }

        public NZString REF_SLIP_NO
        {
            get { return m_REF_SLIP_NO; }
            set { m_REF_SLIP_NO = value; }
        }

        public NZString LOT_NO
        {
            get { return m_LOT_NO; }
            set { m_LOT_NO = value; }
        }

        public NZDecimal IN_QTY
        {
            get { return m_IN_QTY; }
            set { m_IN_QTY = value; }
        }

        public NZDecimal OUT_QTY
        {
            get { return m_OUT_QTY; }
            set { m_OUT_QTY = value; }
        }

        public NZDecimal BALANCE
        {
            get { return m_BALANCE; }
            set { m_BALANCE = value; }
        }

        public NZString NG_CRITERIA
        {
            get { return m_NG_CRITERIA; }
            set { m_NG_CRITERIA = value; }
        }

        public NZDecimal NG_QTY
        {
            get { return m_NG_QTY; }
            set { m_NG_QTY = value; }
        }
    }
}
