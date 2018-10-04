using Rubik.UIDataModel;
using EVOFramework;
using Rubik.BIZ;
using Rubik.DTO;
using Rubik.Validators;
using SystemMaintenance.SQLServer.DAO;
using SystemMaintenance.DTO;
using System;
using SystemMaintenance.BIZ;

namespace Rubik.Controller
{
    internal class AdjustmentEntryController
    {
        #region Mapping
        public AdjustmentEntryUIDM ConvertDTOToUIDM(InventoryTransactionDTO dto)
        {
            AdjustmentEntryUIDM model = new AdjustmentEntryUIDM();
            model.TransactionID = dto.TRANS_ID;
            model.AdjustNo = dto.SLIP_NO;
            model.AdjustDate = dto.TRANS_DATE;
            model.AdjustType = dto.IN_OUT_CLS;
            model.ItemCode = dto.ITEM_CD;

            model.StoredLoc = dto.LOC_CD;
            model.LotNo = dto.LOT_NO;
            model.PackNo = dto.PACK_NO;
            model.FGNo = dto.FG_NO;
            model.ExternalLotNo = dto.EXTERNAL_LOT_NO;
            model.AdjustWeight = dto.WEIGHT;
            model.AdjustQty = dto.QTY;
            model.Remark = dto.REMARK;
            model.ReasonCode = dto.TRAN_SUB_CLS;

            //== Get Item Description.
            ItemBIZ biz = new ItemBIZ();
            ItemDTO itemDTO = biz.LoadItem(dto.ITEM_CD);
            model.ItemDesc = itemDTO.SHORT_NAME;

            //-- Get Customer Name
            DealingBIZ bizCust = new DealingBIZ();
            DealingDTO dtoCust = bizCust.LoadLocation(itemDTO.CUSTOMER_CD);
            model.CustomerName = dtoCust.LOC_DESC;

            //== Get OnHand.
            InventoryBIZ inventoryBIZ = new InventoryBIZ();
            InventoryPeriodBIZ inventoryPeriodBIZ = new InventoryPeriodBIZ();

            InventoryPeriodDTO inventoryPeriodDTO = inventoryPeriodBIZ.LoadCurrentPeriod();
            InventoryOnhandDTO inventoryOnhandDTO = inventoryBIZ.LoadInventoryOnHandByDate(inventoryPeriodDTO.YEAR_MONTH, dto.TRANS_DATE, dto.ITEM_CD, dto.LOC_CD, dto.LOT_NO, dto.PACK_NO);
            if (inventoryOnhandDTO == null)
                model.OnHandQty.Value = 0;
            else
                model.OnHandQty = inventoryOnhandDTO.ON_HAND_QTY;

            return model;
        }

