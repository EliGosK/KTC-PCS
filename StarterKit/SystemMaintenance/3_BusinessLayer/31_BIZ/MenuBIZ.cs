using System.Collections.Generic;
using SystemMaintenance.UIDataModel;
using EVOFramework;
using SystemMaintenance.DTO;
using System.Data;
using SystemMaintenance.DAO;

namespace SystemMaintenance.BIZ
{
    internal class MenuBIZ
    {

        #region Load functions
        public List<MenuSub> LoadMenus(NZString userCD)
        {
            IMenuDAO dao = DAOFactory.CreateMenuDAO(CommonLib.Common.CurrentDatabase);

            List<MenuSub> menuSubList = dao.GetAllMenuSubFromUser(userCD, CommonLib.Common.SystemLanguage);

            for (int i = 0; i < menuSubList.Count; i++)
            {
                MenuSub menuSub = menuSubList[i];

                List<MenuSubItemDTO> menuSubItemList = dao.GetAllMenuSubItem(menuSub.MENU_SUB_CD.StrongValue, userCD.StrongValue);
                menuSub.MenuSubItemList = menuSubItemList;
            }


            return menuSubList;
        }
        #endregion

        #region Favorite
        /// <summary>
        /// Load screen favorite by given user.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>list of screen code.</returns>
        public List<string> LoadScreenFavorite(string username)
        {
            List<string> screens = new List<string>();
            IMenuDAO daoMenu = DAOFactory.CreateMenuDAO(CommonLib.Common.CurrentDatabase);
            DataTable dt = daoMenu.GetScreenFavorite(username);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                screens.Add(dt.Rows[i][0].ToString());
            }
            return screens;
        }

        /// <summary>
        /// Add screen favorite.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="screenCD"></param>
        public void AddScreenFavorite(string username, string screenCD)
        {
            IMenuDAO daoMenu = DAOFactory.CreateMenuDAO(CommonLib.Common.CurrentDatabase);
            daoMenu.AddNewFavorite(username, screenCD);
        }

        /// <summary>
        /// Remove screen favorite
        /// </summary>
        /// <param name="username"></param>
        /// <param name="screenCD"></param>
        public void RemoveScreenFavorite(string username, string screenCD)
        {
            IMenuDAO daoMenu = DAOFactory.CreateMenuDAO(CommonLib.Common.CurrentDatabase);
            daoMenu.DeleteFavorite(username, screenCD);
        }
        #endregion

        #region Exists functions
        /// <summary>
        /// Check exists menu favorite.
        /// </summary>
        /// <param name="userAccount"></param>
        /// <param name="screenCD"></param>
        /// <returns></returns>
        public bool ExistMenuFavorite(NZString userAccount, NZString screenCD)
        {
            IMenuFavoriteDAO dao = DAOFactory.CreateMenuFavoriteDAO(CommonLib.Common.CurrentDatabase);
            return dao.Exist(null, userAccount, screenCD);
        }
        #endregion
    }
}
