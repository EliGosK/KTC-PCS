using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rubik.DTO;
using Rubik.DAO;
using EVOFramework;

namespace Rubik.BIZ
{
    public class WorkingCalendarBIZ
    {
        #region properties
        private WorkingCalendarDAO m_DAOWorkingCalendar;
        #endregion

        #region constructor
        public WorkingCalendarBIZ()
        {
            m_DAOWorkingCalendar = new WorkingCalendarDAO();
        }
        #endregion

        #region public method
        public WorkingCalendarDTO GetLastGeneratedCalendar()
        {
            return m_DAOWorkingCalendar.LoadByLastUpdate(CommonLib.Common.CurrentDatabase);
        }
        public WorkingCalendarDTO GetFirstGeneratedCalendar()
        {
            return m_DAOWorkingCalendar.LoadByFirstUpdate(CommonLib.Common.CurrentDatabase);
        }
        public WorkingCalendarDTO GetTargetMonthCalendar(DateTime period)
        {
            return m_DAOWorkingCalendar.LoadByPK(CommonLib.Common.CurrentDatabase, period);
        }
        public void UpdateWorkingCalendar(WorkingCalendarDTO wkDTO)
        {
            m_DAOWorkingCalendar.UpdateWithPK(CommonLib.Common.CurrentDatabase, wkDTO, wkDTO.PERIOD);
        }
        public void CreateWorkingCalendar(int iNoOfMonth, DateTime dtmSelectedMonth, bool[] bStopingDay)
        {
            WorkingCalendarDTO[] dtoArrayWK = new WorkingCalendarDTO[iNoOfMonth];
            for (int i = 0; i < iNoOfMonth; i++, dtmSelectedMonth = dtmSelectedMonth.AddMonths(1))
            {
                // สร้าง calendar string เพื่อกำหนดให้ DTO
                StringBuilder calendarStringBuilder = new StringBuilder();
                DayOfWeek dayOfWeekEnum = dtmSelectedMonth.DayOfWeek;
                for (int iDay = 0; iDay < 31; iDay++, dayOfWeekEnum++)
                {
                    if (iDay < DateTime.DaysInMonth(dtmSelectedMonth.Year, dtmSelectedMonth.Month))
                    {
                        string s = (bStopingDay[(int)dayOfWeekEnum]) ? "0" : "1";
                        calendarStringBuilder.Append(s);
                    }
                    else
                        calendarStringBuilder.Append(" ");

                    if ((int)dayOfWeekEnum + 1 >= 7)
                        dayOfWeekEnum -= 7;
                }

                dtoArrayWK[i] = GenerateWorkingCalendarDTO(dtmSelectedMonth);
                dtoArrayWK[i].PERIOD = (NZDateTime)dtmSelectedMonth;
                dtoArrayWK[i].CALENDAR_STRING = (NZString)(calendarStringBuilder.ToString());
            }
            foreach (WorkingCalendarDTO wkDTO in dtoArrayWK)
            {
                m_DAOWorkingCalendar.AddNew(CommonLib.Common.CurrentDatabase, wkDTO);
            }
        }

        public WorkingCalendarDTO GenerateWorkingCalendarDTO(DateTime dateTime)
        {
            // กำหนด calendar string ให้เป็นทำงานทุกวัน (1)
            StringBuilder calendarStringBuilder = new StringBuilder();
            for (int i = 0; i < DateTime.DaysInMonth(dateTime.Year, dateTime.Month); i++)
                calendarStringBuilder.Append("1");

            WorkingCalendarDTO wkDTO = new WorkingCalendarDTO
            {
                CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD,
                CRT_DATE = (NZDateTime)DateTime.UtcNow,
                CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine,
                UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD,
                UPD_DATE = (NZDateTime)DateTime.UtcNow,
                UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine,
                IS_ACTIVE = (NZBoolean)(true),
                PERIOD = (NZDateTime)dateTime,
                CALENDAR_STRING = (NZString)(calendarStringBuilder.ToString())
            };
            return wkDTO;
        }
        #endregion
    }
}
