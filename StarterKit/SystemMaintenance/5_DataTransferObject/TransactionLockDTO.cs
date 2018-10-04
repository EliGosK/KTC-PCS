/*
 *		Author: Mr.Teerayut S
 *      Team : SI-EVO
 * 		Writed On 2009/10/05
 * 		Time : 12:44 PM
 *  	This is DTO for TZ_TRANS_LOCK Table.
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
    [DataTransferObject("TZ_TRANS_LOCK", typeof(eColumns))]
    public class TransactionLockDTO : AbstractDTO
    {
        #region " Enums Columns "
        public enum eColumns
        {
            KEY1,
            KEY2,
            KEY3,
            KEY4,
            KEY5,
            CRT_BY,
            CRT_DATE,
            CRT_MACHINE
        };
        #endregion

        #region " Variables "
        private NZString m_strKEY1 = new NZString();
        private NZString m_strKEY2 = new NZString();
        private NZString m_strKEY3 = new NZString();
        private NZString m_strKEY4 = new NZString();
        private NZString m_strKEY5 = new NZString();
        private NZString m_strCRT_BY = new NZString();
        private NZDateTime m_dtCRT_DATE = new NZDateTime();
        private NZString m_strCRT_MACHINE = new NZString();
        #endregion

        #region " Constructor "

        #endregion

        #region " Getter and Setter properties "
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "KEY1", 0, 0, 50)]
        public NZString KEY1
        {
            get { return m_strKEY1; }
            set
            {
                if (value == null)
                    m_strKEY1.Value = value;
                else
                    m_strKEY1 = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "KEY2", 0, 0, 50)]
        public NZString KEY2
        {
            get { return m_strKEY2; }
            set
            {
                if (value == null)
                    m_strKEY2.Value = value;
                else
                    m_strKEY2 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "KEY3", 0, 0, 50)]
        public NZString KEY3
        {
            get { return m_strKEY3; }
            set
            {
                if (value == null)
                    m_strKEY3.Value = value;
                else
                    m_strKEY3 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "KEY4", 0, 0, 50)]
        public NZString KEY4
        {
            get { return m_strKEY4; }
            set
            {
                if (value == null)
                    m_strKEY4.Value = value;
                else
                    m_strKEY4 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "KEY5", 0, 0, 50)]
        public NZString KEY5
        {
            get { return m_strKEY5; }
            set
            {
                if (value == null)
                    m_strKEY5.Value = value;
                else
                    m_strKEY5 = value;
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
                values.Add(eColumns.KEY1.ToString());
                values.Add(eColumns.KEY2.ToString());

                //Add PrimaryKey Name
                return new MapKeyValue<string, List<string>>("PK_TZ_TRANS_LOCK", values);
            }
        }
        #endregion

        #region " Helper "
        /*
		public void SaveDTO() {
			TransactionLockDTO dto = new TransactionLockDTO();
			dto.KEY1 = 
			dto.KEY2 = 
			dto.KEY3 = 
			dto.KEY4 = 
			dto.KEY5 = 
			dto.CRT_BY = 
			dto.CRT_DATE = 
			dto.CRT_MACHINE = 
		}
		*/
        #endregion
    }
}

