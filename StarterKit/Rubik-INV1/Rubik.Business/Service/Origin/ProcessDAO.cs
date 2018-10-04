/* Create by: Ms. Sansanee K.
 * Create on: 2011-06-09
 * Company: CSI Groups (Thailand)
 * Group: SI-EVO
 
 *** This generate source code was build for DAO on StarterKit system. ***/
using System;
using System.Collections.Generic;
using System.Text;
using EVOFramework.Database;
using EVOFramework;
using Rubik.DTO;
using Rubik.Data;


namespace Rubik.DAO {
    internal partial class ProcessDAO {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public ProcessDAO() { }

        public ProcessDAO(Database db) {
            this.m_db = db;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get encapsulated database object.
        /// </summary>
        public Database CurrentDatabase {
            get { return m_db; }
        }
        #endregion

        #region Protected Method
        /// <summary>
        /// Determine to choose current database connection.
        /// </summary>
        /// <param name="specificDB"></param>
        /// <exception cref="DataAccessException">Cannot determine to use database.</exception>
        /// <returns></returns>
        protected Database UseDatabase(Database specificDB) {
            if (specificDB != null)
                return specificDB;

            if (this.m_db != null)
                return this.m_db;

            throw new DataAccessException(ResourceBundle.ALL.S_CANNOT_USE_DB);
        }
        #endregion

        #region Basic Operation
        /// <summary>
        /// Check exist before manipulate data. If found record will update data. Otherwise insert new data.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNewOrUpdate(Database database, ProcessDTO data) {
            Database db = UseDatabase(database);

            if (Exist(database, data.PROCESS_NO))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, ProcessDTO data) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            sb.AppendLine("  " + ProcessDTO.eColumns.PROCESS_NO);
            sb.AppendLine("  ," + ProcessDTO.eColumns.PROCESS_TYPE);
            sb.AppendLine("  ," + ProcessDTO.eColumns.STATUS);
            sb.AppendLine("  ," + ProcessDTO.eColumns.DESCRIPTION);
            sb.AppendLine("  ," + ProcessDTO.eColumns.START_PRCS_TIME);
            sb.AppendLine("  ," + ProcessDTO.eColumns.END_PRCS_TIME);
            //sb.AppendLine("  ," + ProcessDTO.eColumns.FILTER_TIMESTAMP);
            sb.AppendLine("  ," + ProcessDTO.eColumns.FILE_NAME);
            sb.AppendLine("  ," + ProcessDTO.eColumns.MD5SUM);
            sb.AppendLine("  ," + ProcessDTO.eColumns.IS_CANCEL);
            sb.AppendLine("  ," + ProcessDTO.eColumns.CANCEL_DATE);
            sb.AppendLine("  ," + ProcessDTO.eColumns.CANCEL_BY);
            sb.AppendLine("  ," + ProcessDTO.eColumns.CANCEL_MACHINE);
            sb.AppendLine("  ," + ProcessDTO.eColumns.PROCESS_DATE);
            sb.AppendLine("  ," + ProcessDTO.eColumns.PROCESS_BY);
            sb.AppendLine("  ," + ProcessDTO.eColumns.PROCESS_MACHINE);
            sb.AppendLine("  ," + ProcessDTO.eColumns.RESERVE1);
            sb.AppendLine("  ," + ProcessDTO.eColumns.RESERVE2);
            sb.AppendLine(") VALUES(");
            sb.AppendLine("   :PROCESS_NO");
            sb.AppendLine("   ,:PROCESS_TYPE");
            sb.AppendLine("   ,:STATUS");
            sb.AppendLine("   ,:DESCRIPTION");
            sb.AppendLine("   ,:START_PRCS_TIME");
            sb.AppendLine("   ,:END_PRCS_TIME");
            //sb.AppendLine("   ,:FILTER_TIMESTAMP");
            sb.AppendLine("   ,:FILE_NAME");
            sb.AppendLine("   ,:MD5SUM");
            sb.AppendLine("   ,:IS_CANCEL");
            sb.AppendLine("   ,:CANCEL_DATE");
            sb.AppendLine("   ,:CANCEL_BY");
            sb.AppendLine("   ,:CANCEL_MACHINE");
            sb.AppendLine("   ,:PROCESS_DATE");
            sb.AppendLine("   ,:PROCESS_BY");
            sb.AppendLine("   ,:PROCESS_MACHINE");
            sb.AppendLine("   ,:RESERVE1");
            sb.AppendLine("   ,:RESERVE2");
            sb.AppendLine(" )");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("PROCESS_NO", DataType.NVarChar, data.PROCESS_NO.Value);
            req.Parameters.Add("PROCESS_TYPE", DataType.NVarChar, data.PROCESS_TYPE.Value);
            req.Parameters.Add("STATUS", DataType.NVarChar, data.STATUS.Value);
            req.Parameters.Add("DESCRIPTION", DataType.NVarChar, data.DESCRIPTION.Value);
            req.Parameters.Add("START_PRCS_TIME", DataType.DateTime, data.START_PRCS_TIME.Value);
            req.Parameters.Add("END_PRCS_TIME", DataType.DateTime, data.END_PRCS_TIME.Value);
            req.Parameters.Add("FILTER_TIMESTAMP", DataType.DateTime, data.FILTER_TIMESTAMP.Value);
            req.Parameters.Add("FILE_NAME", DataType.NVarChar, data.FILE_NAME.Value);
            req.Parameters.Add("MD5SUM", DataType.NVarChar, data.MD5SUM.Value);
            req.Parameters.Add("IS_CANCEL", DataType.Number, data.IS_CANCEL.Value);
            req.Parameters.Add("CANCEL_DATE", DataType.DateTime, data.CANCEL_DATE.Value);
            req.Parameters.Add("CANCEL_BY", DataType.NVarChar, data.CANCEL_BY.Value);
            req.Parameters.Add("CANCEL_MACHINE", DataType.NVarChar, data.CANCEL_MACHINE.Value);
            req.Parameters.Add("PROCESS_DATE", DataType.DateTime, data.PROCESS_DATE.Value);
            req.Parameters.Add("PROCESS_BY", DataType.NVarChar, data.PROCESS_BY.Value);
            req.Parameters.Add("PROCESS_MACHINE", DataType.NVarChar, data.PROCESS_MACHINE.Value);
            req.Parameters.Add("RESERVE1", DataType.NVarChar, data.RESERVE1.Value);
            req.Parameters.Add("RESERVE2", DataType.NVarChar, data.RESERVE2.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using primary key value on the given data variable
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data with primary key value.</param>
        /// <returns></returns>
        public int UpdateWithoutPK(Database database, ProcessDTO data) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + ProcessDTO.eColumns.PROCESS_TYPE + "=:PROCESS_TYPE");
            sb.AppendLine("  ," + ProcessDTO.eColumns.STATUS + "=:STATUS");
            sb.AppendLine("  ," + ProcessDTO.eColumns.DESCRIPTION + "=:DESCRIPTION");
            sb.AppendLine("  ," + ProcessDTO.eColumns.START_PRCS_TIME + "=:START_PRCS_TIME");
            sb.AppendLine("  ," + ProcessDTO.eColumns.END_PRCS_TIME + "=:END_PRCS_TIME");
            sb.AppendLine("  ," + ProcessDTO.eColumns.FILTER_TIMESTAMP + "=:FILTER_TIMESTAMP");
            sb.AppendLine("  ," + ProcessDTO.eColumns.FILE_NAME + "=:FILE_NAME");
            sb.AppendLine("  ," + ProcessDTO.eColumns.MD5SUM + "=:MD5SUM");
            sb.AppendLine("  ," + ProcessDTO.eColumns.IS_CANCEL + "=:IS_CANCEL");
            sb.AppendLine("  ," + ProcessDTO.eColumns.CANCEL_DATE + "=:CANCEL_DATE");
            sb.AppendLine("  ," + ProcessDTO.eColumns.CANCEL_BY + "=:CANCEL_BY");
            sb.AppendLine("  ," + ProcessDTO.eColumns.CANCEL_MACHINE + "=:CANCEL_MACHINE");
            sb.AppendLine("  ," + ProcessDTO.eColumns.PROCESS_DATE + "=:PROCESS_DATE");
            sb.AppendLine("  ," + ProcessDTO.eColumns.PROCESS_BY + "=:PROCESS_BY");
            sb.AppendLine("  ," + ProcessDTO.eColumns.PROCESS_MACHINE + "=:PROCESS_MACHINE");
            sb.AppendLine("  ," + ProcessDTO.eColumns.RESERVE1 + "=:RESERVE1");
            sb.AppendLine("  ," + ProcessDTO.eColumns.RESERVE2 + "=:RESERVE2");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ProcessDTO.eColumns.PROCESS_NO + "=:PROCESS_NO");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("PROCESS_NO", DataType.NVarChar, data.PROCESS_NO.Value);
            req.Parameters.Add("PROCESS_TYPE", DataType.NVarChar, data.PROCESS_TYPE.Value);
            req.Parameters.Add("STATUS", DataType.NVarChar, data.STATUS.Value);
            req.Parameters.Add("DESCRIPTION", DataType.NVarChar, data.DESCRIPTION.Value);
            req.Parameters.Add("START_PRCS_TIME", DataType.DateTime, data.START_PRCS_TIME.Value);
            req.Parameters.Add("END_PRCS_TIME", DataType.DateTime, data.END_PRCS_TIME.Value);
            req.Parameters.Add("FILTER_TIMESTAMP", DataType.DateTime, data.FILTER_TIMESTAMP.Value);
            req.Parameters.Add("FILE_NAME", DataType.NVarChar, data.FILE_NAME.Value);
            req.Parameters.Add("MD5SUM", DataType.NVarChar, data.MD5SUM.Value);
            req.Parameters.Add("IS_CANCEL", DataType.Number, data.IS_CANCEL.Value);
            req.Parameters.Add("CANCEL_DATE", DataType.DateTime, data.CANCEL_DATE.Value);
            req.Parameters.Add("CANCEL_BY", DataType.NVarChar, data.CANCEL_BY.Value);
            req.Parameters.Add("CANCEL_MACHINE", DataType.NVarChar, data.CANCEL_MACHINE.Value);
            req.Parameters.Add("PROCESS_DATE", DataType.DateTime, data.PROCESS_DATE.Value);
            req.Parameters.Add("PROCESS_BY", DataType.NVarChar, data.PROCESS_BY.Value);
            req.Parameters.Add("PROCESS_MACHINE", DataType.NVarChar, data.PROCESS_MACHINE.Value);
            req.Parameters.Add("RESERVE1", DataType.NVarChar, data.RESERVE1.Value);
            req.Parameters.Add("RESERVE2", DataType.NVarChar, data.RESERVE2.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using the table's primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data which to update.</param>
        /// <param name="oldPROCESS_NO">Old Key #1</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, ProcessDTO data, NZString oldPROCESS_NO) {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + ProcessDTO.eColumns.PROCESS_NO + "=:PROCESS_NO");
            sb.AppendLine("  ," + ProcessDTO.eColumns.PROCESS_TYPE + "=:PROCESS_TYPE");
            sb.AppendLine("  ," + ProcessDTO.eColumns.STATUS + "=:STATUS");
            sb.AppendLine("  ," + ProcessDTO.eColumns.DESCRIPTION + "=:DESCRIPTION");
            sb.AppendLine("  ," + ProcessDTO.eColumns.START_PRCS_TIME + "=:START_PRCS_TIME");
            sb.AppendLine("  ," + ProcessDTO.eColumns.END_PRCS_TIME + "=:END_PRCS_TIME");
            sb.AppendLine("  ," + ProcessDTO.eColumns.FILTER_TIMESTAMP + "=:FILTER_TIMESTAMP");
            sb.AppendLine("  ," + ProcessDTO.eColumns.FILE_NAME + "=:FILE_NAME");
            sb.AppendLine("  ," + ProcessDTO.eColumns.MD5SUM + "=:MD5SUM");
            sb.AppendLine("  ," + ProcessDTO.eColumns.IS_CANCEL + "=:IS_CANCEL");
            sb.AppendLine("  ," + ProcessDTO.eColumns.CANCEL_DATE + "=:CANCEL_DATE");
            sb.AppendLine("  ," + ProcessDTO.eColumns.CANCEL_BY + "=:CANCEL_BY");
            sb.AppendLine("  ," + ProcessDTO.eColumns.CANCEL_MACHINE + "=:CANCEL_MACHINE");
            sb.AppendLine("  ," + ProcessDTO.eColumns.PROCESS_DATE + "=:PROCESS_DATE");
            sb.AppendLine("  ," + ProcessDTO.eColumns.PROCESS_BY + "=:PROCESS_BY");
            sb.AppendLine("  ," + ProcessDTO.eColumns.PROCESS_MACHINE + "=:PROCESS_MACHINE");
            sb.AppendLine("  ," + ProcessDTO.eColumns.RESERVE1 + "=:RESERVE1");
            sb.AppendLine("  ," + ProcessDTO.eColumns.RESERVE2 + "=:RESERVE2");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ProcessDTO.eColumns.PROCESS_NO + "=:oldPROCESS_NO");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("PROCESS_NO", DataType.NVarChar, data.PROCESS_NO.Value);
            req.Parameters.Add("PROCESS_TYPE", DataType.NVarChar, data.PROCESS_TYPE.Value);
            req.Parameters.Add("STATUS", DataType.NVarChar, data.STATUS.Value);
            req.Parameters.Add("DESCRIPTION", DataType.NVarChar, data.DESCRIPTION.Value);
            req.Parameters.Add("START_PRCS_TIME", DataType.DateTime, data.START_PRCS_TIME.Value);
            req.Parameters.Add("END_PRCS_TIME", DataType.DateTime, data.END_PRCS_TIME.Value);
            req.Parameters.Add("FILTER_TIMESTAMP", DataType.DateTime, data.FILTER_TIMESTAMP.Value);
            req.Parameters.Add("FILE_NAME", DataType.NVarChar, data.FILE_NAME.Value);
            req.Parameters.Add("MD5SUM", DataType.NVarChar, data.MD5SUM.Value);
            req.Parameters.Add("IS_CANCEL", DataType.Number, data.IS_CANCEL.Value);
            req.Parameters.Add("CANCEL_DATE", DataType.DateTime, data.CANCEL_DATE.Value);
            req.Parameters.Add("CANCEL_BY", DataType.NVarChar, data.CANCEL_BY.Value);
            req.Parameters.Add("CANCEL_MACHINE", DataType.NVarChar, data.CANCEL_MACHINE.Value);
            req.Parameters.Add("PROCESS_DATE", DataType.DateTime, data.PROCESS_DATE.Value);
            req.Parameters.Add("PROCESS_BY", DataType.NVarChar, data.PROCESS_BY.Value);
            req.Parameters.Add("PROCESS_MACHINE", DataType.NVarChar, data.PROCESS_MACHINE.Value);
            req.Parameters.Add("RESERVE1", DataType.NVarChar, data.RESERVE1.Value);
            req.Parameters.Add("RESERVE2", DataType.NVarChar, data.RESERVE2.Value);
            req.Parameters.Add("oldPROCESS_NO", DataType.NVarChar, oldPROCESS_NO.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="PROCESS_NO">Key #1</param>
        /// <returns></returns>
        public int Delete(Database database, NZString PROCESS_NO) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ProcessDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ProcessDTO.eColumns.PROCESS_NO + "=:PROCESS_NO");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("PROCESS_NO", DataType.NVarChar, PROCESS_NO.Value);
            #endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, NZString PROCESS_NO) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ProcessDTO));

