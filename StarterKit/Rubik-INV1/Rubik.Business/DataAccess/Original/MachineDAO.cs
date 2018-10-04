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
using System.Data;

namespace Rubik.DAO {
    internal partial class MachineDAO {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public MachineDAO() { }

        public MachineDAO(Database db) {
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
        public int AddNewOrUpdate(Database database, MachineDTO data) {
            Database db = UseDatabase(database);

            if (Exist(database, data.MACHINE_CD))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, MachineDTO data) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            sb.AppendLine("  " + MachineDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + MachineDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + MachineDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + MachineDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + MachineDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + MachineDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + MachineDTO.eColumns.MACHINE_CD);
            sb.AppendLine("  ," + MachineDTO.eColumns.MACHINE_TYPE);
            sb.AppendLine("  ," + MachineDTO.eColumns.PROCESS_CD);
            sb.AppendLine("  ," + MachineDTO.eColumns.MACHINE_GROUP);
            sb.AppendLine("  ," + MachineDTO.eColumns.PROJECT);
            sb.AppendLine("  ," + MachineDTO.eColumns.REMARK);
            sb.AppendLine("  ," + MachineDTO.eColumns.OLD_DATA);
            sb.AppendLine(") VALUES(");
            sb.AppendLine("   @CRT_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,@CRT_MACHINE");
            sb.AppendLine("   ,@UPD_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,@UPD_MACHINE");
            sb.AppendLine("   ,@MACHINE_CD");
            sb.AppendLine("   ,@MACHINE_TYPE");
            sb.AppendLine("   ,@PROCESS_CD");
            sb.AppendLine("   ,@MACHINE_GROUP");
            sb.AppendLine("   ,@PROJECT");
            sb.AppendLine("   ,@REMARK");
            sb.AppendLine("   ,@OLD_DATA");
            sb.AppendLine(" )");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@CRT_BY", DataType.NVarChar, data.CRT_BY.Value);
            req.Parameters.Add("@CRT_MACHINE", DataType.NVarChar, data.CRT_MACHINE.Value);
            req.Parameters.Add("@UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("@MACHINE_CD", DataType.NVarChar, data.MACHINE_CD.Value);
            req.Parameters.Add("@MACHINE_TYPE", DataType.NVarChar, data.MACHINE_TYPE.Value);
            req.Parameters.Add("@PROCESS_CD", DataType.NVarChar, data.PROCESS_CD.Value);
            req.Parameters.Add("@MACHINE_GROUP", DataType.NVarChar, data.MACHINE_GROUP.Value);
            req.Parameters.Add("@PROJECT", DataType.NVarChar, data.PROJECT.Value);
            req.Parameters.Add("@REMARK", DataType.NVarChar, data.REMARK.Value);
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
        public int UpdateWithoutPK(Database database, MachineDTO data) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + MachineDTO.eColumns.UPD_BY + "=@UPD_BY");
            sb.AppendLine("  ," + MachineDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + MachineDTO.eColumns.UPD_MACHINE + "=@UPD_MACHINE");
            sb.AppendLine("  ," + MachineDTO.eColumns.MACHINE_TYPE + "=@MACHINE_TYPE");
            sb.AppendLine("  ," + MachineDTO.eColumns.PROCESS_CD + "=@PROCESS_CD");
            sb.AppendLine("  ," + MachineDTO.eColumns.MACHINE_GROUP + "=@MACHINE_GROUP");
            sb.AppendLine("  ," + MachineDTO.eColumns.PROJECT + "=@PROJECT");
            sb.AppendLine("  ," + MachineDTO.eColumns.REMARK + "=@REMARK");
            sb.AppendLine("  ," + MachineDTO.eColumns.OLD_DATA + "=@OLD_DATA");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + MachineDTO.eColumns.MACHINE_CD + "=@MACHINE_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("@MACHINE_CD", DataType.NVarChar, data.MACHINE_CD.Value);
            req.Parameters.Add("@MACHINE_TYPE", DataType.NVarChar, data.MACHINE_TYPE.Value);
            req.Parameters.Add("@PROCESS_CD", DataType.NVarChar, data.PROCESS_CD.Value);
            req.Parameters.Add("@MACHINE_GROUP", DataType.NVarChar, data.MACHINE_GROUP.Value);
            req.Parameters.Add("@PROJECT", DataType.NVarChar, data.PROJECT.Value);
            req.Parameters.Add("@REMARK", DataType.NVarChar, data.REMARK.Value);
            req.Parameters.Add("@OLD_DATA", DataType.Default, data.OLD_DATA.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using the table's primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data which to update.</param>
        /// <param name="oldMACHINE_CD">Old Key #1</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, MachineDTO data, String oldMACHINE_CD) {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + MachineDTO.eColumns.UPD_BY + "=@UPD_BY");
            sb.AppendLine("  ," + MachineDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + MachineDTO.eColumns.UPD_MACHINE + "=@UPD_MACHINE");
            sb.AppendLine("  ," + MachineDTO.eColumns.MACHINE_CD + "=@MACHINE_CD");
            sb.AppendLine("  ," + MachineDTO.eColumns.MACHINE_TYPE + "=@MACHINE_TYPE");
            sb.AppendLine("  ," + MachineDTO.eColumns.PROCESS_CD + "=@PROCESS_CD");
            sb.AppendLine("  ," + MachineDTO.eColumns.MACHINE_GROUP + "=@MACHINE_GROUP");
            sb.AppendLine("  ," + MachineDTO.eColumns.PROJECT + "=@PROJECT");
            sb.AppendLine("  ," + MachineDTO.eColumns.REMARK + "=@REMARK");
            sb.AppendLine("  ," + MachineDTO.eColumns.OLD_DATA + "=@OLD_DATA");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + MachineDTO.eColumns.MACHINE_CD + "=@oldMACHINE_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("@MACHINE_CD", DataType.NVarChar, data.MACHINE_CD.Value);
            req.Parameters.Add("@MACHINE_TYPE", DataType.NVarChar, data.MACHINE_TYPE.Value);
            req.Parameters.Add("@PROCESS_CD", DataType.NVarChar, data.PROCESS_CD.Value);
            req.Parameters.Add("@MACHINE_GROUP", DataType.NVarChar, data.MACHINE_GROUP.Value);
            req.Parameters.Add("@PROJECT", DataType.NVarChar, data.PROJECT.Value);
            req.Parameters.Add("@REMARK", DataType.NVarChar, data.REMARK.Value);
            req.Parameters.Add("@OLD_DATA", DataType.Default, data.OLD_DATA.Value);
            req.Parameters.Add("@oldMACHINE_CD", DataType.NVarChar, oldMACHINE_CD);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="MACHINE_CD">Key #1</param>
        /// <returns></returns>
        public int Delete(Database database, String MACHINE_CD) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(MachineDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + MachineDTO.eColumns.MACHINE_CD + "=@MACHINE_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@MACHINE_CD", DataType.NVarChar, MACHINE_CD);
            #endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, String MACHINE_CD) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(MachineDTO));

            sb.AppendLine(" SELECT TOP 1 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + MachineDTO.eColumns.MACHINE_CD + "=@MACHINE_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@MACHINE_CD", DataType.NVarChar, MACHINE_CD);
            #endregion

            return (db.ExecuteQuery(req).Rows.Count > 0);
        }

        public string ValidateBeforeDelete(Database database, NZString MACHINE_CD)
        {
            Database db = UseDatabase(database);
            DataRequest req = new DataRequest("S_MAS130_CheckBeforeDelete");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_MachineCode", DataType.VarChar, MACHINE_CD.Value);
            string sReturnCode = db.ExecuteScalar(req).ToString();
            return (NZString)sReturnCode;
        }
        #endregion

        #region Load Operation
        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <returns>List of DTO.</returns>
        public List<MachineDTO> LoadAll(Database database) {
            return LoadAll(database, true,
                MachineDTO.eColumns.MACHINE_CD
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<MachineDTO> LoadAll(Database database, bool ascending) {
            return LoadAll(database, ascending,
                MachineDTO.eColumns.MACHINE_CD
            );
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<MachineDTO> LoadAll(Database database, bool ascending, params MachineDTO.eColumns[] orderByColumns) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(MachineDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + MachineDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + MachineDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + MachineDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + MachineDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + MachineDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + MachineDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + MachineDTO.eColumns.MACHINE_CD);
            sb.AppendLine("  ," + MachineDTO.eColumns.MACHINE_TYPE);
            sb.AppendLine("  ," + MachineDTO.eColumns.PROCESS_CD);
            sb.AppendLine("  ," + MachineDTO.eColumns.MACHINE_GROUP);
            sb.AppendLine("  ," + MachineDTO.eColumns.PROJECT);
            sb.AppendLine("  ," + MachineDTO.eColumns.REMARK);
            sb.AppendLine("  ," + MachineDTO.eColumns.OLD_DATA);
            sb.AppendLine("  ," + MachineDTO.eColumns.TIME_STAMP);
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

            return db.ExecuteForList<MachineDTO>(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="MACHINE_CD">Key #1</param>
        /// <returns></returns>
        public MachineDTO LoadByPK(Database database, String MACHINE_CD) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(MachineDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + MachineDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + MachineDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + MachineDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + MachineDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + MachineDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + MachineDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + MachineDTO.eColumns.MACHINE_CD);
            sb.AppendLine("  ," + MachineDTO.eColumns.MACHINE_TYPE);
            sb.AppendLine("  ," + MachineDTO.eColumns.PROCESS_CD);
            sb.AppendLine("  ," + MachineDTO.eColumns.MACHINE_GROUP);
            sb.AppendLine("  ," + MachineDTO.eColumns.PROJECT);
            sb.AppendLine("  ," + MachineDTO.eColumns.REMARK);
            sb.AppendLine("  ," + MachineDTO.eColumns.OLD_DATA);
            sb.AppendLine("  ," + MachineDTO.eColumns.TIME_STAMP);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + MachineDTO.eColumns.MACHINE_CD + "=@MACHINE_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@MACHINE_CD", DataType.NVarChar, MACHINE_CD);
            #endregion

            List<MachineDTO> list = db.ExecuteForList<MachineDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        #endregion
    }
}

