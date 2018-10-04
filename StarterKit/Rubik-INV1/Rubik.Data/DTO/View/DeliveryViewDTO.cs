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
    [DataTransferObject("DELIVERY_VIEW", typeof(eColumns))]
    public class DeliveryViewDTO : AbstractDTO
    {
        #region " Enums Columns "
        public enum eColumns
        {
            //CRT_BY,
            //CRT_DATE,
            //CRT_MACHINE,
            //UPD_BY,
            //UPD_DATE,
            //UPD_MACHINE,

            ORDER_NO,
            ORDER_DETAIL_NO,
            //RECEIVE_DATE,
            CUSTOMER_CD,
            //LOC_CD,
            //LOC_DESC,
            //ORDER_TYPE,
            PO_NO,
            //PO_DATE,
            //CURRENCY,
            //EXCHANGE_RATE,
            //REMARK,
            ITEM_CD,
            SHORT_NAME,
            ITEM_DELIVERY_DATE,
            QTY,
            RETURN_QTY,
            PRICE,
            //PRICE_THB,
            AMOUNT,
            //AMOUNT_THB,

            //TOTAL_QTY,
            //TOTAL_AMOUNT,
            //TOTAL_AMOUNT_THB,

            //RUN_NO,
            SHIP_QTY,
            REMAIN_QTY,
            COMPLETE_FLAG,
            OLD_DATA,

            //PART_NO
        };
        #endregion

        #region " Variables "

        //private NZString m_strCRT_BY = new NZString();
        //private NZDateTime m_dtCRT_DATE = new NZDateTime();
        //private NZString m_strCRT_MACHINE = new NZString();
        //private NZString m_strUPD_BY = new NZString();
        //private NZDateTime m_dtUPD_DATE = new NZDateTime();
        //private NZString m_strUPD_MACHINE = new NZString();

        private NZString m_strORDER_NO = new NZString();
        private NZString m_strORDER_DETAIL_NO = new NZString();
        //private NZDateTime m_dtRECEIVE_DATE = new NZDateTime();
        private NZString m_strCUSTOMER_CD = new NZString();
        //private NZString m_strLOC_CD = new NZString();
        //private NZString m_strLOC_DESC = new NZString();
        //private NZString m_strORDER_TYPE = new NZString();
        private NZString m_strPO_NO = new NZString();
        //private NZDateTime m_dtPO_DATE = new NZDateTime();
        //private NZString m_strCURRENCY = new NZString();
        //private NZDecimal m_dEXCHANGE_RATE = new NZDecimal();
        //private NZString m_strREMARK = new NZString();

        private NZString m_strITEM_CD = new NZString();
        private NZString m_strSHORT_NAME = new NZString();
        private NZDateTime m_dtITEM_DELIVERY_DATE = new NZDateTime();
        private NZDecimal m_dQTY = new NZDecimal();
        private NZDecimal m_dRETURN_QTY = new NZDecimal();
        private NZDecimal m_dPRICE = new NZDecimal();
        //private NZDecimal m_dPRICE_THB = new NZDecimal();
        private NZDecimal m_dAMOUNT = new NZDecimal();
        //private NZDecimal m_dAMOUNT_THB = new NZDecimal();

        //private NZDecimal m_dTOTAL_QTY = new NZDecimal();
        //private NZDecimal m_dTOTAL_AMOUNT = new NZDecimal();
        //private NZDecimal m_dTOTAL_AMOUNT_THB = new NZDecimal();

        //private NZInt m_iRUN_NO = new NZInt();
        private NZDecimal m_dSHIP_QTY = new NZDecimal();
        private NZInt m_iCOMPLETE_FLAG = new NZInt();
        private NZInt m_iOLD_DATA = new NZInt();

        //private NZString m_strPART_NO = new NZString();

        private NZDecimal m_dREMAIN_QTY = new NZDecimal();
        #endregion

        #region " Getter and Setter properties "

        //[Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CRT_BY", 0, 0, 30)]
        //public NZString CRT_BY
        //{
        //    get { return m_strCRT_BY; }
        //    set
        //    {
        //        if (value == null)
        //            m_strCRT_BY.Value = value;
        //        else
        //            m_strCRT_BY = value;
        //    }
        //}
        //[Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "CRT_DATE", 23, 3, 8)]
        //public NZDateTime CRT_DATE
        //{
        //    get { return m_dtCRT_DATE; }
        //    set
        //    {
        //        if (value == null)
        //            m_dtCRT_DATE.Value = value;
        //        else
        //            m_dtCRT_DATE = value;
        //    }
        //}
        //[Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CRT_MACHINE", 0, 0, 50)]
        //public NZString CRT_MACHINE
        //{
        //    get { return m_strCRT_MACHINE; }
        //    set
        //    {
        //        if (value == null)
        //            m_strCRT_MACHINE.Value = value;
        //        else
        //            m_strCRT_MACHINE = value;
        //    }
        //}
        //[Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "UPD_BY", 0, 0, 30)]
        //public NZString UPD_BY
        //{
        //    get { return m_strUPD_BY; }
        //    set
        //    {
        //        if (value == null)
        //            m_strUPD_BY.Value = value;
        //        else
        //            m_strUPD_BY = value;
        //    }
        //}
        //[Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "UPD_DATE", 23, 3, 8)]
        //public NZDateTime UPD_DATE
        //{
        //    get { return m_dtUPD_DATE; }
        //    set
        //    {
        //        if (value == null)
        //            m_dtUPD_DATE.Value = value;
        //        else
        //            m_dtUPD_DATE = value;
        //    }
        //}
        //[Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "UPD_MACHINE", 0, 0, 50)]
        //public NZString UPD_MACHINE
        //{
        //    get { return m_strUPD_MACHINE; }
        //    set
        //    {
        //        if (value == null)
        //            m_strUPD_MACHINE.Value = value;
        //        else
        //            m_strUPD_MACHINE = value;
        //    }
        //}
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
        //[Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "RECEIVE_DATE", 23, 3, 8)]
        //public NZDateTime RECEIVE_DATE
        //{
        //    get { return m_dtRECEIVE_DATE; }
        //    set
        //    {
        //        if (value == null)
        //            m_dtRECEIVE_DATE.Value = value;
        //        else
        //            m_dtRECEIVE_DATE = value;
        //    }
        //}
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
        //[Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "LOC_CD", 0, 0, 30)]
        //public NZString LOC_CD
        //{
        //    get { return m_strLOC_CD; }
        //    set
        //    {
        //        if (value == null)
        //            m_strLOC_CD.Value = value;
        //        else
        //            m_strLOC_CD = value;
        //    }
        //}
        //[Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "LOC_DESC", 0, 0, 100)]
        //public NZString LOC_DESC
        //{
        //    get { return m_strLOC_DESC; }
        //    set
        //    {
        //        if (value == null)
        //            m_strLOC_DESC.Value = value;
        //        else
        //            m_strLOC_DESC = value;
        //    }
        //}
        //[Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ORDER_TYPE", 0, 0, 30)]
        //public NZString ORDER_TYPE
        //{
        //    get { return m_strORDER_TYPE; }
        //    set
        //    {
        //        if (value == null)
        //            m_strORDER_TYPE.Value = value;
        //        else
        //            m_strORDER_TYPE = value;
        //    }
        //}
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
        //[Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "PO_DATE", 23, 3, 8)]
        //public NZDateTime PO_DATE
        //{
        //    get { return m_dtPO_DATE; }
        //    set
        //    {
        //        if (value == null)
        //            m_dtPO_DATE.Value = value;
        //        else
        //            m_dtPO_DATE = value;
        //    }
        //}
        //[Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CURRENCY", 0, 0, 30)]
        //public NZString CURRENCY
        //{
        //    get { return m_strCURRENCY; }
        //    set
        //    {
        //        if (value == null)
        //            m_strCURRENCY.Value = value;
        //        else
        //            m_strCURRENCY = value;
        //    }
        //}
        //[Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "EXCHANGE_RATE", 16, 6, 9)]
        //public NZDecimal EXCHANGE_RATE
        //{
        //    get { return m_dEXCHANGE_RATE; }
        //    set
        //    {
        //        if (value == null)
        //            m_dEXCHANGE_RATE.Value = value;
        //        else
        //            m_dEXCHANGE_RATE = value;
        //    }
        //}
        //[Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "REMARK", 0, 0, 255)]
        //public NZString REMARK
        //{
        //    get { return m_strREMARK; }
        //    set
        //    {
        //        if (value == null)
        //            m_strREMARK.Value = value;
        //        else
        //            m_strREMARK = value;
        //    }
        //}
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "SHORT_NAME", 0, 0, 50)]
        public NZString SHORT_NAME
        {
            get { return m_strSHORT_NAME; }
            set
            {
                if (value == null)
                    m_strSHORT_NAME.Value = value;
                else
                    m_strSHORT_NAME = value;
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
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "RETURN_QTY", 16, 6, 9)]
        public NZDecimal RETURN_QTY
        {
            get { return m_dRETURN_QTY; }
            set
            {
                if (value == null)
                    m_dRETURN_QTY.Value = value;
                else
                    m_dRETURN_QTY = value;
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
        //[Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "PRICE_THB", 16, 6, 9)]
        //public NZDecimal PRICE_THB
        //{
        //    get { return m_dPRICE_THB; }
        //    set
        //    {
        //        if (value == null)
        //            m_dPRICE_THB.Value = value;
        //        else
        //            m_dPRICE_THB = value;
        //    }
        //}
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
        //[Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "AMOUNT_THB", 18, 6, 9)]
        //public NZDecimal AMOUNT_THB
        //{
        //    get { return m_dAMOUNT_THB; }
        //    set
        //    {
        //        if (value == null)
        //            m_dAMOUNT_THB.Value = value;
        //        else
        //            m_dAMOUNT_THB = value;
        //    }
        //}
        //[Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "TOTAL_QTY", 18, 6, 9)]
        //public NZDecimal TOTAL_QTY
        //{
        //    get { return m_dTOTAL_QTY; }
        //    set
        //    {
        //        if (value == null)
        //            m_dTOTAL_QTY.Value = value;
        //        else
        //            m_dTOTAL_QTY = value;
        //    }
        //}
        //[Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "TOTAL_AMOUNT", 18, 6, 9)]
        //public NZDecimal TOTAL_AMOUNT
        //{
        //    get { return m_dTOTAL_AMOUNT; }
        //    set
        //    {
        //        if (value == null)
        //            m_dTOTAL_AMOUNT.Value = value;
        //        else
        //            m_dTOTAL_AMOUNT = value;
        //    }
        //}
        //[Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "TOTAL_AMOUNT_THB", 18, 6, 9)]
        //public NZDecimal TOTAL_AMOUNT_THB
        //{
        //    get { return m_dTOTAL_AMOUNT_THB; }
        //    set
        //    {
        //        if (value == null)
        //            m_dTOTAL_AMOUNT_THB.Value = value;
        //        else
        //            m_dTOTAL_AMOUNT_THB = value;
        //    }
        //}
        //[Field(typeof(System.Int32), typeof(NZInt), DataType.Default, "RUN_NO", 10, 0, 4)]
        //public NZInt RUN_NO
        //{
        //    get { return m_iRUN_NO; }
        //    set
        //    {
        //        if (value == null)
        //            m_iRUN_NO.Value = value;
        //        else
        //            m_iRUN_NO = value;
        //    }
        //}
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
        //[Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "PART_NO", 0, 0, 50)]
        //public NZString PART_NO
        //{
        //    get { return m_strPART_NO; }
        //    set
        //    {
        //        if (value == null)
        //            m_strPART_NO.Value = value;
        //        else
        //            m_strPART_NO = value;
        //    }
        //}
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "REMAIN_QTY", 16, 6, 9)]
        public NZDecimal REMAIN_QTY
        {
            get { return m_dREMAIN_QTY; }
            set
            {
                if (value == null)
                    m_dREMAIN_QTY.Value = value;
                else
                    m_dREMAIN_QTY = value;
            }
        }
        #endregion

    }
}

