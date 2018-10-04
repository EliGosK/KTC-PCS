//Create Date 12 Oct 2010
//Author: Bunyapat L.
//Object Name: Stock Taking DTO
//Description: To use as parameter to pass stock taking data in system


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Data;

namespace Rubik.DTO
{
    public class StockTakingDTO
    {
        public DateTime STOCK_TAKING_DATE
        {
            get { return m_dtSTOCK_TAKING_DATE; }
            set { m_dtSTOCK_TAKING_DATE = value; }
        }
        public string YEAR_MONTH
        {
            get { return m_strYEAR_MONTH; }
            set { m_strYEAR_MONTH = value; }
        }
        public string PRE_PROCESS_BY
        {
            get { return m_strPRE_PROCESS_BY; }
            set { m_strPRE_PROCESS_BY = value; }
        }
        public DateTime PRE_PROCESS_DATE
        {
            get { return m_dtPRE_PROCESS_DATE; }
            set { m_dtPRE_PROCESS_DATE = value; }
        }
        public string REMARK
        {
            get { return m_strREMARK; }
            set { m_strREMARK = value; }
        }
        public string PRE_PROCESS_NAME
        {
            get { return m_strPRE_PROCESS_NAME; }
            set { m_strPRE_PROCESS_NAME = value; }
        }
        public string CRT_BY
        {
            get { return m_strCRT_BY; }
            set { m_strCRT_BY = value; }
        }
        public DateTime CRT_DATE
        {
            get { return m_dtCRT_DATE; }
            set { m_dtCRT_DATE = value; }
        }
        public string CRT_MACHINE
        {
            get { return m_strCRT_MACHINE; }
            set { m_strCRT_MACHINE = value; }
        }

        public string UPD_BY
        {
            get { return m_strUPD_BY; }
            set { m_strUPD_BY = value; }
        }
        public DateTime UPD_DATE
        {
            get { return m_dtUPD_DATE; }
            set { m_dtUPD_DATE = value; }
        }
        public string UPD_MACHINE
        {
            get { return m_strUPD_MACHINE; }
            set { m_strUPD_MACHINE = value; }
        }

        public string LOCATION_CODE
        {
            get { return m_strLOCATION_CODE; }
            set { m_strLOCATION_CODE = value; }
        }

        public int SEARCH_INCOMPLETE
        {
            get { return m_iSEARCH_INCOMPLETE; }
            set { m_iSEARCH_INCOMPLETE = value; }
        }

        public int SEARCH_DIFF
        {
            get { return m_iSEARCH_DIFF; }
            set { m_iSEARCH_DIFF = value; }
        }

        public int NO_MASTER
        {
            get { return m_iNO_MASTER; }
            set { m_iNO_MASTER = value; }
        }

        public string PART_NO
        {
            get { return m_strPART_NO; }
            set { m_strPART_NO = value; }
        }

        public string PART_TYPE
        {
            get { return m_strPART_TYPE; }
            set { m_strPART_TYPE = value; }
        }

        public string PART_SUB_TYPE
        {
            get { return m_strPART_SUB_TYPE; }
            set { m_strPART_SUB_TYPE = value; }
        }

        public string FOR_CUSTOMER
        {
            get { return m_strFOR_CUSTOMER; }
            set { m_strFOR_CUSTOMER = value; }
        }


        private DateTime m_dtSTOCK_TAKING_DATE;
        private string m_strYEAR_MONTH;
        private string m_strPRE_PROCESS_BY;
        private DateTime m_dtPRE_PROCESS_DATE;

        private string m_strREMARK;

        private string m_strPRE_PROCESS_NAME;
        private string m_strLOCATION_CODE;


        private string m_strCRT_BY;
        private DateTime m_dtCRT_DATE;
        private string m_strCRT_MACHINE;
        private string m_strUPD_BY;
        private DateTime m_dtUPD_DATE;
        private string m_strUPD_MACHINE;

        private int m_iSEARCH_INCOMPLETE;
        private int m_iSEARCH_DIFF;
        private int m_iNO_MASTER;

        private string m_strPART_NO;
        private string m_strPART_TYPE;
        private string m_strPART_SUB_TYPE;
        private string m_strFOR_CUSTOMER;
    }
}
