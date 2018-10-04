using System;
using System.Collections;
using System.Windows.Forms;
using System.Drawing.Design;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Runtime.InteropServices;

namespace Cube.AFD.Windows.Controls.CalendarControls {


    public enum CalendarType {
        Region, Gregorian, ThaiBuddhist
    }

    //public class DateTimeFormat {
    //    private static _english
    //}

    //[TypeConverter(typeof(CalendarLayoutConverter))]
    //internal class CalendarLayoutConverter : TypeConverter {
    //    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) {
    //        if (sourceType == typeof(InstanceDescriptor)) {
    //            return true;
    //        }

    //        return base.CanConvertFrom(context, sourceType);
    //    }

    //    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) {
    //        if (destinationType == typeof(InstanceDescriptor)) {
    //            return true;
    //        }
    //        return base.CanConvertTo(context, destinationType);
    //    }

    //    public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType) {
    //        if (destinationType == typeof(CalendarLayout)) {
    //            CalendarLayout layout = (CalendarLayout)value;
    //            return new InstanceDescriptor(
    //                typeof(CalendarLayout).GetConstructor(new Type[] {typeof(CalendarLayout.LayoutType)}),
    //                new object[] { layout.Layout },
    //                true);
    //        }

    //        return base.ConvertTo(context, culture, value, destinationType);
    //    }
    //}



    [Serializable, 
    StructLayout(LayoutKind.Sequential)]
    //TypeConverter(typeof(CalendarLayoutControl)),
   //TypeConverter(typeof(CalendarLayoutConverter)),
    
    public struct CalendarLayout{
        private const int MONTH_SPACE = 4;
        public enum LayoutType {
            One,
            TwoRight, TwoDown,
            ThreeRight, ThreeDown, ThreeMerge,
            Four,
            Five,
            SixRight, SixDown,
            EightRight, EightDown,
            TwelveRight, TwelveDown
        }
        private int m_iMonthRow;
        private int m_iMonthCol;
        private int m_iMonthCount;
        private LayoutType m_layout;

        private void InitialVariable() {
            m_iMonthCount = 0;
            m_iMonthCol = 0;
            m_iMonthRow = 0;
            switch (m_layout) {
                case LayoutType.EightDown:
                    m_iMonthCol = 2;
                    m_iMonthRow = 4;
                    m_iMonthCount = 8;
                    break;
                case LayoutType.EightRight:
                    m_iMonthCol = 4;
                    m_iMonthRow = 2;
                    m_iMonthCount = 8;
                    break;
                case LayoutType.Five:
                    m_iMonthCol = 2;
                    m_iMonthRow = 3;
                    m_iMonthCount = 5;
                    break;
                case LayoutType.Four:
                    m_iMonthCol = 2;
                    m_iMonthRow = 2;
                    m_iMonthCount = 4;
                    break;
                case LayoutType.One:
                    m_iMonthCol = 1;
                    m_iMonthRow = 1;
                    m_iMonthCount = 1;
                    break;
                case LayoutType.SixDown:
                    m_iMonthCol = 2;
                    m_iMonthRow = 3;
                    m_iMonthCount = 6;
                    break;
                case LayoutType.SixRight:
                    m_iMonthCol = 3;
                    m_iMonthRow = 2;
                    m_iMonthCount = 6;
                    break;
                case LayoutType.ThreeDown:
                    m_iMonthCol = 1;
                    m_iMonthRow = 3;
                    m_iMonthCount = 3;
                    break;
                case LayoutType.ThreeMerge:
                    m_iMonthCol = 2;
                    m_iMonthRow = 2;
                    m_iMonthCount = 3;
                    break;
                case LayoutType.ThreeRight:
                    m_iMonthCol = 3;
                    m_iMonthRow = 1;
                    m_iMonthCount = 3;
                    break;
                case LayoutType.TwelveDown:
                    m_iMonthCol = 3;
                    m_iMonthRow = 4;
                    m_iMonthCount = 12;
                    break;
                case LayoutType.TwelveRight:
                    m_iMonthCol = 4;
                    m_iMonthRow = 3;
                    m_iMonthCount = 12;
                    break;
                case LayoutType.TwoDown:
                    m_iMonthCol = 1;
                    m_iMonthRow = 2;
                    m_iMonthCount = 2;
                    break;
                case LayoutType.TwoRight:
                    m_iMonthCol = 2;
                    m_iMonthRow = 1;
                    m_iMonthCount = 2;
                    break;
            }
        }

        #region "Constructor"
        public CalendarLayout(LayoutType layout) {
            m_layout = layout;
            m_iMonthCount = 0;
            m_iMonthCol = 0;
            m_iMonthRow = 0;
            InitialVariable();
        }
        #endregion

