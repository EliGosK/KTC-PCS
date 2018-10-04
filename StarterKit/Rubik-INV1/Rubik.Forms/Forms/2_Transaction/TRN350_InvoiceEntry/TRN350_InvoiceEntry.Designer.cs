namespace Rubik.Transaction
{
    partial class TRN350_InvoiceEntry
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
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TRN350_InvoiceEntry));
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.lbInvoiceInformation = new EVOFramework.Windows.Forms.EVOLabel();
            this.cmsOperation = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtRemark = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblRemark = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboCustomerCode = new EVOFramework.Windows.Forms.EVOComboBox();
            this.lblCustomerCode = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoPanel1 = new EVOFramework.Windows.Forms.EVOPanel();
            this.label7 = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblShipmentNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.lbInvoiceDate = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblTransactionNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.dtInvoiceDate = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.dmcShip = new EVOFramework.Data.UIDataModelController(this.components);
            this.fpCustomerOrder = new FarPoint.Win.Spread.FpSpread();
            this.shtCustomerOrder = new FarPoint.Win.Spread.SheetView();
            this.lblAmount = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblTotalQty = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtSubTotal = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.txtTotal = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.evoLabel6 = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblInvoiceNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtInvoiceNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.evoLabel7 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel8 = new EVOFramework.Windows.Forms.EVOLabel();
            this.dtPaymentDueDate = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.lblPaymentDueDate = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboTermOfPayment = new EVOFramework.Windows.Forms.EVOComboBox();
            this.lblTermOfPayment = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel9 = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblAddress = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel10 = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboAddress = new EVOFramework.Windows.Forms.EVOComboBox();
            this.txtFullAddress = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblReferTemNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtReferTemNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblDeliveryNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtDeliveryNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.evoLabel2 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtVat = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.txtVatTotal = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.chkCancelInvoice = new EVOFramework.Windows.Forms.EVOCheckBox();
            this.btnReIssue = new EVOFramework.Windows.Forms.EVOButton();
            this.evoLabel3 = new EVOFramework.Windows.Forms.EVOLabel();
            this.btnDeliveryNo = new EVOFramework.Windows.Forms.EVOButton();
            this.pnlContainer.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.cmsOperation.SuspendLayout();
            this.evoPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpCustomerOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtCustomerOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.btnDeliveryNo);
            this.pnlContainer.Controls.Add(this.btnReIssue);
            this.pnlContainer.Controls.Add(this.chkCancelInvoice);
            this.pnlContainer.Controls.Add(this.txtDeliveryNo);
            this.pnlContainer.Controls.Add(this.txtFullAddress);
            this.pnlContainer.Controls.Add(this.evoLabel9);
            this.pnlContainer.Controls.Add(this.lblTermOfPayment);
            this.pnlContainer.Controls.Add(this.cboAddress);
            this.pnlContainer.Controls.Add(this.cboTermOfPayment);
            this.pnlContainer.Controls.Add(this.evoLabel8);
            this.pnlContainer.Controls.Add(this.dtPaymentDueDate);
            this.pnlContainer.Controls.Add(this.lblPaymentDueDate);
            this.pnlContainer.Controls.Add(this.evoLabel7);
            this.pnlContainer.Controls.Add(this.txtInvoiceNo);
            this.pnlContainer.Controls.Add(this.lblInvoiceNo);
            this.pnlContainer.Controls.Add(this.evoLabel6);
            this.pnlContainer.Controls.Add(this.txtTotal);
            this.pnlContainer.Controls.Add(this.txtVat);
            this.pnlContainer.Controls.Add(this.txtVatTotal);
            this.pnlContainer.Controls.Add(this.txtSubTotal);
            this.pnlContainer.Controls.Add(this.evoLabel10);
            this.pnlContainer.Controls.Add(this.evoLabel1);
            this.pnlContainer.Controls.Add(this.evoLabel3);
            this.pnlContainer.Controls.Add(this.evoLabel2);
            this.pnlContainer.Controls.Add(this.lblAmount);
            this.pnlContainer.Controls.Add(this.lblTotalQty);
            this.pnlContainer.Controls.Add(this.fpCustomerOrder);
            this.pnlContainer.Controls.Add(this.tableLayoutPanel7);
            this.pnlContainer.Controls.Add(this.txtReferTemNo);
            this.pnlContainer.Controls.Add(this.txtRemark);
            this.pnlContainer.Controls.Add(this.lblReferTemNo);
            this.pnlContainer.Controls.Add(this.lblRemark);
            this.pnlContainer.Controls.Add(this.evoPanel1);
            this.pnlContainer.Controls.Add(this.dtInvoiceDate);
            this.pnlContainer.Controls.Add(this.lblTransactionNo);
            this.pnlContainer.Controls.Add(this.cboCustomerCode);
            this.pnlContainer.Controls.Add(this.lbInvoiceDate);
            this.pnlContainer.Controls.Add(this.lblAddress);
            this.pnlContainer.Controls.Add(this.lblCustomerCode);
            this.pnlContainer.Controls.Add(this.lblDeliveryNo);
            this.pnlContainer.Controls.Add(this.lblShipmentNo);
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlContainer.Size = new System.Drawing.Size(942, 600);
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel7.BackgroundImage")));
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.Controls.Add(this.lbInvoiceInformation, 0, 0);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(7, 67);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(923, 23);
            this.tableLayoutPanel7.TabIndex = 12;
            // 
            // lbInvoiceInformation
            // 
            this.lbInvoiceInformation.AppearanceName = "Header";
            this.lbInvoiceInformation.AutoSize = true;
            this.lbInvoiceInformation.ControlID = "";
            this.lbInvoiceInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbInvoiceInformation.ForeColor = System.Drawing.Color.Navy;
            this.lbInvoiceInformation.Location = new System.Drawing.Point(0, 0);
            this.lbInvoiceInformation.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lbInvoiceInformation.Name = "lbInvoiceInformation";
            this.lbInvoiceInformation.PathString = null;
            this.lbInvoiceInformation.PathValue = "Invoice Information";
            this.lbInvoiceInformation.Size = new System.Drawing.Size(167, 23);
            this.lbInvoiceInformation.TabIndex = 0;
            this.lbInvoiceInformation.Text = "Invoice Information";
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
            this.txtRemark.Location = new System.Drawing.Point(143, 261);
            this.txtRemark.MaxLength = 255;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.PathString = "REMARK.Value";
            this.txtRemark.PathValue = "";
            this.txtRemark.Size = new System.Drawing.Size(786, 26);
            this.txtRemark.TabIndex = 4;
            this.txtRemark.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRemark_KeyPress);
            // 
            // lblRemark
            // 
            this.lblRemark.AppearanceName = "";
            this.lblRemark.ControlID = "";
            this.lblRemark.Location = new System.Drawing.Point(17, 261);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.PathString = null;
            this.lblRemark.PathValue = "Remark";
            this.lblRemark.Size = new System.Drawing.Size(93, 26);
            this.lblRemark.TabIndex = 8;
            this.lblRemark.Text = "Remark";
            this.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboCustomerCode
            // 
            this.cboCustomerCode.AppearanceName = "";
            this.cboCustomerCode.AppearanceReadOnlyName = "";
            this.cboCustomerCode.ControlID = "";
            this.cboCustomerCode.DropDownHeight = 180;
            this.cboCustomerCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboCustomerCode.ForeColor = System.Drawing.Color.Black;
            this.cboCustomerCode.FormattingEnabled = true;
            this.cboCustomerCode.IntegralHeight = false;
            this.cboCustomerCode.Location = new System.Drawing.Point(143, 97);
            this.cboCustomerCode.MaxLength = 200;
            this.cboCustomerCode.Name = "cboCustomerCode";
            this.cboCustomerCode.PathString = "CUSTOMER_CD.Value";
            this.cboCustomerCode.PathValue = null;
            this.cboCustomerCode.ReadOnly = true;
            this.cboCustomerCode.Size = new System.Drawing.Size(322, 28);
            this.cboCustomerCode.TabIndex = 1;
            this.cboCustomerCode.SelectedIndexChanged += new System.EventHandler(this.cboCustomerCode_SelectedIndexChanged);
            // 
            // lblCustomerCode
            // 
            this.lblCustomerCode.AppearanceName = "";
            this.lblCustomerCode.ControlID = "";
            this.lblCustomerCode.Location = new System.Drawing.Point(42, 97);
            this.lblCustomerCode.Name = "lblCustomerCode";
            this.lblCustomerCode.PathString = null;
            this.lblCustomerCode.PathValue = "Customer";
            this.lblCustomerCode.Size = new System.Drawing.Size(93, 28);
            this.lblCustomerCode.TabIndex = 8;
            this.lblCustomerCode.Text = "Customer";
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
            this.label7.PathValue = "Invoice Entry";
            this.label7.Size = new System.Drawing.Size(231, 39);
            this.label7.TabIndex = 37;
            this.label7.Text = "Invoice Entry";
            // 
            // lblShipmentNo
            // 
            this.lblShipmentNo.AppearanceName = "";
            this.lblShipmentNo.ControlID = "";
            this.lblShipmentNo.Location = new System.Drawing.Point(576, 4);
            this.lblShipmentNo.Name = "lblShipmentNo";
            this.lblShipmentNo.PathString = null;
            this.lblShipmentNo.PathValue = "Transaction No.";
            this.lblShipmentNo.Size = new System.Drawing.Size(137, 28);
            this.lblShipmentNo.TabIndex = 1;
            this.lblShipmentNo.Text = "Transaction No.";
            this.lblShipmentNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbInvoiceDate
            // 
            this.lbInvoiceDate.AppearanceName = "";
            this.lbInvoiceDate.ControlID = "";
            this.lbInvoiceDate.Location = new System.Drawing.Point(576, 128);
            this.lbInvoiceDate.Name = "lbInvoiceDate";
            this.lbInvoiceDate.PathString = null;
            this.lbInvoiceDate.PathValue = "Invoice Date";
            this.lbInvoiceDate.Size = new System.Drawing.Size(112, 29);
            this.lbInvoiceDate.TabIndex = 2;
            this.lbInvoiceDate.Text = "Invoice Date";
            this.lbInvoiceDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTransactionNo
            // 
            this.lblTransactionNo.AppearanceName = "";
            this.lblTransactionNo.ControlID = "";
            this.lblTransactionNo.Location = new System.Drawing.Point(728, 4);
            this.lblTransactionNo.Name = "lblTransactionNo";
            this.lblTransactionNo.PathString = "BILL_NO.Value";
            this.lblTransactionNo.PathValue = "";
            this.lblTransactionNo.Size = new System.Drawing.Size(200, 28);
            this.lblTransactionNo.TabIndex = 1;
            this.lblTransactionNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtInvoiceDate
            // 
            this.dtInvoiceDate.AppearanceName = "";
            this.dtInvoiceDate.AppearanceReadOnlyName = "";
            this.dtInvoiceDate.BackColor = System.Drawing.Color.Transparent;
            this.dtInvoiceDate.ControlID = "";
            this.dtInvoiceDate.Format = "dd/MM/yyyy";
            this.dtInvoiceDate.Location = new System.Drawing.Point(730, 129);
            this.dtInvoiceDate.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtInvoiceDate.Name = "dtInvoiceDate";
            this.dtInvoiceDate.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtInvoiceDate.NZValue")));
            this.dtInvoiceDate.PathString = "INVOICE_DATE.Value";
            this.dtInvoiceDate.PathValue = ((object)(resources.GetObject("dtInvoiceDate.PathValue")));
            this.dtInvoiceDate.ReadOnly = false;
            this.dtInvoiceDate.ShowButton = true;
            this.dtInvoiceDate.Size = new System.Drawing.Size(200, 20);
            this.dtInvoiceDate.TabIndex = 0;
            this.dtInvoiceDate.Value = null;
            // 
            // fpCustomerOrder
            // 
            this.fpCustomerOrder.About = "2.5.2015.2005";
            this.fpCustomerOrder.AccessibleDescription = "fpCustomerOrder, SheetCustomerOrder, Row 0, Column 0, ";
            this.fpCustomerOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fpCustomerOrder.BackColor = System.Drawing.Color.AliceBlue;
            this.fpCustomerOrder.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpCustomerOrder.ContextMenuStrip = this.cmsOperation;
            this.fpCustomerOrder.EditModeReplace = true;
            this.fpCustomerOrder.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpCustomerOrder.Location = new System.Drawing.Point(11, 293);
            this.fpCustomerOrder.Name = "fpCustomerOrder";
            this.fpCustomerOrder.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpCustomerOrder.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpCustomerOrder.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpCustomerOrder.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtCustomerOrder});
            this.fpCustomerOrder.Size = new System.Drawing.Size(919, 192);
            this.fpCustomerOrder.TabIndex = 6;
            this.fpCustomerOrder.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never;
            this.fpCustomerOrder.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpCustomerOrder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpCustomerOrder_KeyDown);
            this.fpCustomerOrder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fpCustomerOrder_MouseDown);
            // 
            // shtCustomerOrder
            // 
            this.shtCustomerOrder.Reset();
            this.shtCustomerOrder.SheetName = "SheetCustomerOrder";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtCustomerOrder.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtCustomerOrder.ColumnCount = 11;
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
            this.shtCustomerOrder.ColumnHeader.Cells.Get(0, 5).Value = "Part Description";
            this.shtCustomerOrder.ColumnHeader.Cells.Get(0, 6).Value = "Unit";
            this.shtCustomerOrder.ColumnHeader.Cells.Get(0, 7).Value = "Delivery Qty";
            this.shtCustomerOrder.ColumnHeader.Cells.Get(0, 8).Value = "Unit Price";
            this.shtCustomerOrder.ColumnHeader.Cells.Get(0, 9).Value = "Amount";
            this.shtCustomerOrder.ColumnHeader.Cells.Get(0, 10).Value = "TransID";
            this.shtCustomerOrder.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtCustomerOrder.Columns.Get(0).Label = "PO No.";
            this.shtCustomerOrder.Columns.Get(0).Tag = "PO No.";
            this.shtCustomerOrder.Columns.Get(0).Width = 91F;
            this.shtCustomerOrder.Columns.Get(1).CellType = textCellType1;
            this.shtCustomerOrder.Columns.Get(1).Label = "Order No.";
            this.shtCustomerOrder.Columns.Get(1).Tag = "Order No.";
            this.shtCustomerOrder.Columns.Get(1).Width = 84F;
            this.shtCustomerOrder.Columns.Get(2).Label = "Order Detail No";
            this.shtCustomerOrder.Columns.Get(2).Tag = "Order Detail No";
            this.shtCustomerOrder.Columns.Get(2).Width = 83F;
            this.shtCustomerOrder.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.shtCustomerOrder.Columns.Get(3).Label = "M/N";
            this.shtCustomerOrder.Columns.Get(3).Tag = "M/N";
            this.shtCustomerOrder.Columns.Get(3).Width = 70F;
            this.shtCustomerOrder.Columns.Get(4).Label = "Part No.";
            this.shtCustomerOrder.Columns.Get(4).Tag = "Part No.";
            this.shtCustomerOrder.Columns.Get(4).Width = 70F;
            this.shtCustomerOrder.Columns.Get(5).Label = "Part Description";
            this.shtCustomerOrder.Columns.Get(5).Tag = "Part Description";
            this.shtCustomerOrder.Columns.Get(5).Width = 149F;
            this.shtCustomerOrder.Columns.Get(6).Label = "Unit";
            this.shtCustomerOrder.Columns.Get(6).Tag = "Unit";
            this.shtCustomerOrder.Columns.Get(7).CellType = numberCellType1;
            this.shtCustomerOrder.Columns.Get(7).Label = "Delivery Qty";
            this.shtCustomerOrder.Columns.Get(7).Tag = "Delivery Qty";
            this.shtCustomerOrder.Columns.Get(7).Width = 70F;
            this.shtCustomerOrder.Columns.Get(8).Label = "Unit Price";
            this.shtCustomerOrder.Columns.Get(8).Tag = "Unit Price";
            this.shtCustomerOrder.Columns.Get(8).Width = 70F;
            this.shtCustomerOrder.Columns.Get(9).Label = "Amount";
            this.shtCustomerOrder.Columns.Get(9).Tag = "Amount";
            this.shtCustomerOrder.Columns.Get(9).Width = 70F;
            this.shtCustomerOrder.Columns.Get(10).Label = "TransID";
            this.shtCustomerOrder.Columns.Get(10).Tag = "TransID";
            this.shtCustomerOrder.Columns.Get(10).Visible = false;
            this.shtCustomerOrder.Columns.Get(10).Width = 86F;
            this.shtCustomerOrder.DataAutoCellTypes = false;
            this.shtCustomerOrder.DataAutoHeadings = false;
            this.shtCustomerOrder.DataAutoSizeColumns = false;
            this.shtCustomerOrder.RowHeader.Columns.Default.Resizable = true;
            this.shtCustomerOrder.Rows.Get(1).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.shtCustomerOrder.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // lblAmount
            // 
            this.lblAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAmount.AppearanceName = "";
            this.lblAmount.AutoSize = true;
            this.lblAmount.ControlID = "";
            this.lblAmount.Location = new System.Drawing.Point(642, 561);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.PathString = null;
            this.lblAmount.PathValue = "Total";
            this.lblAmount.Size = new System.Drawing.Size(45, 19);
            this.lblAmount.TabIndex = 232337;
            this.lblAmount.Text = "Total";
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalQty.AppearanceName = "";
            this.lblTotalQty.AutoSize = true;
            this.lblTotalQty.ControlID = "";
            this.lblTotalQty.Location = new System.Drawing.Point(642, 495);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.PathString = null;
            this.lblTotalQty.PathValue = "Sub Total";
            this.lblTotalQty.Size = new System.Drawing.Size(77, 19);
            this.lblTotalQty.TabIndex = 232336;
            this.lblTotalQty.Text = "Sub Total";
            // 
            // evoLabel1
            // 
            this.evoLabel1.AppearanceName = "RequireText";
            this.evoLabel1.ControlID = "";
            this.evoLabel1.Location = new System.Drawing.Point(20, 97);
            this.evoLabel1.Name = "evoLabel1";
            this.evoLabel1.PathString = null;
            this.evoLabel1.PathValue = "*";
            this.evoLabel1.Size = new System.Drawing.Size(16, 28);
            this.evoLabel1.TabIndex = 232341;
            this.evoLabel1.Text = "*";
            this.evoLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.AllowNegative = true;
            this.txtSubTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubTotal.AppearanceName = "";
            this.txtSubTotal.AppearanceReadOnlyName = "";
            this.txtSubTotal.ControlID = "";
            this.txtSubTotal.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSubTotal.DecimalPoint = '.';
            this.txtSubTotal.DigitsInGroup = 3;
            this.txtSubTotal.Double = 0D;
            this.txtSubTotal.FixDecimalPosition = true;
            this.txtSubTotal.Flags = 0;
            this.txtSubTotal.GroupSeparator = ',';
            this.txtSubTotal.Int = 0;
            this.txtSubTotal.Location = new System.Drawing.Point(732, 491);
            this.txtSubTotal.Long = ((long)(0));
            this.txtSubTotal.MaxDecimalPlaces = 4;
            this.txtSubTotal.MaxWholeDigits = 9;
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.NegativeSign = '-';
            this.txtSubTotal.PathString = "SUB_TOTAL.Value";
            this.txtSubTotal.PathValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSubTotal.Prefix = "";
            this.txtSubTotal.RangeMax = 1.7976931348623157E+308D;
            this.txtSubTotal.RangeMin = -1.7976931348623157E+308D;
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.Size = new System.Drawing.Size(197, 27);
            this.txtSubTotal.TabIndex = 232344;
            this.txtSubTotal.Text = "0";
            this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotal
            // 
            this.txtTotal.AllowNegative = true;
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.AppearanceName = "";
            this.txtTotal.AppearanceReadOnlyName = "";
            this.txtTotal.ControlID = "";
            this.txtTotal.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotal.DecimalPoint = '.';
            this.txtTotal.DigitsInGroup = 3;
            this.txtTotal.Double = 0D;
            this.txtTotal.FixDecimalPosition = true;
            this.txtTotal.Flags = 0;
            this.txtTotal.GroupSeparator = ',';
            this.txtTotal.Int = 0;
            this.txtTotal.Location = new System.Drawing.Point(732, 557);
            this.txtTotal.Long = ((long)(0));
            this.txtTotal.MaxDecimalPlaces = 4;
            this.txtTotal.MaxWholeDigits = 9;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.NegativeSign = '-';
            this.txtTotal.PathString = "TOTAL.Value";
            this.txtTotal.PathValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotal.Prefix = "";
            this.txtTotal.RangeMax = 1.7976931348623157E+308D;
            this.txtTotal.RangeMin = -1.7976931348623157E+308D;
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(196, 27);
            this.txtTotal.TabIndex = 232345;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // evoLabel6
            // 
            this.evoLabel6.AppearanceName = "RequireText";
            this.evoLabel6.ControlID = "";
            this.evoLabel6.Location = new System.Drawing.Point(552, 127);
            this.evoLabel6.Name = "evoLabel6";
            this.evoLabel6.PathString = null;
            this.evoLabel6.PathValue = "*";
            this.evoLabel6.Size = new System.Drawing.Size(16, 30);
            this.evoLabel6.TabIndex = 232347;
            this.evoLabel6.Text = "*";
            this.evoLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.AppearanceName = "";
            this.lblInvoiceNo.ControlID = "";
            this.lblInvoiceNo.Location = new System.Drawing.Point(576, 95);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.PathString = null;
            this.lblInvoiceNo.PathValue = "Invoice No.";
            this.lblInvoiceNo.Size = new System.Drawing.Size(112, 29);
            this.lblInvoiceNo.TabIndex = 232348;
            this.lblInvoiceNo.Text = "Invoice No.";
            this.lblInvoiceNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.AppearanceName = "";
            this.txtInvoiceNo.AppearanceReadOnlyName = "";
            this.txtInvoiceNo.ControlID = "";
            this.txtInvoiceNo.DisableRestrictChar = false;
            this.txtInvoiceNo.HelpButton = null;
            this.txtInvoiceNo.Location = new System.Drawing.Point(730, 96);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.PathString = "INVOICE_NO.Value";
            this.txtInvoiceNo.PathValue = "";
            this.txtInvoiceNo.Size = new System.Drawing.Size(200, 27);
            this.txtInvoiceNo.TabIndex = 232349;
            // 
            // evoLabel7
            // 
            this.evoLabel7.AppearanceName = "RequireText";
            this.evoLabel7.ControlID = "";
            this.evoLabel7.Location = new System.Drawing.Point(552, 94);
            this.evoLabel7.Name = "evoLabel7";
            this.evoLabel7.PathString = null;
            this.evoLabel7.PathValue = "*";
            this.evoLabel7.Size = new System.Drawing.Size(16, 30);
            this.evoLabel7.TabIndex = 232350;
            this.evoLabel7.Text = "*";
            this.evoLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // evoLabel8
            // 
            this.evoLabel8.AppearanceName = "RequireText";
            this.evoLabel8.ControlID = "";
            this.evoLabel8.Location = new System.Drawing.Point(552, 193);
            this.evoLabel8.Name = "evoLabel8";
            this.evoLabel8.PathString = null;
            this.evoLabel8.PathValue = "*";
            this.evoLabel8.Size = new System.Drawing.Size(16, 30);
            this.evoLabel8.TabIndex = 232353;
            this.evoLabel8.Text = "*";
            this.evoLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtPaymentDueDate
            // 
            this.dtPaymentDueDate.AppearanceName = "";
            this.dtPaymentDueDate.AppearanceReadOnlyName = "";
            this.dtPaymentDueDate.BackColor = System.Drawing.Color.Transparent;
            this.dtPaymentDueDate.ControlID = "";
            this.dtPaymentDueDate.Format = "dd/MM/yyyy";
            this.dtPaymentDueDate.Location = new System.Drawing.Point(730, 196);
            this.dtPaymentDueDate.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtPaymentDueDate.Name = "dtPaymentDueDate";
            this.dtPaymentDueDate.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtPaymentDueDate.NZValue")));
            this.dtPaymentDueDate.PathString = "PAYMENT_DUE_DATE.Value";
            this.dtPaymentDueDate.PathValue = ((object)(resources.GetObject("dtPaymentDueDate.PathValue")));
            this.dtPaymentDueDate.ReadOnly = false;
            this.dtPaymentDueDate.ShowButton = true;
            this.dtPaymentDueDate.Size = new System.Drawing.Size(200, 20);
            this.dtPaymentDueDate.TabIndex = 232351;
            this.dtPaymentDueDate.Value = null;
            // 
            // lblPaymentDueDate
            // 
            this.lblPaymentDueDate.AppearanceName = "";
            this.lblPaymentDueDate.ControlID = "";
            this.lblPaymentDueDate.Location = new System.Drawing.Point(577, 195);
            this.lblPaymentDueDate.Name = "lblPaymentDueDate";
            this.lblPaymentDueDate.PathString = null;
            this.lblPaymentDueDate.PathValue = "Payment Due Date";
            this.lblPaymentDueDate.Size = new System.Drawing.Size(147, 29);
            this.lblPaymentDueDate.TabIndex = 232352;
            this.lblPaymentDueDate.Text = "Payment Due Date";
            this.lblPaymentDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboTermOfPayment
            // 
            this.cboTermOfPayment.AppearanceName = "";
            this.cboTermOfPayment.AppearanceReadOnlyName = "";
            this.cboTermOfPayment.ControlID = "";
            this.cboTermOfPayment.DropDownHeight = 180;
            this.cboTermOfPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboTermOfPayment.ForeColor = System.Drawing.Color.Black;
            this.cboTermOfPayment.FormattingEnabled = true;
            this.cboTermOfPayment.IntegralHeight = false;
            this.cboTermOfPayment.Location = new System.Drawing.Point(730, 162);
            this.cboTermOfPayment.MaxLength = 200;
            this.cboTermOfPayment.Name = "cboTermOfPayment";
            this.cboTermOfPayment.PathString = "TERM_OF_PAYMENT.Value";
            this.cboTermOfPayment.PathValue = null;
            this.cboTermOfPayment.ReadOnly = true;
            this.cboTermOfPayment.Size = new System.Drawing.Size(200, 28);
            this.cboTermOfPayment.TabIndex = 232354;
            // 
            // lblTermOfPayment
            // 
            this.lblTermOfPayment.AppearanceName = "";
            this.lblTermOfPayment.ControlID = "";
            this.lblTermOfPayment.Location = new System.Drawing.Point(575, 162);
            this.lblTermOfPayment.Name = "lblTermOfPayment";
            this.lblTermOfPayment.PathString = null;
            this.lblTermOfPayment.PathValue = "Term Of Payment";
            this.lblTermOfPayment.Size = new System.Drawing.Size(135, 29);
            this.lblTermOfPayment.TabIndex = 232355;
            this.lblTermOfPayment.Text = "Term Of Payment";
            this.lblTermOfPayment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // evoLabel9
            // 
            this.evoLabel9.AppearanceName = "RequireText";
            this.evoLabel9.ControlID = "";
            this.evoLabel9.Location = new System.Drawing.Point(552, 159);
            this.evoLabel9.Name = "evoLabel9";
            this.evoLabel9.PathString = null;
            this.evoLabel9.PathValue = "*";
            this.evoLabel9.Size = new System.Drawing.Size(16, 30);
            this.evoLabel9.TabIndex = 232356;
            this.evoLabel9.Text = "*";
            this.evoLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAddress
            // 
            this.lblAddress.AppearanceName = "";
            this.lblAddress.ControlID = "";
            this.lblAddress.Location = new System.Drawing.Point(42, 129);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.PathString = null;
            this.lblAddress.PathValue = "Address";
            this.lblAddress.Size = new System.Drawing.Size(93, 28);
            this.lblAddress.TabIndex = 8;
            this.lblAddress.Text = "Address";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // evoLabel10
            // 
            this.evoLabel10.AppearanceName = "RequireText";
            this.evoLabel10.ControlID = "";
            this.evoLabel10.Location = new System.Drawing.Point(20, 129);
            this.evoLabel10.Name = "evoLabel10";
            this.evoLabel10.PathString = null;
            this.evoLabel10.PathValue = "*";
            this.evoLabel10.Size = new System.Drawing.Size(16, 28);
            this.evoLabel10.TabIndex = 232341;
            this.evoLabel10.Text = "*";
            this.evoLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboAddress
            // 
            this.cboAddress.AppearanceName = "";
            this.cboAddress.AppearanceReadOnlyName = "";
            this.cboAddress.BackColor = System.Drawing.Color.White;
            this.cboAddress.ControlID = "";
            this.cboAddress.DropDownHeight = 180;
            this.cboAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboAddress.ForeColor = System.Drawing.Color.Black;
            this.cboAddress.FormattingEnabled = true;
            this.cboAddress.IntegralHeight = false;
            this.cboAddress.Location = new System.Drawing.Point(471, 97);
            this.cboAddress.MaxLength = 200;
            this.cboAddress.Name = "cboAddress";
            this.cboAddress.PathString = "";
            this.cboAddress.PathValue = null;
            this.cboAddress.Size = new System.Drawing.Size(48, 28);
            this.cboAddress.TabIndex = 232354;
            // 
            // txtFullAddress
            // 
            this.txtFullAddress.AppearanceName = "";
            this.txtFullAddress.AppearanceReadOnlyName = "";
            this.txtFullAddress.ControlID = "";
            this.txtFullAddress.DisableRestrictChar = false;
            this.txtFullAddress.HelpButton = null;
            this.txtFullAddress.Location = new System.Drawing.Point(143, 130);
            this.txtFullAddress.Multiline = true;
            this.txtFullAddress.Name = "txtFullAddress";
            this.txtFullAddress.PathString = "ADDRESS.Value";
            this.txtFullAddress.PathValue = "";
            this.txtFullAddress.ReadOnly = true;
            this.txtFullAddress.Size = new System.Drawing.Size(376, 93);
            this.txtFullAddress.TabIndex = 232357;
            // 
            // lblReferTemNo
            // 
            this.lblReferTemNo.AppearanceName = "";
            this.lblReferTemNo.ControlID = "";
            this.lblReferTemNo.Location = new System.Drawing.Point(17, 229);
            this.lblReferTemNo.Name = "lblReferTemNo";
            this.lblReferTemNo.PathString = null;
            this.lblReferTemNo.PathValue = "Refer Tem No.";
            this.lblReferTemNo.Size = new System.Drawing.Size(120, 26);
            this.lblReferTemNo.TabIndex = 8;
            this.lblReferTemNo.Text = "Refer Tem No.";
            this.lblReferTemNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtReferTemNo
            // 
            this.txtReferTemNo.AppearanceName = "";
            this.txtReferTemNo.AppearanceReadOnlyName = "";
            this.txtReferTemNo.BackColor = System.Drawing.Color.White;
            this.txtReferTemNo.ControlID = "";
            this.txtReferTemNo.DisableRestrictChar = false;
            this.txtReferTemNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtReferTemNo.ForeColor = System.Drawing.Color.Black;
            this.txtReferTemNo.HelpButton = null;
            this.txtReferTemNo.Location = new System.Drawing.Point(143, 229);
            this.txtReferTemNo.MaxLength = 255;
            this.txtReferTemNo.Name = "txtReferTemNo";
            this.txtReferTemNo.PathString = "REFER_TEM_NO.Value";
            this.txtReferTemNo.PathValue = "";
            this.txtReferTemNo.Size = new System.Drawing.Size(786, 26);
            this.txtReferTemNo.TabIndex = 4;
            this.txtReferTemNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRemark_KeyPress);
            // 
            // lblDeliveryNo
            // 
            this.lblDeliveryNo.AppearanceName = "";
            this.lblDeliveryNo.ControlID = "";
            this.lblDeliveryNo.Location = new System.Drawing.Point(576, 33);
            this.lblDeliveryNo.Name = "lblDeliveryNo";
            this.lblDeliveryNo.PathString = null;
            this.lblDeliveryNo.PathValue = "Delivery No.";
            this.lblDeliveryNo.Size = new System.Drawing.Size(137, 28);
            this.lblDeliveryNo.TabIndex = 1;
            this.lblDeliveryNo.Text = "Delivery No.";
            this.lblDeliveryNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDeliveryNo
            // 
            this.txtDeliveryNo.AppearanceName = "";
            this.txtDeliveryNo.AppearanceReadOnlyName = "";
            this.txtDeliveryNo.ControlID = "";
            this.txtDeliveryNo.DisableRestrictChar = false;
            this.txtDeliveryNo.HelpButton = null;
            this.txtDeliveryNo.Location = new System.Drawing.Point(728, 34);
            this.txtDeliveryNo.Name = "txtDeliveryNo";
            this.txtDeliveryNo.PathString = "DELIVERY_NO.Value";
            this.txtDeliveryNo.PathValue = "";
            this.txtDeliveryNo.Size = new System.Drawing.Size(163, 27);
            this.txtDeliveryNo.TabIndex = 232358;
            this.txtDeliveryNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtDeliveryNo_Validating);
            // 
            // evoLabel2
            // 
            this.evoLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.evoLabel2.AppearanceName = "";
            this.evoLabel2.AutoSize = true;
            this.evoLabel2.ControlID = "";
            this.evoLabel2.Location = new System.Drawing.Point(642, 528);
            this.evoLabel2.Name = "evoLabel2";
            this.evoLabel2.PathString = null;
            this.evoLabel2.PathValue = "Vat";
            this.evoLabel2.Size = new System.Drawing.Size(32, 19);
            this.evoLabel2.TabIndex = 232336;
            this.evoLabel2.Text = "Vat";
            // 
            // txtVat
            // 
            this.txtVat.AllowNegative = true;
            this.txtVat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVat.AppearanceName = "";
            this.txtVat.AppearanceReadOnlyName = "";
            this.txtVat.ControlID = "";
            this.txtVat.Decimal = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.txtVat.DecimalPoint = '.';
            this.txtVat.DigitsInGroup = 3;
            this.txtVat.Double = 7D;
            this.txtVat.FixDecimalPosition = true;
            this.txtVat.Flags = 0;
            this.txtVat.GroupSeparator = ',';
            this.txtVat.Int = 7;
            this.txtVat.Location = new System.Drawing.Point(732, 524);
            this.txtVat.Long = ((long)(7));
            this.txtVat.MaxDecimalPlaces = 4;
            this.txtVat.MaxWholeDigits = 9;
            this.txtVat.Name = "txtVat";
            this.txtVat.NegativeSign = '-';
            this.txtVat.PathString = "VAT.Value";
            this.txtVat.PathValue = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.txtVat.Prefix = "";
            this.txtVat.RangeMax = 1.7976931348623157E+308D;
            this.txtVat.RangeMin = -1.7976931348623157E+308D;
            this.txtVat.Size = new System.Drawing.Size(76, 27);
            this.txtVat.TabIndex = 232344;
            this.txtVat.Text = "7";
            this.txtVat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtVatTotal
            // 
            this.txtVatTotal.AllowNegative = true;
            this.txtVatTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVatTotal.AppearanceName = "";
            this.txtVatTotal.AppearanceReadOnlyName = "";
            this.txtVatTotal.ControlID = "";
            this.txtVatTotal.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtVatTotal.DecimalPoint = '.';
            this.txtVatTotal.DigitsInGroup = 3;
            this.txtVatTotal.Double = 0D;
            this.txtVatTotal.FixDecimalPosition = true;
            this.txtVatTotal.Flags = 0;
            this.txtVatTotal.GroupSeparator = ',';
            this.txtVatTotal.Int = 0;
            this.txtVatTotal.Location = new System.Drawing.Point(843, 524);
            this.txtVatTotal.Long = ((long)(0));
            this.txtVatTotal.MaxDecimalPlaces = 4;
            this.txtVatTotal.MaxWholeDigits = 9;
            this.txtVatTotal.Name = "txtVatTotal";
            this.txtVatTotal.NegativeSign = '-';
            this.txtVatTotal.PathString = "VAT_AMOUNT.Value";
            this.txtVatTotal.PathValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtVatTotal.Prefix = "";
            this.txtVatTotal.RangeMax = 1.7976931348623157E+308D;
            this.txtVatTotal.RangeMin = -1.7976931348623157E+308D;
            this.txtVatTotal.Size = new System.Drawing.Size(85, 27);
            this.txtVatTotal.TabIndex = 232344;
            this.txtVatTotal.Text = "0";
            this.txtVatTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkCancelInvoice
            // 
            this.chkCancelInvoice.AppearanceName = "";
            this.chkCancelInvoice.AutoSize = true;
            this.chkCancelInvoice.CheckedValue = "1";
            this.chkCancelInvoice.ControlID = null;
            this.chkCancelInvoice.Location = new System.Drawing.Point(304, 15);
            this.chkCancelInvoice.Name = "chkCancelInvoice";
            this.chkCancelInvoice.PathString = "CANCEL_FLAG.Value";
            this.chkCancelInvoice.PathValue = false;
            this.chkCancelInvoice.Size = new System.Drawing.Size(130, 23);
            this.chkCancelInvoice.TabIndex = 232359;
            this.chkCancelInvoice.Text = "Cancel Invoice";
            this.chkCancelInvoice.UnCheckedValue = null;
            this.chkCancelInvoice.UseVisualStyleBackColor = true;
            // 
            // btnReIssue
            // 
            this.btnReIssue.AppearanceName = "";
            this.btnReIssue.ControlID = null;
            this.btnReIssue.Location = new System.Drawing.Point(440, 9);
            this.btnReIssue.Name = "btnReIssue";
            this.btnReIssue.Size = new System.Drawing.Size(79, 33);
            this.btnReIssue.TabIndex = 232360;
            this.btnReIssue.Text = "Re-Issue";
            this.btnReIssue.UseVisualStyleBackColor = true;
            // 
            // evoLabel3
            // 
            this.evoLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.evoLabel3.AppearanceName = "";
            this.evoLabel3.AutoSize = true;
            this.evoLabel3.ControlID = "";
            this.evoLabel3.Location = new System.Drawing.Point(812, 528);
            this.evoLabel3.Name = "evoLabel3";
            this.evoLabel3.PathString = null;
            this.evoLabel3.PathValue = "%";
            this.evoLabel3.Size = new System.Drawing.Size(25, 19);
            this.evoLabel3.TabIndex = 232336;
            this.evoLabel3.Text = "%";
            // 
            // btnDeliveryNo
            // 
            this.btnDeliveryNo.AppearanceName = "";
            this.btnDeliveryNo.ControlID = null;
            this.btnDeliveryNo.Location = new System.Drawing.Point(898, 34);
            this.btnDeliveryNo.Name = "btnDeliveryNo";
            this.btnDeliveryNo.Size = new System.Drawing.Size(32, 27);
            this.btnDeliveryNo.TabIndex = 232361;
            this.btnDeliveryNo.Text = "...";
            this.btnDeliveryNo.UseVisualStyleBackColor = true;
            this.btnDeliveryNo.Click += new System.EventHandler(this.btnDeliveryNo_Click);
            // 
            // TRN350_InvoiceEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(942, 650);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TRN350_InvoiceEntry";
            this.Text = "Invoice Entry";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TRN350_InvoiceEntry_FormClosed);
            this.Load += new System.EventHandler(this.TRN350_Load);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EVOFramework.Windows.Forms.EVOPanel evoPanel1;
        private EVOFramework.Windows.Forms.EVOLabel label7;
        private EVOFramework.Windows.Forms.EVOLabel lblShipmentNo;
        private EVOFramework.Windows.Forms.EVOLabel lbInvoiceDate;
        private EVOFramework.Windows.Forms.EVOLabel lblTransactionNo;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtInvoiceDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private EVOFramework.Windows.Forms.EVOLabel lbInvoiceInformation;
        private EVOFramework.Windows.Forms.EVOTextBox txtRemark;
        private EVOFramework.Windows.Forms.EVOLabel lblRemark;
        private EVOFramework.Data.UIDataModelController dmcShip;
        private System.Windows.Forms.ContextMenuStrip cmsOperation;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private EVOFramework.Windows.Forms.EVOComboBox cboCustomerCode;
        private EVOFramework.Windows.Forms.EVOLabel lblCustomerCode;
        private FarPoint.Win.Spread.FpSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView shtCustomerOrder;
        private FarPoint.Win.Spread.FpSpread fpCustomerOrder;
        private EVOFramework.Windows.Forms.EVOLabel lblAmount;
        private EVOFramework.Windows.Forms.EVOLabel lblTotalQty;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel1;
        private EVOFramework.Windows.Forms.EVONumericTextBox txtTotal;
        private EVOFramework.Windows.Forms.EVONumericTextBox txtSubTotal;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel6;
        private EVOFramework.Windows.Forms.EVOLabel lblInvoiceNo;
        private EVOFramework.Windows.Forms.EVOTextBox txtInvoiceNo;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel8;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtPaymentDueDate;
        private EVOFramework.Windows.Forms.EVOLabel lblPaymentDueDate;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel7;
        private EVOFramework.Windows.Forms.EVOComboBox cboTermOfPayment;
        private EVOFramework.Windows.Forms.EVOLabel lblTermOfPayment;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel9;
        private EVOFramework.Windows.Forms.EVOComboBox cboAddress;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel10;
        private EVOFramework.Windows.Forms.EVOLabel lblAddress;
        private EVOFramework.Windows.Forms.EVOTextBox txtFullAddress;
        private EVOFramework.Windows.Forms.EVOTextBox txtReferTemNo;
        private EVOFramework.Windows.Forms.EVOLabel lblReferTemNo;
        private EVOFramework.Windows.Forms.EVOLabel lblDeliveryNo;
        private EVOFramework.Windows.Forms.EVOTextBox txtDeliveryNo;
        private EVOFramework.Windows.Forms.EVONumericTextBox txtVat;
        private EVOFramework.Windows.Forms.EVONumericTextBox txtVatTotal;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel2;
        private EVOFramework.Windows.Forms.EVOCheckBox chkCancelInvoice;
        private EVOFramework.Windows.Forms.EVOButton btnReIssue;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel3;
        private EVOFramework.Windows.Forms.EVOButton btnDeliveryNo;

    }
}
