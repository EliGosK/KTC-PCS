
/*
 *		Author: Teerayut S. And Kung I.
 *      Team : SI-EVO
 * 		Writed On 2009/08/28
 * 		Time : 11:12 AM
 *  	This is Data Layer for VENDOR_CUSTOMER_TAB Table.
 *		From Templates Version : 1.0.0
 *		Last Modify Template On : 2009/08/24
 */
#region Using Namespace

using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Database;
using System.Collections.Generic;
#endregion

namespace SystemMaintenance.DTO
{
    [DataTransferObject("VENDOR_CUSTOMER_TAB", typeof(eColumns))]
    public class VENDOR_CUSTOMER_TABDTO : AbstractDTO
    {
        #region " Enums Columns "
        public enum eColumns
        {
            VENDOR_CODE,
            VENDOR_NAME,
            ADDRESS1,
            ADDRESS2,
            POSTAL_CODE,
            TELEPHONE_NO,
            FAX_NO,
            VENDOR_CHARGE,
            ORGANIZATION_TYPE,
            VENDOR_TYPE,
            MRP_TARGET_TYPE,
            PU_OFFSET_CODE,
            PU_LEAD_TIME_GROSS,
            PU_LEAD_TIME_SAFETY,
            SHIP_LEAD_TIME_GROSS,
            SHIP_LEAD_TIME_SAFETY,
            SHIP_LEAD_TIME_NET,
            PU_LEAD_TIME_NET,
            CREATE_DATE,
            CREATE_USER,
            LAST_UPD_DATE,
            LAST_UPD_USER,
            SHIP_OFFSET_CODE,
            IS_ALT_DLV
        };
        #endregion

        #region " Variables "
        private NZString m_strVENDOR_CODE = new NZString();
        private NZString m_strVENDOR_NAME = new NZString();
        private NZString m_strADDRESS1 = new NZString();
        private NZString m_strADDRESS2 = new NZString();
        private NZString m_strPOSTAL_CODE = new NZString();
        private NZString m_strTELEPHONE_NO = new NZString();
        private NZString m_strFAX_NO = new NZString();
        private NZString m_strVENDOR_CHARGE = new NZString();
        private NZString m_strORGANIZATION_TYPE = new NZString();
        private NZString m_strVENDOR_TYPE = new NZString();
        private NZString m_strMRP_TARGET_TYPE = new NZString();
        private NZString m_strPU_OFFSET_CODE = new NZString();
        private NZInt m_iPU_LEAD_TIME_GROSS = new NZInt();
        private NZInt m_iPU_LEAD_TIME_SAFETY = new NZInt();
        private NZInt m_iSHIP_LEAD_TIME_GROSS = new NZInt();
        private NZInt m_iSHIP_LEAD_TIME_SAFETY = new NZInt();
        private NZInt m_iSHIP_LEAD_TIME_NET = new NZInt();
        private NZInt m_iPU_LEAD_TIME_NET = new NZInt();
        private NZDateTime m_dtCREATE_DATE = new NZDateTime();
        private NZString m_strCREATE_USER = new NZString();
        private NZDateTime m_dtLAST_UPD_DATE = new NZDateTime();
        private NZString m_strLAST_UPD_USER = new NZString();
        private NZString m_strSHIP_OFFSET_CODE = new NZString();
        private NZString m_strIS_ALT_DLV = new NZString();
        #endregion

        #region " Constructor "

        #endregion

