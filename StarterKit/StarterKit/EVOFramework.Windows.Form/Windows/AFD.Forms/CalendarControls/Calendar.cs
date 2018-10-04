using System;
using System.Reflection;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Drawing.Design;
using System.Collections;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;



namespace Cube.AFD.Windows.Controls.CalendarControls {

    
    [Designer(typeof(Design.CalendarDesigner))]
    //[DesignerSerializer(typeof(Design.CalendarCodeDomSerializer), typeof(CodeDomSerializer))]
    [ToolboxBitmap(typeof(System.Windows.Forms.MonthCalendar))]
    public partial class Calendar : UserControl {
        private const int MIN_HEIGHT = 100;
        private const int MIN_WIDHT = 100;

        public delegate void ActiveDayChangedHandler(DayObject preActiveDay, DayObject curActiveDay);
        public delegate void CheckChangedHandler(DayObject day);
        public delegate void DayClickHandler(DayObject day);
        public delegate void DayDoubleClickHandle(DayObject day);
        //kim Add 20070510
        public delegate void CheckChangedDisplayMonth(int iYear, int iMonth);
        public delegate void CheckChangingDisplayMonth(int iYear, int iMonth,ref bool bHandled);
        //----------------
        public event ActiveDayChangedHandler OnActiveDayChanged = null;
        public event CheckChangedHandler OnCheckChanged = null;
        public event EventHandler OnSelectedDayChanged = null;
        public event MonthObject.PaintDayHandler OnPaintDay = null;
        public event DayClickHandler OnDayClick = null;
        public event DayDoubleClickHandle OnDayDoubleClick = null;
        //kim Add 20070510
        public event CheckChangedDisplayMonth OnDisplayMonthChanged = null;
        public event CheckChangingDisplayMonth OnDisplayMonthChanging = null;
        private bool bChangedDisplayMonthHandled = false;
        //--------------------

        private ImageList m_imglIcon = null;
        private ImageList m_imglDayBackground = null;
        private SpecialDayCollection m_specialDays = null;

        private int m_iBackImgIdxTemplate= -1;

        // off-screen object
        private Graphics m_gOff = null;
        private Bitmap m_bmpOff = null;

        private CalendarType m_calendarType = CalendarType.Region;
        private DateTime m_dtToday;
        private ArrowImageObject m_imgBack = null;
        private ArrowImageObject m_imgNext = null;
        private int m_iHeaderHeight = 25;
        private int m_iArrowImageOffset = 3;
        private CalendarLayout m_layout = CalendarLayout.One;
        private CalendarLayout.LayoutType m_layoutType = CalendarLayout.LayoutType.One;
        private ArrayList m_arDisplayedMonths = new ArrayList();
        private bool m_bKeebDisplayedMonthInMemory = false;
        private MonthObject[] m_months = new MonthObject[0];
        private int m_iStartYear = DateTime.Today.Year;
        private int m_iStartMonth = DateTime.Today.Month;
        private Point m_ptMouseDown = Point.Empty;

        private CalendarStyle m_style = new CalendarStyle();
        private DayObject m_dayActive = null;

        private SelectionPolicy m_selection = SelectionPolicy.Single;
        private DayObjectCollections m_selectedDays = new DayObjectCollections();
        private DayObjectCollections m_checkedDays = new DayObjectCollections();
        private ContextMenu m_ctxMonth = new ContextMenu();
        private Control m_currentEditorControl = null;
        private EditorView m_editView = EditorView.Default;
        private EditorMode m_editMode = EditorMode.DisplayWhenEdit;
        private EditorWhen m_editWhen = EditorWhen.DoubleClick;
        private NumericUpDown m_yearUpDown;
        private bool m_bShowCheckBox = false;
        private Hashtable m_htDayValueMap = new Hashtable();   // Key will be keep Date (day, month & year), Value will be keep data for display on editor control

        private ArrayList m_arRectDraw = new ArrayList();


        private DateTimeFormatInfo m_dtInfo = null;

        public EditorView EditorView {
            get {
                return m_editView;
            }
            set {
                if (m_editView != value) {
                    m_editView = value;
                }
            }
        }

        public EditorWhen EditorWhen {
            get {
                return m_editWhen;
            }
            set {
                m_editWhen = value;
            }
        }

        public EditorMode EditorMode {
            get {
                return m_editMode;
            }
            set {
                if (m_editMode != value) {
                    m_editMode = value;
                }
            }
        }


        [Browsable(false)]
        public CalendarStyle CalendarStyle {
            get {
                return m_style;
            }
            set {
                m_style = value;
                CreateMenuItemList();
            }
        }

        public Calendar() {
            
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            m_style = CalendarStyle.CoolEye;// new CalendarStyle();
            //// Calendar Header [Display Month & Year]
            //this.CalendarStyle.CalendarHeader = new HeaderStyle(this.Font, Color.FromArgb(63, 125, 145), Color.FromArgb(148, 184, 220), 24);
            //// Week Header
            //this.CalendarStyle.WeekHeader = new HeaderStyle(this.Font, Color.Black, Color.Green, 20);
            //// Day Style [Display all day in month]
            //this.CalendarStyle.DayStyle.Font = this.Font;
            //this.CalendarStyle.DayStyle.NormalDay = new DayCellStyle(Color.Black, Color.White);
            //this.CalendarStyle.DayStyle.InactiveDay = new DayCellStyle(Color.FromArgb(222, 223, 228), Color.FromArgb(232, 238, 236));
            //this.CalendarStyle.DayStyle.SelectionDay = new DayCellStyle(Color.Black, Color.Blue);
            //this.CalendarStyle.DayStyle.ActiveDay = new DayCellStyle(Color.Black, Color.White, Color.Blue);
            //this.CalendarStyle.DayStyle.TodayDay = new DayCellStyle(Color.Blue, Color.Red, Color.Pink);
            //// Calendar Grid Color
            //this.CalendarStyle.GridColor = Color.Green;
            ////this.CalendarStyle.MonthText = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
            ////this.CalendarStyle.WeekText = new string[] { "1", "อังคาร" };

            CreateMenuItemList();
            m_yearUpDown = new NumericUpDown();
            m_yearUpDown.ValueChanged += new EventHandler(m_yearUpDown_ValueChanged);
            m_yearUpDown.Minimum = 1000;
            m_yearUpDown.Maximum = DateTime.MaxValue.Year;
            m_yearUpDown.Visible = false;
            this.Controls.Add(m_yearUpDown);




            //m_monthVisual = new MonthVisual();
            //m_monthVisual.TodayBackgroundColor =Color.FromArgb(255, 163, 163);
            //m_monthVisual.Header.Font = this.Font;
            //m_monthVisual.Header.BackColor = Color.FromArgb(148,184,220);
            //m_monthVisual.Header.ForeColor = Color.FromArgb(63, 125, 145);

            //m_monthVisual.Week.Font = this.Font;
            //m_monthVisual.Week.BackColor = Color.FromArgb(148,203,220);
            //m_monthVisual.Week.ForeColor = Color.FromArgb(63, 125, 145);

            //m_monthVisual.LineColor = Color.FromArgb(63, 125, 145);
            //m_monthVisual.DayNumberFont = new Font(this.Font.FontFamily, this.Font.Size / 1.1F);

            //m_monthVisual.SetDayOfWeekBackgroundColor(DayOfWeek.Sunday, Color.FromArgb(255, 250, 231));
            //m_monthVisual.SetDayOfWeekBackgroundColor(DayOfWeek.Saturday, Color.FromArgb(255, 250, 231));

            //m_monthVisual.OutOfRangeDayBackgroundColor = Color.FromArgb(232, 238, 236);

            m_imglIcon = null;
            m_specialDays = new SpecialDayCollection(this);
            //_ImageList = null;
            //_ItemCollection = new ImageIndexMappingCollection(this);
            //_ItemCollection.CollectionChanged += new EventHandler(OnCollectionChanged);


            
            ReCreateOffScreenObject();
            m_dtToday = DateTime.Now;


            CreateObject();
            AttachEvent();
            ReCreateMonthObject(false);
            //kim add 20070510
            this.OnDisplayMonthChanged += new CheckChangedDisplayMonth(Calendar_OnDisplayMonthChanged);
            this.OnDisplayMonthChanging += new CheckChangingDisplayMonth(Calendar_OnDisplayMonthChanging);
            //End --------------------------------------------------------
            //_ItemCollection = new ImageIndexMappingCollection(this);


            //m_editorControl = new DayEdit1();
            //this.Controls.Add(m_editorControl);
            //m_editorControl.Visible = false;

            //this.EditorControl = new DayEdit1();


        }
        //kim add 20070510---------------------------------------------------------------------
        void Calendar_OnDisplayMonthChanging(int iYear, int iMonth,ref bool bHandled)
        {
            this.bChangedDisplayMonthHandled = bHandled;
        }
        void Calendar_OnDisplayMonthChanged(int iYear, int iMonth)
        {
            //OnDisplayMonthChanged(iYear, iMonth);
            //throw new Exception("The method or operation is not implemented.");
        }
        //--------------------------------------------------------------------------------------------

