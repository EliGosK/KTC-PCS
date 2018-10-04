
#region Using Namespace
using System;
using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Database;
using System.Collections.Generic;
#endregion

namespace Rubik.DTO
{
    [Serializable()]
    [DataTransferObject("TB_ITEM_EQUIVALENT_MS", typeof(eColumns))]
    public class ItemEquivalentDTO : AbstractDTO
    {
        #region " Enums Columns "
        public enum eColumns
        {
            ITEM_CD,
            EQUIVALENT_ITEM_CD,
            ORDER_LOC_CD,
            CRT_BY,
            CRT_DATE,
            CRT_MACHINE,
            UPD_BY,
            UPD_DATE,
            UPD_MACHINE,
        };
        #endregion

        #region " Variables "
        private NZString m_strITEM_CD = new NZString();
        private NZString m_strEQUIVALENT_ITEM_CD = new NZString();
        private NZString m_strORDER_LOC_CD = new NZString();

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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ITEM_CD", 0, 0, 35)]
        public NZString ITEM_CD
        {
            get { return m_strITEM_CD; }
            set
            {
                if (value == null)
                    m_strITEM_CD.Value = value;
                else
                    m_strITEM_CD = value;
            }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "EQUIVALENT_ITEM_CD", 0, 0, 35)]
        public NZString EQUIVALENT_ITEM_CD
        {
            get { return m_strEQUIVALENT_ITEM_CD; }
            set
            {
                if (value == null)
                    m_strEQUIVALENT_ITEM_CD.Value = value;
                else
                    m_strEQUIVALENT_ITEM_CD = value;
            }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ORDER_LOC_CD", 0, 0, 20)]
        public NZString ORDER_LOC_CD
        {
            get { return m_strORDER_LOC_CD; }
            set
            {
                if (value == null)
                    m_strORDER_LOC_CD.Value = value;
                else
                    m_strORDER_LOC_CD = value;
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
        //public override MapKeyValue<string, List<string>> PrimaryKey
        //{
        //    get
        //    {
        //        List<string> values = new List<string>();

        //        //Add MemberColums of PrimaryKey
        //        values.Add(eColumns.ITEM_CD.ToString());

        //        //Add MemberColums of PrimaryKey
        //        values.Add(eColumns.EQUIVALENT_ITEM_CD.ToString());

        //        //Add PrimaryKey Name
        //        return new MapKeyValue<string, List<string>>("PK_TB_ITEM_EQUIVALENT_MS", values);
        //    }
        //}
        #endregion

        #region " Helper "

        #endregion
    }
}