        public InventoryTransactionDTO ConvertUIDMToDTO(AdjustmentEntryUIDM model)
        {
            InventoryTransactionDTO dto = new InventoryTransactionDTO();
            dto.TRANS_ID = model.TransactionID;
            dto.ITEM_CD = model.ItemCode;
            dto.LOC_CD = model.StoredLoc;
            dto.LOT_NO = (model.LotNo.IsNull || model.LotNo.StrongValue.Trim() == string.Empty) ? new NZString() : model.LotNo;
            dto.TRANS_DATE = model.AdjustDate;
            dto.TRANS_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Adjustment);
            dto.IN_OUT_CLS = model.AdjustType;
            dto.QTY = model.AdjustQty;
            dto.WEIGHT = model.AdjustWeight;
            dto.PACK_NO = model.PackNo;
            dto.FG_NO = model.FGNo;
            dto.EXTERNAL_LOT_NO = model.ExternalLotNo;
            dto.SLIP_NO = model.AdjustNo;
            dto.GROUP_TRANS_ID = model.GroupTransID;
            //dto.OBJ_ITEM_CD =
            //dto.REF_NO =
            //dto.REF_SLIP_NO =
            //dto.REF_SLIP_CLS =
            //dto.OTHER_DL_NO =
            dto.REMARK = model.Remark;
            dto.TRAN_SUB_CLS = model.ReasonCode;
            dto.SCREEN_TYPE = DataDefine.ScreenType.AdjustmentEntry.ToNZString();
            dto.EFFECT_STOCK = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.In).ToString().Equals(model.AdjustType.StrongValue) ? new NZInt(null, (int)DataDefine.eEFFECT_STOCK.In) : new NZInt(null, (int)DataDefine.eEFFECT_STOCK.Out);
            dto.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dto.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
            dto.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dto.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
            dto.OLD_DATA = new NZInt(null, 0);
            return dto;
        }
        #endregion

        #region Load
        public NZDecimal GetOnhandQty(NZDateTime adjustDate, NZString itemCode, NZString locationCode, NZString lotNo)
        {
            InventoryBIZ biz = new InventoryBIZ();
            if (itemCode.IsNull || locationCode.IsNull)
                return (NZDecimal)0;

            ActualOnhandViewDTO dto = biz.LoadActualInventoryOnHand(itemCode, locationCode, lotNo);
            if (dto == null)
                return (NZDecimal)0;

            return dto.ONHAND_QTY;
        }

        public AdjustmentEntryUIDM LoadData(NZString transactionID)
        {
            InventoryTransBIZ dao = new InventoryTransBIZ();
            InventoryTransactionDTO dto = dao.LoadByTransactionID(transactionID);

            if (dto == null)
                return new AdjustmentEntryUIDM();

            return ConvertDTOToUIDM(dto);
        }
        #endregion

        #region Save
        /// <summary>
        /// Save new data.
        /// </summary>
        /// <param name="model"></param>
        public void SaveAdd(AdjustmentEntryUIDM model)
        {
            try
            {
                CommonLib.Common.CurrentDatabase.KeepConnection = true;
                CommonLib.Common.CurrentDatabase.BeginTransaction(System.Data.IsolationLevel.Serializable);

                AdjustmentValidator adjustmentValidator = new AdjustmentValidator();
                ItemValidator itemValidator = new ItemValidator();
                DealingValidator locationValidator = new DealingValidator();
                TransactionValidator valTran = new TransactionValidator();
                CommonBizValidator commonVal = new CommonBizValidator();

                //ValidateException.ThrowErrorItem(adjustmentValidator.CheckEmptyAdjustDate(model.AdjustDate));
                //ValidateException.ThrowErrorItem(adjustmentValidator.CheckEmptyReasonCode(model.ReasonCode));
                //ValidateException.ThrowErrorItem(valTran.DateIsInCurrentPeriod(model.AdjustDate));
                //ValidateException.ThrowErrorItem(itemValidator.CheckEmptyItemCode(model.ItemCode));

                BusinessException businessException = itemValidator.CheckItemNotExist(model.ItemCode);
                if (businessException != null)
                    ValidateException.ThrowErrorItem(businessException.Error);

                //ValidateException.ThrowErrorItem(locationValidator.CheckEmptyLocationCode(model.StoredLoc));
                ValidateException.ThrowErrorItem(locationValidator.CheckNotExistsLocationCode(model.StoredLoc));
                ValidateException.ThrowErrorItem(commonVal.CheckInputLot(model.ItemCode, new NZString(), model.LotNo, false));

                //ValidateException.ThrowErrorItem(adjustmentValidator.CheckEmptyAdjustQty(model.AdjustQty));
                //ValidateException.ThrowErrorItem(adjustmentValidator.CheckIsZeroAdjustQty(model.AdjustQty));

                #region Lock Running Number gen.

                TransactionLockDAO daoTrans = new TransactionLockDAO(CommonLib.Common.CurrentDatabase);
                TransactionLockDTO dtoTrans = new TransactionLockDTO();
                NZString key1 = new NZString(null, "ADJUST_NO");
                NZString key2 = new NZString(null, "INV_TRANS_TR");
                if (!daoTrans.Exist(null, key1, key2))
                {
                    dtoTrans.KEY1 = key1;
                    dtoTrans.KEY2 = key2;
                    dtoTrans.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                    dtoTrans.CRT_DATE.Value = DateTime.Now;
                    dtoTrans.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                    daoTrans.AddNew(null, dtoTrans);
                }

                // lock transaction
                daoTrans.SelectWithKeys(null, key1, key2);
                // end of lock transaction

                #endregion

                RunningNumberBIZ bizRunning = new RunningNumberBIZ();
                NZString SlipNo = bizRunning.GetCompleteRunningNo(new NZString(null, "ADJUST_NO"), new NZString(null, "TB_INV_TRANS_TR"));
                model.AdjustNo = SlipNo;

                NZString GroupTransID = bizRunning.GetCompleteRunningNo(new NZString(null, "TRAN_GROUP_ID"), new NZString(null, "TB_INV_TRANS_TR"));
                model.GroupTransID = GroupTransID;

                #region Generate pack_no if it is empty

                DealingConstraintBIZ bizConstraint = new DealingConstraintBIZ();

                string strProcess = model.StoredLoc.StrongValue;
                DealingConstraintDTO constriant = bizConstraint.LoadDealingConstraint(strProcess.ToNZString());
                if (constriant != null && constriant.ENABLE_PACK_FLAG.StrongValue == 1 && model.PackNo.IsNull) 
                {
                    NZString PackNo = bizRunning.GetCompleteRunningNo(new NZString(null, "PACK_NO_AUTO_GEN"), new NZString(null, "TB_INV_TRANS_TR"));
                    model.PackNo = PackNo;
                }

                #endregion

                InventoryBIZ inventoryBIZ = new InventoryBIZ();

                InventoryTransactionDTO dto = ConvertUIDMToDTO(model);
                inventoryBIZ.AddInventoryTransaction(CommonLib.Common.CurrentDatabase, dto, true);

                CommonLib.Common.CurrentDatabase.Commit();
            }
            catch (System.Exception)
            {
                CommonLib.Common.CurrentDatabase.Rollback();
                throw;
            }
        }

        /// <summary>
        /// Update old data.
        /// </summary>
        /// <param name="oldTransactionID"></param>
        /// <param name="newDataModel"></param>
        public void SaveEdit(NZString oldTransactionID, AdjustmentEntryUIDM newDataModel)
        {
            try
            {
                CommonLib.Common.CurrentDatabase.KeepConnection = true;
                CommonLib.Common.CurrentDatabase.BeginTransaction(System.Data.IsolationLevel.Serializable);


                ValidateException validateException = new ValidateException();
                AdjustmentValidator adjustmentValidator = new AdjustmentValidator();
                TransactionValidator valTran = new TransactionValidator();
                ItemValidator itemValidator = new ItemValidator();
                DealingValidator locationValidator = new DealingValidator();

                //validateException.AddError(adjustmentValidator.CheckEmptyAdjustDate(newDataModel.AdjustDate));
                //validateException.AddError(adjustmentValidator.CheckEmptyReasonCode(newDataModel.ReasonCode));
                //validateException.AddError(valTran.DateIsInCurrentPeriod(newDataModel.AdjustDate));
                //validateException.AddError(itemValidator.CheckEmptyItemCode(newDataModel.ItemCode));

                BusinessException businessException = itemValidator.CheckItemNotExist(newDataModel.ItemCode);
                if (businessException != null)
                    validateException.AddError(businessException.Error);

                //validateException.AddError(locationValidator.CheckEmptyLocationCode(newDataModel.StoredLoc));
                validateException.AddError(locationValidator.CheckNotExistsLocationCode(newDataModel.StoredLoc));
                //validateException.AddError(adjustmentValidator.CheckEmptyAdjustQty(newDataModel.AdjustQty));
                //validateException.AddError(adjustmentValidator.CheckIsZeroAdjustQty(newDataModel.AdjustQty));
                validateException.ThrowIfHasError();

                InventoryBIZ inventoryBIZ = new InventoryBIZ();

                InventoryTransactionDTO dto = ConvertUIDMToDTO(newDataModel);
                inventoryBIZ.UpdateInventoryTransaction(CommonLib.Common.CurrentDatabase, oldTransactionID, dto);
                CommonLib.Common.CurrentDatabase.Commit();
            }
            catch (System.Exception)
            {
                CommonLib.Common.CurrentDatabase.Rollback();
                throw;
            }
        }
        #endregion
    }
}
