/* Create by: Ms. Sansanee K.
 * Create on: 2012-02-17
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
using System.Data;

namespace Rubik.DAO {
    internal partial class DealingDAO {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public DealingDAO() { }

        public DealingDAO(Database db) {
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
        public int AddNewOrUpdate(Database database, DealingDTO data) {
            Database db = UseDatabase(database);

            if (Exist(database, data.LOC_CD))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, DealingDTO data) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            sb.AppendLine("  " + DealingDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + DealingDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + DealingDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + DealingDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + DealingDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + DealingDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + DealingDTO.eColumns.LOC_CD);
            sb.AppendLine("  ," + DealingDTO.eColumns.LOC_DESC);
            sb.AppendLine("  ," + DealingDTO.eColumns.LOC_CLS);
            sb.AppendLine("  ," + DealingDTO.eColumns.TERM_OF_PAYMENT);
            sb.AppendLine("  ," + DealingDTO.eColumns.INVOICE_PATTERN);
            sb.AppendLine("  ," + DealingDTO.eColumns.ADDRESS1);
            sb.AppendLine("  ," + DealingDTO.eColumns.TEL1);
            sb.AppendLine("  ," + DealingDTO.eColumns.FAX1);
            sb.AppendLine("  ," + DealingDTO.eColumns.EMAIL1);
            sb.AppendLine("  ," + DealingDTO.eColumns.CONTACT_PERSON1);
            sb.AppendLine("  ," + DealingDTO.eColumns.REMARK1);
            sb.AppendLine("  ," + DealingDTO.eColumns.ADDRESS2);
            sb.AppendLine("  ," + DealingDTO.eColumns.TEL2);
            sb.AppendLine("  ," + DealingDTO.eColumns.FAX2);
            sb.AppendLine("  ," + DealingDTO.eColumns.EMAIL2);
            sb.AppendLine("  ," + DealingDTO.eColumns.CONTACT_PERSON2);
            sb.AppendLine("  ," + DealingDTO.eColumns.REMARK2);
            sb.AppendLine("  ," + DealingDTO.eColumns.ADDRESS3);
            sb.AppendLine("  ," + DealingDTO.eColumns.TEL3);
            sb.AppendLine("  ," + DealingDTO.eColumns.FAX3);
            sb.AppendLine("  ," + DealingDTO.eColumns.EMAIL3);
            sb.AppendLine("  ," + DealingDTO.eColumns.CONTACT_PERSON3);
            sb.AppendLine("  ," + DealingDTO.eColumns.REMARK3);
            sb.AppendLine("  ," + DealingDTO.eColumns.ALLOW_NEGATIVE);
            sb.AppendLine("  ," + DealingDTO.eColumns.OLD_DATA);
            sb.AppendLine(") VALUES(");
            sb.AppendLine("   @CRT_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,@CRT_MACHINE");
            sb.AppendLine("   ,@UPD_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,@UPD_MACHINE");
            sb.AppendLine("   ,@LOC_CD");
            sb.AppendLine("   ,@LOC_DESC");
            sb.AppendLine("   ,@LOC_CLS");
            sb.AppendLine("   ,@TERM_OF_PAYMENT");
            sb.AppendLine("   ,@INVOICE_PATTERN");
            sb.AppendLine("   ,@ADDRESS1");
            sb.AppendLine("   ,@TEL1");
            sb.AppendLine("   ,@FAX1");
            sb.AppendLine("   ,@EMAIL1");
            sb.AppendLine("   ,@CONTACT_PERSON1");
            sb.AppendLine("   ,@REMARK1");
            sb.AppendLine("   ,@ADDRESS2");
            sb.AppendLine("   ,@TEL2");
            sb.AppendLine("   ,@FAX2");
            sb.AppendLine("   ,@EMAIL2");
            sb.AppendLine("   ,@CONTACT_PERSON2");
            sb.AppendLine("   ,@REMARK2");
            sb.AppendLine("   ,@ADDRESS3");
            sb.AppendLine("   ,@TEL3");
            sb.AppendLine("   ,@FAX3");
            sb.AppendLine("   ,@EMAIL3");
            sb.AppendLine("   ,@CONTACT_PERSON3");
            sb.AppendLine("   ,@REMARK3");
            sb.AppendLine("   ,@ALLOW_NEGATIVE");
            sb.AppendLine("   ,@OLD_DATA");
            sb.AppendLine(" )");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@CRT_BY", DataType.NVarChar, data.CRT_BY.Value);
            req.Parameters.Add("@CRT_MACHINE", DataType.NVarChar, data.CRT_MACHINE.Value);
            req.Parameters.Add("@UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("@LOC_CD", DataType.NVarChar, data.LOC_CD.Value);
            req.Parameters.Add("@LOC_DESC", DataType.NVarChar, data.LOC_DESC.Value);
            req.Parameters.Add("@LOC_CLS", DataType.NVarChar, data.LOC_CLS.Value);
            req.Parameters.Add("@TERM_OF_PAYMENT", DataType.NVarChar, data.TERM_OF_PAYMENT.Value);
            req.Parameters.Add("@INVOICE_PATTERN", DataType.NVarChar, data.INVOICE_PATTERN.Value);
            req.Parameters.Add("@ADDRESS1", DataType.NVarChar, data.ADDRESS1.Value);
            req.Parameters.Add("@TEL1", DataType.NVarChar, data.TEL1.Value);
            req.Parameters.Add("@FAX1", DataType.NVarChar, data.FAX1.Value);
            req.Parameters.Add("@EMAIL1", DataType.NVarChar, data.EMAIL1.Value);
            req.Parameters.Add("@CONTACT_PERSON1", DataType.NVarChar, data.CONTACT_PERSON1.Value);
            req.Parameters.Add("@REMARK1", DataType.NVarChar, data.REMARK1.Value);
            req.Parameters.Add("@ADDRESS2", DataType.NVarChar, data.ADDRESS2.Value);
            req.Parameters.Add("@TEL2", DataType.NVarChar, data.TEL2.Value);
            req.Parameters.Add("@FAX2", DataType.NVarChar, data.FAX2.Value);
            req.Parameters.Add("@EMAIL2", DataType.NVarChar, data.EMAIL2.Value);
            req.Parameters.Add("@CONTACT_PERSON2", DataType.NVarChar, data.CONTACT_PERSON2.Value);
            req.Parameters.Add("@REMARK2", DataType.NVarChar, data.REMARK2.Value);
            req.Parameters.Add("@ADDRESS3", DataType.NVarChar, data.ADDRESS3.Value);
            req.Parameters.Add("@TEL3", DataType.NVarChar, data.TEL3.Value);
            req.Parameters.Add("@FAX3", DataType.NVarChar, data.FAX3.Value);
            req.Parameters.Add("@EMAIL3", DataType.NVarChar, data.EMAIL3.Value);
            req.Parameters.Add("@CONTACT_PERSON3", DataType.NVarChar, data.CONTACT_PERSON3.Value);
            req.Parameters.Add("@REMARK3", DataType.NVarChar, data.REMARK3.Value);
            req.Parameters.Add("@ALLOW_NEGATIVE", DataType.NVarChar, data.ALLOW_NEGATIVE.Value);
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
        public int UpdateWithoutPK(Database database, DealingDTO data) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + DealingDTO.eColumns.UPD_BY + "=@UPD_BY");
            sb.AppendLine("  ," + DealingDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + DealingDTO.eColumns.UPD_MACHINE + "=@UPD_MACHINE");
            sb.AppendLine("  ," + DealingDTO.eColumns.LOC_DESC + "=@LOC_DESC");
            sb.AppendLine("  ," + DealingDTO.eColumns.LOC_CLS + "=@LOC_CLS");
            sb.AppendLine("  ," + DealingDTO.eColumns.TERM_OF_PAYMENT + "=@TERM_OF_PAYMENT");
            sb.AppendLine("  ," + DealingDTO.eColumns.INVOICE_PATTERN + "=@INVOICE_PATTERN");
            sb.AppendLine("  ," + DealingDTO.eColumns.ADDRESS1 + "=@ADDRESS1");
            sb.AppendLine("  ," + DealingDTO.eColumns.TEL1 + "=@TEL1");
            sb.AppendLine("  ," + DealingDTO.eColumns.FAX1 + "=@FAX1");
            sb.AppendLine("  ," + DealingDTO.eColumns.EMAIL1 + "=@EMAIL1");
            sb.AppendLine("  ," + DealingDTO.eColumns.CONTACT_PERSON1 + "=@CONTACT_PERSON1");
            sb.AppendLine("  ," + DealingDTO.eColumns.REMARK1 + "=@REMARK1");
            sb.AppendLine("  ," + DealingDTO.eColumns.ADDRESS2 + "=@ADDRESS2");
            sb.AppendLine("  ," + DealingDTO.eColumns.TEL2 + "=@TEL2");
            sb.AppendLine("  ," + DealingDTO.eColumns.FAX2 + "=@FAX2");
            sb.AppendLine("  ," + DealingDTO.eColumns.EMAIL2 + "=@EMAIL2");
            sb.AppendLine("  ," + DealingDTO.eColumns.CONTACT_PERSON2 + "=@CONTACT_PERSON2");
            sb.AppendLine("  ," + DealingDTO.eColumns.REMARK2 + "=@REMARK2");
            sb.AppendLine("  ," + DealingDTO.eColumns.ADDRESS3 + "=@ADDRESS3");
            sb.AppendLine("  ," + DealingDTO.eColumns.TEL3 + "=@TEL3");
            sb.AppendLine("  ," + DealingDTO.eColumns.FAX3 + "=@FAX3");
            sb.AppendLine("  ," + DealingDTO.eColumns.EMAIL3 + "=@EMAIL3");
            sb.AppendLine("  ," + DealingDTO.eColumns.CONTACT_PERSON3 + "=@CONTACT_PERSON3");
            sb.AppendLine("  ," + DealingDTO.eColumns.REMARK3 + "=@REMARK3");
            sb.AppendLine("  ," + DealingDTO.eColumns.ALLOW_NEGATIVE + "=@ALLOW_NEGATIVE");
            sb.AppendLine("  ," + DealingDTO.eColumns.OLD_DATA + "=@OLD_DATA");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + DealingDTO.eColumns.LOC_CD + "=@LOC_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("@LOC_CD", DataType.NVarChar, data.LOC_CD.Value);
            req.Parameters.Add("@LOC_DESC", DataType.NVarChar, data.LOC_DESC.Value);
            req.Parameters.Add("@LOC_CLS", DataType.NVarChar, data.LOC_CLS.Value);
            req.Parameters.Add("@TERM_OF_PAYMENT", DataType.NVarChar, data.TERM_OF_PAYMENT.Value);
            req.Parameters.Add("@INVOICE_PATTERN", DataType.NVarChar, data.INVOICE_PATTERN.Value);
            req.Parameters.Add("@ADDRESS1", DataType.NVarChar, data.ADDRESS1.Value);
            req.Parameters.Add("@TEL1", DataType.NVarChar, data.TEL1.Value);
            req.Parameters.Add("@FAX1", DataType.NVarChar, data.FAX1.Value);
            req.Parameters.Add("@EMAIL1", DataType.NVarChar, data.EMAIL1.Value);
            req.Parameters.Add("@CONTACT_PERSON1", DataType.NVarChar, data.CONTACT_PERSON1.Value);
            req.Parameters.Add("@REMARK1", DataType.NVarChar, data.REMARK1.Value);
            req.Parameters.Add("@ADDRESS2", DataType.NVarChar, data.ADDRESS2.Value);
            req.Parameters.Add("@TEL2", DataType.NVarChar, data.TEL2.Value);
            req.Parameters.Add("@FAX2", DataType.NVarChar, data.FAX2.Value);
            req.Parameters.Add("@EMAIL2", DataType.NVarChar, data.EMAIL2.Value);
            req.Parameters.Add("@CONTACT_PERSON2", DataType.NVarChar, data.CONTACT_PERSON2.Value);
            req.Parameters.Add("@REMARK2", DataType.NVarChar, data.REMARK2.Value);
            req.Parameters.Add("@ADDRESS3", DataType.NVarChar, data.ADDRESS3.Value);
            req.Parameters.Add("@TEL3", DataType.NVarChar, data.TEL3.Value);
            req.Parameters.Add("@FAX3", DataType.NVarChar, data.FAX3.Value);
            req.Parameters.Add("@EMAIL3", DataType.NVarChar, data.EMAIL3.Value);
            req.Parameters.Add("@CONTACT_PERSON3", DataType.NVarChar, data.CONTACT_PERSON3.Value);
            req.Parameters.Add("@REMARK3", DataType.NVarChar, data.REMARK3.Value);
            req.Parameters.Add("@ALLOW_NEGATIVE", DataType.NVarChar, data.ALLOW_NEGATIVE.Value);
            req.Parameters.Add("@OLD_DATA", DataType.Default, data.OLD_DATA.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using the table's primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data which to update.</param>
        /// <param name="oldLOC_CD">Old Key #1</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, DealingDTO data, String oldLOC_CD) {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + DealingDTO.eColumns.UPD_BY + "=@UPD_BY");
            sb.AppendLine("  ," + DealingDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + DealingDTO.eColumns.UPD_MACHINE + "=@UPD_MACHINE");
            sb.AppendLine("  ," + DealingDTO.eColumns.LOC_CD + "=@LOC_CD");
            sb.AppendLine("  ," + DealingDTO.eColumns.LOC_DESC + "=@LOC_DESC");
            sb.AppendLine("  ," + DealingDTO.eColumns.LOC_CLS + "=@LOC_CLS");
            sb.AppendLine("  ," + DealingDTO.eColumns.TERM_OF_PAYMENT + "=@TERM_OF_PAYMENT");
            sb.AppendLine("  ," + DealingDTO.eColumns.INVOICE_PATTERN + "=@INVOICE_PATTERN");
            sb.AppendLine("  ," + DealingDTO.eColumns.ADDRESS1 + "=@ADDRESS1");
            sb.AppendLine("  ," + DealingDTO.eColumns.TEL1 + "=@TEL1");
            sb.AppendLine("  ," + DealingDTO.eColumns.FAX1 + "=@FAX1");
            sb.AppendLine("  ," + DealingDTO.eColumns.EMAIL1 + "=@EMAIL1");
            sb.AppendLine("  ," + DealingDTO.eColumns.CONTACT_PERSON1 + "=@CONTACT_PERSON1");
            sb.AppendLine("  ," + DealingDTO.eColumns.REMARK1 + "=@REMARK1");
            sb.AppendLine("  ," + DealingDTO.eColumns.ADDRESS2 + "=@ADDRESS2");
            sb.AppendLine("  ," + DealingDTO.eColumns.TEL2 + "=@TEL2");
            sb.AppendLine("  ," + DealingDTO.eColumns.FAX2 + "=@FAX2");
            sb.AppendLine("  ," + DealingDTO.eColumns.EMAIL2 + "=@EMAIL2");
            sb.AppendLine("  ," + DealingDTO.eColumns.CONTACT_PERSON2 + "=@CONTACT_PERSON2");
            sb.AppendLine("  ," + DealingDTO.eColumns.REMARK2 + "=@REMARK2");
            sb.AppendLine("  ," + DealingDTO.eColumns.ADDRESS3 + "=@ADDRESS3");
            sb.AppendLine("  ," + DealingDTO.eColumns.TEL3 + "=@TEL3");
            sb.AppendLine("  ," + DealingDTO.eColumns.FAX3 + "=@FAX3");
            sb.AppendLine("  ," + DealingDTO.eColumns.EMAIL3 + "=@EMAIL3");
            sb.AppendLine("  ," + DealingDTO.eColumns.CONTACT_PERSON3 + "=@CONTACT_PERSON3");
            sb.AppendLine("  ," + DealingDTO.eColumns.REMARK3 + "=@REMARK3");
            sb.AppendLine("  ," + DealingDTO.eColumns.ALLOW_NEGATIVE + "=@ALLOW_NEGATIVE");
            sb.AppendLine("  ," + DealingDTO.eColumns.OLD_DATA + "=@OLD_DATA");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + DealingDTO.eColumns.LOC_CD + "=@oldLOC_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("@LOC_CD", DataType.NVarChar, data.LOC_CD.Value);
            req.Parameters.Add("@LOC_DESC", DataType.NVarChar, data.LOC_DESC.Value);
            req.Parameters.Add("@LOC_CLS", DataType.NVarChar, data.LOC_CLS.Value);
            req.Parameters.Add("@TERM_OF_PAYMENT", DataType.NVarChar, data.TERM_OF_PAYMENT.Value);
            req.Parameters.Add("@INVOICE_PATTERN", DataType.NVarChar, data.INVOICE_PATTERN.Value);
            req.Parameters.Add("@ADDRESS1", DataType.NVarChar, data.ADDRESS1.Value);
            req.Parameters.Add("@TEL1", DataType.NVarChar, data.TEL1.Value);
            req.Parameters.Add("@FAX1", DataType.NVarChar, data.FAX1.Value);
            req.Parameters.Add("@EMAIL1", DataType.NVarChar, data.EMAIL1.Value);
            req.Parameters.Add("@CONTACT_PERSON1", DataType.NVarChar, data.CONTACT_PERSON1.Value);
            req.Parameters.Add("@REMARK1", DataType.NVarChar, data.REMARK1.Value);
            req.Parameters.Add("@ADDRESS2", DataType.NVarChar, data.ADDRESS2.Value);
            req.Parameters.Add("@TEL2", DataType.NVarChar, data.TEL2.Value);
            req.Parameters.Add("@FAX2", DataType.NVarChar, data.FAX2.Value);
            req.Parameters.Add("@EMAIL2", DataType.NVarChar, data.EMAIL2.Value);
            req.Parameters.Add("@CONTACT_PERSON2", DataType.NVarChar, data.CONTACT_PERSON2.Value);
            req.Parameters.Add("@REMARK2", DataType.NVarChar, data.REMARK2.Value);
            req.Parameters.Add("@ADDRESS3", DataType.NVarChar, data.ADDRESS3.Value);
            req.Parameters.Add("@TEL3", DataType.NVarChar, data.TEL3.Value);
            req.Parameters.Add("@FAX3", DataType.NVarChar, data.FAX3.Value);
            req.Parameters.Add("@EMAIL3", DataType.NVarChar, data.EMAIL3.Value);
            req.Parameters.Add("@CONTACT_PERSON3", DataType.NVarChar, data.CONTACT_PERSON3.Value);
            req.Parameters.Add("@REMARK3", DataType.NVarChar, data.REMARK3.Value);
            req.Parameters.Add("@ALLOW_NEGATIVE", DataType.NVarChar, data.ALLOW_NEGATIVE.Value);
            req.Parameters.Add("@OLD_DATA", DataType.Default, data.OLD_DATA.Value);
            req.Parameters.Add("@oldLOC_CD", DataType.NVarChar, oldLOC_CD);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="LOC_CD">Key #1</param>
        /// <returns></returns>
        public int Delete(Database database, String LOC_CD) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(DealingDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + DealingDTO.eColumns.LOC_CD + "=@LOC_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@LOC_CD", DataType.NVarChar, LOC_CD);
            #endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, String LOC_CD) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(DealingDTO));

            sb.AppendLine(" SELECT TOP 1 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + DealingDTO.eColumns.LOC_CD + "=@LOC_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@LOC_CD", DataType.NVarChar, LOC_CD);
            #endregion

            return (db.ExecuteQuery(req).Rows.Count > 0);
        }

        public string ValidateBeforeDelete(Database database, NZString LOC_CD)
        {
            Database db = UseDatabase(database);
            DataRequest req = new DataRequest("S_MAS010_CheckBeforeDelete");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_LocationCode", DataType.VarChar,LOC_CD.Value);
            string sReturnCode = db.ExecuteScalar(req).ToString();
            return (NZString)sReturnCode;
        }


        #endregion

        #region Load Operation
        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <returns>List of DTO.</returns>
        public List<DealingDTO> LoadAll(Database database) {
            return LoadAll(database, true,
                DealingDTO.eColumns.LOC_CD
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<DealingDTO> LoadAll(Database database, bool ascending) {
            return LoadAll(database, ascending,
                DealingDTO.eColumns.LOC_CD
            );
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<DealingDTO> LoadAll(Database database, bool ascending, params DealingDTO.eColumns[] orderByColumns) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(DealingDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + DealingDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + DealingDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + DealingDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + DealingDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + DealingDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + DealingDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + DealingDTO.eColumns.LOC_CD);
            sb.AppendLine("  ," + DealingDTO.eColumns.LOC_DESC);
            sb.AppendLine("  ," + DealingDTO.eColumns.LOC_CLS);
            sb.AppendLine("  ," + DealingDTO.eColumns.TERM_OF_PAYMENT);
            sb.AppendLine("  ," + DealingDTO.eColumns.INVOICE_PATTERN);
            sb.AppendLine("  ," + DealingDTO.eColumns.ADDRESS1);
            sb.AppendLine("  ," + DealingDTO.eColumns.TEL1);
            sb.AppendLine("  ," + DealingDTO.eColumns.FAX1);
            sb.AppendLine("  ," + DealingDTO.eColumns.EMAIL1);
            sb.AppendLine("  ," + DealingDTO.eColumns.CONTACT_PERSON1);
            sb.AppendLine("  ," + DealingDTO.eColumns.REMARK1);
            sb.AppendLine("  ," + DealingDTO.eColumns.ADDRESS2);
            sb.AppendLine("  ," + DealingDTO.eColumns.TEL2);
            sb.AppendLine("  ," + DealingDTO.eColumns.FAX2);
            sb.AppendLine("  ," + DealingDTO.eColumns.EMAIL2);
            sb.AppendLine("  ," + DealingDTO.eColumns.CONTACT_PERSON2);
            sb.AppendLine("  ," + DealingDTO.eColumns.REMARK2);
            sb.AppendLine("  ," + DealingDTO.eColumns.ADDRESS3);
            sb.AppendLine("  ," + DealingDTO.eColumns.TEL3);
            sb.AppendLine("  ," + DealingDTO.eColumns.FAX3);
            sb.AppendLine("  ," + DealingDTO.eColumns.EMAIL3);
            sb.AppendLine("  ," + DealingDTO.eColumns.CONTACT_PERSON3);
            sb.AppendLine("  ," + DealingDTO.eColumns.REMARK3);
            sb.AppendLine("  ," + DealingDTO.eColumns.ALLOW_NEGATIVE);
            sb.AppendLine("  ," + DealingDTO.eColumns.OLD_DATA);
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

            return db.ExecuteForList<DealingDTO>(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="LOC_CD">Key #1</param>
        /// <returns></returns>
        public DealingDTO LoadByPK(Database database, String LOC_CD) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(DealingDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + DealingDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + DealingDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + DealingDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + DealingDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + DealingDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + DealingDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + DealingDTO.eColumns.LOC_CD);
            sb.AppendLine("  ," + DealingDTO.eColumns.LOC_DESC);
            sb.AppendLine("  ," + DealingDTO.eColumns.LOC_CLS);
            sb.AppendLine("  ," + DealingDTO.eColumns.TERM_OF_PAYMENT);
            sb.AppendLine("  ," + DealingDTO.eColumns.INVOICE_PATTERN);
            sb.AppendLine("  ," + DealingDTO.eColumns.ADDRESS1);
            sb.AppendLine("  ," + DealingDTO.eColumns.TEL1);
            sb.AppendLine("  ," + DealingDTO.eColumns.FAX1);
            sb.AppendLine("  ," + DealingDTO.eColumns.EMAIL1);
            sb.AppendLine("  ," + DealingDTO.eColumns.CONTACT_PERSON1);
            sb.AppendLine("  ," + DealingDTO.eColumns.REMARK1);
            sb.AppendLine("  ," + DealingDTO.eColumns.ADDRESS2);
            sb.AppendLine("  ," + DealingDTO.eColumns.TEL2);
            sb.AppendLine("  ," + DealingDTO.eColumns.FAX2);
            sb.AppendLine("  ," + DealingDTO.eColumns.EMAIL2);
            sb.AppendLine("  ," + DealingDTO.eColumns.CONTACT_PERSON2);
            sb.AppendLine("  ," + DealingDTO.eColumns.REMARK2);
            sb.AppendLine("  ," + DealingDTO.eColumns.ADDRESS3);
            sb.AppendLine("  ," + DealingDTO.eColumns.TEL3);
            sb.AppendLine("  ," + DealingDTO.eColumns.FAX3);
            sb.AppendLine("  ," + DealingDTO.eColumns.EMAIL3);
            sb.AppendLine("  ," + DealingDTO.eColumns.CONTACT_PERSON3);
            sb.AppendLine("  ," + DealingDTO.eColumns.REMARK3);
            sb.AppendLine("  ," + DealingDTO.eColumns.ALLOW_NEGATIVE);
            sb.AppendLine("  ," + DealingDTO.eColumns.OLD_DATA);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + DealingDTO.eColumns.LOC_CD + "=@LOC_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@LOC_CD", DataType.NVarChar, LOC_CD);
            #endregion

            List<DealingDTO> list = db.ExecuteForList<DealingDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        #endregion
    }
}

