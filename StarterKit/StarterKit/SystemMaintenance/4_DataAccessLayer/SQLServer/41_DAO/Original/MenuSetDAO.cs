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
    internal partial class MenuSetDAO : IMenuSetDAO
    {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public MenuSetDAO() { }

        public MenuSetDAO(Database db)
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
        public int AddNewOrUpdate(Database database, MenuSetDTO data)
        {
            Database db = UseDatabase(database);

            if (Exist(database, data.MENU_SET_CD))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, MenuSetDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            sb.AppendLine("  " + MenuSetDTO.eColumns.MENU_SET_CD);
            sb.AppendLine("  ," + MenuSetDTO.eColumns.MENU_SET_NAME);
            sb.AppendLine("  ," + MenuSetDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + MenuSetDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + MenuSetDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + MenuSetDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + MenuSetDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + MenuSetDTO.eColumns.UPD_MACHINE);
            sb.AppendLine(") VALUES(");
            sb.AppendLine("   :MENU_SET_CD");
            sb.AppendLine("   ,:MENU_SET_NAME");
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
            req.Parameters.Add("MENU_SET_CD", DataType.VarChar, data.MENU_SET_CD.Value);
            req.Parameters.Add("MENU_SET_NAME", DataType.VarChar, data.MENU_SET_NAME.Value);
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
        public int UpdateWithoutPK(Database database, MenuSetDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + MenuSetDTO.eColumns.MENU_SET_NAME + "=:MENU_SET_NAME");
            sb.AppendLine("  ," + MenuSetDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + MenuSetDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + MenuSetDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + MenuSetDTO.eColumns.MENU_SET_CD + "=:MENU_SET_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("MENU_SET_CD", DataType.VarChar, data.MENU_SET_CD.Value);
            req.Parameters.Add("MENU_SET_NAME", DataType.VarChar, data.MENU_SET_NAME.Value);
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
        /// <param name="oldMENU_SET_CD">Old Key #1</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, MenuSetDTO data, NZString oldMENU_SET_CD)
        {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + MenuSetDTO.eColumns.MENU_SET_CD + "=:MENU_SET_CD");
            sb.AppendLine("  ," + MenuSetDTO.eColumns.MENU_SET_NAME + "=:MENU_SET_NAME");
            sb.AppendLine("  ," + MenuSetDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + MenuSetDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + MenuSetDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + MenuSetDTO.eColumns.MENU_SET_CD + "=:oldMENU_SET_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("MENU_SET_CD", DataType.VarChar, data.MENU_SET_CD.Value);
            req.Parameters.Add("MENU_SET_NAME", DataType.VarChar, data.MENU_SET_NAME.Value);
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("oldMENU_SET_CD", DataType.VarChar, oldMENU_SET_CD.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="MENU_SET_CD">Key #1</param>
        /// <returns></returns>
        public int Delete(Database database, NZString MENU_SET_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(MenuSetDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + MenuSetDTO.eColumns.MENU_SET_CD + "=:MENU_SET_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("MENU_SET_CD", DataType.VarChar, MENU_SET_CD.Value);
            #endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, NZString MENU_SET_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(MenuSetDTO));

            sb.AppendLine(" SELECT TOP 1 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + MenuSetDTO.eColumns.MENU_SET_CD + "=:MENU_SET_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("MENU_SET_CD", DataType.VarChar, MENU_SET_CD.Value);
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
        public List<MenuSetDTO> LoadAll(Database database)
        {
            return LoadAll(database, true,
                MenuSetDTO.eColumns.MENU_SET_CD
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<MenuSetDTO> LoadAll(Database database, bool ascending)
        {
            return LoadAll(database, ascending,
                MenuSetDTO.eColumns.MENU_SET_CD
            );
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<MenuSetDTO> LoadAll(Database database, bool ascending, params MenuSetDTO.eColumns[] orderByColumns)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(MenuSetDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + MenuSetDTO.eColumns.MENU_SET_CD);
            sb.AppendLine("  ," + MenuSetDTO.eColumns.MENU_SET_NAME);
            sb.AppendLine("  ," + MenuSetDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + MenuSetDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + MenuSetDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + MenuSetDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + MenuSetDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + MenuSetDTO.eColumns.UPD_MACHINE);
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

            return db.ExecuteForList<MenuSetDTO>(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="MENU_SET_CD">Key #1</param>
        /// <returns></returns>
        public MenuSetDTO LoadByPK(Database database, NZString MENU_SET_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(MenuSetDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + MenuSetDTO.eColumns.MENU_SET_CD);
            sb.AppendLine("  ," + MenuSetDTO.eColumns.MENU_SET_NAME);
            sb.AppendLine("  ," + MenuSetDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + MenuSetDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + MenuSetDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + MenuSetDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + MenuSetDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + MenuSetDTO.eColumns.UPD_MACHINE);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + MenuSetDTO.eColumns.MENU_SET_CD + "=:MENU_SET_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("MENU_SET_CD", DataType.VarChar, MENU_SET_CD.Value);
            #endregion

            List<MenuSetDTO> list = db.ExecuteForList<MenuSetDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        #endregion
    }
}

