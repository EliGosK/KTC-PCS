/*
 *		Author: Ms. Sansanee K
 *      Team : MOU_FUSION
 * 		Writed On 2011/06/28
 * 		Time : 10:58 AM
 *  	This is DTO for WK_PURCHASE_ORDER_H Table.
 *		From Templates Version : 1.0.0
 *		Last Modify Template On : 2009/08/27
 */
#region Using Namespace
using System;
using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Database;
using System.Collections.Generic;
#endregion

namespace Rubik.DTO {
	[Serializable()]
	[DataTransferObject("WK_PURCHASE_ORDER_H", typeof(eColumns))]
    public class TmpPurchaseOrderDTO : AbstractDTO {
		#region " Enums Columns "
		public enum eColumns {
			CRT_BY,
			CRT_DATE,
			CRT_MACHINE,
			UPD_BY,
			UPD_DATE,
			UPD_MACHINE,
			IS_ACTIVE,
			PO_GROUP,
			PO_NO,
			PO_TYPE,
			PO_DATE,
			SUPPLIER_CD,
			SUPPLIER_NAME,
			ADDRESS,
			DELIVERY_TO,
			DELIVERY_TO_NAME,
			DELIVERY_TO_ADDRESS,
			CURRENCY,
			VAT_TYPE,
			VAT_RATE,
			TERM_OF_PAYMENT,
			IS_EXPORT,
			STATUS,
			REMARK,
			PO_LINE,
			ITEM_CD,
			ITEM_DESC,
			DUE_DATE,
			UNIT_PRICE,
			PO_QTY,
			UNIT,
			AMOUNT,
			RECEIVE_QTY,
			BACK_ORDER_QTY,
			LAST_RECEIVE_ID,
			LAST_RECEIVE_DATE,
			RECORD_STATUS
		};
        #endregion
		
		#region " Variables "
		private NZString m_strCRT_BY = new NZString();
		private NZDateTime m_dtCRT_DATE = new NZDateTime();
		private NZString m_strCRT_MACHINE = new NZString();
		private NZString m_strUPD_BY = new NZString();
		private NZDateTime m_dtUPD_DATE = new NZDateTime();
		private NZString m_strUPD_MACHINE = new NZString();
        private NZBoolean m_IS_ACTIVE = new NZBoolean();
		private NZInt m_iPO_GROUP = new NZInt();
		private NZString m_strPO_NO = new NZString();
		private NZString m_strPO_TYPE = new NZString();
		private NZDateTime m_PO_DATE = new NZDateTime();
		private NZString m_strSUPPLIER_CD = new NZString();
		private NZString m_strSUPPLIER_NAME = new NZString();
		private NZString m_strADDRESS = new NZString();
		private NZString m_strDELIVERY_TO = new NZString();
		private NZString m_strDELIVERY_TO_NAME = new NZString();
		private NZString m_strDELIVERY_TO_ADDRESS = new NZString();
		private NZString m_strCURRENCY = new NZString();
		private NZString m_strVAT_TYPE = new NZString();
		private NZDecimal m_dVAT_RATE = new NZDecimal();
		private NZString m_strTERM_OF_PAYMENT = new NZString();
        private NZBoolean m_IS_EXPORT = new NZBoolean();
		private NZString m_strSTATUS = new NZString();
		private NZString m_strREMARK = new NZString();
		private NZDecimal m_dPO_LINE = new NZDecimal();
		private NZString m_strITEM_CD = new NZString();
		private NZString m_strITEM_DESC = new NZString();
        private NZDateTime m_DUE_DATE = new NZDateTime();
		private NZDecimal m_dUNIT_PRICE = new NZDecimal();
		private NZDecimal m_dPO_QTY = new NZDecimal();
		private NZString m_strUNIT = new NZString();
		private NZDecimal m_dAMOUNT = new NZDecimal();
		private NZDecimal m_dRECEIVE_QTY = new NZDecimal();
		private NZDecimal m_dBACK_ORDER_QTY = new NZDecimal();
		private NZString m_strLAST_RECEIVE_ID = new NZString();
		private NZDateTime m_dtLAST_RECEIVE_DATE = new NZDateTime();
		private NZString m_strRECORD_STATUS = new NZString();
        #endregion
		
		#region " Constructor "
		
        #endregion

