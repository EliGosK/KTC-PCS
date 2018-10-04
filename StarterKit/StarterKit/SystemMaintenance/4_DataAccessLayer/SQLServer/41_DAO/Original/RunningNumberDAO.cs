/* Create by: Mr.Teerayut Sinlan
 * Create on: 2009-10-01
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
    internal partial class RunningNumberDAO : IRunningNumberDAO
    {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public RunningNumberDAO() { }

        public RunningNumberDAO(Database db)
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
        public int AddNewOrUpdate(Database database, RunningNumberDTO data)
        {
            Database db = UseDatabase(database);

            if (Exist(database, data.ID_NAME, data.TB_NAME))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, RunningNumberDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            sb.AppendLine("  " + RunningNumberDTO.eColumns.ID_NAME);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.TB_NAME);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.DESCRIPTION);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.FORMAT);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.NEXTVALUE);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.LAST_RESET);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.RESET_FLAG_DAY);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.RESET_FLAG_MONTH);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.RESET_FLAG_YEAR);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.UPD_MACHINE);
            sb.AppendLine(") VALUES(");
            sb.AppendLine("   :ID_NAME");
            sb.AppendLine("   ,:TB_NAME");
            sb.AppendLine("   ,:DESCRIPTION");
            sb.AppendLine("   ,:FORMAT");
            sb.AppendLine("   ,:NEXTVALUE");
            sb.AppendLine("   ,:LAST_RESET");
            sb.AppendLine("   ,:RESET_FLAG_DAY");
            sb.AppendLine("   ,:RESET_FLAG_MONTH");
            sb.AppendLine("   ,:RESET_FLAG_YEAR");
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
            req.Parameters.Add("ID_NAME", DataType.VarChar, data.ID_NAME.Value);
            req.Parameters.Add("TB_NAME", DataType.VarChar, data.TB_NAME.Value);
            req.Parameters.Add("DESCRIPTION", DataType.VarChar, data.DESCRIPTION.Value);
            req.Parameters.Add("FORMAT", DataType.VarChar, data.FORMAT.Value);
            req.Parameters.Add("NEXTVALUE", DataType.Number, data.NEXTVALUE.Value);
            req.Parameters.Add("LAST_RESET", DataType.DateTime, data.LAST_RESET.Value);
            req.Parameters.Add("RESET_FLAG_DAY", DataType.Default, data.RESET_FLAG_DAY.Value);
            req.Parameters.Add("RESET_FLAG_MONTH", DataType.Default, data.RESET_FLAG_MONTH.Value);
            req.Parameters.Add("RESET_FLAG_YEAR", DataType.Default, data.RESET_FLAG_YEAR.Value);
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
        public int UpdateWithoutPK(Database database, RunningNumberDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + RunningNumberDTO.eColumns.DESCRIPTION + "=:DESCRIPTION");
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.FORMAT + "=:FORMAT");
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.NEXTVALUE + "=:NEXTVALUE");
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.LAST_RESET + "=:LAST_RESET");
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.RESET_FLAG_DAY + "=:RESET_FLAG_DAY");
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.RESET_FLAG_MONTH + "=:RESET_FLAG_MONTH");
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.RESET_FLAG_YEAR + "=:RESET_FLAG_YEAR");
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + RunningNumberDTO.eColumns.ID_NAME + "=:ID_NAME");
            sb.AppendLine("  AND " + RunningNumberDTO.eColumns.TB_NAME + "=:TB_NAME");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("ID_NAME", DataType.VarChar, data.ID_NAME.Value);
            req.Parameters.Add("TB_NAME", DataType.VarChar, data.TB_NAME.Value);
            req.Parameters.Add("DESCRIPTION", DataType.VarChar, data.DESCRIPTION.Value);
            req.Parameters.Add("FORMAT", DataType.VarChar, data.FORMAT.Value);
            req.Parameters.Add("NEXTVALUE", DataType.Number, data.NEXTVALUE.Value);
            req.Parameters.Add("LAST_RESET", DataType.DateTime, data.LAST_RESET.Value);
            req.Parameters.Add("RESET_FLAG_DAY", DataType.Default, data.RESET_FLAG_DAY.Value);
            req.Parameters.Add("RESET_FLAG_MONTH", DataType.Default, data.RESET_FLAG_MONTH.Value);
            req.Parameters.Add("RESET_FLAG_YEAR", DataType.Default, data.RESET_FLAG_YEAR.Value);
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
        /// <param name="oldID_NAME">Old Key #1</param>
        /// <param name="oldTB_NAME">Old Key #2</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, RunningNumberDTO data, NZString oldID_NAME, NZString oldTB_NAME)
        {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + RunningNumberDTO.eColumns.ID_NAME + "=:ID_NAME");
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.TB_NAME + "=:TB_NAME");
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.DESCRIPTION + "=:DESCRIPTION");
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.FORMAT + "=:FORMAT");
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.NEXTVALUE + "=:NEXTVALUE");
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.LAST_RESET + "=:LAST_RESET");
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.RESET_FLAG_DAY + "=:RESET_FLAG_DAY");
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.RESET_FLAG_MONTH + "=:RESET_FLAG_MONTH");
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.RESET_FLAG_YEAR + "=:RESET_FLAG_YEAR");
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + RunningNumberDTO.eColumns.ID_NAME + "=:oldID_NAME");
            sb.AppendLine("  AND " + RunningNumberDTO.eColumns.TB_NAME + "=:oldRunningNumber");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("ID_NAME", DataType.VarChar, data.ID_NAME.Value);
            req.Parameters.Add("TB_NAME", DataType.VarChar, data.TB_NAME.Value);
            req.Parameters.Add("DESCRIPTION", DataType.VarChar, data.DESCRIPTION.Value);
            req.Parameters.Add("FORMAT", DataType.VarChar, data.FORMAT.Value);
            req.Parameters.Add("NEXTVALUE", DataType.Number, data.NEXTVALUE.Value);
            req.Parameters.Add("LAST_RESET", DataType.DateTime, data.LAST_RESET.Value);
            req.Parameters.Add("RESET_FLAG_DAY", DataType.Default, data.RESET_FLAG_DAY.Value);
            req.Parameters.Add("RESET_FLAG_MONTH", DataType.Default, data.RESET_FLAG_MONTH.Value);
            req.Parameters.Add("RESET_FLAG_YEAR", DataType.Default, data.RESET_FLAG_YEAR.Value);
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("oldID_NAME", DataType.VarChar, oldID_NAME.Value);
            req.Parameters.Add("oldTB_NAME", DataType.VarChar, oldTB_NAME.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ID_NAME">Key #1</param>
        /// <param name="TB_NAME">Key #2</param>
        /// <returns></returns>
        public int Delete(Database database, NZString ID_NAME, NZString TB_NAME)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(RunningNumberDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + RunningNumberDTO.eColumns.ID_NAME + "=:ID_NAME");
            sb.AppendLine("  AND " + RunningNumberDTO.eColumns.TB_NAME + "=:TB_NAME");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("ID_NAME", DataType.VarChar, ID_NAME.Value);
            req.Parameters.Add("TB_NAME", DataType.VarChar, TB_NAME.Value);
            #endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, NZString ID_NAME, NZString TB_NAME)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(RunningNumberDTO));

            sb.AppendLine(" SELECT TOP 1 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + RunningNumberDTO.eColumns.ID_NAME + "=:ID_NAME");
            sb.AppendLine("  AND " + RunningNumberDTO.eColumns.TB_NAME + "=:TB_NAME");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("ID_NAME", DataType.VarChar, ID_NAME.Value);
            req.Parameters.Add("TB_NAME", DataType.VarChar, TB_NAME.Value);
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
        public List<RunningNumberDTO> LoadAll(Database database)
        {
            return LoadAll(database, true,
                RunningNumberDTO.eColumns.ID_NAME
                , RunningNumberDTO.eColumns.TB_NAME
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<RunningNumberDTO> LoadAll(Database database, bool ascending)
        {
            return LoadAll(database, ascending,
                RunningNumberDTO.eColumns.ID_NAME
                , RunningNumberDTO.eColumns.TB_NAME
            );
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<RunningNumberDTO> LoadAll(Database database, bool ascending, params RunningNumberDTO.eColumns[] orderByColumns)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(RunningNumberDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + RunningNumberDTO.eColumns.ID_NAME);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.TB_NAME);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.DESCRIPTION);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.FORMAT);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.NEXTVALUE);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.LAST_RESET);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.RESET_FLAG_DAY);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.RESET_FLAG_MONTH);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.RESET_FLAG_YEAR);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.UPD_MACHINE);
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

            return db.ExecuteForList<RunningNumberDTO>(req);
        }

        
        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ID_NAME">Key #1</param>
        /// <param name="TB_NAME">Key #2</param>
        /// <returns></returns>
        public RunningNumberDTO LoadByPK(Database database, NZString ID_NAME, NZString TB_NAME)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(RunningNumberDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + RunningNumberDTO.eColumns.ID_NAME);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.TB_NAME);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.DESCRIPTION);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.FORMAT);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.NEXTVALUE);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.LAST_RESET);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.RESET_FLAG_DAY);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.RESET_FLAG_MONTH);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.RESET_FLAG_YEAR);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.UPD_MACHINE);
            sb.AppendLine(" FROM " + tableName + " WITH (UPDLOCK) ");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + RunningNumberDTO.eColumns.ID_NAME + "=:ID_NAME");
            sb.AppendLine("  AND " + RunningNumberDTO.eColumns.TB_NAME + "=:TB_NAME");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("ID_NAME", DataType.VarChar, ID_NAME.Value);
            req.Parameters.Add("TB_NAME", DataType.VarChar, TB_NAME.Value);
            #endregion

            List<RunningNumberDTO> list = db.ExecuteForList<RunningNumberDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        #endregion
    }
}