        public static int WeekInMonth(int year, int month) {
            DateTime dt = new DateTime(year, month, 1);
            int iDayCount = DateTime.DaysInMonth(year, month);
            iDayCount += (int)dt.DayOfWeek;
            //int iWeekCount = (int)Math.Round((decimal)iDayCount / 7);
            int iWeekCount = (int)(iDayCount / 7) + (iDayCount % 7 == 0 ? 0 : 1);
            return iWeekCount;
        }

        private void SetMaxWeek(params MonthObject[] months) {
            int iMaxWeek = -1;
            for (int i = 0; i < months.Length; ++i) {
                if (months[i].WeekCount > iMaxWeek) {
                    iMaxWeek = months[i].WeekCount;
                }
            }

            foreach (MonthObject m in months) {
                m.WeekCount = iMaxWeek;
            }
        }

        public void ResizeMonthObject(Rectangle clientRectangle, int yOffset, MonthObject []months) {
            try {
                Rectangle rcArea = new Rectangle(clientRectangle.X, clientRectangle.Y + yOffset, clientRectangle.Width - 1, clientRectangle.Height - yOffset - 1);
                int x1, y1, x2, y2;

                int iUnitHeight;
                int iUnitWidth;

                if (m_layout == LayoutType.ThreeMerge) {
                    Rectangle rc;
                    iUnitHeight = (rcArea.Height - MONTH_SPACE * 2) / 5;
                    iUnitWidth = (rcArea.Width - MONTH_SPACE) / 2;
                    rc = new Rectangle(0, 0, rcArea.Width, iUnitHeight * 3);
                    months[0].ClientRectangle = rc;

                    rc = new Rectangle(0, rc.Y + rc.Height + MONTH_SPACE, iUnitWidth, rcArea.Height - rc.Y - rc.Height - MONTH_SPACE);
                    months[1].ClientRectangle = rc;
                    rc = new Rectangle(rc.X + rc.Width + MONTH_SPACE, rc.Y, rcArea.Width - rc.Width - MONTH_SPACE, rc.Height);
                    months[2].ClientRectangle = rc;
                } else if (m_layout == LayoutType.Five) {
                    int iRow = 4;
                    iUnitWidth = (rcArea.Width - MONTH_SPACE) / 2;
                    iUnitHeight = (rcArea.Height - MONTH_SPACE * (iRow - 1)) / iRow;

                    Rectangle rc = new Rectangle(0, 0, iUnitWidth, iUnitHeight);
                    months[0].ClientRectangle = rc;

                    rc = new Rectangle(rc.Right + MONTH_SPACE, 0, rcArea.Right - rc.Right - MONTH_SPACE, iUnitHeight);
                    months[1].ClientRectangle = rc;

                    rc = new Rectangle(0, rc.Bottom + MONTH_SPACE, rcArea.Width, iUnitHeight * 2);
                    months[2].ClientRectangle = rc;

                    rc = new Rectangle(0, rc.Bottom + MONTH_SPACE, iUnitWidth, rcArea.Bottom - rc.Bottom - MONTH_SPACE);
                    months[3].ClientRectangle = rc;

                    rc = new Rectangle(rc.Right + MONTH_SPACE, rc.Top, rcArea.Right - rc.Right - MONTH_SPACE, rc.Height);
                    months[4].ClientRectangle = rc;
                } else {
                    iUnitWidth = (rcArea.Width - (MONTH_SPACE * (m_iMonthCol - 1))) / m_iMonthCol;
                    iUnitHeight = (rcArea.Height - (MONTH_SPACE * (m_iMonthRow - 1))) / m_iMonthRow;
                    int iCount = 0;
                    for (int iRow = 0; iRow < m_iMonthRow; ++iRow) {
                        y1 = iRow * (iUnitHeight + MONTH_SPACE);
                        y2 = y1 + iUnitHeight;
                        int iMaxWeek = -1;
                        for (int iCol = 0; iCol < m_iMonthCol; ++iCol) {
                            x1 = iCol * (iUnitWidth + MONTH_SPACE);
                            if (iCol < m_iMonthCol - 1) {
                                x2 = x1 + iUnitWidth;
                            } else {
                                x2 = rcArea.Right;
                            }
                            months[iCount].ClientRectangle = new Rectangle(x1, y1, x2 - x1, y2 - y1);
                            if (months[iCount].WeekCount > iMaxWeek) {
                                iMaxWeek = months[iCount].WeekCount;
                            }
                            iCount++;
                        }
                    }
                }

            } catch (Exception ex) {
                if (ex != null) {
                    Console.WriteLine(ex);
                    throw (new Exception(ex.Message));
                }
            }
        }

