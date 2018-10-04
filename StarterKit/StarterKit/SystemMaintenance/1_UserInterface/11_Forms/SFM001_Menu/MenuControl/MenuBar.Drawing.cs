using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace SystemMaintenance.Forms
{
    partial class MenuBar
    {
        internal void DrawMenuBar(Graphics g, DrawingState state) {
            Image imgState = GetImageFromCurrentState(state);
            Rectangle textArea = Rectangle.Empty;

            switch (state)
            {
                case DrawingState.Normal:
                    #region
                    using (SolidBrush brush = new SolidBrush(Appearance.NormalBackColor))
                    {
                        g.FillRectangle(brush, ClientRectangle);
                    }

                    // Draw Image Collapse/Expand state.
                    g.DrawImageUnscaled(imgState, MenuBar.C_IMAGE_LEFT_MARGIN, Location.Y + (ClientRectangle.Height / 2) - (imgState.Height / 2) - 1);

                    // Draw Text
                    textArea = ClientRectangle;
                    textArea.X = MenuBar.C_IMAGE_LEFT_MARGIN + imgState.Width + MenuBar.C_SPACE_BETWEEN_IMAGE_AND_TEXT;
                    textArea.Width -= textArea.X + 2;

                    TextRenderer.DrawText(g,
                        Text,
                        Appearance.Font,
                        textArea,
                        Appearance.NormalFontColor,
                        GetTextFormatFlags());
                    #endregion
                    break;
                case DrawingState.Over:
                    #region
                    using (SolidBrush brush = new SolidBrush(Appearance.OverBackColor))
                    {
                        g.FillRectangle(brush, ClientRectangle);
                    }

                    // Draw Image Collapse/Expand state.
                    g.DrawImageUnscaled(imgState, MenuBar.C_IMAGE_LEFT_MARGIN, Location.Y + (ClientRectangle.Height / 2) - (imgState.Height / 2) - 1);

                    // Draw Text
                    textArea = ClientRectangle;
                    textArea.X = MenuBar.C_IMAGE_LEFT_MARGIN + imgState.Width + MenuBar.C_SPACE_BETWEEN_IMAGE_AND_TEXT;
                    textArea.Width -= textArea.X + 2;

                    TextRenderer.DrawText(g,
                        Text,
                        Appearance.Font,
                        textArea,
                        Appearance.OverFontColor,
                        GetTextFormatFlags());
                    #endregion
                    break;
                case DrawingState.Hot:
                    #region
                    using (SolidBrush brush = new SolidBrush(Appearance.HotBackColor))
                    {
                        g.FillRectangle(brush, ClientRectangle);
                    }

                    // Draw Image Collapse/Expand state.
                    g.DrawImageUnscaled(imgState, MenuBar.C_IMAGE_LEFT_MARGIN, Location.Y + (ClientRectangle.Height / 2) - (imgState.Height / 2) - 1);

                    // Draw Text
                    textArea = ClientRectangle;
                    textArea.X = MenuBar.C_IMAGE_LEFT_MARGIN + imgState.Width + MenuBar.C_SPACE_BETWEEN_IMAGE_AND_TEXT;
                    textArea.Width -= textArea.X + 2;

                    TextRenderer.DrawText(g,
                        Text,
                        Appearance.Font,
                        textArea,
                        Appearance.HotFontColor,
                        GetTextFormatFlags());
                    #endregion
                    break;
            }

            // Draw seperate line.
            if (this.State == EState.Collapsed) {
                Point ptFrom = new Point(C_SEPERATOR_LEFT_MARGIN, this.ClientRectangle.Bottom);
                Point ptTo = new Point(this.ClientRectangle.Right - C_SEPERATOR_RIGHT_MARGIN, this.ClientRectangle.Bottom);
                using (Pen pen = new Pen(Appearance.SeperatorLineColor)) {
                    g.DrawLine(pen, ptFrom, ptTo);    
                }
                
            }
        }

        /// <summary>
        /// Draw all menu items into surface.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="itemHover"></param>
        internal void DrawMenuItems(Graphics g, MenuItem itemHover) {
            // Clear surface prepare for drawing menu items.
            Rectangle rectangle = new Rectangle();
            rectangle.X = this.ClientRectangle.X;
            rectangle.Y = this.ClientRectangle.Bottom;
            rectangle.Width = this.ClientRectangle.Width;
            rectangle.Height = GetMenuItemsContentHeight();

            using (SolidBrush brush = new SolidBrush(Color.White)) {
                g.FillRectangle(brush, rectangle);    
            }

            // Draw gradient at right edge.
            Point ptFrom = new Point(rectangle.Width, rectangle.Y);
            Point ptTo = new Point(ptFrom.X - 50, rectangle.Y);
            using (LinearGradientBrush brush = new LinearGradientBrush(ptFrom, ptTo, Color.FromArgb(242, 242, 242), Color.White)) {
                g.FillRectangle(brush, ptTo.X + 1, rectangle.Y, 50, rectangle.Height);
            }
                            
            // Loop all menu item elements to paint.
            for (int i = 0; i < MenuItems.Count; i++) {
                MenuItem item = MenuItems[i];
                item.DrawMenuItem(g, item == itemHover);
            }
        }
    }
}
