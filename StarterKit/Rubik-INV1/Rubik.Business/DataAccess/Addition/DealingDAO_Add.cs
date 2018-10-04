using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Database;
using System.Data;
using EVOFramework;
using Rubik.DTO;

namespace Rubik.DAO
{
    partial class DealingDAO
    {
        public DataTable LoadByLocationType(Database database, NZString[] LocationType, NZString[] ExceptLocation, bool IncludeOldData)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(DealingDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + DealingDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + DealingDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + DealingDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + DealingDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + DealingDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + DealingDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + DealingDTO.eColumns.LOC_CD);
            sb.AppendLine("  ," + DealingDTO.eColumns.LOC_DESC);
            sb.AppendLine("  ," + DealingDTO.eColumns.LOC_CLS);
            sb.AppendLine("  ," + DealingDTO.eColumns.ADDRESS1);
            sb.AppendLine("  ," + DealingDTO.eColumns.TEL1);
            sb.AppendLine("  ," + DealingDTO.eColumns.FAX1);
            sb.AppendLine("  ," + DealingDTO.eColumns.EMAIL1);
            sb.AppendLine("  ," + DealingDTO.eColumns.CONTACT_PERSON1);
            sb.AppendLine("  ," + DealingDTO.eColumns.REMARK1);
            sb.AppendLine("  ," + DealingDTO.eColumns.ADDRESS2);
            sb.AppendLine("  ," + DealingDTO.eColumns.TEL2);
            sb.AppendLine("  ," + DealingDTO.eColumns.FAX2);
            sb.AppendLine("  ," + DealingDTO.eColumns.EMAIL2);
            sb.AppendLine("  ," + DealingDTO.eColumns.CONTACT_PERSON2);
            sb.AppendLine("  ," + DealingDTO.eColumns.REMARK2);
            sb.AppendLine("  ," + DealingDTO.eColumns.ADDRESS3);
            sb.AppendLine("  ," + DealingDTO.eColumns.TEL3);
            sb.AppendLine("  ," + DealingDTO.eColumns.FAX3);
            sb.AppendLine("  ," + DealingDTO.eColumns.EMAIL3);
            sb.AppendLine("  ," + DealingDTO.eColumns.CONTACT_PERSON3);
            sb.AppendLine("  ," + DealingDTO.eColumns.REMARK3);
            sb.AppendLine("  ," + DealingDTO.eColumns.ALLOW_NEGATIVE);
            sb.AppendLine("  ," + DealingDTO.eColumns.OLD_DATA);
            sb.AppendLine(" FROM " + tableName);

            if (!IncludeOldData)
                sb.AppendLine(" WHERE ISNULL(" + DealingDTO.eColumns.OLD_DATA + ",0)= 0");
            else
                sb.AppendLine(" WHERE 1 = 1");

            if (LocationType != null && LocationType.Length > 0)
            {
                sb.AppendLine(" AND " + DealingDTO.eColumns.LOC_CLS + " IN (");

                for (int i = 0; i < LocationType.Length; i++)
                {
                    sb.AppendLine("'" + LocationType[i].StrongValue + "'");

                    if (i < LocationType.Length - 1)
                        sb.AppendLine(", ");
                }

                sb.AppendLine(" )");
            }

            if (ExceptLocation != null && ExceptLocation.Length > 0) {
                sb.AppendLine(" AND " + DealingDTO.eColumns.LOC_CD + " NOT IN (");

                for (int i = 0; i < ExceptLocation.Length; i++) {
                    sb.AppendLine("'" + ExceptLocation[i].StrongValue + "'");

                    if (i < ExceptLocation.Length - 1)
                        sb.AppendLine(", ");
                }

                sb.AppendLine(" )");
            }

            

            sb.AppendLine(" ORDER BY ORDER_SEQ");

            #endregion

            DataRequest req = new DataRequest(sb.ToString());

            return db.ExecuteQuery(req);
        }

        public DataTable LoadByLocationType(Database database, NZString MasterNo, NZString[] ExceptLocation, bool IncludeOldData) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableNameDealing = EVOFramework.Data.DTOUtility.ReadTableName(typeof(DealingDTO));
            string tableNameItemProcess = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ItemProcessDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  DL." + DealingDTO.eColumns.CRT_BY);
            sb.AppendLine("  ,DL." + DealingDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ,DL." + DealingDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ,DL." + DealingDTO.eColumns.UPD_BY);
            sb.AppendLine("  ,DL." + DealingDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ,DL." + DealingDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ,DL." + DealingDTO.eColumns.LOC_CD);
            sb.AppendLine("  ,DL." + DealingDTO.eColumns.LOC_DESC);
            sb.AppendLine("  ,DL." + DealingDTO.eColumns.LOC_CLS);
            sb.AppendLine("  ,DL." + DealingDTO.eColumns.ADDRESS1);
            sb.AppendLine("  ,DL." + DealingDTO.eColumns.TEL1);
            sb.AppendLine("  ,DL." + DealingDTO.eColumns.FAX1);
            sb.AppendLine("  ,DL." + DealingDTO.eColumns.EMAIL1);
            sb.AppendLine("  ,DL." + DealingDTO.eColumns.CONTACT_PERSON1);
            sb.AppendLine("  ,DL." + DealingDTO.eColumns.REMARK1);
            sb.AppendLine("  ,DL." + DealingDTO.eColumns.ADDRESS2);
            sb.AppendLine("  ,DL." + DealingDTO.eColumns.TEL2);
            sb.AppendLine("  ,DL." + DealingDTO.eColumns.FAX2);
            sb.AppendLine("  ,DL." + DealingDTO.eColumns.EMAIL2);
            sb.AppendLine("  ,DL." + DealingDTO.eColumns.CONTACT_PERSON2);
            sb.AppendLine("  ,DL." + DealingDTO.eColumns.REMARK2);
            sb.AppendLine("  ,DL." + DealingDTO.eColumns.ADDRESS3);
            sb.AppendLine("  ,DL." + DealingDTO.eColumns.TEL3);
            sb.AppendLine("  ,DL." + DealingDTO.eColumns.FAX3);
            sb.AppendLine("  ,DL." + DealingDTO.eColumns.EMAIL3);
            sb.AppendLine("  ,DL." + DealingDTO.eColumns.CONTACT_PERSON3);
            sb.AppendLine("  ,DL." + DealingDTO.eColumns.REMARK3);
            sb.AppendLine("  ,DL." + DealingDTO.eColumns.ALLOW_NEGATIVE);
            sb.AppendLine("  ,DL." + DealingDTO.eColumns.OLD_DATA);
            sb.AppendLine(" FROM " + tableNameItemProcess + " IP");
            sb.AppendLine(" LEFT JOIN " + tableNameDealing + " DL ON IP." + ItemProcessDTO.eColumns.PROCESS_CD + " = " + DealingDTO.eColumns.LOC_CD);

