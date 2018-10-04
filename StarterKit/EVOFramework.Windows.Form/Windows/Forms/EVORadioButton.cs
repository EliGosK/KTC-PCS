using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EVOFramework.Windows.Forms
{
    public partial class EVORadioButton : RadioButton, IUIDataModelSupport, IAppearance
    {
        #region Variables

        private string m_appearanceName = string.Empty;

        #endregion

        #region Constructor

        public EVORadioButton()
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
        [DefaultValue("NormalText")]
        public string AppearanceName
        {
            get { return m_appearanceName; }
            set { m_appearanceName = value; }
        }

        #endregion

        #region IControlIdentify Members

        [Browsable(true)]
        public string ControlID { get; set; }

        #endregion

        #region IControlFocusable Members

        public void FocusOnControl()
        {
            this.Focus();
        }

        #endregion

        #region IDomainSupport Members

        /// <summary>
        /// Specifiy path value of variable's property.
        /// <para>style: [DomainName].[NestedPropertyName, ...].[ResultPropertyName]</para>
        /// <para>example: UserDomain.Username.Value</para>
        /// </summary>
        [Browsable(true)]
        public string PathString { get; set; }

        /// <summary>
        /// Assign path value.
        /// </summary>
        [Browsable(false)]
        [Obsolete("Not used, should be use SpecificValue property.")]
        object IUIDataModelSupport.PathValue { get; set; }

        /// <summary>
        /// Get or set specific value.
        /// </summary>
        [Browsable(true)]
        [Description("Constant of radiobutton")]
        public string SpecificValue { get; set; }
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
