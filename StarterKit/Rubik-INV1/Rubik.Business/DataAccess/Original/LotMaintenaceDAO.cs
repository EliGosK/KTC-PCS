using System;
using System.Collections.Generic;
using System.Text;
using Rubik.DTO;
using EVOFramework.Database;
using EVOFramework;

namespace Rubik.DAO
{
    public class LotMaintenaceDAO
    {
        private readonly Database m_db;
        public LotMaintenaceDAO(Database db)
        {
            this.m_db = db;
        }
        public List<LotMaintenanceDTO> LoadInventory(Database database, LotMaintenanceDTO data)
        {
            Database db = UseDatabase(database);

            InventoryPeriodDAO periodDao = new InventoryPeriodDAO(db);
            InventoryPeriodDTO periodDto = periodDao.LoadCurrentYearMonth(null);

            StringBuilder sb = new StringBuilder();
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InventoryOnhandDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + InventoryOnhandDTO.eColumns.LOT_NO);
            sb.AppendLine("  ," + InventoryOnhandDTO.eColumns.ON_HAND_QTY);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine("where (LOC_CD = :ORDER_LOC)");
            sb.AppendLine("and (YEAR_MONTH = :YEAR_MONTH)");
            sb.AppendLine("and (ITEM_CD = :ITEM_CD)");
            sb.AppendLine("and (ON_HAND_QTY > 0)");
            sb.AppendLine("and (LOT_NO like :LOT_NO + '%' or :LOT_NO is null)");

            if (!data.ShowReserveLot.NVL(false))
            {
                sb.AppendLine("and (LOT_NO not like '%#R')");
            }

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("ITEM_CD", data.Item_NO.Value);
            req.Parameters.Add("ORDER_LOC", data.Location.Value);
            req.Parameters.Add("LOT_NO", data.LOT_NO.Value);
            req.Parameters.Add("YEAR_MONTH", periodDto.YEAR_MONTH.Value);



            return db.ExecuteForList<LotMaintenanceDTO>(req);
        }

        protected Database UseDatabase(Database specificDB)
        {
            if (specificDB != null)
                return specificDB;

            if (this.m_db != null)
                return this.m_db;

            throw new DataAccessException(ResourceBundle.ALL.S_CANNOT_USE_DB);
        }
    }
}
