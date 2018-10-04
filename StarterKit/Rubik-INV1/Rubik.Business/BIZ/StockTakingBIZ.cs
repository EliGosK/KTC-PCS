//Create Date 12 Oct 2010
//Author: Bunyapat L.
//Object Name: Stock Taking Business
//Description: Business controller to control stock taking module

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EVOFramework;
using CommonLib;
using Rubik.DTO;
using Rubik.DAO;
using SystemMaintenance.BIZ;
using SystemMaintenance.SQLServer.DAO;
using SystemMaintenance.DTO;

namespace Rubik.BIZ
{
    public class StockTakingBIZ
    {
        #region Step1. Stock Taking Pre Process
        public bool CheckExistsStockTaking(StockTakingDTO argStockTaking)
        {
            bool bExistsStockTaking = false;

            StockTakingDAO dao = new StockTakingDAO(CommonLib.Common.CurrentDatabase);
            bExistsStockTaking = dao.CheckExistsStockTaking(argStockTaking);

            return bExistsStockTaking;
        }
        public StockTakingDTO RunStockTakingPreProcess(StockTakingDTO argStockTaking)
        {
            StockTakingDTO ret = null;

            argStockTaking.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            argStockTaking.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
            argStockTaking.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            argStockTaking.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;

            StockTakingDAO dao = new StockTakingDAO(CommonLib.Common.CurrentDatabase);
            dao.RunStockTakingPreProcess(argStockTaking);

            return ret;
        }

        public StockTakingDTO LoadLastStockTaking()
        {
            StockTakingDTO ret = null;

            StockTakingDAO dao = new StockTakingDAO(CommonLib.Common.CurrentDatabase);
            ret = dao.LoadLastStockTaking();

            return ret;
        }
        #endregion

        #region Step3. Stock Taking Entry

        public DataTable LoadStockTakingEntryData(StockTakingDTO argStockTaking)
        {
            DataTable ret = null;

            StockTakingDAO dao = new StockTakingDAO(CommonLib.Common.CurrentDatabase);
            ret = dao.LoadStockTakingEntryData(argStockTaking);

            return ret;
        }

        public void UpdateStockTakingData(List<StockTakingDetailDTO> listDataInsert, List<StockTakingDetailDTO> listDataUpdate, List<StockTakingDetailDTO> listDataDelete)
        {
            CommonLib.Common.CurrentDatabase.KeepConnection = true;
            CommonLib.Common.CurrentDatabase.BeginTransaction();

            try
            {
                StockTakingDAO dao = new StockTakingDAO(CommonLib.Common.CurrentDatabase);

                foreach (StockTakingDetailDTO dtoInsert in listDataInsert)
                {
                    dao.InsertStockTakingEntry(dtoInsert);
                }

                foreach (StockTakingDetailDTO dtoUpdate in listDataUpdate)
                {
                    dao.UpdateStockTakingEntry(dtoUpdate);
                }

                foreach (StockTakingDetailDTO dtoDelete in listDataDelete)
                {
                    dao.DeleteStockTakingEntry(dtoDelete);
                }

                CommonLib.Common.CurrentDatabase.Commit();
            }
            catch (Exception ex)
            {
                CommonLib.Common.CurrentDatabase.Rollback();
                throw ex;
            }
            finally
            {
                CommonLib.Common.CurrentDatabase.KeepConnection = false;
            }


        }

        public int GetFlagRunUpdateProcess(StockTakingDTO argStockTaking)
        {
            int ret = 1;

            StockTakingDAO dao = new StockTakingDAO(CommonLib.Common.CurrentDatabase);
            ret = dao.GetFlagRunUpdateProcess(argStockTaking);

            return ret;
        }
        #endregion

        #region Step4. Stock Taking Update Process
        public void RunStockTakingUpdateProcess(StockTakingDTO argStockTaking)
        {
            CommonLib.Common.CurrentDatabase.KeepConnection = true;
            CommonLib.Common.CurrentDatabase.BeginTransaction();

            try
            {
                argStockTaking.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                argStockTaking.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                argStockTaking.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                argStockTaking.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;

                StockTakingDAO dao = new StockTakingDAO(CommonLib.Common.CurrentDatabase);

                //load stock taking entry data and set flag as adjusted
                DataTable dtStockTakingEntry = dao.LoadStockTakingForUpdateProcess(argStockTaking);

                InventoryBIZ inventoryBIZ = new InventoryBIZ();

                InventoryPeriodBIZ bizPeriod = new InventoryPeriodBIZ();
                InventoryPeriodDTO dtoPeriod = bizPeriod.LoadCurrentPeriod();

                DateTime dtmCurrentDate = Common.GetDatabaseDateTime().Date;

                DateTime dtmAdjustDate = dtmCurrentDate;

                if (dtmCurrentDate < dtoPeriod.PERIOD_BEGIN_DATE.StrongValue)
                {
                    dtmAdjustDate = dtoPeriod.PERIOD_BEGIN_DATE.StrongValue;
                }
                else
                {
                    if (dtmCurrentDate > dtoPeriod.PERIOD_END_DATE.StrongValue)
                    {
                        dtmAdjustDate = dtoPeriod.PERIOD_END_DATE.StrongValue;
                    }
                    else
                    {
                        dtmAdjustDate = dtmCurrentDate;
                    }
                }

                //adjust inventory
                foreach (DataRow dr in dtStockTakingEntry.Rows)
                {
                    InventoryTransactionDTO invTrans = ConvertToInventoryTransactionDTO(argStockTaking.STOCK_TAKING_DATE, dtmAdjustDate, dr);

                    inventoryBIZ.AddInventoryTransaction(CommonLib.Common.CurrentDatabase, invTrans, true);
                }

                CommonLib.Common.CurrentDatabase.Commit();
            }
            catch (Exception ex)
            {
                CommonLib.Common.CurrentDatabase.Rollback();

                throw ex;
            }
            finally
            {
                CommonLib.Common.CurrentDatabase.KeepConnection = false;
            }
        }

