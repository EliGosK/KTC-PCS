using System;
using System.Data;
using System.Collections.Generic;
using SystemMaintenance.BIZ;
using SystemMaintenance.DTO;
using SystemMaintenance.SQLServer.DAO;
using Rubik.DAO;
using EVOFramework;
using Rubik.DTO;
using EVOFramework.Database;
using Rubik.Validators;
using CommonLib;

namespace Rubik.BIZ
{
    public class LotMaintenanceBIZ
    {
        public List<LotMaintenanceDTO> LoadAll(LotMaintenanceDTO data)
        {
            LotMaintenaceDAO dao = new LotMaintenaceDAO(CommonLib.Common.CurrentDatabase);


            return dao.LoadInventory(null, data);

        }
    }
}
