using System;
using System.Collections.Generic;
using System.Data;
using Rubik.DAO;
using Rubik.DTO;
using EVOFramework.Database;
using Rubik.Validators;
using EVOFramework;
using Rubik.Data;
using CommonLib;

namespace Rubik.BIZ {

    public class DemandOrderBIZ {

        #region Load Data

        public List<DemandOrderDTO> LoadDemandOrder(DemandOrderDTO dto) {

            DemandOrderDAO dao = new DemandOrderDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadDemandOrder(null, dto.YEAR_MONTH, dto.CUSTOMER_CD);

        }

        public DataTable LoadDemandOrderSummary(DemandOrderDTO dto) {

            DemandOrderDAO dao = new DemandOrderDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadDemandOrderSummary(null, dto.YEAR_MONTH, dto.CUSTOMER_CD);

        }

        public DataTable LoadSourceOrderSummaryEachMonth(GenerateMRPDTO dto) {

            DemandOrderDAO dao = new DemandOrderDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadSourceOrderSummaryEachMonth(null, dto, Common.CurrentUserInfomation.DateFormat.ToString());

        }

        #endregion

        #region Operation

        public void Add(DemandOrderDTO dtoOrder, List<TmpDemandOrderDTO> dtoItems) {

            CheckBeforeAdd(dtoOrder, dtoItems);

            SaveData(dtoOrder, dtoItems);  
        }

        public void Update(DemandOrderDTO dtoOrder , List<TmpDemandOrderDTO> dtoItems) 
        {
            CheckBeforeUpdate(dtoOrder, dtoItems);

            SaveData(dtoOrder, dtoItems);            
        }

