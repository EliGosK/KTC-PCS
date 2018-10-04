using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cube.AFD.Windows.Controls.CalendarControls.Design {
    public partial class EditorControlSelection : Form {
        string m_strTypeName = string.Empty;
        public EditorControlSelection(string strTypeNmae) {
            InitializeComponent();
            m_strTypeName = strTypeNmae;
        }

        private void EditorControlSelection_Load(object sender, EventArgs e) {
            lblFolder.Text = AppDomain.CurrentDomain.BaseDirectory;
            ReloadAssembly();
        }

        private void ReloadAssembly() {
            panelEditor.Controls.Clear();
            // Load Current Assembly
            Assembly aCurrent = Assembly.GetExecutingAssembly();
            // Load Assembly from specify folder
            ArrayList asms = new ArrayList();
            asms.Add(aCurrent);
            if (Directory.Exists(lblFolder.Text)) {
                string []fileNames = Directory.GetFiles(lblFolder.Text);
                foreach (string fName in fileNames) {
                    try {
                        FileInfo f = new FileInfo(fName);
                        string strExtension = f.Extension.ToUpper();
                        if (strExtension == ".DLL" || strExtension == ".EXE") {
                            string strTempFile = Path.GetTempFileName();
                            strTempFile += strExtension;
                            File.Copy(f.FullName, strTempFile);
                            Assembly a = Assembly.LoadFile(strTempFile);
                            if (a != aCurrent) {
                                asms.Add(a);
                            }
                        }
                    } catch { }
                }
            }

            // Load type from assembly
            ArrayList arEditorTypeCurrent = new ArrayList();
            ArrayList arEditorType = new ArrayList();
            int iCount = 0;
            foreach (Assembly asm in asms) {
                Type[] types = asm.GetTypes();
                foreach (Type t in types) {
                    try {
                        if (t.IsSubclassOf(typeof(DayEditor))) {
                            if (iCount <= 0) {
                                arEditorTypeCurrent.Add(t);
                            } else {
                                arEditorType.Add(t);
                            }
                        }

                        //Type tif = t.GetInterface("IEditorControl");
                        //if (tif != null) {
                        //    if (iCount <= 0) {
                        //        arEditorTypeCurrent.Add(t);
                        //    } else {
                        //        arEditorType.Add(t);
                        //    }
                        //}
                    } catch { }
                }
                iCount++;
            }
            for (int i = 0; i < asms.Count; ++i) {
                asms[i] = null;
            }
            asms.Clear();
            asms = null;
            GC.Collect();
            
            // Display in panel
            int x = 10;
            int y = 5;
            foreach (Type t in arEditorTypeCurrent) {
                RadioButton rd = new RadioButton();
                rd.Visible = true;
                rd.Text = t.FullName;
                rd.Location = new Point(x, y);
                rd.Width = panelEditor.Width - (x * 2);
                rd.ForeColor = Color.Blue;
                rd.CheckedChanged += new EventHandler(rd_CheckedChanged);
                rd.Tag = t;
                rd.Checked = (m_strTypeName == t.FullName);
                panelEditor.Controls.Add(rd);
                y += rd.Height;
            }
            foreach (Type t in arEditorType) {
                RadioButton rd = new RadioButton();
                rd.Visible = true;
                rd.Text = t.FullName;
                rd.Location = new Point(x, y);
                rd.Width = panelEditor.Width - (x*2);
                rd.CheckedChanged += new EventHandler(rd_CheckedChanged);
                rd.Tag = t;
                rd.Checked = (m_strTypeName == t.FullName);
                panelEditor.Controls.Add(rd);
                y += rd.Height;
            }
        }

        public string TypeName {
            get {
                return m_strTypeName;
            }
        }

        public Type SelectedType {
            get {
                foreach (Control c in panelEditor.Controls) {
                    if ((((RadioButton)c).Checked)) {
                        return (Type)c.Tag;
                    }
                }
                return null;
            }
        }

        void rd_CheckedChanged(object sender, EventArgs e) {
            try {
                panelPreview.Controls.Clear();
                Type t = (Type)((RadioButton)sender).Tag;
                m_strTypeName = t.FullName;
                object oControl =  Activator.CreateInstance(t);
                if (oControl.GetType().IsSubclassOf(typeof(Control)) == true) {
                    Control c = (Control)oControl;
                    c.Visible = true;
                    int x1, y1;
                    x1 = (panelPreview.Width - c.Width) / 2;
                    y1 = (panelPreview.Height - c.Height) / 2;
                    c.Location = new Point(x1, y1);

                    panelPreview.Controls.Add(c);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnChangeFolder_Click(object sender, EventArgs e) {
            try {
                FolderBrowserDialog dlg = new FolderBrowserDialog();
                if (Directory.Exists(lblFolder.Text)) {
                    dlg.SelectedPath = lblFolder.Text;
                } else {
                    dlg.SelectedPath = AppDomain.CurrentDomain.BaseDirectory;
                }
                if (dlg.ShowDialog() == DialogResult.OK) {
                    lblFolder.Text = dlg.SelectedPath;
                    ReloadAssembly();
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
