/*
 *		Author: Teerayut S. And Kung I.
 *      Team : SI-EVO
 * 		Writed On 2009/09/14
 * 		Time : 04:54 PM
 *  	This is DTO for TZ_MENU_SUB_LANG_MS Table.
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
    [DataTransferObject("TZ_MENU_SUB_LANG_MS", typeof(eColumns))]
    public class MenuSubLangDTO : AbstractDTO
    {
        #region " Enums Columns "
        public enum eColumns
        {
            LANG_CD,
            MENU_SUB_CD,
            MENU_SUB_DESC,
            CRT_BY,
            CRT_DATE,
            CRT_MACHINE,
            UPD_BY,
            UPD_DATE,
            UPD_MACHINE
        };
        #endregion

        #region " Variables "
        private NZString m_strLANG_CD = new NZString();
        private NZString m_strMENU_SUB_CD = new NZString();
        private NZString m_strMENU_SUB_DESC = new NZString();
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
        [Field(typeof(System.String), typeof(NZString), DataType.VarChar, "LANG_CD", 0, 0, 40)]
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
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.VarChar, "MENU_SUB_CD", 0, 0, 60)]
        public NZString MENU_SUB_CD
        {
            get { return m_strMENU_SUB_CD; }
            set
            {
                if (value == null)
                    m_strMENU_SUB_CD.Value = value;
                else
                    m_strMENU_SUB_CD = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "MENU_SUB_DESC", 0, 0, 400)]
        public NZString MENU_SUB_DESC
        {
            get { return m_strMENU_SUB_DESC; }
            set
            {
                if (value == null)
                    m_strMENU_SUB_DESC.Value = value;
                else
                    m_strMENU_SUB_DESC = value;
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
                values.Add("LANG_CD");
                values.Add("MENU_SUB_CD");

                //Add PrimaryKey Name
                return new MapKeyValue<string, List<string>>("SYS_C0026771", values);
            }
        }
        #endregion

        #region " Helper "
        /*
		public void SaveDTO() {
			MenuSubLangDTO dto = new MenuSubLangDTO();
			dto.LANG_CD = 
			dto.MENU_SUB_CD = 
			dto.MENU_SUB_DESC = 
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

