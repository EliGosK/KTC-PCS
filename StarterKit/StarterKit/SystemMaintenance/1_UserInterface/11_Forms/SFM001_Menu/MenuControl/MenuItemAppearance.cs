using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SystemMaintenance.Forms
{
    public class MenuItemAppearance
    {
        private Font m_font;
        private Color m_fontColor;
        private Color m_fontHoverColor;
        
        internal MenuItemAppearance()
        {
        }

        public MenuItemAppearance(Font font, Color fontColor)
        {
            m_font = font;
            m_fontColor = fontColor;
        }

        public Font Font
        {
            get { return m_font; }
            protected set { m_font = value; }
        }

        public Color FontColor
        {
            get { return m_fontColor; }
            protected set { m_fontColor = value; }
        }

        public Color FontHoverColor {
            get { return m_fontHoverColor; }
            set { m_fontHoverColor = value; }
        }
    }

    internal class DefaultMenuItemAppearance : MenuItemAppearance
    {
        public DefaultMenuItemAppearance()
        {
            this.Font = new Font("tahoma", 9.75f, FontStyle.Bold);
            this.FontColor = Color.FromArgb(100, 100, 100);
            this.FontHoverColor = Color.Blue;
        }
    }
}
