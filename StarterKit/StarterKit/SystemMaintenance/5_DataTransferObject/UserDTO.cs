
/*
 *		Author: Teerayut S. And Kung I.
 *      Team : SI-EVO
 * 		Writed On 2009/08/27
 * 		Time : 09:56 AM
 *  	This is Data Layer for TZ_USER_MS Table.
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
    [DataTransferObject("TZ_USER_MS", typeof(eColumns))]
    public class UserDTO : AbstractDTO
    {
        #region " Enums Columns "
        public enum eColumns
        {
            USER_ACCOUNT,
            MENU_SET_CD,
            GROUP_CD,
            DEPARTMENT_CD,
            LANG_CD,
            DATE_FORMAT,
            PASS,
            FULL_NAME,
            APPLY_DATE,
            FLG_RESIGN,
            FLG_ACTIVE,
            CRT_BY,
            CRT_DATE,
            CRT_MACHINE,
            UPD_BY,
            UPD_DATE,
            UPD_MACHINE,
            UPPER_USER_ACCOUNT,
            LOWER_USER_ACCOUNT,
            HIDDEN_PERSON_IN_CHARGE
        };
        #endregion

        #region " Variables "
        private NZString m_strUSER_ACCOUNT = new NZString();
        private NZString m_strMENU_SET_CD = new NZString();
        private NZString m_strGROUP_CD = new NZString();
        private NZString m_strDEPARTMENT_CD = new NZString();
        private NZString m_strLANG_CD = new NZString();
        private NZInt m_DATE_FORMAT = new NZInt();
        private NZString m_strPASS = new NZString();
        private NZString m_strFULL_NAME = new NZString();
        private NZDateTime m_dtAPPLY_DATE = new NZDateTime();
        private NZInt m_FLG_RESIGN = new NZInt();
        private NZInt m_FLG_ACTIVE = new NZInt();
        private NZString m_strCRT_BY = new NZString();
        private NZDateTime m_dtCRT_DATE = new NZDateTime();
        private NZString m_strCRT_MACHINE = new NZString();
        private NZString m_strUPD_BY = new NZString();
        private NZDateTime m_dtUPD_DATE = new NZDateTime();
        private NZString m_strUPD_MACHINE = new NZString();
        private NZString m_strUPPER_USER_ACCOUNT = new NZString();
        private NZString m_strLOWER_USER_ACCOUNT = new NZString();
        private NZInt m_iHIDDEN_PERSON_IN_CHARGE = new NZInt();

        private NZString m_strGROUP_NAME = new NZString();

        #endregion

        #region " Constructor "

        #endregion

        #region Getter and Setter properties
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "USER_ACCOUNT", 0, 0, 30)]
        public NZString USER_ACCOUNT
        {
            get { return m_strUSER_ACCOUNT; }
            set
            {
                if (value == null)
                    m_strUSER_ACCOUNT.Value = value;
                else
                    m_strUSER_ACCOUNT = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "MENU_SET_CD", 0, 0, 30)]
        public NZString MENU_SET_CD
        {
            get { return m_strMENU_SET_CD; }
            set
            {
                if (value == null)
                    m_strMENU_SET_CD.Value = value;
                else
                    m_strMENU_SET_CD = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "GROUP_CD", 0, 0, 30)]
        public NZString GROUP_CD
        {
            get { return m_strGROUP_CD; }
            set
            {
                if (value == null)
                    m_strGROUP_CD.Value = value;
                else
                    m_strGROUP_CD = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "DEPARTMENT_CD", 0, 0, 30)]
        public NZString DEPARTMENT_CD
        {
            get { return m_strDEPARTMENT_CD; }
            set
            {
                if (value == null)
                    m_strDEPARTMENT_CD.Value = value;
                else
                    m_strDEPARTMENT_CD = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "LANG_CD", 0, 0, 20)]
        public NZString LANG_CD
        {
            get { return m_strLANG_CD; }
            set
            {
                if (value == null)
                    m_strLANG_CD.Value = value;
                else
                    m_strLANG_CD = value;
            }
        }
        /// <summary>
        /// 0=YMD, 1=MDY, 2=DMY
        /// </summary>
        [FieldNotNull]
        [Field(typeof(System.Boolean), typeof(NZInt), DataType.Number, "DATE_FORMAT", 1, 0, 0)]
        public NZInt DATE_FORMAT
        {
            get { return m_DATE_FORMAT; }
            set
            {
                if (value == null)
                    m_DATE_FORMAT.Value = value;
                else
                    m_DATE_FORMAT = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "PASS", 0, 0, 100)]
        public NZString PASS
        {
            get { return m_strPASS; }
            set
            {
                if (value == null)
                    m_strPASS.Value = value;
                else
                    m_strPASS = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "FULL_NAME", 0, 0, 400)]
        public NZString FULL_NAME
        {
            get { return m_strFULL_NAME; }
            set
            {
                if (value == null)
                    m_strFULL_NAME.Value = value;
                else
                    m_strFULL_NAME = value;
            }
        }
        [Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "APPLY_DATE", 0, 0, 0)]
        public NZDateTime APPLY_DATE
        {
            get { return m_dtAPPLY_DATE; }
            set
            {
                if (value == null)
                    m_dtAPPLY_DATE.Value = value;
                else
                    m_dtAPPLY_DATE = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.Boolean), typeof(NZInt), DataType.Number, "FLG_RESIGN", 1, 0, 0)]
        public NZInt FLG_RESIGN
        {
            get { return m_FLG_RESIGN; }
            set
            {
                if (value == null)
                    m_FLG_RESIGN.Value = value;
                else
                    m_FLG_RESIGN = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.Boolean), typeof(NZInt), DataType.Number, "FLG_ACTIVE", 1, 0, 0)]
        public NZInt FLG_ACTIVE
        {
            get { return m_FLG_ACTIVE; }
            set
            {
                if (value == null)
                    m_FLG_ACTIVE.Value = value;
                else
                    m_FLG_ACTIVE = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CRT_BY", 0, 0, 30)]
        public NZString CRT_BY
        {
            get { return m_strCRT_BY; }
            set
            {
                if (value == null)
                    m_strCRT_BY.Value = value;
                else
                    m_strCRT_BY = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "CRT_DATE", 0, 0, 0)]
        public NZDateTime CRT_DATE
        {
            get { return m_dtCRT_DATE; }
            set
            {
                if (value == null)
                    m_dtCRT_DATE.Value = value;
                else
                    m_dtCRT_DATE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CRT_MACHINE", 0, 0, 100)]
        public NZString CRT_MACHINE
        {
            get { return m_strCRT_MACHINE; }
            set
            {
                if (value == null)
                    m_strCRT_MACHINE.Value = value;
                else
                    m_strCRT_MACHINE = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "UPD_BY", 0, 0, 30)]
        public NZString UPD_BY
        {
            get { return m_strUPD_BY; }
            set
            {
                if (value == null)
                    m_strUPD_BY.Value = value;
                else
                    m_strUPD_BY = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "UPD_DATE", 0, 0, 0)]
        public NZDateTime UPD_DATE
        {
            get { return m_dtUPD_DATE; }
            set
            {
                if (value == null)
                    m_dtUPD_DATE.Value = value;
                else
                    m_dtUPD_DATE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "UPD_MACHINE", 0, 0, 100)]
        public NZString UPD_MACHINE
        {
            get { return m_strUPD_MACHINE; }
            set
            {
                if (value == null)
                    m_strUPD_MACHINE.Value = value;
                else
                    m_strUPD_MACHINE = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "UPPER_USER_ACCOUNT", 0, 0, 30)]
        public NZString UPPER_USER_ACCOUNT
        {
            get { return m_strUPPER_USER_ACCOUNT; }
            set
            {
                if (value == null)
                    m_strUPPER_USER_ACCOUNT.Value = value;
                else
                    m_strUPPER_USER_ACCOUNT = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "LOWER_USER_ACCOUNT", 0, 0, 30)]
        public NZString LOWER_USER_ACCOUNT
        {
            get { return m_strLOWER_USER_ACCOUNT; }
            set
            {
                if (value == null)
                    m_strLOWER_USER_ACCOUNT.Value = value;
                else
                    m_strLOWER_USER_ACCOUNT = value;
            }
        }

        [FieldNotNull]
        [Field(typeof(System.Boolean), typeof(NZInt), DataType.Number, "HIDDEN_PERSON_IN_CHARGE", 1, 0, 0)]
        public NZInt HIDDEN_PERSON_IN_CHARGE
        {
            get { return m_iHIDDEN_PERSON_IN_CHARGE; }
            set
            {
                if (value == null)
                    m_iHIDDEN_PERSON_IN_CHARGE.Value = value;
                else
                    m_iHIDDEN_PERSON_IN_CHARGE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "GROUP_NAME", 0, 0, 30)]
        public NZString GROUP_NAME
        {
            get { return m_strGROUP_NAME; }
            set
            {
                if (value == null)
                    m_strGROUP_NAME.Value = value;
                else
                    m_strGROUP_NAME = value;
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
                values.Add("UPPER_USER_ACCOUNT");
                values.Add("LOWER_USER_ACCOUNT");

                //Add PrimaryKey Name
                return new MapKeyValue<string, List<string>>("USER_PK", values);
            }
        }
        /// <summary>
        /// Return list or array's unique key fields.
        /// </summary>
        /// <remarks>
        /// If this table mapping not has unique key, return null value.
        /// </remarks>
        public override Map<string, List<string>> UniqueKeys
        {

            get
            {
                Map<string, List<string>> idxKeys = new Map<string, List<string>>();

                List<string> values = null;


                //IDX1
                values = new List<string>();
                values.Add("USER_ACCOUNT");
                idxKeys.Put("USER_IDX1", values);


                return idxKeys;
            }
        }
        #endregion


    }
}

