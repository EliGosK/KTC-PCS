/*
 *		Author: Ms. Sansanee K.
 *      Team : SI-EVO
 * 		Writed On 2012/03/20
 * 		Time : 02:36 PM
 *  	This is DTO for TB_BOM_MS Table.
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
    [DataTransferObject("TB_BOM_MS", typeof(eColumns))]
    public class BOMDTO : AbstractDTO
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
            UPPER_ITEM_CD,
            LOWER_ITEM_CD,
            ITEM_SEQ,
            UPPER_QTY,
            LOWER_QTY,
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
        private NZString m_iUPPER_ITEM_CD = new NZString();
        private NZString m_iLOWER_ITEM_CD = new NZString();
        private NZInt m_iITEM_SEQ = new NZInt();
        private NZDecimal m_dUPPER_QTY = new NZDecimal();
        private NZDecimal m_dLOWER_QTY = new NZDecimal();
        private NZInt m_iOLD_DATA = new NZInt();
        private NZByteArray m_baTIME_STAMP = new NZByteArray();
        #endregion

        #region " Constructor "

        #endregion

        #region " Getter and Setter properties "
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
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZInt), DataType.NVarChar, "UPPER_ITEM_CD", 0, 0, 30)]
        public NZString UPPER_ITEM_CD
        {
            get { return m_iUPPER_ITEM_CD; }
            set
            {
                if (value == null)
                    m_iUPPER_ITEM_CD.Value = value;
                else
                    m_iUPPER_ITEM_CD = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.Int32), typeof(NZString), DataType.NVarChar, "LOWER_ITEM_CD", 0, 0, 30)]
        public NZString LOWER_ITEM_CD
        {
            get { return m_iLOWER_ITEM_CD; }
            set
            {
                if (value == null)
                    m_iLOWER_ITEM_CD.Value = value;
                else
                    m_iLOWER_ITEM_CD = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.Int32, "ITEM_SEQ", 10, 0, 4)]
        public NZInt ITEM_SEQ
        {
            get { return m_iITEM_SEQ; }
            set
            {
                if (value == null)
                    m_iITEM_SEQ.Value = value;
                else
                    m_iITEM_SEQ = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "UPPER_QTY", 16, 6, 9)]
        public NZDecimal UPPER_QTY
        {
            get { return m_dUPPER_QTY; }
            set
            {
                if (value == null)
                    m_dUPPER_QTY.Value = value;
                else
                    m_dUPPER_QTY = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "LOWER_QTY", 16, 6, 9)]
        public NZDecimal LOWER_QTY
        {
            get { return m_dLOWER_QTY; }
            set
            {
                if (value == null)
                    m_dLOWER_QTY.Value = value;
                else
                    m_dLOWER_QTY = value;
            }
        }
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Int32, "OLD_DATA", 10, 0, 4)]
        public NZInt OLD_DATA
        {
            get { return m_iOLD_DATA; }
            set
            {
                if (value == null)
                    m_iOLD_DATA.Value = value;
                else
                    m_iOLD_DATA = value;
            }
        }
        [Field(typeof(System.Byte[]), typeof(NZByteArray), DataType.Object, "TIME_STAMP", 0, 0, 8)]
        public NZByteArray TIME_STAMP
        {
            get { return m_baTIME_STAMP; }
            set
            {
                if (value == null)
                    m_baTIME_STAMP.Value = value;
                else
                    m_baTIME_STAMP = value;
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
                values.Add(eColumns.UPPER_ITEM_CD.ToString());
                values.Add(eColumns.LOWER_ITEM_CD.ToString());
                values.Add(eColumns.ITEM_SEQ.ToString());

                //Add PrimaryKey Name
                return new MapKeyValue<string, List<string>>("PK_TB_BOM_MS", values);
            }
        }
        #endregion

        #region " Helper "
        /*
		public void SaveDTO() {
			BOMDTO dto = new BOMDTO();
			dto.CRT_BY = 
			dto.CRT_DATE = 
			dto.CRT_MACHINE = 
			dto.UPD_BY = 
			dto.UPD_DATE = 
			dto.UPD_MACHINE = 
			dto.UPPER_ITEM_CD = 
			dto.LOWER_ITEM_CD = 
			dto.ITEM_SEQ = 
			dto.UPPER_QTY = 
			dto.LOWER_QTY = 
			dto.OLD_DATA = 
			dto.TIME_STAMP = 
		}
		*/
        #endregion
    }
}

