/*
 *		Author: Teerayut S. And Kung I.
 *      Team : SI-EVO
 * 		Writed On 2009/09/03
 * 		Time : 03:19 PM
 *  	This is DTO for TZ_SCREEN_DETAIL_MS Table.
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
    [DataTransferObject("TZ_SCREEN_DETAIL_MS", typeof(eColumns))]
    public class ScreenDetailDTO : AbstractDTO
    {
        #region " Enums Columns "
        public enum eColumns
        {
            SCREEN_CD,
            CONTROL_CD,
            CONTROL_TYPE,
            CRT_BY,
            CRT_DATE,
            CRT_MACHINE,
            UPD_BY,
            UPD_DATE,
            UPD_MACHINE,
            ORIGINAL_TITLE,
            IS_USED
        };
        #endregion

        #region " Variables "
        private NZString m_strSCREEN_CD = new NZString();
        private NZString m_strCONTROL_CD = new NZString();
        private NZString m_strCONTROL_TYPE = new NZString();
        private NZString m_strCRT_BY = new NZString();
        private NZDateTime m_dtCRT_DATE = new NZDateTime();
        private NZString m_strCRT_MACHINE = new NZString();
        private NZString m_strUPD_BY = new NZString();
        private NZDateTime m_dtUPD_DATE = new NZDateTime();
        private NZString m_strUPD_MACHINE = new NZString();
        private NZString m_strORIGINAL_TITLE = new NZString();
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
        [Field(typeof(System.String), typeof(NZString), DataType.VarChar, "CONTROL_CD", 0, 0, 240)]
        public NZString CONTROL_CD
        {
            get { return m_strCONTROL_CD; }
            set
            {
                if (value == null)
                    m_strCONTROL_CD.Value = value;
                else
                    m_strCONTROL_CD = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.VarChar, "CONTROL_TYPE", 0, 0, 80)]
        public NZString CONTROL_TYPE
        {
            get { return m_strCONTROL_TYPE; }
            set
            {
                if (value == null)
                    m_strCONTROL_TYPE.Value = value;
                else
                    m_strCONTROL_TYPE = value;
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ORIGINAL_TITLE", 0, 0, 50)]
        public NZString ORIGINAL_TITLE
        {
            get { return m_strORIGINAL_TITLE; }
            set
            {
                if (value == null)
                    m_strORIGINAL_TITLE.Value = value;
                else
                    m_strORIGINAL_TITLE = value;
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
                values.Add("CONTROL_CD");

                //Add PrimaryKey Name
                return new MapKeyValue<string, List<string>>("SYS_C0026703", values);
            }
        }
        #endregion

        #region " Helper "
        /*
		public void SaveDTO() {
			ScreenDetailDTO dto = new ScreenDetailDTO();
			dto.SCREEN_CD = 
			dto.CONTROL_CD = 
			dto.CONTROL_TYPE = 
			dto.CRT_BY = 
			dto.CRT_DATE = 
			dto.CRT_MACHINE = 
			dto.UPD_BY = 
			dto.UPD_DATE = 
			dto.UPD_MACHINE = 
            dto.ORIGINAL_TITLE = 
		}
		*/
        #endregion
    }
}

