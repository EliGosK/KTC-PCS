using System;
using System.Collections.Generic;
using System.Data;
using SystemMaintenance.BIZ;
using CommonLib;
using EVOFramework;
using Rubik.BIZ;
using Rubik.DTO;
using Rubik.UIDataModel;
using Rubik.Validators;

namespace Rubik.Controller
{
   public class IssueByEntryController
    {
       private enum eColView
       {
           ITEM_CODE,
           ITEM_DESC,
           LOT_NO,
           REQUEST_QTY,
           ISSUE_QTY,
           ONHAND_QTY,
           TRANS_ID,
           REF_NO,
       }

       internal void SaveAddIssue(List<IssueByOrderUIDM> uidmIssueList)
       {
           List<InventoryTransactionDTO> dtoInvTrnsListFrom = new List<InventoryTransactionDTO>();
           List<InventoryTransactionDTO> dtoInvTrnsListTo = new List<InventoryTransactionDTO>();

           InventoryTransactionDTO dtoInvTrns;
           IssueEntryValidator val = new IssueEntryValidator();
           CommonBizValidator commonVal = new CommonBizValidator();
           InventoryBIZ bizInv = new InventoryBIZ();

           for (int i = 0; i < uidmIssueList.Count; i++)
           {
               ValidateException.ThrowErrorItem(commonVal.CheckInputLot(uidmIssueList[i].ITEM_CD, uidmIssueList[i].FROM_LOC_CD, uidmIssueList[i].LOT_NO, true));

               #region Add New Trans Record
               // up
               dtoInvTrns = new InventoryTransactionDTO();
               dtoInvTrns.ITEM_CD = uidmIssueList[i].ITEM_CD;
               dtoInvTrns.LOC_CD = uidmIssueList[i].FROM_LOC_CD;
               dtoInvTrns.LOT_NO = uidmIssueList[i].LOT_NO.StrongValue.Trim() == string.Empty ? new NZString() : uidmIssueList[i].LOT_NO;
               dtoInvTrns.TRANS_DATE = uidmIssueList[i].TRANS_DATE;
               if (dtoInvTrns.TRANS_DATE.IsNull) dtoInvTrns.TRANS_DATE.Value = CommonLib.Common.GetDatabaseDateTime();
               dtoInvTrns.TRANS_CLS = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Issuing).ToNZString();//uidmIssueList[i].TRANS_CLS;
               dtoInvTrns.IN_OUT_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.Out);
               dtoInvTrns.QTY = uidmIssueList[i].QTY;
               dtoInvTrns.REMARK = uidmIssueList[i].REMARK;
               dtoInvTrns.OBJ_ITEM_CD = uidmIssueList[i].OBJ_ITEM_CD;
               dtoInvTrns.OBJ_ORDER_QTY = uidmIssueList[i].OBJ_ORDER_QTY;
               dtoInvTrns.CRT_BY = Common.CurrentUserInfomation.UserCD;
               dtoInvTrns.CRT_DATE.Value = CommonLib.Common.GetDatabaseDateTime();
               dtoInvTrns.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
               dtoInvTrns.UPD_BY = Common.CurrentUserInfomation.UserCD;
               dtoInvTrns.UPD_DATE.Value = CommonLib.Common.GetDatabaseDateTime();
               dtoInvTrns.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
               dtoInvTrns.REF_SLIP_CLS = (NZString)DataDefine.Convert2ClassCode(DataDefine.eREF_SLIP_CLS.Issue);

               dtoInvTrns.FOR_CUSTOMER = uidmIssueList[i].FOR_CUSTOMER;
               dtoInvTrns.FOR_MACHINE = uidmIssueList[i].FOR_MACHINE;
               dtoInvTrns.REF_SLIP_NO2 = uidmIssueList[i].REF_SLIP_NO2;
               dtoInvTrns.REF_SLIP_NO = uidmIssueList[i].REF_SLIP_NO;
               dtoInvTrns.TRAN_SUB_CLS = uidmIssueList[i].TRAN_SUB_CLS;
               dtoInvTrns.SCREEN_TYPE = DataDefine.ScreenType.IssueEntry.ToNZString();

               dtoInvTrnsListFrom.Add(dtoInvTrns);

