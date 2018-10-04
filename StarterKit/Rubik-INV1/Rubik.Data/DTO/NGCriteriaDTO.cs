/*
 *		Author: Ms. Sansanee K.
 *      Team : SI-EVO
 * 		Writed On 2012/02/24
 * 		Time : 04:23 PM
 *  	This is DTO for TB_NG_CRITERIA_MS Table.
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
    [DataTransferObject("TB_NG_CRITERIA_MS", typeof(eColumns))]
    public class NGCriteriaDTO : AbstractDTO {
        #region " Enums Columns "
        public enum eColumns {
            CRT_BY,
            CRT_DATE,
            CRT_MACHINE,
            UPD_BY,
            UPD_DATE,
            UPD_MACHINE,
            PROCESS_CD,
            NG_CRITERIA_CD,
            NG_CRITERIA_DESC,
            OLD_DATA
        };
        #endregion

        #region " Variables "
        private NZString m_strCRT_BY = new NZString();
        private NZDateTime m_dtCRT_DATE = new NZDateTime();
        private NZString m_strCRT_MACHINE = new NZString();
        private NZString m_strUPD_BY = new NZString();
        private NZDateTime m_dtUPD_DATE = new NZDateTime();
        private NZString m_strUPD_MACHINE = new NZString();
        private NZString m_strPROCESS_CD = new NZString();
        private NZString m_strNG_CRITERIA_CD = new NZString();
        private NZString m_strNG_CRITERIA_DESC = new NZString();
        private NZInt m_iOLD_DATA = new NZInt();
        #endregion

        #region " Constructor "

        #endregion

        #region " Getter and Setter properties "
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CRT_BY", 0, 0, 30)]
        public NZString CRT_BY {
            get { return m_strCRT_BY; }
            set {
                if (value == null)
                    m_strCRT_BY.Value = value;
                else
                    m_strCRT_BY = value;
            }
        }
        [Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "CRT_DATE", 23, 3, 8)]
        public NZDateTime CRT_DATE {
            get { return m_dtCRT_DATE; }
            set {
                if (value == null)
                    m_dtCRT_DATE.Value = value;
                else
                    m_dtCRT_DATE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CRT_MACHINE", 0, 0, 50)]
        public NZString CRT_MACHINE {
            get { return m_strCRT_MACHINE; }
            set {
                if (value == null)
                    m_strCRT_MACHINE.Value = value;
                else
                    m_strCRT_MACHINE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "UPD_BY", 0, 0, 30)]
        public NZString UPD_BY {
            get { return m_strUPD_BY; }
            set {
                if (value == null)
                    m_strUPD_BY.Value = value;
                else
                    m_strUPD_BY = value;
            }
        }
        [Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "UPD_DATE", 23, 3, 8)]
        public NZDateTime UPD_DATE {
            get { return m_dtUPD_DATE; }
            set {
                if (value == null)
                    m_dtUPD_DATE.Value = value;
                else
                    m_dtUPD_DATE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "UPD_MACHINE", 0, 0, 50)]
        public NZString UPD_MACHINE {
            get { return m_strUPD_MACHINE; }
            set {
                if (value == null)
                    m_strUPD_MACHINE.Value = value;
                else
                    m_strUPD_MACHINE = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "PROCESS_CD", 0, 0, 30)]
        public NZString PROCESS_CD {
            get { return m_strPROCESS_CD; }
            set {
                if (value == null)
                    m_strPROCESS_CD.Value = value;
                else
                    m_strPROCESS_CD = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "NG_CRITERIA_CD", 0, 0, 30)]
        public NZString NG_CRITERIA_CD {
            get { return m_strNG_CRITERIA_CD; }
            set {
                if (value == null)
                    m_strNG_CRITERIA_CD.Value = value;
                else
                    m_strNG_CRITERIA_CD = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "NG_CRITERIA_DESC", 0, 0, 100)]
        public NZString NG_CRITERIA_DESC {
            get { return m_strNG_CRITERIA_DESC; }
            set {
                if (value == null)
                    m_strNG_CRITERIA_DESC.Value = value;
                else
                    m_strNG_CRITERIA_DESC = value;
            }
        }
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Default, "OLD_DATA", 10, 0, 4)]
        public NZInt OLD_DATA {
            get { return m_iOLD_DATA; }
            set {
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
        public override MapKeyValue<string, List<string>> PrimaryKey {
            get {
                List<string> values = new List<string>();

                //Add MemberColums of PrimaryKey
                values.Add(eColumns.PROCESS_CD.ToString());
                values.Add(eColumns.NG_CRITERIA_CD.ToString());

                //Add PrimaryKey Name
                return new MapKeyValue<string, List<string>>("PK_TB_NG_CRITERIA_MS", values);
            }
        }
        #endregion

        #region " Helper "
        /*
		public void SaveDTO() {
			NGCriteriaDTO dto = new NGCriteriaDTO();
			dto.CRT_BY = 
			dto.CRT_DATE = 
			dto.CRT_MACHINE = 
			dto.UPD_BY = 
			dto.UPD_DATE = 
			dto.UPD_MACHINE = 
			dto.PROCESS_CD = 
			dto.NG_CRITERIA_CD = 
			dto.NG_CRITERIA_DESC = 
			dto.OLD_DATA = 
		}
		*/
        #endregion
    }
}

