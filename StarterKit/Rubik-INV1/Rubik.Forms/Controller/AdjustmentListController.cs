using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using Rubik.BIZ;
using Rubik.DTO;

namespace Rubik.Controller
{
    internal class AdjustmentListController
    {
        public List<InventoryTransactionViewDTO> LoadAdjustmentList(NZDateTime beginPeriod, NZDateTime endPeriod)
        {
            InventoryTransBIZ biz = new InventoryTransBIZ();
            return biz.LoadAdjustmentList(beginPeriod, endPeriod, false);
        }
    }
}
