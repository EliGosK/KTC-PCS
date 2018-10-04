#define Edit_By_Chatas_C
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using EVOFramework.Database;
using Rubik.DTO;
using System.Data;

namespace Rubik.DAO
{
    partial class ReturnDAO : BaseDAO
    {

        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public ReturnDAO(Database db)
        {
            this.m_db = db;
        }
        #endregion

        #region Function Load

        public DataTable Load_ReturnListEntry(NZString SlipNo, bool IncludeOldData)
        {
            Database db = m_db;

            DataRequest req = new DataRequest("S_TRN270_ReturnProductEntry_Load");
            req.CommandType = CommandType.StoredProcedure;
            //req.Parameters.Add("@RETURNDATE", DataType.DateTime, CheckNull(ReturnDate.StrongValue.Date));
            req.Parameters.Add("@SLIP_NO", DataType.NVarChar, CheckNull(SlipNo.Value));
            //req.Parameters.Add("@CUSTOMER_CD", DataType.NVarChar, CheckNull(CustomerCode.Value));
            //req.Parameters.Add("@RETURN_LOC_CD", DataType.NVarChar, CheckNull(ReturnLocCd.Value));
            if (!IncludeOldData)
                req.Parameters.Add("@OLD_DATA", DataType.Int16, 0);    //not include old value  

            return db.ExecuteQuery(req);
        }

        public DataTable Load_ReturnProductionList(NZDateTime DateBegin, NZDateTime DateEnd, bool IncludeOldData)
        {
            Database db = m_db;

            DataRequest req = new DataRequest("S_TRN260_ReturnProductionList_Load");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pDtmDateFrom", DataType.DateTime, CheckNull(DateBegin.StrongValue.Date));
            req.Parameters.Add("@pDtmDateTo", DataType.DateTime, CheckNull(DateEnd.StrongValue.Date));
            if (!IncludeOldData)
                req.Parameters.Add("@OLD_DATA", DataType.Int16, 0);    //not include old value  

            return db.ExecuteQuery(req);
        }

        public void UpdateReturnQTY(NZString TransID, NZDecimal DiffQTY, NZString UpdateBy, NZString UpdateMachine)
        {
            Database db = m_db;

            DataRequest req = new DataRequest("S_TRN270_UpdateReturnQTY");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_TRANS_ID", DataType.NVarChar, CheckNull(TransID.Value));
            req.Parameters.Add("@pNum_DiffQty", DataType.Default, CheckNull(DiffQTY.StrongValue));
            req.Parameters.Add("@pVar_UpdateBy", DataType.NVarChar, CheckNull(UpdateBy.Value));
            req.Parameters.Add("@pVar_UpdateMachine", DataType.NVarChar, CheckNull(UpdateMachine.Value));

            db.ExecuteNonQuery(req);
        }
        #endregion
    }
}
