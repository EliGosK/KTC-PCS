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
    internal partial class ImageDAO : IImageDAO
    {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public ImageDAO() { }

        public ImageDAO(Database db)
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
        public int AddNewOrUpdate(Database database, ImageDTO data)
        {
            Database db = UseDatabase(database);

            if (Exist(database, data.IMAGE_CD))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, ImageDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            sb.AppendLine("  " + ImageDTO.eColumns.IMAGE_CD);
            sb.AppendLine("  ," + ImageDTO.eColumns.IMAGE_BIN);
            sb.AppendLine("  ," + ImageDTO.eColumns.IMAGE_DES);
            sb.AppendLine("  ," + ImageDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + ImageDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + ImageDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + ImageDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + ImageDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + ImageDTO.eColumns.UPD_MACHINE);
            sb.AppendLine(") VALUES(");
            sb.AppendLine("   :IMAGE_CD");
            sb.AppendLine("   ,:IMAGE_BIN");
            sb.AppendLine("   ,:IMAGE_DES");
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
            req.Parameters.Add("IMAGE_CD", DataType.VarChar, data.IMAGE_CD.Value);
            req.Parameters.Add("IMAGE_BIN", DataType.Object, data.IMAGE_BIN.Value);
            req.Parameters.Add("IMAGE_DES", DataType.VarChar, data.IMAGE_DES.Value);
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
        public int UpdateWithoutPK(Database database, ImageDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + ImageDTO.eColumns.IMAGE_BIN + "=:IMAGE_BIN");
            sb.AppendLine("  ," + ImageDTO.eColumns.IMAGE_DES + "=:IMAGE_DES");
            sb.AppendLine("  ," + ImageDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + ImageDTO.eColumns.UPD_DATE + "=SYSDATE");
            sb.AppendLine("  ," + ImageDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ImageDTO.eColumns.IMAGE_CD + "=:IMAGE_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("IMAGE_CD", DataType.VarChar, data.IMAGE_CD.Value);
            req.Parameters.Add("IMAGE_BIN", DataType.Object, data.IMAGE_BIN.Value);
            req.Parameters.Add("IMAGE_DES", DataType.VarChar, data.IMAGE_DES.Value);
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
        /// <param name="oldIMAGE_CD">Old Key #1</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, ImageDTO data, NZString oldIMAGE_CD)
        {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + ImageDTO.eColumns.IMAGE_CD + "=:IMAGE_CD");
            sb.AppendLine("  ," + ImageDTO.eColumns.IMAGE_BIN + "=:IMAGE_BIN");
            sb.AppendLine("  ," + ImageDTO.eColumns.IMAGE_DES + "=:IMAGE_DES");
            sb.AppendLine("  ," + ImageDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + ImageDTO.eColumns.UPD_DATE + "=SYSDATE");
            sb.AppendLine("  ," + ImageDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ImageDTO.eColumns.IMAGE_CD + "=:oldIMAGE_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("IMAGE_CD", DataType.VarChar, data.IMAGE_CD.Value);
            req.Parameters.Add("IMAGE_BIN", DataType.Object, data.IMAGE_BIN.Value);
            req.Parameters.Add("IMAGE_DES", DataType.VarChar, data.IMAGE_DES.Value);
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("oldIMAGE_CD", DataType.VarChar, oldIMAGE_CD.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="IMAGE_CD">Key #1</param>
        /// <returns></returns>
        public int Delete(Database database, NZString IMAGE_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ImageDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ImageDTO.eColumns.IMAGE_CD + "=:IMAGE_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("IMAGE_CD", DataType.VarChar, IMAGE_CD.Value);
            #endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, NZString IMAGE_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ImageDTO));

            sb.AppendLine(" SELECT 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ROWNUM=1");
            sb.AppendLine("  AND " + ImageDTO.eColumns.IMAGE_CD + "=:IMAGE_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("IMAGE_CD", DataType.VarChar, IMAGE_CD.Value);
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
        public List<ImageDTO> LoadAll(Database database)
        {
            return LoadAll(database, true,
                ImageDTO.eColumns.IMAGE_CD
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<ImageDTO> LoadAll(Database database, bool ascending)
        {
            return LoadAll(database, ascending,
                ImageDTO.eColumns.IMAGE_CD
            );
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<ImageDTO> LoadAll(Database database, bool ascending, params ImageDTO.eColumns[] orderByColumns)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ImageDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + ImageDTO.eColumns.IMAGE_CD);
            sb.AppendLine("  ," + ImageDTO.eColumns.IMAGE_BIN);
            sb.AppendLine("  ," + ImageDTO.eColumns.IMAGE_DES);
            sb.AppendLine("  ," + ImageDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + ImageDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + ImageDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + ImageDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + ImageDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + ImageDTO.eColumns.UPD_MACHINE);
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

            return db.ExecuteForList<ImageDTO>(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="IMAGE_CD">Key #1</param>
        /// <returns></returns>
        public ImageDTO LoadByPK(Database database, NZString IMAGE_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ImageDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + ImageDTO.eColumns.IMAGE_CD);
            sb.AppendLine("  ," + ImageDTO.eColumns.IMAGE_BIN);
            sb.AppendLine("  ," + ImageDTO.eColumns.IMAGE_DES);
            sb.AppendLine("  ," + ImageDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + ImageDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + ImageDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + ImageDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + ImageDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + ImageDTO.eColumns.UPD_MACHINE);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ImageDTO.eColumns.IMAGE_CD + "=:IMAGE_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("IMAGE_CD", DataType.VarChar, IMAGE_CD.Value);
            #endregion

            List<ImageDTO> list = db.ExecuteForList<ImageDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        #endregion
    }
}

