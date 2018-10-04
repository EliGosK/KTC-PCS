namespace SystemMaintenance.Forms
{
    partial class SFM0091_AddMenuSet
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
            this.txtMenuSetDesc = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblMenuSetDesc = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtMenuSetCode = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblMenuSetCode = new EVOFramework.Windows.Forms.EVOLabel();
            this.dmcAddMenuSet = new EVOFramework.Data.UIDataModelController(this.components);
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ControlID = "";
            this.btnCancel.Location = new System.Drawing.Point(282, 93);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(62, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ControlID = "";
            this.btnSave.Location = new System.Drawing.Point(201, 93);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(62, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtMenuSetDesc
            // 
            this.txtMenuSetDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMenuSetDesc.ControlID = "";
            this.txtMenuSetDesc.Location = new System.Drawing.Point(154, 57);
            this.txtMenuSetDesc.MaxLength = 50;
            this.txtMenuSetDesc.Name = "txtMenuSetDesc";
            this.txtMenuSetDesc.PathString = "MenuSetDesc.Value";
            this.txtMenuSetDesc.PathValue = "";
            this.txtMenuSetDesc.Size = new System.Drawing.Size(190, 20);
            this.txtMenuSetDesc.TabIndex = 2;
            this.txtMenuSetDesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMenuSetDesc_KeyPress);
            // 
            // lblMenuSetDesc
            // 
            this.lblMenuSetDesc.AutoSize = true;
            this.lblMenuSetDesc.Location = new System.Drawing.Point(61, 60);
            this.lblMenuSetDesc.Name = "lblMenuSetDesc";
            this.lblMenuSetDesc.Size = new System.Drawing.Size(87, 13);
            this.lblMenuSetDesc.TabIndex = 22;
            this.lblMenuSetDesc.Text = "Menu Set Desc :";
            // 
            // txtMenuSetCode
            // 
            this.txtMenuSetCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMenuSetCode.ControlID = "";
            this.txtMenuSetCode.Location = new System.Drawing.Point(154, 31);
            this.txtMenuSetCode.MaxLength = 15;
            this.txtMenuSetCode.Name = "txtMenuSetCode";
            this.txtMenuSetCode.PathString = "MenuSetCD.Value";
            this.txtMenuSetCode.PathValue = "";
            this.txtMenuSetCode.Size = new System.Drawing.Size(190, 20);
            this.txtMenuSetCode.TabIndex = 1;
            this.txtMenuSetCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMenuSetCode_KeyPress);
            // 
            // lblMenuSetCode
            // 
            this.lblMenuSetCode.AutoSize = true;
            this.lblMenuSetCode.Location = new System.Drawing.Point(61, 34);
            this.lblMenuSetCode.Name = "lblMenuSetCode";
            this.lblMenuSetCode.Size = new System.Drawing.Size(87, 13);
            this.lblMenuSetCode.TabIndex = 20;
            this.lblMenuSetCode.Text = "Menu Set Code :";
            // 
            // SFM0091_AddMenuSet
            // 
            this.ClientSize = new System.Drawing.Size(418, 157);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtMenuSetDesc);
            this.Controls.Add(this.lblMenuSetDesc);
            this.Controls.Add(this.txtMenuSetCode);
            this.Controls.Add(this.lblMenuSetCode);
            this.Name = "SFM0091_AddMenuSet";
            this.Text = "Add Menu Set";
            this.Load += new System.EventHandler(this.SFM0091_AddMenuSet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EVOFramework.Windows.Forms.EVOButton btnCancel;
        private EVOFramework.Windows.Forms.EVOButton btnSave;
        private EVOFramework.Windows.Forms.EVOTextBox txtMenuSetDesc;
        private EVOFramework.Windows.Forms.EVOLabel lblMenuSetDesc;
        private EVOFramework.Windows.Forms.EVOTextBox txtMenuSetCode;
        private EVOFramework.Windows.Forms.EVOLabel lblMenuSetCode;
        private EVOFramework.Data.UIDataModelController dmcAddMenuSet;
    }
}
