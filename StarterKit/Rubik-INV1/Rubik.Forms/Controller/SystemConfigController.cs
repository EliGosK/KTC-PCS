using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rubik.BIZ;
using System.Data;
using EVOFramework;
using Rubik.DTO;
using Rubik.UIDataModel;
using EVOFramework.Data;


namespace Rubik.Controller
{
    public class SystemConfigController
    {
        internal SystemConfigurationUIDM LoadSysConfig()
        {
            SystemConfigurationUIDM model = new SystemConfigurationUIDM();
            SysConfigBIZ biz = new SysConfigBIZ();
            List<SysConfigDTO> listConfig = biz.LoadData();
            model.DATA_VIEW = DTOUtility.ConvertListToDataTable<SysConfigDTO>(listConfig);
            return model;
        }

        internal int UpdateConfig(SysConfigDTO data)
        {
            SysConfigBIZ biz = new SysConfigBIZ();
            return biz.UpdateData(data);

        }
        internal int UpdateConfig(SystemConfigurationUIDM sysUIDM)
        {
            SysConfigDTO data = new SysConfigDTO();
            data.SYS_GROUP_ID = sysUIDM.SysGroupId;
            data.SYS_KEY = sysUIDM.SysKey;
            data.CHAR_DATA = sysUIDM.ChrData;
            int checkUpdate = UpdateConfig(data);
            return checkUpdate;
        }
    }
}
