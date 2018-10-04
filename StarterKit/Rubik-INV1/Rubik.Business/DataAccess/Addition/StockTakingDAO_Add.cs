//Create Date 12 Oct 2010
//Author: Bunyapat L.
//Object Name: Stock Taking DAO
//Description: Data access layer to retrive data from database

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Database;
using System.Data;
using Rubik.DTO;
using EVOFramework;

namespace Rubik.DAO
{
    public class StockTakingDAO : BaseDAO
    {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public StockTakingDAO(Database db)
        {
            this.m_db = db;
        }
        #endregion

        public bool CheckExistsStockTaking(StockTakingDTO argStockTaking)
        {
            bool bExistsStockTaking = false;

            Database db = m_db;

            DataRequest req = new DataRequest();
            req.CommandText = "S_STK010_CheckExistsStockTaking";
            req.Parameters.Add("@pDtm_StockTakingDate", argStockTaking.STOCK_TAKING_DATE);
            req.CommandType = System.Data.CommandType.StoredProcedure;
            int iResult = (int)db.ExecuteScalar(req);
            if (iResult == 1)
            {
                bExistsStockTaking = true;
            }
            else
            {
                bExistsStockTaking = false;
            }


            return bExistsStockTaking;
        }

        public StockTakingDTO RunStockTakingPreProcess(StockTakingDTO argStockTaking)
        {
            Database db = m_db;

            DataRequest req = new DataRequest();
            req.CommandText = "S_STK010_PreProcess";
            req.Parameters.Add("@pDtm_StockTakingDate", argStockTaking.STOCK_TAKING_DATE);
            req.Parameters.Add("@pVar_YearMonth", argStockTaking.YEAR_MONTH);
            req.Parameters.Add("@pVar_PreProcessBy", argStockTaking.CRT_BY);
            req.Parameters.Add("@pVar_Remark", argStockTaking.REMARK);
            req.Parameters.Add("@pVar_Machine", argStockTaking.CRT_MACHINE);
            req.CommandType = System.Data.CommandType.StoredProcedure;
            db.ExecuteNonQuery(req);

            return argStockTaking;
        }

        public StockTakingDTO LoadLastStockTaking()
        {

            StockTakingDTO ret = null;

            Database db = m_db;

            DataRequest req = new DataRequest();
            req.CommandText = "S_STK010_LoadLatestStockTaking";
            req.CommandType = CommandType.StoredProcedure;


            db.KeepConnection = true;
            using (IDataReader reader = db.ExecuteDataReader(req))
            {
                if (reader.Read())
                {
                    ret = new StockTakingDTO();
                    ret.STOCK_TAKING_DATE = reader.GetDateTime(0);
                    ret.YEAR_MONTH = reader.GetString(1);
                    ret.PRE_PROCESS_BY = reader.GetString(2);
                    ret.PRE_PROCESS_DATE = reader.GetDateTime(3);
                    ret.REMARK = reader.GetString(4);
                    ret.CRT_BY = reader.GetString(5);
                    ret.CRT_DATE = reader.GetDateTime(6);
                    ret.CRT_MACHINE = reader.GetString(7);
                    ret.UPD_BY = reader.GetString(8);
                    ret.UPD_DATE = reader.GetDateTime(9);
                    ret.UPD_MACHINE = reader.GetString(10);

                    ret.PRE_PROCESS_NAME = reader.GetString(11);

                }
            }
            db.KeepConnection = false;

            return ret;
        }


        public DataTable LoadStockTakingEntryData(StockTakingDTO argStockTaking)
        {
            DataTable ret = null;

            Database db = m_db;

            DataRequest req = new DataRequest();
            req.CommandText = "S_STK030_LoadStockTakingEntryData";
            req.Parameters.Add("@pDtm_StockTakingDate", argStockTaking.STOCK_TAKING_DATE);
            req.Parameters.Add("@pVar_LocationCode", argStockTaking.LOCATION_CODE);
            req.Parameters.Add("@pInt_IncompleteFlag", argStockTaking.SEARCH_INCOMPLETE);

            req.CommandType = System.Data.CommandType.StoredProcedure;
            DataSet ds = db.ExecuteDataSet(req);

            if (ds != null && ds.Tables.Count > 0)
            {
                ret = ds.Tables[0];
            }

            return ret;
        }

