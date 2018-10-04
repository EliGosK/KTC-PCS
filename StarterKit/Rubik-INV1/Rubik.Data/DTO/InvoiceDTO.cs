/*
 *		Author: Mr.Pongthorn S.
 *      Team : TP_JDL
 * 		Writed On 2012/05/09
 * 		Time : 05:37 PM
 *  	This is DTO for TB_INVOICE_TR Table.
 *		From Templates Version : 1.0.0
 *		Last Modify Template On : 2012/05/09
 */
#region Using Namespace
using System;
using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Database;
using System.Collections.Generic;
#endregion

namespace Rubik.DTO
{
    [Serializable()]
    [DataTransferObject("TB_INVOICE_TR", typeof(eColumns))]
    public class InvoiceDTO : AbstractDTO
    {
        #region " Enums Columns "
        public enum eColumns
        {
            CRT_BY,
            CRT_DATE,
            CRT_MACHINE,
            UPD_BY,
            UPD_DATE,
            UPD_MACHINE,
            TRANS_ID,
            BILL_NO,
            DEALING_NO,
            DELIVERY_NO,
            ADDRESS_NO,
            ADDRESS,
            INVOICE_NO,
            INVOICE_DATE,
            TERM_OF_PAYMENT,
            PAYMENT_DUE_DATE,
            REFER_TEM_NO,
            REMARK,
            SUB_TOTAL,
            VAT,
            VAT_AMOUNT,
            TOTAL,
            CANCEL_FLAG,
            PO_NO,
            ORDER_NO,
            ORDER_DETAIL_NO,
            ITEM_CD,
            SHORT_NAME,
            ITEM_DESC,
            UNIT,
            QTY,
            PRICE,
            AMOUNT,
            OLD_DATA
        };
        #endregion

        #region " Variables "
        private NZString m_strTRANS_ID = new NZString();
        private NZString m_strBILL_NO = new NZString();
        private NZString m_strDEALING_NO = new NZString();
        private NZString m_strDELIVERY_NO = new NZString();
        private NZString m_strCUSTOMER_CD = new NZString();
        private NZInt m_iADDRESS_NO = new NZInt();
        private NZString m_strADDRESS = new NZString();
        private NZString m_strINVOICE_NO = new NZString();
        private NZDateTime m_dtINVOICE_DATE = new NZDateTime();
        private NZString m_strTERM_OF_PAYMENT = new NZString();
        private NZDateTime m_dtPAYMENT_DUE_DATE = new NZDateTime();
        private NZString m_strREFER_TEM_NO = new NZString();
        private NZString m_strREMARK = new NZString();
        private NZDecimal m_dSUB_TOTAL = new NZDecimal();
        private NZDecimal m_dVAT = new NZDecimal();
        private NZDecimal m_dVAT_AMOUNT = new NZDecimal();
        private NZDecimal m_dTOTAL = new NZDecimal();
        private NZInt m_iCANCEL_FLAG = new NZInt();

        private NZString m_strCRT_BY = new NZString();
        private NZDateTime m_dtCRT_DATE = new NZDateTime();
        private NZString m_strCRT_MACHINE = new NZString();
        private NZString m_strUPD_BY = new NZString();
        private NZDateTime m_dtUPD_DATE = new NZDateTime();
        private NZString m_strUPD_MACHINE = new NZString();

        private NZString m_strPO_NO = new NZString();
        private NZString m_strORDER_NO = new NZString();
        private NZString m_strORDER_DETAIL_NO = new NZString();
        private NZString m_strITEM_CD = new NZString();
        private NZString m_strSHORT_NAME = new NZString();
        private NZString m_strITEM_DESC = new NZString();
        private NZString m_strUNIT = new NZString();
        private NZDecimal m_dQTY = new NZDecimal();
        private NZDecimal m_dPRICE = new NZDecimal();
        private NZDecimal m_dAMOUNT = new NZDecimal();
        private NZInt m_iOLD_DATA = new NZInt();
        #endregion

        #region " Constructor "

        #endregion

