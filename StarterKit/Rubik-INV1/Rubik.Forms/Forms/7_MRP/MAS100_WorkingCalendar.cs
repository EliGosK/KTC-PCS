using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SystemMaintenance.Forms;
using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Windows.Forms;
using Cube.AFD.Windows.Controls.CalendarControls;
using Rubik.BIZ;
using Rubik.DTO;
using System.Runtime.InteropServices;
using SystemMaintenance;
using CommonLib;

namespace Rubik.MRP
{
    /// <summary>
    /// สถานะของหน้าจอ สำหรับกำหนดการ Edit
    /// </summary>
    public enum eScreenState
    {
        View,
        Idle,
        Edit
    }
    //[Screen("MAS100", "Working Calendar", eShowAction.Normal, eScreenType.Screen, "Working Calendar")]
    public partial class MAS100_WorkingCalendar : CustomizeBaseForm
    {     
        private void MRP010_WorkingCalendar_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.AliceBlue;
            this.WindowState = FormWindowState.Maximized;
            // set default value to controls
            this.SetScreenState(eScreenState.View);          
            this.evoCheckBoxDay1.Checked = true;
            this.evoCheckBoxDay7.Checked = true;

            this.evoDateTextBoxLastGen.Format = MRPDateTimeUtil.SetShortDate(Common.CurrentUserInfomation.DateFormat);
            this.evoDateTextBoxStartMY.Format = MRPDateTimeUtil.SetShortDate(Common.CurrentUserInfomation.DateFormat);
            this.evoDateTextBoxWithCalendar.Format = MRPDateTimeUtil.SetShortDate(Common.CurrentUserInfomation.DateFormat);

            

            Button[,] myButtons =
                {
                    {btnDay1,btnDay2,btnDay3,btnDay4,btnDay5,btnDay6,btnDay7},
                    {btnDay8,btnDay9,btnDay10,btnDay11,btnDay12,btnDay13,btnDay14},
                    {btnDay15,btnDay16,btnDay17,btnDay18,btnDay19,btnDay20,btnDay21},
                    {btnDay22,btnDay23,btnDay24,btnDay25,btnDay26,btnDay27,btnDay28},
                    {btnDay29,btnDay30,btnDay31,btnDay32,btnDay33,btnDay34,btnDay35},
                    {btnDay36,btnDay37,btnDay38,btnDay39,btnDay40,btnDay41,btnDay42}
                };
            m_BtnDayInCalendarList = myButtons;
            foreach (Button t in m_BtnDayInCalendarList)
            {
                t.Click += new EventHandler(ClickChangeDayColor);
            }

            m_BIZWorkingCalendar = new WorkingCalendarBIZ();

            this.evoDateTextBoxWithCalendar.Value = DateTime.UtcNow;

            UpdateDateTextBox();

            // gen ปฏิทินเดือนปัจจุบัน
            this.GenerateCalendar();
        }      

        #region properties
        private eScreenState m_ScreenStateEnum = eScreenState.View;
        private WorkingCalendarBIZ m_BIZWorkingCalendar;
        private WorkingCalendarDTO m_DTOWorkingCalendar;
        private Button[,] m_BtnDayInCalendarList;
        #endregion

        #region constructor
        public MAS100_WorkingCalendar()
        {
            InitializeComponent();
        }
        #endregion

