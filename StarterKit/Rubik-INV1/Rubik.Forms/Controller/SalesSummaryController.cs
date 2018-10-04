using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rubik.BIZ;
using System.Data;
using EVOFramework;
using Rubik.DTO;

namespace Rubik.Controller
{
    public class SalesSummaryController
    {

        internal DataTable LoadSalesSummary(NZDateTime dtDateFrom, NZDateTime dtDateTo)
        {
            SalesSummaryBIZ biz = new SalesSummaryBIZ();

            return biz.LoadSalesSummary(dtDateFrom, dtDateTo);

        }

        internal DataTable LoadSalesSummary(NZDateTime dtDateFrom) {
            SalesSummaryBIZ biz = new SalesSummaryBIZ();

            return biz.LoadSalesSummary(dtDateFrom);

        }
    }
}
