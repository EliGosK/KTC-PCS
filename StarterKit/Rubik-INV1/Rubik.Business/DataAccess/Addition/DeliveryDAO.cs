#define Edit_By_Chatas_C
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using EVOFramework.Database;
using Rubik.DTO;
using System.Data;

namespace Rubik.DAO
{
    partial class DeliveryDAO : BaseDAO
    {

        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public DeliveryDAO(Database db)
        {
            this.m_db = db;
        }
        #endregion

        #region Function Load

        public List<DeliveryViewDTO> Load_OrderMaintenance(NZDateTime DateBegin
                                                            , NZDateTime DateEnd
                                                            , NZString CustomerCd
                                                            , NZString Currency
                                                            , NZString SlipNo
                                                            , bool IncludeOldData)
        {
            Database db = m_db;

            DataRequest req = new DataRequest("S_TRN120_OrderMaintenance_Load");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@PERIOD_BEGIN_DATE", DataType.DateTime, CheckNull(DateBegin.StrongValue.Date));
            req.Parameters.Add("@PERIOD_END_DATE", DataType.DateTime, CheckNull(DateEnd.StrongValue.Date));
            req.Parameters.Add("@CUSTOMER_CD", DataType.NVarChar, CheckNull(CustomerCd.StrongValue));
            req.Parameters.Add("@CURRENCY", DataType.NVarChar, CheckNull(Currency.StrongValue));
            if (!SlipNo.IsNull)
                req.Parameters.Add("@SLIP_NO", DataType.NVarChar, CheckNull(SlipNo.StrongValue)); ;    //not include old value
            if (!IncludeOldData)
                req.Parameters.Add("@OLD_DATA", DataType.Int16, 0);    //not include old value  

            return db.ExecuteForList<DeliveryViewDTO>(req);
        }

        public DataTable Load_DeliveryList(NZDateTime DateBegin, NZDateTime DateEnd, bool IncludeOldData)
        {
            Database db = m_db;

            DataRequest req = new DataRequest("S_TRN090_DeliveryList_Load");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pDtmDateFrom", DataType.DateTime, CheckNull(DateBegin.StrongValue.Date));
            req.Parameters.Add("@pDtmDateTo", DataType.DateTime, CheckNull(DateEnd.StrongValue.Date));
            req.Parameters.Add("@ITEMCD", DataType.Default, DBNull.Value);
            req.Parameters.Add("@SHORT_NAME", DataType.NVarChar, DBNull.Value);
            if (!IncludeOldData)
                req.Parameters.Add("@OLD_DATA", DataType.Int16, 0);    //not include old value  

            return db.ExecuteQuery(req);
        }

        public DataTable Load_DeliveryOrderListForReturn(NZDateTime DateBegin, NZDateTime DateEnd, NZString ItemCd, NZString ShortName, NZString CustomerCd, NZString Return_Slip_No, bool IncludeOldData)
        {
            Database db = m_db;

            DataRequest req = new DataRequest("S_TRN090_DeliveryList_Load");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pDtmDateFrom", DataType.DateTime, CheckNull(DateBegin.StrongValue.Date));
            req.Parameters.Add("@pDtmDateTo", DataType.DateTime, CheckNull(DateEnd.StrongValue.Date));
            req.Parameters.Add("@ITEMCD", DataType.Default, CheckNull(ItemCd.Value));
            req.Parameters.Add("@SHORT_NAME", DataType.NVarChar, CheckNull(ShortName.Value));
            req.Parameters.Add("@CUSTOMER_CD", DataType.NVarChar, CheckNull(CustomerCd.Value));
            req.Parameters.Add("@RETURN_SLIP_NO", DataType.NVarChar, CheckNull(Return_Slip_No.Value));
            if (!IncludeOldData)
                req.Parameters.Add("@OLD_DATA", DataType.Int16, 0);    //not include old value  

            return db.ExecuteQuery(req);
        }

        public DataTable Load_OrderList(NZString SlipNo, bool IncludeOldData)
        {
            Database db = m_db;

            DataRequest req = new DataRequest("S_TRN100_DeliveryEntry_Order_Load");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@SLIP_NO", DataType.NVarChar, CheckNull(SlipNo.Value));
            if (!IncludeOldData)
                req.Parameters.Add("@OLD_DATA", DataType.Int16, 0);    //not include old value  

            return db.ExecuteQuery(req);
        }

        public DataTable Load_LotList(NZString SlipNo, bool IncludeOldData)
        {
            Database db = m_db;

            DataRequest req = new DataRequest("S_TRN100_DeliveryEntry_Lot_Load");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@SLIP_NO", DataType.NVarChar, CheckNull(SlipNo.Value));
            if (!IncludeOldData)
                req.Parameters.Add("@OLD_DATA", DataType.Int16, 0);    //not include old value  

            return db.ExecuteQuery(req);
        }

