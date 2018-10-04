using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using Rubik.UIDataModel;
using Rubik.BIZ;
using Rubik.DTO;
using EVOFramework.Data;
using System.Data;
using CommonLib;
using SystemMaintenance.BIZ;
using Rubik.Validators;

namespace Rubik.Controller
{
    public class ReceivingEntryController
    {
        private ReceivingEntryUIDM MapDTOToUIDM(InventoryTransactionViewDTO dto)
        {
            ReceivingEntryUIDM model = new ReceivingEntryUIDM();
            model.RECEIVE_NO = dto.SLIP_NO;
            model.RECEIVE_DATE = dto.TRANS_DATE;
            model.RECEIVE_TYPE = dto.TRANS_CLS;
            model.INVOICE_NO = dto.OTHER_DL_NO;
            model.PO_NO = dto.REF_SLIP_NO;
            model.STORED_LOC = dto.LOC_CD;
            model.REMARK = dto.REMARK;
            model.DEALING_NO = dto.DEALING_NO;
            return model;
        }

        /// <summary>
        /// คัดลอกค่าที่เป็น Header ของ Model ไปเก็บไว้ใน DTO
        /// </summary>
        /// <param name="model"></param>
        /// <param name="dto"></param>
        private void AssignHeaderToDTO(ReceivingEntryUIDM model, InventoryTransactionDTO dto)
        {
            dto.TRANS_DATE = model.RECEIVE_DATE;
            dto.SLIP_NO = model.RECEIVE_NO;
            dto.TRANS_CLS = model.RECEIVE_TYPE;
            dto.REF_SLIP_NO = model.PO_NO;
            dto.OTHER_DL_NO = model.INVOICE_NO;
            dto.REMARK = model.REMARK;
            dto.LOC_CD = model.STORED_LOC;
            dto.DEALING_NO = model.DEALING_NO;
            dto.SCREEN_TYPE = DataDefine.ScreenType.ReceivingEntry.ToNZString();

            dto.REF_SLIP_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eREF_SLIP_CLS.PurchseOrder);

