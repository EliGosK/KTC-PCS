using EVOFramework.Windows.Forms;
namespace Rubik.Master
{
    partial class MAS050_BOMSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAS050_BOMSetup));
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.CurrencyCellType currencyCellType1 = new FarPoint.Win.Spread.CellType.CurrencyCellType();
            FarPoint.Win.Spread.CellType.CurrencyCellType currencyCellType2 = new FarPoint.Win.Spread.CellType.CurrencyCellType();
            this.pnlContainerNew = new EVOFramework.Windows.Forms.EVOPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpHeader2 = new System.Windows.Forms.TableLayoutPanel();
            this.stcBOMInformation = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcBOMSetup = new EVOFramework.Windows.Forms.EVOLabel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.stcItemDesc = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcItemCD = new EVOFramework.Windows.Forms.EVOLabel();
            this.label4 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtItemCD = new Rubik.Forms.UserControl.ItemTextBox();
            this.txtItemDesc = new EVOFramework.Windows.Forms.EVOTextBox();
            this.btnItemCD = new EVOFramework.Windows.Forms.EVOButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fpView = new FarPoint.Win.Spread.FpSpread();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miAddChildItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miEditItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miDeleteTree = new System.Windows.Forms.ToolStripMenuItem();
            this.shtView = new FarPoint.Win.Spread.SheetView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnMoveUp = new EVOFramework.Windows.Forms.EVOButton();
            this.btnMoveDown = new EVOFramework.Windows.Forms.EVOButton();
            this.imgListStateNode = new System.Windows.Forms.ImageList(this.components);
            this.tslControl = new System.Windows.Forms.ToolStrip();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tlsSeperator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.tlsSeperator2 = new System.Windows.Forms.ToolStripSeparator();
            this.pnlContainerNew.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tlpHeader2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).BeginInit();
            this.ctxMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).BeginInit();
            this.panel2.SuspendLayout();
            this.tslControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainerNew
            // 
            this.pnlContainerNew.AppearanceName = "FormBGColor";
            this.pnlContainerNew.AutoScroll = true;
            this.pnlContainerNew.Controls.Add(this.tableLayoutPanel1);
            this.pnlContainerNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainerNew.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.pnlContainerNew.Location = new System.Drawing.Point(0, 28);
            this.pnlContainerNew.Name = "pnlContainerNew";
            this.pnlContainerNew.Size = new System.Drawing.Size(792, 461);
            this.pnlContainerNew.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tlpHeader2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.stcBOMSetup, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(792, 461);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tlpHeader2
            // 
            this.tlpHeader2.AutoSize = true;
            this.tlpHeader2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tlpHeader2.BackgroundImage")));
            this.tlpHeader2.ColumnCount = 1;
            this.tlpHeader2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHeader2.Controls.Add(this.stcBOMInformation, 0, 0);
            this.tlpHeader2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHeader2.Location = new System.Drawing.Point(0, 51);
            this.tlpHeader2.Margin = new System.Windows.Forms.Padding(0);
            this.tlpHeader2.Name = "tlpHeader2";
            this.tlpHeader2.RowCount = 1;
            this.tlpHeader2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHeader2.Size = new System.Drawing.Size(792, 24);
            this.tlpHeader2.TabIndex = 38;
            // 
            // stcBOMInformation
            // 
            this.stcBOMInformation.AppearanceName = "Header";
            this.stcBOMInformation.AutoSize = true;
            this.stcBOMInformation.ControlID = "";
            this.stcBOMInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.stcBOMInformation.ForeColor = System.Drawing.Color.Navy;
            this.stcBOMInformation.Location = new System.Drawing.Point(0, 0);
            this.stcBOMInformation.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.stcBOMInformation.Name = "stcBOMInformation";
            this.stcBOMInformation.PathString = null;
            this.stcBOMInformation.PathValue = "BOM Structure Information";
            this.stcBOMInformation.Size = new System.Drawing.Size(230, 24);
            this.stcBOMInformation.TabIndex = 0;
            this.stcBOMInformation.Text = "BOM Structure Information";
            // 
            // stcBOMSetup
            // 
            this.stcBOMSetup.AppearanceName = "Title";
            this.stcBOMSetup.AutoSize = true;
            this.stcBOMSetup.ControlID = "";
            this.stcBOMSetup.Dock = System.Windows.Forms.DockStyle.Top;
            this.stcBOMSetup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.stcBOMSetup.Location = new System.Drawing.Point(3, 0);
            this.stcBOMSetup.Name = "stcBOMSetup";
            this.stcBOMSetup.PathString = null;
            this.stcBOMSetup.PathValue = "BOM Setup";
            this.stcBOMSetup.Size = new System.Drawing.Size(786, 19);
            this.stcBOMSetup.TabIndex = 36;
            this.stcBOMSetup.Text = "BOM Setup";
            this.stcBOMSetup.UseMnemonic = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.Controls.Add(this.stcItemDesc, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.stcItemCD, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtItemCD, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnItemCD, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtItemDesc, 5, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 19);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(792, 32);
            this.tableLayoutPanel2.TabIndex = 37;
            // 
            // stcItemDesc
            // 
            this.stcItemDesc.AppearanceName = "";
            this.stcItemDesc.ControlID = "";
            this.stcItemDesc.Dock = System.Windows.Forms.DockStyle.Top;
            this.stcItemDesc.Location = new System.Drawing.Point(306, 3);
            this.stcItemDesc.Margin = new System.Windows.Forms.Padding(3);
            this.stcItemDesc.Name = "stcItemDesc";
            this.stcItemDesc.PathString = null;
            this.stcItemDesc.PathValue = "Part Name";
            this.stcItemDesc.Size = new System.Drawing.Size(100, 21);
            this.stcItemDesc.TabIndex = 14;
            this.stcItemDesc.Text = "Part Name";
            // 
            // stcItemCD
            // 
            this.stcItemCD.AppearanceName = "";
            this.stcItemCD.ControlID = "";
            this.stcItemCD.Dock = System.Windows.Forms.DockStyle.Top;
            this.stcItemCD.Location = new System.Drawing.Point(23, 3);
            this.stcItemCD.Margin = new System.Windows.Forms.Padding(3);
            this.stcItemCD.Name = "stcItemCD";
            this.stcItemCD.PathString = null;
            this.stcItemCD.PathValue = "Part No";
            this.stcItemCD.Size = new System.Drawing.Size(82, 21);
            this.stcItemCD.TabIndex = 11;
            this.stcItemCD.Text = "Part No";
            // 
            // label4
            // 
            this.label4.AppearanceName = "RequireText";
            this.label4.AutoSize = true;
            this.label4.ControlID = "";
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.ForeColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.PathString = null;
            this.label4.PathValue = "*";
            this.label4.Size = new System.Drawing.Size(14, 32);
            this.label4.TabIndex = 10;
            this.label4.Text = "*";
            // 
            // txtItemCD
            // 
            this.txtItemCD.AllowNegative = true;
            this.txtItemCD.AppearanceName = "";
            this.txtItemCD.AppearanceReadOnlyName = "";
            this.txtItemCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtItemCD.CheckEmpty = true;
            this.txtItemCD.CheckExist = false;
            this.txtItemCD.CheckNotExist = true;
            this.txtItemCD.ControlID = "";
            this.txtItemCD.CustomerCode = null;
            this.txtItemCD.CustomerNameTextBox = null;
            this.txtItemCD.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtItemCD.DecimalPoint = '.';
            this.txtItemCD.DescriptionTextBox = this.txtItemDesc;
            this.txtItemCD.DigitsInGroup = 0;
            this.txtItemCD.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtItemCD.Double = 0D;
            this.txtItemCD.FixDecimalPosition = true;
            this.txtItemCD.Flags = 0;
            this.txtItemCD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtItemCD.GroupSeparator = ',';
            this.txtItemCD.HelpButton = this.btnItemCD;
            this.txtItemCD.Int = 0;
            this.txtItemCD.ItemType = null;
            this.txtItemCD.Location = new System.Drawing.Point(111, 3);
            this.txtItemCD.Long = ((long)(0));
            this.txtItemCD.MaxDecimalPlaces = 0;
            this.txtItemCD.MaxLength = 50;
            this.txtItemCD.MaxWholeDigits = 10;
            this.txtItemCD.Name = "txtItemCD";
            this.txtItemCD.NegativeSign = '-';
            this.txtItemCD.PathString = null;
            this.txtItemCD.PathValue = "";
            this.txtItemCD.Prefix = "";
            this.txtItemCD.RangeMax = 9999999999D;
            this.txtItemCD.RangeMin = 0D;
            this.txtItemCD.SelectedCustomerData = null;
            this.txtItemCD.SelectedItemData = null;
            this.txtItemCD.SelectedItemProcessData = null;
            this.txtItemCD.Size = new System.Drawing.Size(157, 26);
            this.txtItemCD.SqlOperator = Rubik.eSqlOperator.In;
            this.txtItemCD.TabIndex = 12;
            this.txtItemCD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtItemCD.KeyPressResult += new Rubik.Forms.UserControl.ItemFoundHandler(this.txtItem_KeyPressResult);
            // 
            // txtItemDesc
            // 
            this.txtItemDesc.AppearanceName = "";
            this.txtItemDesc.AppearanceReadOnlyName = "";
            this.txtItemDesc.ControlID = "";
            this.txtItemDesc.DisableRestrictChar = false;
            this.txtItemDesc.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtItemDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtItemDesc.HelpButton = null;
            this.txtItemDesc.Location = new System.Drawing.Point(412, 3);
            this.txtItemDesc.MaxLength = 100;
            this.txtItemDesc.Name = "txtItemDesc";
            this.txtItemDesc.PathString = null;
            this.txtItemDesc.PathValue = "";
            this.txtItemDesc.Size = new System.Drawing.Size(377, 26);
            this.txtItemDesc.TabIndex = 15;
            // 
            // btnItemCD
            // 
            this.btnItemCD.AppearanceName = "";
            this.btnItemCD.AutoSize = true;
            this.btnItemCD.BackgroundImage = global::Rubik.Forms.Properties.Resources.VIEW;
            this.btnItemCD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnItemCD.ControlID = null;
            this.btnItemCD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnItemCD.Location = new System.Drawing.Point(274, 3);
            this.btnItemCD.Name = "btnItemCD";
            this.btnItemCD.Size = new System.Drawing.Size(26, 26);
            this.btnItemCD.TabIndex = 13;
            this.btnItemCD.TabStop = false;
            this.btnItemCD.UseVisualStyleBackColor = true;
            this.btnItemCD.Click += new System.EventHandler(this.btnItemCD_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.fpView);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 78);
            this.panel1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(789, 380);
            this.panel1.TabIndex = 39;
            // 
            // fpView
            // 
            this.fpView.About = "2.5.2015.2005";
            this.fpView.AccessibleDescription = "fpView, Sheet1";
            this.fpView.BackColor = System.Drawing.SystemColors.Control;
            this.fpView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fpView.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpView.ContextMenuStrip = this.ctxMenu;
            this.fpView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.Location = new System.Drawing.Point(44, 0);
            this.fpView.Margin = new System.Windows.Forms.Padding(5);
            this.fpView.Name = "fpView";
            this.fpView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpView.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtView});
            this.fpView.Size = new System.Drawing.Size(745, 380);
            this.fpView.TabIndex = 40;
            this.fpView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.fpView_SelectionChanged);
            this.fpView.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpView_CellDoubleClick);
            this.fpView.Paint += new System.Windows.Forms.PaintEventHandler(this.fpView_Paint);
            this.fpView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpView_KeyDown);
            this.fpView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fpView_MouseDown);
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAddChildItem,
            this.miEditItem,
            this.miDeleteItem,
            this.miDeleteTree});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(145, 92);
            this.ctxMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ctxMenu_Opening);
            // 
            // miAddChildItem
            // 
            this.miAddChildItem.Name = "miAddChildItem";
            this.miAddChildItem.Size = new System.Drawing.Size(144, 22);
            this.miAddChildItem.Text = "Add Child Item";
            this.miAddChildItem.Click += new System.EventHandler(this.miAddChildItem_Click);
            // 
            // miEditItem
            // 
            this.miEditItem.Name = "miEditItem";
            this.miEditItem.Size = new System.Drawing.Size(144, 22);
            this.miEditItem.Text = "Edit Item";
            this.miEditItem.Click += new System.EventHandler(this.miEditItem_Click);
            // 
            // miDeleteItem
            // 
            this.miDeleteItem.Name = "miDeleteItem";
            this.miDeleteItem.Size = new System.Drawing.Size(144, 22);
            this.miDeleteItem.Text = "Delete Item";
            this.miDeleteItem.Click += new System.EventHandler(this.miDeleteItem_Click);
            // 
            // miDeleteTree
            // 
            this.miDeleteTree.Name = "miDeleteTree";
            this.miDeleteTree.Size = new System.Drawing.Size(144, 22);
            this.miDeleteTree.Text = "Delete Tree";
            this.miDeleteTree.Click += new System.EventHandler(this.miDeleteTree_Click);
            // 
            // shtView
            // 
            this.shtView.Reset();
            this.shtView.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtView.ColumnCount = 10;
            this.shtView.RowCount = 0;
            this.shtView.AutoCalculation = false;
            this.shtView.AutoGenerateColumns = false;
            this.shtView.ColumnHeader.Cells.Get(0, 0).Value = "Part No";
            this.shtView.ColumnHeader.Cells.Get(0, 1).Value = "Part Name";
            this.shtView.ColumnHeader.Cells.Get(0, 2).Value = "Part Class";
            this.shtView.ColumnHeader.Cells.Get(0, 3).Value = "Lot Control";
            this.shtView.ColumnHeader.Cells.Get(0, 4).Value = "Consumption";
            this.shtView.ColumnHeader.Cells.Get(0, 5).Value = "Seq";
            this.shtView.ColumnHeader.Cells.Get(0, 6).Value = "Parent Rate";
            this.shtView.ColumnHeader.Cells.Get(0, 7).Value = "Child Rate";
            this.shtView.ColumnHeader.Cells.Get(0, 8).Value = "Child Loc.";
            this.shtView.ColumnHeader.Cells.Get(0, 9).Value = "MRP Flag";
            this.shtView.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtView.Columns.Get(0).CellType = textCellType1;
            this.shtView.Columns.Get(0).Label = "Part No";
            this.shtView.Columns.Get(0).Tag = "Part No";
            this.shtView.Columns.Get(0).Width = 240F;
            this.shtView.Columns.Get(1).CellType = textCellType2;
            this.shtView.Columns.Get(1).Label = "Part Name";
            this.shtView.Columns.Get(1).Tag = "Part Name";
            this.shtView.Columns.Get(1).Width = 180F;
            this.shtView.Columns.Get(2).CellType = textCellType3;
            this.shtView.Columns.Get(2).Label = "Part Class";
            this.shtView.Columns.Get(2).Tag = "Part Class";
            this.shtView.Columns.Get(2).Width = 120F;
            this.shtView.Columns.Get(3).CellType = checkBoxCellType1;
            this.shtView.Columns.Get(3).Label = "Lot Control";
            this.shtView.Columns.Get(3).Tag = "Lot Control";
            this.shtView.Columns.Get(3).Width = 110F;
            this.shtView.Columns.Get(4).Label = "Consumption";
            this.shtView.Columns.Get(4).Tag = "Consumption";
            this.shtView.Columns.Get(4).Width = 110F;
            numberCellType1.DecimalPlaces = 0;
            this.shtView.Columns.Get(5).CellType = numberCellType1;
            this.shtView.Columns.Get(5).Label = "Seq";
            this.shtView.Columns.Get(5).Tag = "Seq";
            this.shtView.Columns.Get(5).Width = 75F;
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
            currencyCellType1.ShowCurrencySymbol = false;
            currencyCellType1.ShowSeparator = true;
            this.shtView.Columns.Get(6).CellType = currencyCellType1;
            this.shtView.Columns.Get(6).Label = "Parent Rate";
            this.shtView.Columns.Get(6).Tag = "Parent Rate";
            this.shtView.Columns.Get(6).Width = 75F;
            currencyCellType2.DecimalPlaces = 6;
            currencyCellType2.DecimalSeparator = ".";
            currencyCellType2.FixedPoint = false;
            currencyCellType2.MaximumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            393216});
            currencyCellType2.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            currencyCellType2.ShowCurrencySymbol = false;
            currencyCellType2.ShowSeparator = true;
            this.shtView.Columns.Get(7).CellType = currencyCellType2;
            this.shtView.Columns.Get(7).Label = "Child Rate";
            this.shtView.Columns.Get(7).Tag = "Child Rate";
            this.shtView.Columns.Get(7).Width = 75F;
            this.shtView.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.shtView.Columns.Get(8).Label = "Child Loc.";
            this.shtView.Columns.Get(8).Locked = false;
            this.shtView.Columns.Get(8).Tag = "Child Loc.";
            this.shtView.Columns.Get(8).Width = 120F;
            this.shtView.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.shtView.Columns.Get(9).Label = "MRP Flag";
            this.shtView.Columns.Get(9).Tag = "MRP Flag";
            this.shtView.Columns.Get(9).Width = 142F;
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.Controls.Add(this.btnMoveUp);
            this.panel2.Controls.Add(this.btnMoveDown);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(44, 380);
            this.panel2.TabIndex = 43;
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMoveUp.AppearanceName = "";
            this.btnMoveUp.ControlID = null;
            this.btnMoveUp.Image = global::Rubik.Forms.Properties.Resources.UP_BTN;
            this.btnMoveUp.Location = new System.Drawing.Point(7, 137);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(31, 31);
            this.btnMoveUp.TabIndex = 41;
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMoveDown.AppearanceName = "";
            this.btnMoveDown.ControlID = null;
            this.btnMoveDown.Image = global::Rubik.Forms.Properties.Resources.DOWN_BTN;
            this.btnMoveDown.Location = new System.Drawing.Point(7, 174);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(31, 31);
            this.btnMoveDown.TabIndex = 42;
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // imgListStateNode
            // 
            this.imgListStateNode.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListStateNode.ImageStream")));
            this.imgListStateNode.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListStateNode.Images.SetKeyName(0, "BLANK");
            this.imgListStateNode.Images.SetKeyName(1, "PLUS");
            this.imgListStateNode.Images.SetKeyName(2, "MINUS");
            // 
            // tslControl
            // 
            this.tslControl.GripMargin = new System.Windows.Forms.Padding(0);
            this.tslControl.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tslControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave,
            this.tlsSeperator1,
            this.tsbCancel,
            this.tlsSeperator2});
            this.tslControl.Location = new System.Drawing.Point(0, 0);
            this.tslControl.Name = "tslControl";
            this.tslControl.Padding = new System.Windows.Forms.Padding(0);
            this.tslControl.Size = new System.Drawing.Size(792, 28);
            this.tslControl.TabIndex = 2;
            this.tslControl.TabStop = true;
            // 
            // tsbSave
            // 
            this.tsbSave.Image = global::Rubik.Forms.Properties.Resources.SAVE;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Margin = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Padding = new System.Windows.Forms.Padding(2);
            this.tsbSave.Size = new System.Drawing.Size(55, 24);
            this.tsbSave.Text = "Save";
            this.tsbSave.ToolTipText = "Save";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tlsSeperator1
            // 
            this.tlsSeperator1.Name = "tlsSeperator1";
            this.tlsSeperator1.Size = new System.Drawing.Size(6, 28);
            // 
            // tsbCancel
            // 
            this.tsbCancel.Image = global::Rubik.Forms.Properties.Resources.CANCEL_ICON;
            this.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancel.Margin = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.tsbCancel.Name = "tsbCancel";
            this.tsbCancel.Padding = new System.Windows.Forms.Padding(2);
            this.tsbCancel.Size = new System.Drawing.Size(63, 24);
            this.tsbCancel.Text = "Cancel";
            this.tsbCancel.ToolTipText = "Cancel";
            this.tsbCancel.Click += new System.EventHandler(this.tsbCancel_Click);
            // 
            // tlsSeperator2
            // 
            this.tlsSeperator2.Name = "tlsSeperator2";
            this.tlsSeperator2.Size = new System.Drawing.Size(6, 28);
            // 
            // MAS050_BOMSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 489);
            this.Controls.Add(this.pnlContainerNew);
            this.Controls.Add(this.tslControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(690, 523);
            this.Name = "MAS050_BOMSetup";
            this.Text = "BOM Setup";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MAS050_BOMSetup_Load);
            this.Shown += new System.EventHandler(this.MAS050_BOMSetup_Shown);
            this.pnlContainerNew.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tlpHeader2.ResumeLayout(false);
            this.tlpHeader2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).EndInit();
            this.ctxMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tslControl.ResumeLayout(false);
            this.tslControl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private EVOLabel label4;
        private EVOFramework.Windows.Forms.EVOLabel stcItemDesc;
        private EVOFramework.Windows.Forms.EVOLabel stcItemCD;
        private Rubik.Forms.UserControl.ItemTextBox txtItemCD;
        private EVOFramework.Windows.Forms.EVOButton btnItemCD;
        private EVOFramework.Windows.Forms.EVOTextBox txtItemDesc;
        private System.Windows.Forms.TableLayoutPanel tlpHeader2;
        private EVOLabel stcBOMInformation;
        private System.Windows.Forms.Panel panel1;
        private FarPoint.Win.Spread.FpSpread fpView;
        private FarPoint.Win.Spread.SheetView shtView;
        private EVOFramework.Windows.Forms.EVOButton btnMoveDown;
        private EVOFramework.Windows.Forms.EVOButton btnMoveUp;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ImageList imgListStateNode;
        private System.Windows.Forms.ToolStripMenuItem miAddChildItem;
        private System.Windows.Forms.ToolStripMenuItem miEditItem;
        private System.Windows.Forms.ToolStripMenuItem miDeleteItem;
        private System.Windows.Forms.ToolStripMenuItem miDeleteTree;
        private EVOPanel pnlContainerNew;
        public System.Windows.Forms.ToolStrip tslControl;
        public System.Windows.Forms.ToolStripButton tsbSave;
        protected System.Windows.Forms.ToolStripSeparator tlsSeperator1;
        public System.Windows.Forms.ToolStripButton tsbCancel;
        protected System.Windows.Forms.ToolStripSeparator tlsSeperator2;
        private EVOLabel stcBOMSetup;
    }
}