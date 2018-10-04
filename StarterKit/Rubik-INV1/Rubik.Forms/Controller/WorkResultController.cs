using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemMaintenance.BIZ;
using EVOFramework;
using Rubik.BIZ;
using Rubik.DTO;
using Rubik.UIDataModel;
using CommonLib;
using Rubik.Validators;
using EVOFramework.Data;
using EVOFramework.Windows.Forms;
using System.Data;
using ClassListBIZ = Rubik.BIZ.ClassListBIZ;
using EVOFramework.Database;

namespace Rubik.Controller
{
    internal class WorkResultController
    {
        #region Create UI Data model
        public WorkResultEntryUIDM CreateUIDMForAddMode()
        {
            WorkResultEntryUIDM model = new WorkResultEntryUIDM();
            model.WorkResultDate.Value = CommonLib.Common.GetDatabaseDateTime();
            model.DataView.AcceptChanges();
            return model;
        }
        #endregion

        #region Mapping
        private InventoryTransactionDTO CreateDTOForWorkResult(WorkResultEntryUIDM model)
        {
            InventoryTransactionDTO dto = new InventoryTransactionDTO();

            //dto.TRANS_ID = model.TransactionID;
            //dto.ITEM_CD = model.ItemCode;
            //dto.LOC_CD = model.StoredLoc;
            //dto.LOT_NO = model.LotNo;
            //dto.TRANS_DATE = model.WorkResultDate;
            //dto.TRANS_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.WorkResult);
            //dto.IN_OUT_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.In);
            //dto.QTY = model.GoodQty;
            //dto.NG_QTY = model.NGQty;
            //dto.RESERVE_QTY = model.ReserveQty;
            //dto.REMARK = model.Remark;
            //dto.REF_SLIP_NO = model.WorkOrderNo;
            //dto.SLIP_NO = model.WorkResultNo;
            ////dto.REF_SLIP_NO2 = model.WorkOrderNo2;
            //dto.REF_SLIP_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eREF_SLIP_CLS.WorkOrder);
            //dto.CRT_BY = Common.CurrentUserInfomation.UserCD;
            //dto.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
            //dto.UPD_BY = Common.CurrentUserInfomation.UserCD;
            //dto.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
            //dto.SHIFT_CLS = model.ShipClass;
            //dto.FOR_MACHINE = model.ForMachine;
            //dto.SCREEN_TYPE = DataDefine.ScreenType.WorkResultEntry.ToNZString();
            //dto.NG_REASON = model.NGReason;
            //dto.TRAN_SUB_CLS = DataDefine.eTRAN_SUB_CLS.WR.ToString().ToNZString();
            return dto;
        }
        private InventoryTransactionDTO CreateDTOForNGResult(WorkResultEntryUIDM model)
        {
            InventoryTransactionDTO dto = new InventoryTransactionDTO();

            //dto.TRANS_ID = model.NGTransactionID;
            //dto.ITEM_CD = model.ItemCode;
            //// FOR NG RESULT GET STORE LOC FROM SYSTEM
            //SysConfigBIZ bizSYS = new SysConfigBIZ();


            //SysConfigDTO dtoSYS = bizSYS.LoadByPK(DataDefine.eSYSTEM_CONFIG.TRN080.SYS_GROUP_ID, (NZString)DataDefine.eSYSTEM_CONFIG.TRN080.SYS_KEY.NG_LOC_CD.ToString());
            //if (dtoSYS == null || dtoSYS.CHAR_DATA.IsNull || dtoSYS.CHAR_DATA.StrongValue == "ORDER_LOC")
            //{
            //    dto.LOC_CD = model.OrderLoc;
            //}
            //else
            //{
            //    dto.LOC_CD = dtoSYS.CHAR_DATA;
            //}
            //dto.LOT_NO = DataDefine.LOT_SCRAP.ToNZString();
            //dto.TRANS_DATE = model.WorkResultDate;
            //dto.TRANS_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.NGWorkResult);
            //dto.IN_OUT_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.In);
            //dto.QTY = model.NGQty;
            //dto.NG_QTY = model.NGQty;
            //dto.REMARK = model.Remark;
            //dto.REF_SLIP_NO = model.WorkOrderNo;
            //dto.SLIP_NO = model.WorkResultNo;
            //dto.REF_SLIP_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eREF_SLIP_CLS.WorkOrder);
            //dto.CRT_BY = Common.CurrentUserInfomation.UserCD;
            //dto.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
            //dto.UPD_BY = Common.CurrentUserInfomation.UserCD;
            //dto.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
            //dto.SHIFT_CLS = model.ShipClass;
            //dto.SCREEN_TYPE = DataDefine.ScreenType.WorkResultEntry.ToNZString();
            return dto;
        }

