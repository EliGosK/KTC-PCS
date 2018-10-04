namespace Rubik.Inventory
{
    partial class INV030
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INV030));
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAddToList = new System.Windows.Forms.ToolStripButton();
            this.tsbClearAll = new System.Windows.Forms.ToolStripButton();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.cmsOperation = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.evoPanel1 = new EVOFramework.Windows.Forms.EVOPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new EVOFramework.Windows.Forms.EVOPanel();
            this.txtPartNo = new Rubik.Forms.UserControl.ItemTextBox();
            this.txtPartName = new EVOFramework.Windows.Forms.EVOTextBox();
            this.btnPartNo = new EVOFramework.Windows.Forms.EVOButton();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.panel5 = new EVOFramework.Windows.Forms.EVOPanel();
            this.label7 = new EVOFramework.Windows.Forms.EVOLabel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblHeader = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblPartNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblLotNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblNumberofCopies = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblLotSize = new EVOFramework.Windows.Forms.EVOLabel();
            this.fpView = new FarPoint.Win.Spread.FpSpread();
            this.shtView = new FarPoint.Win.Spread.SheetView();
            this.lblPartName = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtLotNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.txtLotSize = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.txtNumberofCopies = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.chkNoQty = new EVOFramework.Windows.Forms.EVOCheckBox();
            this.evoLabel7 = new EVOFramework.Windows.Forms.EVOLabel();
            this.btnClear = new EVOFramework.Windows.Forms.EVOButton();
            this.lblTagType = new EVOFramework.Windows.Forms.EVOLabel();
            this.panel1 = new EVOFramework.Windows.Forms.EVOPanel();
            this.rdoTagTypeRM = new EVOFramework.Windows.Forms.EVORadioButton();
            this.rdoTagTypeWIP = new EVOFramework.Windows.Forms.EVORadioButton();
            this.rdoTagTypeFG = new EVOFramework.Windows.Forms.EVORadioButton();
            this.toolStrip1.SuspendLayout();
            this.cmsOperation.SuspendLayout();
            this.evoPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddToList,
            this.tsbClearAll,
            this.tsbPrint});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(795, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAddToList
            // 
            this.tsbAddToList.Image = global::Rubik.Forms.Properties.Resources.ADD_TO_LIST;
            this.tsbAddToList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddToList.Name = "tsbAddToList";
            this.tsbAddToList.Size = new System.Drawing.Size(78, 22);
            this.tsbAddToList.Text = "Add to List";
            this.tsbAddToList.Click += new System.EventHandler(this.tsbAddToList_Click);
            // 
            // tsbClearAll
            // 
            this.tsbClearAll.Image = global::Rubik.Forms.Properties.Resources.CLEAR;
            this.tsbClearAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClearAll.Name = "tsbClearAll";
            this.tsbClearAll.Size = new System.Drawing.Size(66, 22);
            this.tsbClearAll.Text = "Clear All";
            this.tsbClearAll.Click += new System.EventHandler(this.tsbClearAll_Click);
            // 
            // tsbPrint
            // 
            this.tsbPrint.Image = global::Rubik.Forms.Properties.Resources.PRINT;
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(49, 22);
            this.tsbPrint.Text = "Print";
            this.tsbPrint.Click += new System.EventHandler(this.tsbPrint_Click);
            // 
            // cmsOperation
            // 
            this.cmsOperation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.cmsOperation.Name = "cmsOperation";
            this.cmsOperation.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // evoPanel1
            // 
            this.evoPanel1.AppearanceName = "FormBGColor";
            this.evoPanel1.Controls.Add(this.tableLayoutPanel1);
            this.evoPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.evoPanel1.Location = new System.Drawing.Point(0, 25);
            this.evoPanel1.Name = "evoPanel1";
            this.evoPanel1.Size = new System.Drawing.Size(795, 470);
            this.evoPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.52825F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.98292F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.93854F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.381297F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.49443F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.73622F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Controls.Add(this.panel4, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblPartNo, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblLotNo, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblNumberofCopies, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblLotSize, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.fpView, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.lblPartName, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtLotNo, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtPartName, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtLotSize, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtNumberofCopies, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.chkNoQty, 6, 4);
            this.tableLayoutPanel1.Controls.Add(this.evoLabel7, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnClear, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblTagType, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(795, 470);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.AppearanceName = "";
            this.panel4.Controls.Add(this.txtPartNo);
            this.panel4.Controls.Add(this.btnPartNo);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(159, 140);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(242, 32);
            this.panel4.TabIndex = 69;
            // 
            // txtPartNo
            // 
            this.txtPartNo.AllowNegative = true;
            this.txtPartNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPartNo.AppearanceName = "";
            this.txtPartNo.AppearanceReadOnlyName = "";
            this.txtPartNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPartNo.CheckEmpty = false;
            this.txtPartNo.CheckExist = false;
            this.txtPartNo.CheckNotExist = false;
            this.txtPartNo.ControlID = "";
            this.txtPartNo.CustomerCode = null;
            this.txtPartNo.CustomerNameTextBox = null;
            this.txtPartNo.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPartNo.DecimalPoint = '.';
            this.txtPartNo.DescriptionTextBox = this.txtPartName;
            this.txtPartNo.DigitsInGroup = 0;
            this.txtPartNo.Double = 0D;
            this.txtPartNo.FixDecimalPosition = true;
            this.txtPartNo.Flags = 0;
            this.txtPartNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtPartNo.GroupSeparator = ',';
            this.txtPartNo.HelpButton = this.btnPartNo;
            this.txtPartNo.Int = 0;
            this.txtPartNo.ItemType = null;
            this.txtPartNo.Location = new System.Drawing.Point(3, 1);
            this.txtPartNo.Long = ((long)(0));
            this.txtPartNo.MaxDecimalPlaces = 0;
            this.txtPartNo.MaxLength = 35;
            this.txtPartNo.MaxWholeDigits = 10;
            this.txtPartNo.Name = "txtPartNo";
            this.txtPartNo.NegativeSign = '-';
            this.txtPartNo.PathString = "ITEM_CD.Value";
            this.txtPartNo.PathValue = "";
            this.txtPartNo.Prefix = "";
            this.txtPartNo.RangeMax = 9999999999D;
            this.txtPartNo.RangeMin = 0D;
            this.txtPartNo.SelectedCustomerData = null;
            this.txtPartNo.SelectedItemData = null;
            this.txtPartNo.SelectedItemProcessData = null;
            this.txtPartNo.Size = new System.Drawing.Size(200, 26);
            this.txtPartNo.SqlOperator = Rubik.eSqlOperator.In;
            this.txtPartNo.TabIndex = 1;
            this.txtPartNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPartNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPartNo_KeyPress);
            // 
            // txtPartName
            // 
            this.txtPartName.AppearanceName = "";
            this.txtPartName.AppearanceReadOnlyName = "";
            this.tableLayoutPanel1.SetColumnSpan(this.txtPartName, 3);
            this.txtPartName.ControlID = "";
            this.txtPartName.DisableRestrictChar = false;
            this.txtPartName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPartName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtPartName.HelpButton = null;
            this.txtPartName.Location = new System.Drawing.Point(506, 143);
            this.txtPartName.Name = "txtPartName";
            this.txtPartName.PathString = null;
            this.txtPartName.PathValue = "";
            this.txtPartName.Size = new System.Drawing.Size(248, 26);
            this.txtPartName.TabIndex = 70;
            // 
            // btnPartNo
            // 
            this.btnPartNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPartNo.AppearanceName = "";
            this.btnPartNo.BackgroundImage = global::Rubik.Forms.Properties.Resources.VIEW;
            this.btnPartNo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPartNo.ControlID = null;
            this.btnPartNo.Location = new System.Drawing.Point(209, 0);
            this.btnPartNo.Name = "btnPartNo";
            this.btnPartNo.Size = new System.Drawing.Size(30, 26);
            this.btnPartNo.TabIndex = 232321;
            this.btnPartNo.TabStop = false;
            this.btnPartNo.UseVisualStyleBackColor = true;
            this.btnPartNo.Click += new System.EventHandler(this.btnPartNo_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel3.BackgroundImage")));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel3, 8);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 833F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 272);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(789, 27);
            this.tableLayoutPanel3.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AccessibleName = "Header";
            this.label1.AppearanceName = "";
            this.label1.AutoSize = true;
            this.label1.ControlID = "";
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.PathString = null;
            this.label1.PathValue = "Selected List for TAG Print";
            this.label1.Size = new System.Drawing.Size(228, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selected List for TAG Print";
            // 
            // panel5
            // 
            this.panel5.AppearanceName = "";
            this.tableLayoutPanel1.SetColumnSpan(this.panel5, 6);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(665, 58);
            this.panel5.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AccessibleName = "Title";
            this.label7.AppearanceName = "Title";
            this.label7.AutoSize = true;
            this.label7.ControlID = "";
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Tahoma", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.PathString = null;
            this.label7.PathValue = "TAG Card Printing";
            this.label7.Size = new System.Drawing.Size(303, 39);
            this.label7.TabIndex = 36;
            this.label7.Text = "TAG Card Printing";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel2.BackgroundImage")));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 8);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 833F));
            this.tableLayoutPanel2.Controls.Add(this.lblHeader, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 103);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(789, 34);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // lblHeader
            // 
            this.lblHeader.AccessibleName = "Header";
            this.lblHeader.AppearanceName = "Header";
            this.lblHeader.AutoSize = true;
            this.lblHeader.ControlID = "";
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblHeader.ForeColor = System.Drawing.Color.Navy;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.PathString = null;
            this.lblHeader.PathValue = "TAG Card Information";
            this.lblHeader.Size = new System.Drawing.Size(191, 24);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "TAG Card Information";
            // 
            // lblPartNo
            // 
            this.lblPartNo.AppearanceName = "";
            this.lblPartNo.ControlID = "";
            this.lblPartNo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPartNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPartNo.Location = new System.Drawing.Point(26, 140);
            this.lblPartNo.Name = "lblPartNo";
            this.lblPartNo.PathString = null;
            this.lblPartNo.PathValue = "Part No. :";
            this.lblPartNo.Size = new System.Drawing.Size(130, 27);
            this.lblPartNo.TabIndex = 16;
            this.lblPartNo.Text = "Part No. :";
            this.lblPartNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLotNo
            // 
            this.lblLotNo.AppearanceName = "";
            this.lblLotNo.ControlID = "";
            this.lblLotNo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLotNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblLotNo.Location = new System.Drawing.Point(26, 172);
            this.lblLotNo.Name = "lblLotNo";
            this.lblLotNo.PathString = null;
            this.lblLotNo.PathValue = "Lot No :";
            this.lblLotNo.Size = new System.Drawing.Size(130, 27);
            this.lblLotNo.TabIndex = 16;
            this.lblLotNo.Text = "Lot No :";
            this.lblLotNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNumberofCopies
            // 
            this.lblNumberofCopies.AppearanceName = "";
            this.lblNumberofCopies.ControlID = "";
            this.lblNumberofCopies.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNumberofCopies.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblNumberofCopies.Location = new System.Drawing.Point(26, 204);
            this.lblNumberofCopies.Name = "lblNumberofCopies";
            this.lblNumberofCopies.PathString = null;
            this.lblNumberofCopies.PathValue = "Number of Copies :";
            this.lblNumberofCopies.Size = new System.Drawing.Size(130, 29);
            this.lblNumberofCopies.TabIndex = 16;
            this.lblNumberofCopies.Text = "Number of Copies :";
            this.lblNumberofCopies.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLotSize
            // 
            this.lblLotSize.AppearanceName = "";
            this.lblLotSize.ControlID = "";
            this.lblLotSize.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLotSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblLotSize.Location = new System.Drawing.Point(404, 172);
            this.lblLotSize.Name = "lblLotSize";
            this.lblLotSize.PathString = null;
            this.lblLotSize.PathValue = "Lot Size :";
            this.lblLotSize.Size = new System.Drawing.Size(96, 30);
            this.lblLotSize.TabIndex = 16;
            this.lblLotSize.Text = "Lot Size :";
            this.lblLotSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fpView
            // 
            this.fpView.About = "2.5.2015.2005";
            this.fpView.AccessibleDescription = "fpView, Sheet1";
            this.fpView.BackColor = System.Drawing.Color.AliceBlue;
            this.tableLayoutPanel1.SetColumnSpan(this.fpView, 6);
            this.fpView.ContextMenuStrip = this.cmsOperation;
            this.fpView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.Location = new System.Drawing.Point(26, 305);
            this.fpView.Name = "fpView";
            this.fpView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtView});
            this.fpView.Size = new System.Drawing.Size(728, 153);
            this.fpView.TabIndex = 18;
            this.fpView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpView_KeyDown);
            // 
            // shtView
            // 
            this.shtView.Reset();
            this.shtView.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtView.ColumnCount = 6;
            this.shtView.RowCount = 0;
            this.shtView.AutoGenerateColumns = false;
            this.shtView.ColumnHeader.Cells.Get(0, 0).Value = "Part No.";
            this.shtView.ColumnHeader.Cells.Get(0, 1).Value = "Part Name";
            this.shtView.ColumnHeader.Cells.Get(0, 2).Value = "Part Type";
            this.shtView.ColumnHeader.Cells.Get(0, 3).Value = "Lot No.";
            this.shtView.ColumnHeader.Cells.Get(0, 4).Value = "Lot Size";
            this.shtView.ColumnHeader.Cells.Get(0, 5).Value = "Number of Copies";
            this.shtView.Columns.Get(0).Label = "Part No.";
            this.shtView.Columns.Get(0).Tag = "Part No.";
            this.shtView.Columns.Get(0).Width = 127F;
            this.shtView.Columns.Get(1).Label = "Part Name";
            this.shtView.Columns.Get(1).Tag = "Part Name";
            this.shtView.Columns.Get(1).Width = 127F;
            this.shtView.Columns.Get(2).Label = "Part Type";
            this.shtView.Columns.Get(2).Tag = "Part Type";
            this.shtView.Columns.Get(2).Width = 127F;
            this.shtView.Columns.Get(3).Label = "Lot No.";
            this.shtView.Columns.Get(3).Tag = "Lot No.";
            this.shtView.Columns.Get(3).Width = 127F;
            numberCellType1.DecimalPlaces = 6;
            numberCellType1.FixedPoint = false;
            this.shtView.Columns.Get(4).CellType = numberCellType1;
            this.shtView.Columns.Get(4).Label = "Lot Size";
            this.shtView.Columns.Get(4).Tag = "Lot Size";
            this.shtView.Columns.Get(4).Width = 94F;
            this.shtView.Columns.Get(5).Label = "Number of Copies";
            this.shtView.Columns.Get(5).Tag = "Number of Copies";
            this.shtView.Columns.Get(5).Width = 145F;
            this.shtView.DataAutoCellTypes = false;
            this.shtView.DataAutoHeadings = false;
            this.shtView.DataAutoSizeColumns = false;
            this.shtView.RowHeader.Columns.Default.Resizable = false;
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpView.SetActiveViewport(0, 1, 0);
            // 
            // lblPartName
            // 
            this.lblPartName.AppearanceName = "";
            this.lblPartName.ControlID = "";
            this.lblPartName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPartName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPartName.Location = new System.Drawing.Point(404, 140);
            this.lblPartName.Name = "lblPartName";
            this.lblPartName.PathString = null;
            this.lblPartName.PathValue = "Part Name :";
            this.lblPartName.Size = new System.Drawing.Size(96, 27);
            this.lblPartName.TabIndex = 16;
            this.lblPartName.Text = "Part Name :";
            this.lblPartName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLotNo
            // 
            this.txtLotNo.AppearanceName = "";
            this.txtLotNo.AppearanceReadOnlyName = "";
            this.txtLotNo.ControlID = "";
            this.txtLotNo.DisableRestrictChar = false;
            this.txtLotNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLotNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtLotNo.HelpButton = null;
            this.txtLotNo.Location = new System.Drawing.Point(162, 175);
            this.txtLotNo.MaxLength = 10;
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.PathString = null;
            this.txtLotNo.PathValue = "";
            this.txtLotNo.Size = new System.Drawing.Size(236, 26);
            this.txtLotNo.TabIndex = 2;
            this.txtLotNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLotNo_KeyPress);
            // 
            // txtLotSize
            // 
            this.txtLotSize.AllowNegative = true;
            this.txtLotSize.AppearanceName = "";
            this.txtLotSize.AppearanceReadOnlyName = "";
            this.tableLayoutPanel1.SetColumnSpan(this.txtLotSize, 2);
            this.txtLotSize.ControlID = "";
            this.txtLotSize.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtLotSize.DecimalPoint = '.';
            this.txtLotSize.DigitsInGroup = 3;
            this.txtLotSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLotSize.Double = 0D;
            this.txtLotSize.FixDecimalPosition = false;
            this.txtLotSize.Flags = 0;
            this.txtLotSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtLotSize.GroupSeparator = ',';
            this.txtLotSize.Int = 0;
            this.txtLotSize.Location = new System.Drawing.Point(506, 175);
            this.txtLotSize.Long = ((long)(0));
            this.txtLotSize.MaxDecimalPlaces = 4;
            this.txtLotSize.MaxWholeDigits = 9;
            this.txtLotSize.Name = "txtLotSize";
            this.txtLotSize.NegativeSign = '-';
            this.txtLotSize.PathString = null;
            this.txtLotSize.PathValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtLotSize.Prefix = "";
            this.txtLotSize.RangeMax = 1.7976931348623157E+308D;
            this.txtLotSize.RangeMin = -1.7976931348623157E+308D;
            this.txtLotSize.Size = new System.Drawing.Size(162, 26);
            this.txtLotSize.TabIndex = 70;
            this.txtLotSize.Text = "0";
            // 
            // txtNumberofCopies
            // 
            this.txtNumberofCopies.AllowNegative = true;
            this.txtNumberofCopies.AppearanceName = "";
            this.txtNumberofCopies.AppearanceReadOnlyName = "";
            this.txtNumberofCopies.ControlID = "";
            this.txtNumberofCopies.Decimal = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtNumberofCopies.DecimalPoint = '.';
            this.txtNumberofCopies.DigitsInGroup = 3;
            this.txtNumberofCopies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNumberofCopies.Double = 1D;
            this.txtNumberofCopies.FixDecimalPosition = false;
            this.txtNumberofCopies.Flags = 0;
            this.txtNumberofCopies.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtNumberofCopies.GroupSeparator = ',';
            this.txtNumberofCopies.Int = 1;
            this.txtNumberofCopies.Location = new System.Drawing.Point(162, 207);
            this.txtNumberofCopies.Long = ((long)(1));
            this.txtNumberofCopies.MaxDecimalPlaces = 0;
            this.txtNumberofCopies.MaxWholeDigits = 6;
            this.txtNumberofCopies.Name = "txtNumberofCopies";
            this.txtNumberofCopies.NegativeSign = '-';
            this.txtNumberofCopies.PathString = null;
            this.txtNumberofCopies.PathValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtNumberofCopies.Prefix = "";
            this.txtNumberofCopies.RangeMax = 1.7976931348623157E+308D;
            this.txtNumberofCopies.RangeMin = -1.7976931348623157E+308D;
            this.txtNumberofCopies.Size = new System.Drawing.Size(236, 26);
            this.txtNumberofCopies.TabIndex = 3;
            this.txtNumberofCopies.Text = "1";
            this.txtNumberofCopies.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNumberofCopies.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumberofCopies_KeyPress);
            // 
            // chkNoQty
            // 
            this.chkNoQty.AppearanceName = "";
            this.chkNoQty.CheckedValue = null;
            this.chkNoQty.ControlID = null;
            this.chkNoQty.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkNoQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkNoQty.Location = new System.Drawing.Point(674, 175);
            this.chkNoQty.Name = "chkNoQty";
            this.chkNoQty.PathString = null;
            this.chkNoQty.PathValue = false;
            this.chkNoQty.Size = new System.Drawing.Size(80, 24);
            this.chkNoQty.TabIndex = 72;
            this.chkNoQty.Text = "No Qty";
            this.chkNoQty.UnCheckedValue = null;
            this.chkNoQty.UseVisualStyleBackColor = true;
            this.chkNoQty.CheckedChanged += new System.EventHandler(this.chkNoQty_CheckedChanged);
            // 
            // evoLabel7
            // 
            this.evoLabel7.AppearanceName = "RequireText";
            this.evoLabel7.ControlID = "";
            this.evoLabel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.evoLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel7.Location = new System.Drawing.Point(3, 140);
            this.evoLabel7.Name = "evoLabel7";
            this.evoLabel7.PathString = null;
            this.evoLabel7.PathValue = "*";
            this.evoLabel7.Size = new System.Drawing.Size(17, 27);
            this.evoLabel7.TabIndex = 16;
            this.evoLabel7.Text = "*";
            this.evoLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClear
            // 
            this.btnClear.AppearanceName = "";
            this.btnClear.ControlID = null;
            this.btnClear.Location = new System.Drawing.Point(26, 239);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(94, 27);
            this.btnClear.TabIndex = 74;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblTagType
            // 
            this.lblTagType.AppearanceName = "";
            this.lblTagType.ControlID = "";
            this.lblTagType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblTagType.Location = new System.Drawing.Point(26, 64);
            this.lblTagType.Name = "lblTagType";
            this.lblTagType.PathString = null;
            this.lblTagType.PathValue = "TAG Type :";
            this.lblTagType.Size = new System.Drawing.Size(94, 30);
            this.lblTagType.TabIndex = 16;
            this.lblTagType.Text = "TAG Type :";
            this.lblTagType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.AppearanceName = "";
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 3);
            this.panel1.Controls.Add(this.rdoTagTypeRM);
            this.panel1.Controls.Add(this.rdoTagTypeWIP);
            this.panel1.Controls.Add(this.rdoTagTypeFG);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(159, 64);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(354, 36);
            this.panel1.TabIndex = 73;
            // 
            // rdoTagTypeRM
            // 
            this.rdoTagTypeRM.AppearanceName = "";
            this.rdoTagTypeRM.ControlID = null;
            this.rdoTagTypeRM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rdoTagTypeRM.Location = new System.Drawing.Point(192, 3);
            this.rdoTagTypeRM.Name = "rdoTagTypeRM";
            this.rdoTagTypeRM.PathString = null;
            this.rdoTagTypeRM.Size = new System.Drawing.Size(122, 27);
            this.rdoTagTypeRM.SpecificValue = "2";
            this.rdoTagTypeRM.TabIndex = 2;
            this.rdoTagTypeRM.TabStop = true;
            this.rdoTagTypeRM.Text = "RM";
            this.rdoTagTypeRM.UseVisualStyleBackColor = true;
            this.rdoTagTypeRM.CheckedChanged += new System.EventHandler(this.rdoTagType_CheckedChanged);
            // 
            // rdoTagTypeWIP
            // 
            this.rdoTagTypeWIP.AppearanceName = "";
            this.rdoTagTypeWIP.ControlID = null;
            this.rdoTagTypeWIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rdoTagTypeWIP.Location = new System.Drawing.Point(94, 3);
            this.rdoTagTypeWIP.Name = "rdoTagTypeWIP";
            this.rdoTagTypeWIP.PathString = null;
            this.rdoTagTypeWIP.Size = new System.Drawing.Size(92, 27);
            this.rdoTagTypeWIP.SpecificValue = "1";
            this.rdoTagTypeWIP.TabIndex = 1;
            this.rdoTagTypeWIP.TabStop = true;
            this.rdoTagTypeWIP.Text = "WIP";
            this.rdoTagTypeWIP.UseVisualStyleBackColor = true;
            this.rdoTagTypeWIP.CheckedChanged += new System.EventHandler(this.rdoTagType_CheckedChanged);
            // 
            // rdoTagTypeFG
            // 
            this.rdoTagTypeFG.AppearanceName = "";
            this.rdoTagTypeFG.ControlID = null;
            this.rdoTagTypeFG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rdoTagTypeFG.Location = new System.Drawing.Point(3, 3);
            this.rdoTagTypeFG.Name = "rdoTagTypeFG";
            this.rdoTagTypeFG.PathString = null;
            this.rdoTagTypeFG.Size = new System.Drawing.Size(78, 27);
            this.rdoTagTypeFG.SpecificValue = "0";
            this.rdoTagTypeFG.TabIndex = 0;
            this.rdoTagTypeFG.TabStop = true;
            this.rdoTagTypeFG.Text = "FG";
            this.rdoTagTypeFG.UseVisualStyleBackColor = true;
            this.rdoTagTypeFG.CheckedChanged += new System.EventHandler(this.rdoTagType_CheckedChanged);
            // 
            // INV030
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(795, 495);
            this.Controls.Add(this.evoPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "INV030";
            this.Text = "TAG Card Printing";
            this.Load += new System.EventHandler(this.INV030_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.cmsOperation.ResumeLayout(false);
            this.evoPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAddToList;
        private System.Windows.Forms.ToolStripButton tsbClearAll;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ContextMenuStrip cmsOperation;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private EVOFramework.Windows.Forms.EVOPanel evoPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private EVOFramework.Windows.Forms.EVOPanel panel4;
        private Rubik.Forms.UserControl.ItemTextBox txtPartNo;
        private EVOFramework.Windows.Forms.EVOTextBox txtPartName;
        private EVOFramework.Windows.Forms.EVOButton btnPartNo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private EVOFramework.Windows.Forms.EVOLabel label1;
        private EVOFramework.Windows.Forms.EVOPanel panel5;
        private EVOFramework.Windows.Forms.EVOLabel label7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private EVOFramework.Windows.Forms.EVOLabel lblHeader;
        private EVOFramework.Windows.Forms.EVOLabel lblPartNo;
        private EVOFramework.Windows.Forms.EVOLabel lblLotNo;
        private EVOFramework.Windows.Forms.EVOLabel lblNumberofCopies;
        private EVOFramework.Windows.Forms.EVOLabel lblLotSize;
        private FarPoint.Win.Spread.FpSpread fpView;
        private FarPoint.Win.Spread.SheetView shtView;
        private EVOFramework.Windows.Forms.EVOLabel lblPartName;
        private EVOFramework.Windows.Forms.EVOTextBox txtLotNo;
        private EVOFramework.Windows.Forms.EVONumericTextBox txtLotSize;
        private EVOFramework.Windows.Forms.EVONumericTextBox txtNumberofCopies;
        private EVOFramework.Windows.Forms.EVOCheckBox chkNoQty;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel7;
        private EVOFramework.Windows.Forms.EVOButton btnClear;
        private EVOFramework.Windows.Forms.EVOLabel lblTagType;
        private EVOFramework.Windows.Forms.EVOPanel panel1;
        private EVOFramework.Windows.Forms.EVORadioButton rdoTagTypeRM;
        private EVOFramework.Windows.Forms.EVORadioButton rdoTagTypeWIP;
        private EVOFramework.Windows.Forms.EVORadioButton rdoTagTypeFG;
    }
}
