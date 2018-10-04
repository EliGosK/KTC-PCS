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
    public partial interface IClassListDAO
    {      
        #region Basic Operation
        int AddNewOrUpdate(Database database, ClassListDTO data);

        int AddNew(Database database, ClassListDTO data);

        int UpdateWithoutPK(Database database, ClassListDTO data);

        int UpdateWithPK(Database database, ClassListDTO data, NZString oldCLS_INFO_CD, NZString oldCLS_CD);

        int Delete(Database database, NZString CLS_INFO_CD, NZString CLS_CD);
        #endregion

        #region Check Exists Operation
        bool Exist(Database database, NZString CLS_INFO_CD, NZString CLS_CD);
        #endregion

        #region Load Operation
        List<ClassListDTO> LoadAll(Database database);

        List<ClassListDTO> LoadAll(Database database, bool ascending);

        List<ClassListDTO> LoadAll(Database database, bool ascending, params ClassListDTO.eColumns[] orderByColumns);

        ClassListDTO LoadByPK(Database database, NZString CLS_INFO_CD, NZString CLS_CD);
        #endregion
    }
}

