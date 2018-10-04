using System;
using System.Collections.Generic;
using EVOFramework;
using Rubik.BIZ;
using Rubik.UIDataModel;
using Rubik.DTO;
using SystemMaintenance.BIZ;
using System.Data;

namespace Rubik.Controller
{
    class IssueByItemController
    {

        internal NZDecimal GetOnHandQty(IssueByItemUIDM uidmIssue)
        {
            InventoryBIZ bizInv = new InventoryBIZ();
            ActualOnhandViewDTO dtoInvOnHand;
            //InventoryPeriodBIZ bizPeriod = new InventoryPeriodBIZ();

            //NZString YearMonth = bizPeriod.LoadCurrentPeriod().YEAR_MONTH; //new NZString(null, CommonLib.Common.GetDatabaseDateTime().ToString("yyyyMM"));
            //InventoryPeriodDTO dtoPeriod = bizPeriod.LoadCurrentPeriod();

            //if (dtoPeriod == null) return new NZDecimal();

            dtoInvOnHand = bizInv.LoadActualInventoryOnHand(uidmIssue.ITEM_CD, uidmIssue.FROM_LOC_CD, uidmIssue.LOT_NO);
            if (dtoInvOnHand != null)
                return dtoInvOnHand.ONHAND_QTY;

            return new NZDecimal();
        }

        internal void SaveAddIssue(IssueByItemUIDM uidmIssue)
        {

            List<InventoryTransactionDTO> dtoInvTrnsList = new List<InventoryTransactionDTO>();
            InventoryTransactionDTO dtoInvTrns; // = new InventoryTransactionDTO();

            InventoryBIZ bizInv = new InventoryBIZ();

            try {
                //20100311 add by pichet
                CommonLib.Common.CurrentDatabase.KeepConnection = true;
                CommonLib.Common.CurrentDatabase.BeginTransaction(IsolationLevel.Serializable);
                //20100311 end add

                #region Add New Trans Record
                RunningNumberBIZ bizRunning = new RunningNumberBIZ();
                NZString TransID = bizRunning.GetCompleteRunningNo(new NZString(null, "TRAN_ID"), new NZString(null, "TB_INV_TRANS_TR"));
                NZString RefID = bizRunning.GetCompleteRunningNo(new NZString(null, "TRAN_ID"), new NZString(null, "TB_INV_TRANS_TR"));
                NZString TranCls = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Issuing).ToNZString(); 
                // up
                dtoInvTrns = new InventoryTransactionDTO();
                dtoInvTrns.TRANS_ID = TransID;
                dtoInvTrns.REF_NO = RefID;
                dtoInvTrns.ITEM_CD = uidmIssue.ITEM_CD;
                dtoInvTrns.LOC_CD = uidmIssue.FROM_LOC_CD;
                dtoInvTrns.LOT_NO = uidmIssue.LOT_NO.StrongValue.Trim() == string.Empty ? new NZString() : uidmIssue.LOT_NO;
                dtoInvTrns.TRANS_DATE = uidmIssue.TRANS_DATE;
                if (dtoInvTrns.TRANS_DATE.IsNull)
                    dtoInvTrns.TRANS_DATE.Value = CommonLib.Common.GetDatabaseDateTime();
                dtoInvTrns.TRANS_CLS = TranCls;//uidmIssue.TRANS_CLS;
                dtoInvTrns.IN_OUT_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.Out);
                dtoInvTrns.QTY = uidmIssue.QTY;
                dtoInvTrns.REMARK = uidmIssue.REMARK;
                dtoInvTrns.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                dtoInvTrns.CRT_DATE.Value = CommonLib.Common.GetDatabaseDateTime();
                dtoInvTrns.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                dtoInvTrns.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                dtoInvTrns.UPD_DATE.Value = CommonLib.Common.GetDatabaseDateTime();
                dtoInvTrns.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                dtoInvTrns.REF_SLIP_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eREF_SLIP_CLS.Issue);
                dtoInvTrns.REF_SLIP_NO = uidmIssue.REF_SLIP_NO;
                dtoInvTrns.REF_SLIP_NO2 = uidmIssue.REF_SLIP_NO2;
                dtoInvTrns.TRAN_SUB_CLS = uidmIssue.TRAN_SUB_CLS;
                dtoInvTrns.FOR_CUSTOMER = uidmIssue.FOR_CUSTOMER;
                dtoInvTrns.FOR_MACHINE = uidmIssue.FOR_MACHINE;
                dtoInvTrns.SCREEN_TYPE = DataDefine.ScreenType.IssueEntry.ToNZString();

                dtoInvTrnsList.Add(dtoInvTrns);

