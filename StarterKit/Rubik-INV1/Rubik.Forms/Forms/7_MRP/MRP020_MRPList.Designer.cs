namespace Rubik.MRP
{
    partial class MRP020_MRPList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MRP020_MRPList));
            this.txtSearch = new EVOFramework.Windows.Forms.EVOTextBox();
            this.fpView = new FarPoint.Win.Spread.FpSpread();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.shtView = new FarPoint.Win.Spread.SheetView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tlpTitle = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.dtPeriodEnd = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.dtPeriodBegin = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.evoLabel7 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).BeginInit();
            this.ctxMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.evoLabel1);
            this.pnlContainer.Controls.Add(this.dtPeriodEnd);
            this.pnlContainer.Controls.Add(this.label1);
            this.pnlContainer.Controls.Add(this.dtPeriodBegin);
            this.pnlContainer.Controls.Add(this.tlpTitle);
            this.pnlContainer.Controls.Add(this.evoLabel7);
            this.pnlContainer.Controls.Add(this.pictureBox1);
            this.pnlContainer.Controls.Add(this.fpView);
            this.pnlContainer.Controls.Add(this.txtSearch);
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlContainer.Size = new System.Drawing.Size(800, 434);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.AppearanceName = "";
            this.txtSearch.AppearanceReadOnlyName = "";
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.ControlID = "";
            this.txtSearch.DisableRestrictChar = true;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.HelpButton = null;
            this.txtSearch.Location = new System.Drawing.Point(47, 42);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PathString = null;
            this.txtSearch.PathValue = "";
            this.txtSearch.Size = new System.Drawing.Size(741, 26);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TabStop = false;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            // 
            // fpView
            // 
            this.fpView.About = "2.5.2015.2005";
            this.fpView.AccessibleDescription = "fpView, Sheet1";
            this.fpView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fpView.BackColor = System.Drawing.Color.AliceBlue;
            this.fpView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fpView.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpView.ContextMenuStrip = this.ctxMenu;
            this.fpView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.Location = new System.Drawing.Point(13, 74);
            this.fpView.Name = "fpView";
            this.fpView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpView.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtView});
            this.fpView.Size = new System.Drawing.Size(775, 348);
            this.fpView.TabIndex = 3;
            this.fpView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpView_CellDoubleClick);
            this.fpView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpView_KeyDown);
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEdit});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(153, 48);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(152, 22);
            this.mnuEdit.Text = "Edit";
            this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
            // 
            // shtView
            // 
            this.shtView.Reset();
            this.shtView.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtView.ColumnCount = 37;
            this.shtView.RowCount = 0;
            this.shtView.AutoCalculation = false;
            this.shtView.AutoGenerateColumns = false;
            this.shtView.ColumnHeader.Cells.Get(0, 0).Value = "Create By";
            this.shtView.ColumnHeader.Cells.Get(0, 1).Value = "Create Date";
            this.shtView.ColumnHeader.Cells.Get(0, 2).Value = "Create Machine";
            this.shtView.ColumnHeader.Cells.Get(0, 3).Value = "Update By";
            this.shtView.ColumnHeader.Cells.Get(0, 4).Value = "Update Date";
            this.shtView.ColumnHeader.Cells.Get(0, 5).Value = "Update Machine";
            this.shtView.ColumnHeader.Cells.Get(0, 6).Value = "Active";
            this.shtView.ColumnHeader.Cells.Get(0, 7).Value = "MRP No.";
            this.shtView.ColumnHeader.Cells.Get(0, 8).Value = "Revision No.";
            this.shtView.ColumnHeader.Cells.Get(0, 9).Value = "Part No";
            this.shtView.ColumnHeader.Cells.Get(0, 10).Value = "Part Name";
            this.shtView.ColumnHeader.Cells.Get(0, 11).Value = "Part Type";
            this.shtView.ColumnHeader.Cells.Get(0, 12).Value = "Supplier LOC";
            this.shtView.ColumnHeader.Cells.Get(0, 13).Value = "Due Date";
            this.shtView.ColumnHeader.Cells.Get(0, 14).Value = "Incoming Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 15).Value = "Outgoing Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 16).Value = "Request Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 17).Value = "Actual Request Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 18).Value = "Actual Request By Lot Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 19).Value = "Purchase Order Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 20).Value = "On Hand Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 21).Value = "Balance Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 22).Value = "Balance By Lot Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 23).Value = "Order Process";
            this.shtView.ColumnHeader.Cells.Get(0, 24).Value = "Lot Size";
            this.shtView.ColumnHeader.Cells.Get(0, 25).Value = "Reorder Point";
            this.shtView.ColumnHeader.Cells.Get(0, 26).Value = "Safety Stock";
            this.shtView.ColumnHeader.Cells.Get(0, 27).Value = "Minimum Order";
            this.shtView.ColumnHeader.Cells.Get(0, 28).Value = "Inventory Unit Rate";
            this.shtView.ColumnHeader.Cells.Get(0, 29).Value = "Inventory Unit";
            this.shtView.ColumnHeader.Cells.Get(0, 30).Value = "Order Unit Rate";
            this.shtView.ColumnHeader.Cells.Get(0, 31).Value = "Order Unit";
            this.shtView.ColumnHeader.Cells.Get(0, 32).Value = "Max Capacity";
            this.shtView.ColumnHeader.Cells.Get(0, 33).Value = "Leadtime";
            this.shtView.ColumnHeader.Cells.Get(0, 34).Value = "Safety Leadtime";
            this.shtView.ColumnHeader.Cells.Get(0, 35).Value = "MRP Flag";
            this.shtView.ColumnHeader.Cells.Get(0, 36).Value = "Order Condition";
            this.shtView.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtView.Columns.Get(0).Label = "Create By";
            this.shtView.Columns.Get(0).Tag = "Create By";
            this.shtView.Columns.Get(0).Width = 131F;
            this.shtView.Columns.Get(1).Label = "Create Date";
            this.shtView.Columns.Get(1).Tag = "Create Date";
            this.shtView.Columns.Get(1).Width = 123F;
            this.shtView.Columns.Get(2).Label = "Create Machine";
            this.shtView.Columns.Get(2).Tag = "Create Machine";
            this.shtView.Columns.Get(2).Width = 168F;
            this.shtView.Columns.Get(3).Label = "Update By";
            this.shtView.Columns.Get(3).Tag = "Update By";
            this.shtView.Columns.Get(3).Width = 100F;
            this.shtView.Columns.Get(4).Label = "Update Date";
            this.shtView.Columns.Get(4).Tag = "Update Date";
            this.shtView.Columns.Get(4).Width = 129F;
            this.shtView.Columns.Get(5).Label = "Update Machine";
            this.shtView.Columns.Get(5).Tag = "Update Machine";
            this.shtView.Columns.Get(5).Width = 158F;
            this.shtView.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.shtView.Columns.Get(6).Label = "Active";
            this.shtView.Columns.Get(6).Tag = "Active";
            this.shtView.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.shtView.Columns.Get(6).Width = 121F;
            this.shtView.Columns.Get(7).Label = "MRP No.";
            this.shtView.Columns.Get(7).Tag = "MRP No.";
            this.shtView.Columns.Get(7).Width = 147F;
            this.shtView.Columns.Get(8).Label = "Revision No.";
            this.shtView.Columns.Get(8).Tag = "Revision No.";
            this.shtView.Columns.Get(8).Width = 108F;
            this.shtView.Columns.Get(9).Label = "Part No";
            this.shtView.Columns.Get(9).Tag = "Part No";
            this.shtView.Columns.Get(9).Width = 200F;
            this.shtView.Columns.Get(10).Label = "Part Name";
            this.shtView.Columns.Get(10).Tag = "Part Name";
            this.shtView.Columns.Get(10).Width = 200F;
            this.shtView.Columns.Get(11).Label = "Part Type";
            this.shtView.Columns.Get(11).Tag = "Part Type";
            this.shtView.Columns.Get(11).Width = 167F;
            this.shtView.Columns.Get(12).Label = "Supplier LOC";
            this.shtView.Columns.Get(12).Tag = "Supplier LOC";
            this.shtView.Columns.Get(12).Width = 200F;
            this.shtView.Columns.Get(13).Label = "Due Date";
            this.shtView.Columns.Get(13).Tag = "Due Date";
            this.shtView.Columns.Get(13).Width = 144F;
            this.shtView.Columns.Get(14).Label = "Incoming Qty";
            this.shtView.Columns.Get(14).Tag = "Incoming Qty";
            this.shtView.Columns.Get(14).Width = 150F;
            this.shtView.Columns.Get(15).Label = "Outgoing Qty";
            this.shtView.Columns.Get(15).Tag = "Outgoing Qty";
            this.shtView.Columns.Get(15).Width = 150F;
            this.shtView.Columns.Get(16).Label = "Request Qty";
            this.shtView.Columns.Get(16).Tag = "Request Qty";
            this.shtView.Columns.Get(16).Width = 150F;
            this.shtView.Columns.Get(17).Label = "Actual Request Qty";
            this.shtView.Columns.Get(17).Tag = "Actual Request Qty";
            this.shtView.Columns.Get(17).Width = 150F;
            this.shtView.Columns.Get(18).Label = "Actual Request By Lot Qty";
            this.shtView.Columns.Get(18).Tag = "Actual Request By Lot Qty";
            this.shtView.Columns.Get(18).Width = 150F;
            this.shtView.Columns.Get(19).Label = "Purchase Order Qty";
            this.shtView.Columns.Get(19).Tag = "Purchase Order Qty";
            this.shtView.Columns.Get(19).Width = 150F;
            this.shtView.Columns.Get(20).Label = "On Hand Qty";
            this.shtView.Columns.Get(20).Tag = "On Hand Qty";
            this.shtView.Columns.Get(20).Width = 150F;
            this.shtView.Columns.Get(21).Label = "Balance Qty";
            this.shtView.Columns.Get(21).Tag = "Balance Qty";
            this.shtView.Columns.Get(21).Width = 150F;
            this.shtView.Columns.Get(22).Label = "Balance By Lot Qty";
            this.shtView.Columns.Get(22).Tag = "Balance By Lot Qty";
            this.shtView.Columns.Get(22).Width = 150F;
            this.shtView.Columns.Get(23).Label = "Order Process";
            this.shtView.Columns.Get(23).Tag = "Order Process";
            this.shtView.Columns.Get(23).Width = 183F;
            this.shtView.Columns.Get(24).Label = "Lot Size";
            this.shtView.Columns.Get(24).Tag = "Lot Size";
            this.shtView.Columns.Get(24).Width = 126F;
            this.shtView.Columns.Get(25).Label = "Reorder Point";
            this.shtView.Columns.Get(25).Tag = "Reorder Point";
            this.shtView.Columns.Get(25).Width = 149F;
            this.shtView.Columns.Get(26).Label = "Safety Stock";
            this.shtView.Columns.Get(26).Tag = "Safety Stock";
            this.shtView.Columns.Get(26).Width = 138F;
            this.shtView.Columns.Get(27).Label = "Minimum Order";
            this.shtView.Columns.Get(27).Tag = "Minimum Order";
            this.shtView.Columns.Get(27).Width = 161F;
            this.shtView.Columns.Get(28).Label = "Inventory Unit Rate";
            this.shtView.Columns.Get(28).Tag = "Inventory Unit Rate";
            this.shtView.Columns.Get(28).Width = 119F;
            this.shtView.Columns.Get(29).Label = "Inventory Unit";
            this.shtView.Columns.Get(29).Tag = "Inventory Unit";
            this.shtView.Columns.Get(29).Width = 115F;
            this.shtView.Columns.Get(30).Label = "Order Unit Rate";
            this.shtView.Columns.Get(30).Tag = "Order Unit Rate";
            this.shtView.Columns.Get(30).Width = 119F;
            this.shtView.Columns.Get(31).Label = "Order Unit";
            this.shtView.Columns.Get(31).Tag = "Order Unit";
            this.shtView.Columns.Get(31).Width = 115F;
            this.shtView.Columns.Get(32).Label = "Max Capacity";
            this.shtView.Columns.Get(32).Tag = "Max Capacity";
            this.shtView.Columns.Get(32).Width = 139F;
            this.shtView.Columns.Get(33).Label = "Leadtime";
            this.shtView.Columns.Get(33).Tag = "Leadtime";
            this.shtView.Columns.Get(33).Width = 124F;
            this.shtView.Columns.Get(34).Label = "Safety Leadtime";
            this.shtView.Columns.Get(34).Tag = "Safety Leadtime";
            this.shtView.Columns.Get(34).Width = 155F;
            this.shtView.Columns.Get(35).Label = "MRP Flag";
            this.shtView.Columns.Get(35).Tag = "MRP Flag";
            this.shtView.Columns.Get(35).Width = 239F;
            this.shtView.Columns.Get(36).Label = "Order Condition";
            this.shtView.Columns.Get(36).Tag = "Order Condition";
            this.shtView.Columns.Get(36).Width = 170F;
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
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Rubik.Forms.Properties.Resources.FIND_TEXT;
            this.pictureBox1.Location = new System.Drawing.Point(13, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // tlpTitle
            // 
            this.tlpTitle.AutoSize = true;
            this.tlpTitle.ColumnCount = 6;
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tlpTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpTitle.Location = new System.Drawing.Point(0, 0);
            this.tlpTitle.Name = "tlpTitle";
            this.tlpTitle.RowCount = 1;
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpTitle.Size = new System.Drawing.Size(800, 0);
            this.tlpTitle.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AppearanceName = "Title";
            this.label1.AutoSize = true;
            this.label1.ControlID = "";
            this.label1.Font = new System.Drawing.Font("Tahoma", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.PathString = null;
            this.label1.PathValue = "MRP Result List";
            this.label1.Size = new System.Drawing.Size(266, 39);
            this.label1.TabIndex = 35;
            this.label1.Text = "MRP Result List";
            // 
            // dtPeriodEnd
            // 
            this.dtPeriodEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtPeriodEnd.AppearanceName = "";
            this.dtPeriodEnd.AppearanceReadOnlyName = "";
            this.dtPeriodEnd.BackColor = System.Drawing.Color.Transparent;
            this.dtPeriodEnd.ControlID = "";
            this.dtPeriodEnd.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.dtPeriodEnd.Format = "dd/MM/yyyy";
            this.dtPeriodEnd.Location = new System.Drawing.Point(634, 8);
            this.dtPeriodEnd.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtPeriodEnd.Name = "dtPeriodEnd";
            this.dtPeriodEnd.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtPeriodEnd.NZValue")));
            this.dtPeriodEnd.PathString = null;
            this.dtPeriodEnd.PathValue = ((object)(resources.GetObject("dtPeriodEnd.PathValue")));
            this.dtPeriodEnd.ReadOnly = false;
            this.dtPeriodEnd.ShowButton = true;
            this.dtPeriodEnd.Size = new System.Drawing.Size(154, 27);
            this.dtPeriodEnd.TabIndex = 36;
            this.dtPeriodEnd.Value = null;
            // 
            // dtPeriodBegin
            // 
            this.dtPeriodBegin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtPeriodBegin.AppearanceName = "";
            this.dtPeriodBegin.AppearanceReadOnlyName = "";
            this.dtPeriodBegin.BackColor = System.Drawing.Color.Transparent;
            this.dtPeriodBegin.ControlID = "";
            this.dtPeriodBegin.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.dtPeriodBegin.Format = "dd/MM/yyyy";
            this.dtPeriodBegin.Location = new System.Drawing.Point(453, 8);
            this.dtPeriodBegin.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtPeriodBegin.Name = "dtPeriodBegin";
            this.dtPeriodBegin.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtPeriodBegin.NZValue")));
            this.dtPeriodBegin.PathString = null;
            this.dtPeriodBegin.PathValue = ((object)(resources.GetObject("dtPeriodBegin.PathValue")));
            this.dtPeriodBegin.ReadOnly = false;
            this.dtPeriodBegin.ShowButton = true;
            this.dtPeriodBegin.Size = new System.Drawing.Size(154, 27);
            this.dtPeriodBegin.TabIndex = 37;
            this.dtPeriodBegin.Value = null;
            // 
            // evoLabel7
            // 
            this.evoLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.evoLabel7.AppearanceName = "";
            this.evoLabel7.AutoSize = true;
            this.evoLabel7.ControlID = "";
            this.evoLabel7.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel7.Location = new System.Drawing.Point(359, 12);
            this.evoLabel7.Name = "evoLabel7";
            this.evoLabel7.PathString = null;
            this.evoLabel7.PathValue = "Period Date";
            this.evoLabel7.Size = new System.Drawing.Size(91, 19);
            this.evoLabel7.TabIndex = 38;
            this.evoLabel7.Text = "Period Date";
            // 
            // evoLabel1
            // 
            this.evoLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.evoLabel1.AppearanceName = "";
            this.evoLabel1.AutoSize = true;
            this.evoLabel1.ControlID = "";
            this.evoLabel1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel1.Location = new System.Drawing.Point(613, 12);
            this.evoLabel1.Name = "evoLabel1";
            this.evoLabel1.PathString = null;
            this.evoLabel1.PathValue = "-";
            this.evoLabel1.Size = new System.Drawing.Size(15, 19);
            this.evoLabel1.TabIndex = 39;
            this.evoLabel1.Text = "-";
            // 
            // MRP020_MRPList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 459);
            this.ExportObject = this.fpView;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MRP020_MRPList";
            this.Text = "MRP020 - MRP Result List";
            this.Controls.SetChildIndex(this.pnlContainer, 0);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).EndInit();
            this.ctxMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EVOFramework.Windows.Forms.EVOTextBox txtSearch;
        private FarPoint.Win.Spread.FpSpread fpView;
        private FarPoint.Win.Spread.SheetView shtView;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tlpTitle;
        private EVOFramework.Windows.Forms.EVOLabel label1;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtPeriodEnd;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtPeriodBegin;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel7;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel1;
    }
}