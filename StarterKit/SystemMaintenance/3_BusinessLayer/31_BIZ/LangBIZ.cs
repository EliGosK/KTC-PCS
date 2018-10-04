using EVOFramework.Data;
using SystemMaintenance.DTO;
using System.Collections.Generic;
using SystemMaintenance.DAO;

namespace SystemMaintenance.BIZ
{
    public class LangBIZ
    {
        public LookupData LoadLookup(bool orderByKey)
        {
            ILangDAO dao = DAOFactory.CreateLangDAO(CommonLib.Common.CurrentDatabase);
            List<LangDTO> dtos = dao.LoadAll(null, orderByKey);
            return new LookupData(DTOUtility.ConvertListToDataTable(dtos),
                LangDTO.eColumns.LANG_NAME.ToString(),
                LangDTO.eColumns.LANG_CD.ToString());
        }

        public List<LangDTO> LoadAll()
        {
            ILangDAO dao = DAOFactory.CreateLangDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadAll(null);
        }

        /// <summary>
        /// Load system default language from database.
        /// </summary>
        /// <returns>language code.</returns>
        public string LoadSystemDefaultLanguage() {
            ILangDAO dao = DAOFactory.CreateLangDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadSystemDefautLanguage(null);
        }
    }
}
