using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using Rubik.BIZ;
using Rubik.DTO;
using System.Data;
using EVOFramework.Data;
using System.Collections;

namespace Rubik.Validators
{
    public class WorkResultEntryValidator
    {
        #region Check Single
        /// <summary>
        /// Check empty and not in current period.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
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

        public ErrorItem CheckWorkResultGoodQty(NZDecimal qty)
        {
            if (qty.IsNull || qty.StrongValue < 0)
            {
                return new ErrorItem(qty.Owner, TKPMessages.eValidate.VLM0048.ToString());
            }
            return null;
        }

        public ErrorItem CheckWorkResultQty(NZDecimal qty)
        {
            if (qty.IsNull || qty.StrongValue <= 0)
            {
                return new ErrorItem(qty.Owner, TKPMessages.eValidate.VLM0048.ToString());
            }
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

        #region Business Validate
        /// <summary>
        /// Validate data before load consumption list.
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="orderLocation"></param>
        /// <param name="qty"></param>
        public void ValidateBeforeLoadConsumption(NZString itemCode, NZString orderLocation, NZDecimal qty, NZString ConsumptionCls)
        {
            //== Check ItemCode.
            ItemValidator itemValidator = new ItemValidator();
            ValidateException.ThrowErrorItem(itemValidator.CheckEmptyItemCode(itemCode));

            BusinessException businessException = itemValidator.CheckItemNotExist(itemCode);
            if (businessException != null)
                ValidateException.ThrowErrorItem(businessException.Error);

            //== Check Order Location.
            DealingValidator locationValidator = new DealingValidator();
            if (ConsumptionCls.StrongValue == DataDefine.Convert2ClassCode(DataDefine.eCONSUMPTION_CLS.Manual))
            {
                ValidateException.ThrowErrorItem(locationValidator.CheckEmptyLocationCode(orderLocation));
                ValidateException.ThrowErrorItem(locationValidator.CheckNotExistsLocationCode(orderLocation));
            }


        }

        public ErrorItem CheckDifferentLocationOfItem(DataTable argConsumption)
        {
            List<WorkResultEntryViewDTO> listConsumption = DTOUtility.ConvertDataTableToList<WorkResultEntryViewDTO>(argConsumption);

            Dictionary<string, string> dictItemLocation = new Dictionary<string, string>();

            foreach (WorkResultEntryViewDTO dtoConsumption in listConsumption)
            {
                string strItemCode = dtoConsumption.ITEM_CD.StrongValue;
                if (dictItemLocation.ContainsKey(strItemCode))
                {
                    string strLocation = dictItemLocation[dtoConsumption.ITEM_CD.StrongValue];
                    if (!strLocation.Equals(dtoConsumption.LOC_CD.StrongValue))
                    {
                        return new ErrorItem(null, TKPMessages.eValidate.VLM0099.ToString(), new object[] { strItemCode });
                    }
                }
                else
                {
                    dictItemLocation.Add(dtoConsumption.ITEM_CD.StrongValue, dtoConsumption.LOC_CD.StrongValue);
                }

            }



            return null;
        }


        #endregion


    }
}
