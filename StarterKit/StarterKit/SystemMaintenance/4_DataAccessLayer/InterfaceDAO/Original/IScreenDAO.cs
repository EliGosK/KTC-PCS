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
    public partial interface IScreenDAO
    {
        #region Basic Operation
        int AddNewOrUpdate(Database database, ScreenDTO data);

        int AddNew(Database database, ScreenDTO data);

        int UpdateWithoutPK(Database database, ScreenDTO data);

        int UpdateWithPK(Database database, ScreenDTO data, NZString oldSCREEN_CD);

        int Delete(Database database, NZString SCREEN_CD);
        #endregion

        #region Check Exists Operation
        bool Exist(Database database, NZString SCREEN_CD);
        #endregion

        #region Load Operation
        List<ScreenDTO> LoadAll(Database database);

        List<ScreenDTO> LoadAll(Database database, bool ascending);

        List<ScreenDTO> LoadAll(Database database, bool ascending, params ScreenDTO.eColumns[] orderByColumns);

        ScreenDTO LoadByPK(Database database, NZString SCREEN_CD);
        #endregion
    }
}

