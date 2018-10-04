#region Using Namespace

using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Database;
using System.Collections.Generic;
using System;
using System.Text;
#endregion

namespace Rubik.DTO
{
    [Serializable()]
    [DataTransferObject("TZ_SCREEN_SHEET_WIDTH_MS", typeof(eColumns))]
    public class SheetWidthDTO : AbstractDTO
    {
        #region " Enums Columns "
        public enum eColumns
        {
            SCREEN_CD,
            SHEET_ID,
            COL_INDEX,
            COL_WIDTH,
        };
        #endregion

        #region " Variables "
        private NZString m_strSCREEN_CD = new NZString();
        private NZString m_strSHEET_ID = new NZString();
        private NZInt m_dCOL_INDEX = new NZInt();
        private NZDecimal m_dCOL_WIDTH = new NZDecimal();
        #endregion

        #region " Constructor "

        #endregion

        #region " Getter and Setter properties "
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "SCREEN_CD", 0, 0, 120)]
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "SHEET_ID", 0, 0, 100)]
        public NZString SHEET_ID
        {
            get { return m_strSHEET_ID; }
            set
            {
                if (value == null)
                    m_strSHEET_ID.Value = value;
                else
                    m_strSHEET_ID = value;
            }
        }

        [Field(typeof(System.Decimal), typeof(NZInt), DataType.Number, "COL_INDEX", 5, 0, 5)]
        public NZInt COL_INDEX
        {
            get { return m_dCOL_INDEX; }
            set
            {
                if (value == null)
                    m_dCOL_INDEX.Value = value;
                else
                    m_dCOL_INDEX = value;
            }
        }

        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "COL_WIDTH", 16, 6, 9)]
        public NZDecimal COL_WIDTH
        {
            get { return m_dCOL_WIDTH; }
            set
            {
                if (value == null)
                    m_dCOL_WIDTH.Value = value;
                else
                    m_dCOL_WIDTH = value;
            }
        }



        #endregion

        #region " Overriden method "
        ///// <summary>
        ///// Return array of primary key fields.
        ///// </summary>
        ///// <remarks>
        ///// If this table mapping has not primary key, return null value.
        ///// </remarks>
        //public override MapKeyValue<string, List<string>> PrimaryKey
        //{
        //    get
        //    {
        //        List<string> values = new List<string>();

        //        //Add MemberColums of PrimaryKey
        //        values.Add(eColumns.SCREEN_CD.ToString());
        //        values.Add(eColumns.COL_INDEX.ToString());

        //        //Add PrimaryKey Name
        //        return new MapKeyValue<string, List<string>>("PK_TZ_SCREEN_SHEET_WIDTH_MS", values);
        //    }
        //}
        #endregion

        #region " Helper "

        #endregion
    }
}

