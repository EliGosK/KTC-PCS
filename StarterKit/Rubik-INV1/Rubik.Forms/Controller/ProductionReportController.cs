using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rubik.DTO;
using EVOFramework;
using Rubik.BIZ;
using CommonLib;
using Rubik.UIDataModel;
using System.Data;
using EVOFramework.Data;
using Rubik.Validators;

namespace Rubik.Controller
{
    internal class ProductionReportController
    {
        public ProductionReportEntryUIDM CreateModel(ProductionReportEntryDTO TransDTO, DataTable NGData)
        {
            ProductionReportEntryUIDM model = new ProductionReportEntryUIDM();

            model.TRANS_ID = TransDTO.TRANS_ID;
            model.REF_NO = TransDTO.REF_NO;
            model.PRODUCTION_REPORT_NO = TransDTO.PRODUCTION_REPORT_NO;
            model.PRODUCTION_REPORT_DATE = TransDTO.PRODUCTION_REPORT_DATE;
            model.SHIFT = TransDTO.SHIFT;
            model.MASTER_NO = TransDTO.MASTER_NO;
            model.PART_NO = TransDTO.PART_NO;
            model.CUSTOMER_NAME = TransDTO.CUSTOMER_NAME;
            model.PROCESS = TransDTO.PROCESS;
            model.MACHINE_NO = TransDTO.MACHINE_NO;
            model.REWORK = TransDTO.REWORK;
            model.LOT_NO = TransDTO.LOT_NO;
            model.CUST_LOT_NO = TransDTO.CUST_LOT_NO;
            model.SUPPLIER = TransDTO.SUPPLIER;
            model.WEIGHT = TransDTO.WEIGHT;
            model.QTY = TransDTO.QTY;
            model.PERSON_IN_CHARGE = TransDTO.PERSON_IN_CHARGE;
            model.REMARK = TransDTO.REMARK;
            model.NG_WEIGHT = TransDTO.NG_WEIGHT;
            model.NG_QTY = TransDTO.NG_QTY;

            model.DataView = NGData;

            return model;
        }

        public List<ProductionReportEntryViewDTO> LoadNGCriteria(NZString Process)
        {
            NGCriteriaBIZ biz = new NGCriteriaBIZ();
            return biz.LoadNGCriteriaByProcess(Common.CurrentDatabase, Process, false);
        }
        public DataTable LoadProductionReportList(NZDateTime DateBegin, NZDateTime DateEnd)
        {
            InventoryTransBIZ biz = new InventoryTransBIZ();
            return biz.LoadProductionReportList(DateBegin, DateEnd, false);
        }

        public ProductionReportEntryUIDM LoadProductionReport(NZString TransID)
        {
            ProductionReportEntryUIDM model = null;
            DataTable dtNG = null;

            InventoryTransBIZ biz = new InventoryTransBIZ();
            ProductionReportEntryDTO dto = biz.LoadProductionReport(TransID);
            if (dto == null)
                return new ProductionReportEntryUIDM();

            dtNG = biz.LoadNGTransaction(dto.TRANS_ID);

            model = CreateModel(dto, dtNG);

            return model;
        }