        public void SaveData(DemandOrderDTO dtoOrder, List<TmpDemandOrderDTO> dtoItems) 
        {
            Database db = null;

            try {
                db = Common.CurrentDatabase;
                db.KeepConnection = true;
                db.BeginTransaction(IsolationLevel.Serializable);

                TmpDemandOrderDAO daoTmpOrder = new TmpDemandOrderDAO(db);
                DemandOrderDAO daoOrder = new DemandOrderDAO(db);

                //add all record to temp table
                daoTmpOrder.DeleteTempDemandOrder(null, dtoOrder);
                foreach (TmpDemandOrderDTO dto in dtoItems) {
                    daoTmpOrder.InsertTempDemandOrder(null, dto);
                }

                //set all record to in-active and update data for item in table
                daoOrder.DeleteOrder(null, dtoOrder);
                daoOrder.UpdateOrder(null, dtoOrder);

                //delete data in tmp
                daoTmpOrder.DeleteTempDemandOrder(null, dtoOrder);

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
        }

        public int DeleteDemandOrder(DemandOrderDTO dto) 
        {
            int iResult = -1;
            Database db = null;

            try {

                CheckBeforeDelete(dto);

                db = Common.CurrentDatabase;
                db.KeepConnection = true;
                db.BeginTransaction(IsolationLevel.Serializable);                

                DemandOrderDAO daoOrder = new DemandOrderDAO(db);             
                iResult = daoOrder.DeleteOrder(null, dto);

                db.Commit();                
            }
            catch (Exception) {
                db.Rollback();
                throw;
            }
            finally {
                if (db.DBConnectionState == ConnectionState.Open)
                    db.Close();
            }
            return iResult;
        }

        public int DeleteTargetDemandOrder(DemandOrderDTO dto)
        {
            int iResult = -1;
            Database db = null;

            try
            {

                CheckBeforeDelete(dto);

                db = Common.CurrentDatabase;
                db.KeepConnection = true;
                db.BeginTransaction(IsolationLevel.Serializable);

                DemandOrderDAO daoOrder = new DemandOrderDAO(db);
                iResult = daoOrder.DeleteTargetOrder(null, dto);

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
            return iResult;
        }
        #endregion

        #region Validate

        public bool IsExists(DemandOrderDTO dto) 
        {
            DemandOrderDAO dao = new DemandOrderDAO(CommonLib.Common.CurrentDatabase);
            return dao.ExistsByHeader(null, dto.YEAR_MONTH, dto.CUSTOMER_CD);
        }

        public bool CanEditing(DemandOrderDTO dto) 
        {
            return (DateTime.Compare(dto.YEAR_MONTH, DateTime.Now.Date) > 1);
        }

        public bool IsHoliday(DateTime dtmPERIOD, DateTime dtmDATE) 
        {
            DemandOrderDAO dao = new DemandOrderDAO(CommonLib.Common.CurrentDatabase);
            return dao.IsHoliday(null ,dtmPERIOD, dtmDATE);
        }

        private void CheckCustomer(DemandOrderDTO dtoOrder)
        {
            ErrorItem errorItem;

            DealingBIZ bizCustomer = new DealingBIZ();
            DealingDTO dtoCustomer = bizCustomer.LoadLocation(dtoOrder.CUSTOMER_CD);
            if (dtoCustomer == null) 
            {
                errorItem = new ErrorItem(null, TKPMessages.eValidate.VLM0108.ToString());
                throw new BusinessException(errorItem);
            }

            //check customer is exists
            //CustomerBIZ bizCustomer = new CustomerBIZ();
            //CustomerDTO dtoCustomer = new CustomerDTO();
            //dtoCustomer.CUSTOMER_CODE = dtoOrder.CUSTOMER_CD;
            //if (!bizCustomer.IsExists(dtoCustomer)) {
            //    errorItem = new ErrorItem(null, TKPMessages.eValidate.VLM0108.ToString());
            //    throw new BusinessException(errorItem);
            //}

        }

        private void CheckOrder(DemandOrderDTO dtoOrder) 
        {
            ErrorItem errorItem;

            //check customer and year/month is exists
            if (IsExists(dtoOrder)) {
                string[] param = new string[2];
                param[0] = dtoOrder.YEAR_MONTH.ToString();
                param[1] = dtoOrder.CUSTOMER_CD;

                errorItem = new ErrorItem(null, TKPMessages.eValidate.VLM0107.ToString(), param);
                throw new BusinessException(errorItem);
            }
        }

        private void CheckOrderItem(List<TmpDemandOrderDTO> dtoItems) 
        {
            ErrorItem errorItem;
            if (dtoItems.Count == 0) {
                errorItem = new ErrorItem(null, TKPMessages.eValidate.VLM0115.ToString());
                throw new BusinessException(errorItem);
            }

            //check item is exists in master
            ItemBIZ bizItem = new ItemBIZ();
            foreach (TmpDemandOrderDTO orderItem in dtoItems) {
                ItemDTO dtoItem = bizItem.LoadItem(orderItem.ITEM_CD);
                if (dtoItem == null) {
                    errorItem = new ErrorItem(null, TKPMessages.eValidate.VLM0109.ToString());
                    throw new BusinessException(errorItem);
                }
            }
        }


        public bool CheckBeforeUpdate(DemandOrderDTO dtoOrder, List<TmpDemandOrderDTO> dtoItems) 
        {
            CheckCustomer(dtoOrder);
            CheckOrderItem(dtoItems);

            return true;
        }

        public bool CheckBeforeAdd(DemandOrderDTO dtoOrder, List<TmpDemandOrderDTO> dtoItems) 
        {   
            CheckCustomer(dtoOrder);
            CheckOrder(dtoOrder);
            CheckOrderItem(dtoItems);

            return true;
        }
        public bool CheckBeforeDelete(DemandOrderDTO dto) {
            return true;
        }
        #endregion


        public DataTable LoadDemandOrderInRange(NZDateTime nZDateTimeBegin, NZDateTime nZDateTimeEnd)
        {
            DemandOrderDAO dao = new DemandOrderDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadDemandOrderInRange(null, nZDateTimeBegin, nZDateTimeEnd);
        }
    }
}
