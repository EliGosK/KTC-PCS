namespace SystemMaintenance.Forms
{
    partial class SFM0033_GroupProperty
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
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.txtGroupCD = new EVOFramework.Windows.Forms.EVOTextBox();
            this.grpMember = new System.Windows.Forms.GroupBox();
            this.fpUser = new FarPoint.Win.Spread.FpSpread();
            this.shtUser = new FarPoint.Win.Spread.SheetView();
            this.txtGoupDesc = new EVOFramework.Windows.Forms.EVOTextBox();
            this.btnCancel = new EVOFramework.Windows.Forms.EVOButton();
            this.btnAdd = new EVOFramework.Windows.Forms.EVOButton();
            this.btnRemove = new EVOFramework.Windows.Forms.EVOButton();
            this.dmcGroupProperty = new EVOFramework.Data.UIDataModelController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.grpMember.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtUser)).BeginInit();
            this.SuspendLayout();
            // 
            // picIcon
            // 
            this.picIcon.Image = global::SystemMaintenance.Properties.Resources.GROUP_USER;
            this.picIcon.Location = new System.Drawing.Point(70, 14);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(63, 61);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picIcon.TabIndex = 0;
            this.picIcon.TabStop = false;
            // 
            // txtGroupCD
            // 
            this.txtGroupCD.AppearanceName = "";
            this.txtGroupCD.AppearanceReadOnlyName = "";
            this.txtGroupCD.ControlID = "";
            this.txtGroupCD.DisableRestrictChar = false;
            this.txtGroupCD.HelpButton = null;
            this.txtGroupCD.Location = new System.Drawing.Point(150, 22);
            this.txtGroupCD.MaxLength = 15;
            this.txtGroupCD.Name = "txtGroupCD";
            this.txtGroupCD.PathString = "GroupCD.Value";
            this.txtGroupCD.PathValue = "";
            this.txtGroupCD.Size = new System.Drawing.Size(190, 20);
            this.txtGroupCD.TabIndex = 23;
            // 
            // grpMember
            // 
            this.grpMember.Controls.Add(this.fpUser);
            this.grpMember.Location = new System.Drawing.Point(12, 81);
            this.grpMember.Name = "grpMember";
            this.grpMember.Size = new System.Drawing.Size(409, 284);
            this.grpMember.TabIndex = 24;
            this.grpMember.TabStop = false;
            this.grpMember.Text = "Member";
            // 
            // fpUser
            // 
            this.fpUser.About = "2.5.2015.2005";
            this.fpUser.AccessibleDescription = "fpUser, Sheet1, Row 0, Column 0, ";
            this.fpUser.BackColor = System.Drawing.Color.Transparent;
            this.fpUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpUser.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpUser.Location = new System.Drawing.Point(3, 16);
            this.fpUser.Name = "fpUser";
            this.fpUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpUser.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtUser});
            this.fpUser.Size = new System.Drawing.Size(403, 265);
            this.fpUser.TabIndex = 1;
            this.fpUser.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // shtUser
            // 
            this.shtUser.Reset();
            this.shtUser.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtUser.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtUser.ColumnCount = 2;
            this.shtUser.RowCount = 0;
            this.shtUser.AutoGenerateColumns = false;
            this.shtUser.ColumnHeader.Cells.Get(0, 0).Value = "User Account";
            this.shtUser.ColumnHeader.Cells.Get(0, 1).Value = "User Name";
            this.shtUser.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtUser.Columns.Get(0).Label = "User Account";
            this.shtUser.Columns.Get(0).Tag = "UserAccount";
            this.shtUser.Columns.Get(0).Width = 132F;
            this.shtUser.Columns.Get(1).Label = "User Name";
            this.shtUser.Columns.Get(1).Tag = "UserName";
            this.shtUser.Columns.Get(1).Width = 201F;
            this.shtUser.DataAutoCellTypes = false;
            this.shtUser.DataAutoHeadings = false;
            this.shtUser.DataAutoSizeColumns = false;
            this.shtUser.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.shtUser.RowHeader.Columns.Default.Resizable = true;
            this.shtUser.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.shtUser.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.shtUser.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpUser.SetActiveViewport(0, 1, 0);
            // 
            // txtGoupDesc
            // 
            this.txtGoupDesc.AppearanceName = "";
            this.txtGoupDesc.AppearanceReadOnlyName = "";
            this.txtGoupDesc.ControlID = "";
            this.txtGoupDesc.DisableRestrictChar = false;
            this.txtGoupDesc.HelpButton = null;
            this.txtGoupDesc.Location = new System.Drawing.Point(150, 48);
            this.txtGoupDesc.MaxLength = 30;
            this.txtGoupDesc.Name = "txtGoupDesc";
            this.txtGoupDesc.PathString = "GroupDesc.Value";
            this.txtGoupDesc.PathValue = "";
            this.txtGoupDesc.Size = new System.Drawing.Size(190, 20);
            this.txtGoupDesc.TabIndex = 25;
            this.txtGoupDesc.Leave += new System.EventHandler(this.txtGoupDesc_Leave);
            // 
            // btnCancel
            // 
            this.btnCancel.AppearanceName = "";
            this.btnCancel.ControlID = "";
            this.btnCancel.Location = new System.Drawing.Point(343, 377);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AppearanceName = "";
            this.btnAdd.ControlID = "";
            this.btnAdd.Location = new System.Drawing.Point(12, 377);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 26;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.AppearanceName = "";
            this.btnRemove.ControlID = "";
            this.btnRemove.Location = new System.Drawing.Point(93, 377);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 28;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // SFM0033_GroupProperty
            // 
            this.ClientSize = new System.Drawing.Size(433, 412);
            this.ControlBox = false;
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtGoupDesc);
            this.Controls.Add(this.grpMember);
            this.Controls.Add(this.txtGroupCD);
            this.Controls.Add(this.picIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SFM0033_GroupProperty";
            this.Text = "Group Properties";
            this.Load += new System.EventHandler(this.SFM0033_GroupProperty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.grpMember.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picIcon;
        private EVOFramework.Windows.Forms.EVOTextBox txtGroupCD;
        private System.Windows.Forms.GroupBox grpMember;
        private FarPoint.Win.Spread.FpSpread fpUser;
        private FarPoint.Win.Spread.SheetView shtUser;
        private EVOFramework.Windows.Forms.EVOTextBox txtGoupDesc;
        private EVOFramework.Windows.Forms.EVOButton btnCancel;
        private EVOFramework.Windows.Forms.EVOButton btnAdd;
        private EVOFramework.Windows.Forms.EVOButton btnRemove;
        private EVOFramework.Data.UIDataModelController dmcGroupProperty;
    }
}
