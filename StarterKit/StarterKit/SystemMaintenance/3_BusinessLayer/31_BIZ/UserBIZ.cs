using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemMaintenance.DTO;
using EVOFramework;
using EVOFramework.Database;
using SystemMaintenance.Validators;
using SystemMaintenance.DAO;
using System.Data;
using SystemMaintenance.SQLServer.DAO;

namespace SystemMaintenance.BIZ
{
    public class UserBIZ
    {
        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int CreateUser(UserDTO data)
        {
            // Validate data
            ValidateException validator = new ValidateException();
            if (data.USER_ACCOUNT.IsNull)
            {
                validator.AddError(data.USER_ACCOUNT.Owner, "VLD001");
            }
            //data.ValidateFieldNotNull()

            validator.ThrowIfHasError();


            // Business Check
            IUserDAO dao = DAOFactory.CreateUserDAO(CommonLib.Common.CurrentDatabase);
            dao.AddNew(null, data);
            return 0;
        }

        /// <summary>
        /// Delete user.
        /// </summary>
        /// <param name="USER_ACCOUNT"></param>
        /// <returns></returns>
        public int DeleteUser(NZString USER_ACCOUNT)
        {
            IUserDAO dao = DAOFactory.CreateUserDAO(CommonLib.Common.CurrentDatabase);
            return dao.DeleteUser(null, USER_ACCOUNT.StrongValue);
        }

        /// <summary>
        /// Change password.
        /// </summary>
        /// <param name="oldUSER_ACCOUNT"></param>
        /// <param name="newPASS"></param>
        /// <returns></returns>
        public int ChangePassword(NZString oldUSER_ACCOUNT, NZString newPASS)
        {
            IUserDAO dao = DAOFactory.CreateUserDAO(CommonLib.Common.CurrentDatabase);
            return dao.ChangePassword(null, oldUSER_ACCOUNT, newPASS, CommonLib.Common.CurrentUserInfomation.UserCD, CommonLib.Common.CurrentUserInfomation.Machine);
        }

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
        /// <exception cref="BusinessException"><c>BusinessException</c>.</exception>
        /// <exception cref="!:EVOFramework.ValidationException"><c>ValidateException</c>.</exception>
        public int UpdateUserProfile(NZString userCD, NZString username, NZString oldPassword, NZString newPassword, NZString confirmNewPassword, NZInt dateFormat, NZInt langCD)
        {
            UserProfileValidator validator = new UserProfileValidator();
            validator.ValidateChangeUserProfile(userCD, username, oldPassword, newPassword, confirmNewPassword, dateFormat, langCD);

            IUserDAO dao = DAOFactory.CreateUserDAO(CommonLib.Common.CurrentDatabase);
            dao.UpdateUserDefaultValue(null, userCD, username, dateFormat, langCD, CommonLib.Common.CurrentUserInfomation.UserCD, CommonLib.Common.CurrentUserInfomation.Machine);
            if (!newPassword.IsNull && !confirmNewPassword.IsNull)
            {
                string encNewPassword = HashUserPassword(userCD.StrongValue, newPassword.StrongValue, true);
                dao.ChangePassword(null, userCD, new NZString(newPassword.Owner, encNewPassword), CommonLib.Common.CurrentUserInfomation.UserCD, CommonLib.Common.CurrentUserInfomation.Machine);
            }

            return 1;
        }

        /// <summary>
        /// Hash username and password to generate encrypted string.
        /// </summary>
        /// <param name="UserCD"></param>
        /// <param name="Password"></param>
        /// <param name="ignoreUsernameCaseSensitive"></param>
        /// <returns></returns>
        public string HashUserPassword(string UserCD, string Password, bool ignoreUsernameCaseSensitive)
        {
            byte[] byteUpper = null;
            byte[] byteLower = null;

            if (!ignoreUsernameCaseSensitive)
            {
                byteUpper = Encryption.MD5EncryptString(UserCD);
                byteLower = byteUpper;
            }
            else
            {
                byteUpper = Encryption.MD5EncryptString(UserCD.ToUpper());
                byteLower = Encryption.MD5EncryptString(UserCD.ToLower());
            }

            byte[] bytePassword = Encryption.MD5EncryptString(Password);

            string strEnc = string.Empty;
            for (int i = 0; i < byteUpper.Length; i++)
            {
                if (!ignoreUsernameCaseSensitive)
                    strEnc += String.Format("{0:X2}", (byte)(byteUpper[i] ^ bytePassword[i]));
                else
                {
                    strEnc += String.Format("{0:X2}", (byte)((byteUpper[i] ^ byteLower[i]) ^ bytePassword[i]));
                }
            }

            return strEnc;
        }

