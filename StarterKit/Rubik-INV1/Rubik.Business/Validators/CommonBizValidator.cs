using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using Rubik.BIZ;
using Rubik.DTO;

namespace Rubik.Validators
{
    public class CommonBizValidator
    {
        #region Check Lot Control
        /// <summary>
        /// Use for Check Lot Control
        /// 1. Load Lot Control Class from Item MS
        /// 2. If Lot Control is NO then check if it is "SCRAP", "DUMMY" or "RECYCLE"
        /// 3. If Lot Control is YES then check if it is empty or not exist
        /// </summary>
        /// <param name="itemCode">Item Code</param>
        /// <param name="locCode">Location Code</param>
        /// <param name="lotNo">Lot No</param>
        /// <param name="isCheckExist">Is Check Lot Exist</param>
        /// <returns></returns>
        public ErrorItem CheckInputLot(NZString itemCode, NZString locCode, NZString lotNo, bool isCheckExist)
        {
            ItemBIZ biz = new ItemBIZ();
            ItemDTO dto = biz.LoadItem(itemCode);

            //switch (DataDefine.ConvertValue2Enum<DataDefine.eLOT_CONTROL_CLS>(dto.LOT_CONTROL_CLS.StrongValue))
            //{
            //    case DataDefine.eLOT_CONTROL_CLS.No:
            //        // if lot control is no then check if it not empty or not "SCRAP", "DUMMY", "RECYCLE", "SUPP"
            //        if (!lotNo.IsNull || lotNo.StrongValue != string.Empty)
            //        {
            //            string supplyLot = DataDefine.LOT_SUPPLIER;

            //            if (lotNo.StrongValue != DataDefine.LOT_SCRAP &&
            //                lotNo.StrongValue != DataDefine.LOT_DUMMY &&
            //                //lotNo.StrongValue != DataDefine.LOT_SUPPLIER &&
            //                lotNo.StrongValue != DataDefine.LOT_RECYCLE)
            //            {
            //                return new ErrorItem(lotNo.Owner, TKPMessages.eValidate.VLM0065.ToString());
            //            }
            //        }
            //        break;
            //    case DataDefine.eLOT_CONTROL_CLS.Yes:
            //        if (lotNo.IsNull || lotNo.StrongValue.Trim() == String.Empty)
            //        {
            //            return new ErrorItem(lotNo.Owner, TKPMessages.eValidate.VLM0050.ToString(), new object[] { itemCode.StrongValue });
            //        }
            //        break;
            //    case DataDefine.eLOT_CONTROL_CLS.Partial:
            //        break;
            //}

            //if (isCheckExist)
            //{
            //    InventoryBIZ bizInv = new InventoryBIZ();
            //    List<InventoryOnhandDTO> dtolist = new List<InventoryOnhandDTO>();
            //    dtolist = bizInv.LoadLotNoByKey(itemCode, locCode, lotNo);
            //    if (dtolist == null || dtolist.Count == 0)
            //    {
            //        return new ErrorItem(lotNo.Owner, TKPMessages.eValidate.VLM0054.ToString(), new[] { lotNo.StrongValue });
            //    }
            //}
            return null;
        }
        #endregion
    }
}
