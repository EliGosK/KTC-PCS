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
    public partial interface IMenuSetDetailDAO
    {
        #region Basic Operation
        int AddNewOrUpdate(Database database, MenuSetDetailDTO data);

        int AddNew(Database database, MenuSetDetailDTO data);

        int UpdateWithoutPK(Database database, MenuSetDetailDTO data);

        int UpdateWithPK(Database database, MenuSetDetailDTO data, NZString oldMENU_SUB_CD, NZString oldMENU_SET_CD);

        int Delete(Database database, NZString MENU_SUB_CD, NZString MENU_SET_CD);
        #endregion

        #region Check Exists Operation
        bool Exist(Database database, NZString MENU_SUB_CD, NZString MENU_SET_CD);
        #endregion

        #region Load Operation
        List<MenuSetDetailDTO> LoadAll(Database database);

        List<MenuSetDetailDTO> LoadAll(Database database, bool ascending);

        List<MenuSetDetailDTO> LoadAll(Database database, bool ascending, params MenuSetDetailDTO.eColumns[] orderByColumns);

        MenuSetDetailDTO LoadByPK(Database database, NZString MENU_SUB_CD, NZString MENU_SET_CD);
        #endregion
    }
}

