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

    public class ProcessBIZ {

        #region Load Data

        public ProcessDTO LoadLastProcess(string strPROCESS_TYPE) 
        {
            ProcessDAO dao = new ProcessDAO(Common.CurrentDatabase);
            return dao.LoadLastProcess(null, strPROCESS_TYPE);
        }

        public ItemProcessDTO LoadDefaultProcess(NZString ItemCD, NZString ProcessCD) 
        {
            ItemProcessDAO dao = new ItemProcessDAO(Common.CurrentDatabase);
            return dao.LoadDefaultProcessOfItem(null, ItemCD, ProcessCD);
        }

        #endregion

        #region Operation
        
        public void InsertTransaction(ProcessDTO dto) 
        {
            Database db = null;

            try {

                CheckBeforeSave();

                db = Common.CurrentDatabase;
                db.KeepConnection = true;
                db.BeginTransaction(IsolationLevel.Serializable);

                ProcessDAO dao = new ProcessDAO(db);
                dao.AddNew(null, dto);

                db.Commit();
            }
            catch (Exception ex)
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

        public void UpdateFinishTime(ProcessDTO dto) {
            Database db = null;

            try {

                CheckBeforeSave();

                db = Common.CurrentDatabase;
                db.KeepConnection = true;
                db.BeginTransaction(IsolationLevel.Serializable);

                ProcessDAO dao = new ProcessDAO(db);
                dao.UpdateFinishProcess(null, dto);

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

        public void SimulateMRP(ProcessDTO dtoProcess , GenerateMRPDTO dtoGen) {
            Database db = null;

            try {
                
                db = Common.CurrentDatabase;
                db.KeepConnection = true;
                db.BeginTransaction(IsolationLevel.Serializable);

                ProcessDAO dao = new ProcessDAO(db);
                dao.SimulateMRP(null, dtoProcess.PROCESS_NO, dtoGen);

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
        
        #endregion

        #region Validate
        
        public bool CheckBeforeSave() {
            return true;
        }
        #endregion

    }
}
