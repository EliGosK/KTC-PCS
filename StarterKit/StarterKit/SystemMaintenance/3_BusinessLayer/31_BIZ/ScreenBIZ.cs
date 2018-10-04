using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EVOFramework;
using SystemMaintenance.DTO;
using SystemMaintenance.DAO;

namespace SystemMaintenance.BIZ
{
    public class ScreenBIZ
    {
        public DatabaseScreen LoadScreen(NZString screenCode) {
            IScreenDAO dao = DAOFactory.CreateScreenDAO(CommonLib.Common.CurrentDatabase);
            return dao.SelectScreen(null, screenCode, CommonLib.Common.CurrentUserInfomation.LanguageCD, CommonLib.Common.SystemLanguage);
        }

        public DatabaseScreenList LoadScreens()
        {
            IScreenDAO dao = DAOFactory.CreateScreenDAO(CommonLib.Common.CurrentDatabase);
            return dao.SelectScreens(null, CommonLib.Common.CurrentUserInfomation.LanguageCD, CommonLib.Common.SystemLanguage);
        }

        public int AddNew(ScreenDTO dtoScreen)
        {
            CommonLib.Common.CurrentDatabase.KeepConnection = true;
            CommonLib.Common.CurrentDatabase.BeginTransaction();

            try
            {
                IScreenDAO dao = DAOFactory.CreateScreenDAO(CommonLib.Common.CurrentDatabase);
                dao.AddNew(null, dtoScreen);
                CommonLib.Common.CurrentDatabase.Commit();
                return 1;
            }
            catch
            {
                CommonLib.Common.CurrentDatabase.Rollback();
                throw;
            }
           
        }

        public int DeletebyScreenCD(NZString ScreenCD)
        {
            CommonLib.Common.CurrentDatabase.KeepConnection = true;
            CommonLib.Common.CurrentDatabase.BeginTransaction();

            try
            {
                IScreenDAO dao = DAOFactory.CreateScreenDAO(CommonLib.Common.CurrentDatabase);
                dao.DeleteByScreenCD(null, ScreenCD.StrongValue);
                CommonLib.Common.CurrentDatabase.Commit();
                return 1;
            }
            catch
            {
                CommonLib.Common.CurrentDatabase.Rollback();
                throw;
            }
       
        }

        /// <summary>
        /// Load screen description
        /// </summary>
        /// <param name="screenCD">Screen CD</param>
        /// <param name="langCD">LanguageCD that want to load.</param>
        /// <param name="defaultLangCD">If not found data on the given langCD arg, it will use defaultLangCD to default.</param>
        /// <returns>Screen Description.</returns>
        public string LoadScreenDescriptionDependOnLanguage(string screenCD, string langCD, string defaultLangCD) {
            ILangDAO daoLang = DAOFactory.CreateLangDAO(CommonLib.Common.CurrentDatabase);

            string strScreenDescription = string.Empty;

            // Load screen language by given langCD argument.
            strScreenDescription = daoLang.LoadScreenDescriptionByLangCD(null, screenCD, langCD);
            if (String.IsNullOrEmpty(strScreenDescription))
            {                
                // check defaultLangCD argument is empty.
                if (String.IsNullOrEmpty(defaultLangCD)) {
                    string systemDefaultLang = daoLang.LoadSystemDefautLanguage(null);
                    strScreenDescription = daoLang.LoadScreenDescriptionByLangCD(null, screenCD, systemDefaultLang);
                } else {                    
                    strScreenDescription = daoLang.LoadScreenDescriptionByLangCD(null, screenCD, defaultLangCD);
                }              
            } 

            return strScreenDescription;
        }

        internal DatabaseScreenList LoadScreensWithLangCD(NZString LangCD)
        {
            IScreenDAO dao = DAOFactory.CreateScreenDAO(CommonLib.Common.CurrentDatabase);
            return dao.SelectScreens(null, LangCD, CommonLib.Common.SystemLanguage);
        }

        internal DatabaseScreenList LoadScreensWithAuthorizeAndLangCD(NZString LangCD)
        {
            IScreenDAO dao = DAOFactory.CreateScreenDAO(CommonLib.Common.CurrentDatabase);
            return dao.SelectScreenWithAuthorize(null, LangCD, CommonLib.Common.SystemLanguage);
        }

        internal int UpdateScreenImage(ScreenDTO dto)
        {
            CommonLib.Common.CurrentDatabase.KeepConnection = true;
            CommonLib.Common.CurrentDatabase.BeginTransaction();

            try
            {
                IScreenDAO dao = DAOFactory.CreateScreenDAO(CommonLib.Common.CurrentDatabase);
                dao.UpdateScreenImage(null, dto);
                CommonLib.Common.CurrentDatabase.Commit();
                return 1;
            }
            catch
            {
                CommonLib.Common.CurrentDatabase.Rollback();
                throw;
            }
           
        }
    }
}