        #region " Getter and Setter properties "
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CRT_BY", 0, 0, 30)]
        public NZString CRT_BY
        {
            get { return m_strCRT_BY; }
            set
            {
                if (value == null)
                    m_strCRT_BY.Value = value;
                else
                    m_strCRT_BY = value;
            }
        }
        [Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "CRT_DATE", 23, 3, 8)]
        public NZDateTime CRT_DATE
        {
            get { return m_dtCRT_DATE; }
            set
            {
                if (value == null)
                    m_dtCRT_DATE.Value = value;
                else
                    m_dtCRT_DATE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CRT_MACHINE", 0, 0, 50)]
        public NZString CRT_MACHINE
        {
            get { return m_strCRT_MACHINE; }
            set
            {
                if (value == null)
                    m_strCRT_MACHINE.Value = value;
                else
                    m_strCRT_MACHINE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "UPD_BY", 0, 0, 30)]
        public NZString UPD_BY
        {
            get { return m_strUPD_BY; }
            set
            {
                if (value == null)
                    m_strUPD_BY.Value = value;
                else
                    m_strUPD_BY = value;
            }
        }
        [Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "UPD_DATE", 23, 3, 8)]
        public NZDateTime UPD_DATE
        {
            get { return m_dtUPD_DATE; }
            set
            {
                if (value == null)
                    m_dtUPD_DATE.Value = value;
                else
                    m_dtUPD_DATE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "UPD_MACHINE", 0, 0, 50)]
        public NZString UPD_MACHINE
        {
            get { return m_strUPD_MACHINE; }
            set
            {
                if (value == null)
                    m_strUPD_MACHINE.Value = value;
                else
                    m_strUPD_MACHINE = value;
            }
        }
        //[FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "TRANS_ID", 0, 0, 30)]
        public NZString TRANS_ID
        {
            get { return m_strTRANS_ID; }
            set
            {
                if (value == null)
                    m_strTRANS_ID.Value = value;
                else
                    m_strTRANS_ID = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "BILL_NO", 0, 0, 30)]
        public NZString BILL_NO
        {
            get { return m_strBILL_NO; }
            set
            {
                if (value == null)
                    m_strBILL_NO.Value = value;
                else
                    m_strBILL_NO = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "DEALING_NO", 0, 0, 30)]
        public NZString DEALING_NO
        {
            get { return m_strDEALING_NO; }
            set
            {
                if (value == null)
                    m_strDEALING_NO.Value = value;
                else
                    m_strDEALING_NO = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.Default, "DELIVERY_NO", 0, 0, 30)]
        public NZString DELIVERY_NO
        {
            get { return m_strDELIVERY_NO; }
            set
            {
                if (value == null)
                    m_strDELIVERY_NO.Value = value;
                else
                    m_strDELIVERY_NO = value;
            }
        }
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Default, "ADDRESS_NO", 10, 0, 4)]
        public NZInt ADDRESS_NO
        {
            get { return m_iADDRESS_NO; }
            set
            {
                if (value == null)
                    m_iADDRESS_NO.Value = value;
                else
                    m_iADDRESS_NO = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ADDRESS", 0, 0, 255)]
        public NZString ADDRESS
        {
            get { return m_strADDRESS; }
            set
            {
                if (value == null)
                    m_strADDRESS.Value = value;
                else
                    m_strADDRESS = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "INVOICE_NO", 0, 0, 50)]
        public NZString INVOICE_NO
        {
            get { return m_strINVOICE_NO; }
            set
            {
                if (value == null)
                    m_strINVOICE_NO.Value = value;
                else
                    m_strINVOICE_NO = value;
            }
        }
        [Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "INVOICE_DATE", 23, 3, 8)]
        public NZDateTime INVOICE_DATE
        {
            get { return m_dtINVOICE_DATE; }
            set
            {
                if (value == null)
                    m_dtINVOICE_DATE.Value = value;
                else
                    m_dtINVOICE_DATE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "TERM_OF_PAYMENT", 0, 0, 30)]
        public NZString TERM_OF_PAYMENT
        {
            get { return m_strTERM_OF_PAYMENT; }
            set
            {
                if (value == null)
                    m_strTERM_OF_PAYMENT.Value = value;
                else
                    m_strTERM_OF_PAYMENT = value;
            }
        }
        [Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "PAYMENT_DUE_DATE", 23, 3, 8)]
        public NZDateTime PAYMENT_DUE_DATE
        {
            get { return m_dtPAYMENT_DUE_DATE; }
            set
            {
                if (value == null)
                    m_dtPAYMENT_DUE_DATE.Value = value;
                else
                    m_dtPAYMENT_DUE_DATE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "REFER_TEM_NO", 0, 0, 255)]
        public NZString REFER_TEM_NO
        {
            get { return m_strREFER_TEM_NO; }
            set
            {
                if (value == null)
                    m_strREFER_TEM_NO.Value = value;
                else
                    m_strREFER_TEM_NO = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "REMARK", 0, 0, 255)]
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
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "SUB_TOTAL", 18, 6, 9)]
        public NZDecimal SUB_TOTAL
        {
            get { return m_dSUB_TOTAL; }
            set
            {
                if (value == null)
                    m_dSUB_TOTAL.Value = value;
                else
                    m_dSUB_TOTAL = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "VAT", 16, 6, 9)]
        public NZDecimal VAT
        {
            get { return m_dVAT; }
            set
            {
                if (value == null)
                    m_dVAT.Value = value;
                else
                    m_dVAT = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "VAT_AMOUNT", 18, 6, 9)]
        public NZDecimal VAT_AMOUNT
        {
            get { return m_dVAT_AMOUNT; }
            set
            {
                if (value == null)
                    m_dVAT_AMOUNT.Value = value;
                else
                    m_dVAT_AMOUNT = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "TOTAL", 18, 6, 9)]
        public NZDecimal TOTAL
        {
            get { return m_dTOTAL; }
            set
            {
                if (value == null)
                    m_dTOTAL.Value = value;
                else
                    m_dTOTAL = value;
            }
        }
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Default, "CANCEL_FLAG", 10, 0, 4)]
        public NZInt CANCEL_FLAG
        {
            get { return m_iCANCEL_FLAG; }
            set
            {
                if (value == null)
                    m_iCANCEL_FLAG.Value = value;
                else
                    m_iCANCEL_FLAG = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "PO_NO", 0, 0, 50)]
        public NZString PO_NO
        {
            get { return m_strPO_NO; }
            set
            {
                if (value == null)
                    m_strPO_NO.Value = value;
                else
                    m_strPO_NO = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ORDER_NO", 0, 0, 30)]
        public NZString ORDER_NO
        {
            get { return m_strORDER_NO; }
            set
            {
                if (value == null)
                    m_strORDER_NO.Value = value;
                else
                    m_strORDER_NO = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ORDER_DETAIL_NO", 0, 0, 30)]
        public NZString ORDER_DETAIL_NO
        {
            get { return m_strORDER_DETAIL_NO; }
            set
            {
                if (value == null)
                    m_strORDER_DETAIL_NO.Value = value;
                else
                    m_strORDER_DETAIL_NO = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ITEM_CD", 0, 0, 30)]
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "SHORT_NAME", 0, 0, 30)]
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ITEM_DESC", 0, 0, 100)]
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "UNIT", 0, 0, 30)]
        public NZString UNIT
        {
            get { return m_strUNIT; }
            set
            {
                if (value == null)
                    m_strUNIT.Value = value;
                else
                    m_strUNIT = value;
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
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "PRICE", 16, 6, 9)]
        public NZDecimal PRICE
        {
            get { return m_dPRICE; }
            set
            {
                if (value == null)
                    m_dPRICE.Value = value;
                else
                    m_dPRICE = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "AMOUNT", 18, 6, 9)]
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
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Default, "OLD_DATA", 10, 0, 4)]
        public NZInt OLD_DATA
        {
            get { return m_iOLD_DATA; }
            set
            {
                if (value == null)
                    m_iOLD_DATA.Value = value;
                else
                    m_iOLD_DATA = value;
            }
        }

        #endregion

        #region " Overriden method "
        /// <summary>
        /// Return array of primary key fields.
        /// </summary>
        /// <remarks>
        /// If this table mapping has not primary key, return null value.
        /// </remarks>
        /// 
        //public override MapKeyValue<string, List<string>> PrimaryKey
        //{
        //    get
        //    {
        //        List<string> values = new List<string>();

        //        //Add MemberColums of PrimaryKey
        //        values.Add(eColumns.TRANS_ID.ToString());

        //        //Add PrimaryKey Name
        //        return new MapKeyValue<string, List<string>>("PK_TB_INVOICE_TR", values);
        //    }
        //}
        #endregion

        #region " Helper "
        /*
		public void SaveDTO() {
			CustomerOrderDDTO dto = new CustomerOrderDDTO();
			dto.CRT_BY = 
			dto.CRT_DATE = 
			dto.CRT_MACHINE = 
			dto.UPD_BY = 
			dto.UPD_DATE = 
			dto.UPD_MACHINE = 
			dto.ORDER_NO = 
			dto.RUN_NO = 
			dto.ITEM_CD = 
			dto.ITEM_DELIVERY_DATE = 
			dto.QTY = 
			dto.PRICE = 
			dto.AMOUNT = 
			dto.AMOUNT_THB = 
			dto.SHIP_QTY = 
			dto.COMPLETE_FLAG = 
			dto.OLD_DATA = 
		}
		*/
        #endregion
    }
}

