using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using EVOFramework.Database;
using Rubik.DTO;

namespace Rubik.DAO
{
    internal partial class InventoryPeriodDAO
    {
        public InventoryPeriodDTO LoadCurrentYearMonth(Database database)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InventoryPeriodDTO));
            sb.AppendLine(" SELECT TOP 1 ");
            sb.AppendLine("  " + InventoryPeriodDTO.eColumns.YEAR_MONTH);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.PERIOD_BEGIN_DATE);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.PERIOD_END_DATE);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.UPD_MACHINE);
            sb.AppendLine(" FROM " + tableName);

            DataRequest req = new DataRequest(sb.ToString());

            List<InventoryPeriodDTO> list = db.ExecuteForList<InventoryPeriodDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }

        public InventoryPeriodDTO LoadCurrentPeriodWithQueryRange(Database database)
        {
            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_InventoryPeriodWithQueryRange";
            req.CommandType = System.Data.CommandType.StoredProcedure;

            List<InventoryPeriodDTO> list = db.ExecuteForList<InventoryPeriodDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }
        public InventoryPeriodDTO LoadPeriodByDate(Database database, NZDateTime date)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InventoryPeriodDTO));
            sb.AppendLine(" SELECT TOP 1 ");
            sb.AppendLine("  " + InventoryPeriodDTO.eColumns.YEAR_MONTH);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.PERIOD_BEGIN_DATE);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.PERIOD_END_DATE);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + InventoryPeriodDTO.eColumns.UPD_MACHINE);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  :DATE BETWEEN " + InventoryOnhandDTO.eColumns.PERIOD_BEGIN_DATE);
            sb.AppendLine("      AND " + InventoryOnhandDTO.eColumns.PERIOD_END_DATE);
            sb.AppendLine(" ORDER BY " + InventoryOnhandDTO.eColumns.YEAR_MONTH);

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("DATE", DataType.DateTime, date.Value);

            List<InventoryPeriodDTO> list = db.ExecuteForList<InventoryPeriodDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;

        }

        /// <summary>
        /// This function simulate and get data of next period following etype Rolling up, Rolling Down
        /// in case of Rolling up  next Period record
        /// else previous period record
        /// </summary>
        /// <param name="database"></param>
        /// <param name="eType"></param>
        /// <returns></returns>
        public InventoryPeriodDTO GetNextPeriodRecord(Database database, eMonthlyCloseProcess eType)
        {
            Database db = UseDatabase(database);

            string sql = @"select		   top 1
		                                   LEFT(CONVERT(nvarchar,DATEADD(m,:incMonth,CONVERT(date,[YEAR_MONTH] + '01' ,112)),112),6) as [YEAR_MONTH]
		                                  ,DATEADD(m,:incMonth,CONVERT(date,[YEAR_MONTH] + '01' ,112)) AS [PERIOD_BEGIN_DATE]
		                                  ,dateadd(d,-1,DATEADD(m,1 + :incMonth,CONVERT(date,[YEAR_MONTH] + '01' ,112))) as  [PERIOD_END_DATE]
		                                  ,p.CRT_BY
		                                  ,p.CRT_DATE
		                                  ,p.CRT_MACHINE
		                                  ,p.UPD_BY
		                                  ,p.UPD_DATE
		                                  ,p.UPD_MACHINE
                            from TB_INV_PERIOD_MS p";

            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("incMonth", DataType.Number, (eType == eMonthlyCloseProcess.ROLLING_UP ? 1 : -1));

            List<InventoryPeriodDTO> list = db.ExecuteForList<InventoryPeriodDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;

        }


        public int UpdateInventoryPeriod(Database database, InventoryPeriodDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" update TB_INV_PERIOD_MS ");
            sb.AppendLine(" set YEAR_MONTH = :pYEAR_MONTH ");
            sb.AppendLine("     ,PERIOD_BEGIN_DATE = :pPERIOD_BEGIN_DATE ");
            sb.AppendLine("     ,PERIOD_END_DATE = :pPERIOD_END_DATE ");
            sb.AppendLine("     ,UPD_BY =:pUPD_BY ");
            sb.AppendLine("     ,UPD_DATE = getdate() ");
            sb.AppendLine("     ,UPD_MACHINE = :pUPD_MACHINE; ");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("pYEAR_MONTH", DataType.NVarChar, data.YEAR_MONTH.Value);
            req.Parameters.Add("pPERIOD_BEGIN_DATE", DataType.DateTime, data.PERIOD_BEGIN_DATE.Value);
            req.Parameters.Add("pPERIOD_END_DATE", DataType.DateTime, data.PERIOD_END_DATE.Value);
            req.Parameters.Add("pUPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("pUPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);

            return db.ExecuteNonQuery(req);
        }
    }
}
