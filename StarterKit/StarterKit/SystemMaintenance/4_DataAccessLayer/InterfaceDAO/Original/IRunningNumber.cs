/* Create by: Mr.Teerayut Sinlan
 * Create on: 2009-10-01
 * Company: CSI Groups (Thailand)
 * Group: SI-EVO
 
 *** This generate source code was build for DAO on StarterKit system. ***/
using System.Collections.Generic;
using SystemMaintenance.DTO;
using EVOFramework.Database;
using EVOFramework;

namespace SystemMaintenance.DAO
{
    public partial interface IRunningNumberDAO
    {
        #region Basic Operation
        int AddNewOrUpdate(Database database, RunningNumberDTO data);

        int AddNew(Database database, RunningNumberDTO data);

        int UpdateWithoutPK(Database database, RunningNumberDTO data);

        int UpdateWithPK(Database database, RunningNumberDTO data, NZString oldID_NAME, NZString oldTB_NAME);

        int Delete(Database database, NZString ID_NAME, NZString TB_NAME);
        #endregion

        #region Check Exists Operation
        bool Exist(Database database, NZString ID_NAME, NZString TB_NAME);
        #endregion

        #region Load Operation
        List<RunningNumberDTO> LoadAll(Database database);

        List<RunningNumberDTO> LoadAll(Database database, bool ascending);

        List<RunningNumberDTO> LoadAll(Database database, bool ascending, params RunningNumberDTO.eColumns[] orderByColumns);

        RunningNumberDTO LoadByPK_UPDLock(Database database, NZString ID_NAME, NZString TB_NAME);
        #endregion
    }
}

