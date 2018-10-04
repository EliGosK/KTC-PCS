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
    public partial interface IScreenDetailDAO
    {
        #region Basic Operation
        int AddNewOrUpdate(Database database, ScreenDetailDTO data);

        int AddNew(Database database, ScreenDetailDTO data);

        int UpdateWithoutPK(Database database, ScreenDetailDTO data);

        int UpdateWithPK(Database database, ScreenDetailDTO data, NZString oldSCREEN_CD, NZString oldCONTROL_CD);

        int Delete(Database database, NZString SCREEN_CD, NZString CONTROL_CD);
        #endregion

        #region Check Exists Operation
        bool Exist(Database database, NZString SCREEN_CD, NZString CONTROL_CD);
        #endregion

        #region Load Operation
        List<ScreenDetailDTO> LoadAll(Database database);

        List<ScreenDetailDTO> LoadAll(Database database, bool ascending);

        List<ScreenDetailDTO> LoadAll(Database database, bool ascending, params ScreenDetailDTO.eColumns[] orderByColumns);

        ScreenDetailDTO LoadByPK(Database database, NZString SCREEN_CD, NZString CONTROL_CD);
        #endregion
    }
}

