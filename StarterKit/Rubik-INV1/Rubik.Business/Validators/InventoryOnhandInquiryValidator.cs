using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;

namespace Rubik.Validators
{
    public class InventoryOnhandInquiryValidator
    {
        #region Mandatory Check
        public ErrorItem CheckEmptyBeginDate(NZDateTime date) {
            if (date.IsNull)
                return new ErrorItem(date.Owner, TKPMessages.eValidate.VLM0021.ToString());

            return null;
        }

        public ErrorItem CheckEmptyEndDate(NZDateTime date) {
            if (date.IsNull)
                return new ErrorItem(date.Owner, TKPMessages.eValidate.VLM0022.ToString());

            return null;
        }

        public ErrorItem CheckBetweenDate(NZDateTime fromDate, NZDateTime toDate) {
            if (toDate.StrongValue.Date.CompareTo(fromDate.StrongValue.Date) < 0) {
                return new ErrorItem(toDate.Owner, TKPMessages.eValidate.VLM0023.ToString());
            }

            return null;
        }
        #endregion

        #region Business Validator
        public void ValidatePeriodDateRange(NZDateTime BeginDate, NZDateTime EndDate) {
            ValidateException.ThrowErrorItem(CheckEmptyBeginDate(BeginDate));
            ValidateException.ThrowErrorItem(CheckEmptyEndDate(EndDate));
            ValidateException.ThrowErrorItem(CheckBetweenDate(BeginDate, EndDate));
        }
        #endregion
    }
}
