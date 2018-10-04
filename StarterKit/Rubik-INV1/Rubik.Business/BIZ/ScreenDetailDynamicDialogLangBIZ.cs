using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Rubik.DAO;
using Rubik.DTO;

namespace Rubik.BIZ
{
    public class ScreenDetailDynamicDialogLangBIZ
    {
        public List<ScreenDetailDynamicDialogLangDTO> LoadScreenDetailByLangCD(string screenCD, string LangCD)
        {
            ScreenDetailDynamicDialogLangDAO dao = new ScreenDetailDynamicDialogLangDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadScreenDetailByLangCD(null, screenCD, LangCD);
        }
    }
}
