using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using SystemMaintenance.BIZ;

namespace SystemMaintenance.Validators
{
    class MenuSetMaintenanceValidator
    {
        internal bool ValidateBeforeAdd(SystemMaintenance.DTO.MenuSetDTO dto)
        {
            ValidateException validateException = new ValidateException();
            ErrorItem errorItem = null;

            errorItem = CheckExistMenuSet(dto.MENU_SET_CD);
            if (errorItem != null)
            {
                validateException.AddError(errorItem);
                throw validateException;
            }

            return true;
        }

        private ErrorItem CheckExistMenuSet(NZString MenuSetCD)
        {
            MenuSetMaintenanceBIZ menuBiz = new MenuSetMaintenanceBIZ();

            if (MenuSetCD.IsNull)
            {
                ErrorItem item = new ErrorItem(MenuSetCD.Owner, Messages.eValidate.VLM9012.ToString());
                return item;
            }

            if (menuBiz.isExistMenuSet(MenuSetCD))
            {
                ErrorItem item = new ErrorItem(MenuSetCD.Owner, Messages.eValidate.VLM9013.ToString());
                return item;
            }

            return null;
        }
    }
}
