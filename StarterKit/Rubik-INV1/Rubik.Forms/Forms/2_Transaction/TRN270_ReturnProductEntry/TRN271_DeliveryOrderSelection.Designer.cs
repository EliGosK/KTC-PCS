
namespace Rubik.Transaction
{
    partial class TRN271_DeliveryOrderSelection
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
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TRN271_DeliveryOrderSelection));
            this.dmc = new EVOFramework.Data.UIDataModelController(this.components);
            this.fpView = new FarPoint.Win.Spread.FpSpread();
            this.shtView = new FarPoint.Win.Spread.SheetView();
            this.evoLabel1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel2 = new EVOFramework.Windows.Forms.EVOLabel();
            this.dtPeriodEnd = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.evoLabel3 = new EVOFramework.Windows.Forms.EVOLabel();
            this.dtPeriodBegin = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.txtItemDesc = new EVOFramework.Windows.Forms.EVOTextBox();
            this.evoLabel8 = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcItemCode = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtMasterNo = new Rubik.Forms.UserControl.ItemTextBox();
            this.btnItemCode = new EVOFramework.Windows.Forms.EVOButton();
            this.btnGenerate = new EVOFramework.Windows.Forms.EVOButton();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContainer.Controls.Add(this.btnGenerate);
            this.pnlContainer.Controls.Add(this.txtItemDesc);
            this.pnlContainer.Controls.Add(this.evoLabel8);
            this.pnlContainer.Controls.Add(this.stcItemCode);
            this.pnlContainer.Controls.Add(this.txtMasterNo);
            this.pnlContainer.Controls.Add(this.btnItemCode);
            this.pnlContainer.Controls.Add(this.dtPeriodEnd);
            this.pnlContainer.Controls.Add(this.evoLabel3);
            this.pnlContainer.Controls.Add(this.dtPeriodBegin);
            this.pnlContainer.Controls.Add(this.evoLabel2);
            this.pnlContainer.Controls.Add(this.evoLabel1);
            this.pnlContainer.Controls.Add(this.fpView);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.None;
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlContainer.Location = new System.Drawing.Point(0, 25);
            this.pnlContainer.Size = new System.Drawing.Size(928, 465);
            // 
            // fpView
            // 
            this.fpView.About = "2.5.2015.2005";
            this.fpView.AccessibleDescription = "fpView, Sheet1";
            this.fpView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fpView.BackColor = System.Drawing.Color.AliceBlue;
            this.fpView.EditModeReplace = true;
            this.fpView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.Location = new System.Drawing.Point(12, 136);
            this.fpView.Name = "fpView";
            this.fpView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtView});
            this.fpView.Size = new System.Drawing.Size(904, 315);
            this.fpView.TabIndex = 5;
            this.fpView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.Change += new FarPoint.Win.Spread.ChangeEventHandler(this.fpView_Change);
            this.fpView.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.fpView_ButtonClicked);
            this.fpView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpView_KeyDown);
            // 
            // shtView
            // 
            this.shtView.Reset();
            this.shtView.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtView.ColumnCount = 17;
            this.shtView.RowCount = 0;
            this.shtView.AutoCalculation = false;
            this.shtView.AutoGenerateColumns = false;
            this.shtView.ColumnHeader.Cells.Get(0, 0).Value = " ";
            this.shtView.ColumnHeader.Cells.Get(0, 1).Value = "Delivery No.";
            this.shtView.ColumnHeader.Cells.Get(0, 2).Value = "Group Trans ID.";
            this.shtView.ColumnHeader.Cells.Get(0, 3).Value = "Trans ID.";
            this.shtView.ColumnHeader.Cells.Get(0, 4).Value = "Currency";
            this.shtView.ColumnHeader.Cells.Get(0, 5).Value = "Order No.";
            this.shtView.ColumnHeader.Cells.Get(0, 6).Value = "Order Detail No.";
            this.shtView.ColumnHeader.Cells.Get(0, 7).Value = "PO No.";
            this.shtView.ColumnHeader.Cells.Get(0, 8).Value = "M/N";
            this.shtView.ColumnHeader.Cells.Get(0, 9).Value = "Part No. ";
            this.shtView.ColumnHeader.Cells.Get(0, 10).Value = "Delivery Date";
            this.shtView.ColumnHeader.Cells.Get(0, 11).Value = "Pack No.";
            this.shtView.ColumnHeader.Cells.Get(0, 12).Value = "FG No.";
            this.shtView.ColumnHeader.Cells.Get(0, 13).Value = "Lot No.";
            this.shtView.ColumnHeader.Cells.Get(0, 14).Value = "Customer Lot No.";
            this.shtView.ColumnHeader.Cells.Get(0, 15).Value = "Delivery Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 16).Value = "Returnable Qty";
            this.shtView.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtView.Columns.Get(0).CellType = checkBoxCellType1;
            this.shtView.Columns.Get(0).Label = " ";
            this.shtView.Columns.Get(0).Locked = false;
            this.shtView.Columns.Get(0).Width = 20F;
            this.shtView.Columns.Get(1).AllowAutoFilter = true;
            this.shtView.Columns.Get(1).AllowAutoSort = true;
            this.shtView.Columns.Get(1).Label = "Delivery No.";
            this.shtView.Columns.Get(1).Tag = "Delivery No.";
            this.shtView.Columns.Get(1).Width = 115F;
            this.shtView.Columns.Get(2).Label = "Group Trans ID.";
            this.shtView.Columns.Get(2).Visible = false;
            this.shtView.Columns.Get(2).Width = 150F;
            this.shtView.Columns.Get(3).Label = "Trans ID.";
            this.shtView.Columns.Get(3).Visible = false;
            this.shtView.Columns.Get(3).Width = 100F;
            this.shtView.Columns.Get(4).Label = "Currency";
            this.shtView.Columns.Get(4).Visible = false;
            this.shtView.Columns.Get(4).Width = 100F;
            this.shtView.Columns.Get(5).AllowAutoFilter = true;
            this.shtView.Columns.Get(5).AllowAutoSort = true;
            this.shtView.Columns.Get(5).Label = "Order No.";
            this.shtView.Columns.Get(5).Locked = true;
            this.shtView.Columns.Get(5).Tag = "Order No.";
            this.shtView.Columns.Get(5).Width = 115F;
            this.shtView.Columns.Get(6).Label = "Order Detail No.";
            this.shtView.Columns.Get(6).Visible = false;
            this.shtView.Columns.Get(6).Width = 150F;
            this.shtView.Columns.Get(7).AllowAutoFilter = true;
            this.shtView.Columns.Get(7).AllowAutoSort = true;
            this.shtView.Columns.Get(7).Label = "PO No.";
            this.shtView.Columns.Get(7).Tag = "PO No.";
            this.shtView.Columns.Get(7).Width = 115F;
            this.shtView.Columns.Get(8).AllowAutoFilter = true;
            this.shtView.Columns.Get(8).AllowAutoSort = true;
            this.shtView.Columns.Get(8).Label = "M/N";
            this.shtView.Columns.Get(8).Tag = "Master No.";
            this.shtView.Columns.Get(8).Width = 115F;
            this.shtView.Columns.Get(9).AllowAutoFilter = true;
            this.shtView.Columns.Get(9).AllowAutoSort = true;
            this.shtView.Columns.Get(9).Label = "Part No. ";
            this.shtView.Columns.Get(9).Tag = "Part No. ";
            this.shtView.Columns.Get(9).Width = 115F;
            this.shtView.Columns.Get(10).AllowAutoFilter = true;
            this.shtView.Columns.Get(10).AllowAutoSort = true;
            this.shtView.Columns.Get(10).Label = "Delivery Date";
            this.shtView.Columns.Get(10).Locked = true;
            this.shtView.Columns.Get(10).Tag = "Delivery Date";
            this.shtView.Columns.Get(10).Width = 115F;
            this.shtView.Columns.Get(11).AllowAutoFilter = true;
            this.shtView.Columns.Get(11).AllowAutoSort = true;
            this.shtView.Columns.Get(11).Label = "Pack No.";
            this.shtView.Columns.Get(11).Locked = false;
            this.shtView.Columns.Get(11).Tag = "Pack No.";
            this.shtView.Columns.Get(11).Visible = false;
            this.shtView.Columns.Get(11).Width = 120F;
            this.shtView.Columns.Get(12).AllowAutoFilter = true;
            this.shtView.Columns.Get(12).AllowAutoSort = true;
            this.shtView.Columns.Get(12).Label = "FG No.";
            this.shtView.Columns.Get(12).Tag = "FG No.";
            this.shtView.Columns.Get(12).Visible = false;
            this.shtView.Columns.Get(12).Width = 122F;
            this.shtView.Columns.Get(13).AllowAutoFilter = true;
            this.shtView.Columns.Get(13).AllowAutoSort = true;
            this.shtView.Columns.Get(13).Label = "Lot No.";
            this.shtView.Columns.Get(13).Tag = "Lot No.";
            this.shtView.Columns.Get(13).Width = 120F;
            this.shtView.Columns.Get(14).AllowAutoFilter = true;
            this.shtView.Columns.Get(14).AllowAutoSort = true;
            this.shtView.Columns.Get(14).Label = "Customer Lot No.";
            this.shtView.Columns.Get(14).Tag = "Customer Lot No.";
            this.shtView.Columns.Get(14).Width = 120F;
            this.shtView.Columns.Get(15).AllowAutoFilter = true;
            this.shtView.Columns.Get(15).AllowAutoSort = true;
            this.shtView.Columns.Get(15).Label = "Delivery Qty";
            this.shtView.Columns.Get(15).Tag = "Delivery Qty";
            this.shtView.Columns.Get(15).Width = 120F;
            this.shtView.Columns.Get(16).AllowAutoFilter = true;
            this.shtView.Columns.Get(16).AllowAutoSort = true;
            this.shtView.Columns.Get(16).Label = "Returnable Qty";
            this.shtView.Columns.Get(16).Tag = "Returnable Qty";
            this.shtView.Columns.Get(16).Width = 120F;
            this.shtView.DataAutoCellTypes = false;
            this.shtView.DataAutoHeadings = false;
            this.shtView.DataAutoSizeColumns = false;
            this.shtView.DefaultStyle.ForeColor = System.Drawing.Color.Blue;
            this.shtView.DefaultStyle.Locked = true;
            this.shtView.DefaultStyle.Parent = "DataAreaDefault";
            this.shtView.LockForeColor = System.Drawing.Color.Black;
            this.shtView.RowHeader.Columns.Default.Resizable = true;
            this.shtView.RowHeader.Columns.Get(0).Width = 34F;
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpView.SetActiveViewport(0, 1, 0);
            // 
            // evoLabel1
            // 
            this.evoLabel1.AppearanceName = "Title";
            this.evoLabel1.AutoSize = true;
            this.evoLabel1.ControlID = "";
            this.evoLabel1.Font = new System.Drawing.Font("Tahoma", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.evoLabel1.Location = new System.Drawing.Point(12, 15);
            this.evoLabel1.Name = "evoLabel1";
            this.evoLabel1.PathString = null;
            this.evoLabel1.PathValue = "Delivery Selection";
            this.evoLabel1.Size = new System.Drawing.Size(307, 39);
            this.evoLabel1.TabIndex = 100019;
            this.evoLabel1.Text = "Delivery Selection";
            // 
            // evoLabel2
            // 
            this.evoLabel2.AppearanceName = "";
            this.evoLabel2.ControlID = "";
            this.evoLabel2.Location = new System.Drawing.Point(20, 99);
            this.evoLabel2.Name = "evoLabel2";
            this.evoLabel2.PathString = null;
            this.evoLabel2.PathValue = "Delivery Date";
            this.evoLabel2.Size = new System.Drawing.Size(105, 32);
            this.evoLabel2.TabIndex = 100022;
            this.evoLabel2.Text = "Delivery Date";
            this.evoLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtPeriodEnd
            // 
            this.dtPeriodEnd.AppearanceName = "";
            this.dtPeriodEnd.AppearanceReadOnlyName = "";
            this.dtPeriodEnd.BackColor = System.Drawing.Color.Transparent;
            this.dtPeriodEnd.ControlID = "";
            this.dtPeriodEnd.Format = "dd/MM/yyyy";
            this.dtPeriodEnd.Location = new System.Drawing.Point(350, 102);
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
            // 
            // evoLabel3
            // 
            this.evoLabel3.AppearanceName = "";
            this.evoLabel3.AutoSize = true;
            this.evoLabel3.ControlID = "";
            this.evoLabel3.Location = new System.Drawing.Point(329, 106);
            this.evoLabel3.Name = "evoLabel3";
            this.evoLabel3.PathString = null;
            this.evoLabel3.PathValue = "-";
            this.evoLabel3.Size = new System.Drawing.Size(15, 19);
            this.evoLabel3.TabIndex = 100025;
            this.evoLabel3.Text = "-";
            this.evoLabel3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dtPeriodBegin
            // 
            this.dtPeriodBegin.AppearanceName = "";
            this.dtPeriodBegin.AppearanceReadOnlyName = "";
            this.dtPeriodBegin.BackColor = System.Drawing.Color.Transparent;
            this.dtPeriodBegin.ControlID = "";
            this.dtPeriodBegin.Format = "dd/MM/yyyy";
            this.dtPeriodBegin.Location = new System.Drawing.Point(134, 102);
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
            // 
            // txtItemDesc
            // 
            this.txtItemDesc.AppearanceName = "";
            this.txtItemDesc.AppearanceReadOnlyName = "";
            this.txtItemDesc.ControlID = "";
            this.txtItemDesc.DisableRestrictChar = false;
            this.txtItemDesc.HelpButton = null;
            this.txtItemDesc.Location = new System.Drawing.Point(414, 67);
            this.txtItemDesc.MaxLength = 50;
            this.txtItemDesc.Name = "txtItemDesc";
            this.txtItemDesc.PathString = "ItemDesc.Value";
            this.txtItemDesc.PathValue = "";
            this.txtItemDesc.Size = new System.Drawing.Size(368, 27);
            this.txtItemDesc.TabIndex = 1;
            // 
            // evoLabel8
            // 
            this.evoLabel8.AppearanceName = "";
            this.evoLabel8.ControlID = "";
            this.evoLabel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel8.Location = new System.Drawing.Point(15, 66);
            this.evoLabel8.Name = "evoLabel8";
            this.evoLabel8.PathString = null;
            this.evoLabel8.PathValue = "Master No.";
            this.evoLabel8.Size = new System.Drawing.Size(87, 31);
            this.evoLabel8.TabIndex = 100030;
            this.evoLabel8.Text = "Master No.";
            this.evoLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcItemCode
            // 
            this.stcItemCode.AppearanceName = "";
            this.stcItemCode.ControlID = "";
            this.stcItemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.stcItemCode.Location = new System.Drawing.Point(350, 63);
            this.stcItemCode.Name = "stcItemCode";
            this.stcItemCode.PathString = null;
            this.stcItemCode.PathValue = "Part No.";
            this.stcItemCode.Size = new System.Drawing.Size(80, 35);
            this.stcItemCode.TabIndex = 100031;
            this.stcItemCode.Text = "Part No.";
            this.stcItemCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.txtMasterNo.CustomerNameTextBox = null;
            this.txtMasterNo.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMasterNo.DecimalPoint = '.';
            this.txtMasterNo.DescriptionTextBox = this.txtItemDesc;
            this.txtMasterNo.DigitsInGroup = 0;
            this.txtMasterNo.Double = 0D;
            this.txtMasterNo.FixDecimalPosition = true;
            this.txtMasterNo.Flags = 0;
            this.txtMasterNo.ForeColor = System.Drawing.Color.Black;
            this.txtMasterNo.GroupSeparator = ',';
            this.txtMasterNo.HelpButton = this.btnItemCode;
            this.txtMasterNo.Int = 0;
            this.txtMasterNo.ItemType = new Rubik.eItemType[0];
            this.txtMasterNo.Location = new System.Drawing.Point(134, 68);
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
            this.txtMasterNo.Size = new System.Drawing.Size(149, 27);
            this.txtMasterNo.SqlOperator = Rubik.eSqlOperator.In;
            this.txtMasterNo.TabIndex = 0;
            this.txtMasterNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnItemCode
            // 
            this.btnItemCode.AppearanceName = "";
            this.btnItemCode.AutoSize = true;
            this.btnItemCode.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnItemCode.BackgroundImage")));
            this.btnItemCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnItemCode.ControlID = null;
            this.btnItemCode.Location = new System.Drawing.Point(289, 67);
            this.btnItemCode.Name = "btnItemCode";
            this.btnItemCode.Size = new System.Drawing.Size(32, 29);
            this.btnItemCode.TabIndex = 1;
            this.btnItemCode.TabStop = false;
            this.btnItemCode.UseVisualStyleBackColor = true;
            // 
            // btnGenerate
            // 
            this.btnGenerate.AppearanceName = "";
            this.btnGenerate.AutoSize = true;
            this.btnGenerate.BackgroundImage = global::Rubik.Forms.Properties.Resources.REFRESH;
            this.btnGenerate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGenerate.ControlID = null;
            this.btnGenerate.Location = new System.Drawing.Point(538, 101);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(34, 29);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // TRN271_DeliveryOrderSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(928, 515);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 396);
            this.Name = "TRN271_DeliveryOrderSelection";
            this.Text = "TRN102: Delivery Selection";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Lot_Maintenance_Load);
            this.Shown += new System.EventHandler(this.TRN271_DeliveryOrderSelection_Shown);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EVOFramework.Data.UIDataModelController dmc;
        private FarPoint.Win.Spread.FpSpread fpView;
        private FarPoint.Win.Spread.SheetView shtView;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel1;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel2;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtPeriodEnd;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel3;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtPeriodBegin;
        private EVOFramework.Windows.Forms.EVOTextBox txtItemDesc;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel8;
        private EVOFramework.Windows.Forms.EVOLabel stcItemCode;
        private Forms.UserControl.ItemTextBox txtMasterNo;
        private EVOFramework.Windows.Forms.EVOButton btnItemCode;
        private EVOFramework.Windows.Forms.EVOButton btnGenerate;
    }
}
