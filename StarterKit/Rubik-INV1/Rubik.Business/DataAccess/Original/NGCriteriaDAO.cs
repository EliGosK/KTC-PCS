/* Create by: Ms. Sansanee K.
 * Create on: 2012-02-24
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

namespace Rubik.DAO 
{
    internal partial class NGCriteriaDAO : BaseDAO 
    {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public NGCriteriaDAO() { }

        public NGCriteriaDAO(Database db) {
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
        public int AddNewOrUpdate(Database database, NGCriteriaDTO data) {
            Database db = UseDatabase(database);

            if (Exist(database, data.PROCESS_CD, data.NG_CRITERIA_CD))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, NGCriteriaDTO data) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            sb.AppendLine("  " + NGCriteriaDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + NGCriteriaDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + NGCriteriaDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + NGCriteriaDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + NGCriteriaDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + NGCriteriaDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + NGCriteriaDTO.eColumns.PROCESS_CD);
            sb.AppendLine("  ," + NGCriteriaDTO.eColumns.NG_CRITERIA_CD);
            sb.AppendLine("  ," + NGCriteriaDTO.eColumns.NG_CRITERIA_DESC);
            sb.AppendLine("  ," + NGCriteriaDTO.eColumns.OLD_DATA);
            sb.AppendLine(") VALUES(");
            sb.AppendLine("   @CRT_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,@CRT_MACHINE");
            sb.AppendLine("   ,@UPD_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,@UPD_MACHINE");
            sb.AppendLine("   ,@PROCESS_CD");
            sb.AppendLine("   ,@NG_CRITERIA_CD");
            sb.AppendLine("   ,@NG_CRITERIA_DESC");
            sb.AppendLine("   ,@OLD_DATA");
            sb.AppendLine(" )");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@CRT_BY", DataType.NVarChar, data.CRT_BY.Value);
            req.Parameters.Add("@CRT_MACHINE", DataType.NVarChar, data.CRT_MACHINE.Value);
            req.Parameters.Add("@UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("@PROCESS_CD", DataType.NVarChar, data.PROCESS_CD.Value);
            req.Parameters.Add("@NG_CRITERIA_CD", DataType.NVarChar, data.NG_CRITERIA_CD.Value);
            req.Parameters.Add("@NG_CRITERIA_DESC", DataType.NVarChar, data.NG_CRITERIA_DESC.Value);
            req.Parameters.Add("@OLD_DATA", DataType.Default, data.OLD_DATA.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using primary key value on the given data variable
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data with primary key value.</param>
        /// <returns></returns>
        public int UpdateWithoutPK(Database database, NGCriteriaDTO data) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + NGCriteriaDTO.eColumns.UPD_BY + "=@UPD_BY");
            sb.AppendLine("  ," + NGCriteriaDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + NGCriteriaDTO.eColumns.UPD_MACHINE + "=@UPD_MACHINE");
            sb.AppendLine("  ," + NGCriteriaDTO.eColumns.NG_CRITERIA_DESC + "=@NG_CRITERIA_DESC");
            sb.AppendLine("  ," + NGCriteriaDTO.eColumns.OLD_DATA + "=@OLD_DATA");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + NGCriteriaDTO.eColumns.PROCESS_CD + "=@PROCESS_CD");
            sb.AppendLine("  AND " + NGCriteriaDTO.eColumns.NG_CRITERIA_CD + "=@NG_CRITERIA_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("@PROCESS_CD", DataType.NVarChar, data.PROCESS_CD.Value);
            req.Parameters.Add("@NG_CRITERIA_CD", DataType.NVarChar, data.NG_CRITERIA_CD.Value);
            req.Parameters.Add("@NG_CRITERIA_DESC", DataType.NVarChar, data.NG_CRITERIA_DESC.Value);
            req.Parameters.Add("@OLD_DATA", DataType.Default, data.OLD_DATA.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using the table's primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data which to update.</param>
        /// <param name="oldPROCESS_CD">Old Key #1</param>
        /// <param name="oldNG_CRITERIA_CD">Old Key #2</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, NGCriteriaDTO data, String oldPROCESS_CD, String oldNG_CRITERIA_CD) {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + NGCriteriaDTO.eColumns.UPD_BY + "=@UPD_BY");
            sb.AppendLine("  ," + NGCriteriaDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + NGCriteriaDTO.eColumns.UPD_MACHINE + "=@UPD_MACHINE");
            sb.AppendLine("  ," + NGCriteriaDTO.eColumns.PROCESS_CD + "=@PROCESS_CD");
            sb.AppendLine("  ," + NGCriteriaDTO.eColumns.NG_CRITERIA_CD + "=@NG_CRITERIA_CD");
            sb.AppendLine("  ," + NGCriteriaDTO.eColumns.NG_CRITERIA_DESC + "=@NG_CRITERIA_DESC");
            sb.AppendLine("  ," + NGCriteriaDTO.eColumns.OLD_DATA + "=@OLD_DATA");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + NGCriteriaDTO.eColumns.PROCESS_CD + "=@oldPROCESS_CD");
            sb.AppendLine("  AND " + NGCriteriaDTO.eColumns.NG_CRITERIA_CD + "=@oldNGCriteria");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("@PROCESS_CD", DataType.NVarChar, data.PROCESS_CD.Value);
            req.Parameters.Add("@NG_CRITERIA_CD", DataType.NVarChar, data.NG_CRITERIA_CD.Value);
            req.Parameters.Add("@NG_CRITERIA_DESC", DataType.NVarChar, data.NG_CRITERIA_DESC.Value);
            req.Parameters.Add("@OLD_DATA", DataType.Default, data.OLD_DATA.Value);
            req.Parameters.Add("@oldPROCESS_CD", DataType.NVarChar, oldPROCESS_CD);
            req.Parameters.Add("@oldNG_CRITERIA_CD", DataType.NVarChar, oldNG_CRITERIA_CD);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="PROCESS_CD">Key #1</param>
        /// <param name="NG_CRITERIA_CD">Key #2</param>
        /// <returns></returns>
        public int Delete(Database database, String PROCESS_CD, String NG_CRITERIA_CD) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(NGCriteriaDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + NGCriteriaDTO.eColumns.PROCESS_CD + "=@PROCESS_CD");
            sb.AppendLine("  AND " + NGCriteriaDTO.eColumns.NG_CRITERIA_CD + "=@NG_CRITERIA_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@PROCESS_CD", DataType.NVarChar, PROCESS_CD);
            req.Parameters.Add("@NG_CRITERIA_CD", DataType.NVarChar, NG_CRITERIA_CD);
            #endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, String PROCESS_CD, String NG_CRITERIA_CD) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(NGCriteriaDTO));

            sb.AppendLine(" SELECT TOP 1 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + NGCriteriaDTO.eColumns.PROCESS_CD + "=@PROCESS_CD");
            sb.AppendLine("  AND " + NGCriteriaDTO.eColumns.NG_CRITERIA_CD + "=@NG_CRITERIA_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@PROCESS_CD", DataType.NVarChar, PROCESS_CD);
            req.Parameters.Add("@NG_CRITERIA_CD", DataType.NVarChar, NG_CRITERIA_CD);
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
        public List<NGCriteriaDTO> LoadAll(Database database) {
            return LoadAll(database, true,
                NGCriteriaDTO.eColumns.PROCESS_CD
                , NGCriteriaDTO.eColumns.NG_CRITERIA_CD
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<NGCriteriaDTO> LoadAll(Database database, bool ascending) {
            return LoadAll(database, ascending,
                NGCriteriaDTO.eColumns.PROCESS_CD
                , NGCriteriaDTO.eColumns.NG_CRITERIA_CD
            );
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<NGCriteriaDTO> LoadAll(Database database, bool ascending, params NGCriteriaDTO.eColumns[] orderByColumns) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(NGCriteriaDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + NGCriteriaDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + NGCriteriaDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + NGCriteriaDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + NGCriteriaDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + NGCriteriaDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + NGCriteriaDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + NGCriteriaDTO.eColumns.PROCESS_CD);
            sb.AppendLine("  ," + NGCriteriaDTO.eColumns.NG_CRITERIA_CD);
            sb.AppendLine("  ," + NGCriteriaDTO.eColumns.NG_CRITERIA_DESC);
            sb.AppendLine("  ," + NGCriteriaDTO.eColumns.OLD_DATA);
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

            return db.ExecuteForList<NGCriteriaDTO>(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="PROCESS_CD">Key #1</param>
        /// <param name="NG_CRITERIA_CD">Key #2</param>
        /// <returns></returns>
        public NGCriteriaDTO LoadByPK(Database database, String PROCESS_CD, String NG_CRITERIA_CD) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(NGCriteriaDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + NGCriteriaDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + NGCriteriaDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + NGCriteriaDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + NGCriteriaDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + NGCriteriaDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + NGCriteriaDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + NGCriteriaDTO.eColumns.PROCESS_CD);
            sb.AppendLine("  ," + NGCriteriaDTO.eColumns.NG_CRITERIA_CD);
            sb.AppendLine("  ," + NGCriteriaDTO.eColumns.NG_CRITERIA_DESC);
            sb.AppendLine("  ," + NGCriteriaDTO.eColumns.OLD_DATA);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + NGCriteriaDTO.eColumns.PROCESS_CD + "=@PROCESS_CD");
            sb.AppendLine("  AND " + NGCriteriaDTO.eColumns.NG_CRITERIA_CD + "=@NG_CRITERIA_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@PROCESS_CD", DataType.NVarChar, PROCESS_CD);
            req.Parameters.Add("@NG_CRITERIA_CD", DataType.NVarChar, NG_CRITERIA_CD);
            #endregion

            List<NGCriteriaDTO> list = db.ExecuteForList<NGCriteriaDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        #endregion
    }
}