            if (dto.TRANS_CLS.StrongValue == DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Receiving))
                dto.IN_OUT_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.In);
            else
            {
                dto.IN_OUT_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.Out);
            }

            if (dto.REF_NO.IsNull)
            {
                RunningNumberBIZ runningNumberBIZ = new RunningNumberBIZ();
                NZString runningNo = runningNumberBIZ.GetCompleteRunningNo(DataDefine.RECEIVE_REF_NO.ToNZString(), DataDefine.TRANSACTION_TABLE_NAME.ToNZString());
                dto.REF_NO = runningNo;
            }
        }

        /// <summary>
        /// Load data for Receiving Entry.
        /// </summary>
        /// <param name="receiveNo"></param>
        /// <returns></returns>
        public ReceivingEntryUIDM LoadData(NZString receiveNo)
        {

            InventoryBIZ biz = new InventoryBIZ();
            List<InventoryTransactionViewDTO> listViewDTO = biz.LoadTransactionViewByReceiveNo(receiveNo);
            if (listViewDTO != null)
            {
                if (listViewDTO.Count > 0)
                {
                    ReceivingEntryUIDM model = MapDTOToUIDM(listViewDTO[0]);
                    model.DATA_VIEW = DTOUtility.ConvertListToDataTable(listViewDTO);

                    //== Ensure that data has not modified.
                    model.DATA_VIEW.AcceptChanges();

                    return model;
                }
            }
            return new ReceivingEntryUIDM();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <exception cref="!:EVOFramework.ValidateException"><c>ValidateException</c>.</exception>
        public void Save(ReceivingEntryUIDM model, Common.eScreenMode Mode)
        {
            try
            {
                Common.CurrentDatabase.KeepConnection = true;
                Common.CurrentDatabase.BeginTransaction(IsolationLevel.Serializable);

                InventoryBIZ biz = new InventoryBIZ();
                InventoryTransBIZ bizTrans = new InventoryTransBIZ();

                #region Validate Data
                //== Validate Header, contain: Receive Date, Stored Loc.
                ReceivingValidator receivingValidator = new ReceivingValidator();
                DealingValidator locationValidator = new DealingValidator();
                ItemValidator itemValidator = new ItemValidator();
                CommonBizValidator commonVal = new CommonBizValidator();

                ValidateException.ThrowErrorItem(receivingValidator.CheckReceiveDate(model.RECEIVE_DATE));
                ValidateException.ThrowErrorItem(locationValidator.CheckEmptyLocationCode(model.STORED_LOC));
                ValidateException.ThrowErrorItem(locationValidator.CheckNotExistsLocationCode(model.STORED_LOC));
                // Check for Supplier Type
                ValidateException.ThrowErrorItem(receivingValidator.CheckForSupplierType(model.DEALING_NO));

                //== If data not has to processing.
                if (model.DATA_VIEW == null || model.DATA_VIEW.Rows.Count == 0)
                    ValidateException.ThrowErrorItem(new ErrorItem(null, TKPMessages.eValidate.VLM0055.ToString()));

                DataTable dtNonDelete = model.DATA_VIEW.GetChanges(DataRowState.Unchanged | DataRowState.Added | DataRowState.Modified);
                List<InventoryTransactionViewDTO> listData = DTOUtility.ConvertDataTableToList<InventoryTransactionViewDTO>(dtNonDelete);

                //== Validate Item cannot duplicate on ITEM_CD and LOT_NO           
                List<string> listCheckKeyDuplicate = new List<string>();
                for (int i = 0; i < listData.Count; i++)
                {
                    BusinessException err = itemValidator.CheckItemNotExist(listData[i].ITEM_CD);
                    if (err != null)
                        ValidateException.ThrowErrorItem(err.Error);
                    string strKey = listData[i].ITEM_CD.NVL(String.Empty)
                        + listData[i].LOT_NO.NVL(String.Empty)
                        + listData[i].EXTERNAL_LOT_NO.NVL(String.Empty)
                        ;

                    if (listCheckKeyDuplicate.Contains(strKey))
                    {
                        ValidateException.ThrowErrorItem(new ErrorItem(null, TKPMessages.eValidate.VLM0096.ToString(), new object[] { listData[i].ITEM_CD.NVL(String.Empty), listData[i].LOT_NO.NVL(String.Empty), listData[i].EXTERNAL_LOT_NO.NVL(String.Empty) }));
                    }

                    listCheckKeyDuplicate.Add(strKey);


                }




                for (int i = 0; i < listData.Count; i++)
                {
                    InventoryTransactionViewDTO viewDTO = listData[i];

                    //== Check LotNo If item use lot control class.
                    ValidateException.ThrowErrorItem(commonVal.CheckInputLot(viewDTO.ITEM_CD, new NZString(), viewDTO.LOT_NO, false));

                }
                #endregion


                DataTable dtData = model.DATA_VIEW;

                DataTable dtAdd = dtData.GetChanges(DataRowState.Added);
                DataTable dtModify = dtData.GetChanges(DataRowState.Modified);
                DataTable dtDelete = dtData.GetChanges(DataRowState.Deleted);

                List<InventoryTransactionDTO> listAdd = null;
                List<InventoryTransactionDTO> listUpdate = null;
                List<InventoryTransactionDTO> listDelete = null;


                //มีการปรับให้ทำคำสั่งทีละ set ของ add , update , delete เลย
                //ที่เริ่มจาก delete ก่อนเพราะ consumption จะได้มีการเอาไปใช้สำหรับตัวที่ add ได้เลย ไม่ต้องค้างไว้ lot หน้า
                //== Delete process.
                if (dtDelete != null && dtDelete.Rows.Count > 0)
                {
                    listDelete = DTOUtility.ConvertDataTableToList<InventoryTransactionDTO>(dtDelete);

                    List<InventoryTransactionDTO> listDeleteConsumption = null;
                    for (int i = 0; i < listDelete.Count; i++)
                    {
                        InventoryTransactionDTO dto = listDelete[i];

                        listDeleteConsumption = bizTrans.LoadConsumptionItemByRefNo(dto.REF_NO);
                        biz.ReceivingItems(Common.CurrentDatabase, null, null, listDeleteConsumption);
                    }
                }
                biz.ReceivingItems(Common.CurrentDatabase, null, null, listDelete);



                //== Insert process.
                if (dtAdd != null && dtAdd.Rows.Count > 0)
                {
                    //listAdd = DTOUtility.ConvertDataTableToList<InventoryTransactionDTO>(dtAdd);

                    //ถ้ากรณี receiving ให้แตกเป็น lot ย่อยตาม lot size ให้
                    if (model.RECEIVE_TYPE.StrongValue.Equals(DataDefine.eTRANS_TYPE_string.Receiving))
                    {
                        listAdd = SplitBoxSize(model, DTOUtility.ConvertDataTableToList<InventoryTransactionViewDTO>(dtAdd));
                    }
                    else
                    {
                        listAdd = DTOUtility.ConvertDataTableToList<InventoryTransactionDTO>(dtAdd);
                    }
                    NZString runningNo = null;
                    RunningNumberBIZ runningNumberBIZ = new RunningNumberBIZ();

                    if (model.RECEIVE_NO.IsNull)
                    {
                        runningNo = runningNumberBIZ.GetCompleteRunningNo(DataDefine.RECEIVE_SLIP_NO.ToNZString(), DataDefine.TRANSACTION_TABLE_NAME.ToNZString());
                    }
                    else
                    {
                        runningNo = model.RECEIVE_NO;
                    }

                    List<InventoryTransactionDTO> listAddEachDetail = null;

                    for (int i = 0; i < listAdd.Count; i++)
                    {
                        listAddEachDetail = new List<InventoryTransactionDTO>();

                        InventoryTransactionDTO dto = listAdd[i];

                        // Copy ค่า Header จาก Model ไปยัง DTO แต่ละตัว
                        AssignHeaderToDTO(model, dto);

                        //ถ้า Receive ต้อง check ว่า lot นั้นไม่เคยทำ receive มาก่อน
                        //if (model.RECEIVE_TYPE.StrongValue.Equals(DataDefine.eTRANS_TYPE_string.Receiving))
                        //{
                        //    ValidateException.ThrowErrorItem(receivingValidator.CheckExistReceiveItem(dto.ITEM_CD, dto.LOT_NO));
                        //}
                        //else
                        //{
                        //    ValidateException.ThrowErrorItem(receivingValidator.CheckNotExistReceiveItem(dto.ITEM_CD, dto.LOT_NO));
                        //}

                        //dto.TRANS_ID = runningNumberBIZ.GetCompleteRunningNo(DataDefine.TRANS_ID.ToNZString(), DataDefine.TRANSACTION_TABLE_NAME.ToNZString());
                        dto.SLIP_NO = runningNo;
                        dto.CRT_BY = Common.CurrentUserInfomation.UserCD;
                        dto.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                        dto.UPD_BY = Common.CurrentUserInfomation.UserCD;
                        dto.UPD_MACHINE = Common.CurrentUserInfomation.Machine;

                        // Check all lines.
                        receivingValidator.ValidateBeforeSaveAdd(dto);

                        //add header ใส่ list 
                        listAddEachDetail.Add(dto);
                        #region Do Consumption if Item Process Type is SP and Receive Type is Receiving
                        if (model.RECEIVE_TYPE.StrongValue == DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Receiving))
                        {
                            // load for item process type
                            ItemBIZ bizItem = new ItemBIZ();
                            ItemProcessDTO dtoItem = bizItem.LoadItemProcess(dto.ITEM_CD);
                            //if (dtoItem.ORDER_PROCESS_CLS.StrongValue == DataDefine.ORDER_PROCESS_CLS_SUBCONTACT)
                            //{
                            //    List<InventoryTransactionDTO> dtoConsumptionTr = CreateConsumptionDTO(dto);
                            //    if (dtoConsumptionTr != null && dtoConsumptionTr.Count > 0)
                            //    {
                            //        listAddEachDetail.AddRange(dtoConsumptionTr);

                            //        //for (int j = 0; j < dtoConsumptionTr.Count; j++)
                            //        //{
                            //        //    listAddEachDetail.Add(dtoConsumptionTr[j]);
                            //        //}
                            //    }

                            //}
                        }
                        #endregion

                        biz.ReceivingItems(Common.CurrentDatabase, listAddEachDetail, null, null);

                    }
                }

                //== Update process.
                if (dtModify != null && dtModify.Rows.Count > 0)
                {
                    listUpdate = DTOUtility.ConvertDataTableToList<InventoryTransactionDTO>(dtModify);


                    List<InventoryTransactionDTO> listUpdateDetail = null;
                    List<InventoryTransactionDTO> listAddConsumption = null;
                    List<InventoryTransactionDTO> listDeleteConsumption = null;

                    for (int i = 0; i < listUpdate.Count; i++)
                    {
                        listUpdateDetail = new List<InventoryTransactionDTO>();
                        listAddConsumption = new List<InventoryTransactionDTO>();
                        listDeleteConsumption = new List<InventoryTransactionDTO>();

                        InventoryTransactionDTO dto = listUpdate[i];

                        // Copy ค่า Header จาก Model ไปยัง DTO แต่ละตัว
                        AssignHeaderToDTO(model, dto);

                        dto.CRT_BY = Common.CurrentUserInfomation.UserCD;
                        dto.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                        dto.UPD_BY = Common.CurrentUserInfomation.UserCD;
                        dto.UPD_MACHINE = Common.CurrentUserInfomation.Machine;

                        // Check all lines.
                        receivingValidator.ValidateBeforeSaveAdd(dto);


                        //Clear consumption เดิมก่อน
                        listDeleteConsumption = bizTrans.LoadConsumptionItemByRefNo(dto.REF_NO);
                        biz.ReceivingItems(Common.CurrentDatabase, null, null, listDeleteConsumption);

                        //add header ใส่ list
                        listUpdateDetail.Add(dto);

                        #region Do Consumption if Item Process Type is SP
                        if (model.RECEIVE_TYPE.StrongValue == DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Receiving))
                        {
                            // load for item process type
                            ItemBIZ bizItem = new ItemBIZ();
                            ItemProcessDTO dtoItem = bizItem.LoadItemProcess(dto.ITEM_CD);
                            //if (dtoItem.ORDER_PROCESS_CLS.StrongValue == DataDefine.ORDER_PROCESS_CLS_SUBCONTACT)
                            //{
                            //    List<InventoryTransactionDTO> dtoConsumptionTr = CreateConsumptionDTO(dto);
                            //    if (dtoConsumptionTr != null && dtoConsumptionTr.Count > 0)
                            //    {
                            //        listAddConsumption.AddRange(dtoConsumptionTr);
                            //        //for (int j = 0; j < dtoConsumptionTr.Count; j++)
                            //        //{
                            //        //    listConsumption.Add(dtoConsumptionTr[j]);
                            //        //}
                            //    }
                            //}
                        }
                        #endregion


                        biz.ReceivingItems(Common.CurrentDatabase, listAddConsumption, listUpdateDetail, null);

                    }
                }


                //ปรับให้ไปสั่ง add delete แต่ละตัวไป เพราะว่ากรณีที่ตัด consumption 
                //จะมีโอกาสข้าม lot  ถ้าคำนวณ โดยไม่ตัด mat ก่อน มันจะตัด lot เดิมตลอด
                //biz.ReceivingItems(Common.CurrentDatabase, listAdd, listUpdate, listDelete, listConsumption);
                //biz.ReceivingItems(Common.CurrentDatabase, null, listUpdate, null, null);



                //Update Header for Edit Case
                if (Mode == Common.eScreenMode.EDIT && dtData != null && dtData.Rows.Count > 0)
                {
                    listUpdate = DTOUtility.ConvertDataTableToList<InventoryTransactionDTO>(dtData);

                    for (int i = 0; i < listUpdate.Count; i++)
                    {
                        InventoryTransactionDTO dto = listUpdate[i];

                        // Copy ค่า Header จาก Model ไปยัง DTO แต่ละตัว
                        AssignHeaderToDTO(model, dto);

                        dto.CRT_BY = Common.CurrentUserInfomation.UserCD;
                        dto.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                        dto.UPD_BY = Common.CurrentUserInfomation.UserCD;
                        dto.UPD_MACHINE = Common.CurrentUserInfomation.Machine;

                        biz.UpdateReceiveHeader(Common.CurrentDatabase, dto);
                    }
                }

                Common.CurrentDatabase.Commit();
            }
            catch (Exception)
            {
                Common.CurrentDatabase.Rollback();
                throw;
            }
        }

        private List<InventoryTransactionDTO> SplitBoxSize(ReceivingEntryUIDM receivingModel
                , List<InventoryTransactionViewDTO> argReceivingList)
        {

            List<InventoryTransactionDTO> listSplitBox = new List<InventoryTransactionDTO>();

            RunningNumberBIZ runningNoBiz = new RunningNumberBIZ();
            NZString strLotNoPrefix = runningNoBiz.GenerateLotNoPrefix(new NZDateTime(null, receivingModel.RECEIVE_DATE.StrongValue));

            Dictionary<string, NZInt> dictLastRunningNo = new Dictionary<string, NZInt>();
            NZInt iLastRunningNo = new NZInt();

            InventoryTransactionDTO transDTO = null;
            foreach (InventoryTransactionViewDTO receivingDTO in argReceivingList)
            {
                iLastRunningNo = new NZInt(null, 0);

                //lot size == 0 ไม่ต้องแตก lot
                if ((receivingDTO.LOT_CONTROL_CLS != DataDefine.Convert2ClassCode(DataDefine.eLOT_CONTROL_CLS.Yes))
                    || (receivingDTO.LOT_SIZE.NVL(0) <= 0)
                    )
                {
                    transDTO = new InventoryTransactionDTO();

                    transDTO.ITEM_CD = receivingDTO.ITEM_CD;
                    transDTO.LOT_NO = receivingDTO.LOT_NO;
                    transDTO.PRICE = receivingDTO.PRICE;
                    transDTO.QTY = receivingDTO.QTY;
                    transDTO.EXTERNAL_LOT_NO = receivingDTO.EXTERNAL_LOT_NO;


                    listSplitBox.Add(transDTO);
                }
                else
                {
                    int iTotalBox = (int)Math.Ceiling(receivingDTO.QTY.NVL(0) / receivingDTO.LOT_SIZE.NVL(1));

                    if (dictLastRunningNo.ContainsKey(receivingDTO.ITEM_CD.StrongValue))
                    {
                        iLastRunningNo = dictLastRunningNo[receivingDTO.ITEM_CD.StrongValue];
                    }
                    else
                    {
                        iLastRunningNo = runningNoBiz.GetLastLotNoRunningBox(strLotNoPrefix, receivingModel.STORED_LOC, receivingDTO.ITEM_CD, new NZInt(null, 0));
                        dictLastRunningNo.Add(receivingDTO.ITEM_CD.StrongValue, iLastRunningNo);
                    }

                    NZDecimal dRemainQty = new NZDecimal(null, receivingDTO.QTY.StrongValue);
                    for (int iBox = 0; iBox < iTotalBox; iBox++)
                    {
                        transDTO = new InventoryTransactionDTO();

                        transDTO.ITEM_CD = receivingDTO.ITEM_CD;
                        transDTO.LOT_NO = GenerateLotNo(strLotNoPrefix, ref iLastRunningNo);
                        transDTO.PRICE = receivingDTO.PRICE;
                        transDTO.EXTERNAL_LOT_NO = receivingDTO.EXTERNAL_LOT_NO;

                        if (dRemainQty.NVL(0) >= receivingDTO.LOT_SIZE.NVL(0))
                        {
                            transDTO.QTY = new NZDecimal(null, receivingDTO.LOT_SIZE.StrongValue);
                            dRemainQty.Value = dRemainQty.StrongValue - transDTO.QTY.StrongValue;
                        }
                        else
                        {
                            transDTO.QTY = new NZDecimal(null, dRemainQty.StrongValue);
                        }



                        listSplitBox.Add(transDTO);
                    }
                }
            }

            return listSplitBox;
        }

        public NZString GenerateLotNo(NZString LotNoPrefix, ref NZInt LastRunningNo)
        {
            LastRunningNo.Value = LastRunningNo.StrongValue + 1;
            string strFinalLotNo = LotNoPrefix.ToString() + LastRunningNo.StrongValue.ToString("00");
            return new NZString(null, strFinalLotNo);
        }

        private List<InventoryTransactionDTO> CreateConsumptionDTO(InventoryTransactionDTO dto)
        {
            List<InventoryTransactionDTO> dtoConList = new List<InventoryTransactionDTO>();
            InventoryTransactionDTO dtoCon;

            InventoryBIZ biz = new InventoryBIZ();

            // GET LOCATION INFORMATION
            DealingBIZ bizLoc = new DealingBIZ();
            DealingDTO dtoLoc = bizLoc.LoadLocation(dto.DEALING_NO);
            bool AllowNegative = dtoLoc.ALLOW_NEGATIVE.StrongValue == "01";

            //WorkResultController ctrlWR=new WorkResultController ();
            List<WorkResultEntryViewDTO> dtoChildItem = biz.LoadConsumptionListFromItemCode(dto.ITEM_CD, dto.DEALING_NO, dto.QTY);
            for (int j = 0; j < dtoChildItem.Count; j++)
            {
                // GET CONSUMPTION ITEM FROM FIFO PROCESS WRITE BY KIMMIK.
                List<ActualOnhandViewDTO> dtoListActOnhand = biz.FifoListingProcess(Common.CurrentDatabase
                    , dtoChildItem[j].ITEM_CD.StrongValue, dtoChildItem[j].LOC_CD.StrongValue, dtoChildItem[j].CONSUMPTION_QTY.StrongValue
                    , !AllowNegative, AllowNegative);
                if (dtoListActOnhand != null && dtoListActOnhand.Count > 0)
                {
                    for (int i = 0; i < dtoListActOnhand.Count; i++)
                    {
                        dtoCon = new InventoryTransactionDTO();
                        dtoCon.ITEM_CD = dtoListActOnhand[i].ITEM_CD;
                        dtoCon.LOC_CD = dtoListActOnhand[i].LOC_CD;
                        dtoCon.LOT_NO = dtoListActOnhand[i].LOT_NO;
                        dtoCon.DEALING_NO = dto.DEALING_NO;
                        dtoCon.TRANS_DATE = dto.TRANS_DATE;
                        dtoCon.TRANS_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Consumption);
                        dtoCon.IN_OUT_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.Out);
                        dtoCon.QTY = dtoListActOnhand[i].ONHAND_QTY;
                        dtoCon.OBJ_ORDER_QTY = dto.QTY;
                        dtoCon.OBJ_ITEM_CD = dto.ITEM_CD;
                        dtoCon.REMARK = dto.REMARK;
                        dtoCon.CRT_BY = Common.CurrentUserInfomation.UserCD;
                        dtoCon.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                        dtoCon.UPD_BY = Common.CurrentUserInfomation.UserCD;
                        dtoCon.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
                        dtoCon.SCREEN_TYPE = DataDefine.ScreenType.ReceivingEntry.ToNZString();
                        dtoCon.REF_NO = dto.REF_NO;

                        dtoConList.Add(dtoCon);
                    }
                }
            }



            return dtoConList;
        }
    }
}
