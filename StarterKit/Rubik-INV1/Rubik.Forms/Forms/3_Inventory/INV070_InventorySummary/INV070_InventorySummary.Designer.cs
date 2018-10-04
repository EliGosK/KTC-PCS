namespace Rubik.Inventory
{
    partial class INV070_InventorySummary
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
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType7 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType8 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType9 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType10 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType11 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType12 = new FarPoint.Win.Spread.CellType.TextCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INV070_InventorySummary));
            this.fpInventorySummary = new FarPoint.Win.Spread.FpSpread();
            this.shtInventorySummary = new FarPoint.Win.Spread.SheetView();
            this.txtFilter = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblHeader = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblInventoryPeriod = new EVOFramework.Windows.Forms.EVOLabel();
            this.dtMonth = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpInventorySummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtInventorySummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.BackColor = System.Drawing.Color.AliceBlue;
            this.pnlContainer.Controls.Add(this.lblHeader);
            this.pnlContainer.Controls.Add(this.fpInventorySummary);
            this.pnlContainer.Controls.Add(this.txtFilter);
            this.pnlContainer.Controls.Add(this.pictureBox1);
            this.pnlContainer.Controls.Add(this.lblInventoryPeriod);
            this.pnlContainer.Controls.Add(this.dtMonth);
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlContainer.Size = new System.Drawing.Size(992, 608);
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
            this.fpInventorySummary.Location = new System.Drawing.Point(12, 53);
            this.fpInventorySummary.Name = "fpInventorySummary";
            this.fpInventorySummary.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpInventorySummary.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.AsNeeded;
            this.fpInventorySummary.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpInventorySummary.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtInventorySummary});
            this.fpInventorySummary.Size = new System.Drawing.Size(971, 549);
            this.fpInventorySummary.TabIndex = 0;
            this.fpInventorySummary.TabStop = false;
            this.fpInventorySummary.TextTipDelay = 1000;
            this.fpInventorySummary.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpInventorySummary.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpView_CellDoubleClick);
            this.fpInventorySummary.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpInventorySummary_KeyDown);
            // 
            // shtInventorySummary
            // 
            this.shtInventorySummary.Reset();
            this.shtInventorySummary.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtInventorySummary.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtInventorySummary.ColumnCount = 17;
            this.shtInventorySummary.RowCount = 2;
            this.shtInventorySummary.AutoGenerateColumns = false;
            this.shtInventorySummary.ColumnHeader.Cells.Get(0, 0).Value = "Item Level";
            this.shtInventorySummary.ColumnHeader.Cells.Get(0, 1).Value = "M/N";
            this.shtInventorySummary.ColumnHeader.Cells.Get(0, 2).Value = "Part No";
            this.shtInventorySummary.ColumnHeader.Cells.Get(0, 3).Value = "Customer Name";
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
            this.shtInventorySummary.ColumnHeader.Cells.Get(0, 16).Value = "FG";
            this.shtInventorySummary.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtInventorySummary.Columns.Get(0).AllowAutoFilter = true;
            this.shtInventorySummary.Columns.Get(0).AllowAutoSort = true;
            this.shtInventorySummary.Columns.Get(0).Label = "Item Level";
            this.shtInventorySummary.Columns.Get(0).Tag = "Item Level";
            this.shtInventorySummary.Columns.Get(0).Width = 87F;
            this.shtInventorySummary.Columns.Get(1).AllowAutoFilter = true;
            this.shtInventorySummary.Columns.Get(1).AllowAutoSort = true;
            this.shtInventorySummary.Columns.Get(1).Label = "M/N";
            this.shtInventorySummary.Columns.Get(1).Tag = "M/N";
            this.shtInventorySummary.Columns.Get(1).Width = 90F;
            this.shtInventorySummary.Columns.Get(2).AllowAutoFilter = true;
            this.shtInventorySummary.Columns.Get(2).AllowAutoSort = true;
            this.shtInventorySummary.Columns.Get(2).CellType = textCellType1;
            this.shtInventorySummary.Columns.Get(2).Label = "Part No";
            this.shtInventorySummary.Columns.Get(2).Tag = "Part Code";
            this.shtInventorySummary.Columns.Get(2).Width = 150F;
            this.shtInventorySummary.Columns.Get(3).AllowAutoFilter = true;
            this.shtInventorySummary.Columns.Get(3).AllowAutoSort = true;
            this.shtInventorySummary.Columns.Get(3).CellType = textCellType2;
            this.shtInventorySummary.Columns.Get(3).Label = "Customer Name";
            this.shtInventorySummary.Columns.Get(3).Tag = "Customer Name";
            this.shtInventorySummary.Columns.Get(3).Width = 150F;
            this.shtInventorySummary.Columns.Get(4).AllowAutoFilter = true;
            this.shtInventorySummary.Columns.Get(4).AllowAutoSort = true;
            this.shtInventorySummary.Columns.Get(4).CellType = textCellType3;
            this.shtInventorySummary.Columns.Get(4).Label = "Header";
            this.shtInventorySummary.Columns.Get(4).Tag = "Header";
            this.shtInventorySummary.Columns.Get(4).Width = 110F;
            this.shtInventorySummary.Columns.Get(5).AllowAutoFilter = true;
            this.shtInventorySummary.Columns.Get(5).AllowAutoSort = true;
            this.shtInventorySummary.Columns.Get(5).CellType = textCellType4;
            this.shtInventorySummary.Columns.Get(5).Label = "Rolling";
            this.shtInventorySummary.Columns.Get(5).Tag = "Rolling";
            this.shtInventorySummary.Columns.Get(5).Width = 110F;
            this.shtInventorySummary.Columns.Get(6).AllowAutoFilter = true;
            this.shtInventorySummary.Columns.Get(6).AllowAutoSort = true;
            this.shtInventorySummary.Columns.Get(6).CellType = textCellType5;
            this.shtInventorySummary.Columns.Get(6).Label = "Cutting (KTC)";
            this.shtInventorySummary.Columns.Get(6).Tag = "Cutting";
            this.shtInventorySummary.Columns.Get(6).Width = 110F;
            this.shtInventorySummary.Columns.Get(7).AllowAutoFilter = true;
            this.shtInventorySummary.Columns.Get(7).AllowAutoSort = true;
            this.shtInventorySummary.Columns.Get(7).Label = "Cutting (Sub)";
            this.shtInventorySummary.Columns.Get(7).Tag = "Cutting (Sub)";
            this.shtInventorySummary.Columns.Get(7).Width = 110F;
            this.shtInventorySummary.Columns.Get(8).AllowAutoFilter = true;
            this.shtInventorySummary.Columns.Get(8).AllowAutoSort = true;
            this.shtInventorySummary.Columns.Get(8).CellType = textCellType6;
            this.shtInventorySummary.Columns.Get(8).Label = "Plating (KTC)";
            this.shtInventorySummary.Columns.Get(8).Tag = "Plating (KTC)";
            this.shtInventorySummary.Columns.Get(8).Width = 110F;
            this.shtInventorySummary.Columns.Get(9).AllowAutoFilter = true;
            this.shtInventorySummary.Columns.Get(9).AllowAutoSort = true;
            this.shtInventorySummary.Columns.Get(9).CellType = textCellType7;
            this.shtInventorySummary.Columns.Get(9).Label = "Plating (Sub)";
            this.shtInventorySummary.Columns.Get(9).Tag = "Plating (Sub)";
            this.shtInventorySummary.Columns.Get(9).Width = 110F;
            this.shtInventorySummary.Columns.Get(10).AllowAutoFilter = true;
            this.shtInventorySummary.Columns.Get(10).AllowAutoSort = true;
            this.shtInventorySummary.Columns.Get(10).CellType = textCellType8;
            this.shtInventorySummary.Columns.Get(10).Label = "Heat Treatment (Sub)";
            this.shtInventorySummary.Columns.Get(10).Tag = "Heat Treatment (Sub)";
            this.shtInventorySummary.Columns.Get(10).Width = 157F;
            this.shtInventorySummary.Columns.Get(11).AllowAutoFilter = true;
            this.shtInventorySummary.Columns.Get(11).AllowAutoSort = true;
            this.shtInventorySummary.Columns.Get(11).CellType = textCellType9;
            this.shtInventorySummary.Columns.Get(11).Label = "Others";
            this.shtInventorySummary.Columns.Get(11).Tag = "Others";
            this.shtInventorySummary.Columns.Get(11).Width = 110F;
            this.shtInventorySummary.Columns.Get(12).AllowAutoFilter = true;
            this.shtInventorySummary.Columns.Get(12).AllowAutoSort = true;
            this.shtInventorySummary.Columns.Get(12).CellType = textCellType10;
            this.shtInventorySummary.Columns.Get(12).Label = "QC";
            this.shtInventorySummary.Columns.Get(12).Tag = "QC";
            this.shtInventorySummary.Columns.Get(12).Width = 110F;
            this.shtInventorySummary.Columns.Get(13).AllowAutoFilter = true;
            this.shtInventorySummary.Columns.Get(13).AllowAutoSort = true;
            this.shtInventorySummary.Columns.Get(13).Label = "QC Hold";
            this.shtInventorySummary.Columns.Get(13).Locked = false;
            this.shtInventorySummary.Columns.Get(13).Tag = "QC Hold";
            this.shtInventorySummary.Columns.Get(13).Width = 110F;
            this.shtInventorySummary.Columns.Get(14).AllowAutoFilter = true;
            this.shtInventorySummary.Columns.Get(14).AllowAutoSort = true;
            this.shtInventorySummary.Columns.Get(14).CellType = textCellType11;
            this.shtInventorySummary.Columns.Get(14).Label = "Packing";
            this.shtInventorySummary.Columns.Get(14).Tag = "Packing";
            this.shtInventorySummary.Columns.Get(14).Width = 110F;
            this.shtInventorySummary.Columns.Get(15).AllowAutoFilter = true;
            this.shtInventorySummary.Columns.Get(15).AllowAutoSort = true;
            this.shtInventorySummary.Columns.Get(15).Label = "WIP";
            this.shtInventorySummary.Columns.Get(15).Tag = "WIP";
            this.shtInventorySummary.Columns.Get(15).Width = 110F;
            this.shtInventorySummary.Columns.Get(16).AllowAutoFilter = true;
            this.shtInventorySummary.Columns.Get(16).AllowAutoSort = true;
            this.shtInventorySummary.Columns.Get(16).CellType = textCellType12;
            this.shtInventorySummary.Columns.Get(16).Label = "FG";
            this.shtInventorySummary.Columns.Get(16).Tag = "FG";
            this.shtInventorySummary.Columns.Get(16).Width = 110F;
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
            this.fpInventorySummary.SetViewportLeftColumn(0, 0, 9);
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
            this.txtFilter.Location = new System.Drawing.Point(411, 21);
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
            this.lblHeader.PathValue = "Inventory Summary";
            this.lblHeader.Size = new System.Drawing.Size(353, 39);
            this.lblHeader.TabIndex = 35;
            this.lblHeader.Text = "Inventory Summary";
            // 
            // lblInventoryPeriod
            // 
            this.lblInventoryPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInventoryPeriod.AppearanceName = "";
            this.lblInventoryPeriod.ControlID = "";
            this.lblInventoryPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblInventoryPeriod.Location = new System.Drawing.Point(747, 23);
            this.lblInventoryPeriod.Name = "lblInventoryPeriod";
            this.lblInventoryPeriod.PathString = null;
            this.lblInventoryPeriod.PathValue = "Month";
            this.lblInventoryPeriod.Size = new System.Drawing.Size(78, 23);
            this.lblInventoryPeriod.TabIndex = 4;
            this.lblInventoryPeriod.Text = "Month";
            this.lblInventoryPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtMonth
            // 
            this.dtMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtMonth.AppearanceName = "";
            this.dtMonth.AppearanceReadOnlyName = "";
            this.dtMonth.BackColor = System.Drawing.Color.Transparent;
            this.dtMonth.ControlID = "";
            this.dtMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtMonth.Format = "MM/yyyy";
            this.dtMonth.Location = new System.Drawing.Point(841, 21);
            this.dtMonth.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtMonth.Name = "dtMonth";
            this.dtMonth.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtMonth.NZValue")));
            this.dtMonth.PathString = null;
            this.dtMonth.PathValue = ((object)(resources.GetObject("dtMonth.PathValue")));
            this.dtMonth.ReadOnly = false;
            this.dtMonth.ShowButton = true;
            this.dtMonth.Size = new System.Drawing.Size(139, 26);
            this.dtMonth.TabIndex = 7;
            this.dtMonth.Value = null;
            this.dtMonth.ValueChanged += new System.EventHandler(this.dtPeriodBegin_ValueChanged);
            this.dtMonth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtPeriodBegin_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Rubik.Forms.Properties.Resources.FIND_TEXT;
            this.pictureBox1.Location = new System.Drawing.Point(377, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // INV070_InventorySummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(992, 666);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "INV070_InventorySummary";
            this.Text = "Inventory Summary";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.INV010_InventoryOnHandInquiry_Load);
            this.Shown += new System.EventHandler(this.INV070_InventorySummary_Shown);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpInventorySummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtInventorySummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread fpInventorySummary;
        private FarPoint.Win.Spread.SheetView shtInventorySummary;
        private EVOFramework.Windows.Forms.EVOTextBox txtFilter;
        private EVOFramework.Windows.Forms.EVOLabel lblInventoryPeriod;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtMonth;
        private System.Windows.Forms.PictureBox pictureBox1;
        private EVOFramework.Windows.Forms.EVOLabel lblHeader;
    }
}
