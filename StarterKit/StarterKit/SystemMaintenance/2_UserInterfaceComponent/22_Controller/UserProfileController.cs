using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using EVOFramework.Data;
using SystemMaintenance.UIDataModel;
using SystemMaintenance.BIZ;
using SystemMaintenance.DTO;

namespace SystemMaintenance.Controller
{
    public class UserProfileController
    {
        public const string C_VAL_MODEL = "UserProfileModel";

        public Map<string, object> LoadUserProfile(NZString userCD) {
            UserProfileUIDM model = new UserProfileUIDM();
            UserBIZ bizUser = new UserBIZ();

            UserDTO dtoUser =  bizUser.LoadUser(userCD);
            model.UserAccount.Value = dtoUser.USER_ACCOUNT.Value;
            model.Username.Value = dtoUser.FULL_NAME.Value;
            model.DefaultDateFormat.Value = dtoUser.DATE_FORMAT.Value;
            model.DefaultLang.Value = dtoUser.LANG_CD.Value;

            Map<string, object> mapData = new Map<string, object>();
            mapData.Put(C_VAL_MODEL, model);

            return mapData;
        }

        /// <summary>
        /// Save modified user profile.
        /// </summary>
        /// <param name="model"></param>
        /// <exception cref="BusinessException"><c>BusinessException</c>.</exception>
        /// <exception cref="Exception"><c>Exception</c>.</exception>
        public void SaveUserProfile(UserProfileUIDM model) {            



            UserBIZ bizUser = new UserBIZ();
            bizUser.UpdateUserProfile(CommonLib.Common.CurrentUserInfomation.UserCD,
                                      model.Username,
                                      model.CurrentPassword, model.Password, model.ConfirmPassword,
                                      new NZInt(null, model.DefaultDateFormat.Value),
                                      new NZInt(null, model.DefaultLang.Value));
                
            
            
        }
    }
}
