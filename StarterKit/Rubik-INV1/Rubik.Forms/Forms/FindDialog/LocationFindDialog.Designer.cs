namespace Rubik.Forms.FindDialog
{
    partial class LocationFindDialog
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
            this.evoLabel1.PathValue = "Location List";
            this.evoLabel1.Size = new System.Drawing.Size(663, 19);
            this.evoLabel1.TabIndex = 0;
            this.evoLabel1.Text = "Location List";
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
            this.shtView.ColumnCount = 28;
            this.shtView.RowCount = 0;
            this.shtView.AutoCalculation = false;
            this.shtView.AutoGenerateColumns = false;
            this.shtView.ColumnHeader.Cells.Get(0, 0).Value = "Create By";
            this.shtView.ColumnHeader.Cells.Get(0, 1).Value = "Create Date";
            this.shtView.ColumnHeader.Cells.Get(0, 2).Value = "Create Machine";
            this.shtView.ColumnHeader.Cells.Get(0, 3).Value = "Update By";
            this.shtView.ColumnHeader.Cells.Get(0, 4).Value = "Update Date";
            this.shtView.ColumnHeader.Cells.Get(0, 5).Value = "Update Machine";
            this.shtView.ColumnHeader.Cells.Get(0, 6).Value = "Location Code";
            this.shtView.ColumnHeader.Cells.Get(0, 7).Value = "Location Desc";
            this.shtView.ColumnHeader.Cells.Get(0, 8).Value = "Location Class";
            this.shtView.ColumnHeader.Cells.Get(0, 9).Value = "Address1";
            this.shtView.ColumnHeader.Cells.Get(0, 10).Value = "Tel1";
            this.shtView.ColumnHeader.Cells.Get(0, 11).Value = "Fax1";
            this.shtView.ColumnHeader.Cells.Get(0, 12).Value = "Email1";
            this.shtView.ColumnHeader.Cells.Get(0, 13).Value = "Contact Person1";
            this.shtView.ColumnHeader.Cells.Get(0, 14).Value = "Remark1";
            this.shtView.ColumnHeader.Cells.Get(0, 15).Value = "Address2";
            this.shtView.ColumnHeader.Cells.Get(0, 16).Value = "Tel2";
            this.shtView.ColumnHeader.Cells.Get(0, 17).Value = "Fax2";
            this.shtView.ColumnHeader.Cells.Get(0, 18).Value = "Email2";
            this.shtView.ColumnHeader.Cells.Get(0, 19).Value = "Contact Person2";
            this.shtView.ColumnHeader.Cells.Get(0, 20).Value = "Remark2";
            this.shtView.ColumnHeader.Cells.Get(0, 21).Value = "Address3";
            this.shtView.ColumnHeader.Cells.Get(0, 22).Value = "Tel3";
            this.shtView.ColumnHeader.Cells.Get(0, 23).Value = "Fax3";
            this.shtView.ColumnHeader.Cells.Get(0, 24).Value = "Email3";
            this.shtView.ColumnHeader.Cells.Get(0, 25).Value = "Contact Person3";
            this.shtView.ColumnHeader.Cells.Get(0, 26).Value = "Remark3";
            this.shtView.ColumnHeader.Cells.Get(0, 27).Value = "Allow Negative";
            this.shtView.ColumnHeader.Rows.Get(0).Height = 30F;
            this.shtView.Columns.Get(0).Label = "Create By";
            this.shtView.Columns.Get(0).Visible = false;
            this.shtView.Columns.Get(1).Label = "Create Date";
            this.shtView.Columns.Get(1).Visible = false;
            this.shtView.Columns.Get(2).Label = "Create Machine";
            this.shtView.Columns.Get(2).Visible = false;
            this.shtView.Columns.Get(3).Label = "Update By";
            this.shtView.Columns.Get(3).Visible = false;
            this.shtView.Columns.Get(4).Label = "Update Date";
            this.shtView.Columns.Get(4).Visible = false;
            this.shtView.Columns.Get(5).Label = "Update Machine";
            this.shtView.Columns.Get(5).Visible = false;
            this.shtView.Columns.Get(6).AllowAutoFilter = true;
            this.shtView.Columns.Get(6).AllowAutoSort = true;
            this.shtView.Columns.Get(6).Label = "Location Code";
            this.shtView.Columns.Get(6).Locked = true;
            this.shtView.Columns.Get(6).Tag = "Location Code";
            this.shtView.Columns.Get(6).Width = 133F;
            this.shtView.Columns.Get(7).Label = "Location Desc";
            this.shtView.Columns.Get(7).Width = 224F;
            this.shtView.Columns.Get(8).Label = "Location Class";
            this.shtView.Columns.Get(8).Width = 130F;
            this.shtView.Columns.Get(9).Label = "Address1";
            this.shtView.Columns.Get(9).Visible = false;
            this.shtView.Columns.Get(10).Label = "Tel1";
            this.shtView.Columns.Get(10).Visible = false;
            this.shtView.Columns.Get(11).Label = "Fax1";
            this.shtView.Columns.Get(11).Visible = false;
            this.shtView.Columns.Get(12).Label = "Email1";
            this.shtView.Columns.Get(12).Visible = false;
            this.shtView.Columns.Get(13).Label = "Contact Person1";
            this.shtView.Columns.Get(13).Visible = false;
            this.shtView.Columns.Get(14).Label = "Remark1";
            this.shtView.Columns.Get(14).Visible = false;
            this.shtView.Columns.Get(15).Label = "Address2";
            this.shtView.Columns.Get(15).Visible = false;
            this.shtView.Columns.Get(16).Label = "Tel2";
            this.shtView.Columns.Get(16).Visible = false;
            this.shtView.Columns.Get(17).Label = "Fax2";
            this.shtView.Columns.Get(17).Visible = false;
            this.shtView.Columns.Get(18).Label = "Email2";
            this.shtView.Columns.Get(18).Visible = false;
            this.shtView.Columns.Get(19).Label = "Contact Person2";
            this.shtView.Columns.Get(19).Visible = false;
            this.shtView.Columns.Get(20).Label = "Remark2";
            this.shtView.Columns.Get(20).Visible = false;
            this.shtView.Columns.Get(21).Label = "Address3";
            this.shtView.Columns.Get(21).Visible = false;
            this.shtView.Columns.Get(21).Width = 62F;
            this.shtView.Columns.Get(22).Label = "Tel3";
            this.shtView.Columns.Get(22).Visible = false;
            this.shtView.Columns.Get(23).Label = "Fax3";
            this.shtView.Columns.Get(23).Visible = false;
            this.shtView.Columns.Get(24).Label = "Email3";
            this.shtView.Columns.Get(24).Visible = false;
            this.shtView.Columns.Get(25).Label = "Contact Person3";
            this.shtView.Columns.Get(25).Visible = false;
            this.shtView.Columns.Get(26).Label = "Remark3";
            this.shtView.Columns.Get(26).Visible = false;
            this.shtView.Columns.Get(27).Label = "Allow Negative";
            this.shtView.Columns.Get(27).Visible = false;
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
            // LocationFindDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(669, 454);
            this.Controls.Add(this.pnlContainer);
            this.Name = "LocationFindDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Location Find Dialog";
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
