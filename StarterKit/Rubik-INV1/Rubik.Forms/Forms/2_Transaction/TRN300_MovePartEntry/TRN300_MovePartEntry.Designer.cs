namespace Rubik.Transaction
{
    partial class TRN300_MovePartEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TRN300_MovePartEntry));
            this.stcWorkResultNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcWorkResultDate = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblMoveNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.dtMoveDate = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.stcReqWorkResultDate = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcHead = new EVOFramework.Windows.Forms.EVOLabel();
            this.tlpHeader2 = new System.Windows.Forms.TableLayoutPanel();
            this.stcReceiveInfo = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcItemCode = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcItemDesc = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcReqItemCode = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcOrderLoc = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcWorkResultQty = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcRemark = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcReqOrderLoc = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcReqGoodQty = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtCustomerName = new EVOFramework.Windows.Forms.EVOTextBox();
            this.btnSearchMasterNo = new EVOFramework.Windows.Forms.EVOButton();
            this.txtRemark = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblShift = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboShift = new EVOFramework.Windows.Forms.EVOComboBox();
            this.evoLabel1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.cmsOperation = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dmc = new EVOFramework.Data.UIDataModelController(this.components);
            this.hiddenToTransID = new EVOFramework.Windows.Forms.EVOLabel();
            this.hiddenFromTransID = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel2 = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcStoreLoc = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel7 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel5 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtMoveQtyPCS = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.txtMoveQtyKG = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.evoLabel3 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtLotNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.evoLabel4 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel6 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel9 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtOnHandQty = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.evoLabel8 = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboMoveReason = new EVOFramework.Windows.Forms.EVOComboBox();
            this.cboFromProcess = new EVOFramework.Windows.Forms.EVOComboBox();
            this.cboToProcess = new EVOFramework.Windows.Forms.EVOComboBox();
            this.txtPartNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.txtMasterNo = new Rubik.Forms.UserControl.ItemTextBox();
            this.pnlContainer.SuspendLayout();
            this.tlpHeader2.SuspendLayout();
            this.cmsOperation.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.txtPartNo);
            this.pnlContainer.Controls.Add(this.txtMasterNo);
            this.pnlContainer.Controls.Add(this.cboToProcess);
            this.pnlContainer.Controls.Add(this.cboFromProcess);
            this.pnlContainer.Controls.Add(this.cboMoveReason);
            this.pnlContainer.Controls.Add(this.evoLabel6);
            this.pnlContainer.Controls.Add(this.evoLabel9);
            this.pnlContainer.Controls.Add(this.txtOnHandQty);
            this.pnlContainer.Controls.Add(this.txtLotNo);
            this.pnlContainer.Controls.Add(this.evoLabel7);
            this.pnlContainer.Controls.Add(this.evoLabel5);
            this.pnlContainer.Controls.Add(this.txtMoveQtyPCS);
            this.pnlContainer.Controls.Add(this.txtMoveQtyKG);
            this.pnlContainer.Controls.Add(this.stcWorkResultDate);
            this.pnlContainer.Controls.Add(this.dtMoveDate);
            this.pnlContainer.Controls.Add(this.stcWorkResultNo);
            this.pnlContainer.Controls.Add(this.stcReqWorkResultDate);
            this.pnlContainer.Controls.Add(this.stcRemark);
            this.pnlContainer.Controls.Add(this.lblMoveNo);
            this.pnlContainer.Controls.Add(this.txtRemark);
            this.pnlContainer.Controls.Add(this.evoLabel8);
            this.pnlContainer.Controls.Add(this.evoLabel3);
            this.pnlContainer.Controls.Add(this.stcWorkResultQty);
            this.pnlContainer.Controls.Add(this.stcReqGoodQty);
            this.pnlContainer.Controls.Add(this.evoLabel4);
            this.pnlContainer.Controls.Add(this.stcItemCode);
            this.pnlContainer.Controls.Add(this.stcStoreLoc);
            this.pnlContainer.Controls.Add(this.stcOrderLoc);
            this.pnlContainer.Controls.Add(this.stcItemDesc);
            this.pnlContainer.Controls.Add(this.tlpHeader2);
            this.pnlContainer.Controls.Add(this.stcHead);
            this.pnlContainer.Controls.Add(this.evoLabel2);
            this.pnlContainer.Controls.Add(this.stcReqOrderLoc);
            this.pnlContainer.Controls.Add(this.stcReqItemCode);
            this.pnlContainer.Controls.Add(this.hiddenFromTransID);
            this.pnlContainer.Controls.Add(this.hiddenToTransID);
            this.pnlContainer.Controls.Add(this.txtCustomerName);
            this.pnlContainer.Controls.Add(this.lblShift);
            this.pnlContainer.Controls.Add(this.evoLabel1);
            this.pnlContainer.Controls.Add(this.cboShift);
            this.pnlContainer.Controls.Add(this.btnSearchMasterNo);
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlContainer.Size = new System.Drawing.Size(892, 469);
            // 
            // stcWorkResultNo
            // 
            this.stcWorkResultNo.AppearanceName = "";
            this.stcWorkResultNo.AutoSize = true;
            this.stcWorkResultNo.ControlID = "";
            this.stcWorkResultNo.Location = new System.Drawing.Point(413, 6);
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
            this.stcWorkResultDate.Location = new System.Drawing.Point(413, 36);
            this.stcWorkResultDate.Name = "stcWorkResultDate";
            this.stcWorkResultDate.PathString = null;
            this.stcWorkResultDate.PathValue = "Move Date";
            this.stcWorkResultDate.Size = new System.Drawing.Size(87, 33);
            this.stcWorkResultDate.TabIndex = 1;
            this.stcWorkResultDate.Text = "Move Date";
            this.stcWorkResultDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMoveNo
            // 
            this.lblMoveNo.AppearanceName = "";
            this.lblMoveNo.ControlID = "";
            this.lblMoveNo.Location = new System.Drawing.Point(534, 9);
            this.lblMoveNo.Name = "lblMoveNo";
            this.lblMoveNo.PathString = "MOVE_NO.Value";
            this.lblMoveNo.PathValue = "";
            this.lblMoveNo.Size = new System.Drawing.Size(346, 19);
            this.lblMoveNo.TabIndex = 0;
            // 
            // dtMoveDate
            // 
            this.dtMoveDate.AppearanceName = "";
            this.dtMoveDate.AppearanceReadOnlyName = "";
            this.dtMoveDate.BackColor = System.Drawing.Color.Transparent;
            this.dtMoveDate.ControlID = "";
            this.dtMoveDate.Format = "dd/MM/yyyy";
            this.dtMoveDate.Location = new System.Drawing.Point(534, 42);
            this.dtMoveDate.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtMoveDate.Name = "dtMoveDate";
            this.dtMoveDate.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtMoveDate.NZValue")));
            this.dtMoveDate.PathString = "MOVE_DATE.Value";
            this.dtMoveDate.PathValue = ((object)(resources.GetObject("dtMoveDate.PathValue")));
            this.dtMoveDate.ReadOnly = false;
            this.dtMoveDate.ShowButton = true;
            this.dtMoveDate.Size = new System.Drawing.Size(126, 20);
            this.dtMoveDate.TabIndex = 1;
            this.dtMoveDate.Value = null;
            this.dtMoveDate.ValueChanged += new System.EventHandler(this.dtWorkResultDate_ValueChanged);
            // 
            // stcReqWorkResultDate
            // 
            this.stcReqWorkResultDate.AppearanceName = "RequireText";
            this.stcReqWorkResultDate.AutoSize = true;
            this.stcReqWorkResultDate.ControlID = "";
            this.stcReqWorkResultDate.Location = new System.Drawing.Point(389, 43);
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
            this.stcHead.PathValue = "Move Process Entry";
            this.stcHead.Size = new System.Drawing.Size(146, 19);
            this.stcHead.TabIndex = 37;
            this.stcHead.Text = "Move Process Entry";
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
            this.tlpHeader2.Size = new System.Drawing.Size(871, 19);
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
            this.stcReceiveInfo.PathValue = "Move Part Information";
            this.stcReceiveInfo.Size = new System.Drawing.Size(168, 19);
            this.stcReceiveInfo.TabIndex = 0;
            this.stcReceiveInfo.Text = "Move Part Information";
            // 
            // stcItemCode
            // 
            this.stcItemCode.AppearanceName = "";
            this.stcItemCode.ControlID = "";
            this.stcItemCode.Location = new System.Drawing.Point(350, 104);
            this.stcItemCode.Name = "stcItemCode";
            this.stcItemCode.PathString = null;
            this.stcItemCode.PathValue = "Part No";
            this.stcItemCode.Size = new System.Drawing.Size(69, 35);
            this.stcItemCode.TabIndex = 1;
            this.stcItemCode.Text = "Part No";
            this.stcItemCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcItemDesc
            // 
            this.stcItemDesc.AppearanceName = "";
            this.stcItemDesc.ControlID = "";
            this.stcItemDesc.Location = new System.Drawing.Point(35, 138);
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
            this.stcOrderLoc.Location = new System.Drawing.Point(35, 171);
            this.stcOrderLoc.Name = "stcOrderLoc";
            this.stcOrderLoc.PathString = null;
            this.stcOrderLoc.PathValue = "From Process";
            this.stcOrderLoc.Size = new System.Drawing.Size(133, 33);
            this.stcOrderLoc.TabIndex = 1;
            this.stcOrderLoc.Text = "From Process";
            this.stcOrderLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcWorkResultQty
            // 
            this.stcWorkResultQty.AppearanceName = "";
            this.stcWorkResultQty.ControlID = "";
            this.stcWorkResultQty.Location = new System.Drawing.Point(35, 270);
            this.stcWorkResultQty.Name = "stcWorkResultQty";
            this.stcWorkResultQty.PathString = null;
            this.stcWorkResultQty.PathValue = "Move Qty";
            this.stcWorkResultQty.Size = new System.Drawing.Size(133, 33);
            this.stcWorkResultQty.TabIndex = 1;
            this.stcWorkResultQty.Text = "Move Qty";
            this.stcWorkResultQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcRemark
            // 
            this.stcRemark.AppearanceName = "";
            this.stcRemark.ControlID = "";
            this.stcRemark.Location = new System.Drawing.Point(34, 369);
            this.stcRemark.Name = "stcRemark";
            this.stcRemark.PathString = null;
            this.stcRemark.PathValue = "Remark";
            this.stcRemark.Size = new System.Drawing.Size(133, 33);
            this.stcRemark.TabIndex = 1;
            this.stcRemark.Text = "Remark";
            this.stcRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcReqOrderLoc
            // 
            this.stcReqOrderLoc.AppearanceName = "RequireText";
            this.stcReqOrderLoc.AutoSize = true;
            this.stcReqOrderLoc.ControlID = "";
            this.stcReqOrderLoc.Location = new System.Drawing.Point(10, 178);
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
            this.stcReqGoodQty.Location = new System.Drawing.Point(11, 281);
            this.stcReqGoodQty.Name = "stcReqGoodQty";
            this.stcReqGoodQty.PathString = null;
            this.stcReqGoodQty.PathValue = "*";
            this.stcReqGoodQty.Size = new System.Drawing.Size(18, 19);
            this.stcReqGoodQty.TabIndex = 3;
            this.stcReqGoodQty.Text = "*";
            this.stcReqGoodQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.AppearanceName = "";
            this.txtCustomerName.AppearanceReadOnlyName = "";
            this.txtCustomerName.ControlID = "";
            this.txtCustomerName.DisableRestrictChar = false;
            this.txtCustomerName.HelpButton = null;
            this.txtCustomerName.Location = new System.Drawing.Point(174, 141);
            this.txtCustomerName.MaxLength = 100;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.PathString = "CUSTOMER_NAME.Value";
            this.txtCustomerName.PathValue = "";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(615, 27);
            this.txtCustomerName.TabIndex = 5;
            // 
            // btnSearchMasterNo
            // 
            this.btnSearchMasterNo.AppearanceName = "";
            this.btnSearchMasterNo.AutoSize = true;
            this.btnSearchMasterNo.BackgroundImage = global::Rubik.Forms.Properties.Resources.VIEW;
            this.btnSearchMasterNo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchMasterNo.ControlID = null;
            this.btnSearchMasterNo.Location = new System.Drawing.Point(310, 107);
            this.btnSearchMasterNo.Name = "btnSearchMasterNo";
            this.btnSearchMasterNo.Size = new System.Drawing.Size(34, 29);
            this.btnSearchMasterNo.TabIndex = 3;
            this.btnSearchMasterNo.TabStop = false;
            this.btnSearchMasterNo.UseVisualStyleBackColor = true;
            // 
            // txtRemark
            // 
            this.txtRemark.AppearanceName = "";
            this.txtRemark.AppearanceReadOnlyName = "";
            this.txtRemark.ControlID = "";
            this.txtRemark.DisableRestrictChar = false;
            this.txtRemark.HelpButton = null;
            this.txtRemark.Location = new System.Drawing.Point(174, 373);
            this.txtRemark.MaxLength = 255;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.PathString = "REMARK.Value";
            this.txtRemark.PathValue = "";
            this.txtRemark.Size = new System.Drawing.Size(615, 80);
            this.txtRemark.TabIndex = 13;
            this.txtRemark.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRemark_KeyPress);
            // 
            // lblShift
            // 
            this.lblShift.AppearanceName = "";
            this.lblShift.ControlID = "";
            this.lblShift.Location = new System.Drawing.Point(684, 39);
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
            this.cboShift.AppearanceName = "";
            this.cboShift.AppearanceReadOnlyName = "";
            this.cboShift.ControlID = "";
            this.cboShift.DropDownHeight = 180;
            this.cboShift.FormattingEnabled = true;
            this.cboShift.IntegralHeight = false;
            this.cboShift.Location = new System.Drawing.Point(730, 42);
            this.cboShift.MaxLength = 50;
            this.cboShift.Name = "cboShift";
            this.cboShift.PathString = "SHIFT_CLS.Value";
            this.cboShift.PathValue = null;
            this.cboShift.Size = new System.Drawing.Size(150, 27);
            this.cboShift.TabIndex = 2;
            // 
            // evoLabel1
            // 
            this.evoLabel1.AppearanceName = "RequireText";
            this.evoLabel1.AutoSize = true;
            this.evoLabel1.ControlID = "";
            this.evoLabel1.Location = new System.Drawing.Point(666, 46);
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
            this.duplicateToolStripMenuItem.Click += new System.EventHandler(this.duplicateToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // hiddenToTransID
            // 
            this.hiddenToTransID.AppearanceName = "";
            this.hiddenToTransID.AutoSize = true;
            this.hiddenToTransID.ControlID = "";
            this.hiddenToTransID.Location = new System.Drawing.Point(13, 443);
            this.hiddenToTransID.Name = "hiddenToTransID";
            this.hiddenToTransID.PathString = "TRANS_ID_TO.Value";
            this.hiddenToTransID.PathValue = "hiddenToTransID";
            this.hiddenToTransID.Size = new System.Drawing.Size(133, 19);
            this.hiddenToTransID.TabIndex = 100000;
            this.hiddenToTransID.Text = "hiddenToTransID";
            this.hiddenToTransID.Visible = false;
            // 
            // hiddenFromTransID
            // 
            this.hiddenFromTransID.AppearanceName = "";
            this.hiddenFromTransID.AutoSize = true;
            this.hiddenFromTransID.ControlID = "";
            this.hiddenFromTransID.Location = new System.Drawing.Point(13, 424);
            this.hiddenFromTransID.Name = "hiddenFromTransID";
            this.hiddenFromTransID.PathString = "TRANS_ID_FROM.Value";
            this.hiddenFromTransID.PathValue = "hiddenFromTransID";
            this.hiddenFromTransID.Size = new System.Drawing.Size(151, 19);
            this.hiddenFromTransID.TabIndex = 100000;
            this.hiddenFromTransID.Text = "hiddenFromTransID";
            this.hiddenFromTransID.Visible = false;
            // 
            // evoLabel2
            // 
            this.evoLabel2.AppearanceName = "RequireText";
            this.evoLabel2.AutoSize = true;
            this.evoLabel2.ControlID = "";
            this.evoLabel2.Location = new System.Drawing.Point(9, 211);
            this.evoLabel2.Name = "evoLabel2";
            this.evoLabel2.PathString = null;
            this.evoLabel2.PathValue = "*";
            this.evoLabel2.Size = new System.Drawing.Size(18, 19);
            this.evoLabel2.TabIndex = 3;
            this.evoLabel2.Text = "*";
            this.evoLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcStoreLoc
            // 
            this.stcStoreLoc.AppearanceName = "";
            this.stcStoreLoc.ControlID = "";
            this.stcStoreLoc.Location = new System.Drawing.Point(34, 204);
            this.stcStoreLoc.Name = "stcStoreLoc";
            this.stcStoreLoc.PathString = null;
            this.stcStoreLoc.PathValue = "To Process";
            this.stcStoreLoc.Size = new System.Drawing.Size(133, 33);
            this.stcStoreLoc.TabIndex = 1;
            this.stcStoreLoc.Text = "To Process";
            this.stcStoreLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // evoLabel7
            // 
            this.evoLabel7.AppearanceName = "";
            this.evoLabel7.AutoSize = true;
            this.evoLabel7.ControlID = "";
            this.evoLabel7.Location = new System.Drawing.Point(747, 277);
            this.evoLabel7.Name = "evoLabel7";
            this.evoLabel7.PathString = null;
            this.evoLabel7.PathValue = "PCS";
            this.evoLabel7.Size = new System.Drawing.Size(37, 19);
            this.evoLabel7.TabIndex = 100005;
            this.evoLabel7.Text = "PCS";
            // 
            // evoLabel5
            // 
            this.evoLabel5.AppearanceName = "";
            this.evoLabel5.AutoSize = true;
            this.evoLabel5.ControlID = "";
            this.evoLabel5.Location = new System.Drawing.Point(440, 277);
            this.evoLabel5.Name = "evoLabel5";
            this.evoLabel5.PathString = null;
            this.evoLabel5.PathValue = "KG";
            this.evoLabel5.Size = new System.Drawing.Size(29, 19);
            this.evoLabel5.TabIndex = 100006;
            this.evoLabel5.Text = "KG";
            // 
            // txtMoveQtyPCS
            // 
            this.txtMoveQtyPCS.AllowNegative = false;
            this.txtMoveQtyPCS.AppearanceName = "";
            this.txtMoveQtyPCS.AppearanceReadOnlyName = "";
            this.txtMoveQtyPCS.ControlID = "";
            this.txtMoveQtyPCS.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMoveQtyPCS.DecimalPoint = '.';
            this.txtMoveQtyPCS.DigitsInGroup = 3;
            this.txtMoveQtyPCS.Double = 0D;
            this.txtMoveQtyPCS.FixDecimalPosition = false;
            this.txtMoveQtyPCS.Flags = 65536;
            this.txtMoveQtyPCS.GroupSeparator = ',';
            this.txtMoveQtyPCS.Int = 0;
            this.txtMoveQtyPCS.Location = new System.Drawing.Point(481, 273);
            this.txtMoveQtyPCS.Long = ((long)(0));
            this.txtMoveQtyPCS.MaxDecimalPlaces = 0;
            this.txtMoveQtyPCS.MaxLength = 20;
            this.txtMoveQtyPCS.MaxWholeDigits = 10;
            this.txtMoveQtyPCS.Name = "txtMoveQtyPCS";
            this.txtMoveQtyPCS.NegativeSign = '\0';
            this.txtMoveQtyPCS.PathString = "MOVE_QTY.Value";
            this.txtMoveQtyPCS.PathValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMoveQtyPCS.Prefix = "";
            this.txtMoveQtyPCS.RangeMax = 1.7976931348623157E+308D;
            this.txtMoveQtyPCS.RangeMin = 0D;
            this.txtMoveQtyPCS.Size = new System.Drawing.Size(260, 27);
            this.txtMoveQtyPCS.TabIndex = 10;
            this.txtMoveQtyPCS.Text = "0";
            this.txtMoveQtyPCS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMoveQtyPCS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMoveQtyPCS_KeyPress);
            this.txtMoveQtyPCS.Validating += new System.ComponentModel.CancelEventHandler(this.txtMoveQtyPCS_Validating);
            // 
            // txtMoveQtyKG
            // 
            this.txtMoveQtyKG.AllowNegative = false;
            this.txtMoveQtyKG.AppearanceName = "";
            this.txtMoveQtyKG.AppearanceReadOnlyName = "";
            this.txtMoveQtyKG.ControlID = "";
            this.txtMoveQtyKG.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMoveQtyKG.DecimalPoint = '.';
            this.txtMoveQtyKG.DigitsInGroup = 3;
            this.txtMoveQtyKG.Double = 0D;
            this.txtMoveQtyKG.FixDecimalPosition = false;
            this.txtMoveQtyKG.Flags = 65536;
            this.txtMoveQtyKG.GroupSeparator = ',';
            this.txtMoveQtyKG.Int = 0;
            this.txtMoveQtyKG.Location = new System.Drawing.Point(174, 273);
            this.txtMoveQtyKG.Long = ((long)(0));
            this.txtMoveQtyKG.MaxDecimalPlaces = 6;
            this.txtMoveQtyKG.MaxLength = 20;
            this.txtMoveQtyKG.MaxWholeDigits = 10;
            this.txtMoveQtyKG.Name = "txtMoveQtyKG";
            this.txtMoveQtyKG.NegativeSign = '\0';
            this.txtMoveQtyKG.PathString = "WEIGHT.Value";
            this.txtMoveQtyKG.PathValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMoveQtyKG.Prefix = "";
            this.txtMoveQtyKG.RangeMax = 1.7976931348623157E+308D;
            this.txtMoveQtyKG.RangeMin = 0D;
            this.txtMoveQtyKG.Size = new System.Drawing.Size(260, 27);
            this.txtMoveQtyKG.TabIndex = 9;
            this.txtMoveQtyKG.Text = "0";
            this.txtMoveQtyKG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMoveQtyKG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMoveQtyKG_KeyPress);
            this.txtMoveQtyKG.Validating += new System.ComponentModel.CancelEventHandler(this.txtMoveQtyKG_Validating);
            // 
            // evoLabel3
            // 
            this.evoLabel3.AppearanceName = "";
            this.evoLabel3.ControlID = "";
            this.evoLabel3.Location = new System.Drawing.Point(34, 303);
            this.evoLabel3.Name = "evoLabel3";
            this.evoLabel3.PathString = null;
            this.evoLabel3.PathValue = "Lot No.";
            this.evoLabel3.Size = new System.Drawing.Size(119, 33);
            this.evoLabel3.TabIndex = 1;
            this.evoLabel3.Text = "Lot No.";
            this.evoLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLotNo
            // 
            this.txtLotNo.AppearanceName = "";
            this.txtLotNo.AppearanceReadOnlyName = "";
            this.txtLotNo.ControlID = "";
            this.txtLotNo.DisableRestrictChar = false;
            this.txtLotNo.HelpButton = null;
            this.txtLotNo.Location = new System.Drawing.Point(174, 307);
            this.txtLotNo.MaxLength = 50;
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.PathString = "LOT_NO.Value";
            this.txtLotNo.PathValue = "";
            this.txtLotNo.Size = new System.Drawing.Size(614, 27);
            this.txtLotNo.TabIndex = 11;
            this.txtLotNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtLotNo_Validating);
            // 
            // evoLabel4
            // 
            this.evoLabel4.AppearanceName = "";
            this.evoLabel4.ControlID = "";
            this.evoLabel4.Location = new System.Drawing.Point(35, 104);
            this.evoLabel4.Name = "evoLabel4";
            this.evoLabel4.PathString = null;
            this.evoLabel4.PathValue = "Master No.";
            this.evoLabel4.Size = new System.Drawing.Size(92, 35);
            this.evoLabel4.TabIndex = 1;
            this.evoLabel4.Text = "Master No.";
            this.evoLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // evoLabel6
            // 
            this.evoLabel6.AppearanceName = "";
            this.evoLabel6.AutoSize = true;
            this.evoLabel6.ControlID = "";
            this.evoLabel6.Location = new System.Drawing.Point(747, 244);
            this.evoLabel6.Name = "evoLabel6";
            this.evoLabel6.PathString = null;
            this.evoLabel6.PathValue = "PCS";
            this.evoLabel6.Size = new System.Drawing.Size(37, 19);
            this.evoLabel6.TabIndex = 100012;
            this.evoLabel6.Text = "PCS";
            // 
            // evoLabel9
            // 
            this.evoLabel9.AppearanceName = "";
            this.evoLabel9.ControlID = "";
            this.evoLabel9.Location = new System.Drawing.Point(34, 237);
            this.evoLabel9.Name = "evoLabel9";
            this.evoLabel9.PathString = null;
            this.evoLabel9.PathValue = "On Hand Qty";
            this.evoLabel9.Size = new System.Drawing.Size(133, 33);
            this.evoLabel9.TabIndex = 100009;
            this.evoLabel9.Text = "On Hand Qty";
            this.evoLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOnHandQty
            // 
            this.txtOnHandQty.AllowNegative = true;
            this.txtOnHandQty.AppearanceName = "";
            this.txtOnHandQty.AppearanceReadOnlyName = "";
            this.txtOnHandQty.ControlID = "";
            this.txtOnHandQty.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOnHandQty.DecimalPoint = '.';
            this.txtOnHandQty.DigitsInGroup = 3;
            this.txtOnHandQty.Double = 0D;
            this.txtOnHandQty.FixDecimalPosition = false;
            this.txtOnHandQty.Flags = 0;
            this.txtOnHandQty.GroupSeparator = ',';
            this.txtOnHandQty.Int = 0;
            this.txtOnHandQty.Location = new System.Drawing.Point(174, 240);
            this.txtOnHandQty.Long = ((long)(0));
            this.txtOnHandQty.MaxDecimalPlaces = 0;
            this.txtOnHandQty.MaxWholeDigits = 10;
            this.txtOnHandQty.Name = "txtOnHandQty";
            this.txtOnHandQty.NegativeSign = '\0';
            this.txtOnHandQty.PathString = "ON_HAND_QTY.Value";
            this.txtOnHandQty.PathValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOnHandQty.Prefix = "";
            this.txtOnHandQty.RangeMax = 1.7976931348623157E+308D;
            this.txtOnHandQty.RangeMin = 0D;
            this.txtOnHandQty.ReadOnly = true;
            this.txtOnHandQty.Size = new System.Drawing.Size(567, 27);
            this.txtOnHandQty.TabIndex = 8;
            this.txtOnHandQty.Text = "0";
            this.txtOnHandQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // evoLabel8
            // 
            this.evoLabel8.AppearanceName = "";
            this.evoLabel8.ControlID = "";
            this.evoLabel8.Location = new System.Drawing.Point(34, 336);
            this.evoLabel8.Name = "evoLabel8";
            this.evoLabel8.PathString = null;
            this.evoLabel8.PathValue = "Move Reason";
            this.evoLabel8.Size = new System.Drawing.Size(119, 33);
            this.evoLabel8.TabIndex = 1;
            this.evoLabel8.Text = "Move Reason";
            this.evoLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboMoveReason
            // 
            this.cboMoveReason.AppearanceName = "";
            this.cboMoveReason.AppearanceReadOnlyName = "";
            this.cboMoveReason.ControlID = null;
            this.cboMoveReason.DropDownHeight = 180;
            this.cboMoveReason.FormattingEnabled = true;
            this.cboMoveReason.IntegralHeight = false;
            this.cboMoveReason.Location = new System.Drawing.Point(174, 340);
            this.cboMoveReason.MaxLength = 30;
            this.cboMoveReason.Name = "cboMoveReason";
            this.cboMoveReason.PathString = "REASON.Value";
            this.cboMoveReason.PathValue = null;
            this.cboMoveReason.Size = new System.Drawing.Size(615, 27);
            this.cboMoveReason.TabIndex = 12;
            // 
            // cboFromProcess
            // 
            this.cboFromProcess.AppearanceName = "";
            this.cboFromProcess.AppearanceReadOnlyName = "";
            this.cboFromProcess.ControlID = null;
            this.cboFromProcess.DropDownHeight = 180;
            this.cboFromProcess.FormattingEnabled = true;
            this.cboFromProcess.IntegralHeight = false;
            this.cboFromProcess.Location = new System.Drawing.Point(174, 175);
            this.cboFromProcess.MaxLength = 50;
            this.cboFromProcess.Name = "cboFromProcess";
            this.cboFromProcess.PathString = "FROM_PROCESS.Value";
            this.cboFromProcess.PathValue = null;
            this.cboFromProcess.Size = new System.Drawing.Size(615, 27);
            this.cboFromProcess.TabIndex = 6;
            this.cboFromProcess.Validating += new System.ComponentModel.CancelEventHandler(this.cboFromProcess_Validating);
            // 
            // cboToProcess
            // 
            this.cboToProcess.AppearanceName = "";
            this.cboToProcess.AppearanceReadOnlyName = "";
            this.cboToProcess.ControlID = null;
            this.cboToProcess.DropDownHeight = 180;
            this.cboToProcess.FormattingEnabled = true;
            this.cboToProcess.IntegralHeight = false;
            this.cboToProcess.Location = new System.Drawing.Point(174, 208);
            this.cboToProcess.MaxLength = 50;
            this.cboToProcess.Name = "cboToProcess";
            this.cboToProcess.PathString = "TO_PROCESS.Value";
            this.cboToProcess.PathValue = null;
            this.cboToProcess.Size = new System.Drawing.Size(615, 27);
            this.cboToProcess.TabIndex = 7;
            // 
            // txtPartNo
            // 
            this.txtPartNo.AppearanceName = "";
            this.txtPartNo.AppearanceReadOnlyName = "";
            this.txtPartNo.ControlID = "";
            this.txtPartNo.DisableRestrictChar = false;
            this.txtPartNo.HelpButton = null;
            this.txtPartNo.Location = new System.Drawing.Point(421, 107);
            this.txtPartNo.MaxLength = 50;
            this.txtPartNo.Name = "txtPartNo";
            this.txtPartNo.PathString = "PART_NO.Value";
            this.txtPartNo.PathValue = "";
            this.txtPartNo.ReadOnly = true;
            this.txtPartNo.Size = new System.Drawing.Size(367, 27);
            this.txtPartNo.TabIndex = 4;
            this.txtPartNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtPartNo_Validating);
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
            this.txtMasterNo.FixDecimalPosition = true;
            this.txtMasterNo.Flags = 0;
            this.txtMasterNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtMasterNo.GroupSeparator = ',';
            this.txtMasterNo.HelpButton = this.btnSearchMasterNo;
            this.txtMasterNo.Int = 0;
            this.txtMasterNo.ItemType = null;
            this.txtMasterNo.Location = new System.Drawing.Point(174, 108);
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
            // TRN300_MovePartEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(892, 519);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 396);
            this.Name = "TRN300_MovePartEntry";
            this.Text = "Move Process Entry";
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EVOFramework.Windows.Forms.EVOLabel stcHead;
        private EVOFramework.Windows.Forms.EVOLabel stcWorkResultNo;
        private EVOFramework.Windows.Forms.EVOLabel stcWorkResultDate;
        private EVOFramework.Windows.Forms.EVOLabel lblMoveNo;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtMoveDate;
        private EVOFramework.Windows.Forms.EVOLabel stcReqWorkResultDate;
        private System.Windows.Forms.TableLayoutPanel tlpHeader2;
        private EVOFramework.Windows.Forms.EVOLabel stcReceiveInfo;
        private EVOFramework.Windows.Forms.EVOLabel stcItemCode;
        private EVOFramework.Windows.Forms.EVOLabel stcItemDesc;
        private EVOFramework.Windows.Forms.EVOLabel stcReqItemCode;
        private EVOFramework.Windows.Forms.EVOLabel stcOrderLoc;
        private EVOFramework.Windows.Forms.EVOLabel stcWorkResultQty;
        private EVOFramework.Windows.Forms.EVOLabel stcRemark;
        private EVOFramework.Windows.Forms.EVOLabel stcReqOrderLoc;
        private EVOFramework.Windows.Forms.EVOLabel stcReqGoodQty;
        private EVOFramework.Windows.Forms.EVOTextBox txtCustomerName;
        private EVOFramework.Data.UIDataModelController dmc;
        private EVOFramework.Windows.Forms.EVOTextBox txtRemark;
        private EVOFramework.Windows.Forms.EVOButton btnSearchMasterNo;
        private EVOFramework.Windows.Forms.EVOLabel hiddenToTransID;
        private System.Windows.Forms.ContextMenuStrip cmsOperation;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private EVOFramework.Windows.Forms.EVOLabel lblShift;
        private EVOFramework.Windows.Forms.EVOComboBox cboShift;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel1;
        private EVOFramework.Windows.Forms.EVOLabel hiddenFromTransID;
        private System.Windows.Forms.ToolStripMenuItem duplicateToolStripMenuItem;
        private EVOFramework.Windows.Forms.EVOLabel stcStoreLoc;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel2;
        protected EVOFramework.Windows.Forms.EVOLabel evoLabel7;
        protected EVOFramework.Windows.Forms.EVOLabel evoLabel5;
        protected EVOFramework.Windows.Forms.EVONumericTextBox txtMoveQtyPCS;
        protected EVOFramework.Windows.Forms.EVONumericTextBox txtMoveQtyKG;
        private EVOFramework.Windows.Forms.EVOTextBox txtLotNo;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel3;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel4;
        protected EVOFramework.Windows.Forms.EVOLabel evoLabel6;
        protected EVOFramework.Windows.Forms.EVOLabel evoLabel9;
        protected EVOFramework.Windows.Forms.EVONumericTextBox txtOnHandQty;
        private EVOFramework.Windows.Forms.EVOComboBox cboMoveReason;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel8;
        private EVOFramework.Windows.Forms.EVOComboBox cboFromProcess;
        private EVOFramework.Windows.Forms.EVOComboBox cboToProcess;
        private Forms.UserControl.ItemTextBox txtMasterNo;
        private EVOFramework.Windows.Forms.EVOTextBox txtPartNo;
    }
}
