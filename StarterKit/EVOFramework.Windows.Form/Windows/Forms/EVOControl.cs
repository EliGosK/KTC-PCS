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
    /// <summary>
    /// Represent base control.
    /// </summary>
    public partial class EVOControl : Control, IControlIdentify
    {
        public EVOControl()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);                        
        }

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
            if (this.CanFocus)
                this.Focus();
        }

        #endregion
    }
}