            if (!IncludeOldData)
                sb.AppendLine(" WHERE ISNULL(IP." + DealingDTO.eColumns.OLD_DATA + ",0)= 0");
            else
                sb.AppendLine(" WHERE 1 = 1");

            sb.AppendLine(" AND IP." + ItemProcessDTO.eColumns.ITEM_CD + " = " + MasterNo.StrongValue);

            //if (LocationType != null && LocationType.Length > 0) {
            //    sb.AppendLine(" AND " + DealingDTO.eColumns.LOC_CLS + " IN (");

            //    for (int i = 0; i < LocationType.Length; i++) {
            //        sb.AppendLine("'" + LocationType[i].StrongValue + "'");

            //        if (i < LocationType.Length - 1)
            //            sb.AppendLine(", ");
            //    }

            //    sb.AppendLine(" )");
            //}

            if (ExceptLocation != null && ExceptLocation.Length > 0) {
                sb.AppendLine(" AND " + DealingDTO.eColumns.LOC_CD + " NOT IN (");

                for (int i = 0; i < ExceptLocation.Length; i++) {
                    sb.AppendLine("'" + ExceptLocation[i].StrongValue + "'");

                    if (i < ExceptLocation.Length - 1)
                        sb.AppendLine(", ");
                }

                sb.AppendLine(" )");
            }



            sb.AppendLine(" ORDER BY DL.ORDER_SEQ");

            #endregion

            DataRequest req = new DataRequest(sb.ToString());

            return db.ExecuteQuery(req);
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<DealingDTO> LoadAllWithLimit(Database database, bool ascending, params DealingDTO.eColumns[] orderByColumns)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(DealingDTO));

            sb.AppendLine(@" SELECT TOP (SELECT CONVERT(INT,CHAR_DATA)
                              FROM TZ_SYS_CONFIG
                              WHERE SYS_GROUP_ID = 'LOAD_LIMIT'
                              AND SYS_KEY = 'MAS010')");
            sb.AppendLine("  " + DealingDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + DealingDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + DealingDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + DealingDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + DealingDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + DealingDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + DealingDTO.eColumns.LOC_CD);
            sb.AppendLine("  ," + DealingDTO.eColumns.LOC_DESC);
            sb.AppendLine("  ," + DealingDTO.eColumns.LOC_CLS);
            sb.AppendLine("  ," + DealingDTO.eColumns.ADDRESS1);
            sb.AppendLine("  ," + DealingDTO.eColumns.TEL1);
            sb.AppendLine("  ," + DealingDTO.eColumns.FAX1);
            sb.AppendLine("  ," + DealingDTO.eColumns.EMAIL1);
            sb.AppendLine("  ," + DealingDTO.eColumns.CONTACT_PERSON1);
            sb.AppendLine("  ," + DealingDTO.eColumns.REMARK1);
            sb.AppendLine("  ," + DealingDTO.eColumns.ADDRESS2);
            sb.AppendLine("  ," + DealingDTO.eColumns.TEL2);
            sb.AppendLine("  ," + DealingDTO.eColumns.FAX2);
            sb.AppendLine("  ," + DealingDTO.eColumns.EMAIL2);
            sb.AppendLine("  ," + DealingDTO.eColumns.CONTACT_PERSON2);
            sb.AppendLine("  ," + DealingDTO.eColumns.REMARK2);
            sb.AppendLine("  ," + DealingDTO.eColumns.ADDRESS3);
            sb.AppendLine("  ," + DealingDTO.eColumns.TEL3);
            sb.AppendLine("  ," + DealingDTO.eColumns.FAX3);
            sb.AppendLine("  ," + DealingDTO.eColumns.EMAIL3);
            sb.AppendLine("  ," + DealingDTO.eColumns.CONTACT_PERSON3);
            sb.AppendLine("  ," + DealingDTO.eColumns.REMARK3);
            sb.AppendLine("  ," + DealingDTO.eColumns.ALLOW_NEGATIVE);
            sb.AppendLine("  ," + DealingDTO.eColumns.OLD_DATA);

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

            return db.ExecuteForList<DealingDTO>(req);
        }

        public DataTable LoadDealingList(Database database , bool bIncludeOldData) 
        {
            Database db = UseDatabase(database);
            
            DataRequest req = new DataRequest("S_MAS010_LoadDealingList");
            req.CommandType = CommandType.StoredProcedure;
            if (!bIncludeOldData)
                req.Parameters.Add("@pInt_OldData", 0);

            return db.ExecuteQuery(req);
        }
    }
}
