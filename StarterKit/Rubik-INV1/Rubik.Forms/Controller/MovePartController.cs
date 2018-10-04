using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EVOFramework;
using Rubik.BIZ;
using Rubik.UIDataModel;
using Rubik.DTO;
using Rubik.Validators;

namespace Rubik.Controller {
    public class MovePartController 
    {
        internal DataTable LoadMovePartList(NZDateTime DateBegin, NZDateTime DateEnd) 
        {
            MovePartBIZ biz = new MovePartBIZ();
            return biz.LoadMovePartList(DateBegin, DateEnd, false);
        }

        public ItemProcessDTO LoadDefaultProcessOfItem(NZString ItemCD, NZString ProcessCD) 
        {
            ProcessBIZ biz = new ProcessBIZ();
            return biz.LoadDefaultProcess(ItemCD,ProcessCD);
        }

        internal void SaveNewMovePart(MovePartUIDM model) 
        {
            #region Validate
            ItemValidator itemValidator = new ItemValidator();

            BusinessException businessException = itemValidator.CheckItemNotExist(model.MASTER_NO);
            if (businessException != null)
                ValidateException.ThrowErrorItem(businessException.Error);
            #endregion

            InventoryBIZ bizInv = new InventoryBIZ();
            DealingConstraintBIZ bizConstraint = new DealingConstraintBIZ();

            InventoryTransactionDTO dtoInvTrnsFrom = new InventoryTransactionDTO();
            InventoryTransactionDTO dtoInvTrnsTo = new InventoryTransactionDTO();

            #region From
            dtoInvTrnsFrom.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;			
			dtoInvTrnsFrom.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
			dtoInvTrnsFrom.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;			
			dtoInvTrnsFrom.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
			//dtoInvTrnsListFrom.TRANS_ID = 
			dtoInvTrnsFrom.ITEM_CD = model.MASTER_NO;
			dtoInvTrnsFrom.LOC_CD = model.FROM_PROCESS;
			//dtoInvTrnsFrom.LOT_NO = model.LOT_NO;
			//dtoInvTrnsListFrom.PACK_NO = string.Empty;
			dtoInvTrnsFrom.TRANS_DATE = model.MOVE_DATE;
			dtoInvTrnsFrom.TRANS_CLS = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.MovePart).ToNZString();
			dtoInvTrnsFrom.IN_OUT_CLS = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.Out).ToNZString();
			dtoInvTrnsFrom.QTY = model.MOVE_QTY;
			//dtoInvTrnsListFrom.OBJ_ITEM_CD = 
			//dtoInvTrnsListFrom.OBJ_ORDER_QTY = 
			//dtoInvTrnsListFrom.REF_NO = 
			//dtoInvTrnsListFrom.REF_SLIP_NO = 
			//dtoInvTrnsListFrom.REF_SLIP_CLS = 
			//dtoInvTrnsListFrom.OTHER_DL_NO = 
			//dtoInvTrnsListFrom.SLIP_NO = 
			dtoInvTrnsFrom.REMARK = model.REMARK;
			//dtoInvTrnsListFrom.DEALING_NO = 
			//dtoInvTrnsListFrom.EXTERNAL_LOT_NO = 
			//dtoInvTrnsListFrom.PRICE = 
			//dtoInvTrnsListFrom.FOR_CUSTOMER = 
			//dtoInvTrnsListFrom.FOR_MACHINE = 
			dtoInvTrnsFrom.SHIFT_CLS = model.SHIFT_CLS;
			//dtoInvTrnsListFrom.REF_SLIP_NO2 = 
			//dtoInvTrnsListFrom.NG_QTY = 
			dtoInvTrnsFrom.TRAN_SUB_CLS = model.REASON;
			dtoInvTrnsFrom.SCREEN_TYPE = DataDefine.ScreenType.MovePartEntry.ToNZString();
			//dtoInvTrnsListFrom.GROUP_TRANS_ID = 
			//dtoInvTrnsListFrom.RESERVE_QTY = 
			//dtoInvTrnsListFrom.NG_REASON = 
			dtoInvTrnsFrom.EFFECT_STOCK = new NZInt(null,(int)DataDefine.eEFFECT_STOCK.Out);
            dtoInvTrnsFrom.LOT_REMARK = model.LOT_NO;
            dtoInvTrnsFrom.OLD_DATA = new NZInt(null, 0);
            dtoInvTrnsFrom.WEIGHT = model.WEIGHT;

            #endregion

            #region To

