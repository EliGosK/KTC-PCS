using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemMaintenance.DTO;
using EVOFramework;
using SystemMaintenance.DAO;

namespace SystemMaintenance.BIZ
{
    class ScreenDetailBIZ
    {
        public int AddNew(ScreenDetailDTO dtoScreenDetail)
        {
            IScreenDetailDAO dao = DAOFactory.CreateScreenDetailDAO(CommonLib.Common.CurrentDatabase);
            return dao.AddNew(null, dtoScreenDetail);
        }

        public bool isExist(string ScreenCD,string ControlCD)
        {
            NZString screencd = new NZString();
            NZString controlcd = new NZString();

            screencd.Value = ScreenCD;
            controlcd.Value = ControlCD;
            return DAOFactory.CreateScreenDetailDAO(CommonLib.Common.CurrentDatabase).Exist(null, screencd, controlcd);
        }
    }
}
