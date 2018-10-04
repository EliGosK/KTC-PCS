/* Create by: Mr.Teerayut Sinlan
 * Create on: 2009-09-23
 * Company: CSI Groups (Thailand)
 * Group: SI-EVO
 
 *** This generate source code was build for DAO on StarterKit system. ***/
using System;
using System.Collections.Generic;
using System.Text;
using EVOFramework.Database;
using EVOFramework;
using SystemMaintenance.DTO;
using SystemMaintenance.DAO;

namespace SystemMaintenance.Oracle.DAO
{
    internal partial class ClassListDAO : IClassListDAO
    {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public ClassListDAO() { }

        public ClassListDAO(Database db)
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
        public int AddNewOrUpdate(Database database, ClassListDTO data)
        {
            Database db = UseDatabase(database);

            if (Exist(database, data.CLS_INFO_CD, data.CLS_CD))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, ClassListDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            sb.AppendLine("  " + ClassListDTO.eColumns.CLS_INFO_CD);
            sb.AppendLine("  ," + ClassListDTO.eColumns.CLS_CD);
            sb.AppendLine("  ," + ClassListDTO.eColumns.CLS_DESC);
            sb.AppendLine(") VALUES(");
            sb.AppendLine("   :CLS_INFO_CD");
            sb.AppendLine("   ,:CLS_CD");
            sb.AppendLine("   ,:CLS_DESC");
            sb.AppendLine(" )");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("CLS_INFO_CD", DataType.VarChar, data.CLS_INFO_CD.Value);
            req.Parameters.Add("CLS_CD", DataType.VarChar, data.CLS_CD.Value);
            req.Parameters.Add("CLS_DESC", DataType.VarChar, data.CLS_DESC.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using primary key value on the given data variable
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data with primary key value.</param>
        /// <returns></returns>
        public int UpdateWithoutPK(Database database, ClassListDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + ClassListDTO.eColumns.CLS_DESC + "=:CLS_DESC");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ClassListDTO.eColumns.CLS_INFO_CD + "=:CLS_INFO_CD");
            sb.AppendLine("  AND " + ClassListDTO.eColumns.CLS_CD + "=:CLS_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("CLS_INFO_CD", DataType.VarChar, data.CLS_INFO_CD.Value);
            req.Parameters.Add("CLS_CD", DataType.VarChar, data.CLS_CD.Value);
            req.Parameters.Add("CLS_DESC", DataType.VarChar, data.CLS_DESC.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using the table's primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data which to update.</param>
        /// <param name="oldCLS_INFO_CD">Old Key #1</param>
        /// <param name="oldCLS_CD">Old Key #2</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, ClassListDTO data, NZString oldCLS_INFO_CD, NZString oldCLS_CD)
        {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + ClassListDTO.eColumns.CLS_INFO_CD + "=:CLS_INFO_CD");
            sb.AppendLine("  ," + ClassListDTO.eColumns.CLS_CD + "=:CLS_CD");
            sb.AppendLine("  ," + ClassListDTO.eColumns.CLS_DESC + "=:CLS_DESC");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ClassListDTO.eColumns.CLS_INFO_CD + "=:oldCLS_INFO_CD");
            sb.AppendLine("  AND " + ClassListDTO.eColumns.CLS_CD + "=:oldClassList");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("CLS_INFO_CD", DataType.VarChar, data.CLS_INFO_CD.Value);
            req.Parameters.Add("CLS_CD", DataType.VarChar, data.CLS_CD.Value);
            req.Parameters.Add("CLS_DESC", DataType.VarChar, data.CLS_DESC.Value);
            req.Parameters.Add("oldCLS_INFO_CD", DataType.VarChar, oldCLS_INFO_CD.Value);
            req.Parameters.Add("oldCLS_CD", DataType.VarChar, oldCLS_CD.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="CLS_INFO_CD">Key #1</param>
        /// <param name="CLS_CD">Key #2</param>
        /// <returns></returns>
        public int Delete(Database database, NZString CLS_INFO_CD, NZString CLS_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ClassListDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ClassListDTO.eColumns.CLS_INFO_CD + "=:CLS_INFO_CD");
            sb.AppendLine("  AND " + ClassListDTO.eColumns.CLS_CD + "=:CLS_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("CLS_INFO_CD", DataType.VarChar, CLS_INFO_CD.Value);
            req.Parameters.Add("CLS_CD", DataType.VarChar, CLS_CD.Value);
            #endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, NZString CLS_INFO_CD, NZString CLS_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ClassListDTO));

            sb.AppendLine(" SELECT 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ROWNUM=1");
            sb.AppendLine("  AND " + ClassListDTO.eColumns.CLS_INFO_CD + "=:CLS_INFO_CD");
            sb.AppendLine("  AND " + ClassListDTO.eColumns.CLS_CD + "=:CLS_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("CLS_INFO_CD", DataType.VarChar, CLS_INFO_CD.Value);
            req.Parameters.Add("CLS_CD", DataType.VarChar, CLS_CD.Value);
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
        public List<ClassListDTO> LoadAll(Database database)
        {
            return LoadAll(database, true,
                ClassListDTO.eColumns.CLS_INFO_CD
                , ClassListDTO.eColumns.CLS_CD
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<ClassListDTO> LoadAll(Database database, bool ascending)
        {
            return LoadAll(database, ascending,
                ClassListDTO.eColumns.CLS_INFO_CD
                , ClassListDTO.eColumns.CLS_CD
            );
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<ClassListDTO> LoadAll(Database database, bool ascending, params ClassListDTO.eColumns[] orderByColumns)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ClassListDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + ClassListDTO.eColumns.CLS_INFO_CD);
            sb.AppendLine("  ," + ClassListDTO.eColumns.CLS_CD);
            sb.AppendLine("  ," + ClassListDTO.eColumns.CLS_DESC);
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

            return db.ExecuteForList<ClassListDTO>(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="CLS_INFO_CD">Key #1</param>
        /// <param name="CLS_CD">Key #2</param>
        /// <returns></returns>
        public ClassListDTO LoadByPK(Database database, NZString CLS_INFO_CD, NZString CLS_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ClassListDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + ClassListDTO.eColumns.CLS_INFO_CD);
            sb.AppendLine("  ," + ClassListDTO.eColumns.CLS_CD);
            sb.AppendLine("  ," + ClassListDTO.eColumns.CLS_DESC);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ClassListDTO.eColumns.CLS_INFO_CD + "=:CLS_INFO_CD");
            sb.AppendLine("  AND " + ClassListDTO.eColumns.CLS_CD + "=:CLS_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("CLS_INFO_CD", DataType.VarChar, CLS_INFO_CD.Value);
            req.Parameters.Add("CLS_CD", DataType.VarChar, CLS_CD.Value);
            #endregion

            List<ClassListDTO> list = db.ExecuteForList<ClassListDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        #endregion
    }
}

