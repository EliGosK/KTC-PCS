namespace SystemMaintenance.Forms
{
    partial class SFM0082_EditSubMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.stcSubMenuCode = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtSubMenuCode = new EVOFramework.Windows.Forms.EVOTextBox();
            this.stcSubMenuName = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtSubMenuName = new EVOFramework.Windows.Forms.EVOTextBox();
            this.btnSave = new EVOFramework.Windows.Forms.EVOButton();
            this.btnCancel = new EVOFramework.Windows.Forms.EVOButton();
            this.SuspendLayout();
            // 
            // stcSubMenuCode
            // 
            this.stcSubMenuCode.Location = new System.Drawing.Point(6, 9);
            this.stcSubMenuCode.Name = "stcSubMenuCode";
            this.stcSubMenuCode.Size = new System.Drawing.Size(103, 23);
            this.stcSubMenuCode.TabIndex = 2;
            this.stcSubMenuCode.Text = "Sub Menu Code:";
            this.stcSubMenuCode.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtSubMenuCode
            // 
            this.txtSubMenuCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubMenuCode.ControlID = "";
            this.txtSubMenuCode.Location = new System.Drawing.Point(115, 6);
            this.txtSubMenuCode.MaxLength = 15;
            this.txtSubMenuCode.Name = "txtSubMenuCode";
            this.txtSubMenuCode.PathString = "SubMenuCode.Value";
            this.txtSubMenuCode.PathValue = "";
            this.txtSubMenuCode.Size = new System.Drawing.Size(165, 20);
            this.txtSubMenuCode.TabIndex = 3;
            // 
            // stcSubMenuName
            // 
            this.stcSubMenuName.Location = new System.Drawing.Point(6, 32);
            this.stcSubMenuName.Name = "stcSubMenuName";
            this.stcSubMenuName.Size = new System.Drawing.Size(103, 23);
            this.stcSubMenuName.TabIndex = 4;
            this.stcSubMenuName.Text = "Sub Menu Name:";
            this.stcSubMenuName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtSubMenuName
            // 
            this.txtSubMenuName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubMenuName.ControlID = "";
            this.txtSubMenuName.Location = new System.Drawing.Point(115, 29);
            this.txtSubMenuName.MaxLength = 30;
            this.txtSubMenuName.Name = "txtSubMenuName";
            this.txtSubMenuName.PathString = "SubMenuName.Value";
            this.txtSubMenuName.PathValue = "";
            this.txtSubMenuName.Size = new System.Drawing.Size(165, 20);
            this.txtSubMenuName.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.ControlID = null;
            this.btnSave.Location = new System.Drawing.Point(115, 64);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ControlID = null;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(202, 64);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "C&ancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SFM0082_EditSubMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(292, 100);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtSubMenuName);
            this.Controls.Add(this.stcSubMenuName);
            this.Controls.Add(this.txtSubMenuCode);
            this.Controls.Add(this.stcSubMenuCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SFM0082_EditSubMenu";
            this.ShowInTaskbar = false;
            this.Text = "SFM0082 EditSubMenu";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EVOFramework.Windows.Forms.EVOLabel stcSubMenuCode;
        private EVOFramework.Windows.Forms.EVOTextBox txtSubMenuCode;
        private EVOFramework.Windows.Forms.EVOLabel stcSubMenuName;
        private EVOFramework.Windows.Forms.EVOTextBox txtSubMenuName;
        private EVOFramework.Windows.Forms.EVOButton btnSave;
        private EVOFramework.Windows.Forms.EVOButton btnCancel;
    }
}