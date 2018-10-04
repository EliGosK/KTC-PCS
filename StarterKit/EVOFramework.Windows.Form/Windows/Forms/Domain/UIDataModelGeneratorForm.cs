using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EVOFramework.Windows.Forms;

namespace EVOFramework.Data
{
    /// <summary>
    /// Form Domain Generator wizard.
    /// </summary>
    internal partial class UIDataModelGeneratorForm : Form
    {
        private readonly UIDataModelController m_domainController;        

        public UIDataModelGeneratorForm(UIDataModelController domainController, string defaultNamespace, string defaultClassName)
        {
            this.m_domainController = domainController;

            InitializeComponent();

            txtNamespace.Text = defaultNamespace;
            txtClass.Text = defaultClassName;
        }

        private void DomainGeneratorForm_Load(object sender, EventArgs e)
        {
            List<string> listPathRadio = new List<string>();

            for (int i=0; i<m_domainController.ListDomainSupport.Count; i++) {
                IUIDataModelSupport domainSupport = m_domainController.ListDomainSupport[i];

                if (domainSupport is EVORadioButton) {
                    EVORadioButton radio = (EVORadioButton) domainSupport;
                    if (listPathRadio.Contains(radio.PathString)) {
                        continue;
                    }

                    listPathRadio.Add(radio.PathString);
                }

                // add item in listview.
                ListViewItem lsvItem = new ListViewItem(m_domainController.ExtractNestedPropertyName(domainSupport.PathString)[0]);
                lsvItem.SubItems.Add(domainSupport.GetType().Name);
                lsvItem.Tag = domainSupport;
                lsvSource.Items.Add(lsvItem);                                    
            }            
        }

        #region Button Add/Remove item destination.
        private void btnRightAll_Click(object sender, EventArgs e)
        {
            ListViewItem[] items = new ListViewItem[lsvSource.Items.Count];
            for (int i=0; i<lsvSource.Items.Count; i++) {
                items[i] = lsvSource.Items[i];
            }

            for (int i = 0; i < items.Length; i++)
            {
                lsvSource.Items.Remove(items[i]);
                lsvDest.Items.Add(items[i]);
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (lsvSource.SelectedItems.Count > 0)
            {
                ListViewItem[] items = new ListViewItem[lsvSource.SelectedItems.Count];

                for (int i = 0; i < lsvSource.SelectedItems.Count; i++)
                {
                    items[i] = lsvSource.SelectedItems[i];
                }

                for (int i = 0; i < items.Length; i++)
                {
                    lsvSource.Items.Remove(items[i]);
                    lsvDest.Items.Add(items[i]);
                }
            }
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (lsvDest.SelectedItems.Count > 0)
            {
                ListViewItem[] items = new ListViewItem[lsvDest.SelectedItems.Count];

                for (int i = 0; i < lsvDest.SelectedItems.Count; i++)
                {
                    items[i] = lsvDest.SelectedItems[i];
                }

                for (int i = 0; i < items.Length; i++)
                {
                    lsvDest.Items.Remove(items[i]);
                    lsvSource.Items.Add(items[i]);
                }
            }
        }

        private void btnLeftAll_Click(object sender, EventArgs e)
        {
            ListViewItem[] items = new ListViewItem[lsvDest.Items.Count];
            for (int i = 0; i < lsvDest.Items.Count; i++)
            {
                items[i] = lsvDest.Items[i];
            }

            for (int i = 0; i < items.Length; i++)
            {
                lsvDest.Items.Remove(items[i]);
                lsvSource.Items.Add(items[i]);
            }
        }
        #endregion

        private void btnGenPreview_Click(object sender, EventArgs e)
        {
            txtPreview.Text = GeneratePreview();
        }

        private void btnGenFile_Click(object sender, EventArgs e)
        {

            if (saveFileDialog1.ShowDialog() != DialogResult.OK) {
                return;
            }

            string filename = saveFileDialog1.FileName;            
        }

        private string GeneratePreview() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(GenerateClass(txtClass.Text.Trim()));
            return sb.ToString();
        }
        private string GenerateClass(string className)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using EVOFramework;");
            sb.AppendLine("using EVOFramework.Data;");
            sb.AppendLine(string.Empty);
            sb.AppendLine(String.Format("namespace {0} {{", txtNamespace.Text.Trim()));
            sb.AppendLine(String.Format("\tpublic class {0} : IUIDataModel {{", className));

            // Generate Vairables
            for (int i = 0; i < lsvDest.Items.Count; i++) {
                sb.AppendLine(String.Format("\t\tprivate {0} {1} = new {0}();", GetDataTypeOfControl((IUIDataModelSupport)lsvDest.Items[i].Tag),  GetVariableName(lsvDest.Items[i].Text)));
            }

            sb.AppendLine();
            for (int i = 0; i < lsvDest.Items.Count; i++) {
                sb.AppendLine(GetPropertyMethod((IUIDataModelSupport) lsvDest.Items[i].Tag));
            }
            
            sb.AppendLine("\t}");
            sb.AppendLine("}");

            return sb.ToString();
        }

        /// <summary>
        /// Get variable name convention.
        /// </summary>
        /// <param name="ctrlID"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><c>ctrlID</c> is null.</exception>
        private string GetVariableName(string ctrlID)
        {
            const string strPrefix = "m_";

            if (ctrlID == null || ctrlID.Trim() == string.Empty)
                throw new ArgumentNullException("ctrlID", "ControlID can't null or empty value.");

            if (ctrlID.Length < 2)
            {
                return strPrefix + ctrlID.ToLower();
            }

            if (char.IsUpper(ctrlID[0]) && char.IsUpper(ctrlID[1]))
            {  // first two character is Upper.

                // such as: ctrlID: SANo, convert to variable name: m_SANo
                return strPrefix + ctrlID;
            }

            return strPrefix + char.ToLower(ctrlID[0]) + ctrlID.Substring(1);
        }

        private string GetDataTypeOfControl(IUIDataModelSupport component)
        {
            if (component is EVOTextBox)
                return "NZString";
            
            if (component is EVOCheckBox)
                return "NZBoolean";

            if (component is EVORadioButton)
                return "NZString";

            if (component is EVOComboBox)
                return "NZObject";

            return "NZObject";
        }

        private string GetPropertyMethod(IUIDataModelSupport component) {
            string propName = m_domainController.ExtractNestedPropertyName(component.PathString)[0];
            string varName = GetVariableName(propName);
            string dataType = GetDataTypeOfControl(component);
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format("\t\tpublic {0} {1} {{", 
                dataType,
                propName
                ));

            sb.AppendLine(String.Format("\t\t\tget {{ return {0}; }}", varName));
            sb.AppendLine(String.Format("\t\t\tset {{ {0} = value; }}", varName));
            sb.AppendLine("\t\t}");
            return sb.ToString();
        }
    }
}




