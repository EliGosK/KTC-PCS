/*
 *		Author: Mr.Teerayut S
 *      Team : SI-EVO
 * 		Writed On 2009/09/16
 * 		Time : 03:45 PM
 *  	This is DTO for TZ_USER_SCREEN_PERMISSION_MS Table.
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
    [DataTransferObject("TZ_USER_SCREEN_PERMISSION_MS", typeof(eColumns))]
    public class UserScreenPermissionDTO : AbstractDTO
    {
        #region " Enums Columns "
        public enum eColumns
        {
            SCREEN_CD,
            USER_CD,
            FLG_VIEW,
            FLG_ADD,
            FLG_CHG,
            FLG_DEL,
            CRT_BY,
            CRT_DATE,
            CRT_MACHINE,
            UPD_BY,
            UPD_DATE,
            UPD_MACHINE
        };
        #endregion

        #region " Variables "
        private NZString m_strSCREEN_CD = new NZString();
        private NZString m_strUSER_CD = new NZString();
        private NZInt m_iFLG_VIEW = new NZInt();
        private NZInt m_iFLG_ADD = new NZInt();
        private NZInt m_iFLG_CHG = new NZInt();
        private NZInt m_iFLG_DEL = new NZInt();
        private NZString m_strCRT_BY = new NZString();
        private NZDateTime m_dtCRT_DATE = new NZDateTime();
        private NZString m_strCRT_MACHINE = new NZString();
        private NZString m_strUPD_BY = new NZString();
        private NZDateTime m_dtUPD_DATE = new NZDateTime();
        private NZString m_strUPD_MACHINE = new NZString();
        #endregion

        #region " Constructor "

        #endregion

        #region " Getter and Setter properties "
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.VarChar, "SCREEN_CD", 0, 0, 120)]
        public NZString SCREEN_CD
        {
            get { return m_strSCREEN_CD; }
            set
            {
                if (value == null)
                    m_strSCREEN_CD.Value = value;
                else
                    m_strSCREEN_CD = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.VarChar, "USER_CD", 0, 0, 60)]
        public NZString USER_CD
        {
            get { return m_strUSER_CD; }
            set
            {
                if (value == null)
                    m_strUSER_CD.Value = value;
                else
                    m_strUSER_CD = value;
            }
        }
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Number, "FLG_VIEW", 0, 0, 0)]
        public NZInt FLG_VIEW
        {
            get { return m_iFLG_VIEW; }
            set
            {
                if (value == null)
                    m_iFLG_VIEW.Value = value;
                else
                    m_iFLG_VIEW = value;
            }
        }
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Number, "FLG_ADD", 0, 0, 0)]
        public NZInt FLG_ADD
        {
            get { return m_iFLG_ADD; }
            set
            {
                if (value == null)
                    m_iFLG_ADD.Value = value;
                else
                    m_iFLG_ADD = value;
            }
        }
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Number, "FLG_CHG", 0, 0, 0)]
        public NZInt FLG_CHG
        {
            get { return m_iFLG_CHG; }
            set
            {
                if (value == null)
                    m_iFLG_CHG.Value = value;
                else
                    m_iFLG_CHG = value;
            }
        }
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Number, "FLG_DEL", 0, 0, 0)]
        public NZInt FLG_DEL
        {
            get { return m_iFLG_DEL; }
            set
            {
                if (value == null)
                    m_iFLG_DEL.Value = value;
                else
                    m_iFLG_DEL = value;
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
                values.Add("SCREEN_CD");
                values.Add("USER_CD");

                //Add PrimaryKey Name
                return new MapKeyValue<string, List<string>>("SYS_C0026880", values);
            }
        }
        #endregion

        #region " Helper "
        /*
		public void SaveDTO() {
			UserScreenPermissionDTO dto = new UserScreenPermissionDTO();
			dto.SCREEN_CD = 
			dto.USER_CD = 
			dto.FLG_VIEW = 
			dto.FLG_ADD = 
			dto.FLG_CHG = 
			dto.FLG_DEL = 
			dto.CRT_BY = 
			dto.CRT_DATE = 
			dto.CRT_MACHINE = 
			dto.UPD_BY = 
			dto.UPD_DATE = 
			dto.UPD_MACHINE = 
		}
		*/
        #endregion
    }
}

