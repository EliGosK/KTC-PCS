using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace EVOFramework.Windows.Forms
{
    public partial class EVOButton : Button, IControlIdentify, IAppearance
    {
        #region Variables

        private string m_appearanceName = string.Empty;

        #endregion

        #region Constructor
        public EVOButton()
        {
            InitializeComponent();
        }
        #endregion

        #region Overriden method
 
        #endregion

        #region Private method
        private void UpdateAppearance(Appearance appearance)
        {
            if (appearance == null)
                return;

            FontStyle fontStyle = appearance.FontStyle;

            Font font = new Font(appearance.FontName, appearance.FontSize, fontStyle);
            this.Font = font;
            this.BackColor = appearance.BackColor;
            this.ForeColor = appearance.ForeColor;

            this.Invalidate(false);
        }
        #endregion

        #region Protected method
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NullReferenceException">Not found EVOForm host.</exception>
        protected AppearanceList GetUsingAppearance()
        {
            EVOForm form = (EVOForm)FindForm();
            if (form == null)
                throw new NullReferenceException("Not found EVOForm host.");

            if (form.AppearanceComponent != null)
            {
                return null;
            }

            return AppearanceManager.DefaultAppearanceSet;
        }

        #endregion

        #region Public method


        #endregion

        #region IAppearance Members
        /// <summary>
        /// Name of appearance to apply.
        /// </summary>
        [DefaultValue("Button")]
        public string AppearanceName
        {
            get { return m_appearanceName; }
            set { m_appearanceName = value; }
        }

        #endregion

        #region IControlIdentify Members
        private string m_controlID = String.Empty;

        /// <summary>
        /// Represents control's identify. It should be unique.
        /// It references multilanguage and mapping owner error.
        /// </summary>
        [Browsable(true)]
        public string ControlID { get; set; }

        /// <summary>
        /// Focus on current control
        /// </summary>
        public void FocusOnControl() {
            if (this.CanFocus)
                this.Focus();
        }

        #endregion

        #region Implementation of IAppearanceUpdatable

        /// <summary>
        /// Invalidate appearance.
        /// </summary>
        public void InvalidateAppearance() {
            if (AppearanceName.Trim() == string.Empty)
            {
                return;
            }

            AppearanceList appearanceList = GetUsingAppearance();

            try
            {
                Appearance appearance = appearanceList[AppearanceName];
                UpdateAppearance(appearance);
            }
            catch { }
        }

        #endregion
    }
}