        public DataTable Load_Invoice(NZString SlipNo, bool IncludeOldData)
        {
            Database db = m_db;

            DataRequest req = new DataRequest("S_TRN090_DeliveryList_Invoice_Load");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@SLIP_NO", DataType.NVarChar, CheckNull(SlipNo.Value));
            if (!IncludeOldData)
                req.Parameters.Add("@OLD_DATA", DataType.Int16, 0);    //not include old value  

            return db.ExecuteQuery(req);
        }

        public List<ActualOnhandViewDTO> Load_LotMaintenance(NZString SlipNo, NZString LocCd, NZString ItemCd, bool IncludeOldData)
        {
            Database db = m_db;

            DataRequest req = new DataRequest("S_TRN101_LotMaintenance_Load");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@SLIP_NO", DataType.NVarChar, CheckNull(SlipNo.Value));
            req.Parameters.Add("@LOC_CD", DataType.NVarChar, CheckNull(LocCd.Value));
            req.Parameters.Add("@ITEM_CD", DataType.NVarChar, CheckNull(ItemCd.Value));
            if (!IncludeOldData)
                req.Parameters.Add("@OLD_DATA", DataType.Int16, 0);    //not include old value  

            return db.ExecuteForList<ActualOnhandViewDTO>(req);
        }

        public int UpdateReceiveHeader(Database database,InventoryTransactionDTO data)
        {
            Database db = database;

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            //sb.AppendLine("  " + InventoryTransactionDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.LOC_CD + "=:LOC_CD");
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.LOT_NO + "=:LOT_NO");
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRANS_DATE + "=:TRANS_DATE");
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRANS_CLS + "=:TRANS_CLS");
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.IN_OUT_CLS + "=:IN_OUT_CLS");
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.QTY + "=:QTY");
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OBJ_ITEM_CD + "=:OBJ_ITEM_CD");
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OBJ_ORDER_QTY + "=:OBJ_ORDER_QTY");
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_NO + "=:REF_NO");
            sb.AppendLine("  " + InventoryTransactionDTO.eColumns.REMARK + "=:REMARK");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.EXTERNAL_LOT_NO + "=:EXTERNAL_LOT_NO");
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.PRICE + "=:PRICE");
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.FOR_CUSTOMER + "=:FOR_CUSTOMER");
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.FOR_MACHINE + "=:FOR_MACHINE");
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.SHIFT_CLS + "=:SHIFT_CLS");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_SLIP_NO2 + "=:REF_SLIP_NO2");
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.NG_QTY + "=:NG_QTY");
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRAN_SUB_CLS + "=:TRAN_SUB_CLS");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + InventoryTransactionDTO.eColumns.SLIP_NO + "=:SLIP_NO");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("SLIP_NO", DataType.NVarChar, data.SLIP_NO.Value);
            //req.Parameters.Add("ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            //req.Parameters.Add("LOC_CD", DataType.NVarChar, data.LOC_CD.Value);
            //req.Parameters.Add("LOT_NO", DataType.NVarChar, data.LOT_NO.Value);
            //req.Parameters.Add("TRANS_DATE", DataType.DateTime, data.TRANS_DATE.Value);
            //req.Parameters.Add("TRANS_CLS", DataType.NVarChar, data.TRANS_CLS.Value);
            //req.Parameters.Add("IN_OUT_CLS", DataType.NVarChar, data.IN_OUT_CLS.Value);
            //req.Parameters.Add("QTY", DataType.Number, data.QTY.Value);
            //req.Parameters.Add("OBJ_ITEM_CD", DataType.NVarChar, data.OBJ_ITEM_CD.Value);
            //req.Parameters.Add("OBJ_ORDER_QTY", DataType.Number, data.OBJ_ORDER_QTY.Value);
            //req.Parameters.Add("REF_NO", DataType.NVarChar, data.REF_NO.Value);
            req.Parameters.Add("REMARK", DataType.NVarChar, data.REMARK.Value);
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            //req.Parameters.Add("EXTERNAL_LOT_NO", DataType.NVarChar, data.EXTERNAL_LOT_NO.Value);
            //req.Parameters.Add("PRICE", DataType.Number, data.PRICE.Value);
            //req.Parameters.Add("FOR_CUSTOMER", DataType.NVarChar, data.FOR_CUSTOMER.Value);
            //req.Parameters.Add("FOR_MACHINE", DataType.NVarChar, data.FOR_MACHINE.Value);
            //req.Parameters.Add("SHIFT_CLS", DataType.NVarChar, data.SHIFT_CLS.Value);
            req.Parameters.Add("REF_SLIP_NO2", DataType.NVarChar, data.REF_SLIP_NO2.Value);
            //req.Parameters.Add("NG_QTY", DataType.Number, data.NG_QTY.Value);
            //req.Parameters.Add("TRAN_SUB_CLS", DataType.NVarChar, data.TRAN_SUB_CLS.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        #endregion
    }
}
