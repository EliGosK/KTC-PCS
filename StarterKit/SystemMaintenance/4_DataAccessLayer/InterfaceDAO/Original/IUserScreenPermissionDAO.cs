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
    public partial interface IUserScreenPermissionDAO
    {
        #region Basic Operation
        int AddNewOrUpdate(Database database, UserScreenPermissionDTO data);

        int AddNew(Database database, UserScreenPermissionDTO data);

        int UpdateWithoutPK(Database database, UserScreenPermissionDTO data);

        int UpdateWithPK(Database database, UserScreenPermissionDTO data, NZString oldSCREEN_CD, NZString oldUSER_CD);

        int Delete(Database database, NZString SCREEN_CD, NZString USER_CD);
        #endregion

        #region Check Exists Operation
        bool Exist(Database database, NZString SCREEN_CD, NZString USER_CD);
        #endregion

        #region Load Operation
        List<UserScreenPermissionDTO> LoadAll(Database database);

        List<UserScreenPermissionDTO> LoadAll(Database database, bool ascending);

        List<UserScreenPermissionDTO> LoadAll(Database database, bool ascending, params UserScreenPermissionDTO.eColumns[] orderByColumns);

        UserScreenPermissionDTO LoadByPK(Database database, NZString SCREEN_CD, NZString USER_CD);
        #endregion
    }
}

