namespace SystemMaintenance.Forms
{
    partial class SFM006_AuthorizedMaintenance
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
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType2 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType3 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType4 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType5 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType6 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType7 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType8 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            this.grpScreenList = new EVOFramework.Windows.Forms.EVOGroupBox();
            this.fpScreenList = new FarPoint.Win.Spread.FpSpread();
            this.shtScreenList = new FarPoint.Win.Spread.SheetView();
            this.txtFind = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblFind = new EVOFramework.Windows.Forms.EVOLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grpPermission = new EVOFramework.Windows.Forms.EVOGroupBox();
            this.tabPermission = new System.Windows.Forms.TabControl();
            this.tpGroups = new System.Windows.Forms.TabPage();
            this.fpGroupPermission = new FarPoint.Win.Spread.FpSpread();
            this.shtGroupPermission = new FarPoint.Win.Spread.SheetView();
            this.tpUsersAccount = new System.Windows.Forms.TabPage();
            this.fpUserPermission = new FarPoint.Win.Spread.FpSpread();
            this.shtUserPermission = new FarPoint.Win.Spread.SheetView();
            this.grpScreenList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpScreenList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtScreenList)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpPermission.SuspendLayout();
            this.tabPermission.SuspendLayout();
            this.tpGroups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpGroupPermission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtGroupPermission)).BeginInit();
            this.tpUsersAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpUserPermission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtUserPermission)).BeginInit();
            this.SuspendLayout();
            // 
            // grpScreenList
            // 
            this.grpScreenList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpScreenList.AppearanceName = "";
            this.grpScreenList.Controls.Add(this.fpScreenList);
            this.grpScreenList.Controls.Add(this.txtFind);
            this.grpScreenList.Controls.Add(this.lblFind);
            this.grpScreenList.Location = new System.Drawing.Point(12, 12);
            this.grpScreenList.Name = "grpScreenList";
            this.grpScreenList.Size = new System.Drawing.Size(362, 408);
            this.grpScreenList.TabIndex = 0;
            this.grpScreenList.TabStop = false;
            this.grpScreenList.Text = "Screen List";
            // 
            // fpScreenList
            // 
            this.fpScreenList.About = "2.5.2015.2005";
            this.fpScreenList.AccessibleDescription = "fpScreenList, Sheet1";
            this.fpScreenList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fpScreenList.BackColor = System.Drawing.Color.Transparent;
            this.fpScreenList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpScreenList.Location = new System.Drawing.Point(6, 41);
            this.fpScreenList.Name = "fpScreenList";
            this.fpScreenList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpScreenList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtScreenList});
            this.fpScreenList.Size = new System.Drawing.Size(350, 357);
            this.fpScreenList.TabIndex = 9;
            this.fpScreenList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpScreenList.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpScreenList_CellClick);
            this.fpScreenList.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.fpScreenList_SelectionChanged);
            // 
            // shtScreenList
            // 
            this.shtScreenList.Reset();
            this.shtScreenList.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtScreenList.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtScreenList.ColumnCount = 2;
            this.shtScreenList.RowCount = 0;
            this.shtScreenList.AutoGenerateColumns = false;
            this.shtScreenList.ColumnHeader.Cells.Get(0, 0).Value = "Screen Code";
            this.shtScreenList.ColumnHeader.Cells.Get(0, 1).Value = "Original Title";
            this.shtScreenList.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtScreenList.Columns.Get(0).CellType = textCellType1;
            this.shtScreenList.Columns.Get(0).Label = "Screen Code";
            this.shtScreenList.Columns.Get(0).Tag = "ScreenCode";
            this.shtScreenList.Columns.Get(0).Width = 117F;
            this.shtScreenList.Columns.Get(1).CellType = textCellType2;
            this.shtScreenList.Columns.Get(1).Label = "Original Title";
            this.shtScreenList.Columns.Get(1).Tag = "OriginalTitle";
            this.shtScreenList.Columns.Get(1).Width = 156F;
            this.shtScreenList.DataAutoCellTypes = false;
            this.shtScreenList.DataAutoHeadings = false;
            this.shtScreenList.DataAutoSizeColumns = false;
            this.shtScreenList.RowHeader.Columns.Default.Resizable = true;
            this.shtScreenList.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.shtScreenList.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.shtScreenList.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpScreenList.SetActiveViewport(0, 1, 0);
            // 
            // txtFind
            // 
            this.txtFind.AppearanceName = "";
            this.txtFind.AppearanceReadOnlyName = "";
            this.txtFind.ControlID = "";
            this.txtFind.DisableRestrictChar = true;
            this.txtFind.HelpButton = null;
            this.txtFind.Location = new System.Drawing.Point(93, 16);
            this.txtFind.Name = "txtFind";
            this.txtFind.PathString = null;
            this.txtFind.PathValue = "";
            this.txtFind.Size = new System.Drawing.Size(193, 20);
            this.txtFind.TabIndex = 8;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // lblFind
            // 
            this.lblFind.AppearanceName = "";
            this.lblFind.AutoSize = true;
            this.lblFind.ControlID = "";
            this.lblFind.Location = new System.Drawing.Point(40, 19);
            this.lblFind.Name = "lblFind";
            this.lblFind.PathString = null;
            this.lblFind.PathValue = "Finding :";
            this.lblFind.Size = new System.Drawing.Size(47, 13);
            this.lblFind.TabIndex = 7;
            this.lblFind.Text = "Finding :";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grpScreenList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grpPermission);
            this.splitContainer1.Size = new System.Drawing.Size(903, 432);
            this.splitContainer1.SplitterDistance = 377;
            this.splitContainer1.TabIndex = 1;
            // 
            // grpPermission
            // 
            this.grpPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPermission.AppearanceName = "";
            this.grpPermission.Controls.Add(this.tabPermission);
            this.grpPermission.Location = new System.Drawing.Point(3, 12);
            this.grpPermission.Name = "grpPermission";
            this.grpPermission.Size = new System.Drawing.Size(507, 408);
            this.grpPermission.TabIndex = 1;
            this.grpPermission.TabStop = false;
            this.grpPermission.Text = "Permission";
            // 
            // tabPermission
            // 
            this.tabPermission.Controls.Add(this.tpGroups);
            this.tabPermission.Controls.Add(this.tpUsersAccount);
            this.tabPermission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPermission.Location = new System.Drawing.Point(3, 16);
            this.tabPermission.Name = "tabPermission";
            this.tabPermission.SelectedIndex = 0;
            this.tabPermission.Size = new System.Drawing.Size(501, 389);
            this.tabPermission.TabIndex = 0;
            this.tabPermission.SelectedIndexChanged += new System.EventHandler(this.tabPermission_SelectedIndexChanged);
            // 
            // tpGroups
            // 
            this.tpGroups.Controls.Add(this.fpGroupPermission);
            this.tpGroups.Location = new System.Drawing.Point(4, 22);
            this.tpGroups.Name = "tpGroups";
            this.tpGroups.Padding = new System.Windows.Forms.Padding(3);
            this.tpGroups.Size = new System.Drawing.Size(493, 363);
            this.tpGroups.TabIndex = 0;
            this.tpGroups.Text = "Groups";
            this.tpGroups.UseVisualStyleBackColor = true;
            // 
            // fpGroupPermission
            // 
            this.fpGroupPermission.About = "2.5.2015.2005";
            this.fpGroupPermission.AccessibleDescription = "fpGroupPermission, shtGroupPermission, Row 0, Column 0, ";
            this.fpGroupPermission.BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpGroupPermission.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpGroupPermission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpGroupPermission.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpGroupPermission.Location = new System.Drawing.Point(3, 3);
            this.fpGroupPermission.Name = "fpGroupPermission";
            this.fpGroupPermission.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpGroupPermission.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpGroupPermission.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpGroupPermission.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtGroupPermission});
            this.fpGroupPermission.Size = new System.Drawing.Size(487, 357);
            this.fpGroupPermission.TabIndex = 182;
            this.fpGroupPermission.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpGroupPermission.EditModeOff += new System.EventHandler(this.fpGroupPermission_EditModeOff);
            // 
            // shtGroupPermission
            // 
            this.shtGroupPermission.Reset();
            this.shtGroupPermission.SheetName = "shtGroupPermission";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtGroupPermission.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtGroupPermission.ColumnCount = 6;
            this.shtGroupPermission.RowCount = 0;
            this.shtGroupPermission.AutoGenerateColumns = false;
            this.shtGroupPermission.ColumnHeader.Cells.Get(0, 0).Value = "Group Name";
            this.shtGroupPermission.ColumnHeader.Cells.Get(0, 1).Value = "View";
            this.shtGroupPermission.ColumnHeader.Cells.Get(0, 2).Value = "Add";
            this.shtGroupPermission.ColumnHeader.Cells.Get(0, 3).Value = "Change";
            this.shtGroupPermission.ColumnHeader.Cells.Get(0, 4).Value = "Delete";
            this.shtGroupPermission.ColumnHeader.Cells.Get(0, 5).Value = "Group CD";
            this.shtGroupPermission.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtGroupPermission.Columns.Get(0).CellType = textCellType3;
            this.shtGroupPermission.Columns.Get(0).Label = "Group Name";
            this.shtGroupPermission.Columns.Get(0).Tag = "GroupName";
            this.shtGroupPermission.Columns.Get(0).Width = 183F;
            this.shtGroupPermission.Columns.Get(1).CellType = checkBoxCellType1;
            this.shtGroupPermission.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.shtGroupPermission.Columns.Get(1).Label = "View";
            this.shtGroupPermission.Columns.Get(1).Tag = "View";
            this.shtGroupPermission.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Top;
            this.shtGroupPermission.Columns.Get(1).Width = 74F;
            this.shtGroupPermission.Columns.Get(2).CellType = checkBoxCellType2;
            this.shtGroupPermission.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.shtGroupPermission.Columns.Get(2).Label = "Add";
            this.shtGroupPermission.Columns.Get(2).Tag = "Add";
            this.shtGroupPermission.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Top;
            this.shtGroupPermission.Columns.Get(3).CellType = checkBoxCellType3;
            this.shtGroupPermission.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.shtGroupPermission.Columns.Get(3).Label = "Change";
            this.shtGroupPermission.Columns.Get(3).Tag = "Change";
            this.shtGroupPermission.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Top;
            this.shtGroupPermission.Columns.Get(3).Width = 67F;
            this.shtGroupPermission.Columns.Get(4).CellType = checkBoxCellType4;
            this.shtGroupPermission.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.shtGroupPermission.Columns.Get(4).Label = "Delete";
            this.shtGroupPermission.Columns.Get(4).Tag = "Delete";
            this.shtGroupPermission.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Top;
            this.shtGroupPermission.Columns.Get(5).Label = "Group CD";
            this.shtGroupPermission.Columns.Get(5).Tag = "GroupCD";
            this.shtGroupPermission.Columns.Get(5).Visible = false;
            this.shtGroupPermission.DataAutoCellTypes = false;
            this.shtGroupPermission.DataAutoHeadings = false;
            this.shtGroupPermission.DataAutoSizeColumns = false;
            this.shtGroupPermission.DefaultStyle.Locked = true;
            this.shtGroupPermission.DefaultStyle.Parent = "DataAreaDefault";
            this.shtGroupPermission.RowHeader.Columns.Default.Resizable = true;
            this.shtGroupPermission.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.shtGroupPermission.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpGroupPermission.SetActiveViewport(0, 1, 0);
            // 
            // tpUsersAccount
            // 
            this.tpUsersAccount.Controls.Add(this.fpUserPermission);
            this.tpUsersAccount.Location = new System.Drawing.Point(4, 22);
            this.tpUsersAccount.Name = "tpUsersAccount";
            this.tpUsersAccount.Padding = new System.Windows.Forms.Padding(3);
            this.tpUsersAccount.Size = new System.Drawing.Size(493, 363);
            this.tpUsersAccount.TabIndex = 1;
            this.tpUsersAccount.Text = "Users Account";
            this.tpUsersAccount.UseVisualStyleBackColor = true;
            // 
            // fpUserPermission
            // 
            this.fpUserPermission.About = "2.5.2015.2005";
            this.fpUserPermission.AccessibleDescription = "fpUserPermission, shtUserPermission, Row 0, Column 0, ";
            this.fpUserPermission.BackColor = System.Drawing.SystemColors.Control;
            this.fpUserPermission.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpUserPermission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpUserPermission.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpUserPermission.Location = new System.Drawing.Point(3, 3);
            this.fpUserPermission.Name = "fpUserPermission";
            this.fpUserPermission.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpUserPermission.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpUserPermission.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpUserPermission.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtUserPermission});
            this.fpUserPermission.Size = new System.Drawing.Size(487, 357);
            this.fpUserPermission.TabIndex = 193;
            this.fpUserPermission.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpUserPermission.EditModeOff += new System.EventHandler(this.fpUserPermission_EditModeOff);
            // 
            // shtUserPermission
            // 
            this.shtUserPermission.Reset();
            this.shtUserPermission.SheetName = "shtUserPermission";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtUserPermission.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtUserPermission.ColumnCount = 6;
            this.shtUserPermission.RowCount = 0;
            this.shtUserPermission.AutoGenerateColumns = false;
            this.shtUserPermission.ColumnHeader.Cells.Get(0, 0).Value = "User Account";
            this.shtUserPermission.ColumnHeader.Cells.Get(0, 1).Value = "View";
            this.shtUserPermission.ColumnHeader.Cells.Get(0, 2).Value = "Add";
            this.shtUserPermission.ColumnHeader.Cells.Get(0, 3).Value = "Change";
            this.shtUserPermission.ColumnHeader.Cells.Get(0, 4).Value = "Delete";
            this.shtUserPermission.ColumnHeader.Cells.Get(0, 5).Value = "User CD";
            this.shtUserPermission.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtUserPermission.Columns.Get(0).CellType = textCellType4;
            this.shtUserPermission.Columns.Get(0).Label = "User Account";
            this.shtUserPermission.Columns.Get(0).Tag = "UserAccount";
            this.shtUserPermission.Columns.Get(0).Width = 161F;
            checkBoxCellType5.ThreeState = true;
            this.shtUserPermission.Columns.Get(1).CellType = checkBoxCellType5;
            this.shtUserPermission.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.shtUserPermission.Columns.Get(1).Label = "View";
            this.shtUserPermission.Columns.Get(1).Tag = "View";
            this.shtUserPermission.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Top;
            this.shtUserPermission.Columns.Get(1).Width = 67F;
            checkBoxCellType6.ThreeState = true;
            this.shtUserPermission.Columns.Get(2).CellType = checkBoxCellType6;
            this.shtUserPermission.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.shtUserPermission.Columns.Get(2).Label = "Add";
            this.shtUserPermission.Columns.Get(2).Tag = "Add";
            this.shtUserPermission.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Top;
            this.shtUserPermission.Columns.Get(2).Width = 67F;
            checkBoxCellType7.ThreeState = true;
            this.shtUserPermission.Columns.Get(3).CellType = checkBoxCellType7;
            this.shtUserPermission.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.shtUserPermission.Columns.Get(3).Label = "Change";
            this.shtUserPermission.Columns.Get(3).Tag = "Change";
            this.shtUserPermission.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Top;
            this.shtUserPermission.Columns.Get(3).Width = 67F;
            checkBoxCellType8.ThreeState = true;
            this.shtUserPermission.Columns.Get(4).CellType = checkBoxCellType8;
            this.shtUserPermission.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.shtUserPermission.Columns.Get(4).Label = "Delete";
            this.shtUserPermission.Columns.Get(4).Tag = "Delete";
            this.shtUserPermission.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Top;
            this.shtUserPermission.Columns.Get(4).Width = 67F;
            this.shtUserPermission.Columns.Get(5).Label = "User CD";
            this.shtUserPermission.Columns.Get(5).Tag = "UserCD";
            this.shtUserPermission.Columns.Get(5).Visible = false;
            this.shtUserPermission.DataAutoCellTypes = false;
            this.shtUserPermission.DataAutoHeadings = false;
            this.shtUserPermission.DataAutoSizeColumns = false;
            this.shtUserPermission.DefaultStyle.Locked = true;
            this.shtUserPermission.DefaultStyle.Parent = "DataAreaDefault";
            this.shtUserPermission.RowHeader.Columns.Default.Resizable = true;
            this.shtUserPermission.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpUserPermission.SetActiveViewport(0, 1, 0);
            // 
            // SFM006_AuthorizedMaintenance
            // 
            this.ClientSize = new System.Drawing.Size(903, 432);
            this.Controls.Add(this.splitContainer1);
            this.Name = "SFM006_AuthorizedMaintenance";
            this.Text = "AuthorizedMaintenance";
            this.Load += new System.EventHandler(this.SFM006_AuthorizedMaintenance_Load);
            this.Shown += new System.EventHandler(this.SFM006_AuthorizedMaintenance_Shown);
            this.grpScreenList.ResumeLayout(false);
            this.grpScreenList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpScreenList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtScreenList)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.grpPermission.ResumeLayout(false);
            this.tabPermission.ResumeLayout(false);
            this.tpGroups.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpGroupPermission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtGroupPermission)).EndInit();
            this.tpUsersAccount.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpUserPermission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtUserPermission)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EVOFramework.Windows.Forms.EVOGroupBox grpScreenList;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private EVOFramework.Windows.Forms.EVOGroupBox grpPermission;
        private EVOFramework.Windows.Forms.EVOTextBox txtFind;
        private EVOFramework.Windows.Forms.EVOLabel lblFind;
        private FarPoint.Win.Spread.FpSpread fpScreenList;
        private FarPoint.Win.Spread.SheetView shtScreenList;
        private System.Windows.Forms.TabControl tabPermission;
        private System.Windows.Forms.TabPage tpGroups;
        private System.Windows.Forms.TabPage tpUsersAccount;
        private FarPoint.Win.Spread.FpSpread fpGroupPermission;
        private FarPoint.Win.Spread.SheetView shtGroupPermission;
        private FarPoint.Win.Spread.FpSpread fpUserPermission;
        private FarPoint.Win.Spread.SheetView shtUserPermission;
    }
}
