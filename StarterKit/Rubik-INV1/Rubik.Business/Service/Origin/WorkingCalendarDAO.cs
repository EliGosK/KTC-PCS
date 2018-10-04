/* Create by: Mr.Teerayut Sinlan
 * Create on: 2554-05-30
 * Company: CSI Groups (Thailand)
 * Group: SI-EVO
 
 *** This generate source code was build for DAO on StarterKit system. ***/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using EVOFramework.Database;
using Rubik.DTO;
using Rubik.Data;

namespace Rubik.DAO
{
    internal partial class WorkingCalendarDAO
    {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
		public WorkingCalendarDAO() { }
			
        public WorkingCalendarDAO(Database db) {
            this.m_db = db;
        }
        #endregion

		#region Properties
        /// <summary>
        /// Get encapsulated database object.
        /// </summary>
        public Database CurrentDatabase {
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
        protected Database UseDatabase(Database specificDB) {
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
        public int AddNewOrUpdate(Database database, WorkingCalendarDTO data) {
			Database db = UseDatabase(database);
			
            if (Exist(database, data.PERIOD))
                return UpdateWithoutPK(db, data);
            
            return AddNew(db, data);
            
        }
		
        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, WorkingCalendarDTO data) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
			sb.AppendLine("  " + WorkingCalendarDTO.eColumns.CRT_BY);
			sb.AppendLine("  ," + WorkingCalendarDTO.eColumns.CRT_DATE);
			sb.AppendLine("  ," + WorkingCalendarDTO.eColumns.CRT_MACHINE);
			sb.AppendLine("  ," + WorkingCalendarDTO.eColumns.UPD_BY);
			sb.AppendLine("  ," + WorkingCalendarDTO.eColumns.UPD_DATE);
			sb.AppendLine("  ," + WorkingCalendarDTO.eColumns.UPD_MACHINE);
			sb.AppendLine("  ," + WorkingCalendarDTO.eColumns.IS_ACTIVE);
			sb.AppendLine("  ," + WorkingCalendarDTO.eColumns.PERIOD);
			sb.AppendLine("  ," + WorkingCalendarDTO.eColumns.CALENDAR_STRING);
            sb.AppendLine(") VALUES(");
			sb.AppendLine("   :CRT_BY");
			sb.AppendLine("   ,GETDATE()");
			sb.AppendLine("   ,:CRT_MACHINE");
			sb.AppendLine("   ,:UPD_BY");
			sb.AppendLine("   ,GETDATE()");
			sb.AppendLine("   ,:UPD_MACHINE");
			sb.AppendLine("   ,:IS_ACTIVE");
			sb.AppendLine("   ,:PERIOD");
			sb.AppendLine("   ,:CALENDAR_STRING");
            sb.AppendLine(" )");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
			#region Parameters
			req.Parameters.Add("CRT_BY", DataType.NVarChar, Convert.ToString(data.CRT_BY));
            req.Parameters.Add("CRT_MACHINE", DataType.NVarChar, Convert.ToString(data.CRT_MACHINE));
			req.Parameters.Add("UPD_BY", DataType.NVarChar, Convert.ToString(data.UPD_BY));
			req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, Convert.ToString(data.UPD_MACHINE));
			req.Parameters.Add("IS_ACTIVE", DataType.Default, Convert.ToBoolean(data.IS_ACTIVE));
			req.Parameters.Add("PERIOD", DataType.Default, Convert.ToDateTime(data.PERIOD));
			req.Parameters.Add("CALENDAR_STRING", DataType.NVarChar, Convert.ToString(data.CALENDAR_STRING));
			#endregion

            return db.ExecuteNonQuery(req);            
        }