        void _ItemCollection_CollectionChanged(object sender, EventArgs e) {
            Invalidate();
        }

        private void ConstructRectangleToDraw(Rectangle rc) {
            m_arRectDraw.Add(rc);
        }

        private Control m_editorControl;
        private Type m_editorControlType = null;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public SpecialDayCollection SpecialDays{
            get {
                return m_specialDays;
            }
        }

        //[Browsable(false)]
        //public Control EditorControl {
        //    get { return m_editorControl; }
        //    set {
        //        m_editorControl = value;
        //        foreach (MonthObject m in m_months) {
        //            m.EditorControl = m_editorControl;
        //        }
        //    }
        //}

        [Browsable(false)]
        public Type EditorControlType {
            get { return m_editorControlType; }
            set {
                if (value == null)
                    return;
                if (value.IsSubclassOf(typeof(DayEditor))) {
                    object oControl = (DayEditor)Activator.CreateInstance(value);
                    m_editorControlType = value;
                    if (m_editorControl != null) {
                        m_editorControl.Dispose();
                        m_editorControl = null;
                        GC.Collect();
                    }
                    m_editorControl = (Control)oControl;
                    foreach (MonthObject m in m_months) {
                        m.EditorControl = m_editorControl;
                    }
                } else {
                    throw new Exception("Invalid DayEditor type");
                }

                /*
                Type tif = oControl.GetType().GetInterface("IEditorControl");
                if (tif != null) {
                    m_editorControlType = value;
                    if (m_editorControl != null) {
                        m_editorControl.Dispose();
                        m_editorControl = null;
                        GC.Collect();
                    }
                    m_editorControl = (Control)oControl;
                    foreach (MonthObject m in m_months) {
                        m.EditorControl = m_editorControl;
                    }
                }*/
            }
        }


        private void CreateMenuItemList() {
            m_ctxMonth.MenuItems.Clear();
            DateTime dt = new DateTime(DateTime.Today.Year, 1, 1);
            for (int i = 0; i < 12; ++i) {
                MenuItem m = new MenuItem();
                string s = m_style.MonthText.GetMonthText((MonthOfYear)dt.Month-1, CalendarObject.FormatDate(m_dtInfo, "{0:MMMM}", dt));
                m.Text = s;
                m.Click += new EventHandler(this.OnMonthClick);
                m_ctxMonth.MenuItems.Add(m);
                dt = dt.AddMonths(1);
            }
        }

        private void ChangeMenuItemText() {
            foreach (MenuItem m in m_ctxMonth.MenuItems) {
                DateTime dt = new DateTime(DateTime.Today.Year, m.Index + 1, 1);
                string s = m_style.MonthText.GetMonthText((MonthOfYear)dt.Month-1, CalendarObject.FormatDate(m_dtInfo, "{0:MMMM}", dt));
                m.Text = s;// CalendarObject.FormatDate(m_dtInfo, "{0:MMMM}", new DateTime(DateTime.Today.Year, m.Index + 1, 1));
            }
        }

        private void SetCheckedMenuItem(int month) {
            foreach (MenuItem m in m_ctxMonth.MenuItems) {
                bool bChecked = (m.Index + 1) == month;
                if (bChecked) {
                    if (m.Checked) {
                        break;
                    } else {
                        m.Checked = true;
                    }
                } else {
                    if (m.Checked) {
                        m.Checked = false;
                    }
                }
            }
        }

        private int GetYearNumberUsingCalendarType(int iYear) {
            string s = CalendarObject.FormatDate(m_dtInfo, "{0:yyyy}", new DateTime(iYear, 1, 1));
            return Convert.ToInt32(s);
        }

        private void ShowYearNumericUpDown(TextObject txtObj) {
            if (txtObj != null) {
                switch (txtObj.HitTestType) {
                    case HitTestCalendarObject.YearText:  // Display Numeric UpDown
                        m_yearUpDown.Location = txtObj.ClientRectangle.Location;
                        m_yearUpDown.Size = txtObj.ClientRectangle.Size;// new Size(txtObj.ClientRectangle.Width + SystemInformation.SmallCaptionButtonSize.Width, txtObj.ClientRectangle.Height);
                        m_yearUpDown.Width += SystemInformation.SmallIconSize.Width+5;
                        m_yearUpDown.Value = GetYearNumberUsingCalendarType(txtObj.MonthObject.Year);
                        m_yearUpDown.Visible = true;
                        m_yearUpDown.Tag = txtObj;
                        break;
                }
            }
        }

        private void HideEditorControl() {
            if (m_currentEditorControl != null) {
                if (m_currentEditorControl.Visible) {
                    ((DayEditor)m_currentEditorControl).Bitmap = CaptureControl(m_currentEditorControl);
                    m_currentEditorControl.Visible = false;
                    m_currentEditorControl.Enabled = false;
                    this.Controls.Remove(m_currentEditorControl);
                    
                    m_currentEditorControl = null;
                    this.ActiveControl = null;
                    //((IEditorControl)m_currentEditorControl).Bitmap = CaptureControl(m_currentEditorControl);
                    //m_currentEditorControl.Visible = false;
                    //this.Controls.Remove(m_currentEditorControl);
                    //m_currentEditorControl = null;
                }
            }
            
        }

        private void ShowMonthContextMenu(TextObject txtObj) {
            if (txtObj.HitTestType == HitTestCalendarObject.MonthText) {
                if (m_yearUpDown.Visible) {
                    m_yearUpDown.Visible = false;
                }
                HideEditorControl();

                SetCheckedMenuItem(txtObj.MonthObject.Month);
                m_ctxMonth.Tag = txtObj;
                m_ctxMonth.Show(this, txtObj.Location);
            }
        }



        public bool EditModeOn() {
            return ShowEditorControlOnSelectedDay(m_dayActive);
        }

        public bool EditModeOff() {
            KeepEditorData();

            if (m_editMode == EditorMode.Alway)
                return false;

            HideEditorControl();

            return true;
        }

        //public bool KeebDisplayedMonthInMemory {
        //    get { return m_bKeebDisplayedMonthInMemory; }
        //    set {
        //        if (m_bKeebDisplayedMonthInMemory != value) {
        //            m_bKeebDisplayedMonthInMemory = value;
        //        }
        //    }
        //}

