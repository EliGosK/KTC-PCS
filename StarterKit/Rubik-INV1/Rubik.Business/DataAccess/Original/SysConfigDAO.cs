/* Create by: Mr.Teerayut Sinlan
 * Create on: 2553-07-23
 * Company: CSI Groups (Thailand)
 * Group: SI-EVO
 
 *** This generate source code was build for DAO on StarterKit system. ***/
using System;
using System.Collections.Generic;
using System.Text;
using Rubik.DTO;
using EVOFramework.Database;
using EVOFramework;
using Rubik.DAO;

namespace Rubik.DAO
{
    public partial class SysConfigDAO
    {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public SysConfigDAO() { }

        public SysConfigDAO(Database db)
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
        public int AddNewOrUpdate(Database database, SysConfigDTO data)
        {
            Database db = UseDatabase(database);

            if (Exist(database, data.SYS_GROUP_ID, data.SYS_KEY))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, SysConfigDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            sb.AppendLine("  " + SysConfigDTO.eColumns.SYS_GROUP_ID);
            sb.AppendLine("  ," + SysConfigDTO.eColumns.SYS_KEY);
            sb.AppendLine("  ," + SysConfigDTO.eColumns.CHAR_DATA);
            sb.AppendLine(") VALUES(");
            sb.AppendLine("   :SYS_GROUP_ID");
            sb.AppendLine("   ,:SYS_KEY");
            sb.AppendLine("   ,:CHAR_DATA");
            sb.AppendLine(" )");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("SYS_GROUP_ID", DataType.VarChar, data.SYS_GROUP_ID.Value);
            req.Parameters.Add("SYS_KEY", DataType.VarChar, data.SYS_KEY.Value);
            req.Parameters.Add("CHAR_DATA", DataType.VarChar, data.CHAR_DATA.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using primary key value on the given data variable
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data with primary key value.</param>
        /// <returns></returns>
        public int UpdateWithoutPK(Database database, SysConfigDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + SysConfigDTO.eColumns.CHAR_DATA + "=:CHAR_DATA");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + SysConfigDTO.eColumns.SYS_GROUP_ID + "=:SYS_GROUP_ID");
            sb.AppendLine("  AND " + SysConfigDTO.eColumns.SYS_KEY + "=:SYS_KEY");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("SYS_GROUP_ID", DataType.VarChar, data.SYS_GROUP_ID.Value);
            req.Parameters.Add("SYS_KEY", DataType.VarChar, data.SYS_KEY.Value);
            req.Parameters.Add("CHAR_DATA", DataType.VarChar, data.CHAR_DATA.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using the table's primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data which to update.</param>
        /// <param name="oldSYS_GROUP_ID">Old Key #1</param>
        /// <param name="oldSYS_KEY">Old Key #2</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, SysConfigDTO data, NZString oldSYS_GROUP_ID, NZString oldSYS_KEY)
        {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + SysConfigDTO.eColumns.SYS_GROUP_ID + "=:SYS_GROUP_ID");
            sb.AppendLine("  ," + SysConfigDTO.eColumns.SYS_KEY + "=:SYS_KEY");
            sb.AppendLine("  ," + SysConfigDTO.eColumns.CHAR_DATA + "=:CHAR_DATA");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + SysConfigDTO.eColumns.SYS_GROUP_ID + "=:oldSYS_GROUP_ID");
            sb.AppendLine("  AND " + SysConfigDTO.eColumns.SYS_KEY + "=:oldSysConfig");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("SYS_GROUP_ID", DataType.VarChar, data.SYS_GROUP_ID.Value);
            req.Parameters.Add("SYS_KEY", DataType.VarChar, data.SYS_KEY.Value);
            req.Parameters.Add("CHAR_DATA", DataType.VarChar, data.CHAR_DATA.Value);
            req.Parameters.Add("oldSYS_GROUP_ID", DataType.VarChar, oldSYS_GROUP_ID.Value);
            req.Parameters.Add("oldSYS_KEY", DataType.VarChar, oldSYS_KEY.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="SYS_GROUP_ID">Key #1</param>
        /// <param name="SYS_KEY">Key #2</param>
        /// <returns></returns>
        public int Delete(Database database, NZString SYS_GROUP_ID, NZString SYS_KEY)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(SysConfigDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + SysConfigDTO.eColumns.SYS_GROUP_ID + "=:SYS_GROUP_ID");
            sb.AppendLine("  AND " + SysConfigDTO.eColumns.SYS_KEY + "=:SYS_KEY");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("SYS_GROUP_ID", DataType.VarChar, SYS_GROUP_ID.Value);
            req.Parameters.Add("SYS_KEY", DataType.VarChar, SYS_KEY.Value);
            #endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, NZString SYS_GROUP_ID, NZString SYS_KEY)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(SysConfigDTO));

            sb.AppendLine(" SELECT TOP 1 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + SysConfigDTO.eColumns.SYS_GROUP_ID + "=:SYS_GROUP_ID");
            sb.AppendLine("  AND " + SysConfigDTO.eColumns.SYS_KEY + "=:SYS_KEY");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("SYS_GROUP_ID", DataType.VarChar, SYS_GROUP_ID.Value);
            req.Parameters.Add("SYS_KEY", DataType.VarChar, SYS_KEY.Value);
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
        public List<SysConfigDTO> LoadAll(Database database)
        {
            return LoadAll(database, true,
                SysConfigDTO.eColumns.SYS_GROUP_ID
                , SysConfigDTO.eColumns.SYS_KEY
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<SysConfigDTO> LoadAll(Database database, bool ascending)
        {
            return LoadAll(database, ascending,
                SysConfigDTO.eColumns.SYS_GROUP_ID
                , SysConfigDTO.eColumns.SYS_KEY
            );
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<SysConfigDTO> LoadAll(Database database, bool ascending, params SysConfigDTO.eColumns[] orderByColumns)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(SysConfigDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + SysConfigDTO.eColumns.SYS_GROUP_ID);
            sb.AppendLine("  ," + SysConfigDTO.eColumns.SYS_KEY);
            sb.AppendLine("  ," + SysConfigDTO.eColumns.CHAR_DATA);
            sb.AppendLine("  ," + SysConfigDTO.eColumns.EDIT_FLAG);
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

            return db.ExecuteForList<SysConfigDTO>(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="SYS_GROUP_ID">Key #1</param>
        /// <param name="SYS_KEY">Key #2</param>
        /// <returns></returns>
        public SysConfigDTO LoadByPK(Database database, NZString SYS_GROUP_ID, NZString SYS_KEY)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(SysConfigDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + SysConfigDTO.eColumns.SYS_GROUP_ID);
            sb.AppendLine("  ," + SysConfigDTO.eColumns.SYS_KEY);
            sb.AppendLine("  ," + SysConfigDTO.eColumns.CHAR_DATA);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + SysConfigDTO.eColumns.SYS_GROUP_ID + "=:SYS_GROUP_ID");
            sb.AppendLine("  AND " + SysConfigDTO.eColumns.SYS_KEY + "=:SYS_KEY");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("SYS_GROUP_ID", DataType.VarChar, SYS_GROUP_ID.Value);
            req.Parameters.Add("SYS_KEY", DataType.VarChar, SYS_KEY.Value);
            #endregion

            List<SysConfigDTO> list = db.ExecuteForList<SysConfigDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        #endregion
    }
}

