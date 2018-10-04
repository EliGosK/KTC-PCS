using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rubik.DTO;
using EVOFramework;
using Rubik.DAO;

namespace Rubik.Validators
{
    public class SalesUnitPriceValidator
    {
        public ErrorItem CheckEmptyMasterNo(NZString MasterNo)
        {
            if (MasterNo.IsNull)
                return new ErrorItem(MasterNo.Owner, TKPMessages.eValidate.VLM0166.ToString());
            return null;
        }
        public ErrorItem CheckEmptyStartEffeciveDate(NZDateTime StartEffiveDate)
        {
            if (StartEffiveDate.IsNull)
                return new ErrorItem(StartEffiveDate.Owner, TKPMessages.eValidate.VLM0167.ToString());
            return null;
        }
        public ErrorItem CheckEmptyCurrency(NZString Currency)
        {
            if (Currency.IsNull)
                return new ErrorItem(Currency.Owner, TKPMessages.eValidate.VLM0168.ToString());
            return null;
        }
        public ErrorItem CheckEmptyPrice(NZDecimal Price)
        {
            if (Price.IsNull)
            {
                return new ErrorItem(Price.Owner, TKPMessages.eValidate.VLM0169.ToString());
            }

            if (Price.NVL(0) == 0)
            {
                return new ErrorItem(Price.Owner, TKPMessages.eValidate.VLM0220.ToString());
            }
            return null;
        }

        public BusinessException CheckSalesUnitPriceExist(NZString ItemCD, NZDateTime StartEffectiveDate, NZString Currency)
        {
            SalesUnitPriceDAO dao = new SalesUnitPriceDAO(CommonLib.Common.CurrentDatabase);
            if (dao.Exist(null, ItemCD, StartEffectiveDate, Currency))
            {
                ErrorItem errorItem = new ErrorItem(ItemCD.Owner, TKPMessages.eValidate.VLM0165.ToString());
                return new BusinessException(errorItem);
            }
            return null;
        }

        public void ValidateBeforeSaveNew(SalesUnitPriceDTO dto)
        {
            BusinessException businessException = CheckSalesUnitPriceExist(dto.ITEM_CD, dto.START_EFFECTIVE_DATE, dto.CURRENCY);
            if (businessException != null)
            {
                throw businessException;
            }
        }

        public void ValidateBeforeSaveUpdate(SalesUnitPriceDTO dto)
        {

        }
    }
}
