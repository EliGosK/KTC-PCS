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
    public partial interface IMessageDAO
    {
        #region Basic Operation
        int AddNewOrUpdate(Database database, MessageDTO data);

        int AddNew(Database database, MessageDTO data);

        int UpdateWithoutPK(Database database, MessageDTO data);

        int UpdateWithPK(Database database, MessageDTO data, NZString oldMSG_CD, NZString oldLANG_CD);

        int Delete(Database database, NZString MSG_CD, NZString LANG_CD);
        #endregion

        #region Check Exists Operation
        bool Exist(Database database, NZString MSG_CD, NZString LANG_CD);
        #endregion

        #region Load Operation
        List<MessageDTO> LoadAll(Database database);

        List<MessageDTO> LoadAll(Database database, bool ascending);

        List<MessageDTO> LoadAll(Database database, bool ascending, params MessageDTO.eColumns[] orderByColumns);

        MessageDTO LoadByPK(Database database, NZString MSG_CD, NZString LANG_CD);
        #endregion
    }
}

