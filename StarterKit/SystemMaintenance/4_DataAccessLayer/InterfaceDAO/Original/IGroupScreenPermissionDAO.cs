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
    public partial interface IGroupScreenPermissionDAO
    {        
        #region Basic Operation
        int AddNewOrUpdate(Database database, GroupScreenPermissionDTO data);

        int AddNew(Database database, GroupScreenPermissionDTO data);

        int UpdateWithoutPK(Database database, GroupScreenPermissionDTO data);

        int UpdateWithPK(Database database, GroupScreenPermissionDTO data, NZString oldSCREEN_CD, NZString oldGROUP_CD);

        int Delete(Database database, NZString SCREEN_CD, NZString GROUP_CD);
        #endregion

        #region Check Exists Operation
        bool Exist(Database database, NZString SCREEN_CD, NZString GROUP_CD);
        #endregion

        #region Load Operation
        List<GroupScreenPermissionDTO> LoadAll(Database database);

        List<GroupScreenPermissionDTO> LoadAll(Database database, bool ascending);

        List<GroupScreenPermissionDTO> LoadAll(Database database, bool ascending, params GroupScreenPermissionDTO.eColumns[] orderByColumns);

        GroupScreenPermissionDTO LoadByPK(Database database, NZString SCREEN_CD, NZString GROUP_CD);
        #endregion
    }
}

