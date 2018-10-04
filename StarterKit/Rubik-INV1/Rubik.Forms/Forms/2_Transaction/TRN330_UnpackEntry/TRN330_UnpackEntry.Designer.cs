namespace Rubik.Transaction
{
    partial class TRN330_UnpackEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TRN330_UnpackEntry));
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            this.stcWorkResultNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcWorkResultDate = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblWorkResultNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.dtWorkResultDate = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.stcReqWorkResultDate = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcHead = new EVOFramework.Windows.Forms.EVOLabel();
            this.tlpHeader2 = new System.Windows.Forms.TableLayoutPanel();
            this.stcReceiveInfo = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcItemCode = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcItemDesc = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcReqItemCode = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcRemark = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtCustomerName = new EVOFramework.Windows.Forms.EVOTextBox();
            this.btnItemCode = new EVOFramework.Windows.Forms.EVOButton();
            this.txtRemark = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblShift = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboShiftCls = new EVOFramework.Windows.Forms.EVOComboBox();
            this.evoLabel1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.cmsOperation = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dmc = new EVOFramework.Data.UIDataModelController(this.components);
            this.evoLabel4 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtPartNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.evoLabel2 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtLotNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.txtItemCode = new Rubik.Forms.UserControl.ItemTextBox();
            this.fpView = new FarPoint.Win.Spread.FpSpread();
            this.shtView = new FarPoint.Win.Spread.SheetView();
            this.evoLabel3 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoComboBox1 = new EVOFramework.Windows.Forms.EVOComboBox();
            this.stcWorkOrderNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.evoLabel6 = new EVOFramework.Windows.Forms.EVOLabel();
            this.btnGenerate = new EVOFramework.Windows.Forms.EVOButton();
            this.lblTotalQty = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtTotalQty = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.pnlContainer.SuspendLayout();
            this.tlpHeader2.SuspendLayout();
            this.cmsOperation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.txtTotalQty);
            this.pnlContainer.Controls.Add(this.lblTotalQty);
            this.pnlContainer.Controls.Add(this.btnGenerate);
            this.pnlContainer.Controls.Add(this.evoComboBox1);
            this.pnlContainer.Controls.Add(this.stcWorkOrderNo);
            this.pnlContainer.Controls.Add(this.fpView);
            this.pnlContainer.Controls.Add(this.txtPartNo);
            this.pnlContainer.Controls.Add(this.txtLotNo);
            this.pnlContainer.Controls.Add(this.stcWorkResultDate);
            this.pnlContainer.Controls.Add(this.dtWorkResultDate);
            this.pnlContainer.Controls.Add(this.stcWorkResultNo);
            this.pnlContainer.Controls.Add(this.stcReqWorkResultDate);
            this.pnlContainer.Controls.Add(this.evoLabel3);
            this.pnlContainer.Controls.Add(this.stcRemark);
            this.pnlContainer.Controls.Add(this.lblWorkResultNo);
            this.pnlContainer.Controls.Add(this.txtRemark);
            this.pnlContainer.Controls.Add(this.evoLabel2);
            this.pnlContainer.Controls.Add(this.evoLabel4);
            this.pnlContainer.Controls.Add(this.stcItemCode);
            this.pnlContainer.Controls.Add(this.stcItemDesc);
            this.pnlContainer.Controls.Add(this.tableLayoutPanel1);
            this.pnlContainer.Controls.Add(this.tlpHeader2);
            this.pnlContainer.Controls.Add(this.stcHead);
            this.pnlContainer.Controls.Add(this.stcReqItemCode);
            this.pnlContainer.Controls.Add(this.txtCustomerName);
            this.pnlContainer.Controls.Add(this.lblShift);
            this.pnlContainer.Controls.Add(this.txtItemCode);
            this.pnlContainer.Controls.Add(this.evoLabel1);
            this.pnlContainer.Controls.Add(this.cboShiftCls);
            this.pnlContainer.Controls.Add(this.btnItemCode);
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlContainer.Size = new System.Drawing.Size(844, 616);
            this.pnlContainer.Validating += new System.ComponentModel.CancelEventHandler(this.txtItemCode_Validating);
            // 
            // stcWorkResultNo
            // 
            this.stcWorkResultNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stcWorkResultNo.AppearanceName = "";
            this.stcWorkResultNo.AutoSize = true;
            this.stcWorkResultNo.ControlID = "";
            this.stcWorkResultNo.Location = new System.Drawing.Point(356, 16);
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
            this.stcWorkResultDate.PathValue = "Unpack Date";
            this.stcWorkResultDate.Size = new System.Drawing.Size(124, 33);
            this.stcWorkResultDate.TabIndex = 1;
            this.stcWorkResultDate.Text = "Unpack Date";
            this.stcWorkResultDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWorkResultNo
            // 
            this.lblWorkResultNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWorkResultNo.AppearanceName = "";
            this.lblWorkResultNo.ControlID = "";
            this.lblWorkResultNo.Location = new System.Drawing.Point(482, 16);
            this.lblWorkResultNo.Name = "lblWorkResultNo";
            this.lblWorkResultNo.PathString = "";
            this.lblWorkResultNo.PathValue = "";
            this.lblWorkResultNo.Size = new System.Drawing.Size(350, 19);
            this.lblWorkResultNo.TabIndex = 0;
            // 
            // dtWorkResultDate
            // 
            this.dtWorkResultDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtWorkResultDate.AppearanceName = "";
            this.dtWorkResultDate.AppearanceReadOnlyName = "";
            this.dtWorkResultDate.BackColor = System.Drawing.Color.Transparent;
            this.dtWorkResultDate.ControlID = "";
            this.dtWorkResultDate.Format = "dd/MM/yyyy";
            this.dtWorkResultDate.Location = new System.Drawing.Point(486, 49);
            this.dtWorkResultDate.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtWorkResultDate.Name = "dtWorkResultDate";
            this.dtWorkResultDate.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtWorkResultDate.NZValue")));
            this.dtWorkResultDate.PathString = "UNPACKING_DATE.Value";
            this.dtWorkResultDate.PathValue = ((object)(resources.GetObject("dtWorkResultDate.PathValue")));
            this.dtWorkResultDate.ReadOnly = false;
            this.dtWorkResultDate.ShowButton = true;
            this.dtWorkResultDate.Size = new System.Drawing.Size(126, 20);
            this.dtWorkResultDate.TabIndex = 0;
            this.dtWorkResultDate.Value = null;
            this.dtWorkResultDate.ValueChanged += new System.EventHandler(this.dtWorkResultDate_ValueChanged);
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
            this.stcHead.PathValue = "Unpack Entry";
            this.stcHead.Size = new System.Drawing.Size(103, 19);
            this.stcHead.TabIndex = 37;
            this.stcHead.Text = "Unpack Entry";
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
            this.stcReceiveInfo.PathValue = "Unpack Information";
            this.stcReceiveInfo.Size = new System.Drawing.Size(150, 19);
            this.stcReceiveInfo.TabIndex = 0;
            this.stcReceiveInfo.Text = "Unpack Information";
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
            // stcRemark
            // 
            this.stcRemark.AppearanceName = "";
            this.stcRemark.ControlID = "";
            this.stcRemark.Location = new System.Drawing.Point(34, 203);
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
            this.txtCustomerName.PathString = "";
            this.txtCustomerName.PathValue = "";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(606, 27);
            this.txtCustomerName.TabIndex = 4;
            // 
            // btnItemCode
            // 
            this.btnItemCode.AppearanceName = "";
            this.btnItemCode.AutoSize = true;
            this.btnItemCode.BackgroundImage = global::Rubik.Forms.Properties.Resources.VIEW;
            this.btnItemCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnItemCode.ControlID = null;
            this.btnItemCode.Location = new System.Drawing.Point(323, 107);
            this.btnItemCode.Name = "btnItemCode";
            this.btnItemCode.Size = new System.Drawing.Size(34, 29);
            this.btnItemCode.TabIndex = 5;
            this.btnItemCode.TabStop = false;
            this.btnItemCode.UseVisualStyleBackColor = true;
            // 
            // txtRemark
            // 
            this.txtRemark.AppearanceName = "";
            this.txtRemark.AppearanceReadOnlyName = "";
            this.txtRemark.ControlID = "";
            this.txtRemark.DisableRestrictChar = false;
            this.txtRemark.HelpButton = null;
            this.txtRemark.Location = new System.Drawing.Point(187, 207);
            this.txtRemark.MaxLength = 255;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.PathString = "REMARK.Value";
            this.txtRemark.PathValue = "";
            this.txtRemark.Size = new System.Drawing.Size(606, 80);
            this.txtRemark.TabIndex = 6;
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
            // cboShiftCls
            // 
            this.cboShiftCls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboShiftCls.AppearanceName = "";
            this.cboShiftCls.AppearanceReadOnlyName = "";
            this.cboShiftCls.ControlID = "";
            this.cboShiftCls.DropDownHeight = 180;
            this.cboShiftCls.FormattingEnabled = true;
            this.cboShiftCls.IntegralHeight = false;
            this.cboShiftCls.Location = new System.Drawing.Point(682, 49);
            this.cboShiftCls.MaxLength = 50;
            this.cboShiftCls.Name = "cboShiftCls";
            this.cboShiftCls.PathString = "SHIFT_CLS.Value";
            this.cboShiftCls.PathValue = null;
            this.cboShiftCls.Size = new System.Drawing.Size(150, 27);
            this.cboShiftCls.TabIndex = 1;
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
            this.duplicateToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cmsOperation.Name = "cmsOperation";
            this.cmsOperation.Size = new System.Drawing.Size(119, 70);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // duplicateToolStripMenuItem
            // 
            this.duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
            this.duplicateToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.duplicateToolStripMenuItem.Text = "Duplicate";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
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
            this.txtPartNo.Location = new System.Drawing.Point(428, 109);
            this.txtPartNo.MaxLength = 50;
            this.txtPartNo.Name = "txtPartNo";
            this.txtPartNo.PathString = null;
            this.txtPartNo.PathValue = "";
            this.txtPartNo.ReadOnly = true;
            this.txtPartNo.Size = new System.Drawing.Size(365, 27);
            this.txtPartNo.TabIndex = 3;
            // 
            // evoLabel2
            // 
            this.evoLabel2.AppearanceName = "";
            this.evoLabel2.ControlID = "";
            this.evoLabel2.Location = new System.Drawing.Point(34, 325);
            this.evoLabel2.Name = "evoLabel2";
            this.evoLabel2.PathString = null;
            this.evoLabel2.PathValue = "Lot No.";
            this.evoLabel2.Size = new System.Drawing.Size(147, 33);
            this.evoLabel2.TabIndex = 1;
            this.evoLabel2.Text = "Lot No.";
            this.evoLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLotNo
            // 
            this.txtLotNo.AppearanceName = "";
            this.txtLotNo.AppearanceReadOnlyName = "";
            this.txtLotNo.ControlID = "";
            this.txtLotNo.DisableRestrictChar = false;
            this.txtLotNo.HelpButton = null;
            this.txtLotNo.Location = new System.Drawing.Point(187, 329);
            this.txtLotNo.MaxLength = 50;
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.PathString = "LOT_NO.Value";
            this.txtLotNo.PathValue = "";
            this.txtLotNo.Size = new System.Drawing.Size(566, 27);
            this.txtLotNo.TabIndex = 7;
            // 
            // txtItemCode
            // 
            this.txtItemCode.AllowNegative = false;
            this.txtItemCode.AppearanceName = "";
            this.txtItemCode.AppearanceReadOnlyName = "";
            this.txtItemCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtItemCode.CheckEmpty = true;
            this.txtItemCode.CheckExist = false;
            this.txtItemCode.CheckNotExist = true;
            this.txtItemCode.ControlID = "";
            this.txtItemCode.CustomerCode = null;
            this.txtItemCode.CustomerNameTextBox = this.txtCustomerName;
            this.txtItemCode.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtItemCode.DecimalPoint = '.';
            this.txtItemCode.DescriptionTextBox = this.txtPartNo;
            this.txtItemCode.DigitsInGroup = 0;
            this.txtItemCode.Double = 0D;
            this.txtItemCode.FixDecimalPosition = true;
            this.txtItemCode.Flags = 65536;
            this.txtItemCode.GroupSeparator = ',';
            this.txtItemCode.HelpButton = this.btnItemCode;
            this.txtItemCode.Int = 0;
            this.txtItemCode.ItemType = null;
            this.txtItemCode.Location = new System.Drawing.Point(187, 108);
            this.txtItemCode.Long = ((long)(0));
            this.txtItemCode.MaxDecimalPlaces = 0;
            this.txtItemCode.MaxLength = 10;
            this.txtItemCode.MaxWholeDigits = 10;
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.NegativeSign = '-';
            this.txtItemCode.PathString = "ITEM_CD.Value";
            this.txtItemCode.PathValue = "";
            this.txtItemCode.Prefix = "";
            this.txtItemCode.RangeMax = 9999999999D;
            this.txtItemCode.RangeMin = 0D;
            this.txtItemCode.SelectedCustomerData = null;
            this.txtItemCode.SelectedItemData = null;
            this.txtItemCode.SelectedItemProcessData = null;
            this.txtItemCode.Size = new System.Drawing.Size(130, 27);
            this.txtItemCode.SqlOperator = Rubik.eSqlOperator.In;
            this.txtItemCode.TabIndex = 2;
            this.txtItemCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtItemCode.TextChanged += new System.EventHandler(this.txtItemCode_TextChanged);
            // 
            // fpView
            // 
            this.fpView.About = "2.5.2015.2005";
            this.fpView.AccessibleDescription = "fpView, Sheet1, Row 0, Column 0, ";
            this.fpView.BackColor = System.Drawing.Color.AliceBlue;
            this.fpView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.Location = new System.Drawing.Point(187, 362);
            this.fpView.Name = "fpView";
            this.fpView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtView});
            this.fpView.Size = new System.Drawing.Size(606, 206);
            this.fpView.TabIndex = 9;
            this.fpView.TabStop = false;
            this.fpView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.fpView_ButtonClicked);
            this.fpView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpView_KeyDown);
            this.fpView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fpView_KeyUp);
            // 
            // shtView
            // 
            this.shtView.Reset();
            this.shtView.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtView.ColumnCount = 6;
            this.shtView.RowCount = 4;
            this.shtView.AutoCalculation = false;
            this.shtView.AutoGenerateColumns = false;
            this.shtView.ColumnHeader.Cells.Get(0, 0).Value = " ";
            this.shtView.ColumnHeader.Cells.Get(0, 1).Value = "Pack No.";
            this.shtView.ColumnHeader.Cells.Get(0, 2).Value = "FG No.";
            this.shtView.ColumnHeader.Cells.Get(0, 3).Value = "Lot No.";
            this.shtView.ColumnHeader.Cells.Get(0, 4).Value = "Customer Lot No.";
            this.shtView.ColumnHeader.Cells.Get(0, 5).Value = "Qty";
            this.shtView.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtView.Columns.Get(0).CellType = checkBoxCellType1;
            this.shtView.Columns.Get(0).Label = " ";
            this.shtView.Columns.Get(0).Width = 22F;
            this.shtView.Columns.Get(1).Label = "Pack No.";
            this.shtView.Columns.Get(1).Tag = "Pack No.";
            this.shtView.Columns.Get(1).Width = 110F;
            this.shtView.Columns.Get(2).Label = "FG No.";
            this.shtView.Columns.Get(2).Tag = "FG No.";
            this.shtView.Columns.Get(2).Width = 110F;
            this.shtView.Columns.Get(3).Label = "Lot No.";
            this.shtView.Columns.Get(3).Tag = "Lot No.";
            this.shtView.Columns.Get(3).Width = 110F;
            this.shtView.Columns.Get(4).Label = "Customer Lot No.";
            this.shtView.Columns.Get(4).Tag = "Customer Lot No.";
            this.shtView.Columns.Get(4).Width = 110F;
            this.shtView.Columns.Get(5).Label = "Qty";
            this.shtView.Columns.Get(5).Tag = "Qty";
            this.shtView.Columns.Get(5).Width = 100F;
            this.shtView.DataAutoCellTypes = false;
            this.shtView.DataAutoHeadings = false;
            this.shtView.DataAutoSizeColumns = false;
            this.shtView.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.shtView.RowHeader.Columns.Default.Resizable = true;
            this.shtView.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.shtView.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // evoLabel3
            // 
            this.evoLabel3.AppearanceName = "";
            this.evoLabel3.ControlID = "";
            this.evoLabel3.Location = new System.Drawing.Point(34, 362);
            this.evoLabel3.Name = "evoLabel3";
            this.evoLabel3.PathString = null;
            this.evoLabel3.PathValue = "Pack No. List";
            this.evoLabel3.Size = new System.Drawing.Size(147, 37);
            this.evoLabel3.TabIndex = 1;
            this.evoLabel3.Text = "Pack No. List";
            this.evoLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // evoComboBox1
            // 
            this.evoComboBox1.AppearanceName = "";
            this.evoComboBox1.AppearanceReadOnlyName = "";
            this.evoComboBox1.ControlID = null;
            this.evoComboBox1.DropDownHeight = 180;
            this.evoComboBox1.FormattingEnabled = true;
            this.evoComboBox1.IntegralHeight = false;
            this.evoComboBox1.Location = new System.Drawing.Point(187, 174);
            this.evoComboBox1.Name = "evoComboBox1";
            this.evoComboBox1.PathString = "PERSON_IN_CHARGE.Value";
            this.evoComboBox1.PathValue = null;
            this.evoComboBox1.Size = new System.Drawing.Size(606, 27);
            this.evoComboBox1.TabIndex = 5;
            // 
            // stcWorkOrderNo
            // 
            this.stcWorkOrderNo.AppearanceName = "";
            this.stcWorkOrderNo.ControlID = "";
            this.stcWorkOrderNo.Location = new System.Drawing.Point(34, 171);
            this.stcWorkOrderNo.Name = "stcWorkOrderNo";
            this.stcWorkOrderNo.PathString = null;
            this.stcWorkOrderNo.PathValue = "Person In Charge";
            this.stcWorkOrderNo.Size = new System.Drawing.Size(133, 33);
            this.stcWorkOrderNo.TabIndex = 100012;
            this.stcWorkOrderNo.Text = "Person In Charge";
            this.stcWorkOrderNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 300);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(823, 25);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // evoLabel6
            // 
            this.evoLabel6.AppearanceName = "Header";
            this.evoLabel6.ControlID = "";
            this.evoLabel6.Location = new System.Drawing.Point(0, 0);
            this.evoLabel6.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.evoLabel6.Name = "evoLabel6";
            this.evoLabel6.PathString = null;
            this.evoLabel6.PathValue = "Select to Unpack";
            this.evoLabel6.Size = new System.Drawing.Size(172, 25);
            this.evoLabel6.TabIndex = 0;
            this.evoLabel6.Text = "Select to Unpack";
            // 
            // btnGenerate
            // 
            this.btnGenerate.AppearanceName = "";
            this.btnGenerate.AutoSize = true;
            this.btnGenerate.BackgroundImage = global::Rubik.Forms.Properties.Resources.REFRESH;
            this.btnGenerate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGenerate.ControlID = null;
            this.btnGenerate.Location = new System.Drawing.Point(759, 328);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(34, 29);
            this.btnGenerate.TabIndex = 8;
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.AppearanceName = "";
            this.lblTotalQty.ControlID = "";
            this.lblTotalQty.Location = new System.Drawing.Point(500, 571);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.PathString = null;
            this.lblTotalQty.PathValue = "Total Qty";
            this.lblTotalQty.Size = new System.Drawing.Size(94, 33);
            this.lblTotalQty.TabIndex = 100015;
            this.lblTotalQty.Text = "Total Qty";
            this.lblTotalQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.txtTotalQty.Location = new System.Drawing.Point(600, 574);
            this.txtTotalQty.Long = ((long)(0));
            this.txtTotalQty.MaxDecimalPlaces = 4;
            this.txtTotalQty.MaxLength = 30;
            this.txtTotalQty.MaxWholeDigits = 9;
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.NegativeSign = '-';
            this.txtTotalQty.PathString = null;
            this.txtTotalQty.PathValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalQty.Prefix = "";
            this.txtTotalQty.RangeMax = 1.7976931348623157E+308D;
            this.txtTotalQty.RangeMin = -1.7976931348623157E+308D;
            this.txtTotalQty.Size = new System.Drawing.Size(150, 27);
            this.txtTotalQty.TabIndex = 100016;
            this.txtTotalQty.Text = "0";
            // 
            // TRN330_UnpackEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(844, 666);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 700);
            this.Name = "TRN330_UnpackEntry";
            this.Text = "Unpack Entry";
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
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EVOFramework.Windows.Forms.EVOLabel stcHead;
        private EVOFramework.Windows.Forms.EVOLabel stcWorkResultNo;
        private EVOFramework.Windows.Forms.EVOLabel stcWorkResultDate;
        private EVOFramework.Windows.Forms.EVOLabel lblWorkResultNo;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtWorkResultDate;
        private EVOFramework.Windows.Forms.EVOLabel stcReqWorkResultDate;
        private System.Windows.Forms.TableLayoutPanel tlpHeader2;
        private EVOFramework.Windows.Forms.EVOLabel stcReceiveInfo;
        private EVOFramework.Windows.Forms.EVOLabel stcItemCode;
        private EVOFramework.Windows.Forms.EVOLabel stcItemDesc;
        private EVOFramework.Windows.Forms.EVOLabel stcReqItemCode;
        private EVOFramework.Windows.Forms.EVOLabel stcRemark;
        private Rubik.Forms.UserControl.ItemTextBox txtItemCode;
        private EVOFramework.Windows.Forms.EVOTextBox txtCustomerName;
        private EVOFramework.Data.UIDataModelController dmc;
        private EVOFramework.Windows.Forms.EVOTextBox txtRemark;
        private EVOFramework.Windows.Forms.EVOButton btnItemCode;
        private System.Windows.Forms.ContextMenuStrip cmsOperation;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private EVOFramework.Windows.Forms.EVOLabel lblShift;
        private EVOFramework.Windows.Forms.EVOComboBox cboShiftCls;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel1;
        private System.Windows.Forms.ToolStripMenuItem duplicateToolStripMenuItem;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel4;
        private EVOFramework.Windows.Forms.EVOTextBox txtPartNo;
        private EVOFramework.Windows.Forms.EVOTextBox txtLotNo;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel2;
        private FarPoint.Win.Spread.FpSpread fpView;
        private FarPoint.Win.Spread.SheetView shtView;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel3;
        private EVOFramework.Windows.Forms.EVOComboBox evoComboBox1;
        protected EVOFramework.Windows.Forms.EVOLabel stcWorkOrderNo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel6;
        private EVOFramework.Windows.Forms.EVOButton btnGenerate;
        private EVOFramework.Windows.Forms.EVOLabel lblTotalQty;
        private EVOFramework.Windows.Forms.EVONumericTextBox txtTotalQty;
    }
}
