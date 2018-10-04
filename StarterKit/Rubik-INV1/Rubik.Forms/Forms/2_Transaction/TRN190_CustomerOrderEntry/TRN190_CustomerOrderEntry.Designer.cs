namespace Rubik.Transaction
{
    partial class TRN190_CustomerOrderEntry
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
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TRN190_CustomerOrderEntry));
            this.stcHead = new EVOFramework.Windows.Forms.EVOLabel();
            this.tlpHeader2 = new System.Windows.Forms.TableLayoutPanel();
            this.stcReceiveInfo = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcPONo = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcRemark = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcReceiveListInfo = new EVOFramework.Windows.Forms.EVOLabel();
            this.fpCustomerOrderList = new FarPoint.Win.Spread.FpSpread();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.miDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.shtCustomerOrderList = new FarPoint.Win.Spread.SheetView();
            this.txtPONo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.txtRemark = new EVOFramework.Windows.Forms.EVOTextBox();
            this.stcReceiveNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.stdReceiveDate = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblOrderNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.dtReceiveDate = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.stcReqReceiveDate = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblCustomerCode = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboCustomerCode = new EVOFramework.Windows.Forms.EVOComboBox();
            this.stcReqSupplier = new EVOFramework.Windows.Forms.EVOLabel();
            this.dmcCustomerOrderList = new EVOFramework.Data.UIDataModelController(this.components);
            this.lblPODate = new EVOFramework.Windows.Forms.EVOLabel();
            this.dtPODate = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.evoLabel1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboType = new EVOFramework.Windows.Forms.EVOComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTotalAmount = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblTotalQty = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel2 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel3 = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboCurrency = new EVOFramework.Windows.Forms.EVOComboBox();
            this.evoLabel4 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtExchangeRate = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.evoLabel5 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel6 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtQty = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.txtAmount = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.txtAmountTHB = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.rqCurrency = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel7 = new EVOFramework.Windows.Forms.EVOLabel();
            this.pnlContainer.SuspendLayout();
            this.tlpHeader2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpCustomerOrderList)).BeginInit();
            this.ctxMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shtCustomerOrderList)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.evoLabel7);
            this.pnlContainer.Controls.Add(this.rqCurrency);
            this.pnlContainer.Controls.Add(this.txtAmountTHB);
            this.pnlContainer.Controls.Add(this.txtAmount);
            this.pnlContainer.Controls.Add(this.txtQty);
            this.pnlContainer.Controls.Add(this.txtExchangeRate);
            this.pnlContainer.Controls.Add(this.cboCurrency);
            this.pnlContainer.Controls.Add(this.evoLabel2);
            this.pnlContainer.Controls.Add(this.evoLabel6);
            this.pnlContainer.Controls.Add(this.lblTotalAmount);
            this.pnlContainer.Controls.Add(this.lblTotalQty);
            this.pnlContainer.Controls.Add(this.stcReqReceiveDate);
            this.pnlContainer.Controls.Add(this.dtReceiveDate);
            this.pnlContainer.Controls.Add(this.stdReceiveDate);
            this.pnlContainer.Controls.Add(this.stcReceiveNo);
            this.pnlContainer.Controls.Add(this.lblOrderNo);
            this.pnlContainer.Controls.Add(this.cboType);
            this.pnlContainer.Controls.Add(this.evoLabel1);
            this.pnlContainer.Controls.Add(this.dtPODate);
            this.pnlContainer.Controls.Add(this.fpCustomerOrderList);
            this.pnlContainer.Controls.Add(this.tableLayoutPanel1);
            this.pnlContainer.Controls.Add(this.tlpHeader2);
            this.pnlContainer.Controls.Add(this.stcRemark);
            this.pnlContainer.Controls.Add(this.lblPODate);
            this.pnlContainer.Controls.Add(this.evoLabel5);
            this.pnlContainer.Controls.Add(this.evoLabel4);
            this.pnlContainer.Controls.Add(this.evoLabel3);
            this.pnlContainer.Controls.Add(this.stcPONo);
            this.pnlContainer.Controls.Add(this.stcHead);
            this.pnlContainer.Controls.Add(this.txtRemark);
            this.pnlContainer.Controls.Add(this.txtPONo);
            this.pnlContainer.Controls.Add(this.stcReqSupplier);
            this.pnlContainer.Controls.Add(this.cboCustomerCode);
            this.pnlContainer.Controls.Add(this.lblCustomerCode);
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlContainer.Size = new System.Drawing.Size(907, 728);
            // 
            // stcHead
            // 
            this.stcHead.AppearanceName = "Title";
            this.stcHead.AutoSize = true;
            this.stcHead.ControlID = "";
            this.stcHead.Font = new System.Drawing.Font("Tahoma", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.stcHead.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.stcHead.Location = new System.Drawing.Point(9, 10);
            this.stcHead.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.stcHead.Name = "stcHead";
            this.stcHead.PathString = null;
            this.stcHead.PathValue = "Customer Order Entry";
            this.stcHead.Size = new System.Drawing.Size(366, 39);
            this.stcHead.TabIndex = 36;
            this.stcHead.Text = "Customer Order Entry";
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
            this.tlpHeader2.Location = new System.Drawing.Point(9, 67);
            this.tlpHeader2.Margin = new System.Windows.Forms.Padding(0);
            this.tlpHeader2.Name = "tlpHeader2";
            this.tlpHeader2.RowCount = 1;
            this.tlpHeader2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHeader2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlpHeader2.Size = new System.Drawing.Size(886, 24);
            this.tlpHeader2.TabIndex = 9;
            // 
            // stcReceiveInfo
            // 
            this.stcReceiveInfo.AppearanceName = "Header";
            this.stcReceiveInfo.AutoSize = true;
            this.stcReceiveInfo.ControlID = "";
            this.stcReceiveInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.stcReceiveInfo.ForeColor = System.Drawing.Color.Navy;
            this.stcReceiveInfo.Location = new System.Drawing.Point(0, 0);
            this.stcReceiveInfo.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.stcReceiveInfo.Name = "stcReceiveInfo";
            this.stcReceiveInfo.PathString = null;
            this.stcReceiveInfo.PathValue = "Customer Order Information";
            this.stcReceiveInfo.Size = new System.Drawing.Size(242, 24);
            this.stcReceiveInfo.TabIndex = 0;
            this.stcReceiveInfo.Text = "Customer Order Information";
            // 
            // stcPONo
            // 
            this.stcPONo.AppearanceName = "";
            this.stcPONo.AutoSize = true;
            this.stcPONo.ControlID = "";
            this.stcPONo.Location = new System.Drawing.Point(36, 173);
            this.stcPONo.Name = "stcPONo";
            this.stcPONo.PathString = null;
            this.stcPONo.PathValue = "PO No. ";
            this.stcPONo.Size = new System.Drawing.Size(65, 19);
            this.stcPONo.TabIndex = 6;
            this.stcPONo.Text = "PO No. ";
            this.stcPONo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcRemark
            // 
            this.stcRemark.AppearanceName = "";
            this.stcRemark.AutoSize = true;
            this.stcRemark.ControlID = "";
            this.stcRemark.Location = new System.Drawing.Point(36, 206);
            this.stcRemark.Name = "stcRemark";
            this.stcRemark.PathString = null;
            this.stcRemark.PathValue = "Remark ";
            this.stcRemark.Size = new System.Drawing.Size(68, 19);
            this.stcRemark.TabIndex = 8;
            this.stcRemark.Text = "Remark ";
            this.stcRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcReceiveListInfo
            // 
            this.stcReceiveListInfo.AppearanceName = "Header";
            this.stcReceiveListInfo.AutoSize = true;
            this.stcReceiveListInfo.ControlID = "";
            this.stcReceiveListInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.stcReceiveListInfo.ForeColor = System.Drawing.Color.Navy;
            this.stcReceiveListInfo.Location = new System.Drawing.Point(0, 0);
            this.stcReceiveListInfo.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.stcReceiveListInfo.Name = "stcReceiveListInfo";
            this.stcReceiveListInfo.PathString = null;
            this.stcReceiveListInfo.PathValue = "Customer Order List";
            this.stcReceiveListInfo.Size = new System.Drawing.Size(177, 24);
            this.stcReceiveListInfo.TabIndex = 0;
            this.stcReceiveListInfo.Text = "Customer Order List";
            // 
            // fpCustomerOrderList
            // 
            this.fpCustomerOrderList.About = "2.5.2015.2005";
            this.fpCustomerOrderList.AccessibleDescription = "fpCustomerOrderList, Sheet1";
            this.fpCustomerOrderList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fpCustomerOrderList.BackColor = System.Drawing.Color.AliceBlue;
            this.fpCustomerOrderList.ContextMenuStrip = this.ctxMenu;
            this.fpCustomerOrderList.EditModeReplace = true;
            this.fpCustomerOrderList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpCustomerOrderList.Location = new System.Drawing.Point(8, 259);
            this.fpCustomerOrderList.Name = "fpCustomerOrderList";
            this.fpCustomerOrderList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpCustomerOrderList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpCustomerOrderList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtCustomerOrderList});
            this.fpCustomerOrderList.Size = new System.Drawing.Size(886, 424);
            this.fpCustomerOrderList.TabIndex = 0;
            this.fpCustomerOrderList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpCustomerOrderList.EditModeOn += new System.EventHandler(this.fpView_EditModeOn);
            this.fpCustomerOrderList.EditModeOff += new System.EventHandler(this.fpView_EditModeOff);
            this.fpCustomerOrderList.LeaveCell += new FarPoint.Win.Spread.LeaveCellEventHandler(this.fpView_LeaveCell);
            this.fpCustomerOrderList.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.fpView_ButtonClicked);
            this.fpCustomerOrderList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpCustomerOrderList_KeyDown);
            this.fpCustomerOrderList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fpView_KeyUp);
            this.fpCustomerOrderList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fpView_MouseDown);
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAdd,
            this.miDelete});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(106, 48);
            // 
            // miAdd
            // 
            this.miAdd.Name = "miAdd";
            this.miAdd.Size = new System.Drawing.Size(105, 22);
            this.miAdd.Text = "Add";
            this.miAdd.Click += new System.EventHandler(this.miAdd_Click);
            // 
            // miDelete
            // 
            this.miDelete.Name = "miDelete";
            this.miDelete.Size = new System.Drawing.Size(105, 22);
            this.miDelete.Text = "Delete";
            this.miDelete.Click += new System.EventHandler(this.miDelete_Click);
            // 
            // shtCustomerOrderList
            // 
            this.shtCustomerOrderList.Reset();
            this.shtCustomerOrderList.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtCustomerOrderList.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtCustomerOrderList.ColumnCount = 12;
            this.shtCustomerOrderList.RowCount = 0;
            this.shtCustomerOrderList.AutoCalculation = false;
            this.shtCustomerOrderList.AutoGenerateColumns = false;
            this.shtCustomerOrderList.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.shtCustomerOrderList.ColumnHeader.Cells.Get(0, 0).Value = "Order Detail No";
            this.shtCustomerOrderList.ColumnHeader.Cells.Get(0, 1).Value = "M/N";
            this.shtCustomerOrderList.ColumnHeader.Cells.Get(0, 3).Value = "Part No.";
            this.shtCustomerOrderList.ColumnHeader.Cells.Get(0, 4).Value = "Del. Date";
            this.shtCustomerOrderList.ColumnHeader.Cells.Get(0, 5).Value = "Old Del. Date";
            this.shtCustomerOrderList.ColumnHeader.Cells.Get(0, 6).Value = "Qty";
            this.shtCustomerOrderList.ColumnHeader.Cells.Get(0, 7).Value = "Old QTY";
            this.shtCustomerOrderList.ColumnHeader.Cells.Get(0, 8).Value = "Price";
            this.shtCustomerOrderList.ColumnHeader.Cells.Get(0, 9).Value = "Amount";
            this.shtCustomerOrderList.ColumnHeader.Cells.Get(0, 10).Value = "Price (THB)";
            this.shtCustomerOrderList.ColumnHeader.Cells.Get(0, 11).Value = "Amount (THB)";
            this.shtCustomerOrderList.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtCustomerOrderList.Columns.Get(0).Label = "Order Detail No";
            this.shtCustomerOrderList.Columns.Get(0).Visible = false;
            this.shtCustomerOrderList.Columns.Get(0).Width = 140F;
            textCellType1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.shtCustomerOrderList.Columns.Get(1).CellType = textCellType1;
            this.shtCustomerOrderList.Columns.Get(1).Label = "M/N";
            this.shtCustomerOrderList.Columns.Get(1).Locked = true;
            this.shtCustomerOrderList.Columns.Get(1).Tag = "M/N";
            this.shtCustomerOrderList.Columns.Get(1).Width = 80F;
            buttonCellType1.ShadowSize = 0;
            buttonCellType1.Text = "...";
            this.shtCustomerOrderList.Columns.Get(2).CellType = buttonCellType1;
            this.shtCustomerOrderList.Columns.Get(2).Resizable = false;
            this.shtCustomerOrderList.Columns.Get(2).Tag = "ITEM_CD_BTN";
            this.shtCustomerOrderList.Columns.Get(2).Width = 25F;
            this.shtCustomerOrderList.Columns.Get(3).Label = "Part No.";
            this.shtCustomerOrderList.Columns.Get(3).Tag = "Part No";
            this.shtCustomerOrderList.Columns.Get(3).Width = 100F;
            dateTimeCellType1.Calendar = ((System.Globalization.Calendar)(resources.GetObject("dateTimeCellType1.Calendar")));
            dateTimeCellType1.DateDefault = new System.DateTime(2012, 2, 9, 10, 35, 44, 0);
            dateTimeCellType1.TimeDefault = new System.DateTime(2012, 2, 9, 10, 35, 44, 0);
            this.shtCustomerOrderList.Columns.Get(4).CellType = dateTimeCellType1;
            this.shtCustomerOrderList.Columns.Get(4).Label = "Del. Date";
            this.shtCustomerOrderList.Columns.Get(4).Tag = "Del. Date";
            this.shtCustomerOrderList.Columns.Get(4).Width = 91F;
            this.shtCustomerOrderList.Columns.Get(5).Label = "Old Del. Date";
            this.shtCustomerOrderList.Columns.Get(5).Visible = false;
            this.shtCustomerOrderList.Columns.Get(5).Width = 130F;
            this.shtCustomerOrderList.Columns.Get(6).Label = "Qty";
            this.shtCustomerOrderList.Columns.Get(6).Locked = false;
            this.shtCustomerOrderList.Columns.Get(6).Tag = "Qty";
            this.shtCustomerOrderList.Columns.Get(6).Width = 91F;
            this.shtCustomerOrderList.Columns.Get(7).Label = "Old QTY";
            this.shtCustomerOrderList.Columns.Get(7).Visible = false;
            this.shtCustomerOrderList.Columns.Get(7).Width = 100F;
            numberCellType1.Separator = ",";
            numberCellType1.ShowSeparator = true;
            this.shtCustomerOrderList.Columns.Get(8).CellType = numberCellType1;
            this.shtCustomerOrderList.Columns.Get(8).Label = "Price";
            this.shtCustomerOrderList.Columns.Get(8).Tag = "Price";
            this.shtCustomerOrderList.Columns.Get(8).Width = 91F;
            numberCellType2.Separator = ",";
            numberCellType2.ShowSeparator = true;
            this.shtCustomerOrderList.Columns.Get(9).CellType = numberCellType2;
            this.shtCustomerOrderList.Columns.Get(9).Label = "Amount";
            this.shtCustomerOrderList.Columns.Get(9).Tag = "Amount";
            this.shtCustomerOrderList.Columns.Get(9).Width = 120F;
            this.shtCustomerOrderList.Columns.Get(10).CellType = numberCellType3;
            this.shtCustomerOrderList.Columns.Get(10).Label = "Price (THB)";
            this.shtCustomerOrderList.Columns.Get(10).Tag = "Price (THB)";
            this.shtCustomerOrderList.Columns.Get(10).Width = 120F;
            this.shtCustomerOrderList.Columns.Get(11).CellType = numberCellType4;
            this.shtCustomerOrderList.Columns.Get(11).Label = "Amount (THB)";
            this.shtCustomerOrderList.Columns.Get(11).Tag = "Amount (THB)";
            this.shtCustomerOrderList.Columns.Get(11).Width = 120F;
            this.shtCustomerOrderList.DataAutoCellTypes = false;
            this.shtCustomerOrderList.DataAutoHeadings = false;
            this.shtCustomerOrderList.DataAutoSizeColumns = false;
            this.shtCustomerOrderList.DefaultStyle.ForeColor = System.Drawing.Color.Blue;
            this.shtCustomerOrderList.DefaultStyle.Locked = true;
            this.shtCustomerOrderList.DefaultStyle.Parent = "DataAreaDefault";
            this.shtCustomerOrderList.LockForeColor = System.Drawing.Color.Black;
            this.shtCustomerOrderList.RowHeader.Columns.Default.Resizable = true;
            this.shtCustomerOrderList.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpCustomerOrderList.SetActiveViewport(0, 1, 0);
            // 
            // txtPONo
            // 
            this.txtPONo.AppearanceName = "";
            this.txtPONo.AppearanceReadOnlyName = "";
            this.txtPONo.ControlID = "";
            this.txtPONo.DisableRestrictChar = false;
            this.txtPONo.HelpButton = null;
            this.txtPONo.Location = new System.Drawing.Point(177, 169);
            this.txtPONo.MaxLength = 30;
            this.txtPONo.Name = "txtPONo";
            this.txtPONo.PathString = "PO_NO.Value";
            this.txtPONo.PathValue = "";
            this.txtPONo.Size = new System.Drawing.Size(166, 27);
            this.txtPONo.TabIndex = 5;
            // 
            // txtRemark
            // 
            this.txtRemark.AppearanceName = "";
            this.txtRemark.AppearanceReadOnlyName = "";
            this.txtRemark.ControlID = "";
            this.txtRemark.DisableRestrictChar = false;
            this.txtRemark.HelpButton = null;
            this.txtRemark.Location = new System.Drawing.Point(177, 202);
            this.txtRemark.MaxLength = 255;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.PathString = "REMARK.Value";
            this.txtRemark.PathValue = "";
            this.txtRemark.Size = new System.Drawing.Size(717, 27);
            this.txtRemark.TabIndex = 8;
            this.txtRemark.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRemark_KeyPress);
            // 
            // stcReceiveNo
            // 
            this.stcReceiveNo.AppearanceName = "";
            this.stcReceiveNo.AutoSize = true;
            this.stcReceiveNo.ControlID = "";
            this.stcReceiveNo.Location = new System.Drawing.Point(560, 10);
            this.stcReceiveNo.Name = "stcReceiveNo";
            this.stcReceiveNo.PathString = null;
            this.stcReceiveNo.PathValue = "Order No.";
            this.stcReceiveNo.Size = new System.Drawing.Size(80, 19);
            this.stcReceiveNo.TabIndex = 0;
            this.stcReceiveNo.Text = "Order No.";
            this.stcReceiveNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stdReceiveDate
            // 
            this.stdReceiveDate.AppearanceName = "";
            this.stdReceiveDate.AutoSize = true;
            this.stdReceiveDate.ControlID = "";
            this.stdReceiveDate.Location = new System.Drawing.Point(560, 40);
            this.stdReceiveDate.Name = "stdReceiveDate";
            this.stdReceiveDate.PathString = null;
            this.stdReceiveDate.PathValue = "Receive Date ";
            this.stdReceiveDate.Size = new System.Drawing.Size(104, 19);
            this.stdReceiveDate.TabIndex = 1;
            this.stdReceiveDate.Text = "Receive Date ";
            this.stdReceiveDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.AppearanceName = "";
            this.lblOrderNo.ControlID = "";
            this.lblOrderNo.Location = new System.Drawing.Point(662, 7);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.PathString = "ORDER_NO.Value";
            this.lblOrderNo.PathValue = "";
            this.lblOrderNo.Size = new System.Drawing.Size(233, 24);
            this.lblOrderNo.TabIndex = 0;
            // 
            // dtReceiveDate
            // 
            this.dtReceiveDate.AppearanceName = "";
            this.dtReceiveDate.AppearanceReadOnlyName = "";
            this.dtReceiveDate.BackColor = System.Drawing.Color.Transparent;
            this.dtReceiveDate.ControlID = "";
            this.dtReceiveDate.Format = "dd/MM/yyyy";
            this.dtReceiveDate.Location = new System.Drawing.Point(667, 36);
            this.dtReceiveDate.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtReceiveDate.Name = "dtReceiveDate";
            this.dtReceiveDate.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtReceiveDate.NZValue")));
            this.dtReceiveDate.PathString = "RECEIVE_DATE.Value";
            this.dtReceiveDate.PathValue = ((object)(resources.GetObject("dtReceiveDate.PathValue")));
            this.dtReceiveDate.ReadOnly = false;
            this.dtReceiveDate.ShowButton = true;
            this.dtReceiveDate.Size = new System.Drawing.Size(228, 20);
            this.dtReceiveDate.TabIndex = 1;
            this.dtReceiveDate.Value = null;
            this.dtReceiveDate.ValueChanged += new System.EventHandler(this.dtReceiveDate_ValueChanged);
            // 
            // stcReqReceiveDate
            // 
            this.stcReqReceiveDate.AppearanceName = "RequireText";
            this.stcReqReceiveDate.AutoSize = true;
            this.stcReqReceiveDate.ControlID = "";
            this.stcReqReceiveDate.Location = new System.Drawing.Point(536, 40);
            this.stcReqReceiveDate.Name = "stcReqReceiveDate";
            this.stcReqReceiveDate.PathString = null;
            this.stcReqReceiveDate.PathValue = "*";
            this.stcReqReceiveDate.Size = new System.Drawing.Size(18, 19);
            this.stcReqReceiveDate.TabIndex = 3;
            this.stcReqReceiveDate.Text = "*";
            // 
            // lblCustomerCode
            // 
            this.lblCustomerCode.AppearanceName = "";
            this.lblCustomerCode.ControlID = "";
            this.lblCustomerCode.Location = new System.Drawing.Point(36, 104);
            this.lblCustomerCode.Name = "lblCustomerCode";
            this.lblCustomerCode.PathString = null;
            this.lblCustomerCode.PathValue = "Customer Code ";
            this.lblCustomerCode.Size = new System.Drawing.Size(135, 24);
            this.lblCustomerCode.TabIndex = 6;
            this.lblCustomerCode.Text = "Customer Code ";
            this.lblCustomerCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboCustomerCode
            // 
            this.cboCustomerCode.AppearanceName = "";
            this.cboCustomerCode.AppearanceReadOnlyName = "";
            this.cboCustomerCode.ControlID = null;
            this.cboCustomerCode.DropDownHeight = 180;
            this.cboCustomerCode.FormattingEnabled = true;
            this.cboCustomerCode.IntegralHeight = false;
            this.cboCustomerCode.Location = new System.Drawing.Point(177, 103);
            this.cboCustomerCode.Name = "cboCustomerCode";
            this.cboCustomerCode.PathString = "CUSTOMER_CD.Value";
            this.cboCustomerCode.PathValue = null;
            this.cboCustomerCode.Size = new System.Drawing.Size(718, 27);
            this.cboCustomerCode.TabIndex = 2;
            this.cboCustomerCode.SelectedIndexChanged += new System.EventHandler(this.cboCustomerCode_SelectedIndexChanged);
            // 
            // stcReqSupplier
            // 
            this.stcReqSupplier.AppearanceName = "RequireText";
            this.stcReqSupplier.AutoSize = true;
            this.stcReqSupplier.ControlID = "";
            this.stcReqSupplier.Location = new System.Drawing.Point(12, 140);
            this.stcReqSupplier.Name = "stcReqSupplier";
            this.stcReqSupplier.PathString = null;
            this.stcReqSupplier.PathValue = "*";
            this.stcReqSupplier.Size = new System.Drawing.Size(18, 19);
            this.stcReqSupplier.TabIndex = 3;
            this.stcReqSupplier.Text = "*";
            this.stcReqSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPODate
            // 
            this.lblPODate.AppearanceName = "";
            this.lblPODate.AutoSize = true;
            this.lblPODate.ControlID = "";
            this.lblPODate.Location = new System.Drawing.Point(351, 173);
            this.lblPODate.Name = "lblPODate";
            this.lblPODate.PathString = null;
            this.lblPODate.PathValue = "PO Date ";
            this.lblPODate.Size = new System.Drawing.Size(72, 19);
            this.lblPODate.TabIndex = 6;
            this.lblPODate.Text = "PO Date ";
            this.lblPODate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtPODate
            // 
            this.dtPODate.AppearanceName = "";
            this.dtPODate.AppearanceReadOnlyName = "";
            this.dtPODate.BackColor = System.Drawing.Color.Transparent;
            this.dtPODate.ControlID = "";
            this.dtPODate.Format = "dd/MM/yyyy";
            this.dtPODate.Location = new System.Drawing.Point(429, 169);
            this.dtPODate.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtPODate.Name = "dtPODate";
            this.dtPODate.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtPODate.NZValue")));
            this.dtPODate.PathString = "PO_DATE.Value";
            this.dtPODate.PathValue = ((object)(resources.GetObject("dtPODate.PathValue")));
            this.dtPODate.ReadOnly = false;
            this.dtPODate.ShowButton = true;
            this.dtPODate.Size = new System.Drawing.Size(140, 20);
            this.dtPODate.TabIndex = 6;
            this.dtPODate.Value = null;
            // 
            // evoLabel1
            // 
            this.evoLabel1.AppearanceName = "";
            this.evoLabel1.AutoSize = true;
            this.evoLabel1.ControlID = "";
            this.evoLabel1.Location = new System.Drawing.Point(36, 140);
            this.evoLabel1.Name = "evoLabel1";
            this.evoLabel1.PathString = null;
            this.evoLabel1.PathValue = "Type ";
            this.evoLabel1.Size = new System.Drawing.Size(49, 19);
            this.evoLabel1.TabIndex = 42;
            this.evoLabel1.Text = "Type ";
            this.evoLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboType
            // 
            this.cboType.AppearanceName = "";
            this.cboType.AppearanceReadOnlyName = "";
            this.cboType.ControlID = null;
            this.cboType.DropDownHeight = 180;
            this.cboType.FormattingEnabled = true;
            this.cboType.IntegralHeight = false;
            this.cboType.Location = new System.Drawing.Point(177, 136);
            this.cboType.Name = "cboType";
            this.cboType.PathString = "ORDER_TYPE.Value";
            this.cboType.PathValue = null;
            this.cboType.Size = new System.Drawing.Size(392, 27);
            this.cboType.TabIndex = 3;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel1.BackgroundImage")));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.stcReceiveListInfo, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 232);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(886, 24);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalAmount.AppearanceName = "";
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.ControlID = "";
            this.lblTotalAmount.Location = new System.Drawing.Point(332, 693);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.PathString = null;
            this.lblTotalAmount.PathValue = "Amount";
            this.lblTotalAmount.Size = new System.Drawing.Size(66, 19);
            this.lblTotalAmount.TabIndex = 45;
            this.lblTotalAmount.Text = "Amount";
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalQty.AppearanceName = "";
            this.lblTotalQty.AutoSize = true;
            this.lblTotalQty.ControlID = "";
            this.lblTotalQty.Location = new System.Drawing.Point(67, 693);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.PathString = null;
            this.lblTotalQty.PathValue = "Qty";
            this.lblTotalQty.Size = new System.Drawing.Size(34, 19);
            this.lblTotalQty.TabIndex = 44;
            this.lblTotalQty.Text = "Qty";
            // 
            // evoLabel2
            // 
            this.evoLabel2.AppearanceName = "RequireText";
            this.evoLabel2.AutoSize = true;
            this.evoLabel2.ControlID = "";
            this.evoLabel2.Location = new System.Drawing.Point(12, 107);
            this.evoLabel2.Name = "evoLabel2";
            this.evoLabel2.PathString = null;
            this.evoLabel2.PathValue = "*";
            this.evoLabel2.Size = new System.Drawing.Size(18, 19);
            this.evoLabel2.TabIndex = 49;
            this.evoLabel2.Text = "*";
            this.evoLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // evoLabel3
            // 
            this.evoLabel3.AppearanceName = "";
            this.evoLabel3.AutoSize = true;
            this.evoLabel3.ControlID = "";
            this.evoLabel3.Location = new System.Drawing.Point(657, 140);
            this.evoLabel3.Name = "evoLabel3";
            this.evoLabel3.PathString = null;
            this.evoLabel3.PathValue = "Currency";
            this.evoLabel3.Size = new System.Drawing.Size(72, 19);
            this.evoLabel3.TabIndex = 6;
            this.evoLabel3.Text = "Currency";
            this.evoLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboCurrency
            // 
            this.cboCurrency.AppearanceName = "";
            this.cboCurrency.AppearanceReadOnlyName = "";
            this.cboCurrency.ControlID = null;
            this.cboCurrency.DropDownHeight = 180;
            this.cboCurrency.FormattingEnabled = true;
            this.cboCurrency.IntegralHeight = false;
            this.cboCurrency.Location = new System.Drawing.Point(738, 136);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.PathString = "CURRENCY.Value";
            this.cboCurrency.PathValue = null;
            this.cboCurrency.Size = new System.Drawing.Size(157, 27);
            this.cboCurrency.TabIndex = 4;
            this.cboCurrency.SelectedIndexChanged += new System.EventHandler(this.cboCurrency_SelectedIndexChanged);
            // 
            // evoLabel4
            // 
            this.evoLabel4.AppearanceName = "";
            this.evoLabel4.AutoSize = true;
            this.evoLabel4.ControlID = "";
            this.evoLabel4.Location = new System.Drawing.Point(620, 173);
            this.evoLabel4.Name = "evoLabel4";
            this.evoLabel4.PathString = null;
            this.evoLabel4.PathValue = "Exchange Rate";
            this.evoLabel4.Size = new System.Drawing.Size(112, 19);
            this.evoLabel4.TabIndex = 6;
            this.evoLabel4.Text = "Exchange Rate";
            this.evoLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtExchangeRate
            // 
            this.txtExchangeRate.AllowNegative = false;
            this.txtExchangeRate.AppearanceName = "";
            this.txtExchangeRate.AppearanceReadOnlyName = "";
            this.txtExchangeRate.ControlID = "";
            this.txtExchangeRate.Decimal = new decimal(new int[] {
            10000,
            0,
            0,
            262144});
            this.txtExchangeRate.DecimalPoint = '.';
            this.txtExchangeRate.DigitsInGroup = 3;
            this.txtExchangeRate.Double = 1D;
            this.txtExchangeRate.FixDecimalPosition = false;
            this.txtExchangeRate.Flags = 65536;
            this.txtExchangeRate.GroupSeparator = ',';
            this.txtExchangeRate.Int = 0;
            this.txtExchangeRate.Location = new System.Drawing.Point(738, 169);
            this.txtExchangeRate.Long = ((long)(0));
            this.txtExchangeRate.MaxDecimalPlaces = 4;
            this.txtExchangeRate.MaxWholeDigits = 6;
            this.txtExchangeRate.Name = "txtExchangeRate";
            this.txtExchangeRate.NegativeSign = '-';
            this.txtExchangeRate.PathString = "EXCHANGE_RATE.Value";
            this.txtExchangeRate.PathValue = new decimal(new int[] {
            10000,
            0,
            0,
            262144});
            this.txtExchangeRate.Prefix = "";
            this.txtExchangeRate.RangeMax = 1.7976931348623157E+308D;
            this.txtExchangeRate.RangeMin = 0D;
            this.txtExchangeRate.Size = new System.Drawing.Size(80, 27);
            this.txtExchangeRate.TabIndex = 7;
            this.txtExchangeRate.Text = "1.0000";
            this.txtExchangeRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtExchangeRate.Validating += new System.ComponentModel.CancelEventHandler(this.txtExchangeRate_Validating);
            // 
            // evoLabel5
            // 
            this.evoLabel5.AppearanceName = "";
            this.evoLabel5.AutoSize = true;
            this.evoLabel5.ControlID = "";
            this.evoLabel5.Location = new System.Drawing.Point(824, 173);
            this.evoLabel5.Name = "evoLabel5";
            this.evoLabel5.PathString = null;
            this.evoLabel5.PathValue = "(to THB)";
            this.evoLabel5.Size = new System.Drawing.Size(70, 19);
            this.evoLabel5.TabIndex = 6;
            this.evoLabel5.Text = "(to THB)";
            this.evoLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // evoLabel6
            // 
            this.evoLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.evoLabel6.AppearanceName = "";
            this.evoLabel6.AutoSize = true;
            this.evoLabel6.ControlID = "";
            this.evoLabel6.Location = new System.Drawing.Point(597, 693);
            this.evoLabel6.Name = "evoLabel6";
            this.evoLabel6.PathString = null;
            this.evoLabel6.PathValue = "Amount (THB)";
            this.evoLabel6.Size = new System.Drawing.Size(113, 19);
            this.evoLabel6.TabIndex = 45;
            this.evoLabel6.Text = "Amount (THB)";
            // 
            // txtQty
            // 
            this.txtQty.AllowNegative = true;
            this.txtQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtQty.AppearanceName = "";
            this.txtQty.AppearanceReadOnlyName = "";
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
            this.txtQty.Location = new System.Drawing.Point(116, 689);
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
            this.txtQty.Size = new System.Drawing.Size(150, 27);
            this.txtQty.TabIndex = 52;
            this.txtQty.Text = "0";
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAmount
            // 
            this.txtAmount.AllowNegative = true;
            this.txtAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAmount.AppearanceName = "";
            this.txtAmount.AppearanceReadOnlyName = "";
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
            this.txtAmount.Location = new System.Drawing.Point(404, 689);
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
            this.txtAmount.Size = new System.Drawing.Size(150, 27);
            this.txtAmount.TabIndex = 52;
            this.txtAmount.Text = "0";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAmountTHB
            // 
            this.txtAmountTHB.AllowNegative = true;
            this.txtAmountTHB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAmountTHB.AppearanceName = "";
            this.txtAmountTHB.AppearanceReadOnlyName = "";
            this.txtAmountTHB.ControlID = "";
            this.txtAmountTHB.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtAmountTHB.DecimalPoint = '.';
            this.txtAmountTHB.DigitsInGroup = 3;
            this.txtAmountTHB.Double = 0D;
            this.txtAmountTHB.FixDecimalPosition = true;
            this.txtAmountTHB.Flags = 0;
            this.txtAmountTHB.GroupSeparator = ',';
            this.txtAmountTHB.Int = 0;
            this.txtAmountTHB.Location = new System.Drawing.Point(716, 689);
            this.txtAmountTHB.Long = ((long)(0));
            this.txtAmountTHB.MaxDecimalPlaces = 4;
            this.txtAmountTHB.MaxWholeDigits = 9;
            this.txtAmountTHB.Name = "txtAmountTHB";
            this.txtAmountTHB.NegativeSign = '-';
            this.txtAmountTHB.PathString = "TOTAL_AMOUNT_THB.Value";
            this.txtAmountTHB.PathValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtAmountTHB.Prefix = "";
            this.txtAmountTHB.RangeMax = 1.7976931348623157E+308D;
            this.txtAmountTHB.RangeMin = -1.7976931348623157E+308D;
            this.txtAmountTHB.Size = new System.Drawing.Size(150, 27);
            this.txtAmountTHB.TabIndex = 52;
            this.txtAmountTHB.Text = "0";
            this.txtAmountTHB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rqCurrency
            // 
            this.rqCurrency.AppearanceName = "RequireText";
            this.rqCurrency.AutoSize = true;
            this.rqCurrency.ControlID = "";
            this.rqCurrency.Location = new System.Drawing.Point(635, 140);
            this.rqCurrency.Name = "rqCurrency";
            this.rqCurrency.PathString = null;
            this.rqCurrency.PathValue = "*";
            this.rqCurrency.Size = new System.Drawing.Size(18, 19);
            this.rqCurrency.TabIndex = 53;
            this.rqCurrency.Text = "*";
            this.rqCurrency.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // evoLabel7
            // 
            this.evoLabel7.AppearanceName = "RequireText";
            this.evoLabel7.AutoSize = true;
            this.evoLabel7.ControlID = "";
            this.evoLabel7.Location = new System.Drawing.Point(596, 173);
            this.evoLabel7.Name = "evoLabel7";
            this.evoLabel7.PathString = null;
            this.evoLabel7.PathValue = "*";
            this.evoLabel7.Size = new System.Drawing.Size(18, 19);
            this.evoLabel7.TabIndex = 53;
            this.evoLabel7.Text = "*";
            this.evoLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TRN190_CustomerOrderEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(907, 778);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 390);
            this.Name = "TRN190_CustomerOrderEntry";
            this.Text = "Customer Order Entry";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TRN190_FormClosed);
            this.Load += new System.EventHandler(this.TRN190_Load);
            this.Shown += new System.EventHandler(this.TRN190_Shown);
            this.Controls.SetChildIndex(this.pnlContainer, 0);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.tlpHeader2.ResumeLayout(false);
            this.tlpHeader2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpCustomerOrderList)).EndInit();
            this.ctxMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shtCustomerOrderList)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpHeader2;
        private EVOFramework.Windows.Forms.EVOLabel stcReceiveInfo;
        private EVOFramework.Windows.Forms.EVOLabel stcPONo;
        private EVOFramework.Windows.Forms.EVOLabel stcRemark;
        private EVOFramework.Windows.Forms.EVOLabel stcReceiveListInfo;
        private FarPoint.Win.Spread.FpSpread fpCustomerOrderList;
        private FarPoint.Win.Spread.SheetView shtCustomerOrderList;
        private EVOFramework.Windows.Forms.EVOTextBox txtPONo;
        private EVOFramework.Windows.Forms.EVOLabel stcHead;
        private EVOFramework.Windows.Forms.EVOTextBox txtRemark;
        private EVOFramework.Windows.Forms.EVOLabel stcReceiveNo;
        private EVOFramework.Windows.Forms.EVOLabel stdReceiveDate;
        private EVOFramework.Windows.Forms.EVOLabel lblOrderNo;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtReceiveDate;
        private EVOFramework.Windows.Forms.EVOLabel stcReqReceiveDate;
        private EVOFramework.Data.UIDataModelController dmcCustomerOrderList;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem miAdd;
        private System.Windows.Forms.ToolStripMenuItem miDelete;
        private EVOFramework.Windows.Forms.EVOLabel lblCustomerCode;
        private EVOFramework.Windows.Forms.EVOComboBox cboCustomerCode;
        private EVOFramework.Windows.Forms.EVOLabel stcReqSupplier;
        private EVOFramework.Windows.Forms.EVOLabel lblPODate;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtPODate;
        private EVOFramework.Windows.Forms.EVOComboBox cboType;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private EVOFramework.Windows.Forms.EVOLabel lblTotalAmount;
        private EVOFramework.Windows.Forms.EVOLabel lblTotalQty;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel2;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel3;
        private EVOFramework.Windows.Forms.EVOComboBox cboCurrency;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel4;
        private EVOFramework.Windows.Forms.EVONumericTextBox txtExchangeRate;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel5;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel6;
        private EVOFramework.Windows.Forms.EVONumericTextBox txtAmountTHB;
        private EVOFramework.Windows.Forms.EVONumericTextBox txtAmount;
        private EVOFramework.Windows.Forms.EVONumericTextBox txtQty;
        private EVOFramework.Windows.Forms.EVOLabel rqCurrency;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel7;

    }
}
