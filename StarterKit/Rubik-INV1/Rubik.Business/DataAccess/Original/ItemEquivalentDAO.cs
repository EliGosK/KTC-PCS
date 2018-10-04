
using System.Text;
using EVOFramework;
using EVOFramework.Database;
using System.Data;
using Rubik.DTO;
using System.Collections.Generic;

namespace Rubik.DAO
{
    partial class ItemEquivalentDAO : BaseDAO
    {

        public int AddNew(Database database, ItemEquivalentDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            sb.AppendLine("  " + ItemEquivalentDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + ItemEquivalentDTO.eColumns.EQUIVALENT_ITEM_CD);
            sb.AppendLine("  ," + ItemEquivalentDTO.eColumns.ORDER_LOC_CD);
            sb.AppendLine("  ," + ItemEquivalentDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + ItemEquivalentDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + ItemEquivalentDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + ItemEquivalentDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + ItemEquivalentDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + ItemEquivalentDTO.eColumns.UPD_MACHINE);
            sb.AppendLine(") VALUES(");
            sb.AppendLine("   @ITEM_CD");
            sb.AppendLine("   ,@EQUIVALENT_ITEM_CD");
            sb.AppendLine("   ,@ORDER_LOC_CD");
            sb.AppendLine("   ,@CRT_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,@CRT_MACHINE");
            sb.AppendLine("   ,@UPD_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,@UPD_MACHINE");
            sb.AppendLine(" )");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("@EQUIVALENT_ITEM_CD", DataType.NVarChar, data.EQUIVALENT_ITEM_CD.Value);
            req.Parameters.Add("@ORDER_LOC_CD", DataType.NVarChar, data.ORDER_LOC_CD.Value);
            req.Parameters.Add("@CRT_BY", DataType.NVarChar, data.CRT_BY.Value);
            req.Parameters.Add("@CRT_MACHINE", DataType.NVarChar, data.CRT_MACHINE.Value);
            req.Parameters.Add("@UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }



        public int UpdateWithoutPK(Database database, ItemEquivalentDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("   " + ItemEquivalentDTO.eColumns.ORDER_LOC_CD + "=@ORDER_LOC_CD");
            sb.AppendLine("  ," + ItemEquivalentDTO.eColumns.UPD_BY + "=@UPD_BY");
            sb.AppendLine("  ," + ItemEquivalentDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + ItemEquivalentDTO.eColumns.UPD_MACHINE + "=@UPD_MACHINE");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ItemEquivalentDTO.eColumns.ITEM_CD + "=@ITEM_CD");
            sb.AppendLine("  AND " + ItemEquivalentDTO.eColumns.EQUIVALENT_ITEM_CD + "=@EQUIVALENT_ITEM_CD");

            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("@EQUIVALENT_ITEM_CD", DataType.NVarChar, data.EQUIVALENT_ITEM_CD.Value);
            req.Parameters.Add("@ORDER_LOC_CD", DataType.NVarChar, data.ORDER_LOC_CD.Value);

            req.Parameters.Add("@UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            #endregion

            return db.ExecuteNonQuery(req);

        }


        public int Delete(Database database, ItemEquivalentDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            sb.AppendLine(" DELETE FROM " + data.TableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ItemEquivalentDTO.eColumns.ITEM_CD + "=@ITEM_CD");
            sb.AppendLine("  AND " + ItemEquivalentDTO.eColumns.EQUIVALENT_ITEM_CD + "=@EQUIVALENT_ITEM_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("@EQUIVALENT_ITEM_CD", DataType.NVarChar, data.EQUIVALENT_ITEM_CD.Value);

            #endregion
            return db.ExecuteNonQuery(req);
        }
    }
}
