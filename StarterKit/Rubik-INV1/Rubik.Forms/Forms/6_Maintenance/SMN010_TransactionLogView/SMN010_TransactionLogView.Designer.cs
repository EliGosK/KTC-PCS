namespace Rubik.Transaction
{
    partial class SMN010
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SMN010));
            this.fpView = new FarPoint.Win.Spread.FpSpread();
            this.shtView = new FarPoint.Win.Spread.SheetView();
            this.tableContainer = new System.Windows.Forms.TableLayoutPanel();
            this.panSearch = new EVOFramework.Windows.Forms.EVOPanel();
            this.tblSearch = new System.Windows.Forms.TableLayoutPanel();
            this.txtSearch = new EVOFramework.Windows.Forms.EVOTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblScreenType = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboScreenType = new EVOFramework.Windows.Forms.EVOComboBox();
            this.pnlHeader = new EVOFramework.Windows.Forms.EVOPanel();
            this.stcHead = new EVOFramework.Windows.Forms.EVOLabel();
            this.tableSearch = new System.Windows.Forms.TableLayoutPanel();
            this.stcDash = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcPeriod = new EVOFramework.Windows.Forms.EVOLabel();
            this.dtPeriodBegin = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.dtPeriodEnd = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).BeginInit();
            this.tableContainer.SuspendLayout();
            this.panSearch.SuspendLayout();
            this.tblSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.tableSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.tableContainer);
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlContainer.Size = new System.Drawing.Size(804, 399);
            // 
            // fpView
            // 
            this.fpView.About = "2.5.2015.2005";
            this.fpView.AccessibleDescription = "fpView, Sheet1";
            this.fpView.BackColor = System.Drawing.Color.AliceBlue;
            this.tableContainer.SetColumnSpan(this.fpView, 2);
            this.fpView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.Location = new System.Drawing.Point(3, 79);
            this.fpView.Name = "fpView";
            this.fpView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtView});
            this.fpView.Size = new System.Drawing.Size(798, 317);
            this.fpView.TabIndex = 0;
            this.fpView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpView_CellClick);
            this.fpView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpView_KeyDown);
            // 
            // shtView
            // 
            this.shtView.Reset();
            this.shtView.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtView.ColumnCount = 31;
            this.shtView.RowCount = 0;
            this.shtView.AutoGenerateColumns = false;
            this.shtView.ColumnHeader.Cells.Get(0, 0).Value = "Screen Type";
            this.shtView.ColumnHeader.Cells.Get(0, 1).Value = "Operation Type";
            this.shtView.ColumnHeader.Cells.Get(0, 2).Value = "Operation Date";
            this.shtView.ColumnHeader.Cells.Get(0, 3).Value = "Operation Machine";
            this.shtView.ColumnHeader.Cells.Get(0, 4).Value = "By User";
            this.shtView.ColumnHeader.Cells.Get(0, 5).Value = "Trans Id";
            this.shtView.ColumnHeader.Cells.Get(0, 6).Value = "Part Cd";
            this.shtView.ColumnHeader.Cells.Get(0, 7).Value = "Loc Cd";
            this.shtView.ColumnHeader.Cells.Get(0, 8).Value = "Lot No";
            this.shtView.ColumnHeader.Cells.Get(0, 9).Value = "Trans Date";
            this.shtView.ColumnHeader.Cells.Get(0, 10).Value = "Trans Cls";
            this.shtView.ColumnHeader.Cells.Get(0, 11).Value = "In/Out Cls";
            this.shtView.ColumnHeader.Cells.Get(0, 12).Value = "Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 13).Value = "Obj Item Cd";
            this.shtView.ColumnHeader.Cells.Get(0, 14).Value = "Obj Order Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 15).Value = "Ref No";
            this.shtView.ColumnHeader.Cells.Get(0, 16).Value = "Ref Slip No";
            this.shtView.ColumnHeader.Cells.Get(0, 17).Value = "Slip No";
            this.shtView.ColumnHeader.Cells.Get(0, 18).Value = "Remark";
            this.shtView.ColumnHeader.Cells.Get(0, 19).Value = "Dealing No";
            this.shtView.ColumnHeader.Cells.Get(0, 20).Value = "Supp Lot No";
            this.shtView.ColumnHeader.Cells.Get(0, 21).Value = "Price";
            this.shtView.ColumnHeader.Cells.Get(0, 22).Value = "For Customer";
            this.shtView.ColumnHeader.Cells.Get(0, 23).Value = "For Machine";
            this.shtView.ColumnHeader.Cells.Get(0, 24).Value = "Shift Cls";
            this.shtView.ColumnHeader.Cells.Get(0, 25).Value = "Ref Slip No2";
            this.shtView.ColumnHeader.Cells.Get(0, 26).Value = "Ng Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 27).Value = "Tran Sub Cls";
            this.shtView.ColumnHeader.Cells.Get(0, 28).Value = "Group Trans ID";
            this.shtView.ColumnHeader.Cells.Get(0, 29).Value = "Reserve Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 30).Value = "NG Reason";
            this.shtView.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtView.Columns.Get(0).AllowAutoFilter = true;
            this.shtView.Columns.Get(0).AllowAutoSort = true;
            this.shtView.Columns.Get(0).Label = "Screen Type";
            this.shtView.Columns.Get(0).Tag = "Screen Type";
            this.shtView.Columns.Get(0).Width = 134F;
            this.shtView.Columns.Get(1).AllowAutoFilter = true;
            this.shtView.Columns.Get(1).AllowAutoSort = true;
            this.shtView.Columns.Get(1).Label = "Operation Type";
            this.shtView.Columns.Get(1).Tag = "Operation Type";
            this.shtView.Columns.Get(1).Width = 169F;
            this.shtView.Columns.Get(2).AllowAutoFilter = true;
            this.shtView.Columns.Get(2).AllowAutoSort = true;
            this.shtView.Columns.Get(2).Label = "Operation Date";
            this.shtView.Columns.Get(2).Tag = "Operation Date";
            this.shtView.Columns.Get(2).Width = 159F;
            this.shtView.Columns.Get(3).AllowAutoFilter = true;
            this.shtView.Columns.Get(3).AllowAutoSort = true;
            this.shtView.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.shtView.Columns.Get(3).Label = "Operation Machine";
            this.shtView.Columns.Get(3).Tag = "Operation Machine";
            this.shtView.Columns.Get(3).Width = 184F;
            this.shtView.Columns.Get(4).AllowAutoFilter = true;
            this.shtView.Columns.Get(4).AllowAutoSort = true;
            this.shtView.Columns.Get(4).Label = "By User";
            this.shtView.Columns.Get(4).Tag = "By User";
            this.shtView.Columns.Get(4).Width = 134F;
            this.shtView.Columns.Get(5).AllowAutoFilter = true;
            this.shtView.Columns.Get(5).AllowAutoSort = true;
            this.shtView.Columns.Get(5).Label = "Trans Id";
            this.shtView.Columns.Get(5).Tag = "Trans Id";
            this.shtView.Columns.Get(5).Width = 134F;
            this.shtView.Columns.Get(6).AllowAutoFilter = true;
            this.shtView.Columns.Get(6).AllowAutoSort = true;
            this.shtView.Columns.Get(6).Label = "Part Cd";
            this.shtView.Columns.Get(6).Tag = "Part Cd";
            this.shtView.Columns.Get(6).Width = 134F;
            this.shtView.Columns.Get(7).AllowAutoFilter = true;
            this.shtView.Columns.Get(7).AllowAutoSort = true;
            this.shtView.Columns.Get(7).Label = "Loc Cd";
            this.shtView.Columns.Get(7).Tag = "Loc Cd";
            this.shtView.Columns.Get(7).Width = 134F;
            this.shtView.Columns.Get(8).AllowAutoFilter = true;
            this.shtView.Columns.Get(8).AllowAutoSort = true;
            this.shtView.Columns.Get(8).Label = "Lot No";
            this.shtView.Columns.Get(8).Tag = "Lot No";
            this.shtView.Columns.Get(8).Width = 134F;
            this.shtView.Columns.Get(9).AllowAutoFilter = true;
            this.shtView.Columns.Get(9).AllowAutoSort = true;
            this.shtView.Columns.Get(9).Label = "Trans Date";
            this.shtView.Columns.Get(9).Tag = "Trans Date";
            this.shtView.Columns.Get(9).Width = 134F;
            this.shtView.Columns.Get(10).AllowAutoFilter = true;
            this.shtView.Columns.Get(10).AllowAutoSort = true;
            this.shtView.Columns.Get(10).Label = "Trans Cls";
            this.shtView.Columns.Get(10).Tag = "Trans Cls";
            this.shtView.Columns.Get(10).Width = 134F;
            this.shtView.Columns.Get(11).AllowAutoFilter = true;
            this.shtView.Columns.Get(11).AllowAutoSort = true;
            this.shtView.Columns.Get(11).Label = "In/Out Cls";
            this.shtView.Columns.Get(11).Tag = "In/Out Cls";
            this.shtView.Columns.Get(11).Width = 134F;
            this.shtView.Columns.Get(12).AllowAutoFilter = true;
            this.shtView.Columns.Get(12).AllowAutoSort = true;
            this.shtView.Columns.Get(12).Label = "Qty";
            this.shtView.Columns.Get(12).Tag = "Qty";
            this.shtView.Columns.Get(12).Width = 134F;
            this.shtView.Columns.Get(13).AllowAutoFilter = true;
            this.shtView.Columns.Get(13).AllowAutoSort = true;
            this.shtView.Columns.Get(13).Label = "Obj Item Cd";
            this.shtView.Columns.Get(13).Tag = "Obj Item Cd";
            this.shtView.Columns.Get(13).Width = 134F;
            this.shtView.Columns.Get(14).AllowAutoFilter = true;
            this.shtView.Columns.Get(14).AllowAutoSort = true;
            this.shtView.Columns.Get(14).Label = "Obj Order Qty";
            this.shtView.Columns.Get(14).Tag = "Obj Order Qty";
            this.shtView.Columns.Get(14).Width = 172F;
            this.shtView.Columns.Get(15).AllowAutoFilter = true;
            this.shtView.Columns.Get(15).AllowAutoSort = true;
            this.shtView.Columns.Get(15).Label = "Ref No";
            this.shtView.Columns.Get(15).Tag = "Ref No";
            this.shtView.Columns.Get(15).Width = 134F;
            this.shtView.Columns.Get(16).AllowAutoFilter = true;
            this.shtView.Columns.Get(16).AllowAutoSort = true;
            this.shtView.Columns.Get(16).Label = "Ref Slip No";
            this.shtView.Columns.Get(16).Tag = "Ref Slip No";
            this.shtView.Columns.Get(16).Width = 134F;
            this.shtView.Columns.Get(17).AllowAutoFilter = true;
            this.shtView.Columns.Get(17).AllowAutoSort = true;
            this.shtView.Columns.Get(17).Label = "Slip No";
            this.shtView.Columns.Get(17).Tag = "Slip No";
            this.shtView.Columns.Get(17).Width = 134F;
            this.shtView.Columns.Get(18).AllowAutoFilter = true;
            this.shtView.Columns.Get(18).AllowAutoSort = true;
            this.shtView.Columns.Get(18).Label = "Remark";
            this.shtView.Columns.Get(18).Tag = "Remark";
            this.shtView.Columns.Get(18).Width = 134F;
            this.shtView.Columns.Get(19).AllowAutoFilter = true;
            this.shtView.Columns.Get(19).AllowAutoSort = true;
            this.shtView.Columns.Get(19).Label = "Dealing No";
            this.shtView.Columns.Get(19).Tag = "Dealing No";
            this.shtView.Columns.Get(19).Width = 134F;
            this.shtView.Columns.Get(20).AllowAutoFilter = true;
            this.shtView.Columns.Get(20).AllowAutoSort = true;
            this.shtView.Columns.Get(20).Label = "Supp Lot No";
            this.shtView.Columns.Get(20).Tag = "Supp Lot No";
            this.shtView.Columns.Get(20).Width = 134F;
            this.shtView.Columns.Get(21).AllowAutoFilter = true;
            this.shtView.Columns.Get(21).AllowAutoSort = true;
            this.shtView.Columns.Get(21).Label = "Price";
            this.shtView.Columns.Get(21).Tag = "Price";
            this.shtView.Columns.Get(21).Width = 134F;
            this.shtView.Columns.Get(22).AllowAutoFilter = true;
            this.shtView.Columns.Get(22).AllowAutoSort = true;
            this.shtView.Columns.Get(22).Label = "For Customer";
            this.shtView.Columns.Get(22).Tag = "For Customer";
            this.shtView.Columns.Get(22).Width = 134F;
            this.shtView.Columns.Get(23).AllowAutoFilter = true;
            this.shtView.Columns.Get(23).AllowAutoSort = true;
            this.shtView.Columns.Get(23).Label = "For Machine";
            this.shtView.Columns.Get(23).Tag = "For Machine";
            this.shtView.Columns.Get(23).Width = 134F;
            this.shtView.Columns.Get(24).AllowAutoFilter = true;
            this.shtView.Columns.Get(24).AllowAutoSort = true;
            this.shtView.Columns.Get(24).Label = "Shift Cls";
            this.shtView.Columns.Get(24).Tag = "Shift Cls";
            this.shtView.Columns.Get(24).Width = 134F;
            this.shtView.Columns.Get(25).AllowAutoFilter = true;
            this.shtView.Columns.Get(25).AllowAutoSort = true;
            this.shtView.Columns.Get(25).Label = "Ref Slip No2";
            this.shtView.Columns.Get(25).Tag = "Ref Slip No2";
            this.shtView.Columns.Get(25).Width = 134F;
            this.shtView.Columns.Get(26).AllowAutoFilter = true;
            this.shtView.Columns.Get(26).AllowAutoSort = true;
            this.shtView.Columns.Get(26).Label = "Ng Qty";
            this.shtView.Columns.Get(26).Tag = "Ng Qty";
            this.shtView.Columns.Get(26).Width = 134F;
            this.shtView.Columns.Get(27).AllowAutoFilter = true;
            this.shtView.Columns.Get(27).AllowAutoSort = true;
            this.shtView.Columns.Get(27).Label = "Tran Sub Cls";
            this.shtView.Columns.Get(27).Tag = "Tran Sub Cls";
            this.shtView.Columns.Get(27).Width = 134F;
            this.shtView.Columns.Get(28).AllowAutoFilter = true;
            this.shtView.Columns.Get(28).AllowAutoSort = true;
            this.shtView.Columns.Get(28).Label = "Group Trans ID";
            this.shtView.Columns.Get(28).Tag = "Group Trans ID";
            this.shtView.Columns.Get(28).Width = 120F;
            this.shtView.Columns.Get(29).AllowAutoFilter = true;
            this.shtView.Columns.Get(29).AllowAutoSort = true;
            this.shtView.Columns.Get(29).Label = "Reserve Qty";
            this.shtView.Columns.Get(29).Tag = "Reserve Qty";
            this.shtView.Columns.Get(29).Width = 120F;
            this.shtView.Columns.Get(30).AllowAutoFilter = true;
            this.shtView.Columns.Get(30).AllowAutoSort = true;
            this.shtView.Columns.Get(30).Label = "NG Reason";
            this.shtView.Columns.Get(30).Tag = "NG Reason";
            this.shtView.Columns.Get(30).Width = 120F;
            this.shtView.DataAutoCellTypes = false;
            this.shtView.DataAutoHeadings = false;
            this.shtView.DataAutoSizeColumns = false;
            this.shtView.RowHeader.Columns.Default.Resizable = true;
            this.shtView.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.shtView.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpView.SetActiveViewport(0, 1, 0);
            // 
            // tableContainer
            // 
            this.tableContainer.ColumnCount = 2;
            this.tableContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 548F));
            this.tableContainer.Controls.Add(this.panSearch, 0, 1);
            this.tableContainer.Controls.Add(this.pnlHeader, 0, 0);
            this.tableContainer.Controls.Add(this.fpView, 0, 1);
            this.tableContainer.Controls.Add(this.tableSearch, 1, 0);
            this.tableContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableContainer.Location = new System.Drawing.Point(0, 0);
            this.tableContainer.Name = "tableContainer";
            this.tableContainer.RowCount = 3;
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableContainer.Size = new System.Drawing.Size(804, 399);
            this.tableContainer.TabIndex = 1;
            // 
            // panSearch
            // 
            this.panSearch.AppearanceName = "";
            this.tableContainer.SetColumnSpan(this.panSearch, 2);
            this.panSearch.Controls.Add(this.tblSearch);
            this.panSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panSearch.Location = new System.Drawing.Point(0, 43);
            this.panSearch.Margin = new System.Windows.Forms.Padding(0);
            this.panSearch.Name = "panSearch";
            this.panSearch.Size = new System.Drawing.Size(804, 33);
            this.panSearch.TabIndex = 4;
            // 
            // tblSearch
            // 
            this.tblSearch.ColumnCount = 5;
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 196F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 456F));
            this.tblSearch.Controls.Add(this.txtSearch, 4, 0);
            this.tblSearch.Controls.Add(this.pictureBox1, 3, 0);
            this.tblSearch.Controls.Add(this.lblScreenType, 0, 0);
            this.tblSearch.Controls.Add(this.cboScreenType, 1, 0);
            this.tblSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSearch.Location = new System.Drawing.Point(0, 0);
            this.tblSearch.Margin = new System.Windows.Forms.Padding(0);
            this.tblSearch.Name = "tblSearch";
            this.tblSearch.RowCount = 1;
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSearch.Size = new System.Drawing.Size(804, 33);
            this.tblSearch.TabIndex = 4;
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
            this.txtSearch.Location = new System.Drawing.Point(351, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PathString = null;
            this.txtSearch.PathValue = "";
            this.txtSearch.Size = new System.Drawing.Size(450, 26);
            this.txtSearch.TabIndex = 7;
            this.txtSearch.TabStop = false;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Rubik.Forms.Properties.Resources.FIND_TEXT;
            this.pictureBox1.Location = new System.Drawing.Point(308, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // lblScreenType
            // 
            this.lblScreenType.AppearanceName = "";
            this.lblScreenType.AutoSize = true;
            this.lblScreenType.ControlID = "";
            this.lblScreenType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScreenType.Location = new System.Drawing.Point(3, 0);
            this.lblScreenType.Name = "lblScreenType";
            this.lblScreenType.PathString = null;
            this.lblScreenType.PathValue = "Screen Type";
            this.lblScreenType.Size = new System.Drawing.Size(96, 33);
            this.lblScreenType.TabIndex = 8;
            this.lblScreenType.Text = "Screen Type";
            this.lblScreenType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboScreenType
            // 
            this.cboScreenType.AppearanceName = "";
            this.cboScreenType.AppearanceReadOnlyName = "";
            this.cboScreenType.ControlID = null;
            this.cboScreenType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboScreenType.DropDownHeight = 180;
            this.cboScreenType.FormattingEnabled = true;
            this.cboScreenType.IntegralHeight = false;
            this.cboScreenType.Location = new System.Drawing.Point(105, 3);
            this.cboScreenType.Name = "cboScreenType";
            this.cboScreenType.PathString = null;
            this.cboScreenType.PathValue = null;
            this.cboScreenType.Size = new System.Drawing.Size(190, 27);
            this.cboScreenType.TabIndex = 9;
            this.cboScreenType.SelectedIndexChanged += new System.EventHandler(this.cboScreenType_SelectedIndexChanged);
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
            this.pnlHeader.Size = new System.Drawing.Size(256, 43);
            this.pnlHeader.TabIndex = 0;
            // 
            // stcHead
            // 
            this.stcHead.AppearanceName = "Title";
            this.stcHead.AutoSize = true;
            this.stcHead.ControlID = "";
            this.stcHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stcHead.Font = new System.Drawing.Font("Tahoma", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.stcHead.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.stcHead.Location = new System.Drawing.Point(0, 0);
            this.stcHead.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.stcHead.Name = "stcHead";
            this.stcHead.PathString = null;
            this.stcHead.PathValue = "Transaction Log View";
            this.stcHead.Size = new System.Drawing.Size(360, 39);
            this.stcHead.TabIndex = 37;
            this.stcHead.Text = "Transaction Log View";
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
            this.tableSearch.Location = new System.Drawing.Point(256, 10);
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
            this.stcDash.ControlID = "";
            this.stcDash.Dock = System.Windows.Forms.DockStyle.Top;
            this.stcDash.Location = new System.Drawing.Point(339, 0);
            this.stcDash.Name = "stcDash";
            this.stcDash.PathString = null;
            this.stcDash.PathValue = "-";
            this.stcDash.Size = new System.Drawing.Size(15, 30);
            this.stcDash.TabIndex = 1;
            this.stcDash.Text = "-";
            this.stcDash.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcPeriod
            // 
            this.stcPeriod.AppearanceName = "";
            this.stcPeriod.ControlID = "";
            this.stcPeriod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stcPeriod.Location = new System.Drawing.Point(3, 0);
            this.stcPeriod.Name = "stcPeriod";
            this.stcPeriod.PathString = null;
            this.stcPeriod.PathValue = "Operation Period";
            this.stcPeriod.Size = new System.Drawing.Size(139, 33);
            this.stcPeriod.TabIndex = 0;
            this.stcPeriod.Text = "Operation Period";
            this.stcPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.dtPeriodBegin.Size = new System.Drawing.Size(185, 20);
            this.dtPeriodBegin.TabIndex = 2;
            this.dtPeriodBegin.Value = null;
            this.dtPeriodBegin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtPeriodBegin_KeyPress);
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
            this.dtPeriodEnd.Size = new System.Drawing.Size(185, 20);
            this.dtPeriodEnd.TabIndex = 3;
            this.dtPeriodEnd.Value = null;
            this.dtPeriodEnd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtPeriodEnd_KeyPress);
            // 
            // SMN010
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(804, 424);
            this.ExportObject = this.fpView;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SMN010";
            this.Load += new System.EventHandler(this.SMN010_Load);
            this.pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).EndInit();
            this.tableContainer.ResumeLayout(false);
            this.tableContainer.PerformLayout();
            this.panSearch.ResumeLayout(false);
            this.tblSearch.ResumeLayout(false);
            this.tblSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tableSearch.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread fpView;
        private FarPoint.Win.Spread.SheetView shtView;
        private System.Windows.Forms.TableLayoutPanel tableContainer;
        private EVOFramework.Windows.Forms.EVOPanel pnlHeader;
        private EVOFramework.Windows.Forms.EVOLabel stcHead;
        private System.Windows.Forms.TableLayoutPanel tableSearch;
        private EVOFramework.Windows.Forms.EVOLabel stcDash;
        private EVOFramework.Windows.Forms.EVOLabel stcPeriod;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtPeriodBegin;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtPeriodEnd;
        private EVOFramework.Windows.Forms.EVOPanel panSearch;
        private System.Windows.Forms.TableLayoutPanel tblSearch;
        private System.Windows.Forms.PictureBox pictureBox1;
        private EVOFramework.Windows.Forms.EVOTextBox txtSearch;
        private EVOFramework.Windows.Forms.EVOLabel lblScreenType;
        private EVOFramework.Windows.Forms.EVOComboBox cboScreenType;
    }
}
