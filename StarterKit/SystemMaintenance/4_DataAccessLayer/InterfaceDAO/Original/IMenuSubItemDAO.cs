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
    public partial interface IMenuSubItemDAO
    {
        #region Basic Operation
        int AddNewOrUpdate(Database database, MenuSubItemDTO data);

        int AddNew(Database database, MenuSubItemDTO data);

        int UpdateWithoutPK(Database database, MenuSubItemDTO data);

        int UpdateWithPK(Database database, MenuSubItemDTO data, NZString oldMENU_SUB_CD, NZString oldSCREEN_CD);

        int Delete(Database database, NZString MENU_SUB_CD, NZString SCREEN_CD);
        #endregion

        #region Check Exists Operation
        bool Exist(Database database, NZString MENU_SUB_CD, NZString SCREEN_CD);
        #endregion

        #region Load Operation
        List<MenuSubItemDTO> LoadAll(Database database);

        List<MenuSubItemDTO> LoadAll(Database database, bool ascending);

        List<MenuSubItemDTO> LoadAll(Database database, bool ascending, params MenuSubItemDTO.eColumns[] orderByColumns);

        MenuSubItemDTO LoadByPK(Database database, NZString MENU_SUB_CD, NZString SCREEN_CD);
        #endregion
    }
}

