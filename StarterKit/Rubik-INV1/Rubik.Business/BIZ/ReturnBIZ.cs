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
    public class ReturnBIZ
    {
        public DataTable Load_ReturnListEntry(NZString SlipNo, bool IncludeOldData)
        {
            ReturnDAO dao = new ReturnDAO(Common.CurrentDatabase);
            return dao.Load_ReturnListEntry(SlipNo,IncludeOldData);
        }

        public DataTable Load_ReturnProductionList(NZDateTime DateBegin, NZDateTime DateEnd, bool OldData)
        {
            ReturnDAO dao = new ReturnDAO(Common.CurrentDatabase);
            return dao.Load_ReturnProductionList(DateBegin, DateEnd, OldData);
        }

        public void SaveShipmentEntry(Database db, List<InventoryTransactionDTO> addItems, List<InventoryTransactionDTO> updateItems, List<InventoryTransactionDTO> deleteItems)
        {

            InventoryBIZ bizInv = new InventoryBIZ();
            if (addItems != null && addItems.Count > 0)
            {
                bizInv.AddInventoryTransactions(db, addItems, true);
            }

            if (updateItems != null && updateItems.Count > 0)
            {
                bizInv.UpdateInventoryTransactions(db, updateItems);
            }

            if (deleteItems != null && deleteItems.Count > 0)
            {
                bizInv.DeleteInventoryTransactions(db, deleteItems);
            }

        }

        public void UpdateReturnQTY(Database db, NZString TransID, NZDecimal DiffQTY, NZString UpdateBy, NZString UpdateMachine)
        {
            ReturnDAO daoReturn = new ReturnDAO(db);
            daoReturn.UpdateReturnQTY(TransID, DiffQTY, UpdateBy, UpdateMachine);
        }
    }
}
