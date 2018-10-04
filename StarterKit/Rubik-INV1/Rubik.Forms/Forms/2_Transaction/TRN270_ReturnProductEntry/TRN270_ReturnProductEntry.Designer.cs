namespace Rubik.Transaction
{
    partial class TRN270_ReturnProductEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TRN270_ReturnProductEntry));
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.CurrencyCellType currencyCellType1 = new FarPoint.Win.Spread.CellType.CurrencyCellType();
            this.stcHead = new EVOFramework.Windows.Forms.EVOLabel();
            this.tlpHeader2 = new System.Windows.Forms.TableLayoutPanel();
            this.stcReceiveInfo = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcReqStoreLoc = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcRemark = new EVOFramework.Windows.Forms.EVOLabel();
            this.tableReceiveListInfo = new System.Windows.Forms.TableLayoutPanel();
            this.stcReceiveListInfo = new EVOFramework.Windows.Forms.EVOLabel();
            this.fpReturnProductList = new FarPoint.Win.Spread.FpSpread();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.miDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.shtReturnProductList = new FarPoint.Win.Spread.SheetView();
            this.txtRemark = new EVOFramework.Windows.Forms.EVOTextBox();
            this.stcReceiveNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.stdReceiveDate = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblReturnNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.dtReturnDate = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.stcReqReceiveDate = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcStoredLoc = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboReturnLoc = new EVOFramework.Windows.Forms.EVOComboBox();
            this.lbCustomerCode = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboCustomerCode = new EVOFramework.Windows.Forms.EVOComboBox();
            this.stcReqSupplier = new EVOFramework.Windows.Forms.EVOLabel();
            this.dmcReturn = new EVOFramework.Data.UIDataModelController(this.components);
            this.btnAddReturn = new EVOFramework.Windows.Forms.EVOButton();
            this.pnlContainer.SuspendLayout();
            this.tlpHeader2.SuspendLayout();
            this.tableReceiveListInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpReturnProductList)).BeginInit();
            this.ctxMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shtReturnProductList)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.btnAddReturn);
            this.pnlContainer.Controls.Add(this.tableReceiveListInfo);
            this.pnlContainer.Controls.Add(this.lblReturnNo);
            this.pnlContainer.Controls.Add(this.stdReceiveDate);
            this.pnlContainer.Controls.Add(this.dtReturnDate);
            this.pnlContainer.Controls.Add(this.stcReceiveNo);
            this.pnlContainer.Controls.Add(this.stcReqReceiveDate);
            this.pnlContainer.Controls.Add(this.tlpHeader2);
            this.pnlContainer.Controls.Add(this.fpReturnProductList);
            this.pnlContainer.Controls.Add(this.stcRemark);
            this.pnlContainer.Controls.Add(this.stcHead);
            this.pnlContainer.Controls.Add(this.stcReqStoreLoc);
            this.pnlContainer.Controls.Add(this.txtRemark);
            this.pnlContainer.Controls.Add(this.cboCustomerCode);
            this.pnlContainer.Controls.Add(this.stcReqSupplier);
            this.pnlContainer.Controls.Add(this.stcStoredLoc);
            this.pnlContainer.Controls.Add(this.cboReturnLoc);
            this.pnlContainer.Controls.Add(this.lbCustomerCode);
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlContainer.Size = new System.Drawing.Size(898, 587);
            // 
            // stcHead
            // 
            this.stcHead.AppearanceName = "Title";
            this.stcHead.AutoSize = true;
            this.stcHead.ControlID = "";
            this.stcHead.Font = new System.Drawing.Font("Tahoma", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.stcHead.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.stcHead.Location = new System.Drawing.Point(13, 12);
            this.stcHead.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.stcHead.Name = "stcHead";
            this.stcHead.PathString = null;
            this.stcHead.PathValue = "Return Product Entry";
            this.stcHead.Size = new System.Drawing.Size(354, 39);
            this.stcHead.TabIndex = 36;
            this.stcHead.Text = "Return Product Entry";
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
            this.tlpHeader2.Location = new System.Drawing.Point(14, 75);
            this.tlpHeader2.Margin = new System.Windows.Forms.Padding(0);
            this.tlpHeader2.Name = "tlpHeader2";
            this.tlpHeader2.RowCount = 1;
            this.tlpHeader2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHeader2.Size = new System.Drawing.Size(872, 24);
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
            this.stcReceiveInfo.PathValue = "Return Product Information";
            this.stcReceiveInfo.Size = new System.Drawing.Size(233, 24);
            this.stcReceiveInfo.TabIndex = 0;
            this.stcReceiveInfo.Text = "Return Product Information";
            // 
            // stcReqStoreLoc
            // 
            this.stcReqStoreLoc.AppearanceName = "RequireText";
            this.stcReqStoreLoc.AutoSize = true;
            this.stcReqStoreLoc.ControlID = "";
            this.stcReqStoreLoc.Location = new System.Drawing.Point(19, 149);
            this.stcReqStoreLoc.Name = "stcReqStoreLoc";
            this.stcReqStoreLoc.PathString = null;
            this.stcReqStoreLoc.PathValue = "*";
            this.stcReqStoreLoc.Size = new System.Drawing.Size(18, 19);
            this.stcReqStoreLoc.TabIndex = 3;
            this.stcReqStoreLoc.Text = "*";
            this.stcReqStoreLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcRemark
            // 
            this.stcRemark.AppearanceName = "";
            this.stcRemark.AutoSize = true;
            this.stcRemark.ControlID = "";
            this.stcRemark.Location = new System.Drawing.Point(49, 182);
            this.stcRemark.Name = "stcRemark";
            this.stcRemark.PathString = null;
            this.stcRemark.PathValue = "Remark";
            this.stcRemark.Size = new System.Drawing.Size(63, 19);
            this.stcRemark.TabIndex = 8;
            this.stcRemark.Text = "Remark";
            this.stcRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableReceiveListInfo
            // 
            this.tableReceiveListInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableReceiveListInfo.AutoSize = true;
            this.tableReceiveListInfo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableReceiveListInfo.BackgroundImage")));
            this.tableReceiveListInfo.ColumnCount = 1;
            this.tableReceiveListInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableReceiveListInfo.Controls.Add(this.stcReceiveListInfo, 0, 0);
            this.tableReceiveListInfo.Location = new System.Drawing.Point(20, 259);
            this.tableReceiveListInfo.Margin = new System.Windows.Forms.Padding(0);
            this.tableReceiveListInfo.Name = "tableReceiveListInfo";
            this.tableReceiveListInfo.RowCount = 1;
            this.tableReceiveListInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableReceiveListInfo.Size = new System.Drawing.Size(866, 24);
            this.tableReceiveListInfo.TabIndex = 9;
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
            this.stcReceiveListInfo.PathValue = "Return Product List Information";
            this.stcReceiveListInfo.Size = new System.Drawing.Size(265, 24);
            this.stcReceiveListInfo.TabIndex = 0;
            this.stcReceiveListInfo.Text = "Return Product List Information";
            // 
            // fpReturnProductList
            // 
            this.fpReturnProductList.About = "2.5.2015.2005";
            this.fpReturnProductList.AccessibleDescription = "fpReturnProductList, Sheet1";
            this.fpReturnProductList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fpReturnProductList.BackColor = System.Drawing.Color.AliceBlue;
            this.fpReturnProductList.ContextMenuStrip = this.ctxMenu;
            this.fpReturnProductList.EditModeReplace = true;
            this.fpReturnProductList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpReturnProductList.Location = new System.Drawing.Point(16, 286);
            this.fpReturnProductList.Name = "fpReturnProductList";
            this.fpReturnProductList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpReturnProductList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpReturnProductList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtReturnProductList});
            this.fpReturnProductList.Size = new System.Drawing.Size(870, 289);
            this.fpReturnProductList.TabIndex = 5;
            this.fpReturnProductList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpReturnProductList.EditModeOn += new System.EventHandler(this.fpView_EditModeOn);
            this.fpReturnProductList.EditModeOff += new System.EventHandler(this.fpView_EditModeOff);
            this.fpReturnProductList.LeaveCell += new FarPoint.Win.Spread.LeaveCellEventHandler(this.fpView_LeaveCell);
            this.fpReturnProductList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpReturnProductList_KeyDown);
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
            // shtReturnProductList
            // 
            this.shtReturnProductList.Reset();
            this.shtReturnProductList.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtReturnProductList.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtReturnProductList.ColumnCount = 17;
            this.shtReturnProductList.RowCount = 0;
            this.shtReturnProductList.AutoCalculation = false;
            this.shtReturnProductList.AutoGenerateColumns = false;
            this.shtReturnProductList.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.shtReturnProductList.ColumnHeader.Cells.Get(0, 0).Value = "PO No.";
            this.shtReturnProductList.ColumnHeader.Cells.Get(0, 1).Value = "Slip No.";
            this.shtReturnProductList.ColumnHeader.Cells.Get(0, 2).Value = "Trans ID.";
            this.shtReturnProductList.ColumnHeader.Cells.Get(0, 3).Value = "Trans Group ID.";
            this.shtReturnProductList.ColumnHeader.Cells.Get(0, 4).Value = "Ref No";
            this.shtReturnProductList.ColumnHeader.Cells.Get(0, 5).Value = "Order No.";
            this.shtReturnProductList.ColumnHeader.Cells.Get(0, 6).Value = "Order Detail No.";
            this.shtReturnProductList.ColumnHeader.Cells.Get(0, 7).Value = "M/N";
            this.shtReturnProductList.ColumnHeader.Cells.Get(0, 8).Value = "Part No.";
            this.shtReturnProductList.ColumnHeader.Cells.Get(0, 9).Value = "Delivery Date";
            this.shtReturnProductList.ColumnHeader.Cells.Get(0, 10).Value = "Pack No.";
            this.shtReturnProductList.ColumnHeader.Cells.Get(0, 11).Value = "FG No.";
            this.shtReturnProductList.ColumnHeader.Cells.Get(0, 12).Value = "Lot No.";
            this.shtReturnProductList.ColumnHeader.Cells.Get(0, 13).Value = "Customer Lot No.";
            this.shtReturnProductList.ColumnHeader.Cells.Get(0, 14).Value = "Delivery Qty";
            this.shtReturnProductList.ColumnHeader.Cells.Get(0, 15).Value = "Returnable Qty";
            this.shtReturnProductList.ColumnHeader.Cells.Get(0, 16).Value = "Return Qty";
            this.shtReturnProductList.ColumnHeader.Rows.Get(0).Height = 40F;
            textCellType1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.shtReturnProductList.Columns.Get(0).CellType = textCellType1;
            this.shtReturnProductList.Columns.Get(0).Label = "PO No.";
            this.shtReturnProductList.Columns.Get(0).Locked = true;
            this.shtReturnProductList.Columns.Get(0).Tag = "PO No.";
            this.shtReturnProductList.Columns.Get(0).Width = 100F;
            this.shtReturnProductList.Columns.Get(1).Label = "Slip No.";
            this.shtReturnProductList.Columns.Get(1).Visible = false;
            this.shtReturnProductList.Columns.Get(1).Width = 100F;
            this.shtReturnProductList.Columns.Get(2).Label = "Trans ID.";
            this.shtReturnProductList.Columns.Get(2).Visible = false;
            this.shtReturnProductList.Columns.Get(2).Width = 100F;
            this.shtReturnProductList.Columns.Get(3).Label = "Trans Group ID.";
            this.shtReturnProductList.Columns.Get(3).Visible = false;
            this.shtReturnProductList.Columns.Get(3).Width = 150F;
            this.shtReturnProductList.Columns.Get(4).Label = "Ref No";
            this.shtReturnProductList.Columns.Get(4).Visible = false;
            this.shtReturnProductList.Columns.Get(4).Width = 100F;
            this.shtReturnProductList.Columns.Get(5).Label = "Order No.";
            this.shtReturnProductList.Columns.Get(5).Tag = "Order No.";
            this.shtReturnProductList.Columns.Get(5).Width = 120F;
            this.shtReturnProductList.Columns.Get(6).Label = "Order Detail No.";
            this.shtReturnProductList.Columns.Get(6).Visible = false;
            this.shtReturnProductList.Columns.Get(6).Width = 140F;
            this.shtReturnProductList.Columns.Get(7).Label = "M/N";
            this.shtReturnProductList.Columns.Get(7).Tag = "Master No.";
            this.shtReturnProductList.Columns.Get(7).Width = 120F;
            this.shtReturnProductList.Columns.Get(8).Label = "Part No.";
            this.shtReturnProductList.Columns.Get(8).Tag = "Part No";
            this.shtReturnProductList.Columns.Get(8).Width = 120F;
            this.shtReturnProductList.Columns.Get(9).Label = "Delivery Date";
            this.shtReturnProductList.Columns.Get(9).Tag = "Delivery Date";
            this.shtReturnProductList.Columns.Get(9).Width = 150F;
            this.shtReturnProductList.Columns.Get(10).Label = "Pack No.";
            this.shtReturnProductList.Columns.Get(10).Locked = false;
            this.shtReturnProductList.Columns.Get(10).Tag = "Pack No.";
            this.shtReturnProductList.Columns.Get(10).Visible = false;
            this.shtReturnProductList.Columns.Get(10).Width = 110F;
            this.shtReturnProductList.Columns.Get(11).Label = "FG No.";
            this.shtReturnProductList.Columns.Get(11).Tag = "FG No.";
            this.shtReturnProductList.Columns.Get(11).Visible = false;
            this.shtReturnProductList.Columns.Get(11).Width = 104F;
            this.shtReturnProductList.Columns.Get(12).Label = "Lot No.";
            this.shtReturnProductList.Columns.Get(12).Tag = "Lot No.";
            this.shtReturnProductList.Columns.Get(12).Width = 97F;
            this.shtReturnProductList.Columns.Get(13).Label = "Customer Lot No.";
            this.shtReturnProductList.Columns.Get(13).Tag = "Customer Lot No.";
            this.shtReturnProductList.Columns.Get(13).Width = 120F;
            this.shtReturnProductList.Columns.Get(14).Label = "Delivery Qty";
            this.shtReturnProductList.Columns.Get(14).Tag = "Delivery Qty";
            this.shtReturnProductList.Columns.Get(14).Width = 97F;
            this.shtReturnProductList.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.shtReturnProductList.Columns.Get(15).Label = "Returnable Qty";
            this.shtReturnProductList.Columns.Get(15).Tag = "Returnable Qty";
            this.shtReturnProductList.Columns.Get(15).Width = 97F;
            currencyCellType1.DecimalPlaces = 6;
            currencyCellType1.DecimalSeparator = ".";
            currencyCellType1.FixedPoint = false;
            currencyCellType1.MaximumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            393216});
            currencyCellType1.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            currencyCellType1.Separator = ",";
            currencyCellType1.ShowCurrencySymbol = false;
            currencyCellType1.ShowSeparator = true;
            this.shtReturnProductList.Columns.Get(16).CellType = currencyCellType1;
            this.shtReturnProductList.Columns.Get(16).Label = "Return Qty";
            this.shtReturnProductList.Columns.Get(16).Locked = false;
            this.shtReturnProductList.Columns.Get(16).Tag = "Return Qty";
            this.shtReturnProductList.Columns.Get(16).Width = 97F;
            this.shtReturnProductList.DataAutoCellTypes = false;
            this.shtReturnProductList.DataAutoHeadings = false;
            this.shtReturnProductList.DataAutoSizeColumns = false;
            this.shtReturnProductList.DefaultStyle.ForeColor = System.Drawing.Color.Blue;
            this.shtReturnProductList.DefaultStyle.Locked = true;
            this.shtReturnProductList.DefaultStyle.Parent = "DataAreaDefault";
            this.shtReturnProductList.LockForeColor = System.Drawing.Color.Black;
            this.shtReturnProductList.RowHeader.Columns.Default.Resizable = true;
            this.shtReturnProductList.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.shtReturnProductList.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpReturnProductList.SetActiveViewport(0, 1, 0);
            // 
            // txtRemark
            // 
            this.txtRemark.AppearanceName = "";
            this.txtRemark.AppearanceReadOnlyName = "";
            this.txtRemark.ControlID = "";
            this.txtRemark.DisableRestrictChar = false;
            this.txtRemark.HelpButton = null;
            this.txtRemark.Location = new System.Drawing.Point(195, 178);
            this.txtRemark.MaxLength = 255;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.PathString = "REMARK.Value";
            this.txtRemark.PathValue = "";
            this.txtRemark.Size = new System.Drawing.Size(691, 27);
            this.txtRemark.TabIndex = 3;
            this.txtRemark.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRemark_KeyPress);
            // 
            // stcReceiveNo
            // 
            this.stcReceiveNo.AppearanceName = "";
            this.stcReceiveNo.AutoSize = true;
            this.stcReceiveNo.ControlID = "";
            this.stcReceiveNo.Location = new System.Drawing.Point(542, 16);
            this.stcReceiveNo.Name = "stcReceiveNo";
            this.stcReceiveNo.PathString = null;
            this.stcReceiveNo.PathValue = "Transaction No.";
            this.stcReceiveNo.Size = new System.Drawing.Size(121, 19);
            this.stcReceiveNo.TabIndex = 0;
            this.stcReceiveNo.Text = "Transaction No.";
            this.stcReceiveNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stdReceiveDate
            // 
            this.stdReceiveDate.AppearanceName = "";
            this.stdReceiveDate.AutoSize = true;
            this.stdReceiveDate.ControlID = "";
            this.stdReceiveDate.Location = new System.Drawing.Point(544, 47);
            this.stdReceiveDate.Name = "stdReceiveDate";
            this.stdReceiveDate.PathString = null;
            this.stdReceiveDate.PathValue = "Return Date";
            this.stdReceiveDate.Size = new System.Drawing.Size(93, 19);
            this.stdReceiveDate.TabIndex = 1;
            this.stdReceiveDate.Text = "Return Date";
            this.stdReceiveDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblReturnNo
            // 
            this.lblReturnNo.AppearanceName = "";
            this.lblReturnNo.ControlID = "";
            this.lblReturnNo.Location = new System.Drawing.Point(664, 13);
            this.lblReturnNo.Name = "lblReturnNo";
            this.lblReturnNo.PathString = "SLIP_NO.Value";
            this.lblReturnNo.PathValue = "";
            this.lblReturnNo.Size = new System.Drawing.Size(222, 25);
            this.lblReturnNo.TabIndex = 0;
            // 
            // dtReturnDate
            // 
            this.dtReturnDate.AppearanceName = "";
            this.dtReturnDate.AppearanceReadOnlyName = "";
            this.dtReturnDate.BackColor = System.Drawing.Color.Transparent;
            this.dtReturnDate.ControlID = "";
            this.dtReturnDate.Format = "dd/MM/yyyy";
            this.dtReturnDate.Location = new System.Drawing.Point(664, 43);
            this.dtReturnDate.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtReturnDate.Name = "dtReturnDate";
            this.dtReturnDate.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtReturnDate.NZValue")));
            this.dtReturnDate.PathString = "TRANS_DATE.Value";
            this.dtReturnDate.PathValue = ((object)(resources.GetObject("dtReturnDate.PathValue")));
            this.dtReturnDate.ReadOnly = false;
            this.dtReturnDate.ShowButton = true;
            this.dtReturnDate.Size = new System.Drawing.Size(222, 20);
            this.dtReturnDate.TabIndex = 0;
            this.dtReturnDate.Value = null;
            this.dtReturnDate.ValueChanged += new System.EventHandler(this.dtReceiveDate_ValueChanged);
            // 
            // stcReqReceiveDate
            // 
            this.stcReqReceiveDate.AppearanceName = "RequireText";
            this.stcReqReceiveDate.AutoSize = true;
            this.stcReqReceiveDate.ControlID = "";
            this.stcReqReceiveDate.Location = new System.Drawing.Point(521, 47);
            this.stcReqReceiveDate.Name = "stcReqReceiveDate";
            this.stcReqReceiveDate.PathString = null;
            this.stcReqReceiveDate.PathValue = "*";
            this.stcReqReceiveDate.Size = new System.Drawing.Size(18, 19);
            this.stcReqReceiveDate.TabIndex = 3;
            this.stcReqReceiveDate.Text = "*";
            // 
            // stcStoredLoc
            // 
            this.stcStoredLoc.AppearanceName = "";
            this.stcStoredLoc.ControlID = "";
            this.stcStoredLoc.Location = new System.Drawing.Point(49, 142);
            this.stcStoredLoc.Name = "stcStoredLoc";
            this.stcStoredLoc.PathString = null;
            this.stcStoredLoc.PathValue = "Return Location";
            this.stcStoredLoc.Size = new System.Drawing.Size(140, 33);
            this.stcStoredLoc.TabIndex = 39;
            this.stcStoredLoc.Text = "Return Location";
            this.stcStoredLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboReturnLoc
            // 
            this.cboReturnLoc.AppearanceName = "";
            this.cboReturnLoc.AppearanceReadOnlyName = "";
            this.cboReturnLoc.BackColor = System.Drawing.SystemColors.Control;
            this.cboReturnLoc.ControlID = null;
            this.cboReturnLoc.DropDownHeight = 180;
            this.cboReturnLoc.FormattingEnabled = true;
            this.cboReturnLoc.IntegralHeight = false;
            this.cboReturnLoc.Location = new System.Drawing.Point(195, 145);
            this.cboReturnLoc.Name = "cboReturnLoc";
            this.cboReturnLoc.PathString = "LOC_CD.Value";
            this.cboReturnLoc.PathValue = null;
            this.cboReturnLoc.ReadOnly = true;
            this.cboReturnLoc.Size = new System.Drawing.Size(691, 27);
            this.cboReturnLoc.TabIndex = 2;
            // 
            // lbCustomerCode
            // 
            this.lbCustomerCode.AppearanceName = "";
            this.lbCustomerCode.ControlID = "";
            this.lbCustomerCode.Location = new System.Drawing.Point(49, 109);
            this.lbCustomerCode.Name = "lbCustomerCode";
            this.lbCustomerCode.PathString = null;
            this.lbCustomerCode.PathValue = "Customer";
            this.lbCustomerCode.Size = new System.Drawing.Size(140, 33);
            this.lbCustomerCode.TabIndex = 6;
            this.lbCustomerCode.Text = "Customer";
            this.lbCustomerCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboCustomerCode
            // 
            this.cboCustomerCode.AppearanceName = "";
            this.cboCustomerCode.AppearanceReadOnlyName = "";
            this.cboCustomerCode.ControlID = null;
            this.cboCustomerCode.DropDownHeight = 180;
            this.cboCustomerCode.FormattingEnabled = true;
            this.cboCustomerCode.IntegralHeight = false;
            this.cboCustomerCode.Location = new System.Drawing.Point(195, 112);
            this.cboCustomerCode.Name = "cboCustomerCode";
            this.cboCustomerCode.PathString = "DEALING_NO.Value";
            this.cboCustomerCode.PathValue = null;
            this.cboCustomerCode.Size = new System.Drawing.Size(691, 27);
            this.cboCustomerCode.TabIndex = 1;
            this.cboCustomerCode.SelectedIndexChanged += new System.EventHandler(this.cboCustomerCode_SelectedIndexChanged);
            // 
            // stcReqSupplier
            // 
            this.stcReqSupplier.AppearanceName = "RequireText";
            this.stcReqSupplier.AutoSize = true;
            this.stcReqSupplier.ControlID = "";
            this.stcReqSupplier.Location = new System.Drawing.Point(19, 116);
            this.stcReqSupplier.Name = "stcReqSupplier";
            this.stcReqSupplier.PathString = null;
            this.stcReqSupplier.PathValue = "*";
            this.stcReqSupplier.Size = new System.Drawing.Size(18, 19);
            this.stcReqSupplier.TabIndex = 3;
            this.stcReqSupplier.Text = "*";
            this.stcReqSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAddReturn
            // 
            this.btnAddReturn.AppearanceName = "";
            this.btnAddReturn.ControlID = null;
            this.btnAddReturn.Location = new System.Drawing.Point(23, 216);
            this.btnAddReturn.Name = "btnAddReturn";
            this.btnAddReturn.Size = new System.Drawing.Size(126, 27);
            this.btnAddReturn.TabIndex = 4;
            this.btnAddReturn.Text = "Add Return";
            this.btnAddReturn.UseVisualStyleBackColor = true;
            this.btnAddReturn.Click += new System.EventHandler(this.btnAddReturn_Click);
            // 
            // TRN270_ReturnProductEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(898, 637);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 390);
            this.Name = "TRN270_ReturnProductEntry";
            this.Text = "Return Product Entry";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TRN020_FormClosed);
            this.Load += new System.EventHandler(this.TRN270_Load);
            this.Shown += new System.EventHandler(this.TRN270_Shown);
            this.Controls.SetChildIndex(this.pnlContainer, 0);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.tlpHeader2.ResumeLayout(false);
            this.tlpHeader2.PerformLayout();
            this.tableReceiveListInfo.ResumeLayout(false);
            this.tableReceiveListInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpReturnProductList)).EndInit();
            this.ctxMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shtReturnProductList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpHeader2;
        private EVOFramework.Windows.Forms.EVOLabel stcReceiveInfo;
        private EVOFramework.Windows.Forms.EVOLabel stcRemark;
        private System.Windows.Forms.TableLayoutPanel tableReceiveListInfo;
        private EVOFramework.Windows.Forms.EVOLabel stcReceiveListInfo;
        private FarPoint.Win.Spread.FpSpread fpReturnProductList;
        private FarPoint.Win.Spread.SheetView shtReturnProductList;
        private EVOFramework.Windows.Forms.EVOLabel stcHead;
        private EVOFramework.Windows.Forms.EVOTextBox txtRemark;
        private EVOFramework.Windows.Forms.EVOLabel stcReceiveNo;
        private EVOFramework.Windows.Forms.EVOLabel stdReceiveDate;
        private EVOFramework.Windows.Forms.EVOLabel lblReturnNo;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtReturnDate;
        private EVOFramework.Windows.Forms.EVOLabel stcReqReceiveDate;
        private EVOFramework.Data.UIDataModelController dmcReturn;
        private EVOFramework.Windows.Forms.EVOLabel stcStoredLoc;
        private EVOFramework.Windows.Forms.EVOComboBox cboReturnLoc;
        private EVOFramework.Windows.Forms.EVOLabel stcReqStoreLoc;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem miAdd;
        private System.Windows.Forms.ToolStripMenuItem miDelete;
        private EVOFramework.Windows.Forms.EVOLabel lbCustomerCode;
        private EVOFramework.Windows.Forms.EVOComboBox cboCustomerCode;
        private EVOFramework.Windows.Forms.EVOLabel stcReqSupplier;
        private EVOFramework.Windows.Forms.EVOButton btnAddReturn;

    }
}
