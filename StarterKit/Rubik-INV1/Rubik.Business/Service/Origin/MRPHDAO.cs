/* Create by: 
 * Create on: 2554-06-23
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
    internal partial class MRPHDAO
    {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public MRPHDAO() { }

        public MRPHDAO(Database db)
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
        public int AddNewOrUpdate(Database database, MRPHDTO data)
        {
            Database db = UseDatabase(database);

            if (Exist(database, data.MRP_NO, data.ITEM_CD, data.ORDER_LOC_CD))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, MRPHDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            sb.AppendLine("  " + MRPHDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + MRPHDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + MRPHDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + MRPHDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + MRPHDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + MRPHDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + MRPHDTO.eColumns.IS_ACTIVE);
            sb.AppendLine("  ," + MRPHDTO.eColumns.MRP_NO);
            sb.AppendLine("  ," + MRPHDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + MRPHDTO.eColumns.ORDER_LOC_CD);
            sb.AppendLine("  ," + MRPHDTO.eColumns.REVISION_NO);
            sb.AppendLine("  ," + MRPHDTO.eColumns.ITEM_CLS);
            sb.AppendLine("  ," + MRPHDTO.eColumns.ITEM_DESC);
            sb.AppendLine("  ," + MRPHDTO.eColumns.ORDER_PROCESS_CLS);
            sb.AppendLine("  ," + MRPHDTO.eColumns.LOT_SIZE);
            sb.AppendLine("  ," + MRPHDTO.eColumns.REORDER_POINT);
            sb.AppendLine("  ," + MRPHDTO.eColumns.SAFETY_STOCK);
            sb.AppendLine("  ," + MRPHDTO.eColumns.MINIMUM_ORDER);
            sb.AppendLine("  ," + MRPHDTO.eColumns.INV_UM_CLS);
            sb.AppendLine("  ," + MRPHDTO.eColumns.ORDER_UM_CLS);
            sb.AppendLine("  ," + MRPHDTO.eColumns.INV_UM_RATE);
            sb.AppendLine("  ," + MRPHDTO.eColumns.ORDER_UM_RATE);
            sb.AppendLine("  ," + MRPHDTO.eColumns.MAX_CAPACITY);
            sb.AppendLine("  ," + MRPHDTO.eColumns.LEADTIME);
            sb.AppendLine("  ," + MRPHDTO.eColumns.SAFETY_LEADTIME);
            sb.AppendLine("  ," + MRPHDTO.eColumns.MRP_FLAG);
            sb.AppendLine("  ," + MRPHDTO.eColumns.ORDER_CONDITION);
            sb.AppendLine(") VALUES(");
            sb.AppendLine("   :CRT_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,:CRT_MACHINE");
            sb.AppendLine("   ,:UPD_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,:UPD_MACHINE");
            sb.AppendLine("   ,:IS_ACTIVE");
            sb.AppendLine("   ,:MRP_NO");
            sb.AppendLine("   ,:ITEM_CD");
            sb.AppendLine("   ,:ORDER_LOC_CD");
            sb.AppendLine("   ,:REVISION_NO");
            sb.AppendLine("   ,:ITEM_CLS");
            sb.AppendLine("   ,:ITEM_DESC");
            sb.AppendLine("   ,:ORDER_PROCESS_CLS");
            sb.AppendLine("   ,:LOT_SIZE");
            sb.AppendLine("   ,:REORDER_POINT");
            sb.AppendLine("   ,:SAFETY_STOCK");
            sb.AppendLine("   ,:MINIMUM_ORDER");
            sb.AppendLine("   ,:INV_UM_CLS");
            sb.AppendLine("   ,:ORDER_UM_CLS");
            sb.AppendLine("   ,:INV_UM_RATE");
            sb.AppendLine("   ,:ORDER_UM_RATE");
            sb.AppendLine("   ,:MAX_CAPACITY");
            sb.AppendLine("   ,:LEADTIME");
            sb.AppendLine("   ,:SAFETY_LEADTIME");
            sb.AppendLine("   ,:MRP_FLAG");
            sb.AppendLine("   ,:ORDER_CONDITION");
            sb.AppendLine(" )");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("CRT_BY", DataType.NVarChar, data.CRT_BY.Value);
            req.Parameters.Add("CRT_MACHINE", DataType.NVarChar, data.CRT_MACHINE.Value);
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("IS_ACTIVE", DataType.Number, data.IS_ACTIVE.Value);
            req.Parameters.Add("MRP_NO", DataType.NVarChar, data.MRP_NO.Value);
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("ORDER_LOC_CD", DataType.NVarChar, data.ORDER_LOC_CD.Value);
            req.Parameters.Add("REVISION_NO", DataType.Number, data.REVISION_NO.Value);
            req.Parameters.Add("ITEM_CLS", DataType.NVarChar, data.ITEM_CLS.Value);
            req.Parameters.Add("ITEM_DESC", DataType.NVarChar, data.ITEM_DESC.Value);
            req.Parameters.Add("ORDER_PROCESS_CLS", DataType.NVarChar, data.ORDER_PROCESS_CLS.Value);
            req.Parameters.Add("LOT_SIZE", DataType.Number, data.LOT_SIZE.Value);
            req.Parameters.Add("REORDER_POINT", DataType.Number, data.REORDER_POINT.Value);
            req.Parameters.Add("SAFETY_STOCK", DataType.Number, data.SAFETY_STOCK.Value);
            req.Parameters.Add("MINIMUM_ORDER", DataType.Number, data.MINIMUM_ORDER.Value);
            req.Parameters.Add("INV_UM_CLS", DataType.NVarChar, data.INV_UM_CLS.Value);
            req.Parameters.Add("ORDER_UM_CLS", DataType.NVarChar, data.ORDER_UM_CLS.Value);
            req.Parameters.Add("INV_UM_RATE", DataType.Number, data.INV_UM_RATE.Value);
            req.Parameters.Add("ORDER_UM_RATE", DataType.Number, data.ORDER_UM_RATE.Value);
            req.Parameters.Add("MAX_CAPACITY", DataType.Number, data.MAX_CAPACITY.Value);
            req.Parameters.Add("LEADTIME", DataType.Number, data.LEADTIME.Value);
            req.Parameters.Add("SAFETY_LEADTIME", DataType.Number, data.SAFETY_LEADTIME.Value);
            req.Parameters.Add("MRP_FLAG", DataType.NVarChar, data.MRP_FLAG.Value);
            req.Parameters.Add("ORDER_CONDITION", DataType.NVarChar, data.ORDER_CONDITION.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using primary key value on the given data variable
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data with primary key value.</param>
        /// <returns></returns>
        public int UpdateWithoutPK(Database database, MRPHDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + MRPHDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + MRPHDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + MRPHDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            sb.AppendLine("  ," + MRPHDTO.eColumns.IS_ACTIVE + "=:IS_ACTIVE");
            sb.AppendLine("  ," + MRPHDTO.eColumns.REVISION_NO + "=:REVISION_NO");
            sb.AppendLine("  ," + MRPHDTO.eColumns.ITEM_CLS + "=:ITEM_CLS");
            sb.AppendLine("  ," + MRPHDTO.eColumns.ITEM_DESC + "=:ITEM_DESC");
            sb.AppendLine("  ," + MRPHDTO.eColumns.ORDER_PROCESS_CLS + "=:ORDER_PROCESS_CLS");
            sb.AppendLine("  ," + MRPHDTO.eColumns.LOT_SIZE + "=:LOT_SIZE");
            sb.AppendLine("  ," + MRPHDTO.eColumns.REORDER_POINT + "=:REORDER_POINT");
            sb.AppendLine("  ," + MRPHDTO.eColumns.SAFETY_STOCK + "=:SAFETY_STOCK");
            sb.AppendLine("  ," + MRPHDTO.eColumns.MINIMUM_ORDER + "=:MINIMUM_ORDER");
            sb.AppendLine("  ," + MRPHDTO.eColumns.INV_UM_CLS + "=:INV_UM_CLS");
            sb.AppendLine("  ," + MRPHDTO.eColumns.ORDER_UM_CLS + "=:ORDER_UM_CLS");
            sb.AppendLine("  ," + MRPHDTO.eColumns.INV_UM_RATE + "=:INV_UM_RATE");
            sb.AppendLine("  ," + MRPHDTO.eColumns.ORDER_UM_RATE + "=:ORDER_UM_RATE");
            sb.AppendLine("  ," + MRPHDTO.eColumns.MAX_CAPACITY + "=:MAX_CAPACITY");
            sb.AppendLine("  ," + MRPHDTO.eColumns.LEADTIME + "=:LEADTIME");
            sb.AppendLine("  ," + MRPHDTO.eColumns.SAFETY_LEADTIME + "=:SAFETY_LEADTIME");
            sb.AppendLine("  ," + MRPHDTO.eColumns.MRP_FLAG + "=:MRP_FLAG");
            sb.AppendLine("  ," + MRPHDTO.eColumns.ORDER_CONDITION + "=:ORDER_CONDITION");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + MRPHDTO.eColumns.MRP_NO + "=:MRP_NO");
            sb.AppendLine("  AND " + MRPHDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            sb.AppendLine("  AND " + MRPHDTO.eColumns.ORDER_LOC_CD + "=:ORDER_LOC_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("IS_ACTIVE", DataType.Number, data.IS_ACTIVE.Value);
            req.Parameters.Add("MRP_NO", DataType.NVarChar, data.MRP_NO.Value);
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("ORDER_LOC_CD", DataType.NVarChar, data.ORDER_LOC_CD.Value);
            req.Parameters.Add("REVISION_NO", DataType.Number, data.REVISION_NO.Value);
            req.Parameters.Add("ITEM_CLS", DataType.NVarChar, data.ITEM_CLS.Value);
            req.Parameters.Add("ITEM_DESC", DataType.NVarChar, data.ITEM_DESC.Value);
            req.Parameters.Add("ORDER_PROCESS_CLS", DataType.NVarChar, data.ORDER_PROCESS_CLS.Value);
            req.Parameters.Add("LOT_SIZE", DataType.Number, data.LOT_SIZE.Value);
            req.Parameters.Add("REORDER_POINT", DataType.Number, data.REORDER_POINT.Value);
            req.Parameters.Add("SAFETY_STOCK", DataType.Number, data.SAFETY_STOCK.Value);
            req.Parameters.Add("MINIMUM_ORDER", DataType.Number, data.MINIMUM_ORDER.Value);
            req.Parameters.Add("INV_UM_CLS", DataType.NVarChar, data.INV_UM_CLS.Value);
            req.Parameters.Add("ORDER_UM_CLS", DataType.NVarChar, data.ORDER_UM_CLS.Value);
            req.Parameters.Add("INV_UM_RATE", DataType.Number, data.INV_UM_RATE.Value);
            req.Parameters.Add("ORDER_UM_RATE", DataType.Number, data.ORDER_UM_RATE.Value);
            req.Parameters.Add("MAX_CAPACITY", DataType.Number, data.MAX_CAPACITY.Value);
            req.Parameters.Add("LEADTIME", DataType.Number, data.LEADTIME.Value);
            req.Parameters.Add("SAFETY_LEADTIME", DataType.Number, data.SAFETY_LEADTIME.Value);
            req.Parameters.Add("MRP_FLAG", DataType.NVarChar, data.MRP_FLAG.Value);
            req.Parameters.Add("ORDER_CONDITION", DataType.NVarChar, data.ORDER_CONDITION.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using the table's primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data which to update.</param>
        /// <param name="oldMRP_NO">Old Key #1</param>
        /// <param name="oldITEM_CD">Old Key #2</param>
        /// <param name="oldORDER_LOC_CD">Old Key #3</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, MRPHDTO data, String oldMRP_NO, String oldITEM_CD, String oldORDER_LOC_CD)
        {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + MRPHDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + MRPHDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + MRPHDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            sb.AppendLine("  ," + MRPHDTO.eColumns.IS_ACTIVE + "=:IS_ACTIVE");
            sb.AppendLine("  ," + MRPHDTO.eColumns.MRP_NO + "=:MRP_NO");
            sb.AppendLine("  ," + MRPHDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            sb.AppendLine("  ," + MRPHDTO.eColumns.ORDER_LOC_CD + "=:ORDER_LOC_CD");
            sb.AppendLine("  ," + MRPHDTO.eColumns.REVISION_NO + "=:REVISION_NO");
            sb.AppendLine("  ," + MRPHDTO.eColumns.ITEM_CLS + "=:ITEM_CLS");
            sb.AppendLine("  ," + MRPHDTO.eColumns.ITEM_DESC + "=:ITEM_DESC");
            sb.AppendLine("  ," + MRPHDTO.eColumns.ORDER_PROCESS_CLS + "=:ORDER_PROCESS_CLS");
            sb.AppendLine("  ," + MRPHDTO.eColumns.LOT_SIZE + "=:LOT_SIZE");
            sb.AppendLine("  ," + MRPHDTO.eColumns.REORDER_POINT + "=:REORDER_POINT");
            sb.AppendLine("  ," + MRPHDTO.eColumns.SAFETY_STOCK + "=:SAFETY_STOCK");
            sb.AppendLine("  ," + MRPHDTO.eColumns.MINIMUM_ORDER + "=:MINIMUM_ORDER");
            sb.AppendLine("  ," + MRPHDTO.eColumns.INV_UM_CLS + "=:INV_UM_CLS");
            sb.AppendLine("  ," + MRPHDTO.eColumns.ORDER_UM_CLS + "=:ORDER_UM_CLS");
            sb.AppendLine("  ," + MRPHDTO.eColumns.INV_UM_RATE + "=:INV_UM_RATE");
            sb.AppendLine("  ," + MRPHDTO.eColumns.ORDER_UM_RATE + "=:ORDER_UM_RATE");
            sb.AppendLine("  ," + MRPHDTO.eColumns.MAX_CAPACITY + "=:MAX_CAPACITY");
            sb.AppendLine("  ," + MRPHDTO.eColumns.LEADTIME + "=:LEADTIME");
            sb.AppendLine("  ," + MRPHDTO.eColumns.SAFETY_LEADTIME + "=:SAFETY_LEADTIME");
            sb.AppendLine("  ," + MRPHDTO.eColumns.MRP_FLAG + "=:MRP_FLAG");
            sb.AppendLine("  ," + MRPHDTO.eColumns.ORDER_CONDITION + "=:ORDER_CONDITION");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + MRPHDTO.eColumns.MRP_NO + "=:oldMRP_NO");
            sb.AppendLine("  AND " + MRPHDTO.eColumns.ITEM_CD + "=:oldMRPH");
            sb.AppendLine("  AND " + MRPHDTO.eColumns.ORDER_LOC_CD + "=:oldMRPH");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("IS_ACTIVE", DataType.Number, data.IS_ACTIVE.Value);
            req.Parameters.Add("MRP_NO", DataType.NVarChar, data.MRP_NO.Value);
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("ORDER_LOC_CD", DataType.NVarChar, data.ORDER_LOC_CD.Value);
            req.Parameters.Add("REVISION_NO", DataType.Number, data.REVISION_NO.Value);
            req.Parameters.Add("ITEM_CLS", DataType.NVarChar, data.ITEM_CLS.Value);
            req.Parameters.Add("ITEM_DESC", DataType.NVarChar, data.ITEM_DESC.Value);
            req.Parameters.Add("ORDER_PROCESS_CLS", DataType.NVarChar, data.ORDER_PROCESS_CLS.Value);
            req.Parameters.Add("LOT_SIZE", DataType.Number, data.LOT_SIZE.Value);
            req.Parameters.Add("REORDER_POINT", DataType.Number, data.REORDER_POINT.Value);
            req.Parameters.Add("SAFETY_STOCK", DataType.Number, data.SAFETY_STOCK.Value);
            req.Parameters.Add("MINIMUM_ORDER", DataType.Number, data.MINIMUM_ORDER.Value);
            req.Parameters.Add("INV_UM_CLS", DataType.NVarChar, data.INV_UM_CLS.Value);
            req.Parameters.Add("ORDER_UM_CLS", DataType.NVarChar, data.ORDER_UM_CLS.Value);
            req.Parameters.Add("INV_UM_RATE", DataType.Number, data.INV_UM_RATE.Value);
            req.Parameters.Add("ORDER_UM_RATE", DataType.Number, data.ORDER_UM_RATE.Value);
            req.Parameters.Add("MAX_CAPACITY", DataType.Number, data.MAX_CAPACITY.Value);
            req.Parameters.Add("LEADTIME", DataType.Number, data.LEADTIME.Value);
            req.Parameters.Add("SAFETY_LEADTIME", DataType.Number, data.SAFETY_LEADTIME.Value);
            req.Parameters.Add("MRP_FLAG", DataType.NVarChar, data.MRP_FLAG.Value);
            req.Parameters.Add("ORDER_CONDITION", DataType.NVarChar, data.ORDER_CONDITION.Value);
            req.Parameters.Add("oldMRP_NO", DataType.NVarChar, oldMRP_NO);
            req.Parameters.Add("oldITEM_CD", DataType.NVarChar, oldITEM_CD);
            req.Parameters.Add("oldORDER_LOC_CD", DataType.NVarChar, oldORDER_LOC_CD);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="MRP_NO">Key #1</param>
        /// <param name="ITEM_CD">Key #2</param>
        /// <param name="ORDER_LOC_CD">Key #3</param>
        /// <returns></returns>
        public int Delete(Database database, String MRP_NO, String ITEM_CD, String ORDER_LOC_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(MRPHDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + MRPHDTO.eColumns.MRP_NO + "=:MRP_NO");
            sb.AppendLine("  AND " + MRPHDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            sb.AppendLine("  AND " + MRPHDTO.eColumns.ORDER_LOC_CD + "=:ORDER_LOC_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("MRP_NO", DataType.NVarChar, MRP_NO);
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, ITEM_CD);
            req.Parameters.Add("ORDER_LOC_CD", DataType.NVarChar, ORDER_LOC_CD);
            #endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, String MRP_NO, String ITEM_CD, String ORDER_LOC_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(MRPHDTO));

            sb.AppendLine(" SELECT TOP 1 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + MRPHDTO.eColumns.MRP_NO + "=:MRP_NO");
            sb.AppendLine("  AND " + MRPHDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            sb.AppendLine("  AND " + MRPHDTO.eColumns.ORDER_LOC_CD + "=:ORDER_LOC_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("MRP_NO", DataType.NVarChar, MRP_NO);
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, ITEM_CD);
            req.Parameters.Add("ORDER_LOC_CD", DataType.NVarChar, ORDER_LOC_CD);
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
        public List<MRPHDTO> LoadAll(Database database)
        {
            return LoadAll(database, true,
                MRPHDTO.eColumns.MRP_NO
                , MRPHDTO.eColumns.ITEM_CD
                , MRPHDTO.eColumns.ORDER_LOC_CD
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<MRPHDTO> LoadAll(Database database, bool ascending)
        {
            return LoadAll(database, ascending,
                MRPHDTO.eColumns.MRP_NO
                , MRPHDTO.eColumns.ITEM_CD
                , MRPHDTO.eColumns.ORDER_LOC_CD
            );
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<MRPHDTO> LoadAll(Database database, bool ascending, params MRPHDTO.eColumns[] orderByColumns)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(MRPHDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + MRPHDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + MRPHDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + MRPHDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + MRPHDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + MRPHDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + MRPHDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + MRPHDTO.eColumns.IS_ACTIVE);
            sb.AppendLine("  ," + MRPHDTO.eColumns.MRP_NO);
            sb.AppendLine("  ," + MRPHDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + MRPHDTO.eColumns.ORDER_LOC_CD);
            sb.AppendLine("  ," + MRPHDTO.eColumns.REVISION_NO);
            sb.AppendLine("  ," + MRPHDTO.eColumns.ITEM_CLS);
            sb.AppendLine("  ," + MRPHDTO.eColumns.ITEM_DESC);
            sb.AppendLine("  ," + MRPHDTO.eColumns.ORDER_PROCESS_CLS);
            sb.AppendLine("  ," + MRPHDTO.eColumns.LOT_SIZE);
            sb.AppendLine("  ," + MRPHDTO.eColumns.REORDER_POINT);
            sb.AppendLine("  ," + MRPHDTO.eColumns.SAFETY_STOCK);
            sb.AppendLine("  ," + MRPHDTO.eColumns.MINIMUM_ORDER);
            sb.AppendLine("  ," + MRPHDTO.eColumns.INV_UM_CLS);
            sb.AppendLine("  ," + MRPHDTO.eColumns.ORDER_UM_CLS);
            sb.AppendLine("  ," + MRPHDTO.eColumns.INV_UM_RATE);
            sb.AppendLine("  ," + MRPHDTO.eColumns.ORDER_UM_RATE);
            sb.AppendLine("  ," + MRPHDTO.eColumns.MAX_CAPACITY);
            sb.AppendLine("  ," + MRPHDTO.eColumns.LEADTIME);
            sb.AppendLine("  ," + MRPHDTO.eColumns.SAFETY_LEADTIME);
            sb.AppendLine("  ," + MRPHDTO.eColumns.MRP_FLAG);
            sb.AppendLine("  ," + MRPHDTO.eColumns.ORDER_CONDITION);
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

            return db.ExecuteForList<MRPHDTO>(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="MRP_NO">Key #1</param>
        /// <param name="ITEM_CD">Key #2</param>
        /// <param name="ORDER_LOC_CD">Key #3</param>
        /// <returns></returns>
        public MRPHDTO LoadByPK(Database database, String MRP_NO, String ITEM_CD, String ORDER_LOC_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(MRPHDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + MRPHDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + MRPHDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + MRPHDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + MRPHDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + MRPHDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + MRPHDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + MRPHDTO.eColumns.IS_ACTIVE);
            sb.AppendLine("  ," + MRPHDTO.eColumns.MRP_NO);
            sb.AppendLine("  ," + MRPHDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + MRPHDTO.eColumns.ORDER_LOC_CD);
            sb.AppendLine("  ," + MRPHDTO.eColumns.REVISION_NO);
            sb.AppendLine("  ," + MRPHDTO.eColumns.ITEM_CLS);
            sb.AppendLine("  ," + MRPHDTO.eColumns.ITEM_DESC);
            sb.AppendLine("  ," + MRPHDTO.eColumns.ORDER_PROCESS_CLS);
            sb.AppendLine("  ," + MRPHDTO.eColumns.LOT_SIZE);
            sb.AppendLine("  ," + MRPHDTO.eColumns.REORDER_POINT);
            sb.AppendLine("  ," + MRPHDTO.eColumns.SAFETY_STOCK);
            sb.AppendLine("  ," + MRPHDTO.eColumns.MINIMUM_ORDER);
            sb.AppendLine("  ," + MRPHDTO.eColumns.INV_UM_CLS);
            sb.AppendLine("  ," + MRPHDTO.eColumns.ORDER_UM_CLS);
            sb.AppendLine("  ," + MRPHDTO.eColumns.INV_UM_RATE);
            sb.AppendLine("  ," + MRPHDTO.eColumns.ORDER_UM_RATE);
            sb.AppendLine("  ," + MRPHDTO.eColumns.MAX_CAPACITY);
            sb.AppendLine("  ," + MRPHDTO.eColumns.LEADTIME);
            sb.AppendLine("  ," + MRPHDTO.eColumns.SAFETY_LEADTIME);
            sb.AppendLine("  ," + MRPHDTO.eColumns.MRP_FLAG);
            sb.AppendLine("  ," + MRPHDTO.eColumns.ORDER_CONDITION);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + MRPHDTO.eColumns.MRP_NO + "=:MRP_NO");
            sb.AppendLine("  AND " + MRPHDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            sb.AppendLine("  AND " + MRPHDTO.eColumns.ORDER_LOC_CD + "=:ORDER_LOC_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("MRP_NO", DataType.NVarChar, MRP_NO);
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, ITEM_CD);
            req.Parameters.Add("ORDER_LOC_CD", DataType.NVarChar, ORDER_LOC_CD);
            #endregion

            List<MRPHDTO> list = db.ExecuteForList<MRPHDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        #endregion
    }
}

