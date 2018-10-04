namespace SystemMaintenance.Forms
{
    partial class SFM0032_UserList
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
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            this.grpMember = new System.Windows.Forms.GroupBox();
            this.fpUser = new FarPoint.Win.Spread.FpSpread();
            this.cmsSelectHelper = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectNoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertSelectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shtUser = new FarPoint.Win.Spread.SheetView();
            this.btnCancel = new EVOFramework.Windows.Forms.EVOButton();
            this.btnAdd = new EVOFramework.Windows.Forms.EVOButton();
            this.grpMember.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpUser)).BeginInit();
            this.cmsSelectHelper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shtUser)).BeginInit();
            this.SuspendLayout();
            // 
            // grpMember
            // 
            this.grpMember.Controls.Add(this.fpUser);
            this.grpMember.Location = new System.Drawing.Point(12, 12);
            this.grpMember.Name = "grpMember";
            this.grpMember.Size = new System.Drawing.Size(447, 349);
            this.grpMember.TabIndex = 25;
            this.grpMember.TabStop = false;
            this.grpMember.Text = "Member";
            // 
            // fpUser
            // 
            this.fpUser.About = "2.5.2015.2005";
            this.fpUser.AccessibleDescription = "fpUser, Sheet1";
            this.fpUser.BackColor = System.Drawing.Color.Transparent;
            this.fpUser.ContextMenuStrip = this.cmsSelectHelper;
            this.fpUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpUser.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpUser.Location = new System.Drawing.Point(3, 16);
            this.fpUser.Name = "fpUser";
            this.fpUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpUser.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtUser});
            this.fpUser.Size = new System.Drawing.Size(441, 330);
            this.fpUser.TabIndex = 1;
            this.fpUser.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // cmsSelectHelper
            // 
            this.cmsSelectHelper.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.selectNoneToolStripMenuItem,
            this.invertSelectToolStripMenuItem});
            this.cmsSelectHelper.Name = "cmsSelectHelper";
            this.cmsSelectHelper.Size = new System.Drawing.Size(137, 70);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // selectNoneToolStripMenuItem
            // 
            this.selectNoneToolStripMenuItem.Name = "selectNoneToolStripMenuItem";
            this.selectNoneToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.selectNoneToolStripMenuItem.Text = "Select None";
            this.selectNoneToolStripMenuItem.Click += new System.EventHandler(this.selectNoneToolStripMenuItem_Click);
            // 
            // invertSelectToolStripMenuItem
            // 
            this.invertSelectToolStripMenuItem.Name = "invertSelectToolStripMenuItem";
            this.invertSelectToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.invertSelectToolStripMenuItem.Text = "Invert Select";
            this.invertSelectToolStripMenuItem.Click += new System.EventHandler(this.invertSelectToolStripMenuItem_Click);
            // 
            // shtUser
            // 
            this.shtUser.Reset();
            this.shtUser.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtUser.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtUser.ColumnCount = 3;
            this.shtUser.RowCount = 0;
            this.shtUser.AutoGenerateColumns = false;
            this.shtUser.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.shtUser.ColumnHeader.Cells.Get(0, 1).Value = "User Account";
            this.shtUser.ColumnHeader.Cells.Get(0, 2).Value = "User Name";
            this.shtUser.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtUser.Columns.Get(0).CellType = checkBoxCellType1;
            this.shtUser.Columns.Get(0).Label = "Sel";
            this.shtUser.Columns.Get(0).Tag = "Sel";
            this.shtUser.Columns.Get(0).Width = 32F;
            this.shtUser.Columns.Get(1).Label = "User Account";
            this.shtUser.Columns.Get(1).Tag = "UserAccount";
            this.shtUser.Columns.Get(1).Width = 150F;
            this.shtUser.Columns.Get(2).Label = "User Name";
            this.shtUser.Columns.Get(2).Tag = "UserName";
            this.shtUser.Columns.Get(2).Width = 198F;
            this.shtUser.DataAutoCellTypes = false;
            this.shtUser.DataAutoHeadings = false;
            this.shtUser.DataAutoSizeColumns = false;
            this.shtUser.RowHeader.Columns.Default.Resizable = true;
            this.shtUser.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpUser.SetActiveViewport(0, 1, 0);
            // 
            // btnCancel
            // 
            this.btnCancel.AppearanceName = "";
            this.btnCancel.ControlID = "";
            this.btnCancel.Location = new System.Drawing.Point(374, 377);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AppearanceName = "";
            this.btnAdd.ControlID = "";
            this.btnAdd.Location = new System.Drawing.Point(293, 377);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 28;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // SFM0032_UserList
            // 
            this.ClientSize = new System.Drawing.Size(471, 412);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.grpMember);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "SFM0032_UserList";
            this.Text = "User List";
            this.Load += new System.EventHandler(this.SFM0032_UserList_Load);
            this.grpMember.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpUser)).EndInit();
            this.cmsSelectHelper.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shtUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMember;
        private FarPoint.Win.Spread.FpSpread fpUser;
        private FarPoint.Win.Spread.SheetView shtUser;
        private EVOFramework.Windows.Forms.EVOButton btnCancel;
        private EVOFramework.Windows.Forms.EVOButton btnAdd;
        private System.Windows.Forms.ContextMenuStrip cmsSelectHelper;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectNoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertSelectToolStripMenuItem;
    }
}
