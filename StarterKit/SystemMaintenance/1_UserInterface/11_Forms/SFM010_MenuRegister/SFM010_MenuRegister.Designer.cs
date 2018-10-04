namespace SystemMaintenance.Forms
{
    partial class SFM010_MenuRegister
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
            this.splitterContainer = new System.Windows.Forms.SplitContainer();
            this.evoGroupBox1 = new EVOFramework.Windows.Forms.EVOGroupBox();
            this.trvMenu = new System.Windows.Forms.TreeView();
            this.evoGroupBox2 = new EVOFramework.Windows.Forms.EVOGroupBox();
            this.fpScreen = new FarPoint.Win.Spread.FpSpread();
            this.shtScreen = new FarPoint.Win.Spread.SheetView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMoveDown = new EVOFramework.Windows.Forms.EVOButton();
            this.btnMoveUp = new EVOFramework.Windows.Forms.EVOButton();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuRegisterScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRemoveScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.splitterContainer.Panel1.SuspendLayout();
            this.splitterContainer.Panel2.SuspendLayout();
            this.splitterContainer.SuspendLayout();
            this.evoGroupBox1.SuspendLayout();
            this.evoGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtScreen)).BeginInit();
            this.panel1.SuspendLayout();
            this.ctxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitterContainer
            // 
            this.splitterContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitterContainer.Location = new System.Drawing.Point(0, 0);
            this.splitterContainer.Name = "splitterContainer";
            // 
            // splitterContainer.Panel1
            // 
            this.splitterContainer.Panel1.Controls.Add(this.evoGroupBox1);
            this.splitterContainer.Panel1.Padding = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.splitterContainer.Panel1MinSize = 250;
            // 
            // splitterContainer.Panel2
            // 
            this.splitterContainer.Panel2.Controls.Add(this.evoGroupBox2);
            this.splitterContainer.Panel2.Controls.Add(this.panel1);
            this.splitterContainer.Panel2.Padding = new System.Windows.Forms.Padding(5, 5, 5, 10);
            this.splitterContainer.Size = new System.Drawing.Size(710, 316);
            this.splitterContainer.SplitterDistance = 250;
            this.splitterContainer.SplitterWidth = 5;
            this.splitterContainer.TabIndex = 0;
            // 
            // evoGroupBox1
            // 
            this.evoGroupBox1.AppearanceName = "";
            this.evoGroupBox1.Controls.Add(this.trvMenu);
            this.evoGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.evoGroupBox1.Location = new System.Drawing.Point(5, 10);
            this.evoGroupBox1.Name = "evoGroupBox1";
            this.evoGroupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.evoGroupBox1.Size = new System.Drawing.Size(240, 296);
            this.evoGroupBox1.TabIndex = 0;
            this.evoGroupBox1.TabStop = false;
            this.evoGroupBox1.Text = "Menu List";
            // 
            // trvMenu
            // 
            this.trvMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvMenu.FullRowSelect = true;
            this.trvMenu.HideSelection = false;
            this.trvMenu.Location = new System.Drawing.Point(5, 18);
            this.trvMenu.Name = "trvMenu";
            this.trvMenu.Size = new System.Drawing.Size(230, 273);
            this.trvMenu.TabIndex = 0;
            this.trvMenu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvMenu_AfterSelect);
            this.trvMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trvMenu_MouseDown);
            // 
            // evoGroupBox2
            // 
            this.evoGroupBox2.AppearanceName = "";
            this.evoGroupBox2.Controls.Add(this.fpScreen);
            this.evoGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.evoGroupBox2.Location = new System.Drawing.Point(5, 5);
            this.evoGroupBox2.Name = "evoGroupBox2";
            this.evoGroupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.evoGroupBox2.Size = new System.Drawing.Size(408, 301);
            this.evoGroupBox2.TabIndex = 1;
            this.evoGroupBox2.TabStop = false;
            this.evoGroupBox2.Text = "Screen List";
            // 
            // fpScreen
            // 
            this.fpScreen.About = "2.5.2015.2005";
            this.fpScreen.AccessibleDescription = "fpScreen, Sheet1";
            this.fpScreen.BackColor = System.Drawing.SystemColors.Control;
            this.fpScreen.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpScreen.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpScreen.Location = new System.Drawing.Point(5, 18);
            this.fpScreen.Name = "fpScreen";
            this.fpScreen.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpScreen.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpScreen.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpScreen.SelectionBlockOptions = ((FarPoint.Win.Spread.SelectionBlockOptions)((FarPoint.Win.Spread.SelectionBlockOptions.Cells | FarPoint.Win.Spread.SelectionBlockOptions.Rows)));
            this.fpScreen.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtScreen});
            this.fpScreen.Size = new System.Drawing.Size(398, 278);
            this.fpScreen.TabIndex = 0;
            this.fpScreen.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpScreen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fpScreen_MouseDown);
            this.fpScreen.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.fpScreen_SelectionChanged);
            // 
            // shtScreen
            // 
            this.shtScreen.Reset();
            this.shtScreen.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtScreen.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtScreen.ColumnCount = 3;
            this.shtScreen.RowCount = 0;
            this.shtScreen.AutoCalculation = false;
            this.shtScreen.AutoGenerateColumns = false;
            this.shtScreen.ColumnHeader.Cells.Get(0, 0).Value = " ";
            this.shtScreen.ColumnHeader.Cells.Get(0, 1).Value = "Screen Code";
            this.shtScreen.ColumnHeader.Cells.Get(0, 2).Value = "Original Title";
            this.shtScreen.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtScreen.Columns.Get(0).CellType = checkBoxCellType1;
            this.shtScreen.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.shtScreen.Columns.Get(0).Label = " ";
            this.shtScreen.Columns.Get(0).Width = 38F;
            this.shtScreen.Columns.Get(1).AllowAutoFilter = true;
            this.shtScreen.Columns.Get(1).AllowAutoSort = true;
            this.shtScreen.Columns.Get(1).CellType = textCellType1;
            this.shtScreen.Columns.Get(1).Label = "Screen Code";
            this.shtScreen.Columns.Get(1).Locked = true;
            this.shtScreen.Columns.Get(1).Tag = "Screen Code";
            this.shtScreen.Columns.Get(1).Width = 137F;
            this.shtScreen.Columns.Get(2).AllowAutoFilter = true;
            this.shtScreen.Columns.Get(2).AllowAutoSort = true;
            this.shtScreen.Columns.Get(2).CellType = textCellType2;
            this.shtScreen.Columns.Get(2).Label = "Original Title";
            this.shtScreen.Columns.Get(2).Locked = true;
            this.shtScreen.Columns.Get(2).Tag = "Original Title";
            this.shtScreen.Columns.Get(2).Width = 146F;
            this.shtScreen.DataAutoCellTypes = false;
            this.shtScreen.DataAutoHeadings = false;
            this.shtScreen.DataAutoSizeColumns = false;
            this.shtScreen.RowHeader.Columns.Default.Resizable = true;
            this.shtScreen.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.shtScreen.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.shtScreen.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpScreen.SetActiveViewport(0, 1, 0);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMoveDown);
            this.panel1.Controls.Add(this.btnMoveUp);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(413, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(37, 301);
            this.panel1.TabIndex = 1;
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMoveDown.AppearanceName = "";
            this.btnMoveDown.ControlID = null;
            this.btnMoveDown.Image = global::SystemMaintenance.Properties.Resources.DOWN_BTN;
            this.btnMoveDown.Location = new System.Drawing.Point(3, 153);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(31, 31);
            this.btnMoveDown.TabIndex = 1;
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMoveUp.AppearanceName = "";
            this.btnMoveUp.ControlID = null;
            this.btnMoveUp.Image = global::SystemMaintenance.Properties.Resources.UP_BTN;
            this.btnMoveUp.Location = new System.Drawing.Point(3, 116);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(31, 31);
            this.btnMoveUp.TabIndex = 0;
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRegisterScreen,
            this.mnuRemoveScreen});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(204, 48);
            // 
            // mnuRegisterScreen
            // 
            this.mnuRegisterScreen.Name = "mnuRegisterScreen";
            this.mnuRegisterScreen.Size = new System.Drawing.Size(203, 22);
            this.mnuRegisterScreen.Text = "Register Screen to Menu";
            this.mnuRegisterScreen.Click += new System.EventHandler(this.mnuRegisterScreen_Click);
            // 
            // mnuRemoveScreen
            // 
            this.mnuRemoveScreen.Name = "mnuRemoveScreen";
            this.mnuRemoveScreen.Size = new System.Drawing.Size(203, 22);
            this.mnuRemoveScreen.Text = "Remove Screen from Menu";
            this.mnuRemoveScreen.Click += new System.EventHandler(this.mnuRemoveScreen_Click);
            // 
            // SFM010_MenuRegister
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(710, 316);
            this.Controls.Add(this.splitterContainer);
            this.MinimumSize = new System.Drawing.Size(700, 350);
            this.Name = "SFM010_MenuRegister";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "SFM010 Menu Register";
            this.Load += new System.EventHandler(this.SFM010_MenuRegister_Load);
            this.Shown += new System.EventHandler(this.SFM010_MenuRegister_Shown);
            this.splitterContainer.Panel1.ResumeLayout(false);
            this.splitterContainer.Panel2.ResumeLayout(false);
            this.splitterContainer.ResumeLayout(false);
            this.evoGroupBox1.ResumeLayout(false);
            this.evoGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtScreen)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ctxMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitterContainer;
        private EVOFramework.Windows.Forms.EVOGroupBox evoGroupBox1;
        private System.Windows.Forms.TreeView trvMenu;
        private EVOFramework.Windows.Forms.EVOGroupBox evoGroupBox2;
        private FarPoint.Win.Spread.FpSpread fpScreen;
        private FarPoint.Win.Spread.SheetView shtScreen;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuRegisterScreen;
        private System.Windows.Forms.ToolStripMenuItem mnuRemoveScreen;
        private System.Windows.Forms.Panel panel1;
        private EVOFramework.Windows.Forms.EVOButton btnMoveDown;
        private EVOFramework.Windows.Forms.EVOButton btnMoveUp;
    }
}