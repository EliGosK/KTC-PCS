using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SystemMaintenance.DTO;
using EVOFramework;
using SystemMaintenance.SQLServer.DAO;

namespace SystemMaintenance.BIZ
{
    public class RunningNumberBIZ
    {
        /// <summary>
        /// Get Complete Running No
        /// </summary>
        /// <param name="IDName"></param>
        /// <param name="TBName"></param>
        /// <returns></returns>
        public NZString GetCompleteRunningNo(NZString IDName, NZString TBName)
        {
            NZString CompleteRunning = new NZString();
            //  CommonLib.Common.CurrentDatabase.KeepConnection = true;
            //  CommonLib.Common.CurrentDatabase.BeginTransaction(IsolationLevel.Serializable);
            //try
            //{
            if (IDName.IsNull || TBName.IsNull) return CompleteRunning;

            // get data first
            RunningNumberDAO dao = new RunningNumberDAO(CommonLib.Common.CurrentDatabase);
            RunningNumberDTO dto = dao.LoadByPK_UPDLock(null, IDName, TBName);
            if (dto == null) return CompleteRunning;

            // if load success then lock transaction
            //   TransactionLockDAO daoTrans = new TransactionLockDAO(CommonLib.Common.CurrentDatabase);
            //   TransactionLockDTO dtoTrans = new TransactionLockDTO();
            //NZString key1 = new NZString(null, "ISSUE_TRANS_ID");
            //NZString key2 = new NZString(null, "INV_TRANS_TR");
            //if (daoTrans.Exist(null,key1 ,key2 ))
            //{
            //    daoTrans.SelectWithKeys(null, key1, key2);
            //}
            //else
            //{
            //    dtoTrans.KEY1 = key1;
            //    dtoTrans.KEY2 = key2;
            //    dtoTrans.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            //    dtoTrans.CRT_DATE.Value = DateTime.Now;
            //    dtoTrans.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
            //    daoTrans.AddNew(null, dtoTrans);
            //    daoTrans.SelectWithKeys(null, key1, key2);
            //}
            string FormatString = dto.FORMAT.StrongValue;
            int RunningLenght = FormatString.LastIndexOf("X") - FormatString.IndexOf("X") + 1;
            string RunningText = FormatString.Substring(FormatString.IndexOf("X"), RunningLenght);
            NZDecimal NextRunning = dto.NEXTVALUE;
            NZDateTime LastReset = dto.LAST_RESET;

            NZString ResetFlagByDay = dto.RESET_FLAG_DAY;
            NZString ResetFlagByMonth = dto.RESET_FLAG_MONTH;
            NZString ResetFlagByYear = dto.RESET_FLAG_YEAR;

            if (!ResetFlagByDay.IsNull && ResetFlagByDay.StrongValue.ToUpper() == "Y")
            {
                if (!LastReset.IsNull && LastReset.StrongValue.Date != DateTime.Now.Date)
                {
                    NextRunning.Value = 1;
                    dto.LAST_RESET.Value = DateTime.Now;
                }
            }
            else if (!ResetFlagByMonth.IsNull && ResetFlagByMonth.StrongValue.ToUpper() == "Y")
            {
                if (!LastReset.IsNull && LastReset.StrongValue.Month != DateTime.Now.Month)
                {
                    NextRunning.Value = 1;
                    dto.LAST_RESET.Value = DateTime.Now;
                }
            }
            else if (!ResetFlagByYear.IsNull && ResetFlagByYear.StrongValue.ToUpper() == "Y")
            {
                if (!LastReset.IsNull && LastReset.StrongValue.Year != DateTime.Now.Year)
                {
                    NextRunning.Value = 1;
                    dto.LAST_RESET.Value = DateTime.Now;
                }
            }

            string RunningFormat = "{0:";
            for (int i = 0; i < RunningLenght; i++)
            {
                RunningFormat += "0";
            }
            RunningFormat += "}";

            string CompleteRunningNo = string.Format(RunningFormat, NextRunning.StrongValue);

            // replace DD
            if (FormatString.IndexOf("DD") != -1)
            {
                FormatString = FormatString.Replace("DD", DateTime.Now.ToString("dd"));
            }
            // replace MM
            if (FormatString.IndexOf("MM") != -1)
            {
                FormatString = FormatString.Replace("MM", DateTime.Now.ToString("MM"));
            }
            // replace YY
            if (FormatString.IndexOf("YYYY") != -1)
            {
                FormatString = FormatString.Replace("YYYY", DateTime.Now.ToString("yyyy"));
            }
            if (FormatString.IndexOf("YY") != -1)
            {
                FormatString = FormatString.Replace("YY", DateTime.Now.ToString("yy"));
            }

            CompleteRunning.Value = FormatString.Replace(RunningText, CompleteRunningNo);

            // after get running number completet then step up 
            // next running value
            dto.NEXTVALUE.Value = dto.NEXTVALUE.StrongValue + 1;
            dto.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dto.UPD_DATE.Value = DateTime.Now;
            dto.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
            dao.SetNextRunningNoValue(null, dto);
            // daoTrans.DeleteWithKeys(null, key1, key2);
            //   }

            return CompleteRunning;
        }

        public NZString GenerateLotNoPrefix(NZDateTime LotDate)
        {
            NZString strLotNoPrefix = new NZString();

            RunningNumberDAO dao = new RunningNumberDAO(CommonLib.Common.CurrentDatabase);
            strLotNoPrefix = dao.GenerateLotNoPrefix(LotDate);

            return strLotNoPrefix;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strLotNoPrefix"></param>
        /// <param name="strLocationCode"></param>
        /// <param name="strItemCode"></param>
        /// <param name="ReuseZeroQty">Lot ที่ลบทิ้ง สามารถนำมาใช้ใหม่ได้   Ex. Receive Lot 001 , 002 ,003 เข้าไปแล้ว ลบ Lot 003ทิ้ง จะสามารถใช้  Lot003 ซ้ำได้</param>
        /// <returns></returns>
        public NZInt GetLastLotNoRunningBox(NZString strLotNoPrefix, NZString strLocationCode, NZString strItemCode, NZInt ReuseZeroQty)
        {
            NZInt LastRunningNo = new NZInt();

            RunningNumberDAO dao = new RunningNumberDAO(CommonLib.Common.CurrentDatabase);
            LastRunningNo = dao.GetLastLotNoRunningBox(strLotNoPrefix, strLocationCode, strItemCode, ReuseZeroQty);

            return LastRunningNo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="Location"></param>
        /// <param name="itemCode"></param>
        /// <param name="ReuseZeroQty">Lot ที่ลบทิ้ง สามารถนำมาใช้ใหม่ได้   Ex. Receive Lot 001 , 002 ,003 เข้าไปแล้ว ลบ Lot 003ทิ้ง จะสามารถใช้  Lot003 ซ้ำได้</param>
        /// <returns></returns>
        public NZString GetCompleteLotNo(NZDateTime date, NZString Location, NZString itemCode, NZInt ReuseZeroQty)
        {
            NZString strLotNoPrefix = this.GenerateLotNoPrefix(date);
            NZInt iLastRunningNo = this.GetLastLotNoRunningBox(strLotNoPrefix, Location, itemCode, ReuseZeroQty);

            iLastRunningNo.Value = iLastRunningNo.StrongValue + 1;
            string strFinalLotNo = strLotNoPrefix.ToString() + iLastRunningNo.StrongValue.ToString("00");
            return new NZString(null, strFinalLotNo);

        }
    
    }
}
