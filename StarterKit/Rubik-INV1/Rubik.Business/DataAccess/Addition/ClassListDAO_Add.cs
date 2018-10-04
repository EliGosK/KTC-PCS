using System.Collections.Generic;
using System.Text;
using EVOFramework.Database;
using Rubik.DTO;
using EVOFramework;

namespace Rubik.DAO {
    partial class ClassListDAO {
        /// <summary>
        /// Load all ClassType where condition at CLS_INFO_CD.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="CLS_INFO_CD"></param>
        /// <returns></returns>
        public List<ClassListDTO> LoadByClassInfo(Database database, NZString CLS_INFO_CD) {
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
            sb.AppendLine(" ORDER BY " + ClassListDTO.eColumns.SEQ + ", " + ClassListDTO.eColumns.CLS_CD);
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("CLS_INFO_CD", DataType.VarChar, CLS_INFO_CD.Value);
            #endregion

            List<ClassListDTO> list = db.ExecuteForList<ClassListDTO>(req);
            return list;
        }

        /// <summary>
        /// Load all ClassType where condition at CLS_INFO_CD and CLS_CD
        /// </summary>
        /// <param name="database"></param>
        /// <param name="CLS_INFO_CD"></param>
        /// <param name="CLS_CD"></param>
        /// <returns></returns>
        public List<ClassListDTO> LoadByClassInfo(Database database, NZString CLS_INFO_CD, NZString[] CLS_CD) {
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

            if (CLS_CD != null && CLS_CD.Length > 0) {
                sb.AppendLine(" AND CLS_CD IN (");

                for (int i = 0; i < CLS_CD.Length; i++) {
                    sb.AppendLine("'" + CLS_CD[i].StrongValue + "'");

                    if (i < CLS_CD.Length - 1)
                        sb.AppendLine(", ");
                }

                sb.AppendLine(" )");
            }
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
