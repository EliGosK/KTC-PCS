using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Windows.Forms;
using System.Windows.Forms;
using System.Data;


namespace Rubik.UserControl
{
    public class LocationTextBox : EVOTextBox
    {
        public LocationType LocationType { get; set; }
        public EVOTextBox DescriptionTextBox { get; set; }
        public EVOButton HelpButton { get; set; }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // LocationTextBox
            // 
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LocationTextBox_KeyPress);
            this.ResumeLayout(false);

        }

        private void LocationTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (true)
                {
                    DescriptionTextBox.Text = "";
                }
                //else
                //{
                //    DescriptionTextBox.Text = string.Empty;
                //}
            }
        }
    }

    public enum LocationType
    {
        Store,
        Production,
        Vendor,
        Customer
    }


}
