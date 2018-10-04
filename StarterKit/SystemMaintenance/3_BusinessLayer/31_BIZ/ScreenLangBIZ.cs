using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemMaintenance.DTO;
using EVOFramework;
using SystemMaintenance.DAO;

namespace SystemMaintenance.BIZ
{
    class ScreenLangBIZ
    {
        public int AddNew(ScreenLangDTO dtoScreenLang)
        {
            IScreenLangDAO dao = DAOFactory.CreateScreenLangDAO(CommonLib.Common.CurrentDatabase);
            return dao.AddNew(null, dtoScreenLang);
        }

        //public int DeletebyScreenCD(NZString nZString)
        //{
        //    ScreenLangDAO dao = new ScreenLangDAO(CommonLib.Common.CurrentDatabase);
        //    return dao.DeletebyScreenCD(null, nZString);
        //}

        public int UpdateScreenDisplayText(ScreenLangDTO dto)
        {
            IScreenLangDAO dao = DAOFactory.CreateScreenLangDAO(CommonLib.Common.CurrentDatabase);
            return dao.UpdateWithoutPK(null, dto);
        }

    }
}
