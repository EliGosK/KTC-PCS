namespace Rubik.Transaction
{
    partial class TRN320_PackingEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TRN320_PackingEntry));
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.stcWorkResultNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcWorkResultDate = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblPackingNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.dtPackingDate = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.stcReqWorkResultDate = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcHead = new EVOFramework.Windows.Forms.EVOLabel();
            this.tlpHeader2 = new System.Windows.Forms.TableLayoutPanel();
            this.stcReceiveInfo = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcItemCode = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcItemDesc = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcReqItemCode = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcOrderLoc = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcRemark = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtCustomerName = new EVOFramework.Windows.Forms.EVOTextBox();
            this.btnSearchMasterNo = new EVOFramework.Windows.Forms.EVOButton();
            this.cboSourceProcess = new EVOFramework.Windows.Forms.EVOComboBox();
            this.txtRemark = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblShift = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboShift = new EVOFramework.Windows.Forms.EVOComboBox();
            this.evoLabel1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.cmsOperation = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dmc = new EVOFramework.Data.UIDataModelController(this.components);
            this.hiddenTransactionID = new EVOFramework.Windows.Forms.EVOLabel();
            this.hiddenNGTransactionID = new EVOFramework.Windows.Forms.EVOLabel();
            this.hiddenReserveTransID = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel4 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtPartNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.evoLabel2 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtPackNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.fpLotNoList = new FarPoint.Win.Spread.FpSpread();
            this.shtLotNoList = new FarPoint.Win.Spread.SheetView();
            this.evoLabel3 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel5 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtTotalQty = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.evoLabel6 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtOnHand = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.stcWorkOrderNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboPersonInCharge = new EVOFramework.Windows.Forms.EVOComboBox();
            this.txtMasterNo = new Rubik.Forms.UserControl.ItemTextBox();
            this.cboDescProcess = new EVOFramework.Windows.Forms.EVOComboBox();
            this.evoLabel7 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel8 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel9 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtFGNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.txtNumberOfBox = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.evoLabel11 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel12 = new EVOFramework.Windows.Forms.EVOLabel();
            this.pnlContainer.SuspendLayout();
            this.tlpHeader2.SuspendLayout();
            this.cmsOperation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpLotNoList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtLotNoList)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.evoLabel12);
            this.pnlContainer.Controls.Add(this.evoLabel11);
            this.pnlContainer.Controls.Add(this.txtNumberOfBox);
            this.pnlContainer.Controls.Add(this.txtFGNo);
            this.pnlContainer.Controls.Add(this.evoLabel9);
            this.pnlContainer.Controls.Add(this.evoLabel8);
            this.pnlContainer.Controls.Add(this.evoLabel7);
            this.pnlContainer.Controls.Add(this.cboDescProcess);
            this.pnlContainer.Controls.Add(this.txtMasterNo);
            this.pnlContainer.Controls.Add(this.cboPersonInCharge);
            this.pnlContainer.Controls.Add(this.stcWorkOrderNo);
            this.pnlContainer.Controls.Add(this.txtOnHand);
            this.pnlContainer.Controls.Add(this.txtTotalQty);
            this.pnlContainer.Controls.Add(this.fpLotNoList);
            this.pnlContainer.Controls.Add(this.txtPartNo);
            this.pnlContainer.Controls.Add(this.txtPackNo);
            this.pnlContainer.Controls.Add(this.stcWorkResultDate);
            this.pnlContainer.Controls.Add(this.dtPackingDate);
            this.pnlContainer.Controls.Add(this.stcWorkResultNo);
            this.pnlContainer.Controls.Add(this.stcReqWorkResultDate);
            this.pnlContainer.Controls.Add(this.evoLabel6);
            this.pnlContainer.Controls.Add(this.evoLabel5);
            this.pnlContainer.Controls.Add(this.evoLabel3);
            this.pnlContainer.Controls.Add(this.stcRemark);
            this.pnlContainer.Controls.Add(this.lblPackingNo);
            this.pnlContainer.Controls.Add(this.txtRemark);
            this.pnlContainer.Controls.Add(this.evoLabel2);
            this.pnlContainer.Controls.Add(this.evoLabel4);
            this.pnlContainer.Controls.Add(this.stcItemCode);
            this.pnlContainer.Controls.Add(this.stcOrderLoc);
            this.pnlContainer.Controls.Add(this.stcItemDesc);
            this.pnlContainer.Controls.Add(this.tlpHeader2);
            this.pnlContainer.Controls.Add(this.stcHead);
            this.pnlContainer.Controls.Add(this.stcReqItemCode);
            this.pnlContainer.Controls.Add(this.cboSourceProcess);
            this.pnlContainer.Controls.Add(this.hiddenNGTransactionID);
            this.pnlContainer.Controls.Add(this.hiddenReserveTransID);
            this.pnlContainer.Controls.Add(this.hiddenTransactionID);
            this.pnlContainer.Controls.Add(this.txtCustomerName);
            this.pnlContainer.Controls.Add(this.lblShift);
            this.pnlContainer.Controls.Add(this.evoLabel1);
            this.pnlContainer.Controls.Add(this.cboShift);
            this.pnlContainer.Controls.Add(this.btnSearchMasterNo);
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlContainer.Size = new System.Drawing.Size(844, 651);
            // 
            // stcWorkResultNo
            // 
            this.stcWorkResultNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stcWorkResultNo.AppearanceName = "";
            this.stcWorkResultNo.AutoSize = true;
            this.stcWorkResultNo.ControlID = "";
            this.stcWorkResultNo.Location = new System.Drawing.Point(357, 16);
            this.stcWorkResultNo.Name = "stcWorkResultNo";
            this.stcWorkResultNo.PathString = null;
            this.stcWorkResultNo.PathValue = "Transaction No.";
            this.stcWorkResultNo.Size = new System.Drawing.Size(121, 19);
            this.stcWorkResultNo.TabIndex = 0;
            this.stcWorkResultNo.Text = "Transaction No.";
            // 
            // stcWorkResultDate
            // 
            this.stcWorkResultDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stcWorkResultDate.AppearanceName = "";
            this.stcWorkResultDate.ControlID = "";
            this.stcWorkResultDate.Location = new System.Drawing.Point(357, 46);
            this.stcWorkResultDate.Name = "stcWorkResultDate";
            this.stcWorkResultDate.PathString = null;
            this.stcWorkResultDate.PathValue = "Packing Date";
            this.stcWorkResultDate.Size = new System.Drawing.Size(124, 33);
            this.stcWorkResultDate.TabIndex = 1;
            this.stcWorkResultDate.Text = "Packing Date";
            this.stcWorkResultDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPackingNo
            // 
            this.lblPackingNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPackingNo.AppearanceName = "";
            this.lblPackingNo.ControlID = "";
            this.lblPackingNo.Location = new System.Drawing.Point(482, 16);
            this.lblPackingNo.Name = "lblPackingNo";
            this.lblPackingNo.PathString = "PACKING_NO.Value";
            this.lblPackingNo.PathValue = "";
            this.lblPackingNo.Size = new System.Drawing.Size(350, 19);
            this.lblPackingNo.TabIndex = 0;
            // 
            // dtPackingDate
            // 
            this.dtPackingDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtPackingDate.AppearanceName = "";
            this.dtPackingDate.AppearanceReadOnlyName = "";
            this.dtPackingDate.BackColor = System.Drawing.Color.Transparent;
            this.dtPackingDate.ControlID = "";
            this.dtPackingDate.Format = "dd/MM/yyyy";
            this.dtPackingDate.Location = new System.Drawing.Point(486, 49);
            this.dtPackingDate.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtPackingDate.Name = "dtPackingDate";
            this.dtPackingDate.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtPackingDate.NZValue")));
            this.dtPackingDate.PathString = "PACKING_DATE.Value";
            this.dtPackingDate.PathValue = ((object)(resources.GetObject("dtPackingDate.PathValue")));
            this.dtPackingDate.ReadOnly = false;
            this.dtPackingDate.ShowButton = true;
            this.dtPackingDate.Size = new System.Drawing.Size(126, 20);
            this.dtPackingDate.TabIndex = 1;
            this.dtPackingDate.Value = null;
            this.dtPackingDate.ValueChanged += new System.EventHandler(this.dtWorkResultDate_ValueChanged);
            // 
            // stcReqWorkResultDate
            // 
            this.stcReqWorkResultDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stcReqWorkResultDate.AppearanceName = "RequireText";
            this.stcReqWorkResultDate.AutoSize = true;
            this.stcReqWorkResultDate.ControlID = "";
            this.stcReqWorkResultDate.Location = new System.Drawing.Point(333, 53);
            this.stcReqWorkResultDate.Name = "stcReqWorkResultDate";
            this.stcReqWorkResultDate.PathString = null;
            this.stcReqWorkResultDate.PathValue = "*";
            this.stcReqWorkResultDate.Size = new System.Drawing.Size(18, 19);
            this.stcReqWorkResultDate.TabIndex = 3;
            this.stcReqWorkResultDate.Text = "*";
            // 
            // stcHead
            // 
            this.stcHead.AppearanceName = "Title";
            this.stcHead.AutoSize = true;
            this.stcHead.ControlID = "";
            this.stcHead.Location = new System.Drawing.Point(10, 21);
            this.stcHead.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.stcHead.Name = "stcHead";
            this.stcHead.PathString = null;
            this.stcHead.PathValue = "Packing Entry";
            this.stcHead.Size = new System.Drawing.Size(105, 19);
            this.stcHead.TabIndex = 37;
            this.stcHead.Text = "Packing Entry";
            // 
            // tlpHeader2
            // 
            this.tlpHeader2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpHeader2.AutoSize = true;
            this.tlpHeader2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tlpHeader2.BackgroundImage")));
            this.tlpHeader2.ColumnCount = 1;
            this.tlpHeader2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpHeader2.Controls.Add(this.stcReceiveInfo, 0, 0);
            this.tlpHeader2.Location = new System.Drawing.Point(9, 79);
            this.tlpHeader2.Margin = new System.Windows.Forms.Padding(0);
            this.tlpHeader2.Name = "tlpHeader2";
            this.tlpHeader2.RowCount = 1;
            this.tlpHeader2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHeader2.Size = new System.Drawing.Size(823, 19);
            this.tlpHeader2.TabIndex = 10;
            // 
            // stcReceiveInfo
            // 
            this.stcReceiveInfo.AppearanceName = "Header";
            this.stcReceiveInfo.AutoSize = true;
            this.stcReceiveInfo.ControlID = "";
            this.stcReceiveInfo.Location = new System.Drawing.Point(0, 0);
            this.stcReceiveInfo.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.stcReceiveInfo.Name = "stcReceiveInfo";
            this.stcReceiveInfo.PathString = null;
            this.stcReceiveInfo.PathValue = "Packing Information";
            this.stcReceiveInfo.Size = new System.Drawing.Size(152, 19);
            this.stcReceiveInfo.TabIndex = 0;
            this.stcReceiveInfo.Text = "Packing Information";
            // 
            // stcItemCode
            // 
            this.stcItemCode.AppearanceName = "";
            this.stcItemCode.ControlID = "";
            this.stcItemCode.Location = new System.Drawing.Point(362, 104);
            this.stcItemCode.Name = "stcItemCode";
            this.stcItemCode.PathString = null;
            this.stcItemCode.PathValue = "Part No.";
            this.stcItemCode.Size = new System.Drawing.Size(69, 35);
            this.stcItemCode.TabIndex = 1;
            this.stcItemCode.Text = "Part No.";
            this.stcItemCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcItemDesc
            // 
            this.stcItemDesc.AppearanceName = "";
            this.stcItemDesc.ControlID = "";
            this.stcItemDesc.Location = new System.Drawing.Point(34, 138);
            this.stcItemDesc.Name = "stcItemDesc";
            this.stcItemDesc.PathString = null;
            this.stcItemDesc.PathValue = "Customer Name";
            this.stcItemDesc.Size = new System.Drawing.Size(147, 33);
            this.stcItemDesc.TabIndex = 1;
            this.stcItemDesc.Text = "Customer Name";
            this.stcItemDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcReqItemCode
            // 
            this.stcReqItemCode.AppearanceName = "RequireText";
            this.stcReqItemCode.AutoSize = true;
            this.stcReqItemCode.ControlID = "";
            this.stcReqItemCode.Location = new System.Drawing.Point(10, 112);
            this.stcReqItemCode.Name = "stcReqItemCode";
            this.stcReqItemCode.PathString = null;
            this.stcReqItemCode.PathValue = "*";
            this.stcReqItemCode.Size = new System.Drawing.Size(18, 19);
            this.stcReqItemCode.TabIndex = 3;
            this.stcReqItemCode.Text = "*";
            this.stcReqItemCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcOrderLoc
            // 
            this.stcOrderLoc.AppearanceName = "";
            this.stcOrderLoc.ControlID = "";
            this.stcOrderLoc.Location = new System.Drawing.Point(5, 427);
            this.stcOrderLoc.Name = "stcOrderLoc";
            this.stcOrderLoc.PathString = null;
            this.stcOrderLoc.PathValue = "Process";
            this.stcOrderLoc.Size = new System.Drawing.Size(74, 33);
            this.stcOrderLoc.TabIndex = 1;
            this.stcOrderLoc.Text = "Process";
            this.stcOrderLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.stcOrderLoc.Visible = false;
            // 
            // stcRemark
            // 
            this.stcRemark.AppearanceName = "";
            this.stcRemark.ControlID = "";
            this.stcRemark.Location = new System.Drawing.Point(34, 548);
            this.stcRemark.Name = "stcRemark";
            this.stcRemark.PathString = null;
            this.stcRemark.PathValue = "Remark";
            this.stcRemark.Size = new System.Drawing.Size(96, 33);
            this.stcRemark.TabIndex = 1;
            this.stcRemark.Text = "Remark";
            this.stcRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.AppearanceName = "";
            this.txtCustomerName.AppearanceReadOnlyName = "";
            this.txtCustomerName.ControlID = "";
            this.txtCustomerName.DisableRestrictChar = false;
            this.txtCustomerName.HelpButton = null;
            this.txtCustomerName.Location = new System.Drawing.Point(187, 141);
            this.txtCustomerName.MaxLength = 100;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.PathString = "CUSTOMER_NAME.Value";
            this.txtCustomerName.PathValue = "";
            this.txtCustomerName.Size = new System.Drawing.Size(606, 27);
            this.txtCustomerName.TabIndex = 5;
            // 
            // btnSearchMasterNo
            // 
            this.btnSearchMasterNo.AppearanceName = "";
            this.btnSearchMasterNo.AutoSize = true;
            this.btnSearchMasterNo.BackgroundImage = global::Rubik.Forms.Properties.Resources.VIEW;
            this.btnSearchMasterNo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchMasterNo.ControlID = null;
            this.btnSearchMasterNo.Location = new System.Drawing.Point(323, 107);
            this.btnSearchMasterNo.Name = "btnSearchMasterNo";
            this.btnSearchMasterNo.Size = new System.Drawing.Size(34, 29);
            this.btnSearchMasterNo.TabIndex = 3;
            this.btnSearchMasterNo.TabStop = false;
            this.btnSearchMasterNo.UseVisualStyleBackColor = true;
            this.btnSearchMasterNo.Click += new System.EventHandler(this.btnItemCode_Click);
            // 
            // cboSourceProcess
            // 
            this.cboSourceProcess.AppearanceName = "";
            this.cboSourceProcess.AppearanceReadOnlyName = "";
            this.cboSourceProcess.ControlID = null;
            this.cboSourceProcess.DropDownHeight = 180;
            this.cboSourceProcess.FormattingEnabled = true;
            this.cboSourceProcess.IntegralHeight = false;
            this.cboSourceProcess.Location = new System.Drawing.Point(4, 463);
            this.cboSourceProcess.Name = "cboSourceProcess";
            this.cboSourceProcess.PathString = "SOURCE_LOC.Value";
            this.cboSourceProcess.PathValue = null;
            this.cboSourceProcess.Size = new System.Drawing.Size(131, 27);
            this.cboSourceProcess.TabIndex = 7;
            this.cboSourceProcess.Visible = false;
            this.cboSourceProcess.SelectedIndexChanged += new System.EventHandler(this.cboOrderLoc_SelectedIndexChanged);
            // 
            // txtRemark
            // 
            this.txtRemark.AppearanceName = "";
            this.txtRemark.AppearanceReadOnlyName = "";
            this.txtRemark.ControlID = "";
            this.txtRemark.DisableRestrictChar = false;
            this.txtRemark.HelpButton = null;
            this.txtRemark.Location = new System.Drawing.Point(187, 552);
            this.txtRemark.MaxLength = 255;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.PathString = "REMARK.Value";
            this.txtRemark.PathValue = "";
            this.txtRemark.Size = new System.Drawing.Size(606, 80);
            this.txtRemark.TabIndex = 13;
            this.txtRemark.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRemark_KeyPress);
            // 
            // lblShift
            // 
            this.lblShift.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShift.AppearanceName = "";
            this.lblShift.ControlID = "";
            this.lblShift.Location = new System.Drawing.Point(636, 46);
            this.lblShift.Name = "lblShift";
            this.lblShift.PathString = null;
            this.lblShift.PathValue = "Shift";
            this.lblShift.Size = new System.Drawing.Size(44, 33);
            this.lblShift.TabIndex = 1;
            this.lblShift.Text = "Shift";
            this.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboShift
            // 
            this.cboShift.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboShift.AppearanceName = "";
            this.cboShift.AppearanceReadOnlyName = "";
            this.cboShift.ControlID = "";
            this.cboShift.DropDownHeight = 180;
            this.cboShift.FormattingEnabled = true;
            this.cboShift.IntegralHeight = false;
            this.cboShift.Location = new System.Drawing.Point(682, 49);
            this.cboShift.MaxLength = 50;
            this.cboShift.Name = "cboShift";
            this.cboShift.PathString = "SHIFT_CLS.Value";
            this.cboShift.PathValue = null;
            this.cboShift.Size = new System.Drawing.Size(150, 27);
            this.cboShift.TabIndex = 2;
            // 
            // evoLabel1
            // 
            this.evoLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.evoLabel1.AppearanceName = "RequireText";
            this.evoLabel1.AutoSize = true;
            this.evoLabel1.ControlID = "";
            this.evoLabel1.Location = new System.Drawing.Point(618, 53);
            this.evoLabel1.Name = "evoLabel1";
            this.evoLabel1.PathString = null;
            this.evoLabel1.PathValue = "*";
            this.evoLabel1.Size = new System.Drawing.Size(18, 19);
            this.evoLabel1.TabIndex = 3;
            this.evoLabel1.Text = "*";
            this.evoLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // hiddenTransactionID
            // 
            this.hiddenTransactionID.AppearanceName = "";
            this.hiddenTransactionID.AutoSize = true;
            this.hiddenTransactionID.ControlID = "";
            this.hiddenTransactionID.Location = new System.Drawing.Point(5, 398);
            this.hiddenTransactionID.Name = "hiddenTransactionID";
            this.hiddenTransactionID.PathString = "TRANS_ID.Value";
            this.hiddenTransactionID.PathValue = "hiddenTransID";
            this.hiddenTransactionID.Size = new System.Drawing.Size(114, 19);
            this.hiddenTransactionID.TabIndex = 100000;
            this.hiddenTransactionID.Text = "hiddenTransID";
            this.hiddenTransactionID.Visible = false;
            // 
            // hiddenNGTransactionID
            // 
            this.hiddenNGTransactionID.AppearanceName = "";
            this.hiddenNGTransactionID.AutoSize = true;
            this.hiddenNGTransactionID.ControlID = "";
            this.hiddenNGTransactionID.Location = new System.Drawing.Point(4, 357);
            this.hiddenNGTransactionID.Name = "hiddenNGTransactionID";
            this.hiddenNGTransactionID.PathString = "NGTransactionID.Value";
            this.hiddenNGTransactionID.PathValue = "hiddenNGTrans";
            this.hiddenNGTransactionID.Size = new System.Drawing.Size(119, 19);
            this.hiddenNGTransactionID.TabIndex = 100001;
            this.hiddenNGTransactionID.Text = "hiddenNGTrans";
            this.hiddenNGTransactionID.Visible = false;
            // 
            // hiddenReserveTransID
            // 
            this.hiddenReserveTransID.AppearanceName = "";
            this.hiddenReserveTransID.AutoSize = true;
            this.hiddenReserveTransID.ControlID = "";
            this.hiddenReserveTransID.Location = new System.Drawing.Point(9, 379);
            this.hiddenReserveTransID.Name = "hiddenReserveTransID";
            this.hiddenReserveTransID.PathString = "ReserveTransactionID.Value";
            this.hiddenReserveTransID.PathValue = "hiddenReserveTransID";
            this.hiddenReserveTransID.Size = new System.Drawing.Size(169, 19);
            this.hiddenReserveTransID.TabIndex = 100000;
            this.hiddenReserveTransID.Text = "hiddenReserveTransID";
            this.hiddenReserveTransID.Visible = false;
            // 
            // evoLabel4
            // 
            this.evoLabel4.AppearanceName = "";
            this.evoLabel4.ControlID = "";
            this.evoLabel4.Location = new System.Drawing.Point(34, 104);
            this.evoLabel4.Name = "evoLabel4";
            this.evoLabel4.PathString = null;
            this.evoLabel4.PathValue = "Master No.";
            this.evoLabel4.Size = new System.Drawing.Size(96, 35);
            this.evoLabel4.TabIndex = 1;
            this.evoLabel4.Text = "Master No.";
            this.evoLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPartNo
            // 
            this.txtPartNo.AppearanceName = "";
            this.txtPartNo.AppearanceReadOnlyName = "";
            this.txtPartNo.ControlID = "";
            this.txtPartNo.DisableRestrictChar = false;
            this.txtPartNo.HelpButton = null;
            this.txtPartNo.Location = new System.Drawing.Point(437, 109);
            this.txtPartNo.MaxLength = 50;
            this.txtPartNo.Name = "txtPartNo";
            this.txtPartNo.PathString = "PART_NO.Value";
            this.txtPartNo.PathValue = "";
            this.txtPartNo.Size = new System.Drawing.Size(356, 27);
            this.txtPartNo.TabIndex = 4;
            // 
            // evoLabel2
            // 
            this.evoLabel2.AppearanceName = "";
            this.evoLabel2.ControlID = "";
            this.evoLabel2.Location = new System.Drawing.Point(34, 170);
            this.evoLabel2.Name = "evoLabel2";
            this.evoLabel2.PathString = null;
            this.evoLabel2.PathValue = "Pack No.";
            this.evoLabel2.Size = new System.Drawing.Size(96, 33);
            this.evoLabel2.TabIndex = 1;
            this.evoLabel2.Text = "Pack No.";
            this.evoLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPackNo
            // 
            this.txtPackNo.AppearanceName = "";
            this.txtPackNo.AppearanceReadOnlyName = "";
            this.txtPackNo.ControlID = "";
            this.txtPackNo.DisableRestrictChar = false;
            this.txtPackNo.HelpButton = null;
            this.txtPackNo.Location = new System.Drawing.Point(187, 174);
            this.txtPackNo.MaxLength = 100;
            this.txtPackNo.Name = "txtPackNo";
            this.txtPackNo.PathString = "PACK_NO.Value";
            this.txtPackNo.PathValue = "";
            this.txtPackNo.Size = new System.Drawing.Size(606, 27);
            this.txtPackNo.TabIndex = 6;
            this.txtPackNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtPackNo_Validating);
            // 
            // fpLotNoList
            // 
            this.fpLotNoList.About = "2.5.2015.2005";
            this.fpLotNoList.AccessibleDescription = "fpLotNoList, Sheet1";
            this.fpLotNoList.BackColor = System.Drawing.Color.AliceBlue;
            this.fpLotNoList.ContextMenuStrip = this.cmsOperation;
            this.fpLotNoList.EditModeReplace = true;
            this.fpLotNoList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpLotNoList.Location = new System.Drawing.Point(187, 307);
            this.fpLotNoList.Name = "fpLotNoList";
            this.fpLotNoList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpLotNoList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpLotNoList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtLotNoList});
            this.fpLotNoList.Size = new System.Drawing.Size(606, 206);
            this.fpLotNoList.TabIndex = 11;
            this.fpLotNoList.TabStop = false;
            this.fpLotNoList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpLotNoList.EditModeOff += new System.EventHandler(this.fpLotNoList_EditModeOff);
            this.fpLotNoList.LeaveCell += new FarPoint.Win.Spread.LeaveCellEventHandler(this.fpLotNoList_LeaveCell);
            this.fpLotNoList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpLotNoList_KeyDown);
            this.fpLotNoList.Validating += new System.ComponentModel.CancelEventHandler(this.fpLotNoList_Validating);
            // 
            // shtLotNoList
            // 
            this.shtLotNoList.Reset();
            this.shtLotNoList.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtLotNoList.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtLotNoList.ColumnCount = 4;
            this.shtLotNoList.RowCount = 0;
            this.shtLotNoList.AutoGenerateColumns = false;
            this.shtLotNoList.ColumnHeader.Cells.Get(0, 0).Value = "TRANS ID";
            this.shtLotNoList.ColumnHeader.Cells.Get(0, 1).Value = "Lot No.";
            this.shtLotNoList.ColumnHeader.Cells.Get(0, 2).Value = "Customer Lot No.";
            this.shtLotNoList.ColumnHeader.Cells.Get(0, 3).Value = "Qty";
            this.shtLotNoList.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtLotNoList.Columns.Get(0).Label = "TRANS ID";
            this.shtLotNoList.Columns.Get(0).Visible = false;
            this.shtLotNoList.Columns.Get(0).Width = 72F;
            textCellType1.MaxLength = 50;
            this.shtLotNoList.Columns.Get(1).CellType = textCellType1;
            this.shtLotNoList.Columns.Get(1).Label = "Lot No.";
            this.shtLotNoList.Columns.Get(1).Tag = "Lot No.";
            this.shtLotNoList.Columns.Get(1).Width = 150F;
            textCellType2.MaxLength = 50;
            this.shtLotNoList.Columns.Get(2).CellType = textCellType2;
            this.shtLotNoList.Columns.Get(2).Label = "Customer Lot No.";
            this.shtLotNoList.Columns.Get(2).Tag = "Customer Lot No.";
            this.shtLotNoList.Columns.Get(2).Width = 150F;
            this.shtLotNoList.Columns.Get(3).Label = "Qty";
            this.shtLotNoList.Columns.Get(3).Tag = "Qty";
            this.shtLotNoList.Columns.Get(3).Width = 150F;
            this.shtLotNoList.DataAutoCellTypes = false;
            this.shtLotNoList.DataAutoHeadings = false;
            this.shtLotNoList.DataAutoSizeColumns = false;
            this.shtLotNoList.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.shtLotNoList.RowHeader.Columns.Default.Resizable = true;
            this.shtLotNoList.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.shtLotNoList.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.shtLotNoList.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpLotNoList.SetActiveViewport(0, 1, 0);
            // 
            // evoLabel3
            // 
            this.evoLabel3.AppearanceName = "";
            this.evoLabel3.ControlID = "";
            this.evoLabel3.Location = new System.Drawing.Point(34, 307);
            this.evoLabel3.Name = "evoLabel3";
            this.evoLabel3.PathString = null;
            this.evoLabel3.PathValue = "Lot Information";
            this.evoLabel3.Size = new System.Drawing.Size(147, 33);
            this.evoLabel3.TabIndex = 1;
            this.evoLabel3.Text = "Lot Information";
            this.evoLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // evoLabel5
            // 
            this.evoLabel5.AppearanceName = "";
            this.evoLabel5.ControlID = "";
            this.evoLabel5.Location = new System.Drawing.Point(33, 519);
            this.evoLabel5.Name = "evoLabel5";
            this.evoLabel5.PathString = null;
            this.evoLabel5.PathValue = "Total Qty";
            this.evoLabel5.Size = new System.Drawing.Size(96, 25);
            this.evoLabel5.TabIndex = 1;
            this.evoLabel5.Text = "Total Qty";
            this.evoLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.AllowNegative = true;
            this.txtTotalQty.AppearanceName = "";
            this.txtTotalQty.AppearanceReadOnlyName = "";
            this.txtTotalQty.ControlID = "";
            this.txtTotalQty.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalQty.DecimalPoint = '.';
            this.txtTotalQty.DigitsInGroup = 3;
            this.txtTotalQty.Double = 0D;
            this.txtTotalQty.FixDecimalPosition = false;
            this.txtTotalQty.Flags = 0;
            this.txtTotalQty.GroupSeparator = ',';
            this.txtTotalQty.Int = 0;
            this.txtTotalQty.Location = new System.Drawing.Point(187, 519);
            this.txtTotalQty.Long = ((long)(0));
            this.txtTotalQty.MaxDecimalPlaces = 4;
            this.txtTotalQty.MaxWholeDigits = 9;
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.NegativeSign = '-';
            this.txtTotalQty.PathString = "TOTAL_QTY.Value";
            this.txtTotalQty.PathValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalQty.Prefix = "";
            this.txtTotalQty.RangeMax = 1.7976931348623157E+308D;
            this.txtTotalQty.RangeMin = -1.7976931348623157E+308D;
            this.txtTotalQty.ReadOnly = true;
            this.txtTotalQty.Size = new System.Drawing.Size(263, 27);
            this.txtTotalQty.TabIndex = 12;
            this.txtTotalQty.Text = "0";
            // 
            // evoLabel6
            // 
            this.evoLabel6.AppearanceName = "";
            this.evoLabel6.ControlID = "";
            this.evoLabel6.Location = new System.Drawing.Point(34, 241);
            this.evoLabel6.Name = "evoLabel6";
            this.evoLabel6.PathString = null;
            this.evoLabel6.PathValue = "On Hand Qty";
            this.evoLabel6.Size = new System.Drawing.Size(96, 25);
            this.evoLabel6.TabIndex = 1;
            this.evoLabel6.Text = "On Hand Qty";
            this.evoLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOnHand
            // 
            this.txtOnHand.AllowNegative = true;
            this.txtOnHand.AppearanceName = "";
            this.txtOnHand.AppearanceReadOnlyName = "";
            this.txtOnHand.ControlID = "";
            this.txtOnHand.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOnHand.DecimalPoint = '.';
            this.txtOnHand.DigitsInGroup = 3;
            this.txtOnHand.Double = 0D;
            this.txtOnHand.FixDecimalPosition = false;
            this.txtOnHand.Flags = 0;
            this.txtOnHand.GroupSeparator = ',';
            this.txtOnHand.Int = 0;
            this.txtOnHand.Location = new System.Drawing.Point(187, 240);
            this.txtOnHand.Long = ((long)(0));
            this.txtOnHand.MaxDecimalPlaces = 4;
            this.txtOnHand.MaxWholeDigits = 9;
            this.txtOnHand.Name = "txtOnHand";
            this.txtOnHand.NegativeSign = '-';
            this.txtOnHand.PathString = null;
            this.txtOnHand.PathValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOnHand.Prefix = "";
            this.txtOnHand.RangeMax = 1.7976931348623157E+308D;
            this.txtOnHand.RangeMin = -1.7976931348623157E+308D;
            this.txtOnHand.ReadOnly = true;
            this.txtOnHand.Size = new System.Drawing.Size(263, 27);
            this.txtOnHand.TabIndex = 8;
            this.txtOnHand.Text = "0";
            // 
            // stcWorkOrderNo
            // 
            this.stcWorkOrderNo.AppearanceName = "";
            this.stcWorkOrderNo.ControlID = "";
            this.stcWorkOrderNo.Location = new System.Drawing.Point(34, 204);
            this.stcWorkOrderNo.Name = "stcWorkOrderNo";
            this.stcWorkOrderNo.PathString = null;
            this.stcWorkOrderNo.PathValue = "Person In Charge";
            this.stcWorkOrderNo.Size = new System.Drawing.Size(133, 33);
            this.stcWorkOrderNo.TabIndex = 100012;
            this.stcWorkOrderNo.Text = "Person In Charge";
            this.stcWorkOrderNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboPersonInCharge
            // 
            this.cboPersonInCharge.AppearanceName = "";
            this.cboPersonInCharge.AppearanceReadOnlyName = "";
            this.cboPersonInCharge.ControlID = null;
            this.cboPersonInCharge.DropDownHeight = 180;
            this.cboPersonInCharge.FormattingEnabled = true;
            this.cboPersonInCharge.IntegralHeight = false;
            this.cboPersonInCharge.Location = new System.Drawing.Point(187, 207);
            this.cboPersonInCharge.Name = "cboPersonInCharge";
            this.cboPersonInCharge.PathString = "PERSON_IN_CHARGE.Value";
            this.cboPersonInCharge.PathValue = null;
            this.cboPersonInCharge.Size = new System.Drawing.Size(606, 27);
            this.cboPersonInCharge.TabIndex = 7;
            // 
            // txtMasterNo
            // 
            this.txtMasterNo.AllowNegative = true;
            this.txtMasterNo.AppearanceName = "";
            this.txtMasterNo.AppearanceReadOnlyName = "";
            this.txtMasterNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMasterNo.CheckEmpty = true;
            this.txtMasterNo.CheckExist = false;
            this.txtMasterNo.CheckNotExist = true;
            this.txtMasterNo.ControlID = "";
            this.txtMasterNo.CustomerCode = null;
            this.txtMasterNo.CustomerNameTextBox = this.txtCustomerName;
            this.txtMasterNo.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMasterNo.DecimalPoint = '.';
            this.txtMasterNo.DescriptionTextBox = this.txtPartNo;
            this.txtMasterNo.DigitsInGroup = 0;
            this.txtMasterNo.Double = 0D;
            this.txtMasterNo.FixDecimalPosition = false;
            this.txtMasterNo.Flags = 0;
            this.txtMasterNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtMasterNo.GroupSeparator = ',';
            this.txtMasterNo.HelpButton = this.btnSearchMasterNo;
            this.txtMasterNo.Int = 0;
            this.txtMasterNo.ItemType = null;
            this.txtMasterNo.Location = new System.Drawing.Point(187, 109);
            this.txtMasterNo.Long = ((long)(0));
            this.txtMasterNo.MaxDecimalPlaces = 0;
            this.txtMasterNo.MaxLength = 10;
            this.txtMasterNo.MaxWholeDigits = 10;
            this.txtMasterNo.Name = "txtMasterNo";
            this.txtMasterNo.NegativeSign = '-';
            this.txtMasterNo.PathString = "MASTER_NO.Value";
            this.txtMasterNo.PathValue = "0";
            this.txtMasterNo.Prefix = "";
            this.txtMasterNo.RangeMax = 9999999999D;
            this.txtMasterNo.RangeMin = 0D;
            this.txtMasterNo.SelectedCustomerData = null;
            this.txtMasterNo.SelectedItemData = null;
            this.txtMasterNo.SelectedItemProcessData = null;
            this.txtMasterNo.Size = new System.Drawing.Size(130, 26);
            this.txtMasterNo.SqlOperator = Rubik.eSqlOperator.In;
            this.txtMasterNo.TabIndex = 3;
            this.txtMasterNo.Text = "0";
            this.txtMasterNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMasterNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtMasterNo_Validating);
            // 
            // cboDescProcess
            // 
            this.cboDescProcess.AppearanceName = "";
            this.cboDescProcess.AppearanceReadOnlyName = "";
            this.cboDescProcess.ControlID = null;
            this.cboDescProcess.DropDownHeight = 180;
            this.cboDescProcess.FormattingEnabled = true;
            this.cboDescProcess.IntegralHeight = false;
            this.cboDescProcess.Location = new System.Drawing.Point(4, 492);
            this.cboDescProcess.Name = "cboDescProcess";
            this.cboDescProcess.PathString = "DEST_LOC.Value";
            this.cboDescProcess.PathValue = null;
            this.cboDescProcess.Size = new System.Drawing.Size(131, 27);
            this.cboDescProcess.TabIndex = 100015;
            this.cboDescProcess.Visible = false;
            // 
            // evoLabel7
            // 
            this.evoLabel7.AppearanceName = "RequireText";
            this.evoLabel7.AutoSize = true;
            this.evoLabel7.ControlID = "";
            this.evoLabel7.Location = new System.Drawing.Point(10, 177);
            this.evoLabel7.Name = "evoLabel7";
            this.evoLabel7.PathString = null;
            this.evoLabel7.PathValue = "*";
            this.evoLabel7.Size = new System.Drawing.Size(18, 19);
            this.evoLabel7.TabIndex = 100016;
            this.evoLabel7.Text = "*";
            this.evoLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // evoLabel8
            // 
            this.evoLabel8.AppearanceName = "RequireText";
            this.evoLabel8.AutoSize = true;
            this.evoLabel8.ControlID = "";
            this.evoLabel8.Location = new System.Drawing.Point(9, 314);
            this.evoLabel8.Name = "evoLabel8";
            this.evoLabel8.PathString = null;
            this.evoLabel8.PathValue = "*";
            this.evoLabel8.Size = new System.Drawing.Size(18, 19);
            this.evoLabel8.TabIndex = 100016;
            this.evoLabel8.Text = "*";
            this.evoLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // evoLabel9
            // 
            this.evoLabel9.AppearanceName = "";
            this.evoLabel9.ControlID = "";
            this.evoLabel9.Location = new System.Drawing.Point(34, 274);
            this.evoLabel9.Name = "evoLabel9";
            this.evoLabel9.PathString = null;
            this.evoLabel9.PathValue = "FG No.";
            this.evoLabel9.Size = new System.Drawing.Size(127, 25);
            this.evoLabel9.TabIndex = 100017;
            this.evoLabel9.Text = "FG No.";
            this.evoLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFGNo
            // 
            this.txtFGNo.AppearanceName = "";
            this.txtFGNo.AppearanceReadOnlyName = "";
            this.txtFGNo.ControlID = "";
            this.txtFGNo.DisableRestrictChar = false;
            this.txtFGNo.HelpButton = null;
            this.txtFGNo.Location = new System.Drawing.Point(187, 274);
            this.txtFGNo.MaxLength = 50;
            this.txtFGNo.Name = "txtFGNo";
            this.txtFGNo.PathString = "FG_NO.Value";
            this.txtFGNo.PathValue = "";
            this.txtFGNo.Size = new System.Drawing.Size(263, 27);
            this.txtFGNo.TabIndex = 9;
            // 
            // txtNumberOfBox
            // 
            this.txtNumberOfBox.AllowNegative = true;
            this.txtNumberOfBox.AppearanceName = "";
            this.txtNumberOfBox.AppearanceReadOnlyName = "";
            this.txtNumberOfBox.BackColor = System.Drawing.SystemColors.Window;
            this.txtNumberOfBox.ControlID = "";
            this.txtNumberOfBox.Decimal = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtNumberOfBox.DecimalPoint = '.';
            this.txtNumberOfBox.DigitsInGroup = 3;
            this.txtNumberOfBox.Double = 1D;
            this.txtNumberOfBox.FixDecimalPosition = false;
            this.txtNumberOfBox.Flags = 0;
            this.txtNumberOfBox.GroupSeparator = ',';
            this.txtNumberOfBox.Int = 1;
            this.txtNumberOfBox.Location = new System.Drawing.Point(671, 274);
            this.txtNumberOfBox.Long = ((long)(1));
            this.txtNumberOfBox.MaxDecimalPlaces = 0;
            this.txtNumberOfBox.MaxLength = 4;
            this.txtNumberOfBox.MaxWholeDigits = 4;
            this.txtNumberOfBox.Name = "txtNumberOfBox";
            this.txtNumberOfBox.NegativeSign = '-';
            this.txtNumberOfBox.PathString = null;
            this.txtNumberOfBox.PathValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtNumberOfBox.Prefix = "";
            this.txtNumberOfBox.RangeMax = 1.7976931348623157E+308D;
            this.txtNumberOfBox.RangeMin = -1.7976931348623157E+308D;
            this.txtNumberOfBox.ReadOnly = true;
            this.txtNumberOfBox.Size = new System.Drawing.Size(64, 27);
            this.txtNumberOfBox.TabIndex = 10;
            this.txtNumberOfBox.Text = "1";
            this.txtNumberOfBox.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumberOfBox_Validating);
            // 
            // evoLabel11
            // 
            this.evoLabel11.AppearanceName = "";
            this.evoLabel11.ControlID = "";
            this.evoLabel11.Location = new System.Drawing.Point(652, 274);
            this.evoLabel11.Name = "evoLabel11";
            this.evoLabel11.PathString = null;
            this.evoLabel11.PathValue = "X";
            this.evoLabel11.Size = new System.Drawing.Size(18, 25);
            this.evoLabel11.TabIndex = 100021;
            this.evoLabel11.Text = "X";
            this.evoLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // evoLabel12
            // 
            this.evoLabel12.AppearanceName = "";
            this.evoLabel12.ControlID = "";
            this.evoLabel12.Location = new System.Drawing.Point(735, 274);
            this.evoLabel12.Name = "evoLabel12";
            this.evoLabel12.PathString = null;
            this.evoLabel12.PathValue = "Boxes";
            this.evoLabel12.Size = new System.Drawing.Size(58, 25);
            this.evoLabel12.TabIndex = 100022;
            this.evoLabel12.Text = "Boxes";
            this.evoLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TRN320_PackingEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(844, 701);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 700);
            this.Name = "TRN320_PackingEntry";
            this.Text = "Packing Entry";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TRN080_FormClosed);
            this.Load += new System.EventHandler(this.TRN080_Load);
            this.Shown += new System.EventHandler(this.TRN080_Shown);
            this.Controls.SetChildIndex(this.pnlContainer, 0);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.tlpHeader2.ResumeLayout(false);
            this.tlpHeader2.PerformLayout();
            this.cmsOperation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpLotNoList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtLotNoList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EVOFramework.Windows.Forms.EVOLabel stcHead;
        private EVOFramework.Windows.Forms.EVOLabel stcWorkResultNo;
        private EVOFramework.Windows.Forms.EVOLabel stcWorkResultDate;
        private EVOFramework.Windows.Forms.EVOLabel lblPackingNo;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtPackingDate;
        private EVOFramework.Windows.Forms.EVOLabel stcReqWorkResultDate;
        private System.Windows.Forms.TableLayoutPanel tlpHeader2;
        private EVOFramework.Windows.Forms.EVOLabel stcReceiveInfo;
        private EVOFramework.Windows.Forms.EVOLabel stcItemCode;
        private EVOFramework.Windows.Forms.EVOLabel stcItemDesc;
        private EVOFramework.Windows.Forms.EVOLabel stcReqItemCode;
        private EVOFramework.Windows.Forms.EVOLabel stcOrderLoc;
        private EVOFramework.Windows.Forms.EVOLabel stcRemark;
        private EVOFramework.Windows.Forms.EVOTextBox txtCustomerName;
        private EVOFramework.Windows.Forms.EVOComboBox cboSourceProcess;
        private EVOFramework.Data.UIDataModelController dmc;
        private EVOFramework.Windows.Forms.EVOTextBox txtRemark;
        private EVOFramework.Windows.Forms.EVOButton btnSearchMasterNo;
        private EVOFramework.Windows.Forms.EVOLabel hiddenTransactionID;
        private System.Windows.Forms.ContextMenuStrip cmsOperation;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private EVOFramework.Windows.Forms.EVOLabel lblShift;
        private EVOFramework.Windows.Forms.EVOComboBox cboShift;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel1;
        private EVOFramework.Windows.Forms.EVOLabel hiddenNGTransactionID;
        private EVOFramework.Windows.Forms.EVOLabel hiddenReserveTransID;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel4;
        private EVOFramework.Windows.Forms.EVOTextBox txtPartNo;
        private EVOFramework.Windows.Forms.EVOTextBox txtPackNo;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel2;
        private FarPoint.Win.Spread.FpSpread fpLotNoList;
        private FarPoint.Win.Spread.SheetView shtLotNoList;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel3;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel5;
        private EVOFramework.Windows.Forms.EVONumericTextBox txtTotalQty;
        private EVOFramework.Windows.Forms.EVONumericTextBox txtOnHand;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel6;
        protected EVOFramework.Windows.Forms.EVOLabel stcWorkOrderNo;
        private EVOFramework.Windows.Forms.EVOComboBox cboPersonInCharge;
        private Forms.UserControl.ItemTextBox txtMasterNo;
        private EVOFramework.Windows.Forms.EVOComboBox cboDescProcess;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel8;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel7;
        private EVOFramework.Windows.Forms.EVOTextBox txtFGNo;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel9;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel12;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel11;
        private EVOFramework.Windows.Forms.EVONumericTextBox txtNumberOfBox;
    }
}