        enum eStockTakingUpdateColum
        {
            ID,
            //COUNTING_ID,
            ITEM_CD,
            LOC_CD,
            LOT_NO,
            EXTERNAL_LOT_NO,
            PACK_NO,
            DIFF_QTY,
            //EFFECT_INVENTORY_FLAG,
            //ADJUSTED_FLAG,
            REMARK,
            FG_NO
        }

        public InventoryTransactionDTO ConvertToInventoryTransactionDTO(DateTime argStockTakingDate, DateTime argAdjustDate, DataRow dr)
        {

            InventoryTransactionDTO dto = new InventoryTransactionDTO();

            RunningNumberBIZ bizRunning = new RunningNumberBIZ();
            NZString SlipNo = bizRunning.GetCompleteRunningNo(new NZString(null, "ADJUST_NO"), new NZString(null, "TB_INV_TRANS_TR"));
            dto.SLIP_NO = SlipNo;


            dto.TRANS_ID = new NZString(null, "-"); // new transaction แน่ๆเพราะ adjust ใหม่
            dto.ITEM_CD = new NZString(null, dr[(int)eStockTakingUpdateColum.ITEM_CD]);
            dto.LOC_CD = new NZString(null, dr[(int)eStockTakingUpdateColum.LOC_CD]);

            if (dr[(int)eStockTakingUpdateColum.LOT_NO] == DBNull.Value)
            {
                dto.LOT_NO = new NZString(null, null);
            }
            else
            {
                dto.LOT_NO = new NZString(null, dr[(int)eStockTakingUpdateColum.LOT_NO]);
            }

            if (dr[(int)eStockTakingUpdateColum.PACK_NO] == DBNull.Value)
            {
                dto.PACK_NO = new NZString(null, null);
            }
            else
            {
                dto.PACK_NO = new NZString(null, dr[(int)eStockTakingUpdateColum.PACK_NO]);
            }

            if (dr[(int)eStockTakingUpdateColum.EXTERNAL_LOT_NO] == DBNull.Value)
            {
                dto.EXTERNAL_LOT_NO = new NZString(null, null);
            }
            else
            {
                dto.EXTERNAL_LOT_NO = new NZString(null, dr[(int)eStockTakingUpdateColum.EXTERNAL_LOT_NO]);
            }

            if (dr[(int)eStockTakingUpdateColum.FG_NO] == DBNull.Value)
            {
                dto.FG_NO = new NZString(null, null);
            }
            else
            {
                dto.FG_NO = new NZString(null, dr[(int)eStockTakingUpdateColum.FG_NO]);
            }

            //modify on 30 oct 2010
            //change adjust date from stock taking date to be
            //   - end period date :  current date > end period date 
            //   - current date : current date <= end period date
            dto.TRANS_DATE = new NZDateTime(null, argAdjustDate);
            dto.TRANS_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Adjustment);
            dto.TRAN_SUB_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eADJUST_TYPE.StockTaking);

