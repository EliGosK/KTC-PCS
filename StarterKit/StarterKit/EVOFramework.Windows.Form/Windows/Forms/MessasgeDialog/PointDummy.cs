using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EVOFramework.Windows.Forms
{
    internal partial class PointDummy : System.Windows.Forms.Form
    {
        private ArrayList m_lineList = new ArrayList();
        private byte m_alpha = 0;

        public PointDummy()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            int iExStyle = Win32.GetWindowLong(this.Handle, Win32.GWL_EXSTYLE);
            iExStyle |= Win32.WS_EX_LAYERED | Win32.WS_EX_NOACTIVATE | Win32.WS_EX_TRANSPARENT;

            Win32.SetWindowLong(this.Handle, Win32.GWL_EXSTYLE, iExStyle);

            //Prevent Flicker ตอนเปิดหน้าจอครั้งแรก
            SetAlpha(0);
            //Win32.SetLayeredWindowAttributes(this.Handle, Win32.RGB(BackColor.R,BackColor.G,BackColor.B), 0, Win32.LWA_ALPHA | Win32.LWA_COLORKEY);
            Win32.ShowWindow(this.Handle, Win32.SW_SHOW);

            // Redraw contents NOW - no flickering since the window's not visible
            Win32.RedrawWindow(this.Handle, IntPtr.Zero, IntPtr.Zero, Win32.RDW_UPDATENOW);

            //Win32.SetLayeredWindowAttributes(this.Handle, Win32.RGB(BackColor.R, BackColor.G, BackColor.B), 255, Win32.LWA_ALPHA | Win32.LWA_COLORKEY);
            SetAlpha(255);
        }

        /// <summary>
        /// วาดเส้นที่กำหนดไว้
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.Clear(BackColor);

            for (int i = 0; i < m_lineList.Count; i++)
            {
                Line line = m_lineList[i] as Line;
                e.Graphics.DrawLine(new Pen(Color.Black, 1f), line.Point1, line.Point2);
            }
        }

        public void SetAlpha(byte b)
        {
            m_alpha = b;
            Win32.SetLayeredWindowAttributes(this.Handle, Win32.RGB(BackColor.R, BackColor.G, BackColor.B), b, Win32.LWA_ALPHA | Win32.LWA_COLORKEY);
            
        }

        /// <summary>
        /// Get alpha transparent level.
        /// </summary>
        public byte AlphaLevel
        {
            get { return m_alpha; }
        }

        /// <summary>
        /// Set Location and Size, โดยใช้มาตรฐานพิกัดของหน้าจอ DesktopWindow
        /// </summary>
        /// <param name="x1">พิกัด X เริ่มต้น (มุมบนซ้าย)</param>
        /// <param name="y1">พิก้ด Y เริ้มต้น (มุมบนซ้าย)</param>
        /// <param name="x2">พิกัด X ปลายทาง (มุมล่างขวา)</param>
        /// <param name="y2">พิกัด Y ปลายทาง (มุมล่างขวา)</param>
        public void SetPosition(int x1, int y1, int x2, int y2)
        {
            this.Location = new Point(x1, y1);
            this.Size = new Size(x2 - x1, y2 - y1);           
        }

        /// <summary>
        /// เพิ่มเส้นที่วาด
        /// </summary>
        /// <param name="pt1"></param>
        /// <param name="pt2"></param>
        public void AddLine(Point pt1, Point pt2)
        {
            Line line = new Line(pt1, pt2);
            m_lineList.Add(line);
        }

        /// <summary>
        /// ลบรายการเส้นที่วาด
        /// </summary>
        public void ClearLine()
        {
            m_lineList.Clear();
        }

        /// <summary>
        /// Get System screen location and size.
        /// </summary>
        [Browsable(false)]
        public Rectangle SystemScreenRectangle
        {
            get
            {
                Win32.RECT rect = new Win32.RECT();
                Win32.GetWindowRect(Handle, ref rect);
                return rect.ToRectangle();
            }
        }
    }

    internal class Line
    {
        private Point m_pt1;
        private Point m_pt2;

        public Line(Point pt1, Point pt2)
        {
            m_pt1 = pt1;
            m_pt2 = pt2;
        }

        public Point Point1
        {
            get { return m_pt1; }
            set { m_pt1 = value; }
        }

        public Point Point2
        {
            get { return m_pt2; }
            set { m_pt2 = value; }
        }
    }
}