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

namespace SystemMaintenance.Forms
{
    [Serializable()]
    /// <summary>
    /// This class is used to represents appearance of MenuBar componenet which display on MenuTree viewer.
    /// </summary>
    public class MenuBarAppearance
    {
        #region " Variables "

        /// <summary>
        /// Font for all state.
        /// </summary>
        private Font m_font;
        /// <summary>
        /// Color of seperator line.
        /// </summary>
        private Color m_seperatorLineColor;

        #region "  Normal State  "
        
        /// <summary>
        /// Back color for normal state.
        /// </summary>
        private Color m_normalBackColor;
        /// <summary>
        /// Font color for normal state.
        /// </summary>
        private Color m_normalFontColor;
        /// <summary>
        /// Image display expanded state.
        /// </summary>
        private Image m_normalImageExpanded;
        /// <summary>
        /// Image display collapsed state.
        /// </summary>
        private Image m_normalImageCollapsed;
        #endregion

        #region " Over State "
        /// <summary>
        /// Back color for over state.
        /// </summary>
        private Color m_overBackColor;
        /// <summary>
        /// Font color for over state.
        /// </summary>
        private Color m_overFontColor;
        /// <summary>
        /// Image display expanded state.
        /// </summary>
        private Image m_overImageExpanded;
        /// <summary>
        /// Image display collapsed state.
        /// </summary>
        private Image m_overImageCollapsed;
        #endregion

        #region " Hot State "
        /// <summary>
        /// Back color for hot state.
        /// </summary>
        private Color m_hotBackColor;
        /// <summary>
        /// Font color for hot state.
        /// </summary>
        private Color m_hotFontColor;
        /// <summary>
        /// Image display expanded state.
        /// </summary>
        private Image m_hotImageExpanded;
        /// <summary>
        /// Image display collapsed state.
        /// </summary>
        private Image m_hotImageCollapsed;
        #endregion
       
        
        #endregion

        #region " Constructor "
        public MenuBarAppearance() {
        }
        #endregion

        #region " Properties "               



        /// <summary>
        /// Font for normal state.
        /// </summary>
        public Font Font {
            get { return m_font; }
            set { m_font = value; }
        }

        /// <summary>
        /// Back color for normal state.
        /// </summary>
        public Color NormalBackColor {
            get { return m_normalBackColor; }
            set { m_normalBackColor = value; }
        }

        /// <summary>
        /// Font color for normal state.
        /// </summary>
        public Color NormalFontColor {
            get { return m_normalFontColor; }
            set { m_normalFontColor = value; }
        }

        /// <summary>
        /// Image display expanded state.
        /// </summary>
        public Image NormalImageExpanded {
            get { return m_normalImageExpanded; }
            set { m_normalImageExpanded = value; }
        }

        /// <summary>
        /// Image display collapsed state.
        /// </summary>
        public Image NormalImageCollapsed {
            get { return m_normalImageCollapsed; }
            set { m_normalImageCollapsed = value; }
        }


        /// <summary>
        /// Back color for over state.
        /// </summary>
        public Color OverBackColor {
            get { return m_overBackColor; }
            set { m_overBackColor = value; }
        }

        /// <summary>
        /// Font color for over state.
        /// </summary>
        public Color OverFontColor {
            get { return m_overFontColor; }
            set { m_overFontColor = value; }
        }

        /// <summary>
        /// Image display expanded state.
        /// </summary>
        public Image OverImageExpanded {
            get { return m_overImageExpanded; }
            set { m_overImageExpanded = value; }
        }

        /// <summary>
        /// Image display collapsed state.
        /// </summary>
        public Image OverImageCollapsed {
            get { return m_overImageCollapsed; }
            set { m_overImageCollapsed = value; }
        }

        

        /// <summary>
        /// Color of seperator line.
        /// </summary>
        public Color SeperatorLineColor {
            get { return m_seperatorLineColor; }
            set { m_seperatorLineColor = value; }
        }

        /// <summary>
        /// Back color for hot state.
        /// </summary>
        public Color HotBackColor {
            get { return m_hotBackColor; }
            set { m_hotBackColor = value; }
        }

        /// <summary>
        /// Font color for hot state.
        /// </summary>
        public Color HotFontColor {
            get { return m_hotFontColor; }
            set { m_hotFontColor = value; }
        }

        /// <summary>
        /// Image display expanded state.
        /// </summary>
        public Image HotImageExpanded {
            get { return m_hotImageExpanded; }
            set { m_hotImageExpanded = value; }
        }

        /// <summary>
        /// Image display collapsed state.
        /// </summary>
        public Image HotImageCollapsed {
            get { return m_hotImageCollapsed; }
            set { m_hotImageCollapsed = value; }
        }

        #endregion
    }

    internal class DefautlMenuBarAppearance : MenuBarAppearance {
        public DefautlMenuBarAppearance()
        {
            this.Font = new Font("Tahoma", 10f, FontStyle.Bold);
            this.SeperatorLineColor = Color.FromArgb(0, 191, 192);

            this.NormalBackColor = Color.FromArgb(183, 244, 247);            
            this.NormalFontColor = Color.FromArgb(56, 183, 189);
            this.NormalImageCollapsed = Properties.Resources.MENU_IMAGE_COLLAPSE_STATE;
            this.NormalImageExpanded = Properties.Resources.MENU_IMAGE_EXPAND_STATE;

            this.OverBackColor = WorkFlowDiagram.HSBColor.ShiftBrighness(this.NormalBackColor, 100);
            this.OverFontColor = WorkFlowDiagram.HSBColor.ShiftBrighness(this.NormalFontColor, -50);
            this.OverImageCollapsed = this.NormalImageCollapsed;
            this.OverImageExpanded = this.NormalImageExpanded;

            this.HotBackColor = WorkFlowDiagram.HSBColor.ShiftBrighness(this.NormalBackColor, -20);
            this.HotFontColor = WorkFlowDiagram.HSBColor.ShiftBrighness(this.NormalFontColor, -50);
            this.HotImageCollapsed = this.NormalImageCollapsed;
            this.HotImageExpanded = this.NormalImageExpanded; 
        }
    }
}
