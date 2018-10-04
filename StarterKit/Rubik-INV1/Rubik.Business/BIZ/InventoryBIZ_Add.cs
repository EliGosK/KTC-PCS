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
#warning Move all in this class to Original INV BIZ
        public int AddIssueConsumption(List<InventoryTransactionDTO> dtoInvTrnsList)
        {
            try
            {
                #region Validate Mandatory
                IssueEntryValidator valIssue = new IssueEntryValidator();
                InventoryOnhandValidator valINV = new InventoryOnhandValidator();

                ErrorItem errorItem = null;

                if (dtoInvTrnsList.Count > 0) {
                    errorItem = valIssue.CheckIssueDate(dtoInvTrnsList[0].TRANS_DATE);
                    if (null != errorItem) {
                        ValidateException.ThrowErrorItem(errorItem);
                    }
                }
                
                
                // CHECK EXIST INVENTORY ONHAND
                //for (int i = 0; i < dtoInvTrnsList.Count; i++)
                //{
                    

                //    if (dtoInvTrnsList[i].IN_OUT_CLS.StrongValue == DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.Out))
                //    {
                //        // NZString YearMonth = new NZString(null, dtoInvTrnsList[i].TRANS_DATE.StrongValue.ToString("yyyyMM"));

                //        errorItem = valINV.CheckOnhandQty(dtoInvTrnsList[i].IN_OUT_CLS.StrongValue, dtoInvTrnsList[i].QTY, dtoInvTrnsList[i].ITEM_CD,
                //                                            dtoInvTrnsList[i].LOC_CD, dtoInvTrnsList[i].LOT_NO);
                //        if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);
                //    }


                //}

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
                NZString ConsumptionID = bizRunning.GetCompleteRunningNo(new NZString(null, "TRAN_ID"), new NZString(null, "TB_INV_TRANS_TR"));
                // if load success then lock transaction
                daoTrans.SelectWithKeys(null, key1, key2);
                // end of lock transaction

                dtoInvTrnsList[0].TRANS_ID = TransID;
                dtoInvTrnsList[0].REF_NO = RefID;
                dtoInvTrnsList[1].TRANS_ID = RefID;
                dtoInvTrnsList[1].REF_NO = TransID;
                dtoInvTrnsList[2].TRANS_ID = ConsumptionID;
                dtoInvTrnsList[2].REF_NO = RefID;
                for (int i = 0; i < dtoInvTrnsList.Count; i++)
                {
                    InventoryTransaction.AddNew(null, dtoInvTrnsList[i]);
                }
               
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

        public int UpdateConsumption(List<InventoryTransactionDTO> dtoInvTrnsList)
        {           
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

                    #endregion
                    InventoryTransaction.UpdateWithoutPK(null, dtoInvTrnsList[i]);
            
                }

               
            }
            catch (Exception)
            {
                //CommonLib.Common.CurrentDatabase.Rollback();
                throw;
            }

            return 1;
        }

    }
}
