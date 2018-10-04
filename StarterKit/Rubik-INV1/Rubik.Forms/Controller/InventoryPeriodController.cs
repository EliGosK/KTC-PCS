using System;
using EVOFramework;
using Rubik.BIZ;
using Rubik.DTO;

namespace Rubik.Controller
{
    class InventoryPeriodController
    {
        internal int UpdatePeriod(NZString YearMonth, NZDateTime PeriodBegin, NZDateTime PeriodEnd)
        {
            InventoryPeriodBIZ biz = new InventoryPeriodBIZ();
            InventoryPeriodDTO dto = new InventoryPeriodDTO();
            dto.YEAR_MONTH = YearMonth;
            dto.PERIOD_BEGIN_DATE = PeriodBegin;
            dto.PERIOD_END_DATE = PeriodEnd;
            dto.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dto.CRT_DATE.Value = CommonLib.Common.GetDatabaseDateTime();
            dto.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
            dto.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dto.UPD_DATE.Value = CommonLib.Common.GetDatabaseDateTime();
            dto.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
            return biz.UpdatePeriod(dto);
        }
    }
}
