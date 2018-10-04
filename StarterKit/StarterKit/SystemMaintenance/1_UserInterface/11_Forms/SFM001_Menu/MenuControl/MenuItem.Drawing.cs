using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace SystemMaintenance.Forms
{
    partial class MenuItem
    {
        internal void DrawMenuItem(Graphics g, bool isHover) {
            Rectangle imageRectangle;
            Rectangle textRectangle;
            GetImageAndTextRectangle(out imageRectangle, out textRectangle);

            // Adjust to relative with Parent on axis-Y.
            imageRectangle.Offset(0, Parent.ClientRectangle.Bottom);
            textRectangle.Offset(0, Parent.ClientRectangle.Bottom);

            // Draw Image
            if (Image != null) {
                g.DrawImage(Image, imageRectangle.X, imageRectangle.Y, Image.Width, Image.Height );
            }

            // Draw Text            
            if (Text != null && Text.Trim() != "") {
                //Rectangle textRectangle = this.ClientRectangle;
                //textRectangle.X = C_IMAGE_LEFT_MARGIN + ((Image == null) ? 0 : Image.Width) + C_SPACE_BETWEEN_IMAGE_AND_TEXT;
                //textRectangle.Width = this.ClientRectangle.Width - (textRectangle.X + C_TEXT_RIGHT_MARGIN);

                TextFormatFlags flags = GetTextFormatFlags();
                if (isHover) {
                    TextRenderer.DrawText(g, this.Text, Appearance.Font, textRectangle, Appearance.FontHoverColor, flags);
                } else {
                    TextRenderer.DrawText(g, this.Text, Appearance.Font, textRectangle, Appearance.FontColor, flags);
                }
            }
        }
    }
}
