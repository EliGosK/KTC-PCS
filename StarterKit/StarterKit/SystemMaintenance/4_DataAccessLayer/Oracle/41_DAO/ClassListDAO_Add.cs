using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemMaintenance.DTO;
using EVOFramework.Database;
using EVOFramework;

namespace SystemMaintenance.Oracle.DAO
{
    partial class ClassListDAO
    {
        /// <summary>
        /// Load all ClassType where condition at CLS_INFO_CD.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="CLS_INFO_CD"></param>
        /// <returns></returns>
        public List<ClassListDTO> LoadByClassInfo(Database database, NZString CLS_INFO_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ClassListDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + ClassListDTO.eColumns.CLS_INFO_CD);
            sb.AppendLine("  ," + ClassListDTO.eColumns.CLS_CD);
            sb.AppendLine("  ," + ClassListDTO.eColumns.CLS_DESC);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ClassListDTO.eColumns.CLS_INFO_CD + "=:CLS_INFO_CD");
            sb.AppendLine(" ORDER BY " + ClassListDTO.eColumns.CLS_CD);
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("CLS_INFO_CD", DataType.VarChar, CLS_INFO_CD.Value);
            #endregion

            List<ClassListDTO> list = db.ExecuteForList<ClassListDTO>(req);
            return list;
        }
    }
}
