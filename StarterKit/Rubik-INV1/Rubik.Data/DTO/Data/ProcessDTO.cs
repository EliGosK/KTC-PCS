/*
 *		Author: Ms. Sansanee K
 *      Team : MOU_FUSION
 * 		Writed On 2011/06/09
 * 		Time : 11:16 AM
 *  	This is DTO for TB_PROCESS_TR Table.
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

namespace Rubik.Data {
    [Serializable()]
    [DataTransferObject("TB_PROCESS_TR", typeof(eColumns))]
    public class ProcessDTO : AbstractDTO {
        #region " Enums Columns "
        public enum eColumns {
            PROCESS_NO,
            PROCESS_TYPE,
            STATUS,
            DESCRIPTION,
            START_PRCS_TIME,
            END_PRCS_TIME,
            FILTER_TIMESTAMP,
            FILE_NAME,
            MD5SUM,
            IS_CANCEL,
            CANCEL_DATE,
            CANCEL_BY,
            CANCEL_MACHINE,
            PROCESS_DATE,
            PROCESS_BY,
            PROCESS_MACHINE,
            RESERVE1,
            RESERVE2
        };
        #endregion

        #region " Variables "
        private NZString m_strPROCESS_NO = new NZString();
        private NZString m_strPROCESS_TYPE = new NZString();
        private NZString m_strSTATUS = new NZString();
        private NZString m_strDESCRIPTION = new NZString();
        private NZDateTime m_dtSTART_PRCS_TIME = new NZDateTime();
        private NZDateTime m_dtEND_PRCS_TIME = new NZDateTime();
        private NZDateTime m_baFILTER_TIMESTAMP = new NZDateTime();
        private NZString m_strFILE_NAME = new NZString();
        private NZString m_strMD5SUM = new NZString();
        private NZDecimal m_dIS_CANCEL = new NZDecimal();
        private NZDateTime m_dtCANCEL_DATE = new NZDateTime();
        private NZString m_strCANCEL_BY = new NZString();
        private NZString m_strCANCEL_MACHINE = new NZString();
        private NZDateTime m_dtPROCESS_DATE = new NZDateTime();
        private NZString m_strPROCESS_BY = new NZString();
        private NZString m_strPROCESS_MACHINE = new NZString();
        private NZString m_strRESERVE1 = new NZString();
        private NZString m_strRESERVE2 = new NZString();
        #endregion

        #region " Constructor "

        #endregion

        #region " Getter and Setter properties "
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "PROCESS_NO", 0, 0, 30)]
        public NZString PROCESS_NO {
            get { return m_strPROCESS_NO; }
            set {
                if (value == null)
                    m_strPROCESS_NO.Value = value;
                else
                    m_strPROCESS_NO = value;
            }
        }
        /// <summary>
        /// ‘MRP’ – MRP Process,
        /// </summary>
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "PROCESS_TYPE", 0, 0, 5)]
        public NZString PROCESS_TYPE {
            get { return m_strPROCESS_TYPE; }
            set {
                if (value == null)
                    m_strPROCESS_TYPE.Value = value;
                else
                    m_strPROCESS_TYPE = value;
            }
        }
        /// <summary>
        /// S: Start Process, Q : Queue,  P : Processing, T : Terminated, W : Complete with Warning,  F : Process Finish Normally, E : Process
        /// </summary>
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "STATUS", 0, 0, 5)]
        public NZString STATUS {
            get { return m_strSTATUS; }
            set {
                if (value == null)
                    m_strSTATUS.Value = value;
                else
                    m_strSTATUS = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "DESCRIPTION", 0, 0, 200)]
        public NZString DESCRIPTION {
            get { return m_strDESCRIPTION; }
            set {
                if (value == null)
                    m_strDESCRIPTION.Value = value;
                else
                    m_strDESCRIPTION = value;
            }
        }
        [Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "START_PRCS_TIME", 23, 3, 8)]
        public NZDateTime START_PRCS_TIME {
            get { return m_dtSTART_PRCS_TIME; }
            set {
                if (value == null)
                    m_dtSTART_PRCS_TIME.Value = value;
                else
                    m_dtSTART_PRCS_TIME = value;
            }
        }
        [Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "END_PRCS_TIME", 23, 3, 8)]
        public NZDateTime END_PRCS_TIME {
            get { return m_dtEND_PRCS_TIME; }
            set {
                if (value == null)
                    m_dtEND_PRCS_TIME.Value = value;
                else
                    m_dtEND_PRCS_TIME = value;
            }
        }
        [Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "FILTER_TIMESTAMP", 23, 3, 8)]
        public NZDateTime FILTER_TIMESTAMP {
            get { return m_baFILTER_TIMESTAMP; }
            set {
                if (value == null)
                    m_baFILTER_TIMESTAMP.Value = value;
                else
                    m_baFILTER_TIMESTAMP = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "FILE_NAME", 0, 0, 100)]
        public NZString FILE_NAME {
            get { return m_strFILE_NAME; }
            set {
                if (value == null)
                    m_strFILE_NAME.Value = value;
                else
                    m_strFILE_NAME = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "MD5SUM", 0, 0, 100)]
        public NZString MD5SUM {
            get { return m_strMD5SUM; }
            set {
                if (value == null)
                    m_strMD5SUM.Value = value;
                else
                    m_strMD5SUM = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "IS_CANCEL", 1, 0, 5)]
        public NZDecimal IS_CANCEL {
            get { return m_dIS_CANCEL; }
            set {
                if (value == null)
                    m_dIS_CANCEL.Value = value;
                else
                    m_dIS_CANCEL = value;
            }
        }
        [Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "CANCEL_DATE", 23, 3, 8)]
        public NZDateTime CANCEL_DATE {
            get { return m_dtCANCEL_DATE; }
            set {
                if (value == null)
                    m_dtCANCEL_DATE.Value = value;
                else
                    m_dtCANCEL_DATE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CANCEL_BY", 0, 0, 30)]
        public NZString CANCEL_BY {
            get { return m_strCANCEL_BY; }
            set {
                if (value == null)
                    m_strCANCEL_BY.Value = value;
                else
                    m_strCANCEL_BY = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CANCEL_MACHINE", 0, 0, 100)]
        public NZString CANCEL_MACHINE {
            get { return m_strCANCEL_MACHINE; }
            set {
                if (value == null)
                    m_strCANCEL_MACHINE.Value = value;
                else
                    m_strCANCEL_MACHINE = value;
            }
        }
        [Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "PROCESS_DATE", 23, 3, 8)]
        public NZDateTime PROCESS_DATE {
            get { return m_dtPROCESS_DATE; }
            set {
                if (value == null)
                    m_dtPROCESS_DATE.Value = value;
                else
                    m_dtPROCESS_DATE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "PROCESS_BY", 0, 0, 30)]
        public NZString PROCESS_BY {
            get { return m_strPROCESS_BY; }
            set {
                if (value == null)
                    m_strPROCESS_BY.Value = value;
                else
                    m_strPROCESS_BY = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "PROCESS_MACHINE", 0, 0, 100)]
        public NZString PROCESS_MACHINE {
            get { return m_strPROCESS_MACHINE; }
            set {
                if (value == null)
                    m_strPROCESS_MACHINE.Value = value;
                else
                    m_strPROCESS_MACHINE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "RESERVE1", 0, 0, 100)]
        public NZString RESERVE1 {
            get { return m_strRESERVE1; }
            set {
                if (value == null)
                    m_strRESERVE1.Value = value;
                else
                    m_strRESERVE1 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "RESERVE2", 0, 0, 100)]
        public NZString RESERVE2 {
            get { return m_strRESERVE2; }
            set {
                if (value == null)
                    m_strRESERVE2.Value = value;
                else
                    m_strRESERVE2 = value;
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
                values.Add(eColumns.PROCESS_NO.ToString());

                //Add PrimaryKey Name
                return new MapKeyValue<string, List<string>>("PK_TB_PROCESS_TR", values);
            }
        }
        #endregion

        #region " Helper "
        /*
		public void SaveDTO() {
			ProcessDTO dto = new ProcessDTO();
			dto.PROCESS_NO = 
			dto.PROCESS_TYPE = 
			dto.STATUS = 
			dto.DESCRIPTION = 
			dto.START_PRCS_TIME = 
			dto.END_PRCS_TIME = 
			dto.FILTER_TIMESTAMP = 
			dto.FILE_NAME = 
			dto.MD5SUM = 
			dto.IS_CANCEL = 
			dto.CANCEL_DATE = 
			dto.CANCEL_BY = 
			dto.CANCEL_MACHINE = 
			dto.PROCESS_DATE = 
			dto.PROCESS_BY = 
			dto.PROCESS_MACHINE = 
			dto.RESERVE1 = 
			dto.RESERVE2 = 
		}
		*/
        #endregion
    }
}