        private InventoryTransactionDTO CreateDTOForReserveResult(WorkResultEntryUIDM model)
        {
            InventoryTransactionDTO dto = new InventoryTransactionDTO();

            //dto.TRANS_ID = model.ReserveTransactionID;
            //dto.ITEM_CD = model.ItemCode;
            //dto.LOC_CD = model.StoredLoc;
            //dto.LOT_NO.Value = model.LotNo + DataDefine.LOT_RESERVE_POSTFIX;
            //dto.TRANS_DATE = model.WorkResultDate;
            //dto.TRANS_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.ReserveResult);
            //dto.IN_OUT_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.In);
            //dto.QTY = model.ReserveQty;
            //dto.RESERVE_QTY = model.ReserveQty;
            //dto.REMARK = model.Remark;
            //dto.REF_SLIP_NO = model.WorkOrderNo;
            //dto.SLIP_NO = model.WorkResultNo;
            //dto.REF_SLIP_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eREF_SLIP_CLS.WorkOrder);
            //dto.CRT_BY = Common.CurrentUserInfomation.UserCD;
            //dto.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
            //dto.UPD_BY = Common.CurrentUserInfomation.UserCD;
            //dto.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
            //dto.SHIFT_CLS = model.ShipClass;
            //dto.FOR_MACHINE = model.ForMachine;
            //dto.SCREEN_TYPE = DataDefine.ScreenType.WorkResultEntry.ToNZString();
            return dto;
        }

        private InventoryTransactionDTO CreateDTOForConsumption(WorkResultEntryUIDM model, WorkResultEntryViewDTO line)
        {
            InventoryTransactionDTO dto = new InventoryTransactionDTO();

            //dto.TRANS_ID = line.TRANS_ID;
            //dto.ITEM_CD = line.ITEM_CD;
            //dto.LOC_CD = line.LOC_CD;
            //dto.LOT_NO = line.LOT_NO;
            //dto.TRANS_DATE = model.WorkResultDate;
            //dto.TRANS_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Consumption);
            //dto.IN_OUT_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.Out);
            //dto.QTY = line.CONSUMPTION_QTY;
            //dto.OBJ_ITEM_CD = model.ItemCode;
            //dto.OBJ_ORDER_QTY = model.WorkResultQty;
            //dto.REMARK = model.Remark;
            //dto.REF_SLIP_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eREF_SLIP_CLS.WorkResult);
            //dto.CRT_BY = Common.CurrentUserInfomation.UserCD;
            //dto.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
            //dto.UPD_BY = Common.CurrentUserInfomation.UserCD;
            //dto.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
            //dto.SHIFT_CLS = model.ShipClass;
            //dto.SCREEN_TYPE = DataDefine.ScreenType.WorkResultEntry.ToNZString();
            return dto;
        }
        private InventoryTransactionDTO CreateDTOForConsumption(WorkResultEntryUIDM model, ActualOnhandViewDTO line)
        {
            InventoryTransactionDTO dto = new InventoryTransactionDTO();

            ////dto.TRANS_ID = line.TRANS_ID; // TRANS_ID จะได้มาเองตอน add transaction
            //dto.ITEM_CD = line.ITEM_CD;
            //dto.LOC_CD = line.LOC_CD;
            //dto.LOT_NO = line.LOT_NO;
            //dto.TRANS_DATE = model.WorkResultDate;
            //dto.TRANS_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Consumption);
            //dto.IN_OUT_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.Out);
            //dto.QTY = line.ONHAND_QTY;
            //dto.OBJ_ITEM_CD = model.ItemCode;
            //dto.OBJ_ORDER_QTY = model.WorkResultQty;
            //dto.REMARK = model.Remark;
            //dto.REF_SLIP_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eREF_SLIP_CLS.WorkResult);
            //dto.CRT_BY = Common.CurrentUserInfomation.UserCD;
            //dto.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
            //dto.UPD_BY = Common.CurrentUserInfomation.UserCD;
            //dto.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
            //dto.SHIFT_CLS = model.ShipClass;
            //dto.SCREEN_TYPE = DataDefine.ScreenType.WorkResultEntry.ToNZString();
            return dto;
        }