        public MonthObject[] GetMonthObject(Calendar owner, Rectangle clientRectangle, int yOffset, int iYearStart, int iMonthStart, ArrayList arDisplayedMonth, MonthObject.PaintDayHandler paintDayHandler) {
            try {
                if (arDisplayedMonth == null)
                    arDisplayedMonth = new ArrayList();

                Rectangle rcArea = new Rectangle(clientRectangle.X, clientRectangle.Y + yOffset, clientRectangle.Width - 1, clientRectangle.Height - yOffset - 1);
                
                DateTime dtStart = new DateTime(iYearStart, iMonthStart, 1);
                MonthObject[] months = new MonthObject[m_iMonthCount];
                for (int i = 0; i < m_iMonthCount; ++i) {
                    MonthObject mNew = new MonthObject(owner);
                    DateTime dtTmp = dtStart.AddMonths(i);
                    mNew.SetDay(dtTmp);
                    if (arDisplayedMonth.Contains(mNew)) {
                        int index = arDisplayedMonth.IndexOf(mNew);
                        months[i] = (MonthObject)arDisplayedMonth[index];
                        months[i].SetDay(dtTmp);
                    } else {
                        months[i] = mNew;
                        months[i].AttachOnPaintDayEvent(paintDayHandler);
                    }
                    months[i].ShowDayBeforeMonth = false;
                    months[i].ShowDayAfterMonth = false;
                    //months[i] = new MonthObject(owner);
                    //months[i].SetDay(dtStart.AddMonths(i));
                }
                int x1, y1, x2, y2;
                
                int iUnitHeight;
                int iUnitWidth;

                if (m_layout == LayoutType.ThreeMerge) {
                    Rectangle rc;
                    iUnitHeight = (rcArea.Height - MONTH_SPACE * 2) / 5;
                    iUnitWidth = (rcArea.Width - MONTH_SPACE) /2;
                    rc = new Rectangle(0, 0, rcArea.Width, iUnitHeight*3);
                    months[0].ClientRectangle = rc;

                    rc = new Rectangle(0, rc.Y + rc.Height + MONTH_SPACE, iUnitWidth, rcArea.Height - rc.Y - rc.Height -MONTH_SPACE);
                    months[1].ClientRectangle = rc;
                    rc = new Rectangle(rc.X+rc.Width + MONTH_SPACE, rc.Y, rcArea.Width - rc.Width - MONTH_SPACE, rc.Height);
                    months[2].ClientRectangle = rc;


                    months[1].IsSmall = true;
                    months[2].IsSmall = true;

                    months[0].ShowDayBeforeMonth = true;
                    months[2].ShowDayAfterMonth = true;

                    SetMaxWeek(months[1], months[2]);
                    
                } else if (m_layout == LayoutType.Five) {
                    int iRow = 4;
                    iUnitWidth = (rcArea.Width - MONTH_SPACE) / 2;
                    iUnitHeight = (rcArea.Height - MONTH_SPACE*(iRow-1)) / iRow;

                    Rectangle rc = new Rectangle(0, 0, iUnitWidth, iUnitHeight);
                    months[0].ClientRectangle = rc;

                    rc = new Rectangle(rc.Right + MONTH_SPACE, 0, rcArea.Right - rc.Right - MONTH_SPACE, iUnitHeight);
                    months[1].ClientRectangle = rc;

                    rc = new Rectangle(0, rc.Bottom + MONTH_SPACE, rcArea.Width, iUnitHeight*2);
                    months[2].ClientRectangle = rc;

                    rc = new Rectangle(0, rc.Bottom + MONTH_SPACE, iUnitWidth, rcArea.Bottom - rc.Bottom - MONTH_SPACE);
                    months[3].ClientRectangle = rc;

                    rc = new Rectangle(rc.Right + MONTH_SPACE, rc.Top, rcArea.Right - rc.Right - MONTH_SPACE, rc.Height);
                    months[4].ClientRectangle = rc;

                    months[0].IsSmall = true;
                    months[1].IsSmall = true;
                    months[3].IsSmall = true;
                    months[4].IsSmall = true;
                    SetMaxWeek(months[0], months[1]);
                    SetMaxWeek(months[3], months[4]);

                    months[0].ShowDayBeforeMonth = true;
                    months[4].ShowDayAfterMonth = true;
                } else {
                    iUnitWidth = (rcArea.Width - (MONTH_SPACE*(m_iMonthCol-1))) / m_iMonthCol;
                    iUnitHeight = (rcArea.Height - (MONTH_SPACE*(m_iMonthRow-1))) / m_iMonthRow;
                    int iCount = 0;
                    for (int iRow = 0; iRow < m_iMonthRow; ++iRow) {
                        y1 = iRow * (iUnitHeight+MONTH_SPACE);
                        y2 = y1 + iUnitHeight ;
                        int iMaxWeek = -1;
                        for (int iCol = 0; iCol < m_iMonthCol; ++iCol) {
                            x1 = iCol * (iUnitWidth + MONTH_SPACE);
                            if (iCol < m_iMonthCol - 1) {
                                x2 = x1 + iUnitWidth;
                            } else {
                                x2 = rcArea.Right;
                            }
                            months[iCount].ClientRectangle = new Rectangle(x1, y1, x2 - x1, y2 - y1);
                            if (months[iCount].WeekCount > iMaxWeek) {
                                iMaxWeek = months[iCount].WeekCount;
                            }
                            iCount++;
                        }
                        for (int iCol = 0; iCol < m_iMonthCol; ++iCol) {
                            months[iCount - iCol - 1].WeekCount = iMaxWeek; 
                        }
                    }
                    months[0].ShowDayBeforeMonth = true;
                    months[months.Length - 1].ShowDayAfterMonth = true;
                }

                //// Keep new month object to array list
                //foreach (MonthObject m in months) {
                //    int index = arDisplayedMonth.IndexOf(m);
                //    if (index >= 0) {
                //        arDisplayedMonth[index] = m;
                //    }
                //}

                return months;
            } catch (Exception ex) {
                if (ex != null) {
                    Console.WriteLine(ex);
                    throw (new Exception(ex.Message));
                }
                return new MonthObject[0];
            }
        }

