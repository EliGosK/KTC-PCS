using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using Rubik.BIZ;
using Rubik.DTO;

namespace Rubik.Validators
{
    public class ProductionReportValidator
    {
        public ErrorItem CheckWorkResultDate(NZDateTime date)
        {
            if (date.IsNull)
            {
                return new ErrorItem(date.Owner, TKPMessages.eValidate.VLM0046.ToString());
            }

            InventoryPeriodBIZ biz = new InventoryPeriodBIZ();
            InventoryPeriodDTO dto = biz.LoadCurrentPeriod();
            if (dto == null)
                return new ErrorItem(date.Owner, TKPMessages.eValidate.VLM0047.ToString());

            // edit by tar
            // AddMonths(1) to period end date 
            if (date.StrongValue.Date.CompareTo(dto.PERIOD_BEGIN_DATE.StrongValue.Date) < 0 ||
                date.StrongValue.Date.CompareTo(dto.PERIOD_END_DATE.StrongValue.AddMonths(1).Date) > 0)
                return new ErrorItem(date.Owner, TKPMessages.eValidate.VLM0047.ToString());

            return null;
        }
        public ErrorItem CheckEmptyShiftType(NZString ShiftType)
        {
            if (ShiftType.IsNull)
            {
                return new ErrorItem(ShiftType.Owner, TKPMessages.eValidate.VLM0081.ToString());
            }
            return null;
        }
        public ErrorItem CheckEmptyMasterNo(NZString MasterNo)
        {
            if (MasterNo.IsNull)
                return new ErrorItem(MasterNo.Owner, TKPMessages.eValidate.VLM0166.ToString());
            return null;
        }
        public ErrorItem CheckMoveProcess(NZString Process)
        {
            if (Process.IsNull)
                return new ErrorItem(Process.Owner, TKPMessages.eValidate.VLM0160.ToString());
            return null;
        }
        public ErrorItem CheckProductionQty(NZDecimal qty)
        {
            if (qty.IsNull || qty.StrongValue <= 0)
            {
                return new ErrorItem(qty.Owner, TKPMessages.eValidate.VLM0048.ToString());
            }
            return null;
        }


    }
}
