/* Create by: Mr.Teerayut Sinlan
 * Create on: 2009-10-07
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
    internal partial class InventoryPeriodDAO 
    {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public InventoryPeriodDAO() { }

        public InventoryPeriodDAO(Database db)
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
        public int AddNewOrUpdate(Database database, InventoryPeriodDTO data)
        {
            Database db = UseDatabase(database);

            if (Exist(database, data.YEAR_MONTH))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, InventoryPeriodDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            sb.AppendLine("  " + InventoryPeriodDTO.eColumns.YEAR_MONTH);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.PERIOD_BEGIN_DATE);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.PERIOD_END_DATE);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.UPD_MACHINE);
            sb.AppendLine(") VALUES(");
            sb.AppendLine("   :YEAR_MONTH");
            sb.AppendLine("   ,:PERIOD_BEGIN_DATE");
            sb.AppendLine("   ,:PERIOD_END_DATE");
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
            req.Parameters.Add("YEAR_MONTH", DataType.NVarChar, data.YEAR_MONTH.Value);
            req.Parameters.Add("PERIOD_BEGIN_DATE", DataType.DateTime, data.PERIOD_BEGIN_DATE.Value);
            req.Parameters.Add("PERIOD_END_DATE", DataType.DateTime, data.PERIOD_END_DATE.Value);
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
        public int UpdateWithoutPK(Database database, InventoryPeriodDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + InventoryPeriodDTO.eColumns.PERIOD_BEGIN_DATE + "=:PERIOD_BEGIN_DATE");
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.PERIOD_END_DATE + "=:PERIOD_END_DATE");
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + InventoryPeriodDTO.eColumns.YEAR_MONTH + "=:YEAR_MONTH");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("YEAR_MONTH", DataType.NVarChar, data.YEAR_MONTH.Value);
            req.Parameters.Add("PERIOD_BEGIN_DATE", DataType.DateTime, data.PERIOD_BEGIN_DATE.Value);
            req.Parameters.Add("PERIOD_END_DATE", DataType.DateTime, data.PERIOD_END_DATE.Value);
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
        /// <param name="oldYEAR_MONTH">Old Key #1</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, InventoryPeriodDTO data, NZString oldYEAR_MONTH)
        {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + InventoryPeriodDTO.eColumns.YEAR_MONTH + "=:YEAR_MONTH");
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.PERIOD_BEGIN_DATE + "=:PERIOD_BEGIN_DATE");
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.PERIOD_END_DATE + "=:PERIOD_END_DATE");
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + InventoryPeriodDTO.eColumns.YEAR_MONTH + "=:oldYEAR_MONTH");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("YEAR_MONTH", DataType.NVarChar, data.YEAR_MONTH.Value);
            req.Parameters.Add("PERIOD_BEGIN_DATE", DataType.DateTime, data.PERIOD_BEGIN_DATE.Value);
            req.Parameters.Add("PERIOD_END_DATE", DataType.DateTime, data.PERIOD_END_DATE.Value);
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("oldYEAR_MONTH", DataType.NVarChar, oldYEAR_MONTH.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="YEAR_MONTH">Key #1</param>
        /// <returns></returns>
        public int Delete(Database database, NZString YEAR_MONTH)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InventoryPeriodDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + InventoryPeriodDTO.eColumns.YEAR_MONTH + "=:YEAR_MONTH");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("YEAR_MONTH", DataType.NVarChar, YEAR_MONTH.Value);
            #endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, NZString YEAR_MONTH)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InventoryPeriodDTO));

            sb.AppendLine(" SELECT TOP 1 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + InventoryPeriodDTO.eColumns.YEAR_MONTH + "=:YEAR_MONTH");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("YEAR_MONTH", DataType.NVarChar, YEAR_MONTH.Value);
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
        public List<InventoryPeriodDTO> LoadAll(Database database)
        {
            return LoadAll(database, true,
                InventoryPeriodDTO.eColumns.YEAR_MONTH
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<InventoryPeriodDTO> LoadAll(Database database, bool ascending)
        {
            return LoadAll(database, ascending,
                InventoryPeriodDTO.eColumns.YEAR_MONTH
            );
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<InventoryPeriodDTO> LoadAll(Database database, bool ascending, params InventoryPeriodDTO.eColumns[] orderByColumns)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InventoryPeriodDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + InventoryPeriodDTO.eColumns.YEAR_MONTH);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.PERIOD_BEGIN_DATE);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.PERIOD_END_DATE);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.UPD_MACHINE);
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

            return db.ExecuteForList<InventoryPeriodDTO>(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="YEAR_MONTH">Key #1</param>
        /// <returns></returns>
        public InventoryPeriodDTO LoadByPK(Database database, NZString YEAR_MONTH)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InventoryPeriodDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + InventoryPeriodDTO.eColumns.YEAR_MONTH);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.PERIOD_BEGIN_DATE);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.PERIOD_END_DATE);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.UPD_MACHINE);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + InventoryPeriodDTO.eColumns.YEAR_MONTH + "=:YEAR_MONTH");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("YEAR_MONTH", DataType.NVarChar, YEAR_MONTH.Value);
            #endregion

            List<InventoryPeriodDTO> list = db.ExecuteForList<InventoryPeriodDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        #endregion
    }
}

