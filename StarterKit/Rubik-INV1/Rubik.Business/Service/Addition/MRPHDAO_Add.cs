/* Create by: Ms. Sansanee K.
 * Create on: 2011-06-17
 * Company: CSI Groups (Thailand)
 * Group: SI-EVO
 
 *** This generate source code was build for DAO on StarterKit system. ***/
using System;
using System.Collections.Generic;
using System.Text;
using EVOFramework.Database;
using EVOFramework;
using Rubik.DTO;
using Rubik.Data;
using System.Data;


namespace Rubik.DAO {
    internal partial class MRPHDAO {

        #region Load Data

        public List<MRPHDTO> LoadMRPHeader(Database database, string strMRP_NO) {

            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_MRP010_LoadMRPHeader";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_MRP_NO", DataType.NVarChar, strMRP_NO);

            return db.ExecuteForList<MRPHDTO>(req);
            
        }

        public DataTable LoadSimalateMRPHeader(Database database, string strMRP_NO) {

            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_MRP010_LoadSimulateMRPHeader";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_MRP_NO", DataType.NVarChar, strMRP_NO);

            return db.ExecuteQuery(req);

        }


        public DataTable LoadMRPList(Database database, NZDateTime dtmDate, NZDateTime dtmDateTo)
        {
            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_MRP020_LoadMRPList";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pDtm_DATE_FROM", DataType.DateTime, dtmDate.Value);
            req.Parameters.Add("@pDtm_DATE_TO", DataType.DateTime, dtmDateTo.Value);

            return db.ExecuteQuery(req);
        }

        #endregion


        #region Operation

        public void UpdateMRPRevision(Database database, MRPHDTO dto) 
        {
            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_MRP020_UpdateMRPRevision";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_MRP_NO", DataType.VarChar, dto.MRP_NO.Value);
            req.Parameters.Add("@pVar_ITEM_CD", DataType.VarChar, dto.ITEM_CD.Value);
            req.Parameters.Add("@pVar_ORDER_LOC_CD", DataType.VarChar, dto.ORDER_LOC_CD.Value);
            req.Parameters.Add("@pVar_UPD_BY", DataType.VarChar, dto.UPD_BY.Value);
            req.Parameters.Add("@pVar_UPD_MACHINE", DataType.VarChar, dto.UPD_MACHINE.Value);

            db.ExecuteNonQuery(req);
        }

        #endregion
    }
}

