/* Create by: Ms. Sansanee K.
 * Create on: 2012-03-20
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
    internal partial class BOMDAO
    {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public BOMDAO() { }

        public BOMDAO(Database db)
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
        public int AddNewOrUpdate(Database database, BOMDTO data)
        {
            Database db = UseDatabase(database);

            if (Exist(database, data.UPPER_ITEM_CD, data.LOWER_ITEM_CD, data.ITEM_SEQ))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, BOMDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            sb.AppendLine("  " + BOMDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + BOMDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + BOMDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + BOMDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + BOMDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + BOMDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + BOMDTO.eColumns.UPPER_ITEM_CD);
            sb.AppendLine("  ," + BOMDTO.eColumns.LOWER_ITEM_CD);
            sb.AppendLine("  ," + BOMDTO.eColumns.ITEM_SEQ);
            sb.AppendLine("  ," + BOMDTO.eColumns.UPPER_QTY);
            sb.AppendLine("  ," + BOMDTO.eColumns.LOWER_QTY);
            sb.AppendLine("  ," + BOMDTO.eColumns.OLD_DATA);
            sb.AppendLine(") VALUES(");
            sb.AppendLine("   @CRT_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,@CRT_MACHINE");
            sb.AppendLine("   ,@UPD_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,@UPD_MACHINE");
            sb.AppendLine("   ,@UPPER_ITEM_CD");
            sb.AppendLine("   ,@LOWER_ITEM_CD");
            sb.AppendLine("   ,@ITEM_SEQ");
            sb.AppendLine("   ,@UPPER_QTY");
            sb.AppendLine("   ,@LOWER_QTY");
            sb.AppendLine("   ,@OLD_DATA");
            sb.AppendLine(" )");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@CRT_BY", DataType.NVarChar, data.CRT_BY.Value);
            req.Parameters.Add("@CRT_MACHINE", DataType.NVarChar, data.CRT_MACHINE.Value);
            req.Parameters.Add("@UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("@UPPER_ITEM_CD", DataType.Default, data.UPPER_ITEM_CD.Value);
            req.Parameters.Add("@LOWER_ITEM_CD", DataType.Default, data.LOWER_ITEM_CD.Value);
            req.Parameters.Add("@ITEM_SEQ", DataType.Default, data.ITEM_SEQ.Value);
            req.Parameters.Add("@UPPER_QTY", DataType.Number, data.UPPER_QTY.Value);
            req.Parameters.Add("@LOWER_QTY", DataType.Number, data.LOWER_QTY.Value);
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
        public int UpdateWithoutPK(Database database, BOMDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + BOMDTO.eColumns.UPD_BY + "=@UPD_BY");
            sb.AppendLine("  ," + BOMDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + BOMDTO.eColumns.UPD_MACHINE + "=@UPD_MACHINE");
            sb.AppendLine("  ," + BOMDTO.eColumns.UPPER_QTY + "=@UPPER_QTY");
            sb.AppendLine("  ," + BOMDTO.eColumns.LOWER_QTY + "=@LOWER_QTY");
            sb.AppendLine("  ," + BOMDTO.eColumns.OLD_DATA + "=@OLD_DATA");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + BOMDTO.eColumns.UPPER_ITEM_CD + "=@UPPER_ITEM_CD");
            sb.AppendLine("  AND " + BOMDTO.eColumns.LOWER_ITEM_CD + "=@LOWER_ITEM_CD");
            sb.AppendLine("  AND " + BOMDTO.eColumns.ITEM_SEQ + "=@ITEM_SEQ");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("@UPPER_ITEM_CD", DataType.Default, data.UPPER_ITEM_CD.Value);
            req.Parameters.Add("@LOWER_ITEM_CD", DataType.Default, data.LOWER_ITEM_CD.Value);
            req.Parameters.Add("@ITEM_SEQ", DataType.Default, data.ITEM_SEQ.Value);
            req.Parameters.Add("@UPPER_QTY", DataType.Number, data.UPPER_QTY.Value);
            req.Parameters.Add("@LOWER_QTY", DataType.Number, data.LOWER_QTY.Value);
            req.Parameters.Add("@OLD_DATA", DataType.Default, data.OLD_DATA.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using the table's primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data which to update.</param>
        /// <param name="oldUPPER_ITEM_CD">Old Key #1</param>
        /// <param name="oldLOWER_ITEM_CD">Old Key #2</param>
        /// <param name="oldITEM_SEQ">Old Key #3</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, BOMDTO data, NZString oldUPPER_ITEM_CD, NZString oldLOWER_ITEM_CD, NZInt oldITEM_SEQ)
        {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + BOMDTO.eColumns.UPD_BY + "=@UPD_BY");
            sb.AppendLine("  ," + BOMDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + BOMDTO.eColumns.UPD_MACHINE + "=@UPD_MACHINE");
            sb.AppendLine("  ," + BOMDTO.eColumns.UPPER_ITEM_CD + "=@UPPER_ITEM_CD");
            sb.AppendLine("  ," + BOMDTO.eColumns.LOWER_ITEM_CD + "=@LOWER_ITEM_CD");
            sb.AppendLine("  ," + BOMDTO.eColumns.ITEM_SEQ + "=@ITEM_SEQ");
            sb.AppendLine("  ," + BOMDTO.eColumns.UPPER_QTY + "=@UPPER_QTY");
            sb.AppendLine("  ," + BOMDTO.eColumns.LOWER_QTY + "=@LOWER_QTY");
            sb.AppendLine("  ," + BOMDTO.eColumns.OLD_DATA + "=@OLD_DATA");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + BOMDTO.eColumns.UPPER_ITEM_CD + "=@oldUPPER_ITEM_CD");
            sb.AppendLine("  AND " + BOMDTO.eColumns.LOWER_ITEM_CD + "=@oldBOM");
            sb.AppendLine("  AND " + BOMDTO.eColumns.ITEM_SEQ + "=@oldBOM");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("@UPPER_ITEM_CD", DataType.Default, data.UPPER_ITEM_CD.Value);
            req.Parameters.Add("@LOWER_ITEM_CD", DataType.Default, data.LOWER_ITEM_CD.Value);
            req.Parameters.Add("@ITEM_SEQ", DataType.Default, data.ITEM_SEQ.Value);
            req.Parameters.Add("@UPPER_QTY", DataType.Number, data.UPPER_QTY.Value);
            req.Parameters.Add("@LOWER_QTY", DataType.Number, data.LOWER_QTY.Value);
            req.Parameters.Add("@OLD_DATA", DataType.Default, data.OLD_DATA.Value);
            req.Parameters.Add("@oldUPPER_ITEM_CD", DataType.Default, oldUPPER_ITEM_CD);
            req.Parameters.Add("@oldLOWER_ITEM_CD", DataType.Default, oldLOWER_ITEM_CD);
            req.Parameters.Add("@oldITEM_SEQ", DataType.Default, oldITEM_SEQ);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="UPPER_ITEM_CD">Key #1</param>
        /// <param name="LOWER_ITEM_CD">Key #2</param>
        /// <param name="ITEM_SEQ">Key #3</param>
        /// <returns></returns>
        public int Delete(Database database, NZString UPPER_ITEM_CD, NZString LOWER_ITEM_CD, NZInt ITEM_SEQ)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(BOMDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + BOMDTO.eColumns.UPPER_ITEM_CD + "=@UPPER_ITEM_CD");
            sb.AppendLine("  AND " + BOMDTO.eColumns.LOWER_ITEM_CD + "=@LOWER_ITEM_CD");
            sb.AppendLine("  AND " + BOMDTO.eColumns.ITEM_SEQ + "=@ITEM_SEQ");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@UPPER_ITEM_CD", DataType.Default, UPPER_ITEM_CD.Value);
            req.Parameters.Add("@LOWER_ITEM_CD", DataType.Default, LOWER_ITEM_CD.Value);
            req.Parameters.Add("@ITEM_SEQ", DataType.Default, ITEM_SEQ.Value);
            #endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, NZString UPPER_ITEM_CD, NZString LOWER_ITEM_CD, NZInt ITEM_SEQ)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(BOMDTO));

            sb.AppendLine(" SELECT TOP 1 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + BOMDTO.eColumns.UPPER_ITEM_CD + "=@UPPER_ITEM_CD");
            sb.AppendLine("  AND " + BOMDTO.eColumns.LOWER_ITEM_CD + "=@LOWER_ITEM_CD");
            sb.AppendLine("  AND " + BOMDTO.eColumns.ITEM_SEQ + "=@ITEM_SEQ");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@UPPER_ITEM_CD", DataType.Default, UPPER_ITEM_CD.Value);
            req.Parameters.Add("@LOWER_ITEM_CD", DataType.Default, LOWER_ITEM_CD.Value);
            req.Parameters.Add("@ITEM_SEQ", DataType.Default, ITEM_SEQ.Value);
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
        public List<BOMDTO> LoadAll(Database database)
        {
            return LoadAll(database, true,
                BOMDTO.eColumns.UPPER_ITEM_CD
                , BOMDTO.eColumns.LOWER_ITEM_CD
                , BOMDTO.eColumns.ITEM_SEQ
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<BOMDTO> LoadAll(Database database, bool ascending)
        {
            return LoadAll(database, ascending,
                BOMDTO.eColumns.UPPER_ITEM_CD
                , BOMDTO.eColumns.LOWER_ITEM_CD
                , BOMDTO.eColumns.ITEM_SEQ
            );
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<BOMDTO> LoadAll(Database database, bool ascending, params BOMDTO.eColumns[] orderByColumns)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(BOMDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + BOMDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + BOMDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + BOMDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + BOMDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + BOMDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + BOMDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + BOMDTO.eColumns.UPPER_ITEM_CD);
            sb.AppendLine("  ," + BOMDTO.eColumns.LOWER_ITEM_CD);
            sb.AppendLine("  ," + BOMDTO.eColumns.ITEM_SEQ);
            sb.AppendLine("  ," + BOMDTO.eColumns.UPPER_QTY);
            sb.AppendLine("  ," + BOMDTO.eColumns.LOWER_QTY);
            sb.AppendLine("  ," + BOMDTO.eColumns.OLD_DATA);
            sb.AppendLine("  ," + BOMDTO.eColumns.TIME_STAMP);
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

            return db.ExecuteForList<BOMDTO>(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="UPPER_ITEM_CD">Key #1</param>
        /// <param name="LOWER_ITEM_CD">Key #2</param>
        /// <param name="ITEM_SEQ">Key #3</param>
        /// <returns></returns>
        public BOMDTO LoadByPK(Database database, NZString UPPER_ITEM_CD, NZString LOWER_ITEM_CD, NZInt ITEM_SEQ)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(BOMDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + BOMDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + BOMDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + BOMDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + BOMDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + BOMDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + BOMDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + BOMDTO.eColumns.UPPER_ITEM_CD);
            sb.AppendLine("  ," + BOMDTO.eColumns.LOWER_ITEM_CD);
            sb.AppendLine("  ," + BOMDTO.eColumns.ITEM_SEQ);
            sb.AppendLine("  ," + BOMDTO.eColumns.UPPER_QTY);
            sb.AppendLine("  ," + BOMDTO.eColumns.LOWER_QTY);
            sb.AppendLine("  ," + BOMDTO.eColumns.OLD_DATA);
            sb.AppendLine("  ," + BOMDTO.eColumns.TIME_STAMP);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + BOMDTO.eColumns.UPPER_ITEM_CD + "=@UPPER_ITEM_CD");
            sb.AppendLine("  AND " + BOMDTO.eColumns.LOWER_ITEM_CD + "=@LOWER_ITEM_CD");
            sb.AppendLine("  AND " + BOMDTO.eColumns.ITEM_SEQ + "=@ITEM_SEQ");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@UPPER_ITEM_CD", DataType.Default, UPPER_ITEM_CD);
            req.Parameters.Add("@LOWER_ITEM_CD", DataType.Default, LOWER_ITEM_CD);
            req.Parameters.Add("@ITEM_SEQ", DataType.Default, ITEM_SEQ);
            #endregion

            List<BOMDTO> list = db.ExecuteForList<BOMDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        #endregion
    }
}

