using EVOFramework;
using EVOFramework.Database;
using System.Data;

namespace SystemMaintenance.InterfaceDAO
{
    public partial interface ITransactionLockDAO
    {
        DataTable SelectWithKeys(Database database, NZString key1
            , NZString key2);
        DataTable SelectWithKeys(Database database, NZString key1
            , NZString key2, NZString key3);
        DataTable SelectWithKeys(Database database, NZString key1
            , NZString key2, NZString key3, NZString key4);
        DataTable SelectWithKeys(Database database, NZString key1
            , NZString key2, NZString key3, NZString key4, NZString key5);

        int DeleteWithKeys(Database database, NZString key1, NZString key2);
        int DeleteWithKeys(Database database, NZString key1, NZString key2, NZString key3);
        int DeleteWithKeys(Database database, NZString key1, NZString key2, NZString key3, NZString key4);
        int DeleteWithKeys(Database database, NZString key1, NZString key2, NZString key3, NZString key4, NZString key5);
    }
}
