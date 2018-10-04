using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using Rubik.DAO;
using Rubik.DTO;

namespace Rubik.Validators
{
    public class DealingValidator
    {
        #region Mandatory Check
        public ErrorItem CheckEmptyLocationCode(NZString LOC_CD) {
            if (LOC_CD.IsNull) 
                return new ErrorItem(LOC_CD.Owner, TKPMessages.eValidate.VLM0001.ToString());

            return null;
        }

        public ErrorItem CheckEmptyLocationName(NZString LOC_NAME)
        {
            if (LOC_NAME.IsNull) 
                return new ErrorItem(LOC_NAME.Owner, TKPMessages.eValidate.VLM0002.ToString());

            return null;
        }

        public ErrorItem CheckEmptyLocationType(NZString LOC_TYPE)
        {
            if (LOC_TYPE.IsNull)
                return new ErrorItem(LOC_TYPE.Owner, TKPMessages.eValidate.VLM0003.ToString());
            return null;
        }

        public ErrorItem CheckEmptyTermOfPayment(NZString LOC_TYPE)
        {
            if (LOC_TYPE.IsNull)
                return new ErrorItem(LOC_TYPE.Owner, TKPMessages.eValidate.VLM0225.ToString());
            return null;
        }

        public ErrorItem CheckInvoicePattern(NZString INVOICE_PATTERN, NZString LOC_TYPE)
        {
            if (LOC_TYPE == "03" || LOC_TYPE == "05")
            {
                if (INVOICE_PATTERN.IsNull)
                    return new ErrorItem(INVOICE_PATTERN.Owner, TKPMessages.eValidate.VLM0226.ToString());
            }
            return null;
        }

        public ErrorItem CheckExistLocationCode(NZString LOC_CD) {
            DealingDAO dao = new DealingDAO(CommonLib.Common.CurrentDatabase);
            if (dao.Exist(null, LOC_CD))
            {
                return new ErrorItem(LOC_CD.Owner, TKPMessages.eValidate.VLM0005.ToString());
            }
            return null;
        }

        public ErrorItem CheckNotExistsLocationCode(NZString LOC_CD) {
            DealingDAO dao = new DealingDAO(CommonLib.Common.CurrentDatabase);
            if (!dao.Exist(null, LOC_CD))
            {
                return new ErrorItem(LOC_CD.Owner, TKPMessages.eValidate.VLM0004.ToString());
            }
            return null;
        }
        #endregion

        #region Business Check
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <exception cref="ValidateException"><c>ValidateException</c>.</exception>
        /// <exception cref="BusinessException"><c>BusinessException</c>.</exception>
        public void ValidateBeforeSaveNew(DealingDTO data) {
            ValidateException validateException = new ValidateException();
            ErrorItem errorItem = null;

            #region mandatory check
            errorItem = CheckEmptyLocationCode(data.LOC_CD);
            if (errorItem != null)
                validateException.AddError(errorItem);

            errorItem = CheckEmptyLocationName(data.LOC_DESC);
            if (errorItem != null)
                validateException.AddError(errorItem);

            errorItem = CheckEmptyLocationType(data.LOC_CLS);
            if (errorItem != null)
                validateException.AddError(errorItem);
            
            validateException.ThrowIfHasError();
            #endregion

            DealingDAO dao = new DealingDAO(CommonLib.Common.CurrentDatabase);
            if (dao.Exist(null, data.LOC_CD)) {
                errorItem = new ErrorItem(data.LOC_CD.Owner, TKPMessages.eValidate.VLM0005.ToString());
                BusinessException businessException = new BusinessException(errorItem);
                throw businessException;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <exception cref="ValidateException"><c>ValidateException</c>.</exception>
        /// <exception cref="BusinessException"><c>BusinessException</c>.</exception>
        public void ValidateBeforeSaveUpdate(DealingDTO data)
        {
            ValidateException validateException = new ValidateException();
            ErrorItem errorItem = null;

            #region mandatory check
            errorItem = CheckEmptyLocationCode(data.LOC_CD);
            if (errorItem != null)
                validateException.AddError(errorItem);

            errorItem = CheckEmptyLocationName(data.LOC_DESC);
            if (errorItem != null)
                validateException.AddError(errorItem);

            errorItem = CheckEmptyLocationType(data.LOC_CLS);
            if (errorItem != null)
                validateException.AddError(errorItem);

            validateException.ThrowIfHasError();
            #endregion

            DealingDAO dao = new DealingDAO(CommonLib.Common.CurrentDatabase);
            if (false == dao.Exist(null, data.LOC_CD))
            {
                errorItem = new ErrorItem(data.LOC_CD.Owner, TKPMessages.eValidate.VLM0004.ToString());
                BusinessException businessException = new BusinessException(errorItem);
                throw businessException;
            }
        }

        public ErrorItem ValidateBeforeDelete(NZString LOC_CD)
        {
            //ValidateException validateException = new ValidateException();
            //ErrorItem errorItem = null;

            DealingDAO dao = new DealingDAO(CommonLib.Common.CurrentDatabase);
            string returnString = dao.ValidateBeforeDelete(null, LOC_CD);
            if (returnString == null)
            {
                return null;
            }
            else
            {
                return new ErrorItem(LOC_CD.Owner, returnString);
            }
        }

        #endregion
    }
}
