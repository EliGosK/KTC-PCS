/*
 * Create By: Mr.Teerayut Sinlan
 * Create Date: 2009-07-21
 * Group : ASSI SI-JE2
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace SystemMaintenance.Forms
{
    public partial class MenuItem
    {
        #region " Constant "
        /// <summary>
        /// Left margin of image
        /// </summary>
        public const int C_IMAGE_LEFT_MARGIN = 20;
        /// <summary>
        /// Top and bottom margin to display text.
        /// </summary>
        public const int C_TEXT_TOP_BOTTOM_MARGIN = 2;
        /// <summary>
        /// Right margin of display text.
        /// </summary>
        public const int C_TEXT_RIGHT_MARGIN = 2;
        /// <summary>
        /// Space between image and text.
        /// </summary>
        public const int C_SPACE_BETWEEN_IMAGE_AND_TEXT = 2;
        #endregion

        #region " Variables "

        private object m_tag = null;
        private MenuBar m_parent = null;
        private string m_text = null;
        private Image m_image = null;
        private MenuItemAppearance m_appearance = new DefaultMenuItemAppearance();

        private Point m_location = Point.Empty;
        private Size m_size = Size.Empty;
        #endregion

        #region " Constructor "
        public MenuItem(MenuBar parent)
        {
            m_parent = parent;
        }
        #endregion

        #region " Private method "
        /// <summary>
        /// Get text format flags.        
        /// </summary>
        /// <returns></returns>
        public TextFormatFlags GetTextFormatFlags()
        {
            return TextFormatFlags.VerticalCenter
                | TextFormatFlags.Left
                | TextFormatFlags.WordBreak
                | TextFormatFlags.WordEllipsis;
        }
        
        #endregion

        #region " Public method "
        /// <summary>
        /// Calculate row height.
        /// </summary>
        /// <param name="widthArea">Whole width of client rectangle.</param>
        /// <returns></returns>
        public int GetRowHeight(int widthArea)
        {
            Size imageSize = Size.Empty;
            if (Image != null) {
                imageSize.Height = Image.Height;
                imageSize.Width = Image.Width;
            }            

            int textWidthArea = widthArea - (C_IMAGE_LEFT_MARGIN + imageSize.Width + C_SPACE_BETWEEN_IMAGE_AND_TEXT + C_TEXT_RIGHT_MARGIN);

            TextFormatFlags flags = GetTextFormatFlags();
            int textHeight = TextRenderer.MeasureText(Text, Appearance.Font, new Size(textWidthArea, 1000), flags).Height;

            return Math.Max(textHeight + (C_TEXT_TOP_BOTTOM_MARGIN * 2), imageSize.Height + (C_TEXT_TOP_BOTTOM_MARGIN * 2));            
        }

        /// <summary>
        /// Get Rectangle area of Image and Text for paint on surface.
        /// </summary>
        /// <param name="outImageRectangle">output Image rectangle</param>
        /// <param name="outTextRectangle">output Text rectangle</param>
        internal void GetImageAndTextRectangle(out Rectangle outImageRectangle, out Rectangle outTextRectangle) {
            Size imageSize = Size.Empty;
            if (Image != null)
            {
                imageSize.Height = Image.Height;
                imageSize.Width = Image.Width;
            }  

            outImageRectangle = new Rectangle();   
            outTextRectangle = new Rectangle();

            if (Image != null) {
                outImageRectangle.X = this.ClientRectangle.X + C_IMAGE_LEFT_MARGIN;
                outImageRectangle.Y = this.ClientRectangle.Y + C_TEXT_TOP_BOTTOM_MARGIN;
                outImageRectangle.Width = imageSize.Width;
                outImageRectangle.Height = imageSize.Height;
            }

            outTextRectangle.X = outImageRectangle.Right + C_SPACE_BETWEEN_IMAGE_AND_TEXT;
            outTextRectangle.Y = this.ClientRectangle.Y + C_TEXT_TOP_BOTTOM_MARGIN;
            outTextRectangle.Width = this.ClientRectangle.Width - ( outTextRectangle.X + C_TEXT_RIGHT_MARGIN );
            outTextRectangle.Height = this.ClientRectangle.Height - ( C_TEXT_TOP_BOTTOM_MARGIN * 2);
        }        
        #endregion        

        #region " HitTest "
        public bool Contains(Point pt) {
            return Contains(pt.X, pt.Y);
        }

        public bool Contains(int x, int y) {
            Rectangle rect = ClientRectangle;
            rect.Offset(0, Parent.ClientRectangle.Bottom);
            return rect.Contains(x, y);
        }
        #endregion

        #region " Properties "
        /// <summary>
        /// Appearance of MenuItem.
        /// </summary>
        public MenuItemAppearance Appearance
        {
            get { return m_appearance; }
            set { m_appearance = value; }
        }
        /// <summary>
        /// Parent of menu item.
        /// </summary>
        public MenuBar Parent
        {
            get { return m_parent; }
            set { m_parent = value; }
        }

        /// <summary>
        /// Text to display.
        /// </summary>
        public string Text
        {
            get { return m_text; }
            set { m_text = value;}
        }

        /// <summary>
        /// Image to display
        /// </summary>
        public Image Image
        {
            get { return m_image; }
            set { m_image = value; }
        }

        /// <summary>
        /// Location relative with parent MenuBar.
        /// </summary>
        public Point Location {
            get { return m_location; }
            set {
                m_location = value;
                if (Parent != null && Parent.Host != null) {
                    Parent.Host.Invalidate();
                }
            }
        }

        public Size Size {
            get { return m_size; }
            set {
                m_size = value;
                if (Parent != null && Parent.Host != null)
                {
                    Parent.Host.Invalidate();
                }
            }
        }

        public Rectangle ClientRectangle {
            get { return new Rectangle(Location, Size); }
        }

        public object Tag {
            get { return m_tag; }
            set { m_tag = value; }
        }

        #endregion
    }
}
