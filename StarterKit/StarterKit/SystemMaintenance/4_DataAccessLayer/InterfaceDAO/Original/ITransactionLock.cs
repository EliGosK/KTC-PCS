/* Create by: Mr.Teerayut Sinlan
 * Create on: 2009-10-05
 * Company: CSI Groups (Thailand)
 * Group: SI-EVO
 
 *** This generate source code was build for DAO on StarterKit system. ***/
using System;
using System.Collections.Generic;
using System.Text;
using SystemMaintenance.DTO;
using EVOFramework.Database;
using EVOFramework;

namespace SystemMaintenance.DAO
{
    public partial interface ITransactionLockDAO
    {
        #region Basic Operation
        int AddNewOrUpdate(Database database, TransactionLockDTO data);

        int AddNew(Database database, TransactionLockDTO data);

        int UpdateWithoutPK(Database database, TransactionLockDTO data);

        int UpdateWithPK(Database database, TransactionLockDTO data, NZString oldKEY1, NZString oldKEY2);

        int Delete(Database database, NZString KEY1, NZString KEY2);
        #endregion

        #region Check Exists Operation
        bool Exist(Database database, NZString KEY1, NZString KEY2);
        #endregion

        #region Load Operation
        List<TransactionLockDTO> LoadAll(Database database);

        List<TransactionLockDTO> LoadAll(Database database, bool ascending);

        List<TransactionLockDTO> LoadAll(Database database, bool ascending, params TransactionLockDTO.eColumns[] orderByColumns);

        TransactionLockDTO LoadByPK(Database database, NZString KEY1, NZString KEY2);
        #endregion
    }
}

