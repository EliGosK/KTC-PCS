/*
 *		Author: Ms. Sansanee K
 *      Team : SI-EVO
 * 		Writed On 2011/05/31
 * 		Time : 03:19 PM
 *  	This is DTO for WK_DEMAND_ORDER Table.
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
	[DataTransferObject("WK_DEMAND_ORDER", typeof(eColumns))]
	public class TmpDemandOrderDTO : AbstractDTO{
		#region " Enums Columns "
		public enum eColumns {
			CRT_BY,
			CRT_DATE,
			CRT_MACHINE,
			YEAR_MONTH,
			CUSTOMER_CD,
			DUE_DATE,
			ITEM_CD,
            ITEM_DESC,
			ORDER_QTY,
			ORDER_TYPE
		};
        #endregion
		
		#region " Variables "
		private NZString m_strCRT_BY = new NZString();
		private NZDateTime m_dtCRT_DATE = new NZDateTime();
		private NZString m_strCRT_MACHINE = new NZString();
		private NZDateTime m_YEAR_MONTH = new NZDateTime();
		private NZString m_strCUSTOMER_CD = new NZString();
		private NZDateTime m_dtDUE_DATE = new NZDateTime();
		private NZString m_strITEM_CD = new NZString();
        private NZString m_strITEM_DESC = new NZString();
		private NZDecimal m_dORDER_QTY = new NZDecimal();
		private NZString m_strORDER_TYPE = new NZString();
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
		[Field(typeof(System.DateTime), typeof(NZDateTime), DataType.Default, "YEAR_MONTH", 10, 0, 3)]
        public NZDateTime YEAR_MONTH {
			get { return m_YEAR_MONTH; }
			set {
				if (value==null)
					m_YEAR_MONTH.Value = value;
				else
					m_YEAR_MONTH = value;
			}
		}
		[FieldNotNull]
		[Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CUSTOMER_CD", 0, 0, 35)]
		public NZString CUSTOMER_CD {
			get { return m_strCUSTOMER_CD; }
			set {
				if (value==null)
					m_strCUSTOMER_CD.Value = value;
				else
					m_strCUSTOMER_CD = value;
			}
		}
		[FieldNotNull]
		[Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "DUE_DATE", 23, 3, 8)]
		public NZDateTime DUE_DATE {
			get { return m_dtDUE_DATE; }
			set {
				if (value==null)
					m_dtDUE_DATE.Value = value;
				else
					m_dtDUE_DATE = value;
			}
		}
		[FieldNotNull]
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
                if (value == null)
                    m_strITEM_DESC.Value = value;
                else
                    m_strITEM_DESC = value;
            }
        }
		[FieldNotNull]
		[Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "ORDER_QTY", 16, 2, 9)]
		public NZDecimal ORDER_QTY {
			get { return m_dORDER_QTY; }
			set {
				if (value==null)
					m_dORDER_QTY.Value = value;
				else
					m_dORDER_QTY = value;
			}
		}
		[Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ORDER_TYPE", 0, 0, 50)]
		public NZString ORDER_TYPE {
			get { return m_strORDER_TYPE; }
			set {
				if (value==null)
					m_strORDER_TYPE.Value = value;
				else
					m_strORDER_TYPE = value;
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
				values.Add(eColumns.CUSTOMER_CD.ToString());
				values.Add(eColumns.DUE_DATE.ToString());
				values.Add(eColumns.ITEM_CD.ToString());
				
				//Add PrimaryKey Name
				return new MapKeyValue<string, List<string>>("PK_WK_DEMAND_ORDER", values);                
            }
        }
        #endregion
		
		#region " Helper "
		/*
		public void SaveDTO() {
			TmpDemandOrderDTO dto = new TmpDemandOrderDTO();
			dto.CRT_BY = 
			dto.CRT_DATE = 
			dto.CRT_MACHINE = 
			dto.YEAR_MONTH = 
			dto.CUSTOMER_CD = 
			dto.DUE_DATE = 
			dto.ITEM_CD = 
			dto.ORDER_QTY = 
			dto.ORDER_TYPE = 
		}
		*/
		#endregion
	}
}
	
