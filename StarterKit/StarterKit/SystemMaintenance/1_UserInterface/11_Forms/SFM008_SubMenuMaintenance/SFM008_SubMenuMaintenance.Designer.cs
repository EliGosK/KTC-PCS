namespace SystemMaintenance.Forms
{
    partial class SFM008_SubMenuMaintenance
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
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.lblLanguage = new EVOFramework.Windows.Forms.EVOLabel();
            this.grpSubMenuList = new EVOFramework.Windows.Forms.EVOGroupBox();
            this.fpView = new FarPoint.Win.Spread.FpSpread();
            this.shtView = new FarPoint.Win.Spread.SheetView();
            this.txtFind = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblFind = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboLanguage = new EVOFramework.Windows.Forms.EVOComboBox();
            this.dmcSubMenu = new EVOFramework.Data.UIDataModelController(this.components);
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddSubMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteSubMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslEditing = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpSubMenuList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).BeginInit();
            this.ctxMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLanguage
            // 
            this.lblLanguage.AppearanceName = "";
            this.lblLanguage.ControlID = "";
            this.lblLanguage.Location = new System.Drawing.Point(13, 9);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.PathString = null;
            this.lblLanguage.PathValue = "Language:";
            this.lblLanguage.Size = new System.Drawing.Size(83, 23);
            this.lblLanguage.TabIndex = 0;
            this.lblLanguage.Text = "Language:";
            this.lblLanguage.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // grpSubMenuList
            // 
            this.grpSubMenuList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSubMenuList.AppearanceName = "";
            this.grpSubMenuList.Controls.Add(this.fpView);
            this.grpSubMenuList.Controls.Add(this.txtFind);
            this.grpSubMenuList.Controls.Add(this.lblFind);
            this.grpSubMenuList.Location = new System.Drawing.Point(7, 39);
            this.grpSubMenuList.Name = "grpSubMenuList";
            this.grpSubMenuList.Size = new System.Drawing.Size(488, 285);
            this.grpSubMenuList.TabIndex = 1;
            this.grpSubMenuList.TabStop = false;
            this.grpSubMenuList.Text = "Sub Menu List";
            // 
            // fpView
            // 
            this.fpView.About = "2.5.2015.2005";
            this.fpView.AccessibleDescription = "fpView, Sheet1";
            this.fpView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fpView.BackColor = System.Drawing.SystemColors.Control;
            this.fpView.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpView.EditModeReplace = true;
            this.fpView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.Location = new System.Drawing.Point(9, 43);
            this.fpView.Name = "fpView";
            this.fpView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpView.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtView});
            this.fpView.Size = new System.Drawing.Size(473, 236);
            this.fpView.TabIndex = 3;
            this.fpView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fpView_MouseDown);
            this.fpView.EditModeOn += new System.EventHandler(this.fpView_EditModeOn);
            this.fpView.EditModeOff += new System.EventHandler(this.fpView_EditModeOff);
            // 
            // shtView
            // 
            this.shtView.Reset();
            this.shtView.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtView.ColumnCount = 3;
            this.shtView.RowCount = 0;
            this.shtView.AutoCalculation = false;
            this.shtView.AutoGenerateColumns = false;
            this.shtView.ColumnHeader.Cells.Get(0, 0).Value = "Sub Menu Code";
            this.shtView.ColumnHeader.Cells.Get(0, 1).Value = "Original Caption";
            this.shtView.ColumnHeader.Cells.Get(0, 2).Value = "Display Caption";
            this.shtView.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtView.Columns.Get(0).CellType = textCellType1;
            this.shtView.Columns.Get(0).Label = "Sub Menu Code";
            this.shtView.Columns.Get(0).Locked = true;
            this.shtView.Columns.Get(0).Tag = "SUB_MENU_CD";
            this.shtView.Columns.Get(0).Width = 107F;
            this.shtView.Columns.Get(1).AllowAutoFilter = true;
            this.shtView.Columns.Get(1).AllowAutoSort = true;
            this.shtView.Columns.Get(1).CellType = textCellType2;
            this.shtView.Columns.Get(1).Label = "Original Caption";
            this.shtView.Columns.Get(1).Locked = true;
            this.shtView.Columns.Get(1).Tag = "SUB_MENU_NAME";
            this.shtView.Columns.Get(1).Width = 154F;
            this.shtView.Columns.Get(2).AllowAutoFilter = true;
            this.shtView.Columns.Get(2).AllowAutoSort = true;
            this.shtView.Columns.Get(2).CellType = textCellType3;
            this.shtView.Columns.Get(2).ForeColor = System.Drawing.Color.Blue;
            this.shtView.Columns.Get(2).Label = "Display Caption";
            this.shtView.Columns.Get(2).Tag = "SUB_MENU_LANG";
            this.shtView.Columns.Get(2).Width = 156F;
            this.shtView.DataAutoCellTypes = false;
            this.shtView.DataAutoHeadings = false;
            this.shtView.DataAutoSizeColumns = false;
            this.shtView.RowHeader.Columns.Default.Resizable = true;
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpView.SetActiveViewport(0, 1, 0);
            // 
            // txtFind
            // 
            this.txtFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFind.AppearanceName = "";
            this.txtFind.AppearanceReadOnlyName = "";
            this.txtFind.ControlID = "";
            this.txtFind.DisableRestrictChar = true;
            this.txtFind.HelpButton = null;
            this.txtFind.Location = new System.Drawing.Point(95, 13);
            this.txtFind.MaxLength = 15;
            this.txtFind.Name = "txtFind";
            this.txtFind.PathString = "FindText.Value";
            this.txtFind.PathValue = "";
            this.txtFind.Size = new System.Drawing.Size(387, 20);
            this.txtFind.TabIndex = 2;
            this.txtFind.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFind_KeyUp);
            // 
            // lblFind
            // 
            this.lblFind.AppearanceName = "";
            this.lblFind.ControlID = "";
            this.lblFind.Location = new System.Drawing.Point(6, 16);
            this.lblFind.Name = "lblFind";
            this.lblFind.PathString = null;
            this.lblFind.PathValue = "Finding:";
            this.lblFind.Size = new System.Drawing.Size(83, 23);
            this.lblFind.TabIndex = 1;
            this.lblFind.Text = "Finding:";
            this.lblFind.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboLanguage
            // 
            this.cboLanguage.AppearanceName = "";
            this.cboLanguage.AppearanceReadOnlyName = "";
            this.cboLanguage.ControlID = null;
            this.cboLanguage.DropDownHeight = 180;
            this.cboLanguage.FormattingEnabled = true;
            this.cboLanguage.IntegralHeight = false;
            this.cboLanguage.Location = new System.Drawing.Point(102, 7);
            this.cboLanguage.Name = "cboLanguage";
            this.cboLanguage.PathString = "Language.Value";
            this.cboLanguage.PathValue = null;
            this.cboLanguage.Size = new System.Drawing.Size(139, 21);
            this.cboLanguage.TabIndex = 2;
            this.cboLanguage.SelectedValueChanged += new System.EventHandler(this.cboLanguage_SelectedValueChanged);
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddSubMenu,
            this.mnuDeleteSubMenu,
            this.mnuProperties});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(156, 70);
            // 
            // mnuAddSubMenu
            // 
            this.mnuAddSubMenu.Name = "mnuAddSubMenu";
            this.mnuAddSubMenu.Size = new System.Drawing.Size(155, 22);
            this.mnuAddSubMenu.Text = "Add Sub Menu";
            this.mnuAddSubMenu.Click += new System.EventHandler(this.mnuAddSubMenu_Click);
            // 
            // mnuDeleteSubMenu
            // 
            this.mnuDeleteSubMenu.Name = "mnuDeleteSubMenu";
            this.mnuDeleteSubMenu.Size = new System.Drawing.Size(155, 22);
            this.mnuDeleteSubMenu.Text = "Delete Sub Menu";
            this.mnuDeleteSubMenu.Click += new System.EventHandler(this.mnuDeleteSubMenu_Click);
            // 
            // mnuProperties
            // 
            this.mnuProperties.Name = "mnuProperties";
            this.mnuProperties.Size = new System.Drawing.Size(155, 22);
            this.mnuProperties.Text = "Properties";
            this.mnuProperties.Click += new System.EventHandler(this.mnuProperties_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslEditing});
            this.statusStrip1.Location = new System.Drawing.Point(0, 333);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(503, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslEditing
            // 
            this.tslEditing.Name = "tslEditing";
            this.tslEditing.Size = new System.Drawing.Size(0, 17);
            // 
            // SFM008_SubMenuMaintenance
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(503, 355);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cboLanguage);
            this.Controls.Add(this.grpSubMenuList);
            this.Controls.Add(this.lblLanguage);
            this.Name = "SFM008_SubMenuMaintenance";
            this.Text = "SFM008 Sub Menu Maintenance";
            this.Load += new System.EventHandler(this.SFM008_SubMenuMaintenance_Load);
            this.grpSubMenuList.ResumeLayout(false);
            this.grpSubMenuList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).EndInit();
            this.ctxMenu.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EVOFramework.Windows.Forms.EVOLabel lblLanguage;
        private EVOFramework.Windows.Forms.EVOGroupBox grpSubMenuList;
        private EVOFramework.Windows.Forms.EVOComboBox cboLanguage;
        private FarPoint.Win.Spread.FpSpread fpView;
        private FarPoint.Win.Spread.SheetView shtView;
        private EVOFramework.Windows.Forms.EVOTextBox txtFind;
        private EVOFramework.Windows.Forms.EVOLabel lblFind;
        private EVOFramework.Data.UIDataModelController dmcSubMenu;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuAddSubMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteSubMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuProperties;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslEditing;
    }
}