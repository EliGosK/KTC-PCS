namespace Rubik.Forms.FindDialog
{
    partial class ItemFindDialog
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtSearch = new EVOFramework.Windows.Forms.EVOTextBox();
            this.pnlContainer = new EVOFramework.Windows.Forms.EVOPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.fpItemView = new FarPoint.Win.Spread.FpSpread();
            this.shtItemView = new FarPoint.Win.Spread.SheetView();
            this.evoLabel1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoPanel1 = new EVOFramework.Windows.Forms.EVOPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlContainer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpItemView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtItemView)).BeginInit();
            this.evoPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Rubik.Forms.Properties.Resources.FIND_TEXT;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 47;
            this.pictureBox1.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.AppearanceName = "";
            this.txtSearch.AppearanceReadOnlyName = "";
            this.txtSearch.ControlID = "";
            this.txtSearch.DisableRestrictChar = true;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtSearch.HelpButton = null;
            this.txtSearch.Location = new System.Drawing.Point(34, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PathString = null;
            this.txtSearch.PathValue = "";
            this.txtSearch.Size = new System.Drawing.Size(752, 26);
            this.txtSearch.TabIndex = 45;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // pnlContainer
            // 
            this.pnlContainer.AppearanceName = "FormBGColor";
            this.pnlContainer.Controls.Add(this.tableLayoutPanel1);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(792, 466);
            this.pnlContainer.TabIndex = 49;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.fpItemView, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.evoLabel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.evoPanel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(792, 466);
            this.tableLayoutPanel1.TabIndex = 48;
            // 
            // fpItemView
            // 
            this.fpItemView.About = "2.5.2015.2005";
            this.fpItemView.AccessibleDescription = "fpItemView, Sheet1, Row 0, Column 0, ";
            this.fpItemView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fpItemView.BackColor = System.Drawing.SystemColors.Control;
            this.fpItemView.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.fpItemView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpItemView.Location = new System.Drawing.Point(3, 59);
            this.fpItemView.Name = "fpItemView";
            this.fpItemView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpItemView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpItemView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtItemView});
            this.fpItemView.Size = new System.Drawing.Size(786, 404);
            this.fpItemView.TabIndex = 4;
            this.fpItemView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpItemView.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpItemView_CellDoubleClick);
            this.fpItemView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpItemView_KeyDown);
            // 
            // shtItemView
            // 
            this.shtItemView.Reset();
            this.shtItemView.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtItemView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtItemView.ColumnCount = 4;
            this.shtItemView.RowCount = 0;
            this.shtItemView.AutoCalculation = false;
            this.shtItemView.AutoGenerateColumns = false;
            this.shtItemView.ColumnHeader.Cells.Get(0, 0).Value = "M/N";
            this.shtItemView.ColumnHeader.Cells.Get(0, 1).Value = "Part No.";
            this.shtItemView.ColumnHeader.Cells.Get(0, 2).Value = "Customer";
            this.shtItemView.ColumnHeader.Cells.Get(0, 3).Value = "Customer Name";
            this.shtItemView.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtItemView.Columns.Get(0).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(0).AllowAutoSort = true;
            this.shtItemView.Columns.Get(0).Label = "M/N";
            this.shtItemView.Columns.Get(0).Tag = "ITEM_CD";
            this.shtItemView.Columns.Get(0).Width = 100F;
            this.shtItemView.Columns.Get(1).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(1).AllowAutoSort = true;
            this.shtItemView.Columns.Get(1).Label = "Part No.";
            this.shtItemView.Columns.Get(1).Tag = "SHORT_NAME";
            this.shtItemView.Columns.Get(1).Width = 150F;
            this.shtItemView.Columns.Get(2).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(2).AllowAutoSort = true;
            this.shtItemView.Columns.Get(2).Label = "Customer";
            this.shtItemView.Columns.Get(2).Tag = "CUSTOMER_CD";
            this.shtItemView.Columns.Get(2).Width = 200F;
            this.shtItemView.Columns.Get(3).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(3).AllowAutoSort = true;
            this.shtItemView.Columns.Get(3).Label = "Customer Name";
            this.shtItemView.Columns.Get(3).Tag = "Customer Name";
            this.shtItemView.Columns.Get(3).Width = 128F;
            this.shtItemView.DataAutoCellTypes = false;
            this.shtItemView.DataAutoHeadings = false;
            this.shtItemView.DataAutoSizeColumns = false;
            this.shtItemView.RowHeader.Columns.Default.Resizable = true;
            this.shtItemView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpItemView.SetActiveViewport(0, 1, 0);
            // 
            // evoLabel1
            // 
            this.evoLabel1.AppearanceName = "Title";
            this.evoLabel1.AutoSize = true;
            this.evoLabel1.ControlID = "";
            this.evoLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.evoLabel1.Location = new System.Drawing.Point(3, 0);
            this.evoLabel1.Name = "evoLabel1";
            this.evoLabel1.Padding = new System.Windows.Forms.Padding(3);
            this.evoLabel1.PathString = null;
            this.evoLabel1.PathValue = "Part List";
            this.evoLabel1.Size = new System.Drawing.Size(786, 19);
            this.evoLabel1.TabIndex = 0;
            this.evoLabel1.Text = "Part List";
            // 
            // evoPanel1
            // 
            this.evoPanel1.AppearanceName = "";
            this.evoPanel1.AutoSize = true;
            this.evoPanel1.Controls.Add(this.pictureBox1);
            this.evoPanel1.Controls.Add(this.txtSearch);
            this.evoPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.evoPanel1.Location = new System.Drawing.Point(3, 22);
            this.evoPanel1.Name = "evoPanel1";
            this.evoPanel1.Size = new System.Drawing.Size(786, 31);
            this.evoPanel1.TabIndex = 1;
            // 
            // ItemFindDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(792, 466);
            this.Controls.Add(this.pnlContainer);
            this.MinimumSize = new System.Drawing.Size(402, 228);
            this.Name = "ItemFindDialog";
            this.Text = "Part Find Dialog";
            this.Load += new System.EventHandler(this.ItemFindDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlContainer.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpItemView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtItemView)).EndInit();
            this.evoPanel1.ResumeLayout(false);
            this.evoPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private EVOFramework.Windows.Forms.EVOTextBox txtSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel1;
        private EVOFramework.Windows.Forms.EVOPanel evoPanel1;
        private FarPoint.Win.Spread.FpSpread fpItemView;
        private FarPoint.Win.Spread.SheetView shtItemView;
        public EVOFramework.Windows.Forms.EVOPanel pnlContainer;
    }
}
