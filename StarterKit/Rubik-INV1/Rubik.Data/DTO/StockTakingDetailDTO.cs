//Create Date 12 Oct 2010
//Author: Bunyapat L.
//Object Name: Stock Taking DTO
//Description: To use as parameter to pass stock taking detail data in system

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rubik.DTO
{
    public class StockTakingDetailDTO
    {
        public enum eColOCK_TAKINGD
        {
            CRT_BY,
            CRT_DATE,
            CRT_MACHINE,
            UPD_BY,
            UPD_DATE,
            UPD_MACHINE,
            STOCK_TAKING_DATE,
            ID,
            COUNTING_ID,
            ITEM_CD,
            LOC_CD,
            LOT_NO,
            EXTERNAL_LOT_NO,
            PACK_NO,
            FG_NO,
            SYSTEM_QTY,
            COUNT_QTY,
            DIFF_QTY,
            EFFECT_INVENTORY_FLAG,
            ADJUSTED_FLAG,
            MANUAL_ADD_FLAG,
            TAG_NO,
            REMARK,
            OLD_DATA,
        }

        private DateTime? m_dtmSTOCK_TAKING_DATE;
        private long? m_iID;
        private long? m_iCOUNTING_ID;
        private string m_strITEM_CD;
        private string m_strLOC_CD;
        private string m_strLOT_NO;
        private string m_strEXTERNAL_LOT_NO;
        private string m_strPACK_NO;
        private string m_strFG_NO;
        private decimal? m_decSYSTEM_QTY;
        private decimal? m_decCOUNT_QTY;
        private decimal? m_decDIFF_QTY;
        private int? m_iEFFECT_INVENTORY_FLAG;
        private int? m_iADJUSTED_FLAG;
        private int? m_iMANUAL_ADD_FLAG;
        private string m_strTAG_NO;
        private string m_strREMARK;
        private string m_strCRT_BY;
        private DateTime? m_dtmCRT_DATE;
        private string m_strCRT_MACHINE;
        private string m_strUPD_BY;
        private DateTime? m_dtmUPD_DATE;
        private string m_strUPD_MACHINE;
        private int? m_iROW_STATUS;

        public DateTime? STOCK_TAKING_DATE { get { return m_dtmSTOCK_TAKING_DATE; } set { m_dtmSTOCK_TAKING_DATE = value; } }
        public long? ID { get { return m_iID; } set { m_iID = value; } }
        public long? COUNTING_ID { get { return m_iCOUNTING_ID; } set { m_iCOUNTING_ID = value; } }
        public string ITEM_CD { get { return m_strITEM_CD; } set { m_strITEM_CD = value; } }
        public string LOC_CD { get { return m_strLOC_CD; } set { m_strLOC_CD = value; } }
        public string LOT_NO { get { return m_strLOT_NO; } set { m_strLOT_NO = value; } }
        public string EXTERNAL_LOT_NO { get { return m_strEXTERNAL_LOT_NO; } set { m_strEXTERNAL_LOT_NO = value; } }
        public string PACK_NO { get { return m_strPACK_NO; } set { m_strPACK_NO = value; } }
        public string FG_NO { get { return m_strFG_NO; } set { m_strFG_NO = value; } }
        public decimal? SYSTEM_QTY { get { return m_decSYSTEM_QTY; } set { m_decSYSTEM_QTY = value; } }
        public decimal? COUNT_QTY { get { return m_decCOUNT_QTY; } set { m_decCOUNT_QTY = value; } }
        public decimal? DIFF_QTY { get { return m_decDIFF_QTY; } set { m_decDIFF_QTY = value; } }
        public int? EFFECT_INVENTORY_FLAG { get { return m_iEFFECT_INVENTORY_FLAG; } set { m_iEFFECT_INVENTORY_FLAG = value; } }
        public int? ADJUSTED_FLAG { get { return m_iADJUSTED_FLAG; } set { m_iADJUSTED_FLAG = value; } }
        public int? MANUAL_ADD_FLAG { get { return m_iMANUAL_ADD_FLAG; } set { m_iMANUAL_ADD_FLAG = value; } }
        public string TAG_NO { get { return m_strTAG_NO; } set { m_strTAG_NO = value; } }
        public string REMARK { get { return m_strREMARK; } set { m_strREMARK = value; } }
        public string CRT_BY { get { return m_strCRT_BY; } set { m_strCRT_BY = value; } }
        public DateTime? CRT_DATE { get { return m_dtmCRT_DATE; } set { m_dtmCRT_DATE = value; } }
        public string CRT_MACHINE { get { return m_strCRT_MACHINE; } set { m_strCRT_MACHINE = value; } }
        public string UPD_BY { get { return m_strUPD_BY; } set { m_strUPD_BY = value; } }
        public DateTime? UPD_DATE { get { return m_dtmUPD_DATE; } set { m_dtmUPD_DATE = value; } }
        public string UPD_MACHINE { get { return m_strUPD_MACHINE; } set { m_strUPD_MACHINE = value; } }
        public int? ROW_STATUS { get { return m_iROW_STATUS; } set { m_iROW_STATUS = value; } }

    }
}
