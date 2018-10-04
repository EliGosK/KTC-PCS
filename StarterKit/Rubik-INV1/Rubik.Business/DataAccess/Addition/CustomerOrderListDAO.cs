using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Database;
using System.Data;
using EVOFramework;
using Rubik.DTO;

namespace Rubik.DAO
{
    public class CustomerOrderListDAO : BaseDAO
    {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public CustomerOrderListDAO(Database db)
        {
            this.m_db = db;
        }
        #endregion

        #region Load Data

        public DataTable LoadCustomerOrderList(NZDateTime DateBegin, NZDateTime DateEnd, NZInt filterType, bool IncludeOldData)
        {
            DataTable dt = null;

            Database db = m_db;

            DataRequest req = new DataRequest("S_TRN180_LoadCustomerOrderList");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@PERIOD_BEGIN_DATE", DataType.DateTime, CheckNull(DateBegin.StrongValue.Date));
            req.Parameters.Add("@PERIOD_END_DATE", DataType.DateTime, CheckNull(DateEnd.StrongValue.Date));
            req.Parameters.Add("@FILTER_TYPE", DataType.Int32, filterType.StrongValue);
            if (!IncludeOldData)
                req.Parameters.Add("@OLD_DATA", DataType.Int16, 0);    //not include old value  

            DataSet ds = db.ExecuteDataSet(req);

            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }

            return dt;
        }

        public DataTable LoadCustomerOrderEntry(NZString CustomerCd, NZString orderNo, bool IncludeOldData)
        {
            DataTable dt = null;

            Database db = m_db;

            DataRequest req = new DataRequest("S_TRN190_LoadCustomerOrderEntry");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@ORDER_NO", DataType.NVarChar, CheckNull(orderNo.Value));
            req.Parameters.Add("@CUSTOMER_CD", DataType.NVarChar, CheckNull(CustomerCd.Value));
            if (!IncludeOldData)
                req.Parameters.Add("@OLD_DATA", DataType.Int16, 0);    //not include old value  

            DataSet ds = db.ExecuteDataSet(req);

            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }

            return dt;
        }

        public int AddNewH(Database database, CustomerOrderHDTO data)
        {
            Database db = UseDatabase(database);
            CustomerOrderHDAO daoCustomerOrderH = new CustomerOrderHDAO();
            return daoCustomerOrderH.AddNew(database, data);
        }

        public int AddNewD(Database database, CustomerOrderDDTO data)
        {
            Database db = UseDatabase(database);
            CustomerOrderDDAO daoCustomerOrderD = new CustomerOrderDDAO();
            return daoCustomerOrderD.AddNew(database, data);
        }

        #endregion
    }
}
