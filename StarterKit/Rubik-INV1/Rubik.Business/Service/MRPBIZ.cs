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

    public class MRPBIZ {

        #region Load Data

        public MRPHDTO LoadMRPHByPK(string strMRP_NO, string strITEM_CD, string strLOC_CD) 
        {
            MRPHDAO dao = new MRPHDAO(Common.CurrentDatabase);
            return dao.LoadByPK(null, strMRP_NO.ToNZString(), strITEM_CD.ToNZString(), strLOC_CD.ToNZString());
        }

        public List<MRPHDTO> LoadMRPH(string strMRP_NO) 
        {
            MRPHDAO dao = new MRPHDAO(Common.CurrentDatabase);
            return dao.LoadMRPHeader(null, strMRP_NO);
        }

        public List<MRPDDTO> LoadMRPD(string strMRP_NO) {
            MRPDDAO dao = new MRPDDAO(Common.CurrentDatabase);
            return dao.LoadMRPDetail(null, strMRP_NO);                        
        }

        public DataTable LoadMRPDByItem(NZString strMRP_NO, NZString strITEM_CD, NZString strLOC_CD, NZDateTime dtmPERIOD_BEGIN, NZDateTime dtmPERIOD_END) {
            MRPDDAO dao = new MRPDDAO(Common.CurrentDatabase);
            return dao.LoadMRPDetailByItem(null, strMRP_NO, strITEM_CD, strLOC_CD, dtmPERIOD_BEGIN, dtmPERIOD_END);
        }

        public DataTable LoadSimalateMRPHeader(string strMRP_NO) {
            MRPHDAO dao = new MRPHDAO(Common.CurrentDatabase);
            return dao.LoadSimalateMRPHeader(null, strMRP_NO);
        }

        public DataTable LoadMRPDetailSummaryByMonth(string strMRP_NO, string strITEM_CD, string strLOC_CD) {
            MRPDDAO dao = new MRPDDAO(Common.CurrentDatabase);
            return dao.LoadMRPDetailSummaryByMonth(null, strMRP_NO, strITEM_CD, strLOC_CD, Common.CurrentUserInfomation.DateFormat.ToString());
        }


        #endregion

        #region Other Method

        public DateTime GetDefaultStartDate() 
        {
            return DateTime.Now.Date.AddDays(1);
        }

        public int GetDefaultRecoverDuration() {
            int value = 0;

            SysConfigBIZ biz = new SysConfigBIZ();
            SysConfigDTO dto = biz.LoadByPK((NZString)"RECOVER_DURATION", (NZString)"MRP010");
            if (dto != null)
                value = Convert.ToInt32(dto.CHAR_DATA);

            return value;
        }

        public NZDateTime GetMaxMRPDate() 
        {
            MRPDDAO dao = new MRPDDAO(Common.CurrentDatabase);
            NZDateTime dtm = dao.LoadMaxMRPDate(null);
            if (!dtm.IsNull) 
            {              
                DateTime d = new DateTime(dtm.StrongValue.Year, dtm.StrongValue.Month, 1);
                return new NZDateTime(null, d.AddMonths(1).AddDays(-1));
            }

            return new NZDateTime(null,new DateTime(2999, 12, 31));
        }

        #endregion

        #region Operation

        public void SimulateMRP(ProcessDTO dtoProcess , GenerateMRPDTO dtoGen) 
        {
            //Database db = null;
            ProcessBIZ bizProcess = null;

            try {

                CheckBeforeSimulate();

                bizProcess = new ProcessBIZ();

                //Insert Process Transaction
                bizProcess.InsertTransaction(dtoProcess);
                
                //MRP Simulate Process
                bizProcess.SimulateMRP(dtoProcess, dtoGen);

                //Update Process Transaction
                dtoProcess.END_PRCS_TIME = DateTime.Now.ToNZDateTime();
                dtoProcess.STATUS = (NZString)"F"; //Finish Normal
                bizProcess.UpdateFinishTime(dtoProcess);
                
            }
            catch (Exception)
            {
                //db.Rollback();

                //Update Process Transaction
                //dtoProcess.END_PRCS_TIME = DateTime.Now.ToNZDateTime();
                dtoProcess.STATUS = (NZString)"E";  //Terminate
                bizProcess.UpdateFinishTime(dtoProcess);

                throw;
            }
            //finally
            //{
            //    if (db.DBConnectionState == ConnectionState.Open)
            //        db.Close();
            //}
        }

        public void Add(List<MRPDDTO> dtos) 
        {
            Database db = null;

            try {
                db = Common.CurrentDatabase;
                db.KeepConnection = true;
                db.BeginTransaction(IsolationLevel.Serializable);

                MRPDDAO dao = new MRPDDAO(db);

                foreach (MRPDDTO dto in dtos) 
                {
                    dao.AddNew(null, dto);
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

        public void SaveData(MRPHDTO dtoHeader, List<MRPDDTO> dtoInsert, List<MRPDDTO> dtoUpdate, List<MRPDDTO> dtoDelete) 
        {
            try {

                CheckBeforeSave();

                Common.CurrentDatabase.KeepConnection = true;
                Common.CurrentDatabase.BeginTransaction(IsolationLevel.Serializable);

                //Update Header
                MRPHDAO daoMRPH = new MRPHDAO(Common.CurrentDatabase);
                daoMRPH.UpdateMRPRevision(null, dtoHeader);

                MRPDDAO daoMRPD = new MRPDDAO(Common.CurrentDatabase);

                if (dtoDelete != null && dtoDelete.Count > 0) 
                {
                    foreach (MRPDDTO dto in dtoDelete) {
                        dto.CRT_BY = Common.CurrentUserInfomation.UserCD;
                        dto.CRT_DATE = DateTime.Now.ToNZDateTime();
                        dto.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                        dto.UPD_BY = Common.CurrentUserInfomation.UserCD;
                        dto.UPD_DATE = DateTime.Now.ToNZDateTime();
                        dto.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
                        daoMRPD.Delete(null, dto.MRP_NO, dto.ITEM_CD, dto.ORDER_LOC_CD, dto.AT_DATE);
                    }
                }

                if (dtoInsert != null && dtoInsert.Count > 0) 
                {
                    foreach (MRPDDTO dto in dtoInsert) {
                        dto.CRT_BY = Common.CurrentUserInfomation.UserCD;
                        dto.CRT_DATE = DateTime.Now.ToNZDateTime();
                        dto.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                        dto.UPD_BY = Common.CurrentUserInfomation.UserCD;
                        dto.UPD_DATE = DateTime.Now.ToNZDateTime();
                        dto.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
                        daoMRPD.AddNewOrUpdate(null, dto);
                    }
                }

                if (dtoUpdate != null && dtoUpdate.Count > 0) 
                {
                    foreach (MRPDDTO dto in dtoUpdate) {
                        dto.CRT_BY = Common.CurrentUserInfomation.UserCD;
                        dto.CRT_DATE = DateTime.Now.ToNZDateTime();
                        dto.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                        dto.UPD_BY = Common.CurrentUserInfomation.UserCD;
                        dto.UPD_DATE = DateTime.Now.ToNZDateTime();
                        dto.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
                        daoMRPD.AddNewOrUpdate(null, dto);
                    }
                }

                //Call Update Balance Stock
                daoMRPD.UpdateBalanceStock(null, dtoHeader);

                Common.CurrentDatabase.Commit();
            }
            catch (Exception) {
                Common.CurrentDatabase.Rollback();
                throw;
            }
        }

        #endregion

        #region Validate
        
        public bool CheckBeforeSimulate() {                

            return true;
        }

        public bool CheckBeforeSave() 
        {
            return true;
        }


        public bool CheckCanDelete(MRPDDTO dto) 
        {
            //ถ้ามีเฉพาะ order qty สามารถลบได้
            //if (!dto.AT_DATE.IsNull)
            //    return false;
            if (!dto.INCOMING_QTY.IsNull)
                return false;
            if (!dto.OUTGOING_QTY.IsNull)
                return false;
            if (!dto.REQ_QTY.IsNull)
                return false;
            if (!dto.ON_HAND_QTY.IsNull)
                return false;
            if (!dto.ACT_REQ_QTY.IsNull)
                return false;
            if (!dto.ACT_REQ_LOT_QTY.IsNull)
                return false;
            return true;
        }

        public bool CheckCanModifyDate(MRPDDTO dto) 
        {
            //แก้ไขได้เฉพาะ order qty
            if (!dto.INCOMING_QTY.IsNull)
                return false;
            if (!dto.OUTGOING_QTY.IsNull)
                return false;
            if (!dto.REQ_QTY.IsNull)
                return false;
            if (!dto.ON_HAND_QTY.IsNull)
                return false;
            if (!dto.ACT_REQ_QTY.IsNull)
                return false;
            if (!dto.ACT_REQ_LOT_QTY.IsNull)
                return false;
            return true;
        }

        #endregion


        public DataTable LoadMRPList(NZDateTime dtmDate, NZDateTime dtmDateTo)
        {
            MRPHDAO dao = new MRPHDAO(Common.CurrentDatabase);
            return dao.LoadMRPList(null, dtmDate, dtmDateTo);
        }
    }
}
