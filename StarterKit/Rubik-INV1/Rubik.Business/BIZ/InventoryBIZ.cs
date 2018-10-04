using System;
using System.Data;
using System.Collections.Generic;
using SystemMaintenance.BIZ;
using SystemMaintenance.DTO;
using SystemMaintenance.SQLServer.DAO;
using Rubik.DAO;
using EVOFramework;
using Rubik.DTO;
using EVOFramework.Database;
using Rubik.Validators;
using CommonLib;

namespace Rubik.BIZ
{
    public partial class InventoryBIZ
    {
        #region Load
        public DataTable LoadInventoryOnhand(DateTime? FromPeriod, DateTime? ToPeriod, bool GroupByItem)
        {
            InventoryOnhandDAO dao = new InventoryOnhandDAO(CommonLib.Common.CurrentDatabase);
            if (GroupByItem)
                return dao.LoadInventoryOnhandGroupByItem(null, FromPeriod, ToPeriod);

            return dao.LoadInventoryOnhand(null, FromPeriod, ToPeriod);
        }
        public InventoryOnhandDTO LoadInventoryOnHand(NZString YEAR_MONTH, NZDateTime PERIOD_BEGIN_DATE, NZDateTime PERIOD_END_DATE
            , NZString ITEM_CD
            , NZString LOC_CD
            , NZString LOT_NO)
        {
            InventoryOnhandDAO dao = new InventoryOnhandDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadInventoryOnHand(null, YEAR_MONTH, PERIOD_BEGIN_DATE, PERIOD_END_DATE
                                    , ITEM_CD, LOC_CD, LOT_NO);
        }

        public InventoryOnhandDTO LoadInventoryOnHandAllLotNo(NZString YEAR_MONTH, NZDateTime PERIOD_BEGIN_DATE, NZDateTime PERIOD_END_DATE
            , NZString ITEM_CD
            , NZString LOC_CD
            , NZString LOT_NO
            )
        {
            InventoryOnhandDAO dao = new InventoryOnhandDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadInventoryOnHandAllLotNo(null, YEAR_MONTH, PERIOD_BEGIN_DATE, PERIOD_END_DATE
                                    , ITEM_CD, LOC_CD, LOT_NO);
        }

        public InventoryOnhandDTO LoadInventoryOnHandByDate(NZString YEAR_MONTH
            , NZDateTime DATE
            , NZString ITEM_CD
            , NZString LOC_CD
            , NZString LOT_NO
            , NZString PACK_NO
            )
        {

            InventoryOnhandDAO dao = new InventoryOnhandDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadInventoryOnHandByDate(null, YEAR_MONTH, DATE, ITEM_CD, LOC_CD, LOT_NO, PACK_NO);
        }

        public InventoryOnhandDTO LoadInventoryOnHandByYearMonth(NZString YEAR_MONTH, NZString ITEM_CD
            , NZString LOC_CD
            , NZString LOT_NO
            , NZString PACK_NO
            )
        {

            InventoryOnhandDAO dao = new InventoryOnhandDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadInventoryOnHandByYearMonth(null, YEAR_MONTH, ITEM_CD, LOC_CD, LOT_NO, PACK_NO);
        }

        public InventoryOnhandDTO LoadInventoryOnHandByCurrentPeriod(
            NZString ITEM_CD
            , NZString LOC_CD
            , NZString LOT_NO
            , NZString PACK_NO
            )
        {
            InventoryPeriodBIZ inventoryPeriodBiz = new InventoryPeriodBIZ();
            InventoryPeriodDTO inventoryPeriodDto = inventoryPeriodBiz.LoadCurrentPeriod();
            if (inventoryPeriodDto == null)
                return null;


            InventoryOnhandDAO dao = new InventoryOnhandDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadInventoryOnHandByYearMonth(null, inventoryPeriodDto.YEAR_MONTH, ITEM_CD, LOC_CD, LOT_NO, PACK_NO);
        }
        public InventoryOnhandDTO LoadInventoryOnHandByItem(
            NZString ITEM_CD
            , NZString LOC_CD
            )
        {
            InventoryOnhandDAO dao = new InventoryOnhandDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadInventoryOnHandByItem(null, ITEM_CD, LOC_CD);
        }

