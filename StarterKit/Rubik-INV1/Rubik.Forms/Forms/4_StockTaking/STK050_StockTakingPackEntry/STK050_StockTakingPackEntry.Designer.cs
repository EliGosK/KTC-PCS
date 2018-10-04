namespace Rubik.StockTaking
{
    partial class STK050_StockTakingPackEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(STK050_StockTakingPackEntry));
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.stcHead = new EVOFramework.Windows.Forms.EVOLabel();
            this.tlpHeader2 = new System.Windows.Forms.TableLayoutPanel();
            this.stcReceiveInfo = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcItemCode = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcItemDesc = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcReqItemCode = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtItemDesc = new EVOFramework.Windows.Forms.EVOTextBox();
            this.btnItemCode = new EVOFramework.Windows.Forms.EVOButton();
            this.cmsOperation = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dmc = new EVOFramework.Data.UIDataModelController(this.components);
            this.evoLabel4 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtPartNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblPackNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtPackNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.txtMasterNo = new Rubik.Forms.UserControl.ItemTextBox();
            this.fpView = new FarPoint.Win.Spread.FpSpread();
            this.shtView = new FarPoint.Win.Spread.SheetView();
            this.evoLabel3 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel5 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtTotalQty = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.evoLabel1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel6 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtFGNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblFGNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel12 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel11 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtNumberOfBox = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.lblTagNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtTagNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.pnlContainer.SuspendLayout();
            this.tlpHeader2.SuspendLayout();
            this.cmsOperation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.txtTagNo);
            this.pnlContainer.Controls.Add(this.lblTagNo);
            this.pnlContainer.Controls.Add(this.evoLabel12);
            this.pnlContainer.Controls.Add(this.evoLabel11);
            this.pnlContainer.Controls.Add(this.txtNumberOfBox);
            this.pnlContainer.Controls.Add(this.txtFGNo);
            this.pnlContainer.Controls.Add(this.lblFGNo);
            this.pnlContainer.Controls.Add(this.evoLabel6);
            this.pnlContainer.Controls.Add(this.evoLabel1);
            this.pnlContainer.Controls.Add(this.txtTotalQty);
            this.pnlContainer.Controls.Add(this.fpView);
            this.pnlContainer.Controls.Add(this.txtPartNo);
            this.pnlContainer.Controls.Add(this.txtPackNo);
            this.pnlContainer.Controls.Add(this.evoLabel5);
            this.pnlContainer.Controls.Add(this.evoLabel3);
            this.pnlContainer.Controls.Add(this.lblPackNo);
            this.pnlContainer.Controls.Add(this.evoLabel4);
            this.pnlContainer.Controls.Add(this.stcItemCode);
            this.pnlContainer.Controls.Add(this.stcItemDesc);
            this.pnlContainer.Controls.Add(this.tlpHeader2);
            this.pnlContainer.Controls.Add(this.stcHead);
            this.pnlContainer.Controls.Add(this.stcReqItemCode);
            this.pnlContainer.Controls.Add(this.txtItemDesc);
            this.pnlContainer.Controls.Add(this.txtMasterNo);
            this.pnlContainer.Controls.Add(this.btnItemCode);
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlContainer.Size = new System.Drawing.Size(881, 528);
            // 
            // stcHead
            // 
            this.stcHead.AppearanceName = "Title";
            this.stcHead.AutoSize = true;
            this.stcHead.ControlID = "";
            this.stcHead.Location = new System.Drawing.Point(10, 21);
            this.stcHead.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.stcHead.Name = "stcHead";
            this.stcHead.PathString = null;
            this.stcHead.PathValue = "Stock Taking Pack Entry (Add Pack)";
            this.stcHead.Size = new System.Drawing.Size(262, 19);
            this.stcHead.TabIndex = 37;
            this.stcHead.Text = "Stock Taking Pack Entry (Add Pack)";
            // 
            // tlpHeader2
            // 
            this.tlpHeader2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpHeader2.AutoSize = true;
            this.tlpHeader2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tlpHeader2.BackgroundImage")));
            this.tlpHeader2.ColumnCount = 1;
            this.tlpHeader2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpHeader2.Controls.Add(this.stcReceiveInfo, 0, 0);
            this.tlpHeader2.Location = new System.Drawing.Point(9, 63);
            this.tlpHeader2.Margin = new System.Windows.Forms.Padding(0);
            this.tlpHeader2.Name = "tlpHeader2";
            this.tlpHeader2.RowCount = 1;
            this.tlpHeader2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHeader2.Size = new System.Drawing.Size(860, 19);
            this.tlpHeader2.TabIndex = 10;
            // 
            // stcReceiveInfo
            // 
            this.stcReceiveInfo.AppearanceName = "Header";
            this.stcReceiveInfo.AutoSize = true;
            this.stcReceiveInfo.ControlID = "";
            this.stcReceiveInfo.Location = new System.Drawing.Point(0, 0);
            this.stcReceiveInfo.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.stcReceiveInfo.Name = "stcReceiveInfo";
            this.stcReceiveInfo.PathString = null;
            this.stcReceiveInfo.PathValue = "Packing Information";
            this.stcReceiveInfo.Size = new System.Drawing.Size(152, 19);
            this.stcReceiveInfo.TabIndex = 0;
            this.stcReceiveInfo.Text = "Packing Information";
            // 
            // stcItemCode
            // 
            this.stcItemCode.AppearanceName = "";
            this.stcItemCode.ControlID = "";
            this.stcItemCode.Location = new System.Drawing.Point(362, 93);
            this.stcItemCode.Name = "stcItemCode";
            this.stcItemCode.PathString = null;
            this.stcItemCode.PathValue = "Part No.";
            this.stcItemCode.Size = new System.Drawing.Size(69, 35);
            this.stcItemCode.TabIndex = 1;
            this.stcItemCode.Text = "Part No.";
            this.stcItemCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcItemDesc
            // 
            this.stcItemDesc.AppearanceName = "";
            this.stcItemDesc.ControlID = "";
            this.stcItemDesc.Location = new System.Drawing.Point(34, 127);
            this.stcItemDesc.Name = "stcItemDesc";
            this.stcItemDesc.PathString = null;
            this.stcItemDesc.PathValue = "Customer Name";
            this.stcItemDesc.Size = new System.Drawing.Size(147, 33);
            this.stcItemDesc.TabIndex = 1;
            this.stcItemDesc.Text = "Customer Name";
            this.stcItemDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcReqItemCode
            // 
            this.stcReqItemCode.AppearanceName = "RequireText";
            this.stcReqItemCode.AutoSize = true;
            this.stcReqItemCode.ControlID = "";
            this.stcReqItemCode.Location = new System.Drawing.Point(10, 101);
            this.stcReqItemCode.Name = "stcReqItemCode";
            this.stcReqItemCode.PathString = null;
            this.stcReqItemCode.PathValue = "*";
            this.stcReqItemCode.Size = new System.Drawing.Size(18, 19);
            this.stcReqItemCode.TabIndex = 3;
            this.stcReqItemCode.Text = "*";
            this.stcReqItemCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtItemDesc
            // 
            this.txtItemDesc.AppearanceName = "";
            this.txtItemDesc.AppearanceReadOnlyName = "";
            this.txtItemDesc.ControlID = "";
            this.txtItemDesc.DisableRestrictChar = false;
            this.txtItemDesc.HelpButton = null;
            this.txtItemDesc.Location = new System.Drawing.Point(187, 130);
            this.txtItemDesc.MaxLength = 50;
            this.txtItemDesc.Name = "txtItemDesc";
            this.txtItemDesc.PathString = "ItemDesc.Value";
            this.txtItemDesc.PathValue = "";
            this.txtItemDesc.ReadOnly = true;
            this.txtItemDesc.Size = new System.Drawing.Size(606, 27);
            this.txtItemDesc.TabIndex = 2;
            // 
            // btnItemCode
            // 
            this.btnItemCode.AppearanceName = "";
            this.btnItemCode.AutoSize = true;
            this.btnItemCode.BackgroundImage = global::Rubik.Forms.Properties.Resources.VIEW;
            this.btnItemCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnItemCode.ControlID = null;
            this.btnItemCode.Location = new System.Drawing.Point(323, 96);
            this.btnItemCode.Name = "btnItemCode";
            this.btnItemCode.Size = new System.Drawing.Size(34, 29);
            this.btnItemCode.TabIndex = 1;
            this.btnItemCode.TabStop = false;
            this.btnItemCode.UseVisualStyleBackColor = true;
            this.btnItemCode.Click += new System.EventHandler(this.btnItemCode_Click);
            // 
            // cmsOperation
            // 
            this.cmsOperation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.duplicateToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cmsOperation.Name = "cmsOperation";
            this.cmsOperation.Size = new System.Drawing.Size(153, 92);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // duplicateToolStripMenuItem
            // 
            this.duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
            this.duplicateToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.duplicateToolStripMenuItem.Text = "Duplicate";
            this.duplicateToolStripMenuItem.Visible = false;
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // evoLabel4
            // 
            this.evoLabel4.AppearanceName = "";
            this.evoLabel4.ControlID = "";
            this.evoLabel4.Location = new System.Drawing.Point(34, 93);
            this.evoLabel4.Name = "evoLabel4";
            this.evoLabel4.PathString = null;
            this.evoLabel4.PathValue = "Master No.";
            this.evoLabel4.Size = new System.Drawing.Size(96, 35);
            this.evoLabel4.TabIndex = 1;
            this.evoLabel4.Text = "Master No.";
            this.evoLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPartNo
            // 
            this.txtPartNo.AppearanceName = "";
            this.txtPartNo.AppearanceReadOnlyName = "";
            this.txtPartNo.ControlID = "";
            this.txtPartNo.DisableRestrictChar = false;
            this.txtPartNo.HelpButton = null;
            this.txtPartNo.Location = new System.Drawing.Point(437, 96);
            this.txtPartNo.MaxLength = 50;
            this.txtPartNo.Name = "txtPartNo";
            this.txtPartNo.PathString = "ShortName.Value";
            this.txtPartNo.PathValue = "";
            this.txtPartNo.Size = new System.Drawing.Size(356, 27);
            this.txtPartNo.TabIndex = 1;
            this.txtPartNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtPartNo_Validating);
            // 
            // lblPackNo
            // 
            this.lblPackNo.AppearanceName = "";
            this.lblPackNo.ControlID = "";
            this.lblPackNo.Location = new System.Drawing.Point(34, 192);
            this.lblPackNo.Name = "lblPackNo";
            this.lblPackNo.PathString = null;
            this.lblPackNo.PathValue = "Pack No.";
            this.lblPackNo.Size = new System.Drawing.Size(96, 33);
            this.lblPackNo.TabIndex = 1;
            this.lblPackNo.Text = "Pack No.";
            this.lblPackNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPackNo
            // 
            this.txtPackNo.AppearanceName = "";
            this.txtPackNo.AppearanceReadOnlyName = "";
            this.txtPackNo.ControlID = "";
            this.txtPackNo.DisableRestrictChar = false;
            this.txtPackNo.HelpButton = null;
            this.txtPackNo.Location = new System.Drawing.Point(187, 196);
            this.txtPackNo.Name = "txtPackNo";
            this.txtPackNo.PathString = null;
            this.txtPackNo.PathValue = "";
            this.txtPackNo.Size = new System.Drawing.Size(606, 27);
            this.txtPackNo.TabIndex = 4;
            // 
            // txtMasterNo
            // 
            this.txtMasterNo.AllowNegative = true;
            this.txtMasterNo.AppearanceName = "";
            this.txtMasterNo.AppearanceReadOnlyName = "";
            this.txtMasterNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMasterNo.CheckEmpty = true;
            this.txtMasterNo.CheckExist = false;
            this.txtMasterNo.CheckNotExist = true;
            this.txtMasterNo.ControlID = "";
            this.txtMasterNo.CustomerCode = null;
            this.txtMasterNo.CustomerNameTextBox = this.txtItemDesc;
            this.txtMasterNo.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMasterNo.DecimalPoint = '.';
            this.txtMasterNo.DescriptionTextBox = this.txtPartNo;
            this.txtMasterNo.DigitsInGroup = 0;
            this.txtMasterNo.Double = 0D;
            this.txtMasterNo.FixDecimalPosition = true;
            this.txtMasterNo.Flags = 0;
            this.txtMasterNo.GroupSeparator = ',';
            this.txtMasterNo.HelpButton = this.btnItemCode;
            this.txtMasterNo.Int = 0;
            this.txtMasterNo.ItemType = null;
            this.txtMasterNo.Location = new System.Drawing.Point(187, 96);
            this.txtMasterNo.Long = ((long)(0));
            this.txtMasterNo.MaxDecimalPlaces = 0;
            this.txtMasterNo.MaxLength = 10;
            this.txtMasterNo.MaxWholeDigits = 10;
            this.txtMasterNo.Name = "txtMasterNo";
            this.txtMasterNo.NegativeSign = '-';
            this.txtMasterNo.PathString = "ItemCode.Value";
            this.txtMasterNo.PathValue = "";
            this.txtMasterNo.Prefix = "";
            this.txtMasterNo.RangeMax = 9999999999D;
            this.txtMasterNo.RangeMin = 0D;
            this.txtMasterNo.SelectedCustomerData = null;
            this.txtMasterNo.SelectedItemData = null;
            this.txtMasterNo.SelectedItemProcessData = null;
            this.txtMasterNo.Size = new System.Drawing.Size(130, 27);
            this.txtMasterNo.SqlOperator = Rubik.eSqlOperator.In;
            this.txtMasterNo.TabIndex = 0;
            this.txtMasterNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMasterNo.KeyPressResult += new Rubik.Forms.UserControl.ItemFoundHandler(this.txtItemCode_KeyPressResult);
            // 
            // fpView
            // 
            this.fpView.About = "2.5.2015.2005";
            this.fpView.AccessibleDescription = "fpView, Sheet1, Row 0, Column 0, ";
            this.fpView.BackColor = System.Drawing.Color.AliceBlue;
            this.fpView.ContextMenuStrip = this.cmsOperation;
            this.fpView.EditModeReplace = true;
            this.fpView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.Location = new System.Drawing.Point(187, 263);
            this.fpView.Name = "fpView";
            this.fpView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtView});
            this.fpView.Size = new System.Drawing.Size(606, 206);
            this.fpView.TabIndex = 7;
            this.fpView.TabStop = false;
            this.fpView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.EditModeOn += new System.EventHandler(this.fpView_EditModeOn);
            this.fpView.EditModeOff += new System.EventHandler(this.fpView_EditModeOff);
            this.fpView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpView_KeyDown);
            // 
            // shtView
            // 
            this.shtView.Reset();
            this.shtView.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtView.ColumnCount = 3;
            this.shtView.RowCount = 0;
            this.shtView.AutoGenerateColumns = false;
            this.shtView.ColumnHeader.Cells.Get(0, 0).Value = "Lot No.";
            this.shtView.ColumnHeader.Cells.Get(0, 1).Value = "Customer Lot No.";
            this.shtView.ColumnHeader.Cells.Get(0, 2).Value = "Qty";
            this.shtView.ColumnHeader.Rows.Get(0).Height = 40F;
            textCellType1.MaxLength = 50;
            this.shtView.Columns.Get(0).CellType = textCellType1;
            this.shtView.Columns.Get(0).Label = "Lot No.";
            this.shtView.Columns.Get(0).Tag = "Lot No.";
            this.shtView.Columns.Get(0).Width = 156F;
            textCellType2.MaxLength = 50;
            this.shtView.Columns.Get(1).CellType = textCellType2;
            this.shtView.Columns.Get(1).Label = "Customer Lot No.";
            this.shtView.Columns.Get(1).Width = 176F;
            this.shtView.Columns.Get(2).Label = "Qty";
            this.shtView.Columns.Get(2).Tag = "Qty";
            this.shtView.Columns.Get(2).Width = 150F;
            this.shtView.DataAutoCellTypes = false;
            this.shtView.DataAutoHeadings = false;
            this.shtView.DataAutoSizeColumns = false;
            this.shtView.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.shtView.RowHeader.Columns.Default.Resizable = true;
            this.shtView.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.shtView.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpView.SetActiveViewport(0, 1, 0);
            // 
            // evoLabel3
            // 
            this.evoLabel3.AppearanceName = "";
            this.evoLabel3.ControlID = "";
            this.evoLabel3.Location = new System.Drawing.Point(34, 263);
            this.evoLabel3.Name = "evoLabel3";
            this.evoLabel3.PathString = null;
            this.evoLabel3.PathValue = "Lot Information";
            this.evoLabel3.Size = new System.Drawing.Size(147, 33);
            this.evoLabel3.TabIndex = 1;
            this.evoLabel3.Text = "Lot Information";
            this.evoLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // evoLabel5
            // 
            this.evoLabel5.AppearanceName = "";
            this.evoLabel5.ControlID = "";
            this.evoLabel5.Location = new System.Drawing.Point(450, 475);
            this.evoLabel5.Name = "evoLabel5";
            this.evoLabel5.PathString = null;
            this.evoLabel5.PathValue = "Total Qty";
            this.evoLabel5.Size = new System.Drawing.Size(96, 25);
            this.evoLabel5.TabIndex = 1;
            this.evoLabel5.Text = "Total Qty";
            this.evoLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.AllowNegative = true;
            this.txtTotalQty.AppearanceName = "";
            this.txtTotalQty.AppearanceReadOnlyName = "";
            this.txtTotalQty.ControlID = "";
            this.txtTotalQty.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalQty.DecimalPoint = '.';
            this.txtTotalQty.DigitsInGroup = 3;
            this.txtTotalQty.Double = 0D;
            this.txtTotalQty.FixDecimalPosition = false;
            this.txtTotalQty.Flags = 0;
            this.txtTotalQty.GroupSeparator = ',';
            this.txtTotalQty.Int = 0;
            this.txtTotalQty.Location = new System.Drawing.Point(562, 475);
            this.txtTotalQty.Long = ((long)(0));
            this.txtTotalQty.MaxDecimalPlaces = 4;
            this.txtTotalQty.MaxWholeDigits = 9;
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.NegativeSign = '-';
            this.txtTotalQty.PathString = null;
            this.txtTotalQty.PathValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalQty.Prefix = "";
            this.txtTotalQty.RangeMax = 1.7976931348623157E+308D;
            this.txtTotalQty.RangeMin = -1.7976931348623157E+308D;
            this.txtTotalQty.ReadOnly = true;
            this.txtTotalQty.Size = new System.Drawing.Size(147, 27);
            this.txtTotalQty.TabIndex = 7;
            this.txtTotalQty.Text = "0";
            // 
            // evoLabel1
            // 
            this.evoLabel1.AppearanceName = "RequireText";
            this.evoLabel1.AutoSize = true;
            this.evoLabel1.ControlID = "";
            this.evoLabel1.Location = new System.Drawing.Point(10, 199);
            this.evoLabel1.Name = "evoLabel1";
            this.evoLabel1.PathString = null;
            this.evoLabel1.PathValue = "*";
            this.evoLabel1.Size = new System.Drawing.Size(18, 19);
            this.evoLabel1.TabIndex = 38;
            this.evoLabel1.Text = "*";
            this.evoLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // evoLabel6
            // 
            this.evoLabel6.AppearanceName = "RequireText";
            this.evoLabel6.AutoSize = true;
            this.evoLabel6.ControlID = "";
            this.evoLabel6.Location = new System.Drawing.Point(10, 270);
            this.evoLabel6.Name = "evoLabel6";
            this.evoLabel6.PathString = null;
            this.evoLabel6.PathValue = "*";
            this.evoLabel6.Size = new System.Drawing.Size(18, 19);
            this.evoLabel6.TabIndex = 39;
            this.evoLabel6.Text = "*";
            this.evoLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFGNo
            // 
            this.txtFGNo.AppearanceName = "";
            this.txtFGNo.AppearanceReadOnlyName = "";
            this.txtFGNo.ControlID = "";
            this.txtFGNo.DisableRestrictChar = false;
            this.txtFGNo.HelpButton = null;
            this.txtFGNo.Location = new System.Drawing.Point(187, 229);
            this.txtFGNo.MaxLength = 50;
            this.txtFGNo.Name = "txtFGNo";
            this.txtFGNo.PathString = null;
            this.txtFGNo.PathValue = "";
            this.txtFGNo.Size = new System.Drawing.Size(252, 27);
            this.txtFGNo.TabIndex = 5;
            // 
            // lblFGNo
            // 
            this.lblFGNo.AppearanceName = "";
            this.lblFGNo.ControlID = "";
            this.lblFGNo.Location = new System.Drawing.Point(34, 225);
            this.lblFGNo.Name = "lblFGNo";
            this.lblFGNo.PathString = null;
            this.lblFGNo.PathValue = "FG No.";
            this.lblFGNo.Size = new System.Drawing.Size(96, 33);
            this.lblFGNo.TabIndex = 40;
            this.lblFGNo.Text = "FG No.";
            this.lblFGNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // evoLabel12
            // 
            this.evoLabel12.AppearanceName = "";
            this.evoLabel12.ControlID = "";
            this.evoLabel12.Location = new System.Drawing.Point(731, 229);
            this.evoLabel12.Name = "evoLabel12";
            this.evoLabel12.PathString = null;
            this.evoLabel12.PathValue = "Boxes";
            this.evoLabel12.Size = new System.Drawing.Size(58, 25);
            this.evoLabel12.TabIndex = 100025;
            this.evoLabel12.Text = "Boxes";
            this.evoLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // evoLabel11
            // 
            this.evoLabel11.AppearanceName = "";
            this.evoLabel11.ControlID = "";
            this.evoLabel11.Location = new System.Drawing.Point(558, 229);
            this.evoLabel11.Name = "evoLabel11";
            this.evoLabel11.PathString = null;
            this.evoLabel11.PathValue = "X";
            this.evoLabel11.Size = new System.Drawing.Size(18, 25);
            this.evoLabel11.TabIndex = 100024;
            this.evoLabel11.Text = "X";
            this.evoLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNumberOfBox
            // 
            this.txtNumberOfBox.AllowNegative = true;
            this.txtNumberOfBox.AppearanceName = "";
            this.txtNumberOfBox.AppearanceReadOnlyName = "";
            this.txtNumberOfBox.BackColor = System.Drawing.SystemColors.Window;
            this.txtNumberOfBox.ControlID = "";
            this.txtNumberOfBox.Decimal = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtNumberOfBox.DecimalPoint = '.';
            this.txtNumberOfBox.DigitsInGroup = 3;
            this.txtNumberOfBox.Double = 1D;
            this.txtNumberOfBox.FixDecimalPosition = false;
            this.txtNumberOfBox.Flags = 0;
            this.txtNumberOfBox.GroupSeparator = ',';
            this.txtNumberOfBox.Int = 1;
            this.txtNumberOfBox.Location = new System.Drawing.Point(582, 229);
            this.txtNumberOfBox.Long = ((long)(1));
            this.txtNumberOfBox.MaxDecimalPlaces = 0;
            this.txtNumberOfBox.MaxLength = 4;
            this.txtNumberOfBox.MaxWholeDigits = 4;
            this.txtNumberOfBox.Name = "txtNumberOfBox";
            this.txtNumberOfBox.NegativeSign = '-';
            this.txtNumberOfBox.PathString = null;
            this.txtNumberOfBox.PathValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtNumberOfBox.Prefix = "";
            this.txtNumberOfBox.RangeMax = 1.7976931348623157E+308D;
            this.txtNumberOfBox.RangeMin = -1.7976931348623157E+308D;
            this.txtNumberOfBox.ReadOnly = true;
            this.txtNumberOfBox.Size = new System.Drawing.Size(149, 27);
            this.txtNumberOfBox.TabIndex = 6;
            this.txtNumberOfBox.Text = "1";
            this.txtNumberOfBox.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumberOfBox_Validating);
            // 
            // lblTagNo
            // 
            this.lblTagNo.AppearanceName = "";
            this.lblTagNo.ControlID = "";
            this.lblTagNo.Location = new System.Drawing.Point(34, 159);
            this.lblTagNo.Name = "lblTagNo";
            this.lblTagNo.PathString = null;
            this.lblTagNo.PathValue = "Tag No.";
            this.lblTagNo.Size = new System.Drawing.Size(96, 33);
            this.lblTagNo.TabIndex = 100026;
            this.lblTagNo.Text = "Tag No.";
            this.lblTagNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTagNo
            // 
            this.txtTagNo.AppearanceName = "";
            this.txtTagNo.AppearanceReadOnlyName = "";
            this.txtTagNo.ControlID = "";
            this.txtTagNo.DisableRestrictChar = false;
            this.txtTagNo.HelpButton = null;
            this.txtTagNo.Location = new System.Drawing.Point(187, 163);
            this.txtTagNo.Name = "txtTagNo";
            this.txtTagNo.PathString = null;
            this.txtTagNo.PathValue = "";
            this.txtTagNo.Size = new System.Drawing.Size(606, 27);
            this.txtTagNo.TabIndex = 3;
            // 
            // STK050_StockTakingPackEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(881, 578);
            this.Name = "STK050_StockTakingPackEntry";
            this.Text = "STK050 - Stock Taking Pack Entry (Add Pack)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TRN080_FormClosed);
            this.Load += new System.EventHandler(this.TRN080_Load);
            this.Shown += new System.EventHandler(this.TRN080_Shown);
            this.Controls.SetChildIndex(this.pnlContainer, 0);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.tlpHeader2.ResumeLayout(false);
            this.tlpHeader2.PerformLayout();
            this.cmsOperation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EVOFramework.Windows.Forms.EVOLabel stcHead;
        private System.Windows.Forms.TableLayoutPanel tlpHeader2;
        private EVOFramework.Windows.Forms.EVOLabel stcReceiveInfo;
        private EVOFramework.Windows.Forms.EVOLabel stcItemCode;
        private EVOFramework.Windows.Forms.EVOLabel stcItemDesc;
        private EVOFramework.Windows.Forms.EVOLabel stcReqItemCode;
        private Rubik.Forms.UserControl.ItemTextBox txtMasterNo;
        private EVOFramework.Windows.Forms.EVOTextBox txtItemDesc;
        private EVOFramework.Data.UIDataModelController dmc;
        private EVOFramework.Windows.Forms.EVOButton btnItemCode;
        private System.Windows.Forms.ContextMenuStrip cmsOperation;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duplicateToolStripMenuItem;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel4;
        private EVOFramework.Windows.Forms.EVOTextBox txtPartNo;
        private EVOFramework.Windows.Forms.EVOTextBox txtPackNo;
        private EVOFramework.Windows.Forms.EVOLabel lblPackNo;
        private FarPoint.Win.Spread.FpSpread fpView;
        private FarPoint.Win.Spread.SheetView shtView;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel3;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel5;
        private EVOFramework.Windows.Forms.EVONumericTextBox txtTotalQty;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel6;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel1;
        private EVOFramework.Windows.Forms.EVOTextBox txtFGNo;
        private EVOFramework.Windows.Forms.EVOLabel lblFGNo;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel12;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel11;
        private EVOFramework.Windows.Forms.EVONumericTextBox txtNumberOfBox;
        private EVOFramework.Windows.Forms.EVOTextBox txtTagNo;
        private EVOFramework.Windows.Forms.EVOLabel lblTagNo;
    }
}
