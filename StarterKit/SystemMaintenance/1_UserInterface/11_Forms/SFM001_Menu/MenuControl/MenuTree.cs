/* Create by: Mr. Teerayut Sinlan
 * Create on: 2009-07-21
 * Company: CSI Groups (Thailand)
 * Group: SI-EVO
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SystemMaintenance.Forms
{
    [ToolboxItem(false)]
    public partial class MenuTree : Control
    {
        #region " Constant "
        /// <summary>
        /// Small scroll value.
        /// </summary>
        private int C_SMALL_SCROLL = 20;
        #endregion

        #region " Variables "
        private VScrollBar m_vScrollBar = null;
        private readonly List<MenuBar> m_menuBars = new List<MenuBar>();
        /// <summary>
        /// MenuBar selected.
        /// </summary>
        private MenuBar m_menuBarSelected = null;
        #endregion
        
        #region " Constructor "
        /// <summary>
        /// Constructor
        /// </summary>
        public MenuTree()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Selectable, true);

            base.BackColor = Color.FromArgb(183, 244, 247); 

            VScrollBar = new VScrollBar();            
            VScrollBar.Dock = DockStyle.Right;
            VScrollBar.Visible = false;
            VScrollBar.VisibleChanged += new EventHandler(VScrollBar_VisibleChanged);
            VScrollBar.Scroll += new ScrollEventHandler(VScrollBar_Scroll);
            //VScrollBar.ValueChanged += new EventHandler(VScrollBar_ValueChanged);
            this.Controls.Add(VScrollBar);
        }                        
        #endregion

        #region " Overriden method "
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);           

            RecalculateLocationAndSize();
        }
        protected override void OnResize(EventArgs e)
        {
            
            base.OnResize(e);
           
            RecalculateLocationAndSize();           
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            RecalculateLocationAndSize();
        }        
        #endregion'

        #region "  Properties  "
        public override Color BackColor
        {
            get
            {
                return Color.FromArgb(183, 244, 247); 
            }
            set
            {
                base.BackColor = value;
            }
        }
        /// <summary>
        /// Get client rectangle include scroll bar size.
        /// </summary>
        public new Rectangle ClientRectangle {
            get {
                if (VScrollBar.Visible) {
                    Rectangle rect = new Rectangle();
                    rect.X = 0;
                    rect.Y = 0;
                    rect.Width = this.Width - VScrollBar.Width;
                    rect.Height = this.Height;
                    return rect;
                } else {
                    return base.ClientRectangle;
                }

            }
        }

        /// <summary>
        /// Get or set vertical scrollbar.
        /// </summary>
        [Browsable(false)]
        public VScrollBar VScrollBar
        {
            get { return m_vScrollBar; }
            set { m_vScrollBar = value; }
        }

        /// <summary>
        /// Get list of menu bars.
        /// </summary>
        public List<MenuBar> MenuBars {
            get { return m_menuBars; }
        }

        /// <summary>
        /// MenuBar selected.
        /// </summary>
        public MenuBar MenuBarSelected {
            get { return m_menuBarSelected; }
            set {
                SetMenuBarSelected(value);                
            }
        }

        #endregion

        #region " MenuBar Collection method "

        private bool m_bBeginUpdateMenuBar = false;
        /// <summary>
        /// Begin transaction of add menubar. Call method to suspend draw logic.
        /// </summary>
        public void BeginUpdateMenuBar() {
            m_bBeginUpdateMenuBar = true;
        }

        /// <summary>
        /// Resume draw logic. Call method after add transaction menubar.
        /// </summary>
        public void EndUpdateMenuBar() {
            m_bBeginUpdateMenuBar = false;
            RecalculateLocationAndSize();
            this.Invalidate();
        }

        /// <summary>
        /// Get status of begin update menu bar.
        /// </summary>
        internal bool IsBeginUpdateMenuBar {
            get { return m_bBeginUpdateMenuBar; }
        }

        public void AddMenuBar(MenuBar item)
        {
            item.Host = this;
            m_menuBars.Add(item);

            if (!m_bBeginUpdateMenuBar) {
                RecalculateLocationAndSize();
                this.Invalidate();
            }
        }

        public void RemoveMenuBar(MenuBar item)
        {
            m_menuBars.Remove(item);
            if (!m_bBeginUpdateMenuBar) {
                RecalculateLocationAndSize();
                this.Invalidate();
            }
        }

        public void RemoveMenuBarAt(int index)
        {
            m_menuBars.RemoveAt(index);
            if (!m_bBeginUpdateMenuBar) {
                RecalculateLocationAndSize();
                this.Invalidate();
            }
        }

        public void ClearMenuBars() {
            m_menuBars.Clear();
            if (!m_bBeginUpdateMenuBar) {
                RecalculateLocationAndSize();
                this.Invalidate();
            }
        }

        public int GetCountMenuBar()
        {
            return m_menuBars.Count;
        }
        #endregion

        #region " Scrollbar "
        void VScrollBar_VisibleChanged(object sender, EventArgs e)
        {
            RecalculateLocationAndSize();

            for (int i = 0; i < MenuBars.Count; i++ ) {
                if (MenuBars[i].State == MenuBar.EState.Expanded) {
                    MenuBars[i].RecalculateLocationAndSizeOfMenuItems();
                }
            }                

            RecalculateLocationAndSize();
            this.Invalidate();
        }

        void VScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            int diffValue = e.NewValue - e.OldValue;
            int changeValue = (-1) *diffValue;

            for (int i=0; i<MenuBars.Count(); i++) {
                MenuBars[i].OffsetPosition(0, changeValue);
            }

            this.Invalidate();
        }       

        private void UpdateScrollBar() {
            if (MenuBars.Count == 0) {
                VScrollBar.Value = 0;
                VScrollBar.Visible = false;
                return;
            }            


            // Findout real bottom position.
            int offsetTop = MenuBars[0].Location.Y;

            // Adjust current position to origin coordinate.
            int bottom = MenuBars[MenuBars.Count - 1].ClientRectangle.Bottom - offsetTop;
            if (MenuBars[MenuBars.Count - 1].State == MenuBar.EState.Expanded) {
                bottom += MenuBars[MenuBars.Count - 1].GetMenuItemsContentHeight();
            }
            int maxVal = bottom;
            int smallChangeVal = C_SMALL_SCROLL;
            int largeChangeVal = this.Height + 1;

            int oldValue = this.VScrollBar.Value;       

            VScrollBar.Minimum = 0;
            VScrollBar.Maximum = maxVal;
            VScrollBar.SmallChange = smallChangeVal;
            VScrollBar.LargeChange = largeChangeVal;

            int maxValue = this.VScrollBar.Maximum - this.VScrollBar.LargeChange + 1;
            if (oldValue > maxValue)
            {
                this.VScrollBar.Value = maxValue;
            }
        }
        #endregion

        #region " Privat method "
        #region " Recalculate Location and Size "
        /// <summary>
        /// Compute location and size on all menu bar and own menu item.
        /// </summary>
        internal void RecalculateLocationAndSize()
        {
            RecalculateLocationAndSize(true);
        }

        /// <summary>
        /// Compute location and size on all menu bar and own menu item.
        /// </summary>
        /// <param name="calcScroll">True = calculate scrollbar</param>
        private void RecalculateLocationAndSize(bool calcScroll)
        {
            int offsetScroll = 0;
            if (VScrollBar.Visible)
                offsetScroll = VScrollBar.Value;

            // Startup compute location and size of menubar.
            int yPos = 0;
            for (int i = 0; i < MenuBars.Count; i++)
            {
                MenuBar bar = MenuBars[i];                
                int height = bar.GetRowHeight(ClientRectangle.Width, DrawingState.Normal) + (MenuBar.C_TEXT_TOP_BOTTOM_MARGIN * 2); // add padding on Top and Bottom by 2px                

                bar.Location = new Point(0, yPos - offsetScroll);
                bar.Size = new Size(ClientRectangle.Width, height);

                yPos += bar.Size.Height + 1;
                if (bar.State == MenuBar.EState.Collapsed)
                {                    
                    continue;
                }

                // In case of bar has state is equal "Expand". So at any time must has one menu bar selected ** Only **
                //if (bar.ImageBufferMenuItems != null) {
                    //yPos += bar.ImageBufferMenuItems.Height;                    
                //}

                if (bar.MenuItems.Count > 0)
                {
                    yPos += bar.GetMenuItemsContentHeight();
                }
            }

            // Decision to visible scrollbar.
            if (calcScroll)
            {
                if (yPos > this.Height)
                {
                    VScrollBar.Visible = true;                    
                }
                else
                {                    
                    if (VScrollBar.Visible)
                        VScrollBar.Visible = false;

                    VScrollBar.Value = 0;
                }
                RecalculateLocationAndSize(false);
                UpdateScrollBar();
                RecalculateLocationAndSize(false);
            }


        }
        #endregion

        private void SetMenuBarSelected(MenuBar bar) {
            if (m_menuBarSelected != null)
            {
                m_menuBarSelected.Collapse();
                m_menuBarSelected = null;
            }

            if (bar != null) {
                m_menuBarSelected = bar;
                m_menuBarSelected.Expand();

                OnMenuBarSelectedChange(bar);
            }
        }
        #endregion
    }
}
