/* Create by: Mr.Teerayut Sinlan
 * Create on: 2553-08-10
 * Company: CSI Groups (Thailand)
 * Group: SI-EVO
 
 *** This generate source code was build for DAO on StarterKit system. ***/
using System;
using System.Collections.Generic;
using System.Text;
using Rubik.DTO;
using EVOFramework.Database;
using EVOFramework;

namespace Rubik.DAO
{
    internal partial class InvTranLogDAO
    {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public InvTranLogDAO() { }

        public InvTranLogDAO(Database db)
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
    

    
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InvTranLogDTO));

            sb.AppendLine(" SELECT TOP 1 1 ");
            sb.AppendLine(" FROM " + tableName);
            #endregion

            DataRequest req = new DataRequest(sb.ToString());

            return (db.ExecuteQuery(req).Rows.Count > 0);
        }
        #endregion

        #region Load Operation

        #endregion

       
    }
}

