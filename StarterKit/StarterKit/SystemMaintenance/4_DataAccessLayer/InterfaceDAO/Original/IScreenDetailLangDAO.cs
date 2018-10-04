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
    public partial interface IScreenDetailLangDAO
    {
        #region Basic Operation
        int AddNewOrUpdate(Database database, ScreenDetailLangDTO data);

        int AddNew(Database database, ScreenDetailLangDTO data);

        int UpdateWithoutPK(Database database, ScreenDetailLangDTO data);

        int UpdateWithPK(Database database, ScreenDetailLangDTO data, NZString oldCONTROL_CD, NZString oldLANG_CD, NZString oldSCREEN_CD);

        int Delete(Database database, NZString CONTROL_CD, NZString LANG_CD, NZString SCREEN_CD);
        #endregion

        #region Check Exists Operation
        bool Exist(Database database, NZString CONTROL_CD, NZString LANG_CD, NZString SCREEN_CD);
        #endregion

        #region Load Operation
        List<ScreenDetailLangDTO> LoadAll(Database database);

        List<ScreenDetailLangDTO> LoadAll(Database database, bool ascending);

        List<ScreenDetailLangDTO> LoadAll(Database database, bool ascending, params ScreenDetailLangDTO.eColumns[] orderByColumns);

        ScreenDetailLangDTO LoadByPK(Database database, NZString CONTROL_CD, NZString LANG_CD, NZString SCREEN_CD);
        #endregion
    }
}

