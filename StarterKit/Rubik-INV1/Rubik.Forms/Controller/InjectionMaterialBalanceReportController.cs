using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rubik.BIZ;
using EVOFramework;

namespace Rubik.Controller
{
   public class InjectionMaterialBalanceReportController
    {

        internal System.Data.DataTable GetReportTable(NZDateTime BeginDate, NZDateTime EndDate, NZString ItemA, NZString ItemB)
        {
            InventoryTransBIZ biz = new InventoryTransBIZ();
            return biz.LoadInjectionMaterialReportTable(BeginDate, EndDate, ItemA, ItemB);
        }
    }
}
