/* Create by: Ms. Sansanee K.
 * Create on: 2012-03-05
 * Company: CSI Groups (Thailand)
 * Group: SI-EVO
 
 *** This generate source code was build for DAO on StarterKit system. ***/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using EVOFramework.Database;
using Rubik.DTO;

namespace Rubik.DAO {
    internal partial class DealingConstraintDAO {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public DealingConstraintDAO() { }

        public DealingConstraintDAO(Database db) {
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
        public int AddNewOrUpdate(Database database, DealingConstraintDTO data) {
            Database db = UseDatabase(database);

            if (Exist(database, data.LOC_CD))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, DealingConstraintDTO data) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            sb.AppendLine("  " + DealingConstraintDTO.eColumns.LOC_CD);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.NO_CONSUMPTION_FLAG);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.COMPONENT_ITEM_USAGE);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.ENABLE_SUPPLIER_FLAG);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.ENABLE_LOT_FLAG);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.ENABLE_PACK_FLAG);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.ENABLE_CUST_LOT_FLAG);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.NO_MOVE_FLAG);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.NO_PRODUCTION_REPORT_FLAG);
            sb.AppendLine(") VALUES(");
            sb.AppendLine("   @LOC_CD");
            sb.AppendLine("   ,@NO_CONSUMPTION_FLAG");
            sb.AppendLine("   ,@COMPONENT_ITEM_USAGE");
            sb.AppendLine("   ,@ENABLE_SUPPLIER_FLAG");
            sb.AppendLine("   ,@ENABLE_LOT_FLAG");
            sb.AppendLine("   ,@ENABLE_PACK_FLAG");
            sb.AppendLine("   ,@ENABLE_CUST_LOT_FLAG");
            sb.AppendLine("   ,@NO_MOVE_FLAG");
            sb.AppendLine("   ,@NO_PRODUCTION_REPORT_FLAG");
            sb.AppendLine(" )");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@LOC_CD", DataType.NVarChar, data.LOC_CD.Value);
            req.Parameters.Add("@NO_CONSUMPTION_FLAG", DataType.Default, data.NO_CONSUMPTION_FLAG.Value);
            req.Parameters.Add("@COMPONENT_ITEM_USAGE", DataType.Default, data.COMPONENT_ITEM_USAGE.Value);
            req.Parameters.Add("@ENABLE_SUPPLIER_FLAG", DataType.Default, data.ENABLE_SUPPLIER_FLAG.Value);
            req.Parameters.Add("@ENABLE_LOT_FLAG", DataType.Default, data.ENABLE_LOT_FLAG.Value);
            req.Parameters.Add("@ENABLE_PACK_FLAG", DataType.Default, data.ENABLE_PACK_FLAG.Value);
            req.Parameters.Add("@ENABLE_CUST_LOT_FLAG", DataType.Default, data.ENABLE_CUST_LOT_FLAG.Value);
            req.Parameters.Add("@NO_MOVE_FLAG", DataType.Default, data.NO_MOVE_FLAG.Value);
            req.Parameters.Add("@NO_PRODUCTION_REPORT_FLAG", DataType.Default, data.NO_PRODUCTION_REPORT_FLAG.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using primary key value on the given data variable
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data with primary key value.</param>
        /// <returns></returns>
        public int UpdateWithoutPK(Database database, DealingConstraintDTO data) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + DealingConstraintDTO.eColumns.NO_CONSUMPTION_FLAG + "=@NO_CONSUMPTION_FLAG");
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.COMPONENT_ITEM_USAGE + "=@COMPONENT_ITEM_USAGE");
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.ENABLE_SUPPLIER_FLAG + "=@ENABLE_SUPPLIER_FLAG");
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.ENABLE_LOT_FLAG + "=@ENABLE_LOT_FLAG");
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.ENABLE_PACK_FLAG + "=@ENABLE_PACK_FLAG");
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.ENABLE_CUST_LOT_FLAG + "=@ENABLE_CUST_LOT_FLAG");
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.NO_MOVE_FLAG + "=@NO_MOVE_FLAG");
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.NO_PRODUCTION_REPORT_FLAG + "=@NO_PRODUCTION_REPORT_FLAG");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + DealingConstraintDTO.eColumns.LOC_CD + "=@LOC_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@LOC_CD", DataType.NVarChar, data.LOC_CD.Value);
            req.Parameters.Add("@NO_CONSUMPTION_FLAG", DataType.Default, data.NO_CONSUMPTION_FLAG.Value);
            req.Parameters.Add("@COMPONENT_ITEM_USAGE", DataType.Default, data.COMPONENT_ITEM_USAGE.Value);
            req.Parameters.Add("@ENABLE_SUPPLIER_FLAG", DataType.Default, data.ENABLE_SUPPLIER_FLAG.Value);
            req.Parameters.Add("@ENABLE_LOT_FLAG", DataType.Default, data.ENABLE_LOT_FLAG.Value);
            req.Parameters.Add("@ENABLE_PACK_FLAG", DataType.Default, data.ENABLE_PACK_FLAG.Value);
            req.Parameters.Add("@ENABLE_CUST_LOT_FLAG", DataType.Default, data.ENABLE_CUST_LOT_FLAG.Value);
            req.Parameters.Add("@NO_MOVE_FLAG", DataType.Default, data.NO_MOVE_FLAG.Value);
            req.Parameters.Add("@NO_PRODUCTION_REPORT_FLAG", DataType.Default, data.NO_PRODUCTION_REPORT_FLAG.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using the table's primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data which to update.</param>
        /// <param name="oldLOC_CD">Old Key #1</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, DealingConstraintDTO data, String oldLOC_CD) {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + DealingConstraintDTO.eColumns.LOC_CD + "=@LOC_CD");
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.NO_CONSUMPTION_FLAG + "=@NO_CONSUMPTION_FLAG");
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.COMPONENT_ITEM_USAGE + "=@COMPONENT_ITEM_USAGE");
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.ENABLE_SUPPLIER_FLAG + "=@ENABLE_SUPPLIER_FLAG");
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.ENABLE_LOT_FLAG + "=@ENABLE_LOT_FLAG");
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.ENABLE_PACK_FLAG + "=@ENABLE_PACK_FLAG");
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.ENABLE_CUST_LOT_FLAG + "=@ENABLE_CUST_LOT_FLAG");
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.NO_MOVE_FLAG + "=@NO_MOVE_FLAG");
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.NO_PRODUCTION_REPORT_FLAG + "=@NO_PRODUCTION_REPORT_FLAG");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + DealingConstraintDTO.eColumns.LOC_CD + "=@oldLOC_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@LOC_CD", DataType.NVarChar, data.LOC_CD.Value);
            req.Parameters.Add("@NO_CONSUMPTION_FLAG", DataType.Default, data.NO_CONSUMPTION_FLAG.Value);
            req.Parameters.Add("@COMPONENT_ITEM_USAGE", DataType.Default, data.COMPONENT_ITEM_USAGE.Value);
            req.Parameters.Add("@ENABLE_SUPPLIER_FLAG", DataType.Default, data.ENABLE_SUPPLIER_FLAG.Value);
            req.Parameters.Add("@ENABLE_LOT_FLAG", DataType.Default, data.ENABLE_LOT_FLAG.Value);
            req.Parameters.Add("@ENABLE_PACK_FLAG", DataType.Default, data.ENABLE_PACK_FLAG.Value);
            req.Parameters.Add("@ENABLE_CUST_LOT_FLAG", DataType.Default, data.ENABLE_CUST_LOT_FLAG.Value);
            req.Parameters.Add("@NO_MOVE_FLAG", DataType.Default, data.NO_MOVE_FLAG.Value);
            req.Parameters.Add("@NO_PRODUCTION_REPORT_FLAG", DataType.Default, data.NO_PRODUCTION_REPORT_FLAG.Value);
            req.Parameters.Add("@oldLOC_CD", DataType.NVarChar, oldLOC_CD);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="LOC_CD">Key #1</param>
        /// <returns></returns>
        public int Delete(Database database, String LOC_CD) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(DealingConstraintDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + DealingConstraintDTO.eColumns.LOC_CD + "=@LOC_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@LOC_CD", DataType.NVarChar, LOC_CD);
            #endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, String LOC_CD) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(DealingConstraintDTO));

            sb.AppendLine(" SELECT TOP 1 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + DealingConstraintDTO.eColumns.LOC_CD + "=@LOC_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@LOC_CD", DataType.NVarChar, LOC_CD);
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
        public List<DealingConstraintDTO> LoadAll(Database database) {
            return LoadAll(database, true,
                DealingConstraintDTO.eColumns.LOC_CD
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<DealingConstraintDTO> LoadAll(Database database, bool ascending) {
            return LoadAll(database, ascending,
                DealingConstraintDTO.eColumns.LOC_CD
            );
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<DealingConstraintDTO> LoadAll(Database database, bool ascending, params DealingConstraintDTO.eColumns[] orderByColumns) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(DealingConstraintDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + DealingConstraintDTO.eColumns.LOC_CD);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.NO_CONSUMPTION_FLAG);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.COMPONENT_ITEM_USAGE);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.ENABLE_SUPPLIER_FLAG);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.ENABLE_LOT_FLAG);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.ENABLE_PACK_FLAG);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.ENABLE_CUST_LOT_FLAG);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.NO_MOVE_FLAG);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.NO_PRODUCTION_REPORT_FLAG);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.NO_NG_CONSUMPTION_FLAG);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.LOT_CONTROL_FLAG);
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

            return db.ExecuteForList<DealingConstraintDTO>(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="LOC_CD">Key #1</param>
        /// <returns></returns>
        public DealingConstraintDTO LoadByPK(Database database, String LOC_CD) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(DealingConstraintDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + DealingConstraintDTO.eColumns.LOC_CD);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.NO_CONSUMPTION_FLAG);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.COMPONENT_ITEM_USAGE);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.ENABLE_SUPPLIER_FLAG);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.ENABLE_LOT_FLAG);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.ENABLE_PACK_FLAG);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.ENABLE_CUST_LOT_FLAG);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.NO_MOVE_FLAG);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.NO_PRODUCTION_REPORT_FLAG);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.NO_NG_CONSUMPTION_FLAG);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.LOT_CONTROL_FLAG);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.CHECK_DUPLICATE_LOT_FLAG);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + DealingConstraintDTO.eColumns.LOC_CD + "=@LOC_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@LOC_CD", DataType.NVarChar, LOC_CD);
            #endregion

            List<DealingConstraintDTO> list = db.ExecuteForList<DealingConstraintDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        #endregion
    }
}

