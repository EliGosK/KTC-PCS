using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using Rubik.BIZ;
using Rubik.DTO;

namespace Rubik.Validators
{
    public class ShipEntryValidator

    {  
        #region Mandatory Check
        public ErrorItem CheckEmptyItemCode(NZString ItemCode)
        {
            if (ItemCode.IsNull)
                return new ErrorItem(ItemCode.Owner, TKPMessages.eValidate.VLM0006.ToString());

            return null;
        }

        public ErrorItem CheckEmptyLocCD(NZString LocCD)
        {
            if (LocCD.IsNull)
                return new ErrorItem(LocCD.Owner, TKPMessages.eValidate.VLM0001.ToString());

            return null;
        }

      

      
        public ErrorItem CheckShipQTY(NZString ItemCD, NZString LocCD, NZString LotNo, NZDecimal ShipQTY)
        {
            if (ShipQTY.IsNull || ShipQTY.StrongValue == 0)
                return new ErrorItem(ShipQTY.Owner, TKPMessages.eValidate.VLM0039.ToString());

            InventoryBIZ biz = new InventoryBIZ();
            ActualOnhandViewDTO dto = biz.LoadActualInventoryOnHand(ItemCD, LocCD, LotNo);


            if (dto == null || dto.ONHAND_QTY.IsNull || dto.ONHAND_QTY.StrongValue == 0)
                return new ErrorItem(null, TKPMessages.eValidate.VLM0029.ToString());

            if (ShipQTY.StrongValue > dto.ONHAND_QTY.StrongValue)
            {
                return new ErrorItem(ShipQTY.Owner, TKPMessages.eValidate.VLM0040.ToString());
            }
            return null;
        }

        public ErrorItem CheckOnhandQty(NZString YearMonth, NZString ItemCD, NZString FromLoc, NZString LotNo)
        {
            InventoryBIZ bizInv = new InventoryBIZ();
            InventoryPeriodDTO dtoPeriod = new InventoryPeriodBIZ().LoadByPK(YearMonth);
            ActualOnhandViewDTO dtoOnhand = bizInv.LoadActualInventoryOnHand(ItemCD, FromLoc, LotNo);
            if (dtoOnhand == null)
                return new ErrorItem(YearMonth.Owner, TKPMessages.eValidate.VLM0029.ToString());
            if (dtoOnhand.ONHAND_QTY.IsNull || dtoOnhand.ONHAND_QTY.StrongValue == 0)
                return new ErrorItem(YearMonth.Owner, TKPMessages.eValidate.VLM0029.ToString());

            return null;
        }

        //public ErrorItem CheckShipDate(NZDateTime ShipDate)
        //{
        //    if (ShipDate.IsNull)
        //        return new ErrorItem(ShipDate.Owner, TKPMessages.eValidate.VLM0031.ToString());

        //    InventoryPeriodBIZ biz = new InventoryPeriodBIZ();
        //    NZString YearMonth = new NZString(ShipDate.Owner, ShipDate.StrongValue.ToString("yyyyMM"));
        //    InventoryPeriodDTO dto = biz.LoadByPK(YearMonth);
        //    if (dto == null)
        //        return new ErrorItem(ShipDate.Owner, TKPMessages.eValidate.VLM0032.ToString());
        //    if (dto.PERIOD_BEGIN_DATE.StrongValue > ShipDate.StrongValue
        //        || dto.PERIOD_END_DATE.StrongValue < ShipDate.StrongValue)
        //        return new ErrorItem(ShipDate.Owner, TKPMessages.eValidate.VLM0032.ToString());
        //    return null;
        //}
        #endregion

        public void ValidateBeforeSaveNew(InventoryTransactionDTO dto, NZDecimal OnhandQty)
        {
            ValidateException validateException = new ValidateException();
            ErrorItem errorItem = null;

            #region mandatory check
            errorItem = CheckEmptyItemCode(dto.ITEM_CD);
            if (errorItem != null)
                validateException.AddError(errorItem);

            errorItem = CheckShipQTY(dto.ITEM_CD, dto.LOC_CD, dto.LOT_NO, dto.QTY);
            if (errorItem != null)
                validateException.AddError(errorItem);

            errorItem = CheckShipDate(dto.TRANS_DATE);
            if (errorItem != null)
                validateException.AddError(errorItem);

            validateException.ThrowIfHasError();
            #endregion

        }

        public ErrorItem CheckShipDate(NZDateTime date)
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
