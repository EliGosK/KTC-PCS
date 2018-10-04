#define MODIFY_BY_ITIM
using System.Text;
using EVOFramework;
using EVOFramework.Database;
using System.Data;
using Rubik.DTO;
using System.Collections.Generic;

namespace Rubik.DAO
{
    partial class ItemDAO
    {
        public DataTable LoadAllItemWithItemType(Database database, eSqlOperator sqlOperator, string[] ItemTypes)
        {
            Database db = UseDatabase(database);

            string sql =
                @"SELECT TIM.* , DL.LOC_DESC "
                //TIM.ITEM_CD,
                //TIM.SHORT_NAME,
                //TIM.ITEM_DESC,
                //TIM.KIND_OF_PRODUCT,
                //TIM.CUSTOMER_CD,
                //TIM.CUSTOMER_USE_POINT,
                //TIM.WEIGHT,
                //TIM.BOI,
                //TIM.PRODUCTION_DI,
                //TIM.ITEM_LEVEL,
                //TIM.MAT_NAME,
                //TIM.MAT_SIZE,
                //TIM.MAT_SUPPLIER_CD,
                //TIM.KIND_OF_MAT,
                //TIM.MAT_DI,
                //TIM.REMARK,
                //TIM.CRT_DATE,
                //TIM.CRT_BY,
                //TIM.UPD_DATE,
                //TIM.UPD_BY,
                //TIM.SCREW_KIND,
                //TIM.SCREW_HEAD,
                //TIM.SCREW_M,
                //TIM.SCREW_L,
                //TIM.SCREW_TYPE,
                //TIM.SCREW_REMARK1,
                //TIM.SCREW_REMARK2,
                //TIM.HEXABULAR,
                //--TIMM.MACHINE_PROCESS AS PROCESS1,
                //--TIMM.MACHINE_TYPE AS MACHINE_TYPE1,
                //--TIMM.MACHINE_PROCESS AS PROCESS2,
                //--TIMM.MACHINE_TYPE AS MACHINE_TYPE2,
                //--TIMM.MACHINE_PROCESS AS PROCESS3,
                //--TIMM.MACHINE_TYPE AS MACHINE_TYPE3,
                //--TIMM.MACHINE_PROCESS AS PROCESS4,
                //--TIMM.MACHINE_TYPE AS MACHINE_TYPE4,
                //--TIMM.MACHINE_PROCESS AS PROCESS5,
                //--TIMM.MACHINE_TYPE AS MACHINE_TYPE5,
                //--TIMM.MACHINE_PROCESS AS PROCESS6,
                //--TIMM.MACHINE_TYPE AS MACHINE_TYPE6,
                //TIM.HEAT_FLAG,
                //TIM.HEAT_TYPE,
                //TIM.HEAT_HARDNESS,
                //TIM.HEAT_CORE_HARDNESS,
                //TIM.HEAT_CASE_DEPTH,
                //TIM.PLATING_FLAG,
                //TIM.PLATING_KIND,
                //TIM.PLATING_SUPPLIER_CD,
                //TIM.PLATING_THICKNESS1_1,
                //TIM.PLATING_THICKNESS1_2,
                //TIM.PLATING_THICKNESS2_1,
                //TIM.PLATING_THICKNESS2_2,
                //TIM.PLATING_KTC,
                //TIM.BAKING_FLAG,
                //TIM.BAKING_TIME,
                //TIM.BAKING_TEMP,
                //TIM.OTHER_TREATMENT1_FLAG,
                //TIM.OTHER_TREATMENT1_KIND,
                //TIM.OTHER_TREATMENT1_CONDITION,
                //TIM.OTHER_TREATMENT2_FLAG,
                //TIM.OTHER_TREATMENT2_KIND,
                //TIM.OTHER_TREATMENT2_CONDITION,
                //TIM.ROUTING_TEXT

            + " FROM TB_ITEM_MS TIM "
            + " LEFT JOIN TB_DEALING_MS DL ON TIM.CUSTOMER_CD = DL.LOC_CD";
            //LEFT JOIN TB_ITEM_PROCESS_MS TIPM ON TIM.ITEM_CD = TIPM.ITEM_CD
            //LEFT JOIN TB_ITEM_MACHINE_MS TIMM ON TIPM.ITEM_CD = TIMM.ITEM_CD";


            if (ItemTypes != null && ItemTypes.Length > 0)
            {
                string strOperator = "IN";
                if (sqlOperator == eSqlOperator.NotIn)
                    strOperator = "NOT IN";

                sql += string.Format(" WHERE TIM.KIND_OF_PRODUCT {0} (", strOperator);

                for (int i = 0; i < ItemTypes.Length; i++)
                {
                    sql += "'" + ItemTypes[i] + "'";

                    if (i < ItemTypes.Length - 1)
                        sql += ", ";
                }

                sql += " )";
            }

            sql += " ORDER BY TIM.ITEM_CD";
            
            DataRequest req = new DataRequest(sql);

            return db.ExecuteQuery(req);
        }

