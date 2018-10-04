/* Create by: Ms. Sansanee K.
 * Create on: 2011-05-27
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
using Rubik.Data;
using System.Data;

namespace Rubik.DAO {

    internal partial class DemandOrderDAO {

        #region Load Data

        /// <summary>
        /// Load order of year/month and customer
        /// </summary>
        /// <param name="database"></param>
        /// <param name="dtmYEAR_MONTH"></param>
        /// <param name="strCUSTOMER_CODE"></param>
        /// <returns>all item of input parameter</returns>
        public List<DemandOrderDTO> LoadDemandOrder(Database database, DateTime dtmYEAR_MONTH, string strCUSTOMER_CODE) {

            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_MRP020_LoadDemandOrder";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pDtm_YearMonth", DataType.DateTime, dtmYEAR_MONTH);
            req.Parameters.Add("@pVar_CustomerCode", DataType.NVarChar, strCUSTOMER_CODE);

            List<DemandOrderDTO> list = db.ExecuteForList<DemandOrderDTO>(req);

            return list;
        }

        /// <summary>
        /// get order item
        /// </summary>
        /// <param name="database"></param>
        /// <param name="dtmYEAR_MONTH"></param>
        /// <param name="strCUSTOMER_CD"></param>
        /// <param name="strITEM_CD"></param>
        /// <returns></returns>
        public DemandOrderDTO LoadDemandOrderByItem(Database database, DateTime dtmYEAR_MONTH, string strCUSTOMER_CD, string strITEM_CD) {

            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_MRP020_LoadDemandOrderByItem";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pDtm_YEAR_MONTH", DataType.DateTime, dtmYEAR_MONTH);
            req.Parameters.Add("@pVar_CUSTOMER_CD", DataType.NVarChar, strCUSTOMER_CD);
            req.Parameters.Add("@pVar_ITEM_CD", DataType.NVarChar, strITEM_CD);

            List<DemandOrderDTO> list = db.ExecuteForList<DemandOrderDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }

        public DataTable LoadDemandOrderSummary(Database database, DateTime dtmYEAR_MONTH , string strCUSTOMER_CODE) {

            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_MRP020_LoadDemandOrder_Summary";
            req.CommandType = CommandType.StoredProcedure;            
            req.Parameters.Add("@pDtm_YearMonth", DataType.DateTime, dtmYEAR_MONTH.Date);
            req.Parameters.Add("@pVar_CustomerCode", DataType.NVarChar, strCUSTOMER_CODE);

            return db.ExecuteQuery(req);            
        }

        public DataTable LoadSourceOrderSummaryEachMonth(Database database, GenerateMRPDTO dto, string strDateFormat) {

            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_MRP010_LoadSourceOrderSumByMonth";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pDtm_StartDate", DataType.DateTime, dto.START_DATE.Value);
            if (dto.ITEM_FLAG) {
                req.Parameters.Add("@pVar_ItemCodeFrom", DataType.NVarChar, dto.ITEM_CD_FROM.Value);
                req.Parameters.Add("@pVar_ItemCodeTo", DataType.NVarChar, dto.ITEM_CD_TO.Value);
            }
            req.Parameters.Add("@pVar_DATE_FORMAT", DataType.NVarChar, strDateFormat);

            return db.ExecuteQuery(req);
        }

        public DataTable LoadDemandOrderInRange(Database database, NZDateTime nZDateTimeBegin, NZDateTime nZDateTimeEnd)
        {
            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_ORD010_LoadDemandOrderInRange";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pDtm_StartDate", DataType.DateTime, nZDateTimeBegin.Value);
            req.Parameters.Add("@pDtm_EndDate", DataType.DateTime, nZDateTimeEnd.Value);

            return db.ExecuteQuery(req);
        }

        #endregion

        #region Operation

        public int UpdateOrder(Database database, DemandOrderDTO dto) 
        {
            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_MRP020_UpdateDemandOrder";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_CRT_BY", DataType.NVarChar, dto.CRT_BY.Value);
            req.Parameters.Add("@pVar_CRT_MACHINE", DataType.NVarChar, dto.CRT_MACHINE.Value);
            req.Parameters.Add("@pDtm_YEAR_MONTH", DataType.DateTime, dto.YEAR_MONTH.Value);
            req.Parameters.Add("@pVar_CUSTOMER_CD", DataType.NVarChar, dto.CUSTOMER_CD.Value);            

            return db.ExecuteNonQuery(req);

        }

        public int DeleteOrder(Database database, DemandOrderDTO dto) {
            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_MRP020_DeleteDemandOrder";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_UPD_BY", DataType.NVarChar, dto.CRT_BY.Value);
            req.Parameters.Add("@pVar_UPD_MACHINE", DataType.NVarChar, dto.CRT_MACHINE.Value);
            req.Parameters.Add("@pVar_CUSTOMER_CD", DataType.NVarChar, dto.CUSTOMER_CD.Value);
            req.Parameters.Add("@pDtm_YEAR_MONTH", DataType.DateTime, dto.YEAR_MONTH.Value);

            return db.ExecuteNonQuery(req);

        }

        public int DeleteTargetOrder(Database database, DemandOrderDTO dto)
        { 
            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_MRP020_DeleteTargetDemandOrder"; 
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_UPD_BY", DataType.NVarChar, dto.CRT_BY.Value);
            req.Parameters.Add("@pVar_UPD_MACHINE", DataType.NVarChar, dto.CRT_MACHINE.Value);
            req.Parameters.Add("@pVar_ORDER_ID", DataType.Int32, dto.ORDER_ID.Value);

            return db.ExecuteNonQuery(req);
        }

        #endregion

        #region Is Exists
        
        public bool ExistsByHeader(Database database, DateTime dtmYEAR_MONTH, string strCUSTOMER_CODE) {

            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_MRP020_LoadDemandOrder";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pDtm_YearMonth", DataType.DateTime, dtmYEAR_MONTH);
            req.Parameters.Add("@pVar_CustomerCode", DataType.NVarChar, strCUSTOMER_CODE);

            return (db.ExecuteQuery(req).Rows.Count > 0);
        }

        public bool IsHoliday(Database database, DateTime dtmPERIOD, DateTime dtmDATE) 
        {
            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_MRP020_CheckWorkingDate";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pDtm_PERIOD", DataType.DateTime, dtmPERIOD.Date);
            req.Parameters.Add("@pDtm_DATE", DataType.DateTime, dtmDATE.Date);

            DataTable dt = db.ExecuteQuery(req);
            return (dt != null && dt.Rows.Count > 0); 
        }

        #endregion

    }
}

