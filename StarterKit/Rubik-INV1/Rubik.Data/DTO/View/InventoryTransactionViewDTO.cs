using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Database;

namespace Rubik.DTO
{
    [DataTransferObject("TB_INV_TRANS_TR", typeof(eColumns))]
    public class InventoryTransactionViewDTO : InventoryTransactionDTO
    {
        #region " Enums Columns "
        public new enum eColumns
        {
            TRANS_ID,
            ITEM_CD,
            LOC_CD,
            PACK_NO,
            FG_NO,
            LOT_NO,
            TRANS_DATE,
            TRANS_CLS,
            IN_OUT_CLS,
            QTY,
            OBJ_ITEM_CD,
            OBJ_ORDER_QTY,
            REF_NO,
            REF_SLIP_NO,
            REF_SLIP_CLS,
            OTHER_DL_NO,
            SLIP_NO,
            REMARK,
            CRT_BY,
            CRT_DATE,
            CRT_MACHINE,
            UPD_BY,
            UPD_DATE,
            UPD_MACHINE,
            DEALING_NO,
            EXTERNAL_LOT_NO,
            PRICE,
            FOR_CUSTOMER,
            FOR_MACHINE,
            SHIFT_CLS,

            REF_SLIP_NO2,
            NG_QTY,
            TRAN_SUB_CLS,


            // new field
            ITEM_DESC,   
            ORDER_QTY,
            INV_UM_CLS,
            ORDER_UM_CLS,
            INV_UM_RATE,
            ORDER_UM_RATE,
            AMOUNT,
            LOT_SIZE,
            GROUP_TRANS_ID,
            RESERVE_QTY,
            LOT_CONTROL_CLS,

            SHORT_NAME,
            CUSTOMER_NAME,
            IN_OUT_CLS_NAME,
            TRAN_SUB_CLS_NAME,
            LOC_DESC,
        };
        #endregion

        #region Variables
        private NZString m_strITEM_DESC = new NZString();
        private NZString m_strSHORT_NAME = new NZString();
        private NZString m_strCUSTOMER_NAME = new NZString();
        private NZString m_strIN_OUT_CLS_NAME = new NZString();
        private NZString m_strTRAN_SUB_CLS_NAME = new NZString();
        private NZString m_strLOC_DESC = new NZString();

        private NZDecimal m_dRECEIVING_QTY = new NZDecimal();
        private NZString m_strINV_UM_CLS = new NZString();
        private NZString m_strORDER_UM_CLS = new NZString();
        private NZDecimal m_dINV_UM_RATE = new NZDecimal();
        private NZDecimal m_dORDER_UM_RATE = new NZDecimal();
        private NZDecimal m_dAMOUNT = new NZDecimal();
        private NZDecimal m_dLOT_SIZE = new NZDecimal();
        private NZString m_strLOT_CONTROL_CLS = new NZString();
        #endregion

        #region Properties
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ITEM_DESC", 0, 0, 50)]
        public NZString ITEM_DESC
        {
            get { return m_strITEM_DESC; }
            set
            {
                if (value == null)
                    m_strITEM_DESC.Value = value;
                else
                    m_strITEM_DESC = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "SHORT_NAME", 0, 0, 50)]
        public NZString SHORT_NAME {
            get { return m_strSHORT_NAME; }
            set {
                if (value == null)
                    m_strSHORT_NAME.Value = value;
                else
                    m_strSHORT_NAME = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CUSTOMER_NAME", 0, 0, 100)]
        public NZString CUSTOMER_NAME {
            get { return m_strCUSTOMER_NAME; }
            set {
                if (value == null)
                    m_strCUSTOMER_NAME.Value = value;
                else
                    m_strCUSTOMER_NAME = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "IN_OUT_CLS_NAME", 0, 0, 50)]
        public NZString IN_OUT_CLS_NAME {
            get { return m_strIN_OUT_CLS_NAME; }
            set {
                if (value == null)
                    m_strIN_OUT_CLS_NAME.Value = value;
                else
                    m_strIN_OUT_CLS_NAME = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "TRAN_SUB_CLS_NAME", 0, 0, 50)]
        public NZString TRAN_SUB_CLS_NAME {
            get { return m_strTRAN_SUB_CLS_NAME; }
            set {
                if (value == null)
                    m_strTRAN_SUB_CLS_NAME.Value = value;
                else
                    m_strTRAN_SUB_CLS_NAME = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "LOC_DESC", 0, 0, 100)]
        public NZString LOC_DESC {
            get { return m_strLOC_DESC; }
            set {
                if (value == null)
                    m_strLOC_DESC.Value = value;
                else
                    m_strLOC_DESC = value;
            }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "INV_UM_CLS", 0, 0, 5)]
        public NZString INV_UM_CLS
        {
            get { return m_strINV_UM_CLS; }
            set
            {
                if (value == null)
                    m_strINV_UM_CLS.Value = value;
                else
                    m_strINV_UM_CLS = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ORDER_UM_CLS", 0, 0, 5)]
        public NZString ORDER_UM_CLS
        {
            get { return m_strORDER_UM_CLS; }
            set
            {
                if (value == null)
                    m_strORDER_UM_CLS.Value = value;
                else
                    m_strORDER_UM_CLS = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "INV_UM_RATE", 10, 0, 9)]
        public NZDecimal INV_UM_RATE
        {
            get { return m_dINV_UM_RATE; }
            set
            {
                if (value == null)
                    m_dINV_UM_RATE.Value = value;
                else
                    m_dINV_UM_RATE = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "ORDER_UM_RATE", 10, 0, 9)]
        public NZDecimal ORDER_UM_RATE
        {
            get { return m_dORDER_UM_RATE; }
            set
            {
                if (value == null)
                    m_dORDER_UM_RATE.Value = value;
                else
                    m_dORDER_UM_RATE = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "ORDER_QTY", 10, 0, 9)]
        public NZDecimal ORDER_QTY
        {
            get { return m_dRECEIVING_QTY; }
            set
            {
                if (value == null)
                    m_dRECEIVING_QTY.Value = value;
                else
                    m_dRECEIVING_QTY = value;
            }
        }

        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "AMOUNT", 10, 0, 9)]
        public NZDecimal AMOUNT
        {
            get { return m_dAMOUNT; }
            set
            {
                if (value == null)
                    m_dAMOUNT.Value = value;
                else
                    m_dAMOUNT = value;
            }
        }

        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "LOT_SIZE", 13, 6, 9)]
        public NZDecimal LOT_SIZE
        {
            get { return m_dLOT_SIZE; }
            set
            {
                if (value == null)
                    m_dLOT_SIZE.Value = value;
                else
                    m_dLOT_SIZE = value;
            }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "LOT_CONTROL_CLS", 0, 0, 5)]
        public NZString LOT_CONTROL_CLS
        {
            get { return m_strLOT_CONTROL_CLS; }
            set
            {
                if (value == null)
                    m_strLOT_CONTROL_CLS.Value = value;
                else
                    m_strLOT_CONTROL_CLS = value;
            }
        }


        #endregion

        public override MapKeyValue<string, List<string>> PrimaryKey
        {
            get
            {
                return null;
            }
        }

        public override Map<string, List<string>> UniqueKeys
        {
            get
            {
                return null;
            }
        }
    }
}
