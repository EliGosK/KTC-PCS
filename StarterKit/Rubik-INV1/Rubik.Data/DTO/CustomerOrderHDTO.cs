/*
 *		Author: Ms. Sansanee K.
 *      Team : SI-EVO
 * 		Writed On 2012/03/02
 * 		Time : 12:11 PM
 *  	This is DTO for TB_CUSTOMER_ORDERH_TR Table.
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
    [DataTransferObject("TB_CUSTOMER_ORDERH_TR", typeof(eColumns))]
    public class CustomerOrderHDTO : AbstractDTO
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
            RECEIVE_DATE,
            CUSTOMER_CD,
            ORDER_TYPE,
            CURRENCY,
            PO_NO,
            PO_DATE,
            EXCHANGE_RATE,
            REMARK,
            TOTAL_QTY,
            TOTAL_AMOUNT,
            TOTAL_AMOUNT_THB,
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
        private NZDateTime m_dtRECEIVE_DATE = new NZDateTime();
        private NZString m_strCUSTOMER_CD = new NZString();
        private NZString m_strORDER_TYPE = new NZString();
        private NZString m_strCURRENCY = new NZString();
        private NZString m_strPO_NO = new NZString();
        private NZDateTime m_dtPO_DATE = new NZDateTime();
        private NZDecimal m_dEXCHANGE_RATE = new NZDecimal();
        private NZString m_strREMARK = new NZString();
        private NZDecimal m_dTOTAL_QTY = new NZDecimal();
        private NZDecimal m_dTOTAL_AMOUNT = new NZDecimal();
        private NZDecimal m_dTOTAL_AMOUNT_THB = new NZDecimal();
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
        [Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "RECEIVE_DATE", 23, 3, 8)]
        public NZDateTime RECEIVE_DATE
        {
            get { return m_dtRECEIVE_DATE; }
            set
            {
                if (value == null)
                    m_dtRECEIVE_DATE.Value = value;
                else
                    m_dtRECEIVE_DATE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CUSTOMER_CD", 0, 0, 50)]
        public NZString CUSTOMER_CD
        {
            get { return m_strCUSTOMER_CD; }
            set
            {
                if (value == null)
                    m_strCUSTOMER_CD.Value = value;
                else
                    m_strCUSTOMER_CD = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ORDER_TYPE", 0, 0, 30)]
        public NZString ORDER_TYPE
        {
            get { return m_strORDER_TYPE; }
            set
            {
                if (value == null)
                    m_strORDER_TYPE.Value = value;
                else
                    m_strORDER_TYPE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CURRENCY", 0, 0, 30)]
        public NZString CURRENCY
        {
            get { return m_strCURRENCY; }
            set
            {
                if (value == null)
                    m_strCURRENCY.Value = value;
                else
                    m_strCURRENCY = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "PO_NO", 0, 0, 50)]
        public NZString PO_NO
        {
            get { return m_strPO_NO; }
            set
            {
                if (value == null)
                    m_strPO_NO.Value = value;
                else
                    m_strPO_NO = value;
            }
        }
        [Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "PO_DATE", 23, 3, 8)]
        public NZDateTime PO_DATE
        {
            get { return m_dtPO_DATE; }
            set
            {
                if (value == null)
                    m_dtPO_DATE.Value = value;
                else
                    m_dtPO_DATE = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "EXCHANGE_RATE", 16, 6, 9)]
        public NZDecimal EXCHANGE_RATE
        {
            get { return m_dEXCHANGE_RATE; }
            set
            {
                if (value == null)
                    m_dEXCHANGE_RATE.Value = value;
                else
                    m_dEXCHANGE_RATE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "REMARK", 0, 0, 255)]
        public NZString REMARK
        {
            get { return m_strREMARK; }
            set
            {
                if (value == null)
                    m_strREMARK.Value = value;
                else
                    m_strREMARK = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "TOTAL_QTY", 18, 6, 9)]
        public NZDecimal TOTAL_QTY
        {
            get { return m_dTOTAL_QTY; }
            set
            {
                if (value == null)
                    m_dTOTAL_QTY.Value = value;
                else
                    m_dTOTAL_QTY = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "TOTAL_AMOUNT", 18, 6, 9)]
        public NZDecimal TOTAL_AMOUNT
        {
            get { return m_dTOTAL_AMOUNT; }
            set
            {
                if (value == null)
                    m_dTOTAL_AMOUNT.Value = value;
                else
                    m_dTOTAL_AMOUNT = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "TOTAL_AMOUNT_THB", 18, 6, 9)]
        public NZDecimal TOTAL_AMOUNT_THB
        {
            get { return m_dTOTAL_AMOUNT_THB; }
            set
            {
                if (value == null)
                    m_dTOTAL_AMOUNT_THB.Value = value;
                else
                    m_dTOTAL_AMOUNT_THB = value;
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

                //Add PrimaryKey Name
                return new MapKeyValue<string, List<string>>("PK_TB_CUSTOMER_ORDER_TR", values);
            }
        }
        #endregion

        #region " Helper "
        /*
		public void SaveDTO() {
			CustomerOrderHDTO dto = new CustomerOrderHDTO();
			dto.CRT_BY = 
			dto.CRT_DATE = 
			dto.CRT_MACHINE = 
			dto.UPD_BY = 
			dto.UPD_DATE = 
			dto.UPD_MACHINE = 
			dto.ORDER_NO = 
			dto.RECEIVE_DATE = 
			dto.CUSTOMER_CD = 
			dto.ORDER_TYPE = 
			dto.CURRENCY = 
			dto.PO_NO = 
			dto.PO_DATE = 
			dto.EXCHANGE_RATE = 
			dto.REMARK = 
			dto.TOTAL_QTY = 
			dto.TOTAL_AMOUNT = 
			dto.TOTAL_AMOUNT_THB = 
			dto.OLD_DATA = 
		}
		*/
        #endregion
    }
}