        [Browsable(false)]
        public DataTable EditorData{
            get {
                KeepEditorData();
                DataTable dtResult = new DataTable();
                // Adding Column
                dtResult.Columns.Add("Date", typeof(string));
                dtResult.Columns.Add("Value", typeof(object));

                // Adding Row Data
                ArrayList arDate = new ArrayList();
                IEnumerator i = m_htDayValueMap.Keys.GetEnumerator();
                while (i.MoveNext()) {
                    arDate.Add(Convert.ToDateTime(i.Current));
                }
                arDate.Sort();
                // Keep data into datatable
                foreach (DateTime dt in arDate) {
                    object oValue = null;
                    if (m_htDayValueMap.ContainsKey(dt)) {
                        oValue = m_htDayValueMap[dt];
                    }
                    dtResult.Rows.Add(dt, oValue);
                }

                return dtResult;

            }
        }

        private void KeepEditorData() {
            foreach (MonthObject m in m_months) {
                foreach (DayObject d in m.DayObjects) {
                    if (d.EditorControl != null) {
                        DayEditor editor = (DayEditor)d.EditorControl;
                        if (editor.IsValueChanged) {
                            DateTime dtKey = new DateTime(d.Date.Year, d.Date.Month, d.Date.Day);
                            m_htDayValueMap[dtKey] = editor.Value;
                        }

                        //IEditorControl iec = (IEditorControl)d.EditorControl;
                        //if (iec.IsValueChanged) {
                        //    DateTime dtKey = new DateTime(d.Date.Year, d.Date.Month, d.Date.Day);
                        //    m_htDayValueMap[dtKey] = iec.Value;
                        //}
                    }
                }
            }
        }
        //kim change private to public
        public void DisplayMonth(int iYear, int iMonth)
        {
            
            //kim add 20070511
            this.bChangedDisplayMonthHandled = false;
            if (OnDisplayMonthChanging != null) {
                OnDisplayMonthChanging(iYear, iMonth, ref this.bChangedDisplayMonthHandled);
            }
            if (this.bChangedDisplayMonthHandled == true) {
                return;
            }
            //end add
            // Keep displayed month
            if (m_bKeebDisplayedMonthInMemory) {
                foreach (MonthObject m in m_months) {
                    if (m_arDisplayedMonths.Contains(m)) {
                        int index = m_arDisplayedMonths.IndexOf(m);
                        m_arDisplayedMonths[index] = m;
                    } else {
                        m_arDisplayedMonths.Add(m);
                    }
                }
            }

            // Keep object data from editor control
            KeepEditorData();


            // Start day of month for display
            DateTime dtNew = new DateTime(iYear, iMonth, 1);
            // Detatch event
            foreach (MonthObject m in m_months) {
                m.OnCalendarObjectInvalidate -= new CalendarObject.CalendarObjectInvalidateHandler(CalendarObject_OnCalendarObjectInvalidate);
            }
            if (m_bKeebDisplayedMonthInMemory == false) {
                for (int i=0;i<m_months.Length;++i){
                    MonthObject m = m_months[i];
                    m.Dispose();
                    m = null;
                }
                m_months = null;
                GC.Collect();
            }
            // Get new month object
            m_months = m_layout.GetMonthObject(this, this.ClientRectangle, 0, dtNew.Year, dtNew.Month, m_arDisplayedMonths, MonthObject_OnPaintDay);
            // Create DayObject for each month
            foreach (MonthObject m in m_months) {
                //m.HeaderSize = m_iHeaderHeight;
                m.ShowCheckBox = this.ShowCheckBox;
                if (m.EditorControl == null) {
                    m.EditorControl = m_editorControl;
                }
                if (m.DayObjects.Count <= 0) {
                    m.CreateDayObject(m_selectedDays, m_checkedDays);
                } else {
                    m.ResizeDayObject(m_selectedDays, m_checkedDays);
                }

                // Set value to EditorControl
                foreach (DayObject d in m.DayObjects) {
                    if (d.EditorControl != null) {
                        DateTime dtKey = d.DatePart;
                        if (m_htDayValueMap.ContainsKey(dtKey)) {
                            DayEditor editor = (DayEditor)d.EditorControl;
                            editor.Value = m_htDayValueMap[dtKey];

                            //IEditorControl iec = (IEditorControl)d.EditorControl;
                            //iec.Value = m_htDayValueMap[dtKey];
                        }
                    }
                }
                m.OnCalendarObjectInvalidate += new CalendarObject.CalendarObjectInvalidateHandler(CalendarObject_OnCalendarObjectInvalidate);
                
                
            }

            ShowEditorControl();


            //m_editorControl.Visible = false;
            if (m_currentEditorControl != null) {
                m_currentEditorControl.Visible = false;
                m_currentEditorControl.Enabled = false;
                this.Controls.Remove(m_currentEditorControl);
                m_currentEditorControl = null;
            }
            this.Invalidate();

            //kim Add 20070510
            if (OnDisplayMonthChanged != null){
                OnDisplayMonthChanged(iYear, iMonth);
            }
            //-------------------------------------------
        }

        [Browsable(false)]
        public Image BackgroundImageTemplate {
            get {
                if (m_imglDayBackground == null)
                    return null;
                if (m_iBackImgIdxTemplate >= 0 && m_iBackImgIdxTemplate < m_imglDayBackground.Images.Count) {
                    return m_imglDayBackground.Images[m_iBackImgIdxTemplate];
                } else {
                    return null;
                }
            }
        }

