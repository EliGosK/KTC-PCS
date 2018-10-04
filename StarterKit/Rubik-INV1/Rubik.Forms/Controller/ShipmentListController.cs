using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLib;
using EVOFramework;
using Rubik.BIZ;
using Rubik.DTO;

namespace Rubik.Controller
{
   public class ShipmentListController
    {
       internal System.Data.DataTable LoadAllShipTransByPeriod(NZDateTime PERIOD_BEGIN_DATE, NZDateTime PERIOD_END_DATE)
        {
            InventoryTransBIZ biz = new InventoryTransBIZ();
            return biz.LoadAllShipTransByPeriod(PERIOD_BEGIN_DATE, PERIOD_END_DATE);
        }

       public void DeleteItem(NZString transactionID)
       {
           // if TransactionType = Shipment return, Check stock before delete.
           InventoryTransBIZ inventoryTransBiz = new InventoryTransBIZ();
           InventoryBIZ biz = new InventoryBIZ();

           biz.DeleteInventoryTransaction(Common.CurrentDatabase, transactionID);
       }

       public void DeleteItem_Return(NZString transactionID)
       {
           // if TransactionType = Shipment return, Check stock before delete.
           InventoryTransBIZ inventoryTransBiz = new InventoryTransBIZ();
           InventoryBIZ biz = new InventoryBIZ();

           biz.DeleteInventoryTransaction(Common.CurrentDatabase, transactionID);
       }

       public void DeletePack(NZString transactionID)
       {
           // if TransactionType = Shipment return, Check stock before delete.
           InventoryTransBIZ inventoryTransBiz = new InventoryTransBIZ();
           InventoryBIZ biz = new InventoryBIZ();

           biz.DeleteInventoryPack(Common.CurrentDatabase, transactionID);
       }

       //public void DeleteGroup_Return(NZString SlipNo)
       //{
       //    // if TransactionType = Shipment return, Check stock before delete.
       //    InventoryTransBIZ inventoryTransBiz = new InventoryTransBIZ();
       //    InventoryBIZ biz = new InventoryBIZ();

       //    biz.DeleteInventorySlipNo_Return(Common.CurrentDatabase, SlipNo);
       //}

       public void DeleteOrder(NZString transID)
       {
           // if TransactionType = Shipment return, Check stock before delete.
           InventoryTransBIZ inventoryTransBiz = new InventoryTransBIZ();
           InventoryBIZ biz = new InventoryBIZ();

           biz.DeleteInventoryOrder(Common.CurrentDatabase, transID);
       }

       public void DeleteGroupTransaction(NZString transID)
       {
           InventoryTransBIZ inventoryTransBiz = new InventoryTransBIZ();
           InventoryBIZ biz = new InventoryBIZ();

           biz.DeleteInventoryGroupTrans(Common.CurrentDatabase, transID);
       }

    }
}
