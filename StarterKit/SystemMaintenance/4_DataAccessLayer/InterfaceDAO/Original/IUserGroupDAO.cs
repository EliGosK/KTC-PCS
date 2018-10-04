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
    public partial interface IUserGroupDAO
    {
        #region Basic Operation
        int AddNewOrUpdate(Database database, UserGroupDTO data);

        int AddNew(Database database, UserGroupDTO data);

        int UpdateWithoutPK(Database database, UserGroupDTO data);

        int UpdateWithPK(Database database, UserGroupDTO data, NZString oldGROUP_CD);

        int Delete(Database database, NZString GROUP_CD);
        #endregion

        #region Check Exists Operation
        bool Exist(Database database, NZString GROUP_CD);
        #endregion

        #region Load Operation
        List<UserGroupDTO> LoadAll(Database database);

        List<UserGroupDTO> LoadAll(Database database, bool ascending);

        List<UserGroupDTO> LoadAll(Database database, bool ascending, params UserGroupDTO.eColumns[] orderByColumns);

        UserGroupDTO LoadByPK(Database database, NZString GROUP_CD);
        #endregion
    }
}

