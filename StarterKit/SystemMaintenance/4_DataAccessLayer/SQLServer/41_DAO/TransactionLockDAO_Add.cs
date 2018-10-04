using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using System.Data;
using EVOFramework.Database;


namespace SystemMaintenance.SQLServer.DAO
{
    public partial class TransactionLockDAO
    {
        public DataTable SelectWithKeys(Database database, NZString key1, NZString key2)
        {
            Database db = UseDatabase(database);
            string sql =
                @"  SELECT     *
                    FROM       TZ_TRANS_LOCK
                    WHERE     (KEY1 = :KEY1) AND (KEY2 = :KEY2)";
            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("KEY1", DataType.VarChar, key1.StrongValue);
            req.Parameters.Add("KEY2", DataType.VarChar, key2.StrongValue);

            return db.ExecuteQuery(req);
        }
        public DataTable SelectWithKeys(Database database, NZString key1, NZString key2, NZString key3)
        {
            Database db = UseDatabase(database);
            string sql =
                @"  SELECT     *
                    FROM       TZ_TRANS_LOCK
                    WHERE     (KEY1 = :KEY1) 
                    AND       (KEY2 = :KEY2)
                    AND       (KEY3 = :KEY3)";
            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("KEY1", DataType.VarChar, key1.StrongValue);
            req.Parameters.Add("KEY2", DataType.VarChar, key2.StrongValue);
            req.Parameters.Add("KEY3", DataType.VarChar, key3.StrongValue);
            return db.ExecuteQuery(req);
        }
        public DataTable SelectWithKeys(Database database, NZString key1, NZString key2, NZString key3, NZString key4)
        {
            Database db = UseDatabase(database);
            string sql =
                @"  SELECT     *
                    FROM       TZ_TRANS_LOCK
                    WHERE     (KEY1 = :KEY1) 
                    AND       (KEY2 = :KEY2)
                    AND       (KEY3 = :KEY3)
                    AND       (KEY4 = :KEY4)";
            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("KEY1", DataType.VarChar, key1.StrongValue);
            req.Parameters.Add("KEY2", DataType.VarChar, key2.StrongValue);
            req.Parameters.Add("KEY3", DataType.VarChar, key3.StrongValue);
            req.Parameters.Add("KEY4", DataType.VarChar, key4.StrongValue);
            return db.ExecuteQuery(req);
        }
        public DataTable SelectWithKeys(Database database, NZString key1, NZString key2, NZString key3, NZString key4, NZString key5)
        {
            Database db = UseDatabase(database);
            string sql =
                @"  SELECT     *
                    FROM       TZ_TRANS_LOCK
                    WHERE     (KEY1 = :KEY1)
                    AND       (KEY2 = :KEY2)
                    AND       (KEY3 = :KEY3)
                    AND       (KEY4 = :KEY4)
                    AND       (KEY5 = :KEY5)";
            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("KEY1", DataType.VarChar, key1.StrongValue);
            req.Parameters.Add("KEY2", DataType.VarChar, key2.StrongValue);
            req.Parameters.Add("KEY3", DataType.VarChar, key3.StrongValue);
            req.Parameters.Add("KEY4", DataType.VarChar, key4.StrongValue);
            req.Parameters.Add("KEY5", DataType.VarChar, key5.StrongValue);
            return db.ExecuteQuery(req);
        }

        public int DeleteWithKeys(Database database, NZString key1, NZString key2)
        {
            Database db = UseDatabase(database);
            string sql =
                @"  DELETE
                    FROM       TZ_TRANS_LOCK
                    WHERE     (KEY1 = :KEY1) AND (KEY2 = :KEY2)";
            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("KEY1", DataType.VarChar, key1.StrongValue);
            req.Parameters.Add("KEY2", DataType.VarChar, key2.StrongValue);

            return db.ExecuteNonQuery(req);
        }
        public int DeleteWithKeys(Database database, NZString key1, NZString key2, NZString key3)
        {
            Database db = UseDatabase(database);
            string sql =
                @"  DELETE
                    FROM       TZ_TRANS_LOCK
                    WHERE     (KEY1 = :KEY1) 
                    AND       (KEY2 = :KEY2)
                    AND       (KEY3 = :KEY3)";
            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("KEY1", DataType.VarChar, key1.StrongValue);
            req.Parameters.Add("KEY2", DataType.VarChar, key2.StrongValue);
            req.Parameters.Add("KEY3", DataType.VarChar, key3.StrongValue);
            return db.ExecuteNonQuery(req);
        }
        public int DeleteWithKeys(Database database, NZString key1, NZString key2, NZString key3, NZString key4)
        {
            Database db = UseDatabase(database);
            string sql =
                @"  DELETE
                    FROM       TZ_TRANS_LOCK
                    WHERE     (KEY1 = :KEY1) 
                    AND       (KEY2 = :KEY2)
                    AND       (KEY3 = :KEY3)
                    AND       (KEY4 = :KEY4)";
            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("KEY1", DataType.VarChar, key1.StrongValue);
            req.Parameters.Add("KEY2", DataType.VarChar, key2.StrongValue);
            req.Parameters.Add("KEY3", DataType.VarChar, key3.StrongValue);
            req.Parameters.Add("KEY4", DataType.VarChar, key4.StrongValue);
            return db.ExecuteNonQuery(req);
        }
        public int DeleteWithKeys(Database database, NZString key1, NZString key2, NZString key3, NZString key4, NZString key5)
        {
            Database db = UseDatabase(database);
            string sql =
                @"  DELETE
                    FROM       TZ_TRANS_LOCK
                    WHERE     (KEY1 = :KEY1)
                    AND       (KEY2 = :KEY2)
                    AND       (KEY3 = :KEY3)
                    AND       (KEY4 = :KEY4)
                    AND       (KEY5 = :KEY5)";
            DataRequest req = new DataRequest(sql);
            req.Parameters.Add("KEY1", DataType.VarChar, key1.StrongValue);
            req.Parameters.Add("KEY2", DataType.VarChar, key2.StrongValue);
            req.Parameters.Add("KEY3", DataType.VarChar, key3.StrongValue);
            req.Parameters.Add("KEY4", DataType.VarChar, key4.StrongValue);
            req.Parameters.Add("KEY5", DataType.VarChar, key5.StrongValue);
            return db.ExecuteNonQuery(req);
        }
    }
}
