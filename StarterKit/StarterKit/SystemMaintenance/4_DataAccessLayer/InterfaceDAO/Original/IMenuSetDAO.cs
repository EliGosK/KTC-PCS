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
    public partial interface IMenuSetDAO
    {
        #region Basic Operation
        int AddNewOrUpdate(Database database, MenuSetDTO data);

        int AddNew(Database database, MenuSetDTO data);

        int UpdateWithoutPK(Database database, MenuSetDTO data);

        int UpdateWithPK(Database database, MenuSetDTO data, NZString oldMENU_SET_CD);

        int Delete(Database database, NZString MENU_SET_CD);
        #endregion

        #region Check Exists Operation
        bool Exist(Database database, NZString MENU_SET_CD);
        #endregion

        #region Load Operation
        List<MenuSetDTO> LoadAll(Database database);

        List<MenuSetDTO> LoadAll(Database database, bool ascending);

        List<MenuSetDTO> LoadAll(Database database, bool ascending, params MenuSetDTO.eColumns[] orderByColumns);

        MenuSetDTO LoadByPK(Database database, NZString MENU_SET_CD);
        #endregion
    }
}

