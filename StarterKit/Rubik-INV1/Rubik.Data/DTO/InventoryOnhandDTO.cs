/*
 *		Author: Mr.Teerayut S
 *      Team : SI-EVO
 * 		Writed On 2010/06/15
 * 		Time : 02:45 PM
 *  	This is DTO for TB_INV_ONHAND_TR Table.
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
    [DataTransferObject("TB_INV_ONHAND_TR", typeof(eColumns))]
    public class InventoryOnhandDTO : AbstractDTO
    {
        #region " Enums Columns "
        public enum eColumns
        {
            CRT_BY,
            CRT_DATE,
            CRT_MACHINE,
            UPD_BY,
            UPD_DATE,
            UPD_MACHINE,
            ID,
            YEAR_MONTH,
            PERIOD_BEGIN_DATE,
            PERIOD_END_DATE,
            ITEM_CD,
            LOC_CD,
            LOT_NO,
            PACK_NO,
            OPEN_QTY,
            IN_QTY,
            OUT_QTY,
            ADJUST_QTY,
            STOCK_TAKE_QTY,
            ON_HAND_QTY,
            LAST_RECEIVE_DATE,
            EXTERNAL_LOT_NO,
            FG_NO,
            OLD_DATA,
            TIME_STAMP
        };
        #endregion

        #region " Variables "

        private NZString m_strCRT_BY = new NZString();
        private NZDateTime m_dtCRT_DATE = new NZDateTime();
        private NZString m_strCRT_MACHINE = new NZString();
        private NZString m_strUPD_BY = new NZString();
        private NZDateTime m_dtUPD_DATE = new NZDateTime();
        private NZString m_strUPD_MACHINE = new NZString();
        private NZLong m_lID = new NZLong();
        private NZString m_strYEAR_MONTH = new NZString();
        private NZDateTime m_dtPERIOD_BEGIN_DATE = new NZDateTime();
        private NZDateTime m_dtPERIOD_END_DATE = new NZDateTime();
        private NZString m_strITEM_CD = new NZString();
        private NZString m_strLOC_CD = new NZString();
        private NZString m_strLOT_NO = new NZString();
        private NZString m_strPACK_NO = new NZString();
        private NZDecimal m_dOPEN_QTY = new NZDecimal();
        private NZDecimal m_dIN_QTY = new NZDecimal();
        private NZDecimal m_dOUT_QTY = new NZDecimal();
        private NZDecimal m_dADJUST_QTY = new NZDecimal();
        private NZDecimal m_dSTOCK_TAKE_QTY = new NZDecimal();
        private NZDecimal m_dON_HAND_QTY = new NZDecimal();
        private NZString m_strEXTERNAL_LOT_NO = new NZString();
        private NZString m_strFG_NO = new NZString();
        private NZDateTime m_dtLAST_RECEIVE_DATE = new NZDateTime();
        private NZInt m_strOLD_DATA = new NZInt();
        private NZInt m_iTIME_STAMP = new NZInt();
        #endregion

        #region " Constructor "

        #endregion

        #region " Getter and Setter properties "
        [FieldNotNull]
        [Field(typeof(System.Int64), typeof(NZLong), DataType.Default, "ID", 19, 0, 8)]
        public NZLong ID
        {
            get { return m_lID; }
            set
            {
                if (value == null)
                    m_lID.Value = value;
                else
                    m_lID = value;
            }
        }
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "LOC_CD", 0, 0, 30)]
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "LOT_NO", 0, 0, 50)]
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "PACK_NO", 0, 0, 50)]
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
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "OPEN_QTY", 16, 6, 9)]
        public NZDecimal OPEN_QTY
        {
            get { return m_dOPEN_QTY; }
            set
            {
                if (value == null)
                    m_dOPEN_QTY.Value = value;
                else
                    m_dOPEN_QTY = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "IN_QTY", 16, 6, 9)]
        public NZDecimal IN_QTY
        {
            get { return m_dIN_QTY; }
            set
            {
                if (value == null)
                    m_dIN_QTY.Value = value;
                else
                    m_dIN_QTY = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "OUT_QTY", 16, 6, 9)]
        public NZDecimal OUT_QTY
        {
            get { return m_dOUT_QTY; }
            set
            {
                if (value == null)
                    m_dOUT_QTY.Value = value;
                else
                    m_dOUT_QTY = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "ADJUST_QTY", 16, 6, 9)]
        public NZDecimal ADJUST_QTY
        {
            get { return m_dADJUST_QTY; }
            set
            {
                if (value == null)
                    m_dADJUST_QTY.Value = value;
                else
                    m_dADJUST_QTY = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "STOCK_TAKE_QTY", 16, 6, 9)]
        public NZDecimal STOCK_TAKE_QTY
        {
            get { return m_dSTOCK_TAKE_QTY; }
            set
            {
                if (value == null)
                    m_dSTOCK_TAKE_QTY.Value = value;
                else
                    m_dSTOCK_TAKE_QTY = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "ON_HAND_QTY", 16, 6, 9)]
        public NZDecimal ON_HAND_QTY
        {
            get { return m_dON_HAND_QTY; }
            set
            {
                if (value == null)
                    m_dON_HAND_QTY.Value = value;
                else
                    m_dON_HAND_QTY = value;
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
        /// <summary>
        /// Last Trn In (Receive,Issue In)
        /// </summary>
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

        [Field(typeof(System.String), typeof(NZString), DataType.Int32, "OLD_DATA", 10, 0, 4)]
        public NZInt OLD_DATA
        {
            get { return m_strOLD_DATA; }
            set
            {
                if (value == null)
                    m_strOLD_DATA.Value = value;
                else
                    m_strOLD_DATA = value;
            }
        }

        [Field(typeof(System.Int32), typeof(NZInt), DataType.Default, "TIME_STAMP", 10, 0, 4)]
        public NZInt TIME_STAMP
        {
            get { return m_iTIME_STAMP; }
            set
            {
                if (value == null)
                    m_iTIME_STAMP.Value = value;
                else
                    m_iTIME_STAMP = value;
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
                values.Add(eColumns.ID.ToString());

                //Add PrimaryKey Name
                return new MapKeyValue<string, List<string>>("PK_TB_INV_ONHAND_TR", values);
            }
        }
        /// <summary>
        /// Return list or array's unique key fields.
        /// </summary>
        /// <remarks>
        /// If this table mapping not has unique key, return null value.
        /// </remarks>
        public override Map<string, List<string>> UniqueKeys
        {

            get
            {
                Map<string, List<string>> idxKeys = new Map<string, List<string>>();

                List<string> values = null;


                //IDX1
                values = new List<string>();
                values.Add(eColumns.YEAR_MONTH.ToString());
                values.Add(eColumns.ITEM_CD.ToString());
                values.Add(eColumns.LOC_CD.ToString());
                values.Add(eColumns.LOT_NO.ToString());
                values.Add(eColumns.PACK_NO.ToString());

                idxKeys.Put("UNQ_INV_ONHAND_TR", values);


                return idxKeys;
            }
        }
        #endregion

        #region " Helper "
        /*
		public void SaveDTO() {
			InventoryOnhandDTO dto = new InventoryOnhandDTO();
			dto.ID = 
			dto.YEAR_MONTH = 
			dto.PERIOD_BEGIN_DATE = 
			dto.PERIOD_END_DATE = 
			dto.ITEM_CD = 
			dto.LOC_CD = 
			dto.LOT_NO = 
			dto.OPEN_QTY = 
			dto.IN_QTY = 
			dto.OUT_QTY = 
			dto.ADJUST_QTY = 
			dto.STOCK_TAKE_QTY = 
			dto.ON_HAND_QTY = 
			dto.CRT_BY = 
			dto.CRT_DATE = 
			dto.CRT_MACHINE = 
			dto.UPD_BY = 
			dto.UPD_DATE = 
			dto.UPD_MACHINE = 
			dto.LAST_RECEIVE_DATE = 
		}
		*/
        #endregion
    }
}

