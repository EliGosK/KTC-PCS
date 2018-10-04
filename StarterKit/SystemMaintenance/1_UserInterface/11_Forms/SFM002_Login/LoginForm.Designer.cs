namespace SystemMaintenance.Forms
{
    partial class LoginForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnl1 = new System.Windows.Forms.Panel();
            this.txtDatabase = new EVOFramework.Windows.Forms.EVOTextBox();
            this.picLogin = new System.Windows.Forms.PictureBox();
            this.stcDatabase = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtPassword = new EVOFramework.Windows.Forms.EVOTextBox();
            this.txtUserAccount = new EVOFramework.Windows.Forms.EVOTextBox();
            this.stcPassword = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcUserAccount = new EVOFramework.Windows.Forms.EVOLabel();
            this.btnConfig = new EVOFramework.Windows.Forms.EVOButton();
            this.btnOK = new EVOFramework.Windows.Forms.EVOButton();
            this.btnCancel = new EVOFramework.Windows.Forms.EVOButton();
            this.br = new EVOFramework.Windows.Forms.EVOBorder();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogin)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pnl1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(357, 81);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pnl1
            // 
            this.pnl1.BackColor = System.Drawing.SystemColors.Control;
            this.pnl1.Controls.Add(this.txtDatabase);
            this.pnl1.Controls.Add(this.picLogin);
            this.pnl1.Controls.Add(this.stcDatabase);
            this.pnl1.Controls.Add(this.txtPassword);
            this.pnl1.Controls.Add(this.txtUserAccount);
            this.pnl1.Controls.Add(this.stcPassword);
            this.pnl1.Controls.Add(this.stcUserAccount);
            this.pnl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl1.Location = new System.Drawing.Point(0, 0);
            this.pnl1.Margin = new System.Windows.Forms.Padding(0);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(357, 81);
            this.pnl1.TabIndex = 0;
            // 
            // txtDatabase
            // 
            this.txtDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDatabase.AppearanceName = "";
            this.txtDatabase.AppearanceReadOnlyName = "";
            this.txtDatabase.BackColor = System.Drawing.SystemColors.Control;
            this.txtDatabase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDatabase.ControlID = "Password";
            this.txtDatabase.DisableRestrictChar = false;
            this.txtDatabase.HelpButton = null;
            this.txtDatabase.Location = new System.Drawing.Point(166, 59);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.PathString = "";
            this.txtDatabase.PathValue = "";
            this.txtDatabase.ReadOnly = true;
            this.txtDatabase.Size = new System.Drawing.Size(171, 13);
            this.txtDatabase.TabIndex = 2;
            this.txtDatabase.TabStop = false;
            // 
            // picLogin
            // 
            this.picLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picLogin.Image = global::SystemMaintenance.Properties.Resources.SCREEN_LOGON;
            this.picLogin.Location = new System.Drawing.Point(5, 7);
            this.picLogin.Name = "picLogin";
            this.picLogin.Size = new System.Drawing.Size(76, 68);
            this.picLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogin.TabIndex = 6;
            this.picLogin.TabStop = false;
            this.picLogin.DoubleClick += new System.EventHandler(this.picLogin_DoubleClick);
            // 
            // stcDatabase
            // 
            this.stcDatabase.AppearanceName = "";
            this.stcDatabase.ControlID = "";
            this.stcDatabase.Location = new System.Drawing.Point(93, 59);
            this.stcDatabase.Name = "stcDatabase";
            this.stcDatabase.PathString = null;
            this.stcDatabase.PathValue = "Database:";
            this.stcDatabase.Size = new System.Drawing.Size(65, 23);
            this.stcDatabase.TabIndex = 4;
            this.stcDatabase.Text = "Database:";
            this.stcDatabase.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.AppearanceName = "";
            this.txtPassword.AppearanceReadOnlyName = "";
            this.txtPassword.ControlID = "Password";
            this.txtPassword.DisableRestrictChar = false;
            this.txtPassword.HelpButton = null;
            this.txtPassword.Location = new System.Drawing.Point(166, 32);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PathString = "";
            this.txtPassword.PathValue = "";
            this.txtPassword.Size = new System.Drawing.Size(171, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // txtUserAccount
            // 
            this.txtUserAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserAccount.AppearanceName = "";
            this.txtUserAccount.AppearanceReadOnlyName = "";
            this.txtUserAccount.ControlID = "Username";
            this.txtUserAccount.DisableRestrictChar = false;
            this.txtUserAccount.HelpButton = null;
            this.txtUserAccount.Location = new System.Drawing.Point(166, 9);
            this.txtUserAccount.Name = "txtUserAccount";
            this.txtUserAccount.PathString = "";
            this.txtUserAccount.PathValue = "";
            this.txtUserAccount.Size = new System.Drawing.Size(171, 20);
            this.txtUserAccount.TabIndex = 0;
            // 
            // stcPassword
            // 
            this.stcPassword.AppearanceName = "";
            this.stcPassword.ControlID = "";
            this.stcPassword.Location = new System.Drawing.Point(93, 35);
            this.stcPassword.Name = "stcPassword";
            this.stcPassword.PathString = null;
            this.stcPassword.PathValue = "Password:";
            this.stcPassword.Size = new System.Drawing.Size(65, 23);
            this.stcPassword.TabIndex = 1;
            this.stcPassword.Text = "Password:";
            this.stcPassword.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // stcUserAccount
            // 
            this.stcUserAccount.AppearanceName = "";
            this.stcUserAccount.ControlID = "";
            this.stcUserAccount.Location = new System.Drawing.Point(78, 12);
            this.stcUserAccount.Name = "stcUserAccount";
            this.stcUserAccount.PathString = null;
            this.stcUserAccount.PathValue = "User Account:";
            this.stcUserAccount.Size = new System.Drawing.Size(82, 23);
            this.stcUserAccount.TabIndex = 0;
            this.stcUserAccount.Text = "User Account:";
            this.stcUserAccount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnConfig
            // 
            this.btnConfig.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnConfig.AppearanceName = "";
            this.btnConfig.ControlID = "";
            this.btnConfig.Location = new System.Drawing.Point(12, 9);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(75, 23);
            this.btnConfig.TabIndex = 2;
            this.btnConfig.Text = "Config";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Visible = false;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.AppearanceName = "";
            this.btnOK.ControlID = "";
            this.btnOK.Location = new System.Drawing.Point(181, 9);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.AppearanceName = "";
            this.btnCancel.ControlID = "";
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(262, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // br
            // 
            this.br.BackColor = System.Drawing.Color.Transparent;
            this.br.BorderLineColor = System.Drawing.SystemColors.ControlDark;
            this.br.Dock = System.Windows.Forms.DockStyle.Top;
            this.br.Location = new System.Drawing.Point(0, 81);
            this.br.Name = "br";
            this.br.Size = new System.Drawing.Size(357, 3);
            this.br.Style = EVOFramework.Windows.Forms.EVOBorder.BorderEdgeStyle.Top;
            this.br.TabIndex = 0;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnOK);
            this.pnlBottom.Controls.Add(this.btnConfig);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Location = new System.Drawing.Point(0, 84);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(357, 40);
            this.pnlBottom.TabIndex = 1;
            // 
            // LoginForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(357, 124);
            this.ControlBox = false;
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.br);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.Text = "Login";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.Shown += new System.EventHandler(this.LoginForm_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnl1.ResumeLayout(false);
            this.pnl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogin)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnl1;
        private EVOFramework.Windows.Forms.EVOTextBox txtPassword;
        private EVOFramework.Windows.Forms.EVOTextBox txtUserAccount;
        private EVOFramework.Windows.Forms.EVOLabel stcPassword;
        private EVOFramework.Windows.Forms.EVOLabel stcUserAccount;
        private EVOFramework.Windows.Forms.EVOButton btnConfig;
        private EVOFramework.Windows.Forms.EVOButton btnOK;
        private EVOFramework.Windows.Forms.EVOButton btnCancel;
        private EVOFramework.Windows.Forms.EVOBorder br;
        private EVOFramework.Windows.Forms.EVOLabel stcDatabase;
        private System.Windows.Forms.PictureBox picLogin;
        private EVOFramework.Windows.Forms.EVOTextBox txtDatabase;
        private System.Windows.Forms.Panel pnlBottom;
    }
}