/* Create by: Ms. Sansanee K.
 * Create on: 2011-06-28
 * Company: CSI Groups (Thailand)
 * Group: SI-EVO
 
 *** This generate source code was build for DAO on StarterKit system. ***/
using System;
using System.Collections.Generic;
using System.Text;
using EVOFramework.Database;
using EVOFramework;
using Rubik.DTO;


namespace Rubik.DAO {
    public partial class TmpPurchaseOrderDAO {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public TmpPurchaseOrderDAO() { }

        public TmpPurchaseOrderDAO(Database db) {
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
        public int AddNewOrUpdate(Database database, TmpPurchaseOrderDTO data) {
            Database db = UseDatabase(database);

            if (Exist(database))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, TmpPurchaseOrderDTO data) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            sb.AppendLine("  " + TmpPurchaseOrderDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.IS_ACTIVE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.PO_GROUP);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.PO_NO);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.PO_TYPE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.PO_DATE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.SUPPLIER_CD);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.SUPPLIER_NAME);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.ADDRESS);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.DELIVERY_TO);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.DELIVERY_TO_NAME);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.DELIVERY_TO_ADDRESS);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.CURRENCY);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.VAT_TYPE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.VAT_RATE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.TERM_OF_PAYMENT);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.IS_EXPORT);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.STATUS);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.REMARK);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.PO_LINE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.ITEM_DESC);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.DUE_DATE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.UNIT_PRICE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.PO_QTY);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.UNIT);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.AMOUNT);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.RECEIVE_QTY);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.BACK_ORDER_QTY);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.LAST_RECEIVE_ID);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.LAST_RECEIVE_DATE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.RECORD_STATUS);
            sb.AppendLine(") VALUES(");
            sb.AppendLine("   :CRT_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,:CRT_MACHINE");
            sb.AppendLine("   ,:UPD_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,:UPD_MACHINE");
            sb.AppendLine("   ,:IS_ACTIVE");
            sb.AppendLine("   ,:PO_GROUP");
            sb.AppendLine("   ,:PO_NO");
            sb.AppendLine("   ,:PO_TYPE");
            sb.AppendLine("   ,:PO_DATE");
            sb.AppendLine("   ,:SUPPLIER_CD");
            sb.AppendLine("   ,:SUPPLIER_NAME");
            sb.AppendLine("   ,:ADDRESS");
            sb.AppendLine("   ,:DELIVERY_TO");
            sb.AppendLine("   ,:DELIVERY_TO_NAME");
            sb.AppendLine("   ,:DELIVERY_TO_ADDRESS");
            sb.AppendLine("   ,:CURRENCY");
            sb.AppendLine("   ,:VAT_TYPE");
            sb.AppendLine("   ,:VAT_RATE");
            sb.AppendLine("   ,:TERM_OF_PAYMENT");
            sb.AppendLine("   ,:IS_EXPORT");
            sb.AppendLine("   ,:STATUS");
            sb.AppendLine("   ,:REMARK");
            sb.AppendLine("   ,:PO_LINE");
            sb.AppendLine("   ,:ITEM_CD");
            sb.AppendLine("   ,:ITEM_DESC");
            sb.AppendLine("   ,:DUE_DATE");
            sb.AppendLine("   ,:UNIT_PRICE");
            sb.AppendLine("   ,:PO_QTY");
            sb.AppendLine("   ,:UNIT");
            sb.AppendLine("   ,:AMOUNT");
            sb.AppendLine("   ,:RECEIVE_QTY");
            sb.AppendLine("   ,:BACK_ORDER_QTY");
            sb.AppendLine("   ,:LAST_RECEIVE_ID");
            sb.AppendLine("   ,:LAST_RECEIVE_DATE");
            sb.AppendLine("   ,:RECORD_STATUS");
            sb.AppendLine(" )");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("CRT_BY", DataType.NVarChar, data.CRT_BY.Value);
            req.Parameters.Add("CRT_MACHINE", DataType.NVarChar, data.CRT_MACHINE.Value);
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("IS_ACTIVE", DataType.Default, data.IS_ACTIVE.Value);
            req.Parameters.Add("PO_GROUP", DataType.Default, data.PO_GROUP.Value);
            req.Parameters.Add("PO_NO", DataType.NVarChar, data.PO_NO.Value);
            req.Parameters.Add("PO_TYPE", DataType.NVarChar, data.PO_TYPE.Value);
            req.Parameters.Add("PO_DATE", DataType.Default, data.PO_DATE.Value);
            req.Parameters.Add("SUPPLIER_CD", DataType.NVarChar, data.SUPPLIER_CD.Value);
            req.Parameters.Add("SUPPLIER_NAME", DataType.NVarChar, data.SUPPLIER_NAME.Value);
            req.Parameters.Add("ADDRESS", DataType.NVarChar, data.ADDRESS.Value);
            req.Parameters.Add("DELIVERY_TO", DataType.NVarChar, data.DELIVERY_TO.Value);
            req.Parameters.Add("DELIVERY_TO_NAME", DataType.NVarChar, data.DELIVERY_TO_NAME.Value);
            req.Parameters.Add("DELIVERY_TO_ADDRESS", DataType.NVarChar, data.DELIVERY_TO_ADDRESS.Value);
            req.Parameters.Add("CURRENCY", DataType.NVarChar, data.CURRENCY.Value);
            req.Parameters.Add("VAT_TYPE", DataType.NVarChar, data.VAT_TYPE.Value);
            req.Parameters.Add("VAT_RATE", DataType.Number, data.VAT_RATE.Value);
            req.Parameters.Add("TERM_OF_PAYMENT", DataType.NVarChar, data.TERM_OF_PAYMENT.Value);
            req.Parameters.Add("IS_EXPORT", DataType.Default, data.IS_EXPORT.Value);
            req.Parameters.Add("STATUS", DataType.NVarChar, data.STATUS.Value);
            req.Parameters.Add("REMARK", DataType.NVarChar, data.REMARK.Value);
            req.Parameters.Add("PO_LINE", DataType.Number, data.PO_LINE.Value);
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("ITEM_DESC", DataType.NVarChar, data.ITEM_DESC.Value);
            req.Parameters.Add("DUE_DATE", DataType.Default, data.DUE_DATE.Value);
            req.Parameters.Add("UNIT_PRICE", DataType.Number, data.UNIT_PRICE.Value);
            req.Parameters.Add("PO_QTY", DataType.Number, data.PO_QTY.Value);
            req.Parameters.Add("UNIT", DataType.NVarChar, data.UNIT.Value);
            req.Parameters.Add("AMOUNT", DataType.Number, data.AMOUNT.Value);
            req.Parameters.Add("RECEIVE_QTY", DataType.Number, data.RECEIVE_QTY.Value);
            req.Parameters.Add("BACK_ORDER_QTY", DataType.Number, data.BACK_ORDER_QTY.Value);
            req.Parameters.Add("LAST_RECEIVE_ID", DataType.NVarChar, data.LAST_RECEIVE_ID.Value);
            req.Parameters.Add("LAST_RECEIVE_DATE", DataType.DateTime, data.LAST_RECEIVE_DATE.Value);
            req.Parameters.Add("RECORD_STATUS", DataType.NVarChar, data.RECORD_STATUS.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using primary key value on the given data variable
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data with primary key value.</param>
        /// <returns></returns>
        public int UpdateWithoutPK(Database database, TmpPurchaseOrderDTO data) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + TmpPurchaseOrderDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.IS_ACTIVE + "=:IS_ACTIVE");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.PO_GROUP + "=:PO_GROUP");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.PO_NO + "=:PO_NO");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.PO_TYPE + "=:PO_TYPE");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.PO_DATE + "=:PO_DATE");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.SUPPLIER_CD + "=:SUPPLIER_CD");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.SUPPLIER_NAME + "=:SUPPLIER_NAME");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.ADDRESS + "=:ADDRESS");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.DELIVERY_TO + "=:DELIVERY_TO");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.DELIVERY_TO_NAME + "=:DELIVERY_TO_NAME");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.DELIVERY_TO_ADDRESS + "=:DELIVERY_TO_ADDRESS");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.CURRENCY + "=:CURRENCY");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.VAT_TYPE + "=:VAT_TYPE");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.VAT_RATE + "=:VAT_RATE");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.TERM_OF_PAYMENT + "=:TERM_OF_PAYMENT");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.IS_EXPORT + "=:IS_EXPORT");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.STATUS + "=:STATUS");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.REMARK + "=:REMARK");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.PO_LINE + "=:PO_LINE");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.ITEM_DESC + "=:ITEM_DESC");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.DUE_DATE + "=:DUE_DATE");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.UNIT_PRICE + "=:UNIT_PRICE");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.PO_QTY + "=:PO_QTY");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.UNIT + "=:UNIT");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.AMOUNT + "=:AMOUNT");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.RECEIVE_QTY + "=:RECEIVE_QTY");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.BACK_ORDER_QTY + "=:BACK_ORDER_QTY");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.LAST_RECEIVE_ID + "=:LAST_RECEIVE_ID");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.LAST_RECEIVE_DATE + "=:LAST_RECEIVE_DATE");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.RECORD_STATUS + "=:RECORD_STATUS");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("IS_ACTIVE", DataType.Default, data.IS_ACTIVE.Value);
            req.Parameters.Add("PO_GROUP", DataType.Default, data.PO_GROUP.Value);
            req.Parameters.Add("PO_NO", DataType.NVarChar, data.PO_NO.Value);
            req.Parameters.Add("PO_TYPE", DataType.NVarChar, data.PO_TYPE.Value);
            req.Parameters.Add("PO_DATE", DataType.Default, data.PO_DATE.Value);
            req.Parameters.Add("SUPPLIER_CD", DataType.NVarChar, data.SUPPLIER_CD.Value);
            req.Parameters.Add("SUPPLIER_NAME", DataType.NVarChar, data.SUPPLIER_NAME.Value);
            req.Parameters.Add("ADDRESS", DataType.NVarChar, data.ADDRESS.Value);
            req.Parameters.Add("DELIVERY_TO", DataType.NVarChar, data.DELIVERY_TO.Value);
            req.Parameters.Add("DELIVERY_TO_NAME", DataType.NVarChar, data.DELIVERY_TO_NAME.Value);
            req.Parameters.Add("DELIVERY_TO_ADDRESS", DataType.NVarChar, data.DELIVERY_TO_ADDRESS.Value);
            req.Parameters.Add("CURRENCY", DataType.NVarChar, data.CURRENCY.Value);
            req.Parameters.Add("VAT_TYPE", DataType.NVarChar, data.VAT_TYPE.Value);
            req.Parameters.Add("VAT_RATE", DataType.Number, data.VAT_RATE.Value);
            req.Parameters.Add("TERM_OF_PAYMENT", DataType.NVarChar, data.TERM_OF_PAYMENT.Value);
            req.Parameters.Add("IS_EXPORT", DataType.Default, data.IS_EXPORT.Value);
            req.Parameters.Add("STATUS", DataType.NVarChar, data.STATUS.Value);
            req.Parameters.Add("REMARK", DataType.NVarChar, data.REMARK.Value);
            req.Parameters.Add("PO_LINE", DataType.Number, data.PO_LINE.Value);
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("ITEM_DESC", DataType.NVarChar, data.ITEM_DESC.Value);
            req.Parameters.Add("DUE_DATE", DataType.Default, data.DUE_DATE.Value);
            req.Parameters.Add("UNIT_PRICE", DataType.Number, data.UNIT_PRICE.Value);
            req.Parameters.Add("PO_QTY", DataType.Number, data.PO_QTY.Value);
            req.Parameters.Add("UNIT", DataType.NVarChar, data.UNIT.Value);
            req.Parameters.Add("AMOUNT", DataType.Number, data.AMOUNT.Value);
            req.Parameters.Add("RECEIVE_QTY", DataType.Number, data.RECEIVE_QTY.Value);
            req.Parameters.Add("BACK_ORDER_QTY", DataType.Number, data.BACK_ORDER_QTY.Value);
            req.Parameters.Add("LAST_RECEIVE_ID", DataType.NVarChar, data.LAST_RECEIVE_ID.Value);
            req.Parameters.Add("LAST_RECEIVE_DATE", DataType.DateTime, data.LAST_RECEIVE_DATE.Value);
            req.Parameters.Add("RECORD_STATUS", DataType.NVarChar, data.RECORD_STATUS.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using the table's primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data which to update.</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, TmpPurchaseOrderDTO data) {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + TmpPurchaseOrderDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.IS_ACTIVE + "=:IS_ACTIVE");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.PO_GROUP + "=:PO_GROUP");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.PO_NO + "=:PO_NO");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.PO_TYPE + "=:PO_TYPE");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.PO_DATE + "=:PO_DATE");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.SUPPLIER_CD + "=:SUPPLIER_CD");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.SUPPLIER_NAME + "=:SUPPLIER_NAME");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.ADDRESS + "=:ADDRESS");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.DELIVERY_TO + "=:DELIVERY_TO");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.DELIVERY_TO_NAME + "=:DELIVERY_TO_NAME");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.DELIVERY_TO_ADDRESS + "=:DELIVERY_TO_ADDRESS");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.CURRENCY + "=:CURRENCY");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.VAT_TYPE + "=:VAT_TYPE");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.VAT_RATE + "=:VAT_RATE");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.TERM_OF_PAYMENT + "=:TERM_OF_PAYMENT");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.IS_EXPORT + "=:IS_EXPORT");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.STATUS + "=:STATUS");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.REMARK + "=:REMARK");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.PO_LINE + "=:PO_LINE");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.ITEM_DESC + "=:ITEM_DESC");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.DUE_DATE + "=:DUE_DATE");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.UNIT_PRICE + "=:UNIT_PRICE");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.PO_QTY + "=:PO_QTY");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.UNIT + "=:UNIT");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.AMOUNT + "=:AMOUNT");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.RECEIVE_QTY + "=:RECEIVE_QTY");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.BACK_ORDER_QTY + "=:BACK_ORDER_QTY");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.LAST_RECEIVE_ID + "=:LAST_RECEIVE_ID");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.LAST_RECEIVE_DATE + "=:LAST_RECEIVE_DATE");
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.RECORD_STATUS + "=:RECORD_STATUS");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("IS_ACTIVE", DataType.Default, data.IS_ACTIVE.Value);
            req.Parameters.Add("PO_GROUP", DataType.Default, data.PO_GROUP.Value);
            req.Parameters.Add("PO_NO", DataType.NVarChar, data.PO_NO.Value);
            req.Parameters.Add("PO_TYPE", DataType.NVarChar, data.PO_TYPE.Value);
            req.Parameters.Add("PO_DATE", DataType.Default, data.PO_DATE.Value);
            req.Parameters.Add("SUPPLIER_CD", DataType.NVarChar, data.SUPPLIER_CD.Value);
            req.Parameters.Add("SUPPLIER_NAME", DataType.NVarChar, data.SUPPLIER_NAME.Value);
            req.Parameters.Add("ADDRESS", DataType.NVarChar, data.ADDRESS.Value);
            req.Parameters.Add("DELIVERY_TO", DataType.NVarChar, data.DELIVERY_TO.Value);
            req.Parameters.Add("DELIVERY_TO_NAME", DataType.NVarChar, data.DELIVERY_TO_NAME.Value);
            req.Parameters.Add("DELIVERY_TO_ADDRESS", DataType.NVarChar, data.DELIVERY_TO_ADDRESS.Value);
            req.Parameters.Add("CURRENCY", DataType.NVarChar, data.CURRENCY.Value);
            req.Parameters.Add("VAT_TYPE", DataType.NVarChar, data.VAT_TYPE.Value);
            req.Parameters.Add("VAT_RATE", DataType.Number, data.VAT_RATE.Value);
            req.Parameters.Add("TERM_OF_PAYMENT", DataType.NVarChar, data.TERM_OF_PAYMENT.Value);
            req.Parameters.Add("IS_EXPORT", DataType.Default, data.IS_EXPORT.Value);
            req.Parameters.Add("STATUS", DataType.NVarChar, data.STATUS.Value);
            req.Parameters.Add("REMARK", DataType.NVarChar, data.REMARK.Value);
            req.Parameters.Add("PO_LINE", DataType.Number, data.PO_LINE.Value);
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("ITEM_DESC", DataType.NVarChar, data.ITEM_DESC.Value);
            req.Parameters.Add("DUE_DATE", DataType.Default, data.DUE_DATE.Value);
            req.Parameters.Add("UNIT_PRICE", DataType.Number, data.UNIT_PRICE.Value);
            req.Parameters.Add("PO_QTY", DataType.Number, data.PO_QTY.Value);
            req.Parameters.Add("UNIT", DataType.NVarChar, data.UNIT.Value);
            req.Parameters.Add("AMOUNT", DataType.Number, data.AMOUNT.Value);
            req.Parameters.Add("RECEIVE_QTY", DataType.Number, data.RECEIVE_QTY.Value);
            req.Parameters.Add("BACK_ORDER_QTY", DataType.Number, data.BACK_ORDER_QTY.Value);
            req.Parameters.Add("LAST_RECEIVE_ID", DataType.NVarChar, data.LAST_RECEIVE_ID.Value);
            req.Parameters.Add("LAST_RECEIVE_DATE", DataType.DateTime, data.LAST_RECEIVE_DATE.Value);
            req.Parameters.Add("RECORD_STATUS", DataType.NVarChar, data.RECORD_STATUS.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
        /// <returns></returns>
        public int Delete(Database database) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(TmpPurchaseOrderDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(TmpPurchaseOrderDTO));

            sb.AppendLine(" SELECT TOP 1 1 ");
            sb.AppendLine(" FROM " + tableName);
            #endregion

            DataRequest req = new DataRequest(sb.ToString());

            return (db.ExecuteQuery(req).Rows.Count > 0);
        }
        #endregion

        #region Load Operation
        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <returns>List of DTO.</returns>
        public List<TmpPurchaseOrderDTO> LoadAll(Database database) {
            return LoadAll(database, true);
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<TmpPurchaseOrderDTO> LoadAll(Database database, bool ascending) {
            return LoadAll(database, ascending);
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<TmpPurchaseOrderDTO> LoadAll(Database database, bool ascending, params TmpPurchaseOrderDTO.eColumns[] orderByColumns) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(TmpPurchaseOrderDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + TmpPurchaseOrderDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.IS_ACTIVE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.PO_GROUP);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.PO_NO);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.PO_TYPE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.PO_DATE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.SUPPLIER_CD);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.SUPPLIER_NAME);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.ADDRESS);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.DELIVERY_TO);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.DELIVERY_TO_NAME);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.DELIVERY_TO_ADDRESS);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.CURRENCY);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.VAT_TYPE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.VAT_RATE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.TERM_OF_PAYMENT);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.IS_EXPORT);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.STATUS);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.REMARK);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.PO_LINE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.ITEM_DESC);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.DUE_DATE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.UNIT_PRICE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.PO_QTY);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.UNIT);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.AMOUNT);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.RECEIVE_QTY);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.BACK_ORDER_QTY);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.LAST_RECEIVE_ID);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.LAST_RECEIVE_DATE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.RECORD_STATUS);
            sb.AppendLine(" FROM " + tableName);

            if (orderByColumns != null && orderByColumns.Length > 0) {
                sb.AppendLine(" ORDER BY ");
                string sort = ascending ? "asc" : "desc";

                for (int i = 0; i < orderByColumns.Length; i++) {
                    if (i == 0)
                        sb.AppendLine(String.Format("   {0} {1}", orderByColumns[i], sort));
                    else
                        sb.AppendLine(String.Format("   ,{0} {1}", orderByColumns[i], sort));
                }
            }
            #endregion

            DataRequest req = new DataRequest(sb.ToString());

            return db.ExecuteForList<TmpPurchaseOrderDTO>(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <returns></returns>
        public TmpPurchaseOrderDTO LoadByPK(Database database) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(TmpPurchaseOrderDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + TmpPurchaseOrderDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.IS_ACTIVE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.PO_GROUP);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.PO_NO);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.PO_TYPE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.PO_DATE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.SUPPLIER_CD);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.SUPPLIER_NAME);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.ADDRESS);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.DELIVERY_TO);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.DELIVERY_TO_NAME);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.DELIVERY_TO_ADDRESS);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.CURRENCY);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.VAT_TYPE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.VAT_RATE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.TERM_OF_PAYMENT);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.IS_EXPORT);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.STATUS);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.REMARK);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.PO_LINE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.ITEM_DESC);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.DUE_DATE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.UNIT_PRICE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.PO_QTY);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.UNIT);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.AMOUNT);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.RECEIVE_QTY);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.BACK_ORDER_QTY);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.LAST_RECEIVE_ID);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.LAST_RECEIVE_DATE);
            sb.AppendLine("  ," + TmpPurchaseOrderDTO.eColumns.RECORD_STATUS);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            #endregion

            List<TmpPurchaseOrderDTO> list = db.ExecuteForList<TmpPurchaseOrderDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        #endregion
    }
}

