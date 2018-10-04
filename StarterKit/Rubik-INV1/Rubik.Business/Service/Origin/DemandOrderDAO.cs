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
using Rubik.Data;
using Rubik.DTO;


namespace Rubik.DAO {

    internal partial class DemandOrderDAO {

        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public DemandOrderDAO() { }

        public DemandOrderDAO(Database db) {
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
        public int AddNewOrUpdate(Database database, DemandOrderDTO data) {
            Database db = UseDatabase(database);

            if (Exist(database, data.ORDER_ID))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, DemandOrderDTO data) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            sb.AppendLine("  " + DemandOrderDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.IS_ACTIVE);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.REVISION);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.YEAR_MONTH);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.CUSTOMER_CD);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.ORDER_ID);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.DUE_DATE);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.ORDER_QTY);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.ORDER_TYPE);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.PRIORITY);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.Reserve);
            sb.AppendLine(") VALUES(");
            sb.AppendLine("   :CRT_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,:CRT_MACHINE");
            sb.AppendLine("   ,:UPD_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,:UPD_MACHINE");
            sb.AppendLine("   ,:IS_ACTIVE");
            sb.AppendLine("   ,:REVISION");
            sb.AppendLine("   ,:YEAR_MONTH");
            sb.AppendLine("   ,:CUSTOMER_CD");
            sb.AppendLine("   ,:ORDER_ID");
            sb.AppendLine("   ,:DUE_DATE");
            sb.AppendLine("   ,:ITEM_CD");
            sb.AppendLine("   ,:ORDER_QTY");
            sb.AppendLine("   ,:ORDER_TYPE");
            sb.AppendLine("   ,:PRIORITY");
            sb.AppendLine("   ,:Reserve");
            sb.AppendLine(" )");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("CRT_BY", DataType.NVarChar, data.CRT_BY.Value);
            req.Parameters.Add("CRT_MACHINE", DataType.NVarChar, data.CRT_MACHINE.Value);
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("IS_ACTIVE", DataType.Default, data.IS_ACTIVE.Value);
            req.Parameters.Add("REVISION", DataType.Number, data.REVISION.Value);
            req.Parameters.Add("YEAR_MONTH", DataType.Default, data.YEAR_MONTH.Value);
            req.Parameters.Add("CUSTOMER_CD", DataType.NVarChar, data.CUSTOMER_CD.Value);
            req.Parameters.Add("ORDER_ID", DataType.Default, data.ORDER_ID.Value);
            req.Parameters.Add("DUE_DATE", DataType.DateTime, data.DUE_DATE.Value);
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("ORDER_QTY", DataType.Number, data.ORDER_QTY.Value);
            req.Parameters.Add("ORDER_TYPE", DataType.NVarChar, data.ORDER_TYPE.Value);
            req.Parameters.Add("PRIORITY", DataType.NVarChar, data.PRIORITY.Value);
            req.Parameters.Add("Reserve", DataType.NVarChar, data.Reserve.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using primary key value on the given data variable
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data with primary key value.</param>
        /// <returns></returns>
        public int UpdateWithoutPK(Database database, DemandOrderDTO data) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + DemandOrderDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.IS_ACTIVE + "=:IS_ACTIVE");
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.REVISION + "=:REVISION");
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.YEAR_MONTH + "=:YEAR_MONTH");
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.CUSTOMER_CD + "=:CUSTOMER_CD");
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.DUE_DATE + "=:DUE_DATE");
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.ORDER_QTY + "=:ORDER_QTY");
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.ORDER_TYPE + "=:ORDER_TYPE");
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.PRIORITY + "=:PRIORITY");
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.Reserve + "=:Reserve");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + DemandOrderDTO.eColumns.ORDER_ID + "=:ORDER_ID");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("IS_ACTIVE", DataType.Default, data.IS_ACTIVE.Value);
            req.Parameters.Add("REVISION", DataType.Number, data.REVISION.Value);
            req.Parameters.Add("YEAR_MONTH", DataType.Default, data.YEAR_MONTH.Value);
            req.Parameters.Add("CUSTOMER_CD", DataType.NVarChar, data.CUSTOMER_CD.Value);
            req.Parameters.Add("ORDER_ID", DataType.Default, data.ORDER_ID.Value);
            req.Parameters.Add("DUE_DATE", DataType.DateTime, data.DUE_DATE.Value);
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("ORDER_QTY", DataType.Number, data.ORDER_QTY.Value);
            req.Parameters.Add("ORDER_TYPE", DataType.NVarChar, data.ORDER_TYPE.Value);
            req.Parameters.Add("PRIORITY", DataType.NVarChar, data.PRIORITY.Value);
            req.Parameters.Add("Reserve", DataType.NVarChar, data.Reserve.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using the table's primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data which to update.</param>
        /// <param name="oldORDER_ID">Old Key #1</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, DemandOrderDTO data, NZInt oldORDER_ID) {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + DemandOrderDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.IS_ACTIVE + "=:IS_ACTIVE");
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.REVISION + "=:REVISION");
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.YEAR_MONTH + "=:YEAR_MONTH");
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.CUSTOMER_CD + "=:CUSTOMER_CD");
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.ORDER_ID + "=:ORDER_ID");
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.DUE_DATE + "=:DUE_DATE");
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.ORDER_QTY + "=:ORDER_QTY");
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.ORDER_TYPE + "=:ORDER_TYPE");
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.PRIORITY + "=:PRIORITY");
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.Reserve + "=:Reserve");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + DemandOrderDTO.eColumns.ORDER_ID + "=:oldORDER_ID");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("IS_ACTIVE", DataType.Default, data.IS_ACTIVE.Value);
            req.Parameters.Add("REVISION", DataType.Number, data.REVISION.Value);
            req.Parameters.Add("YEAR_MONTH", DataType.Default, data.YEAR_MONTH.Value);
            req.Parameters.Add("CUSTOMER_CD", DataType.NVarChar, data.CUSTOMER_CD.Value);
            req.Parameters.Add("ORDER_ID", DataType.Default, data.ORDER_ID.Value);
            req.Parameters.Add("DUE_DATE", DataType.DateTime, data.DUE_DATE.Value);
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("ORDER_QTY", DataType.Number, data.ORDER_QTY.Value);
            req.Parameters.Add("ORDER_TYPE", DataType.NVarChar, data.ORDER_TYPE.Value);
            req.Parameters.Add("PRIORITY", DataType.NVarChar, data.PRIORITY.Value);
            req.Parameters.Add("Reserve", DataType.NVarChar, data.Reserve.Value);
            req.Parameters.Add("oldORDER_ID", DataType.Default, oldORDER_ID.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ORDER_ID">Key #1</param>
        /// <returns></returns>
        public int Delete(Database database, NZInt ORDER_ID) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(DemandOrderDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + DemandOrderDTO.eColumns.ORDER_ID + "=:ORDER_ID");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("ORDER_ID", DataType.Default, ORDER_ID.Value);
            #endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, NZInt ORDER_ID) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(DemandOrderDTO));

            sb.AppendLine(" SELECT TOP 1 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + DemandOrderDTO.eColumns.ORDER_ID + "=:ORDER_ID");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("ORDER_ID", DataType.Default, ORDER_ID.Value);
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
        public List<DemandOrderDTO> LoadAll(Database database) {
            return LoadAll(database, true,
                DemandOrderDTO.eColumns.ORDER_ID
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<DemandOrderDTO> LoadAll(Database database, bool ascending) {
            return LoadAll(database, ascending,
                DemandOrderDTO.eColumns.ORDER_ID
            );
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<DemandOrderDTO> LoadAll(Database database, bool ascending, params DemandOrderDTO.eColumns[] orderByColumns) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(DemandOrderDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + DemandOrderDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.IS_ACTIVE);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.REVISION);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.YEAR_MONTH);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.CUSTOMER_CD);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.ORDER_ID);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.DUE_DATE);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.ORDER_QTY);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.ORDER_TYPE);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.PRIORITY);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.Reserve);
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

            return db.ExecuteForList<DemandOrderDTO>(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ORDER_ID">Key #1</param>
        /// <returns></returns>
        public DemandOrderDTO LoadByPK(Database database, NZInt ORDER_ID) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(DemandOrderDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + DemandOrderDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.IS_ACTIVE);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.REVISION);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.YEAR_MONTH);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.CUSTOMER_CD);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.ORDER_ID);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.DUE_DATE);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.ORDER_QTY);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.ORDER_TYPE);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.PRIORITY);
            sb.AppendLine("  ," + DemandOrderDTO.eColumns.Reserve);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + DemandOrderDTO.eColumns.ORDER_ID + "=:ORDER_ID");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("ORDER_ID", DataType.Default, ORDER_ID.Value);
            #endregion

            List<DemandOrderDTO> list = db.ExecuteForList<DemandOrderDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        #endregion
    }
}

