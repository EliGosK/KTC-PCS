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
    public class DealingBIZ
    {
        #region Load
        public DealingDTO LoadLocation(NZString LOC_CD) {
            DealingDAO dao = new DealingDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadByPK(null, LOC_CD);
        }

        public List<DealingDTO> LoadAllLocations(bool LimitRow)
        {
            DealingDAO dao = new DealingDAO(CommonLib.Common.CurrentDatabase);
            if (LimitRow)
            {
                return dao.LoadAllWithLimit(null, true);
            }
            return dao.LoadAll(null, true);
        }
        public DataTable LoadByLocationType(NZString[] LocationType) 
        {
            DealingDAO dao = new DealingDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadByLocationType(null,LocationType, null, false);
        }

        public DataTable LoadDealingList() {
            DealingDAO dao = new DealingDAO(CommonLib.Common.CurrentDatabase);           
            return dao.LoadDealingList(null , false);
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
        public int SaveNew(DealingDTO data) {
            DealingValidator validator = new DealingValidator();
            validator.ValidateBeforeSaveNew(data);

            DealingDAO dao = new DealingDAO(CommonLib.Common.CurrentDatabase);
            return dao.AddNew(null, data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="EVOFramework.ValidateException"><c>ValidateException</c>.</exception>
        /// <exception cref="EVOFramework.BusinessException"><c>BusinessException</c>.</exception>
        public int SaveUpdate(DealingDTO data) {
            DealingValidator validator = new DealingValidator();
            validator.ValidateBeforeSaveUpdate(data);

            DealingDAO dao = new DealingDAO(CommonLib.Common.CurrentDatabase);
            return dao.UpdateWithoutPK(null, data);
        }
        #endregion

        #region Delete
        public int DeleteLocation(NZString LOC_CD) {
            DealingDAO dao = new DealingDAO(CommonLib.Common.CurrentDatabase);
            return dao.Delete(null, LOC_CD);
        }
        #endregion
    }
}
