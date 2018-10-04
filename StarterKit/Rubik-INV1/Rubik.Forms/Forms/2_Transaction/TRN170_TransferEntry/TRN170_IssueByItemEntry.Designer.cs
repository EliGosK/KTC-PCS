namespace Rubik.Transaction
{
    partial class TRN170_TransferEntry
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
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType2 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TRN170_TransferEntry));
            this.fpIssueList = new FarPoint.Win.Spread.FpSpread();
            this.cmsOperation = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shtIssueList = new FarPoint.Win.Spread.SheetView();
            this.evoLabel2 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel4 = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblToLoc = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblFromLoc = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboFromLoc = new EVOFramework.Windows.Forms.EVOComboBox();
            this.cboToLoc = new EVOFramework.Windows.Forms.EVOComboBox();
            this.txtRemark = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblSubType = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblRemark = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblForCustomer = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboSubType = new EVOFramework.Windows.Forms.EVOComboBox();
            this.cboForCustomer = new EVOFramework.Windows.Forms.EVOComboBox();
            this.txtJobOrderNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.txtRefDocNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblRefDocNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblJobOrderNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel5 = new EVOFramework.Windows.Forms.EVOLabel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoPanel1 = new EVOFramework.Windows.Forms.EVOPanel();
            this.label7 = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblIssueNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblIssueDate = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtIssueNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.dtIssueDate = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.lblIssueInformation = new EVOFramework.Windows.Forms.EVOLabel();
            this.dmcIssue = new EVOFramework.Data.UIDataModelController(this.components);
            this.evoPanel5 = new EVOFramework.Windows.Forms.EVOPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.btnMultiItem = new System.Windows.Forms.Button();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpIssueList)).BeginInit();
            this.cmsOperation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shtIssueList)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.evoPanel1.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.btnMultiItem);
            this.pnlContainer.Controls.Add(this.fpIssueList);
            this.pnlContainer.Controls.Add(this.tableLayoutPanel3);
            this.pnlContainer.Controls.Add(this.tableLayoutPanel7);
            this.pnlContainer.Controls.Add(this.dtIssueDate);
            this.pnlContainer.Controls.Add(this.txtRemark);
            this.pnlContainer.Controls.Add(this.lblRemark);
            this.pnlContainer.Controls.Add(this.lblIssueDate);
            this.pnlContainer.Controls.Add(this.lblIssueNo);
            this.pnlContainer.Controls.Add(this.txtIssueNo);
            this.pnlContainer.Controls.Add(this.cboToLoc);
            this.pnlContainer.Controls.Add(this.lblToLoc);
            this.pnlContainer.Controls.Add(this.evoLabel2);
            this.pnlContainer.Controls.Add(this.evoLabel4);
            this.pnlContainer.Controls.Add(this.lblFromLoc);
            this.pnlContainer.Controls.Add(this.evoPanel1);
            this.pnlContainer.Controls.Add(this.evoLabel5);
            this.pnlContainer.Controls.Add(this.lblSubType);
            this.pnlContainer.Controls.Add(this.cboSubType);
            this.pnlContainer.Controls.Add(this.lblRefDocNo);
            this.pnlContainer.Controls.Add(this.txtJobOrderNo);
            this.pnlContainer.Controls.Add(this.lblJobOrderNo);
            this.pnlContainer.Controls.Add(this.txtRefDocNo);
            this.pnlContainer.Controls.Add(this.lblForCustomer);
            this.pnlContainer.Controls.Add(this.cboForCustomer);
            this.pnlContainer.Controls.Add(this.cboFromLoc);
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlContainer.Size = new System.Drawing.Size(909, 702);
            // 
            // fpIssueList
            // 
            this.fpIssueList.About = "2.5.2015.2005";
            this.fpIssueList.AccessibleDescription = "fpIssueList, Sheet1";
            this.fpIssueList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fpIssueList.BackColor = System.Drawing.Color.AliceBlue;
            this.fpIssueList.ContextMenuStrip = this.cmsOperation;
            this.fpIssueList.EditModeReplace = true;
            this.fpIssueList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpIssueList.Location = new System.Drawing.Point(11, 300);
            this.fpIssueList.Name = "fpIssueList";
            this.fpIssueList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpIssueList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpIssueList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtIssueList});
            this.fpIssueList.Size = new System.Drawing.Size(883, 387);
            this.fpIssueList.TabIndex = 11;
            this.fpIssueList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpIssueList.EditModeOn += new System.EventHandler(this.fpIssueList_EditModeOn);
            this.fpIssueList.EditModeOff += new System.EventHandler(this.fpIssueList_EditModeOff);
            this.fpIssueList.LeaveCell += new FarPoint.Win.Spread.LeaveCellEventHandler(this.fpIssueList_LeaveCell);
            this.fpIssueList.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.fpIssueList_ButtonClicked);
            this.fpIssueList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpIssueList_KeyDown);
            this.fpIssueList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fpIssueList_KeyUp);
            // 
            // cmsOperation
            // 
            this.cmsOperation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cmsOperation.Name = "cmsOperation";
            this.cmsOperation.Size = new System.Drawing.Size(106, 48);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // shtIssueList
            // 
            this.shtIssueList.Reset();
            this.shtIssueList.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtIssueList.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtIssueList.ColumnCount = 10;
            this.shtIssueList.RowCount = 0;
            this.shtIssueList.AutoGenerateColumns = false;
            this.shtIssueList.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.shtIssueList.ColumnHeader.Cells.Get(0, 0).Value = "Master No.";
            this.shtIssueList.ColumnHeader.Cells.Get(0, 1).Value = " ";
            this.shtIssueList.ColumnHeader.Cells.Get(0, 2).Value = "Part No.";
            this.shtIssueList.ColumnHeader.Cells.Get(0, 3).Value = "Part Name";
            this.shtIssueList.ColumnHeader.Cells.Get(0, 4).Value = "Lot No.";
            this.shtIssueList.ColumnHeader.Cells.Get(0, 5).Value = " ";
            this.shtIssueList.ColumnHeader.Cells.Get(0, 6).Value = "Transfer Qty";
            this.shtIssueList.ColumnHeader.Cells.Get(0, 7).Value = "On Hand Qty";
            this.shtIssueList.ColumnHeader.Rows.Get(0).Height = 40F;
            textCellType1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.shtIssueList.Columns.Get(0).CellType = textCellType1;
            this.shtIssueList.Columns.Get(0).Label = "Master No.";
            this.shtIssueList.Columns.Get(0).Tag = "Master No.";
            this.shtIssueList.Columns.Get(0).Width = 90F;
            buttonCellType1.Text = "...";
            this.shtIssueList.Columns.Get(1).CellType = buttonCellType1;
            this.shtIssueList.Columns.Get(1).Label = " ";
            this.shtIssueList.Columns.Get(1).Tag = "ITEM_CD_BTN";
            this.shtIssueList.Columns.Get(1).Width = 31F;
            this.shtIssueList.Columns.Get(2).Label = "Part No.";
            this.shtIssueList.Columns.Get(2).Tag = "Part No.";
            this.shtIssueList.Columns.Get(2).Width = 120F;
            this.shtIssueList.Columns.Get(3).CellType = textCellType2;
            this.shtIssueList.Columns.Get(3).Label = "Part Name";
            this.shtIssueList.Columns.Get(3).Tag = "Part Desc";
            this.shtIssueList.Columns.Get(3).Width = 120F;
            textCellType3.MaxLength = 30;
            this.shtIssueList.Columns.Get(4).CellType = textCellType3;
            this.shtIssueList.Columns.Get(4).Label = "Lot No.";
            this.shtIssueList.Columns.Get(4).Tag = "Lot No.";
            this.shtIssueList.Columns.Get(4).Width = 139F;
            buttonCellType2.Text = "...";
            this.shtIssueList.Columns.Get(5).CellType = buttonCellType2;
            this.shtIssueList.Columns.Get(5).Label = " ";
            this.shtIssueList.Columns.Get(5).Tag = "LOT_BTN";
            this.shtIssueList.Columns.Get(5).Width = 31F;
            numberCellType1.DecimalPlaces = 6;
            numberCellType1.FixedPoint = false;
            numberCellType1.MinimumValue = 0D;
            numberCellType1.ShowSeparator = true;
            this.shtIssueList.Columns.Get(6).CellType = numberCellType1;
            this.shtIssueList.Columns.Get(6).Label = "Transfer Qty";
            this.shtIssueList.Columns.Get(6).Tag = "Transfer Qty";
            this.shtIssueList.Columns.Get(6).Width = 120F;
            numberCellType2.DecimalPlaces = 6;
            numberCellType2.FixedPoint = false;
            numberCellType2.ShowSeparator = true;
            this.shtIssueList.Columns.Get(7).CellType = numberCellType2;
            this.shtIssueList.Columns.Get(7).Label = "On Hand Qty";
            this.shtIssueList.Columns.Get(7).Tag = "On Hand Qty";
            this.shtIssueList.Columns.Get(7).Width = 120F;
            this.shtIssueList.Columns.Get(8).Visible = false;
            this.shtIssueList.Columns.Get(9).Visible = false;
            this.shtIssueList.DataAutoCellTypes = false;
            this.shtIssueList.DataAutoHeadings = false;
            this.shtIssueList.DataAutoSizeColumns = false;
            this.shtIssueList.RowHeader.Columns.Default.Resizable = true;
            this.shtIssueList.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.shtIssueList.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpIssueList.SetActiveViewport(0, 1, 0);
            // 
            // evoLabel2
            // 
            this.evoLabel2.AppearanceName = "RequireText";
            this.evoLabel2.AutoSize = true;
            this.evoLabel2.ControlID = "";
            this.evoLabel2.Location = new System.Drawing.Point(10, 200);
            this.evoLabel2.Name = "evoLabel2";
            this.evoLabel2.PathString = null;
            this.evoLabel2.PathValue = "*";
            this.evoLabel2.Size = new System.Drawing.Size(18, 19);
            this.evoLabel2.TabIndex = 232331;
            this.evoLabel2.Text = "*";
            this.evoLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // evoLabel4
            // 
            this.evoLabel4.AppearanceName = "RequireText";
            this.evoLabel4.AutoSize = true;
            this.evoLabel4.ControlID = "";
            this.evoLabel4.Location = new System.Drawing.Point(10, 166);
            this.evoLabel4.Name = "evoLabel4";
            this.evoLabel4.PathString = null;
            this.evoLabel4.PathValue = "*";
            this.evoLabel4.Size = new System.Drawing.Size(18, 19);
            this.evoLabel4.TabIndex = 232331;
            this.evoLabel4.Text = "*";
            this.evoLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblToLoc
            // 
            this.lblToLoc.AppearanceName = "";
            this.lblToLoc.ControlID = "";
            this.lblToLoc.Location = new System.Drawing.Point(34, 193);
            this.lblToLoc.Name = "lblToLoc";
            this.lblToLoc.PathString = null;
            this.lblToLoc.PathValue = "To Loc";
            this.lblToLoc.Size = new System.Drawing.Size(75, 33);
            this.lblToLoc.TabIndex = 8;
            this.lblToLoc.Text = "To Loc";
            this.lblToLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFromLoc
            // 
            this.lblFromLoc.AppearanceName = "";
            this.lblFromLoc.ControlID = "";
            this.lblFromLoc.Location = new System.Drawing.Point(34, 159);
            this.lblFromLoc.Name = "lblFromLoc";
            this.lblFromLoc.PathString = null;
            this.lblFromLoc.PathValue = "From Loc";
            this.lblFromLoc.Size = new System.Drawing.Size(85, 33);
            this.lblFromLoc.TabIndex = 8;
            this.lblFromLoc.Text = "From Loc";
            this.lblFromLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboFromLoc
            // 
            this.cboFromLoc.AppearanceName = "";
            this.cboFromLoc.AppearanceReadOnlyName = "";
            this.cboFromLoc.ControlID = null;
            this.cboFromLoc.DropDownHeight = 180;
            this.cboFromLoc.FormattingEnabled = true;
            this.cboFromLoc.IntegralHeight = false;
            this.cboFromLoc.Location = new System.Drawing.Point(125, 162);
            this.cboFromLoc.Name = "cboFromLoc";
            this.cboFromLoc.PathString = "FROM_LOC_CD.Value";
            this.cboFromLoc.PathValue = null;
            this.cboFromLoc.Size = new System.Drawing.Size(613, 27);
            this.cboFromLoc.TabIndex = 7;
            this.cboFromLoc.SelectedValueChanged += new System.EventHandler(this.cboFromLoc_SelectedValueChanged);
            // 
            // cboToLoc
            // 
            this.cboToLoc.AppearanceName = "";
            this.cboToLoc.AppearanceReadOnlyName = "";
            this.cboToLoc.ControlID = null;
            this.cboToLoc.DropDownHeight = 180;
            this.cboToLoc.FormattingEnabled = true;
            this.cboToLoc.IntegralHeight = false;
            this.cboToLoc.Location = new System.Drawing.Point(125, 196);
            this.cboToLoc.Name = "cboToLoc";
            this.cboToLoc.PathString = "TO_LOC_CD.Value";
            this.cboToLoc.PathValue = null;
            this.cboToLoc.Size = new System.Drawing.Size(613, 27);
            this.cboToLoc.TabIndex = 8;
            // 
            // txtRemark
            // 
            this.txtRemark.AppearanceName = "";
            this.txtRemark.AppearanceReadOnlyName = "";
            this.txtRemark.ControlID = "";
            this.txtRemark.DisableRestrictChar = false;
            this.txtRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtRemark.HelpButton = null;
            this.txtRemark.Location = new System.Drawing.Point(125, 229);
            this.txtRemark.MaxLength = 255;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.PathString = "REMARK.Value";
            this.txtRemark.PathValue = "";
            this.txtRemark.Size = new System.Drawing.Size(613, 26);
            this.txtRemark.TabIndex = 10;
            this.txtRemark.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRemark_KeyPress);
            // 
            // lblSubType
            // 
            this.lblSubType.AppearanceName = "";
            this.lblSubType.ControlID = "";
            this.lblSubType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblSubType.Location = new System.Drawing.Point(34, 125);
            this.lblSubType.Name = "lblSubType";
            this.lblSubType.PathString = null;
            this.lblSubType.PathValue = "Sub Type";
            this.lblSubType.Size = new System.Drawing.Size(85, 34);
            this.lblSubType.TabIndex = 50;
            this.lblSubType.Text = "Sub Type";
            this.lblSubType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRemark
            // 
            this.lblRemark.AppearanceName = "";
            this.lblRemark.ControlID = "";
            this.lblRemark.Location = new System.Drawing.Point(34, 226);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.PathString = null;
            this.lblRemark.PathValue = "Remark";
            this.lblRemark.Size = new System.Drawing.Size(85, 31);
            this.lblRemark.TabIndex = 8;
            this.lblRemark.Text = "Remark";
            this.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblForCustomer
            // 
            this.lblForCustomer.AppearanceName = "";
            this.lblForCustomer.ControlID = "";
            this.lblForCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblForCustomer.Location = new System.Drawing.Point(294, 0);
            this.lblForCustomer.Name = "lblForCustomer";
            this.lblForCustomer.PathString = null;
            this.lblForCustomer.PathValue = "For Customer :";
            this.lblForCustomer.Size = new System.Drawing.Size(117, 34);
            this.lblForCustomer.TabIndex = 50;
            this.lblForCustomer.Text = "For Customer :";
            this.lblForCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblForCustomer.Visible = false;
            // 
            // cboSubType
            // 
            this.cboSubType.AppearanceName = "";
            this.cboSubType.AppearanceReadOnlyName = "";
            this.cboSubType.ControlID = null;
            this.cboSubType.DropDownHeight = 180;
            this.cboSubType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboSubType.FormattingEnabled = true;
            this.cboSubType.IntegralHeight = false;
            this.cboSubType.Location = new System.Drawing.Point(125, 128);
            this.cboSubType.Name = "cboSubType";
            this.cboSubType.PathString = "TRAN_SUB_CLS.Value";
            this.cboSubType.PathValue = null;
            this.cboSubType.Size = new System.Drawing.Size(613, 28);
            this.cboSubType.TabIndex = 2;
            this.cboSubType.SelectedValueChanged += new System.EventHandler(this.cboFromLoc_SelectedValueChanged);
            // 
            // cboForCustomer
            // 
            this.cboForCustomer.AppearanceName = "";
            this.cboForCustomer.AppearanceReadOnlyName = "";
            this.cboForCustomer.ControlID = "";
            this.cboForCustomer.DropDownHeight = 180;
            this.cboForCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboForCustomer.FormattingEnabled = true;
            this.cboForCustomer.IntegralHeight = false;
            this.cboForCustomer.Location = new System.Drawing.Point(394, 4);
            this.cboForCustomer.Name = "cboForCustomer";
            this.cboForCustomer.PathString = "FOR_CUSTOMER.Value";
            this.cboForCustomer.PathValue = null;
            this.cboForCustomer.Size = new System.Drawing.Size(46, 28);
            this.cboForCustomer.TabIndex = 7;
            this.cboForCustomer.Visible = false;
            // 
            // txtJobOrderNo
            // 
            this.txtJobOrderNo.AppearanceName = "";
            this.txtJobOrderNo.AppearanceReadOnlyName = "";
            this.txtJobOrderNo.ControlID = "";
            this.txtJobOrderNo.DisableRestrictChar = false;
            this.txtJobOrderNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtJobOrderNo.HelpButton = null;
            this.txtJobOrderNo.Location = new System.Drawing.Point(379, 34);
            this.txtJobOrderNo.MaxLength = 20;
            this.txtJobOrderNo.Name = "txtJobOrderNo";
            this.txtJobOrderNo.PathString = "REF_SLIP_NO.Value";
            this.txtJobOrderNo.PathValue = "";
            this.txtJobOrderNo.Size = new System.Drawing.Size(47, 26);
            this.txtJobOrderNo.TabIndex = 3;
            this.txtJobOrderNo.Visible = false;
            // 
            // txtRefDocNo
            // 
            this.txtRefDocNo.AppearanceName = "";
            this.txtRefDocNo.AppearanceReadOnlyName = "";
            this.txtRefDocNo.ControlID = "";
            this.txtRefDocNo.DisableRestrictChar = false;
            this.txtRefDocNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtRefDocNo.HelpButton = null;
            this.txtRefDocNo.Location = new System.Drawing.Point(520, 36);
            this.txtRefDocNo.MaxLength = 20;
            this.txtRefDocNo.Name = "txtRefDocNo";
            this.txtRefDocNo.PathString = "REF_SLIP_NO2.Value";
            this.txtRefDocNo.PathValue = "";
            this.txtRefDocNo.Size = new System.Drawing.Size(23, 26);
            this.txtRefDocNo.TabIndex = 4;
            this.txtRefDocNo.Visible = false;
            // 
            // lblRefDocNo
            // 
            this.lblRefDocNo.AppearanceName = "";
            this.lblRefDocNo.ControlID = "";
            this.lblRefDocNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblRefDocNo.Location = new System.Drawing.Point(294, 31);
            this.lblRefDocNo.Name = "lblRefDocNo";
            this.lblRefDocNo.PathString = null;
            this.lblRefDocNo.PathValue = "Ref Doc No. :";
            this.lblRefDocNo.Size = new System.Drawing.Size(77, 32);
            this.lblRefDocNo.TabIndex = 50;
            this.lblRefDocNo.Text = "Ref Doc No. :";
            this.lblRefDocNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRefDocNo.Visible = false;
            // 
            // lblJobOrderNo
            // 
            this.lblJobOrderNo.AppearanceName = "";
            this.lblJobOrderNo.ControlID = "";
            this.lblJobOrderNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblJobOrderNo.Location = new System.Drawing.Point(432, 36);
            this.lblJobOrderNo.Name = "lblJobOrderNo";
            this.lblJobOrderNo.PathString = null;
            this.lblJobOrderNo.PathValue = "Job Order No. :";
            this.lblJobOrderNo.Size = new System.Drawing.Size(92, 32);
            this.lblJobOrderNo.TabIndex = 50;
            this.lblJobOrderNo.Text = "Job Order No. :";
            this.lblJobOrderNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblJobOrderNo.Visible = false;
            // 
            // evoLabel5
            // 
            this.evoLabel5.AppearanceName = "RequireText";
            this.evoLabel5.AutoSize = true;
            this.evoLabel5.ControlID = "";
            this.evoLabel5.Location = new System.Drawing.Point(10, 133);
            this.evoLabel5.Name = "evoLabel5";
            this.evoLabel5.PathString = null;
            this.evoLabel5.PathValue = "*";
            this.evoLabel5.Size = new System.Drawing.Size(18, 19);
            this.evoLabel5.TabIndex = 232331;
            this.evoLabel5.Text = "*";
            this.evoLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel3.BackgroundImage")));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(12, 261);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(882, 33);
            this.tableLayoutPanel3.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AppearanceName = "Header";
            this.label2.AutoSize = true;
            this.label2.ControlID = "";
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label2.Name = "label2";
            this.label2.PathString = null;
            this.label2.PathValue = "Transfer List Information";
            this.label2.Size = new System.Drawing.Size(208, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Transfer List Information";
            // 
            // evoPanel1
            // 
            this.evoPanel1.AppearanceName = "";
            this.evoPanel1.Controls.Add(this.label7);
            this.evoPanel1.Location = new System.Drawing.Point(11, 13);
            this.evoPanel1.Name = "evoPanel1";
            this.evoPanel1.Size = new System.Drawing.Size(277, 50);
            this.evoPanel1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AppearanceName = "Title";
            this.label7.AutoSize = true;
            this.label7.ControlID = "";
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Tahoma", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.PathString = null;
            this.label7.PathValue = "Transfer Entry";
            this.label7.Size = new System.Drawing.Size(245, 39);
            this.label7.TabIndex = 37;
            this.label7.Text = "Transfer Entry";
            // 
            // lblIssueNo
            // 
            this.lblIssueNo.AppearanceName = "";
            this.lblIssueNo.ControlID = "";
            this.lblIssueNo.Location = new System.Drawing.Point(540, 13);
            this.lblIssueNo.Name = "lblIssueNo";
            this.lblIssueNo.PathString = null;
            this.lblIssueNo.PathValue = "Transfer No.:";
            this.lblIssueNo.Size = new System.Drawing.Size(100, 32);
            this.lblIssueNo.TabIndex = 1;
            this.lblIssueNo.Text = "Transfer No.:";
            this.lblIssueNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIssueDate
            // 
            this.lblIssueDate.AppearanceName = "";
            this.lblIssueDate.ControlID = "";
            this.lblIssueDate.Location = new System.Drawing.Point(540, 48);
            this.lblIssueDate.Name = "lblIssueDate";
            this.lblIssueDate.PathString = null;
            this.lblIssueDate.PathValue = "Transfer Date:";
            this.lblIssueDate.Size = new System.Drawing.Size(100, 31);
            this.lblIssueDate.TabIndex = 2;
            this.lblIssueDate.Text = "Transfer Date:";
            this.lblIssueDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtIssueNo
            // 
            this.txtIssueNo.AppearanceName = "";
            this.txtIssueNo.AppearanceReadOnlyName = "";
            this.txtIssueNo.ControlID = "";
            this.txtIssueNo.DisableRestrictChar = false;
            this.txtIssueNo.HelpButton = null;
            this.txtIssueNo.Location = new System.Drawing.Point(640, 13);
            this.txtIssueNo.Name = "txtIssueNo";
            this.txtIssueNo.PathString = "SLIP_NO.Value";
            this.txtIssueNo.PathValue = "";
            this.txtIssueNo.Size = new System.Drawing.Size(257, 27);
            this.txtIssueNo.TabIndex = 0;
            // 
            // dtIssueDate
            // 
            this.dtIssueDate.AppearanceName = "";
            this.dtIssueDate.AppearanceReadOnlyName = "";
            this.dtIssueDate.BackColor = System.Drawing.Color.Transparent;
            this.dtIssueDate.ControlID = "";
            this.dtIssueDate.Format = "dd/MM/yyyy";
            this.dtIssueDate.Location = new System.Drawing.Point(640, 48);
            this.dtIssueDate.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtIssueDate.Name = "dtIssueDate";
            this.dtIssueDate.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtIssueDate.NZValue")));
            this.dtIssueDate.PathString = "TRANS_DATE.Value";
            this.dtIssueDate.PathValue = ((object)(resources.GetObject("dtIssueDate.PathValue")));
            this.dtIssueDate.ReadOnly = false;
            this.dtIssueDate.ShowButton = true;
            this.dtIssueDate.Size = new System.Drawing.Size(257, 20);
            this.dtIssueDate.TabIndex = 1;
            this.dtIssueDate.Value = null;
            this.dtIssueDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtIssueDate_KeyPress);
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel7.BackgroundImage")));
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.Controls.Add(this.lblIssueInformation, 0, 0);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(11, 81);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(883, 32);
            this.tableLayoutPanel7.TabIndex = 12;
            // 
            // lblIssueInformation
            // 
            this.lblIssueInformation.AppearanceName = "Header";
            this.lblIssueInformation.AutoSize = true;
            this.lblIssueInformation.ControlID = "";
            this.lblIssueInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblIssueInformation.ForeColor = System.Drawing.Color.Navy;
            this.lblIssueInformation.Location = new System.Drawing.Point(0, 0);
            this.lblIssueInformation.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblIssueInformation.Name = "lblIssueInformation";
            this.lblIssueInformation.PathString = null;
            this.lblIssueInformation.PathValue = "Transfer Information";
            this.lblIssueInformation.Size = new System.Drawing.Size(176, 24);
            this.lblIssueInformation.TabIndex = 0;
            this.lblIssueInformation.Text = "Transfer Information";
            // 
            // evoPanel5
            // 
            this.evoPanel5.AppearanceName = "";
            this.evoPanel5.Location = new System.Drawing.Point(0, 0);
            this.evoPanel5.Name = "evoPanel5";
            this.evoPanel5.Size = new System.Drawing.Size(200, 100);
            this.evoPanel5.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel2.BackgroundImage")));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AppearanceName = "";
            this.label1.AutoSize = true;
            this.label1.ControlID = "";
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.PathString = null;
            this.label1.PathValue = "Issue List Information";
            this.label1.Size = new System.Drawing.Size(183, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Issue List Information";
            // 
            // btnMultiItem
            // 
            this.btnMultiItem.Location = new System.Drawing.Point(744, 228);
            this.btnMultiItem.Name = "btnMultiItem";
            this.btnMultiItem.Size = new System.Drawing.Size(150, 26);
            this.btnMultiItem.TabIndex = 232332;
            this.btnMultiItem.Text = "Add Multi Item";
            this.btnMultiItem.UseVisualStyleBackColor = true;
            this.btnMultiItem.Click += new System.EventHandler(this.button1_Click);
            // 
            // TRN170_TransferEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(909, 752);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TRN170_TransferEntry";
            this.Text = "Transfer Entry";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TRN170_Load);
            this.Controls.SetChildIndex(this.pnlContainer, 0);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpIssueList)).EndInit();
            this.cmsOperation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shtIssueList)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.evoPanel1.ResumeLayout(false);
            this.evoPanel1.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EVOFramework.Windows.Forms.EVOPanel evoPanel1;
        private EVOFramework.Windows.Forms.EVOLabel label7;
        private EVOFramework.Windows.Forms.EVOLabel lblIssueNo;
        private EVOFramework.Windows.Forms.EVOLabel lblIssueDate;
        private EVOFramework.Windows.Forms.EVOTextBox txtIssueNo;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtIssueDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private EVOFramework.Windows.Forms.EVOLabel lblIssueInformation;
        private EVOFramework.Data.UIDataModelController dmcIssue;
        private FarPoint.Win.Spread.FpSpread fpIssueList;
        private FarPoint.Win.Spread.SheetView shtIssueList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private EVOFramework.Windows.Forms.EVOLabel label2;
        private EVOFramework.Windows.Forms.EVOPanel evoPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private EVOFramework.Windows.Forms.EVOLabel label1;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel2;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel4;
        private EVOFramework.Windows.Forms.EVOLabel lblToLoc;
        private EVOFramework.Windows.Forms.EVOLabel lblFromLoc;
        private EVOFramework.Windows.Forms.EVOComboBox cboFromLoc;
        private EVOFramework.Windows.Forms.EVOComboBox cboToLoc;
        private EVOFramework.Windows.Forms.EVOTextBox txtRemark;
        private EVOFramework.Windows.Forms.EVOLabel lblRemark;
        private System.Windows.Forms.ContextMenuStrip cmsOperation;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private EVOFramework.Windows.Forms.EVOLabel lblSubType;
        private EVOFramework.Windows.Forms.EVOLabel lblJobOrderNo;
        private EVOFramework.Windows.Forms.EVOLabel lblRefDocNo;
        private EVOFramework.Windows.Forms.EVOLabel lblForCustomer;
        private EVOFramework.Windows.Forms.EVOComboBox cboSubType;
        private EVOFramework.Windows.Forms.EVOComboBox cboForCustomer;
        private EVOFramework.Windows.Forms.EVOTextBox txtJobOrderNo;
        private EVOFramework.Windows.Forms.EVOTextBox txtRefDocNo;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel5;
        private System.Windows.Forms.Button btnMultiItem;
    }
}
