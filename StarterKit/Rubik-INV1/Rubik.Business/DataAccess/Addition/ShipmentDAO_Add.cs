using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EVOFramework;
using EVOFramework.Database;
using Rubik.DTO;

namespace Rubik.DAO
{
    partial class ShipmentDAO_Add : BaseDAO
    {
        public void UpdateCustomerOrderStatus(Database database, NZString OrderDetailNo, decimal QTY)
        {
            Database db = UseDatabase(database);

            DataRequest req = new DataRequest("S_TRN100_UpdateCustomerOrderStatus");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_OrderDetailNo", DataType.NVarChar, CheckNull(OrderDetailNo.StrongValue));
            req.Parameters.Add("@pNum_DiffQty", DataType.Decimal, CheckNull(QTY));
            db.ExecuteNonQuery(req);
        }
    }
}
