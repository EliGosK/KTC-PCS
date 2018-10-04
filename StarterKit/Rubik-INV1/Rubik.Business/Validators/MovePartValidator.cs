using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using Rubik.BIZ;
using Rubik.DTO;

namespace Rubik.Validators {
    public class MovePartValidator
    {
        public ErrorItem CheckEmptyMoveNo(NZString MoveNo) {
            if (MoveNo.IsNull)
                return new ErrorItem(MoveNo.Owner, TKPMessages.eValidate.VLM0170.ToString());
            return null;
        }
        public ErrorItem CheckEmptyMoveDate(NZDateTime MoveDate) {
            if (MoveDate.IsNull)
                return new ErrorItem(MoveDate.Owner, TKPMessages.eValidate.VLM0171.ToString());
            return null;
        }
        public ErrorItem CheckEmptyShift(NZString Shift) {
            if (Shift.IsNull)
                return new ErrorItem(Shift.Owner, TKPMessages.eValidate.VLM0172.ToString());
            return null;
        }
        public ErrorItem CheckEmptyMasterNo(NZString MasterNo) {
            if (MasterNo.IsNull)
                return new ErrorItem(MasterNo.Owner, TKPMessages.eValidate.VLM0166.ToString());
            return null;
        }        
        public ErrorItem CheckMoveProcess(NZString FromProcess,NZString ToProcess) 
        {
            if (FromProcess.IsNull)
                return new ErrorItem(FromProcess.Owner, TKPMessages.eValidate.VLM0173.ToString());
            
            if (ToProcess.IsNull)
                return new ErrorItem(ToProcess.Owner, TKPMessages.eValidate.VLM0174.ToString());           

            if (FromProcess.StrongValue.Equals(ToProcess.StrongValue))
                return new ErrorItem(ToProcess.Owner, TKPMessages.eValidate.VLM0030.ToString());

            return null;
        }
        public ErrorItem CheckMoveQty(NZDecimal MoveQty, NZDecimal OnHandQty) 
        {
            if (MoveQty.IsNull || MoveQty.StrongValue == 0)
                return new ErrorItem(MoveQty.Owner, TKPMessages.eValidate.VLM0175.ToString());
            if (MoveQty.StrongValue < 0)
                return new ErrorItem(MoveQty.Owner, TKPMessages.eValidate.VLM0176.ToString());
            if (MoveQty.StrongValue > OnHandQty.StrongValue)
                return new ErrorItem(MoveQty.Owner, TKPMessages.eValidate.VLM0177.ToString());
            return null;
        }

        public ErrorItem CheckMoveDate(NZDateTime date)
        {
            InventoryPeriodBIZ biz = new InventoryPeriodBIZ();
            InventoryPeriodDTO dto = biz.LoadCurrentPeriod();
            if (dto == null)
                return new ErrorItem(date.Owner, TKPMessages.eValidate.VLM0075.ToString());

            // edit by tar
            // AddMonths(1) to period end date 
            if (date.StrongValue.Date.CompareTo(dto.PERIOD_BEGIN_DATE.StrongValue.Date) < 0 ||
                date.StrongValue.Date.CompareTo(dto.PERIOD_END_DATE.StrongValue.AddMonths(1).Date) > 0)
                return new ErrorItem(date.Owner, TKPMessages.eValidate.VLM0075.ToString());

            return null;
        }
    }
}
