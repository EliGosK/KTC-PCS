namespace Rubik.Master
{
    partial class MAS051_RegisterBOM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAS051_RegisterBOM));
            this.txtUpperQty = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.txtLowerQty = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.txtItemDesc = new EVOFramework.Windows.Forms.EVOTextBox();
            this.stcLowerQty = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcUpperQty = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcItemDesc = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcItemCode = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtParentItemDesc = new EVOFramework.Windows.Forms.EVOTextBox();
            this.stcParentItemDesc = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcParentItemCode = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtParentItemCode = new EVOFramework.Windows.Forms.EVOTextBox();
            this.txtItemCode = new Rubik.Forms.UserControl.ItemTextBox();
            this.btnItemCode = new EVOFramework.Windows.Forms.EVOButton();
            this.tsControl = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tlsSeperator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.tlsSeperator2 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pnlContainer = new EVOFramework.Windows.Forms.EVOPanel();
            this.evoLabel3 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel2 = new EVOFramework.Windows.Forms.EVOLabel();
            this.chkMRPFlag = new EVOFramework.Windows.Forms.EVOCheckBox();
            this.chkChildOrderLoc = new EVOFramework.Windows.Forms.EVOCheckBox();
            this.cboMRPFlag = new EVOFramework.Windows.Forms.EVOComboBox();
            this.evoLabel1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboOrderLoc = new EVOFramework.Windows.Forms.EVOComboBox();
            this.stcChildOrderLoc = new EVOFramework.Windows.Forms.EVOLabel();
            this.tsControl.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUpperQty
            // 
            this.txtUpperQty.AllowNegative = false;
            this.txtUpperQty.AppearanceName = "DataEdit";
            this.txtUpperQty.AppearanceReadOnlyName = "DataReadOnly";
            this.txtUpperQty.ControlID = "";
            this.txtUpperQty.Decimal = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtUpperQty.DecimalPoint = '.';
            this.txtUpperQty.DigitsInGroup = 3;
            this.txtUpperQty.Double = 1D;
            this.txtUpperQty.FixDecimalPosition = false;
            this.txtUpperQty.Flags = 65536;
            this.txtUpperQty.GroupSeparator = ',';
            this.txtUpperQty.Int = 1;
            this.txtUpperQty.Location = new System.Drawing.Point(172, 154);
            this.txtUpperQty.Long = ((long)(1));
            this.txtUpperQty.MaxDecimalPlaces = 6;
            this.txtUpperQty.MaxLength = 10;
            this.txtUpperQty.MaxWholeDigits = 10;
            this.txtUpperQty.Name = "txtUpperQty";
            this.txtUpperQty.NegativeSign = '-';
            this.txtUpperQty.PathString = null;
            this.txtUpperQty.PathValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtUpperQty.Prefix = "";
            this.txtUpperQty.RangeMax = 1.7976931348623157E+308D;
            this.txtUpperQty.RangeMin = 1D;
            this.txtUpperQty.Size = new System.Drawing.Size(317, 27);
            this.txtUpperQty.TabIndex = 5;
            this.txtUpperQty.Text = "1";
            this.txtUpperQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtLowerQty
            // 
            this.txtLowerQty.AllowNegative = false;
            this.txtLowerQty.AppearanceName = "DataEdit";
            this.txtLowerQty.AppearanceReadOnlyName = "DataReadOnly";
            this.txtLowerQty.ControlID = "";
            this.txtLowerQty.Decimal = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtLowerQty.DecimalPoint = '.';
            this.txtLowerQty.DigitsInGroup = 3;
            this.txtLowerQty.Double = 1D;
            this.txtLowerQty.FixDecimalPosition = false;
            this.txtLowerQty.Flags = 65536;
            this.txtLowerQty.GroupSeparator = ',';
            this.txtLowerQty.Int = 1;
            this.txtLowerQty.Location = new System.Drawing.Point(172, 187);
            this.txtLowerQty.Long = ((long)(1));
            this.txtLowerQty.MaxDecimalPlaces = 6;
            this.txtLowerQty.MaxLength = 10;
            this.txtLowerQty.MaxWholeDigits = 10;
            this.txtLowerQty.Name = "txtLowerQty";
            this.txtLowerQty.NegativeSign = '-';
            this.txtLowerQty.PathString = null;
            this.txtLowerQty.PathValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtLowerQty.Prefix = "";
            this.txtLowerQty.RangeMax = 1.7976931348623157E+308D;
            this.txtLowerQty.RangeMin = 1D;
            this.txtLowerQty.Size = new System.Drawing.Size(317, 27);
            this.txtLowerQty.TabIndex = 6;
            this.txtLowerQty.Text = "1";
            this.txtLowerQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtItemDesc
            // 
            this.txtItemDesc.AppearanceName = "";
            this.txtItemDesc.AppearanceReadOnlyName = "";
            this.txtItemDesc.ControlID = "";
            this.txtItemDesc.DisableRestrictChar = false;
            this.txtItemDesc.HelpButton = null;
            this.txtItemDesc.Location = new System.Drawing.Point(172, 121);
            this.txtItemDesc.MaxLength = 100;
            this.txtItemDesc.Name = "txtItemDesc";
            this.txtItemDesc.PathString = null;
            this.txtItemDesc.PathValue = "";
            this.txtItemDesc.Size = new System.Drawing.Size(317, 27);
            this.txtItemDesc.TabIndex = 4;
            // 
            // stcLowerQty
            // 
            this.stcLowerQty.AccessibleName = "";
            this.stcLowerQty.AppearanceName = "";
            this.stcLowerQty.AutoSize = true;
            this.stcLowerQty.ControlID = "";
            this.stcLowerQty.Location = new System.Drawing.Point(31, 191);
            this.stcLowerQty.Margin = new System.Windows.Forms.Padding(3);
            this.stcLowerQty.Name = "stcLowerQty";
            this.stcLowerQty.PathString = null;
            this.stcLowerQty.PathValue = "Child Qty";
            this.stcLowerQty.Size = new System.Drawing.Size(75, 19);
            this.stcLowerQty.TabIndex = 7;
            this.stcLowerQty.Text = "Child Qty";
            // 
            // stcUpperQty
            // 
            this.stcUpperQty.AccessibleName = "";
            this.stcUpperQty.AppearanceName = "";
            this.stcUpperQty.AutoSize = true;
            this.stcUpperQty.ControlID = "";
            this.stcUpperQty.Location = new System.Drawing.Point(31, 158);
            this.stcUpperQty.Margin = new System.Windows.Forms.Padding(3);
            this.stcUpperQty.Name = "stcUpperQty";
            this.stcUpperQty.PathString = null;
            this.stcUpperQty.PathValue = "Parent Qty";
            this.stcUpperQty.Size = new System.Drawing.Size(84, 19);
            this.stcUpperQty.TabIndex = 6;
            this.stcUpperQty.Text = "Parent Qty";
            // 
            // stcItemDesc
            // 
            this.stcItemDesc.AccessibleName = "";
            this.stcItemDesc.AppearanceName = "";
            this.stcItemDesc.AutoSize = true;
            this.stcItemDesc.ControlID = "";
            this.stcItemDesc.Location = new System.Drawing.Point(31, 125);
            this.stcItemDesc.Margin = new System.Windows.Forms.Padding(3);
            this.stcItemDesc.Name = "stcItemDesc";
            this.stcItemDesc.PathString = null;
            this.stcItemDesc.PathValue = "Part Name";
            this.stcItemDesc.Size = new System.Drawing.Size(83, 19);
            this.stcItemDesc.TabIndex = 5;
            this.stcItemDesc.Text = "Part Name";
            // 
            // stcItemCode
            // 
            this.stcItemCode.AccessibleName = "";
            this.stcItemCode.AppearanceName = "";
            this.stcItemCode.AutoSize = true;
            this.stcItemCode.ControlID = "";
            this.stcItemCode.Location = new System.Drawing.Point(31, 92);
            this.stcItemCode.Margin = new System.Windows.Forms.Padding(3);
            this.stcItemCode.Name = "stcItemCode";
            this.stcItemCode.PathString = null;
            this.stcItemCode.PathValue = "Part No";
            this.stcItemCode.Size = new System.Drawing.Size(62, 19);
            this.stcItemCode.TabIndex = 4;
            this.stcItemCode.Text = "Part No";
            // 
            // txtParentItemDesc
            // 
            this.txtParentItemDesc.AppearanceName = "";
            this.txtParentItemDesc.AppearanceReadOnlyName = "";
            this.txtParentItemDesc.ControlID = "";
            this.txtParentItemDesc.DisableRestrictChar = false;
            this.txtParentItemDesc.HelpButton = null;
            this.txtParentItemDesc.Location = new System.Drawing.Point(172, 55);
            this.txtParentItemDesc.MaxLength = 100;
            this.txtParentItemDesc.Name = "txtParentItemDesc";
            this.txtParentItemDesc.PathString = null;
            this.txtParentItemDesc.PathValue = "";
            this.txtParentItemDesc.Size = new System.Drawing.Size(317, 27);
            this.txtParentItemDesc.TabIndex = 1;
            // 
            // stcParentItemDesc
            // 
            this.stcParentItemDesc.AccessibleName = "";
            this.stcParentItemDesc.AppearanceName = "";
            this.stcParentItemDesc.AutoSize = true;
            this.stcParentItemDesc.ControlID = "";
            this.stcParentItemDesc.Location = new System.Drawing.Point(31, 59);
            this.stcParentItemDesc.Margin = new System.Windows.Forms.Padding(3);
            this.stcParentItemDesc.Name = "stcParentItemDesc";
            this.stcParentItemDesc.PathString = null;
            this.stcParentItemDesc.PathValue = "Parent Item Name";
            this.stcParentItemDesc.Size = new System.Drawing.Size(138, 19);
            this.stcParentItemDesc.TabIndex = 2;
            this.stcParentItemDesc.Text = "Parent Item Name";
            // 
            // stcParentItemCode
            // 
            this.stcParentItemCode.AccessibleName = "";
            this.stcParentItemCode.AppearanceName = "";
            this.stcParentItemCode.AutoSize = true;
            this.stcParentItemCode.ControlID = "";
            this.stcParentItemCode.Location = new System.Drawing.Point(31, 26);
            this.stcParentItemCode.Margin = new System.Windows.Forms.Padding(3);
            this.stcParentItemCode.Name = "stcParentItemCode";
            this.stcParentItemCode.PathString = null;
            this.stcParentItemCode.PathValue = "Parent Item No";
            this.stcParentItemCode.Size = new System.Drawing.Size(117, 19);
            this.stcParentItemCode.TabIndex = 6;
            this.stcParentItemCode.Text = "Parent Item No";
            // 
            // txtParentItemCode
            // 
            this.txtParentItemCode.AppearanceName = "";
            this.txtParentItemCode.AppearanceReadOnlyName = "";
            this.txtParentItemCode.ControlID = "";
            this.txtParentItemCode.DisableRestrictChar = false;
            this.txtParentItemCode.HelpButton = null;
            this.txtParentItemCode.Location = new System.Drawing.Point(172, 22);
            this.txtParentItemCode.MaxLength = 50;
            this.txtParentItemCode.Name = "txtParentItemCode";
            this.txtParentItemCode.PathString = null;
            this.txtParentItemCode.PathValue = "";
            this.txtParentItemCode.Size = new System.Drawing.Size(317, 27);
            this.txtParentItemCode.TabIndex = 0;
            // 
            // txtItemCode
            // 
            this.txtItemCode.AllowNegative = true;
            this.txtItemCode.AppearanceName = "";
            this.txtItemCode.AppearanceReadOnlyName = "";
            this.txtItemCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtItemCode.CheckEmpty = true;
            this.txtItemCode.CheckExist = false;
            this.txtItemCode.CheckNotExist = true;
            this.txtItemCode.ControlID = "";
            this.txtItemCode.CustomerCode = null;
            this.txtItemCode.CustomerNameTextBox = null;
            this.txtItemCode.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtItemCode.DecimalPoint = '.';
            this.txtItemCode.DescriptionTextBox = this.txtItemDesc;
            this.txtItemCode.DigitsInGroup = 0;
            this.txtItemCode.Double = 0D;
            this.txtItemCode.FixDecimalPosition = true;
            this.txtItemCode.Flags = 0;
            this.txtItemCode.GroupSeparator = ',';
            this.txtItemCode.HelpButton = this.btnItemCode;
            this.txtItemCode.Int = 0;
            this.txtItemCode.ItemType = null;
            this.txtItemCode.Location = new System.Drawing.Point(172, 88);
            this.txtItemCode.Long = ((long)(0));
            this.txtItemCode.MaxDecimalPlaces = 0;
            this.txtItemCode.MaxLength = 50;
            this.txtItemCode.MaxWholeDigits = 10;
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.NegativeSign = '-';
            this.txtItemCode.PathString = null;
            this.txtItemCode.PathValue = "";
            this.txtItemCode.Prefix = "";
            this.txtItemCode.RangeMax = 9999999999D;
            this.txtItemCode.RangeMin = 0D;
            this.txtItemCode.SelectedCustomerData = null;
            this.txtItemCode.SelectedItemData = null;
            this.txtItemCode.SelectedItemProcessData = null;
            this.txtItemCode.Size = new System.Drawing.Size(317, 27);
            this.txtItemCode.SqlOperator = Rubik.eSqlOperator.NotIn;
            this.txtItemCode.TabIndex = 2;
            this.txtItemCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnItemCode
            // 
            this.btnItemCode.AppearanceName = "";
            this.btnItemCode.AutoSize = true;
            this.btnItemCode.BackgroundImage = global::Rubik.Forms.Properties.Resources.VIEW;
            this.btnItemCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnItemCode.ControlID = null;
            this.btnItemCode.Location = new System.Drawing.Point(495, 88);
            this.btnItemCode.Name = "btnItemCode";
            this.btnItemCode.Size = new System.Drawing.Size(26, 27);
            this.btnItemCode.TabIndex = 3;
            this.btnItemCode.TabStop = false;
            this.btnItemCode.UseVisualStyleBackColor = true;
            // 
            // tsControl
            // 
            this.tsControl.GripMargin = new System.Windows.Forms.Padding(0);
            this.tsControl.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tlsSeperator1,
            this.tsbCancel,
            this.tlsSeperator2});
            this.tsControl.Location = new System.Drawing.Point(0, 0);
            this.tsControl.Name = "tsControl";
            this.tsControl.Padding = new System.Windows.Forms.Padding(0);
            this.tsControl.Size = new System.Drawing.Size(533, 28);
            this.tsControl.TabIndex = 9999;
            this.tsControl.TabStop = true;
            // 
            // tsbAdd
            // 
            this.tsbAdd.Image = global::Rubik.Forms.Properties.Resources.ADD_ICON;
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Margin = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Padding = new System.Windows.Forms.Padding(2);
            this.tsbAdd.Size = new System.Drawing.Size(50, 24);
            this.tsbAdd.Text = "Add";
            this.tsbAdd.ToolTipText = "Add";
            this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
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
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 333);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(533, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pnlContainer
            // 
            this.pnlContainer.AccessibleName = "";
            this.pnlContainer.AppearanceName = "FormBGColor";
            this.pnlContainer.AutoSize = true;
            this.pnlContainer.Controls.Add(this.evoLabel3);
            this.pnlContainer.Controls.Add(this.evoLabel2);
            this.pnlContainer.Controls.Add(this.chkMRPFlag);
            this.pnlContainer.Controls.Add(this.chkChildOrderLoc);
            this.pnlContainer.Controls.Add(this.cboMRPFlag);
            this.pnlContainer.Controls.Add(this.evoLabel1);
            this.pnlContainer.Controls.Add(this.cboOrderLoc);
            this.pnlContainer.Controls.Add(this.stcChildOrderLoc);
            this.pnlContainer.Controls.Add(this.txtUpperQty);
            this.pnlContainer.Controls.Add(this.stcParentItemCode);
            this.pnlContainer.Controls.Add(this.stcParentItemDesc);
            this.pnlContainer.Controls.Add(this.txtLowerQty);
            this.pnlContainer.Controls.Add(this.txtParentItemDesc);
            this.pnlContainer.Controls.Add(this.txtParentItemCode);
            this.pnlContainer.Controls.Add(this.txtItemDesc);
            this.pnlContainer.Controls.Add(this.stcItemCode);
            this.pnlContainer.Controls.Add(this.txtItemCode);
            this.pnlContainer.Controls.Add(this.stcLowerQty);
            this.pnlContainer.Controls.Add(this.stcItemDesc);
            this.pnlContainer.Controls.Add(this.btnItemCode);
            this.pnlContainer.Controls.Add(this.stcUpperQty);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.pnlContainer.Location = new System.Drawing.Point(0, 28);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(533, 305);
            this.pnlContainer.TabIndex = 0;
            // 
            // evoLabel3
            // 
            this.evoLabel3.AccessibleName = "";
            this.evoLabel3.AppearanceName = "";
            this.evoLabel3.AutoSize = true;
            this.evoLabel3.ControlID = "";
            this.evoLabel3.ForeColor = System.Drawing.Color.Red;
            this.evoLabel3.Location = new System.Drawing.Point(7, 191);
            this.evoLabel3.Margin = new System.Windows.Forms.Padding(3);
            this.evoLabel3.Name = "evoLabel3";
            this.evoLabel3.PathString = null;
            this.evoLabel3.PathValue = "*";
            this.evoLabel3.Size = new System.Drawing.Size(18, 19);
            this.evoLabel3.TabIndex = 17;
            this.evoLabel3.Text = "*";
            // 
            // evoLabel2
            // 
            this.evoLabel2.AccessibleName = "";
            this.evoLabel2.AppearanceName = "";
            this.evoLabel2.AutoSize = true;
            this.evoLabel2.ControlID = "";
            this.evoLabel2.ForeColor = System.Drawing.Color.Red;
            this.evoLabel2.Location = new System.Drawing.Point(7, 158);
            this.evoLabel2.Margin = new System.Windows.Forms.Padding(3);
            this.evoLabel2.Name = "evoLabel2";
            this.evoLabel2.PathString = null;
            this.evoLabel2.PathValue = "*";
            this.evoLabel2.Size = new System.Drawing.Size(18, 19);
            this.evoLabel2.TabIndex = 16;
            this.evoLabel2.Text = "*";
            // 
            // chkMRPFlag
            // 
            this.chkMRPFlag.AppearanceName = "";
            this.chkMRPFlag.AutoSize = true;
            this.chkMRPFlag.Checked = true;
            this.chkMRPFlag.CheckedValue = null;
            this.chkMRPFlag.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMRPFlag.ControlID = null;
            this.chkMRPFlag.Location = new System.Drawing.Point(377, 257);
            this.chkMRPFlag.Name = "chkMRPFlag";
            this.chkMRPFlag.PathString = null;
            this.chkMRPFlag.PathValue = true;
            this.chkMRPFlag.Size = new System.Drawing.Size(154, 23);
            this.chkMRPFlag.TabIndex = 10;
            this.chkMRPFlag.Text = "Same as Item Ms ";
            this.chkMRPFlag.UnCheckedValue = null;
            this.chkMRPFlag.UseVisualStyleBackColor = true;
            this.chkMRPFlag.CheckedChanged += new System.EventHandler(this.chkMRPFlag_CheckedChanged);
            // 
            // chkChildOrderLoc
            // 
            this.chkChildOrderLoc.AppearanceName = "";
            this.chkChildOrderLoc.AutoSize = true;
            this.chkChildOrderLoc.Checked = true;
            this.chkChildOrderLoc.CheckedValue = null;
            this.chkChildOrderLoc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChildOrderLoc.ControlID = null;
            this.chkChildOrderLoc.Location = new System.Drawing.Point(377, 224);
            this.chkChildOrderLoc.Name = "chkChildOrderLoc";
            this.chkChildOrderLoc.PathString = null;
            this.chkChildOrderLoc.PathValue = true;
            this.chkChildOrderLoc.Size = new System.Drawing.Size(154, 23);
            this.chkChildOrderLoc.TabIndex = 8;
            this.chkChildOrderLoc.Text = "Same as Item Ms ";
            this.chkChildOrderLoc.UnCheckedValue = null;
            this.chkChildOrderLoc.UseVisualStyleBackColor = true;
            this.chkChildOrderLoc.CheckedChanged += new System.EventHandler(this.chkChildOrderLoc_CheckedChanged);
            // 
            // cboMRPFlag
            // 
            this.cboMRPFlag.AppearanceName = "";
            this.cboMRPFlag.AppearanceReadOnlyName = "";
            this.cboMRPFlag.ControlID = null;
            this.cboMRPFlag.DropDownHeight = 180;
            this.cboMRPFlag.FormattingEnabled = true;
            this.cboMRPFlag.IntegralHeight = false;
            this.cboMRPFlag.Location = new System.Drawing.Point(172, 253);
            this.cboMRPFlag.Name = "cboMRPFlag";
            this.cboMRPFlag.PathString = "MRP_FLAG.Value";
            this.cboMRPFlag.PathValue = null;
            this.cboMRPFlag.Size = new System.Drawing.Size(199, 27);
            this.cboMRPFlag.TabIndex = 9;
            // 
            // evoLabel1
            // 
            this.evoLabel1.AccessibleName = "";
            this.evoLabel1.AppearanceName = "";
            this.evoLabel1.AutoSize = true;
            this.evoLabel1.ControlID = "";
            this.evoLabel1.Location = new System.Drawing.Point(31, 257);
            this.evoLabel1.Margin = new System.Windows.Forms.Padding(3);
            this.evoLabel1.Name = "evoLabel1";
            this.evoLabel1.PathString = null;
            this.evoLabel1.PathValue = "MRP Flag";
            this.evoLabel1.Size = new System.Drawing.Size(74, 19);
            this.evoLabel1.TabIndex = 12;
            this.evoLabel1.Text = "MRP Flag";
            // 
            // cboOrderLoc
            // 
            this.cboOrderLoc.AppearanceName = "";
            this.cboOrderLoc.AppearanceReadOnlyName = "";
            this.cboOrderLoc.ControlID = null;
            this.cboOrderLoc.DropDownHeight = 180;
            this.cboOrderLoc.FormattingEnabled = true;
            this.cboOrderLoc.IntegralHeight = false;
            this.cboOrderLoc.Location = new System.Drawing.Point(172, 220);
            this.cboOrderLoc.Name = "cboOrderLoc";
            this.cboOrderLoc.PathString = "OrderLoc.Value";
            this.cboOrderLoc.PathValue = null;
            this.cboOrderLoc.Size = new System.Drawing.Size(199, 27);
            this.cboOrderLoc.TabIndex = 7;
            // 
            // stcChildOrderLoc
            // 
            this.stcChildOrderLoc.AccessibleName = "";
            this.stcChildOrderLoc.AppearanceName = "";
            this.stcChildOrderLoc.AutoSize = true;
            this.stcChildOrderLoc.ControlID = "";
            this.stcChildOrderLoc.Location = new System.Drawing.Point(31, 224);
            this.stcChildOrderLoc.Margin = new System.Windows.Forms.Padding(3);
            this.stcChildOrderLoc.Name = "stcChildOrderLoc";
            this.stcChildOrderLoc.PathString = null;
            this.stcChildOrderLoc.PathValue = "Child Order Loc";
            this.stcChildOrderLoc.Size = new System.Drawing.Size(120, 19);
            this.stcChildOrderLoc.TabIndex = 11;
            this.stcChildOrderLoc.Text = "Child Order Loc";
            // 
            // MAS051_RegisterBOM
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(533, 355);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tsControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(514, 300);
            this.Name = "MAS051_RegisterBOM";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Register Item to BOM Setup";
            this.Load += new System.EventHandler(this.MAS051_ReigsterBOM_Load);
            this.Shown += new System.EventHandler(this.MAS051_ReigsterBOM_Shown);
            this.tsControl.ResumeLayout(false);
            this.tsControl.PerformLayout();
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip tsControl;
        public System.Windows.Forms.ToolStripButton tsbAdd;
        public System.Windows.Forms.ToolStripSeparator tlsSeperator1;
        public System.Windows.Forms.ToolStripButton tsbCancel;
        public System.Windows.Forms.ToolStripSeparator tlsSeperator2;
        public System.Windows.Forms.StatusStrip statusStrip1;
        public EVOFramework.Windows.Forms.EVOLabel stcParentItemDesc;
        public EVOFramework.Windows.Forms.EVOLabel stcParentItemCode;
        public EVOFramework.Windows.Forms.EVOLabel stcLowerQty;
        public EVOFramework.Windows.Forms.EVOLabel stcUpperQty;
        public EVOFramework.Windows.Forms.EVOLabel stcItemDesc;
        public EVOFramework.Windows.Forms.EVOLabel stcItemCode;
        public EVOFramework.Windows.Forms.EVOTextBox txtParentItemDesc;
        public EVOFramework.Windows.Forms.EVOTextBox txtParentItemCode;
        public EVOFramework.Windows.Forms.EVOTextBox txtItemDesc;
        public Rubik.Forms.UserControl.ItemTextBox txtItemCode;
        public EVOFramework.Windows.Forms.EVOButton btnItemCode;
        public EVOFramework.Windows.Forms.EVONumericTextBox txtUpperQty;
        public EVOFramework.Windows.Forms.EVONumericTextBox txtLowerQty;
        public EVOFramework.Windows.Forms.EVOPanel pnlContainer;
        public EVOFramework.Windows.Forms.EVOLabel stcChildOrderLoc;
        public EVOFramework.Windows.Forms.EVOComboBox cboOrderLoc;
        public EVOFramework.Windows.Forms.EVOComboBox cboMRPFlag;
        public EVOFramework.Windows.Forms.EVOLabel evoLabel1;
        public EVOFramework.Windows.Forms.EVOCheckBox chkMRPFlag;
        public EVOFramework.Windows.Forms.EVOCheckBox chkChildOrderLoc;
        public EVOFramework.Windows.Forms.EVOLabel evoLabel3;
        public EVOFramework.Windows.Forms.EVOLabel evoLabel2;
    }
}