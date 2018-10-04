using System;
using System.Data;
using System.Collections.Generic;
using SystemMaintenance.BIZ;
using SystemMaintenance.DTO;
using SystemMaintenance.SQLServer.DAO;
using Rubik.DAO;
using EVOFramework;
using Rubik.DTO;
using EVOFramework.Database;
using Rubik.Validators;
using CommonLib;

namespace Rubik.BIZ
{
    public class SalesSummaryBIZ
    {
        public DataTable LoadSalesSummary(NZDateTime dtDateFrom, NZDateTime dtDateTo)
        {
            SalesSummaryDAO dao = new SalesSummaryDAO(Common.CurrentDatabase);
            return dao.LoadSalesSummary(null, dtDateFrom, dtDateTo);
        }

        public DataTable LoadSalesSummary(NZDateTime dtDateFrom) 
        {
            SalesSummaryDAO dao = new SalesSummaryDAO(Common.CurrentDatabase);
            return dao.LoadSalesSummary(null, dtDateFrom);
        }
    }
}
