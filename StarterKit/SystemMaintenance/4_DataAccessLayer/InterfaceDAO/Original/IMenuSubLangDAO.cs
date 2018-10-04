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
    public partial interface IMenuSubLangDAO
    {
        #region Basic Operation
        int AddNewOrUpdate(Database database, MenuSubLangDTO data);

        int AddNew(Database database, MenuSubLangDTO data);

        int UpdateWithoutPK(Database database, MenuSubLangDTO data);

        int UpdateWithPK(Database database, MenuSubLangDTO data, NZString oldLANG_CD, NZString oldMENU_SUB_CD);

        int Delete(Database database, NZString LANG_CD, NZString MENU_SUB_CD);
        #endregion

        #region Check Exists Operation
        bool Exist(Database database, NZString LANG_CD, NZString MENU_SUB_CD);
        #endregion

        #region Load Operation
        List<MenuSubLangDTO> LoadAll(Database database);

        List<MenuSubLangDTO> LoadAll(Database database, bool ascending);

        List<MenuSubLangDTO> LoadAll(Database database, bool ascending, params MenuSubLangDTO.eColumns[] orderByColumns);

        MenuSubLangDTO LoadByPK(Database database, NZString LANG_CD, NZString MENU_SUB_CD);
        #endregion
    }
}

