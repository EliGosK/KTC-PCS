using System;
using EVOFramework.Data;
using EVOFramework;
using EVOFramework.Database;


namespace Rubik.DTO
{
    [Serializable()]
    [DataTransferObject("NGInquiry_VIEW_DTO", typeof(eColumns))]
    public class NGInquiryViewDTO : AbstractDTO
    {
        #region enum
        public enum eColumns
        {
            ITEM_CD,
            ITEM_DESC,
            SHORT_NAME,
            LOT_NO,
            TRANS_DATE,
            SHIFT_CLS,
            QTY,
            NG_QTY,
            RESERVE_QTY,
            WO_NO,
            REMARK,
            NG_REASON,
            TRAN_SUB_CLS
        }
        #endregion

        #region variable
        private NZString m_strITEM_CD = new NZString();
        private NZString m_strITEM_DESC = new NZString();
        private NZString m_strSHORT_NAME = new NZString();
        private NZString m_strLOT_NO = new NZString();
        private NZDateTime m_dtTRANS_DATE = new NZDateTime();
        private NZString m_strSHIFT_CLS = new NZString();
        private NZDecimal m_dQTY = new NZDecimal();
        private NZDecimal m_dNG_QTY = new NZDecimal();
        private NZDecimal m_dRESERVE_QTY = new NZDecimal();
        private NZString m_strWO_NO = new NZString();
        private NZString m_strREMARK = new NZString();
        private NZString m_strNG_REASON = new NZString();
        private NZString m_strTRAN_SUB_CLS = new NZString();
        #endregion

        #region properties

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ITEM_CD", 0, 0, 35)]
        public NZString ITEM_CD
        {
            get { return m_strITEM_CD; }
            set
            {
                if (value == null)
                    m_strITEM_CD.Value = value;
                else
                    m_strITEM_CD = value;
            }
        }
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
        public NZString SHORT_NAME
        {
            get { return m_strSHORT_NAME; }
            set
            {
                if (value == null)
                    m_strSHORT_NAME.Value = value;
                else
                    m_strSHORT_NAME = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "LOT_NO", 0, 0, 10)]
        public NZString LOT_NO
        {
            get { return m_strLOT_NO; }
            set
            {
                if (value == null)
                    m_strLOT_NO.Value = value;
                else
                    m_strLOT_NO = value;
            }
        }
        [Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "TRANS_DATE", 23, 3, 8)]
        public NZDateTime TRANS_DATE
        {
            get { return m_dtTRANS_DATE; }
            set
            {
                if (value == null)
                    m_dtTRANS_DATE.Value = value;
                else
                    m_dtTRANS_DATE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "SHIFT_CLS", 0, 0, 2)]
        public NZString SHIFT_CLS
        {
            get { return m_strSHIFT_CLS; }
            set
            {
                if (value == null)
                    m_strSHIFT_CLS.Value = value;
                else
                    m_strSHIFT_CLS = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "QTY", 16, 6, 9)]
        public NZDecimal QTY
        {
            get { return m_dQTY; }
            set
            {
                if (value == null)
                    m_dQTY.Value = value;
                else
                    m_dQTY = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "NG_QTY", 16, 6, 9)]
        public NZDecimal NG_QTY
        {
            get { return m_dNG_QTY; }
            set
            {
                if (value == null)
                    m_dNG_QTY.Value = value;
                else
                    m_dNG_QTY = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "RESERVE_QTY", 16, 6, 9)]
        public NZDecimal RESERVE_QTY
        {
            get { return m_dRESERVE_QTY; }
            set
            {
                if (value == null)
                    m_dRESERVE_QTY.Value = value;
                else
                    m_dRESERVE_QTY = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "WO_NO", 0, 0, 20)]
        public NZString WO_NO
        {
            get { return m_strWO_NO; }
            set
            {
                if (value == null)
                    m_strWO_NO.Value = value;
                else
                    m_strWO_NO = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "REMARK", 0, 0, 200)]
        public NZString REMARK
        {
            get { return m_strREMARK; }
            set
            {
                if (value == null)
                    m_strREMARK.Value = value;
                else
                    m_strREMARK = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "REMARK", 0, 0, 200)]
        public NZString NG_REASON
        {
            get { return m_strNG_REASON; }
            set
            {
                if (value == null)
                    m_strNG_REASON.Value = value;
                else
                    m_strNG_REASON = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "TRAN_SUB_CLS", 0, 0, 35)]
        public NZString TRAN_SUB_CLS
        {
            get { return m_strTRAN_SUB_CLS; }
            set
            {
                if (value == null)
                    m_strTRAN_SUB_CLS.Value = value;
                else
                    m_strTRAN_SUB_CLS = value;
            }
        }
        #endregion
    }
}
