using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EVOFramework.Database;

namespace Rubik.DAO
{
    public class SearchDialogDAO
    {
        #region Variables

        private readonly Database m_db;

        #endregion

        #region Constructor

        public SearchDialogDAO() { }

        public SearchDialogDAO(Database db)
        {
            this.m_db = db;
        }

        #endregion

        public DataTable searchData(string argStoredProcedure, ParameterCollection argParameters)
        {
            DataTable ret = null;

            Database db = m_db;

            DataRequest req = new DataRequest();
            req.CommandText = argStoredProcedure;
            req.CommandType = CommandType.StoredProcedure;
            if (argParameters != null)
            {
                req.Parameters = argParameters;
            }

            DataSet ds = m_db.ExecuteDataSet(req);
            if (ds != null && ds.Tables.Count > 0)
            {
                ret = ds.Tables[0];
            }

            return ret;
        }
    }
}