        public int GetFlagRunUpdateProcess(StockTakingDTO argStockTaking)
        {
            int ret = 1;

            Database db = m_db;

            DataRequest req = new DataRequest();
            req.CommandText = "S_STK030_GetFlagRunUpdateProcess";
            req.Parameters.Add("@pDtm_StockTakingDate", argStockTaking.STOCK_TAKING_DATE);
            req.Parameters.Add("@pVar_LocationCode", argStockTaking.LOCATION_CODE);

            req.CommandType = System.Data.CommandType.StoredProcedure;
            ret = (int)db.ExecuteScalar(req);

            return ret;
        }

        public void InsertStockTakingEntry(StockTakingDetailDTO dtoInsert)
        {
            Database db = m_db;

            DataRequest req = new DataRequest();
            req.CommandText = "S_STK030_InsertStockTakingEntry";
            req.Parameters.Add("@pDtm_StockTakingDate", dtoInsert.STOCK_TAKING_DATE);
            req.Parameters.Add("@pVar_ItemCode", dtoInsert.ITEM_CD);
            req.Parameters.Add("@pVar_LocationCode", dtoInsert.LOC_CD);
            req.Parameters.Add("@pVar_LotNo", dtoInsert.LOT_NO);
            req.Parameters.Add("@pVar_ExternalLotNo", dtoInsert.EXTERNAL_LOT_NO);
            req.Parameters.Add("@pVar_PackNo", dtoInsert.PACK_NO);
            req.Parameters.Add("@pVar_FGNo", dtoInsert.FG_NO);
            req.Parameters.Add("@pNum_CountQty", dtoInsert.COUNT_QTY);
            req.Parameters.Add("@pInt_EffectInventoryFlag", dtoInsert.EFFECT_INVENTORY_FLAG);
            req.Parameters.Add("@pInt_ManualAddFlag", dtoInsert.MANUAL_ADD_FLAG);
            req.Parameters.Add("@pVar_TagNo", dtoInsert.TAG_NO);
            req.Parameters.Add("@pVar_Remark", dtoInsert.REMARK);
            req.Parameters.Add("@pVar_UpdateBy", dtoInsert.UPD_BY);
            req.Parameters.Add("@pVar_UpdateMachine", dtoInsert.UPD_MACHINE);

            req.CommandType = System.Data.CommandType.StoredProcedure;
            db.ExecuteNonQuery(req);
        }

        public void UpdateStockTakingEntry(StockTakingDetailDTO dtoUpdate)
        {
            Database db = m_db;

            DataRequest req = new DataRequest();
            req.CommandText = "S_STK030_UpdateStockTakingEntry";
            req.Parameters.Add("@pDtm_StockTakingDate", dtoUpdate.STOCK_TAKING_DATE);
            req.Parameters.Add("@pNum_ID", dtoUpdate.ID);
            if (dtoUpdate.COUNT_QTY == null)
            {
                req.Parameters.Add("@pNum_CountQty", DBNull.Value);
            }
            else
            {
                req.Parameters.Add("@pNum_CountQty", dtoUpdate.COUNT_QTY);
            }
            //req.Parameters.Add("@pVar_ExternalLotNo", dtoUpdate.EXTERNAL_LOT_NO);
            req.Parameters.Add("@pInt_EffectInventoryFlag", dtoUpdate.EFFECT_INVENTORY_FLAG);
            req.Parameters.Add("@pVar_FGNo", dtoUpdate.FG_NO);
            req.Parameters.Add("@pVar_TagNo", dtoUpdate.TAG_NO);
            req.Parameters.Add("@pVar_Remark", dtoUpdate.REMARK);
            req.Parameters.Add("@pVar_UpdateBy", dtoUpdate.UPD_BY);
            req.Parameters.Add("@pVar_UpdateMachine", dtoUpdate.UPD_MACHINE);

            req.CommandType = System.Data.CommandType.StoredProcedure;
            db.ExecuteNonQuery(req);
        }