        /// <summary>
        /// Update record by using primary key value on the given data variable
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data with primary key value.</param>
        /// <returns></returns>
        public int UpdateWithoutPK(Database database, WorkingCalendarDTO data)
        {		
			Database db = UseDatabase(database);
			
			StringBuilder sb = new StringBuilder();
			#region SQL Statement
			sb.AppendLine(" UPDATE " + data.TableName);
			sb.AppendLine(" SET ");
			sb.AppendLine("  " + WorkingCalendarDTO.eColumns.UPD_BY + "=:UPD_BY");
			sb.AppendLine("  ," + WorkingCalendarDTO.eColumns.UPD_DATE + "=GETDATE()");
			sb.AppendLine("  ," + WorkingCalendarDTO.eColumns.UPD_MACHINE +"=:UPD_MACHINE");
			sb.AppendLine("  ," + WorkingCalendarDTO.eColumns.IS_ACTIVE +"=:IS_ACTIVE");
			sb.AppendLine("  ," + WorkingCalendarDTO.eColumns.CALENDAR_STRING +"=:CALENDAR_STRING");
			sb.AppendLine(" WHERE ");
			sb.AppendLine("  " + WorkingCalendarDTO.eColumns.PERIOD + "=:PERIOD");
			#endregion
			
			DataRequest req = new DataRequest(sb.ToString());
			#region Parameters
			req.Parameters.Add("UPD_BY", DataType.NVarChar, Convert.ToString(data.UPD_BY));
			req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, Convert.ToDateTime(data.UPD_MACHINE));
			req.Parameters.Add("IS_ACTIVE", DataType.Default, Convert.ToBoolean(data.IS_ACTIVE));
			req.Parameters.Add("PERIOD", DataType.Default, Convert.ToDateTime(data.PERIOD));
			req.Parameters.Add("CALENDAR_STRING", DataType.NVarChar, Convert.ToString(data.CALENDAR_STRING));
			#endregion
			
            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using the table's primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data which to update.</param>
		/// <param name="oldPERIOD">Old Key #1</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, WorkingCalendarDTO data,  DateTime oldPERIOD) {
			
			Database db = UseDatabase(database);
			
			StringBuilder sb = new StringBuilder();
			#region SQL Statement
			sb.AppendLine(" UPDATE " + data.TableName);
			sb.AppendLine(" SET ");
			sb.AppendLine("  " + WorkingCalendarDTO.eColumns.UPD_BY + "=:UPD_BY");
			sb.AppendLine("  ," + WorkingCalendarDTO.eColumns.UPD_DATE + "=GETDATE()");
			sb.AppendLine("  ," + WorkingCalendarDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
			sb.AppendLine("  ," + WorkingCalendarDTO.eColumns.IS_ACTIVE + "=:IS_ACTIVE");
			sb.AppendLine("  ," + WorkingCalendarDTO.eColumns.PERIOD + "=:PERIOD");
			sb.AppendLine("  ," + WorkingCalendarDTO.eColumns.CALENDAR_STRING + "=:CALENDAR_STRING");
			sb.AppendLine(" WHERE ");
			sb.AppendLine("  " + WorkingCalendarDTO.eColumns.PERIOD + "=:oldPERIOD");
			#endregion
			
			DataRequest req = new DataRequest(sb.ToString());
			#region Parameters
			req.Parameters.Add("UPD_BY", DataType.NVarChar, Convert.ToString(data.UPD_BY));
			req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, Convert.ToString(data.UPD_MACHINE));
			req.Parameters.Add("IS_ACTIVE", DataType.Default, Convert.ToBoolean(data.IS_ACTIVE));
            req.Parameters.Add("PERIOD", DataType.Default, Convert.ToDateTime(data.PERIOD));
			req.Parameters.Add("CALENDAR_STRING", DataType.NVarChar, Convert.ToString(data.CALENDAR_STRING));
			req.Parameters.Add("oldPERIOD", DataType.Default, Convert.ToDateTime(oldPERIOD));
			#endregion
			
            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
		/// <param name="PERIOD">Key #1</param>
        /// <returns></returns>
        public int Delete(Database database, DateTime PERIOD) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
			
