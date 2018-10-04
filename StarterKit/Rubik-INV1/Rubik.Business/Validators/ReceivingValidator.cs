using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using Rubik.BIZ;
using Rubik.DTO;

namespace Rubik.Validators
{
    public class ReceivingValidator
    {
        /// <summary>
        /// Check empty and not in current period.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public ErrorItem CheckReceiveDate(NZDateTime date)
        {
            if (date.IsNull)
            {
                return new ErrorItem(date.Owner, TKPMessages.eValidate.VLM0041.ToString());
            }

            // Check in using period.
            InventoryPeriodBIZ inventoryPeriodBIZ = new InventoryPeriodBIZ();
            InventoryPeriodDTO inventoryPeriodDTO = inventoryPeriodBIZ.LoadCurrentPeriod();

            InventoryPeriodValidator inventoryPeriodValidator = new InventoryPeriodValidator();
            // fix by tar
            // AddMonths(1) to period end date
            if (date.StrongValue.Date < inventoryPeriodDTO.PERIOD_BEGIN_DATE.StrongValue.Date ||
                date.StrongValue.Date > inventoryPeriodDTO.PERIOD_END_DATE.StrongValue.AddMonths(1).Date)
            {
                return new ErrorItem(date.Owner, TKPMessages.eValidate.VLM0042.ToString());
            }

            return null;
        }

        ///// <summary>
        ///// Check that Item has need lot no?
        ///// </summary>
        ///// <param name="itemCode"></param>
        ///// <param name="lotNo"></param>
        ///// <returns></returns>
        //public ErrorItem CheckInputLot(NZString itemCode, NZString lotNo)
        //{
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

        public ErrorItem CheckExistReceiveItem(NZString itemCode, NZString lotNo, NZString locCode)
        {
            TransactionValidator val = new TransactionValidator();
            return val.CheckExistReceiveItem(itemCode, lotNo, locCode);

        }

        public ErrorItem CheckNotExistReceiveItem(NZString itemCode, NZString lotNo, NZString locCode)
        {
            TransactionValidator val = new TransactionValidator();
            return val.CheckNotExistReceiveItem(itemCode, lotNo, locCode);

        }
        #region Business Validate

        public void ValidateBeforeSaveAdd(InventoryTransactionDTO data)
        {
            //Validate Item Code
            ItemValidator itemValidator = new ItemValidator();
            ValidateException.ThrowErrorItem(itemValidator.CheckEmptyItemCode(data.ITEM_CD));

            BusinessException itemNotFound = itemValidator.CheckItemNotExist(data.ITEM_CD);
            if (itemNotFound != null)
            {
                ValidateException.ThrowErrorItem(itemNotFound.Error);
            }
            if (data.TRANS_ID.IsNull)
            {
                if (data.TRANS_CLS.StrongValue == DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Receiving))
                {
                    ValidateException.ThrowErrorItem(CheckExistReceiveItem(data.ITEM_CD, data.LOT_NO, data.LOC_CD));
                }
                else
                {
                    ValidateException.ThrowErrorItem(CheckNotExistReceiveItem(data.ITEM_CD, data.LOT_NO, data.LOC_CD));
                }


                ////ถ้า Receive ต้อง check ว่า lot นั้นไม่เคยทำ receive มาก่อน
                //if (model.RECEIVE_TYPE.StrongValue.Equals(DataDefine.eTRANS_TYPE_string.Receiving))
                //{
                //    ValidateException.ThrowErrorItem(receivingValidator.CheckExistReceiveItem(dto.ITEM_CD, dto.LOT_NO));
                //}
                //else
                //{
                //    ValidateException.ThrowErrorItem(receivingValidator.CheckNotExistReceiveItem(dto.ITEM_CD, dto.LOT_NO));
                //}


            }


            //Validate Receive Qty
            if (data.QTY.IsNull || data.QTY.StrongValue <= 0)
            {
                ValidateException.ThrowErrorItem(new ErrorItem(data.QTY.Owner, TKPMessages.eValidate.VLM0043.ToString()));
            }
        }
        #endregion


        public ErrorItem CheckForSupplierType(NZString SupplierCode)
        {
            //ErrorItem err = null;

            // if Receive Type is Receive Return then check nothing.
            //if (ReceiveType.StrongValue == DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Receive_Return))
            //{
            //    return null;
            //}

            //// load for item process type
            //ItemBIZ bizItem = new ItemBIZ ();
            //ItemProcessDTO dtoItem = bizItem.LoadItemProcess(ItemCD);
            //if (dtoItem.ORDER_PROCESS_CLS.StrongValue == DataDefine.ORDER_PROCESS_CLS_SUBCONTACT)
            //{
            if (SupplierCode.IsNull || SupplierCode.StrongValue.ToString().Trim() == string.Empty)
            {
                return new ErrorItem(null, TKPMessages.eValidate.VLM0082.ToString());
            }
            // }

            return null;
        }
    }
}
