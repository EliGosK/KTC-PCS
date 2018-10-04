//Create Date 12 Oct 2010
//Author: Bunyapat L.
//Object Name: Report DAO
//Description: Data access layer to retrive report data


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Database;
using System.Data;
using Rubik.DTO;

namespace Rubik.DAO
{
    public class ReportDAO : BaseDAO
    {
        #region Variables

        private readonly Database m_db;

        #endregion

        #region Constructor

        public ReportDAO() { }

        public ReportDAO(Database db)
        {
            this.m_db = db;
        }

        #endregion

        public DataSet LoadStockCheckingList(StockTakingDTO argSTK)
        {
            DataSet ret = null;

            Database db = m_db;

            DataRequest req = new DataRequest();
            req.CommandText = "S_STR010_StockCheckingList";
            req.CommandType = CommandType.StoredProcedure;

            req.Parameters.Add("@pDtm_StockTakingDate", argSTK.STOCK_TAKING_DATE);
            req.Parameters.Add("@pVar_LocationCode", CheckNull(argSTK.LOCATION_CODE));
            req.Parameters.Add("@pVar_PartNo", CheckNull(argSTK.PART_NO));
            req.Parameters.Add("@pVar_PartType", CheckNull(argSTK.PART_TYPE));
            req.Parameters.Add("@pVar_PartSubType", CheckNull(argSTK.PART_SUB_TYPE));
            req.Parameters.Add("@pInt_IncompleteFlag", CheckNull(argSTK.SEARCH_INCOMPLETE));
            req.Parameters.Add("@pInt_DiffFlag", CheckNull(argSTK.SEARCH_DIFF));
            req.Parameters.Add("@pInt_NoMaster", CheckNull(argSTK.NO_MASTER));

            ret = m_db.ExecuteDataSet(req);

            return ret;
        }

        public DataSet LoadStockCountingResultForExport(StockTakingDTO argSTK)
        {
            DataSet ret = null;

            Database db = m_db;

            DataRequest req = new DataRequest();
            req.CommandText = "S_STR020_StockCountingResultForExport";
            req.CommandType = CommandType.StoredProcedure;

            req.Parameters.Add("@pDtm_StockTakingDate", argSTK.STOCK_TAKING_DATE.Date);
            req.Parameters.Add("@pVar_LocationCode", CheckNull(argSTK.LOCATION_CODE));
            req.Parameters.Add("@pVar_PartNo", CheckNull(argSTK.PART_NO));
            req.Parameters.Add("@pVar_PartType", CheckNull(argSTK.PART_TYPE));
            req.Parameters.Add("@pVar_PartSubType", CheckNull(argSTK.PART_SUB_TYPE));
            req.Parameters.Add("@pInt_IncompleteFlag", CheckNull(argSTK.SEARCH_INCOMPLETE));
            req.Parameters.Add("@pInt_DiffFlag", CheckNull(argSTK.SEARCH_DIFF));
            req.Parameters.Add("@pInt_NoMaster", CheckNull(argSTK.NO_MASTER));

            ret = m_db.ExecuteDataSet(req);

            return ret;
        }

        public DataSet LoadStockCountingResult(StockTakingDTO argSTK)
        {
            DataSet ret = null;

            Database db = m_db;

            DataRequest req = new DataRequest();
            req.CommandText = "S_STR020_StockCountingResult";
            req.CommandType = CommandType.StoredProcedure;

            req.Parameters.Add("@pDtm_StockTakingDate", argSTK.STOCK_TAKING_DATE);
            req.Parameters.Add("@pVar_LocationCode", CheckNull(argSTK.LOCATION_CODE));
            req.Parameters.Add("@pVar_PartNo", CheckNull(argSTK.PART_NO));
            req.Parameters.Add("@pVar_PartType", CheckNull(argSTK.PART_TYPE));
            req.Parameters.Add("@pVar_PartSubType", CheckNull(argSTK.PART_SUB_TYPE));
            req.Parameters.Add("@pInt_IncompleteFlag", CheckNull(argSTK.SEARCH_INCOMPLETE));
            req.Parameters.Add("@pInt_DiffFlag", CheckNull(argSTK.SEARCH_DIFF));
            req.Parameters.Add("@pInt_NoMaster", CheckNull(argSTK.NO_MASTER));

            ret = m_db.ExecuteDataSet(req);

            return ret;
        }

