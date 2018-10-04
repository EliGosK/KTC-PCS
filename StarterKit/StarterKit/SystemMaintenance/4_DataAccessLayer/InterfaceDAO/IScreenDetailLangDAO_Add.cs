using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Database;
using SystemMaintenance.DTO;
using System.Data;

namespace SystemMaintenance.DAO
{
    public partial interface IScreenDetailLangDAO
    {

        int DeleteByScreenCD(Database database, string ScreenCD);

        /// <summary>
        /// Load with specified ScreenCode and LangCode.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="SCREEN_CD">Key #1</param>
        /// <param name="LANG_CD">Key #2</param>        
        /// <returns></returns>
        List<ScreenDetailLangDTO> LoadScreenDetailByLangCD(Database database, string SCREEN_CD, string LANG_CD);

        DataTable LoadScreenDetailWithOriginalCaptionByLangCD(Database database, string SCREEN_CD, string LANG_CD);

        void UpdateIsUsed(Database database, ScreenDetailLangDTO dto);

        void ResetUsageFlag();
    }
}
