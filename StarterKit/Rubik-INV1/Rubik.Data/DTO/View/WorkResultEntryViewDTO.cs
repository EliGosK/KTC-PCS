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
    public class WorkResultEntryViewDTO : AbstractDTO
    {
        #region Enum
        public enum eColumns {
            TRANS_ID,
            ITEM_CD,
            LOC_CD,
            LOT_CONTROL_CLS,
            LOT_NO,
            ON_HAND_QTY,
            REQUEST_QTY,
            CONSUMPTION_QTY,
            INV_UM_CLS,
            CHILD_ORDER_LOC_CD,
            //LOWER_QTY,
            //UPPER_QTY,
        }
        #endregion

        #region Variables
        private NZString m_TRANS_ID = new NZString();
        private NZString m_ITEM_CD = new NZString();
        private NZString m_LOC_CD = new NZString();
        private NZString m_LOT_CONTROL_CLS = new NZString();
        private NZString m_LOT_NO = new NZString();
        private NZDecimal m_ON_HAND_QTY = new NZDecimal();
        private NZDecimal m_REQUEST_QTY = new NZDecimal();
        private NZDecimal m_CONSUMPTION_QTY = new NZDecimal();
        private NZString m_INV_UM_CLS = new NZString();
        private NZString m_CHILD_ORDER_LOC_CD = new NZString();
        //private NZDecimal m_UPPER_QTY = new NZDecimal();
        //private NZDecimal m_LOWER_QTY = new NZDecimal();
        #endregion

        #region Properties
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "TRANS_ID", 0, 0, 20)]
        public NZString TRANS_ID
        {
            get { return m_TRANS_ID; }
            set { m_TRANS_ID = value; }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ITEM_CD", 0, 0, 20)]
        public NZString ITEM_CD {
            get { return m_ITEM_CD; }
            set { m_ITEM_CD = value; }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "LOC_CD", 0, 0, 10)]
        public NZString LOC_CD
        {
            get { return m_LOC_CD; }
            set { m_LOC_CD = value; }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "LOT_CONTROL_CLS", 0, 0, 20)]
        public NZString LOT_CONTROL_CLS {
            get { return m_LOT_CONTROL_CLS; }
            set { m_LOT_CONTROL_CLS = value; }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "LOT_NO", 0, 0, 20)]
        public NZString LOT_NO {
            get { return m_LOT_NO; }
            set { m_LOT_NO = value; }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "ON_HAND_QTY", 10, 0, 9)]
        public NZDecimal ON_HAND_QTY {
            get { return m_ON_HAND_QTY; }
            set { m_ON_HAND_QTY = value; }
        }

        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "REQUEST_QTY", 10, 0, 9)]
        public NZDecimal REQUEST_QTY {
            get { return m_REQUEST_QTY; }
            set { m_REQUEST_QTY = value; }
        }

        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "CONSUMPTION_QTY", 10, 0, 9)]
        public NZDecimal CONSUMPTION_QTY {
            get { return m_CONSUMPTION_QTY; }
            set { m_CONSUMPTION_QTY = value; }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "INV_UM_CLS", 0, 0, 20)]
        public NZString INV_UM_CLS
        {
            get { return m_INV_UM_CLS; }
            set { m_INV_UM_CLS = value; }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CHILD_ORDER_LOC_CD", 0, 0, 20)]
        public NZString CHILD_ORDER_LOC_CD
        {
            get { return m_CHILD_ORDER_LOC_CD; }
            set { m_CHILD_ORDER_LOC_CD = value; }
        }

        //[Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "UPPER_QTY", 10, 0, 9)]
        //public NZDecimal UPPER_QTY {
        //    get { return m_UPPER_QTY; }
        //    set { m_UPPER_QTY = value; }
        //}

        //[Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "LOWER_QTY", 10, 0, 9)]
        //public NZDecimal LOWER_QTY {
        //    get { return m_LOWER_QTY; }
        //    set { m_LOWER_QTY = value; }
        //}
        #endregion      
    }
}

