using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Rubik.BIZ;
using Rubik.DTO;

namespace Rubik.Controller
{
    public class InvTranLogController
    {
        internal DataTable LoadAllInvTranLogPeriod(EVOFramework.NZDateTime FromDate, EVOFramework.NZDateTime ToDate, EVOFramework.NZString ScreenType)
        {
            InvTranLogBIZ biz = new InvTranLogBIZ();
            return biz.LoadAllInvTranLogPeriod(FromDate, ToDate, ScreenType);
        }



        internal DataTable LoadLogData(LogInquiryCriteriaDTO criteria)
        {
            InvTranLogBIZ biz = new InvTranLogBIZ();


            return biz.LoadLogData(criteria);



        }
    }
}