                // down
                dtoInvTrns = new InventoryTransactionDTO();
                dtoInvTrns.TRANS_ID = RefID;
                dtoInvTrns.REF_NO = TransID;
                dtoInvTrns.ITEM_CD = uidmIssue.ITEM_CD;
                dtoInvTrns.LOC_CD = uidmIssue.TO_LOC_CD;
                dtoInvTrns.LOT_NO = uidmIssue.LOT_NO.StrongValue.Trim() == string.Empty ? new NZString() : uidmIssue.LOT_NO; 
                dtoInvTrns.TRANS_DATE = uidmIssue.TRANS_DATE;
                if (dtoInvTrns.TRANS_DATE.IsNull)
                    dtoInvTrns.TRANS_DATE.Value = CommonLib.Common.GetDatabaseDateTime();
                dtoInvTrns.TRANS_CLS = TranCls; //uidmIssue.TRANS_CLS;
                dtoInvTrns.IN_OUT_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.In);
                dtoInvTrns.QTY = uidmIssue.QTY;
                dtoInvTrns.REMARK = uidmIssue.REMARK;
                dtoInvTrns.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                dtoInvTrns.CRT_DATE.Value = CommonLib.Common.GetDatabaseDateTime();
                dtoInvTrns.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                dtoInvTrns.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                dtoInvTrns.UPD_DATE.Value = CommonLib.Common.GetDatabaseDateTime();
                dtoInvTrns.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                dtoInvTrns.REF_SLIP_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eREF_SLIP_CLS.Issue);
                dtoInvTrns.REF_SLIP_NO = uidmIssue.REF_SLIP_NO;
                dtoInvTrns.REF_SLIP_NO2 = uidmIssue.REF_SLIP_NO2;
                dtoInvTrns.TRAN_SUB_CLS = uidmIssue.TRAN_SUB_CLS;
                dtoInvTrns.FOR_CUSTOMER = uidmIssue.FOR_CUSTOMER;
                dtoInvTrns.FOR_MACHINE = uidmIssue.FOR_MACHINE;
                dtoInvTrns.SCREEN_TYPE = DataDefine.ScreenType.IssueEntry.ToNZString();

                dtoInvTrnsList.Add(dtoInvTrns);

                #endregion

                //bizInv.AddIssueByItem(dtoInvTrnsList, dtoInvOnHandList);

                // REWRITE UPDATE STOCK ONHAND METHOD
                // CHANGE TO USE THE COMMON FUNCTION
                bizInv.AddInventoryTransactions(CommonLib.Common.CurrentDatabase, dtoInvTrnsList,false);
                //bizInv.UpdateInventoryOnhand(CommonLib.Common.CurrentDatabase, uidmIssue.TRANS_DATE
                //    , uidmIssue.ITEM_CD, uidmIssue.TO_LOC_CD, uidmIssue.LOT_NO, DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.In).ToNZString(), uidmIssue.QTY, DataDefine.eTRANS_TYPE.Issuing);
                //bizInv.UpdateInventoryOnhand(CommonLib.Common.CurrentDatabase, uidmIssue.TRANS_DATE
                //    , uidmIssue.ITEM_CD, uidmIssue.FROM_LOC_CD, uidmIssue.LOT_NO, DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.Out).ToNZString(), uidmIssue.QTY, DataDefine.eTRANS_TYPE.Issuing);

                CommonLib.Common.CurrentDatabase.Commit();

            }
            catch (Exception) {
                CommonLib.Common.CurrentDatabase.Rollback();
                throw;
            }
            finally {
                if (CommonLib.Common.CurrentDatabase.DBConnectionState == ConnectionState.Open)
                    CommonLib.Common.CurrentDatabase.Close();
            }
            
        }


        internal void SaveUpdateIssue(IssueByItemUIDM uidmIssue)
        {
            List<InventoryTransactionDTO> dtoInvTrnsList = new List<InventoryTransactionDTO>();
            InventoryTransactionDTO dtoInvTrns; // = new InventoryTransactionDTO();

            InventoryBIZ bizInv = new InventoryBIZ();

           

            try
            {
                //20100311 add by pichet
                CommonLib.Common.CurrentDatabase.KeepConnection = true;
                CommonLib.Common.CurrentDatabase.BeginTransaction(IsolationLevel.Serializable);
                //20100311 end add

                #region Add New Trans Record
                NZString TranCls = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Issuing).ToNZString(); 
                // up
                dtoInvTrns = new InventoryTransactionDTO();
                dtoInvTrns.TRANS_ID = uidmIssue.TRANS_ID;
                dtoInvTrns.REF_NO = uidmIssue.REF_NO;
                dtoInvTrns.ITEM_CD = uidmIssue.ITEM_CD;
                dtoInvTrns.LOC_CD = uidmIssue.FROM_LOC_CD;
                dtoInvTrns.LOT_NO = uidmIssue.LOT_NO.StrongValue.Trim() == string.Empty ? new NZString() : uidmIssue.LOT_NO;
                dtoInvTrns.TRANS_DATE = uidmIssue.TRANS_DATE;
                if (dtoInvTrns.TRANS_DATE.IsNull) dtoInvTrns.TRANS_DATE.Value = CommonLib.Common.GetDatabaseDateTime();
                dtoInvTrns.TRANS_CLS = TranCls;// uidmIssue.TRANS_CLS;
                dtoInvTrns.IN_OUT_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.Out);
                dtoInvTrns.QTY = uidmIssue.QTY;
                dtoInvTrns.REMARK = uidmIssue.REMARK;
                dtoInvTrns.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                dtoInvTrns.CRT_DATE.Value = CommonLib.Common.GetDatabaseDateTime();
                dtoInvTrns.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                dtoInvTrns.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                dtoInvTrns.UPD_DATE.Value = CommonLib.Common.GetDatabaseDateTime();
                dtoInvTrns.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                dtoInvTrns.REF_SLIP_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eREF_SLIP_CLS.Issue);
                dtoInvTrns.REF_SLIP_NO = uidmIssue.REF_SLIP_NO;
                dtoInvTrns.REF_SLIP_NO2 = uidmIssue.REF_SLIP_NO2;
                dtoInvTrns.TRAN_SUB_CLS = uidmIssue.TRAN_SUB_CLS;
                dtoInvTrns.FOR_CUSTOMER = uidmIssue.FOR_CUSTOMER;
                dtoInvTrns.FOR_MACHINE = uidmIssue.FOR_MACHINE;
                dtoInvTrns.SCREEN_TYPE = DataDefine.ScreenType.IssueEntry.ToNZString();

                dtoInvTrnsList.Add(dtoInvTrns);

                // down
                dtoInvTrns = new InventoryTransactionDTO();
                dtoInvTrns.TRANS_ID = uidmIssue.REF_NO;
                dtoInvTrns.REF_NO = uidmIssue.TRANS_ID;
                dtoInvTrns.ITEM_CD = uidmIssue.ITEM_CD;
                dtoInvTrns.LOC_CD = uidmIssue.TO_LOC_CD;
                dtoInvTrns.LOT_NO = uidmIssue.LOT_NO.StrongValue.Trim() == string.Empty ? new NZString() : uidmIssue.LOT_NO;
                dtoInvTrns.TRANS_DATE = uidmIssue.TRANS_DATE;
                if (dtoInvTrns.TRANS_DATE.IsNull) dtoInvTrns.TRANS_DATE.Value = CommonLib.Common.GetDatabaseDateTime();
                dtoInvTrns.TRANS_CLS = TranCls;//uidmIssue.TRANS_CLS;
                dtoInvTrns.IN_OUT_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.In);
                dtoInvTrns.QTY = uidmIssue.QTY;
                dtoInvTrns.REMARK = uidmIssue.REMARK;
                dtoInvTrns.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                dtoInvTrns.CRT_DATE.Value = CommonLib.Common.GetDatabaseDateTime();
                dtoInvTrns.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                dtoInvTrns.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                dtoInvTrns.UPD_DATE.Value = CommonLib.Common.GetDatabaseDateTime();
                dtoInvTrns.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                dtoInvTrns.REF_SLIP_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eREF_SLIP_CLS.Issue);
                dtoInvTrns.REF_SLIP_NO = uidmIssue.REF_SLIP_NO;
                dtoInvTrns.REF_SLIP_NO2 = uidmIssue.REF_SLIP_NO2;
                dtoInvTrns.TRAN_SUB_CLS = uidmIssue.TRAN_SUB_CLS;
                dtoInvTrns.FOR_CUSTOMER = uidmIssue.FOR_CUSTOMER;
                dtoInvTrns.FOR_MACHINE = uidmIssue.FOR_MACHINE;
                dtoInvTrns.SCREEN_TYPE = DataDefine.ScreenType.IssueEntry.ToNZString();

                dtoInvTrnsList.Add(dtoInvTrns);

                #endregion

                //bizInv.UpdateIssueByItem(dtoInvTrnsList);//, dtoInvOnHandList);
                bizInv.UpdateInventoryTransactions(CommonLib.Common.CurrentDatabase, dtoInvTrnsList);
                //bizInv.UpdateInventoryOnhand(CommonLib.Common.CurrentDatabase, uidmIssue.TRANS_DATE
                //   , uidmIssue.ITEM_CD, uidmIssue.TO_LOC_CD, uidmIssue.LOT_NO, DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.In).ToNZString(), uidmIssue.QTY, DataDefine.eTRANS_TYPE.Issuing);
                //bizInv.UpdateInventoryOnhand(CommonLib.Common.CurrentDatabase, uidmIssue.TRANS_DATE
                //    , uidmIssue.ITEM_CD, uidmIssue.FROM_LOC_CD, uidmIssue.LOT_NO, DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.Out).ToNZString(), uidmIssue.QTY, DataDefine.eTRANS_TYPE.Issuing);

                CommonLib.Common.CurrentDatabase.Commit();
            }
            catch (Exception)
            {
                CommonLib.Common.CurrentDatabase.Rollback();
                throw;
            }
            finally
            {
                if (CommonLib.Common.CurrentDatabase.DBConnectionState == ConnectionState.Open)
                    CommonLib.Common.CurrentDatabase.Close();
            }
        }
    }
}
