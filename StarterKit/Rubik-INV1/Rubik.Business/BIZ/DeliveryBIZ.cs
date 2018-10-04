using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Database;
using Rubik.DAO;
using Rubik.DTO;
using CommonLib;
using SystemMaintenance.BIZ;

namespace Rubik.BIZ
{
    public class DeliveryBIZ
    {
        public List<DeliveryViewDTO> Load_OrderMaintenance(NZDateTime DateBegin, NZDateTime DateEnd, NZString CustomerCd, NZString Currency, NZString SlipNo, bool IncludeOldData)
        {
            DeliveryDAO dao = new DeliveryDAO(Common.CurrentDatabase);
            return dao.Load_OrderMaintenance(DateBegin, DateEnd, CustomerCd, Currency, SlipNo, IncludeOldData);
        }

        public DataTable Load_DeliveryList(NZDateTime DateBegin, NZDateTime DateEnd, bool OldData)
        {
            DeliveryDAO dao = new DeliveryDAO(Common.CurrentDatabase);
            return dao.Load_DeliveryList(DateBegin, DateEnd,OldData);
        }

        public DataTable Load_DeliveryOrderListForReturn(NZDateTime DateBegin, NZDateTime DateEnd, NZString ItemCd, NZString ShortName, NZString CustomerCd, NZString Return_Slip_No, bool OldData)
        {
            DeliveryDAO dao = new DeliveryDAO(Common.CurrentDatabase);
            return dao.Load_DeliveryOrderListForReturn(DateBegin, DateEnd,ItemCd,ShortName,CustomerCd,Return_Slip_No, OldData);
        }
        
        public DataTable Load_OrderList(NZString SlipNo, bool OldData)
        {
            DeliveryDAO dao = new DeliveryDAO(Common.CurrentDatabase);
            return dao.Load_OrderList(SlipNo, OldData);
        }

        public DataTable Load_LotList(NZString SlipNo, bool OldData)
        {
            DeliveryDAO dao = new DeliveryDAO(Common.CurrentDatabase);
            return dao.Load_LotList(SlipNo, OldData);
        }

        public DataTable Load_Invoice(NZString SlipNo, bool OldData)
        {
            DeliveryDAO dao = new DeliveryDAO(Common.CurrentDatabase);
            return dao.Load_Invoice(SlipNo, OldData);
        }

        public List<ActualOnhandViewDTO> Load_LotMaintenance(NZString SlipNo, NZString LocCd, NZString ItemCd, bool IncludeOldData)
        {
            DeliveryDAO dao = new DeliveryDAO(Common.CurrentDatabase);
            return dao.Load_LotMaintenance(SlipNo, LocCd, ItemCd, IncludeOldData);
        }

        public int UpdateReceiveHeader(Database db, InventoryTransactionDTO data)
        {
            DeliveryDAO dao = new DeliveryDAO(Common.CurrentDatabase);
            return dao.UpdateReceiveHeader(db,data);
        }
    }
}
