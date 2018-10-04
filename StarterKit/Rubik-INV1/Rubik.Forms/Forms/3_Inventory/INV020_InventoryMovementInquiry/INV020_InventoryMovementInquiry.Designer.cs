namespace Rubik.Inventory
{
    partial class INV020_InventoryMovementInquiry
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
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INV020_InventoryMovementInquiry));
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.CurrencyCellType currencyCellType1 = new FarPoint.Win.Spread.CellType.CurrencyCellType();
            FarPoint.Win.Spread.CellType.CurrencyCellType currencyCellType2 = new FarPoint.Win.Spread.CellType.CurrencyCellType();
            FarPoint.Win.Spread.CellType.CurrencyCellType currencyCellType3 = new FarPoint.Win.Spread.CellType.CurrencyCellType();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtInvPeriod = new EVOFramework.Windows.Forms.EVOTextBox();
            this.stcInvPeriod = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcLotNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcItem = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcLocation = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtLocation = new EVOFramework.Windows.Forms.EVOTextBox();
            this.txtItem = new EVOFramework.Windows.Forms.EVOTextBox();
            this.txtLotNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblHeader = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcOnHandQty = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtOnHandQty = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.lblItemType = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboItemType = new EVOFramework.Windows.Forms.EVOComboBox();
            this.stcUnitMeasure = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtUnitMeasure = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblPackNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtPackNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.fpView = new FarPoint.Win.Spread.FpSpread();
            this.shtView = new FarPoint.Win.Spread.SheetView();
            this.pnlContainer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.BackColor = System.Drawing.Color.AliceBlue;
            this.pnlContainer.Controls.Add(this.fpView);
            this.pnlContainer.Controls.Add(this.tableLayoutPanel1);
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlContainer.Padding = new System.Windows.Forms.Padding(3);
            this.pnlContainer.Size = new System.Drawing.Size(892, 532);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 134F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 215F));
            this.tableLayoutPanel1.Controls.Add(this.txtInvPeriod, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.stcInvPeriod, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.stcLotNo, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.stcItem, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.stcLocation, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtLocation, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtItem, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtLotNo, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblHeader, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.stcOnHandQty, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtOnHandQty, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblItemType, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cboItemType, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.stcUnitMeasure, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtUnitMeasure, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblPackNo, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtPackNo, 4, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(886, 186);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtInvPeriod
            // 
            this.txtInvPeriod.AppearanceName = "";
            this.txtInvPeriod.AppearanceReadOnlyName = "";
            this.txtInvPeriod.ControlID = "";
            this.txtInvPeriod.DisableRestrictChar = false;
            this.txtInvPeriod.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtInvPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtInvPeriod.HelpButton = null;
            this.txtInvPeriod.Location = new System.Drawing.Point(671, 51);
            this.txtInvPeriod.MaxLength = 30;
            this.txtInvPeriod.Name = "txtInvPeriod";
            this.txtInvPeriod.PathString = null;
            this.txtInvPeriod.PathValue = "";
            this.txtInvPeriod.Size = new System.Drawing.Size(209, 26);
            this.txtInvPeriod.TabIndex = 4;
            // 
            // stcInvPeriod
            // 
            this.stcInvPeriod.AppearanceName = "";
            this.stcInvPeriod.ControlID = "";
            this.stcInvPeriod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stcInvPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.stcInvPeriod.Location = new System.Drawing.Point(537, 48);
            this.stcInvPeriod.Name = "stcInvPeriod";
            this.stcInvPeriod.PathString = null;
            this.stcInvPeriod.PathValue = "Inventory Period:";
            this.stcInvPeriod.Size = new System.Drawing.Size(128, 32);
            this.stcInvPeriod.TabIndex = 6;
            this.stcInvPeriod.Text = "Inventory Period:";
            this.stcInvPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcLotNo
            // 
            this.stcLotNo.AppearanceName = "";
            this.stcLotNo.ControlID = "";
            this.stcLotNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stcLotNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.stcLotNo.Location = new System.Drawing.Point(6, 145);
            this.stcLotNo.Name = "stcLotNo";
            this.stcLotNo.PathString = null;
            this.stcLotNo.PathValue = "LOT No:";
            this.stcLotNo.Size = new System.Drawing.Size(95, 38);
            this.stcLotNo.TabIndex = 2;
            this.stcLotNo.Text = "LOT No:";
            this.stcLotNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcItem
            // 
            this.stcItem.AppearanceName = "";
            this.stcItem.ControlID = "";
            this.stcItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stcItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.stcItem.Location = new System.Drawing.Point(6, 80);
            this.stcItem.Name = "stcItem";
            this.stcItem.PathString = null;
            this.stcItem.PathValue = "Item:";
            this.stcItem.Size = new System.Drawing.Size(95, 32);
            this.stcItem.TabIndex = 1;
            this.stcItem.Text = "Item:";
            this.stcItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcLocation
            // 
            this.stcLocation.AppearanceName = "";
            this.stcLocation.ControlID = "";
            this.stcLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stcLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.stcLocation.Location = new System.Drawing.Point(6, 48);
            this.stcLocation.Name = "stcLocation";
            this.stcLocation.PathString = null;
            this.stcLocation.PathValue = "Location:";
            this.stcLocation.Size = new System.Drawing.Size(95, 32);
            this.stcLocation.TabIndex = 0;
            this.stcLocation.Text = "Location:";
            this.stcLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLocation
            // 
            this.txtLocation.AppearanceName = "";
            this.txtLocation.AppearanceReadOnlyName = "";
            this.txtLocation.ControlID = "";
            this.txtLocation.DisableRestrictChar = false;
            this.txtLocation.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtLocation.HelpButton = null;
            this.txtLocation.Location = new System.Drawing.Point(107, 51);
            this.txtLocation.MaxLength = 20;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.PathString = null;
            this.txtLocation.PathValue = "";
            this.txtLocation.Size = new System.Drawing.Size(415, 26);
            this.txtLocation.TabIndex = 0;
            // 
            // txtItem
            // 
            this.txtItem.AppearanceName = "";
            this.txtItem.AppearanceReadOnlyName = "";
            this.txtItem.ControlID = "";
            this.txtItem.DisableRestrictChar = false;
            this.txtItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtItem.HelpButton = null;
            this.txtItem.Location = new System.Drawing.Point(107, 83);
            this.txtItem.MaxLength = 35;
            this.txtItem.Name = "txtItem";
            this.txtItem.PathString = null;
            this.txtItem.PathValue = "";
            this.txtItem.Size = new System.Drawing.Size(415, 26);
            this.txtItem.TabIndex = 1;
            // 
            // txtLotNo
            // 
            this.txtLotNo.AppearanceName = "";
            this.txtLotNo.AppearanceReadOnlyName = "";
            this.txtLotNo.ControlID = "";
            this.txtLotNo.DisableRestrictChar = false;
            this.txtLotNo.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtLotNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtLotNo.HelpButton = null;
            this.txtLotNo.Location = new System.Drawing.Point(107, 148);
            this.txtLotNo.MaxLength = 10;
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.PathString = null;
            this.txtLotNo.PathValue = "";
            this.txtLotNo.Size = new System.Drawing.Size(415, 26);
            this.txtLotNo.TabIndex = 3;
            // 
            // lblHeader
            // 
            this.lblHeader.AppearanceName = "Title";
            this.lblHeader.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblHeader, 5);
            this.lblHeader.ControlID = "";
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Tahoma", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblHeader.Location = new System.Drawing.Point(6, 3);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Padding = new System.Windows.Forms.Padding(3);
            this.lblHeader.PathString = null;
            this.lblHeader.PathValue = "Inventory Movement Information";
            this.lblHeader.Size = new System.Drawing.Size(874, 45);
            this.lblHeader.TabIndex = 35;
            this.lblHeader.Text = "Inventory Movement Information";
            // 
            // stcOnHandQty
            // 
            this.stcOnHandQty.AppearanceName = "";
            this.stcOnHandQty.ControlID = "";
            this.stcOnHandQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stcOnHandQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.stcOnHandQty.Location = new System.Drawing.Point(537, 80);
            this.stcOnHandQty.Name = "stcOnHandQty";
            this.stcOnHandQty.PathString = null;
            this.stcOnHandQty.PathValue = "On Hand Qty:";
            this.stcOnHandQty.Size = new System.Drawing.Size(128, 32);
            this.stcOnHandQty.TabIndex = 7;
            this.stcOnHandQty.Text = "On Hand Qty:";
            this.stcOnHandQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOnHandQty
            // 
            this.txtOnHandQty.AllowNegative = true;
            this.txtOnHandQty.AppearanceName = "";
            this.txtOnHandQty.AppearanceReadOnlyName = "";
            this.txtOnHandQty.ControlID = "";
            this.txtOnHandQty.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOnHandQty.DecimalPoint = '.';
            this.txtOnHandQty.DigitsInGroup = 3;
            this.txtOnHandQty.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtOnHandQty.Double = 0D;
            this.txtOnHandQty.FixDecimalPosition = false;
            this.txtOnHandQty.Flags = 0;
            this.txtOnHandQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtOnHandQty.GroupSeparator = ',';
            this.txtOnHandQty.Int = 0;
            this.txtOnHandQty.Location = new System.Drawing.Point(671, 83);
            this.txtOnHandQty.Long = ((long)(0));
            this.txtOnHandQty.MaxDecimalPlaces = 6;
            this.txtOnHandQty.MaxWholeDigits = 10;
            this.txtOnHandQty.Name = "txtOnHandQty";
            this.txtOnHandQty.NegativeSign = '-';
            this.txtOnHandQty.PathString = null;
            this.txtOnHandQty.PathValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOnHandQty.Prefix = "";
            this.txtOnHandQty.RangeMax = 1.7976931348623157E+308D;
            this.txtOnHandQty.RangeMin = -1.7976931348623157E+308D;
            this.txtOnHandQty.Size = new System.Drawing.Size(209, 26);
            this.txtOnHandQty.TabIndex = 5;
            this.txtOnHandQty.Text = "0";
            this.txtOnHandQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblItemType
            // 
            this.lblItemType.AppearanceName = "";
            this.lblItemType.ControlID = "";
            this.lblItemType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblItemType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblItemType.Location = new System.Drawing.Point(6, 112);
            this.lblItemType.Name = "lblItemType";
            this.lblItemType.PathString = null;
            this.lblItemType.PathValue = "Part Type:";
            this.lblItemType.Size = new System.Drawing.Size(95, 33);
            this.lblItemType.TabIndex = 2;
            this.lblItemType.Text = "Part Type:";
            this.lblItemType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboItemType
            // 
            this.cboItemType.AppearanceName = "";
            this.cboItemType.AppearanceReadOnlyName = "";
            this.cboItemType.ControlID = null;
            this.cboItemType.Dock = System.Windows.Forms.DockStyle.Top;
            this.cboItemType.DropDownHeight = 180;
            this.cboItemType.FormattingEnabled = true;
            this.cboItemType.IntegralHeight = false;
            this.cboItemType.Location = new System.Drawing.Point(107, 115);
            this.cboItemType.Name = "cboItemType";
            this.cboItemType.PathString = null;
            this.cboItemType.PathValue = null;
            this.cboItemType.Size = new System.Drawing.Size(415, 27);
            this.cboItemType.TabIndex = 2;
            // 
            // stcUnitMeasure
            // 
            this.stcUnitMeasure.AppearanceName = "";
            this.stcUnitMeasure.ControlID = "";
            this.stcUnitMeasure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stcUnitMeasure.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.stcUnitMeasure.Location = new System.Drawing.Point(537, 112);
            this.stcUnitMeasure.Name = "stcUnitMeasure";
            this.stcUnitMeasure.PathString = null;
            this.stcUnitMeasure.PathValue = "Unit Measure:";
            this.stcUnitMeasure.Size = new System.Drawing.Size(128, 33);
            this.stcUnitMeasure.TabIndex = 7;
            this.stcUnitMeasure.Text = "Unit Measure:";
            this.stcUnitMeasure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUnitMeasure
            // 
            this.txtUnitMeasure.AppearanceName = "";
            this.txtUnitMeasure.AppearanceReadOnlyName = "";
            this.txtUnitMeasure.ControlID = "";
            this.txtUnitMeasure.DisableRestrictChar = false;
            this.txtUnitMeasure.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtUnitMeasure.HelpButton = null;
            this.txtUnitMeasure.Location = new System.Drawing.Point(671, 115);
            this.txtUnitMeasure.MaxLength = 30;
            this.txtUnitMeasure.Name = "txtUnitMeasure";
            this.txtUnitMeasure.PathString = null;
            this.txtUnitMeasure.PathValue = "";
            this.txtUnitMeasure.Size = new System.Drawing.Size(209, 27);
            this.txtUnitMeasure.TabIndex = 6;
            // 
            // lblPackNo
            // 
            this.lblPackNo.AppearanceName = "";
            this.lblPackNo.ControlID = "";
            this.lblPackNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPackNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPackNo.Location = new System.Drawing.Point(537, 145);
            this.lblPackNo.Name = "lblPackNo";
            this.lblPackNo.PathString = null;
            this.lblPackNo.PathValue = "Pack No:";
            this.lblPackNo.Size = new System.Drawing.Size(128, 38);
            this.lblPackNo.TabIndex = 36;
            this.lblPackNo.Text = "Pack No:";
            this.lblPackNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPackNo
            // 
            this.txtPackNo.AppearanceName = "";
            this.txtPackNo.AppearanceReadOnlyName = "";
            this.txtPackNo.ControlID = "";
            this.txtPackNo.DisableRestrictChar = false;
            this.txtPackNo.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtPackNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtPackNo.HelpButton = null;
            this.txtPackNo.Location = new System.Drawing.Point(671, 148);
            this.txtPackNo.MaxLength = 10;
            this.txtPackNo.Name = "txtPackNo";
            this.txtPackNo.PathString = null;
            this.txtPackNo.PathValue = "";
            this.txtPackNo.Size = new System.Drawing.Size(209, 26);
            this.txtPackNo.TabIndex = 37;
            // 
            // fpView
            // 
            this.fpView.About = "2.5.2015.2005";
            this.fpView.AccessibleDescription = "fpView, Sheet1";
            this.fpView.BackColor = System.Drawing.Color.AliceBlue;
            this.fpView.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.AsNeeded;
            this.fpView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.Location = new System.Drawing.Point(3, 189);
            this.fpView.Name = "fpView";
            this.fpView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpView.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.AsNeeded;
            this.fpView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtView});
            this.fpView.Size = new System.Drawing.Size(886, 340);
            this.fpView.TabIndex = 0;
            this.fpView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpView_KeyDown);
            // 
            // shtView
            // 
            this.shtView.Reset();
            this.shtView.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtView.ColumnCount = 15;
            this.shtView.RowCount = 0;
            this.shtView.AutoCalculation = false;
            this.shtView.AutoGenerateColumns = false;
            this.shtView.ColumnHeader.Cells.Get(0, 0).Value = "Date";
            this.shtView.ColumnHeader.Cells.Get(0, 1).Value = "Trans ID";
            this.shtView.ColumnHeader.Cells.Get(0, 2).Value = "Trans Info";
            this.shtView.ColumnHeader.Cells.Get(0, 3).Value = "Lot No.";
            this.shtView.ColumnHeader.Cells.Get(0, 4).Value = "In Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 5).Value = "Out Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 6).Value = "Balance";
            this.shtView.ColumnHeader.Cells.Get(0, 7).Value = "NG Criteria";
            this.shtView.ColumnHeader.Cells.Get(0, 8).Value = "NG Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 9).Value = "Price";
            this.shtView.ColumnHeader.Cells.Get(0, 10).Value = "Ref Type";
            this.shtView.ColumnHeader.Cells.Get(0, 11).Value = "Ref Slip No";
            this.shtView.ColumnHeader.Cells.Get(0, 12).Value = "Ref No";
            this.shtView.ColumnHeader.Cells.Get(0, 13).Value = "For Customer";
            this.shtView.ColumnHeader.Cells.Get(0, 14).Value = "Remark";
            this.shtView.ColumnHeader.Rows.Get(0).Height = 40F;
            dateTimeCellType1.Calendar = ((System.Globalization.Calendar)(resources.GetObject("dateTimeCellType1.Calendar")));
            dateTimeCellType1.DateDefault = new System.DateTime(2009, 9, 22, 11, 2, 49, 0);
            dateTimeCellType1.TimeDefault = new System.DateTime(2009, 9, 22, 11, 2, 49, 0);
            dateTimeCellType1.TwoDigitYearMax = 2029;
            this.shtView.Columns.Get(0).CellType = dateTimeCellType1;
            this.shtView.Columns.Get(0).Label = "Date";
            this.shtView.Columns.Get(0).Tag = "TRANS_DATE";
            this.shtView.Columns.Get(0).Width = 100F;
            this.shtView.Columns.Get(1).CellType = textCellType1;
            this.shtView.Columns.Get(1).Label = "Trans ID";
            this.shtView.Columns.Get(1).Tag = "TRANS_ID";
            this.shtView.Columns.Get(1).Width = 123F;
            this.shtView.Columns.Get(2).CellType = textCellType2;
            this.shtView.Columns.Get(2).Label = "Trans Info";
            this.shtView.Columns.Get(2).Tag = "TRANS_INFO";
            this.shtView.Columns.Get(2).Width = 152F;
            this.shtView.Columns.Get(3).Label = "Lot No.";
            this.shtView.Columns.Get(3).Tag = "LOT_NO";
            this.shtView.Columns.Get(3).Width = 100F;
            currencyCellType1.DecimalPlaces = 6;
            currencyCellType1.DecimalSeparator = ".";
            currencyCellType1.FixedPoint = false;
            currencyCellType1.MaximumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            393216});
            currencyCellType1.MinimumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            -2147090432});
            currencyCellType1.Separator = ",";
            currencyCellType1.ShowCurrencySymbol = false;
            currencyCellType1.ShowSeparator = true;
            this.shtView.Columns.Get(4).CellType = currencyCellType1;
            this.shtView.Columns.Get(4).Label = "In Qty";
            this.shtView.Columns.Get(4).Tag = "IN_QTY";
            this.shtView.Columns.Get(4).Width = 110F;
            currencyCellType2.DecimalPlaces = 6;
            currencyCellType2.DecimalSeparator = ".";
            currencyCellType2.FixedPoint = false;
            currencyCellType2.MaximumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            393216});
            currencyCellType2.MinimumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            -2147090432});
            currencyCellType2.ShowCurrencySymbol = false;
            currencyCellType2.ShowSeparator = true;
            this.shtView.Columns.Get(5).CellType = currencyCellType2;
            this.shtView.Columns.Get(5).Label = "Out Qty";
            this.shtView.Columns.Get(5).Tag = "OUT_QTY";
            this.shtView.Columns.Get(5).Width = 101F;
            currencyCellType3.DecimalPlaces = 6;
            currencyCellType3.DecimalSeparator = ".";
            currencyCellType3.FixedPoint = false;
            currencyCellType3.MaximumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            393216});
            currencyCellType3.MinimumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            -2147090432});
            currencyCellType3.NegativeFormat = FarPoint.Win.Spread.CellType.CurrencyNegativeFormat.SignSymbolBefore;
            currencyCellType3.Separator = ",";
            currencyCellType3.ShowCurrencySymbol = false;
            currencyCellType3.ShowSeparator = true;
            this.shtView.Columns.Get(6).CellType = currencyCellType3;
            this.shtView.Columns.Get(6).Label = "Balance";
            this.shtView.Columns.Get(6).Tag = "BALANCE";
            this.shtView.Columns.Get(6).Width = 118F;
            this.shtView.Columns.Get(7).Label = "NG Criteria";
            this.shtView.Columns.Get(7).Width = 100F;
            this.shtView.Columns.Get(8).Label = "NG Qty";
            this.shtView.Columns.Get(8).Width = 100F;
            this.shtView.Columns.Get(9).Label = "Price";
            this.shtView.Columns.Get(9).Tag = "Price";
            this.shtView.Columns.Get(9).Width = 89F;
            this.shtView.Columns.Get(10).Label = "Ref Type";
            this.shtView.Columns.Get(10).Tag = "REF_TYPE";
            this.shtView.Columns.Get(10).Width = 150F;
            this.shtView.Columns.Get(11).Label = "Ref Slip No";
            this.shtView.Columns.Get(11).Tag = "REF_SLIP_NO";
            this.shtView.Columns.Get(11).Width = 158F;
            this.shtView.Columns.Get(12).Label = "Ref No";
            this.shtView.Columns.Get(12).Tag = "Ref No";
            this.shtView.Columns.Get(12).Width = 153F;
            this.shtView.Columns.Get(13).Label = "For Customer";
            this.shtView.Columns.Get(13).Tag = "For Customer";
            this.shtView.Columns.Get(13).Width = 133F;
            this.shtView.Columns.Get(14).Label = "Remark";
            this.shtView.Columns.Get(14).Tag = "Remark";
            this.shtView.Columns.Get(14).Width = 250F;
            this.shtView.DataAutoCellTypes = false;
            this.shtView.DataAutoHeadings = false;
            this.shtView.DataAutoSizeColumns = false;
            this.shtView.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.shtView.RowHeader.Columns.Default.Resizable = true;
            this.shtView.RowHeader.Columns.Get(0).Width = 56F;
            this.shtView.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.shtView.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpView.SetActiveViewport(0, 1, 0);
            // 
            // INV020_InventoryMovementInquiry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 590);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "INV020_InventoryMovementInquiry";
            this.Text = "Inventory Movement Inquiry";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.INV020_InventoryMovementInquiry_Load);
            this.Shown += new System.EventHandler(this.INV020_InventoryMovementInquiry_Shown);
            this.pnlContainer.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private FarPoint.Win.Spread.FpSpread fpView;
        private FarPoint.Win.Spread.SheetView shtView;
        private EVOFramework.Windows.Forms.EVOLabel stcOnHandQty;
        private EVOFramework.Windows.Forms.EVOLabel stcInvPeriod;
        private EVOFramework.Windows.Forms.EVOLabel stcLotNo;
        private EVOFramework.Windows.Forms.EVOLabel stcItem;
        private EVOFramework.Windows.Forms.EVOLabel stcLocation;
        private EVOFramework.Windows.Forms.EVOTextBox txtLocation;
        private EVOFramework.Windows.Forms.EVOTextBox txtItem;
        private EVOFramework.Windows.Forms.EVOTextBox txtLotNo;
        private EVOFramework.Windows.Forms.EVOTextBox txtInvPeriod;
        private EVOFramework.Windows.Forms.EVONumericTextBox txtOnHandQty;
        private EVOFramework.Windows.Forms.EVOLabel lblHeader;
        private EVOFramework.Windows.Forms.EVOLabel stcUnitMeasure;
        private EVOFramework.Windows.Forms.EVOTextBox txtUnitMeasure;
        private EVOFramework.Windows.Forms.EVOLabel lblItemType;
        private EVOFramework.Windows.Forms.EVOComboBox cboItemType;
        private EVOFramework.Windows.Forms.EVOLabel lblPackNo;
        private EVOFramework.Windows.Forms.EVOTextBox txtPackNo;

    }
}