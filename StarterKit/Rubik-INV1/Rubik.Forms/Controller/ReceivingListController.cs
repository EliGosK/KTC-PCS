using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using Rubik.BIZ;
using Rubik.DTO;
using CommonLib;
using System.Data.SqlClient;

namespace Rubik.Controller
{
    public class ReceivingListController
    {
        public List<InventoryTransactionViewDTO> LoadReceivingList(NZDateTime beginPeriod, NZDateTime endPeriod)
        {
            InventoryBIZ biz = new InventoryBIZ();
            return biz.LoadReceivingList(beginPeriod, endPeriod);
        }

        public void DeleteItem(NZString transactionID)
        {
            try
            {
                InventoryBIZ biz = new InventoryBIZ();

                // for Consumtion item it must delete too
                InventoryTransBIZ bizTran = new InventoryTransBIZ();

                // Delete
                InventoryTransactionDTO dto = bizTran.LoadByTransactionID(transactionID);
                List<InventoryTransactionDTO> listConDTO = bizTran.LoadByRefNo(dto.REF_NO);

                Common.CurrentDatabase.KeepConnection = true;
                Common.CurrentDatabase.BeginTransaction();

                biz.DeleteInventoryTransactions(Common.CurrentDatabase, listConDTO);

                Common.CurrentDatabase.Commit();
            }
            catch (Exception ex)
            {
                Common.CurrentDatabase.Rollback();
                throw ex;
            }
            //biz.DeleteInventoryTransaction(Common.CurrentDatabase, transactionID);

        }

        public void DeleteGroupTransaction(NZString receiveNo)
        {
            try
            {
                InventoryBIZ biz = new InventoryBIZ();
                // for Consumtion item it must delete too
                InventoryTransBIZ bizTran = new InventoryTransBIZ();

                // Delete
                List<InventoryTransactionDTO> listReceive = bizTran.LoadBySlipNo(receiveNo);

                Common.CurrentDatabase.KeepConnection = true;
                Common.CurrentDatabase.BeginTransaction();

                foreach (InventoryTransactionDTO dtoReceive in listReceive)
                {
                    List<InventoryTransactionDTO> listForDelete = bizTran.LoadByRefNo(dtoReceive.REF_NO);


                    biz.DeleteInventoryTransactions(Common.CurrentDatabase, listForDelete);

                }
                Common.CurrentDatabase.Commit();
            }
            catch (Exception ex)
            {
                Common.CurrentDatabase.Rollback();
                throw ex;
            }
        }
    }
}