        #region Getter and Setter properties
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.VarChar, "VENDOR_CODE", 0, 0, 32)]
        public NZString VENDOR_CODE
        {
            get { return m_strVENDOR_CODE; }
            set
            {
                if (value == null)
                    m_strVENDOR_CODE.Value = value;
                else
                    m_strVENDOR_CODE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.VarChar, "VENDOR_NAME", 0, 0, 160)]
        public NZString VENDOR_NAME
        {
            get { return m_strVENDOR_NAME; }
            set
            {
                if (value == null)
                    m_strVENDOR_NAME.Value = value;
                else
                    m_strVENDOR_NAME = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.VarChar, "ADDRESS1", 0, 0, 1020)]
        public NZString ADDRESS1
        {
            get { return m_strADDRESS1; }
            set
            {
                if (value == null)
                    m_strADDRESS1.Value = value;
                else
                    m_strADDRESS1 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.VarChar, "ADDRESS2", 0, 0, 1020)]
        public NZString ADDRESS2
        {
            get { return m_strADDRESS2; }
            set
            {
                if (value == null)
                    m_strADDRESS2.Value = value;
                else
                    m_strADDRESS2 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.VarChar, "POSTAL_CODE", 0, 0, 32)]
        public NZString POSTAL_CODE
        {
            get { return m_strPOSTAL_CODE; }
            set
            {
                if (value == null)
                    m_strPOSTAL_CODE.Value = value;
                else
                    m_strPOSTAL_CODE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.VarChar, "TELEPHONE_NO", 0, 0, 48)]
        public NZString TELEPHONE_NO
        {
            get { return m_strTELEPHONE_NO; }
            set
            {
                if (value == null)
                    m_strTELEPHONE_NO.Value = value;
                else
                    m_strTELEPHONE_NO = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.VarChar, "FAX_NO", 0, 0, 48)]
        public NZString FAX_NO
        {
            get { return m_strFAX_NO; }
            set
            {
                if (value == null)
                    m_strFAX_NO.Value = value;
                else
                    m_strFAX_NO = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.VarChar, "VENDOR_CHARGE", 0, 0, 80)]
        public NZString VENDOR_CHARGE
        {
            get { return m_strVENDOR_CHARGE; }
            set
            {
                if (value == null)
                    m_strVENDOR_CHARGE.Value = value;
                else
                    m_strVENDOR_CHARGE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.VarChar, "ORGANIZATION_TYPE", 0, 0, 4)]
        public NZString ORGANIZATION_TYPE
        {
            get { return m_strORGANIZATION_TYPE; }
            set
            {
                if (value == null)
                    m_strORGANIZATION_TYPE.Value = value;
                else
                    m_strORGANIZATION_TYPE = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.VarChar, "VENDOR_TYPE", 0, 0, 4)]
        public NZString VENDOR_TYPE
        {
            get { return m_strVENDOR_TYPE; }
            set
            {
                if (value == null)
                    m_strVENDOR_TYPE.Value = value;
                else
                    m_strVENDOR_TYPE = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.VarChar, "MRP_TARGET_TYPE", 0, 0, 4)]
        public NZString MRP_TARGET_TYPE
        {
            get { return m_strMRP_TARGET_TYPE; }
            set
            {
                if (value == null)
                    m_strMRP_TARGET_TYPE.Value = value;
                else
                    m_strMRP_TARGET_TYPE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.VarChar, "PU_OFFSET_CODE", 0, 0, 8)]
        public NZString PU_OFFSET_CODE
        {
            get { return m_strPU_OFFSET_CODE; }
            set
            {
                if (value == null)
                    m_strPU_OFFSET_CODE.Value = value;
                else
                    m_strPU_OFFSET_CODE = value;
            }
        }
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Number, "PU_LEAD_TIME_GROSS", 2, 0, 0)]
        public NZInt PU_LEAD_TIME_GROSS
        {
            get { return m_iPU_LEAD_TIME_GROSS; }
            set
            {
                if (value == null)
                    m_iPU_LEAD_TIME_GROSS.Value = value;
                else
                    m_iPU_LEAD_TIME_GROSS = value;
            }
        }
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Number, "PU_LEAD_TIME_SAFETY", 2, 0, 0)]
        public NZInt PU_LEAD_TIME_SAFETY
        {
            get { return m_iPU_LEAD_TIME_SAFETY; }
            set
            {
                if (value == null)
                    m_iPU_LEAD_TIME_SAFETY.Value = value;
                else
                    m_iPU_LEAD_TIME_SAFETY = value;
            }
        }
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Number, "SHIP_LEAD_TIME_GROSS", 2, 0, 0)]
        public NZInt SHIP_LEAD_TIME_GROSS
        {
            get { return m_iSHIP_LEAD_TIME_GROSS; }
            set
            {
                if (value == null)
                    m_iSHIP_LEAD_TIME_GROSS.Value = value;
                else
                    m_iSHIP_LEAD_TIME_GROSS = value;
            }
        }
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Number, "SHIP_LEAD_TIME_SAFETY", 2, 0, 0)]
        public NZInt SHIP_LEAD_TIME_SAFETY
        {
            get { return m_iSHIP_LEAD_TIME_SAFETY; }
            set
            {
                if (value == null)
                    m_iSHIP_LEAD_TIME_SAFETY.Value = value;
                else
                    m_iSHIP_LEAD_TIME_SAFETY = value;
            }
        }
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Number, "SHIP_LEAD_TIME_NET", 4, 0, 0)]
        public NZInt SHIP_LEAD_TIME_NET
        {
            get { return m_iSHIP_LEAD_TIME_NET; }
            set
            {
                if (value == null)
                    m_iSHIP_LEAD_TIME_NET.Value = value;
                else
                    m_iSHIP_LEAD_TIME_NET = value;
            }
        }
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Number, "PU_LEAD_TIME_NET", 4, 0, 0)]
        public NZInt PU_LEAD_TIME_NET
        {
            get { return m_iPU_LEAD_TIME_NET; }
            set
            {
                if (value == null)
                    m_iPU_LEAD_TIME_NET.Value = value;
                else
                    m_iPU_LEAD_TIME_NET = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "CREATE_DATE", 0, 0, 0)]
        public NZDateTime CREATE_DATE
        {
            get { return m_dtCREATE_DATE; }
            set
            {
                if (value == null)
                    m_dtCREATE_DATE.Value = value;
                else
                    m_dtCREATE_DATE = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.VarChar, "CREATE_USER", 0, 0, 100)]
        public NZString CREATE_USER
        {
            get { return m_strCREATE_USER; }
            set
            {
                if (value == null)
                    m_strCREATE_USER.Value = value;
                else
                    m_strCREATE_USER = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "LAST_UPD_DATE", 0, 0, 0)]
        public NZDateTime LAST_UPD_DATE
        {
            get { return m_dtLAST_UPD_DATE; }
            set
            {
                if (value == null)
                    m_dtLAST_UPD_DATE.Value = value;
                else
                    m_dtLAST_UPD_DATE = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.VarChar, "LAST_UPD_USER", 0, 0, 100)]
        public NZString LAST_UPD_USER
        {
            get { return m_strLAST_UPD_USER; }
            set
            {
                if (value == null)
                    m_strLAST_UPD_USER.Value = value;
                else
                    m_strLAST_UPD_USER = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.VarChar, "SHIP_OFFSET_CODE", 0, 0, 8)]
        public NZString SHIP_OFFSET_CODE
        {
            get { return m_strSHIP_OFFSET_CODE; }
            set
            {
                if (value == null)
                    m_strSHIP_OFFSET_CODE.Value = value;
                else
                    m_strSHIP_OFFSET_CODE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.VarChar, "IS_ALT_DLV", 0, 0, 4)]
        public NZString IS_ALT_DLV
        {
            get { return m_strIS_ALT_DLV; }
            set
            {
                if (value == null)
                    m_strIS_ALT_DLV.Value = value;
                else
                    m_strIS_ALT_DLV = value;
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
                values.Add("VENDOR_CODE");

                //Add PrimaryKey Name
                return new MapKeyValue<string, List<string>>("SYS_C00210439", values);
            }
        }
        #endregion

    }
}

