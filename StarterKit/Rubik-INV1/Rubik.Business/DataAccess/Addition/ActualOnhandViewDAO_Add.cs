using System;
using System.Collections.Generic;
using System.Text;
using Rubik.DTO;
using EVOFramework.Database;
using EVOFramework;
using Rubik.DAO;
using System.Data;

namespace Rubik.DAO
{
    internal partial class ActualOnhandViewDAO
    {
        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ITEM_CD">Key #1</param>
        /// <param name="LOC_CD">Key #2</param>
        /// <param name="LOT_NO">Key #3</param>
        /// <returns></returns>
        public ActualOnhandViewDTO LoadByPK(Database database, NZString ITEM_CD, NZString LOC_CD, NZString LOT_NO)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ActualOnhandViewDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + ActualOnhandViewDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + ActualOnhandViewDTO.eColumns.LOC_CD);
            sb.AppendLine("  ," + ActualOnhandViewDTO.eColumns.LOT_NO);
            sb.AppendLine("  ," + ActualOnhandViewDTO.eColumns.ONHAND_QTY);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ActualOnhandViewDTO.eColumns.ITEM_CD + "=:ITEM_CD");
            sb.AppendLine("  AND " + ActualOnhandViewDTO.eColumns.LOC_CD + "=:LOC_CD");
            sb.AppendLine("  AND ISNULL(" + ActualOnhandViewDTO.eColumns.LOT_NO + ",' ')= ISNULL(:LOT_NO,' ') ");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("ITEM_CD", DataType.NVarChar, ITEM_CD.Value);
            req.Parameters.Add("LOC_CD", DataType.NVarChar, LOC_CD.Value);
            req.Parameters.Add("LOT_NO", DataType.NVarChar, LOT_NO.Value);
            #endregion

            List<ActualOnhandViewDTO> list = db.ExecuteForList<ActualOnhandViewDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }


        public DataTable CheckUnpackInventory(Database database, NZString GroupTransID)
        {
            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_TRN310_CheckUnpackInventory";
            req.CommandType = CommandType.StoredProcedure;
            #region Parameters
            req.Parameters.Add("@GroupTransID", DataType.NVarChar, GroupTransID.Value);
            #endregion

            DataSet ds = db.ExecuteDataSet(req);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }

            return null;
        }
    }
}
