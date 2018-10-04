/* Create by: Mr.Teerayut Sinlan
 * Create on: 2554-06-17
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
    internal partial class PurchaseOrderDDAO
    {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public PurchaseOrderDDAO() { }

        public PurchaseOrderDDAO(Database db)
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
        public int AddNewOrUpdate(Database database, PurchaseOrderDDTO data)
        {
            Database db = UseDatabase(database);

            if (Exist(database, data.PO_NO, data.PO_LINE))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, PurchaseOrderDDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            sb.AppendLine("  " + PurchaseOrderDDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.IS_ACTIVE);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.PO_NO);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.PO_LINE);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.ITEM_DESC);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.DUE_DATE);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.UNIT_PRICE);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.PO_QTY);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.UNIT);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.AMOUNT);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.RECEIVE_QTY);
            //sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.BACK_ORDER_QTY);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.LAST_RECEIVE_ID);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.LAST_RECEIVE_DATE);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.STATUS);
            sb.AppendLine(") VALUES(");
            sb.AppendLine("   :CRT_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,:CRT_MACHINE");
            sb.AppendLine("   ,:UPD_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,:UPD_MACHINE");
            sb.AppendLine("   ,:IS_ACTIVE");
            sb.AppendLine("   ,:PO_NO");
            sb.AppendLine("   ,:PO_LINE");
            sb.AppendLine("   ,:ITEM_CD");
            sb.AppendLine("   ,:ITEM_DESC");
            sb.AppendLine("   ,:DUE_DATE");
            sb.AppendLine("   ,:UNIT_PRICE");
            sb.AppendLine("   ,:PO_QTY");
            sb.AppendLine("   ,:UNIT");
            sb.AppendLine("   ,:AMOUNT");
            sb.AppendLine("   ,:RECEIVE_QTY");
            //sb.AppendLine("   ,:BACK_ORDER_QTY");
            sb.AppendLine("   ,:LAST_RECEIVE_ID");
            sb.AppendLine("   ,:LAST_RECEIVE_DATE");
            sb.AppendLine("   ,:STATUS");
            sb.AppendLine(" )");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("CRT_BY", DataType.NVarChar, data.CRT_BY.Value);
            req.Parameters.Add("CRT_MACHINE", DataType.NVarChar, data.CRT_MACHINE.Value);
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("IS_ACTIVE", DataType.Default, data.IS_ACTIVE.Value);
            req.Parameters.Add("PO_NO", DataType.NVarChar, data.PO_NO.Value);
            req.Parameters.Add("PO_LINE", DataType.Number, data.PO_LINE.Value);
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("ITEM_DESC", DataType.NVarChar, data.ITEM_DESC.Value);
            req.Parameters.Add("DUE_DATE", DataType.Default, data.DUE_DATE.Value);
            req.Parameters.Add("UNIT_PRICE", DataType.Number, data.UNIT_PRICE.Value);
            req.Parameters.Add("PO_QTY", DataType.Number, data.PO_QTY.Value);
            req.Parameters.Add("UNIT", DataType.NVarChar, data.UNIT.Value);
            req.Parameters.Add("AMOUNT", DataType.Number, data.AMOUNT.Value);
            req.Parameters.Add("RECEIVE_QTY", DataType.Number, data.RECEIVE_QTY.Value);
            //req.Parameters.Add("BACK_ORDER_QTY", DataType.Number, data.BACK_ORDER_QTY.Value);
            req.Parameters.Add("LAST_RECEIVE_ID", DataType.NVarChar, data.LAST_RECEIVE_ID.Value);
            req.Parameters.Add("LAST_RECEIVE_DATE", DataType.DateTime, data.LAST_RECEIVE_DATE.Value);
            req.Parameters.Add("STATUS", DataType.NVarChar, data.STATUS.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using primary key value on the given data variable
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data with primary key value.</param>
        /// <returns></returns>
        public int UpdateWithoutPK(Database database, PurchaseOrderDDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + PurchaseOrderDDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.IS_ACTIVE + "=:IS_ACTIVE");
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.ITEM_DESC + "=:ITEM_DESC");
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.DUE_DATE + "=:DUE_DATE");
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.UNIT_PRICE + "=:UNIT_PRICE");
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.PO_QTY + "=:PO_QTY");
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.UNIT + "=:UNIT");
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.AMOUNT + "=:AMOUNT");
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.RECEIVE_QTY + "=:RECEIVE_QTY");
            //sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.BACK_ORDER_QTY + "=:BACK_ORDER_QTY");
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.LAST_RECEIVE_ID + "=:LAST_RECEIVE_ID");
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.LAST_RECEIVE_DATE + "=:LAST_RECEIVE_DATE");
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.STATUS + "=:STATUS");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + PurchaseOrderDDTO.eColumns.PO_NO + "=:PO_NO");
            sb.AppendLine("  AND " + PurchaseOrderDDTO.eColumns.PO_LINE + "=:PO_LINE");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("IS_ACTIVE", DataType.Default, data.IS_ACTIVE.Value);
            req.Parameters.Add("PO_NO", DataType.NVarChar, data.PO_NO.Value);
            req.Parameters.Add("PO_LINE", DataType.Number, data.PO_LINE.Value);
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("ITEM_DESC", DataType.NVarChar, data.ITEM_DESC.Value);
            req.Parameters.Add("DUE_DATE", DataType.Default, data.DUE_DATE.Value);
            req.Parameters.Add("UNIT_PRICE", DataType.Number, data.UNIT_PRICE.Value);
            req.Parameters.Add("PO_QTY", DataType.Number, data.PO_QTY.Value);
            req.Parameters.Add("UNIT", DataType.NVarChar, data.UNIT.Value);
            req.Parameters.Add("AMOUNT", DataType.Number, data.AMOUNT.Value);
            req.Parameters.Add("RECEIVE_QTY", DataType.Number, data.RECEIVE_QTY.Value);
            //req.Parameters.Add("BACK_ORDER_QTY", DataType.Number, data.BACK_ORDER_QTY.Value);
            req.Parameters.Add("LAST_RECEIVE_ID", DataType.NVarChar, data.LAST_RECEIVE_ID.Value);
            req.Parameters.Add("LAST_RECEIVE_DATE", DataType.DateTime, data.LAST_RECEIVE_DATE.Value);
            req.Parameters.Add("STATUS", DataType.NVarChar, data.STATUS.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using the table's primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data which to update.</param>
        /// <param name="oldPO_NO">Old Key #1</param>
        /// <param name="oldPO_LINE">Old Key #2</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, PurchaseOrderDDTO data, String oldPO_NO, Decimal oldPO_LINE)
        {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + PurchaseOrderDDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.IS_ACTIVE + "=:IS_ACTIVE");
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.PO_NO + "=:PO_NO");
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.PO_LINE + "=:PO_LINE");
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.ITEM_DESC + "=:ITEM_DESC");
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.DUE_DATE + "=:DUE_DATE");
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.UNIT_PRICE + "=:UNIT_PRICE");
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.PO_QTY + "=:PO_QTY");
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.UNIT + "=:UNIT");
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.AMOUNT + "=:AMOUNT");
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.RECEIVE_QTY + "=:RECEIVE_QTY");
            //sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.BACK_ORDER_QTY + "=:BACK_ORDER_QTY");
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.LAST_RECEIVE_ID + "=:LAST_RECEIVE_ID");
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.LAST_RECEIVE_DATE + "=:LAST_RECEIVE_DATE");
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.STATUS + "=:STATUS");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + PurchaseOrderDDTO.eColumns.PO_NO + "=:oldPO_NO");
            sb.AppendLine("  AND " + PurchaseOrderDDTO.eColumns.PO_LINE + "=:oldPurchaseOrderD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("IS_ACTIVE", DataType.Default, data.IS_ACTIVE.Value);
            req.Parameters.Add("PO_NO", DataType.NVarChar, data.PO_NO.Value);
            req.Parameters.Add("PO_LINE", DataType.Number, data.PO_LINE.Value);
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("ITEM_DESC", DataType.NVarChar, data.ITEM_DESC.Value);
            req.Parameters.Add("DUE_DATE", DataType.Default, data.DUE_DATE.Value);
            req.Parameters.Add("UNIT_PRICE", DataType.Number, data.UNIT_PRICE.Value);
            req.Parameters.Add("PO_QTY", DataType.Number, data.PO_QTY.Value);
            req.Parameters.Add("UNIT", DataType.NVarChar, data.UNIT.Value);
            req.Parameters.Add("AMOUNT", DataType.Number, data.AMOUNT.Value);
            req.Parameters.Add("RECEIVE_QTY", DataType.Number, data.RECEIVE_QTY.Value);
            //req.Parameters.Add("BACK_ORDER_QTY", DataType.Number, data.BACK_ORDER_QTY.Value);
            req.Parameters.Add("LAST_RECEIVE_ID", DataType.NVarChar, data.LAST_RECEIVE_ID.Value);
            req.Parameters.Add("LAST_RECEIVE_DATE", DataType.DateTime, data.LAST_RECEIVE_DATE.Value);
            req.Parameters.Add("STATUS", DataType.NVarChar, data.STATUS.Value);
            req.Parameters.Add("oldPO_NO", DataType.NVarChar, oldPO_NO);
            req.Parameters.Add("oldPO_LINE", DataType.Number, oldPO_LINE);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="PO_NO">Key #1</param>
        /// <param name="PO_LINE">Key #2</param>
        /// <returns></returns>
        public int Delete(Database database, String PO_NO, Decimal PO_LINE)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(PurchaseOrderDDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + PurchaseOrderDDTO.eColumns.PO_NO + "=:PO_NO");
            sb.AppendLine("  AND " + PurchaseOrderDDTO.eColumns.PO_LINE + "=:PO_LINE");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("PO_NO", DataType.NVarChar, PO_NO);
            req.Parameters.Add("PO_LINE", DataType.Number, PO_LINE);
            #endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, String PO_NO, Decimal PO_LINE)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(PurchaseOrderDDTO));

            sb.AppendLine(" SELECT TOP 1 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + PurchaseOrderDDTO.eColumns.PO_NO + "=:PO_NO");
            sb.AppendLine("  AND " + PurchaseOrderDDTO.eColumns.PO_LINE + "=:PO_LINE");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("PO_NO", DataType.NVarChar, PO_NO);
            req.Parameters.Add("PO_LINE", DataType.Number, PO_LINE);
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
        public List<PurchaseOrderDDTO> LoadAll(Database database)
        {
            return LoadAll(database, true,
                PurchaseOrderDDTO.eColumns.PO_NO
                , PurchaseOrderDDTO.eColumns.PO_LINE
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<PurchaseOrderDDTO> LoadAll(Database database, bool ascending)
        {
            return LoadAll(database, ascending,
                PurchaseOrderDDTO.eColumns.PO_NO
                , PurchaseOrderDDTO.eColumns.PO_LINE
            );
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<PurchaseOrderDDTO> LoadAll(Database database, bool ascending, params PurchaseOrderDDTO.eColumns[] orderByColumns)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(PurchaseOrderDDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + PurchaseOrderDDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.IS_ACTIVE);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.PO_NO);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.PO_LINE);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.ITEM_DESC);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.DUE_DATE);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.UNIT_PRICE);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.PO_QTY);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.UNIT);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.AMOUNT);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.RECEIVE_QTY);
            //sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.BACK_ORDER_QTY);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.LAST_RECEIVE_ID);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.LAST_RECEIVE_DATE);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.STATUS);
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

            return db.ExecuteForList<PurchaseOrderDDTO>(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="PO_NO">Key #1</param>
        /// <param name="PO_LINE">Key #2</param>
        /// <returns></returns>
        public PurchaseOrderDDTO LoadByPK(Database database, String PO_NO, Decimal PO_LINE)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(PurchaseOrderDDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + PurchaseOrderDDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.IS_ACTIVE);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.PO_NO);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.PO_LINE);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.ITEM_DESC);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.DUE_DATE);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.UNIT_PRICE);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.PO_QTY);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.UNIT);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.AMOUNT);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.RECEIVE_QTY);
            //sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.BACK_ORDER_QTY);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.LAST_RECEIVE_ID);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.LAST_RECEIVE_DATE);
            sb.AppendLine("  ," + PurchaseOrderDDTO.eColumns.STATUS);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + PurchaseOrderDDTO.eColumns.PO_NO + "=:PO_NO");
            sb.AppendLine("  AND " + PurchaseOrderDDTO.eColumns.PO_LINE + "=:PO_LINE");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("PO_NO", DataType.NVarChar, PO_NO);
            req.Parameters.Add("PO_LINE", DataType.Number, PO_LINE);
            #endregion

            List<PurchaseOrderDDTO> list = db.ExecuteForList<PurchaseOrderDDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        #endregion
    }
}

