/* Create by: Ms. Sansanee K.
 * Create on: 2012-03-05
 * Company: CSI Groups (Thailand)
 * Group: SI-EVO
 
 *** This generate source code was build for DAO on StarterKit system. ***/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using EVOFramework.Database;
using Rubik.DTO;

namespace Rubik.DAO
{
    internal partial class DealingConstraintDAO
    {

        public List<DealingConstraintDTO> LoadByConstraint(Database database, NZString ConstraintName, NZInt ConstraintFlag)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(DealingConstraintDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + DealingConstraintDTO.eColumns.LOC_CD);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.NO_CONSUMPTION_FLAG);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.COMPONENT_ITEM_USAGE);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.ENABLE_SUPPLIER_FLAG);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.ENABLE_LOT_FLAG);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.ENABLE_PACK_FLAG);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.ENABLE_CUST_LOT_FLAG);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.NO_MOVE_FLAG);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.NO_PRODUCTION_REPORT_FLAG);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.NO_NG_CONSUMPTION_FLAG);
            sb.AppendLine("  ," + DealingConstraintDTO.eColumns.LOT_CONTROL_FLAG);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ConstraintName.Value + "=@CONSTRAINT_FLAG");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            //req.Parameters.Add("@CONSTRAINT_NAME", DataType.NVarChar, ConstraintName.Value);
            req.Parameters.Add("@CONSTRAINT_FLAG", DataType.NVarChar, ConstraintFlag.Value);
            #endregion

            List<DealingConstraintDTO> list = db.ExecuteForList<DealingConstraintDTO>(req);

            return list;
        }

    }
}