            sb.AppendLine(" SELECT TOP 1 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ProcessDTO.eColumns.PROCESS_NO + "=:PROCESS_NO");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("PROCESS_NO", DataType.NVarChar, PROCESS_NO.Value);
            #endregion

            return (db.ExecuteQuery(req).Rows.Count > 0);
        }
        #endregion

        #region Load Operation
        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <returns>List of DTO.</returns>
        public List<ProcessDTO> LoadAll(Database database) {
            return LoadAll(database, true,
                ProcessDTO.eColumns.PROCESS_NO
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<ProcessDTO> LoadAll(Database database, bool ascending) {
            return LoadAll(database, ascending,
                ProcessDTO.eColumns.PROCESS_NO
            );
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<ProcessDTO> LoadAll(Database database, bool ascending, params ProcessDTO.eColumns[] orderByColumns) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ProcessDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + ProcessDTO.eColumns.PROCESS_NO);
            sb.AppendLine("  ," + ProcessDTO.eColumns.PROCESS_TYPE);
            sb.AppendLine("  ," + ProcessDTO.eColumns.STATUS);
            sb.AppendLine("  ," + ProcessDTO.eColumns.DESCRIPTION);
            sb.AppendLine("  ," + ProcessDTO.eColumns.START_PRCS_TIME);
            sb.AppendLine("  ," + ProcessDTO.eColumns.END_PRCS_TIME);
            sb.AppendLine("  ," + ProcessDTO.eColumns.FILTER_TIMESTAMP);
            sb.AppendLine("  ," + ProcessDTO.eColumns.FILE_NAME);
            sb.AppendLine("  ," + ProcessDTO.eColumns.MD5SUM);
            sb.AppendLine("  ," + ProcessDTO.eColumns.IS_CANCEL);
            sb.AppendLine("  ," + ProcessDTO.eColumns.CANCEL_DATE);
            sb.AppendLine("  ," + ProcessDTO.eColumns.CANCEL_BY);
            sb.AppendLine("  ," + ProcessDTO.eColumns.CANCEL_MACHINE);
            sb.AppendLine("  ," + ProcessDTO.eColumns.PROCESS_DATE);
            sb.AppendLine("  ," + ProcessDTO.eColumns.PROCESS_BY);
            sb.AppendLine("  ," + ProcessDTO.eColumns.PROCESS_MACHINE);
            sb.AppendLine("  ," + ProcessDTO.eColumns.RESERVE1);
            sb.AppendLine("  ," + ProcessDTO.eColumns.RESERVE2);
            sb.AppendLine(" FROM " + tableName);

            if (orderByColumns != null && orderByColumns.Length > 0) {
                sb.AppendLine(" ORDER BY ");
                string sort = ascending ? "asc" : "desc";

                for (int i = 0; i < orderByColumns.Length; i++) {
                    if (i == 0)
                        sb.AppendLine(String.Format("   {0} {1}", orderByColumns[i], sort));
                    else
                        sb.AppendLine(String.Format("   ,{0} {1}", orderByColumns[i], sort));
                }
            }
            #endregion

            DataRequest req = new DataRequest(sb.ToString());

            return db.ExecuteForList<ProcessDTO>(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="PROCESS_NO">Key #1</param>
        /// <returns></returns>
        public ProcessDTO LoadByPK(Database database, NZString PROCESS_NO) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ProcessDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + ProcessDTO.eColumns.PROCESS_NO);
            sb.AppendLine("  ," + ProcessDTO.eColumns.PROCESS_TYPE);
            sb.AppendLine("  ," + ProcessDTO.eColumns.STATUS);
            sb.AppendLine("  ," + ProcessDTO.eColumns.DESCRIPTION);
            sb.AppendLine("  ," + ProcessDTO.eColumns.START_PRCS_TIME);
            sb.AppendLine("  ," + ProcessDTO.eColumns.END_PRCS_TIME);
            sb.AppendLine("  ," + ProcessDTO.eColumns.FILTER_TIMESTAMP);
            sb.AppendLine("  ," + ProcessDTO.eColumns.FILE_NAME);
            sb.AppendLine("  ," + ProcessDTO.eColumns.MD5SUM);
            sb.AppendLine("  ," + ProcessDTO.eColumns.IS_CANCEL);
            sb.AppendLine("  ," + ProcessDTO.eColumns.CANCEL_DATE);
            sb.AppendLine("  ," + ProcessDTO.eColumns.CANCEL_BY);
            sb.AppendLine("  ," + ProcessDTO.eColumns.CANCEL_MACHINE);
            sb.AppendLine("  ," + ProcessDTO.eColumns.PROCESS_DATE);
            sb.AppendLine("  ," + ProcessDTO.eColumns.PROCESS_BY);
            sb.AppendLine("  ," + ProcessDTO.eColumns.PROCESS_MACHINE);
            sb.AppendLine("  ," + ProcessDTO.eColumns.RESERVE1);
            sb.AppendLine("  ," + ProcessDTO.eColumns.RESERVE2);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ProcessDTO.eColumns.PROCESS_NO + "=:PROCESS_NO");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("PROCESS_NO", DataType.NVarChar, PROCESS_NO.Value);
            #endregion

            List<ProcessDTO> list = db.ExecuteForList<ProcessDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        #endregion
    }
}

