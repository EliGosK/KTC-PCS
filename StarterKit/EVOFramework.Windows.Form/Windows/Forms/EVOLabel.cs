using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace EVOFramework.Windows.Forms
{
    public partial class EVOLabel : Label, IAppearance, IUIDataModelSupport
    {
        #region Variables

        private string m_appearanceName = string.Empty;

        #endregion

        #region Constructor
        public EVOLabel()
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
        [Browsable(true)]
        [DefaultValue("NormalText")]
        public string AppearanceName
        {
            get { return m_appearanceName; }
            set { m_appearanceName = value; }
        }

        #endregion

        #region Implementation of IAppearanceUpdatable

        /// <summary>
        /// Invalidate appearance.
        /// </summary>
        public void InvalidateAppearance()
        {
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
    }
}
