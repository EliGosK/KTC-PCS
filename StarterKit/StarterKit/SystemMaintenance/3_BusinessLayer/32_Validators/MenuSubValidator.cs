using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using SystemMaintenance.BIZ;

namespace SystemMaintenance.Validators
{
    public class MenuSubValidator
    {
        /// <summary>
        /// Check menu sub code is empty.
        /// </summary>
        /// <param name="menuSubCD"></param>
        /// <returns></returns>
        public ErrorItem CheckMenuSubCode(NZString menuSubCD) {
            if (menuSubCD.IsNull)
                return new ErrorItem(menuSubCD.Owner, Messages.eValidate.VLM9014.ToString());

            return null;
        }

        /// <summary>
        /// Check menu sub name is empty.
        /// </summary>
        /// <param name="menuSubName"></param>
        /// <returns></returns>
        public ErrorItem CheckMenuSubName(NZString menuSubName) {
            if (menuSubName.IsNull)
                return new ErrorItem(menuSubName.Owner, Messages.eValidate.VLM9015.ToString());

            return null;
        }


        #region Business Validator
        /// <summary>
        /// Check data before save add.
        /// </summary>
        /// <param name="menuSubCD"></param>
        /// <param name="menuSubName"></param>
        /// <exception cref="EVOFramework.ValidateException"><c>ValidateException</c>.</exception>
        /// <exception cref="BusinessException"><c>BusinessException</c>.</exception>
        public void ValidateBeforeSaveAdd(NZString menuSubCD, NZString menuSubName) {
            ValidateException validateException = new ValidateException();
            ErrorItem errorItem = null;

            errorItem = CheckMenuSubCode(menuSubCD);
            if (errorItem != null)
                validateException.AddError(errorItem);

            errorItem = CheckMenuSubName(menuSubName);
            if (errorItem != null)
                validateException.AddError(errorItem);

            validateException.ThrowIfHasError();

            //~~~~~~~~~~~~~~~

            MenuSubMaintenanceBIZ biz = new MenuSubMaintenanceBIZ();
            if (biz.ExistMenuSub(menuSubCD)) {
                errorItem = new ErrorItem(menuSubCD.Owner, Messages.eValidate.VLM9016.ToString());
                throw new BusinessException(errorItem);
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuSubCD"></param>
        /// <param name="menuSubName"></param>
        /// <exception cref="EVOFramework.ValidateException"><c>ValidateException</c>.</exception>        
        public void ValidateBeforeSaveEdit(NZString menuSubCD, NZString menuSubName) {
            ValidateException validateException = new ValidateException();
            ErrorItem errorItem = null;

            errorItem = CheckMenuSubCode(menuSubCD);
            if (errorItem != null)
                validateException.AddError(errorItem);

            errorItem = CheckMenuSubName(menuSubName);
            if (errorItem != null)
                validateException.AddError(errorItem);

            validateException.ThrowIfHasError();
        }
        #endregion
    }
}
