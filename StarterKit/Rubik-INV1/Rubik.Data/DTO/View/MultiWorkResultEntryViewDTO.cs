using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Data;
using EVOFramework;
using EVOFramework.Database;

namespace Rubik.DTO
{
    [Serializable]
    [DataTransferObject("TB_INV_TRANS_TR", typeof(eColumns))]
    public class MultiWorkResultEntryViewDTO : AbstractDTO
    {
        #region Enum
        public enum eColumns
        {
            WORK_RESULT_NO,
            LOT_NO,
            ON_HAND_QTY,
            GOOD_QTY,
            RESERVE_QTY,
            NG_QTY,
            GOOD_TRANSACTION_ID,
            RESERVE_TRANSACTION_ID,
            NG_TRANSACTION_ID,
            CONSUMPTION_TRANSACTION_ID,
            NG_REASON
        }
        #endregion

        #region Variables
        private NZString m_WORK_RESULT_NO = new NZString();
        private NZString m_LOT_NO = new NZString();
        private NZDecimal m_ON_HAND_QTY = new NZDecimal();
        private NZDecimal m_GOOD_QTY = new NZDecimal();
        private NZDecimal m_RESERVE_QTY = new NZDecimal();
        private NZDecimal m_NG_QTY = new NZDecimal();
        private NZString m_GOOD_TRANSACTION_ID = new NZString();
        private NZString m_RESERVE_TRANSACTION_ID = new NZString();
        private NZString m_NG_TRANSACTION_ID = new NZString();
        private NZString m_CONSUMPTION_TRANSACTION_ID = new NZString();
        private NZString m_NG_REASON = new NZString();
        #endregion

        #region Properties
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "WORK_RESULT_NO", 0, 0, 20)]
        public NZString WORK_RESULT_NO
        {
            get { return m_WORK_RESULT_NO; }
            set { m_WORK_RESULT_NO = value; }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "LOT_NO", 0, 0, 20)]
        public NZString LOT_NO
        {
            get { return m_LOT_NO; }
            set { m_LOT_NO = value; }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "ON_HAND_QTY", 10, 0, 9)]
        public NZDecimal ON_HAND_QTY
        {
            get { return m_ON_HAND_QTY; }
            set { m_ON_HAND_QTY = value; }
        }

        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "GOOD_QTY", 10, 0, 9)]
        public NZDecimal GOOD_QTY
        {
            get { return m_GOOD_QTY; }
            set { m_GOOD_QTY = value; }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "RESERVE_QTY", 10, 0, 9)]
        public NZDecimal RESERVE_QTY
        {
            get { return m_RESERVE_QTY; }
            set { m_RESERVE_QTY = value; }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "NG_QTY", 10, 0, 9)]
        public NZDecimal NG_QTY
        {
            get { return m_NG_QTY; }
            set { m_NG_QTY = value; }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "GOOD_TRANSACTION_ID", 0, 0, 20)]
        public NZString GOOD_TRANSACTION_ID
        {
            get { return m_GOOD_TRANSACTION_ID; }
            set { m_GOOD_TRANSACTION_ID = value; }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "RESERVE_TRANSACTION_ID", 0, 0, 20)]
        public NZString RESERVE_TRANSACTION_ID
        {
            get { return m_RESERVE_TRANSACTION_ID; }
            set { m_RESERVE_TRANSACTION_ID = value; }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "NG_TRANSACTION_ID", 0, 0, 20)]
        public NZString NG_TRANSACTION_ID
        {
            get { return m_NG_TRANSACTION_ID; }
            set { m_NG_TRANSACTION_ID = value; }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CONSUMPTION_TRANSACTION_ID", 0, 0, 20)]
        public NZString CONSUMPTION_TRANSACTION_ID
        {
            get { return m_CONSUMPTION_TRANSACTION_ID; }
            set { m_CONSUMPTION_TRANSACTION_ID = value; }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "NG_REASON", 0, 0, 200)]
        public NZString NG_REASON
        {
            get { return m_NG_REASON; }
            set { m_NG_REASON = value; }
        }
        #endregion
    }
}

