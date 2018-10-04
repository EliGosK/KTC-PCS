using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemMaintenance.UIDataModel;
using SystemMaintenance.BIZ;
using EVOFramework;
using SystemMaintenance.UIDM;

namespace SystemMaintenance.Controller
{
    public class MenuController
    {        
        public List<MenuSub> LoadMenuHierachy() {
            MenuBIZ biz = new MenuBIZ();
            return biz.LoadMenus(CommonLib.Common.CurrentUserInfomation.UserCD);
        }

        public List<string> LoadScreenFavorite(NZString username)
        {
            MenuBIZ biz = new MenuBIZ();
            return biz.LoadScreenFavorite(username.NVL(String.Empty));            
        }

        public void RemoveScreenFavorite(NZString username, NZString screenCD)
        {
            MenuBIZ biz = new MenuBIZ();
            biz.RemoveScreenFavorite(username.NVL(String.Empty), screenCD.NVL(String.Empty));
        }

        public void AddScreenFavorite(NZString username, NZString screenCD)
        {
            MenuBIZ biz = new MenuBIZ();
            biz.AddScreenFavorite(username.NVL(String.Empty), screenCD.NVL(String.Empty));
        }        
    }
}
