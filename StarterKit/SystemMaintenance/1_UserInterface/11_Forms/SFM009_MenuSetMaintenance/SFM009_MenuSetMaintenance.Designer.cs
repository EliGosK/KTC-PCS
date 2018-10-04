namespace SystemMaintenance.Forms
{
    partial class SFM009_MenuSetMaintenance
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
            this.fpMenuSet = new FarPoint.Win.Spread.FpSpread();
            this.cmsMenuSet = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addMenuSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMenuSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shtMenuSet = new FarPoint.Win.Spread.SheetView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.fpMenuSub = new FarPoint.Win.Spread.FpSpread();
            this.cmsMenuSub = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.registSubMenuToMenuSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSubMenuFromMenuSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shtMenuSub = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.fpMenuSet)).BeginInit();
            this.cmsMenuSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shtMenuSet)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpMenuSub)).BeginInit();
            this.cmsMenuSub.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shtMenuSub)).BeginInit();
            this.SuspendLayout();
            // 
            // fpMenuSet
            // 
            this.fpMenuSet.About = "2.5.2015.2005";
            this.fpMenuSet.AccessibleDescription = "fpMenuSet, Sheet1, Row 0, Column 0, ";
            this.fpMenuSet.BackColor = System.Drawing.SystemColors.Control;
            this.fpMenuSet.ContextMenuStrip = this.cmsMenuSet;
            this.fpMenuSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpMenuSet.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpMenuSet.Location = new System.Drawing.Point(0, 0);
            this.fpMenuSet.Name = "fpMenuSet";
            this.fpMenuSet.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpMenuSet.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpMenuSet.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtMenuSet});
            this.fpMenuSet.Size = new System.Drawing.Size(577, 244);
            this.fpMenuSet.TabIndex = 0;
            this.fpMenuSet.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpMenuSet.EditModeOn += new System.EventHandler(this.fpMenuSet_EditModeOn);
            this.fpMenuSet.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.fpMenuSet_SelectionChanged);
            this.fpMenuSet.EditModeOff += new System.EventHandler(this.fpMenuSet_EditModeOff);
            // 
            // cmsMenuSet
            // 
            this.cmsMenuSet.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMenuSetToolStripMenuItem,
            this.deleteMenuSetToolStripMenuItem});
            this.cmsMenuSet.Name = "cmsMenuSet";
            this.cmsMenuSet.Size = new System.Drawing.Size(154, 48);
            // 
            // addMenuSetToolStripMenuItem
            // 
            this.addMenuSetToolStripMenuItem.Name = "addMenuSetToolStripMenuItem";
            this.addMenuSetToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.addMenuSetToolStripMenuItem.Text = "Add Menu Set";
            this.addMenuSetToolStripMenuItem.Click += new System.EventHandler(this.addMenuSetToolStripMenuItem_Click);
            // 
            // deleteMenuSetToolStripMenuItem
            // 
            this.deleteMenuSetToolStripMenuItem.Name = "deleteMenuSetToolStripMenuItem";
            this.deleteMenuSetToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.deleteMenuSetToolStripMenuItem.Text = "Delete Menu Set";
            this.deleteMenuSetToolStripMenuItem.Click += new System.EventHandler(this.deleteMenuSetToolStripMenuItem_Click);
            // 
            // shtMenuSet
            // 
            this.shtMenuSet.Reset();
            this.shtMenuSet.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtMenuSet.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtMenuSet.ColumnCount = 2;
            this.shtMenuSet.RowCount = 0;
            this.shtMenuSet.AutoGenerateColumns = false;
            this.shtMenuSet.ColumnHeader.Cells.Get(0, 0).Value = "Menu Set Code";
            this.shtMenuSet.ColumnHeader.Cells.Get(0, 1).Value = "Menu Set Description";
            this.shtMenuSet.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtMenuSet.Columns.Get(0).Label = "Menu Set Code";
            this.shtMenuSet.Columns.Get(0).Tag = "MenuSetCode";
            this.shtMenuSet.Columns.Get(0).Width = 189F;
            this.shtMenuSet.Columns.Get(1).Label = "Menu Set Description";
            this.shtMenuSet.Columns.Get(1).Tag = "MenuSetDesc";
            this.shtMenuSet.Columns.Get(1).Width = 347F;
            this.shtMenuSet.DataAutoCellTypes = false;
            this.shtMenuSet.DataAutoHeadings = false;
            this.shtMenuSet.DataAutoSizeColumns = false;
            this.shtMenuSet.RowHeader.Columns.Default.Resizable = true;
            this.shtMenuSet.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.shtMenuSet.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpMenuSet.SetActiveViewport(0, 1, 0);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.fpMenuSet);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnUp);
            this.splitContainer1.Panel2.Controls.Add(this.btnDown);
            this.splitContainer1.Panel2.Controls.Add(this.fpMenuSub);
            this.splitContainer1.Size = new System.Drawing.Size(577, 435);
            this.splitContainer1.SplitterDistance = 244;
            this.splitContainer1.TabIndex = 2;
            // 
            // btnUp
            // 
            this.btnUp.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnUp.Image = global::SystemMaintenance.Properties.Resources.UP_BTN;
            this.btnUp.Location = new System.Drawing.Point(545, 59);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(30, 31);
            this.btnUp.TabIndex = 19;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDown.Image = global::SystemMaintenance.Properties.Resources.DOWN_BTN;
            this.btnDown.Location = new System.Drawing.Point(545, 96);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(30, 32);
            this.btnDown.TabIndex = 20;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // fpMenuSub
            // 
            this.fpMenuSub.About = "2.5.2015.2005";
            this.fpMenuSub.AccessibleDescription = "fpMenuSub, Sheet1, Row 0, Column 0, ";
            this.fpMenuSub.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fpMenuSub.BackColor = System.Drawing.SystemColors.Control;
            this.fpMenuSub.ContextMenuStrip = this.cmsMenuSub;
            this.fpMenuSub.EditModeReplace = true;
            this.fpMenuSub.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpMenuSub.Location = new System.Drawing.Point(0, 0);
            this.fpMenuSub.Name = "fpMenuSub";
            this.fpMenuSub.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpMenuSub.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpMenuSub.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtMenuSub});
            this.fpMenuSub.Size = new System.Drawing.Size(542, 184);
            this.fpMenuSub.TabIndex = 1;
            this.fpMenuSub.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // cmsMenuSub
            // 
            this.cmsMenuSub.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registSubMenuToMenuSetToolStripMenuItem,
            this.removeSubMenuFromMenuSetToolStripMenuItem});
            this.cmsMenuSub.Name = "cmsMenuSub";
            this.cmsMenuSub.Size = new System.Drawing.Size(237, 48);
            // 
            // registSubMenuToMenuSetToolStripMenuItem
            // 
            this.registSubMenuToMenuSetToolStripMenuItem.Name = "registSubMenuToMenuSetToolStripMenuItem";
            this.registSubMenuToMenuSetToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.registSubMenuToMenuSetToolStripMenuItem.Text = "Regist Sub Menu to Menu Set";
            this.registSubMenuToMenuSetToolStripMenuItem.Click += new System.EventHandler(this.registSubMenuToMenuSetToolStripMenuItem_Click);
            // 
            // removeSubMenuFromMenuSetToolStripMenuItem
            // 
            this.removeSubMenuFromMenuSetToolStripMenuItem.Name = "removeSubMenuFromMenuSetToolStripMenuItem";
            this.removeSubMenuFromMenuSetToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.removeSubMenuFromMenuSetToolStripMenuItem.Text = "Remove Sub Menu from Menu Set";
            this.removeSubMenuFromMenuSetToolStripMenuItem.Click += new System.EventHandler(this.removeSubMenuFromMenuSetToolStripMenuItem_Click);
            // 
            // shtMenuSub
            // 
            this.shtMenuSub.Reset();
            this.shtMenuSub.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtMenuSub.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtMenuSub.ColumnCount = 3;
            this.shtMenuSub.RowCount = 0;
            this.shtMenuSub.AutoGenerateColumns = false;
            this.shtMenuSub.ColumnHeader.Cells.Get(0, 0).Value = "Sub Menu Code";
            this.shtMenuSub.ColumnHeader.Cells.Get(0, 1).Value = "Sub Menu Description";
            this.shtMenuSub.ColumnHeader.Cells.Get(0, 2).Value = "DisplaySEQ";
            this.shtMenuSub.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtMenuSub.Columns.Get(0).Label = "Sub Menu Code";
            this.shtMenuSub.Columns.Get(0).Tag = "SubMenuCode";
            this.shtMenuSub.Columns.Get(0).Width = 186F;
            this.shtMenuSub.Columns.Get(1).Label = "Sub Menu Description";
            this.shtMenuSub.Columns.Get(1).Tag = "SubMenuDesc";
            this.shtMenuSub.Columns.Get(1).Width = 310F;
            this.shtMenuSub.Columns.Get(2).Label = "DisplaySEQ";
            this.shtMenuSub.Columns.Get(2).Tag = "DisplaySEQ";
            this.shtMenuSub.Columns.Get(2).Visible = false;
            this.shtMenuSub.Columns.Get(2).Width = 86F;
            this.shtMenuSub.DataAutoCellTypes = false;
            this.shtMenuSub.DataAutoHeadings = false;
            this.shtMenuSub.DataAutoSizeColumns = false;
            this.shtMenuSub.RowHeader.Columns.Default.Resizable = true;
            this.shtMenuSub.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.shtMenuSub.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpMenuSub.SetActiveViewport(0, 1, 0);
            // 
            // SFM009_MenuSetMaintenance
            // 
            this.ClientSize = new System.Drawing.Size(602, 459);
            this.Controls.Add(this.splitContainer1);
            this.Name = "SFM009_MenuSetMaintenance";
            this.Text = "Menu Set Maintenance";
            this.Load += new System.EventHandler(this.SFM009_MenuSetMaintenance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fpMenuSet)).EndInit();
            this.cmsMenuSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shtMenuSet)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpMenuSub)).EndInit();
            this.cmsMenuSub.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shtMenuSub)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread fpMenuSet;
        private FarPoint.Win.Spread.SheetView shtMenuSet;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private FarPoint.Win.Spread.FpSpread fpMenuSub;
        private FarPoint.Win.Spread.SheetView shtMenuSub;
        private System.Windows.Forms.ContextMenuStrip cmsMenuSet;
        private System.Windows.Forms.ToolStripMenuItem addMenuSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteMenuSetToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsMenuSub;
        private System.Windows.Forms.ToolStripMenuItem registSubMenuToMenuSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeSubMenuFromMenuSetToolStripMenuItem;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
    }
}
