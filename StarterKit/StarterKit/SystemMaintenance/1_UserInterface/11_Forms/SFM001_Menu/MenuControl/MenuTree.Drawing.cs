using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SystemMaintenance.Forms
{
    

    partial class MenuTree
    {
        
        #region "  Overriden Paint  "
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (m_bBeginUpdateMenuBar)
                return;

            Graphics g = e.Graphics;            
            
            for (int i = 0; i < MenuBars.Count; i++ ) {
                MenuBar bar = MenuBars[i];
                if (bar.ClientRectangle.Y > this.Height)
                    return;

                // Compute area of menu bar.                
                if (bar == MenuBarSelected) {
                    bar.DrawMenuBar(g, DrawingState.Hot);
                } else if (bar == MenuBarHover) {
                    bar.DrawMenuBar(g, DrawingState.Over);
                } else {
                    bar.DrawMenuBar(g, DrawingState.Normal);    
                }
                                
                // Check if menubar has expanded ?
                if (bar.State == MenuBar.EState.Collapsed) {                    
                    continue;
                } else {
                    if (bar.MenuItems.Count > 0) {
                        bar.DrawMenuItems(g, MenuItemHover);
                    }
                }
                
                                
            }
                
        }
        #endregion
        

    }
}
