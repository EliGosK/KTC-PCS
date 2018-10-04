/*
 *		Author: Ms. Sansanee K.
 *      Team : SI-EVO
 * 		Writed On 2012/02/17
 * 		Time : 02:48 PM
 *  	This is DTO for TB_DEALING_MS Table.
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
    [DataTransferObject("TB_DEALING_MS", typeof(eColumns))]
    public class DealingDTO : AbstractDTO {
        #region " Enums Columns "
        public enum eColumns {
            CRT_BY,
            CRT_DATE,
            CRT_MACHINE,
            UPD_BY,
            UPD_DATE,
            UPD_MACHINE,
            LOC_CD,
            LOC_DESC,
            LOC_CLS,
            TERM_OF_PAYMENT,
            INVOICE_PATTERN,
            ADDRESS1,
            TEL1,
            FAX1,
            EMAIL1,
            CONTACT_PERSON1,
            REMARK1,
            ADDRESS2,
            TEL2,
            FAX2,
            EMAIL2,
            CONTACT_PERSON2,
            REMARK2,
            ADDRESS3,
            TEL3,
            FAX3,
            EMAIL3,
            CONTACT_PERSON3,
            REMARK3,
            ALLOW_NEGATIVE,
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
        private NZString m_strLOC_CD = new NZString();
        private NZString m_strLOC_DESC = new NZString();
        private NZString m_strLOC_CLS = new NZString();
        private NZString m_strTERM_OF_PAYMENT = new NZString();
        private NZString m_strINVOICE_PATTERN = new NZString();
        private NZString m_strADDRESS1 = new NZString();
        private NZString m_strTEL1 = new NZString();
        private NZString m_strFAX1 = new NZString();
        private NZString m_strEMAIL1 = new NZString();
        private NZString m_strCONTACT_PERSON1 = new NZString();
        private NZString m_strREMARK1 = new NZString();
        private NZString m_strADDRESS2 = new NZString();
        private NZString m_strTEL2 = new NZString();
        private NZString m_strFAX2 = new NZString();
        private NZString m_strEMAIL2 = new NZString();
        private NZString m_strCONTACT_PERSON2 = new NZString();
        private NZString m_strREMARK2 = new NZString();
        private NZString m_strADDRESS3 = new NZString();
        private NZString m_strTEL3 = new NZString();
        private NZString m_strFAX3 = new NZString();
        private NZString m_strEMAIL3 = new NZString();
        private NZString m_strCONTACT_PERSON3 = new NZString();
        private NZString m_strREMARK3 = new NZString();
        private NZString m_strALLOW_NEGATIVE = new NZString();
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "LOC_CD", 0, 0, 30)]
        public NZString LOC_CD {
            get { return m_strLOC_CD; }
            set {
                if (value == null)
                    m_strLOC_CD.Value = value;
                else
                    m_strLOC_CD = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "LOC_DESC", 0, 0, 50)]
        public NZString LOC_DESC {
            get { return m_strLOC_DESC; }
            set {
                if (value == null)
                    m_strLOC_DESC.Value = value;
                else
                    m_strLOC_DESC = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "LOC_CLS", 0, 0, 30)]
        public NZString LOC_CLS {
            get { return m_strLOC_CLS; }
            set {
                if (value == null)
                    m_strLOC_CLS.Value = value;
                else
                    m_strLOC_CLS = value;
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "INVOICE_PATTERN", 0, 0, 30)]
        public NZString INVOICE_PATTERN
        {
            get { return m_strINVOICE_PATTERN; }
            set
            {
                if (value == null)
                    m_strINVOICE_PATTERN.Value = value;
                else
                    m_strINVOICE_PATTERN = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ADDRESS1", 0, 0, 255)]
        public NZString ADDRESS1 {
            get { return m_strADDRESS1; }
            set {
                if (value == null)
                    m_strADDRESS1.Value = value;
                else
                    m_strADDRESS1 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "TEL1", 0, 0, 50)]
        public NZString TEL1 {
            get { return m_strTEL1; }
            set {
                if (value == null)
                    m_strTEL1.Value = value;
                else
                    m_strTEL1 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "FAX1", 0, 0, 50)]
        public NZString FAX1 {
            get { return m_strFAX1; }
            set {
                if (value == null)
                    m_strFAX1.Value = value;
                else
                    m_strFAX1 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "EMAIL1", 0, 0, 50)]
        public NZString EMAIL1 {
            get { return m_strEMAIL1; }
            set {
                if (value == null)
                    m_strEMAIL1.Value = value;
                else
                    m_strEMAIL1 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CONTACT_PERSON1", 0, 0, 100)]
        public NZString CONTACT_PERSON1 {
            get { return m_strCONTACT_PERSON1; }
            set {
                if (value == null)
                    m_strCONTACT_PERSON1.Value = value;
                else
                    m_strCONTACT_PERSON1 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "REMARK1", 0, 0, 255)]
        public NZString REMARK1 {
            get { return m_strREMARK1; }
            set {
                if (value == null)
                    m_strREMARK1.Value = value;
                else
                    m_strREMARK1 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ADDRESS2", 0, 0, 255)]
        public NZString ADDRESS2 {
            get { return m_strADDRESS2; }
            set {
                if (value == null)
                    m_strADDRESS2.Value = value;
                else
                    m_strADDRESS2 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "TEL2", 0, 0, 50)]
        public NZString TEL2 {
            get { return m_strTEL2; }
            set {
                if (value == null)
                    m_strTEL2.Value = value;
                else
                    m_strTEL2 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "FAX2", 0, 0, 50)]
        public NZString FAX2 {
            get { return m_strFAX2; }
            set {
                if (value == null)
                    m_strFAX2.Value = value;
                else
                    m_strFAX2 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "EMAIL2", 0, 0, 50)]
        public NZString EMAIL2 {
            get { return m_strEMAIL2; }
            set {
                if (value == null)
                    m_strEMAIL2.Value = value;
                else
                    m_strEMAIL2 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CONTACT_PERSON2", 0, 0, 100)]
        public NZString CONTACT_PERSON2 {
            get { return m_strCONTACT_PERSON2; }
            set {
                if (value == null)
                    m_strCONTACT_PERSON2.Value = value;
                else
                    m_strCONTACT_PERSON2 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "REMARK2", 0, 0, 255)]
        public NZString REMARK2 {
            get { return m_strREMARK2; }
            set {
                if (value == null)
                    m_strREMARK2.Value = value;
                else
                    m_strREMARK2 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ADDRESS3", 0, 0, 255)]
        public NZString ADDRESS3 {
            get { return m_strADDRESS3; }
            set {
                if (value == null)
                    m_strADDRESS3.Value = value;
                else
                    m_strADDRESS3 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "TEL3", 0, 0, 50)]
        public NZString TEL3 {
            get { return m_strTEL3; }
            set {
                if (value == null)
                    m_strTEL3.Value = value;
                else
                    m_strTEL3 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "FAX3", 0, 0, 50)]
        public NZString FAX3 {
            get { return m_strFAX3; }
            set {
                if (value == null)
                    m_strFAX3.Value = value;
                else
                    m_strFAX3 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "EMAIL3", 0, 0, 50)]
        public NZString EMAIL3 {
            get { return m_strEMAIL3; }
            set {
                if (value == null)
                    m_strEMAIL3.Value = value;
                else
                    m_strEMAIL3 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CONTACT_PERSON3", 0, 0, 100)]
        public NZString CONTACT_PERSON3 {
            get { return m_strCONTACT_PERSON3; }
            set {
                if (value == null)
                    m_strCONTACT_PERSON3.Value = value;
                else
                    m_strCONTACT_PERSON3 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "REMARK3", 0, 0, 255)]
        public NZString REMARK3 {
            get { return m_strREMARK3; }
            set {
                if (value == null)
                    m_strREMARK3.Value = value;
                else
                    m_strREMARK3 = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ALLOW_NEGATIVE", 0, 0, 30)]
        public NZString ALLOW_NEGATIVE {
            get { return m_strALLOW_NEGATIVE; }
            set {
                if (value == null)
                    m_strALLOW_NEGATIVE.Value = value;
                else
                    m_strALLOW_NEGATIVE = value;
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
                values.Add(eColumns.LOC_CD.ToString());

                //Add PrimaryKey Name
                return new MapKeyValue<string, List<string>>("PK_TB_DEALING_MS", values);
            }
        }
        #endregion

        #region " Helper "
        /*
		public void SaveDTO() {
			DealingDTO dto = new DealingDTO();
			dto.CRT_BY = 
			dto.CRT_DATE = 
			dto.CRT_MACHINE = 
			dto.UPD_BY = 
			dto.UPD_DATE = 
			dto.UPD_MACHINE = 
			dto.LOC_CD = 
			dto.LOC_DESC = 
			dto.LOC_CLS = 
			dto.ADDRESS1 = 
			dto.TEL1 = 
			dto.FAX1 = 
			dto.EMAIL1 = 
			dto.CONTACT_PERSON1 = 
			dto.REMARK1 = 
			dto.ADDRESS2 = 
			dto.TEL2 = 
			dto.FAX2 = 
			dto.EMAIL2 = 
			dto.CONTACT_PERSON2 = 
			dto.REMARK2 = 
			dto.ADDRESS3 = 
			dto.TEL3 = 
			dto.FAX3 = 
			dto.EMAIL3 = 
			dto.CONTACT_PERSON3 = 
			dto.REMARK3 = 
			dto.ALLOW_NEGATIVE = 
			dto.OLD_DATA = 
		}
		*/
        #endregion
    }
}

