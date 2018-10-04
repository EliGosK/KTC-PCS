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
    public partial interface ILangDAO
    {        
        #region Basic Operation
        int AddNewOrUpdate(Database database, LangDTO data);

        int AddNew(Database database, LangDTO data);

        int UpdateWithoutPK(Database database, LangDTO data);

        int UpdateWithPK(Database database, LangDTO data, NZString oldLANG_CD);

        int Delete(Database database, NZString LANG_CD);
        #endregion

        #region Check Exists Operation
        bool Exist(Database database, NZString LANG_CD);
        #endregion

        #region Load Operation
        List<LangDTO> LoadAll(Database database);

        List<LangDTO> LoadAll(Database database, bool ascending);

        List<LangDTO> LoadAll(Database database, bool ascending, params LangDTO.eColumns[] orderByColumns);

        LangDTO LoadByPK(Database database, NZString LANG_CD);
        #endregion
    }
}

