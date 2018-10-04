/* Create by: Ms. Sansanee K.
 * Create on: 2012-03-16
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

namespace Rubik.DAO
{
    public partial class ItemProcessDAO
    {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public ItemProcessDAO() { }

        public ItemProcessDAO(Database db)
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
        public int AddNewOrUpdate(Database database, ItemProcessDTO data)
        {
            Database db = UseDatabase(database);

            if (Exist(database, data.ITEM_CD, data.ITEM_SEQ))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, ItemProcessDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            sb.AppendLine("  " + ItemProcessDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.ITEM_SEQ);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.PROCESS_CD);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.WEIGHT);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.PRODUCTION_LEADTIME);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.QTY_PER_DAY);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.SUPPLIER_CD);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.OLD_DATA);
            sb.AppendLine(") VALUES(");
            sb.AppendLine("   @CRT_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,@CRT_MACHINE");
            sb.AppendLine("   ,@UPD_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,@UPD_MACHINE");
            sb.AppendLine("   ,@ITEM_CD");
            sb.AppendLine("   ,@ITEM_SEQ");
            sb.AppendLine("   ,@PROCESS_CD");
            sb.AppendLine("   ,@WEIGHT");
            sb.AppendLine("   ,@PRODUCTION_LEADTIME");
            sb.AppendLine("   ,@QTY_PER_DAY");
            sb.AppendLine("   ,@SUPPLIER_CD");
            sb.AppendLine("   ,@OLD_DATA");
            sb.AppendLine(" )");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@CRT_BY", DataType.NVarChar, data.CRT_BY.Value);
            req.Parameters.Add("@CRT_MACHINE", DataType.NVarChar, data.CRT_MACHINE.Value);
            req.Parameters.Add("@UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("@ITEM_CD", DataType.Default, data.ITEM_CD.StrongValue);
            req.Parameters.Add("@ITEM_SEQ", DataType.Default, data.ITEM_SEQ.StrongValue);
            req.Parameters.Add("@PROCESS_CD", DataType.NVarChar, data.PROCESS_CD.Value);
            req.Parameters.Add("@WEIGHT", DataType.Number, data.WEIGHT.Value);
            req.Parameters.Add("@PRODUCTION_LEADTIME", DataType.Default, data.PRODUCTION_LEADTIME.Value);
            req.Parameters.Add("@QTY_PER_DAY", DataType.Number, data.QTY_PER_DAY.Value);
            req.Parameters.Add("@SUPPLIER_CD", DataType.NVarChar, data.SUPPLIER_CD.Value);
            req.Parameters.Add("@OLD_DATA", DataType.Default, data.OLD_DATA.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using primary key value on the given data variable
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data with primary key value.</param>
        /// <returns></returns>
        public int UpdateWithoutPK(Database database, ItemProcessDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + ItemProcessDTO.eColumns.UPD_BY + "=@UPD_BY");
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.UPD_MACHINE + "=@UPD_MACHINE");
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.PROCESS_CD + "=@PROCESS_CD");
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.WEIGHT + "=@WEIGHT");
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.PRODUCTION_LEADTIME + "=@PRODUCTION_LEADTIME");
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.QTY_PER_DAY + "=@QTY_PER_DAY");
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.SUPPLIER_CD + "=@SUPPLIER_CD");
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.OLD_DATA + "=@OLD_DATA");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ItemProcessDTO.eColumns.ITEM_CD + "=@ITEM_CD");
            sb.AppendLine("  AND " + ItemProcessDTO.eColumns.ITEM_SEQ + "=@ITEM_SEQ");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("@ITEM_CD", DataType.Default, data.ITEM_CD.Value);
            req.Parameters.Add("@ITEM_SEQ", DataType.Default, data.ITEM_SEQ.Value);
            req.Parameters.Add("@PROCESS_CD", DataType.NVarChar, data.PROCESS_CD.Value);
            req.Parameters.Add("@WEIGHT", DataType.Number, data.WEIGHT.Value);
            req.Parameters.Add("@PRODUCTION_LEADTIME", DataType.Default, data.PRODUCTION_LEADTIME.Value);
            req.Parameters.Add("@QTY_PER_DAY", DataType.Number, data.QTY_PER_DAY.Value);
            req.Parameters.Add("@SUPPLIER_CD", DataType.NVarChar, data.SUPPLIER_CD.Value);
            req.Parameters.Add("@OLD_DATA", DataType.Default, data.OLD_DATA.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using the table's primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data which to update.</param>
        /// <param name="oldITEM_CD">Old Key #1</param>
        /// <param name="oldITEM_SEQ">Old Key #2</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, ItemProcessDTO data, NZInt oldITEM_CD, NZInt oldITEM_SEQ)
        {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + ItemProcessDTO.eColumns.UPD_BY + "=@UPD_BY");
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.UPD_MACHINE + "=@UPD_MACHINE");
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.ITEM_CD + "=@ITEM_CD");
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.ITEM_SEQ + "=@ITEM_SEQ");
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.PROCESS_CD + "=@PROCESS_CD");
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.WEIGHT + "=@WEIGHT");
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.PRODUCTION_LEADTIME + "=@PRODUCTION_LEADTIME");
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.QTY_PER_DAY + "=@QTY_PER_DAY");
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.SUPPLIER_CD + "=@SUPPLIER_CD");
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.OLD_DATA + "=@OLD_DATA");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ItemProcessDTO.eColumns.ITEM_CD + "=@oldITEM_CD");
            sb.AppendLine("  AND " + ItemProcessDTO.eColumns.ITEM_SEQ + "=@oldItemProcess");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("@ITEM_CD", DataType.Default, data.ITEM_CD.Value);
            req.Parameters.Add("@ITEM_SEQ", DataType.Default, data.ITEM_SEQ.Value);
            req.Parameters.Add("@PROCESS_CD", DataType.NVarChar, data.PROCESS_CD.Value);
            req.Parameters.Add("@WEIGHT", DataType.Number, data.WEIGHT.Value);
            req.Parameters.Add("@PRODUCTION_LEADTIME", DataType.Default, data.PRODUCTION_LEADTIME.Value);
            req.Parameters.Add("@QTY_PER_DAY", DataType.Number, data.QTY_PER_DAY.Value);
            req.Parameters.Add("@SUPPLIER_CD", DataType.NVarChar, data.SUPPLIER_CD.Value);
            req.Parameters.Add("@OLD_DATA", DataType.Default, data.OLD_DATA.Value);
            req.Parameters.Add("@oldITEM_CD", DataType.Default, oldITEM_CD);
            req.Parameters.Add("@oldITEM_SEQ", DataType.Default, oldITEM_SEQ);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ITEM_CD">Key #1</param>
        /// <param name="ITEM_SEQ">Key #2</param>
        /// <returns></returns>
        public int Delete(Database database, NZString ITEM_CD, NZInt ITEM_SEQ)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ItemProcessDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ItemProcessDTO.eColumns.ITEM_CD + "=@ITEM_CD");
            sb.AppendLine("  AND " + ItemProcessDTO.eColumns.ITEM_SEQ + "=@ITEM_SEQ");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@ITEM_CD", DataType.Default, ITEM_CD.Value);
            req.Parameters.Add("@ITEM_SEQ", DataType.Default, ITEM_SEQ.Value);
            #endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, NZString ITEM_CD, NZInt ITEM_SEQ)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ItemProcessDTO));

            sb.AppendLine(" SELECT TOP 1 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ItemProcessDTO.eColumns.ITEM_CD + "=@ITEM_CD");
            sb.AppendLine("  AND " + ItemProcessDTO.eColumns.ITEM_SEQ + "=@ITEM_SEQ");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@ITEM_CD", DataType.Default, ITEM_CD);
            req.Parameters.Add("@ITEM_SEQ", DataType.Default, ITEM_SEQ);
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
        public List<ItemProcessDTO> LoadAll(Database database)
        {
            return LoadAll(database, true,
                ItemProcessDTO.eColumns.ITEM_CD
                , ItemProcessDTO.eColumns.ITEM_SEQ
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<ItemProcessDTO> LoadAll(Database database, bool ascending)
        {
            return LoadAll(database, ascending,
                ItemProcessDTO.eColumns.ITEM_CD
                , ItemProcessDTO.eColumns.ITEM_SEQ
            );
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<ItemProcessDTO> LoadAll(Database database, bool ascending, params ItemProcessDTO.eColumns[] orderByColumns)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ItemProcessDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + ItemProcessDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.ITEM_SEQ);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.PROCESS_CD);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.WEIGHT);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.PRODUCTION_LEADTIME);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.QTY_PER_DAY);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.SUPPLIER_CD);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.OLD_DATA);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.TIME_STAMP);
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

            return db.ExecuteForList<ItemProcessDTO>(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ITEM_CD">Key #1</param>
        /// <param name="ITEM_SEQ">Key #2</param>
        /// <returns></returns>
        public ItemProcessDTO LoadByPK(Database database, NZInt ITEM_CD, NZInt ITEM_SEQ)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ItemProcessDTO));
            sb.AppendLine(" SELECT ");
            //sb.AppendLine("  " + ItemProcessDTO.eColumns.CRT_BY);
            //sb.AppendLine("  ," + ItemProcessDTO.eColumns.CRT_DATE);
            //sb.AppendLine("  ," + ItemProcessDTO.eColumns.CRT_MACHINE);
            //sb.AppendLine("  ," + ItemProcessDTO.eColumns.UPD_BY);
            //sb.AppendLine("  ," + ItemProcessDTO.eColumns.UPD_DATE);
            //sb.AppendLine("  ," + ItemProcessDTO.eColumns.UPD_MACHINE);
            //sb.AppendLine("  ," + ItemProcessDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.ITEM_SEQ);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.PROCESS_CD);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.WEIGHT);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.PRODUCTION_LEADTIME);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.QTY_PER_DAY);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.SUPPLIER_CD);
            //sb.AppendLine("  ," + ItemProcessDTO.eColumns.OLD_DATA);
            //sb.AppendLine("  ," + ItemProcessDTO.eColumns.TIME_STAMP);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ItemProcessDTO.eColumns.ITEM_CD + "=@ITEM_CD");
            sb.AppendLine("  AND " + ItemProcessDTO.eColumns.ITEM_SEQ + "=@ITEM_SEQ");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@ITEM_CD", DataType.Default, ITEM_CD);
            req.Parameters.Add("@ITEM_SEQ", DataType.Default, ITEM_SEQ);
            #endregion

            List<ItemProcessDTO> list = db.ExecuteForList<ItemProcessDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        #endregion
    }
}

