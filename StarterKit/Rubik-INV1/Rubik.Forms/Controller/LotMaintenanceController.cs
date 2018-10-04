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
    public class LotMaintenanceController
    {
        internal LotMaintenanceUIDM loaddata(LotMaintenanceUIDM model)
        {
            LotMaintenanceBIZ biz = new LotMaintenanceBIZ();
            LotMaintenanceDTO data = new LotMaintenanceDTO();
            data.Location = model.Location;
            data.Item_NO = model.Item_No;
            data.Item_Name = model.Item_Name;
            data.LOT_NO = model.Lot_No;
            data.ShowReserveLot = model.ShowReserveLot;
            List<LotMaintenanceDTO> ListLot = biz.LoadAll(data);
            model.DATA_VIEW = DTOUtility.ConvertListToDataTable<LotMaintenanceDTO>(ListLot);
            return model;
        }
    }
}
