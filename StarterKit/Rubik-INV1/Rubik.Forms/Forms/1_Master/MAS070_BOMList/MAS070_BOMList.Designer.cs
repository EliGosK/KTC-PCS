namespace Rubik.Master
{
    partial class MAS070_BOMList
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
            FarPoint.Win.Spread.CellType.TextCellType textCellType13 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType14 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType15 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType16 = new FarPoint.Win.Spread.CellType.TextCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAS070_BOMList));
            this.txtSearch = new EVOFramework.Windows.Forms.EVOTextBox();
            this.fpItemView = new FarPoint.Win.Spread.FpSpread();
            this.cmsItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shtItemView = new FarPoint.Win.Spread.SheetView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboBOMStatus = new EVOFramework.Windows.Forms.EVOComboBox();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpItemView)).BeginInit();
            this.cmsItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shtItemView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.cboBOMStatus);
            this.pnlContainer.Controls.Add(this.label1);
            this.pnlContainer.Controls.Add(this.pictureBox1);
            this.pnlContainer.Controls.Add(this.fpItemView);
            this.pnlContainer.Controls.Add(this.txtSearch);
            this.pnlContainer.Size = new System.Drawing.Size(792, 441);
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
            this.txtSearch.Location = new System.Drawing.Point(44, 50);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PathString = null;
            this.txtSearch.PathValue = "";
            this.txtSearch.Size = new System.Drawing.Size(487, 26);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TabStop = false;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // fpItemView
            // 
            this.fpItemView.About = "2.5.2015.2005";
            this.fpItemView.AccessibleDescription = "fpItemView, Sheet1";
            this.fpItemView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fpItemView.BackColor = System.Drawing.SystemColors.Control;
            this.fpItemView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fpItemView.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpItemView.ContextMenuStrip = this.cmsItem;
            this.fpItemView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpItemView.Location = new System.Drawing.Point(10, 82);
            this.fpItemView.Name = "fpItemView";
            this.fpItemView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpItemView.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpItemView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpItemView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtItemView});
            this.fpItemView.Size = new System.Drawing.Size(770, 347);
            this.fpItemView.TabIndex = 3;
            this.fpItemView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpItemView.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpItemView_CellDoubleClick);
            this.fpItemView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpItemView_KeyDown);
            this.fpItemView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fpItemView_KeyPress);
            this.fpItemView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fpItemView_MouseDown);
            // 
            // cmsItem
            // 
            this.cmsItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cmsItem.Name = "cmsItem";
            this.cmsItem.Size = new System.Drawing.Size(106, 48);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // shtItemView
            // 
            this.shtItemView.Reset();
            this.shtItemView.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtItemView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtItemView.ColumnCount = 17;
            this.shtItemView.RowCount = 0;
            this.shtItemView.AutoCalculation = false;
            this.shtItemView.AutoGenerateColumns = false;
            this.shtItemView.ColumnHeader.Cells.Get(0, 0).Value = "Part No";
            this.shtItemView.ColumnHeader.Cells.Get(0, 1).Value = "Part Name";
            this.shtItemView.ColumnHeader.Cells.Get(0, 2).Value = "Part Class";
            this.shtItemView.ColumnHeader.Cells.Get(0, 3).Value = "Lot Control";
            this.shtItemView.ColumnHeader.Cells.Get(0, 4).Value = "Process";
            this.shtItemView.ColumnHeader.Cells.Get(0, 5).Value = "Order Loc";
            this.shtItemView.ColumnHeader.Cells.Get(0, 6).Value = "Store Loc";
            this.shtItemView.ColumnHeader.Cells.Get(0, 7).Value = "Child Order Loc";
            this.shtItemView.ColumnHeader.Cells.Get(0, 8).Value = "Consump.";
            this.shtItemView.ColumnHeader.Cells.Get(0, 9).Value = "Seq";
            this.shtItemView.ColumnHeader.Cells.Get(0, 10).Value = "Lower Item";
            this.shtItemView.ColumnHeader.Cells.Get(0, 11).Value = "Lower Item Name";
            this.shtItemView.ColumnHeader.Cells.Get(0, 12).Value = "Lower Class";
            this.shtItemView.ColumnHeader.Cells.Get(0, 13).Value = "Qty";
            this.shtItemView.ColumnHeader.Cells.Get(0, 14).Value = "Div";
            this.shtItemView.ColumnHeader.Cells.Get(0, 15).Value = "Status";
            this.shtItemView.ColumnHeader.Cells.Get(0, 16).Value = "MRP Flag";
            this.shtItemView.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtItemView.Columns.Get(0).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(0).AllowAutoSort = true;
            this.shtItemView.Columns.Get(0).CellType = textCellType1;
            this.shtItemView.Columns.Get(0).Label = "Part No";
            this.shtItemView.Columns.Get(0).Tag = "Part No";
            this.shtItemView.Columns.Get(0).Width = 139F;
            this.shtItemView.Columns.Get(1).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(1).AllowAutoSort = true;
            this.shtItemView.Columns.Get(1).CellType = textCellType2;
            this.shtItemView.Columns.Get(1).Label = "Part Name";
            this.shtItemView.Columns.Get(1).Tag = "Part Name";
            this.shtItemView.Columns.Get(1).Width = 139F;
            this.shtItemView.Columns.Get(2).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(2).AllowAutoSort = true;
            this.shtItemView.Columns.Get(2).CellType = textCellType3;
            this.shtItemView.Columns.Get(2).Label = "Part Class";
            this.shtItemView.Columns.Get(2).Tag = "Part Class";
            this.shtItemView.Columns.Get(2).Width = 139F;
            this.shtItemView.Columns.Get(3).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(3).AllowAutoSort = true;
            this.shtItemView.Columns.Get(3).CellType = textCellType4;
            this.shtItemView.Columns.Get(3).Label = "Lot Control";
            this.shtItemView.Columns.Get(3).Tag = "Lot Control";
            this.shtItemView.Columns.Get(3).Width = 139F;
            this.shtItemView.Columns.Get(4).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(4).AllowAutoSort = true;
            this.shtItemView.Columns.Get(4).CellType = textCellType5;
            this.shtItemView.Columns.Get(4).Label = "Process";
            this.shtItemView.Columns.Get(4).Tag = "Process";
            this.shtItemView.Columns.Get(4).Width = 139F;
            this.shtItemView.Columns.Get(5).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(5).AllowAutoSort = true;
            this.shtItemView.Columns.Get(5).CellType = textCellType6;
            this.shtItemView.Columns.Get(5).Label = "Order Loc";
            this.shtItemView.Columns.Get(5).Tag = "Order Loc";
            this.shtItemView.Columns.Get(5).Width = 139F;
            this.shtItemView.Columns.Get(6).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(6).AllowAutoSort = true;
            this.shtItemView.Columns.Get(6).CellType = textCellType7;
            this.shtItemView.Columns.Get(6).Label = "Store Loc";
            this.shtItemView.Columns.Get(6).Tag = "Store Loc";
            this.shtItemView.Columns.Get(6).Width = 139F;
            this.shtItemView.Columns.Get(7).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(7).AllowAutoSort = true;
            this.shtItemView.Columns.Get(7).CellType = textCellType8;
            this.shtItemView.Columns.Get(7).Label = "Child Order Loc";
            this.shtItemView.Columns.Get(7).Tag = "Child Order Loc";
            this.shtItemView.Columns.Get(7).Width = 139F;
            this.shtItemView.Columns.Get(8).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(8).AllowAutoSort = true;
            this.shtItemView.Columns.Get(8).CellType = textCellType9;
            this.shtItemView.Columns.Get(8).Label = "Consump.";
            this.shtItemView.Columns.Get(8).Tag = "Consump.";
            this.shtItemView.Columns.Get(8).Width = 139F;
            this.shtItemView.Columns.Get(9).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(9).AllowAutoSort = true;
            this.shtItemView.Columns.Get(9).CellType = textCellType10;
            this.shtItemView.Columns.Get(9).Label = "Seq";
            this.shtItemView.Columns.Get(9).Tag = "Seq";
            this.shtItemView.Columns.Get(9).Width = 139F;
            this.shtItemView.Columns.Get(10).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(10).AllowAutoSort = true;
            this.shtItemView.Columns.Get(10).CellType = textCellType11;
            this.shtItemView.Columns.Get(10).Label = "Lower Item";
            this.shtItemView.Columns.Get(10).Tag = "Lower Item";
            this.shtItemView.Columns.Get(10).Width = 139F;
            this.shtItemView.Columns.Get(11).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(11).AllowAutoSort = true;
            this.shtItemView.Columns.Get(11).CellType = textCellType12;
            this.shtItemView.Columns.Get(11).Label = "Lower Item Name";
            this.shtItemView.Columns.Get(11).Tag = "Lower Item Name";
            this.shtItemView.Columns.Get(11).Width = 139F;
            this.shtItemView.Columns.Get(12).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(12).AllowAutoSort = true;
            this.shtItemView.Columns.Get(12).CellType = textCellType13;
            this.shtItemView.Columns.Get(12).Label = "Lower Class";
            this.shtItemView.Columns.Get(12).Tag = "Lower Class";
            this.shtItemView.Columns.Get(12).Width = 139F;
            this.shtItemView.Columns.Get(13).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(13).AllowAutoSort = true;
            this.shtItemView.Columns.Get(13).CellType = textCellType14;
            this.shtItemView.Columns.Get(13).Label = "Qty";
            this.shtItemView.Columns.Get(13).Tag = "Qty";
            this.shtItemView.Columns.Get(13).Width = 139F;
            this.shtItemView.Columns.Get(14).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(14).AllowAutoSort = true;
            this.shtItemView.Columns.Get(14).CellType = textCellType15;
            this.shtItemView.Columns.Get(14).Label = "Div";
            this.shtItemView.Columns.Get(14).Tag = "Div";
            this.shtItemView.Columns.Get(14).Width = 139F;
            this.shtItemView.Columns.Get(15).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(15).AllowAutoSort = true;
            this.shtItemView.Columns.Get(15).CellType = textCellType16;
            this.shtItemView.Columns.Get(15).Label = "Status";
            this.shtItemView.Columns.Get(15).Tag = "Status";
            this.shtItemView.Columns.Get(15).Width = 139F;
            this.shtItemView.Columns.Get(16).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(16).AllowAutoSort = true;
            this.shtItemView.Columns.Get(16).Label = "MRP Flag";
            this.shtItemView.Columns.Get(16).Tag = "MRP Flag";
            this.shtItemView.Columns.Get(16).Width = 139F;
            this.shtItemView.DataAutoCellTypes = false;
            this.shtItemView.DataAutoHeadings = false;
            this.shtItemView.DataAutoSizeColumns = false;
            this.shtItemView.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.shtItemView.RowHeader.Columns.Default.Resizable = true;
            this.shtItemView.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.shtItemView.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.shtItemView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpItemView.SetActiveViewport(0, 1, 0);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Rubik.Forms.Properties.Resources.FIND_TEXT;
            this.pictureBox1.Location = new System.Drawing.Point(6, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 39);
            this.label1.TabIndex = 35;
            this.label1.Text = "BOM List";
            // 
            // cboBOMStatus
            // 
            this.cboBOMStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBOMStatus.AppearanceName = "";
            this.cboBOMStatus.AppearanceReadOnlyName = "";
            this.cboBOMStatus.ControlID = null;
            this.cboBOMStatus.DropDownHeight = 180;
            this.cboBOMStatus.FormattingEnabled = true;
            this.cboBOMStatus.IntegralHeight = false;
            this.cboBOMStatus.Location = new System.Drawing.Point(537, 50);
            this.cboBOMStatus.Name = "cboBOMStatus";
            this.cboBOMStatus.PathString = "";
            this.cboBOMStatus.PathValue = null;
            this.cboBOMStatus.Size = new System.Drawing.Size(243, 27);
            this.cboBOMStatus.TabIndex = 36;
            this.cboBOMStatus.SelectedValueChanged += new System.EventHandler(this.cboBOMStatus_SelectedValueChanged);
            // 
            // MAS070_BOMList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(792, 466);
            this.ExportObject = this.fpItemView;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MAS070_BOMList";
            this.Text = "BOM List";
            this.Load += new System.EventHandler(this.MAS030_ItemList_Load);
            this.Controls.SetChildIndex(this.pnlContainer, 0);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpItemView)).EndInit();
            this.cmsItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shtItemView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EVOFramework.Windows.Forms.EVOTextBox txtSearch;
        private FarPoint.Win.Spread.FpSpread fpItemView;
        private FarPoint.Win.Spread.SheetView shtItemView;
        private System.Windows.Forms.ContextMenuStrip cmsItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private EVOFramework.Windows.Forms.EVOComboBox cboBOMStatus;
    }
}
