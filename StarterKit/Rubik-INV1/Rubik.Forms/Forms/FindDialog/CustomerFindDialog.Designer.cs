namespace Rubik.Forms.FindDialog
{
    partial class CustomerFindDialog
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
            this.evoLabel1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.fpView = new FarPoint.Win.Spread.FpSpread();
            this.shtView = new FarPoint.Win.Spread.SheetView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.evoPanel1 = new EVOFramework.Windows.Forms.EVOPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtSearch = new EVOFramework.Windows.Forms.EVOTextBox();
            this.pnlContainer = new EVOFramework.Windows.Forms.EVOPanel();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.evoPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlContainer.SuspendLayout();
            this.SuspendLayout();
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
            this.evoLabel1.PathValue = "LotNo List";
            this.evoLabel1.Size = new System.Drawing.Size(663, 19);
            this.evoLabel1.TabIndex = 0;
            this.evoLabel1.Text = "LotNo List";
            // 
            // fpView
            // 
            this.fpView.About = "2.5.2015.2005";
            this.fpView.AccessibleDescription = "fpView, Sheet1";
            this.fpView.BackColor = System.Drawing.SystemColors.Control;
            this.fpView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.Location = new System.Drawing.Point(3, 59);
            this.fpView.Name = "fpView";
            this.fpView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtView});
            this.fpView.Size = new System.Drawing.Size(663, 392);
            this.fpView.TabIndex = 46;
            this.fpView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpView_CellDoubleClick);
            this.fpView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpView_KeyDown);
            this.fpView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fpView_KeyPress);
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
            this.shtView.ColumnHeader.Cells.Get(0, 0).Value = "Create By";
            this.shtView.ColumnHeader.Cells.Get(0, 1).Value = "Create Date";
            this.shtView.ColumnHeader.Cells.Get(0, 2).Value = "Create Machine";
            this.shtView.ColumnHeader.Cells.Get(0, 3).Value = "Update By";
            this.shtView.ColumnHeader.Cells.Get(0, 4).Value = "Update Date";
            this.shtView.ColumnHeader.Cells.Get(0, 5).Value = "Update Machine";
            this.shtView.ColumnHeader.Cells.Get(0, 6).Value = "Is Active";
            this.shtView.ColumnHeader.Cells.Get(0, 7).Value = "Customer Code";
            this.shtView.ColumnHeader.Cells.Get(0, 8).Value = "Customer Name";
            this.shtView.ColumnHeader.Cells.Get(0, 9).Value = "Customer Type";
            this.shtView.ColumnHeader.Cells.Get(0, 10).Value = "Address";
            this.shtView.ColumnHeader.Cells.Get(0, 11).Value = "Phone No";
            this.shtView.ColumnHeader.Cells.Get(0, 12).Value = "Fax";
            this.shtView.ColumnHeader.Cells.Get(0, 13).Value = "Remark";
            this.shtView.ColumnHeader.Cells.Get(0, 14).Value = "Delivery LT";
            this.shtView.Columns.Get(0).AllowAutoFilter = true;
            this.shtView.Columns.Get(0).AllowAutoSort = true;
            this.shtView.Columns.Get(0).Label = "Create By";
            this.shtView.Columns.Get(0).Locked = true;
            this.shtView.Columns.Get(0).ShowSortIndicator = false;
            this.shtView.Columns.Get(0).Tag = "Create By";
            this.shtView.Columns.Get(0).Width = 99F;
            this.shtView.Columns.Get(1).Label = "Create Date";
            this.shtView.Columns.Get(1).Width = 120F;
            this.shtView.Columns.Get(2).Label = "Create Machine";
            this.shtView.Columns.Get(2).Width = 121F;
            this.shtView.Columns.Get(3).Label = "Update By";
            this.shtView.Columns.Get(3).Width = 107F;
            this.shtView.Columns.Get(4).Label = "Update Date";
            this.shtView.Columns.Get(4).Width = 107F;
            this.shtView.Columns.Get(5).Label = "Update Machine";
            this.shtView.Columns.Get(5).Width = 98F;
            this.shtView.Columns.Get(6).Label = "Is Active";
            this.shtView.Columns.Get(6).Width = 72F;
            this.shtView.Columns.Get(7).Label = "Customer Code";
            this.shtView.Columns.Get(7).Width = 147F;
            this.shtView.Columns.Get(8).Label = "Customer Name";
            this.shtView.Columns.Get(8).Width = 198F;
            this.shtView.Columns.Get(9).Label = "Customer Type";
            this.shtView.Columns.Get(9).Width = 116F;
            this.shtView.Columns.Get(10).Label = "Address";
            this.shtView.Columns.Get(10).Width = 249F;
            this.shtView.Columns.Get(11).Label = "Phone No";
            this.shtView.Columns.Get(11).Width = 127F;
            this.shtView.Columns.Get(12).Label = "Fax";
            this.shtView.Columns.Get(12).Width = 111F;
            this.shtView.Columns.Get(13).Label = "Remark";
            this.shtView.Columns.Get(13).Width = 174F;
            this.shtView.Columns.Get(14).Label = "Delivery LT";
            this.shtView.Columns.Get(14).Width = 103F;
            this.shtView.DataAutoCellTypes = false;
            this.shtView.DataAutoHeadings = false;
            this.shtView.DataAutoSizeColumns = false;
            this.shtView.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.shtView.RowHeader.Columns.Default.Resizable = true;
            this.shtView.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.shtView.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpView.SetViewportLeftColumn(0, 0, 4);
            this.fpView.SetActiveViewport(0, 1, 0);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.evoLabel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.evoPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.fpView, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(669, 454);
            this.tableLayoutPanel1.TabIndex = 48;
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
            this.evoPanel1.Size = new System.Drawing.Size(663, 31);
            this.evoPanel1.TabIndex = 1;
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
            this.txtSearch.DisableRestrictChar = false;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtSearch.HelpButton = null;
            this.txtSearch.Location = new System.Drawing.Point(34, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PathString = null;
            this.txtSearch.PathValue = "";
            this.txtSearch.Size = new System.Drawing.Size(629, 26);
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
            this.pnlContainer.Size = new System.Drawing.Size(669, 454);
            this.pnlContainer.TabIndex = 50;
            // 
            // CustomerFindDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(669, 454);
            this.Controls.Add(this.pnlContainer);
            this.Name = "CustomerFindDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "LotNo Find Dialog";
            this.Load += new System.EventHandler(this.CustomerFindDialog_Load);
            this.Shown += new System.EventHandler(this.CustomerFindDialog_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.evoPanel1.ResumeLayout(false);
            this.evoPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EVOFramework.Windows.Forms.EVOLabel evoLabel1;
        private FarPoint.Win.Spread.FpSpread fpView;
        private FarPoint.Win.Spread.SheetView shtView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private EVOFramework.Windows.Forms.EVOPanel evoPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private EVOFramework.Windows.Forms.EVOTextBox txtSearch;
        private EVOFramework.Windows.Forms.EVOPanel pnlContainer;
    }
}
