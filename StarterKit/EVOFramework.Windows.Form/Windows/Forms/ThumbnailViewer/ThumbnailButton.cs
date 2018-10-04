using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace EVOFramework.Windows.Forms
{
    /// <summary>
    /// Represents item button on Thumbnail viewer.
    /// </summary>
    [ToolboxItem(false)]
    public partial class ThumbnailButton : Control
    {
        #region Variables

        /// <summary>
        /// Border corner radius angle, default = 6
        /// </summary>
        private int m_borderCornerRadius = 6;

        /// <summary>
        /// Start linear brush color at top (Vertical).
        /// </summary>
        private Color m_backgroundColorStart = Color.FromArgb(255, 182, 90);

        /// <summary>
        /// End linear brush color at bottom (Vertical).
        /// </summary>
        private Color m_backgroundColorEnd = Color.FromArgb(255, 226, 123);

        /// <summary>
        /// Border Color
        /// </summary>
        private Color m_borderColor = Color.FromArgb(205, 180, 155);

        /// <summary>
        /// Same image size on width and height.
        /// </summary>
        private int m_imageSizeSymmetric = 100;

        /// <summary>
        /// Image to display.
        /// </summary>
        private Image m_image = null;

        /// <summary>
        /// Dummy of image. If Image property is assigned, it will calculate new ratio image and store to dummy.
        /// </summary>
        private Image m_imageDummy = null;

        #region Flags
        /// <summary>
        /// Flag to indicate that control has selected by mouse or keyboard.
        /// </summary>
        private bool m_bSelected = false;

        /// <summary>
        /// Flag to indicate that mouse has over on control.
        /// </summary>
        private bool m_bMouseHover = false;

        #endregion

        #endregion

        #region Constructor
        public ThumbnailButton()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.StandardClick, true);
            SetStyle(ControlStyles.UserMouse, true);
        }
        #endregion

        #region Overriden
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            AdjustSize(new Size(ImageSizeSymmetric, ImageSizeSymmetric));
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            m_bSelected = false;
            m_bMouseHover = true;

            this.Invalidate(false);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            m_bSelected = false;
            m_bMouseHover = false;

            this.Invalidate(false);
        }
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);

            m_bSelected = false;
            m_bMouseHover = true;

            this.Invalidate(false);
        }
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            
            m_bSelected = false;
            m_bMouseHover = false;

            this.Invalidate(false);
        }
        #endregion

        #region Paint method
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);            


            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.Bicubic;            

            Rectangle clientRectangle = this.ClientRectangle;
            clientRectangle.Width--;
            clientRectangle.Height--;

            if (DesignMode)
            {
                GraphicsPath borderPath = CreateBorderPath(clientRectangle);
                DrawBorder(g, borderPath, Color.Gray, 1, DashStyle.Dash);

                DrawImage(g);
                borderPath.Dispose();
                
                return;
            }

            if (this.Focused) {
                GraphicsPath borderPath = CreateBorderPath(clientRectangle);
                // Fill Background color
                g.SetClip(borderPath);
                DrawBackground(g, 0);
                g.ResetClip();                

                // Draw Border.
                DrawBorder(g, borderPath, BorderColor, 1);
                borderPath.Dispose();
            } else if (m_bMouseHover) {
                GraphicsPath borderPath = CreateBorderPath(clientRectangle);
                // Fill Background color
                g.SetClip(borderPath);
                DrawBackground(g, -100);
                g.ResetClip();

                // Draw Border.
                DrawBorder(g, borderPath, BorderColor, 1);
                borderPath.Dispose();
            }

            // Draw Image.
            DrawImage(g);
        }

        private void DrawBackground(Graphics g, int shiftBrightness) {
            Color startColor = ColorHelper.ShiftSaturation(BackgroundColorStart, shiftBrightness);
            Color endColor = ColorHelper.ShiftSaturation(BackgroundColorEnd, shiftBrightness);
            LinearGradientBrush linear = new LinearGradientBrush(this.ClientRectangle, startColor, endColor, LinearGradientMode.Vertical);            
            g.FillRectangle(linear, this.ClientRectangle);            
            linear.Dispose();
        }

        private void DrawImage(Graphics g) {
            if (ImageDummy == null)
                return;
            
            // Calculate position to draw image.
            int x = (this.ClientRectangle.Width / 2) - (ImageDummy.Width / 2);
            int y = (this.ClientRectangle.Height / 2) - (ImageDummy.Height / 2);
            g.DrawImageUnscaled(ImageDummy, x, y);
        }
        #endregion

        #region Utility methods
        /// <summary>
        /// Create border graphics path with corner radius.
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        private GraphicsPath CreateBorderPath(Rectangle area)
        {
            GraphicsPath path = new GraphicsPath();

            if (BorderCornerRadius == 0)
            {
                path.AddRectangle(area);
            }
            else {
                path.AddArc(area.X, area.Y, BorderCornerRadius, BorderCornerRadius, 180, 90);
                path.AddArc(area.Right - BorderCornerRadius, area.Y, BorderCornerRadius, BorderCornerRadius, 270, 90);
                path.AddArc(area.Right - BorderCornerRadius, area.Bottom - BorderCornerRadius, BorderCornerRadius, BorderCornerRadius, 0, 90);
                path.AddArc(area.X, area.Bottom - BorderCornerRadius, BorderCornerRadius, BorderCornerRadius, 90, 90);
                path.CloseFigure();
            }

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

        #region Public method
        /// <summary>
        /// Adjust Size to fit image and spare space padding all edge.
        /// </summary>
        /// <param name="size">Size of Image.</param>
        public void AdjustSize(Size size) {

            // Padding all edge at least 3 pixel.
            int iPadding = 3;
            if (BorderCornerRadius > 6)
            {
                iPadding = BorderCornerRadius / 2;
            }
            this.Width = ImageSizeSymmetric + (iPadding * 2);
            this.Height = ImageSizeSymmetric + (iPadding * 2);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Border corner radius angle, default = 6
        /// </summary>
        [Browsable(true)]
        [DefaultValue(6)]
        public int BorderCornerRadius
        {
            get { return m_borderCornerRadius; }
            set {
                m_borderCornerRadius = (value < 0) ? 0 : value;
            }
        }

        /// <summary>
        /// Start linear brush color at top (Vertical).
        /// </summary>
        [Browsable(true)]
        [DefaultValue(typeof(Color), "255, 182, 90")]
        public Color BackgroundColorStart {
            get { return m_backgroundColorStart; }
            set { m_backgroundColorStart = value; }
        }

        /// <summary>
        /// End linear brush color at bottom (Vertical).
        /// </summary>
        [Browsable(true)]
        [DefaultValue(typeof(Color), "255, 226, 123")]
        public Color BackgroundColorEnd {
            get { return m_backgroundColorEnd; }
            set { m_backgroundColorEnd = value; }
        }

        /// <summary>
        /// Border Color
        /// </summary>
        public Color BorderColor {
            get { return m_borderColor; }
            set { m_borderColor = value; }
        }

        /// <summary>
        /// Image to display.
        /// </summary>
        public Image Image {
            get { return m_image; }
            set {
                m_image = value;

                // Calculate size symmetric.
                if (value == null) {
                    m_imageDummy = null;
                    return;
                }

                if (value.Height <= ImageSizeSymmetric && value.Width <= ImageSizeSymmetric) {
                    m_imageDummy = value;
                    return;
                }

                if (value.Height < value.Width) {
                    int newHeight = Math.Max(1, Convert.ToInt32(ImageSizeSymmetric * ( value.Height / (double)value.Width )));
                    m_imageDummy = ImageHelper.GetThumbnailImage(value, ImageSizeSymmetric, newHeight);
                    return;
                }

                if (value.Height > value.Width) {
                    int newWidth = Math.Max(1, Convert.ToInt32(ImageSizeSymmetric * ( value.Width / (double)value.Height )));
                    m_imageDummy = ImageHelper.GetThumbnailImage(value, newWidth, ImageSizeSymmetric);
                    return;
                }

                m_imageDummy = ImageHelper.GetThumbnailImage(value, ImageSizeSymmetric, ImageSizeSymmetric);
            }
        }

        /// <summary>
        /// Same image size on width and height.
        /// </summary>
        public int ImageSizeSymmetric {
            get { return m_imageSizeSymmetric; }
            set { m_imageSizeSymmetric = value; }
        }

        /// <summary>
        /// Dummy of image. If Image property is assigned, it will calculate new ratio image and store to dummy.
        /// </summary>
        private Image ImageDummy {
            get { return m_imageDummy; }
            set { m_imageDummy = value; }
        }

        #endregion
    }
}
