/*
 *		Author: Mr.Teerayut S
 *      Team : SI-EVO
 * 		Writed On 2010/06/11
 * 		Time : 03:31 PM
 *  	This is DTO for V_ACTUAL_ONHAND Table.
 *		From Templates Version : 1.0.0
 *		Last Modify Template On : 2009/08/27
 */
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
    [DataTransferObject("V_ACTUAL_ONHAND", typeof(eColumns))]
    public class ActualOnhandViewDTO : AbstractDTO
    {
        #region " Enums Columns "
        public enum eColumns
        {
            LAST_RECEIVE_DATE,
            ITEM_CD,
            LOC_CD,
            LOT_NO,
            PACK_NO,
            FG_NO,
            ONHAND_QTY,
            EXTERNAL_LOT_NO
        };
        #endregion

        #region " Variables "
        private NZDateTime m_dtLAST_RECEIVE_DATE = new NZDateTime();
        private NZString m_strITEM_CD = new NZString();
        private NZString m_strLOC_CD = new NZString();
        private NZString m_strLOT_NO = new NZString();
        private NZString m_strPACK_NO = new NZString();
        private NZString m_strFG_NO = new NZString();
        private NZDecimal m_dONHAND_QTY = new NZDecimal();
        private NZString m_strEXTERNAL_LOT_NO = new NZString();
        #endregion

        #region " Constructor "

        #endregion

        #region " Getter and Setter properties "
        [Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "LAST_RECEIVE_DATE", 23, 3, 8)]
        public NZDateTime LAST_RECEIVE_DATE
        {
            get { return m_dtLAST_RECEIVE_DATE; }
            set
            {
                if (value == null)
                    m_dtLAST_RECEIVE_DATE.Value = value;
                else
                    m_dtLAST_RECEIVE_DATE = value;
            }
        }
        [FieldNotNull]
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
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "LOC_CD", 0, 0, 20)]
        public NZString LOC_CD
        {
            get { return m_strLOC_CD; }
            set
            {
                if (value == null)
                    m_strLOC_CD.Value = value;
                else
                    m_strLOC_CD = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "LOT_NO", 0, 0, 30)]
        public NZString LOT_NO
        {
            get { return m_strLOT_NO; }
            set
            {
                if (value == null)
                    m_strLOT_NO.Value = value;
                else
                    m_strLOT_NO = value;
            }
        }

        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "PACK_NO", 0, 0, 30)]
        public NZString PACK_NO
        {
            get { return m_strPACK_NO; }
            set
            {
                if (value == null)
                    m_strPACK_NO.Value = value;
                else
                    m_strPACK_NO = value;
            }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "FG_NO", 0, 0, 50)]
        public NZString FG_NO
        {
            get { return m_strFG_NO; }
            set
            {
                if (value == null)
                    m_strFG_NO.Value = value;
                else
                    m_strFG_NO = value;
            }
        }

        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "ONHAND_QTY", 38, 6, 17)]
        public NZDecimal ONHAND_QTY
        {
            get { return m_dONHAND_QTY; }
            set
            {
                if (value == null)
                    m_dONHAND_QTY.Value = value;
                else
                    m_dONHAND_QTY = value;
            }
        }

        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "EXTERNAL_LOT_NO", 0, 0, 50)]
        public NZString EXTERNAL_LOT_NO
        {
            get { return m_strEXTERNAL_LOT_NO; }
            set
            {
                if (value == null)
                    m_strEXTERNAL_LOT_NO.Value = value;
                else
                    m_strEXTERNAL_LOT_NO = value;
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
        //        values.Add(eColumns.LOC_CD.ToString());
        //        values.Add(eColumns.LOT_NO.ToString());

        //        //Add PrimaryKey Name
        //        return new MapKeyValue<string, List<string>>("PK_V_ACTUAL_ONHAND", values);
        //    }
        //}
        #endregion

        #region " Helper "
        /*
		public void SaveDTO() {
			ActualOnhandViewDTO dto = new ActualOnhandViewDTO();
			dto.ITEM_CD = 
			dto.LOC_CD = 
			dto.LOT_NO = 
			dto.ONHAND_QTY = 
		}
		*/
        #endregion
    }
}

