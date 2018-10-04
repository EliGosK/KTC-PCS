using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemMaintenance.Oracle.DAO;
using SystemMaintenance.DTO;
using EVOFramework;
using SystemMaintenance.BIZ;
using SystemMaintenance.UIDataModel;

namespace SystemMaintenance.Validators
{
    public class UserProfileValidator
    {
        #region Check Requires
        /// <summary>
        /// Check date format is empty.
        /// </summary>
        /// <param name="dateFormat"></param>
        /// <returns></returns>
        public ErrorItem CheckRequireDefaultDateFormat(NZInt dateFormat) {
            if (dateFormat.IsNull)
                return new ErrorItem(dateFormat.Owner, Messages.eValidate.VLM9005.ToString());

            return null;
        }

        /// <summary>
        /// Check defautl language is empty.
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public ErrorItem CheckRequireDefaultLanguage(NZInt language)
        {
            if (language.IsNull)
                return new ErrorItem(language.Owner, Messages.eValidate.VLM9006.ToString());
            return null;
        }

        /// <summary>
        /// Check username is empty.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public ErrorItem CheckRequireUsername(NZString username)
        {
            if (username.IsNull)
                return new ErrorItem(username.Owner, Messages.eValidate.VLM9003.ToString());
            return null;
        }
        #endregion

        #region Business Check
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userCD"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <param name="confirmNewPassword"></param>
        /// <returns></returns>
        /// <exception cref="BusinessException"><c>BusinessException</c>.</exception>
        public void BizCheckChangePassword(NZString userCD, NZString oldPassword, NZString newPassword, NZString confirmNewPassword) {
//            UserDAO dao = new UserDAO(CommonLib.Common.CurrentDatabase);
            UserBIZ biz = new UserBIZ();
            
            // check old password.
            if (!newPassword.IsNull && !confirmNewPassword.IsNull)
            {
                UserDTO dtoUser = biz.LoadUser(userCD);
                string encPassword = biz.HashUserPassword(userCD.StrongValue, oldPassword.StrongValue, true);
                if (!Equals(encPassword, dtoUser.PASS.StrongValue))
                {

                    ErrorItem error = new ErrorItem(confirmNewPassword.Owner, Messages.eValidate.VLM9010.ToString());
                    throw new BusinessException(error);

                }

                if (!Equals(newPassword.Value, confirmNewPassword.Value))
                {
                    ErrorItem error = new ErrorItem(confirmNewPassword.Owner, Messages.eValidate.VLM9009.ToString());
                    throw new BusinessException(error);
                }
            }
        }
        #endregion

        #region Validation


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userCD"></param>
        /// <param name="username"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <param name="confirmNewPassword"></param>
        /// <param name="dateFormat"></param>
        /// <param name="langCD"></param>
        /// <returns></returns>
        /// <exception cref="EVOFramework.ValidationException"><c>ValidateException</c>.</exception>
        /// <exception cref="EVOFramework.BusinessException"><c>BusinessException</c>.</exception>
        public bool ValidateChangeUserProfile(NZString userCD, NZString username, NZString oldPassword, NZString newPassword, NZString confirmNewPassword, NZInt dateFormat, NZInt langCD)
        {
            ValidateException validateException = new ValidateException();
            ErrorItem errorItem = null;

            errorItem = CheckRequireUsername(username);
            if (errorItem != null) 
                validateException.AddError(errorItem);

            errorItem = CheckRequireDefaultDateFormat(dateFormat);
            if (errorItem != null)
                validateException.AddError(errorItem);

            errorItem = CheckRequireDefaultLanguage(langCD);
            if (errorItem != null)
                validateException.AddError(errorItem);

            validateException.ThrowIfHasError();


            //==== Business Checker
            BizCheckChangePassword(userCD, oldPassword, newPassword, confirmNewPassword);

            return true;
        }
        #endregion
    }
}
