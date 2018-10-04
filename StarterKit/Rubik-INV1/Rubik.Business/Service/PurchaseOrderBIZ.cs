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
using EVOFramework.Data;

namespace Rubik.BIZ {

    public class PurchaseOrderBIZ {

        #region Load Data

        public PurchaseOrderHDTO LoadByPK(PurchaseOrderHDTO dto) {

            PurchaseOrderHDAO dao = new PurchaseOrderHDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadByPK(null, dto.PO_NO);
        }

        public List<PurchaseOrderDDTO> LoadDetailByPO(PurchaseOrderHDTO dto) {

            PurchaseOrderDDAO dao = new PurchaseOrderDDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadPurchaseOrderDByPONo(null, dto);
        }

        public DataTable LoadPurchaseOrderDByPONo(DateTime dtmPO_DATE_FROM, DateTime dtmPO_DATE_TO) {
            PurchaseOrderHDAO dao = new PurchaseOrderHDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadPurchaseOrderDByPONo(null, dtmPO_DATE_FROM, dtmPO_DATE_TO);
        }

        // edit by Chatas C. 17 June 2011
        /// <summary>
        /// Load Purchase orde in selected time range.
        /// </summary>
        /// <param name="dtmPO_DATE_FROM">Start Date</param>
        /// <param name="dtmPO_DATE_TO">End Date</param>
        /// <param name="bIncludeCancel">Is show all PO include cancel</param>
        /// <returns></returns>
        public DataTable LoadPurchaseOrderDByPONoWithCriteria(DateTime dtmPO_DATE_FROM, DateTime dtmPO_DATE_TO, bool bIncludeCancel) 
        {
            PurchaseOrderHDAO dao = new PurchaseOrderHDAO(CommonLib.Common.CurrentDatabase);
            if (bIncludeCancel)
                return dao.LoadAllPurchaseOrderDByPONo(null, dtmPO_DATE_FROM, dtmPO_DATE_TO);
            else
                return dao.LoadPurchaseOrderDByPONo(null, dtmPO_DATE_FROM, dtmPO_DATE_TO);
        }
        #endregion

        #region Operation

