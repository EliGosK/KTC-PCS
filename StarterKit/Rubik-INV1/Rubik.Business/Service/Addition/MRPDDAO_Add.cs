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
    internal partial class MRPDDAO {

        #region Load Data
        public List<MRPDDTO> LoadMRPDetail(Database database, string strMRP_NO) {

            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_MRP010_LoadMRPDetail";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_MRP_NO", DataType.NVarChar, strMRP_NO);

            return db.ExecuteForList<MRPDDTO>(req);

        }

        public DataTable LoadMRPDetailByItem(Database database, NZString strMRP_NO, NZString strITEM_CD, NZString strLOC_CD, NZDateTime dtmPERIOD_BEGIN, NZDateTime dtmPERIOD_END) {

            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_MRP020_LoadMRPDetailByItem";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_MRP_NO", DataType.NVarChar, strMRP_NO.Value);
            req.Parameters.Add("@pVar_ITEM_CD", DataType.NVarChar, strITEM_CD.Value);
            req.Parameters.Add("@pVar_LOC_CD", DataType.NVarChar, strLOC_CD.Value);
            req.Parameters.Add("@pDtm_PERIOD_FROM", DataType.DateTime, dtmPERIOD_BEGIN.Value);
            req.Parameters.Add("@pDtm_PERIOD_TO", DataType.DateTime, dtmPERIOD_END.Value);

            return db.ExecuteQuery(req);

        }

        public DataTable LoadMRPDetailSummaryByMonth(Database database, string strMRP_NO, string strITEM_CD, string strLOC_CD, string strDateFormat) {

            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_MRP010_LoadMRPDetailSummaryByMonth";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_MRP_NO", DataType.NVarChar, strMRP_NO);
            req.Parameters.Add("@pVar_ITEM_CD", DataType.NVarChar, strITEM_CD);
            req.Parameters.Add("@pVar_ORDER_LOC_CD", DataType.NVarChar, strLOC_CD);
            req.Parameters.Add("@pVar_DATE_FORMAT", DataType.NVarChar, strDateFormat);

            return db.ExecuteQuery(req);

        }

        public NZDateTime LoadMaxMRPDate(Database database) 
        {
            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_MRP020_MaxMRPDate";
            req.CommandType = CommandType.StoredProcedure;            

            NZDateTime dtm = new NZDateTime(null,db.ExecuteScalar(req));
            return dtm;            
        }

        #endregion

        #region Operation

        public void UpdateBalanceStock(Database database, MRPHDTO dto) {
            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_MRP020_UPDATE_BALANCE_ITEM";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pMRP_NO", DataType.VarChar, dto.MRP_NO.Value);
            req.Parameters.Add("@pITEM_CD", DataType.VarChar, dto.ITEM_CD.Value);
            req.Parameters.Add("@pORDER_LOC_CD", DataType.VarChar, dto.ORDER_LOC_CD.Value);
            //req.Parameters.Add("@pVar_UPD_BY", DataType.VarChar, dto.UPD_BY.Value);
            //req.Parameters.Add("@pVar_UPD_MACHINE", DataType.VarChar, dto.UPD_MACHINE.Value);

            db.ExecuteNonQuery(req);
        }

        #endregion
    }
}

