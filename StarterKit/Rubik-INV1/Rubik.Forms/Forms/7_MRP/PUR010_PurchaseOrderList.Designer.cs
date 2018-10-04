namespace Rubik.MRP
{
    partial class PUR010_PurchaseOrderList
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
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType3 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PUR010_PurchaseOrderList));
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType3 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType4 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType4 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            this.tableContainer = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeader = new EVOFramework.Windows.Forms.EVOPanel();
            this.stcHead = new EVOFramework.Windows.Forms.EVOLabel();
            this.tableSearch = new System.Windows.Forms.TableLayoutPanel();
            this.stcDash = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcPeriod = new EVOFramework.Windows.Forms.EVOLabel();
            this.dtPeriodBegin = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.dtPeriodEnd = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.chkIncludeCancel = new EVOFramework.Windows.Forms.EVOCheckBox();
            this.fpView = new FarPoint.Win.Spread.FpSpread();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.shtView = new FarPoint.Win.Spread.SheetView();
            this.panSearch = new EVOFramework.Windows.Forms.EVOPanel();
            this.tblSearch = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtSearch = new EVOFramework.Windows.Forms.EVOTextBox();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.pnlContainer.SuspendLayout();
            this.tableContainer.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.tableSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).BeginInit();
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
            this.pnlContainer.Size = new System.Drawing.Size(1098, 305);
            // 
            // tableContainer
            // 
            this.tableContainer.ColumnCount = 2;
            this.tableContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 548F));
            this.tableContainer.Controls.Add(this.pnlHeader, 0, 0);
            this.tableContainer.Controls.Add(this.tableSearch, 1, 0);
            this.tableContainer.Controls.Add(this.fpView, 0, 2);
            this.tableContainer.Controls.Add(this.panSearch, 0, 1);
            this.tableContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableContainer.Location = new System.Drawing.Point(0, 0);
            this.tableContainer.Name = "tableContainer";
            this.tableContainer.RowCount = 3;
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableContainer.Size = new System.Drawing.Size(1098, 305);
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
            this.pnlHeader.Size = new System.Drawing.Size(550, 33);
            this.pnlHeader.TabIndex = 1;
            // 
            // stcHead
            // 
            this.stcHead.AccessibleName = "";
            this.stcHead.AppearanceName = "Title";
            this.stcHead.AutoSize = true;
            this.stcHead.ControlID = "";
            this.stcHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.stcHead.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.stcHead.Location = new System.Drawing.Point(0, 0);
            this.stcHead.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.stcHead.Name = "stcHead";
            this.stcHead.Padding = new System.Windows.Forms.Padding(3);
            this.stcHead.PathString = null;
            this.stcHead.PathValue = "Purchase Order List";
            this.stcHead.Size = new System.Drawing.Size(153, 25);
            this.stcHead.TabIndex = 0;
            this.stcHead.Text = "Purchase Order List";
            // 
            // tableSearch
            // 
            this.tableSearch.AutoSize = true;
            this.tableSearch.ColumnCount = 5;
            this.tableSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableSearch.Controls.Add(this.stcDash, 3, 0);
            this.tableSearch.Controls.Add(this.stcPeriod, 1, 0);
            this.tableSearch.Controls.Add(this.dtPeriodBegin, 2, 0);
            this.tableSearch.Controls.Add(this.dtPeriodEnd, 4, 0);
            this.tableSearch.Controls.Add(this.chkIncludeCancel, 0, 0);
            this.tableSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableSearch.Location = new System.Drawing.Point(550, 0);
            this.tableSearch.Margin = new System.Windows.Forms.Padding(0);
            this.tableSearch.Name = "tableSearch";
            this.tableSearch.RowCount = 1;
            this.tableSearch.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableSearch.Size = new System.Drawing.Size(548, 33);
            this.tableSearch.TabIndex = 3;
            // 
            // stcDash
            // 
            this.stcDash.AppearanceName = "";
            this.stcDash.AutoSize = true;
            this.stcDash.ControlID = "";
            this.stcDash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stcDash.Location = new System.Drawing.Point(396, 0);
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
            this.stcPeriod.Location = new System.Drawing.Point(163, 0);
            this.stcPeriod.Name = "stcPeriod";
            this.stcPeriod.PathString = null;
            this.stcPeriod.PathValue = "PO Date";
            this.stcPeriod.Size = new System.Drawing.Size(94, 33);
            this.stcPeriod.TabIndex = 0;
            this.stcPeriod.Text = "PO Date";
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
            this.dtPeriodBegin.Location = new System.Drawing.Point(263, 3);
            this.dtPeriodBegin.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtPeriodBegin.Name = "dtPeriodBegin";
            this.dtPeriodBegin.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtPeriodBegin.NZValue")));
            this.dtPeriodBegin.PathString = null;
            this.dtPeriodBegin.PathValue = ((object)(resources.GetObject("dtPeriodBegin.PathValue")));
            this.dtPeriodBegin.ReadOnly = false;
            this.dtPeriodBegin.ShowButton = true;
            this.dtPeriodBegin.Size = new System.Drawing.Size(127, 27);
            this.dtPeriodBegin.TabIndex = 3;
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
            this.dtPeriodEnd.Location = new System.Drawing.Point(417, 3);
            this.dtPeriodEnd.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtPeriodEnd.Name = "dtPeriodEnd";
            this.dtPeriodEnd.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtPeriodEnd.NZValue")));
            this.dtPeriodEnd.PathString = null;
            this.dtPeriodEnd.PathValue = ((object)(resources.GetObject("dtPeriodEnd.PathValue")));
            this.dtPeriodEnd.ReadOnly = false;
            this.dtPeriodEnd.ShowButton = true;
            this.dtPeriodEnd.Size = new System.Drawing.Size(128, 27);
            this.dtPeriodEnd.TabIndex = 2;
            this.dtPeriodEnd.Value = null;
            // 
            // chkIncludeCancel
            // 
            this.chkIncludeCancel.AppearanceName = "";
            this.chkIncludeCancel.AutoSize = true;
            this.chkIncludeCancel.CheckedValue = null;
            this.chkIncludeCancel.ControlID = null;
            this.chkIncludeCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkIncludeCancel.Location = new System.Drawing.Point(3, 3);
            this.chkIncludeCancel.Name = "chkIncludeCancel";
            this.chkIncludeCancel.PathString = null;
            this.chkIncludeCancel.PathValue = false;
            this.chkIncludeCancel.Size = new System.Drawing.Size(154, 27);
            this.chkIncludeCancel.TabIndex = 4;
            this.chkIncludeCancel.Text = "Include cancel PO";
            this.chkIncludeCancel.UnCheckedValue = null;
            this.chkIncludeCancel.UseVisualStyleBackColor = true;
            // 
            // fpView
            // 
            this.fpView.About = "2.5.2015.2005";
            this.fpView.AccessibleDescription = "fpView, Sheet1";
            this.fpView.BackColor = System.Drawing.Color.AliceBlue;
            this.tableContainer.SetColumnSpan(this.fpView, 2);
            this.fpView.ContextMenuStrip = this.ctxMenu;
            this.fpView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.Location = new System.Drawing.Point(3, 71);
            this.fpView.Name = "fpView";
            this.fpView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtView});
            this.fpView.Size = new System.Drawing.Size(1092, 235);
            this.fpView.TabIndex = 3;
            this.fpView.TabStop = false;
            this.fpView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.EnterCell += new FarPoint.Win.Spread.EnterCellEventHandler(this.fpView_EnterCell);
            this.fpView.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpView_CellDoubleClick);
            this.fpView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpView_KeyDown);
            // 
            // ctxMenu
            // 
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // shtView
            // 
            this.shtView.Reset();
            this.shtView.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtView.ColumnCount = 30;
            this.shtView.RowCount = 0;
            this.shtView.AutoGenerateColumns = false;
            this.shtView.ColumnHeader.Cells.Get(0, 0).Value = "PO Line";
            this.shtView.ColumnHeader.Cells.Get(0, 1).Value = "CRT_BY";
            this.shtView.ColumnHeader.Cells.Get(0, 2).Value = "CRT_Date";
            this.shtView.ColumnHeader.Cells.Get(0, 3).Value = "CRT_Machine";
            this.shtView.ColumnHeader.Cells.Get(0, 4).Value = "UPD_BY";
            this.shtView.ColumnHeader.Cells.Get(0, 5).Value = "UPD_DATE";
            this.shtView.ColumnHeader.Cells.Get(0, 6).Value = "UPD_MACHINE";
            this.shtView.ColumnHeader.Cells.Get(0, 7).Value = "PO No.";
            this.shtView.ColumnHeader.Cells.Get(0, 8).Value = "PO Type";
            this.shtView.ColumnHeader.Cells.Get(0, 9).Value = "PO Date";
            this.shtView.ColumnHeader.Cells.Get(0, 10).Value = "Supplier Code";
            this.shtView.ColumnHeader.Cells.Get(0, 11).Value = "Supplier Name";
            this.shtView.ColumnHeader.Cells.Get(0, 12).Value = "Address";
            this.shtView.ColumnHeader.Cells.Get(0, 13).Value = "Delivery To";
            this.shtView.ColumnHeader.Cells.Get(0, 14).Value = "Currency";
            this.shtView.ColumnHeader.Cells.Get(0, 15).Value = "Vat Type";
            this.shtView.ColumnHeader.Cells.Get(0, 16).Value = "Vat Rate";
            this.shtView.ColumnHeader.Cells.Get(0, 17).Value = "Term of Payment";
            this.shtView.ColumnHeader.Cells.Get(0, 18).Value = "Is Export";
            this.shtView.ColumnHeader.Cells.Get(0, 19).Value = "Remark";
            this.shtView.ColumnHeader.Cells.Get(0, 20).Value = "Part Code";
            this.shtView.ColumnHeader.Cells.Get(0, 21).Value = "Part Desc.";
            this.shtView.ColumnHeader.Cells.Get(0, 22).Value = "Due Date";
            this.shtView.ColumnHeader.Cells.Get(0, 23).Value = "Unit Price";
            this.shtView.ColumnHeader.Cells.Get(0, 24).Value = "PO Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 25).Value = "Unit";
            this.shtView.ColumnHeader.Cells.Get(0, 26).Value = "Amount";
            this.shtView.ColumnHeader.Cells.Get(0, 27).Value = "Receive Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 28).Value = "Status";
            this.shtView.ColumnHeader.Cells.Get(0, 29).Value = "Active";
            this.shtView.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtView.Columns.Get(0).AllowAutoFilter = true;
            this.shtView.Columns.Get(0).AllowAutoSort = true;
            this.shtView.Columns.Get(0).Label = "PO Line";
            this.shtView.Columns.Get(0).Locked = true;
            this.shtView.Columns.Get(0).Tag = "PO Line";
            this.shtView.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.shtView.Columns.Get(0).Width = 105F;
            this.shtView.Columns.Get(1).AllowAutoFilter = true;
            this.shtView.Columns.Get(1).AllowAutoSort = true;
            this.shtView.Columns.Get(1).Label = "CRT_BY";
            this.shtView.Columns.Get(1).Locked = true;
            this.shtView.Columns.Get(1).Tag = "CRT_BY";
            this.shtView.Columns.Get(1).Width = 110F;
            this.shtView.Columns.Get(2).AllowAutoFilter = true;
            this.shtView.Columns.Get(2).AllowAutoSort = true;
            this.shtView.Columns.Get(2).Label = "CRT_Date";
            this.shtView.Columns.Get(2).Locked = true;
            this.shtView.Columns.Get(2).Tag = "CRT_Date";
            this.shtView.Columns.Get(2).Width = 130F;
            this.shtView.Columns.Get(3).AllowAutoFilter = true;
            this.shtView.Columns.Get(3).AllowAutoSort = true;
            this.shtView.Columns.Get(3).Label = "CRT_Machine";
            this.shtView.Columns.Get(3).Locked = true;
            this.shtView.Columns.Get(3).Tag = "CRT_Machine";
            this.shtView.Columns.Get(3).Width = 142F;
            this.shtView.Columns.Get(4).AllowAutoFilter = true;
            this.shtView.Columns.Get(4).AllowAutoSort = true;
            this.shtView.Columns.Get(4).Label = "UPD_BY";
            this.shtView.Columns.Get(4).Tag = "UPD_BY";
            this.shtView.Columns.Get(4).Width = 108F;
            this.shtView.Columns.Get(5).AllowAutoFilter = true;
            this.shtView.Columns.Get(5).AllowAutoSort = true;
            this.shtView.Columns.Get(5).Label = "UPD_DATE";
            this.shtView.Columns.Get(5).Locked = true;
            this.shtView.Columns.Get(5).Tag = "UPD_DATE";
            this.shtView.Columns.Get(5).Width = 134F;
            this.shtView.Columns.Get(6).AllowAutoFilter = true;
            this.shtView.Columns.Get(6).AllowAutoSort = true;
            this.shtView.Columns.Get(6).Label = "UPD_MACHINE";
            this.shtView.Columns.Get(6).Locked = true;
            this.shtView.Columns.Get(6).Tag = "UPD_MACHINE";
            this.shtView.Columns.Get(6).Width = 157F;
            this.shtView.Columns.Get(7).AllowAutoFilter = true;
            this.shtView.Columns.Get(7).AllowAutoSort = true;
            this.shtView.Columns.Get(7).Label = "PO No.";
            this.shtView.Columns.Get(7).Locked = true;
            this.shtView.Columns.Get(7).Tag = "PO No.";
            this.shtView.Columns.Get(7).Width = 124F;
            this.shtView.Columns.Get(8).AllowAutoFilter = true;
            this.shtView.Columns.Get(8).AllowAutoSort = true;
            this.shtView.Columns.Get(8).Label = "PO Type";
            this.shtView.Columns.Get(8).Tag = "PO Type";
            this.shtView.Columns.Get(8).Width = 120F;
            this.shtView.Columns.Get(9).AllowAutoFilter = true;
            this.shtView.Columns.Get(9).AllowAutoSort = true;
            dateTimeCellType3.Calendar = ((System.Globalization.Calendar)(resources.GetObject("dateTimeCellType3.Calendar")));
            dateTimeCellType3.DateDefault = new System.DateTime(2011, 6, 9, 9, 10, 0, 0);
            dateTimeCellType3.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
            dateTimeCellType3.TimeDefault = new System.DateTime(2011, 6, 9, 9, 10, 0, 0);
            dateTimeCellType3.TwoDigitYearMax = 2029;
            dateTimeCellType3.UserDefinedFormat = "dd/MM/yyyy";
            this.shtView.Columns.Get(9).CellType = dateTimeCellType3;
            this.shtView.Columns.Get(9).Label = "PO Date";
            this.shtView.Columns.Get(9).Tag = "PO Date";
            this.shtView.Columns.Get(9).Width = 106F;
            this.shtView.Columns.Get(10).AllowAutoFilter = true;
            this.shtView.Columns.Get(10).AllowAutoSort = true;
            this.shtView.Columns.Get(10).Label = "Supplier Code";
            this.shtView.Columns.Get(10).Locked = true;
            this.shtView.Columns.Get(10).Tag = "Supplier Code";
            this.shtView.Columns.Get(10).Width = 142F;
            this.shtView.Columns.Get(11).AllowAutoFilter = true;
            this.shtView.Columns.Get(11).AllowAutoSort = true;
            this.shtView.Columns.Get(11).Label = "Supplier Name";
            this.shtView.Columns.Get(11).Locked = true;
            this.shtView.Columns.Get(11).Tag = "Supplier Name";
            this.shtView.Columns.Get(11).Width = 155F;
            this.shtView.Columns.Get(12).AllowAutoFilter = true;
            this.shtView.Columns.Get(12).AllowAutoSort = true;
            this.shtView.Columns.Get(12).Label = "Address";
            this.shtView.Columns.Get(12).Locked = true;
            this.shtView.Columns.Get(12).Tag = "Address";
            this.shtView.Columns.Get(12).Width = 118F;
            this.shtView.Columns.Get(13).AllowAutoFilter = true;
            this.shtView.Columns.Get(13).AllowAutoSort = true;
            this.shtView.Columns.Get(13).Label = "Delivery To";
            this.shtView.Columns.Get(13).Locked = true;
            this.shtView.Columns.Get(13).Tag = "Delivery To";
            this.shtView.Columns.Get(13).Width = 138F;
            this.shtView.Columns.Get(14).AllowAutoFilter = true;
            this.shtView.Columns.Get(14).AllowAutoSort = true;
            this.shtView.Columns.Get(14).Label = "Currency";
            this.shtView.Columns.Get(14).Locked = true;
            this.shtView.Columns.Get(14).Tag = "Currency";
            this.shtView.Columns.Get(14).Width = 141F;
            this.shtView.Columns.Get(15).AllowAutoFilter = true;
            this.shtView.Columns.Get(15).AllowAutoSort = true;
            this.shtView.Columns.Get(15).Label = "Vat Type";
            this.shtView.Columns.Get(15).Locked = true;
            this.shtView.Columns.Get(15).Tag = "Vat Type";
            this.shtView.Columns.Get(15).Width = 93F;
            this.shtView.Columns.Get(16).AllowAutoFilter = true;
            this.shtView.Columns.Get(16).AllowAutoSort = true;
            this.shtView.Columns.Get(16).Label = "Vat Rate";
            this.shtView.Columns.Get(16).Locked = true;
            this.shtView.Columns.Get(16).Tag = "Vat Rate";
            this.shtView.Columns.Get(16).Width = 95F;
            this.shtView.Columns.Get(17).AllowAutoFilter = true;
            this.shtView.Columns.Get(17).AllowAutoSort = true;
            this.shtView.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.shtView.Columns.Get(17).Label = "Term of Payment";
            this.shtView.Columns.Get(17).Locked = true;
            this.shtView.Columns.Get(17).Tag = "Term of Payment";
            this.shtView.Columns.Get(17).Width = 166F;
            this.shtView.Columns.Get(18).AllowAutoFilter = true;
            this.shtView.Columns.Get(18).AllowAutoSort = true;
            this.shtView.Columns.Get(18).CellType = checkBoxCellType3;
            this.shtView.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.shtView.Columns.Get(18).Label = "Is Export";
            this.shtView.Columns.Get(18).Tag = "Is Export";
            this.shtView.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.shtView.Columns.Get(18).Width = 126F;
            this.shtView.Columns.Get(19).AllowAutoFilter = true;
            this.shtView.Columns.Get(19).AllowAutoSort = true;
            this.shtView.Columns.Get(19).Label = "Remark";
            this.shtView.Columns.Get(19).Tag = "Remark";
            this.shtView.Columns.Get(19).Width = 111F;
            this.shtView.Columns.Get(20).AllowAutoFilter = true;
            this.shtView.Columns.Get(20).AllowAutoSort = true;
            this.shtView.Columns.Get(20).Label = "Part Code";
            this.shtView.Columns.Get(20).Tag = "Part Code";
            this.shtView.Columns.Get(20).Width = 189F;
            this.shtView.Columns.Get(21).AllowAutoFilter = true;
            this.shtView.Columns.Get(21).AllowAutoSort = true;
            this.shtView.Columns.Get(21).Label = "Part Desc.";
            this.shtView.Columns.Get(21).Tag = "Part Desc.";
            this.shtView.Columns.Get(21).Width = 230F;
            this.shtView.Columns.Get(22).AllowAutoFilter = true;
            this.shtView.Columns.Get(22).AllowAutoSort = true;
            dateTimeCellType4.Calendar = ((System.Globalization.Calendar)(resources.GetObject("dateTimeCellType4.Calendar")));
            dateTimeCellType4.DateDefault = new System.DateTime(2011, 6, 9, 9, 15, 12, 0);
            dateTimeCellType4.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
            dateTimeCellType4.TimeDefault = new System.DateTime(2011, 6, 9, 9, 15, 12, 0);
            dateTimeCellType4.TwoDigitYearMax = 2029;
            dateTimeCellType4.UserDefinedFormat = "dd/MM/yyyy";
            this.shtView.Columns.Get(22).CellType = dateTimeCellType4;
            this.shtView.Columns.Get(22).Label = "Due Date";
            this.shtView.Columns.Get(22).Tag = "Due Date";
            this.shtView.Columns.Get(22).Width = 132F;
            this.shtView.Columns.Get(23).AllowAutoFilter = true;
            this.shtView.Columns.Get(23).AllowAutoSort = true;
            this.shtView.Columns.Get(23).Label = "Unit Price";
            this.shtView.Columns.Get(23).Tag = "Unit Price";
            this.shtView.Columns.Get(23).Width = 116F;
            this.shtView.Columns.Get(24).AllowAutoFilter = true;
            this.shtView.Columns.Get(24).AllowAutoSort = true;
            this.shtView.Columns.Get(24).Label = "PO Qty";
            this.shtView.Columns.Get(24).Tag = "PO Qty";
            this.shtView.Columns.Get(24).Width = 108F;
            this.shtView.Columns.Get(25).AllowAutoFilter = true;
            this.shtView.Columns.Get(25).AllowAutoSort = true;
            this.shtView.Columns.Get(25).Label = "Unit";
            this.shtView.Columns.Get(25).Tag = "Unit";
            this.shtView.Columns.Get(25).Width = 101F;
            this.shtView.Columns.Get(26).AllowAutoFilter = true;
            this.shtView.Columns.Get(26).AllowAutoSort = true;
            this.shtView.Columns.Get(26).Label = "Amount";
            this.shtView.Columns.Get(26).Tag = "Amount";
            this.shtView.Columns.Get(26).Width = 112F;
            this.shtView.Columns.Get(27).AllowAutoFilter = true;
            this.shtView.Columns.Get(27).AllowAutoSort = true;
            this.shtView.Columns.Get(27).Label = "Receive Qty";
            this.shtView.Columns.Get(27).Tag = "Receive Qty";
            this.shtView.Columns.Get(27).Width = 136F;
            this.shtView.Columns.Get(28).AllowAutoFilter = true;
            this.shtView.Columns.Get(28).AllowAutoSort = true;
            this.shtView.Columns.Get(28).Label = "Status";
            this.shtView.Columns.Get(28).Tag = "Status";
            this.shtView.Columns.Get(28).Width = 118F;
            this.shtView.Columns.Get(29).AllowAutoFilter = true;
            this.shtView.Columns.Get(29).AllowAutoSort = true;
            this.shtView.Columns.Get(29).CellType = checkBoxCellType4;
            this.shtView.Columns.Get(29).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.shtView.Columns.Get(29).Label = "Active";
            this.shtView.Columns.Get(29).Tag = "Active";
            this.shtView.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.shtView.Columns.Get(29).Width = 126F;
            this.shtView.DataAutoCellTypes = false;
            this.shtView.DataAutoHeadings = false;
            this.shtView.DataAutoSizeColumns = false;
            this.shtView.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.shtView.RowHeader.Columns.Default.Resizable = true;
            this.shtView.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.shtView.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpView.SetActiveViewport(0, 1, 0);
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
            this.panSearch.Size = new System.Drawing.Size(1098, 35);
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
            this.tblSearch.Size = new System.Drawing.Size(1098, 33);
            this.tblSearch.TabIndex = 0;
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
            this.txtSearch.Size = new System.Drawing.Size(1037, 26);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TabStop = false;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 330);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1098, 22);
            this.statusBar.TabIndex = 5;
            this.statusBar.Text = "statusStrip1";
            // 
            // PUR010_PurchaseOrderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1098, 352);
            this.Controls.Add(this.statusBar);
            this.ExportObject = this.fpView;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PUR010_PurchaseOrderList";
            this.Text = "Receiving List";
            this.Load += new System.EventHandler(this.PUR010_Load);
            this.Controls.SetChildIndex(this.statusBar, 0);
            this.Controls.SetChildIndex(this.pnlContainer, 0);
            this.pnlContainer.ResumeLayout(false);
            this.tableContainer.ResumeLayout(false);
            this.tableContainer.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tableSearch.ResumeLayout(false);
            this.tableSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).EndInit();
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
        private FarPoint.Win.Spread.FpSpread fpView;
        private FarPoint.Win.Spread.SheetView shtView;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.TableLayoutPanel tableSearch;
        private EVOFramework.Windows.Forms.EVOLabel stcDash;
        private EVOFramework.Windows.Forms.EVOLabel stcPeriod;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtPeriodBegin;
        private EVOFramework.Windows.Forms.EVOPanel panSearch;
        private System.Windows.Forms.TableLayoutPanel tblSearch;
        private EVOFramework.Windows.Forms.EVOTextBox txtSearch;
        private System.Windows.Forms.PictureBox pictureBox1;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtPeriodEnd;
        private EVOFramework.Windows.Forms.EVOCheckBox chkIncludeCancel;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
    }
}
