using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace EVOFramework.Windows.Forms
{
    public partial class EVOCheckBox : CheckBox, IUIDataModelSupport, IAppearance
    {
        #region Variables

        private string m_appearanceName = string.Empty;

        #endregion

        #region Constructor
        public EVOCheckBox()
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
        public string AppearanceName
        {
            get { return m_appearanceName; }
            set { m_appearanceName = value; }
        }

        #endregion

        #region IControlIdentify Members

        /// <summary>
        /// Represents control's identify. It should be unique.
        /// It references multilanguage and mapping owner error.
        /// </summary>
        [Browsable(true)]
        public string ControlID { get; set; }

        #endregion

        #region IControlFocusable Members

        /// <summary>
        /// Focus on current control
        /// </summary>
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
        /// Assign value.
        /// </summary>
        [Browsable(false)]
        public object PathValue
        {
            get
            {
                return this.Checked;
            }
            set
            {
                if (value == null)
                {
                    this.Checked = false;
                    return;
                }                

                if (value is bool)
                {
                    this.Checked = Convert.ToBoolean(value);
                    return;
                }
                if (value is int ||value is decimal ||value is double)
                {
                    int i = Convert.ToInt32(value);
                    if (i <= 0)
                    {
                        this.Checked = false;
                        return;
                    }
                    this.Checked = true;
                    return;
                }
                if (value is string)
                {
                    string str = Convert.ToString(value);
                    if (str.ToLower() == "yes" || str.ToLower() == "y" || str.ToLower() == "true")
                    {
                        this.Checked = true;
                        return;
                    }
                    else
                    {
                        this.Checked = false;
                        return;
                    }
                }

                //if (bool.TryParse(value.ToString(), out result))
                //    this.Checked = result;
                //else {
                //    this.Checked = false;
                //}

            }
        }


        /// <summary>
        /// Get or set CheckedValue value.
        /// </summary>
        [Browsable(true)]
        [Description("Constant of checked value")]
        public string CheckedValue { get; set; }

        /// <summary>
        /// Get or set UnCheckedValue value.
        /// </summary>
        [Browsable(true)]
        [Description("Constant of Unchecked value")]
        public string UnCheckedValue { get; set; }
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
