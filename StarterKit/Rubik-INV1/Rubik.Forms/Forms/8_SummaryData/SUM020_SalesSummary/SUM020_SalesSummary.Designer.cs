namespace Rubik.SummaryData
{
    partial class SUM020_SalesSummary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SUM020_SalesSummary));
            this.txtFilter = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblHeader = new EVOFramework.Windows.Forms.EVOLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblInventoryPeriod = new EVOFramework.Windows.Forms.EVOLabel();
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
            this.pnlContainer.Controls.Add(this.lblInventoryPeriod);
            this.pnlContainer.Controls.Add(this.dtDateBegin);
            this.pnlContainer.Controls.Add(this.lblHeader);
            this.pnlContainer.Controls.Add(this.txtFilter);
            this.pnlContainer.Controls.Add(this.pictureBox1);
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
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
            this.txtFilter.Location = new System.Drawing.Point(-13, 21);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.PathString = null;
            this.txtFilter.PathValue = "";
            this.txtFilter.Size = new System.Drawing.Size(191, 26);
            this.txtFilter.TabIndex = 2;
            this.txtFilter.Visible = false;
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
            this.pictureBox1.Location = new System.Drawing.Point(-47, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // lblInventoryPeriod
            // 
            this.lblInventoryPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInventoryPeriod.AppearanceName = "";
            this.lblInventoryPeriod.ControlID = "";
            this.lblInventoryPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblInventoryPeriod.Location = new System.Drawing.Point(362, 24);
            this.lblInventoryPeriod.Name = "lblInventoryPeriod";
            this.lblInventoryPeriod.PathString = null;
            this.lblInventoryPeriod.PathValue = "Month/Year";
            this.lblInventoryPeriod.Size = new System.Drawing.Size(111, 23);
            this.lblInventoryPeriod.TabIndex = 44;
            this.lblInventoryPeriod.Text = "Month/Year";
            this.lblInventoryPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtDateBegin
            // 
            this.dtDateBegin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDateBegin.AppearanceName = "";
            this.dtDateBegin.AppearanceReadOnlyName = "";
            this.dtDateBegin.BackColor = System.Drawing.Color.Transparent;
            this.dtDateBegin.ControlID = "";
            this.dtDateBegin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtDateBegin.Format = "MM/yyyy";
            this.dtDateBegin.Location = new System.Drawing.Point(479, 22);
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
            this.fpInventorySummary.Size = new System.Drawing.Size(609, 232);
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
            this.shtInventorySummary.ColumnCount = 0;
            this.shtInventorySummary.RowCount = 0;
            this.shtInventorySummary.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtInventorySummary.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.shtInventorySummary.RowHeader.Columns.Default.Resizable = true;
            this.shtInventorySummary.RowHeader.Columns.Get(0).Width = 55F;
            this.shtInventorySummary.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.shtInventorySummary.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.shtInventorySummary.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpInventorySummary.SetActiveViewport(0, 1, 1);
            // 
            // SUM020_SalesSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(630, 347);
            this.Name = "SUM020_SalesSummary";
            this.Text = "SUM020 : Sales Summary";
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
        private EVOFramework.Windows.Forms.EVOLabel lblInventoryPeriod;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtDateBegin;
        private FarPoint.Win.Spread.FpSpread fpInventorySummary;
        private FarPoint.Win.Spread.SheetView shtInventorySummary;
    }
}
