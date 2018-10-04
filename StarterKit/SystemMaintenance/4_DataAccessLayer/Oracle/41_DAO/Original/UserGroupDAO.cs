/* Create by: Mr.Teerayut Sinlan
 * Create on: 2009-09-25
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
    internal partial class UserGroupDAO : IUserGroupDAO
    {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public UserGroupDAO() { }

        public UserGroupDAO(Database db)
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
        public int AddNewOrUpdate(Database database, UserGroupDTO data)
        {
            Database db = UseDatabase(database);

            if (Exist(database, data.GROUP_CD))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, UserGroupDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            sb.AppendLine("  " + UserGroupDTO.eColumns.GROUP_CD);
            sb.AppendLine("  ," + UserGroupDTO.eColumns.GROUP_NAME);
            sb.AppendLine("  ," + UserGroupDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + UserGroupDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + UserGroupDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + UserGroupDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + UserGroupDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + UserGroupDTO.eColumns.UPD_MACHINE);
            sb.AppendLine(") VALUES(");
            sb.AppendLine("   :GROUP_CD");
            sb.AppendLine("   ,:GROUP_NAME");
            sb.AppendLine("   ,:CRT_BY");
            sb.AppendLine("   ,SYSDATE");
            sb.AppendLine("   ,:CRT_MACHINE");
            sb.AppendLine("   ,:UPD_BY");
            sb.AppendLine("   ,SYSDATE");
            sb.AppendLine("   ,:UPD_MACHINE");
            sb.AppendLine(" )");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("GROUP_CD", DataType.NVarChar, data.GROUP_CD.Value);
            req.Parameters.Add("GROUP_NAME", DataType.NVarChar, data.GROUP_NAME.Value);
            req.Parameters.Add("CRT_BY", DataType.NVarChar, data.CRT_BY.Value);
            req.Parameters.Add("CRT_MACHINE", DataType.NVarChar, data.CRT_MACHINE.Value);
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using primary key value on the given data variable
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data with primary key value.</param>
        /// <returns></returns>
        public int UpdateWithoutPK(Database database, UserGroupDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + UserGroupDTO.eColumns.GROUP_NAME + "=:GROUP_NAME");
            sb.AppendLine("  ," + UserGroupDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + UserGroupDTO.eColumns.UPD_DATE + "=SYSDATE");
            sb.AppendLine("  ," + UserGroupDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + UserGroupDTO.eColumns.GROUP_CD + "=:GROUP_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("GROUP_CD", DataType.NVarChar, data.GROUP_CD.Value);
            req.Parameters.Add("GROUP_NAME", DataType.NVarChar, data.GROUP_NAME.Value);
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using the table's primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data which to update.</param>
        /// <param name="oldGROUP_CD">Old Key #1</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, UserGroupDTO data, NZString oldGROUP_CD)
        {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + UserGroupDTO.eColumns.GROUP_CD + "=:GROUP_CD");
            sb.AppendLine("  ," + UserGroupDTO.eColumns.GROUP_NAME + "=:GROUP_NAME");
            sb.AppendLine("  ," + UserGroupDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + UserGroupDTO.eColumns.UPD_DATE + "=SYSDATE");
            sb.AppendLine("  ," + UserGroupDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + UserGroupDTO.eColumns.GROUP_CD + "=:oldGROUP_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("GROUP_CD", DataType.NVarChar, data.GROUP_CD.Value);
            req.Parameters.Add("GROUP_NAME", DataType.NVarChar, data.GROUP_NAME.Value);
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("oldGROUP_CD", DataType.NVarChar, oldGROUP_CD.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="GROUP_CD">Key #1</param>
        /// <returns></returns>
        public int Delete(Database database, NZString GROUP_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(UserGroupDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + UserGroupDTO.eColumns.GROUP_CD + "=:GROUP_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("GROUP_CD", DataType.NVarChar, GROUP_CD.Value);
            #endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, NZString GROUP_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(UserGroupDTO));

            sb.AppendLine(" SELECT 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ROWNUM=1");
            sb.AppendLine("  AND " + UserGroupDTO.eColumns.GROUP_CD + "=:GROUP_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("GROUP_CD", DataType.NVarChar, GROUP_CD.Value);
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
        public List<UserGroupDTO> LoadAll(Database database)
        {
            return LoadAll(database, true,
                UserGroupDTO.eColumns.GROUP_CD
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<UserGroupDTO> LoadAll(Database database, bool ascending)
        {
            return LoadAll(database, ascending,
                UserGroupDTO.eColumns.GROUP_CD
            );
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<UserGroupDTO> LoadAll(Database database, bool ascending, params UserGroupDTO.eColumns[] orderByColumns)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(UserGroupDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + UserGroupDTO.eColumns.GROUP_CD);
            sb.AppendLine("  ," + UserGroupDTO.eColumns.GROUP_NAME);
            sb.AppendLine("  ," + UserGroupDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + UserGroupDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + UserGroupDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + UserGroupDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + UserGroupDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + UserGroupDTO.eColumns.UPD_MACHINE);
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

            return db.ExecuteForList<UserGroupDTO>(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="GROUP_CD">Key #1</param>
        /// <returns></returns>
        public UserGroupDTO LoadByPK(Database database, NZString GROUP_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(UserGroupDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + UserGroupDTO.eColumns.GROUP_CD);
            sb.AppendLine("  ," + UserGroupDTO.eColumns.GROUP_NAME);
            sb.AppendLine("  ," + UserGroupDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + UserGroupDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + UserGroupDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + UserGroupDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + UserGroupDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + UserGroupDTO.eColumns.UPD_MACHINE);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + UserGroupDTO.eColumns.GROUP_CD + "=:GROUP_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("GROUP_CD", DataType.NVarChar, GROUP_CD.Value);
            #endregion

            List<UserGroupDTO> list = db.ExecuteForList<UserGroupDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        #endregion
    }
}

