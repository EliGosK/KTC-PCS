/*
 *		Author: Mr.Teerayut S
 *      Team : SI-EVO
 * 		Writed On 2554/05/31
 * 		Time : 12:38 PM
 *  	This is DTO for TB_FACTORY_CALENDAR_MS Table.
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

namespace Rubik.DTO
{
	[Serializable()]
	[DataTransferObject("TB_FACTORY_CALENDAR_MS", typeof(eColumns))]
	public class WorkingCalendarDTO : AbstractDTO{
		#region " Enums Columns "
		public enum eColumns {
			CRT_BY,
			CRT_DATE,
			CRT_MACHINE,
			UPD_BY,
			UPD_DATE,
			UPD_MACHINE,
			IS_ACTIVE,
			PERIOD,
			CALENDAR_STRING
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
		private NZDateTime m_PERIOD = new NZDateTime();
		private NZString m_strCALENDAR_STRING = new NZString();
        #endregion
		
		#region " Constructor "
		
        #endregion

        #region " Getter and Setter properties "
		[Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CRT_BY", 0, 0, 15)]
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
		[Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "UPD_BY", 0, 0, 15)]
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
		[Field(typeof(System.Object), typeof(NZDateTime), DataType.Default, "PERIOD", 10, 0, 3)]
        public NZDateTime PERIOD
        {
			get { return m_PERIOD; }
			set {
				if (value==null)
					m_PERIOD.Value = value;
				else
					m_PERIOD = value;
			}
		}
		/// <summary>
		/// Holiday Date=0; Working Date=1, Is not Date: space, Fix Length=31
		/// </summary>
		[FieldNotNull]
		[Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CALENDAR_STRING", 0, 0, 200)]
		public NZString CALENDAR_STRING {
			get { return m_strCALENDAR_STRING; }
			set {
				if (value==null)
					m_strCALENDAR_STRING.Value = value;
				else
					m_strCALENDAR_STRING = value;
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
				values.Add(eColumns.PERIOD.ToString());
				
				//Add PrimaryKey Name
				return new MapKeyValue<string, List<string>>("PK_TB_WORKING_CALENDAR_MS", values);                
            }
        }
        #endregion
		
		#region " Helper "
		/*
		public void SaveDTO() {
			WorkingCalendarDTO dto = new WorkingCalendarDTO();
			dto.CRT_BY = 
			dto.CRT_DATE = 
			dto.CRT_MACHINE = 
			dto.UPD_BY = 
			dto.UPD_DATE = 
			dto.UPD_MACHINE = 
			dto.IS_ACTIVE = 
			dto.PERIOD = 
			dto.CALENDAR_STRING = 
		}
		*/
		#endregion
	}
}
	
