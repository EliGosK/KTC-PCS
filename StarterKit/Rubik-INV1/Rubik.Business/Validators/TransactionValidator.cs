using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using Rubik.BIZ;
using Rubik.DTO;

namespace Rubik.Validators
{
    public class TransactionValidator
    {

        /// <summary>
        /// Check if Transaction can edit or delete?
        /// </summary>
        /// <param name="transactionID"></param>
        /// <returns></returns>
        public bool TransactionCanEditOrDelete(NZString transactionID)
        {
            InventoryTransBIZ bizInventoryTrans = new InventoryTransBIZ();

            InventoryTransactionDTO dtoInventoryTransaction = bizInventoryTrans.LoadByTransactionID(transactionID);
            if (dtoInventoryTransaction == null)
                return false;

            ErrorItem err = DateIsInCurrentPeriod(dtoInventoryTransaction.TRANS_DATE.StrongValue);
            if (err == null)
                return true;

            return false;
        }

        /// <summary>
        /// Check if date is between date range?
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="checkDate"></param>
        /// <returns></returns>
        public bool IsInDateRange(DateTime fromDate, DateTime toDate, DateTime checkDate)
        {
            if (checkDate.Date.CompareTo(fromDate.Date) < 0
                || checkDate.Date.CompareTo(toDate.Date) > 0)
                return false;

            return true;
        }

        /// <summary>
        /// Check if date is between date range of current period?
        /// </summary>
        /// <param name="checkDate"></param>
        /// <returns></returns>
        public ErrorItem DateIsInCurrentPeriod(DateTime checkDate)
        {
            InventoryPeriodBIZ bizInventoryPeriod = new InventoryPeriodBIZ();
            InventoryPeriodDTO dtoInventoryPeriod = bizInventoryPeriod.LoadCurrentPeriod();

            if (dtoInventoryPeriod.PERIOD_BEGIN_DATE.StrongValue > checkDate.Date || dtoInventoryPeriod.PERIOD_END_DATE.StrongValue.AddMonths(1).Date < checkDate.Date)
            {
                //return new ErrorItem(null, Message.LoadMessage(TKPMessages.eValidate.VLM0075.ToString()).MessageDescription);
                return new ErrorItem(null, TKPMessages.eValidate.VLM0075.ToString());

            }
            //IsInDateRange(dtoInventoryPeriod.PERIOD_BEGIN_DATE.StrongValue,
            //               dtoInventoryPeriod.PERIOD_END_DATE.StrongValue.AddMonths(1)
            //               , checkDate)
            return null;
        }

        //public ErrorItem CheckExistReceiveItem(NZString itemCode, NZString lotNo)
        //{
        //    InventoryTransBIZ biz = new InventoryTransBIZ();
        //    InventoryTransactionDTO dto = biz.LoadReceiveItemByLot(itemCode, lotNo);
        //    if (dto != null)
        //    {
        //        return new ErrorItem(null,TKPMessages.eValidate.VLM0064.ToString(), new[] { itemCode.StrongValue, lotNo.StrongValue });
        //    }
        //    return null;
        //}
        public ErrorItem CheckExistReceiveItem(NZString itemCode, NZString lotNo, NZString locCode)
        {
            InventoryTransBIZ biz = new InventoryTransBIZ();
            if (lotNo == null || lotNo.StrongValue == string.Empty)
            {
                return null;
            }

            InventoryTransactionDTO dto = biz.LoadReceiveItemByLot(itemCode, lotNo, locCode);
            if (dto != null)
            {
                return new ErrorItem(null, TKPMessages.eValidate.VLM0064.ToString(), new[] { itemCode.StrongValue, lotNo.StrongValue });
            }
            return null;
        }

        public ErrorItem CheckNotExistReceiveItem(NZString itemCode, NZString lotNo, NZString locCode)
        {
            InventoryTransBIZ biz = new InventoryTransBIZ();
            if (lotNo == null || lotNo.StrongValue == string.Empty)
            {
                return null;
            }

            InventoryTransactionDTO dto = biz.LoadReceiveItemByLot(itemCode, lotNo, locCode);
            if (dto == null)
            {
                return new ErrorItem(null, TKPMessages.eValidate.VLM0064.ToString(), new[] { itemCode.StrongValue, lotNo.StrongValue });
            }
            return null;
        }
    }
}
