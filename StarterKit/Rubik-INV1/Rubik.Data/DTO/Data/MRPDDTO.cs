/*
 *		Author: 
 *      Team : SI-EVO
 * 		Writed On 2554/06/23
 * 		Time : 10:57 AM
 *  	This is DTO for TB_MRP_D_TR Table.
 *		From Templates Version : 
 *		Last Modify Template On : 
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
    [DataTransferObject("TB_MRP_D_TR", typeof(eColumns))]
    public class MRPDDTO : AbstractDTO
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
            IS_ACTIVE,
            MRP_NO,
            ITEM_CD,
            ORDER_LOC_CD,
            AT_DATE,
            INCOMING_QTY,
            OUTGOING_QTY,
            REQ_QTY,
            ACT_REQ_QTY,
            ACT_REQ_LOT_QTY,
            ORDER_QTY,
            ON_HAND_QTY,
            BAL_QTY,
            BAL_LOT_QTY
        };
        #endregion

        #region " Variables "
        private NZString m_strCRT_BY = new NZString();
        private NZDateTime m_dtCRT_DATE = new NZDateTime();
        private NZString m_strCRT_MACHINE = new NZString();
        private NZString m_strUPD_BY = new NZString();
        private NZDateTime m_dtUPD_DATE = new NZDateTime();
        private NZString m_strUPD_MACHINE = new NZString();
        private NZDecimal m_dIS_ACTIVE = new NZDecimal();
        private NZString m_strMRP_NO = new NZString();
        private NZString m_strITEM_CD = new NZString();
        private NZString m_strORDER_LOC_CD = new NZString();
        private NZDateTime m_dtAT_DATE = new NZDateTime();
        private NZDecimal m_dINCOMING_QTY = new NZDecimal();
        private NZDecimal m_dOUTGOING_QTY = new NZDecimal();
        private NZDecimal m_dREQ_QTY = new NZDecimal();
        private NZDecimal m_dACT_REQ_QTY = new NZDecimal();
        private NZDecimal m_dACT_REQ_LOT_QTY = new NZDecimal();
        private NZDecimal m_dORDER_QTY = new NZDecimal();
        private NZDecimal m_dON_HAND_QTY = new NZDecimal();
        private NZDecimal m_dBAL_QTY = new NZDecimal();
        private NZDecimal m_dBAL_LOT_QTY = new NZDecimal();
        #endregion

        #region " Constructor "

        #endregion

        #region " Getter and Setter properties "
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
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "IS_ACTIVE", 1, 0, 5)]
        public NZDecimal IS_ACTIVE
        {
            get { return m_dIS_ACTIVE; }
            set
            {
                if (value == null)
                    m_dIS_ACTIVE.Value = value;
                else
                    m_dIS_ACTIVE = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "MRP_NO", 0, 0, 30)]
        public NZString MRP_NO
        {
            get { return m_strMRP_NO; }
            set
            {
                if (value == null)
                    m_strMRP_NO.Value = value;
                else
                    m_strMRP_NO = value;
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
        [FieldNotNull]
        [Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "AT_DATE", 23, 3, 8)]
        public NZDateTime AT_DATE
        {
            get { return m_dtAT_DATE; }
            set
            {
                if (value == null)
                    m_dtAT_DATE.Value = value;
                else
                    m_dtAT_DATE = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "INCOMING_QTY", 16, 4, 9)]
        public NZDecimal INCOMING_QTY
        {
            get { return m_dINCOMING_QTY; }
            set
            {
                if (value == null)
                    m_dINCOMING_QTY.Value = value;
                else
                    m_dINCOMING_QTY = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "OUTGOING_QTY", 16, 4, 9)]
        public NZDecimal OUTGOING_QTY
        {
            get { return m_dOUTGOING_QTY; }
            set
            {
                if (value == null)
                    m_dOUTGOING_QTY.Value = value;
                else
                    m_dOUTGOING_QTY = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "REQ_QTY", 16, 4, 9)]
        public NZDecimal REQ_QTY
        {
            get { return m_dREQ_QTY; }
            set
            {
                if (value == null)
                    m_dREQ_QTY.Value = value;
                else
                    m_dREQ_QTY = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "ACT_REQ_QTY", 16, 4, 9)]
        public NZDecimal ACT_REQ_QTY
        {
            get { return m_dACT_REQ_QTY; }
            set
            {
                if (value == null)
                    m_dACT_REQ_QTY.Value = value;
                else
                    m_dACT_REQ_QTY = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "ACT_REQ_LOT_QTY", 16, 4, 9)]
        public NZDecimal ACT_REQ_LOT_QTY
        {
            get { return m_dACT_REQ_LOT_QTY; }
            set
            {
                if (value == null)
                    m_dACT_REQ_LOT_QTY.Value = value;
                else
                    m_dACT_REQ_LOT_QTY = value;
            }
        }
        /// <summary>
        /// [default =  ACT_REQ_LOT_QTY] but user can update order qty
        /// </summary>
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "ORDER_QTY", 16, 4, 9)]
        public NZDecimal ORDER_QTY
        {
            get { return m_dORDER_QTY; }
            set
            {
                if (value == null)
                    m_dORDER_QTY.Value = value;
                else
                    m_dORDER_QTY = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "ON_HAND_QTY", 16, 4, 9)]
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
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "BAL_QTY", 16, 4, 9)]
        public NZDecimal BAL_QTY
        {
            get { return m_dBAL_QTY; }
            set
            {
                if (value == null)
                    m_dBAL_QTY.Value = value;
                else
                    m_dBAL_QTY = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "BAL_LOT_QTY", 16, 4, 9)]
        public NZDecimal BAL_LOT_QTY
        {
            get { return m_dBAL_LOT_QTY; }
            set
            {
                if (value == null)
                    m_dBAL_LOT_QTY.Value = value;
                else
                    m_dBAL_LOT_QTY = value;
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
                values.Add(eColumns.MRP_NO.ToString());
                values.Add(eColumns.ITEM_CD.ToString());
                values.Add(eColumns.ORDER_LOC_CD.ToString());
                values.Add(eColumns.AT_DATE.ToString());

                //Add PrimaryKey Name
                return new MapKeyValue<string, List<string>>("PK_TB_MRP_D_TR", values);
            }
        }
        #endregion

        #region " Helper "
        /*
		public void SaveDTO() {
			MRPDDTO dto = new MRPDDTO();
			dto.CRT_BY = 
			dto.CRT_DATE = 
			dto.CRT_MACHINE = 
			dto.UPD_BY = 
			dto.UPD_DATE = 
			dto.UPD_MACHINE = 
			dto.IS_ACTIVE = 
			dto.MRP_NO = 
			dto.ITEM_CD = 
			dto.ORDER_LOC_CD = 
			dto.AT_DATE = 
			dto.INCOMING_QTY = 
			dto.OUTGOING_QTY = 
			dto.REQ_QTY = 
			dto.ACT_REQ_QTY = 
			dto.ACT_REQ_LOT_QTY = 
			dto.ORDER_QTY = 
			dto.ON_HAND_QTY = 
			dto.BAL_QTY = 
			dto.BAL_LOT_QTY = 
		}
		*/
        #endregion
    }
}