        #endregion

        #region Load Data
        public List<InventoryTransactionViewDTO> LoadWorkResultList(NZDateTime beginPeriod, NZDateTime endPeriod)
        {
            InventoryBIZ biz = new InventoryBIZ();
            return biz.LoadWorkResultList(beginPeriod, endPeriod);
        }
        /// <summary>
        /// Load all child item of parent item code at first level to consumption operation.
        /// </summary>
        /// <param name="parentItemCode"></param>
        /// <param name="orderLocation"></param>
        /// <param name="qty"></param>
        /// <returns></returns>
        public List<WorkResultEntryViewDTO> LoadRequireConsumptionItems(NZString parentItemCode, NZString orderLocation, NZDecimal qty)
        {
            InventoryBIZ biz = new InventoryBIZ();
            return biz.LoadConsumptionListFromItemCode(parentItemCode, orderLocation, qty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionID"></param>
        /// <returns></returns>
        public WorkResultEntryUIDM LoadForEditWorkResult(NZString transactionID)
        {

            //== Load Header (Work Result)
            InventoryTransBIZ bizInventoryTransaction = new InventoryTransBIZ();
            ItemBIZ bizItem = new ItemBIZ();

            InventoryTransactionDTO dtoInventoryTransaction = bizInventoryTransaction.LoadByTransactionID(transactionID);
            if (dtoInventoryTransaction == null)
                return null;

            ItemDTO dtoItem = bizItem.LoadItem(dtoInventoryTransaction.ITEM_CD);
            ItemProcessDTO dtoItemProcess = bizItem.LoadItemProcess(dtoInventoryTransaction.ITEM_CD);
            WorkResultEntryUIDM model = new WorkResultEntryUIDM();

            model.TransactionID = dtoInventoryTransaction.TRANS_ID;
            model.ItemCode = dtoInventoryTransaction.ITEM_CD;
            model.ItemDesc = dtoItem.ITEM_DESC;
            model.LotNo = dtoInventoryTransaction.LOT_NO;
            model.StoredLoc = dtoInventoryTransaction.LOC_CD;
            model.Remark = dtoInventoryTransaction.REMARK;
            model.WorkOrderNo = dtoInventoryTransaction.REF_SLIP_NO;
            model.WorkResultDate = dtoInventoryTransaction.TRANS_DATE;
            model.WorkResultQty.Value = dtoInventoryTransaction.QTY.NVL(0) + dtoInventoryTransaction.NG_QTY.NVL(0) + dtoInventoryTransaction.RESERVE_QTY.NVL(0);
            model.GoodQty.Value = dtoInventoryTransaction.QTY.NVL(0);
            model.WorkResultNo = dtoInventoryTransaction.SLIP_NO;
            model.ShipClass = dtoInventoryTransaction.SHIFT_CLS;
            //model.CONSUMTION_CLS = dtoItemProcess.CONSUMTION_CLS;
            model.ReserveQty = dtoInventoryTransaction.RESERVE_QTY;
            model.NGQty = dtoInventoryTransaction.NG_QTY;
            model.ForMachine = dtoInventoryTransaction.FOR_MACHINE;
            model.NGReason = dtoInventoryTransaction.NG_REASON;
            //model.LotSize = dtoItemProcess.LOT_SIZE;

            //model.OrderLoc = dtoItemProcess.ORDER_LOC_CD;


            InventoryTransactionDTO dtoNGTrans = bizInventoryTransaction.LoadNGWorkResult(model.WorkResultNo);
            if (dtoNGTrans != null && !dtoNGTrans.TRANS_ID.IsNull)
                model.NGTransactionID = dtoNGTrans.TRANS_ID;

            InventoryTransactionDTO dtoReserveTrans = bizInventoryTransaction.LoadReserveResult(model.WorkResultNo);
            if (dtoReserveTrans != null && !dtoReserveTrans.TRANS_ID.IsNull)
                model.ReserveTransactionID = dtoReserveTrans.TRANS_ID;


            InventoryBIZ bizInventory = new InventoryBIZ();
            List<WorkResultEntryViewDTO> dtoList = bizInventory.LoadWorkResultConsumptionList(model.WorkResultNo);

            model.DataView = DTOUtility.ConvertListToDataTable(dtoList);

            model.DataView.AcceptChanges();
            return model;
        }

        #endregion

        #region Save Data
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns>If save data operation completed will return true. Otherwise return false.</returns>
        public bool SaveData(WorkResultEntryUIDM model, DataDefine.eCONSUMPTION_CLS ConsumptionClass)
        {
            ItemBIZ bizItem = new ItemBIZ();
            ClassListBIZ bizClassList = new ClassListBIZ();
            InventoryBIZ biz = new InventoryBIZ();
            IssueEntryValidator valLot = new IssueEntryValidator();
            // Load default over consumption checking.
            ClassListDTO dtoOverConsumptionCheck = bizClassList.LoadByPK((NZString)DataDefine.OVER_CONSUME_CHK, (NZString)DataDefine.Convert2ClassCode(DataDefine.eOVER_CONSUME_CHK.DEFAULT));
            bool bOverConsumeChk = false;
            if (dtoOverConsumptionCheck != null && dtoOverConsumptionCheck.CLS_DESC.NVL(String.Empty) == "1")
                bOverConsumeChk = true;


            //string mode = "UPD";
            //if (model.WorkOrderNo.IsNull)
            //{
            //    mode = "ADD";
            //}

            #region Validate data
            //== Validate Header, contain: ItemCode, Order Location and Qty.
            #region Validate mandatory
            WorkResultEntryValidator workResultEntryValidator = new WorkResultEntryValidator();
            ItemValidator itemValidator = new ItemValidator();
            DealingValidator locationValidator = new DealingValidator();
            CommonBizValidator commonVal = new CommonBizValidator();
            ValidateException.ThrowErrorItem(workResultEntryValidator.CheckWorkResultDate(model.WorkResultDate));
            ValidateException.ThrowErrorItem(itemValidator.CheckEmptyItemCode(model.ItemCode));
            ValidateException.ThrowErrorItem(workResultEntryValidator.CheckEmptyShiftType(model.ShipClass));
            ValidateException.ThrowErrorItem(workResultEntryValidator.CheckDifferentLocationOfItem(model.DataView));

            BusinessException itemFound = itemValidator.CheckItemNotExist(model.ItemCode);
            if (itemFound != null) {
                ValidateException.ThrowErrorItem(itemFound.Error);
            }
            if (ConsumptionClass != DataDefine.eCONSUMPTION_CLS.No) {
                ValidateException.ThrowErrorItem(locationValidator.CheckEmptyLocationCode(model.OrderLoc));
                ValidateException.ThrowErrorItem(locationValidator.CheckNotExistsLocationCode(model.OrderLoc));
            }

            ValidateException.ThrowErrorItem(locationValidator.CheckEmptyLocationCode(model.StoredLoc));
            ValidateException.ThrowErrorItem(locationValidator.CheckNotExistsLocationCode(model.StoredLoc));
            ValidateException.ThrowErrorItem(workResultEntryValidator.CheckWorkResultQty(model.WorkResultQty));
            ValidateException.ThrowErrorItem(workResultEntryValidator.CheckWorkResultGoodQty((NZDecimal)(model.WorkResultQty.StrongValue - model.NGQty.StrongValue)));

            // Check LotNo
            ValidateException.ThrowErrorItem(commonVal.CheckInputLot(model.ItemCode, new NZString(), model.LotNo, false));
            #endregion

            //== Validate Detail list.
            if (ConsumptionClass == DataDefine.eCONSUMPTION_CLS.Manual)
            {
                List<WorkResultEntryViewDTO> listItems = DTOUtility.ConvertDataTableToList<WorkResultEntryViewDTO>(model.DataView);

                #region Validate detail list.
                // Check ItemCD & LotNo
                List<string> listInvalidLotNo = new List<string>();
                List<string> listInvalidConsumptionQty = new List<string>();

                for (int i = 0; i < listItems.Count; i++)
                {
                    BusinessException itemChildNotFound = itemValidator.CheckItemNotExist(listItems[i].ITEM_CD);
                    if (itemChildNotFound != null)
                        ValidateException.ThrowErrorItem(itemChildNotFound.Error);

                    ItemDTO dtoItem = bizItem.LoadItem(listItems[i].ITEM_CD);
                    WorkResultEntryViewDTO line = listItems[i];
                    //line.LOT_CONTROL_CLS = dtoItem.LOT_CONTROL_CLS;

                    if (line.LOT_CONTROL_CLS.StrongValue == DataDefine.Convert2ClassCode(DataDefine.eLOT_CONTROL_CLS.Yes) &&
                        (line.LOT_NO.IsNull || line.LOT_NO.StrongValue.Trim() == string.Empty))
                    {

                        if (listInvalidLotNo.Contains(line.ITEM_CD.StrongValue))
                            continue;
                        listInvalidLotNo.Add(line.ITEM_CD.StrongValue);
                    }

                    if (bOverConsumeChk)
                    {
                        if (line.CONSUMPTION_QTY.StrongValue > line.ON_HAND_QTY.StrongValue)
                        {
                            if (listInvalidConsumptionQty.Contains(line.ITEM_CD.StrongValue))
                                continue;
                            listInvalidConsumptionQty.Add(line.ITEM_CD.StrongValue);
                        }
                    }
                    ValidateException.ThrowErrorItem(commonVal.CheckInputLot(line.ITEM_CD, line.LOC_CD, line.LOT_NO, true));
                }

                // Generate item doesn't input LOT_NO
                if (listInvalidLotNo.Count > 0)
                {
                    listInvalidLotNo.Sort();

                    string errorItems = string.Empty;
                    for (int i = 0; i < listInvalidLotNo.Count; i++)
                    {
                        if (i != 0)
                        {
                            errorItems += ", ";
                        }
                        errorItems += listInvalidLotNo[i];
                    }

                    ValidateException.ThrowErrorItem(new ErrorItem(null, TKPMessages.eValidate.VLM0050.ToString(), new object[] { errorItems }));
                    return false;
                }


                // Generate list item that input consumption qty more than stock onhand qty.
                if (listInvalidConsumptionQty.Count > 0)
                {
                    listInvalidConsumptionQty.Sort();

                    string errorItems = string.Empty;
                    for (int i = 0; i < listInvalidConsumptionQty.Count; i++)
                    {
                        if (i != 0)
                        {
                            errorItems += ", ";
                        }
                        errorItems += listInvalidConsumptionQty[i];
                    }

                    ValidateException.ThrowErrorItem(new ErrorItem(null, TKPMessages.eValidate.VLM0051.ToString(), new object[] { errorItems }));
                    return false;
                }
                #endregion

                // Validate Child Item to support Parent Item.
                #region Validate Child Item to support Parent item.
                // Summary Consumption Qty by Item (not include LotNo) and then check compare with RequestQty.
                InventoryBIZ bizInventory = new InventoryBIZ();
                List<WorkResultEntryViewDTO> listSourceChildItems = bizInventory.LoadConsumptionListFromItemCode(model.ItemCode, model.OrderLoc, model.WorkResultQty);
                for (int i = 0; i < listSourceChildItems.Count; i++) {
                    object objSumByItem = model.DataView.Compute(
                        String.Format("SUM({0})", WorkResultEntryViewDTO.eColumns.CONSUMPTION_QTY),
                        String.Format("{0} = '{1}'", WorkResultEntryViewDTO.eColumns.ITEM_CD, listSourceChildItems[i].ITEM_CD.StrongValue)
                        );



                    decimal sumConsumptionQty = 0;
                    if (objSumByItem != null && objSumByItem != DBNull.Value)
                        sumConsumptionQty = Convert.ToDecimal(objSumByItem);

                    decimal diffQty = Math.Abs(sumConsumptionQty - listSourceChildItems[i].CONSUMPTION_QTY.StrongValue);
                    if (sumConsumptionQty < listSourceChildItems[i].REQUEST_QTY.StrongValue)  // Total of ConsumtpionQty < RequestQty
                    {
                        // Confirmation to continue save.
                        MessageDialogResult dr = MessageDialog.ShowConfirmation(null, Message.LoadMessage(TKPMessages.eConfirm.CFM0001.ToString(),
                                                                                 new object[]
                                                                                 {
                                                                                     listSourceChildItems[i].ITEM_CD.StrongValue,
                                                                                     model.ItemCode.StrongValue,
                                                                                     diffQty.ToString(DataDefine.DEFAULT_FORMAT_NUMBER)
                                                                                 }),
                                                       MessageDialogButtons.YesNo);

                        if (dr == MessageDialogResult.No)
                            return false;
                    }
                    else if (sumConsumptionQty > listSourceChildItems[i].REQUEST_QTY.StrongValue)  // Total of ConsumtpionQty > RequestQty
                    {
                        // Confirmation to continue save.
                        MessageDialogResult dr = MessageDialog.ShowConfirmation(null, Message.LoadMessage(TKPMessages.eConfirm.CFM0002.ToString(),
                                                                                 new object[]
                                                                                 {
                                                                                     listSourceChildItems[i].ITEM_CD.StrongValue,
                                                                                     model.ItemCode.StrongValue,
                                                                                     diffQty.ToString(DataDefine.DEFAULT_FORMAT_NUMBER)
                                                                                 }),
                                                       MessageDialogButtons.YesNo);

                        if (dr == MessageDialogResult.No)
                            return false;
                    }
                }
                #endregion
            }

            #endregion
            DataTable dtData;
            if (model.DataView == null)
            {
                WorkResultEntryViewDTO dto = new WorkResultEntryViewDTO();
                dto.CreateDataTableSchema(out dtData);
            }
            else
            {
                dtData = model.DataView;
            }


            DataTable dtAdd = dtData.GetChanges(DataRowState.Added);
            DataTable dtUpdate = dtData.GetChanges(DataRowState.Modified);
            DataTable dtDelete = dtData.GetChanges(DataRowState.Deleted);

            List<InventoryTransactionDTO> listAdd = new List<InventoryTransactionDTO>();
            List<InventoryTransactionDTO> listUpdate = new List<InventoryTransactionDTO>();
            List<InventoryTransactionDTO> listDelete = new List<InventoryTransactionDTO>();
            Database db = null;
            try
            {
                db = Common.CurrentDatabase;
                db.KeepConnection = true;
                db.BeginTransaction();

                //TransactionValidator valTran = new TransactionValidator();
                //InventoryTransBIZ bizTran = new InventoryTransBIZ();
                //bizTran.l

                #region Header
                NZString runningNo = new NZString();

                //ให้ generate lot ใหม่อีกครั้ง กรณีกรอกพร้อมกัน 2 เครื่อง ไม่งั้นมันจะ insert ข้อมูลมั่ว
                // ที่ใส่ตรงนี้เพราะว่า จะได้แก้ model.LotNo ก่อนที่จะสร้าง  object dto
                //เนื่องจาก reserve ก็มีดึง lot no ไปใช้
                if (model.WorkResultNo.IsNull) {
                    RunningNumberBIZ runnningBiz = new RunningNumberBIZ();
                    NZString strCompleteLotNo = runnningBiz.GetCompleteLotNo(new NZDateTime(null, model.WorkResultDate.StrongValue), model.StoredLoc, model.ItemCode, new NZInt(null, 0));
                    model.LotNo = strCompleteLotNo;
                }

                InventoryTransactionDTO dtoWorkResult = CreateDTOForWorkResult(model);
                InventoryTransactionDTO dtoNGResult = CreateDTOForNGResult(model);
                InventoryTransactionDTO dtoReserveResult = CreateDTOForReserveResult(model);

                InventoryTransBIZ bizTran = new InventoryTransBIZ();
                bizTran.LockRefSlipNumber(dtoWorkResult.REF_SLIP_NO);

                if (model.WorkResultNo.IsNull) {
                    RunningNumberBIZ runningNumberBIZ = new RunningNumberBIZ();
                    runningNo = runningNumberBIZ.GetCompleteRunningNo((NZString)"WORK_RESULT_SLIP_NO", (NZString)"TB_INV_TRANS_TR");

                    // Create new transaction.                    
                    dtoWorkResult.SLIP_NO = runningNo;
                    dtoNGResult.SLIP_NO = runningNo;
                    dtoReserveResult.SLIP_NO = runningNo;

                    listAdd.Add(dtoWorkResult);
                    if (model.NGQty.NVL(0) > 0)
                        listAdd.Add(dtoNGResult);

                    if (model.ReserveQty.NVL(0) > 0)
                        listAdd.Add(dtoReserveResult);
                }
                else {
                    // Update old transaction
                    runningNo = model.WorkResultNo;

                    listUpdate.Add(dtoWorkResult);

                    if (!model.NGTransactionID.IsNull) // UPDATE NG IF IT ALREADY HAS NG QTY
                    {
                        listUpdate.Add(dtoNGResult);
                    }
                    else if (model.NGQty.NVL(0) > 0) // ADD NEW NG TRANS IF NEW NG IS INPUT
                    {
                        //dtoNGResult.SLIP_NO = dtoWorkResult.SLIP_NO;
                        listAdd.Add(dtoNGResult);
                    }

                    if (!model.ReserveTransactionID.IsNull) // UPDATE Reserve IF IT ALREADY HAS Reserve QTY
                    {
                        listUpdate.Add(dtoReserveResult);
                    }
                    else if (model.ReserveQty.NVL(0) > 0) // ADD NEW Reserve TRANS IF NEW NG IS INPUT
                    {
                        //dtoReserveResult.SLIP_NO = dtoWorkResult.SLIP_NO;
                        listAdd.Add(dtoNGResult);
                    }

                }

                #endregion

                #region Detail

                #region Do Auto Consumption
                if (ConsumptionClass == DataDefine.eCONSUMPTION_CLS.Auto)
                {
                    // WHEN CONSUMPTION IS AUTO
                    // DELETE ALL OLD TRANSACTION FIRST THEN ADD NEW

                    //Modify by Bunyapat L.
                    //28 Apr 2011
                    //ให้สั่ง ClearConsumption ไปเลย 
                    List<WorkResultEntryViewDTO> listTMPDelete = null;
                    List<InventoryTransactionDTO> listTmpDelete = null;

                    if (dtData != null && dtData.Rows.Count > 0)
                    {
                        listTMPDelete = DTOUtility.ConvertDataTableToList<WorkResultEntryViewDTO>(dtData);
                        listTmpDelete = new List<InventoryTransactionDTO>();
                        for (int i = 0; i < listTMPDelete.Count; i++)
                        {
                            WorkResultEntryViewDTO line = listTMPDelete[i];
                            InventoryTransactionDTO dto = CreateDTOForConsumption(model, line);
                            dto.REF_NO = runningNo;

                            listTmpDelete.Add(dto);
                        }

                        // Move to delete below section
                        //biz.WorkResultItems(Common.CurrentDatabase, null, null, listTmpDelete);
                    }

                    biz.ClearConsumption(Common.CurrentDatabase, dtoWorkResult);

                    if (dtData != null && dtData.Rows.Count > 0)
                    {
                        List<WorkResultEntryViewDTO> listTMPAdd = DTOUtility.ConvertDataTableToList<WorkResultEntryViewDTO>(dtData);

                        // GET LOCATION INFORMATION
                        DealingBIZ bizLoc = new DealingBIZ();
                        for (int i = 0; i < listTMPAdd.Count; i++)
                        {
                            DealingDTO dtoLoc = bizLoc.LoadLocation(listTMPAdd[i].LOC_CD);
                            bool AllowNegative = dtoLoc.ALLOW_NEGATIVE.StrongValue == "01";


                            // GET CONSUMPTION ITEM FROM FIFO PROCESS WRITE BY KIMMIK.
                            List<ActualOnhandViewDTO> dtoListActOnhand = biz.FifoListingProcess(Common.CurrentDatabase
                                , listTMPAdd[i].ITEM_CD.StrongValue, listTMPAdd[i].LOC_CD.StrongValue
                                , listTMPAdd[i].CONSUMPTION_QTY.StrongValue
                                , !AllowNegative, AllowNegative);
                            if (dtoListActOnhand != null && dtoListActOnhand.Count > 0)
                            {
                                for (int j = 0; j < dtoListActOnhand.Count; j++)
                                {
                                    InventoryTransactionDTO dto = CreateDTOForConsumption(model, dtoListActOnhand[j]);
                                    dto.REF_NO = runningNo;

                                    listAdd.Add(dto);
                                }
                            }
                        }
                    }
                    biz.WorkResultItems(Common.CurrentDatabase, listAdd, listUpdate, listDelete);
                }
                #endregion

                #region Do Manual Consumption
                if (ConsumptionClass == DataDefine.eCONSUMPTION_CLS.Manual)
                {
                    List<InventoryTransactionDTO> listTmpDelete = new List<InventoryTransactionDTO>();
                    //== Update process.
                    //Modify by Bunyapat L.
                    //28 Apr 2011
                    //Manual consumption ให้ใช้การ insert เข้า Delete ทุกตัวที่เป็นตัวเก่า
                    //แล้วค่อย Add ตัวใหม่แทน เพราะข้างใน function มันจะทำการ clear consumption ทั้งหมด ไม่งั้นจะเกิด bug ตอน update
                    if (dtUpdate != null && dtUpdate.Rows.Count > 0)
                    {
                        List<WorkResultEntryViewDTO> listViewUpdate = DTOUtility.ConvertDataTableToList<WorkResultEntryViewDTO>(dtUpdate);


                        for (int i = 0; i < listViewUpdate.Count; i++)
                        {
                            WorkResultEntryViewDTO line = listViewUpdate[i];

                            // Copy ค่า Header จาก Model ไปยัง DTO แต่ละตัว
                            InventoryTransactionDTO dto = CreateDTOForConsumption(model, line);
                            dto.REF_NO = runningNo;

                            //listUpdate.Add(dto);
                            listAdd.Add(dto);
                            listTmpDelete.Add((InventoryTransactionDTO)dto.Clone());
                        }
                    }

                    //== Insert process.
                    if (dtAdd != null && dtAdd.Rows.Count > 0)
                    {
                        List<WorkResultEntryViewDTO> listViewAdd = DTOUtility.ConvertDataTableToList<WorkResultEntryViewDTO>(dtAdd);

                        for (int i = 0; i < listViewAdd.Count; i++)
                        {
                            WorkResultEntryViewDTO line = listViewAdd[i];
                            InventoryTransactionDTO dto = CreateDTOForConsumption(model, line);
                            dto.REF_NO = runningNo;

                            listAdd.Add(dto);
                        }
                    }


                    //== Delete process.
                    if (dtDelete != null && dtDelete.Rows.Count > 0)
                    {
                        List<WorkResultEntryViewDTO> listViewDelete = DTOUtility.ConvertDataTableToList<WorkResultEntryViewDTO>(dtDelete);
                        for (int i = 0; i < dtDelete.Rows.Count; i++)
                        {
                            WorkResultEntryViewDTO line = listViewDelete[i];

                            // Copy ค่า Header จาก Model ไปยัง DTO แต่ละตัว
                            InventoryTransactionDTO dto = CreateDTOForConsumption(model, line);
                            dto.REF_NO = runningNo;

                            listDelete.Add(dto);
                        }
                    }
                    biz.WorkResultItems(Common.CurrentDatabase, null, null, listTmpDelete);
                    biz.WorkResultItems(Common.CurrentDatabase, listAdd, listUpdate, listDelete);
                }
                #endregion

                #region Do No Consumption
                if (ConsumptionClass == DataDefine.eCONSUMPTION_CLS.No)
                {
                    biz.WorkResultItems(Common.CurrentDatabase, listAdd, listUpdate, listDelete);
                }
                #endregion
                #endregion

                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
            finally
            {
                if (db.DBConnectionState == ConnectionState.Open)
                {
                    db.Close();
                }
            }

            return true;
        }
        #endregion

        #region Delete Data
        public void DeleteWorkResult(NZString workResultNo)
        {

            InventoryBIZ biz = new InventoryBIZ();
            biz.DeleteWorkResult(workResultNo);


        }

        public void DeleteGroupTransaction(NZString groupTrans)
        {

            InventoryBIZ biz = new InventoryBIZ();
            biz.DeleteGroupTransaction(groupTrans);


        }
        #endregion

    }
}
