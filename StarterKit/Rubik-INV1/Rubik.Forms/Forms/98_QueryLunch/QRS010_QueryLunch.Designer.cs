namespace Rubik.QueryLunch
{
    partial class QRS010_QueryLunch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QRS010_QueryLunch));
            this.txtSearch = new EVOFramework.Windows.Forms.EVOTextBox();
            this.fpView = new FarPoint.Win.Spread.FpSpread();
            this.shtView = new FarPoint.Win.Spread.SheetView();
            this.tlpTitle = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblStartCell = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtStartRow = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblTemplate = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtTemplate = new EVOFramework.Windows.Forms.EVOTextBox();
            this.txtStartColumn = new EVOFramework.Windows.Forms.EVOTextBox();
            this.fpQueryList = new FarPoint.Win.Spread.FpSpread();
            this.shtQueryList = new FarPoint.Win.Spread.SheetView();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpQueryList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtQueryList)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.fpQueryList);
            this.pnlContainer.Controls.Add(this.txtTemplate);
            this.pnlContainer.Controls.Add(this.lblTemplate);
            this.pnlContainer.Controls.Add(this.txtStartColumn);
            this.pnlContainer.Controls.Add(this.txtStartRow);
            this.pnlContainer.Controls.Add(this.lblStartCell);
            this.pnlContainer.Controls.Add(this.label1);
            this.pnlContainer.Controls.Add(this.tlpTitle);
            this.pnlContainer.Controls.Add(this.fpView);
            this.pnlContainer.Controls.Add(this.txtSearch);
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlContainer.Size = new System.Drawing.Size(800, 541);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.AppearanceName = "";
            this.txtSearch.AppearanceReadOnlyName = "";
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.ControlID = "";
            this.txtSearch.DisableRestrictChar = false;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.HelpButton = null;
            this.txtSearch.Location = new System.Drawing.Point(281, 42);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PathString = null;
            this.txtSearch.PathValue = "select * from tb_item_ms";
            this.txtSearch.Size = new System.Drawing.Size(507, 168);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TabStop = false;
            this.txtSearch.Text = "select * from tb_item_ms";
            // 
            // fpView
            // 
            this.fpView.About = "2.5.2015.2005";
            this.fpView.AccessibleDescription = "fpView, Sheet1, Row 0, Column 0, ";
            this.fpView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fpView.BackColor = System.Drawing.Color.AliceBlue;
            this.fpView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fpView.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.Location = new System.Drawing.Point(10, 216);
            this.fpView.Name = "fpView";
            this.fpView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpView.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtView});
            this.fpView.Size = new System.Drawing.Size(778, 313);
            this.fpView.TabIndex = 3;
            this.fpView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpView_KeyDown);
            // 
            // shtView
            // 
            this.shtView.Reset();
            this.shtView.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtView.ColumnCount = 0;
            this.shtView.RowCount = 0;
            this.shtView.AutoCalculation = false;
            this.shtView.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtView.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.shtView.RowHeader.Columns.Default.Resizable = true;
            this.shtView.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.shtView.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpView.SetActiveViewport(0, 1, 1);
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
            this.label1.PathValue = "Query Lunch";
            this.label1.Size = new System.Drawing.Size(217, 39);
            this.label1.TabIndex = 35;
            this.label1.Text = "Query Lunch";
            // 
            // lblStartCell
            // 
            this.lblStartCell.AppearanceName = "";
            this.lblStartCell.AutoSize = true;
            this.lblStartCell.ControlID = "";
            this.lblStartCell.Location = new System.Drawing.Point(265, 12);
            this.lblStartCell.Name = "lblStartCell";
            this.lblStartCell.PathString = null;
            this.lblStartCell.PathValue = "Start Cell";
            this.lblStartCell.Size = new System.Drawing.Size(73, 19);
            this.lblStartCell.TabIndex = 45;
            this.lblStartCell.Text = "Start Cell";
            // 
            // txtStartRow
            // 
            this.txtStartRow.AppearanceName = "";
            this.txtStartRow.AppearanceReadOnlyName = "";
            this.txtStartRow.ControlID = "";
            this.txtStartRow.DisableRestrictChar = false;
            this.txtStartRow.HelpButton = null;
            this.txtStartRow.Location = new System.Drawing.Point(344, 9);
            this.txtStartRow.Name = "txtStartRow";
            this.txtStartRow.PathString = null;
            this.txtStartRow.PathValue = "0";
            this.txtStartRow.Size = new System.Drawing.Size(34, 27);
            this.txtStartRow.TabIndex = 46;
            this.txtStartRow.Text = "0";
            // 
            // lblTemplate
            // 
            this.lblTemplate.AppearanceName = "";
            this.lblTemplate.AutoSize = true;
            this.lblTemplate.ControlID = "";
            this.lblTemplate.Location = new System.Drawing.Point(453, 12);
            this.lblTemplate.Name = "lblTemplate";
            this.lblTemplate.PathString = null;
            this.lblTemplate.PathValue = "Template";
            this.lblTemplate.Size = new System.Drawing.Size(75, 19);
            this.lblTemplate.TabIndex = 45;
            this.lblTemplate.Text = "Template";
            // 
            // txtTemplate
            // 
            this.txtTemplate.AppearanceName = "";
            this.txtTemplate.AppearanceReadOnlyName = "";
            this.txtTemplate.ControlID = "";
            this.txtTemplate.DisableRestrictChar = false;
            this.txtTemplate.HelpButton = null;
            this.txtTemplate.Location = new System.Drawing.Point(532, 9);
            this.txtTemplate.Name = "txtTemplate";
            this.txtTemplate.PathString = null;
            this.txtTemplate.PathValue = "";
            this.txtTemplate.Size = new System.Drawing.Size(256, 27);
            this.txtTemplate.TabIndex = 46;
            // 
            // txtStartColumn
            // 
            this.txtStartColumn.AppearanceName = "";
            this.txtStartColumn.AppearanceReadOnlyName = "";
            this.txtStartColumn.ControlID = "";
            this.txtStartColumn.DisableRestrictChar = false;
            this.txtStartColumn.HelpButton = null;
            this.txtStartColumn.Location = new System.Drawing.Point(384, 9);
            this.txtStartColumn.Name = "txtStartColumn";
            this.txtStartColumn.PathString = null;
            this.txtStartColumn.PathValue = "0";
            this.txtStartColumn.Size = new System.Drawing.Size(34, 27);
            this.txtStartColumn.TabIndex = 46;
            this.txtStartColumn.Text = "0";
            // 
            // fpQueryList
            // 
            this.fpQueryList.About = "2.5.2015.2005";
            this.fpQueryList.AccessibleDescription = "fpQueryList, Sheet1, Row 0, Column 0, ";
            this.fpQueryList.BackColor = System.Drawing.Color.AliceBlue;
            this.fpQueryList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fpQueryList.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpQueryList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpQueryList.Location = new System.Drawing.Point(10, 42);
            this.fpQueryList.Name = "fpQueryList";
            this.fpQueryList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpQueryList.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpQueryList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpQueryList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtQueryList});
            this.fpQueryList.Size = new System.Drawing.Size(265, 168);
            this.fpQueryList.TabIndex = 47;
            this.fpQueryList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpQueryList.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.fpQueryList_SelectionChanged);
            this.fpQueryList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpQueryList_KeyDown);
            // 
            // shtQueryList
            // 
            this.shtQueryList.Reset();
            this.shtQueryList.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtQueryList.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtQueryList.ColumnCount = 2;
            this.shtQueryList.RowCount = 3;
            this.shtQueryList.AutoCalculation = false;
            this.shtQueryList.AutoGenerateColumns = false;
            this.shtQueryList.ColumnHeader.Cells.Get(0, 0).Value = "ID";
            this.shtQueryList.ColumnHeader.Cells.Get(0, 1).Value = "Name";
            this.shtQueryList.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtQueryList.Columns.Get(0).Label = "ID";
            this.shtQueryList.Columns.Get(0).Width = 50F;
            this.shtQueryList.Columns.Get(1).Label = "Name";
            this.shtQueryList.Columns.Get(1).Width = 150F;
            this.shtQueryList.DataAutoSizeColumns = false;
            this.shtQueryList.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.shtQueryList.RowHeader.Columns.Default.Resizable = true;
            this.shtQueryList.RowHeader.Columns.Get(0).Width = 36F;
            this.shtQueryList.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.shtQueryList.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.shtQueryList.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // QRS010_QueryLunch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 566);
            this.ExportObject = this.fpView;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "QRS010_QueryLunch";
            this.Text = "QRS010 - Query Lunch";
            this.Load += new System.EventHandler(this.QRS010_QueryLunch_Load);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpQueryList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtQueryList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EVOFramework.Windows.Forms.EVOTextBox txtSearch;
        private FarPoint.Win.Spread.FpSpread fpView;
        private FarPoint.Win.Spread.SheetView shtView;
        private System.Windows.Forms.TableLayoutPanel tlpTitle;
        private EVOFramework.Windows.Forms.EVOLabel label1;
        private EVOFramework.Windows.Forms.EVOTextBox txtTemplate;
        private EVOFramework.Windows.Forms.EVOLabel lblTemplate;
        private EVOFramework.Windows.Forms.EVOTextBox txtStartRow;
        private EVOFramework.Windows.Forms.EVOLabel lblStartCell;
        private EVOFramework.Windows.Forms.EVOTextBox txtStartColumn;
        private FarPoint.Win.Spread.FpSpread fpQueryList;
        private FarPoint.Win.Spread.SheetView shtQueryList;
    }
}