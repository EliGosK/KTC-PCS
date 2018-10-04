/*
 *		Author: Ms. Sansanee K.
 *      Team : SI-EVO
 * 		Writed On 2012/03/02
 * 		Time : 04:48 PM
 *  	This is DTO for TB_INV_TRANS_TR Table.
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
    [DataTransferObject("TB_INV_TRANS_TR", typeof(eColumns))]
    public class InventoryTransactionDTO : AbstractDTO
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
            TRANS_ID,
            ITEM_CD,
            LOC_CD,
            LOT_NO,
            FG_NO,
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
        private NZString m_strTRANS_ID = new NZString();
        private NZString m_strITEM_CD = new NZString();
        private NZString m_strLOC_CD = new NZString();
        private NZString m_strLOT_NO = new NZString();
        private NZString m_strFG_NO = new NZString();
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
        private NZInt m_iOLD_DATA = new NZInt();
        private NZInt m_iTIME_STAMP = new NZInt();
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "TRANS_ID", 0, 0, 30)]
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "EXTERNAL_LOT_NO", 0, 0, 30)]
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
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "TRANS_CLS", 0, 0, 30)]
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
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "IN_OUT_CLS", 0, 0, 30)]
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "OBJ_ITEM_CD", 0, 0, 30)]
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "REF_NO", 0, 0, 30)]
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "REF_SLIP_NO", 0, 0, 30)]
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "REF_SLIP_CLS", 0, 0, 30)]
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "OTHER_DL_NO", 0, 0, 30)]
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "SLIP_NO", 0, 0, 30)]
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "DEALING_NO", 0, 0, 30)]
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "FOR_CUSTOMER", 0, 0, 30)]
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "FOR_MACHINE", 0, 0, 30)]
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "SHIFT_CLS", 0, 0, 30)]
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "REF_SLIP_NO2", 0, 0, 30)]
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "TRAN_SUB_CLS", 0, 0, 30)]
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "SCREEN_TYPE", 0, 0, 30)]
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "GROUP_TRANS_ID", 0, 0, 30)]
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "NG_REASON", 0, 0, 255)]
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
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Int32, "TIME_STAMP", 10, 0, 4)]
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
                values.Add(eColumns.TRANS_ID.ToString());

                //Add PrimaryKey Name
                return new MapKeyValue<string, List<string>>("PK_TB_INV_TRANS_TR", values);
            }
        }
        #endregion

        #region " Helper "
        /*
		public void SaveDTO() {
			InventoryTransactionDTO dto = new InventoryTransactionDTO();
			dto.CRT_BY = 
			dto.CRT_DATE = 
			dto.CRT_MACHINE = 
			dto.UPD_BY = 
			dto.UPD_DATE = 
			dto.UPD_MACHINE = 
			dto.TRANS_ID = 
			dto.ITEM_CD = 
			dto.LOC_CD = 
			dto.LOT_NO = 
			dto.PACK_NO = 
			dto.EXTERNAL_LOT_NO = 
			dto.TRANS_DATE = 
			dto.TRANS_CLS = 
			dto.IN_OUT_CLS = 
			dto.QTY = 
			dto.WEIGHT = 
			dto.OBJ_ITEM_CD = 
			dto.OBJ_ORDER_QTY = 
			dto.REF_NO = 
			dto.REF_SLIP_NO = 
			dto.REF_SLIP_CLS = 
			dto.OTHER_DL_NO = 
			dto.SLIP_NO = 
			dto.REMARK = 
			dto.DEALING_NO = 
			dto.PRICE = 
			dto.AMOUNT = 
			dto.FOR_CUSTOMER = 
			dto.FOR_MACHINE = 
			dto.SHIFT_CLS = 
			dto.REF_SLIP_NO2 = 
			dto.NG_QTY = 
			dto.NG_WEIGHT = 
			dto.TRAN_SUB_CLS = 
			dto.SCREEN_TYPE = 
			dto.GROUP_TRANS_ID = 
			dto.RESERVE_QTY = 
			dto.NG_REASON = 
			dto.EFFECT_STOCK = 
			dto.LOT_REMARK = 
			dto.PERSON_IN_CHARGE = 
			dto.CURRENCY = 
			dto.OLD_DATA = 
			dto.TIME_STAMP = 
		}
		*/
        #endregion
    }
}

