using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EVOFramework.Windows.Forms
{
    /// <summary>
    /// Empty control identify class.
    /// </summary>
    public class EmptyControlIdentify : IControlIdentify
    {
        public EmptyControlIdentify(string controlID) {
            ControlID = controlID;
        }

        #region IControlIdentify Members

        /// <summary>
        /// Represents control's identify. It should be unique.
        /// It references multilanguage and mapping owner error.
        /// </summary>
        public string ControlID { get; set; }

        /// <summary>
        /// Focus on current control
        /// </summary>
        public void FocusOnControl()
        {
            
        }

        #endregion
    }
}
