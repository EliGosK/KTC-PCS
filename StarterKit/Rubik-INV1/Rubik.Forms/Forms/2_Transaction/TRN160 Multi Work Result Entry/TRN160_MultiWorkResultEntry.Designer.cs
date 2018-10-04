/*
 * Small Master: Type (Work Result, Re-Work)
 * 
 * Require field: Type, Shift, Item No, Order Loc, Stored Loc 
 * Disable field: WR Group No, Item Descripion, Child Item No
 * 
 * Condition ของการกรอกหน้า screen นี้  (เฉพาะ Type work Result)
 * - item นั้นจะต้องมี consumtion class เป็น manual 
 * - จะต้องมี child item แค่ 1 ตัวเท่านั้น 
 * 
 * Default: date=current, Type=Work Result
 * Step of Operation
 * - Type กดปุ่ม OK จากนั้น Disable Type
 * 
 * สำหรับ Work Result
 * - Shift -> Item No (Get Description, Order Loc, Stored Loc, Child Item No) -> Lot No แล้วกด ? -> Lock All Header and Load Detail
 * - ให้โหลด Detail จาก Inventory Onhand ตาม Child Item ณ Order Loc (เฉพาะที่ Qty > 0)
 * 
 * สำหรับ Rework
 * - Shift -> Item No (Get Description, Order Loc=Store Loc, Stored Loc, Child Item No=Item No) -> Lot No แล้วกด ? -> Lock All Header and Load Detail
 * - ให้โหลด Detail จาก Inventory Onhand ตาม Child Item ณ Order Loc (เฉพาะที่ Qty > 0, Lot ลงท้ายด้วย '#R')
 * 
 * การบันทึกข้อมูล (ใช้ process แบบ manual)
 * - ทำการบันทึกทีละ line ใน data grid พร้อมทั้ง gen transaction no 
 *     + Output = Item No, Lot No (ตาม Grid), Good Qty ใน Grid, Reserve Qty (set lot no = lot no ตาม grid + 'R'), NG Qty ตาม process ปกติ
 *                     - Reserve Qty ห้ามกรอกใน case ใน Re-work (disable)
 *     + Input  = Child Item No, Lot No (ตาม Grid), Consumtion Qty = Good + Reserve + NG)
 * Remark:
 * - Group No ถูก Gen การกรอก Work Result เป็น Group
 * 
 * หลังจากบันทึกข้อมูล
 * - ถ้าเลือก save and new ให้ default Type, shift, Item No, Order Loc, Stored Loc, Child Item No เป็นตัวเก่าให้
 * 
 * 
 * 
 * 
*/