        #region Private Method
        /// <summary>
        /// แสดง Period ล่าสุดที่ได้ทำการ gen ไว้ (ถ้าไม่มีจะทำการแสดง period ปัจจุบัน)
        /// </summary>
        public void UpdateDateTextBox()
        {
            WorkingCalendarDTO wkDTOLastGen = m_BIZWorkingCalendar.GetLastGeneratedCalendar();
            if (wkDTOLastGen != null)
            {
                evoDateTextBoxLastGen.DateValue = (DateTime)wkDTOLastGen.PERIOD;
                evoDateTextBoxStartMY.DateValue = Convert.ToDateTime(evoDateTextBoxLastGen.DateValue).AddMonths(1);
            }
            else
            {
                evoDateTextBoxLastGen.Text = string.Empty;
                evoDateTextBoxStartMY.DateValue = DateTime.UtcNow;
            }           
        }
        /// <summary>
        /// Set ScreenState and set enable property to evoControl.
        /// </summary>
        /// <param name="screenState">ScreenState that want to set.</param>
        protected void SetScreenState(eScreenState screenState)
        {
            this.m_ScreenStateEnum = screenState;
            txtNoOfMonth.Text = "12";
            switch (m_ScreenStateEnum)
            {
                case eScreenState.View:
                    tsbEdit.Enabled = false;
                    tsbCancel.Enabled = false;
                    tsbSave.Enabled = false;
                    evoGroupBox1.Enabled = true;
                    evoGBSelectMonth.Enabled = true;
                    break;
                case eScreenState.Idle:
                    tsbEdit.Enabled = true;
                    tsbCancel.Enabled = false;
                    tsbSave.Enabled = false;
                    evoGroupBox1.Enabled = true;
                    evoGBSelectMonth.Enabled = true;
                    break;
                case eScreenState.Edit:
                    tsbEdit.Enabled = false;
                    tsbCancel.Enabled = true;
                    tsbSave.Enabled = true;
                    evoGroupBox1.Enabled = false;
                    //evoGBSelectMonth.Enabled = false;
                    break;
            }
        }
        /// <summary>
        /// สร้างปฏิทินของเดือนที่ปรากฏจาก EVODateTimeWithCalendar
        /// </summary>
        private void GenerateCalendar()
        {
            try
            {
                DateTime dateTime;
                if (evoDateTextBoxWithCalendar.Value == null)
                    evoDateTextBoxWithCalendar.Value = Convert.ToDateTime(evoDateTextBoxLastGen.DateValue);

                // เปรียบเทียบว่า DateTime ปัจจุบันมีอยู่ใน database หรือไม่ ถ้าไม่มีจะหา DateTime ที่ใกล้ที่สุด
                dateTime = Convert.ToDateTime(evoDateTextBoxWithCalendar.Value);
                DateTime dtmGenFirst = (m_BIZWorkingCalendar.GetFirstGeneratedCalendar()).PERIOD.StrongValue; ;
                DateTime dtmGenLast = Convert.ToDateTime(evoDateTextBoxLastGen.DateValue);

                ErrorItem errItem = WorkingCalendarValidation.CheckDateTimeIsGen((NZDateTime)dateTime, dtmGenFirst, dtmGenLast);
                if (errItem != null)
                {
                    if (dateTime < dtmGenFirst)
                        dateTime = dtmGenFirst;
                    else if (dateTime > dtmGenLast)
                        dateTime = dtmGenLast;
                    evoDateTextBoxWithCalendar.Value = dateTime;
                }

                dateTime = dateTime.AddDays(0 - dateTime.Day);
                dateTime = dateTime.AddDays(1);
                // นำ DateTime ที่ได้ไปสร้าง dto
                WorkingCalendarDTO wkDTO = GetDTOfromCurrentCalendar();

                // เตรียม TextBox ไว้สร้างปฏิทิน
                for (int j = 0; j < 7; j++)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        m_BtnDayInCalendarList[i, j].BackColor = Color.White;
                        m_BtnDayInCalendarList[i, j].Text = string.Empty;
                        m_BtnDayInCalendarList[i, j].Enabled = false;
                    }
                }

                // หาว่าวันแรกของเดือนเป็นวันอะไร?         
                DayOfWeek dayOfWeekEnum = dateTime.DayOfWeek;