        #region "Static Properties"
        public static CalendarLayout EightDown {
            get {
                return new CalendarLayout(LayoutType.EightDown);
            }
        }
        public static CalendarLayout EightRight {
            get {
                return new CalendarLayout(LayoutType.EightRight);
            }
        }
        public static CalendarLayout Five {
            get {
                return new CalendarLayout(LayoutType.Five);
            }
        }
        public static CalendarLayout Four {
            get {
                return new CalendarLayout(LayoutType.Four);
            }
        }
        public static CalendarLayout One {
            get {
                return new CalendarLayout(LayoutType.One);
            }
        }
        public static CalendarLayout SixDown {
            get {
                return new CalendarLayout(LayoutType.SixDown);
            }
        }
        public static CalendarLayout SixRight {
            get {
                return new CalendarLayout(LayoutType.SixRight);
            }
        }
        public static CalendarLayout ThreeDown {
            get {
                return new CalendarLayout(LayoutType.ThreeDown);
            }
        }
        public static CalendarLayout ThreeMerge {
            get {
                return new CalendarLayout(LayoutType.ThreeMerge);
            }
        }
        public static CalendarLayout ThreeRight {
            get {
                return new CalendarLayout(LayoutType.ThreeRight);
            }
        }
        public static CalendarLayout TwelveDown {
            get {
                return new CalendarLayout(LayoutType.TwelveDown);
            }
        }
        public static CalendarLayout TwelveRight {
            get {
                return new CalendarLayout(LayoutType.TwelveRight);
            }
        }
        public static CalendarLayout TwoDown {
            get {
                return new CalendarLayout(LayoutType.TwoDown);
            }
        }
        public static CalendarLayout TwoRight {
            get {
                return new CalendarLayout(LayoutType.TwoRight);
            }
        }
        #endregion

        #region "Properties"
        public int MountRow {
            get {
                return m_iMonthRow;
            }
        }
        public int MonthCol {
            get {
                return m_iMonthCol;
            }
        }
        public int MonthCount {
            get {
                return m_iMonthCount;
            }
        }
        public LayoutType Layout {
            get {
                return m_layout;
            }
            set {
                if (m_layout != value) {
                    m_layout = value;
                    InitialVariable();
                }
            }
        }
        #endregion

        #region "Override Method"
        public override bool Equals(object obj) {
            return this.m_layout == ((CalendarLayout)obj).m_layout;
        }
        public override int GetHashCode() {
            return base.GetHashCode();
        }
        public override string ToString() {
            return m_layout.ToString();
        }
        #endregion

        #region "Operators"
        public static bool operator ==(CalendarLayout l1, CalendarLayout l2){
            return l1.Layout == l2.Layout;
        }

        public static bool operator !=(CalendarLayout l1, CalendarLayout l2) {
            return l1.Layout != l2.Layout;
        }
        #endregion
    }

    public enum SelectionPolicy {
        Single,
        Merge,
        Continuous
    }

}