        public void SaveNewProductionReport(ProductionReportEntryUIDM data)
        {
            try
            {
                ItemValidator itemValidator = new ItemValidator();
                ValidateException.ThrowErrorItem(itemValidator.CheckEmptyItemCode(data.MASTER_NO));

                BusinessException businessException = itemValidator.CheckItemNotExist(data.MASTER_NO);
                if (businessException != null)
                    ValidateException.ThrowErrorItem(businessException.Error);

                InventoryBIZ bizInv = new InventoryBIZ();
                DealingConstraintBIZ bizConstraint = new DealingConstraintBIZ();
                DealingConstraintDTO constriant = bizConstraint.LoadDealingConstraint(data.PROCESS);

                InventoryTransactionDTO dtoInvMainTransIn = new InventoryTransactionDTO();
                InventoryTransactionDTO dtoInvMainTransOut = null;

                #region Main Transaction : for good qty
                dtoInvMainTransIn.CRT_BY = Common.CurrentUserInfomation.UserCD;
                //dtoInvMainTransIn.CRT_DATE = 
                dtoInvMainTransIn.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                dtoInvMainTransIn.UPD_BY = Common.CurrentUserInfomation.UserCD;
                //dtoInvMainTransIn.UPD_DATE =
                dtoInvMainTransIn.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
                //dtoInvMainTransIn.TRANS_ID =
                dtoInvMainTransIn.ITEM_CD = data.MASTER_NO;
                dtoInvMainTransIn.LOC_CD = data.PROCESS;
                //dtoInvMainTransIn.LOT_NO = 
                //dtoInvMainTransIn.PACK_NO = 
                dtoInvMainTransIn.EXTERNAL_LOT_NO = data.CUST_LOT_NO;
                dtoInvMainTransIn.TRANS_DATE = data.PRODUCTION_REPORT_DATE;
                dtoInvMainTransIn.TRANS_CLS = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.WorkResult).ToNZString();
                dtoInvMainTransIn.IN_OUT_CLS = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.In).ToNZString();
                dtoInvMainTransIn.QTY = data.QTY;
                dtoInvMainTransIn.WEIGHT = data.WEIGHT;
                //dtoInvMainTransIn.OBJ_ITEM_CD = 
                //dtoInvMainTransIn.OBJ_ORDER_QTY =
                //dtoInvMainTransIn.REF_NO =
                //dtoInvMainTransIn.REF_SLIP_NO =
                //dtoInvMainTransIn.REF_SLIP_CLS =
                //dtoInvMainTransIn.OTHER_DL_NO =
                //dtoInvMainTransIn.SLIP_NO =
                dtoInvMainTransIn.REMARK = data.REMARK;
                dtoInvMainTransIn.DEALING_NO = data.SUPPLIER;
                //dtoInvMainTransIn.PRICE =
                //dtoInvMainTransIn.AMOUNT =
                //dtoInvMainTransIn.FOR_CUSTOMER =
                dtoInvMainTransIn.FOR_MACHINE = data.MACHINE_NO;
                dtoInvMainTransIn.SHIFT_CLS = data.SHIFT;
                //dtoInvMainTransIn.REF_SLIP_NO2 =
                dtoInvMainTransIn.NG_QTY = data.NG_QTY;
                //dtoInvMainTransIn.NG_WEIGHT =
                //dtoInvMainTransIn.TRAN_SUB_CLS = new NZString(null, data.REWORK.StrongValue);
                dtoInvMainTransIn.TRAN_SUB_CLS = Convert.ToInt32(data.REWORK.StrongValue) == (int)DataDefine.eTRAN_SUB_CLS.RW ?
                                                new NZString(null, DataDefine.eTRAN_SUB_CLS.RW.ToString()) :
                                                new NZString(null, DataDefine.eTRAN_SUB_CLS.WR.ToString());
                dtoInvMainTransIn.REWORK_FLAG = new NZInt(data.REWORK.Owner, Convert.ToInt32(data.REWORK));//(data.REWORK.NVL("WR") == DataDefine.eTRAN_SUB_CLS.RW.ToString() ? 1 : 0).ToNZInt();

                dtoInvMainTransIn.SCREEN_TYPE = DataDefine.ScreenType.WorkResultEntry.ToNZString();
                //dtoInvMainTransIn.GROUP_TRANS_ID =
                //dtoInvMainTransIn.RESERVE_QTY =
                //dtoInvMainTransIn.NG_REASON =
                dtoInvMainTransIn.EFFECT_STOCK = new NZInt(null, (int)DataDefine.eEFFECT_STOCK.In);
                dtoInvMainTransIn.LOT_REMARK = data.LOT_NO;
                dtoInvMainTransIn.PERSON_IN_CHARGE = data.PERSON_IN_CHARGE;
                //dtoInvMainTransIn.CURRENCY = 
                dtoInvMainTransIn.OLD_DATA = new NZInt(null, 0);

