namespace SystemMaintenance.Forms
{
    partial class SFM003_UserMaintenance
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabUser = new System.Windows.Forms.TabPage();
            this.fpUser = new FarPoint.Win.Spread.FpSpread();
            this.cmsUser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shtUser = new FarPoint.Win.Spread.SheetView();
            this.tabGroup = new System.Windows.Forms.TabPage();
            this.fpGroup = new FarPoint.Win.Spread.FpSpread();
            this.cmsGroup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.propertiesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.shtGroup = new FarPoint.Win.Spread.SheetView();
            this.dmcUserMaintenance = new EVOFramework.Data.UIDataModelController(this.components);
            this.tabControl1.SuspendLayout();
            this.tabUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpUser)).BeginInit();
            this.cmsUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shtUser)).BeginInit();
            this.tabGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpGroup)).BeginInit();
            this.cmsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shtGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabUser);
            this.tabControl1.Controls.Add(this.tabGroup);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(677, 437);
            this.tabControl1.TabIndex = 0;
            // 
            // tabUser
            // 
            this.tabUser.Controls.Add(this.fpUser);
            this.tabUser.Location = new System.Drawing.Point(4, 22);
            this.tabUser.Name = "tabUser";
            this.tabUser.Padding = new System.Windows.Forms.Padding(3);
            this.tabUser.Size = new System.Drawing.Size(669, 411);
            this.tabUser.TabIndex = 1;
            this.tabUser.Text = "User";
            this.tabUser.UseVisualStyleBackColor = true;
            // 
            // fpUser
            // 
            this.fpUser.About = "2.5.2015.2005";
            this.fpUser.AccessibleDescription = "fpUser, Sheet1";
            this.fpUser.BackColor = System.Drawing.Color.Transparent;
            this.fpUser.ContextMenuStrip = this.cmsUser;
            this.fpUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpUser.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpUser.Location = new System.Drawing.Point(3, 3);
            this.fpUser.Name = "fpUser";
            this.fpUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpUser.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpUser.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtUser});
            this.fpUser.Size = new System.Drawing.Size(663, 405);
            this.fpUser.TabIndex = 0;
            this.fpUser.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpUser.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpUser_CellDoubleClick);
            // 
            // cmsUser
            // 
            this.cmsUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newUserToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator2,
            this.propertiesToolStripMenuItem});
            this.cmsUser.Name = "cmsUser";
            this.cmsUser.Size = new System.Drawing.Size(124, 76);
            // 
            // newUserToolStripMenuItem
            // 
            this.newUserToolStripMenuItem.Image = global::SystemMaintenance.Properties.Resources.NEW_USER;
            this.newUserToolStripMenuItem.Name = "newUserToolStripMenuItem";
            this.newUserToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.newUserToolStripMenuItem.Text = "New User";
            this.newUserToolStripMenuItem.Click += new System.EventHandler(this.newUserToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(120, 6);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.propertiesToolStripMenuItem.Text = "Properties";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.propertiesToolStripMenuItem_Click);
            // 
            // shtUser
            // 
            this.shtUser.Reset();
            this.shtUser.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtUser.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtUser.ColumnCount = 4;
            this.shtUser.RowCount = 0;
            this.shtUser.AutoGenerateColumns = false;
            this.shtUser.ColumnHeader.Cells.Get(0, 0).Value = "User Account";
            this.shtUser.ColumnHeader.Cells.Get(0, 1).Value = "User Name";
            this.shtUser.ColumnHeader.Cells.Get(0, 2).Value = "User Group";
            this.shtUser.ColumnHeader.Cells.Get(0, 3).Value = "Is Active";
            this.shtUser.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtUser.Columns.Get(0).Label = "User Account";
            this.shtUser.Columns.Get(0).Tag = "UserAccount";
            this.shtUser.Columns.Get(0).Width = 150F;
            this.shtUser.Columns.Get(1).Label = "User Name";
            this.shtUser.Columns.Get(1).Tag = "UserName";
            this.shtUser.Columns.Get(1).Width = 150F;
            this.shtUser.Columns.Get(2).Label = "User Group";
            this.shtUser.Columns.Get(2).Tag = "User Group";
            this.shtUser.Columns.Get(2).Width = 150F;
            this.shtUser.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.shtUser.Columns.Get(3).Label = "Is Active";
            this.shtUser.Columns.Get(3).Tag = "Is Active";
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
            // tabGroup
            // 
            this.tabGroup.Controls.Add(this.fpGroup);
            this.tabGroup.Location = new System.Drawing.Point(4, 22);
            this.tabGroup.Name = "tabGroup";
            this.tabGroup.Padding = new System.Windows.Forms.Padding(3);
            this.tabGroup.Size = new System.Drawing.Size(669, 411);
            this.tabGroup.TabIndex = 0;
            this.tabGroup.Text = "Group";
            this.tabGroup.UseVisualStyleBackColor = true;
            // 
            // fpGroup
            // 
            this.fpGroup.About = "2.5.2015.2005";
            this.fpGroup.AccessibleDescription = "fpGroup, Sheet1, Row 0, Column 0, ";
            this.fpGroup.BackColor = System.Drawing.Color.Transparent;
            this.fpGroup.ContextMenuStrip = this.cmsGroup;
            this.fpGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpGroup.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpGroup.Location = new System.Drawing.Point(3, 3);
            this.fpGroup.Name = "fpGroup";
            this.fpGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpGroup.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpGroup.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtGroup});
            this.fpGroup.Size = new System.Drawing.Size(434, 405);
            this.fpGroup.TabIndex = 1;
            this.fpGroup.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpGroup.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpGroup_CellDoubleClick);
            // 
            // cmsGroup
            // 
            this.cmsGroup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGroupToolStripMenuItem,
            this.deleteToolStripMenuItem1,
            this.toolStripSeparator1,
            this.propertiesToolStripMenuItem1});
            this.cmsGroup.Name = "cmsGroup";
            this.cmsGroup.Size = new System.Drawing.Size(128, 76);
            // 
            // newGroupToolStripMenuItem
            // 
            this.newGroupToolStripMenuItem.Image = global::SystemMaintenance.Properties.Resources.NEW_GROUP_USER;
            this.newGroupToolStripMenuItem.Name = "newGroupToolStripMenuItem";
            this.newGroupToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.newGroupToolStripMenuItem.Text = "New Group";
            this.newGroupToolStripMenuItem.Click += new System.EventHandler(this.newGroupToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Image = global::SystemMaintenance.Properties.Resources.DELETE_GROUP_USER;
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(127, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(124, 6);
            // 
            // propertiesToolStripMenuItem1
            // 
            this.propertiesToolStripMenuItem1.Image = global::SystemMaintenance.Properties.Resources.GROUP_USER;
            this.propertiesToolStripMenuItem1.Name = "propertiesToolStripMenuItem1";
            this.propertiesToolStripMenuItem1.Size = new System.Drawing.Size(127, 22);
            this.propertiesToolStripMenuItem1.Text = "Properties";
            this.propertiesToolStripMenuItem1.Click += new System.EventHandler(this.propertiesToolStripMenuItem1_Click);
            // 
            // shtGroup
            // 
            this.shtGroup.Reset();
            this.shtGroup.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtGroup.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtGroup.ColumnCount = 2;
            this.shtGroup.RowCount = 0;
            this.shtGroup.AutoGenerateColumns = false;
            this.shtGroup.ColumnHeader.Cells.Get(0, 0).Value = "Group Name";
            this.shtGroup.ColumnHeader.Cells.Get(0, 1).Value = "Description";
            this.shtGroup.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtGroup.Columns.Get(0).Label = "Group Name";
            this.shtGroup.Columns.Get(0).Tag = "GroupName";
            this.shtGroup.Columns.Get(0).Width = 180F;
            this.shtGroup.Columns.Get(1).Label = "Description";
            this.shtGroup.Columns.Get(1).Tag = "Description";
            this.shtGroup.Columns.Get(1).Width = 180F;
            this.shtGroup.DataAutoCellTypes = false;
            this.shtGroup.DataAutoHeadings = false;
            this.shtGroup.DataAutoSizeColumns = false;
            this.shtGroup.RowHeader.Columns.Default.Resizable = true;
            this.shtGroup.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.shtGroup.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpGroup.SetActiveViewport(0, 1, 0);
            // 
            // SFM003_UserMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(677, 437);
            this.Controls.Add(this.tabControl1);
            this.Name = "SFM003_UserMaintenance";
            this.Text = "Group & User Maintenance";
            this.Load += new System.EventHandler(this.SFM003_UserMaintenance_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpUser)).EndInit();
            this.cmsUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shtUser)).EndInit();
            this.tabGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpGroup)).EndInit();
            this.cmsGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shtGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGroup;
        private System.Windows.Forms.TabPage tabUser;
        private FarPoint.Win.Spread.FpSpread fpUser;
        private FarPoint.Win.Spread.SheetView shtUser;
        private System.Windows.Forms.ContextMenuStrip cmsUser;
        private System.Windows.Forms.ToolStripMenuItem newUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private EVOFramework.Data.UIDataModelController dmcUserMaintenance;
        private FarPoint.Win.Spread.FpSpread fpGroup;
        private FarPoint.Win.Spread.SheetView shtGroup;
        private System.Windows.Forms.ContextMenuStrip cmsGroup;
        private System.Windows.Forms.ToolStripMenuItem newGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem1;
    }
}