            decimal decQty = 0;
            decQty = Convert.ToDecimal(dr[(int)eStockTakingUpdateColum.DIFF_QTY]);
            if (decQty > 0)
            {
                dto.IN_OUT_CLS = new NZString(null, DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.In));
                dto.QTY = new NZDecimal(null, decQty);
                dto.EFFECT_STOCK = new NZInt(null, 1);
            }
            else
            {
                dto.IN_OUT_CLS = new NZString(null, DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.Out));
                dto.QTY = new NZDecimal(null, Math.Abs(decQty));
                dto.EFFECT_STOCK = new NZInt(null, -1);
            }

            //dto.OBJ_ITEM_CD =
            //dto.REF_NO =
            //dto.REF_SLIP_NO =
            //dto.REF_SLIP_CLS =
            //dto.OTHER_DL_NO =
            dto.REMARK = new NZString(null, "Stock Taking on " + argStockTakingDate.ToString("dd/MM/yyyy"));
            dto.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dto.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
            dto.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dto.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;

            return dto;
        }

        public bool CheckLocationRunUpdateProcess(StockTakingDTO argStockTaking)
        {
            bool bRunUpdateProcess = false;


            StockTakingDAO dao = new StockTakingDAO(CommonLib.Common.CurrentDatabase);
            bRunUpdateProcess = dao.CheckLocationRunUpdateProcess(argStockTaking);


            return bRunUpdateProcess;
        }

        public bool CheckCompleteInputData(StockTakingDTO argStockTaking)
        {
            bool bCompleteInput = false;

            StockTakingDAO dao = new StockTakingDAO(CommonLib.Common.CurrentDatabase);
            bCompleteInput = dao.CheckCompleteInputData(argStockTaking);


            return bCompleteInput;
        }

        public string GetTextEffectInventory(StockTakingDTO argStockTaking)
        {
            string strEffectInventory = "";

            StockTakingDAO dao = new StockTakingDAO(CommonLib.Common.CurrentDatabase);
            strEffectInventory = dao.GetTextEffectInventory(argStockTaking);

            return strEffectInventory;
        }

        #endregion

        public void InsertStockTakingTemp(List<ImportStockTakingDTO> listData)
        {
            CommonLib.Common.CurrentDatabase.KeepConnection = true;
            CommonLib.Common.CurrentDatabase.BeginTransaction();

            try
            {
                StockTakingDAO dao = new StockTakingDAO(CommonLib.Common.CurrentDatabase);
                dao.DeleteStockTakingTemp(Common.CurrentUserInfomation.UserCD, Common.CurrentUserInfomation.Machine);

                foreach (ImportStockTakingDTO dto in listData)
                {
                    dao.InsertStockTakingTemp(dto);
                }

                CommonLib.Common.CurrentDatabase.Commit();
            }
            catch (Exception ex)
            {
                CommonLib.Common.CurrentDatabase.Rollback();
                throw ex;
            }
            finally
            {
                CommonLib.Common.CurrentDatabase.KeepConnection = false;
            }

        }

        public List<ImportStockTakingDTO> ValidateStockTakingTemp(NZString UserCD, NZString MachineCD)
        {
            CommonLib.Common.CurrentDatabase.KeepConnection = true;
            CommonLib.Common.CurrentDatabase.BeginTransaction();

            try
            {
                List<ImportStockTakingDTO> listError = null;

                StockTakingDAO dao = new StockTakingDAO(CommonLib.Common.CurrentDatabase);
                listError = dao.ValidateStockTakingTemp(UserCD, MachineCD);

                CommonLib.Common.CurrentDatabase.Commit();

                return listError;
            }
            catch (Exception ex)
            {
                CommonLib.Common.CurrentDatabase.Rollback();
                throw ex;
            }
            finally
            {
                CommonLib.Common.CurrentDatabase.KeepConnection = false;
            }

        }

        public void UpdateStockTaking(NZString UserCD, NZString MachineCD)
        {
            CommonLib.Common.CurrentDatabase.KeepConnection = true;
            CommonLib.Common.CurrentDatabase.BeginTransaction();

            try
            {
                StockTakingDAO dao = new StockTakingDAO(CommonLib.Common.CurrentDatabase);

                dao.UpdateStockTaking(UserCD, MachineCD);

                dao.DeleteStockTakingTemp(UserCD, MachineCD);

                CommonLib.Common.CurrentDatabase.Commit();
            }
            catch (Exception ex)
            {
                CommonLib.Common.CurrentDatabase.Rollback();
                throw ex;
            }
            finally
            {
                CommonLib.Common.CurrentDatabase.KeepConnection = false;
            }

        }

        public void ClearImportStockTaking(NZString UserCD, NZString MachineCD)
        {
            CommonLib.Common.CurrentDatabase.KeepConnection = true;
            CommonLib.Common.CurrentDatabase.BeginTransaction();

            try
            {
                StockTakingDAO dao = new StockTakingDAO(CommonLib.Common.CurrentDatabase);

                dao.ClearImportStockTaking(UserCD, MachineCD);

                CommonLib.Common.CurrentDatabase.Commit();
            }
            catch (Exception ex)
            {
                CommonLib.Common.CurrentDatabase.Rollback();
                throw ex;
            }
            finally
            {
                CommonLib.Common.CurrentDatabase.KeepConnection = false;
            }

        }

        public bool DoAdjustInventory()
        {
            StockTakingDAO dao = new StockTakingDAO(CommonLib.Common.CurrentDatabase);
            return dao.DoAdjustInventory();
        }

        public NZString GeneratePackNo()
        {
            CommonLib.Common.CurrentDatabase.KeepConnection = true;
            CommonLib.Common.CurrentDatabase.BeginTransaction(IsolationLevel.Serializable);

            NZString PackNo = new NZString();

            try
            {

                #region Lock Running Number gen.

                TransactionLockDAO daoTrans = new TransactionLockDAO(CommonLib.Common.CurrentDatabase);
                TransactionLockDTO dtoTrans = new TransactionLockDTO();
                NZString key1 = new NZString(null, "PACK_NO_AUTO_GEN");
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
                PackNo = bizRunning.GetCompleteRunningNo(new NZString(null, "PACK_NO_AUTO_GEN"), new NZString(null, "TB_INV_TRANS_TR"));

                daoTrans.DeleteWithKeys(null, key1, key2);
                CommonLib.Common.CurrentDatabase.Commit();
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

            return PackNo;
        }

    }
}