namespace Rubik.Transaction
{
    partial class TRN160_MultiWorkResultEntry
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
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TRN160_MultiWorkResultEntry));
            this.cmsOperation = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dmc = new EVOFramework.Data.UIDataModelController(this.components);
            this.hiddenTransactionID = new EVOFramework.Windows.Forms.EVOLabel();
            this.hiddenNGTransactionID = new EVOFramework.Windows.Forms.EVOLabel();
            this.fpView = new FarPoint.Win.Spread.FpSpread();
            this.shtView = new FarPoint.Win.Spread.SheetView();
            this.lblShift = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboShiftCls = new EVOFramework.Windows.Forms.EVOComboBox();
            this.lblOrderLoc = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblWorkResultDate = new EVOFramework.Windows.Forms.EVOLabel();
            this.btnItemCode = new EVOFramework.Windows.Forms.EVOButton();
            this.lblItemCode = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblHead = new EVOFramework.Windows.Forms.EVOLabel();
            this.dtWorkResultDate = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.txtForMachine = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblForMachine = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboOrderLoc = new EVOFramework.Windows.Forms.EVOComboBox();
            this.cboStoredLoc = new EVOFramework.Windows.Forms.EVOComboBox();
            this.lblStoredLoc = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblLotNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtLotNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblRemark = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtRemark = new EVOFramework.Windows.Forms.EVOTextBox();
            this.btnGenerate = new EVOFramework.Windows.Forms.EVOButton();
            this.lblChildItem = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtChildItemNo = new EVOFramework.Windows.Forms.EVOComboBox();
            this.lblWRGroupNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtWRGroupNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.cboTypeCls = new EVOFramework.Windows.Forms.EVOComboBox();
            this.lblType = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtItemDesc = new EVOFramework.Windows.Forms.EVOTextBox();
            this.txtItemCode = new Rubik.Forms.UserControl.ItemTextBox();
            this.lblWorkOrderNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtWorkOrderNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.btnType = new EVOFramework.Windows.Forms.EVOButton();
            this.stcType = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcShift = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcItemNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcOrderLoc = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcStoreLoc = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcWRDate = new EVOFramework.Windows.Forms.EVOLabel();
            this.btnClear = new EVOFramework.Windows.Forms.EVOButton();
            this.lblOrderLocFromBOM = new System.Windows.Forms.Label();
            this.pnlContainer.SuspendLayout();
            this.cmsOperation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.lblOrderLocFromBOM);
            this.pnlContainer.Controls.Add(this.stcWRDate);
            this.pnlContainer.Controls.Add(this.stcStoreLoc);
            this.pnlContainer.Controls.Add(this.stcOrderLoc);
            this.pnlContainer.Controls.Add(this.stcItemNo);
            this.pnlContainer.Controls.Add(this.stcShift);
            this.pnlContainer.Controls.Add(this.stcType);
            this.pnlContainer.Controls.Add(this.txtWorkOrderNo);
            this.pnlContainer.Controls.Add(this.lblWorkOrderNo);
            this.pnlContainer.Controls.Add(this.txtItemDesc);
            this.pnlContainer.Controls.Add(this.lblItemCode);
            this.pnlContainer.Controls.Add(this.btnItemCode);
            this.pnlContainer.Controls.Add(this.txtItemCode);
            this.pnlContainer.Controls.Add(this.txtChildItemNo);
            this.pnlContainer.Controls.Add(this.txtRemark);
            this.pnlContainer.Controls.Add(this.lblRemark);
            this.pnlContainer.Controls.Add(this.txtLotNo);
            this.pnlContainer.Controls.Add(this.lblLotNo);
            this.pnlContainer.Controls.Add(this.txtWRGroupNo);
            this.pnlContainer.Controls.Add(this.lblWRGroupNo);
            this.pnlContainer.Controls.Add(this.txtForMachine);
            this.pnlContainer.Controls.Add(this.lblForMachine);
            this.pnlContainer.Controls.Add(this.dtWorkResultDate);
            this.pnlContainer.Controls.Add(this.lblChildItem);
            this.pnlContainer.Controls.Add(this.lblHead);
            this.pnlContainer.Controls.Add(this.btnClear);
            this.pnlContainer.Controls.Add(this.btnType);
            this.pnlContainer.Controls.Add(this.btnGenerate);
            this.pnlContainer.Controls.Add(this.lblWorkResultDate);
            this.pnlContainer.Controls.Add(this.lblStoredLoc);
            this.pnlContainer.Controls.Add(this.lblOrderLoc);
            this.pnlContainer.Controls.Add(this.lblType);
            this.pnlContainer.Controls.Add(this.lblShift);
            this.pnlContainer.Controls.Add(this.cboStoredLoc);
            this.pnlContainer.Controls.Add(this.cboOrderLoc);
            this.pnlContainer.Controls.Add(this.cboTypeCls);
            this.pnlContainer.Controls.Add(this.cboShiftCls);
            this.pnlContainer.Controls.Add(this.fpView);
            this.pnlContainer.Controls.Add(this.hiddenNGTransactionID);
            this.pnlContainer.Controls.Add(this.hiddenTransactionID);
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlContainer.Size = new System.Drawing.Size(950, 566);
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
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // hiddenTransactionID
            // 
            this.hiddenTransactionID.AppearanceName = "";
            this.hiddenTransactionID.AutoSize = true;
            this.hiddenTransactionID.ControlID = "";
            this.hiddenTransactionID.Location = new System.Drawing.Point(0, 0);
            this.hiddenTransactionID.Name = "hiddenTransactionID";
            this.hiddenTransactionID.PathString = "TransactionID.Value";
            this.hiddenTransactionID.PathValue = "";
            this.hiddenTransactionID.Size = new System.Drawing.Size(0, 19);
            this.hiddenTransactionID.TabIndex = 16;
            this.hiddenTransactionID.Visible = false;
            // 
            // hiddenNGTransactionID
            // 
            this.hiddenNGTransactionID.AppearanceName = "";
            this.hiddenNGTransactionID.AutoSize = true;
            this.hiddenNGTransactionID.ControlID = "";
            this.hiddenNGTransactionID.Location = new System.Drawing.Point(396, 236);
            this.hiddenNGTransactionID.Name = "hiddenNGTransactionID";
            this.hiddenNGTransactionID.PathString = "NGTransactionID.Value";
            this.hiddenNGTransactionID.PathValue = "";
            this.hiddenNGTransactionID.Size = new System.Drawing.Size(0, 19);
            this.hiddenNGTransactionID.TabIndex = 100001;
            this.hiddenNGTransactionID.Visible = false;
            // 
            // fpView
            // 
            this.fpView.About = "2.5.2015.2005";
            this.fpView.AccessibleDescription = "fpView, Sheet1, Row 0, Column 0, ";
            this.fpView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fpView.BackColor = System.Drawing.Color.AliceBlue;
            this.fpView.ContextMenuStrip = this.cmsOperation;
            this.fpView.EditModeReplace = true;
            this.fpView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.Location = new System.Drawing.Point(12, 245);
            this.fpView.Name = "fpView";
            this.fpView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtView});
            this.fpView.Size = new System.Drawing.Size(926, 308);
            this.fpView.TabIndex = 100001;
            this.fpView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpView_KeyDown);
            this.fpView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fpView_KeyUp_1);
            // 
            // shtView
            // 
            this.shtView.Reset();
            this.shtView.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtView.ColumnCount = 11;
            this.shtView.RowCount = 0;
            this.shtView.AutoCalculation = false;
            this.shtView.AutoGenerateColumns = false;
            this.shtView.ColumnHeader.Cells.Get(0, 0).Value = "WR No.";
            this.shtView.ColumnHeader.Cells.Get(0, 1).Value = "Lot No.";
            this.shtView.ColumnHeader.Cells.Get(0, 2).Value = "On hand Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 3).Value = "Good Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 4).Value = "Reserve Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 5).Value = "NG Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 6).Value = "GDTran ID";
            this.shtView.ColumnHeader.Cells.Get(0, 7).Value = "RS Tran ID";
            this.shtView.ColumnHeader.Cells.Get(0, 8).Value = "NG Tran ID";
            this.shtView.ColumnHeader.Cells.Get(0, 9).Value = "Consump Tran ID";
            this.shtView.ColumnHeader.Cells.Get(0, 10).Value = "NG Reason";
            this.shtView.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtView.Columns.Get(0).Label = "WR No.";
            this.shtView.Columns.Get(0).Tag = "WR No.";
            this.shtView.Columns.Get(0).Width = 100F;
            textCellType1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            textCellType1.MaxLength = 35;
            this.shtView.Columns.Get(1).CellType = textCellType1;
            this.shtView.Columns.Get(1).Label = "Lot No.";
            this.shtView.Columns.Get(1).Locked = true;
            this.shtView.Columns.Get(1).Tag = "Lot No.";
            this.shtView.Columns.Get(1).Width = 122F;
            numberCellType1.DecimalPlaces = 2;
            numberCellType1.DecimalSeparator = ".";
            numberCellType1.FixedPoint = false;
            numberCellType1.Separator = ",";
            numberCellType1.ShowSeparator = true;
            this.shtView.Columns.Get(2).CellType = numberCellType1;
            this.shtView.Columns.Get(2).Label = "On hand Qty";
            this.shtView.Columns.Get(2).Locked = false;
            this.shtView.Columns.Get(2).Tag = "On hand Qty";
            this.shtView.Columns.Get(2).Width = 122F;
            numberCellType2.DecimalPlaces = 2;
            numberCellType2.DecimalSeparator = ".";
            numberCellType2.FixedPoint = false;
            numberCellType2.MinimumValue = 0D;
            numberCellType2.Separator = ",";
            numberCellType2.ShowSeparator = true;
            this.shtView.Columns.Get(3).CellType = numberCellType2;
            this.shtView.Columns.Get(3).Label = "Good Qty";
            this.shtView.Columns.Get(3).Locked = false;
            this.shtView.Columns.Get(3).Tag = "Good Qty";
            this.shtView.Columns.Get(3).Width = 122F;
            numberCellType3.DecimalPlaces = 2;
            numberCellType3.DecimalSeparator = ".";
            numberCellType3.FixedPoint = false;
            numberCellType3.MinimumValue = 0D;
            numberCellType3.Separator = ",";
            numberCellType3.ShowSeparator = true;
            this.shtView.Columns.Get(4).CellType = numberCellType3;
            this.shtView.Columns.Get(4).Label = "Reserve Qty";
            this.shtView.Columns.Get(4).Locked = false;
            this.shtView.Columns.Get(4).Tag = "Reserve Qty";
            this.shtView.Columns.Get(4).Width = 122F;
            numberCellType4.DecimalPlaces = 2;
            numberCellType4.DecimalSeparator = ".";
            numberCellType4.FixedPoint = false;
            numberCellType4.MinimumValue = 0D;
            numberCellType4.Separator = ",";
            numberCellType4.ShowSeparator = true;
            this.shtView.Columns.Get(5).CellType = numberCellType4;
            this.shtView.Columns.Get(5).Label = "NG Qty";
            this.shtView.Columns.Get(5).Locked = false;
            this.shtView.Columns.Get(5).Tag = "NG Qty";
            this.shtView.Columns.Get(5).Width = 122F;
            this.shtView.Columns.Get(6).Label = "GDTran ID";
            this.shtView.Columns.Get(6).Visible = false;
            this.shtView.Columns.Get(6).Width = 100F;
            this.shtView.Columns.Get(7).Label = "RS Tran ID";
            this.shtView.Columns.Get(7).Visible = false;
            this.shtView.Columns.Get(7).Width = 100F;
            this.shtView.Columns.Get(8).Label = "NG Tran ID";
            this.shtView.Columns.Get(8).Visible = false;
            this.shtView.Columns.Get(8).Width = 100F;
            this.shtView.Columns.Get(9).Label = "Consump Tran ID";
            this.shtView.Columns.Get(9).Visible = false;
            this.shtView.Columns.Get(9).Width = 100F;
            this.shtView.Columns.Get(10).CellType = textCellType2;
            this.shtView.Columns.Get(10).Label = "NG Reason";
            this.shtView.Columns.Get(10).Tag = "NG Reason";
            this.shtView.Columns.Get(10).Width = 200F;
            this.shtView.DataAutoCellTypes = false;
            this.shtView.DataAutoHeadings = false;
            this.shtView.DataAutoSizeColumns = false;
            this.shtView.DefaultStyle.ForeColor = System.Drawing.Color.Blue;
            this.shtView.DefaultStyle.Locked = true;
            this.shtView.DefaultStyle.Parent = "DataAreaDefault";
            this.shtView.LockForeColor = System.Drawing.Color.Black;
            this.shtView.RowHeader.Columns.Default.Resizable = true;
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpView.SetActiveViewport(0, 1, 0);
            // 
            // lblShift
            // 
            this.lblShift.AppearanceName = "";
            this.lblShift.ControlID = "";
            this.lblShift.Location = new System.Drawing.Point(30, 76);
            this.lblShift.Name = "lblShift";
            this.lblShift.PathString = null;
            this.lblShift.PathValue = "Shift:";
            this.lblShift.Size = new System.Drawing.Size(118, 33);
            this.lblShift.TabIndex = 100002;
            this.lblShift.Text = "Shift:";
            this.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboShiftCls
            // 
            this.cboShiftCls.AppearanceName = "";
            this.cboShiftCls.AppearanceReadOnlyName = "";
            this.cboShiftCls.ControlID = "";
            this.cboShiftCls.DropDownHeight = 180;
            this.cboShiftCls.FormattingEnabled = true;
            this.cboShiftCls.IntegralHeight = false;
            this.cboShiftCls.Location = new System.Drawing.Point(170, 80);
            this.cboShiftCls.MaxLength = 50;
            this.cboShiftCls.Name = "cboShiftCls";
            this.cboShiftCls.PathString = "ShiftClass.Value";
            this.cboShiftCls.PathValue = null;
            this.cboShiftCls.Size = new System.Drawing.Size(250, 27);
            this.cboShiftCls.TabIndex = 2;
            // 
            // lblOrderLoc
            // 
            this.lblOrderLoc.AppearanceName = "";
            this.lblOrderLoc.ControlID = "";
            this.lblOrderLoc.Location = new System.Drawing.Point(501, 136);
            this.lblOrderLoc.Name = "lblOrderLoc";
            this.lblOrderLoc.PathString = null;
            this.lblOrderLoc.PathValue = "Order Loc:";
            this.lblOrderLoc.Size = new System.Drawing.Size(133, 33);
            this.lblOrderLoc.TabIndex = 100005;
            this.lblOrderLoc.Text = "Order Loc:";
            this.lblOrderLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWorkResultDate
            // 
            this.lblWorkResultDate.AppearanceName = "";
            this.lblWorkResultDate.ControlID = "";
            this.lblWorkResultDate.Location = new System.Drawing.Point(501, 47);
            this.lblWorkResultDate.Name = "lblWorkResultDate";
            this.lblWorkResultDate.PathString = null;
            this.lblWorkResultDate.PathValue = "Work Result Date:";
            this.lblWorkResultDate.Size = new System.Drawing.Size(138, 33);
            this.lblWorkResultDate.TabIndex = 100007;
            this.lblWorkResultDate.Text = "Work Result Date:";
            this.lblWorkResultDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnItemCode
            // 
            this.btnItemCode.AppearanceName = "";
            this.btnItemCode.AutoSize = true;
            this.btnItemCode.BackgroundImage = global::Rubik.Forms.Properties.Resources.VIEW;
            this.btnItemCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnItemCode.ControlID = null;
            this.btnItemCode.Location = new System.Drawing.Point(386, 109);
            this.btnItemCode.Name = "btnItemCode";
            this.btnItemCode.Size = new System.Drawing.Size(34, 29);
            this.btnItemCode.TabIndex = 4;
            this.btnItemCode.TabStop = false;
            this.btnItemCode.UseVisualStyleBackColor = true;
            // 
            // lblItemCode
            // 
            this.lblItemCode.AppearanceName = "";
            this.lblItemCode.ControlID = "";
            this.lblItemCode.Location = new System.Drawing.Point(30, 105);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.PathString = null;
            this.lblItemCode.PathValue = "Part No:";
            this.lblItemCode.Size = new System.Drawing.Size(118, 35);
            this.lblItemCode.TabIndex = 100009;
            this.lblItemCode.Text = "Part No:";
            this.lblItemCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHead
            // 
            this.lblHead.AppearanceName = "Title";
            this.lblHead.AutoSize = true;
            this.lblHead.ControlID = "";
            this.lblHead.Location = new System.Drawing.Point(7, 7);
            this.lblHead.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblHead.Name = "lblHead";
            this.lblHead.PathString = null;
            this.lblHead.PathValue = "Work Result Entry (Multi-line)";
            this.lblHead.Size = new System.Drawing.Size(218, 19);
            this.lblHead.TabIndex = 0;
            this.lblHead.Text = "Work Result Entry (Multi-line)";
            this.lblHead.Click += new System.EventHandler(this.stcHead_Click);
            // 
            // dtWorkResultDate
            // 
            this.dtWorkResultDate.AppearanceName = "";
            this.dtWorkResultDate.AppearanceReadOnlyName = "";
            this.dtWorkResultDate.BackColor = System.Drawing.Color.Transparent;
            this.dtWorkResultDate.ControlID = "";
            this.dtWorkResultDate.Format = "dd/MM/yyyy";
            this.dtWorkResultDate.Location = new System.Drawing.Point(640, 50);
            this.dtWorkResultDate.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtWorkResultDate.Name = "dtWorkResultDate";
            this.dtWorkResultDate.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtWorkResultDate.NZValue")));
            this.dtWorkResultDate.PathString = "WorkResultDate.Value";
            this.dtWorkResultDate.PathValue = ((object)(resources.GetObject("dtWorkResultDate.PathValue")));
            this.dtWorkResultDate.ReadOnly = false;
            this.dtWorkResultDate.ShowButton = true;
            this.dtWorkResultDate.Size = new System.Drawing.Size(250, 20);
            this.dtWorkResultDate.TabIndex = 10;
            this.dtWorkResultDate.Value = null;
            // 
            // txtForMachine
            // 
            this.txtForMachine.AppearanceName = "";
            this.txtForMachine.AppearanceReadOnlyName = "";
            this.txtForMachine.ControlID = "";
            this.txtForMachine.DisableRestrictChar = false;
            this.txtForMachine.HelpButton = null;
            this.txtForMachine.Location = new System.Drawing.Point(640, 20);
            this.txtForMachine.MaxLength = 20;
            this.txtForMachine.Name = "txtForMachine";
            this.txtForMachine.PathString = "ForMachine.Value";
            this.txtForMachine.PathValue = "";
            this.txtForMachine.Size = new System.Drawing.Size(250, 27);
            this.txtForMachine.TabIndex = 9;
            this.txtForMachine.Visible = false;
            // 
            // lblForMachine
            // 
            this.lblForMachine.AppearanceName = "";
            this.lblForMachine.ControlID = "";
            this.lblForMachine.Location = new System.Drawing.Point(501, 16);
            this.lblForMachine.Name = "lblForMachine";
            this.lblForMachine.PathString = null;
            this.lblForMachine.PathValue = "For Machine:";
            this.lblForMachine.Size = new System.Drawing.Size(133, 33);
            this.lblForMachine.TabIndex = 100012;
            this.lblForMachine.Text = "For Machine:";
            this.lblForMachine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblForMachine.Visible = false;
            // 
            // cboOrderLoc
            // 
            this.cboOrderLoc.AppearanceName = "";
            this.cboOrderLoc.AppearanceReadOnlyName = "";
            this.cboOrderLoc.ControlID = "";
            this.cboOrderLoc.DropDownHeight = 180;
            this.cboOrderLoc.FormattingEnabled = true;
            this.cboOrderLoc.IntegralHeight = false;
            this.cboOrderLoc.Location = new System.Drawing.Point(640, 139);
            this.cboOrderLoc.MaxLength = 50;
            this.cboOrderLoc.Name = "cboOrderLoc";
            this.cboOrderLoc.PathString = "OrderLoc.Value";
            this.cboOrderLoc.PathValue = null;
            this.cboOrderLoc.Size = new System.Drawing.Size(250, 27);
            this.cboOrderLoc.TabIndex = 13;
            // 
            // cboStoredLoc
            // 
            this.cboStoredLoc.AppearanceName = "";
            this.cboStoredLoc.AppearanceReadOnlyName = "";
            this.cboStoredLoc.ControlID = "";
            this.cboStoredLoc.DropDownHeight = 180;
            this.cboStoredLoc.FormattingEnabled = true;
            this.cboStoredLoc.IntegralHeight = false;
            this.cboStoredLoc.Location = new System.Drawing.Point(640, 169);
            this.cboStoredLoc.MaxLength = 50;
            this.cboStoredLoc.Name = "cboStoredLoc";
            this.cboStoredLoc.PathString = "StoredLoc.Value";
            this.cboStoredLoc.PathValue = null;
            this.cboStoredLoc.Size = new System.Drawing.Size(250, 27);
            this.cboStoredLoc.TabIndex = 14;
            // 
            // lblStoredLoc
            // 
            this.lblStoredLoc.AppearanceName = "";
            this.lblStoredLoc.ControlID = "";
            this.lblStoredLoc.Location = new System.Drawing.Point(501, 166);
            this.lblStoredLoc.Name = "lblStoredLoc";
            this.lblStoredLoc.PathString = null;
            this.lblStoredLoc.PathValue = "Stored Loc:";
            this.lblStoredLoc.Size = new System.Drawing.Size(133, 33);
            this.lblStoredLoc.TabIndex = 100005;
            this.lblStoredLoc.Text = "Stored Loc:";
            this.lblStoredLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLotNo
            // 
            this.lblLotNo.AppearanceName = "";
            this.lblLotNo.ControlID = "";
            this.lblLotNo.Location = new System.Drawing.Point(30, 196);
            this.lblLotNo.Name = "lblLotNo";
            this.lblLotNo.PathString = null;
            this.lblLotNo.PathValue = "Lot No:";
            this.lblLotNo.Size = new System.Drawing.Size(118, 33);
            this.lblLotNo.TabIndex = 100012;
            this.lblLotNo.Text = "Lot No:";
            this.lblLotNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLotNo
            // 
            this.txtLotNo.AppearanceName = "";
            this.txtLotNo.AppearanceReadOnlyName = "";
            this.txtLotNo.ControlID = "";
            this.txtLotNo.DisableRestrictChar = false;
            this.txtLotNo.HelpButton = null;
            this.txtLotNo.Location = new System.Drawing.Point(170, 200);
            this.txtLotNo.MaxLength = 50;
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.PathString = "LotNo.Value";
            this.txtLotNo.PathValue = "";
            this.txtLotNo.Size = new System.Drawing.Size(210, 27);
            this.txtLotNo.TabIndex = 7;
            // 
            // lblRemark
            // 
            this.lblRemark.AppearanceName = "";
            this.lblRemark.ControlID = "";
            this.lblRemark.Location = new System.Drawing.Point(501, 196);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.PathString = null;
            this.lblRemark.PathValue = "Remark:";
            this.lblRemark.Size = new System.Drawing.Size(133, 33);
            this.lblRemark.TabIndex = 100012;
            this.lblRemark.Text = "Remark:";
            this.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRemark
            // 
            this.txtRemark.AppearanceName = "";
            this.txtRemark.AppearanceReadOnlyName = "";
            this.txtRemark.ControlID = "";
            this.txtRemark.DisableRestrictChar = false;
            this.txtRemark.HelpButton = null;
            this.txtRemark.Location = new System.Drawing.Point(640, 199);
            this.txtRemark.MaxLength = 255;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.PathString = "Remark.Value";
            this.txtRemark.PathValue = "";
            this.txtRemark.Size = new System.Drawing.Size(250, 27);
            this.txtRemark.TabIndex = 15;
            // 
            // btnGenerate
            // 
            this.btnGenerate.AppearanceName = "";
            this.btnGenerate.AutoSize = true;
            this.btnGenerate.BackgroundImage = global::Rubik.Forms.Properties.Resources.REFRESH;
            this.btnGenerate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGenerate.ControlID = null;
            this.btnGenerate.Location = new System.Drawing.Point(386, 199);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(34, 29);
            this.btnGenerate.TabIndex = 8;
            this.btnGenerate.TabStop = false;
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lblChildItem
            // 
            this.lblChildItem.AppearanceName = "";
            this.lblChildItem.ControlID = "";
            this.lblChildItem.Location = new System.Drawing.Point(30, 165);
            this.lblChildItem.Name = "lblChildItem";
            this.lblChildItem.PathString = null;
            this.lblChildItem.PathValue = "Child Item No:";
            this.lblChildItem.Size = new System.Drawing.Size(118, 35);
            this.lblChildItem.TabIndex = 100009;
            this.lblChildItem.Text = "Child Item No:";
            this.lblChildItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtChildItemNo
            // 
            this.txtChildItemNo.AppearanceName = "";
            this.txtChildItemNo.AppearanceReadOnlyName = "";
            this.txtChildItemNo.ControlID = "";
            this.txtChildItemNo.DropDownHeight = 180;
            this.txtChildItemNo.IntegralHeight = false;
            this.txtChildItemNo.Location = new System.Drawing.Point(170, 170);
            this.txtChildItemNo.MaxLength = 50;
            this.txtChildItemNo.Name = "txtChildItemNo";
            this.txtChildItemNo.PathString = "ChildItemCode.Value";
            this.txtChildItemNo.PathValue = null;
            this.txtChildItemNo.Size = new System.Drawing.Size(250, 27);
            this.txtChildItemNo.TabIndex = 6;
            this.txtChildItemNo.TabStop = false;
            this.txtChildItemNo.SelectedValueChanged += new System.EventHandler(this.txtChildItemNo_SelectedValueChanged);
            // 
            // lblWRGroupNo
            // 
            this.lblWRGroupNo.AppearanceName = "";
            this.lblWRGroupNo.ControlID = "";
            this.lblWRGroupNo.Location = new System.Drawing.Point(501, 76);
            this.lblWRGroupNo.Name = "lblWRGroupNo";
            this.lblWRGroupNo.PathString = null;
            this.lblWRGroupNo.PathValue = "WR Group No:";
            this.lblWRGroupNo.Size = new System.Drawing.Size(133, 33);
            this.lblWRGroupNo.TabIndex = 100012;
            this.lblWRGroupNo.Text = "WR Group No:";
            this.lblWRGroupNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtWRGroupNo
            // 
            this.txtWRGroupNo.AppearanceName = "";
            this.txtWRGroupNo.AppearanceReadOnlyName = "";
            this.txtWRGroupNo.ControlID = "";
            this.txtWRGroupNo.DisableRestrictChar = false;
            this.txtWRGroupNo.HelpButton = null;
            this.txtWRGroupNo.Location = new System.Drawing.Point(640, 79);
            this.txtWRGroupNo.MaxLength = 20;
            this.txtWRGroupNo.Name = "txtWRGroupNo";
            this.txtWRGroupNo.PathString = "WorkResultGroupNo.Value";
            this.txtWRGroupNo.PathValue = "";
            this.txtWRGroupNo.Size = new System.Drawing.Size(250, 27);
            this.txtWRGroupNo.TabIndex = 11;
            // 
            // cboTypeCls
            // 
            this.cboTypeCls.AppearanceName = "";
            this.cboTypeCls.AppearanceReadOnlyName = "";
            this.cboTypeCls.ControlID = "";
            this.cboTypeCls.DropDownHeight = 180;
            this.cboTypeCls.FormattingEnabled = true;
            this.cboTypeCls.IntegralHeight = false;
            this.cboTypeCls.Location = new System.Drawing.Point(170, 50);
            this.cboTypeCls.MaxLength = 50;
            this.cboTypeCls.Name = "cboTypeCls";
            this.cboTypeCls.PathString = "TRAN_SUB_CLS.Value";
            this.cboTypeCls.PathValue = null;
            this.cboTypeCls.Size = new System.Drawing.Size(170, 27);
            this.cboTypeCls.TabIndex = 0;
            this.cboTypeCls.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboTypeCls_KeyPress);
            // 
            // lblType
            // 
            this.lblType.AppearanceName = "";
            this.lblType.ControlID = "";
            this.lblType.Location = new System.Drawing.Point(30, 46);
            this.lblType.Name = "lblType";
            this.lblType.PathString = null;
            this.lblType.PathValue = "Type:";
            this.lblType.Size = new System.Drawing.Size(118, 33);
            this.lblType.TabIndex = 100002;
            this.lblType.Text = "Type:";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtItemDesc
            // 
            this.txtItemDesc.AppearanceName = "";
            this.txtItemDesc.AppearanceReadOnlyName = "";
            this.txtItemDesc.ControlID = "";
            this.txtItemDesc.DisableRestrictChar = false;
            this.txtItemDesc.HelpButton = null;
            this.txtItemDesc.Location = new System.Drawing.Point(170, 140);
            this.txtItemDesc.MaxLength = 50;
            this.txtItemDesc.Name = "txtItemDesc";
            this.txtItemDesc.PathString = "ItemDesc.Value";
            this.txtItemDesc.PathValue = "";
            this.txtItemDesc.Size = new System.Drawing.Size(250, 27);
            this.txtItemDesc.TabIndex = 5;
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
            this.txtItemCode.Location = new System.Drawing.Point(170, 110);
            this.txtItemCode.Long = ((long)(0));
            this.txtItemCode.MaxDecimalPlaces = 0;
            this.txtItemCode.MaxLength = 50;
            this.txtItemCode.MaxWholeDigits = 10;
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.NegativeSign = '-';
            this.txtItemCode.PathString = "ItemCode.Value";
            this.txtItemCode.PathValue = "";
            this.txtItemCode.Prefix = "";
            this.txtItemCode.RangeMax = 9999999999D;
            this.txtItemCode.RangeMin = 0D;
            this.txtItemCode.SelectedCustomerData = null;
            this.txtItemCode.SelectedItemData = null;
            this.txtItemCode.SelectedItemProcessData = null;
            this.txtItemCode.Size = new System.Drawing.Size(210, 27);
            this.txtItemCode.SqlOperator = Rubik.eSqlOperator.In;
            this.txtItemCode.TabIndex = 3;
            this.txtItemCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtItemCode.KeyPressResult += new Rubik.Forms.UserControl.ItemFoundHandler(this.txtItemCode_KeyPressResult);
            // 
            // lblWorkOrderNo
            // 
            this.lblWorkOrderNo.AppearanceName = "";
            this.lblWorkOrderNo.ControlID = "";
            this.lblWorkOrderNo.Location = new System.Drawing.Point(501, 109);
            this.lblWorkOrderNo.Name = "lblWorkOrderNo";
            this.lblWorkOrderNo.PathString = null;
            this.lblWorkOrderNo.PathValue = "Work Order No:";
            this.lblWorkOrderNo.Size = new System.Drawing.Size(133, 33);
            this.lblWorkOrderNo.TabIndex = 100013;
            this.lblWorkOrderNo.Text = "Work Order No:";
            this.lblWorkOrderNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtWorkOrderNo
            // 
            this.txtWorkOrderNo.AppearanceName = "";
            this.txtWorkOrderNo.AppearanceReadOnlyName = "";
            this.txtWorkOrderNo.ControlID = "";
            this.txtWorkOrderNo.DisableRestrictChar = false;
            this.txtWorkOrderNo.HelpButton = null;
            this.txtWorkOrderNo.Location = new System.Drawing.Point(640, 109);
            this.txtWorkOrderNo.MaxLength = 20;
            this.txtWorkOrderNo.Name = "txtWorkOrderNo";
            this.txtWorkOrderNo.PathString = "WorkOrderNo.Value";
            this.txtWorkOrderNo.PathValue = "";
            this.txtWorkOrderNo.Size = new System.Drawing.Size(250, 27);
            this.txtWorkOrderNo.TabIndex = 12;
            // 
            // btnType
            // 
            this.btnType.AppearanceName = "";
            this.btnType.AutoSize = true;
            this.btnType.BackgroundImage = global::Rubik.Forms.Properties.Resources.REFRESH;
            this.btnType.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnType.ControlID = null;
            this.btnType.Location = new System.Drawing.Point(346, 49);
            this.btnType.Name = "btnType";
            this.btnType.Size = new System.Drawing.Size(34, 29);
            this.btnType.TabIndex = 1;
            this.btnType.TabStop = false;
            this.btnType.UseVisualStyleBackColor = true;
            this.btnType.Click += new System.EventHandler(this.btnType_Click);
            // 
            // stcType
            // 
            this.stcType.AppearanceName = "RequireText";
            this.stcType.AutoSize = true;
            this.stcType.ControlID = "";
            this.stcType.Location = new System.Drawing.Point(8, 54);
            this.stcType.Name = "stcType";
            this.stcType.PathString = null;
            this.stcType.PathValue = "*";
            this.stcType.Size = new System.Drawing.Size(18, 19);
            this.stcType.TabIndex = 100015;
            this.stcType.Text = "*";
            this.stcType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcShift
            // 
            this.stcShift.AppearanceName = "RequireText";
            this.stcShift.AutoSize = true;
            this.stcShift.ControlID = "";
            this.stcShift.Location = new System.Drawing.Point(8, 83);
            this.stcShift.Name = "stcShift";
            this.stcShift.PathString = null;
            this.stcShift.PathValue = "*";
            this.stcShift.Size = new System.Drawing.Size(18, 19);
            this.stcShift.TabIndex = 100015;
            this.stcShift.Text = "*";
            this.stcShift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcItemNo
            // 
            this.stcItemNo.AppearanceName = "RequireText";
            this.stcItemNo.AutoSize = true;
            this.stcItemNo.ControlID = "";
            this.stcItemNo.Location = new System.Drawing.Point(8, 112);
            this.stcItemNo.Name = "stcItemNo";
            this.stcItemNo.PathString = null;
            this.stcItemNo.PathValue = "*";
            this.stcItemNo.Size = new System.Drawing.Size(18, 19);
            this.stcItemNo.TabIndex = 100015;
            this.stcItemNo.Text = "*";
            this.stcItemNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcOrderLoc
            // 
            this.stcOrderLoc.AppearanceName = "RequireText";
            this.stcOrderLoc.AutoSize = true;
            this.stcOrderLoc.ControlID = "";
            this.stcOrderLoc.Location = new System.Drawing.Point(477, 143);
            this.stcOrderLoc.Name = "stcOrderLoc";
            this.stcOrderLoc.PathString = null;
            this.stcOrderLoc.PathValue = "*";
            this.stcOrderLoc.Size = new System.Drawing.Size(18, 19);
            this.stcOrderLoc.TabIndex = 100015;
            this.stcOrderLoc.Text = "*";
            this.stcOrderLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcStoreLoc
            // 
            this.stcStoreLoc.AppearanceName = "RequireText";
            this.stcStoreLoc.AutoSize = true;
            this.stcStoreLoc.ControlID = "";
            this.stcStoreLoc.Location = new System.Drawing.Point(477, 172);
            this.stcStoreLoc.Name = "stcStoreLoc";
            this.stcStoreLoc.PathString = null;
            this.stcStoreLoc.PathValue = "*";
            this.stcStoreLoc.Size = new System.Drawing.Size(18, 19);
            this.stcStoreLoc.TabIndex = 100015;
            this.stcStoreLoc.Text = "*";
            this.stcStoreLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcWRDate
            // 
            this.stcWRDate.AppearanceName = "RequireText";
            this.stcWRDate.AutoSize = true;
            this.stcWRDate.ControlID = "";
            this.stcWRDate.Location = new System.Drawing.Point(477, 54);
            this.stcWRDate.Name = "stcWRDate";
            this.stcWRDate.PathString = null;
            this.stcWRDate.PathValue = "*";
            this.stcWRDate.Size = new System.Drawing.Size(18, 19);
            this.stcWRDate.TabIndex = 100015;
            this.stcWRDate.Text = "*";
            this.stcWRDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClear
            // 
            this.btnClear.AppearanceName = "";
            this.btnClear.AutoSize = true;
            this.btnClear.BackgroundImage = global::Rubik.Forms.Properties.Resources.CLEAR;
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClear.ControlID = null;
            this.btnClear.Location = new System.Drawing.Point(386, 49);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(34, 29);
            this.btnClear.TabIndex = 1;
            this.btnClear.TabStop = false;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblOrderLocFromBOM
            // 
            this.lblOrderLocFromBOM.AutoSize = true;
            this.lblOrderLocFromBOM.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblOrderLocFromBOM.Location = new System.Drawing.Point(896, 142);
            this.lblOrderLocFromBOM.Name = "lblOrderLocFromBOM";
            this.lblOrderLocFromBOM.Size = new System.Drawing.Size(46, 19);
            this.lblOrderLocFromBOM.TabIndex = 100016;
            this.lblOrderLocFromBOM.Tag = "ใช้กรณีที่ Order Loc โหลดมาจาก BOM จะแสดง";
            this.lblOrderLocFromBOM.Text = "BOM";
            this.lblOrderLocFromBOM.Visible = false;
            // 
            // TRN160_MultiWorkResultEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(950, 616);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 396);
            this.Name = "TRN160_MultiWorkResultEntry";
            this.Text = "TRN160 Work Result Entry";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TRN160_FormClosed);
            this.Load += new System.EventHandler(this.TRN160_Load);
            this.Shown += new System.EventHandler(this.TRN160_Shown);
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
        private EVOFramework.Windows.Forms.EVOLabel hiddenTransactionID;
        private System.Windows.Forms.ContextMenuStrip cmsOperation;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private EVOFramework.Windows.Forms.EVOLabel hiddenNGTransactionID;
        private FarPoint.Win.Spread.FpSpread fpView;
        private FarPoint.Win.Spread.SheetView shtView;
        private Rubik.Forms.UserControl.ItemTextBox txtItemCode;
        private EVOFramework.Windows.Forms.EVOLabel lblShift;
        private EVOFramework.Windows.Forms.EVOComboBox cboShiftCls;
        private EVOFramework.Windows.Forms.EVOLabel lblOrderLoc;
        private EVOFramework.Windows.Forms.EVOLabel lblWorkResultDate;
        private EVOFramework.Windows.Forms.EVOButton btnItemCode;
        private EVOFramework.Windows.Forms.EVOLabel lblItemCode;
        private EVOFramework.Windows.Forms.EVOLabel lblHead;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtWorkResultDate;
        private EVOFramework.Windows.Forms.EVOTextBox txtForMachine;
        private EVOFramework.Windows.Forms.EVOLabel lblForMachine;
        private EVOFramework.Windows.Forms.EVOLabel lblStoredLoc;
        private EVOFramework.Windows.Forms.EVOComboBox cboStoredLoc;
        private EVOFramework.Windows.Forms.EVOComboBox cboOrderLoc;
        private EVOFramework.Windows.Forms.EVOTextBox txtLotNo;
        private EVOFramework.Windows.Forms.EVOLabel lblLotNo;
        private EVOFramework.Windows.Forms.EVOTextBox txtRemark;
        private EVOFramework.Windows.Forms.EVOLabel lblRemark;
        private EVOFramework.Windows.Forms.EVOButton btnGenerate;
        private EVOFramework.Windows.Forms.EVOComboBox txtChildItemNo;
        private EVOFramework.Windows.Forms.EVOLabel lblChildItem;
        private EVOFramework.Windows.Forms.EVOTextBox txtWRGroupNo;
        private EVOFramework.Windows.Forms.EVOLabel lblWRGroupNo;
        private EVOFramework.Windows.Forms.EVOLabel lblType;
        private EVOFramework.Windows.Forms.EVOComboBox cboTypeCls;
        private EVOFramework.Windows.Forms.EVOTextBox txtItemDesc;
        private EVOFramework.Windows.Forms.EVOLabel lblWorkOrderNo;
        private EVOFramework.Windows.Forms.EVOTextBox txtWorkOrderNo;
        private EVOFramework.Windows.Forms.EVOButton btnType;
        private EVOFramework.Windows.Forms.EVOLabel stcType;
        private EVOFramework.Windows.Forms.EVOLabel stcShift;
        private EVOFramework.Windows.Forms.EVOLabel stcItemNo;
        private EVOFramework.Windows.Forms.EVOLabel stcStoreLoc;
        private EVOFramework.Windows.Forms.EVOLabel stcOrderLoc;
        private EVOFramework.Windows.Forms.EVOLabel stcWRDate;
        private EVOFramework.Windows.Forms.EVOButton btnClear;
        private System.Windows.Forms.Label lblOrderLocFromBOM;
    }
}
