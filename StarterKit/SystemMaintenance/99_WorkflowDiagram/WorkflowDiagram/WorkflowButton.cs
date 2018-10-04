using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowDiagram.DTO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using EVOFramework;

namespace WorkFlowDiagram
{    
    [ToolboxItem(false)]
    public partial class WorkflowButton : Control
    {
        #region "  Constant  for drawing size of Image.  "
        private const int IMG_WIDTH = 34;
        private const int IMG_HEIGHT = 34;
        #endregion

        #region "  Variables  "
        private ButtonDTO m_dto = null;        
        private Image m_image = SystemMaintenance.Properties.Resources.img_not_found;
        private WorkflowButtonAppearance m_appearance = new WorkflowButtonAppearance();

        private bool m_isMouseOver = false;
        #endregion

        #region "  Constructor  "
        public WorkflowButton() {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        public WorkflowButton(ButtonDTO dto) : base()
        {
            Data = dto;
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.Margin = System.Windows.Forms.Padding.Empty;            
        }
        #endregion
        
        #region "  Properties  "
        /// <summary>
        /// Get or set data.
        /// </summary>
        public ButtonDTO Data {
            get { return m_dto; }
            set { m_dto = value; }
        }

        /// <summary>
        /// Get or set appearance
        /// </summary>
        public WorkflowButtonAppearance Appearance {
            get { return m_appearance; }
            set { m_appearance = value; }
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);

            if (this.Enabled)
            {
                SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                SetStyle(ControlStyles.Selectable, true);

            }
            else
            {
                SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                SetStyle(ControlStyles.Selectable, false);
                
            }
        }

        /// <summary>
        /// Get or set Image to display
        /// </summary>
        public Image Image {
            get { return m_image; }
            set {
                m_image = value;
                if (m_image == null)
                    m_image = SystemMaintenance.Properties.Resources.img_not_found;
                
            }
        }
        #endregion

        #region "  Overriden base method  "        
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            Rectangle clientRect = this.ClientRectangle;
            clientRect.Width--;
            clientRect.Height--;

            GraphicsPath borderPath = CreateBorderPath(clientRect);

            //Draw Client area background.
            if (m_isMouseOver)
            {
                Color backColor = Appearance.BackColor;
                backColor = HSBColor.ShiftBrighness(backColor, -30);
                using (SolidBrush brush = new SolidBrush(backColor))
                {
                    g.FillPath(brush, borderPath);
                }
            } else {
                using (SolidBrush brush = new SolidBrush(Appearance.BackColor)) {
                    g.FillPath(brush, borderPath);
                }
            }


            // Draw Image
            DrawImage(g, this.Image, (clientRect.Width / 2) - (IMG_WIDTH / 2), 3, IMG_WIDTH, IMG_HEIGHT);
            
            // Draw Text
            Rectangle textRect = clientRect;
            textRect.X = 3;
            textRect.Width = clientRect.Width - 6;
            textRect.Y = IMG_HEIGHT + 6;
            textRect.Height = clientRect.Height - ( textRect.Y + 3 );
            
            DrawText(g, this.Text, Appearance.Font, this.Appearance.FontColor, textRect);

            // Draw Border
            if (m_isMouseOver)
            {
                Color backColor = Appearance.BorderColor;
                backColor = HSBColor.ShiftBrighness(backColor, -30);
                DrawBorder(g, borderPath, backColor, 2);
            } else {
                DrawBorder(g, borderPath, Appearance.BorderColor, 1);
            }
            borderPath.Dispose();
        }
        #endregion

        #region "  Paint  Logic"        
        private GraphicsPath CreateBorderPath(Rectangle area) {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(area.X, area.Y, Appearance.CornerRadius, Appearance.CornerRadius, 180, 90);
            path.AddArc(area.Right - Appearance.CornerRadius, area.Y , Appearance.CornerRadius, Appearance.CornerRadius, 270, 90);
            path.AddArc(area.Right - Appearance.CornerRadius, area.Bottom - Appearance.CornerRadius, Appearance.CornerRadius, Appearance.CornerRadius, 0, 90);
            path.AddArc(area.X, area.Bottom - Appearance.CornerRadius, Appearance.CornerRadius, Appearance.CornerRadius, 90, 90);
            path.CloseFigure();

            return path;
        }
        private void DrawBorder(Graphics g, GraphicsPath borderPath, Color borderColor, int penWidth) {
            using (Pen pen = new Pen(borderColor, penWidth)) {
                g.DrawPath(pen, borderPath);
            }
        }
        private void DrawImage(Graphics g, Image image, int x, int y, int width, int height) {
            Image thumbImg = ImageHelper.GetThumbnailImage(image, width, height);
            g.DrawImage(thumbImg, x, y, width, height);
            thumbImg.Dispose();
        }
        private void DrawText(Graphics g, string text, Font font, Color foreColor, Rectangle area) {
            TextRenderer.DrawText(g, text, font, area, foreColor, 
                TextFormatFlags.HorizontalCenter |
                TextFormatFlags.PreserveGraphicsClipping |
                TextFormatFlags.Top |
                TextFormatFlags.WordBreak |
                TextFormatFlags.EndEllipsis 
                );
        }
        #endregion

        #region "  Mouse Event  "
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            m_isMouseOver = false;
            this.Invalidate(false);
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            m_isMouseOver = true;            
            this.Invalidate(false);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            m_isMouseOver = false;
            this.Invalidate(false);
        }
        #endregion
    }
}
