using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EVOFramework;
using Rubik.BIZ;
using Rubik.DTO;
using CommonLib;
using System.Data.SqlClient;
using Rubik.UIDataModel;
using EVOFramework.Data;
using SystemMaintenance;
using Rubik.Validators;
using SystemMaintenance.BIZ;

namespace Rubik.Controller
{
    public class DeliveryController
    {
        public List<DeliveryViewDTO> Load_OrderMaintenance(NZDateTime beginPeriod, NZDateTime endPeriod, NZString CustomerCd,NZString Currency,NZString SlipNo)
        {
            DeliveryBIZ biz = new DeliveryBIZ();
            return biz.Load_OrderMaintenance(beginPeriod, endPeriod, CustomerCd, Currency,SlipNo, false);
        }

        public DataTable Load_DeliveryList(NZDateTime beginPeriod, NZDateTime endPeriod)
        {
            DeliveryBIZ biz = new DeliveryBIZ();
            return biz.Load_DeliveryList(beginPeriod, endPeriod, false);
        }

        public DataTable Load_DeliveryOrderListForReturn(NZDateTime DateBegin, NZDateTime DateEnd, NZString ItemCd, NZString ShortName, NZString CustomerCd, NZString Return_Slip_No)
        {
            DeliveryBIZ biz = new DeliveryBIZ();
            return biz.Load_DeliveryOrderListForReturn(DateBegin, DateEnd, ItemCd, ShortName,CustomerCd,Return_Slip_No, false);
        }

        public DataTable Load_OrderList(NZString SlipNo)
        {
            DeliveryBIZ biz = new DeliveryBIZ();
            return biz.Load_OrderList(SlipNo, false);
        }

        public DataTable Load_LotList(NZString SlipNo)
        {
            DeliveryBIZ biz = new DeliveryBIZ();
            return biz.Load_LotList(SlipNo, false);
        }

        public DataTable Load_Invoice(NZString SlipNo)
        {
            DeliveryBIZ biz = new DeliveryBIZ();
            return biz.Load_Invoice(SlipNo, false);
        }

        public List<ActualOnhandViewDTO> Load_LotMaintenance(NZString SlipNo, NZString LocCd, NZString ItemCd, bool IncludeOldData)
        {
            DeliveryBIZ biz = new DeliveryBIZ();
            return biz.Load_LotMaintenance(SlipNo, LocCd, ItemCd, IncludeOldData);
        }
    }
}
