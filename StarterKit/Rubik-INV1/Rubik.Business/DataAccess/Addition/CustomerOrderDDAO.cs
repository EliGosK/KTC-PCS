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
    internal partial class CustomerOrderDDAO : BaseDAO
    {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public CustomerOrderDDAO() { }

        public CustomerOrderDDAO(Database db)
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
        public int AddNewOrUpdate(Database database, CustomerOrderDDTO data)
        {
            Database db = UseDatabase(database);

            if (Exist(database, data.ORDER_NO, data.ORDER_DETAIL_NO))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, CustomerOrderDDTO data)
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
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.ORDER_NO);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.ORDER_DETAIL_NO);
            //sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.RUN_NO);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.ITEM_DELIVERY_DATE);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.QTY);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.PRICE);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.AMOUNT);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.AMOUNT_THB);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.SHIP_QTY);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.COMPLETE_FLAG);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.OLD_DATA);
            sb.AppendLine(") VALUES(");
            sb.AppendLine("   @CRT_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,@CRT_MACHINE");
            sb.AppendLine("   ,@UPD_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,@UPD_MACHINE");
            sb.AppendLine("   ,@ORDER_NO");
            sb.AppendLine("   ,@ORDER_DETAIL_NO");
            //sb.AppendLine("   ,@RUN_NO");
            sb.AppendLine("   ,@ITEM_CD");
            sb.AppendLine("   ,@ITEM_DELIVERY_DATE");
            sb.AppendLine("   ,@QTY");
            sb.AppendLine("   ,@PRICE");
            sb.AppendLine("   ,@AMOUNT");
            sb.AppendLine("   ,@AMOUNT_THB");
            sb.AppendLine("   ,@SHIP_QTY");
            sb.AppendLine("   ,@COMPLETE_FLAG");
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
            req.Parameters.Add("@ORDER_DETAIL_NO", DataType.NVarChar, data.ORDER_DETAIL_NO.Value);
            //req.Parameters.Add("@RUN_NO", DataType.Default, data.RUN_NO.Value);
            req.Parameters.Add("@ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("@ITEM_DELIVERY_DATE", DataType.DateTime, data.ITEM_DELIVERY_DATE.Value);
            req.Parameters.Add("@QTY", DataType.Number, data.QTY.Value);
            req.Parameters.Add("@PRICE", DataType.Number, data.PRICE.Value);
            req.Parameters.Add("@AMOUNT", DataType.Number, data.AMOUNT.Value);
            req.Parameters.Add("@AMOUNT_THB", DataType.Number, data.AMOUNT_THB.Value);
            req.Parameters.Add("@SHIP_QTY", DataType.Number, data.SHIP_QTY.Value);
            req.Parameters.Add("@COMPLETE_FLAG", DataType.Default, data.COMPLETE_FLAG.Value);
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
        public int UpdateWithoutPK(Database database, CustomerOrderDDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + CustomerOrderDDTO.eColumns.UPD_BY + "=@UPD_BY");
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.UPD_MACHINE + "=@UPD_MACHINE");
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.ITEM_CD + "=@ITEM_CD");
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.ITEM_DELIVERY_DATE + "=@ITEM_DELIVERY_DATE");
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.QTY + "=@QTY");
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.PRICE + "=@PRICE");
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.AMOUNT + "=@AMOUNT");
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.AMOUNT_THB + "=@AMOUNT_THB");
            //sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.SHIP_QTY + "=@SHIP_QTY");
            //sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.COMPLETE_FLAG + "=@COMPLETE_FLAG");
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.OLD_DATA + "=@OLD_DATA");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + CustomerOrderDDTO.eColumns.ORDER_NO + "=@ORDER_NO");
            sb.AppendLine("  AND " + CustomerOrderDDTO.eColumns.ORDER_DETAIL_NO + "=@ORDER_DETAIL_NO");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("@ORDER_NO", DataType.NVarChar, data.ORDER_NO.Value);
            req.Parameters.Add("@ORDER_DETAIL_NO", DataType.NVarChar, data.ORDER_DETAIL_NO.Value);
            req.Parameters.Add("@RUN_NO", DataType.Default, data.RUN_NO.Value);
            req.Parameters.Add("@ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("@ITEM_DELIVERY_DATE", DataType.DateTime, data.ITEM_DELIVERY_DATE.Value);
            req.Parameters.Add("@QTY", DataType.Number, data.QTY.Value);
            req.Parameters.Add("@PRICE", DataType.Number, data.PRICE.Value);
            req.Parameters.Add("@AMOUNT", DataType.Number, data.AMOUNT.Value);
            req.Parameters.Add("@AMOUNT_THB", DataType.Number, data.AMOUNT_THB.Value);
            //req.Parameters.Add("@SHIP_QTY", DataType.Number, data.SHIP_QTY.Value);
            //req.Parameters.Add("@COMPLETE_FLAG", DataType.Default, data.COMPLETE_FLAG.Value);
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
        /// <param name="oldRUN_NO">Old Key #2</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, CustomerOrderDDTO data, String oldORDER_NO, NZString oldORDER_DETAIL_NO)
        {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + CustomerOrderDDTO.eColumns.UPD_BY + "=@UPD_BY");
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.UPD_MACHINE + "=@UPD_MACHINE");
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.ORDER_NO + "=@ORDER_NO");
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.ORDER_NO + "=@ORDER_DETAIL_NO");
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.RUN_NO + "=@RUN_NO");
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.ITEM_CD + "=@ITEM_CD");
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.ITEM_DELIVERY_DATE + "=@ITEM_DELIVERY_DATE");
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.QTY + "=@QTY");
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.PRICE + "=@PRICE");
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.AMOUNT + "=@AMOUNT");
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.AMOUNT_THB + "=@AMOUNT_THB");
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.SHIP_QTY + "=@SHIP_QTY");
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.COMPLETE_FLAG + "=@COMPLETE_FLAG");
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.OLD_DATA + "=@OLD_DATA");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + CustomerOrderDDTO.eColumns.ORDER_NO + "=@oldORDER_NO");
            sb.AppendLine("  AND " + CustomerOrderDDTO.eColumns.ORDER_DETAIL_NO + "=@oldORDER_DATAIL_NO");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("@ORDER_NO", DataType.NVarChar, data.ORDER_NO.Value);
            req.Parameters.Add("@ORDER_DETAIL_NO", DataType.NVarChar, data.ORDER_DETAIL_NO.Value);
            req.Parameters.Add("@RUN_NO", DataType.Default, data.RUN_NO.Value);
            req.Parameters.Add("@ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("@ITEM_DELIVERY_DATE", DataType.DateTime, data.ITEM_DELIVERY_DATE.Value);
            req.Parameters.Add("@QTY", DataType.Number, data.QTY.Value);
            req.Parameters.Add("@PRICE", DataType.Number, data.PRICE.Value);
            req.Parameters.Add("@AMOUNT", DataType.Number, data.AMOUNT.Value);
            req.Parameters.Add("@AMOUNT_THB", DataType.Number, data.AMOUNT_THB.Value);
            req.Parameters.Add("@SHIP_QTY", DataType.Number, data.SHIP_QTY.Value);
            req.Parameters.Add("@COMPLETE_FLAG", DataType.Default, data.COMPLETE_FLAG.Value);
            req.Parameters.Add("@OLD_DATA", DataType.Default, 0);
            req.Parameters.Add("@oldORDER_NO", DataType.NVarChar, oldORDER_NO);
            req.Parameters.Add("@oldORDER_DATAIL_NO", DataType.Default, oldORDER_DETAIL_NO);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ORDER_NO">Key #1</param>
        /// <param name="RUN_NO">Key #2</param>
        /// <returns></returns>
        public int Delete(Database database, String ORDER_NO, NZString ORDER_DETAIL_NO)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(CustomerOrderDDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + CustomerOrderDDTO.eColumns.ORDER_NO + "=@ORDER_NO");
            sb.AppendLine("  AND " + CustomerOrderDDTO.eColumns.ORDER_DETAIL_NO + "=@ORDER_DETAIL_NO");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@ORDER_NO", DataType.NVarChar, ORDER_NO);
            req.Parameters.Add("@ORDER_DETAIL_NO", DataType.NVarChar, ORDER_DETAIL_NO.StrongValue);
            #endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, NZString ORDER_NO, NZString ORDER_DETAIL_NO)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(CustomerOrderDDTO));

            sb.AppendLine(" SELECT TOP 1 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + CustomerOrderDDTO.eColumns.ORDER_NO + "=@ORDER_NO");
            sb.AppendLine("  AND " + CustomerOrderDDTO.eColumns.ORDER_DETAIL_NO + "=@ORDER_DETAIL_NO");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@ORDER_NO", DataType.NVarChar, ORDER_NO.Value);
            req.Parameters.Add("@ORDER_DETAIL_NO", DataType.NVarChar, ORDER_DETAIL_NO.Value);
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
        public List<CustomerOrderDDTO> LoadAll(Database database)
        {
            return LoadAll(database, true,
                CustomerOrderDDTO.eColumns.ORDER_NO
                , CustomerOrderDDTO.eColumns.RUN_NO
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<CustomerOrderDDTO> LoadAll(Database database, bool ascending)
        {
            return LoadAll(database, ascending,
                CustomerOrderDDTO.eColumns.ORDER_NO
                , CustomerOrderDDTO.eColumns.RUN_NO
            );
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<CustomerOrderDDTO> LoadAll(Database database, bool ascending, params CustomerOrderDDTO.eColumns[] orderByColumns)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(CustomerOrderDDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + CustomerOrderDDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.ORDER_NO);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.RUN_NO);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.ITEM_DELIVERY_DATE);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.QTY);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.PRICE);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.AMOUNT);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.AMOUNT_THB);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.SHIP_QTY);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.COMPLETE_FLAG);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.OLD_DATA);
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

            return db.ExecuteForList<CustomerOrderDDTO>(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ORDER_NO">Key #1</param>
        /// <param name="RUN_NO">Key #2</param>
        /// <returns></returns>
        public CustomerOrderDDTO LoadByPK(Database database, String ORDER_NO, NZString ORDER_DETAIL_NO)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(CustomerOrderDDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + CustomerOrderDDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.ORDER_NO);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.ORDER_DETAIL_NO);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.RUN_NO);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.ITEM_DELIVERY_DATE);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.QTY);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.PRICE);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.AMOUNT);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.AMOUNT_THB);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.SHIP_QTY);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.COMPLETE_FLAG);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.OLD_DATA);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + CustomerOrderDDTO.eColumns.ORDER_NO + "=@ORDER_NO");
            sb.AppendLine(String.Format(" AND ({0} is null OR {1} = {0})", CustomerOrderDDTO.eColumns.ORDER_DETAIL_NO, "@ORDER_DETAIL_NO"));
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@ORDER_NO", DataType.NVarChar, ORDER_NO);
            req.Parameters.Add("@ORDER_DETAIL_NO", DataType.NVarChar, CheckNull(ORDER_DETAIL_NO.StrongValue));
            #endregion

            List<CustomerOrderDDTO> list = db.ExecuteForList<CustomerOrderDDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }

        public List<CustomerOrderDDTO> LoadAllDetail(Database database, String ORDER_NO)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(CustomerOrderDDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + CustomerOrderDDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.ORDER_NO);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.ORDER_DETAIL_NO);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.RUN_NO);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.ITEM_DELIVERY_DATE);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.QTY);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.PRICE);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.AMOUNT);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.AMOUNT_THB);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.SHIP_QTY);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.COMPLETE_FLAG);
            sb.AppendLine("  ," + CustomerOrderDDTO.eColumns.OLD_DATA);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + CustomerOrderDDTO.eColumns.ORDER_NO + "=@ORDER_NO");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@ORDER_NO", DataType.NVarChar, ORDER_NO);
            #endregion

            return db.ExecuteForList<CustomerOrderDDTO>(req);
        }

        #endregion
    }
}

