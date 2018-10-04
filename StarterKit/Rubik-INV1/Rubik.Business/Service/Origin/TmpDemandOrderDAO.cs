/* Create by: Ms. Sansanee K.
 * Create on: 2011-05-31
 * Company: CSI Groups (Thailand)
 * Group: SI-EVO
 
 *** This generate source code was build for DAO on StarterKit system. ***/
using System;
using System.Collections.Generic;
using System.Text;
using EVOFramework.Database;
using EVOFramework;
using Rubik.DTO;


namespace Rubik.DAO {
    internal partial class TmpDemandOrderDAO  {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public TmpDemandOrderDAO() { }

        public TmpDemandOrderDAO(Database db) {
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
        public int AddNewOrUpdate(Database database, TmpDemandOrderDTO data) {
            Database db = UseDatabase(database);

            if (Exist(database, data.CUSTOMER_CD, data.DUE_DATE, data.ITEM_CD))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, TmpDemandOrderDTO data) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            sb.AppendLine("  " + TmpDemandOrderDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + TmpDemandOrderDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + TmpDemandOrderDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + TmpDemandOrderDTO.eColumns.YEAR_MONTH);
            sb.AppendLine("  ," + TmpDemandOrderDTO.eColumns.CUSTOMER_CD);
            sb.AppendLine("  ," + TmpDemandOrderDTO.eColumns.DUE_DATE);
            sb.AppendLine("  ," + TmpDemandOrderDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + TmpDemandOrderDTO.eColumns.ORDER_QTY);
            sb.AppendLine("  ," + TmpDemandOrderDTO.eColumns.ORDER_TYPE);
            sb.AppendLine(") VALUES(");
            sb.AppendLine("   :CRT_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,:CRT_MACHINE");
            sb.AppendLine("   ,:YEAR_MONTH");
            sb.AppendLine("   ,:CUSTOMER_CD");
            sb.AppendLine("   ,:DUE_DATE");
            sb.AppendLine("   ,:ITEM_CD");
            sb.AppendLine("   ,:ORDER_QTY");
            sb.AppendLine("   ,:ORDER_TYPE");
            sb.AppendLine(" )");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("CRT_BY", DataType.NVarChar, data.CRT_BY.Value);
            req.Parameters.Add("CRT_MACHINE", DataType.NVarChar, data.CRT_MACHINE.Value);
            req.Parameters.Add("YEAR_MONTH", DataType.Default, data.YEAR_MONTH.Value);
            req.Parameters.Add("CUSTOMER_CD", DataType.NVarChar, data.CUSTOMER_CD.Value);
            req.Parameters.Add("DUE_DATE", DataType.DateTime, data.DUE_DATE.Value);
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("ORDER_QTY", DataType.Number, data.ORDER_QTY.Value);
            req.Parameters.Add("ORDER_TYPE", DataType.NVarChar, data.ORDER_TYPE.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using primary key value on the given data variable
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data with primary key value.</param>
        /// <returns></returns>
        public int UpdateWithoutPK(Database database, TmpDemandOrderDTO data) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + TmpDemandOrderDTO.eColumns.YEAR_MONTH + "=:YEAR_MONTH");
            sb.AppendLine("  ," + TmpDemandOrderDTO.eColumns.ORDER_QTY + "=:ORDER_QTY");
            sb.AppendLine("  ," + TmpDemandOrderDTO.eColumns.ORDER_TYPE + "=:ORDER_TYPE");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + TmpDemandOrderDTO.eColumns.CUSTOMER_CD + "=:CUSTOMER_CD");
            sb.AppendLine("  AND " + TmpDemandOrderDTO.eColumns.DUE_DATE + "=:DUE_DATE");
            sb.AppendLine("  AND " + TmpDemandOrderDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("YEAR_MONTH", DataType.Default, data.YEAR_MONTH.Value);
            req.Parameters.Add("CUSTOMER_CD", DataType.NVarChar, data.CUSTOMER_CD.Value);
            req.Parameters.Add("DUE_DATE", DataType.DateTime, data.DUE_DATE.Value);
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("ORDER_QTY", DataType.Number, data.ORDER_QTY.Value);
            req.Parameters.Add("ORDER_TYPE", DataType.NVarChar, data.ORDER_TYPE.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using the table's primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data which to update.</param>
        /// <param name="oldCUSTOMER_CD">Old Key #1</param>
        /// <param name="oldDUE_DATE">Old Key #2</param>
        /// <param name="oldITEM_CD">Old Key #3</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, TmpDemandOrderDTO data, NZString oldCUSTOMER_CD, NZDateTime oldDUE_DATE, NZString oldITEM_CD) {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + TmpDemandOrderDTO.eColumns.YEAR_MONTH + "=:YEAR_MONTH");
            sb.AppendLine("  ," + TmpDemandOrderDTO.eColumns.CUSTOMER_CD + "=:CUSTOMER_CD");
            sb.AppendLine("  ," + TmpDemandOrderDTO.eColumns.DUE_DATE + "=:DUE_DATE");
            sb.AppendLine("  ," + TmpDemandOrderDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            sb.AppendLine("  ," + TmpDemandOrderDTO.eColumns.ORDER_QTY + "=:ORDER_QTY");
            sb.AppendLine("  ," + TmpDemandOrderDTO.eColumns.ORDER_TYPE + "=:ORDER_TYPE");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + TmpDemandOrderDTO.eColumns.CUSTOMER_CD + "=:oldCUSTOMER_CD");
            sb.AppendLine("  AND " + TmpDemandOrderDTO.eColumns.DUE_DATE + "=:oldTmpDemandOrder");
            sb.AppendLine("  AND " + TmpDemandOrderDTO.eColumns.ITEM_CD + "=:oldTmpDemandOrder");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("YEAR_MONTH", DataType.Default, data.YEAR_MONTH.Value);
            req.Parameters.Add("CUSTOMER_CD", DataType.NVarChar, data.CUSTOMER_CD.Value);
            req.Parameters.Add("DUE_DATE", DataType.DateTime, data.DUE_DATE.Value);
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("ORDER_QTY", DataType.Number, data.ORDER_QTY.Value);
            req.Parameters.Add("ORDER_TYPE", DataType.NVarChar, data.ORDER_TYPE.Value);
            req.Parameters.Add("oldCUSTOMER_CD", DataType.NVarChar, oldCUSTOMER_CD.Value);
            req.Parameters.Add("oldDUE_DATE", DataType.DateTime, oldDUE_DATE.Value);
            req.Parameters.Add("oldITEM_CD", DataType.NVarChar, oldITEM_CD.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="CUSTOMER_CD">Key #1</param>
        /// <param name="DUE_DATE">Key #2</param>
        /// <param name="ITEM_CD">Key #3</param>
        /// <returns></returns>
        public int Delete(Database database, NZString CUSTOMER_CD, NZDateTime DUE_DATE, NZString ITEM_CD) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(TmpDemandOrderDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + TmpDemandOrderDTO.eColumns.CUSTOMER_CD + "=:CUSTOMER_CD");
            sb.AppendLine("  AND " + TmpDemandOrderDTO.eColumns.DUE_DATE + "=:DUE_DATE");
            sb.AppendLine("  AND " + TmpDemandOrderDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("CUSTOMER_CD", DataType.NVarChar, CUSTOMER_CD.Value);
            req.Parameters.Add("DUE_DATE", DataType.DateTime, DUE_DATE.Value);
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, ITEM_CD.Value);
            #endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, NZString CUSTOMER_CD, NZDateTime DUE_DATE, NZString ITEM_CD) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(TmpDemandOrderDTO));

            sb.AppendLine(" SELECT TOP 1 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + TmpDemandOrderDTO.eColumns.CUSTOMER_CD + "=:CUSTOMER_CD");
            sb.AppendLine("  AND " + TmpDemandOrderDTO.eColumns.DUE_DATE + "=:DUE_DATE");
            sb.AppendLine("  AND " + TmpDemandOrderDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("CUSTOMER_CD", DataType.NVarChar, CUSTOMER_CD.Value);
            req.Parameters.Add("DUE_DATE", DataType.DateTime, DUE_DATE.Value);
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, ITEM_CD.Value);
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
        public List<TmpDemandOrderDTO> LoadAll(Database database) {
            return LoadAll(database, true,
                TmpDemandOrderDTO.eColumns.CUSTOMER_CD
                , TmpDemandOrderDTO.eColumns.DUE_DATE
                , TmpDemandOrderDTO.eColumns.ITEM_CD
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<TmpDemandOrderDTO> LoadAll(Database database, bool ascending) {
            return LoadAll(database, ascending,
                TmpDemandOrderDTO.eColumns.CUSTOMER_CD
                , TmpDemandOrderDTO.eColumns.DUE_DATE
                , TmpDemandOrderDTO.eColumns.ITEM_CD
            );
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<TmpDemandOrderDTO> LoadAll(Database database, bool ascending, params TmpDemandOrderDTO.eColumns[] orderByColumns) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(TmpDemandOrderDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + TmpDemandOrderDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + TmpDemandOrderDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + TmpDemandOrderDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + TmpDemandOrderDTO.eColumns.YEAR_MONTH);
            sb.AppendLine("  ," + TmpDemandOrderDTO.eColumns.CUSTOMER_CD);
            sb.AppendLine("  ," + TmpDemandOrderDTO.eColumns.DUE_DATE);
            sb.AppendLine("  ," + TmpDemandOrderDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + TmpDemandOrderDTO.eColumns.ORDER_QTY);
            sb.AppendLine("  ," + TmpDemandOrderDTO.eColumns.ORDER_TYPE);
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

            return db.ExecuteForList<TmpDemandOrderDTO>(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="CUSTOMER_CD">Key #1</param>
        /// <param name="DUE_DATE">Key #2</param>
        /// <param name="ITEM_CD">Key #3</param>
        /// <returns></returns>
        public TmpDemandOrderDTO LoadByPK(Database database, NZString CUSTOMER_CD, NZDateTime DUE_DATE, NZString ITEM_CD) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(TmpDemandOrderDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + TmpDemandOrderDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + TmpDemandOrderDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + TmpDemandOrderDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + TmpDemandOrderDTO.eColumns.YEAR_MONTH);
            sb.AppendLine("  ," + TmpDemandOrderDTO.eColumns.CUSTOMER_CD);
            sb.AppendLine("  ," + TmpDemandOrderDTO.eColumns.DUE_DATE);
            sb.AppendLine("  ," + TmpDemandOrderDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + TmpDemandOrderDTO.eColumns.ORDER_QTY);
            sb.AppendLine("  ," + TmpDemandOrderDTO.eColumns.ORDER_TYPE);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + TmpDemandOrderDTO.eColumns.CUSTOMER_CD + "=:CUSTOMER_CD");
            sb.AppendLine("  AND " + TmpDemandOrderDTO.eColumns.DUE_DATE + "=:DUE_DATE");
            sb.AppendLine("  AND " + TmpDemandOrderDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("CUSTOMER_CD", DataType.NVarChar, CUSTOMER_CD.Value);
            req.Parameters.Add("DUE_DATE", DataType.DateTime, DUE_DATE.Value);
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, ITEM_CD.Value);
            #endregion

            List<TmpDemandOrderDTO> list = db.ExecuteForList<TmpDemandOrderDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        #endregion
    }
}

