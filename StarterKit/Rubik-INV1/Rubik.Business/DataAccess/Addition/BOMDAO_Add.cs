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
    partial class BOMDAO
    {
        #region Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        /// <param name="UPPER_ITEM_CD"></param>
        /// <returns></returns>
        public List<BOMSetupDTO> LoadBOMExplosion(Database database, NZString UPPER_ITEM_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT * ");
            sb.AppendLine(" FROM dbo.FNC_GET_BOM_EXPLOSION(:UPPER_ITEM_CD, 0, '', '~') ");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("UPPER_ITEM_CD", DataType.NVarChar, UPPER_ITEM_CD.Value);

            return db.ExecuteForList<BOMSetupDTO>(req);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        /// <param name="LOWER_ITEM_CD"></param>
        /// <returns></returns>
        public List<BOMSetupDTO> LoadBOMImplosion(Database database, NZString LOWER_ITEM_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT * ");
            sb.AppendLine(" FROM dbo.FNC_GET_BOM_IMPLOSION(:LOWER_ITEM_CD, 0, '', '~') ");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("LOWER_ITEM_CD", DataType.NVarChar, LOWER_ITEM_CD.Value);

            return db.ExecuteForList<BOMSetupDTO>(req);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ITEM_CD"></param>
        /// <returns></returns>
        public List<BOMSetupViewDTO> LoadBOMSetup(Database database, NZString ITEM_CD)
        {
            Database db = UseDatabase(database);
#if Edit_By_Chatas_C
            DataRequest req = new DataRequest();
            req.CommandText = "S_MAS050_LoadBomWithItemCD";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@Upper_Item_CD", DataType.VarChar, ITEM_CD.Value);
#else
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + BOMSetupViewDTO.eColumns.UPPER_ITEM_CD);
            sb.AppendLine("  ," + BOMSetupViewDTO.eColumns.LOWER_ITEM_CD);
            sb.AppendLine("  ," + BOMSetupViewDTO.eColumns.LEVEL);
            sb.AppendLine("  ," + BOMSetupViewDTO.eColumns.PATH);
            sb.AppendLine("  ," + BOMSetupViewDTO.eColumns.SEQ);
            sb.AppendLine("  ," + BOMSetupViewDTO.eColumns.UPPER_QTY);
            sb.AppendLine("  ," + BOMSetupViewDTO.eColumns.LOWER_QTY);
            sb.AppendLine("  ," + BOMSetupViewDTO.eColumns.CHILD_ORDER_LOC_CD);

            sb.AppendLine("  ,UPPER_ITEM." + ItemDTO.eColumns.ITEM_DESC + " " + BOMSetupViewDTO.eColumns.UPPER_ITEM_DESC);
            sb.AppendLine("  ,LOWER_ITEM." + ItemDTO.eColumns.ITEM_DESC + " " + BOMSetupViewDTO.eColumns.LOWER_ITEM_DESC);
            sb.AppendLine("  ,UPPER_ITEM." + ItemDTO.eColumns.ITEM_CLS + " " + BOMSetupViewDTO.eColumns.UPPER_ITEM_CLS);
            sb.AppendLine("  ,LOWER_ITEM." + ItemDTO.eColumns.ITEM_CLS + " " + BOMSetupViewDTO.eColumns.LOWER_ITEM_CLS);
            sb.AppendLine("  ,UPPER_ITEM." + ItemDTO.eColumns.LOT_CONTROL_CLS + " " + BOMSetupViewDTO.eColumns.UPPER_LOT_CONTROL_CLS);
            sb.AppendLine("  ,LOWER_ITEM." + ItemDTO.eColumns.LOT_CONTROL_CLS + " " + BOMSetupViewDTO.eColumns.LOWER_LOT_CONTROL_CLS);
            sb.AppendLine("  ,H_PRC." + ItemProcessDTO.eColumns.CONSUMTION_CLS + " " + BOMSetupViewDTO.eColumns.UPPER_CONSUMTION_CLS);
            sb.AppendLine("  ,L_PRC." + ItemProcessDTO.eColumns.CONSUMTION_CLS + " " + BOMSetupViewDTO.eColumns.LOWER_CONSUMTION_CLS);
            sb.AppendLine(" FROM dbo.FNC_GET_BOM_EXPLOSION(:UPPER_ITEM_CD, 0, '', '~') T ");
            sb.AppendLine("  INNER JOIN TB_ITEM_MS UPPER_ITEM ");
            sb.AppendLine("    ON T.UPPER_ITEM_CD = UPPER_ITEM.ITEM_CD");
            sb.AppendLine("  INNER JOIN TB_ITEM_MS LOWER_ITEM ");
            sb.AppendLine("    ON T.LOWER_ITEM_CD = LOWER_ITEM.ITEM_CD");
            sb.AppendLine("  INNER JOIN TB_ITEM_PROCESS_MS H_PRC ");
            sb.AppendLine("    ON H_PRC.ITEM_CD = UPPER_ITEM.ITEM_CD ");
            sb.AppendLine("  INNER JOIN TB_ITEM_PROCESS_MS L_PRC ");
            sb.AppendLine("    ON L_PRC.ITEM_CD = LOWER_ITEM.ITEM_CD ");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("UPPER_ITEM_CD", DataType.NVarChar, ITEM_CD.Value);
#endif
            return db.ExecuteForList<BOMSetupViewDTO>(req);
        }

#if Edit_By_Chatas_C     
        public NZString FindMRPFlag(Database database, NZString MRPFlagCD)
        {
            Database db = UseDatabase(database);
            DataRequest req = new DataRequest();
            req.CommandText = "S_MAS051_LoadMRPFLAG";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@MRP_FLAG_CD", DataType.VarChar, MRPFlagCD.Value);
            string strMRPFlag = db.ExecuteScalar(req).ToString();
            return (NZString)strMRPFlag;
        }
#endif

        /// <summary>
        /// Load max sequence of upper item code.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="UPPER_ITEM_CD"></param>
        /// <returns></returns>
        public int LoadMaxSequenceOfUpperItem(Database database, NZString UPPER_ITEM_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT MAX(SEQ) ");
            sb.AppendLine(" FROM TB_BOM_MS ");
            sb.AppendLine("   WHERE UPPER_ITEM_CD = :UPPER_ITEM_CD ");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("UPPER_ITEM_CD", DataType.NVarChar, UPPER_ITEM_CD.Value);

            object obj = db.ExecuteScalar(req);
            if (obj == null || obj == DBNull.Value)
                return 0;

            return Convert.ToInt32(obj);
        }

        /// <summary>
        /// get all child part with level fix from parent part
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ITEM_CD"></param>
        /// <param name="Level"></param>
        /// <returns></returns>
        public List<BOMSetupViewDTO> LoadChildPartWithLevelFix(Database database, NZString ITEM_CD, int Level)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + BOMSetupViewDTO.eColumns.UPPER_ITEM_CD);
            sb.AppendLine("  ," + BOMSetupViewDTO.eColumns.LOWER_ITEM_CD);
            sb.AppendLine("  ," + BOMSetupViewDTO.eColumns.LEVEL);
            sb.AppendLine("  ," + BOMSetupViewDTO.eColumns.PATH);
            sb.AppendLine("  ," + BOMSetupViewDTO.eColumns.SEQ);
            sb.AppendLine("  ," + BOMSetupViewDTO.eColumns.UPPER_QTY);
            sb.AppendLine("  ," + BOMSetupViewDTO.eColumns.LOWER_QTY);
            sb.AppendLine("  ,UPPER_ITEM." + ItemDTO.eColumns.ITEM_DESC + " " + BOMSetupViewDTO.eColumns.UPPER_ITEM_DESC);
            sb.AppendLine("  ,LOWER_ITEM." + ItemDTO.eColumns.ITEM_DESC + " " + BOMSetupViewDTO.eColumns.LOWER_ITEM_DESC);
            //sb.AppendLine("  ,UPPER_ITEM." + ItemDTO.eColumns.ITEM_CLS + " " + BOMSetupViewDTO.eColumns.UPPER_ITEM_CLS);
            //sb.AppendLine("  ,LOWER_ITEM." + ItemDTO.eColumns.ITEM_CLS + " " + BOMSetupViewDTO.eColumns.LOWER_ITEM_CLS);
            //sb.AppendLine("  ,UPPER_ITEM." + ItemDTO.eColumns.LOT_CONTROL_CLS + " " + BOMSetupViewDTO.eColumns.UPPER_LOT_CONTROL_CLS);
            //sb.AppendLine("  ,LOWER_ITEM." + ItemDTO.eColumns.LOT_CONTROL_CLS + " " + BOMSetupViewDTO.eColumns.LOWER_LOT_CONTROL_CLS);
            sb.AppendLine(" FROM dbo.FNC_GET_BOM_EXPLOSION(:UPPER_ITEM_CD, 0, '', '~') T ");
            sb.AppendLine("  INNER JOIN TB_ITEM_MS UPPER_ITEM ");
            sb.AppendLine("    ON T.UPPER_ITEM_CD = UPPER_ITEM.ITEM_CD");
            sb.AppendLine("  INNER JOIN TB_ITEM_MS LOWER_ITEM ");
            sb.AppendLine("    ON T.LOWER_ITEM_CD = LOWER_ITEM.ITEM_CD");
            sb.AppendLine(" WHERE LEVEL = :LEVEL ");
            sb.AppendLine(" ORDER BY LOWER_ITEM_CD ");
            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("UPPER_ITEM_CD", DataType.NVarChar, ITEM_CD.Value);
            req.Parameters.Add("LEVEL", DataType.NVarChar, Level.ToString());

            return db.ExecuteForList<BOMSetupViewDTO>(req);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        /// <param name="UPPER_ITEM_CD"></param>
        /// <param name="LOWER_ITEM_CD"></param>
        /// <returns></returns>
        public List<BOMSetupViewDTO> LoadBOMSetup(Database database, NZString UPPER_ITEM_CD, NZString LOWER_ITEM_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  BOM.UPPER_ITEM_CD " + BOMSetupViewDTO.eColumns.UPPER_ITEM_CD);
            sb.AppendLine("  ,BOM.LOWER_ITEM_CD " + BOMSetupViewDTO.eColumns.LOWER_ITEM_CD);
            sb.AppendLine("  ,0 " + BOMSetupViewDTO.eColumns.LEVEL);
            sb.AppendLine("  ,'' " + BOMSetupViewDTO.eColumns.PATH);
            sb.AppendLine("  ,0 " + BOMSetupViewDTO.eColumns.SEQ);
            sb.AppendLine("  ,BOM.UPPER_QTY " + BOMSetupViewDTO.eColumns.UPPER_QTY);
            sb.AppendLine("  ,BOM.LOWER_QTY " + BOMSetupViewDTO.eColumns.LOWER_QTY);
            sb.AppendLine("  ,UPPER_ITEM." + ItemDTO.eColumns.ITEM_DESC + " " + BOMSetupViewDTO.eColumns.UPPER_ITEM_DESC);
            sb.AppendLine("  ,LOWER_ITEM." + ItemDTO.eColumns.ITEM_DESC + " " + BOMSetupViewDTO.eColumns.LOWER_ITEM_DESC);
            //sb.AppendLine("  ,UPPER_ITEM." + ItemDTO.eColumns.ITEM_CLS + " " + BOMSetupViewDTO.eColumns.UPPER_ITEM_CLS);
            //sb.AppendLine("  ,LOWER_ITEM." + ItemDTO.eColumns.ITEM_CLS + " " + BOMSetupViewDTO.eColumns.LOWER_ITEM_CLS);
            //sb.AppendLine("  ,UPPER_ITEM." + ItemDTO.eColumns.LOT_CONTROL_CLS + " " + BOMSetupViewDTO.eColumns.UPPER_LOT_CONTROL_CLS);
            //sb.AppendLine("  ,LOWER_ITEM." + ItemDTO.eColumns.LOT_CONTROL_CLS + " " + BOMSetupViewDTO.eColumns.LOWER_LOT_CONTROL_CLS);
            sb.AppendLine(" FROM TB_BOM_MS BOM ");
            sb.AppendLine("  INNER JOIN TB_ITEM_MS UPPER_ITEM ");
            sb.AppendLine("    ON BOM.UPPER_ITEM_CD = UPPER_ITEM.ITEM_CD");
            sb.AppendLine("  INNER JOIN TB_ITEM_MS LOWER_ITEM ");
            sb.AppendLine("    ON BOM.LOWER_ITEM_CD = LOWER_ITEM.ITEM_CD");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("   BOM.UPPER_ITEM_CD = :UPPER_ITEM_CD");
            sb.AppendLine("   AND BOM.LOWER_ITEM_CD = :LOWER_ITEM_CD");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("UPPER_ITEM_CD", DataType.NVarChar, UPPER_ITEM_CD.Value);
            req.Parameters.Add("LOWER_ITEM_CD", DataType.NVarChar, LOWER_ITEM_CD.Value);

            return db.ExecuteForList<BOMSetupViewDTO>(req);
        }
        #endregion

        public ItemProcessDTO LoadLocationandMRPFlag(Database database , string strItemCD)
        {
            Database db = UseDatabase(database);
            DataRequest req = new DataRequest();
            req.CommandText = "S_MAS050_LOAD_CHILDLOC_MRP_FROM_ITEM_PROCESS";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@p_Var_ITEM_CD", DataType.VarChar, strItemCD.Trim());
            List<DTO.ItemProcessDTO> list = db.ExecuteForList<DTO.ItemProcessDTO>(req);    
            if(list.Count > 0)
                return list[0];
            else
                return null;     
        }

        public string LoadMRPFLag(Database database, NZString strNZMRPFlag)
        {
            Database db = UseDatabase(database);
            DataRequest req = new DataRequest();
            req.CommandText = "[S_MAS051_LoadMRPFLAG_WITH_DESC]";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@MRP_FLAG_CD", DataType.VarChar, strNZMRPFlag.Value);
            string strMRPFlag = db.ExecuteScalar(req).ToString();
            return (NZString)strMRPFlag;
        }
        #region WorkOrder
        /// <summary>
        /// Explosion BOM for retrieve list child items of specific ITEM_CD on level one.
        /// </summary>
        /// <param name="ITEM_CD">Parent Item Code which want to explosion child BOM.</param>
        /// <param name="ORDER_LOC">Location of order.</param>
        /// <param name="QTY">Quantity of work result.</param>
        /// <returns>List of WorkResultEntryViewDTO</returns>
        public List<WorkResultEntryViewDTO> LoadConsumptionListByExplosionBOM(Database database, NZString ITEM_CD, NZString ORDER_LOC, NZDecimal QTY)
        {
            Database db = UseDatabase(database);
            StringBuilder sb = new StringBuilder();

            InventoryPeriodDAO periodDao = new InventoryPeriodDAO(db);
            InventoryPeriodDTO periodDto = periodDao.LoadCurrentYearMonth(null);

            #region SQL Statement

            //sb.AppendLine(" SELECT T.*, T.REQUEST_QTY " + WorkResultEntryViewDTO.eColumns.CONSUMPTION_QTY);
            //sb.AppendLine(" FROM ( ");
            //sb.AppendLine(" SELECT ");
            //sb.AppendLine("   T_BOM.LOWER_ITEM_CD 	" + WorkResultEntryViewDTO.eColumns.ITEM_CD);
            //sb.AppendLine("   ,L_ITM.LOT_CONTROL_CLS " + WorkResultEntryViewDTO.eColumns.LOT_CONTROL_CLS);
            //sb.AppendLine("   ,:ORDER_LOC LOC_CD ");
            //sb.AppendLine("   ,NULL " + WorkResultEntryViewDTO.eColumns.LOT_NO);
            //sb.AppendLine("   ,ISNULL(STK.ON_HAND_QTY, 0) " + WorkResultEntryViewDTO.eColumns.ON_HAND_QTY);
            //sb.AppendLine("   ,(T_BOM.LOWER_QTY / T_BOM.UPPER_QTY) * :WO_QTY " + WorkResultEntryViewDTO.eColumns.REQUEST_QTY);
            ////sb.AppendLine("   ,T_BOM.LOWER_QTY " + WorkResultEntryViewDTO.eColumns.LOWER_QTY);
            ////sb.AppendLine("   ,T_BOM.UPPER_QTY " + WorkResultEntryViewDTO.eColumns.UPPER_QTY);
            //sb.AppendLine(" ,L_ITM.INV_UM_CLS INV_UM_CLS");
            //sb.AppendLine(" ,T_BOM." + WorkResultEntryViewDTO.eColumns.CHILD_ORDER_LOC_CD.ToString() + " " + WorkResultEntryViewDTO.eColumns.CHILD_ORDER_LOC_CD);
            //sb.AppendLine(" FROM ");
            //sb.AppendLine("   FNC_GET_BOM_EXPLOSION( :ITEM_CD, 0, '', '~') T_BOM");
            //sb.AppendLine("   INNER JOIN TB_ITEM_MS L_ITM");
            //sb.AppendLine("     ON L_ITM.ITEM_CD = T_BOM.LOWER_ITEM_CD");
            //sb.AppendLine("   LEFT JOIN TB_INV_ONHAND_TR STK");
            //sb.AppendLine("     ON STK.ITEM_CD = T_BOM.LOWER_ITEM_CD");
            //sb.AppendLine("    AND STK.LOC_CD = :ORDER_LOC");
            //sb.AppendLine("    AND ISNULL(STK.LOT_NO, '') = '' ");
            //sb.AppendLine("    AND STK.YEAR_MONTH=:YEAR_MONTH ");
            //sb.AppendLine(" WHERE T_BOM.LEVEL = 1");
            //sb.AppendLine(" ) T ");
            //sb.AppendLine(" ORDER BY T.ITEM_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, ITEM_CD.Value);
            req.Parameters.Add("ORDER_LOC", DataType.NVarChar, ORDER_LOC.Value);
            req.Parameters.Add("WO_QTY", DataType.Number, QTY.Value);
            req.Parameters.Add("YEAR_MONTH", DataType.NVarChar, periodDto.YEAR_MONTH.Value);

            return db.ExecuteForList<WorkResultEntryViewDTO>(req);
            }

        public List<MultiWorkResultEntryViewDTO> LoadChildItemToInputMultiWorkResult(Database database, NZString ITEM_CD, NZString ORDER_LOC, NZString LOT_NO, DataDefine.eTRAN_SUB_CLS workResultType)
        {
            Database db = UseDatabase(database);
            StringBuilder sb = new StringBuilder();

            InventoryPeriodDAO periodDao = new InventoryPeriodDAO(db);
            InventoryPeriodDTO periodDto = periodDao.LoadCurrentYearMonth(null);

            #region SQL Statement

            sb.AppendLine(@"select stk.LOT_NO, stk.ON_HAND_QTY ");
            sb.AppendLine(@"from TB_INV_ONHAND_TR stk");
            sb.AppendLine(@"where (STK.LOC_CD = :ORDER_LOC)");
            sb.AppendLine(@"and (STK.YEAR_MONTH = :YEAR_MONTH)");
            sb.AppendLine(@"and (STK.ITEM_CD = :ITEM_CD)");
            sb.AppendLine(@"and (STK.ON_HAND_QTY > 0)");
            sb.AppendLine(@"and (STK.LOT_NO like :LOT_NO + '%' or :LOT_NO is null)");

            if (workResultType == DataDefine.eTRAN_SUB_CLS.WR)
            {
                sb.AppendLine(@"and (STK.LOT_NO not like '%#R')"); //work result หา lot ปกติ
            }
            else if (workResultType == DataDefine.eTRAN_SUB_CLS.RW)
            {
                sb.AppendLine(@"and (STK.LOT_NO like '%#R')"); //rework หา lot ที่เป็น reserve
            }
            else
            {
                throw new NotSupportedException();
            }


            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, ITEM_CD.Value);
            req.Parameters.Add("ORDER_LOC", DataType.NVarChar, ORDER_LOC.Value);
            req.Parameters.Add("YEAR_MONTH", DataType.NVarChar, periodDto.YEAR_MONTH.Value);
            req.Parameters.Add("LOT_NO", DataType.VarChar, LOT_NO.Value);

            return db.ExecuteForList<MultiWorkResultEntryViewDTO>(req);
        }
        #endregion

        public List<ComponentUsageDTO> LoadComponentUsage(Database database, NZString strMasterNo, NZDecimal decQty) {
            Database db = UseDatabase(database);
            DataRequest req = new DataRequest();
            req.CommandText = "S_COMMON_LoadComponentUsage";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_ItemCode", DataType.VarChar, strMasterNo.Value);
            req.Parameters.Add("@pNum_Qty", DataType.VarChar, decQty.Value);
            return db.ExecuteForList<ComponentUsageDTO>(req);            
        }

        public DataTable LoadBOMList()
        {
            DataRequest req = new DataRequest();
            req.CommandText = "S_MAS070_LoadBOMList";
            req.CommandType = CommandType.StoredProcedure;

            return m_db.ExecuteQuery(req);
        }

        public List<ItemComponentDTO> LoadComponentListByItemCD(Database database, NZString ItemCD)
        {
            Database db = UseDatabase(database);

            DataRequest req = new DataRequest("S_MAS040_LoadComponentByMasterNo");
            req.CommandType = CommandType.StoredProcedure;

            #region Parameters
            req.Parameters.Add("@pVar_UpperItemCD", DataType.NVarChar, ItemCD.Value);
            //req.Parameters.Add("ORDER_PROCESS_CLS", DataType.NVarChar, ORDER_PROCESS_CLS.Value);
            #endregion

            List<ItemComponentDTO> list = db.ExecuteForList<ItemComponentDTO>(req);
            return list;
        }
    }
}
