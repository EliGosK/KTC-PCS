using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using SystemMaintenance.DTO;
using SystemMaintenance.BIZ;

namespace SystemMaintenance.Validators
{
    public class UserGroupValidator
    {
        public bool ValidateBeforeAdd(UserGroupDTO usergroupDTO)
        {
            ValidateException validateException = new ValidateException();
            ErrorItem errorItem = null;

            errorItem = CheckExistGroupCD(usergroupDTO.GROUP_CD);
            if (errorItem != null)
            {
                validateException.AddError(errorItem);
                throw validateException;
            }

            errorItem = CheckUserName(usergroupDTO.GROUP_NAME);
            if (errorItem != null)
            {
                validateException.AddError(errorItem);
                throw validateException;
            }

            
            return true;
        }

        private ErrorItem CheckUserName(NZString GroupName)
        {
            if (GroupName.IsNull)
            {
                ErrorItem item = new ErrorItem(GroupName.Owner, Messages.eValidate.VLM9003.ToString());
                return item;
            }

            return null;
        }
        public ErrorItem CheckExistGroupCD(NZString GroupCD)
        {
            UserGroupBIZ userBiz = new UserGroupBIZ();

            if (GroupCD.IsNull)
            {
                ErrorItem item = new ErrorItem(GroupCD.Owner, Messages.eValidate.VLM9011.ToString());
                return item;
            }

            if (userBiz.isExistGroupCD(GroupCD))
            {
                ErrorItem item = new ErrorItem(GroupCD.Owner, Messages.eValidate.VLM9001.ToString());
                return item;
            }

            return null;
        }
    }
}
