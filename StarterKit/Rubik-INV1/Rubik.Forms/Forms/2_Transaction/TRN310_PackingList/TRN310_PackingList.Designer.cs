namespace Rubik.Transaction
{
    partial class TRN310_PackingList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TRN310_PackingList));
            this.tableContainer = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeader = new EVOFramework.Windows.Forms.EVOPanel();
            this.stcHead = new EVOFramework.Windows.Forms.EVOLabel();
            this.tableSearch = new System.Windows.Forms.TableLayoutPanel();
            this.stcDash = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcPeriod = new EVOFramework.Windows.Forms.EVOLabel();
            this.dtPeriodBegin = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.dtPeriodEnd = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.fpPackingList = new FarPoint.Win.Spread.FpSpread();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.miDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.miDeleteGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.shtPackingList = new FarPoint.Win.Spread.SheetView();
            this.panSearch = new EVOFramework.Windows.Forms.EVOPanel();
            this.tblSearch = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtSearch = new EVOFramework.Windows.Forms.EVOTextBox();
            this.pnlContainer.SuspendLayout();
            this.tableContainer.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.tableSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpPackingList)).BeginInit();
            this.ctxMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shtPackingList)).BeginInit();
            this.panSearch.SuspendLayout();
            this.tblSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.tableContainer);
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlContainer.Size = new System.Drawing.Size(892, 327);
            // 
            // tableContainer
            // 
            this.tableContainer.ColumnCount = 2;
            this.tableContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 548F));
            this.tableContainer.Controls.Add(this.pnlHeader, 0, 0);
            this.tableContainer.Controls.Add(this.tableSearch, 1, 0);
            this.tableContainer.Controls.Add(this.fpPackingList, 0, 2);
            this.tableContainer.Controls.Add(this.panSearch, 0, 1);
            this.tableContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableContainer.Location = new System.Drawing.Point(0, 0);
            this.tableContainer.Name = "tableContainer";
            this.tableContainer.RowCount = 3;
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableContainer.Size = new System.Drawing.Size(892, 327);
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
            this.pnlHeader.Size = new System.Drawing.Size(344, 33);
            this.pnlHeader.TabIndex = 1;
            // 
            // stcHead
            // 
            this.stcHead.AccessibleName = "";
            this.stcHead.AppearanceName = "Title";
            this.stcHead.AutoSize = true;
            this.stcHead.ControlID = "";
            this.stcHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stcHead.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.stcHead.Location = new System.Drawing.Point(0, 0);
            this.stcHead.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.stcHead.Name = "stcHead";
            this.stcHead.Padding = new System.Windows.Forms.Padding(3);
            this.stcHead.PathString = null;
            this.stcHead.PathValue = "Packing List";
            this.stcHead.Size = new System.Drawing.Size(98, 25);
            this.stcHead.TabIndex = 37;
            this.stcHead.Text = "Packing List";
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
            this.tableSearch.Controls.Add(this.stcPeriod, 0, 0);
            this.tableSearch.Controls.Add(this.dtPeriodBegin, 1, 0);
            this.tableSearch.Controls.Add(this.dtPeriodEnd, 3, 0);
            this.tableSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableSearch.Location = new System.Drawing.Point(344, 0);
            this.tableSearch.Margin = new System.Windows.Forms.Padding(0);
            this.tableSearch.Name = "tableSearch";
            this.tableSearch.RowCount = 1;
            this.tableSearch.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableSearch.Size = new System.Drawing.Size(548, 33);
            this.tableSearch.TabIndex = 0;
            // 
            // stcDash
            // 
            this.stcDash.AppearanceName = "";
            this.stcDash.AutoSize = true;
            this.stcDash.ControlID = "";
            this.stcDash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stcDash.Location = new System.Drawing.Point(339, 0);
            this.stcDash.Name = "stcDash";
            this.stcDash.PathString = null;
            this.stcDash.PathValue = "-";
            this.stcDash.Size = new System.Drawing.Size(15, 33);
            this.stcDash.TabIndex = 1;
            this.stcDash.Text = "-";
            this.stcDash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stcPeriod
            // 
            this.stcPeriod.AppearanceName = "";
            this.stcPeriod.AutoSize = true;
            this.stcPeriod.ControlID = "";
            this.stcPeriod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stcPeriod.Location = new System.Drawing.Point(3, 0);
            this.stcPeriod.Name = "stcPeriod";
            this.stcPeriod.PathString = null;
            this.stcPeriod.PathValue = "Packing Date";
            this.stcPeriod.Size = new System.Drawing.Size(139, 33);
            this.stcPeriod.TabIndex = 0;
            this.stcPeriod.Text = "Packing Date";
            this.stcPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtPeriodBegin
            // 
            this.dtPeriodBegin.AppearanceName = "";
            this.dtPeriodBegin.AppearanceReadOnlyName = "";
            this.dtPeriodBegin.BackColor = System.Drawing.Color.Transparent;
            this.dtPeriodBegin.ControlID = "";
            this.dtPeriodBegin.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtPeriodBegin.Format = "dd/MM/yyyy";
            this.dtPeriodBegin.Location = new System.Drawing.Point(148, 3);
            this.dtPeriodBegin.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtPeriodBegin.Name = "dtPeriodBegin";
            this.dtPeriodBegin.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtPeriodBegin.NZValue")));
            this.dtPeriodBegin.PathString = null;
            this.dtPeriodBegin.PathValue = ((object)(resources.GetObject("dtPeriodBegin.PathValue")));
            this.dtPeriodBegin.ReadOnly = false;
            this.dtPeriodBegin.ShowButton = true;
            this.dtPeriodBegin.Size = new System.Drawing.Size(185, 27);
            this.dtPeriodBegin.TabIndex = 2;
            this.dtPeriodBegin.Value = null;
            // 
            // dtPeriodEnd
            // 
            this.dtPeriodEnd.AppearanceName = "";
            this.dtPeriodEnd.AppearanceReadOnlyName = "";
            this.dtPeriodEnd.BackColor = System.Drawing.Color.Transparent;
            this.dtPeriodEnd.ControlID = "";
            this.dtPeriodEnd.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtPeriodEnd.Format = "dd/MM/yyyy";
            this.dtPeriodEnd.Location = new System.Drawing.Point(360, 3);
            this.dtPeriodEnd.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtPeriodEnd.Name = "dtPeriodEnd";
            this.dtPeriodEnd.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtPeriodEnd.NZValue")));
            this.dtPeriodEnd.PathString = null;
            this.dtPeriodEnd.PathValue = ((object)(resources.GetObject("dtPeriodEnd.PathValue")));
            this.dtPeriodEnd.ReadOnly = false;
            this.dtPeriodEnd.ShowButton = true;
            this.dtPeriodEnd.Size = new System.Drawing.Size(185, 27);
            this.dtPeriodEnd.TabIndex = 3;
            this.dtPeriodEnd.Value = null;
            // 
            // fpPackingList
            // 
            this.fpPackingList.About = "2.5.2015.2005";
            this.fpPackingList.AccessibleDescription = "fpPackingList, Sheet1, Row 0, Column 0, ";
            this.fpPackingList.BackColor = System.Drawing.Color.AliceBlue;
            this.tableContainer.SetColumnSpan(this.fpPackingList, 2);
            this.fpPackingList.ContextMenuStrip = this.ctxMenu;
            this.fpPackingList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpPackingList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpPackingList.Location = new System.Drawing.Point(3, 71);
            this.fpPackingList.Name = "fpPackingList";
            this.fpPackingList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpPackingList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpPackingList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtPackingList});
            this.fpPackingList.Size = new System.Drawing.Size(886, 253);
            this.fpPackingList.TabIndex = 2;
            this.fpPackingList.TabStop = false;
            this.fpPackingList.TextTipDelay = 1000;
            this.fpPackingList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpPackingList.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpView_CellDoubleClick);
            this.fpPackingList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpPackingList_KeyDown);
            this.fpPackingList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fpView_KeyPress);
            this.fpPackingList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fpView_MouseDown);
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
            // shtPackingList
            // 
            this.shtPackingList.Reset();
            this.shtPackingList.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtPackingList.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtPackingList.ColumnCount = 18;
            this.shtPackingList.RowCount = 0;
            this.shtPackingList.AutoGenerateColumns = false;
            this.shtPackingList.ColumnHeader.Cells.Get(0, 0).Value = "Trans ID";
            this.shtPackingList.ColumnHeader.Cells.Get(0, 1).Value = "Group Trans ID";
            this.shtPackingList.ColumnHeader.Cells.Get(0, 2).Value = "Packing Date";
            this.shtPackingList.ColumnHeader.Cells.Get(0, 3).Value = "Type";
            this.shtPackingList.ColumnHeader.Cells.Get(0, 4).Value = "M/N";
            this.shtPackingList.ColumnHeader.Cells.Get(0, 5).Value = "Part No.";
            this.shtPackingList.ColumnHeader.Cells.Get(0, 6).Value = "Customer Name";
            this.shtPackingList.ColumnHeader.Cells.Get(0, 7).Value = "Shift";
            this.shtPackingList.ColumnHeader.Cells.Get(0, 8).Value = "Shift Name";
            this.shtPackingList.ColumnHeader.Cells.Get(0, 9).Value = "Transaction No.";
            this.shtPackingList.ColumnHeader.Cells.Get(0, 10).Value = "Person In Charge";
            this.shtPackingList.ColumnHeader.Cells.Get(0, 11).Value = "Person In Charge Name";
            this.shtPackingList.ColumnHeader.Cells.Get(0, 12).Value = "Pack No.";
            this.shtPackingList.ColumnHeader.Cells.Get(0, 13).Value = "FG No.";
            this.shtPackingList.ColumnHeader.Cells.Get(0, 14).Value = "Lot No.";
            this.shtPackingList.ColumnHeader.Cells.Get(0, 15).Value = "Customer Lot No.";
            this.shtPackingList.ColumnHeader.Cells.Get(0, 16).Value = "Qty";
            this.shtPackingList.ColumnHeader.Cells.Get(0, 17).Value = "Remark";
            this.shtPackingList.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtPackingList.Columns.Get(1).Label = "Group Trans ID";
            this.shtPackingList.Columns.Get(1).Width = 70F;
            this.shtPackingList.Columns.Get(2).AllowAutoFilter = true;
            this.shtPackingList.Columns.Get(2).AllowAutoSort = true;
            this.shtPackingList.Columns.Get(2).Label = "Packing Date";
            this.shtPackingList.Columns.Get(2).Locked = true;
            this.shtPackingList.Columns.Get(2).Tag = "Packing Date";
            this.shtPackingList.Columns.Get(2).Width = 130F;
            this.shtPackingList.Columns.Get(3).AllowAutoFilter = true;
            this.shtPackingList.Columns.Get(3).AllowAutoSort = true;
            this.shtPackingList.Columns.Get(3).Label = "Type";
            this.shtPackingList.Columns.Get(3).Tag = "Type";
            this.shtPackingList.Columns.Get(3).Width = 100F;
            this.shtPackingList.Columns.Get(4).AllowAutoFilter = true;
            this.shtPackingList.Columns.Get(4).AllowAutoSort = true;
            this.shtPackingList.Columns.Get(4).Label = "M/N";
            this.shtPackingList.Columns.Get(4).Tag = "Master No.";
            this.shtPackingList.Columns.Get(4).Width = 90F;
            this.shtPackingList.Columns.Get(5).AllowAutoFilter = true;
            this.shtPackingList.Columns.Get(5).AllowAutoSort = true;
            this.shtPackingList.Columns.Get(5).Label = "Part No.";
            this.shtPackingList.Columns.Get(5).Tag = "Part No";
            this.shtPackingList.Columns.Get(5).Width = 139F;
            this.shtPackingList.Columns.Get(6).AllowAutoFilter = true;
            this.shtPackingList.Columns.Get(6).AllowAutoSort = true;
            this.shtPackingList.Columns.Get(6).Label = "Customer Name";
            this.shtPackingList.Columns.Get(6).Locked = true;
            this.shtPackingList.Columns.Get(6).Tag = "Customer Name";
            this.shtPackingList.Columns.Get(6).Width = 140F;
            this.shtPackingList.Columns.Get(7).AllowAutoFilter = true;
            this.shtPackingList.Columns.Get(7).AllowAutoSort = true;
            this.shtPackingList.Columns.Get(7).Label = "Shift";
            this.shtPackingList.Columns.Get(7).Tag = "Shift";
            this.shtPackingList.Columns.Get(7).Width = 90F;
            this.shtPackingList.Columns.Get(8).AllowAutoFilter = true;
            this.shtPackingList.Columns.Get(8).AllowAutoSort = true;
            this.shtPackingList.Columns.Get(8).Label = "Shift Name";
            this.shtPackingList.Columns.Get(8).Width = 165F;
            this.shtPackingList.Columns.Get(9).AllowAutoFilter = true;
            this.shtPackingList.Columns.Get(9).AllowAutoSort = true;
            this.shtPackingList.Columns.Get(9).Label = "Transaction No.";
            this.shtPackingList.Columns.Get(9).Tag = "Transaction No.";
            this.shtPackingList.Columns.Get(9).Width = 165F;
            this.shtPackingList.Columns.Get(10).AllowAutoFilter = true;
            this.shtPackingList.Columns.Get(10).AllowAutoSort = true;
            this.shtPackingList.Columns.Get(10).Label = "Person In Charge";
            this.shtPackingList.Columns.Get(10).Tag = "Person In Charge";
            this.shtPackingList.Columns.Get(10).Width = 120F;
            this.shtPackingList.Columns.Get(11).AllowAutoFilter = true;
            this.shtPackingList.Columns.Get(11).AllowAutoSort = true;
            this.shtPackingList.Columns.Get(11).Label = "Person In Charge Name";
            this.shtPackingList.Columns.Get(11).Width = 160F;
            this.shtPackingList.Columns.Get(12).AllowAutoFilter = true;
            this.shtPackingList.Columns.Get(12).AllowAutoSort = true;
            this.shtPackingList.Columns.Get(12).Label = "Pack No.";
            this.shtPackingList.Columns.Get(12).Tag = "Pack No.";
            this.shtPackingList.Columns.Get(12).Width = 100F;
            this.shtPackingList.Columns.Get(13).AllowAutoFilter = true;
            this.shtPackingList.Columns.Get(13).AllowAutoSort = true;
            this.shtPackingList.Columns.Get(13).Label = "FG No.";
            this.shtPackingList.Columns.Get(13).Tag = "FG No.";
            this.shtPackingList.Columns.Get(13).Width = 139F;
            this.shtPackingList.Columns.Get(14).AllowAutoFilter = true;
            this.shtPackingList.Columns.Get(14).AllowAutoSort = true;
            this.shtPackingList.Columns.Get(14).Label = "Lot No.";
            this.shtPackingList.Columns.Get(14).Tag = "Lot No.";
            this.shtPackingList.Columns.Get(14).Width = 101F;
            this.shtPackingList.Columns.Get(15).AllowAutoFilter = true;
            this.shtPackingList.Columns.Get(15).AllowAutoSort = true;
            this.shtPackingList.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.shtPackingList.Columns.Get(15).Label = "Customer Lot No.";
            this.shtPackingList.Columns.Get(15).Tag = "Customer Lot No.";
            this.shtPackingList.Columns.Get(15).Width = 120F;
            this.shtPackingList.Columns.Get(16).AllowAutoFilter = true;
            this.shtPackingList.Columns.Get(16).AllowAutoSort = true;
            this.shtPackingList.Columns.Get(16).Label = "Qty";
            this.shtPackingList.Columns.Get(16).Tag = "Qty";
            this.shtPackingList.Columns.Get(16).Width = 100F;
            this.shtPackingList.Columns.Get(17).AllowAutoFilter = true;
            this.shtPackingList.Columns.Get(17).AllowAutoSort = true;
            this.shtPackingList.Columns.Get(17).Label = "Remark";
            this.shtPackingList.Columns.Get(17).Tag = "Remark";
            this.shtPackingList.Columns.Get(17).Width = 100F;
            this.shtPackingList.DataAutoCellTypes = false;
            this.shtPackingList.DataAutoHeadings = false;
            this.shtPackingList.DataAutoSizeColumns = false;
            this.shtPackingList.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.shtPackingList.RowHeader.Columns.Default.Resizable = true;
            this.shtPackingList.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.shtPackingList.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.shtPackingList.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpPackingList.SetActiveViewport(0, 1, 0);
            // 
            // panSearch
            // 
            this.panSearch.AppearanceName = "";
            this.tableContainer.SetColumnSpan(this.panSearch, 2);
            this.panSearch.Controls.Add(this.tblSearch);
            this.panSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panSearch.Location = new System.Drawing.Point(0, 33);
            this.panSearch.Margin = new System.Windows.Forms.Padding(0);
            this.panSearch.Name = "panSearch";
            this.panSearch.Size = new System.Drawing.Size(892, 35);
            this.panSearch.TabIndex = 3;
            // 
            // tblSearch
            // 
            this.tblSearch.ColumnCount = 3;
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblSearch.Controls.Add(this.pictureBox1, 1, 0);
            this.tblSearch.Controls.Add(this.txtSearch, 2, 0);
            this.tblSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblSearch.Location = new System.Drawing.Point(0, 0);
            this.tblSearch.Margin = new System.Windows.Forms.Padding(0);
            this.tblSearch.Name = "tblSearch";
            this.tblSearch.RowCount = 1;
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSearch.Size = new System.Drawing.Size(892, 33);
            this.tblSearch.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Rubik.Forms.Properties.Resources.FIND_TEXT;
            this.pictureBox1.Location = new System.Drawing.Point(20, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.AppearanceName = "";
            this.txtSearch.AppearanceReadOnlyName = "";
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.ControlID = "";
            this.txtSearch.DisableRestrictChar = true;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.HelpButton = null;
            this.txtSearch.Location = new System.Drawing.Point(58, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PathString = null;
            this.txtSearch.PathValue = "";
            this.txtSearch.Size = new System.Drawing.Size(831, 26);
            this.txtSearch.TabIndex = 7;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // TRN310_PackingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(892, 352);
            this.ExportObject = this.fpPackingList;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TRN310_PackingList";
            this.Text = "Packing List";
            this.Load += new System.EventHandler(this.TRN010_Load);
            this.Shown += new System.EventHandler(this.TRN010_Shown);
            this.Controls.SetChildIndex(this.pnlContainer, 0);
            this.pnlContainer.ResumeLayout(false);
            this.tableContainer.ResumeLayout(false);
            this.tableContainer.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tableSearch.ResumeLayout(false);
            this.tableSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpPackingList)).EndInit();
            this.ctxMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shtPackingList)).EndInit();
            this.panSearch.ResumeLayout(false);
            this.tblSearch.ResumeLayout(false);
            this.tblSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableContainer;
        private EVOFramework.Windows.Forms.EVOPanel pnlHeader;
        private EVOFramework.Windows.Forms.EVOLabel stcHead;
        private FarPoint.Win.Spread.FpSpread fpPackingList;
        private FarPoint.Win.Spread.SheetView shtPackingList;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem miEdit;
        private System.Windows.Forms.ToolStripMenuItem miDelete;
        private System.Windows.Forms.TableLayoutPanel tableSearch;
        private EVOFramework.Windows.Forms.EVOLabel stcDash;
        private EVOFramework.Windows.Forms.EVOLabel stcPeriod;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtPeriodBegin;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtPeriodEnd;
        private EVOFramework.Windows.Forms.EVOPanel panSearch;
        private System.Windows.Forms.TableLayoutPanel tblSearch;
        private System.Windows.Forms.PictureBox pictureBox1;
        private EVOFramework.Windows.Forms.EVOTextBox txtSearch;
        private System.Windows.Forms.ToolStripMenuItem miDeleteGroup;
    }
}
