namespace Rubik.Transaction
{
    partial class TRN100_DeliveryEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TRN100_DeliveryEntry));
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.lblShipInformation = new EVOFramework.Windows.Forms.EVOLabel();
            this.cmsOperation = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.evoLabel4 = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboFromLoc = new EVOFramework.Windows.Forms.EVOComboBox();
            this.txtRemark = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblRemark = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboCustomerCode = new EVOFramework.Windows.Forms.EVOComboBox();
            this.lblFromLoc = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblCustomerCode = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoPanel1 = new EVOFramework.Windows.Forms.EVOPanel();
            this.label7 = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblShipmentNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblShipDate = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblDeliveryNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.dtDeliveryDate = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.dmcShip = new EVOFramework.Data.UIDataModelController(this.components);
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.fpCustomerOrder = new FarPoint.Win.Spread.FpSpread();
            this.shtCustomerOrder = new FarPoint.Win.Spread.SheetView();
            this.lblGrandTotal = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblTotalAmount = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblTotalQty = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel2 = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboCurrency = new EVOFramework.Windows.Forms.EVOComboBox();
            this.fpCustomerOrderDetail = new FarPoint.Win.Spread.FpSpread();
            this.shtCustomerOrderDetail = new FarPoint.Win.Spread.SheetView();
            this.evoLabel3 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtQty = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.txtAmount = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.evoLabel5 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel6 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel7 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtInvoiceNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.pnlContainer.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.cmsOperation.SuspendLayout();
            this.evoPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpCustomerOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtCustomerOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpCustomerOrderDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtCustomerOrderDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.txtInvoiceNo);
            this.pnlContainer.Controls.Add(this.evoLabel6);
            this.pnlContainer.Controls.Add(this.evoLabel5);
            this.pnlContainer.Controls.Add(this.txtAmount);
            this.pnlContainer.Controls.Add(this.txtQty);
            this.pnlContainer.Controls.Add(this.evoLabel3);
            this.pnlContainer.Controls.Add(this.fpCustomerOrderDetail);
            this.pnlContainer.Controls.Add(this.evoLabel1);
            this.pnlContainer.Controls.Add(this.lblGrandTotal);
            this.pnlContainer.Controls.Add(this.lblTotalAmount);
            this.pnlContainer.Controls.Add(this.lblTotalQty);
            this.pnlContainer.Controls.Add(this.fpCustomerOrder);
            this.pnlContainer.Controls.Add(this.btnAddOrder);
            this.pnlContainer.Controls.Add(this.tableLayoutPanel7);
            this.pnlContainer.Controls.Add(this.txtRemark);
            this.pnlContainer.Controls.Add(this.cboFromLoc);
            this.pnlContainer.Controls.Add(this.evoLabel7);
            this.pnlContainer.Controls.Add(this.lblRemark);
            this.pnlContainer.Controls.Add(this.evoLabel4);
            this.pnlContainer.Controls.Add(this.lblFromLoc);
            this.pnlContainer.Controls.Add(this.evoPanel1);
            this.pnlContainer.Controls.Add(this.dtDeliveryDate);
            this.pnlContainer.Controls.Add(this.lblDeliveryNo);
            this.pnlContainer.Controls.Add(this.cboCurrency);
            this.pnlContainer.Controls.Add(this.cboCustomerCode);
            this.pnlContainer.Controls.Add(this.lblShipDate);
            this.pnlContainer.Controls.Add(this.evoLabel2);
            this.pnlContainer.Controls.Add(this.lblCustomerCode);
            this.pnlContainer.Controls.Add(this.lblShipmentNo);
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlContainer.Size = new System.Drawing.Size(942, 616);
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel7.BackgroundImage")));
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.Controls.Add(this.lblShipInformation, 0, 0);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(12, 68);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(923, 23);
            this.tableLayoutPanel7.TabIndex = 12;
            // 
            // lblShipInformation
            // 
            this.lblShipInformation.AppearanceName = "Header";
            this.lblShipInformation.AutoSize = true;
            this.lblShipInformation.ControlID = "";
            this.lblShipInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblShipInformation.ForeColor = System.Drawing.Color.Navy;
            this.lblShipInformation.Location = new System.Drawing.Point(0, 0);
            this.lblShipInformation.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblShipInformation.Name = "lblShipInformation";
            this.lblShipInformation.PathString = null;
            this.lblShipInformation.PathValue = "Delivery Information";
            this.lblShipInformation.Size = new System.Drawing.Size(174, 23);
            this.lblShipInformation.TabIndex = 0;
            this.lblShipInformation.Text = "Delivery Information";
            // 
            // cmsOperation
            // 
            this.cmsOperation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.cmsOperation.Name = "cmsOperation";
            this.cmsOperation.Size = new System.Drawing.Size(106, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // evoLabel4
            // 
            this.evoLabel4.AppearanceName = "RequireText";
            this.evoLabel4.ControlID = "";
            this.evoLabel4.Location = new System.Drawing.Point(12, 137);
            this.evoLabel4.Name = "evoLabel4";
            this.evoLabel4.PathString = null;
            this.evoLabel4.PathValue = "*";
            this.evoLabel4.Size = new System.Drawing.Size(12, 32);
            this.evoLabel4.TabIndex = 232331;
            this.evoLabel4.Text = "*";
            this.evoLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboFromLoc
            // 
            this.cboFromLoc.AppearanceName = "";
            this.cboFromLoc.AppearanceReadOnlyName = "";
            this.cboFromLoc.BackColor = System.Drawing.Color.White;
            this.cboFromLoc.ControlID = null;
            this.cboFromLoc.DropDownHeight = 180;
            this.cboFromLoc.ForeColor = System.Drawing.Color.Black;
            this.cboFromLoc.FormattingEnabled = true;
            this.cboFromLoc.IntegralHeight = false;
            this.cboFromLoc.Location = new System.Drawing.Point(168, 140);
            this.cboFromLoc.Name = "cboFromLoc";
            this.cboFromLoc.PathString = "LOC_CD.Value";
            this.cboFromLoc.PathValue = null;
            this.cboFromLoc.Size = new System.Drawing.Size(436, 27);
            this.cboFromLoc.TabIndex = 3;
            this.cboFromLoc.SelectedIndexChanged += new System.EventHandler(this.cboFromLoc_SelectedIndexChanged);
            // 
            // txtRemark
            // 
            this.txtRemark.AppearanceName = "";
            this.txtRemark.AppearanceReadOnlyName = "";
            this.txtRemark.BackColor = System.Drawing.Color.White;
            this.txtRemark.ControlID = "";
            this.txtRemark.DisableRestrictChar = false;
            this.txtRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtRemark.ForeColor = System.Drawing.Color.Black;
            this.txtRemark.HelpButton = null;
            this.txtRemark.Location = new System.Drawing.Point(168, 173);
            this.txtRemark.MaxLength = 255;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.PathString = "REMARK.Value";
            this.txtRemark.PathValue = "";
            this.txtRemark.Size = new System.Drawing.Size(762, 26);
            this.txtRemark.TabIndex = 5;
            this.txtRemark.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRemark_KeyPress);
            // 
            // lblRemark
            // 
            this.lblRemark.AppearanceName = "";
            this.lblRemark.ControlID = "";
            this.lblRemark.Location = new System.Drawing.Point(38, 171);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.PathString = null;
            this.lblRemark.PathValue = "Remark";
            this.lblRemark.Size = new System.Drawing.Size(101, 31);
            this.lblRemark.TabIndex = 8;
            this.lblRemark.Text = "Remark";
            this.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboCustomerCode
            // 
            this.cboCustomerCode.AppearanceName = "";
            this.cboCustomerCode.AppearanceReadOnlyName = "";
            this.cboCustomerCode.BackColor = System.Drawing.Color.White;
            this.cboCustomerCode.ControlID = "";
            this.cboCustomerCode.DropDownHeight = 180;
            this.cboCustomerCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboCustomerCode.ForeColor = System.Drawing.Color.Black;
            this.cboCustomerCode.FormattingEnabled = true;
            this.cboCustomerCode.IntegralHeight = false;
            this.cboCustomerCode.Location = new System.Drawing.Point(168, 106);
            this.cboCustomerCode.MaxLength = 200;
            this.cboCustomerCode.Name = "cboCustomerCode";
            this.cboCustomerCode.PathString = "DEALING_NO.Value";
            this.cboCustomerCode.PathValue = null;
            this.cboCustomerCode.Size = new System.Drawing.Size(436, 28);
            this.cboCustomerCode.TabIndex = 1;
            this.cboCustomerCode.SelectedIndexChanged += new System.EventHandler(this.cboCustomerCode_SelectedIndexChanged);
            // 
            // lblFromLoc
            // 
            this.lblFromLoc.AppearanceName = "";
            this.lblFromLoc.ControlID = "";
            this.lblFromLoc.Location = new System.Drawing.Point(36, 138);
            this.lblFromLoc.Name = "lblFromLoc";
            this.lblFromLoc.PathString = null;
            this.lblFromLoc.PathValue = "From Loc";
            this.lblFromLoc.Size = new System.Drawing.Size(101, 31);
            this.lblFromLoc.TabIndex = 8;
            this.lblFromLoc.Text = "From Loc";
            this.lblFromLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCustomerCode
            // 
            this.lblCustomerCode.AppearanceName = "";
            this.lblCustomerCode.ControlID = "";
            this.lblCustomerCode.Location = new System.Drawing.Point(36, 105);
            this.lblCustomerCode.Name = "lblCustomerCode";
            this.lblCustomerCode.PathString = null;
            this.lblCustomerCode.PathValue = "Customer Code";
            this.lblCustomerCode.Size = new System.Drawing.Size(124, 31);
            this.lblCustomerCode.TabIndex = 8;
            this.lblCustomerCode.Text = "Customer Code";
            this.lblCustomerCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // evoPanel1
            // 
            this.evoPanel1.AppearanceName = "";
            this.evoPanel1.Controls.Add(this.label7);
            this.evoPanel1.Location = new System.Drawing.Point(12, 3);
            this.evoPanel1.Name = "evoPanel1";
            this.evoPanel1.Size = new System.Drawing.Size(286, 46);
            this.evoPanel1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AppearanceName = "Title";
            this.label7.AutoSize = true;
            this.label7.ControlID = "";
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Tahoma", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.PathString = null;
            this.label7.PathValue = "Delivery Entry";
            this.label7.Size = new System.Drawing.Size(244, 39);
            this.label7.TabIndex = 37;
            this.label7.Text = "Delivery Entry";
            // 
            // lblShipmentNo
            // 
            this.lblShipmentNo.AppearanceName = "";
            this.lblShipmentNo.ControlID = "";
            this.lblShipmentNo.Location = new System.Drawing.Point(521, 7);
            this.lblShipmentNo.Name = "lblShipmentNo";
            this.lblShipmentNo.PathString = null;
            this.lblShipmentNo.PathValue = "Transaction No.";
            this.lblShipmentNo.Size = new System.Drawing.Size(137, 32);
            this.lblShipmentNo.TabIndex = 1;
            this.lblShipmentNo.Text = "Transaction No.";
            this.lblShipmentNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblShipDate
            // 
            this.lblShipDate.AppearanceName = "";
            this.lblShipDate.ControlID = "";
            this.lblShipDate.Location = new System.Drawing.Point(524, 39);
            this.lblShipDate.Name = "lblShipDate";
            this.lblShipDate.PathString = null;
            this.lblShipDate.PathValue = "Delivery Date";
            this.lblShipDate.Size = new System.Drawing.Size(112, 29);
            this.lblShipDate.TabIndex = 2;
            this.lblShipDate.Text = "Delivery Date";
            this.lblShipDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDeliveryNo
            // 
            this.lblDeliveryNo.AppearanceName = "";
            this.lblDeliveryNo.ControlID = "";
            this.lblDeliveryNo.Location = new System.Drawing.Point(664, 7);
            this.lblDeliveryNo.Name = "lblDeliveryNo";
            this.lblDeliveryNo.PathString = "SLIP_NO.Value";
            this.lblDeliveryNo.PathValue = "";
            this.lblDeliveryNo.Size = new System.Drawing.Size(261, 32);
            this.lblDeliveryNo.TabIndex = 1;
            this.lblDeliveryNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtDeliveryDate
            // 
            this.dtDeliveryDate.AppearanceName = "";
            this.dtDeliveryDate.AppearanceReadOnlyName = "";
            this.dtDeliveryDate.BackColor = System.Drawing.Color.Transparent;
            this.dtDeliveryDate.ControlID = "";
            this.dtDeliveryDate.Format = "dd/MM/yyyy";
            this.dtDeliveryDate.Location = new System.Drawing.Point(664, 42);
            this.dtDeliveryDate.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtDeliveryDate.Name = "dtDeliveryDate";
            this.dtDeliveryDate.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtDeliveryDate.NZValue")));
            this.dtDeliveryDate.PathString = "TRANS_DATE.Value";
            this.dtDeliveryDate.PathValue = ((object)(resources.GetObject("dtDeliveryDate.PathValue")));
            this.dtDeliveryDate.ReadOnly = false;
            this.dtDeliveryDate.ShowButton = true;
            this.dtDeliveryDate.Size = new System.Drawing.Size(261, 20);
            this.dtDeliveryDate.TabIndex = 0;
            this.dtDeliveryDate.Value = null;
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.Location = new System.Drawing.Point(13, 205);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(150, 26);
            this.btnAddOrder.TabIndex = 6;
            this.btnAddOrder.Text = "Add Order";
            this.btnAddOrder.UseVisualStyleBackColor = true;
            this.btnAddOrder.Click += new System.EventHandler(this.btnOrderMaintenance_Click);
            // 
            // fpCustomerOrder
            // 
            this.fpCustomerOrder.About = "2.5.2015.2005";
            this.fpCustomerOrder.AccessibleDescription = "fpCustomerOrder, SheetCustomerOrder, Row 0, Column 0, ";
            this.fpCustomerOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fpCustomerOrder.BackColor = System.Drawing.Color.AliceBlue;
            this.fpCustomerOrder.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpCustomerOrder.ContextMenuStrip = this.cmsOperation;
            this.fpCustomerOrder.EditModeReplace = true;
            this.fpCustomerOrder.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpCustomerOrder.Location = new System.Drawing.Point(10, 237);
            this.fpCustomerOrder.Name = "fpCustomerOrder";
            this.fpCustomerOrder.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpCustomerOrder.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpCustomerOrder.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpCustomerOrder.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtCustomerOrder});
            this.fpCustomerOrder.Size = new System.Drawing.Size(923, 136);
            this.fpCustomerOrder.TabIndex = 7;
            this.fpCustomerOrder.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never;
            this.fpCustomerOrder.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpCustomerOrder.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpCustomerOrder_CellClick);
            this.fpCustomerOrder.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.fpCustomerOrder_ButtonClicked);
            this.fpCustomerOrder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpCustomerOrder_KeyDown);
            this.fpCustomerOrder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fpCustomerOrder_MouseDown);
            // 
            // shtCustomerOrder
            // 
            this.shtCustomerOrder.Reset();
            this.shtCustomerOrder.SheetName = "SheetCustomerOrder";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtCustomerOrder.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtCustomerOrder.ColumnCount = 14;
            this.shtCustomerOrder.RowCount = 3;
            this.shtCustomerOrder.AutoGenerateColumns = false;
            this.shtCustomerOrder.Cells.Get(0, 4).Value = "PartA";
            this.shtCustomerOrder.Cells.Get(1, 4).Value = "PartB";
            this.shtCustomerOrder.Cells.Get(2, 4).Value = "PartC";
            this.shtCustomerOrder.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.shtCustomerOrder.ColumnHeader.Cells.Get(0, 0).Value = "PO No.";
            this.shtCustomerOrder.ColumnHeader.Cells.Get(0, 1).Value = "Order No.";
            this.shtCustomerOrder.ColumnHeader.Cells.Get(0, 2).Value = "Order Detail No";
            this.shtCustomerOrder.ColumnHeader.Cells.Get(0, 3).Value = "M/N";
            this.shtCustomerOrder.ColumnHeader.Cells.Get(0, 4).Value = "Part No.";
            this.shtCustomerOrder.ColumnHeader.Cells.Get(0, 5).Value = "Delivery Date";
            this.shtCustomerOrder.ColumnHeader.Cells.Get(0, 6).Value = "Order QTY";
            this.shtCustomerOrder.ColumnHeader.Cells.Get(0, 7).Value = "Order Remain Qty";
            this.shtCustomerOrder.ColumnHeader.Cells.Get(0, 8).Value = "Delivery Qty";
            this.shtCustomerOrder.ColumnHeader.Cells.Get(0, 9).Value = "Ship QTY";
            this.shtCustomerOrder.ColumnHeader.Cells.Get(0, 10).Value = "Price";
            this.shtCustomerOrder.ColumnHeader.Cells.Get(0, 11).Value = "Amount";
            this.shtCustomerOrder.ColumnHeader.Cells.Get(0, 12).Value = "Return Qty";
            this.shtCustomerOrder.ColumnHeader.Cells.Get(0, 13).Value = "Choose FG";
            this.shtCustomerOrder.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtCustomerOrder.Columns.Get(0).Label = "PO No.";
            this.shtCustomerOrder.Columns.Get(0).Width = 91F;
            this.shtCustomerOrder.Columns.Get(1).CellType = textCellType1;
            this.shtCustomerOrder.Columns.Get(1).Label = "Order No.";
            this.shtCustomerOrder.Columns.Get(1).Tag = "Order No.";
            this.shtCustomerOrder.Columns.Get(1).Width = 100F;
            this.shtCustomerOrder.Columns.Get(2).Label = "Order Detail No";
            this.shtCustomerOrder.Columns.Get(2).Visible = false;
            this.shtCustomerOrder.Columns.Get(2).Width = 150F;
            this.shtCustomerOrder.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.shtCustomerOrder.Columns.Get(3).Label = "M/N";
            this.shtCustomerOrder.Columns.Get(3).Tag = "Master No.";
            this.shtCustomerOrder.Columns.Get(3).Width = 70F;
            this.shtCustomerOrder.Columns.Get(4).Label = "Part No.";
            this.shtCustomerOrder.Columns.Get(4).Tag = "Part No.";
            this.shtCustomerOrder.Columns.Get(4).Width = 70F;
            this.shtCustomerOrder.Columns.Get(5).Label = "Delivery Date";
            this.shtCustomerOrder.Columns.Get(5).Tag = "Delivery Date";
            this.shtCustomerOrder.Columns.Get(5).Width = 80F;
            this.shtCustomerOrder.Columns.Get(6).Label = "Order QTY";
            this.shtCustomerOrder.Columns.Get(6).Visible = false;
            this.shtCustomerOrder.Columns.Get(6).Width = 100F;
            this.shtCustomerOrder.Columns.Get(7).CellType = numberCellType3;
            this.shtCustomerOrder.Columns.Get(7).Label = "Order Remain Qty";
            this.shtCustomerOrder.Columns.Get(7).Locked = true;
            this.shtCustomerOrder.Columns.Get(7).Tag = "Order Remain Qty";
            this.shtCustomerOrder.Columns.Get(7).Width = 100F;
            this.shtCustomerOrder.Columns.Get(8).CellType = numberCellType4;
            this.shtCustomerOrder.Columns.Get(8).Label = "Delivery Qty";
            this.shtCustomerOrder.Columns.Get(8).Tag = "Delivery Qty";
            this.shtCustomerOrder.Columns.Get(8).Width = 70F;
            this.shtCustomerOrder.Columns.Get(9).Label = "Ship QTY";
            this.shtCustomerOrder.Columns.Get(9).Visible = false;
            this.shtCustomerOrder.Columns.Get(9).Width = 100F;
            this.shtCustomerOrder.Columns.Get(10).Label = "Price";
            this.shtCustomerOrder.Columns.Get(10).Tag = "Price";
            this.shtCustomerOrder.Columns.Get(10).Width = 70F;
            this.shtCustomerOrder.Columns.Get(11).Label = "Amount";
            this.shtCustomerOrder.Columns.Get(11).Tag = "Amount";
            this.shtCustomerOrder.Columns.Get(11).Width = 70F;
            this.shtCustomerOrder.Columns.Get(12).Label = "Return Qty";
            this.shtCustomerOrder.Columns.Get(12).Visible = false;
            this.shtCustomerOrder.Columns.Get(12).Width = 80F;
            this.shtCustomerOrder.Columns.Get(13).CellType = buttonCellType1;
            this.shtCustomerOrder.Columns.Get(13).Label = "Choose FG";
            this.shtCustomerOrder.Columns.Get(13).Tag = "Choose FG";
            this.shtCustomerOrder.Columns.Get(13).Width = 80F;
            this.shtCustomerOrder.DataAutoCellTypes = false;
            this.shtCustomerOrder.DataAutoHeadings = false;
            this.shtCustomerOrder.DataAutoSizeColumns = false;
            this.shtCustomerOrder.RowHeader.Columns.Default.Resizable = true;
            this.shtCustomerOrder.Rows.Get(1).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.shtCustomerOrder.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGrandTotal.AppearanceName = "";
            this.lblGrandTotal.AutoSize = true;
            this.lblGrandTotal.ControlID = "";
            this.lblGrandTotal.Location = new System.Drawing.Point(87, 586);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.PathString = null;
            this.lblGrandTotal.PathValue = "Total";
            this.lblGrandTotal.Size = new System.Drawing.Size(45, 19);
            this.lblGrandTotal.TabIndex = 232340;
            this.lblGrandTotal.Text = "Total";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalAmount.AppearanceName = "";
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.ControlID = "";
            this.lblTotalAmount.Location = new System.Drawing.Point(490, 586);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.PathString = null;
            this.lblTotalAmount.PathValue = "Amount";
            this.lblTotalAmount.Size = new System.Drawing.Size(66, 19);
            this.lblTotalAmount.TabIndex = 232337;
            this.lblTotalAmount.Text = "Amount";
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalQty.AppearanceName = "";
            this.lblTotalQty.AutoSize = true;
            this.lblTotalQty.ControlID = "";
            this.lblTotalQty.Location = new System.Drawing.Point(219, 586);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.PathString = null;
            this.lblTotalQty.PathValue = "Qty";
            this.lblTotalQty.Size = new System.Drawing.Size(34, 19);
            this.lblTotalQty.TabIndex = 232336;
            this.lblTotalQty.Text = "Qty";
            // 
            // evoLabel1
            // 
            this.evoLabel1.AppearanceName = "RequireText";
            this.evoLabel1.ControlID = "";
            this.evoLabel1.Location = new System.Drawing.Point(12, 104);
            this.evoLabel1.Name = "evoLabel1";
            this.evoLabel1.PathString = null;
            this.evoLabel1.PathValue = "*";
            this.evoLabel1.Size = new System.Drawing.Size(12, 32);
            this.evoLabel1.TabIndex = 232341;
            this.evoLabel1.Text = "*";
            this.evoLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // evoLabel2
            // 
            this.evoLabel2.AppearanceName = "";
            this.evoLabel2.ControlID = "";
            this.evoLabel2.Location = new System.Drawing.Point(644, 105);
            this.evoLabel2.Name = "evoLabel2";
            this.evoLabel2.PathString = null;
            this.evoLabel2.PathValue = "Currency";
            this.evoLabel2.Size = new System.Drawing.Size(76, 31);
            this.evoLabel2.TabIndex = 8;
            this.evoLabel2.Text = "Currency";
            this.evoLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboCurrency
            // 
            this.cboCurrency.AppearanceName = "";
            this.cboCurrency.AppearanceReadOnlyName = "";
            this.cboCurrency.BackColor = System.Drawing.Color.White;
            this.cboCurrency.ControlID = "";
            this.cboCurrency.DropDownHeight = 180;
            this.cboCurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboCurrency.ForeColor = System.Drawing.Color.Black;
            this.cboCurrency.FormattingEnabled = true;
            this.cboCurrency.IntegralHeight = false;
            this.cboCurrency.Location = new System.Drawing.Point(726, 106);
            this.cboCurrency.MaxLength = 200;
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.PathString = "CURRENCY.Value";
            this.cboCurrency.PathValue = null;
            this.cboCurrency.Size = new System.Drawing.Size(204, 28);
            this.cboCurrency.TabIndex = 2;
            this.cboCurrency.SelectedIndexChanged += new System.EventHandler(this.cboCurrency_SelectedIndexChanged);
            // 
            // fpCustomerOrderDetail
            // 
            this.fpCustomerOrderDetail.About = "2.5.2015.2005";
            this.fpCustomerOrderDetail.AccessibleDescription = "fpCustomerOrderDetail, SheetOrderDetail, Row 0, Column 0, ";
            this.fpCustomerOrderDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fpCustomerOrderDetail.BackColor = System.Drawing.Color.AliceBlue;
            this.fpCustomerOrderDetail.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpCustomerOrderDetail.EditModeReplace = true;
            this.fpCustomerOrderDetail.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpCustomerOrderDetail.Location = new System.Drawing.Point(10, 379);
            this.fpCustomerOrderDetail.Name = "fpCustomerOrderDetail";
            this.fpCustomerOrderDetail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpCustomerOrderDetail.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpCustomerOrderDetail.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpCustomerOrderDetail.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtCustomerOrderDetail});
            this.fpCustomerOrderDetail.Size = new System.Drawing.Size(923, 197);
            this.fpCustomerOrderDetail.TabIndex = 232342;
            this.fpCustomerOrderDetail.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never;
            this.fpCustomerOrderDetail.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpCustomerOrderDetail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpCustomerOrderDetail_KeyDown);
            // 
            // shtCustomerOrderDetail
            // 
            this.shtCustomerOrderDetail.Reset();
            this.shtCustomerOrderDetail.SheetName = "SheetOrderDetail";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtCustomerOrderDetail.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtCustomerOrderDetail.ColumnCount = 14;
            this.shtCustomerOrderDetail.RowCount = 6;
            this.shtCustomerOrderDetail.AutoGenerateColumns = false;
            this.shtCustomerOrderDetail.Cells.Get(0, 4).Value = "PartA";
            this.shtCustomerOrderDetail.Cells.Get(1, 4).Value = "PartB";
            this.shtCustomerOrderDetail.Cells.Get(2, 4).Value = "PartB";
            this.shtCustomerOrderDetail.Cells.Get(3, 4).Value = "PartC";
            this.shtCustomerOrderDetail.Cells.Get(4, 4).Value = "PartC";
            this.shtCustomerOrderDetail.Cells.Get(5, 4).Value = "PartC";
            this.shtCustomerOrderDetail.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.shtCustomerOrderDetail.ColumnHeader.Cells.Get(0, 0).Value = "Order No.";
            this.shtCustomerOrderDetail.ColumnHeader.Cells.Get(0, 1).Value = "Order Detail No.";
            this.shtCustomerOrderDetail.ColumnHeader.Cells.Get(0, 2).Value = "Trans ID";
            this.shtCustomerOrderDetail.ColumnHeader.Cells.Get(0, 3).Value = "M/N";
            this.shtCustomerOrderDetail.ColumnHeader.Cells.Get(0, 4).Value = "Part No.";
            this.shtCustomerOrderDetail.ColumnHeader.Cells.Get(0, 5).Value = "Pack Date";
            this.shtCustomerOrderDetail.ColumnHeader.Cells.Get(0, 6).Value = "Pack No.";
            this.shtCustomerOrderDetail.ColumnHeader.Cells.Get(0, 7).Value = "FG No.";
            this.shtCustomerOrderDetail.ColumnHeader.Cells.Get(0, 8).Value = "Lot No.";
            this.shtCustomerOrderDetail.ColumnHeader.Cells.Get(0, 9).Value = "Customer Lot No.";
            this.shtCustomerOrderDetail.ColumnHeader.Cells.Get(0, 10).Value = "Price";
            this.shtCustomerOrderDetail.ColumnHeader.Cells.Get(0, 11).Value = "Amount";
            this.shtCustomerOrderDetail.ColumnHeader.Cells.Get(0, 12).Value = "Lot Qty";
            this.shtCustomerOrderDetail.ColumnHeader.Cells.Get(0, 13).Value = "Return Qty";
            this.shtCustomerOrderDetail.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtCustomerOrderDetail.Columns.Get(0).Label = "Order No.";
            this.shtCustomerOrderDetail.Columns.Get(0).Visible = false;
            this.shtCustomerOrderDetail.Columns.Get(0).Width = 85F;
            this.shtCustomerOrderDetail.Columns.Get(1).Label = "Order Detail No.";
            this.shtCustomerOrderDetail.Columns.Get(1).Visible = false;
            this.shtCustomerOrderDetail.Columns.Get(1).Width = 130F;
            this.shtCustomerOrderDetail.Columns.Get(2).Label = "Trans ID";
            this.shtCustomerOrderDetail.Columns.Get(2).Visible = false;
            this.shtCustomerOrderDetail.Columns.Get(2).Width = 80F;
            this.shtCustomerOrderDetail.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.shtCustomerOrderDetail.Columns.Get(3).Label = "M/N";
            this.shtCustomerOrderDetail.Columns.Get(3).Tag = "Master No.";
            this.shtCustomerOrderDetail.Columns.Get(3).Width = 70F;
            this.shtCustomerOrderDetail.Columns.Get(4).Label = "Part No.";
            this.shtCustomerOrderDetail.Columns.Get(4).Tag = "Part No.";
            this.shtCustomerOrderDetail.Columns.Get(4).Width = 70F;
            this.shtCustomerOrderDetail.Columns.Get(5).Label = "Pack Date";
            this.shtCustomerOrderDetail.Columns.Get(5).Visible = false;
            this.shtCustomerOrderDetail.Columns.Get(5).Width = 80F;
            this.shtCustomerOrderDetail.Columns.Get(6).Label = "Pack No.";
            this.shtCustomerOrderDetail.Columns.Get(6).Tag = "Pack No.";
            this.shtCustomerOrderDetail.Columns.Get(6).Visible = false;
            this.shtCustomerOrderDetail.Columns.Get(6).Width = 90F;
            this.shtCustomerOrderDetail.Columns.Get(7).Label = "FG No.";
            this.shtCustomerOrderDetail.Columns.Get(7).Tag = "FG No.";
            this.shtCustomerOrderDetail.Columns.Get(7).Visible = false;
            this.shtCustomerOrderDetail.Columns.Get(7).Width = 102F;
            this.shtCustomerOrderDetail.Columns.Get(8).Label = "Lot No.";
            this.shtCustomerOrderDetail.Columns.Get(8).Tag = "Lot No.";
            this.shtCustomerOrderDetail.Columns.Get(8).Width = 90F;
            this.shtCustomerOrderDetail.Columns.Get(9).Label = "Customer Lot No.";
            this.shtCustomerOrderDetail.Columns.Get(9).Tag = "Customer Lot No.";
            this.shtCustomerOrderDetail.Columns.Get(9).Width = 120F;
            this.shtCustomerOrderDetail.Columns.Get(10).Label = "Price";
            this.shtCustomerOrderDetail.Columns.Get(10).Width = 100F;
            this.shtCustomerOrderDetail.Columns.Get(11).Label = "Amount";
            this.shtCustomerOrderDetail.Columns.Get(11).Width = 100F;
            this.shtCustomerOrderDetail.Columns.Get(12).CellType = numberCellType1;
            this.shtCustomerOrderDetail.Columns.Get(12).Label = "Lot Qty";
            this.shtCustomerOrderDetail.Columns.Get(12).Tag = "Lot Qty";
            this.shtCustomerOrderDetail.Columns.Get(12).Width = 90F;
            this.shtCustomerOrderDetail.Columns.Get(13).CellType = numberCellType2;
            this.shtCustomerOrderDetail.Columns.Get(13).Label = "Return Qty";
            this.shtCustomerOrderDetail.Columns.Get(13).Tag = "Lot Qty";
            this.shtCustomerOrderDetail.Columns.Get(13).Visible = false;
            this.shtCustomerOrderDetail.Columns.Get(13).Width = 90F;
            this.shtCustomerOrderDetail.DataAutoCellTypes = false;
            this.shtCustomerOrderDetail.DataAutoHeadings = false;
            this.shtCustomerOrderDetail.DataAutoSizeColumns = false;
            this.shtCustomerOrderDetail.RowHeader.Columns.Default.Resizable = true;
            this.shtCustomerOrderDetail.Rows.Get(1).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.shtCustomerOrderDetail.Rows.Get(2).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.shtCustomerOrderDetail.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // evoLabel3
            // 
            this.evoLabel3.AppearanceName = "RequireText";
            this.evoLabel3.ControlID = "";
            this.evoLabel3.Location = new System.Drawing.Point(174, 202);
            this.evoLabel3.Name = "evoLabel3";
            this.evoLabel3.PathString = null;
            this.evoLabel3.PathValue = "** Please choose Customer Code and Currency before click \"Add Order\" button.";
            this.evoLabel3.Size = new System.Drawing.Size(604, 32);
            this.evoLabel3.TabIndex = 232343;
            this.evoLabel3.Text = "** Please choose Customer Code and Currency before click \"Add Order\" button.";
            this.evoLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.txtQty.Location = new System.Drawing.Point(259, 582);
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
            this.txtQty.Size = new System.Drawing.Size(149, 27);
            this.txtQty.TabIndex = 232344;
            this.txtQty.Text = "0";
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAmount
            // 
            this.txtAmount.AllowNegative = true;
            this.txtAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAmount.AppearanceName = "";
            this.txtAmount.AppearanceReadOnlyName = "";
            this.txtAmount.BackColor = System.Drawing.SystemColors.Control;
            this.txtAmount.ControlID = "";
            this.txtAmount.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtAmount.DecimalPoint = '.';
            this.txtAmount.DigitsInGroup = 3;
            this.txtAmount.Double = 0D;
            this.txtAmount.FixDecimalPosition = true;
            this.txtAmount.Flags = 0;
            this.txtAmount.GroupSeparator = ',';
            this.txtAmount.Int = 0;
            this.txtAmount.Location = new System.Drawing.Point(562, 582);
            this.txtAmount.Long = ((long)(0));
            this.txtAmount.MaxDecimalPlaces = 4;
            this.txtAmount.MaxWholeDigits = 9;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.NegativeSign = '-';
            this.txtAmount.PathString = "TOTAL_AMOUNT.Value";
            this.txtAmount.PathValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtAmount.Prefix = "";
            this.txtAmount.RangeMax = 1.7976931348623157E+308D;
            this.txtAmount.RangeMin = -1.7976931348623157E+308D;
            this.txtAmount.Size = new System.Drawing.Size(149, 27);
            this.txtAmount.TabIndex = 232345;
            this.txtAmount.Text = "0";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // evoLabel5
            // 
            this.evoLabel5.AppearanceName = "RequireText";
            this.evoLabel5.ControlID = "";
            this.evoLabel5.Location = new System.Drawing.Point(626, 104);
            this.evoLabel5.Name = "evoLabel5";
            this.evoLabel5.PathString = null;
            this.evoLabel5.PathValue = "*";
            this.evoLabel5.Size = new System.Drawing.Size(12, 32);
            this.evoLabel5.TabIndex = 232346;
            this.evoLabel5.Text = "*";
            this.evoLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // evoLabel6
            // 
            this.evoLabel6.AppearanceName = "RequireText";
            this.evoLabel6.ControlID = "";
            this.evoLabel6.Location = new System.Drawing.Point(503, 37);
            this.evoLabel6.Name = "evoLabel6";
            this.evoLabel6.PathString = null;
            this.evoLabel6.PathValue = "*";
            this.evoLabel6.Size = new System.Drawing.Size(12, 32);
            this.evoLabel6.TabIndex = 232347;
            this.evoLabel6.Text = "*";
            this.evoLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // evoLabel7
            // 
            this.evoLabel7.AppearanceName = "";
            this.evoLabel7.ControlID = "";
            this.evoLabel7.Location = new System.Drawing.Point(626, 138);
            this.evoLabel7.Name = "evoLabel7";
            this.evoLabel7.PathString = null;
            this.evoLabel7.PathValue = "Invoice No.";
            this.evoLabel7.Size = new System.Drawing.Size(101, 31);
            this.evoLabel7.TabIndex = 8;
            this.evoLabel7.Text = "Invoice No.";
            this.evoLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.AppearanceName = "";
            this.txtInvoiceNo.AppearanceReadOnlyName = "";
            this.txtInvoiceNo.ControlID = "";
            this.txtInvoiceNo.DisableRestrictChar = false;
            this.txtInvoiceNo.HelpButton = null;
            this.txtInvoiceNo.Location = new System.Drawing.Point(726, 140);
            this.txtInvoiceNo.MaxLength = 30;
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.PathString = "REF_SLIP_NO2.Value";
            this.txtInvoiceNo.PathValue = "";
            this.txtInvoiceNo.Size = new System.Drawing.Size(204, 27);
            this.txtInvoiceNo.TabIndex = 4;
            // 
            // TRN100_DeliveryEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(942, 666);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TRN100_DeliveryEntry";
            this.Text = "Delivery Entry";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TRN100_DeliveryEntry_FormClosed);
            this.Load += new System.EventHandler(this.TRN100_Load);
            this.Controls.SetChildIndex(this.pnlContainer, 0);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.cmsOperation.ResumeLayout(false);
            this.evoPanel1.ResumeLayout(false);
            this.evoPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpCustomerOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtCustomerOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpCustomerOrderDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtCustomerOrderDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EVOFramework.Windows.Forms.EVOPanel evoPanel1;
        private EVOFramework.Windows.Forms.EVOLabel label7;
        private EVOFramework.Windows.Forms.EVOLabel lblShipmentNo;
        private EVOFramework.Windows.Forms.EVOLabel lblShipDate;
        private EVOFramework.Windows.Forms.EVOLabel lblDeliveryNo;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtDeliveryDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private EVOFramework.Windows.Forms.EVOLabel lblShipInformation;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel4;
        private EVOFramework.Windows.Forms.EVOLabel lblFromLoc;
        private EVOFramework.Windows.Forms.EVOComboBox cboFromLoc;
        private EVOFramework.Windows.Forms.EVOTextBox txtRemark;
        private EVOFramework.Windows.Forms.EVOLabel lblRemark;
        private EVOFramework.Data.UIDataModelController dmcShip;
        private System.Windows.Forms.ContextMenuStrip cmsOperation;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private EVOFramework.Windows.Forms.EVOComboBox cboCustomerCode;
        private EVOFramework.Windows.Forms.EVOLabel lblCustomerCode;
        private System.Windows.Forms.Button btnAddOrder;
        private FarPoint.Win.Spread.FpSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView shtCustomerOrder;
        private FarPoint.Win.Spread.FpSpread fpCustomerOrder;
        private EVOFramework.Windows.Forms.EVOLabel lblGrandTotal;
        private EVOFramework.Windows.Forms.EVOLabel lblTotalAmount;
        private EVOFramework.Windows.Forms.EVOLabel lblTotalQty;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel1;
        private EVOFramework.Windows.Forms.EVOComboBox cboCurrency;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel2;
        private FarPoint.Win.Spread.FpSpread fpCustomerOrderDetail;
        private FarPoint.Win.Spread.SheetView shtCustomerOrderDetail;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel3;
        private EVOFramework.Windows.Forms.EVONumericTextBox txtAmount;
        private EVOFramework.Windows.Forms.EVONumericTextBox txtQty;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel5;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel6;
        private EVOFramework.Windows.Forms.EVOTextBox txtInvoiceNo;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel7;

    }
}
