/*
 *		Author: Ms. Sansanee K.
 *      Team : SI-EVO
 * 		Writed On 2012/03/02
 * 		Time : 12:12 PM
 *  	This is DTO for TB_CUSTOMER_ORDERD_TR Table.
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
    [DataTransferObject("TB_CUSTOMER_ORDERD_TR", typeof(eColumns))]
    public class CustomerOrderDDTO : AbstractDTO
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
            ORDER_NO,
            ORDER_DETAIL_NO,
            RUN_NO,
            ITEM_CD,
            ITEM_DELIVERY_DATE,
            QTY,
            PRICE,
            AMOUNT,
            AMOUNT_THB,
            SHIP_QTY,
            COMPLETE_FLAG,
            OLD_DATA
        };
        #endregion

        #region " Variables "
        private NZString m_strCRT_BY = new NZString();
        private NZDateTime m_dtCRT_DATE = new NZDateTime();
        private NZString m_strCRT_MACHINE = new NZString();
        private NZString m_strUPD_BY = new NZString();
        private NZDateTime m_dtUPD_DATE = new NZDateTime();
        private NZString m_strUPD_MACHINE = new NZString();
        private NZString m_strORDER_NO = new NZString();
        private NZString m_strORDER_DETAIL_NO = new NZString();
        private NZInt m_iRUN_NO = new NZInt();
        private NZString m_strITEM_CD = new NZString();
        private NZDateTime m_dtITEM_DELIVERY_DATE = new NZDateTime();
        private NZDecimal m_dQTY = new NZDecimal();
        private NZDecimal m_dPRICE = new NZDecimal();
        private NZDecimal m_dAMOUNT = new NZDecimal();
        private NZDecimal m_dAMOUNT_THB = new NZDecimal();
        private NZDecimal m_dSHIP_QTY = new NZDecimal();
        private NZInt m_iCOMPLETE_FLAG = new NZInt();
        private NZInt m_iOLD_DATA = new NZInt();
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ORDER_NO", 0, 0, 30)]
        public NZString ORDER_NO
        {
            get { return m_strORDER_NO; }
            set
            {
                if (value == null)
                    m_strORDER_NO.Value = value;
                else
                    m_strORDER_NO = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ORDER_DETAIL_NO", 0, 0, 30)]
        public NZString ORDER_DETAIL_NO
        {
            get { return m_strORDER_DETAIL_NO; }
            set
            {
                if (value == null)
                    m_strORDER_DETAIL_NO.Value = value;
                else
                    m_strORDER_DETAIL_NO = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Default, "RUN_NO", 10, 0, 4)]
        public NZInt RUN_NO
        {
            get { return m_iRUN_NO; }
            set
            {
                if (value == null)
                    m_iRUN_NO.Value = value;
                else
                    m_iRUN_NO = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ITEM_CD", 0, 0, 30)]
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
        [Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "ITEM_DELIVERY_DATE", 23, 3, 8)]
        public NZDateTime ITEM_DELIVERY_DATE
        {
            get { return m_dtITEM_DELIVERY_DATE; }
            set
            {
                if (value == null)
                    m_dtITEM_DELIVERY_DATE.Value = value;
                else
                    m_dtITEM_DELIVERY_DATE = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "QTY", 16, 6, 9)]
        public NZDecimal QTY
        {
            get { return m_dQTY; }
            set
            {
                if (value == null)
                    m_dQTY.Value = value;
                else
                    m_dQTY = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "PRICE", 16, 6, 9)]
        public NZDecimal PRICE
        {
            get { return m_dPRICE; }
            set
            {
                if (value == null)
                    m_dPRICE.Value = value;
                else
                    m_dPRICE = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "AMOUNT", 18, 6, 9)]
        public NZDecimal AMOUNT
        {
            get { return m_dAMOUNT; }
            set
            {
                if (value == null)
                    m_dAMOUNT.Value = value;
                else
                    m_dAMOUNT = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "AMOUNT_THB", 18, 6, 9)]
        public NZDecimal AMOUNT_THB
        {
            get { return m_dAMOUNT_THB; }
            set
            {
                if (value == null)
                    m_dAMOUNT_THB.Value = value;
                else
                    m_dAMOUNT_THB = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "SHIP_QTY", 16, 6, 9)]
        public NZDecimal SHIP_QTY
        {
            get { return m_dSHIP_QTY; }
            set
            {
                if (value == null)
                    m_dSHIP_QTY.Value = value;
                else
                    m_dSHIP_QTY = value;
            }
        }
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Default, "COMPLETE_FLAG", 10, 0, 4)]
        public NZInt COMPLETE_FLAG
        {
            get { return m_iCOMPLETE_FLAG; }
            set
            {
                if (value == null)
                    m_iCOMPLETE_FLAG.Value = value;
                else
                    m_iCOMPLETE_FLAG = value;
            }
        }
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Default, "OLD_DATA", 10, 0, 4)]
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
                values.Add(eColumns.ORDER_NO.ToString());
                values.Add(eColumns.RUN_NO.ToString());

                //Add PrimaryKey Name
                return new MapKeyValue<string, List<string>>("PK_TB_CUSTOMER_ORDERD_TR", values);
            }
        }
        #endregion

        #region " Helper "
        /*
		public void SaveDTO() {
			CustomerOrderDDTO dto = new CustomerOrderDDTO();
			dto.CRT_BY = 
			dto.CRT_DATE = 
			dto.CRT_MACHINE = 
			dto.UPD_BY = 
			dto.UPD_DATE = 
			dto.UPD_MACHINE = 
			dto.ORDER_NO = 
			dto.RUN_NO = 
			dto.ITEM_CD = 
			dto.ITEM_DELIVERY_DATE = 
			dto.QTY = 
			dto.PRICE = 
			dto.AMOUNT = 
			dto.AMOUNT_THB = 
			dto.SHIP_QTY = 
			dto.COMPLETE_FLAG = 
			dto.OLD_DATA = 
		}
		*/
        #endregion
    }
}

