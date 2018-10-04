using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EVOFramework.Windows.Forms
{
    /// <summary>
    /// Implement this interface to support control change text lanuguage.
    /// </summary>
    public interface ILanguageChangable
    {
        /// <summary>
        /// Indicates this control can change language.
        /// </summary>
        bool CanChangeLanguage { get; set; }

        /// <summary>
        /// If this control can change langauge, it will be called when system has change mutlilanguage.
        /// If it can't change language, it should be return method.
        /// </summary>
        void ChangeLanguage();
    }
}