            dtoInvTrnsTo.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dtoInvTrnsTo.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
            dtoInvTrnsTo.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dtoInvTrnsTo.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
            //dtoInvTrnsListFrom.TRANS_ID = 
            dtoInvTrnsTo.ITEM_CD = model.MASTER_NO;
            dtoInvTrnsTo.LOC_CD = model.TO_PROCESS;
            //dtoInvTrnsTo.LOT_NO = model.LOT_NO;
            //dtoInvTrnsListFrom.PACK_NO = string.Empty;
            dtoInvTrnsTo.TRANS_DATE = model.MOVE_DATE;
            dtoInvTrnsTo.TRANS_CLS = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.MovePart).ToNZString();
            dtoInvTrnsTo.IN_OUT_CLS = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.In).ToNZString();
            dtoInvTrnsTo.QTY = model.MOVE_QTY;
            //dtoInvTrnsListFrom.OBJ_ITEM_CD = 
            //dtoInvTrnsListFrom.OBJ_ORDER_QTY = 
            //dtoInvTrnsListFrom.REF_NO = 
            //dtoInvTrnsListFrom.REF_SLIP_NO = 
            //dtoInvTrnsListFrom.REF_SLIP_CLS = 
            //dtoInvTrnsListFrom.OTHER_DL_NO = 
            //dtoInvTrnsListFrom.SLIP_NO = 
            dtoInvTrnsTo.REMARK = model.REMARK;
            //dtoInvTrnsListFrom.DEALING_NO = 
            //dtoInvTrnsListFrom.EXTERNAL_LOT_NO = 
            //dtoInvTrnsListFrom.PRICE = 
            //dtoInvTrnsListFrom.FOR_CUSTOMER = 
            //dtoInvTrnsListFrom.FOR_MACHINE = 
            dtoInvTrnsTo.SHIFT_CLS = model.SHIFT_CLS;
            //dtoInvTrnsListFrom.REF_SLIP_NO2 = 
            //dtoInvTrnsListFrom.NG_QTY = 
            dtoInvTrnsTo.TRAN_SUB_CLS = model.REASON;
            dtoInvTrnsTo.SCREEN_TYPE = DataDefine.ScreenType.MovePartEntry.ToNZString();
            //dtoInvTrnsListFrom.GROUP_TRANS_ID = 
            //dtoInvTrnsListFrom.RESERVE_QTY = 
            //dtoInvTrnsListFrom.NG_REASON = 
            dtoInvTrnsTo.EFFECT_STOCK = new NZInt(null, (int)DataDefine.eEFFECT_STOCK.In);
            dtoInvTrnsTo.LOT_REMARK = model.LOT_NO;
            dtoInvTrnsTo.OLD_DATA = new NZInt(null, 0);
            dtoInvTrnsTo.WEIGHT = model.WEIGHT;

            #endregion

            #region Consumption

            List<InventoryTransactionDTO> listComponent = new List<InventoryTransactionDTO>();
            DealingConstraintDTO dtoConstraint = bizConstraint.LoadDealingConstraint(model.FROM_PROCESS);
            if (dtoConstraint != null && dtoConstraint.COMPONENT_ITEM_USAGE.StrongValue == 1) 
            {
                //get component usage
                BOMBIZ bizBOM = new BOMBIZ();
                List<ComponentUsageDTO> components = bizBOM.LoadComponentUsage(model.MASTER_NO, model.MOVE_QTY);
                if (components != null) 
                {
                    foreach (ComponentUsageDTO component in components) 
                    {
                        InventoryTransactionDTO dtoComponent = new InventoryTransactionDTO();
                        dtoComponent.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                        dtoComponent.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                        dtoComponent.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                        dtoComponent.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                        //dtoComponent.TRANS_ID = 
                        dtoComponent.ITEM_CD = component.LOWER_ITEM_CD;
                        dtoComponent.LOC_CD = model.FROM_PROCESS;
                        //dtoComponent.LOT_NO = model.LOT_NO;
                        //dtoComponent.PACK_NO = string.Empty;
                        dtoComponent.TRANS_DATE = model.MOVE_DATE;
                        dtoComponent.TRANS_CLS = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.MoveConsumption).ToNZString();
                        dtoComponent.IN_OUT_CLS = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.Out).ToNZString();
                        dtoComponent.QTY = component.USAGE_QTY;
                        //dtoComponent.OBJ_ITEM_CD = 
                        //dtoComponent.OBJ_ORDER_QTY = 
                        //dtoComponent.REF_NO = 
                        //dtoComponent.REF_SLIP_NO = 
                        //dtoComponent.REF_SLIP_CLS = 
                        //dtoComponent.OTHER_DL_NO = 
                        //dtoComponent.SLIP_NO = 
                        dtoComponent.REMARK = model.REMARK;
                        //dtoComponent.DEALING_NO = 
                        //dtoComponent.EXTERNAL_LOT_NO = 
                        //dtoComponent.PRICE = 
                        //dtoComponent.FOR_CUSTOMER = 
                        //dtoComponent.FOR_MACHINE = 
                        dtoComponent.SHIFT_CLS = model.SHIFT_CLS;
                        //dtoComponent.REF_SLIP_NO2 = 
                        //dtoComponent.NG_QTY = 
                        dtoComponent.TRAN_SUB_CLS = model.REASON;
                        dtoComponent.SCREEN_TYPE = DataDefine.ScreenType.MovePartEntry.ToNZString();
                        //dtoComponent.GROUP_TRANS_ID = 
                        //dtoComponent.RESERVE_QTY = 
                        //dtoComponent.NG_REASON = 
                        dtoComponent.EFFECT_STOCK = new NZInt(null, (int)DataDefine.eEFFECT_STOCK.Out);
                        dtoComponent.LOT_REMARK = model.LOT_NO;
                        dtoComponent.OLD_DATA = new NZInt(null, 0);
                        //dtoComponent.WEIGHT = model.WEIGHT;
                        listComponent.Add(dtoComponent);
                    }
                }

            #endregion
            }

            bizInv.AddMovePart(dtoInvTrnsFrom, dtoInvTrnsTo, listComponent);

        }

        internal void SaveUpdateMovePart(MovePartUIDM model) 
        {
            #region Validate
            ItemValidator itemValidator = new ItemValidator();

            BusinessException businessException = itemValidator.CheckItemNotExist(model.MASTER_NO);
            if (businessException != null)
                ValidateException.ThrowErrorItem(businessException.Error);
            #endregion

            DealingConstraintBIZ bizConstraint = new DealingConstraintBIZ();
            InventoryBIZ bizInv = new InventoryBIZ();
            InventoryTransBIZ bizInvTrans = new InventoryTransBIZ();
            BOMBIZ bizBOM = new BOMBIZ();

            List<InventoryTransactionDTO> InvUpdateList = new List<InventoryTransactionDTO>();
            List<InventoryTransactionDTO> InvNewList = new List<InventoryTransactionDTO>(); 

            //Keep Main Transaction
            InventoryTransactionDTO dtoInvTrnsFrom = bizInvTrans.LoadByTransactionID(model.TRANS_ID_FROM);
            InventoryTransactionDTO dtoInvTrnsTo = bizInvTrans.LoadByTransactionID(model.TRANS_ID_TO);

            #region From
            //InventoryTransactionDTO dtoInvTrnsFrom = new InventoryTransactionDTO();
            dtoInvTrnsFrom.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dtoInvTrnsFrom.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
            //dtoInvTrnsFrom.TRANS_ID = model.TRANS_ID_FROM;
            //dtoInvTrnsFrom.ITEM_CD = model.MASTER_NO;
            //dtoInvTrnsFrom.LOC_CD = model.FROM_PROCESS;
            //dtoInvTrnsFrom.LOT_NO = model.LOT_NO;
            //dtoInvTrnsListFrom.PACK_NO = string.Empty;
            //dtoInvTrnsFrom.TRANS_DATE = model.MOVE_DATE;
            //dtoInvTrnsFrom.TRANS_CLS = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.MovePart).ToNZString();
            //dtoInvTrnsFrom.IN_OUT_CLS = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.Out).ToNZString();
            dtoInvTrnsFrom.QTY = model.MOVE_QTY;
            //dtoInvTrnsFrom.OBJ_ITEM_CD = 
            //dtoInvTrnsFrom.OBJ_ORDER_QTY = 
            //dtoInvTrnsFrom.REF_NO = 
            //dtoInvTrnsFrom.REF_SLIP_NO = 
            //dtoInvTrnsFrom.REF_SLIP_CLS = 
            //dtoInvTrnsFrom.OTHER_DL_NO = 
            //dtoInvTrnsFrom.SLIP_NO = model.MOVE_NO;
            dtoInvTrnsFrom.REMARK = model.REMARK;
            //dtoInvTrnsFrom.DEALING_NO = 
            //dtoInvTrnsFrom.EXTERNAL_LOT_NO = 
            //dtoInvTrnsFrom.PRICE = 
            //dtoInvTrnsFrom.FOR_CUSTOMER = 
            //dtoInvTrnsFrom.FOR_MACHINE = 
            dtoInvTrnsFrom.SHIFT_CLS = model.SHIFT_CLS;
            //dtoInvTrnsFrom.REF_SLIP_NO2 = 
            //dtoInvTrnsFrom.NG_QTY = 
            dtoInvTrnsFrom.TRAN_SUB_CLS = model.REASON;
            dtoInvTrnsFrom.SCREEN_TYPE = DataDefine.ScreenType.MovePartEntry.ToNZString();
            //dtoInvTrnsFrom.GROUP_TRANS_ID = model.TRANS_ID_FROM;
            //dtoInvTrnsFrom.RESERVE_QTY = 
            //dtoInvTrnsFrom.NG_REASON = 
            //dtoInvTrnsFrom.EFFECT_STOCK = new NZInt(null, (int)DataDefine.eEFFECT_STOCK.Out);
            dtoInvTrnsFrom.LOT_REMARK = model.LOT_NO;
            dtoInvTrnsFrom.OLD_DATA = new NZInt(null, 0);
            dtoInvTrnsFrom.WEIGHT = model.WEIGHT;

            InvUpdateList.Add(dtoInvTrnsFrom);

            #endregion

            #region To

            //InventoryTransactionDTO dtoInvTrnsTo = new InventoryTransactionDTO();
            dtoInvTrnsTo.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dtoInvTrnsTo.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
            //dtoInvTrnsTo.TRANS_ID = model.TRANS_ID_TO;
            //dtoInvTrnsTo.ITEM_CD = model.MASTER_NO;
            //dtoInvTrnsTo.LOC_CD = model.TO_PROCESS;
            //dtoInvTrnsTo.LOT_NO = model.LOT_NO;
            //dtoInvTrnsListFrom.PACK_NO = string.Empty;
            //dtoInvTrnsTo.TRANS_DATE = model.MOVE_DATE;
            //dtoInvTrnsTo.TRANS_CLS = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.MovePart).ToNZString();
            //dtoInvTrnsTo.IN_OUT_CLS = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.In).ToNZString();
            dtoInvTrnsTo.QTY = model.MOVE_QTY;
            //dtoInvTrnsTo.OBJ_ITEM_CD = 
            //dtoInvTrnsTo.OBJ_ORDER_QTY = 
            //dtoInvTrnsTo.REF_NO = 
            //dtoInvTrnsTo.REF_SLIP_NO = model.MOVE_NO;
            //dtoInvTrnsTo.REF_SLIP_CLS = 
            //dtoInvTrnsTo.OTHER_DL_NO = 
            //dtoInvTrnsTo.SLIP_NO = 
            dtoInvTrnsTo.REMARK = model.REMARK;
            //dtoInvTrnsTo.DEALING_NO = 
            //dtoInvTrnsTo.EXTERNAL_LOT_NO = 
            //dtoInvTrnsTo.PRICE = 
            //dtoInvTrnsTo.FOR_CUSTOMER = 
            //dtoInvTrnsTo.FOR_MACHINE = 
            dtoInvTrnsTo.SHIFT_CLS = model.SHIFT_CLS;
            //dtoInvTrnsTo.REF_SLIP_NO2 = 
            //dtoInvTrnsTo.NG_QTY = 
            dtoInvTrnsTo.TRAN_SUB_CLS = model.REASON;
            dtoInvTrnsTo.SCREEN_TYPE = DataDefine.ScreenType.MovePartEntry.ToNZString();
            //dtoInvTrnsTo.GROUP_TRANS_ID = model.TRANS_ID_TO;
            //dtoInvTrnsTo.RESERVE_QTY = 
            //dtoInvTrnsTo.NG_REASON = 
            //dtoInvTrnsTo.EFFECT_STOCK = new NZInt(null, (int)DataDefine.eEFFECT_STOCK.In);
            dtoInvTrnsTo.LOT_REMARK = model.LOT_NO;
            dtoInvTrnsTo.OLD_DATA = new NZInt(null, 0);
            dtoInvTrnsTo.WEIGHT = model.WEIGHT;

            InvUpdateList.Add(dtoInvTrnsTo);

            #endregion
            
            #region Consumtion

            DealingConstraintDTO dtoConstraint = bizConstraint.LoadDealingConstraint(model.FROM_PROCESS);
            if (dtoConstraint != null && dtoConstraint.COMPONENT_ITEM_USAGE.StrongValue == 1) 
            {                                
                List<ComponentUsageDTO> components = bizBOM.LoadComponentUsage(model.MASTER_NO, model.MOVE_QTY);
                if (components != null) 
                {
                    foreach (ComponentUsageDTO component in components) 
                    {
                        InventoryTransactionDTO dtoComponent = bizInvTrans.LoadConsumptionTransaction(DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.MoveConsumption).ToNZString(),
                                                                                                model.TRANS_ID_FROM,
                                                                                                component.LOWER_ITEM_CD);
                        if (dtoComponent != null) 
                        {
                            dtoComponent.QTY = component.USAGE_QTY;
                            InvUpdateList.Add(dtoComponent);
                        }
                        else 
                        {
                            //------ new component -----------------//

                            dtoComponent = new InventoryTransactionDTO();
                            dtoComponent.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                            dtoComponent.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                            dtoComponent.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                            dtoComponent.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                            //dtoComponent.TRANS_ID = 
                            dtoComponent.ITEM_CD = component.LOWER_ITEM_CD;
                            dtoComponent.LOC_CD = dtoInvTrnsFrom.LOC_CD;
                            //dtoComponent.LOT_NO = model.LOT_NO;
                            //dtoComponent.PACK_NO = string.Empty;
                            dtoComponent.TRANS_DATE = dtoInvTrnsFrom.TRANS_DATE;
                            dtoComponent.TRANS_CLS = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.MoveConsumption).ToNZString();
                            dtoComponent.IN_OUT_CLS = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.Out).ToNZString();
                            dtoComponent.QTY = component.USAGE_QTY;
                            //dtoComponent.OBJ_ITEM_CD = 
                            //dtoComponent.OBJ_ORDER_QTY = 
                            dtoComponent.REF_NO = dtoInvTrnsFrom.TRANS_ID;
                            dtoComponent.REF_SLIP_NO = dtoInvTrnsFrom.SLIP_NO;
                            //dtoComponent.REF_SLIP_CLS = 
                            //dtoComponent.OTHER_DL_NO = 
                            //dtoComponent.SLIP_NO = 
                            dtoComponent.REMARK = dtoInvTrnsFrom.REMARK;
                            //dtoComponent.DEALING_NO = 
                            //dtoComponent.EXTERNAL_LOT_NO = 
                            //dtoComponent.PRICE = 
                            //dtoComponent.FOR_CUSTOMER = 
                            //dtoComponent.FOR_MACHINE = 
                            dtoComponent.SHIFT_CLS = dtoInvTrnsFrom.SHIFT_CLS;
                            //dtoComponent.REF_SLIP_NO2 = 
                            //dtoComponent.NG_QTY = 
                            dtoComponent.TRAN_SUB_CLS = dtoInvTrnsFrom.TRAN_SUB_CLS;
                            dtoComponent.SCREEN_TYPE = DataDefine.ScreenType.MovePartEntry.ToNZString();
                            //dtoComponent.GROUP_TRANS_ID = 
                            //dtoComponent.RESERVE_QTY = 
                            //dtoComponent.NG_REASON = 
                            dtoComponent.EFFECT_STOCK = new NZInt(null, (int)DataDefine.eEFFECT_STOCK.Out);
                            dtoComponent.LOT_REMARK = dtoInvTrnsFrom.LOT_REMARK;
                            dtoComponent.OLD_DATA = new NZInt(null, 0);
                            //dtoComponent.WEIGHT = model.WEIGHT;
                            InvNewList.Add(dtoComponent);
                        }
                    }
                }
            }

            #endregion

            bizInv.UpdateMovePart(InvUpdateList, InvNewList);            
        }

        internal void DeleteMovePart(NZString TransIDFrom, NZString TransIDTo) 
        {
            InventoryBIZ bizInv = new InventoryBIZ();
            InventoryTransBIZ bizTrans = new InventoryTransBIZ();

            List<InventoryTransactionDTO> dtoList = new List<InventoryTransactionDTO>();   
            InventoryTransactionDTO dto = bizTrans.LoadByTransactionID(TransIDFrom);

            bizInv.DeleteGroupTransaction(dto.GROUP_TRANS_ID);
            ////From
            //dto = new InventoryTransactionDTO();
            //dto.TRANS_ID = TransIDFrom;
            //dtoList.Add(dto);

            ////To
            //dto = new InventoryTransactionDTO();
            //dto.TRANS_ID = TransIDTo;
            //dtoList.Add(dto);

            //bizInv.DeleteTransactionList(dtoList);
            //bizInv.DeleteInventoryTransactions(CommonLib.Common.CurrentDatabase, dtoList);
        }
    }

}
