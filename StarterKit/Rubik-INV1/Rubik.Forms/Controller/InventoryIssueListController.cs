using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rubik.BIZ;
using EVOFramework;

namespace Rubik.Controller
{
    public class InventoryIssueListController
    {
        internal System.Data.DataTable LoadAllIssueTransByPeriod(NZDateTime PERIOD_BEGIN_DATE, NZDateTime PERIOD_END_DATE, string ScreenType)
        {
            InventoryTransBIZ biz = new InventoryTransBIZ();
            return biz.LoadAllIssueTransByPeriod(PERIOD_BEGIN_DATE, PERIOD_END_DATE, ScreenType);
        }
    }
}
