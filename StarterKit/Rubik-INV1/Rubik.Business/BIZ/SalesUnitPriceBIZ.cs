using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Data;
using Rubik.DAO;
using System.Data;
using Rubik.DTO;
using Rubik.Validators;
using EVOFramework;

namespace Rubik.BIZ
{
    public class SalesUnitPriceBIZ
    {
        #region Load
        public SalesUnitPriceDTO LoadSalesUnitPrice(NZString ITEM_CD, NZDateTime START_EFFECTIVE_DATE, NZString CURRENCY)
        {
            SalesUnitPriceDAO dao = new SalesUnitPriceDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadByPK(null, new NZInt(null,ITEM_CD.StrongValue), START_EFFECTIVE_DATE, CURRENCY);
        }

        public SalesUnitPriceDTO LoadSalesUnitPriceByPK(NZString ITEM_CD, NZDateTime START_EFFECTIVE_DATE, NZString CURRENCY)
        {
            SalesUnitPriceDAO dao = new SalesUnitPriceDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadSalesUnitPriceByPK(null, ITEM_CD, START_EFFECTIVE_DATE, CURRENCY);
        }

        public List<SalesUnitPriceDTO> LoadAllSalesUnitPrice(bool LimitRow)
        {
            SalesUnitPriceDAO dao = new SalesUnitPriceDAO(CommonLib.Common.CurrentDatabase);
            if (LimitRow)
            {
                return dao.LoadAllWithLimit(null, true);
            }
            return dao.LoadAll(null, true);
        }

        public DataTable LoadSalesUnitPriceList(bool includeOldData, DateTime? priceOnDate)
        {
            SalesUnitPriceDAO dao = new SalesUnitPriceDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadSalesUnitPriceList(null, includeOldData, priceOnDate);
        }

        public SalesUnitPriceDTO getSalesUnitPriceByEffectiveDate(NZString ITEM_CD, NZString CURRENCY, NZDateTime START_EFFECTIVE_DATE)
        {
            SalesUnitPriceDAO dao = new SalesUnitPriceDAO(CommonLib.Common.CurrentDatabase);

            return dao.getSalesUnitPriceByEffectiveDate(null, ITEM_CD, CURRENCY, START_EFFECTIVE_DATE);
        }
        #endregion
        
        #region Save
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="EVOFramework.ValidateException"><c>ValidateException</c>.</exception>
        /// <exception cref="EVOFramework.BusinessException"><c>BusinessException</c>.</exception>
        public int SaveNew(SalesUnitPriceDTO data)
        {
            SalesUnitPriceValidator validator = new SalesUnitPriceValidator();
            validator.ValidateBeforeSaveNew(data);

            SalesUnitPriceDAO dao = new SalesUnitPriceDAO(CommonLib.Common.CurrentDatabase);
            return dao.AddNew(null, data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="EVOFramework.ValidateException"><c>ValidateException</c>.</exception>
        /// <exception cref="EVOFramework.BusinessException"><c>BusinessException</c>.</exception>
        public int SaveUpdate(SalesUnitPriceDTO data)
        {
            SalesUnitPriceValidator validator = new SalesUnitPriceValidator();
            validator.ValidateBeforeSaveUpdate(data);

            SalesUnitPriceDAO dao = new SalesUnitPriceDAO(CommonLib.Common.CurrentDatabase);
            return dao.UpdateWithoutPK(null, data);
        }
        #endregion

        #region Delete
        public int DeleteSalesUnitPrice(NZString ITEM_CD, NZDateTime START_EFFECTIVE_DATE, NZString CURRENCY)
        {
            SalesUnitPriceDAO dao = new SalesUnitPriceDAO(CommonLib.Common.CurrentDatabase);
            return dao.Delete(null, ITEM_CD, START_EFFECTIVE_DATE, CURRENCY);
        }
        #endregion
    }
}