			string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(WorkingCalendarDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
			sb.AppendLine(" WHERE ");
			sb.AppendLine("  " + WorkingCalendarDTO.eColumns.PERIOD + "=:PERIOD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
			#region Parameters
			req.Parameters.Add("PERIOD", DataType.Default, PERIOD);
			#endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
		/// <summary>
		/// Check exists the specified key.
		/// </summary>
        public bool Exist(Database database, DateTime PERIOD) {
			Database db = UseDatabase(database);
			
			StringBuilder sb = new StringBuilder();
			#region SQL Statement
			string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(WorkingCalendarDTO));
			
			sb.AppendLine(" SELECT TOP 1 1 ");
			sb.AppendLine(" FROM " + tableName);
			sb.AppendLine(" WHERE ");
			sb.AppendLine("  " + WorkingCalendarDTO.eColumns.PERIOD + "=:PERIOD");
			#endregion
			
			DataRequest req = new DataRequest(sb.ToString());
			#region Parameters
			req.Parameters.Add("PERIOD", DataType.Default, PERIOD);
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
        public List<WorkingCalendarDTO> LoadAll(Database database) {
            return LoadAll(database, true, 
				WorkingCalendarDTO.eColumns.PERIOD
			);
        }

       /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<WorkingCalendarDTO> LoadAll(Database database, bool ascending) {
            return LoadAll(database, ascending,
				WorkingCalendarDTO.eColumns.PERIOD
			);
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<WorkingCalendarDTO> LoadAll(Database database, bool ascending, params WorkingCalendarDTO.eColumns[] orderByColumns) {
            Database db = UseDatabase(database);
			
			StringBuilder sb = new StringBuilder();
			#region SQL Statement
			string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(WorkingCalendarDTO));
			
			sb.AppendLine(" SELECT ");
			sb.AppendLine("  " + WorkingCalendarDTO.eColumns.CRT_BY);
			sb.AppendLine("  ," + WorkingCalendarDTO.eColumns.CRT_DATE);
			sb.AppendLine("  ," + WorkingCalendarDTO.eColumns.CRT_MACHINE);
			sb.AppendLine("  ," + WorkingCalendarDTO.eColumns.UPD_BY);
			sb.AppendLine("  ," + WorkingCalendarDTO.eColumns.UPD_DATE);
			sb.AppendLine("  ," + WorkingCalendarDTO.eColumns.UPD_MACHINE);
			sb.AppendLine("  ," + WorkingCalendarDTO.eColumns.IS_ACTIVE);
			sb.AppendLine("  ," + WorkingCalendarDTO.eColumns.PERIOD);
			sb.AppendLine("  ," + WorkingCalendarDTO.eColumns.CALENDAR_STRING);
			sb.AppendLine(" FROM " + tableName);
			
			if (orderByColumns != null && orderByColumns.Length > 0) {
				sb.AppendLine(" ORDER BY ");
				string sort = ascending ? "asc" : "desc";
				
				for (int i=0; i<orderByColumns.Length; i++) {
					if (i == 0)
						sb.AppendLine(String.Format("   {0} {1}", orderByColumns[i], sort));
					else
						sb.AppendLine(String.Format("   ,{0} {1}", orderByColumns[i], sort));
				}
			}
			#endregion
			
			DataRequest req = new DataRequest(sb.ToString());
			
            return db.ExecuteForList<WorkingCalendarDTO>(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
		/// <param name="PERIOD">Key #1</param>
        /// <returns></returns>
        public WorkingCalendarDTO LoadByPK(Database database, DateTime PERIOD) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(WorkingCalendarDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + WorkingCalendarDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + WorkingCalendarDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + WorkingCalendarDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + WorkingCalendarDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + WorkingCalendarDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + WorkingCalendarDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + WorkingCalendarDTO.eColumns.IS_ACTIVE);
            sb.AppendLine("  ," + WorkingCalendarDTO.eColumns.PERIOD);
            sb.AppendLine("  ," + WorkingCalendarDTO.eColumns.CALENDAR_STRING);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + WorkingCalendarDTO.eColumns.PERIOD + "=:PERIOD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("PERIOD", DataType.Default, PERIOD);
            #endregion

            List<WorkingCalendarDTO> list = db.ExecuteForList<WorkingCalendarDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        #endregion
    }
}

