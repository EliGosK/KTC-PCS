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

namespace SystemMaintenance.Oracle.DAO
{
    internal partial class ScreenDetailLangDAO : IScreenDetailLangDAO
    {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public ScreenDetailLangDAO() { }

        public ScreenDetailLangDAO(Database db)
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
        public int AddNewOrUpdate(Database database, ScreenDetailLangDTO data)
        {
            Database db = UseDatabase(database);

            if (Exist(database, data.CONTROL_CD, data.LANG_CD, data.SCREEN_CD))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, ScreenDetailLangDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            sb.AppendLine("  " + ScreenDetailLangDTO.eColumns.CONTROL_CD);
            sb.AppendLine("  ," + ScreenDetailLangDTO.eColumns.LANG_CD);
            sb.AppendLine("  ," + ScreenDetailLangDTO.eColumns.SCREEN_CD);
            sb.AppendLine("  ," + ScreenDetailLangDTO.eColumns.CONTROL_CAPTION);
            sb.AppendLine("  ," + ScreenDetailLangDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + ScreenDetailLangDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + ScreenDetailLangDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + ScreenDetailLangDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + ScreenDetailLangDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + ScreenDetailLangDTO.eColumns.UPD_MACHINE);
            sb.AppendLine(") VALUES(");
            sb.AppendLine("   :CONTROL_CD");
            sb.AppendLine("   ,:LANG_CD");
            sb.AppendLine("   ,:SCREEN_CD");
            sb.AppendLine("   ,:CONTROL_CAPTION");
            sb.AppendLine("   ,:CRT_BY");
            sb.AppendLine("   ,SYSDATE");
            sb.AppendLine("   ,:CRT_MACHINE");
            sb.AppendLine("   ,:UPD_BY");
            sb.AppendLine("   ,SYSDATE");
            sb.AppendLine("   ,:UPD_MACHINE");
            sb.AppendLine(" )");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("CONTROL_CD", DataType.VarChar, data.CONTROL_CD.Value);
            req.Parameters.Add("LANG_CD", DataType.VarChar, data.LANG_CD.Value);
            req.Parameters.Add("SCREEN_CD", DataType.VarChar, data.SCREEN_CD.Value);
            req.Parameters.Add("CONTROL_CAPTION", DataType.NVarChar, data.CONTROL_CAPTION.Value);
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
        public int UpdateWithoutPK(Database database, ScreenDetailLangDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + ScreenDetailLangDTO.eColumns.CONTROL_CAPTION + "=:CONTROL_CAPTION");
            sb.AppendLine("  ," + ScreenDetailLangDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + ScreenDetailLangDTO.eColumns.UPD_DATE + "=SYSDATE");
            sb.AppendLine("  ," + ScreenDetailLangDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ScreenDetailLangDTO.eColumns.CONTROL_CD + "=:CONTROL_CD");
            sb.AppendLine("  AND " + ScreenDetailLangDTO.eColumns.LANG_CD + "=:LANG_CD");
            sb.AppendLine("  AND " + ScreenDetailLangDTO.eColumns.SCREEN_CD + "=:SCREEN_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("CONTROL_CD", DataType.VarChar, data.CONTROL_CD.Value);
            req.Parameters.Add("LANG_CD", DataType.VarChar, data.LANG_CD.Value);
            req.Parameters.Add("SCREEN_CD", DataType.VarChar, data.SCREEN_CD.Value);
            req.Parameters.Add("CONTROL_CAPTION", DataType.NVarChar, data.CONTROL_CAPTION.Value);
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
        /// <param name="oldCONTROL_CD">Old Key #1</param>
        /// <param name="oldLANG_CD">Old Key #2</param>
        /// <param name="oldSCREEN_CD">Old Key #3</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, ScreenDetailLangDTO data, NZString oldCONTROL_CD, NZString oldLANG_CD, NZString oldSCREEN_CD)
        {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + ScreenDetailLangDTO.eColumns.CONTROL_CD + "=:CONTROL_CD");
            sb.AppendLine("  ," + ScreenDetailLangDTO.eColumns.LANG_CD + "=:LANG_CD");
            sb.AppendLine("  ," + ScreenDetailLangDTO.eColumns.SCREEN_CD + "=:SCREEN_CD");
            sb.AppendLine("  ," + ScreenDetailLangDTO.eColumns.CONTROL_CAPTION + "=:CONTROL_CAPTION");
            sb.AppendLine("  ," + ScreenDetailLangDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + ScreenDetailLangDTO.eColumns.UPD_DATE + "=SYSDATE");
            sb.AppendLine("  ," + ScreenDetailLangDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ScreenDetailLangDTO.eColumns.CONTROL_CD + "=:oldCONTROL_CD");
            sb.AppendLine("  AND " + ScreenDetailLangDTO.eColumns.LANG_CD + "=:oldScreenDetailLang");
            sb.AppendLine("  AND " + ScreenDetailLangDTO.eColumns.SCREEN_CD + "=:oldScreenDetailLang");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("CONTROL_CD", DataType.VarChar, data.CONTROL_CD.Value);
            req.Parameters.Add("LANG_CD", DataType.VarChar, data.LANG_CD.Value);
            req.Parameters.Add("SCREEN_CD", DataType.VarChar, data.SCREEN_CD.Value);
            req.Parameters.Add("CONTROL_CAPTION", DataType.NVarChar, data.CONTROL_CAPTION.Value);
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("oldCONTROL_CD", DataType.VarChar, oldCONTROL_CD.Value);
            req.Parameters.Add("oldLANG_CD", DataType.VarChar, oldLANG_CD.Value);
            req.Parameters.Add("oldSCREEN_CD", DataType.VarChar, oldSCREEN_CD.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="CONTROL_CD">Key #1</param>
        /// <param name="LANG_CD">Key #2</param>
        /// <param name="SCREEN_CD">Key #3</param>
        /// <returns></returns>
        public int Delete(Database database, NZString CONTROL_CD, NZString LANG_CD, NZString SCREEN_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ScreenDetailLangDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ScreenDetailLangDTO.eColumns.CONTROL_CD + "=:CONTROL_CD");
            sb.AppendLine("  AND " + ScreenDetailLangDTO.eColumns.LANG_CD + "=:LANG_CD");
            sb.AppendLine("  AND " + ScreenDetailLangDTO.eColumns.SCREEN_CD + "=:SCREEN_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("CONTROL_CD", DataType.VarChar, CONTROL_CD.Value);
            req.Parameters.Add("LANG_CD", DataType.VarChar, LANG_CD.Value);
            req.Parameters.Add("SCREEN_CD", DataType.VarChar, SCREEN_CD.Value);
            #endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, NZString CONTROL_CD, NZString LANG_CD, NZString SCREEN_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ScreenDetailLangDTO));

            sb.AppendLine(" SELECT 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ROWNUM=1");
            sb.AppendLine("  AND " + ScreenDetailLangDTO.eColumns.CONTROL_CD + "=:CONTROL_CD");
            sb.AppendLine("  AND " + ScreenDetailLangDTO.eColumns.LANG_CD + "=:LANG_CD");
            sb.AppendLine("  AND " + ScreenDetailLangDTO.eColumns.SCREEN_CD + "=:SCREEN_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("CONTROL_CD", DataType.VarChar, CONTROL_CD.Value);
            req.Parameters.Add("LANG_CD", DataType.VarChar, LANG_CD.Value);
            req.Parameters.Add("SCREEN_CD", DataType.VarChar, SCREEN_CD.Value);
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
        public List<ScreenDetailLangDTO> LoadAll(Database database)
        {
            return LoadAll(database, true,
                ScreenDetailLangDTO.eColumns.CONTROL_CD
                , ScreenDetailLangDTO.eColumns.LANG_CD
                , ScreenDetailLangDTO.eColumns.SCREEN_CD
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<ScreenDetailLangDTO> LoadAll(Database database, bool ascending)
        {
            return LoadAll(database, ascending,
                ScreenDetailLangDTO.eColumns.CONTROL_CD
                , ScreenDetailLangDTO.eColumns.LANG_CD
                , ScreenDetailLangDTO.eColumns.SCREEN_CD
            );
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<ScreenDetailLangDTO> LoadAll(Database database, bool ascending, params ScreenDetailLangDTO.eColumns[] orderByColumns)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ScreenDetailLangDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + ScreenDetailLangDTO.eColumns.CONTROL_CD);
            sb.AppendLine("  ," + ScreenDetailLangDTO.eColumns.LANG_CD);
            sb.AppendLine("  ," + ScreenDetailLangDTO.eColumns.SCREEN_CD);
            sb.AppendLine("  ," + ScreenDetailLangDTO.eColumns.CONTROL_CAPTION);
            sb.AppendLine("  ," + ScreenDetailLangDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + ScreenDetailLangDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + ScreenDetailLangDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + ScreenDetailLangDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + ScreenDetailLangDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + ScreenDetailLangDTO.eColumns.UPD_MACHINE);
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

            return db.ExecuteForList<ScreenDetailLangDTO>(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="CONTROL_CD">Key #1</param>
        /// <param name="LANG_CD">Key #2</param>
        /// <param name="SCREEN_CD">Key #3</param>
        /// <returns></returns>
        public ScreenDetailLangDTO LoadByPK(Database database, NZString CONTROL_CD, NZString LANG_CD, NZString SCREEN_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ScreenDetailLangDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + ScreenDetailLangDTO.eColumns.CONTROL_CD);
            sb.AppendLine("  ," + ScreenDetailLangDTO.eColumns.LANG_CD);
            sb.AppendLine("  ," + ScreenDetailLangDTO.eColumns.SCREEN_CD);
            sb.AppendLine("  ," + ScreenDetailLangDTO.eColumns.CONTROL_CAPTION);
            sb.AppendLine("  ," + ScreenDetailLangDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + ScreenDetailLangDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + ScreenDetailLangDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + ScreenDetailLangDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + ScreenDetailLangDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + ScreenDetailLangDTO.eColumns.UPD_MACHINE);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ScreenDetailLangDTO.eColumns.CONTROL_CD + "=:CONTROL_CD");
            sb.AppendLine("  AND " + ScreenDetailLangDTO.eColumns.LANG_CD + "=:LANG_CD");
            sb.AppendLine("  AND " + ScreenDetailLangDTO.eColumns.SCREEN_CD + "=:SCREEN_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("CONTROL_CD", DataType.VarChar, CONTROL_CD.Value);
            req.Parameters.Add("LANG_CD", DataType.VarChar, LANG_CD.Value);
            req.Parameters.Add("SCREEN_CD", DataType.VarChar, SCREEN_CD.Value);
            #endregion

            List<ScreenDetailLangDTO> list = db.ExecuteForList<ScreenDetailLangDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        #endregion
    }
}

