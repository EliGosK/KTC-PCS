namespace Rubik.Transaction
{
    partial class TRN140
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TRN140));
            this.lblHeader = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblIssueDate = new EVOFramework.Windows.Forms.EVOLabel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new EVOFramework.Windows.Forms.EVOLabel();
            this.tlpHeader2 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new EVOFramework.Windows.Forms.EVOLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new EVOFramework.Windows.Forms.EVOPanel();
            this.dtIssueDate = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.lblTransactionID = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtTransactionID = new EVOFramework.Windows.Forms.EVOLabel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblInventoryUMCls = new EVOFramework.Windows.Forms.EVOLabel();
            this.btnItemCode = new EVOFramework.Windows.Forms.EVOButton();
            this.cboInventoryUM = new EVOFramework.Windows.Forms.EVOComboBox();
            this.txtRemark = new EVOFramework.Windows.Forms.EVOTextBox();
            this.txtIssueQty = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.txtOnHandQty = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.cboToLoc = new EVOFramework.Windows.Forms.EVOComboBox();
            this.txtItemDesc = new EVOFramework.Windows.Forms.EVOTextBox();
            this.panel2 = new EVOFramework.Windows.Forms.EVOPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSubHeader = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblItemCode = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblItemDesc = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblFromLoc = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblToLoc = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblLotNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblOnHandQty = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblIssueQty = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblRemark = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboFromLoc = new EVOFramework.Windows.Forms.EVOComboBox();
            this.evoLabel1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel2 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel3 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel4 = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblForCustomer = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblForMachine = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtForMachine = new EVOFramework.Windows.Forms.EVOTextBox();
            this.cboForCustomer = new EVOFramework.Windows.Forms.EVOComboBox();
            this.txtRefDocNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.txtJobOrderNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblRefDocNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblJobOrderNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtItemCode = new Rubik.Forms.UserControl.ItemTextBox();
            this.txtLotNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.btnLotNo = new EVOFramework.Windows.Forms.EVOButton();
            this.dmcIssueByItem = new EVOFramework.Data.UIDataModelController(this.components);
            this.pnlContainer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.tableLayoutPanel2);
            this.pnlContainer.Controls.Add(this.tableLayoutPanel1);
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlContainer.Size = new System.Drawing.Size(638, 626);
            // 
            // lblHeader
            // 
            this.lblHeader.AppearanceName = "Title";
            this.lblHeader.AutoSize = true;
            this.lblHeader.ControlID = "";
            this.lblHeader.Font = new System.Drawing.Font("Tahoma", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblHeader.Location = new System.Drawing.Point(3, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.PathString = null;
            this.lblHeader.PathValue = "Issue  Consumption";
            this.lblHeader.Size = new System.Drawing.Size(332, 39);
            this.lblHeader.TabIndex = 35;
            this.lblHeader.Text = "Issue  Consumption";
            // 
            // lblIssueDate
            // 
            this.lblIssueDate.AppearanceName = "";
            this.lblIssueDate.AutoSize = true;
            this.lblIssueDate.ControlID = "";
            this.lblIssueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblIssueDate.Location = new System.Drawing.Point(15, 42);
            this.lblIssueDate.Name = "lblIssueDate";
            this.lblIssueDate.PathString = null;
            this.lblIssueDate.PathValue = "Issue Date :";
            this.lblIssueDate.Size = new System.Drawing.Size(95, 20);
            this.lblIssueDate.TabIndex = 46;
            this.lblIssueDate.Text = "Issue Date :";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel4.BackgroundImage")));
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AppearanceName = "";
            this.label9.AutoSize = true;
            this.label9.ControlID = "";
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label9.ForeColor = System.Drawing.Color.Navy;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label9.Name = "label9";
            this.label9.PathString = null;
            this.label9.PathValue = "Process Information";
            this.label9.Size = new System.Drawing.Size(175, 24);
            this.label9.TabIndex = 0;
            this.label9.Text = "Process Information";
            // 
            // tlpHeader2
            // 
            this.tlpHeader2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tlpHeader2.BackgroundImage")));
            this.tlpHeader2.ColumnCount = 1;
            this.tlpHeader2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpHeader2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHeader2.Location = new System.Drawing.Point(0, 0);
            this.tlpHeader2.Name = "tlpHeader2";
            this.tlpHeader2.RowCount = 1;
            this.tlpHeader2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpHeader2.Size = new System.Drawing.Size(200, 100);
            this.tlpHeader2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AppearanceName = "";
            this.label3.AutoSize = true;
            this.label3.ControlID = "";
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label3.Name = "label3";
            this.label3.PathString = null;
            this.label3.PathValue = "Location Information";
            this.label3.Size = new System.Drawing.Size(178, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Location Information";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.53595F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.46405F));
            this.tableLayoutPanel1.Controls.Add(this.lblHeader, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.89802F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(630, 77);
            this.tableLayoutPanel1.TabIndex = 48;
            // 
            // panel1
            // 
            this.panel1.AppearanceName = "";
            this.panel1.Controls.Add(this.dtIssueDate);
            this.panel1.Controls.Add(this.lblIssueDate);
            this.panel1.Controls.Add(this.lblTransactionID);
            this.panel1.Controls.Add(this.txtTransactionID);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(359, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 71);
            this.panel1.TabIndex = 48;
            // 
            // dtIssueDate
            // 
            this.dtIssueDate.AppearanceName = "";
            this.dtIssueDate.AppearanceReadOnlyName = "";
            this.dtIssueDate.BackColor = System.Drawing.Color.Transparent;
            this.dtIssueDate.ControlID = "";
            this.dtIssueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtIssueDate.Format = "dd/MM/yyyy";
            this.dtIssueDate.Location = new System.Drawing.Point(116, 39);
            this.dtIssueDate.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtIssueDate.Name = "dtIssueDate";
            this.dtIssueDate.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtIssueDate.NZValue")));
            this.dtIssueDate.PathString = "TRANS_DATE.Value";
            this.dtIssueDate.PathValue = ((object)(resources.GetObject("dtIssueDate.PathValue")));
            this.dtIssueDate.ReadOnly = false;
            this.dtIssueDate.ShowButton = true;
            this.dtIssueDate.Size = new System.Drawing.Size(150, 26);
            this.dtIssueDate.TabIndex = 1;
            this.dtIssueDate.TabStop = false;
            this.dtIssueDate.Value = null;
            this.dtIssueDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtIssueDate_KeyPress);
            // 
            // lblTransactionID
            // 
            this.lblTransactionID.AppearanceName = "";
            this.lblTransactionID.ControlID = "";
            this.lblTransactionID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblTransactionID.Location = new System.Drawing.Point(15, 6);
            this.lblTransactionID.Name = "lblTransactionID";
            this.lblTransactionID.PathString = null;
            this.lblTransactionID.PathValue = "Transaction ID :";
            this.lblTransactionID.Size = new System.Drawing.Size(121, 30);
            this.lblTransactionID.TabIndex = 48;
            this.lblTransactionID.Text = "Transaction ID :";
            this.lblTransactionID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTransactionID
            // 
            this.txtTransactionID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTransactionID.AppearanceName = "";
            this.txtTransactionID.BackColor = System.Drawing.Color.AliceBlue;
            this.txtTransactionID.ControlID = "";
            this.txtTransactionID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtTransactionID.Location = new System.Drawing.Point(142, 6);
            this.txtTransactionID.Name = "txtTransactionID";
            this.txtTransactionID.PathString = "TRANS_ID.Value";
            this.txtTransactionID.PathValue = "";
            this.txtTransactionID.Size = new System.Drawing.Size(122, 30);
            this.txtTransactionID.TabIndex = 1;
            this.txtTransactionID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.Controls.Add(this.lblInventoryUMCls, 1, 12);
            this.tableLayoutPanel2.Controls.Add(this.btnItemCode, 3, 5);
            this.tableLayoutPanel2.Controls.Add(this.cboInventoryUM, 2, 12);
            this.tableLayoutPanel2.Controls.Add(this.txtRemark, 2, 13);
            this.tableLayoutPanel2.Controls.Add(this.txtIssueQty, 2, 11);
            this.tableLayoutPanel2.Controls.Add(this.txtOnHandQty, 2, 10);
            this.tableLayoutPanel2.Controls.Add(this.cboToLoc, 2, 8);
            this.tableLayoutPanel2.Controls.Add(this.txtItemDesc, 2, 6);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblItemCode, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.lblItemDesc, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.lblFromLoc, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.lblToLoc, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.lblLotNo, 1, 9);
            this.tableLayoutPanel2.Controls.Add(this.lblOnHandQty, 1, 10);
            this.tableLayoutPanel2.Controls.Add(this.lblIssueQty, 1, 11);
            this.tableLayoutPanel2.Controls.Add(this.lblRemark, 1, 13);
            this.tableLayoutPanel2.Controls.Add(this.cboFromLoc, 2, 7);
            this.tableLayoutPanel2.Controls.Add(this.evoLabel1, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.evoLabel2, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.evoLabel3, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.evoLabel4, 0, 11);
            this.tableLayoutPanel2.Controls.Add(this.lblForCustomer, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblForMachine, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtForMachine, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.cboForCustomer, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtRefDocNo, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtJobOrderNo, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblRefDocNo, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblJobOrderNo, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtItemCode, 2, 5);
            this.tableLayoutPanel2.Controls.Add(this.txtLotNo, 2, 9);
            this.tableLayoutPanel2.Controls.Add(this.btnLotNo, 3, 9);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 83);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 14;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(630, 540);
            this.tableLayoutPanel2.TabIndex = 49;
            // 
            // lblInventoryUMCls
            // 
            this.lblInventoryUMCls.AppearanceName = "";
            this.lblInventoryUMCls.ControlID = "";
            this.lblInventoryUMCls.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInventoryUMCls.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblInventoryUMCls.Location = new System.Drawing.Point(33, 398);
            this.lblInventoryUMCls.Name = "lblInventoryUMCls";
            this.lblInventoryUMCls.PathString = null;
            this.lblInventoryUMCls.PathValue = "Inventory U/M";
            this.lblInventoryUMCls.Size = new System.Drawing.Size(142, 34);
            this.lblInventoryUMCls.TabIndex = 73;
            this.lblInventoryUMCls.Text = "Inventory U/M";
            this.lblInventoryUMCls.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnItemCode
            // 
            this.btnItemCode.AppearanceName = "";
            this.btnItemCode.BackgroundImage = global::Rubik.Forms.Properties.Resources.VIEW;
            this.btnItemCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnItemCode.ControlID = null;
            this.btnItemCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnItemCode.Location = new System.Drawing.Point(598, 168);
            this.btnItemCode.Name = "btnItemCode";
            this.btnItemCode.Size = new System.Drawing.Size(29, 28);
            this.btnItemCode.TabIndex = 232321;
            this.btnItemCode.TabStop = false;
            this.btnItemCode.UseVisualStyleBackColor = true;
            this.btnItemCode.Click += new System.EventHandler(this.btnItemCode_Click);
            // 
            // cboInventoryUM
            // 
            this.cboInventoryUM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboInventoryUM.AppearanceName = "";
            this.cboInventoryUM.AppearanceReadOnlyName = "";
            this.tableLayoutPanel2.SetColumnSpan(this.cboInventoryUM, 2);
            this.cboInventoryUM.ControlID = null;
            this.cboInventoryUM.DropDownHeight = 180;
            this.cboInventoryUM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboInventoryUM.FormattingEnabled = true;
            this.cboInventoryUM.IntegralHeight = false;
            this.cboInventoryUM.Location = new System.Drawing.Point(181, 401);
            this.cboInventoryUM.Name = "cboInventoryUM";
            this.cboInventoryUM.PathString = "INV_UM_CLS.Value";
            this.cboInventoryUM.PathValue = null;
            this.cboInventoryUM.Size = new System.Drawing.Size(446, 28);
            this.cboInventoryUM.TabIndex = 13;
            this.cboInventoryUM.TabStop = false;
            // 
            // txtRemark
            // 
            this.txtRemark.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemark.AppearanceName = "";
            this.txtRemark.AppearanceReadOnlyName = "";
            this.tableLayoutPanel2.SetColumnSpan(this.txtRemark, 2);
            this.txtRemark.ControlID = "";
            this.txtRemark.DisableRestrictChar = false;
            this.txtRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtRemark.HelpButton = null;
            this.txtRemark.Location = new System.Drawing.Point(181, 435);
            this.txtRemark.MaxLength = 255;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.PathString = "REMARK.Value";
            this.txtRemark.PathValue = "";
            this.txtRemark.Size = new System.Drawing.Size(446, 26);
            this.txtRemark.TabIndex = 14;
            this.txtRemark.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRemark_KeyPress);
            // 
            // txtIssueQty
            // 
            this.txtIssueQty.AllowNegative = true;
            this.txtIssueQty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIssueQty.AppearanceName = "";
            this.txtIssueQty.AppearanceReadOnlyName = "";
            this.tableLayoutPanel2.SetColumnSpan(this.txtIssueQty, 2);
            this.txtIssueQty.ControlID = "";
            this.txtIssueQty.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtIssueQty.DecimalPoint = '.';
            this.txtIssueQty.DigitsInGroup = 3;
            this.txtIssueQty.Double = 0D;
            this.txtIssueQty.FixDecimalPosition = false;
            this.txtIssueQty.Flags = 0;
            this.txtIssueQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtIssueQty.GroupSeparator = ',';
            this.txtIssueQty.Int = 0;
            this.txtIssueQty.Location = new System.Drawing.Point(181, 369);
            this.txtIssueQty.Long = ((long)(0));
            this.txtIssueQty.MaxDecimalPlaces = 4;
            this.txtIssueQty.MaxWholeDigits = 9;
            this.txtIssueQty.Name = "txtIssueQty";
            this.txtIssueQty.NegativeSign = '\0';
            this.txtIssueQty.PathString = "QTY.Value";
            this.txtIssueQty.PathValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtIssueQty.Prefix = "";
            this.txtIssueQty.RangeMax = 1.7976931348623157E+308D;
            this.txtIssueQty.RangeMin = 0D;
            this.txtIssueQty.Size = new System.Drawing.Size(446, 26);
            this.txtIssueQty.TabIndex = 12;
            this.txtIssueQty.Text = "0";
            this.txtIssueQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtOnHandQty
            // 
            this.txtOnHandQty.AllowNegative = true;
            this.txtOnHandQty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOnHandQty.AppearanceName = "";
            this.txtOnHandQty.AppearanceReadOnlyName = "";
            this.tableLayoutPanel2.SetColumnSpan(this.txtOnHandQty, 2);
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
            this.txtOnHandQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtOnHandQty.GroupSeparator = ',';
            this.txtOnHandQty.Int = 0;
            this.txtOnHandQty.Location = new System.Drawing.Point(181, 337);
            this.txtOnHandQty.Long = ((long)(0));
            this.txtOnHandQty.MaxDecimalPlaces = 4;
            this.txtOnHandQty.MaxWholeDigits = 9;
            this.txtOnHandQty.Name = "txtOnHandQty";
            this.txtOnHandQty.NegativeSign = '-';
            this.txtOnHandQty.PathString = "ONHAND_QTY.Value";
            this.txtOnHandQty.PathValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOnHandQty.Prefix = "";
            this.txtOnHandQty.RangeMax = 1.7976931348623157E+308D;
            this.txtOnHandQty.RangeMin = -1.7976931348623157E+308D;
            this.txtOnHandQty.Size = new System.Drawing.Size(446, 26);
            this.txtOnHandQty.TabIndex = 11;
            this.txtOnHandQty.Text = "0";
            this.txtOnHandQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboToLoc
            // 
            this.cboToLoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboToLoc.AppearanceName = "";
            this.cboToLoc.AppearanceReadOnlyName = "";
            this.tableLayoutPanel2.SetColumnSpan(this.cboToLoc, 2);
            this.cboToLoc.ControlID = null;
            this.cboToLoc.DropDownHeight = 180;
            this.cboToLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboToLoc.FormattingEnabled = true;
            this.cboToLoc.IntegralHeight = false;
            this.cboToLoc.Location = new System.Drawing.Point(181, 268);
            this.cboToLoc.Name = "cboToLoc";
            this.cboToLoc.PathString = "TO_LOC_CD.Value";
            this.cboToLoc.PathValue = null;
            this.cboToLoc.Size = new System.Drawing.Size(446, 28);
            this.cboToLoc.TabIndex = 9;
            // 
            // txtItemDesc
            // 
            this.txtItemDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemDesc.AppearanceName = "";
            this.txtItemDesc.AppearanceReadOnlyName = "";
            this.tableLayoutPanel2.SetColumnSpan(this.txtItemDesc, 2);
            this.txtItemDesc.ControlID = "";
            this.txtItemDesc.DisableRestrictChar = false;
            this.txtItemDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtItemDesc.HelpButton = null;
            this.txtItemDesc.Location = new System.Drawing.Point(181, 202);
            this.txtItemDesc.MaxLength = 100;
            this.txtItemDesc.Name = "txtItemDesc";
            this.txtItemDesc.PathString = "ITEM_DESC.Value";
            this.txtItemDesc.PathValue = "";
            this.txtItemDesc.Size = new System.Drawing.Size(446, 26);
            this.txtItemDesc.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.AppearanceName = "";
            this.tableLayoutPanel2.SetColumnSpan(this.panel2, 4);
            this.panel2.Controls.Add(this.tableLayoutPanel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(624, 29);
            this.panel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel3.BackgroundImage")));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.lblSubHeader, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(624, 29);
            this.tableLayoutPanel3.TabIndex = 9;
            // 
            // lblSubHeader
            // 
            this.lblSubHeader.AppearanceName = "Header";
            this.lblSubHeader.AutoSize = true;
            this.lblSubHeader.ControlID = "";
            this.lblSubHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblSubHeader.ForeColor = System.Drawing.Color.Navy;
            this.lblSubHeader.Location = new System.Drawing.Point(0, 0);
            this.lblSubHeader.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblSubHeader.Name = "lblSubHeader";
            this.lblSubHeader.PathString = null;
            this.lblSubHeader.PathValue = "Issue Information";
            this.lblSubHeader.Size = new System.Drawing.Size(151, 24);
            this.lblSubHeader.TabIndex = 0;
            this.lblSubHeader.Text = "Issue Information";
            // 
            // lblItemCode
            // 
            this.lblItemCode.AppearanceName = "";
            this.lblItemCode.ControlID = "";
            this.lblItemCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblItemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblItemCode.Location = new System.Drawing.Point(33, 165);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.PathString = null;
            this.lblItemCode.PathValue = "Part No. :";
            this.lblItemCode.Size = new System.Drawing.Size(142, 34);
            this.lblItemCode.TabIndex = 50;
            this.lblItemCode.Text = "Part No. :";
            this.lblItemCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblItemDesc
            // 
            this.lblItemDesc.AppearanceName = "";
            this.lblItemDesc.ControlID = "";
            this.lblItemDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblItemDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblItemDesc.Location = new System.Drawing.Point(33, 199);
            this.lblItemDesc.Name = "lblItemDesc";
            this.lblItemDesc.PathString = null;
            this.lblItemDesc.PathValue = "Part Name :";
            this.lblItemDesc.Size = new System.Drawing.Size(142, 32);
            this.lblItemDesc.TabIndex = 51;
            this.lblItemDesc.Text = "Part Name :";
            this.lblItemDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFromLoc
            // 
            this.lblFromLoc.AppearanceName = "";
            this.lblFromLoc.ControlID = "";
            this.lblFromLoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFromLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblFromLoc.Location = new System.Drawing.Point(33, 231);
            this.lblFromLoc.Name = "lblFromLoc";
            this.lblFromLoc.PathString = null;
            this.lblFromLoc.PathValue = "From Loc :";
            this.lblFromLoc.Size = new System.Drawing.Size(142, 30);
            this.lblFromLoc.TabIndex = 52;
            this.lblFromLoc.Text = "From Loc :";
            this.lblFromLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblToLoc
            // 
            this.lblToLoc.AppearanceName = "";
            this.lblToLoc.ControlID = "";
            this.lblToLoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblToLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblToLoc.Location = new System.Drawing.Point(33, 265);
            this.lblToLoc.Name = "lblToLoc";
            this.lblToLoc.PathString = null;
            this.lblToLoc.PathValue = "To Loc :";
            this.lblToLoc.Size = new System.Drawing.Size(142, 30);
            this.lblToLoc.TabIndex = 53;
            this.lblToLoc.Text = "To Loc :";
            this.lblToLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLotNo
            // 
            this.lblLotNo.AppearanceName = "";
            this.lblLotNo.ControlID = "";
            this.lblLotNo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLotNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblLotNo.Location = new System.Drawing.Point(33, 299);
            this.lblLotNo.Name = "lblLotNo";
            this.lblLotNo.PathString = null;
            this.lblLotNo.PathValue = "Lot No. :";
            this.lblLotNo.Size = new System.Drawing.Size(142, 30);
            this.lblLotNo.TabIndex = 54;
            this.lblLotNo.Text = "Lot No. :";
            this.lblLotNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOnHandQty
            // 
            this.lblOnHandQty.AppearanceName = "";
            this.lblOnHandQty.ControlID = "";
            this.lblOnHandQty.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblOnHandQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblOnHandQty.Location = new System.Drawing.Point(33, 334);
            this.lblOnHandQty.Name = "lblOnHandQty";
            this.lblOnHandQty.PathString = null;
            this.lblOnHandQty.PathValue = "On-Hand Qty :";
            this.lblOnHandQty.Size = new System.Drawing.Size(142, 30);
            this.lblOnHandQty.TabIndex = 55;
            this.lblOnHandQty.Text = "On-Hand Qty :";
            this.lblOnHandQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIssueQty
            // 
            this.lblIssueQty.AppearanceName = "";
            this.lblIssueQty.ControlID = "";
            this.lblIssueQty.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblIssueQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblIssueQty.Location = new System.Drawing.Point(33, 366);
            this.lblIssueQty.Name = "lblIssueQty";
            this.lblIssueQty.PathString = null;
            this.lblIssueQty.PathValue = "Issue Qty :";
            this.lblIssueQty.Size = new System.Drawing.Size(142, 30);
            this.lblIssueQty.TabIndex = 56;
            this.lblIssueQty.Text = "Issue Qty :";
            this.lblIssueQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRemark
            // 
            this.lblRemark.AppearanceName = "";
            this.lblRemark.ControlID = "";
            this.lblRemark.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblRemark.Location = new System.Drawing.Point(33, 432);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.PathString = null;
            this.lblRemark.PathValue = "Remark :";
            this.lblRemark.Size = new System.Drawing.Size(142, 30);
            this.lblRemark.TabIndex = 57;
            this.lblRemark.Text = "Remark :";
            this.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboFromLoc
            // 
            this.cboFromLoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFromLoc.AppearanceName = "";
            this.cboFromLoc.AppearanceReadOnlyName = "";
            this.tableLayoutPanel2.SetColumnSpan(this.cboFromLoc, 2);
            this.cboFromLoc.ControlID = null;
            this.cboFromLoc.DropDownHeight = 180;
            this.cboFromLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboFromLoc.FormattingEnabled = true;
            this.cboFromLoc.IntegralHeight = false;
            this.cboFromLoc.Location = new System.Drawing.Point(181, 234);
            this.cboFromLoc.Name = "cboFromLoc";
            this.cboFromLoc.PathString = "FROM_LOC_CD.Value";
            this.cboFromLoc.PathValue = null;
            this.cboFromLoc.Size = new System.Drawing.Size(446, 28);
            this.cboFromLoc.TabIndex = 8;
            this.cboFromLoc.SelectedValueChanged += new System.EventHandler(this.cboFromLoc_SelectedValueChanged);
            // 
            // evoLabel1
            // 
            this.evoLabel1.AppearanceName = "RequireText";
            this.evoLabel1.ControlID = "";
            this.evoLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.evoLabel1.Location = new System.Drawing.Point(3, 165);
            this.evoLabel1.Name = "evoLabel1";
            this.evoLabel1.PathString = null;
            this.evoLabel1.PathValue = "*";
            this.evoLabel1.Size = new System.Drawing.Size(24, 34);
            this.evoLabel1.TabIndex = 69;
            this.evoLabel1.Text = "*";
            this.evoLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // evoLabel2
            // 
            this.evoLabel2.AppearanceName = "RequireText";
            this.evoLabel2.ControlID = "";
            this.evoLabel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.evoLabel2.Location = new System.Drawing.Point(3, 231);
            this.evoLabel2.Name = "evoLabel2";
            this.evoLabel2.PathString = null;
            this.evoLabel2.PathValue = "*";
            this.evoLabel2.Size = new System.Drawing.Size(24, 33);
            this.evoLabel2.TabIndex = 70;
            this.evoLabel2.Text = "*";
            this.evoLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // evoLabel3
            // 
            this.evoLabel3.AppearanceName = "RequireText";
            this.evoLabel3.ControlID = "";
            this.evoLabel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.evoLabel3.Location = new System.Drawing.Point(3, 265);
            this.evoLabel3.Name = "evoLabel3";
            this.evoLabel3.PathString = null;
            this.evoLabel3.PathValue = "*";
            this.evoLabel3.Size = new System.Drawing.Size(24, 32);
            this.evoLabel3.TabIndex = 71;
            this.evoLabel3.Text = "*";
            this.evoLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // evoLabel4
            // 
            this.evoLabel4.AppearanceName = "RequireText";
            this.evoLabel4.ControlID = "";
            this.evoLabel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.evoLabel4.Location = new System.Drawing.Point(3, 366);
            this.evoLabel4.Name = "evoLabel4";
            this.evoLabel4.PathString = null;
            this.evoLabel4.PathValue = "*";
            this.evoLabel4.Size = new System.Drawing.Size(24, 30);
            this.evoLabel4.TabIndex = 72;
            this.evoLabel4.Text = "*";
            this.evoLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblForCustomer
            // 
            this.lblForCustomer.AppearanceName = "";
            this.lblForCustomer.ControlID = "";
            this.lblForCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblForCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblForCustomer.Location = new System.Drawing.Point(33, 99);
            this.lblForCustomer.Name = "lblForCustomer";
            this.lblForCustomer.PathString = null;
            this.lblForCustomer.PathValue = "For Customer :";
            this.lblForCustomer.Size = new System.Drawing.Size(142, 34);
            this.lblForCustomer.TabIndex = 50;
            this.lblForCustomer.Text = "For Customer :";
            this.lblForCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblForMachine
            // 
            this.lblForMachine.AppearanceName = "";
            this.lblForMachine.ControlID = "";
            this.lblForMachine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblForMachine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblForMachine.Location = new System.Drawing.Point(33, 133);
            this.lblForMachine.Name = "lblForMachine";
            this.lblForMachine.PathString = null;
            this.lblForMachine.PathValue = "For Machine :";
            this.lblForMachine.Size = new System.Drawing.Size(142, 32);
            this.lblForMachine.TabIndex = 50;
            this.lblForMachine.Text = "For Machine :";
            this.lblForMachine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtForMachine
            // 
            this.txtForMachine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtForMachine.AppearanceName = "";
            this.txtForMachine.AppearanceReadOnlyName = "";
            this.tableLayoutPanel2.SetColumnSpan(this.txtForMachine, 2);
            this.txtForMachine.ControlID = "";
            this.txtForMachine.DisableRestrictChar = false;
            this.txtForMachine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtForMachine.HelpButton = null;
            this.txtForMachine.Location = new System.Drawing.Point(181, 136);
            this.txtForMachine.MaxLength = 20;
            this.txtForMachine.Name = "txtForMachine";
            this.txtForMachine.PathString = "FOR_MACHINE.Value";
            this.txtForMachine.PathValue = "";
            this.txtForMachine.Size = new System.Drawing.Size(446, 26);
            this.txtForMachine.TabIndex = 5;
            // 
            // cboForCustomer
            // 
            this.cboForCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboForCustomer.AppearanceName = "";
            this.cboForCustomer.AppearanceReadOnlyName = "";
            this.tableLayoutPanel2.SetColumnSpan(this.cboForCustomer, 2);
            this.cboForCustomer.ControlID = "";
            this.cboForCustomer.DropDownHeight = 180;
            this.cboForCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboForCustomer.FormattingEnabled = true;
            this.cboForCustomer.IntegralHeight = false;
            this.cboForCustomer.Location = new System.Drawing.Point(181, 102);
            this.cboForCustomer.Name = "cboForCustomer";
            this.cboForCustomer.PathString = "FOR_CUSTOMER.Value";
            this.cboForCustomer.PathValue = null;
            this.cboForCustomer.Size = new System.Drawing.Size(446, 28);
            this.cboForCustomer.TabIndex = 4;
            // 
            // txtRefDocNo
            // 
            this.txtRefDocNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRefDocNo.AppearanceName = "";
            this.txtRefDocNo.AppearanceReadOnlyName = "";
            this.tableLayoutPanel2.SetColumnSpan(this.txtRefDocNo, 2);
            this.txtRefDocNo.ControlID = "";
            this.txtRefDocNo.DisableRestrictChar = false;
            this.txtRefDocNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtRefDocNo.HelpButton = null;
            this.txtRefDocNo.Location = new System.Drawing.Point(181, 38);
            this.txtRefDocNo.MaxLength = 20;
            this.txtRefDocNo.Name = "txtRefDocNo";
            this.txtRefDocNo.PathString = "REF_SLIP_NO.Value";
            this.txtRefDocNo.PathValue = "";
            this.txtRefDocNo.Size = new System.Drawing.Size(446, 26);
            this.txtRefDocNo.TabIndex = 2;
            // 
            // txtJobOrderNo
            // 
            this.txtJobOrderNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJobOrderNo.AppearanceName = "";
            this.txtJobOrderNo.AppearanceReadOnlyName = "";
            this.tableLayoutPanel2.SetColumnSpan(this.txtJobOrderNo, 2);
            this.txtJobOrderNo.ControlID = "";
            this.txtJobOrderNo.DisableRestrictChar = false;
            this.txtJobOrderNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtJobOrderNo.HelpButton = null;
            this.txtJobOrderNo.Location = new System.Drawing.Point(181, 70);
            this.txtJobOrderNo.MaxLength = 20;
            this.txtJobOrderNo.Name = "txtJobOrderNo";
            this.txtJobOrderNo.PathString = "REF_SLIP_NO2.Value";
            this.txtJobOrderNo.PathValue = "";
            this.txtJobOrderNo.Size = new System.Drawing.Size(446, 26);
            this.txtJobOrderNo.TabIndex = 3;
            // 
            // lblRefDocNo
            // 
            this.lblRefDocNo.AppearanceName = "";
            this.lblRefDocNo.ControlID = "";
            this.lblRefDocNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblRefDocNo.Location = new System.Drawing.Point(33, 35);
            this.lblRefDocNo.Name = "lblRefDocNo";
            this.lblRefDocNo.PathString = null;
            this.lblRefDocNo.PathValue = "Ref Doc No. :";
            this.lblRefDocNo.Size = new System.Drawing.Size(142, 32);
            this.lblRefDocNo.TabIndex = 50;
            this.lblRefDocNo.Text = "Ref Doc No. :";
            this.lblRefDocNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblJobOrderNo
            // 
            this.lblJobOrderNo.AppearanceName = "";
            this.lblJobOrderNo.ControlID = "";
            this.lblJobOrderNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblJobOrderNo.Location = new System.Drawing.Point(33, 67);
            this.lblJobOrderNo.Name = "lblJobOrderNo";
            this.lblJobOrderNo.PathString = null;
            this.lblJobOrderNo.PathValue = "Job Order No. :";
            this.lblJobOrderNo.Size = new System.Drawing.Size(142, 32);
            this.lblJobOrderNo.TabIndex = 50;
            this.lblJobOrderNo.Text = "Job Order No. :";
            this.lblJobOrderNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtItemCode
            // 
            this.txtItemCode.AllowNegative = true;
            this.txtItemCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemCode.AppearanceName = "";
            this.txtItemCode.AppearanceReadOnlyName = "";
            this.txtItemCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtItemCode.CheckEmpty = false;
            this.txtItemCode.CheckExist = false;
            this.txtItemCode.CheckNotExist = false;
            this.txtItemCode.ControlID = "";
            this.txtItemCode.CustomerCode = null;
            this.txtItemCode.CustomerNameTextBox = null;
            this.txtItemCode.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtItemCode.DecimalPoint = '.';
            this.txtItemCode.DescriptionTextBox = this.txtItemDesc;
            this.txtItemCode.DigitsInGroup = 0;
            this.txtItemCode.Double = 0D;
            this.txtItemCode.FixDecimalPosition = true;
            this.txtItemCode.Flags = 0;
            this.txtItemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtItemCode.GroupSeparator = ',';
            this.txtItemCode.HelpButton = this.btnItemCode;
            this.txtItemCode.Int = 0;
            this.txtItemCode.ItemType = null;
            this.txtItemCode.Location = new System.Drawing.Point(181, 168);
            this.txtItemCode.Long = ((long)(0));
            this.txtItemCode.MaxDecimalPlaces = 0;
            this.txtItemCode.MaxLength = 50;
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
            this.txtItemCode.Size = new System.Drawing.Size(411, 26);
            this.txtItemCode.SqlOperator = Rubik.eSqlOperator.In;
            this.txtItemCode.TabIndex = 6;
            this.txtItemCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.txtLotNo.Location = new System.Drawing.Point(181, 302);
            this.txtLotNo.MaxLength = 10;
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.PathString = "LOT_NO.Value";
            this.txtLotNo.PathValue = "";
            this.txtLotNo.Size = new System.Drawing.Size(409, 27);
            this.txtLotNo.TabIndex = 10;
            this.txtLotNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLotNo_KeyPress);
            // 
            // btnLotNo
            // 
            this.btnLotNo.AppearanceName = "";
            this.btnLotNo.AutoSize = true;
            this.btnLotNo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLotNo.BackgroundImage")));
            this.btnLotNo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLotNo.ControlID = null;
            this.btnLotNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLotNo.Location = new System.Drawing.Point(598, 302);
            this.btnLotNo.Name = "btnLotNo";
            this.btnLotNo.Size = new System.Drawing.Size(29, 29);
            this.btnLotNo.TabIndex = 232325;
            this.btnLotNo.TabStop = false;
            this.btnLotNo.UseVisualStyleBackColor = true;
            this.btnLotNo.Click += new System.EventHandler(this.btnLotNo_Click);
            // 
            // TRN140
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(638, 676);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TRN140";
            this.Text = "Issue Entry By Item";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.INV040_Load);
            this.pnlContainer.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EVOFramework.Windows.Forms.EVOLabel lblHeader;
        private EVOFramework.Windows.Forms.EVOLabel lblIssueDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private EVOFramework.Windows.Forms.EVOLabel label9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tlpHeader2;
        private EVOFramework.Windows.Forms.EVOLabel label3;
        private EVOFramework.Windows.Forms.EVOPanel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private EVOFramework.Windows.Forms.EVOPanel panel2;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtIssueDate;
        private EVOFramework.Windows.Forms.EVOLabel lblTransactionID;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private EVOFramework.Windows.Forms.EVOLabel lblSubHeader;
        private EVOFramework.Windows.Forms.EVOLabel lblItemCode;
        private EVOFramework.Windows.Forms.EVOLabel lblItemDesc;
        private EVOFramework.Windows.Forms.EVOLabel lblFromLoc;
        private EVOFramework.Windows.Forms.EVOLabel lblToLoc;
        private EVOFramework.Windows.Forms.EVOTextBox txtRemark;
        private EVOFramework.Windows.Forms.EVONumericTextBox txtIssueQty;
        private EVOFramework.Windows.Forms.EVONumericTextBox txtOnHandQty;
        private EVOFramework.Windows.Forms.EVOComboBox cboToLoc;
        private EVOFramework.Windows.Forms.EVOTextBox txtItemDesc;
        private EVOFramework.Windows.Forms.EVOLabel lblLotNo;
        private EVOFramework.Windows.Forms.EVOLabel lblOnHandQty;
        private EVOFramework.Windows.Forms.EVOLabel lblIssueQty;
        private EVOFramework.Windows.Forms.EVOLabel lblRemark;
        private EVOFramework.Windows.Forms.EVOLabel txtTransactionID;
        private EVOFramework.Windows.Forms.EVOComboBox cboFromLoc;
        private EVOFramework.Windows.Forms.EVOButton btnItemCode;
        private EVOFramework.Data.UIDataModelController dmcIssueByItem;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel1;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel2;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel3;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel4;
        private EVOFramework.Windows.Forms.EVOLabel lblInventoryUMCls;
        private EVOFramework.Windows.Forms.EVOComboBox cboInventoryUM;
        private EVOFramework.Windows.Forms.EVOLabel lblJobOrderNo;
        private EVOFramework.Windows.Forms.EVOLabel lblRefDocNo;
        private EVOFramework.Windows.Forms.EVOLabel lblForCustomer;
        private EVOFramework.Windows.Forms.EVOLabel lblForMachine;
        private EVOFramework.Windows.Forms.EVOTextBox txtForMachine;
        private EVOFramework.Windows.Forms.EVOComboBox cboForCustomer;
        private EVOFramework.Windows.Forms.EVOTextBox txtRefDocNo;
        private EVOFramework.Windows.Forms.EVOTextBox txtJobOrderNo;
        private Rubik.Forms.UserControl.ItemTextBox txtItemCode;
        private EVOFramework.Windows.Forms.EVOTextBox txtLotNo;
        private EVOFramework.Windows.Forms.EVOButton btnLotNo;
    }
}
