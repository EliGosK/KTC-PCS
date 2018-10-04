using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using SystemMaintenance.BIZ;

namespace SystemMaintenance.Validators
{
    public class MenuFrameValidator
    {
        public ErrorItem CheckExistFavorite(NZString userAccount, NZString screenCD) {
            MenuBIZ biz = new MenuBIZ();
            if (biz.ExistMenuFavorite(userAccount, screenCD)) {
                ErrorItem item = new ErrorItem(null, Messages.eValidate.VLM9017.ToString());
                return item;
            }

            return null;
        }
    }
}
