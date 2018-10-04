/* Create by: Mr. Teerayut Sinlan
 * Create on: 2009-08-05
 * Company: CSI Groups (Thailand)
 * Group: SI-EVO
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using EVOFramework;

namespace SystemMaintenance.Forms
{
    [ToolboxItem(false)]
    internal partial class FavoriteButton : Button
    {
        private const int C_CORNER_RADIUS = 6;
        private const int C_IMAGE_SIZE = 32;

        private bool m_bMouseOver = false;

        /// <summary>
        /// Indicate flatten button. If true, border will draw when mouse is over. Otherwise draw border always.
        /// </summary>
        private bool m_flatButton = true;

        /// <summary>
        /// Border Color.
        /// </summary>
        private Color m_borderColor = Color.Red;

        public FavoriteButton()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            
            this.MouseEnter += new EventHandler(FavoriteButton_MouseEnter);
            this.MouseLeave += new EventHandler(FavoriteButton_MouseLeave);
        }


        #region " Properties "
        /// <summary>
        /// Indicate flatten button. If true, border will draw when mouse is over. Otherwise draw border always.
        /// </summary>
        public bool FlatButton {
            get { return m_flatButton; }
            set {
                if (m_flatButton != value) {
                    if (value == false) {
                        this.Enter -= new EventHandler(FavoriteButton_MouseEnter);
                        this.Leave -= new EventHandler(FavoriteButton_MouseLeave);
                        m_bMouseOver = true;
                    } else {
                        this.Enter += new EventHandler(FavoriteButton_MouseEnter);
                        this.Leave += new EventHandler(FavoriteButton_MouseLeave);
                    }
                }

                m_flatButton = value;
            }
        }

        /// <summary>
        /// Border Color.
        /// </summary>
        public Color BorderColor {
            get { return m_borderColor; }
            set { m_borderColor = value; }
        }
        #endregion

        #region " Private methods "
        private GraphicsPath CreateBorderPath(Rectangle area)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(area.X, area.Y, C_CORNER_RADIUS, C_CORNER_RADIUS, 180, 90);
            path.AddArc(area.Right - C_CORNER_RADIUS, area.Y, C_CORNER_RADIUS, C_CORNER_RADIUS, 270, 90);
            path.AddArc(area.Right - C_CORNER_RADIUS, area.Bottom - C_CORNER_RADIUS, C_CORNER_RADIUS, C_CORNER_RADIUS, 0, 90);
            path.AddArc(area.X, area.Bottom - C_CORNER_RADIUS, C_CORNER_RADIUS, C_CORNER_RADIUS, 90, 90);
            path.CloseFigure();

            return path;
        }

        private void DrawBorder(Graphics g, GraphicsPath borderPath, Color borderColor, int penWidth)
        {
            DrawBorder(g, borderPath, borderColor, penWidth, DashStyle.Solid);
        }        

        private void DrawBorder(Graphics g, GraphicsPath borderPath, Color borderColor, int penWidth, DashStyle dashStyle)
        {
            using (Pen pen = new Pen(borderColor, penWidth))
            {
                pen.DashStyle = dashStyle;
                g.DrawPath(pen, borderPath);
            }
        }        
        private void DrawImage(Graphics g, Image image, int x, int y, int width, int height)
        {
            Image thumbImg = ImageHelper.GetThumbnailImage(image, width, height);
            g.DrawImage(thumbImg, x, y, width, height);
            thumbImg.Dispose();
        }
        #endregion

        void FavoriteButton_MouseLeave(object sender, EventArgs e)
        {
            m_bMouseOver = false;
            this.Invalidate();
        }

        void FavoriteButton_MouseEnter(object sender, EventArgs e)
        {
            m_bMouseOver = true;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            Graphics g = pe.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.Clear(BackColor);

            Rectangle rect = this.ClientRectangle;
            rect.Width--;
            rect.Height--;

            using (GraphicsPath path = CreateBorderPath(rect)) {
                //Default padding = 3
                int yText = 3;
                if (Image != null) {
                    yText += C_IMAGE_SIZE + 3;

                    // Draw Image
                    DrawImage(g, Image, 
                        (this.Width / 2) - (C_IMAGE_SIZE / 2), 
                        3, C_IMAGE_SIZE, C_IMAGE_SIZE);
                }


                // Draw Text
                Rectangle rectText = new Rectangle();
                rectText.X = 3;
                rectText.Y = yText;
                rectText.Width = this.Width - 6;
                rectText.Height = this.Height - rectText.Y - 3;
                TextRenderer.DrawText(g, this.Text, this.Font, rectText, this.ForeColor, 
                    TextFormatFlags.Top | TextFormatFlags.HorizontalCenter | TextFormatFlags.WordBreak | TextFormatFlags.WordEllipsis);

                // Draw border
                if (m_bMouseOver) {
                    DrawBorder(g, path, BorderColor, 1);
                } else {
                    if (this.Focused) {
                        DrawBorder(g, path, WorkFlowDiagram.HSBColor.ShiftBrighness(BorderColor, 70), 1, DashStyle.Dash);
                    }
                }
                
            }
        }
    }
}
