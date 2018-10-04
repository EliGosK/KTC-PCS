using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using Rubik.DAO;
using EVOFramework.Data;
using Rubik.DTO;
using System.Data;
using CommonLib;

namespace Rubik.BIZ
{
    public class InventoryTransBIZ
    {
        /// <summary>
        /// Load All Transaction
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable LoadAllIssueTransByPeriod(NZDateTime PERIOD_BEGIN_DATE, NZDateTime PERIOD_END_DATE, string ScreenType)
        {
            InventoryTransactionDAO dao = new InventoryTransactionDAO(CommonLib.Common.CurrentDatabase);
            //if (HasSlipNo)
            //{
            //    return dao.LoadAllIssueTransByPeriodWithSlipNoNotNull(null, PERIOD_BEGIN_DATE, PERIOD_END_DATE);
            //}
            return dao.LoadAllIssueTransByPeriod(null, PERIOD_BEGIN_DATE, PERIOD_END_DATE, ScreenType);
        }

        public InventoryTransactionDTO LoadByTransactionID(NZString transactionID)
        {
            InventoryTransactionDAO dao = new InventoryTransactionDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadByPK(null, transactionID);
        }

        public InventoryTransactionDTO LoadByRefNoAndTransType(NZString transactionID, NZString transType)
        {
            InventoryTransactionDAO dao = new InventoryTransactionDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadByRefNoAndTransType(null, transactionID, transType);
        }

        public List<InventoryTransactionDTO> LoadByRefNo(NZString RefNo)
        {
            InventoryTransactionDAO dao = new InventoryTransactionDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadTransactionsByRefNo(null, RefNo);
        }

        public List<InventoryTransactionDTO> LoadConsumptionItemByRefNo(NZString RefNo)
        {
            InventoryTransactionDAO dao = new InventoryTransactionDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadConsumptionItemByRefNo(null, RefNo);
        }

        public List<InventoryTransactionDTO> LoadBySlipNo(NZString SlipNo)
        {
            InventoryTransactionDAO dao = new InventoryTransactionDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadTransactionsBySlipNo(null, SlipNo);
        }

        public List<InventoryTransactionDTO> LoadGroupTransaction(NZString groupTrans)
        {
            InventoryTransactionDAO dao = new InventoryTransactionDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadGroupTransaction(null, groupTrans);
        }
        public List<InventoryTransactionDTO> LoadGroupTransaction(NZString groupTrans, NZString transType)
        {
            InventoryTransactionDAO dao = new InventoryTransactionDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadGroupTransaction(null, groupTrans, transType);
        }
        public InventoryTransactionDTO LoadNGWorkResult(NZString workResultNo)
        {

            InventoryBIZ bizInventory = new InventoryBIZ();
            InventoryTransactionDAO dao = new InventoryTransactionDAO(CommonLib.Common.CurrentDatabase);
            InventoryTransactionDTO dto = dao.LoadNGWorkResult(null, workResultNo);
            return dto;
        }

        public InventoryTransactionDTO LoadReserveResult(NZString workResultNo)
        {

            InventoryBIZ bizInventory = new InventoryBIZ();
            InventoryTransactionDAO dao = new InventoryTransactionDAO(CommonLib.Common.CurrentDatabase);
            InventoryTransactionDTO dto = dao.LoadReserveResult(null, workResultNo);
            return dto;
        }
        /// <summary>
        /// Load adjustment for list in specifiy period date.
        /// </summary>
        /// <param name="PERIOD_BEGIN_DATE"></param>
        /// <param name="PERIOD_END_DATE"></param>
        /// <returns></returns>
        public List<InventoryTransactionViewDTO> LoadAdjustmentList(NZDateTime PERIOD_BEGIN_DATE, NZDateTime PERIOD_END_DATE, bool IncludeOldData)
        {
            InventoryTransactionDAO dao = new InventoryTransactionDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadAdjustList(PERIOD_BEGIN_DATE, PERIOD_END_DATE, IncludeOldData);
            //return dao.LoadTransactionViewByTypeInPeriod(null, PERIOD_BEGIN_DATE, PERIOD_END_DATE,
            //                                             new NZString[]
            //                                                 {
            //                                                     (NZString) DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Adjustment)
            //                                                 });
        }

        public System.Data.DataTable LoadAllShipTransByPeriod(NZDateTime PERIOD_BEGIN_DATE, NZDateTime PERIOD_END_DATE)
        {
            InventoryTransactionDAO dao = new InventoryTransactionDAO(CommonLib.Common.CurrentDatabase);

            return dao.LoadAllShipTransByPeriod(null, PERIOD_BEGIN_DATE, PERIOD_END_DATE);
        }