        public DataTable LoadAllItemWithItemType(Database database, eSqlOperator sqlOperator, string[] ItemTypes, NZString strDealing, DataDefine.eDealingType argDealingType)
        {
            Database db = UseDatabase(database);

            string sql =
                @"SELECT T.*, DL.LOC_DESC
                FROM TB_ITEM_MS T 
                LEFT JOIN TB_DEALING_MS DL ON T.CUSTOMER_CD = DL.LOC_CD";

            DataRequest req = new DataRequest();

            if (strDealing != null && !"".Equals(strDealing.NVL("")))
            {
                sql += " WHERE T.CUSTOMER_CD = @CUSTOMER_CD";

                req.Parameters.Add("@CUSTOMER_CD", strDealing.Value);
            }

            sql += " ORDER BY T.ITEM_CD";

            req.CommandText = sql;

            return db.ExecuteQuery(req);
        }

        public DataTable LoadAllItemWithItemType(Database database, eSqlOperator sqlOperator, string[] ItemTypes, NZString strSupplier)
        {
            Database db = UseDatabase(database);

            string sql =
                @"SELECT T.*,
                   TT.ORDER_LOC_CD,
                   TT.STORE_LOC_CD,
                   TT.ORDER_PROCESS_CLS,
                   TT.ORDER_LOC_CD,
                   TT.STORE_LOC_CD,
                   TT.PACK_SIZE,
                   TT.CONSUMTION_CLS,
                   TT.LOT_SIZE
                   
            FROM TB_ITEM_MS T
                 INNER JOIN TB_ITEM_PROCESS_MS TT ON T.ITEM_CD = TT.ITEM_CD";
            if (ItemTypes != null && ItemTypes.Length > 0)
            {
                string strOperator = "IN";
                if (sqlOperator == eSqlOperator.NotIn)
                    strOperator = "NOT IN";

                sql += string.Format(" WHERE t.ITEM_CLS {0} (", strOperator);

                for (int i = 0; i < ItemTypes.Length; i++)
                {
                    sql += "'" + ItemTypes[i] + "'";

                    if (i < ItemTypes.Length - 1)
                        sql += ", ";
                }

                sql += " )";
            }

            sql += " AND TT.ORDER_LOC_CD = :SUPPLIER_CD";

            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("SUPPLIER_CD", strSupplier.Value);

            return db.ExecuteQuery(req);
        }

