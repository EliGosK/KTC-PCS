using System;
using System.Collections.Generic;
using System.Text;
using EVOFramework.Database;
using EVOFramework;
using Rubik.DTO;
using System.Data;

namespace Rubik.DAO
{
    public class SalesSummaryDAO : BaseDAO
    {
        public SalesSummaryDAO(Database db)
        {
            m_db = db;
        }

        public DataTable LoadSalesSummary(Database database, NZDateTime dtDateFrom, NZDateTime dtDateTo)
        {
            DataTable dtRet = null;

            Database db = UseDatabase(database);

            //StringBuilder sb = new StringBuilder();

            DataRequest req = new DataRequest();
            req.CommandType = CommandType.StoredProcedure;

            req.CommandText = "S_SUM010_LoadSalesSummary";
            req.Parameters.Add("@pDtm_DateFrom", DataType.DateTime, dtDateFrom.Value);
            req.Parameters.Add("@pDtm_DateTo", DataType.DateTime, dtDateTo.Value);


            DataSet ds = db.ExecuteDataSet(req);


            if (ds != null && ds.Tables.Count > 0)
            {
                dtRet = ds.Tables[0];
            }

            return dtRet;
        }

        public DataTable LoadSalesSummary(Database database, NZDateTime dtDateFrom)
        {
            DataTable dtRet = null;

            Database db = UseDatabase(database);

            //StringBuilder sb = new StringBuilder();

            DataRequest req = new DataRequest();
            req.CommandType = CommandType.StoredProcedure;

            req.CommandText = "S_SUM020_SalesSummaryReport";
            req.Parameters.Add("@pDtm_YearMonth", DataType.DateTime, dtDateFrom.Value);

            DataSet ds = db.ExecuteDataSet(req);


            if (ds != null && ds.Tables.Count > 0)
            {
                dtRet = ds.Tables[0];
            }

            return dtRet;
        }
    }
}