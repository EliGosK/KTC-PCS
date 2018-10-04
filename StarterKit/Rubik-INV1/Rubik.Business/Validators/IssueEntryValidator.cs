using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using Rubik.DTO;
using Rubik.BIZ;

namespace Rubik.Validators
{
    public class IssueEntryValidator
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

        public ErrorItem CheckEmptyLocFrom(NZString LocCD)
        {
            if (LocCD.IsNull)
                return new ErrorItem(LocCD.Owner, TKPMessages.eValidate.VLM0025.ToString());

            return null;
        }

        public ErrorItem CheckEmptySubType(NZString SubType)
        {
            if (SubType.IsNull)
                return new ErrorItem(SubType.Owner, TKPMessages.eValidate.VLM0080.ToString());

            return null;
        }

        public ErrorItem CheckEmptyLocTo(NZString LocCD)
        {
            if (LocCD.IsNull)
                return new ErrorItem(LocCD.Owner, TKPMessages.eValidate.VLM0026.ToString());

            return null;
        }

        public ErrorItem CheckFromToLocation(NZString FromLocCD, NZString ToLocCD)
        {
            if (FromLocCD.StrongValue == ToLocCD.StrongValue)
                return new ErrorItem(ToLocCD.Owner, TKPMessages.eValidate.VLM0030.ToString());

            return null;
        }

        public ErrorItem CheckIssueQTY(NZDecimal IssueQTY)
        {
            if (IssueQTY.IsNull || IssueQTY.StrongValue == 0)
                return new ErrorItem(IssueQTY.Owner, TKPMessages.eValidate.VLM0027.ToString());
            //if (OnhandQTY.IsNull || OnhandQTY.StrongValue == 0)
            //    return new ErrorItem(OnhandQTY.Owner, TKPMessages.eValidate.VLM0029.ToString());


            return null;
        }

        public ErrorItem CheckIssueDate(NZDateTime IssueDate)
        {
            if (IssueDate.IsNull)
                return new ErrorItem(IssueDate.Owner, TKPMessages.eValidate.VLM0031.ToString());

            InventoryPeriodBIZ biz = new InventoryPeriodBIZ();
            //NZString YearMonth = new NZString(IssueDate.Owner, IssueDate.StrongValue.ToString("yyyyMM"));
            InventoryPeriodDTO dto = biz.LoadCurrentPeriod();
            if (dto == null)
                return new ErrorItem(IssueDate.Owner, TKPMessages.eValidate.VLM0032.ToString());

            // edit by tar
            // AddMonths(1) to period end date
            if (dto.PERIOD_BEGIN_DATE.StrongValue.Date > IssueDate.StrongValue.Date
                || dto.PERIOD_END_DATE.StrongValue.AddMonths(1).Date < IssueDate.StrongValue.Date)
                return new ErrorItem(IssueDate.Owner, TKPMessages.eValidate.VLM0032.ToString());
            return null;
        }

        //public ErrorItem CheckLotNo(NZString ItemCD, NZString FromLoc, NZString LotNo) {
        //    ItemBIZ biz = new ItemBIZ();
        //    ItemDTO dto = biz.LoadItem(ItemCD);

        //    switch (DataDefine.ConvertValue2Enum<DataDefine.eLOT_CONTROL_CLS>(dto.LOT_CONTROL_CLS.StrongValue)) {
        //        case DataDefine.eLOT_CONTROL_CLS.No:
        //            if (!LotNo.IsNull || LotNo.StrongValue != string.Empty) {
        //                return new ErrorItem(LotNo.Owner, TKPMessages.eValidate.VLM0065.ToString());
        //            }
        //            break;
        //        case DataDefine.eLOT_CONTROL_CLS.Yes:
        //            if (LotNo.IsNull) {
        //                return new ErrorItem(LotNo.Owner, TKPMessages.eValidate.VLM0050.ToString(), new[] { ItemCD.StrongValue });
        //            }
        //            InventoryBIZ bizInv = new InventoryBIZ();
        //            List<InventoryOnhandDTO> dtolist = new List<InventoryOnhandDTO>();
        //            dtolist = bizInv.LoadLotNoByKey(ItemCD, FromLoc, LotNo);
        //            if (dtolist == null || dtolist.Count == 0) {
        //                return new ErrorItem(LotNo.Owner, TKPMessages.eValidate.VLM0054.ToString(), new[] { LotNo.StrongValue });
        //            }
        //            break;
        //    }

        //    return null;
        //}

        //public ErrorItem CheckOnhandQtyForEditMode(NZDecimal QTY, NZDecimal OnhandQTY, NZString ItemCD, NZString FromLoc)
        //{
        //    if (OnhandQTY.IsNull || OnhandQTY.StrongValue == 0)
        //        return new ErrorItem(QTY.Owner, TKPMessages.eValidate.VLM0029.ToString());

        //    if (QTY.StrongValue > OnhandQTY.StrongValue)
        //    {
        //        return new ErrorItem(QTY.Owner, TKPMessages.eValidate.VLM0063.ToString(), new[] { ItemCD, FromLoc }
        //            );
        //    }
        //    return null;
        //}
        #endregion

        public void ValidateBeforeSaveNew(InventoryTransactionDTO dto, NZDecimal OnhandQty)
        {
            ValidateException validateException = new ValidateException();
            CommonBizValidator commonVal = new CommonBizValidator();
            ErrorItem errorItem = null;

            #region mandatory check
            errorItem = CheckEmptyItemCode(dto.ITEM_CD);
            if (errorItem != null)
                validateException.AddError(errorItem);

            errorItem = CheckEmptyLocFrom(dto.LOC_CD);
            if (errorItem != null)
                validateException.AddError(errorItem);

            errorItem = CheckEmptySubType(dto.TRAN_SUB_CLS);
            if (errorItem != null)
                validateException.AddError(errorItem);

            errorItem = CheckIssueQTY(dto.QTY);
            if (errorItem != null)
                validateException.AddError(errorItem);

            errorItem = CheckIssueDate(dto.TRANS_DATE);
            if (errorItem != null)
                validateException.AddError(errorItem);

            errorItem = commonVal.CheckInputLot(dto.ITEM_CD, dto.LOC_CD, dto.LOT_NO, true);
            if (errorItem != null)
                validateException.AddError(errorItem);
            validateException.ThrowIfHasError();
            #endregion

        }




        public ErrorItem CheckIssueMonth(NZDateTime IssueDate)
        {
            if (IssueDate.IsNull)
                return new ErrorItem(IssueDate.Owner, TKPMessages.eValidate.VLM0031.ToString());

            InventoryPeriodBIZ biz = new InventoryPeriodBIZ();
            //NZString YearMonth = new NZString(IssueDate.Owner, IssueDate.StrongValue.ToString("yyyyMM"));
            InventoryPeriodDTO dto = biz.LoadCurrentPeriod();// (YearMonth);
            if (dto == null)
                return new ErrorItem(IssueDate.Owner, TKPMessages.eValidate.VLM0032.ToString());
            if (dto.PERIOD_BEGIN_DATE.StrongValue > IssueDate.StrongValue
                || dto.PERIOD_END_DATE.StrongValue.AddMonths(1) < IssueDate.StrongValue)
                return new ErrorItem(IssueDate.Owner, TKPMessages.eValidate.VLM0032.ToString());
            return null;
        }


    }
}
