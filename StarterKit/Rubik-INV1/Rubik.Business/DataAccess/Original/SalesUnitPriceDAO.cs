/* Create by: Ms. Sansanee K.
 * Create on: 2012-03-19
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

namespace Rubik.DAO {
    internal partial class SalesUnitPriceDAO {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public SalesUnitPriceDAO() { }

        public SalesUnitPriceDAO(Database db) {
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
        public int AddNewOrUpdate(Database database, SalesUnitPriceDTO data) {
            Database db = UseDatabase(database);

            if (Exist(database, data.ITEM_CD, data.START_EFFECTIVE_DATE, data.CURRENCY))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, SalesUnitPriceDTO data) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            sb.AppendLine("  " + SalesUnitPriceDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.START_EFFECTIVE_DATE);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.PRICE);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.CURRENCY);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.REMARK);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.OLD_DATA);
            sb.AppendLine(") VALUES(");
            sb.AppendLine("   @CRT_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,@CRT_MACHINE");
            sb.AppendLine("   ,@UPD_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,@UPD_MACHINE");
            sb.AppendLine("   ,@ITEM_CD");
            sb.AppendLine("   ,@START_EFFECTIVE_DATE");
            sb.AppendLine("   ,@PRICE");
            sb.AppendLine("   ,@CURRENCY");
            sb.AppendLine("   ,@REMARK");
            sb.AppendLine("   ,@OLD_DATA");
            sb.AppendLine(" )");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@CRT_BY", DataType.NVarChar, data.CRT_BY.Value);
            req.Parameters.Add("@CRT_MACHINE", DataType.NVarChar, data.CRT_MACHINE.Value);
            req.Parameters.Add("@UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("@ITEM_CD", DataType.Default, data.ITEM_CD.Value);
            req.Parameters.Add("@START_EFFECTIVE_DATE", DataType.DateTime, data.START_EFFECTIVE_DATE.Value);
            req.Parameters.Add("@PRICE", DataType.Number, data.PRICE.Value);
            req.Parameters.Add("@CURRENCY", DataType.NVarChar, data.CURRENCY.Value);
            req.Parameters.Add("@REMARK", DataType.NVarChar, data.REMARK.Value);
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
        public int UpdateWithoutPK(Database database, SalesUnitPriceDTO data) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + SalesUnitPriceDTO.eColumns.UPD_BY + "=@UPD_BY");
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.UPD_MACHINE + "=@UPD_MACHINE");
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.PRICE + "=@PRICE");
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.REMARK + "=@REMARK");
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.OLD_DATA + "=@OLD_DATA");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + SalesUnitPriceDTO.eColumns.ITEM_CD + "=@ITEM_CD");
            sb.AppendLine("  AND " + SalesUnitPriceDTO.eColumns.START_EFFECTIVE_DATE + "=@START_EFFECTIVE_DATE");
            sb.AppendLine("  AND " + SalesUnitPriceDTO.eColumns.CURRENCY + "=@CURRENCY");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("@ITEM_CD", DataType.Default, data.ITEM_CD.Value);
            req.Parameters.Add("@START_EFFECTIVE_DATE", DataType.DateTime, data.START_EFFECTIVE_DATE.Value);
            req.Parameters.Add("@PRICE", DataType.Number, data.PRICE.Value);
            req.Parameters.Add("@CURRENCY", DataType.NVarChar, data.CURRENCY.Value);
            req.Parameters.Add("@REMARK", DataType.NVarChar, data.REMARK.Value);
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
        /// <param name="oldSTART_EFFECTIVE_DATE">Old Key #2</param>
        /// <param name="oldCURRENCY">Old Key #3</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, SalesUnitPriceDTO data, NZInt oldITEM_CD, DateTime oldSTART_EFFECTIVE_DATE, String oldCURRENCY) {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + SalesUnitPriceDTO.eColumns.UPD_BY + "=@UPD_BY");
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.UPD_MACHINE + "=@UPD_MACHINE");
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.ITEM_CD + "=@ITEM_CD");
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.START_EFFECTIVE_DATE + "=@START_EFFECTIVE_DATE");
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.PRICE + "=@PRICE");
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.CURRENCY + "=@CURRENCY");
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.REMARK + "=@REMARK");
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.OLD_DATA + "=@OLD_DATA");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + SalesUnitPriceDTO.eColumns.ITEM_CD + "=@oldITEM_CD");
            sb.AppendLine("  AND " + SalesUnitPriceDTO.eColumns.START_EFFECTIVE_DATE + "=@oldSalesUnitPrice");
            sb.AppendLine("  AND " + SalesUnitPriceDTO.eColumns.CURRENCY + "=@oldSalesUnitPrice");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("@ITEM_CD", DataType.Default, data.ITEM_CD.Value);
            req.Parameters.Add("@START_EFFECTIVE_DATE", DataType.DateTime, data.START_EFFECTIVE_DATE.Value);
            req.Parameters.Add("@PRICE", DataType.Number, data.PRICE.Value);
            req.Parameters.Add("@CURRENCY", DataType.NVarChar, data.CURRENCY.Value);
            req.Parameters.Add("@REMARK", DataType.NVarChar, data.REMARK.Value);
            req.Parameters.Add("@OLD_DATA", DataType.Default, data.OLD_DATA.Value);
            req.Parameters.Add("@oldITEM_CD", DataType.Default, oldITEM_CD);
            req.Parameters.Add("@oldSTART_EFFECTIVE_DATE", DataType.DateTime, oldSTART_EFFECTIVE_DATE);
            req.Parameters.Add("@oldCURRENCY", DataType.NVarChar, oldCURRENCY);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ITEM_CD">Key #1</param>
        /// <param name="START_EFFECTIVE_DATE">Key #2</param>
        /// <param name="CURRENCY">Key #3</param>
        /// <returns></returns>
        public int Delete(Database database, NZInt ITEM_CD, DateTime START_EFFECTIVE_DATE, String CURRENCY) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(SalesUnitPriceDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + SalesUnitPriceDTO.eColumns.ITEM_CD + "=@ITEM_CD");
            sb.AppendLine("  AND " + SalesUnitPriceDTO.eColumns.START_EFFECTIVE_DATE + "=@START_EFFECTIVE_DATE");
            sb.AppendLine("  AND " + SalesUnitPriceDTO.eColumns.CURRENCY + "=@CURRENCY");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@ITEM_CD", DataType.Default, ITEM_CD);
            req.Parameters.Add("@START_EFFECTIVE_DATE", DataType.DateTime, START_EFFECTIVE_DATE);
            req.Parameters.Add("@CURRENCY", DataType.NVarChar, CURRENCY);
            #endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, NZInt ITEM_CD, DateTime START_EFFECTIVE_DATE, String CURRENCY) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(SalesUnitPriceDTO));

            sb.AppendLine(" SELECT TOP 1 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + SalesUnitPriceDTO.eColumns.ITEM_CD + "=@ITEM_CD");
            sb.AppendLine("  AND " + SalesUnitPriceDTO.eColumns.START_EFFECTIVE_DATE + "=@START_EFFECTIVE_DATE");
            sb.AppendLine("  AND " + SalesUnitPriceDTO.eColumns.CURRENCY + "=@CURRENCY");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@ITEM_CD", DataType.Default, ITEM_CD);
            req.Parameters.Add("@START_EFFECTIVE_DATE", DataType.DateTime, START_EFFECTIVE_DATE);
            req.Parameters.Add("@CURRENCY", DataType.NVarChar, CURRENCY);
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
        public List<SalesUnitPriceDTO> LoadAll(Database database) {
            return LoadAll(database, true,
                SalesUnitPriceDTO.eColumns.ITEM_CD
                , SalesUnitPriceDTO.eColumns.START_EFFECTIVE_DATE
                , SalesUnitPriceDTO.eColumns.CURRENCY
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<SalesUnitPriceDTO> LoadAll(Database database, bool ascending) {
            return LoadAll(database, ascending,
                SalesUnitPriceDTO.eColumns.ITEM_CD
                , SalesUnitPriceDTO.eColumns.START_EFFECTIVE_DATE
                , SalesUnitPriceDTO.eColumns.CURRENCY
            );
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<SalesUnitPriceDTO> LoadAll(Database database, bool ascending, params SalesUnitPriceDTO.eColumns[] orderByColumns) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(SalesUnitPriceDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + SalesUnitPriceDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.START_EFFECTIVE_DATE);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.PRICE);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.CURRENCY);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.REMARK);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.OLD_DATA);
            //sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.TIME_STAMP);
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

            return db.ExecuteForList<SalesUnitPriceDTO>(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ITEM_CD">Key #1</param>
        /// <param name="START_EFFECTIVE_DATE">Key #2</param>
        /// <param name="CURRENCY">Key #3</param>
        /// <returns></returns>
        public SalesUnitPriceDTO LoadByPK(Database database, NZInt ITEM_CD, NZDateTime START_EFFECTIVE_DATE, NZString CURRENCY) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(SalesUnitPriceDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + SalesUnitPriceDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.START_EFFECTIVE_DATE);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.PRICE);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.CURRENCY);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.REMARK);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.OLD_DATA);
            //sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.TIME_STAMP);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + SalesUnitPriceDTO.eColumns.ITEM_CD + "=@ITEM_CD");
            sb.AppendLine("  AND " + SalesUnitPriceDTO.eColumns.START_EFFECTIVE_DATE + "=@START_EFFECTIVE_DATE");
            sb.AppendLine("  AND " + SalesUnitPriceDTO.eColumns.CURRENCY + "=@CURRENCY");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@ITEM_CD", DataType.Default, ITEM_CD.Value);
            req.Parameters.Add("@START_EFFECTIVE_DATE", DataType.DateTime, START_EFFECTIVE_DATE.Value);
            req.Parameters.Add("@CURRENCY", DataType.NVarChar, CURRENCY.Value);
            #endregion

            List<SalesUnitPriceDTO> list = db.ExecuteForList<SalesUnitPriceDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        #endregion
    }
}