        public void DeleteStockTakingEntry(StockTakingDetailDTO dtoDelete)
        {
            Database db = m_db;

            DataRequest req = new DataRequest();
            req.CommandText = "S_STK030_DeleteStockTakingEntry";
            req.Parameters.Add("@pDtm_StockTakingDate", dtoDelete.STOCK_TAKING_DATE);
            req.Parameters.Add("@pNum_ID", dtoDelete.ID);
            req.Parameters.Add("@pVar_UpdateBy", dtoDelete.UPD_BY);
            req.Parameters.Add("@pVar_UpdateMachine", dtoDelete.UPD_MACHINE);

            req.CommandType = System.Data.CommandType.StoredProcedure;
            db.ExecuteNonQuery(req);
        }


        public DataTable LoadStockTakingForUpdateProcess(StockTakingDTO argStockTaking)
        {
            DataTable ret = null;

            Database db = m_db;

            DataRequest req = new DataRequest();
            req.CommandText = "S_STK040_LoadStockTakingForUpdateProcess";
            req.Parameters.Add("@pDtm_StockTakingDate", argStockTaking.STOCK_TAKING_DATE);
            req.Parameters.Add("@pVar_LocationCode", argStockTaking.LOCATION_CODE);
            req.Parameters.Add("@pVar_UpdateBy", argStockTaking.UPD_BY);
            req.Parameters.Add("@pVar_UpdateMachine", argStockTaking.UPD_MACHINE);

            req.CommandType = System.Data.CommandType.StoredProcedure;
            DataSet ds = db.ExecuteDataSet(req);

            if (ds != null && ds.Tables.Count > 0)
            {
                ret = ds.Tables[0];
            }

            return ret;
        }

        public bool CheckLocationRunUpdateProcess(StockTakingDTO argStockTaking)
        {
            bool bRunUpdateProcess = false;

            Database db = m_db;

            DataRequest req = new DataRequest();
            req.CommandText = "S_STK040_CheckLocationRunUpdateProcess";
            req.Parameters.Add("@pDtm_StockTakingDate", argStockTaking.STOCK_TAKING_DATE);
            req.Parameters.Add("@pVar_LocationCode", argStockTaking.LOCATION_CODE);

            req.CommandType = System.Data.CommandType.StoredProcedure;
            int iReturnCode = (int)db.ExecuteScalar(req);

            if (iReturnCode == 1)
            {
                bRunUpdateProcess = true;
            }
            else
            {
                bRunUpdateProcess = false;
            }

            return bRunUpdateProcess;
        }

        public bool CheckCompleteInputData(StockTakingDTO argStockTaking)
        {
            bool bCompleteInput = false;

            Database db = m_db;

            DataRequest req = new DataRequest();
            req.CommandText = "S_STK040_CheckCompleteInputData";
            req.Parameters.Add("@pDtm_StockTakingDate", argStockTaking.STOCK_TAKING_DATE);
            req.Parameters.Add("@pVar_LocationCode", argStockTaking.LOCATION_CODE);

            req.CommandType = System.Data.CommandType.StoredProcedure;
            int iReturnCode = (int)db.ExecuteScalar(req);

            if (iReturnCode == 1)
            {
                bCompleteInput = true;
            }
            else
            {
                bCompleteInput = false;
            }

            return bCompleteInput;
        }


        public string GetTextEffectInventory(StockTakingDTO argStockTaking)
        {
            string strEffectInventory = "";

            Database db = m_db;

            DataRequest req = new DataRequest();
            req.CommandText = "S_STK040_GetTextEffectInventory";
            req.Parameters.Add("@pDtm_StockTakingDate", argStockTaking.STOCK_TAKING_DATE);
            req.Parameters.Add("@pVar_LocationCode", argStockTaking.LOCATION_CODE);

            req.CommandType = System.Data.CommandType.StoredProcedure;
            strEffectInventory = (string)db.ExecuteScalar(req);

            return strEffectInventory;
        }

