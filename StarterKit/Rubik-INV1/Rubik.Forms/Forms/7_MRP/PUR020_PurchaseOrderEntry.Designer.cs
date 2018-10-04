namespace Rubik.MRP
{
    partial class PUR020_PurchaseOrderEntry
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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PUR020_PurchaseOrderEntry));
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType2 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType5 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType6 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType3 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType7 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSaveAndNew = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveAndClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCancelPO = new System.Windows.Forms.ToolStripButton();
            this.pnlContainer = new EVOFramework.Windows.Forms.EVOPanel();
            this.pnlPO = new System.Windows.Forms.Panel();
            this.lblPoNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.dtmPODate = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.evoLabel7 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel3 = new EVOFramework.Windows.Forms.EVOLabel();
            this.gbPOH = new System.Windows.Forms.GroupBox();
            this.chkOurFactory = new EVOFramework.Windows.Forms.EVOCheckBox();
            this.lblPoStatus = new EVOFramework.Windows.Forms.EVOLabel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.evoLabel24 = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboTermOfPayment = new EVOFramework.Windows.Forms.EVOComboBox();
            this.evoLabel8 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel2 = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboDelivery = new EVOFramework.Windows.Forms.EVOComboBox();
            this.cboSupplierCode = new EVOFramework.Windows.Forms.EVOComboBox();
            this.evoLabel22 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel20 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel9 = new EVOFramework.Windows.Forms.EVOLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.evoLabel6 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel16 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel15 = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboCurrency = new EVOFramework.Windows.Forms.EVOComboBox();
            this.txtVatRate = new EVOFramework.Windows.Forms.EVOIntegerTextBox();
            this.txtRemark = new EVOFramework.Windows.Forms.EVOTextBox();
            this.evoLabel4 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel11 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel10 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel5 = new EVOFramework.Windows.Forms.EVOLabel();
            this.fpView = new FarPoint.Win.Spread.FpSpread();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.shtView = new FarPoint.Win.Spread.SheetView();
            this.toolStrip1.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.pnlPO.SuspendLayout();
            this.gbPOH.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSaveAndNew,
            this.tsbSaveAndClose,
            this.toolStripSeparator2,
            this.tsbCancelPO});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1028, 28);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbSaveAndNew
            // 
            this.tsbSaveAndNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbSaveAndNew.Image")));
            this.tsbSaveAndNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveAndNew.Margin = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.tsbSaveAndNew.Name = "tsbSaveAndNew";
            this.tsbSaveAndNew.Padding = new System.Windows.Forms.Padding(2);
            this.tsbSaveAndNew.Size = new System.Drawing.Size(105, 24);
            this.tsbSaveAndNew.Text = "Save and New";
            this.tsbSaveAndNew.ToolTipText = "Save and New (Ctrl + Enter)";
            this.tsbSaveAndNew.Click += new System.EventHandler(this.tsbSaveAndNew_Click);
            // 
            // tsbSaveAndClose
            // 
            this.tsbSaveAndClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbSaveAndClose.Image")));
            this.tsbSaveAndClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveAndClose.Margin = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.tsbSaveAndClose.Name = "tsbSaveAndClose";
            this.tsbSaveAndClose.Padding = new System.Windows.Forms.Padding(2);
            this.tsbSaveAndClose.Size = new System.Drawing.Size(110, 24);
            this.tsbSaveAndClose.Text = "Save and Close";
            this.tsbSaveAndClose.ToolTipText = "Save and Close (Ctrl + Shift + Enter)";
            this.tsbSaveAndClose.Click += new System.EventHandler(this.tsbSaveAndClose_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // tsbCancelPO
            // 
            this.tsbCancelPO.Image = global::Rubik.Forms.Properties.Resources.CLEAR;
            this.tsbCancelPO.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancelPO.Name = "tsbCancelPO";
            this.tsbCancelPO.Size = new System.Drawing.Size(82, 25);
            this.tsbCancelPO.Text = "Cancel PO";
            this.tsbCancelPO.Click += new System.EventHandler(this.tsbCancelPO_Click);
            // 
            // pnlContainer
            // 
            this.pnlContainer.AppearanceName = "FormBGColor";
            this.pnlContainer.AutoScroll = true;
            this.pnlContainer.BackColor = System.Drawing.Color.AliceBlue;
            this.pnlContainer.Controls.Add(this.pnlPO);
            this.pnlContainer.Controls.Add(this.gbPOH);
            this.pnlContainer.Controls.Add(this.evoLabel5);
            this.pnlContainer.Controls.Add(this.fpView);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 28);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1028, 718);
            this.pnlContainer.TabIndex = 0;
            // 
            // pnlPO
            // 
            this.pnlPO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPO.Controls.Add(this.lblPoNo);
            this.pnlPO.Controls.Add(this.evoLabel1);
            this.pnlPO.Controls.Add(this.dtmPODate);
            this.pnlPO.Controls.Add(this.evoLabel7);
            this.pnlPO.Controls.Add(this.evoLabel3);
            this.pnlPO.Location = new System.Drawing.Point(595, 0);
            this.pnlPO.Name = "pnlPO";
            this.pnlPO.Size = new System.Drawing.Size(433, 72);
            this.pnlPO.TabIndex = 10082;
            // 
            // lblPoNo
            // 
            this.lblPoNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPoNo.AppearanceName = "";
            this.lblPoNo.ControlID = "";
            this.lblPoNo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPoNo.Location = new System.Drawing.Point(102, 7);
            this.lblPoNo.Name = "lblPoNo";
            this.lblPoNo.PathString = null;
            this.lblPoNo.PathValue = "";
            this.lblPoNo.Size = new System.Drawing.Size(307, 22);
            this.lblPoNo.TabIndex = 10087;
            // 
            // evoLabel1
            // 
            this.evoLabel1.AppearanceName = "";
            this.evoLabel1.AutoSize = true;
            this.evoLabel1.ControlID = "";
            this.evoLabel1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel1.Location = new System.Drawing.Point(36, 7);
            this.evoLabel1.Name = "evoLabel1";
            this.evoLabel1.PathString = null;
            this.evoLabel1.PathValue = "PO No.";
            this.evoLabel1.Size = new System.Drawing.Size(60, 19);
            this.evoLabel1.TabIndex = 10041;
            this.evoLabel1.Text = "PO No.";
            // 
            // dtmPODate
            // 
            this.dtmPODate.AppearanceName = "";
            this.dtmPODate.AppearanceReadOnlyName = "";
            this.dtmPODate.BackColor = System.Drawing.Color.Transparent;
            this.dtmPODate.ControlID = "";
            this.dtmPODate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtmPODate.Format = "dd/MM/yyyy";
            this.dtmPODate.Location = new System.Drawing.Point(102, 32);
            this.dtmPODate.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtmPODate.Name = "dtmPODate";
            this.dtmPODate.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtmPODate.NZValue")));
            this.dtmPODate.PathString = null;
            this.dtmPODate.PathValue = ((object)(resources.GetObject("dtmPODate.PathValue")));
            this.dtmPODate.ReadOnly = false;
            this.dtmPODate.ShowButton = true;
            this.dtmPODate.Size = new System.Drawing.Size(309, 27);
            this.dtmPODate.TabIndex = 0;
            this.dtmPODate.Value = null;
            // 
            // evoLabel7
            // 
            this.evoLabel7.AppearanceName = "";
            this.evoLabel7.AutoSize = true;
            this.evoLabel7.ControlID = "";
            this.evoLabel7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel7.ForeColor = System.Drawing.Color.Red;
            this.evoLabel7.Location = new System.Drawing.Point(6, 20);
            this.evoLabel7.Name = "evoLabel7";
            this.evoLabel7.PathString = null;
            this.evoLabel7.PathValue = "*";
            this.evoLabel7.Size = new System.Drawing.Size(18, 19);
            this.evoLabel7.TabIndex = 10080;
            this.evoLabel7.Text = "*";
            // 
            // evoLabel3
            // 
            this.evoLabel3.AppearanceName = "";
            this.evoLabel3.AutoSize = true;
            this.evoLabel3.ControlID = "";
            this.evoLabel3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel3.Location = new System.Drawing.Point(29, 36);
            this.evoLabel3.Name = "evoLabel3";
            this.evoLabel3.PathString = null;
            this.evoLabel3.PathValue = "PO Date";
            this.evoLabel3.Size = new System.Drawing.Size(67, 19);
            this.evoLabel3.TabIndex = 10043;
            this.evoLabel3.Text = "PO Date";
            // 
            // gbPOH
            // 
            this.gbPOH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPOH.Controls.Add(this.chkOurFactory);
            this.gbPOH.Controls.Add(this.lblPoStatus);
            this.gbPOH.Controls.Add(this.tableLayoutPanel2);
            this.gbPOH.Controls.Add(this.cboTermOfPayment);
            this.gbPOH.Controls.Add(this.evoLabel8);
            this.gbPOH.Controls.Add(this.evoLabel2);
            this.gbPOH.Controls.Add(this.cboDelivery);
            this.gbPOH.Controls.Add(this.cboSupplierCode);
            this.gbPOH.Controls.Add(this.evoLabel22);
            this.gbPOH.Controls.Add(this.evoLabel20);
            this.gbPOH.Controls.Add(this.evoLabel9);
            this.gbPOH.Controls.Add(this.tableLayoutPanel1);
            this.gbPOH.Controls.Add(this.evoLabel16);
            this.gbPOH.Controls.Add(this.evoLabel15);
            this.gbPOH.Controls.Add(this.cboCurrency);
            this.gbPOH.Controls.Add(this.txtVatRate);
            this.gbPOH.Controls.Add(this.txtRemark);
            this.gbPOH.Controls.Add(this.evoLabel4);
            this.gbPOH.Controls.Add(this.evoLabel11);
            this.gbPOH.Controls.Add(this.evoLabel10);
            this.gbPOH.Location = new System.Drawing.Point(0, 61);
            this.gbPOH.Name = "gbPOH";
            this.gbPOH.Size = new System.Drawing.Size(1028, 265);
            this.gbPOH.TabIndex = 1;
            this.gbPOH.TabStop = false;
            this.gbPOH.Text = "groupBox1";
            // 
            // chkOurFactory
            // 
            this.chkOurFactory.AppearanceName = "";
            this.chkOurFactory.AutoSize = true;
            this.chkOurFactory.CheckedValue = null;
            this.chkOurFactory.ControlID = null;
            this.chkOurFactory.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkOurFactory.Location = new System.Drawing.Point(146, 85);
            this.chkOurFactory.Name = "chkOurFactory";
            this.chkOurFactory.PathString = null;
            this.chkOurFactory.PathValue = false;
            this.chkOurFactory.Size = new System.Drawing.Size(111, 23);
            this.chkOurFactory.TabIndex = 2;
            this.chkOurFactory.Text = "Our Factory";
            this.chkOurFactory.UnCheckedValue = null;
            this.chkOurFactory.UseVisualStyleBackColor = true;
            this.chkOurFactory.CheckedChanged += new System.EventHandler(this.chkOurFactory_CheckedChanged);
            // 
            // lblPoStatus
            // 
            this.lblPoStatus.AppearanceName = "";
            this.lblPoStatus.ControlID = "";
            this.lblPoStatus.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPoStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblPoStatus.Location = new System.Drawing.Point(693, 45);
            this.lblPoStatus.Name = "lblPoStatus";
            this.lblPoStatus.PathString = null;
            this.lblPoStatus.PathValue = "";
            this.lblPoStatus.Size = new System.Drawing.Size(311, 28);
            this.lblPoStatus.TabIndex = 10086;
            this.lblPoStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel2.BackgroundImage")));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.evoLabel24, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 240);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1028, 38);
            this.tableLayoutPanel2.TabIndex = 10059;
            // 
            // evoLabel24
            // 
            this.evoLabel24.AppearanceName = "Header";
            this.evoLabel24.AutoSize = true;
            this.evoLabel24.ControlID = "";
            this.evoLabel24.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel24.ForeColor = System.Drawing.Color.Navy;
            this.evoLabel24.Location = new System.Drawing.Point(0, 0);
            this.evoLabel24.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.evoLabel24.Name = "evoLabel24";
            this.evoLabel24.PathString = null;
            this.evoLabel24.PathValue = "Purchase Order Detail";
            this.evoLabel24.Size = new System.Drawing.Size(195, 24);
            this.evoLabel24.TabIndex = 0;
            this.evoLabel24.Text = "Purchase Order Detail";
            // 
            // cboTermOfPayment
            // 
            this.cboTermOfPayment.AppearanceName = "";
            this.cboTermOfPayment.AppearanceReadOnlyName = "";
            this.cboTermOfPayment.ControlID = null;
            this.cboTermOfPayment.DropDownHeight = 180;
            this.cboTermOfPayment.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboTermOfPayment.FormattingEnabled = true;
            this.cboTermOfPayment.IntegralHeight = false;
            this.cboTermOfPayment.Location = new System.Drawing.Point(263, 121);
            this.cboTermOfPayment.Name = "cboTermOfPayment";
            this.cboTermOfPayment.PathString = null;
            this.cboTermOfPayment.PathValue = null;
            this.cboTermOfPayment.Size = new System.Drawing.Size(276, 27);
            this.cboTermOfPayment.TabIndex = 5;
            // 
            // evoLabel8
            // 
            this.evoLabel8.AppearanceName = "";
            this.evoLabel8.AutoSize = true;
            this.evoLabel8.ControlID = "";
            this.evoLabel8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel8.Location = new System.Drawing.Point(50, 124);
            this.evoLabel8.Name = "evoLabel8";
            this.evoLabel8.PathString = null;
            this.evoLabel8.PathValue = "Term Of Payment";
            this.evoLabel8.Size = new System.Drawing.Size(135, 19);
            this.evoLabel8.TabIndex = 10080;
            this.evoLabel8.Text = "Term Of Payment";
            // 
            // evoLabel2
            // 
            this.evoLabel2.AppearanceName = "";
            this.evoLabel2.AutoSize = true;
            this.evoLabel2.ControlID = "";
            this.evoLabel2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel2.ForeColor = System.Drawing.Color.Red;
            this.evoLabel2.Location = new System.Drawing.Point(549, 122);
            this.evoLabel2.Name = "evoLabel2";
            this.evoLabel2.PathString = null;
            this.evoLabel2.PathValue = "*";
            this.evoLabel2.Size = new System.Drawing.Size(18, 19);
            this.evoLabel2.TabIndex = 10079;
            this.evoLabel2.Text = "*";
            // 
            // cboDelivery
            // 
            this.cboDelivery.AppearanceName = "";
            this.cboDelivery.AppearanceReadOnlyName = "";
            this.cboDelivery.ControlID = null;
            this.cboDelivery.DropDownHeight = 180;
            this.cboDelivery.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboDelivery.FormattingEnabled = true;
            this.cboDelivery.IntegralHeight = false;
            this.cboDelivery.Location = new System.Drawing.Point(263, 83);
            this.cboDelivery.Name = "cboDelivery";
            this.cboDelivery.PathString = null;
            this.cboDelivery.PathValue = null;
            this.cboDelivery.Size = new System.Drawing.Size(276, 27);
            this.cboDelivery.TabIndex = 3;
            // 
            // cboSupplierCode
            // 
            this.cboSupplierCode.AppearanceName = "";
            this.cboSupplierCode.AppearanceReadOnlyName = "";
            this.cboSupplierCode.ControlID = null;
            this.cboSupplierCode.DropDownHeight = 180;
            this.cboSupplierCode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboSupplierCode.FormattingEnabled = true;
            this.cboSupplierCode.IntegralHeight = false;
            this.cboSupplierCode.Location = new System.Drawing.Point(263, 47);
            this.cboSupplierCode.Name = "cboSupplierCode";
            this.cboSupplierCode.PathString = null;
            this.cboSupplierCode.PathValue = null;
            this.cboSupplierCode.Size = new System.Drawing.Size(276, 27);
            this.cboSupplierCode.TabIndex = 1;
            // 
            // evoLabel22
            // 
            this.evoLabel22.AppearanceName = "";
            this.evoLabel22.AutoSize = true;
            this.evoLabel22.ControlID = "";
            this.evoLabel22.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel22.ForeColor = System.Drawing.Color.Red;
            this.evoLabel22.Location = new System.Drawing.Point(26, 87);
            this.evoLabel22.Name = "evoLabel22";
            this.evoLabel22.PathString = null;
            this.evoLabel22.PathValue = "*";
            this.evoLabel22.Size = new System.Drawing.Size(18, 19);
            this.evoLabel22.TabIndex = 10075;
            this.evoLabel22.Text = "*";
            // 
            // evoLabel20
            // 
            this.evoLabel20.AppearanceName = "";
            this.evoLabel20.AutoSize = true;
            this.evoLabel20.ControlID = "";
            this.evoLabel20.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel20.ForeColor = System.Drawing.Color.Red;
            this.evoLabel20.Location = new System.Drawing.Point(26, 50);
            this.evoLabel20.Name = "evoLabel20";
            this.evoLabel20.PathString = null;
            this.evoLabel20.PathValue = "*";
            this.evoLabel20.Size = new System.Drawing.Size(18, 19);
            this.evoLabel20.TabIndex = 10072;
            this.evoLabel20.Text = "*";
            // 
            // evoLabel9
            // 
            this.evoLabel9.AppearanceName = "";
            this.evoLabel9.AutoSize = true;
            this.evoLabel9.ControlID = "";
            this.evoLabel9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel9.Location = new System.Drawing.Point(573, 50);
            this.evoLabel9.Name = "evoLabel9";
            this.evoLabel9.PathString = null;
            this.evoLabel9.PathValue = "PO Status";
            this.evoLabel9.Size = new System.Drawing.Size(78, 19);
            this.evoLabel9.TabIndex = 10054;
            this.evoLabel9.Text = "PO Status";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel1.BackgroundImage")));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.evoLabel6, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1028, 38);
            this.tableLayoutPanel1.TabIndex = 10008;
            // 
            // evoLabel6
            // 
            this.evoLabel6.AppearanceName = "Header";
            this.evoLabel6.AutoSize = true;
            this.evoLabel6.ControlID = "";
            this.evoLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel6.ForeColor = System.Drawing.Color.Navy;
            this.evoLabel6.Location = new System.Drawing.Point(0, 0);
            this.evoLabel6.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.evoLabel6.Name = "evoLabel6";
            this.evoLabel6.PathString = null;
            this.evoLabel6.PathValue = "Purchase Order Header";
            this.evoLabel6.Size = new System.Drawing.Size(212, 24);
            this.evoLabel6.TabIndex = 0;
            this.evoLabel6.Text = "Purchase Order Header";
            // 
            // evoLabel16
            // 
            this.evoLabel16.AppearanceName = "";
            this.evoLabel16.AutoSize = true;
            this.evoLabel16.ControlID = "";
            this.evoLabel16.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel16.Location = new System.Drawing.Point(50, 161);
            this.evoLabel16.Name = "evoLabel16";
            this.evoLabel16.PathString = null;
            this.evoLabel16.PathValue = "Remark";
            this.evoLabel16.Size = new System.Drawing.Size(63, 19);
            this.evoLabel16.TabIndex = 10069;
            this.evoLabel16.Text = "Remark";
            // 
            // evoLabel15
            // 
            this.evoLabel15.AppearanceName = "";
            this.evoLabel15.AutoSize = true;
            this.evoLabel15.ControlID = "";
            this.evoLabel15.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel15.Location = new System.Drawing.Point(573, 86);
            this.evoLabel15.Name = "evoLabel15";
            this.evoLabel15.PathString = null;
            this.evoLabel15.PathValue = "Vat Rate (%)";
            this.evoLabel15.Size = new System.Drawing.Size(101, 19);
            this.evoLabel15.TabIndex = 10065;
            this.evoLabel15.Text = "Vat Rate (%)";
            // 
            // cboCurrency
            // 
            this.cboCurrency.AppearanceName = "";
            this.cboCurrency.AppearanceReadOnlyName = "";
            this.cboCurrency.ControlID = null;
            this.cboCurrency.DropDownHeight = 180;
            this.cboCurrency.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboCurrency.FormattingEnabled = true;
            this.cboCurrency.IntegralHeight = false;
            this.cboCurrency.Location = new System.Drawing.Point(693, 120);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.PathString = null;
            this.cboCurrency.PathValue = null;
            this.cboCurrency.Size = new System.Drawing.Size(313, 27);
            this.cboCurrency.TabIndex = 6;
            // 
            // txtVatRate
            // 
            this.txtVatRate.AllowNegative = true;
            this.txtVatRate.AppearanceName = "";
            this.txtVatRate.AppearanceReadOnlyName = "";
            this.txtVatRate.ControlID = "";
            this.txtVatRate.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtVatRate.DecimalPoint = '.';
            this.txtVatRate.DigitsInGroup = 3;
            this.txtVatRate.Double = 0D;
            this.txtVatRate.Flags = 0;
            this.txtVatRate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtVatRate.GroupSeparator = ',';
            this.txtVatRate.Int = 0;
            this.txtVatRate.Location = new System.Drawing.Point(693, 83);
            this.txtVatRate.Long = ((long)(0));
            this.txtVatRate.MaxDecimalPlaces = 0;
            this.txtVatRate.MaxWholeDigits = 9;
            this.txtVatRate.Name = "txtVatRate";
            this.txtVatRate.NegativeSign = '\0';
            this.txtVatRate.PathString = null;
            this.txtVatRate.PathValue = 0;
            this.txtVatRate.Prefix = "";
            this.txtVatRate.RangeMax = 1.7976931348623157E+308D;
            this.txtVatRate.RangeMin = 0D;
            this.txtVatRate.Size = new System.Drawing.Size(313, 27);
            this.txtVatRate.TabIndex = 4;
            this.txtVatRate.Text = "0";
            this.txtVatRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtRemark
            // 
            this.txtRemark.AppearanceName = "";
            this.txtRemark.AppearanceReadOnlyName = "";
            this.txtRemark.ControlID = "";
            this.txtRemark.DisableRestrictChar = false;
            this.txtRemark.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtRemark.HelpButton = null;
            this.txtRemark.Location = new System.Drawing.Point(263, 158);
            this.txtRemark.MaxLength = 255;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.PathString = null;
            this.txtRemark.PathValue = "";
            this.txtRemark.Size = new System.Drawing.Size(743, 73);
            this.txtRemark.TabIndex = 7;
            // 
            // evoLabel4
            // 
            this.evoLabel4.AppearanceName = "";
            this.evoLabel4.AutoSize = true;
            this.evoLabel4.ControlID = "";
            this.evoLabel4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel4.Location = new System.Drawing.Point(50, 50);
            this.evoLabel4.Name = "evoLabel4";
            this.evoLabel4.PathString = null;
            this.evoLabel4.PathValue = "Supplier";
            this.evoLabel4.Size = new System.Drawing.Size(67, 19);
            this.evoLabel4.TabIndex = 10044;
            this.evoLabel4.Text = "Supplier";
            // 
            // evoLabel11
            // 
            this.evoLabel11.AppearanceName = "";
            this.evoLabel11.AutoSize = true;
            this.evoLabel11.ControlID = "";
            this.evoLabel11.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel11.Location = new System.Drawing.Point(573, 122);
            this.evoLabel11.Name = "evoLabel11";
            this.evoLabel11.PathString = null;
            this.evoLabel11.PathValue = "Currency";
            this.evoLabel11.Size = new System.Drawing.Size(72, 19);
            this.evoLabel11.TabIndex = 10056;
            this.evoLabel11.Text = "Currency";
            // 
            // evoLabel10
            // 
            this.evoLabel10.AppearanceName = "";
            this.evoLabel10.AutoSize = true;
            this.evoLabel10.ControlID = "";
            this.evoLabel10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel10.Location = new System.Drawing.Point(50, 87);
            this.evoLabel10.Name = "evoLabel10";
            this.evoLabel10.PathString = null;
            this.evoLabel10.PathValue = "Delivery To";
            this.evoLabel10.Size = new System.Drawing.Size(90, 19);
            this.evoLabel10.TabIndex = 10055;
            this.evoLabel10.Tag = "";
            this.evoLabel10.Text = "Delivery To";
            // 
            // evoLabel5
            // 
            this.evoLabel5.AppearanceName = "Title";
            this.evoLabel5.AutoSize = true;
            this.evoLabel5.ControlID = "";
            this.evoLabel5.Font = new System.Drawing.Font("Tahoma", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.evoLabel5.Location = new System.Drawing.Point(3, 9);
            this.evoLabel5.Name = "evoLabel5";
            this.evoLabel5.PathString = null;
            this.evoLabel5.PathValue = "Purchase Order Entry";
            this.evoLabel5.Size = new System.Drawing.Size(358, 39);
            this.evoLabel5.TabIndex = 10006;
            this.evoLabel5.Text = "Purchase Order Entry";
            // 
            // fpView
            // 
            this.fpView.About = "2.5.2015.2005";
            this.fpView.AccessibleDescription = "fpView, Sheet1";
            this.fpView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fpView.BackColor = System.Drawing.Color.AliceBlue;
            this.fpView.ContextMenuStrip = this.ctxMenu;
            this.fpView.EditModeReplace = true;
            this.fpView.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.fpView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.Location = new System.Drawing.Point(0, 328);
            this.fpView.Name = "fpView";
            this.fpView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtView});
            this.fpView.Size = new System.Drawing.Size(1028, 390);
            this.fpView.TabIndex = 8;
            this.fpView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.EditModeOn += new System.EventHandler(this.fpView_EditModeOn);
            this.fpView.EditModeOff += new System.EventHandler(this.fpView_EditModeOff);
            this.fpView.LeaveCell += new FarPoint.Win.Spread.LeaveCellEventHandler(this.fpView_LeaveCell);
            this.fpView.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.fpView_ButtonClicked);
            this.fpView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpView_KeyUp);
            this.fpView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fpView_KeyUp);
            // 
            // ctxMenu
            // 
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // shtView
            // 
            this.shtView.Reset();
            this.shtView.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtView.ColumnCount = 27;
            this.shtView.RowCount = 0;
            this.shtView.AutoCalculation = false;
            this.shtView.AutoGenerateColumns = false;
            this.shtView.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.shtView.ColumnHeader.Cells.Get(0, 0).Value = "PO_LINE";
            this.shtView.ColumnHeader.Cells.Get(0, 1).Value = "CRT_BY";
            this.shtView.ColumnHeader.Cells.Get(0, 2).Value = "CTR_DATE";
            this.shtView.ColumnHeader.Cells.Get(0, 3).Value = "CRT_MACHINE";
            this.shtView.ColumnHeader.Cells.Get(0, 4).Value = "UPD_BY";
            this.shtView.ColumnHeader.Cells.Get(0, 5).Value = "UPD_DATE";
            this.shtView.ColumnHeader.Cells.Get(0, 6).Value = "UPD_MACHINE";
            this.shtView.ColumnHeader.Cells.Get(0, 7).Value = "IS_ACTIVE";
            this.shtView.ColumnHeader.Cells.Get(0, 8).Value = "PO_NO";
            this.shtView.ColumnHeader.Cells.Get(0, 9).Value = "Part Code";
            this.shtView.ColumnHeader.Cells.Get(0, 10).Value = "...";
            this.shtView.ColumnHeader.Cells.Get(0, 11).Value = "Part Desc";
            this.shtView.ColumnHeader.Cells.Get(0, 12).Value = "Due Date";
            this.shtView.ColumnHeader.Cells.Get(0, 13).Value = "Unit";
            this.shtView.ColumnHeader.Cells.Get(0, 14).Value = "Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 15).Value = "Unit Price";
            this.shtView.ColumnHeader.Cells.Get(0, 16).Value = "Amount";
            this.shtView.ColumnHeader.Cells.Get(0, 17).Value = "Inventory U/M";
            this.shtView.ColumnHeader.Cells.Get(0, 18).Value = "Inventory Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 19).Value = "Receive Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 20).Value = "Back Order Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 21).Value = "LAST_RECEIVE_ID";
            this.shtView.ColumnHeader.Cells.Get(0, 22).Value = "LAST_RECEIVE_DATE";
            this.shtView.ColumnHeader.Cells.Get(0, 23).Value = "Status";
            this.shtView.ColumnHeader.Cells.Get(0, 24).Value = "Modify State";
            this.shtView.ColumnHeader.Cells.Get(0, 25).Value = "KeptStatus";
            this.shtView.ColumnHeader.Cells.Get(0, 26).Value = "rate";
            this.shtView.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtView.Columns.Get(0).Label = "PO_LINE";
            this.shtView.Columns.Get(0).Tag = "PO_LINE";
            this.shtView.Columns.Get(1).Label = "CRT_BY";
            this.shtView.Columns.Get(1).Locked = false;
            this.shtView.Columns.Get(1).Tag = "CRT_BY";
            this.shtView.Columns.Get(2).Label = "CTR_DATE";
            this.shtView.Columns.Get(2).Tag = "CTR_DATE";
            this.shtView.Columns.Get(2).Width = 62F;
            this.shtView.Columns.Get(3).Label = "CRT_MACHINE";
            this.shtView.Columns.Get(3).Tag = "CRT_MACHINE";
            this.shtView.Columns.Get(4).Label = "UPD_BY";
            this.shtView.Columns.Get(4).Tag = "UPD_BY";
            this.shtView.Columns.Get(5).Label = "UPD_DATE";
            this.shtView.Columns.Get(5).Tag = "UPD_DATE";
            this.shtView.Columns.Get(6).Label = "UPD_MACHINE";
            this.shtView.Columns.Get(6).Tag = "UPD_MACHINE";
            this.shtView.Columns.Get(7).Label = "IS_ACTIVE";
            this.shtView.Columns.Get(7).Tag = "IS_ACTIVE";
            this.shtView.Columns.Get(8).Label = "PO_NO";
            this.shtView.Columns.Get(8).Tag = "PO_NO";
            this.shtView.Columns.Get(8).Width = 70F;
            textCellType1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.shtView.Columns.Get(9).CellType = textCellType1;
            this.shtView.Columns.Get(9).Label = "Part Code";
            this.shtView.Columns.Get(9).Locked = true;
            this.shtView.Columns.Get(9).Tag = "Part Code";
            this.shtView.Columns.Get(9).Width = 190F;
            buttonCellType1.ShadowSize = 0;
            buttonCellType1.Text = "...";
            this.shtView.Columns.Get(10).CellType = buttonCellType1;
            this.shtView.Columns.Get(10).Label = "...";
            this.shtView.Columns.Get(10).Locked = true;
            this.shtView.Columns.Get(10).Resizable = false;
            this.shtView.Columns.Get(10).Tag = "...";
            this.shtView.Columns.Get(10).Width = 30F;
            textCellType2.MaxLength = 50;
            this.shtView.Columns.Get(11).CellType = textCellType2;
            this.shtView.Columns.Get(11).Label = "Part Desc";
            this.shtView.Columns.Get(11).Locked = true;
            this.shtView.Columns.Get(11).Tag = "Part Desc";
            this.shtView.Columns.Get(11).Width = 220F;
            dateTimeCellType1.Calendar = ((System.Globalization.Calendar)(resources.GetObject("dateTimeCellType1.Calendar")));
            dateTimeCellType1.DateDefault = new System.DateTime(2011, 6, 8, 14, 23, 35, 0);
            dateTimeCellType1.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
            dateTimeCellType1.TimeDefault = new System.DateTime(2011, 6, 8, 14, 23, 35, 0);
            dateTimeCellType1.TwoDigitYearMax = 2029;
            dateTimeCellType1.UserDefinedFormat = "dd/MM/yyyy";
            this.shtView.Columns.Get(12).CellType = dateTimeCellType1;
            this.shtView.Columns.Get(12).Label = "Due Date";
            this.shtView.Columns.Get(12).Tag = "Due Date";
            this.shtView.Columns.Get(12).Width = 144F;
            comboBoxCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            this.shtView.Columns.Get(13).CellType = comboBoxCellType1;
            this.shtView.Columns.Get(13).Label = "Unit";
            this.shtView.Columns.Get(13).Tag = "Unit";
            this.shtView.Columns.Get(13).Width = 104F;
            numberCellType1.MinimumValue = 0D;
            this.shtView.Columns.Get(14).CellType = numberCellType1;
            this.shtView.Columns.Get(14).Label = "Qty";
            this.shtView.Columns.Get(14).Tag = "Qty";
            this.shtView.Columns.Get(14).Width = 87F;
            numberCellType2.MinimumValue = 0D;
            this.shtView.Columns.Get(15).CellType = numberCellType2;
            this.shtView.Columns.Get(15).Label = "Unit Price";
            this.shtView.Columns.Get(15).Tag = "Unit Price";
            this.shtView.Columns.Get(15).Width = 115F;
            numberCellType3.MinimumValue = 0D;
            this.shtView.Columns.Get(16).CellType = numberCellType3;
            this.shtView.Columns.Get(16).Label = "Amount";
            this.shtView.Columns.Get(16).Tag = "Amount";
            this.shtView.Columns.Get(16).Width = 113F;
            comboBoxCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            this.shtView.Columns.Get(17).CellType = comboBoxCellType2;
            this.shtView.Columns.Get(17).Label = "Inventory U/M";
            this.shtView.Columns.Get(17).Locked = false;
            this.shtView.Columns.Get(17).Tag = "Inventory U/M";
            this.shtView.Columns.Get(17).Width = 136F;
            this.shtView.Columns.Get(18).CellType = numberCellType4;
            this.shtView.Columns.Get(18).Label = "Inventory Qty";
            this.shtView.Columns.Get(18).Tag = "Inventory Qty";
            this.shtView.Columns.Get(18).Width = 144F;
            this.shtView.Columns.Get(19).CellType = numberCellType5;
            this.shtView.Columns.Get(19).Label = "Receive Qty";
            this.shtView.Columns.Get(19).Tag = "Receive Qty";
            this.shtView.Columns.Get(19).Width = 121F;
            this.shtView.Columns.Get(20).CellType = numberCellType6;
            this.shtView.Columns.Get(20).Label = "Back Order Qty";
            this.shtView.Columns.Get(20).Tag = "Back Order Qty";
            this.shtView.Columns.Get(20).Width = 153F;
            this.shtView.Columns.Get(21).Label = "LAST_RECEIVE_ID";
            this.shtView.Columns.Get(21).Tag = "LAST_RECEIVE_ID";
            this.shtView.Columns.Get(22).Label = "LAST_RECEIVE_DATE";
            this.shtView.Columns.Get(22).Width = 0F;
            comboBoxCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            this.shtView.Columns.Get(23).CellType = comboBoxCellType3;
            this.shtView.Columns.Get(23).Label = "Status";
            this.shtView.Columns.Get(23).Tag = "Status";
            this.shtView.Columns.Get(23).Width = 172F;
            this.shtView.Columns.Get(24).Label = "Modify State";
            this.shtView.Columns.Get(24).Tag = "Modify State";
            this.shtView.Columns.Get(25).Label = "KeptStatus";
            this.shtView.Columns.Get(25).Tag = "KeptStatus";
            this.shtView.Columns.Get(25).Width = 86F;
            this.shtView.Columns.Get(26).CellType = numberCellType7;
            this.shtView.Columns.Get(26).Label = "rate";
            this.shtView.Columns.Get(26).Tag = "rate";
            this.shtView.DataAutoCellTypes = false;
            this.shtView.DataAutoHeadings = false;
            this.shtView.DataAutoSizeColumns = false;
            this.shtView.DefaultStyle.ForeColor = System.Drawing.Color.Blue;
            this.shtView.DefaultStyle.Locked = true;
            this.shtView.DefaultStyle.Parent = "DataAreaDefault";
            this.shtView.LockForeColor = System.Drawing.Color.Black;
            this.shtView.RowHeader.Columns.Default.Resizable = true;
            this.shtView.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpView.SetActiveViewport(0, 1, 0);
            // 
            // PUR020_PurchaseOrderEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1028, 746);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.toolStrip1);
            this.Name = "PUR020_PurchaseOrderEntry";
            this.Text = "PUR020 : Purchase Order Entry";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PUR020_PurchaseOrderEntry_FormClosed);
            this.Load += new System.EventHandler(this.PUR020_PurchaseOrderEntry_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.pnlPO.ResumeLayout(false);
            this.pnlPO.PerformLayout();
            this.gbPOH.ResumeLayout(false);
            this.gbPOH.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripButton tsbSaveAndClose;
        public System.Windows.Forms.ToolStripButton tsbSaveAndNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public EVOFramework.Windows.Forms.EVOPanel pnlContainer;
        private FarPoint.Win.Spread.FpSpread fpView;
        private FarPoint.Win.Spread.SheetView shtView;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel5;
        private System.Windows.Forms.GroupBox gbPOH;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel6;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel4;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel15;
        private EVOFramework.Windows.Forms.EVOIntegerTextBox txtVatRate;
        private EVOFramework.Windows.Forms.EVOComboBox cboCurrency;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel11;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel10;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel9;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel16;
        private EVOFramework.Windows.Forms.EVOTextBox txtRemark;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel24;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel22;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel20;
        private EVOFramework.Windows.Forms.EVOComboBox cboSupplierCode;
        private EVOFramework.Windows.Forms.EVOComboBox cboDelivery;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel2;
        private EVOFramework.Windows.Forms.EVOComboBox cboTermOfPayment;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel8;
        private System.Windows.Forms.Panel pnlPO;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel1;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtmPODate;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel7;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel3;
        private System.Windows.Forms.ToolStripButton tsbCancelPO;
        private EVOFramework.Windows.Forms.EVOLabel lblPoStatus;
        private EVOFramework.Windows.Forms.EVOLabel lblPoNo;
        private EVOFramework.Windows.Forms.EVOCheckBox chkOurFactory;
    }
}
