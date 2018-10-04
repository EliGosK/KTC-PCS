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
    internal partial class UserScreenPermissionDAO : IUserScreenPermissionDAO
    {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public UserScreenPermissionDAO() { }

        public UserScreenPermissionDAO(Database db)
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
        public int AddNewOrUpdate(Database database, UserScreenPermissionDTO data)
        {
            Database db = UseDatabase(database);

            if (Exist(database, data.SCREEN_CD, data.USER_CD))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, UserScreenPermissionDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            sb.AppendLine("  " + UserScreenPermissionDTO.eColumns.SCREEN_CD);
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.USER_CD);
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.FLG_VIEW);
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.FLG_ADD);
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.FLG_CHG);
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.FLG_DEL);
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.UPD_MACHINE);
            sb.AppendLine(") VALUES(");
            sb.AppendLine("   :SCREEN_CD");
            sb.AppendLine("   ,:USER_CD");
            sb.AppendLine("   ,:FLG_VIEW");
            sb.AppendLine("   ,:FLG_ADD");
            sb.AppendLine("   ,:FLG_CHG");
            sb.AppendLine("   ,:FLG_DEL");
            sb.AppendLine("   ,:CRT_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,:CRT_MACHINE");
            sb.AppendLine("   ,:UPD_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,:UPD_MACHINE");
            sb.AppendLine(" )");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("SCREEN_CD", DataType.VarChar, data.SCREEN_CD.Value);
            req.Parameters.Add("USER_CD", DataType.VarChar, data.USER_CD.Value);
            req.Parameters.Add("FLG_VIEW", DataType.Number, data.FLG_VIEW.Value);
            req.Parameters.Add("FLG_ADD", DataType.Number, data.FLG_ADD.Value);
            req.Parameters.Add("FLG_CHG", DataType.Number, data.FLG_CHG.Value);
            req.Parameters.Add("FLG_DEL", DataType.Number, data.FLG_DEL.Value);
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
        public int UpdateWithoutPK(Database database, UserScreenPermissionDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + UserScreenPermissionDTO.eColumns.FLG_VIEW + "=:FLG_VIEW");
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.FLG_ADD + "=:FLG_ADD");
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.FLG_CHG + "=:FLG_CHG");
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.FLG_DEL + "=:FLG_DEL");
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + UserScreenPermissionDTO.eColumns.SCREEN_CD + "=:SCREEN_CD");
            sb.AppendLine("  AND " + UserScreenPermissionDTO.eColumns.USER_CD + "=:USER_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("SCREEN_CD", DataType.VarChar, data.SCREEN_CD.Value);
            req.Parameters.Add("USER_CD", DataType.VarChar, data.USER_CD.Value);
            req.Parameters.Add("FLG_VIEW", DataType.Number, data.FLG_VIEW.Value);
            req.Parameters.Add("FLG_ADD", DataType.Number, data.FLG_ADD.Value);
            req.Parameters.Add("FLG_CHG", DataType.Number, data.FLG_CHG.Value);
            req.Parameters.Add("FLG_DEL", DataType.Number, data.FLG_DEL.Value);
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
        /// <param name="oldSCREEN_CD">Old Key #1</param>
        /// <param name="oldUSER_CD">Old Key #2</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, UserScreenPermissionDTO data, NZString oldSCREEN_CD, NZString oldUSER_CD)
        {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + UserScreenPermissionDTO.eColumns.SCREEN_CD + "=:SCREEN_CD");
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.USER_CD + "=:USER_CD");
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.FLG_VIEW + "=:FLG_VIEW");
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.FLG_ADD + "=:FLG_ADD");
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.FLG_CHG + "=:FLG_CHG");
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.FLG_DEL + "=:FLG_DEL");
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + UserScreenPermissionDTO.eColumns.SCREEN_CD + "=:oldSCREEN_CD");
            sb.AppendLine("  AND " + UserScreenPermissionDTO.eColumns.USER_CD + "=:oldUserScreenPermission");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("SCREEN_CD", DataType.VarChar, data.SCREEN_CD.Value);
            req.Parameters.Add("USER_CD", DataType.VarChar, data.USER_CD.Value);
            req.Parameters.Add("FLG_VIEW", DataType.Number, data.FLG_VIEW.Value);
            req.Parameters.Add("FLG_ADD", DataType.Number, data.FLG_ADD.Value);
            req.Parameters.Add("FLG_CHG", DataType.Number, data.FLG_CHG.Value);
            req.Parameters.Add("FLG_DEL", DataType.Number, data.FLG_DEL.Value);
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("oldSCREEN_CD", DataType.VarChar, oldSCREEN_CD.Value);
            req.Parameters.Add("oldUSER_CD", DataType.VarChar, oldUSER_CD.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="SCREEN_CD">Key #1</param>
        /// <param name="USER_CD">Key #2</param>
        /// <returns></returns>
        public int Delete(Database database, NZString SCREEN_CD, NZString USER_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(UserScreenPermissionDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + UserScreenPermissionDTO.eColumns.SCREEN_CD + "=:SCREEN_CD");
            sb.AppendLine("  AND " + UserScreenPermissionDTO.eColumns.USER_CD + "=:USER_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("SCREEN_CD", DataType.VarChar, SCREEN_CD.Value);
            req.Parameters.Add("USER_CD", DataType.VarChar, USER_CD.Value);
            #endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, NZString SCREEN_CD, NZString USER_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(UserScreenPermissionDTO));

            sb.AppendLine(" SELECT TOP 1 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + UserScreenPermissionDTO.eColumns.SCREEN_CD + "=:SCREEN_CD");
            sb.AppendLine("  AND " + UserScreenPermissionDTO.eColumns.USER_CD + "=:USER_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("SCREEN_CD", DataType.VarChar, SCREEN_CD.Value);
            req.Parameters.Add("USER_CD", DataType.VarChar, USER_CD.Value);
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
        public List<UserScreenPermissionDTO> LoadAll(Database database)
        {
            return LoadAll(database, true,
                UserScreenPermissionDTO.eColumns.SCREEN_CD
                , UserScreenPermissionDTO.eColumns.USER_CD
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<UserScreenPermissionDTO> LoadAll(Database database, bool ascending)
        {
            return LoadAll(database, ascending,
                UserScreenPermissionDTO.eColumns.SCREEN_CD
                , UserScreenPermissionDTO.eColumns.USER_CD
            );
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<UserScreenPermissionDTO> LoadAll(Database database, bool ascending, params UserScreenPermissionDTO.eColumns[] orderByColumns)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(UserScreenPermissionDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + UserScreenPermissionDTO.eColumns.SCREEN_CD);
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.USER_CD);
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.FLG_VIEW);
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.FLG_ADD);
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.FLG_CHG);
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.FLG_DEL);
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.UPD_MACHINE);
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

            return db.ExecuteForList<UserScreenPermissionDTO>(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="SCREEN_CD">Key #1</param>
        /// <param name="USER_CD">Key #2</param>
        /// <returns></returns>
        public UserScreenPermissionDTO LoadByPK(Database database, NZString SCREEN_CD, NZString USER_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(UserScreenPermissionDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + UserScreenPermissionDTO.eColumns.SCREEN_CD);
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.USER_CD);
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.FLG_VIEW);
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.FLG_ADD);
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.FLG_CHG);
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.FLG_DEL);
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + UserScreenPermissionDTO.eColumns.UPD_MACHINE);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + UserScreenPermissionDTO.eColumns.SCREEN_CD + "=:SCREEN_CD");
            sb.AppendLine("  AND " + UserScreenPermissionDTO.eColumns.USER_CD + "=:USER_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("SCREEN_CD", DataType.VarChar, SCREEN_CD.Value);
            req.Parameters.Add("USER_CD", DataType.VarChar, USER_CD.Value);
            #endregion

            List<UserScreenPermissionDTO> list = db.ExecuteForList<UserScreenPermissionDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        #endregion
    }
}

