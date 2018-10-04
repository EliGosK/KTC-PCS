namespace SystemMaintenance.Forms
{
    partial class FormSetting
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
            this.grpDatabase = new System.Windows.Forms.GroupBox();
            this.stcDatabaseName = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtDatabasename = new EVOFramework.Windows.Forms.EVOTextBox();
            this.btnTestConnection = new EVOFramework.Windows.Forms.EVOButton();
            this.txtPassword = new EVOFramework.Windows.Forms.EVOTextBox();
            this.txtUsername = new EVOFramework.Windows.Forms.EVOTextBox();
            this.txtServiceName = new EVOFramework.Windows.Forms.EVOTextBox();
            this.stcPassword = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcUsername = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcServiceName = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblProvider = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcProvider = new EVOFramework.Windows.Forms.EVOLabel();
            this.btnOK = new EVOFramework.Windows.Forms.EVOButton();
            this.btnCancel = new EVOFramework.Windows.Forms.EVOButton();
            this.grpDatabase.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpDatabase
            // 
            this.grpDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDatabase.Controls.Add(this.stcDatabaseName);
            this.grpDatabase.Controls.Add(this.txtDatabasename);
            this.grpDatabase.Controls.Add(this.btnTestConnection);
            this.grpDatabase.Controls.Add(this.txtPassword);
            this.grpDatabase.Controls.Add(this.txtUsername);
            this.grpDatabase.Controls.Add(this.txtServiceName);
            this.grpDatabase.Controls.Add(this.stcPassword);
            this.grpDatabase.Controls.Add(this.stcUsername);
            this.grpDatabase.Controls.Add(this.stcServiceName);
            this.grpDatabase.Controls.Add(this.lblProvider);
            this.grpDatabase.Controls.Add(this.stcProvider);
            this.grpDatabase.Location = new System.Drawing.Point(5, 5);
            this.grpDatabase.Name = "grpDatabase";
            this.grpDatabase.Size = new System.Drawing.Size(273, 165);
            this.grpDatabase.TabIndex = 0;
            this.grpDatabase.TabStop = false;
            this.grpDatabase.Text = "Database";
            // 
            // stcDatabaseName
            // 
            this.stcDatabaseName.AppearanceName = "";
            this.stcDatabaseName.ControlID = "";
            this.stcDatabaseName.Location = new System.Drawing.Point(9, 63);
            this.stcDatabaseName.Name = "stcDatabaseName";
            this.stcDatabaseName.PathString = null;
            this.stcDatabaseName.PathValue = "Database Name:";
            this.stcDatabaseName.Size = new System.Drawing.Size(87, 23);
            this.stcDatabaseName.TabIndex = 4;
            this.stcDatabaseName.Text = "Database Name:";
            this.stcDatabaseName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtDatabasename
            // 
            this.txtDatabasename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDatabasename.AppearanceName = "";
            this.txtDatabasename.AppearanceReadOnlyName = "";
            this.txtDatabasename.ControlID = "";
            this.txtDatabasename.HelpButton = null;
            this.txtDatabasename.Location = new System.Drawing.Point(101, 60);
            this.txtDatabasename.MaxLength = 50;
            this.txtDatabasename.Name = "txtDatabasename";
            this.txtDatabasename.PathString = null;
            this.txtDatabasename.PathValue = "";
            this.txtDatabasename.Size = new System.Drawing.Size(166, 20);
            this.txtDatabasename.TabIndex = 5;
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestConnection.AppearanceName = "";
            this.btnTestConnection.ControlID = "";
            this.btnTestConnection.Location = new System.Drawing.Point(160, 132);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(107, 23);
            this.btnTestConnection.TabIndex = 10;
            this.btnTestConnection.Text = "&Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.AppearanceName = "";
            this.txtPassword.AppearanceReadOnlyName = "";
            this.txtPassword.ControlID = "";
            this.txtPassword.HelpButton = null;
            this.txtPassword.Location = new System.Drawing.Point(101, 106);
            this.txtPassword.MaxLength = 50;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PathString = null;
            this.txtPassword.PathValue = "";
            this.txtPassword.Size = new System.Drawing.Size(166, 20);
            this.txtPassword.TabIndex = 9;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.AppearanceName = "";
            this.txtUsername.AppearanceReadOnlyName = "";
            this.txtUsername.ControlID = "";
            this.txtUsername.HelpButton = null;
            this.txtUsername.Location = new System.Drawing.Point(101, 84);
            this.txtUsername.MaxLength = 50;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PathString = null;
            this.txtUsername.PathValue = "";
            this.txtUsername.Size = new System.Drawing.Size(166, 20);
            this.txtUsername.TabIndex = 7;
            // 
            // txtServiceName
            // 
            this.txtServiceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServiceName.AppearanceName = "";
            this.txtServiceName.AppearanceReadOnlyName = "";
            this.txtServiceName.ControlID = "";
            this.txtServiceName.HelpButton = null;
            this.txtServiceName.Location = new System.Drawing.Point(101, 35);
            this.txtServiceName.MaxLength = 50;
            this.txtServiceName.Name = "txtServiceName";
            this.txtServiceName.PathString = null;
            this.txtServiceName.PathValue = "";
            this.txtServiceName.Size = new System.Drawing.Size(166, 20);
            this.txtServiceName.TabIndex = 3;
            // 
            // stcPassword
            // 
            this.stcPassword.AppearanceName = "";
            this.stcPassword.ControlID = "";
            this.stcPassword.Location = new System.Drawing.Point(8, 109);
            this.stcPassword.Name = "stcPassword";
            this.stcPassword.PathString = null;
            this.stcPassword.PathValue = "Password:";
            this.stcPassword.Size = new System.Drawing.Size(87, 23);
            this.stcPassword.TabIndex = 8;
            this.stcPassword.Text = "Password:";
            this.stcPassword.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // stcUsername
            // 
            this.stcUsername.AppearanceName = "";
            this.stcUsername.ControlID = "";
            this.stcUsername.Location = new System.Drawing.Point(8, 87);
            this.stcUsername.Name = "stcUsername";
            this.stcUsername.PathString = null;
            this.stcUsername.PathValue = "Username:";
            this.stcUsername.Size = new System.Drawing.Size(87, 23);
            this.stcUsername.TabIndex = 6;
            this.stcUsername.Text = "Username:";
            this.stcUsername.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // stcServiceName
            // 
            this.stcServiceName.AppearanceName = "";
            this.stcServiceName.ControlID = "";
            this.stcServiceName.Location = new System.Drawing.Point(9, 39);
            this.stcServiceName.Name = "stcServiceName";
            this.stcServiceName.PathString = null;
            this.stcServiceName.PathValue = "Service Name:";
            this.stcServiceName.Size = new System.Drawing.Size(87, 23);
            this.stcServiceName.TabIndex = 2;
            this.stcServiceName.Text = "Service Name:";
            this.stcServiceName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblProvider
            // 
            this.lblProvider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProvider.AppearanceName = "";
            this.lblProvider.ControlID = "";
            this.lblProvider.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblProvider.Location = new System.Drawing.Point(101, 16);
            this.lblProvider.Name = "lblProvider";
            this.lblProvider.PathString = null;
            this.lblProvider.PathValue = "SQL Server";
            this.lblProvider.Size = new System.Drawing.Size(166, 23);
            this.lblProvider.TabIndex = 1;
            this.lblProvider.Text = "SQL Server";
            // 
            // stcProvider
            // 
            this.stcProvider.AppearanceName = "";
            this.stcProvider.ControlID = "";
            this.stcProvider.Location = new System.Drawing.Point(8, 16);
            this.stcProvider.Name = "stcProvider";
            this.stcProvider.PathString = null;
            this.stcProvider.PathValue = "Provider:";
            this.stcProvider.Size = new System.Drawing.Size(87, 23);
            this.stcProvider.TabIndex = 0;
            this.stcProvider.Text = "Provider:";
            this.stcProvider.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.AppearanceName = "";
            this.btnOK.ControlID = "";
            this.btnOK.Location = new System.Drawing.Point(59, 176);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.AppearanceName = "";
            this.btnCancel.ControlID = "";
            this.btnCancel.Location = new System.Drawing.Point(151, 176);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormSetting
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(285, 211);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grpDatabase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(256, 0);
            this.Name = "FormSetting";
            this.ShowInTaskbar = false;
            this.Text = "Configuration";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormSetting_Load);
            this.grpDatabase.ResumeLayout(false);
            this.grpDatabase.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDatabase;
        private EVOFramework.Windows.Forms.EVOButton btnOK;
        private EVOFramework.Windows.Forms.EVOButton btnCancel;
        private EVOFramework.Windows.Forms.EVOTextBox txtPassword;
        private EVOFramework.Windows.Forms.EVOTextBox txtUsername;
        private EVOFramework.Windows.Forms.EVOTextBox txtServiceName;
        private EVOFramework.Windows.Forms.EVOLabel stcPassword;
        private EVOFramework.Windows.Forms.EVOLabel stcUsername;
        private EVOFramework.Windows.Forms.EVOLabel stcServiceName;
        private EVOFramework.Windows.Forms.EVOLabel lblProvider;
        private EVOFramework.Windows.Forms.EVOLabel stcProvider;
        private EVOFramework.Windows.Forms.EVOButton btnTestConnection;
        private EVOFramework.Windows.Forms.EVOLabel stcDatabaseName;
        private EVOFramework.Windows.Forms.EVOTextBox txtDatabasename;
    }
}