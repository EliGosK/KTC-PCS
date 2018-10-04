namespace Rubik.Transaction
{
    partial class TRN020
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TRN020));
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.CurrencyCellType currencyCellType1 = new FarPoint.Win.Spread.CellType.CurrencyCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.CurrencyCellType currencyCellType2 = new FarPoint.Win.Spread.CellType.CurrencyCellType();
            this.tableContainer = new System.Windows.Forms.TableLayoutPanel();
            this.stcHead = new EVOFramework.Windows.Forms.EVOLabel();
            this.pnlTitle = new EVOFramework.Windows.Forms.EVOPanel();
            this.tlpHeader2 = new System.Windows.Forms.TableLayoutPanel();
            this.stcReceiveInfo = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcReceiveType = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcPONo = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcReqStoreLoc = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcRemark = new EVOFramework.Windows.Forms.EVOLabel();
            this.pnlReceiveListInfo = new EVOFramework.Windows.Forms.EVOPanel();
            this.tableReceiveListInfo = new System.Windows.Forms.TableLayoutPanel();
            this.stcReceiveListInfo = new EVOFramework.Windows.Forms.EVOLabel();
            this.pnlView = new EVOFramework.Windows.Forms.EVOPanel();
            this.fpView = new FarPoint.Win.Spread.FpSpread();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.miDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.shtView = new FarPoint.Win.Spread.SheetView();
            this.pnlReceiveType = new EVOFramework.Windows.Forms.EVOPanel();
            this.rdoReceiveReturn = new EVOFramework.Windows.Forms.EVORadioButton();
            this.rdoReceive = new EVOFramework.Windows.Forms.EVORadioButton();
            this.txtPONo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.txtRemark = new EVOFramework.Windows.Forms.EVOTextBox();
            this.chkFilterItem = new EVOFramework.Windows.Forms.EVOCheckBox();
            this.tableHeader = new System.Windows.Forms.TableLayoutPanel();
            this.stcReceiveNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.stdReceiveDate = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblReceiveNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.dtReceiveDate = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.stcReqReceiveDate = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcStoredLoc = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboStoredLoc = new EVOFramework.Windows.Forms.EVOComboBox();
            this.stcInvoiceNo = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtInvoiceNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblSupplierCode = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboSupplierCode = new EVOFramework.Windows.Forms.EVOComboBox();
            this.stcReqSupplier = new EVOFramework.Windows.Forms.EVOLabel();
            this.dmcReceive = new EVOFramework.Data.UIDataModelController(this.components);
            this.pnlContainer.SuspendLayout();
            this.tableContainer.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            this.tlpHeader2.SuspendLayout();
            this.pnlReceiveListInfo.SuspendLayout();
            this.tableReceiveListInfo.SuspendLayout();
            this.pnlView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).BeginInit();
            this.ctxMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).BeginInit();
            this.pnlReceiveType.SuspendLayout();
            this.tableHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.tableContainer);
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlContainer.Size = new System.Drawing.Size(792, 516);
            // 
            // tableContainer
            // 
            this.tableContainer.ColumnCount = 4;
            this.tableContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 146F));
            this.tableContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 307F));
            this.tableContainer.Controls.Add(this.stcHead, 0, 0);
            this.tableContainer.Controls.Add(this.pnlTitle, 0, 1);
            this.tableContainer.Controls.Add(this.stcReceiveType, 1, 2);
            this.tableContainer.Controls.Add(this.stcPONo, 1, 6);
            this.tableContainer.Controls.Add(this.stcReqStoreLoc, 0, 5);
            this.tableContainer.Controls.Add(this.stcRemark, 1, 7);
            this.tableContainer.Controls.Add(this.pnlReceiveListInfo, 0, 8);
            this.tableContainer.Controls.Add(this.pnlView, 0, 9);
            this.tableContainer.Controls.Add(this.pnlReceiveType, 2, 2);
            this.tableContainer.Controls.Add(this.txtPONo, 2, 6);
            this.tableContainer.Controls.Add(this.txtRemark, 2, 7);
            this.tableContainer.Controls.Add(this.chkFilterItem, 3, 4);
            this.tableContainer.Controls.Add(this.tableHeader, 3, 0);
            this.tableContainer.Controls.Add(this.stcStoredLoc, 1, 5);
            this.tableContainer.Controls.Add(this.cboStoredLoc, 2, 5);
            this.tableContainer.Controls.Add(this.stcInvoiceNo, 1, 3);
            this.tableContainer.Controls.Add(this.txtInvoiceNo, 2, 3);
            this.tableContainer.Controls.Add(this.lblSupplierCode, 1, 4);
            this.tableContainer.Controls.Add(this.cboSupplierCode, 2, 4);
            this.tableContainer.Controls.Add(this.stcReqSupplier, 0, 4);
            this.tableContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableContainer.Location = new System.Drawing.Point(0, 0);
            this.tableContainer.Name = "tableContainer";
            this.tableContainer.RowCount = 10;
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableContainer.Size = new System.Drawing.Size(792, 516);
            this.tableContainer.TabIndex = 0;
            // 
            // stcHead
            // 
            this.stcHead.AppearanceName = "Title";
            this.stcHead.AutoSize = true;
            this.tableContainer.SetColumnSpan(this.stcHead, 3);
            this.stcHead.ControlID = "";
            this.stcHead.Font = new System.Drawing.Font("Tahoma", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.stcHead.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.stcHead.Location = new System.Drawing.Point(0, 0);
            this.stcHead.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.stcHead.Name = "stcHead";
            this.stcHead.PathString = null;
            this.stcHead.PathValue = "Receiving Entry";
            this.stcHead.Size = new System.Drawing.Size(268, 39);
            this.stcHead.TabIndex = 36;
            this.stcHead.Text = "Receiving Entry";
            // 
            // pnlTitle
            // 
            this.pnlTitle.AppearanceName = "";
            this.pnlTitle.AutoSize = true;
            this.tableContainer.SetColumnSpan(this.pnlTitle, 4);
            this.pnlTitle.Controls.Add(this.tlpHeader2);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 45);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(792, 24);
            this.pnlTitle.TabIndex = 3;
            // 
            // tlpHeader2
            // 
            this.tlpHeader2.AutoSize = true;
            this.tlpHeader2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tlpHeader2.BackgroundImage")));
            this.tlpHeader2.ColumnCount = 1;
            this.tlpHeader2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpHeader2.Controls.Add(this.stcReceiveInfo, 0, 0);
            this.tlpHeader2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHeader2.Location = new System.Drawing.Point(0, 0);
            this.tlpHeader2.Margin = new System.Windows.Forms.Padding(0);
            this.tlpHeader2.Name = "tlpHeader2";
            this.tlpHeader2.RowCount = 1;
            this.tlpHeader2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHeader2.Size = new System.Drawing.Size(792, 24);
            this.tlpHeader2.TabIndex = 9;
            // 
            // stcReceiveInfo
            // 
            this.stcReceiveInfo.AppearanceName = "Header";
            this.stcReceiveInfo.AutoSize = true;
            this.stcReceiveInfo.ControlID = "";
            this.stcReceiveInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.stcReceiveInfo.ForeColor = System.Drawing.Color.Navy;
            this.stcReceiveInfo.Location = new System.Drawing.Point(0, 0);
            this.stcReceiveInfo.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.stcReceiveInfo.Name = "stcReceiveInfo";
            this.stcReceiveInfo.PathString = null;
            this.stcReceiveInfo.PathValue = "Receiving Information";
            this.stcReceiveInfo.Size = new System.Drawing.Size(191, 24);
            this.stcReceiveInfo.TabIndex = 0;
            this.stcReceiveInfo.Text = "Receiving Information";
            // 
            // stcReceiveType
            // 
            this.stcReceiveType.AppearanceName = "";
            this.stcReceiveType.AutoSize = true;
            this.stcReceiveType.ControlID = "";
            this.stcReceiveType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stcReceiveType.Location = new System.Drawing.Point(33, 69);
            this.stcReceiveType.Name = "stcReceiveType";
            this.stcReceiveType.PathString = null;
            this.stcReceiveType.PathValue = "Receiving Type :";
            this.stcReceiveType.Size = new System.Drawing.Size(140, 30);
            this.stcReceiveType.TabIndex = 4;
            this.stcReceiveType.Text = "Receiving Type :";
            this.stcReceiveType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcPONo
            // 
            this.stcPONo.AppearanceName = "";
            this.stcPONo.AutoSize = true;
            this.stcPONo.ControlID = "";
            this.stcPONo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stcPONo.Location = new System.Drawing.Point(33, 198);
            this.stcPONo.Name = "stcPONo";
            this.stcPONo.PathString = null;
            this.stcPONo.PathValue = "PO No. :";
            this.stcPONo.Size = new System.Drawing.Size(140, 33);
            this.stcPONo.TabIndex = 6;
            this.stcPONo.Text = "PO No. :";
            this.stcPONo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcReqStoreLoc
            // 
            this.stcReqStoreLoc.AppearanceName = "RequireText";
            this.stcReqStoreLoc.AutoSize = true;
            this.stcReqStoreLoc.ControlID = "";
            this.stcReqStoreLoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stcReqStoreLoc.Location = new System.Drawing.Point(3, 165);
            this.stcReqStoreLoc.Name = "stcReqStoreLoc";
            this.stcReqStoreLoc.PathString = null;
            this.stcReqStoreLoc.PathValue = "*";
            this.stcReqStoreLoc.Size = new System.Drawing.Size(24, 33);
            this.stcReqStoreLoc.TabIndex = 3;
            this.stcReqStoreLoc.Text = "*";
            this.stcReqStoreLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stcRemark
            // 
            this.stcRemark.AppearanceName = "";
            this.stcRemark.AutoSize = true;
            this.stcRemark.ControlID = "";
            this.stcRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stcRemark.Location = new System.Drawing.Point(33, 231);
            this.stcRemark.Name = "stcRemark";
            this.stcRemark.PathString = null;
            this.stcRemark.PathValue = "Remark :";
            this.stcRemark.Size = new System.Drawing.Size(140, 33);
            this.stcRemark.TabIndex = 8;
            this.stcRemark.Text = "Remark :";
            this.stcRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlReceiveListInfo
            // 
            this.pnlReceiveListInfo.AppearanceName = "";
            this.pnlReceiveListInfo.AutoSize = true;
            this.tableContainer.SetColumnSpan(this.pnlReceiveListInfo, 4);
            this.pnlReceiveListInfo.Controls.Add(this.tableReceiveListInfo);
            this.pnlReceiveListInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlReceiveListInfo.Location = new System.Drawing.Point(0, 264);
            this.pnlReceiveListInfo.Margin = new System.Windows.Forms.Padding(0);
            this.pnlReceiveListInfo.Name = "pnlReceiveListInfo";
            this.pnlReceiveListInfo.Size = new System.Drawing.Size(792, 24);
            this.pnlReceiveListInfo.TabIndex = 11;
            // 
            // tableReceiveListInfo
            // 
            this.tableReceiveListInfo.AutoSize = true;
            this.tableReceiveListInfo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableReceiveListInfo.BackgroundImage")));
            this.tableReceiveListInfo.ColumnCount = 1;
            this.tableReceiveListInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableReceiveListInfo.Controls.Add(this.stcReceiveListInfo, 0, 0);
            this.tableReceiveListInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableReceiveListInfo.Location = new System.Drawing.Point(0, 0);
            this.tableReceiveListInfo.Margin = new System.Windows.Forms.Padding(0);
            this.tableReceiveListInfo.Name = "tableReceiveListInfo";
            this.tableReceiveListInfo.RowCount = 1;
            this.tableReceiveListInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableReceiveListInfo.Size = new System.Drawing.Size(792, 24);
            this.tableReceiveListInfo.TabIndex = 9;
            // 
            // stcReceiveListInfo
            // 
            this.stcReceiveListInfo.AppearanceName = "Header";
            this.stcReceiveListInfo.AutoSize = true;
            this.stcReceiveListInfo.ControlID = "";
            this.stcReceiveListInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.stcReceiveListInfo.ForeColor = System.Drawing.Color.Navy;
            this.stcReceiveListInfo.Location = new System.Drawing.Point(0, 0);
            this.stcReceiveListInfo.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.stcReceiveListInfo.Name = "stcReceiveListInfo";
            this.stcReceiveListInfo.PathString = null;
            this.stcReceiveListInfo.PathValue = "Receiving List Information";
            this.stcReceiveListInfo.Size = new System.Drawing.Size(223, 24);
            this.stcReceiveListInfo.TabIndex = 0;
            this.stcReceiveListInfo.Text = "Receiving List Information";
            // 
            // pnlView
            // 
            this.pnlView.AppearanceName = "";
            this.pnlView.AutoSize = true;
            this.tableContainer.SetColumnSpan(this.pnlView, 4);
            this.pnlView.Controls.Add(this.fpView);
            this.pnlView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlView.Location = new System.Drawing.Point(3, 291);
            this.pnlView.Name = "pnlView";
            this.pnlView.Size = new System.Drawing.Size(786, 222);
            this.pnlView.TabIndex = 7;
            // 
            // fpView
            // 
            this.fpView.About = "2.5.2015.2005";
            this.fpView.AccessibleDescription = "fpView, Sheet1";
            this.fpView.BackColor = System.Drawing.Color.AliceBlue;
            this.fpView.ContextMenuStrip = this.ctxMenu;
            this.fpView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpView.EditModeReplace = true;
            this.fpView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.Location = new System.Drawing.Point(0, 0);
            this.fpView.Name = "fpView";
            this.fpView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtView});
            this.fpView.Size = new System.Drawing.Size(786, 222);
            this.fpView.TabIndex = 0;
            this.fpView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.EditModeOn += new System.EventHandler(this.fpView_EditModeOn);
            this.fpView.EditModeOff += new System.EventHandler(this.fpView_EditModeOff);
            this.fpView.LeaveCell += new FarPoint.Win.Spread.LeaveCellEventHandler(this.fpView_LeaveCell);
            this.fpView.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.fpView_ButtonClicked);
            this.fpView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpView_KeyDown);
            this.fpView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fpView_KeyUp);
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAdd,
            this.miDelete});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(153, 70);
            // 
            // miAdd
            // 
            this.miAdd.Name = "miAdd";
            this.miAdd.Size = new System.Drawing.Size(152, 22);
            this.miAdd.Text = "Add";
            this.miAdd.Click += new System.EventHandler(this.miAdd_Click);
            // 
            // miDelete
            // 
            this.miDelete.Name = "miDelete";
            this.miDelete.Size = new System.Drawing.Size(152, 22);
            this.miDelete.Text = "Delete";
            this.miDelete.Click += new System.EventHandler(this.miDelete_Click);
            // 
            // shtView
            // 
            this.shtView.Reset();
            this.shtView.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtView.ColumnCount = 15;
            this.shtView.RowCount = 0;
            this.shtView.AutoCalculation = false;
            this.shtView.AutoGenerateColumns = false;
            this.shtView.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.shtView.ColumnHeader.Cells.Get(0, 0).Value = "Part No";
            this.shtView.ColumnHeader.Cells.Get(0, 2).Value = "Part Name";
            this.shtView.ColumnHeader.Cells.Get(0, 3).Value = "Lot No.";
            this.shtView.ColumnHeader.Cells.Get(0, 4).Value = "Supplier Lot No.";
            this.shtView.ColumnHeader.Cells.Get(0, 5).Value = "Receive Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 6).Value = "Lot Size";
            this.shtView.ColumnHeader.Cells.Get(0, 7).Value = "Price";
            this.shtView.ColumnHeader.Cells.Get(0, 8).Value = "Amount";
            this.shtView.ColumnHeader.Cells.Get(0, 9).Value = "Receive U/M";
            this.shtView.ColumnHeader.Cells.Get(0, 10).Value = "Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 11).Value = "U/M";
            this.shtView.ColumnHeader.Cells.Get(0, 12).Value = "ORDER_UM_RATE";
            this.shtView.ColumnHeader.Cells.Get(0, 13).Value = "INV_UM_RATE";
            this.shtView.ColumnHeader.Cells.Get(0, 14).Value = "Lot Control";
            this.shtView.ColumnHeader.Rows.Get(0).Height = 40F;
            textCellType1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.shtView.Columns.Get(0).CellType = textCellType1;
            this.shtView.Columns.Get(0).Label = "Part No";
            this.shtView.Columns.Get(0).Locked = true;
            this.shtView.Columns.Get(0).Tag = "Part No";
            this.shtView.Columns.Get(0).Width = 179F;
            buttonCellType1.ShadowSize = 0;
            buttonCellType1.Text = "...";
            this.shtView.Columns.Get(1).CellType = buttonCellType1;
            this.shtView.Columns.Get(1).Resizable = false;
            this.shtView.Columns.Get(1).Tag = "ITEM_CD_BTN";
            this.shtView.Columns.Get(1).Width = 25F;
            textCellType2.MaxLength = 50;
            this.shtView.Columns.Get(2).CellType = textCellType2;
            this.shtView.Columns.Get(2).Label = "Part Name";
            this.shtView.Columns.Get(2).Locked = true;
            this.shtView.Columns.Get(2).Tag = "Part Name";
            this.shtView.Columns.Get(2).Width = 167F;
            textCellType3.MaxLength = 30;
            this.shtView.Columns.Get(3).CellType = textCellType3;
            this.shtView.Columns.Get(3).Label = "Lot No.";
            this.shtView.Columns.Get(3).Tag = "Lot No";
            this.shtView.Columns.Get(3).Width = 114F;
            this.shtView.Columns.Get(4).Label = "Supplier Lot No.";
            this.shtView.Columns.Get(4).Tag = "Supplier Lot No.";
            this.shtView.Columns.Get(4).Width = 133F;
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
            currencyCellType1.Separator = ",";
            currencyCellType1.ShowCurrencySymbol = false;
            currencyCellType1.ShowSeparator = true;
            this.shtView.Columns.Get(5).CellType = currencyCellType1;
            this.shtView.Columns.Get(5).Label = "Receive Qty";
            this.shtView.Columns.Get(5).Locked = false;
            this.shtView.Columns.Get(5).Tag = "Receive Qty";
            this.shtView.Columns.Get(5).Width = 99F;
            this.shtView.Columns.Get(6).Label = "Lot Size";
            this.shtView.Columns.Get(6).Tag = "Lot Size";
            this.shtView.Columns.Get(6).Width = 71F;
            numberCellType1.Separator = ",";
            numberCellType1.ShowSeparator = true;
            this.shtView.Columns.Get(7).CellType = numberCellType1;
            this.shtView.Columns.Get(7).Label = "Price";
            this.shtView.Columns.Get(7).Tag = "Price";
            this.shtView.Columns.Get(7).Width = 81F;
            numberCellType2.Separator = ",";
            numberCellType2.ShowSeparator = true;
            this.shtView.Columns.Get(8).CellType = numberCellType2;
            this.shtView.Columns.Get(8).Label = "Amount";
            this.shtView.Columns.Get(8).Tag = "Amount";
            this.shtView.Columns.Get(8).Width = 116F;
            this.shtView.Columns.Get(9).Label = "Receive U/M";
            this.shtView.Columns.Get(9).Locked = true;
            this.shtView.Columns.Get(9).Tag = "Receive U/M";
            this.shtView.Columns.Get(9).Width = 122F;
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
            currencyCellType2.Separator = ",";
            currencyCellType2.ShowCurrencySymbol = false;
            currencyCellType2.ShowSeparator = true;
            this.shtView.Columns.Get(10).CellType = currencyCellType2;
            this.shtView.Columns.Get(10).Label = "Qty";
            this.shtView.Columns.Get(10).Locked = true;
            this.shtView.Columns.Get(10).Tag = "Qty";
            this.shtView.Columns.Get(10).Width = 77F;
            this.shtView.Columns.Get(11).Label = "U/M";
            this.shtView.Columns.Get(11).Locked = true;
            this.shtView.Columns.Get(11).Tag = "U/M";
            this.shtView.Columns.Get(11).Width = 88F;
            this.shtView.Columns.Get(12).Label = "ORDER_UM_RATE";
            this.shtView.Columns.Get(12).Tag = "ORDER_UM_RATE";
            this.shtView.Columns.Get(12).Visible = false;
            this.shtView.Columns.Get(13).Label = "INV_UM_RATE";
            this.shtView.Columns.Get(13).Tag = "INV_UM_RATE";
            this.shtView.Columns.Get(13).Visible = false;
            this.shtView.Columns.Get(14).Label = "Lot Control";
            this.shtView.Columns.Get(14).Tag = "Lot Control";
            this.shtView.Columns.Get(14).Visible = false;
            this.shtView.Columns.Get(14).Width = 70F;
            this.shtView.DataAutoCellTypes = false;
            this.shtView.DataAutoHeadings = false;
            this.shtView.DataAutoSizeColumns = false;
            this.shtView.DefaultStyle.ForeColor = System.Drawing.Color.Blue;
            this.shtView.DefaultStyle.Locked = true;
            this.shtView.DefaultStyle.Parent = "DataAreaDefault";
            this.shtView.LockForeColor = System.Drawing.Color.Black;
            this.shtView.RowHeader.Columns.Default.Resizable = true;
            this.shtView.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpView.SetActiveViewport(0, 1, 0);
            // 
            // pnlReceiveType
            // 
            this.pnlReceiveType.AppearanceName = "";
            this.pnlReceiveType.AutoSize = true;
            this.tableContainer.SetColumnSpan(this.pnlReceiveType, 2);
            this.pnlReceiveType.Controls.Add(this.rdoReceiveReturn);
            this.pnlReceiveType.Controls.Add(this.rdoReceive);
            this.pnlReceiveType.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlReceiveType.Location = new System.Drawing.Point(176, 69);
            this.pnlReceiveType.Margin = new System.Windows.Forms.Padding(0);
            this.pnlReceiveType.Name = "pnlReceiveType";
            this.pnlReceiveType.Size = new System.Drawing.Size(616, 30);
            this.pnlReceiveType.TabIndex = 1;
            // 
            // rdoReceiveReturn
            // 
            this.rdoReceiveReturn.AppearanceName = "";
            this.rdoReceiveReturn.AutoSize = true;
            this.rdoReceiveReturn.ControlID = null;
            this.rdoReceiveReturn.Location = new System.Drawing.Point(133, 4);
            this.rdoReceiveReturn.Name = "rdoReceiveReturn";
            this.rdoReceiveReturn.PathString = "RECEIVE_TYPE.Value";
            this.rdoReceiveReturn.Size = new System.Drawing.Size(132, 23);
            this.rdoReceiveReturn.SpecificValue = "01";
            this.rdoReceiveReturn.TabIndex = 1;
            this.rdoReceiveReturn.TabStop = true;
            this.rdoReceiveReturn.Text = "Receive Return";
            this.rdoReceiveReturn.UseVisualStyleBackColor = true;
            this.rdoReceiveReturn.CheckedChanged += new System.EventHandler(this.rdoReceiveReturn_CheckedChanged);
            // 
            // rdoReceive
            // 
            this.rdoReceive.AppearanceName = "";
            this.rdoReceive.AutoSize = true;
            this.rdoReceive.ControlID = null;
            this.rdoReceive.Location = new System.Drawing.Point(14, 4);
            this.rdoReceive.Name = "rdoReceive";
            this.rdoReceive.PathString = "RECEIVE_TYPE.Value";
            this.rdoReceive.Size = new System.Drawing.Size(80, 23);
            this.rdoReceive.SpecificValue = "00";
            this.rdoReceive.TabIndex = 0;
            this.rdoReceive.TabStop = true;
            this.rdoReceive.Text = "Receive";
            this.rdoReceive.UseVisualStyleBackColor = true;
            this.rdoReceive.CheckedChanged += new System.EventHandler(this.rdoReceiveReturn_CheckedChanged);
            // 
            // txtPONo
            // 
            this.txtPONo.AppearanceName = "";
            this.txtPONo.AppearanceReadOnlyName = "";
            this.tableContainer.SetColumnSpan(this.txtPONo, 2);
            this.txtPONo.ControlID = "";
            this.txtPONo.DisableRestrictChar = false;
            this.txtPONo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPONo.HelpButton = null;
            this.txtPONo.Location = new System.Drawing.Point(179, 201);
            this.txtPONo.MaxLength = 30;
            this.txtPONo.Name = "txtPONo";
            this.txtPONo.PathString = "PO_NO.Value";
            this.txtPONo.PathValue = "";
            this.txtPONo.Size = new System.Drawing.Size(610, 27);
            this.txtPONo.TabIndex = 4;
            // 
            // txtRemark
            // 
            this.txtRemark.AppearanceName = "";
            this.txtRemark.AppearanceReadOnlyName = "";
            this.tableContainer.SetColumnSpan(this.txtRemark, 2);
            this.txtRemark.ControlID = "";
            this.txtRemark.DisableRestrictChar = false;
            this.txtRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemark.HelpButton = null;
            this.txtRemark.Location = new System.Drawing.Point(179, 234);
            this.txtRemark.MaxLength = 255;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.PathString = "REMARK.Value";
            this.txtRemark.PathValue = "";
            this.txtRemark.Size = new System.Drawing.Size(610, 27);
            this.txtRemark.TabIndex = 5;
            this.txtRemark.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRemark_KeyPress);
            // 
            // chkFilterItem
            // 
            this.chkFilterItem.AppearanceName = "";
            this.chkFilterItem.Checked = true;
            this.chkFilterItem.CheckedValue = null;
            this.chkFilterItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterItem.ControlID = null;
            this.chkFilterItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkFilterItem.Location = new System.Drawing.Point(488, 135);
            this.chkFilterItem.Name = "chkFilterItem";
            this.chkFilterItem.PathString = null;
            this.chkFilterItem.PathValue = true;
            this.chkFilterItem.Size = new System.Drawing.Size(301, 27);
            this.chkFilterItem.TabIndex = 40;
            this.chkFilterItem.Text = "Filter Item by supplier";
            this.chkFilterItem.UnCheckedValue = null;
            this.chkFilterItem.UseVisualStyleBackColor = true;
            // 
            // tableHeader
            // 
            this.tableHeader.AutoSize = true;
            this.tableHeader.ColumnCount = 3;
            this.tableHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableHeader.Controls.Add(this.stcReceiveNo, 1, 1);
            this.tableHeader.Controls.Add(this.stdReceiveDate, 1, 2);
            this.tableHeader.Controls.Add(this.lblReceiveNo, 2, 1);
            this.tableHeader.Controls.Add(this.dtReceiveDate, 2, 2);
            this.tableHeader.Controls.Add(this.stcReqReceiveDate, 0, 2);
            this.tableHeader.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableHeader.Location = new System.Drawing.Point(485, 0);
            this.tableHeader.Margin = new System.Windows.Forms.Padding(0);
            this.tableHeader.Name = "tableHeader";
            this.tableHeader.RowCount = 3;
            this.tableHeader.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableHeader.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableHeader.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableHeader.Size = new System.Drawing.Size(307, 45);
            this.tableHeader.TabIndex = 0;
            // 
            // stcReceiveNo
            // 
            this.stcReceiveNo.AppearanceName = "";
            this.stcReceiveNo.AutoSize = true;
            this.stcReceiveNo.ControlID = "";
            this.stcReceiveNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stcReceiveNo.Location = new System.Drawing.Point(33, 0);
            this.stcReceiveNo.Name = "stcReceiveNo";
            this.stcReceiveNo.PathString = null;
            this.stcReceiveNo.PathValue = "Receive No :";
            this.stcReceiveNo.Size = new System.Drawing.Size(124, 19);
            this.stcReceiveNo.TabIndex = 0;
            this.stcReceiveNo.Text = "Receive No :";
            this.stcReceiveNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stdReceiveDate
            // 
            this.stdReceiveDate.AppearanceName = "";
            this.stdReceiveDate.AutoSize = true;
            this.stdReceiveDate.ControlID = "";
            this.stdReceiveDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stdReceiveDate.Location = new System.Drawing.Point(33, 19);
            this.stdReceiveDate.Name = "stdReceiveDate";
            this.stdReceiveDate.PathString = null;
            this.stdReceiveDate.PathValue = "Receive Date :";
            this.stdReceiveDate.Size = new System.Drawing.Size(124, 26);
            this.stdReceiveDate.TabIndex = 1;
            this.stdReceiveDate.Text = "Receive Date :";
            this.stdReceiveDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblReceiveNo
            // 
            this.lblReceiveNo.AppearanceName = "";
            this.lblReceiveNo.AutoSize = true;
            this.lblReceiveNo.ControlID = "";
            this.lblReceiveNo.Location = new System.Drawing.Point(163, 0);
            this.lblReceiveNo.Name = "lblReceiveNo";
            this.lblReceiveNo.PathString = "RECEIVE_NO.Value";
            this.lblReceiveNo.PathValue = "";
            this.lblReceiveNo.Size = new System.Drawing.Size(0, 19);
            this.lblReceiveNo.TabIndex = 0;
            // 
            // dtReceiveDate
            // 
            this.dtReceiveDate.AppearanceName = "";
            this.dtReceiveDate.AppearanceReadOnlyName = "";
            this.dtReceiveDate.BackColor = System.Drawing.Color.Transparent;
            this.dtReceiveDate.ControlID = "";
            this.dtReceiveDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtReceiveDate.Format = "dd/MM/yyyy";
            this.dtReceiveDate.Location = new System.Drawing.Point(163, 22);
            this.dtReceiveDate.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtReceiveDate.Name = "dtReceiveDate";
            this.dtReceiveDate.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtReceiveDate.NZValue")));
            this.dtReceiveDate.PathString = "RECEIVE_DATE.Value";
            this.dtReceiveDate.PathValue = ((object)(resources.GetObject("dtReceiveDate.PathValue")));
            this.dtReceiveDate.ReadOnly = false;
            this.dtReceiveDate.ShowButton = true;
            this.dtReceiveDate.Size = new System.Drawing.Size(141, 20);
            this.dtReceiveDate.TabIndex = 0;
            this.dtReceiveDate.Value = null;
            this.dtReceiveDate.ValueChanged += new System.EventHandler(this.dtReceiveDate_ValueChanged);
            // 
            // stcReqReceiveDate
            // 
            this.stcReqReceiveDate.AppearanceName = "RequireText";
            this.stcReqReceiveDate.AutoSize = true;
            this.stcReqReceiveDate.ControlID = "";
            this.stcReqReceiveDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.stcReqReceiveDate.Location = new System.Drawing.Point(3, 19);
            this.stcReqReceiveDate.Name = "stcReqReceiveDate";
            this.stcReqReceiveDate.PathString = null;
            this.stcReqReceiveDate.PathValue = "*";
            this.stcReqReceiveDate.Size = new System.Drawing.Size(24, 19);
            this.stcReqReceiveDate.TabIndex = 3;
            this.stcReqReceiveDate.Text = "*";
            // 
            // stcStoredLoc
            // 
            this.stcStoredLoc.AppearanceName = "";
            this.stcStoredLoc.ControlID = "";
            this.stcStoredLoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stcStoredLoc.Location = new System.Drawing.Point(33, 165);
            this.stcStoredLoc.Name = "stcStoredLoc";
            this.stcStoredLoc.PathString = null;
            this.stcStoredLoc.PathValue = "Store Loc :";
            this.stcStoredLoc.Size = new System.Drawing.Size(140, 33);
            this.stcStoredLoc.TabIndex = 39;
            this.stcStoredLoc.Text = "Store Loc :";
            this.stcStoredLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboStoredLoc
            // 
            this.cboStoredLoc.AppearanceName = "";
            this.cboStoredLoc.AppearanceReadOnlyName = "";
            this.tableContainer.SetColumnSpan(this.cboStoredLoc, 2);
            this.cboStoredLoc.ControlID = null;
            this.cboStoredLoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboStoredLoc.DropDownHeight = 180;
            this.cboStoredLoc.FormattingEnabled = true;
            this.cboStoredLoc.IntegralHeight = false;
            this.cboStoredLoc.Location = new System.Drawing.Point(179, 168);
            this.cboStoredLoc.Name = "cboStoredLoc";
            this.cboStoredLoc.PathString = "STORED_LOC.Value";
            this.cboStoredLoc.PathValue = null;
            this.cboStoredLoc.Size = new System.Drawing.Size(610, 27);
            this.cboStoredLoc.TabIndex = 3;
            // 
            // stcInvoiceNo
            // 
            this.stcInvoiceNo.AppearanceName = "";
            this.stcInvoiceNo.ControlID = "";
            this.stcInvoiceNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stcInvoiceNo.Location = new System.Drawing.Point(33, 99);
            this.stcInvoiceNo.Name = "stcInvoiceNo";
            this.stcInvoiceNo.PathString = null;
            this.stcInvoiceNo.PathValue = "Invoice No :";
            this.stcInvoiceNo.Size = new System.Drawing.Size(140, 33);
            this.stcInvoiceNo.TabIndex = 6;
            this.stcInvoiceNo.Text = "Invoice No :";
            this.stcInvoiceNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.AppearanceName = "";
            this.txtInvoiceNo.AppearanceReadOnlyName = "";
            this.tableContainer.SetColumnSpan(this.txtInvoiceNo, 2);
            this.txtInvoiceNo.ControlID = "";
            this.txtInvoiceNo.DisableRestrictChar = false;
            this.txtInvoiceNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInvoiceNo.HelpButton = null;
            this.txtInvoiceNo.Location = new System.Drawing.Point(179, 102);
            this.txtInvoiceNo.MaxLength = 20;
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.PathString = "INVOICE_NO.Value";
            this.txtInvoiceNo.PathValue = "";
            this.txtInvoiceNo.Size = new System.Drawing.Size(610, 27);
            this.txtInvoiceNo.TabIndex = 1;
            // 
            // lblSupplierCode
            // 
            this.lblSupplierCode.AppearanceName = "";
            this.lblSupplierCode.ControlID = "";
            this.lblSupplierCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSupplierCode.Location = new System.Drawing.Point(33, 132);
            this.lblSupplierCode.Name = "lblSupplierCode";
            this.lblSupplierCode.PathString = null;
            this.lblSupplierCode.PathValue = "Supplier Code :";
            this.lblSupplierCode.Size = new System.Drawing.Size(140, 33);
            this.lblSupplierCode.TabIndex = 6;
            this.lblSupplierCode.Text = "Supplier Code :";
            this.lblSupplierCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboSupplierCode
            // 
            this.cboSupplierCode.AppearanceName = "";
            this.cboSupplierCode.AppearanceReadOnlyName = "";
            this.cboSupplierCode.ControlID = null;
            this.cboSupplierCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboSupplierCode.DropDownHeight = 180;
            this.cboSupplierCode.FormattingEnabled = true;
            this.cboSupplierCode.IntegralHeight = false;
            this.cboSupplierCode.Location = new System.Drawing.Point(179, 135);
            this.cboSupplierCode.Name = "cboSupplierCode";
            this.cboSupplierCode.PathString = "DEALING_NO.Value";
            this.cboSupplierCode.PathValue = null;
            this.cboSupplierCode.Size = new System.Drawing.Size(303, 27);
            this.cboSupplierCode.TabIndex = 2;
            // 
            // stcReqSupplier
            // 
            this.stcReqSupplier.AppearanceName = "RequireText";
            this.stcReqSupplier.AutoSize = true;
            this.stcReqSupplier.ControlID = "";
            this.stcReqSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stcReqSupplier.Location = new System.Drawing.Point(3, 132);
            this.stcReqSupplier.Name = "stcReqSupplier";
            this.stcReqSupplier.PathString = null;
            this.stcReqSupplier.PathValue = "*";
            this.stcReqSupplier.Size = new System.Drawing.Size(24, 33);
            this.stcReqSupplier.TabIndex = 3;
            this.stcReqSupplier.Text = "*";
            this.stcReqSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TRN020
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 390);
            this.Name = "TRN020";
            this.Text = "Receiving Entry";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TRN020_FormClosed);
            this.Load += new System.EventHandler(this.TRN020_Load);
            this.Shown += new System.EventHandler(this.TRN020_Shown);
            this.Controls.SetChildIndex(this.pnlContainer, 0);
            this.pnlContainer.ResumeLayout(false);
            this.tableContainer.ResumeLayout(false);
            this.tableContainer.PerformLayout();
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.tlpHeader2.ResumeLayout(false);
            this.tlpHeader2.PerformLayout();
            this.pnlReceiveListInfo.ResumeLayout(false);
            this.pnlReceiveListInfo.PerformLayout();
            this.tableReceiveListInfo.ResumeLayout(false);
            this.tableReceiveListInfo.PerformLayout();
            this.pnlView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).EndInit();
            this.ctxMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).EndInit();
            this.pnlReceiveType.ResumeLayout(false);
            this.pnlReceiveType.PerformLayout();
            this.tableHeader.ResumeLayout(false);
            this.tableHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableContainer;
        private EVOFramework.Windows.Forms.EVOPanel pnlTitle;
        private System.Windows.Forms.TableLayoutPanel tlpHeader2;
        private EVOFramework.Windows.Forms.EVOLabel stcReceiveInfo;
        private EVOFramework.Windows.Forms.EVOLabel stcReceiveType;
        private EVOFramework.Windows.Forms.EVOLabel stcPONo;
        private EVOFramework.Windows.Forms.EVOLabel stcRemark;
        private EVOFramework.Windows.Forms.EVOPanel pnlReceiveListInfo;
        private System.Windows.Forms.TableLayoutPanel tableReceiveListInfo;
        private EVOFramework.Windows.Forms.EVOLabel stcReceiveListInfo;
        private EVOFramework.Windows.Forms.EVOPanel pnlView;
        private FarPoint.Win.Spread.FpSpread fpView;
        private FarPoint.Win.Spread.SheetView shtView;
        private EVOFramework.Windows.Forms.EVOPanel pnlReceiveType;
        private EVOFramework.Windows.Forms.EVORadioButton rdoReceiveReturn;
        private EVOFramework.Windows.Forms.EVORadioButton rdoReceive;
        private EVOFramework.Windows.Forms.EVOTextBox txtPONo;
        private EVOFramework.Windows.Forms.EVOLabel stcHead;
        private EVOFramework.Windows.Forms.EVOLabel stcInvoiceNo;
        private EVOFramework.Windows.Forms.EVOTextBox txtInvoiceNo;
        private EVOFramework.Windows.Forms.EVOTextBox txtRemark;
        private System.Windows.Forms.TableLayoutPanel tableHeader;
        private EVOFramework.Windows.Forms.EVOLabel stcReceiveNo;
        private EVOFramework.Windows.Forms.EVOLabel stdReceiveDate;
        private EVOFramework.Windows.Forms.EVOLabel lblReceiveNo;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtReceiveDate;
        private EVOFramework.Windows.Forms.EVOLabel stcReqReceiveDate;
        private EVOFramework.Data.UIDataModelController dmcReceive;
        private EVOFramework.Windows.Forms.EVOLabel stcStoredLoc;
        private EVOFramework.Windows.Forms.EVOComboBox cboStoredLoc;
        private EVOFramework.Windows.Forms.EVOLabel stcReqStoreLoc;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem miAdd;
        private System.Windows.Forms.ToolStripMenuItem miDelete;
        private EVOFramework.Windows.Forms.EVOLabel lblSupplierCode;
        private EVOFramework.Windows.Forms.EVOComboBox cboSupplierCode;
        private EVOFramework.Windows.Forms.EVOLabel stcReqSupplier;
        private EVOFramework.Windows.Forms.EVOCheckBox chkFilterItem;

    }
}
