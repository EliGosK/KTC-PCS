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
    internal partial class UserDAO : IUserDAO
    {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public UserDAO() { }

        public UserDAO(Database db)
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
        public int AddNewOrUpdate(Database database, UserDTO data)
        {
            Database db = UseDatabase(database);

            if (Exist(database, data.UPPER_USER_ACCOUNT, data.LOWER_USER_ACCOUNT))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, UserDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            sb.AppendLine("  " + UserDTO.eColumns.USER_ACCOUNT);
            sb.AppendLine("  ," + UserDTO.eColumns.MENU_SET_CD);
            sb.AppendLine("  ," + UserDTO.eColumns.GROUP_CD);
            sb.AppendLine("  ," + UserDTO.eColumns.DEPARTMENT_CD);
            sb.AppendLine("  ," + UserDTO.eColumns.LANG_CD);
            sb.AppendLine("  ," + UserDTO.eColumns.DATE_FORMAT);
            sb.AppendLine("  ," + UserDTO.eColumns.PASS);
            sb.AppendLine("  ," + UserDTO.eColumns.FULL_NAME);
            sb.AppendLine("  ," + UserDTO.eColumns.APPLY_DATE);
            sb.AppendLine("  ," + UserDTO.eColumns.FLG_RESIGN);
            sb.AppendLine("  ," + UserDTO.eColumns.FLG_ACTIVE);
            sb.AppendLine("  ," + UserDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + UserDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + UserDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + UserDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + UserDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + UserDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + UserDTO.eColumns.UPPER_USER_ACCOUNT);
            sb.AppendLine("  ," + UserDTO.eColumns.LOWER_USER_ACCOUNT);
            sb.AppendLine(") VALUES(");
            sb.AppendLine("   :USER_ACCOUNT");
            sb.AppendLine("   ,:MENU_SET_CD");
            sb.AppendLine("   ,:GROUP_CD");
            sb.AppendLine("   ,:DEPARTMENT_CD");
            sb.AppendLine("   ,:LANG_CD");
            sb.AppendLine("   ,:DATE_FORMAT");
            sb.AppendLine("   ,:PASS");
            sb.AppendLine("   ,:FULL_NAME");
            sb.AppendLine("   ,:APPLY_DATE");
            sb.AppendLine("   ,:FLG_RESIGN");
            sb.AppendLine("   ,:FLG_ACTIVE");
            sb.AppendLine("   ,:CRT_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,:CRT_MACHINE");
            sb.AppendLine("   ,:UPD_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,:UPD_MACHINE");
            sb.AppendLine("   ,:UPPER_USER_ACCOUNT");
            sb.AppendLine("   ,:LOWER_USER_ACCOUNT");
            sb.AppendLine(" )");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("USER_ACCOUNT", DataType.NVarChar, data.USER_ACCOUNT.Value);
            req.Parameters.Add("MENU_SET_CD", DataType.NVarChar, data.MENU_SET_CD.Value);
            req.Parameters.Add("GROUP_CD", DataType.NVarChar, data.GROUP_CD.Value);
            req.Parameters.Add("DEPARTMENT_CD", DataType.NVarChar, data.DEPARTMENT_CD.Value);
            req.Parameters.Add("LANG_CD", DataType.NVarChar, data.LANG_CD.Value);
            req.Parameters.Add("DATE_FORMAT", DataType.Number, data.DATE_FORMAT.Value);
            req.Parameters.Add("PASS", DataType.NVarChar, data.PASS.Value);
            req.Parameters.Add("FULL_NAME", DataType.NVarChar, data.FULL_NAME.Value);
            req.Parameters.Add("APPLY_DATE", DataType.DateTime, data.APPLY_DATE.Value);
            req.Parameters.Add("FLG_RESIGN", DataType.Number, data.FLG_RESIGN.Value);
            req.Parameters.Add("FLG_ACTIVE", DataType.Number, data.FLG_ACTIVE.Value);
            req.Parameters.Add("CRT_BY", DataType.NVarChar, data.CRT_BY.Value);
            req.Parameters.Add("CRT_MACHINE", DataType.NVarChar, data.CRT_MACHINE.Value);
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("UPPER_USER_ACCOUNT", DataType.NVarChar, data.UPPER_USER_ACCOUNT.Value);
            req.Parameters.Add("LOWER_USER_ACCOUNT", DataType.NVarChar, data.LOWER_USER_ACCOUNT.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using primary key value on the given data variable
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data with primary key value.</param>
        /// <returns></returns>
        public int UpdateWithoutPK(Database database, UserDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + UserDTO.eColumns.USER_ACCOUNT + "=:USER_ACCOUNT");
            sb.AppendLine("  ," + UserDTO.eColumns.MENU_SET_CD + "=:MENU_SET_CD");
            sb.AppendLine("  ," + UserDTO.eColumns.GROUP_CD + "=:GROUP_CD");
            sb.AppendLine("  ," + UserDTO.eColumns.DEPARTMENT_CD + "=:DEPARTMENT_CD");
            sb.AppendLine("  ," + UserDTO.eColumns.LANG_CD + "=:LANG_CD");
            sb.AppendLine("  ," + UserDTO.eColumns.DATE_FORMAT + "=:DATE_FORMAT");
            sb.AppendLine("  ," + UserDTO.eColumns.PASS + "=:PASS");
            sb.AppendLine("  ," + UserDTO.eColumns.FULL_NAME + "=:FULL_NAME");
            sb.AppendLine("  ," + UserDTO.eColumns.APPLY_DATE + "=:APPLY_DATE");
            sb.AppendLine("  ," + UserDTO.eColumns.FLG_RESIGN + "=:FLG_RESIGN");
            sb.AppendLine("  ," + UserDTO.eColumns.FLG_ACTIVE + "=:FLG_ACTIVE");
            sb.AppendLine("  ," + UserDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + UserDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + UserDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + UserDTO.eColumns.UPPER_USER_ACCOUNT + "=:UPPER_USER_ACCOUNT");
            sb.AppendLine("  AND " + UserDTO.eColumns.LOWER_USER_ACCOUNT + "=:LOWER_USER_ACCOUNT");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("USER_ACCOUNT", DataType.NVarChar, data.USER_ACCOUNT.Value);
            req.Parameters.Add("MENU_SET_CD", DataType.NVarChar, data.MENU_SET_CD.Value);
            req.Parameters.Add("GROUP_CD", DataType.NVarChar, data.GROUP_CD.Value);
            req.Parameters.Add("DEPARTMENT_CD", DataType.NVarChar, data.DEPARTMENT_CD.Value);
            req.Parameters.Add("LANG_CD", DataType.NVarChar, data.LANG_CD.Value);
            req.Parameters.Add("DATE_FORMAT", DataType.Number, data.DATE_FORMAT.Value);
            req.Parameters.Add("PASS", DataType.NVarChar, data.PASS.Value);
            req.Parameters.Add("FULL_NAME", DataType.NVarChar, data.FULL_NAME.Value);
            req.Parameters.Add("APPLY_DATE", DataType.DateTime, data.APPLY_DATE.Value);
            req.Parameters.Add("FLG_RESIGN", DataType.Number, data.FLG_RESIGN.Value);
            req.Parameters.Add("FLG_ACTIVE", DataType.Number, data.FLG_ACTIVE.Value);
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("UPPER_USER_ACCOUNT", DataType.NVarChar, data.UPPER_USER_ACCOUNT.Value);
            req.Parameters.Add("LOWER_USER_ACCOUNT", DataType.NVarChar, data.LOWER_USER_ACCOUNT.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using the table's primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data which to update.</param>
        /// <param name="oldUPPER_USER_ACCOUNT">Old Key #1</param>
        /// <param name="oldLOWER_USER_ACCOUNT">Old Key #2</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, UserDTO data, NZString oldUPPER_USER_ACCOUNT, NZString oldLOWER_USER_ACCOUNT)
        {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + UserDTO.eColumns.USER_ACCOUNT + "=:USER_ACCOUNT");
            sb.AppendLine("  ," + UserDTO.eColumns.MENU_SET_CD + "=:MENU_SET_CD");
            sb.AppendLine("  ," + UserDTO.eColumns.GROUP_CD + "=:GROUP_CD");
            sb.AppendLine("  ," + UserDTO.eColumns.DEPARTMENT_CD + "=:DEPARTMENT_CD");
            sb.AppendLine("  ," + UserDTO.eColumns.LANG_CD + "=:LANG_CD");
            sb.AppendLine("  ," + UserDTO.eColumns.DATE_FORMAT + "=:DATE_FORMAT");
            sb.AppendLine("  ," + UserDTO.eColumns.PASS + "=:PASS");
            sb.AppendLine("  ," + UserDTO.eColumns.FULL_NAME + "=:FULL_NAME");
            sb.AppendLine("  ," + UserDTO.eColumns.APPLY_DATE + "=:APPLY_DATE");
            sb.AppendLine("  ," + UserDTO.eColumns.FLG_RESIGN + "=:FLG_RESIGN");
            sb.AppendLine("  ," + UserDTO.eColumns.FLG_ACTIVE + "=:FLG_ACTIVE");
            sb.AppendLine("  ," + UserDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + UserDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + UserDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            sb.AppendLine("  ," + UserDTO.eColumns.UPPER_USER_ACCOUNT + "=:UPPER_USER_ACCOUNT");
            sb.AppendLine("  ," + UserDTO.eColumns.LOWER_USER_ACCOUNT + "=:LOWER_USER_ACCOUNT");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + UserDTO.eColumns.UPPER_USER_ACCOUNT + "=:oldUPPER_USER_ACCOUNT");
            sb.AppendLine("  AND " + UserDTO.eColumns.LOWER_USER_ACCOUNT + "=:oldUser");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("USER_ACCOUNT", DataType.NVarChar, data.USER_ACCOUNT.Value);
            req.Parameters.Add("MENU_SET_CD", DataType.NVarChar, data.MENU_SET_CD.Value);
            req.Parameters.Add("GROUP_CD", DataType.NVarChar, data.GROUP_CD.Value);
            req.Parameters.Add("DEPARTMENT_CD", DataType.NVarChar, data.DEPARTMENT_CD.Value);
            req.Parameters.Add("LANG_CD", DataType.NVarChar, data.LANG_CD.Value);
            req.Parameters.Add("DATE_FORMAT", DataType.Number, data.DATE_FORMAT.Value);
            req.Parameters.Add("PASS", DataType.NVarChar, data.PASS.Value);
            req.Parameters.Add("FULL_NAME", DataType.NVarChar, data.FULL_NAME.Value);
            req.Parameters.Add("APPLY_DATE", DataType.DateTime, data.APPLY_DATE.Value);
            req.Parameters.Add("FLG_RESIGN", DataType.Number, data.FLG_RESIGN.Value);
            req.Parameters.Add("FLG_ACTIVE", DataType.Number, data.FLG_ACTIVE.Value);
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("UPPER_USER_ACCOUNT", DataType.NVarChar, data.UPPER_USER_ACCOUNT.Value);
            req.Parameters.Add("LOWER_USER_ACCOUNT", DataType.NVarChar, data.LOWER_USER_ACCOUNT.Value);
            req.Parameters.Add("oldUPPER_USER_ACCOUNT", DataType.NVarChar, oldUPPER_USER_ACCOUNT.Value);
            req.Parameters.Add("oldLOWER_USER_ACCOUNT", DataType.NVarChar, oldLOWER_USER_ACCOUNT.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="UPPER_USER_ACCOUNT">Key #1</param>
        /// <param name="LOWER_USER_ACCOUNT">Key #2</param>
        /// <returns></returns>
        public int Delete(Database database, NZString UPPER_USER_ACCOUNT, NZString LOWER_USER_ACCOUNT)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(UserDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + UserDTO.eColumns.UPPER_USER_ACCOUNT + "=:UPPER_USER_ACCOUNT");
            sb.AppendLine("  AND " + UserDTO.eColumns.LOWER_USER_ACCOUNT + "=:LOWER_USER_ACCOUNT");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("UPPER_USER_ACCOUNT", DataType.NVarChar, UPPER_USER_ACCOUNT.Value);
            req.Parameters.Add("LOWER_USER_ACCOUNT", DataType.NVarChar, LOWER_USER_ACCOUNT.Value);
            #endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, NZString UPPER_USER_ACCOUNT, NZString LOWER_USER_ACCOUNT)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(UserDTO));

            sb.AppendLine(" SELECT TOP 1 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + UserDTO.eColumns.UPPER_USER_ACCOUNT + "=:UPPER_USER_ACCOUNT");
            sb.AppendLine("  AND " + UserDTO.eColumns.LOWER_USER_ACCOUNT + "=:LOWER_USER_ACCOUNT");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("UPPER_USER_ACCOUNT", DataType.NVarChar, UPPER_USER_ACCOUNT.Value);
            req.Parameters.Add("LOWER_USER_ACCOUNT", DataType.NVarChar, LOWER_USER_ACCOUNT.Value);
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
        public List<UserDTO> LoadAll(Database database)
        {
            return LoadAll(database, true,
                UserDTO.eColumns.UPPER_USER_ACCOUNT
                , UserDTO.eColumns.LOWER_USER_ACCOUNT
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<UserDTO> LoadAll(Database database, bool ascending)
        {
            return LoadAll(database, ascending,
                UserDTO.eColumns.UPPER_USER_ACCOUNT
                , UserDTO.eColumns.LOWER_USER_ACCOUNT
            );
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<UserDTO> LoadAll(Database database, bool ascending, params UserDTO.eColumns[] orderByColumns)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(UserDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + UserDTO.eColumns.USER_ACCOUNT);
            sb.AppendLine("  ," + UserDTO.eColumns.MENU_SET_CD);
            sb.AppendLine("  ," + UserDTO.eColumns.GROUP_CD);
            sb.AppendLine("  ," + UserDTO.eColumns.DEPARTMENT_CD);
            sb.AppendLine("  ," + UserDTO.eColumns.LANG_CD);
            sb.AppendLine("  ," + UserDTO.eColumns.DATE_FORMAT);
            sb.AppendLine("  ," + UserDTO.eColumns.PASS);
            sb.AppendLine("  ," + UserDTO.eColumns.FULL_NAME);
            sb.AppendLine("  ," + UserDTO.eColumns.APPLY_DATE);
            sb.AppendLine("  ," + UserDTO.eColumns.FLG_RESIGN);
            sb.AppendLine("  ," + UserDTO.eColumns.FLG_ACTIVE);
            sb.AppendLine("  ," + UserDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + UserDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + UserDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + UserDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + UserDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + UserDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + UserDTO.eColumns.UPPER_USER_ACCOUNT);
            sb.AppendLine("  ," + UserDTO.eColumns.LOWER_USER_ACCOUNT);
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

            return db.ExecuteForList<UserDTO>(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="UPPER_USER_ACCOUNT">Key #1</param>
        /// <param name="LOWER_USER_ACCOUNT">Key #2</param>
        /// <returns></returns>
        public UserDTO LoadByPK(Database database, NZString UPPER_USER_ACCOUNT, NZString LOWER_USER_ACCOUNT)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(UserDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + UserDTO.eColumns.USER_ACCOUNT);
            sb.AppendLine("  ," + UserDTO.eColumns.MENU_SET_CD);
            sb.AppendLine("  ," + UserDTO.eColumns.GROUP_CD);
            sb.AppendLine("  ," + UserDTO.eColumns.DEPARTMENT_CD);
            sb.AppendLine("  ," + UserDTO.eColumns.LANG_CD);
            sb.AppendLine("  ," + UserDTO.eColumns.DATE_FORMAT);
            sb.AppendLine("  ," + UserDTO.eColumns.PASS);
            sb.AppendLine("  ," + UserDTO.eColumns.FULL_NAME);
            sb.AppendLine("  ," + UserDTO.eColumns.APPLY_DATE);
            sb.AppendLine("  ," + UserDTO.eColumns.FLG_RESIGN);
            sb.AppendLine("  ," + UserDTO.eColumns.FLG_ACTIVE);
            sb.AppendLine("  ," + UserDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + UserDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + UserDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + UserDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + UserDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + UserDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + UserDTO.eColumns.UPPER_USER_ACCOUNT);
            sb.AppendLine("  ," + UserDTO.eColumns.LOWER_USER_ACCOUNT);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + UserDTO.eColumns.UPPER_USER_ACCOUNT + "=:UPPER_USER_ACCOUNT");
            sb.AppendLine("  AND " + UserDTO.eColumns.LOWER_USER_ACCOUNT + "=:LOWER_USER_ACCOUNT");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("UPPER_USER_ACCOUNT", DataType.NVarChar, UPPER_USER_ACCOUNT.Value);
            req.Parameters.Add("LOWER_USER_ACCOUNT", DataType.NVarChar, LOWER_USER_ACCOUNT.Value);
            #endregion

            List<UserDTO> list = db.ExecuteForList<UserDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        #endregion


    }
}

