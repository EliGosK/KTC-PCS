using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Database;
using System.Data;
using EVOFramework;

namespace Rubik.DAO {
    public class MovePartDAO : BaseDAO
    {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public MovePartDAO(Database db)
        {
            this.m_db = db;
        }
        #endregion

        #region Load Data

        public DataTable LoadMovePartList(NZDateTime DateBegin, NZDateTime DateEnd, bool IncludeOldData) 
        {
            DataTable dt = null;

            Database db = m_db;

            DataRequest req = new DataRequest("S_TRN290_LoadMovePartList");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pDtm_DateBegin", DataType.DateTime, CheckNull(DateBegin.Value));
            req.Parameters.Add("@pDtm_DateEnd", DataType.DateTime, CheckNull(DateEnd.Value));
            if (!IncludeOldData)
                req.Parameters.Add("@pInt_OldData", DataType.Int16, 0);    //not include old value   
            
            DataSet ds = db.ExecuteDataSet(req);

            if (ds != null && ds.Tables.Count > 0) {
                dt = ds.Tables[0];
            }

            return dt;
        }

        #endregion
    }
}