        public InventoryOnhandDTO LoadInventoryOnHandOfDate(
            NZDateTime DATE
            , NZString ITEM_CD
            , NZString LOC_CD
            , NZString LOT_NO
            , NZString PACK_NO
            )
        {
            InventoryPeriodDAO inventoryPeriodDao = new InventoryPeriodDAO(CommonLib.Common.CurrentDatabase);

            InventoryPeriodDTO inventoryPeriodDto = inventoryPeriodDao.LoadPeriodByDate(null, DATE);
            if (inventoryPeriodDto == null)
                return null;

            return LoadInventoryOnHandByDate(inventoryPeriodDto.YEAR_MONTH, DATE, ITEM_CD, LOC_CD, LOT_NO, PACK_NO);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="STR_TRANS_DATE"></param>
        /// <param name="END_TRANS_DATE"></param>
        /// <param name="ITEM_CD"></param>
        /// <param name="LOC_CD"></param>
        /// <returns></returns>
        public List<InventoryTransactionDTO> LoadInventoryMovement(NZDateTime STR_TRANS_DATE, NZDateTime END_TRANS_DATE, NZString ITEM_CD, NZString LOC_CD, NZString LOT_NO)
        {
            InventoryTransactionDAO dao = new InventoryTransactionDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadTransactionsOnPeriod(null, STR_TRANS_DATE, END_TRANS_DATE, ITEM_CD, LOC_CD, LOT_NO);
        }

        public List<InventoryTransactionDTO> LoadInventoryMovementByLotNo(NZDateTime STR_TRANS_DATE, NZDateTime END_TRANS_DATE, NZString ITEM_CD, NZString LOC_CD, NZString LOT_NO)
        {
            InventoryTransactionDAO dao = new InventoryTransactionDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadTransactionsOnPeriodByLotNo(null, STR_TRANS_DATE, END_TRANS_DATE, ITEM_CD, LOC_CD, LOT_NO);
        }

        /// <summary>
        /// Load Lot for check exist for Item and Location
        /// </summary>
        /// <param name="ITEM_CD"></param>
        /// <param name="LOC_CD"></param>
        /// <param name="LOT_NO"></param>
        /// <returns></returns>


        public DataTable LoadAllLotNo(NZString YEAR_MONTH)
        {
            InventoryOnhandDAO dao = new InventoryOnhandDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadAllLotNo(null, YEAR_MONTH);
        }

        public DataTable LoadAllLotNoByItemAndLocation(NZString YEAR_MONTH, NZString ITEM_CD, NZString LOC_CD)
        {
            InventoryOnhandDAO dao = new InventoryOnhandDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadAllLotNoByItemAndLocation(null, YEAR_MONTH, ITEM_CD, LOC_CD);
        }

        public List<InventoryTransactionDTO> LoadInventoryTrans(InventoryTransactionDTO dto)
        {
            InventoryTransactionDAO inventoryTransactionDAO = new InventoryTransactionDAO(CommonLib.Common.CurrentDatabase);
            return inventoryTransactionDAO.Load(null, dto);
        }

        #endregion

        #region Issue By Item and Order
        /// <summary>
        /// Add Issue
        /// </summary>
        /// <param name="dtoInvTrnsList"></param>
        /// <param name="dtoInvOnHandList"></param>
        /// <returns></returns>
        /// <exception cref="Exception"><c>Exception</c>.</exception>
        public int AddIssueByItem(List<InventoryTransactionDTO> dtoInvTrnsList)//, List<InventoryOnhandDTO> dtoInvOnHandList)
        {
            // Comment out by pichet
            //CommonLib.Common.CurrentDatabase.KeepConnection = true;
            //CommonLib.Common.CurrentDatabase.BeginTransaction(IsolationLevel.Serializable);
            // end comment
            try
            {
                #region Validate Mandatory
                IssueEntryValidator valIssue = new IssueEntryValidator();
                InventoryOnhandValidator valINV = new InventoryOnhandValidator();

                // CHECK EXIST INVENTORY ONHAND
                for (int i = 0; i < dtoInvTrnsList.Count; i++)
                {
                    ErrorItem errorItem = null;


                    errorItem = valIssue.CheckIssueDate(dtoInvTrnsList[i].TRANS_DATE);
                    if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                    //if (dtoInvTrnsList[i].IN_OUT_CLS.StrongValue == DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.Out)) {
                    //    // NZString YearMonth = new NZString(null, dtoInvTrnsList[i].TRANS_DATE.StrongValue.ToString("yyyyMM"));

                    //    errorItem = valINV.CheckOnhandQty(dtoInvTrnsList[i].IN_OUT_CLS.StrongValue, dtoInvTrnsList[i].QTY, dtoInvTrnsList[i].ITEM_CD,
                    //                                        dtoInvTrnsList[i].LOC_CD, dtoInvTrnsList[i].LOT_NO);
                    //    if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);
                    //}


                }

                #endregion

                // lock transaction
                TransactionLockDAO daoTrans = new TransactionLockDAO(CommonLib.Common.CurrentDatabase);
                TransactionLockDTO dtoTrans = new TransactionLockDTO();
                NZString key1 = new NZString(null, "ISSUE_TRANS_ID");
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
                // end of lock transaction


                InventoryTransactionDAO InventoryTransaction = new InventoryTransactionDAO(CommonLib.Common.CurrentDatabase);

                RunningNumberBIZ bizRunning = new RunningNumberBIZ();
                NZString TransID = bizRunning.GetCompleteRunningNo(new NZString(null, "TRAN_ID"), new NZString(null, "TB_INV_TRANS_TR"));
                NZString RefID = bizRunning.GetCompleteRunningNo(new NZString(null, "TRAN_ID"), new NZString(null, "TB_INV_TRANS_TR"));

                // if load success then lock transaction
                daoTrans.SelectWithKeys(null, key1, key2);
                // end of lock transaction

                dtoInvTrnsList[0].TRANS_ID = TransID;
                dtoInvTrnsList[0].REF_NO = RefID;
                dtoInvTrnsList[1].TRANS_ID = RefID;
                dtoInvTrnsList[1].REF_NO = TransID;
                for (int i = 0; i < dtoInvTrnsList.Count; i++)
                {
                    InventoryTransaction.AddNew(null, dtoInvTrnsList[i]);
                }
                //InventoryOnhandDAO daoInventoryOnhand = new InventoryOnhandDAO(CommonLib.Common.CurrentDatabase);
                //for (int i = 0; i < dtoInvOnHandList.Count; i++)
                //{
                //    // check for exist first
                //    // if exist then update if not then add new 
                //    //if (daoInventoryOnhand.LoadInventoryOnHand(null
                //    //    , dtoInvOnHandList[i].YEAR_MONTH
                //    //    , dtoInvOnHandList[i].PERIOD_BEGIN_DATE
                //    //    , dtoInvOnHandList[i].PERIOD_END_DATE
                //    //    , dtoInvOnHandList[i].ITEM_CD
                //    //    , dtoInvOnHandList[i].LOC_CD
                //    //    , dtoInvOnHandList[i].LOT_NO) != null)
                //    //{
                //    //    daoInventoryOnhand.UpdateWithoutPK(null, dtoInvOnHandList[i]);
                //    //}
                //    //else
                //    //{
                //    //    daoInventoryOnhand.AddNew(null, dtoInvOnHandList[i]);
                //    //}
                //    daoInventoryOnhand.AddNewOrUpdate2(null, dtoInvOnHandList[i]);
                //}
                daoTrans.DeleteWithKeys(null, key1, key2);
                CommonLib.Common.CurrentDatabase.Commit();
            }
            catch (ValidateException)
            {
                CommonLib.Common.CurrentDatabase.Rollback();
                throw;
            }
            catch (BusinessException)
            {
                CommonLib.Common.CurrentDatabase.Rollback();
                throw;
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
            return 1;
        }

        /// <summary>
        /// Add Issue By Order
        /// </summary>
        /// <param name="dtoInvTrnsListFrom"></param>
        /// <param name="dtoInvTrnsListTo"></param>
        /// <param name="ItemCount"></param>
        /// <returns></returns>
        /// <exception cref="Exception"><c>Exception</c>.</exception>
        public int AddIssueByOrder(List<InventoryTransactionDTO> dtoInvTrnsListFrom, List<InventoryTransactionDTO> dtoInvTrnsListTo, int ItemCount) //, List<InventoryOnhandDTO> dtoInvOnHandListFrom, List<InventoryOnhandDTO> dtoInvOnHandListTo, int ItemCount)
        {
            CommonLib.Common.CurrentDatabase.KeepConnection = true;
            // lock transaction
            CommonLib.Common.CurrentDatabase.BeginTransaction(IsolationLevel.Serializable);

            try
            {
                #region Validate before Add
                #region Validate Mandatory
                IssueEntryValidator valIssue = new IssueEntryValidator();
                InventoryOnhandValidator valINV = new InventoryOnhandValidator();
                // CHECK EXIST INVENTORY ONHAND
                for (int i = 0; i < ItemCount; i++)
                {
                    ErrorItem errorItem = null;


                    errorItem = valIssue.CheckIssueDate(dtoInvTrnsListFrom[i].TRANS_DATE);
                    if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                    //errorItem = new ItemValidator().CheckItemNotExist(dtoInvTrnsListFrom[i].ITEM_CD).Error;
                    //if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                    errorItem = valIssue.CheckEmptyLocFrom(dtoInvTrnsListFrom[i].LOC_CD);
                    if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                    errorItem = valIssue.CheckEmptyLocTo(dtoInvTrnsListTo[i].LOC_CD);
                    if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                    errorItem = valIssue.CheckFromToLocation(dtoInvTrnsListFrom[i].LOC_CD, dtoInvTrnsListTo[i].LOC_CD);
                    if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                    //NZString YearMonth = new NZString(null, dtoInvTrnsListFrom[i].TRANS_DATE.StrongValue.ToString("yyyyMM"));
                    //errorItem = valINV.CheckOnhandQty(dtoInvTrnsListFrom[i].IN_OUT_CLS.StrongValue, dtoInvTrnsListFrom[i].QTY, dtoInvTrnsListFrom[i].ITEM_CD,
                    //                                    dtoInvTrnsListFrom[i].LOC_CD, dtoInvTrnsListFrom[i].LOT_NO);
                    //if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                }

                #endregion

                #endregion

                #region Lock Running Number gen.
                TransactionLockDAO daoTrans = new TransactionLockDAO(CommonLib.Common.CurrentDatabase);
                TransactionLockDTO dtoTrans = new TransactionLockDTO();
                NZString key1 = new NZString(null, "ISSUE_TRANS_ID");
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

                //InventoryTransactionDAO InventoryTransaction = new InventoryTransactionDAO(CommonLib.Common.CurrentDatabase);
                List<InventoryTransactionDTO> dtoList = new List<InventoryTransactionDTO>();

                RunningNumberBIZ bizRunning = new RunningNumberBIZ();
                NZString SlipNo = bizRunning.GetCompleteRunningNo(new NZString(null, "ISSUE_SLIP_NO"), new NZString(null, "TB_INV_TRANS_TR"));
                for (int i = 0; i < ItemCount; i++)
                {
                    #region Add Transaction
                    NZString TransID = bizRunning.GetCompleteRunningNo(new NZString(null, "TRAN_ID"), new NZString(null, "TB_INV_TRANS_TR"));
                    NZString RefID = bizRunning.GetCompleteRunningNo(new NZString(null, "TRAN_ID"), new NZString(null, "TB_INV_TRANS_TR"));

                    dtoInvTrnsListFrom[i].TRANS_ID = TransID;
                    dtoInvTrnsListFrom[i].REF_NO = RefID;
                    dtoInvTrnsListTo[i].TRANS_ID = RefID;
                    dtoInvTrnsListTo[i].REF_NO = TransID;

                    dtoInvTrnsListFrom[i].SLIP_NO = SlipNo;
                    dtoInvTrnsListTo[i].REF_SLIP_NO = SlipNo;

                    //InventoryTransaction.AddNew(null, dtoInvTrnsListFrom[i]);
                    //InventoryTransaction.AddNew(null, dtoInvTrnsListTo[i]);
                    dtoList.Add(dtoInvTrnsListFrom[i]);
                    dtoList.Add(dtoInvTrnsListTo[i]);
                    #endregion

                }
                AddInventoryTransactions(Common.CurrentDatabase, dtoList, false);
                daoTrans.DeleteWithKeys(null, key1, key2);
                CommonLib.Common.CurrentDatabase.Commit();
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

            return 1;
        }

        /// <summary>
        /// Update Issue By Item
        /// </summary>
        /// <param name="dtoInvTrnsList"></param>
        ///// <param name="dtoInvOnHandList"></param>
        /// <returns></returns>
        /// <exception cref="Exception"><c>Exception</c>.</exception>
        public int UpdateIssueByItem(List<InventoryTransactionDTO> dtoInvTrnsList)//, List<InventoryOnhandDTO> dtoInvOnHandList)
        {
            //CommonLib.Common.CurrentDatabase.KeepConnection = true;
            //CommonLib.Common.CurrentDatabase.BeginTransaction(IsolationLevel.Serializable);
            try
            {
                InventoryTransactionDAO InventoryTransaction = new InventoryTransactionDAO(CommonLib.Common.CurrentDatabase);

                for (int i = 0; i < dtoInvTrnsList.Count; i++)
                {
                    #region Validate Mandatory
                    IssueEntryValidator valIssue = new IssueEntryValidator();

                    ErrorItem errorItem = null;

                    errorItem = valIssue.CheckIssueDate(dtoInvTrnsList[i].TRANS_DATE);
                    if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                    //if (dtoInvTrnsList[i].IN_OUT_CLS.StrongValue == DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.Out))
                    //{
                    //    NZString YearMonth = new NZString(null, dtoInvTrnsList[i].TRANS_DATE.StrongValue.ToString("yyyyMM"));
                    //    errorItem = valIssue.CheckOnhandQty(dtoInvTrnsList[i].QTY, YearMonth, dtoInvTrnsList[i].ITEM_CD,
                    //                                        dtoInvTrnsList[i].LOC_CD, dtoInvTrnsList[i].LOT_NO);
                    //    if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);
                    //}

                    #endregion
                    InventoryTransaction.UpdateWithoutPK(null, dtoInvTrnsList[i]);
                    //    UpdateInventoryOnhand(CommonLib.Common.CurrentDatabase
                    //, dtoInvTrnsList[i].TRANS_DATE
                    //, dtoInvTrnsList[i].ITEM_CD
                    //, dtoInvTrnsList[i].LOC_CD
                    //, dtoInvTrnsList[i].LOT_NO
                    //, dtoInvTrnsList[i].IN_OUT_CLS// (NZString)DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.Out)
                    //, dtoInvTrnsList[i].QTY);
                }

                //UpdateInventoryOnhand(CommonLib.Common.CurrentDatabase
                //, uidmIssue.TRANS_DATE
                //, uidmIssue.ITEM_CD
                //, uidmIssue.FROM_LOC_CD
                //, uidmIssue.LOT_NO
                //, (NZString)DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.Out)
                //, uidmIssue.QTY);
                //UpdateInventoryOnhand(CommonLib.Common.CurrentDatabase
                //    , uidmIssue.TRANS_DATE
                //    , uidmIssue.ITEM_CD
                //    , uidmIssue.TO_LOC_CD
                //    , uidmIssue.LOT_NO
                //    , (NZString)DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.In)
                //    , uidmIssue.QTY);

                InventoryOnhandDAO daoInventoryOnhand = new InventoryOnhandDAO(CommonLib.Common.CurrentDatabase);
                //for (int i = 0; i < dtoInvOnHandList.Count; i++)
                //{
                //    // check for exist first
                //    // if exist then update if not then add new 
                //    //if (daoInventoryOnhand.LoadInventoryOnHand(null
                //    //    , dtoInvOnHandList[i].YEAR_MONTH
                //    //    , dtoInvOnHandList[i].PERIOD_BEGIN_DATE
                //    //    , dtoInvOnHandList[i].PERIOD_END_DATE
                //    //    , dtoInvOnHandList[i].ITEM_CD
                //    //    , dtoInvOnHandList[i].LOC_CD
                //    //    , dtoInvOnHandList[i].LOT_NO) != null)
                //    //{
                //    //    daoInventoryOnhand.UpdateWithoutPK(null, dtoInvOnHandList[i]);
                //    //}
                //    //else
                //    //{
                //    //    daoInventoryOnhand.AddNew(null, dtoInvOnHandList[i]);
                //    //}
                //    daoInventoryOnhand.AddNewOrUpdate2(null, dtoInvOnHandList[i]);
                //}
                // daoTrans.DeleteWithKeys(null, key1, key2);
                //CommonLib.Common.CurrentDatabase.Commit();
            }
            catch (Exception)
            {
                //CommonLib.Common.CurrentDatabase.Rollback();
                throw;
            }

            return 1;
        }

        #endregion

        /// <exception cref="Exception"><c>Exception</c>.</exception>
        public int ReceiveInventory(InventoryTransactionDTO dtoInvTrns, InventoryOnhandDTO dtoInvOnHand)
        {
            CommonLib.Common.CurrentDatabase.KeepConnection = true;
            try
            {
                // lock transaction
                TransactionLockDAO daoTrans = new TransactionLockDAO(CommonLib.Common.CurrentDatabase);
                TransactionLockDTO dtoTrans = new TransactionLockDTO();
                NZString key1 = new NZString(null, "TRANS_ID");
                NZString key2 = new NZString(null, "TB_INV_TRANS_TR");
                if (!daoTrans.Exist(null, key1, key2))
                {
                    dtoTrans.KEY1 = key1;
                    dtoTrans.KEY2 = key2;
                    dtoTrans.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                    dtoTrans.CRT_DATE.Value = DateTime.Now;
                    dtoTrans.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                    daoTrans.AddNew(null, dtoTrans);
                }
                // end of lock transaction

                CommonLib.Common.CurrentDatabase.BeginTransaction(IsolationLevel.Serializable);
                InventoryTransactionDAO InventoryTransaction = new InventoryTransactionDAO(CommonLib.Common.CurrentDatabase);

                RunningNumberBIZ bizRunning = new RunningNumberBIZ();
                NZString TransID = bizRunning.GetCompleteRunningNo(new NZString(null, "TRANS_ID"), new NZString(null, "TB_INV_TRANS_TR"));
                // NZString RefID = bizRunning.GetCompleteRunningNo(new NZString(null, "RECEIVE_TRANS_ID"), new NZString(null, "INV_TRANS_TR"));

                // if load success then lock transaction
                daoTrans.SelectWithKeys(null, key1, key2);
                // end of lock transaction

                dtoInvTrns.TRANS_ID = TransID;
                //dtoInvTrns.REF_NO = RefID;

                InventoryTransaction.AddNew(null, dtoInvTrns);

                InventoryOnhandDAO daoInventoryOnhand = new InventoryOnhandDAO(CommonLib.Common.CurrentDatabase);

                // check for exist first
                // if exist then update if not then add new 
                if (daoInventoryOnhand.LoadInventoryOnHand(null
                    , dtoInvOnHand.YEAR_MONTH
                    , dtoInvOnHand.PERIOD_BEGIN_DATE
                    , dtoInvOnHand.PERIOD_END_DATE
                    , dtoInvOnHand.ITEM_CD
                    , dtoInvOnHand.LOC_CD
                    , dtoInvOnHand.LOT_NO) != null)
                {
                    daoInventoryOnhand.UpdateWithoutPK(null, dtoInvOnHand);
                }
                else
                {
                    daoInventoryOnhand.AddNew(null, dtoInvOnHand);
                }


                daoTrans.DeleteWithKeys(null, key1, key2);
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
            return 1;
        }

        /// <exception cref="Exception"><c>Exception</c>.</exception>
        public int ShipInventory(InventoryTransactionDTO dtoInvTrns, InventoryOnhandDTO dtoInvOnHand)
        {
            CommonLib.Common.CurrentDatabase.KeepConnection = true;
            try
            {
                // lock transaction
                TransactionLockDAO daoTrans = new TransactionLockDAO(CommonLib.Common.CurrentDatabase);
                TransactionLockDTO dtoTrans = new TransactionLockDTO();
                NZString key1 = new NZString(null, "SHIP_TRANS_ID");
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
                // end of lock transaction

                CommonLib.Common.CurrentDatabase.BeginTransaction(IsolationLevel.Serializable);
                InventoryTransactionDAO InventoryTransaction = new InventoryTransactionDAO(CommonLib.Common.CurrentDatabase);

                RunningNumberBIZ bizRunning = new RunningNumberBIZ();
                NZString TransID = bizRunning.GetCompleteRunningNo(new NZString(null, "SHIP_TRANS_ID"), new NZString(null, "INV_TRANS_TR"));
                // NZString RefID = bizRunning.GetCompleteRunningNo(new NZString(null, "RECEIVE_TRANS_ID"), new NZString(null, "INV_TRANS_TR"));

                // if load success then lock transaction
                daoTrans.SelectWithKeys(null, key1, key2);
                // end of lock transaction

                dtoInvTrns.TRANS_ID = TransID;
                //dtoInvTrns.REF_NO = RefID;

                InventoryTransaction.AddNew(null, dtoInvTrns);

                InventoryOnhandDAO daoInventoryOnhand = new InventoryOnhandDAO(CommonLib.Common.CurrentDatabase);

                // check for exist first
                // if exist then update if not then add new 
                if (daoInventoryOnhand.LoadInventoryOnHand(null
                    , dtoInvOnHand.YEAR_MONTH
                    , dtoInvOnHand.PERIOD_BEGIN_DATE
                    , dtoInvOnHand.PERIOD_END_DATE
                    , dtoInvOnHand.ITEM_CD
                    , dtoInvOnHand.LOC_CD
                    , dtoInvOnHand.LOT_NO) != null)
                {
                    daoInventoryOnhand.UpdateWithoutPK(null, dtoInvOnHand);
                }
                else
                {
                    daoInventoryOnhand.AddNew(null, dtoInvOnHand);
                }


                daoTrans.DeleteWithKeys(null, key1, key2);
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
            return 1;
        }

        #region [Common Main Method] Update Inventory onHand

        ///// <summary>
        ///// Main Method:ใช้ function นี้เป็นตัวหลักในการจัดการเกี่ยวกับ onhand ที่มีในทุกหน้า transaction
        ///// โดยจะมีการ check transaction date และในกรณีที่เป็นการ out
        ///// จะ check ให้ว่า Location นั้นมีการ allow negative หรือไม่
        ///// และจะ throw error เมื่อมี onhand ไม่พอต่อ qty นั้น
        ///// </summary>
        ///// <param name="database"></param>
        ///// <param name="transDate"></param>
        ///// <param name="itemCode"></param>
        ///// <param name="storedLocationCode"></param>
        ///// <param name="lotNo"></param>
        ///// <param name="inOutType"></param>
        ///// <param name="Qty">In case of Update or Delete  Qty = Diff Qty else Qty</param>
        ///// <param name="eOperationCls"></param>
        //public void UpdateInventoryOnhand(Database database, NZDateTime transDate, NZString itemCode, NZString storedLocationCode, NZString lotNo, NZString inOutType, NZDecimal Qty, DataDefine.eTRANS_TYPE TranType, DataDefine.eOperationClass eOperationCls)
        public void UpdateInventoryOnhand(Database database
            //, NZDateTime transDate, NZString itemCode, NZString storedLocationCode, NZString lotNo, NZString inOutType, NZDecimal Qty, DataDefine.eTRANS_TYPE TranType, DataDefine.eOperationClass eOperationCls
            , InventoryTransactionDTO argTransactionDTO, DataDefine.eOperationClass eOperationCls
            )
        {
            DataDefine.eIN_OUT_CLASS inOutClass = DataDefine.ConvertValue2Enum<DataDefine.eIN_OUT_CLASS>(argTransactionDTO.IN_OUT_CLS.StrongValue);

            if (inOutClass == DataDefine.eIN_OUT_CLASS.None)
                return;

            // Check transDate is in current period.

            NZString strYEAR_MONTH = argTransactionDTO.TRANS_DATE.StrongValue.ToString("yyyyMM").ToNZString();

            //Check transaction in Current Period and Next period
            TransactionValidator valTrn = new TransactionValidator();
            ErrorItem err2 = valTrn.DateIsInCurrentPeriod(argTransactionDTO.TRANS_DATE.StrongValue);
            if (err2 != null)
            {
                ValidateException.ThrowErrorItem(err2);
            }
            InventoryOnhandDAO inventoryOnhandDAO = new InventoryOnhandDAO(database);

            NZDateTime PeriodStart = null;
            NZDateTime PeriodEnd = null;
            NZDateTime dtLAST_RECEIVE_DATE = new NZDateTime(null, null);
            PeriodStart = new NZDateTime(null, new DateTime(argTransactionDTO.TRANS_DATE.StrongValue.Year, argTransactionDTO.TRANS_DATE.StrongValue.Month, 1));
            PeriodEnd = new NZDateTime(null, new DateTime(argTransactionDTO.TRANS_DATE.StrongValue.Year, argTransactionDTO.TRANS_DATE.StrongValue.Month,
                                                               DateTime.DaysInMonth(argTransactionDTO.TRANS_DATE.StrongValue.Year,
                                                                                    argTransactionDTO.TRANS_DATE.StrongValue.Month)));


            // change AdjustQty on current record.
            if (inOutClass == DataDefine.eIN_OUT_CLASS.In)
            {
                // Update Last receive Date ใน Tb on-hand 
                // --> Update เฉพาะ Case receive (Type receive)
                // , Issue (transfer In), Issue Return (transfer In), Work Result (WIP in)
                if ((eOperationCls != DataDefine.eOperationClass.Delete)
                    //&& (TranType == DataDefine.eTRANS_TYPE.Receiving ||
                    //TranType == DataDefine.eTRANS_TYPE.Issuing ||
                    //TranType == DataDefine.eTRANS_TYPE.Issuing_Return ||
                    //TranType == DataDefine.eTRANS_TYPE.WorkResult ||
                    //TranType == DataDefine.eTRANS_TYPE.ReserveResult)
                    )
                {
                    dtLAST_RECEIVE_DATE = CommonLib.Common.GetDatabaseDateTime().ToNZDateTime();
                }
            }

            DealingConstraintBIZ constraintBiz = new DealingConstraintBIZ();
            DealingConstraintDTO constraintDTO = constraintBiz.LoadDealingConstraint(argTransactionDTO.LOC_CD);


            if (constraintDTO.LOT_CONTROL_FLAG.NVL(0) != 1)
            {
                argTransactionDTO.LOT_NO = new NZString(argTransactionDTO.LOT_NO.Owner, "");
                argTransactionDTO.PACK_NO = new NZString(argTransactionDTO.PACK_NO.Owner, "");
                argTransactionDTO.EXTERNAL_LOT_NO = new NZString(argTransactionDTO.EXTERNAL_LOT_NO.Owner, "");
            }



            inventoryOnhandDAO.UpdateInventoryOnhand(null, strYEAR_MONTH, argTransactionDTO, CommonLib.Common.CurrentUserInfomation.UserCD, CommonLib.Common.CurrentUserInfomation.Machine, dtLAST_RECEIVE_DATE, PeriodStart, PeriodEnd);

            //Check Allow Negative Location After Update on Hand
            #region Check Allow Negative Location
            //Check Allow Negative Location
            InventoryOnhandValidator valINV = new InventoryOnhandValidator();
            ErrorItem err = valINV.CheckOnhandQty_AfterTR(database, argTransactionDTO.QTY.Owner, argTransactionDTO.ITEM_CD, argTransactionDTO.LOC_CD, argTransactionDTO.LOT_NO);
            if (err != null)
            {
                ValidateException.ThrowErrorItem(err);
            }
            //End
            #endregion

        }



        #endregion

        #region [Common Main Method] AddNew / Update / Delete Inventory Transaction Record.
        public void AddInventoryTransactions(Database database, List<InventoryTransactionDTO> listData, bool isGenTransID)
        {
            for (int i = 0; i < listData.Count; i++)
            {
                AddInventoryTransaction(database, listData[i], isGenTransID);
            }
        }

        //public void AddInventoryTransactions_Return(Database database, List<InventoryTransactionDTO> listData, bool isGenTransID)
        //{
        //    for (int i = 0; i < listData.Count; i++)
        //    {
        //        AddInventoryTransaction_Return(database, listData[i], isGenTransID);
        //    }
        //}

        /// <summary>
        /// Add new transaction. ใช้กรณีเพิ่ม Transaction ตัวใหม่  ซึ่งอาจจะกระทบต่อตาราง Inventory Onhand
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        public void AddInventoryTransaction(Database database, InventoryTransactionDTO data, bool isGenTransID)
        {
            string transTypeCode = DataDefine.Convert2ClassCode(data.TRANS_CLS.Value);
            DataDefine.eTRANS_TYPE transType = DataDefine.ConvertValue2Enum<DataDefine.eTRANS_TYPE>(transTypeCode);

            //== Dispatcher Transaction Type.
            RunningNumberBIZ bizRunning = new RunningNumberBIZ();

            //switch (transType)
            //{
            //    case DataDefine.eTRANS_TYPE.Receiving:
            //    case DataDefine.eTRANS_TYPE.Receive_Return:
            //    case DataDefine.eTRANS_TYPE.Issuing:
            //    case DataDefine.eTRANS_TYPE.Issuing_Return:
            //    case DataDefine.eTRANS_TYPE.Issue_Consumption:
            //    case DataDefine.eTRANS_TYPE.Shipment_Return:
            //    case DataDefine.eTRANS_TYPE.Adjustment:
            //if (data.IN_OUT_CLS.StrongValue == DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.In))
            //{
            if (data.LOC_CD.StrongValue == DataDefine.LOCATION_SCRAP)
            {
                data.LOT_NO.Value = DataDefine.LOT_SCRAP;
            }

            DealingBIZ bizLoc = new DealingBIZ();
            DealingDTO dtoLoc = bizLoc.LoadLocation(data.LOC_CD);

            if (dtoLoc != null &&
                (dtoLoc.LOC_CLS.StrongValue == DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Customer) ||
                dtoLoc.LOC_CLS.StrongValue == DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.CustomerVendor) ||
                dtoLoc.LOC_CLS.StrongValue == DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Vendor)))
            {
                string supplyLot = DataDefine.LOT_SUPPLIER;
                //data.LOT_NO.Value = DataDefine.LOT_SUPPLIER;
            }
            //}
            //        break;
            // }


            if (isGenTransID)
            {
                // Generate new Transaction ID.
                NZString TransID = bizRunning.GetCompleteRunningNo(new NZString(null, "TRAN_ID"), new NZString(null, "TB_INV_TRANS_TR"));
                data.TRANS_ID = TransID;
            }
            // Add Inventory transaction.
            InventoryTransactionDAO dao = new InventoryTransactionDAO(database);
            ShipmentDAO_Add daoShipment = new ShipmentDAO_Add();

            if (dao.AddNew(null, data) <= 0)
                throw new ValidateException("Insert failed. Data is missing, Please check your data.");

            //data.TRANS_CLS = transType;
            // Start update stock.

            UpdateInventoryOnhand(database, data, DataDefine.eOperationClass.Add);

            if (data.TRANS_CLS == DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Shipment))
            {
                daoShipment.UpdateCustomerOrderStatus(database, data.REF_SLIP_NO.StrongValue.ToNZString(), data.QTY.StrongValue);
            }
            if (data.TRANS_CLS == DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Shipment_Return))
            {
                // Update Return QTY ของ Delivery TransID ที่ Return Item อ้างถึง
                InventoryTransactionDTO inventoryTransactionDTO = dao.LoadByPK(database, data.REF_NO.StrongValue);
                ReturnBIZ bizReturn = new ReturnBIZ();
                decimal diffQTY = data.QTY.StrongValue;
                bizReturn.UpdateReturnQTY(database, inventoryTransactionDTO.TRANS_ID, diffQTY.ToNZDecimal(), Common.CurrentUserInfomation.UserCD, Common.CurrentUserInfomation.Machine);
                // Update Ship QTY ของ Customer Order => Order Detail No.
                daoShipment.UpdateCustomerOrderStatus(database, data.REF_SLIP_NO.StrongValue.ToNZString(), data.QTY.StrongValue * -1);
            }
            //if (data.TRANS_CLS == DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Receiving))
            //{
            //    dao.UpdatePOBalance(null, data, data.QTY.StrongValue);
            //}

        }

        //public void AddInventoryTransaction_Return(Database database, InventoryTransactionDTO data, bool isGenTransID)
        //{
        //    string transTypeCode = DataDefine.Convert2ClassCode(data.TRANS_CLS.Value);
        //    DataDefine.eTRANS_TYPE transType = DataDefine.ConvertValue2Enum<DataDefine.eTRANS_TYPE>(transTypeCode);

        //    //== Dispatcher Transaction Type.
        //    RunningNumberBIZ bizRunning = new RunningNumberBIZ();

        //    //switch (transType)
        //    //{
        //    //    case DataDefine.eTRANS_TYPE.Receiving:
        //    //    case DataDefine.eTRANS_TYPE.Receive_Return:
        //    //    case DataDefine.eTRANS_TYPE.Issuing:
        //    //    case DataDefine.eTRANS_TYPE.Issuing_Return:
        //    //    case DataDefine.eTRANS_TYPE.Issue_Consumption:
        //    //    case DataDefine.eTRANS_TYPE.Shipment_Return:
        //    //    case DataDefine.eTRANS_TYPE.Adjustment:
        //    //if (data.IN_OUT_CLS.StrongValue == DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.In))
        //    //{
        //    if (data.LOC_CD.StrongValue == DataDefine.LOCATION_SCRAP)
        //    {
        //        data.LOT_NO.Value = DataDefine.LOT_SCRAP;
        //    }

        //    DealingBIZ bizLoc = new DealingBIZ();
        //    DealingDTO dtoLoc = bizLoc.LoadLocation(data.LOC_CD);

        //    if (dtoLoc != null &&
        //        (dtoLoc.LOC_CLS.StrongValue == DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Customer) ||
        //        dtoLoc.LOC_CLS.StrongValue == DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.CustomerVendor) ||
        //        dtoLoc.LOC_CLS.StrongValue == DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Vendor)))
        //    {
        //        string supplyLot = DataDefine.LOT_SUPPLIER;
        //        //data.LOT_NO.Value = DataDefine.LOT_SUPPLIER;
        //    }
        //    //}
        //    //        break;
        //    // }


        //    if (isGenTransID)
        //    {
        //        // Generate new Transaction ID.
        //        NZString TransID = bizRunning.GetCompleteRunningNo(new NZString(null, "TRAN_ID"), new NZString(null, "TB_INV_TRANS_TR"));
        //        data.TRANS_ID = TransID;
        //    }

        //    // Add Inventory transaction.
        //    InventoryTransactionDAO dao = new InventoryTransactionDAO(database);
        //    ShipmentDAO_Add daoShipment = new ShipmentDAO_Add();

        //    if (dao.AddNew(null, data) <= 0)
        //        throw new ValidateException("Insert failed. Data is missing, Please check your data.");

        //    InventoryTransactionDTO inventoryTransactionDTO = dao.LoadByPK(database, data.REF_NO.StrongValue);
        //    ReturnBIZ bizReturn = new ReturnBIZ();
        //    //decimal diffQTY = inventoryTransactionDTO.RETURN_QTY.IsNull ? 0 : inventoryTransactionDTO.RETURN_QTY.StrongValue;
        //    decimal diffQTY = data.QTY.StrongValue;
        //    bizReturn.UpdateReturnQTY(database, inventoryTransactionDTO.TRANS_ID, diffQTY.ToNZDecimal(), Common.CurrentUserInfomation.UserCD, Common.CurrentUserInfomation.Machine);

        //    UpdateInventoryOnhand(database, data, DataDefine.eOperationClass.Add);

        //    if (data.TRANS_CLS.StrongValue == DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Shipment))
        //        daoShipment.UpdateCustomerOrderStatus(database, data.REF_SLIP_NO.StrongValue.ToNZString(), data.QTY.StrongValue);
        //    if (data.TRANS_CLS.StrongValue == DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Shipment_Return))
        //        daoShipment.UpdateCustomerOrderStatus(database, data.REF_SLIP_NO.StrongValue.ToNZString(), data.QTY.StrongValue * -1);

        //}

        public void UpdateInventoryTransactions(Database database, List<InventoryTransactionDTO> listData)
        {
            for (int i = 0; i < listData.Count; i++)
            {
                UpdateInventoryTransaction(database, listData[i].TRANS_ID, listData[i]);
            }
        }

        //public void UpdateInventoryTransactions_Return(Database database, List<InventoryTransactionDTO> listData)
        //{
        //    for (int i = 0; i < listData.Count; i++)
        //    {
        //        UpdateInventoryTransaction_Return(database, listData[i].TRANS_ID, listData[i]);
        //    }
        //}
        /// <summary>
        /// ใช้กรณีต้องการ Adjust Transaction ตัวเก่า
        /// </summary>
        /// <param name="database"></param>
        /// <param name="oldData"></param>
        /// <param name="newData"></param>        
        public void UpdateInventoryTransaction(Database database, InventoryTransactionDTO oldData, InventoryTransactionDTO newData)
        {
            string transTypeCode = DataDefine.Convert2ClassCode(newData.TRANS_CLS.Value);
            DataDefine.eTRANS_TYPE transType = DataDefine.ConvertValue2Enum<DataDefine.eTRANS_TYPE>(transTypeCode);

            if (oldData.ITEM_CD.ToString() != newData.ITEM_CD.ToString() || oldData.LOC_CD.ToString() != newData.LOC_CD.ToString()
                || oldData.LOT_NO.ToString() != newData.LOT_NO.ToString() || oldData.PACK_NO.ToString() != newData.PACK_NO.ToString())
            {
                throw new ValidateException("Update failed. Data is changing, Please check your data.");
            }

            decimal diffQty = newData.QTY.StrongValue - oldData.QTY.StrongValue;
            newData.TRANS_ID = oldData.TRANS_ID;


            if (newData.LOC_CD.StrongValue == DataDefine.LOCATION_SCRAP)
            {
                newData.LOT_NO.Value = DataDefine.LOT_SCRAP;
            }

            DealingBIZ bizLoc = new DealingBIZ();
            DealingDTO dtoLoc = bizLoc.LoadLocation(newData.LOC_CD);
            if (dtoLoc.LOC_CLS.StrongValue == DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Customer) ||
                dtoLoc.LOC_CLS.StrongValue == DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.CustomerVendor) ||
                dtoLoc.LOC_CLS.StrongValue == DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Vendor))
            {

                string supplyLot = DataDefine.LOT_SUPPLIER;
                //newData.LOT_NO.Value = DataDefine.LOT_SUPPLIER;
            }

