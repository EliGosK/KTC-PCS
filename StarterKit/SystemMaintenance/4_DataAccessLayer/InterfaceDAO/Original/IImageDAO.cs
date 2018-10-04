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
    public partial interface IImageDAO
    {        
        #region Basic Operation
        int AddNewOrUpdate(Database database, ImageDTO data);

        int AddNew(Database database, ImageDTO data);

        int UpdateWithoutPK(Database database, ImageDTO data);

        int UpdateWithPK(Database database, ImageDTO data, NZString oldIMAGE_CD);

        int Delete(Database database, NZString IMAGE_CD);
        #endregion

        #region Check Exists Operation
        bool Exist(Database database, NZString IMAGE_CD);
        #endregion

        #region Load Operation
        List<ImageDTO> LoadAll(Database database);

        List<ImageDTO> LoadAll(Database database, bool ascending);

        List<ImageDTO> LoadAll(Database database, bool ascending, params ImageDTO.eColumns[] orderByColumns);

        ImageDTO LoadByPK(Database database, NZString IMAGE_CD);
        #endregion
    }
}

