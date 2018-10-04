using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Database;
using EVOFramework;
using Rubik.DAO;
using Rubik.DTO;
using System.Data;

namespace Rubik.BIZ
{
    public class BOMBIZ
    {
        #region Load
        public List<BOMSetupDTO> LoadBOMExplosion(NZString UPPER_ITEM_CD)
        {
            BOMDAO dao = new BOMDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadBOMExplosion(null, UPPER_ITEM_CD);
        }
        public List<BOMSetupDTO> LoadBOMImplosion(NZString LOWER_ITEM_CD)
        {
            BOMDAO dao = new BOMDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadBOMImplosion(null, LOWER_ITEM_CD);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UPPER_ITEM_CD"></param>
        /// <returns></returns>
        public List<BOMSetupViewDTO> LoadBOMSetupView(NZString UPPER_ITEM_CD)
        {
            BOMDAO dao = new BOMDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadBOMSetup(null, UPPER_ITEM_CD);
        }

        public int GetNextSequenceOfUpperItem(NZString UPPER_ITEM_CD)
        {
            BOMDAO dao = new BOMDAO(CommonLib.Common.CurrentDatabase);
            int maxSeq = dao.LoadMaxSequenceOfUpperItem(null, UPPER_ITEM_CD);
            return maxSeq + 1;
        }

        /// <summary>
        /// Load Child Part With Level Fix
        /// </summary>
        /// <param name="ITEM_CD"></param>
        /// <param name="Level"></param>
        /// <returns></returns>
        public List<BOMSetupViewDTO> LoadChildPartWithLevelFix(NZString ITEM_CD, int Level)
        {
            BOMDAO dao = new BOMDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadChildPartWithLevelFix(null, ITEM_CD, Level);
        }

        public List<BOMSetupViewDTO> LoadBOMByKey(NZString UPPER_ITEM_CD, NZString LOWER_ITEM_CD) {
            BOMDAO dao = new BOMDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadBOMSetup(null, UPPER_ITEM_CD, LOWER_ITEM_CD);
        }

        public DataTable LoadBOMList() {
            BOMDAO dao = new BOMDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadBOMList();
        }

        public ItemProcessDTO LoadLocationandMRPFLag(string strItemCode)
        {
            BOMDAO dao = new BOMDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadLocationandMRPFlag(null, strItemCode);
        }
        #endregion

        #region Add new
        public int AddNew(BOMDTO dto)
        {
            BOMDAO dao = new BOMDAO(CommonLib.Common.CurrentDatabase);
            return dao.AddNew(null, dto);
        }
        #endregion

        #region Update
        public int UpdateWithPK(BOMDTO dto, NZString oldUPPER_ITEM_CD, NZString oldLOWER_ITEM_CD, NZInt oldITEM_SEQ)
        {
            BOMDAO dao = new BOMDAO(CommonLib.Common.CurrentDatabase);
            return dao.UpdateWithPK(null, dto, oldUPPER_ITEM_CD, oldLOWER_ITEM_CD, oldITEM_SEQ);
        }
        #endregion

        #region Delete
        public int Delete(BOMDTO dto)
        {
            BOMDAO dao = new BOMDAO(CommonLib.Common.CurrentDatabase);
            return dao.Delete(null, dto.UPPER_ITEM_CD, dto.LOWER_ITEM_CD, dto.ITEM_SEQ);
        }
        public NZString FindMRPFlag(NZString strMRPFlag)
        {
            BOMDAO dao = new BOMDAO(CommonLib.Common.CurrentDatabase);
            return dao.FindMRPFlag(null, strMRPFlag);
        }
        #endregion

        public string LoadMRPFLag(NZString strMRPFLag)
        {
            BOMDAO dao = new BOMDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadMRPFLag(null, strMRPFLag);
        }

        public List<ComponentUsageDTO> LoadComponentUsage(NZString strMasterNo, NZDecimal decQty) 
        {
            BOMDAO dao = new BOMDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadComponentUsage(null, strMasterNo, decQty);            
        }
    }
}
