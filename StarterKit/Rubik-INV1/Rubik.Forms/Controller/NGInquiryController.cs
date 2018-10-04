using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rubik.BIZ;
using System.Data;
using EVOFramework;
using Rubik.DTO;

namespace Rubik.Controller
{
    public class NGInquiryController
    {
        internal List<NGInquiryViewDTO> LoadNGInquiry(NZDateTime FromPeriod, NZDateTime ToPeriod, NZString ItemFrom, NZString ItemTo, bool GroupByItem,NZString LotNo)
        {
            NGInqurityBIZ biz = new NGInqurityBIZ();
            return biz.LoadNGInqurity(FromPeriod, ToPeriod, ItemFrom, ItemTo, GroupByItem, LotNo);
        }
    }
}
