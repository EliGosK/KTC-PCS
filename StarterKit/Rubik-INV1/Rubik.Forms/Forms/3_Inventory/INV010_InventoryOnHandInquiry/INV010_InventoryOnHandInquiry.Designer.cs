namespace Rubik.Inventory
{
    partial class INV010_InventoryOnHandInquiry
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
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType5 = new FarPoint.Win.Spread.CellType.NumberCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INV010_InventoryOnHandInquiry));
            this.fpView = new FarPoint.Win.Spread.FpSpread();
            this.shtView = new FarPoint.Win.Spread.SheetView();
            this.txtFilter = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblHeader = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblInventoryPeriod = new EVOFramework.Windows.Forms.EVOLabel();
            this.panel2 = new EVOFramework.Windows.Forms.EVOPanel();
            this.chkZeroQty = new EVOFramework.Windows.Forms.EVOCheckBox();
            this.rdoGroupItem = new EVOFramework.Windows.Forms.EVORadioButton();
            this.rdoGroupItemLotNo = new EVOFramework.Windows.Forms.EVORadioButton();
            this.dtPeriodBegin = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.dtPeriodEnd = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chkToEndMonth = new EVOFramework.Windows.Forms.EVOCheckBox();
            this.evoLabel2 = new EVOFramework.Windows.Forms.EVOLabel();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.BackColor = System.Drawing.Color.AliceBlue;
            this.pnlContainer.Controls.Add(this.chkToEndMonth);
            this.pnlContainer.Controls.Add(this.lblHeader);
            this.pnlContainer.Controls.Add(this.fpView);
            this.pnlContainer.Controls.Add(this.txtFilter);
            this.pnlContainer.Controls.Add(this.panel2);
            this.pnlContainer.Controls.Add(this.pictureBox1);
            this.pnlContainer.Controls.Add(this.evoLabel2);
            this.pnlContainer.Controls.Add(this.dtPeriodEnd);
            this.pnlContainer.Controls.Add(this.lblInventoryPeriod);
            this.pnlContainer.Controls.Add(this.dtPeriodBegin);
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlContainer.Size = new System.Drawing.Size(992, 608);
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
            this.fpView.Location = new System.Drawing.Point(12, 108);
            this.fpView.Name = "fpView";
            this.fpView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpView.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.AsNeeded;
            this.fpView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtView});
            this.fpView.Size = new System.Drawing.Size(971, 494);
            this.fpView.TabIndex = 0;
            this.fpView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpView_CellDoubleClick);
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
            this.shtView.AutoGenerateColumns = false;
            this.shtView.ColumnHeader.Cells.Get(0, 0).Value = "YEAR_MONTH";
            this.shtView.ColumnHeader.Cells.Get(0, 1).Value = "Location";
            this.shtView.ColumnHeader.Cells.Get(0, 2).Value = "M/N";
            this.shtView.ColumnHeader.Cells.Get(0, 3).Value = "Part No.";
            this.shtView.ColumnHeader.Cells.Get(0, 4).Value = "Customer";
            this.shtView.ColumnHeader.Cells.Get(0, 5).Value = "Pack No.";
            this.shtView.ColumnHeader.Cells.Get(0, 6).Value = "Lot No.";
            this.shtView.ColumnHeader.Cells.Get(0, 7).Value = "External Lot No.";
            this.shtView.ColumnHeader.Cells.Get(0, 8).Value = "On hand Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 9).Value = "Previous Bal";
            this.shtView.ColumnHeader.Cells.Get(0, 10).Value = "Total In Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 11).Value = "Total Out Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 12).Value = "Total Adj Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 13).Value = "Last Recieve";
            this.shtView.ColumnHeader.Cells.Get(0, 14).Value = "On hand query type";
            this.shtView.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtView.Columns.Get(0).AllowAutoFilter = true;
            this.shtView.Columns.Get(0).AllowAutoSort = true;
            this.shtView.Columns.Get(0).Label = "YEAR_MONTH";
            this.shtView.Columns.Get(0).Tag = "YEAR_MONTH";
            this.shtView.Columns.Get(0).Width = 130F;
            this.shtView.Columns.Get(1).AllowAutoFilter = true;
            this.shtView.Columns.Get(1).AllowAutoSort = true;
            this.shtView.Columns.Get(1).Label = "Location";
            this.shtView.Columns.Get(1).Tag = "Location";
            this.shtView.Columns.Get(1).Width = 150F;
            this.shtView.Columns.Get(2).AllowAutoFilter = true;
            this.shtView.Columns.Get(2).AllowAutoSort = true;
            this.shtView.Columns.Get(2).Label = "M/N";
            this.shtView.Columns.Get(2).Tag = "Part Code";
            this.shtView.Columns.Get(2).Width = 100F;
            this.shtView.Columns.Get(3).AllowAutoFilter = true;
            this.shtView.Columns.Get(3).AllowAutoSort = true;
            this.shtView.Columns.Get(3).Label = "Part No.";
            this.shtView.Columns.Get(3).Tag = "Part No.";
            this.shtView.Columns.Get(3).Width = 175F;
            this.shtView.Columns.Get(4).AllowAutoFilter = true;
            this.shtView.Columns.Get(4).AllowAutoSort = true;
            this.shtView.Columns.Get(4).Label = "Customer";
            this.shtView.Columns.Get(4).Tag = "Customer";
            this.shtView.Columns.Get(4).Width = 146F;
            this.shtView.Columns.Get(5).AllowAutoFilter = true;
            this.shtView.Columns.Get(5).AllowAutoSort = true;
            this.shtView.Columns.Get(5).Label = "Pack No.";
            this.shtView.Columns.Get(5).Tag = "Pack No.";
            this.shtView.Columns.Get(5).Width = 120F;
            this.shtView.Columns.Get(6).AllowAutoFilter = true;
            this.shtView.Columns.Get(6).AllowAutoSort = true;
            this.shtView.Columns.Get(6).Label = "Lot No.";
            this.shtView.Columns.Get(6).Tag = "Lot No.";
            this.shtView.Columns.Get(6).Width = 120F;
            this.shtView.Columns.Get(7).AllowAutoFilter = true;
            this.shtView.Columns.Get(7).AllowAutoSort = true;
            this.shtView.Columns.Get(7).Label = "External Lot No.";
            this.shtView.Columns.Get(7).Tag = "External Lot No.";
            this.shtView.Columns.Get(7).Width = 120F;
            this.shtView.Columns.Get(8).AllowAutoFilter = true;
            this.shtView.Columns.Get(8).AllowAutoSort = true;
            numberCellType1.DecimalPlaces = 6;
            numberCellType1.DecimalSeparator = ".";
            numberCellType1.FixedPoint = false;
            numberCellType1.ShowSeparator = true;
            this.shtView.Columns.Get(8).CellType = numberCellType1;
            this.shtView.Columns.Get(8).Label = "On hand Qty";
            this.shtView.Columns.Get(8).Tag = "On hand Qty";
            this.shtView.Columns.Get(8).Width = 120F;
            this.shtView.Columns.Get(9).AllowAutoFilter = true;
            this.shtView.Columns.Get(9).AllowAutoSort = true;
            numberCellType2.DecimalPlaces = 6;
            numberCellType2.FixedPoint = false;
            numberCellType2.ShowSeparator = true;
            this.shtView.Columns.Get(9).CellType = numberCellType2;
            this.shtView.Columns.Get(9).Label = "Previous Bal";
            this.shtView.Columns.Get(9).Tag = "Previous Bal";
            this.shtView.Columns.Get(9).Width = 120F;
            this.shtView.Columns.Get(10).AllowAutoFilter = true;
            this.shtView.Columns.Get(10).AllowAutoSort = true;
            numberCellType3.DecimalPlaces = 6;
            numberCellType3.FixedPoint = false;
            numberCellType3.ShowSeparator = true;
            this.shtView.Columns.Get(10).CellType = numberCellType3;
            this.shtView.Columns.Get(10).Label = "Total In Qty";
            this.shtView.Columns.Get(10).Tag = "Total In Qty";
            this.shtView.Columns.Get(10).Width = 120F;
            this.shtView.Columns.Get(11).AllowAutoFilter = true;
            this.shtView.Columns.Get(11).AllowAutoSort = true;
            numberCellType4.DecimalPlaces = 6;
            numberCellType4.FixedPoint = false;
            numberCellType4.ShowSeparator = true;
            this.shtView.Columns.Get(11).CellType = numberCellType4;
            this.shtView.Columns.Get(11).Label = "Total Out Qty";
            this.shtView.Columns.Get(11).Tag = "Total Out Qty";
            this.shtView.Columns.Get(11).Width = 120F;
            this.shtView.Columns.Get(12).AllowAutoFilter = true;
            this.shtView.Columns.Get(12).AllowAutoSort = true;
            numberCellType5.DecimalPlaces = 6;
            numberCellType5.FixedPoint = false;
            numberCellType5.ShowSeparator = true;
            this.shtView.Columns.Get(12).CellType = numberCellType5;
            this.shtView.Columns.Get(12).Label = "Total Adj Qty";
            this.shtView.Columns.Get(12).Tag = "Total Adj Qty";
            this.shtView.Columns.Get(12).Width = 120F;
            this.shtView.Columns.Get(13).AllowAutoFilter = true;
            this.shtView.Columns.Get(13).AllowAutoSort = true;
            this.shtView.Columns.Get(13).Label = "Last Recieve";
            this.shtView.Columns.Get(13).Tag = "Last Recieve";
            this.shtView.Columns.Get(13).Width = 120F;
            this.shtView.Columns.Get(14).Label = "On hand query type";
            this.shtView.Columns.Get(14).Tag = "On hand query type";
            this.shtView.Columns.Get(14).Width = 120F;
            this.shtView.DataAutoCellTypes = false;
            this.shtView.DataAutoHeadings = false;
            this.shtView.DataAutoSizeColumns = false;
            this.shtView.RowHeader.Columns.Default.Resizable = true;
            this.shtView.RowHeader.Columns.Get(0).AllowAutoSort = true;
            this.shtView.RowHeader.Columns.Get(0).Width = 55F;
            this.shtView.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.shtView.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpView.SetActiveViewport(0, 1, 0);
            // 
            // txtFilter
            // 
            this.txtFilter.AppearanceName = "";
            this.txtFilter.AppearanceReadOnlyName = "";
            this.txtFilter.ControlID = "";
            this.txtFilter.DisableRestrictChar = true;
            this.txtFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtFilter.HelpButton = null;
            this.txtFilter.Location = new System.Drawing.Point(49, 68);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.PathString = null;
            this.txtFilter.PathValue = "";
            this.txtFilter.Size = new System.Drawing.Size(330, 26);
            this.txtFilter.TabIndex = 2;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            this.txtFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFilter_KeyDown);
            // 
            // lblHeader
            // 
            this.lblHeader.AppearanceName = "Title";
            this.lblHeader.ControlID = "";
            this.lblHeader.Font = new System.Drawing.Font("Tahoma", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblHeader.Location = new System.Drawing.Point(5, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.PathString = null;
            this.lblHeader.PathValue = "Inventory on hand";
            this.lblHeader.Size = new System.Drawing.Size(452, 39);
            this.lblHeader.TabIndex = 35;
            this.lblHeader.Text = "Inventory on hand";
            // 
            // lblInventoryPeriod
            // 
            this.lblInventoryPeriod.AppearanceName = "";
            this.lblInventoryPeriod.ControlID = "";
            this.lblInventoryPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblInventoryPeriod.Location = new System.Drawing.Point(522, 22);
            this.lblInventoryPeriod.Name = "lblInventoryPeriod";
            this.lblInventoryPeriod.PathString = null;
            this.lblInventoryPeriod.PathValue = "Inventory Period";
            this.lblInventoryPeriod.Size = new System.Drawing.Size(78, 23);
            this.lblInventoryPeriod.TabIndex = 4;
            this.lblInventoryPeriod.Text = "Inventory Period";
            this.lblInventoryPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.AppearanceName = "";
            this.panel2.Controls.Add(this.chkZeroQty);
            this.panel2.Controls.Add(this.rdoGroupItem);
            this.panel2.Controls.Add(this.rdoGroupItemLotNo);
            this.panel2.Location = new System.Drawing.Point(382, 66);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(436, 30);
            this.panel2.TabIndex = 6;
            // 
            // chkZeroQty
            // 
            this.chkZeroQty.AppearanceName = "";
            this.chkZeroQty.AutoSize = true;
            this.chkZeroQty.CheckedValue = null;
            this.chkZeroQty.ControlID = null;
            this.chkZeroQty.Location = new System.Drawing.Point(328, 5);
            this.chkZeroQty.Name = "chkZeroQty";
            this.chkZeroQty.PathString = null;
            this.chkZeroQty.PathValue = false;
            this.chkZeroQty.Size = new System.Drawing.Size(84, 23);
            this.chkZeroQty.TabIndex = 5;
            this.chkZeroQty.Text = "Qty = 0";
            this.chkZeroQty.UnCheckedValue = null;
            this.chkZeroQty.UseVisualStyleBackColor = true;
            this.chkZeroQty.CheckedChanged += new System.EventHandler(this.chkZeroQty_CheckedChanged);
            // 
            // rdoGroupItem
            // 
            this.rdoGroupItem.AppearanceName = "";
            this.rdoGroupItem.ControlID = null;
            this.rdoGroupItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rdoGroupItem.Location = new System.Drawing.Point(21, 5);
            this.rdoGroupItem.Name = "rdoGroupItem";
            this.rdoGroupItem.PathString = null;
            this.rdoGroupItem.Size = new System.Drawing.Size(109, 23);
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
            this.rdoGroupItemLotNo.Location = new System.Drawing.Point(153, 5);
            this.rdoGroupItemLotNo.Name = "rdoGroupItemLotNo";
            this.rdoGroupItemLotNo.PathString = null;
            this.rdoGroupItemLotNo.Size = new System.Drawing.Size(148, 23);
            this.rdoGroupItemLotNo.SpecificValue = null;
            this.rdoGroupItemLotNo.TabIndex = 2;
            this.rdoGroupItemLotNo.TabStop = true;
            this.rdoGroupItemLotNo.Text = "By Item, Lot No.";
            this.rdoGroupItemLotNo.UseVisualStyleBackColor = true;
            this.rdoGroupItemLotNo.CheckedChanged += new System.EventHandler(this.rdoGroupItemLotNo_CheckedChanged);
            // 
            // dtPeriodBegin
            // 
            this.dtPeriodBegin.AppearanceName = "";
            this.dtPeriodBegin.AppearanceReadOnlyName = "";
            this.dtPeriodBegin.BackColor = System.Drawing.Color.Transparent;
            this.dtPeriodBegin.ControlID = "";
            this.dtPeriodBegin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtPeriodBegin.Format = "dd/MM/yyyy";
            this.dtPeriodBegin.Location = new System.Drawing.Point(616, 20);
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
            this.dtPeriodBegin.ValueChanged += new System.EventHandler(this.dtPeriodBegin_ValueChanged);
            this.dtPeriodBegin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtPeriodBegin_KeyPress);
            // 
            // dtPeriodEnd
            // 
            this.dtPeriodEnd.AppearanceName = "";
            this.dtPeriodEnd.AppearanceReadOnlyName = "";
            this.dtPeriodEnd.BackColor = System.Drawing.Color.Transparent;
            this.dtPeriodEnd.ControlID = "";
            this.dtPeriodEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtPeriodEnd.Format = "dd/MM/yyyy";
            this.dtPeriodEnd.Location = new System.Drawing.Point(812, 20);
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
            this.dtPeriodEnd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtPeriodEnd_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Rubik.Forms.Properties.Resources.FIND_TEXT;
            this.pictureBox1.Location = new System.Drawing.Point(15, 68);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // chkToEndMonth
            // 
            this.chkToEndMonth.AppearanceName = "";
            this.chkToEndMonth.AutoSize = true;
            this.chkToEndMonth.CheckedValue = "";
            this.chkToEndMonth.ControlID = null;
            this.chkToEndMonth.Location = new System.Drawing.Point(791, 26);
            this.chkToEndMonth.Name = "chkToEndMonth";
            this.chkToEndMonth.PathString = null;
            this.chkToEndMonth.PathValue = false;
            this.chkToEndMonth.Size = new System.Drawing.Size(15, 14);
            this.chkToEndMonth.TabIndex = 5;
            this.chkToEndMonth.UnCheckedValue = "";
            this.chkToEndMonth.UseVisualStyleBackColor = true;
            this.chkToEndMonth.CheckedChanged += new System.EventHandler(this.chkToEndMonth_CheckedChanged);
            // 
            // evoLabel2
            // 
            this.evoLabel2.AppearanceName = "";
            this.evoLabel2.ControlID = "";
            this.evoLabel2.Location = new System.Drawing.Point(761, 19);
            this.evoLabel2.Name = "evoLabel2";
            this.evoLabel2.PathString = null;
            this.evoLabel2.PathValue = "-";
            this.evoLabel2.Size = new System.Drawing.Size(19, 29);
            this.evoLabel2.TabIndex = 5;
            this.evoLabel2.Text = "-";
            this.evoLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // INV010_InventoryOnHandInquiry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(992, 666);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "INV010_InventoryOnHandInquiry";
            this.Text = "Inventory OnHand Inquiry";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.INV010_InventoryOnHandInquiry_Load);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread fpView;
        private FarPoint.Win.Spread.SheetView shtView;
        private EVOFramework.Windows.Forms.EVOTextBox txtFilter;
        private EVOFramework.Windows.Forms.EVOLabel lblInventoryPeriod;
        private EVOFramework.Windows.Forms.EVOPanel panel2;
        private EVOFramework.Windows.Forms.EVORadioButton rdoGroupItem;
        private EVOFramework.Windows.Forms.EVORadioButton rdoGroupItemLotNo;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtPeriodBegin;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtPeriodEnd;
        private System.Windows.Forms.PictureBox pictureBox1;
        private EVOFramework.Windows.Forms.EVOLabel lblHeader;
        private EVOFramework.Windows.Forms.EVOCheckBox chkZeroQty;
        private EVOFramework.Windows.Forms.EVOCheckBox chkToEndMonth;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel2;
    }
}