        public void InsertStockTakingTemp(ImportStockTakingDTO dtoImportData)
        {
            Database db = m_db;

            DataRequest req = new DataRequest();
            req.CommandText = "S_STK060_InsertImportStockTaking";
            req.Parameters.Add("@pInt_LINE_NO", DataType.Number, dtoImportData.LINE_NO.Value);
            req.Parameters.Add("@pVar_FILENAME", DataType.NVarChar, dtoImportData.IMPORT_FILE_NAME.Value);
            req.Parameters.Add("@pVar_PROCESS_CD", DataType.NVarChar, dtoImportData.PROCESS_CD.Value);
            req.Parameters.Add("@pVar_ITEM_CD", DataType.Number, dtoImportData.ITEM_CD.Value);
            req.Parameters.Add("@pVar_WEIGHT", DataType.NVarChar,dtoImportData.WEIGHT.Value);
            req.Parameters.Add("@pVar_QTY", DataType.NVarChar, dtoImportData.QTY.Value);
            req.Parameters.Add("@pVar_TAG_NO", DataType.NVarChar, dtoImportData.TAG_NO.Value);
            req.Parameters.Add("@pVar_REMARK", DataType.NVarChar, dtoImportData.REMARK.Value);
            req.Parameters.Add("@pVar_CREATE_BY", DataType.NVarChar, dtoImportData.CREATE_BY.Value);
            req.Parameters.Add("@pVar_CREATE_MACHINE", DataType.NVarChar, dtoImportData.CREATE_MACHINE.Value);

            req.CommandType = System.Data.CommandType.StoredProcedure;
            db.ExecuteNonQuery(req);
        }
        public void DeleteStockTakingTemp(NZString CREATE_BY, NZString CREATE_MACHINE)
        {
            Database db = m_db;

            DataRequest req = new DataRequest();
            req.CommandText = "S_STK060_DeleteImportStockTaking";
            req.Parameters.Add("@pVar_CREATE_BY", CREATE_BY.Value);
            req.Parameters.Add("@pVar_CREATE_MACHINE", CREATE_MACHINE.Value);

            req.CommandType = System.Data.CommandType.StoredProcedure;
            db.ExecuteNonQuery(req);
        }
        public List<ImportStockTakingDTO> ValidateStockTakingTemp(NZString CREATE_BY, NZString CREATE_MACHINE)
        {
            Database db = m_db;

            DataRequest req = new DataRequest();
            req.CommandText = "S_STK060_ValidateImportStockTaking";
            req.Parameters.Add("@pVar_CREATE_BY", CREATE_BY.Value);
            req.Parameters.Add("@pVar_CREATE_MACHINE", CREATE_MACHINE.Value);

            req.CommandType = System.Data.CommandType.StoredProcedure;

            return db.ExecuteForList<ImportStockTakingDTO>(req);
        }
        public void UpdateStockTaking(NZString CREATE_BY, NZString CREATE_MACHINE)
        {
            Database db = m_db;

            DataRequest req = new DataRequest();
            req.CommandText = "S_STK060_UpdateStockTaking";
            req.Parameters.Add("@pVar_CREATE_BY", CREATE_BY.Value);
            req.Parameters.Add("@pVar_CREATE_MACHINE", CREATE_MACHINE.Value);

            req.CommandType = System.Data.CommandType.StoredProcedure;
            db.ExecuteNonQuery(req);
        }
        public void ClearImportStockTaking(NZString UPDATE_BY, NZString UPDATE_MACHINE)
        {
            Database db = m_db;

            DataRequest req = new DataRequest();
            req.CommandText = "S_STK060_DeleteStockTaking";
            req.Parameters.Add("@pVar_UPD_BY", UPDATE_BY.Value);
            req.Parameters.Add("@pVar_UPD_MACHINE", UPDATE_MACHINE.Value);
            req.CommandType = CommandType.StoredProcedure;
            db.ExecuteNonQuery(req);
        }
        public bool DoAdjustInventory()
        {
            int doAdjust = 0;

            Database db = m_db;

            DataRequest req = new DataRequest();
            req.CommandText = "S_STK060_CheckDoAdjustInventory";
            req.CommandType = System.Data.CommandType.StoredProcedure;
            doAdjust = (int)db.ExecuteScalar(req);

            return doAdjust > 0;
        }
    }
}
