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
    internal partial class TmpDemandOrderDAO {

        #region Operation

        public int InsertTempDemandOrder(Database database, TmpDemandOrderDTO dto) {

            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_MRP020_InsertTmpDemandOrder";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_CRT_BY", DataType.NVarChar, dto.CRT_BY.Value);
            req.Parameters.Add("@pDtm_CRT_DATE", DataType.DateTime, dto.CRT_DATE.Value);
            req.Parameters.Add("@pVar_CRT_MACHINE", DataType.NVarChar, dto.CRT_MACHINE.Value);
            req.Parameters.Add("@pDtm_YEAR_MONTH", DataType.DateTime, dto.YEAR_MONTH.Value);
            req.Parameters.Add("@pVar_CUSTOMER_CD", DataType.NVarChar, dto.CUSTOMER_CD.Value);
            req.Parameters.Add("@pDtm_DUE_DATE", DataType.DateTime, dto.DUE_DATE.Value);
            req.Parameters.Add("@pVar_ITEM_CD", DataType.NVarChar, dto.ITEM_CD.Value);
            req.Parameters.Add("@pVar_ITEM_DESC", DataType.NVarChar, dto.ITEM_DESC.Value);
            req.Parameters.Add("@pNum_ORDER_QTY", DataType.Decimal, dto.ORDER_QTY.Value);
            req.Parameters.Add("@pVar_ORDER_TYPE", DataType.NVarChar, dto.ORDER_TYPE.Value);

            return db.ExecuteNonQuery(req);
        }

        public int DeleteTempDemandOrder(Database database, DemandOrderDTO dto) {

            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_MRP020_DeleteTmpDemandOrder";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_CRT_BY", DataType.NVarChar, dto.CRT_BY.Value);
            req.Parameters.Add("@pVar_CRT_MACHINE", DataType.NVarChar, dto.CRT_MACHINE.Value);
            req.Parameters.Add("@pDtm_YEAR_MONTH", DataType.DateTime, dto.YEAR_MONTH.Value);
            req.Parameters.Add("@pVar_CUSTOMER_CD", DataType.NVarChar, dto.CUSTOMER_CD.Value);    

            return db.ExecuteNonQuery(req);
        }

        #endregion

    }
}

