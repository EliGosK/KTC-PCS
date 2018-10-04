/* Create by: Mr.Teerayut Sinlan
 * Create on: 2009-10-09
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
    internal partial class ItemImageDAO
    {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public ItemImageDAO() { }

        public ItemImageDAO(Database db)
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
        public int AddNewOrUpdate(Database database, ItemImageDTO data)
        {
            Database db = UseDatabase(database);

            if (Exist(database, data.ITEM_CD))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, ItemImageDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            sb.AppendLine("  " + ItemImageDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + ItemImageDTO.eColumns.IMAGE);
            sb.AppendLine(") VALUES(");
            sb.AppendLine("   :ITEM_CD");
            sb.AppendLine("   ,:IMAGE");
            sb.AppendLine(" )");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("IMAGE", DataType.Default, data.IMAGE.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using primary key value on the given data variable
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data with primary key value.</param>
        /// <returns></returns>
        public int UpdateWithoutPK(Database database, ItemImageDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + ItemImageDTO.eColumns.IMAGE + "=:IMAGE");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ItemImageDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("IMAGE", DataType.Default, data.IMAGE.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using the table's primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data which to update.</param>
        /// <param name="oldITEM_CD">Old Key #1</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, ItemImageDTO data, NZString oldITEM_CD)
        {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + ItemImageDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            sb.AppendLine("  ," + ItemImageDTO.eColumns.IMAGE + "=:IMAGE");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ItemImageDTO.eColumns.ITEM_CD + "=:oldITEM_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("IMAGE", DataType.Default, data.IMAGE.Value);
            req.Parameters.Add("oldITEM_CD", DataType.NVarChar, oldITEM_CD.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ITEM_CD">Key #1</param>
        /// <returns></returns>
        public int Delete(Database database, NZString ITEM_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ItemImageDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ItemImageDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, ITEM_CD.Value);
            #endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, NZString ITEM_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ItemImageDTO));

            sb.AppendLine(" SELECT TOP 1 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ItemImageDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, ITEM_CD.Value);
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
        public List<ItemImageDTO> LoadAll(Database database)
        {
            return LoadAll(database, true,
                ItemImageDTO.eColumns.ITEM_CD
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<ItemImageDTO> LoadAll(Database database, bool ascending)
        {
            return LoadAll(database, ascending,
                ItemImageDTO.eColumns.ITEM_CD
            );
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<ItemImageDTO> LoadAll(Database database, bool ascending, params ItemImageDTO.eColumns[] orderByColumns)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ItemImageDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + ItemImageDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + ItemImageDTO.eColumns.IMAGE);
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

            return db.ExecuteForList<ItemImageDTO>(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ITEM_CD">Key #1</param>
        /// <returns></returns>
        public ItemImageDTO LoadByPK(Database database, NZString ITEM_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ItemImageDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + ItemImageDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + ItemImageDTO.eColumns.IMAGE);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ItemImageDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, ITEM_CD.Value);
            #endregion

            List<ItemImageDTO> list = db.ExecuteForList<ItemImageDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        #endregion
    }
}

