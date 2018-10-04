/* Create by: Mr.Teerayut Sinlan
 * Create on: 2010-06-15
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
    internal partial class InventoryOnhandDAO 
    {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public InventoryOnhandDAO() { }

        public InventoryOnhandDAO(Database db)
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
        public int AddNewOrUpdate(Database database, InventoryOnhandDTO data)
        {
            Database db = UseDatabase(database);

            if (Exist(database, data.ID))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, InventoryOnhandDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            //sb.AppendLine("  " + InventoryOnhandDTO.eColumns.ID);
            sb.AppendLine("  " + InventoryOnhandDTO.eColumns.YEAR_MONTH);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.PERIOD_BEGIN_DATE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.PERIOD_END_DATE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.LOC_CD);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.LOT_NO);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.OPEN_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.IN_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.OUT_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.ADJUST_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.STOCK_TAKE_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.ON_HAND_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.LAST_RECEIVE_DATE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.OLD_DATA);
            sb.AppendLine(") VALUES(");
           // sb.AppendLine("   :ID");
            sb.AppendLine("   :YEAR_MONTH");
            sb.AppendLine("   ,:PERIOD_BEGIN_DATE");
            sb.AppendLine("   ,:PERIOD_END_DATE");
            sb.AppendLine("   ,:ITEM_CD");
            sb.AppendLine("   ,:LOC_CD");
            sb.AppendLine("   ,:LOT_NO");
            sb.AppendLine("   ,:OPEN_QTY");
            sb.AppendLine("   ,:IN_QTY");
            sb.AppendLine("   ,:OUT_QTY");
            sb.AppendLine("   ,:ADJUST_QTY");
            sb.AppendLine("   ,:STOCK_TAKE_QTY");
            sb.AppendLine("   ,:ON_HAND_QTY");
            sb.AppendLine("   ,:CRT_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,:CRT_MACHINE");
            sb.AppendLine("   ,:UPD_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,:UPD_MACHINE");
            sb.AppendLine("   ,:LAST_RECEIVE_DATE");
            sb.AppendLine("   ,:OLD_DATA");
            sb.AppendLine(" )");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            //req.Parameters.Add("ID", DataType.Default, data.ID.Value);
            req.Parameters.Add("YEAR_MONTH", DataType.NVarChar, data.YEAR_MONTH.Value);
            req.Parameters.Add("PERIOD_BEGIN_DATE", DataType.DateTime, data.PERIOD_BEGIN_DATE.Value);
            req.Parameters.Add("PERIOD_END_DATE", DataType.DateTime, data.PERIOD_END_DATE.Value);
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("LOC_CD", DataType.NVarChar, data.LOC_CD.Value);
            req.Parameters.Add("LOT_NO", DataType.NVarChar, data.LOT_NO.Value);
            req.Parameters.Add("OPEN_QTY", DataType.Number, data.OPEN_QTY.Value);
            req.Parameters.Add("IN_QTY", DataType.Number, data.IN_QTY.Value);
            req.Parameters.Add("OUT_QTY", DataType.Number, data.OUT_QTY.Value);
            req.Parameters.Add("ADJUST_QTY", DataType.Number, data.ADJUST_QTY.Value);
            req.Parameters.Add("STOCK_TAKE_QTY", DataType.Number, data.STOCK_TAKE_QTY.Value);
            req.Parameters.Add("ON_HAND_QTY", DataType.Number, data.ON_HAND_QTY.Value);
            req.Parameters.Add("CRT_BY", DataType.NVarChar, data.CRT_BY.Value);
            req.Parameters.Add("CRT_MACHINE", DataType.NVarChar, data.CRT_MACHINE.Value);
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("LAST_RECEIVE_DATE", DataType.DateTime, data.LAST_RECEIVE_DATE.Value);
            req.Parameters.Add("OLD_DATA", DataType.Int16, 0);
            #endregion

            try
            {
                return db.ExecuteNonQuery(req);
            }
            catch (Exception err)
            {
                throw;
            }
           
        }

        /// <summary>
        /// Update record by using primary key value on the given data variable
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data with primary key value.</param>
        /// <returns></returns>
        public int UpdateWithoutPK(Database database, InventoryOnhandDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            //sb.AppendLine("  " + InventoryOnhandDTO.eColumns.YEAR_MONTH + "=:YEAR_MONTH");
            //sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.PERIOD_BEGIN_DATE + "=:PERIOD_BEGIN_DATE");
            //sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.PERIOD_END_DATE + "=:PERIOD_END_DATE");
            //sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            //sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.LOC_CD + "=:LOC_CD");
            //sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.LOT_NO + "=:LOT_NO");
            sb.AppendLine("  " + InventoryOnhandDTO.eColumns.OPEN_QTY + "=:OPEN_QTY");
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.IN_QTY + "=:IN_QTY");
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.OUT_QTY + "=:OUT_QTY");
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.ADJUST_QTY + "=:ADJUST_QTY");
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.STOCK_TAKE_QTY + "=:STOCK_TAKE_QTY");
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.ON_HAND_QTY + "=:ON_HAND_QTY");
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.LAST_RECEIVE_DATE + "=:LAST_RECEIVE_DATE");
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.OLD_DATA + "=:OLD_DATA");
            sb.AppendLine(" WHERE ");
            //sb.AppendLine("  " + InventoryOnhandDTO.eColumns.ID + "=:ID");
            sb.AppendLine("  " + InventoryOnhandDTO.eColumns.YEAR_MONTH + "=:YEAR_MONTH");
            sb.AppendLine(" AND " + InventoryOnhandDTO.eColumns.PERIOD_BEGIN_DATE + "=:PERIOD_BEGIN_DATE");
            sb.AppendLine(" AND " + InventoryOnhandDTO.eColumns.PERIOD_END_DATE + "=:PERIOD_END_DATE");
            sb.AppendLine(" AND " + InventoryOnhandDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            sb.AppendLine(" AND " + InventoryOnhandDTO.eColumns.LOC_CD + "=:LOC_CD");
            sb.AppendLine(" AND ((LOT_NO IS NULL) OR (LOT_NO =:LOT_NO))");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("ID", DataType.Default, data.ID.Value);
            req.Parameters.Add("YEAR_MONTH", DataType.NVarChar, data.YEAR_MONTH.Value);
            req.Parameters.Add("PERIOD_BEGIN_DATE", DataType.DateTime, data.PERIOD_BEGIN_DATE.Value);
            req.Parameters.Add("PERIOD_END_DATE", DataType.DateTime, data.PERIOD_END_DATE.Value);
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("LOC_CD", DataType.NVarChar, data.LOC_CD.Value);
            req.Parameters.Add("LOT_NO", DataType.NVarChar, data.LOT_NO.Value);
            req.Parameters.Add("OPEN_QTY", DataType.Number, data.OPEN_QTY.Value);
            req.Parameters.Add("IN_QTY", DataType.Number, data.IN_QTY.Value);
            req.Parameters.Add("OUT_QTY", DataType.Number, data.OUT_QTY.Value);
            req.Parameters.Add("ADJUST_QTY", DataType.Number, data.ADJUST_QTY.Value);
            req.Parameters.Add("STOCK_TAKE_QTY", DataType.Number, data.STOCK_TAKE_QTY.Value);
            req.Parameters.Add("ON_HAND_QTY", DataType.Number, data.ON_HAND_QTY.Value);
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("LAST_RECEIVE_DATE", DataType.DateTime, data.LAST_RECEIVE_DATE.Value);
            req.Parameters.Add("OLD_DATA", DataType.Number, 0);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using the table's primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data which to update.</param>
        /// <param name="oldID">Old Key #1</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, InventoryOnhandDTO data, NZLong oldID)
        {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            //sb.AppendLine("  " + InventoryOnhandDTO.eColumns.ID + "=:ID");
            sb.AppendLine("  " + InventoryOnhandDTO.eColumns.YEAR_MONTH + "=:YEAR_MONTH");
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.PERIOD_BEGIN_DATE + "=:PERIOD_BEGIN_DATE");
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.PERIOD_END_DATE + "=:PERIOD_END_DATE");
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.LOC_CD + "=:LOC_CD");
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.LOT_NO + "=:LOT_NO");
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.OPEN_QTY + "=:OPEN_QTY");
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.IN_QTY + "=:IN_QTY");
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.OUT_QTY + "=:OUT_QTY");
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.ADJUST_QTY + "=:ADJUST_QTY");
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.STOCK_TAKE_QTY + "=:STOCK_TAKE_QTY");
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.ON_HAND_QTY + "=:ON_HAND_QTY");
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.LAST_RECEIVE_DATE + "=:LAST_RECEIVE_DATE");
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.OLD_DATA + "=:OLD_DATA");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + InventoryOnhandDTO.eColumns.ID + "=:oldID");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            //req.Parameters.Add("ID", DataType.Default, data.ID.Value);
            req.Parameters.Add("YEAR_MONTH", DataType.NVarChar, data.YEAR_MONTH.Value);
            req.Parameters.Add("PERIOD_BEGIN_DATE", DataType.DateTime, data.PERIOD_BEGIN_DATE.Value);
            req.Parameters.Add("PERIOD_END_DATE", DataType.DateTime, data.PERIOD_END_DATE.Value);
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("LOC_CD", DataType.NVarChar, data.LOC_CD.Value);
            req.Parameters.Add("LOT_NO", DataType.NVarChar, data.LOT_NO.Value);
            req.Parameters.Add("OPEN_QTY", DataType.Number, data.OPEN_QTY.Value);
            req.Parameters.Add("IN_QTY", DataType.Number, data.IN_QTY.Value);
            req.Parameters.Add("OUT_QTY", DataType.Number, data.OUT_QTY.Value);
            req.Parameters.Add("ADJUST_QTY", DataType.Number, data.ADJUST_QTY.Value);
            req.Parameters.Add("STOCK_TAKE_QTY", DataType.Number, data.STOCK_TAKE_QTY.Value);
            req.Parameters.Add("ON_HAND_QTY", DataType.Number, data.ON_HAND_QTY.Value);
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("LAST_RECEIVE_DATE", DataType.DateTime, data.LAST_RECEIVE_DATE.Value);
            req.Parameters.Add("@OLD_DATA", DataType.Default, 0);
            req.Parameters.Add("oldID", DataType.Default, oldID.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ID">Key #1</param>
        /// <returns></returns>
        public int Delete(Database database, NZLong ID)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InventoryOnhandDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + InventoryOnhandDTO.eColumns.ID + "=:ID");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("ID", DataType.Default, ID.Value);
            #endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, NZLong ID)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InventoryOnhandDTO));

            sb.AppendLine(" SELECT TOP 1 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + InventoryOnhandDTO.eColumns.ID + "=:ID");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("ID", DataType.Default, ID.Value);
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
        public List<InventoryOnhandDTO> LoadAll(Database database)
        {
            return LoadAll(database, true,
                InventoryOnhandDTO.eColumns.ID
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<InventoryOnhandDTO> LoadAll(Database database, bool ascending)
        {
            return LoadAll(database, ascending,
                InventoryOnhandDTO.eColumns.ID
            );
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<InventoryOnhandDTO> LoadAll(Database database, bool ascending, params InventoryOnhandDTO.eColumns[] orderByColumns)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InventoryOnhandDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + InventoryOnhandDTO.eColumns.ID);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.YEAR_MONTH);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.PERIOD_BEGIN_DATE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.PERIOD_END_DATE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.LOC_CD);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.LOT_NO);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.OPEN_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.IN_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.OUT_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.ADJUST_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.STOCK_TAKE_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.ON_HAND_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.LAST_RECEIVE_DATE);
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

            return db.ExecuteForList<InventoryOnhandDTO>(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ID">Key #1</param>
        /// <returns></returns>
        public InventoryOnhandDTO LoadByPK(Database database, NZLong ID)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InventoryOnhandDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + InventoryOnhandDTO.eColumns.ID);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.YEAR_MONTH);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.PERIOD_BEGIN_DATE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.PERIOD_END_DATE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.LOC_CD);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.LOT_NO);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.OPEN_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.IN_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.OUT_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.ADJUST_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.STOCK_TAKE_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.ON_HAND_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.LAST_RECEIVE_DATE);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + InventoryOnhandDTO.eColumns.ID + "=:ID");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("ID", DataType.Default, ID.Value);
            #endregion

            List<InventoryOnhandDTO> list = db.ExecuteForList<InventoryOnhandDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        #endregion
    }
}

