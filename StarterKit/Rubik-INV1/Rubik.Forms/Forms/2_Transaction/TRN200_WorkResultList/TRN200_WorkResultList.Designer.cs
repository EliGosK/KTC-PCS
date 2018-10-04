namespace Rubik.Transaction
{
    partial class TRN200_WorkResultList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TRN200_WorkResultList));
            this.stcHead = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcDash = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcPeriod = new EVOFramework.Windows.Forms.EVOLabel();
            this.dtPeriodBegin = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.dtPeriodEnd = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.fpProductionReportList = new FarPoint.Win.Spread.FpSpread();
            this.shtProductionReportList = new FarPoint.Win.Spread.SheetView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtSearch = new EVOFramework.Windows.Forms.EVOTextBox();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.miDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpProductionReportList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtProductionReportList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.ctxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.txtSearch);
            this.pnlContainer.Controls.Add(this.pictureBox1);
            this.pnlContainer.Controls.Add(this.fpProductionReportList);
            this.pnlContainer.Controls.Add(this.stcDash);
            this.pnlContainer.Controls.Add(this.stcHead);
            this.pnlContainer.Controls.Add(this.dtPeriodBegin);
            this.pnlContainer.Controls.Add(this.dtPeriodEnd);
            this.pnlContainer.Controls.Add(this.stcPeriod);
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlContainer.Size = new System.Drawing.Size(894, 330);
            // 
            // stcHead
            // 
            this.stcHead.AccessibleName = "";
            this.stcHead.AppearanceName = "Title";
            this.stcHead.AutoSize = true;
            this.stcHead.ControlID = "";
            this.stcHead.Font = new System.Drawing.Font("Tahoma", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.stcHead.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.stcHead.Location = new System.Drawing.Point(9, 7);
            this.stcHead.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.stcHead.Name = "stcHead";
            this.stcHead.Padding = new System.Windows.Forms.Padding(3);
            this.stcHead.PathString = null;
            this.stcHead.PathValue = "Production Report List";
            this.stcHead.Size = new System.Drawing.Size(326, 39);
            this.stcHead.TabIndex = 37;
            this.stcHead.Text = "Production Report List";
            // 
            // stcDash
            // 
            this.stcDash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stcDash.AppearanceName = "";
            this.stcDash.AutoSize = true;
            this.stcDash.ControlID = "";
            this.stcDash.Location = new System.Drawing.Point(674, 17);
            this.stcDash.Name = "stcDash";
            this.stcDash.PathString = null;
            this.stcDash.PathValue = "-";
            this.stcDash.Size = new System.Drawing.Size(15, 19);
            this.stcDash.TabIndex = 1;
            this.stcDash.Text = "-";
            this.stcDash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stcPeriod
            // 
            this.stcPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stcPeriod.AppearanceName = "";
            this.stcPeriod.AutoSize = true;
            this.stcPeriod.ControlID = "";
            this.stcPeriod.Location = new System.Drawing.Point(302, 17);
            this.stcPeriod.Name = "stcPeriod";
            this.stcPeriod.PathString = null;
            this.stcPeriod.PathValue = "Production Report Date";
            this.stcPeriod.Size = new System.Drawing.Size(174, 19);
            this.stcPeriod.TabIndex = 0;
            this.stcPeriod.Text = "Production Report Date";
            this.stcPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtPeriodBegin
            // 
            this.dtPeriodBegin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtPeriodBegin.AppearanceName = "";
            this.dtPeriodBegin.AppearanceReadOnlyName = "";
            this.dtPeriodBegin.BackColor = System.Drawing.Color.Transparent;
            this.dtPeriodBegin.ControlID = "";
            this.dtPeriodBegin.Format = "dd/MM/yyyy";
            this.dtPeriodBegin.Location = new System.Drawing.Point(483, 16);
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
            // dtPeriodEnd
            // 
            this.dtPeriodEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtPeriodEnd.AppearanceName = "";
            this.dtPeriodEnd.AppearanceReadOnlyName = "";
            this.dtPeriodEnd.BackColor = System.Drawing.Color.Transparent;
            this.dtPeriodEnd.ControlID = "";
            this.dtPeriodEnd.Format = "dd/MM/yyyy";
            this.dtPeriodEnd.Location = new System.Drawing.Point(695, 16);
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
            // fpProductionReportList
            // 
            this.fpProductionReportList.About = "2.5.2015.2005";
            this.fpProductionReportList.AccessibleDescription = "fpProductionReportList, Sheet1";
            this.fpProductionReportList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fpProductionReportList.BackColor = System.Drawing.Color.AliceBlue;
            this.fpProductionReportList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpProductionReportList.Location = new System.Drawing.Point(5, 84);
            this.fpProductionReportList.Name = "fpProductionReportList";
            this.fpProductionReportList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpProductionReportList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpProductionReportList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtProductionReportList});
            this.fpProductionReportList.Size = new System.Drawing.Size(883, 239);
            this.fpProductionReportList.TabIndex = 2;
            this.fpProductionReportList.TabStop = false;
            this.fpProductionReportList.TabStripRatio = 0.499460625674218D;
            this.fpProductionReportList.TextTipDelay = 1000;
            this.fpProductionReportList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpProductionReportList.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpView_CellDoubleClick);
            this.fpProductionReportList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpProductionReportList_KeyDown);
            this.fpProductionReportList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fpView_KeyPress);
            this.fpProductionReportList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fpView_MouseDown);
            // 
            // shtProductionReportList
            // 
            this.shtProductionReportList.Reset();
            this.shtProductionReportList.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtProductionReportList.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtProductionReportList.ColumnCount = 22;
            this.shtProductionReportList.RowCount = 0;
            this.shtProductionReportList.AutoGenerateColumns = false;
            this.shtProductionReportList.ColumnHeader.Cells.Get(0, 0).Value = "TRANS ID";
            this.shtProductionReportList.ColumnHeader.Cells.Get(0, 1).Value = "Production Report Date";
            this.shtProductionReportList.ColumnHeader.Cells.Get(0, 2).Value = "M/N";
            this.shtProductionReportList.ColumnHeader.Cells.Get(0, 3).Value = "Part No.";
            this.shtProductionReportList.ColumnHeader.Cells.Get(0, 4).Value = "Customer Name";
            this.shtProductionReportList.ColumnHeader.Cells.Get(0, 5).Value = "MC. No.";
            this.shtProductionReportList.ColumnHeader.Cells.Get(0, 6).Value = "MC Name";
            this.shtProductionReportList.ColumnHeader.Cells.Get(0, 7).Value = "Shift";
            this.shtProductionReportList.ColumnHeader.Cells.Get(0, 8).Value = "Shift Name";
            this.shtProductionReportList.ColumnHeader.Cells.Get(0, 9).Value = "Transaction No.";
            this.shtProductionReportList.ColumnHeader.Cells.Get(0, 10).Value = "Process";
            this.shtProductionReportList.ColumnHeader.Cells.Get(0, 11).Value = "Process Name";
            this.shtProductionReportList.ColumnHeader.Cells.Get(0, 12).Value = "Supplier";
            this.shtProductionReportList.ColumnHeader.Cells.Get(0, 13).Value = "Supplier Name";
            this.shtProductionReportList.ColumnHeader.Cells.Get(0, 14).Value = "Rework";
            this.shtProductionReportList.ColumnHeader.Cells.Get(0, 15).Value = "Lot No.";
            this.shtProductionReportList.ColumnHeader.Cells.Get(0, 16).Value = "Customer Lot No.";
            this.shtProductionReportList.ColumnHeader.Cells.Get(0, 17).Value = "Person In Charge";
            this.shtProductionReportList.ColumnHeader.Cells.Get(0, 18).Value = "Person In Charge Name";
            this.shtProductionReportList.ColumnHeader.Cells.Get(0, 19).Value = "Total OK";
            this.shtProductionReportList.ColumnHeader.Cells.Get(0, 20).Value = "Total NG";
            this.shtProductionReportList.ColumnHeader.Cells.Get(0, 21).Value = "Remark";
            this.shtProductionReportList.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtProductionReportList.Columns.Get(0).AllowAutoFilter = true;
            this.shtProductionReportList.Columns.Get(0).AllowAutoSort = true;
            this.shtProductionReportList.Columns.Get(0).Label = "TRANS ID";
            this.shtProductionReportList.Columns.Get(0).Width = 118F;
            this.shtProductionReportList.Columns.Get(1).AllowAutoFilter = true;
            this.shtProductionReportList.Columns.Get(1).AllowAutoSort = true;
            this.shtProductionReportList.Columns.Get(1).Label = "Production Report Date";
            this.shtProductionReportList.Columns.Get(1).Locked = true;
            this.shtProductionReportList.Columns.Get(1).Tag = "Production Report Date";
            this.shtProductionReportList.Columns.Get(1).Width = 130F;
            this.shtProductionReportList.Columns.Get(2).AllowAutoFilter = true;
            this.shtProductionReportList.Columns.Get(2).AllowAutoSort = true;
            this.shtProductionReportList.Columns.Get(2).Label = "M/N";
            this.shtProductionReportList.Columns.Get(2).Tag = "M/N";
            this.shtProductionReportList.Columns.Get(2).Width = 90F;
            this.shtProductionReportList.Columns.Get(3).AllowAutoFilter = true;
            this.shtProductionReportList.Columns.Get(3).AllowAutoSort = true;
            this.shtProductionReportList.Columns.Get(3).Label = "Part No.";
            this.shtProductionReportList.Columns.Get(3).Tag = "Part No";
            this.shtProductionReportList.Columns.Get(3).Width = 139F;
            this.shtProductionReportList.Columns.Get(4).AllowAutoFilter = true;
            this.shtProductionReportList.Columns.Get(4).AllowAutoSort = true;
            this.shtProductionReportList.Columns.Get(4).Label = "Customer Name";
            this.shtProductionReportList.Columns.Get(4).Locked = true;
            this.shtProductionReportList.Columns.Get(4).Tag = "Customer Name";
            this.shtProductionReportList.Columns.Get(4).Width = 144F;
            this.shtProductionReportList.Columns.Get(5).AllowAutoFilter = true;
            this.shtProductionReportList.Columns.Get(5).AllowAutoSort = true;
            this.shtProductionReportList.Columns.Get(5).Label = "MC. No.";
            this.shtProductionReportList.Columns.Get(5).Tag = "MC. No.";
            this.shtProductionReportList.Columns.Get(5).Width = 116F;
            this.shtProductionReportList.Columns.Get(6).AllowAutoFilter = true;
            this.shtProductionReportList.Columns.Get(6).AllowAutoSort = true;
            this.shtProductionReportList.Columns.Get(6).Label = "MC Name";
            this.shtProductionReportList.Columns.Get(6).Width = 112F;
            this.shtProductionReportList.Columns.Get(7).AllowAutoFilter = true;
            this.shtProductionReportList.Columns.Get(7).AllowAutoSort = true;
            this.shtProductionReportList.Columns.Get(7).Label = "Shift";
            this.shtProductionReportList.Columns.Get(7).Tag = "Shift";
            this.shtProductionReportList.Columns.Get(7).Width = 96F;
            this.shtProductionReportList.Columns.Get(8).AllowAutoFilter = true;
            this.shtProductionReportList.Columns.Get(8).AllowAutoSort = true;
            this.shtProductionReportList.Columns.Get(8).Label = "Shift Name";
            this.shtProductionReportList.Columns.Get(8).Width = 157F;
            this.shtProductionReportList.Columns.Get(9).AllowAutoFilter = true;
            this.shtProductionReportList.Columns.Get(9).AllowAutoSort = true;
            this.shtProductionReportList.Columns.Get(9).Label = "Transaction No.";
            this.shtProductionReportList.Columns.Get(9).Tag = "Transaction No.";
            this.shtProductionReportList.Columns.Get(9).Width = 165F;
            this.shtProductionReportList.Columns.Get(10).AllowAutoFilter = true;
            this.shtProductionReportList.Columns.Get(10).AllowAutoSort = true;
            this.shtProductionReportList.Columns.Get(10).Label = "Process";
            this.shtProductionReportList.Columns.Get(10).Tag = "Process";
            this.shtProductionReportList.Columns.Get(10).Width = 150F;
            this.shtProductionReportList.Columns.Get(11).AllowAutoFilter = true;
            this.shtProductionReportList.Columns.Get(11).AllowAutoSort = true;
            this.shtProductionReportList.Columns.Get(11).Label = "Process Name";
            this.shtProductionReportList.Columns.Get(11).Tag = "Process Name";
            this.shtProductionReportList.Columns.Get(11).Width = 156F;
            this.shtProductionReportList.Columns.Get(12).AllowAutoFilter = true;
            this.shtProductionReportList.Columns.Get(12).AllowAutoSort = true;
            this.shtProductionReportList.Columns.Get(12).Label = "Supplier";
            this.shtProductionReportList.Columns.Get(12).Tag = "Supplier";
            this.shtProductionReportList.Columns.Get(12).Width = 120F;
            this.shtProductionReportList.Columns.Get(13).AllowAutoFilter = true;
            this.shtProductionReportList.Columns.Get(13).AllowAutoSort = true;
            this.shtProductionReportList.Columns.Get(13).Label = "Supplier Name";
            this.shtProductionReportList.Columns.Get(13).Tag = "Supplier Name";
            this.shtProductionReportList.Columns.Get(13).Width = 120F;
            this.shtProductionReportList.Columns.Get(14).AllowAutoFilter = true;
            this.shtProductionReportList.Columns.Get(14).AllowAutoSort = true;
            this.shtProductionReportList.Columns.Get(14).Label = "Rework";
            this.shtProductionReportList.Columns.Get(14).Tag = "Rework";
            this.shtProductionReportList.Columns.Get(14).Width = 100F;
            this.shtProductionReportList.Columns.Get(15).AllowAutoFilter = true;
            this.shtProductionReportList.Columns.Get(15).AllowAutoSort = true;
            this.shtProductionReportList.Columns.Get(15).Label = "Lot No.";
            this.shtProductionReportList.Columns.Get(15).Locked = true;
            this.shtProductionReportList.Columns.Get(15).Tag = "Lot No.";
            this.shtProductionReportList.Columns.Get(15).Width = 150F;
            this.shtProductionReportList.Columns.Get(16).AllowAutoFilter = true;
            this.shtProductionReportList.Columns.Get(16).AllowAutoSort = true;
            this.shtProductionReportList.Columns.Get(16).Label = "Customer Lot No.";
            this.shtProductionReportList.Columns.Get(16).Tag = "Customer Lot No.";
            this.shtProductionReportList.Columns.Get(16).Width = 120F;
            this.shtProductionReportList.Columns.Get(17).AllowAutoFilter = true;
            this.shtProductionReportList.Columns.Get(17).AllowAutoSort = true;
            this.shtProductionReportList.Columns.Get(17).Label = "Person In Charge";
            this.shtProductionReportList.Columns.Get(17).Tag = "Person In Charge";
            this.shtProductionReportList.Columns.Get(17).Width = 120F;
            this.shtProductionReportList.Columns.Get(18).AllowAutoFilter = true;
            this.shtProductionReportList.Columns.Get(18).AllowAutoSort = true;
            this.shtProductionReportList.Columns.Get(18).Label = "Person In Charge Name";
            this.shtProductionReportList.Columns.Get(18).Width = 150F;
            this.shtProductionReportList.Columns.Get(19).AllowAutoFilter = true;
            this.shtProductionReportList.Columns.Get(19).AllowAutoSort = true;
            this.shtProductionReportList.Columns.Get(19).Label = "Total OK";
            this.shtProductionReportList.Columns.Get(19).Locked = true;
            this.shtProductionReportList.Columns.Get(19).Tag = "Total OK";
            this.shtProductionReportList.Columns.Get(19).Width = 100F;
            this.shtProductionReportList.Columns.Get(20).AllowAutoFilter = true;
            this.shtProductionReportList.Columns.Get(20).AllowAutoSort = true;
            this.shtProductionReportList.Columns.Get(20).Label = "Total NG";
            this.shtProductionReportList.Columns.Get(20).Tag = "Total NG";
            this.shtProductionReportList.Columns.Get(20).Width = 100F;
            this.shtProductionReportList.Columns.Get(21).AllowAutoFilter = true;
            this.shtProductionReportList.Columns.Get(21).AllowAutoSort = true;
            this.shtProductionReportList.Columns.Get(21).Label = "Remark";
            this.shtProductionReportList.Columns.Get(21).Locked = true;
            this.shtProductionReportList.Columns.Get(21).Tag = "Remark";
            this.shtProductionReportList.Columns.Get(21).Width = 112F;
            this.shtProductionReportList.DataAutoCellTypes = false;
            this.shtProductionReportList.DataAutoHeadings = false;
            this.shtProductionReportList.DataAutoSizeColumns = false;
            this.shtProductionReportList.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.shtProductionReportList.RowHeader.Columns.Default.Resizable = true;
            this.shtProductionReportList.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.shtProductionReportList.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.shtProductionReportList.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpProductionReportList.SetActiveViewport(0, 1, 0);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Rubik.Forms.Properties.Resources.FIND_TEXT;
            this.pictureBox1.Location = new System.Drawing.Point(13, 50);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
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
            this.txtSearch.Location = new System.Drawing.Point(58, 53);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PathString = null;
            this.txtSearch.PathValue = "";
            this.txtSearch.Size = new System.Drawing.Size(831, 26);
            this.txtSearch.TabIndex = 7;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miEdit,
            this.miDelete});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(153, 70);
            // 
            // miEdit
            // 
            this.miEdit.Name = "miEdit";
            this.miEdit.Size = new System.Drawing.Size(152, 22);
            this.miEdit.Text = "Edit";
            this.miEdit.Click += new System.EventHandler(this.miEdit_Click);
            // 
            // miDelete
            // 
            this.miDelete.Name = "miDelete";
            this.miDelete.Size = new System.Drawing.Size(152, 22);
            this.miDelete.Text = "Delete";
            this.miDelete.Click += new System.EventHandler(this.miDelete_Click);
            // 
            // TRN200_WorkResultList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(894, 355);
            this.ExportObject = this.fpProductionReportList;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TRN200_WorkResultList";
            this.Text = "Production Report List";
            this.Load += new System.EventHandler(this.TRN010_Load);
            this.Shown += new System.EventHandler(this.TRN010_Shown);
            this.Controls.SetChildIndex(this.pnlContainer, 0);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpProductionReportList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtProductionReportList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ctxMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EVOFramework.Windows.Forms.EVOLabel stcHead;
        private FarPoint.Win.Spread.FpSpread fpProductionReportList;
        private FarPoint.Win.Spread.SheetView shtProductionReportList;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem miEdit;
        private System.Windows.Forms.ToolStripMenuItem miDelete;
        private EVOFramework.Windows.Forms.EVOLabel stcDash;
        private EVOFramework.Windows.Forms.EVOLabel stcPeriod;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtPeriodBegin;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtPeriodEnd;
        private System.Windows.Forms.PictureBox pictureBox1;
        private EVOFramework.Windows.Forms.EVOTextBox txtSearch;
    }
}
