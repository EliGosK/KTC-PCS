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
    internal partial class MenuSubLangDAO : IMenuSubLangDAO
    {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public MenuSubLangDAO() { }

        public MenuSubLangDAO(Database db)
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
        public int AddNewOrUpdate(Database database, MenuSubLangDTO data)
        {
            Database db = UseDatabase(database);

            if (Exist(database, data.LANG_CD, data.MENU_SUB_CD))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, MenuSubLangDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            sb.AppendLine("  " + MenuSubLangDTO.eColumns.LANG_CD);
            sb.AppendLine("  ," + MenuSubLangDTO.eColumns.MENU_SUB_CD);
            sb.AppendLine("  ," + MenuSubLangDTO.eColumns.MENU_SUB_DESC);
            sb.AppendLine("  ," + MenuSubLangDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + MenuSubLangDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + MenuSubLangDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + MenuSubLangDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + MenuSubLangDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + MenuSubLangDTO.eColumns.UPD_MACHINE);
            sb.AppendLine(") VALUES(");
            sb.AppendLine("   :LANG_CD");
            sb.AppendLine("   ,:MENU_SUB_CD");
            sb.AppendLine("   ,:MENU_SUB_DESC");
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
            req.Parameters.Add("LANG_CD", DataType.VarChar, data.LANG_CD.Value);
            req.Parameters.Add("MENU_SUB_CD", DataType.VarChar, data.MENU_SUB_CD.Value);
            req.Parameters.Add("MENU_SUB_DESC", DataType.NVarChar, data.MENU_SUB_DESC.Value);
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
        public int UpdateWithoutPK(Database database, MenuSubLangDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + MenuSubLangDTO.eColumns.MENU_SUB_DESC + "=:MENU_SUB_DESC");
            sb.AppendLine("  ," + MenuSubLangDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + MenuSubLangDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + MenuSubLangDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + MenuSubLangDTO.eColumns.LANG_CD + "=:LANG_CD");
            sb.AppendLine("  AND " + MenuSubLangDTO.eColumns.MENU_SUB_CD + "=:MENU_SUB_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("LANG_CD", DataType.VarChar, data.LANG_CD.Value);
            req.Parameters.Add("MENU_SUB_CD", DataType.VarChar, data.MENU_SUB_CD.Value);
            req.Parameters.Add("MENU_SUB_DESC", DataType.NVarChar, data.MENU_SUB_DESC.Value);
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
        /// <param name="oldLANG_CD">Old Key #1</param>
        /// <param name="oldMENU_SUB_CD">Old Key #2</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, MenuSubLangDTO data, NZString oldLANG_CD, NZString oldMENU_SUB_CD)
        {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + MenuSubLangDTO.eColumns.LANG_CD + "=:LANG_CD");
            sb.AppendLine("  ," + MenuSubLangDTO.eColumns.MENU_SUB_CD + "=:MENU_SUB_CD");
            sb.AppendLine("  ," + MenuSubLangDTO.eColumns.MENU_SUB_DESC + "=:MENU_SUB_DESC");
            sb.AppendLine("  ," + MenuSubLangDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + MenuSubLangDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + MenuSubLangDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + MenuSubLangDTO.eColumns.LANG_CD + "=:oldLANG_CD");
            sb.AppendLine("  AND " + MenuSubLangDTO.eColumns.MENU_SUB_CD + "=:oldMenuSubLang");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("LANG_CD", DataType.VarChar, data.LANG_CD.Value);
            req.Parameters.Add("MENU_SUB_CD", DataType.VarChar, data.MENU_SUB_CD.Value);
            req.Parameters.Add("MENU_SUB_DESC", DataType.NVarChar, data.MENU_SUB_DESC.Value);
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("oldLANG_CD", DataType.VarChar, oldLANG_CD.Value);
            req.Parameters.Add("oldMENU_SUB_CD", DataType.VarChar, oldMENU_SUB_CD.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="LANG_CD">Key #1</param>
        /// <param name="MENU_SUB_CD">Key #2</param>
        /// <returns></returns>
        public int Delete(Database database, NZString LANG_CD, NZString MENU_SUB_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(MenuSubLangDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + MenuSubLangDTO.eColumns.LANG_CD + "=:LANG_CD");
            sb.AppendLine("  AND " + MenuSubLangDTO.eColumns.MENU_SUB_CD + "=:MENU_SUB_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("LANG_CD", DataType.VarChar, LANG_CD.Value);
            req.Parameters.Add("MENU_SUB_CD", DataType.VarChar, MENU_SUB_CD.Value);
            #endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, NZString LANG_CD, NZString MENU_SUB_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(MenuSubLangDTO));

            sb.AppendLine(" SELECT TOP 1 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + MenuSubLangDTO.eColumns.LANG_CD + "=:LANG_CD");
            sb.AppendLine("  AND " + MenuSubLangDTO.eColumns.MENU_SUB_CD + "=:MENU_SUB_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("LANG_CD", DataType.VarChar, LANG_CD.Value);
            req.Parameters.Add("MENU_SUB_CD", DataType.VarChar, MENU_SUB_CD.Value);
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
        public List<MenuSubLangDTO> LoadAll(Database database)
        {
            return LoadAll(database, true,
                MenuSubLangDTO.eColumns.LANG_CD
                , MenuSubLangDTO.eColumns.MENU_SUB_CD
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<MenuSubLangDTO> LoadAll(Database database, bool ascending)
        {
            return LoadAll(database, ascending,
                MenuSubLangDTO.eColumns.LANG_CD
                , MenuSubLangDTO.eColumns.MENU_SUB_CD
            );
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<MenuSubLangDTO> LoadAll(Database database, bool ascending, params MenuSubLangDTO.eColumns[] orderByColumns)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(MenuSubLangDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + MenuSubLangDTO.eColumns.LANG_CD);
            sb.AppendLine("  ," + MenuSubLangDTO.eColumns.MENU_SUB_CD);
            sb.AppendLine("  ," + MenuSubLangDTO.eColumns.MENU_SUB_DESC);
            sb.AppendLine("  ," + MenuSubLangDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + MenuSubLangDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + MenuSubLangDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + MenuSubLangDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + MenuSubLangDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + MenuSubLangDTO.eColumns.UPD_MACHINE);
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

            return db.ExecuteForList<MenuSubLangDTO>(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="LANG_CD">Key #1</param>
        /// <param name="MENU_SUB_CD">Key #2</param>
        /// <returns></returns>
        public MenuSubLangDTO LoadByPK(Database database, NZString LANG_CD, NZString MENU_SUB_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(MenuSubLangDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + MenuSubLangDTO.eColumns.LANG_CD);
            sb.AppendLine("  ," + MenuSubLangDTO.eColumns.MENU_SUB_CD);
            sb.AppendLine("  ," + MenuSubLangDTO.eColumns.MENU_SUB_DESC);
            sb.AppendLine("  ," + MenuSubLangDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + MenuSubLangDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + MenuSubLangDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + MenuSubLangDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + MenuSubLangDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + MenuSubLangDTO.eColumns.UPD_MACHINE);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + MenuSubLangDTO.eColumns.LANG_CD + "=:LANG_CD");
            sb.AppendLine("  AND " + MenuSubLangDTO.eColumns.MENU_SUB_CD + "=:MENU_SUB_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("LANG_CD", DataType.VarChar, LANG_CD.Value);
            req.Parameters.Add("MENU_SUB_CD", DataType.VarChar, MENU_SUB_CD.Value);
            #endregion

            List<MenuSubLangDTO> list = db.ExecuteForList<MenuSubLangDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        #endregion
    }
}

