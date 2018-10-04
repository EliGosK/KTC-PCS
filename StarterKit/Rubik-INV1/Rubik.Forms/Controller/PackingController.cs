using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rubik.UIDataModel;
using Rubik.Validators;
using EVOFramework;
using Rubik.DTO;
using Rubik.BIZ;
using System.Data;
using CommonLib;
using EVOFramework.Data;

namespace Rubik.Controller
{
    public class PackingController
    {
        public DataTable LoadPackingList(NZDateTime DateBegin, NZDateTime DateEnd)
        {
            InventoryTransBIZ biz = new InventoryTransBIZ();
            return biz.LoadPackingList(DateBegin, DateEnd, false);
        }

        public PackingEntryUIDM LoadPackingByPackingNo(NZString PackingNo)
        {
            PackingEntryUIDM model = new PackingEntryUIDM();

            InventoryTransBIZ biz = new InventoryTransBIZ();
            PackingEntryDTO dto = biz.LoadPackingByPackingNo(PackingNo);
            if (dto == null)
                return null;

            model.TRANS_ID = dto.TRANS_ID;
            model.PACKING_NO = dto.PACKING_NO;
            model.PACKING_DATE = dto.PACKING_DATE;
            model.SHIFT_CLS = dto.SHIFT_CLS;
            model.MASTER_NO = dto.MASTER_NO;
            model.PART_NO = dto.PART_NO;
            model.CUSTOMER_NAME = dto.CUSTOMER_NAME;
            model.PACK_NO = dto.PACK_NO;
            model.PERSON_IN_CHARGE = dto.PERSON_IN_CHARGE;
            model.TOTAL_QTY = dto.TOTAL_QTY;
            model.REMARK = dto.REMARK;
            model.SOURCE_LOC = dto.SOURCE_LOC;
            model.DEST_LOC = dto.DEST_LOC;
            model.FG_NO = dto.FG_NO;

            DataTable dt = biz.LoadPackingLotByPackingNo(PackingNo);
            model.DATA_VIEW = dt;

            return model;
        }

        public DataTable LoadPackingList(NZString MasterNo,NZString LocCD,NZString LotNo)
        {
           

            InventoryTransBIZ biz = new InventoryTransBIZ();
            DataTable dt = biz.LoadPackingList(MasterNo, LocCD, LotNo);

            return dt;
        }

