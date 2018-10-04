using System;
using System.Collections.Generic;
using System.Text;
using EVOFramework.Database;
using EVOFramework;
using Rubik.DTO;
using System.Data;

namespace Rubik.DAO
{
    partial class InventoryOnhandDAO
    {
        #region Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        /// <param name="FromPeriod"></param>
        /// <param name="ToPeriod"></param>
        /// <returns></returns>
        internal System.Data.DataTable LoadInventoryOnhand(Database database, DateTime? FromPeriod, DateTime? ToPeriod)
        {
            Database db = UseDatabase(database);
            string sql = @"SELECT  T.LOC_CD LOCATION,
                                   T.ITEM_CD ITEM_CODE,
                                   TT.ITEM_DESC ITEM_DESCRIPTION,
                                   T.LOT_NO LOT_NO,
                                   T.OPEN_QTY PREVIOUS_BAL,
                                   T.IN_QTY TOTAL_IN_QTY,
                                   T.OUT_QTY TOTAL_OUT_QTY,
                                   T.ADJUST_QTY TOTAL_ADJ_QTY,
                                   (T.OPEN_QTY + T.IN_QTY + T.ADJUST_QTY - T.OUT_QTY) ONHAND_QTY,
                                   T.YEAR_MONTH
                              FROM TB_INV_ONHAND_TR T
                             INNER JOIN TB_ITEM_MS TT ON T.ITEM_CD = TT.ITEM_CD
                             WHERE T.PERIOD_BEGIN_DATE >= :FROMDATE
                               AND T.PERIOD_END_DATE <= :ENDDATE
                             ORDER BY T.LOC_CD, T.ITEM_CD, T.LOT_NO ";

            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("FROMDATE", DataType.DateTime, FromPeriod);
            req.Parameters.Add("ENDDATE", DataType.DateTime, ToPeriod);

            return db.ExecuteQuery(req);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        /// <param name="FromPeriod"></param>
        /// <param name="ToPeriod"></param>
        /// <returns></returns>
        internal System.Data.DataTable LoadInventoryOnhandGroupByItem(Database database, DateTime? FromPeriod, DateTime? ToPeriod)
        {
            Database db = UseDatabase(database);
            string sql =
                @"SELECT  T.LOC_CD LOCATION,
                                   T.ITEM_CD ITEM_CODE,
                                   (SELECT TT.ITEM_DESC FROM TB_ITEM_MS TT WHERE T.ITEM_CD = TT.ITEM_CD) ITEM_DESCRIPTION,
                                   '"
                + CommonLib.Common.LOT_NO_GROUPBY +
                @"' LOT_NO,
                                   SUM(T.OPEN_QTY) PREVIOUS_BAL,
                                   SUM(T.IN_QTY) TOTAL_IN_QTY,
                                   SUM(T.OUT_QTY) TOTAL_OUT_QTY,
                                   SUM(T.ADJUST_QTY) TOTAL_ADJ_QTY,
                                   SUM((T.OPEN_QTY + T.IN_QTY + T.ADJUST_QTY - T.OUT_QTY)) ONHAND_QTY,
                                   T.YEAR_MONTH
                              FROM TB_INV_ONHAND_TR T
                             WHERE T.PERIOD_BEGIN_DATE >= :FROMDATE
                               AND T.PERIOD_END_DATE <= :ENDDATE
                             GROUP BY T.ITEM_CD, T.LOC_CD, T.YEAR_MONTH
                             ORDER BY T.LOC_CD, T.ITEM_CD ";

            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("FROMDATE", DataType.DateTime, FromPeriod);
            req.Parameters.Add("ENDDATE", DataType.DateTime, ToPeriod);

            return db.ExecuteQuery(req);

        }

        /// <summary>
        /// Load record InventoryOnHand by IndexKey
        /// </summary>
        /// <param name="database"></param>
        /// <param name="YEAR_MONTH"></param>
        /// <param name="PERIOD_BEGIN_DATE"></param>
        /// <param name="PERIOD_END_DATE"></param>
        /// <param name="ITEM_CD"></param>
        /// <param name="LOC_CD"></param>
        /// <param name="LOT_NO"></param>
        /// <returns></returns>
        public InventoryOnhandDTO LoadInventoryOnHand(Database database, NZString YEAR_MONTH, NZDateTime PERIOD_BEGIN_DATE, NZDateTime PERIOD_END_DATE
            , NZString ITEM_CD
            , NZString LOC_CD
            , NZString LOT_NO)
        {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InventoryOnhandDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + InventoryOnhandDTO.eColumns.ID);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.YEAR_MONTH);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.PERIOD_BEGIN_DATE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.PERIOD_END_DATE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.LOC_CD);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.PACK_NO);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.LOT_NO);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.OPEN_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.IN_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.OUT_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.ADJUST_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.STOCK_TAKE_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.ON_HAND_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.UPD_MACHINE);
            sb.AppendLine(" FROM " + tableName);
            //20100311 add by Pichet
            sb.AppendLine(" with (HOLDLOCK,TABLOCKX) ");
            //20100311 end

            sb.AppendLine(" WHERE ");
            sb.AppendLine(String.Format("  (({0} IS NULL AND :{1} IS NULL) OR {0} = :{1}) ", InventoryOnhandDTO.eColumns.YEAR_MONTH, "YEAR_MONTH"));
            //Remove by Nopparit P. 2010/01/05  On TAKEI Site
            //sb.AppendLine(String.Format("  AND (({0} IS NULL AND :{1} IS NULL) OR {0} = :{1}) ", InventoryOnhandDTO.eColumns.PERIOD_BEGIN_DATE, "PERIOD_BEGIN_DATE"));
            //sb.AppendLine(String.Format("  AND (({0} IS NULL AND :{1} IS NULL) OR {0} = :{1}) ", InventoryOnhandDTO.eColumns.PERIOD_END_DATE, "PERIOD_END_DATE"));
            //End Remove by Nopparit P. 2010/01/05  On TAKEI Site

            sb.AppendLine(String.Format("  AND (({0} IS NULL AND :{1} IS NULL) OR {0} = :{1}) ", InventoryOnhandDTO.eColumns.ITEM_CD, "ITEM_CD"));
            //sb.AppendLine(String.Format("  AND (({0} IS NULL AND :{1} IS NULL) OR {0} = :{1}) ", InventoryOnhandDTO.eColumns.WH_CD, "WH_CD"));
            sb.AppendLine(String.Format("  AND (({0} IS NULL AND :{1} IS NULL) OR {0} = :{1}) ", InventoryOnhandDTO.eColumns.LOC_CD, "LOC_CD"));
            sb.AppendLine(String.Format("  AND (({0} IS NULL AND :{1} IS NULL) OR {0} = :{1}) ", InventoryOnhandDTO.eColumns.LOT_NO, "LOT_NO"));
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("YEAR_MONTH", DataType.NVarChar, YEAR_MONTH.Value);
            //Remove by Nopparit P. 2010/01/05  On TAKEI Site
            //req.Parameters.Add("PERIOD_BEGIN_DATE", DataType.DateTime, PERIOD_BEGIN_DATE.Value);
            //req.Parameters.Add("PERIOD_END_DATE", DataType.DateTime, PERIOD_END_DATE.Value);
            //End Remove by Nopparit P. 2010/01/05  On TAKEI Site
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, ITEM_CD.Value);
            //req.Parameters.Add("WH_CD", DataType.NVarChar, WH_CD.Value);
            req.Parameters.Add("LOC_CD", DataType.NVarChar, LOC_CD.Value);
            req.Parameters.Add("LOT_NO", DataType.NVarChar, LOT_NO.Value);

            List<InventoryOnhandDTO> list = db.ExecuteForList<InventoryOnhandDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }

        public InventoryOnhandDTO LoadInventoryOnHandAllLotNo(Database database, NZString YEAR_MONTH, NZDateTime PERIOD_BEGIN_DATE, NZDateTime PERIOD_END_DATE
            , NZString ITEM_CD
            , NZString LOC_CD
            , NZString LOT_NO
            )
        {

            Database db = UseDatabase(database);


            #region SQL Statement
            //StringBuilder sb = new StringBuilder();
            //string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InventoryOnhandDTO));
            //sb.AppendLine(" SELECT ");
            //sb.AppendLine("  " + InventoryOnhandDTO.eColumns.YEAR_MONTH);
            //sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.ITEM_CD);
            //sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.LOC_CD);
            //sb.AppendLine(String.Format("  ,SUM({0}) {0}", InventoryOnhandDTO.eColumns.OPEN_QTY));
            //sb.AppendLine(String.Format("  ,SUM({0}) {0}", InventoryOnhandDTO.eColumns.IN_QTY));
            //sb.AppendLine(String.Format("  ,SUM({0}) {0}", InventoryOnhandDTO.eColumns.OUT_QTY));
            //sb.AppendLine(String.Format("  ,SUM({0}) {0}", InventoryOnhandDTO.eColumns.ADJUST_QTY));
            //sb.AppendLine(String.Format("  ,SUM({0}) {0}", InventoryOnhandDTO.eColumns.STOCK_TAKE_QTY));
            //sb.AppendLine(String.Format("  ,SUM({0}) {0}", InventoryOnhandDTO.eColumns.ON_HAND_QTY));
            //sb.AppendLine(" FROM " + tableName);
            //sb.AppendLine(" WHERE ");
            //sb.AppendLine(String.Format("  (({0} IS NULL AND :{1} IS NULL) OR {0} = :{1}) ", InventoryOnhandDTO.eColumns.YEAR_MONTH, "YEAR_MONTH"));
            //sb.AppendLine(String.Format("  AND (({0} IS NULL AND :{1} IS NULL) OR {0} = :{1}) ", InventoryOnhandDTO.eColumns.ITEM_CD, "ITEM_CD"));
            //sb.AppendLine(String.Format("  AND (({0} IS NULL AND :{1} IS NULL) OR {0} = :{1}) ", InventoryOnhandDTO.eColumns.LOC_CD, "LOC_CD"));
            //sb.AppendLine(" GROUP BY ");
            //sb.AppendLine("  " + InventoryOnhandDTO.eColumns.YEAR_MONTH);
            //sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.ITEM_CD);
            //sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.LOC_CD);
            #endregion



            DataRequest req = new DataRequest();
            req.CommandType = CommandType.StoredProcedure;
            req.CommandText = "S_INV020_LoadOnHand";

            req.Parameters.Add("@pYEAR_MONTH", DataType.NVarChar, YEAR_MONTH.Value);
            req.Parameters.Add("@pITEM_CD", DataType.NVarChar, ITEM_CD.Value);
            req.Parameters.Add("@pLOC_CD", DataType.NVarChar, LOC_CD.Value);
            req.Parameters.Add("@pLOT_NO", DataType.NVarChar, LOT_NO.Value);

            List<InventoryOnhandDTO> list = db.ExecuteForList<InventoryOnhandDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }

        /// <summary>
        /// Load LotNo in YearMonth by ItemCD and LocCD.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="yearMonth"></param>
        /// <param name="itemCD"></param>
        /// <param name="locationCD"></param>
        /// <returns></returns>
        public List<InventoryOnhandDTO> LoadLotNo(Database database, NZString yearMonth, NZString itemCD, NZString locationCD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InventoryOnhandDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + InventoryOnhandDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.ID);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.YEAR_MONTH);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.PERIOD_BEGIN_DATE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.PERIOD_END_DATE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.LOC_CD);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.PACK_NO);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.LOT_NO);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.OPEN_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.IN_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.OUT_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.ADJUST_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.STOCK_TAKE_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.ON_HAND_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.LAST_RECEIVE_DATE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.EXTERNAL_LOT_NO);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.OLD_DATA);


            sb.AppendLine(" FROM " + tableName);

            sb.AppendLine(" WHERE  YEAR_MONTH=:YEAR_MONTH AND ITEM_CD =:ITEM_CD AND LOC_CD =:LOC_CD");
            sb.AppendLine("  AND LOT_NO IS NOT NULL ");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("ITEM_CD", DataType.VarChar, itemCD.StrongValue);
            req.Parameters.Add("LOC_CD", DataType.VarChar, locationCD.StrongValue);
            req.Parameters.Add("YEAR_MONTH", DataType.NVarChar, yearMonth.Value);

            return db.ExecuteForList<InventoryOnhandDTO>(req);
        }

        /// <summary>
        /// Load LotNo in YearMonth by ItemCD and LocCD that must has onhand qty.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="yearMonth"></param>
        /// <param name="itemCD"></param>
        /// <param name="locationCD"></param>
        /// <returns></returns>
        public List<InventoryOnhandDTO> LoadLotNoWithHasOnhandQty(Database database, NZString yearMonth, NZString currentYearMonth, NZString itemCD, NZString locationCD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InventoryOnhandDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + InventoryOnhandDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.ID);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.YEAR_MONTH);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.PERIOD_BEGIN_DATE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.PERIOD_END_DATE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.LOC_CD);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.PACK_NO);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.LOT_NO);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.OPEN_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.IN_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.OUT_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.ADJUST_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.STOCK_TAKE_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.ON_HAND_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.LAST_RECEIVE_DATE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.EXTERNAL_LOT_NO);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.OLD_DATA);
            sb.AppendLine(" FROM " + tableName);

            sb.AppendLine(" WHERE  (" + InventoryOnhandDTO.eColumns.YEAR_MONTH + "=:YEAR_MONTH) AND " + InventoryOnhandDTO.eColumns.ITEM_CD + " =:ITEM_CD AND " + InventoryOnhandDTO.eColumns.LOC_CD + "=:LOC_CD");
            sb.AppendLine("  AND " + InventoryOnhandDTO.eColumns.ON_HAND_QTY.ToString() + " > 0 ");
            sb.AppendLine("  AND " + InventoryOnhandDTO.eColumns.PACK_NO.ToString() + " IS NOT NULL ");
            sb.AppendLine("  AND " + InventoryOnhandDTO.eColumns.LOT_NO.ToString() + "IS NOT NULL ");

            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add(InventoryOnhandDTO.eColumns.ITEM_CD.ToString(), DataType.VarChar, itemCD.StrongValue);
            req.Parameters.Add(InventoryOnhandDTO.eColumns.LOC_CD.ToString(), DataType.VarChar, locationCD.StrongValue);
            //req.Parameters.Add(InventoryOnhandDTO.eColumns.YEAR_MONTH.ToString(), DataType.NVarChar, yearMonth.Value);
            req.Parameters.Add(InventoryOnhandDTO.eColumns.YEAR_MONTH.ToString(), DataType.NVarChar, currentYearMonth.Value);

            return db.ExecuteForList<InventoryOnhandDTO>(req);
        }

        /// <summary>
        /// Load all of LotNo that be used on speicific YearMonth
        /// </summary>
        /// <param name="database"></param>
        /// <param name="YEAR_MONTH"></param>
        /// <returns></returns>
        public DataTable LoadAllLotNo(Database database, NZString YEAR_MONTH)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT DISTINCT");
            sb.AppendLine("   T.LOT_NO, T.PACK_NO, T.FG_NO, T.EXTERNAL_LOT_NO, 'No Qty' as QTY");
            sb.AppendLine(" FROM TB_INV_ONHAND_TR T");
            sb.AppendLine(" WHERE");
            sb.AppendLine("   T." + InventoryOnhandDTO.eColumns.LOT_NO + " IS NOT NULL");
            sb.AppendLine("   AND T." + InventoryOnhandDTO.eColumns.YEAR_MONTH + "= :YEAR_MONTH");
            sb.AppendLine("   AND T." + InventoryOnhandDTO.eColumns.ON_HAND_QTY + " > 0");
            sb.AppendLine(" ORDER BY T." + InventoryOnhandDTO.eColumns.PACK_NO + ",T." + InventoryOnhandDTO.eColumns.LOT_NO);

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("YEAR_MONTH", DataType.NVarChar, YEAR_MONTH.Value);

            DataTable dt = db.ExecuteQuery(req);
            return dt;
        }

        /// <summary>
        /// Load all of LotNo that be used on speicific YearMonth, ItemCode and LocationCode
        /// </summary>
        /// <param name="database"></param>
        /// <param name="YEAR_MONTH"></param>
        /// <param name="ITEM_CD"></param>
        /// <param name="LOC_CD"></param>
        /// <returns></returns>
        public DataTable LoadAllLotNoByItemAndLocation(Database database, NZString YEAR_MONTH, NZString ITEM_CD, NZString LOC_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("");
            sb.AppendLine(" SELECT DISTINCT");
            sb.AppendLine("   T.LOT_NO, T.PACK_NO, T.FG_NO, T.EXTERNAL_LOT_NO, T.ON_HAND_QTY");
            sb.AppendLine(" FROM TB_INV_ONHAND_TR T");
            sb.AppendLine(" WHERE");
            sb.AppendLine("   T." + InventoryOnhandDTO.eColumns.ITEM_CD + " = :ITEM_CD");
            sb.AppendLine("   AND T." + InventoryOnhandDTO.eColumns.LOC_CD + " = :LOC_CD");
            sb.AppendLine("   AND T." + InventoryOnhandDTO.eColumns.YEAR_MONTH + "= :YEAR_MONTH");
            //sb.AppendLine("   AND T." + InventoryOnhandDTO.eColumns.LOT_NO + " IS NOT NULL");
            sb.AppendLine("   AND T." + InventoryOnhandDTO.eColumns.ON_HAND_QTY + " > 0");

            sb.AppendLine(" ORDER BY T." + InventoryOnhandDTO.eColumns.PACK_NO + ",T." + InventoryOnhandDTO.eColumns.LOT_NO);



            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, ITEM_CD.Value);
            req.Parameters.Add("LOC_CD", DataType.NVarChar, LOC_CD.Value);
            req.Parameters.Add("YEAR_MONTH", DataType.NVarChar, YEAR_MONTH.Value);

            DataTable dt = db.ExecuteQuery(req);
            return dt;
        }

        public DataTable LoadAllLotNoByItemAndLocationIgnoreReserveLot(Database database, NZString YEAR_MONTH, NZString ITEM_CD, NZString LOC_CD, bool showReserveLot)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT DISTINCT");
            sb.AppendLine("   T.LOT_NO, T.PACK_NO, T.ON_HAND_QTY");
            sb.AppendLine(" FROM TB_INV_ONHAND_TR T");
            sb.AppendLine(" WHERE");
            sb.AppendLine("   T." + InventoryOnhandDTO.eColumns.ITEM_CD + " = :ITEM_CD");
            sb.AppendLine("   AND T." + InventoryOnhandDTO.eColumns.LOC_CD + " = :LOC_CD");
            sb.AppendLine("   AND T." + InventoryOnhandDTO.eColumns.YEAR_MONTH + "= :YEAR_MONTH");
            //sb.AppendLine("   AND T." + InventoryOnhandDTO.eColumns.LOT_NO + " IS NOT NULL");
            sb.AppendLine("   AND T." + InventoryOnhandDTO.eColumns.LOT_NO + " NOT LIKE '%" + DataDefine.LOT_RESERVE_POSTFIX + "'");
            sb.AppendLine("   AND T." + InventoryOnhandDTO.eColumns.ON_HAND_QTY + " > 0");

            if (!showReserveLot)
            {
                sb.AppendLine("and (t.LOT_NO not like '%#R' or t.LOT_NO is null)");
            }

            sb.AppendLine(" ORDER BY T." + InventoryOnhandDTO.eColumns.LOT_NO);



            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, ITEM_CD.Value);
            req.Parameters.Add("LOC_CD", DataType.NVarChar, LOC_CD.Value);
            req.Parameters.Add("YEAR_MONTH", DataType.NVarChar, YEAR_MONTH.Value);

            DataTable dt = db.ExecuteQuery(req);
            return dt;
        }

        #endregion

        public List<InventoryOnhandInquiryViewDTO> LoadInventoryOnhandInquiryView(Database database, NZString yearMonth, NZDateTime beginDate, NZDateTime endDate, bool groupByItem, int iToEndOfMonth)
        {
            Database db = UseDatabase(database);

            //StringBuilder sb = new StringBuilder();

            DataRequest req = new DataRequest();
            req.CommandType = CommandType.StoredProcedure;


            if (groupByItem)
            {
                #region
                //sb.AppendLine(" SELECT   ");
                //sb.AppendLine("  T_REAL.YEAR_MONTH  ");
                //sb.AppendLine(" ,T_REAL.LOC_CD LOCATION  ");
                //sb.AppendLine(" ,T_REAL.ITEM_CD ITEM_CODE  ");
                //sb.AppendLine(" ,ITM.ITEM_DESC ITEM_DESCRIPTION  ");
                //sb.AppendLine(" ,T_REAL.LOT_NO  ");
                //sb.AppendLine(" ,T_REAL.OPEN_QTY PREVIOUS_BAL  ");
                //sb.AppendLine(" ,T_REAL.IN_QTY TOTAL_IN_QTY  ");
                //sb.AppendLine(" ,T_REAL.OUT_QTY TOTAL_OUT_QTY  ");
                //sb.AppendLine(" ,T_REAL.ADJ_QTY TOTAL_ADJ_QTY  ");
                //sb.AppendLine(" ,T_REAL.OPEN_QTY+T_REAL.IN_QTY - T_REAL.OUT_QTY +T_REAL.ADJ_QTY ONHAND_QTY  ");
                //sb.AppendLine(" ,ITM.INV_UM_CLS   ");
                //sb.AppendLine(" ,ITM.ITEM_CLS ");
                //sb.AppendLine(" ,ITM.ITEM_CLS_MINOR ");
                //sb.AppendLine(" ,ITM.FOR_CUSTOMER ");
                //sb.AppendLine(" ,ITM.MODEL ");
                //sb.AppendLine(" FROM ( ");
                //sb.AppendLine("       SELECT  ");
                //sb.AppendLine("       ISNULL(STK.YEAR_MONTH,:YEAR_MONTH) AS YEAR_MONTH, ");
                //sb.AppendLine("       ISNULL(STK.ITEM_CD,T_TRN.ITEM_CD) AS ITEM_CD,  ");
                //sb.AppendLine("       ISNULL(STK.LOC_CD,T_TRN.LOC_CD) AS LOC_CD, ");
                //sb.AppendLine("       'XXXXXXXXXX' LOT_NO,  ");
                //sb.AppendLine("       ISNULL(SUM(STK.OPEN_QTY),0) OPEN_QTY,  ");
                //sb.AppendLine("       ISNULL(SUM(T_TRN.IN_QTY),0) IN_QTY,  ");
                //sb.AppendLine("       ISNULL(SUM(T_TRN.OUT_QTY),0) OUT_QTY,  ");
                //sb.AppendLine("       ISNULL(SUM(T_TRN.ADJ_QTY),0) ADJ_QTY  ");
                ////sb.AppendLine("       STK.LAST_RECEIVE_DATE  ");
                //sb.AppendLine("   			      ");
                ////20100722 kim change to support initial data
                ////sb.AppendLine("       FROM (SELECT * FROM TB_INV_ONHAND_TR T WHERE T.YEAR_MONTH = :YEAR_MONTH) STK  ");
                //sb.AppendLine("       FROM (SELECT * FROM TB_INV_ONHAND_TR T WHERE T.YEAR_MONTH = :YEAR_MONTH AND NOT (T.LOT_NO = 'TEST' AND T.IN_QTY = 0 AND T.OUT_QTY = 0 AND T.ON_HAND_QTY =0)) STK  ");

                //sb.AppendLine("            FULL JOIN (  ");
                //sb.AppendLine("                       SELECT    ");
                //sb.AppendLine("                       	  --CONVERT(CHAR(6),TRN.TRANS_DATE,112) YEAR_MONTH ");
                //sb.AppendLine("                           --, ");
                //sb.AppendLine("                           TRN.ITEM_CD  ");
                //sb.AppendLine("                           ,TRN.LOC_CD  ");
                //sb.AppendLine("                           ,ISNULL(TRN.LOT_NO,'') LOT_NO ");
                //sb.AppendLine("                           ,IN_QTY = ISNULL(SUM(CASE  ");
                //sb.AppendLine("                               WHEN IN_OUT_CLS = '01' AND TRANS_CLS <> '50' THEN TRN.QTY  ");
                //sb.AppendLine("                             END),0 ) ");
                //sb.AppendLine("                           ,OUT_QTY = ISNULL(SUM(CASE  ");
                //sb.AppendLine("                               WHEN IN_OUT_CLS = '02' AND TRANS_CLS <> '50' THEN TRN.QTY ");
                //sb.AppendLine("                             END ),0 ) ");
                //sb.AppendLine("                           ,ADJ_QTY = ISNULL(SUM( CASE  ");
                //sb.AppendLine("                               WHEN IN_OUT_CLS = '01' AND TRANS_CLS = '50' THEN TRN.QTY ");
                //sb.AppendLine("                               WHEN IN_OUT_CLS = '02' AND TRANS_CLS = '50' THEN -1 * TRN.QTY  ");
                //sb.AppendLine("                             END)  ,0 )                  ");
                //sb.AppendLine("                             FROM   ");
                //sb.AppendLine("                           TB_INV_TRANS_TR TRN  ");
                //sb.AppendLine("                             WHERE   ");
                //sb.AppendLine("                           TRN.TRANS_DATE BETWEEN CONVERT(DATETIME,:YEAR_MONTH + '01',112) ");
                //sb.AppendLine("              						AND :END_DATE ");
                //sb.AppendLine("                           GROUP BY  ");
                //sb.AppendLine("                             --CONVERT(CHAR(6),TRN.TRANS_DATE,112)  ");
                //sb.AppendLine("                             --, ");
                //sb.AppendLine("                             TRN.ITEM_CD  ");
                //sb.AppendLine("                             ,TRN.LOC_CD  ");
                //sb.AppendLine("                             ,TRN.LOT_NO  ");
                //sb.AppendLine("                       ) T_TRN  ");
                //sb.AppendLine("                           ON  --STK.YEAR_MONTH = T_TRN.YEAR_MONTH  ");
                //sb.AppendLine("                           --AND  ");
                //sb.AppendLine("                           STK.ITEM_CD = T_TRN.ITEM_CD  ");
                //sb.AppendLine("                           AND STK.LOC_CD  = T_TRN.LOC_CD  ");
                //sb.AppendLine("                           AND ISNULL(STK.LOT_NO,'')  = ISNULL(T_TRN.LOT_NO,'') ");
                ////sb.AppendLine(" 	WHERE  ");
                ////sb.AppendLine("     	STK.YEAR_MONTH = :YEAR_MONTH   ");
                //sb.AppendLine("     GROUP BY  ");
                //sb.AppendLine("       ISNULL(STK.YEAR_MONTH,:YEAR_MONTH) , ");
                //sb.AppendLine("       ISNULL(STK.ITEM_CD,T_TRN.ITEM_CD) ,  ");
                //sb.AppendLine("       ISNULL(STK.LOC_CD,T_TRN.LOC_CD)  ");
                ////sb.AppendLine("       STK.ITEM_CD,  ");
                ////sb.AppendLine("       STK.LOC_CD,   ");
                ////sb.AppendLine("       STK.YEAR_MONTH ");
                //sb.AppendLine("        ");
                //sb.AppendLine("              ");
                //sb.AppendLine(" ) T_REAL  ");
                //sb.AppendLine(" 	LEFT JOIN TB_ITEM_MS ITM ON ITM.ITEM_CD = T_REAL.ITEM_CD   ");

                #endregion

                req.CommandText = "S_INV010_InventoryInquiryGroupItem";
            }
            else
            {

                #region
                //sb.AppendLine(" SELECT   ");
                //sb.AppendLine("  T_REAL.YEAR_MONTH  ");
                //sb.AppendLine(" ,T_REAL.LOC_CD LOCATION  ");
                //sb.AppendLine(" ,T_REAL.ITEM_CD ITEM_CODE  ");
                //sb.AppendLine(" ,ITM.ITEM_DESC ITEM_DESCRIPTION  ");
                //sb.AppendLine(" ,T_REAL.LOT_NO  ");
                //sb.AppendLine(" ,T_REAL.OPEN_QTY PREVIOUS_BAL  ");
                //sb.AppendLine(" ,T_REAL.IN_QTY TOTAL_IN_QTY  ");
                //sb.AppendLine(" ,T_REAL.OUT_QTY TOTAL_OUT_QTY  ");
                //sb.AppendLine(" ,T_REAL.ADJ_QTY TOTAL_ADJ_QTY  ");
                //sb.AppendLine(" ,T_REAL.OPEN_QTY+T_REAL.IN_QTY - T_REAL.OUT_QTY +T_REAL.ADJ_QTY ONHAND_QTY  ");
                //sb.AppendLine(" ,ITM.INV_UM_CLS   ");
                //sb.AppendLine(" ,ITM.ITEM_CLS ");
                //sb.AppendLine(" ,ITM.ITEM_CLS_MINOR ");
                //sb.AppendLine(" ,ITM.FOR_CUSTOMER ");
                //sb.AppendLine(" ,ITM.MODEL ");
                //// ------------------------------------------
                //sb.AppendLine(" ,T_REAL.LAST_RECEIVE_DATE ");
                //sb.AppendLine(" ,T_REAL.SUPP_LOT_NO ");
                //// ------------------------------------------
                //sb.AppendLine(" FROM ( ");
                //sb.AppendLine("       SELECT  ");
                //sb.AppendLine("       ISNULL(STK.YEAR_MONTH,:YEAR_MONTH) AS YEAR_MONTH, ");
                //sb.AppendLine("       ISNULL(STK.ITEM_CD,T_TRN.ITEM_CD) AS ITEM_CD,  ");
                //sb.AppendLine("       ISNULL(STK.LOC_CD,T_TRN.LOC_CD) AS LOC_CD, ");
                //sb.AppendLine("       ISNULL(STK.LOT_NO,T_TRN.LOT_NO)  AS LOT_NO, ");
                //// --------------------------------------------
                //sb.AppendLine("       STK.LAST_RECEIVE_DATE,  ");
                //sb.AppendLine("       STK.SUPP_LOT_NO,  ");
                //// --------------------------------------------
                //sb.AppendLine("       ISNULL(STK.OPEN_QTY,0) OPEN_QTY,  ");
                //sb.AppendLine("       ISNULL(T_TRN.IN_QTY,0) IN_QTY,  ");
                //sb.AppendLine("       ISNULL(T_TRN.OUT_QTY,0) OUT_QTY,  ");
                //sb.AppendLine("       ISNULL(T_TRN.ADJ_QTY,0) ADJ_QTY  ");
                //sb.AppendLine("   			      ");
                ////20100722 kim change to support initial data
                ////sb.AppendLine("       FROM (SELECT * FROM TB_INV_ONHAND_TR T WHERE T.YEAR_MONTH = :YEAR_MONTH) STK  ");
                //sb.AppendLine("       FROM (SELECT * FROM TB_INV_ONHAND_TR T WHERE T.YEAR_MONTH = :YEAR_MONTH AND NOT (T.LOT_NO = 'TEST' AND T.IN_QTY = 0 AND T.OUT_QTY = 0 AND T.ON_HAND_QTY =0)) STK  ");

                //sb.AppendLine("            FULL JOIN (  ");
                //sb.AppendLine("                       SELECT    ");
                //sb.AppendLine("                       	 ");
                //sb.AppendLine("                           TRN.ITEM_CD  ");
                //sb.AppendLine("                           ,TRN.LOC_CD  ");
                //sb.AppendLine("                           ,ISNULL(TRN.LOT_NO,'') LOT_NO ");
                //sb.AppendLine("                           ,IN_QTY = ISNULL(SUM(CASE  ");
                //sb.AppendLine("                               WHEN IN_OUT_CLS = '01' AND TRANS_CLS <> '50' THEN TRN.QTY  ");
                //sb.AppendLine("                             END),0 ) ");
                //sb.AppendLine("                           ,OUT_QTY = ISNULL(SUM(CASE  ");
                //sb.AppendLine("                               WHEN IN_OUT_CLS = '02' AND TRANS_CLS <> '50' THEN TRN.QTY ");
                //sb.AppendLine("                             END ),0 ) ");
                //sb.AppendLine("                           ,ADJ_QTY = ISNULL(SUM( CASE  ");
                //sb.AppendLine("                               WHEN IN_OUT_CLS = '01' AND TRANS_CLS = '50' THEN TRN.QTY ");
                //sb.AppendLine("                               WHEN IN_OUT_CLS = '02' AND TRANS_CLS = '50' THEN -1 * TRN.QTY  ");
                //sb.AppendLine("                             END)  ,0 )                  ");
                //sb.AppendLine("                             FROM   ");
                //sb.AppendLine("                           TB_INV_TRANS_TR TRN  ");
                //sb.AppendLine("                             WHERE   ");
                //sb.AppendLine("                           TRN.TRANS_DATE BETWEEN CONVERT(DATETIME,:YEAR_MONTH + '01',112)  ");
                //sb.AppendLine("              						AND CONVERT(DATETIME,:END_DATE,112) ");
                //sb.AppendLine("                           GROUP BY  ");
                //sb.AppendLine("                              ");
                //sb.AppendLine("                              TRN.ITEM_CD  ");
                //sb.AppendLine("                             ,TRN.LOC_CD  ");
                //sb.AppendLine("                             ,TRN.LOT_NO  ");
                //sb.AppendLine("                       ) T_TRN  ");
                //sb.AppendLine("                           ON  ");
                //sb.AppendLine("                           STK.ITEM_CD = T_TRN.ITEM_CD  ");
                //sb.AppendLine("                           AND STK.LOC_CD  = T_TRN.LOC_CD  ");
                //sb.AppendLine("                           AND ISNULL(STK.LOT_NO,'')  = ISNULL(T_TRN.LOT_NO,'') ");
                ////sb.AppendLine(" 	WHERE  ");
                ////sb.AppendLine("     	ISNULL(STK.YEAR_MONTH,:YEAR_MONTH) = :YEAR_MONTH ");
                //sb.AppendLine("  --   GROUP BY  ");
                //sb.AppendLine("  --     STK.ITEM_CD,  ");
                //sb.AppendLine("  --     STK.LOC_CD,   ");
                //sb.AppendLine("  --     STK.YEAR_MONTH  ");
                //sb.AppendLine("        ");
                //sb.AppendLine(" ) T_REAL  ");
                //sb.AppendLine(" 	LEFT JOIN TB_ITEM_MS ITM ON ITM.ITEM_CD = T_REAL.ITEM_CD   ");


                #endregion

                //sb.AppendLine(" ORDER BY T_REAL.LOC_CD,T_REAL.ITEM_CD,T_REAL.LOT_NO ");

                req.CommandText = "S_INV010_InventoryInquiry";
            }

            req.Parameters.Add("@pYEAR_MONTH", DataType.VarChar, yearMonth.Value);
            req.Parameters.Add("@pEND_DATE", DataType.DateTime, endDate.Value);
            req.Parameters.Add("@pTO_END_MONTH", DataType.Int32, iToEndOfMonth);

            return db.ExecuteForList<InventoryOnhandInquiryViewDTO>(req);
        }

        public DataTable LoadInventorySummary(Database database, NZString yearMonth)
        {
            DataTable dtRet = null;

            Database db = UseDatabase(database);

            //StringBuilder sb = new StringBuilder();

            DataRequest req = new DataRequest();
            req.CommandType = CommandType.StoredProcedure;

            req.CommandText = "S_INV070_LoadInventorySummary";
            req.Parameters.Add("@pYEAR_MONTH", DataType.VarChar, yearMonth.Value);

            DataSet ds = db.ExecuteDataSet(req);


            if (ds != null && ds.Tables.Count > 0)
            {
                dtRet = ds.Tables[0];
            }

            return dtRet;
        }


        public void RollingUpProcess(Database database, InventoryPeriodDTO fromPeriod, InventoryPeriodDTO toPeriod)
        {
            Database db = UseDatabase(database);

            string sql = @"     MERGE dbo.TB_INV_ONHAND_TR as target
                                USING (
			                            SELECT --[ID]
			                              :pToYEAR_MONTH as YEAR_MONTH
			                              ,:pToPERIOD_BEGIN_DATE AS [PERIOD_BEGIN_DATE]
			                              ,:pToPERIOD_END_DATE as  [PERIOD_END_DATE]
			                              ,[ITEM_CD]
			                              ,[LOC_CD]
			                              ,[PACK_NO]
			                              ,[LOT_NO]
			                              ,[EXTERNAL_LOT_NO]
			                              ,isnull([ON_HAND_QTY],0) as [ON_HAND_QTY]
			                              --,[CRT_BY]
			                              --,[CRT_DATE]
			                              --,[CRT_MACHINE]
			                              --,[UPD_BY]
			                              --,[UPD_DATE]
			                              --,[UPD_MACHINE]
			                              ,[LAST_RECEIVE_DATE]
                                          ,[FG_NO]
			                            from dbo.TB_INV_ONHAND_TR o 
				                        where o.YEAR_MONTH = :pFromYEAR_MONTH
                                        and isnull([ON_HAND_QTY],0) <> 0
                                ) AS source
                                ON (target.YEAR_MONTH = source.YEAR_MONTH and target.ITEM_CD = source.ITEM_CD and target.LOC_CD = source.LOC_CD and ISNULL(target.LOT_NO,'') = ISNULL(source.LOT_NO,'') and ISNULL(target.PACK_NO,'') = ISNULL(source.PACK_NO,''))
                                WHEN MATCHED THEN 
                                    UPDATE SET [OPEN_QTY] = source.[ON_HAND_QTY] 
                                              ,[ON_HAND_QTY] = source.[ON_HAND_QTY] + ISNULL(IN_QTY,0) - ISNULL(OUT_QTY,0) + isnull(ADJUST_QTY,0) + isnull(STOCK_TAKE_QTY,0)
				                              ,[LAST_RECEIVE_DATE] = source.[LAST_RECEIVE_DATE]
				                              ,[FG_NO] = source.[FG_NO]
				                              ,[UPD_BY] = :pUPD_BY
				                              ,[UPD_DATE] = getdate()
				                              ,[UPD_MACHINE] = :pUPD_MACHINE
				                              ,[OLD_DATA] = 0
                                WHEN NOT MATCHED THEN    
                                    INSERT ([YEAR_MONTH]
                                       ,[PERIOD_BEGIN_DATE]
                                       ,[PERIOD_END_DATE]
                                       ,[ITEM_CD]
                                       ,[LOC_CD]
                                       ,[PACK_NO]
                                       ,[LOT_NO]
                                       ,[EXTERNAL_LOT_NO]
                                       ,[OPEN_QTY]
                                       ,[IN_QTY]
                                       ,[OUT_QTY]
                                       ,[ADJUST_QTY]
                                       ,[STOCK_TAKE_QTY]
                                       ,[ON_HAND_QTY]
                                       ,[CRT_BY]
                                       ,[CRT_DATE]
                                       ,[CRT_MACHINE]
                                       ,[UPD_BY]
                                       ,[UPD_DATE]
                                       ,[UPD_MACHINE]
                                       ,[LAST_RECEIVE_DATE]
                                       ,[FG_NO]
                                       ,[OLD_DATA])
                                    VALUES (source.[YEAR_MONTH]
                                       ,source.[PERIOD_BEGIN_DATE]
                                       ,source.[PERIOD_END_DATE]
                                       ,source.[ITEM_CD]
                                       ,source.[LOC_CD]
                                       ,source.[PACK_NO]
                                       ,source.[LOT_NO]
                                       ,source.[EXTERNAL_LOT_NO]
                                       ,source.[ON_HAND_QTY]
                                       ,0 --source.[IN_QTY]
                                       ,0 --source.[OUT_QTY]
                                       ,0 --source.[ADJUST_QTY]
                                       ,0 --source.[STOCK_TAKE_QTY]
                                       ,source.[ON_HAND_QTY]
                                       ,:pUPD_BY
                                       ,getdate() --source.[CRT_DATE]
                                       ,:pUPD_MACHINE--source.[CRT_MACHINE]
                                       ,:pUPD_BY
                                       ,getdate()--source.[UPD_DATE]
                                       ,:pUPD_MACHINE--source.[UPD_MACHINE]
                                       ,source.[LAST_RECEIVE_DATE]
                                       ,source.[FG_NO]
                                       ,0);";

            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("pToYEAR_MONTH", DataType.NVarChar, toPeriod.YEAR_MONTH.Value);
            req.Parameters.Add("pToPERIOD_BEGIN_DATE", DataType.DateTime, toPeriod.PERIOD_BEGIN_DATE.Value);
            req.Parameters.Add("pToPERIOD_END_DATE", DataType.DateTime, toPeriod.PERIOD_END_DATE.Value);
            req.Parameters.Add("pFromYEAR_MONTH", DataType.NVarChar, fromPeriod.YEAR_MONTH.Value);
            req.Parameters.Add("pUPD_BY", DataType.NVarChar, toPeriod.UPD_BY.Value);
            req.Parameters.Add("pUPD_MACHINE", DataType.NVarChar, toPeriod.UPD_MACHINE.Value);

            db.ExecuteNonQuery(req);

            //            //Update On-Hand
            //            string sql2 = @"update o
            //                            set  o.ON_HAND_QTY   = ISNULL(o.[OPEN_QTY],0) + ISNULL(o.IN_QTY,0) - ISNULL(o.OUT_QTY,0) + isnull(o.ADJUST_QTY,0) + isnull(o.STOCK_TAKE_QTY,0)
            //	                            ,o.[UPD_BY]		 = :pUPD_BY
            //	                            ,o.[UPD_DATE]	 = getdate()
            //	                            ,o.[UPD_MACHINE] = :pUPD_MACHINE
            //                            from TB_INV_ONHAND_TR o
            //                            where o.YEAR_MONTH = :pToYEAR_MONTH";
            //            DataRequest req2 = new DataRequest(sql2);
            //            req2.Parameters.Add("pToYEAR_MONTH", DataType.NVarChar, toPeriod.YEAR_MONTH.Value);
            //            req2.Parameters.Add("pUPD_BY", DataType.NVarChar, toPeriod.UPD_BY.Value);
            //            req2.Parameters.Add("pUPD_MACHINE", DataType.NVarChar, toPeriod.UPD_MACHINE.Value);
            //            db.ExecuteNonQuery(req2);


            //Clear Old Data
            DataRequest req3 = new DataRequest("[dbo].[ClearInventoryData]");
            req3.CommandType = CommandType.StoredProcedure;
            db.ExecuteNonQuery(req3);
        }

        public void RollingDownProcess(Database database, InventoryPeriodDTO fromPeriod, InventoryPeriodDTO toPeriod)
        {
            Database db = UseDatabase(database);
            //Set from period Open =0

            // 10 Jan 2013: modify query by add ON_HAND_QTY = ON_HAND_QTY - OPEN_QTY
            string sql = @" update TB_INV_ONHAND_TR
                            set OPEN_QTY = 0
                                , ON_HAND_QTY = ON_HAND_QTY - OPEN_QTY
                               ,[UPD_BY] = :pUPD_BY
                               ,[UPD_DATE] = getdate()
                               ,[UPD_MACHINE] = :pUPD_MACHINE
                            where YEAR_MONTH =  :pFromYEAR_MONTH ";

            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("pFromYEAR_MONTH", DataType.NVarChar, fromPeriod.YEAR_MONTH.Value);
            req.Parameters.Add("pUPD_BY", DataType.NVarChar, toPeriod.UPD_BY.Value);
            req.Parameters.Add("pUPD_MACHINE", DataType.NVarChar, toPeriod.UPD_MACHINE.Value);
            db.ExecuteNonQuery(req);

            //Set to Period Last receive
            string sql2 = @"     UPDATE TO_PERIOD
                                   SET TO_PERIOD.LAST_RECEIVE_DATE = FRM_PERIOD.LAST_RECEIVE_DATE,
                                       TO_PERIOD.UPD_BY                      = :PUPD_BY,
                                       TO_PERIOD.UPD_DATE                    = GETDATE(),
                                       TO_PERIOD.UPD_MACHINE                 = :PUPD_MACHINE 
                                 FROM TB_INV_ONHAND_TR TO_PERIOD JOIN TB_INV_ONHAND_TR FRM_PERIOD ON FRM_PERIOD.YEAR_MONTH = :pFromYEAR_MONTH
                                                                                                  AND TO_PERIOD.ITEM_CD = FRM_PERIOD.ITEM_CD 
                                                                                                  AND TO_PERIOD.LOC_CD = FRM_PERIOD.LOC_CD 
                                                                                                  AND ISNULL(TO_PERIOD.LOT_NO, ' ') = ISNULL(FRM_PERIOD.LOT_NO, ' ')
                                                                                                  AND ISNULL(TO_PERIOD.PACK_NO, ' ') = ISNULL(FRM_PERIOD.PACK_NO, ' ')
                                 WHERE TO_PERIOD.YEAR_MONTH = :pToYEAR_MONTH ";

            DataRequest req2 = new DataRequest(sql2);
            req2.Parameters.Add("pFromYEAR_MONTH", DataType.NVarChar, fromPeriod.YEAR_MONTH.Value);
            req2.Parameters.Add("pToYEAR_MONTH", DataType.NVarChar, toPeriod.YEAR_MONTH.Value);
            req2.Parameters.Add("pUPD_BY", DataType.NVarChar, toPeriod.UPD_BY.Value);
            req2.Parameters.Add("pUPD_MACHINE", DataType.NVarChar, toPeriod.UPD_MACHINE.Value);
            db.ExecuteNonQuery(req2);

        }

        public InventoryOnhandDTO LoadInventoryOnHandByDate(Database database,
            NZString YEAR_MONTH
            , NZDateTime DATE
            , NZString ITEM_CD
            , NZString LOC_CD
            , NZString LOT_NO
            , NZString PACK_NO

            )
        {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InventoryOnhandDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + InventoryOnhandDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.ID);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.YEAR_MONTH);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.PERIOD_BEGIN_DATE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.PERIOD_END_DATE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.LOC_CD);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.PACK_NO);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.LOT_NO);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.OPEN_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.IN_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.OUT_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.ADJUST_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.STOCK_TAKE_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.ON_HAND_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.LAST_RECEIVE_DATE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.EXTERNAL_LOT_NO);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.OLD_DATA);
            sb.AppendLine(" FROM " + tableName + " WITH(UPDLOCK) ");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("   :DATE BETWEEN PERIOD_BEGIN_DATE AND PERIOD_END_DATE");
            sb.AppendLine(String.Format("  AND (({0} IS NULL AND :{1} IS NULL) OR {0} = :{1}) ", InventoryOnhandDTO.eColumns.YEAR_MONTH, "YEAR_MONTH"));
            sb.AppendLine(String.Format("  AND (({0} IS NULL AND :{1} IS NULL) OR {0} = :{1}) ", InventoryOnhandDTO.eColumns.ITEM_CD, "ITEM_CD"));
            sb.AppendLine(String.Format("  AND (({0} IS NULL AND :{1} IS NULL) OR {0} = :{1}) ", InventoryOnhandDTO.eColumns.LOC_CD, "LOC_CD"));
            //sb.AppendLine(String.Format("  AND (({0} IS NULL AND :{1} IS NULL) OR {0} = :{1}) ", InventoryOnhandDTO.eColumns.LOT_NO, "LOT_NO"));
            sb.AppendLine(String.Format("  AND ISNULL({0}, '') = ISNULL(:{1}, '') ", InventoryOnhandDTO.eColumns.LOT_NO, "LOT_NO"));
            sb.AppendLine(String.Format("  AND ISNULL({0}, '') = ISNULL(:{1}, '') ", InventoryOnhandDTO.eColumns.PACK_NO, "PACK_NO"));
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("YEAR_MONTH", DataType.NVarChar, YEAR_MONTH.Value);
            req.Parameters.Add("DATE", DataType.DateTime, DATE.Value);
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, ITEM_CD.Value);
            req.Parameters.Add("LOC_CD", DataType.NVarChar, LOC_CD.Value);
            req.Parameters.Add("LOT_NO", DataType.NVarChar, LOT_NO.Value);
            req.Parameters.Add("PACK_NO", DataType.NVarChar, PACK_NO.Value);

            List<InventoryOnhandDTO> list = db.ExecuteForList<InventoryOnhandDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }

        public InventoryOnhandDTO LoadInventoryOnHandByYearMonth(Database database,
            NZString YEAR_MONTH
            , NZString ITEM_CD
            , NZString LOC_CD
            , NZString LOT_NO
            , NZString PACK_NO
            )
        {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InventoryOnhandDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + InventoryOnhandDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.ID);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.YEAR_MONTH);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.PERIOD_BEGIN_DATE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.PERIOD_END_DATE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.LOC_CD);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.PACK_NO);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.LOT_NO);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.OPEN_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.IN_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.OUT_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.ADJUST_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.STOCK_TAKE_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.ON_HAND_QTY);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.LAST_RECEIVE_DATE);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.EXTERNAL_LOT_NO);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.OLD_DATA);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + InventoryOnhandDTO.eColumns.YEAR_MONTH + " = :YEAR_MONTH ");
            sb.AppendLine(String.Format("  AND (({0} IS NULL AND :{1} IS NULL) OR {0} = :{1}) ", InventoryOnhandDTO.eColumns.ITEM_CD, "ITEM_CD"));
            sb.AppendLine(String.Format("  AND (({0} IS NULL AND :{1} IS NULL) OR {0} = :{1}) ", InventoryOnhandDTO.eColumns.LOC_CD, "LOC_CD"));
            sb.AppendLine(String.Format("  AND (({0} IS NULL AND :{1} IS NULL) OR {0} = :{1}) ", InventoryOnhandDTO.eColumns.LOT_NO, "LOT_NO"));
            sb.AppendLine(String.Format("  AND (({0} IS NULL AND :{1} IS NULL) OR {0} = :{1}) ", InventoryOnhandDTO.eColumns.PACK_NO, "PACK_NO"));

            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("YEAR_MONTH", DataType.NVarChar, YEAR_MONTH.Value);
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, ITEM_CD.Value);
            req.Parameters.Add("LOC_CD", DataType.NVarChar, LOC_CD.Value);
            req.Parameters.Add("LOT_NO", DataType.NVarChar, LOT_NO.Value);
            req.Parameters.Add("PACK_NO", DataType.NVarChar, PACK_NO.Value);

            List<InventoryOnhandDTO> list = db.ExecuteForList<InventoryOnhandDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }

        public InventoryOnhandDTO LoadInventoryOnHandByItem(Database database,
            NZString ITEM_CD
            , NZString LOC_CD
            )
        {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = "dbo.V_ACTUAL_ONHAND_BY_ITEM";
            sb.AppendLine(" SELECT ");
            sb.AppendLine("   ITEM_CD");
            sb.AppendLine("  ,LOC_CD");
            sb.AppendLine("  ,ONHAND_QTY AS ON_HAND_QTY");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine(String.Format("  (({0} IS NULL AND :{1} IS NULL) OR {0} = :{1}) ", InventoryOnhandDTO.eColumns.ITEM_CD, "ITEM_CD"));
            sb.AppendLine(String.Format("  AND (({0} IS NULL AND :{1} IS NULL) OR {0} = :{1}) ", InventoryOnhandDTO.eColumns.LOC_CD, "LOC_CD"));

            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, ITEM_CD.Value);
            req.Parameters.Add("LOC_CD", DataType.NVarChar, LOC_CD.Value);

            List<InventoryOnhandDTO> list = db.ExecuteForList<InventoryOnhandDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }

        public List<ActualOnhandViewDTO> LoadInventoryOnHandList(Database database,
            NZString ITEM_CD
            , NZString LOC_CD
            , NZString LOT_NO
            , NZString PACK_NO
            //, params NZString[] OrderBy
            )
        {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = "dbo.V_ACTUAL_ONHAND";
            sb.AppendLine(" SELECT ");
            sb.AppendLine("   LAST_RECEIVE_DATE");
            sb.AppendLine("  ,ITEM_CD");
            sb.AppendLine("  ,LOC_CD");
            sb.AppendLine("  ,LOT_NO");
            sb.AppendLine("  ,PACK_NO");
            sb.AppendLine("  ,ONHAND_QTY AS ONHAND_QTY");
            sb.AppendLine("  ,EXTERNAL_LOT_NO");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE 1=1");
            sb.AppendLine(String.Format("  AND (({0} IS NULL AND :{1} IS NULL) OR {0} = :{1}) ", InventoryOnhandDTO.eColumns.ITEM_CD, "ITEM_CD"));
            sb.AppendLine(String.Format("  AND (({0} IS NULL AND :{1} IS NULL) OR {0} = :{1}) ", InventoryOnhandDTO.eColumns.LOC_CD, "LOC_CD"));
            sb.AppendLine(String.Format("  AND ({0} IS NOT NULL) ", InventoryOnhandDTO.eColumns.LOT_NO, "LOT_NO"));
            //sb.AppendLine(String.Format("  AND (({0} IS NULL AND :{1} IS NULL) OR {0} = :{1}) ", InventoryOnhandDTO.eColumns.LOT_NO, "LOT_NO"));
            //sb.AppendLine(String.Format("  AND (({0} IS NULL AND :{1} IS NULL) OR {0} = :{1}) ", InventoryOnhandDTO.eColumns.PACK_NO, "PACK_NO"));

            #endregion

            //if (OrderBy != null && OrderBy.Length > 0)
            //{
            //    sb.AppendLine(" ORDER BY ");
            //    for (int i = 0; i < OrderBy.Length; i++)
            //    {
            //        sb.Append(OrderBy[i].ToString() + ",");
            //    }

            //    sb.Remove(sb.Length - 1, 1);
            //}


            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, ITEM_CD.Value);
            req.Parameters.Add("LOC_CD", DataType.NVarChar, LOC_CD.Value);
            //req.Parameters.Add("LOT_NO", DataType.NVarChar, LOT_NO.Value);
            //req.Parameters.Add("PACK_NO", DataType.NVarChar, PACK_NO.Value);

            return db.ExecuteForList<ActualOnhandViewDTO>(req);
        }


        public List<InventoryOnhandDTO> LoadAllByYearMonth(Database database, NZString YEAR_MONTH)
        {
            Database db = UseDatabase(database);
            string sql = @"SELECT * FROM TB_INV_ONHAND_TR T WHERE T.YEAR_MONTH = :YEAR_MONTH";
            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("YEAR_MONTH", DataType.VarChar, YEAR_MONTH.StrongValue);

            return db.ExecuteForList<InventoryOnhandDTO>(req);
        }
        #region Exists
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, NZString YEAR_MONTH, NZString ITEM_CD, NZString LOC_CD, NZString LOT_NO)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InventoryOnhandDTO));

            sb.AppendLine(" SET ANSI_NULLS OFF; ");
            sb.AppendLine(" SELECT TOP 1 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + InventoryOnhandDTO.eColumns.YEAR_MONTH + "=:YEAR_MONTH");
            sb.AppendLine("  AND " + InventoryOnhandDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            sb.AppendLine("  AND " + InventoryOnhandDTO.eColumns.LOC_CD + "=:LOC_CD");
            sb.AppendLine("  AND " + InventoryOnhandDTO.eColumns.LOT_NO + "=:LOT_NO");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("YEAR_MONTH", DataType.NVarChar, YEAR_MONTH.Value);
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, ITEM_CD.Value);
            req.Parameters.Add("LOC_CD", DataType.NVarChar, LOC_CD.Value);
            req.Parameters.Add("LOT_NO", DataType.NVarChar, LOT_NO.Value);
            #endregion

            return (db.ExecuteQuery(req).Rows.Count > 0);
        }

        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, NZDateTime PERIOD_BEGIN_DATE, NZDateTime PERIOD_END_DATE, NZString ITEM_CD, NZString LOC_CD, NZString LOT_NO)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InventoryOnhandDTO));

            sb.AppendLine(" SELECT TOP 1 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + InventoryOnhandDTO.eColumns.PERIOD_BEGIN_DATE + "=:PERIOD_BEGIN_DATE");
            sb.AppendLine("  AND " + InventoryOnhandDTO.eColumns.PERIOD_END_DATE + "=:PERIOD_END_DATE");
            sb.AppendLine("  AND " + InventoryOnhandDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            sb.AppendLine("  AND " + InventoryOnhandDTO.eColumns.LOC_CD + "=:LOC_CD");
            sb.AppendLine("  AND " + InventoryOnhandDTO.eColumns.LOT_NO + "=:LOT_NO");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("PERIOD_BEGIN_DATE", DataType.DateTime, PERIOD_BEGIN_DATE.Value);
            req.Parameters.Add("PERIOD_END_DATE", DataType.DateTime, PERIOD_END_DATE.Value);
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, ITEM_CD.Value);
            req.Parameters.Add("LOC_CD", DataType.NVarChar, LOC_CD.Value);
            req.Parameters.Add("LOT_NO", DataType.NVarChar, LOT_NO.Value);
            #endregion

            return (db.ExecuteQuery(req).Rows.Count > 0);
        }
        #endregion

        #region Add / Update
        /// <summary>
        /// Check exist before manipulate data. If found record will update data. Otherwise insert new data.
        /// <para>Use key: YearMonth, ItemCode, LocationCode, LotNo</para>
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNewOrUpdate2(Database database, InventoryOnhandDTO data)
        {
            Database db = UseDatabase(database);

            if (Exist(database, data.YEAR_MONTH, data.ITEM_CD, data.LOC_CD, data.LOT_NO))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }
        #endregion

        public int DeleteByItem(Database database, NZString ITEM_CD)
        {
            Database db = UseDatabase(database);
            string sql = @"DELETE FROM TB_INV_ONHAND_TR WHERE ITEM_CD = :ITEM_CD";
            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("ITEM_CD", DataType.VarChar, ITEM_CD.Value);
            return db.ExecuteNonQuery(req);
        }

        public void UpdateStockOnhand(Database database, NZString YEAR_MONTH)
        {
            Database db = UseDatabase(database);

            string strSql = "exec dbo.UpdateStockOnhand :YEAR_MONTH";
            DataRequest req = new DataRequest(strSql);
            req.Parameters.Add("YEAR_MONTH", DataType.NVarChar, YEAR_MONTH.Value);

            db.ExecuteNonQuery(req);
        }

        public List<InventoryOnhandDTO> LoadInvOnhandWithNegativeQty(Database database, NZString YearMonth)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InventoryOnhandDTO));

            // sb.AppendLine(" SET ANSI_NULLS OFF; ");
            sb.AppendLine(" SELECT * ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + InventoryOnhandDTO.eColumns.YEAR_MONTH + "=:YEAR_MONTH");
            sb.AppendLine("  AND " + InventoryOnhandDTO.eColumns.ON_HAND_QTY + "< 0");

            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("YEAR_MONTH", DataType.NVarChar, YearMonth.Value);

            #endregion

            return db.ExecuteForList<InventoryOnhandDTO>(req);
        }

        public List<InventoryOnhandDTO> LoadInvOnhandWithNegativeQty(Database database, NZString YearMonth, NZString Location)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InventoryOnhandDTO));

            // sb.AppendLine(" SET ANSI_NULLS OFF; ");
            sb.AppendLine(" SELECT * ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + InventoryOnhandDTO.eColumns.YEAR_MONTH + "=:YEAR_MONTH");
            sb.AppendLine("  AND " + InventoryOnhandDTO.eColumns.LOC_CD + "=:LOC_CD");
            sb.AppendLine("  AND " + InventoryOnhandDTO.eColumns.ON_HAND_QTY + "< 0");

            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("YEAR_MONTH", DataType.NVarChar, YearMonth.Value);
            req.Parameters.Add("LOC_CD", DataType.NVarChar, Location.Value);

            #endregion

            return db.ExecuteForList<InventoryOnhandDTO>(req);
        }

        public List<InventoryOnhandDTO> LoadInventoryWithYearMonth(Database database, NZString YearMonth)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InventoryOnhandDTO));

            // sb.AppendLine(" SET ANSI_NULLS OFF; ");
            sb.AppendLine(" SELECT * ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + InventoryOnhandDTO.eColumns.YEAR_MONTH + "=:YEAR_MONTH");
            // sb.AppendLine("  AND " + InventoryOnhandDTO.eColumns.ON_HAND_QTY + "< 0");

            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("YEAR_MONTH", DataType.NVarChar, YearMonth.Value);

            #endregion

            return db.ExecuteForList<InventoryOnhandDTO>(req);
        }

        public List<ActualOnhandViewDTO> FifoListingProcess(Database database, string strItemNo, string strLocation, decimal decReqQty, bool bCheckOnhandQty, bool bAllowNegativeOutput)
        {
            Database db = UseDatabase(database);

            DataRequest req = new DataRequest("[dbo].[FIFO_LISTING_PROCESS]");
            req.CommandType = CommandType.StoredProcedure;

            req.Parameters.Add("ItemNo", DataType.NVarChar, strItemNo);
            req.Parameters.Add("Location", DataType.NVarChar, strLocation);
            req.Parameters.Add("ReqQty", DataType.Decimal, decReqQty);
            req.Parameters.Add("bCheckOnHandQty", DataType.Boolean, bCheckOnhandQty);
            req.Parameters.Add("bAllowNegativeOutput", DataType.Boolean, bAllowNegativeOutput);

            return db.ExecuteForList<ActualOnhandViewDTO>(req);
        }

        public void UpdateInventoryOnhand(Database database
            , NZString yearmonth
            //, NZString itemCode, NZString LocationCode, NZString lotNo, NZString inOutClass, NZDecimal Qty
            , InventoryTransactionDTO argTransactionDTO
            , NZString UpdateBy, NZString UpdateMachine, NZDateTime LastReceiveDate, NZDateTime pPeriodStart, NZDateTime pPeriodEnd)
        {
            Database db = UseDatabase(database);
            string sql = @"MERGE dbo.TB_INV_ONHAND_TR as target
                            USING (
	                              SELECT 
		                              :pYEAR_MONTH as YEAR_MONTH
		                              ,:pITEM_CD as ITEM_CD
		                              ,:pLOC_CD as LOC_CD
		                              ,:pLOT_NO as LOT_NO   
                                      ,:pFG_NO as FG_NO  
		                              ,:pPACK_NO as PACK_NO
		                              ,:pIN_OUT_CLS as IN_OUT_CLS
		                              ,(case when :pIN_OUT_CLS = '01' and :pTRANS_TYPE <> '50' then :pQTY else 0 end) as IN_QTY
		                              ,(case when :pIN_OUT_CLS = '02' and :pTRANS_TYPE <> '50' then :pQTY else 0 end) as OUT_QTY
		                              ,(case when :pIN_OUT_CLS = '01' then :pQTY else -:pQTY end) as ON_HAND_QTY
		                              ,(case when :pIN_OUT_CLS = '01' and :pTRANS_TYPE = '50' then :pQTY 
                                            when :pIN_OUT_CLS = '02' and :pTRANS_TYPE = '50' then -:pQTY
                                            else 0 
                                        end) as ADJUST_QTY
		                              --,0 as STOCK_TAKE_QTY
		                              ,:pUPD_BY as UPD_BY
		                              , getdate() as UPD_DATE
		                              ,:pUPD_MACHINE as UPD_MACHINE
		                              ,:pLAST_RECEIVE_DATE as LAST_RECEIVE_DATE
		                              ,:pEXTERNAL_LOT_NO as EXTERNAL_LOT_NO
	                              ) Src
                            on (target.ITEM_CD = src.ITEM_CD and target.LOC_CD = src.LOC_CD and ISNULL(target.LOT_NO,'') =ISNULL(src.LOT_NO,'') and ISNULL(target.PACK_NO,'') =ISNULL(src.PACK_NO,'') and target.YEAR_MONTH = src.YEAR_MONTH )
                            when MATCHED then
                            update set target.IN_QTY = target.IN_QTY + src.IN_QTY
		                              ,target.OUT_QTY = target.OUT_QTY + src.OUT_QTY
		                              ,target.ADJUST_QTY = target.ADJUST_QTY + src.ADJUST_QTY
		                              ,target.ON_HAND_QTY = target.ON_HAND_QTY + src.ON_HAND_QTY
		                              ,target.UPD_BY = src.UPD_BY
		                              ,target.UPD_DATE = src.UPD_DATE
		                              ,target.UPD_MACHINE = src.UPD_MACHINE
		                              ,target.LAST_RECEIVE_DATE = ISNULL(src.LAST_RECEIVE_DATE,target.LAST_RECEIVE_DATE)
		                              ,target.EXTERNAL_LOT_NO = ISNULL(src.EXTERNAL_LOT_NO,target.EXTERNAL_LOT_NO)
                                      ,target.FG_NO = ISNULL(src.FG_NO,target.FG_NO)
                                      ,target.OLD_DATA = 0
                            WHEN NOT MATCHED THEN    
                            INSERT     ([YEAR_MONTH]
                                       ,[PERIOD_BEGIN_DATE]
                                       ,[PERIOD_END_DATE]
                                       ,[ITEM_CD]
                                       ,[LOC_CD]
                                       ,[LOT_NO]
                                       ,[FG_NO]
                                       ,[PACK_NO]
                                       ,[OPEN_QTY]
                                       ,[IN_QTY]
                                       ,[OUT_QTY]
                                       ,[ADJUST_QTY]
                                       ,[STOCK_TAKE_QTY]
                                       ,[ON_HAND_QTY]
                                       ,[CRT_BY]
                                       ,[CRT_DATE]
                                       ,[CRT_MACHINE]
                                       ,[UPD_BY]
                                       ,[UPD_DATE]
                                       ,[UPD_MACHINE]
                                       ,[LAST_RECEIVE_DATE]
                                       ,[EXTERNAL_LOT_NO]
                                       ,[OLD_DATA])
                                 VALUES
                                       (src.YEAR_MONTH
                                       ,:pPeriodStart
                                       ,:pPeriodEnd
                                       ,src.ITEM_CD
                                       ,src.LOC_CD
                                       ,src.LOT_NO
                                       ,src.FG_NO
                                       ,src.PACK_NO
                                       ,0
                                       ,src.IN_QTY
                                       ,src.OUT_QTY
                                       ,src.ADJUST_QTY
                                       ,0--<STOCK_TAKE_QTY, numeric(16,6),>
                                       ,src.ON_HAND_QTY
                                       ,src.UPD_BY
                                       ,src.UPD_DATE
                                       ,src.UPD_MACHINE
                                       ,src.UPD_BY
                                       ,src.UPD_DATE
                                       ,src.UPD_MACHINE
                                       ,src.LAST_RECEIVE_DATE
                                       ,src.EXTERNAL_LOT_NO
                                       ,0);";

            DataRequest req = new DataRequest(sql);
            #region Parameters
            //NZString yearmonth, NZString itemCode, NZString LocationCode, NZString lotNo, NZString inOutClass, NZDecimal Qty, NZString UpdateBy, NZDateTime UpdateMachine, NZDateTime LastReceiveDate, NZDateTime pPeriodStart, NZDateTime pPeriodEnd) {
            req.Parameters.Add("@pYEAR_MONTH", DataType.NVarChar, yearmonth.Value);
            req.Parameters.Add("@pITEM_CD", DataType.NVarChar, argTransactionDTO.ITEM_CD.Value);
            req.Parameters.Add("@pLOC_CD", DataType.NVarChar, argTransactionDTO.LOC_CD.Value);
            //req.Parameters.Add("pLOT_NO", DataType.NVarChar, ((argTransactionDTO.LOT_NO.Value == null || argTransactionDTO.LOT_NO.Value.ToString().Trim() == string.Empty) ? DBNull.Value : argTransactionDTO.LOT_NO.Value));
            req.Parameters.Add("@pLOT_NO", DataType.NVarChar, argTransactionDTO.LOT_NO.Value);
            req.Parameters.Add("@pFG_NO", DataType.NVarChar, argTransactionDTO.FG_NO.Value);
            req.Parameters.Add("@pPACK_NO", DataType.NVarChar, argTransactionDTO.PACK_NO.Value);

            req.Parameters.Add("@pIN_OUT_CLS", DataType.NVarChar, argTransactionDTO.IN_OUT_CLS.Value);
            req.Parameters.Add("@pQTY", DataType.Decimal, argTransactionDTO.QTY.Value);
            req.Parameters.Add("@pUPD_BY", DataType.NVarChar, UpdateBy.Value);
            req.Parameters.Add("@pUPD_MACHINE", DataType.NVarChar, UpdateMachine.Value);
            //req.Parameters.Add("pLAST_RECEIVE_DATE", DataType.DateTime, (LastReceiveDate == null || LastReceiveDate.Value == null ? DBNull.Value : LastReceiveDate.Value));
            req.Parameters.Add("@pLAST_RECEIVE_DATE", DataType.DateTime, LastReceiveDate.Value);

            req.Parameters.Add("@pPeriodStart", DataType.DateTime, pPeriodStart.Value);
            req.Parameters.Add("@pPeriodEnd", DataType.DateTime, pPeriodEnd.Value);

            req.Parameters.Add("@pEXTERNAL_LOT_NO", DataType.NVarChar, argTransactionDTO.EXTERNAL_LOT_NO.Value);
            req.Parameters.Add("@pTRANS_TYPE", DataType.NVarChar, argTransactionDTO.TRANS_CLS.Value);
            #endregion

            db.ExecuteNonQuery(req);
        }

    }
}