        public void PaintDay(Graphics g, MonthObject monthObj, DayObject dayObj) {
            bool bToday = false;
            //MonthVisual mVisual = monthObj.MonthVisual;

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Far;
            sf.LineAlignment = StringAlignment.Near;

            int index = m_style.WeekText.IndexOf(dayObj.Date.DayOfWeek);
            Brush br;
            if (index >= 0) {
                br = m_style.WeekText[index].BackBrush;
                if (br == null) {
                    br = m_style.DayStyle.NormalDay.BackBrush;
                }
            } else {
                br = m_style.DayStyle.NormalDay.BackBrush;
            }
            Brush brFore = m_style.DayStyle.NormalDay.ForeBrush;
            

            if (dayObj.Date.Date == DateTime.Today.Date && dayObj.Show) {
                br = m_style.DayStyle.TodayDay.BackBrush;
                brFore = m_style.DayStyle.TodayDay.ForeBrush;
                bToday = true;
            }
            if (dayObj.Selected && dayObj.Show) {
                br = m_style.DayStyle.SelectionDay.BackBrush;
                brFore = m_style.DayStyle.SelectionDay.ForeBrush;
            }else if (dayObj.Date.Month != monthObj.Month) {
                br = m_style.DayStyle.InactiveDay.BackBrush;
                brFore = m_style.DayStyle.InactiveDay.ForeBrush;
            }
            Image imgBack = this.BackgroundImageTemplate;
            g.FillRectangle(br, dayObj.ClientRectangle);
            if (imgBack != null) {
                g.DrawImage(imgBack, dayObj.ClientRectangle);
            }
            g.DrawLines(m_style.GridPen, CalendarObject.PointAroundFromRect(dayObj.ClientRectangle));
            if (bToday) {
                Rectangle rc = dayObj.ClientRectangle;
                rc.Inflate(-1, -1);
                g.DrawLines(m_style.DayStyle.TodayDay.LinePen, CalendarObject.PointAroundFromRect(rc));
            }
            //m_g.DrawLines(dob.Date.Day == 1 ? m_visual.LinePenActive : m_visual.LinePen, CalendarObject.PointAroundFromRect(dob.ClientRectangle));

            if (dayObj.Show) {
                SpecialDay sDay = m_specialDays.GetSpecialDay(dayObj.Date);
                if (sDay != null && m_imglDayBackground != null) { // Draw background
                    if (sDay.ImageIndex >= 0 && sDay.ImageIndex < m_imglDayBackground.Images.Count) {
                        g.DrawImage(m_imglDayBackground.Images[sDay.ImageIndex], dayObj.ClientRectangle);
                    }
                }
                // Day Text
                g.DrawString(dayObj.Date.Day.ToString()
                    , monthObj.IsSmall ? m_style.DayStyle.FontSmall : m_style.DayStyle.Font
                    , brFore// dayObj.Date.Month == monthObj.Month ? Brushes.Black : Brushes.Gainsboro
                    , dayObj.ClientRectangle, sf);

                Point ptLocation = new Point(dayObj.ClientRectangle.Left + DayObject.CHECK_BOX_OFFSET, dayObj.ClientRectangle.Top + DayObject.CHECK_BOX_OFFSET);
                // Check Box
                if (dayObj.ShowCheckBox) {
                    ptLocation = dayObj.CheckImage.ClientRectangle.Location;
                    g.DrawImage(dayObj.CheckImage.Bitmap, ptLocation);
                    ptLocation.X += dayObj.CheckImage.Bitmap.Width + DayObject.CHECK_BOX_OFFSET;
                }

                // Icon from special day
                if (m_imglIcon != null) {
                    if (sDay != null) {
                        if (sDay.ImageIndexies != null) {
                            ptLocation.Y--;
                            int iCountLine = 0;
                            foreach (ImageIndexMapping im in sDay.ImageIndexies) {
                                if (im != null) {
                                    if (im.ImageIndex >= 0 && im.ImageIndex < m_imglIcon.Images.Count) {
                                        g.DrawImage(m_imglIcon.Images[im.ImageIndex], ptLocation);
                                        ptLocation.X += m_imglIcon.ImageSize.Width + DayObject.CHECK_BOX_OFFSET;
                                        if (ptLocation.X + m_imglIcon.ImageSize.Width > dayObj.ClientRectangle.Right) {
                                            ptLocation.X = dayObj.ClientRectangle.Left + 1;
                                            iCountLine++;
                                            ptLocation.Y += iCountLine * m_imglIcon.ImageSize.Height + DayObject.CHECK_BOX_OFFSET; ;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }



            }
        }

        [Browsable(false)]
        public DateTime FirstDay {
            get {
                if (m_months != null) {
                    if (m_months.Length > 0) {
                        MonthObject m = m_months[0];
                        if (m.DayObjects.Count > 0) {
                            return ((DayObject)m.DayObjects[0]).Date;
                        }
                    }
                }
                return DateTime.MinValue;
            }
        }

        [Browsable(false)]
        public DateTime LastDay {
            get {
                if (m_months != null) {
                    if (m_months.Length > 0) {
                        MonthObject m = m_months[m_months.Length - 1];
                        if (m.DayObjects.Count > 0) {
                            return ((DayObject)m.DayObjects[m.DayObjects.Count - 1]).Date;
                        }
                    }
                }
                return DateTime.MinValue;
            }
        }
        private void MonthObject_OnPaintDay(Graphics g, MonthObject monthObj, DayObject dayObj) {
            //int iMonthBreak = 5;
            //int iDayBreak = 31;
            //if (dayObj.Date.Month == iMonthBreak && dayObj.Date.Day == iDayBreak) {
            //    Console.WriteLine("Break");
            //}

            if (OnPaintDay != null) {
                OnPaintDay(g, monthObj, dayObj);
            } else {
                bool bAlreadyDraw = false;
                if (m_editView == EditorView.ForeControl || m_editView == EditorView.OwnerDraw) {
                    if (dayObj.EditorControl != null) {    // Draw from control
                        if (m_editView == EditorView.ForeControl) {
                            Bitmap bmp = ((DayEditor)dayObj.EditorControl).Bitmap;
                            //Bitmap bmp = ((IEditorControl)dayObj.EditorControl).Bitmap;
                            if (bmp != null) {
                                Point ptLocation = dayObj.ClientRectangle.Location;
                                Size sz = dayObj.ClientRectangle.Size;
                                ptLocation = new Point(ptLocation.X + 1, ptLocation.Y + 1);
                                sz = new Size(sz.Width - 1, sz.Height - 1);

                                Rectangle rcDest = new Rectangle(ptLocation, sz);
                                Rectangle rcSrc = new Rectangle(0, 0, bmp.Width, bmp.Height);

                                g.DrawImage(bmp, rcDest, rcSrc, GraphicsUnit.Pixel);

                                bAlreadyDraw = true;
                            }
                        } else if (m_editView == EditorView.OwnerDraw) {
                            ((DayEditor)dayObj.EditorControl).PaintDay(this, g, monthObj, dayObj);
                            //((IEditorControl)dayObj.EditorControl).PaintDay(this, g, monthObj, dayObj);
                            bAlreadyDraw = true;
                        }
                    }
                }

                if (bAlreadyDraw == false) {
                    PaintDay(g, monthObj, dayObj);
                }
            }

        }


        private void m_yearUpDown_ValueChanged(object sender, EventArgs e) {
            if (m_yearUpDown.Tag != null) {
                TextObject txtObj = (TextObject)m_yearUpDown.Tag;
                int iMonth = txtObj.MonthObject.Month;
                int iYear = Convert.ToInt32(m_yearUpDown.Value);
                DateTime dtNew = CalendarObject.DateFromYearMonth(m_dtInfo, iYear, iMonth);
                // Get Month Index
                int iCount = 0;
                MonthObject month= null;
                foreach (MonthObject m in m_months) {
                    if (m == txtObj.MonthObject) {
                        month = m;
                        break;
                    }
                    iCount++;
                }
                if (month != null) {
                    DateTime dtFirst = dtNew.AddMonths(-1 * iCount);
                    DisplayMonth(dtFirst.Year, dtFirst.Month);
                    m_yearUpDown.Tag = m_months[iCount].YearTextObject;

                    //Point pt = this.PointToClient(MousePosition);
                    //TextObject txtObjNew = GetHitTestObject(pt.X, pt.Y);
                    //m_yearUpDown.Tag = txtObjNew;
                }
            }
            //DateTime dt = Convert.ToDateTime("01/01/2549", m_dtInfo);
            //Console.WriteLine("he");
        }


        void OnMonthClick(object sender, EventArgs e) {
            MenuItem mItem = (MenuItem)sender;
            if (mItem.Checked) {
                return;
            }


            try {
                if (m_ctxMonth.Tag is TextObject) {
                    TextObject txtObj = (TextObject)m_ctxMonth.Tag;
                    if (txtObj.HitTestType == HitTestCalendarObject.MonthText) {
                        // Get index of month in calendar
                        int iMonthIndex = 0;
                        MonthObject mOwner = null;
                        foreach (MonthObject m in m_months) {
                            if (m == txtObj.MonthObject) {
                                mOwner = m;
                                break;
                            }
                            iMonthIndex++;
                        }
                        if (mOwner != null) {
                            int iNewMonth = ((MenuItem)sender).Index+1;
                            DateTime dtNew = new DateTime(mOwner.Year, iNewMonth, 1);
                            // Get first day of first month to show
                            dtNew = dtNew.AddMonths(-1 * iMonthIndex);
                            DisplayMonth(dtNew.Year, dtNew.Month);
                        }
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        public CalendarType CalendarType {
            get {
                return m_calendarType;
            }
            set {
                if (m_calendarType != value){
                    m_calendarType = value;
                    switch (m_calendarType) {
                        case CalendarType.Region:
                            m_dtInfo = null;
                            break;
                        case CalendarType.Gregorian:
                            m_dtInfo = new CultureInfo("en-US").DateTimeFormat;
                            break;
                        case CalendarType.ThaiBuddhist:
                            m_dtInfo = new CultureInfo("th-TH").DateTimeFormat;
                            break;
                    }
                    ChangeMenuItemText();
                    this.Invalidate();
                }
            }
        }

        [Browsable(false)]
        public DateTimeFormatInfo DateTimeFormatInfo {
            get {
                return m_dtInfo;
            }
        }

        private DayObject GetDayFromPoint(Point pt) {
            foreach (MonthObject m in m_months) {
                DayObject d = m.GetDateFromPoint(pt.X, pt.Y);
                if (d != null)
                    return d;
            }
            return null;
        }

        private DayObjectCollections GetDaysBetweenDate(DateTime d1, DateTime d2) {
            DayObjectCollections days = new DayObjectCollections();
            foreach (MonthObject m in m_months) {
                DayObject[] ds = m.GetDaysBetweenDate(d1, d2);
                foreach (DayObject d in ds) {
                    days.Add(d);
                }
            }
            return days;
        }

        //private DayObjectCollections GetDaysFromRect(Rectangle rc) {
        //    DayObjectCollections days = new DayObjectCollections();
        //    foreach (MonthObject m in m_months) {
        //        DayObject[] ds = m.GetDaysInRect(rc);
        //        foreach (DayObject d in ds) {
        //            days.Add(d);
        //        }
        //    }
        //    return days;
        //}

        // Can be select only day

        [Browsable(false)]
        public DayObject ActiveDay {
            get {
                return m_dayActive;
            }
            set {
                DayObject prev = m_dayActive;
                if (m_dayActive == null) {
                    m_dayActive = value;
                    if (m_editorControl != null) {
                        m_editorControl.Visible = false;
                    }
                    if (OnActiveDayChanged != null) {
                        OnActiveDayChanged(prev, m_dayActive);
                    }
                } else if (m_dayActive != value) {
                    m_dayActive = value;
                    if (OnActiveDayChanged != null) {
                        OnActiveDayChanged(prev, m_dayActive);
                    }
                }
            }
        }

        private void SetDayChecked(DayObject dob, Point pt) {
            if (dob == null)
                return ;

            
            if (dob.CheckImage.ClientRectangle.Contains(pt)) {
                dob.Checked = !dob.Checked;
                if (OnCheckChanged != null) {
                    OnCheckChanged(dob);
                }
                this.Invalidate(dob.CheckImage.ClientRectangle);
                if (dob.Checked && m_checkedDays.Contains(dob) == false) {
                    m_checkedDays.Add(dob);
                } else if (dob.Checked == false && m_checkedDays.Contains(dob)) {
                    m_checkedDays.Remove(dob);
                }
            }

        }

        [Browsable(false)]
        public DayObjectCollections CheckedDays {
            get {
                return m_checkedDays; 
            }
        }

        private Rectangle SetSelectedDay(DayObject dob, bool bSelected) {
            Rectangle rcDraw = Rectangle.Empty;

            foreach (MonthObject m in m_months) {
                foreach (DayObject d in m.DayObjects) {
                    if (d == dob) {
                        if (d.Selected != bSelected) {
                            d.Selected = bSelected;
                            if (d.Show) {
                                if (rcDraw == Rectangle.Empty) {
                                    rcDraw = d.ClientRectangle;
                                } else {
                                    rcDraw = Rectangle.Union(rcDraw, d.ClientRectangle);
                                }
                            }
                        }
                    }
                }
            }
            return rcDraw;
        }

        private void DoSelectionSingle(Point pt) {
            DayObject dob = GetDayFromPoint(pt);
            if (dob != null) {
                // Set new selection day
                if (this.ActiveDay != null && this.ActiveDay != dob) {
                    this.ActiveDay.Active = false;
                    ConstructRectangleToDraw(this.ActiveDay.ClientRectangle);
                }
                
                if (this.ActiveDay != dob) {
                    dob.Active = true;
                    this.ActiveDay = dob;
                    ConstructRectangleToDraw(this.ActiveDay.ClientRectangle);
                }

                if (dob.Selected == false) {
                    //dob.Selected = true;
                    ConstructRectangleToDraw(SetSelectedDay(dob, true));
                    // Clear old selected day
                    foreach (DayObject d in m_selectedDays) {
                        if (d.Selected) {
                            ConstructRectangleToDraw(SetSelectedDay(d, false));
                            //this.Invalidate(d.ClientRectangle);
                        }
                    }
                    m_selectedDays.Clear();
                    m_selectedDays.Add(dob);
                    FireOnSelectedDayChanged();
                    //bNeedDraw = true;
                }

                InvalidateRectDraw();
            }
        }

        private void InvalidateRectDraw() {
            if (m_arRectDraw.Count > 0) {
                foreach (Rectangle rc in m_arRectDraw) {
                    this.Invalidate(rc);
                }
            }
        }

        private void DoSelectionMerge(Point pt) {
            DayObject dob = GetDayFromPoint(pt);
            if (dob != null) { // Get new selected day
                ConstructRectangleToDraw(SetSelectedDay(dob, !dob.Selected));

                if (this.ActiveDay != null && this.ActiveDay != dob) {
                    this.ActiveDay.Active = false;
                    ConstructRectangleToDraw(this.ActiveDay.ClientRectangle);
                    this.ActiveDay = null;
                }

                if (this.ActiveDay != dob) {
                    dob.Active = true;
                    this.ActiveDay = dob;
                    ConstructRectangleToDraw(this.ActiveDay.ClientRectangle);
                }

                if (dob.Selected && m_selectedDays.Contains(dob) == false) {
                    m_selectedDays.Add(dob);
                    FireOnSelectedDayChanged();
                }
                if (dob.Selected == false && m_selectedDays.Contains(dob)) {
                    m_selectedDays.Remove(dob);
                    FireOnSelectedDayChanged();
                }

                InvalidateRectDraw();
            }
        }

        private void DoSelectionContinuous(Point pt) {
            if (m_ptMouseDown == Point.Empty) { // First Mouse Down, Clear all old selection
                // Get First Day Selected
                DayObject dFirst = GetDayFromPoint(pt);
                if (dFirst != null) {
                    m_ptMouseDown = pt;
                    // Clear All Selection
                    foreach (DayObject dOld in m_selectedDays) {
                        if (dOld.Selected) {
                            if (dFirst != dOld) {
                                ConstructRectangleToDraw(SetSelectedDay(dOld, false));
                            }
                        }
                    }
                    m_selectedDays.Clear();
                    // Add first day selected.
                    
                    m_selectedDays.Add(dFirst);
                    FireOnSelectedDayChanged();
                    if (dFirst.Selected == false) {
                        ConstructRectangleToDraw(SetSelectedDay(dFirst, true));
                        //this.Invalidate(dFirst.ClientRectangle);
                    }

                    if (this.ActiveDay != null && this.ActiveDay != dFirst) {
                        this.ActiveDay.Active = false;
                        ConstructRectangleToDraw(this.ActiveDay.ClientRectangle);
                        this.ActiveDay = null;
                    }

                    if (this.ActiveDay != dFirst) {
                        dFirst.Active = true;
                        this.ActiveDay = dFirst;
                        ConstructRectangleToDraw(this.ActiveDay.ClientRectangle);
                    }

                    InvalidateRectDraw();
                }
            } else { // Now mouse in moving
                DayObject dayStart = GetDayFromPoint(m_ptMouseDown);
                if (dayStart != null) {
                    ArrayList arDayEnds = new ArrayList();
                    foreach (MonthObject m in m_months) {
                        DayObject d = m.GetFirstEndDayFromPoint(new Point(pt.X, pt.Y));
                        if (d != null) {
                            //Console.WriteLine(d.Date.ToString());
                            arDayEnds.Add(d);
                        }
                    }
                    arDayEnds.Sort();
                    if (arDayEnds.Count > 0) {
                        DayObject dayEnd = (DayObject)arDayEnds[arDayEnds.Count - 1];
                        DayObjectCollections days = GetDaysBetweenDate(dayStart.Date, dayEnd.Date);

                        if (this.ActiveDay != null && this.ActiveDay != dayEnd) {
                            this.ActiveDay.Active = false;
                            ConstructRectangleToDraw(this.ActiveDay.ClientRectangle);
                            this.ActiveDay = null;
                        }

                        if (this.ActiveDay != dayEnd) {
                            dayEnd.Active = true;
                            this.ActiveDay = dayEnd;
                            ConstructRectangleToDraw(dayEnd.ClientRectangle);
                        }

                        // Remove Un-Selected day from old selection
                        ArrayList arTmp = new ArrayList();
                        foreach (DayObject d in m_selectedDays) {
                            if (days.Contains(d) == false) {
                                arTmp.Add(d);
                            }
                        }
                        foreach (DayObject d in arTmp) {
                            if (d.Selected == true) {
                                ConstructRectangleToDraw(SetSelectedDay(d, false));
                            }
                            m_selectedDays.Remove(d);
                        }
                        // Add new selected day to exist selected collection
                        foreach (DayObject d in days) {
                            if (m_selectedDays.Contains(d) == false) {
                                if (d.Selected == false) {
                                    ConstructRectangleToDraw(SetSelectedDay(d, true));
                                }
                                m_selectedDays.Add(d);
                            }
                        }
                        FireOnSelectedDayChanged();
                    }
                    InvalidateRectDraw();
                }
                //Rectangle rc = new Rectangle(m_ptMouseDown, new Size(pt.X - m_ptMouseDown.X, pt.Y - m_ptMouseDown.Y));
                ////Console.WriteLine(rc.Location.ToString() + " = " + GetDayFromPoint(rc.Location).Date.ToString());
                //DayObjectCollections days = GetDaysFromRect(rc);
            }
        }

        public void FireOnSelectedDayChanged() {
            if (OnSelectedDayChanged != null) {
                OnSelectedDayChanged(this, EventArgs.Empty);
            }
        }

        private Bitmap CaptureControl(Control window) {
            if (m_editView != EditorView.ForeControl)
                return null;
            if (window == null)
                return null;

            Bitmap memoryImage = null;
            Rectangle rc = window.RectangleToScreen(window.ClientRectangle);

            try {
                // Create new graphics object using handle to window.
                using (Graphics graphics = window.CreateGraphics()) {
                    memoryImage = new Bitmap(rc.Width, rc.Height, graphics);

                    using (Graphics memoryGrahics = Graphics.FromImage(memoryImage)) {
                        memoryGrahics.CopyFromScreen(rc.X, rc.Y, 0, 0, rc.Size, CopyPixelOperation.SourceCopy);
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString(), "Capture failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return memoryImage;
        }

        private void ShowEditorControl() {
            foreach (Control c in this.Controls) {
                if (c is NumericUpDown) {   // Year Up-Down
                } else {
                    c.Visible = false;
                }
            }

            if (m_editMode == EditorMode.Alway) {
                this.Controls.Clear();
                this.Controls.Add(m_yearUpDown);

                foreach (MonthObject m in m_months) {
                    foreach (DayObject d in m.DayObjects) {
                        if (d.EditorControl != null && d.Show) {
                            d.EditorControl.Visible = true;
                            d.EditorControl.Enabled = true;
                            this.Controls.Add(d.EditorControl);
                        }
                    }
                }
            }
        }

        private bool ShowEditorControlOnSelectedDay(DayObject dob) {
            if (dob == null)
                return false;
            if (dob.Show == false)
                return false;

            Control c = dob.EditorControl;
            if (c != null) {
                c.Location = dob.ClientRectangle.Location;
                c.Size = dob.ClientRectangle.Size;
                c.Location = new Point(c.Location.X + 1, c.Location.Y + 1);
                c.Size = new Size(c.Size.Width - 1, c.Size.Height - 1);
                c.Visible = true;
                c.Enabled = true;
                this.Controls.Add(c);

                if (m_currentEditorControl != null) {
                    ((DayEditor)m_currentEditorControl).Bitmap = CaptureControl(m_currentEditorControl);
                    //((IEditorControl)m_currentEditorControl).Bitmap = CaptureControl(m_currentEditorControl);
                }


                m_currentEditorControl = c;
                ((DayEditor)m_currentEditorControl).SetFocus();
                //((IEditorControl)m_currentEditorControl).SetFocus();
                return true;
            }
            return false;
        }

        protected override void OnDoubleClick(EventArgs e) {
            Point pt = this.PointToClient(MousePosition);
            DayObject dob = GetDayFromPoint(pt);
            if (dob != null) {
                if ((m_editWhen & EditorWhen.DoubleClick) == EditorWhen.DoubleClick) {
                    ShowEditorControlOnSelectedDay(dob);
                }
                if (OnDayDoubleClick != null) {
                    OnDayDoubleClick(dob);
                }
            }
            base.OnDoubleClick(e);
        }

        protected override void OnClick(EventArgs e) {
            Point pt = this.PointToClient(MousePosition);
            DayObject dob = GetDayFromPoint(pt);
            if (dob != null) {
                if (OnDayClick != null) {
                    OnDayClick(m_dayActive);
                }
            }
            base.OnClick(e);
        }

        protected override void OnMouseMove(MouseEventArgs e) {
            if (m_selection == SelectionPolicy.Continuous && m_ptMouseDown != Point.Empty) {
                DoSelectionContinuous(new Point(e.X, e.Y));
            } 
            //else {
            //    bool bBack = m_imgBack.ClientRectangle.Contains(e.X, e.Y);
            //    bool bNext = m_imgNext.ClientRectangle.Contains(e.X, e.Y);

            //    if (bBack) {
            //        if (m_imgBack.State != ImageObject.ImageState.Over) {
            //            m_imgBack.State = ImageObject.ImageState.Over;
            //            this.Invalidate(m_imgBack.ClientRectangle);
            //        }
            //    } else {
            //        if (m_imgBack.State != ImageObject.ImageState.Normal) {
            //            m_imgBack.State = ImageObject.ImageState.Normal;
            //            this.Invalidate(m_imgBack.ClientRectangle);
            //        }
            //    }

            //    if (bNext) {
            //        if (m_imgNext.State != ImageObject.ImageState.Over) {
            //            m_imgNext.State = ImageObject.ImageState.Over;
            //            this.Invalidate(m_imgNext.ClientRectangle);
            //        }
            //    } else {
            //        if (m_imgNext.State != ImageObject.ImageState.Normal) {
            //            m_imgNext.State = ImageObject.ImageState.Normal;
            //            this.Invalidate(m_imgNext.ClientRectangle);
            //        }
            //    }
                
            //}
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e) {
            m_ptMouseDown = Point.Empty;
            base.OnMouseUp(e);
        }

        private void MoveActiveCell(int xDif, int yDif) {
            if (m_dayActive == null)
                return;

            // Under Construction....


        }



        protected override void OnKeyDown(KeyEventArgs e) {
            //kim add 20070518------------------------------------------
            base.OnKeyDown(e);
            //end ------------------------------------------------------
            //Point pt = this.PointToClient(MousePosition);
            //DayObject dob = GetDayFromPoint(pt);
            //int xDiff = 0;
            //int yDiff = 0;
            //switch (e.KeyCode) {
            //    case Keys.F2:
            //        if ((m_editWhen & EditorWhen.F2) == EditorWhen.F2) {
            //            ShowEditorControlOnSelectedDay(dob);
            //        }
            //        break;
            //    case Keys.Enter:
            //        if ((m_editWhen & EditorWhen.Enter) == EditorWhen.Enter) {
            //            ShowEditorControlOnSelectedDay(dob);
            //        }
            //        break;
            //    case Keys.Left:
            //        xDiff = -1;
            //        break;
            //    case Keys.Right:
            //        xDiff = 1;
            //        break;
            //    case Keys.Up:
            //        yDiff = -1;
            //        break;
            //    case Keys.Down:
            //        yDiff = 1;
            //        break;
            //}
            //MoveActiveCell(xDiff, yDiff);
            //base.OnKeyDown(e);
        }

        private TextObject GetHitTestObject(int x, int y) {
            foreach (MonthObject m in m_months) {
                TextObject txtObj = m.HitTestTextObject(x, y);
                if (txtObj != null) {
                    return txtObj;
                }
            }
            return null;
        }

        protected override void OnMouseDown(MouseEventArgs e) {
            // Get HitTestObject (Month and Year object)
            TextObject txtObj = GetHitTestObject(e.X, e.Y);
            if (txtObj != null) {    // Mouse down on Month or Year object.
                if (m_yearUpDown.Visible) {
                    m_yearUpDown.Visible = false;
                }
                HideEditorControl();
                if (e.Button == MouseButtons.Left) {
                    if (txtObj.HitTestType == HitTestCalendarObject.YearText) {
                        ShowYearNumericUpDown(txtObj);
                    } else if (txtObj.HitTestType == HitTestCalendarObject.MonthText) {
                        ShowMonthContextMenu(txtObj);
                    }
                }
            } else {
                if (m_yearUpDown.Visible) {
                    m_yearUpDown.Visible = false;
                }
                HideEditorControl();
                if (e.Button == MouseButtons.Left) {
                    SetDayChecked(GetDayFromPoint(new Point(e.X, e.Y)), new Point(e.X, e.Y));

                    switch (m_selection) {
                        case SelectionPolicy.Single:
                            DoSelectionSingle(new Point(e.X, e.Y));
                            break;
                        case SelectionPolicy.Merge:
                            DoSelectionMerge(new Point(e.X, e.Y));
                            break;
                        case SelectionPolicy.Continuous:
                            DoSelectionContinuous(new Point(e.X, e.Y));
                            break;
                    }

                    if (m_months.Length > 0) {
                        Point pt = new Point(e.X, e.Y);
                        DateTime dtFirstMonth = m_months[0].FirstDay;
                        if (m_imgNext.ClientRectangle.Contains(pt)) {
                            dtFirstMonth = dtFirstMonth.AddMonths(1);
                            DisplayMonth(dtFirstMonth.Year, dtFirstMonth.Month);
                        } else if (m_imgBack.ClientRectangle.Contains(pt)) {
                            dtFirstMonth = dtFirstMonth.AddMonths(-1);
                            DisplayMonth(dtFirstMonth.Year, dtFirstMonth.Month);
                        }
                    }
                }
            }
            base.OnMouseDown(e);
        }


        protected override void OnLoad(EventArgs e) {
            ReCreateOffScreenObject();
            Point locate = new Point(this.ClientRectangle.Width - m_iArrowImageOffset - ArrowImageObject.SIZE, m_imgNext.ClientRectangle.Top);
            Size sz = m_imgNext.ClientRectangle.Size;
            m_imgNext.ClientRectangle = new Rectangle(locate, sz);

            ReCreateMonthObject(false);

            base.OnLoad(e);
        }

        private void ReCreateMonthObject(bool bSizeChanged) {
            if (bSizeChanged == false) {
                foreach (MonthObject m in m_months) {
                    m.OnCalendarObjectInvalidate -= new CalendarObject.CalendarObjectInvalidateHandler(CalendarObject_OnCalendarObjectInvalidate);
                }

                m_months = m_layout.GetMonthObject(this, this.ClientRectangle, 0, DateTime.Today.Year, DateTime.Today.Month, m_arDisplayedMonths, MonthObject_OnPaintDay);
                foreach (MonthObject m in m_months) {
                    //m.HeaderSize = m_iHeaderHeight;
                    m.ShowCheckBox = this.ShowCheckBox;
                    if (m.EditorControl == null) {
                        m.EditorControl = m_editorControl;
                    }
                    if (m.DayObjects.Count <= 0) {
                        m.CreateDayObject(m_selectedDays, m_checkedDays);
                    } else {
                        m.ResizeDayObject(m_selectedDays, m_checkedDays);
                    }
                    m.OnCalendarObjectInvalidate += new CalendarObject.CalendarObjectInvalidateHandler(CalendarObject_OnCalendarObjectInvalidate);
                }
                ShowEditorControl();
            } else {
                m_layout.ResizeMonthObject(this.ClientRectangle, 0, m_months);
                foreach (MonthObject m in m_months) {
                    m.ResizeDayObject(m_selectedDays, m_checkedDays);
                }
                
            }
        }


        private void AttachEvent() {
            m_imgBack.OnCalendarObjectInvalidate += new CalendarObject.CalendarObjectInvalidateHandler(CalendarObject_OnCalendarObjectInvalidate);
            m_imgNext.OnCalendarObjectInvalidate += new CalendarObject.CalendarObjectInvalidateHandler(CalendarObject_OnCalendarObjectInvalidate);
            
        }

        void CalendarObject_OnCalendarObjectInvalidate(CalendarObject obj) {
            this.Invalidate(obj.ClientRectangle);
        }

        private void CreateObject() {
            int x1 = 0, y1 = 0;


            x1 = m_iArrowImageOffset;
            y1 = (m_iHeaderHeight - ArrowImageObject.SIZE) / 2;

            m_imgBack = new ArrowImageObject(this, new Point(x1, y1), ArrowImageObject.ArrowType.Back);


            x1 = this.ClientRectangle.Width - m_iArrowImageOffset - ArrowImageObject.SIZE;
            m_imgNext = new ArrowImageObject(this, new Point(x1, y1), ArrowImageObject.ArrowType.Next);

            //MessageBox.Show("Width = " + this.ClientRectangle.ToString());


        }



        private void RefreshMonthRectangle() {

        }

        //[Description("Specify calendar layout"),
        //Editor(typeof(CalendarLayoutEditor), typeof(UITypeEditor)),
        //DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor(typeof(CalendarLayoutEditor), typeof(UITypeEditor))]
        public CalendarLayout.LayoutType CalendarView{
            get {
                return m_layoutType;
            }
            set {
                if (m_layoutType != value) {
                    m_layoutType = value;
                    m_layout = new CalendarLayout(m_layoutType);
                    ReCreateMonthObject(false);
                    OnSizeChanged(EventArgs.Empty);
                }
            }
        }

        //[Description("Specify calendar layout"),
        //Editor(typeof(CalendarLayoutEditor), typeof(UITypeEditor)),
        //DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        //[Editor(typeof(CalendarLayoutEditor), typeof(UITypeEditor))]
        //public CalendarLayout CalendarLayout {
        //    get {
        //        return m_layout;
        //    }
        //    set {
        //        if (m_layout != value) {
        //            m_layout = value;
        //            ReCreateMonthObject(false);
        //            OnSizeChanged(EventArgs.Empty); // Fire event on size change to re-draw all content of calendar
        //            //this.Invalidate();
        //        }
        //    }
        //}

        //[Description("Number of month for display"), Editor(typeof(MonthDimensionEditor), typeof(UITypeEditor))]
        //public CalendarLayout CalendarLayout{
        //    get {
        //        return m_layout;
        //    }
        //    set {
        //        if (m_layout != value) {
        //            m_layout = value;
        //            RefreshMonthCount();
        //            this.Invalidate();
        //        }
        //    }
        //}

        [Browsable(false)]
        public DayObjectCollections SelectedDays {
            get {
                return m_selectedDays;
            }
        }

        public SelectionPolicy SelectionPolicy {
            get {
                return m_selection;
            }
            set {
                if (m_selection != value) {
                    m_selection = value;
                    foreach (DayObject d in m_selectedDays) {
                        this.Invalidate(d.ClientRectangle);
                    }
                    m_selectedDays.Clear();
                }
            }
        }

        public bool ShowCheckBox {
            get {
                return m_bShowCheckBox;
            }
            set {
                if (m_bShowCheckBox != value) {
                    m_bShowCheckBox = value;
                    foreach (MonthObject m in m_months) {
                        m.ShowCheckBox = m_bShowCheckBox;
                    }
                    this.Invalidate();
                }
            }
        }        

        public void InvalidateAll() {
            OnSizeChanged(EventArgs.Empty);
        }

        protected override void OnSizeChanged(EventArgs e) {
            if (this.Created) {
                ReCreateOffScreenObject();
                Point locate = new Point(this.ClientRectangle.Width - m_iArrowImageOffset - ArrowImageObject.SIZE, m_imgNext.ClientRectangle.Top);
                Size sz = m_imgNext.ClientRectangle.Size;
                m_imgNext.ClientRectangle = new Rectangle(locate, sz);

                ReCreateMonthObject(true);

                // Resize Editor Control
                if (m_currentEditorControl != null) {
                    if (m_currentEditorControl.Visible) {
                        DayEditor editor = (DayEditor)m_currentEditorControl;
                        if (editor != null) {
                            DayObject dob = editor.DayObject;
                            m_currentEditorControl.Location = dob.ClientRectangle.Location;
                            m_currentEditorControl.Size = dob.ClientRectangle.Size;
                        }


                        //IEditorControl iec = (IEditorControl)m_currentEditorControl;
                        //if (iec != null) {
                        //    DayObject dob = iec.DayObject;
                        //    m_currentEditorControl.Location = dob.ClientRectangle.Location;
                        //    m_currentEditorControl.Size = dob.ClientRectangle.Size;
                        //}
                    }
                }
                // Resize Year Up-Down
                if (m_yearUpDown.Visible == true) {
                    if (m_yearUpDown.Tag != null) {
                        TextObject txtObj = (TextObject)m_yearUpDown.Tag;
                        m_yearUpDown.Location = txtObj.ClientRectangle.Location;
                        m_yearUpDown.Size = txtObj.ClientRectangle.Size;
                        m_yearUpDown.Width += SystemInformation.SmallIconSize.Width+5;
                    }
                }
            }
            base.OnSizeChanged(e);
        }

        private void ReCreateOffScreenObject() {
            if (m_gOff != null) {
                m_gOff.Dispose();
                m_gOff = null;
                GC.Collect();
            }
            if (m_bmpOff != null) {
                m_bmpOff.Dispose();
                m_bmpOff = null;
                GC.Collect();
            }

            if (this.ClientRectangle.Width > 0 && this.ClientRectangle.Height > 0) {
                m_bmpOff = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
                m_gOff = Graphics.FromImage(m_bmpOff);
                m_gOff.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
            }
        }

        private void DrawHeader() {
            if (m_gOff == null)
                return;

            //Rectangle rc = new Rectangle(0, 0, this.ClientSize.Width, m_iHeaderHeight);

            
            // Draw Back Image
            if (m_imgBack != null){
                //m_gOff.FillRectangle(new SolidBrush(Color.Red), m_imgBack.ClientRectangle);
                m_gOff.DrawImage(m_imgBack.Bitmap, m_imgBack.ClientRectangle);
            }
            // Draw Next Image
            if (m_imgNext != null) {
                //m_gOff.FillRectangle(new SolidBrush(Color.Green), m_imgNext.ClientRectangle);
                m_gOff.DrawImage(m_imgNext.Bitmap, m_imgNext.ClientRectangle);
            }

        }

        private void DrawMonth(Rectangle rcClip) {
            if (m_gOff == null)
                return;

            DateTime dtToday = DateTime.Today;
            foreach (MonthObject m in m_months){
                m.DrawMonth(m_gOff, rcClip);
                dtToday = dtToday.AddMonths(1);
            }
            
        }

        private void DrawBackground() {
            if (m_gOff == null)
                return;

            //m_gOff.FillRectangle(new SolidBrush(Color.White), this.ClientRectangle);
        }

        protected override void OnPaint(PaintEventArgs e) {
            DrawMonth(e.ClipRectangle);
            DrawHeader();
            //DrawBackground();

            if (m_bmpOff != null) {
                e.Graphics.DrawImage(m_bmpOff, new Point(0, 0));
            }
            //e.Graphics.DrawImage(m_bmpOff, e.ClipRectangle, e.ClipRectangle, GraphicsUnit.Pixel);
            // Display Check Box
            //base.OnPaint(e);
            m_arRectDraw.Clear();
        }


        [Category("Appearance"), Description("...")]
        public ImageList IconImageList {
            get {
                return m_imglIcon;
            }
            set {
                if (m_imglIcon != value)
                    m_imglIcon = value;
            }
        }

        public ImageList DayBackgroundImageList {
            get { return this.m_imglDayBackground; }
            set {
                if (m_imglDayBackground != value) {
                    m_imglDayBackground = value;
                }
            }
        }

        [Browsable(false)]
        public ImageList ImageList {
            get { return m_imglDayBackground; }
        }

        [DefaultValue(-1)]
        [Localizable(true)]
        [TypeConverter(typeof(System.Windows.Forms.ImageIndexConverter))]
        [Editor("System.Windows.Forms.Design.ImageIndexEditor", typeof(System.Drawing.Design.UITypeEditor))]
        public int TemplateBackgroundImageIndex{
            get { return this.m_iBackImgIdxTemplate; }
            set {
                this.m_iBackImgIdxTemplate = value;
            }
        }

        private void Calendar_Load(object sender, EventArgs e) {
            Assembly asm = Assembly.GetExecutingAssembly();
            Type[] types = asm.GetTypes();
            foreach (Type t in types) {
                Console.Write(t.FullName);
                if (t.FullName.IndexOf("DayEditor") >= 0) {
                    Console.WriteLine("break;");
                }
                if (t.IsSubclassOf(typeof(DayEditor))) {
                    Console.WriteLine(" is DayEditor");
                } else {
                    Console.WriteLine(" is not DayEditor");
                }
            }
            //    //Type tIn = t.GetInterface("IEditorControl");
            //    //if (tIn != null) {
            //    //    Console.WriteLine(tIn.ToString());
            //    //} 
            //}
            //Console.WriteLine(asm.ToString());
        }

    }


    //public class MonthForDisplayEditor : UITypeEditor {
    //    public MonthForDisplayEditor() {
    //    }
    //    public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) {
    //        return UITypeEditorEditStyle.Modal;
    //    }
    //    public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) {
    //        IWindowsFormsEditorService frmsvr = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
    //        if (frmsvr == null)
    //            return null;

    //        Form1 f = new Form1();
    //        frmsvr.ShowDialog(f);


    //        return base.EditValue(context, provider, value);
    //    }
    //}
}

