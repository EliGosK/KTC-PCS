using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemMaintenance.DTO;
using EVOFramework.Database;
using EVOFramework;

namespace SystemMaintenance.SQLServer.DAO
{
    internal partial class RunningNumberDAO
    {
        /// <summary>
        /// Step up Next Value for running number
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int SetNextRunningNoValue(Database database, RunningNumberDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            //sb.AppendLine("  " + RunningNumberDTO.eColumns.DESCRIPTION + "=:DESCRIPTION");
            //sb.AppendLine("  ," + RunningNumberDTO.eColumns.FORMAT + "=:FORMAT");
            sb.AppendLine("  " + RunningNumberDTO.eColumns.NEXTVALUE + "=:NEXTVALUE");
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.LAST_RESET + "=:LAST_RESET");
            //sb.AppendLine("  ," + RunningNumberDTO.eColumns.RESET_FLAG_DAY + "=:RESET_FLAG_DAY");
            //sb.AppendLine("  ," + RunningNumberDTO.eColumns.RESET_FLAG_MONTH + "=:RESET_FLAG_MONTH");
            //sb.AppendLine("  ," + RunningNumberDTO.eColumns.RESET_FLAG_YEAR + "=:RESET_FLAG_YEAR");
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.UPD_BY + "=:UPD_BY");
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.UPD_MACHINE + "=:UPD_MACHINE");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + RunningNumberDTO.eColumns.ID_NAME + "=:ID_NAME");
            sb.AppendLine("  AND " + RunningNumberDTO.eColumns.TB_NAME + "=:TB_NAME");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("ID_NAME", DataType.VarChar, data.ID_NAME.Value);
            req.Parameters.Add("TB_NAME", DataType.VarChar, data.TB_NAME.Value);
            //req.Parameters.Add("DESCRIPTION", DataType.VarChar, data.DESCRIPTION.Value);
            //req.Parameters.Add("FORMAT", DataType.VarChar, data.FORMAT.Value);
            req.Parameters.Add("NEXTVALUE", DataType.Number, data.NEXTVALUE.Value);
            req.Parameters.Add("LAST_RESET", DataType.DateTime, data.LAST_RESET.Value);
            //req.Parameters.Add("RESET_FLAG_DAY", DataType.Default, data.RESET_FLAG_DAY.Value);
            //req.Parameters.Add("RESET_FLAG_MONTH", DataType.Default, data.RESET_FLAG_MONTH.Value);
            //req.Parameters.Add("RESET_FLAG_YEAR", DataType.Default, data.RESET_FLAG_YEAR.Value);
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ID_NAME">Key #1</param>
        /// <param name="TB_NAME">Key #2</param>
        /// <returns></returns>
        public RunningNumberDTO LoadByPK_UPDLock(Database database, NZString ID_NAME, NZString TB_NAME)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(RunningNumberDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + RunningNumberDTO.eColumns.ID_NAME);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.TB_NAME);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.DESCRIPTION);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.FORMAT);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.NEXTVALUE);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.LAST_RESET);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.RESET_FLAG_DAY);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.RESET_FLAG_MONTH);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.RESET_FLAG_YEAR);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + RunningNumberDTO.eColumns.UPD_MACHINE);
            sb.AppendLine(" FROM " + tableName + " WITH (UPDLOCK) ");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + RunningNumberDTO.eColumns.ID_NAME + "=:ID_NAME");
            sb.AppendLine("  AND " + RunningNumberDTO.eColumns.TB_NAME + "=:TB_NAME");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("ID_NAME", DataType.VarChar, ID_NAME.Value);
            req.Parameters.Add("TB_NAME", DataType.VarChar, TB_NAME.Value);
            #endregion

            List<RunningNumberDTO> list = db.ExecuteForList<RunningNumberDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }

        public NZString GenerateLotNoPrefix(NZDateTime LotDate)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select dbo.GenerateLotNoPrefix(:Date)");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("Date", DataType.DateTime, LotDate.Value);

            return new NZString(null, m_db.ExecuteScalar(req));
        }

        public NZInt GetLastLotNoRunningBox(NZString strLotNoPrefix, NZString strLocationCode, NZString strItemCode, NZInt ReuseZeroQty)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select dbo.GetLastLotNoRunningBox(:LotNoPrefix,:LocationCode,:ItemCode,:ReuseZeroQty)");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("LotNoPrefix", DataType.VarChar, strLotNoPrefix.Value);
            req.Parameters.Add("LocationCode", DataType.VarChar, strLocationCode.Value);
            req.Parameters.Add("ItemCode", DataType.VarChar, strItemCode.Value);
            req.Parameters.Add("ReuseZeroQty", DataType.Int32, ReuseZeroQty.Value);

            return new NZInt(null, m_db.ExecuteScalar(req));
        }
    }
}
