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
    internal partial class MRPDDAO
    {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public MRPDDAO() { }

        public MRPDDAO(Database db)
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
        public int AddNewOrUpdate(Database database, MRPDDTO data)
        {
            Database db = UseDatabase(database);

            if (Exist(database, data.MRP_NO, data.ITEM_CD, data.ORDER_LOC_CD, data.AT_DATE))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, MRPDDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            sb.AppendLine("  " + MRPDDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + MRPDDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + MRPDDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + MRPDDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + MRPDDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + MRPDDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + MRPDDTO.eColumns.IS_ACTIVE);
            sb.AppendLine("  ," + MRPDDTO.eColumns.MRP_NO);
            sb.AppendLine("  ," + MRPDDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + MRPDDTO.eColumns.ORDER_LOC_CD);
            sb.AppendLine("  ," + MRPDDTO.eColumns.AT_DATE);
            sb.AppendLine("  ," + MRPDDTO.eColumns.INCOMING_QTY);
            sb.AppendLine("  ," + MRPDDTO.eColumns.OUTGOING_QTY);
            sb.AppendLine("  ," + MRPDDTO.eColumns.REQ_QTY);
            sb.AppendLine("  ," + MRPDDTO.eColumns.ACT_REQ_QTY);
            sb.AppendLine("  ," + MRPDDTO.eColumns.ACT_REQ_LOT_QTY);
            sb.AppendLine("  ," + MRPDDTO.eColumns.ORDER_QTY);
            sb.AppendLine("  ," + MRPDDTO.eColumns.ON_HAND_QTY);
            sb.AppendLine("  ," + MRPDDTO.eColumns.BAL_QTY);
            sb.AppendLine("  ," + MRPDDTO.eColumns.BAL_LOT_QTY);
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
            sb.AppendLine("   ,:AT_DATE");
            sb.AppendLine("   ,:INCOMING_QTY");
            sb.AppendLine("   ,:OUTGOING_QTY");
            sb.AppendLine("   ,:REQ_QTY");
            sb.AppendLine("   ,:ACT_REQ_QTY");
            sb.AppendLine("   ,:ACT_REQ_LOT_QTY");
            sb.AppendLine("   ,:ORDER_QTY");
            sb.AppendLine("   ,:ON_HAND_QTY");
            sb.AppendLine("   ,:BAL_QTY");
            sb.AppendLine("   ,:BAL_LOT_QTY");
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
            req.Parameters.Add("AT_DATE", DataType.DateTime, data.AT_DATE.Value);
            req.Parameters.Add("INCOMING_QTY", DataType.Number, data.INCOMING_QTY.Value);
            req.Parameters.Add("OUTGOING_QTY", DataType.Number, data.OUTGOING_QTY.Value);
            req.Parameters.Add("REQ_QTY", DataType.Number, data.REQ_QTY.Value);
            req.Parameters.Add("ACT_REQ_QTY", DataType.Number, data.ACT_REQ_QTY.Value);
            req.Parameters.Add("ACT_REQ_LOT_QTY", DataType.Number, data.ACT_REQ_LOT_QTY.Value);
            req.Parameters.Add("ORDER_QTY", DataType.Number, data.ORDER_QTY.Value);
            req.Parameters.Add("ON_HAND_QTY", DataType.Number, data.ON_HAND_QTY.Value);
            req.Parameters.Add("BAL_QTY", DataType.Number, data.BAL_QTY.Value);
            req.Parameters.Add("BAL_LOT_QTY", DataType.Number, data.BAL_LOT_QTY.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using primary key value on the given data variable
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data with primary key value.</param>
        /// <returns></returns>
        public int UpdateWithoutPK(Database database, MRPDDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + MRPDDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + MRPDDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + MRPDDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            sb.AppendLine("  ," + MRPDDTO.eColumns.IS_ACTIVE + "=:IS_ACTIVE");
            sb.AppendLine("  ," + MRPDDTO.eColumns.INCOMING_QTY + "=:INCOMING_QTY");
            sb.AppendLine("  ," + MRPDDTO.eColumns.OUTGOING_QTY + "=:OUTGOING_QTY");
            sb.AppendLine("  ," + MRPDDTO.eColumns.REQ_QTY + "=:REQ_QTY");
            sb.AppendLine("  ," + MRPDDTO.eColumns.ACT_REQ_QTY + "=:ACT_REQ_QTY");
            sb.AppendLine("  ," + MRPDDTO.eColumns.ACT_REQ_LOT_QTY + "=:ACT_REQ_LOT_QTY");
            sb.AppendLine("  ," + MRPDDTO.eColumns.ORDER_QTY + "=:ORDER_QTY");
            sb.AppendLine("  ," + MRPDDTO.eColumns.ON_HAND_QTY + "=:ON_HAND_QTY");
            sb.AppendLine("  ," + MRPDDTO.eColumns.BAL_QTY + "=:BAL_QTY");
            sb.AppendLine("  ," + MRPDDTO.eColumns.BAL_LOT_QTY + "=:BAL_LOT_QTY");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + MRPDDTO.eColumns.MRP_NO + "=:MRP_NO");
            sb.AppendLine("  AND " + MRPDDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            sb.AppendLine("  AND " + MRPDDTO.eColumns.ORDER_LOC_CD + "=:ORDER_LOC_CD");
            sb.AppendLine("  AND " + MRPDDTO.eColumns.AT_DATE + "=:AT_DATE");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("IS_ACTIVE", DataType.Number, data.IS_ACTIVE.Value);
            req.Parameters.Add("MRP_NO", DataType.NVarChar, data.MRP_NO.Value);
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("ORDER_LOC_CD", DataType.NVarChar, data.ORDER_LOC_CD.Value);
            req.Parameters.Add("AT_DATE", DataType.DateTime, data.AT_DATE.Value);
            req.Parameters.Add("INCOMING_QTY", DataType.Number, data.INCOMING_QTY.Value);
            req.Parameters.Add("OUTGOING_QTY", DataType.Number, data.OUTGOING_QTY.Value);
            req.Parameters.Add("REQ_QTY", DataType.Number, data.REQ_QTY.Value);
            req.Parameters.Add("ACT_REQ_QTY", DataType.Number, data.ACT_REQ_QTY.Value);
            req.Parameters.Add("ACT_REQ_LOT_QTY", DataType.Number, data.ACT_REQ_LOT_QTY.Value);
            req.Parameters.Add("ORDER_QTY", DataType.Number, data.ORDER_QTY.Value);
            req.Parameters.Add("ON_HAND_QTY", DataType.Number, data.ON_HAND_QTY.Value);
            req.Parameters.Add("BAL_QTY", DataType.Number, data.BAL_QTY.Value);
            req.Parameters.Add("BAL_LOT_QTY", DataType.Number, data.BAL_LOT_QTY.Value);
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
        /// <param name="oldAT_DATE">Old Key #4</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, MRPDDTO data, String oldMRP_NO, String oldITEM_CD, String oldORDER_LOC_CD, DateTime oldAT_DATE)
        {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + MRPDDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + MRPDDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + MRPDDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            sb.AppendLine("  ," + MRPDDTO.eColumns.IS_ACTIVE + "=:IS_ACTIVE");
            sb.AppendLine("  ," + MRPDDTO.eColumns.MRP_NO + "=:MRP_NO");
            sb.AppendLine("  ," + MRPDDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            sb.AppendLine("  ," + MRPDDTO.eColumns.ORDER_LOC_CD + "=:ORDER_LOC_CD");
            sb.AppendLine("  ," + MRPDDTO.eColumns.AT_DATE + "=:AT_DATE");
            sb.AppendLine("  ," + MRPDDTO.eColumns.INCOMING_QTY + "=:INCOMING_QTY");
            sb.AppendLine("  ," + MRPDDTO.eColumns.OUTGOING_QTY + "=:OUTGOING_QTY");
            sb.AppendLine("  ," + MRPDDTO.eColumns.REQ_QTY + "=:REQ_QTY");
            sb.AppendLine("  ," + MRPDDTO.eColumns.ACT_REQ_QTY + "=:ACT_REQ_QTY");
            sb.AppendLine("  ," + MRPDDTO.eColumns.ACT_REQ_LOT_QTY + "=:ACT_REQ_LOT_QTY");
            sb.AppendLine("  ," + MRPDDTO.eColumns.ORDER_QTY + "=:ORDER_QTY");
            sb.AppendLine("  ," + MRPDDTO.eColumns.ON_HAND_QTY + "=:ON_HAND_QTY");
            sb.AppendLine("  ," + MRPDDTO.eColumns.BAL_QTY + "=:BAL_QTY");
            sb.AppendLine("  ," + MRPDDTO.eColumns.BAL_LOT_QTY + "=:BAL_LOT_QTY");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + MRPDDTO.eColumns.MRP_NO + "=:oldMRP_NO");
            sb.AppendLine("  AND " + MRPDDTO.eColumns.ITEM_CD + "=:oldMRPD");
            sb.AppendLine("  AND " + MRPDDTO.eColumns.ORDER_LOC_CD + "=:oldMRPD");
            sb.AppendLine("  AND " + MRPDDTO.eColumns.AT_DATE + "=:oldMRPD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("IS_ACTIVE", DataType.Number, data.IS_ACTIVE.Value);
            req.Parameters.Add("MRP_NO", DataType.NVarChar, data.MRP_NO.Value);
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("ORDER_LOC_CD", DataType.NVarChar, data.ORDER_LOC_CD.Value);
            req.Parameters.Add("AT_DATE", DataType.DateTime, data.AT_DATE.Value);
            req.Parameters.Add("INCOMING_QTY", DataType.Number, data.INCOMING_QTY.Value);
            req.Parameters.Add("OUTGOING_QTY", DataType.Number, data.OUTGOING_QTY.Value);
            req.Parameters.Add("REQ_QTY", DataType.Number, data.REQ_QTY.Value);
            req.Parameters.Add("ACT_REQ_QTY", DataType.Number, data.ACT_REQ_QTY.Value);
            req.Parameters.Add("ACT_REQ_LOT_QTY", DataType.Number, data.ACT_REQ_LOT_QTY.Value);
            req.Parameters.Add("ORDER_QTY", DataType.Number, data.ORDER_QTY.Value);
            req.Parameters.Add("ON_HAND_QTY", DataType.Number, data.ON_HAND_QTY.Value);
            req.Parameters.Add("BAL_QTY", DataType.Number, data.BAL_QTY.Value);
            req.Parameters.Add("BAL_LOT_QTY", DataType.Number, data.BAL_LOT_QTY.Value);
            req.Parameters.Add("oldMRP_NO", DataType.NVarChar, oldMRP_NO);
            req.Parameters.Add("oldITEM_CD", DataType.NVarChar, oldITEM_CD);
            req.Parameters.Add("oldORDER_LOC_CD", DataType.NVarChar, oldORDER_LOC_CD);
            req.Parameters.Add("oldAT_DATE", DataType.DateTime, oldAT_DATE);
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
        /// <param name="AT_DATE">Key #4</param>
        /// <returns></returns>
        public int Delete(Database database, String MRP_NO, String ITEM_CD, String ORDER_LOC_CD, DateTime AT_DATE)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(MRPDDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + MRPDDTO.eColumns.MRP_NO + "=:MRP_NO");
            sb.AppendLine("  AND " + MRPDDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            sb.AppendLine("  AND " + MRPDDTO.eColumns.ORDER_LOC_CD + "=:ORDER_LOC_CD");
            sb.AppendLine("  AND " + MRPDDTO.eColumns.AT_DATE + "=:AT_DATE");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("MRP_NO", DataType.NVarChar, MRP_NO);
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, ITEM_CD);
            req.Parameters.Add("ORDER_LOC_CD", DataType.NVarChar, ORDER_LOC_CD);
            req.Parameters.Add("AT_DATE", DataType.DateTime, AT_DATE);
            #endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, String MRP_NO, String ITEM_CD, String ORDER_LOC_CD, DateTime AT_DATE)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(MRPDDTO));

            sb.AppendLine(" SELECT TOP 1 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + MRPDDTO.eColumns.MRP_NO + "=:MRP_NO");
            sb.AppendLine("  AND " + MRPDDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            sb.AppendLine("  AND " + MRPDDTO.eColumns.ORDER_LOC_CD + "=:ORDER_LOC_CD");
            sb.AppendLine("  AND " + MRPDDTO.eColumns.AT_DATE + "=:AT_DATE");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("MRP_NO", DataType.NVarChar, MRP_NO);
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, ITEM_CD);
            req.Parameters.Add("ORDER_LOC_CD", DataType.NVarChar, ORDER_LOC_CD);
            req.Parameters.Add("AT_DATE", DataType.DateTime, AT_DATE);
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
        public List<MRPDDTO> LoadAll(Database database)
        {
            return LoadAll(database, true,
                MRPDDTO.eColumns.MRP_NO
                , MRPDDTO.eColumns.ITEM_CD
                , MRPDDTO.eColumns.ORDER_LOC_CD
                , MRPDDTO.eColumns.AT_DATE
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<MRPDDTO> LoadAll(Database database, bool ascending)
        {
            return LoadAll(database, ascending,
                MRPDDTO.eColumns.MRP_NO
                , MRPDDTO.eColumns.ITEM_CD
                , MRPDDTO.eColumns.ORDER_LOC_CD
                , MRPDDTO.eColumns.AT_DATE
            );
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<MRPDDTO> LoadAll(Database database, bool ascending, params MRPDDTO.eColumns[] orderByColumns)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(MRPDDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + MRPDDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + MRPDDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + MRPDDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + MRPDDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + MRPDDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + MRPDDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + MRPDDTO.eColumns.IS_ACTIVE);
            sb.AppendLine("  ," + MRPDDTO.eColumns.MRP_NO);
            sb.AppendLine("  ," + MRPDDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + MRPDDTO.eColumns.ORDER_LOC_CD);
            sb.AppendLine("  ," + MRPDDTO.eColumns.AT_DATE);
            sb.AppendLine("  ," + MRPDDTO.eColumns.INCOMING_QTY);
            sb.AppendLine("  ," + MRPDDTO.eColumns.OUTGOING_QTY);
            sb.AppendLine("  ," + MRPDDTO.eColumns.REQ_QTY);
            sb.AppendLine("  ," + MRPDDTO.eColumns.ACT_REQ_QTY);
            sb.AppendLine("  ," + MRPDDTO.eColumns.ACT_REQ_LOT_QTY);
            sb.AppendLine("  ," + MRPDDTO.eColumns.ORDER_QTY);
            sb.AppendLine("  ," + MRPDDTO.eColumns.ON_HAND_QTY);
            sb.AppendLine("  ," + MRPDDTO.eColumns.BAL_QTY);
            sb.AppendLine("  ," + MRPDDTO.eColumns.BAL_LOT_QTY);
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

            return db.ExecuteForList<MRPDDTO>(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="MRP_NO">Key #1</param>
        /// <param name="ITEM_CD">Key #2</param>
        /// <param name="ORDER_LOC_CD">Key #3</param>
        /// <param name="AT_DATE">Key #4</param>
        /// <returns></returns>
        public MRPDDTO LoadByPK(Database database, String MRP_NO, String ITEM_CD, String ORDER_LOC_CD, DateTime AT_DATE)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(MRPDDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + MRPDDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + MRPDDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + MRPDDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + MRPDDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + MRPDDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + MRPDDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + MRPDDTO.eColumns.IS_ACTIVE);
            sb.AppendLine("  ," + MRPDDTO.eColumns.MRP_NO);
            sb.AppendLine("  ," + MRPDDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + MRPDDTO.eColumns.ORDER_LOC_CD);
            sb.AppendLine("  ," + MRPDDTO.eColumns.AT_DATE);
            sb.AppendLine("  ," + MRPDDTO.eColumns.INCOMING_QTY);
            sb.AppendLine("  ," + MRPDDTO.eColumns.OUTGOING_QTY);
            sb.AppendLine("  ," + MRPDDTO.eColumns.REQ_QTY);
            sb.AppendLine("  ," + MRPDDTO.eColumns.ACT_REQ_QTY);
            sb.AppendLine("  ," + MRPDDTO.eColumns.ACT_REQ_LOT_QTY);
            sb.AppendLine("  ," + MRPDDTO.eColumns.ORDER_QTY);
            sb.AppendLine("  ," + MRPDDTO.eColumns.ON_HAND_QTY);
            sb.AppendLine("  ," + MRPDDTO.eColumns.BAL_QTY);
            sb.AppendLine("  ," + MRPDDTO.eColumns.BAL_LOT_QTY);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + MRPDDTO.eColumns.MRP_NO + "=:MRP_NO");
            sb.AppendLine("  AND " + MRPDDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            sb.AppendLine("  AND " + MRPDDTO.eColumns.ORDER_LOC_CD + "=:ORDER_LOC_CD");
            sb.AppendLine("  AND " + MRPDDTO.eColumns.AT_DATE + "=:AT_DATE");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("MRP_NO", DataType.NVarChar, MRP_NO);
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, ITEM_CD);
            req.Parameters.Add("ORDER_LOC_CD", DataType.NVarChar, ORDER_LOC_CD);
            req.Parameters.Add("AT_DATE", DataType.DateTime, AT_DATE);
            #endregion

            List<MRPDDTO> list = db.ExecuteForList<MRPDDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        #endregion
    }
}

