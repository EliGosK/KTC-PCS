/* Create by: Mr.Teerayut Sinlan
 * Create on: 2009-10-05
 * Company: CSI Groups (Thailand)
 * Group: SI-EVO
 
 *** This generate source code was build for DAO on StarterKit system. ***/
using System;
using System.Collections.Generic;
using System.Text;
using SystemMaintenance.DTO;
using EVOFramework.Database;
using EVOFramework;
using SystemMaintenance.DAO;

namespace SystemMaintenance.Oracle.DAO
{
    internal partial class TransactionLockDAO : ITransactionLockDAO
    {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public TransactionLockDAO() { }

        public TransactionLockDAO(Database db)
        {
            this.m_db = db;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get encapsulated database object.
        /// </summary>
        public Database CurrentDatabase
        {
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
        protected Database UseDatabase(Database specificDB)
        {
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
        public int AddNewOrUpdate(Database database, TransactionLockDTO data)
        {
            Database db = UseDatabase(database);

            if (Exist(database, data.KEY1, data.KEY2))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, TransactionLockDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            sb.AppendLine("  " + TransactionLockDTO.eColumns.KEY1);
            sb.AppendLine("  ," + TransactionLockDTO.eColumns.KEY2);
            sb.AppendLine("  ," + TransactionLockDTO.eColumns.KEY3);
            sb.AppendLine("  ," + TransactionLockDTO.eColumns.KEY4);
            sb.AppendLine("  ," + TransactionLockDTO.eColumns.KEY5);
            sb.AppendLine("  ," + TransactionLockDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + TransactionLockDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + TransactionLockDTO.eColumns.CRT_MACHINE);
            sb.AppendLine(") VALUES(");
            sb.AppendLine("   :KEY1");
            sb.AppendLine("   ,:KEY2");
            sb.AppendLine("   ,:KEY3");
            sb.AppendLine("   ,:KEY4");
            sb.AppendLine("   ,:KEY5");
            sb.AppendLine("   ,:CRT_BY");
            sb.AppendLine("   ,SYSDATE");
            sb.AppendLine("   ,:CRT_MACHINE");
            sb.AppendLine(" )");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("KEY1", DataType.Default, data.KEY1.Value);
            req.Parameters.Add("KEY2", DataType.Default, data.KEY2.Value);
            req.Parameters.Add("KEY3", DataType.Default, data.KEY3.Value);
            req.Parameters.Add("KEY4", DataType.Default, data.KEY4.Value);
            req.Parameters.Add("KEY5", DataType.Default, data.KEY5.Value);
            req.Parameters.Add("CRT_BY", DataType.Default, data.CRT_BY.Value);
            req.Parameters.Add("CRT_MACHINE", DataType.Default, data.CRT_MACHINE.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using primary key value on the given data variable
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data with primary key value.</param>
        /// <returns></returns>
        public int UpdateWithoutPK(Database database, TransactionLockDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + TransactionLockDTO.eColumns.KEY3 + "=:KEY3");
            sb.AppendLine("  ," + TransactionLockDTO.eColumns.KEY4 + "=:KEY4");
            sb.AppendLine("  ," + TransactionLockDTO.eColumns.KEY5 + "=:KEY5");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + TransactionLockDTO.eColumns.KEY1 + "=:KEY1");
            sb.AppendLine("  AND " + TransactionLockDTO.eColumns.KEY2 + "=:KEY2");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("KEY1", DataType.Default, data.KEY1.Value);
            req.Parameters.Add("KEY2", DataType.Default, data.KEY2.Value);
            req.Parameters.Add("KEY3", DataType.Default, data.KEY3.Value);
            req.Parameters.Add("KEY4", DataType.Default, data.KEY4.Value);
            req.Parameters.Add("KEY5", DataType.Default, data.KEY5.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using the table's primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data which to update.</param>
        /// <param name="oldKEY1">Old Key #1</param>
        /// <param name="oldKEY2">Old Key #2</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, TransactionLockDTO data, NZString oldKEY1, NZString oldKEY2)
        {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + TransactionLockDTO.eColumns.KEY1 + "=:KEY1");
            sb.AppendLine("  ," + TransactionLockDTO.eColumns.KEY2 + "=:KEY2");
            sb.AppendLine("  ," + TransactionLockDTO.eColumns.KEY3 + "=:KEY3");
            sb.AppendLine("  ," + TransactionLockDTO.eColumns.KEY4 + "=:KEY4");
            sb.AppendLine("  ," + TransactionLockDTO.eColumns.KEY5 + "=:KEY5");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + TransactionLockDTO.eColumns.KEY1 + "=:oldKEY1");
            sb.AppendLine("  AND " + TransactionLockDTO.eColumns.KEY2 + "=:oldTransactionLock");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("KEY1", DataType.Default, data.KEY1.Value);
            req.Parameters.Add("KEY2", DataType.Default, data.KEY2.Value);
            req.Parameters.Add("KEY3", DataType.Default, data.KEY3.Value);
            req.Parameters.Add("KEY4", DataType.Default, data.KEY4.Value);
            req.Parameters.Add("KEY5", DataType.Default, data.KEY5.Value);
            req.Parameters.Add("oldKEY1", DataType.Default, oldKEY1.Value);
            req.Parameters.Add("oldKEY2", DataType.Default, oldKEY2.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="KEY1">Key #1</param>
        /// <param name="KEY2">Key #2</param>
        /// <returns></returns>
        public int Delete(Database database, NZString KEY1, NZString KEY2)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(TransactionLockDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + TransactionLockDTO.eColumns.KEY1 + "=:KEY1");
            sb.AppendLine("  AND " + TransactionLockDTO.eColumns.KEY2 + "=:KEY2");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("KEY1", DataType.Default, KEY1.Value);
            req.Parameters.Add("KEY2", DataType.Default, KEY2.Value);
            #endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, NZString KEY1, NZString KEY2)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(TransactionLockDTO));

            sb.AppendLine(" SELECT 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ROWNUM=1");
            sb.AppendLine("  AND " + TransactionLockDTO.eColumns.KEY1 + "=:KEY1");
            sb.AppendLine("  AND " + TransactionLockDTO.eColumns.KEY2 + "=:KEY2");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("KEY1", DataType.Default, KEY1.Value);
            req.Parameters.Add("KEY2", DataType.Default, KEY2.Value);
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
        public List<TransactionLockDTO> LoadAll(Database database)
        {
            return LoadAll(database, true,
                TransactionLockDTO.eColumns.KEY1
                , TransactionLockDTO.eColumns.KEY2
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<TransactionLockDTO> LoadAll(Database database, bool ascending)
        {
            return LoadAll(database, ascending,
                TransactionLockDTO.eColumns.KEY1
                , TransactionLockDTO.eColumns.KEY2
            );
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<TransactionLockDTO> LoadAll(Database database, bool ascending, params TransactionLockDTO.eColumns[] orderByColumns)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(TransactionLockDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + TransactionLockDTO.eColumns.KEY1);
            sb.AppendLine("  ," + TransactionLockDTO.eColumns.KEY2);
            sb.AppendLine("  ," + TransactionLockDTO.eColumns.KEY3);
            sb.AppendLine("  ," + TransactionLockDTO.eColumns.KEY4);
            sb.AppendLine("  ," + TransactionLockDTO.eColumns.KEY5);
            sb.AppendLine("  ," + TransactionLockDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + TransactionLockDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + TransactionLockDTO.eColumns.CRT_MACHINE);
            sb.AppendLine(" FROM " + tableName);

            if (orderByColumns != null && orderByColumns.Length > 0)
            {
                sb.AppendLine(" ORDER BY ");
                string sort = ascending ? "asc" : "desc";

                for (int i = 0; i < orderByColumns.Length; i++)
                {
                    if (i == 0)
                        sb.AppendLine(String.Format("   {0} {1}", orderByColumns[i], sort));
                    else
                        sb.AppendLine(String.Format("   ,{0} {1}", orderByColumns[i], sort));
                }
            }
            #endregion

            DataRequest req = new DataRequest(sb.ToString());

            return db.ExecuteForList<TransactionLockDTO>(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="KEY1">Key #1</param>
        /// <param name="KEY2">Key #2</param>
        /// <returns></returns>
        public TransactionLockDTO LoadByPK(Database database, NZString KEY1, NZString KEY2)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(TransactionLockDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + TransactionLockDTO.eColumns.KEY1);
            sb.AppendLine("  ," + TransactionLockDTO.eColumns.KEY2);
            sb.AppendLine("  ," + TransactionLockDTO.eColumns.KEY3);
            sb.AppendLine("  ," + TransactionLockDTO.eColumns.KEY4);
            sb.AppendLine("  ," + TransactionLockDTO.eColumns.KEY5);
            sb.AppendLine("  ," + TransactionLockDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + TransactionLockDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + TransactionLockDTO.eColumns.CRT_MACHINE);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + TransactionLockDTO.eColumns.KEY1 + "=:KEY1");
            sb.AppendLine("  AND " + TransactionLockDTO.eColumns.KEY2 + "=:KEY2");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("KEY1", DataType.Default, KEY1.Value);
            req.Parameters.Add("KEY2", DataType.Default, KEY2.Value);
            #endregion

            List<TransactionLockDTO> list = db.ExecuteForList<TransactionLockDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        #endregion
    }
}