                #endregion

                if (constriant == null || constriant.NO_CONSUMPTION_FLAG.StrongValue == 0)
                {
                    dtoInvMainTransOut = new InventoryTransactionDTO();

                    #region Main Transaction for used qty(qty + ng)
                    dtoInvMainTransOut.CRT_BY = Common.CurrentUserInfomation.UserCD;
                    //dtoInvMainTransOut.CRT_DATE = 
                    dtoInvMainTransOut.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                    dtoInvMainTransOut.UPD_BY = Common.CurrentUserInfomation.UserCD;
                    //dtoInvMainTransOut.UPD_DATE =
                    dtoInvMainTransOut.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
                    //dtoInvMainTransOut.TRANS_ID =
                    dtoInvMainTransOut.ITEM_CD = data.MASTER_NO;
                    dtoInvMainTransOut.LOC_CD = data.PROCESS;
                    //dtoInvMainTransOut.LOT_NO = 
                    //dtoInvMainTransOut.PACK_NO = 
                    dtoInvMainTransOut.EXTERNAL_LOT_NO = data.CUST_LOT_NO;
                    dtoInvMainTransOut.TRANS_DATE = data.PRODUCTION_REPORT_DATE;
                    dtoInvMainTransOut.TRANS_CLS = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Consumption).ToNZString();
                    dtoInvMainTransOut.IN_OUT_CLS = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.Out).ToNZString();
                    dtoInvMainTransOut.QTY = new NZDecimal(null, data.QTY.StrongValue + data.NG_QTY.StrongValue);
                    dtoInvMainTransOut.WEIGHT = data.WEIGHT;
                    //dtoInvMainTransOut.OBJ_ITEM_CD = 
                    //dtoInvMainTransOut.OBJ_ORDER_QTY =
                    //dtoInvMainTransOut.REF_NO =
                    //dtoInvMainTransOut.REF_SLIP_NO =
                    //dtoInvMainTransOut.REF_SLIP_CLS =
                    //dtoInvMainTransOut.OTHER_DL_NO =
                    //dtoInvMainTransOut.SLIP_NO =
                    dtoInvMainTransOut.REMARK = data.REMARK;
                    dtoInvMainTransOut.DEALING_NO = data.SUPPLIER;
                    //dtoInvMainTransOut.PRICE =
                    //dtoInvMainTransOut.AMOUNT =
                    //dtoInvMainTransOut.FOR_CUSTOMER =
                    dtoInvMainTransOut.FOR_MACHINE = data.MACHINE_NO;
                    dtoInvMainTransOut.SHIFT_CLS = data.SHIFT;
                    //dtoInvMainTransOut.REF_SLIP_NO2 =
                    //dtoInvMainTransOut.NG_QTY = data.NG_QTY;
                    //dtoInvMainTransOut.NG_WEIGHT =
                    //dtoInvMainTransOut.TRAN_SUB_CLS = new NZString(null, DataDefine.eTRAN_SUB_CLS.WR.ToString());
                    dtoInvMainTransOut.SCREEN_TYPE = DataDefine.ScreenType.WorkResultEntry.ToNZString();
                    //dtoInvMainTransOut.GROUP_TRANS_ID =
                    //dtoInvMainTransOut.RESERVE_QTY =
                    //dtoInvMainTransOut.NG_REASON =
                    dtoInvMainTransOut.EFFECT_STOCK = new NZInt(null, (int)DataDefine.eEFFECT_STOCK.Out);
                    dtoInvMainTransOut.LOT_REMARK = data.LOT_NO;
                    dtoInvMainTransOut.PERSON_IN_CHARGE = data.PERSON_IN_CHARGE;
                    //dtoInvMainTransOut.CURRENCY = 
                    dtoInvMainTransOut.OLD_DATA = new NZInt(null, 0);

