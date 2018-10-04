using System;
using System.ComponentModel;
using System.Drawing;

namespace EVOFramework.Windows.Forms
{
    [ToolboxItem(true)]
    public partial class EVODateTextBox : DateTextBox, IUIDataModelSupport, IAppearance, IReadOnlyAppearance
    {
        #region Variables
        // Appearance.
        private string m_appearanceName = string.Empty;
        private string m_appearanceReadOnlyName = string.Empty;
        #endregion

        #region Constructor
        public EVODateTextBox()
        {
            InitializeComponent();
        }
        #endregion

        #region Private method
        protected void UpdateAppearance(string appearanceName)
        {
            if (AppearanceName.Trim() == string.Empty)
            {
                return;
            }

            AppearanceList appearanceList = GetUsingAppearance();

            try
            {
                Appearance appearance = appearanceList[appearanceName];
                UpdateAppearance(appearance);
            }
            catch { }
        }

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
                return null;

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
        [DefaultValue("DataEdit")]
        public string AppearanceName
        {
            get { return m_appearanceName; }
            set { m_appearanceName = value; }
        }

        #endregion

        #region IReadOnlyAppearance Members

        /// <summary>
        /// Name of appearance to apply.
        /// </summary>
        [DefaultValue("DataReadOnly")]
        public string AppearanceReadOnlyName
        {
            get
            {
                return m_appearanceReadOnlyName;
            }
            set
            {
                m_appearanceReadOnlyName = value;
            }
        }

        #endregion

        #region IControlIdentify Members

        private string m_controlID = string.Empty;
        public string ControlID
        {
            get
            {
                return m_controlID;
            }
            set
            {
                m_controlID = value;
            }
        }

        public void FocusOnControl()
        {
            this.SelectAll();
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
        [Description("Specifiy path value of variable's property. style: [DomainName].[NestedPropertyName, ...].[ResultPropertyName]. Example: UserDomain.Username.Value")]
        public string PathString { get; set; }

        /// <summary>
        /// Get or set raw value.
        /// </summary>
        [Browsable(false)]
        public object PathValue
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value == null ? string.Empty : value.ToString();
            }
        }

        #endregion

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.TextBoxBase.ReadOnlyChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
        /// <exception cref="ApplicationException"><c>ApplicationException</c>.</exception>
        protected override void OnReadOnlyChanged(EventArgs e)
        {
            base.OnReadOnlyChanged(e);

            if (DesignMode)
                return;

            InvalidateAppearance();
        }

        #region Implementation of IAppearanceUpdatable

        /// <summary>
        /// Invalidate appearance.
        /// </summary>
        /// <exception cref="ApplicationException"><c>ApplicationException</c>.</exception>
        public void InvalidateAppearance()
        {
            if (AppearanceReadOnlyName == null || AppearanceReadOnlyName.Trim() == string.Empty)
            {
                return;
            }

            AppearanceList appearanceList = GetUsingAppearance();
            if (appearanceList == null || appearanceList.Count <= 0)
                return;

            Appearance apr = null;
            if (this.ReadOnly)
            {
                apr = appearanceList[AppearanceReadOnlyName];
            }
            else
            {
                apr = appearanceList[AppearanceName];
            }

            UpdateAppearance(apr);
        }

        #endregion
    }
}
