using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace EVOFramework.Windows.Forms
{
    public partial class AppearanceComponent : Component
    {
        #region Constructor
        public AppearanceComponent()
        {
            InitializeComponent();
        }

        public AppearanceComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        #endregion
    }
}
