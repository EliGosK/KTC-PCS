/*
 *		Author: Teerayut S. And Kung I.
 *      Team : SI-EVO
 * 		Writed On 2009/09/03
 * 		Time : 03:16 PM
 *  	This is DTO for TZ_SCREEN_MS Table.
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
    [DataTransferObject("TZ_SCREEN_MS", typeof(eColumns))]
    public class ScreenDTO : AbstractDTO
    {
        #region " Enums Columns "
        public enum eColumns
        {
            SCREEN_CD,
            SCREEN_NAME,
            IMAGE_CD,
            SCREEN_TYPE,
            SCREEN_ACTION,
            EXT_PROGRAM,
            CRT_BY,
            CRT_DATE,
            CRT_MACHINE,
            UPD_BY,
            UPD_DATE,
            UPD_MACHINE,
            ORIGINAL_TITLE,
            IS_AUTHORIZE,
            IS_USED
        };
        #endregion

        #region " Variables "
        private NZString m_strSCREEN_CD = new NZString();
        private NZString m_strSCREEN_NAME = new NZString();
        private NZString m_strIMAGE_CD = new NZString();
        private NZInt m_iSCREEN_TYPE = new NZInt();
        private NZInt m_iSCREEN_ACTION = new NZInt();
        private NZString m_strEXT_PROGRAM = new NZString();
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "SCREEN_NAME", 0, 0, 100)]
        public NZString SCREEN_NAME
        {
            get { return m_strSCREEN_NAME; }
            set
            {
                if (value == null)
                    m_strSCREEN_NAME.Value = value;
                else
                    m_strSCREEN_NAME = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.VarChar, "IMAGE_CD", 0, 0, 40)]
        public NZString IMAGE_CD
        {
            get { return m_strIMAGE_CD; }
            set
            {
                if (value == null)
                    m_strIMAGE_CD.Value = value;
                else
                    m_strIMAGE_CD = value;
            }
        }
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Number, "SCREEN_TYPE", 0, 0, 0)]
        public NZInt SCREEN_TYPE
        {
            get { return m_iSCREEN_TYPE; }
            set
            {
                if (value == null)
                    m_iSCREEN_TYPE.Value = value;
                else
                    m_iSCREEN_TYPE = value;
            }
        }
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Number, "SCREEN_ACTION", 0, 0, 0)]
        public NZInt SCREEN_ACTION
        {
            get { return m_iSCREEN_ACTION; }
            set
            {
                if (value == null)
                    m_iSCREEN_ACTION.Value = value;
                else
                    m_iSCREEN_ACTION = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.VarChar, "EXT_PROGRAM", 0, 0, 800)]
        public NZString EXT_PROGRAM
        {
            get { return m_strEXT_PROGRAM; }
            set
            {
                if (value == null)
                    m_strEXT_PROGRAM.Value = value;
                else
                    m_strEXT_PROGRAM = value;
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

                //Add PrimaryKey Name
                return new MapKeyValue<string, List<string>>("SYS_C0026689", values);
            }
        }
        #endregion

        #region " Helper "
        /*
		public void SaveDTO() {
			ScreenDTO dto = new ScreenDTO();
			dto.SCREEN_CD = 
			dto.SCREEN_NAME = 
			dto.IMAGE_CD = 
			dto.SCREEN_TYPE = 
			dto.SCREEN_ACTION = 
			dto.EXT_PROGRAM = 
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

