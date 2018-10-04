/* Create by: Mr.Teerayut Sinlan
 * Create on: 2554-06-10
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
    internal partial class PurchaseOrderHDAO
    {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public PurchaseOrderHDAO() { }

        public PurchaseOrderHDAO(Database db)
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
        public int AddNewOrUpdate(Database database, PurchaseOrderHDTO data)
        {
            Database db = UseDatabase(database);

            if (Exist(database, data.PO_NO))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, PurchaseOrderHDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            sb.AppendLine("  " + PurchaseOrderHDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.IS_ACTIVE);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.PO_NO);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.PO_TYPE);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.PO_DATE);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.SUPPLIER_CD);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.SUPPLIER_NAME);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.ADDRESS);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.DELIVERY_TO);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.CURRENCY);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.VAT_TYPE);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.VAT_RATE);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.TERM_OF_PAYMENT);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.IS_EXPORT);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.STATUS);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.REMARK);
            sb.AppendLine(") VALUES(");
            sb.AppendLine("   :CRT_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,:CRT_MACHINE");
            sb.AppendLine("   ,:UPD_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,:UPD_MACHINE");
            sb.AppendLine("   ,:IS_ACTIVE");
            sb.AppendLine("   ,:PO_NO");
            sb.AppendLine("   ,:PO_TYPE");
            sb.AppendLine("   ,:PO_DATE");
            sb.AppendLine("   ,:SUPPLIER_CD");
            sb.AppendLine("   ,:SUPPLIER_NAME");
            sb.AppendLine("   ,:ADDRESS");
            sb.AppendLine("   ,:DELIVERY_TO");
            sb.AppendLine("   ,:CURRENCY");
            sb.AppendLine("   ,:VAT_TYPE");
            sb.AppendLine("   ,:VAT_RATE");
            sb.AppendLine("   ,:TERM_OF_PAYMENT");
            sb.AppendLine("   ,:IS_EXPORT");
            sb.AppendLine("   ,:STATUS");
            sb.AppendLine("   ,:REMARK");
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
            req.Parameters.Add("PO_TYPE", DataType.NVarChar, data.PO_TYPE.Value);
            req.Parameters.Add("PO_DATE", DataType.Default, data.PO_DATE.Value);
            req.Parameters.Add("SUPPLIER_CD", DataType.NVarChar, data.SUPPLIER_CD.Value);
            req.Parameters.Add("SUPPLIER_NAME", DataType.NVarChar, data.SUPPLIER_NAME.Value);
            req.Parameters.Add("ADDRESS", DataType.NVarChar, data.ADDRESS.Value);
            req.Parameters.Add("DELIVERY_TO", DataType.NVarChar, data.DELIVERY_TO.Value);
            req.Parameters.Add("CURRENCY", DataType.NVarChar, data.CURRENCY.Value);
            req.Parameters.Add("VAT_TYPE", DataType.NVarChar, data.VAT_TYPE.Value);
            req.Parameters.Add("VAT_RATE", DataType.Number, data.VAT_RATE.Value);
            req.Parameters.Add("TERM_OF_PAYMENT", DataType.NVarChar, data.TERM_OF_PAYMENT.Value);
            req.Parameters.Add("IS_EXPORT", DataType.Default, data.IS_EXPORT.Value);
            req.Parameters.Add("STATUS", DataType.NVarChar, data.STATUS.Value);
            req.Parameters.Add("REMARK", DataType.NVarChar, data.REMARK.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using primary key value on the given data variable
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data with primary key value.</param>
        /// <returns></returns>
        public int UpdateWithoutPK(Database database, PurchaseOrderHDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + PurchaseOrderHDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.IS_ACTIVE + "=:IS_ACTIVE");
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.PO_TYPE + "=:PO_TYPE");
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.PO_DATE + "=:PO_DATE");
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.SUPPLIER_CD + "=:SUPPLIER_CD");
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.SUPPLIER_NAME + "=:SUPPLIER_NAME");
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.ADDRESS + "=:ADDRESS");
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.DELIVERY_TO + "=:DELIVERY_TO");
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.CURRENCY + "=:CURRENCY");
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.VAT_TYPE + "=:VAT_TYPE");
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.VAT_RATE + "=:VAT_RATE");
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.TERM_OF_PAYMENT + "=:TERM_OF_PAYMENT");
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.IS_EXPORT + "=:IS_EXPORT");
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.STATUS + "=:STATUS");
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.REMARK + "=:REMARK");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + PurchaseOrderHDTO.eColumns.PO_NO + "=:PO_NO");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("IS_ACTIVE", DataType.Default, data.IS_ACTIVE.Value);
            req.Parameters.Add("PO_NO", DataType.NVarChar, data.PO_NO.Value);
            req.Parameters.Add("PO_TYPE", DataType.NVarChar, data.PO_TYPE.Value);
            req.Parameters.Add("PO_DATE", DataType.Default, data.PO_DATE.Value);
            req.Parameters.Add("SUPPLIER_CD", DataType.NVarChar, data.SUPPLIER_CD.Value);
            req.Parameters.Add("SUPPLIER_NAME", DataType.NVarChar, data.SUPPLIER_NAME.Value);
            req.Parameters.Add("ADDRESS", DataType.NVarChar, data.ADDRESS.Value);
            req.Parameters.Add("DELIVERY_TO", DataType.NVarChar, data.DELIVERY_TO.Value);
            req.Parameters.Add("CURRENCY", DataType.NVarChar, data.CURRENCY.Value);
            req.Parameters.Add("VAT_TYPE", DataType.NVarChar, data.VAT_TYPE.Value);
            req.Parameters.Add("VAT_RATE", DataType.Number, data.VAT_RATE.Value);
            req.Parameters.Add("TERM_OF_PAYMENT", DataType.NVarChar, data.TERM_OF_PAYMENT.Value);
            req.Parameters.Add("IS_EXPORT", DataType.Default, data.IS_EXPORT.Value);
            req.Parameters.Add("STATUS", DataType.NVarChar, data.STATUS.Value);
            req.Parameters.Add("REMARK", DataType.NVarChar, data.REMARK.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using the table's primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data which to update.</param>
        /// <param name="oldPO_NO">Old Key #1</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, PurchaseOrderHDTO data, String oldPO_NO)
        {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + PurchaseOrderHDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.IS_ACTIVE + "=:IS_ACTIVE");
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.PO_NO + "=:PO_NO");
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.PO_TYPE + "=:PO_TYPE");
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.PO_DATE + "=:PO_DATE");
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.SUPPLIER_CD + "=:SUPPLIER_CD");
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.SUPPLIER_NAME + "=:SUPPLIER_NAME");
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.ADDRESS + "=:ADDRESS");
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.DELIVERY_TO + "=:DELIVERY_TO");
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.CURRENCY + "=:CURRENCY");
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.VAT_TYPE + "=:VAT_TYPE");
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.VAT_RATE + "=:VAT_RATE");
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.TERM_OF_PAYMENT + "=:TERM_OF_PAYMENT");
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.IS_EXPORT + "=:IS_EXPORT");
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.STATUS + "=:STATUS");
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.REMARK + "=:REMARK");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + PurchaseOrderHDTO.eColumns.PO_NO + "=:oldPO_NO");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("IS_ACTIVE", DataType.Default, data.IS_ACTIVE.Value);
            req.Parameters.Add("PO_NO", DataType.NVarChar, data.PO_NO.Value);
            req.Parameters.Add("PO_TYPE", DataType.NVarChar, data.PO_TYPE.Value);
            req.Parameters.Add("PO_DATE", DataType.Default, data.PO_DATE.Value);
            req.Parameters.Add("SUPPLIER_CD", DataType.NVarChar, data.SUPPLIER_CD.Value);
            req.Parameters.Add("SUPPLIER_NAME", DataType.NVarChar, data.SUPPLIER_NAME.Value);
            req.Parameters.Add("ADDRESS", DataType.NVarChar, data.ADDRESS.Value);
            req.Parameters.Add("DELIVERY_TO", DataType.NVarChar, data.DELIVERY_TO.Value);
            req.Parameters.Add("CURRENCY", DataType.NVarChar, data.CURRENCY.Value);
            req.Parameters.Add("VAT_TYPE", DataType.NVarChar, data.VAT_TYPE.Value);
            req.Parameters.Add("VAT_RATE", DataType.Number, data.VAT_RATE.Value);
            req.Parameters.Add("TERM_OF_PAYMENT", DataType.NVarChar, data.TERM_OF_PAYMENT.Value);
            req.Parameters.Add("IS_EXPORT", DataType.Default, data.IS_EXPORT.Value);
            req.Parameters.Add("STATUS", DataType.NVarChar, data.STATUS.Value);
            req.Parameters.Add("REMARK", DataType.NVarChar, data.REMARK.Value);
            req.Parameters.Add("oldPO_NO", DataType.NVarChar, oldPO_NO);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="PO_NO">Key #1</param>
        /// <returns></returns>
        public int Delete(Database database, String PO_NO)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(PurchaseOrderHDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + PurchaseOrderHDTO.eColumns.PO_NO + "=:PO_NO");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("PO_NO", DataType.NVarChar, PO_NO);
            #endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, String PO_NO)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(PurchaseOrderHDTO));

            sb.AppendLine(" SELECT TOP 1 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + PurchaseOrderHDTO.eColumns.PO_NO + "=:PO_NO");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("PO_NO", DataType.NVarChar, PO_NO);
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
        public List<PurchaseOrderHDTO> LoadAll(Database database)
        {
            return LoadAll(database, true,
                PurchaseOrderHDTO.eColumns.PO_NO
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<PurchaseOrderHDTO> LoadAll(Database database, bool ascending)
        {
            return LoadAll(database, ascending,
                PurchaseOrderHDTO.eColumns.PO_NO
            );
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<PurchaseOrderHDTO> LoadAll(Database database, bool ascending, params PurchaseOrderHDTO.eColumns[] orderByColumns)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(PurchaseOrderHDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + PurchaseOrderHDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.IS_ACTIVE);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.PO_NO);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.PO_TYPE);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.PO_DATE);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.SUPPLIER_CD);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.SUPPLIER_NAME);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.ADDRESS);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.DELIVERY_TO);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.CURRENCY);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.VAT_TYPE);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.VAT_RATE);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.TERM_OF_PAYMENT);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.IS_EXPORT);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.STATUS);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.REMARK);
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

            return db.ExecuteForList<PurchaseOrderHDTO>(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="PO_NO">Key #1</param>
        /// <returns></returns>
        public PurchaseOrderHDTO LoadByPK(Database database, String PO_NO)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(PurchaseOrderHDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + PurchaseOrderHDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.IS_ACTIVE);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.PO_NO);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.PO_TYPE);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.PO_DATE);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.SUPPLIER_CD);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.SUPPLIER_NAME);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.ADDRESS);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.DELIVERY_TO);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.CURRENCY);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.VAT_TYPE);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.VAT_RATE);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.TERM_OF_PAYMENT);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.IS_EXPORT);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.STATUS);
            sb.AppendLine("  ," + PurchaseOrderHDTO.eColumns.REMARK);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + PurchaseOrderHDTO.eColumns.PO_NO + "=:PO_NO");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("PO_NO", DataType.NVarChar, PO_NO);
            #endregion

            List<PurchaseOrderHDTO> list = db.ExecuteForList<PurchaseOrderHDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        #endregion
    }
}