        /// <summary>
        /// Load user information from database.
        /// </summary>
        /// <param name="userCD"></param>
        /// <returns></returns>
        public UserDTO LoadUser(NZString userCD)
        {
            IUserDAO dao = DAOFactory.CreateUserDAO(CommonLib.Common.CurrentDatabase);

            //UserDAO dao = new UserDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadByPK(null, userCD.ToUpper(), userCD.ToLower());
        }

        public List<UserDTO> LoadPersonInCharge()
        {
            IUserDAO dao = DAOFactory.CreateUserDAO(CommonLib.Common.CurrentDatabase);
            UserDAO sDAO = (UserDAO)dao;
            return sDAO.LoadPersonInCharge(null);
        }

        public List<UserDTO> LoadAllUser()
        {
            IUserDAO dao = DAOFactory.CreateUserDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadAll(null);
        }
        public List<UserDTO> LoadAllUserNotInGroup(string GroupCD)
        {
            IUserDAO dao = DAOFactory.CreateUserDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadAllUserNotInGroup(null, true, GroupCD, null);
        }

        public List<UserDTO> LoadUserByGroupCD(string GroupCD)
        {
            IUserDAO dao = DAOFactory.CreateUserDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadAllByGroupCD(null, true, GroupCD, null);
        }
        public int AddNewUser(UserDTO dto)
        {
            UserValidator valUser = new UserValidator();
            if (valUser.ValidateBeforeAdd(dto))
            {
                IUserDAO dao = DAOFactory.CreateUserDAO(CommonLib.Common.CurrentDatabase);
                return dao.AddNew(null, dto);
            }
            return 0;
        }

        public int UpdateUser(UserDTO dto)
        {
            UserValidator valUser = new UserValidator();
            if (valUser.ValidateBeforeUpdate(dto))
            {
                IUserDAO dao = DAOFactory.CreateUserDAO(CommonLib.Common.CurrentDatabase);
                if (dto.PASS.IsNull)
                    return dao.UpdateWithoutPK(null, dto, false);
                return dao.UpdateWithoutPK(null, dto);
            }
            return 0;
        }

        public bool isExistUserAccount(NZString userCD)
        {
            return DAOFactory.CreateUserDAO(CommonLib.Common.CurrentDatabase).Exist_Username(null, userCD.StrongValue);
        }

        internal int RemoveUserFromGroup(UserDTO userDTO)
        {
            return DAOFactory.CreateUserDAO(CommonLib.Common.CurrentDatabase).RemoveUserFromGroup(null, userDTO);
        }

        internal int AddUserToGroup(UserDTO userDTO)
        {
            IUserDAO dao = DAOFactory.CreateUserDAO(CommonLib.Common.CurrentDatabase);
            return dao.AddUserToGroup(null, userDTO);

        }

        public DataTable LoadPermissionTable(string strUserName)
        {
            DataTable dtPermission = null;

            IUserDAO dao = DAOFactory.CreateUserDAO(CommonLib.Common.CurrentDatabase);
            dtPermission = dao.LoadPermissionTable(strUserName);

            return dtPermission;
        }

        public void RegisterMachine(NZString userCD)
        {
            IUserDAO dao = DAOFactory.CreateUserDAO(CommonLib.Common.CurrentDatabase);

            //UserDAO dao = new UserDAO(CommonLib.Common.CurrentDatabase);
            dao.RegisterMachine(null, userCD.ToUpper());
        }
    }
}
