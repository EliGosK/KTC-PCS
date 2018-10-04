using System;
using System.Collections.Generic;
using System.Text;
using EVOFramework.Database;
using EVOFramework;
using Rubik.DTO;
using System.Data;

namespace Rubik.DAO
{
    public class NGInurityDAO
    {
        private readonly Database m_db;
        public NGInurityDAO(Database db)
        {
            this.m_db = db;
        }
        public List<NGInquiryViewDTO> LoadNGInquiry(Database database, NZDateTime FromPeriod, NZDateTime ToPeriod, NZString ItemFrom, NZString ItemTo, bool GroupByItem,NZString LotNo)
        {
            
            Database db = UseDatabase(database);
            //Use Stored Procedures
            DataRequest req = new DataRequest("S_TRN150_NGInquiry_Load");
            req.CommandType = System.Data.CommandType.StoredProcedure;
            req.Parameters.Add("@pDtmDateFrom",FromPeriod.Value);
            req.Parameters.Add("@pDtmDateTo", ToPeriod.Value);
            req.Parameters.Add("@pVarItemCodeFrom", ItemFrom.Value);
            req.Parameters.Add("@pVarItemCodeTo",ItemTo.Value);
            req.Parameters.Add("@pIntDisplayType", GroupByItem);
            req.Parameters.Add("@pVarLotNumber", LotNo.Value);
            return db.ExecuteForList<NGInquiryViewDTO>(req);

        }
        protected Database UseDatabase(Database specificDB)
        {
            if (specificDB != null)
                return specificDB;

            if (this.m_db != null)
                return this.m_db;

            throw new DataAccessException(ResourceBundle.ALL.S_CANNOT_USE_DB);
        }
    }
}