            // Add Inventory transaction.
            InventoryTransactionDAO dao = new InventoryTransactionDAO(database);
            if (dao.UpdateWithoutPK(null, newData) <= 0)
                throw new ValidateException("Update failed. Data is missing, Please check your data.");

            // Start update stock.
            newData.QTY = (NZDecimal)diffQty;
            UpdateInventoryOnhand(database, newData, DataDefine.eOperationClass.Update);

            if (newData.TRANS_CLS.StrongValue == DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Shipment_Return))
            {
                // Update Return QTY ของ Delivery TransID ที่ Return Item อ้างถึง
                ReturnBIZ bizReturn = new ReturnBIZ();
                bizReturn.UpdateReturnQTY(database, newData.REF_NO, newData.QTY, Common.CurrentUserInfomation.UserCD, Common.CurrentUserInfomation.Machine);
                // Update Ship QTY ของ Customer Order => Order Detail No.
                ShipmentDAO_Add daoShipment = new ShipmentDAO_Add();
                daoShipment.UpdateCustomerOrderStatus(database, newData.REF_SLIP_NO.StrongValue.ToNZString(), newData.QTY.StrongValue * -1);
            }

            //if (newData.TRANS_CLS == DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Receiving))
            //{
            //    // Update Balance
            //    dao.UpdatePOBalance(null, newData, diffQty);
            //}

        }

        //public void UpdateInventoryTransaction_Return(Database database, InventoryTransactionDTO oldData, InventoryTransactionDTO newData)
        //{
        //    string transTypeCode = DataDefine.Convert2ClassCode(newData.TRANS_CLS.Value);
        //    DataDefine.eTRANS_TYPE transType = DataDefine.ConvertValue2Enum<DataDefine.eTRANS_TYPE>(transTypeCode);

        //    if (oldData.ITEM_CD.ToString() != newData.ITEM_CD.ToString() || oldData.LOC_CD.ToString() != newData.LOC_CD.ToString()
        //        || oldData.LOT_NO.ToString() != newData.LOT_NO.ToString() || oldData.PACK_NO.ToString() != newData.PACK_NO.ToString())
        //    {
        //        throw new ValidateException("Update failed. Data is changing, Please check your data.");
        //    }

        //    decimal diffQty = newData.QTY.StrongValue - oldData.QTY.StrongValue;
        //    newData.TRANS_ID = oldData.TRANS_ID;


        //    if (newData.LOC_CD.StrongValue == DataDefine.LOCATION_SCRAP)
        //    {
        //        newData.LOT_NO.Value = DataDefine.LOT_SCRAP;
        //    }

        //    DealingBIZ bizLoc = new DealingBIZ();
        //    DealingDTO dtoLoc = bizLoc.LoadLocation(newData.LOC_CD);
        //    if (dtoLoc.LOC_CLS.StrongValue == DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Customer) ||
        //        dtoLoc.LOC_CLS.StrongValue == DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.CustomerVendor) ||
        //        dtoLoc.LOC_CLS.StrongValue == DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Vendor))
        //    {

        //        string supplyLot = DataDefine.LOT_SUPPLIER;
        //        //newData.LOT_NO.Value = DataDefine.LOT_SUPPLIER;
        //    }

        //    // Add Inventory transaction.
        //    InventoryTransactionDAO dao = new InventoryTransactionDAO(database);
        //    if (dao.UpdateWithoutPK(null, newData) <= 0)
        //        throw new ValidateException("Update failed. Data is missing, Please check your data.");

        //    // Start update stock.
        //    newData.QTY = (NZDecimal)diffQty;

        //    //InventoryTransactionDTO inventoryTransactionDTO = dao.LoadByPK(database, newData.REF_NO.StrongValue);
        //    ReturnBIZ bizReturn = new ReturnBIZ();
        //    //decimal diffQTY = inventoryTransactionDTO.RETURN_QTY.IsNull ? 0 : inventoryTransactionDTO.RETURN_QTY.StrongValue;
        //    //diffQTY += newData.QTY.StrongValue;

        //    bizReturn.UpdateReturnQTY(database, newData.REF_NO, newData.QTY, Common.CurrentUserInfomation.UserCD, Common.CurrentUserInfomation.Machine);

        //    ShipmentDAO_Add daoShipment = new ShipmentDAO_Add();
        //    if (newData.TRANS_CLS.StrongValue == DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Shipment_Return))
        //        daoShipment.UpdateCustomerOrderStatus(database, newData.REF_SLIP_NO.StrongValue.ToNZString(), newData.QTY.StrongValue * -1);

        //    //UpdateInventoryOnhand(database, newData, DataDefine.eOperationClass.Update);

        //    //if (newData.TRANS_CLS == DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Receiving))
        //    //{
        //    //    // Update Balance
        //    //    dao.UpdatePOBalance(null, newData, diffQty);
        //    //}

        //}

        public void UpdateInventoryTransaction(Database database, NZString TRANS_ID, InventoryTransactionDTO newData)
        {
            InventoryTransactionDAO dao = new InventoryTransactionDAO(database);
            InventoryTransactionDTO dto = dao.LoadByPK(null, TRANS_ID);
            UpdateInventoryTransaction(database, dto, newData);
        }

        //public void UpdateInventoryTransaction_Return(Database database, NZString TRANS_ID, InventoryTransactionDTO newData)
        //{
        //    InventoryTransactionDAO dao = new InventoryTransactionDAO(database);
        //    InventoryTransactionDTO dto = dao.LoadByPK(null, TRANS_ID);
        //    UpdateInventoryTransaction_Return(database, dto, newData);
        //}

        public void DeleteInventoryTransactions(Database database, List<InventoryTransactionDTO> listItems)
        {

            for (int i = 0; i < listItems.Count; i++)
            {
                DeleteInventoryTransaction(database, listItems[i].TRANS_ID);
            }
        }

        //public void DeleteInventoryTransactionsList_Return(Database database, List<InventoryTransactionDTO> listItems)
        //{

        //    for (int i = 0; i < listItems.Count; i++)
        //    {
        //        DeleteInventoryTransaction_Return(database, listItems[i].TRANS_ID);
        //    }
        //}

        public void DeleteInventoryTransactions(Database database, List<NZString> listTranID)
        {
            for (int i = 0; i < listTranID.Count; i++)
            {
                DeleteInventoryTransaction(database, listTranID[i]);
            }
        }

        /// <summary>
        /// Delete transaction by TRANS_ID and Update OnHand Qty
        /// </summary>
        /// <param name="database"></param>
        /// <param name="TRANS_ID"></param>
        public void DeleteInventoryTransaction(Database database, NZString TRANS_ID)
        {

            InventoryTransactionDAO inventoryTransactionDAO = new InventoryTransactionDAO(database);

            //== Load Transaction.
            InventoryTransactionDTO inventoryTransactionDTO = inventoryTransactionDAO.LoadByPK(database, TRANS_ID);
            if (inventoryTransactionDTO == null)
                return;// throw new ValidateException("Delete failed. Data is missing, Please check your data.");


            //Delete data
            // int kk = inventoryTransactionDAO.Delete(database, TRANS_ID);
            if (inventoryTransactionDAO.Delete(database, TRANS_ID) <= 0)
                throw new ValidateException("Delete failed. Data is missing, Please check your data.");

            // inverse Qty
            inventoryTransactionDTO.QTY = (-1 * inventoryTransactionDTO.QTY.StrongValue).ToNZDecimal();

            //Update onhand
            UpdateInventoryOnhand(database, inventoryTransactionDTO, DataDefine.eOperationClass.Delete);

            ShipmentDAO_Add daoShipment = new ShipmentDAO_Add();
            if (inventoryTransactionDTO.TRANS_CLS.StrongValue == DataDefine.eTRANS_TYPE_string.Shipment)
                daoShipment.UpdateCustomerOrderStatus(database, inventoryTransactionDTO.REF_SLIP_NO.StrongValue.ToNZString(), inventoryTransactionDTO.QTY.StrongValue);
            if (inventoryTransactionDTO.TRANS_CLS.StrongValue == DataDefine.eTRANS_TYPE_string.Shipment_Return)
            {
                // Update Return QTY ของ Delivery TransID ที่ Return Item อ้างถึง
                ReturnDAO daoReturn = new ReturnDAO(database);
                daoReturn.UpdateReturnQTY(inventoryTransactionDTO.REF_NO, (inventoryTransactionDTO.QTY.StrongValue).ToNZDecimal(), Common.CurrentUserInfomation.UserCD, Common.CurrentUserInfomation.Machine);
                // Update Ship QTY ของ Customer Order => Order Detail No.
                InventoryTransactionDTO inventoryTransactionDTO_Delivery = inventoryTransactionDAO.LoadByPK(database, inventoryTransactionDTO.REF_NO.StrongValue);
                daoShipment.UpdateCustomerOrderStatus(database, inventoryTransactionDTO_Delivery.REF_SLIP_NO.StrongValue.ToNZString(), inventoryTransactionDTO.QTY.StrongValue * -1);
            }

            //// if Data = 'RCV' --> Update PO Balance
            //if (inventoryTransactionDTO.TRANS_CLS == DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Receiving))
            //{
            //    inventoryTransactionDAO.UpdatePOBalance(database, inventoryTransactionDTO, inventoryTransactionDTO.QTY.StrongValue);
            //}

        }

        //public void DeleteInventoryTransaction_Return(Database database, NZString TRANS_ID)
        //{

        //    InventoryTransactionDAO inventoryTransactionDAO = new InventoryTransactionDAO(database);

        //    //== Load Transaction.
        //    InventoryTransactionDTO inventoryTransactionDTO_Return = inventoryTransactionDAO.LoadByPK(database, TRANS_ID);
        //    if (inventoryTransactionDTO_Return == null)
        //        return;// throw new ValidateException("Delete failed. Data is missing, Please check your data.");


        //    //Delete data
        //    // int kk = inventoryTransactionDAO.Delete(database, TRANS_ID);
        //    if (inventoryTransactionDAO.Delete(database, TRANS_ID) <= 0)
        //        throw new ValidateException("Delete failed. Data is missing, Please check your data.");

        //    // Load Original Delivey Trans for Update new return QTY by ( Original Return QTY - Remove Return QTY )
        //    InventoryTransactionDTO inventoryTransactionDTO = inventoryTransactionDAO.LoadByPK(database, inventoryTransactionDTO_Return.REF_NO.StrongValue);
        //    decimal diffReturnQTY = 0;
        //    diffReturnQTY = inventoryTransactionDTO_Return.QTY.StrongValue * -1;

        //    ReturnDAO daoReturn = new ReturnDAO(database);
        //    daoReturn.UpdateReturnQTY(inventoryTransactionDTO_Return.REF_NO, diffReturnQTY.ToNZDecimal(), Common.CurrentUserInfomation.UserCD, Common.CurrentUserInfomation.Machine);
        //    //Update onhand
        //    //UpdateInventoryOnhand(database, inventoryTransactionDTO, DataDefine.eOperationClass.Delete);

        //    ShipmentDAO_Add daoShipment = new ShipmentDAO_Add();

        //    if (inventoryTransactionDTO_Return.TRANS_CLS.StrongValue == DataDefine.eTRANS_TYPE_string.Shipment_Return)
        //        daoShipment.UpdateCustomerOrderStatus(database, inventoryTransactionDTO_Return.REF_SLIP_NO.StrongValue.ToNZString(), inventoryTransactionDTO_Return.QTY.StrongValue);
        //    //// if Data = 'RCV' --> Update PO Balance
        //    //if (inventoryTransactionDTO.TRANS_CLS == DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Receiving))
        //    //{
        //    //    inventoryTransactionDAO.UpdatePOBalance(database, inventoryTransactionDTO, inventoryTransactionDTO.QTY.StrongValue);
        //    //}

        //}

        public void DeleteInventoryPack(Database database, NZString TRANS_ID)
        {

            InventoryTransactionDAO inventoryTransactionDAO = new InventoryTransactionDAO(database);

            //== Load Transaction.
            InventoryTransactionDTO param = new InventoryTransactionDTO();
            InventoryTransactionDTO inventoryTransactionDTO = inventoryTransactionDAO.LoadByPK(database, TRANS_ID);
            param.ITEM_CD = inventoryTransactionDTO.ITEM_CD;
            param.PACK_NO = inventoryTransactionDTO.PACK_NO;
            param.LOC_CD = inventoryTransactionDTO.LOC_CD;
            param.SLIP_NO = inventoryTransactionDTO.SLIP_NO;

            List<InventoryTransactionDTO> listInventoryTransactionDTO = inventoryTransactionDAO.Load(database, param);
            if (listInventoryTransactionDTO == null || listInventoryTransactionDTO.Count <= 0)
                return;// throw new ValidateException("Delete failed. Data is missing, Please check your data.");

            for (int i = 0; i < listInventoryTransactionDTO.Count; i++)
            {
                DeleteInventoryTransaction(database, listInventoryTransactionDTO[i].TRANS_ID);
            }


        }

        //public void DeleteInventorySlipNo_Return(Database database, NZString SlipNo)
        //{

        //    InventoryTransactionDAO inventoryTransactionDAO = new InventoryTransactionDAO(database);

        //    //== Load Transaction.
        //    InventoryTransactionDTO param = new InventoryTransactionDTO();
        //    InventoryTransactionDTO inventoryTransactionDTO = new InventoryTransactionDTO();
        //    param.SLIP_NO = SlipNo;
        //    param.TRANS_CLS = DataDefine.eTRANS_TYPE_string.Shipment_Return.ToNZString();
        //    List<InventoryTransactionDTO> listInventoryTransactionDTO = inventoryTransactionDAO.Load(database, param);
        //    if (listInventoryTransactionDTO == null || listInventoryTransactionDTO.Count <= 0)
        //        return;// throw new ValidateException("Delete failed. Data is missing, Please check your data.");

        //    for (int i = 0; i < listInventoryTransactionDTO.Count; i++)
        //    {
        //        DeleteInventoryTransaction_Return(database, listInventoryTransactionDTO[i].TRANS_ID);
        //    }


        //}

        public void DeleteInventoryOrder(Database database, NZString transID)
        {

            InventoryTransactionDAO inventoryTransactionDAO = new InventoryTransactionDAO(database);

            //== Load Transaction.
            InventoryTransactionDTO param = new InventoryTransactionDTO();
            InventoryTransactionDTO inventoryTransactionDTO = inventoryTransactionDAO.LoadByPK(database, transID);
            param.REF_SLIP_NO = inventoryTransactionDTO.REF_SLIP_NO;
            param.SLIP_NO = inventoryTransactionDTO.SLIP_NO;

            List<InventoryTransactionDTO> listInventoryTransactionDTO = inventoryTransactionDAO.Load(database, param);
            if (listInventoryTransactionDTO == null || listInventoryTransactionDTO.Count <= 0)
                return;// throw new ValidateException("Delete failed. Data is missing, Please check your data.");

            for (int i = 0; i < listInventoryTransactionDTO.Count; i++)
            {
                DeleteInventoryTransaction(database, listInventoryTransactionDTO[i].TRANS_ID);
            }


        }

        public void DeleteInventoryGroupTrans(Database database, NZString transID)
        {
            InventoryTransactionDAO inventoryTransactionDAO = new InventoryTransactionDAO(database);

            //== Load Transaction.
            InventoryTransactionDTO param = new InventoryTransactionDTO();
            InventoryTransactionDTO inventoryTransactionDTO = inventoryTransactionDAO.LoadByPK(database, transID);
            param.SLIP_NO = inventoryTransactionDTO.SLIP_NO;
            List<InventoryTransactionDTO> listInventoryTransactionDTO = inventoryTransactionDAO.Load(database, param);
            if (listInventoryTransactionDTO == null || listInventoryTransactionDTO.Count <= 0)
                return;// throw new ValidateException("Delete failed. Data is missing, Please check your data.");

            for (int i = 0; i < listInventoryTransactionDTO.Count; i++)
            {
                DeleteInventoryTransaction(database, listInventoryTransactionDTO[i].TRANS_ID);
            }


        }
        #endregion

        #region Adjust Stock function
        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        /// <param name="adjustDate"></param>
        /// <param name="itemCode"></param>
        /// <param name="storedLocationCode"></param>
        /// <param name="lotNo"></param>
        /// <param name="inOutType">01: In, 02: Out</param>
        /// <param name="adjustQty"></param>
        /// <param name="lastQty">ถ้าเป็นการ Adjust ใหม่  ให้ระบุค่า 0 , แต่ถ้าเป็นการแก้ Stock เก่าเพื่อทำการ Adjust ใหม่ ให้ระบุค่า Qty ตัวเก่า</param>
        //internal void AdjustStock(Database database, NZDateTime adjustDate, NZString itemCode, NZString storedLocationCode, NZString lotNo, NZString inOutType, NZDecimal adjustQty, NZDecimal lastQty)
        //{
        //    // Check mandatory
        //    if (adjustDate.IsNull || itemCode.IsNull || storedLocationCode.IsNull || adjustQty.IsNull)
        //    {
        //        ValidateException.ThrowErrorItem(new ErrorItem(null, TKPMessages.eValidate.VLM0033.ToString()));
        //    }


        //    //// Check adjustDate is in current period.
        //    //InventoryPeriodDAO inventoryPeriodDAO = new InventoryPeriodDAO();
        //    //InventoryPeriodDTO inventoryPeriodDTO = inventoryPeriodDAO.LoadCurrentYearMonth(database);

        //    //if (inventoryPeriodDTO == null)
        //    //{
        //    //    ValidateException.ThrowErrorItem(new ErrorItem(adjustDate.Owner, TKPMessages.eValidate.VLM0034.ToString()));
        //    //    return;
        //    //}

        //    //if (adjustDate.StrongValue.Date.CompareTo(inventoryPeriodDTO.PERIOD_BEGIN_DATE.StrongValue.Date) < 0
        //    //    || adjustDate.StrongValue.Date.CompareTo(inventoryPeriodDTO.PERIOD_END_DATE.StrongValue.Date) > 0)
        //    //{
        //    //    ValidateException.ThrowErrorItem(new ErrorItem(adjustDate.Owner, TKPMessages.eValidate.VLM0034.ToString()));
        //    //    return;
        //    //}

        //    NZString YearMonth = adjustDate.StrongValue.ToString("yyyyMM").ToNZString();

        //    InventoryOnhandDAO inventoryOnhandDAO = new InventoryOnhandDAO(database);
        //    InventoryOnhandDTO inventoryOnhandDTO = inventoryOnhandDAO.LoadInventoryOnHandByDate(null, YearMonth, adjustDate, itemCode, storedLocationCode, lotNo);

        //    // if not found record. It will create new record.
        //    if (inventoryOnhandDTO == null)
        //    {
        //        inventoryOnhandDTO = new InventoryOnhandDTO();
        //        inventoryOnhandDTO.YEAR_MONTH = YearMonth;
        //        inventoryOnhandDTO.PERIOD_BEGIN_DATE = new DateTime(adjustDate.StrongValue.Year, adjustDate.StrongValue.Month, 1).ToNZDateTime();
        //        inventoryOnhandDTO.PERIOD_END_DATE = new DateTime(adjustDate.StrongValue.Year, adjustDate.StrongValue.Month, DateTime.DaysInMonth(adjustDate.StrongValue.Year, adjustDate.StrongValue.Month)).ToNZDateTime();
        //        inventoryOnhandDTO.ITEM_CD = itemCode;
        //        inventoryOnhandDTO.LOC_CD = storedLocationCode;
        //        inventoryOnhandDTO.LOT_NO = lotNo;
        //        inventoryOnhandDTO.ADJUST_QTY.Value = adjustQty.Value;
        //        inventoryOnhandDTO.OPEN_QTY.Value = 0;
        //        inventoryOnhandDTO.IN_QTY.Value = 0;
        //        inventoryOnhandDTO.OUT_QTY.Value = 0;
        //        inventoryOnhandDTO.STOCK_TAKE_QTY.Value = 0;
        //        inventoryOnhandDTO.ADJUST_QTY.Value = 0;
        //        inventoryOnhandDTO.ON_HAND_QTY.Value = 0;
        //        inventoryOnhandDTO.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
        //        inventoryOnhandDTO.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
        //        inventoryOnhandDTO.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
        //        inventoryOnhandDTO.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;

        //    }
        //    else
        //    {
        //        inventoryOnhandDTO.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
        //        inventoryOnhandDTO.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
        //        inventoryOnhandDTO.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
        //        inventoryOnhandDTO.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
        //    }


        //    InventoryOnhandDTO newInventoryOnhandDTO = (InventoryOnhandDTO)inventoryOnhandDTO.Clone();

        //    // ค่า In/Out Type ของ Transaction ตัวใหม่
        //    DataDefine.eIN_OUT_CLASS inOutClass = DataDefine.ConvertValue2Enum<DataDefine.eIN_OUT_CLASS>(inOutType.StrongValue);

        //    // change AdjustQty on current record.
        //    if (inOutClass == DataDefine.eIN_OUT_CLASS.In)
        //    {
        //        newInventoryOnhandDTO.ADJUST_QTY.Value = inventoryOnhandDTO.ADJUST_QTY.StrongValue + (adjustQty.StrongValue);

        //    }
        //    else
        //    {
        //        //// Before decrease stock should be check available stock.
        //        //if ((adjustQty.StrongValue) > inventoryOnhandDTO.ON_HAND_QTY.StrongValue) {
        //        //    ValidateException.ThrowErrorItem(new ErrorItem(adjustQty.Owner, TKPMessages.eValidate.VLM0036.ToString()));
        //        //}

        //        newInventoryOnhandDTO.ADJUST_QTY.Value = inventoryOnhandDTO.ADJUST_QTY.StrongValue - (adjustQty.StrongValue);
        //    }


        //    // Change onhand qty.
        //    newInventoryOnhandDTO.ON_HAND_QTY.Value = newInventoryOnhandDTO.OPEN_QTY.StrongValue +
        //                                              newInventoryOnhandDTO.IN_QTY.StrongValue - newInventoryOnhandDTO.OUT_QTY.StrongValue +
        //                                              newInventoryOnhandDTO.ADJUST_QTY.StrongValue + newInventoryOnhandDTO.STOCK_TAKE_QTY.StrongValue;

        //    // Populate data.
        //    inventoryOnhandDAO.AddNewOrUpdate2(database, newInventoryOnhandDTO);
        //}
        #endregion

        //#region Consumption function
        //internal void AddStock(Database database, NZDateTime inputDate, NZString itemCode, NZString locationCode, NZString lotNo, NZString inOutType, NZDecimal qty)
        //{
        //    // Check mandatory
        //    if (inputDate.IsNull)
        //    {
        //        ValidateException.ThrowErrorItem(new ErrorItem(null, TKPMessages.eValidate.VLM0033.ToString()));
        //    }



        //    // Check adjustDate is in current period.
        //    InventoryPeriodDAO inventoryPeriodDAO = new InventoryPeriodDAO();
        //    InventoryPeriodDTO inventoryPeriodDTO = inventoryPeriodDAO.LoadCurrentYearMonth(database);

        //    if (inventoryPeriodDTO == null)
        //    {
        //        ValidateException.ThrowErrorItem(new ErrorItem(inputDate.Owner, TKPMessages.eValidate.VLM0034.ToString()));
        //        return;
        //    }

        //    if (inputDate.StrongValue.Date.CompareTo(inventoryPeriodDTO.PERIOD_BEGIN_DATE.StrongValue.Date) < 0
        //        || inputDate.StrongValue.Date.CompareTo(inventoryPeriodDTO.PERIOD_END_DATE.StrongValue.Date) > 0)
        //    {
        //        ValidateException.ThrowErrorItem(new ErrorItem(inputDate.Owner, TKPMessages.eValidate.VLM0034.ToString()));
        //        return;
        //    }


        //    InventoryOnhandDAO inventoryOnhandDAO = new InventoryOnhandDAO(database);
        //    InventoryOnhandDTO inventoryOnhandDTO = inventoryOnhandDAO.LoadInventoryOnHandByDate(null, inventoryPeriodDTO.YEAR_MONTH, inputDate, itemCode, locationCode, lotNo);

        //    // if not found record. It will create new record.
        //    if (inventoryOnhandDTO == null)
        //    {
        //        inventoryOnhandDTO = new InventoryOnhandDTO();
        //        inventoryOnhandDTO.YEAR_MONTH = inventoryPeriodDTO.YEAR_MONTH;
        //        inventoryOnhandDTO.PERIOD_BEGIN_DATE = inventoryPeriodDTO.PERIOD_BEGIN_DATE;
        //        inventoryOnhandDTO.PERIOD_END_DATE = inventoryPeriodDTO.PERIOD_END_DATE;
        //        inventoryOnhandDTO.ITEM_CD = itemCode;
        //        inventoryOnhandDTO.LOC_CD = locationCode;
        //        inventoryOnhandDTO.LOT_NO = lotNo;
        //        inventoryOnhandDTO.ADJUST_QTY.Value = qty.Value;
        //        inventoryOnhandDTO.OPEN_QTY.Value = 0;
        //        inventoryOnhandDTO.IN_QTY.Value = 0;
        //        inventoryOnhandDTO.OUT_QTY.Value = 0;
        //        inventoryOnhandDTO.STOCK_TAKE_QTY.Value = 0;
        //        inventoryOnhandDTO.ADJUST_QTY.Value = 0;
        //        inventoryOnhandDTO.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
        //        inventoryOnhandDTO.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
        //        inventoryOnhandDTO.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
        //        inventoryOnhandDTO.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
        //    }


        //    InventoryOnhandDTO newInventoryOnhandDTO = (InventoryOnhandDTO)inventoryOnhandDTO.Clone();
        //    DataDefine.eIN_OUT_CLASS inOutClass = DataDefine.ConvertValue2Enum<DataDefine.eIN_OUT_CLASS>(inOutType.StrongValue);

        //    // change IN/OUT qty on current record.
        //    if (inOutClass == DataDefine.eIN_OUT_CLASS.In)
        //    {

        //        newInventoryOnhandDTO.IN_QTY.Value = inventoryOnhandDTO.IN_QTY.StrongValue + qty.StrongValue;
        //    }
        //    else
        //    {
        //        newInventoryOnhandDTO.OUT_QTY.Value = inventoryOnhandDTO.OUT_QTY.StrongValue + qty.StrongValue;
        //    }


        //    // Change onhand qty.
        //    newInventoryOnhandDTO.ON_HAND_QTY.Value = newInventoryOnhandDTO.OPEN_QTY.StrongValue +
        //                                              newInventoryOnhandDTO.IN_QTY.StrongValue - newInventoryOnhandDTO.OUT_QTY.StrongValue +
        //                                              newInventoryOnhandDTO.ADJUST_QTY.StrongValue + newInventoryOnhandDTO.STOCK_TAKE_QTY.StrongValue;

        //    // Populate data.
        //    inventoryOnhandDAO.AddNewOrUpdate2(database, newInventoryOnhandDTO);
        //}
        //#endregion


        public void UpdateIssueByOrder(List<InventoryTransactionDTO> listAdd_from, List<InventoryTransactionDTO> listAdd_to, List<InventoryTransactionDTO> listUpdate_from, List<InventoryTransactionDTO> listUpdate_to, List<InventoryTransactionDTO> listDelete_from, List<InventoryTransactionDTO> listDelete_to)
        {
            //CommonLib.Common.CurrentDatabase.KeepConnection = true;
            // lock transaction
            //CommonLib.Common.CurrentDatabase.BeginTransaction(IsolationLevel.Serializable);

            try
            {
                InventoryTransactionDAO InventoryTransaction = new InventoryTransactionDAO(CommonLib.Common.CurrentDatabase);

                #region Lock Running Number gen.
                TransactionLockDAO daoTrans = new TransactionLockDAO(CommonLib.Common.CurrentDatabase);
                TransactionLockDTO dtoTrans = new TransactionLockDTO();
                NZString key1 = new NZString(null, "ISSUE_TRANS_ID");
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

                #region Add
                if (listAdd_from != null && listAdd_from.Count > 0)
                {
                    #region Validate Mandatory
                    IssueEntryValidator valIssue = new IssueEntryValidator();
                    // CHECK EXIST INVENTORY ONHAND

                    for (int i = 0; i < listAdd_from.Count; i++)
                    {
                        ErrorItem errorItem = null;

                        errorItem = valIssue.CheckIssueDate(listAdd_from[i].TRANS_DATE);
                        if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                        //errorItem = new ItemValidator().CheckItemNotExist(dtoInvTrnsListFrom[i].ITEM_CD).Error;
                        //if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                        errorItem = valIssue.CheckEmptyLocFrom(listAdd_from[i].LOC_CD);
                        if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                        errorItem = valIssue.CheckEmptyLocTo(listAdd_from[i].LOC_CD);
                        if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                        errorItem = valIssue.CheckFromToLocation(listAdd_from[i].LOC_CD, listAdd_to[i].LOC_CD);
                        if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                        //NZString YearMonth = new NZString(null, listAdd_from[i].TRANS_DATE.StrongValue.ToString("yyyyMM"));
                        //InventoryOnhandValidator invVal = new InventoryOnhandValidator();
                        //errorItem = invVal.CheckOnhandQty(listAdd_from[i].QTY, listAdd_from[i].ITEM_CD,
                        //                                    listAdd_from[i].LOC_CD, listAdd_from[i].LOT_NO);
                        //if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                    }



                    #endregion

                    RunningNumberBIZ bizRunning = new RunningNumberBIZ();
                    List<InventoryTransactionDTO> dtoAddList = new List<InventoryTransactionDTO>();
                    for (int i = 0; i < listAdd_from.Count; i++)
                    {
                        #region Add Transaction
                        NZString TransID = bizRunning.GetCompleteRunningNo(new NZString(null, "TRAN_ID"), new NZString(null, "TB_INV_TRANS_TR"));
                        NZString RefID = bizRunning.GetCompleteRunningNo(new NZString(null, "TRAN_ID"), new NZString(null, "TB_INV_TRANS_TR"));

                        listAdd_from[i].TRANS_ID = TransID;
                        listAdd_from[i].REF_NO = RefID;
                        listAdd_to[i].TRANS_ID = RefID;
                        listAdd_to[i].REF_NO = TransID;

                        //InventoryTransaction.AddNew(null, listAdd_from[i]);
                        //InventoryTransaction.AddNew(null, listAdd_to[i]);
                        dtoAddList.Add(listAdd_from[i]);
                        dtoAddList.Add(listAdd_to[i]);
                        #endregion

                        //UpdateInventoryOnhand(CommonLib.Common.CurrentDatabase, listAdd_from[i].TRANS_DATE
                        //    , listAdd_from[i].ITEM_CD, listAdd_from[i].LOC_CD, listAdd_from[i].LOT_NO
                        //    , listAdd_from[i].IN_OUT_CLS, listAdd_from[i].QTY, DataDefine.eTRANS_TYPE.Issuing);
                        //UpdateInventoryOnhand(CommonLib.Common.CurrentDatabase, listAdd_to[i].TRANS_DATE
                        //   , listAdd_to[i].ITEM_CD, listAdd_to[i].LOC_CD, listAdd_to[i].LOT_NO
                        //   , listAdd_to[i].IN_OUT_CLS, listAdd_to[i].QTY, DataDefine.eTRANS_TYPE.Issuing);

                    }
                    AddInventoryTransactions(Common.CurrentDatabase, dtoAddList, false);

                }
                #endregion

                #region Update
                if (listUpdate_from != null && listUpdate_from.Count > 0)
                {
                    List<InventoryTransactionDTO> dtoUpdateList = new List<InventoryTransactionDTO>();
                    for (int i = 0; i < listUpdate_from.Count; i++)
                    {
                        //// get diff qty
                        //InventoryTransactionDAO daoTran = new InventoryTransactionDAO(CommonLib.Common.CurrentDatabase);
                        //InventoryTransactionDTO dtoOld_from = daoTran.LoadByPK(null, listUpdate_from[i].TRANS_ID);
                        //InventoryTransactionDTO dtoOld_to = daoTran.LoadByPK(null, listUpdate_to[i].TRANS_ID);

                        //decimal difQty_from = listUpdate_from[i].QTY.StrongValue - dtoOld_from.QTY.StrongValue;
                        //decimal difQty_to = listUpdate_from[i].QTY.StrongValue - dtoOld_to.QTY.StrongValue;

                        //InventoryTransaction.UpdateWithoutPK(null, listUpdate_from[i]);
                        //InventoryTransaction.UpdateWithoutPK(null, listUpdate_to[i]);
                        dtoUpdateList.Add(listUpdate_from[i]);
                        dtoUpdateList.Add(listUpdate_to[i]);

                        //UpdateInventoryOnhand(CommonLib.Common.CurrentDatabase, listUpdate_from[i].TRANS_DATE
                        //                      , listUpdate_from[i].ITEM_CD, listUpdate_from[i].LOC_CD,
                        //                      listUpdate_from[i].LOT_NO
                        //                      , listUpdate_from[i].IN_OUT_CLS, (NZDecimal)difQty_from, DataDefine.eTRANS_TYPE.Issuing);
                        //UpdateInventoryOnhand(CommonLib.Common.CurrentDatabase, listUpdate_to[i].TRANS_DATE
                        //                      , listUpdate_to[i].ITEM_CD, listUpdate_to[i].LOC_CD,
                        //                      listUpdate_to[i].LOT_NO
                        //                      , listUpdate_to[i].IN_OUT_CLS, (NZDecimal)difQty_to, DataDefine.eTRANS_TYPE.Issuing);

                    }
                    UpdateInventoryTransactions(Common.CurrentDatabase, dtoUpdateList);
                }

                #endregion

                #region Delete
                if (listDelete_from != null && listDelete_from.Count > 0)
                {
                    List<InventoryTransactionDTO> dtoDeleteList = new List<InventoryTransactionDTO>();
                    for (int i = 0; i < listDelete_from.Count; i++)
                    {
                        // get diff qty
                        //InventoryTransactionDAO daoTran = new InventoryTransactionDAO(CommonLib.Common.CurrentDatabase);
                        //InventoryTransactionDTO dtoOld_from = daoTran.LoadByPK(null, listDelete_from[i].TRANS_ID);
                        //InventoryTransactionDTO dtoOld_to = daoTran.LoadByPK(null, listDelete_to[i].TRANS_ID);

                        //decimal difQty_from = 0 - dtoOld_from.QTY.StrongValue;
                        //decimal difQty_to = 0 - dtoOld_to.QTY.StrongValue;

                        //InventoryTransaction.Delete(null, listDelete_from[i].TRANS_ID);
                        //InventoryTransaction.Delete(null, listDelete_to[i].TRANS_ID);

                        dtoDeleteList.Add(listDelete_from[i]);
                        dtoDeleteList.Add(listDelete_to[i]);
                        //UpdateInventoryOnhand(CommonLib.Common.CurrentDatabase, listDelete_from[i].TRANS_DATE
                        //                      , listDelete_from[i].ITEM_CD, listDelete_from[i].LOC_CD,
                        //                      listDelete_from[i].LOT_NO
                        //                      , listDelete_from[i].IN_OUT_CLS, (NZDecimal)difQty_from, DataDefine.eTRANS_TYPE.Issuing);
                        //UpdateInventoryOnhand(CommonLib.Common.CurrentDatabase, listDelete_to[i].TRANS_DATE
                        //                      , listDelete_to[i].ITEM_CD, listDelete_to[i].LOC_CD,
                        //                      listDelete_to[i].LOT_NO
                        //                      , listDelete_to[i].IN_OUT_CLS, (NZDecimal)difQty_to, DataDefine.eTRANS_TYPE.Issuing);
                    }
                    DeleteInventoryTransactions(Common.CurrentDatabase, dtoDeleteList);
                }

                #endregion
                daoTrans.DeleteWithKeys(null, key1, key2);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<InventoryTransactionDTO> LoadAllTransactionsOnPeriod(NZDateTime STR_TRANS_DATE, NZDateTime END_TRANS_DATE)
        {
            InventoryTransactionDAO dao = new InventoryTransactionDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadAllTransactionsOnPeriod(null, STR_TRANS_DATE, END_TRANS_DATE);
        }

        public int UpdateReceiveHeader(Database db, InventoryTransactionDTO dto)
        {
            InventoryTransactionDAO dao = new InventoryTransactionDAO(db);
            return dao.UpdateReceiveHeader(null, dto);
        }



        /// <summary>
        /// THIS FUNCTION WILL LOAD INVENTORY ONHAND
        /// FROM V_ACTUAL_ONHAND VIEW
        /// </summary>
        /// <param name="ItemCD"></param>
        /// <param name="FromLoc"></param>
        /// <param name="LotNo"></param>
        /// <returns></returns>
        public ActualOnhandViewDTO LoadActualInventoryOnHand(Database db, NZString ItemCD, NZString FromLoc, NZString LotNo)
        {
            ActualOnhandViewDAO dao = new ActualOnhandViewDAO(db);
            return dao.LoadByPK(db, ItemCD, FromLoc, LotNo);
        }

        public DataTable CheckUnpackInventory(NZString GroupTransID)
        {
            ActualOnhandViewDAO dao = new ActualOnhandViewDAO(CommonLib.Common.CurrentDatabase);
            return dao.CheckUnpackInventory(null, GroupTransID);
        }

        /// <summary>
        /// THIS FUNCTION WILL LOAD INVENTORY ONHAND
        /// FROM V_ACTUAL_ONHAND VIEW
        /// </summary>
        /// <param name="ItemCD"></param>
        /// <param name="FromLoc"></param>
        /// <param name="LotNo"></param>
        /// <returns></returns>
        public ActualOnhandViewDTO LoadActualInventoryOnHand(NZString ItemCD, NZString FromLoc, NZString LotNo)
        {

            return LoadActualInventoryOnHand(CommonLib.Common.CurrentDatabase, ItemCD, FromLoc, LotNo);
        }

        public List<ActualOnhandViewDTO> LoadInventoryOnHandList(
            NZString ITEM_CD
            , NZString LOC_CD
            , NZString LOT_NO
            , NZString PACK_NO
            // , NZString[] OrderBy
            )
        {
            InventoryOnhandDAO dao = new InventoryOnhandDAO(Common.CurrentDatabase);
            return dao.LoadInventoryOnHandList(null, ITEM_CD, LOC_CD, LOT_NO, PACK_NO); //, OrderBy);
        }

        #region Receiving Business

        #region Load
        public List<InventoryTransactionViewDTO> LoadReceivingList(NZDateTime PERIOD_BEGIN_DATE, NZDateTime PERIOD_END_DATE)
        {
            InventoryTransactionDAO dao = new InventoryTransactionDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadTransactionViewByTypeInPeriod(null, PERIOD_BEGIN_DATE, PERIOD_END_DATE,
                                                         new NZString[]
                                                             {
                                                                 (NZString) DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Receiving),
                                                                 (NZString) DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Receive_Return)
                                                             });
        }

        public List<InventoryTransactionViewDTO> LoadTransactionViewByReceiveNo(NZString receiveNo)
        {
            InventoryTransactionDAO dao = new InventoryTransactionDAO(Common.CurrentDatabase);
            return dao.LoadTransactionViewByReceiveNo(null, receiveNo);
        }
        #endregion

        #region Save



        /// <summary>
        /// รับ Item 
        /// </summary>
        /// <param name="addItems">ข้อมูลของ InventoryTransaction ที่จะเพิ่มใหม่</param>
        /// <param name="updateItems">ข้อมูลของ InventoryTransaction ที่จะปรับปรุง</param>
        /// <param name="deleteItems">ข้อมูลของ InventoryTransaction ที่จะลบ</param>
        // /// <param name="consumptionItems">ข้อมูลของ consumptionItems ใช้สำหรับ Receiving จาก Subcontractor เท่านั้น</param>
        public void ReceivingItems(Database db, List<InventoryTransactionDTO> addItems, List<InventoryTransactionDTO> updateItems, List<InventoryTransactionDTO> deleteItems
            //ปรับให้ใชช้การส่งค่าจาก หน้า screen เข้ามาแทน เนื่องจากตอน receive มีการแตก lot ย่อย ทำให้ต้องคำนวณ consumption ใหม่
            //ทุครั้งในการตัดแต่ละ detail ไม่งั้นจะเกิดปัญหาตัด lot เดิมซ้ำตลอด
            //, List<InventoryTransactionDTO> consumptionItems
            )
        {
            if (addItems != null && addItems.Count > 0)
            {
                //Add Main Data (addItems)
                AddInventoryTransactions(db, addItems, true);

                ////if consumptionItems is null skip add consumption list data
                //if (consumptionItems != null && consumptionItems.Count > 0)
                //{
                //    //Add consumption data by loop search
                //    for (int i = 0; i < addItems.Count; i++)
                //    {
                //        for (int j = 0; j < consumptionItems.Count; j++)
                //        {
                //            if (consumptionItems[j].REF_NO.StrongValue == addItems[i].REF_NO.StrongValue)
                //            {
                //                AddInventoryTransaction(db, consumptionItems[j], true);
                //            }
                //        }
                //    }
                //}

            }

            if (updateItems != null && updateItems.Count > 0)
            {
                // for Consumtion item it must delete old data and add new
                //InventoryTransBIZ bizTran = new InventoryTransBIZ();
                //for (int i = 0; i < updateItems.Count; i++)
                //{
                //    // Delete
                //    List<InventoryTransactionDTO> listConDTO = bizTran.LoadConsumptionItemByRefNo(updateItems[i].REF_NO);
                //    DeleteInventoryTransactions(db, listConDTO);
                //}

                UpdateInventoryTransactions(db, updateItems);

                ////if consumptionItems is null skip add consumption list data
                //if (consumptionItems != null && consumptionItems.Count > 0)
                //{
                //    //Add consumption data by loop search
                //    for (int i = 0; i < updateItems.Count; i++)
                //    {
                //        for (int j = 0; j < consumptionItems.Count; j++)
                //        {
                //            if (consumptionItems[j].REF_NO.StrongValue == updateItems[i].REF_NO.StrongValue)
                //            {
                //                AddInventoryTransaction(db, consumptionItems[j], true);
                //            }
                //        }
                //    }
                //}
            }

            if (deleteItems != null && deleteItems.Count > 0)
            {
                //// for Consumtion item it must delete too
                //InventoryTransBIZ bizTran = new InventoryTransBIZ();
                //for (int i = 0; i < deleteItems.Count; i++)
                //{
                //    // Delete
                //    //20101208 kim แก้ bug ให้เป็น LoadByRefNo
                //    //List<InventoryTransactionDTO> listConDTO = bizTran.LoadBySlipNo(deleteItems[i].REF_NO);
                //    List<InventoryTransactionDTO> listConDTO = bizTran.LoadByRefNo(deleteItems[i].REF_NO);
                //    DeleteInventoryTransactions(db, listConDTO);
                //}

                DeleteInventoryTransactions(db, deleteItems);
            }
        }

        public NZString GenerateReceivingLotNoPrefix()
        {
            NZString LotNoPrefix = new NZString();


            return LotNoPrefix;
        }
        #endregion

        #endregion

        #region Work Result Business
        #region Load
        public List<InventoryTransactionViewDTO> LoadWorkResultList(NZDateTime PERIOD_BEGIN_DATE, NZDateTime PERIOD_END_DATE)
        {
            InventoryTransactionDAO dao = new InventoryTransactionDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadTransactionViewByTypeInPeriod(null, PERIOD_BEGIN_DATE, PERIOD_END_DATE,
                                                         new NZString[]
                                                             {
                                                                 (NZString) DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.WorkResult)                                                                 
                                                             });
        }

        /// <summary>
        /// Load consumption list from specific item code. It will not has initial consumtion qty at first.
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="orderLocation"></param>
        /// <param name="qty"></param>
        /// <returns></returns>
        public List<WorkResultEntryViewDTO> LoadConsumptionListFromItemCode(NZString itemCode, NZString orderLocation, NZDecimal qty)
        {
            BOMDAO dao = new BOMDAO(Common.CurrentDatabase);
            return dao.LoadConsumptionListByExplosionBOM(null, itemCode, orderLocation, qty);

        }

        /// <summary>
        /// Load consumption list from inventory transaction by same parent item code.
        /// </summary>
        /// <param name="workResultNo"></param>
        /// <returns></returns>
        public List<WorkResultEntryViewDTO> LoadWorkResultConsumptionList(NZString workResultNo)
        {

            InventoryBIZ bizInventory = new InventoryBIZ();
            InventoryTransactionDAO dao = new InventoryTransactionDAO(Common.CurrentDatabase);
            List<WorkResultEntryViewDTO> dtoList = dao.LoadWorkResultConsumptionList(null, workResultNo);

            for (int i = 0; i < dtoList.Count; i++)
            {
                //WorkResultEntryViewDTO dto = dtoList[i];
                //ActualOnhandViewDTO dtoOnhand = bizInventory.LoadActualInventoryOnHand(dto.ITEM_CD, dto.LOC_CD, dto.LOT_NO);
                //if (dtoOnhand != null)
                //    dto.ON_HAND_QTY.Value = dtoOnhand.ONHAND_QTY.NVL(0) + dto.CONSUMPTION_QTY.NVL(0);
            }

            return dtoList;

        }

        #endregion

        /// <summary>
        /// รับ Item 
        /// </summary>
        /// <param name="addItems">ข้อมูลของ InventoryTransaction ที่จะเพิ่มใหม่</param>
        /// <param name="updateItems">ข้อมูลของ InventoryTransaction ที่จะปรับปรุง</param>
        /// <param name="deleteItems">ข้อมูลของ InventoryTransaction ที่จะลบ</param>
        /// 
        public void WorkResultItems(Database db, List<InventoryTransactionDTO> addItems, List<InventoryTransactionDTO> updateItems, List<InventoryTransactionDTO> deleteItems)
        {
            if (addItems != null && addItems.Count > 0)
            {
                //Add Main Data (addItems)
                AddInventoryTransactions(db, addItems, true);
            }

            if (updateItems != null && updateItems.Count > 0)
            {
                InventoryTransBIZ bizTran = new InventoryTransBIZ();
                for (int i = 0; i < updateItems.Count; i++)
                {
                    // การ Update Work Result ต้องลบ Consumption record ก่อนแล้ว Add ใหม่
                    List<InventoryTransactionDTO> listConDTO = bizTran.LoadConsumptionItemByRefNo(updateItems[i].REF_NO);
                    DeleteInventoryTransactions(db, listConDTO);
                }

                UpdateInventoryTransactions(db, updateItems);
            }

            if (deleteItems != null && deleteItems.Count > 0)
            {
                DeleteInventoryTransactions(db, deleteItems);
            }
        }

        public void ClearConsumption(Database db, InventoryTransactionDTO argWorkResult)
        {
            InventoryTransactionDAO inventoryTransactionDAO = new InventoryTransactionDAO(db);

            //== Load Transaction.
            List<InventoryTransactionDTO> inventoryTransactionDTO = inventoryTransactionDAO.LoadListTransactionByRefNoAndTransType(db, argWorkResult.SLIP_NO, DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Consumption).ToNZString());

            DeleteInventoryTransactions(db, inventoryTransactionDTO);

        }

        #region Delete
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workResultNo"></param>
        /// <exception cref="Exception"><c>Exception</c>.</exception>
        public void DeleteWorkResult(NZString workResultNo)
        {
            InventoryTransBIZ bizInventoryTrans = new InventoryTransBIZ();
            InventoryBIZ biz = new InventoryBIZ();

            Database db = Common.CurrentDatabase;
            db.KeepConnection = true;
            db.BeginTransaction();

            try
            {
                // load header of work/result.
                List<InventoryTransactionDTO> listHeaderItems = bizInventoryTrans.LoadBySlipNo(workResultNo);
                biz.DeleteInventoryTransactions(db, listHeaderItems);


                // Load detail consumption to delete.
                List<InventoryTransactionDTO> listDeleteItems = bizInventoryTrans.LoadByRefNo(workResultNo);
                biz.DeleteInventoryTransactions(db, listDeleteItems);

                db.Commit();
            }
            catch
            {
                db.Rollback();
                throw;
            }
            finally
            {
                db.Close();
            }
        }


        public void DeleteGroupTransaction(NZString groupTrans)
        {
            InventoryTransBIZ bizInventoryTrans = new InventoryTransBIZ();
            InventoryBIZ biz = new InventoryBIZ();

            Database db = Common.CurrentDatabase;
            db.KeepConnection = true;
            db.BeginTransaction();

            try
            {
                // load header of work/result.
                List<InventoryTransactionDTO> listTransactionGroup = bizInventoryTrans.LoadGroupTransaction(groupTrans);
                biz.DeleteInventoryTransactions(db, listTransactionGroup);

                db.Commit();
            }
            catch
            {
                db.Rollback();
                throw;
            }
            finally
            {
                db.Close();
            }
        }

        #endregion

        public List<ActualOnhandViewDTO> FifoListingProcess(Database database, string strItemNo, string strLocation, decimal decReqQty, bool bCheckOnhandQty, bool bAllowNegativeOutput)
        {
            // order ตาม lot no เท่านั้น เพราะยังไม่มี receive date เป็นตัวช่วย
            InventoryOnhandDAO dao = new InventoryOnhandDAO(database);
            return dao.FifoListingProcess(database, strItemNo, strLocation, decReqQty, bCheckOnhandQty, bAllowNegativeOutput);
        }
        #endregion

        #region Inventory Onhand Inquiry
        public List<InventoryOnhandInquiryViewDTO> LoadInventoryOnhandInquiry(NZString yearMonth, NZDateTime FromPeriod, NZDateTime ToPeriod, bool GroupByItem, int iToEndOfMonth)
        {
            InventoryOnhandDAO dao = new InventoryOnhandDAO(Common.CurrentDatabase);
            return dao.LoadInventoryOnhandInquiryView(null, yearMonth, FromPeriod, ToPeriod, GroupByItem, iToEndOfMonth);
        }

        #endregion

        #region Inventory Summary

        public DataTable LoadInventorySummary(NZString yearMonth)
        {
            InventoryOnhandDAO dao = new InventoryOnhandDAO(Common.CurrentDatabase);
            return dao.LoadInventorySummary(null, yearMonth);
        }

        #endregion

        internal List<InventoryOnhandDTO> LoadInvOnhandWithNegativeQty(NZString YearMonth)
        {
            InventoryOnhandDAO dao = new InventoryOnhandDAO(Common.CurrentDatabase);
            return dao.LoadInvOnhandWithNegativeQty(null, YearMonth);
        }

        internal List<InventoryOnhandDTO> LoadInvOnhandWithNegativeQty(NZString YearMonth, NZString Location)
        {
            InventoryOnhandDAO dao = new InventoryOnhandDAO(Common.CurrentDatabase);
            return dao.LoadInvOnhandWithNegativeQty(null, YearMonth, Location);
        }

        internal List<InventoryOnhandDTO> LoadInventoryWithYearMonth(NZString PreMonth)
        {
            InventoryOnhandDAO dao = new InventoryOnhandDAO(Common.CurrentDatabase);
            return dao.LoadInventoryWithYearMonth(null, PreMonth);
        }

        #region Run Inventory Closing Process
        /// <exception cref="Exception"><c>Exception</c>.</exception>
        public int RunInventoryClosingProcess(eMonthlyCloseProcess ePrcsType)
        {
            Database db = null;
            try
            {
                db = Common.CurrentDatabase;
                db.KeepConnection = true;
                db.BeginTransaction(IsolationLevel.Serializable);
                //kim change to merge statement
                InventoryPeriodDAO daoInvPeriod = new InventoryPeriodDAO(db);
                InventoryOnhandDAO daoOnHand = new InventoryOnhandDAO(db);

                InventoryPeriodDTO dtoFromPeriod = daoInvPeriod.LoadCurrentYearMonth(db);

                InventoryPeriodDTO dtoToPeriod = daoInvPeriod.GetNextPeriodRecord(db, ePrcsType);
                dtoToPeriod.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                dtoToPeriod.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;

                switch (ePrcsType)
                {
                    case eMonthlyCloseProcess.ROLLING_UP:
                        daoOnHand.RollingUpProcess(db, dtoFromPeriod, dtoToPeriod);
                        break;
                    case eMonthlyCloseProcess.ROLLING_DOWN:
                        daoOnHand.RollingDownProcess(db, dtoFromPeriod, dtoToPeriod);
                        break;
                }

                // update inventory period
                daoInvPeriod.UpdateInventoryPeriod(db, dtoToPeriod);
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
                    db.Close();
            }
            return 1;
        }
        #endregion

        #region Negative Lot Clearing Process
        private void _NegativeLotClearingProcess(Database db, DateTime dtAdjustDate, InventoryOnhandDTO dtoNegativeLot)
        {

            decimal totalOutQty = 0;
            string strRemark = "Negative Lot Clearing Process";
            string strTranSubClass = "05";
            //Loop Do Adjust Out
            List<ActualOnhandViewDTO> dtoFifoList = FifoListingProcess(Common.CurrentDatabase, dtoNegativeLot.ITEM_CD.StrongValue, dtoNegativeLot.LOC_CD.StrongValue, Math.Abs(dtoNegativeLot.ON_HAND_QTY.StrongValue), false, false);
            foreach (ActualOnhandViewDTO dto in dtoFifoList)
            {
                #region Create AdjustOutDTO
                InventoryTransactionDTO dtoAdjust = new InventoryTransactionDTO();
                //dtoAdjust.TRANS_ID = 
                dtoAdjust.ITEM_CD = dto.ITEM_CD;
                dtoAdjust.LOC_CD = dto.LOC_CD;
                dtoAdjust.LOT_NO = dto.LOT_NO;
                dtoAdjust.TRANS_DATE = dtAdjustDate.ToNZDateTime();
                dtoAdjust.TRANS_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Adjustment);
                dtoAdjust.IN_OUT_CLS = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.Out).ToNZString();
                dtoAdjust.QTY = dto.ONHAND_QTY;
                dtoAdjust.REMARK = strRemark.ToNZString();
                dtoAdjust.TRAN_SUB_CLS = strTranSubClass.ToNZString();
                dtoAdjust.SCREEN_TYPE = DataDefine.ScreenType.AdjustmentEntry.ToNZString();
                dtoAdjust.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                dtoAdjust.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                dtoAdjust.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                dtoAdjust.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                #endregion
                AddInventoryTransaction(db, dtoAdjust, true);
                totalOutQty += dtoAdjust.QTY.StrongValue;
            }
            if (totalOutQty > 0)
            {
                //Do Adjust In
                #region Create AdjustInDTO
                InventoryTransactionDTO dtoAdjustIn = new InventoryTransactionDTO();
                //dtoAdjust.TRANS_ID = 
                dtoAdjustIn.ITEM_CD = dtoNegativeLot.ITEM_CD;
                dtoAdjustIn.LOC_CD = dtoNegativeLot.LOC_CD;
                dtoAdjustIn.LOT_NO = dtoNegativeLot.LOT_NO;
                dtoAdjustIn.TRANS_DATE = dtAdjustDate.ToNZDateTime();
                dtoAdjustIn.TRANS_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Adjustment);
                dtoAdjustIn.IN_OUT_CLS = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.In).ToNZString();
                dtoAdjustIn.QTY = totalOutQty.ToNZDecimal();
                dtoAdjustIn.REMARK = strRemark.ToNZString();
                dtoAdjustIn.TRAN_SUB_CLS = strTranSubClass.ToNZString();
                dtoAdjustIn.SCREEN_TYPE = DataDefine.ScreenType.AdjustmentEntry.ToNZString();
                dtoAdjustIn.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                dtoAdjustIn.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                dtoAdjustIn.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                dtoAdjustIn.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                #endregion
                AddInventoryTransaction(db, dtoAdjustIn, true);
            }
        }

        public void NegativeLotClearingProcess(string strLocation)
        {
            Database db = null;
            try
            {
                db = Common.CurrentDatabase;
                db.KeepConnection = true;
                db.BeginTransaction(IsolationLevel.Serializable);

                //get current period
                InventoryPeriodBIZ bizPeriod = new InventoryPeriodBIZ();
                InventoryPeriodDTO currPeriod = bizPeriod.LoadCurrentPeriod();

                //Load all Negative Lot
                List<InventoryOnhandDTO> dtoNegativeLots = null;
                if (strLocation == "All")
                {
                    dtoNegativeLots = LoadInvOnhandWithNegativeQty(currPeriod.YEAR_MONTH);
                }
                else
                {
                    dtoNegativeLots = LoadInvOnhandWithNegativeQty(currPeriod.YEAR_MONTH, strLocation.ToNZString());
                }

                foreach (InventoryOnhandDTO dtoNegativeLot in dtoNegativeLots)
                {
                    _NegativeLotClearingProcess(db, currPeriod.PERIOD_END_DATE.StrongValue.Date, dtoNegativeLot);
                }

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

        }
        #endregion

        public int UpdateIssueHeader(InventoryTransactionDTO dtoHeader)
        {
            InventoryTransactionDAO dao = new InventoryTransactionDAO(CommonLib.Common.CurrentDatabase);
            return dao.UpdateIssueHeader(null, dtoHeader);
        }


        public List<MultiWorkResultEntryViewDTO> LoadChildItemToInputMultiWorkResult(NZString childItemCode, NZString orderLocation, NZString lotNo, DataDefine.eTRAN_SUB_CLS workResultType)
        {
            BOMDAO dao = new BOMDAO(Common.CurrentDatabase);
            return dao.LoadChildItemToInputMultiWorkResult(null, childItemCode, orderLocation, lotNo, workResultType);

        }

        public int AddMovePart(InventoryTransactionDTO dtoInvTrnsFrom, InventoryTransactionDTO dtoInvTrnsTo, List<InventoryTransactionDTO> dtoComponent)
        {
            CommonLib.Common.CurrentDatabase.KeepConnection = true;
            CommonLib.Common.CurrentDatabase.BeginTransaction(IsolationLevel.Serializable);

            try
            {

                #region Lock Running Number gen.

                TransactionLockDAO daoTrans = new TransactionLockDAO(CommonLib.Common.CurrentDatabase);
                TransactionLockDTO dtoTrans = new TransactionLockDTO();
                NZString key1 = new NZString(null, "MOVE_NO");
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

                List<InventoryTransactionDTO> dtoList = new List<InventoryTransactionDTO>();

                RunningNumberBIZ bizRunning = new RunningNumberBIZ();
                NZString SlipNo = bizRunning.GetCompleteRunningNo(new NZString(null, "MOVE_NO"), new NZString(null, "TB_INV_TRANS_TR"));

                NZString TransID = bizRunning.GetCompleteRunningNo(new NZString(null, "TRAN_ID"), new NZString(null, "TB_INV_TRANS_TR"));
                NZString RefID = bizRunning.GetCompleteRunningNo(new NZString(null, "TRAN_ID"), new NZString(null, "TB_INV_TRANS_TR"));
                NZString GroupTransID = bizRunning.GetCompleteRunningNo(new NZString(null, "TRAN_GROUP_ID"), new NZString(null, "TB_INV_TRANS_TR"));

                #region From

                dtoInvTrnsFrom.TRANS_ID = TransID;
                dtoInvTrnsFrom.REF_NO = RefID;
                dtoInvTrnsFrom.SLIP_NO = SlipNo;
                dtoInvTrnsFrom.GROUP_TRANS_ID = GroupTransID;
                dtoList.Add(dtoInvTrnsFrom);

                #endregion

                #region To

                dtoInvTrnsTo.TRANS_ID = RefID;
                dtoInvTrnsTo.REF_NO = TransID;
                dtoInvTrnsTo.REF_SLIP_NO = SlipNo;
                dtoInvTrnsTo.GROUP_TRANS_ID = GroupTransID;
                dtoList.Add(dtoInvTrnsTo);

                #endregion

                #region Move Consumption

                for (int i = 0; i < dtoComponent.Count; i++)
                {
                    NZString ConsumptionTransID = bizRunning.GetCompleteRunningNo(new NZString(null, "TRAN_ID"), new NZString(null, "TB_INV_TRANS_TR"));
                    dtoComponent[i].TRANS_ID = ConsumptionTransID;
                    dtoComponent[i].REF_NO = TransID;
                    dtoComponent[i].REF_SLIP_NO = SlipNo;
                    dtoComponent[i].GROUP_TRANS_ID = GroupTransID;
                    dtoList.Add(dtoComponent[i]);
                }

                #endregion

                AddInventoryTransactions(Common.CurrentDatabase, dtoList, false);
                daoTrans.DeleteWithKeys(null, key1, key2);
                CommonLib.Common.CurrentDatabase.Commit();
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

            return 1;
        }
        public int UpdateMovePart(List<InventoryTransactionDTO> listInvUpdateTrans, List<InventoryTransactionDTO> listInvNewTrans)
        {
            CommonLib.Common.CurrentDatabase.KeepConnection = true;
            CommonLib.Common.CurrentDatabase.BeginTransaction(IsolationLevel.Serializable);

            try
            {

                UpdateInventoryTransactions(CommonLib.Common.CurrentDatabase, listInvUpdateTrans);
                AddInventoryTransactions(CommonLib.Common.CurrentDatabase, listInvNewTrans, true);

                CommonLib.Common.CurrentDatabase.Commit();
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

            return 1;
        }

        public int AddProductionReport(InventoryTransactionDTO dtoInvTrnsIn, InventoryTransactionDTO dtoInvTrnsOut, List<InventoryTransactionDTO> dtoNGList)
        {
            CommonLib.Common.CurrentDatabase.KeepConnection = true;
            CommonLib.Common.CurrentDatabase.BeginTransaction(IsolationLevel.Serializable);

            try
            {

                #region Lock Running Number gen.

                TransactionLockDAO daoTrans = new TransactionLockDAO(Common.CurrentDatabase);
                TransactionLockDTO dtoTrans = new TransactionLockDTO();
                NZString key1 = new NZString(null, "WORK_RESULT_SLIP_NO");
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

                List<InventoryTransactionDTO> dtoList = new List<InventoryTransactionDTO>();

                RunningNumberBIZ bizRunning = new RunningNumberBIZ();
                NZString SlipNo = bizRunning.GetCompleteRunningNo(new NZString(null, "WORK_RESULT_SLIP_NO"), new NZString(null, "TB_INV_TRANS_TR"));

                NZString TransID = bizRunning.GetCompleteRunningNo(new NZString(null, "TRAN_ID"), new NZString(null, "TB_INV_TRANS_TR"));
                NZString RefID = bizRunning.GetCompleteRunningNo(new NZString(null, "TRAN_ID"), new NZString(null, "TB_INV_TRANS_TR"));
                NZString GroupTransID = bizRunning.GetCompleteRunningNo(new NZString(null, "TRAN_GROUP_ID"), new NZString(null, "TB_INV_TRANS_TR"));

                #region In

                dtoInvTrnsIn.TRANS_ID = TransID;
                dtoInvTrnsIn.REF_NO = RefID;
                dtoInvTrnsIn.SLIP_NO = SlipNo;
                dtoInvTrnsIn.GROUP_TRANS_ID = GroupTransID;
                dtoList.Add(dtoInvTrnsIn);

                #endregion

                #region Out

                if (dtoInvTrnsOut != null)
                {
                    dtoInvTrnsOut.TRANS_ID = RefID;
                    dtoInvTrnsOut.REF_NO = TransID;
                    dtoInvTrnsOut.REF_SLIP_NO = SlipNo;
                    dtoInvTrnsOut.GROUP_TRANS_ID = GroupTransID;
                    dtoList.Add(dtoInvTrnsOut);
                }

                #endregion

                #region NG List

                for (int i = 0; i < dtoNGList.Count; i++)
                {
                    NZString NGTransID = bizRunning.GetCompleteRunningNo(new NZString(null, "TRAN_ID"), new NZString(null, "TB_INV_TRANS_TR"));
                    dtoNGList[i].TRANS_ID = NGTransID;
                    dtoNGList[i].REF_NO = TransID;
                    dtoNGList[i].REF_SLIP_NO = SlipNo;
                    dtoNGList[i].GROUP_TRANS_ID = GroupTransID;
                    dtoList.Add(dtoNGList[i]);
                }

                #endregion

                AddInventoryTransactions(Common.CurrentDatabase, dtoList, false);
                daoTrans.DeleteWithKeys(null, key1, key2);
                CommonLib.Common.CurrentDatabase.Commit();
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

            return 1;
        }
        public int UpdateProductionReport(List<InventoryTransactionDTO> listInvTrans)
        {
            CommonLib.Common.CurrentDatabase.KeepConnection = true;
            CommonLib.Common.CurrentDatabase.BeginTransaction(IsolationLevel.Serializable);

            try
            {

                List<InventoryTransactionDTO> dtoNew = new List<InventoryTransactionDTO>();
                List<InventoryTransactionDTO> dtoUpdate = new List<InventoryTransactionDTO>();
                List<InventoryTransactionDTO> dtoDelete = new List<InventoryTransactionDTO>();
                for (int i = 0; i < listInvTrans.Count; i++)
                {
                    if (listInvTrans[i].TRANS_ID.IsNull && listInvTrans[i].QTY > 0)
                        dtoNew.Add(listInvTrans[i]);
                    else if (listInvTrans[i].QTY > 0)
                        dtoUpdate.Add(listInvTrans[i]);
                    else
                        dtoDelete.Add(listInvTrans[i]);
                }

                DeleteInventoryTransactions(Common.CurrentDatabase, dtoDelete);
                UpdateInventoryTransactions(Common.CurrentDatabase, dtoUpdate);
                AddInventoryTransactions(Common.CurrentDatabase, dtoNew, true);

                CommonLib.Common.CurrentDatabase.Commit();
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

            return 1;
        }

        public int AddPacking(List<InventoryTransactionDTO> dtoInvTrnsDestination, InventoryTransactionDTO dtoInvTrnsSource, int NumberOfBox)
        {
            CommonLib.Common.CurrentDatabase.KeepConnection = true;
            CommonLib.Common.CurrentDatabase.BeginTransaction(IsolationLevel.Serializable);

            try
            {

                for (int iBox = 0; iBox < NumberOfBox; iBox++)
                {

                    #region Lock Running Number gen.

                    TransactionLockDAO daoTrans = new TransactionLockDAO(CommonLib.Common.CurrentDatabase);
                    TransactionLockDTO dtoTrans = new TransactionLockDTO();
                    NZString key1 = new NZString(null, "PACK_NO");
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

                    List<InventoryTransactionDTO> dtoList = new List<InventoryTransactionDTO>();

                    RunningNumberBIZ bizRunning = new RunningNumberBIZ();
                    NZString SlipNo = bizRunning.GetCompleteRunningNo(new NZString(null, "PACK_NO"), new NZString(null, "TB_INV_TRANS_TR"));
                    NZString GroupTransID = bizRunning.GetCompleteRunningNo(new NZString(null, "TRAN_GROUP_ID"), new NZString(null, "TB_INV_TRANS_TR"));
                    NZString PackNo = new NZString();

                    //Pack No. is same all transaction
                    if (dtoInvTrnsSource.PACK_NO.IsNull)
                        PackNo = bizRunning.GetCompleteRunningNo(new NZString(null, "PACK_NO_AUTO_GEN"), new NZString(null, "TB_INV_TRANS_TR"));
                    else
                        PackNo = dtoInvTrnsSource.PACK_NO;

                    #region Destination

                    for (int i = 0; i < dtoInvTrnsDestination.Count; i++)
                    {
                        NZString DestTransID = bizRunning.GetCompleteRunningNo(new NZString(null, "TRAN_ID"), new NZString(null, "TB_INV_TRANS_TR"));
                        dtoInvTrnsDestination[i].TRANS_ID = DestTransID;
                        //dtoInvTrnsDestination[i].REF_NO = TransID;
                        dtoInvTrnsDestination[i].SLIP_NO = SlipNo;
                        dtoInvTrnsDestination[i].GROUP_TRANS_ID = GroupTransID;
                        dtoInvTrnsDestination[i].PACK_NO = PackNo;
                        dtoList.Add(dtoInvTrnsDestination[i]);
                    }

                    #endregion

                    #region Source

                    NZString TransID = bizRunning.GetCompleteRunningNo(new NZString(null, "TRAN_ID"), new NZString(null, "TB_INV_TRANS_TR"));

                    dtoInvTrnsSource.TRANS_ID = TransID;
                    //dtoInvTrnsSource.REF_NO = RefID;
                    dtoInvTrnsSource.REF_SLIP_NO = SlipNo;
                    dtoInvTrnsSource.GROUP_TRANS_ID = GroupTransID;
                    dtoInvTrnsSource.PACK_NO = PackNo;
                    dtoList.Add(dtoInvTrnsSource);

                    #endregion

                    AddInventoryTransactions(Common.CurrentDatabase, dtoList, false);
                    daoTrans.DeleteWithKeys(null, key1, key2);

                }

                CommonLib.Common.CurrentDatabase.Commit();
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

            return 1;
        }
        public int UpdatePacking(List<InventoryTransactionDTO> NewList, List<InventoryTransactionDTO> ModifyList, List<InventoryTransactionDTO> DeleteList)
        {
            CommonLib.Common.CurrentDatabase.KeepConnection = true;
            CommonLib.Common.CurrentDatabase.BeginTransaction(IsolationLevel.Serializable);

            try
            {
                if (DeleteList != null && DeleteList.Count > 0)
                    DeleteInventoryTransactions(Common.CurrentDatabase, DeleteList);

                if (ModifyList != null && ModifyList.Count > 0)
                    UpdateInventoryTransactions(Common.CurrentDatabase, ModifyList);

                if (NewList != null && NewList.Count > 0)
                    AddInventoryTransactions(Common.CurrentDatabase, NewList, true);

                CommonLib.Common.CurrentDatabase.Commit();
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

            return 1;
        }
        public bool PackNoIsExist(NZString PackNo)
        {
            InventoryTransactionDAO dao = new InventoryTransactionDAO(Common.CurrentDatabase);
            DataTable dt = dao.CountTransRecordByPackNo(PackNo);
            if (dt != null && dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public bool LotNoIsExist(NZString LotNo) 
        {
            InventoryTransactionDAO dao = new InventoryTransactionDAO(Common.CurrentDatabase);
            DataTable dt = dao.CountTransRecordByLotNo(LotNo);
            if (dt != null && dt.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public int AddUnPacking(List<InventoryTransactionDTO> dtoInvTrnsSource, InventoryTransactionDTO dtoInvTrnsDestination)
        {
            CommonLib.Common.CurrentDatabase.KeepConnection = true;
            CommonLib.Common.CurrentDatabase.BeginTransaction(IsolationLevel.Serializable);

            try
            {

                #region Lock Running Number gen.

                TransactionLockDAO daoTrans = new TransactionLockDAO(CommonLib.Common.CurrentDatabase);
                TransactionLockDTO dtoTrans = new TransactionLockDTO();
                NZString key1 = new NZString(null, "UNPACK_NO");
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

                List<InventoryTransactionDTO> dtoList = new List<InventoryTransactionDTO>();

                RunningNumberBIZ bizRunning = new RunningNumberBIZ();
                NZString SlipNo = bizRunning.GetCompleteRunningNo(new NZString(null, "UNPACK_NO"), new NZString(null, "TB_INV_TRANS_TR"));

                NZString GroupTransID = bizRunning.GetCompleteRunningNo(new NZString(null, "TRAN_GROUP_ID"), new NZString(null, "TB_INV_TRANS_TR"));

                #region Source

                for (int i = 0; i < dtoInvTrnsSource.Count; i++)
                {
                    NZString TransID = bizRunning.GetCompleteRunningNo(new NZString(null, "TRAN_ID"), new NZString(null, "TB_INV_TRANS_TR"));
                    dtoInvTrnsSource[i].TRANS_ID = TransID;
                    //dtoInvTrnsDestination[i].REF_NO = TransID;
                    dtoInvTrnsSource[i].REF_SLIP_NO = SlipNo;
                    dtoInvTrnsSource[i].GROUP_TRANS_ID = GroupTransID;
                    dtoList.Add(dtoInvTrnsSource[i]);
                }

                #endregion

                #region Destination

                NZString DestTransID = bizRunning.GetCompleteRunningNo(new NZString(null, "TRAN_ID"), new NZString(null, "TB_INV_TRANS_TR"));

                dtoInvTrnsDestination.TRANS_ID = DestTransID;
                //dtoInvTrnsSource.REF_NO = RefID;
                dtoInvTrnsDestination.SLIP_NO = SlipNo;
                dtoInvTrnsDestination.GROUP_TRANS_ID = GroupTransID;
                dtoList.Add(dtoInvTrnsDestination);

                #endregion

                AddInventoryTransactions(Common.CurrentDatabase, dtoList, false);

                daoTrans.DeleteWithKeys(null, key1, key2);
                CommonLib.Common.CurrentDatabase.Commit();
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

            return 1;
        }

        public void DeleteTransactionList(List<InventoryTransactionDTO> listInvTrans)
        {
            InventoryTransBIZ bizInventoryTrans = new InventoryTransBIZ();
            InventoryBIZ biz = new InventoryBIZ();

            Database db = Common.CurrentDatabase;
            db.KeepConnection = true;
            db.BeginTransaction();

            try
            {
                biz.DeleteInventoryTransactions(db, listInvTrans);
                db.Commit();
            }
            catch
            {
                db.Rollback();
                throw;
            }
            finally
            {
                db.Close();
            }
        }
    }
}
