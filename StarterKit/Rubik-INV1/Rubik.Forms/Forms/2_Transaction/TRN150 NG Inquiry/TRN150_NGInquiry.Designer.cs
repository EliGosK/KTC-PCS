namespace Rubik.Inventory
{
    partial class TRN150_NGInquiry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TRN150_NGInquiry));
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType7 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType8 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType9 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.rdoGroupItem = new EVOFramework.Windows.Forms.EVORadioButton();
            this.rdoGroupItemLotNo = new EVOFramework.Windows.Forms.EVORadioButton();
            this.dtPeriodBegin = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.dtPeriodEnd = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.tlpTitle = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblItemCode = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtItemDesc = new EVOFramework.Windows.Forms.EVOTextBox();
            this.btnItemCode = new EVOFramework.Windows.Forms.EVOButton();
            this.txtItemFrom = new Rubik.Forms.UserControl.ItemTextBox();
            this.evoTextBox1 = new EVOFramework.Windows.Forms.EVOTextBox();
            this.evoButton1 = new EVOFramework.Windows.Forms.EVOButton();
            this.txtItemTo = new Rubik.Forms.UserControl.ItemTextBox();
            this.evoLabel1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblWorkResultDate = new EVOFramework.Windows.Forms.EVOLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btlFind = new System.Windows.Forms.Button();
            this.evoPanel1 = new EVOFramework.Windows.Forms.EVOPanel();
            this.txtLotNumber = new EVOFramework.Windows.Forms.EVOTextBox();
            this.fpView = new FarPoint.Win.Spread.FpSpread();
            this.shtView = new FarPoint.Win.Spread.SheetView();
            this.evoLabel2 = new EVOFramework.Windows.Forms.EVOLabel();
            this.pnlContainer.SuspendLayout();
            this.tlpTitle.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.evoPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.BackColor = System.Drawing.Color.AliceBlue;
            this.pnlContainer.Controls.Add(this.evoTextBox1);
            this.pnlContainer.Controls.Add(this.label2);
            this.pnlContainer.Controls.Add(this.dtPeriodBegin);
            this.pnlContainer.Controls.Add(this.lblWorkResultDate);
            this.pnlContainer.Controls.Add(this.evoButton1);
            this.pnlContainer.Controls.Add(this.txtItemTo);
            this.pnlContainer.Controls.Add(this.evoLabel1);
            this.pnlContainer.Controls.Add(this.txtItemDesc);
            this.pnlContainer.Controls.Add(this.txtItemFrom);
            this.pnlContainer.Controls.Add(this.btnItemCode);
            this.pnlContainer.Controls.Add(this.lblItemCode);
            this.pnlContainer.Controls.Add(this.dtPeriodEnd);
            this.pnlContainer.Controls.Add(this.groupBox1);
            this.pnlContainer.Controls.Add(this.evoPanel1);
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlContainer.Size = new System.Drawing.Size(879, 517);
            // 
            // rdoGroupItem
            // 
            this.rdoGroupItem.AppearanceName = "";
            this.rdoGroupItem.Checked = true;
            this.rdoGroupItem.ControlID = null;
            this.rdoGroupItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rdoGroupItem.Location = new System.Drawing.Point(6, 17);
            this.rdoGroupItem.Name = "rdoGroupItem";
            this.rdoGroupItem.PathString = null;
            this.rdoGroupItem.Size = new System.Drawing.Size(109, 26);
            this.rdoGroupItem.SpecificValue = null;
            this.rdoGroupItem.TabIndex = 3;
            this.rdoGroupItem.TabStop = true;
            this.rdoGroupItem.Text = "By Item";
            this.rdoGroupItem.UseVisualStyleBackColor = true;
            this.rdoGroupItem.CheckedChanged += new System.EventHandler(this.rdoGroupItem_CheckedChanged);
            // 
            // rdoGroupItemLotNo
            // 
            this.rdoGroupItemLotNo.AppearanceName = "";
            this.rdoGroupItemLotNo.ControlID = null;
            this.rdoGroupItemLotNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rdoGroupItemLotNo.Location = new System.Drawing.Point(121, 17);
            this.rdoGroupItemLotNo.Name = "rdoGroupItemLotNo";
            this.rdoGroupItemLotNo.PathString = null;
            this.rdoGroupItemLotNo.Size = new System.Drawing.Size(148, 25);
            this.rdoGroupItemLotNo.SpecificValue = null;
            this.rdoGroupItemLotNo.TabIndex = 2;
            this.rdoGroupItemLotNo.Text = "By Item, Lot No.";
            this.rdoGroupItemLotNo.UseVisualStyleBackColor = true;
            // 
            // dtPeriodBegin
            // 
            this.dtPeriodBegin.AppearanceName = "";
            this.dtPeriodBegin.AppearanceReadOnlyName = "";
            this.dtPeriodBegin.BackColor = System.Drawing.Color.Transparent;
            this.dtPeriodBegin.ControlID = "";
            this.dtPeriodBegin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtPeriodBegin.Format = "dd/MM/yyyy";
            this.dtPeriodBegin.Location = new System.Drawing.Point(475, 63);
            this.dtPeriodBegin.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtPeriodBegin.Name = "dtPeriodBegin";
            this.dtPeriodBegin.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtPeriodBegin.NZValue")));
            this.dtPeriodBegin.PathString = null;
            this.dtPeriodBegin.PathValue = ((object)(resources.GetObject("dtPeriodBegin.PathValue")));
            this.dtPeriodBegin.ReadOnly = false;
            this.dtPeriodBegin.ShowButton = true;
            this.dtPeriodBegin.Size = new System.Drawing.Size(139, 26);
            this.dtPeriodBegin.TabIndex = 7;
            this.dtPeriodBegin.Value = null;
            // 
            // dtPeriodEnd
            // 
            this.dtPeriodEnd.AppearanceName = "";
            this.dtPeriodEnd.AppearanceReadOnlyName = "";
            this.dtPeriodEnd.BackColor = System.Drawing.Color.Transparent;
            this.dtPeriodEnd.ControlID = "";
            this.dtPeriodEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtPeriodEnd.Format = "dd/MM/yyyy";
            this.dtPeriodEnd.Location = new System.Drawing.Point(670, 62);
            this.dtPeriodEnd.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtPeriodEnd.Name = "dtPeriodEnd";
            this.dtPeriodEnd.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtPeriodEnd.NZValue")));
            this.dtPeriodEnd.PathString = null;
            this.dtPeriodEnd.PathValue = ((object)(resources.GetObject("dtPeriodEnd.PathValue")));
            this.dtPeriodEnd.ReadOnly = false;
            this.dtPeriodEnd.ShowButton = true;
            this.dtPeriodEnd.Size = new System.Drawing.Size(145, 26);
            this.dtPeriodEnd.TabIndex = 8;
            this.dtPeriodEnd.Value = null;
            // 
            // tlpTitle
            // 
            this.tlpTitle.ColumnCount = 1;
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.Controls.Add(this.label1, 0, 0);
            this.tlpTitle.Location = new System.Drawing.Point(0, 0);
            this.tlpTitle.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTitle.Name = "tlpTitle";
            this.tlpTitle.RowCount = 2;
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpTitle.Size = new System.Drawing.Size(404, 44);
            this.tlpTitle.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AppearanceName = "Title";
            this.label1.AutoSize = true;
            this.label1.ControlID = "";
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.PathString = null;
            this.label1.PathValue = "NG Inquiry";
            this.label1.Size = new System.Drawing.Size(398, 39);
            this.label1.TabIndex = 35;
            this.label1.Text = "NG Inquiry";
            // 
            // lblItemCode
            // 
            this.lblItemCode.AppearanceName = "";
            this.lblItemCode.ControlID = "";
            this.lblItemCode.Location = new System.Drawing.Point(6, 58);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.PathString = null;
            this.lblItemCode.PathValue = "Part From:";
            this.lblItemCode.Size = new System.Drawing.Size(117, 35);
            this.lblItemCode.TabIndex = 100010;
            this.lblItemCode.Text = "Part From:";
            this.lblItemCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtItemDesc
            // 
            this.txtItemDesc.AppearanceName = "";
            this.txtItemDesc.AppearanceReadOnlyName = "";
            this.txtItemDesc.ControlID = "";
            this.txtItemDesc.DisableRestrictChar = false;
            this.txtItemDesc.Enabled = false;
            this.txtItemDesc.HelpButton = null;
            this.txtItemDesc.Location = new System.Drawing.Point(385, 63);
            this.txtItemDesc.MaxLength = 50;
            this.txtItemDesc.Name = "txtItemDesc";
            this.txtItemDesc.PathString = "ItemDesc.Value";
            this.txtItemDesc.PathValue = "";
            this.txtItemDesc.Size = new System.Drawing.Size(20, 27);
            this.txtItemDesc.TabIndex = 100013;
            this.txtItemDesc.Visible = false;
            // 
            // btnItemCode
            // 
            this.btnItemCode.AppearanceName = "";
            this.btnItemCode.AutoSize = true;
            this.btnItemCode.BackgroundImage = global::Rubik.Forms.Properties.Resources.VIEW;
            this.btnItemCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnItemCode.ControlID = null;
            this.btnItemCode.Location = new System.Drawing.Point(345, 61);
            this.btnItemCode.Name = "btnItemCode";
            this.btnItemCode.Size = new System.Drawing.Size(34, 29);
            this.btnItemCode.TabIndex = 100012;
            this.btnItemCode.TabStop = false;
            this.btnItemCode.UseVisualStyleBackColor = true;
            // 
            // txtItemFrom
            // 
            this.txtItemFrom.AllowNegative = true;
            this.txtItemFrom.AppearanceName = "";
            this.txtItemFrom.AppearanceReadOnlyName = "";
            this.txtItemFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtItemFrom.CheckEmpty = true;
            this.txtItemFrom.CheckExist = false;
            this.txtItemFrom.CheckNotExist = true;
            this.txtItemFrom.ControlID = "";
            this.txtItemFrom.CustomerCode = null;
            this.txtItemFrom.CustomerNameTextBox = null;
            this.txtItemFrom.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtItemFrom.DecimalPoint = '.';
            this.txtItemFrom.DescriptionTextBox = this.txtItemDesc;
            this.txtItemFrom.DigitsInGroup = 0;
            this.txtItemFrom.Double = 0D;
            this.txtItemFrom.FixDecimalPosition = true;
            this.txtItemFrom.Flags = 0;
            this.txtItemFrom.GroupSeparator = ',';
            this.txtItemFrom.HelpButton = this.btnItemCode;
            this.txtItemFrom.Int = 0;
            this.txtItemFrom.ItemType = null;
            this.txtItemFrom.Location = new System.Drawing.Point(129, 62);
            this.txtItemFrom.Long = ((long)(0));
            this.txtItemFrom.MaxDecimalPlaces = 0;
            this.txtItemFrom.MaxLength = 50;
            this.txtItemFrom.MaxWholeDigits = 10;
            this.txtItemFrom.Name = "txtItemFrom";
            this.txtItemFrom.NegativeSign = '-';
            this.txtItemFrom.PathString = "ItemCode.Value";
            this.txtItemFrom.PathValue = "";
            this.txtItemFrom.Prefix = "";
            this.txtItemFrom.RangeMax = 9999999999D;
            this.txtItemFrom.RangeMin = 0D;
            this.txtItemFrom.SelectedCustomerData = null;
            this.txtItemFrom.SelectedItemData = null;
            this.txtItemFrom.SelectedItemProcessData = null;
            this.txtItemFrom.Size = new System.Drawing.Size(210, 27);
            this.txtItemFrom.SqlOperator = Rubik.eSqlOperator.In;
            this.txtItemFrom.TabIndex = 100011;
            this.txtItemFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // evoTextBox1
            // 
            this.evoTextBox1.AppearanceName = "";
            this.evoTextBox1.AppearanceReadOnlyName = "";
            this.evoTextBox1.ControlID = "";
            this.evoTextBox1.DisableRestrictChar = false;
            this.evoTextBox1.Enabled = false;
            this.evoTextBox1.HelpButton = null;
            this.evoTextBox1.Location = new System.Drawing.Point(385, 97);
            this.evoTextBox1.MaxLength = 50;
            this.evoTextBox1.Name = "evoTextBox1";
            this.evoTextBox1.PathString = "ItemDesc.Value";
            this.evoTextBox1.PathValue = "";
            this.evoTextBox1.Size = new System.Drawing.Size(20, 27);
            this.evoTextBox1.TabIndex = 100017;
            this.evoTextBox1.Visible = false;
            // 
            // evoButton1
            // 
            this.evoButton1.AppearanceName = "";
            this.evoButton1.AutoSize = true;
            this.evoButton1.BackgroundImage = global::Rubik.Forms.Properties.Resources.VIEW;
            this.evoButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.evoButton1.ControlID = null;
            this.evoButton1.Location = new System.Drawing.Point(345, 96);
            this.evoButton1.Name = "evoButton1";
            this.evoButton1.Size = new System.Drawing.Size(34, 29);
            this.evoButton1.TabIndex = 100016;
            this.evoButton1.TabStop = false;
            this.evoButton1.UseVisualStyleBackColor = true;
            // 
            // txtItemTo
            // 
            this.txtItemTo.AllowNegative = true;
            this.txtItemTo.AppearanceName = "";
            this.txtItemTo.AppearanceReadOnlyName = "";
            this.txtItemTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtItemTo.CheckEmpty = true;
            this.txtItemTo.CheckExist = false;
            this.txtItemTo.CheckNotExist = true;
            this.txtItemTo.ControlID = "";
            this.txtItemTo.CustomerCode = null;
            this.txtItemTo.CustomerNameTextBox = null;
            this.txtItemTo.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtItemTo.DecimalPoint = '.';
            this.txtItemTo.DescriptionTextBox = this.evoTextBox1;
            this.txtItemTo.DigitsInGroup = 0;
            this.txtItemTo.Double = 0D;
            this.txtItemTo.FixDecimalPosition = true;
            this.txtItemTo.Flags = 0;
            this.txtItemTo.GroupSeparator = ',';
            this.txtItemTo.HelpButton = this.evoButton1;
            this.txtItemTo.Int = 0;
            this.txtItemTo.ItemType = null;
            this.txtItemTo.Location = new System.Drawing.Point(129, 97);
            this.txtItemTo.Long = ((long)(0));
            this.txtItemTo.MaxDecimalPlaces = 0;
            this.txtItemTo.MaxLength = 50;
            this.txtItemTo.MaxWholeDigits = 10;
            this.txtItemTo.Name = "txtItemTo";
            this.txtItemTo.NegativeSign = '-';
            this.txtItemTo.PathString = "ItemCode.Value";
            this.txtItemTo.PathValue = "";
            this.txtItemTo.Prefix = "";
            this.txtItemTo.RangeMax = 9999999999D;
            this.txtItemTo.RangeMin = 0D;
            this.txtItemTo.SelectedCustomerData = null;
            this.txtItemTo.SelectedItemData = null;
            this.txtItemTo.SelectedItemProcessData = null;
            this.txtItemTo.Size = new System.Drawing.Size(210, 27);
            this.txtItemTo.SqlOperator = Rubik.eSqlOperator.In;
            this.txtItemTo.TabIndex = 100015;
            this.txtItemTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // evoLabel1
            // 
            this.evoLabel1.AppearanceName = "";
            this.evoLabel1.ControlID = "";
            this.evoLabel1.Location = new System.Drawing.Point(6, 92);
            this.evoLabel1.Name = "evoLabel1";
            this.evoLabel1.PathString = null;
            this.evoLabel1.PathValue = "Part To:";
            this.evoLabel1.Size = new System.Drawing.Size(117, 35);
            this.evoLabel1.TabIndex = 100014;
            this.evoLabel1.Text = "Part To:";
            this.evoLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWorkResultDate
            // 
            this.lblWorkResultDate.AppearanceName = "";
            this.lblWorkResultDate.ControlID = "";
            this.lblWorkResultDate.Location = new System.Drawing.Point(424, 59);
            this.lblWorkResultDate.Name = "lblWorkResultDate";
            this.lblWorkResultDate.PathString = null;
            this.lblWorkResultDate.PathValue = "Date";
            this.lblWorkResultDate.Size = new System.Drawing.Size(45, 33);
            this.lblWorkResultDate.TabIndex = 100019;
            this.lblWorkResultDate.Text = "Date";
            this.lblWorkResultDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoGroupItemLotNo);
            this.groupBox1.Controls.Add(this.rdoGroupItem);
            this.groupBox1.Location = new System.Drawing.Point(428, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 50);
            this.groupBox1.TabIndex = 100020;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(626, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 19);
            this.label2.TabIndex = 100021;
            this.label2.Text = "To";
            // 
            // btlFind
            // 
            this.btlFind.Location = new System.Drawing.Point(734, 100);
            this.btlFind.Name = "btlFind";
            this.btlFind.Size = new System.Drawing.Size(60, 28);
            this.btlFind.TabIndex = 100022;
            this.btlFind.Text = "Find";
            this.btlFind.UseVisualStyleBackColor = true;
            this.btlFind.Click += new System.EventHandler(this.btlFind_Click);
            // 
            // evoPanel1
            // 
            this.evoPanel1.AppearanceName = "";
            this.evoPanel1.Controls.Add(this.txtLotNumber);
            this.evoPanel1.Controls.Add(this.fpView);
            this.evoPanel1.Controls.Add(this.btlFind);
            this.evoPanel1.Controls.Add(this.tlpTitle);
            this.evoPanel1.Controls.Add(this.evoLabel2);
            this.evoPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.evoPanel1.Location = new System.Drawing.Point(0, 0);
            this.evoPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.evoPanel1.Name = "evoPanel1";
            this.evoPanel1.Size = new System.Drawing.Size(879, 517);
            this.evoPanel1.TabIndex = 100023;
            // 
            // txtLotNumber
            // 
            this.txtLotNumber.AppearanceName = "";
            this.txtLotNumber.AppearanceReadOnlyName = "";
            this.txtLotNumber.ControlID = "";
            this.txtLotNumber.DisableRestrictChar = false;
            this.txtLotNumber.HelpButton = null;
            this.txtLotNumber.Location = new System.Drawing.Point(129, 131);
            this.txtLotNumber.MaxLength = 20;
            this.txtLotNumber.Name = "txtLotNumber";
            this.txtLotNumber.PathString = "LotNo.Value";
            this.txtLotNumber.PathValue = "";
            this.txtLotNumber.Size = new System.Drawing.Size(210, 27);
            this.txtLotNumber.TabIndex = 100023;
            // 
            // fpView
            // 
            this.fpView.About = "2.5.2015.2005";
            this.fpView.AccessibleDescription = "fpView, Sheet1";
            this.fpView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fpView.BackColor = System.Drawing.Color.AliceBlue;
            this.fpView.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.AsNeeded;
            this.fpView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.Location = new System.Drawing.Point(0, 169);
            this.fpView.Name = "fpView";
            this.fpView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpView.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.AsNeeded;
            this.fpView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtView});
            this.fpView.Size = new System.Drawing.Size(879, 350);
            this.fpView.TabIndex = 100018;
            this.fpView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpView_KeyDown);
            // 
            // shtView
            // 
            this.shtView.Reset();
            this.shtView.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtView.ColumnCount = 11;
            this.shtView.RowCount = 0;
            this.shtView.AutoGenerateColumns = false;
            this.shtView.ColumnHeader.Cells.Get(0, 0).Value = "Part Code";
            this.shtView.ColumnHeader.Cells.Get(0, 1).Value = "Part Desc ";
            this.shtView.ColumnHeader.Cells.Get(0, 2).Value = "Short Name";
            this.shtView.ColumnHeader.Cells.Get(0, 3).Value = "Lot No.";
            this.shtView.ColumnHeader.Cells.Get(0, 4).Value = "Tran Date";
            this.shtView.ColumnHeader.Cells.Get(0, 5).Value = "Shift";
            this.shtView.ColumnHeader.Cells.Get(0, 6).Value = "NG Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 7).Value = "NG Reason";
            this.shtView.ColumnHeader.Cells.Get(0, 8).Value = "WO No.";
            this.shtView.ColumnHeader.Cells.Get(0, 9).Value = "Remark";
            this.shtView.ColumnHeader.Cells.Get(0, 10).Value = "Work Result Type";
            this.shtView.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtView.Columns.Get(0).AllowAutoFilter = true;
            this.shtView.Columns.Get(0).AllowAutoSort = true;
            this.shtView.Columns.Get(0).CellType = textCellType1;
            this.shtView.Columns.Get(0).Label = "Part Code";
            this.shtView.Columns.Get(0).Locked = true;
            this.shtView.Columns.Get(0).Tag = "Part Code";
            this.shtView.Columns.Get(0).Width = 160F;
            this.shtView.Columns.Get(1).AllowAutoFilter = true;
            this.shtView.Columns.Get(1).AllowAutoSort = true;
            this.shtView.Columns.Get(1).CellType = textCellType2;
            this.shtView.Columns.Get(1).Label = "Part Desc ";
            this.shtView.Columns.Get(1).Locked = true;
            this.shtView.Columns.Get(1).Tag = "Part Description";
            this.shtView.Columns.Get(1).Width = 180F;
            this.shtView.Columns.Get(2).AllowAutoFilter = true;
            this.shtView.Columns.Get(2).AllowAutoSort = true;
            this.shtView.Columns.Get(2).CellType = textCellType3;
            this.shtView.Columns.Get(2).Label = "Short Name";
            this.shtView.Columns.Get(2).Locked = true;
            this.shtView.Columns.Get(2).Tag = "Short Name";
            this.shtView.Columns.Get(2).Width = 140F;
            this.shtView.Columns.Get(3).AllowAutoSort = true;
            this.shtView.Columns.Get(3).CellType = textCellType4;
            this.shtView.Columns.Get(3).Label = "Lot No.";
            this.shtView.Columns.Get(3).Locked = true;
            this.shtView.Columns.Get(3).Tag = "Lot No.";
            this.shtView.Columns.Get(3).Width = 108F;
            this.shtView.Columns.Get(4).AllowAutoFilter = true;
            this.shtView.Columns.Get(4).AllowAutoSort = true;
            dateTimeCellType1.Calendar = ((System.Globalization.Calendar)(resources.GetObject("dateTimeCellType1.Calendar")));
            dateTimeCellType1.DateDefault = new System.DateTime(2011, 5, 13, 16, 12, 12, 0);
            dateTimeCellType1.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
            dateTimeCellType1.TimeDefault = new System.DateTime(2011, 5, 13, 16, 12, 12, 0);
            dateTimeCellType1.TwoDigitYearMax = 2029;
            dateTimeCellType1.UserDefinedFormat = "dd/MM/yyyy";
            this.shtView.Columns.Get(4).CellType = dateTimeCellType1;
            this.shtView.Columns.Get(4).Label = "Tran Date";
            this.shtView.Columns.Get(4).Locked = true;
            this.shtView.Columns.Get(4).Tag = "Tran Date";
            this.shtView.Columns.Get(4).Width = 116F;
            this.shtView.Columns.Get(5).AllowAutoFilter = true;
            this.shtView.Columns.Get(5).AllowAutoSort = true;
            this.shtView.Columns.Get(5).CellType = textCellType5;
            this.shtView.Columns.Get(5).Label = "Shift";
            this.shtView.Columns.Get(5).Locked = true;
            this.shtView.Columns.Get(5).Tag = "Shift";
            this.shtView.Columns.Get(5).Width = 80F;
            this.shtView.Columns.Get(6).AllowAutoFilter = true;
            this.shtView.Columns.Get(6).AllowAutoSort = true;
            numberCellType1.DecimalPlaces = 6;
            numberCellType1.DecimalSeparator = ".";
            numberCellType1.FixedPoint = false;
            this.shtView.Columns.Get(6).CellType = numberCellType1;
            this.shtView.Columns.Get(6).Label = "NG Qty";
            this.shtView.Columns.Get(6).Locked = true;
            this.shtView.Columns.Get(6).Tag = "NG Qty";
            this.shtView.Columns.Get(6).Width = 100F;
            this.shtView.Columns.Get(7).AllowAutoFilter = true;
            this.shtView.Columns.Get(7).AllowAutoSort = true;
            this.shtView.Columns.Get(7).CellType = textCellType6;
            this.shtView.Columns.Get(7).Label = "NG Reason";
            this.shtView.Columns.Get(7).Locked = true;
            this.shtView.Columns.Get(7).Tag = "NG Reason";
            this.shtView.Columns.Get(7).Width = 130F;
            this.shtView.Columns.Get(8).AllowAutoFilter = true;
            this.shtView.Columns.Get(8).AllowAutoSort = true;
            this.shtView.Columns.Get(8).CellType = textCellType7;
            this.shtView.Columns.Get(8).Label = "WO No.";
            this.shtView.Columns.Get(8).Locked = true;
            this.shtView.Columns.Get(8).Tag = "WO No.";
            this.shtView.Columns.Get(8).Width = 101F;
            this.shtView.Columns.Get(9).AllowAutoFilter = true;
            this.shtView.Columns.Get(9).AllowAutoSort = true;
            this.shtView.Columns.Get(9).CellType = textCellType8;
            this.shtView.Columns.Get(9).Label = "Remark";
            this.shtView.Columns.Get(9).Locked = true;
            this.shtView.Columns.Get(9).Tag = "Remark";
            this.shtView.Columns.Get(9).Width = 105F;
            this.shtView.Columns.Get(10).AllowAutoFilter = true;
            this.shtView.Columns.Get(10).AllowAutoSort = true;
            this.shtView.Columns.Get(10).CellType = textCellType9;
            this.shtView.Columns.Get(10).Label = "Work Result Type";
            this.shtView.Columns.Get(10).Locked = true;
            this.shtView.Columns.Get(10).Tag = "Work Result Type";
            this.shtView.Columns.Get(10).Width = 162F;
            this.shtView.DataAutoCellTypes = false;
            this.shtView.DataAutoHeadings = false;
            this.shtView.DataAutoSizeColumns = false;
            this.shtView.RowHeader.Columns.Default.Resizable = true;
            this.shtView.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.shtView.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpView.SetActiveViewport(0, 1, 0);
            // 
            // evoLabel2
            // 
            this.evoLabel2.AppearanceName = "";
            this.evoLabel2.ControlID = "";
            this.evoLabel2.Location = new System.Drawing.Point(6, 126);
            this.evoLabel2.Name = "evoLabel2";
            this.evoLabel2.PathString = null;
            this.evoLabel2.PathValue = "Lot No:";
            this.evoLabel2.Size = new System.Drawing.Size(114, 35);
            this.evoLabel2.TabIndex = 100017;
            this.evoLabel2.Text = "Lot No:";
            this.evoLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TRN150_NGInquiry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(879, 575);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TRN150_NGInquiry";
            this.Text = "TRN150: NG Inquiry";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TRN150_NGInquiry_Load);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.tlpTitle.ResumeLayout(false);
            this.tlpTitle.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.evoPanel1.ResumeLayout(false);
            this.evoPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private EVOFramework.Windows.Forms.EVORadioButton rdoGroupItem;
        private EVOFramework.Windows.Forms.EVORadioButton rdoGroupItemLotNo;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtPeriodEnd;
        private System.Windows.Forms.TableLayoutPanel tlpTitle;
        private EVOFramework.Windows.Forms.EVOLabel label1;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtPeriodBegin;
        private EVOFramework.Windows.Forms.EVOLabel lblItemCode;
        private EVOFramework.Windows.Forms.EVOTextBox txtItemDesc;
        private EVOFramework.Windows.Forms.EVOButton btnItemCode;
        private Rubik.Forms.UserControl.ItemTextBox txtItemFrom;
        private EVOFramework.Windows.Forms.EVOTextBox evoTextBox1;
        private EVOFramework.Windows.Forms.EVOButton evoButton1;
        private Rubik.Forms.UserControl.ItemTextBox txtItemTo;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel1;
        private EVOFramework.Windows.Forms.EVOLabel lblWorkResultDate;
        private System.Windows.Forms.Button btlFind;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private EVOFramework.Windows.Forms.EVOPanel evoPanel1;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel2;
        private FarPoint.Win.Spread.FpSpread fpView;
        private FarPoint.Win.Spread.SheetView shtView;
        private EVOFramework.Windows.Forms.EVOTextBox txtLotNumber;
    }
}
