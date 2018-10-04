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
    partial class InventoryTransactionDAO : BaseDAO
    {
        /// <summary>
        /// Load data for Inventory transactions. So it will load data between the given date.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="STR_TRANS_DATE"></param>
        /// <param name="END_TRANS_DATE"></param>
        /// <param name="ITEM_CD"></param>
        /// <param name="LOC_CD"></param>
        /// <param name="LOT_NO"></param>
        /// <returns></returns>
        public List<InventoryTransactionDTO> LoadTransactionsOnPeriod(Database database, NZDateTime STR_TRANS_DATE, NZDateTime END_TRANS_DATE, NZString ITEM_CD, NZString LOC_CD, NZString LOT_NO)
        {

            Database db = UseDatabase(database);

            #region SQL Statement
            //StringBuilder sb = new StringBuilder();
            //string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InventoryTransactionDTO));
            //sb.AppendLine(" SELECT ");
            //sb.AppendLine("  " + InventoryTransactionDTO.eColumns.TRANS_ID);
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.ITEM_CD);
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.LOC_CD);
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.LOT_NO);
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRANS_DATE);
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRANS_CLS);
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.IN_OUT_CLS);
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.QTY);
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OBJ_ITEM_CD);
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_NO);
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_SLIP_NO);
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_SLIP_CLS);
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OTHER_DL_NO);
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REMARK);
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.CRT_BY);
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.CRT_DATE);
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.CRT_MACHINE);
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.UPD_BY);
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.UPD_DATE);
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.UPD_MACHINE);
            //sb.AppendLine(" FROM " + tableName);
            //sb.AppendLine(" WHERE ");
            //sb.AppendLine(String.Format("  (({0} IS NULL AND :{1} IS NULL) OR {0} = :{1}) ", InventoryTransactionDTO.eColumns.ITEM_CD, "ITEM_CD"));
            //sb.AppendLine(String.Format("  AND (({0} IS NULL AND :{1} IS NULL) OR {0} = :{1}) ", InventoryTransactionDTO.eColumns.LOC_CD, "LOC_CD"));
            //sb.AppendLine("  AND " + InventoryTransactionDTO.eColumns.TRANS_DATE + " BETWEEN :START_DATE AND :END_DATE");
            //sb.AppendLine(" ORDER BY " + InventoryTransactionDTO.eColumns.TRANS_DATE + "," + InventoryTransactionDTO.eColumns.IN_OUT_CLS + "," + InventoryTransactionDTO.eColumns.TRANS_ID);
            #endregion

            DataRequest req = new DataRequest();
            req.CommandText = "S_INV020_LoadTransaction";
            req.CommandType = CommandType.StoredProcedure;

            req.Parameters.Add("@pITEM_CD", DataType.NVarChar, ITEM_CD.Value);
            req.Parameters.Add("@pLOC_CD", DataType.NVarChar, LOC_CD.Value);
            req.Parameters.Add("@pSTART_DATE", DataType.DateTime, STR_TRANS_DATE.StrongValue.Date);
            req.Parameters.Add("@pEND_DATE", DataType.DateTime, END_TRANS_DATE.StrongValue.Date);
            req.Parameters.Add("@pLOT_NO", DataType.NVarChar, LOT_NO.Value);

            return db.ExecuteForList<InventoryTransactionDTO>(req);
        }

        public List<InventoryTransactionDTO> LoadAllTransactionsOnPeriod(Database database, NZDateTime STR_TRANS_DATE, NZDateTime END_TRANS_DATE)
        {

            Database db = UseDatabase(database);

            #region SQL Statement
            StringBuilder sb = new StringBuilder();
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InventoryTransactionDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + InventoryTransactionDTO.eColumns.TRANS_ID);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.LOC_CD);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.LOT_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRANS_DATE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRANS_CLS);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.IN_OUT_CLS);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.QTY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OBJ_ITEM_CD);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_SLIP_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_SLIP_CLS);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OTHER_DL_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REMARK);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.UPD_MACHINE);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE " + InventoryTransactionDTO.eColumns.TRANS_DATE + " BETWEEN :START_DATE AND :END_DATE");
            //sb.AppendLine(String.Format("  (({0} IS NULL AND :{1} IS NULL) OR {0} = :{1}) ", InventoryTransactionDTO.eColumns.ITEM_CD, "ITEM_CD"));
            //sb.AppendLine(String.Format("  AND (({0} IS NULL AND :{1} IS NULL) OR {0} = :{1}) ", InventoryTransactionDTO.eColumns.LOC_CD, "LOC_CD"));
            //sb.AppendLine("  AND " + InventoryTransactionDTO.eColumns.TRANS_DATE + " BETWEEN :START_DATE AND :END_DATE");
            //sb.AppendLine(" ORDER BY " + InventoryTransactionDTO.eColumns.TRANS_DATE + "," + InventoryTransactionDTO.eColumns.IN_OUT_CLS + "," + InventoryTransactionDTO.eColumns.TRANS_ID);
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            //req.Parameters.Add("ITEM_CD", DataType.NVarChar, ITEM_CD.Value);
            //req.Parameters.Add("LOC_CD", DataType.NVarChar, LOC_CD.Value);
            req.Parameters.Add("START_DATE", DataType.DateTime, STR_TRANS_DATE.StrongValue.Date);

            req.Parameters.Add("END_DATE", DataType.DateTime, END_TRANS_DATE.StrongValue.Date);

            return db.ExecuteForList<InventoryTransactionDTO>(req);
        }

        /// <summary>
        /// Load data for Inventory transactions. So it will load data between the given date.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="STR_TRANS_DATE"></param>
        /// <param name="END_TRANS_DATE"></param>
        /// <param name="ITEM_CD"></param>
        /// <param name="LOC_CD"></param>
        /// <returns></returns>
        public List<InventoryTransactionDTO> LoadTransactionsOnPeriodByLotNo(Database database, NZDateTime STR_TRANS_DATE, NZDateTime END_TRANS_DATE, NZString ITEM_CD, NZString LOC_CD, NZString LOT_NO)
        {

            Database db = UseDatabase(database);

            #region SQL Statement
            StringBuilder sb = new StringBuilder();
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InventoryTransactionDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + InventoryTransactionDTO.eColumns.TRANS_ID);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.LOC_CD);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.LOT_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRANS_DATE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRANS_CLS);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.IN_OUT_CLS);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.QTY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OBJ_ITEM_CD);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_SLIP_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_SLIP_CLS);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OTHER_DL_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REMARK);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.UPD_MACHINE);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine(String.Format("  (({0} IS NULL AND :{1} IS NULL) OR {0} = :{1}) ", InventoryTransactionDTO.eColumns.ITEM_CD, "ITEM_CD"));
            sb.AppendLine(String.Format("  AND (({0} IS NULL AND :{1} IS NULL) OR {0} = :{1}) ", InventoryTransactionDTO.eColumns.LOC_CD, "LOC_CD"));
            sb.AppendLine(String.Format("  AND ISNULL({0}, '') = ISNULL(:{1}, '') ", InventoryTransactionDTO.eColumns.LOT_NO, "LOT_NO"));
            sb.AppendLine("  AND " + InventoryTransactionDTO.eColumns.TRANS_DATE + " BETWEEN :START_DATE AND :END_DATE");
            sb.AppendLine(" ORDER BY " + InventoryTransactionDTO.eColumns.TRANS_DATE + "," + InventoryTransactionDTO.eColumns.IN_OUT_CLS + "," + InventoryTransactionDTO.eColumns.TRANS_ID);
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, ITEM_CD.Value);
            req.Parameters.Add("LOC_CD", DataType.NVarChar, LOC_CD.Value);
            req.Parameters.Add("LOT_NO", DataType.NVarChar, LOT_NO.Value);
            req.Parameters.Add("START_DATE", DataType.DateTime, STR_TRANS_DATE.StrongValue.Date);
            req.Parameters.Add("END_DATE", DataType.DateTime, END_TRANS_DATE.StrongValue.Date);

            return db.ExecuteForList<InventoryTransactionDTO>(req);
        }

        //        public DataTable LoadAllIssueTransByPeriodWithSlipNoIsNull(Database database, NZDateTime PERIOD_BEGIN_DATE, NZDateTime PERIOD_END_DATE)
        //        {
        //            Database db = UseDatabase(database);
        //            string sql = @"   SELECT   TRN.TRANS_DATE ISSUE_DATE,
        //                                       TRN.TRANS_ID ISSUE_NO,
        //                                       TRN.TRANS_CLS ISSUE_TYPE,
        //                                       --  ' '       REF_NO,
        //                                       TRN.ITEM_CD PART_NO,
        //                                       ITM.ITEM_DESC PART_NAME,
        //                                       TRN.QTY ISSUE_QTY,
        //                                       TRN.LOC_CD FROM_LOC,
        //                                       --LOC.LOC_DESC FROM_LOC_NAME,
        //                                       TRN2.LOC_CD TO_LOC,
        //                                       --LOC2.LOC_DESC TO_LOC_NAME,
        //                                       TRN.LOT_NO LOT_NO,
        //                                       TRN.REMARK,
        //                                       TRN.REF_NO
        //                                FROM TB_INV_TRANS_TR TRN
        //                                     INNER JOIN TB_ITEM_MS ITM ON TRN.ITEM_CD = ITM.ITEM_CD
        //                                    -- INNER JOIN TB_LOCATION_MS LOC ON LOC.LOC_CD = TRN.LOC_CD
        //                                     INNER JOIN TB_INV_TRANS_TR TRN2 ON TRN.REF_NO = TRN2.TRANS_ID
        //                                  --   INNER JOIN TB_LOCATION_MS LOC2 ON LOC2.LOC_CD = TRN2.LOC_CD
        //                                WHERE TRN.TRANS_CLS IN ('10', '11') AND
        //                                      TRN.IN_OUT_CLS = '02' AND
        //                                      TRN.TRANS_DATE BETWEEN :PERIOD_BEGIN_DATE AND :PERIOD_END_DATE
        //                                  AND TRN.SLIP_NO IS NULL --AND TRN.REF_SLIP_NO IS NULL
        //";
        //            DataRequest req = new DataRequest(sql);
        //            req.Parameters.Add("PERIOD_BEGIN_DATE", DataType.DateTime, PERIOD_BEGIN_DATE.StrongValue);
        //            req.Parameters.Add("PERIOD_END_DATE", DataType.DateTime, PERIOD_END_DATE.StrongValue);
        //            return db.ExecuteQuery(req);
        //        }

        public DataTable LoadAllIssueTransByPeriod(Database database, NZDateTime PERIOD_BEGIN_DATE, NZDateTime PERIOD_END_DATE, string ScreenType)
        {
            Database db = UseDatabase(database);
            string sql = @"   SELECT   TRN.TRANS_DATE ISSUE_DATE,
                                       TRN.TRANS_ID ISSUE_NO,
                                       TRN.TRANS_CLS ISSUE_TYPE,
                                       TRN.ITEM_CD PART_NO,
                                       ITM.ITEM_DESC PART_NAME,
                                       TRN.QTY ISSUE_QTY,
                                       TRN.LOC_CD FROM_LOC,
                                    
                                       TRN2.LOC_CD TO_LOC,
                                   
                                       TRN.LOT_NO LOT_NO,
                                       TRN.REMARK,
                                       TRN.SLIP_NO,
                                       TRN.OBJ_ITEM_CD,
                                       TRN.OBJ_ORDER_QTY,
                                       TRN.REF_NO,

                                       TRN.TRAN_SUB_CLS,
                                       TRN.FOR_CUSTOMER,
                                       TRN.FOR_MACHINE,
                                       TRN.REF_SLIP_NO,
                                       TRN.REF_SLIP_NO2,
                                       TRN.TRANS_ID


                                FROM TB_INV_TRANS_TR TRN
                                     INNER JOIN TB_ITEM_MS ITM ON TRN.ITEM_CD = ITM.ITEM_CD
                                     
                                     INNER JOIN TB_INV_TRANS_TR TRN2 ON TRN2.TRANS_ID = TRN.REF_NO
                                   
                                WHERE TRN.TRANS_CLS IN ('10','11','12') AND
                                      TRN.IN_OUT_CLS = '02' AND
                                      TRN.TRANS_DATE BETWEEN :PERIOD_BEGIN_DATE AND :PERIOD_END_DATE
                                  AND TRN.SCREEN_TYPE = :SCREEN_TYPE ";

            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("PERIOD_BEGIN_DATE", DataType.DateTime, PERIOD_BEGIN_DATE.Value);
            req.Parameters.Add("PERIOD_END_DATE", DataType.DateTime, PERIOD_END_DATE.Value);
            req.Parameters.Add("SCREEN_TYPE", DataType.VarChar, ScreenType);
            return db.ExecuteQuery(req);
        }


        /// <summary>
        /// Load inventory transaction by join with item to retrieve item description.
        /// It fill data into InventoryTransactionViewDTO.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="PERIOD_BEGIN_DATE">Begin date range.</param>
        /// <param name="PERIOD_END_DATE">End date range.</param>
        /// <param name="TRANS_CLS">Array of trasaction class which need to include.</param>
        /// <returns></returns>
        public List<InventoryTransactionViewDTO> LoadTransactionViewByTypeInPeriod(Database database, NZDateTime PERIOD_BEGIN_DATE, NZDateTime PERIOD_END_DATE, params NZString[] TRANS_CLS)
        {
            Database db = UseDatabase(database);

            string strTypes = string.Empty;
            if (TRANS_CLS != null && TRANS_CLS.Length > 0)
            {
                strTypes = "(";

                for (int i = 0; i < TRANS_CLS.Length; i++)
                {
                    if (i != 0)
                        strTypes += ", ";
                    strTypes += String.Format("'{0}'", TRANS_CLS[i].Value);
                }
            }

            if (strTypes != string.Empty)
                strTypes += ")";

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InventoryTransactionDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  T." + InventoryTransactionViewDTO.eColumns.TRANS_ID);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.LOC_CD);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.LOT_NO);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.TRANS_DATE);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.TRANS_CLS);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.IN_OUT_CLS);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.QTY);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.OBJ_ITEM_CD);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.REF_NO);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.REF_SLIP_NO);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.REF_SLIP_CLS);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.OTHER_DL_NO);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.SLIP_NO);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.REMARK);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.CRT_BY);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.UPD_BY);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.PRICE);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.EXTERNAL_LOT_NO);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.DEALING_NO);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.TRAN_SUB_CLS);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.SHIFT_CLS);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.NG_QTY);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.FOR_MACHINE);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.GROUP_TRANS_ID);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.RESERVE_QTY);
            sb.AppendLine("  ,T.QTY * T.PRICE " + InventoryTransactionViewDTO.eColumns.AMOUNT);
            sb.AppendLine("  ,T.QTY " + InventoryTransactionViewDTO.eColumns.ORDER_QTY);
            sb.AppendLine("  ,ITM." + InventoryTransactionViewDTO.eColumns.ITEM_DESC);

            //Add by Sansanee
            sb.AppendLine("  ,ITM." + InventoryTransactionViewDTO.eColumns.SHORT_NAME);
            sb.AppendLine("  ,CUST.LOC_DESC " + InventoryTransactionViewDTO.eColumns.CUSTOMER_NAME);
            sb.AppendLine("  ,IN_OUT.CLS_DESC " + InventoryTransactionViewDTO.eColumns.IN_OUT_CLS_NAME);
            sb.AppendLine("  ,TRAN_SUB_CLS.CLS_DESC " + InventoryTransactionViewDTO.eColumns.TRAN_SUB_CLS_NAME);
            sb.AppendLine("  ,LOC." + InventoryTransactionViewDTO.eColumns.LOC_DESC);
            //sb.AppendLine("  ,ITM." + InventoryTransactionViewDTO.eColumns.INV_UM_CLS);
            //sb.AppendLine("  ,ITM." + InventoryTransactionViewDTO.eColumns.ORDER_UM_CLS);
            //sb.AppendLine("  ,ITM." + InventoryTransactionViewDTO.eColumns.INV_UM_RATE);
            //sb.AppendLine("  ,ITM." + InventoryTransactionViewDTO.eColumns.ORDER_UM_RATE);
            sb.AppendLine(" FROM " + tableName + " T");
            sb.AppendLine("   INNER JOIN TB_ITEM_MS ITM ");
            sb.AppendLine(String.Format("     ON T.{0} = ITM.{1}", InventoryTransactionViewDTO.eColumns.ITEM_CD, ItemDTO.eColumns.ITEM_CD));

            //Add by Sansanee
            sb.AppendLine("   LEFT JOIN TB_DEALING_MS CUST ");
            sb.AppendLine("     ON ITM.CUSTOMER_CD = CUST.LOC_CD ");
            sb.AppendLine("   LEFT JOIN TB_CLASS_LIST_MS IN_OUT  ");
            sb.AppendLine("     ON T.IN_OUT_CLS = IN_OUT.CLS_CD ");
            sb.AppendLine("         AND IN_OUT.CLS_INFO_CD = 'IN_OUT_CLASS' ");
            sb.AppendLine("   LEFT JOIN TB_CLASS_LIST_MS TRAN_SUB_CLS ");
            sb.AppendLine("     ON T.IN_OUT_CLS = TRAN_SUB_CLS.CLS_CD ");
            sb.AppendLine("         AND TRAN_SUB_CLS.CLS_INFO_CD = 'ADJ_SUBTYPE' ");
            sb.AppendLine("   LEFT JOIN TB_DEALING_MS LOC ");
            sb.AppendLine("     ON T.LOC_CD = LOC.LOC_CD ");

            sb.AppendLine(" WHERE ");
            sb.AppendLine(String.Format("  ((:{1} IS NULL) OR {0} >= :{1}) ", InventoryTransactionViewDTO.eColumns.TRANS_DATE, "PERIOD_BEGIN_DATE"));
            sb.AppendLine(String.Format("  AND ((:{1} IS NULL) OR {0} <= :{1}) ", InventoryTransactionViewDTO.eColumns.TRANS_DATE, "PERIOD_END_DATE"));
            sb.AppendLine(String.Format("  AND T.{0} IN {1} ", InventoryTransactionViewDTO.eColumns.TRANS_CLS, strTypes));
            sb.AppendLine(" AND ISNULL(T.OLD_DATA,0) = 0");
            sb.AppendLine(" ORDER BY T." + InventoryTransactionViewDTO.eColumns.TRANS_ID);
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("PERIOD_BEGIN_DATE", DataType.DateTime, PERIOD_BEGIN_DATE.Value);
            req.Parameters.Add("PERIOD_END_DATE", DataType.DateTime, PERIOD_END_DATE.Value);

            return db.ExecuteForList<InventoryTransactionViewDTO>(req);
        }

        public List<InventoryTransactionViewDTO> LoadTransactionViewByReceiveNo(Database database, NZString SLIP_NO)
        {
            Database db = UseDatabase(database);
            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InventoryTransactionDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  T." + InventoryTransactionViewDTO.eColumns.TRANS_ID);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.LOC_CD);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.LOT_NO);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.TRANS_DATE);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.TRANS_CLS);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.IN_OUT_CLS);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.QTY);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.OBJ_ITEM_CD);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.REF_NO);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.REF_SLIP_NO);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.REF_SLIP_CLS);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.OTHER_DL_NO);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.SLIP_NO);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.REMARK);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.CRT_BY);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.UPD_BY);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.PRICE);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.EXTERNAL_LOT_NO);
            sb.AppendLine("  ,T." + InventoryTransactionViewDTO.eColumns.DEALING_NO);
            //sb.AppendLine("  ,T.QTY * T.PRICE " + InventoryTransactionViewDTO.eColumns.AMOUNT);
            sb.AppendLine("  ,T.QTY * T.PRICE * (ITM.ORDER_UM_RATE / ITM.INV_UM_RATE) " + InventoryTransactionViewDTO.eColumns.AMOUNT);
            sb.AppendLine("  ,T.QTY * (ITM.ORDER_UM_RATE / ITM.INV_UM_RATE) " + InventoryTransactionViewDTO.eColumns.ORDER_QTY);
            sb.AppendLine("  ,ITM." + InventoryTransactionViewDTO.eColumns.ITEM_DESC);
            sb.AppendLine("  ,ITM." + InventoryTransactionViewDTO.eColumns.INV_UM_CLS);
            sb.AppendLine("  ,ITM." + InventoryTransactionViewDTO.eColumns.ORDER_UM_CLS);
            sb.AppendLine("  ,ITM." + InventoryTransactionViewDTO.eColumns.INV_UM_RATE);
            sb.AppendLine("  ,ITM." + InventoryTransactionViewDTO.eColumns.ORDER_UM_RATE);
            //sb.AppendLine("  ,PRC." + ItemProcessDTO.eColumns.LOT_SIZE);
            sb.AppendLine(" FROM " + tableName + " T");
            sb.AppendLine("   INNER JOIN TB_ITEM_MS ITM ");
            sb.AppendLine(String.Format("     ON T.{0} = ITM.{1}", InventoryTransactionViewDTO.eColumns.ITEM_CD, InventoryTransactionViewDTO.eColumns.ITEM_CD));
            sb.AppendLine("   INNER JOIN TB_ITEM_PROCESS_MS PRC ");
            sb.AppendLine(String.Format("     ON T.{0} = PRC.{1}", InventoryTransactionViewDTO.eColumns.ITEM_CD, ItemProcessDTO.eColumns.ITEM_CD));
            sb.AppendLine(" WHERE ");
            sb.AppendLine("   T.SLIP_NO = :SLIP_NO ");
            sb.AppendLine("   AND T.TRANS_CLS IN ('00', '01') ");
            sb.AppendLine(" ORDER BY T." + InventoryTransactionViewDTO.eColumns.TRANS_ID);
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("SLIP_NO", DataType.NVarChar, SLIP_NO.Value);

            return db.ExecuteForList<InventoryTransactionViewDTO>(req);
        }

        public DataTable LoadAllShipTransByPeriod(Database database, NZDateTime PERIOD_BEGIN_DATE, NZDateTime PERIOD_END_DATE)
        {
            Database db = UseDatabase(database);

            string sql =
                @"SELECT   T.TRANS_DATE SHIP_DATE,
                           T.SLIP_NO SHIPMENT_NO,
                           T.TRANS_CLS SHIP_TYPE,
                           T.ITEM_CD PART_NO,
                           ITM.ITEM_DESC PART_NAME,
                           T.LOT_NO LOT_NO,
                           T.QTY QTY,
                           T.LOC_CD STORED_LOC,
                           T.REF_SLIP_NO2 INVOICE_NO,
                           T.TRANS_ID TRANSACTION_ID,
                           T.REMARK REMARK,
                            T.DEALING_NO,
                            T.OTHER_DL_NO
                    FROM TB_INV_TRANS_TR T 
                    INNER JOIN TB_ITEM_MS ITM ON T.ITEM_CD = ITM.ITEM_CD
                    WHERE T.TRANS_CLS IN ('30','31')
                    AND   T.TRANS_DATE BETWEEN :PERIOD_BEGIN_DATE AND :PERIOD_END_DATE
                 ";
            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("PERIOD_BEGIN_DATE", DataType.DateTime, PERIOD_BEGIN_DATE.Value);
            req.Parameters.Add("PERIOD_END_DATE", DataType.DateTime, PERIOD_END_DATE.Value);

            return db.ExecuteQuery(req);
        }

        public DataTable LoadShipList(Database database, NZString SlipNo)
        {
            Database db = UseDatabase(database);

            string sql = @"SELECT    T.ITEM_CD PART_NO,
                                   ITM.ITEM_DESC PART_NAME,
                                     T.LOT_NO LOT_NO,
                                   ONH.ON_HAND_QTY ONHAND_QTY,
                                     T.QTY ISSUE_QTY,
                                     T.TRANS_ID,
                                     T.OTHER_DL_NO,
                                     T.DEALING_NO                                  
                            FROM TB_INV_TRANS_TR T
                                 INNER JOIN TB_ITEM_MS ITM ON T.ITEM_CD = ITM.ITEM_CD     
                                 INNER JOIN TB_INV_ONHAND_TR ONH 
                                   ON ONH.ITEM_CD = T.ITEM_CD
                                  AND ONH.LOC_CD = T.LOC_CD AND ISNULL(ONH.LOT_NO, '') =  ISNULL(T.LOT_NO, '')
                                  AND ONH.YEAR_MONTH = DBO.FNC_LEADING_ZERO(DATEPART(YYYY, T.TRANS_DATE), 4) + DBO.FNC_LEADING_ZERO(DATEPART(MM, T.TRANS_DATE), 2)       

                            WHERE T.SLIP_NO = :SlipNo";
            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("SlipNo", DataType.VarChar, SlipNo.StrongValue);

            return db.ExecuteQuery(req);
        }

        public DataTable LoadIssueListForEdit(Database database, NZString SlipNo)
        {
            Database db = UseDatabase(database);

            string sql = @"SELECT    T.ITEM_CD ITEM_CODE,
                                   ITM.ITEM_DESC ITEM_DESC,
                                     T.LOT_NO LOT_NO,
                                       0 REQUEST_QTY,
                                     T.QTY ISSUE_QTY,
                                     T.QTY + ONH.ON_HAND_QTY ONHAND_QTY,
                                     T.TRANS_ID,
                                     T.REF_NO
                            FROM TB_INV_TRANS_TR T
                            INNER JOIN TB_ITEM_MS ITM ON T.ITEM_CD = ITM.ITEM_CD
                            INNER JOIN TB_INV_ONHAND_TR ONH ON ONH.ITEM_CD = T.ITEM_CD AND
                                              ONH.LOC_CD = T.LOC_CD AND ISNULL(ONH.LOT_NO, '') = ISNULL(
                                              T.LOT_NO, '')
                                    AND ONH.YEAR_MONTH = DBO.FNC_LEADING_ZERO(DATEPART(YYYY, T.TRANS_DATE), 4) + DBO.FNC_LEADING_ZERO(DATEPART(MM, T.TRANS_DATE), 2)       
                            WHERE (T.SLIP_NO = :SlipNo) OR (T.SLIP_NO IS NULL AND T.REF_SLIP_NO = :SlipNo)
                            AND T.IN_OUT_CLS = '02' ORDER BY T.ITEM_CD";
            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("SlipNo", DataType.VarChar, SlipNo.StrongValue);

            return db.ExecuteQuery(req);
        }

        public List<WorkResultEntryViewDTO> LoadWorkResultConsumptionList(Database database, NZString WorkResultNo)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" SELECT");
            sb.AppendLine("   TRN.TRANS_ID ");
            sb.AppendLine("   ,ITM.ITEM_CD");
            sb.AppendLine("   ,ITM.LOT_CONTROL_CLS");
            sb.AppendLine("   ,TRN.LOC_CD ");
            sb.AppendLine("   ,TRN.LOT_NO");
            sb.AppendLine("   ,-1 ON_HAND_QTY");
            sb.AppendLine("   ,TRN.QTY CONSUMPTION_QTY");
            sb.AppendLine("   ,TRN.OBJ_ORDER_QTY * (ISNULL(BOM.LOWER_QTY, 0) / ISNULL(BOM.UPPER_QTY, 1)) REQUEST_QTY");
            sb.AppendLine("   ,ITM.INV_UM_CLS");
            sb.AppendLine(" FROM ");
            sb.AppendLine("   TB_INV_TRANS_TR TRN");
            sb.AppendLine("   INNER JOIN TB_ITEM_MS ITM");
            sb.AppendLine("     ON ITM.ITEM_CD = TRN.ITEM_CD");
            sb.AppendLine("   LEFT JOIN TB_BOM_MS BOM");
            sb.AppendLine("     ON BOM.UPPER_ITEM_CD = TRN.OBJ_ITEM_CD");
            sb.AppendLine("    AND BOM.LOWER_ITEM_CD = TRN.ITEM_CD");
            sb.AppendLine(" WHERE TRN.REF_NO=:WR_NO ");
            sb.AppendLine("   AND TRN.TRANS_CLS = '40' ");
            //sb.AppendLine(" ORDER BY TRN.TRANS_ID");
            sb.AppendLine(" ORDER BY TRN.ITEM_CD,TRN.LOC_CD, TRN.LOT_NO");

            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("WR_NO", DataType.NVarChar, WorkResultNo.Value);

            return db.ExecuteForList<WorkResultEntryViewDTO>(req);
        }
        public InventoryTransactionDTO LoadNGWorkResult(Database database, NZString WorkResultNo)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" SELECT *");

            sb.AppendLine(" FROM ");
            sb.AppendLine("   TB_INV_TRANS_TR TRN");

            sb.AppendLine(" WHERE TRN.SLIP_NO = :WR_NO ");
            sb.AppendLine(string.Format("   AND TRN.TRANS_CLS = '{0}' ", DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.NGWorkResult)));
            // sb.AppendLine(" ORDER BY TRN.TRANS_ID");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("WR_NO", DataType.NVarChar, WorkResultNo.Value);

            List<InventoryTransactionDTO> list = db.ExecuteForList<InventoryTransactionDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }

        public InventoryTransactionDTO LoadReserveResult(Database database, NZString WorkResultNo)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" SELECT *");

            sb.AppendLine(" FROM ");
            sb.AppendLine("   TB_INV_TRANS_TR TRN");

            sb.AppendLine(" WHERE TRN.SLIP_NO = :WR_NO ");
            sb.AppendLine(string.Format("   AND TRN.TRANS_CLS = '{0}' ", DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.ReserveResult)));
            // sb.AppendLine(" ORDER BY TRN.TRANS_ID");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("WR_NO", DataType.NVarChar, WorkResultNo.Value);

            List<InventoryTransactionDTO> list = db.ExecuteForList<InventoryTransactionDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        public List<InventoryTransactionDTO> LoadTransactionsByRefNo(Database database, NZString REF_NO)
        {
            Database db = UseDatabase(database);
            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" SELECT");
            sb.AppendLine("  TRN." + InventoryTransactionDTO.eColumns.TRANS_ID);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.LOC_CD);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.LOT_NO);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.TRANS_DATE);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.TRANS_CLS);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.IN_OUT_CLS);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.QTY);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.OBJ_ITEM_CD);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.OBJ_ORDER_QTY);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.REF_NO);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.REF_SLIP_NO);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.REF_SLIP_CLS);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.OTHER_DL_NO);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.SLIP_NO);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.REMARK);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.CRT_BY);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.UPD_BY);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.UPD_MACHINE);
            // edit by Chatas C. 22 June 2011
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.DEALING_NO);

            sb.AppendLine(" FROM ");
            sb.AppendLine("   TB_INV_TRANS_TR TRN");
            sb.AppendLine(" WHERE");
            sb.AppendLine("   TRN.REF_NO = :REF_NO");
            sb.AppendLine(" ORDER BY");
            sb.AppendLine("   TRN.TRANS_ID  ");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("REF_NO", DataType.NVarChar, REF_NO.Value);

            return db.ExecuteForList<InventoryTransactionDTO>(req);
        }

        public List<InventoryTransactionDTO> LoadConsumptionItemByRefNo(Database database, NZString REF_NO)
        {
            Database db = UseDatabase(database);
            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" SELECT");
            sb.AppendLine("  TRN." + InventoryTransactionDTO.eColumns.TRANS_ID);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.LOC_CD);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.LOT_NO);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.TRANS_DATE);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.TRANS_CLS);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.IN_OUT_CLS);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.QTY);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.OBJ_ITEM_CD);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.OBJ_ORDER_QTY);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.REF_NO);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.REF_SLIP_NO);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.REF_SLIP_CLS);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.OTHER_DL_NO);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.SLIP_NO);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.REMARK);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.CRT_BY);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.UPD_BY);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.UPD_MACHINE);
            sb.AppendLine(" FROM ");
            sb.AppendLine("   TB_INV_TRANS_TR TRN ");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("   TRN.REF_NO = :REF_NO ");
            sb.AppendLine(" AND TRN.TRANS_CLS = '40' ");
            sb.AppendLine(" ORDER BY");
            sb.AppendLine("   TRN.TRANS_ID  ");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("REF_NO", DataType.NVarChar, REF_NO.Value);

            return db.ExecuteForList<InventoryTransactionDTO>(req);
        }


        public InventoryTransactionDTO LoadByRefNoAndTransType(Database database, NZString REF_NO, NZString TRANS_CLS)
        {
            Database db = UseDatabase(database);
            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" SELECT");
            sb.AppendLine("  TRN." + InventoryTransactionDTO.eColumns.TRANS_ID);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.LOC_CD);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.LOT_NO);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.TRANS_DATE);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.TRANS_CLS);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.IN_OUT_CLS);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.QTY);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.OBJ_ITEM_CD);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.OBJ_ORDER_QTY);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.REF_NO);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.REF_SLIP_NO);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.REF_SLIP_CLS);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.OTHER_DL_NO);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.SLIP_NO);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.REMARK);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.CRT_BY);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.UPD_BY);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.UPD_MACHINE);
            sb.AppendLine(" FROM ");
            sb.AppendLine("   TB_INV_TRANS_TR TRN");
            sb.AppendLine(" WHERE");
            sb.AppendLine("   TRN.REF_NO = :REF_NO");
            sb.AppendLine(" AND  TRN.TRANS_CLS = :TRANS_CLS");
            sb.AppendLine(" ORDER BY");
            sb.AppendLine("   TRN.TRANS_ID  ");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("REF_NO", DataType.NVarChar, REF_NO.Value);
            req.Parameters.Add("TRANS_CLS", DataType.NVarChar, TRANS_CLS.Value);

            List<InventoryTransactionDTO> list = db.ExecuteForList<InventoryTransactionDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }

        public List<InventoryTransactionDTO> LoadListTransactionByRefNoAndTransType(Database database, NZString REF_NO, NZString TRANS_CLS)
        {
            Database db = UseDatabase(database);
            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" SELECT");
            sb.AppendLine("  TRN." + InventoryTransactionDTO.eColumns.TRANS_ID);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.LOC_CD);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.LOT_NO);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.TRANS_DATE);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.TRANS_CLS);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.IN_OUT_CLS);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.QTY);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.OBJ_ITEM_CD);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.OBJ_ORDER_QTY);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.REF_NO);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.REF_SLIP_NO);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.REF_SLIP_CLS);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.OTHER_DL_NO);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.SLIP_NO);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.REMARK);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.CRT_BY);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.UPD_BY);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.GROUP_TRANS_ID);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.RESERVE_QTY);
            sb.AppendLine(" FROM ");
            sb.AppendLine("   TB_INV_TRANS_TR TRN");
            sb.AppendLine(" WHERE");
            sb.AppendLine("   TRN.REF_NO = :REF_NO");
            sb.AppendLine(" AND  TRN.TRANS_CLS = :TRANS_CLS");
            sb.AppendLine(" ORDER BY");
            sb.AppendLine("   TRN.TRANS_ID  ");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("REF_NO", DataType.NVarChar, REF_NO.Value);
            req.Parameters.Add("TRANS_CLS", DataType.NVarChar, TRANS_CLS.Value);

            List<InventoryTransactionDTO> list = db.ExecuteForList<InventoryTransactionDTO>(req);

            return list;
        }

        public List<InventoryTransactionDTO> LoadTransactionsBySlipNo(Database database, NZString SLIP_NO)
        {
            Database db = UseDatabase(database);
            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" SELECT");
            sb.AppendLine("  TRN." + InventoryTransactionDTO.eColumns.TRANS_ID);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.LOC_CD);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.LOT_NO);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.TRANS_DATE);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.TRANS_CLS);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.IN_OUT_CLS);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.QTY);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.OBJ_ITEM_CD);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.OBJ_ORDER_QTY);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.REF_NO);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.REF_SLIP_NO);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.REF_SLIP_CLS);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.OTHER_DL_NO);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.SLIP_NO);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.REMARK);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.CRT_BY);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.UPD_BY);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.UPD_MACHINE);
            sb.AppendLine(" FROM ");
            sb.AppendLine("   TB_INV_TRANS_TR TRN");
            sb.AppendLine(" WHERE");
            sb.AppendLine("   TRN.SLIP_NO = :SLIP_NO");
            sb.AppendLine(" ORDER BY");
            sb.AppendLine("   TRN.TRANS_ID  ");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("SLIP_NO", DataType.NVarChar, SLIP_NO.Value);

            return db.ExecuteForList<InventoryTransactionDTO>(req);
        }

        public List<InventoryTransactionDTO> LoadGroupTransaction(Database database, NZString GROUP_TRANS_ID)
        {
            Database db = UseDatabase(database);
            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + InventoryTransactionDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRANS_ID);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.LOC_CD);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.LOT_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.FG_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.PACK_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.EXTERNAL_LOT_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRANS_DATE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRANS_CLS);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.IN_OUT_CLS);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.QTY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.WEIGHT);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OBJ_ITEM_CD);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OBJ_ORDER_QTY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_SLIP_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_SLIP_CLS);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OTHER_DL_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.SLIP_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REMARK);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.DEALING_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.PRICE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.AMOUNT);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.FOR_CUSTOMER);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.FOR_MACHINE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.SHIFT_CLS);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_SLIP_NO2);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.NG_QTY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.NG_WEIGHT);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRAN_SUB_CLS);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.SCREEN_TYPE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.GROUP_TRANS_ID);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.RESERVE_QTY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.NG_REASON);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.EFFECT_STOCK);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.LOT_REMARK);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.PERSON_IN_CHARGE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.CURRENCY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OLD_DATA);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TIME_STAMP);
            sb.AppendLine(" FROM ");
            sb.AppendLine("   TB_INV_TRANS_TR TRN");
            sb.AppendLine(" WHERE");
            sb.AppendLine("   TRN.GROUP_TRANS_ID = :GROUP_TRANS_ID");
            sb.AppendLine(" ORDER BY");
            sb.AppendLine("   TRN.TRANS_ID  ");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("GROUP_TRANS_ID", DataType.NVarChar, GROUP_TRANS_ID.Value);

            return db.ExecuteForList<InventoryTransactionDTO>(req);
        }
        public List<InventoryTransactionDTO> LoadGroupTransaction(Database database, NZString GROUP_TRANS_ID, NZString TRANS_CLS)
        {
            Database db = UseDatabase(database);
            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" SELECT");
            sb.AppendLine("  TRN." + InventoryTransactionDTO.eColumns.TRANS_ID);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.LOC_CD);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.LOT_NO);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.TRANS_DATE);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.TRANS_CLS);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.IN_OUT_CLS);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.QTY);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.OBJ_ITEM_CD);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.OBJ_ORDER_QTY);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.REF_NO);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.REF_SLIP_NO);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.REF_SLIP_CLS);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.OTHER_DL_NO);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.SLIP_NO);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.REMARK);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.CRT_BY);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.UPD_BY);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.DEALING_NO);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.EXTERNAL_LOT_NO);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.PRICE);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.FOR_CUSTOMER);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.FOR_MACHINE);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.SHIFT_CLS);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.REF_SLIP_NO2);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.NG_QTY);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.TRAN_SUB_CLS);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.SCREEN_TYPE);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.GROUP_TRANS_ID);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.RESERVE_QTY);
            sb.AppendLine("  ,TRN." + InventoryTransactionDTO.eColumns.NG_REASON);

            sb.AppendLine(" FROM ");
            sb.AppendLine("   TB_INV_TRANS_TR TRN");
            sb.AppendLine(" WHERE");
            sb.AppendLine("   TRN.GROUP_TRANS_ID = :GROUP_TRANS_ID");
            sb.AppendLine(" AND  TRN.TRANS_CLS = :TRANS_CLS");
            sb.AppendLine(" ORDER BY");
            sb.AppendLine("   TRN.TRANS_ID  ");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("GROUP_TRANS_ID", DataType.NVarChar, GROUP_TRANS_ID.Value);
            req.Parameters.Add("TRANS_CLS", DataType.NVarChar, TRANS_CLS.Value);

            return db.ExecuteForList<InventoryTransactionDTO>(req);
        }

        public void DeleteByItem(Database database, NZString ITEM_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("DELETE FROM TB_INV_TRANS_TR WHERE ITEM_CD=:ITEM_CD");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, ITEM_CD.Value);

            db.ExecuteNonQuery(req);
        }

        public bool ExistsByItem(Database database, NZString ITEM_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT TOP 1 1");
            sb.AppendLine(" FROM TB_INV_TRANS_TR T");
            sb.AppendLine(" WHERE ITEM_CD=:ITEM_CD");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, ITEM_CD.Value);

            object obj = db.ExecuteScalar(req);
            return (obj != null || obj != DBNull.Value);

        }

        public InventoryTransactionDTO LoadReceiveItemByLot(Database database, NZString itemCode, NZString lotNo, NZString locCode)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT *");
            sb.AppendLine(" FROM TB_INV_TRANS_TR T");
            sb.AppendLine(" WHERE (ITEM_CD=:ITEM_CD)");
            sb.AppendLine(" AND (ISNULL(LOT_NO,' ') = ISNULL(:LOT_NO,' '))");
            sb.AppendLine(" AND (TRANS_CLS = '00')");
            sb.AppendLine(" AND (LOC_CD = :LOC_CD)");
            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, itemCode.Value);
            req.Parameters.Add("LOT_NO", DataType.NVarChar, lotNo.Value);
            req.Parameters.Add("LOC_CD", DataType.NVarChar, locCode.Value);

            List<InventoryTransactionDTO> list = db.ExecuteForList<InventoryTransactionDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;

        }

        public DataTable LoadProductionReportList(NZDateTime DateBegin, NZDateTime DateEnd, bool IncludeOldData)
        {
            DataTable dt = null;

            Database db = m_db;

            DataRequest req = new DataRequest("S_TRN210_LoadProductionReportList");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pDtm_DateBegin", DataType.DateTime, CheckNull(DateBegin.Value));
            req.Parameters.Add("@pDtm_DateEnd", DataType.DateTime, CheckNull(DateEnd.Value));
            if (!IncludeOldData)
                req.Parameters.Add("@pInt_OldData", DataType.Int16, 0);    //not include old value   

            DataSet ds = db.ExecuteDataSet(req);

            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }

            return dt;
        }
        public ProductionReportEntryDTO LoadProductionReport(NZString TransID)
        {
            Database db = m_db;

            DataRequest req = new DataRequest("S_TRN210_LoadProductionReport");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_TransID", DataType.VarChar, TransID.Value);

            List<ProductionReportEntryDTO> list = db.ExecuteForList<ProductionReportEntryDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        public DataTable LoadNGTransaction(NZString TransID)
        {
            Database db = m_db;

            DataRequest req = new DataRequest("S_TRN210_LoadNGTransaction");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_TransID", DataType.VarChar, TransID.Value);

            return db.ExecuteQuery(req);
        }

        public DataTable LoadPackingList(NZDateTime DateBegin, NZDateTime DateEnd, bool IncludeOldData)
        {
            DataTable dt = null;

            Database db = m_db;

            DataRequest req = new DataRequest("S_TRN320_LoadPackingList");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pDtm_DateBegin", DataType.DateTime, CheckNull(DateBegin.Value));
            req.Parameters.Add("@pDtm_DateEnd", DataType.DateTime, CheckNull(DateEnd.Value));
            if (!IncludeOldData)
                req.Parameters.Add("@pInt_OldData", DataType.Int16, 0);    //not include old value   

            DataSet ds = db.ExecuteDataSet(req);

            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }

            return dt;
        }
        public PackingEntryDTO LoadPackingByPackingNo(NZString PackingNo)
        {
            Database db = m_db;

            DataRequest req = new DataRequest("S_TRN320_LoadPackingByPackingNo");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_PackingNo", DataType.VarChar, PackingNo.Value);

            List<PackingEntryDTO> list = db.ExecuteForList<PackingEntryDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        public DataTable LoadPackingLotByPackingNo(NZString PackingNo)
        {
            Database db = m_db;

            DataRequest req = new DataRequest("S_TRN320_LoadPackingLotByPackingNo");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_PackingNo", DataType.VarChar, PackingNo.Value);

            return db.ExecuteQuery(req);
        }
        public DataTable LoadPackingList(NZString MasterNo, NZString LocCD, NZString LotNo)
        {
            Database db = m_db;

            DataRequest req = new DataRequest("S_TRN330_LoadPackNoList");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@vVar_LocCD", DataType.VarChar, LocCD.Value);
            req.Parameters.Add("@vVar_ItemCD", DataType.VarChar, MasterNo.Value);
            req.Parameters.Add("@vVar_LotNo", DataType.VarChar, LotNo.Value);

            return db.ExecuteQuery(req);
        }
        public DataTable CountTransRecordByPackNo(NZString PackNo)
        {
            Database db = m_db;

            DataRequest req = new DataRequest("S_TRN320_LoadInventoryTransactionByPackNo");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_PackNo", DataType.VarChar, PackNo.Value);

            return db.ExecuteQuery(req);
        }
        public DataTable CountTransRecordByLotNo(NZString LotNo) {
            Database db = m_db;

            DataRequest req = new DataRequest("S_TRN210_LoadInventoryTransactionByLotNo");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_LotNo", DataType.VarChar, LotNo.Value);

            return db.ExecuteQuery(req);
        }

        public int UpdateReceiveHeader(Database database, InventoryTransactionDTO data)
        {
            Database db = UseDatabase(database);

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
            sb.AppendLine("  " + InventoryTransactionDTO.eColumns.REF_SLIP_NO2 + "=:REF_SLIP_NO2");
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_SLIP_CLS + "=:REF_SLIP_CLS");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OTHER_DL_NO + "=:OTHER_DL_NO");
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.SLIP_NO + "=:SLIP_NO");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REMARK + "=:REMARK");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.DEALING_NO + "=:DEALING_NO");
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.EXTERNAL_LOT_NO + "=:EXTERNAL_LOT_NO");
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.PRICE + "=:PRICE");
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.FOR_CUSTOMER + "=:FOR_CUSTOMER");
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.FOR_MACHINE + "=:FOR_MACHINE");
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.SHIFT_CLS + "=:SHIFT_CLS");
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_SLIP_NO2 + "=:REF_SLIP_NO2");
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.NG_QTY + "=:NG_QTY");
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRAN_SUB_CLS + "=:TRAN_SUB_CLS");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + InventoryTransactionDTO.eColumns.TRANS_ID + "=:TRANS_ID");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("TRANS_ID", DataType.NVarChar, data.TRANS_ID.Value);
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
            req.Parameters.Add("REF_SLIP_NO2", DataType.NVarChar, data.REF_SLIP_NO2.Value);
            //req.Parameters.Add("REF_SLIP_CLS", DataType.NVarChar, data.REF_SLIP_CLS.Value);
            req.Parameters.Add("OTHER_DL_NO", DataType.NVarChar, data.OTHER_DL_NO.Value);
            //req.Parameters.Add("SLIP_NO", DataType.NVarChar, data.SLIP_NO.Value);
            req.Parameters.Add("REMARK", DataType.NVarChar, data.REMARK.Value);
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("DEALING_NO", DataType.NVarChar, data.DEALING_NO.Value);
            //req.Parameters.Add("EXTERNAL_LOT_NO", DataType.NVarChar, data.EXTERNAL_LOT_NO.Value);
            //req.Parameters.Add("PRICE", DataType.Number, data.PRICE.Value);
            //req.Parameters.Add("FOR_CUSTOMER", DataType.NVarChar, data.FOR_CUSTOMER.Value);
            //req.Parameters.Add("FOR_MACHINE", DataType.NVarChar, data.FOR_MACHINE.Value);
            //req.Parameters.Add("SHIFT_CLS", DataType.NVarChar, data.SHIFT_CLS.Value);
            //req.Parameters.Add("REF_SLIP_NO2", DataType.NVarChar, data.REF_SLIP_NO2.Value);
            //req.Parameters.Add("NG_QTY", DataType.Number, data.NG_QTY.Value);
            //req.Parameters.Add("TRAN_SUB_CLS", DataType.NVarChar, data.TRAN_SUB_CLS.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }
        public int UpdateIssueHeader(Database database, InventoryTransactionDTO data)
        {
            Database db = UseDatabase(database);

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
            sb.AppendLine("  " + InventoryTransactionDTO.eColumns.REF_SLIP_NO + "=:REF_SLIP_NO");
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_SLIP_CLS + "=:REF_SLIP_CLS");
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OTHER_DL_NO + "=:OTHER_DL_NO");
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.SLIP_NO + "=:SLIP_NO");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REMARK + "=:REMARK");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.DEALING_NO + "=:DEALING_NO");
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.EXTERNAL_LOT_NO + "=:EXTERNAL_LOT_NO");
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.PRICE + "=:PRICE");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.FOR_CUSTOMER + "=:FOR_CUSTOMER");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.FOR_MACHINE + "=:FOR_MACHINE");
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.SHIFT_CLS + "=:SHIFT_CLS");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_SLIP_NO2 + "=:REF_SLIP_NO2");
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.NG_QTY + "=:NG_QTY");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRAN_SUB_CLS + "=:TRAN_SUB_CLS");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + InventoryTransactionDTO.eColumns.TRANS_ID + "=:TRANS_ID");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("TRANS_ID", DataType.NVarChar, data.TRANS_ID.Value);
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
            req.Parameters.Add("REF_SLIP_NO", DataType.NVarChar, data.REF_SLIP_NO.Value);
            //req.Parameters.Add("REF_SLIP_CLS", DataType.NVarChar, data.REF_SLIP_CLS.Value);
            //req.Parameters.Add("OTHER_DL_NO", DataType.NVarChar, data.OTHER_DL_NO.Value);
            //req.Parameters.Add("SLIP_NO", DataType.NVarChar, data.SLIP_NO.Value);
            req.Parameters.Add("REMARK", DataType.NVarChar, data.REMARK.Value);
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            //req.Parameters.Add("DEALING_NO", DataType.NVarChar, data.DEALING_NO.Value);
            //req.Parameters.Add("EXTERNAL_LOT_NO", DataType.NVarChar, data.EXTERNAL_LOT_NO.Value);
            //req.Parameters.Add("PRICE", DataType.Number, data.PRICE.Value);
            req.Parameters.Add("FOR_CUSTOMER", DataType.NVarChar, data.FOR_CUSTOMER.Value);
            req.Parameters.Add("FOR_MACHINE", DataType.NVarChar, data.FOR_MACHINE.Value);
            //req.Parameters.Add("SHIFT_CLS", DataType.NVarChar, data.SHIFT_CLS.Value);
            req.Parameters.Add("REF_SLIP_NO2", DataType.NVarChar, data.REF_SLIP_NO2.Value);
            //req.Parameters.Add("NG_QTY", DataType.Number, data.NG_QTY.Value);
            req.Parameters.Add("TRAN_SUB_CLS", DataType.NVarChar, data.TRAN_SUB_CLS.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        internal System.Data.DataTable LoadCostView(Database database, List<string> ItemCodes)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine("  SELECT TR.TRANS_DATE AS 'Transaction Date'																  ");
            sb.AppendLine("         ,I.ITEM_CLS + ' : ' + (SELECT CL.CLS_DESC FROM TB_CLASS_LIST_MS CL WHERE CL.CLS_INFO_CD = 'ITEM_CLS' AND CL.CLS_CD = I.ITEM_CLS)  AS 'Item Type'  ");
            sb.AppendLine("         ,MAX(I.ITEM_CLS_MINOR) + ' : ' + (SELECT CL.CLS_DESC FROM TB_CLASS_LIST_MS CL WHERE CL.CLS_INFO_CD = 'ITEM_CLS_MINOR04' AND CL.CLS_CD = MAX(I.ITEM_CLS_MINOR)) AS 'Item Sub Type'  ");
            sb.AppendLine("         ,TR.ITEM_CD AS 'Item Code'  ");
            sb.AppendLine("         ,MAX(I.ITEM_DESC) AS 'Item Name'  ");
            sb.AppendLine("         ,MAX(I.ITEM_8_DIGITS) AS 'Short Name'  ");
            sb.AppendLine("         ,TR.LOT_NO AS 'Lot No'  ");
            sb.AppendLine("         ,TR.TRANS_CLS + ' : ' + (SELECT CL.CLS_DESC FROM TB_CLASS_LIST_MS CL WHERE CL.CLS_INFO_CD = 'TRANS_TYPE' AND CL.CLS_CD = TR.TRANS_CLS) AS 'Transaction Type'  ");
            sb.AppendLine("         ,TR.IN_OUT_CLS + ' : ' + (SELECT CL.CLS_DESC FROM TB_CLASS_LIST_MS CL WHERE CL.CLS_INFO_CD = 'IN_OUT_CLASS' AND CL.CLS_CD = TR.IN_OUT_CLS) AS 'In/Out Type'  ");
            sb.AppendLine("         ,MAX(CASE TR.IN_OUT_CLS WHEN '01' THEN TR.DEALING_NO ELSE NULL END) AS 'Supplier'-- + ' : ' + (SELECT LOC.LOC_DESC FROM TB_LOCATION_MS LOC WHERE LOC.LOC_CD = MAX(CASE TR.IN_OUT_CLS WHEN '01' THEN TR.DEALING_NO ELSE NULL END)) AS 'Supplier'  ");
            sb.AppendLine("         ,SUM(TR.QTY) AS 'Qty'  ");
            sb.AppendLine("         ,CASE WHEN TR.TRANS_CLS = '00' THEN TR.PRICE ");
            sb.AppendLine(" 			  ELSE (SELECT TOP 1 RCV.PRICE FROM TB_INV_TRANS_TR RCV WHERE TR.ITEM_CD = RCV.ITEM_CD AND TR.LOT_NO = RCV.LOT_NO AND RCV.TRANS_CLS = '00')  ");
            sb.AppendLine(" 		 END AS 'Price'  ");
            sb.AppendLine("         ,CASE WHEN TR.TRANS_CLS = '00' THEN TR.PRICE ");
            sb.AppendLine(" 			  ELSE (SELECT TOP 1 RCV.PRICE FROM TB_INV_TRANS_TR RCV WHERE TR.ITEM_CD = RCV.ITEM_CD AND TR.LOT_NO = RCV.LOT_NO AND RCV.TRANS_CLS = '00')  ");
            sb.AppendLine(" 		 END * SUM(TR.QTY) AS 'Amount'  ");
            sb.AppendLine("    FROM TB_INV_TRANS_TR TR  ");
            sb.AppendLine("    JOIN TB_ITEM_MS I   ");
            sb.AppendLine("      ON I.ITEM_CD = TR.ITEM_CD    ");

            sb.AppendLine("  WHERE TR.TRANS_CLS NOT IN ('10', '11', '12') -- NOT IN ISSUE (INTERNAL TRANSFER) ");
            sb.AppendLine("  --  AND I.ITEM_CLS IN ('03', '04') MAT,PART ");
            sb.AppendLine("    AND I.ITEM_CD IN (   ");
            for (int i = 0; i < ItemCodes.Count; i++)
            {
                if (i == 0)
                {
                    //sb.AppendLine("'" + ItemCodes[i] + "'");
                    sb.AppendLine(" :ItemCode" + i + "");
                }
                else
                {
                    // sb.AppendLine(", '" + ItemCodes[i] + "'");
                    sb.AppendLine(", :ItemCode" + i + "");
                }

            }
            sb.AppendLine("  ) ");
            sb.AppendLine("  GROUP BY TR.TRANS_DATE, ");
            sb.AppendLine("           I.ITEM_CLS, ");
            sb.AppendLine("           TR.ITEM_CD, ");
            sb.AppendLine("           TR.LOT_NO, ");
            sb.AppendLine("           TR.TRANS_CLS, ");
            sb.AppendLine("           TR.IN_OUT_CLS, ");
            sb.AppendLine("           TR.PRICE ");
            sb.AppendLine("  ORDER BY I.ITEM_CLS, TR.ITEM_CD, TR.LOT_NO, TR.TRANS_DATE, TR.IN_OUT_CLS; ");

            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            for (int i = 0; i < ItemCodes.Count; i++)
            {
                req.Parameters.Add("ItemCode" + i, DataType.VarChar, ItemCodes[i]);
            }
            #endregion

            return db.ExecuteQuery(req);
        }

        internal System.Data.DataTable LoadInjectionMaterialReportTable(Database database, NZDateTime BeginDate, NZDateTime EndDate, NZString ItemA, NZString ItemB)
        {
            Database db = UseDatabase(database);
            string strSql = "dbo.INJ_MAT_BALANCE_RPT";
            DataRequest req = new DataRequest(strSql);
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@BEGIN_DATE", DataType.DateTime, BeginDate.Value);
            req.Parameters.Add("@END_DATE", DataType.DateTime, EndDate.Value);
            req.Parameters.Add("@ITEM_CD_A", DataType.NVarChar, ItemA.StrongValue == string.Empty ? DBNull.Value : ItemA.Value);
            req.Parameters.Add("@ITEM_CD_B", DataType.NVarChar, ItemB.StrongValue == string.Empty ? DBNull.Value : ItemB.Value);

            return db.ExecuteQuery(req);
        }

        //public int UpdatePOBalance(Database database, InventoryTransactionDTO DTOInventoryTransaction, decimal dChangeQty) {
        //    Database db = UseDatabase(database);

        //    DataRequest req = new DataRequest();
        //    req.CommandText = "S_PURP010_FIFOBalancePOProcess";
        //    req.CommandType = CommandType.StoredProcedure;
        //    req.Parameters.Add("@P_RECEIVING_ID", DataType.NVarChar, DTOInventoryTransaction.TRANS_ID.Value);
        //    req.Parameters.Add("@P_RECEIVING_DATE", DataType.DateTime, DTOInventoryTransaction.TRANS_DATE.Value);
        //    req.Parameters.Add("@P_ITEM_CD", DataType.NVarChar, DTOInventoryTransaction.ITEM_CD.Value);
        //    req.Parameters.Add("@P_SUPPLIER_CD", DataType.NVarChar, DTOInventoryTransaction.DEALING_NO.Value);
        //    req.Parameters.Add("@P_CHGQTY", DataType.Decimal, dChangeQty);
        //    //if (DTOInventoryTransaction.SCREEN_TYPE == DataDefine.ScreenType.ReceivingEntry.ToNZString()) {
        //    //    req.Parameters.Add("@p_IS_INV_UNIT", DataType.Number, 1);//**
        //    //}
        //    if (DTOInventoryTransaction.TRANS_CLS == DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Receiving)) {
        //        req.Parameters.Add("@p_IS_INV_UNIT", DataType.Number, 1);//**
        //    }

        //    return db.ExecuteNonQuery(req);
        //}

        public List<InventoryTransactionDTO> LockRefSlipNumber(Database database, NZString RefSlipNumber)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InventoryTransactionDTO));
            sb.AppendLine(" SELECT 1 ");

            sb.AppendLine(" FROM " + tableName + " WITH(UPDLOCK) ");
            sb.AppendLine(" WHERE ");
            sb.AppendLine(" REF_SLIP_NO = :REF_SLIP_NO ");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("REF_SLIP_NO", DataType.NVarChar, RefSlipNumber.Value);

            return db.ExecuteForList<InventoryTransactionDTO>(req);


        }

        public InventoryTransactionDTO loadShip(Database database, NZString TranId)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InventoryTransactionDTO));
            sb.AppendLine(" SELECT SLIP_NO ");

            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine(" TRANS_ID = :TRANS_ID");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("TRANS_ID", DataType.NVarChar, TranId.Value);


            List<InventoryTransactionDTO> list = db.ExecuteForList<InventoryTransactionDTO>(req);

            return list[0];


        }

        public InventoryTransactionDTO LoadConsumptionTransaction(Database database, NZString TransClass, NZString RefNo, NZString ItemCD)
        {
            Database db = UseDatabase(database);

            DataRequest req = new DataRequest("S_TRN300_LoadConsumptionTransaction");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_TRANS_CLS", DataType.NVarChar, TransClass.Value);
            req.Parameters.Add("@pVar_REF_NO", DataType.NVarChar, RefNo.Value);
            req.Parameters.Add("@pVar_ITEM_CD", DataType.NVarChar, ItemCD.Value);

            List<InventoryTransactionDTO> list = db.ExecuteForList<InventoryTransactionDTO>(req);
            if (list == null || list.Count == 0)
                return null;

            return list[0];

        }

        public List<InventoryTransactionViewDTO> LoadAdjustList(NZDateTime DateBegin, NZDateTime DateEnd, bool IncludeOldData)
        {
            //DataTable dt = null;

            Database db = m_db;

            DataRequest req = new DataRequest("S_TRN110_LoadAdjustList");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pDtm_DateBegin", DataType.DateTime, CheckNull(DateBegin.Value));
            req.Parameters.Add("@pDtm_DateEnd", DataType.DateTime, CheckNull(DateEnd.Value));
            if (!IncludeOldData)
                req.Parameters.Add("@pInt_OldData", DataType.Int16, 0);    //not include old value   

            //DataSet ds = db.ExecuteDataSet(req);

            //if (ds != null && ds.Tables.Count > 0)
            //{
            //    dt = ds.Tables[0];
            //}

            //return dt;

            return db.ExecuteForList<InventoryTransactionViewDTO>(req);
        }

    }
}
