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
using CommonLib;


namespace Rubik.DAO {

    internal partial class PurchaseOrderDDAO {

        #region Load Data
        
        public List<PurchaseOrderDDTO> LoadPurchaseOrderDByPONo(Database database, PurchaseOrderHDTO dto) {

            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_MRP040_LoadPurchaseOrderDByPO";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_PO_NO", DataType.VarChar, dto.PO_NO.Value);

            List<PurchaseOrderDDTO> list = db.ExecuteForList<PurchaseOrderDDTO>(req);

            return list;
        }

        public DataTable LoadReceivePurchaseOrderD(Database database, PurchaseOrderHDTO dto) {

            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_MRP040_LoadReceiveItem";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_PO_NO", DataType.VarChar, dto.PO_NO.Value);

            return db.ExecuteQuery(req);
        }

        #endregion

        #region Operation

        public int DeleteByPO(Database database, PurchaseOrderHDTO dto) {
            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_MRP040_DeletePurchaseOrderDByPONo";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_PO_NO", DataType.NVarChar, dto.PO_NO.Value);

            return db.ExecuteNonQuery(req);
        }

        public int DeleteDTO(Database database, PurchaseOrderDDTO dto)
        {
            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_MRP040_DeletePurchaseOrderDByPOLine";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_PO_NO", DataType.NVarChar, dto.PO_NO.Value);
            req.Parameters.Add("@pVar_PO_LINE", DataType.Decimal, dto.PO_LINE.Value);

            return db.ExecuteNonQuery(req);
        }

        public decimal DeleteWithReturnReceiveQTY(Database database, PurchaseOrderDDTO dto)
        {
            Database db = UseDatabase(database);
            DataRequest req = new DataRequest();
            req.CommandText = "S_MRP040_DeletePurchaseOrderDByPOLine";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_PO_NO", DataType.NVarChar, dto.PO_NO.Value);
            req.Parameters.Add("@pVar_PO_LINE", DataType.Decimal, dto.PO_LINE.Value);
            object obj = db.ExecuteScalar(req);
            if (obj == DBNull.Value || obj == null)
                return 0;
            else
                return Convert.ToDecimal(obj);

        }

        public bool IsExistPOLine(Database database, NZString strPO_NO)
        {
            Database db = UseDatabase(database);
            DataRequest req = new DataRequest();
            req.CommandText = "S_PUR010_IS_EXIST_PO_LINE";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@P_PO_NO", DataType.NVarChar, strPO_NO.Value);

            return db.ExecuteQuery(req).Rows.Count > 0;
        }
        #endregion
    }
}

