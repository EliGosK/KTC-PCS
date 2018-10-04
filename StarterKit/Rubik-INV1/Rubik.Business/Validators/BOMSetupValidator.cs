using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using Rubik.BIZ;
using Rubik.DTO;

namespace Rubik.Validators
{
    public class BOMSetupValidator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ParentItemCode">Parent of current item which need to check looping.</param>
        /// <param name="ItemCode">ItemCode which will checkinig.</param>
        /// <returns></returns>
        public ErrorItem LoopingUpCheck(NZString ParentItemCode, NZString ItemCode) {
            BOMBIZ biz = new BOMBIZ();
            List<BOMSetupDTO> implosionList = biz.LoadBOMImplosion(ItemCode);
            for (int i = 0; i < implosionList.Count; i++) {
                if (implosionList[i].UPPER_ITEM_CD.Value == ParentItemCode.Value) {
                    ErrorItem item = new ErrorItem(ItemCode.Owner, "MSG CUSTOM", "LoopingUpCheck fail.");
                    return item;
                }
            }

            return null;
        }
    }
}
