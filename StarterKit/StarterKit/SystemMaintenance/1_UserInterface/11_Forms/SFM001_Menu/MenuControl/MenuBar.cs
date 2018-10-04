/*
 * Create By: Mr.Teerayut Sinlan
 * Create Date: 2009-07-21
 * Group : ASSI SI-JE2
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SystemMaintenance.Forms
{
    [Serializable()]
    public partial class MenuBar
    {
        #region " Enumeration "
        public enum EState {
            Collapsed,
            Expanded
        }
        #endregion

        #region " Constant "
        /// <summary>
        /// Left margin of image
        /// </summary>
        public const int C_IMAGE_LEFT_MARGIN = 13;
        /// <summary>
        /// Top and bottom margin to display text.
        /// </summary>
        public const int C_TEXT_TOP_BOTTOM_MARGIN = 5;
        /// <summary>
        /// Right margin of display text.
        /// </summary>
        public const int C_TEXT_RIGHT_MARGIN = 2;
        /// <summary>
        /// Space between image and text.
        /// </summary>
        public const int C_SPACE_BETWEEN_IMAGE_AND_TEXT = 2;
        /// <summary>
        /// Left margin of seperator line.
        /// </summary>
        public const int C_SEPERATOR_LEFT_MARGIN = 13;
        /// <summary>
        /// Right margin of seperator line.
        /// </summary>
        public const int C_SEPERATOR_RIGHT_MARGIN = 13;
        #endregion

        #region " Variables "
        /// <summary>
        /// Location (x, y)
        /// </summary>
        private Point m_location = Point.Empty;
        /// <summary>
        /// Size (width, height)
        /// </summary>
        private Size m_size = Size.Empty;
        /// <summary>
        /// Store own data.
        /// </summary>
        private object m_tag = null;

        /// <summary>
        /// Host which contain this control.
        /// </summary>
        [NonSerialized()]
        private MenuTree m_host = null;

        /// <summary>
        /// Collection of child menu items.
        /// </summary>
        private readonly List<MenuItem> m_menuItems = new List<MenuItem>();

        /// <summary>
        /// Appearance.
        /// </summary>
        private MenuBarAppearance m_appearance = new DefautlMenuBarAppearance();

        /// <summary>
        /// Collapse/Expand state.
        /// </summary>
        private EState m_state = EState.Collapsed;

        /// <summary>
        /// Text display.
        /// </summary>
        private string m_text = "";

        #endregion

        #region " Constructor "
        public MenuBar()
        {
        }        
        #endregion

        #region " Private method "
        /// <summary>
        /// Get text format flags.        
        /// </summary>
        /// <returns></returns>
        public TextFormatFlags GetTextFormatFlags() {
            return TextFormatFlags.VerticalCenter
                   | TextFormatFlags.Left
                   | TextFormatFlags.WordBreak
                   | TextFormatFlags.WordEllipsis;
        }

        /// <summary>
        /// Get image expand/collapse state.
        /// </summary>
        /// <returns></returns>
        public Image GetImageFromCurrentState(DrawingState state) {
            if (State == EState.Collapsed) {
                switch (state) {
                    case DrawingState.Normal:
                        return Appearance.NormalImageCollapsed;
                    case DrawingState.Over:
                        return Appearance.OverImageCollapsed;
                    default:
                        return Appearance.NormalImageCollapsed;
                        
                }                
            } else {
                switch (state)
                {
                    case DrawingState.Normal:
                        return Appearance.NormalImageExpanded;
                    case DrawingState.Over:
                        return Appearance.OverImageExpanded;
                    default:
                        return Appearance.NormalImageExpanded;
                }    
            }
        }

        internal void RecalculateLocationAndSizeOfMenuItems() {
            int width = this.ClientRectangle.Width;

            int yPos = 0;
            for (int i=0; i<MenuItems.Count; i++) {
                MenuItem item = MenuItems[i];
                item.Location = new Point(0, yPos);
                item.Size = new Size(width, item.GetRowHeight(width));

                yPos += item.Size.Height + 1;
            }
        }
        #endregion

        #region " Public method "
        //public void RecreateImageBufferMenuItems() {
        //    RecreateImageBufferMenuItems(null);
        //}
        //public void RecreateImageBufferMenuItems(MenuItem hoverItem)
        //{
        //    // Release old memory.
        //    //if (ImageBufferMenuItems != null) {
        //    //    ImageBufferMenuItems.Dispose();
        //    //    ImageBufferMenuItems = null;
        //    //}

        //    if (MenuItems.Count == 0) {
        //        return;
        //    }

        //    //Bitmap image  = CreateImageBufferMenuItems();
        //    //ImageBufferMenuItems = DrawImageBufferMenuItems(image, hoverItem);
        //}

        /// <summary>
        /// Calculate row height.
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public int GetRowHeight(int widthArea, DrawingState state) {                                    

            Image img = GetImageFromCurrentState(state);
            int imgHeight = img.Height;

            int textWidthArea = widthArea - (C_IMAGE_LEFT_MARGIN + img.Width + C_SPACE_BETWEEN_IMAGE_AND_TEXT + C_TEXT_RIGHT_MARGIN);
            
            TextFormatFlags flags = GetTextFormatFlags();
            int textHeight = TextRenderer.MeasureText(Text, Appearance.Font, new Size(textWidthArea, 1000), flags).Height;

            
            return Math.Max(textHeight, imgHeight + 4);
        }
        

        /// <summary>
        /// Calculate all rows height of child menu item.
        /// </summary>        
        /// <returns></returns>
        public int GetMenuItemsContentHeight()
        {
            if (MenuItems.Count > 0)
                return MenuItems[MenuItems.Count - 1].ClientRectangle.Bottom;
            return 0;
        }
        
        

        #region " Expand/Collapse/Toggle method "
        /// <summary>
        /// Expand sub menu items.
        /// </summary>
        public void Expand() {
            if (State == EState.Expanded)
                return;

            this.RecalculateLocationAndSizeOfMenuItems();
            m_state = EState.Expanded;

            if (MenuItems.Count != 0) {
                //Bitmap image = CreateImageBufferMenuItems();
                //ImageBufferMenuItems = DrawImageBufferMenuItems(image, null);

                Host.RecalculateLocationAndSize();
            }

            Host.Invalidate();
        }

        /// <summary>
        /// Collapse sub menu items.
        /// </summary>
        public void Collapse() {
            if (State == EState.Collapsed)
                return;

            // Relase image buffer of menu items.
            //if (ImageBufferMenuItems != null) {
            //    ImageBufferMenuItems.Dispose();
            //    ImageBufferMenuItems = null;
            //}

            m_state = EState.Collapsed;




            Host.RecalculateLocationAndSize();
            Host.Invalidate();
        }

        /// <summary>
        /// Toggle state of sub menu items.
        /// </summary>
        public void ToggleState() {
            if (State == EState.Expanded)
                Collapse();
            else {
                Expand();
            }
        }
        #endregion

        #region " Hit Test "
        public bool ContainsBarOrItemContent(Point pt) {
            return ContainsBarOrItemContent(pt.X, pt.Y);
        }
        public bool ContainsBarOrItemContent(int x, int y)
        {
            Rectangle area = ClientRectangle;
            
            if (State == EState.Expanded) {
                area.Height += this.GetMenuItemsContentHeight();
            }

            return area.Contains(x, y);
        }
        public bool ContainsBar(Point pt) {
            return ContainsBar(pt.X, pt.Y);
        }
        public bool ContainsBar(int x, int y) {
            return this.ClientRectangle.Contains(x, y);
        }

        #endregion
        #endregion

        #region " Scroll Position "
        internal void OffsetPosition(int dx, int dy) {
            Point pt = this.Location;
            pt.X += dx;
            pt.Y += dy;
            this.Location = pt;
        }        
        #endregion

        #region " Properties "
        /// <summary>
        /// Host which contain this control.
        /// </summary>
        public MenuTree Host
        {
            get { return m_host; }
            internal set { m_host = value; }
        }

        /// <summary>
        /// Appearance.
        /// </summary>        
        public MenuBarAppearance Appearance {
            get { return m_appearance; }
            set { m_appearance = value; }
        }

        /// <summary>
        /// Collapse/Expand state.
        /// </summary>
        public EState State {
            get { return m_state; }
            //internal set { m_state = value; }
        }

        /// <summary>
        /// Text display.
        /// </summary>
        public string Text {
            get { return m_text; }
            set {
                m_text = value ?? String.Empty;
            } 
        }

        /// <summary>
        /// Store own data.
        /// </summary>
        public object Tag
        {
            get { return m_tag; }
            set { m_tag = value; }
        }

        /// <summary>
        /// Collection of child menu items.
        /// </summary>
        public List<MenuItem> MenuItems
        {
            get { return m_menuItems; }
        }

        /// <summary>
        /// Location (x, y)
        /// </summary>
        public Point Location {
            get { return m_location; }
            set {
                m_location = value;
                if (Host != null) {
                    Host.Invalidate();
                }
            }
        }

        /// <summary>
        /// Size (width, height)
        /// </summary>
        public Size Size {
            get { return m_size; }
            set {
                m_size = value;

                

                if (Host != null)
                {
                    // Update location and size of MenuItems.
                    RecalculateLocationAndSizeOfMenuItems();
                    Host.Invalidate();
                }
            }
        }

        /// <summary>
        /// Get client rectangle.
        /// </summary>
        public Rectangle ClientRectangle {
            get {
                return new Rectangle(Location, Size);
            }
        } 
        #endregion
    }
}
