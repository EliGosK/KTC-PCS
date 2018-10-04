/*
 *		Author: Mr.Teerayut S
 *      Team : SI-EVO
 * 		Writed On 2554/06/10
 * 		Time : 09:56 AM
 *  	This is DTO for TB_PURCHASE_ORDER_H_TR Table.
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

namespace Rubik.Data
{
	[Serializable()]
	[DataTransferObject("TB_PURCHASE_ORDER_H_TR", typeof(eColumns))]
	public class PurchaseOrderHDTO : AbstractDTO{
		#region " Enums Columns "
		public enum eColumns {
			CRT_BY,
			CRT_DATE,
			CRT_MACHINE,
			UPD_BY,
			UPD_DATE,
			UPD_MACHINE,
			IS_ACTIVE,
			PO_NO,
			PO_TYPE,
			PO_DATE,
			SUPPLIER_CD,
			SUPPLIER_NAME,
			ADDRESS,
			DELIVERY_TO,
			CURRENCY,
			VAT_TYPE,
			VAT_RATE,
			TERM_OF_PAYMENT,
			IS_EXPORT,
			STATUS,
			REMARK
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
		private NZString m_strPO_NO = new NZString();
		private NZString m_strPO_TYPE = new NZString();
		private NZDateTime m_PO_DATE = new NZDateTime();
		private NZString m_strSUPPLIER_CD = new NZString();
		private NZString m_strSUPPLIER_NAME = new NZString();
		private NZString m_strADDRESS = new NZString();
		private NZString m_strDELIVERY_TO = new NZString();
		private NZString m_strCURRENCY = new NZString();
		private NZString m_strVAT_TYPE = new NZString();
		private NZDecimal m_dVAT_RATE = new NZDecimal();
		private NZString m_strTERM_OF_PAYMENT = new NZString();
		private NZBoolean m_IS_EXPORT = new NZBoolean();
		private NZString m_strSTATUS = new NZString();
		private NZString m_strREMARK = new NZString();
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
		[Field(typeof(System.Boolean), typeof(NZBoolean), DataType.Default, "IS_ACTIVE", 1, 0, 1)]
		public NZBoolean IS_ACTIVE {
			get { return m_IS_ACTIVE; }
			set {
				if (value==null)
					m_IS_ACTIVE.Value = value;
				else
					m_IS_ACTIVE = value;
			}
		}
		[FieldNotNull]
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
		[Field(typeof(System.Object), typeof(NZDateTime), DataType.Default, "PO_DATE", 10, 0, 3)]
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
		[Field(typeof(System.Boolean), typeof(NZBoolean), DataType.Default, "IS_EXPORT", 1, 0, 1)]
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
	
        #endregion
		
		#region " Overriden method "
        /// <summary>
        /// Return array of primary key fields.
        /// </summary>
        /// <remarks>
        /// If this table mapping has not primary key, return null value.
        /// </remarks>
        public override MapKeyValue<string, List<string>> PrimaryKey
        {
            get
            {                                         
                List<string> values = new List<string>();
								
                //Add MemberColums of PrimaryKey
				values.Add(eColumns.PO_NO.ToString());
				
				//Add PrimaryKey Name
				return new MapKeyValue<string, List<string>>("PK_TB_PURCHASE_ORDER_H_TR_1", values);                
            }
        }
        #endregion
		
		#region " Helper "
		/*
		public void SaveDTO() {
			PurchaseOrderHDTO dto = new PurchaseOrderHDTO();
			dto.CRT_BY = 
			dto.CRT_DATE = 
			dto.CRT_MACHINE = 
			dto.UPD_BY = 
			dto.UPD_DATE = 
			dto.UPD_MACHINE = 
			dto.IS_ACTIVE = 
			dto.PO_NO = 
			dto.PO_TYPE = 
			dto.PO_DATE = 
			dto.SUPPLIER_CD = 
			dto.SUPPLIER_NAME = 
			dto.ADDRESS = 
			dto.DELIVERY_TO = 
			dto.CURRENCY = 
			dto.VAT_TYPE = 
			dto.VAT_RATE = 
			dto.TERM_OF_PAYMENT = 
			dto.IS_EXPORT = 
			dto.STATUS = 
			dto.REMARK = 
		}
		*/
		#endregion
	}
}
	
