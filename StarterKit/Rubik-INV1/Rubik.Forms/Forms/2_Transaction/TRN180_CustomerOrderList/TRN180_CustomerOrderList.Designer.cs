namespace Rubik.Transaction
{
    partial class TRN180_CustomerOrderList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TRN180_CustomerOrderList));
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.stcHead = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcDash = new EVOFramework.Windows.Forms.EVOLabel();
            this.dtPeriodBegin = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.dtPeriodEnd = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.fpCustomerOrderList = new FarPoint.Win.Spread.FpSpread();
            this.shtCustomerOrderList = new FarPoint.Win.Spread.SheetView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtSearch = new EVOFramework.Windows.Forms.EVOTextBox();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.miDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.miDeleteGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTotalQty = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblTotalAmount = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblGrandTotal = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtQty = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.txtAmount = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.txtAmountTHB = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.lblDate = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboFilterDate = new EVOFramework.Windows.Forms.EVOComboBox();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpCustomerOrderList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtCustomerOrderList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.ctxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.cboFilterDate);
            this.pnlContainer.Controls.Add(this.lblDate);
            this.pnlContainer.Controls.Add(this.txtAmountTHB);
            this.pnlContainer.Controls.Add(this.txtAmount);
            this.pnlContainer.Controls.Add(this.txtQty);
            this.pnlContainer.Controls.Add(this.evoLabel1);
            this.pnlContainer.Controls.Add(this.lblGrandTotal);
            this.pnlContainer.Controls.Add(this.lblTotalAmount);
            this.pnlContainer.Controls.Add(this.lblTotalQty);
            this.pnlContainer.Controls.Add(this.txtSearch);
            this.pnlContainer.Controls.Add(this.pictureBox1);
            this.pnlContainer.Controls.Add(this.dtPeriodEnd);
            this.pnlContainer.Controls.Add(this.stcDash);
            this.pnlContainer.Controls.Add(this.fpCustomerOrderList);
            this.pnlContainer.Controls.Add(this.stcHead);
            this.pnlContainer.Controls.Add(this.dtPeriodBegin);
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlContainer.Size = new System.Drawing.Size(982, 432);
            // 
            // stcHead
            // 
            this.stcHead.AccessibleName = "";
            this.stcHead.AppearanceName = "Title";
            this.stcHead.AutoSize = true;
            this.stcHead.ControlID = "";
            this.stcHead.Font = new System.Drawing.Font("Tahoma", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.stcHead.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.stcHead.Location = new System.Drawing.Point(9, 5);
            this.stcHead.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.stcHead.Name = "stcHead";
            this.stcHead.Padding = new System.Windows.Forms.Padding(3);
            this.stcHead.PathString = null;
            this.stcHead.PathValue = "Customer Order List";
            this.stcHead.Size = new System.Drawing.Size(294, 39);
            this.stcHead.TabIndex = 37;
            this.stcHead.Text = "Customer Order List";
            // 
            // stcDash
            // 
            this.stcDash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stcDash.AppearanceName = "";
            this.stcDash.AutoSize = true;
            this.stcDash.ControlID = "";
            this.stcDash.Location = new System.Drawing.Point(802, 15);
            this.stcDash.Name = "stcDash";
            this.stcDash.PathString = null;
            this.stcDash.PathValue = "-";
            this.stcDash.Size = new System.Drawing.Size(15, 19);
            this.stcDash.TabIndex = 1;
            this.stcDash.Text = "-";
            this.stcDash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtPeriodBegin
            // 
            this.dtPeriodBegin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtPeriodBegin.AppearanceName = "";
            this.dtPeriodBegin.AppearanceReadOnlyName = "";
            this.dtPeriodBegin.BackColor = System.Drawing.Color.Transparent;
            this.dtPeriodBegin.ControlID = "";
            this.dtPeriodBegin.Format = "dd/MM/yyyy";
            this.dtPeriodBegin.Location = new System.Drawing.Point(646, 11);
            this.dtPeriodBegin.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtPeriodBegin.Name = "dtPeriodBegin";
            this.dtPeriodBegin.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtPeriodBegin.NZValue")));
            this.dtPeriodBegin.PathString = null;
            this.dtPeriodBegin.PathValue = ((object)(resources.GetObject("dtPeriodBegin.PathValue")));
            this.dtPeriodBegin.ReadOnly = false;
            this.dtPeriodBegin.ShowButton = true;
            this.dtPeriodBegin.Size = new System.Drawing.Size(150, 20);
            this.dtPeriodBegin.TabIndex = 1;
            this.dtPeriodBegin.Value = null;
            // 
            // dtPeriodEnd
            // 
            this.dtPeriodEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtPeriodEnd.AppearanceName = "";
            this.dtPeriodEnd.AppearanceReadOnlyName = "";
            this.dtPeriodEnd.BackColor = System.Drawing.Color.Transparent;
            this.dtPeriodEnd.ControlID = "";
            this.dtPeriodEnd.Format = "dd/MM/yyyy";
            this.dtPeriodEnd.Location = new System.Drawing.Point(823, 11);
            this.dtPeriodEnd.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtPeriodEnd.Name = "dtPeriodEnd";
            this.dtPeriodEnd.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtPeriodEnd.NZValue")));
            this.dtPeriodEnd.PathString = null;
            this.dtPeriodEnd.PathValue = ((object)(resources.GetObject("dtPeriodEnd.PathValue")));
            this.dtPeriodEnd.ReadOnly = false;
            this.dtPeriodEnd.ShowButton = true;
            this.dtPeriodEnd.Size = new System.Drawing.Size(150, 20);
            this.dtPeriodEnd.TabIndex = 2;
            this.dtPeriodEnd.Value = null;
            // 
            // fpCustomerOrderList
            // 
            this.fpCustomerOrderList.About = "2.5.2015.2005";
            this.fpCustomerOrderList.AccessibleDescription = "fpCustomerOrderList, Sheet1, Row 0, Column 0, ";
            this.fpCustomerOrderList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fpCustomerOrderList.BackColor = System.Drawing.Color.AliceBlue;
            this.fpCustomerOrderList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpCustomerOrderList.Location = new System.Drawing.Point(3, 77);
            this.fpCustomerOrderList.Name = "fpCustomerOrderList";
            this.fpCustomerOrderList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpCustomerOrderList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpCustomerOrderList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtCustomerOrderList});
            this.fpCustomerOrderList.Size = new System.Drawing.Size(976, 310);
            this.fpCustomerOrderList.TabIndex = 2;
            this.fpCustomerOrderList.TabStop = false;
            this.fpCustomerOrderList.TextTipDelay = 1000;
            this.fpCustomerOrderList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpCustomerOrderList.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpView_CellDoubleClick);
            this.fpCustomerOrderList.AutoFilteredColumn += new FarPoint.Win.Spread.AutoFilteredColumnEventHandler(this.fpCustomerOrderList_AutoFilteredColumn);
            this.fpCustomerOrderList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpCustomerOrderList_KeyDown);
            this.fpCustomerOrderList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fpView_KeyPress);
            this.fpCustomerOrderList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fpView_MouseDown);
            // 
            // shtCustomerOrderList
            // 
            this.shtCustomerOrderList.Reset();
            this.shtCustomerOrderList.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtCustomerOrderList.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtCustomerOrderList.ColumnCount = 19;
            this.shtCustomerOrderList.RowCount = 0;
            this.shtCustomerOrderList.AutoGenerateColumns = false;
            this.shtCustomerOrderList.ColumnHeader.Cells.Get(0, 0).Value = "Order No.";
            this.shtCustomerOrderList.ColumnHeader.Cells.Get(0, 1).Value = "Order Detail No.";
            this.shtCustomerOrderList.ColumnHeader.Cells.Get(0, 2).Value = "Receive Date";
            this.shtCustomerOrderList.ColumnHeader.Cells.Get(0, 3).Value = "Customer";
            this.shtCustomerOrderList.ColumnHeader.Cells.Get(0, 4).Value = "Customer Name";
            this.shtCustomerOrderList.ColumnHeader.Cells.Get(0, 5).Value = "Type";
            this.shtCustomerOrderList.ColumnHeader.Cells.Get(0, 6).Value = "Type Desc.";
            this.shtCustomerOrderList.ColumnHeader.Cells.Get(0, 7).Value = "PO No.";
            this.shtCustomerOrderList.ColumnHeader.Cells.Get(0, 8).Value = "PO Date";
            this.shtCustomerOrderList.ColumnHeader.Cells.Get(0, 9).Value = "Currency";
            this.shtCustomerOrderList.ColumnHeader.Cells.Get(0, 10).Value = "Exchange Rate";
            this.shtCustomerOrderList.ColumnHeader.Cells.Get(0, 11).Value = "Remark";
            this.shtCustomerOrderList.ColumnHeader.Cells.Get(0, 12).Value = "M/N";
            this.shtCustomerOrderList.ColumnHeader.Cells.Get(0, 13).Value = "Part No.";
            this.shtCustomerOrderList.ColumnHeader.Cells.Get(0, 14).Value = "Del. Date";
            this.shtCustomerOrderList.ColumnHeader.Cells.Get(0, 15).Value = "Qty";
            this.shtCustomerOrderList.ColumnHeader.Cells.Get(0, 16).Value = "Price";
            this.shtCustomerOrderList.ColumnHeader.Cells.Get(0, 17).Value = "Amount";
            this.shtCustomerOrderList.ColumnHeader.Cells.Get(0, 18).Value = "Amount (THB)";
            this.shtCustomerOrderList.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtCustomerOrderList.Columns.Get(0).AllowAutoFilter = true;
            this.shtCustomerOrderList.Columns.Get(0).AllowAutoSort = true;
            this.shtCustomerOrderList.Columns.Get(0).Label = "Order No.";
            this.shtCustomerOrderList.Columns.Get(0).Width = 150F;
            this.shtCustomerOrderList.Columns.Get(1).AllowAutoFilter = true;
            this.shtCustomerOrderList.Columns.Get(1).AllowAutoSort = true;
            this.shtCustomerOrderList.Columns.Get(1).Label = "Order Detail No.";
            this.shtCustomerOrderList.Columns.Get(1).Tag = "Order Detail No.";
            this.shtCustomerOrderList.Columns.Get(1).Visible = false;
            this.shtCustomerOrderList.Columns.Get(1).Width = 150F;
            this.shtCustomerOrderList.Columns.Get(2).AllowAutoFilter = true;
            this.shtCustomerOrderList.Columns.Get(2).AllowAutoSort = true;
            this.shtCustomerOrderList.Columns.Get(2).Label = "Receive Date";
            this.shtCustomerOrderList.Columns.Get(2).Tag = "ORDER_DATE";
            this.shtCustomerOrderList.Columns.Get(2).Width = 150F;
            this.shtCustomerOrderList.Columns.Get(3).AllowAutoFilter = true;
            this.shtCustomerOrderList.Columns.Get(3).AllowAutoSort = true;
            this.shtCustomerOrderList.Columns.Get(3).Label = "Customer";
            this.shtCustomerOrderList.Columns.Get(3).Tag = "DEALING_CD";
            this.shtCustomerOrderList.Columns.Get(3).Width = 120F;
            this.shtCustomerOrderList.Columns.Get(4).AllowAutoFilter = true;
            this.shtCustomerOrderList.Columns.Get(4).AllowAutoSort = true;
            this.shtCustomerOrderList.Columns.Get(4).Label = "Customer Name";
            this.shtCustomerOrderList.Columns.Get(4).Tag = "DEALING_DESC";
            this.shtCustomerOrderList.Columns.Get(4).Width = 120F;
            this.shtCustomerOrderList.Columns.Get(5).AllowAutoFilter = true;
            this.shtCustomerOrderList.Columns.Get(5).AllowAutoSort = true;
            this.shtCustomerOrderList.Columns.Get(5).Label = "Type";
            this.shtCustomerOrderList.Columns.Get(5).Tag = "ORDER_TYPE";
            this.shtCustomerOrderList.Columns.Get(5).Width = 150F;
            this.shtCustomerOrderList.Columns.Get(6).Label = "Type Desc.";
            this.shtCustomerOrderList.Columns.Get(6).Visible = false;
            this.shtCustomerOrderList.Columns.Get(6).Width = 120F;
            this.shtCustomerOrderList.Columns.Get(7).AllowAutoFilter = true;
            this.shtCustomerOrderList.Columns.Get(7).AllowAutoSort = true;
            this.shtCustomerOrderList.Columns.Get(7).Label = "PO No.";
            this.shtCustomerOrderList.Columns.Get(7).Tag = "PO_NO";
            this.shtCustomerOrderList.Columns.Get(7).Width = 100F;
            this.shtCustomerOrderList.Columns.Get(8).AllowAutoFilter = true;
            this.shtCustomerOrderList.Columns.Get(8).AllowAutoSort = true;
            this.shtCustomerOrderList.Columns.Get(8).Label = "PO Date";
            this.shtCustomerOrderList.Columns.Get(8).Locked = true;
            this.shtCustomerOrderList.Columns.Get(8).Tag = "PO_DATE";
            this.shtCustomerOrderList.Columns.Get(8).Width = 120F;
            this.shtCustomerOrderList.Columns.Get(9).AllowAutoFilter = true;
            this.shtCustomerOrderList.Columns.Get(9).AllowAutoSort = true;
            this.shtCustomerOrderList.Columns.Get(9).Label = "Currency";
            this.shtCustomerOrderList.Columns.Get(9).Tag = "Currency";
            this.shtCustomerOrderList.Columns.Get(9).Width = 110F;
            this.shtCustomerOrderList.Columns.Get(10).AllowAutoFilter = true;
            this.shtCustomerOrderList.Columns.Get(10).AllowAutoSort = true;
            this.shtCustomerOrderList.Columns.Get(10).Label = "Exchange Rate";
            this.shtCustomerOrderList.Columns.Get(10).Tag = "Exchange Rate";
            this.shtCustomerOrderList.Columns.Get(10).Width = 110F;
            this.shtCustomerOrderList.Columns.Get(11).AllowAutoFilter = true;
            this.shtCustomerOrderList.Columns.Get(11).AllowAutoSort = true;
            this.shtCustomerOrderList.Columns.Get(11).Label = "Remark";
            this.shtCustomerOrderList.Columns.Get(11).Tag = "REMARK";
            this.shtCustomerOrderList.Columns.Get(11).Width = 100F;
            this.shtCustomerOrderList.Columns.Get(12).AllowAutoFilter = true;
            this.shtCustomerOrderList.Columns.Get(12).AllowAutoSort = true;
            this.shtCustomerOrderList.Columns.Get(12).Label = "M/N";
            this.shtCustomerOrderList.Columns.Get(12).Tag = "ITEM_CD";
            this.shtCustomerOrderList.Columns.Get(12).Width = 90F;
            this.shtCustomerOrderList.Columns.Get(13).AllowAutoFilter = true;
            this.shtCustomerOrderList.Columns.Get(13).AllowAutoSort = true;
            this.shtCustomerOrderList.Columns.Get(13).Label = "Part No.";
            this.shtCustomerOrderList.Columns.Get(13).Locked = true;
            this.shtCustomerOrderList.Columns.Get(13).Tag = "SHORT_NAME";
            this.shtCustomerOrderList.Columns.Get(13).Width = 144F;
            this.shtCustomerOrderList.Columns.Get(14).AllowAutoFilter = true;
            this.shtCustomerOrderList.Columns.Get(14).AllowAutoSort = true;
            this.shtCustomerOrderList.Columns.Get(14).Label = "Del. Date";
            this.shtCustomerOrderList.Columns.Get(14).Tag = "Del. Date";
            this.shtCustomerOrderList.Columns.Get(14).Width = 90F;
            this.shtCustomerOrderList.Columns.Get(15).AllowAutoFilter = true;
            this.shtCustomerOrderList.Columns.Get(15).AllowAutoSort = true;
            this.shtCustomerOrderList.Columns.Get(15).Label = "Qty";
            this.shtCustomerOrderList.Columns.Get(15).Tag = "QTY";
            this.shtCustomerOrderList.Columns.Get(15).Width = 100F;
            this.shtCustomerOrderList.Columns.Get(16).AllowAutoFilter = true;
            this.shtCustomerOrderList.Columns.Get(16).AllowAutoSort = true;
            numberCellType1.ShowSeparator = true;
            this.shtCustomerOrderList.Columns.Get(16).CellType = numberCellType1;
            this.shtCustomerOrderList.Columns.Get(16).Label = "Price";
            this.shtCustomerOrderList.Columns.Get(16).Tag = "PRICE";
            this.shtCustomerOrderList.Columns.Get(16).Width = 95F;
            this.shtCustomerOrderList.Columns.Get(17).AllowAutoFilter = true;
            this.shtCustomerOrderList.Columns.Get(17).AllowAutoSort = true;
            numberCellType2.ShowSeparator = true;
            this.shtCustomerOrderList.Columns.Get(17).CellType = numberCellType2;
            this.shtCustomerOrderList.Columns.Get(17).Label = "Amount";
            this.shtCustomerOrderList.Columns.Get(17).Tag = "AMOUNT";
            this.shtCustomerOrderList.Columns.Get(17).Width = 100F;
            this.shtCustomerOrderList.Columns.Get(18).AllowAutoFilter = true;
            this.shtCustomerOrderList.Columns.Get(18).AllowAutoSort = true;
            this.shtCustomerOrderList.Columns.Get(18).Label = "Amount (THB)";
            this.shtCustomerOrderList.Columns.Get(18).Tag = "Amount (THB)";
            this.shtCustomerOrderList.Columns.Get(18).Width = 100F;
            this.shtCustomerOrderList.DataAutoCellTypes = false;
            this.shtCustomerOrderList.DataAutoHeadings = false;
            this.shtCustomerOrderList.DataAutoSizeColumns = false;
            this.shtCustomerOrderList.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.shtCustomerOrderList.RowHeader.Columns.Default.Resizable = true;
            this.shtCustomerOrderList.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.shtCustomerOrderList.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.shtCustomerOrderList.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpCustomerOrderList.SetActiveViewport(0, 1, 0);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Rubik.Forms.Properties.Resources.FIND_TEXT;
            this.pictureBox1.Location = new System.Drawing.Point(24, 45);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.AppearanceName = "";
            this.txtSearch.AppearanceReadOnlyName = "";
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.ControlID = "";
            this.txtSearch.DisableRestrictChar = true;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.HelpButton = null;
            this.txtSearch.Location = new System.Drawing.Point(62, 48);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PathString = null;
            this.txtSearch.PathValue = "";
            this.txtSearch.Size = new System.Drawing.Size(917, 26);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miEdit,
            this.miDelete,
            this.miDeleteGroup});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(138, 70);
            // 
            // miEdit
            // 
            this.miEdit.Name = "miEdit";
            this.miEdit.Size = new System.Drawing.Size(137, 22);
            this.miEdit.Text = "Edit";
            this.miEdit.Click += new System.EventHandler(this.miEdit_Click);
            // 
            // miDelete
            // 
            this.miDelete.Name = "miDelete";
            this.miDelete.Size = new System.Drawing.Size(137, 22);
            this.miDelete.Text = "Delete";
            this.miDelete.Click += new System.EventHandler(this.miDelete_Click);
            // 
            // miDeleteGroup
            // 
            this.miDeleteGroup.Name = "miDeleteGroup";
            this.miDeleteGroup.Size = new System.Drawing.Size(137, 22);
            this.miDeleteGroup.Text = "Delete Group";
            this.miDeleteGroup.Click += new System.EventHandler(this.miDeleteGroup_Click);
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalQty.AppearanceName = "";
            this.lblTotalQty.AutoSize = true;
            this.lblTotalQty.ControlID = "";
            this.lblTotalQty.Location = new System.Drawing.Point(219, 397);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.PathString = null;
            this.lblTotalQty.PathValue = "Qty";
            this.lblTotalQty.Size = new System.Drawing.Size(34, 19);
            this.lblTotalQty.TabIndex = 38;
            this.lblTotalQty.Text = "Qty";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalAmount.AppearanceName = "";
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.ControlID = "";
            this.lblTotalAmount.Location = new System.Drawing.Point(447, 397);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.PathString = null;
            this.lblTotalAmount.PathValue = "Amount";
            this.lblTotalAmount.Size = new System.Drawing.Size(66, 19);
            this.lblTotalAmount.TabIndex = 38;
            this.lblTotalAmount.Text = "Amount";
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGrandTotal.AppearanceName = "";
            this.lblGrandTotal.AutoSize = true;
            this.lblGrandTotal.ControlID = "";
            this.lblGrandTotal.Location = new System.Drawing.Point(87, 397);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.PathString = null;
            this.lblGrandTotal.PathValue = "Total";
            this.lblGrandTotal.Size = new System.Drawing.Size(45, 19);
            this.lblGrandTotal.TabIndex = 40;
            this.lblGrandTotal.Text = "Total";
            // 
            // evoLabel1
            // 
            this.evoLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.evoLabel1.AppearanceName = "";
            this.evoLabel1.AutoSize = true;
            this.evoLabel1.ControlID = "";
            this.evoLabel1.Location = new System.Drawing.Point(693, 397);
            this.evoLabel1.Name = "evoLabel1";
            this.evoLabel1.PathString = null;
            this.evoLabel1.PathValue = "Amount (THB)";
            this.evoLabel1.Size = new System.Drawing.Size(113, 19);
            this.evoLabel1.TabIndex = 41;
            this.evoLabel1.Text = "Amount (THB)";
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
            this.txtQty.FixDecimalPosition = false;
            this.txtQty.Flags = 0;
            this.txtQty.GroupSeparator = ',';
            this.txtQty.Int = 0;
            this.txtQty.Location = new System.Drawing.Point(277, 393);
            this.txtQty.Long = ((long)(0));
            this.txtQty.MaxDecimalPlaces = 4;
            this.txtQty.MaxWholeDigits = 9;
            this.txtQty.Name = "txtQty";
            this.txtQty.NegativeSign = '-';
            this.txtQty.PathString = null;
            this.txtQty.PathValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtQty.Prefix = "";
            this.txtQty.RangeMax = 1.7976931348623157E+308D;
            this.txtQty.RangeMin = -1.7976931348623157E+308D;
            this.txtQty.Size = new System.Drawing.Size(150, 27);
            this.txtQty.TabIndex = 4;
            this.txtQty.Text = "0";
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
            this.txtAmount.FixDecimalPosition = false;
            this.txtAmount.Flags = 0;
            this.txtAmount.GroupSeparator = ',';
            this.txtAmount.Int = 0;
            this.txtAmount.Location = new System.Drawing.Point(532, 393);
            this.txtAmount.Long = ((long)(0));
            this.txtAmount.MaxDecimalPlaces = 4;
            this.txtAmount.MaxWholeDigits = 9;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.NegativeSign = '-';
            this.txtAmount.PathString = null;
            this.txtAmount.PathValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtAmount.Prefix = "";
            this.txtAmount.RangeMax = 1.7976931348623157E+308D;
            this.txtAmount.RangeMin = -1.7976931348623157E+308D;
            this.txtAmount.Size = new System.Drawing.Size(150, 27);
            this.txtAmount.TabIndex = 5;
            this.txtAmount.Text = "0";
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
            this.txtAmountTHB.FixDecimalPosition = false;
            this.txtAmountTHB.Flags = 0;
            this.txtAmountTHB.GroupSeparator = ',';
            this.txtAmountTHB.Int = 0;
            this.txtAmountTHB.Location = new System.Drawing.Point(814, 393);
            this.txtAmountTHB.Long = ((long)(0));
            this.txtAmountTHB.MaxDecimalPlaces = 4;
            this.txtAmountTHB.MaxWholeDigits = 9;
            this.txtAmountTHB.Name = "txtAmountTHB";
            this.txtAmountTHB.NegativeSign = '-';
            this.txtAmountTHB.PathString = null;
            this.txtAmountTHB.PathValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtAmountTHB.Prefix = "";
            this.txtAmountTHB.RangeMax = 1.7976931348623157E+308D;
            this.txtAmountTHB.RangeMin = -1.7976931348623157E+308D;
            this.txtAmountTHB.Size = new System.Drawing.Size(150, 27);
            this.txtAmountTHB.TabIndex = 6;
            this.txtAmountTHB.Text = "0";
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.AppearanceName = "";
            this.lblDate.AutoSize = true;
            this.lblDate.ControlID = "";
            this.lblDate.Location = new System.Drawing.Point(347, 15);
            this.lblDate.Name = "lblDate";
            this.lblDate.PathString = null;
            this.lblDate.PathValue = "Filter Date";
            this.lblDate.Size = new System.Drawing.Size(81, 19);
            this.lblDate.TabIndex = 48;
            this.lblDate.Text = "Filter Date";
            // 
            // cboFilterDate
            // 
            this.cboFilterDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFilterDate.AppearanceName = "";
            this.cboFilterDate.AppearanceReadOnlyName = "";
            this.cboFilterDate.ControlID = null;
            this.cboFilterDate.DropDownHeight = 180;
            this.cboFilterDate.FormattingEnabled = true;
            this.cboFilterDate.IntegralHeight = false;
            this.cboFilterDate.Location = new System.Drawing.Point(434, 11);
            this.cboFilterDate.Name = "cboFilterDate";
            this.cboFilterDate.PathString = null;
            this.cboFilterDate.PathValue = null;
            this.cboFilterDate.Size = new System.Drawing.Size(206, 27);
            this.cboFilterDate.TabIndex = 0;
            // 
            // TRN180_CustomerOrderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(982, 457);
            this.ExportObject = this.fpCustomerOrderList;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TRN180_CustomerOrderList";
            this.Text = "Customer Order List";
            this.Load += new System.EventHandler(this.TRN180_Load);
            this.Shown += new System.EventHandler(this.TRN180_Shown);
            this.Controls.SetChildIndex(this.pnlContainer, 0);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpCustomerOrderList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtCustomerOrderList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ctxMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EVOFramework.Windows.Forms.EVOLabel stcHead;
        private FarPoint.Win.Spread.FpSpread fpCustomerOrderList;
        private FarPoint.Win.Spread.SheetView shtCustomerOrderList;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem miEdit;
        private System.Windows.Forms.ToolStripMenuItem miDelete;
        private EVOFramework.Windows.Forms.EVOLabel stcDash;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtPeriodBegin;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtPeriodEnd;
        private System.Windows.Forms.PictureBox pictureBox1;
        private EVOFramework.Windows.Forms.EVOTextBox txtSearch;
        private System.Windows.Forms.ToolStripMenuItem miDeleteGroup;
        private EVOFramework.Windows.Forms.EVOLabel lblGrandTotal;
        private EVOFramework.Windows.Forms.EVOLabel lblTotalAmount;
        private EVOFramework.Windows.Forms.EVOLabel lblTotalQty;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel1;
        private EVOFramework.Windows.Forms.EVONumericTextBox txtAmountTHB;
        private EVOFramework.Windows.Forms.EVONumericTextBox txtAmount;
        private EVOFramework.Windows.Forms.EVONumericTextBox txtQty;
        private EVOFramework.Windows.Forms.EVOLabel lblDate;
        private EVOFramework.Windows.Forms.EVOComboBox cboFilterDate;
    }
}