        /// <summary>
        /// Add PO Header and detail into db.
        /// </summary>
        /// <param name="dtoH">PO Header that will be added into database.</param>
        /// <param name="dtoDs">PO Detail List that be linked with Header.</param>
        public void AddPO(PurchaseOrderHDTO dtoH, List<PurchaseOrderDDTO> dtoDs) {
            Database db = null;

            try {

                CheckBeforeAdd(dtoH, dtoDs);

                db = Common.CurrentDatabase;
                db.KeepConnection = true;
                db.BeginTransaction(IsolationLevel.Serializable);

                PurchaseOrderHDAO daoH = new PurchaseOrderHDAO(db);
                PurchaseOrderDDAO daoD = new PurchaseOrderDDAO(db);

                // Add Header
                daoH.AddNew(null, dtoH);

                // Add Details
                foreach (PurchaseOrderDDTO dtoD in dtoDs) {
                    daoD.AddNew(null, dtoD);
                }

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
        }

        /// <summary>
        /// Update PO (include add , edit , delete) 
        /// </summary>
        /// <param name="dtoH">PO Header that want to update.</param>
        /// <param name="dtoDsUpdate">PO Detail List that want to update.</param>
        /// <param name="dtoDSAdd">PO Detail List that want to add into this PO Header.</param>
        /// <param name="dtoDSDel">PO Detail List that want to delete from this PO Header.</param>
        public void UpdatePO(PurchaseOrderHDTO dtoH, List<PurchaseOrderDDTO> dtoDsUpdate, List<PurchaseOrderDDTO> dtoDSAdd, List<PurchaseOrderDDTO> dtoDSDel) {
            Database db = null;

            try {
                CheckBeforeUpdate(dtoH, dtoDsUpdate);

                db = Common.CurrentDatabase;
                db.KeepConnection = true;
                db.BeginTransaction(IsolationLevel.Serializable);

                PurchaseOrderHDAO daoH = new PurchaseOrderHDAO(db);
                PurchaseOrderDDAO daoD = new PurchaseOrderDDAO(db);

                //----------Update Header ------------
                daoH.UpdateWithoutPK(null, dtoH);
               

                // Add Details Phase
                if (dtoDSAdd != null && dtoDSAdd.Count > 0) {
                    foreach (PurchaseOrderDDTO dtoD in dtoDSAdd) {
                        daoD.AddNew(null, dtoD);
                    }
                }

                // Update Details Phase
                if (dtoDsUpdate != null && dtoDsUpdate.Count > 0)
                {
                    foreach (PurchaseOrderDDTO dtoD in dtoDsUpdate)
                    {
                        // เก็บผลต่างระหว่าง Receive Qty กับ PO Qty 
                        // ถ้า Receive Qty > PO Qty หมายความว่า ได้มีการ update PO Qty ให้ลดลงจากปกติ และ Receive Qty มีมากเกินที่ต้องการ 
                        // จะลด Receive Qty ให้เท่ากับ PO Qty และนำผลต่างนั้นไปเก็บไว้ใน Stack รอการใช้งานต่อไป                          
                        decimal dChangeQty = dtoD.RECEIVE_QTY - dtoD.PO_QTY;

                        // ถ้าค่า receive มากกว่า po qty จะปรับ receive ให้เท่ากับ po qty + สถานะเป็น 01
                        if (dtoD.RECEIVE_QTY >= dtoD.PO_QTY)
                        {
                            dtoD.RECEIVE_QTY = dtoD.PO_QTY;
                            if (!dtoD.STATUS.Value.Equals("02"))
                                dtoD.STATUS = (NZString)"01";
                        }
                        // ถ้าค่า receive น้อยกว่า po qty จะเปลี่ยนสถานะเป็น 00 คือ PO รายการนี้ยังได้ของไม่ครบ
                        else
                        {
                            if (!dtoD.STATUS.Value.Equals("02"))
                                dtoD.STATUS = (NZString)"00";
                        }
                        daoD.UpdateWithoutPK(null, dtoD);

                        // ถ้า receive มีการเปลี่ยนแปลง จะเรียก FIFO process
                        if (dChangeQty > 0)
                        {
                            daoH.UpdateBalance(null, dtoH, dtoD, dChangeQty);
                        }
                    }
                }

                // Delete Details Phase
                if (dtoDSDel != null && dtoDSDel.Count > 0)
                {
                    _DeletePOLine(db, dtoH, dtoDSDel);
                    // เมื่อลบเสร็จเช็คว่า ถ้าใน Purchase order ใบนี้ไม่มี list การสั่งซื้อเหลืออยู่แล้ว ให้กำหนดสถานะเป็น inactive
                    if (dtoDSAdd.Count == 0 && !daoD.IsExistPOLine(db, dtoH.PO_NO))
                    {
                        _CancelPO(dtoH, db);
                    }
                }

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
        }

        /// <summary>
        /// Private method that use for delete.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="dtoH"></param>
        /// <param name="dtoDs"></param>
        private void _DeletePOLine(Database db, PurchaseOrderHDTO dtoH, List<PurchaseOrderDDTO> dtoDs)
        {

            CheckBeforeUpdate(dtoH, dtoDs);

            PurchaseOrderHDAO daoH = new PurchaseOrderHDAO(db);
            PurchaseOrderDDAO daoD = new PurchaseOrderDDAO(db);

            if (dtoDs == null)
                return;

            foreach (PurchaseOrderDDTO dtoD in dtoDs)
            {
                PurchaseOrderDDTO dtoDTmp = dtoD;
                dtoD.RECEIVE_QTY = (NZDecimal)daoD.DeleteWithReturnReceiveQTY(null, dtoD);

                daoH.UpdateBalance(null, dtoH, dtoD, dtoD.RECEIVE_QTY);
            }

        }

        /// <summary>
        /// Delete PO Line and Call Update PO balance Function
        /// </summary>
        /// <param name="dtoH">PO Header that be the owner of PO Detail List</param>
        /// <param name="dtoDs">PO Detail List that want to delete.</param>
        public void DeletePOLine(PurchaseOrderHDTO dtoH, List<PurchaseOrderDDTO> dtoDs)
        {
            Database db = null;

            try
            {
                db = Common.CurrentDatabase;
                db.KeepConnection = true;
                db.BeginTransaction(IsolationLevel.Serializable);

                _DeletePOLine(db, dtoH, dtoDs);

                PurchaseOrderDDAO daoD = new PurchaseOrderDDAO();
                // เมื่อลบเสร็จเช็คว่า ถ้าใน Purchase order ใบนี้ไม่มี list การสั่งซื้อเหลืออยู่แล้ว ให้กำหนดสถานะเป็น inactive
                if (!daoD.IsExistPOLine(db, dtoH.PO_NO))
                {
                    _CancelPO(dtoH, db);
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
                    db.Close();
            }
        }

        /// <summary>
        /// Private method that use for cancel PO
        /// </summary>
        /// <param name="dtoH"></param>
        /// <param name="db"></param>
        private void _CancelPO(PurchaseOrderHDTO dtoH, Database db)
        {
            PurchaseOrderHDAO daoH = new PurchaseOrderHDAO(db);
            PurchaseOrderDDAO daoD = new PurchaseOrderDDAO(db);

            List<PurchaseOrderDDTO> dDTOList = daoD.LoadPurchaseOrderDByPONo(null, dtoH);
            foreach (PurchaseOrderDDTO dtoD in dDTOList)
                daoH.UpdateBalance(null, dtoH, dtoD, dtoD.RECEIVE_QTY);
            daoH.Cancel(null, dtoH);
        }

        /// <summary>
        /// Cancel PO Header and Update Balance PO Function.
        /// </summary>
        /// <param name="dtoH">PO Header that want to cancel</param>
        public void CancelPO(PurchaseOrderHDTO dtoH)
        {
            Database db = null;

            try
            {

                db = Common.CurrentDatabase;
                db.KeepConnection = true;
                db.BeginTransaction(IsolationLevel.Serializable);

                _CancelPO(dtoH, db);

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

        //public void DeletePO(PurchaseOrderHDTO dtoH) {
        //    Database db = null;

        //    try {

        //        CheckBeforeDelete(dtoH);

        //        db = Common.CurrentDatabase;
        //        db.KeepConnection = true;
        //        db.BeginTransaction(IsolationLevel.Serializable);

        //        PurchaseOrderHDAO daoH = new PurchaseOrderHDAO(db);
        //        PurchaseOrderDDAO daoD = new PurchaseOrderDDAO(db);

        //        //----------delete Header : set InActive ------------
        //        daoH.DeletePurchaseOrderH(null, dtoH);

        //        //----------delete all detail------------------
        //        daoD.DeleteByPO(null, dtoH);

        //        db.Commit();
        //    }
        //    catch (Exception) {
        //        db.Rollback();
        //        throw;
        //    }
        //    finally {
        //        if (db.DBConnectionState == ConnectionState.Open)
        //            db.Close();
        //    }
        //}

        #endregion

        #region Validate

        private void CheckPOIsExists(PurchaseOrderHDTO dtoH) {
            ErrorItem errorItem;

            PurchaseOrderHDAO dao = new PurchaseOrderHDAO(CommonLib.Common.CurrentDatabase);
            if (dao.Exist(null, dtoH.PO_NO)) {
                errorItem = new ErrorItem(null, TKPMessages.eValidate.VLM0110.ToString());
                throw new BusinessException(errorItem);
            }
        }

        private void CheckPurchaseOrderItem(List<PurchaseOrderDDTO> dtoDs) {
            ErrorItem errorItem;

            //check item is exists in master
            ItemBIZ bizItem = new ItemBIZ();
            foreach (PurchaseOrderDDTO item in dtoDs) {
                ItemDTO dtoItem = bizItem.LoadItem(item.ITEM_CD);
                if (dtoItem == null) {
                    errorItem = new ErrorItem(null, TKPMessages.eValidate.VLM0109.ToString());
                    throw new BusinessException(errorItem);
                }
            }
        }

        private bool CheckBeforeAdd(PurchaseOrderHDTO dtoH, List<PurchaseOrderDDTO> dtoDs) {
            //Check PO exists
            CheckPOIsExists(dtoH);

            //Check Item is exist?
            CheckPurchaseOrderItem(dtoDs);
            return true;
        }

        private bool CheckBeforeUpdate(PurchaseOrderHDTO dtoH, List<PurchaseOrderDDTO> dtoDs) {

            //Check Item is exist?
            CheckPurchaseOrderItem(dtoDs);

            return true;
        }

        private bool CheckBeforeDelete(PurchaseOrderHDTO dtoH) {

            CanDeletePO(dtoH);

            return true;
        }

        private bool CheckBeforeGeneratePO(List<PurchaseOrderHDTO> dtoHeader, List<PurchaseOrderDDTO> dtoDetail) {

            if (dtoHeader == null || dtoHeader.Count == 0) 
            {
                ErrorItem err = new ErrorItem(null, TKPMessages.eValidate.VLM0151.ToString());
                throw new BusinessException(err);
            }
            if (dtoDetail == null || dtoDetail.Count == 0) {
                ErrorItem err = new ErrorItem(null, TKPMessages.eValidate.VLM0151.ToString());
                throw new BusinessException(err);
            }
            return true;
        }

        private void CanDeletePO(PurchaseOrderHDTO dtoH) {
            PurchaseOrderDDAO dao = new PurchaseOrderDDAO(CommonLib.Common.CurrentDatabase);
            DataTable dt = dao.LoadReceivePurchaseOrderD(null, dtoH);
            if (dt != null && dt.Rows.Count > 0) {
                ErrorItem errorItem = new ErrorItem(null, TKPMessages.eValidate.VLM0111.ToString());
                throw new BusinessException(errorItem);
            }
        }

        #endregion

       

        public DataTable LoadGeneratePO(NZDateTime dtmFrom,NZDateTime dtmTo,NZString strItemCDFrom,NZString strItemCDTo,NZString strLocCDFrom,NZString strLocCDTo,NZInt iPOInterval) 
        {
            GeneratePO(dtmFrom, dtmTo, strItemCDFrom, strItemCDTo, strLocCDFrom, strLocCDTo, iPOInterval);

            TmpPurchaseOrderDAO dao = new TmpPurchaseOrderDAO(Common.CurrentDatabase);
            DataTable dt = dao.LoadTmpGeneratePO(null,Common.CurrentUserInfomation.UserCD, Common.CurrentUserInfomation.Machine);
            
            return dt;           
        }

        private void GeneratePO(NZDateTime dtmFrom, NZDateTime dtmTo, NZString strItemCDFrom, NZString strItemCDTo, NZString strLocCDFrom, NZString strLocCDTo, NZInt iPOInterval) 
        {
            Database db = null;
            TmpPurchaseOrderDAO dao = null;
            try {

                db = Common.CurrentDatabase;
                db.KeepConnection = true;
                db.BeginTransaction(IsolationLevel.Serializable);

                dao = new TmpPurchaseOrderDAO(db);
                dao.GeneratePO(null, dtmFrom, dtmTo, strItemCDFrom, strItemCDTo, strLocCDFrom, strLocCDTo, Common.CurrentUserInfomation.UserCD, Common.CurrentUserInfomation.Machine, iPOInterval);
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
        }

        public void SaveGeneratePO(List<PurchaseOrderHDTO> dtoHeader, List<PurchaseOrderDDTO> dtoDetail) 
        {
            Database db = null;
            try 
            {
                db = Common.CurrentDatabase;

                CheckBeforeGeneratePO(dtoHeader, dtoDetail);

                db.KeepConnection = true;
                db.BeginTransaction(IsolationLevel.Serializable);

                PurchaseOrderHDAO daoH = new PurchaseOrderHDAO(db);
                PurchaseOrderDDAO daoD = new PurchaseOrderDDAO(db);

                if (dtoHeader.Count == 0)
                    return;
                foreach (PurchaseOrderHDTO dtoH in dtoHeader) 
                {
                    daoH.AddNew(null, dtoH);
                }

                if (dtoDetail.Count == 0)
                    return;
                foreach (PurchaseOrderDDTO dtoD in dtoDetail) 
                {
                    daoD.AddNew(null,dtoD);
                }

                db.Commit();
            }
            catch (Exception) 
            {
                if (db.DBConnectionState == ConnectionState.Open)
                    db.Rollback();
                throw;
            }
            finally 
            {
                if (db.DBConnectionState == ConnectionState.Open)
                    db.Close();
            }
        }
    }
}
