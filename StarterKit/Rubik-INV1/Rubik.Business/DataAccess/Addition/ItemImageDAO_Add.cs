using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Database;

namespace Rubik.DAO
{
    internal partial class ItemImageDAO
    {
        internal int UpdateWithoutPK(Database database, string ItemCD, byte[] byteArray)
        {
            Database db = UseDatabase(database);
            string sql = @" UPDATE TB_ITEM_IMAGE_MS SET
                                    IMAGE = :IMAGE
                                    WHERE ITEM_CD = :ITEM_CD";
            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("IMAGE", DataType.Binary, byteArray);
            req.Parameters.Add("ITEM_CD", DataType.VarChar, ItemCD);
            return db.ExecuteNonQuery(req);
        }

        internal int AddNew(Database database, string ItemCD, byte[] byteArray)
        {
            Database db = UseDatabase(database);
            string sql = @" INSERT INTO TB_ITEM_IMAGE_MS (ITEM_CD,IMAGE)
                             VALUES(   :ITEM_CD ,   :IMAGE) ";

            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("IMAGE", DataType.Binary, byteArray);
            req.Parameters.Add("ITEM_CD", DataType.VarChar, ItemCD);
            return db.ExecuteNonQuery(req);
        }
    }
}
