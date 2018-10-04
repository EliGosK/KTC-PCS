/* Create by: Ms. Sansanee K.
 * Create on: 2012-03-02
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
    internal partial class CustomerOrderHDAO
    {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public CustomerOrderHDAO() { }

        public CustomerOrderHDAO(Database db)
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
        public int AddNewOrUpdate(Database database, CustomerOrderHDTO data)
        {
            Database db = UseDatabase(database);

            if (Exist(database, data.ORDER_NO))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, CustomerOrderHDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            sb.AppendLine("  " + CustomerOrderHDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.ORDER_NO);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.RECEIVE_DATE);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.CUSTOMER_CD);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.ORDER_TYPE);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.CURRENCY);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.PO_NO);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.PO_DATE);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.EXCHANGE_RATE);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.REMARK);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.TOTAL_QTY);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.TOTAL_AMOUNT);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.TOTAL_AMOUNT_THB);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.OLD_DATA);
            sb.AppendLine(") VALUES(");
            sb.AppendLine("   @CRT_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,@CRT_MACHINE");
            sb.AppendLine("   ,@UPD_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,@UPD_MACHINE");
            sb.AppendLine("   ,@ORDER_NO");
            sb.AppendLine("   ,@RECEIVE_DATE");
            sb.AppendLine("   ,@CUSTOMER_CD");
            sb.AppendLine("   ,@ORDER_TYPE");
            sb.AppendLine("   ,@CURRENCY");
            sb.AppendLine("   ,@PO_NO");
            sb.AppendLine("   ,@PO_DATE");
            sb.AppendLine("   ,@EXCHANGE_RATE");
            sb.AppendLine("   ,@REMARK");
            sb.AppendLine("   ,@TOTAL_QTY");
            sb.AppendLine("   ,@TOTAL_AMOUNT");
            sb.AppendLine("   ,@TOTAL_AMOUNT_THB");
            sb.AppendLine("   ,@OLD_DATA");
            sb.AppendLine(" )");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@CRT_BY", DataType.NVarChar, data.CRT_BY.Value);
            req.Parameters.Add("@CRT_MACHINE", DataType.NVarChar, data.CRT_MACHINE.Value);
            req.Parameters.Add("@UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("@ORDER_NO", DataType.NVarChar, data.ORDER_NO.Value);
            req.Parameters.Add("@RECEIVE_DATE", DataType.DateTime, data.RECEIVE_DATE.Value);
            req.Parameters.Add("@CUSTOMER_CD", DataType.NVarChar, data.CUSTOMER_CD.Value);
            req.Parameters.Add("@ORDER_TYPE", DataType.NVarChar, data.ORDER_TYPE.Value);
            req.Parameters.Add("@CURRENCY", DataType.NVarChar, data.CURRENCY.Value);
            req.Parameters.Add("@PO_NO", DataType.NVarChar, data.PO_NO.Value);
            req.Parameters.Add("@PO_DATE", DataType.DateTime, data.PO_DATE.Value);
            req.Parameters.Add("@EXCHANGE_RATE", DataType.Number, data.EXCHANGE_RATE.Value);
            req.Parameters.Add("@REMARK", DataType.NVarChar, data.REMARK.Value);
            req.Parameters.Add("@TOTAL_QTY", DataType.Number, data.TOTAL_QTY.Value);
            req.Parameters.Add("@TOTAL_AMOUNT", DataType.Number, data.TOTAL_AMOUNT.Value);
            req.Parameters.Add("@TOTAL_AMOUNT_THB", DataType.Number, data.TOTAL_AMOUNT_THB.Value);
            req.Parameters.Add("@OLD_DATA", DataType.Default, 0);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using primary key value on the given data variable
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data with primary key value.</param>
        /// <returns></returns>
        public int UpdateWithoutPK(Database database, CustomerOrderHDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + CustomerOrderHDTO.eColumns.UPD_BY + "=@UPD_BY");
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.UPD_MACHINE + "=@UPD_MACHINE");
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.RECEIVE_DATE + "=@RECEIVE_DATE");
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.CUSTOMER_CD + "=@CUSTOMER_CD");
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.ORDER_TYPE + "=@ORDER_TYPE");
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.CURRENCY + "=@CURRENCY");
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.PO_NO + "=@PO_NO");
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.PO_DATE + "=@PO_DATE");
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.EXCHANGE_RATE + "=@EXCHANGE_RATE");
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.REMARK + "=@REMARK");
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.TOTAL_QTY + "=@TOTAL_QTY");
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.TOTAL_AMOUNT + "=@TOTAL_AMOUNT");
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.TOTAL_AMOUNT_THB + "=@TOTAL_AMOUNT_THB");
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.OLD_DATA + "=@OLD_DATA");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + CustomerOrderHDTO.eColumns.ORDER_NO + "=@ORDER_NO");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("@ORDER_NO", DataType.NVarChar, data.ORDER_NO.Value);
            req.Parameters.Add("@RECEIVE_DATE", DataType.DateTime, data.RECEIVE_DATE.Value);
            req.Parameters.Add("@CUSTOMER_CD", DataType.NVarChar, data.CUSTOMER_CD.Value);
            req.Parameters.Add("@ORDER_TYPE", DataType.NVarChar, data.ORDER_TYPE.Value);
            req.Parameters.Add("@CURRENCY", DataType.NVarChar, data.CURRENCY.Value);
            req.Parameters.Add("@PO_NO", DataType.NVarChar, data.PO_NO.Value);
            req.Parameters.Add("@PO_DATE", DataType.DateTime, data.PO_DATE.Value);
            req.Parameters.Add("@EXCHANGE_RATE", DataType.Number, data.EXCHANGE_RATE.Value);
            req.Parameters.Add("@REMARK", DataType.NVarChar, data.REMARK.Value);
            req.Parameters.Add("@TOTAL_QTY", DataType.Number, data.TOTAL_QTY.Value);
            req.Parameters.Add("@TOTAL_AMOUNT", DataType.Number, data.TOTAL_AMOUNT.Value);
            req.Parameters.Add("@TOTAL_AMOUNT_THB", DataType.Number, data.TOTAL_AMOUNT_THB.Value);
            req.Parameters.Add("@OLD_DATA", DataType.Default, 0);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using the table's primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data which to update.</param>
        /// <param name="oldORDER_NO">Old Key #1</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, CustomerOrderHDTO data, String oldORDER_NO)
        {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + CustomerOrderHDTO.eColumns.UPD_BY + "=@UPD_BY");
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.UPD_MACHINE + "=@UPD_MACHINE");
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.ORDER_NO + "=@ORDER_NO");
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.RECEIVE_DATE + "=@RECEIVE_DATE");
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.CUSTOMER_CD + "=@CUSTOMER_CD");
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.ORDER_TYPE + "=@ORDER_TYPE");
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.CURRENCY + "=@CURRENCY");
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.PO_NO + "=@PO_NO");
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.PO_DATE + "=@PO_DATE");
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.EXCHANGE_RATE + "=@EXCHANGE_RATE");
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.REMARK + "=@REMARK");
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.TOTAL_QTY + "=@TOTAL_QTY");
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.TOTAL_AMOUNT + "=@TOTAL_AMOUNT");
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.TOTAL_AMOUNT_THB + "=@TOTAL_AMOUNT_THB");
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.OLD_DATA + "=@OLD_DATA");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + CustomerOrderHDTO.eColumns.ORDER_NO + "=@oldORDER_NO");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("@ORDER_NO", DataType.NVarChar, data.ORDER_NO.Value);
            req.Parameters.Add("@RECEIVE_DATE", DataType.DateTime, data.RECEIVE_DATE.Value);
            req.Parameters.Add("@CUSTOMER_CD", DataType.NVarChar, data.CUSTOMER_CD.Value);
            req.Parameters.Add("@ORDER_TYPE", DataType.NVarChar, data.ORDER_TYPE.Value);
            req.Parameters.Add("@CURRENCY", DataType.NVarChar, data.CURRENCY.Value);
            req.Parameters.Add("@PO_NO", DataType.NVarChar, data.PO_NO.Value);
            req.Parameters.Add("@PO_DATE", DataType.DateTime, data.PO_DATE.Value);
            req.Parameters.Add("@EXCHANGE_RATE", DataType.Number, data.EXCHANGE_RATE.Value);
            req.Parameters.Add("@REMARK", DataType.NVarChar, data.REMARK.Value);
            req.Parameters.Add("@TOTAL_QTY", DataType.Number, data.TOTAL_QTY.Value);
            req.Parameters.Add("@TOTAL_AMOUNT", DataType.Number, data.TOTAL_AMOUNT.Value);
            req.Parameters.Add("@TOTAL_AMOUNT_THB", DataType.Number, data.TOTAL_AMOUNT_THB.Value);
            req.Parameters.Add("@OLD_DATA", DataType.Default, 0);
            req.Parameters.Add("@oldORDER_NO", DataType.NVarChar, oldORDER_NO);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ORDER_NO">Key #1</param>
        /// <returns></returns>
        public int Delete(Database database, String ORDER_NO)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(CustomerOrderHDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + CustomerOrderHDTO.eColumns.ORDER_NO + "=@ORDER_NO");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@ORDER_NO", DataType.NVarChar, ORDER_NO);
            #endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, NZString ORDER_NO)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(CustomerOrderHDTO));

            sb.AppendLine(" SELECT TOP 1 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + CustomerOrderHDTO.eColumns.ORDER_NO + "=@ORDER_NO");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@ORDER_NO", DataType.NVarChar, ORDER_NO.Value);
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
        public List<CustomerOrderHDTO> LoadAll(Database database)
        {
            return LoadAll(database, true,
                CustomerOrderHDTO.eColumns.ORDER_NO
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<CustomerOrderHDTO> LoadAll(Database database, bool ascending)
        {
            return LoadAll(database, ascending,
                CustomerOrderHDTO.eColumns.ORDER_NO
            );
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<CustomerOrderHDTO> LoadAll(Database database, bool ascending, params CustomerOrderHDTO.eColumns[] orderByColumns)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(CustomerOrderHDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + CustomerOrderHDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.ORDER_NO);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.RECEIVE_DATE);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.CUSTOMER_CD);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.ORDER_TYPE);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.CURRENCY);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.PO_NO);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.PO_DATE);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.EXCHANGE_RATE);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.REMARK);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.TOTAL_QTY);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.TOTAL_AMOUNT);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.TOTAL_AMOUNT_THB);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.OLD_DATA);
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

            return db.ExecuteForList<CustomerOrderHDTO>(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ORDER_NO">Key #1</param>
        /// <returns></returns>
        public CustomerOrderHDTO LoadByPK(Database database, String ORDER_NO)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(CustomerOrderHDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + CustomerOrderHDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.ORDER_NO);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.RECEIVE_DATE);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.CUSTOMER_CD);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.ORDER_TYPE);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.CURRENCY);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.PO_NO);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.PO_DATE);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.EXCHANGE_RATE);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.REMARK);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.TOTAL_QTY);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.TOTAL_AMOUNT);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.TOTAL_AMOUNT_THB);
            sb.AppendLine("  ," + CustomerOrderHDTO.eColumns.OLD_DATA);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + CustomerOrderHDTO.eColumns.ORDER_NO + "=@ORDER_NO");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@ORDER_NO", DataType.NVarChar, ORDER_NO);
            #endregion

            List<CustomerOrderHDTO> list = db.ExecuteForList<CustomerOrderHDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        #endregion

        public int UpdateCustomerHeaderTotal(Database database, String ORDER_NO)
        {
            Database db = UseDatabase(database);
            DataRequest req = new DataRequest();

            req.CommandText = "S_TRN180_UpdateOrderHTotal";
            req.CommandType = System.Data.CommandType.StoredProcedure ;
            req.Parameters.Add("@ORDER_NO", DataType.NVarChar, ORDER_NO);

            return db.ExecuteNonQuery(req);
        }

    }
}

