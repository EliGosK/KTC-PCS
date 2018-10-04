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
    public partial interface IMenuFavoriteDAO
    {        
        #region Basic Operation
        int AddNewOrUpdate(Database database, MenuFavoriteDTO data);

        int AddNew(Database database, MenuFavoriteDTO data);

        int UpdateWithoutPK(Database database, MenuFavoriteDTO data);

        int UpdateWithPK(Database database, MenuFavoriteDTO data, NZString oldUSER_ACCOUNT, NZString oldSCREEN_CD);

        int Delete(Database database, NZString USER_ACCOUNT, NZString SCREEN_CD);
        #endregion

        #region Check Exists Operation
        bool Exist(Database database, NZString USER_ACCOUNT, NZString SCREEN_CD);
        #endregion

        #region Load Operation
        List<MenuFavoriteDTO> LoadAll(Database database);

        List<MenuFavoriteDTO> LoadAll(Database database, bool ascending);

        List<MenuFavoriteDTO> LoadAll(Database database, bool ascending, params MenuFavoriteDTO.eColumns[] orderByColumns);

        MenuFavoriteDTO LoadByPK(Database database, NZString USER_ACCOUNT, NZString SCREEN_CD);
        #endregion
    }
}

