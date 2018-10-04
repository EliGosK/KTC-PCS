using System;
using System.Reflection;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace Cube.AFD.Windows.Controls.CalendarControls {

    public class PaintDayEventArgs : EventArgs {
        public PaintDayEventArgs() {
        }
    }

    public enum MonthOfYear {
        January = 0,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }

    public enum HitTestCalendarObject {
        YearText, MonthText, ImageObject
    }

    public class CalendarObject {
        public delegate void CalendarObjectInvalidateHandler(CalendarObject obj);    
        protected Rectangle m_rcClient;
        protected Calendar m_owner;
        protected HitTestCalendarObject m_hitTestObj;

        public event CalendarObjectInvalidateHandler OnCalendarObjectInvalidate = null;

        protected string FormatDate(string format, params object []args){
            return CalendarObject.FormatDate(m_owner.DateTimeFormatInfo, format, args);

        }

        public Calendar Calendar {
            get {
                return m_owner;
            }
        }

        protected CalendarStyle Style {
            get {
                if (m_owner == null)
                    return null;
                return m_owner.CalendarStyle;
            }
        }

        public static string FormatDate(IFormatProvider provider, string format, params object[] args) {
            if (provider == null) {
                return string.Format(format, args);
            } else {
                return string.Format(provider, format, args);
            }
        }

        public static DateTime DateFromYearMonth(IFormatProvider provider, int iYear, int iMonth) {
            string strDate = string.Format("{0:00}/{1:00}/{2:00}", 1, iMonth, iYear);
            string strFormat = "dd/MM/yyyy";
            if (provider == null) {
                return DateTime.ParseExact(strDate, strFormat, System.Globalization.DateTimeFormatInfo.CurrentInfo);
            } else {
                return DateTime.ParseExact(strDate, strFormat, provider);
            }
        }


        public CalendarObject(Calendar owner) {
            m_owner = owner;
        }

        protected void Invalidate() {
            if (OnCalendarObjectInvalidate != null) {
                OnCalendarObjectInvalidate(this);
            }
        }

        public virtual Rectangle ClientRectangle {
            get { return m_rcClient; }
            set {
                if (m_rcClient != value) {
                    m_rcClient = value;
                    this.Invalidate();
                }
            }
        }

        public static Point[] PointAroundFromRect(Rectangle rc) {
            return PointAroundFromRect(rc, 0, 0);
            //int x1 = rc.Left;
            //int y1 = rc.Top;
            //int x2 = rc.Left + rc.Width;
            //int y2 = rc.Top + rc.Height;
            //return new Point[] { new Point(x1, y1), new Point(x2, y1), new Point(x2, y2), new Point(x1, y2), new Point(x1, y1) };
        }

        public static Point[] PointAroundFromRect(Rectangle rc, int difX, int difY) {
            int x1 = rc.Left + difX;
            int y1 = rc.Top + difY;
            int x2 = rc.Left + rc.Width - difX*2;
            int y2 = rc.Top + rc.Height - difY*2;
            return new Point[] { new Point(x1, y1), new Point(x2, y1), new Point(x2, y2), new Point(x1, y2), new Point(x1, y1) };
        }

        public Point[] PointAroundRect {
            get {
                return CalendarObject.PointAroundFromRect(m_rcClient);
            }
        }

        public HitTestCalendarObject HitTestType {
            get {
                return m_hitTestObj;
            }
        }
    }


    public class DayObject : CalendarObject, IComparer, IComparable, ICloneable, IDisposable {
        public const int CHECK_BOX_SIZE = 13;
        public const int CHECK_BOX_OFFSET = 2;
        private DateTime m_date = DateTime.Now;
        private MonthObject m_monthObject = null;
        private bool m_bShow = true;
        private bool m_bSelected = false;
        private Control m_editorControl = null;
        private bool m_bActive = false;
        private bool m_bChecked = false;
        private ImageObject m_imgCheck = null;
        private bool m_bShowCheckBox = false;
        private string[] m_strLines = new string[0];
        private object m_oTag = null;
        public DayObject(Calendar owner, Rectangle rc, DateTime dt) : base(owner) {
            m_rcClient = rc;
            m_date = dt;

            Rectangle rcCheckImage = new Rectangle(rc.Location.X + CHECK_BOX_OFFSET, rc.Location.Y + CHECK_BOX_OFFSET, CHECK_BOX_SIZE, CHECK_BOX_SIZE);
            m_imgCheck = new ImageObject(owner, rcCheckImage, Properties.Resources.UnChecked);
        }

        public void Dispose() {
            m_monthObject = null;
            m_editorControl = null;
        }

        public object Tag {
            get {
                return m_oTag;
            }
            set {
                m_oTag = value;
            }
        }

        public object Clone() {
            DayObject dNew = new DayObject(m_owner, m_rcClient, m_date);
            PropertyInfo[] pInfo = dNew.GetType().GetProperties();
            foreach (PropertyInfo p in pInfo) {
                if (p.CanWrite) {
                    PropertyInfo pCur = this.GetType().GetProperty(p.Name);
                    if (pCur != null) {
                        if (pCur.CanRead) {
                            object oValue = pCur.GetValue(this, null);
                            if (oValue != null) {
                                p.SetValue(dNew, oValue, null);
                            }
                        }
                    }
                }
            }

            return dNew;
        }

        public bool ShowCheckBox {
            get { return m_bShowCheckBox; }
            set {
                if (m_bShowCheckBox != value) {
                    m_bShowCheckBox = value;
                }
            }
        }

        public bool Selected {
            get { return m_bSelected; }
            set {
                if (m_bSelected != value) {
                    m_bSelected = value;
                }
            }
        }
        public override Rectangle ClientRectangle {
            get {
                return base.ClientRectangle;
            }
            set {
                if (base.ClientRectangle != value) {
                    base.ClientRectangle = value;
                    m_imgCheck.ClientRectangle = new Rectangle(base.ClientRectangle.Location.X + CHECK_BOX_OFFSET, base.ClientRectangle.Location.Y + CHECK_BOX_OFFSET, CHECK_BOX_SIZE, CHECK_BOX_SIZE);
                    if (m_editorControl != null) {
                        m_editorControl.Location = new Point(m_rcClient.Location.X + 1, m_rcClient.Location.Y + 1);// m_rcClient.Location;
                        m_editorControl.Size = new Size(m_rcClient.Size.Width - 1, m_rcClient.Size.Height - 1);
                    }
                }
            }
        }

        public static bool operator ==(DayObject l1, DayObject l2) {
            if (l1 is DayObject == false && l2 is DayObject == false)
                return true;

            if (l1 is DayObject == false)
                return false;

            if (l2 is DayObject == false)
                return false;

            return l1.Date.Date == l2.Date.Date;
        }

        public static bool operator !=(DayObject l1, DayObject l2) {
            if (l1 is DayObject == false && l2 is DayObject == false)
                return false;

            if (l1 is DayObject == false)
                return true;

            if (l2 is DayObject == false)
                return true;

            return l1.Date.Date != l2.Date.Date;
        }

        public bool Checked {
            get { return m_bChecked; }
            set {
                if (m_bChecked != value) {
                    m_bChecked = value;
                    m_imgCheck.Bitmap = m_bChecked ? Properties.Resources.Checked : Properties.Resources.UnChecked;
                }
            }
        }
        public ImageObject CheckImage {
            get {
                return m_imgCheck;
            }
        }
        public DateTime Date {
            get {
                return m_date;
            }
        }
        public DateTime DatePart {
            get {
                return new DateTime(m_date.Year, m_date.Month, m_date.Day);
            }
        }
        public bool Active {
            get { return m_bActive; }
            set {
                if (m_bActive != value) {
                    m_bActive = value;
                }
            }
        }
        public bool Show {
            get { return m_bShow; }
            set {
                if (m_bShow != value) {
                    m_bShow = value;
                }
            }
        }
        public override bool Equals(object obj) {
            if (obj == null)
                return false;
            return this.m_date == ((DayObject)obj).m_date;
        }
        public override int GetHashCode() {
            return base.GetHashCode();
        }
        int IComparer.Compare(object x, object y) {
            DayObject dx = (DayObject)x;
            DayObject dy = (DayObject)y;
            return DateTime.Compare(dx.Date, dy.Date);
        }
        int IComparable.CompareTo(object x) {
            return DateTime.Compare(m_date, ((DayObject)x).m_date);
        }
        public override string ToString() {
            if (m_owner== null){
                return m_date.ToString();
            }else if (m_owner.DateTimeFormatInfo == null){
                return m_date.ToString();
            }else{
                return CalendarObject.FormatDate(m_owner.DateTimeFormatInfo, "{0:" +m_owner.DateTimeFormatInfo.LongDatePattern + "}", m_date);
            }
        }
        public MonthObject MonthObject {
            get { return m_monthObject; }
            set {
                m_monthObject = value;
            }
        }
        public Control EditorControl {
            get {
                return m_editorControl;
            }
            set {
                m_editorControl = value;
                m_editorControl.Location = new Point(m_rcClient.Location.X + 1, m_rcClient.Location.Y + 1);// m_rcClient.Location;
                m_editorControl.Size = new Size(m_rcClient.Size.Width - 1, m_rcClient.Size.Height - 1);

                ((DayEditor)m_editorControl).DayObject = this;
                //((IEditorControl)m_editorControl).DayObject = this;
            }
        }

        public Bitmap GetControlBitmap() {
            if (m_editorControl == null)
                return null;

            Bitmap memoryImage = null;
            Rectangle rc = m_editorControl.RectangleToScreen(m_editorControl.DisplayRectangle);
            try {
                Graphics g = m_editorControl.CreateGraphics();
                memoryImage = new Bitmap(rc.Width, rc.Height, g);

                Graphics gNew = Graphics.FromImage(memoryImage);
                gNew.CopyFromScreen(rc.X, rc.Y, 0, 0, rc.Size, CopyPixelOperation.SourceCopy);

            } catch (Exception ex) {
//                MessageBox.Show(ex.ToString(), "Capture failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.ToString());
                return null;
            }
            return memoryImage;
        }
    }



    public class DayObjectCollections : CollectionBase {
        public DayObject this[int index] {
            get {
                return ((DayObject)List[index]);
            }
            set {
                List[index] = value;
            }
        }

        public int Add(DayObject value) {
            return (List.Add(value));
        }

        public int IndexOf(DayObject value) {
            return (List.IndexOf(value));
        }

        public void Insert(int index, DayObject value) {
            List.Insert(index, value);
        }

        public void Remove(DayObject value) {
            List.Remove(value);
        }

        public bool Contains(DayObject value) {
            // If value is not of type DayObject, this will return false.
            return (List.Contains(value));
        }

        protected override void OnInsert(int index, Object value) {
            // Insert additional code to be run only when inserting values.
        }

        protected override void OnRemove(int index, Object value) {
            // Insert additional code to be run only when removing values.
        }

        protected override void OnSet(int index, Object oldValue, Object newValue) {
            // Insert additional code to be run only when setting values.
        }

        protected override void OnValidate(Object value) {
            if (value.GetType() != typeof(DayObject))
                throw new ArgumentException("value must be of type DayObject.", "value");
        }

    }

    public class TextObject : CalendarObject {
        private string m_strText = string.Empty;
        private Point m_location = new Point(0, 0);
        private Size m_size = new Size(0, 0);
        private MonthObject m_month = null;
        public TextObject(Calendar owner,MonthObject month , HitTestCalendarObject objType) : base(owner) {
            m_hitTestObj = objType;
            m_month = month;
        }

        public MonthObject MonthObject {
            get {
                return m_month;
            }
        }

        public string Text {
            get { return m_strText; }
            set {
                if (m_strText != value) {
                    m_strText = value;
                }
            }
        }

        public Point Location {
            get { return m_location; }
            set {
                if (m_location != value) {
                    m_location = value;
                    m_rcClient.Location = new Point(m_location.X, m_location.Y);
                }
            }
        }

        public Size Size {
            get { return m_size; }
            set {
                if (m_size != value) {
                    m_size = value;
                    m_rcClient.Size = new Size(m_size.Width, m_size.Height);
                }
            }
        }

        public static Size GetGraphicSize(Graphics g, string text, Font f) {
            SizeF szf = g.MeasureString(text, f);
            Size sz = new Size((int)szf.Width+1, (int)szf.Height+1);
            return sz;
        }

    }

    public class MonthObject : CalendarObject, IDisposable {
        public delegate void PaintDayHandler(Graphics g, MonthObject monthObj,  DayObject dayObj);
        private const int DAY_PER_WEEK = 7;
        //private const float RATIO = 1.2F;
        private bool m_bIsSmall = false;
        private bool m_bShowDayBeforeThisMonth = false;
        private bool m_bShowDayAfterThisMonth = false;
        //private int m_iHeaderSize = 20;
        //private int m_iHeaderSizeSmall = 20;
        private Graphics m_g;
        //private Font m_font;
        //private Font m_fontSmall;
        //private Brush m_brHeader;
        private StringFormat m_sf;
        private DateTime m_date;
        private int m_iWeekCount = 0;
        public event PaintDayHandler OnPaintDay = null;
        private ArrayList m_arDays = new ArrayList();
        private TextObject m_txtYear;
        private TextObject m_txtMonth;
        private Control m_editorControl = null;
        private bool m_bShowCheckeBox = false;

        public MonthObject(Calendar owner) : base(owner) {
            //m_brHeader = new SolidBrush(Color.FromArgb(2, 106, 254));
            m_sf = new StringFormat();
            m_sf.Alignment = StringAlignment.Center;
            m_sf.LineAlignment = StringAlignment.Center;

            m_txtMonth = new TextObject(owner, this, HitTestCalendarObject.MonthText);
            m_txtYear = new TextObject(owner, this, HitTestCalendarObject.YearText);
        }

        public void Dispose() {
            for (int i = 0; i < m_arDays.Count; ++i) {
                DayObject dob = (DayObject)m_arDays[i];
                dob.Dispose();
                dob = null;
            }
            m_arDays.Clear();
            GC.Collect();
        }

        public bool ShowCheckBox {
            get {
                return m_bShowCheckeBox;
            }
            set {
                if (m_bShowCheckeBox != value) {
                    m_bShowCheckeBox = value;
                    foreach (DayObject dob in m_arDays) {
                        dob.ShowCheckBox = m_bShowCheckeBox;
                    }
                }
            }
        }

        public Control EditorControl {
            get { return m_editorControl; }
            set {
                m_editorControl = value;
                if (m_editorControl != null) {
                    foreach (DayObject d in m_arDays) {
                        Type t = m_editorControl.GetType();
                        d.EditorControl = (Control)Activator.CreateInstance(t);
                    }
                }
            }
        }

        public ArrayList DayObjects {
            get {
                return m_arDays;
            }
        }

        public TextObject HitTestTextObject(int x, int y) {
            Point pt = new Point(x, y);
            if (m_txtMonth.ClientRectangle.Contains(pt)) {
                return m_txtMonth;
            } else if (m_txtYear.ClientRectangle.Contains(pt)) {
                return m_txtYear;
            } else {
                return null;
            }
        }

        public void AttachOnPaintDayEvent(PaintDayHandler handler) {
            OnPaintDay = handler;
        }

        public DayObject GetFirstStartDayFromPoint(Point pt) {
            DayObject dayStart = GetDateFromPoint(pt.X, pt.Y);
            if (dayStart == null) { // 
                Rectangle rc = new Rectangle(pt.X, pt.Y, m_rcClient.Right- pt.X, m_rcClient.Bottom- pt.Y);
                for (int i = 0; i < m_arDays.Count; ++i) {
                    DayObject d = (DayObject)m_arDays[i];
                    if (d.Show) {
                        if (rc.IntersectsWith(d.ClientRectangle)) {
                            dayStart = d;
                            break;
                        }
                    }
                }
            }
            return dayStart;
        }

        public DayObject GetFirstEndDayFromPoint(Point pt) {
            DayObject dayEnd = GetDateFromPoint(pt.X, pt.Y);
            if (dayEnd == null) {
                Rectangle rc = new Rectangle(m_rcClient.Left, m_rcClient.Top, m_rcClient.Width - (m_rcClient.Right - pt.X), m_rcClient.Height - (m_rcClient.Bottom - pt.Y));
                for (int i = m_arDays.Count - 1; i >= 0; --i) {
                    DayObject d = (DayObject)m_arDays[i];
                    if (d.Show) {
                        if (rc.IntersectsWith(d.ClientRectangle)) {
                            dayEnd = d;
                            break;
                        }
                    }
                }
            }
            return dayEnd;
        }

        //public DayObject[] GetDaysInRect(Rectangle rc) {
        //    DayObject dayStart = GetFirstStartDayFromPoint(rc.Location);
        //    DayObject dayEnd = GetFirstEndDayFromPoint(new Point(rc.Top, rc.Right));

        //    ArrayList ar = new ArrayList();
        //    foreach (DayObject d in m_arDays) {
        //        if (d.Show && d.Date >= dayStart.Date && d.Date <= dayEnd.Date) {
        //            ar.Add(d);
        //        }
        //    }
        //    DayObject[] r = new DayObject[ar.Count];
        //    ar.CopyTo(r);
        //    return r;
        //}

        public DayObject[] GetDaysBetweenDate(DateTime d1, DateTime d2) {
            ArrayList ar = new ArrayList();
            foreach (DayObject d in m_arDays) {
                if (d.Show && d.Date >= d1 && d.Date <= d2) {
                    ar.Add(d);
                }
            }
            DayObject[] r = new DayObject[ar.Count];
            ar.CopyTo(r);
            return r;
        }

        //public DayObject[] GetDateFromRect(Rectangle rc) {
        //    ArrayList ar = new ArrayList();
            
        //    DayObject dayStart = GetDateFromPoint(rc.Location.X, rc.Location.Y);
        //    DayObject dayEnd = GetDateFromPoint(rc.Right, rc.Bottom);
        //    if (dayStart == null && dayEnd == null) {
        //        return new DayObject[0];
        //    } else {
        //        if (dayStart == null) {
        //            dayStart = new DayObject(null, Rectangle.Empty, DateTime.MinValue);
        //        }
        //        if (dayEnd == null) {
        //            dayEnd = new DayObject(null, Rectangle.Empty, DateTime.MaxValue);
        //        }

        //        foreach (DayObject dob in m_arDays) {
        //            if (dob.Show && dob.Date >= dayStart.Date && dob.Date <= dayEnd.Date) {
        //                ar.Add(dob);
        //            }
        //        }
        //    }
            
        //    //if (dayStart == null) {
        //    //    Console.WriteLine(rc);
        //    //} else {
        //    //    Console.WriteLine(rc + " : " + dayStart.Date.ToString());
        //    //}
        //    //if (dayStart != null) {
                
        //    //    if (dayEnd == null) {
        //    //        dayEnd = new DayObject(null, Rectangle.Empty, DateTime.MaxValue);
        //    //    }


        //    //    foreach (DayObject dob in m_arDays) {
        //    //        if (dob.Show && dob.Date >= dayStart.Date && dob.Date <= dayEnd.Date) {
        //    //            ar.Add(dob);
        //    //        }
        //    //    }
        //    //}
        //    DayObject[] r = new DayObject[ar.Count];
        //    ar.CopyTo(r);
        //    return r;
        //}

        public DayObject GetDateFromPoint(int x, int y) {
            foreach (DayObject dob in m_arDays) {
                if (dob.Show) {
                    if (dob.ClientRectangle.Contains(new Point(x, y))) {
                        return dob;
                    }
                }
            }
            return null;
        }

        //private int HeaderSizeWeek {
        //    get {
        //        return 2 * (this.HeaderSizeToDraw / 3);
        //    }
        //}
        //private int HeaderSizeToDraw {
        //    get {
        //        return m_bIsSmall ? m_iHeaderSizeSmall : m_iHeaderSize;
        //    }
        //}
        private Font FontToDraw {
            get {
                return m_bIsSmall ? base.Style.DayStyle.FontSmall : base.Style.DayStyle.Font;//m_fontSmall: m_font;
            }
        }

        private void CalculateTextRect(Rectangle rcHeader) {
            m_txtMonth.Text = FormatDate("{0:MMMM}", m_date);
            m_txtMonth.Size = TextObject.GetGraphicSize(m_g, m_txtMonth.Text,  base.Style.CalendarHeader.Font);// this.FontToDraw);
            m_txtYear.Text = FormatDate("{0:yyyy}", m_date);
            m_txtYear.Size = TextObject.GetGraphicSize(m_g, m_txtYear.Text, base.Style.CalendarHeader.Font);// this.FontToDraw);
            Point pt = new Point(0, 0);
            int txtWidth = m_txtMonth.Size.Width + m_txtYear.Size.Width + 10; // 10 = space between mont and year text.
            int txtHeight = m_txtMonth.Size.Height > m_txtYear.Size.Height ? m_txtMonth.Size.Height : m_txtYear.Size.Height;
            m_txtMonth.Size = new Size(m_txtMonth.Size.Width, txtHeight);
            m_txtYear.Size = new Size(m_txtYear.Size.Width, txtHeight);

            pt.Y = rcHeader.Top + (rcHeader.Height - txtHeight) / 2;
            pt.X = rcHeader.Left + (rcHeader.Width - txtWidth) / 2;
            m_txtMonth.Location = new Point(pt.X, pt.Y);
            m_txtYear.Location = new Point(m_txtMonth.Location.X + m_txtMonth.Size.Width + 10, pt.Y);
        }

        public TextObject YearTextObject {
            get {
                return m_txtYear;
            }
        }

        private void DrawMonthHeader(Rectangle rcClip) {
            Rectangle rcHeader = new Rectangle();
            rcHeader.X = m_rcClient.X;
            rcHeader.Y = m_rcClient.Y;
            rcHeader.Width = m_rcClient.Width;
            rcHeader.Height = base.Style.CalendarHeader.Height;// this.HeaderSizeToDraw;

            // Calendar Header
            m_g.FillRectangle(base.Style.CalendarHeader.BackBrush, rcHeader);
            m_g.DrawLines(base.Style.GridPen, MonthObject.PointAroundFromRect(rcHeader));
            CalculateTextRect(rcHeader);
            m_g.DrawString(m_txtMonth.Text, base.Style.CalendarHeader.Font, base.Style.CalendarHeader.ForeBrush, m_txtMonth.ClientRectangle, m_sf);
            m_g.DrawString(m_txtYear.Text, base.Style.CalendarHeader.Font, base.Style.CalendarHeader.ForeBrush, m_txtYear.ClientRectangle, m_sf);

            // Draw Week Header
            rcHeader.Y += rcHeader.Height;
            rcHeader.Height = base.Style.WeekHeader.Height;// this.HeaderSizeWeek;
            m_g.FillRectangle(base.Style.WeekHeader.BackBrush, rcHeader);

            DateTime dt = DateTime.Today;
            while (dt.DayOfWeek != DayOfWeek.Sunday) {
                dt = dt.AddDays(1);
            }
            
            int iWidth = rcHeader.Width / DAY_PER_WEEK;
            for (int i = 0; i < DAY_PER_WEEK; ++i) {
                Rectangle rc = new Rectangle();
                rc.X = rcHeader.X + i * iWidth;
                rc.Y = rcHeader.Y;
                if (i < DAY_PER_WEEK - 1) {
                    rc.Width = iWidth;
                } else { // last column
                    rc.Width = rcHeader.Width - iWidth * 6;
                }
                rc.Height = rcHeader.Height;
                m_g.DrawLines(base.Style.GridPen, MonthObject.PointAroundFromRect(rc));
                
                string s = base.Style.WeekText.GetWeekText(dt.DayOfWeek, FormatDate("{0:ddd}", dt));
                m_g.DrawString(s, base.Style.WeekHeader.Font , base.Style.WeekHeader.ForeBrush, rc, m_sf);
                dt = dt.AddDays(1);
            }

            DrawDay(rcClip);
        }

        private void DrawDay(Rectangle rcClip) {
            
            if (m_arDays.Count == 0) {
                CreateDayObject(null, null);
            }
            
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Far;
            sf.LineAlignment = StringAlignment.Near;
            ArrayList arActiveDay = new ArrayList();
            foreach (DayObject dob in m_arDays) {
                //if (dob.Date.Month == 5 && dob.Date.Day == 31) {
                //    Console.WriteLine(dob.ClientRectangle);
                //}
                dob.Show = false;
                if (m_date.Month == dob.Date.Month) {
                    dob.Show = true;
                } else {
                    if (dob.Date < m_date && m_bShowDayBeforeThisMonth) {
                        dob.Show = true;
                    } else if (dob.Date > m_date && m_bShowDayAfterThisMonth) {
                        dob.Show = true;
                    }
                }

                if (dob.EditorControl != null && m_owner.EditorMode == EditorMode.Alway) {
                    if (dob.Show == false) {
                        int index = base.Style.WeekText.IndexOf(dob.Date.DayOfWeek);
                        Brush br;
                        if (index >= 0) {
                            br = base.Style.WeekText[index].BackBrush;
                            if (br == null) {
                                br = base.Style.DayStyle.NormalDay.BackBrush;
                            }
                        } else {
                            br = base.Style.DayStyle.NormalDay.BackBrush;
                        }
                        if (dob.Selected && dob.Show) {
                            br = base.Style.DayStyle.SelectionDay.BackBrush;
                        } else if (dob.Date.Month != this.Month) {
                            br = base.Style.DayStyle.InactiveDay.BackBrush;
                        }
                        Image imgBack = m_owner.BackgroundImageTemplate;
                        m_g.FillRectangle(br, dob.ClientRectangle);
                        if (imgBack != null) {
                            m_g.DrawImage(imgBack, dob.ClientRectangle);
                        }
                        
                    }
                    m_g.DrawLines(base.Style.GridPen, CalendarObject.PointAroundFromRect(dob.ClientRectangle));
                } else if (OnPaintDay != null) {
                    if (dob.Active) {
                        arActiveDay.Add(dob);
                    }
                    if (rcClip.IntersectsWith(dob.ClientRectangle)) {
                        OnPaintDay(m_g, this, dob);
                    }
                }

                /*if (OnDrawDay != null) {
                    if (dob.Active) {
                        arActiveDay.Add(dob);
                    }
                    if (rcClip.IntersectsWith(dob.ClientRectangle)) {
                        OnDrawDay(m_g, this, dob);
                    }
                }else if (dob.EditorControl != null){
                    //Bitmap bmp = dob.GetControlBitmap();

                    //m_g.DrawImage(bmp, dob.ClientRectangle, new Rectangle(new Point(0, 0), bmp.Size), GraphicsUnit.Pixel);
                    m_g.DrawLines(m_visual.LinePen, CalendarObject.PointAroundFromRect(dob.ClientRectangle));
                } else {
                    Brush br = m_visual.GetDayOfWeekBackgroundBrush(dob.Date.DayOfWeek);
                    if (dob.Selected && dob.Show) {
                        br = m_visual.SelectedBrush;
                    } else if (dob.Date.Month != m_date.Month) {
                        br = m_visual.OutOfRangeDayBackgroundBrush;
                    }

                    m_g.FillRectangle(br, dob.ClientRectangle);
                    m_g.DrawLines(m_visual.LinePen, CalendarObject.PointAroundFromRect(dob.ClientRectangle));
                    //m_g.DrawLines(dob.Date.Day == 1 ? m_visual.LinePenActive : m_visual.LinePen, CalendarObject.PointAroundFromRect(dob.ClientRectangle));
                    if (dob.Active) {
                        arActiveDay.Add(dob);
                    }

                    if (dob.Show) {
                        m_g.DrawString(dob.Date.Day.ToString()
                            , m_bIsSmall ? m_visual.DayNumberFontSmall : m_visual.DayNumberFont
                            , dob.Date.Month == m_date.Month ? Brushes.Black : Brushes.Gainsboro
                            , dob.ClientRectangle, sf);

                        if (dob.ShowCheckBox) {
                            m_g.DrawImage(dob.CheckImage.Bitmap, dob.CheckImage.ClientRectangle.Location);
                        }
                    }

                }*/
            }
            // Draw Active Date
            foreach (DayObject d in arActiveDay) {
                if (d.Show) {
                    Rectangle rc = d.ClientRectangle;
                    rc.X++;
                    rc.Y++; 
                    rc.Width-=2;
                    rc.Height-=2;
                    m_g.DrawLines(base.Style.DayStyle.ActiveDay.LinePen, CalendarObject.PointAroundFromRect(rc));
                }
            }
        }

        public int WeekCount{
            get{ return m_iWeekCount;}
            set{ m_iWeekCount = value;}
        }


        public void ResizeDayObject(DayObjectCollections selectedDays, DayObjectCollections checkedDays) {
            if (selectedDays == null)
                selectedDays = new DayObjectCollections();
            if (checkedDays == null)
                checkedDays = new DayObjectCollections();

            // Calculate Day in this month
            int iAreaWidth = m_rcClient.Width;
            int iAreaHeight = m_rcClient.Height - base.Style.CalendarHeader.Height - base.Style.WeekHeader.Height;// this.HeaderSizeToDraw - this.HeaderSizeWeek;
            int iWidth = iAreaWidth / 7;
            int iHeight = iAreaHeight / m_iWeekCount;
            int iWidthLast = iAreaWidth - iWidth * 6;
            int iHeightLast = iAreaHeight - iHeight * (m_iWeekCount - 1);
            int iCount = 0;
            int x1, y1;
            DateTime dtTmp = m_date;
            dtTmp = dtTmp.AddDays(-1 * (int)dtTmp.DayOfWeek);
            
            for (int i = 0; i < m_iWeekCount; ++i) {
                for (int j = 0; j < DAY_PER_WEEK; ++j) {
                    x1 = m_rcClient.Left + j * iWidth;
                    y1 = m_rcClient.Top + base.Style.CalendarHeader.Height + base.Style.WeekHeader.Height/*this.HeaderSizeToDraw + this.HeaderSizeWeek*/ + i * iHeight;
                    Rectangle rc = new Rectangle(x1, y1, j < DAY_PER_WEEK - 1 ? iWidth : iWidthLast, i < m_iWeekCount - 1 ? iHeight : iHeightLast);

                    if (iCount < m_arDays.Count) {
                        DayObject dob = (DayObject)m_arDays[iCount];
                        dob.Selected = selectedDays.Contains(dob);
                        dob.Checked = checkedDays.Contains(dob);


                        dob.ClientRectangle = rc;

                        if (dob.EditorControl != null) {
                            dob.EditorControl.Location = new Point(dob.ClientRectangle.Location.X + 1, dob.ClientRectangle.Location.Y + 1);// m_rcClient.Location;
                            dob.EditorControl.Size = new Size(dob.ClientRectangle.Size.Width - 1, dob.ClientRectangle.Size.Height - 1);
                        }
                    }
                    iCount++;



                    //DayObject dob = new DayObject(m_owner, rc, dtTmp);
                    //dob.Selected = false;
                    //m_arDays.Add(dob);
                    //dtTmp = dtTmp.AddDays(1);
                    //iCount++;
                }
            }
        }

        public void CreateDayObject(DayObjectCollections selectedDays, DayObjectCollections checkedDays) {
            if (selectedDays == null)
                selectedDays = new DayObjectCollections();
            if (checkedDays == null)
                checkedDays = new DayObjectCollections();
            // Calculate Day in this month
            int iAreaWidth = m_rcClient.Width;
            int iAreaHeight = m_rcClient.Height - base.Style.CalendarHeader.Height - base.Style.WeekHeader.Height;// this.HeaderSizeToDraw - this.HeaderSizeWeek;
            int iWidth = iAreaWidth / 7;
            int iHeight = iAreaHeight / m_iWeekCount;
            int iWidthLast = iAreaWidth - iWidth * 6;
            int iHeightLast = iAreaHeight - iHeight * (m_iWeekCount - 1);
            int iCount = 1;
            int x1, y1;
            DateTime dtTmp = m_date;
            dtTmp = dtTmp.AddDays(-1 * (int)dtTmp.DayOfWeek);
            m_arDays.Clear();
            for (int i = 0; i < m_iWeekCount; ++i) {
                for (int j = 0; j < DAY_PER_WEEK; ++j) {
                    x1 = m_rcClient.Left + j * iWidth;
                    y1 = m_rcClient.Top + base.Style.CalendarHeader.Height + base.Style.WeekHeader.Height/*this.HeaderSizeToDraw + this.HeaderSizeWeek*/ + i * iHeight;
                    Rectangle rc = new Rectangle(x1, y1, j < DAY_PER_WEEK - 1 ? iWidth : iWidthLast, i < m_iWeekCount - 1 ? iHeight : iHeightLast);
                    
                    DayObject dob = new DayObject(m_owner, rc, dtTmp);

                    dob.Show = false;
                    if (m_date.Month == dob.Date.Month) {
                        dob.Show = true;
                    } else {
                        if (dob.Date < m_date && m_bShowDayBeforeThisMonth) {
                            dob.Show = true;
                        } else if (dob.Date > m_date && m_bShowDayAfterThisMonth) {
                            dob.Show = true;
                        }
                    }

                    dob.MonthObject = this;
                    //if (m_date.Month == dob.Date.Month) {
                        if (selectedDays.Contains(dob)) {
                            //int index = selectedDays.IndexOf(dob);
                            //dob = (DayObject)selectedDays[index].Clone();
                            dob.Selected = true;
                            dob.ClientRectangle = rc;
                        } else {
                            dob.Selected = false;
                        }

                        if (checkedDays.Contains(dob)) {
                            dob.Checked = true;
                        } else {
                            dob.Checked = false;
                        }
                    //}

                    dob.ShowCheckBox = this.ShowCheckBox;
                    if (this.m_editorControl != null) {
                        Type t = m_editorControl.GetType();
                        dob.EditorControl = (Control)Activator.CreateInstance(t);
                    }

                    m_arDays.Add(dob);

                    dtTmp = dtTmp.AddDays(1);
                    iCount++;
                }
            }
            m_arDays.Sort();
        }

        public void SetDay(DateTime dt) {
            m_date = new DateTime(dt.Year, dt.Month, 1);
            m_iWeekCount = CalendarLayout.WeekInMonth(dt.Year, dt.Month);
        }

        public int Month {
            get { return m_date.Month; }
        }
        public int Year {
            get { return m_date.Year; }
        }
        public DateTime FirstDay {
            get {
                return m_date;
            }
        }

        public void DrawMonth(Graphics g, /*Font f, */Rectangle rcClip) {
            m_g = g;
            //m_font = f;
            //m_fontSmall = new Font(m_font.FontFamily, m_font.Size / RATIO);
            DrawMonthHeader(rcClip);
        }

        public bool ShowDayBeforeMonth {
            get { return m_bShowDayBeforeThisMonth; }
            set {
                if (m_bShowDayBeforeThisMonth != value) {
                    m_bShowDayBeforeThisMonth = value;
                }
            }
        }

        public bool ShowDayAfterMonth {
            get { return m_bShowDayAfterThisMonth; }
            set {
                if (m_bShowDayAfterThisMonth != value) {
                    m_bShowDayAfterThisMonth = value;
                }
            }
        }

        public bool IsSmall {
            get {
                return m_bIsSmall;
            }
            set {
                if (m_bIsSmall != value) {
                    m_bIsSmall = value;
                }
            }
        }
        //public int HeaderSize {
        //    get { return m_iHeaderSize; }
        //    set {
        //        if (m_iHeaderSize != value) {
        //            m_iHeaderSize = value;
        //            m_iHeaderSizeSmall = (int)(value / RATIO);
        //        }
        //    }
        //}

        public override bool Equals(object obj) {
            MonthObject o = (MonthObject)obj;
            DateTime dt1 = new DateTime(m_date.Year, m_date.Month, 1);
            DateTime dt2 = new DateTime(o.m_date.Year, o.m_date.Month, 1);
            return dt1 == dt2;
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public override string ToString() {
            return string.Format("{0:MM/yyyy}", m_date);
        }
        
    }


    public class ImageObject : CalendarObject{
        private Bitmap m_bmp;

        public ImageObject(Calendar owner, Rectangle rc, Bitmap bmp) : base(owner){
            m_bmp = bmp;
            m_rcClient = rc;
            m_hitTestObj = HitTestCalendarObject.ImageObject;
        }

        public Bitmap Bitmap {
            get {
                return m_bmp;
            }
            set {
                m_bmp = value;
            }
        }

    }

    internal class ArrowImageObject : ImageObject {
        internal enum ArrowType {
            Back, Next
        }
        ArrowType m_type = ArrowType.Back;
        public const int SIZE = 16;

        public ArrowImageObject(Calendar owner, Point x1y1, ArrowType type)
            : base(owner, new Rectangle(x1y1, new Size(SIZE, SIZE)) , type == ArrowType.Back ? Properties.Resources.prevup : Properties.Resources.nextup) {
            
            m_type = type;
        }
        public Size ImageSize {
            get {
                return new Size(SIZE, SIZE);
            }
        }
    }


}
