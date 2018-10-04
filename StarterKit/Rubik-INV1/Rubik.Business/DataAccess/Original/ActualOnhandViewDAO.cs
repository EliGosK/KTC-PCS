/* Create by: Mr.Teerayut Sinlan
 * Create on: 2010-06-11
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
    /// <summary>
    /// THIS IS DAO FOR V_ACTUAL_ONHAND
    /// JUST USE FOR VIEW ONLY
    /// </summary>
    internal partial class ActualOnhandViewDAO
    {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public ActualOnhandViewDAO() { }

        public ActualOnhandViewDAO(Database db)
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
        public int AddNewOrUpdate(Database database, ActualOnhandViewDTO data)
        {
            Database db = UseDatabase(database);

            if (Exist(database, data.ITEM_CD, data.LOC_CD, data.LOT_NO))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, ActualOnhandViewDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            sb.AppendLine("  " + ActualOnhandViewDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + ActualOnhandViewDTO.eColumns.LOC_CD);
            sb.AppendLine("  ," + ActualOnhandViewDTO.eColumns.LOT_NO);
            sb.AppendLine("  ," + ActualOnhandViewDTO.eColumns.ONHAND_QTY);
            sb.AppendLine(") VALUES(");
            sb.AppendLine("   :ITEM_CD");
            sb.AppendLine("   ,:LOC_CD");
            sb.AppendLine("   ,:LOT_NO");
            sb.AppendLine("   ,:ONHAND_QTY");
            sb.AppendLine(" )");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("LOC_CD", DataType.NVarChar, data.LOC_CD.Value);
            req.Parameters.Add("LOT_NO", DataType.NVarChar, data.LOT_NO.Value);
            req.Parameters.Add("ONHAND_QTY", DataType.Number, data.ONHAND_QTY.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using primary key value on the given data variable
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data with primary key value.</param>
        /// <returns></returns>
        public int UpdateWithoutPK(Database database, ActualOnhandViewDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + ActualOnhandViewDTO.eColumns.ONHAND_QTY + "=:ONHAND_QTY");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ActualOnhandViewDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            sb.AppendLine("  AND " + ActualOnhandViewDTO.eColumns.LOC_CD + "=:LOC_CD");
            sb.AppendLine("  AND " + ActualOnhandViewDTO.eColumns.LOT_NO + "=:LOT_NO");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("LOC_CD", DataType.NVarChar, data.LOC_CD.Value);
            req.Parameters.Add("LOT_NO", DataType.NVarChar, data.LOT_NO.Value);
            req.Parameters.Add("ONHAND_QTY", DataType.Number, data.ONHAND_QTY.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using the table's primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data which to update.</param>
        /// <param name="oldITEM_CD">Old Key #1</param>
        /// <param name="oldLOC_CD">Old Key #2</param>
        /// <param name="oldLOT_NO">Old Key #3</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, ActualOnhandViewDTO data, NZString oldITEM_CD, NZString oldLOC_CD, NZString oldLOT_NO)
        {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + ActualOnhandViewDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            sb.AppendLine("  ," + ActualOnhandViewDTO.eColumns.LOC_CD + "=:LOC_CD");
            sb.AppendLine("  ," + ActualOnhandViewDTO.eColumns.LOT_NO + "=:LOT_NO");
            sb.AppendLine("  ," + ActualOnhandViewDTO.eColumns.ONHAND_QTY + "=:ONHAND_QTY");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ActualOnhandViewDTO.eColumns.ITEM_CD + "=:oldITEM_CD");
            sb.AppendLine("  AND " + ActualOnhandViewDTO.eColumns.LOC_CD + "=:oldActualOnhandView");
            sb.AppendLine("  AND " + ActualOnhandViewDTO.eColumns.LOT_NO + "=:oldActualOnhandView");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("LOC_CD", DataType.NVarChar, data.LOC_CD.Value);
            req.Parameters.Add("LOT_NO", DataType.NVarChar, data.LOT_NO.Value);
            req.Parameters.Add("ONHAND_QTY", DataType.Number, data.ONHAND_QTY.Value);
            req.Parameters.Add("oldITEM_CD", DataType.NVarChar, oldITEM_CD.Value);
            req.Parameters.Add("oldLOC_CD", DataType.NVarChar, oldLOC_CD.Value);
            req.Parameters.Add("oldLOT_NO", DataType.NVarChar, oldLOT_NO.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ITEM_CD">Key #1</param>
        /// <param name="LOC_CD">Key #2</param>
        /// <param name="LOT_NO">Key #3</param>
        /// <returns></returns>
        public int Delete(Database database, NZString ITEM_CD, NZString LOC_CD, NZString LOT_NO)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ActualOnhandViewDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ActualOnhandViewDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            sb.AppendLine("  AND " + ActualOnhandViewDTO.eColumns.LOC_CD + "=:LOC_CD");
            sb.AppendLine("  AND " + ActualOnhandViewDTO.eColumns.LOT_NO + "=:LOT_NO");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, ITEM_CD.Value);
            req.Parameters.Add("LOC_CD", DataType.NVarChar, LOC_CD.Value);
            req.Parameters.Add("LOT_NO", DataType.NVarChar, LOT_NO.Value);
            #endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, NZString ITEM_CD, NZString LOC_CD, NZString LOT_NO)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ActualOnhandViewDTO));

            sb.AppendLine(" SELECT TOP 1 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ActualOnhandViewDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            sb.AppendLine("  AND " + ActualOnhandViewDTO.eColumns.LOC_CD + "=:LOC_CD");
            sb.AppendLine("  AND " + ActualOnhandViewDTO.eColumns.LOT_NO + "=:LOT_NO");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, ITEM_CD.Value);
            req.Parameters.Add("LOC_CD", DataType.NVarChar, LOC_CD.Value);
            req.Parameters.Add("LOT_NO", DataType.NVarChar, LOT_NO.Value);
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
        public List<ActualOnhandViewDTO> LoadAll(Database database)
        {
            return LoadAll(database, true,
                ActualOnhandViewDTO.eColumns.ITEM_CD
                , ActualOnhandViewDTO.eColumns.LOC_CD
                , ActualOnhandViewDTO.eColumns.LOT_NO
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<ActualOnhandViewDTO> LoadAll(Database database, bool ascending)
        {
            return LoadAll(database, ascending,
                ActualOnhandViewDTO.eColumns.ITEM_CD
                , ActualOnhandViewDTO.eColumns.LOC_CD
                , ActualOnhandViewDTO.eColumns.LOT_NO
            );
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<ActualOnhandViewDTO> LoadAll(Database database, bool ascending, params ActualOnhandViewDTO.eColumns[] orderByColumns)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ActualOnhandViewDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + ActualOnhandViewDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + ActualOnhandViewDTO.eColumns.LOC_CD);
            sb.AppendLine("  ," + ActualOnhandViewDTO.eColumns.LOT_NO);
            sb.AppendLine("  ," + ActualOnhandViewDTO.eColumns.ONHAND_QTY);
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

            return db.ExecuteForList<ActualOnhandViewDTO>(req);
        }

        #endregion
    }
}

