
namespace Rubik.Transaction
{
    partial class TRN103_FGSelection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TRN103_FGSelection));
            this.dmc = new EVOFramework.Data.UIDataModelController(this.components);
            this.evoLabel1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.btnGenerate = new EVOFramework.Windows.Forms.EVOButton();
            this.lblLotNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtLotNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.txtRemainQty = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.evoLabel7 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtPartNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.evoLabel6 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtItemNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.evoLabel5 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtQty = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.lblTotalQty = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel2 = new EVOFramework.Windows.Forms.EVOLabel();
            this.fpView = new FarPoint.Win.Spread.FpSpread();
            this.cmsOperation = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shtView = new FarPoint.Win.Spread.SheetView();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).BeginInit();
            this.cmsOperation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContainer.Controls.Add(this.fpView);
            this.pnlContainer.Controls.Add(this.evoLabel2);
            this.pnlContainer.Controls.Add(this.txtQty);
            this.pnlContainer.Controls.Add(this.lblTotalQty);
            this.pnlContainer.Controls.Add(this.txtRemainQty);
            this.pnlContainer.Controls.Add(this.txtLotNo);
            this.pnlContainer.Controls.Add(this.evoLabel7);
            this.pnlContainer.Controls.Add(this.lblLotNo);
            this.pnlContainer.Controls.Add(this.txtPartNo);
            this.pnlContainer.Controls.Add(this.btnGenerate);
            this.pnlContainer.Controls.Add(this.evoLabel6);
            this.pnlContainer.Controls.Add(this.evoLabel1);
            this.pnlContainer.Controls.Add(this.txtItemNo);
            this.pnlContainer.Controls.Add(this.evoLabel5);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.None;
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlContainer.Location = new System.Drawing.Point(0, 25);
            this.pnlContainer.Size = new System.Drawing.Size(773, 465);
            // 
            // evoLabel1
            // 
            this.evoLabel1.AppearanceName = "Title";
            this.evoLabel1.AutoSize = true;
            this.evoLabel1.ControlID = "";
            this.evoLabel1.Font = new System.Drawing.Font("Tahoma", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.evoLabel1.Location = new System.Drawing.Point(12, 15);
            this.evoLabel1.Name = "evoLabel1";
            this.evoLabel1.PathString = null;
            this.evoLabel1.PathValue = "FG Selection";
            this.evoLabel1.Size = new System.Drawing.Size(217, 39);
            this.evoLabel1.TabIndex = 100019;
            this.evoLabel1.Text = "FG Selection";
            // 
            // btnGenerate
            // 
            this.btnGenerate.AppearanceName = "";
            this.btnGenerate.AutoSize = true;
            this.btnGenerate.BackgroundImage = global::Rubik.Forms.Properties.Resources.REFRESH;
            this.btnGenerate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGenerate.ControlID = null;
            this.btnGenerate.Location = new System.Drawing.Point(701, 63);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(34, 29);
            this.btnGenerate.TabIndex = 232336;
            this.btnGenerate.TabStop = false;
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Visible = false;
            // 
            // lblLotNo
            // 
            this.lblLotNo.AppearanceName = "";
            this.lblLotNo.ControlID = "";
            this.lblLotNo.Location = new System.Drawing.Point(285, 17);
            this.lblLotNo.Name = "lblLotNo";
            this.lblLotNo.PathString = null;
            this.lblLotNo.PathValue = "Lot No.";
            this.lblLotNo.Size = new System.Drawing.Size(92, 33);
            this.lblLotNo.TabIndex = 232337;
            this.lblLotNo.Text = "Lot No.";
            this.lblLotNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLotNo.Visible = false;
            // 
            // txtLotNo
            // 
            this.txtLotNo.AppearanceName = "";
            this.txtLotNo.AppearanceReadOnlyName = "";
            this.txtLotNo.ControlID = "";
            this.txtLotNo.DisableRestrictChar = false;
            this.txtLotNo.HelpButton = null;
            this.txtLotNo.Location = new System.Drawing.Point(383, 20);
            this.txtLotNo.MaxLength = 50;
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.PathString = "Lot_No.Value";
            this.txtLotNo.PathValue = "";
            this.txtLotNo.Size = new System.Drawing.Size(331, 27);
            this.txtLotNo.TabIndex = 232335;
            this.txtLotNo.Visible = false;
            this.txtLotNo.TextChanged += new System.EventHandler(this.txtLotNo_TextChanged);
            // 
            // txtRemainQty
            // 
            this.txtRemainQty.AllowNegative = true;
            this.txtRemainQty.AppearanceName = "";
            this.txtRemainQty.AppearanceReadOnlyName = "";
            this.txtRemainQty.BackColor = System.Drawing.SystemColors.Control;
            this.txtRemainQty.ControlID = "";
            this.txtRemainQty.Decimal = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtRemainQty.DecimalPoint = '.';
            this.txtRemainQty.DigitsInGroup = 3;
            this.txtRemainQty.Double = 1D;
            this.txtRemainQty.FixDecimalPosition = false;
            this.txtRemainQty.Flags = 0;
            this.txtRemainQty.GroupSeparator = ',';
            this.txtRemainQty.Int = 1;
            this.txtRemainQty.Location = new System.Drawing.Point(576, 65);
            this.txtRemainQty.Long = ((long)(1));
            this.txtRemainQty.MaxDecimalPlaces = 4;
            this.txtRemainQty.MaxWholeDigits = 9;
            this.txtRemainQty.Name = "txtRemainQty";
            this.txtRemainQty.NegativeSign = '-';
            this.txtRemainQty.PathString = null;
            this.txtRemainQty.PathValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtRemainQty.Prefix = "";
            this.txtRemainQty.RangeMax = 1.7976931348623157E+308D;
            this.txtRemainQty.RangeMin = -1.7976931348623157E+308D;
            this.txtRemainQty.Size = new System.Drawing.Size(119, 27);
            this.txtRemainQty.TabIndex = 100038;
            this.txtRemainQty.Text = "1";
            // 
            // evoLabel7
            // 
            this.evoLabel7.AppearanceName = "";
            this.evoLabel7.ControlID = "";
            this.evoLabel7.Location = new System.Drawing.Point(444, 63);
            this.evoLabel7.Name = "evoLabel7";
            this.evoLabel7.PathString = null;
            this.evoLabel7.PathValue = "Order Remain";
            this.evoLabel7.Size = new System.Drawing.Size(126, 28);
            this.evoLabel7.TabIndex = 100037;
            this.evoLabel7.Text = "Order Remain";
            this.evoLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPartNo
            // 
            this.txtPartNo.AppearanceName = "";
            this.txtPartNo.AppearanceReadOnlyName = "";
            this.txtPartNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtPartNo.ControlID = "";
            this.txtPartNo.DisableRestrictChar = false;
            this.txtPartNo.HelpButton = null;
            this.txtPartNo.Location = new System.Drawing.Point(254, 65);
            this.txtPartNo.Name = "txtPartNo";
            this.txtPartNo.PathString = null;
            this.txtPartNo.PathValue = "";
            this.txtPartNo.Size = new System.Drawing.Size(182, 27);
            this.txtPartNo.TabIndex = 100036;
            // 
            // evoLabel6
            // 
            this.evoLabel6.AppearanceName = "";
            this.evoLabel6.ControlID = "";
            this.evoLabel6.Location = new System.Drawing.Point(175, 63);
            this.evoLabel6.Name = "evoLabel6";
            this.evoLabel6.PathString = null;
            this.evoLabel6.PathValue = "Part No.";
            this.evoLabel6.Size = new System.Drawing.Size(73, 28);
            this.evoLabel6.TabIndex = 100035;
            this.evoLabel6.Text = "Part No.";
            this.evoLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtItemNo
            // 
            this.txtItemNo.AppearanceName = "";
            this.txtItemNo.AppearanceReadOnlyName = "";
            this.txtItemNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtItemNo.ControlID = "";
            this.txtItemNo.DisableRestrictChar = false;
            this.txtItemNo.HelpButton = null;
            this.txtItemNo.Location = new System.Drawing.Point(105, 65);
            this.txtItemNo.Name = "txtItemNo";
            this.txtItemNo.PathString = null;
            this.txtItemNo.PathValue = "";
            this.txtItemNo.Size = new System.Drawing.Size(59, 27);
            this.txtItemNo.TabIndex = 100034;
            // 
            // evoLabel5
            // 
            this.evoLabel5.AppearanceName = "";
            this.evoLabel5.ControlID = "";
            this.evoLabel5.Location = new System.Drawing.Point(15, 63);
            this.evoLabel5.Name = "evoLabel5";
            this.evoLabel5.PathString = null;
            this.evoLabel5.PathValue = "Master No.";
            this.evoLabel5.Size = new System.Drawing.Size(90, 28);
            this.evoLabel5.TabIndex = 100033;
            this.evoLabel5.Text = "Master No.";
            this.evoLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtQty
            // 
            this.txtQty.AllowNegative = true;
            this.txtQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtQty.AppearanceName = "";
            this.txtQty.AppearanceReadOnlyName = "";
            this.txtQty.BackColor = System.Drawing.SystemColors.Control;
            this.txtQty.ControlID = "";
            this.txtQty.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtQty.DecimalPoint = '.';
            this.txtQty.DigitsInGroup = 3;
            this.txtQty.Double = 0D;
            this.txtQty.FixDecimalPosition = true;
            this.txtQty.Flags = 0;
            this.txtQty.GroupSeparator = ',';
            this.txtQty.Int = 0;
            this.txtQty.Location = new System.Drawing.Point(518, 424);
            this.txtQty.Long = ((long)(0));
            this.txtQty.MaxDecimalPlaces = 4;
            this.txtQty.MaxWholeDigits = 9;
            this.txtQty.Name = "txtQty";
            this.txtQty.NegativeSign = '-';
            this.txtQty.PathString = "TOTAL_QTY.Value";
            this.txtQty.PathValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtQty.Prefix = "";
            this.txtQty.RangeMax = 1.7976931348623157E+308D;
            this.txtQty.RangeMin = -1.7976931348623157E+308D;
            this.txtQty.Size = new System.Drawing.Size(142, 27);
            this.txtQty.TabIndex = 232347;
            this.txtQty.Text = "0";
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalQty.AppearanceName = "";
            this.lblTotalQty.AutoSize = true;
            this.lblTotalQty.ControlID = "";
            this.lblTotalQty.Location = new System.Drawing.Point(425, 428);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.PathString = null;
            this.lblTotalQty.PathValue = "Total Qty";
            this.lblTotalQty.Size = new System.Drawing.Size(75, 19);
            this.lblTotalQty.TabIndex = 232345;
            this.lblTotalQty.Text = "Total Qty";
            // 
            // evoLabel2
            // 
            this.evoLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.evoLabel2.AppearanceName = "";
            this.evoLabel2.AutoSize = true;
            this.evoLabel2.ControlID = "";
            this.evoLabel2.ForeColor = System.Drawing.Color.Red;
            this.evoLabel2.Location = new System.Drawing.Point(15, 428);
            this.evoLabel2.Name = "evoLabel2";
            this.evoLabel2.PathString = null;
            this.evoLabel2.PathValue = "Highlight = This pack is choosed in other orders";
            this.evoLabel2.Size = new System.Drawing.Size(351, 19);
            this.evoLabel2.TabIndex = 232348;
            this.evoLabel2.Text = "Highlight = This pack is choosed in other orders";
            this.evoLabel2.Visible = false;
            // 
            // fpView
            // 
            this.fpView.About = "2.5.2015.2005";
            this.fpView.AccessibleDescription = "fpLotNoList, Sheet1";
            this.fpView.BackColor = System.Drawing.Color.AliceBlue;
            this.fpView.ContextMenuStrip = this.cmsOperation;
            this.fpView.EditModeReplace = true;
            this.fpView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.Location = new System.Drawing.Point(19, 109);
            this.fpView.Name = "fpView";
            this.fpView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtView});
            this.fpView.Size = new System.Drawing.Size(716, 299);
            this.fpView.TabIndex = 232349;
            this.fpView.TabStop = false;
            this.fpView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.EditModeOff += new System.EventHandler(this.fpView_EditModeOff);
            this.fpView.LeaveCell += new FarPoint.Win.Spread.LeaveCellEventHandler(this.fpView_LeaveCell);
            this.fpView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpView_KeyDown);
            this.fpView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fpView_KeyUp);
            this.fpView.Validating += new System.ComponentModel.CancelEventHandler(this.fpView_Validating);
            // 
            // cmsOperation
            // 
            this.cmsOperation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cmsOperation.Name = "cmsOperation";
            this.cmsOperation.Size = new System.Drawing.Size(153, 70);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // shtView
            // 
            this.shtView.Reset();
            this.shtView.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtView.ColumnCount = 4;
            this.shtView.RowCount = 0;
            this.shtView.AutoGenerateColumns = false;
            this.shtView.ColumnHeader.Cells.Get(0, 0).Value = "TRANS ID";
            this.shtView.ColumnHeader.Cells.Get(0, 1).Value = "Lot No.";
            this.shtView.ColumnHeader.Cells.Get(0, 2).Value = "Customer Lot No.";
            this.shtView.ColumnHeader.Cells.Get(0, 3).Value = "Qty";
            this.shtView.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtView.Columns.Get(0).Label = "TRANS ID";
            this.shtView.Columns.Get(0).Visible = false;
            this.shtView.Columns.Get(0).Width = 72F;
            textCellType1.MaxLength = 50;
            this.shtView.Columns.Get(1).CellType = textCellType1;
            this.shtView.Columns.Get(1).Label = "Lot No.";
            this.shtView.Columns.Get(1).Tag = "Lot No.";
            this.shtView.Columns.Get(1).Width = 150F;
            textCellType2.MaxLength = 50;
            this.shtView.Columns.Get(2).CellType = textCellType2;
            this.shtView.Columns.Get(2).Label = "Customer Lot No.";
            this.shtView.Columns.Get(2).Tag = "Customer Lot No.";
            this.shtView.Columns.Get(2).Width = 150F;
            this.shtView.Columns.Get(3).Label = "Qty";
            this.shtView.Columns.Get(3).Tag = "Qty";
            this.shtView.Columns.Get(3).Width = 150F;
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
            // TRN103_FGSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(773, 515);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 396);
            this.Name = "TRN103_FGSelection";
            this.Text = "TRN103: FG Selection";
            this.Load += new System.EventHandler(this.TRN103_FGSelection_Load);
            this.Controls.SetChildIndex(this.pnlContainer, 0);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).EndInit();
            this.cmsOperation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EVOFramework.Data.UIDataModelController dmc;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel1;
        private EVOFramework.Windows.Forms.EVOTextBox txtLotNo;
        private EVOFramework.Windows.Forms.EVOLabel lblLotNo;
        private EVOFramework.Windows.Forms.EVOButton btnGenerate;
        private EVOFramework.Windows.Forms.EVONumericTextBox txtRemainQty;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel7;
        private EVOFramework.Windows.Forms.EVOTextBox txtPartNo;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel6;
        private EVOFramework.Windows.Forms.EVOTextBox txtItemNo;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel5;
        private EVOFramework.Windows.Forms.EVONumericTextBox txtQty;
        private EVOFramework.Windows.Forms.EVOLabel lblTotalQty;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel2;
        private FarPoint.Win.Spread.FpSpread fpView;
        private FarPoint.Win.Spread.SheetView shtView;
        private System.Windows.Forms.ContextMenuStrip cmsOperation;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}
