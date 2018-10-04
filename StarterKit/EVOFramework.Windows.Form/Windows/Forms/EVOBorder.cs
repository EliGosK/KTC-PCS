/*
 * พัฒนาโปรแกรมวันที่ 27/10/2007
 * เขียนโดย  นายธีรยุทธ  สินล้าน
 * 
 * UserControl นี้ใช้สำหรับวาดเส้นขอบ หรือจะทำเป็น Frame เหมือนกับ Bevel ใน Delphi
 * 
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace EVOFramework.Windows.Forms
{
    public class EVOBorder : Panel
    {
        public enum BorderEdgeStyle { None, Left, Top, Right, Bottom, All };

        public EVOBorder()
        {            
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.Selectable, false); 
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        #region Attribute
        /// <summary>
        /// Line Color
        /// </summary>
        private Color m_lineColor = Color.FromKnownColor(KnownColor.ControlDark);

        /// <summary>
        /// Shadow Color
        /// </summary>
        private Color m_shadowColor = Color.White;

        /// <summary>
        /// Border Style
        /// </summary>
        private BorderEdgeStyle m_borderStyle = BorderEdgeStyle.All;
        #endregion

        #region Properties
        [Description("Border style")]
        [DefaultValue(typeof(BorderEdgeStyle), "All")]
        public BorderEdgeStyle Style
        {
            set { 
                this.m_borderStyle = value;
                this.Invalidate();
            }
            get { return this.m_borderStyle; }
        }

        [Description("Border Line Color")]        
        public Color BorderLineColor
        {
            set { 
                this.m_lineColor = value;
                this.Invalidate();
            }
            get { return this.m_lineColor; }
        }

        [Description("Border Shadow Color")]
        [DefaultValue(typeof(Color), "White")]
        public Color BorderShadowColor
        {
            set
            {
                this.m_shadowColor = value;
                this.Invalidate();
            }
            get { return this.m_shadowColor; }
        }
        #endregion

        #region Functions

        private void DrawBorderAll(Graphics g, Rectangle clientRectangle)
        {                        
            //reduce width and height by 2
            clientRectangle.Width -= 2;
            clientRectangle.Height -= 2;

            //draw Shadow border line
            clientRectangle.Offset(1, 1);
            using (Pen shadowPen = new Pen(m_shadowColor)) {
                g.DrawRectangle(shadowPen, clientRectangle);
            }

            //draw Main border line
            clientRectangle.Offset(-1, -1);
            using (Pen linePen = new Pen(m_lineColor)) {
                g.DrawRectangle(linePen, clientRectangle);
            }
        }
        private void DrawBorderLeft(Graphics g, Rectangle clientRectangle)
        {
            Point startPoint = new Point(0, 0);
            Point endPoint = new Point(0, clientRectangle.Height);
            using (Pen linePen = new Pen(BorderLineColor)) {
                g.DrawLine(linePen, startPoint, endPoint);
            }

            startPoint.X++;
            endPoint.X++;
            using (Pen borderPen = new Pen(BorderShadowColor)) {
                g.DrawLine(borderPen, startPoint, endPoint);
            }
        }
        private void DrawBorderTop(Graphics g, Rectangle clientRectangle)
        {
            Point startPoint = new Point(0, 0);
            Point endPoint = new Point(clientRectangle.Width, 0);
            using (Pen linePen = new Pen(BorderLineColor)) {
                g.DrawLine(linePen, startPoint, endPoint);
            }

            startPoint.Y++;
            endPoint.Y++;
            using (Pen borderPen = new Pen(BorderShadowColor)) {
                g.DrawLine(borderPen, startPoint, endPoint);
            }
        }
        private void DrawBorderRight(Graphics g, Rectangle clientRectangle)
        {
            Point startPoint = new Point(clientRectangle.Width - 2, 0);
            Point endPoint = new Point(clientRectangle.Width - 2, clientRectangle.Height);
            using (Pen linePen = new Pen(BorderLineColor)) {
                g.DrawLine(linePen, startPoint, endPoint);
            }

            startPoint.X++;
            endPoint.X++;
            using (Pen borderPen = new Pen(BorderShadowColor)) {
                g.DrawLine(borderPen, startPoint, endPoint);
            }
        }
        private void DrawBorderBottom(Graphics g, Rectangle clientRectangle)
        {
            Point startPoint = new Point(0, clientRectangle.Height - 2);
            Point endPoint = new Point(clientRectangle.Width, clientRectangle.Height - 2);
            using (Pen linePen = new Pen(BorderLineColor)) {
                g.DrawLine(linePen, startPoint, endPoint);
            }

            startPoint.Y++;
            endPoint.Y++;
            using (Pen borderPen = new Pen(BorderShadowColor)) {
                g.DrawLine(borderPen, startPoint, endPoint);
            }

        }
        #endregion      

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            switch (m_borderStyle)
            {
                case BorderEdgeStyle.All:
                    DrawBorderAll(e.Graphics, e.ClipRectangle);
                    break;
                case BorderEdgeStyle.Left:
                    DrawBorderLeft(e.Graphics, e.ClipRectangle);
                    break;
                case BorderEdgeStyle.Top:
                    DrawBorderTop(e.Graphics, e.ClipRectangle);
                    break;
                case BorderEdgeStyle.Right:
                    DrawBorderRight(e.Graphics, e.ClipRectangle);
                    break;
                case BorderEdgeStyle.Bottom:
                    DrawBorderBottom(e.Graphics, e.ClipRectangle);
                    break;
                case BorderEdgeStyle.None:
                    break;
            }
        }
        
    }
}
