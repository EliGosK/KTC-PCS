using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rubik.DAO;
using Rubik.DTO;
using EVOFramework;

namespace Rubik.BIZ
{
    public class ItemImageBIZ
    {
        public List<ItemImageDTO> LoadAllImage()
        {
            ItemImageDAO dao = new ItemImageDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadAll(null);
        }

        public int AddImage(string ItemCD, byte[] byteArray)
        {
            ItemImageDAO dao = new ItemImageDAO(CommonLib.Common.CurrentDatabase);
            if (dao.Exist(null, new NZString(null, ItemCD)))
                return dao.UpdateWithoutPK(null, ItemCD, byteArray);
            return dao.AddNew(null, ItemCD, byteArray);
        }

        public ItemImageDTO LoadImage(NZString ItemCD)
        {
            ItemImageDAO dao = new ItemImageDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadByPK(null, ItemCD);
        }

        public int DeleteImage(NZString ItemCD)
        {
            ItemImageDAO dao = new ItemImageDAO(CommonLib.Common.CurrentDatabase);
            return dao.Delete(null, ItemCD);
        }
    }
}
