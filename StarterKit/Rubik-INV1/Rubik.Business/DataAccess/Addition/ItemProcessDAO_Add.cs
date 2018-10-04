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
    public partial class ItemProcessDAO
    {
        public ItemProcessDTO LoadByItemCD(Database database, NZString ItemCD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ItemProcessDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + ItemProcessDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.ITEM_SEQ);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.PROCESS_CD);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.WEIGHT);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.PRODUCTION_LEADTIME);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.QTY_PER_DAY);
            sb.AppendLine("  ," + ItemProcessDTO.eColumns.SUPPLIER_CD);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ItemProcessDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            //sb.AppendLine("  AND " + ItemProcessDTO.eColumns.ORDER_PROCESS_CLS + "=:ORDER_PROCESS_CLS");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, ItemCD.Value);
            //req.Parameters.Add("ORDER_PROCESS_CLS", DataType.NVarChar, ORDER_PROCESS_CLS.Value);
            #endregion

            List<ItemProcessDTO> list = db.ExecuteForList<ItemProcessDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }

        public List<ItemViewProcessDTO> LoadProcessListByItemCD(Database database, NZString ItemCD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ItemProcessDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  IT." + ItemViewProcessDTO.eColumns.ITEM_SEQ);
            sb.AppendLine("  ,IT." + ItemViewProcessDTO.eColumns.PROCESS_CD);
            sb.AppendLine("  ,PR.LOC_DESC as " + ItemViewProcessDTO.eColumns.PROCESS_NAME);
            sb.AppendLine("  ,IT." + ItemViewProcessDTO.eColumns.WEIGHT);
            sb.AppendLine("  ,IT." + ItemViewProcessDTO.eColumns.PRODUCTION_LEADTIME);
            sb.AppendLine("  ,IT." + ItemViewProcessDTO.eColumns.QTY_PER_DAY);
            sb.AppendLine("  ,IT." + ItemViewProcessDTO.eColumns.SUPPLIER_CD);
            sb.AppendLine("  ,IT." + ItemViewProcessDTO.eColumns.OLD_DATA);
            sb.AppendLine("  ,IT." + ItemViewProcessDTO.eColumns.TIME_STAMP);
            sb.AppendLine(" FROM " + tableName + " IT");
            sb.AppendLine(" LEFT JOIN TB_DEALING_MS PR ON IT.PROCESS_CD = PR.LOC_CD AND PR.LOC_CLS = '02' ");            
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  IT." + ItemProcessDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            //sb.AppendLine("  AND " + ItemProcessDTO.eColumns.ORDER_PROCESS_CLS + "=:ORDER_PROCESS_CLS");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, ItemCD.Value);
            //req.Parameters.Add("ORDER_PROCESS_CLS", DataType.NVarChar, ORDER_PROCESS_CLS.Value);
            #endregion

            List<ItemViewProcessDTO> list = db.ExecuteForList<ItemViewProcessDTO>(req);
            return list;
        }

        public int UpdateByItemCD(Database database, ItemProcessDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            //sb.AppendLine("  " + ItemProcessDTO.eColumns.ORDER_PROCESS_CLS + "=:ORDER_PROCESS_CLS");
            //sb.AppendLine("  ," + ItemProcessDTO.eColumns.ORDER_LOC_CD + "=:ORDER_LOC_CD");
            //sb.AppendLine("  ," + ItemProcessDTO.eColumns.STORE_LOC_CD + "=:STORE_LOC_CD");
            //sb.AppendLine("  ," + ItemProcessDTO.eColumns.PACK_SIZE + "=:PACK_SIZE");
            //sb.AppendLine("  ," + ItemProcessDTO.eColumns.CONSUMTION_CLS + "=:CONSUMTION_CLS");
            //sb.AppendLine("  ," + ItemProcessDTO.eColumns.UPD_BY + "=:UPD_BY");
            //sb.AppendLine("  ," + ItemProcessDTO.eColumns.UPD_DATE + "=GETDATE()");
            //sb.AppendLine("  ," + ItemProcessDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            //sb.AppendLine("  ," + ItemProcessDTO.eColumns.LOT_SIZE + "=:LOT_SIZE");

            ////Modify by Sansanee K. 03 June 2011 Case Add Filed
            //sb.AppendLine("  ," + ItemProcessDTO.eColumns.REORDER_POINT + "=:REORDER_POINT");
            //sb.AppendLine("  ," + ItemProcessDTO.eColumns.SAFETY_STOCK + "=:SAFETY_STOCK");
            //sb.AppendLine("  ," + ItemProcessDTO.eColumns.MINIMUM_ORDER + "=:MINIMUM_ORDER");
            //sb.AppendLine("  ," + ItemProcessDTO.eColumns.MAX_CAPACITY + "=:MAX_CAPACITY");
            //sb.AppendLine("  ," + ItemProcessDTO.eColumns.LEADTIME + "=:LEADTIME");
            //sb.AppendLine("  ," + ItemProcessDTO.eColumns.SAFETY_LEADTIME + "=:SAFETY_LEADTIME");
            //sb.AppendLine("  ," + ItemProcessDTO.eColumns.MRP_FLAG + "=:MRP_FLAG");
            //sb.AppendLine("  ," + ItemProcessDTO.eColumns.ORDER_CONDITION + "=:ORDER_CONDITION");
            //sb.AppendLine("  ," + ItemProcessDTO.eColumns.YIELD + "=:YIELD");

            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ItemProcessDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            //sb.AppendLine("  AND " + ItemProcessDTO.eColumns.ORDER_PROCESS_CLS + "=:ORDER_PROCESS_CLS");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            //req.Parameters.Add("ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            //req.Parameters.Add("ORDER_PROCESS_CLS", DataType.NVarChar, data.ORDER_PROCESS_CLS.Value);
            //req.Parameters.Add("ORDER_LOC_CD", DataType.NVarChar, data.ORDER_LOC_CD.Value);
            //req.Parameters.Add("STORE_LOC_CD", DataType.NVarChar, data.STORE_LOC_CD.Value);
            //req.Parameters.Add("PACK_SIZE", DataType.Number, data.PACK_SIZE.Value);
            //req.Parameters.Add("CONSUMTION_CLS", DataType.NVarChar, data.CONSUMTION_CLS.Value);
            //req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            //req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            //req.Parameters.Add("LOT_SIZE", DataType.NVarChar, data.LOT_SIZE.Value);

            ////Modify by Sansanee K. 03 June 2011 Case Add Filed
            //req.Parameters.Add("REORDER_POINT", DataType.Number, data.REORDER_POINT.Value);
            //req.Parameters.Add("SAFETY_STOCK", DataType.Number, data.SAFETY_STOCK.Value);
            //req.Parameters.Add("MINIMUM_ORDER", DataType.Number, data.MINIMUM_ORDER.Value);
            //req.Parameters.Add("MAX_CAPACITY", DataType.Number, data.MAX_CAPACITY.Value);
            //req.Parameters.Add("LEADTIME", DataType.Number, data.LEADTIME.Value);
            //req.Parameters.Add("SAFETY_LEADTIME", DataType.Number, data.SAFETY_LEADTIME.Value);
            //req.Parameters.Add("MRP_FLAG", DataType.NVarChar, data.MRP_FLAG.Value);
            //req.Parameters.Add("ORDER_CONDITION", DataType.NVarChar, data.ORDER_CONDITION.Value);
            //req.Parameters.Add("YIELD", DataType.Number, data.YIELD.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }


        public ItemProcessDTO LoadWeightByItemProcessCount(Database database, ItemProcessDTO data, NZInt processCount)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ItemProcessDTO));
            sb.AppendLine(" select top(1) *  ");
            sb.AppendLine(" from ( ");
            sb.AppendLine("     SELECT TOP(@ProcessCount)");
            sb.AppendLine("     " + ItemProcessDTO.eColumns.CRT_BY);
            sb.AppendLine("     ," + ItemProcessDTO.eColumns.CRT_DATE);
            sb.AppendLine("     ," + ItemProcessDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("     ," + ItemProcessDTO.eColumns.UPD_BY);
            sb.AppendLine("     ," + ItemProcessDTO.eColumns.UPD_DATE);
            sb.AppendLine("     ," + ItemProcessDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("     ," + ItemProcessDTO.eColumns.ITEM_CD);
            sb.AppendLine("     ," + ItemProcessDTO.eColumns.ITEM_SEQ);
            sb.AppendLine("     ," + ItemProcessDTO.eColumns.PROCESS_CD);
            sb.AppendLine("     ," + ItemProcessDTO.eColumns.WEIGHT);
            sb.AppendLine("     ," + ItemProcessDTO.eColumns.PRODUCTION_LEADTIME);
            sb.AppendLine("     ," + ItemProcessDTO.eColumns.QTY_PER_DAY);
            sb.AppendLine("     ," + ItemProcessDTO.eColumns.SUPPLIER_CD);
            sb.AppendLine("     FROM " + tableName);
            sb.AppendLine("     WHERE ");
            sb.AppendLine("     " + ItemProcessDTO.eColumns.ITEM_CD + "=@ITEM_CD");
            sb.AppendLine("     AND " + ItemProcessDTO.eColumns.PROCESS_CD + "=@PROCESS_CD");
            sb.AppendLine("     ORDER BY " + ItemProcessDTO.eColumns.ITEM_SEQ + " ASC ");
            sb.AppendLine(" ) a ");
            sb.AppendLine(" ORDER BY " + ItemProcessDTO.eColumns.ITEM_SEQ + " DESC ");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters

            req.Parameters.Add("@ProcessCount", DataType.Int32, processCount.Value);
            req.Parameters.Add("@ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("@PROCESS_CD", DataType.NVarChar, data.PROCESS_CD.Value);
            #endregion

            List<ItemProcessDTO> list = db.ExecuteForList<ItemProcessDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }

        public int DeleteByItem(Database database, NZString ItemCD)
        {
            Database db = UseDatabase(database);
            string sql = @"DELETE FROM TB_ITEM_PROCESS_MS WHERE ITEM_CD = :ITEM_CD";
            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("ITEM_CD", DataType.VarChar, ItemCD.Value);
            return db.ExecuteNonQuery(req);
        }

        public ItemProcessDTO LoadDefaultProcessOfItem(Database database, NZString ItemCD, NZString ProcessCD) 
        {
            Database db = UseDatabase(database);

            DataRequest req = new DataRequest("S_TRN300_LoadDefaultProcess");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_ItemCD", ItemCD.Value);
            req.Parameters.Add("@pVar_Process_CD", ProcessCD.Value);

            List<ItemProcessDTO> list = db.ExecuteForList<ItemProcessDTO>(req);
            if (list == null || list.Count == 0)
                return null;
            else
                return list[0];
            
        }
    }
}
