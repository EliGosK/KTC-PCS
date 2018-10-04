namespace SystemMaintenance.Forms
{
    partial class SFM004_ImportScreen
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
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.grpScreenList = new EVOFramework.Windows.Forms.EVOGroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.fpScreenList = new FarPoint.Win.Spread.FpSpread();
            this.cmsSelectHelper = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectNoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertSelectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shtScreenList = new FarPoint.Win.Spread.SheetView();
            this.txtFind = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblFind = new EVOFramework.Windows.Forms.EVOLabel();
            this.grpCommand = new EVOFramework.Windows.Forms.EVOGroupBox();
            this.btnClearScreen = new EVOFramework.Windows.Forms.EVOButton();
            this.btnReImport = new EVOFramework.Windows.Forms.EVOButton();
            this.btnImportScreen = new EVOFramework.Windows.Forms.EVOButton();
            this.grpScreenList.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpScreenList)).BeginInit();
            this.cmsSelectHelper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shtScreenList)).BeginInit();
            this.grpCommand.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpScreenList
            // 
            this.grpScreenList.AppearanceName = "";
            this.grpScreenList.Controls.Add(this.tableLayoutPanel1);
            this.grpScreenList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpScreenList.Location = new System.Drawing.Point(3, 3);
            this.grpScreenList.Name = "grpScreenList";
            this.grpScreenList.Size = new System.Drawing.Size(784, 288);
            this.grpScreenList.TabIndex = 4;
            this.grpScreenList.TabStop = false;
            this.grpScreenList.Text = "System Screen List";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Controls.Add(this.fpScreenList, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtFind, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblFind, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.grpCommand, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(778, 269);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // fpScreenList
            // 
            this.fpScreenList.About = "2.5.2015.2005";
            this.fpScreenList.AccessibleDescription = "fpScreenList, Sheet1";
            this.fpScreenList.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.SetColumnSpan(this.fpScreenList, 2);
            this.fpScreenList.ContextMenuStrip = this.cmsSelectHelper;
            this.fpScreenList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpScreenList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpScreenList.Location = new System.Drawing.Point(3, 29);
            this.fpScreenList.Name = "fpScreenList";
            this.fpScreenList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpScreenList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpScreenList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtScreenList});
            this.fpScreenList.Size = new System.Drawing.Size(572, 237);
            this.fpScreenList.TabIndex = 0;
            this.fpScreenList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
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
            // shtScreenList
            // 
            this.shtScreenList.Reset();
            this.shtScreenList.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtScreenList.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtScreenList.ColumnCount = 5;
            this.shtScreenList.RowCount = 0;
            this.shtScreenList.AutoGenerateColumns = false;
            this.shtScreenList.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.shtScreenList.ColumnHeader.Cells.Get(0, 1).Value = "Screen Code";
            this.shtScreenList.ColumnHeader.Cells.Get(0, 2).Value = "Screen Name";
            this.shtScreenList.ColumnHeader.Cells.Get(0, 3).Value = "Screen Type";
            this.shtScreenList.ColumnHeader.Cells.Get(0, 4).Value = "Import Status";
            this.shtScreenList.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtScreenList.Columns.Get(0).CellType = checkBoxCellType1;
            this.shtScreenList.Columns.Get(0).Label = "Sel";
            this.shtScreenList.Columns.Get(0).Tag = "SEL";
            this.shtScreenList.Columns.Get(0).Width = 29F;
            this.shtScreenList.Columns.Get(1).AllowAutoFilter = true;
            this.shtScreenList.Columns.Get(1).AllowAutoSort = true;
            this.shtScreenList.Columns.Get(1).CellType = textCellType1;
            this.shtScreenList.Columns.Get(1).Label = "Screen Code";
            this.shtScreenList.Columns.Get(1).Tag = "SCREEN_CODE";
            this.shtScreenList.Columns.Get(1).Width = 106F;
            this.shtScreenList.Columns.Get(2).AllowAutoFilter = true;
            this.shtScreenList.Columns.Get(2).AllowAutoSort = true;
            this.shtScreenList.Columns.Get(2).CellType = textCellType2;
            this.shtScreenList.Columns.Get(2).Label = "Screen Name";
            this.shtScreenList.Columns.Get(2).Tag = "SCREEN_NAME";
            this.shtScreenList.Columns.Get(2).Width = 166F;
            this.shtScreenList.Columns.Get(3).AllowAutoFilter = true;
            this.shtScreenList.Columns.Get(3).AllowAutoSort = true;
            this.shtScreenList.Columns.Get(3).CellType = textCellType3;
            this.shtScreenList.Columns.Get(3).Label = "Screen Type";
            this.shtScreenList.Columns.Get(3).Tag = "SCREEN_TYPE";
            this.shtScreenList.Columns.Get(3).Width = 109F;
            this.shtScreenList.Columns.Get(4).AllowAutoFilter = true;
            this.shtScreenList.Columns.Get(4).AllowAutoSort = true;
            this.shtScreenList.Columns.Get(4).CellType = textCellType4;
            this.shtScreenList.Columns.Get(4).Label = "Import Status";
            this.shtScreenList.Columns.Get(4).Tag = "IMPORT_STATUS";
            this.shtScreenList.Columns.Get(4).Width = 104F;
            this.shtScreenList.DataAutoCellTypes = false;
            this.shtScreenList.DataAutoHeadings = false;
            this.shtScreenList.DataAutoSizeColumns = false;
            this.shtScreenList.RowHeader.Columns.Default.Resizable = true;
            this.shtScreenList.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpScreenList.SetActiveViewport(0, 1, 0);
            // 
            // txtFind
            // 
            this.txtFind.AppearanceName = "";
            this.txtFind.AppearanceReadOnlyName = "";
            this.txtFind.ControlID = "";
            this.txtFind.DisableRestrictChar = true;
            this.txtFind.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtFind.HelpButton = null;
            this.txtFind.Location = new System.Drawing.Point(73, 3);
            this.txtFind.Name = "txtFind";
            this.txtFind.PathString = null;
            this.txtFind.PathValue = "";
            this.txtFind.Size = new System.Drawing.Size(502, 20);
            this.txtFind.TabIndex = 2;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // lblFind
            // 
            this.lblFind.AppearanceName = "";
            this.lblFind.ControlID = "";
            this.lblFind.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFind.Location = new System.Drawing.Point(3, 0);
            this.lblFind.Name = "lblFind";
            this.lblFind.PathString = null;
            this.lblFind.PathValue = "Finding :";
            this.lblFind.Size = new System.Drawing.Size(64, 23);
            this.lblFind.TabIndex = 1;
            this.lblFind.Text = "Finding :";
            this.lblFind.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // grpCommand
            // 
            this.grpCommand.AppearanceName = "";
            this.grpCommand.Controls.Add(this.btnClearScreen);
            this.grpCommand.Controls.Add(this.btnReImport);
            this.grpCommand.Controls.Add(this.btnImportScreen);
            this.grpCommand.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCommand.Location = new System.Drawing.Point(581, 29);
            this.grpCommand.Name = "grpCommand";
            this.grpCommand.Size = new System.Drawing.Size(194, 129);
            this.grpCommand.TabIndex = 3;
            this.grpCommand.TabStop = false;
            this.grpCommand.Text = "Command";
            // 
            // btnClearScreen
            // 
            this.btnClearScreen.AppearanceName = "";
            this.btnClearScreen.ControlID = null;
            this.btnClearScreen.Location = new System.Drawing.Point(11, 58);
            this.btnClearScreen.Name = "btnClearScreen";
            this.btnClearScreen.Size = new System.Drawing.Size(173, 23);
            this.btnClearScreen.TabIndex = 1;
            this.btnClearScreen.Text = "Clear Screen Data";
            this.btnClearScreen.UseVisualStyleBackColor = true;
            this.btnClearScreen.Click += new System.EventHandler(this.btnClearScreen_Click);
            // 
            // btnReImport
            // 
            this.btnReImport.AppearanceName = "";
            this.btnReImport.ControlID = null;
            this.btnReImport.Location = new System.Drawing.Point(11, 87);
            this.btnReImport.Name = "btnReImport";
            this.btnReImport.Size = new System.Drawing.Size(173, 23);
            this.btnReImport.TabIndex = 0;
            this.btnReImport.Text = "Re-Import All Screen";
            this.btnReImport.UseVisualStyleBackColor = true;
            this.btnReImport.Click += new System.EventHandler(this.btnReImport_Click);
            // 
            // btnImportScreen
            // 
            this.btnImportScreen.AppearanceName = "";
            this.btnImportScreen.ControlID = null;
            this.btnImportScreen.Location = new System.Drawing.Point(11, 29);
            this.btnImportScreen.Name = "btnImportScreen";
            this.btnImportScreen.Size = new System.Drawing.Size(173, 23);
            this.btnImportScreen.TabIndex = 0;
            this.btnImportScreen.Text = "Import Screen Data";
            this.btnImportScreen.UseVisualStyleBackColor = true;
            this.btnImportScreen.Click += new System.EventHandler(this.btnImportScreen_Click);
            // 
            // SFM004_ImportScreen
            // 
            this.ClientSize = new System.Drawing.Size(790, 294);
            this.Controls.Add(this.grpScreenList);
            this.MinimumSize = new System.Drawing.Size(798, 328);
            this.Name = "SFM004_ImportScreen";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Screen Import";
            this.Load += new System.EventHandler(this.SFM004_ImportScreen_Load);
            this.grpScreenList.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpScreenList)).EndInit();
            this.cmsSelectHelper.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shtScreenList)).EndInit();
            this.grpCommand.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EVOFramework.Windows.Forms.EVOGroupBox grpScreenList;
        private EVOFramework.Windows.Forms.EVOGroupBox grpCommand;
        private EVOFramework.Windows.Forms.EVOButton btnClearScreen;
        private EVOFramework.Windows.Forms.EVOButton btnImportScreen;
        private EVOFramework.Windows.Forms.EVOTextBox txtFind;
        private FarPoint.Win.Spread.FpSpread fpScreenList;
        private FarPoint.Win.Spread.SheetView shtScreenList;
        private EVOFramework.Windows.Forms.EVOLabel lblFind;
        private System.Windows.Forms.ContextMenuStrip cmsSelectHelper;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectNoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertSelectToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private EVOFramework.Windows.Forms.EVOButton btnReImport;

    }
}