        public DataTable LoadLookupTextHelper(Database database, string Column)
        {
            Database db = UseDatabase(database);
            string sql = string.Format(@"SELECT DISTINCT {0} FROM TB_ITEM_MS
                                         WHERE {0} IS NOT NULL", Column);
            DataRequest req = new DataRequest(sql);
            return db.ExecuteQuery(req);
        }

        public DataTable LoadConsumptionList(Database database, NZString ITEM_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL
            sb.AppendLine(" SELECT ");
            sb.AppendLine("   ITM.ITEM_CD,");
            sb.AppendLine("   ITM.ITEM_DESC,");
            sb.AppendLine("   ITM.ITEM_CLS,");
            sb.AppendLine("   ITM.ITEM_CLS_MINOR,");
            sb.AppendLine("   ITM.LOT_CONTROL_CLS,");
            sb.AppendLine("   ITM.ORDER_UM_CLS,");
            sb.AppendLine("   ITM.ORDER_UM_RATE,");
            sb.AppendLine("   ITM.INV_UM_CLS,");
            sb.AppendLine("   ITM.INV_UM_RATE,");
            sb.AppendLine("   ITM.MODEL,");
            sb.AppendLine("   ITM.COLOR,");
            sb.AppendLine("   ITM.MAIN_MATTERIAL,");
            sb.AppendLine("   ITM.FOR_CUSTOMER,");
            sb.AppendLine("   ITM.ITEM_8_DIGITS,");
            sb.AppendLine("   PRC.ORDER_PROCESS_CLS,");
            sb.AppendLine("   PRC.ORDER_LOC_CD,");
            sb.AppendLine("   PRC.STORE_LOC_CD,");
            sb.AppendLine("   PRC.PACK_SIZE,");
            sb.AppendLine("   PRC.CONSUMTION_CLS");
            sb.AppendLine("   ");
            sb.AppendLine(" FROM FNC_GET_BOM_EXPLOSION(:ITEM_CD, 0, '', '~') BOM");
            sb.AppendLine("   INNER JOIN TB_ITEM_MS ITM");
            sb.AppendLine("      ON ITM.ITEM_CD = BOM.LOWER_ITEM_CD");
            sb.AppendLine("   ");
            sb.AppendLine("   INNER JOIN TB_ITEM_PROCESS_MS PRC");
            sb.AppendLine("      ON PRC.ITEM_CD = BOM.LOWER_ITEM_CD");
            sb.AppendLine("      ");
            sb.AppendLine(" WHERE LEVEL = 1");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, ITEM_CD.Value);

            return db.ExecuteQuery(req);
        }

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool ExistWithItemTypes(Database database, NZString ITEM_CD, eSqlOperator sqlOperator, string[] itemTypes)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT 1 ");
            sb.AppendLine(" FROM TB_ITEM_MS ");
            sb.AppendLine(" WHERE ITEM_CD = :ITEM_CD ");

            if (itemTypes != null && itemTypes.Length > 0)
            {
                string strOperator = "IN";
                if (sqlOperator == eSqlOperator.NotIn)
                    strOperator = "NOT IN";

                sb.AppendLine(string.Format(" AND ITEM_CLS {0} (", strOperator));

                for (int i = 0; i < itemTypes.Length; i++)
                {
                    sb.AppendLine("'" + itemTypes[i] + "'");

                    if (i < itemTypes.Length - 1)
                        sb.AppendLine(", ");
                }

                sb.AppendLine(" )");
            }
            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, ITEM_CD.Value);

            return (db.ExecuteQuery(req).Rows.Count > 0);
        }

        public bool ExistWithCustomer(Database database, NZString ITEM_CD, NZString CUSTOMER_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT 1 ");
            sb.AppendLine(" FROM TB_ITEM_MS ");
            sb.AppendLine(" WHERE ITEM_CD = :ITEM_CD ");
            sb.AppendLine(" AND CUSTOMER_CD = :CUSTOMER_CD ");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, ITEM_CD.Value);
            req.Parameters.Add("CUSTOMER_CD", DataType.NVarChar, CUSTOMER_CD.Value);


            return (db.ExecuteQuery(req).Rows.Count > 0);
        }

        #endregion

        public ItemDTO LoadItemByNo(Database database, NZString MasterNo, NZString PartNo)
        {
            Database db = UseDatabase(database);
            DataRequest req = new DataRequest("S_COMMON_LoadItemByNo");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_MasterNo", DataType.NVarChar, MasterNo.Value);
            req.Parameters.Add("@pVar_PartNo", DataType.NVarChar, PartNo.Value);

            List<ItemDTO> list = db.ExecuteForList<ItemDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }

        
    }
}
