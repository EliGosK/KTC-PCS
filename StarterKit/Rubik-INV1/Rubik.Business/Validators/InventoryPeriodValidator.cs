using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using Rubik.DAO;
using Rubik.DTO;
using Rubik.BIZ;

namespace Rubik.Validators
{
    public class InventoryPeriodValidator
    {
        #region Single Check
        public ErrorItem CheckEmptyYearMonth(NZString YearMonth)
        {
            if (YearMonth.IsNull)
                return new ErrorItem(YearMonth.Owner, TKPMessages.eValidate.VLM0020.ToString());

            return null;
        }

        public ErrorItem CheckEmptyPeriodBeginDate(NZDateTime PeriodBeginDate)
        {
            if (PeriodBeginDate.IsNull)
                return new ErrorItem(PeriodBeginDate.Owner, TKPMessages.eValidate.VLM0021.ToString());

            return null;
        }

        public ErrorItem CheckEmptyPeriodEndDate(NZDateTime PeriodEndDate)
        {
            if (PeriodEndDate.IsNull)
                return new ErrorItem(PeriodEndDate.Owner, TKPMessages.eValidate.VLM0022.ToString());

            return null;
        }

        public ErrorItem CheckPeriodBeginToEndDate(NZDateTime PeriodBeginDate, NZDateTime PeriodEndDate)
        {
            if (PeriodBeginDate.StrongValue > PeriodEndDate.StrongValue)
                return new ErrorItem(PeriodEndDate.Owner, TKPMessages.eValidate.VLM0023.ToString());

            return null;
        }

        public ErrorItem CheckCurrentPeriod(NZString YearMonth)
        {
            InventoryPeriodBIZ biz = new InventoryPeriodBIZ();
            InventoryPeriodDTO dto = biz.LoadCurrentPeriod();
            if (dto.YEAR_MONTH.StrongValue != YearMonth.StrongValue)
            {
                return new ErrorItem(null, TKPMessages.eValidate.VLM0078.ToString());
            }
            return null;
        }
        #endregion


        #region Business Validate
        /// <summary>
        /// check ว่ามีการทำ inventory move หรือยัง
        /// </summary>
        /// <returns></returns>
        public ErrorItem CheckInventoryCurrentPeriod()
        {
            InventoryPeriodBIZ bizInventoryPeriod = new InventoryPeriodBIZ();
            InventoryPeriodDTO dtoInventoryPeriod = bizInventoryPeriod.LoadCurrentPeriod();


            if (IsInDateRange(dtoInventoryPeriod.PERIOD_BEGIN_DATE.StrongValue,
                           dtoInventoryPeriod.PERIOD_END_DATE.StrongValue
                           , CommonLib.Common.GetDatabaseDateTime()))
            {
                return null;
            }
            return new ErrorItem(null, SystemMaintenance.Messages.eInformation.INF9005.ToString());
            //return false;
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

        public void ValidateBeforeSaveUpdate(InventoryPeriodDTO dtoInven)
        {
            ValidateException validateException = new ValidateException();
            ErrorItem errorItem = null;

            #region mandatory check
            errorItem = CheckEmptyYearMonth(dtoInven.YEAR_MONTH);
            if (errorItem != null)
                validateException.AddError(errorItem);

            errorItem = CheckEmptyPeriodBeginDate(dtoInven.PERIOD_BEGIN_DATE);
            if (errorItem != null)
                validateException.AddError(errorItem);

            errorItem = CheckEmptyPeriodEndDate(dtoInven.PERIOD_END_DATE);
            if (errorItem != null)
                validateException.AddError(errorItem);

            errorItem = CheckPeriodBeginToEndDate(dtoInven.PERIOD_BEGIN_DATE, dtoInven.PERIOD_END_DATE);
            if (errorItem != null)
                validateException.AddError(errorItem);

            validateException.ThrowIfHasError();

            //BusinessException businessException = CheckInventPeriod(dtoInven.YEAR_MONTH);
            //if (businessException != null)
            //{
            //    throw businessException;
            //}
            #endregion


        }
        public BusinessException CheckInventPeriod(NZString YearMonth)
        {
            InventoryPeriodDAO dao = new InventoryPeriodDAO(CommonLib.Common.CurrentDatabase);
            if (dao.Exist(null, YearMonth))
            {
                ErrorItem errorItem = new ErrorItem(YearMonth.Owner, TKPMessages.eValidate.VLM0024.ToString());
                return new BusinessException(errorItem);
            }
            return null;
        }
        #endregion

        /// <summary>
        /// Check InventoryMonth ว่า = Current Period ? if No --> error
        /// Check if ใน Current period มี Item Lot ที่ qty <0 ให้ออก Confirm Msg ถามว่าจะทำต่อ?
        /// ถ้าเป้น Rolling Down To Period ต้อง Exist ใน TB_INV_ONHAND_TR
        /// </summary>
        /// <param name="ProcessType"></param>
        /// <param name="YearMonth"></param>
        /// <returns></returns>
        public ErrorItem CheckBeforeRunClosingProcess(eMonthlyCloseProcess ProcessType, NZString YearMonth)
        {
            ErrorItem err = null;
            InventoryOnhandValidator valINV = new InventoryOnhandValidator();

            ValidateException.ThrowErrorItem(CheckCurrentPeriod(YearMonth));

            if (ProcessType == eMonthlyCloseProcess.ROLLING_DOWN)
            {
                int iYM = Convert.ToInt32(YearMonth.StrongValue);
                NZString PreMonth = new DateTime(iYM / 100, iYM % 100, 1).AddMonths(-1).ToString("yyyyMM").ToNZString();
                ValidateException.ThrowErrorItem(valINV.CheckIfExistWithYearMonth(PreMonth));   
            }
            
            err = valINV.CheckIfItemLotHasNegativeQty(YearMonth);

            return err;
        }



        public ErrorItem CheckEmptyBeginDate(NZDateTime PeriodBeginDate)
        {
            if (PeriodBeginDate.IsNull)
                return new ErrorItem(PeriodBeginDate.Owner, TKPMessages.eValidate.VLM0075.ToString());

            return null;
        }
    }
}
