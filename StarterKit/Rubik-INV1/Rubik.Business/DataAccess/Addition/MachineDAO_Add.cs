using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EVOFramework.Database;
using Rubik.DTO;

namespace Rubik.DAO
{
    partial class MachineDAO
    {
        public DataTable LoadLookupTextHelper(Database database, string TableName,string ColumnName) 
        {
            Database db = UseDatabase(database);
            string sql = string.Format(@"SELECT DISTINCT {0} FROM {1} WHERE {0} IS NOT NULL", ColumnName , TableName);
            DataRequest req = new DataRequest(sql);
            return db.ExecuteQuery(req);
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<MachineDTO> LoadAllWithLimit(Database database, bool ascending, params MachineDTO.eColumns[] orderByColumns) 
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(MachineDTO));

            sb.AppendLine(@" SELECT TOP (SELECT CONVERT(INT,CHAR_DATA)
                              FROM TZ_SYS_CONFIG
                              WHERE SYS_GROUP_ID = 'LOAD_LIMIT'
                              AND SYS_KEY = 'MAS010')");
            sb.AppendLine("  " + MachineDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + MachineDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + MachineDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + MachineDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + MachineDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + MachineDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + MachineDTO.eColumns.MACHINE_CD);
            sb.AppendLine("  ," + MachineDTO.eColumns.MACHINE_TYPE);
            sb.AppendLine("  ," + MachineDTO.eColumns.PROCESS_CD);
            sb.AppendLine("  ," + MachineDTO.eColumns.MACHINE_GROUP);
            sb.AppendLine("  ," + MachineDTO.eColumns.PROJECT);
            sb.AppendLine("  ," + MachineDTO.eColumns.REMARK);

            sb.AppendLine(" FROM " + tableName);

            if (orderByColumns != null && orderByColumns.Length > 0) {
                sb.AppendLine(" ORDER BY ");
                string sort = ascending ? "asc" : "desc";

                for (int i = 0; i < orderByColumns.Length; i++) {
                    if (i == 0)
                        sb.AppendLine(String.Format("   {0} {1}", orderByColumns[i], sort));
                    else
                        sb.AppendLine(String.Format("   ,{0} {1}", orderByColumns[i], sort));
                }
            }
            #endregion

            DataRequest req = new DataRequest(sb.ToString());

            return db.ExecuteForList<MachineDTO>(req);
        }


        public DataTable LoadMachineList(Database database, bool bIncludeOldData) 
        {
            Database db = UseDatabase(database);
            DataRequest req = new DataRequest("S_MAS130_LoadMachineList");
            req.CommandType = CommandType.StoredProcedure;
            if (!bIncludeOldData)
                req.Parameters.Add("@pInt_OldData", 0);

            return db.ExecuteQuery(req);
        }

        public DataTable LoadMachineGroup(Database database) 
        {
            Database db = UseDatabase(database);
            DataRequest req = new DataRequest("S_COMMON_LoadMachineGroup");
            req.CommandType = CommandType.StoredProcedure;
            return db.ExecuteQuery(req);
        }

        public DataTable LoadMachineGroupOfProcess(Database database, string Process)
        {
            Database db = UseDatabase(database);
            DataRequest req = new DataRequest("S_COMMON_LoadMachineGroupOfProcess");
            req.Parameters.Add("@pVar_ProcessCD", DataType.NVarChar, Process);
            req.CommandType = CommandType.StoredProcedure;
            return db.ExecuteQuery(req);
        }

        public DataTable LoadMachineByProcess(Database database, string ItemCD, string Process, bool IncludeOldData) 
        {
            DataTable dt = null;

            Database db = UseDatabase(database);
            DataRequest req = new DataRequest("S_COMMON_LoadMachineOfProcess");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_ItemCD", DataType.NVarChar, ItemCD);
            req.Parameters.Add("@pVar_ProcessCD", DataType.NVarChar, Process);
            if (!IncludeOldData)
                req.Parameters.Add("@pInt_OldData", DataType.Int16, 0);
            dt = db.ExecuteQuery(req);
            return dt;

            //DataTable dt = null;
            
            //Database db = UseDatabase(database);
            //DataRequest req = new DataRequest("S_COMMON_LoadMachineByProcess");
            //req.CommandType = CommandType.StoredProcedure;
            //req.Parameters.Add("@pVar_Process", DataType.NVarChar, Process);
            //if (!IncludeOldData)
            //    req.Parameters.Add("@pInt_OldData", DataType.Int16, 0);
            //dt = db.ExecuteQuery(req);
            //return dt;
        }

        public DataTable LoadMachine(Database database, bool IncludeOldData) {
            DataTable dt = null;

            Database db = UseDatabase(database);
            DataRequest req = new DataRequest("S_COMMON_LoadMachine");
            req.CommandType = CommandType.StoredProcedure;
            if (!IncludeOldData)
                req.Parameters.Add("@pInt_OldData", DataType.Int16, 0);
            dt = db.ExecuteQuery(req);
            return dt;
        }
    }
}
