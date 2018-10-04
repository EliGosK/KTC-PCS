using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using SystemMaintenance.BIZ;
using System.Data;
using SystemMaintenance.Validators;

namespace SystemMaintenance.Controller
{
    public class SubMenuMaintenanceController
    {
        private readonly MenuSubMaintenanceBIZ m_bizMenuSub = new MenuSubMaintenanceBIZ();        

        public DataTable LoadDataWithLanguage(NZString languageCD)
        {
            DataTable dtView = m_bizMenuSub.LoadAllMenuSubWithLang(languageCD);
            return dtView;
        }

        public void SaveMenuSubDescription(NZString languageCD, NZString menuSub, NZString description) {
            m_bizMenuSub.SaveMenuSubDescription(menuSub, languageCD, description);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuSubCD"></param>
        /// <param name="menuSubName"></param>        
        /// <exception cref="EVOFramework.ValidateException"><c>ValidateException</c>.</exception>
        /// <exception cref="EVOFramework.BusinessException"><c>BusinessException</c>.</exception>
        public void SaveNewMenuSub(NZString menuSubCD, NZString menuSubName) {

            MenuSubValidator validator = new MenuSubValidator();
            validator.ValidateBeforeSaveAdd(menuSubCD, menuSubName);
            
            m_bizMenuSub.SaveNewMenuSubDescription(menuSubCD, menuSubName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuSubCD"></param>
        /// <param name="menuSubName"></param>
        /// <exception cref="EVOFramework.ValidateException"><c>ValidateException</c>.</exception>
        public void SaveEditMenuSub(NZString menuSubCD, NZString menuSubName) {

            MenuSubValidator validator = new MenuSubValidator();
            validator.ValidateBeforeSaveEdit(menuSubCD, menuSubName);
            

            m_bizMenuSub.SaveEditMenuSub(menuSubCD, menuSubName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuSubCD"></param>
        /// <exception cref="ValidateException"><c>ValidateException</c>.</exception>
        public void DeleteMenuSub(NZString menuSubCD) {
            MenuSubValidator validator = new MenuSubValidator();
            ErrorItem item = validator.CheckMenuSubCode(menuSubCD);

            if (item != null) {
                ValidateException validateException = new ValidateException();
                validateException.AddError(item);
                validateException.ThrowIfHasError();
            }


            m_bizMenuSub.DeleteMenuSub(menuSubCD);
        }
    }
}
