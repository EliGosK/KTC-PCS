namespace Rubik.MRP
{
    partial class MRP010_MRPRunningScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MRP010_MRPRunningScreen));
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.evoLabel5 = new EVOFramework.Windows.Forms.EVOLabel();
            this.stdReceiveDate = new EVOFramework.Windows.Forms.EVOLabel();
            this.dtpStartDate = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.chkItemFlag = new System.Windows.Forms.CheckBox();
            this.evoLabel3 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtItemCodeFrom = new EVOFramework.Windows.Forms.EVOTextBox();
            this.txtItemCodeTo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.btnSearchItemFrom = new EVOFramework.Windows.Forms.EVOButton();
            this.btnSearchItemTo = new EVOFramework.Windows.Forms.EVOButton();
            this.evoLabel6 = new EVOFramework.Windows.Forms.EVOLabel();
            this.dtpLastSimulateDate = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.evoLabel7 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtRemark = new EVOFramework.Windows.Forms.EVOTextBox();
            this.btnRun = new EVOFramework.Windows.Forms.EVOButton();
            this.fpView = new FarPoint.Win.Spread.FpSpread();
            this.shtViewHeader = new FarPoint.Win.Spread.SheetView();
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.shtViewDetail = new FarPoint.Win.Spread.SheetView();
            this.picWaiting = new EVOFramework.Windows.Forms.EVOPictureBox();
            this.evoLabel4 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel8 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtMRPNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.txtLastMRPNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.evoLabel1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.btnSourceOrder = new EVOFramework.Windows.Forms.EVOButton();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtViewHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtViewDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWaiting)).BeginInit();
            this.SuspendLayout();
            // 
            // evoLabel5
            // 
            this.evoLabel5.AppearanceName = "Title";
            this.evoLabel5.AutoSize = true;
            this.evoLabel5.ControlID = "";
            this.evoLabel5.Font = new System.Drawing.Font("Tahoma", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.evoLabel5.Location = new System.Drawing.Point(0, 2);
            this.evoLabel5.Name = "evoLabel5";
            this.evoLabel5.PathString = null;
            this.evoLabel5.PathValue = "MRP Running Screen";
            this.evoLabel5.Size = new System.Drawing.Size(350, 39);
            this.evoLabel5.TabIndex = 10003;
            this.evoLabel5.Text = "MRP Running Screen";
            // 
            // stdReceiveDate
            // 
            this.stdReceiveDate.AppearanceName = "";
            this.stdReceiveDate.AutoSize = true;
            this.stdReceiveDate.ControlID = "";
            this.stdReceiveDate.Font = new System.Drawing.Font("Tahoma", 12F);
            this.stdReceiveDate.Location = new System.Drawing.Point(13, 112);
            this.stdReceiveDate.Name = "stdReceiveDate";
            this.stdReceiveDate.PathString = null;
            this.stdReceiveDate.PathValue = "Start Date";
            this.stdReceiveDate.Size = new System.Drawing.Size(79, 19);
            this.stdReceiveDate.TabIndex = 0;
            this.stdReceiveDate.Text = "Start Date";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.AppearanceName = "";
            this.dtpStartDate.AppearanceReadOnlyName = "";
            this.dtpStartDate.BackColor = System.Drawing.Color.Transparent;
            this.dtpStartDate.ControlID = "";
            this.dtpStartDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.dtpStartDate.Format = "dd/MM/yyyy";
            this.dtpStartDate.Location = new System.Drawing.Point(128, 106);
            this.dtpStartDate.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtpStartDate.NZValue")));
            this.dtpStartDate.PathString = null;
            this.dtpStartDate.PathValue = ((object)(resources.GetObject("dtpStartDate.PathValue")));
            this.dtpStartDate.ReadOnly = false;
            this.dtpStartDate.ShowButton = true;
            this.dtpStartDate.Size = new System.Drawing.Size(402, 27);
            this.dtpStartDate.TabIndex = 1;
            this.dtpStartDate.TabStop = false;
            this.dtpStartDate.Value = null;
            // 
            // chkItemFlag
            // 
            this.chkItemFlag.AutoSize = true;
            this.chkItemFlag.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkItemFlag.Location = new System.Drawing.Point(17, 150);
            this.chkItemFlag.Name = "chkItemFlag";
            this.chkItemFlag.Size = new System.Drawing.Size(15, 14);
            this.chkItemFlag.TabIndex = 1;
            this.chkItemFlag.UseVisualStyleBackColor = true;
            this.chkItemFlag.CheckedChanged += new System.EventHandler(this.chkItemFlag_CheckedChanged);
            // 
            // evoLabel3
            // 
            this.evoLabel3.AppearanceName = "";
            this.evoLabel3.AutoSize = true;
            this.evoLabel3.ControlID = "";
            this.evoLabel3.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel3.Location = new System.Drawing.Point(38, 147);
            this.evoLabel3.Name = "evoLabel3";
            this.evoLabel3.PathString = null;
            this.evoLabel3.PathValue = "Part No.";
            this.evoLabel3.Size = new System.Drawing.Size(67, 19);
            this.evoLabel3.TabIndex = 0;
            this.evoLabel3.Text = "Part No.";
            // 
            // txtItemCodeFrom
            // 
            this.txtItemCodeFrom.AppearanceName = "";
            this.txtItemCodeFrom.AppearanceReadOnlyName = "";
            this.txtItemCodeFrom.ControlID = "";
            this.txtItemCodeFrom.DisableRestrictChar = false;
            this.txtItemCodeFrom.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtItemCodeFrom.HelpButton = null;
            this.txtItemCodeFrom.Location = new System.Drawing.Point(128, 139);
            this.txtItemCodeFrom.MaxLength = 50;
            this.txtItemCodeFrom.Name = "txtItemCodeFrom";
            this.txtItemCodeFrom.PathString = null;
            this.txtItemCodeFrom.PathValue = "";
            this.txtItemCodeFrom.Size = new System.Drawing.Size(158, 27);
            this.txtItemCodeFrom.TabIndex = 2;
            // 
            // txtItemCodeTo
            // 
            this.txtItemCodeTo.AppearanceName = "";
            this.txtItemCodeTo.AppearanceReadOnlyName = "";
            this.txtItemCodeTo.ControlID = "";
            this.txtItemCodeTo.DisableRestrictChar = false;
            this.txtItemCodeTo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtItemCodeTo.HelpButton = null;
            this.txtItemCodeTo.Location = new System.Drawing.Point(338, 141);
            this.txtItemCodeTo.MaxLength = 50;
            this.txtItemCodeTo.Name = "txtItemCodeTo";
            this.txtItemCodeTo.PathString = null;
            this.txtItemCodeTo.PathValue = "";
            this.txtItemCodeTo.Size = new System.Drawing.Size(158, 27);
            this.txtItemCodeTo.TabIndex = 4;
            // 
            // btnSearchItemFrom
            // 
            this.btnSearchItemFrom.AppearanceName = "";
            this.btnSearchItemFrom.ControlID = null;
            this.btnSearchItemFrom.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnSearchItemFrom.Location = new System.Drawing.Point(286, 139);
            this.btnSearchItemFrom.Name = "btnSearchItemFrom";
            this.btnSearchItemFrom.Size = new System.Drawing.Size(34, 28);
            this.btnSearchItemFrom.TabIndex = 3;
            this.btnSearchItemFrom.Text = "...";
            this.btnSearchItemFrom.UseVisualStyleBackColor = true;
            this.btnSearchItemFrom.Click += new System.EventHandler(this.btnSearchItemFrom_Click);
            // 
            // btnSearchItemTo
            // 
            this.btnSearchItemTo.AppearanceName = "";
            this.btnSearchItemTo.ControlID = null;
            this.btnSearchItemTo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnSearchItemTo.Location = new System.Drawing.Point(496, 140);
            this.btnSearchItemTo.Name = "btnSearchItemTo";
            this.btnSearchItemTo.Size = new System.Drawing.Size(34, 28);
            this.btnSearchItemTo.TabIndex = 5;
            this.btnSearchItemTo.Text = "...";
            this.btnSearchItemTo.UseVisualStyleBackColor = true;
            this.btnSearchItemTo.Click += new System.EventHandler(this.btnSearchItemTo_Click);
            // 
            // evoLabel6
            // 
            this.evoLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.evoLabel6.AppearanceName = "";
            this.evoLabel6.AutoSize = true;
            this.evoLabel6.ControlID = "";
            this.evoLabel6.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel6.Location = new System.Drawing.Point(801, 11);
            this.evoLabel6.Name = "evoLabel6";
            this.evoLabel6.PathString = null;
            this.evoLabel6.PathValue = "Last Simulate";
            this.evoLabel6.Size = new System.Drawing.Size(103, 19);
            this.evoLabel6.TabIndex = 0;
            this.evoLabel6.Text = "Last Simulate";
            // 
            // dtpLastSimulateDate
            // 
            this.dtpLastSimulateDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpLastSimulateDate.AppearanceName = "";
            this.dtpLastSimulateDate.AppearanceReadOnlyName = "";
            this.dtpLastSimulateDate.BackColor = System.Drawing.Color.Transparent;
            this.dtpLastSimulateDate.ControlID = "";
            this.dtpLastSimulateDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.dtpLastSimulateDate.Format = "dd/MM/yyyy";
            this.dtpLastSimulateDate.Location = new System.Drawing.Point(923, 8);
            this.dtpLastSimulateDate.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtpLastSimulateDate.Name = "dtpLastSimulateDate";
            this.dtpLastSimulateDate.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtpLastSimulateDate.NZValue")));
            this.dtpLastSimulateDate.PathString = null;
            this.dtpLastSimulateDate.PathValue = ((object)(resources.GetObject("dtpLastSimulateDate.PathValue")));
            this.dtpLastSimulateDate.ReadOnly = true;
            this.dtpLastSimulateDate.ShowButton = true;
            this.dtpLastSimulateDate.Size = new System.Drawing.Size(178, 27);
            this.dtpLastSimulateDate.TabIndex = 13;
            this.dtpLastSimulateDate.TabStop = false;
            this.dtpLastSimulateDate.Value = null;
            // 
            // evoLabel7
            // 
            this.evoLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.evoLabel7.AppearanceName = "";
            this.evoLabel7.AutoSize = true;
            this.evoLabel7.ControlID = "";
            this.evoLabel7.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel7.Location = new System.Drawing.Point(548, 112);
            this.evoLabel7.Name = "evoLabel7";
            this.evoLabel7.PathString = null;
            this.evoLabel7.PathValue = "Remark";
            this.evoLabel7.Size = new System.Drawing.Size(63, 19);
            this.evoLabel7.TabIndex = 0;
            this.evoLabel7.Text = "Remark";
            // 
            // txtRemark
            // 
            this.txtRemark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemark.AppearanceName = "";
            this.txtRemark.AppearanceReadOnlyName = "";
            this.txtRemark.ControlID = "";
            this.txtRemark.DisableRestrictChar = false;
            this.txtRemark.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtRemark.HelpButton = null;
            this.txtRemark.Location = new System.Drawing.Point(617, 73);
            this.txtRemark.MaxLength = 255;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.PathString = null;
            this.txtRemark.PathValue = "";
            this.txtRemark.Size = new System.Drawing.Size(317, 94);
            this.txtRemark.TabIndex = 6;
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.AppearanceName = "";
            this.btnRun.ControlID = null;
            this.btnRun.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnRun.Image = global::Rubik.Forms.Properties.Resources.run;
            this.btnRun.Location = new System.Drawing.Point(1026, 106);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 61);
            this.btnRun.TabIndex = 8;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // fpView
            // 
            this.fpView.About = "2.5.2015.2005";
            this.fpView.AccessibleDescription = "fpView, Sheet1, Row 0, Column 0, ";
            this.fpView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fpView.BackColor = System.Drawing.Color.AliceBlue;
            this.fpView.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.fpView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.Location = new System.Drawing.Point(7, 177);
            this.fpView.Name = "fpView";
            this.fpView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtViewHeader});
            this.fpView.Size = new System.Drawing.Size(1094, 293);
            this.fpView.TabIndex = 18;
            this.fpView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpView_CellClick);
            this.fpView.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpView_CellDoubleClick);
            this.fpView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpView_KeyDown);
            // 
            // shtViewHeader
            // 
            this.shtViewHeader.Reset();
            this.shtViewHeader.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtViewHeader.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtViewHeader.ColumnCount = 21;
            this.shtViewHeader.RowCount = 15;
            this.shtViewHeader.AutoCalculation = false;
            this.shtViewHeader.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 0).Value = "MRP No.";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 1).Value = "Revision No.";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 2).Value = "Part No";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 3).Value = "Part Name";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 4).Value = "Supplier LOC";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 5).Value = "Part Type";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 6).Value = "Orde Process";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 7).Value = "Lot Size";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 8).Value = "Reorder Point";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 9).Value = "Safety Stock";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 10).Value = "Minimum Order";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 11).Value = "Inventory Unit Rate";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 12).Value = "Inventory Unit";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 13).Value = "Order Unit Rate";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 14).Value = "Order Unit";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 15).Value = "Max Capacity";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 16).Value = "Leadtime";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 17).Value = "Safety Leadtime";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 18).Value = "MRP Flag";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 19).Value = "Order Condition";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 20).Value = "Inventory Qty";
            this.shtViewHeader.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtViewHeader.Columns.Get(0).CellType = textCellType1;
            this.shtViewHeader.Columns.Get(0).Label = "MRP No.";
            this.shtViewHeader.Columns.Get(0).Tag = "MRP No.";
            this.shtViewHeader.Columns.Get(0).Width = 139F;
            numberCellType1.DecimalPlaces = 0;
            this.shtViewHeader.Columns.Get(1).CellType = numberCellType1;
            this.shtViewHeader.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.shtViewHeader.Columns.Get(1).Label = "Revision No.";
            this.shtViewHeader.Columns.Get(1).Tag = "Revision No.";
            this.shtViewHeader.Columns.Get(1).Width = 116F;
            this.shtViewHeader.Columns.Get(2).Label = "Part No";
            this.shtViewHeader.Columns.Get(2).Tag = "Part No";
            this.shtViewHeader.Columns.Get(2).Width = 200F;
            this.shtViewHeader.Columns.Get(3).Label = "Part Name";
            this.shtViewHeader.Columns.Get(3).Tag = "Part Name";
            this.shtViewHeader.Columns.Get(3).Width = 200F;
            this.shtViewHeader.Columns.Get(4).Label = "Supplier LOC";
            this.shtViewHeader.Columns.Get(4).Tag = "Supplier LOC";
            this.shtViewHeader.Columns.Get(4).Width = 200F;
            this.shtViewHeader.Columns.Get(5).Label = "Part Type";
            this.shtViewHeader.Columns.Get(5).Tag = "Part Type";
            this.shtViewHeader.Columns.Get(5).Width = 124F;
            this.shtViewHeader.Columns.Get(6).Label = "Orde Process";
            this.shtViewHeader.Columns.Get(6).Tag = "Orde Process";
            this.shtViewHeader.Columns.Get(6).Width = 174F;
            this.shtViewHeader.Columns.Get(7).CellType = numberCellType2;
            this.shtViewHeader.Columns.Get(7).Label = "Lot Size";
            this.shtViewHeader.Columns.Get(7).Tag = "Lot Size";
            this.shtViewHeader.Columns.Get(7).Width = 137F;
            this.shtViewHeader.Columns.Get(8).Label = "Reorder Point";
            this.shtViewHeader.Columns.Get(8).Tag = "Reorder Point";
            this.shtViewHeader.Columns.Get(8).Width = 137F;
            this.shtViewHeader.Columns.Get(9).Label = "Safety Stock";
            this.shtViewHeader.Columns.Get(9).Tag = "Safety Stock";
            this.shtViewHeader.Columns.Get(9).Width = 137F;
            this.shtViewHeader.Columns.Get(10).Label = "Minimum Order";
            this.shtViewHeader.Columns.Get(10).Tag = "Minimum Order";
            this.shtViewHeader.Columns.Get(10).Width = 137F;
            this.shtViewHeader.Columns.Get(11).Label = "Inventory Unit Rate";
            this.shtViewHeader.Columns.Get(11).Tag = "Inventory Unit Rate";
            this.shtViewHeader.Columns.Get(11).Width = 129F;
            this.shtViewHeader.Columns.Get(12).Label = "Inventory Unit";
            this.shtViewHeader.Columns.Get(12).Tag = "Inventory Unit";
            this.shtViewHeader.Columns.Get(12).Width = 129F;
            this.shtViewHeader.Columns.Get(13).Label = "Order Unit Rate";
            this.shtViewHeader.Columns.Get(13).Tag = "Order Unit Rate";
            this.shtViewHeader.Columns.Get(13).Width = 129F;
            this.shtViewHeader.Columns.Get(14).Label = "Order Unit";
            this.shtViewHeader.Columns.Get(14).Tag = "Order Unit";
            this.shtViewHeader.Columns.Get(14).Width = 129F;
            this.shtViewHeader.Columns.Get(15).Label = "Max Capacity";
            this.shtViewHeader.Columns.Get(15).Tag = "Max Capacity";
            this.shtViewHeader.Columns.Get(15).Width = 129F;
            this.shtViewHeader.Columns.Get(16).Label = "Leadtime";
            this.shtViewHeader.Columns.Get(16).Tag = "Leadtime";
            this.shtViewHeader.Columns.Get(16).Width = 129F;
            this.shtViewHeader.Columns.Get(17).Label = "Safety Leadtime";
            this.shtViewHeader.Columns.Get(17).Tag = "Safety Leadtime";
            this.shtViewHeader.Columns.Get(17).Width = 129F;
            this.shtViewHeader.Columns.Get(18).Label = "MRP Flag";
            this.shtViewHeader.Columns.Get(18).Tag = "MRP Flag";
            this.shtViewHeader.Columns.Get(18).Width = 220F;
            this.shtViewHeader.Columns.Get(19).Label = "Order Condition";
            this.shtViewHeader.Columns.Get(19).Tag = "Order Condition";
            this.shtViewHeader.Columns.Get(19).Width = 262F;
            this.shtViewHeader.Columns.Get(20).Label = "Inventory Qty";
            this.shtViewHeader.Columns.Get(20).Tag = "Inventory Qty";
            this.shtViewHeader.Columns.Get(20).Width = 129F;
            this.shtViewHeader.DataAutoCellTypes = false;
            this.shtViewHeader.DataAutoHeadings = false;
            this.shtViewHeader.DataAutoSizeColumns = false;
            this.shtViewHeader.DefaultStyle.ForeColor = System.Drawing.Color.Blue;
            this.shtViewHeader.DefaultStyle.Locked = true;
            this.shtViewHeader.DefaultStyle.Parent = "DataAreaDefault";
            this.shtViewHeader.LockForeColor = System.Drawing.Color.Black;
            this.shtViewHeader.RowHeader.Columns.Default.Resizable = true;
            this.shtViewHeader.RowHeader.Columns.Get(0).Width = 50F;
            this.shtViewHeader.RowHeader.Visible = false;
            this.shtViewHeader.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "2.5.2015.2005";
            this.fpSpread1.AccessibleDescription = "fpSpread1, Sheet1, Row 0, Column 0, ";
            this.fpSpread1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fpSpread1.BackColor = System.Drawing.Color.AliceBlue;
            this.fpSpread1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.Location = new System.Drawing.Point(7, 476);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpSpread1.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtViewDetail});
            this.fpSpread1.Size = new System.Drawing.Size(1094, 184);
            this.fpSpread1.TabIndex = 19;
            this.fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // shtViewDetail
            // 
            this.shtViewDetail.Reset();
            this.shtViewDetail.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtViewDetail.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtViewDetail.ColumnCount = 0;
            this.shtViewDetail.RowCount = 0;
            this.shtViewDetail.AutoCalculation = false;
            this.shtViewDetail.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtViewDetail.DefaultStyle.ForeColor = System.Drawing.Color.Blue;
            this.shtViewDetail.DefaultStyle.Locked = true;
            this.shtViewDetail.DefaultStyle.Parent = "DataAreaDefault";
            this.shtViewDetail.LockForeColor = System.Drawing.Color.Black;
            this.shtViewDetail.RowHeader.Columns.Default.Resizable = true;
            this.shtViewDetail.RowHeader.Columns.Get(0).Width = 50F;
            this.shtViewDetail.RowHeader.Visible = false;
            this.shtViewDetail.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpSpread1.SetActiveViewport(0, 1, 1);
            // 
            // picWaiting
            // 
            this.picWaiting.ControlID = "";
            this.picWaiting.Image = global::Rubik.Forms.Properties.Resources.bar_circle;
            this.picWaiting.Location = new System.Drawing.Point(383, 2);
            this.picWaiting.Name = "picWaiting";
            this.picWaiting.PathString = null;
            this.picWaiting.PathValue = global::Rubik.Forms.Properties.Resources.bar_circle;
            this.picWaiting.Size = new System.Drawing.Size(56, 50);
            this.picWaiting.TabIndex = 10004;
            this.picWaiting.TabStop = false;
            // 
            // evoLabel4
            // 
            this.evoLabel4.AppearanceName = "";
            this.evoLabel4.AutoSize = true;
            this.evoLabel4.ControlID = "";
            this.evoLabel4.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel4.Location = new System.Drawing.Point(322, 142);
            this.evoLabel4.Name = "evoLabel4";
            this.evoLabel4.PathString = null;
            this.evoLabel4.PathValue = "-";
            this.evoLabel4.Size = new System.Drawing.Size(15, 19);
            this.evoLabel4.TabIndex = 0;
            this.evoLabel4.Text = "-";
            // 
            // evoLabel8
            // 
            this.evoLabel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.evoLabel8.AppearanceName = "";
            this.evoLabel8.AutoSize = true;
            this.evoLabel8.ControlID = "";
            this.evoLabel8.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel8.Location = new System.Drawing.Point(13, 76);
            this.evoLabel8.Name = "evoLabel8";
            this.evoLabel8.PathString = null;
            this.evoLabel8.PathValue = "MRP No";
            this.evoLabel8.Size = new System.Drawing.Size(65, 19);
            this.evoLabel8.TabIndex = 0;
            this.evoLabel8.Text = "MRP No";
            // 
            // txtMRPNo
            // 
            this.txtMRPNo.AppearanceName = "";
            this.txtMRPNo.AppearanceReadOnlyName = "";
            this.txtMRPNo.ControlID = "";
            this.txtMRPNo.DisableRestrictChar = false;
            this.txtMRPNo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtMRPNo.HelpButton = null;
            this.txtMRPNo.Location = new System.Drawing.Point(128, 73);
            this.txtMRPNo.Name = "txtMRPNo";
            this.txtMRPNo.PathString = null;
            this.txtMRPNo.PathValue = "";
            this.txtMRPNo.ReadOnly = true;
            this.txtMRPNo.Size = new System.Drawing.Size(402, 27);
            this.txtMRPNo.TabIndex = 10006;
            this.txtMRPNo.TabStop = false;
            this.txtMRPNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel7.AutoSize = true;
            this.tableLayoutPanel7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel7.BackgroundImage")));
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.Location = new System.Drawing.Point(7, 41);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(1094, 24);
            this.tableLayoutPanel7.TabIndex = 10007;
            // 
            // txtLastMRPNo
            // 
            this.txtLastMRPNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastMRPNo.AppearanceName = "";
            this.txtLastMRPNo.AppearanceReadOnlyName = "";
            this.txtLastMRPNo.ControlID = "";
            this.txtLastMRPNo.DisableRestrictChar = false;
            this.txtLastMRPNo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtLastMRPNo.HelpButton = null;
            this.txtLastMRPNo.Location = new System.Drawing.Point(617, 8);
            this.txtLastMRPNo.Name = "txtLastMRPNo";
            this.txtLastMRPNo.PathString = null;
            this.txtLastMRPNo.PathValue = "";
            this.txtLastMRPNo.ReadOnly = true;
            this.txtLastMRPNo.Size = new System.Drawing.Size(178, 27);
            this.txtLastMRPNo.TabIndex = 10009;
            this.txtLastMRPNo.TabStop = false;
            // 
            // evoLabel1
            // 
            this.evoLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.evoLabel1.AppearanceName = "";
            this.evoLabel1.AutoSize = true;
            this.evoLabel1.ControlID = "";
            this.evoLabel1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel1.Location = new System.Drawing.Point(513, 11);
            this.evoLabel1.Name = "evoLabel1";
            this.evoLabel1.PathString = null;
            this.evoLabel1.PathValue = "Last MRP No";
            this.evoLabel1.Size = new System.Drawing.Size(98, 19);
            this.evoLabel1.TabIndex = 0;
            this.evoLabel1.Text = "Last MRP No";
            // 
            // btnSourceOrder
            // 
            this.btnSourceOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSourceOrder.AppearanceName = "";
            this.btnSourceOrder.ControlID = null;
            this.btnSourceOrder.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnSourceOrder.Image = global::Rubik.Forms.Properties.Resources.VIEW;
            this.btnSourceOrder.Location = new System.Drawing.Point(940, 106);
            this.btnSourceOrder.Name = "btnSourceOrder";
            this.btnSourceOrder.Size = new System.Drawing.Size(75, 61);
            this.btnSourceOrder.TabIndex = 7;
            this.btnSourceOrder.Text = "Source Order";
            this.btnSourceOrder.UseVisualStyleBackColor = true;
            this.btnSourceOrder.Click += new System.EventHandler(this.btnSourceOrder_Click);
            // 
            // MRP010_MRPRunningScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1113, 665);
            this.Controls.Add(this.txtLastMRPNo);
            this.Controls.Add(this.evoLabel1);
            this.Controls.Add(this.txtMRPNo);
            this.Controls.Add(this.evoLabel8);
            this.Controls.Add(this.picWaiting);
            this.Controls.Add(this.fpSpread1);
            this.Controls.Add(this.fpView);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnSourceOrder);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.evoLabel7);
            this.Controls.Add(this.dtpLastSimulateDate);
            this.Controls.Add(this.evoLabel6);
            this.Controls.Add(this.btnSearchItemTo);
            this.Controls.Add(this.btnSearchItemFrom);
            this.Controls.Add(this.txtItemCodeTo);
            this.Controls.Add(this.txtItemCodeFrom);
            this.Controls.Add(this.evoLabel3);
            this.Controls.Add(this.chkItemFlag);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.stdReceiveDate);
            this.Controls.Add(this.evoLabel5);
            this.Controls.Add(this.evoLabel4);
            this.Controls.Add(this.tableLayoutPanel7);
            this.MinimumSize = new System.Drawing.Size(1049, 699);
            this.Name = "MRP010_MRPRunningScreen";
            this.Text = "MRP010 - MRP Running Screen";
            this.Load += new System.EventHandler(this.MRP010_MRPRunningScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtViewHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtViewDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWaiting)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EVOFramework.Windows.Forms.EVOLabel evoLabel5;
        private EVOFramework.Windows.Forms.EVOLabel stdReceiveDate;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtpStartDate;
        private System.Windows.Forms.CheckBox chkItemFlag;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel3;
        private EVOFramework.Windows.Forms.EVOTextBox txtItemCodeFrom;
        private EVOFramework.Windows.Forms.EVOTextBox txtItemCodeTo;
        private EVOFramework.Windows.Forms.EVOButton btnSearchItemFrom;
        private EVOFramework.Windows.Forms.EVOButton btnSearchItemTo;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel6;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtpLastSimulateDate;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel7;
        private EVOFramework.Windows.Forms.EVOTextBox txtRemark;
        private EVOFramework.Windows.Forms.EVOButton btnRun;
        private FarPoint.Win.Spread.FpSpread fpView;
        private FarPoint.Win.Spread.SheetView shtViewHeader;
        private FarPoint.Win.Spread.FpSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView shtViewDetail;
        private EVOFramework.Windows.Forms.EVOPictureBox picWaiting;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel4;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel8;
        private EVOFramework.Windows.Forms.EVOTextBox txtMRPNo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private EVOFramework.Windows.Forms.EVOTextBox txtLastMRPNo;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel1;
        private EVOFramework.Windows.Forms.EVOButton btnSourceOrder;


    }
}