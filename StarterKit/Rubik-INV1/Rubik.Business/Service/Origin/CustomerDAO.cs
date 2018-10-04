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
    internal partial class CustomerDAO {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public CustomerDAO() { }

        public CustomerDAO(Database db) {
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
        public int AddNewOrUpdate(Database database, CustomerDTO data) {
            Database db = UseDatabase(database);

            if (Exist(database, data.CUSTOMER_CODE))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, CustomerDTO data) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            sb.AppendLine("  " + CustomerDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + CustomerDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + CustomerDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + CustomerDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + CustomerDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + CustomerDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + CustomerDTO.eColumns.IS_ACTIVE);
            sb.AppendLine("  ," + CustomerDTO.eColumns.CUSTOMER_CODE);
            sb.AppendLine("  ," + CustomerDTO.eColumns.CUSTOMER_NAME);
            sb.AppendLine("  ," + CustomerDTO.eColumns.ADDRESS);
            sb.AppendLine("  ," + CustomerDTO.eColumns.PHONE_NO);
            sb.AppendLine("  ," + CustomerDTO.eColumns.FAX);
            sb.AppendLine("  ," + CustomerDTO.eColumns.REMARK);
            sb.AppendLine("  ," + CustomerDTO.eColumns.DELIVERY_LT);
            sb.AppendLine(") VALUES(");
            sb.AppendLine("   :CRT_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,:CRT_MACHINE");
            sb.AppendLine("   ,:UPD_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,:UPD_MACHINE");
            sb.AppendLine("   ,:IS_ACTIVE");
            sb.AppendLine("   ,:CUSTOMER_CODE");
            sb.AppendLine("   ,:CUSTOMER_NAME");
            sb.AppendLine("   ,:ADDRESS");
            sb.AppendLine("   ,:PHONE_NO");
            sb.AppendLine("   ,:FAX");
            sb.AppendLine("   ,:REMARK");
            sb.AppendLine("   ,:DELIVERY_LT");
            sb.AppendLine(" )");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("CRT_BY", DataType.NVarChar, data.CRT_BY.Value);
            req.Parameters.Add("CRT_MACHINE", DataType.NVarChar, data.CRT_MACHINE.Value);
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("IS_ACTIVE", DataType.Default, data.IS_ACTIVE.Value);
            req.Parameters.Add("CUSTOMER_CODE", DataType.NVarChar, data.CUSTOMER_CODE.Value);
            req.Parameters.Add("CUSTOMER_NAME", DataType.NVarChar, data.CUSTOMER_NAME.Value);
            req.Parameters.Add("ADDRESS", DataType.NVarChar, data.ADDRESS.Value);
            req.Parameters.Add("PHONE_NO", DataType.NVarChar, data.PHONE_NO.Value);
            req.Parameters.Add("FAX", DataType.NVarChar, data.FAX.Value);
            req.Parameters.Add("REMARK", DataType.NVarChar, data.REMARK.Value);
            req.Parameters.Add("DELIVERY_LT", DataType.Number, data.DELIVERY_LT.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using primary key value on the given data variable
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data with primary key value.</param>
        /// <returns></returns>
        public int UpdateWithoutPK(Database database, CustomerDTO data) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + CustomerDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + CustomerDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + CustomerDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            sb.AppendLine("  ," + CustomerDTO.eColumns.IS_ACTIVE + "=:IS_ACTIVE");
            sb.AppendLine("  ," + CustomerDTO.eColumns.CUSTOMER_NAME + "=:CUSTOMER_NAME");
            sb.AppendLine("  ," + CustomerDTO.eColumns.ADDRESS + "=:ADDRESS");
            sb.AppendLine("  ," + CustomerDTO.eColumns.PHONE_NO + "=:PHONE_NO");
            sb.AppendLine("  ," + CustomerDTO.eColumns.FAX + "=:FAX");
            sb.AppendLine("  ," + CustomerDTO.eColumns.REMARK + "=:REMARK");
            sb.AppendLine("  ," + CustomerDTO.eColumns.DELIVERY_LT + "=:DELIVERY_LT");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + CustomerDTO.eColumns.CUSTOMER_CODE + "=:CUSTOMER_CODE");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("IS_ACTIVE", DataType.Default, data.IS_ACTIVE.Value);
            req.Parameters.Add("CUSTOMER_CODE", DataType.NVarChar, data.CUSTOMER_CODE.Value);
            req.Parameters.Add("CUSTOMER_NAME", DataType.NVarChar, data.CUSTOMER_NAME.Value);
            req.Parameters.Add("ADDRESS", DataType.NVarChar, data.ADDRESS.Value);
            req.Parameters.Add("PHONE_NO", DataType.NVarChar, data.PHONE_NO.Value);
            req.Parameters.Add("FAX", DataType.NVarChar, data.FAX.Value);
            req.Parameters.Add("REMARK", DataType.NVarChar, data.REMARK.Value);
            req.Parameters.Add("DELIVERY_LT", DataType.Number, data.DELIVERY_LT.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using the table's primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data which to update.</param>
        /// <param name="oldCUSTOMER_CODE">Old Key #1</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, CustomerDTO data, NZString oldCUSTOMER_CODE) {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + CustomerDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + CustomerDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + CustomerDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            sb.AppendLine("  ," + CustomerDTO.eColumns.IS_ACTIVE + "=:IS_ACTIVE");
            sb.AppendLine("  ," + CustomerDTO.eColumns.CUSTOMER_CODE + "=:CUSTOMER_CODE");
            sb.AppendLine("  ," + CustomerDTO.eColumns.CUSTOMER_NAME + "=:CUSTOMER_NAME");
            sb.AppendLine("  ," + CustomerDTO.eColumns.ADDRESS + "=:ADDRESS");
            sb.AppendLine("  ," + CustomerDTO.eColumns.PHONE_NO + "=:PHONE_NO");
            sb.AppendLine("  ," + CustomerDTO.eColumns.FAX + "=:FAX");
            sb.AppendLine("  ," + CustomerDTO.eColumns.REMARK + "=:REMARK");
            sb.AppendLine("  ," + CustomerDTO.eColumns.DELIVERY_LT + "=:DELIVERY_LT");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + CustomerDTO.eColumns.CUSTOMER_CODE + "=:oldCUSTOMER_CODE");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("IS_ACTIVE", DataType.Default, data.IS_ACTIVE.Value);
            req.Parameters.Add("CUSTOMER_CODE", DataType.NVarChar, data.CUSTOMER_CODE.Value);
            req.Parameters.Add("CUSTOMER_NAME", DataType.NVarChar, data.CUSTOMER_NAME.Value);
            req.Parameters.Add("ADDRESS", DataType.NVarChar, data.ADDRESS.Value);
            req.Parameters.Add("PHONE_NO", DataType.NVarChar, data.PHONE_NO.Value);
            req.Parameters.Add("FAX", DataType.NVarChar, data.FAX.Value);
            req.Parameters.Add("REMARK", DataType.NVarChar, data.REMARK.Value);
            req.Parameters.Add("DELIVERY_LT", DataType.Number, data.DELIVERY_LT.Value);
            req.Parameters.Add("oldCUSTOMER_CODE", DataType.NVarChar, oldCUSTOMER_CODE.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="CUSTOMER_CODE">Key #1</param>
        /// <returns></returns>
        public int Delete(Database database, NZString CUSTOMER_CODE) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(CustomerDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + CustomerDTO.eColumns.CUSTOMER_CODE + "=:CUSTOMER_CODE");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("CUSTOMER_CODE", DataType.NVarChar, CUSTOMER_CODE.Value);
            #endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, NZString CUSTOMER_CODE) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(CustomerDTO));

            sb.AppendLine(" SELECT TOP 1 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + CustomerDTO.eColumns.CUSTOMER_CODE + "=:CUSTOMER_CODE");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("CUSTOMER_CODE", DataType.NVarChar, CUSTOMER_CODE.Value);
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
        public List<CustomerDTO> LoadAll(Database database) {
            return LoadAll(database, true,
                CustomerDTO.eColumns.CUSTOMER_CODE
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<CustomerDTO> LoadAll(Database database, bool ascending) {
            return LoadAll(database, ascending,
                CustomerDTO.eColumns.CUSTOMER_CODE
            );
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<CustomerDTO> LoadAll(Database database, bool ascending, params CustomerDTO.eColumns[] orderByColumns) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(CustomerDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + CustomerDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + CustomerDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + CustomerDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + CustomerDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + CustomerDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + CustomerDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + CustomerDTO.eColumns.IS_ACTIVE);
            sb.AppendLine("  ," + CustomerDTO.eColumns.CUSTOMER_CODE);
            sb.AppendLine("  ," + CustomerDTO.eColumns.CUSTOMER_NAME);
            sb.AppendLine("  ," + CustomerDTO.eColumns.ADDRESS);
            sb.AppendLine("  ," + CustomerDTO.eColumns.PHONE_NO);
            sb.AppendLine("  ," + CustomerDTO.eColumns.FAX);
            sb.AppendLine("  ," + CustomerDTO.eColumns.REMARK);
            sb.AppendLine("  ," + CustomerDTO.eColumns.DELIVERY_LT);
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

            return db.ExecuteForList<CustomerDTO>(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="CUSTOMER_CODE">Key #1</param>
        /// <returns></returns>
        public CustomerDTO LoadByPK(Database database, NZString CUSTOMER_CODE) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(CustomerDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + CustomerDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + CustomerDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + CustomerDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + CustomerDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + CustomerDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + CustomerDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + CustomerDTO.eColumns.IS_ACTIVE);
            sb.AppendLine("  ," + CustomerDTO.eColumns.CUSTOMER_CODE);
            sb.AppendLine("  ," + CustomerDTO.eColumns.CUSTOMER_NAME);
            sb.AppendLine("  ," + CustomerDTO.eColumns.ADDRESS);
            sb.AppendLine("  ," + CustomerDTO.eColumns.PHONE_NO);
            sb.AppendLine("  ," + CustomerDTO.eColumns.FAX);
            sb.AppendLine("  ," + CustomerDTO.eColumns.REMARK);
            sb.AppendLine("  ," + CustomerDTO.eColumns.DELIVERY_LT);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + CustomerDTO.eColumns.CUSTOMER_CODE + "=:CUSTOMER_CODE");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("CUSTOMER_CODE", DataType.NVarChar, CUSTOMER_CODE.Value);
            #endregion

            List<CustomerDTO> list = db.ExecuteForList<CustomerDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        #endregion
    }
}