                // ทำการใส่ค่าวันลงไปใน textbox + กำหนดสี
                int week = 0;
                string calendarString = wkDTO.CALENDAR_STRING.ToString();
                for (int i = 0; i < calendarString.Length; i++, dayOfWeekEnum++)
                {
                    // กำหนดค่าวันที่
                    m_BtnDayInCalendarList[week, (int)dayOfWeekEnum].Text = (i + 1).ToString();
                    m_BtnDayInCalendarList[week, (int)dayOfWeekEnum].Enabled = true;
                    // กำหนดสี
                    if (calendarString[i] == '0')
                        m_BtnDayInCalendarList[week, (int)dayOfWeekEnum].BackColor = Color.Red;
                    else
                        m_BtnDayInCalendarList[week, (int)dayOfWeekEnum].BackColor = Color.White;

                    // เลื่อนไปวันต่อไป
                    if ((int)dayOfWeekEnum + 1 >= 7)
                    {
                        dayOfWeekEnum -= 7;
                        week++;
                    }
                }
                ValidateException.ThrowErrorItem(errItem);
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                err.Error.FocusOnControl();
            }
            catch (ValidateException err)
            {
                MessageDialog.ShowBusiness(this, err.ErrorResults[0].Message);
                err.ErrorResults[0].FocusOnControl();
            }        
        }

        /// <summary>
        /// โหลดข้อมูลจาก DB ของเดือนปัจจุบัน(ที่แสดงตรง calendar)มาเก็บใน DTO, ถ้าไม่มีจะ gen DTO ใหม่ให้
        /// </summary>
        /// <returns>DTO ของเดือนปัจจุบัน</returns>
        private WorkingCalendarDTO GetDTOfromCurrentCalendar()
        {
            DateTime dateTime = Convert.ToDateTime(evoDateTextBoxWithCalendar.Value);
            WorkingCalendarDTO loadedDTO = m_BIZWorkingCalendar.GetTargetMonthCalendar(dateTime);
            if (loadedDTO == null)
            {
                SetScreenState(eScreenState.View);
                m_DTOWorkingCalendar = null;
                return m_BIZWorkingCalendar.GenerateWorkingCalendarDTO(dateTime);
            }
            else
            {
                if (this.m_ScreenStateEnum != eScreenState.Edit)
                    SetScreenState(eScreenState.Idle);
                m_DTOWorkingCalendar = loadedDTO;
                return loadedDTO;
            }
        }
        private MessageDialogResult ShowConfirmMessage(Messages.eConfirm msgCD)
        {
            // show confirm message
            MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new EVOFramework.Message(msgCD.ToString()).MessageDescription);
            return dr;
        }
        private void SetDefaultValue()
        {
            this.txtNoOfMonth.Text = "12";
        }
        private void GenWorkingCalendarToDB()
        {
            ValidateException.ThrowErrorItem(WorkingCalendarValidation.CheckEmptyDemandMonth((NZInt)Convert.ToInt32(txtNoOfMonth.Text)));

            switch (ShowConfirmMessage(Messages.eConfirm.CFM9012))
            {
                case MessageDialogResult.Cancel:
                    return;

                case MessageDialogResult.No:
                    return;

                case MessageDialogResult.Yes:
                    break;
            }

            // เตรียมข้อมูลสำหรับ gen
            bool[] bStopingDay = {
                                     evoCheckBoxDay1.Checked,
                                     evoCheckBoxDay2.Checked,
                                     evoCheckBoxDay3.Checked,
                                     evoCheckBoxDay4.Checked,
                                     evoCheckBoxDay5.Checked,
                                     evoCheckBoxDay6.Checked,
                                     evoCheckBoxDay7.Checked
                                 };
            int iNoOfMonth = Convert.ToInt32(txtNoOfMonth.Text);

            //DateTime dateTime = Convert.ToDateTime(Convert.ToDateTime(evoDateTextBoxStartMY.DateValue).ToString("MM-01-yyyy"));
            DateTime dtmSelectedMonth = (DateTime)evoDateTextBoxStartMY.DateValue;
            dtmSelectedMonth = dtmSelectedMonth.AddDays(0 - dtmSelectedMonth.Day);
            dtmSelectedMonth = dtmSelectedMonth.AddDays(1);

            m_BIZWorkingCalendar.CreateWorkingCalendar(iNoOfMonth, dtmSelectedMonth, bStopingDay);
            UpdateDateTextBox();
            MessageDialog.ShowInformation(this, "Information", new EVOFramework.Message(Messages.eInformation.INF9003.ToString()).MessageDescription);
            GenerateCalendar();
        }
        private bool IsCompleteSaveCalendar()
        {
            switch (ShowConfirmMessage(Messages.eConfirm.CFM9001))
            {
                case MessageDialogResult.Cancel:
                    return false;

                case MessageDialogResult.No:
                    return false;

                case MessageDialogResult.Yes:
                    break;
            }

            // get data from current month
            DateTime dateTime = Convert.ToDateTime(evoDateTextBoxWithCalendar.Value);

            StringBuilder calendarStringBuilder = new StringBuilder();
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (m_BtnDayInCalendarList[i, j].Text != string.Empty)
                    {
                        if (m_BtnDayInCalendarList[i, j].BackColor == Color.Red)
                            calendarStringBuilder.Append("0");
                        else
                            calendarStringBuilder.Append("1");
                    }
                }
            }
            WorkingCalendarDTO wkDTO = m_DTOWorkingCalendar;
            wkDTO.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            wkDTO.UPD_DATE = (NZDateTime)DateTime.UtcNow;
            wkDTO.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
            wkDTO.CALENDAR_STRING = (NZString)(calendarStringBuilder.ToString());

            m_BIZWorkingCalendar.UpdateWorkingCalendar(wkDTO);
            MessageDialog.ShowInformation(this, "Information", new EVOFramework.Message(Messages.eInformation.INF9003.ToString()).MessageDescription);
            return true;
        }
        #endregion

        #region Event Handler
        private void ClickChangeDayColor(object sender, EventArgs e)
        {
            if (this.m_ScreenStateEnum == eScreenState.Edit)
            {
                foreach (Button b in m_BtnDayInCalendarList)
                {
                    if (b.Focused && b.Text != string.Empty)
                    {
                        b.BackColor = (b.BackColor == Color.Red) ? Color.White : Color.Red;
                        return;
                    }

                }
            }
        }
       
        private void evoButtonGenerate_Click(object sender, EventArgs e)
        {           
            try
            {
                GenWorkingCalendarToDB();
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                err.Error.FocusOnControl();
            }
            catch (ValidateException err)
            {
                MessageDialog.ShowBusiness(this, err.ErrorResults[0].Message);
                err.ErrorResults[0].FocusOnControl();
            }          
        }       

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            this.SetScreenState(eScreenState.Edit);
        }
        private void tsbSave_Click(object sender, EventArgs e)
        {
            if(this.IsCompleteSaveCalendar())
                this.SetScreenState(eScreenState.Idle);           
        }
        
        private void tsbCancel_Click(object sender, EventArgs e)
        {
            // rollback current calendar. 
            switch (ShowConfirmMessage(Messages.eConfirm.CFM9003))
            {
                case MessageDialogResult.Cancel:
                    return;
                case MessageDialogResult.No:
                    return;
                case MessageDialogResult.Yes:
                    break;
            }
            this.GenerateCalendar();
        }
        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }   

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.m_ScreenStateEnum == eScreenState.Edit)
                this.IsCompleteSaveCalendar();
            evoDateTextBoxWithCalendar.Value = Convert.ToDateTime(evoDateTextBoxWithCalendar.Value).AddMonths(1);
            this.GenerateCalendar();
        }
        private void evoDateTextBoxWithCalendar_CalendarDateChanged(object sender, EventArgs e)
        {
            if (this.m_ScreenStateEnum == eScreenState.Edit)
                this.IsCompleteSaveCalendar();           
            this.GenerateCalendar();
        }
        private void evoDateTextBoxWithCalendar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (this.m_ScreenStateEnum == eScreenState.Edit)
                    this.IsCompleteSaveCalendar();
                this.GenerateCalendar();
            }
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (this.m_ScreenStateEnum == eScreenState.Edit)
                this.IsCompleteSaveCalendar();
            evoDateTextBoxWithCalendar.Value = Convert.ToDateTime(evoDateTextBoxWithCalendar.Value).AddMonths(-1);
            this.GenerateCalendar();
        }
        #endregion   
    }
    public static class WorkingCalendarValidation
    {
        public static ErrorItem CheckEmptyDemandMonth(NZInt iNoOfMonth)
        {
            if (iNoOfMonth > 120 || iNoOfMonth < 1)
                return new ErrorItem(iNoOfMonth.Owner, Messages.eValidate.VLM0139.ToString());
            else
                return null;
        }
        public static ErrorItem CheckDateTimeIsGen(NZDateTime dtmPeriod, DateTime dtmFirst , DateTime dtmLast)
        {
            if(dtmPeriod.StrongValue < dtmFirst || dtmPeriod.StrongValue > dtmLast)
                return new ErrorItem(dtmPeriod.Owner, Messages.eValidate.VLM0140.ToString());
            else
                return null;
        }
    }
    public static class MRPDateTimeUtil
    {
        public static string SetShortDate(EVOFramework.eDateFormat dateFormat)
        {
            switch (dateFormat)
            {
                case eDateFormat.YMD:
                    return "yyyy/MM";
                case eDateFormat.MDY:
                case eDateFormat.DMY:
                    return "MM/yyyy";
            }
            return "dd/MM/yyyy";
        }
    }
}
