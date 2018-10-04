/*
 *		Author: Ms. Sansanee K.
 *      Team : SI-EVO
 * 		Writed On 2012/03/05
 * 		Time : 10:53 AM
 *  	This is DTO for TB_MACHINE_MS Table.
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
    [DataTransferObject("TB_MACHINE_MS", typeof(eColumns))]
    public class MachineDTO : AbstractDTO {
        #region " Enums Columns "
        public enum eColumns {
            CRT_BY,
            CRT_DATE,
            CRT_MACHINE,
            UPD_BY,
            UPD_DATE,
            UPD_MACHINE,
            MACHINE_CD,
            MACHINE_TYPE,
            PROCESS_CD,
            MACHINE_GROUP,
            PROJECT,
            REMARK,
            OLD_DATA,
            TIME_STAMP
        };
        #endregion

        #region " Variables "
        private NZString m_strCRT_BY = new NZString();
        private NZDateTime m_dtCRT_DATE = new NZDateTime();
        private NZString m_strCRT_MACHINE = new NZString();
        private NZString m_strUPD_BY = new NZString();
        private NZDateTime m_dtUPD_DATE = new NZDateTime();
        private NZString m_strUPD_MACHINE = new NZString();
        private NZString m_strMACHINE_CD = new NZString();
        private NZString m_strMACHINE_TYPE = new NZString();
        private NZString m_strPROCESS_CD = new NZString();
        private NZString m_strMACHINE_GROUP = new NZString();
        private NZString m_strPROJECT = new NZString();
        private NZString m_strREMARK = new NZString();
        private NZInt m_iOLD_DATA = new NZInt();
        private NZByteArray m_baTIME_STAMP = new NZByteArray();
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "MACHINE_CD", 0, 0, 30)]
        public NZString MACHINE_CD {
            get { return m_strMACHINE_CD; }
            set {
                if (value == null)
                    m_strMACHINE_CD.Value = value;
                else
                    m_strMACHINE_CD = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "MACHINE_TYPE", 0, 0, 30)]
        public NZString MACHINE_TYPE {
            get { return m_strMACHINE_TYPE; }
            set {
                if (value == null)
                    m_strMACHINE_TYPE.Value = value;
                else
                    m_strMACHINE_TYPE = value;
            }
        }
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "MACHINE_GROUP", 0, 0, 50)]
        public NZString MACHINE_GROUP {
            get { return m_strMACHINE_GROUP; }
            set {
                if (value == null)
                    m_strMACHINE_GROUP.Value = value;
                else
                    m_strMACHINE_GROUP = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "PROJECT", 0, 0, 30)]
        public NZString PROJECT {
            get { return m_strPROJECT; }
            set {
                if (value == null)
                    m_strPROJECT.Value = value;
                else
                    m_strPROJECT = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "REMARK", 0, 0, 255)]
        public NZString REMARK {
            get { return m_strREMARK; }
            set {
                if (value == null)
                    m_strREMARK.Value = value;
                else
                    m_strREMARK = value;
            }
        }
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Int32, "OLD_DATA", 10, 0, 4)]
        public NZInt OLD_DATA {
            get { return m_iOLD_DATA; }
            set {
                if (value == null)
                    m_iOLD_DATA.Value = value;
                else
                    m_iOLD_DATA = value;
            }
        }
        [Field(typeof(System.Byte[]), typeof(NZByteArray), DataType.Object, "TIME_STAMP", 0, 0, 8)]
        public NZByteArray TIME_STAMP {
            get { return m_baTIME_STAMP; }
            set {
                if (value == null)
                    m_baTIME_STAMP.Value = value;
                else
                    m_baTIME_STAMP = value;
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
                values.Add(eColumns.MACHINE_CD.ToString());

                //Add PrimaryKey Name
                return new MapKeyValue<string, List<string>>("PK_TB_MACHINE_MS", values);
            }
        }
        #endregion

        #region " Helper "
        /*
		public void SaveDTO() {
			MachineDTO dto = new MachineDTO();
			dto.CRT_BY = 
			dto.CRT_DATE = 
			dto.CRT_MACHINE = 
			dto.UPD_BY = 
			dto.UPD_DATE = 
			dto.UPD_MACHINE = 
			dto.MACHINE_CD = 
			dto.MACHINE_TYPE = 
			dto.PROCESS_CD = 
			dto.MACHINE_GROUP = 
			dto.PROJECT = 
			dto.REMARK = 
			dto.OLD_DATA = 
			dto.TIME_STAMP = 
		}
		*/
        #endregion
    }
}

