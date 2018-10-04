using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EVOFramework;
using SystemMaintenance.DTO;
using EVOFramework.Database;
using SystemMaintenance.Validators;
using SystemMaintenance.DAO;

namespace SystemMaintenance.BIZ
{
    public class MenuSubMaintenanceBIZ
    {
        #region Load functions
        /// <summary>
        /// Key:
        /// <para>MENU_SUB_CD, MENU_SUB_NAME, MENU_SUB_DESC</para>
        /// </summary>
        /// <param name="langCD"></param>
        /// <returns></returns>
        public DataTable LoadAllMenuSubWithLang(NZString langCD) {
            IMenuSubDAO dao = DAOFactory.CreateMenuSubDAO(CommonLib.Common.CurrentDatabase);
            DataTable dtView = dao.LoadAllMenuSubWithDescription(null, langCD);
            return dtView;
        }

        /// <summary>
        /// Key:
        /// <para>MENU_SUB_CD, MENU_SUB_NAME, MENU_SUB_DESC</para>
        /// </summary>
        /// <param name="menuSubCD"></param>
        /// <param name="langCD"></param>
        /// <returns></returns>
        public DataTable LoadMenuSubWithLang(NZString menuSubCD, NZString langCD)
        {
            IMenuSubDAO dao = DAOFactory.CreateMenuSubDAO(CommonLib.Common.CurrentDatabase);
            DataTable dtView = dao.LoadMenuSubWithDescription(null, menuSubCD, langCD);
            return dtView;
        }
        #endregion

        #region Save functions
        public void SaveMenuSubDescription(NZString menuSubCD, NZString langCD, NZString description) {
            IMenuSubLangDAO daoSubMenuLang = DAOFactory.CreateMenuSubLangDAO(CommonLib.Common.CurrentDatabase);

            MenuSubLangDTO dtoMenuSubLang = new MenuSubLangDTO();
            dtoMenuSubLang.MENU_SUB_CD = menuSubCD;
            dtoMenuSubLang.LANG_CD = langCD;
            dtoMenuSubLang.MENU_SUB_DESC = description;
            dtoMenuSubLang.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dtoMenuSubLang.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dtoMenuSubLang.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
            dtoMenuSubLang.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;

            daoSubMenuLang.AddNewOrUpdate(null, dtoMenuSubLang);
                        
        }

        /// <summary>
        /// Save new menu sub.
        /// </summary>
        /// <param name="menuSubCD"></param>
        /// <param name="menuSubName"></param>
        /// <exception cref="EVOFramework.ValidateException"><c>ValidateException</c>.</exception>
        /// <exception cref="EVOFramework.BusinessException"><c>BusinessException</c>.</exception>
        public void SaveNewMenuSubDescription(NZString menuSubCD, NZString menuSubName) {

            MenuSubValidator validator = new MenuSubValidator();
            validator.ValidateBeforeSaveAdd(menuSubCD, menuSubName);

            Database database = CommonLib.Common.CurrentDatabase;

            try {
                database.KeepConnection = true;
                database.BeginTransaction();

                ILangDAO daoLang = DAOFactory.CreateLangDAO(database);
                IMenuSubDAO daoMenuSub = DAOFactory.CreateMenuSubDAO(database);
                IMenuSubLangDAO daoMenuSubLang = DAOFactory.CreateMenuSubLangDAO(database);

                //== Add menu sub master.
                MenuSubDTO dtoMenuSub = new MenuSubDTO();
                dtoMenuSub.MENU_SUB_CD = menuSubCD;
                dtoMenuSub.MENU_SUB_NAME = menuSubName;
                dtoMenuSub.IMAGE_CD.Value = null;
                dtoMenuSub.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                dtoMenuSub.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                dtoMenuSub.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                dtoMenuSub.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                daoMenuSub.AddNew(null, dtoMenuSub);

                //== Add menu sub on each language.
                List<LangDTO> langs = daoLang.LoadAll(null);
                for (int i = 0; i < langs.Count; i++) {
                    MenuSubLangDTO dtoMenuSubLang = new MenuSubLangDTO();
                    dtoMenuSubLang.MENU_SUB_CD = menuSubCD;
                    dtoMenuSubLang.LANG_CD = langs[i].LANG_CD;
                    dtoMenuSubLang.MENU_SUB_DESC = menuSubName;
                    dtoMenuSubLang.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                    dtoMenuSubLang.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                    dtoMenuSubLang.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                    dtoMenuSubLang.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;

                    daoMenuSubLang.AddNewOrUpdate(null, dtoMenuSubLang);
                    
                }

                database.Commit();

            } catch {
                database.Rollback();
                throw;
            } finally {
                if (database.DBConnectionState == ConnectionState.Open)
                    database.Close();
            }
        }
        public void SaveEditMenuSub(NZString menuSubCD, NZString menuSubName) {
            Database database = CommonLib.Common.CurrentDatabase;

            try
            {
                database.KeepConnection = true;
                database.BeginTransaction();

                IMenuSubDAO daoMenuSub = DAOFactory.CreateMenuSubDAO(database);

                //== Update menu sub master.
                MenuSubDTO dtoMenuSub = new MenuSubDTO();
                dtoMenuSub.MENU_SUB_CD = menuSubCD;
                dtoMenuSub.MENU_SUB_NAME = menuSubName;
                dtoMenuSub.IMAGE_CD.Value = null;
                dtoMenuSub.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                dtoMenuSub.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                dtoMenuSub.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                dtoMenuSub.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                daoMenuSub.UpdateWithoutPK(null, dtoMenuSub);
               
                database.Commit();

            }
            catch
            {
                database.Rollback();
                throw;
            }
            finally
            {
                if (database.DBConnectionState == ConnectionState.Open)
                    database.Close();
            }
        }
        #endregion

        #region Delete functions
        public void DeleteMenuSub(NZString menuSubCD) {
             Database database = CommonLib.Common.CurrentDatabase;

             try {
                 database.KeepConnection = true;
                 database.BeginTransaction();

                 IMenuSubDAO daoMenuSub = DAOFactory.CreateMenuSubDAO(database);
                 IMenuSubLangDAO daoMenuSubLang = DAOFactory.CreateMenuSubLangDAO(database);

                 daoMenuSub.Delete(null, menuSubCD);
                 daoMenuSubLang.DeleteOnAllLang(null, menuSubCD);

                 database.Commit();                 
             } catch {
                 database.Rollback();                 
                 throw;

             } finally {
                 if (database.DBConnectionState == ConnectionState.Open)
                    database.Close();
             }

        }
        #endregion

        #region Exists functions
        /// <summary>
        /// Check exist menu sub code.
        /// </summary>
        /// <param name="menuSubCD"></param>
        /// <returns></returns>
        public bool ExistMenuSub(NZString menuSubCD) {
            IMenuSubDAO dao = DAOFactory.CreateMenuSubDAO(CommonLib.Common.CurrentDatabase);
            return dao.Exist(null, menuSubCD);
        }
        #endregion
    }
}
