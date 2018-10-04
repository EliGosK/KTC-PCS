/*
 *		Author: Mr.Teerayut S
 *      Team : SI-EVO
 * 		Writed On 2009/09/14
 * 		Time : 05:03 PM
 *  	This is DTO for TZ_MENU_SET_DETAIL_MS Table.
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
    [DataTransferObject("TZ_MENU_SET_DETAIL_MS", typeof(eColumns))]
    public class MenuSetDetailDTO : AbstractDTO
    {
        #region " Enums Columns "
        public enum eColumns
        {
            MENU_SUB_CD,
            MENU_SET_CD,
            DISP_SEQ,
            CRT_BY,
            CRT_DATE,
            CRT_MACHINE,
            UPD_BY,
            UPD_DATE,
            UPD_MACHINE
        };
        #endregion

        #region " Variables "
        private NZString m_strMENU_SUB_CD = new NZString();
        private NZString m_strMENU_SET_CD = new NZString();
        private NZInt m_iDISP_SEQ = new NZInt();
        private NZString m_strCRT_BY = new NZString();
        private NZDateTime m_dtCRT_DATE = new NZDateTime();
        private NZString m_strCRT_MACHINE = new NZString();
        private NZString m_strUPD_BY = new NZString();
        private NZDateTime m_dtUPD_DATE = new NZDateTime();
        private NZString m_strUPD_MACHINE = new NZString();
        #endregion

        #region " Constructor "

        #endregion

        #region Getter and Setter properties
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
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.VarChar, "MENU_SET_CD", 0, 0, 60)]
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
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Number, "DISP_SEQ", 0, 0, 0)]
        public NZInt DISP_SEQ
        {
            get { return m_iDISP_SEQ; }
            set
            {
                if (value == null)
                    m_iDISP_SEQ.Value = value;
                else
                    m_iDISP_SEQ = value;
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
                values.Add("MENU_SET_CD");
                values.Add("MENU_SUB_CD");

                //Add PrimaryKey Name
                return new MapKeyValue<string, List<string>>("SYS_C0026755", values);
            }
        }
        #endregion

    }
}

