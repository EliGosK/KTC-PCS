namespace Rubik.StockTaking
{
    partial class STK030_StockTakingEntry
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
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("en-US", false);
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(STK030_StockTakingEntry));
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.miAddPack = new System.Windows.Forms.ToolStripMenuItem();
            this.miDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.fpView = new FarPoint.Win.Spread.FpSpread();
            this.shtView = new FarPoint.Win.Spread.SheetView();
            this.lblHeaderSTK030 = new EVOFramework.Windows.Forms.EVOLabel();
            this.tlpHeader2 = new System.Windows.Forms.TableLayoutPanel();
            this.stcReceiveInfo = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel2 = new EVOFramework.Windows.Forms.EVOLabel();
            this.btnFind = new EVOFramework.Windows.Forms.EVOButton();
            this.evoLabel3 = new EVOFramework.Windows.Forms.EVOLabel();
            this.stdReceiveDate = new EVOFramework.Windows.Forms.EVOLabel();
            this.dtStockTakingDate = new EVOFramework.Windows.Forms.EVODateTextBox();
            this.chkIncomplete = new System.Windows.Forms.CheckBox();
            this.btnCopyData = new EVOFramework.Windows.Forms.EVOButton();
            this.btnUnSelectAll = new EVOFramework.Windows.Forms.EVOButton();
            this.btnSelectAll = new EVOFramework.Windows.Forms.EVOButton();
            this.cboProcess = new EVOFramework.Windows.Forms.EVOComboBox();
            this.txtLotNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.evoLabel1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.btnGo = new EVOFramework.Windows.Forms.EVOButton();
            this.pnlContainer.SuspendLayout();
            this.ctxMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.btnGo);
            this.pnlContainer.Controls.Add(this.evoLabel1);
            this.pnlContainer.Controls.Add(this.txtLotNo);
            this.pnlContainer.Controls.Add(this.cboProcess);
            this.pnlContainer.Controls.Add(this.btnSelectAll);
            this.pnlContainer.Controls.Add(this.btnUnSelectAll);
            this.pnlContainer.Controls.Add(this.btnCopyData);
            this.pnlContainer.Controls.Add(this.chkIncomplete);
            this.pnlContainer.Controls.Add(this.dtStockTakingDate);
            this.pnlContainer.Controls.Add(this.btnFind);
            this.pnlContainer.Controls.Add(this.evoLabel3);
            this.pnlContainer.Controls.Add(this.stdReceiveDate);
            this.pnlContainer.Controls.Add(this.evoLabel2);
            this.pnlContainer.Controls.Add(this.lblHeaderSTK030);
            this.pnlContainer.Controls.Add(this.fpView);
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlContainer.Size = new System.Drawing.Size(992, 477);
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAdd,
            this.miAddPack,
            this.miDelete});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(125, 70);
            this.ctxMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ctxMenu_Opening);
            // 
            // miAdd
            // 
            this.miAdd.Name = "miAdd";
            this.miAdd.Size = new System.Drawing.Size(124, 22);
            this.miAdd.Text = "Add";
            this.miAdd.Click += new System.EventHandler(this.miAdd_Click);
            // 
            // miAddPack
            // 
            this.miAddPack.Name = "miAddPack";
            this.miAddPack.Size = new System.Drawing.Size(124, 22);
            this.miAddPack.Text = "Add Pack";
            this.miAddPack.Visible = false;
            this.miAddPack.Click += new System.EventHandler(this.miAddPack_Click);
            // 
            // miDelete
            // 
            this.miDelete.Name = "miDelete";
            this.miDelete.Size = new System.Drawing.Size(124, 22);
            this.miDelete.Text = "Delete";
            this.miDelete.Click += new System.EventHandler(this.miDelete_Click);
            // 
            // fpView
            // 
            this.fpView.About = "2.5.2015.2005";
            this.fpView.AccessibleDescription = "fpView, Sheet1, Row 0, Column 0, ";
            this.fpView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fpView.BackColor = System.Drawing.Color.AliceBlue;
            this.fpView.ContextMenuStrip = this.ctxMenu;
            this.fpView.EditModeReplace = true;
            this.fpView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.Location = new System.Drawing.Point(0, 109);
            this.fpView.Name = "fpView";
            this.fpView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtView});
            this.fpView.Size = new System.Drawing.Size(992, 368);
            this.fpView.TabIndex = 1;
            this.fpView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.Change += new FarPoint.Win.Spread.ChangeEventHandler(this.fpView_Change);
            this.fpView.LeaveCell += new FarPoint.Win.Spread.LeaveCellEventHandler(this.fpView_LeaveCell);
            this.fpView.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.fpView_ButtonClicked);
            this.fpView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpView_KeyDown);
            this.fpView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fpView_KeyUp);
            this.fpView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fpView_MouseDown);
            // 
            // shtView
            // 
            this.shtView.Reset();
            this.shtView.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtView.ColumnCount = 20;
            this.shtView.RowCount = 5;
            this.shtView.AutoCalculation = false;
            this.shtView.Cells.Get(0, 2).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(0, 2).ParseFormatInfo)).CurrencyNegativePattern = 1;
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(0, 2).ParseFormatInfo)).CurrencySymbol = "฿";
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(0, 2).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(0, 2).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.shtView.Cells.Get(0, 2).ParseFormatString = "n";
            this.shtView.Cells.Get(0, 2).Value = 1;
            this.shtView.Cells.Get(0, 3).Value = "001-P37-001A";
            this.shtView.Cells.Get(0, 5).Value = "BUSH";
            this.shtView.Cells.Get(0, 6).Value = "BTS";
            this.shtView.Cells.Get(0, 8).Value = "100904";
            this.shtView.Cells.Get(0, 12).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(0, 12).ParseFormatInfo)).CurrencyNegativePattern = 1;
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(0, 12).ParseFormatInfo)).CurrencySymbol = "฿";
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(0, 12).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(0, 12).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.shtView.Cells.Get(0, 12).ParseFormatString = "n";
            this.shtView.Cells.Get(0, 12).Value = 300;
            this.shtView.Cells.Get(0, 13).Value = new decimal(new int[] {
            290,
            0,
            0,
            0});
            this.shtView.Cells.Get(0, 14).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(0, 14).ParseFormatInfo)).CurrencyNegativePattern = 1;
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(0, 14).ParseFormatInfo)).CurrencySymbol = "฿";
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(0, 14).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(0, 14).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.shtView.Cells.Get(0, 14).ParseFormatString = "n";
            this.shtView.Cells.Get(0, 14).Value = -10;
            this.shtView.Cells.Get(1, 2).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(1, 2).ParseFormatInfo)).CurrencyNegativePattern = 1;
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(1, 2).ParseFormatInfo)).CurrencySymbol = "฿";
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(1, 2).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(1, 2).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.shtView.Cells.Get(1, 2).ParseFormatString = "n";
            this.shtView.Cells.Get(1, 2).Value = 2;
            this.shtView.Cells.Get(1, 3).Value = "001-P37-001A";
            this.shtView.Cells.Get(1, 5).Value = "BUSH";
            this.shtView.Cells.Get(1, 6).Value = "BTS";
            this.shtView.Cells.Get(1, 8).Value = "100905";
            this.shtView.Cells.Get(1, 12).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(1, 12).ParseFormatInfo)).CurrencyNegativePattern = 1;
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(1, 12).ParseFormatInfo)).CurrencySymbol = "฿";
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(1, 12).ParseFormatInfo)).NumberDecimalDigits = 0;
            this.shtView.Cells.Get(1, 12).ParseFormatString = "n";
            this.shtView.Cells.Get(1, 12).Value = 99991200;
            this.shtView.Cells.Get(1, 13).Value = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            this.shtView.Cells.Get(1, 14).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(1, 14).ParseFormatInfo)).CurrencyNegativePattern = 1;
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(1, 14).ParseFormatInfo)).CurrencySymbol = "฿";
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(1, 14).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(1, 14).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.shtView.Cells.Get(1, 14).ParseFormatString = "n";
            this.shtView.Cells.Get(1, 14).Value = 0;
            this.shtView.Cells.Get(2, 2).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(2, 2).ParseFormatInfo)).CurrencyNegativePattern = 1;
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(2, 2).ParseFormatInfo)).CurrencySymbol = "฿";
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(2, 2).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(2, 2).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.shtView.Cells.Get(2, 2).ParseFormatString = "n";
            this.shtView.Cells.Get(2, 2).Value = 3;
            this.shtView.Cells.Get(2, 3).Value = "001-P86-105B";
            this.shtView.Cells.Get(2, 5).Value = "STOPPER VALVE";
            this.shtView.Cells.Get(2, 6).Value = "YAMAHA";
            this.shtView.Cells.Get(2, 8).Value = "100926";
            this.shtView.Cells.Get(2, 12).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(2, 12).ParseFormatInfo)).CurrencyNegativePattern = 1;
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(2, 12).ParseFormatInfo)).CurrencySymbol = "฿";
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(2, 12).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(2, 12).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.shtView.Cells.Get(2, 12).ParseFormatString = "n";
            this.shtView.Cells.Get(2, 12).Value = 600;
            this.shtView.Cells.Get(2, 13).Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.shtView.Cells.Get(2, 14).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(2, 14).ParseFormatInfo)).CurrencyNegativePattern = 1;
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(2, 14).ParseFormatInfo)).CurrencySymbol = "฿";
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(2, 14).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(2, 14).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.shtView.Cells.Get(2, 14).ParseFormatString = "n";
            this.shtView.Cells.Get(2, 14).Value = 0;
            this.shtView.Cells.Get(3, 2).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(3, 2).ParseFormatInfo)).CurrencyNegativePattern = 1;
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(3, 2).ParseFormatInfo)).CurrencySymbol = "฿";
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(3, 2).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(3, 2).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.shtView.Cells.Get(3, 2).ParseFormatString = "n";
            this.shtView.Cells.Get(3, 2).Value = 4;
            this.shtView.Cells.Get(3, 3).Value = "001-P86-105B";
            this.shtView.Cells.Get(3, 5).Value = "STOPPER VALVE";
            this.shtView.Cells.Get(3, 6).Value = "YAMAHA";
            this.shtView.Cells.Get(3, 8).Value = "100906";
            this.shtView.Cells.Get(3, 12).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(3, 12).ParseFormatInfo)).CurrencyNegativePattern = 1;
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(3, 12).ParseFormatInfo)).CurrencySymbol = "฿";
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(3, 12).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(3, 12).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.shtView.Cells.Get(3, 12).ParseFormatString = "n";
            this.shtView.Cells.Get(3, 12).Value = 0;
            this.shtView.Cells.Get(3, 13).Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.shtView.Cells.Get(3, 14).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(3, 14).ParseFormatInfo)).CurrencyNegativePattern = 1;
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(3, 14).ParseFormatInfo)).CurrencySymbol = "฿";
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(3, 14).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(3, 14).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.shtView.Cells.Get(3, 14).ParseFormatString = "n";
            this.shtView.Cells.Get(3, 14).Value = 150;
            this.shtView.Cells.Get(4, 2).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(4, 2).ParseFormatInfo)).CurrencyNegativePattern = 1;
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(4, 2).ParseFormatInfo)).CurrencySymbol = "฿";
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(4, 2).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(4, 2).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.shtView.Cells.Get(4, 2).ParseFormatString = "n";
            this.shtView.Cells.Get(4, 2).Value = 5;
            this.shtView.Cells.Get(4, 3).Value = "001-P86-110A";
            this.shtView.Cells.Get(4, 5).Value = "STOPPER VALVE";
            this.shtView.Cells.Get(4, 6).Value = "YAMAHA";
            this.shtView.Cells.Get(4, 8).Value = "100813";
            this.shtView.Cells.Get(4, 12).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(4, 12).ParseFormatInfo)).CurrencyNegativePattern = 1;
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(4, 12).ParseFormatInfo)).CurrencySymbol = "฿";
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(4, 12).ParseFormatInfo)).NumberDecimalDigits = 0;
            this.shtView.Cells.Get(4, 12).ParseFormatString = "n";
            this.shtView.Cells.Get(4, 12).Value = 3600;
            this.shtView.Cells.Get(4, 13).Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.shtView.Cells.Get(4, 14).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(4, 14).ParseFormatInfo)).CurrencyNegativePattern = 1;
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(4, 14).ParseFormatInfo)).CurrencySymbol = "฿";
            ((System.Globalization.NumberFormatInfo)(this.shtView.Cells.Get(4, 14).ParseFormatInfo)).NumberDecimalDigits = 0;
            this.shtView.Cells.Get(4, 14).ParseFormatString = "n";
            this.shtView.Cells.Get(4, 14).Value = 3600;
            this.shtView.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.shtView.ColumnHeader.Cells.Get(0, 0).Value = "[STK ID] ซ่อนที่ Initial Screen";
            this.shtView.ColumnHeader.Cells.Get(0, 1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.shtView.ColumnHeader.Cells.Get(0, 1).Value = "Adjust Inventory";
            this.shtView.ColumnHeader.Cells.Get(0, 2).Value = "ID";
            this.shtView.ColumnHeader.Cells.Get(0, 3).Value = "M/N";
            this.shtView.ColumnHeader.Cells.Get(0, 5).Value = "Part No.";
            this.shtView.ColumnHeader.Cells.Get(0, 6).Value = "Customer Name";
            this.shtView.ColumnHeader.Cells.Get(0, 7).Value = "[LOC]";
            this.shtView.ColumnHeader.Cells.Get(0, 8).Value = "Lot No.";
            this.shtView.ColumnHeader.Cells.Get(0, 9).Value = "Customer Lot No.";
            this.shtView.ColumnHeader.Cells.Get(0, 10).Value = "Pack No.";
            this.shtView.ColumnHeader.Cells.Get(0, 11).Value = "FG No.";
            this.shtView.ColumnHeader.Cells.Get(0, 12).Value = "Sys Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 13).Value = "Count Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 14).Value = "Diff";
            this.shtView.ColumnHeader.Cells.Get(0, 15).Value = "[Adjust Flag]";
            this.shtView.ColumnHeader.Cells.Get(0, 16).Value = "[Manual]";
            this.shtView.ColumnHeader.Cells.Get(0, 17).Value = "Tag No.";
            this.shtView.ColumnHeader.Cells.Get(0, 18).Value = "Remark";
            this.shtView.ColumnHeader.Cells.Get(0, 19).Value = "[Row Status]";
            this.shtView.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtView.Columns.Get(0).Label = "[STK ID] ซ่อนที่ Initial Screen";
            this.shtView.Columns.Get(0).Tag = "[STK ID] ซ่อนที่ Initial Screen";
            this.shtView.Columns.Get(0).Width = 68F;
            this.shtView.Columns.Get(1).CellType = checkBoxCellType1;
            this.shtView.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.shtView.Columns.Get(1).Label = "Adjust Inventory";
            this.shtView.Columns.Get(1).Locked = false;
            this.shtView.Columns.Get(1).Tag = "Adjust Inventory";
            this.shtView.Columns.Get(2).Label = "ID";
            this.shtView.Columns.Get(2).Tag = "ID";
            this.shtView.Columns.Get(2).Width = 50F;
            this.shtView.Columns.Get(3).AllowAutoFilter = true;
            this.shtView.Columns.Get(3).AllowAutoSort = true;
            textCellType1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.shtView.Columns.Get(3).CellType = textCellType1;
            this.shtView.Columns.Get(3).Label = "M/N";
            this.shtView.Columns.Get(3).Locked = true;
            this.shtView.Columns.Get(3).Tag = "Master No.";
            this.shtView.Columns.Get(3).Width = 117F;
            buttonCellType1.ShadowSize = 0;
            buttonCellType1.Text = "...";
            this.shtView.Columns.Get(4).CellType = buttonCellType1;
            this.shtView.Columns.Get(4).Locked = false;
            this.shtView.Columns.Get(4).Resizable = false;
            this.shtView.Columns.Get(4).Tag = "ITEM_CD_BTN";
            this.shtView.Columns.Get(4).Width = 25F;
            this.shtView.Columns.Get(5).Label = "Part No.";
            this.shtView.Columns.Get(5).Tag = "Part No.";
            this.shtView.Columns.Get(5).Width = 192F;
            textCellType2.MaxLength = 50;
            this.shtView.Columns.Get(6).CellType = textCellType2;
            this.shtView.Columns.Get(6).Label = "Customer Name";
            this.shtView.Columns.Get(6).Locked = true;
            this.shtView.Columns.Get(6).Tag = "Customer Name";
            this.shtView.Columns.Get(6).Width = 180F;
            this.shtView.Columns.Get(7).Label = "[LOC]";
            this.shtView.Columns.Get(7).Tag = "[LOC]";
            this.shtView.Columns.Get(7).Width = 76F;
            this.shtView.Columns.Get(8).AllowAutoFilter = true;
            this.shtView.Columns.Get(8).AllowAutoSort = true;
            textCellType3.MaxLength = 50;
            this.shtView.Columns.Get(8).CellType = textCellType3;
            this.shtView.Columns.Get(8).Label = "Lot No.";
            this.shtView.Columns.Get(8).Tag = "Lot No.";
            this.shtView.Columns.Get(8).Width = 100F;
            textCellType4.MaxLength = 50;
            this.shtView.Columns.Get(9).CellType = textCellType4;
            this.shtView.Columns.Get(9).Label = "Customer Lot No.";
            this.shtView.Columns.Get(9).Width = 99F;
            this.shtView.Columns.Get(10).AllowAutoFilter = true;
            this.shtView.Columns.Get(10).AllowAutoSort = true;
            textCellType5.MaxLength = 50;
            this.shtView.Columns.Get(10).CellType = textCellType5;
            this.shtView.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.shtView.Columns.Get(10).Label = "Pack No.";
            this.shtView.Columns.Get(10).Tag = "Pack No.";
            this.shtView.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.shtView.Columns.Get(10).Width = 100F;
            this.shtView.Columns.Get(11).AllowAutoFilter = true;
            this.shtView.Columns.Get(11).AllowAutoSort = true;
            this.shtView.Columns.Get(11).CellType = textCellType6;
            this.shtView.Columns.Get(11).Label = "FG No.";
            this.shtView.Columns.Get(11).Tag = "FG No.";
            this.shtView.Columns.Get(11).Width = 100F;
            numberCellType1.DecimalPlaces = 0;
            numberCellType1.MaximumValue = 9999999999.99D;
            numberCellType1.MinimumValue = -9999999999.99D;
            numberCellType1.Separator = ",";
            numberCellType1.ShowSeparator = true;
            this.shtView.Columns.Get(12).CellType = numberCellType1;
            this.shtView.Columns.Get(12).Label = "Sys Qty";
            this.shtView.Columns.Get(12).Tag = "Sys Qty";
            this.shtView.Columns.Get(12).Width = 120F;
            numberCellType2.DecimalPlaces = 0;
            numberCellType2.MaximumValue = 9999999999.99D;
            numberCellType2.MinimumValue = 0D;
            numberCellType2.Separator = ",";
            numberCellType2.ShowSeparator = true;
            this.shtView.Columns.Get(13).CellType = numberCellType2;
            this.shtView.Columns.Get(13).Label = "Count Qty";
            this.shtView.Columns.Get(13).Locked = false;
            this.shtView.Columns.Get(13).Tag = "Count Qty";
            this.shtView.Columns.Get(13).Width = 120F;
            numberCellType3.DecimalPlaces = 0;
            numberCellType3.MaximumValue = 9999999999.99D;
            numberCellType3.MinimumValue = -9999999999.99D;
            numberCellType3.Separator = ",";
            numberCellType3.ShowSeparator = true;
            this.shtView.Columns.Get(14).CellType = numberCellType3;
            this.shtView.Columns.Get(14).Label = "Diff";
            this.shtView.Columns.Get(14).Tag = "Diff";
            this.shtView.Columns.Get(14).Width = 120F;
            this.shtView.Columns.Get(15).Label = "[Adjust Flag]";
            this.shtView.Columns.Get(15).Tag = "[Adjust Flag]";
            this.shtView.Columns.Get(15).Width = 93F;
            this.shtView.Columns.Get(16).Label = "[Manual]";
            this.shtView.Columns.Get(16).Tag = "[Manual]";
            this.shtView.Columns.Get(16).Width = 93F;
            this.shtView.Columns.Get(17).AllowAutoFilter = true;
            this.shtView.Columns.Get(17).AllowAutoSort = true;
            numberCellType4.DecimalPlaces = 0;
            numberCellType4.MaximumValue = 99999D;
            numberCellType4.MinimumValue = 1D;
            this.shtView.Columns.Get(17).CellType = numberCellType4;
            this.shtView.Columns.Get(17).Label = "Tag No.";
            this.shtView.Columns.Get(17).Tag = "Tag No.";
            this.shtView.Columns.Get(17).Width = 120F;
            this.shtView.Columns.Get(18).Label = "Remark";
            this.shtView.Columns.Get(18).Tag = "Remark";
            this.shtView.Columns.Get(18).Width = 150F;
            this.shtView.Columns.Get(19).Label = "[Row Status]";
            this.shtView.Columns.Get(19).Tag = "[Row Status]";
            this.shtView.Columns.Get(19).Width = 91F;
            this.shtView.DataAutoCellTypes = false;
            this.shtView.DataAutoHeadings = false;
            this.shtView.DataAutoSizeColumns = false;
            this.shtView.DefaultStyle.ForeColor = System.Drawing.Color.Blue;
            this.shtView.DefaultStyle.Locked = true;
            this.shtView.DefaultStyle.Parent = "DataAreaDefault";
            this.shtView.LockForeColor = System.Drawing.Color.Black;
            this.shtView.RowHeader.Columns.Default.Resizable = true;
            this.shtView.RowHeader.Columns.Get(0).Width = 50F;
            this.shtView.RowHeader.Visible = false;
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // lblHeaderSTK030
            // 
            this.lblHeaderSTK030.AppearanceName = "Title";
            this.lblHeaderSTK030.AutoSize = true;
            this.lblHeaderSTK030.ControlID = "";
            this.lblHeaderSTK030.Font = new System.Drawing.Font("Tahoma", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblHeaderSTK030.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblHeaderSTK030.Location = new System.Drawing.Point(0, 0);
            this.lblHeaderSTK030.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblHeaderSTK030.Name = "lblHeaderSTK030";
            this.lblHeaderSTK030.PathString = null;
            this.lblHeaderSTK030.PathValue = "Stock Taking Entry";
            this.lblHeaderSTK030.Size = new System.Drawing.Size(317, 39);
            this.lblHeaderSTK030.TabIndex = 37;
            this.lblHeaderSTK030.Text = "Stock Taking Entry";
            // 
            // tlpHeader2
            // 
            this.tlpHeader2.AutoSize = true;
            this.tlpHeader2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tlpHeader2.BackgroundImage")));
            this.tlpHeader2.ColumnCount = 1;
            this.tlpHeader2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpHeader2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHeader2.Location = new System.Drawing.Point(0, 28);
            this.tlpHeader2.Margin = new System.Windows.Forms.Padding(0);
            this.tlpHeader2.Name = "tlpHeader2";
            this.tlpHeader2.RowCount = 1;
            this.tlpHeader2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 566F));
            this.tlpHeader2.Size = new System.Drawing.Size(992, 477);
            this.tlpHeader2.TabIndex = 0;
            // 
            // stcReceiveInfo
            // 
            this.stcReceiveInfo.AppearanceName = "Header";
            this.stcReceiveInfo.AutoSize = true;
            this.stcReceiveInfo.ControlID = "";
            this.stcReceiveInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.stcReceiveInfo.ForeColor = System.Drawing.Color.Navy;
            this.stcReceiveInfo.Location = new System.Drawing.Point(0, 0);
            this.stcReceiveInfo.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.stcReceiveInfo.Name = "stcReceiveInfo";
            this.stcReceiveInfo.PathString = null;
            this.stcReceiveInfo.PathValue = "Receiving Information";
            this.stcReceiveInfo.Size = new System.Drawing.Size(191, 24);
            this.stcReceiveInfo.TabIndex = 0;
            this.stcReceiveInfo.Text = "Receiving Information";
            // 
            // evoLabel2
            // 
            this.evoLabel2.AppearanceName = "Header";
            this.evoLabel2.AutoSize = true;
            this.evoLabel2.ControlID = "";
            this.evoLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel2.ForeColor = System.Drawing.Color.Navy;
            this.evoLabel2.Location = new System.Drawing.Point(9, 39);
            this.evoLabel2.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.evoLabel2.Name = "evoLabel2";
            this.evoLabel2.PathString = null;
            this.evoLabel2.PathValue = "Stock Taking Information";
            this.evoLabel2.Size = new System.Drawing.Size(215, 24);
            this.evoLabel2.TabIndex = 38;
            this.evoLabel2.Text = "Stock Taking Information";
            // 
            // btnFind
            // 
            this.btnFind.AppearanceName = "";
            this.btnFind.ControlID = null;
            this.btnFind.Location = new System.Drawing.Point(876, 72);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 32);
            this.btnFind.TabIndex = 3;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // evoLabel3
            // 
            this.evoLabel3.AppearanceName = "";
            this.evoLabel3.AutoSize = true;
            this.evoLabel3.ControlID = "";
            this.evoLabel3.Location = new System.Drawing.Point(475, 79);
            this.evoLabel3.Name = "evoLabel3";
            this.evoLabel3.PathString = null;
            this.evoLabel3.PathValue = "Process";
            this.evoLabel3.Size = new System.Drawing.Size(62, 19);
            this.evoLabel3.TabIndex = 39;
            this.evoLabel3.Text = "Process";
            // 
            // stdReceiveDate
            // 
            this.stdReceiveDate.AppearanceName = "";
            this.stdReceiveDate.AutoSize = true;
            this.stdReceiveDate.ControlID = "";
            this.stdReceiveDate.Location = new System.Drawing.Point(208, 79);
            this.stdReceiveDate.Name = "stdReceiveDate";
            this.stdReceiveDate.PathString = null;
            this.stdReceiveDate.PathValue = "Stock Taking Date";
            this.stdReceiveDate.Size = new System.Drawing.Size(137, 19);
            this.stdReceiveDate.TabIndex = 39;
            this.stdReceiveDate.Text = "Stock Taking Date";
            // 
            // dtStockTakingDate
            // 
            this.dtStockTakingDate.AppearanceName = "";
            this.dtStockTakingDate.AppearanceReadOnlyName = "";
            this.dtStockTakingDate.ControlID = "";
            this.dtStockTakingDate.DateValue = null;
            this.dtStockTakingDate.Format = "dd/MM/yyyy";
            this.dtStockTakingDate.Location = new System.Drawing.Point(357, 75);
            this.dtStockTakingDate.Mask = "00/00/0000";
            this.dtStockTakingDate.MaxDateTime = new System.DateTime(9998, 12, 31, 23, 59, 59, 999);
            this.dtStockTakingDate.MinDateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtStockTakingDate.Name = "dtStockTakingDate";
            this.dtStockTakingDate.PathString = null;
            this.dtStockTakingDate.PathValue = "  /  /";
            this.dtStockTakingDate.Size = new System.Drawing.Size(100, 27);
            this.dtStockTakingDate.TabIndex = 232325;
            this.dtStockTakingDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkIncomplete
            // 
            this.chkIncomplete.AutoSize = true;
            this.chkIncomplete.Location = new System.Drawing.Point(754, 77);
            this.chkIncomplete.Name = "chkIncomplete";
            this.chkIncomplete.Size = new System.Drawing.Size(107, 23);
            this.chkIncomplete.TabIndex = 3;
            this.chkIncomplete.Text = "Incomplete";
            this.chkIncomplete.UseVisualStyleBackColor = true;
            // 
            // btnCopyData
            // 
            this.btnCopyData.AppearanceName = "";
            this.btnCopyData.ControlID = null;
            this.btnCopyData.Location = new System.Drawing.Point(75, 75);
            this.btnCopyData.Name = "btnCopyData";
            this.btnCopyData.Size = new System.Drawing.Size(103, 26);
            this.btnCopyData.TabIndex = 232326;
            this.btnCopyData.TabStop = false;
            this.btnCopyData.Text = "Copy Data";
            this.btnCopyData.UseVisualStyleBackColor = true;
            this.btnCopyData.Click += new System.EventHandler(this.btnCopyData_Click);
            // 
            // btnUnSelectAll
            // 
            this.btnUnSelectAll.AppearanceName = "";
            this.btnUnSelectAll.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUnSelectAll.BackgroundImage")));
            this.btnUnSelectAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnUnSelectAll.ControlID = null;
            this.btnUnSelectAll.Location = new System.Drawing.Point(43, 75);
            this.btnUnSelectAll.Name = "btnUnSelectAll";
            this.btnUnSelectAll.Size = new System.Drawing.Size(26, 26);
            this.btnUnSelectAll.TabIndex = 232327;
            this.btnUnSelectAll.TabStop = false;
            this.btnUnSelectAll.UseVisualStyleBackColor = true;
            this.btnUnSelectAll.Click += new System.EventHandler(this.btnUnSelectAll_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.AppearanceName = "";
            this.btnSelectAll.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSelectAll.BackgroundImage")));
            this.btnSelectAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSelectAll.ControlID = null;
            this.btnSelectAll.Location = new System.Drawing.Point(11, 75);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(26, 26);
            this.btnSelectAll.TabIndex = 232328;
            this.btnSelectAll.TabStop = false;
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // cboProcess
            // 
            this.cboProcess.AppearanceName = "";
            this.cboProcess.AppearanceReadOnlyName = "";
            this.cboProcess.ControlID = null;
            this.cboProcess.DropDownHeight = 180;
            this.cboProcess.FormattingEnabled = true;
            this.cboProcess.IntegralHeight = false;
            this.cboProcess.Location = new System.Drawing.Point(543, 75);
            this.cboProcess.Name = "cboProcess";
            this.cboProcess.PathString = "";
            this.cboProcess.PathValue = null;
            this.cboProcess.Size = new System.Drawing.Size(184, 27);
            this.cboProcess.TabIndex = 0;
            // 
            // txtLotNo
            // 
            this.txtLotNo.AppearanceName = "";
            this.txtLotNo.AppearanceReadOnlyName = "";
            this.txtLotNo.ControlID = "";
            this.txtLotNo.DisableRestrictChar = false;
            this.txtLotNo.HelpButton = null;
            this.txtLotNo.Location = new System.Drawing.Point(543, 39);
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.PathString = null;
            this.txtLotNo.PathValue = "";
            this.txtLotNo.Size = new System.Drawing.Size(184, 27);
            this.txtLotNo.TabIndex = 4;
            this.txtLotNo.Visible = false;
            this.txtLotNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLotNo_KeyDown);
            // 
            // evoLabel1
            // 
            this.evoLabel1.AppearanceName = "";
            this.evoLabel1.AutoSize = true;
            this.evoLabel1.ControlID = "";
            this.evoLabel1.Location = new System.Drawing.Point(475, 42);
            this.evoLabel1.Name = "evoLabel1";
            this.evoLabel1.PathString = null;
            this.evoLabel1.PathValue = "hiddenLot No.";
            this.evoLabel1.Size = new System.Drawing.Size(109, 19);
            this.evoLabel1.TabIndex = 232330;
            this.evoLabel1.Text = "hiddenLot No.";
            this.evoLabel1.Visible = false;
            // 
            // btnGo
            // 
            this.btnGo.AppearanceName = "";
            this.btnGo.AutoSize = true;
            this.btnGo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGo.BackgroundImage")));
            this.btnGo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGo.ControlID = null;
            this.btnGo.Location = new System.Drawing.Point(730, 38);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(34, 29);
            this.btnGo.TabIndex = 5;
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Visible = false;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // STK030_StockTakingEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(992, 527);
            this.ContextMenuStrip = this.ctxMenu;
            this.Controls.Add(this.tlpHeader2);
            this.MinimumSize = new System.Drawing.Size(600, 390);
            this.Name = "STK030_StockTakingEntry";
            this.Text = "STK030 - Stock Taking Entry";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.STK030_StockTakingEntry_FormClosed);
            this.Load += new System.EventHandler(this.STK030_StockTakingEntry_Load);
            this.Shown += new System.EventHandler(this.STK030_StockTakingEntry_Shown);
            this.Controls.SetChildIndex(this.tlpHeader2, 0);
            this.Controls.SetChildIndex(this.pnlContainer, 0);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.ctxMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem miAdd;
        private FarPoint.Win.Spread.FpSpread fpView;
        private FarPoint.Win.Spread.SheetView shtView;
        private EVOFramework.Windows.Forms.EVOLabel lblHeaderSTK030;
        private System.Windows.Forms.TableLayoutPanel tlpHeader2;
        private EVOFramework.Windows.Forms.EVOLabel stcReceiveInfo;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel2;
        private EVOFramework.Windows.Forms.EVOButton btnFind;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel3;
        private EVOFramework.Windows.Forms.EVOLabel stdReceiveDate;
        private EVOFramework.Windows.Forms.EVODateTextBox dtStockTakingDate;
        private System.Windows.Forms.CheckBox chkIncomplete;
        private System.Windows.Forms.ToolStripMenuItem miDelete;
        private EVOFramework.Windows.Forms.EVOButton btnCopyData;
        private System.Windows.Forms.ToolStripMenuItem miAddPack;
        private EVOFramework.Windows.Forms.EVOButton btnSelectAll;
        private EVOFramework.Windows.Forms.EVOButton btnUnSelectAll;
        protected EVOFramework.Windows.Forms.EVOComboBox cboProcess;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel1;
        private EVOFramework.Windows.Forms.EVOTextBox txtLotNo;
        private EVOFramework.Windows.Forms.EVOButton btnGo;

    }
}
