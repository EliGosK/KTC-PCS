using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.Drawing.Drawing2D;


namespace Cube.AFD.Windows.Controls.CalendarControls {
    internal partial class CalendarLayoutControl : UserControl {
        public CalendarLayoutControl() {
            InitializeComponent();

            cboLayout.Items.Clear();
            cboLayout.Items.Add(CalendarLayout.LayoutType.One.ToString());
            cboLayout.Items.Add(CalendarLayout.LayoutType.TwoRight.ToString());
            cboLayout.Items.Add(CalendarLayout.LayoutType.TwoDown.ToString());
            cboLayout.Items.Add(CalendarLayout.LayoutType.ThreeRight.ToString());
            cboLayout.Items.Add(CalendarLayout.LayoutType.ThreeDown.ToString());
            cboLayout.Items.Add(CalendarLayout.LayoutType.ThreeMerge.ToString());
            cboLayout.Items.Add(CalendarLayout.LayoutType.Four.ToString());
            cboLayout.Items.Add(CalendarLayout.LayoutType.Five.ToString());
            cboLayout.Items.Add(CalendarLayout.LayoutType.SixRight.ToString());
            cboLayout.Items.Add(CalendarLayout.LayoutType.SixDown.ToString());
            cboLayout.Items.Add(CalendarLayout.LayoutType.EightRight.ToString());
            cboLayout.Items.Add(CalendarLayout.LayoutType.EightDown.ToString());
            cboLayout.Items.Add(CalendarLayout.LayoutType.TwelveRight.ToString());
            cboLayout.Items.Add(CalendarLayout.LayoutType.TwelveDown.ToString());
            cboLayout.Text = CalendarLayout.LayoutType.One.ToString();
        }

        private void CalendarLayoutControl_Load(object sender, EventArgs e) {

        }

        public CalendarLayout.LayoutType LayoutType {
            get {
                return (CalendarLayout.LayoutType)Enum.Parse(typeof(CalendarLayout.LayoutType), cboLayout.Text);
            }
            set {
                string s = value.ToString();
                int index = cboLayout.FindStringExact(s);
                cboLayout.SelectedIndex = index;
            }
        }


        private void cboLayout_SelectedIndexChanged(object sender, EventArgs e) {
            panelPreview.Invalidate();
        }


        private void panelPreview_Paint(object sender, PaintEventArgs e) {
            try {
                if (cboLayout.Text.Trim() == string.Empty) {
                    base.OnPaint(e);
                } else {
                    CalendarLayout.LayoutType type = (CalendarLayout.LayoutType)Enum.Parse(typeof(CalendarLayout.LayoutType), cboLayout.Text);
                    CalendarLayout l = new CalendarLayout(type);
                    MonthObject[] months = l.GetMonthObject(null, panelPreview.ClientRectangle, 0, DateTime.Today.Year, DateTime.Today.Month, null, null);
                    Pen p = Pens.Blue;
                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    int iCount = 1;
                    Brush br = Brushes.Black;
                    foreach (MonthObject m in months) {
                        e.Graphics.DrawLines(p, m.PointAroundRect);
                        e.Graphics.DrawString(iCount.ToString(), this.Font, br, m.ClientRectangle, sf);
                        iCount++;
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }
    }

    internal partial class CalendarLayoutEditor : UITypeEditor {
        public CalendarLayoutEditor() {

        }
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) {
            
            return UITypeEditorEditStyle.DropDown;
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) {
            IWindowsFormsEditorService srv = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (srv == null)
                return null;

            CalendarLayoutControl control = new CalendarLayoutControl();
            control.LayoutType = (CalendarLayout.LayoutType)value;
            srv.DropDownControl(control);

            CalendarLayout.LayoutType ret = control.LayoutType;
            srv.CloseDropDown();
            control.Dispose();
            return ret;
        }
        //public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) {
            
        //    IWindowsFormsEditorService frmsrv = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
        //    if (frmsrv == null)
        //        return null;
        //    CalendarLayout layout = CalendarLayout.Five ;
            
        //    try {
        //        MessageBox.Show(value.GetType().Name);
        //        layout = (CalendarLayout)value;
        //    } catch (Exception ex) {
        //        MessageBox.Show(ex.ToString());
        //    }

        //    CalendarLayoutControl control = new CalendarLayoutControl();
        //    control.LayoutType = layout.Layout;
        //    frmsrv.DropDownControl(control);

        //    //value = (object)new CalendarLayout(control.LayoutType);
        //    layout = new CalendarLayout(control.LayoutType);
        //    value = layout;
        //    frmsrv.CloseDropDown();
        //    control.Dispose();
            
        //    return value;
        //}
    }

}
