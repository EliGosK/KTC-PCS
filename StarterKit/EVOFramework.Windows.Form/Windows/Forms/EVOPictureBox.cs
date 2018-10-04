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
    public partial class EVOPictureBox : PictureBox, IUIDataModelSupport
    {
        public EVOPictureBox()
        {
            InitializeComponent();
        }

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
        [Description("Specifiy path value of variable's property. style: [PropertyName][NestedPropertyName, ...].[ResultPropertyName]. Example: UserDomain.Username.Value")]
        public string PathString { get; set; }

        /// <summary>
        /// Get or set raw value.
        /// </summary>
        [Browsable(false)]
        public object PathValue
        {
            get
            {
                return Image;
            }
            set
            {
                if (value == null) {
                    Image = null;
                    return;
                }

                if (value is Image) {
                    Image = (Image)value;
                }                
            }
        }

        #endregion
    }
}
