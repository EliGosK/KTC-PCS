using EVOFramework;
using SystemMaintenance.Oracle.DAO;
using EVOFramework.Database;
using SystemMaintenance.DTO;
using CommonLib;
using SystemMaintenance.BIZ;

namespace SystemMaintenance.Validators
{
    public class UserValidator
    {
        /// <summary>
        /// <para>Check blank username and found username on database.</para>
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public ErrorItem CheckUsername(NZString username)
        {
            if (username.IsNull)
            {
                ErrorItem item = new ErrorItem(username.Owner, Messages.eValidate.VLM9002.ToString());
                return item;
            }

            UserBIZ userBiz = new UserBIZ();
            UserDTO userDTO = userBiz.LoadUser(username);

            //== Check found specified username.
            if (userDTO == null)
            {
                ErrorItem item = new ErrorItem(username.Owner, Messages.eValidate.VLM9007.ToString());
                return item;
            }
            return null;
        }

        /// <summary>
        /// Check blank password and password is matching with given password.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public ErrorItem CheckPassword(NZString username, NZString password)
        {
            if (password.IsNull)
            {
                ErrorItem item = new ErrorItem(password.Owner, Messages.eValidate.VLM9004.ToString());
                return item;
            }

            // ถ้าต้องการเช็คการเข้ารหัส ให้ปรับเป็น true.
            bool bUseHashPassword = true;

            //== Check password same with stored on database.
            UserBIZ userBiz = new UserBIZ();
            string hashPassword = string.Empty;
            if (bUseHashPassword) {
                hashPassword = userBiz.HashUserPassword(username.StrongValue, password.StrongValue, true);
            } else {
                hashPassword = password.StrongValue;
            }

            UserDTO userDTO = userBiz.LoadUser(username);
            if (hashPassword != userDTO.PASS.StrongValue)
            {
                ErrorItem item = new ErrorItem(password.Owner, Messages.eValidate.VLM9007.ToString());
                return item;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="BusinessException"><c>BusinessException</c>.</exception>
        /// <exception cref="ValidateException"><c>ValidateException</c>.</exception>
        public bool ValidateLogin(NZString username, NZString password)
        {
            ValidateException validateException = new ValidateException();
            ErrorItem errorItem = null;
            errorItem = CheckUsername(username);
            if (errorItem != null)
            {
                validateException.AddError(errorItem);
                throw validateException;
            }

            errorItem = CheckPassword(username, password);
            if (errorItem != null)
            {
                validateException.AddError(errorItem);
                throw validateException;
            }

            validateException.ThrowIfHasError();

            UserBIZ userBiz = new UserBIZ();
            UserDTO userDTO = userBiz.LoadUser(username);

            if (userDTO.FLG_ACTIVE.StrongValue != 1)
            {
                errorItem = new ErrorItem(null, "ERR00001", "Account doesn't activate.");
                throw new BusinessException(errorItem);
            }

            if (userDTO.FLG_RESIGN.StrongValue == 1)
            {
                errorItem = new ErrorItem(null, "ERR00002", "Account has resigned.");
                throw new BusinessException(errorItem);
            }

            return true;
        }

        public bool ValidateBeforeAdd(UserDTO userDTO)
        {
            ValidateException validateException = new ValidateException();
            ErrorItem errorItem = null;

            errorItem = CheckExistUserAccount(userDTO.USER_ACCOUNT);
            if (errorItem != null)
            {
                validateException.AddError(errorItem);
                throw validateException;
            }

            errorItem = CheckUserName(userDTO.FULL_NAME);
            if (errorItem != null)
            {
                validateException.AddError(errorItem);
                throw validateException;
            }

            errorItem = CheckPassword(userDTO.PASS);
            if (errorItem != null)
            {
                validateException.AddError(errorItem);
                throw validateException;
            }

            errorItem = CheckDefaultDateFormat(userDTO.DATE_FORMAT);
            if (errorItem != null)
            {
                validateException.AddError(errorItem);
                throw validateException;
            }

            errorItem = CheckDefaultLang(userDTO.LANG_CD);
            if (errorItem != null)
            {
                validateException.AddError(errorItem);
                throw validateException;
            }

            errorItem = CheckGroupCD(userDTO.GROUP_CD);
            if (errorItem != null)
            {
                validateException.AddError(errorItem);
                throw validateException;
            }
            return true;
        }

        private ErrorItem CheckUserName(NZString UserName)
        {
            if (UserName.IsNull)
            {
                ErrorItem item = new ErrorItem(UserName.Owner, Messages.eValidate.VLM9003.ToString());
                return item;
            }

            return null;
        }

        public bool ValidateBeforeUpdate(UserDTO userDTO)
        {
            ValidateException validateException = new ValidateException();
            ErrorItem errorItem = null;

            //errorItem = CheckPassword(userDTO.PASS);
            //if (errorItem != null)
            //{
            //    validateException.AddError(errorItem);
            //    throw validateException;
            //}

            errorItem = CheckDefaultDateFormat(userDTO.DATE_FORMAT);
            if (errorItem != null)
            {
                validateException.AddError(errorItem);
                throw validateException;
            }

            errorItem = CheckDefaultLang(userDTO.LANG_CD);
            if (errorItem != null)
            {
                validateException.AddError(errorItem);
                throw validateException;
            }

            errorItem = CheckGroupCD(userDTO.GROUP_CD);
            if (errorItem != null)
            {
                validateException.AddError(errorItem);
                throw validateException;
            }
            return true;
        }
        public ErrorItem CheckExistUserAccount(NZString userAccount)
        {
            UserBIZ userBiz = new UserBIZ();

            if (userAccount.IsNull)
            {
                ErrorItem item = new ErrorItem(userAccount.Owner, Messages.eValidate.VLM9002.ToString());
                return item;
            }

            if (userBiz.isExistUserAccount(userAccount))
            {
                ErrorItem item = new ErrorItem(userAccount.Owner, Messages.eValidate.VLM9001.ToString());
                return item;
            }

            return null;
        }

        /// <summary>
        /// check for password can use for create new user
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public ErrorItem CheckPassword(NZString password)
        {
            if (password.IsNull)
            {
                ErrorItem item = new ErrorItem(password.Owner, Messages.eValidate.VLM9004.ToString());
                return item;
            }

            UserBIZ userBiz = new UserBIZ();

            return null;
        }

        public ErrorItem CheckGroupCD(NZString groupCD)
        {
            ErrorItem item = null;
            if (groupCD.IsNull)
            {
                if (groupCD.Owner is EVOFramework.Windows.Forms.EVOComboBox)
                {
                    EVOFramework.Windows.Forms.EVOComboBox cbo = (EVOFramework.Windows.Forms.EVOComboBox)groupCD.Owner;
                    if (cbo.Text != string.Empty)
                    {
                        item = new ErrorItem(groupCD.Owner, Messages.eValidate.VLM9008.ToString());
                        return item;
                    }
                }
            }
            return null;
        }

        public ErrorItem CheckDefaultDateFormat(NZInt DefaultDateFormat)
        {
            if (DefaultDateFormat.IsNull)
            {
                ErrorItem item = null;
                if (DefaultDateFormat.Owner is EVOFramework.Windows.Forms.EVOComboBox)
                {
                    EVOFramework.Windows.Forms.EVOComboBox cbo = (EVOFramework.Windows.Forms.EVOComboBox)DefaultDateFormat.Owner;
                    if (cbo.Text != string.Empty)
                    {
                        item = new ErrorItem(DefaultDateFormat.Owner, Messages.eValidate.VLM9008.ToString());
                        return item;
                    }
                }
                item = new ErrorItem(DefaultDateFormat.Owner, Messages.eValidate.VLM9005.ToString());
                return item;
            }

            return null;
        }

        public ErrorItem CheckDefaultLang(NZString DefaultLang)
        {
            if (DefaultLang.IsNull)
            {
                ErrorItem item = null;
                if (DefaultLang.Owner is EVOFramework.Windows.Forms.EVOComboBox)
                {
                    EVOFramework.Windows.Forms.EVOComboBox cbo = (EVOFramework.Windows.Forms.EVOComboBox)DefaultLang.Owner;
                    if (cbo.Text != string.Empty)
                    {
                        item = new ErrorItem(DefaultLang.Owner, Messages.eValidate.VLM9008.ToString());
                        return item;
                    }
                }
                item = new ErrorItem(DefaultLang.Owner, Messages.eValidate.VLM9006.ToString());
                return item;
            }

            return null;
        }
    }
}
