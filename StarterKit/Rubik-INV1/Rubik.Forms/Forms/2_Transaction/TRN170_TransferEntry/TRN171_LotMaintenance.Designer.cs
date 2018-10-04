
namespace Rubik.Transaction
{
    partial class TRN171_LotMaintenance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TRN171_LotMaintenance));
            this.cmsOperation = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dmc = new EVOFramework.Data.UIDataModelController(this.components);
            this.fpView = new FarPoint.Win.Spread.FpSpread();
            this.shtView = new FarPoint.Win.Spread.SheetView();
            this.evoLabel1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblItemCode = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel2 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel3 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtItemDesc = new EVOFramework.Windows.Forms.EVOTextBox();
            this.evoButton1 = new EVOFramework.Windows.Forms.EVOButton();
            this.txtItemNo = new Rubik.Forms.UserControl.ItemTextBox();
            this.txtLotNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblLotNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.btnGenerate = new EVOFramework.Windows.Forms.EVOButton();
            this.chkShowReserveLot = new EVOFramework.Windows.Forms.EVOCheckBox();
            this.txtLocation = new EVOFramework.Windows.Forms.EVOTextBox();
            this.pnlContainer.SuspendLayout();
            this.cmsOperation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContainer.Controls.Add(this.txtLocation);
            this.pnlContainer.Controls.Add(this.chkShowReserveLot);
            this.pnlContainer.Controls.Add(this.txtLotNo);
            this.pnlContainer.Controls.Add(this.lblLotNo);
            this.pnlContainer.Controls.Add(this.btnGenerate);
            this.pnlContainer.Controls.Add(this.txtItemDesc);
            this.pnlContainer.Controls.Add(this.evoButton1);
            this.pnlContainer.Controls.Add(this.txtItemNo);
            this.pnlContainer.Controls.Add(this.evoLabel3);
            this.pnlContainer.Controls.Add(this.evoLabel2);
            this.pnlContainer.Controls.Add(this.lblItemCode);
            this.pnlContainer.Controls.Add(this.evoLabel1);
            this.pnlContainer.Controls.Add(this.fpView);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.None;
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlContainer.Location = new System.Drawing.Point(0, 25);
            this.pnlContainer.Size = new System.Drawing.Size(661, 566);
            // 
            // cmsOperation
            // 
            this.cmsOperation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.cmsOperation.Name = "cmsOperation";
            this.cmsOperation.Size = new System.Drawing.Size(106, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // fpView
            // 
            this.fpView.About = "2.5.2015.2005";
            this.fpView.AccessibleDescription = "fpView, Sheet1";
            this.fpView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fpView.BackColor = System.Drawing.Color.AliceBlue;
            this.fpView.ContextMenuStrip = this.cmsOperation;
            this.fpView.EditModeReplace = true;
            this.fpView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.Location = new System.Drawing.Point(12, 195);
            this.fpView.Name = "fpView";
            this.fpView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtView});
            this.fpView.Size = new System.Drawing.Size(637, 368);
            this.fpView.TabIndex = 100001;
            this.fpView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.fpView_SelectionChanged);
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
            this.shtView.ColumnCount = 4;
            this.shtView.RowCount = 0;
            this.shtView.AutoCalculation = false;
            this.shtView.AutoGenerateColumns = false;
            this.shtView.ColumnHeader.Cells.Get(0, 0).Value = " ";
            this.shtView.ColumnHeader.Cells.Get(0, 1).Value = "Lot";
            this.shtView.ColumnHeader.Cells.Get(0, 2).Value = "On hand";
            this.shtView.ColumnHeader.Cells.Get(0, 3).Value = "Transfer";
            this.shtView.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtView.Columns.Get(0).CellType = checkBoxCellType1;
            this.shtView.Columns.Get(0).Label = " ";
            this.shtView.Columns.Get(0).Locked = false;
            this.shtView.Columns.Get(0).Width = 20F;
            this.shtView.Columns.Get(1).Label = "Lot";
            this.shtView.Columns.Get(1).Locked = true;
            this.shtView.Columns.Get(1).Tag = "Lot";
            this.shtView.Columns.Get(1).Width = 140F;
            this.shtView.Columns.Get(2).Label = "On hand";
            this.shtView.Columns.Get(2).Locked = true;
            this.shtView.Columns.Get(2).Tag = "On hand";
            this.shtView.Columns.Get(2).Width = 122F;
            this.shtView.Columns.Get(3).Label = "Transfer";
            this.shtView.Columns.Get(3).Locked = false;
            this.shtView.Columns.Get(3).Tag = "Transfer";
            this.shtView.Columns.Get(3).Width = 122F;
            this.shtView.DataAutoCellTypes = false;
            this.shtView.DataAutoHeadings = false;
            this.shtView.DataAutoSizeColumns = false;
            this.shtView.DefaultStyle.ForeColor = System.Drawing.Color.Blue;
            this.shtView.DefaultStyle.Locked = true;
            this.shtView.DefaultStyle.Parent = "DataAreaDefault";
            this.shtView.LockForeColor = System.Drawing.Color.Black;
            this.shtView.Protect = false;
            this.shtView.RowHeader.Columns.Default.Resizable = true;
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
            this.evoLabel1.Location = new System.Drawing.Point(14, 12);
            this.evoLabel1.Name = "evoLabel1";
            this.evoLabel1.PathString = null;
            this.evoLabel1.PathValue = "Lot Maintenance";
            this.evoLabel1.Size = new System.Drawing.Size(282, 39);
            this.evoLabel1.TabIndex = 100019;
            this.evoLabel1.Text = "Lot Maintenance";
            // 
            // lblItemCode
            // 
            this.lblItemCode.AppearanceName = "";
            this.lblItemCode.ControlID = "";
            this.lblItemCode.Location = new System.Drawing.Point(12, 93);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.PathString = null;
            this.lblItemCode.PathValue = "Part No";
            this.lblItemCode.Size = new System.Drawing.Size(135, 35);
            this.lblItemCode.TabIndex = 100022;
            this.lblItemCode.Text = "Part No";
            this.lblItemCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // evoLabel2
            // 
            this.evoLabel2.AppearanceName = "";
            this.evoLabel2.ControlID = "";
            this.evoLabel2.Location = new System.Drawing.Point(12, 61);
            this.evoLabel2.Name = "evoLabel2";
            this.evoLabel2.PathString = null;
            this.evoLabel2.PathValue = "Location";
            this.evoLabel2.Size = new System.Drawing.Size(135, 35);
            this.evoLabel2.TabIndex = 100024;
            this.evoLabel2.Text = "Location";
            this.evoLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // evoLabel3
            // 
            this.evoLabel3.AppearanceName = "";
            this.evoLabel3.ControlID = "";
            this.evoLabel3.Location = new System.Drawing.Point(12, 125);
            this.evoLabel3.Name = "evoLabel3";
            this.evoLabel3.PathString = null;
            this.evoLabel3.PathValue = "Part Name";
            this.evoLabel3.Size = new System.Drawing.Size(135, 35);
            this.evoLabel3.TabIndex = 100026;
            this.evoLabel3.Text = "Part Name";
            this.evoLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtItemDesc
            // 
            this.txtItemDesc.AppearanceName = "";
            this.txtItemDesc.AppearanceReadOnlyName = "";
            this.txtItemDesc.ControlID = "";
            this.txtItemDesc.DisableRestrictChar = false;
            this.txtItemDesc.HelpButton = null;
            this.txtItemDesc.Location = new System.Drawing.Point(153, 130);
            this.txtItemDesc.MaxLength = 100;
            this.txtItemDesc.Name = "txtItemDesc";
            this.txtItemDesc.PathString = "Item_Name.Value";
            this.txtItemDesc.PathValue = "";
            this.txtItemDesc.Size = new System.Drawing.Size(250, 27);
            this.txtItemDesc.TabIndex = 100029;
            // 
            // evoButton1
            // 
            this.evoButton1.AppearanceName = "";
            this.evoButton1.AutoSize = true;
            this.evoButton1.BackgroundImage = global::Rubik.Forms.Properties.Resources.VIEW;
            this.evoButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.evoButton1.ControlID = null;
            this.evoButton1.Location = new System.Drawing.Point(369, 96);
            this.evoButton1.Name = "evoButton1";
            this.evoButton1.Size = new System.Drawing.Size(34, 29);
            this.evoButton1.TabIndex = 100028;
            this.evoButton1.TabStop = false;
            this.evoButton1.UseVisualStyleBackColor = true;
            // 
            // txtItemNo
            // 
            this.txtItemNo.AllowNegative = true;
            this.txtItemNo.AppearanceName = "";
            this.txtItemNo.AppearanceReadOnlyName = "";
            this.txtItemNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtItemNo.CheckEmpty = true;
            this.txtItemNo.CheckExist = false;
            this.txtItemNo.CheckNotExist = true;
            this.txtItemNo.ControlID = "";
            this.txtItemNo.CustomerCode = null;
            this.txtItemNo.CustomerNameTextBox = null;
            this.txtItemNo.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtItemNo.DecimalPoint = '.';
            this.txtItemNo.DescriptionTextBox = this.txtItemDesc;
            this.txtItemNo.DigitsInGroup = 0;
            this.txtItemNo.Double = 0D;
            this.txtItemNo.FixDecimalPosition = true;
            this.txtItemNo.Flags = 0;
            this.txtItemNo.GroupSeparator = ',';
            this.txtItemNo.HelpButton = this.evoButton1;
            this.txtItemNo.Int = 0;
            this.txtItemNo.ItemType = new Rubik.eItemType[0];
            this.txtItemNo.Location = new System.Drawing.Point(153, 98);
            this.txtItemNo.Long = ((long)(0));
            this.txtItemNo.MaxDecimalPlaces = 0;
            this.txtItemNo.MaxLength = 50;
            this.txtItemNo.MaxWholeDigits = 10;
            this.txtItemNo.Name = "txtItemNo";
            this.txtItemNo.NegativeSign = '-';
            this.txtItemNo.PathString = "Item_No.Value";
            this.txtItemNo.PathValue = "";
            this.txtItemNo.Prefix = "";
            this.txtItemNo.RangeMax = 9999999999D;
            this.txtItemNo.RangeMin = 0D;
            this.txtItemNo.SelectedCustomerData = null;
            this.txtItemNo.SelectedItemData = null;
            this.txtItemNo.SelectedItemProcessData = null;
            this.txtItemNo.Size = new System.Drawing.Size(210, 27);
            this.txtItemNo.SqlOperator = Rubik.eSqlOperator.In;
            this.txtItemNo.TabIndex = 100027;
            this.txtItemNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtLotNo
            // 
            this.txtLotNo.AppearanceName = "";
            this.txtLotNo.AppearanceReadOnlyName = "";
            this.txtLotNo.ControlID = "";
            this.txtLotNo.DisableRestrictChar = false;
            this.txtLotNo.HelpButton = null;
            this.txtLotNo.Location = new System.Drawing.Point(153, 162);
            this.txtLotNo.MaxLength = 50;
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.PathString = "Lot_No.Value";
            this.txtLotNo.PathValue = "";
            this.txtLotNo.Size = new System.Drawing.Size(210, 27);
            this.txtLotNo.TabIndex = 100033;
            // 
            // lblLotNo
            // 
            this.lblLotNo.AppearanceName = "";
            this.lblLotNo.ControlID = "";
            this.lblLotNo.Location = new System.Drawing.Point(12, 158);
            this.lblLotNo.Name = "lblLotNo";
            this.lblLotNo.PathString = null;
            this.lblLotNo.PathValue = "Lot No";
            this.lblLotNo.Size = new System.Drawing.Size(135, 33);
            this.lblLotNo.TabIndex = 100035;
            this.lblLotNo.Text = "Lot No";
            this.lblLotNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnGenerate
            // 
            this.btnGenerate.AppearanceName = "";
            this.btnGenerate.AutoSize = true;
            this.btnGenerate.BackgroundImage = global::Rubik.Forms.Properties.Resources.REFRESH;
            this.btnGenerate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGenerate.ControlID = null;
            this.btnGenerate.Location = new System.Drawing.Point(369, 160);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(34, 29);
            this.btnGenerate.TabIndex = 100034;
            this.btnGenerate.TabStop = false;
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // chkShowReserveLot
            // 
            this.chkShowReserveLot.AppearanceName = "";
            this.chkShowReserveLot.CheckedValue = "true";
            this.chkShowReserveLot.ControlID = null;
            this.chkShowReserveLot.Location = new System.Drawing.Point(471, 162);
            this.chkShowReserveLot.Name = "chkShowReserveLot";
            this.chkShowReserveLot.PathString = "ShowReserveLot.Value";
            this.chkShowReserveLot.PathValue = false;
            this.chkShowReserveLot.Size = new System.Drawing.Size(178, 27);
            this.chkShowReserveLot.TabIndex = 100037;
            this.chkShowReserveLot.Text = "Show Reserve Lot";
            this.chkShowReserveLot.UnCheckedValue = "false";
            this.chkShowReserveLot.UseVisualStyleBackColor = true;
            // 
            // txtLocation
            // 
            this.txtLocation.AppearanceName = "";
            this.txtLocation.AppearanceReadOnlyName = "";
            this.txtLocation.ControlID = "";
            this.txtLocation.DisableRestrictChar = false;
            this.txtLocation.HelpButton = null;
            this.txtLocation.Location = new System.Drawing.Point(153, 65);
            this.txtLocation.MaxLength = 50;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.PathString = "Item_Name.Value";
            this.txtLocation.PathValue = "";
            this.txtLocation.Size = new System.Drawing.Size(250, 27);
            this.txtLocation.TabIndex = 100038;
            // 
            // TRN171_LotMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(661, 616);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 396);
            this.Name = "TRN171_LotMaintenance";
            this.Text = "TRN101: Lot Maintenance";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Lot_Maintenance_Load);
            this.Controls.SetChildIndex(this.pnlContainer, 0);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.cmsOperation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EVOFramework.Data.UIDataModelController dmc;
        private System.Windows.Forms.ContextMenuStrip cmsOperation;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private FarPoint.Win.Spread.FpSpread fpView;
        private FarPoint.Win.Spread.SheetView shtView;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel1;
        private EVOFramework.Windows.Forms.EVOLabel lblItemCode;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel2;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel3;
        private EVOFramework.Windows.Forms.EVOTextBox txtItemDesc;
        private EVOFramework.Windows.Forms.EVOButton evoButton1;
        private Rubik.Forms.UserControl.ItemTextBox txtItemNo;
        private EVOFramework.Windows.Forms.EVOTextBox txtLotNo;
        private EVOFramework.Windows.Forms.EVOLabel lblLotNo;
        private EVOFramework.Windows.Forms.EVOButton btnGenerate;
        private EVOFramework.Windows.Forms.EVOCheckBox chkShowReserveLot;
        private EVOFramework.Windows.Forms.EVOTextBox txtLocation;
    }
}
