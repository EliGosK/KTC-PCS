
using System.Text;
using EVOFramework;
using EVOFramework.Database;
using System.Data;
using Rubik.DTO;
using System.Collections.Generic;

namespace Rubik.DAO
{
    partial class ItemEquivalentDAO : BaseDAO
    {
        public ItemEquivalentDAO() { }

        public ItemEquivalentDAO(Database db)
        {
            this.m_db = db;
        }


        public List<ItemEquivalentDTO> LoadEquivalentItem(Database database, ItemDTO argItem)
        {
            Database db = UseDatabase(database);

            string sql =
                @"SELECT eq.[ITEM_CD]
                      ,eq.[EQUIVALENT_ITEM_CD]
                      ,eq.[ORDER_LOC_CD]
                      ,eq.[CRT_BY]
                      ,eq.[CRT_DATE]
                      ,eq.[CRT_MACHINE]
                      ,eq.[UPD_BY]
                      ,eq.[UPD_DATE]
                      ,eq.[UPD_MACHINE]
                  FROM [TB_ITEM_EQUIVALENT_MS] eq
                  INNER JOIN [TB_ITEM_MS] it on eq.EQUIVALENT_ITEM_CD = it.ITEM_CD
                  WHERE eq.ITEM_CD = @ITEM_CD";


            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("@ITEM_CD", argItem.ITEM_CD.Value);

            return db.ExecuteForList<ItemEquivalentDTO>(req);
        }


        public List<ItemEquivalentDTO> Load(Database database, ItemDTO argItem)
        {
            Database db = UseDatabase(database);

            string sql =
                @"SELECT eq.[ITEM_CD]
                      ,eq.[EQUIVALENT_ITEM_CD]
                      ,eq.[ORDER_LOC_CD]
                      ,eq.[CRT_BY]
                      ,eq.[CRT_DATE]
                      ,eq.[CRT_MACHINE]
                      ,eq.[UPD_BY]
                      ,eq.[UPD_DATE]
                      ,eq.[UPD_MACHINE]
                  FROM [TB_ITEM_EQUIVALENT_MS] eq
                  WHERE eq.ITEM_CD = @ITEM_CD";


            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("@ITEM_CD", argItem.ITEM_CD.Value);

            return db.ExecuteForList<ItemEquivalentDTO>(req);
        }
    }
}
