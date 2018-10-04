/*
 *		Author: Mr.Teerayut S
 *      Team : SI-EVO
 * 		Writed On 2009/10/07
 * 		Time : 09:57 AM
 *  	This is DTO for TB_INV_PERIOD_MS Table.
 *		From Templates Version : 1.0.0
 *		Last Modify Template On : 2009/08/27
 */
#region Using Namespace

using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Database;
using System.Collections.Generic;
#endregion

namespace Rubik.DTO
{
    [DataTransferObject("TB_INV_PERIOD_MS", typeof(eColumns))]
    public class InventoryPeriodDTO : AbstractDTO
    {
        #region " Enums Columns "
        public enum eColumns
        {
            YEAR_MONTH,
            PERIOD_BEGIN_DATE,
            PERIOD_END_DATE,
            CRT_BY,
            CRT_DATE,
            CRT_MACHINE,
            UPD_BY,
            UPD_DATE,
            UPD_MACHINE
        };
        #endregion

        #region " Variables "
        private NZString m_strYEAR_MONTH = new NZString();
        private NZDateTime m_dtPERIOD_BEGIN_DATE = new NZDateTime();
        private NZDateTime m_dtPERIOD_END_DATE = new NZDateTime();
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "YEAR_MONTH", 0, 0, 6)]
        public NZString YEAR_MONTH
        {
            get { return m_strYEAR_MONTH; }
            set
            {
                if (value == null)
                    m_strYEAR_MONTH.Value = value;
                else
                    m_strYEAR_MONTH = value;
            }
        }
        [Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "PERIOD_BEGIN_DATE", 23, 3, 8)]
        public NZDateTime PERIOD_BEGIN_DATE
        {
            get { return m_dtPERIOD_BEGIN_DATE; }
            set
            {
                if (value == null)
                    m_dtPERIOD_BEGIN_DATE.Value = value;
                else
                    m_dtPERIOD_BEGIN_DATE = value;
            }
        }
        [Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "PERIOD_END_DATE", 23, 3, 8)]
        public NZDateTime PERIOD_END_DATE
        {
            get { return m_dtPERIOD_END_DATE; }
            set
            {
                if (value == null)
                    m_dtPERIOD_END_DATE.Value = value;
                else
                    m_dtPERIOD_END_DATE = value;
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
                values.Add(eColumns.YEAR_MONTH.ToString());

                //Add PrimaryKey Name
                return new MapKeyValue<string, List<string>>("PK_TB_INV_PERIOD_MS", values);
            }
        }
        #endregion

        #region " Helper "
        /*
		public void SaveDTO() {
			InventoryPeriodDTO dto = new InventoryPeriodDTO();
			dto.YEAR_MONTH = 
			dto.PERIOD_BEGIN_DATE = 
			dto.PERIOD_END_DATE = 
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

