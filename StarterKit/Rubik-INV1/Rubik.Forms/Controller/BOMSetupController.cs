using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using Rubik.BIZ;
using Rubik.DTO;
using System.Data;

namespace Rubik.Controller
{
    internal class BOMSetupController
    {
        public List<BOMSetupViewDTO> LoadBOMSetup(NZString ITEM_CD) {
            BOMBIZ biz = new BOMBIZ();

            return biz.LoadBOMSetupView(ITEM_CD);
        }

        public DataTable LoadBOMList() {
            BOMBIZ biz = new BOMBIZ();
            return biz.LoadBOMList();
        }
    }
}
