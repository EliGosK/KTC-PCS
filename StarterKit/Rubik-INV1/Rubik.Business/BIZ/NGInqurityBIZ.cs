using System;
using System.Data;
using System.Collections.Generic;
using SystemMaintenance.BIZ;
using SystemMaintenance.DTO;
using SystemMaintenance.SQLServer.DAO;
using Rubik.DAO;
using EVOFramework;
using Rubik.DTO;
using EVOFramework.Database;
using Rubik.Validators;
using CommonLib;

namespace Rubik.BIZ
{
    public class NGInqurityBIZ
    {
        public List<NGInquiryViewDTO> LoadNGInqurity(NZDateTime FromPeriod, NZDateTime ToPeriod, NZString ItemFrom, NZString ItemTo, bool GroupByItem, NZString LotNo)
        {
            NGInurityDAO dao = new NGInurityDAO(Common.CurrentDatabase);
            return dao.LoadNGInquiry(null, FromPeriod, ToPeriod, ItemFrom, ItemTo, GroupByItem, LotNo);
        }
    }
    
}
