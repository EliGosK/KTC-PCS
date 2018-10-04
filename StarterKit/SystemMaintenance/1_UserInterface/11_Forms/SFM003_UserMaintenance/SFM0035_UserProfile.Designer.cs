namespace SystemMaintenance.Forms
{
    partial class SFM0035_UserProfile
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
            this.picUser = new System.Windows.Forms.PictureBox();
            this.btnCancel = new EVOFramework.Windows.Forms.EVOButton();
            this.btnSave = new EVOFramework.Windows.Forms.EVOButton();
            this.cboDefaultLang = new EVOFramework.Windows.Forms.EVOComboBox();
            this.lblDefaultLang = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboDefaultDateFormat = new EVOFramework.Windows.Forms.EVOComboBox();
            this.lblDefaultDateFormat = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtNewPassword = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblPassWord = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtUsername = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblUserName = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtUserAccount = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblUserAccount = new EVOFramework.Windows.Forms.EVOLabel();
            this.brLine1 = new EVOFramework.Windows.Forms.EVOBorder();
            this.txtConfirmNewPassword = new EVOFramework.Windows.Forms.EVOTextBox();
            this.evoLabel1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel2 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtCurrentPassword = new EVOFramework.Windows.Forms.EVOTextBox();
            this.evoBorder1 = new EVOFramework.Windows.Forms.EVOBorder();
            this.dmcUserProfile = new EVOFramework.Data.UIDataModelController(this.components);
            this.evoBorder2 = new EVOFramework.Windows.Forms.EVOBorder();
            this.evoLabel3 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel4 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel5 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel6 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel7 = new EVOFramework.Windows.Forms.EVOLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            this.SuspendLayout();
            // 
            // picUser
            // 
            this.picUser.Image = global::SystemMaintenance.Properties.Resources.USER;
            this.picUser.Location = new System.Drawing.Point(261, 12);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(62, 58);
            this.picUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUser.TabIndex = 37;
            this.picUser.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.AppearanceName = "";
            this.btnCancel.ControlID = "";
            this.btnCancel.Location = new System.Drawing.Point(191, 244);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.AppearanceName = "";
            this.btnSave.ControlID = "";
            this.btnSave.Location = new System.Drawing.Point(110, 244);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cboDefaultLang
            // 
            this.cboDefaultLang.AppearanceName = "";
            this.cboDefaultLang.AppearanceReadOnlyName = "";
            this.cboDefaultLang.ControlID = null;
            this.cboDefaultLang.DropDownHeight = 180;
            this.cboDefaultLang.FormattingEnabled = true;
            this.cboDefaultLang.IntegralHeight = false;
            this.cboDefaultLang.Location = new System.Drawing.Point(145, 33);
            this.cboDefaultLang.Name = "cboDefaultLang";
            this.cboDefaultLang.PathString = "DefaultLang.Value";
            this.cboDefaultLang.PathValue = null;
            this.cboDefaultLang.Size = new System.Drawing.Size(178, 21);
            this.cboDefaultLang.TabIndex = 3;
            this.cboDefaultLang.Visible = false;
            // 
            // lblDefaultLang
            // 
            this.lblDefaultLang.AppearanceName = "";
            this.lblDefaultLang.ControlID = "";
            this.lblDefaultLang.Location = new System.Drawing.Point(20, 36);
            this.lblDefaultLang.Name = "lblDefaultLang";
            this.lblDefaultLang.PathString = null;
            this.lblDefaultLang.PathValue = "Default Language :";
            this.lblDefaultLang.Size = new System.Drawing.Size(119, 13);
            this.lblDefaultLang.TabIndex = 29;
            this.lblDefaultLang.Text = "Default Language :";
            this.lblDefaultLang.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblDefaultLang.Visible = false;
            // 
            // cboDefaultDateFormat
            // 
            this.cboDefaultDateFormat.AppearanceName = "";
            this.cboDefaultDateFormat.AppearanceReadOnlyName = "";
            this.cboDefaultDateFormat.ControlID = null;
            this.cboDefaultDateFormat.DropDownHeight = 180;
            this.cboDefaultDateFormat.FormattingEnabled = true;
            this.cboDefaultDateFormat.IntegralHeight = false;
            this.cboDefaultDateFormat.Location = new System.Drawing.Point(145, 6);
            this.cboDefaultDateFormat.Name = "cboDefaultDateFormat";
            this.cboDefaultDateFormat.PathString = "DefaultDateFormat.Value";
            this.cboDefaultDateFormat.PathValue = null;
            this.cboDefaultDateFormat.Size = new System.Drawing.Size(178, 21);
            this.cboDefaultDateFormat.TabIndex = 2;
            this.cboDefaultDateFormat.Visible = false;
            // 
            // lblDefaultDateFormat
            // 
            this.lblDefaultDateFormat.AppearanceName = "";
            this.lblDefaultDateFormat.ControlID = "";
            this.lblDefaultDateFormat.Location = new System.Drawing.Point(20, 9);
            this.lblDefaultDateFormat.Name = "lblDefaultDateFormat";
            this.lblDefaultDateFormat.PathString = null;
            this.lblDefaultDateFormat.PathValue = "Default Date Format :";
            this.lblDefaultDateFormat.Size = new System.Drawing.Size(119, 13);
            this.lblDefaultDateFormat.TabIndex = 27;
            this.lblDefaultDateFormat.Text = "Default Date Format :";
            this.lblDefaultDateFormat.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblDefaultDateFormat.Visible = false;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.AppearanceName = "";
            this.txtNewPassword.AppearanceReadOnlyName = "";
            this.txtNewPassword.ControlID = "";
            this.txtNewPassword.DisableRestrictChar = false;
            this.txtNewPassword.HelpButton = null;
            this.txtNewPassword.Location = new System.Drawing.Point(147, 176);
            this.txtNewPassword.MaxLength = 15;
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PathString = "Password.Value";
            this.txtNewPassword.PathValue = "";
            this.txtNewPassword.Size = new System.Drawing.Size(178, 20);
            this.txtNewPassword.TabIndex = 5;
            this.txtNewPassword.UseSystemPasswordChar = true;
            // 
            // lblPassWord
            // 
            this.lblPassWord.AppearanceName = "";
            this.lblPassWord.ControlID = "";
            this.lblPassWord.Location = new System.Drawing.Point(51, 179);
            this.lblPassWord.Name = "lblPassWord";
            this.lblPassWord.PathString = null;
            this.lblPassWord.PathValue = "New password :";
            this.lblPassWord.Size = new System.Drawing.Size(90, 17);
            this.lblPassWord.TabIndex = 25;
            this.lblPassWord.Text = "New password :";
            this.lblPassWord.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtUsername
            // 
            this.txtUsername.AppearanceName = "";
            this.txtUsername.AppearanceReadOnlyName = "";
            this.txtUsername.ControlID = "";
            this.txtUsername.DisableRestrictChar = false;
            this.txtUsername.HelpButton = null;
            this.txtUsername.Location = new System.Drawing.Point(145, 102);
            this.txtUsername.MaxLength = 100;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PathString = "Username.Value";
            this.txtUsername.PathValue = "";
            this.txtUsername.Size = new System.Drawing.Size(178, 20);
            this.txtUsername.TabIndex = 1;
            // 
            // lblUserName
            // 
            this.lblUserName.AppearanceName = "";
            this.lblUserName.ControlID = "";
            this.lblUserName.Location = new System.Drawing.Point(72, 105);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.PathString = null;
            this.lblUserName.PathValue = "Full Name :";
            this.lblUserName.Size = new System.Drawing.Size(67, 17);
            this.lblUserName.TabIndex = 23;
            this.lblUserName.Text = "Full Name :";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtUserAccount
            // 
            this.txtUserAccount.AppearanceName = "";
            this.txtUserAccount.AppearanceReadOnlyName = "";
            this.txtUserAccount.ControlID = "";
            this.txtUserAccount.DisableRestrictChar = false;
            this.txtUserAccount.HelpButton = null;
            this.txtUserAccount.Location = new System.Drawing.Point(145, 76);
            this.txtUserAccount.MaxLength = 15;
            this.txtUserAccount.Name = "txtUserAccount";
            this.txtUserAccount.PathString = "UserAccount.Value";
            this.txtUserAccount.PathValue = "";
            this.txtUserAccount.Size = new System.Drawing.Size(178, 20);
            this.txtUserAccount.TabIndex = 0;
            // 
            // lblUserAccount
            // 
            this.lblUserAccount.AppearanceName = "";
            this.lblUserAccount.ControlID = "";
            this.lblUserAccount.Location = new System.Drawing.Point(58, 79);
            this.lblUserAccount.Name = "lblUserAccount";
            this.lblUserAccount.PathString = null;
            this.lblUserAccount.PathValue = "User Account :";
            this.lblUserAccount.Size = new System.Drawing.Size(81, 17);
            this.lblUserAccount.TabIndex = 21;
            this.lblUserAccount.Text = "User Account :";
            this.lblUserAccount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // brLine1
            // 
            this.brLine1.BorderLineColor = System.Drawing.SystemColors.ControlDark;
            this.brLine1.Location = new System.Drawing.Point(23, 139);
            this.brLine1.Name = "brLine1";
            this.brLine1.Size = new System.Drawing.Size(304, 5);
            this.brLine1.Style = EVOFramework.Windows.Forms.EVOBorder.BorderEdgeStyle.Top;
            this.brLine1.TabIndex = 38;
            // 
            // txtConfirmNewPassword
            // 
            this.txtConfirmNewPassword.AppearanceName = "";
            this.txtConfirmNewPassword.AppearanceReadOnlyName = "";
            this.txtConfirmNewPassword.ControlID = "";
            this.txtConfirmNewPassword.DisableRestrictChar = false;
            this.txtConfirmNewPassword.HelpButton = null;
            this.txtConfirmNewPassword.Location = new System.Drawing.Point(147, 202);
            this.txtConfirmNewPassword.MaxLength = 15;
            this.txtConfirmNewPassword.Name = "txtConfirmNewPassword";
            this.txtConfirmNewPassword.PasswordChar = '*';
            this.txtConfirmNewPassword.PathString = "ConfirmPassword.Value";
            this.txtConfirmNewPassword.PathValue = "";
            this.txtConfirmNewPassword.Size = new System.Drawing.Size(178, 20);
            this.txtConfirmNewPassword.TabIndex = 6;
            this.txtConfirmNewPassword.UseSystemPasswordChar = true;
            // 
            // evoLabel1
            // 
            this.evoLabel1.AppearanceName = "";
            this.evoLabel1.ControlID = "";
            this.evoLabel1.Location = new System.Drawing.Point(22, 205);
            this.evoLabel1.Name = "evoLabel1";
            this.evoLabel1.PathString = null;
            this.evoLabel1.PathValue = "Confirm new password :";
            this.evoLabel1.Size = new System.Drawing.Size(119, 13);
            this.evoLabel1.TabIndex = 40;
            this.evoLabel1.Text = "Confirm new password :";
            this.evoLabel1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // evoLabel2
            // 
            this.evoLabel2.AppearanceName = "";
            this.evoLabel2.ControlID = "";
            this.evoLabel2.Location = new System.Drawing.Point(61, 153);
            this.evoLabel2.Name = "evoLabel2";
            this.evoLabel2.PathString = null;
            this.evoLabel2.PathValue = "Old password:";
            this.evoLabel2.Size = new System.Drawing.Size(80, 17);
            this.evoLabel2.TabIndex = 41;
            this.evoLabel2.Text = "Old password:";
            this.evoLabel2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtCurrentPassword
            // 
            this.txtCurrentPassword.AppearanceName = "";
            this.txtCurrentPassword.AppearanceReadOnlyName = "";
            this.txtCurrentPassword.ControlID = "";
            this.txtCurrentPassword.DisableRestrictChar = false;
            this.txtCurrentPassword.HelpButton = null;
            this.txtCurrentPassword.Location = new System.Drawing.Point(147, 150);
            this.txtCurrentPassword.MaxLength = 15;
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.PathString = "CurrentPassword.Value";
            this.txtCurrentPassword.PathValue = "";
            this.txtCurrentPassword.Size = new System.Drawing.Size(178, 20);
            this.txtCurrentPassword.TabIndex = 4;
            this.txtCurrentPassword.UseSystemPasswordChar = true;
            // 
            // evoBorder1
            // 
            this.evoBorder1.BorderLineColor = System.Drawing.SystemColors.ControlDark;
            this.evoBorder1.Location = new System.Drawing.Point(23, 128);
            this.evoBorder1.Name = "evoBorder1";
            this.evoBorder1.Size = new System.Drawing.Size(304, 5);
            this.evoBorder1.Style = EVOFramework.Windows.Forms.EVOBorder.BorderEdgeStyle.Top;
            this.evoBorder1.TabIndex = 39;
            this.evoBorder1.Visible = false;
            // 
            // evoBorder2
            // 
            this.evoBorder2.BorderLineColor = System.Drawing.SystemColors.ControlDark;
            this.evoBorder2.Location = new System.Drawing.Point(25, 228);
            this.evoBorder2.Name = "evoBorder2";
            this.evoBorder2.Size = new System.Drawing.Size(304, 5);
            this.evoBorder2.Style = EVOFramework.Windows.Forms.EVOBorder.BorderEdgeStyle.Top;
            this.evoBorder2.TabIndex = 39;
            // 
            // evoLabel3
            // 
            this.evoLabel3.AppearanceName = "";
            this.evoLabel3.ControlID = "";
            this.evoLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel3.ForeColor = System.Drawing.Color.Red;
            this.evoLabel3.Location = new System.Drawing.Point(45, 76);
            this.evoLabel3.Name = "evoLabel3";
            this.evoLabel3.PathString = null;
            this.evoLabel3.PathValue = "*";
            this.evoLabel3.Size = new System.Drawing.Size(14, 20);
            this.evoLabel3.TabIndex = 22;
            this.evoLabel3.Text = "*";
            this.evoLabel3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // evoLabel4
            // 
            this.evoLabel4.AppearanceName = "";
            this.evoLabel4.ControlID = "";
            this.evoLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel4.ForeColor = System.Drawing.Color.Red;
            this.evoLabel4.Location = new System.Drawing.Point(62, 102);
            this.evoLabel4.Name = "evoLabel4";
            this.evoLabel4.PathString = null;
            this.evoLabel4.PathValue = "*";
            this.evoLabel4.Size = new System.Drawing.Size(14, 20);
            this.evoLabel4.TabIndex = 42;
            this.evoLabel4.Text = "*";
            this.evoLabel4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // evoLabel5
            // 
            this.evoLabel5.AppearanceName = "";
            this.evoLabel5.ControlID = "";
            this.evoLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel5.ForeColor = System.Drawing.Color.Red;
            this.evoLabel5.Location = new System.Drawing.Point(49, 150);
            this.evoLabel5.Name = "evoLabel5";
            this.evoLabel5.PathString = null;
            this.evoLabel5.PathValue = "*";
            this.evoLabel5.Size = new System.Drawing.Size(17, 20);
            this.evoLabel5.TabIndex = 43;
            this.evoLabel5.Text = "*";
            this.evoLabel5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // evoLabel6
            // 
            this.evoLabel6.AppearanceName = "";
            this.evoLabel6.ControlID = "";
            this.evoLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel6.ForeColor = System.Drawing.Color.Red;
            this.evoLabel6.Location = new System.Drawing.Point(41, 176);
            this.evoLabel6.Name = "evoLabel6";
            this.evoLabel6.PathString = null;
            this.evoLabel6.PathValue = "*";
            this.evoLabel6.Size = new System.Drawing.Size(14, 20);
            this.evoLabel6.TabIndex = 44;
            this.evoLabel6.Text = "*";
            this.evoLabel6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // evoLabel7
            // 
            this.evoLabel7.AppearanceName = "";
            this.evoLabel7.ControlID = "";
            this.evoLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel7.ForeColor = System.Drawing.Color.Red;
            this.evoLabel7.Location = new System.Drawing.Point(8, 202);
            this.evoLabel7.Name = "evoLabel7";
            this.evoLabel7.PathString = null;
            this.evoLabel7.PathValue = "*";
            this.evoLabel7.Size = new System.Drawing.Size(14, 20);
            this.evoLabel7.TabIndex = 45;
            this.evoLabel7.Text = "*";
            this.evoLabel7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SFM0035_UserProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 279);
            this.Controls.Add(this.evoLabel7);
            this.Controls.Add(this.evoLabel6);
            this.Controls.Add(this.evoLabel5);
            this.Controls.Add(this.evoLabel4);
            this.Controls.Add(this.evoLabel3);
            this.Controls.Add(this.evoBorder2);
            this.Controls.Add(this.evoBorder1);
            this.Controls.Add(this.txtCurrentPassword);
            this.Controls.Add(this.evoLabel2);
            this.Controls.Add(this.evoLabel1);
            this.Controls.Add(this.txtConfirmNewPassword);
            this.Controls.Add(this.brLine1);
            this.Controls.Add(this.picUser);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboDefaultLang);
            this.Controls.Add(this.lblDefaultLang);
            this.Controls.Add(this.cboDefaultDateFormat);
            this.Controls.Add(this.lblDefaultDateFormat);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.lblPassWord);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.txtUserAccount);
            this.Controls.Add(this.lblUserAccount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SFM0035_UserProfile";
            this.Text = "SFM0035_UserProfile";
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picUser;
        private EVOFramework.Windows.Forms.EVOButton btnCancel;
        private EVOFramework.Windows.Forms.EVOButton btnSave;
        private EVOFramework.Windows.Forms.EVOComboBox cboDefaultLang;
        private EVOFramework.Windows.Forms.EVOLabel lblDefaultLang;
        private EVOFramework.Windows.Forms.EVOComboBox cboDefaultDateFormat;
        private EVOFramework.Windows.Forms.EVOLabel lblDefaultDateFormat;
        private EVOFramework.Windows.Forms.EVOTextBox txtNewPassword;
        private EVOFramework.Windows.Forms.EVOLabel lblPassWord;
        private EVOFramework.Windows.Forms.EVOTextBox txtUsername;
        private EVOFramework.Windows.Forms.EVOLabel lblUserName;
        private EVOFramework.Windows.Forms.EVOTextBox txtUserAccount;
        private EVOFramework.Windows.Forms.EVOLabel lblUserAccount;
        private EVOFramework.Windows.Forms.EVOBorder brLine1;
        private EVOFramework.Windows.Forms.EVOTextBox txtConfirmNewPassword;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel1;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel2;
        private EVOFramework.Windows.Forms.EVOTextBox txtCurrentPassword;
        private EVOFramework.Windows.Forms.EVOBorder evoBorder1;
        private EVOFramework.Data.UIDataModelController dmcUserProfile;
        private EVOFramework.Windows.Forms.EVOBorder evoBorder2;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel3;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel4;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel5;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel6;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel7;
    }
}