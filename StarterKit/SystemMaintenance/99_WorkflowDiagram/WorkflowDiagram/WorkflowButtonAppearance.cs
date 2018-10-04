using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WorkFlowDiagram
{
    [Serializable()]
    public class WorkflowButtonAppearance
    {
        private Color m_backColor = Color.FromArgb(212, 208, 200);
        private Color m_borderColor = Color.FromArgb(128, 128, 128);
        private Color m_fontColor = Color.Black;
        private Font m_font = new Font("Microsoft sans serif", 7.75f, FontStyle.Bold);
        private int m_cornerRadius = 15;

        internal WorkflowButtonAppearance()
        {

        }

        public WorkflowButtonAppearance(Color borderColor, Font font, Color fontColor, int cornerRadius)
        {
            m_borderColor = borderColor;
            m_font = font;
            m_fontColor = fontColor;
            m_cornerRadius = cornerRadius;
        }

        public Color BorderColor
        {
            get { return m_borderColor; }
            set { m_borderColor = value; }
        }

        public Color FontColor
        {
            get { return m_fontColor; }
            set { m_fontColor = value; }
        }

        public int CornerRadius
        {
            get { return m_cornerRadius; }
            set { m_cornerRadius = value; }
        }

        public Font Font
        {
            get { return m_font; }
            set { m_font = value; }
        }

        public Color BackColor
        {
            get { return m_backColor; }
            set { m_backColor = value; }
        }
    }
}
