using System;
using System.Reflection;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Collections;
using System.Drawing;   
using System.Collections.Generic;
using System.Text;

namespace Cube.AFD.Windows.Controls.CalendarControls {

    [TypeConverter(typeof(DayCellStyle.DayCellStyleConverter))]
    public class DayCellStyle {

        private Color m_backColor = Color.Empty;
        private Brush m_backBrush = new SolidBrush(Color.Empty);
        private Color m_foreColor = Color.Empty;
        private Brush m_foreBrush = new SolidBrush(Color.Black);
        private Color m_lineColor = Color.Empty;
        private Pen m_linePen = new Pen(Color.Empty);

        public DayCellStyle() {
        }
        public DayCellStyle(Color foreColor, Color backColor) {
            m_backColor = backColor;
            m_foreColor = foreColor;
            m_foreBrush = new SolidBrush(m_foreColor);
            m_backBrush = new SolidBrush(m_backColor);
        }
        public DayCellStyle(Color foreColor, Color backColor, Color lineColor) : this(foreColor, backColor) {
            m_lineColor = lineColor;
            m_linePen = new Pen(m_lineColor);
        }

        internal class DayCellStyleConverter : TypeConverter {
            public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) {
                if (destinationType == typeof(InstanceDescriptor)) {
                    return true;
                }
                return base.CanConvertTo(context, destinationType);
            }
            public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType) {
                if (destinationType == typeof(InstanceDescriptor)) {
                    if (value != null) {
                        DayCellStyle d = (DayCellStyle)value;
                        ConstructorInfo cInfo = typeof(DayCellStyle).GetConstructor(new Type[] { typeof(Color), typeof(Color), typeof(Color) });
                        return new InstanceDescriptor(cInfo, new object[] { d.ForeColor, d.BackColor, d.LineColor }, true);
                    }
                }
                return base.ConvertTo(context, culture, value, destinationType);
            }
        }

        [Description("Specify background color for day cell")]
        public Color BackColor {
            get { return m_backColor; }
            set {
                if (m_backColor != value) {
                    m_backColor = value;
                    m_backBrush = new SolidBrush(value);
                }
            }
        }
        [Browsable(false)]
        public Brush BackBrush { get { return m_backBrush; } }
        [Description("Specify text color for day cell")]
        public Color ForeColor {
            get { return m_foreColor; }
            set {
                if (m_foreColor != value) {
                    m_foreColor = value;
                    m_foreBrush = new SolidBrush(value);
                }
            }
        }
        [Browsable(false)]
        public Brush ForeBrush { get { return m_foreBrush; } }
        [Description("Specify inner line color for day cell")]
        public Color LineColor {
            get { return m_lineColor; }
            set {
                if (m_lineColor != value) {
                    m_lineColor = value;
                    m_linePen = new Pen(value);
                }
            }
        }
        [Browsable(false)]
        public Pen LinePen { get { return m_linePen; } }
    }

    [TypeConverter(typeof(DayStyle.DayStyleConverter))]
    public class DayStyle {
        private const float FONT_SMALL_RATIO = 1.2F;
        private DayCellStyle m_dayInactiveCell = new DayCellStyle();
        private DayCellStyle m_dayNormalCell = new DayCellStyle();
        private DayCellStyle m_daySelectionCell = new DayCellStyle();
        private DayCellStyle m_dayActiveCell = new DayCellStyle();
        private DayCellStyle m_dayTodayCell = new DayCellStyle();
        private Font m_dayFont = null; // Use for display day number
        private Font m_dayFontSmall = null;

        public DayStyle() {
        }
        public DayStyle(Font font, DayCellStyle inactiveCell, DayCellStyle normalCell, DayCellStyle selectionCell, DayCellStyle activeCell, DayCellStyle todayCell) {
            m_dayFont = font;
            m_dayFontSmall = new Font(font.FontFamily, font.Size / FONT_SMALL_RATIO);
            m_dayInactiveCell = inactiveCell;
            m_dayNormalCell = normalCell;
            m_daySelectionCell = selectionCell;
            m_dayActiveCell = activeCell;
            m_dayTodayCell = todayCell;
        }

        internal class DayStyleConverter : TypeConverter {
            public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) {
                if (destinationType == typeof(InstanceDescriptor)) {
                    return true;
                }
                return base.CanConvertTo(context, destinationType);
            }
            public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType) {
                if (destinationType == typeof(InstanceDescriptor)) {
                    if (value != null) {
                        DayStyle d = (DayStyle)value;
                        ConstructorInfo cInfo = typeof(DayStyle).GetConstructor(new Type[] { 
                        typeof(Font), typeof(DayCellStyle),typeof(DayCellStyle),typeof(DayCellStyle),typeof(DayCellStyle),typeof(DayCellStyle)});
                        return new InstanceDescriptor(cInfo, new object[] { d.Font, d.InactiveDay, d.NormalDay, d.SelectionDay, d.ActiveDay, d.TodayDay }, true);
                    }
                }
                return base.ConvertTo(context, culture, value, destinationType);
            }
        }

        [Browsable(false)]
        public DayCellStyle InactiveDay {
            get { return m_dayInactiveCell; }
            set { m_dayInactiveCell = value; }
        }
        [Browsable(false)]
        public DayCellStyle NormalDay {
            get { return m_dayNormalCell; }
            set { m_dayNormalCell = value; }
        }
        [Browsable(false)]
        public DayCellStyle SelectionDay {
            get { return m_daySelectionCell; }
            set { m_daySelectionCell = value; }
        }
        [Browsable(false)]
        public DayCellStyle ActiveDay {
            get { return m_dayActiveCell; }
            set { m_dayActiveCell = value; }
        }
        [Browsable(false)]
        public DayCellStyle TodayDay {
            get { return m_dayTodayCell; }
            set { m_dayTodayCell = value; }
        }
        [Description("Specify font for display day text in all day cell")]
        public Font Font {
            get { return m_dayFont; }
            set {
                m_dayFont = value;
                m_dayFontSmall = new Font(value.FontFamily, value.Size / FONT_SMALL_RATIO);
            }
        }
        [Browsable(false)]
        public Font FontSmall { get { return m_dayFontSmall; } }

    }

    [TypeConverter(typeof(HeaderStyle.HeaderStyleConverter))]
    public class HeaderStyle {
        private Color m_backColor = Color.Empty;
        private Color m_foreColor = Color.Empty;
        private Brush m_foreBrush = new SolidBrush(Color.Empty);
        private Pen m_forePen = new Pen(Color.Empty);
        private Font m_font;
        private int m_iHeight;

        private Brush m_backBrush = new SolidBrush(Color.Empty);


        public HeaderStyle() {
        }
        public HeaderStyle(Font font, Color foreColor, Color backColor, int height) {
            m_font = font;
            m_foreColor = foreColor;
            m_backColor = backColor;
            m_iHeight = height;

            m_foreBrush = new SolidBrush(m_foreColor);
            m_forePen = new Pen(m_foreColor);
            m_backBrush = new SolidBrush(m_backColor);
        }

        internal class HeaderStyleConverter : TypeConverter {
            public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) {
                if (destinationType == typeof(InstanceDescriptor)) {
                    return true;
                }
                return base.CanConvertTo(context, destinationType);
            }
            public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType) {
                if (destinationType == typeof(InstanceDescriptor)) {
                    if (value != null) {
                        HeaderStyle h = (HeaderStyle)value;
                        ConstructorInfo cInfo = typeof(HeaderStyle).GetConstructor(new Type[] { typeof(Font), typeof(Color), typeof(Color), typeof(int) });
                        return new InstanceDescriptor(cInfo, new object[] { h.Font, h.ForeColor, h.BackColor, h.Height }, true);
                    }
                }
                return base.ConvertTo(context, culture, value, destinationType);
            }
        }

        [Description("Specify background color for header")]
        public Color BackColor {
            get { return m_backColor; }
            set {
                if (m_backColor != value) {
                    m_backColor = value;
                    m_backBrush = new SolidBrush(m_backColor);
                }
            }
        }
        [Description("Specify fore color for header")]
        public Color ForeColor {
            get { return m_foreColor; }
            set {
                if (m_foreColor != value) {
                    m_foreColor = value;
                    m_foreBrush = new SolidBrush(m_foreColor);
                    m_forePen = new Pen(m_foreColor);
                }
            }
        }
        [Browsable(false)]
        public Brush ForeBrush { get { return m_foreBrush; } }
        [Browsable(false)]
        public Pen ForePen { get { return m_forePen; } }
        [Description("Specify font of header")]
        public Font Font {
            get { return m_font; }
            set {
                if (m_font != value) {
                    m_font = value;
                }
            }
        }
        [Description("Specify height of header")]
        public int Height {
            get { return m_iHeight; }
            set {
                if (m_iHeight != value) {
                    m_iHeight = value;
                }
            }
        }
        [Browsable(false)]
        public Brush BackBrush { get { return m_backBrush; } }
    }
    
    [TypeConverter(typeof(CalendarStyle.CalendarStyleConvert))]
    public class CalendarStyle {
        private const int NUMBER_OF_MONTH = 12;
        private const int NUMBER_OF_DAY_PER_WEEK = 7;
        private HeaderStyle m_calendarHeader = new HeaderStyle();
        private HeaderStyle m_weekHeader = new HeaderStyle();
        private DayStyle m_dayStyle = new DayStyle();
        private Color m_gridColor = Color.Empty;    // Grid color of calendar
        //private Hashtable m_htdayOfWeekBackColor = new Hashtable();
        //private Hashtable m_htdayOfWeekBackBrush = new Hashtable();
        private MonthTextCollection m_monthText = new MonthTextCollection();
        private WeekTextCollection m_weekText = new WeekTextCollection();
        //private string[] m_strMonthText = null;
        //private string[] m_strWeekText = null;

        private Pen m_gridPen = new Pen(Color.Empty);

        public CalendarStyle() {
            //m_htdayOfWeekBackBrush = new Hashtable();
            //m_htdayOfWeekBackColor = new Hashtable();
            //string []s = Enum.GetNames(typeof(DayOfWeek));
            //foreach(string dayName in s){
            //    m_htdayOfWeekBackColor[dayName] = Color.Empty;
            //    m_htdayOfWeekBackBrush[dayName] = new SolidBrush(Color.Empty);
            //}
            m_calendarHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            m_weekHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            m_dayStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));

        }

        public CalendarStyle(Color gridColor, HeaderStyle calendarHeader,  HeaderStyle weekHeader, DayStyle dayStyle, MonthText []monthText, WeekText []weekText) : this(){
            this.GridColor = gridColor;
            this.CalendarHeader = calendarHeader;
            this.WeekHeader = weekHeader;
            this.DayStyle = dayStyle;
            m_monthText = new MonthTextCollection();
            m_monthText.AddRange(monthText);
            m_weekText = new WeekTextCollection();
            m_weekText.AddRange(weekText);
        }

        internal class CalendarStyleConvert : TypeConverter {
            public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) {
                if (destinationType == typeof(InstanceDescriptor)) {
                    return true;
                }
                return base.CanConvertTo(context, destinationType);
            }
            public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType) {
                if (destinationType == typeof(InstanceDescriptor)) {
                    if (value != null) {
                        CalendarStyle c = (CalendarStyle)value;
                        ConstructorInfo cInfo = typeof(CalendarStyle).GetConstructor(new Type[] { typeof(Color), typeof(HeaderStyle), typeof(HeaderStyle), typeof(DayStyle), typeof(MonthText[]), typeof(WeekText[])});
                        return new InstanceDescriptor(cInfo, new object[] { c.GridColor, c.CalendarHeader, c.WeekHeader, c.DayStyle, c.MonthText.ToMonthTextArray(), c.WeekText.ToMonthTextArray()}, true);
                    }
                }
                return base.ConvertTo(context, culture, value, destinationType);
            }
        }

        [Browsable(false)]
        public HeaderStyle CalendarHeader {
            get { return m_calendarHeader; }
            set {
                m_calendarHeader = value;
            }
        }
        [Browsable(false)]
        public HeaderStyle WeekHeader {
            get { return m_weekHeader; }
            set {
                m_weekHeader = value;
            }
        }
        [Browsable(false)]
        public DayStyle DayStyle {
            get {
                return m_dayStyle;
            }
            set {
                m_dayStyle = value;
            }
        }
        [Description("Specify grid color(line color) for display in month")]
        public Color GridColor {
            get { return m_gridColor; }
            set {
                if (m_gridColor != value) {
                    m_gridColor = value;
                    m_gridPen = new Pen(m_gridColor);
                }
            }
        }
        [Browsable(false)]
        public Pen GridPen { get { return m_gridPen; } }

        //public void SetDayOfWeekBackColor(DayOfWeek day, Color color) {
        //    m_htdayOfWeekBackColor[day.ToString()] = color;
        //    m_htdayOfWeekBackBrush[day.ToString()] = new SolidBrush(color);
        //}
        //public Brush GetDayOfWeekBackBrush(DayOfWeek day) {
        //    return (SolidBrush)m_htdayOfWeekBackBrush[day.ToString()];
        //}
        //public Brush GetDayOfWeekBackBrush(DayOfWeek day, Brush brDefault) {
        //    Color c = (Color)m_htdayOfWeekBackColor[day.ToString()];
        //    if (c == Color.Empty)
        //        return brDefault;
        //    else
        //        return (SolidBrush)m_htdayOfWeekBackBrush[day.ToString()];
        //}

        [Description("Specify custom month text")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content),Editor(typeof(System.ComponentModel.Design.CollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public MonthTextCollection MonthText {
            get {
                return m_monthText;
            }
            set {
                m_monthText = value;
            }
        }
        [Description("Specify custom week text")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Editor(typeof(System.ComponentModel.Design.CollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public WeekTextCollection WeekText {
            get {
                return m_weekText;
            }
            set {
                m_weekText = value;
            }
        }


        #region Static Member
        public static CalendarStyle CoolEye {
            get {
                return new CalendarStyle(System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(127)))), ((int)(((byte)(137))))), new HeaderStyle(new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177))), System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(128)))), ((int)(((byte)(151))))), System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(251))))), 23), new HeaderStyle(new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177))), System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(128)))), ((int)(((byte)(151))))), System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(251))))), 18), new DayStyle(new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177))), new DayCellStyle(System.Drawing.Color.Silver, System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(238)))), ((int)(((byte)(236))))), System.Drawing.Color.Empty), new DayCellStyle(System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(101)))), ((int)(((byte)(156))))), System.Drawing.Color.White, System.Drawing.Color.Empty), new DayCellStyle(System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(101)))), ((int)(((byte)(156))))), System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(227)))), ((int)(((byte)(243))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))))), new DayCellStyle(System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(101)))), ((int)(((byte)(156))))), System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))))), new DayCellStyle(System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(101)))), ((int)(((byte)(156))))), System.Drawing.Color.Orange, System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255))))))), new MonthText[0], new WeekText[] {
                new WeekText(System.DayOfWeek.Sunday, "", System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(231)))))),
                new WeekText(System.DayOfWeek.Saturday, "", System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(231))))))});
            }
        }
        public static CalendarStyle BlueWhite {
            get {
                return new CalendarStyle(System.Drawing.Color.Silver, new HeaderStyle(new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178))), System.Drawing.Color.Black, System.Drawing.Color.White, 30), new HeaderStyle(new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))), System.Drawing.Color.Black, System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(255))))), 18), new DayStyle(new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))), new DayCellStyle(System.Drawing.Color.DimGray, System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221))))), System.Drawing.Color.Empty), new DayCellStyle(System.Drawing.Color.Black, System.Drawing.Color.White, System.Drawing.Color.Empty), new DayCellStyle(System.Drawing.Color.Black, System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255))))), System.Drawing.Color.Empty), new DayCellStyle(System.Drawing.Color.Black, System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))))), new DayCellStyle(System.Drawing.Color.Black, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))))), new MonthText[0], new WeekText[] {
            new WeekText(System.DayOfWeek.Sunday, "Sunday", System.Drawing.Color.Empty),
            new WeekText(System.DayOfWeek.Monday, "Monday", System.Drawing.Color.Empty),
            new WeekText(System.DayOfWeek.Tuesday, "Tuesday", System.Drawing.Color.Empty),
            new WeekText(System.DayOfWeek.Wednesday, "Wednesday", System.Drawing.Color.Empty),
            new WeekText(System.DayOfWeek.Thursday, "Thursday", System.Drawing.Color.Empty),
            new WeekText(System.DayOfWeek.Friday, "Friday", System.Drawing.Color.Empty),
            new WeekText(System.DayOfWeek.Saturday, "Saturday", System.Drawing.Color.Empty)});
            }
        }
        public static CalendarStyle PigBlood {
            get {
                return new Cube.AFD.Windows.Controls.CalendarControls.CalendarStyle(System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(123)))), ((int)(((byte)(123))))), new Cube.AFD.Windows.Controls.CalendarControls.HeaderStyle(new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(0))))), System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))), 25), new Cube.AFD.Windows.Controls.CalendarControls.HeaderStyle(new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177))), System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(0))))), 18), new Cube.AFD.Windows.Controls.CalendarControls.DayStyle(new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177))), new Cube.AFD.Windows.Controls.CalendarControls.DayCellStyle(System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177))))), System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107))))), System.Drawing.Color.Empty), new Cube.AFD.Windows.Controls.CalendarControls.DayCellStyle(System.Drawing.Color.Gray, System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206))))), System.Drawing.Color.Empty), new Cube.AFD.Windows.Controls.CalendarControls.DayCellStyle(System.Drawing.Color.Black, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(189)))), ((int)(((byte)(189))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))))), new Cube.AFD.Windows.Controls.CalendarControls.DayCellStyle(System.Drawing.Color.Gray, System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))))), new Cube.AFD.Windows.Controls.CalendarControls.DayCellStyle(System.Drawing.Color.Black, System.Drawing.Color.Lime, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))))), new Cube.AFD.Windows.Controls.CalendarControls.MonthText[0], new Cube.AFD.Windows.Controls.CalendarControls.WeekText[] {
            new Cube.AFD.Windows.Controls.CalendarControls.WeekText(System.DayOfWeek.Sunday, "Sunday", System.Drawing.Color.Empty),
            new Cube.AFD.Windows.Controls.CalendarControls.WeekText(System.DayOfWeek.Monday, "Monday", System.Drawing.Color.Empty),
            new Cube.AFD.Windows.Controls.CalendarControls.WeekText(System.DayOfWeek.Tuesday, "Tuesday", System.Drawing.Color.Empty),
            new Cube.AFD.Windows.Controls.CalendarControls.WeekText(System.DayOfWeek.Wednesday, "Wednesday", System.Drawing.Color.Empty),
            new Cube.AFD.Windows.Controls.CalendarControls.WeekText(System.DayOfWeek.Thursday, "Thursday", System.Drawing.Color.Empty),
            new Cube.AFD.Windows.Controls.CalendarControls.WeekText(System.DayOfWeek.Friday, "Friday", System.Drawing.Color.Empty),
            new Cube.AFD.Windows.Controls.CalendarControls.WeekText(System.DayOfWeek.Saturday, "Saturday", System.Drawing.Color.Empty)});
            }
        }
        public static CalendarStyle PigBlood2 {
            get {
                return new Cube.AFD.Windows.Controls.CalendarControls.CalendarStyle(System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(25)))), ((int)(((byte)(0))))), new Cube.AFD.Windows.Controls.CalendarControls.HeaderStyle(new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))), System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))), System.Drawing.Color.White, 35), new Cube.AFD.Windows.Controls.CalendarControls.HeaderStyle(new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177))), System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(1)))), ((int)(((byte)(0))))), 18), new Cube.AFD.Windows.Controls.CalendarControls.DayStyle(new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0))), new Cube.AFD.Windows.Controls.CalendarControls.DayCellStyle(System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177))))), System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(165))))), System.Drawing.Color.Empty), new Cube.AFD.Windows.Controls.CalendarControls.DayCellStyle(System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(118)))), ((int)(((byte)(115))))), System.Drawing.Color.White, System.Drawing.Color.Empty), new Cube.AFD.Windows.Controls.CalendarControls.DayCellStyle(System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(118)))), ((int)(((byte)(115))))), System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(255)))), ((int)(((byte)(250))))), System.Drawing.Color.Empty), new Cube.AFD.Windows.Controls.CalendarControls.DayCellStyle(System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(118)))), ((int)(((byte)(115))))), System.Drawing.Color.White, System.Drawing.Color.Red), new Cube.AFD.Windows.Controls.CalendarControls.DayCellStyle(System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(118)))), ((int)(((byte)(115))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(239))))), System.Drawing.Color.Maroon)), new Cube.AFD.Windows.Controls.CalendarControls.MonthText[0], new Cube.AFD.Windows.Controls.CalendarControls.WeekText[] {
            new Cube.AFD.Windows.Controls.CalendarControls.WeekText(System.DayOfWeek.Sunday, "Sunday", System.Drawing.Color.Empty),
            new Cube.AFD.Windows.Controls.CalendarControls.WeekText(System.DayOfWeek.Monday, "Monday", System.Drawing.Color.Empty),
            new Cube.AFD.Windows.Controls.CalendarControls.WeekText(System.DayOfWeek.Tuesday, "Tuesday", System.Drawing.Color.Empty),
            new Cube.AFD.Windows.Controls.CalendarControls.WeekText(System.DayOfWeek.Wednesday, "Wednesday", System.Drawing.Color.Empty),
            new Cube.AFD.Windows.Controls.CalendarControls.WeekText(System.DayOfWeek.Thursday, "Thursday", System.Drawing.Color.Empty),
            new Cube.AFD.Windows.Controls.CalendarControls.WeekText(System.DayOfWeek.Friday, "Friday", System.Drawing.Color.Empty),
            new Cube.AFD.Windows.Controls.CalendarControls.WeekText(System.DayOfWeek.Saturday, "Saturday", System.Drawing.Color.Empty)});
            }
        }
        public static CalendarStyle PinkSmooth {
            get {
                return new Cube.AFD.Windows.Controls.CalendarControls.CalendarStyle(System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(127)))), ((int)(((byte)(121))))), new Cube.AFD.Windows.Controls.CalendarControls.HeaderStyle(new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177))), System.Drawing.Color.Black, System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(249))))), 23), new Cube.AFD.Windows.Controls.CalendarControls.HeaderStyle(new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177))), System.Drawing.Color.Black, System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(234)))), ((int)(((byte)(218))))), 18), new Cube.AFD.Windows.Controls.CalendarControls.DayStyle(new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177))), new Cube.AFD.Windows.Controls.CalendarControls.DayCellStyle(System.Drawing.Color.LightCoral, System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(189)))), ((int)(((byte)(190))))), System.Drawing.Color.Empty), new Cube.AFD.Windows.Controls.CalendarControls.DayCellStyle(System.Drawing.Color.Black, System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(222)))), ((int)(((byte)(222))))), System.Drawing.Color.Empty), new Cube.AFD.Windows.Controls.CalendarControls.DayCellStyle(System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(101)))), ((int)(((byte)(156))))), System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(227)))), ((int)(((byte)(243))))), System.Drawing.Color.Empty), new Cube.AFD.Windows.Controls.CalendarControls.DayCellStyle(System.Drawing.Color.Black, System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(222)))), ((int)(((byte)(222))))), System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))))), new Cube.AFD.Windows.Controls.CalendarControls.DayCellStyle(System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(101)))), ((int)(((byte)(156))))), System.Drawing.Color.Orange, System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255))))))), new Cube.AFD.Windows.Controls.CalendarControls.MonthText[0], new Cube.AFD.Windows.Controls.CalendarControls.WeekText[] {
            new Cube.AFD.Windows.Controls.CalendarControls.WeekText(System.DayOfWeek.Sunday, "", System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(231)))))),
            new Cube.AFD.Windows.Controls.CalendarControls.WeekText(System.DayOfWeek.Saturday, "", System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(231))))))});
            }
        }
        #endregion
    }

    [TypeConverter(typeof(WeekText.WeekTextConverter))]
    public class WeekText {
        private DayOfWeek m_day = DayOfWeek.Sunday;
        private string m_strText = string.Empty;
        private Color m_backColor = Color.Empty;
        private Brush m_backBrush = new SolidBrush(Color.Empty);
        public WeekText() {
        }
        public WeekText(DayOfWeek day, string text, Color backColor) {
            m_day = day;
            m_strText = text;
            m_backColor = backColor;
            if (backColor == Color.Empty) {
                m_backBrush = null;
            } else {
                m_backBrush = new SolidBrush(backColor);
            }
        }
        internal class WeekTextConverter : TypeConverter {
            public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) {
                if (destinationType == typeof(InstanceDescriptor)) {
                    return true;
                }
                return base.CanConvertTo(context, destinationType);
            }
            public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType) {
                if (destinationType == typeof(InstanceDescriptor)) {
                    WeekText w = (WeekText)value;
                    ConstructorInfo cInfo = typeof(WeekText).GetConstructor(new Type[] { typeof(DayOfWeek), typeof(string), typeof(Color)});
                    return new InstanceDescriptor(cInfo, new object[] { w.Day, w.Text, w.BackColor}, true);
                }
                return base.ConvertTo(context, culture, value, destinationType);
            }
        }
        public DayOfWeek Day {
            get {
                return m_day;
            }
            set {
                if (m_day != value) {
                    m_day = value;
                }
            }
        }
        public string Text {
            get {
                return m_strText;
            }
            set {
                if (m_strText != value) {
                    m_strText = value;
                }
            }
        }
        public Color BackColor {
            get {
                return m_backColor;
            }
            set {
                if (m_backColor != value) {
                    m_backColor = value;
                    if (value == Color.Empty) {
                        m_backBrush = null;
                    } else {
                        m_backBrush = new SolidBrush(value);
                    }
                }
            }
        }
        [Browsable(false)]
        public Brush BackBrush { get { return m_backBrush; } }
        public override bool Equals(object obj) {
            return m_day == ((WeekText)obj).m_day;
        }
        public override int GetHashCode() {
            return base.GetHashCode();
        }
        public override string ToString() {
            return m_day.ToString() + " : " + m_strText;
        }
    }
    [TypeConverter(typeof(MonthText.MonthTextConverter))]
    public class MonthText{
        private MonthOfYear m_month = MonthOfYear.January;
        private string m_strText = string.Empty;
        public MonthText(){
        }
        public MonthText(MonthOfYear month, string text){
            m_month = month;
            m_strText = text;
        }
        internal class MonthTextConverter : TypeConverter {
            public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) {
                if (destinationType == typeof(InstanceDescriptor)) {
                    return true;
                }
                return base.CanConvertTo(context, destinationType);
            }
            public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType) {
                if (destinationType == typeof(InstanceDescriptor)) {
                    MonthText m = (MonthText)value;
                    ConstructorInfo cInfo = typeof(MonthText).GetConstructor(new Type[] {typeof(MonthOfYear), typeof(string) });
                    return new InstanceDescriptor(cInfo, new object[] { m.Month, m.Text}, true);
                }
                return base.ConvertTo(context, culture, value, destinationType);
            }
        }
        public MonthOfYear Month{
            get{
                return m_month;
            }
            set{
                if (m_month != value){
                    m_month = value;
                }
            }
        }
        public string Text{
            get{
                return m_strText;
            }
            set{
                if (m_strText != value){
                    m_strText = value;
                }
            }
        }
        public override bool Equals(object obj) {
            return m_month == ((MonthText)obj).m_month;
        }
        public override int GetHashCode() {
            return base.GetHashCode();
        }
        public override string ToString() {
            return m_month.ToString() + " : " + m_strText;
        }
    }

    public class WeekTextCollection : CollectionBase {
        public WeekText this[int index] {
            get {
                return ((WeekText)List[index]);
            }
            set {
                List[index] = value;
            }
        }

        public int Add(WeekText value) {
            return (List.Add(value));
        }

        public int IndexOf(WeekText value) {
            return (List.IndexOf(value));
        }

        public int IndexOf(DayOfWeek day) {
            WeekText w = new WeekText(day, string.Empty, Color.Empty);
            return this.IndexOf(w);
        }

        public void Insert(int index, WeekText value) {
            List.Insert(index, value);
        }

        public void Remove(WeekText value) {
            List.Remove(value);
        }

        public bool Contains(WeekText value) {
            // If value is not of type Int16, this will return false.
            return (List.Contains(value));
        }

        public bool Contains(DayOfWeek day) {
            WeekText w = new WeekText(day, string.Empty, Color.Empty);
            return this.Contains(w);
        }

        public void AddRange(WeekText[] value) {
            foreach (WeekText m in value) {
                this.Add(m);
            }
        }

        public string GetWeekText(DayOfWeek day, string defaultValue) {
            int index = this.IndexOf(day);
            string s = string.Empty;
            if (index >= 0) {
                s = this[index].Text;
            }
            if (s.Trim() == string.Empty)
                s = defaultValue;
            return s;
        }

        public WeekText[] ToMonthTextArray() {
            WeekText[] ms = new WeekText[this.Count];
            for (int i = 0; i < this.Count; ++i) {
                ms[i] = this[i];
            }
            return ms;
        }

    }

    public class MonthTextCollection : CollectionBase {
        public MonthText this[int index] {
            get {
                return ((MonthText)List[index]);
            }
            set {
                List[index] = value;
            }
        }

        public int Add(MonthText value) {
            return (List.Add(value));
        }

        public int IndexOf(MonthText value) {
            return (List.IndexOf(value));
        }

        public int IndexOf(MonthOfYear month) {
            MonthText m = new MonthText(month, string.Empty);
            return this.IndexOf(m);
        }

        public string GetMonthText(MonthOfYear month, string defaultValue) {
            int index = this.IndexOf(month);
            if (index >= 0) {
                return this[index].Text;
            } else {
                return defaultValue;
            }
        }

        public void Insert(int index, MonthText value) {
            List.Insert(index, value);
        }

        public void Remove(MonthText value) {
            List.Remove(value);
        }

        public bool Contains(MonthText value) {
            // If value is not of type Int16, this will return false.
            return (List.Contains(value));
        }

        public bool Contains(MonthOfYear month) {
            MonthText m = new MonthText(month, string.Empty);
            return (List.Contains(m));
        }
        
        public void AddRange(MonthText[] value) {
            foreach (MonthText m in value){
                this.Add(m);
            }
        }

        public MonthText[] ToMonthTextArray() {
            MonthText[] ms = new MonthText[this.Count];
            for (int i = 0; i < this.Count; ++i) {
                ms[i] = this[i];
            }
            return ms;
        }

    }

}
