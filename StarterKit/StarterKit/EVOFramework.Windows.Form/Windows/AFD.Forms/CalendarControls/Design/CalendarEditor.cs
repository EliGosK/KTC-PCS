using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cube.AFD.Windows.Controls.CalendarControls.Design {
    public partial class CalendarEditor : Form {

        private const string MIT_OVERALL = "Overall";
        private const string MIT_CELANDAR_HEADER = "Calendar Header";
        private const string MIT_WEEK_HEADER = "Week Header";
        private const string MIT_DAY_STYLE = "Day Style";
        private const string MIT_DAY_NORMAL = "Normal Day";
        private const string MIT_DAY_INACTIVE = "Inactive Day";
        private const string MIT_DAY_SELECTED = "Selected Day";
        private const string MIT_DAY_ACTIVE = "Active Day";
        private const string MIT_DAY_TODAY = "Today Day";

        private const string STYLE_CUSTOM = "-- Custom --";
        private const string STYLE_COOL_EYE = "Cool Eye";
        private const string STYLE_BLUE_WHITE = "Blue White";
        private const string STYLE_PIG_BLOOD = "Pig Blood";
        private const string STYLE_PIG_BLLOD2 = "Pig Blood2";
        private const string STYLE_PINK_SMOOTH = "Pink Smooth";


        private CalendarStyle m_style = new CalendarStyle();
        private IDesigner m_designer = null;
        private Calendar m_calendar = null;

        public CalendarEditor(IDesigner designer, CalendarStyle style, Calendar calendar) {
            InitializeComponent();
            m_designer = designer;
            m_style = style;
            trevStyle.ExpandAll();
            m_calendar = calendar;
            propertyGrid1.SelectedObject = null;

            cboTheme.Items.Clear();
            cboTheme.Items.Add(STYLE_CUSTOM);
            cboTheme.Items.Add(STYLE_COOL_EYE);
            cboTheme.Items.Add(STYLE_BLUE_WHITE);
            cboTheme.Items.Add(STYLE_PIG_BLOOD);
            cboTheme.Items.Add(STYLE_PIG_BLLOD2);
            cboTheme.Items.Add(STYLE_PINK_SMOOTH);
            
            cboTheme.Text = STYLE_CUSTOM;

            // Calendar Type
            switch (calendar.CalendarType) {
                case CalendarType.Region: rdCRegion.Checked = true; break;
                case CalendarType.Gregorian: rdCGregorian.Checked = true; break;
                case CalendarType.ThaiBuddhist: rdCThaiBuddhist.Checked = true; break;
            }

            // Calendar View
            calendarLayoutControl1.LayoutType = m_calendar.CalendarView;

            // Show Checked Box
            if (calendar.ShowCheckBox) {
                rdYes.Checked = true;
            } else {
                rdNo.Checked = true;
            }

            // Selection Policy
            switch (calendar.SelectionPolicy) {
                case SelectionPolicy.Continuous: rdSContinuous.Checked = true; break;
                case SelectionPolicy.Single: rdSSingle.Checked = true; break;
                case SelectionPolicy.Merge: rdSMerge.Checked = true; break;
            }

            // Editor Control
            txtEditorTypeName.Text = calendar.EditorControlType == null ? string.Empty : calendar.EditorControlType.FullName;
            // Editor Mode
            switch (calendar.EditorMode) {
                case EditorMode.Alway: rdMAlway.Checked = true; break;
                case EditorMode.DisplayWhenEdit: rdMDisplayWhenEdit.Checked = true; break;
            }
            // Editor View
            switch (calendar.EditorView) {
                case EditorView.Default: rdVDefault.Checked = true; break;
                case EditorView.ForeControl: rdVForeControl.Checked = true; break;
                case EditorView.OwnerDraw: rdVOwnerDraw.Checked = true; break;
            }
            // Editor When
            chkDoubleClick.Checked =(( calendar.EditorWhen & EditorWhen.DoubleClick) == EditorWhen.DoubleClick);
            chkPressEnter.Checked = ((calendar.EditorWhen & EditorWhen.Enter )== EditorWhen.Enter);
            chkPressF2.Checked = ((calendar.EditorWhen & EditorWhen.F2) == EditorWhen.F2);
        }

        private void FillMonthItem() {
            trevStyle.Nodes.Clear();
            trevStyle.Nodes.Add(MIT_OVERALL);
            trevStyle.Nodes.Add(MIT_CELANDAR_HEADER);
            trevStyle.Nodes.Add(MIT_WEEK_HEADER);
            trevStyle.Nodes.Add(MIT_DAY_STYLE);
            TreeNode node = trevStyle.Nodes[trevStyle.Nodes.Count - 1];
            node.Nodes.Add(MIT_DAY_NORMAL);
            node.Nodes.Add(MIT_DAY_INACTIVE);
            node.Nodes.Add(MIT_DAY_SELECTED);
            node.Nodes.Add(MIT_DAY_ACTIVE);
            node.Nodes.Add(MIT_DAY_TODAY);
            trevStyle.ExpandAll();
        }

        private void CalendarEditor_Load(object sender, EventArgs e) {
            FillMonthItem();
        }

        public Type EditorControlType{
            get {
                return (Type)txtEditorTypeName.Tag;
                //if (txtEditorTypeName.Text == null)
                //    return string.Empty;
                //else
                //    return txtEditorTypeName.Text.Trim();
                //Type t = Type.GetType(txtEditorTypeName.Text.Trim());
                //if (t == null)
                //    return null;
                //if (t.IsSubclassOf(typeof(DayEditor))) {
                //    return t;
                //} else {
                //    return null;
                //}

                //Type tif = t.GetInterface("IEditorControl");
                //if (tif == null)
                //    return null;

                //return t;
            }
        }

        public EditorWhen EditorWhen {
            get {
                if (chkDoubleClick.Checked == false && chkPressEnter.Checked == false && chkPressF2.Checked == false)
                    return EditorWhen.None;
                else {
                    EditorWhen flg = 0;
                    if (chkDoubleClick.Checked)
                        flg |= EditorWhen.DoubleClick;
                    if (chkPressEnter.Checked)
                        flg |= EditorWhen.Enter;
                    if (chkPressF2.Checked)
                        flg |= EditorWhen.F2;
                    return flg;
                }
            }
        }

        public EditorMode EditorMode {
            get {
                if (rdMAlway.Checked)
                    return EditorMode.Alway;
                else
                    return EditorMode.DisplayWhenEdit;
            }
        }

        public EditorView EditorView {
            get {
                if (rdVOwnerDraw.Checked)
                    return EditorView.OwnerDraw;
                else if (rdVForeControl.Checked)
                    return EditorView.ForeControl;
                else
                    return EditorView.Default;
            }
        }

        public SelectionPolicy SelectionPolicy {
            get {
                if (rdSContinuous.Checked)
                    return SelectionPolicy.Continuous;
                else if (rdSMerge.Checked)
                    return SelectionPolicy.Merge;
                else
                    return SelectionPolicy.Single;
            }
        }

        public bool ShowCheckBox {
            get {
                if (rdYes.Checked)
                    return true;
                else
                    return false;
            }
        }

        public CalendarStyle CalendarStyle {
            get {
                return m_style;
            }
            set {
                m_style = value;
            }
        }

        public CalendarLayout.LayoutType CalendarView {
            get {
                return calendarLayoutControl1.LayoutType;
            }
        }

        public CalendarType CalendarType {
            get {
                if (rdCThaiBuddhist.Checked)
                    return CalendarType.ThaiBuddhist;
                else if (rdCGregorian.Checked)
                    return CalendarType.Gregorian;
                else
                    return CalendarType.Region;
            }
        }

        private void SetPropertyObject(string itemText) {
            switch (itemText) {
                case MIT_OVERALL:
                    propertyGrid1.SelectedObject = m_style;
                    break;
                case MIT_CELANDAR_HEADER:
                    propertyGrid1.SelectedObject = m_style.CalendarHeader;
                    break;
                case MIT_WEEK_HEADER:
                    propertyGrid1.SelectedObject = m_style.WeekHeader;
                    break;
                case MIT_DAY_STYLE:
                    propertyGrid1.SelectedObject = m_style.DayStyle;
                    break;
                case MIT_DAY_NORMAL:
                    propertyGrid1.SelectedObject = m_style.DayStyle.NormalDay;
                    break;
                case MIT_DAY_INACTIVE:
                    propertyGrid1.SelectedObject = m_style.DayStyle.InactiveDay;
                    break;
                case MIT_DAY_SELECTED:
                    propertyGrid1.SelectedObject = m_style.DayStyle.SelectionDay;
                    break;
                case MIT_DAY_ACTIVE:
                    propertyGrid1.SelectedObject = m_style.DayStyle.ActiveDay;
                    break;
                case MIT_DAY_TODAY:
                    propertyGrid1.SelectedObject = m_style.DayStyle.TodayDay;
                    break;
            }
        }

        private void trevStyle_AfterSelect(object sender, TreeViewEventArgs e) {
            try {
                if (e.Node != null) {
                    SetPropertyObject(e.Node.Text);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e) {
            m_calendar.InvalidateAll();
            cboTheme.Text = STYLE_CUSTOM;
        }

        private void cboTheme_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                string text = cboTheme.Text;
                switch (text) {
                    case STYLE_BLUE_WHITE:
                        m_style = Cube.AFD.Windows.Controls.CalendarControls.CalendarStyle.BlueWhite;
                        break;
                    case STYLE_COOL_EYE:
                        m_style = Cube.AFD.Windows.Controls.CalendarControls.CalendarStyle.CoolEye;
                        break;
                    case STYLE_PIG_BLOOD:
                        m_style = Cube.AFD.Windows.Controls.CalendarControls.CalendarStyle.PigBlood;
                        break;
                    case STYLE_PIG_BLLOD2:
                        m_style = Cube.AFD.Windows.Controls.CalendarControls.CalendarStyle.PigBlood2;
                        break;
                    case STYLE_PINK_SMOOTH:
                        m_style = Cube.AFD.Windows.Controls.CalendarControls.CalendarStyle.PinkSmooth;
                        break;
                }
                if (trevStyle.SelectedNode != null) {
                    SetPropertyObject(trevStyle.SelectedNode.Text);
                }
                m_calendar.InvalidateAll();
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnApply_Click(object sender, EventArgs e) {
            m_calendar.InvalidateAll();
        }

        private void btnSelectEditor_Click(object sender, EventArgs e) {
            this.Cursor = Cursors.WaitCursor;
            try {
                EditorControlSelection frm = new EditorControlSelection(txtEditorTypeName.Text.Trim());
                if (frm.ShowDialog(this) == DialogResult.OK) {
                    txtEditorTypeName.Text = frm.TypeName;
                    //MessageBox.Show(frm.SelectedType == null ? "NULL" : frm.SelectedType.FullName);
                    txtEditorTypeName.Tag = frm.SelectedType;
                    LoadEditorControl();
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
            this.Cursor = Cursors.Default;
        }

        private void txtEditorTypeName_TextChanged(object sender, EventArgs e) {
            //try {
            //    panelEditorPreview.Controls.Clear();
            //    Type t = Type.GetType(txtEditorTypeName.Text);
            //    if (t != null) {
            //        object o = Activator.CreateInstance(t);
            //        if (o.GetType().IsSubclassOf(typeof(Control))) {
            //            Control c = (Control)o;
            //            c.Visible = true;
            //            int x1, y1;
            //            x1 = (panelEditorPreview.Width - c.Width) / 2;
            //            y1 = (panelEditorPreview.Height - c.Height) / 2;
            //            c.Location = new Point(x1, y1);
            //            panelEditorPreview.Controls.Add(c);
            //        }
            //    }
            //} catch (Exception ex) {
            //    MessageBox.Show(ex.ToString());
            //}
        }

        private void LoadEditorControl() {
            try {
                panelEditorPreview.Controls.Clear();
                Type t = (Type)txtEditorTypeName.Tag;
                if (t != null) {
                    object o = Activator.CreateInstance(t);
                    if (o.GetType().IsSubclassOf(typeof(Control))) {
                        Control c = (Control)o;
                        c.Visible = true;
                        int x1, y1;
                        x1 = (panelEditorPreview.Width - c.Width) / 2;
                        y1 = (panelEditorPreview.Height - c.Height) / 2;
                        c.Location = new Point(x1, y1);
                        panelEditorPreview.Controls.Add(c);
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtEditorTypeName_KeyPress(object sender, KeyPressEventArgs e) {
            if (Convert.ToInt32(e.KeyChar) == 13) {
                LoadEditorControl();
            }
        }
    }
}
