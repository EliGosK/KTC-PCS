//Create Date 14 Oct 2010
//Author: Bunyapat L.
//Object Name: Stock Taking Business
//Description: Business controller to print report

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Rubik.DTO;
using Rubik.DAO;

namespace Rubik.BIZ
{
    public class ReportBIZ
    {
        public DataSet LoadStockCheckingList(StockTakingDTO argSTK)
        {
            DataSet ret = null;

            ReportDAO dao = new ReportDAO(CommonLib.Common.CurrentDatabase);
            ret = dao.LoadStockCheckingList(argSTK);

            if (ret != null && ret.Tables.Count > 0)
            {
                ret.Tables[0].TableName = "S_STR010_StockCheckingList";
            }

            return ret;
        }

        public DataSet LoadStockCountingResultForExport(StockTakingDTO argSTK)
        {
            DataSet ret = null;

            ReportDAO dao = new ReportDAO(CommonLib.Common.CurrentDatabase);
            ret = dao.LoadStockCountingResultForExport(argSTK);

            return ret;
        }

        public DataSet LoadStockCountingResult(StockTakingDTO argSTK)
        {
            DataSet ret = null;

            ReportDAO dao = new ReportDAO(CommonLib.Common.CurrentDatabase);
            ret = dao.LoadStockCountingResult(argSTK);

            if (ret != null && ret.Tables.Count > 0)
            {
                ret.Tables[0].TableName = "S_STR020_StockCountingResult";
            }

            return ret;
        }

        public DataSet LoadEPR010(ReportCriteriaDTO.EPR010 argCriteria)
        {
            DataSet dsReturn = null;

            ReportDAO dao = new ReportDAO(CommonLib.Common.CurrentDatabase);
            dsReturn = dao.LoadEPR010(argCriteria);

            return dsReturn;
        }

        public DataSet LoadEPR020(ReportCriteriaDTO.EPR020 argCriteria)
        {
            DataSet dsReturn = null;

            ReportDAO dao = new ReportDAO(CommonLib.Common.CurrentDatabase);
            dsReturn = dao.LoadEPR020(argCriteria);

            return dsReturn;
        }

        public DataSet LoadIVR010_InventorySheet(ReportCriteriaDTO.IVR010 argCriteria)
        {
            DataSet dsReturn = null;

            ReportDAO dao = new ReportDAO(CommonLib.Common.CurrentDatabase);
            dsReturn = dao.LoadIVR010_InventorySheet(argCriteria);

            return dsReturn;
        }

        public DataSet LoadINV060_ProductionSummaryByItem(ReportCriteriaDTO.INV060 argCriteria)
        {
            DataSet dsReturn = null;

            ReportDAO dao = new ReportDAO(CommonLib.Common.CurrentDatabase);
            dsReturn = dao.LoadINV060_ProductionSummaryByItem(argCriteria);

            return dsReturn;

        }

        public DataSet LoadINV090_ProductionSummaryByMachine(ReportCriteriaDTO.INV090 argCriteria)
        {
            DataSet dsReturn = null;

            ReportDAO dao = new ReportDAO(CommonLib.Common.CurrentDatabase);
            dsReturn = dao.LoadINV090_ProductionSummaryByMachine(argCriteria);

            return dsReturn;
        }


        public DataSet LoadStockTakingTagSummary()
        {
            DataSet dsReturn = null;

            ReportDAO dao = new ReportDAO(CommonLib.Common.CurrentDatabase);
            dsReturn = dao.LoadStockTakingTagSummary();

            if (dsReturn != null && dsReturn.Tables.Count > 0)
            {
                dsReturn.Tables[0].TableName = "STR040_StockTakingTagSummary";
            }

            return dsReturn;
        }
    }
}
