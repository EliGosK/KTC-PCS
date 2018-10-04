using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Database;
using Rubik.DTO;
using EVOFramework;
using System.Data;

namespace Rubik.DAO
{
    partial class SalesUnitPriceDAO
    {

        #region Load Data

        public List<SalesUnitPriceDTO> LoadAllWithLimit(Database database, bool ascending, params SalesUnitPriceDTO.eColumns[] orderByColumns)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(SalesUnitPriceDTO));

            sb.AppendLine(@" SELECT TOP (SELECT CONVERT(INT,CHAR_DATA)
                              FROM TZ_SYS_CONFIG
                              WHERE SYS_GROUP_ID = 'LOAD_LIMIT'
                              AND SYS_KEY = 'MAS010')");
            sb.AppendLine("  " + SalesUnitPriceDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.START_EFFECTIVE_DATE);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.PRICE);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.CURRENCY);
            sb.AppendLine("  ," + SalesUnitPriceDTO.eColumns.REMARK);
            sb.AppendLine(" FROM " + tableName);

            if (orderByColumns != null && orderByColumns.Length > 0)
            {
                sb.AppendLine(" ORDER BY ");
                string sort = ascending ? "asc" : "desc";

                for (int i = 0; i < orderByColumns.Length; i++)
                {
                    if (i == 0)
                        sb.AppendLine(String.Format("   {0} {1}", orderByColumns[i], sort));
                    else
                        sb.AppendLine(String.Format("   ,{0} {1}", orderByColumns[i], sort));
                }
            }

            #endregion

            DataRequest req = new DataRequest(sb.ToString());

            return db.ExecuteForList<SalesUnitPriceDTO>(req);
        }

        public DataTable LoadSalesUnitPriceList(Database database, bool includeOldData, DateTime? priceOnDate)
        {
            Database db = UseDatabase(database);

            string strSQL = "S_MAS110_LoadSalesUnitPriceList";
            DataRequest req = new DataRequest(strSQL);
            req.CommandType = CommandType.StoredProcedure;
            if (priceOnDate != null)
                req.Parameters.Add("@pDtm_PriceOnDate", DataType.DateTime, priceOnDate);
            if (!includeOldData)
                req.Parameters.Add("@pInt_OldData", DataType.NVarChar, 0);  //0:New Data

            return db.ExecuteQuery(req);
        }

        public SalesUnitPriceDTO LoadSalesUnitPriceByPK(Database database, NZString ITEM_CD, NZDateTime START_EFFECTIVE_DATE, NZString CURRENCY)
        {
            Database db = UseDatabase(database);

            DataRequest req = new DataRequest("S_MAS120_LoadSalesUnitPriceByPK");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_ItemCD", DataType.NVarChar, ITEM_CD.Value);
            req.Parameters.Add("@pDtm_StartEffectiveDate", DataType.DateTime, ((DateTime)START_EFFECTIVE_DATE.Value).Date);
            req.Parameters.Add("@pVar_Currency", DataType.NVarChar, CURRENCY.Value);

            List<SalesUnitPriceDTO> list = db.ExecuteForList<SalesUnitPriceDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }

        public SalesUnitPriceDTO getSalesUnitPriceByEffectiveDate(Database database, NZString ITEM_CD, NZString CURRENCY, NZDateTime START_EFFECTIVE_DATE)
        {
            Database db = UseDatabase(database);

            DataRequest req = new DataRequest("S_MAS120_LoadSalesUnitPriceByEffectiveDate");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_ItemCD", DataType.NVarChar, ITEM_CD.Value);
            req.Parameters.Add("@pDtm_StartEffectiveDate", DataType.DateTime, ((DateTime)START_EFFECTIVE_DATE.Value).Date);
            req.Parameters.Add("@pVar_Currency", DataType.NVarChar, CURRENCY.Value);

            List<SalesUnitPriceDTO> list = null;

            try
            {
                list = db.ExecuteForList<SalesUnitPriceDTO>(req);
            }
            catch
            {
                return null;

            }
            if (list != null && list.Count > 0)
                return list[0];

            return null;

        }

        #endregion

        #region Exists

        public bool Exist(Database database, NZString ITEM_CD, NZDateTime START_EFFECTIVE_DATE, NZString CURRENCY)
        {
            Database db = UseDatabase(database);

            DataRequest req = new DataRequest("S_MAS120_CheckExistsSalesUnitPrice");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_ItemCD", DataType.NVarChar, ITEM_CD.Value);
            req.Parameters.Add("@pDtm_StartEffectiveDate", DataType.DateTime, ((DateTime)START_EFFECTIVE_DATE.Value).Date);
            req.Parameters.Add("@pVar_Currency", DataType.NVarChar, CURRENCY.Value);

            return (db.ExecuteQuery(req).Rows.Count > 0);
        }

        #endregion

        #region Operation

        public int Delete(Database database, NZString ITEM_CD, NZDateTime START_EFFECTIVE_DATE, NZString CURRENCY)
        {
            Database db = UseDatabase(database);

            DataRequest req = new DataRequest("S_MAS120_DeleteSalesUnitPrice");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_ItemCD", DataType.NVarChar, ITEM_CD.Value);
            req.Parameters.Add("@pDtm_StartEffectiveDate", DataType.DateTime, START_EFFECTIVE_DATE.Value);
            req.Parameters.Add("@pVar_Currency", DataType.NVarChar, CURRENCY.Value);

            return db.ExecuteNonQuery(req);
        }

        #endregion
    }
}
