/*
 *		Author: Ms. Sansanee K
 *      Team : SI-EVO
 * 		Writed On 2011/05/31
 * 		Time : 03:02 PM
 *  	This is DTO for TB_CUSTOMER_MS Table.
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
    [DataTransferObject("TB_CUSTOMER_MS", typeof(eColumns))]
    public class CustomerDTO : AbstractDTO {
        #region " Enums Columns "
        public enum eColumns {
            CRT_BY,
            CRT_DATE,
            CRT_MACHINE,
            UPD_BY,
            UPD_DATE,
            UPD_MACHINE,
            IS_ACTIVE,
            CUSTOMER_CODE,
            CUSTOMER_NAME,
            CUSTOMER_TYPE,
            ADDRESS,
            PHONE_NO,
            FAX,
            REMARK,
            DELIVERY_LT
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
        private NZString m_strCUSTOMER_CODE = new NZString();
        private NZString m_strCUSTOMER_NAME = new NZString();
        private NZString m_strCUSTOMER_TYPE = new NZString();
        private NZString m_strADDRESS = new NZString();
        private NZString m_strPHONE_NO = new NZString();
        private NZString m_strFAX = new NZString();
        private NZString m_strREMARK = new NZString();
        private NZDecimal m_dDELIVERY_LT = new NZDecimal();
        #endregion

        #region " Constructor "

        #endregion

        #region " Getter and Setter properties "
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CRT_BY", 0, 0, 15)]
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "UPD_BY", 0, 0, 15)]
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
        [Field(typeof(System.Boolean), typeof(NZBoolean), DataType.Default, "IS_ACTIVE", 1, 0, 1)]
        public NZBoolean IS_ACTIVE {
            get { return m_IS_ACTIVE; }
            set {
                if (value == null)
                    m_IS_ACTIVE.Value = value;
                else
                    m_IS_ACTIVE = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CUSTOMER_CODE", 0, 0, 35)]
        public NZString CUSTOMER_CODE {
            get { return m_strCUSTOMER_CODE; }
            set {
                if (value == null)
                    m_strCUSTOMER_CODE.Value = value;
                else
                    m_strCUSTOMER_CODE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CUSTOMER_NAME", 0, 0, 50)]
        public NZString CUSTOMER_NAME {
            get { return m_strCUSTOMER_NAME; }
            set {
                if (value == null)
                    m_strCUSTOMER_NAME.Value = value;
                else
                    m_strCUSTOMER_NAME = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CUSTOMER_TYPE", 0, 0, 30)]
        public NZString CUSTOMER_TYPE {
            get { return m_strCUSTOMER_TYPE; }
            set {
                if (value == null)
                    m_strCUSTOMER_TYPE.Value = value;
                else
                    m_strCUSTOMER_TYPE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ADDRESS", 0, 0, 255)]
        public NZString ADDRESS {
            get { return m_strADDRESS; }
            set {
                if (value == null)
                    m_strADDRESS.Value = value;
                else
                    m_strADDRESS = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "PHONE_NO", 0, 0, 50)]
        public NZString PHONE_NO {
            get { return m_strPHONE_NO; }
            set {
                if (value == null)
                    m_strPHONE_NO.Value = value;
                else
                    m_strPHONE_NO = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "FAX", 0, 0, 50)]
        public NZString FAX {
            get { return m_strFAX; }
            set {
                if (value == null)
                    m_strFAX.Value = value;
                else
                    m_strFAX = value;
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
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "DELIVERY_LT", 5, 0, 5)]
        public NZDecimal DELIVERY_LT {
            get { return m_dDELIVERY_LT; }
            set {
                if (value == null)
                    m_dDELIVERY_LT.Value = value;
                else
                    m_dDELIVERY_LT = value;
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
                values.Add(eColumns.CUSTOMER_CODE.ToString());

                //Add PrimaryKey Name
                return new MapKeyValue<string, List<string>>("PK_TB_CUSTOMER_MS", values);
            }
        }
        #endregion

        #region " Helper "
        /*
		public void SaveDTO() {
			CustomerDTO dto = new CustomerDTO();
			dto.CRT_BY = 
			dto.CRT_DATE = 
			dto.CRT_MACHINE = 
			dto.UPD_BY = 
			dto.UPD_DATE = 
			dto.UPD_MACHINE = 
			dto.IS_ACTIVE = 
			dto.CUSTOMER_CODE = 
			dto.CUSTOMER_NAME = 
			dto.ADDRESS = 
			dto.PHONE_NO = 
			dto.FAX = 
			dto.REMARK = 
			dto.DELIVERY_LT = 
		}
		*/
        #endregion
    }
}

