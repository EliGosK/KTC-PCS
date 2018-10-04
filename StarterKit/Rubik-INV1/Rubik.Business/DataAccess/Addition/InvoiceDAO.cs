/* Create by: Mr. Pongthorn S.
 * Create on: 2012-05-09
 * Company: CSI Groups (Thailand)
 * Group: TP_JDL
 
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
    internal partial class InvoiceDAO : BaseDAO
    {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public InvoiceDAO() { }

        public InvoiceDAO(Database db)
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
        public int AddNewOrUpdate(Database database, InvoiceDTO data)
        {
            Database db = UseDatabase(database);

            if (Exist(database, data.TRANS_ID))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, InvoiceDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            sb.AppendLine("  " + CustomerOrderDDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.TRANS_ID);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.BILL_NO);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.DELIVERY_NO);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.ADDRESS);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.INVOICE_NO);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.INVOICE_DATE);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.TERM_OF_PAYMENT);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.PAYMENT_DUE_DATE);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.REFER_TEM_NO);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.REMARK);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.SUB_TOTAL);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.VAT);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.VAT_AMOUNT);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.TOTAL);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.CANCEL_FLAG);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.PO_NO);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.ORDER_NO);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.ORDER_DETAIL_NO);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.SHORT_NAME);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.ITEM_DESC);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.UNIT);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.QTY);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.PRICE);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.AMOUNT);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.OLD_DATA);
            sb.AppendLine(") VALUES(");
            sb.AppendLine("   @CRT_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,@CRT_MACHINE");
            sb.AppendLine("   ,@UPD_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,@UPD_MACHINE");

            sb.AppendLine("   ,@TRANS_ID");
            sb.AppendLine("   ,@BILL_NO");
            sb.AppendLine("   ,@DELIVERY_NO");
            sb.AppendLine("   ,@ADDRESS");
            sb.AppendLine("   ,@INVOICE_NO");
            sb.AppendLine("   ,@INVOICE_DATE");
            sb.AppendLine("   ,@TERM_OF_PAYMENT");
            sb.AppendLine("   ,@PAYMENT_DUE_DATE");
            sb.AppendLine("   ,@REFER_TEM_NO");
            sb.AppendLine("   ,@REMARK");
            sb.AppendLine("   ,@SUB_TOTAL");
            sb.AppendLine("   ,@VAT");
            sb.AppendLine("   ,@VAT_AMOUNT");
            sb.AppendLine("   ,@TOTAL");
            sb.AppendLine("   ,@CANCEL_FLAG");
            sb.AppendLine("   ,@PO_NO");
            sb.AppendLine("   ,@ORDER_NO");
            sb.AppendLine("   ,@ORDER_DETAIL_NO");
            sb.AppendLine("   ,@ITEM_CD");
            sb.AppendLine("   ,@SHORT_NAME");
            sb.AppendLine("   ,@ITEM_DESC");
            sb.AppendLine("   ,@UNIT");
            sb.AppendLine("   ,@QTY");
            sb.AppendLine("   ,@PRICE");
            sb.AppendLine("   ,@AMOUNT");
            sb.AppendLine("   ,@OLD_DATA");
            sb.AppendLine(" )");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@CRT_BY", DataType.NVarChar, data.CRT_BY.Value);
            req.Parameters.Add("@CRT_MACHINE", DataType.NVarChar, data.CRT_MACHINE.Value);
            req.Parameters.Add("@UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("@TRANS_ID", DataType.NVarChar, data.TRANS_ID.Value);
            req.Parameters.Add("@BILL_NO", DataType.NVarChar, data.BILL_NO.Value);
            req.Parameters.Add("@DELIVERY_NO", DataType.NVarChar, data.DELIVERY_NO.Value);
            req.Parameters.Add("@ADDRESS", DataType.NVarChar, data.ADDRESS.Value);
            req.Parameters.Add("@INVOICE_NO", DataType.NVarChar, data.INVOICE_NO.Value);
            req.Parameters.Add("@INVOICE_DATE", DataType.DateTime, data.INVOICE_DATE.Value);
            req.Parameters.Add("@TERM_OF_PAYMENT", DataType.NVarChar, data.TERM_OF_PAYMENT.Value);
            req.Parameters.Add("@PAYMENT_DUE_DATE", DataType.DateTime, data.PAYMENT_DUE_DATE.Value);
            req.Parameters.Add("@REFER_TEM_NO", DataType.NVarChar, data.REFER_TEM_NO.Value);
            req.Parameters.Add("@REMARK", DataType.NVarChar, data.REMARK.Value);
            req.Parameters.Add("@SUB_TOTAL", DataType.Decimal, data.SUB_TOTAL.Value);
            req.Parameters.Add("@VAT", DataType.Decimal, data.VAT.Value);
            req.Parameters.Add("@VAT_AMOUNT", DataType.Decimal, data.VAT_AMOUNT.Value);
            req.Parameters.Add("@TOTAL", DataType.Decimal, data.TOTAL.Value);
            req.Parameters.Add("@CANCEL_FLAG", DataType.Number, data.CANCEL_FLAG.Value);
            req.Parameters.Add("@PO_NO", DataType.NVarChar, data.PO_NO.Value);
            req.Parameters.Add("@ORDER_NO", DataType.NVarChar, data.ORDER_NO.Value);
            req.Parameters.Add("@ORDER_DETAIL_NO", DataType.NVarChar, data.ORDER_DETAIL_NO.Value);
            req.Parameters.Add("@ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("@SHORT_NAME", DataType.NVarChar, data.SHORT_NAME.Value);
            req.Parameters.Add("@ITEM_DESC", DataType.NVarChar, data.ITEM_DESC.Value);
            req.Parameters.Add("@UNIT", DataType.NVarChar, data.UNIT.Value);
            req.Parameters.Add("@QTY", DataType.Decimal, data.QTY.Value);
            req.Parameters.Add("@PRICE", DataType.Decimal, data.PRICE.Value);
            req.Parameters.Add("@AMOUNT", DataType.Decimal, data.AMOUNT.Value);
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
        public int UpdateWithoutPK(Database database, InvoiceDTO data)
        {
            Database db = UseDatabase(database);


            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + InvoiceDTO.eColumns.UPD_BY + "=@UPD_BY");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.UPD_MACHINE + "=@UPD_MACHINE");

            sb.AppendLine("  ," + InvoiceDTO.eColumns.BILL_NO + "=@BILL_NO");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.DELIVERY_NO + "=@DELIVERY_NO");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.ADDRESS + "=@ADDRESS");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.INVOICE_NO + "=@INVOICE_NO");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.INVOICE_DATE + "=@INVOICE_DATE");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.TERM_OF_PAYMENT + "=@TERM_OF_PAYMENT");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.PAYMENT_DUE_DATE + "=@PAYMENT_DUE_DATE");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.REFER_TEM_NO + "=@REFER_TEM_NO");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.REMARK + "=@REMARK");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.SUB_TOTAL + "=@SUB_TOTAL");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.VAT + "=@VAT");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.VAT_AMOUNT + "=@VAT_AMOUNT");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.TOTAL + "=@TOTAL");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.CANCEL_FLAG + "=@CANCEL_FLAG");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.PO_NO +"=@PO_NO");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.ORDER_NO + "=@ORDER_NO");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.ORDER_DETAIL_NO + "=@ORDER_DETAIL_NO");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.ITEM_CD + "=@ITEM_CD");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.SHORT_NAME + "=@SHORT_NAME");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.ITEM_DESC + "=@ITEM_DESC");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.UNIT + "=@UNIT");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.QTY + "=@QTY");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.PRICE + "=@PRICE");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.AMOUNT + "=@AMOUNT");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.OLD_DATA + "=@OLD_DATA");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + InvoiceDTO.eColumns.TRANS_ID + "=@TRANS_ID");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("@TRANS_ID", DataType.NVarChar, data.TRANS_ID.Value);
            req.Parameters.Add("@BILL_NO", DataType.NVarChar, data.BILL_NO.Value);
            req.Parameters.Add("@DELIVERY_NO", DataType.NVarChar, data.DELIVERY_NO.Value);
            req.Parameters.Add("@ADDRESS", DataType.NVarChar, data.ADDRESS.Value);
            req.Parameters.Add("@INVOICE_NO", DataType.NVarChar, data.INVOICE_NO.Value);
            req.Parameters.Add("@INVOICE_DATE", DataType.DateTime, data.INVOICE_DATE.Value);
            req.Parameters.Add("@TERM_OF_PAYMENT", DataType.NVarChar, data.TERM_OF_PAYMENT.Value);
            req.Parameters.Add("@PAYMENT_DUE_DATE", DataType.DateTime, data.PAYMENT_DUE_DATE.Value);
            req.Parameters.Add("@REFER_TEM_NO", DataType.NVarChar, data.REFER_TEM_NO.Value);
            req.Parameters.Add("@REMARK", DataType.NVarChar, data.REMARK.Value);
            req.Parameters.Add("@SUB_TOTAL", DataType.Decimal, data.SUB_TOTAL.Value);
            req.Parameters.Add("@VAT", DataType.Decimal, data.VAT.Value);
            req.Parameters.Add("@VAT_AMOUNT", DataType.Decimal, data.VAT_AMOUNT.Value);
            req.Parameters.Add("@TOTAL", DataType.Decimal, data.TOTAL.Value);
            req.Parameters.Add("@CANCEL_FLAG", DataType.Number, data.CANCEL_FLAG.Value);
            req.Parameters.Add("@PO_NO", DataType.NVarChar, data.PO_NO.Value);
            req.Parameters.Add("@ORDER_NO", DataType.NVarChar, data.ORDER_NO.Value);
            req.Parameters.Add("@ORDER_DETAIL_NO", DataType.NVarChar, data.ORDER_DETAIL_NO.Value);
            req.Parameters.Add("@ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("@SHORT_NAME", DataType.NVarChar, data.SHORT_NAME.Value);
            req.Parameters.Add("@ITEM_DESC", DataType.NVarChar, data.ITEM_DESC.Value);
            req.Parameters.Add("@UNIT", DataType.NVarChar, data.UNIT.Value);
            req.Parameters.Add("@QTY", DataType.Decimal, data.QTY.Value);
            req.Parameters.Add("@PRICE", DataType.Decimal, data.PRICE.Value);
            req.Parameters.Add("@AMOUNT", DataType.Decimal, data.AMOUNT.Value);
            req.Parameters.Add("@OLD_DATA", DataType.Default, data.OLD_DATA.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using the table's primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data which to update.</param>
        /// <param name="oldTRANS_ID">Old Key</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, InvoiceDTO data, String TRANS_ID)
        {

            Database db = UseDatabase(database);


            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + InvoiceDTO.eColumns.UPD_BY + "=@UPD_BY");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.UPD_MACHINE + "=@UPD_MACHINE");

            sb.AppendLine("  ," + InvoiceDTO.eColumns.BILL_NO + "=@BILL_NO");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.DELIVERY_NO + "=@DELIVERY_NO");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.ADDRESS + "=@ADDRESS");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.INVOICE_NO + "=@INVOICE_NO");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.INVOICE_DATE + "=@INVOICE_DATE");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.TERM_OF_PAYMENT + "=@TERM_OF_PAYMENT");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.PAYMENT_DUE_DATE + "=@PAYMENT_DUE_DATE");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.REFER_TEM_NO + "=@REFER_TEM_NO");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.REMARK + "=@REMARK");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.SUB_TOTAL + "=@SUB_TOTAL");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.VAT + "=@VAT");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.VAT_AMOUNT + "=@VAT_AMOUNT");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.TOTAL + "=@TOTAL");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.CANCEL_FLAG + "=@CANCEL_FLAG");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.PO_NO + "=@PO_NO");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.ORDER_NO + "=@ORDER_NO");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.ORDER_DETAIL_NO + "=@ORDER_DETAIL_NO");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.ITEM_CD + "=@ITEM_CD");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.SHORT_NAME + "=@SHORT_NAME");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.ITEM_DESC + "=@ITEM_DESC");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.UNIT + "=@UNIT");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.QTY + "=@QTY");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.PRICE + "=@PRICE");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.AMOUNT + "=@AMOUNT");
            sb.AppendLine("  ," + InvoiceDTO.eColumns.OLD_DATA + "=@OLD_DATA");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + InvoiceDTO.eColumns.TRANS_ID + "=@TRANS_ID");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("@TRANS_ID", DataType.NVarChar, TRANS_ID);
            req.Parameters.Add("@DELIVERY_NO", DataType.NVarChar, data.DELIVERY_NO.Value);
            req.Parameters.Add("@ADDRESS", DataType.NVarChar, data.ADDRESS.Value);
            req.Parameters.Add("@INVOICE_NO", DataType.NVarChar, data.INVOICE_NO.Value);
            req.Parameters.Add("@INVOICE_DATE", DataType.DateTime, data.INVOICE_DATE.Value);
            req.Parameters.Add("@TERM_OF_PAYMENT", DataType.NVarChar, data.TERM_OF_PAYMENT.Value);
            req.Parameters.Add("@PAYMENT_DUE_DATE", DataType.DateTime, data.PAYMENT_DUE_DATE.Value);
            req.Parameters.Add("@REFER_TEM_NO", DataType.NVarChar, data.REFER_TEM_NO.Value);
            req.Parameters.Add("@REMARK", DataType.NVarChar, data.REMARK.Value);
            req.Parameters.Add("@SUB_TOTAL", DataType.Decimal, data.SUB_TOTAL.Value);
            req.Parameters.Add("@VAT", DataType.Decimal, data.VAT.Value);
            req.Parameters.Add("@VAT_AMOUNT", DataType.Decimal, data.VAT_AMOUNT.Value);
            req.Parameters.Add("@TOTAL", DataType.Decimal, data.TOTAL.Value);
            req.Parameters.Add("@CANCEL_FLAG", DataType.Number, data.CANCEL_FLAG.Value);
            req.Parameters.Add("@PO_NO", DataType.NVarChar, data.PO_NO.Value);
            req.Parameters.Add("@ORDER_NO", DataType.NVarChar, data.ORDER_NO.Value);
            req.Parameters.Add("@ORDER_DETAIL_NO", DataType.NVarChar, data.ORDER_DETAIL_NO.Value);
            req.Parameters.Add("@ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("@SHORT_NAME", DataType.NVarChar, data.SHORT_NAME.Value);
            req.Parameters.Add("@ITEM_DESC", DataType.NVarChar, data.ITEM_DESC.Value);
            req.Parameters.Add("@UNIT", DataType.NVarChar, data.UNIT.Value);
            req.Parameters.Add("@QTY", DataType.Decimal, data.QTY.Value);
            req.Parameters.Add("@PRICE", DataType.Decimal, data.PRICE.Value);
            req.Parameters.Add("@AMOUNT", DataType.Decimal, data.AMOUNT.Value);
            req.Parameters.Add("@OLD_DATA", DataType.Default, data.OLD_DATA.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="TRANS_ID">Key</param>
        /// <returns></returns>
        public int Delete(Database database, String TRANS_ID)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(CustomerOrderDDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + InvoiceDTO.eColumns.ORDER_NO + "=@TRANS_ID");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@TRANS_ID", DataType.NVarChar, TRANS_ID);
            #endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, NZString TRANS_ID)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InvoiceDTO));

            sb.AppendLine(" SELECT TOP 1 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + InvoiceDTO.eColumns.TRANS_ID + "=@TRANS_ID");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@TRANS_ID", DataType.NVarChar, TRANS_ID.Value);
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
        public List<InvoiceDTO> LoadAll(Database database, bool IncludeOldData)
        {
            return LoadAll(database
                , true
                , IncludeOldData
                , InvoiceDTO.eColumns.BILL_NO
                , InvoiceDTO.eColumns.TRANS_ID
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<InvoiceDTO> LoadAll(Database database, bool ascending, bool IncludeOldData)
        {
            return LoadAll(database
                        , ascending
                        , IncludeOldData
                        , InvoiceDTO.eColumns.BILL_NO
                        , InvoiceDTO.eColumns.TRANS_ID
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<InvoiceDTO> LoadAll(Database database, bool ascending, bool IncludeOldData, params InvoiceDTO.eColumns[] orderByColumns)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InvoiceDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + InvoiceDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.TRANS_ID);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.BILL_NO);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.DELIVERY_NO);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.ADDRESS);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.INVOICE_NO);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.INVOICE_DATE);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.TERM_OF_PAYMENT);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.PAYMENT_DUE_DATE);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.REFER_TEM_NO);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.REMARK);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.SUB_TOTAL);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.VAT);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.VAT_AMOUNT);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.TOTAL);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.CANCEL_FLAG);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.PO_NO);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.ORDER_NO);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.ORDER_DETAIL_NO);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.SHORT_NAME);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.ITEM_DESC);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.UNIT);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.QTY);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.PRICE);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.AMOUNT);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.OLD_DATA); 
            sb.AppendLine(" FROM " + tableName);
            if (!IncludeOldData) sb.AppendLine(" WHERE (" + InvoiceDTO.eColumns.OLD_DATA + " = null OR " + InvoiceDTO.eColumns.OLD_DATA + " != '1')");
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

            return db.ExecuteForList<InvoiceDTO>(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="TRANS_ID">Key</param>
        /// <returns></returns>
        public InvoiceDTO LoadByPK(Database database, String TRANS_ID, bool IncludeOldData)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(CustomerOrderDDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + InvoiceDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.TRANS_ID);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.BILL_NO);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.DELIVERY_NO);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.ADDRESS);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.INVOICE_NO);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.INVOICE_DATE);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.TERM_OF_PAYMENT);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.PAYMENT_DUE_DATE);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.REFER_TEM_NO);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.REMARK);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.SUB_TOTAL);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.VAT);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.VAT_AMOUNT);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.TOTAL);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.CANCEL_FLAG);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.PO_NO);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.ORDER_NO);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.ORDER_DETAIL_NO);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.SHORT_NAME);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.ITEM_DESC);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.UNIT);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.QTY);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.PRICE);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.AMOUNT);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.OLD_DATA); 
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + InvoiceDTO.eColumns.TRANS_ID + "=@TRANS_ID");
            if (!IncludeOldData) sb.AppendLine(" AND (" + InvoiceDTO.eColumns.OLD_DATA + " = null OR " + InvoiceDTO.eColumns.OLD_DATA + " != '1')");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@TRANS_ID", DataType.NVarChar, TRANS_ID);
            #endregion

            List<InvoiceDTO> list = db.ExecuteForList<InvoiceDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }

        public List<InvoiceDTO> LoadByBillNo(Database database, String BILL_NO, bool IncludeOldData)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(CustomerOrderDDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + InvoiceDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.TRANS_ID);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.BILL_NO);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.DELIVERY_NO);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.ADDRESS);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.INVOICE_NO);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.INVOICE_DATE);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.TERM_OF_PAYMENT);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.PAYMENT_DUE_DATE);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.REFER_TEM_NO);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.REMARK);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.SUB_TOTAL);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.VAT);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.VAT_AMOUNT);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.TOTAL);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.CANCEL_FLAG);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.PO_NO);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.ORDER_NO);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.ORDER_DETAIL_NO);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.SHORT_NAME);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.ITEM_DESC);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.UNIT);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.QTY);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.PRICE);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.AMOUNT);
            sb.AppendLine("  ," + InvoiceDTO.eColumns.OLD_DATA); 
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + InvoiceDTO.eColumns.BILL_NO + "=@BILL_NO");
            if (!IncludeOldData) sb.AppendLine(" AND (" + InvoiceDTO.eColumns.OLD_DATA + " = null OR " + InvoiceDTO.eColumns.OLD_DATA + " != '1')");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@BILL_NO", DataType.NVarChar, BILL_NO);
            #endregion

            return db.ExecuteForList<InvoiceDTO>(req);
        }

        #endregion
    }
}

