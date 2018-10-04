namespace Rubik.Master
{
    partial class MAS110_SalesUnitPriceList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAS110_SalesUnitPriceList));
            this.txtFind = new EVOFramework.Windows.Forms.EVOTextBox();
            this.fpView = new FarPoint.Win.Spread.FpSpread();
            this.shtView = new FarPoint.Win.Spread.SheetView();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcPriceOn = new EVOFramework.Windows.Forms.EVOLabel();
            this.dtPriceOn = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).BeginInit();
            this.ctxMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.dtPriceOn);
            this.pnlContainer.Controls.Add(this.stcPriceOn);
            this.pnlContainer.Controls.Add(this.label1);
            this.pnlContainer.Controls.Add(this.pictureBox1);
            this.pnlContainer.Controls.Add(this.fpView);
            this.pnlContainer.Controls.Add(this.txtFind);
            this.pnlContainer.Size = new System.Drawing.Size(818, 384);
            // 
            // txtFind
            // 
            this.txtFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFind.AppearanceName = "";
            this.txtFind.AppearanceReadOnlyName = "";
            this.txtFind.BackColor = System.Drawing.Color.White;
            this.txtFind.ControlID = "";
            this.txtFind.DisableRestrictChar = true;
            this.txtFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtFind.ForeColor = System.Drawing.Color.Black;
            this.txtFind.HelpButton = null;
            this.txtFind.Location = new System.Drawing.Point(47, 50);
            this.txtFind.Name = "txtFind";
            this.txtFind.PathString = null;
            this.txtFind.PathValue = "";
            this.txtFind.Size = new System.Drawing.Size(979, 26);
            this.txtFind.TabIndex = 0;
            this.txtFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFind_KeyDown);
            this.txtFind.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFind_KeyUp);
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
            this.fpView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.Location = new System.Drawing.Point(13, 82);
            this.fpView.Name = "fpView";
            this.fpView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpView.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtView});
            this.fpView.Size = new System.Drawing.Size(802, 290);
            this.fpView.TabIndex = 3;
            this.fpView.TabStop = false;
            this.fpView.TextTipDelay = 1000;
            this.fpView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpView_CellDoubleClick);
            this.fpView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpView_KeyDown);
            this.fpView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fpView_KeyPress);
            this.fpView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fpView_MouseDown);
            // 
            // shtView
            // 
            this.shtView.Reset();
            this.shtView.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtView.ColumnCount = 8;
            this.shtView.RowCount = 0;
            this.shtView.AutoCalculation = false;
            this.shtView.AutoGenerateColumns = false;
            this.shtView.ColumnHeader.Cells.Get(0, 0).Value = "M/N";
            this.shtView.ColumnHeader.Cells.Get(0, 1).Value = "Part No.";
            this.shtView.ColumnHeader.Cells.Get(0, 2).Value = "Customer Name";
            this.shtView.ColumnHeader.Cells.Get(0, 3).Value = "Unit Price";
            this.shtView.ColumnHeader.Cells.Get(0, 4).Value = "Currency";
            this.shtView.ColumnHeader.Cells.Get(0, 5).Value = "Currency Name";
            this.shtView.ColumnHeader.Cells.Get(0, 6).Value = "Start Eff. Date";
            this.shtView.ColumnHeader.Cells.Get(0, 7).Value = "Remark";
            this.shtView.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtView.Columns.Get(0).AllowAutoFilter = true;
            this.shtView.Columns.Get(0).AllowAutoSort = true;
            this.shtView.Columns.Get(0).Label = "M/N";
            this.shtView.Columns.Get(0).Tag = "M/N";
            this.shtView.Columns.Get(0).Width = 90F;
            this.shtView.Columns.Get(1).AllowAutoFilter = true;
            this.shtView.Columns.Get(1).AllowAutoSort = true;
            this.shtView.Columns.Get(1).CellType = textCellType1;
            this.shtView.Columns.Get(1).Label = "Part No.";
            this.shtView.Columns.Get(1).Locked = true;
            this.shtView.Columns.Get(1).Tag = "ITEM_CD";
            this.shtView.Columns.Get(1).Width = 120F;
            this.shtView.Columns.Get(2).AllowAutoFilter = true;
            this.shtView.Columns.Get(2).AllowAutoSort = true;
            this.shtView.Columns.Get(2).CellType = textCellType2;
            this.shtView.Columns.Get(2).Label = "Customer Name";
            this.shtView.Columns.Get(2).Locked = true;
            this.shtView.Columns.Get(2).Tag = "CUST_NAME";
            this.shtView.Columns.Get(2).Width = 150F;
            this.shtView.Columns.Get(3).AllowAutoFilter = true;
            this.shtView.Columns.Get(3).AllowAutoSort = true;
            this.shtView.Columns.Get(3).Label = "Unit Price";
            this.shtView.Columns.Get(3).Tag = "UNIT_PRICE";
            this.shtView.Columns.Get(3).Width = 120F;
            this.shtView.Columns.Get(4).AllowAutoFilter = true;
            this.shtView.Columns.Get(4).AllowAutoSort = true;
            this.shtView.Columns.Get(4).Label = "Currency";
            this.shtView.Columns.Get(4).Tag = "CURRENCY";
            this.shtView.Columns.Get(4).Width = 120F;
            this.shtView.Columns.Get(5).AllowAutoFilter = true;
            this.shtView.Columns.Get(5).AllowAutoSort = true;
            this.shtView.Columns.Get(5).Label = "Currency Name";
            this.shtView.Columns.Get(5).Width = 163F;
            this.shtView.Columns.Get(6).AllowAutoFilter = true;
            this.shtView.Columns.Get(6).AllowAutoSort = true;
            this.shtView.Columns.Get(6).Label = "Start Eff. Date";
            this.shtView.Columns.Get(6).Tag = "Start Eff. Date";
            this.shtView.Columns.Get(6).Width = 130F;
            this.shtView.Columns.Get(7).AllowAutoFilter = true;
            this.shtView.Columns.Get(7).AllowAutoSort = true;
            this.shtView.Columns.Get(7).Label = "Remark";
            this.shtView.Columns.Get(7).Tag = "Remark";
            this.shtView.Columns.Get(7).Width = 200F;
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
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEdit,
            this.mnuDelete});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(106, 48);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(105, 22);
            this.mnuEdit.Text = "Edit";
            this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(105, 22);
            this.mnuDelete.Text = "Delete";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Rubik.Forms.Properties.Resources.FIND_TEXT;
            this.pictureBox1.Location = new System.Drawing.Point(13, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AppearanceName = "Title";
            this.label1.AutoSize = true;
            this.label1.ControlID = "";
            this.label1.Font = new System.Drawing.Font("Tahoma", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.PathString = null;
            this.label1.PathValue = "Sales Unit Price List";
            this.label1.Size = new System.Drawing.Size(333, 39);
            this.label1.TabIndex = 35;
            this.label1.Text = "Sales Unit Price List";
            // 
            // stcPriceOn
            // 
            this.stcPriceOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stcPriceOn.AppearanceName = "";
            this.stcPriceOn.AutoSize = true;
            this.stcPriceOn.ControlID = "";
            this.stcPriceOn.Location = new System.Drawing.Point(557, 17);
            this.stcPriceOn.Name = "stcPriceOn";
            this.stcPriceOn.PathString = null;
            this.stcPriceOn.PathValue = "Unit Price On";
            this.stcPriceOn.Size = new System.Drawing.Size(103, 19);
            this.stcPriceOn.TabIndex = 36;
            this.stcPriceOn.Text = "Unit Price On";
            this.stcPriceOn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtPriceOn
            // 
            this.dtPriceOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtPriceOn.AppearanceName = "";
            this.dtPriceOn.AppearanceReadOnlyName = "";
            this.dtPriceOn.BackColor = System.Drawing.Color.Transparent;
            this.dtPriceOn.ControlID = "";
            this.dtPriceOn.Format = "dd/MM/yyyy";
            this.dtPriceOn.Location = new System.Drawing.Point(666, 13);
            this.dtPriceOn.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtPriceOn.Name = "dtPriceOn";
            this.dtPriceOn.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtPriceOn.NZValue")));
            this.dtPriceOn.PathString = null;
            this.dtPriceOn.PathValue = ((object)(resources.GetObject("dtPriceOn.PathValue")));
            this.dtPriceOn.ReadOnly = false;
            this.dtPriceOn.ShowButton = true;
            this.dtPriceOn.Size = new System.Drawing.Size(143, 20);
            this.dtPriceOn.TabIndex = 37;
            this.dtPriceOn.Value = null;
            // 
            // MAS110_SalesUnitPriceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(818, 409);
            this.ExportObject = this.fpView;
            this.Name = "MAS110_SalesUnitPriceList";
            this.Load += new System.EventHandler(this.MAS010_LocationList_Load);
            this.Shown += new System.EventHandler(this.MAS010_LocationList_Shown);
            this.Controls.SetChildIndex(this.pnlContainer, 0);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).EndInit();
            this.ctxMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EVOFramework.Windows.Forms.EVOTextBox txtFind;
        private FarPoint.Win.Spread.FpSpread fpView;
        private FarPoint.Win.Spread.SheetView shtView;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.PictureBox pictureBox1;
        private EVOFramework.Windows.Forms.EVOLabel label1;
        private EVOFramework.Windows.Forms.EVOLabel stcPriceOn;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtPriceOn;
    }
}