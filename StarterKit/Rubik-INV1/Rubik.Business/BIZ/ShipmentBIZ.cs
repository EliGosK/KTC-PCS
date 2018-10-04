using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SystemMaintenance.BIZ;
using CommonLib;
using EVOFramework;
using EVOFramework.Database;
using Rubik.DAO;
using Rubik.DTO;

namespace Rubik.BIZ
{
    public class ShipmentBIZ
    {
        //public void AddShipmentEntry(List<Rubik.DTO.InventoryTransactionDTO> dtoInvTrnsList)
        //{
        //    CommonLib.Common.CurrentDatabase.KeepConnection = true;
        //    CommonLib.Common.CurrentDatabase.BeginTransaction(IsolationLevel.Serializable);
        //    try
        //    {
        //        InventoryBIZ bizInv = new InventoryBIZ();
        //        RunningNumberBIZ bizRunning = new RunningNumberBIZ();

        //        // Validate Before Add
        //        for (int i = 0; i < dtoInvTrnsList.Count; i++)
        //        {
        //            NZDateTime transDate = dtoInvTrnsList[i].TRANS_DATE;
        //            NZString itemCode = dtoInvTrnsList[i].ITEM_CD;
        //            NZString storedLocationCode = dtoInvTrnsList[i].LOC_CD;
        //            NZString lotNo = dtoInvTrnsList[i].LOT_NO;
        //            NZString inOutType = dtoInvTrnsList[i].IN_OUT_CLS;
        //            NZDecimal Qty = dtoInvTrnsList[i].QTY;
        //            // Check mandatory
        //            if (itemCode.IsNull)
        //            {
        //                ValidateException.ThrowErrorItem(new ErrorItem(null, TKPMessages.eValidate.VLM0005.ToString()));
        //            }
        //            if (storedLocationCode.IsNull)
        //            {
        //                ValidateException.ThrowErrorItem(new ErrorItem(null, TKPMessages.eValidate.VLM0001.ToString()));
        //            }
        //            if (transDate.IsNull)
        //            {
        //                ValidateException.ThrowErrorItem(new ErrorItem(null, TKPMessages.eValidate.VLM0037.ToString()));
        //            }
        //            if (Qty.IsNull || Qty.StrongValue == 0)
        //            {
        //                ValidateException.ThrowErrorItem(new ErrorItem(null, TKPMessages.eValidate.VLM0039.ToString()));
        //            }


        //            // Check transDate is in current period.
        //            InventoryPeriodDAO inventoryPeriodDAO = new InventoryPeriodDAO();
        //            InventoryPeriodDTO inventoryPeriodDTO = inventoryPeriodDAO.LoadCurrentYearMonth(CommonLib.Common.CurrentDatabase);

        //            if (inventoryPeriodDTO == null)
        //            {
        //                ValidateException.ThrowErrorItem(new ErrorItem(transDate.Owner,
        //                                                               TKPMessages.eValidate.VLM0037.ToString()));
        //                return;
        //            }

        //            if (transDate.StrongValue.Date.CompareTo(inventoryPeriodDTO.PERIOD_BEGIN_DATE.StrongValue.Date) < 0
        //                || transDate.StrongValue.Date.CompareTo(inventoryPeriodDTO.PERIOD_END_DATE.StrongValue.Date) > 0)
        //            {
        //                ValidateException.ThrowErrorItem(new ErrorItem(transDate.Owner,
        //                                                               TKPMessages.eValidate.VLM0038.ToString()));
        //                return;
        //            }
        //        }

        //        NZString SlipNo = bizRunning.GetCompleteRunningNo(new NZString(null, "SHIP_SLIP_NO"),
        //                                                                               new NZString(null,
        //                                                                                            "TB_INV_TRANS_TR"));

        //        for (int i = 0; i < dtoInvTrnsList.Count; i++)
        //        {
        //            //dtoInvTrnsList[i].TRANS_ID = bizRunning.GetCompleteRunningNo(new NZString(null, "TRAN_ID"),
        //            //                                                                   new NZString(null,
        //            //                                                                                "TB_INV_TRANS_TR"));
        //            dtoInvTrnsList[i].SLIP_NO = SlipNo;
        //            bizInv.AddInventoryTransactions(CommonLib.Common.CurrentDatabase, dtoInvTrnsList,true);
        //        }
        //        CommonLib.Common.CurrentDatabase.Commit();
        //    }
        //    catch (Exception)
        //    {
        //        CommonLib.Common.CurrentDatabase.Rollback();
        //        throw;
        //    }
        //}

        public DataTable LoadShipList(NZString SlipNo)
        {
            InventoryTransactionDAO dao = new InventoryTransactionDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadShipList(null,SlipNo);
        }

        public void AddShipmentEntry(Database db,List<InventoryTransactionDTO> addItems, List<InventoryTransactionDTO> updateItems, List<InventoryTransactionDTO> deleteItems)
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

        public void UpdateShipmentDetail(Database db,NZString OrderDetailNo, decimal QTY)
        {
            ShipmentDAO_Add daoShipment = new ShipmentDAO_Add();
            daoShipment.UpdateCustomerOrderStatus(db, OrderDetailNo, QTY);
        }
    }
}
