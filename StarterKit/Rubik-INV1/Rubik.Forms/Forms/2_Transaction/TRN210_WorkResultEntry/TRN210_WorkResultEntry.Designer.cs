namespace Rubik.Transaction
{
    partial class TRN210_WorkResultEntry
    {

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
        protected void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TRN210_WorkResultEntry));
            this.stcWorkResultNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcWorkResultDate = new EVOFramework.Windows.Forms.EVOLabel();
            this.dtProductionReportDate = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.stcReqWorkResultDate = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcHead = new EVOFramework.Windows.Forms.EVOLabel();
            this.tlpHeader2 = new System.Windows.Forms.TableLayoutPanel();
            this.stcWorkResultInfo = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcItemCode = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcItemDesc = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcReqItemCode = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcOrderLoc = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcWorkResultQty = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcRemark = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcReqOrderLoc = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcReqGoodQty = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtMasterNo = new Rubik.Forms.UserControl.ItemTextBox();
            this.txtCustomerName = new EVOFramework.Windows.Forms.EVOTextBox();
            this.txtPartNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.btnSearchMasterNo = new EVOFramework.Windows.Forms.EVOButton();
            this.cboProcess = new EVOFramework.Windows.Forms.EVOComboBox();
            this.txtQtyKG = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.txtRemark = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblShift = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboShift = new EVOFramework.Windows.Forms.EVOComboBox();
            this.evoLabel1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel2 = new EVOFramework.Windows.Forms.EVOLabel();
            this.cmsOperation = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dmc = new EVOFramework.Data.UIDataModelController(this.components);
            this.hiddenTransactionID = new EVOFramework.Windows.Forms.EVOLabel();
            this.hiddenRefNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblUnitKGS = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtQtyPCS = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.lblUnitPCS = new EVOFramework.Windows.Forms.EVOLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.stcNGInfo = new EVOFramework.Windows.Forms.EVOLabel();
            this.fpNGInfo = new FarPoint.Win.Spread.FpSpread();
            this.shtNGInfo = new FarPoint.Win.Spread.SheetView();
            this.chkRework = new EVOFramework.Windows.Forms.EVOCheckBox();
            this.cboMachineNo = new EVOFramework.Windows.Forms.EVOComboBox();
            this.evoLabel6 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtTotalNG = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.txtOnHandQtyKG = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.evoLabel4 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtOnHandQtyPCS = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.evoLabel5 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel7 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel8 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtLotNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.stcWorkOrderNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel9 = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboPersonInCharge = new EVOFramework.Windows.Forms.EVOComboBox();
            this.txtCustLotNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.evoLabel10 = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblProductionReportNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboSupplier = new EVOFramework.Windows.Forms.EVOComboBox();
            this.lblSupplier = new EVOFramework.Windows.Forms.EVOLabel();
            this.hiddenGroupTransID = new EVOFramework.Windows.Forms.EVOLabel();
            this.pnlContainer.SuspendLayout();
            this.tlpHeader2.SuspendLayout();
            this.cmsOperation.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpNGInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtNGInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.hiddenGroupTransID);
            this.pnlContainer.Controls.Add(this.txtPartNo);
            this.pnlContainer.Controls.Add(this.cboSupplier);
            this.pnlContainer.Controls.Add(this.lblSupplier);
            this.pnlContainer.Controls.Add(this.cboPersonInCharge);
            this.pnlContainer.Controls.Add(this.txtTotalNG);
            this.pnlContainer.Controls.Add(this.cboMachineNo);
            this.pnlContainer.Controls.Add(this.chkRework);
            this.pnlContainer.Controls.Add(this.fpNGInfo);
            this.pnlContainer.Controls.Add(this.tableLayoutPanel1);
            this.pnlContainer.Controls.Add(this.evoLabel7);
            this.pnlContainer.Controls.Add(this.lblUnitPCS);
            this.pnlContainer.Controls.Add(this.evoLabel5);
            this.pnlContainer.Controls.Add(this.lblUnitKGS);
            this.pnlContainer.Controls.Add(this.stcWorkResultDate);
            this.pnlContainer.Controls.Add(this.dtProductionReportDate);
            this.pnlContainer.Controls.Add(this.lblProductionReportNo);
            this.pnlContainer.Controls.Add(this.stcWorkResultNo);
            this.pnlContainer.Controls.Add(this.stcReqWorkResultDate);
            this.pnlContainer.Controls.Add(this.stcRemark);
            this.pnlContainer.Controls.Add(this.txtRemark);
            this.pnlContainer.Controls.Add(this.evoLabel6);
            this.pnlContainer.Controls.Add(this.evoLabel4);
            this.pnlContainer.Controls.Add(this.evoLabel10);
            this.pnlContainer.Controls.Add(this.evoLabel8);
            this.pnlContainer.Controls.Add(this.stcWorkResultQty);
            this.pnlContainer.Controls.Add(this.stcReqGoodQty);
            this.pnlContainer.Controls.Add(this.txtOnHandQtyPCS);
            this.pnlContainer.Controls.Add(this.txtQtyPCS);
            this.pnlContainer.Controls.Add(this.txtOnHandQtyKG);
            this.pnlContainer.Controls.Add(this.txtQtyKG);
            this.pnlContainer.Controls.Add(this.evoLabel9);
            this.pnlContainer.Controls.Add(this.stcItemCode);
            this.pnlContainer.Controls.Add(this.stcOrderLoc);
            this.pnlContainer.Controls.Add(this.stcItemDesc);
            this.pnlContainer.Controls.Add(this.tlpHeader2);
            this.pnlContainer.Controls.Add(this.stcHead);
            this.pnlContainer.Controls.Add(this.stcReqOrderLoc);
            this.pnlContainer.Controls.Add(this.stcReqItemCode);
            this.pnlContainer.Controls.Add(this.cboProcess);
            this.pnlContainer.Controls.Add(this.hiddenRefNo);
            this.pnlContainer.Controls.Add(this.hiddenTransactionID);
            this.pnlContainer.Controls.Add(this.txtCustLotNo);
            this.pnlContainer.Controls.Add(this.txtLotNo);
            this.pnlContainer.Controls.Add(this.txtCustomerName);
            this.pnlContainer.Controls.Add(this.stcWorkOrderNo);
            this.pnlContainer.Controls.Add(this.lblShift);
            this.pnlContainer.Controls.Add(this.txtMasterNo);
            this.pnlContainer.Controls.Add(this.evoLabel1);
            this.pnlContainer.Controls.Add(this.cboShift);
            this.pnlContainer.Controls.Add(this.evoLabel2);
            this.pnlContainer.Controls.Add(this.btnSearchMasterNo);
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlContainer.Size = new System.Drawing.Size(988, 691);
            // 
            // stcWorkResultNo
            // 
            this.stcWorkResultNo.AppearanceName = "";
            this.stcWorkResultNo.AutoSize = true;
            this.stcWorkResultNo.ControlID = "";
            this.stcWorkResultNo.Location = new System.Drawing.Point(442, 16);
            this.stcWorkResultNo.Name = "stcWorkResultNo";
            this.stcWorkResultNo.PathString = null;
            this.stcWorkResultNo.PathValue = "Transaction No.";
            this.stcWorkResultNo.Size = new System.Drawing.Size(121, 19);
            this.stcWorkResultNo.TabIndex = 0;
            this.stcWorkResultNo.Text = "Transaction No.";
            // 
            // stcWorkResultDate
            // 
            this.stcWorkResultDate.AppearanceName = "";
            this.stcWorkResultDate.ControlID = "";
            this.stcWorkResultDate.Location = new System.Drawing.Point(441, 42);
            this.stcWorkResultDate.Name = "stcWorkResultDate";
            this.stcWorkResultDate.PathString = null;
            this.stcWorkResultDate.PathValue = "Production Report Date";
            this.stcWorkResultDate.Size = new System.Drawing.Size(177, 33);
            this.stcWorkResultDate.TabIndex = 1;
            this.stcWorkResultDate.Text = "Production Report Date";
            this.stcWorkResultDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtProductionReportDate
            // 
            this.dtProductionReportDate.AppearanceName = "";
            this.dtProductionReportDate.AppearanceReadOnlyName = "";
            this.dtProductionReportDate.BackColor = System.Drawing.Color.Transparent;
            this.dtProductionReportDate.ControlID = "";
            this.dtProductionReportDate.Format = "dd/MM/yyyy";
            this.dtProductionReportDate.Location = new System.Drawing.Point(624, 48);
            this.dtProductionReportDate.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtProductionReportDate.Name = "dtProductionReportDate";
            this.dtProductionReportDate.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtProductionReportDate.NZValue")));
            this.dtProductionReportDate.PathString = "PRODUCTION_REPORT_DATE.Value";
            this.dtProductionReportDate.PathValue = ((object)(resources.GetObject("dtProductionReportDate.PathValue")));
            this.dtProductionReportDate.ReadOnly = false;
            this.dtProductionReportDate.ShowButton = true;
            this.dtProductionReportDate.Size = new System.Drawing.Size(126, 20);
            this.dtProductionReportDate.TabIndex = 1;
            this.dtProductionReportDate.Value = null;
            this.dtProductionReportDate.ValueChanged += new System.EventHandler(this.dtWorkResultDate_ValueChanged);
            // 
            // stcReqWorkResultDate
            // 
            this.stcReqWorkResultDate.AppearanceName = "RequireText";
            this.stcReqWorkResultDate.AutoSize = true;
            this.stcReqWorkResultDate.ControlID = "";
            this.stcReqWorkResultDate.Location = new System.Drawing.Point(417, 48);
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
            this.stcHead.Font = new System.Drawing.Font("Tahoma", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.stcHead.Location = new System.Drawing.Point(10, 21);
            this.stcHead.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.stcHead.Name = "stcHead";
            this.stcHead.PathString = null;
            this.stcHead.PathValue = "Production Report Entry";
            this.stcHead.Size = new System.Drawing.Size(345, 33);
            this.stcHead.TabIndex = 37;
            this.stcHead.Text = "Production Report Entry";
            // 
            // tlpHeader2
            // 
            this.tlpHeader2.AutoSize = true;
            this.tlpHeader2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tlpHeader2.BackgroundImage")));
            this.tlpHeader2.ColumnCount = 1;
            this.tlpHeader2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpHeader2.Controls.Add(this.stcWorkResultInfo, 0, 0);
            this.tlpHeader2.Location = new System.Drawing.Point(9, 79);
            this.tlpHeader2.Margin = new System.Windows.Forms.Padding(0);
            this.tlpHeader2.Name = "tlpHeader2";
            this.tlpHeader2.RowCount = 1;
            this.tlpHeader2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHeader2.Size = new System.Drawing.Size(523, 19);
            this.tlpHeader2.TabIndex = 10;
            // 
            // stcWorkResultInfo
            // 
            this.stcWorkResultInfo.AppearanceName = "Header";
            this.stcWorkResultInfo.AutoSize = true;
            this.stcWorkResultInfo.ControlID = "";
            this.stcWorkResultInfo.Location = new System.Drawing.Point(0, 0);
            this.stcWorkResultInfo.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.stcWorkResultInfo.Name = "stcWorkResultInfo";
            this.stcWorkResultInfo.PathString = null;
            this.stcWorkResultInfo.PathValue = "Production Report Information";
            this.stcWorkResultInfo.Size = new System.Drawing.Size(226, 19);
            this.stcWorkResultInfo.TabIndex = 0;
            this.stcWorkResultInfo.Text = "Production Report Information";
            // 
            // stcItemCode
            // 
            this.stcItemCode.AppearanceName = "";
            this.stcItemCode.ControlID = "";
            this.stcItemCode.Location = new System.Drawing.Point(33, 106);
            this.stcItemCode.Name = "stcItemCode";
            this.stcItemCode.PathString = null;
            this.stcItemCode.PathValue = "Master No.";
            this.stcItemCode.Size = new System.Drawing.Size(133, 35);
            this.stcItemCode.TabIndex = 1;
            this.stcItemCode.Text = "Master No.";
            this.stcItemCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcItemDesc
            // 
            this.stcItemDesc.AppearanceName = "";
            this.stcItemDesc.ControlID = "";
            this.stcItemDesc.Location = new System.Drawing.Point(33, 140);
            this.stcItemDesc.Name = "stcItemDesc";
            this.stcItemDesc.PathString = null;
            this.stcItemDesc.PathValue = "Customer Name";
            this.stcItemDesc.Size = new System.Drawing.Size(133, 33);
            this.stcItemDesc.TabIndex = 1;
            this.stcItemDesc.Text = "Customer Name";
            this.stcItemDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcReqItemCode
            // 
            this.stcReqItemCode.AppearanceName = "RequireText";
            this.stcReqItemCode.AutoSize = true;
            this.stcReqItemCode.ControlID = "";
            this.stcReqItemCode.Location = new System.Drawing.Point(9, 114);
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
            this.stcOrderLoc.Location = new System.Drawing.Point(33, 176);
            this.stcOrderLoc.Name = "stcOrderLoc";
            this.stcOrderLoc.PathString = null;
            this.stcOrderLoc.PathValue = "Process";
            this.stcOrderLoc.Size = new System.Drawing.Size(133, 26);
            this.stcOrderLoc.TabIndex = 1;
            this.stcOrderLoc.Text = "Process";
            this.stcOrderLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcWorkResultQty
            // 
            this.stcWorkResultQty.AppearanceName = "";
            this.stcWorkResultQty.ControlID = "";
            this.stcWorkResultQty.Location = new System.Drawing.Point(33, 272);
            this.stcWorkResultQty.Name = "stcWorkResultQty";
            this.stcWorkResultQty.PathString = null;
            this.stcWorkResultQty.PathValue = "Total OK";
            this.stcWorkResultQty.Size = new System.Drawing.Size(133, 33);
            this.stcWorkResultQty.TabIndex = 1;
            this.stcWorkResultQty.Text = "Total OK";
            this.stcWorkResultQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcRemark
            // 
            this.stcRemark.AppearanceName = "";
            this.stcRemark.ControlID = "";
            this.stcRemark.Location = new System.Drawing.Point(33, 342);
            this.stcRemark.Name = "stcRemark";
            this.stcRemark.PathString = null;
            this.stcRemark.PathValue = "Remark";
            this.stcRemark.Size = new System.Drawing.Size(133, 25);
            this.stcRemark.TabIndex = 1;
            this.stcRemark.Text = "Remark";
            this.stcRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcReqOrderLoc
            // 
            this.stcReqOrderLoc.AppearanceName = "RequireText";
            this.stcReqOrderLoc.AutoSize = true;
            this.stcReqOrderLoc.ControlID = "";
            this.stcReqOrderLoc.Location = new System.Drawing.Point(9, 180);
            this.stcReqOrderLoc.Name = "stcReqOrderLoc";
            this.stcReqOrderLoc.PathString = null;
            this.stcReqOrderLoc.PathValue = "*";
            this.stcReqOrderLoc.Size = new System.Drawing.Size(18, 19);
            this.stcReqOrderLoc.TabIndex = 3;
            this.stcReqOrderLoc.Text = "*";
            this.stcReqOrderLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcReqGoodQty
            // 
            this.stcReqGoodQty.AppearanceName = "RequireText";
            this.stcReqGoodQty.AutoSize = true;
            this.stcReqGoodQty.ControlID = "";
            this.stcReqGoodQty.Location = new System.Drawing.Point(762, 49);
            this.stcReqGoodQty.Name = "stcReqGoodQty";
            this.stcReqGoodQty.PathString = null;
            this.stcReqGoodQty.PathValue = "*";
            this.stcReqGoodQty.Size = new System.Drawing.Size(18, 19);
            this.stcReqGoodQty.TabIndex = 3;
            this.stcReqGoodQty.Text = "*";
            this.stcReqGoodQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.txtMasterNo.GroupSeparator = ',';
            this.txtMasterNo.HelpButton = this.btnSearchMasterNo;
            this.txtMasterNo.Int = 0;
            this.txtMasterNo.ItemType = new Rubik.eItemType[0];
            this.txtMasterNo.Location = new System.Drawing.Point(173, 110);
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
            this.txtMasterNo.Size = new System.Drawing.Size(70, 27);
            this.txtMasterNo.SqlOperator = Rubik.eSqlOperator.In;
            this.txtMasterNo.TabIndex = 3;
            this.txtMasterNo.Text = "0";
            this.txtMasterNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMasterNo.KeyPressResult += new Rubik.Forms.UserControl.ItemFoundHandler(this.txtItemCode_KeyPressResult);
            this.txtMasterNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtMasterNo_Validating);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.AppearanceName = "";
            this.txtCustomerName.AppearanceReadOnlyName = "";
            this.txtCustomerName.ControlID = "";
            this.txtCustomerName.DisableRestrictChar = false;
            this.txtCustomerName.HelpButton = null;
            this.txtCustomerName.Location = new System.Drawing.Point(173, 143);
            this.txtCustomerName.MaxLength = 100;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.PathString = "CUSTOMER_NAME.Value";
            this.txtCustomerName.PathValue = "";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(359, 27);
            this.txtCustomerName.TabIndex = 5;
            // 
            // txtPartNo
            // 
            this.txtPartNo.AppearanceName = "";
            this.txtPartNo.AppearanceReadOnlyName = "";
            this.txtPartNo.ControlID = "";
            this.txtPartNo.DisableRestrictChar = false;
            this.txtPartNo.HelpButton = null;
            this.txtPartNo.Location = new System.Drawing.Point(367, 110);
            this.txtPartNo.MaxLength = 50;
            this.txtPartNo.Name = "txtPartNo";
            this.txtPartNo.PathString = "PART_NO.Value";
            this.txtPartNo.PathValue = "";
            this.txtPartNo.ReadOnly = true;
            this.txtPartNo.Size = new System.Drawing.Size(165, 27);
            this.txtPartNo.TabIndex = 4;
            this.txtPartNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtPartNo_Validating);
            // 
            // btnSearchMasterNo
            // 
            this.btnSearchMasterNo.AppearanceName = "";
            this.btnSearchMasterNo.AutoSize = true;
            this.btnSearchMasterNo.BackgroundImage = global::Rubik.Forms.Properties.Resources.VIEW;
            this.btnSearchMasterNo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchMasterNo.ControlID = null;
            this.btnSearchMasterNo.Location = new System.Drawing.Point(249, 109);
            this.btnSearchMasterNo.Name = "btnSearchMasterNo";
            this.btnSearchMasterNo.Size = new System.Drawing.Size(34, 29);
            this.btnSearchMasterNo.TabIndex = 3;
            this.btnSearchMasterNo.TabStop = false;
            this.btnSearchMasterNo.UseVisualStyleBackColor = true;
            this.btnSearchMasterNo.Click += new System.EventHandler(this.btnItemCode_Click);
            // 
            // cboProcess
            // 
            this.cboProcess.AppearanceName = "";
            this.cboProcess.AppearanceReadOnlyName = "";
            this.cboProcess.ControlID = null;
            this.cboProcess.DropDownHeight = 180;
            this.cboProcess.FormattingEnabled = true;
            this.cboProcess.IntegralHeight = false;
            this.cboProcess.Location = new System.Drawing.Point(173, 176);
            this.cboProcess.Name = "cboProcess";
            this.cboProcess.PathString = "PROCESS.Value";
            this.cboProcess.PathValue = null;
            this.cboProcess.Size = new System.Drawing.Size(359, 27);
            this.cboProcess.TabIndex = 6;
            this.cboProcess.SelectedIndexChanged += new System.EventHandler(this.cboProcess_SelectedIndexChanged);
            this.cboProcess.TextChanged += new System.EventHandler(this.cboProcess_TextChanged);
            // 
            // txtQtyKG
            // 
            this.txtQtyKG.AllowNegative = false;
            this.txtQtyKG.AppearanceName = "";
            this.txtQtyKG.AppearanceReadOnlyName = "";
            this.txtQtyKG.ControlID = "";
            this.txtQtyKG.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtQtyKG.DecimalPoint = '.';
            this.txtQtyKG.DigitsInGroup = 0;
            this.txtQtyKG.Double = 0D;
            this.txtQtyKG.FixDecimalPosition = false;
            this.txtQtyKG.Flags = 65536;
            this.txtQtyKG.GroupSeparator = ',';
            this.txtQtyKG.Int = 0;
            this.txtQtyKG.Location = new System.Drawing.Point(173, 275);
            this.txtQtyKG.Long = ((long)(0));
            this.txtQtyKG.MaxDecimalPlaces = 6;
            this.txtQtyKG.MaxLength = 10;
            this.txtQtyKG.MaxWholeDigits = 10;
            this.txtQtyKG.Name = "txtQtyKG";
            this.txtQtyKG.NegativeSign = '\0';
            this.txtQtyKG.PathString = "WEIGHT.Value";
            this.txtQtyKG.PathValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtQtyKG.Prefix = "";
            this.txtQtyKG.RangeMax = 1.7976931348623157E+308D;
            this.txtQtyKG.RangeMin = 0D;
            this.txtQtyKG.Size = new System.Drawing.Size(125, 27);
            this.txtQtyKG.TabIndex = 12;
            this.txtQtyKG.Text = "0";
            this.txtQtyKG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtyKG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQtyKG_KeyPress);
            this.txtQtyKG.Validating += new System.ComponentModel.CancelEventHandler(this.txtQtyKG_Validating);
            // 
            // txtRemark
            // 
            this.txtRemark.AppearanceName = "";
            this.txtRemark.AppearanceReadOnlyName = "";
            this.txtRemark.ControlID = "";
            this.txtRemark.DisableRestrictChar = false;
            this.txtRemark.HelpButton = null;
            this.txtRemark.Location = new System.Drawing.Point(173, 341);
            this.txtRemark.MaxLength = 255;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.PathString = "REMARK.Value";
            this.txtRemark.PathValue = "";
            this.txtRemark.Size = new System.Drawing.Size(359, 83);
            this.txtRemark.TabIndex = 15;
            this.txtRemark.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRemark_KeyPress);
            // 
            // lblShift
            // 
            this.lblShift.AppearanceName = "";
            this.lblShift.ControlID = "";
            this.lblShift.Location = new System.Drawing.Point(779, 42);
            this.lblShift.Name = "lblShift";
            this.lblShift.PathString = null;
            this.lblShift.PathValue = "Shift";
            this.lblShift.Size = new System.Drawing.Size(46, 33);
            this.lblShift.TabIndex = 1;
            this.lblShift.Text = "Shift";
            this.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboShift
            // 
            this.cboShift.AppearanceName = "";
            this.cboShift.AppearanceReadOnlyName = "";
            this.cboShift.ControlID = "";
            this.cboShift.DropDownHeight = 180;
            this.cboShift.FormattingEnabled = true;
            this.cboShift.IntegralHeight = false;
            this.cboShift.Location = new System.Drawing.Point(833, 46);
            this.cboShift.MaxLength = 50;
            this.cboShift.Name = "cboShift";
            this.cboShift.PathString = "SHIFT.Value";
            this.cboShift.PathValue = null;
            this.cboShift.Size = new System.Drawing.Size(150, 27);
            this.cboShift.TabIndex = 2;
            // 
            // evoLabel1
            // 
            this.evoLabel1.AppearanceName = "RequireText";
            this.evoLabel1.AutoSize = true;
            this.evoLabel1.ControlID = "";
            this.evoLabel1.Location = new System.Drawing.Point(6, 279);
            this.evoLabel1.Name = "evoLabel1";
            this.evoLabel1.PathString = null;
            this.evoLabel1.PathValue = "*";
            this.evoLabel1.Size = new System.Drawing.Size(18, 19);
            this.evoLabel1.TabIndex = 3;
            this.evoLabel1.Text = "*";
            this.evoLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // evoLabel2
            // 
            this.evoLabel2.AppearanceName = "";
            this.evoLabel2.ControlID = "";
            this.evoLabel2.Location = new System.Drawing.Point(33, 206);
            this.evoLabel2.Name = "evoLabel2";
            this.evoLabel2.PathString = null;
            this.evoLabel2.PathValue = "Machine No.";
            this.evoLabel2.Size = new System.Drawing.Size(133, 33);
            this.evoLabel2.TabIndex = 1;
            this.evoLabel2.Text = "Machine No.";
            this.evoLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.duplicateToolStripMenuItem.Click += new System.EventHandler(this.duplicateToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // hiddenTransactionID
            // 
            this.hiddenTransactionID.AppearanceName = "";
            this.hiddenTransactionID.AutoSize = true;
            this.hiddenTransactionID.ControlID = "";
            this.hiddenTransactionID.Location = new System.Drawing.Point(7, 505);
            this.hiddenTransactionID.Name = "hiddenTransactionID";
            this.hiddenTransactionID.PathString = "TRANS_ID.Value";
            this.hiddenTransactionID.PathValue = "hiddenTransID";
            this.hiddenTransactionID.Size = new System.Drawing.Size(114, 19);
            this.hiddenTransactionID.TabIndex = 100000;
            this.hiddenTransactionID.Text = "hiddenTransID";
            this.hiddenTransactionID.Visible = false;
            // 
            // hiddenRefNo
            // 
            this.hiddenRefNo.AppearanceName = "";
            this.hiddenRefNo.AutoSize = true;
            this.hiddenRefNo.ControlID = "";
            this.hiddenRefNo.Location = new System.Drawing.Point(7, 486);
            this.hiddenRefNo.Name = "hiddenRefNo";
            this.hiddenRefNo.PathString = "REF_NO.Value";
            this.hiddenRefNo.PathValue = "hiddenRefNo";
            this.hiddenRefNo.Size = new System.Drawing.Size(100, 19);
            this.hiddenRefNo.TabIndex = 100000;
            this.hiddenRefNo.Text = "hiddenRefNo";
            this.hiddenRefNo.Visible = false;
            // 
            // lblUnitKGS
            // 
            this.lblUnitKGS.AppearanceName = "";
            this.lblUnitKGS.AutoSize = true;
            this.lblUnitKGS.ControlID = "";
            this.lblUnitKGS.Location = new System.Drawing.Point(304, 279);
            this.lblUnitKGS.Name = "lblUnitKGS";
            this.lblUnitKGS.PathString = null;
            this.lblUnitKGS.PathValue = "KG";
            this.lblUnitKGS.Size = new System.Drawing.Size(29, 19);
            this.lblUnitKGS.TabIndex = 100002;
            this.lblUnitKGS.Text = "KG";
            // 
            // txtQtyPCS
            // 
            this.txtQtyPCS.AllowNegative = false;
            this.txtQtyPCS.AppearanceName = "";
            this.txtQtyPCS.AppearanceReadOnlyName = "";
            this.txtQtyPCS.ControlID = "";
            this.txtQtyPCS.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtQtyPCS.DecimalPoint = '.';
            this.txtQtyPCS.DigitsInGroup = 3;
            this.txtQtyPCS.Double = 0D;
            this.txtQtyPCS.FixDecimalPosition = false;
            this.txtQtyPCS.Flags = 65536;
            this.txtQtyPCS.GroupSeparator = ',';
            this.txtQtyPCS.Int = 0;
            this.txtQtyPCS.Location = new System.Drawing.Point(362, 275);
            this.txtQtyPCS.Long = ((long)(0));
            this.txtQtyPCS.MaxDecimalPlaces = 6;
            this.txtQtyPCS.MaxLength = 10;
            this.txtQtyPCS.MaxWholeDigits = 10;
            this.txtQtyPCS.Name = "txtQtyPCS";
            this.txtQtyPCS.NegativeSign = '\0';
            this.txtQtyPCS.PathString = "QTY.Value";
            this.txtQtyPCS.PathValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtQtyPCS.Prefix = "";
            this.txtQtyPCS.RangeMax = 1.7976931348623157E+308D;
            this.txtQtyPCS.RangeMin = 0D;
            this.txtQtyPCS.Size = new System.Drawing.Size(125, 27);
            this.txtQtyPCS.TabIndex = 13;
            this.txtQtyPCS.Text = "0";
            this.txtQtyPCS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtyPCS.TextChanged += new System.EventHandler(this.numWorkResultQty_TextChanged);
            this.txtQtyPCS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numWorkResultQty_KeyPress);
            // 
            // lblUnitPCS
            // 
            this.lblUnitPCS.AppearanceName = "";
            this.lblUnitPCS.AutoSize = true;
            this.lblUnitPCS.ControlID = "";
            this.lblUnitPCS.Location = new System.Drawing.Point(490, 279);
            this.lblUnitPCS.Name = "lblUnitPCS";
            this.lblUnitPCS.PathString = null;
            this.lblUnitPCS.PathValue = "PCS";
            this.lblUnitPCS.Size = new System.Drawing.Size(37, 19);
            this.lblUnitPCS.TabIndex = 100002;
            this.lblUnitPCS.Text = "PCS";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel1.BackgroundImage")));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.stcNGInfo, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(546, 79);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(435, 19);
            this.tableLayoutPanel1.TabIndex = 100003;
            // 
            // stcNGInfo
            // 
            this.stcNGInfo.AppearanceName = "Header";
            this.stcNGInfo.AutoSize = true;
            this.stcNGInfo.ControlID = "";
            this.stcNGInfo.Location = new System.Drawing.Point(0, 0);
            this.stcNGInfo.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.stcNGInfo.Name = "stcNGInfo";
            this.stcNGInfo.PathString = null;
            this.stcNGInfo.PathValue = "NG Information";
            this.stcNGInfo.Size = new System.Drawing.Size(120, 19);
            this.stcNGInfo.TabIndex = 0;
            this.stcNGInfo.Text = "NG Information";
            // 
            // fpNGInfo
            // 
            this.fpNGInfo.About = "2.5.2015.2005";
            this.fpNGInfo.AccessibleDescription = "fpNGInfo, Sheet1, Row 0, Column 0, ";
            this.fpNGInfo.BackColor = System.Drawing.Color.AliceBlue;
            this.fpNGInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fpNGInfo.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpNGInfo.EditModeReplace = true;
            this.fpNGInfo.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpNGInfo.Location = new System.Drawing.Point(554, 109);
            this.fpNGInfo.Name = "fpNGInfo";
            this.fpNGInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpNGInfo.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpNGInfo.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpNGInfo.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtNGInfo});
            this.fpNGInfo.Size = new System.Drawing.Size(435, 377);
            this.fpNGInfo.TabIndex = 18;
            this.fpNGInfo.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpNGInfo.EditModeOff += new System.EventHandler(this.fpNGInfo_EditModeOff);
            this.fpNGInfo.LeaveCell += new FarPoint.Win.Spread.LeaveCellEventHandler(this.fpNGInfo_LeaveCell);
            this.fpNGInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpNGInfo_KeyDown);
            this.fpNGInfo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fpNGInfo_KeyUp);
            this.fpNGInfo.Validating += new System.ComponentModel.CancelEventHandler(this.fpNGInfo_Validating);
            // 
            // shtNGInfo
            // 
            this.shtNGInfo.Reset();
            this.shtNGInfo.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtNGInfo.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtNGInfo.ColumnCount = 7;
            this.shtNGInfo.RowCount = 3;
            this.shtNGInfo.AutoCalculation = false;
            this.shtNGInfo.AutoGenerateColumns = false;
            this.shtNGInfo.ColumnHeader.Cells.Get(0, 0).Value = "TRANS ID";
            this.shtNGInfo.ColumnHeader.Cells.Get(0, 1).Value = "NG TRANS ID";
            this.shtNGInfo.ColumnHeader.Cells.Get(0, 2).Value = "PROCESS CD";
            this.shtNGInfo.ColumnHeader.Cells.Get(0, 3).Value = "NG Criteria";
            this.shtNGInfo.ColumnHeader.Cells.Get(0, 4).Value = "NG CRITERIA DESC";
            this.shtNGInfo.ColumnHeader.Cells.Get(0, 5).Value = "KG";
            this.shtNGInfo.ColumnHeader.Cells.Get(0, 6).Value = "PCS";
            this.shtNGInfo.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtNGInfo.Columns.Get(0).Label = "TRANS ID";
            this.shtNGInfo.Columns.Get(0).Visible = false;
            this.shtNGInfo.Columns.Get(0).Width = 69F;
            this.shtNGInfo.Columns.Get(1).Label = "NG TRANS ID";
            this.shtNGInfo.Columns.Get(1).Visible = false;
            this.shtNGInfo.Columns.Get(1).Width = 84F;
            this.shtNGInfo.Columns.Get(2).Label = "PROCESS CD";
            this.shtNGInfo.Columns.Get(2).Visible = false;
            this.shtNGInfo.Columns.Get(2).Width = 101F;
            this.shtNGInfo.Columns.Get(3).Label = "NG Criteria";
            this.shtNGInfo.Columns.Get(3).Tag = "NG Criteria";
            this.shtNGInfo.Columns.Get(3).Width = 160F;
            this.shtNGInfo.Columns.Get(4).Label = "NG CRITERIA DESC";
            this.shtNGInfo.Columns.Get(4).Visible = false;
            this.shtNGInfo.Columns.Get(4).Width = 120F;
            this.shtNGInfo.Columns.Get(5).Label = "KG";
            this.shtNGInfo.Columns.Get(5).Tag = "KG";
            this.shtNGInfo.Columns.Get(5).Width = 100F;
            this.shtNGInfo.Columns.Get(6).Label = "PCS";
            this.shtNGInfo.Columns.Get(6).Tag = "PCS";
            this.shtNGInfo.Columns.Get(6).Width = 100F;
            this.shtNGInfo.DataAutoCellTypes = false;
            this.shtNGInfo.DataAutoSizeColumns = false;
            this.shtNGInfo.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.shtNGInfo.RowHeader.Columns.Default.Resizable = true;
            this.shtNGInfo.RowHeader.Columns.Get(0).Width = 36F;
            this.shtNGInfo.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.shtNGInfo.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.shtNGInfo.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // chkRework
            // 
            this.chkRework.AppearanceName = "";
            this.chkRework.AutoSize = true;
            this.chkRework.CheckedValue = "1";
            this.chkRework.ControlID = null;
            this.chkRework.Location = new System.Drawing.Point(451, 211);
            this.chkRework.Name = "chkRework";
            this.chkRework.PathString = "REWORK.Value";
            this.chkRework.PathValue = false;
            this.chkRework.Size = new System.Drawing.Size(81, 23);
            this.chkRework.TabIndex = 8;
            this.chkRework.Text = "Rework";
            this.chkRework.UnCheckedValue = "0";
            this.chkRework.UseVisualStyleBackColor = true;
            // 
            // cboMachineNo
            // 
            this.cboMachineNo.AppearanceName = "";
            this.cboMachineNo.AppearanceReadOnlyName = "";
            this.cboMachineNo.ControlID = null;
            this.cboMachineNo.DropDownHeight = 180;
            this.cboMachineNo.FormattingEnabled = true;
            this.cboMachineNo.IntegralHeight = false;
            this.cboMachineNo.Location = new System.Drawing.Point(173, 209);
            this.cboMachineNo.MaxLength = 10;
            this.cboMachineNo.Name = "cboMachineNo";
            this.cboMachineNo.PathString = "MACHINE_NO.Value";
            this.cboMachineNo.PathValue = null;
            this.cboMachineNo.Size = new System.Drawing.Size(125, 27);
            this.cboMachineNo.TabIndex = 7;
            // 
            // evoLabel6
            // 
            this.evoLabel6.AppearanceName = "";
            this.evoLabel6.ControlID = "";
            this.evoLabel6.Location = new System.Drawing.Point(735, 488);
            this.evoLabel6.Name = "evoLabel6";
            this.evoLabel6.PathString = null;
            this.evoLabel6.PathValue = "Total NG (PCS)";
            this.evoLabel6.Size = new System.Drawing.Size(128, 33);
            this.evoLabel6.TabIndex = 1;
            this.evoLabel6.Text = "Total NG (PCS)";
            this.evoLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTotalNG
            // 
            this.txtTotalNG.AllowNegative = false;
            this.txtTotalNG.AppearanceName = "";
            this.txtTotalNG.AppearanceReadOnlyName = "";
            this.txtTotalNG.ControlID = "";
            this.txtTotalNG.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalNG.DecimalPoint = '.';
            this.txtTotalNG.DigitsInGroup = 3;
            this.txtTotalNG.Double = 0D;
            this.txtTotalNG.FixDecimalPosition = false;
            this.txtTotalNG.Flags = 65536;
            this.txtTotalNG.GroupSeparator = ',';
            this.txtTotalNG.Int = 0;
            this.txtTotalNG.Location = new System.Drawing.Point(858, 494);
            this.txtTotalNG.Long = ((long)(0));
            this.txtTotalNG.MaxDecimalPlaces = 6;
            this.txtTotalNG.MaxLength = 20;
            this.txtTotalNG.MaxWholeDigits = 10;
            this.txtTotalNG.Name = "txtTotalNG";
            this.txtTotalNG.NegativeSign = '\0';
            this.txtTotalNG.PathString = "NG_QTY.Value";
            this.txtTotalNG.PathValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalNG.Prefix = "";
            this.txtTotalNG.RangeMax = 1.7976931348623157E+308D;
            this.txtTotalNG.RangeMin = 0D;
            this.txtTotalNG.ReadOnly = true;
            this.txtTotalNG.Size = new System.Drawing.Size(98, 27);
            this.txtTotalNG.TabIndex = 19;
            this.txtTotalNG.Text = "0";
            this.txtTotalNG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtOnHandQtyKG
            // 
            this.txtOnHandQtyKG.AllowNegative = false;
            this.txtOnHandQtyKG.AppearanceName = "";
            this.txtOnHandQtyKG.AppearanceReadOnlyName = "";
            this.txtOnHandQtyKG.ControlID = "";
            this.txtOnHandQtyKG.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOnHandQtyKG.DecimalPoint = '.';
            this.txtOnHandQtyKG.DigitsInGroup = 3;
            this.txtOnHandQtyKG.Double = 0D;
            this.txtOnHandQtyKG.FixDecimalPosition = false;
            this.txtOnHandQtyKG.Flags = 65536;
            this.txtOnHandQtyKG.GroupSeparator = ',';
            this.txtOnHandQtyKG.Int = 0;
            this.txtOnHandQtyKG.Location = new System.Drawing.Point(178, 454);
            this.txtOnHandQtyKG.Long = ((long)(0));
            this.txtOnHandQtyKG.MaxDecimalPlaces = 6;
            this.txtOnHandQtyKG.MaxLength = 10;
            this.txtOnHandQtyKG.MaxWholeDigits = 10;
            this.txtOnHandQtyKG.Name = "txtOnHandQtyKG";
            this.txtOnHandQtyKG.NegativeSign = '\0';
            this.txtOnHandQtyKG.PathString = "ON_HAND_WEIGHT.Value";
            this.txtOnHandQtyKG.PathValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOnHandQtyKG.Prefix = "";
            this.txtOnHandQtyKG.RangeMax = 1.7976931348623157E+308D;
            this.txtOnHandQtyKG.RangeMin = 0D;
            this.txtOnHandQtyKG.ReadOnly = true;
            this.txtOnHandQtyKG.Size = new System.Drawing.Size(125, 27);
            this.txtOnHandQtyKG.TabIndex = 16;
            this.txtOnHandQtyKG.Text = "0";
            this.txtOnHandQtyKG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOnHandQtyKG.Visible = false;
            this.txtOnHandQtyKG.TextChanged += new System.EventHandler(this.numWorkResultQty_TextChanged);
            this.txtOnHandQtyKG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numWorkResultQty_KeyPress);
            // 
            // evoLabel4
            // 
            this.evoLabel4.AppearanceName = "";
            this.evoLabel4.ControlID = "";
            this.evoLabel4.Location = new System.Drawing.Point(39, 451);
            this.evoLabel4.Name = "evoLabel4";
            this.evoLabel4.PathString = null;
            this.evoLabel4.PathValue = "On Hand Qty";
            this.evoLabel4.Size = new System.Drawing.Size(133, 33);
            this.evoLabel4.TabIndex = 1;
            this.evoLabel4.Text = "On Hand Qty";
            this.evoLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.evoLabel4.Visible = false;
            // 
            // txtOnHandQtyPCS
            // 
            this.txtOnHandQtyPCS.AllowNegative = false;
            this.txtOnHandQtyPCS.AppearanceName = "";
            this.txtOnHandQtyPCS.AppearanceReadOnlyName = "";
            this.txtOnHandQtyPCS.ControlID = "";
            this.txtOnHandQtyPCS.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOnHandQtyPCS.DecimalPoint = '.';
            this.txtOnHandQtyPCS.DigitsInGroup = 3;
            this.txtOnHandQtyPCS.Double = 0D;
            this.txtOnHandQtyPCS.FixDecimalPosition = false;
            this.txtOnHandQtyPCS.Flags = 65536;
            this.txtOnHandQtyPCS.GroupSeparator = ',';
            this.txtOnHandQtyPCS.Int = 0;
            this.txtOnHandQtyPCS.Location = new System.Drawing.Point(367, 454);
            this.txtOnHandQtyPCS.Long = ((long)(0));
            this.txtOnHandQtyPCS.MaxDecimalPlaces = 6;
            this.txtOnHandQtyPCS.MaxLength = 20;
            this.txtOnHandQtyPCS.MaxWholeDigits = 10;
            this.txtOnHandQtyPCS.Name = "txtOnHandQtyPCS";
            this.txtOnHandQtyPCS.NegativeSign = '\0';
            this.txtOnHandQtyPCS.PathString = "ON_HAND_QTY.Value";
            this.txtOnHandQtyPCS.PathValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOnHandQtyPCS.Prefix = "";
            this.txtOnHandQtyPCS.RangeMax = 1.7976931348623157E+308D;
            this.txtOnHandQtyPCS.RangeMin = 0D;
            this.txtOnHandQtyPCS.ReadOnly = true;
            this.txtOnHandQtyPCS.Size = new System.Drawing.Size(125, 27);
            this.txtOnHandQtyPCS.TabIndex = 17;
            this.txtOnHandQtyPCS.Text = "0";
            this.txtOnHandQtyPCS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOnHandQtyPCS.Visible = false;
            this.txtOnHandQtyPCS.TextChanged += new System.EventHandler(this.numWorkResultQty_TextChanged);
            this.txtOnHandQtyPCS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numWorkResultQty_KeyPress);
            // 
            // evoLabel5
            // 
            this.evoLabel5.AppearanceName = "";
            this.evoLabel5.AutoSize = true;
            this.evoLabel5.ControlID = "";
            this.evoLabel5.Location = new System.Drawing.Point(309, 458);
            this.evoLabel5.Name = "evoLabel5";
            this.evoLabel5.PathString = null;
            this.evoLabel5.PathValue = "KG";
            this.evoLabel5.Size = new System.Drawing.Size(29, 19);
            this.evoLabel5.TabIndex = 100002;
            this.evoLabel5.Text = "KG";
            this.evoLabel5.Visible = false;
            // 
            // evoLabel7
            // 
            this.evoLabel7.AppearanceName = "";
            this.evoLabel7.AutoSize = true;
            this.evoLabel7.ControlID = "";
            this.evoLabel7.Location = new System.Drawing.Point(498, 458);
            this.evoLabel7.Name = "evoLabel7";
            this.evoLabel7.PathString = null;
            this.evoLabel7.PathValue = "PCS";
            this.evoLabel7.Size = new System.Drawing.Size(37, 19);
            this.evoLabel7.TabIndex = 100002;
            this.evoLabel7.Text = "PCS";
            this.evoLabel7.Visible = false;
            // 
            // evoLabel8
            // 
            this.evoLabel8.AppearanceName = "";
            this.evoLabel8.ControlID = "";
            this.evoLabel8.Location = new System.Drawing.Point(39, 552);
            this.evoLabel8.Name = "evoLabel8";
            this.evoLabel8.PathString = null;
            this.evoLabel8.PathValue = "hiddenLot No.";
            this.evoLabel8.Size = new System.Drawing.Size(133, 33);
            this.evoLabel8.TabIndex = 1;
            this.evoLabel8.Text = "hiddenLot No.";
            this.evoLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.evoLabel8.Visible = false;
            // 
            // txtLotNo
            // 
            this.txtLotNo.AppearanceName = "";
            this.txtLotNo.AppearanceReadOnlyName = "";
            this.txtLotNo.ControlID = "";
            this.txtLotNo.DisableRestrictChar = false;
            this.txtLotNo.HelpButton = null;
            this.txtLotNo.Location = new System.Drawing.Point(179, 555);
            this.txtLotNo.MaxLength = 50;
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.PathString = "LOT_NO.Value";
            this.txtLotNo.PathValue = "";
            this.txtLotNo.Size = new System.Drawing.Size(359, 27);
            this.txtLotNo.TabIndex = 9;
            this.txtLotNo.Visible = false;
            this.txtLotNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtLotNo_Validating);
            // 
            // stcWorkOrderNo
            // 
            this.stcWorkOrderNo.AppearanceName = "";
            this.stcWorkOrderNo.ControlID = "";
            this.stcWorkOrderNo.Location = new System.Drawing.Point(33, 305);
            this.stcWorkOrderNo.Name = "stcWorkOrderNo";
            this.stcWorkOrderNo.PathString = null;
            this.stcWorkOrderNo.PathValue = "Person In Charge";
            this.stcWorkOrderNo.Size = new System.Drawing.Size(133, 33);
            this.stcWorkOrderNo.TabIndex = 1;
            this.stcWorkOrderNo.Text = "Person In Charge";
            this.stcWorkOrderNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // evoLabel9
            // 
            this.evoLabel9.AppearanceName = "";
            this.evoLabel9.ControlID = "";
            this.evoLabel9.Location = new System.Drawing.Point(301, 106);
            this.evoLabel9.Name = "evoLabel9";
            this.evoLabel9.PathString = null;
            this.evoLabel9.PathValue = "Part No.";
            this.evoLabel9.Size = new System.Drawing.Size(76, 35);
            this.evoLabel9.TabIndex = 1;
            this.evoLabel9.Text = "Part No.";
            this.evoLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboPersonInCharge
            // 
            this.cboPersonInCharge.AppearanceName = "";
            this.cboPersonInCharge.AppearanceReadOnlyName = "";
            this.cboPersonInCharge.ControlID = null;
            this.cboPersonInCharge.DropDownHeight = 180;
            this.cboPersonInCharge.FormattingEnabled = true;
            this.cboPersonInCharge.IntegralHeight = false;
            this.cboPersonInCharge.Location = new System.Drawing.Point(173, 308);
            this.cboPersonInCharge.Name = "cboPersonInCharge";
            this.cboPersonInCharge.PathString = "PERSON_IN_CHARGE.Value";
            this.cboPersonInCharge.PathValue = null;
            this.cboPersonInCharge.Size = new System.Drawing.Size(359, 27);
            this.cboPersonInCharge.TabIndex = 14;
            // 
            // txtCustLotNo
            // 
            this.txtCustLotNo.AppearanceName = "";
            this.txtCustLotNo.AppearanceReadOnlyName = "";
            this.txtCustLotNo.ControlID = "";
            this.txtCustLotNo.DisableRestrictChar = false;
            this.txtCustLotNo.HelpButton = null;
            this.txtCustLotNo.Location = new System.Drawing.Point(179, 589);
            this.txtCustLotNo.MaxLength = 50;
            this.txtCustLotNo.Name = "txtCustLotNo";
            this.txtCustLotNo.PathString = "CUST_LOT_NO.Value";
            this.txtCustLotNo.PathValue = "";
            this.txtCustLotNo.Size = new System.Drawing.Size(359, 27);
            this.txtCustLotNo.TabIndex = 10;
            this.txtCustLotNo.Visible = false;
            // 
            // evoLabel10
            // 
            this.evoLabel10.AppearanceName = "";
            this.evoLabel10.ControlID = "";
            this.evoLabel10.Location = new System.Drawing.Point(39, 586);
            this.evoLabel10.Name = "evoLabel10";
            this.evoLabel10.PathString = null;
            this.evoLabel10.PathValue = "hiddenCust Lot No.";
            this.evoLabel10.Size = new System.Drawing.Size(133, 33);
            this.evoLabel10.TabIndex = 1;
            this.evoLabel10.Text = "hiddenCust Lot No.";
            this.evoLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.evoLabel10.Visible = false;
            // 
            // lblProductionReportNo
            // 
            this.lblProductionReportNo.AppearanceName = "";
            this.lblProductionReportNo.ControlID = "";
            this.lblProductionReportNo.Location = new System.Drawing.Point(624, 16);
            this.lblProductionReportNo.Name = "lblProductionReportNo";
            this.lblProductionReportNo.PathString = "PRODUCTION_REPORT_NO.Value";
            this.lblProductionReportNo.PathValue = "";
            this.lblProductionReportNo.Size = new System.Drawing.Size(356, 19);
            this.lblProductionReportNo.TabIndex = 0;
            this.lblProductionReportNo.Tag = "";
            // 
            // cboSupplier
            // 
            this.cboSupplier.AppearanceName = "";
            this.cboSupplier.AppearanceReadOnlyName = "";
            this.cboSupplier.ControlID = null;
            this.cboSupplier.DropDownHeight = 180;
            this.cboSupplier.FormattingEnabled = true;
            this.cboSupplier.IntegralHeight = false;
            this.cboSupplier.Location = new System.Drawing.Point(173, 242);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.PathString = "SUPPLIER.Value";
            this.cboSupplier.PathValue = null;
            this.cboSupplier.Size = new System.Drawing.Size(359, 27);
            this.cboSupplier.TabIndex = 11;
            // 
            // lblSupplier
            // 
            this.lblSupplier.AppearanceName = "";
            this.lblSupplier.ControlID = "";
            this.lblSupplier.Location = new System.Drawing.Point(32, 243);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.PathString = null;
            this.lblSupplier.PathValue = "Supplier";
            this.lblSupplier.Size = new System.Drawing.Size(135, 24);
            this.lblSupplier.TabIndex = 100012;
            this.lblSupplier.Text = "Supplier";
            this.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hiddenGroupTransID
            // 
            this.hiddenGroupTransID.AppearanceName = "";
            this.hiddenGroupTransID.AutoSize = true;
            this.hiddenGroupTransID.ControlID = "";
            this.hiddenGroupTransID.Location = new System.Drawing.Point(8, 524);
            this.hiddenGroupTransID.Name = "hiddenGroupTransID";
            this.hiddenGroupTransID.PathString = "GROUP_TRANS_ID.Value";
            this.hiddenGroupTransID.PathValue = "hiddenGroupTransID";
            this.hiddenGroupTransID.Size = new System.Drawing.Size(158, 19);
            this.hiddenGroupTransID.TabIndex = 100013;
            this.hiddenGroupTransID.Text = "hiddenGroupTransID";
            this.hiddenGroupTransID.Visible = false;
            // 
            // TRN210_WorkResultEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(988, 741);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "TRN210_WorkResultEntry";
            this.Text = "Production Report Entry";
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
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpNGInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtNGInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected EVOFramework.Windows.Forms.EVOLabel stcHead;
        protected EVOFramework.Windows.Forms.EVOLabel stcWorkResultNo;
        protected EVOFramework.Windows.Forms.EVOLabel stcWorkResultDate;
        protected EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtProductionReportDate;
        protected EVOFramework.Windows.Forms.EVOLabel stcReqWorkResultDate;
        protected System.Windows.Forms.TableLayoutPanel tlpHeader2;
        protected EVOFramework.Windows.Forms.EVOLabel stcWorkResultInfo;
        protected EVOFramework.Windows.Forms.EVOLabel stcItemCode;
        protected EVOFramework.Windows.Forms.EVOLabel stcItemDesc;
        protected EVOFramework.Windows.Forms.EVOLabel stcReqItemCode;
        protected EVOFramework.Windows.Forms.EVOLabel stcOrderLoc;
        protected EVOFramework.Windows.Forms.EVOLabel stcWorkResultQty;
        protected EVOFramework.Windows.Forms.EVOLabel stcRemark;
        protected EVOFramework.Windows.Forms.EVOLabel stcReqOrderLoc;
        protected EVOFramework.Windows.Forms.EVOLabel stcReqGoodQty;
        protected Rubik.Forms.UserControl.ItemTextBox txtMasterNo;
        protected EVOFramework.Windows.Forms.EVOTextBox txtCustomerName;
        protected EVOFramework.Windows.Forms.EVOComboBox cboProcess;
        protected EVOFramework.Data.UIDataModelController dmc;
        protected EVOFramework.Windows.Forms.EVONumericTextBox txtQtyKG;
        protected EVOFramework.Windows.Forms.EVOTextBox txtRemark;
        protected EVOFramework.Windows.Forms.EVOButton btnSearchMasterNo;
        protected EVOFramework.Windows.Forms.EVOLabel hiddenTransactionID;
        protected System.Windows.Forms.ContextMenuStrip cmsOperation;
        protected System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        protected EVOFramework.Windows.Forms.EVOLabel lblShift;
        protected EVOFramework.Windows.Forms.EVOComboBox cboShift;
        protected EVOFramework.Windows.Forms.EVOLabel evoLabel1;
        protected EVOFramework.Windows.Forms.EVOLabel evoLabel2;
        protected EVOFramework.Windows.Forms.EVOLabel hiddenRefNo;
        protected System.Windows.Forms.ToolStripMenuItem duplicateToolStripMenuItem;
        protected EVOFramework.Windows.Forms.EVOLabel lblUnitKGS;
        protected EVOFramework.Windows.Forms.EVOLabel lblUnitPCS;
        protected EVOFramework.Windows.Forms.EVONumericTextBox txtQtyPCS;
        protected System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        protected EVOFramework.Windows.Forms.EVOLabel stcNGInfo;
        protected FarPoint.Win.Spread.FpSpread fpNGInfo;
        protected FarPoint.Win.Spread.SheetView shtNGInfo;
        protected EVOFramework.Windows.Forms.EVOCheckBox chkRework;
        private System.ComponentModel.IContainer components;
        protected EVOFramework.Windows.Forms.EVOComboBox cboMachineNo;
        protected EVOFramework.Windows.Forms.EVONumericTextBox txtTotalNG;
        protected EVOFramework.Windows.Forms.EVOLabel evoLabel6;
        protected EVOFramework.Windows.Forms.EVOLabel evoLabel7;
        protected EVOFramework.Windows.Forms.EVOLabel evoLabel5;
        protected EVOFramework.Windows.Forms.EVOLabel evoLabel4;
        protected EVOFramework.Windows.Forms.EVONumericTextBox txtOnHandQtyPCS;
        protected EVOFramework.Windows.Forms.EVONumericTextBox txtOnHandQtyKG;
        protected EVOFramework.Windows.Forms.EVOLabel evoLabel8;
        protected EVOFramework.Windows.Forms.EVOTextBox txtLotNo;
        protected EVOFramework.Windows.Forms.EVOLabel stcWorkOrderNo;
        protected EVOFramework.Windows.Forms.EVOLabel evoLabel9;
        private EVOFramework.Windows.Forms.EVOComboBox cboPersonInCharge;
        protected EVOFramework.Windows.Forms.EVOLabel evoLabel10;
        protected EVOFramework.Windows.Forms.EVOTextBox txtCustLotNo;
        protected EVOFramework.Windows.Forms.EVOLabel lblProductionReportNo;
        private EVOFramework.Windows.Forms.EVOComboBox cboSupplier;
        private EVOFramework.Windows.Forms.EVOLabel lblSupplier;
        protected EVOFramework.Windows.Forms.EVOTextBox txtPartNo;
        protected EVOFramework.Windows.Forms.EVOLabel hiddenGroupTransID;
    }
}