        #region " Getter and Setter properties "
		[Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CRT_BY", 0, 0, 30)]
		public NZString CRT_BY {
			get { return m_strCRT_BY; }
			set {
				if (value==null)
					m_strCRT_BY.Value = value;
				else
					m_strCRT_BY = value;
			}
		}
		[Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "CRT_DATE", 23, 3, 8)]
		public NZDateTime CRT_DATE {
			get { return m_dtCRT_DATE; }
			set {
				if (value==null)
					m_dtCRT_DATE.Value = value;
				else
					m_dtCRT_DATE = value;
			}
		}
		[Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CRT_MACHINE", 0, 0, 50)]
		public NZString CRT_MACHINE {
			get { return m_strCRT_MACHINE; }
			set {
				if (value==null)
					m_strCRT_MACHINE.Value = value;
				else
					m_strCRT_MACHINE = value;
			}
		}
		[Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "UPD_BY", 0, 0, 30)]
		public NZString UPD_BY {
			get { return m_strUPD_BY; }
			set {
				if (value==null)
					m_strUPD_BY.Value = value;
				else
					m_strUPD_BY = value;
			}
		}
		[Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "UPD_DATE", 23, 3, 8)]
		public NZDateTime UPD_DATE {
			get { return m_dtUPD_DATE; }
			set {
				if (value==null)
					m_dtUPD_DATE.Value = value;
				else
					m_dtUPD_DATE = value;
			}
		}
		[Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "UPD_MACHINE", 0, 0, 50)]
		public NZString UPD_MACHINE {
			get { return m_strUPD_MACHINE; }
			set {
				if (value==null)
					m_strUPD_MACHINE.Value = value;
				else
					m_strUPD_MACHINE = value;
			}
		}
        [Field(typeof(System.Boolean), typeof(NZBoolean), DataType.Boolean, "IS_ACTIVE", 1, 0, 1)]
        public NZBoolean IS_ACTIVE {
			get { return m_IS_ACTIVE; }
			set {
				if (value==null)
					m_IS_ACTIVE.Value = value;
				else
					m_IS_ACTIVE = value;
			}
		}
		[Field(typeof(System.Int32), typeof(NZInt), DataType.Default, "PO_GROUP", 10, 0, 4)]
		public NZInt PO_GROUP {
			get { return m_iPO_GROUP; }
			set {
				if (value==null)
					m_iPO_GROUP.Value = value;
				else
					m_iPO_GROUP = value;
			}
		}
		[Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "PO_NO", 0, 0, 30)]
		public NZString PO_NO {
			get { return m_strPO_NO; }
			set {
				if (value==null)
					m_strPO_NO.Value = value;
				else
					m_strPO_NO = value;
			}
		}
		[Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "PO_TYPE", 0, 0, 30)]
		public NZString PO_TYPE {
			get { return m_strPO_TYPE; }
			set {
				if (value==null)
					m_strPO_TYPE.Value = value;
				else
					m_strPO_TYPE = value;
			}
		}
		[Field(typeof(System.Object), typeof(NZDateTime), DataType.DateTime, "PO_DATE", 10, 0, 3)]
		public NZDateTime PO_DATE {
			get { return m_PO_DATE; }
			set {
				if (value==null)
					m_PO_DATE.Value = value;
				else
					m_PO_DATE = value;
			}
		}
		[Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "SUPPLIER_CD", 0, 0, 30)]
		public NZString SUPPLIER_CD {
			get { return m_strSUPPLIER_CD; }
			set {
				if (value==null)
					m_strSUPPLIER_CD.Value = value;
				else
					m_strSUPPLIER_CD = value;
			}
		}
		[Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "SUPPLIER_NAME", 0, 0, 50)]
		public NZString SUPPLIER_NAME {
			get { return m_strSUPPLIER_NAME; }
			set {
				if (value==null)
					m_strSUPPLIER_NAME.Value = value;
				else
					m_strSUPPLIER_NAME = value;
			}
		}
		[Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ADDRESS", 0, 0, 255)]
		public NZString ADDRESS {
			get { return m_strADDRESS; }
			set {
				if (value==null)
					m_strADDRESS.Value = value;
				else
					m_strADDRESS = value;
			}
		}
		[Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "DELIVERY_TO", 0, 0, 50)]
		public NZString DELIVERY_TO {
			get { return m_strDELIVERY_TO; }
			set {
				if (value==null)
					m_strDELIVERY_TO.Value = value;
				else
					m_strDELIVERY_TO = value;
			}
		}
		[Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "DELIVERY_TO_NAME", 0, 0, 50)]
		public NZString DELIVERY_TO_NAME {
			get { return m_strDELIVERY_TO_NAME; }
			set {
				if (value==null)
					m_strDELIVERY_TO_NAME.Value = value;
				else
					m_strDELIVERY_TO_NAME = value;
			}
		}
		[Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "DELIVERY_TO_ADDRESS", 0, 0, 255)]
		public NZString DELIVERY_TO_ADDRESS {
			get { return m_strDELIVERY_TO_ADDRESS; }
			set {
				if (value==null)
					m_strDELIVERY_TO_ADDRESS.Value = value;
				else
					m_strDELIVERY_TO_ADDRESS = value;
			}
		}
		[Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CURRENCY", 0, 0, 30)]
		public NZString CURRENCY {
			get { return m_strCURRENCY; }
			set {
				if (value==null)
					m_strCURRENCY.Value = value;
				else
					m_strCURRENCY = value;
			}
		}
		[Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "VAT_TYPE", 0, 0, 30)]
		public NZString VAT_TYPE {
			get { return m_strVAT_TYPE; }
			set {
				if (value==null)
					m_strVAT_TYPE.Value = value;
				else
					m_strVAT_TYPE = value;
			}
		}
		[Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "VAT_RATE", 6, 0, 5)]
		public NZDecimal VAT_RATE {
			get { return m_dVAT_RATE; }
			set {
				if (value==null)
					m_dVAT_RATE.Value = value;
				else
					m_dVAT_RATE = value;
			}
		}
		[Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "TERM_OF_PAYMENT", 0, 0, 30)]
		public NZString TERM_OF_PAYMENT {
			get { return m_strTERM_OF_PAYMENT; }
			set {
				if (value==null)
					m_strTERM_OF_PAYMENT.Value = value;
				else
					m_strTERM_OF_PAYMENT = value;
			}
		}
        [Field(typeof(System.Boolean), typeof(NZBoolean), DataType.Boolean, "IS_EXPORT", 1, 0, 1)]
        public NZBoolean IS_EXPORT {
			get { return m_IS_EXPORT; }
			set {
				if (value==null)
					m_IS_EXPORT.Value = value;
				else
					m_IS_EXPORT = value;
			}
		}
		/// <summary>
		/// 0=Open, 1=Auto Complete , 2=Manual Complete
		/// </summary>
		[Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "STATUS", 0, 0, 30)]
		public NZString STATUS {
			get { return m_strSTATUS; }
			set {
				if (value==null)
					m_strSTATUS.Value = value;
				else
					m_strSTATUS = value;
			}
		}
		[Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "REMARK", 0, 0, 255)]
		public NZString REMARK {
			get { return m_strREMARK; }
			set {
				if (value==null)
					m_strREMARK.Value = value;
				else
					m_strREMARK = value;
			}
		}
		[Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "PO_LINE", 16, 0, 9)]
		public NZDecimal PO_LINE {
			get { return m_dPO_LINE; }
			set {
				if (value==null)
					m_dPO_LINE.Value = value;
				else
					m_dPO_LINE = value;
			}
		}
		[Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ITEM_CD", 0, 0, 35)]
		public NZString ITEM_CD {
			get { return m_strITEM_CD; }
			set {
				if (value==null)
					m_strITEM_CD.Value = value;
				else
					m_strITEM_CD = value;
			}
		}
		[Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ITEM_DESC", 0, 0, 50)]
		public NZString ITEM_DESC {
			get { return m_strITEM_DESC; }
			set {
				if (value==null)
					m_strITEM_DESC.Value = value;
				else
					m_strITEM_DESC = value;
			}
		}
		[Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "DUE_DATE", 10, 0, 3)]
		public NZDateTime DUE_DATE {
			get { return m_DUE_DATE; }
			set {
				if (value==null)
					m_DUE_DATE.Value = value;
				else
					m_DUE_DATE = value;
			}
		}
		[Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "UNIT_PRICE", 16, 6, 9)]
		public NZDecimal UNIT_PRICE {
			get { return m_dUNIT_PRICE; }
			set {
				if (value==null)
					m_dUNIT_PRICE.Value = value;
				else
					m_dUNIT_PRICE = value;
			}
		}
		[Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "PO_QTY", 16, 2, 9)]
		public NZDecimal PO_QTY {
			get { return m_dPO_QTY; }
			set {
				if (value==null)
					m_dPO_QTY.Value = value;
				else
					m_dPO_QTY = value;
			}
		}
		[Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "UNIT", 0, 0, 30)]
		public NZString UNIT {
			get { return m_strUNIT; }
			set {
				if (value==null)
					m_strUNIT.Value = value;
				else
					m_strUNIT = value;
			}
		}
		[Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "AMOUNT", 16, 6, 9)]
		public NZDecimal AMOUNT {
			get { return m_dAMOUNT; }
			set {
				if (value==null)
					m_dAMOUNT.Value = value;
				else
					m_dAMOUNT = value;
			}
		}
		[Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "RECEIVE_QTY", 16, 2, 9)]
		public NZDecimal RECEIVE_QTY {
			get { return m_dRECEIVE_QTY; }
			set {
				if (value==null)
					m_dRECEIVE_QTY.Value = value;
				else
					m_dRECEIVE_QTY = value;
			}
		}
		[Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "BACK_ORDER_QTY", 17, 2, 9)]
		public NZDecimal BACK_ORDER_QTY {
			get { return m_dBACK_ORDER_QTY; }
			set {
				if (value==null)
					m_dBACK_ORDER_QTY.Value = value;
				else
					m_dBACK_ORDER_QTY = value;
			}
		}
		[Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "LAST_RECEIVE_ID", 0, 0, 20)]
		public NZString LAST_RECEIVE_ID {
			get { return m_strLAST_RECEIVE_ID; }
			set {
				if (value==null)
					m_strLAST_RECEIVE_ID.Value = value;
				else
					m_strLAST_RECEIVE_ID = value;
			}
		}
		[Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "LAST_RECEIVE_DATE", 23, 3, 8)]
		public NZDateTime LAST_RECEIVE_DATE {
			get { return m_dtLAST_RECEIVE_DATE; }
			set {
				if (value==null)
					m_dtLAST_RECEIVE_DATE.Value = value;
				else
					m_dtLAST_RECEIVE_DATE = value;
			}
		}
		/// <summary>
		/// 00=Open, 01=Auto Complete , 02=Manual Complete
		/// </summary>
		[Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "RECORD_STATUS", 0, 0, 30)]
		public NZString RECORD_STATUS {
			get { return m_strRECORD_STATUS; }
			set {
				if (value==null)
					m_strRECORD_STATUS.Value = value;
				else
					m_strRECORD_STATUS = value;
			}
		}
	
        #endregion
		
		#region " Overriden method "
        #endregion
		
		#region " Helper "
		/*
		public void SaveDTO() {
			TMP_PURCHASE_ORDERDTO dto = new TMP_PURCHASE_ORDERDTO();
			dto.CRT_BY = 
			dto.CRT_DATE = 
			dto.CRT_MACHINE = 
			dto.UPD_BY = 
			dto.UPD_DATE = 
			dto.UPD_MACHINE = 
			dto.IS_ACTIVE = 
			dto.PO_GROUP = 
			dto.PO_NO = 
			dto.PO_TYPE = 
			dto.PO_DATE = 
			dto.SUPPLIER_CD = 
			dto.SUPPLIER_NAME = 
			dto.ADDRESS = 
			dto.DELIVERY_TO = 
			dto.DELIVERY_TO_NAME = 
			dto.DELIVERY_TO_ADDRESS = 
			dto.CURRENCY = 
			dto.VAT_TYPE = 
			dto.VAT_RATE = 
			dto.TERM_OF_PAYMENT = 
			dto.IS_EXPORT = 
			dto.STATUS = 
			dto.REMARK = 
			dto.PO_LINE = 
			dto.ITEM_CD = 
			dto.ITEM_DESC = 
			dto.DUE_DATE = 
			dto.UNIT_PRICE = 
			dto.PO_QTY = 
			dto.UNIT = 
			dto.AMOUNT = 
			dto.RECEIVE_QTY = 
			dto.BACK_ORDER_QTY = 
			dto.LAST_RECEIVE_ID = 
			dto.LAST_RECEIVE_DATE = 
			dto.RECORD_STATUS = 
		}
		*/
		#endregion
	}
}
	
