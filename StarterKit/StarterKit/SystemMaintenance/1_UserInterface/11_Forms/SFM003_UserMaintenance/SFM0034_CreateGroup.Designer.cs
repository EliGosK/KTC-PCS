namespace SystemMaintenance.Forms
{
    partial class SFM0034_CreateGroup
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
            this.components = new System.ComponentModel.Container();
            this.btnCancel = new EVOFramework.Windows.Forms.EVOButton();
            this.btnSave = new EVOFramework.Windows.Forms.EVOButton();
            this.txtGroupDesc = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblGroupDesc = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtGroupCD = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblGroupCD = new EVOFramework.Windows.Forms.EVOLabel();
            this.dmcCreateGroup = new EVOFramework.Data.UIDataModelController(this.components);
            this.picUser = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.ControlID = "";
            this.btnCancel.Location = new System.Drawing.Point(231, 147);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.ControlID = "";
            this.btnSave.Location = new System.Drawing.Point(150, 147);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtGroupDesc
            // 
            this.txtGroupDesc.ControlID = "";
            this.txtGroupDesc.Location = new System.Drawing.Point(116, 107);
            this.txtGroupDesc.MaxLength = 30;
            this.txtGroupDesc.Name = "txtGroupDesc";
            this.txtGroupDesc.PathString = "GroupDesc.Value";
            this.txtGroupDesc.PathValue = "";
            this.txtGroupDesc.Size = new System.Drawing.Size(190, 20);
            this.txtGroupDesc.TabIndex = 2;
            // 
            // lblGroupDesc
            // 
            this.lblGroupDesc.AutoSize = true;
            this.lblGroupDesc.Location = new System.Drawing.Point(13, 110);
            this.lblGroupDesc.Name = "lblGroupDesc";
            this.lblGroupDesc.Size = new System.Drawing.Size(98, 13);
            this.lblGroupDesc.TabIndex = 22;
            this.lblGroupDesc.Text = "Group Description :";
            // 
            // txtGroupCD
            // 
            this.txtGroupCD.ControlID = "";
            this.txtGroupCD.Location = new System.Drawing.Point(116, 81);
            this.txtGroupCD.MaxLength = 15;
            this.txtGroupCD.Name = "txtGroupCD";
            this.txtGroupCD.PathString = "GroupCD.Value";
            this.txtGroupCD.PathValue = "";
            this.txtGroupCD.Size = new System.Drawing.Size(190, 20);
            this.txtGroupCD.TabIndex = 1;
            // 
            // lblGroupCD
            // 
            this.lblGroupCD.AutoSize = true;
            this.lblGroupCD.Location = new System.Drawing.Point(37, 84);
            this.lblGroupCD.Name = "lblGroupCD";
            this.lblGroupCD.Size = new System.Drawing.Size(73, 13);
            this.lblGroupCD.TabIndex = 20;
            this.lblGroupCD.Text = "Group Name :";
            // 
            // picUser
            // 
            this.picUser.Image = global::SystemMaintenance.Properties.Resources.GROUP_USER;
            this.picUser.Location = new System.Drawing.Point(244, 12);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(62, 58);
            this.picUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUser.TabIndex = 26;
            this.picUser.TabStop = false;
            // 
            // SFM0034_CreateGroup
            // 
            this.ClientSize = new System.Drawing.Size(324, 182);
            this.ControlBox = false;
            this.Controls.Add(this.picUser);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtGroupDesc);
            this.Controls.Add(this.lblGroupDesc);
            this.Controls.Add(this.txtGroupCD);
            this.Controls.Add(this.lblGroupCD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "SFM0034_CreateGroup";
            this.Text = "Create Group";
            this.Load += new System.EventHandler(this.SFM0034_CreateGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EVOFramework.Windows.Forms.EVOButton btnCancel;
        private EVOFramework.Windows.Forms.EVOButton btnSave;
        private EVOFramework.Windows.Forms.EVOTextBox txtGroupDesc;
        private EVOFramework.Windows.Forms.EVOLabel lblGroupDesc;
        private EVOFramework.Windows.Forms.EVOTextBox txtGroupCD;
        private EVOFramework.Windows.Forms.EVOLabel lblGroupCD;
        private EVOFramework.Data.UIDataModelController dmcCreateGroup;
        private System.Windows.Forms.PictureBox picUser;
    }
}
