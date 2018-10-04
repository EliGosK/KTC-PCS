/* Create by: Ms. Sansanee K.
 * Create on: 2012-03-23
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
    public partial class ItemMachineDAO {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public ItemMachineDAO() { }

        public ItemMachineDAO(Database db) {
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
        public int AddNewOrUpdate(Database database, ItemMachineDTO data) {
            Database db = UseDatabase(database);

            if (Exist(database, data.ITEM_CD, data.RUN_NO))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, ItemMachineDTO data) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            sb.AppendLine("  " + ItemMachineDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.RUN_NO);
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.MACHINE_PROCESS);
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.MACHINE_TYPE);
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.OLD_DATA);
            sb.AppendLine(") VALUES(");
            sb.AppendLine("   @CRT_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,@CRT_MACHINE");
            sb.AppendLine("   ,@UPD_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,@UPD_MACHINE");
            sb.AppendLine("   ,@ITEM_CD");
            sb.AppendLine("   ,@RUN_NO");
            sb.AppendLine("   ,@MACHINE_PROCESS");
            sb.AppendLine("   ,@MACHINE_TYPE");
            sb.AppendLine("   ,@OLD_DATA");
            sb.AppendLine(" )");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@CRT_BY", DataType.NVarChar, data.CRT_BY.Value);
            req.Parameters.Add("@CRT_MACHINE", DataType.NVarChar, data.CRT_MACHINE.Value);
            req.Parameters.Add("@UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("@ITEM_CD", DataType.Default, data.ITEM_CD.Value);
            req.Parameters.Add("@RUN_NO", DataType.Default, data.RUN_NO.Value);
            req.Parameters.Add("@MACHINE_PROCESS", DataType.NVarChar, data.MACHINE_PROCESS.Value);
            req.Parameters.Add("@MACHINE_TYPE", DataType.NVarChar, data.MACHINE_TYPE.Value);
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
        public int UpdateWithoutPK(Database database, ItemMachineDTO data) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + ItemMachineDTO.eColumns.UPD_BY + "=@UPD_BY");
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.UPD_MACHINE + "=@UPD_MACHINE");
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.MACHINE_PROCESS + "=@MACHINE_PROCESS");
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.MACHINE_TYPE + "=@MACHINE_TYPE");
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.OLD_DATA + "=@OLD_DATA");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ItemMachineDTO.eColumns.ITEM_CD + "=@ITEM_CD");
            sb.AppendLine("  AND " + ItemMachineDTO.eColumns.RUN_NO + "=@RUN_NO");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("@ITEM_CD", DataType.Default, data.ITEM_CD.Value);
            req.Parameters.Add("@RUN_NO", DataType.Default, data.RUN_NO.Value);
            req.Parameters.Add("@MACHINE_PROCESS", DataType.NVarChar, data.MACHINE_PROCESS.Value);
            req.Parameters.Add("@MACHINE_TYPE", DataType.NVarChar, data.MACHINE_TYPE.Value);
            req.Parameters.Add("@OLD_DATA", DataType.Default, data.OLD_DATA.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using the table's primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data which to update.</param>
        /// <param name="oldITEM_CD">Old Key #1</param>
        /// <param name="oldRUN_NO">Old Key #2</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, ItemMachineDTO data, NZString oldITEM_CD, NZInt oldRUN_NO) {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + ItemMachineDTO.eColumns.UPD_BY + "=@UPD_BY");
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.UPD_MACHINE + "=@UPD_MACHINE");
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.ITEM_CD + "=@ITEM_CD");
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.RUN_NO + "=@RUN_NO");
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.MACHINE_PROCESS + "=@MACHINE_PROCESS");
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.MACHINE_TYPE + "=@MACHINE_TYPE");
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.OLD_DATA + "=@OLD_DATA");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ItemMachineDTO.eColumns.ITEM_CD + "=@oldITEM_CD");
            sb.AppendLine("  AND " + ItemMachineDTO.eColumns.RUN_NO + "=@oldItemMachine");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("@ITEM_CD", DataType.Default, data.ITEM_CD.Value);
            req.Parameters.Add("@RUN_NO", DataType.Default, data.RUN_NO.Value);
            req.Parameters.Add("@MACHINE_PROCESS", DataType.NVarChar, data.MACHINE_PROCESS.Value);
            req.Parameters.Add("@MACHINE_TYPE", DataType.NVarChar, data.MACHINE_TYPE.Value);
            req.Parameters.Add("@OLD_DATA", DataType.Default, data.OLD_DATA.Value);
            req.Parameters.Add("@oldITEM_CD", DataType.Default, oldITEM_CD);
            req.Parameters.Add("@oldRUN_NO", DataType.Default, oldRUN_NO);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ITEM_CD">Key #1</param>
        /// <param name="RUN_NO">Key #2</param>
        /// <returns></returns>
        public int Delete(Database database, NZString ITEM_CD, NZInt RUN_NO) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ItemMachineDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ItemMachineDTO.eColumns.ITEM_CD + "=@ITEM_CD");
            sb.AppendLine("  AND " + ItemMachineDTO.eColumns.RUN_NO + "=@RUN_NO");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@ITEM_CD", DataType.Default, ITEM_CD);
            req.Parameters.Add("@RUN_NO", DataType.Default, RUN_NO);
            #endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, NZString ITEM_CD, NZInt RUN_NO) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ItemMachineDTO));

            sb.AppendLine(" SELECT TOP 1 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ItemMachineDTO.eColumns.ITEM_CD + "=@ITEM_CD");
            sb.AppendLine("  AND " + ItemMachineDTO.eColumns.RUN_NO + "=@RUN_NO");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@ITEM_CD", DataType.Default, ITEM_CD);
            req.Parameters.Add("@RUN_NO", DataType.Default, RUN_NO);
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
        public List<ItemMachineDTO> LoadAll(Database database) {
            return LoadAll(database, true,
                ItemMachineDTO.eColumns.ITEM_CD
                , ItemMachineDTO.eColumns.RUN_NO
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<ItemMachineDTO> LoadAll(Database database, bool ascending) {
            return LoadAll(database, ascending,
                ItemMachineDTO.eColumns.ITEM_CD
                , ItemMachineDTO.eColumns.RUN_NO
            );
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<ItemMachineDTO> LoadAll(Database database, bool ascending, params ItemMachineDTO.eColumns[] orderByColumns) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ItemMachineDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + ItemMachineDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.RUN_NO);
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.MACHINE_PROCESS);
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.MACHINE_TYPE);
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.OLD_DATA);
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.TIME_STAMP);
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

            return db.ExecuteForList<ItemMachineDTO>(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ITEM_CD">Key #1</param>
        /// <param name="RUN_NO">Key #2</param>
        /// <returns></returns>
        public ItemMachineDTO LoadByPK(Database database, NZString ITEM_CD, NZInt RUN_NO) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ItemMachineDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + ItemMachineDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.RUN_NO);
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.MACHINE_PROCESS);
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.MACHINE_TYPE);
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.OLD_DATA);
            sb.AppendLine("  ," + ItemMachineDTO.eColumns.TIME_STAMP);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ItemMachineDTO.eColumns.ITEM_CD + "=@ITEM_CD");
            sb.AppendLine("  AND " + ItemMachineDTO.eColumns.RUN_NO + "=@RUN_NO");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@ITEM_CD", DataType.Default, ITEM_CD);
            req.Parameters.Add("@RUN_NO", DataType.Default, RUN_NO);
            #endregion

            List<ItemMachineDTO> list = db.ExecuteForList<ItemMachineDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        #endregion
    }
}

