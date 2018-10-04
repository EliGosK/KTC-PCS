/* Create by: Ms. Sansanee K.
 * Create on: 2011-06-28
 * Company: CSI Groups (Thailand)
 * Group: SI-EVO
 
 *** This generate source code was build for DAO on StarterKit system. ***/
using System;
using System.Collections.Generic;
using System.Text;
using EVOFramework.Database;
using EVOFramework;
using Rubik.DTO;
using System.Data;
using CommonLib;


namespace Rubik.DAO {
    public partial class TmpPurchaseOrderDAO {

        public void GeneratePO(Database database, NZDateTime dtmFrom, NZDateTime dtmTo, NZString strItemCDFrom, NZString strItemCDTo, 
            NZString strLocCDFrom, NZString strLocCDTo, NZString strUser, NZString strMachine, NZInt iPOInterval) {

            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_MRP022_GenerateTmpPO";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pDtm_DATE_FROM", DataType.DateTime, dtmFrom.IsNull ? (object)DBNull.Value : dtmFrom.Value);
            req.Parameters.Add("@pDtm_DATE_TO", DataType.DateTime, dtmTo.IsNull ? (object)DBNull.Value : dtmTo.Value);
            req.Parameters.Add("@pVar_ITEM_CD_FROM", DataType.NVarChar, strItemCDFrom.IsNull ? (object)DBNull.Value : strItemCDFrom.Value);
            req.Parameters.Add("@pVar_ITEM_CD_TO", DataType.NVarChar, strItemCDTo.IsNull ? (object)DBNull.Value : strItemCDTo.Value);
            req.Parameters.Add("@pVar_LOC_CD_FROM", DataType.NVarChar, strLocCDFrom.IsNull ? (object)DBNull.Value : strLocCDFrom.Value);
            req.Parameters.Add("@pVar_LOC_CD_TO", DataType.NVarChar, strLocCDTo.IsNull ? (object)DBNull.Value : strLocCDTo.Value);
            req.Parameters.Add("@pInt_PO_INTERVAL", DataType.Int32, iPOInterval.IsNull || "".Equals(iPOInterval.Value) ? (object)DBNull.Value : iPOInterval.Value);
            req.Parameters.Add("@pVar_USER_CD", DataType.NVarChar, strUser.Value);
            req.Parameters.Add("@pVar_MACHINE", DataType.NVarChar, strMachine.Value);
            db.ExecuteNonQuery(req);
        }

        public DataTable LoadTmpGeneratePO(Database database, NZString strUser, NZString strMachine) {

            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_MRP022_LoadGeneratePO";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_CRT_BY", DataType.NVarChar, strUser.Value);
            req.Parameters.Add("@pVar_CRT_MACHINE", DataType.NVarChar, strMachine.Value);

            return db.ExecuteQuery(req);
        }
        
    }
}

