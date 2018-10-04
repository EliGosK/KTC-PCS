using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Database;
using SystemMaintenance.DTO;

namespace SystemMaintenance.DAO
{
    public partial interface IScreenDetailDAO
    {
        int DeleteByScreenCD(Database database, string ScreenCD);
        void UpdateIsUsed(Database database, ScreenDetailDTO dto);
        void ResetUsageFlag();
    }
}
