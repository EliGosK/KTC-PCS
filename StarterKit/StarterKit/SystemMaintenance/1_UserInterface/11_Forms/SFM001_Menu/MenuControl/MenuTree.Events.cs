using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemMaintenance.Forms
{
    partial class MenuTree
    {
        #region " Event & Delegate "        
        public delegate void MenuBarClickHandler(object sender, MenuBar bar);
        public delegate void MenuItemClickHandler(object sender, MenuItem item);

        public delegate void MenuItemDownHandler(object sender, MenuItem item, System.Windows.Forms.MouseEventArgs e);

        /// <summary>
        /// Occurs when menu bar has change selected.
        /// </summary>
        public event MenuBarClickHandler MenuBarSelectedChange;
        /// <summary>
        /// Occurs when mouse click on MenuBar.
        /// </summary>
        public event MenuBarClickHandler MenuBarClick;
        /// <summary>
        /// Occurs when mouse click on MenuItem.
        /// </summary>
        public event MenuItemClickHandler MenuItemClick;

        /// <summary>
        /// Occurs when mouse down over on menu item.
        /// </summary>
        public event MenuItemDownHandler MenuItemDown;

        

        public event MenuItemClickHandler MenuItemMouseOver;
        #endregion

        #region " Raise event "
        protected void OnMenuBarSelectedChange(MenuBar bar) {
            if (MenuBarSelectedChange != null) {
                MenuBarSelectedChange(this, bar);
            }
        }
        protected void OnMenuBarClick(MenuBar bar) {
            if (MenuBarClick != null) {
                MenuBarClick(this, bar);
            }
        }

        protected void OnMenuItemClick(MenuItem item) {
            if (MenuItemClick != null) {
                MenuItemClick(this, item);
            }
        }

        protected void OnMenuItemMouseOver(MenuItem item) {
            if (MenuItemMouseOver != null) {
                MenuItemMouseOver(this, item);
            }
        }

        protected void OnMenuItemDown(MenuItem item, System.Windows.Forms.MouseEventArgs e)
        {
            MenuItemDownHandler handler = MenuItemDown;
            if (handler != null)
            {
                handler(this, item, e);
            }
        }
        #endregion

        #region " Variable and Properties "
        /// <summary>
        /// Store current menu bar that mouse is hover.
        /// </summary>
        private MenuBar m_menuBarHover = null;
        /// <summary>
        /// Store current menu item that mouse is hover.
        /// </summary>
        private MenuItem m_menuItemHover = null;

        /// <summary>
        /// Store current menu bar that mouse is hover.
        /// </summary>
        private MenuBar MenuBarHover {
            get { return m_menuBarHover; }
            set { m_menuBarHover = value; }
        }

        /// <summary>
        /// Store current menu item that mouse is hover.
        /// </summary>
        private MenuItem MenuItemHover {
            get { return m_menuItemHover; }
            set { m_menuItemHover = value; }
        }

        #endregion

        #region " Overriden Mouse event "
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            
            if (MenuItemHover != null)
            {
                OnMenuItemDown(MenuItemHover, e);
            }
        }
        protected override void OnMouseClick(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (MenuBarHover != null) {                
                if (MenuBarHover.State == MenuBar.EState.Expanded) {                    
                    MenuBarSelected = null;
                }
                else
                {
                    MenuBarSelected = MenuBarHover;
                }

                OnMenuBarSelectedChange(MenuBarSelected);
                OnMenuBarClick(MenuBarHover);
            }

            if (MenuItemHover != null) {
                OnMenuItemClick(MenuItemHover);
            }
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e) {
            base.OnMouseMove(e);

            MenuBar bar = null;
            for (int i = 0; i < MenuBars.Count; i++) {

                MenuBar barTemp = MenuBars[i];
                // Check mouse is over on bar or menu items.
                if (barTemp.ContainsBarOrItemContent(e.Location))
                {
                    bar = barTemp;
                    break;
                }
            }

            // if found bar and item area that mouse is live.
            if (bar != null) {

                if (bar.ContainsBar(e.Location)) {
                    // if mouse is over on MenuBar.

                    #region " Check Mouse is over on MenuBar "
                    if (MenuItemHover != null) {
                        MenuItemHover = null;
                    }

                    // If old and current of menu bar are not equal.
                    if (MenuBarHover != bar) {

                        // Change menu bar hover to new value.
                        MenuBarHover = bar;                        
                    }

                    #endregion
                }
                else {
                    // if mouse is over on MenuItem element of MenuBar.

                    #region " Check Mouse is over on MenuItem element of MenuBar "

                    // Clear menu bar hover.
                    if (MenuBarHover != null) {
                        MenuBarHover = null;
                    }

                    if (bar.State == MenuBar.EState.Expanded) {
                        // find menu item that mouse is over.
                        MenuItem tempItem = null;
                        for (int iMenuItem = 0; iMenuItem < bar.MenuItems.Count; iMenuItem++) {
                            MenuItem item = bar.MenuItems[iMenuItem];
                            if (item.Contains(e.Location)) {
                                tempItem = item;
                                break;
                            }
                        }
                        MenuItemHover = tempItem;

                        //Raise event MenuItem mouse over.
                        OnMenuItemMouseOver(MenuItemHover);

                    } else {
                        MenuItemHover = null;                        
                    }
                    
                    #endregion
                }          
            } else {
                if (MenuBarHover != null)
                    MenuBarHover = null;

                if (MenuItemHover != null) {
                    MenuItemHover = null;
                }
            }


            

            this.Invalidate();            
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (MenuBarHover != null) {
                MenuBarHover = null;                
            }

            if (MenuItemHover != null) {
                MenuItemHover = null;
            }

            this.Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
        }
        #endregion

    }
}
