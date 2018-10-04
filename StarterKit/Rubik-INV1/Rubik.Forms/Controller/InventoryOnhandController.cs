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
    public class InventoryOnhandController
    {

        internal List<InventoryOnhandInquiryViewDTO> LoadInventoryOnhand(NZString yearMonth, NZDateTime FromPeriod, NZDateTime ToPeriod, bool GroupByItem, int iToEndOfMonth)
        {
            InventoryBIZ biz = new InventoryBIZ();

            return biz.LoadInventoryOnhandInquiry(yearMonth, FromPeriod, ToPeriod, GroupByItem, iToEndOfMonth);

        }

        internal DataTable GetCostView(List<string> ItemCodes)
        {
            InventoryTransBIZ biz = new InventoryTransBIZ();

            return biz.LoadCostView(ItemCodes);
        }

        internal DataTable LoadInventorySummary(NZString yearMonth)
        {
            InventoryBIZ biz = new InventoryBIZ();

            return biz.LoadInventorySummary(yearMonth);

        }

    }
}
