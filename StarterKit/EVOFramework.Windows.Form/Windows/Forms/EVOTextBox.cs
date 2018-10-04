using System.ComponentModel;
using System.Windows.Forms;
using System;
using System.Drawing;

namespace EVOFramework.Windows.Forms
{
    public partial class EVOTextBox : TextBox, IUIDataModelSupport, IAppearance, IReadOnlyAppearance
    {
        #region Variables
        private string m_appearanceName = string.Empty;
        private string m_appearanceReadOnlyName = string.Empty;


        #endregion

        #region Constructor
        public EVOTextBox()
        {
            InitializeComponent();
        }
        #endregion

        #region Overriden method


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

        [Browsable(true)]
        [Description("Specifiy Button that will be HELP BUTTON")]
        public EVOButton HelpButton { get; set; }

        [Browsable(true)]
        [Description("Allow user to input unsearchable character")]
        public bool DisableRestrictChar { get; set; }
        #endregion

        #region To Value
        /// <summary>
        /// Return self NZString with owner object.
        /// </summary>
        /// <returns></returns>
        public NZString ToNZString()
        {
            return new NZString(this, this.Text);
        }
        #endregion

        #region Control Event
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (HelpButton != null && HelpButton.Enabled && e.KeyCode == Keys.F5)
            {
                HelpButton.PerformClick();
            }
        }

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

        /// <summary>
        /// This Event for protect case "Copy and Paste" string
        /// that may be contain some character that cannot input to search box
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTextChanged(EventArgs e)
        {           
            if (DisableRestrictChar)
            {
                char[] RestrictChars = new[] { '\'', '"', '[', ']', '%', '&', '*' };
           
                for (int j = 0; j < RestrictChars.Length; j++)
                {
                    Text = Text.Replace(RestrictChars[j].ToString(), string.Empty);
                }
            }
            base.OnTextChanged(e);
        }

        /// <summary>
        /// Set restrict key that can input to textbox. Some character are not allow to input.
        /// How to use : Bind this event to Textbox.keypress event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (DisableRestrictChar)
            {
                e.Handled = false;

                char[] RestrictChars = new[] { '\'', '"', '[', ']', '%', '&', '*' };

                for (int i = 0; i < RestrictChars.Length; i++)
                {
                    if (e.KeyChar == RestrictChars[i])
                    {
                        e.Handled = true;
                    }
                }
            }
        }
        #endregion



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
