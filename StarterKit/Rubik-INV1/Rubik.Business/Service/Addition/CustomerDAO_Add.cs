/* Create by: Ms. Sansanee K.
 * Create on: 2011-05-27
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
using System.Data;

namespace Rubik.DAO {
    internal partial class CustomerDAO {

        #region LoadData

        public DataTable LoadCustomerAll(Database database) {

            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_COMMON_LoadCustomer";
            req.CommandType = CommandType.StoredProcedure;

            return db.ExecuteQuery(req);
        }

        #endregion

    }
}