        public DataSet LoadEPR010(ReportCriteriaDTO.EPR010 argCriteria)
        {
            DataSet dsReturn = null;

            Database db = m_db;

            DataRequest req = new DataRequest();
            req.CommandText = "S_EPR010_LoadSummaryTransaction";
            req.CommandType = CommandType.StoredProcedure;

            req.Parameters.Add("@pDtm_DateFrom", argCriteria.DateFrom);
            req.Parameters.Add("@pDtm_DateTo", argCriteria.DateTo);
            req.Parameters.Add("@pVar_LocationFrom", CheckNull(argCriteria.LocationFrom));
            req.Parameters.Add("@pVar_LocationTo", CheckNull(argCriteria.LocationTo));
            req.Parameters.Add("@pVar_PartNoFrom", CheckNull(argCriteria.PartNoFrom));
            req.Parameters.Add("@pVar_PartNoTo", CheckNull(argCriteria.PartNoTo));
            req.Parameters.Add("@pVar_TransactionClass", CheckNull(argCriteria.TransactionClass));
            req.Parameters.Add("@pVar_InOutClass", CheckNull(argCriteria.InOutClass));

            dsReturn = m_db.ExecuteDataSet(req);

            return dsReturn;

        }

        public DataSet LoadEPR020(ReportCriteriaDTO.EPR020 argCriteria)
        {
            DataSet dsReturn = null;

            Database db = m_db;

            DataRequest req = new DataRequest();
            req.CommandText = "S_EPR020_LoadIssueSummary";
            req.CommandType = CommandType.StoredProcedure;

            req.Parameters.Add("@pDtm_DateFrom", argCriteria.DateFrom);
            req.Parameters.Add("@pDtm_DateTo", argCriteria.DateTo);
            req.Parameters.Add("@pVar_FromLocation", CheckNull(argCriteria.FromLocation));
            req.Parameters.Add("@pVar_ToLocation", CheckNull(argCriteria.ToLocation));
            req.Parameters.Add("@pVar_PartNoFrom", CheckNull(argCriteria.PartNoFrom));
            req.Parameters.Add("@pVar_PartNoTo", CheckNull(argCriteria.PartNoTo));

            dsReturn = m_db.ExecuteDataSet(req);

            return dsReturn;

        }

        public DataSet LoadIVR010_InventorySheet(ReportCriteriaDTO.IVR010 argCriteria)
        {
            DataSet dsReturn = null;

            Database db = m_db;

            DataRequest req = new DataRequest();
            req.CommandText = "S_IVR010_InventorySheet";
            req.CommandType = CommandType.StoredProcedure;
            req.Timeout = 180;

            req.Parameters.Add("@YearMonth", argCriteria.YearMonth);

            dsReturn = m_db.ExecuteDataSet(req);

            return dsReturn;

        }

        public DataSet LoadINV060_ProductionSummaryByItem(ReportCriteriaDTO.INV060 argCriteria)
        {
            DataSet dsReturn = null;
            Database db = m_db;

            DataRequest req = new DataRequest();
            req.CommandText = "S_INV060_ProductionSummaryByItem";
            req.CommandType = CommandType.StoredProcedure;
            req.Timeout = 180;

            req.Parameters.Add("@pDtm_DateFrom", argCriteria.DateFrom);
            req.Parameters.Add("@pDtm_DateTo", argCriteria.DateTo);

            dsReturn = m_db.ExecuteDataSet(req);

            return dsReturn;
        }

        public DataSet LoadINV090_ProductionSummaryByMachine(ReportCriteriaDTO.INV090 argCriteria)
        {
            DataSet dsReturn = null;
            Database db = m_db;

            DataRequest req = new DataRequest();
            req.CommandText = "S_INV090_ProductionSummaryByMachine";
            req.CommandType = CommandType.StoredProcedure;
            req.Timeout = 180;

            req.Parameters.Add("@pDtm_DateFrom", argCriteria.DateFrom);
            req.Parameters.Add("@pDtm_DateTo", argCriteria.DateTo);

            dsReturn = m_db.ExecuteDataSet(req);

            return dsReturn;
        }

        public DataSet LoadStockTakingTagSummary()
        {
            DataSet dsReturn = null;
            Database db = m_db;

            DataRequest req = new DataRequest();
            req.CommandText = "S_STR040_StockTakingTagSummary";
            req.CommandType = CommandType.StoredProcedure;
            req.Timeout = 180;

            dsReturn = m_db.ExecuteDataSet(req);

            return dsReturn;
        }
    }
}
