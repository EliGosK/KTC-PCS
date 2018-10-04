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
    public partial interface IScreenLangDAO
    {
        #region Basic Operation
        int AddNewOrUpdate(Database database, ScreenLangDTO data);

        int AddNew(Database database, ScreenLangDTO data);

        int UpdateWithoutPK(Database database, ScreenLangDTO data);

        int UpdateWithPK(Database database, ScreenLangDTO data, NZString oldSCREEN_CD, NZString oldLANG_CD);

        int Delete(Database database, NZString SCREEN_CD, NZString LANG_CD);
        #endregion

        #region Check Exists Operation
        bool Exist(Database database, NZString SCREEN_CD, NZString LANG_CD);
        #endregion

        #region Load Operation
        List<ScreenLangDTO> LoadAll(Database database);

        List<ScreenLangDTO> LoadAll(Database database, bool ascending);

        List<ScreenLangDTO> LoadAll(Database database, bool ascending, params ScreenLangDTO.eColumns[] orderByColumns);

        ScreenLangDTO LoadByPK(Database database, NZString SCREEN_CD, NZString LANG_CD);
        #endregion
    }
}

