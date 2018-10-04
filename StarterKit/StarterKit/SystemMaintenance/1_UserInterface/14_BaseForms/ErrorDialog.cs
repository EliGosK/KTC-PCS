using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SystemMaintenance.Forms;

namespace SystemMaintenance
{
    public partial class ErrorDialog : CustomizeBaseForm
    {
        private enum eStateCollapse {
            Collapsed, 
            Expanded,
        }

        #region Variables
        private eStateCollapse m_stateCollapse = eStateCollapse.Collapsed;
        private Size m_lastSize = System.Drawing.Size.Empty;
        #endregion

        #region Constructor
        public ErrorDialog()
        {
            InitializeComponent();
        }
        #endregion

        #region Private method
        private void CollapseStackTrace() {
            m_lastSize = this.Size;

            txtStackTrace.Visible = false;
            statusStrip1.Visible = false;
            btnDetail.Text = "Detail >>";
            
            m_stateCollapse = eStateCollapse.Collapsed;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.Height = SystemInformation.CaptionHeight + SystemInformation.BorderSize.Height +  pnlButton.Location.Y + pnlButton.Height + 10;
        }

        private void ExpandStackTrace() {
            txtStackTrace.Visible = true;
            statusStrip1.Visible = true;
            btnDetail.Text = "Detail <<";

            m_stateCollapse = eStateCollapse.Expanded;            
            this.FormBorderStyle = FormBorderStyle.Sizable;

            this.Size = m_lastSize;
        }

        private void ToggleStackTrace() {
            if (m_stateCollapse == eStateCollapse.Collapsed) {
                ExpandStackTrace();
            } else {
                CollapseStackTrace();
            }
        }
        #endregion

        #region Properties
        public string Message {
            get { return lblMessage.Text; }
            set { lblMessage.Text = value; }
        }
        public string StackTrace {
            get { return txtStackTrace.Text; }
            set { txtStackTrace.Text = value;}
        }
        #endregion

        #region Form event
        private void ErrorDialog_Load(object sender, EventArgs e)
        {
            CollapseStackTrace();
        }

        private void ErrorDialog_Shown(object sender, EventArgs e)
        {
            m_lastSize = new Size(409, 354);
        }
        #endregion

        #region Control event
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            ToggleStackTrace();
        }
        #endregion

        
    }
}
