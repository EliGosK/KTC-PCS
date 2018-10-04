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

namespace SystemMaintenance.SQLServer.DAO
{
    internal partial class MenuFavoriteDAO : IMenuFavoriteDAO
    {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public MenuFavoriteDAO() { }

        public MenuFavoriteDAO(Database db)
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
        public int AddNewOrUpdate(Database database, MenuFavoriteDTO data)
        {
            Database db = UseDatabase(database);

            if (Exist(database, data.USER_ACCOUNT, data.SCREEN_CD))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, MenuFavoriteDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            sb.AppendLine("  " + MenuFavoriteDTO.eColumns.USER_ACCOUNT);
            sb.AppendLine("  ," + MenuFavoriteDTO.eColumns.SCREEN_CD);
            sb.AppendLine("  ," + MenuFavoriteDTO.eColumns.SEQ);
            sb.AppendLine(") VALUES(");
            sb.AppendLine("   :USER_ACCOUNT");
            sb.AppendLine("   ,:SCREEN_CD");
            sb.AppendLine("   ,:SEQ");
            sb.AppendLine(" )");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("USER_ACCOUNT", DataType.NVarChar, data.USER_ACCOUNT.Value);
            req.Parameters.Add("SCREEN_CD", DataType.NVarChar, data.SCREEN_CD.Value);
            req.Parameters.Add("SEQ", DataType.Number, data.SEQ.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using primary key value on the given data variable
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data with primary key value.</param>
        /// <returns></returns>
        public int UpdateWithoutPK(Database database, MenuFavoriteDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + MenuFavoriteDTO.eColumns.SEQ + "=:SEQ");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + MenuFavoriteDTO.eColumns.USER_ACCOUNT + "=:USER_ACCOUNT");
            sb.AppendLine("  AND " + MenuFavoriteDTO.eColumns.SCREEN_CD + "=:SCREEN_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("USER_ACCOUNT", DataType.NVarChar, data.USER_ACCOUNT.Value);
            req.Parameters.Add("SCREEN_CD", DataType.NVarChar, data.SCREEN_CD.Value);
            req.Parameters.Add("SEQ", DataType.Number, data.SEQ.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using the table's primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data which to update.</param>
        /// <param name="oldUSER_ACCOUNT">Old Key #1</param>
        /// <param name="oldSCREEN_CD">Old Key #2</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, MenuFavoriteDTO data, NZString oldUSER_ACCOUNT, NZString oldSCREEN_CD)
        {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + MenuFavoriteDTO.eColumns.USER_ACCOUNT + "=:USER_ACCOUNT");
            sb.AppendLine("  ," + MenuFavoriteDTO.eColumns.SCREEN_CD + "=:SCREEN_CD");
            sb.AppendLine("  ," + MenuFavoriteDTO.eColumns.SEQ + "=:SEQ");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + MenuFavoriteDTO.eColumns.USER_ACCOUNT + "=:oldUSER_ACCOUNT");
            sb.AppendLine("  AND " + MenuFavoriteDTO.eColumns.SCREEN_CD + "=:oldMenuFavorite");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("USER_ACCOUNT", DataType.NVarChar, data.USER_ACCOUNT.Value);
            req.Parameters.Add("SCREEN_CD", DataType.NVarChar, data.SCREEN_CD.Value);
            req.Parameters.Add("SEQ", DataType.Number, data.SEQ.Value);
            req.Parameters.Add("oldUSER_ACCOUNT", DataType.NVarChar, oldUSER_ACCOUNT.Value);
            req.Parameters.Add("oldSCREEN_CD", DataType.NVarChar, oldSCREEN_CD.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="USER_ACCOUNT">Key #1</param>
        /// <param name="SCREEN_CD">Key #2</param>
        /// <returns></returns>
        public int Delete(Database database, NZString USER_ACCOUNT, NZString SCREEN_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(MenuFavoriteDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + MenuFavoriteDTO.eColumns.USER_ACCOUNT + "=:USER_ACCOUNT");
            sb.AppendLine("  AND " + MenuFavoriteDTO.eColumns.SCREEN_CD + "=:SCREEN_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("USER_ACCOUNT", DataType.NVarChar, USER_ACCOUNT.Value);
            req.Parameters.Add("SCREEN_CD", DataType.NVarChar, SCREEN_CD.Value);
            #endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, NZString USER_ACCOUNT, NZString SCREEN_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(MenuFavoriteDTO));

            sb.AppendLine(" SELECT TOP 1 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + MenuFavoriteDTO.eColumns.USER_ACCOUNT + "=:USER_ACCOUNT");
            sb.AppendLine("  AND " + MenuFavoriteDTO.eColumns.SCREEN_CD + "=:SCREEN_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("USER_ACCOUNT", DataType.NVarChar, USER_ACCOUNT.Value);
            req.Parameters.Add("SCREEN_CD", DataType.NVarChar, SCREEN_CD.Value);
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
        public List<MenuFavoriteDTO> LoadAll(Database database)
        {
            return LoadAll(database, true,
                MenuFavoriteDTO.eColumns.USER_ACCOUNT
                , MenuFavoriteDTO.eColumns.SCREEN_CD
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<MenuFavoriteDTO> LoadAll(Database database, bool ascending)
        {
            return LoadAll(database, ascending,
                MenuFavoriteDTO.eColumns.USER_ACCOUNT
                , MenuFavoriteDTO.eColumns.SCREEN_CD
            );
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<MenuFavoriteDTO> LoadAll(Database database, bool ascending, params MenuFavoriteDTO.eColumns[] orderByColumns)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(MenuFavoriteDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + MenuFavoriteDTO.eColumns.USER_ACCOUNT);
            sb.AppendLine("  ," + MenuFavoriteDTO.eColumns.SCREEN_CD);
            sb.AppendLine("  ," + MenuFavoriteDTO.eColumns.SEQ);
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

            return db.ExecuteForList<MenuFavoriteDTO>(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="USER_ACCOUNT">Key #1</param>
        /// <param name="SCREEN_CD">Key #2</param>
        /// <returns></returns>
        public MenuFavoriteDTO LoadByPK(Database database, NZString USER_ACCOUNT, NZString SCREEN_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(MenuFavoriteDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + MenuFavoriteDTO.eColumns.USER_ACCOUNT);
            sb.AppendLine("  ," + MenuFavoriteDTO.eColumns.SCREEN_CD);
            sb.AppendLine("  ," + MenuFavoriteDTO.eColumns.SEQ);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + MenuFavoriteDTO.eColumns.USER_ACCOUNT + "=:USER_ACCOUNT");
            sb.AppendLine("  AND " + MenuFavoriteDTO.eColumns.SCREEN_CD + "=:SCREEN_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("USER_ACCOUNT", DataType.NVarChar, USER_ACCOUNT.Value);
            req.Parameters.Add("SCREEN_CD", DataType.NVarChar, SCREEN_CD.Value);
            #endregion

            List<MenuFavoriteDTO> list = db.ExecuteForList<MenuFavoriteDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        #endregion
    }
}