               // down
               dtoInvTrns = new InventoryTransactionDTO();
               dtoInvTrns.ITEM_CD = uidmIssueList[i].ITEM_CD;
               dtoInvTrns.LOC_CD = uidmIssueList[i].TO_LOC_CD;
               dtoInvTrns.LOT_NO = uidmIssueList[i].LOT_NO.StrongValue.Trim() == string.Empty ? new NZString() : uidmIssueList[i].LOT_NO;
               dtoInvTrns.TRANS_DATE = uidmIssueList[i].TRANS_DATE;
               if (dtoInvTrns.TRANS_DATE.IsNull) dtoInvTrns.TRANS_DATE.Value = CommonLib.Common.GetDatabaseDateTime();
               dtoInvTrns.TRANS_CLS = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Issuing).ToNZString();//uidmIssueList[i].TRANS_CLS;
               dtoInvTrns.IN_OUT_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.In);
               dtoInvTrns.QTY = uidmIssueList[i].QTY;
               dtoInvTrns.REMARK = uidmIssueList[i].REMARK;
               dtoInvTrns.CRT_BY = Common.CurrentUserInfomation.UserCD;
               dtoInvTrns.CRT_DATE.Value = CommonLib.Common.GetDatabaseDateTime();
               dtoInvTrns.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
               dtoInvTrns.UPD_BY = Common.CurrentUserInfomation.UserCD;
               dtoInvTrns.UPD_DATE.Value = CommonLib.Common.GetDatabaseDateTime();
               dtoInvTrns.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
               dtoInvTrns.OBJ_ITEM_CD = uidmIssueList[i].OBJ_ITEM_CD;
               dtoInvTrns.OBJ_ORDER_QTY = uidmIssueList[i].OBJ_ORDER_QTY;
               dtoInvTrns.REF_SLIP_CLS = (NZString)DataDefine.Convert2ClassCode(DataDefine.eREF_SLIP_CLS.Issue);

               dtoInvTrns.FOR_CUSTOMER = uidmIssueList[i].FOR_CUSTOMER;
               dtoInvTrns.FOR_MACHINE = uidmIssueList[i].FOR_MACHINE;
               dtoInvTrns.REF_SLIP_NO2 = uidmIssueList[i].REF_SLIP_NO2;
               dtoInvTrns.REF_SLIP_NO = uidmIssueList[i].REF_SLIP_NO;
               dtoInvTrns.TRAN_SUB_CLS = uidmIssueList[i].TRAN_SUB_CLS;
               dtoInvTrns.SCREEN_TYPE = DataDefine.ScreenType.IssueEntry.ToNZString();

               dtoInvTrnsListTo.Add(dtoInvTrns);

               #endregion

           }


           bizInv.AddIssueByOrder(dtoInvTrnsListFrom, dtoInvTrnsListTo, uidmIssueList.Count);
       }

       internal void SaveDataEditMode(IssueByOrderUIDM model)
       {
           //== If data not has to processing.
           if (model.DATA_VIEW == null || model.DATA_VIEW.Rows.Count == 0)
               ValidateException.ThrowErrorItem(new ErrorItem(null, TKPMessages.eValidate.VLM0055.ToString()));

           //model.DATA_VIEW.AcceptChanges();


           // 20100324 11:44 Add by Teerayut S.
           // Comment: Move begin transaction from business class to controller class.
           // add try..catch block to control transaction scope.
           Common.CurrentDatabase.KeepConnection = true;
           Common.CurrentDatabase.BeginTransaction(IsolationLevel.Serializable);
           // 20100324 End Teerayut S.

           try
           {
               DataTable dtData = model.DATA_VIEW;

               DataTable dtAdd = dtData.GetChanges(DataRowState.Added);
               DataTable dtModify = dtData.GetChanges(DataRowState.Modified);
               DataTable dtDelete = dtData.GetChanges(DataRowState.Deleted);

               InventoryBIZ biz = new InventoryBIZ();

               List<InventoryTransactionDTO> listAdd_from = null;
               List<InventoryTransactionDTO> listUpdate_from = null;
               List<InventoryTransactionDTO> listDelete_from = null;

               List<InventoryTransactionDTO> listAdd_to = null;
               List<InventoryTransactionDTO> listUpdate_to = null;
               List<InventoryTransactionDTO> listDelete_to = null;

               //== Insert process.
               if (dtAdd != null && dtAdd.Rows.Count > 0)
               {
                   listAdd_from = ConvertDataTableToList(dtAdd, DataDefine.eIN_OUT_CLASS.Out);
                   listAdd_to = ConvertDataTableToList(dtAdd, DataDefine.eIN_OUT_CLASS.In);
                   NZString runningNo;

                   if (model.SLIP_NO.IsNull)
                   {
                       RunningNumberBIZ runningNumberBIZ = new RunningNumberBIZ();
                       runningNo = runningNumberBIZ.GetCompleteRunningNo((NZString)"ISSUE_SLIP_NO", (NZString)"TB_INV_TRANS_TR");
                   }
                   else
                   {
                       runningNo = model.SLIP_NO;
                   }

                   for (int i = 0; i < listAdd_from.Count; i++)
                   {
                       InventoryTransactionDTO dto_from = listAdd_from[i];
                       InventoryTransactionDTO dto_to = listAdd_to[i];
                       // Copy ค่า Header จาก Model ไปยัง DTO แต่ละตัว
                       AssignHeaderToDTO(model, dto_from, DataDefine.eIN_OUT_CLASS.Out);
                       AssignHeaderToDTO(model, dto_to, DataDefine.eIN_OUT_CLASS.In);

                       dto_from.SLIP_NO = runningNo;
                       dto_from.CRT_BY = Common.CurrentUserInfomation.UserCD;
                       dto_from.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                       dto_from.UPD_BY = Common.CurrentUserInfomation.UserCD;
                       dto_from.UPD_MACHINE = Common.CurrentUserInfomation.Machine;

                       dto_to.REF_SLIP_NO = runningNo;
                       dto_to.CRT_BY = Common.CurrentUserInfomation.UserCD;
                       dto_to.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                       dto_to.UPD_BY = Common.CurrentUserInfomation.UserCD;
                       dto_to.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
                   }
               }

               //== Update process.
               if (dtModify != null && dtModify.Rows.Count > 0)
               {
                   listUpdate_from = ConvertDataTableToList(dtModify, DataDefine.eIN_OUT_CLASS.Out);
                   listUpdate_to = ConvertDataTableToList(dtModify, DataDefine.eIN_OUT_CLASS.In);
                   
                   NZString runningNo;
                   if (model.SLIP_NO.IsNull)
                   {
                       RunningNumberBIZ runningNumberBIZ = new RunningNumberBIZ();
                       runningNo = runningNumberBIZ.GetCompleteRunningNo((NZString)"ISSUE_SLIP_NO", (NZString)"TB_INV_TRANS_TR");
                   }
                   else
                   {
                       runningNo = model.SLIP_NO;
                   }

                   for (int i = 0; i < listUpdate_from.Count; i++)
                   {
                       InventoryTransactionDTO dto_from = listUpdate_from[i];
                       InventoryTransactionDTO dto_to = listUpdate_to[i];

                       // Copy ค่า Header จาก Model ไปยัง DTO แต่ละตัว
                       AssignHeaderToDTO(model, dto_from, DataDefine.eIN_OUT_CLASS.Out);
                       AssignHeaderToDTO(model, dto_to, DataDefine.eIN_OUT_CLASS.In);
                       dto_from.SLIP_NO = runningNo;
                       dto_from.CRT_BY = Common.CurrentUserInfomation.UserCD;
                       dto_from.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                       dto_from.UPD_BY = Common.CurrentUserInfomation.UserCD;
                       dto_from.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
                       dto_to.CRT_BY = Common.CurrentUserInfomation.UserCD;
                       dto_to.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                       dto_to.UPD_BY = Common.CurrentUserInfomation.UserCD;
                       dto_to.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
                   }
               }


               //== Delete process.
               if (dtDelete != null && dtDelete.Rows.Count > 0)
               {
                   listDelete_from = ConvertDataTableToList(dtDelete, DataDefine.eIN_OUT_CLASS.Out);
                   listDelete_to = ConvertDataTableToList(dtDelete, DataDefine.eIN_OUT_CLASS.In);

                   for (int i = 0; i < listDelete_from.Count; i++)
                   {
                       InventoryTransactionDTO dto_from = listDelete_from[i];
                       InventoryTransactionDTO dto_to = listDelete_to[i];

                       // Copy ค่า Header จาก Model ไปยัง DTO แต่ละตัว
                       AssignHeaderToDTO(model, dto_from, DataDefine.eIN_OUT_CLASS.Out);
                       AssignHeaderToDTO(model, dto_to, DataDefine.eIN_OUT_CLASS.In);
                   }
               }


               // ------ Update Header Process -------------
               List<InventoryTransactionDTO> listUpdateHeader_from = new List<InventoryTransactionDTO>();
               List<InventoryTransactionDTO> listUpdateHeader_to = new List<InventoryTransactionDTO>();

               if (dtData != null && dtData.Rows.Count > 0)
               {
                   listUpdateHeader_from = ConvertDataTableToList(dtData, DataDefine.eIN_OUT_CLASS.Out);
                   listUpdateHeader_to = ConvertDataTableToList(dtData, DataDefine.eIN_OUT_CLASS.In);

                   for (int i = 0; i < listUpdateHeader_from.Count; i++)
                   {
                       InventoryTransactionDTO dto_from = listUpdateHeader_from[i];
                       InventoryTransactionDTO dto_to = listUpdateHeader_to[i];

                       // Copy ค่า Header จาก Model ไปยัง DTO แต่ละตัว
                       AssignHeaderToDTO(model, dto_from, DataDefine.eIN_OUT_CLASS.Out);
                       AssignHeaderToDTO(model, dto_to, DataDefine.eIN_OUT_CLASS.In);

                       dto_from.CRT_BY = Common.CurrentUserInfomation.UserCD;
                       dto_from.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                       dto_from.UPD_BY = Common.CurrentUserInfomation.UserCD;
                       dto_from.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
                       dto_to.CRT_BY = Common.CurrentUserInfomation.UserCD;
                       dto_to.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                       dto_to.UPD_BY = Common.CurrentUserInfomation.UserCD;
                       dto_to.UPD_MACHINE = Common.CurrentUserInfomation.Machine;

                       biz.UpdateIssueHeader(listUpdateHeader_from[i]);
                       biz.UpdateIssueHeader(listUpdateHeader_to[i]);
                   }
               }

               // --------- End ----------------------

               biz.UpdateIssueByOrder(listAdd_from, listAdd_to, listUpdate_from, listUpdate_to, listDelete_from, listDelete_to);

               CommonLib.Common.CurrentDatabase.Commit();
           }
           catch (Exception err)
           {
               CommonLib.Common.CurrentDatabase.Rollback();
               throw;
           }
       }

       private List<InventoryTransactionDTO> ConvertDataTableToList(DataTable dt, DataDefine.eIN_OUT_CLASS in_out)
       {
           List<InventoryTransactionDTO> list = new List<InventoryTransactionDTO>();
           foreach (DataRow dr in dt.Rows)
           {

               InventoryTransactionDTO dto = new InventoryTransactionDTO();
               DataRowVersion drVersion = DataRowVersion.Current;
               if (dr.RowState == DataRowState.Deleted)
                   drVersion = DataRowVersion.Original;
               dto.ITEM_CD.Value = dr[(int)eColView.ITEM_CODE, drVersion];// PART_NO,
               dto.LOT_NO.Value = dr[eColView.LOT_NO.ToString(), drVersion];//LOT_NO,
               dto.QTY.Value = dr[eColView.ISSUE_QTY.ToString(), drVersion];//ISSUE_QTY,
               if (in_out == DataDefine.eIN_OUT_CLASS.Out)
               {
                   dto.TRANS_ID.Value = dr[eColView.TRANS_ID.ToString(), drVersion];
                   dto.REF_NO.Value = dr[eColView.REF_NO.ToString(), drVersion];
               }
               else
               {
                   dto.REF_NO.Value = dr[eColView.TRANS_ID.ToString(), drVersion];
                   dto.TRANS_ID.Value = dr[eColView.REF_NO.ToString(), drVersion];
               }
               list.Add(dto);
           }
           return list;
       }

       private void AssignHeaderToDTO(IssueByOrderUIDM model, InventoryTransactionDTO dto, DataDefine.eIN_OUT_CLASS in_out)
       {
           dto.TRANS_DATE = model.TRANS_DATE;
           //dto.REF_SLIP_NO = model.SLIP_NO;
           dto.TRANS_CLS = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Issuing).ToNZString();//model.TRANS_CLS;
           //dto.REF_SLIP_NO = model.INVOICE_NO;
           //dto.OTHER_DL_NO = model.INVOICE_NO;
           dto.REMARK = model.REMARK;
           dto.OBJ_ITEM_CD = model.OBJ_ITEM_CD;
           dto.OBJ_ORDER_QTY = model.OBJ_ORDER_QTY;
           dto.REF_SLIP_CLS = (NZString)DataDefine.Convert2ClassCode(DataDefine.eREF_SLIP_CLS.Issue);
           dto.FOR_CUSTOMER = model.FOR_CUSTOMER;
           dto.FOR_MACHINE = model.FOR_MACHINE;
           dto.REF_SLIP_NO2 = model.REF_SLIP_NO2;
           dto.REF_SLIP_NO = model.REF_SLIP_NO;
           dto.TRAN_SUB_CLS = model.TRAN_SUB_CLS;
           dto.SCREEN_TYPE = DataDefine.ScreenType.IssueEntry.ToNZString();

           if (in_out == DataDefine.eIN_OUT_CLASS.In)
           {
               dto.REF_SLIP_NO = model.SLIP_NO;
               dto.LOC_CD = model.TO_LOC_CD;
               dto.IN_OUT_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.In);
           }
           else
           {
               dto.SLIP_NO = model.SLIP_NO;
               dto.LOC_CD = model.FROM_LOC_CD;
               dto.IN_OUT_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.Out);
           }
       }
       internal List<BOMSetupViewDTO> LoadIssueList(NZString ItemCD)
       {
           // get child part for add to transaction
           BOMBIZ bizBom = new BOMBIZ();
           List<BOMSetupViewDTO> dtoBomList = bizBom.LoadChildPartWithLevelFix(ItemCD, 1);

           return dtoBomList;
       }
       internal DataTable LoadIssueListForEdit(NZString SLIP_NO)
       {
           InventoryTransBIZ biz = new InventoryTransBIZ();
           return biz.LoadIssueListForEdit(SLIP_NO);

       }
    }
}