        public System.Data.DataTable LoadIssueListForEdit(NZString SLIP_NO)
        {
            InventoryTransactionDAO dao = new InventoryTransactionDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadIssueListForEdit(null, SLIP_NO);
        }

        public void DeleteIssueTransaction(NZString TransID, NZString RefNo)
        {
            InventoryBIZ biz = new InventoryBIZ();
            try
            {
                CommonLib.Common.CurrentDatabase.KeepConnection = true;
                CommonLib.Common.CurrentDatabase.BeginTransaction();
                biz.DeleteInventoryTransaction(CommonLib.Common.CurrentDatabase, TransID);
                biz.DeleteInventoryTransaction(CommonLib.Common.CurrentDatabase, RefNo);
                CommonLib.Common.CurrentDatabase.Commit();
            }
            catch (Exception)
            {
                CommonLib.Common.CurrentDatabase.Rollback();
                throw;
            }
        }

        public InventoryTransactionDTO LoadReceiveItemByLot(NZString itemCode, NZString lotNo, NZString locCode)
        {
            InventoryTransactionDAO dao = new InventoryTransactionDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadReceiveItemByLot(CommonLib.Common.CurrentDatabase, itemCode, lotNo, locCode);
        }

        public System.Data.DataTable LoadCostView(List<string> ItemCodes)
        {
            InventoryTransactionDAO dao = new InventoryTransactionDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadCostView(CommonLib.Common.CurrentDatabase, ItemCodes);
        }

        public System.Data.DataTable LoadInjectionMaterialReportTable(NZDateTime BeginDate, NZDateTime EndDate, NZString ItemA, NZString ItemB)
        {
            InventoryTransactionDAO dao = new InventoryTransactionDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadInjectionMaterialReportTable(CommonLib.Common.CurrentDatabase, BeginDate, EndDate, ItemA, ItemB);
        }

        public List<InventoryTransactionDTO> LockRefSlipNumber(NZString RefSlipNumber)
        {
            InventoryTransactionDAO dao = new InventoryTransactionDAO(CommonLib.Common.CurrentDatabase);
            return dao.LockRefSlipNumber(CommonLib.Common.CurrentDatabase, RefSlipNumber);
        }
        public InventoryTransactionDTO LoadShip(NZString TranId)
        {
            InventoryTransactionDAO dao = new InventoryTransactionDAO(CommonLib.Common.CurrentDatabase);
            return dao.loadShip(CommonLib.Common.CurrentDatabase, TranId);
        }

        public DataTable LoadProductionReportList(NZDateTime DateBegin, NZDateTime DateEnd, bool IncludeOldData)
        {
            InventoryTransactionDAO dao = new InventoryTransactionDAO(Common.CurrentDatabase);
            return dao.LoadProductionReportList(DateBegin, DateEnd, IncludeOldData);
        }
        public ProductionReportEntryDTO LoadProductionReport(NZString TransID)
        {
            InventoryTransactionDAO dao = new InventoryTransactionDAO(Common.CurrentDatabase);
            return dao.LoadProductionReport(TransID);
        }
        public DataTable LoadNGTransaction(NZString TransID)
        {
            InventoryTransactionDAO dao = new InventoryTransactionDAO(Common.CurrentDatabase);
            return dao.LoadNGTransaction(TransID);
        }
        public InventoryTransactionDTO LoadConsumptionTransaction(NZString TransClass, NZString RefNo, NZString ItemCD)
        {
            InventoryTransactionDAO dao = new InventoryTransactionDAO(Common.CurrentDatabase);
            return dao.LoadConsumptionTransaction(null, TransClass, RefNo, ItemCD);
        }

        public DataTable LoadPackingList(NZDateTime DateBegin, NZDateTime DateEnd, bool IncludeOldData)
        {
            InventoryTransactionDAO dao = new InventoryTransactionDAO(Common.CurrentDatabase);
            return dao.LoadPackingList(DateBegin, DateEnd, IncludeOldData);
        }
        public PackingEntryDTO LoadPackingByPackingNo(NZString PackingNo)
        {
            InventoryTransactionDAO dao = new InventoryTransactionDAO(Common.CurrentDatabase);
            return dao.LoadPackingByPackingNo(PackingNo);
        }
        public DataTable LoadPackingLotByPackingNo(NZString PackingNo)
        {
            InventoryTransactionDAO dao = new InventoryTransactionDAO(Common.CurrentDatabase);
            return dao.LoadPackingLotByPackingNo(PackingNo);
        }

        public DataTable LoadPackingList(NZString MasterNo, NZString LocCD, NZString LotNo)
        {
            InventoryTransactionDAO dao = new InventoryTransactionDAO(Common.CurrentDatabase);
            return dao.LoadPackingList(MasterNo, LocCD, LotNo);
        }
    }
}
