/* Create by: Ms. Sansanee K.
 * Create on: 2011-06-02
 * Company: CSI Groups (Thailand)
 * Group: SI-EVO
 
 *** This generate source code was build for DAO on StarterKit system. ***/
using System;
using System.Collections.Generic;
using System.Text;
using EVOFramework.Database;
using EVOFramework;
using Rubik.DTO;
using Rubik.Data;
using System.Data;


namespace Rubik.DAO {

    internal partial class PurchaseOrderHDAO {

        #region Load data

        public DataTable LoadPurchaseOrderDByPONo(Database database, DateTime dtmPO_DATE_FROM, DateTime dtmPO_DATE_TO) {

            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_MRP030_LoadPurchaseOrderByPODate";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pDtm_PO_DATE_FROM", DataType.DateTime, dtmPO_DATE_FROM);
            req.Parameters.Add("@pDtm_PO_DATE_TO", DataType.DateTime, dtmPO_DATE_TO);

            return db.ExecuteQuery(req);
        }

        // edit by Chatas C. 17 June 2011
        public DataTable LoadAllPurchaseOrderDByPONo(Database database, DateTime dtmPO_DATE_FROM, DateTime dtmPO_DATE_TO)
        {

            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_MRP030_LoadAllPurchaseOrderByPODate";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pDtm_PO_DATE_FROM", DataType.DateTime, dtmPO_DATE_FROM);
            req.Parameters.Add("@pDtm_PO_DATE_TO", DataType.DateTime, dtmPO_DATE_TO);

            return db.ExecuteQuery(req);
        }

        public void GeneratePO(Database database, NZDateTime dtmFrom, NZDateTime dtmTo, NZString strItemCDFrom, NZString strItemCDTo, NZString strLocCDFrom, NZString strLocCDTo,NZString strUser,NZString strMachine) {

            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_MRP022_GeneratePO";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pDtm_DATE_FROM", DataType.DateTime, dtmFrom.IsNull ? (object)DBNull.Value : dtmFrom.Value);
            req.Parameters.Add("@pDtm_DATE_TO", DataType.DateTime, dtmTo.IsNull ? (object)DBNull.Value : dtmTo.Value);
            req.Parameters.Add("@pVar_ITEM_CD_FROM", DataType.NVarChar, strItemCDFrom.IsNull ? (object)DBNull.Value : strItemCDFrom.Value);
            req.Parameters.Add("@pVar_ITEM_CD_TO", DataType.NVarChar, strItemCDTo.IsNull ? (object)DBNull.Value : strItemCDTo.Value);
            req.Parameters.Add("@pVar_LOC_CD_FROM", DataType.NVarChar, strLocCDFrom.IsNull ? (object)DBNull.Value : strLocCDFrom.Value);
            req.Parameters.Add("@pVar_LOC_CD_TO", DataType.NVarChar, strLocCDTo.IsNull ? (object)DBNull.Value : strLocCDTo.Value);
            req.Parameters.Add("@pVar_USER_CD", DataType.NVarChar, strUser.Value);
            req.Parameters.Add("@pVar_MACHINE", DataType.NVarChar, strMachine.Value);
            db.ExecuteNonQuery(req);
        }

        public DataTable LoadGeneratePO(Database database, NZString strUser, NZString strMachine) 
        {
            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_MRP022_LoadGeneratePO";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_CRT_BY", DataType.NVarChar, strUser.Value);
            req.Parameters.Add("@pVar_CRT_MACHINE", DataType.NVarChar, strMachine.Value);

            return db.ExecuteQuery(req);
        }

        #endregion

        #region Operation

        public int DeletePurchaseOrderH(Database database, PurchaseOrderHDTO dto) {

            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_MRP040_DeletePurchaseOrderH";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_PO_NO", DataType.VarChar, dto.PO_NO.Value);
            req.Parameters.Add("@pVar_UPD_BY", DataType.VarChar, dto.UPD_BY.Value);
            req.Parameters.Add("@pVar_UPD_MACHINE", DataType.VarChar, dto.UPD_MACHINE.Value);            

            return db.ExecuteNonQuery(req);
        }

        public int UpdateBalance(Database database, PurchaseOrderHDTO dtoH, PurchaseOrderDDTO dtoD, decimal dChangeQty)
        {
            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_PURP010_FIFOBalancePOProcess";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@P_RECEIVING_ID", DBNull.Value);
            req.Parameters.Add("@P_RECEIVING_DATE", DataType.DateTime, dtoD.DUE_DATE.Value);
            req.Parameters.Add("@P_ITEM_CD", DataType.NVarChar, dtoD.ITEM_CD.Value);
            req.Parameters.Add("@P_SUPPLIER_CD", DataType.NVarChar, dtoH.SUPPLIER_CD.Value);
            req.Parameters.Add("@P_CHGQTY", DataType.Decimal, dChangeQty);

            return db.ExecuteNonQuery(req);
        }

        #endregion


        internal int Cancel(Database database ,PurchaseOrderHDTO dtoH)
        {
            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_MRP040_CancelPO";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@P_PO_NO", DataType.NVarChar, dtoH.PO_NO.Value);

            return db.ExecuteNonQuery(req);
        }
    }
}

