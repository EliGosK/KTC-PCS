using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace EVOFramework.Windows.Forms
{
    /// <summary>
    /// Interface to support control appearance.
    /// </summary>
    public interface IAppearance: IAppearanceUpdatable
    {

        /// <summary>
        /// Name of appearance to apply.
        /// </summary>
        [Browsable(true)]
        string AppearanceName { get; set; }
    }

    /// <summary>
    /// Interface to support readonly state control appearance.
    /// </summary>
    public interface IReadOnlyAppearance {
        /// <summary>
        /// Name of appearance to apply.
        /// </summary>
        [Browsable(true)]
        string AppearanceReadOnlyName { get; set; }
    }

    public interface IAppearanceUpdatable {
        /// <summary>
        /// Invalidate appearance.
        /// </summary>
        void InvalidateAppearance();
    }
}
