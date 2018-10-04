namespace Rubik.MRP
{
    partial class ORD010_DemandOrderList
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
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType2 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ORD010_DemandOrderList));
            this.txtSearch = new EVOFramework.Windows.Forms.EVOTextBox();
            this.fpView = new FarPoint.Win.Spread.FpSpread();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.shtView = new FarPoint.Win.Spread.SheetView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tlpTitle = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.dtPeriodEnd = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.dtPeriodBegin = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.evoLabel7 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).BeginInit();
            this.ctxMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.evoLabel1);
            this.pnlContainer.Controls.Add(this.dtPeriodEnd);
            this.pnlContainer.Controls.Add(this.label1);
            this.pnlContainer.Controls.Add(this.dtPeriodBegin);
            this.pnlContainer.Controls.Add(this.tlpTitle);
            this.pnlContainer.Controls.Add(this.evoLabel7);
            this.pnlContainer.Controls.Add(this.pictureBox1);
            this.pnlContainer.Controls.Add(this.fpView);
            this.pnlContainer.Controls.Add(this.txtSearch);
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlContainer.Size = new System.Drawing.Size(800, 434);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.AppearanceName = "";
            this.txtSearch.AppearanceReadOnlyName = "";
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.ControlID = "";
            this.txtSearch.DisableRestrictChar = true;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.HelpButton = null;
            this.txtSearch.Location = new System.Drawing.Point(47, 42);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PathString = null;
            this.txtSearch.PathValue = "";
            this.txtSearch.Size = new System.Drawing.Size(741, 26);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TabStop = false;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            // 
            // fpView
            // 
            this.fpView.About = "2.5.2015.2005";
            this.fpView.AccessibleDescription = "fpView, Sheet1";
            this.fpView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fpView.BackColor = System.Drawing.Color.AliceBlue;
            this.fpView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fpView.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpView.ContextMenuStrip = this.ctxMenu;
            this.fpView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.Location = new System.Drawing.Point(13, 74);
            this.fpView.Name = "fpView";
            this.fpView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpView.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtView});
            this.fpView.Size = new System.Drawing.Size(775, 348);
            this.fpView.TabIndex = 3;
            this.fpView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpView_CellDoubleClick);
            this.fpView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpView_KeyDown);
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEdit,
            this.mnuDelete});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(108, 48);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(107, 22);
            this.mnuEdit.Text = "Edit";
            this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(107, 22);
            this.mnuDelete.Text = "Delete";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // shtView
            // 
            this.shtView.Reset();
            this.shtView.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtView.ColumnCount = 18;
            this.shtView.RowCount = 0;
            this.shtView.AutoCalculation = false;
            this.shtView.AutoGenerateColumns = false;
            this.shtView.ColumnHeader.Cells.Get(0, 0).Value = "CREATE BY";
            this.shtView.ColumnHeader.Cells.Get(0, 1).Value = "CREATE DATE";
            this.shtView.ColumnHeader.Cells.Get(0, 2).Value = "CREATE MACHINE";
            this.shtView.ColumnHeader.Cells.Get(0, 3).Value = "UPDATE BY";
            this.shtView.ColumnHeader.Cells.Get(0, 4).Value = "UPDATE DATE";
            this.shtView.ColumnHeader.Cells.Get(0, 5).Value = "UPDATE MACHINE";
            this.shtView.ColumnHeader.Cells.Get(0, 6).Value = "IS ACTIVE";
            this.shtView.ColumnHeader.Cells.Get(0, 7).Value = "REVISION";
            this.shtView.ColumnHeader.Cells.Get(0, 8).Value = "YEAR_MONTH";
            this.shtView.ColumnHeader.Cells.Get(0, 9).Value = "CUSTOMER CD";
            this.shtView.ColumnHeader.Cells.Get(0, 10).Value = "ORDER ID";
            this.shtView.ColumnHeader.Cells.Get(0, 11).Value = "DUE DATE";
            this.shtView.ColumnHeader.Cells.Get(0, 12).Value = "Part CD";
            this.shtView.ColumnHeader.Cells.Get(0, 13).Value = "Part DESC";
            this.shtView.ColumnHeader.Cells.Get(0, 14).Value = "ORDER QTY";
            this.shtView.ColumnHeader.Cells.Get(0, 15).Value = "ORDER TYPE";
            this.shtView.ColumnHeader.Cells.Get(0, 16).Value = "PRIORITY";
            this.shtView.ColumnHeader.Cells.Get(0, 17).Value = "RESERVE";
            this.shtView.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtView.Columns.Get(0).AllowAutoFilter = true;
            this.shtView.Columns.Get(0).AllowAutoSort = true;
            this.shtView.Columns.Get(0).Label = "CREATE BY";
            this.shtView.Columns.Get(0).Tag = "CREATE BY";
            this.shtView.Columns.Get(0).Width = 185F;
            this.shtView.Columns.Get(1).AllowAutoFilter = true;
            this.shtView.Columns.Get(1).AllowAutoSort = true;
            this.shtView.Columns.Get(1).Label = "CREATE DATE";
            this.shtView.Columns.Get(1).Tag = "CREATE DATE";
            this.shtView.Columns.Get(1).Width = 185F;
            this.shtView.Columns.Get(2).AllowAutoFilter = true;
            this.shtView.Columns.Get(2).AllowAutoSort = true;
            this.shtView.Columns.Get(2).Label = "CREATE MACHINE";
            this.shtView.Columns.Get(2).Tag = "CREATE MACHINE";
            this.shtView.Columns.Get(2).Width = 185F;
            this.shtView.Columns.Get(3).AllowAutoFilter = true;
            this.shtView.Columns.Get(3).AllowAutoSort = true;
            this.shtView.Columns.Get(3).Label = "UPDATE BY";
            this.shtView.Columns.Get(3).Tag = "UPDATE BY";
            this.shtView.Columns.Get(3).Width = 185F;
            this.shtView.Columns.Get(4).AllowAutoFilter = true;
            this.shtView.Columns.Get(4).AllowAutoSort = true;
            this.shtView.Columns.Get(4).Label = "UPDATE DATE";
            this.shtView.Columns.Get(4).Tag = "UPDATE DATE";
            this.shtView.Columns.Get(4).Width = 185F;
            this.shtView.Columns.Get(5).AllowAutoFilter = true;
            this.shtView.Columns.Get(5).AllowAutoSort = true;
            this.shtView.Columns.Get(5).Label = "UPDATE MACHINE";
            this.shtView.Columns.Get(5).Tag = "UPDATE MACHINE";
            this.shtView.Columns.Get(5).Width = 185F;
            this.shtView.Columns.Get(6).AllowAutoFilter = true;
            this.shtView.Columns.Get(6).AllowAutoSort = true;
            this.shtView.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.shtView.Columns.Get(6).Label = "IS ACTIVE";
            this.shtView.Columns.Get(6).Tag = "IS ACTIVE";
            this.shtView.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.shtView.Columns.Get(6).Width = 185F;
            this.shtView.Columns.Get(7).AllowAutoFilter = true;
            this.shtView.Columns.Get(7).AllowAutoSort = true;
            this.shtView.Columns.Get(7).Label = "REVISION";
            this.shtView.Columns.Get(7).Locked = false;
            this.shtView.Columns.Get(7).Tag = "REVISION";
            this.shtView.Columns.Get(7).Width = 185F;
            this.shtView.Columns.Get(8).AllowAutoFilter = true;
            this.shtView.Columns.Get(8).AllowAutoSort = true;
            this.shtView.Columns.Get(8).Label = "YEAR_MONTH";
            this.shtView.Columns.Get(8).Tag = "YEAR_MONTH";
            this.shtView.Columns.Get(8).Width = 185F;
            this.shtView.Columns.Get(9).AllowAutoFilter = true;
            this.shtView.Columns.Get(9).AllowAutoSort = true;
            this.shtView.Columns.Get(9).Label = "CUSTOMER CD";
            this.shtView.Columns.Get(9).Tag = "CUSTOMER CD";
            this.shtView.Columns.Get(9).Width = 200F;
            this.shtView.Columns.Get(10).AllowAutoFilter = true;
            this.shtView.Columns.Get(10).AllowAutoSort = true;
            this.shtView.Columns.Get(10).Label = "ORDER ID";
            this.shtView.Columns.Get(10).Tag = "ORDER ID";
            this.shtView.Columns.Get(10).Width = 185F;
            this.shtView.Columns.Get(11).AllowAutoFilter = true;
            this.shtView.Columns.Get(11).AllowAutoSort = true;
            dateTimeCellType2.Calendar = ((System.Globalization.Calendar)(resources.GetObject("dateTimeCellType2.Calendar")));
            dateTimeCellType2.DateDefault = new System.DateTime(2011, 6, 29, 14, 24, 18, 0);
            dateTimeCellType2.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
            dateTimeCellType2.TimeDefault = new System.DateTime(2011, 6, 29, 14, 24, 18, 0);
            dateTimeCellType2.TwoDigitYearMax = 2029;
            dateTimeCellType2.UserDefinedFormat = "dd/MM/yyyy";
            this.shtView.Columns.Get(11).CellType = dateTimeCellType2;
            this.shtView.Columns.Get(11).Label = "DUE DATE";
            this.shtView.Columns.Get(11).Tag = "DUE DATE";
            this.shtView.Columns.Get(11).Width = 127F;
            this.shtView.Columns.Get(12).AllowAutoFilter = true;
            this.shtView.Columns.Get(12).AllowAutoSort = true;
            this.shtView.Columns.Get(12).Label = "Part CD";
            this.shtView.Columns.Get(12).Tag = "Part CD";
            this.shtView.Columns.Get(12).Width = 244F;
            this.shtView.Columns.Get(13).AllowAutoFilter = true;
            this.shtView.Columns.Get(13).AllowAutoSort = true;
            this.shtView.Columns.Get(13).Label = "Part DESC";
            this.shtView.Columns.Get(13).Tag = "Part DESC";
            this.shtView.Columns.Get(13).Width = 218F;
            this.shtView.Columns.Get(14).AllowAutoFilter = true;
            this.shtView.Columns.Get(14).AllowAutoSort = true;
            this.shtView.Columns.Get(14).Label = "ORDER QTY";
            this.shtView.Columns.Get(14).Tag = "ORDER QTY";
            this.shtView.Columns.Get(14).Width = 150F;
            this.shtView.Columns.Get(15).AllowAutoFilter = true;
            this.shtView.Columns.Get(15).AllowAutoSort = true;
            this.shtView.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.shtView.Columns.Get(15).Label = "ORDER TYPE";
            this.shtView.Columns.Get(15).Tag = "ORDER TYPE";
            this.shtView.Columns.Get(15).Width = 185F;
            this.shtView.Columns.Get(16).AllowAutoFilter = true;
            this.shtView.Columns.Get(16).AllowAutoSort = true;
            this.shtView.Columns.Get(16).Label = "PRIORITY";
            this.shtView.Columns.Get(16).Tag = "PRIORITY";
            this.shtView.Columns.Get(16).Width = 185F;
            this.shtView.Columns.Get(17).AllowAutoFilter = true;
            this.shtView.Columns.Get(17).AllowAutoSort = true;
            this.shtView.Columns.Get(17).Label = "RESERVE";
            this.shtView.Columns.Get(17).Tag = "RESERVE";
            this.shtView.Columns.Get(17).Width = 185F;
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
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Rubik.Forms.Properties.Resources.FIND_TEXT;
            this.pictureBox1.Location = new System.Drawing.Point(13, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // tlpTitle
            // 
            this.tlpTitle.AutoSize = true;
            this.tlpTitle.ColumnCount = 6;
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tlpTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpTitle.Location = new System.Drawing.Point(0, 0);
            this.tlpTitle.Name = "tlpTitle";
            this.tlpTitle.RowCount = 1;
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpTitle.Size = new System.Drawing.Size(800, 0);
            this.tlpTitle.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AppearanceName = "Title";
            this.label1.AutoSize = true;
            this.label1.ControlID = "";
            this.label1.Font = new System.Drawing.Font("Tahoma", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.PathString = null;
            this.label1.PathValue = "Demand Order List";
            this.label1.Size = new System.Drawing.Size(317, 39);
            this.label1.TabIndex = 35;
            this.label1.Text = "Demand Order List";
            // 
            // dtPeriodEnd
            // 
            this.dtPeriodEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtPeriodEnd.AppearanceName = "";
            this.dtPeriodEnd.AppearanceReadOnlyName = "";
            this.dtPeriodEnd.BackColor = System.Drawing.Color.Transparent;
            this.dtPeriodEnd.ControlID = "";
            this.dtPeriodEnd.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.dtPeriodEnd.Format = "dd/MM/yyyy";
            this.dtPeriodEnd.Location = new System.Drawing.Point(634, 8);
            this.dtPeriodEnd.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtPeriodEnd.Name = "dtPeriodEnd";
            this.dtPeriodEnd.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtPeriodEnd.NZValue")));
            this.dtPeriodEnd.PathString = null;
            this.dtPeriodEnd.PathValue = ((object)(resources.GetObject("dtPeriodEnd.PathValue")));
            this.dtPeriodEnd.ReadOnly = false;
            this.dtPeriodEnd.ShowButton = true;
            this.dtPeriodEnd.Size = new System.Drawing.Size(154, 27);
            this.dtPeriodEnd.TabIndex = 36;
            this.dtPeriodEnd.Value = null;
            // 
            // dtPeriodBegin
            // 
            this.dtPeriodBegin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtPeriodBegin.AppearanceName = "";
            this.dtPeriodBegin.AppearanceReadOnlyName = "";
            this.dtPeriodBegin.BackColor = System.Drawing.Color.Transparent;
            this.dtPeriodBegin.ControlID = "";
            this.dtPeriodBegin.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.dtPeriodBegin.Format = "dd/MM/yyyy";
            this.dtPeriodBegin.Location = new System.Drawing.Point(453, 8);
            this.dtPeriodBegin.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtPeriodBegin.Name = "dtPeriodBegin";
            this.dtPeriodBegin.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtPeriodBegin.NZValue")));
            this.dtPeriodBegin.PathString = null;
            this.dtPeriodBegin.PathValue = ((object)(resources.GetObject("dtPeriodBegin.PathValue")));
            this.dtPeriodBegin.ReadOnly = false;
            this.dtPeriodBegin.ShowButton = true;
            this.dtPeriodBegin.Size = new System.Drawing.Size(154, 27);
            this.dtPeriodBegin.TabIndex = 37;
            this.dtPeriodBegin.Value = null;
            // 
            // evoLabel7
            // 
            this.evoLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.evoLabel7.AppearanceName = "";
            this.evoLabel7.AutoSize = true;
            this.evoLabel7.ControlID = "";
            this.evoLabel7.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel7.Location = new System.Drawing.Point(359, 12);
            this.evoLabel7.Name = "evoLabel7";
            this.evoLabel7.PathString = null;
            this.evoLabel7.PathValue = "Period Date";
            this.evoLabel7.Size = new System.Drawing.Size(91, 19);
            this.evoLabel7.TabIndex = 38;
            this.evoLabel7.Text = "Period Date";
            // 
            // evoLabel1
            // 
            this.evoLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.evoLabel1.AppearanceName = "";
            this.evoLabel1.AutoSize = true;
            this.evoLabel1.ControlID = "";
            this.evoLabel1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel1.Location = new System.Drawing.Point(613, 12);
            this.evoLabel1.Name = "evoLabel1";
            this.evoLabel1.PathString = null;
            this.evoLabel1.PathValue = "-";
            this.evoLabel1.Size = new System.Drawing.Size(15, 19);
            this.evoLabel1.TabIndex = 39;
            this.evoLabel1.Text = "-";
            // 
            // ORD010_DemandOrderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 459);
            this.ExportObject = this.fpView;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "ORD010_DemandOrderList";
            this.Text = "MRP020 - MRP List";
            this.Load += new System.EventHandler(this.ORD010_DemandOrderList_Load);
            this.Shown += new System.EventHandler(this.MRP020_Shown);
            this.Controls.SetChildIndex(this.pnlContainer, 0);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).EndInit();
            this.ctxMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EVOFramework.Windows.Forms.EVOTextBox txtSearch;
        private FarPoint.Win.Spread.FpSpread fpView;
        private FarPoint.Win.Spread.SheetView shtView;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tlpTitle;
        private EVOFramework.Windows.Forms.EVOLabel label1;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtPeriodEnd;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtPeriodBegin;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel7;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel1;
    }
}