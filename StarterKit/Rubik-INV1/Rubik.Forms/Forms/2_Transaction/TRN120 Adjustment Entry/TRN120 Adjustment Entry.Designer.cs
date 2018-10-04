namespace Rubik.Transaction
{
    partial class TRN120
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TRN120));
            this.stcTransactionID = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcAdjustDate = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblAdjustNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.dtAdjustDate = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.evoLabel4 = new EVOFramework.Windows.Forms.EVOLabel();
            this.pnlHeader = new EVOFramework.Windows.Forms.EVOPanel();
            this.stcHeader = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblInventoryUMCls = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboInventoryUM = new EVOFramework.Windows.Forms.EVOComboBox();
            this.stcRemark = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcLotNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcOnhandQty = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcAdjustQty = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcStoredLoc = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcItemDesc = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcItemCode = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtCustomerName = new EVOFramework.Windows.Forms.EVOTextBox();
            this.txtRemark = new EVOFramework.Windows.Forms.EVOTextBox();
            this.cboStoredLoc = new EVOFramework.Windows.Forms.EVOComboBox();
            this.btnItemCode = new EVOFramework.Windows.Forms.EVOButton();
            this.txtLotNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.btnLotNo = new EVOFramework.Windows.Forms.EVOButton();
            this.evoLabel1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel2 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel3 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtAdjustWeight = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.cboReasonCode = new EVOFramework.Windows.Forms.EVOComboBox();
            this.lblReasonCode = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel5 = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcAdjustType = new EVOFramework.Windows.Forms.EVOLabel();
            this.tlpHeader2 = new System.Windows.Forms.TableLayoutPanel();
            this.stcTitle = new EVOFramework.Windows.Forms.EVOLabel();
            this.pnlAdjustType = new EVOFramework.Windows.Forms.EVOPanel();
            this.rdoDecrease = new EVOFramework.Windows.Forms.EVORadioButton();
            this.rdoIncrease = new EVOFramework.Windows.Forms.EVORadioButton();
            this.dmcAdjust = new EVOFramework.Data.UIDataModelController(this.components);
            this.lblUnitKGS = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtOnhandQty = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.txtAdjustQty = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.evoLabel7 = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblUnitPCS = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel8 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtItemDesc = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblPackNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtPackNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.hiddenTransID = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel6 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel9 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtCustomerLotNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.txtMasterNo = new Rubik.Forms.UserControl.ItemTextBox();
            this.txtFGNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.evoLabel10 = new EVOFramework.Windows.Forms.EVOLabel();
            this.pnlContainer.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.tlpHeader2.SuspendLayout();
            this.pnlAdjustType.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.txtFGNo);
            this.pnlContainer.Controls.Add(this.evoLabel10);
            this.pnlContainer.Controls.Add(this.txtCustomerLotNo);
            this.pnlContainer.Controls.Add(this.evoLabel6);
            this.pnlContainer.Controls.Add(this.hiddenTransID);
            this.pnlContainer.Controls.Add(this.txtPackNo);
            this.pnlContainer.Controls.Add(this.lblPackNo);
            this.pnlContainer.Controls.Add(this.txtItemDesc);
            this.pnlContainer.Controls.Add(this.evoLabel7);
            this.pnlContainer.Controls.Add(this.lblUnitPCS);
            this.pnlContainer.Controls.Add(this.lblUnitKGS);
            this.pnlContainer.Controls.Add(this.pnlHeader);
            this.pnlContainer.Controls.Add(this.lblAdjustNo);
            this.pnlContainer.Controls.Add(this.stcAdjustDate);
            this.pnlContainer.Controls.Add(this.dtAdjustDate);
            this.pnlContainer.Controls.Add(this.stcTransactionID);
            this.pnlContainer.Controls.Add(this.evoLabel4);
            this.pnlContainer.Controls.Add(this.txtLotNo);
            this.pnlContainer.Controls.Add(this.btnLotNo);
            this.pnlContainer.Controls.Add(this.txtRemark);
            this.pnlContainer.Controls.Add(this.stcRemark);
            this.pnlContainer.Controls.Add(this.cboInventoryUM);
            this.pnlContainer.Controls.Add(this.lblInventoryUMCls);
            this.pnlContainer.Controls.Add(this.pnlAdjustType);
            this.pnlContainer.Controls.Add(this.tlpHeader2);
            this.pnlContainer.Controls.Add(this.stcAdjustQty);
            this.pnlContainer.Controls.Add(this.txtAdjustQty);
            this.pnlContainer.Controls.Add(this.txtAdjustWeight);
            this.pnlContainer.Controls.Add(this.stcOnhandQty);
            this.pnlContainer.Controls.Add(this.evoLabel9);
            this.pnlContainer.Controls.Add(this.stcLotNo);
            this.pnlContainer.Controls.Add(this.evoLabel3);
            this.pnlContainer.Controls.Add(this.stcAdjustType);
            this.pnlContainer.Controls.Add(this.txtOnhandQty);
            this.pnlContainer.Controls.Add(this.evoLabel5);
            this.pnlContainer.Controls.Add(this.stcStoredLoc);
            this.pnlContainer.Controls.Add(this.cboStoredLoc);
            this.pnlContainer.Controls.Add(this.lblReasonCode);
            this.pnlContainer.Controls.Add(this.txtCustomerName);
            this.pnlContainer.Controls.Add(this.stcItemDesc);
            this.pnlContainer.Controls.Add(this.cboReasonCode);
            this.pnlContainer.Controls.Add(this.evoLabel8);
            this.pnlContainer.Controls.Add(this.stcItemCode);
            this.pnlContainer.Controls.Add(this.evoLabel2);
            this.pnlContainer.Controls.Add(this.evoLabel1);
            this.pnlContainer.Controls.Add(this.txtMasterNo);
            this.pnlContainer.Controls.Add(this.btnItemCode);
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlContainer.Size = new System.Drawing.Size(896, 541);
            // 
            // stcTransactionID
            // 
            this.stcTransactionID.AppearanceName = "";
            this.stcTransactionID.AutoSize = true;
            this.stcTransactionID.ControlID = "";
            this.stcTransactionID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.stcTransactionID.Location = new System.Drawing.Point(545, 8);
            this.stcTransactionID.Name = "stcTransactionID";
            this.stcTransactionID.PathString = null;
            this.stcTransactionID.PathValue = "Transaction No.";
            this.stcTransactionID.Size = new System.Drawing.Size(120, 20);
            this.stcTransactionID.TabIndex = 10;
            this.stcTransactionID.Text = "Transaction No.";
            // 
            // stcAdjustDate
            // 
            this.stcAdjustDate.AppearanceName = "";
            this.stcAdjustDate.AutoSize = true;
            this.stcAdjustDate.ControlID = "";
            this.stcAdjustDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.stcAdjustDate.Location = new System.Drawing.Point(545, 35);
            this.stcAdjustDate.Name = "stcAdjustDate";
            this.stcAdjustDate.PathString = null;
            this.stcAdjustDate.PathValue = "Adjust Date";
            this.stcAdjustDate.Size = new System.Drawing.Size(93, 20);
            this.stcAdjustDate.TabIndex = 8;
            this.stcAdjustDate.Text = "Adjust Date";
            // 
            // lblAdjustNo
            // 
            this.lblAdjustNo.AppearanceName = "";
            this.lblAdjustNo.ControlID = "";
            this.lblAdjustNo.Location = new System.Drawing.Point(671, 9);
            this.lblAdjustNo.Name = "lblAdjustNo";
            this.lblAdjustNo.PathString = "AdjustNo.Value";
            this.lblAdjustNo.PathValue = "";
            this.lblAdjustNo.Size = new System.Drawing.Size(203, 19);
            this.lblAdjustNo.TabIndex = 0;
            // 
            // dtAdjustDate
            // 
            this.dtAdjustDate.AppearanceName = "";
            this.dtAdjustDate.AppearanceReadOnlyName = "";
            this.dtAdjustDate.BackColor = System.Drawing.Color.Transparent;
            this.dtAdjustDate.ControlID = "";
            this.dtAdjustDate.Format = "dd/MM/yyyy";
            this.dtAdjustDate.Location = new System.Drawing.Point(671, 35);
            this.dtAdjustDate.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtAdjustDate.Name = "dtAdjustDate";
            this.dtAdjustDate.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtAdjustDate.NZValue")));
            this.dtAdjustDate.PathString = "AdjustDate.Value";
            this.dtAdjustDate.PathValue = ((object)(resources.GetObject("dtAdjustDate.PathValue")));
            this.dtAdjustDate.ReadOnly = false;
            this.dtAdjustDate.ShowButton = true;
            this.dtAdjustDate.Size = new System.Drawing.Size(203, 20);
            this.dtAdjustDate.TabIndex = 1;
            this.dtAdjustDate.Value = null;
            // 
            // evoLabel4
            // 
            this.evoLabel4.AppearanceName = "RequireText";
            this.evoLabel4.AutoSize = true;
            this.evoLabel4.ControlID = "";
            this.evoLabel4.Location = new System.Drawing.Point(528, 36);
            this.evoLabel4.Name = "evoLabel4";
            this.evoLabel4.PathString = null;
            this.evoLabel4.PathValue = "*";
            this.evoLabel4.Size = new System.Drawing.Size(18, 19);
            this.evoLabel4.TabIndex = 16;
            this.evoLabel4.Text = "*";
            // 
            // pnlHeader
            // 
            this.pnlHeader.AppearanceName = "";
            this.pnlHeader.AutoSize = true;
            this.pnlHeader.Controls.Add(this.stcHeader);
            this.pnlHeader.Location = new System.Drawing.Point(9, 9);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(450, 39);
            this.pnlHeader.TabIndex = 0;
            // 
            // stcHeader
            // 
            this.stcHeader.AppearanceName = "Title";
            this.stcHeader.AutoSize = true;
            this.stcHeader.ControlID = "";
            this.stcHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.stcHeader.Location = new System.Drawing.Point(0, 0);
            this.stcHeader.Name = "stcHeader";
            this.stcHeader.PathString = null;
            this.stcHeader.PathValue = "Adjust Entry";
            this.stcHeader.Size = new System.Drawing.Size(97, 19);
            this.stcHeader.TabIndex = 36;
            this.stcHeader.Text = "Adjust Entry";
            // 
            // lblInventoryUMCls
            // 
            this.lblInventoryUMCls.AppearanceName = "";
            this.lblInventoryUMCls.ControlID = "";
            this.lblInventoryUMCls.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblInventoryUMCls.Location = new System.Drawing.Point(56, 361);
            this.lblInventoryUMCls.Name = "lblInventoryUMCls";
            this.lblInventoryUMCls.PathString = null;
            this.lblInventoryUMCls.PathValue = "Inventory U/M";
            this.lblInventoryUMCls.Size = new System.Drawing.Size(124, 34);
            this.lblInventoryUMCls.TabIndex = 17;
            this.lblInventoryUMCls.Text = "Inventory U/M";
            this.lblInventoryUMCls.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInventoryUMCls.Visible = false;
            // 
            // cboInventoryUM
            // 
            this.cboInventoryUM.AppearanceName = "";
            this.cboInventoryUM.AppearanceReadOnlyName = "";
            this.cboInventoryUM.BackColor = System.Drawing.Color.White;
            this.cboInventoryUM.ControlID = null;
            this.cboInventoryUM.DropDownHeight = 180;
            this.cboInventoryUM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboInventoryUM.ForeColor = System.Drawing.Color.Black;
            this.cboInventoryUM.FormattingEnabled = true;
            this.cboInventoryUM.IntegralHeight = false;
            this.cboInventoryUM.Location = new System.Drawing.Point(191, 364);
            this.cboInventoryUM.Name = "cboInventoryUM";
            this.cboInventoryUM.PathString = "INV_UM_CLS.Value";
            this.cboInventoryUM.PathValue = null;
            this.cboInventoryUM.Size = new System.Drawing.Size(51, 28);
            this.cboInventoryUM.TabIndex = 16;
            this.cboInventoryUM.Visible = false;
            // 
            // stcRemark
            // 
            this.stcRemark.AppearanceName = "";
            this.stcRemark.ControlID = "";
            this.stcRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.stcRemark.Location = new System.Drawing.Point(56, 331);
            this.stcRemark.Name = "stcRemark";
            this.stcRemark.PathString = null;
            this.stcRemark.PathValue = "Remark";
            this.stcRemark.Size = new System.Drawing.Size(124, 29);
            this.stcRemark.TabIndex = 15;
            this.stcRemark.Text = "Remark";
            this.stcRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcLotNo
            // 
            this.stcLotNo.AppearanceName = "";
            this.stcLotNo.ControlID = "";
            this.stcLotNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.stcLotNo.Location = new System.Drawing.Point(56, 458);
            this.stcLotNo.Name = "stcLotNo";
            this.stcLotNo.PathString = null;
            this.stcLotNo.PathValue = "hiddenLot No.";
            this.stcLotNo.Size = new System.Drawing.Size(124, 27);
            this.stcLotNo.TabIndex = 14;
            this.stcLotNo.Text = "hiddenLot No.";
            this.stcLotNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.stcLotNo.Visible = false;
            // 
            // stcOnhandQty
            // 
            this.stcOnhandQty.AppearanceName = "";
            this.stcOnhandQty.ControlID = "";
            this.stcOnhandQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.stcOnhandQty.Location = new System.Drawing.Point(56, 262);
            this.stcOnhandQty.Name = "stcOnhandQty";
            this.stcOnhandQty.PathString = null;
            this.stcOnhandQty.PathValue = "On Hand Qty";
            this.stcOnhandQty.Size = new System.Drawing.Size(124, 33);
            this.stcOnhandQty.TabIndex = 13;
            this.stcOnhandQty.Text = "On Hand Qty";
            this.stcOnhandQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcAdjustQty
            // 
            this.stcAdjustQty.AppearanceName = "";
            this.stcAdjustQty.ControlID = "";
            this.stcAdjustQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.stcAdjustQty.Location = new System.Drawing.Point(56, 296);
            this.stcAdjustQty.Name = "stcAdjustQty";
            this.stcAdjustQty.PathString = null;
            this.stcAdjustQty.PathValue = "Adjust Qty";
            this.stcAdjustQty.Size = new System.Drawing.Size(124, 33);
            this.stcAdjustQty.TabIndex = 12;
            this.stcAdjustQty.Text = "Adjust Qty";
            this.stcAdjustQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcStoredLoc
            // 
            this.stcStoredLoc.AppearanceName = "";
            this.stcStoredLoc.ControlID = "";
            this.stcStoredLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.stcStoredLoc.Location = new System.Drawing.Point(56, 229);
            this.stcStoredLoc.Name = "stcStoredLoc";
            this.stcStoredLoc.PathString = null;
            this.stcStoredLoc.PathValue = "Store Loc";
            this.stcStoredLoc.Size = new System.Drawing.Size(124, 33);
            this.stcStoredLoc.TabIndex = 11;
            this.stcStoredLoc.Text = "Store Loc";
            this.stcStoredLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcItemDesc
            // 
            this.stcItemDesc.AppearanceName = "";
            this.stcItemDesc.ControlID = "";
            this.stcItemDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.stcItemDesc.Location = new System.Drawing.Point(56, 196);
            this.stcItemDesc.Name = "stcItemDesc";
            this.stcItemDesc.PathString = null;
            this.stcItemDesc.PathValue = "Customer Name";
            this.stcItemDesc.Size = new System.Drawing.Size(124, 32);
            this.stcItemDesc.TabIndex = 10;
            this.stcItemDesc.Text = "Customer Name";
            this.stcItemDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcItemCode
            // 
            this.stcItemCode.AppearanceName = "";
            this.stcItemCode.ControlID = "";
            this.stcItemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.stcItemCode.Location = new System.Drawing.Point(387, 162);
            this.stcItemCode.Name = "stcItemCode";
            this.stcItemCode.PathString = null;
            this.stcItemCode.PathValue = "Part No.";
            this.stcItemCode.Size = new System.Drawing.Size(80, 35);
            this.stcItemCode.TabIndex = 6;
            this.stcItemCode.Text = "Part No.";
            this.stcItemCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.AppearanceName = "";
            this.txtCustomerName.AppearanceReadOnlyName = "";
            this.txtCustomerName.ControlID = "";
            this.txtCustomerName.DisableRestrictChar = false;
            this.txtCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtCustomerName.ForeColor = System.Drawing.Color.Black;
            this.txtCustomerName.HelpButton = null;
            this.txtCustomerName.Location = new System.Drawing.Point(191, 199);
            this.txtCustomerName.MaxLength = 50;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.PathString = "CustomerName.Value";
            this.txtCustomerName.PathValue = "";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(684, 26);
            this.txtCustomerName.TabIndex = 5;
            this.txtCustomerName.TabStop = false;
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
            this.txtRemark.Location = new System.Drawing.Point(191, 332);
            this.txtRemark.MaxLength = 255;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.PathString = "Remark.Value";
            this.txtRemark.PathValue = "";
            this.txtRemark.Size = new System.Drawing.Size(684, 26);
            this.txtRemark.TabIndex = 15;
            this.txtRemark.TabStop = false;
            // 
            // cboStoredLoc
            // 
            this.cboStoredLoc.AppearanceName = "";
            this.cboStoredLoc.AppearanceReadOnlyName = "";
            this.cboStoredLoc.BackColor = System.Drawing.Color.White;
            this.cboStoredLoc.ControlID = null;
            this.cboStoredLoc.DropDownHeight = 180;
            this.cboStoredLoc.ForeColor = System.Drawing.Color.Black;
            this.cboStoredLoc.FormattingEnabled = true;
            this.cboStoredLoc.IntegralHeight = false;
            this.cboStoredLoc.Location = new System.Drawing.Point(191, 232);
            this.cboStoredLoc.Name = "cboStoredLoc";
            this.cboStoredLoc.PathString = "StoredLoc.Value";
            this.cboStoredLoc.PathValue = null;
            this.cboStoredLoc.Size = new System.Drawing.Size(684, 27);
            this.cboStoredLoc.TabIndex = 6;
            this.cboStoredLoc.SelectedValueChanged += new System.EventHandler(this.cboStoredLoc_SelectedValueChanged);
            this.cboStoredLoc.TextChanged += new System.EventHandler(this.cboStoredLoc_TextChanged);
            // 
            // btnItemCode
            // 
            this.btnItemCode.AppearanceName = "";
            this.btnItemCode.AutoSize = true;
            this.btnItemCode.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnItemCode.BackgroundImage")));
            this.btnItemCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnItemCode.ControlID = null;
            this.btnItemCode.Location = new System.Drawing.Point(349, 165);
            this.btnItemCode.Name = "btnItemCode";
            this.btnItemCode.Size = new System.Drawing.Size(32, 29);
            this.btnItemCode.TabIndex = 5;
            this.btnItemCode.TabStop = false;
            this.btnItemCode.UseVisualStyleBackColor = true;
            // 
            // txtLotNo
            // 
            this.txtLotNo.AppearanceName = "";
            this.txtLotNo.AppearanceReadOnlyName = "";
            this.txtLotNo.BackColor = System.Drawing.Color.White;
            this.txtLotNo.ControlID = "";
            this.txtLotNo.DisableRestrictChar = false;
            this.txtLotNo.ForeColor = System.Drawing.Color.Black;
            this.txtLotNo.HelpButton = this.btnLotNo;
            this.txtLotNo.Location = new System.Drawing.Point(191, 458);
            this.txtLotNo.MaxLength = 50;
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.PathString = "LotNo.Value";
            this.txtLotNo.PathValue = "";
            this.txtLotNo.Size = new System.Drawing.Size(646, 27);
            this.txtLotNo.TabIndex = 9;
            this.txtLotNo.Visible = false;
            this.txtLotNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLotNo_KeyPress);
            this.txtLotNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtLotNo_Validating);
            // 
            // btnLotNo
            // 
            this.btnLotNo.AppearanceName = "";
            this.btnLotNo.AutoSize = true;
            this.btnLotNo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLotNo.BackgroundImage")));
            this.btnLotNo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLotNo.ControlID = null;
            this.btnLotNo.Location = new System.Drawing.Point(841, 457);
            this.btnLotNo.Name = "btnLotNo";
            this.btnLotNo.Size = new System.Drawing.Size(32, 29);
            this.btnLotNo.TabIndex = 10;
            this.btnLotNo.TabStop = false;
            this.btnLotNo.UseVisualStyleBackColor = true;
            this.btnLotNo.Visible = false;
            this.btnLotNo.Click += new System.EventHandler(this.btnLotNo_Click);
            // 
            // evoLabel1
            // 
            this.evoLabel1.AppearanceName = "RequireText";
            this.evoLabel1.AutoSize = true;
            this.evoLabel1.ControlID = "";
            this.evoLabel1.Location = new System.Drawing.Point(37, 171);
            this.evoLabel1.Name = "evoLabel1";
            this.evoLabel1.PathString = null;
            this.evoLabel1.PathValue = "*";
            this.evoLabel1.Size = new System.Drawing.Size(18, 19);
            this.evoLabel1.TabIndex = 16;
            this.evoLabel1.Text = "*";
            this.evoLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // evoLabel2
            // 
            this.evoLabel2.AppearanceName = "RequireText";
            this.evoLabel2.AutoSize = true;
            this.evoLabel2.ControlID = "";
            this.evoLabel2.Location = new System.Drawing.Point(37, 238);
            this.evoLabel2.Name = "evoLabel2";
            this.evoLabel2.PathString = null;
            this.evoLabel2.PathValue = "*";
            this.evoLabel2.Size = new System.Drawing.Size(18, 19);
            this.evoLabel2.TabIndex = 16;
            this.evoLabel2.Text = "*";
            this.evoLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // evoLabel3
            // 
            this.evoLabel3.AppearanceName = "RequireText";
            this.evoLabel3.AutoSize = true;
            this.evoLabel3.ControlID = "";
            this.evoLabel3.Location = new System.Drawing.Point(37, 305);
            this.evoLabel3.Name = "evoLabel3";
            this.evoLabel3.PathString = null;
            this.evoLabel3.PathValue = "*";
            this.evoLabel3.Size = new System.Drawing.Size(18, 19);
            this.evoLabel3.TabIndex = 16;
            this.evoLabel3.Text = "*";
            this.evoLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAdjustWeight
            // 
            this.txtAdjustWeight.AllowNegative = false;
            this.txtAdjustWeight.AppearanceName = "";
            this.txtAdjustWeight.AppearanceReadOnlyName = "";
            this.txtAdjustWeight.BackColor = System.Drawing.Color.White;
            this.txtAdjustWeight.ControlID = "";
            this.txtAdjustWeight.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtAdjustWeight.DecimalPoint = '.';
            this.txtAdjustWeight.DigitsInGroup = 3;
            this.txtAdjustWeight.Double = 0D;
            this.txtAdjustWeight.FixDecimalPosition = false;
            this.txtAdjustWeight.Flags = 65536;
            this.txtAdjustWeight.ForeColor = System.Drawing.Color.Black;
            this.txtAdjustWeight.GroupSeparator = ',';
            this.txtAdjustWeight.Int = 0;
            this.txtAdjustWeight.Location = new System.Drawing.Point(191, 299);
            this.txtAdjustWeight.Long = ((long)(0));
            this.txtAdjustWeight.MaxDecimalPlaces = 6;
            this.txtAdjustWeight.MaxWholeDigits = 10;
            this.txtAdjustWeight.Name = "txtAdjustWeight";
            this.txtAdjustWeight.NegativeSign = '-';
            this.txtAdjustWeight.PathString = "AdjustWeight.Value";
            this.txtAdjustWeight.PathValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtAdjustWeight.Prefix = "";
            this.txtAdjustWeight.RangeMax = 1.7976931348623157E+308D;
            this.txtAdjustWeight.RangeMin = -1.7976931348623157E+308D;
            this.txtAdjustWeight.Size = new System.Drawing.Size(280, 27);
            this.txtAdjustWeight.TabIndex = 13;
            this.txtAdjustWeight.Text = "0";
            this.txtAdjustWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAdjustWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAdjustWeight_KeyPress);
            this.txtAdjustWeight.Validating += new System.ComponentModel.CancelEventHandler(this.txtAdjustWeight_Validating);
            // 
            // cboReasonCode
            // 
            this.cboReasonCode.AppearanceName = "";
            this.cboReasonCode.AppearanceReadOnlyName = "";
            this.cboReasonCode.BackColor = System.Drawing.Color.White;
            this.cboReasonCode.ControlID = "";
            this.cboReasonCode.DropDownHeight = 180;
            this.cboReasonCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboReasonCode.ForeColor = System.Drawing.Color.Black;
            this.cboReasonCode.FormattingEnabled = true;
            this.cboReasonCode.IntegralHeight = false;
            this.cboReasonCode.Location = new System.Drawing.Point(191, 132);
            this.cboReasonCode.MaxLength = 50;
            this.cboReasonCode.Name = "cboReasonCode";
            this.cboReasonCode.PathString = "ReasonCode.Value";
            this.cboReasonCode.PathValue = null;
            this.cboReasonCode.Size = new System.Drawing.Size(684, 28);
            this.cboReasonCode.TabIndex = 2;
            // 
            // lblReasonCode
            // 
            this.lblReasonCode.AppearanceName = "";
            this.lblReasonCode.ControlID = "";
            this.lblReasonCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblReasonCode.Location = new System.Drawing.Point(56, 129);
            this.lblReasonCode.Name = "lblReasonCode";
            this.lblReasonCode.PathString = null;
            this.lblReasonCode.PathValue = "Reason";
            this.lblReasonCode.Size = new System.Drawing.Size(124, 34);
            this.lblReasonCode.TabIndex = 10;
            this.lblReasonCode.Text = "Reason";
            this.lblReasonCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // evoLabel5
            // 
            this.evoLabel5.AppearanceName = "RequireText";
            this.evoLabel5.AutoSize = true;
            this.evoLabel5.ControlID = "";
            this.evoLabel5.Location = new System.Drawing.Point(37, 137);
            this.evoLabel5.Name = "evoLabel5";
            this.evoLabel5.PathString = null;
            this.evoLabel5.PathValue = "*";
            this.evoLabel5.Size = new System.Drawing.Size(18, 19);
            this.evoLabel5.TabIndex = 16;
            this.evoLabel5.Text = "*";
            this.evoLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcAdjustType
            // 
            this.stcAdjustType.AppearanceName = "";
            this.stcAdjustType.AutoSize = true;
            this.stcAdjustType.ControlID = "";
            this.stcAdjustType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.stcAdjustType.Location = new System.Drawing.Point(56, 102);
            this.stcAdjustType.Name = "stcAdjustType";
            this.stcAdjustType.PathString = null;
            this.stcAdjustType.PathValue = "Adjust Type";
            this.stcAdjustType.Size = new System.Drawing.Size(92, 20);
            this.stcAdjustType.TabIndex = 7;
            this.stcAdjustType.Text = "Adjust Type";
            this.stcAdjustType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpHeader2
            // 
            this.tlpHeader2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpHeader2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tlpHeader2.BackgroundImage")));
            this.tlpHeader2.ColumnCount = 1;
            this.tlpHeader2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpHeader2.Controls.Add(this.stcTitle, 0, 0);
            this.tlpHeader2.Location = new System.Drawing.Point(0, 69);
            this.tlpHeader2.Margin = new System.Windows.Forms.Padding(0);
            this.tlpHeader2.Name = "tlpHeader2";
            this.tlpHeader2.RowCount = 1;
            this.tlpHeader2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHeader2.Size = new System.Drawing.Size(910, 24);
            this.tlpHeader2.TabIndex = 8;
            // 
            // stcTitle
            // 
            this.stcTitle.AppearanceName = "Header";
            this.stcTitle.AutoSize = true;
            this.stcTitle.ControlID = "";
            this.stcTitle.Location = new System.Drawing.Point(0, 0);
            this.stcTitle.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.stcTitle.Name = "stcTitle";
            this.stcTitle.PathString = null;
            this.stcTitle.PathValue = "Adjust Information";
            this.stcTitle.Size = new System.Drawing.Size(144, 19);
            this.stcTitle.TabIndex = 0;
            this.stcTitle.Text = "Adjust Information";
            // 
            // pnlAdjustType
            // 
            this.pnlAdjustType.AppearanceName = "";
            this.pnlAdjustType.AutoSize = true;
            this.pnlAdjustType.Controls.Add(this.rdoDecrease);
            this.pnlAdjustType.Controls.Add(this.rdoIncrease);
            this.pnlAdjustType.Location = new System.Drawing.Point(193, 96);
            this.pnlAdjustType.Margin = new System.Windows.Forms.Padding(0);
            this.pnlAdjustType.Name = "pnlAdjustType";
            this.pnlAdjustType.Size = new System.Drawing.Size(249, 29);
            this.pnlAdjustType.TabIndex = 0;
            // 
            // rdoDecrease
            // 
            this.rdoDecrease.AppearanceName = "";
            this.rdoDecrease.AutoSize = true;
            this.rdoDecrease.ControlID = null;
            this.rdoDecrease.Location = new System.Drawing.Point(156, 3);
            this.rdoDecrease.Name = "rdoDecrease";
            this.rdoDecrease.PathString = "AdjustType.Value";
            this.rdoDecrease.Size = new System.Drawing.Size(90, 23);
            this.rdoDecrease.SpecificValue = "02";
            this.rdoDecrease.TabIndex = 1;
            this.rdoDecrease.TabStop = true;
            this.rdoDecrease.Text = "Decrease";
            this.rdoDecrease.UseVisualStyleBackColor = true;
            this.rdoDecrease.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            this.rdoDecrease.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rdoIncrease_KeyPress);
            // 
            // rdoIncrease
            // 
            this.rdoIncrease.AppearanceName = "";
            this.rdoIncrease.AutoSize = true;
            this.rdoIncrease.Checked = true;
            this.rdoIncrease.ControlID = null;
            this.rdoIncrease.Location = new System.Drawing.Point(3, 3);
            this.rdoIncrease.Name = "rdoIncrease";
            this.rdoIncrease.PathString = "AdjustType.Value";
            this.rdoIncrease.Size = new System.Drawing.Size(86, 23);
            this.rdoIncrease.SpecificValue = "01";
            this.rdoIncrease.TabIndex = 0;
            this.rdoIncrease.TabStop = true;
            this.rdoIncrease.Text = "Increase";
            this.rdoIncrease.UseVisualStyleBackColor = true;
            this.rdoIncrease.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            this.rdoIncrease.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rdoIncrease_KeyPress);
            // 
            // lblUnitKGS
            // 
            this.lblUnitKGS.AppearanceName = "";
            this.lblUnitKGS.AutoSize = true;
            this.lblUnitKGS.ControlID = "";
            this.lblUnitKGS.Location = new System.Drawing.Point(477, 301);
            this.lblUnitKGS.Name = "lblUnitKGS";
            this.lblUnitKGS.PathString = null;
            this.lblUnitKGS.PathValue = "KG";
            this.lblUnitKGS.Size = new System.Drawing.Size(29, 19);
            this.lblUnitKGS.TabIndex = 100003;
            this.lblUnitKGS.Text = "KG";
            // 
            // txtOnhandQty
            // 
            this.txtOnhandQty.AllowNegative = true;
            this.txtOnhandQty.AppearanceName = "";
            this.txtOnhandQty.AppearanceReadOnlyName = "";
            this.txtOnhandQty.ControlID = "";
            this.txtOnhandQty.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOnhandQty.DecimalPoint = '.';
            this.txtOnhandQty.DigitsInGroup = 3;
            this.txtOnhandQty.Double = 0D;
            this.txtOnhandQty.FixDecimalPosition = false;
            this.txtOnhandQty.Flags = 0;
            this.txtOnhandQty.ForeColor = System.Drawing.Color.Black;
            this.txtOnhandQty.GroupSeparator = ',';
            this.txtOnhandQty.Int = 0;
            this.txtOnhandQty.Location = new System.Drawing.Point(191, 265);
            this.txtOnhandQty.Long = ((long)(0));
            this.txtOnhandQty.MaxDecimalPlaces = 6;
            this.txtOnhandQty.MaxWholeDigits = 10;
            this.txtOnhandQty.Name = "txtOnhandQty";
            this.txtOnhandQty.NegativeSign = '-';
            this.txtOnhandQty.PathString = "OnHandQty.Value";
            this.txtOnhandQty.PathValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOnhandQty.Prefix = "";
            this.txtOnhandQty.RangeMax = 1.7976931348623157E+308D;
            this.txtOnhandQty.RangeMin = -1.7976931348623157E+308D;
            this.txtOnhandQty.ReadOnly = true;
            this.txtOnhandQty.Size = new System.Drawing.Size(646, 27);
            this.txtOnhandQty.TabIndex = 12;
            this.txtOnhandQty.TabStop = false;
            this.txtOnhandQty.Text = "0";
            this.txtOnhandQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAdjustQty
            // 
            this.txtAdjustQty.AllowNegative = false;
            this.txtAdjustQty.AppearanceName = "";
            this.txtAdjustQty.AppearanceReadOnlyName = "";
            this.txtAdjustQty.BackColor = System.Drawing.Color.White;
            this.txtAdjustQty.ControlID = "";
            this.txtAdjustQty.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtAdjustQty.DecimalPoint = '.';
            this.txtAdjustQty.DigitsInGroup = 3;
            this.txtAdjustQty.Double = 0D;
            this.txtAdjustQty.FixDecimalPosition = false;
            this.txtAdjustQty.Flags = 65536;
            this.txtAdjustQty.ForeColor = System.Drawing.Color.Black;
            this.txtAdjustQty.GroupSeparator = ',';
            this.txtAdjustQty.Int = 0;
            this.txtAdjustQty.Location = new System.Drawing.Point(557, 299);
            this.txtAdjustQty.Long = ((long)(0));
            this.txtAdjustQty.MaxDecimalPlaces = 6;
            this.txtAdjustQty.MaxWholeDigits = 10;
            this.txtAdjustQty.Name = "txtAdjustQty";
            this.txtAdjustQty.NegativeSign = '-';
            this.txtAdjustQty.PathString = "AdjustQty.Value";
            this.txtAdjustQty.PathValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtAdjustQty.Prefix = "";
            this.txtAdjustQty.RangeMax = 1.7976931348623157E+308D;
            this.txtAdjustQty.RangeMin = -1.7976931348623157E+308D;
            this.txtAdjustQty.Size = new System.Drawing.Size(280, 27);
            this.txtAdjustQty.TabIndex = 14;
            this.txtAdjustQty.Text = "0";
            this.txtAdjustQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAdjustQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAdjustQty_KeyPress);
            // 
            // evoLabel7
            // 
            this.evoLabel7.AppearanceName = "";
            this.evoLabel7.AutoSize = true;
            this.evoLabel7.ControlID = "";
            this.evoLabel7.Location = new System.Drawing.Point(837, 270);
            this.evoLabel7.Name = "evoLabel7";
            this.evoLabel7.PathString = null;
            this.evoLabel7.PathValue = "PCS";
            this.evoLabel7.Size = new System.Drawing.Size(37, 19);
            this.evoLabel7.TabIndex = 100006;
            this.evoLabel7.Text = "PCS";
            // 
            // lblUnitPCS
            // 
            this.lblUnitPCS.AppearanceName = "";
            this.lblUnitPCS.AutoSize = true;
            this.lblUnitPCS.ControlID = "";
            this.lblUnitPCS.Location = new System.Drawing.Point(837, 303);
            this.lblUnitPCS.Name = "lblUnitPCS";
            this.lblUnitPCS.PathString = null;
            this.lblUnitPCS.PathValue = "PCS";
            this.lblUnitPCS.Size = new System.Drawing.Size(37, 19);
            this.lblUnitPCS.TabIndex = 100005;
            this.lblUnitPCS.Text = "PCS";
            // 
            // evoLabel8
            // 
            this.evoLabel8.AppearanceName = "";
            this.evoLabel8.ControlID = "";
            this.evoLabel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel8.Location = new System.Drawing.Point(56, 162);
            this.evoLabel8.Name = "evoLabel8";
            this.evoLabel8.PathString = null;
            this.evoLabel8.PathValue = "Master No.";
            this.evoLabel8.Size = new System.Drawing.Size(87, 35);
            this.evoLabel8.TabIndex = 6;
            this.evoLabel8.Text = "Master No.";
            this.evoLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtItemDesc
            // 
            this.txtItemDesc.AppearanceName = "";
            this.txtItemDesc.AppearanceReadOnlyName = "";
            this.txtItemDesc.ControlID = "";
            this.txtItemDesc.DisableRestrictChar = false;
            this.txtItemDesc.HelpButton = null;
            this.txtItemDesc.Location = new System.Drawing.Point(451, 165);
            this.txtItemDesc.MaxLength = 50;
            this.txtItemDesc.Name = "txtItemDesc";
            this.txtItemDesc.PathString = "ItemDesc.Value";
            this.txtItemDesc.PathValue = "";
            this.txtItemDesc.ReadOnly = true;
            this.txtItemDesc.Size = new System.Drawing.Size(422, 27);
            this.txtItemDesc.TabIndex = 4;
            this.txtItemDesc.Validating += new System.ComponentModel.CancelEventHandler(this.txtItemDesc_Validating);
            // 
            // lblPackNo
            // 
            this.lblPackNo.AppearanceName = "";
            this.lblPackNo.ControlID = "";
            this.lblPackNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPackNo.Location = new System.Drawing.Point(56, 395);
            this.lblPackNo.Name = "lblPackNo";
            this.lblPackNo.PathString = null;
            this.lblPackNo.PathValue = "hiddenPack No.";
            this.lblPackNo.Size = new System.Drawing.Size(124, 27);
            this.lblPackNo.TabIndex = 100008;
            this.lblPackNo.Text = "hiddenPack No.";
            this.lblPackNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPackNo.Visible = false;
            // 
            // txtPackNo
            // 
            this.txtPackNo.AppearanceName = "";
            this.txtPackNo.AppearanceReadOnlyName = "";
            this.txtPackNo.ControlID = "";
            this.txtPackNo.DisableRestrictChar = false;
            this.txtPackNo.HelpButton = null;
            this.txtPackNo.Location = new System.Drawing.Point(191, 395);
            this.txtPackNo.MaxLength = 30;
            this.txtPackNo.Name = "txtPackNo";
            this.txtPackNo.PathString = "PackNo.Value";
            this.txtPackNo.PathValue = "";
            this.txtPackNo.Size = new System.Drawing.Size(682, 27);
            this.txtPackNo.TabIndex = 7;
            this.txtPackNo.Visible = false;
            // 
            // hiddenTransID
            // 
            this.hiddenTransID.AppearanceName = "";
            this.hiddenTransID.AutoSize = true;
            this.hiddenTransID.ControlID = "";
            this.hiddenTransID.Location = new System.Drawing.Point(291, 368);
            this.hiddenTransID.Name = "hiddenTransID";
            this.hiddenTransID.PathString = "TransactionID.Value";
            this.hiddenTransID.PathValue = "hiddenFromTransID";
            this.hiddenTransID.Size = new System.Drawing.Size(151, 19);
            this.hiddenTransID.TabIndex = 100010;
            this.hiddenTransID.Text = "hiddenFromTransID";
            this.hiddenTransID.Visible = false;
            // 
            // evoLabel6
            // 
            this.evoLabel6.AppearanceName = "RequireText";
            this.evoLabel6.AutoSize = true;
            this.evoLabel6.ControlID = "";
            this.evoLabel6.Location = new System.Drawing.Point(37, 101);
            this.evoLabel6.Name = "evoLabel6";
            this.evoLabel6.PathString = null;
            this.evoLabel6.PathValue = "*";
            this.evoLabel6.Size = new System.Drawing.Size(18, 19);
            this.evoLabel6.TabIndex = 100011;
            this.evoLabel6.Text = "*";
            this.evoLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // evoLabel9
            // 
            this.evoLabel9.AppearanceName = "";
            this.evoLabel9.ControlID = "";
            this.evoLabel9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel9.Location = new System.Drawing.Point(56, 491);
            this.evoLabel9.Name = "evoLabel9";
            this.evoLabel9.PathString = null;
            this.evoLabel9.PathValue = "hiddenCustomer Lot No.";
            this.evoLabel9.Size = new System.Drawing.Size(140, 27);
            this.evoLabel9.TabIndex = 14;
            this.evoLabel9.Text = "hiddenCustomer Lot No.";
            this.evoLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.evoLabel9.Visible = false;
            // 
            // txtCustomerLotNo
            // 
            this.txtCustomerLotNo.AppearanceName = "";
            this.txtCustomerLotNo.AppearanceReadOnlyName = "";
            this.txtCustomerLotNo.ControlID = "";
            this.txtCustomerLotNo.DisableRestrictChar = false;
            this.txtCustomerLotNo.HelpButton = null;
            this.txtCustomerLotNo.Location = new System.Drawing.Point(191, 491);
            this.txtCustomerLotNo.MaxLength = 50;
            this.txtCustomerLotNo.Name = "txtCustomerLotNo";
            this.txtCustomerLotNo.PathString = "ExternalLotNo.Value";
            this.txtCustomerLotNo.PathValue = "";
            this.txtCustomerLotNo.Size = new System.Drawing.Size(682, 27);
            this.txtCustomerLotNo.TabIndex = 11;
            this.txtCustomerLotNo.Visible = false;
            // 
            // txtMasterNo
            // 
            this.txtMasterNo.AllowNegative = true;
            this.txtMasterNo.AppearanceName = "";
            this.txtMasterNo.AppearanceReadOnlyName = "";
            this.txtMasterNo.BackColor = System.Drawing.Color.White;
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
            this.txtMasterNo.DescriptionTextBox = this.txtItemDesc;
            this.txtMasterNo.DigitsInGroup = 0;
            this.txtMasterNo.Double = 0D;
            this.txtMasterNo.FixDecimalPosition = false;
            this.txtMasterNo.Flags = 0;
            this.txtMasterNo.ForeColor = System.Drawing.Color.Black;
            this.txtMasterNo.GroupSeparator = ',';
            this.txtMasterNo.HelpButton = this.btnItemCode;
            this.txtMasterNo.Int = 0;
            this.txtMasterNo.ItemType = new Rubik.eItemType[0];
            this.txtMasterNo.Location = new System.Drawing.Point(191, 166);
            this.txtMasterNo.Long = ((long)(0));
            this.txtMasterNo.MaxDecimalPlaces = 0;
            this.txtMasterNo.MaxLength = 10;
            this.txtMasterNo.MaxWholeDigits = 10;
            this.txtMasterNo.Name = "txtMasterNo";
            this.txtMasterNo.NegativeSign = '-';
            this.txtMasterNo.PathString = "ItemCode.Value";
            this.txtMasterNo.PathValue = "";
            this.txtMasterNo.Prefix = "";
            this.txtMasterNo.RangeMax = 9999999999D;
            this.txtMasterNo.RangeMin = 0D;
            this.txtMasterNo.SelectedCustomerData = null;
            this.txtMasterNo.SelectedItemData = null;
            this.txtMasterNo.SelectedItemProcessData = null;
            this.txtMasterNo.Size = new System.Drawing.Size(152, 27);
            this.txtMasterNo.SqlOperator = Rubik.eSqlOperator.In;
            this.txtMasterNo.TabIndex = 3;
            this.txtMasterNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMasterNo.KeyPressResult += new Rubik.Forms.UserControl.ItemFoundHandler(this.txtItemCode_KeyPressResult);
            this.txtMasterNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItemCode_KeyPress);
            this.txtMasterNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtMasterNo_Validating);
            // 
            // txtFGNo
            // 
            this.txtFGNo.AppearanceName = "";
            this.txtFGNo.AppearanceReadOnlyName = "";
            this.txtFGNo.ControlID = "";
            this.txtFGNo.DisableRestrictChar = false;
            this.txtFGNo.HelpButton = null;
            this.txtFGNo.Location = new System.Drawing.Point(191, 426);
            this.txtFGNo.MaxLength = 50;
            this.txtFGNo.Name = "txtFGNo";
            this.txtFGNo.PathString = "FGNo.Value";
            this.txtFGNo.PathValue = "";
            this.txtFGNo.Size = new System.Drawing.Size(682, 27);
            this.txtFGNo.TabIndex = 8;
            this.txtFGNo.Visible = false;
            // 
            // evoLabel10
            // 
            this.evoLabel10.AppearanceName = "";
            this.evoLabel10.ControlID = "";
            this.evoLabel10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel10.Location = new System.Drawing.Point(56, 426);
            this.evoLabel10.Name = "evoLabel10";
            this.evoLabel10.PathString = null;
            this.evoLabel10.PathValue = "hiddenFG No.";
            this.evoLabel10.Size = new System.Drawing.Size(124, 27);
            this.evoLabel10.TabIndex = 100013;
            this.evoLabel10.Text = "hiddenFG No.";
            this.evoLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.evoLabel10.Visible = false;
            // 
            // TRN120
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(896, 591);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(740, 442);
            this.Name = "TRN120";
            this.Text = "Adjust Entry";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TRN120_Load);
            this.Shown += new System.EventHandler(this.TRN120_Shown);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tlpHeader2.ResumeLayout(false);
            this.tlpHeader2.PerformLayout();
            this.pnlAdjustType.ResumeLayout(false);
            this.pnlAdjustType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EVOFramework.Windows.Forms.EVOLabel stcItemCode;
        private EVOFramework.Windows.Forms.EVOLabel stcAdjustType;
        private System.Windows.Forms.TableLayoutPanel tlpHeader2;
        private EVOFramework.Windows.Forms.EVOLabel stcTitle;
        private EVOFramework.Windows.Forms.EVOLabel stcItemDesc;
        private EVOFramework.Windows.Forms.EVOLabel stcRemark;
        private EVOFramework.Windows.Forms.EVOLabel stcLotNo;
        private EVOFramework.Windows.Forms.EVOLabel stcOnhandQty;
        private EVOFramework.Windows.Forms.EVOLabel stcAdjustQty;
        private EVOFramework.Windows.Forms.EVOLabel stcStoredLoc;
        private EVOFramework.Windows.Forms.EVOTextBox txtCustomerName;
        private EVOFramework.Windows.Forms.EVOTextBox txtRemark;
        private EVOFramework.Windows.Forms.EVOPanel pnlAdjustType;
        private EVOFramework.Windows.Forms.EVORadioButton rdoDecrease;
        private EVOFramework.Windows.Forms.EVORadioButton rdoIncrease;
        private EVOFramework.Windows.Forms.EVOComboBox cboStoredLoc;
        private EVOFramework.Windows.Forms.EVOButton btnItemCode;
        private EVOFramework.Windows.Forms.EVOPanel pnlHeader;
        private EVOFramework.Windows.Forms.EVOLabel stcHeader;
        private EVOFramework.Windows.Forms.EVOLabel stcAdjustDate;
        private EVOFramework.Windows.Forms.EVOLabel stcTransactionID;
        private EVOFramework.Windows.Forms.EVOLabel lblAdjustNo;
        private Rubik.Forms.UserControl.ItemTextBox txtMasterNo;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtAdjustDate;
        private EVOFramework.Data.UIDataModelController dmcAdjust;
        private EVOFramework.Windows.Forms.EVOTextBox txtLotNo;
        private EVOFramework.Windows.Forms.EVOButton btnLotNo;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel1;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel2;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel3;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel4;
        private EVOFramework.Windows.Forms.EVONumericTextBox txtAdjustWeight;
        private EVOFramework.Windows.Forms.EVOLabel lblInventoryUMCls;
        private EVOFramework.Windows.Forms.EVOComboBox cboInventoryUM;
        private EVOFramework.Windows.Forms.EVOLabel lblReasonCode;
        private EVOFramework.Windows.Forms.EVOComboBox cboReasonCode;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel5;
        protected EVOFramework.Windows.Forms.EVOLabel lblUnitKGS;
        private EVOFramework.Windows.Forms.EVONumericTextBox txtAdjustQty;
        private EVOFramework.Windows.Forms.EVONumericTextBox txtOnhandQty;
        protected EVOFramework.Windows.Forms.EVOLabel evoLabel7;
        protected EVOFramework.Windows.Forms.EVOLabel lblUnitPCS;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel8;
        private EVOFramework.Windows.Forms.EVOTextBox txtItemDesc;
        private EVOFramework.Windows.Forms.EVOTextBox txtPackNo;
        private EVOFramework.Windows.Forms.EVOLabel lblPackNo;
        private EVOFramework.Windows.Forms.EVOLabel hiddenTransID;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel6;
        private EVOFramework.Windows.Forms.EVOTextBox txtCustomerLotNo;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel9;
        private EVOFramework.Windows.Forms.EVOTextBox txtFGNo;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel10;

    }
}
