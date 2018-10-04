//Note มีเรื่อง BOM ด้วย

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
    internal class MultiWorkResultController
    {
        #region Create UI Data model
        public MultiWorkResultEntryUIDM CreateUIDMForAddMode()
        {
            MultiWorkResultEntryUIDM model = new MultiWorkResultEntryUIDM();
            model.WorkResultDate.Value = CommonLib.Common.GetDatabaseDateTime();
            model.DataView.AcceptChanges();
            return model;
        }
        #endregion

        #region Mapping

        private InventoryTransactionDTO CreateDTOForConsumption(WorkResultEntryUIDM model, ActualOnhandViewDTO line)
        {
            InventoryTransactionDTO dto = new InventoryTransactionDTO();

            //dto.TRANS_ID = line.TRANS_ID; // TRANS_ID จะได้มาเองตอน add transaction
            //dto.ITEM_CD = line.ITEM_CD;
            //dto.LOC_CD = model.OrderLoc;
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

        public List<MultiWorkResultEntryViewDTO> LoadChildItemToInputMultiWorkResult(NZString childItemCode, NZString orderLoc, NZString lotNo, DataDefine.eTRAN_SUB_CLS workResultType)
        {
            InventoryBIZ biz = new InventoryBIZ();
            return biz.LoadChildItemToInputMultiWorkResult(childItemCode, orderLoc, lotNo, workResultType);
        }

        public List<BOMSetupDTO> LoadChildItem(NZString parentItemCode)
        {
            List<BOMSetupDTO> listResult = new List<BOMSetupDTO>();

            //method นี้ไว้ใช้กับ Multi work result เท่านั้น เลยต้อง check ว่ามันมี level แรก ตัวเดียว
            //หลังจากได้ BOM ค่อยไปหา equivalent item มาให้

            //กรณาอย่าแก้ไขให้ดึงข้อมูลBOM ได้หลายตัว ไม่งั้น multi work result จะผิด            
            BOMBIZ biz = new BOMBIZ();
            List<BOMSetupDTO> listExplosion = biz.LoadBOMExplosion(parentItemCode);

            int iCountLevel1 = 0; //เก็บ count level =1
            int iIndexLevel1 = -1; //เก็บ index ของตัวที่ level =1
            for (int iLength = 0; iLength < listExplosion.Count; iLength++)
            {
                if (listExplosion[iLength].LEVEL == 1)
                {
                    iIndexLevel1 = iLength;
                    iCountLevel1++;

                    if (iCountLevel1 > 1) break;
                }
            }

            if (iCountLevel1 > 1 || iIndexLevel1 == -1)
            {
                throw new BusinessException(new ErrorItem(null, TKPMessages.eValidate.VLM0094.ToString()));
            }

            //ต้องเป็น 1 / 1 ระหว่าง upper , lower เท่านั้น
            if (!(listExplosion[iIndexLevel1].UPPER_QTY == 1 && listExplosion[iIndexLevel1].LOWER_QTY == 1))
            {
                throw new BusinessException(new ErrorItem(null, TKPMessages.eValidate.VLM0098.ToString()));
            }


            //ItemBIZ bizItem = new ItemBIZ();
            //ItemDTO dtoItem = bizItem.LoadItem(list[iIndexLevel1].LOWER_ITEM_CD);

            BOMSetupDTO dtoBOM = listExplosion[iIndexLevel1];

            listResult.Add((BOMSetupDTO)dtoBOM.Clone());

            //Load Equivalent Item
            ItemDTO dtoItem = new ItemDTO();
            dtoItem.ITEM_CD = dtoBOM.LOWER_ITEM_CD;

            ItemBIZ bizItem = new ItemBIZ();
            List<ItemEquivalentDTO> listEquivalent = bizItem.LoadEquivalentItem(dtoItem);

            foreach (ItemEquivalentDTO objEquivalent in listEquivalent)
            {
                BOMSetupDTO dtoBOMEquivalent = new BOMSetupDTO();
                dtoBOMEquivalent.UPPER_ITEM_CD = parentItemCode;
                dtoBOMEquivalent.LOWER_ITEM_CD = objEquivalent.EQUIVALENT_ITEM_CD;
                dtoBOMEquivalent.UPPER_QTY = dtoBOM.UPPER_QTY;
                dtoBOMEquivalent.LOWER_QTY = dtoBOM.LOWER_QTY;
                //dtoBOMEquivalent.CHILD_ORDER_LOC_CD = objEquivalent.ORDER_LOC_CD;
                listResult.Add(dtoBOMEquivalent);
            }

            return listResult;
        }

        private InventoryTransactionDTO CreateDTOForWorkResult(MultiWorkResultEntryUIDM modelHeader
            , MultiWorkResultEntryViewDTO dtoDetailEntry)
        {
            InventoryTransactionDTO dtoTrans = new InventoryTransactionDTO();

            dtoTrans.TRANS_ID = dtoDetailEntry.GOOD_TRANSACTION_ID;
            dtoTrans.ITEM_CD = modelHeader.ItemCode;
            dtoTrans.LOC_CD = modelHeader.StoredLoc;
            if (DataDefine.eTRAN_SUB_CLS.WR.ToString().Equals(modelHeader.TRAN_SUB_CLS))
            {
                dtoTrans.LOT_NO = dtoDetailEntry.LOT_NO;
                dtoTrans.TRAN_SUB_CLS = DataDefine.eTRAN_SUB_CLS.WR.ToString().ToNZString();
            }
            else if (DataDefine.eTRAN_SUB_CLS.RW.ToString().Equals(modelHeader.TRAN_SUB_CLS))
            {
                if (dtoDetailEntry.LOT_NO.ToString().EndsWith(DataDefine.LOT_RESERVE_POSTFIX))
                {
                    dtoTrans.LOT_NO.Value = dtoDetailEntry.LOT_NO.ToString().Remove(dtoDetailEntry.LOT_NO.ToString().Length - 2);
                }
                else
                {
                    dtoTrans.LOT_NO = dtoDetailEntry.LOT_NO;
                }

                dtoTrans.TRAN_SUB_CLS = DataDefine.eTRAN_SUB_CLS.RW.ToString().ToNZString();
            }
            else
            {
                //ใช้เหมือน WorkResult
                dtoTrans.LOT_NO = dtoDetailEntry.LOT_NO;
                dtoTrans.TRAN_SUB_CLS = DataDefine.eTRAN_SUB_CLS.WR.ToString().ToNZString();
            }
            dtoTrans.TRANS_DATE = modelHeader.WorkResultDate;
            dtoTrans.TRANS_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.WorkResult);
            dtoTrans.IN_OUT_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.In);
            dtoTrans.QTY.Value = dtoDetailEntry.GOOD_QTY.NVL(0);
            dtoTrans.NG_QTY.Value = dtoDetailEntry.NG_QTY.NVL(0);
            dtoTrans.REMARK = modelHeader.Remark;
            dtoTrans.REF_SLIP_NO = modelHeader.WorkOrderNo;
            dtoTrans.SLIP_NO = dtoDetailEntry.WORK_RESULT_NO;
            //dtoTrans.REF_SLIP_NO2 = model.WorkOrderNo2; // ไม่มี
            dtoTrans.REF_SLIP_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eREF_SLIP_CLS.WorkOrder);
            dtoTrans.CRT_BY = Common.CurrentUserInfomation.UserCD;
            dtoTrans.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
            dtoTrans.UPD_BY = Common.CurrentUserInfomation.UserCD;
            dtoTrans.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
            dtoTrans.SHIFT_CLS = modelHeader.ShiftClass;
            dtoTrans.FOR_MACHINE = modelHeader.ForMachine;
            dtoTrans.SCREEN_TYPE = DataDefine.ScreenType.WorkResultEntry.ToNZString();
            dtoTrans.GROUP_TRANS_ID = modelHeader.WorkResultGroupNo;
            dtoTrans.RESERVE_QTY.Value = dtoDetailEntry.RESERVE_QTY.NVL(0);
            dtoTrans.NG_REASON = dtoDetailEntry.NG_REASON;

            return dtoTrans;
        }
        private InventoryTransactionDTO CreateDTOForNGResult(MultiWorkResultEntryUIDM modelHeader
            , MultiWorkResultEntryViewDTO dtoDetailEntry, NZString ngLocation)
        {
            InventoryTransactionDTO dto = new InventoryTransactionDTO();

            dto.TRANS_ID = dtoDetailEntry.NG_TRANSACTION_ID;
            dto.ITEM_CD = modelHeader.ItemCode;
            dto.LOC_CD = ngLocation;
            dto.LOT_NO = DataDefine.LOT_SCRAP.ToNZString();
            dto.TRANS_DATE = modelHeader.WorkResultDate;
            dto.TRANS_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.NGWorkResult);
            dto.IN_OUT_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.In);
            dto.QTY = dtoDetailEntry.NG_QTY;
            dto.NG_QTY = dtoDetailEntry.NG_QTY;
            dto.REMARK = modelHeader.Remark;
            dto.REF_SLIP_NO = modelHeader.WorkOrderNo;
            dto.SLIP_NO = dtoDetailEntry.WORK_RESULT_NO;
            dto.REF_SLIP_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eREF_SLIP_CLS.WorkOrder);
            dto.CRT_BY = Common.CurrentUserInfomation.UserCD;
            dto.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
            dto.UPD_BY = Common.CurrentUserInfomation.UserCD;
            dto.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
            dto.SHIFT_CLS = modelHeader.ShiftClass;
            dto.SCREEN_TYPE = DataDefine.ScreenType.WorkResultEntry.ToNZString();
            dto.GROUP_TRANS_ID = modelHeader.WorkResultGroupNo;
            return dto;
        }

        private InventoryTransactionDTO CreateDTOForReserveResult(MultiWorkResultEntryUIDM modelHeader
            , MultiWorkResultEntryViewDTO dtoDetailEntry)
        {
            InventoryTransactionDTO dto = new InventoryTransactionDTO();

            dto.TRANS_ID = dtoDetailEntry.RESERVE_TRANSACTION_ID;
            dto.ITEM_CD = modelHeader.ItemCode;
            dto.LOC_CD = modelHeader.StoredLoc;
            dto.LOT_NO.Value = dtoDetailEntry.LOT_NO + DataDefine.LOT_RESERVE_POSTFIX;
            dto.TRANS_DATE = modelHeader.WorkResultDate;
            dto.TRANS_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.ReserveResult);
            dto.IN_OUT_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.In);
            dto.QTY = dtoDetailEntry.RESERVE_QTY;
            dto.RESERVE_QTY = dtoDetailEntry.RESERVE_QTY;
            dto.REMARK = modelHeader.Remark;
            dto.REF_SLIP_NO = modelHeader.WorkOrderNo;
            dto.SLIP_NO = dtoDetailEntry.WORK_RESULT_NO;
            dto.REF_SLIP_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eREF_SLIP_CLS.WorkOrder);
            dto.CRT_BY = Common.CurrentUserInfomation.UserCD;
            dto.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
            dto.UPD_BY = Common.CurrentUserInfomation.UserCD;
            dto.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
            dto.SHIFT_CLS = modelHeader.ShiftClass;
            dto.SCREEN_TYPE = DataDefine.ScreenType.WorkResultEntry.ToNZString();
            dto.GROUP_TRANS_ID = modelHeader.WorkResultGroupNo;
            return dto;
        }


        private InventoryTransactionDTO CreateDTOForConsumption(MultiWorkResultEntryUIDM model, MultiWorkResultEntryViewDTO line)
        {
            InventoryTransactionDTO dto = new InventoryTransactionDTO();

            dto.TRANS_ID = line.CONSUMPTION_TRANSACTION_ID;
            dto.ITEM_CD = model.ChildItemCode;
            dto.LOC_CD = model.OrderLoc;
            dto.LOT_NO = line.LOT_NO;
            dto.TRANS_DATE = model.WorkResultDate;
            dto.TRANS_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Consumption);
            dto.IN_OUT_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.Out);
            dto.QTY.Value = line.GOOD_QTY.NVL(0) + line.NG_QTY.NVL(0) + line.RESERVE_QTY.NVL(0);
            dto.OBJ_ITEM_CD = model.ItemCode;
            dto.OBJ_ORDER_QTY.Value = line.GOOD_QTY.NVL(0) + line.NG_QTY.NVL(0) + line.RESERVE_QTY.NVL(0);
            dto.REMARK = model.Remark;
            dto.REF_SLIP_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eREF_SLIP_CLS.WorkResult);
            dto.CRT_BY = Common.CurrentUserInfomation.UserCD;
            dto.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
            dto.UPD_BY = Common.CurrentUserInfomation.UserCD;
            dto.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
            dto.SHIFT_CLS = model.ShiftClass;
            dto.SCREEN_TYPE = DataDefine.ScreenType.WorkResultEntry.ToNZString();
            dto.GROUP_TRANS_ID = model.WorkResultGroupNo;
            return dto;
        }


        public MultiWorkResultEntryUIDM LoadForEditMultiWorkResult(NZString transID)
        {

            //== Load Header (Work Result)
            InventoryTransBIZ bizInventoryTransaction = new InventoryTransBIZ();
            InventoryBIZ bizInventory = new InventoryBIZ();


            ItemBIZ bizItem = new ItemBIZ();

            InventoryTransactionDTO transDTO = bizInventoryTransaction.LoadByTransactionID(transID);

            if (transDTO == null)
                return null;


            //เอา transDTO ไปหา group
            //แล้วก็ group -> แปลงเป็น column ตาม spread


            ItemDTO dtoItem = bizItem.LoadItem(transDTO.ITEM_CD);
            ItemProcessDTO dtoItemProcess = bizItem.LoadItemProcess(transDTO.ITEM_CD);

            MultiWorkResultEntryUIDM model = new MultiWorkResultEntryUIDM();

            //model.ChildItemCode = ;// ต้องไปดึงมาจาก consumption ตัวแรก
            //model.OrderLoc=;

            //model.CONSUMTION_CLS = dtoItemProcess.CONSUMTION_CLS;
            model.ForMachine = transDTO.FOR_MACHINE;
            model.ItemCode = transDTO.ITEM_CD;
            model.ItemDesc = dtoItem.ITEM_DESC;
            model.Remark = transDTO.REMARK;
            model.ShiftClass = transDTO.SHIFT_CLS;
            model.StoredLoc = transDTO.LOC_CD;
            model.TRAN_SUB_CLS = transDTO.TRAN_SUB_CLS;
            model.WorkOrderNo = transDTO.REF_SLIP_NO;
            model.WorkResultDate = transDTO.TRANS_DATE;
            model.WorkResultGroupNo = transDTO.GROUP_TRANS_ID;

            List<InventoryTransactionDTO> listTrans = bizInventoryTransaction.LoadGroupTransaction(transDTO.GROUP_TRANS_ID, DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.WorkResult).ToNZString());

            //new list ของ multi work result เพื่อใส่ข้อมูล เป็น row ก่อน
            //แล้วพอวนใส่เสร็จค่อย convert เป็น datatable เพื่อ set value ให้ model.DataView
            List<MultiWorkResultEntryViewDTO> listMultiWorkResult = new List<MultiWorkResultEntryViewDTO>();



            foreach (InventoryTransactionDTO dtoTran in listTrans)
            {

                MultiWorkResultEntryViewDTO multiDTO = new MultiWorkResultEntryViewDTO();
                multiDTO.GOOD_QTY = dtoTran.QTY;
                multiDTO.GOOD_TRANSACTION_ID = dtoTran.TRANS_ID;
                //multiDTO.LOT_NO = dtoTran.LOT_NO;
                multiDTO.NG_QTY = dtoTran.NG_QTY;
                multiDTO.NG_REASON = dtoTran.NG_REASON;

                multiDTO.RESERVE_QTY = dtoTran.RESERVE_QTY;
                multiDTO.WORK_RESULT_NO = dtoTran.SLIP_NO;

                InventoryTransactionDTO dtoNGTrans = bizInventoryTransaction.LoadNGWorkResult(dtoTran.SLIP_NO);
                if (dtoNGTrans != null && !dtoNGTrans.TRANS_ID.IsNull)
                    multiDTO.NG_TRANSACTION_ID = dtoNGTrans.TRANS_ID;

                InventoryTransactionDTO dtoReserveTrans = bizInventoryTransaction.LoadReserveResult(dtoTran.SLIP_NO);
                if (dtoReserveTrans != null && !dtoReserveTrans.TRANS_ID.IsNull)
                    multiDTO.RESERVE_TRANSACTION_ID = dtoReserveTrans.TRANS_ID;



                List<WorkResultEntryViewDTO> consumptionList = bizInventory.LoadWorkResultConsumptionList(dtoTran.SLIP_NO);
                if (consumptionList != null && consumptionList.Count == 1)
                {
                    //model.OrderLoc = consumptionList[0].LOC_CD;
                    //model.ChildItemCode = consumptionList[0].ITEM_CD;
                    //multiDTO.CONSUMPTION_TRANSACTION_ID = consumptionList[0].TRANS_ID;
                    //multiDTO.ON_HAND_QTY = consumptionList[0].ON_HAND_QTY;
                    //multiDTO.LOT_NO = consumptionList[0].LOT_NO;
                }
                else
                {
                    throw new NotSupportedException("Comsumption != 1 item");
                    //if (dtoItemProcess != null)
                    //    model.OrderLoc = dtoItemProcess.ORDER_LOC_CD;
                }


                //multiDTO.ON_HAND_QTY = new NZDecimal(null, 0);//onhand + good + ng + reserve
                //ActualOnhandViewDTO onhandConsumption = bizInventory.LoadActualInventoryOnHand(model.ChildItemCode, model.OrderLoc, multiDTO.LOT_NO);
                //if (onhandConsumption == null)
                //{
                //    multiDTO.ON_HAND_QTY.Value = multiDTO.GOOD_QTY.NVL(0) + multiDTO.NG_QTY.NVL(0) + multiDTO.RESERVE_QTY.NVL(0);
                //}
                //else
                //{
                //    multiDTO.ON_HAND_QTY.Value = onhandConsumption.ONHAND_QTY.NVL(0) + multiDTO.GOOD_QTY.NVL(0) + multiDTO.NG_QTY.NVL(0) + multiDTO.RESERVE_QTY.NVL(0);
                //}



                listMultiWorkResult.Add(multiDTO);
            }

            model.DataView = DTOUtility.ConvertListToDataTable<MultiWorkResultEntryViewDTO>(listMultiWorkResult);

            model.DataView.AcceptChanges();
            return model;
        }

        
        #endregion

        #region Save Data
        public bool SaveData(MultiWorkResultEntryUIDM model)
        {
            ItemBIZ bizItem = new ItemBIZ();
            ClassListBIZ bizClassList = new ClassListBIZ();
            InventoryBIZ biz = new InventoryBIZ();
            IssueEntryValidator valLot = new IssueEntryValidator();

            #region Validate data

            MultiWorkResultEntryValidator workResultEntryValidator = new MultiWorkResultEntryValidator();
            ItemValidator itemValidator = new ItemValidator();
            DealingValidator locationValidator = new DealingValidator();
            CommonBizValidator commonVal = new CommonBizValidator();
            ValidateException.ThrowErrorItem(workResultEntryValidator.CheckWorkResultDate(model.WorkResultDate));
            ValidateException.ThrowErrorItem(itemValidator.CheckEmptyItemCode(model.ItemCode));
            ValidateException.ThrowErrorItem(itemValidator.CheckEmptyItemCode(model.ChildItemCode));
            ValidateException.ThrowErrorItem(workResultEntryValidator.CheckEmptyShiftType(model.ShiftClass));

            BusinessException itemFound = itemValidator.CheckItemNotExist(model.ItemCode);
            if (itemFound != null)
            {
                ValidateException.ThrowErrorItem(itemFound.Error);
            }

            ValidateException.ThrowErrorItem(locationValidator.CheckEmptyLocationCode(model.OrderLoc));
            ValidateException.ThrowErrorItem(locationValidator.CheckNotExistsLocationCode(model.OrderLoc));

            ValidateException.ThrowErrorItem(locationValidator.CheckEmptyLocationCode(model.StoredLoc));
            ValidateException.ThrowErrorItem(locationValidator.CheckNotExistsLocationCode(model.StoredLoc));

            #endregion

            DataTable dtData = null;
            if (model.DataView == null)
            {

                MultiWorkResultEntryViewDTO dto = new MultiWorkResultEntryViewDTO();
                dto.CreateDataTableSchema(out dtData);
            }
            else
            {
                dtData = model.DataView;
            }


            DataTable dtAdd = dtData.GetChanges(DataRowState.Added);
            DataTable dtUpdate = dtData.GetChanges(DataRowState.Modified);
            DataTable dtDelete = dtData.GetChanges(DataRowState.Deleted);

            DataTable dtUnChanged = dtData.GetChanges(DataRowState.Unchanged);

            List<InventoryTransactionDTO> listAdd = new List<InventoryTransactionDTO>();
            List<InventoryTransactionDTO> listUpdate = new List<InventoryTransactionDTO>();
            List<InventoryTransactionDTO> listDelete = new List<InventoryTransactionDTO>();

            List<MultiWorkResultEntryViewDTO> listViewAdd = DTOUtility.ConvertDataTableToList<MultiWorkResultEntryViewDTO>(dtAdd);
            List<MultiWorkResultEntryViewDTO> listViewUpdate = DTOUtility.ConvertDataTableToList<MultiWorkResultEntryViewDTO>(dtUpdate);
            List<MultiWorkResultEntryViewDTO> listViewDelete = DTOUtility.ConvertDataTableToList<MultiWorkResultEntryViewDTO>(dtDelete);
            List<MultiWorkResultEntryViewDTO> listUnchanged = DTOUtility.ConvertDataTableToList<MultiWorkResultEntryViewDTO>(dtUnChanged);



            Database db = null;
            try
            {
                db = Common.CurrentDatabase;
                db.KeepConnection = true;
                db.BeginTransaction();

                NZString runningNo = new NZString();
                NZString strWorkResultGroupNo = new NZString();

                InventoryTransactionDTO dtoWorkResult = null;
                InventoryTransactionDTO dtoNGResult = null;
                InventoryTransactionDTO dtoReserveResult = null;
                InventoryTransactionDTO dtoConsumption = null;


                InventoryTransBIZ bizTran = new InventoryTransBIZ();
                SysConfigBIZ bizSYS = new SysConfigBIZ();

                SysConfigDTO dtoSYS = bizSYS.LoadByPK(DataDefine.eSYSTEM_CONFIG.TRN080.SYS_GROUP_ID, (NZString)DataDefine.eSYSTEM_CONFIG.TRN080.SYS_KEY.NG_LOC_CD.ToString());

                //SysConfigDTO dtoSupplyLot = bizSYS.LoadByPK((NZString)"SUPPLY", (NZString)"SUPP_LOT");

                NZString strNGLocation = null;
                if (dtoSYS == null || dtoSYS.CHAR_DATA.IsNull || dtoSYS.CHAR_DATA.StrongValue == "ORDER_LOC")
                {
                    strNGLocation = model.OrderLoc;
                }
                else
                {
                    strNGLocation = dtoSYS.CHAR_DATA;
                }

                RunningNumberBIZ runningNumberBIZ = new RunningNumberBIZ();

                //set Work Result Group No ให้กับทุกตัว
                //ถ้าheader ยังไม่มีก็ genใหม่
                //ถ้าheader มีแล้ว ก็ใช้ตัวนั้น
                if (model.WorkResultGroupNo.IsNull)
                {
                    strWorkResultGroupNo = runningNumberBIZ.GetCompleteRunningNo((NZString)"WORK_RESULT_GROUP_NO", (NZString)"TB_INV_TRANS_TR");
                    model.WorkResultGroupNo = strWorkResultGroupNo;
                }

                foreach (MultiWorkResultEntryViewDTO dtoAdd in listViewAdd)
                {
                    runningNo = runningNumberBIZ.GetCompleteRunningNo((NZString)"WORK_RESULT_SLIP_NO", (NZString)"TB_INV_TRANS_TR");

                    //ถ้าใส่จำนวนใดจำนวนหนึ่งมา ก็จะ save ได้
                    if (dtoAdd.GOOD_QTY.NVL(0) + dtoAdd.NG_QTY.NVL(0) + dtoAdd.RESERVE_QTY.NVL(0) > 0)
                    {
                        dtoWorkResult = CreateDTOForWorkResult(model, dtoAdd);
                        dtoWorkResult.SLIP_NO = runningNo;
                        listAdd.Add(dtoWorkResult);

                        if (dtoAdd.NG_QTY.NVL(0) > 0)
                        {
                            dtoNGResult = CreateDTOForNGResult(model, dtoAdd, strNGLocation);
                            dtoNGResult.SLIP_NO = runningNo;
                            listAdd.Add(dtoNGResult);
                        }

                        //เฉพาะ work result ที่จะมี reserve ได้
                        if (DataDefine.eTRAN_SUB_CLS.WR.ToString().Equals(model.TRAN_SUB_CLS))
                        {
                            if (dtoAdd.RESERVE_QTY.NVL(0) > 0)
                            {
                                dtoReserveResult = CreateDTOForReserveResult(model, dtoAdd);
                                dtoReserveResult.SLIP_NO = runningNo;
                                listAdd.Add(dtoReserveResult);
                            }
                        }

                        dtoConsumption = CreateDTOForConsumption(model, dtoAdd);
                        dtoConsumption.REF_NO = dtoWorkResult.SLIP_NO;
                        listAdd.Add(dtoConsumption);
                    }

                }

                foreach (MultiWorkResultEntryViewDTO dtoUnchanged in listUnchanged)
                {
                    dtoWorkResult = CreateDTOForWorkResult(model, dtoUnchanged);
                    listUpdate.Add(dtoWorkResult);
                }


                foreach (MultiWorkResultEntryViewDTO dtoUpdate in listViewUpdate)
                {
                    dtoWorkResult = CreateDTOForWorkResult(model, dtoUpdate);
                    listUpdate.Add(dtoWorkResult);

                    if (dtoUpdate.NG_QTY.NVL(0) > 0)
                    {
                        dtoNGResult = CreateDTOForNGResult(model, dtoUpdate, strNGLocation);

                        if (dtoNGResult.TRANS_ID.IsNull)
                        {
                            listAdd.Add(dtoNGResult);
                        }
                        else
                        {
                            listUpdate.Add(dtoNGResult);
                        }
                    }

                    //เฉพาะ work result ที่จะมี reserve ได้
                    if (DataDefine.eTRAN_SUB_CLS.WR.ToString().Equals(model.TRAN_SUB_CLS))
                    {
                        if (dtoUpdate.RESERVE_QTY.NVL(0) > 0)
                        {
                            dtoReserveResult = CreateDTOForReserveResult(model, dtoUpdate);

                            if (dtoReserveResult.TRANS_ID.IsNull)
                            {
                                listAdd.Add(dtoReserveResult);
                            }
                            else
                            {
                                listUpdate.Add(dtoReserveResult);
                            }
                        }
                    }

                    dtoConsumption = CreateDTOForConsumption(model, dtoUpdate);
                    dtoConsumption.REF_NO = dtoWorkResult.SLIP_NO;
                    //consumption ใช้การ add เพราะ ใช้การ clear แล้ว insert ใหม่ เลยต้อง add consumption ใหม่ตลอด
                    listAdd.Add(dtoConsumption);

                    biz.ClearConsumption(Common.CurrentDatabase, dtoWorkResult);
                }




                foreach (MultiWorkResultEntryViewDTO dtoDelete in listViewDelete)
                {
                    dtoWorkResult = CreateDTOForWorkResult(model, dtoDelete);
                    listDelete.Add(dtoWorkResult);

                    if (dtoDelete.NG_QTY.NVL(0) > 0)
                    {
                        dtoNGResult = CreateDTOForNGResult(model, dtoDelete, strNGLocation);
                        listDelete.Add(dtoNGResult);
                    }

                    //เฉพาะ work result ที่จะมี reserve ได้
                    if (DataDefine.eTRAN_SUB_CLS.WR.ToString().Equals(model.TRAN_SUB_CLS))
                    {
                        if (dtoDelete.RESERVE_QTY.NVL(0) > 0)
                        {
                            dtoReserveResult = CreateDTOForReserveResult(model, dtoDelete);
                            listDelete.Add(dtoReserveResult);
                        }
                    }

                    dtoConsumption = CreateDTOForConsumption(model, dtoDelete);
                    listDelete.Add(dtoConsumption);
                }


                biz.WorkResultItems(Common.CurrentDatabase, listAdd, listUpdate, listDelete);

                db.Commit();
            }
            catch (Exception ex)
            {
                db.Rollback();
                throw ex;
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
        #endregion

    }
}