        public void SaveNewPacking(PackingEntryUIDM data, int NumberOfBox)
        {
            try
            {
                #region Validate

                ItemValidator itemValidator = new ItemValidator();
                ValidateException.ThrowErrorItem(itemValidator.CheckEmptyItemCode(data.MASTER_NO));

                BusinessException businessException = itemValidator.CheckItemNotExist(data.MASTER_NO);
                if (businessException != null)
                    ValidateException.ThrowErrorItem(businessException.Error);

                #endregion

                InventoryBIZ biz = new InventoryBIZ();

                SysConfigBIZ sysBiz = new SysConfigBIZ();
                SysConfigDTO defaultSourceLoc = sysBiz.LoadByPK(DataDefine.eSYSTEM_CONFIG.TRN320.SYS_GROUP_ID, (NZString)DataDefine.eSYSTEM_CONFIG.TRN320.SYS_KEY.SOURCE_LOC.ToString());
                SysConfigDTO defaultDestinationLoc = sysBiz.LoadByPK(DataDefine.eSYSTEM_CONFIG.TRN320.SYS_GROUP_ID, (NZString)DataDefine.eSYSTEM_CONFIG.TRN320.SYS_KEY.DEST_LOC.ToString());

                InventoryTransactionDTO Source = new InventoryTransactionDTO();
                List<InventoryTransactionDTO> DestinationList = new List<InventoryTransactionDTO>();

                #region Destination

                foreach (DataRow dr in data.DATA_VIEW.Rows)
                {

                    InventoryTransactionDTO dto = new InventoryTransactionDTO();
                    dto.CRT_BY = Common.CurrentUserInfomation.UserCD;
                    //dto.CRT_DATE
                    dto.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                    dto.UPD_BY = Common.CurrentUserInfomation.UserCD;
                    //dto.UPD_DATE
                    dto.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
                    //dto.TRANS_ID
                    dto.ITEM_CD = data.MASTER_NO;
                    dto.LOC_CD = defaultDestinationLoc.CHAR_DATA;
                    dto.LOT_NO = new NZString(null, dr[(int)PackingEntryUIDM.eColView.LOT_NO]);
                    dto.FG_NO = data.FG_NO;
                    dto.PACK_NO = data.PACK_NO;
                    dto.EXTERNAL_LOT_NO = new NZString(null, dr[(int)PackingEntryUIDM.eColView.EXTERNAL_LOT_NO]);
                    dto.TRANS_DATE = data.PACKING_DATE;
                    dto.TRANS_CLS = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Packing).ToNZString();
                    dto.IN_OUT_CLS = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.In).ToNZString();
                    dto.FG_NO = data.FG_NO;

                    if (dr[(int)PackingEntryUIDM.eColView.QTY] == null
                        || dr[(int)PackingEntryUIDM.eColView.QTY] == (object)DBNull.Value)
                    {
                        dto.QTY = new NZDecimal(null, 0);
                    }
                    else
                    {
                        dto.QTY = new NZDecimal(null, dr[(int)PackingEntryUIDM.eColView.QTY]);
                    }

                    //dto.WEIGHT
                    //dto.OBJ_ITEM_CD
                    //dto.OBJ_ORDER_QTY
                    //dto.REF_NO
                    //dto.REF_SLIP_NO
                    //dto.REF_SLIP_CLS
                    //dto.OTHER_DL_NO
                    //dto.SLIP_NO
                    dto.REMARK = data.REMARK;
                    //dto.DEALING_NO
                    //dto.PRICE
                    //dto.AMOUNT
                    //dto.FOR_CUSTOMER
                    //dto.FOR_MACHINE
                    dto.SHIFT_CLS = data.SHIFT_CLS;
                    //dto.REF_SLIP_NO2
                    //dto.NG_QTY
                    //dto.NG_WEIGHT
                    //dto.TRAN_SUB_CLS = 
                    dto.SCREEN_TYPE = DataDefine.ScreenType.PackingEntry.ToNZString();
                    //dto.GROUP_TRANS_ID
                    //dto.RESERVE_QTY
                    //dto.RETURN_QTY
                    //dto.NG_REASON
                    dto.EFFECT_STOCK = new NZInt(null, (int)DataDefine.eEFFECT_STOCK.In);
                    //dto.LOT_REMARK
                    dto.PERSON_IN_CHARGE = data.PERSON_IN_CHARGE;
                    //dto.CURRENCY
                    //dto.REWORK_FLAG
                    dto.OLD_DATA = new NZInt(null, 0);
                    //dto.TIME_STAMP

                    DestinationList.Add(dto);
                }

                #endregion

                #region Pack

