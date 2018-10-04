using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemMaintenance.DTO;
using System.Data;
using SystemMaintenance.DAO;

namespace SystemMaintenance.BIZ
{
    public class ScreenDetailLangBIZ
    {
        public int AddNew(ScreenDetailLangDTO dtoScreenDetailLang)
        {
            IScreenDetailLangDAO dao = DAOFactory.CreateScreenDetailLangDAO(CommonLib.Common.CurrentDatabase);
            return dao.AddNew(null, dtoScreenDetailLang);
        }



        public List<ScreenDetailLangDTO> LoadScreenDetailByLangCD(string screenCD, string LangCD)
        {
            IScreenDetailLangDAO dao = DAOFactory.CreateScreenDetailLangDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadScreenDetailByLangCD(null, screenCD, LangCD);
        }

        public DataTable LoadScreenDetailWithOriginalCaptionByLangCD(string screenCD, string LangCD)
        {
            IScreenDetailLangDAO dao = DAOFactory.CreateScreenDetailLangDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadScreenDetailWithOriginalCaptionByLangCD(null, screenCD, LangCD);
        }

        public int UpdateScreenDisplayText(ScreenDetailLangDTO dto)
        {
            IScreenDetailLangDAO dao = DAOFactory.CreateScreenDetailLangDAO(CommonLib.Common.CurrentDatabase);
            return dao.UpdateWithoutPK(null, dto);
        }
    }
}
