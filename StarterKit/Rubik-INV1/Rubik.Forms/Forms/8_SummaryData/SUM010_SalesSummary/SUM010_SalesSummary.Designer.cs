namespace Rubik.SummaryData
{
    partial class SUM010_SalesSummary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SUM010_SalesSummary));
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("en-US", false);
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType5 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType6 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType7 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType8 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType9 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType10 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType11 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType12 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType13 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType14 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType15 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType16 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.txtFilter = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblHeader = new EVOFramework.Windows.Forms.EVOLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.evoLabel1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblInventoryPeriod = new EVOFramework.Windows.Forms.EVOLabel();
            this.dtDateEnd = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.dtDateBegin = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.fpInventorySummary = new FarPoint.Win.Spread.FpSpread();
            this.shtInventorySummary = new FarPoint.Win.Spread.SheetView();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpInventorySummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtInventorySummary)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.BackColor = System.Drawing.Color.AliceBlue;
            this.pnlContainer.Controls.Add(this.fpInventorySummary);
            this.pnlContainer.Controls.Add(this.evoLabel1);
            this.pnlContainer.Controls.Add(this.lblInventoryPeriod);
            this.pnlContainer.Controls.Add(this.dtDateEnd);
            this.pnlContainer.Controls.Add(this.dtDateBegin);
            this.pnlContainer.Controls.Add(this.lblHeader);
            this.pnlContainer.Controls.Add(this.txtFilter);
            this.pnlContainer.Controls.Add(this.pictureBox1);
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlContainer.Size = new System.Drawing.Size(992, 608);
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.AppearanceName = "";
            this.txtFilter.AppearanceReadOnlyName = "";
            this.txtFilter.ControlID = "";
            this.txtFilter.DisableRestrictChar = true;
            this.txtFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtFilter.HelpButton = null;
            this.txtFilter.Location = new System.Drawing.Point(349, 21);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.PathString = null;
            this.txtFilter.PathValue = "";
            this.txtFilter.Size = new System.Drawing.Size(191, 26);
            this.txtFilter.TabIndex = 2;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
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
            this.lblHeader.PathValue = "Sales Summary";
            this.lblHeader.Size = new System.Drawing.Size(285, 39);
            this.lblHeader.TabIndex = 35;
            this.lblHeader.Text = "Sales Summary";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Rubik.Forms.Properties.Resources.FIND_TEXT;
            this.pictureBox1.Location = new System.Drawing.Point(315, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // evoLabel1
            // 
            this.evoLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.evoLabel1.AppearanceName = "";
            this.evoLabel1.ControlID = "";
            this.evoLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel1.Location = new System.Drawing.Point(804, 24);
            this.evoLabel1.Name = "evoLabel1";
            this.evoLabel1.PathString = null;
            this.evoLabel1.PathValue = "to";
            this.evoLabel1.Size = new System.Drawing.Size(34, 23);
            this.evoLabel1.TabIndex = 45;
            this.evoLabel1.Text = "to";
            this.evoLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblInventoryPeriod
            // 
            this.lblInventoryPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInventoryPeriod.AppearanceName = "";
            this.lblInventoryPeriod.ControlID = "";
            this.lblInventoryPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblInventoryPeriod.Location = new System.Drawing.Point(546, 24);
            this.lblInventoryPeriod.Name = "lblInventoryPeriod";
            this.lblInventoryPeriod.PathString = null;
            this.lblInventoryPeriod.PathValue = "Delivery Date";
            this.lblInventoryPeriod.Size = new System.Drawing.Size(111, 23);
            this.lblInventoryPeriod.TabIndex = 44;
            this.lblInventoryPeriod.Text = "Delivery Date";
            this.lblInventoryPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtDateEnd
            // 
            this.dtDateEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDateEnd.AppearanceName = "";
            this.dtDateEnd.AppearanceReadOnlyName = "";
            this.dtDateEnd.BackColor = System.Drawing.Color.Transparent;
            this.dtDateEnd.ControlID = "";
            this.dtDateEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtDateEnd.Format = "dd/MM/yyyy";
            this.dtDateEnd.Location = new System.Drawing.Point(844, 22);
            this.dtDateEnd.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtDateEnd.Name = "dtDateEnd";
            this.dtDateEnd.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtDateEnd.NZValue")));
            this.dtDateEnd.PathString = null;
            this.dtDateEnd.PathValue = ((object)(resources.GetObject("dtDateEnd.PathValue")));
            this.dtDateEnd.ReadOnly = false;
            this.dtDateEnd.ShowButton = true;
            this.dtDateEnd.Size = new System.Drawing.Size(139, 26);
            this.dtDateEnd.TabIndex = 47;
            this.dtDateEnd.Value = null;
            // 
            // dtDateBegin
            // 
            this.dtDateBegin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDateBegin.AppearanceName = "";
            this.dtDateBegin.AppearanceReadOnlyName = "";
            this.dtDateBegin.BackColor = System.Drawing.Color.Transparent;
            this.dtDateBegin.ControlID = "";
            this.dtDateBegin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtDateBegin.Format = "dd/MM/yyyy";
            this.dtDateBegin.Location = new System.Drawing.Point(663, 22);
            this.dtDateBegin.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtDateBegin.Name = "dtDateBegin";
            this.dtDateBegin.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtDateBegin.NZValue")));
            this.dtDateBegin.PathString = null;
            this.dtDateBegin.PathValue = ((object)(resources.GetObject("dtDateBegin.PathValue")));
            this.dtDateBegin.ReadOnly = false;
            this.dtDateBegin.ShowButton = true;
            this.dtDateBegin.Size = new System.Drawing.Size(139, 26);
            this.dtDateBegin.TabIndex = 46;
            this.dtDateBegin.Value = null;
            // 
            // fpInventorySummary
            // 
            this.fpInventorySummary.About = "2.5.2015.2005";
            this.fpInventorySummary.AccessibleDescription = "fpInventorySummary, Sheet1, Row 0, Column 0, ";
            this.fpInventorySummary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fpInventorySummary.BackColor = System.Drawing.Color.AliceBlue;
            this.fpInventorySummary.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.AsNeeded;
            this.fpInventorySummary.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpInventorySummary.Location = new System.Drawing.Point(11, 54);
            this.fpInventorySummary.Name = "fpInventorySummary";
            this.fpInventorySummary.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpInventorySummary.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.AsNeeded;
            this.fpInventorySummary.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpInventorySummary.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtInventorySummary});
            this.fpInventorySummary.Size = new System.Drawing.Size(971, 551);
            this.fpInventorySummary.TabIndex = 48;
            this.fpInventorySummary.TabStop = false;
            this.fpInventorySummary.TextTipDelay = 1000;
            this.fpInventorySummary.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpInventorySummary.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpInventorySummary_KeyDown);
            // 
            // shtInventorySummary
            // 
            this.shtInventorySummary.Reset();
            this.shtInventorySummary.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtInventorySummary.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtInventorySummary.ColumnCount = 20;
            this.shtInventorySummary.RowCount = 2;
            this.shtInventorySummary.AutoGenerateColumns = false;
            this.shtInventorySummary.Cells.Get(0, 0).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.shtInventorySummary.Cells.Get(0, 0).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.shtInventorySummary.Cells.Get(0, 0).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.shtInventorySummary.Cells.Get(0, 0).ParseFormatString = "n";
            this.shtInventorySummary.Cells.Get(0, 0).Value = 2001;
            this.shtInventorySummary.Cells.Get(0, 1).Value = "Part1";
            this.shtInventorySummary.Cells.Get(0, 2).Value = "Customer A";
            this.shtInventorySummary.Cells.Get(0, 4).Value = "3000";
            this.shtInventorySummary.Cells.Get(0, 5).Value = "5000";
            this.shtInventorySummary.Cells.Get(0, 6).Value = "0";
            this.shtInventorySummary.Cells.Get(0, 7).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.shtInventorySummary.Cells.Get(0, 7).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.shtInventorySummary.Cells.Get(0, 7).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.shtInventorySummary.Cells.Get(0, 7).ParseFormatString = "n";
            this.shtInventorySummary.Cells.Get(0, 7).Value = 4000;
            this.shtInventorySummary.Cells.Get(0, 8).Value = "0";
            this.shtInventorySummary.Cells.Get(0, 9).Value = "0";
            this.shtInventorySummary.Cells.Get(0, 10).Value = "0";
            this.shtInventorySummary.Cells.Get(0, 11).Value = "0";
            this.shtInventorySummary.Cells.Get(0, 12).Value = "0";
            this.shtInventorySummary.Cells.Get(0, 13).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.shtInventorySummary.Cells.Get(0, 13).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.shtInventorySummary.Cells.Get(0, 13).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.shtInventorySummary.Cells.Get(0, 13).ParseFormatString = "n";
            this.shtInventorySummary.Cells.Get(0, 13).Value = 0;
            this.shtInventorySummary.Cells.Get(0, 14).Value = "2000";
            this.shtInventorySummary.Cells.Get(0, 15).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.shtInventorySummary.Cells.Get(0, 15).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.shtInventorySummary.Cells.Get(0, 15).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.shtInventorySummary.Cells.Get(0, 15).ParseFormatString = "n";
            this.shtInventorySummary.Cells.Get(0, 15).Value = 14000;
            this.shtInventorySummary.Cells.Get(0, 16).Value = "6000";
            this.shtInventorySummary.Cells.Get(0, 17).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.shtInventorySummary.Cells.Get(0, 17).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.shtInventorySummary.Cells.Get(0, 17).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.shtInventorySummary.Cells.Get(0, 17).ParseFormatString = "n";
            this.shtInventorySummary.Cells.Get(0, 17).Value = 15000;
            this.shtInventorySummary.Cells.Get(0, 18).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.shtInventorySummary.Cells.Get(0, 18).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.shtInventorySummary.Cells.Get(0, 18).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.shtInventorySummary.Cells.Get(0, 18).ParseFormatString = "n";
            this.shtInventorySummary.Cells.Get(0, 18).Value = 6000;
            this.shtInventorySummary.Cells.Get(0, 19).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.shtInventorySummary.Cells.Get(0, 19).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.shtInventorySummary.Cells.Get(0, 19).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.shtInventorySummary.Cells.Get(0, 19).ParseFormatString = "n";
            this.shtInventorySummary.Cells.Get(0, 19).Value = 9000;
            this.shtInventorySummary.Cells.Get(1, 0).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.shtInventorySummary.Cells.Get(1, 0).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.shtInventorySummary.Cells.Get(1, 0).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.shtInventorySummary.Cells.Get(1, 0).ParseFormatString = "n";
            this.shtInventorySummary.Cells.Get(1, 0).Value = 2002;
            this.shtInventorySummary.Cells.Get(1, 1).Value = "Part2";
            this.shtInventorySummary.Cells.Get(1, 2).Value = "Customer B";
            this.shtInventorySummary.Cells.Get(1, 4).Value = "2000";
            this.shtInventorySummary.Cells.Get(1, 5).Value = "3000";
            this.shtInventorySummary.Cells.Get(1, 6).Value = "2000";
            this.shtInventorySummary.Cells.Get(1, 7).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.shtInventorySummary.Cells.Get(1, 7).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.shtInventorySummary.Cells.Get(1, 7).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.shtInventorySummary.Cells.Get(1, 7).ParseFormatString = "n";
            this.shtInventorySummary.Cells.Get(1, 7).Value = 0;
            this.shtInventorySummary.Cells.Get(1, 8).Value = "0";
            this.shtInventorySummary.Cells.Get(1, 9).Value = "0";
            this.shtInventorySummary.Cells.Get(1, 10).Value = "0";
            this.shtInventorySummary.Cells.Get(1, 11).Value = "0";
            this.shtInventorySummary.Cells.Get(1, 12).Value = "0";
            this.shtInventorySummary.Cells.Get(1, 13).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.shtInventorySummary.Cells.Get(1, 13).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.shtInventorySummary.Cells.Get(1, 13).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.shtInventorySummary.Cells.Get(1, 13).ParseFormatString = "n";
            this.shtInventorySummary.Cells.Get(1, 13).Value = 0;
            this.shtInventorySummary.Cells.Get(1, 14).Value = "3000";
            this.shtInventorySummary.Cells.Get(1, 15).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.shtInventorySummary.Cells.Get(1, 15).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.shtInventorySummary.Cells.Get(1, 15).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.shtInventorySummary.Cells.Get(1, 15).ParseFormatString = "n";
            this.shtInventorySummary.Cells.Get(1, 15).Value = 10000;
            this.shtInventorySummary.Cells.Get(1, 16).Value = "4000";
            this.shtInventorySummary.Cells.Get(1, 17).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.shtInventorySummary.Cells.Get(1, 17).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.shtInventorySummary.Cells.Get(1, 17).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.shtInventorySummary.Cells.Get(1, 17).ParseFormatString = "n";
            this.shtInventorySummary.Cells.Get(1, 17).Value = 28000;
            this.shtInventorySummary.Cells.Get(1, 18).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.shtInventorySummary.Cells.Get(1, 18).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.shtInventorySummary.Cells.Get(1, 18).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.shtInventorySummary.Cells.Get(1, 18).ParseFormatString = "n";
            this.shtInventorySummary.Cells.Get(1, 18).Value = 9000;
            this.shtInventorySummary.Cells.Get(1, 19).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.shtInventorySummary.Cells.Get(1, 19).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.shtInventorySummary.Cells.Get(1, 19).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.shtInventorySummary.Cells.Get(1, 19).ParseFormatString = "n";
            this.shtInventorySummary.Cells.Get(1, 19).Value = 19000;
            this.shtInventorySummary.ColumnHeader.Cells.Get(0, 0).Value = "M/N";
            this.shtInventorySummary.ColumnHeader.Cells.Get(0, 1).Value = "Part No.";
            this.shtInventorySummary.ColumnHeader.Cells.Get(0, 2).Value = "Customer Name";
            this.shtInventorySummary.ColumnHeader.Cells.Get(0, 3).Value = "Item Level";
            this.shtInventorySummary.ColumnHeader.Cells.Get(0, 4).Value = "Header";
            this.shtInventorySummary.ColumnHeader.Cells.Get(0, 5).Value = "Rolling";
            this.shtInventorySummary.ColumnHeader.Cells.Get(0, 6).Value = "Cutting (KTC)";
            this.shtInventorySummary.ColumnHeader.Cells.Get(0, 7).Value = "Cutting (Sub)";
            this.shtInventorySummary.ColumnHeader.Cells.Get(0, 8).Value = "Plating (KTC)";
            this.shtInventorySummary.ColumnHeader.Cells.Get(0, 9).Value = "Plating (Sub)";
            this.shtInventorySummary.ColumnHeader.Cells.Get(0, 10).Value = "Heat Treatment (Sub)";
            this.shtInventorySummary.ColumnHeader.Cells.Get(0, 11).Value = "Others";
            this.shtInventorySummary.ColumnHeader.Cells.Get(0, 12).Value = "QC";
            this.shtInventorySummary.ColumnHeader.Cells.Get(0, 13).Value = "QC Hold";
            this.shtInventorySummary.ColumnHeader.Cells.Get(0, 14).Value = "Packing";
            this.shtInventorySummary.ColumnHeader.Cells.Get(0, 15).Value = "WIP";
            this.shtInventorySummary.ColumnHeader.Cells.Get(0, 16).Value = "Store (FG)";
            this.shtInventorySummary.ColumnHeader.Cells.Get(0, 17).Value = "Order";
            this.shtInventorySummary.ColumnHeader.Cells.Get(0, 18).Value = "Remain ";
            this.shtInventorySummary.ColumnHeader.Cells.Get(0, 19).Value = "Delivery";
            this.shtInventorySummary.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtInventorySummary.Columns.Get(0).AllowAutoFilter = true;
            this.shtInventorySummary.Columns.Get(0).AllowAutoSort = true;
            this.shtInventorySummary.Columns.Get(0).CellType = textCellType1;
            this.shtInventorySummary.Columns.Get(0).Label = "M/N";
            this.shtInventorySummary.Columns.Get(0).Tag = "M/N";
            this.shtInventorySummary.Columns.Get(0).Width = 90F;
            this.shtInventorySummary.Columns.Get(1).AllowAutoFilter = true;
            this.shtInventorySummary.Columns.Get(1).AllowAutoSort = true;
            this.shtInventorySummary.Columns.Get(1).CellType = textCellType2;
            this.shtInventorySummary.Columns.Get(1).Label = "Part No.";
            this.shtInventorySummary.Columns.Get(1).Tag = "Part Code";
            this.shtInventorySummary.Columns.Get(1).Width = 150F;
            this.shtInventorySummary.Columns.Get(2).AllowAutoFilter = true;
            this.shtInventorySummary.Columns.Get(2).AllowAutoSort = true;
            this.shtInventorySummary.Columns.Get(2).CellType = textCellType3;
            this.shtInventorySummary.Columns.Get(2).Label = "Customer Name";
            this.shtInventorySummary.Columns.Get(2).Tag = "Customer Name";
            this.shtInventorySummary.Columns.Get(2).Width = 150F;
            this.shtInventorySummary.Columns.Get(3).AllowAutoFilter = true;
            this.shtInventorySummary.Columns.Get(3).AllowAutoSort = true;
            this.shtInventorySummary.Columns.Get(3).Label = "Item Level";
            this.shtInventorySummary.Columns.Get(3).Tag = "Item Level";
            this.shtInventorySummary.Columns.Get(3).Width = 90F;
            this.shtInventorySummary.Columns.Get(4).AllowAutoFilter = true;
            this.shtInventorySummary.Columns.Get(4).AllowAutoSort = true;
            numberCellType1.DecimalPlaces = 0;
            numberCellType1.Separator = ",";
            numberCellType1.ShowSeparator = true;
            this.shtInventorySummary.Columns.Get(4).CellType = numberCellType1;
            this.shtInventorySummary.Columns.Get(4).Label = "Header";
            this.shtInventorySummary.Columns.Get(4).Tag = "Header";
            this.shtInventorySummary.Columns.Get(4).Width = 110F;
            this.shtInventorySummary.Columns.Get(5).AllowAutoFilter = true;
            this.shtInventorySummary.Columns.Get(5).AllowAutoSort = true;
            numberCellType2.DecimalPlaces = 0;
            numberCellType2.Separator = ",";
            numberCellType2.ShowSeparator = true;
            this.shtInventorySummary.Columns.Get(5).CellType = numberCellType2;
            this.shtInventorySummary.Columns.Get(5).Label = "Rolling";
            this.shtInventorySummary.Columns.Get(5).Tag = "Rolling";
            this.shtInventorySummary.Columns.Get(5).Width = 110F;
            this.shtInventorySummary.Columns.Get(6).AllowAutoFilter = true;
            this.shtInventorySummary.Columns.Get(6).AllowAutoSort = true;
            numberCellType3.DecimalPlaces = 0;
            numberCellType3.Separator = ",";
            numberCellType3.ShowSeparator = true;
            this.shtInventorySummary.Columns.Get(6).CellType = numberCellType3;
            this.shtInventorySummary.Columns.Get(6).Label = "Cutting (KTC)";
            this.shtInventorySummary.Columns.Get(6).Tag = "Cutting";
            this.shtInventorySummary.Columns.Get(6).Width = 110F;
            this.shtInventorySummary.Columns.Get(7).AllowAutoFilter = true;
            this.shtInventorySummary.Columns.Get(7).AllowAutoSort = true;
            numberCellType4.DecimalPlaces = 0;
            numberCellType4.Separator = ",";
            numberCellType4.ShowSeparator = true;
            this.shtInventorySummary.Columns.Get(7).CellType = numberCellType4;
            this.shtInventorySummary.Columns.Get(7).Label = "Cutting (Sub)";
            this.shtInventorySummary.Columns.Get(7).Tag = "Cutting (Sub)";
            this.shtInventorySummary.Columns.Get(7).Width = 110F;
            this.shtInventorySummary.Columns.Get(8).AllowAutoFilter = true;
            this.shtInventorySummary.Columns.Get(8).AllowAutoSort = true;
            numberCellType5.DecimalPlaces = 0;
            numberCellType5.Separator = ",";
            numberCellType5.ShowSeparator = true;
            this.shtInventorySummary.Columns.Get(8).CellType = numberCellType5;
            this.shtInventorySummary.Columns.Get(8).Label = "Plating (KTC)";
            this.shtInventorySummary.Columns.Get(8).Tag = "Plating (KTC)";
            this.shtInventorySummary.Columns.Get(8).Width = 110F;
            this.shtInventorySummary.Columns.Get(9).AllowAutoFilter = true;
            this.shtInventorySummary.Columns.Get(9).AllowAutoSort = true;
            numberCellType6.DecimalPlaces = 0;
            numberCellType6.Separator = ",";
            numberCellType6.ShowSeparator = true;
            this.shtInventorySummary.Columns.Get(9).CellType = numberCellType6;
            this.shtInventorySummary.Columns.Get(9).Label = "Plating (Sub)";
            this.shtInventorySummary.Columns.Get(9).Tag = "Plating (Sub)";
            this.shtInventorySummary.Columns.Get(9).Width = 110F;
            this.shtInventorySummary.Columns.Get(10).AllowAutoFilter = true;
            this.shtInventorySummary.Columns.Get(10).AllowAutoSort = true;
            numberCellType7.DecimalPlaces = 0;
            numberCellType7.Separator = ",";
            numberCellType7.ShowSeparator = true;
            this.shtInventorySummary.Columns.Get(10).CellType = numberCellType7;
            this.shtInventorySummary.Columns.Get(10).Label = "Heat Treatment (Sub)";
            this.shtInventorySummary.Columns.Get(10).Tag = "Heat Treatment (Sub)";
            this.shtInventorySummary.Columns.Get(10).Width = 172F;
            this.shtInventorySummary.Columns.Get(11).AllowAutoFilter = true;
            this.shtInventorySummary.Columns.Get(11).AllowAutoSort = true;
            numberCellType8.DecimalPlaces = 0;
            numberCellType8.Separator = ",";
            numberCellType8.ShowSeparator = true;
            this.shtInventorySummary.Columns.Get(11).CellType = numberCellType8;
            this.shtInventorySummary.Columns.Get(11).Label = "Others";
            this.shtInventorySummary.Columns.Get(11).Tag = "Others";
            this.shtInventorySummary.Columns.Get(11).Width = 110F;
            this.shtInventorySummary.Columns.Get(12).AllowAutoFilter = true;
            this.shtInventorySummary.Columns.Get(12).AllowAutoSort = true;
            numberCellType9.DecimalPlaces = 0;
            numberCellType9.Separator = ",";
            numberCellType9.ShowSeparator = true;
            this.shtInventorySummary.Columns.Get(12).CellType = numberCellType9;
            this.shtInventorySummary.Columns.Get(12).Label = "QC";
            this.shtInventorySummary.Columns.Get(12).Tag = "QC";
            this.shtInventorySummary.Columns.Get(12).Width = 110F;
            this.shtInventorySummary.Columns.Get(13).AllowAutoFilter = true;
            this.shtInventorySummary.Columns.Get(13).AllowAutoSort = true;
            numberCellType10.DecimalPlaces = 0;
            numberCellType10.Separator = ",";
            numberCellType10.ShowSeparator = true;
            this.shtInventorySummary.Columns.Get(13).CellType = numberCellType10;
            this.shtInventorySummary.Columns.Get(13).Label = "QC Hold";
            this.shtInventorySummary.Columns.Get(13).Locked = false;
            this.shtInventorySummary.Columns.Get(13).Tag = "QC Hold";
            this.shtInventorySummary.Columns.Get(13).Width = 110F;
            this.shtInventorySummary.Columns.Get(14).AllowAutoFilter = true;
            this.shtInventorySummary.Columns.Get(14).AllowAutoSort = true;
            numberCellType11.DecimalPlaces = 0;
            numberCellType11.Separator = ",";
            numberCellType11.ShowSeparator = true;
            this.shtInventorySummary.Columns.Get(14).CellType = numberCellType11;
            this.shtInventorySummary.Columns.Get(14).Label = "Packing";
            this.shtInventorySummary.Columns.Get(14).Tag = "Packing";
            this.shtInventorySummary.Columns.Get(14).Width = 110F;
            this.shtInventorySummary.Columns.Get(15).AllowAutoFilter = true;
            this.shtInventorySummary.Columns.Get(15).AllowAutoSort = true;
            numberCellType12.DecimalPlaces = 0;
            numberCellType12.Separator = ",";
            numberCellType12.ShowSeparator = true;
            this.shtInventorySummary.Columns.Get(15).CellType = numberCellType12;
            this.shtInventorySummary.Columns.Get(15).Label = "WIP";
            this.shtInventorySummary.Columns.Get(15).Tag = "WIP";
            this.shtInventorySummary.Columns.Get(15).Width = 110F;
            this.shtInventorySummary.Columns.Get(16).AllowAutoFilter = true;
            this.shtInventorySummary.Columns.Get(16).AllowAutoSort = true;
            numberCellType13.DecimalPlaces = 0;
            numberCellType13.Separator = ",";
            numberCellType13.ShowSeparator = true;
            this.shtInventorySummary.Columns.Get(16).CellType = numberCellType13;
            this.shtInventorySummary.Columns.Get(16).Label = "Store (FG)";
            this.shtInventorySummary.Columns.Get(16).Tag = "Store (FG)";
            this.shtInventorySummary.Columns.Get(16).Width = 110F;
            this.shtInventorySummary.Columns.Get(17).AllowAutoFilter = true;
            this.shtInventorySummary.Columns.Get(17).AllowAutoSort = true;
            numberCellType14.DecimalPlaces = 0;
            numberCellType14.Separator = ",";
            numberCellType14.ShowSeparator = true;
            this.shtInventorySummary.Columns.Get(17).CellType = numberCellType14;
            this.shtInventorySummary.Columns.Get(17).Label = "Order";
            this.shtInventorySummary.Columns.Get(17).Width = 120F;
            this.shtInventorySummary.Columns.Get(18).AllowAutoFilter = true;
            this.shtInventorySummary.Columns.Get(18).AllowAutoSort = true;
            numberCellType15.DecimalPlaces = 0;
            numberCellType15.Separator = ",";
            numberCellType15.ShowSeparator = true;
            this.shtInventorySummary.Columns.Get(18).CellType = numberCellType15;
            this.shtInventorySummary.Columns.Get(18).Label = "Remain ";
            this.shtInventorySummary.Columns.Get(18).Width = 120F;
            this.shtInventorySummary.Columns.Get(19).AllowAutoFilter = true;
            this.shtInventorySummary.Columns.Get(19).AllowAutoSort = true;
            numberCellType16.DecimalPlaces = 0;
            numberCellType16.Separator = ",";
            numberCellType16.ShowSeparator = true;
            this.shtInventorySummary.Columns.Get(19).CellType = numberCellType16;
            this.shtInventorySummary.Columns.Get(19).Label = "Delivery";
            this.shtInventorySummary.Columns.Get(19).Width = 120F;
            this.shtInventorySummary.DataAutoCellTypes = false;
            this.shtInventorySummary.DataAutoHeadings = false;
            this.shtInventorySummary.DataAutoSizeColumns = false;
            this.shtInventorySummary.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.shtInventorySummary.RowHeader.Columns.Default.Resizable = true;
            this.shtInventorySummary.RowHeader.Columns.Get(0).AllowAutoSort = true;
            this.shtInventorySummary.RowHeader.Columns.Get(0).Width = 55F;
            this.shtInventorySummary.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.shtInventorySummary.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.shtInventorySummary.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // SUM010_SalesSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(992, 666);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SUM010_SalesSummary";
            this.Text = "Sales Summary";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.INV010_InventoryOnHandInquiry_Load);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpInventorySummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtInventorySummary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EVOFramework.Windows.Forms.EVOTextBox txtFilter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private EVOFramework.Windows.Forms.EVOLabel lblHeader;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel1;
        private EVOFramework.Windows.Forms.EVOLabel lblInventoryPeriod;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtDateEnd;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtDateBegin;
        private FarPoint.Win.Spread.FpSpread fpInventorySummary;
        private FarPoint.Win.Spread.SheetView shtInventorySummary;
    }
}