                Source.CRT_BY = Common.CurrentUserInfomation.UserCD;
                //Source.CRT_DATE
                Source.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                Source.UPD_BY = Common.CurrentUserInfomation.UserCD;
                //Source.UPD_DATE
                Source.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
                //Source.TRANS_ID
                Source.ITEM_CD = data.MASTER_NO;
                Source.LOC_CD = defaultSourceLoc.CHAR_DATA;
                //Source.LOT_NO 
                Source.FG_NO = data.FG_NO;
                Source.PACK_NO = data.PACK_NO;
                //Source.EXTERNAL_LOT_NO
                Source.TRANS_DATE = data.PACKING_DATE;
                Source.TRANS_CLS = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Packing_Consumption).ToNZString();
                Source.IN_OUT_CLS = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.Out).ToNZString();
                Source.QTY = data.TOTAL_QTY;
                //Source.WEIGHT
                //Source.OBJ_ITEM_CD
                //Source.OBJ_ORDER_QTY
                //Source.REF_NO
                //Source.REF_SLIP_NO
                //Source.REF_SLIP_CLS
                //Source.OTHER_DL_NO
                //Source.SLIP_NO
                Source.REMARK = data.REMARK;
                //Source.DEALING_NO
                //Source.PRICE
                //Source.AMOUNT
                //Source.FOR_CUSTOMER
                //Source.FOR_MACHINE
                Source.SHIFT_CLS = data.SHIFT_CLS;
                //Source.REF_SLIP_NO2
                //Source.NG_QTY
                //Source.NG_WEIGHT
                //Source.TRAN_SUB_CLS = 
                Source.SCREEN_TYPE = DataDefine.ScreenType.PackingEntry.ToNZString();
                //Source.GROUP_TRANS_ID
                //Source.RESERVE_QTY
                //Source.RETURN_QTY
                //Source.NG_REASON
                Source.EFFECT_STOCK = new NZInt(null, (int)DataDefine.eEFFECT_STOCK.Out);
                //Source.LOT_REMARK
                Source.PERSON_IN_CHARGE = data.PERSON_IN_CHARGE;
                //Source.CURRENCY
                //Source.REWORK_FLAG
                Source.OLD_DATA = new NZInt(null, 0);
                //Source.TIME_STAMP

                #endregion

                biz.AddPacking(DestinationList, Source, NumberOfBox);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SaveUpdatePacking(PackingEntryUIDM data)
        {
            try
            {
                #region Validate

                ItemValidator itemValidator = new ItemValidator();
                ValidateException.ThrowErrorItem(itemValidator.CheckEmptyItemCode(data.MASTER_NO));

                BusinessException businessException = itemValidator.CheckItemNotExist(data.MASTER_NO);
                if (businessException != null)
                    ValidateException.ThrowErrorItem(businessException.Error);

                #endregion

                InventoryBIZ biz = new InventoryBIZ();
                InventoryTransBIZ bizInvTrans = new InventoryTransBIZ();

                //SysConfigBIZ sysBiz = new SysConfigBIZ();
                //SysConfigDTO defaultSourceLoc = sysBiz.LoadByPK(DataDefine.eSYSTEM_CONFIG.TRN320.SYS_GROUP_ID, (NZString)DataDefine.eSYSTEM_CONFIG.TRN320.SYS_KEY.SOURCE_LOC.ToString());
                //SysConfigDTO defaultDestinationLoc = sysBiz.LoadByPK(DataDefine.eSYSTEM_CONFIG.TRN320.SYS_GROUP_ID, (NZString)DataDefine.eSYSTEM_CONFIG.TRN320.SYS_KEY.DEST_LOC.ToString());

                InventoryTransactionDTO Source = null;
                List<InventoryTransactionDTO> NewLotList = null;
                List<InventoryTransactionDTO> ModifyLotList = null;
                List<InventoryTransactionDTO> DeleteLotList = null;

                DataTable dt = data.DATA_VIEW;                

                DataTable dtNew = dt.GetChanges(DataRowState.Added);                
                DataTable dtDelete = dt.GetChanges(DataRowState.Deleted);
                DataTable dtModify = dt.GetChanges(DataRowState.Modified);
                
                ModifyLotList = new List<InventoryTransactionDTO>();

                #region Pack

                Source = bizInvTrans.LoadByTransactionID(data.TRANS_ID);

                //Source.CRT_BY = Common.CurrentUserInfomation.UserCD;
                //Source.CRT_DATE
                //Source.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                Source.UPD_BY = Common.CurrentUserInfomation.UserCD;
                //Source.UPD_DATE
                Source.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
                //Source.TRANS_ID
                //Source.ITEM_CD = data.MASTER_NO;
                //Source.LOC_CD = data.SOURCE_LOC;
                //Source.LOT_NO 
                Source.FG_NO = data.FG_NO;
                //Source.PACK_NO = data.PACK_NO;
                //Source.EXTERNAL_LOT_NO
                //Source.TRANS_DATE = data.PACKING_DATE;
                //Source.TRANS_CLS = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Packing_Consumption).ToNZString();
                //Source.IN_OUT_CLS = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.Out).ToNZString();
                Source.QTY = data.TOTAL_QTY;
                //Source.WEIGHT
                //Source.OBJ_ITEM_CD
                //Source.OBJ_ORDER_QTY
                //Source.REF_NO
                //Source.REF_SLIP_NO
                //Source.REF_SLIP_CLS
                //Source.OTHER_DL_NO
                //Source.SLIP_NO
                Source.REMARK = data.REMARK;
                //Source.DEALING_NO
                //Source.PRICE
                //Source.AMOUNT
                //Source.FOR_CUSTOMER
                //Source.FOR_MACHINE
                Source.SHIFT_CLS = data.SHIFT_CLS;
                //Source.REF_SLIP_NO2
                //Source.NG_QTY
                //Source.NG_WEIGHT
                //Source.TRAN_SUB_CLS = 
                Source.SCREEN_TYPE = DataDefine.ScreenType.PackingEntry.ToNZString();
                //Source.GROUP_TRANS_ID
                //Source.RESERVE_QTY
                //Source.RETURN_QTY
                //Source.NG_REASON
                Source.EFFECT_STOCK = new NZInt(null, (int)DataDefine.eEFFECT_STOCK.Out);
                //Source.LOT_REMARK
                Source.PERSON_IN_CHARGE = data.PERSON_IN_CHARGE;
                //Source.CURRENCY
                //Source.REWORK_FLAG
                Source.OLD_DATA = new NZInt(null, 0);
                //Source.TIME_STAMP

                ModifyLotList.Add(Source);
                #endregion

                #region Destination : Modify Record

                if (dtModify != null)
                {
                    foreach (DataRow dr in dtModify.Rows)
                    {
                        InventoryTransactionDTO dto = bizInvTrans.LoadByTransactionID(new NZString(null, dr[(int)PackingEntryUIDM.eColView.TRANS_ID]));
                        //dto.CRT_BY = Common.CurrentUserInfomation.UserCD;
                        //dto.CRT_DATE
                        //dto.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                        dto.UPD_BY = Common.CurrentUserInfomation.UserCD;
                        //dto.UPD_DATE
                        dto.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
                        //dto.TRANS_ID
                        //dto.ITEM_CD = data.MASTER_NO;
                        //dto.LOC_CD = defaultDestinationLoc.CHAR_DATA;
                        //dto.LOT_NO = new NZString(null, dr[(int)PackingEntryUIDM.eColView.LOT_NO]);
                        dto.FG_NO = data.FG_NO;
                        //dto.PACK_NO = data.PACK_NO;
                        dto.EXTERNAL_LOT_NO = new NZString(null, dr[(int)PackingEntryUIDM.eColView.EXTERNAL_LOT_NO]);
                        //dto.TRANS_DATE = data.PACKING_DATE;
                        //dto.TRANS_CLS = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Packing).ToNZString();
                        //dto.IN_OUT_CLS = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.In).ToNZString();

                        if (dr[(int)PackingEntryUIDM.eColView.QTY] == null
                            || dr[(int)PackingEntryUIDM.eColView.QTY] == (object)DBNull.Value)
                        {
                            dto.QTY = new NZDecimal(null, 0);
                        }
                        else
                        {
                            dto.QTY = new NZDecimal(null, dr[(int)PackingEntryUIDM.eColView.QTY]);
                        }

                        //dto.WEIGHT
                        //dto.OBJ_ITEM_CD
                        //dto.OBJ_ORDER_QTY
                        //dto.REF_NO
                        //dto.REF_SLIP_NO
                        //dto.REF_SLIP_CLS
                        //dto.OTHER_DL_NO
                        //dto.SLIP_NO
                        dto.REMARK = data.REMARK;
                        //dto.DEALING_NO
                        //dto.PRICE
                        //dto.AMOUNT
                        //dto.FOR_CUSTOMER
                        //dto.FOR_MACHINE
                        dto.SHIFT_CLS = data.SHIFT_CLS;
                        //dto.REF_SLIP_NO2
                        //dto.NG_QTY
                        //dto.NG_WEIGHT
                        //dto.TRAN_SUB_CLS = 
                        dto.SCREEN_TYPE = DataDefine.ScreenType.PackingEntry.ToNZString();
                        //dto.GROUP_TRANS_ID
                        //dto.RESERVE_QTY
                        //dto.RETURN_QTY
                        //dto.NG_REASON
                        dto.EFFECT_STOCK = new NZInt(null, (int)DataDefine.eEFFECT_STOCK.In);
                        //dto.LOT_REMARK
                        dto.PERSON_IN_CHARGE = data.PERSON_IN_CHARGE;
                        //dto.CURRENCY
                        //dto.REWORK_FLAG
                        dto.OLD_DATA = new NZInt(null, 0);
                        //dto.TIME_STAMP

                        ModifyLotList.Add(dto);
                    }
                }

                #endregion

                #region Destination : New Record

                if (dtNew != null)
                {
                    NewLotList = new List<InventoryTransactionDTO>();

                    foreach (DataRow dr in dtNew.Rows)
                    {
                        InventoryTransactionDTO dto = new InventoryTransactionDTO();
                        dto.CRT_BY = Common.CurrentUserInfomation.UserCD;
                        //dto.CRT_DATE
                        dto.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                        dto.UPD_BY = Common.CurrentUserInfomation.UserCD;
                        //dto.UPD_DATE
                        dto.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
                        //dto.TRANS_ID
                        dto.ITEM_CD = data.MASTER_NO;
                        dto.LOC_CD = data.DEST_LOC;
                        dto.LOT_NO = new NZString(null, dr[(int)PackingEntryUIDM.eColView.LOT_NO]);
                        dto.FG_NO = data.FG_NO;
                        dto.PACK_NO = data.PACK_NO;
                        dto.EXTERNAL_LOT_NO = new NZString(null, dr[(int)PackingEntryUIDM.eColView.EXTERNAL_LOT_NO]);
                        dto.TRANS_DATE = data.PACKING_DATE;
                        dto.TRANS_CLS = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Packing).ToNZString();
                        dto.IN_OUT_CLS = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.In).ToNZString();

                        if (dr[(int)PackingEntryUIDM.eColView.QTY] == null
                            || dr[(int)PackingEntryUIDM.eColView.QTY] == (object)DBNull.Value)
                        {
                            dto.QTY = new NZDecimal(null, 0);
                        }
                        else
                        {
                            dto.QTY = new NZDecimal(null, dr[(int)PackingEntryUIDM.eColView.QTY]);
                        }

                        //dto.WEIGHT
                        //dto.OBJ_ITEM_CD
                        //dto.OBJ_ORDER_QTY
                        //dto.REF_NO
                        //dto.REF_SLIP_NO
                        //dto.REF_SLIP_CLS
                        //dto.OTHER_DL_NO
                        dto.SLIP_NO = data.PACKING_NO;
                        dto.REMARK = data.REMARK;
                        //dto.DEALING_NO
                        //dto.PRICE
                        //dto.AMOUNT
                        //dto.FOR_CUSTOMER
                        //dto.FOR_MACHINE
                        dto.SHIFT_CLS = data.SHIFT_CLS;
                        //dto.REF_SLIP_NO2
                        //dto.NG_QTY
                        //dto.NG_WEIGHT
                        //dto.TRAN_SUB_CLS = 
                        dto.SCREEN_TYPE = DataDefine.ScreenType.PackingEntry.ToNZString();
                        dto.GROUP_TRANS_ID = Source.GROUP_TRANS_ID;
                        //dto.RESERVE_QTY
                        //dto.RETURN_QTY
                        //dto.NG_REASON
                        dto.EFFECT_STOCK = new NZInt(null, (int)DataDefine.eEFFECT_STOCK.In);
                        //dto.LOT_REMARK
                        dto.PERSON_IN_CHARGE = data.PERSON_IN_CHARGE;
                        //dto.CURRENCY
                        //dto.REWORK_FLAG
                        dto.OLD_DATA = new NZInt(null, 0);
                        //dto.TIME_STAMP

                        NewLotList.Add(dto);
                    }
                }
                #endregion

                #region Destination : Delete Record

                if (dtDelete != null)
                {
                    DeleteLotList = new List<InventoryTransactionDTO>();

                    List<InventoryTransactionDTO> listDelete = DTOUtility.ConvertDataTableToList<InventoryTransactionDTO>(dtDelete);

                    foreach (InventoryTransactionDTO dtoDelete in listDelete)
                    {
                        if (dtoDelete.TRANS_ID == null || dtoDelete.TRANS_ID == (object)DBNull.Value)
                            continue;

                        InventoryTransactionDTO dto = bizInvTrans.LoadByTransactionID(new NZString(null, dtoDelete.TRANS_ID));

                        DeleteLotList.Add(dto);
                    }
                }

                #endregion

                biz.UpdatePacking(NewLotList, ModifyLotList, DeleteLotList);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteTransaction(NZString TransID,NZString GroupTransID)
        {
            try
            {
                Common.CurrentDatabase.KeepConnection = true;
                Common.CurrentDatabase.BeginTransaction(IsolationLevel.Serializable);

                InventoryBIZ biz = new InventoryBIZ();
                InventoryTransBIZ bizInvTrans = new InventoryTransBIZ();
                
                InventoryTransactionDTO dtoConsumption = null;

                biz.DeleteInventoryTransaction(Common.CurrentDatabase, TransID);

                decimal decTotalQty = 0;
                List<InventoryTransactionDTO> List = bizInvTrans.LoadGroupTransaction(GroupTransID);

                if (List.Count == 1)  //Remain Only Consumption Record
                {
                    dtoConsumption = List[0];

                    biz.DeleteInventoryTransaction(Common.CurrentDatabase, dtoConsumption.TRANS_ID);
                }
                else 
                {
                    //Remain Lot and Consumption Record

                    List<InventoryTransactionDTO> UpdateList = new List<InventoryTransactionDTO>();

                    foreach (InventoryTransactionDTO dto in List) 
                    {
                        if (DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Packing_Consumption).Equals(dto.TRANS_CLS.StrongValue) ||
                            DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Unpack).Equals(dto.TRANS_CLS.StrongValue)
                            ) 
                        {
                            dtoConsumption = dto;
                        }
                        else {
                            decTotalQty = decTotalQty + dto.QTY.StrongValue;
                        }
                    }

                    dtoConsumption.UPD_BY = Common.CurrentUserInfomation.UserCD;
                    dtoConsumption.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
                    dtoConsumption.QTY = new NZDecimal(null, decTotalQty);
                    UpdateList.Add(dtoConsumption);

                    biz.UpdateInventoryTransactions(Common.CurrentDatabase, UpdateList);
                }

                Common.CurrentDatabase.Commit();
            }
            catch (BusinessException) 
            {
                CommonLib.Common.CurrentDatabase.Rollback();
                throw;
            }
            catch (ValidateException) 
            {
                CommonLib.Common.CurrentDatabase.Rollback();
                throw;
            }
            catch (Exception) 
            {
                CommonLib.Common.CurrentDatabase.Rollback();
                throw;
            }
        }

        public void DeleteGroupTransaction(NZString TransID)
        {
            try
            {
                InventoryBIZ biz = new InventoryBIZ();
                biz.DeleteGroupTransaction(TransID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SaveNewUnPacking(UnPackingEntryUIDM data)
        {
            try
            {
                #region Validate

                ItemValidator itemValidator = new ItemValidator();
                ValidateException.ThrowErrorItem(itemValidator.CheckEmptyItemCode(data.ITEM_CD));

                BusinessException businessException = itemValidator.CheckItemNotExist(data.ITEM_CD);
                if (businessException != null)
                    ValidateException.ThrowErrorItem(businessException.Error);

                #endregion

                InventoryBIZ biz = new InventoryBIZ();

                SysConfigBIZ sysBiz = new SysConfigBIZ();
                SysConfigDTO defaultSourceLoc = sysBiz.LoadByPK(DataDefine.eSYSTEM_CONFIG.TRN330.SYS_GROUP_ID, (NZString)DataDefine.eSYSTEM_CONFIG.TRN330.SYS_KEY.SOURCE_LOC.ToString());
                SysConfigDTO defaultDestinationLoc = sysBiz.LoadByPK(DataDefine.eSYSTEM_CONFIG.TRN330.SYS_GROUP_ID, (NZString)DataDefine.eSYSTEM_CONFIG.TRN330.SYS_KEY.DEST_LOC.ToString());

                List<InventoryTransactionDTO> SourceList = new List<InventoryTransactionDTO>();
                InventoryTransactionDTO Destination = new InventoryTransactionDTO();

                #region source
                data.TOTAL_QTY = new NZDecimal(null, 0);
                foreach (DataRow dr in data.DATA_VIEW.Rows)
                {
                    InventoryTransactionDTO dto = new InventoryTransactionDTO();
                    dto.CRT_BY = Common.CurrentUserInfomation.UserCD;
                    dto.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                    dto.UPD_BY = Common.CurrentUserInfomation.UserCD;
                    dto.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
                    dto.ITEM_CD = data.ITEM_CD;
                    dto.LOC_CD = defaultSourceLoc.CHAR_DATA;
                    dto.PACK_NO = new NZString(null, dr[(int)UnPackingEntryUIDM.eColView.PACK_NO]);
                    dto.FG_NO = new NZString(null, dr[(int)UnPackingEntryUIDM.eColView.FG_NO]);
                    dto.LOT_NO = new NZString(null, dr[(int)UnPackingEntryUIDM.eColView.LOT_NO]);
                    dto.EXTERNAL_LOT_NO = new NZString(null, dr[(int)UnPackingEntryUIDM.eColView.EXTERNAL_LOT_NO]);
                    dto.TRANS_DATE = data.UNPACKING_DATE;
                    dto.TRANS_CLS = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Unpack_Consumption).ToNZString();
                    dto.IN_OUT_CLS = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.Out).ToNZString();

                    if (dr[(int)UnPackingEntryUIDM.eColView.ONHAND_QTY] == null
                        || dr[(int)UnPackingEntryUIDM.eColView.ONHAND_QTY] == (object)DBNull.Value)
                    {
                        dto.QTY = new NZDecimal(null, 0);
                    }
                    else
                    {
                        dto.QTY = new NZDecimal(null, dr[(int)UnPackingEntryUIDM.eColView.ONHAND_QTY]);
                        data.TOTAL_QTY += dto.QTY;

                    }

                    dto.REMARK = data.REMARK;
                    dto.SHIFT_CLS = data.SHIFT_CLS;
                    dto.PERSON_IN_CHARGE = data.PERSON_IN_CHARGE;
                    dto.SCREEN_TYPE = DataDefine.ScreenType.UnPackingEntry.ToNZString();
                    dto.EFFECT_STOCK = new NZInt(null, (int)DataDefine.eEFFECT_STOCK.Out);
                    dto.OLD_DATA = new NZInt(null, 0);
                    //dto.TIME_STAMP

                    SourceList.Add(dto);
                }

                #endregion

                #region Destination (Unpack)

                Destination.CRT_BY = Common.CurrentUserInfomation.UserCD;
                Destination.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                Destination.UPD_BY = Common.CurrentUserInfomation.UserCD;
                Destination.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
                Destination.ITEM_CD = data.ITEM_CD;
                Destination.LOC_CD = defaultDestinationLoc.CHAR_DATA;
                Destination.TRANS_DATE = data.UNPACKING_DATE;
                Destination.TRANS_CLS = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Unpack).ToNZString();
                Destination.IN_OUT_CLS = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.In).ToNZString();
                Destination.QTY = data.TOTAL_QTY;
                Destination.REMARK = data.REMARK;
                Destination.SHIFT_CLS = data.SHIFT_CLS;
                Destination.SCREEN_TYPE = DataDefine.ScreenType.UnPackingEntry.ToNZString();
                Destination.EFFECT_STOCK = new NZInt(null, (int)DataDefine.eEFFECT_STOCK.In);
                Destination.PERSON_IN_CHARGE = data.PERSON_IN_CHARGE;
                Destination.OLD_DATA = new NZInt(null, 0);

                #endregion

                biz.AddUnPacking(SourceList, Destination);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
