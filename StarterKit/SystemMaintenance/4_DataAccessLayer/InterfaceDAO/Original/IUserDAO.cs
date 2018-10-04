/* Create by: Mr.Teerayut Sinlan
 * Create on: 2009-09-25
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
    public partial interface IUserDAO
    {
        #region Basic Operation
        int AddNewOrUpdate(Database database, UserDTO data);

        int AddNew(Database database, UserDTO data);

        int UpdateWithoutPK(Database database, UserDTO data);

        int UpdateWithPK(Database database, UserDTO data, NZString oldUPPER_USER_ACCOUNT, NZString oldLOWER_USER_ACCOUNT);

        int Delete(Database database, NZString UPPER_USER_ACCOUNT, NZString LOWER_USER_ACCOUNT);
        #endregion

        #region Check Exists Operation
        bool Exist(Database database, NZString UPPER_USER_ACCOUNT, NZString LOWER_USER_ACCOUNT);
        #endregion

        #region Load Operation
        List<UserDTO> LoadAll(Database database);

        List<UserDTO> LoadAll(Database database, bool ascending);

        List<UserDTO> LoadAll(Database database, bool ascending, params UserDTO.eColumns[] orderByColumns);

        UserDTO LoadByPK(Database database, NZString UPPER_USER_ACCOUNT, NZString LOWER_USER_ACCOUNT);
        #endregion
    }
}

