/*
 *		Author: Mr.Teerayut S
 *      Team : SI-EVO
 * 		Writed On 2553/08/10
 * 		Time : 01:39 PM
 *  	This is DTO for TB_INV_TRANS_LOG Table.
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
    [DataTransferObject("TB_INV_TRANS_TR_LOG", typeof(eColumns))]
    public class InvTranLogDTO : AbstractDTO
    {
        #region " Enums Columns "
        public enum eColumns
        {
            ID,
            OPERATION_TYPE,
            OPERATION_DATE,
            OPERATION_MACHINE,
            OPERATION_USER,
            CRT_BY,
            CRT_DATE,
            CRT_MACHINE,
            UPD_BY,
            UPD_DATE,
            UPD_MACHINE,
            TRANS_ID,
            ITEM_CD,
            LOC_CD,
            LOT_NO,
            PACK_NO,
            EXTERNAL_LOT_NO,
            TRANS_DATE,
            TRANS_CLS,
            IN_OUT_CLS,
            QTY,
            WEIGHT,
            OBJ_ITEM_CD,
            OBJ_ORDER_QTY,
            REF_NO,
            REF_SLIP_NO,
            REF_SLIP_CLS,
            OTHER_DL_NO,
            SLIP_NO,
            REMARK,
            DEALING_NO,
            PRICE,
            AMOUNT,
            FOR_CUSTOMER,
            FOR_MACHINE,
            SHIFT_CLS,
            REF_SLIP_NO2,
            NG_QTY,
            NG_WEIGHT,
            TRAN_SUB_CLS,
            SCREEN_TYPE,
            GROUP_TRANS_ID,
            RESERVE_QTY,
            RETURN_QTY,
            NG_REASON,
            EFFECT_STOCK,
            LOT_REMARK,
            PERSON_IN_CHARGE,
            CURRENCY,
            REWORK_FLAG,
            FG_NO,
            OLD_DATA,
            TIME_STAMP
        };
        #endregion

        #region " Variables "
        private NZLong m_lID = new NZLong();
        private NZString m_strOPERATION_TYPE = new NZString();
        private NZDateTime m_dtOPERATION_DATE = new NZDateTime();
        private NZString m_strOPERATION_MACHINE = new NZString();
        private NZString m_strOPERATION_USER = new NZString();
        private NZString m_strCRT_BY = new NZString();
        private NZDateTime m_dtCRT_DATE = new NZDateTime();
        private NZString m_strCRT_MACHINE = new NZString();
        private NZString m_strUPD_BY = new NZString();
        private NZDateTime m_dtUPD_DATE = new NZDateTime();
        private NZString m_strUPD_MACHINE = new NZString();
        private NZString m_strTRANS_ID = new NZString();
        private NZString m_strITEM_CD = new NZString();
        private NZString m_strLOC_CD = new NZString();
        private NZString m_strLOT_NO = new NZString();
        private NZString m_strPACK_NO = new NZString();
        private NZString m_strEXTERNAL_LOT_NO = new NZString();
        private NZDateTime m_dtTRANS_DATE = new NZDateTime();
        private NZString m_strTRANS_CLS = new NZString();
        private NZString m_strIN_OUT_CLS = new NZString();
        private NZDecimal m_dQTY = new NZDecimal();
        private NZDecimal m_dWEIGHT = new NZDecimal();
        private NZString m_strOBJ_ITEM_CD = new NZString();
        private NZDecimal m_dOBJ_ORDER_QTY = new NZDecimal();
        private NZString m_strREF_NO = new NZString();
        private NZString m_strREF_SLIP_NO = new NZString();
        private NZString m_strREF_SLIP_CLS = new NZString();
        private NZString m_strOTHER_DL_NO = new NZString();
        private NZString m_strSLIP_NO = new NZString();
        private NZString m_strREMARK = new NZString();
        private NZString m_strDEALING_NO = new NZString();
        private NZDecimal m_dPRICE = new NZDecimal();
        private NZDecimal m_dAMOUNT = new NZDecimal();
        private NZString m_strFOR_CUSTOMER = new NZString();
        private NZString m_strFOR_MACHINE = new NZString();
        private NZString m_strSHIFT_CLS = new NZString();
        private NZString m_strREF_SLIP_NO2 = new NZString();
        private NZDecimal m_dNG_QTY = new NZDecimal();
        private NZDecimal m_dNG_WEIGHT = new NZDecimal();
        private NZString m_strTRAN_SUB_CLS = new NZString();
        private NZString m_strSCREEN_TYPE = new NZString();
        private NZString m_strGROUP_TRANS_ID = new NZString();
        private NZDecimal m_dRESERVE_QTY = new NZDecimal();
        private NZDecimal m_dRETURN_QTY = new NZDecimal();
        private NZString m_strNG_REASON = new NZString();

        private NZInt m_iEFFECT_STOCK = new NZInt();
        private NZString m_strLOT_REMARK = new NZString();
        private NZString m_strPERSON_IN_CHARGE = new NZString();
        private NZString m_strCURRENCY = new NZString();
        private NZInt m_iREWORK_FLAG = new NZInt();
        private NZString m_strFG_NO = new NZString();
        private NZInt m_iOLD_DATA = new NZInt();
        private NZByteArray m_TIME_STAMP = new NZByteArray();

        #endregion

        #region " Constructor "

        #endregion

        #region " Getter and Setter properties "
        [Field(typeof(System.Int64), typeof(NZLong), DataType.Int64, "ID", 19, 0, 8)]
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "OPERATION_TYPE", 0, 0, 10)]
        public NZString OPERATION_TYPE
        {
            get { return m_strOPERATION_TYPE; }
            set
            {
                if (value == null)
                    m_strOPERATION_TYPE.Value = value;
                else
                    m_strOPERATION_TYPE = value;
            }
        }
        [Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "OPERATION_DATE", 23, 3, 8)]
        public NZDateTime OPERATION_DATE
        {
            get { return m_dtOPERATION_DATE; }
            set
            {
                if (value == null)
                    m_dtOPERATION_DATE.Value = value;
                else
                    m_dtOPERATION_DATE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "OPERATION_MACHINE", 0, 0, 50)]
        public NZString OPERATION_MACHINE
        {
            get { return m_strOPERATION_MACHINE; }
            set
            {
                if (value == null)
                    m_strOPERATION_MACHINE.Value = value;
                else
                    m_strOPERATION_MACHINE = value;
            }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "OPERATION_USER", 0, 0, 15)]
        public NZString OPERATION_USER
        {
            get { return m_strOPERATION_USER; }
            set
            {
                if (value == null)
                    m_strOPERATION_USER.Value = value;
                else
                    m_strOPERATION_USER = value;
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
        /// Running No
        /// </summary>
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "TRANS_ID", 0, 0, 20)]
        public NZString TRANS_ID
        {
            get { return m_strTRANS_ID; }
            set
            {
                if (value == null)
                    m_strTRANS_ID.Value = value;
                else
                    m_strTRANS_ID = value;
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "LOT_NO", 0, 0, 10)]
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
        /// <summary>
        /// Effected Inventory Date
        /// </summary>
        [FieldNotNull]
        [Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "TRANS_DATE", 23, 3, 8)]
        public NZDateTime TRANS_DATE
        {
            get { return m_dtTRANS_DATE; }
            set
            {
                if (value == null)
                    m_dtTRANS_DATE.Value = value;
                else
                    m_dtTRANS_DATE = value;
            }
        }
        /// <summary>
        /// Transaction Type
        /// </summary>
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "TRANS_CLS", 0, 0, 2)]
        public NZString TRANS_CLS
        {
            get { return m_strTRANS_CLS; }
            set
            {
                if (value == null)
                    m_strTRANS_CLS.Value = value;
                else
                    m_strTRANS_CLS = value;
            }
        }
        /// <summary>
        /// In/Out 1:In 2:out
        /// </summary>
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "IN_OUT_CLS", 0, 0, 2)]
        public NZString IN_OUT_CLS
        {
            get { return m_strIN_OUT_CLS; }
            set
            {
                if (value == null)
                    m_strIN_OUT_CLS.Value = value;
                else
                    m_strIN_OUT_CLS = value;
            }
        }
        [FieldNotNull]
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

        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "WEIGHT", 16, 6, 9)]
        public NZDecimal WEIGHT
        {
            get { return m_dWEIGHT; }
            set
            {
                if (value == null)
                    m_dWEIGHT.Value = value;
                else
                    m_dWEIGHT = value;
            }
        }

        /// <summary>
        /// Parent Item cd for Work resulk
        /// </summary>
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "OBJ_ITEM_CD", 0, 0, 35)]
        public NZString OBJ_ITEM_CD
        {
            get { return m_strOBJ_ITEM_CD; }
            set
            {
                if (value == null)
                    m_strOBJ_ITEM_CD.Value = value;
                else
                    m_strOBJ_ITEM_CD = value;
            }
        }
        /// <summary>
        /// Parent Item Qty for Work result
        /// </summary>
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "OBJ_ORDER_QTY", 16, 6, 9)]
        public NZDecimal OBJ_ORDER_QTY
        {
            get { return m_dOBJ_ORDER_QTY; }
            set
            {
                if (value == null)
                    m_dOBJ_ORDER_QTY.Value = value;
                else
                    m_dOBJ_ORDER_QTY = value;
            }
        }
        /// <summary>
        /// Transaction No of related data (swap)
        /// </summary>
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "REF_NO", 0, 0, 20)]
        public NZString REF_NO
        {
            get { return m_strREF_NO; }
            set
            {
                if (value == null)
                    m_strREF_NO.Value = value;
                else
                    m_strREF_NO = value;
            }
        }
        /// <summary>
        /// Our Main Document no (Ex. Invoice no[Ship] ,Po No [receive],Requisition No [Issue])
        /// </summary>
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "REF_SLIP_NO", 0, 0, 20)]
        public NZString REF_SLIP_NO
        {
            get { return m_strREF_SLIP_NO; }
            set
            {
                if (value == null)
                    m_strREF_SLIP_NO.Value = value;
                else
                    m_strREF_SLIP_NO = value;
            }
        }
        /// <summary>
        /// Define type of Ref Slip No
        /// </summary>
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "REF_SLIP_CLS", 0, 0, 20)]
        public NZString REF_SLIP_CLS
        {
            get { return m_strREF_SLIP_CLS; }
            set
            {
                if (value == null)
                    m_strREF_SLIP_CLS.Value = value;
                else
                    m_strREF_SLIP_CLS = value;
            }
        }
        /// <summary>
        /// Dealing Document ref ex receive[invoice]
        /// </summary>
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "OTHER_DL_NO", 0, 0, 20)]
        public NZString OTHER_DL_NO
        {
            get { return m_strOTHER_DL_NO; }
            set
            {
                if (value == null)
                    m_strOTHER_DL_NO.Value = value;
                else
                    m_strOTHER_DL_NO = value;
            }
        }
        /// <summary>
        /// Header No of Transaction for control multi-line
        /// </summary>
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "SLIP_NO", 0, 0, 20)]
        public NZString SLIP_NO
        {
            get { return m_strSLIP_NO; }
            set
            {
                if (value == null)
                    m_strSLIP_NO.Value = value;
                else
                    m_strSLIP_NO = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "REMARK", 0, 0, 200)]
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
      
        /// <summary>
        /// Relate Customer/Supplier Ex. Customer [Ship], Supplier [Receive]
        /// </summary>
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "DEALING_NO", 0, 0, 20)]
        public NZString DEALING_NO
        {
            get { return m_strDEALING_NO; }
            set
            {
                if (value == null)
                    m_strDEALING_NO.Value = value;
                else
                    m_strDEALING_NO = value;
            }
        }
        /// <summary>
        /// PO Price [Receive]
        /// </summary>
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
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "AMOUNT", 16, 6, 9)]
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "FOR_CUSTOMER", 0, 0, 20)]
        public NZString FOR_CUSTOMER
        {
            get { return m_strFOR_CUSTOMER; }
            set
            {
                if (value == null)
                    m_strFOR_CUSTOMER.Value = value;
                else
                    m_strFOR_CUSTOMER = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "FOR_MACHINE", 0, 0, 20)]
        public NZString FOR_MACHINE
        {
            get { return m_strFOR_MACHINE; }
            set
            {
                if (value == null)
                    m_strFOR_MACHINE.Value = value;
                else
                    m_strFOR_MACHINE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "SHIFT_CLS", 0, 0, 2)]
        public NZString SHIFT_CLS
        {
            get { return m_strSHIFT_CLS; }
            set
            {
                if (value == null)
                    m_strSHIFT_CLS.Value = value;
                else
                    m_strSHIFT_CLS = value;
            }
        }
        /// <summary>
        /// Our Document no (Ex. FG Requisition[Ship] , Job  No[Issue])
        /// </summary>
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "REF_SLIP_NO2", 0, 0, 20)]
        public NZString REF_SLIP_NO2
        {
            get { return m_strREF_SLIP_NO2; }
            set
            {
                if (value == null)
                    m_strREF_SLIP_NO2.Value = value;
                else
                    m_strREF_SLIP_NO2 = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "NG_QTY", 16, 6, 9)]
        public NZDecimal NG_QTY
        {
            get { return m_dNG_QTY; }
            set
            {
                if (value == null)
                    m_dNG_QTY.Value = value;
                else
                    m_dNG_QTY = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "NG_WEIGHT", 16, 6, 9)]
        public NZDecimal NG_WEIGHT
        {
            get { return m_dNG_WEIGHT; }
            set
            {
                if (value == null)
                    m_dNG_WEIGHT.Value = value;
                else
                    m_dNG_WEIGHT = value;
            }
        }
        /// <summary>
        /// Sub Type: Ex 01: Issue for PRD, I02: Engineer Sample, Adjust -> Reason Code
        /// </summary>
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "TRAN_SUB_CLS", 0, 0, 3)]
        public NZString TRAN_SUB_CLS
        {
            get { return m_strTRAN_SUB_CLS; }
            set
            {
                if (value == null)
                    m_strTRAN_SUB_CLS.Value = value;
                else
                    m_strTRAN_SUB_CLS = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "SCREEN_TYPE", 0, 0, 10)]
        public NZString SCREEN_TYPE
        {
            get { return m_strSCREEN_TYPE; }
            set
            {
                if (value == null)
                    m_strSCREEN_TYPE.Value = value;
                else
                    m_strSCREEN_TYPE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "GROUP_TRANS_ID", 0, 0, 40)]
        public NZString GROUP_TRANS_ID
        {
            get { return m_strGROUP_TRANS_ID; }
            set
            {
                if (value == null)
                    m_strGROUP_TRANS_ID.Value = value;
                else
                    m_strGROUP_TRANS_ID = value;
            }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "NG_REASON", 0, 0, 200)]
        public NZString NG_REASON
        {
            get { return m_strNG_REASON; }
            set
            {
                if (value == null)
                    m_strNG_REASON.Value = value;
                else
                    m_strNG_REASON = value;
            }
        }

        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "RESERVE_QTY", 16, 6, 9)]
        public NZDecimal RESERVE_QTY
        {
            get { return m_dRESERVE_QTY; }
            set
            {
                if (value == null)
                    m_dRESERVE_QTY.Value = value;
                else
                    m_dRESERVE_QTY = value;
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

        [Field(typeof(System.Int32), typeof(NZInt), DataType.Int32, "EFFECT_STOCK", 10, 0, 4)]
        public NZInt EFFECT_STOCK
        {
            get { return m_iEFFECT_STOCK; }
            set
            {
                if (value == null)
                    m_iEFFECT_STOCK.Value = value;
                else
                    m_iEFFECT_STOCK = value;
            }
        }


        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "LOT_REMARK", 0, 0, 255)]
        public NZString LOT_REMARK
        {
            get { return m_strLOT_REMARK; }
            set
            {
                if (value == null)
                    m_strLOT_REMARK.Value = value;
                else
                    m_strLOT_REMARK = value;
            }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "PERSON_IN_CHARGE", 0, 0, 100)]
        public NZString PERSON_IN_CHARGE
        {
            get { return m_strPERSON_IN_CHARGE; }
            set
            {
                if (value == null)
                    m_strPERSON_IN_CHARGE.Value = value;
                else
                    m_strPERSON_IN_CHARGE = value;
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

        [Field(typeof(System.Int32), typeof(NZInt), DataType.Int32, "REWORK_FLAG", 10, 0, 4)]
        public NZInt REWORK_FLAG
        {
            get { return m_iREWORK_FLAG; }
            set
            {
                if (value == null)
                    m_iREWORK_FLAG.Value = value;
                else
                    m_iREWORK_FLAG = value;
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

        [Field(typeof(System.Byte[]), typeof(NZByteArray), DataType.Byte, "TIME_STAMP", 10, 0, 4)]
        public NZByteArray TIME_STAMP
        {
            get { return m_TIME_STAMP; }
            set
            {
                if (value == null)
                    m_TIME_STAMP.Value = value;
                else
                    m_TIME_STAMP = value;
            }
        }

        #endregion

        #region " Overriden method "
        #endregion

        #region " Helper "
        /*
		public void SaveDTO() {
			InvTranLogDTO dto = new InvTranLogDTO();
			dto.OPERATION_TYPE = 
			dto.OPERATION_DATE = 
			dto.OPERATION_MACHINE = 
			dto.TRANS_ID = 
			dto.ITEM_CD = 
			dto.LOC_CD = 
			dto.LOT_NO = 
			dto.TRANS_DATE = 
			dto.TRANS_CLS = 
			dto.IN_OUT_CLS = 
			dto.QTY = 
			dto.OBJ_ITEM_CD = 
			dto.OBJ_ORDER_QTY = 
			dto.REF_NO = 
			dto.REF_SLIP_NO = 
			dto.REF_SLIP_CLS = 
			dto.OTHER_DL_NO = 
			dto.SLIP_NO = 
			dto.REMARK = 
			dto.CRT_BY = 
			dto.CRT_DATE = 
			dto.CRT_MACHINE = 
			dto.UPD_BY = 
			dto.UPD_DATE = 
			dto.UPD_MACHINE = 
			dto.DEALING_NO = 
			dto.SUPP_LOT_NO = 
			dto.PRICE = 
			dto.FOR_CUSTOMER = 
			dto.FOR_MACHINE = 
			dto.SHIFT_CLS = 
			dto.REF_SLIP_NO2 = 
			dto.NG_QTY = 
			dto.TRAN_SUB_CLS = 
			dto.SCREEN_TYPE = 
		}
		*/
        #endregion
    }
}

