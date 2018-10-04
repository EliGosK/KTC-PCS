/*
 *		Author: Mr.Teerayut S
 *      Team : SI-EVO
 * 		Writed On 2009/10/01
 * 		Time : 04:59 PM
 *  	This is DTO for TZ_RUNNIGN_NO_MS Table.
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
    [DataTransferObject("TZ_RUNNIGN_NO_MS", typeof(eColumns))]
    public class RunningNumberDTO : AbstractDTO
    {
        #region " Enums Columns "
        public enum eColumns
        {
            ID_NAME,
            TB_NAME,
            DESCRIPTION,
            FORMAT,
            NEXTVALUE,
            LAST_RESET,
            RESET_FLAG_DAY,
            RESET_FLAG_MONTH,
            RESET_FLAG_YEAR,
            CRT_BY,
            CRT_DATE,
            CRT_MACHINE,
            UPD_BY,
            UPD_DATE,
            UPD_MACHINE
        };
        #endregion

        #region " Variables "
        private NZString m_strID_NAME = new NZString();
        private NZString m_strTB_NAME = new NZString();
        private NZString m_strDESCRIPTION = new NZString();
        private NZString m_strFORMAT = new NZString();
        private NZDecimal m_dNEXTVALUE = new NZDecimal();
        private NZDateTime m_dtLAST_RESET = new NZDateTime();
        private NZString m_strRESET_FLAG_DAY = new NZString();
        private NZString m_strRESET_FLAG_MONTH = new NZString();
        private NZString m_strRESET_FLAG_YEAR = new NZString();
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
        [Field(typeof(System.String), typeof(NZString), DataType.VarChar, "ID_NAME", 0, 0, 50)]
        public NZString ID_NAME
        {
            get { return m_strID_NAME; }
            set
            {
                if (value == null)
                    m_strID_NAME.Value = value;
                else
                    m_strID_NAME = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.VarChar, "TB_NAME", 0, 0, 50)]
        public NZString TB_NAME
        {
            get { return m_strTB_NAME; }
            set
            {
                if (value == null)
                    m_strTB_NAME.Value = value;
                else
                    m_strTB_NAME = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.VarChar, "DESCRIPTION", 0, 0, 200)]
        public NZString DESCRIPTION
        {
            get { return m_strDESCRIPTION; }
            set
            {
                if (value == null)
                    m_strDESCRIPTION.Value = value;
                else
                    m_strDESCRIPTION = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.VarChar, "FORMAT", 0, 0, 20)]
        public NZString FORMAT
        {
            get { return m_strFORMAT; }
            set
            {
                if (value == null)
                    m_strFORMAT.Value = value;
                else
                    m_strFORMAT = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "NEXTVALUE", 20, 0, 13)]
        public NZDecimal NEXTVALUE
        {
            get { return m_dNEXTVALUE; }
            set
            {
                if (value == null)
                    m_dNEXTVALUE.Value = value;
                else
                    m_dNEXTVALUE = value;
            }
        }
        [Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "LAST_RESET", 23, 3, 8)]
        public NZDateTime LAST_RESET
        {
            get { return m_dtLAST_RESET; }
            set
            {
                if (value == null)
                    m_dtLAST_RESET.Value = value;
                else
                    m_dtLAST_RESET = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.Default, "RESET_FLAG_DAY", 0, 0, 1)]
        public NZString RESET_FLAG_DAY
        {
            get { return m_strRESET_FLAG_DAY; }
            set
            {
                if (value == null)
                    m_strRESET_FLAG_DAY.Value = value;
                else
                    m_strRESET_FLAG_DAY = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.Default, "RESET_FLAG_MONTH", 0, 0, 1)]
        public NZString RESET_FLAG_MONTH
        {
            get { return m_strRESET_FLAG_MONTH; }
            set
            {
                if (value == null)
                    m_strRESET_FLAG_MONTH.Value = value;
                else
                    m_strRESET_FLAG_MONTH = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.Default, "RESET_FLAG_YEAR", 0, 0, 1)]
        public NZString RESET_FLAG_YEAR
        {
            get { return m_strRESET_FLAG_YEAR; }
            set
            {
                if (value == null)
                    m_strRESET_FLAG_YEAR.Value = value;
                else
                    m_strRESET_FLAG_YEAR = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CRT_BY", 0, 0, 15)]
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
        [Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "CRT_DATE", 23, 3, 8)]
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CRT_MACHINE", 0, 0, 50)]
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "UPD_BY", 0, 0, 15)]
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
        [Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "UPD_DATE", 23, 3, 8)]
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "UPD_MACHINE", 0, 0, 50)]
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
                values.Add(eColumns.ID_NAME.ToString());
                values.Add(eColumns.TB_NAME.ToString());

                //Add PrimaryKey Name
                return new MapKeyValue<string, List<string>>("PK_TZ_RUNNIGN_NO_MS", values);
            }
        }
        #endregion

        #region " Helper "
        /*
		public void SaveDTO() {
			RunningNumberDTO dto = new RunningNumberDTO();
			dto.ID_NAME = 
			dto.TB_NAME = 
			dto.DESCRIPTION = 
			dto.FORMAT = 
			dto.NEXTVALUE = 
			dto.LAST_RESET = 
			dto.RESET_FLAG_DAY = 
			dto.RESET_FLAG_MONTH = 
			dto.RESET_FLAG_YEAR = 
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

