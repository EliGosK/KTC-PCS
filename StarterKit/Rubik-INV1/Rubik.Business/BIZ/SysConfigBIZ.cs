using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rubik.DTO;
using Rubik.DAO;
using EVOFramework;
using EVOFramework.Database;

namespace Rubik.BIZ
{
    public class SysConfigBIZ
    {
        public SysConfigDTO LoadByPK(NZString SYS_GROUP_ID, NZString SYS_KEY)
        {
            SysConfigDAO dao = new SysConfigDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadByPK(null, SYS_GROUP_ID, SYS_KEY);
        }
        public List<SysConfigDTO> LoadData()
        {
            SysConfigDAO dao = new SysConfigDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadAll(null);
        }
        public int UpdateData(SysConfigDTO data)
        {
            SysConfigDAO dao = new SysConfigDAO(CommonLib.Common.CurrentDatabase);
            return dao.UpdateWithoutPK(null, data);
        }

        public DateTime GetDefaultDateForScreen(SysConfigDTO argParam)
        {
            SysConfigDAO dao = new SysConfigDAO(CommonLib.Common.CurrentDatabase);
            return dao.GetDefaultDateForScreen(null, argParam);
        }

        public DateTime GetDefaultDateForScreen_No_Fix(SysConfigDTO argParam)
        {
            SysConfigDAO dao = new SysConfigDAO(CommonLib.Common.CurrentDatabase);
            return dao.GetDefaultDateForScreen_No_Fix(null, argParam);
        }
    }
}