                    #endregion
                }

                #region NG Transaction

                List<InventoryTransactionDTO> listNG = new List<InventoryTransactionDTO>();

                DataTable dtData = data.DataView;
                foreach (DataRow dr in dtData.Rows)
                {
                    InventoryTransactionDTO dtoNG = new InventoryTransactionDTO();
                    dtoNG.CRT_BY = Common.CurrentUserInfomation.UserCD;
                    //dtoNG.CRT_DATE = 
                    dtoNG.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                    dtoNG.UPD_BY = Common.CurrentUserInfomation.UserCD;
                    //dtoNG.UPD_DATE =
                    dtoNG.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
                    //dtoNG.TRANS_ID =
                    dtoNG.ITEM_CD = data.MASTER_NO;
                    dtoNG.LOC_CD = data.PROCESS;
                    //dtoNG.LOT_NO = 
                    //dtoNG.PACK_NO = 
                    dtoNG.EXTERNAL_LOT_NO = data.CUST_LOT_NO;
                    dtoNG.TRANS_DATE = data.PRODUCTION_REPORT_DATE;
                    dtoNG.TRANS_CLS = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.NGWorkResult).ToNZString();
                    dtoNG.IN_OUT_CLS = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.None).ToNZString();
                    if (dr[(int)ProductionReportEntryViewDTO.eColumns.NG_QTY] == null || dr[(int)ProductionReportEntryViewDTO.eColumns.NG_QTY] == (object)DBNull.Value)
                    {
                        dtoNG.QTY = new NZDecimal(null, 0);
                        dtoNG.NG_QTY = new NZDecimal(null, 0);
                    }
                    else
                    {
                        dtoNG.QTY = new NZDecimal(null, dr[(int)ProductionReportEntryViewDTO.eColumns.NG_QTY]);
                        dtoNG.NG_QTY = new NZDecimal(null, dr[(int)ProductionReportEntryViewDTO.eColumns.NG_QTY]);
                    }
                    dtoNG.WEIGHT = new NZDecimal(null, dr[(int)ProductionReportEntryViewDTO.eColumns.NG_WEIGHT]);
                    //dtoNG.OBJ_ITEM_CD = 
                    //dtoNG.OBJ_ORDER_QTY =
                    //dtoNG.REF_NO =
                    //dtoNG.REF_SLIP_NO =
                    //dtoNG.REF_SLIP_CLS =
                    //dtoNG.OTHER_DL_NO =
                    //dtoNG.SLIP_NO =
                    dtoNG.REMARK = data.REMARK;
                    dtoNG.DEALING_NO = data.SUPPLIER;
                    //dtoNG.PRICE =
                    //dtoNG.AMOUNT =
                    //dtoNG.FOR_CUSTOMER = 
                    dtoNG.FOR_MACHINE = data.MACHINE_NO;
                    dtoNG.SHIFT_CLS = data.SHIFT;
                    //dtoNG.REF_SLIP_NO2 =
                    //dtoNG.NG_QTY = new NZDecimal(null, dr[(int)ProductionReportEntryViewDTO.eColumns.NG_QTY]);
                    dtoNG.NG_WEIGHT = new NZDecimal(null, dr[(int)ProductionReportEntryViewDTO.eColumns.NG_WEIGHT]);
                    dtoNG.TRAN_SUB_CLS = new NZString(null, dr[(int)ProductionReportEntryViewDTO.eColumns.NG_CRITERIA_CD]);
                    dtoNG.SCREEN_TYPE = DataDefine.ScreenType.WorkResultEntry.ToNZString();
                    //dtoNG.GROUP_TRANS_ID =
                    //dtoNG.RESERVE_QTY =
                    //dtoNG.NG_REASON = 
                    dtoNG.EFFECT_STOCK = new NZInt(null, (int)DataDefine.eEFFECT_STOCK.None);
                    dtoNG.LOT_REMARK = data.LOT_NO;
                    dtoNG.PERSON_IN_CHARGE = data.PERSON_IN_CHARGE;
                    //dtoNG.CURRENCY = 
                    dtoNG.OLD_DATA = new NZInt(null, 0);

                    //save only qty > 0
                    if (dtoNG.QTY > 0)
                        listNG.Add(dtoNG);
                }

                #endregion

                bizInv.AddProductionReport(dtoInvMainTransIn, dtoInvMainTransOut, listNG);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SaveUpdateProductionReport(ProductionReportEntryUIDM data)
        {
            try
            {
                ItemValidator itemValidator = new ItemValidator();
                ValidateException.ThrowErrorItem(itemValidator.CheckEmptyItemCode(data.MASTER_NO));

                BusinessException businessException = itemValidator.CheckItemNotExist(data.MASTER_NO);
                if (businessException != null)
                    ValidateException.ThrowErrorItem(businessException.Error);

                List<InventoryTransactionDTO> dtoList = new List<InventoryTransactionDTO>();

                InventoryBIZ bizInv = new InventoryBIZ();
                InventoryTransBIZ bizInvTrans = new InventoryTransBIZ();
                DealingConstraintBIZ bizConstraint = new DealingConstraintBIZ();
                DealingConstraintDTO constriant = bizConstraint.LoadDealingConstraint(data.PROCESS);

                InventoryTransactionDTO dtoInvMainTransIn = bizInvTrans.LoadByTransactionID(data.TRANS_ID);
                InventoryTransactionDTO dtoInvMainTransOut = null;

                #region Main Transaction : for good qty

                //InventoryTransactionDTO dtoInvMainTransIn = new InventoryTransactionDTO();
                //dtoInvMainTransIn.CRT_BY = Common.CurrentUserInfomation.UserCD;
                //dtoInvMainTransIn.CRT_DATE = 
                //dtoInvMainTransIn.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                dtoInvMainTransIn.UPD_BY = Common.CurrentUserInfomation.UserCD;
                //dtoInvMainTransIn.UPD_DATE =
                dtoInvMainTransIn.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
                //dtoInvMainTransIn.TRANS_ID = data.TRANS_ID;
                //dtoInvMainTransIn.ITEM_CD = data.MASTER_NO;
                //dtoInvMainTransIn.LOC_CD = data.PROCESS;
                //dtoInvMainTransIn.LOT_NO = 
                //dtoInvMainTransIn.PACK_NO = 
                dtoInvMainTransIn.EXTERNAL_LOT_NO = data.CUST_LOT_NO;
                //dtoInvMainTransIn.TRANS_DATE = data.PRODUCTION_REPORT_DATE;
                //dtoInvMainTransIn.TRANS_CLS = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.WorkResult).ToNZString();
                //dtoInvMainTransIn.IN_OUT_CLS = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.In).ToNZString();
                dtoInvMainTransIn.QTY = data.QTY;
                dtoInvMainTransIn.WEIGHT = data.WEIGHT;
                //dtoInvMainTransIn.OBJ_ITEM_CD = 
                //dtoInvMainTransIn.OBJ_ORDER_QTY =
                //dtoInvMainTransIn.REF_NO = data.REF_NO;
                //dtoInvMainTransIn.REF_SLIP_NO =
                //dtoInvMainTransIn.REF_SLIP_CLS =
                //dtoInvMainTransIn.OTHER_DL_NO =
                //dtoInvMainTransIn.SLIP_NO = data.PRODUCTION_REPORT_NO;
                dtoInvMainTransIn.REMARK = data.REMARK;
                dtoInvMainTransIn.DEALING_NO = data.SUPPLIER;
                //dtoInvMainTransIn.PRICE =
                //dtoInvMainTransIn.AMOUNT =
                //dtoInvMainTransIn.FOR_CUSTOMER = 
                dtoInvMainTransIn.FOR_MACHINE = data.MACHINE_NO;
                dtoInvMainTransIn.SHIFT_CLS = data.SHIFT;
                //dtoInvMainTransIn.REF_SLIP_NO2 =
                dtoInvMainTransIn.NG_QTY = data.NG_QTY;
                //dtoInvMainTransIn.NG_WEIGHT =
                //dtoInvMainTransIn.TRAN_SUB_CLS = new NZString(null, data.REWORK.StrongValue);
                dtoInvMainTransIn.TRAN_SUB_CLS = Convert.ToInt32(data.REWORK.StrongValue) == (int)DataDefine.eTRAN_SUB_CLS.RW ?
                                                new NZString(null, DataDefine.eTRAN_SUB_CLS.RW.ToString()) :
                                                new NZString(null, DataDefine.eTRAN_SUB_CLS.WR.ToString());
                dtoInvMainTransIn.REWORK_FLAG = new NZInt(data.REWORK.Owner, Convert.ToInt32(data.REWORK));//(data.REWORK.NVL("WR") == DataDefine.eTRAN_SUB_CLS.RW.ToString() ? 1 : 0).ToNZInt();

                dtoInvMainTransIn.SCREEN_TYPE = DataDefine.ScreenType.WorkResultEntry.ToNZString();
                //dtoInvMainTransIn.GROUP_TRANS_ID = data.GROUP_TRANS_ID;
                //dtoInvMainTransIn.RESERVE_QTY =
                //dtoInvMainTransIn.NG_REASON =
                dtoInvMainTransIn.EFFECT_STOCK = new NZInt(null, (int)DataDefine.eEFFECT_STOCK.In);
                dtoInvMainTransIn.LOT_REMARK = data.LOT_NO;
                dtoInvMainTransIn.PERSON_IN_CHARGE = data.PERSON_IN_CHARGE;
                //dtoInvMainTransIn.CURRENCY = 
                dtoInvMainTransIn.OLD_DATA = new NZInt(null, 0);

                dtoList.Add(dtoInvMainTransIn);

                #endregion

                if (constriant == null || constriant.NO_CONSUMPTION_FLAG.StrongValue == 0)
                {
                    dtoInvMainTransOut = bizInvTrans.LoadByTransactionID(data.REF_NO);
                    #region Main Transaction for used qty(qty + ng)

                    //InventoryTransactionDTO dtoInvMainTransOut = new InventoryTransactionDTO();                
                    //dtoInvMainTransOut.CRT_BY = Common.CurrentUserInfomation.UserCD;
                    //dtoInvMainTransOut.CRT_DATE = 
                    //dtoInvMainTransOut.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                    dtoInvMainTransOut.UPD_BY = Common.CurrentUserInfomation.UserCD;
                    //dtoInvMainTransOut.UPD_DATE =
                    dtoInvMainTransOut.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
                    //dtoInvMainTransOut.TRANS_ID = data.REF_NO;
                    //dtoInvMainTransOut.ITEM_CD = data.MASTER_NO;
                    //dtoInvMainTransOut.LOC_CD = data.PROCESS;
                    //dtoInvMainTransOut.LOT_NO = 
                    //dtoInvMainTransOut.PACK_NO = 
                    dtoInvMainTransOut.EXTERNAL_LOT_NO = data.CUST_LOT_NO;
                    //dtoInvMainTransOut.TRANS_DATE = data.PRODUCTION_REPORT_DATE;
                    //dtoInvMainTransOut.TRANS_CLS = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Consumption).ToNZString();
                    //dtoInvMainTransOut.IN_OUT_CLS = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.Out).ToNZString();
                    dtoInvMainTransOut.QTY = new NZDecimal(null, data.QTY.StrongValue + data.NG_QTY.StrongValue);
                    dtoInvMainTransOut.WEIGHT = data.WEIGHT;
                    //dtoInvMainTransOut.OBJ_ITEM_CD = 
                    //dtoInvMainTransOut.OBJ_ORDER_QTY =
                    //dtoInvMainTransOut.REF_NO = data.TRANS_ID;
                    //dtoInvMainTransOut.REF_SLIP_NO = data.PRODUCTION_REPORT_NO;
                    //dtoInvMainTransOut.REF_SLIP_CLS =
                    //dtoInvMainTransOut.OTHER_DL_NO =
                    //dtoInvMainTransOut.SLIP_NO =
                    dtoInvMainTransOut.REMARK = data.REMARK;
                    dtoInvMainTransOut.DEALING_NO = data.SUPPLIER;
                    //dtoInvMainTransOut.PRICE =
                    //dtoInvMainTransOut.AMOUNT =
                    //dtoInvMainTransOut.FOR_CUSTOMER =
                    dtoInvMainTransOut.FOR_MACHINE = data.MACHINE_NO;
                    dtoInvMainTransOut.SHIFT_CLS = data.SHIFT;
                    //dtoInvMainTransOut.REF_SLIP_NO2 =
                    //dtoInvMainTransOut.NG_QTY = data.NG_QTY;
                    //dtoInvMainTransOut.NG_WEIGHT =
                    //dtoInvMainTransOut.TRAN_SUB_CLS = new NZString(null, DataDefine.eTRAN_SUB_CLS.WR.ToString());
                    dtoInvMainTransOut.SCREEN_TYPE = DataDefine.ScreenType.WorkResultEntry.ToNZString();
                    //dtoInvMainTransOut.GROUP_TRANS_ID = data.GROUP_TRANS_ID;
                    //dtoInvMainTransOut.RESERVE_QTY =
                    //dtoInvMainTransOut.NG_REASON =
                    dtoInvMainTransOut.EFFECT_STOCK = new NZInt(null, (int)DataDefine.eEFFECT_STOCK.Out);
                    dtoInvMainTransOut.LOT_REMARK = data.LOT_NO;
                    dtoInvMainTransOut.PERSON_IN_CHARGE = data.PERSON_IN_CHARGE;
                    //dtoInvMainTransOut.CURRENCY = 
                    dtoInvMainTransOut.OLD_DATA = new NZInt(null, 0);

                    dtoList.Add(dtoInvMainTransOut);

                    #endregion
                }

                #region NG Transaction

                DataTable dtData = data.DataView;
                foreach (DataRow dr in dtData.Rows)
                {
                    InventoryTransactionDTO dtoNG = new InventoryTransactionDTO();
                    dtoNG.CRT_BY = Common.CurrentUserInfomation.UserCD;
                    //dtoNG.CRT_DATE = 
                    dtoNG.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                    dtoNG.UPD_BY = Common.CurrentUserInfomation.UserCD;
                    //dtoNG.UPD_DATE =
                    dtoNG.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
                    dtoNG.TRANS_ID = new NZString(null, dr[(int)ProductionReportEntryViewDTO.eColumns.NG_TRANS_ID]);
                    dtoNG.ITEM_CD = dtoInvMainTransIn.ITEM_CD;
                    dtoNG.LOC_CD = dtoInvMainTransIn.LOC_CD;
                    //dtoNG.LOT_NO = 
                    //dtoNG.PACK_NO = 
                    dtoNG.EXTERNAL_LOT_NO = dtoInvMainTransIn.EXTERNAL_LOT_NO;
                    dtoNG.TRANS_DATE = dtoInvMainTransIn.TRANS_DATE;
                    dtoNG.TRANS_CLS = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.NGWorkResult).ToNZString();
                    dtoNG.IN_OUT_CLS = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.None).ToNZString();
                    if (dr[(int)ProductionReportEntryViewDTO.eColumns.NG_QTY] == null || dr[(int)ProductionReportEntryViewDTO.eColumns.NG_QTY] == (object)DBNull.Value)
                    {
                        dtoNG.QTY = new NZDecimal(null, 0);
                        dtoNG.NG_QTY = new NZDecimal(null, 0);
                    }
                    else
                    {
                        dtoNG.QTY = new NZDecimal(null, dr[(int)ProductionReportEntryViewDTO.eColumns.NG_QTY]);
                        dtoNG.NG_QTY = new NZDecimal(null, dr[(int)ProductionReportEntryViewDTO.eColumns.NG_QTY]);
                    }
                    dtoNG.WEIGHT = new NZDecimal(null, dr[(int)ProductionReportEntryViewDTO.eColumns.NG_WEIGHT]);
                    //dtoNG.OBJ_ITEM_CD = 
                    //dtoNG.OBJ_ORDER_QTY =
                    dtoNG.REF_NO = dtoInvMainTransIn.TRANS_ID;
                    dtoNG.REF_SLIP_NO = dtoInvMainTransIn.SLIP_NO;
                    //dtoNG.REF_SLIP_CLS =
                    //dtoNG.OTHER_DL_NO =
                    //dtoNG.SLIP_NO = 
                    dtoNG.REMARK = dtoInvMainTransIn.REMARK;
                    dtoNG.DEALING_NO = dtoInvMainTransIn.DEALING_NO;
                    //dtoNG.PRICE =
                    //dtoNG.AMOUNT =
                    //dtoNG.FOR_CUSTOMER = 
                    dtoNG.FOR_MACHINE = dtoInvMainTransIn.FOR_MACHINE;
                    dtoNG.SHIFT_CLS = dtoInvMainTransIn.SHIFT_CLS;
                    //dtoNG.REF_SLIP_NO2 =
                    //dtoNG.NG_QTY = new NZDecimal(null, dr[(int)ProductionReportEntryViewDTO.eColumns.NG_QTY]);
                    dtoNG.NG_WEIGHT = new NZDecimal(null, dr[(int)ProductionReportEntryViewDTO.eColumns.NG_WEIGHT]);
                    dtoNG.TRAN_SUB_CLS = new NZString(null, dr[(int)ProductionReportEntryViewDTO.eColumns.NG_CRITERIA_CD]);
                    dtoNG.SCREEN_TYPE = DataDefine.ScreenType.WorkResultEntry.ToNZString();
                    dtoNG.GROUP_TRANS_ID = dtoInvMainTransIn.GROUP_TRANS_ID;
                    //dtoNG.RESERVE_QTY =
                    //dtoNG.NG_REASON = 
                    dtoNG.EFFECT_STOCK = new NZInt(null, (int)DataDefine.eEFFECT_STOCK.None);
                    dtoNG.LOT_REMARK = dtoInvMainTransIn.LOT_REMARK;
                    dtoNG.PERSON_IN_CHARGE = dtoInvMainTransIn.PERSON_IN_CHARGE;
                    //dtoNG.CURRENCY = 
                    dtoNG.OLD_DATA = new NZInt(null, 0);

                    //save only qty > 0
                    //if (dtoNG.QTY > 0)
                    dtoList.Add(dtoNG);
                }

                #endregion

                bizInv.UpdateProductionReport(dtoList);
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal void DeleteProductionReport(NZString TransID)
        {
            InventoryBIZ bizInv = new InventoryBIZ();
            InventoryTransBIZ bizInvTrans = new InventoryTransBIZ();

            List<InventoryTransactionDTO> dtoList = new List<InventoryTransactionDTO>();
            InventoryTransactionDTO dtoTrans = null;

            ProductionReportEntryDTO dtoProduction = bizInvTrans.LoadProductionReport(TransID);
            if (dtoProduction != null)
            {
                //In
                dtoTrans = new InventoryTransactionDTO();
                dtoTrans.TRANS_ID = dtoProduction.TRANS_ID;
                dtoList.Add(dtoTrans);

                //Out
                dtoTrans = new InventoryTransactionDTO();
                dtoTrans.TRANS_ID = dtoProduction.REF_NO;
                dtoList.Add(dtoTrans);

                //NG
                DataTable dtNG = bizInvTrans.LoadNGTransaction(dtoProduction.TRANS_ID);
                if (dtNG != null && dtNG.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtNG.Rows)
                    {
                        NZString NGTrans = new NZString(null, dr[(int)ProductionReportEntryViewDTO.eColumns.NG_TRANS_ID]);
                        if (NGTrans == null)
                            continue;

                        dtoTrans = new InventoryTransactionDTO();
                        dtoTrans.TRANS_ID = NGTrans;
                        dtoList.Add(dtoTrans);
                    }
                }
            }

            bizInv.DeleteTransactionList(dtoList);
        }
    }
}
