/*
 *		Author: Mr.Teerayut S
 *      Team : SI-EVO
 * 		Writed On 2010/06/21
 * 		Time : 05:18 PM
 *  	This is DTO for TB_ITEM_MS Table.
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
    [DataTransferObject("TB_ITEM_MS", typeof(eColumns))]
    public class ItemDTO : AbstractDTO
    {
        #region " Enums Columns "
        public enum eColumns {
            CRT_BY,
            CRT_DATE,
            CRT_MACHINE,
            UPD_BY,
            UPD_DATE,
            UPD_MACHINE,
            ITEM_CD,
            SHORT_NAME,
            ITEM_DESC,
            KIND_OF_PRODUCT,
            CUSTOMER_CD,
            CUSTOMER_USE_POINT,
            WEIGHT,
            BOI,
            PRODUCTION_DI,
            ITEM_LEVEL,
            MAT_NAME,
            MAT_SIZE,
            MAT_SUPPLIER_CD,
            KIND_OF_MAT,
            MAT_DI,
            REMARK,
            SCREW_KIND,
            SCREW_HEAD,
            SCREW_M,
            SCREW_L,
            SCREW_TYPE,
            SCREW_REMARK1,
            SCREW_REMARK2,
            HEXABULAR,
            PROCESS1,
            MACHINE_TYPE1,
            PROCESS2,
            MACHINE_TYPE2,
            PROCESS3,
            MACHINE_TYPE3,
            PROCESS4,
            MACHINE_TYPE4,
            PROCESS5,
            MACHINE_TYPE5,
            PROCESS6,
            MACHINE_TYPE6,
            HEAT_FLAG,
            HEAT_TYPE,
            HEAT_HARDNESS,
            HEAT_CORE_HARDNESS,
            HEAT_CASE_DEPTH,
            PLATING_FLAG,
            PLATING_KIND,
            PLATING_SUPPLIER_CD,
            PLATING_THICKNESS1_1,
            PLATING_THICKNESS1_2,
            PLATING_THICKNESS2_1,
            PLATING_THICKNESS2_2,
            PLATING_KTC,
            BAKING_FLAG,
            BAKING_TIME,
            BAKING_TEMP,
            OTHER_TREATMENT1_FLAG,
            OTHER_TREATMENT1_KIND,
            OTHER_TREATMENT1_CONDITION,
            OTHER_TREATMENT2_FLAG,
            OTHER_TREATMENT2_KIND,
            OTHER_TREATMENT2_CONDITION,
            ROUTING_TEXT,
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
        private NZString m_strITEM_CD = new NZString();
        private NZString m_strSHORT_NAME = new NZString();
        private NZString m_strITEM_DESC = new NZString();
        private NZString m_strKIND_OF_PRODUCT = new NZString();
        private NZString m_strCUSTOMER_CD = new NZString();
        private NZString m_strCUSTOMER_USE_POINT = new NZString();
        private NZDecimal m_dWEIGHT = new NZDecimal();
        private NZString m_strBOI = new NZString();
        private NZString m_strPRODUCTION_DI = new NZString();
        private NZString m_strITEM_LEVEL = new NZString();
        private NZString m_strMAT_NAME = new NZString();
        private NZString m_strMAT_SIZE = new NZString();
        private NZString m_strMAT_SUPPLIER_CD = new NZString();
        private NZString m_strKIND_OF_MAT = new NZString();
        private NZString m_strMAT_DI = new NZString();
        private NZString m_strREMARK = new NZString();
        private NZString m_strSCREW_KIND = new NZString();
        private NZString m_strSCREW_HEAD = new NZString();
        private NZString m_strSCREW_M = new NZString();
        private NZString m_strSCREW_L = new NZString();
        private NZString m_strSCREW_TYPE = new NZString();
        private NZString m_strSCREW_REMARK1 = new NZString();
        private NZString m_strSCREW_REMARK2 = new NZString();
        private NZString m_strHEXABULAR = new NZString();
        private NZString m_strPROCESS1 = new NZString();
        private NZString m_strMACHINE_TYPE1 = new NZString();
        private NZString m_strPROCESS2 = new NZString();
        private NZString m_strMACHINE_TYPE2 = new NZString();
        private NZString m_strPROCESS3 = new NZString();
        private NZString m_strMACHINE_TYPE3 = new NZString();
        private NZString m_strPROCESS4 = new NZString();
        private NZString m_strMACHINE_TYPE4 = new NZString();
        private NZString m_strPROCESS5 = new NZString();
        private NZString m_strMACHINE_TYPE5 = new NZString();
        private NZString m_strPROCESS6 = new NZString();
        private NZString m_strMACHINE_TYPE6 = new NZString();
        private NZInt m_iHEAT_FLAG = new NZInt();
        private NZString m_strHEAT_TYPE = new NZString();
        private NZString m_strHEAT_HARDNESS = new NZString();
        private NZString m_strHEAT_CORE_HARDNESS = new NZString();
        private NZString m_strHEAT_CASE_DEPTH = new NZString();
        private NZInt m_iPLATING_FLAG = new NZInt();
        private NZString m_strPLATING_KIND = new NZString();
        private NZString m_strPLATING_SUPPLIER_CD = new NZString();
        private NZString m_strPLATING_THICKNESS1_1 = new NZString();
        private NZString m_strPLATING_THICKNESS1_2 = new NZString();
        private NZString m_strPLATING_THICKNESS2_1 = new NZString();
        private NZString m_strPLATING_THICKNESS2_2 = new NZString();
        private NZString m_strPLATING_KTC = new NZString();
        private NZInt m_iBAKING_FLAG = new NZInt();
        private NZString m_strBAKING_TIME = new NZString();
        private NZString m_strBAKING_TEMP = new NZString();
        private NZInt m_iOTHER_TREATMENT1_FLAG = new NZInt();
        private NZString m_strOTHER_TREATMENT1_KIND = new NZString();
        private NZString m_strOTHER_TREATMENT1_CONDITION = new NZString();
        private NZInt m_iOTHER_TREATMENT2_FLAG = new NZInt();
        private NZString m_strOTHER_TREATMENT2_KIND = new NZString();
        private NZString m_strOTHER_TREATMENT2_CONDITION = new NZString();
        private NZString m_strROUTING_TEXT = new NZString();
        private NZInt m_iOLD_DATA = new NZInt();
        #endregion

        #region " Constructor "

        #endregion

        #region " Getter and Setter properties "
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CRT_BY", 0, 0, 30)]
        public NZString CRT_BY {
            get { return m_strCRT_BY; }
            set {
                if (value == null)
                    m_strCRT_BY.Value = value;
                else
                    m_strCRT_BY = value;
            }
        }
        [Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "CRT_DATE", 23, 3, 8)]
        public NZDateTime CRT_DATE {
            get { return m_dtCRT_DATE; }
            set {
                if (value == null)
                    m_dtCRT_DATE.Value = value;
                else
                    m_dtCRT_DATE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CRT_MACHINE", 0, 0, 50)]
        public NZString CRT_MACHINE {
            get { return m_strCRT_MACHINE; }
            set {
                if (value == null)
                    m_strCRT_MACHINE.Value = value;
                else
                    m_strCRT_MACHINE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "UPD_BY", 0, 0, 30)]
        public NZString UPD_BY {
            get { return m_strUPD_BY; }
            set {
                if (value == null)
                    m_strUPD_BY.Value = value;
                else
                    m_strUPD_BY = value;
            }
        }
        [Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "UPD_DATE", 23, 3, 8)]
        public NZDateTime UPD_DATE {
            get { return m_dtUPD_DATE; }
            set {
                if (value == null)
                    m_dtUPD_DATE.Value = value;
                else
                    m_dtUPD_DATE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "UPD_MACHINE", 0, 0, 50)]
        public NZString UPD_MACHINE {
            get { return m_strUPD_MACHINE; }
            set {
                if (value == null)
                    m_strUPD_MACHINE.Value = value;
                else
                    m_strUPD_MACHINE = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ITEM_CD", 0, 0, 30)]
        public NZString ITEM_CD {
            get { return m_strITEM_CD; }
            set {
                if (value == null)
                    m_strITEM_CD.Value = value;
                else
                    m_strITEM_CD = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "SHORT_NAME", 0, 0, 50)]
        public NZString SHORT_NAME {
            get { return m_strSHORT_NAME; }
            set {
                if (value == null)
                    m_strSHORT_NAME.Value = value;
                else
                    m_strSHORT_NAME = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ITEM_DESC", 0, 0, 100)]
        public NZString ITEM_DESC {
            get { return m_strITEM_DESC; }
            set {
                if (value == null)
                    m_strITEM_DESC.Value = value;
                else
                    m_strITEM_DESC = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "KIND_OF_PRODUCT", 0, 0, 30)]
        public NZString KIND_OF_PRODUCT {
            get { return m_strKIND_OF_PRODUCT; }
            set {
                if (value == null)
                    m_strKIND_OF_PRODUCT.Value = value;
                else
                    m_strKIND_OF_PRODUCT = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CUSTOMER_CD", 0, 0, 30)]
        public NZString CUSTOMER_CD {
            get { return m_strCUSTOMER_CD; }
            set {
                if (value == null)
                    m_strCUSTOMER_CD.Value = value;
                else
                    m_strCUSTOMER_CD = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CUSTOMER_USE_POINT", 0, 0, 100)]
        public NZString CUSTOMER_USE_POINT {
            get { return m_strCUSTOMER_USE_POINT; }
            set {
                if (value == null)
                    m_strCUSTOMER_USE_POINT.Value = value;
                else
                    m_strCUSTOMER_USE_POINT = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "WEIGHT", 16, 6, 9)]
        public NZDecimal WEIGHT {
            get { return m_dWEIGHT; }
            set {
                if (value == null)
                    m_dWEIGHT.Value = value;
                else
                    m_dWEIGHT = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "BOI", 0, 0, 30)]
        public NZString BOI {
            get { return m_strBOI; }
            set {
                if (value == null)
                    m_strBOI.Value = value;
                else
                    m_strBOI = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "PRODUCTION_DI", 0, 0, 30)]
        public NZString PRODUCTION_DI {
            get { return m_strPRODUCTION_DI; }
            set {
                if (value == null)
                    m_strPRODUCTION_DI.Value = value;
                else
                    m_strPRODUCTION_DI = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ITEM_LEVEL", 0, 0, 30)]
        public NZString ITEM_LEVEL {
            get { return m_strITEM_LEVEL; }
            set {
                if (value == null)
                    m_strITEM_LEVEL.Value = value;
                else
                    m_strITEM_LEVEL = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "MAT_NAME", 0, 0, 100)]
        public NZString MAT_NAME {
            get { return m_strMAT_NAME; }
            set {
                if (value == null)
                    m_strMAT_NAME.Value = value;
                else
                    m_strMAT_NAME = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "MAT_SIZE", 0, 0, 100)]
        public NZString MAT_SIZE {
            get { return m_strMAT_SIZE; }
            set {
                if (value == null)
                    m_strMAT_SIZE.Value = value;
                else
                    m_strMAT_SIZE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "MAT_SUPPLIER_CD", 0, 0, 30)]
        public NZString MAT_SUPPLIER_CD {
            get { return m_strMAT_SUPPLIER_CD; }
            set {
                if (value == null)
                    m_strMAT_SUPPLIER_CD.Value = value;
                else
                    m_strMAT_SUPPLIER_CD = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "KIND_OF_MAT", 0, 0, 100)]
        public NZString KIND_OF_MAT {
            get { return m_strKIND_OF_MAT; }
            set {
                if (value == null)
                    m_strKIND_OF_MAT.Value = value;
                else
                    m_strKIND_OF_MAT = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "MAT_DI", 0, 0, 100)]
        public NZString MAT_DI {
            get { return m_strMAT_DI; }
            set {
                if (value == null)
                    m_strMAT_DI.Value = value;
                else
                    m_strMAT_DI = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "REMARK", 0, 0, 255)]
        public NZString REMARK {
            get { return m_strREMARK; }
            set {
                if (value == null)
                    m_strREMARK.Value = value;
                else
                    m_strREMARK = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "SCREW_KIND", 0, 0, 100)]
        public NZString SCREW_KIND {
            get { return m_strSCREW_KIND; }
            set {
                if (value == null)
                    m_strSCREW_KIND.Value = value;
                else
                    m_strSCREW_KIND = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "SCREW_HEAD", 0, 0, 100)]
        public NZString SCREW_HEAD {
            get { return m_strSCREW_HEAD; }
            set {
                if (value == null)
                    m_strSCREW_HEAD.Value = value;
                else
                    m_strSCREW_HEAD = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "SCREW_M", 0, 0, 100)]
        public NZString SCREW_M {
            get { return m_strSCREW_M; }
            set {
                if (value == null)
                    m_strSCREW_M.Value = value;
                else
                    m_strSCREW_M = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "SCREW_L", 0, 0, 100)]
        public NZString SCREW_L {
            get { return m_strSCREW_L; }
            set {
                if (value == null)
                    m_strSCREW_L.Value = value;
                else
                    m_strSCREW_L = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "SCREW_TYPE", 0, 0, 100)]
        public NZString SCREW_TYPE {
            get { return m_strSCREW_TYPE; }
            set {
                if (value == null)
                    m_strSCREW_TYPE.Value = value;
                else
                    m_strSCREW_TYPE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "SCREW_REMARK1", 0, 0, 100)]
        public NZString SCREW_REMARK1 {
            get { return m_strSCREW_REMARK1; }
            set {
                if (value == null)
                    m_strSCREW_REMARK1.Value = value;
                else
                    m_strSCREW_REMARK1 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "SCREW_REMARK2", 0, 0, 100)]
        public NZString SCREW_REMARK2 {
            get { return m_strSCREW_REMARK2; }
            set {
                if (value == null)
                    m_strSCREW_REMARK2.Value = value;
                else
                    m_strSCREW_REMARK2 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "HEXABULAR", 0, 0, 100)]
        public NZString HEXABULAR {
            get { return m_strHEXABULAR; }
            set {
                if (value == null)
                    m_strHEXABULAR.Value = value;
                else
                    m_strHEXABULAR = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "PROCESS1", 0, 0, 100)]
        public NZString PROCESS1
        {
            get { return m_strPROCESS1; }
            set {
                if (value == null)
                    m_strPROCESS1.Value = value;
                else
                    m_strPROCESS1 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "MACHINE_TYPE1", 0, 0, 100)]
        public NZString MACHINE_TYPE1
        {
            get { return m_strMACHINE_TYPE1; }
            set {
                if (value == null)
                    m_strMACHINE_TYPE1.Value = value;
                else
                    m_strMACHINE_TYPE1 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "PROCESS2", 0, 0, 100)]
        public NZString PROCESS2
        {
            get { return m_strPROCESS2; }
            set
            {
                if (value == null)
                    m_strPROCESS2.Value = value;
                else
                    m_strPROCESS2 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "MACHINE_TYPE2", 0, 0, 100)]
        public NZString MACHINE_TYPE2
        {
            get { return m_strMACHINE_TYPE2; }
            set
            {
                if (value == null)
                    m_strMACHINE_TYPE2.Value = value;
                else
                    m_strMACHINE_TYPE2 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "PROCESS3", 0, 0, 100)]
        public NZString PROCESS3
        {
            get { return m_strPROCESS3; }
            set
            {
                if (value == null)
                    m_strPROCESS3.Value = value;
                else
                    m_strPROCESS3 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "MACHINE_TYPE3", 0, 0, 100)]
        public NZString MACHINE_TYPE3
        {
            get { return m_strMACHINE_TYPE3; }
            set
            {
                if (value == null)
                    m_strMACHINE_TYPE3.Value = value;
                else
                    m_strMACHINE_TYPE3 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "PROCESS4", 0, 0, 100)]
        public NZString PROCESS4
        {
            get { return m_strPROCESS4; }
            set
            {
                if (value == null)
                    m_strPROCESS4.Value = value;
                else
                    m_strPROCESS4 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "MACHINE_TYPE4", 0, 0, 100)]
        public NZString MACHINE_TYPE4
        {
            get { return m_strMACHINE_TYPE4; }
            set
            {
                if (value == null)
                    m_strMACHINE_TYPE4.Value = value;
                else
                    m_strMACHINE_TYPE4 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "PROCESS5", 0, 0, 100)]
        public NZString PROCESS5
        {
            get { return m_strPROCESS5; }
            set
            {
                if (value == null)
                    m_strPROCESS5.Value = value;
                else
                    m_strPROCESS5 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "MACHINE_TYPE5", 0, 0, 100)]
        public NZString MACHINE_TYPE5
        {
            get { return m_strMACHINE_TYPE5; }
            set
            {
                if (value == null)
                    m_strMACHINE_TYPE5.Value = value;
                else
                    m_strMACHINE_TYPE5 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "PROCESS6", 0, 0, 100)]
        public NZString PROCESS6
        {
            get { return m_strPROCESS6; }
            set
            {
                if (value == null)
                    m_strPROCESS6.Value = value;
                else
                    m_strPROCESS6 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "MACHINE_TYPE6", 0, 0, 100)]
        public NZString MACHINE_TYPE6
        {
            get { return m_strMACHINE_TYPE6; }
            set
            {
                if (value == null)
                    m_strMACHINE_TYPE6.Value = value;
                else
                    m_strMACHINE_TYPE6 = value;
            }
        }

        [Field(typeof(System.Int32), typeof(NZInt), DataType.Default, "HEAT_FLAG", 10, 0, 4)]
        public NZInt HEAT_FLAG {
            get { return m_iHEAT_FLAG; }
            set {
                if (value == null)
                    m_iHEAT_FLAG.Value = value;
                else
                    m_iHEAT_FLAG = value;
            }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "HEAT_TYPE", 0, 0, 100)]
        public NZString HEAT_TYPE {
            get { return m_strHEAT_TYPE; }
            set {
                if (value == null)
                    m_strHEAT_TYPE.Value = value;
                else
                    m_strHEAT_TYPE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "HEAT_HARDNESS", 0, 0, 100)]
        public NZString HEAT_HARDNESS {
            get { return m_strHEAT_HARDNESS; }
            set {
                if (value == null)
                    m_strHEAT_HARDNESS.Value = value;
                else
                    m_strHEAT_HARDNESS = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "HEAT_CORE_HARDNESS", 0, 0, 100)]
        public NZString HEAT_CORE_HARDNESS {
            get { return m_strHEAT_CORE_HARDNESS; }
            set {
                if (value == null)
                    m_strHEAT_CORE_HARDNESS.Value = value;
                else
                    m_strHEAT_CORE_HARDNESS = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "HEAT_CASE_DEPTH", 0, 0, 100)]
        public NZString HEAT_CASE_DEPTH {
            get { return m_strHEAT_CASE_DEPTH; }
            set {
                if (value == null)
                    m_strHEAT_CASE_DEPTH.Value = value;
                else
                    m_strHEAT_CASE_DEPTH = value;
            }
        }
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Default, "PLATING_FLAG", 10, 0, 4)]
        public NZInt PLATING_FLAG {
            get { return m_iPLATING_FLAG; }
            set {
                if (value == null)
                    m_iPLATING_FLAG.Value = value;
                else
                    m_iPLATING_FLAG = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "PLATING_KIND", 0, 0, 100)]
        public NZString PLATING_KIND {
            get { return m_strPLATING_KIND; }
            set {
                if (value == null)
                    m_strPLATING_KIND.Value = value;
                else
                    m_strPLATING_KIND = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "PLATING_SUPPLIER_CD", 0, 0, 100)]
        public NZString PLATING_SUPPLIER_CD {
            get { return m_strPLATING_SUPPLIER_CD; }
            set {
                if (value == null)
                    m_strPLATING_SUPPLIER_CD.Value = value;
                else
                    m_strPLATING_SUPPLIER_CD = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "PLATING_THICKNESS1_1", 0, 0, 100)]
        public NZString PLATING_THICKNESS1_1 {
            get { return m_strPLATING_THICKNESS1_1; }
            set {
                if (value == null)
                    m_strPLATING_THICKNESS1_1.Value = value;
                else
                    m_strPLATING_THICKNESS1_1 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "PLATING_THICKNESS1_2", 0, 0, 100)]
        public NZString PLATING_THICKNESS1_2 {
            get { return m_strPLATING_THICKNESS1_2; }
            set {
                if (value == null)
                    m_strPLATING_THICKNESS1_2.Value = value;
                else
                    m_strPLATING_THICKNESS1_2 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "PLATING_THICKNESS2_1", 0, 0, 100)]
        public NZString PLATING_THICKNESS2_1 {
            get { return m_strPLATING_THICKNESS2_1; }
            set {
                if (value == null)
                    m_strPLATING_THICKNESS2_1.Value = value;
                else
                    m_strPLATING_THICKNESS2_1 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "PLATING_THICKNESS2_2", 0, 0, 100)]
        public NZString PLATING_THICKNESS2_2 {
            get { return m_strPLATING_THICKNESS2_2; }
            set {
                if (value == null)
                    m_strPLATING_THICKNESS2_2.Value = value;
                else
                    m_strPLATING_THICKNESS2_2 = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "PLATING_KTC", 0, 0, 100)]
        public NZString PLATING_KTC {
            get { return m_strPLATING_KTC; }
            set {
                if (value == null)
                    m_strPLATING_KTC.Value = value;
                else
                    m_strPLATING_KTC = value;
            }
        }
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Default, "BAKING_FLAG", 10, 0, 4)]
        public NZInt BAKING_FLAG {
            get { return m_iBAKING_FLAG; }
            set {
                if (value == null)
                    m_iBAKING_FLAG.Value = value;
                else
                    m_iBAKING_FLAG = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "BAKING_TIME", 0, 0, 100)]
        public NZString BAKING_TIME {
            get { return m_strBAKING_TIME; }
            set {
                if (value == null)
                    m_strBAKING_TIME.Value = value;
                else
                    m_strBAKING_TIME = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "BAKING_TEMP", 0, 0, 100)]
        public NZString BAKING_TEMP {
            get { return m_strBAKING_TEMP; }
            set {
                if (value == null)
                    m_strBAKING_TEMP.Value = value;
                else
                    m_strBAKING_TEMP = value;
            }
        }
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Default, "OTHER_TREATMENT1_FLAG", 10, 0, 4)]
        public NZInt OTHER_TREATMENT1_FLAG {
            get { return m_iOTHER_TREATMENT1_FLAG; }
            set {
                if (value == null)
                    m_iOTHER_TREATMENT1_FLAG.Value = value;
                else
                    m_iOTHER_TREATMENT1_FLAG = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "OTHER_TREATMENT1_KIND", 0, 0, 100)]
        public NZString OTHER_TREATMENT1_KIND {
            get { return m_strOTHER_TREATMENT1_KIND; }
            set {
                if (value == null)
                    m_strOTHER_TREATMENT1_KIND.Value = value;
                else
                    m_strOTHER_TREATMENT1_KIND = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "OTHER_TREATMENT1_CONDITION", 0, 0, 100)]
        public NZString OTHER_TREATMENT1_CONDITION {
            get { return m_strOTHER_TREATMENT1_CONDITION; }
            set {
                if (value == null)
                    m_strOTHER_TREATMENT1_CONDITION.Value = value;
                else
                    m_strOTHER_TREATMENT1_CONDITION = value;
            }
        }
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Default, "OTHER_TREATMENT2_FLAG", 10, 0, 4)]
        public NZInt OTHER_TREATMENT2_FLAG {
            get { return m_iOTHER_TREATMENT2_FLAG; }
            set {
                if (value == null)
                    m_iOTHER_TREATMENT2_FLAG.Value = value;
                else
                    m_iOTHER_TREATMENT2_FLAG = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "OTHER_TREATMENT2_KIND", 0, 0, 100)]
        public NZString OTHER_TREATMENT2_KIND {
            get { return m_strOTHER_TREATMENT2_KIND; }
            set {
                if (value == null)
                    m_strOTHER_TREATMENT2_KIND.Value = value;
                else
                    m_strOTHER_TREATMENT2_KIND = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "OTHER_TREATMENT2_CONDITION", 0, 0, 100)]
        public NZString OTHER_TREATMENT2_CONDITION {
            get { return m_strOTHER_TREATMENT2_CONDITION; }
            set {
                if (value == null)
                    m_strOTHER_TREATMENT2_CONDITION.Value = value;
                else
                    m_strOTHER_TREATMENT2_CONDITION = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ROUTING_TEXT", 0, 0, 255)]
        public NZString ROUTING_TEXT {
            get { return m_strROUTING_TEXT; }
            set {
                if (value == null)
                    m_strROUTING_TEXT.Value = value;
                else
                    m_strROUTING_TEXT = value;
            }
        }
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Default, "OLD_DATA", 10, 0, 4)]
        public NZInt OLD_DATA {
            get { return m_iOLD_DATA; }
            set {
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
        public override MapKeyValue<string, List<string>> PrimaryKey {
            get {
                List<string> values = new List<string>();

                //Add MemberColums of PrimaryKey
                values.Add(eColumns.ITEM_CD.ToString());

                //Add PrimaryKey Name
                return new MapKeyValue<string, List<string>>("PK_TB_ITEM_MS", values);
            }
        }
        #endregion

        #region " Helper "
        /*
		public void SaveDTO() {
			ItemDTO dto = new ItemDTO();
			dto.CRT_BY = 
			dto.CRT_DATE = 
			dto.CRT_MACHINE = 
			dto.UPD_BY = 
			dto.UPD_DATE = 
			dto.UPD_MACHINE = 
			dto.ITEM_CD = 
			dto.SHORT_NAME = 
			dto.ITEM_DESC = 
			dto.KIND_OF_PRODUCT = 
			dto.CUSTOMER_CD = 
			dto.CUSTOMER_USE_POINT = 
			dto.WEIGHT = 
			dto.BOI = 
			dto.PRODUCTION_DI = 
			dto.ITEM_LEVEL = 
			dto.MAT_NAME = 
			dto.MAT_SIZE = 
			dto.MAT_SUPPLIER_CD = 
			dto.KIND_OF_MAT = 
			dto.MAT_DI = 
			dto.REMARK = 
			dto.SCREW_KIND = 
			dto.SCREW_HEAD = 
			dto.SCREW_M = 
			dto.SCREW_L = 
			dto.SCREW_TYPE = 
			dto.SCREW_REMARK1 = 
			dto.SCREW_REMARK2 = 
			dto.HEXABULAR = 
			dto.HEAT_FLAG = 
			dto.HEAT_TYPE = 
			dto.HEAT_HARDNESS = 
			dto.HEAT_CORE_HARDNESS = 
			dto.HEAT_CASE_DEPTH = 
			dto.PLATING_FLAG = 
			dto.PLATING_KIND = 
			dto.PLATING_SUPPLIER_CD = 
			dto.PLATING_THICKNESS1_1 = 
			dto.PLATING_THICKNESS1_2 = 
			dto.PLATING_THICKNESS2_1 = 
			dto.PLATING_THICKNESS2_2 = 
			dto.PLATING_KTC = 
			dto.BAKING_FLAG = 
			dto.BAKING_TIME = 
			dto.BAKING_TEMP = 
			dto.OTHER_TREATMENT1_FLAG = 
			dto.OTHER_TREATMENT1_KIND = 
			dto.OTHER_TREATMENT1_CONDITION = 
			dto.OTHER_TREATMENT2_FLAG = 
			dto.OTHER_TREATMENT2_KIND = 
			dto.OTHER_TREATMENT2_CONDITION = 
			dto.OLD_DATA = 
		}
		*/
        #endregion
    }
}

