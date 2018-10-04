/*
 *		Author: Ms. Sansanee K.
 *      Team : SI-EVO
 * 		Writed On 2012/02/29
 * 		Time : 05:14 PM
 *  	This is DTO for TB_STOCK_TAKING_IMPORT_TR Table.
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
    [DataTransferObject("TB_STOCK_TAKING_IMPORT_TR", typeof(eColumns))]
    public class ImportStockTakingDTO : AbstractDTO {
        #region " Enums Columns "
        public enum eColumns {
            CREATE_BY,
            CREATE_DATE,
            CREATE_MACHINE,
            IMPORT_FILE_NAME,
            LINE_NO,
            PROCESS_CD,
            ITEM_CD,
            WEIGHT,
            QTY,
            TAG_NO,
            REMARK,
            ERROR_DESC
        };
        #endregion

        #region " Variables "
        private NZString m_strCREATE_BY = new NZString();
        private NZDateTime m_dtCREATE_DATE = new NZDateTime();
        private NZString m_strCREATE_MACHINE = new NZString();
        private NZString m_strIMPORT_FILE_NAME = new NZString();
        private NZInt m_iLINE_NO = new NZInt();
        private NZString m_strPROCESS_CD = new NZString();
        private NZString m_strITEM_CD = new NZString();
        private NZString m_strWEIGHT = new NZString();
        private NZString m_strQTY = new NZString();
        private NZString m_strTAG_NO = new NZString();
        private NZString m_strREMARK = new NZString();
        private NZString m_strERROR_DESC = new NZString();
        #endregion

        #region " Constructor "

        #endregion

        #region " Getter and Setter properties "
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CREATE_BY", 0, 0, 30)]
        public NZString CREATE_BY {
            get { return m_strCREATE_BY; }
            set {
                if (value == null)
                    m_strCREATE_BY.Value = value;
                else
                    m_strCREATE_BY = value;
            }
        }
        [Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "CREATE_DATE", 23, 3, 8)]
        public NZDateTime CREATE_DATE {
            get { return m_dtCREATE_DATE; }
            set {
                if (value == null)
                    m_dtCREATE_DATE.Value = value;
                else
                    m_dtCREATE_DATE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CREATE_MACHINE", 0, 0, 50)]
        public NZString CREATE_MACHINE {
            get { return m_strCREATE_MACHINE; }
            set {
                if (value == null)
                    m_strCREATE_MACHINE.Value = value;
                else
                    m_strCREATE_MACHINE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "IMPORT_FILE_NAME", 0, 0, 100)]
        public NZString IMPORT_FILE_NAME {
            get { return m_strIMPORT_FILE_NAME; }
            set {
                if (value == null)
                    m_strIMPORT_FILE_NAME.Value = value;
                else
                    m_strIMPORT_FILE_NAME = value;
            }
        }
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Default, "LINE_NO", 10, 0, 4)]
        public NZInt LINE_NO {
            get { return m_iLINE_NO; }
            set {
                if (value == null)
                    m_iLINE_NO.Value = value;
                else
                    m_iLINE_NO = value;
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ITEM_CD", 0, 0, 30)]
        public NZString ITEM_CD {
            get { return m_strITEM_CD; }
            set {
                if (value == null)
                    m_strITEM_CD.Value = value;
                else
                    m_strITEM_CD = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "WEIGHT", 0, 0, 30)]
        public NZString WEIGHT {
            get { return m_strWEIGHT; }
            set {
                if (value == null)
                    m_strWEIGHT.Value = value;
                else
                    m_strWEIGHT = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "QTY", 0, 0, 30)]
        public NZString QTY {
            get { return m_strQTY; }
            set {
                if (value == null)
                    m_strQTY.Value = value;
                else
                    m_strQTY = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "TAG_NO", 0, 0, 50)]
        public NZString TAG_NO {
            get { return m_strTAG_NO; }
            set {
                if (value == null)
                    m_strTAG_NO.Value = value;
                else
                    m_strTAG_NO = value;
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ERROR_DESC", 0, 0, 255)]
        public NZString ERROR_DESC {
            get { return m_strERROR_DESC; }
            set {
                if (value == null)
                    m_strERROR_DESC.Value = value;
                else
                    m_strERROR_DESC = value;
            }
        }

        #endregion

        #region " Overriden method "
        #endregion

        #region " Helper "
        /*
		public void SaveDTO() {
			ImportStockTakingDTO dto = new ImportStockTakingDTO();
			dto.CREATE_BY = 
			dto.CREATE_DATE = 
			dto.CREATE_MACHINE = 
			dto.IMPORT_FILE_NAME = 
			dto.LINE_NO = 
			dto.PROCESS_CD = 
			dto.ITEM_CD = 
			dto.WEIGHT = 
			dto.QTY = 
			dto.TAG_NO = 
			dto.REMARK = 
			dto.ERROR_DESC = 
		}
		*/
        #endregion
    }
}

