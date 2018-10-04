using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using Rubik.BIZ;
using System.Data;

namespace Rubik.Validators {
    public class PackingValidator 
    {
        public ErrorItem CheckEmptyMasterNo(NZString MasterNo) 
        {
            if (MasterNo.IsNull)
                return new ErrorItem(MasterNo.Owner, TKPMessages.eValidate.VLM0166.ToString());
            return null;
        }

        public ErrorItem CheckPackingDate(NZDateTime PackingDate) 
        {
            if (PackingDate.IsNull) 
            {
                return new ErrorItem(PackingDate.Owner, TKPMessages.eValidate.VLM0187.ToString());
            }
            return null;
        }

        public ErrorItem CheckEmptyShiftType(NZString ShiftType) 
        {
            if (ShiftType.IsNull) {
                return new ErrorItem(ShiftType.Owner, TKPMessages.eValidate.VLM0081.ToString());
            }
            return null;
        }

        public ErrorItem CheckEmptyFGNo(NZString FGNo)
        {
            if (FGNo.IsNull)
            {
                return new ErrorItem(FGNo.Owner, TKPMessages.eValidate.VLM0229.ToString());
            }
            return null;
        }

        public ErrorItem CheckPackNo(NZString PackNo) 
        {
            if (PackNo.IsNull)
                return new ErrorItem(PackNo.Owner, TKPMessages.eValidate.VLM0188.ToString());

            return null;
        }

        public ErrorItem CheckUnpackingDate(NZDateTime UnpackingDate)
        {
            if (UnpackingDate.IsNull)
            {
                return new ErrorItem(UnpackingDate.Owner, TKPMessages.eValidate.VLM0216.ToString());
            }
            return null;
        }
    }
}
