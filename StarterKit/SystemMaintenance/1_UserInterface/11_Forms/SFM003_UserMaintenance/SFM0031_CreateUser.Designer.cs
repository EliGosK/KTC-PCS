namespace SystemMaintenance.Forms
{
    partial class SFM0031_CreateUser
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
            this.lblUserAccount = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtUserAccount = new EVOFramework.Windows.Forms.EVOTextBox();
            this.txtUserName = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblUserName = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtPassWord = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblPassWord = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblDefaultDateFormat = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboDefaultDateFormat = new EVOFramework.Windows.Forms.EVOComboBox();
            this.cboDefaultLang = new EVOFramework.Windows.Forms.EVOComboBox();
            this.lblDefaultLang = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboGroupUser = new EVOFramework.Windows.Forms.EVOComboBox();
            this.lblGroupUser = new EVOFramework.Windows.Forms.EVOLabel();
            this.btnSave = new EVOFramework.Windows.Forms.EVOButton();
            this.btnCancel = new EVOFramework.Windows.Forms.EVOButton();
            this.chkIsActive = new EVOFramework.Windows.Forms.EVOCheckBox();
            this.chkIsResign = new EVOFramework.Windows.Forms.EVOCheckBox();
            this.dmcCreateUserAccount = new EVOFramework.Data.UIDataModelController(this.components);
            this.picUser = new System.Windows.Forms.PictureBox();
            this.cboMenuSet = new EVOFramework.Windows.Forms.EVOComboBox();
            this.lblMenuSet = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel3 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel2 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel4 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel5 = new EVOFramework.Windows.Forms.EVOLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUserAccount
            // 
            this.lblUserAccount.AppearanceName = "";
            this.lblUserAccount.AutoSize = true;
            this.lblUserAccount.ControlID = "";
            this.lblUserAccount.Location = new System.Drawing.Point(45, 78);
            this.lblUserAccount.Name = "lblUserAccount";
            this.lblUserAccount.PathString = null;
            this.lblUserAccount.PathValue = "User Account";
            this.lblUserAccount.Size = new System.Drawing.Size(72, 13);
            this.lblUserAccount.TabIndex = 0;
            this.lblUserAccount.Text = "User Account";
            // 
            // txtUserAccount
            // 
            this.txtUserAccount.AppearanceName = "";
            this.txtUserAccount.AppearanceReadOnlyName = "";
            this.txtUserAccount.ControlID = "";
            this.txtUserAccount.DisableRestrictChar = false;
            this.txtUserAccount.HelpButton = null;
            this.txtUserAccount.Location = new System.Drawing.Point(120, 75);
            this.txtUserAccount.MaxLength = 15;
            this.txtUserAccount.Name = "txtUserAccount";
            this.txtUserAccount.PathString = "UserAccount.Value";
            this.txtUserAccount.PathValue = "";
            this.txtUserAccount.Size = new System.Drawing.Size(190, 20);
            this.txtUserAccount.TabIndex = 1;
            // 
            // txtUserName
            // 
            this.txtUserName.AppearanceName = "";
            this.txtUserName.AppearanceReadOnlyName = "";
            this.txtUserName.ControlID = "";
            this.txtUserName.DisableRestrictChar = false;
            this.txtUserName.HelpButton = null;
            this.txtUserName.Location = new System.Drawing.Point(120, 101);
            this.txtUserName.MaxLength = 15;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.PathString = "UserName.Value";
            this.txtUserName.PathValue = "";
            this.txtUserName.Size = new System.Drawing.Size(190, 20);
            this.txtUserName.TabIndex = 3;
            // 
            // lblUserName
            // 
            this.lblUserName.AppearanceName = "";
            this.lblUserName.AutoSize = true;
            this.lblUserName.ControlID = "";
            this.lblUserName.Location = new System.Drawing.Point(45, 104);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.PathString = null;
            this.lblUserName.PathValue = "Full Name";
            this.lblUserName.Size = new System.Drawing.Size(54, 13);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "Full Name";
            // 
            // txtPassWord
            // 
            this.txtPassWord.AppearanceName = "";
            this.txtPassWord.AppearanceReadOnlyName = "";
            this.txtPassWord.ControlID = "";
            this.txtPassWord.DisableRestrictChar = false;
            this.txtPassWord.HelpButton = null;
            this.txtPassWord.Location = new System.Drawing.Point(120, 127);
            this.txtPassWord.MaxLength = 50;
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PathString = "PassWord.Value";
            this.txtPassWord.PathValue = "";
            this.txtPassWord.Size = new System.Drawing.Size(190, 20);
            this.txtPassWord.TabIndex = 5;
            this.txtPassWord.UseSystemPasswordChar = true;
            // 
            // lblPassWord
            // 
            this.lblPassWord.AppearanceName = "";
            this.lblPassWord.AutoSize = true;
            this.lblPassWord.ControlID = "";
            this.lblPassWord.Location = new System.Drawing.Point(45, 130);
            this.lblPassWord.Name = "lblPassWord";
            this.lblPassWord.PathString = null;
            this.lblPassWord.PathValue = "Password";
            this.lblPassWord.Size = new System.Drawing.Size(53, 13);
            this.lblPassWord.TabIndex = 4;
            this.lblPassWord.Text = "Password";
            // 
            // lblDefaultDateFormat
            // 
            this.lblDefaultDateFormat.AppearanceName = "";
            this.lblDefaultDateFormat.AutoSize = true;
            this.lblDefaultDateFormat.ControlID = "";
            this.lblDefaultDateFormat.Location = new System.Drawing.Point(7, 27);
            this.lblDefaultDateFormat.Name = "lblDefaultDateFormat";
            this.lblDefaultDateFormat.PathString = null;
            this.lblDefaultDateFormat.PathValue = "Default Date Format";
            this.lblDefaultDateFormat.Size = new System.Drawing.Size(102, 13);
            this.lblDefaultDateFormat.TabIndex = 6;
            this.lblDefaultDateFormat.Text = "Default Date Format";
            this.lblDefaultDateFormat.Visible = false;
            // 
            // cboDefaultDateFormat
            // 
            this.cboDefaultDateFormat.AppearanceName = "";
            this.cboDefaultDateFormat.AppearanceReadOnlyName = "";
            this.cboDefaultDateFormat.ControlID = null;
            this.cboDefaultDateFormat.DropDownHeight = 180;
            this.cboDefaultDateFormat.FormattingEnabled = true;
            this.cboDefaultDateFormat.IntegralHeight = false;
            this.cboDefaultDateFormat.Location = new System.Drawing.Point(120, 24);
            this.cboDefaultDateFormat.Name = "cboDefaultDateFormat";
            this.cboDefaultDateFormat.PathString = "DefaultDateFormat.Value";
            this.cboDefaultDateFormat.PathValue = null;
            this.cboDefaultDateFormat.Size = new System.Drawing.Size(190, 21);
            this.cboDefaultDateFormat.TabIndex = 11;
            this.cboDefaultDateFormat.Visible = false;
            // 
            // cboDefaultLang
            // 
            this.cboDefaultLang.AppearanceName = "";
            this.cboDefaultLang.AppearanceReadOnlyName = "";
            this.cboDefaultLang.ControlID = null;
            this.cboDefaultLang.DropDownHeight = 180;
            this.cboDefaultLang.FormattingEnabled = true;
            this.cboDefaultLang.IntegralHeight = false;
            this.cboDefaultLang.Location = new System.Drawing.Point(111, 48);
            this.cboDefaultLang.Name = "cboDefaultLang";
            this.cboDefaultLang.PathString = "DefaultLang.Value";
            this.cboDefaultLang.PathValue = null;
            this.cboDefaultLang.Size = new System.Drawing.Size(190, 21);
            this.cboDefaultLang.TabIndex = 13;
            this.cboDefaultLang.Visible = false;
            // 
            // lblDefaultLang
            // 
            this.lblDefaultLang.AppearanceName = "";
            this.lblDefaultLang.AutoSize = true;
            this.lblDefaultLang.ControlID = "";
            this.lblDefaultLang.Location = new System.Drawing.Point(32, 51);
            this.lblDefaultLang.Name = "lblDefaultLang";
            this.lblDefaultLang.PathString = null;
            this.lblDefaultLang.PathValue = "Default Lang";
            this.lblDefaultLang.Size = new System.Drawing.Size(68, 13);
            this.lblDefaultLang.TabIndex = 12;
            this.lblDefaultLang.Text = "Default Lang";
            this.lblDefaultLang.Visible = false;
            // 
            // cboGroupUser
            // 
            this.cboGroupUser.AppearanceName = "";
            this.cboGroupUser.AppearanceReadOnlyName = "";
            this.cboGroupUser.ControlID = null;
            this.cboGroupUser.DropDownHeight = 180;
            this.cboGroupUser.FormattingEnabled = true;
            this.cboGroupUser.IntegralHeight = false;
            this.cboGroupUser.Location = new System.Drawing.Point(120, 153);
            this.cboGroupUser.Name = "cboGroupUser";
            this.cboGroupUser.PathString = "GroupUser.Value";
            this.cboGroupUser.PathValue = null;
            this.cboGroupUser.Size = new System.Drawing.Size(190, 21);
            this.cboGroupUser.TabIndex = 15;
            // 
            // lblGroupUser
            // 
            this.lblGroupUser.AppearanceName = "";
            this.lblGroupUser.AutoSize = true;
            this.lblGroupUser.ControlID = "";
            this.lblGroupUser.Location = new System.Drawing.Point(45, 156);
            this.lblGroupUser.Name = "lblGroupUser";
            this.lblGroupUser.PathString = null;
            this.lblGroupUser.PathValue = "Group User";
            this.lblGroupUser.Size = new System.Drawing.Size(61, 13);
            this.lblGroupUser.TabIndex = 14;
            this.lblGroupUser.Text = "Group User";
            // 
            // btnSave
            // 
            this.btnSave.AppearanceName = "";
            this.btnSave.ControlID = "";
            this.btnSave.Location = new System.Drawing.Point(154, 267);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AppearanceName = "";
            this.btnCancel.ControlID = "";
            this.btnCancel.Location = new System.Drawing.Point(235, 267);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkIsActive
            // 
            this.chkIsActive.AppearanceName = "";
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckedValue = "1";
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.ControlID = null;
            this.chkIsActive.Location = new System.Drawing.Point(120, 211);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.PathString = "IsActive.Value";
            this.chkIsActive.PathValue = true;
            this.chkIsActive.Size = new System.Drawing.Size(67, 17);
            this.chkIsActive.TabIndex = 18;
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.UnCheckedValue = "0";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // chkIsResign
            // 
            this.chkIsResign.AppearanceName = "";
            this.chkIsResign.AutoSize = true;
            this.chkIsResign.CheckedValue = "1";
            this.chkIsResign.ControlID = null;
            this.chkIsResign.Location = new System.Drawing.Point(120, 234);
            this.chkIsResign.Name = "chkIsResign";
            this.chkIsResign.PathString = "IsResign.Value";
            this.chkIsResign.PathValue = false;
            this.chkIsResign.Size = new System.Drawing.Size(59, 17);
            this.chkIsResign.TabIndex = 19;
            this.chkIsResign.Text = "Resign";
            this.chkIsResign.UnCheckedValue = "0";
            this.chkIsResign.UseVisualStyleBackColor = true;
            this.chkIsResign.Visible = false;
            // 
            // picUser
            // 
            this.picUser.Image = global::SystemMaintenance.Properties.Resources.USER;
            this.picUser.Location = new System.Drawing.Point(248, 11);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(62, 58);
            this.picUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUser.TabIndex = 20;
            this.picUser.TabStop = false;
            // 
            // cboMenuSet
            // 
            this.cboMenuSet.AppearanceName = "";
            this.cboMenuSet.AppearanceReadOnlyName = "";
            this.cboMenuSet.ControlID = null;
            this.cboMenuSet.DropDownHeight = 180;
            this.cboMenuSet.FormattingEnabled = true;
            this.cboMenuSet.IntegralHeight = false;
            this.cboMenuSet.Location = new System.Drawing.Point(120, 180);
            this.cboMenuSet.Name = "cboMenuSet";
            this.cboMenuSet.PathString = "MenuSet.Value";
            this.cboMenuSet.PathValue = null;
            this.cboMenuSet.Size = new System.Drawing.Size(190, 21);
            this.cboMenuSet.TabIndex = 22;
            // 
            // lblMenuSet
            // 
            this.lblMenuSet.AppearanceName = "";
            this.lblMenuSet.AutoSize = true;
            this.lblMenuSet.ControlID = "";
            this.lblMenuSet.Location = new System.Drawing.Point(45, 183);
            this.lblMenuSet.Name = "lblMenuSet";
            this.lblMenuSet.PathString = null;
            this.lblMenuSet.PathValue = "Menu Set";
            this.lblMenuSet.Size = new System.Drawing.Size(53, 13);
            this.lblMenuSet.TabIndex = 21;
            this.lblMenuSet.Text = "Menu Set";
            // 
            // evoLabel3
            // 
            this.evoLabel3.AppearanceName = "";
            this.evoLabel3.ControlID = "";
            this.evoLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel3.ForeColor = System.Drawing.Color.Red;
            this.evoLabel3.Location = new System.Drawing.Point(25, 75);
            this.evoLabel3.Name = "evoLabel3";
            this.evoLabel3.PathString = null;
            this.evoLabel3.PathValue = "*";
            this.evoLabel3.Size = new System.Drawing.Size(14, 20);
            this.evoLabel3.TabIndex = 23;
            this.evoLabel3.Text = "*";
            this.evoLabel3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // evoLabel1
            // 
            this.evoLabel1.AppearanceName = "";
            this.evoLabel1.ControlID = "";
            this.evoLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel1.ForeColor = System.Drawing.Color.Red;
            this.evoLabel1.Location = new System.Drawing.Point(25, 101);
            this.evoLabel1.Name = "evoLabel1";
            this.evoLabel1.PathString = null;
            this.evoLabel1.PathValue = "*";
            this.evoLabel1.Size = new System.Drawing.Size(14, 20);
            this.evoLabel1.TabIndex = 24;
            this.evoLabel1.Text = "*";
            this.evoLabel1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // evoLabel2
            // 
            this.evoLabel2.AppearanceName = "";
            this.evoLabel2.ControlID = "";
            this.evoLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel2.ForeColor = System.Drawing.Color.Red;
            this.evoLabel2.Location = new System.Drawing.Point(25, 127);
            this.evoLabel2.Name = "evoLabel2";
            this.evoLabel2.PathString = null;
            this.evoLabel2.PathValue = "*";
            this.evoLabel2.Size = new System.Drawing.Size(14, 20);
            this.evoLabel2.TabIndex = 24;
            this.evoLabel2.Text = "*";
            this.evoLabel2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // evoLabel4
            // 
            this.evoLabel4.AppearanceName = "";
            this.evoLabel4.ControlID = "";
            this.evoLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel4.ForeColor = System.Drawing.Color.Red;
            this.evoLabel4.Location = new System.Drawing.Point(25, 153);
            this.evoLabel4.Name = "evoLabel4";
            this.evoLabel4.PathString = null;
            this.evoLabel4.PathValue = "*";
            this.evoLabel4.Size = new System.Drawing.Size(14, 20);
            this.evoLabel4.TabIndex = 24;
            this.evoLabel4.Text = "*";
            this.evoLabel4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // evoLabel5
            // 
            this.evoLabel5.AppearanceName = "";
            this.evoLabel5.ControlID = "";
            this.evoLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel5.ForeColor = System.Drawing.Color.Red;
            this.evoLabel5.Location = new System.Drawing.Point(25, 180);
            this.evoLabel5.Name = "evoLabel5";
            this.evoLabel5.PathString = null;
            this.evoLabel5.PathValue = "*";
            this.evoLabel5.Size = new System.Drawing.Size(14, 20);
            this.evoLabel5.TabIndex = 24;
            this.evoLabel5.Text = "*";
            this.evoLabel5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SFM0031_CreateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(334, 302);
            this.ControlBox = false;
            this.Controls.Add(this.evoLabel5);
            this.Controls.Add(this.evoLabel4);
            this.Controls.Add(this.evoLabel2);
            this.Controls.Add(this.evoLabel1);
            this.Controls.Add(this.evoLabel3);
            this.Controls.Add(this.cboMenuSet);
            this.Controls.Add(this.lblMenuSet);
            this.Controls.Add(this.picUser);
            this.Controls.Add(this.chkIsResign);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboGroupUser);
            this.Controls.Add(this.lblGroupUser);
            this.Controls.Add(this.cboDefaultLang);
            this.Controls.Add(this.lblDefaultLang);
            this.Controls.Add(this.cboDefaultDateFormat);
            this.Controls.Add(this.lblDefaultDateFormat);
            this.Controls.Add(this.txtPassWord);
            this.Controls.Add(this.lblPassWord);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.txtUserAccount);
            this.Controls.Add(this.lblUserAccount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SFM0031_CreateUser";
            this.Text = "Create User Account";
            this.Load += new System.EventHandler(this.SFM0031_CreateUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EVOFramework.Windows.Forms.EVOLabel lblUserAccount;
        private EVOFramework.Windows.Forms.EVOTextBox txtUserAccount;
        private EVOFramework.Windows.Forms.EVOTextBox txtUserName;
        private EVOFramework.Windows.Forms.EVOLabel lblUserName;
        private EVOFramework.Windows.Forms.EVOTextBox txtPassWord;
        private EVOFramework.Windows.Forms.EVOLabel lblPassWord;
        private EVOFramework.Windows.Forms.EVOLabel lblDefaultDateFormat;
        private EVOFramework.Windows.Forms.EVOComboBox cboDefaultDateFormat;
        private EVOFramework.Windows.Forms.EVOComboBox cboDefaultLang;
        private EVOFramework.Windows.Forms.EVOLabel lblDefaultLang;
        private EVOFramework.Windows.Forms.EVOComboBox cboGroupUser;
        private EVOFramework.Windows.Forms.EVOLabel lblGroupUser;
        private EVOFramework.Windows.Forms.EVOButton btnSave;
        private EVOFramework.Windows.Forms.EVOButton btnCancel;
        private EVOFramework.Windows.Forms.EVOCheckBox chkIsActive;
        private EVOFramework.Windows.Forms.EVOCheckBox chkIsResign;
        private EVOFramework.Data.UIDataModelController dmcCreateUserAccount;
        private System.Windows.Forms.PictureBox picUser;
        private EVOFramework.Windows.Forms.EVOComboBox cboMenuSet;
        private EVOFramework.Windows.Forms.EVOLabel lblMenuSet;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel3;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel1;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel2;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel4;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel5;
    }
}
