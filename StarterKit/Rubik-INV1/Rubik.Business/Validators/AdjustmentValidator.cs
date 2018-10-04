using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using Rubik.BIZ;
using Rubik.DAO;
using Rubik.DTO;

namespace Rubik.Validators
{
    public class AdjustmentValidator
    {
        #region Single Check
        #region Check Empty
        public ErrorItem CheckEmptyReasonCode(NZString reasonCode)
        {
            if (reasonCode.IsNull)
                return new ErrorItem(reasonCode.Owner, TKPMessages.eValidate.VLM0079.ToString());

            return null;
        }

        public ErrorItem CheckEmptyAdjustDate(NZDateTime adjustDate)
        {
            if (adjustDate.IsNull)
                return new ErrorItem(adjustDate.Owner, TKPMessages.eValidate.VLM0033.ToString());

            return null;
        }

        public ErrorItem CheckEmptyAdjustQty(NZDecimal adjustQty)
        {
            if (adjustQty.IsNull || adjustQty.StrongValue < decimal.Zero)
            {
                return new ErrorItem(adjustQty.Owner, TKPMessages.eValidate.VLM0035.ToString());
            }
            return null;
        }

        public ErrorItem CheckIsZeroAdjustQty(NZDecimal adjustQty)
        {
            if (adjustQty.NVL(0) == 0)
            {
                return new ErrorItem(adjustQty.Owner, TKPMessages.eValidate.VLM0035.ToString());
            }
            return null;
        }

        //public ErrorItem CheckInputLot(NZString itemCode, NZString lotNo) {
        //    ItemBIZ biz = new ItemBIZ();
        //    ItemDTO dto = biz.LoadItem(itemCode);

        //    switch (DataDefine.ConvertValue2Enum<DataDefine.eLOT_CONTROL_CLS>(dto.LOT_CONTROL_CLS.StrongValue)) {
        //        case DataDefine.eLOT_CONTROL_CLS.No:
        //            if (!lotNo.IsNull || lotNo.StrongValue != string.Empty) {
        //                return new ErrorItem(lotNo.Owner, TKPMessages.eValidate.VLM0065.ToString());
        //            }
        //            break;
        //        case DataDefine.eLOT_CONTROL_CLS.Yes:
        //            if (lotNo.IsNull || lotNo.StrongValue.Trim() == String.Empty) {
        //                return new ErrorItem(lotNo.Owner, TKPMessages.eValidate.VLM0050.ToString(), new object[] { itemCode.StrongValue });
        //            }
        //            break;
        //    }


        //    return null;
        //}
        #endregion

        public ErrorItem CheckAdjustDateIsInCurrentPeriod(NZDateTime adjustDate)
        {
            InventoryPeriodDAO inventoryPeriodDAO = new InventoryPeriodDAO(CommonLib.Common.CurrentDatabase);
            InventoryPeriodDTO inventoryPeriodDTO = inventoryPeriodDAO.LoadCurrentYearMonth(null);

            if (inventoryPeriodDTO == null)
            {
                return new ErrorItem(adjustDate.Owner, TKPMessages.eValidate.VLM0034.ToString());
            }
            if (inventoryPeriodDTO.PERIOD_BEGIN_DATE.StrongValue.Date > adjustDate.StrongValue.Date
                || inventoryPeriodDTO.PERIOD_END_DATE.StrongValue.AddMonths(1).Date < adjustDate.StrongValue.Date)
            {
                return new ErrorItem(adjustDate.Owner, TKPMessages.eValidate.VLM0034.ToString());
            }
            return null;
        }
        #endregion

        public ErrorItem CheckEmptyPackNo(NZString Pack)
        {
            if (Pack.IsNull)
                return new ErrorItem(Pack.Owner, TKPMessages.eValidate.VLM0218.ToString());
            return null;
        }

        public ErrorItem CheckEmptyLotNo(NZString Lot)
        {
            string[] str = new string[1];
            str[0] = "Lot No.";

            if (Lot.IsNull)
                return new ErrorItem(Lot.Owner, TKPMessages.eValidate.VLM0105.ToString(), str);
            return null;
        }

        public ErrorItem CheckEmptyCustomerLotNo(NZString CustLot)
        {
            string[] str = new string[1];
            str[0] = "Customer Lot No.";

            if (CustLot.IsNull)
                return new ErrorItem(CustLot.Owner, TKPMessages.eValidate.VLM0105.ToString(), str);
            return null;
        }


    }
}
