using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EVOFramework.Database;
using EVOFramework;
using Rubik.DTO;

namespace Rubik.DAO 
{
    public partial class ItemMachineDAO 
    {
        public List<ItemMachineDTO> LoadItemMachineByItemCD(NZString MasterNo) 
        {
            Database db = m_db;

            DataRequest req = new DataRequest("S_COMMON_LoadItemMachineByItemCD");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_MasterNo", DataType.NVarChar, MasterNo.Value);            

            return db.ExecuteForList<ItemMachineDTO>(req);
        }

        public void DelteItemMachineByItemCD(NZString MasterNo) 
        {
            Database db = m_db;

            DataRequest req = new DataRequest("S_MAS040_DeleteItemMachineByItemCD");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_MasterNo", DataType.NVarChar, MasterNo.Value);
            db.ExecuteNonQuery(req);
        }
    }
}
