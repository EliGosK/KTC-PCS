using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Cube.AFD.Windows.Controls.CalendarControls {
    public partial class DayEditorTest : DayEditor {
        public DayEditorTest() {
            InitializeComponent();
        }

        public override object Value {
            get {
                foreach (Control c in this.Controls) {
                    if (((RadioButton)c).Checked) {
                        return c.Text;
                    }
                }
                return string.Empty;
            }
            set {
                m_bIsValueChanged = false;
                foreach (Control c in this.Controls) {
                    if (c.Text == Convert.ToString(value)) {
                        ((RadioButton)c).Checked = true;
                        m_bIsValueChanged = true;
                        break;
                    }
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) {
            m_bIsValueChanged = true;
        }

        public override void PaintDay(Calendar calendar, Graphics g, MonthObject monthObj, DayObject dayObj) {
            base.PaintDay(calendar, g, monthObj, dayObj);
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            string v = this.Value.ToString();
            if (v == string.Empty) {
                v = "NONE";
            }
            g.DrawString(v, calendar.Font, Brushes.Blue, dayObj.ClientRectangle, sf);
        }

    }
}
