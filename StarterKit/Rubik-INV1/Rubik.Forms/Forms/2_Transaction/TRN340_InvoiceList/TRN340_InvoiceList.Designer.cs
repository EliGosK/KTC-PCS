namespace Rubik.Transaction
{
    partial class TRN340_InvoiceList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TRN340_InvoiceList));
            this.tableContainer = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeader = new EVOFramework.Windows.Forms.EVOPanel();
            this.stcHead = new EVOFramework.Windows.Forms.EVOLabel();
            this.tableSearch = new System.Windows.Forms.TableLayoutPanel();
            this.stcDash = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcPeriod = new EVOFramework.Windows.Forms.EVOLabel();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.label1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel2 = new EVOFramework.Windows.Forms.EVOLabel();
            this.dtPeriodBegin = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.dtPeriodEnd = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.fpDelivery = new FarPoint.Win.Spread.FpSpread();
            this.shtDelivery = new FarPoint.Win.Spread.SheetView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtSearch = new EVOFramework.Windows.Forms.EVOTextBox();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.miDeletePack = new System.Windows.Forms.ToolStripMenuItem();
            this.miDeleteOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.miDeleteGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbShowAll = new System.Windows.Forms.ToolStripButton();
            this.tsbExport = new System.Windows.Forms.ToolStripButton();
            this.pnlContainer.SuspendLayout();
            this.tableContainer.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.tableSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpDelivery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtDelivery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.ctxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.txtSearch);
            this.pnlContainer.Controls.Add(this.pictureBox1);
            this.pnlContainer.Controls.Add(this.dtPeriodEnd);
            this.pnlContainer.Controls.Add(this.evoLabel1);
            this.pnlContainer.Controls.Add(this.fpDelivery);
            this.pnlContainer.Controls.Add(this.label1);
            this.pnlContainer.Controls.Add(this.dtPeriodBegin);
            this.pnlContainer.Controls.Add(this.evoLabel2);
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlContainer.Size = new System.Drawing.Size(926, 440);
            this.pnlContainer.TabIndex = 0;
            // 
            // tableContainer
            // 
            this.tableContainer.ColumnCount = 2;
            this.tableContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 548F));
            this.tableContainer.Controls.Add(this.pnlHeader, 0, 0);
            this.tableContainer.Location = new System.Drawing.Point(8, 8);
            this.tableContainer.Name = "tableContainer";
            this.tableContainer.RowCount = 1;
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableContainer.Size = new System.Drawing.Size(200, 100);
            this.tableContainer.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.AppearanceName = "";
            this.pnlHeader.AutoSize = true;
            this.pnlHeader.Controls.Add(this.stcHead);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1, 100);
            this.pnlHeader.TabIndex = 0;
            // 
            // stcHead
            // 
            this.stcHead.AppearanceName = "";
            this.stcHead.AutoSize = true;
            this.stcHead.ControlID = "";
            this.stcHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stcHead.Font = new System.Drawing.Font("Tahoma", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.stcHead.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.stcHead.Location = new System.Drawing.Point(0, 0);
            this.stcHead.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.stcHead.Name = "stcHead";
            this.stcHead.PathString = null;
            this.stcHead.PathValue = "Issue by Order List";
            this.stcHead.Size = new System.Drawing.Size(317, 39);
            this.stcHead.TabIndex = 37;
            this.stcHead.Text = "Issue by Order List";
            // 
            // tableSearch
            // 
            this.tableSearch.AutoSize = true;
            this.tableSearch.ColumnCount = 4;
            this.tableSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            this.tableSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableSearch.Controls.Add(this.stcDash, 2, 0);
            this.tableSearch.Location = new System.Drawing.Point(0, 0);
            this.tableSearch.Name = "tableSearch";
            this.tableSearch.RowCount = 1;
            this.tableSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableSearch.Size = new System.Drawing.Size(200, 100);
            this.tableSearch.TabIndex = 0;
            // 
            // stcDash
            // 
            this.stcDash.AppearanceName = "";
            this.stcDash.AutoSize = true;
            this.stcDash.ControlID = "";
            this.stcDash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stcDash.Location = new System.Drawing.Point(167, 0);
            this.stcDash.Name = "stcDash";
            this.stcDash.PathString = null;
            this.stcDash.PathValue = "-";
            this.stcDash.Size = new System.Drawing.Size(10, 100);
            this.stcDash.TabIndex = 1;
            this.stcDash.Text = "-";
            this.stcDash.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // stcPeriod
            // 
            this.stcPeriod.AppearanceName = "";
            this.stcPeriod.AutoSize = true;
            this.stcPeriod.ControlID = "";
            this.stcPeriod.Dock = System.Windows.Forms.DockStyle.Top;
            this.stcPeriod.Location = new System.Drawing.Point(3, 0);
            this.stcPeriod.Name = "stcPeriod";
            this.stcPeriod.PathString = null;
            this.stcPeriod.PathValue = "Inventory Period";
            this.stcPeriod.Size = new System.Drawing.Size(139, 13);
            this.stcPeriod.TabIndex = 0;
            this.stcPeriod.Text = "Inventory Period";
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.Image = global::Rubik.Forms.Properties.Resources.REFRESH;
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(66, 22);
            this.tsbRefresh.Text = "Refresh";
            // 
            // tsbNew
            // 
            this.tsbNew.Image = global::Rubik.Forms.Properties.Resources.DOCUMENT_NEW;
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(76, 22);
            this.tsbNew.Text = "Add New";
            // 
            // tsbExit
            // 
            this.tsbExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbExit.Image = global::Rubik.Forms.Properties.Resources.CLOSE;
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(56, 22);
            this.tsbExit.Text = "Close";
            // 
            // label1
            // 
            this.label1.AppearanceName = "Title";
            this.label1.AutoSize = true;
            this.label1.ControlID = "";
            this.label1.Font = new System.Drawing.Font("Tahoma", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.PathString = null;
            this.label1.PathValue = "Invoice List";
            this.label1.Size = new System.Drawing.Size(172, 33);
            this.label1.TabIndex = 37;
            this.label1.Text = "Invoice List";
            // 
            // evoLabel1
            // 
            this.evoLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.evoLabel1.AppearanceName = "";
            this.evoLabel1.AutoSize = true;
            this.evoLabel1.ControlID = "";
            this.evoLabel1.Location = new System.Drawing.Point(724, 13);
            this.evoLabel1.Name = "evoLabel1";
            this.evoLabel1.PathString = null;
            this.evoLabel1.PathValue = "-";
            this.evoLabel1.Size = new System.Drawing.Size(15, 19);
            this.evoLabel1.TabIndex = 1;
            this.evoLabel1.Text = "-";
            this.evoLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // evoLabel2
            // 
            this.evoLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.evoLabel2.AppearanceName = "";
            this.evoLabel2.AutoSize = true;
            this.evoLabel2.ControlID = "";
            this.evoLabel2.Location = new System.Drawing.Point(422, 13);
            this.evoLabel2.Name = "evoLabel2";
            this.evoLabel2.PathString = null;
            this.evoLabel2.PathValue = "Invoice Date";
            this.evoLabel2.Size = new System.Drawing.Size(97, 19);
            this.evoLabel2.TabIndex = 0;
            this.evoLabel2.Text = "Invoice Date";
            // 
            // dtPeriodBegin
            // 
            this.dtPeriodBegin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtPeriodBegin.AppearanceName = "";
            this.dtPeriodBegin.AppearanceReadOnlyName = "";
            this.dtPeriodBegin.BackColor = System.Drawing.Color.Transparent;
            this.dtPeriodBegin.ControlID = "";
            this.dtPeriodBegin.Format = "dd/MM/yyyy";
            this.dtPeriodBegin.Location = new System.Drawing.Point(533, 12);
            this.dtPeriodBegin.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtPeriodBegin.Name = "dtPeriodBegin";
            this.dtPeriodBegin.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtPeriodBegin.NZValue")));
            this.dtPeriodBegin.PathString = null;
            this.dtPeriodBegin.PathValue = ((object)(resources.GetObject("dtPeriodBegin.PathValue")));
            this.dtPeriodBegin.ReadOnly = false;
            this.dtPeriodBegin.ShowButton = true;
            this.dtPeriodBegin.Size = new System.Drawing.Size(185, 20);
            this.dtPeriodBegin.TabIndex = 0;
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
            this.dtPeriodEnd.Location = new System.Drawing.Point(738, 12);
            this.dtPeriodEnd.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtPeriodEnd.Name = "dtPeriodEnd";
            this.dtPeriodEnd.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtPeriodEnd.NZValue")));
            this.dtPeriodEnd.PathString = null;
            this.dtPeriodEnd.PathValue = ((object)(resources.GetObject("dtPeriodEnd.PathValue")));
            this.dtPeriodEnd.ReadOnly = false;
            this.dtPeriodEnd.ShowButton = true;
            this.dtPeriodEnd.Size = new System.Drawing.Size(185, 20);
            this.dtPeriodEnd.TabIndex = 1;
            this.dtPeriodEnd.Value = null;
            // 
            // fpDelivery
            // 
            this.fpDelivery.About = "2.5.2015.2005";
            this.fpDelivery.AccessibleDescription = "fpDelivery, Sheet1";
            this.fpDelivery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fpDelivery.BackColor = System.Drawing.Color.AliceBlue;
            this.fpDelivery.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpDelivery.Location = new System.Drawing.Point(3, 80);
            this.fpDelivery.Name = "fpDelivery";
            this.fpDelivery.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpDelivery.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpDelivery.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtDelivery});
            this.fpDelivery.Size = new System.Drawing.Size(920, 357);
            this.fpDelivery.TabIndex = 2;
            this.fpDelivery.TabStop = false;
            this.fpDelivery.TextTipDelay = 1000;
            this.fpDelivery.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpDelivery.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpView_CellDoubleClick);
            this.fpDelivery.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpDelivery_KeyDown);
            this.fpDelivery.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fpView_MouseDown);
            // 
            // shtDelivery
            // 
            this.shtDelivery.Reset();
            this.shtDelivery.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtDelivery.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtDelivery.ColumnCount = 15;
            this.shtDelivery.RowCount = 0;
            this.shtDelivery.AutoGenerateColumns = false;
            this.shtDelivery.ColumnHeader.Cells.Get(0, 0).Value = "Invoice Date";
            this.shtDelivery.ColumnHeader.Cells.Get(0, 1).Value = "Invoice No.";
            this.shtDelivery.ColumnHeader.Cells.Get(0, 2).Value = "Cancel Flag";
            this.shtDelivery.ColumnHeader.Cells.Get(0, 3).Value = "Payment Due Date";
            this.shtDelivery.ColumnHeader.Cells.Get(0, 4).Value = "Transaction No.";
            this.shtDelivery.ColumnHeader.Cells.Get(0, 5).Value = "Customer";
            this.shtDelivery.ColumnHeader.Cells.Get(0, 6).Value = "M/N";
            this.shtDelivery.ColumnHeader.Cells.Get(0, 7).Value = "Part No.";
            this.shtDelivery.ColumnHeader.Cells.Get(0, 8).Value = "Part Description";
            this.shtDelivery.ColumnHeader.Cells.Get(0, 9).Value = "PO No.";
            this.shtDelivery.ColumnHeader.Cells.Get(0, 10).Value = "Order No.";
            this.shtDelivery.ColumnHeader.Cells.Get(0, 11).Value = "Remark";
            this.shtDelivery.ColumnHeader.Cells.Get(0, 12).Value = "Delivery Qty";
            this.shtDelivery.ColumnHeader.Cells.Get(0, 13).Value = "Price";
            this.shtDelivery.ColumnHeader.Cells.Get(0, 14).Value = "Amount";
            this.shtDelivery.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtDelivery.Columns.Get(0).AllowAutoFilter = true;
            this.shtDelivery.Columns.Get(0).AllowAutoSort = true;
            this.shtDelivery.Columns.Get(0).Label = "Invoice Date";
            this.shtDelivery.Columns.Get(0).Tag = "Invoice Date";
            this.shtDelivery.Columns.Get(0).Width = 120F;
            this.shtDelivery.Columns.Get(1).AllowAutoFilter = true;
            this.shtDelivery.Columns.Get(1).AllowAutoSort = true;
            this.shtDelivery.Columns.Get(1).Label = "Invoice No.";
            this.shtDelivery.Columns.Get(1).Tag = "Invoice No.";
            this.shtDelivery.Columns.Get(1).Width = 120F;
            this.shtDelivery.Columns.Get(2).AllowAutoFilter = true;
            this.shtDelivery.Columns.Get(2).AllowAutoSort = true;
            this.shtDelivery.Columns.Get(2).Label = "Cancel Flag";
            this.shtDelivery.Columns.Get(2).Tag = "Cancel Flag";
            this.shtDelivery.Columns.Get(2).Width = 120F;
            this.shtDelivery.Columns.Get(3).AllowAutoFilter = true;
            this.shtDelivery.Columns.Get(3).AllowAutoSort = true;
            this.shtDelivery.Columns.Get(3).Label = "Payment Due Date";
            this.shtDelivery.Columns.Get(3).Tag = "Payment Due Date";
            this.shtDelivery.Columns.Get(3).Width = 120F;
            this.shtDelivery.Columns.Get(4).AllowAutoFilter = true;
            this.shtDelivery.Columns.Get(4).AllowAutoSort = true;
            this.shtDelivery.Columns.Get(4).Label = "Transaction No.";
            this.shtDelivery.Columns.Get(4).Tag = "Transaction No.";
            this.shtDelivery.Columns.Get(4).Width = 120F;
            this.shtDelivery.Columns.Get(5).AllowAutoFilter = true;
            this.shtDelivery.Columns.Get(5).AllowAutoSort = true;
            this.shtDelivery.Columns.Get(5).Label = "Customer";
            this.shtDelivery.Columns.Get(5).Tag = "Customer";
            this.shtDelivery.Columns.Get(5).Width = 120F;
            this.shtDelivery.Columns.Get(6).AllowAutoFilter = true;
            this.shtDelivery.Columns.Get(6).AllowAutoSort = true;
            this.shtDelivery.Columns.Get(6).Label = "M/N";
            this.shtDelivery.Columns.Get(6).Tag = "M/N";
            this.shtDelivery.Columns.Get(6).Width = 120F;
            this.shtDelivery.Columns.Get(7).AllowAutoFilter = true;
            this.shtDelivery.Columns.Get(7).AllowAutoSort = true;
            this.shtDelivery.Columns.Get(7).Label = "Part No.";
            this.shtDelivery.Columns.Get(7).Tag = "Part No.";
            this.shtDelivery.Columns.Get(7).Width = 120F;
            this.shtDelivery.Columns.Get(8).AllowAutoFilter = true;
            this.shtDelivery.Columns.Get(8).AllowAutoSort = true;
            this.shtDelivery.Columns.Get(8).Label = "Part Description";
            this.shtDelivery.Columns.Get(8).Tag = "Part Description";
            this.shtDelivery.Columns.Get(8).Width = 120F;
            this.shtDelivery.Columns.Get(9).AllowAutoFilter = true;
            this.shtDelivery.Columns.Get(9).AllowAutoSort = true;
            this.shtDelivery.Columns.Get(9).Label = "PO No.";
            this.shtDelivery.Columns.Get(9).Tag = "PO No.";
            this.shtDelivery.Columns.Get(9).Width = 120F;
            this.shtDelivery.Columns.Get(10).AllowAutoFilter = true;
            this.shtDelivery.Columns.Get(10).AllowAutoSort = true;
            this.shtDelivery.Columns.Get(10).Label = "Order No.";
            this.shtDelivery.Columns.Get(10).Tag = "Order No.";
            this.shtDelivery.Columns.Get(10).Width = 120F;
            this.shtDelivery.Columns.Get(11).AllowAutoFilter = true;
            this.shtDelivery.Columns.Get(11).AllowAutoSort = true;
            this.shtDelivery.Columns.Get(11).Label = "Remark";
            this.shtDelivery.Columns.Get(11).Tag = "Remark";
            this.shtDelivery.Columns.Get(11).Width = 120F;
            this.shtDelivery.Columns.Get(12).AllowAutoFilter = true;
            this.shtDelivery.Columns.Get(12).AllowAutoSort = true;
            this.shtDelivery.Columns.Get(12).Label = "Delivery Qty";
            this.shtDelivery.Columns.Get(12).Tag = "Delivery Qty";
            this.shtDelivery.Columns.Get(12).Width = 120F;
            this.shtDelivery.Columns.Get(13).AllowAutoFilter = true;
            this.shtDelivery.Columns.Get(13).AllowAutoSort = true;
            this.shtDelivery.Columns.Get(13).Label = "Price";
            this.shtDelivery.Columns.Get(13).Tag = "Price";
            this.shtDelivery.Columns.Get(13).Width = 120F;
            this.shtDelivery.Columns.Get(14).AllowAutoFilter = true;
            this.shtDelivery.Columns.Get(14).AllowAutoSort = true;
            this.shtDelivery.Columns.Get(14).Label = "Amount";
            this.shtDelivery.Columns.Get(14).Tag = "Amount";
            this.shtDelivery.Columns.Get(14).Width = 120F;
            this.shtDelivery.DataAutoCellTypes = false;
            this.shtDelivery.DataAutoHeadings = false;
            this.shtDelivery.DataAutoSizeColumns = false;
            this.shtDelivery.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.shtDelivery.RowHeader.Columns.Default.Resizable = true;
            this.shtDelivery.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.shtDelivery.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.shtDelivery.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpDelivery.SetActiveViewport(0, 1, 0);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Rubik.Forms.Properties.Resources.FIND_TEXT;
            this.pictureBox1.Location = new System.Drawing.Point(23, 45);
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
            this.txtSearch.Location = new System.Drawing.Point(61, 48);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PathString = null;
            this.txtSearch.PathValue = "";
            this.txtSearch.Size = new System.Drawing.Size(862, 26);
            this.txtSearch.TabIndex = 7;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miEdit,
            this.miDeletePack,
            this.miDeleteOrder,
            this.miDeleteGroup});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(138, 92);
            // 
            // miEdit
            // 
            this.miEdit.Name = "miEdit";
            this.miEdit.Size = new System.Drawing.Size(137, 22);
            this.miEdit.Text = "Edit";
            this.miEdit.Click += new System.EventHandler(this.miEdit_Click);
            // 
            // miDeletePack
            // 
            this.miDeletePack.Name = "miDeletePack";
            this.miDeletePack.Size = new System.Drawing.Size(137, 22);
            this.miDeletePack.Text = "Delete Pack";
            this.miDeletePack.Click += new System.EventHandler(this.miDeletePack_Click);
            // 
            // miDeleteOrder
            // 
            this.miDeleteOrder.Name = "miDeleteOrder";
            this.miDeleteOrder.Size = new System.Drawing.Size(137, 22);
            this.miDeleteOrder.Text = "Delete Order";
            this.miDeleteOrder.Click += new System.EventHandler(this.miDeleteOrder_Click);
            // 
            // miDeleteGroup
            // 
            this.miDeleteGroup.Name = "miDeleteGroup";
            this.miDeleteGroup.Size = new System.Drawing.Size(137, 22);
            this.miDeleteGroup.Text = "Delete Group";
            this.miDeleteGroup.Click += new System.EventHandler(this.miDeleteGroup_Click);
            // 
            // tsbShowAll
            // 
            this.tsbShowAll.Image = ((System.Drawing.Image)(resources.GetObject("tsbShowAll.Image")));
            this.tsbShowAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShowAll.Name = "tsbShowAll";
            this.tsbShowAll.Size = new System.Drawing.Size(73, 22);
            this.tsbShowAll.Text = "Show All";
            // 
            // tsbExport
            // 
            this.tsbExport.Image = ((System.Drawing.Image)(resources.GetObject("tsbExport.Image")));
            this.tsbExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExport.Name = "tsbExport";
            this.tsbExport.Size = new System.Drawing.Size(60, 22);
            this.tsbExport.Text = "Export";
            // 
            // TRN340_InvoiceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(926, 465);
            this.ExportObject = this.fpDelivery;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TRN340_InvoiceList";
            this.Text = "Invoice List";
            this.Load += new System.EventHandler(this.TRN090_Load);
            this.Shown += new System.EventHandler(this.TRN090_Shown);
            this.Controls.SetChildIndex(this.pnlContainer, 0);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.tableContainer.ResumeLayout(false);
            this.tableContainer.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tableSearch.ResumeLayout(false);
            this.tableSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpDelivery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtDelivery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ctxMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableContainer;
        private EVOFramework.Windows.Forms.EVOPanel pnlHeader;
        private EVOFramework.Windows.Forms.EVOLabel stcHead;
        private System.Windows.Forms.TableLayoutPanel tableSearch;
        private EVOFramework.Windows.Forms.EVOLabel stcDash;
        private EVOFramework.Windows.Forms.EVOLabel stcPeriod;
        private EVOFramework.Windows.Forms.EVOLabel label1;
        private FarPoint.Win.Spread.FpSpread fpDelivery;
        private FarPoint.Win.Spread.SheetView shtDelivery;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel1;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel2;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtPeriodBegin;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtPeriodEnd;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem miEdit;
        private System.Windows.Forms.ToolStripMenuItem miDeletePack;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ToolStripButton tsbShowAll;
        private System.Windows.Forms.ToolStripButton tsbExport;
        private System.Windows.Forms.PictureBox pictureBox1;
        private EVOFramework.Windows.Forms.EVOTextBox txtSearch;
        private System.Windows.Forms.ToolStripMenuItem miDeleteGroup;
        private System.Windows.Forms.ToolStripMenuItem miDeleteOrder;
    }
}
