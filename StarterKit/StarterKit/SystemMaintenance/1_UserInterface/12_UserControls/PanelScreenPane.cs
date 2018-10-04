using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EVOFramework.Windows.Forms;
using System.ComponentModel;

namespace SystemMaintenance
{
    /// <summary>
    /// Panel for receive from to show as pane.
    /// </summary>
    [ToolboxItem(false)]
    public class PanelScreenPane : Panel
    {
        #region Variables
        /// <summary>
        /// Current assigned form.
        /// </summary>
        private EVOForm m_form = null;
        #endregion

        #region Constructor
        public PanelScreenPane() {

        }

        /// <summary>
        /// Current assigned form.
        /// </summary>
        public EVOForm AssignedForm {
            get { return m_form; }
            private set { m_form = value; }
        }

        #endregion

        #region Private methods
        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ArgumentException">Assigned Form is null.</exception>
        private void InitializePane() {
            this.SuspendLayout();

            try
            {
                this.Controls.Clear();

                if (AssignedForm == null)
                    throw new ArgumentException("Assigned Form is null.");

                // Create Close button
                //Button btnClose = new Button();
                //btnClose.Text = "X";
                //btnClose.Size = new Size(24, 24);
                //btnClose.Location = new Point(this.Width - btnClose.Width - 5, 5);
                //btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                //btnClose.Click += new EventHandler(btnClose_Click);
                //this.Controls.Add(btnClose);

                // Add all controls.
                AssignedForm.ShowInTaskbar = false;
                AssignedForm.TopLevel = false;
                AssignedForm.Visible = true;
                AssignedForm.FormBorderStyle = FormBorderStyle.None;
                AssignedForm.Dock = DockStyle.Fill;
                this.Controls.Add(AssignedForm);

            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
            finally {
                this.ResumeLayout(true);
            }
        }

        void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();            
            InternalVariable.MenuFrame_Instance.HideScreenPane();
        }
        #endregion


        #region Public methods
        /// <summary>
        /// Assign form to panel pane.
        /// </summary>
        /// <param name="form"></param>
        public void AssignForm(EVOForm form) {
            this.AssignedForm = form;            
            InitializePane();
        }

        /// <summary>
        /// Close panel.
        /// </summary>
        /// <returns></returns>
        public bool Close() {
            if (AssignedForm != null) {                
                AssignedForm.Close(true);

                if (AssignedForm.IsDisposed) {
                    AssignedForm = null;                    
                } else {
                    return false;
                }
            }

            return true;
        }
        #endregion
    }
}
