using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using Rubik.DAO;
using Rubik.DTO;

namespace Rubik.BIZ
{
    public class SheetWidthBIZ
    {
        public void SaveColumnWidth(List<SheetWidthDTO> list)
        {
            SheetWidthDAO dao = new SheetWidthDAO(CommonLib.Common.CurrentDatabase);

            if (list.Count > 0)
            {

                dao.ClearColumnWidth(null, list[0]);

                foreach (SheetWidthDTO obj in list)
                {
                    dao.SaveColumnWidth(null, obj);
                }

            }
        }

        public List<SheetWidthDTO> LoadColumnWidth(SheetWidthDTO objWidth)
        {
            SheetWidthDAO dao = new SheetWidthDAO(CommonLib.Common.CurrentDatabase);

            return dao.LoadColumnWidth(null, objWidth);

        }
    }
}
