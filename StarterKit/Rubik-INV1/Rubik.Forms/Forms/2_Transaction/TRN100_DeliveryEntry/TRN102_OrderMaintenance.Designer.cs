
namespace Rubik.Transaction
{
    partial class TRN102_OrderSelection
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
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType2 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TRN102_OrderSelection));
            this.dmc = new EVOFramework.Data.UIDataModelController(this.components);
            this.fpView = new FarPoint.Win.Spread.FpSpread();
            this.shtView = new FarPoint.Win.Spread.SheetView();
            this.evoLabel1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel2 = new EVOFramework.Windows.Forms.EVOLabel();
            this.dtPeriodEnd = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.evoLabel3 = new EVOFramework.Windows.Forms.EVOLabel();
            this.dtPeriodBegin = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.evoLabel4 = new EVOFramework.Windows.Forms.EVOLabel();
            this.btnRefresh = new EVOFramework.Windows.Forms.EVOButton();
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
            this.pnlContainer.Controls.Add(this.btnRefresh);
            this.pnlContainer.Controls.Add(this.evoLabel4);
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
            this.pnlContainer.Size = new System.Drawing.Size(863, 465);
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
            this.fpView.Location = new System.Drawing.Point(12, 102);
            this.fpView.Name = "fpView";
            this.fpView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtView});
            this.fpView.Size = new System.Drawing.Size(839, 328);
            this.fpView.TabIndex = 3;
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
            this.shtView.ColumnCount = 13;
            this.shtView.RowCount = 0;
            this.shtView.AutoCalculation = false;
            this.shtView.AutoGenerateColumns = false;
            this.shtView.ColumnHeader.Cells.Get(0, 0).Value = " ";
            this.shtView.ColumnHeader.Cells.Get(0, 1).Value = "Order Detail No";
            this.shtView.ColumnHeader.Cells.Get(0, 2).Value = "Price";
            this.shtView.ColumnHeader.Cells.Get(0, 3).Value = "Amount";
            this.shtView.ColumnHeader.Cells.Get(0, 4).Value = "Order No.";
            this.shtView.ColumnHeader.Cells.Get(0, 5).Value = "PO No.";
            this.shtView.ColumnHeader.Cells.Get(0, 6).Value = "M/N.";
            this.shtView.ColumnHeader.Cells.Get(0, 7).Value = "Part No.";
            this.shtView.ColumnHeader.Cells.Get(0, 8).Value = "Delivery Date";
            this.shtView.ColumnHeader.Cells.Get(0, 9).Value = "Order QTY";
            this.shtView.ColumnHeader.Cells.Get(0, 10).Value = "Remain Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 11).Value = "Return Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 12).Value = "Deliveried Qty";
            this.shtView.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtView.Columns.Get(0).CellType = checkBoxCellType2;
            this.shtView.Columns.Get(0).Label = " ";
            this.shtView.Columns.Get(0).Locked = false;
            this.shtView.Columns.Get(0).Width = 20F;
            this.shtView.Columns.Get(1).Label = "Order Detail No";
            this.shtView.Columns.Get(1).Visible = false;
            this.shtView.Columns.Get(1).Width = 150F;
            this.shtView.Columns.Get(2).Label = "Price";
            this.shtView.Columns.Get(2).Visible = false;
            this.shtView.Columns.Get(3).Label = "Amount";
            this.shtView.Columns.Get(3).Visible = false;
            this.shtView.Columns.Get(3).Width = 70F;
            this.shtView.Columns.Get(4).AllowAutoFilter = true;
            this.shtView.Columns.Get(4).AllowAutoSort = true;
            this.shtView.Columns.Get(4).Label = "Order No.";
            this.shtView.Columns.Get(4).Tag = "Order No.";
            this.shtView.Columns.Get(4).Width = 115F;
            this.shtView.Columns.Get(5).AllowAutoFilter = true;
            this.shtView.Columns.Get(5).AllowAutoSort = true;
            this.shtView.Columns.Get(5).Label = "PO No.";
            this.shtView.Columns.Get(5).Locked = true;
            this.shtView.Columns.Get(5).Tag = "Lot";
            this.shtView.Columns.Get(5).Width = 115F;
            this.shtView.Columns.Get(6).AllowAutoFilter = true;
            this.shtView.Columns.Get(6).AllowAutoSort = true;
            this.shtView.Columns.Get(6).Label = "M/N.";
            this.shtView.Columns.Get(6).Width = 115F;
            this.shtView.Columns.Get(7).AllowAutoFilter = true;
            this.shtView.Columns.Get(7).AllowAutoSort = true;
            this.shtView.Columns.Get(7).Label = "Part No.";
            this.shtView.Columns.Get(7).Width = 115F;
            this.shtView.Columns.Get(8).AllowAutoFilter = true;
            this.shtView.Columns.Get(8).AllowAutoSort = true;
            this.shtView.Columns.Get(8).Label = "Delivery Date";
            this.shtView.Columns.Get(8).Width = 115F;
            this.shtView.Columns.Get(9).AllowAutoFilter = true;
            this.shtView.Columns.Get(9).Label = "Order QTY";
            this.shtView.Columns.Get(9).Width = 110F;
            this.shtView.Columns.Get(10).AllowAutoFilter = true;
            this.shtView.Columns.Get(10).AllowAutoSort = true;
            this.shtView.Columns.Get(10).Label = "Remain Qty";
            this.shtView.Columns.Get(10).Locked = true;
            this.shtView.Columns.Get(10).Tag = "Remain Qty";
            this.shtView.Columns.Get(10).Width = 115F;
            this.shtView.Columns.Get(11).Label = "Return Qty";
            this.shtView.Columns.Get(11).Visible = false;
            this.shtView.Columns.Get(11).Width = 115F;
            this.shtView.Columns.Get(12).AllowAutoFilter = true;
            this.shtView.Columns.Get(12).AllowAutoSort = true;
            this.shtView.Columns.Get(12).Label = "Deliveried Qty";
            this.shtView.Columns.Get(12).Locked = false;
            this.shtView.Columns.Get(12).Tag = "Deliveried Qty";
            this.shtView.Columns.Get(12).Width = 115F;
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
            this.evoLabel1.PathValue = "Order Selection";
            this.evoLabel1.Size = new System.Drawing.Size(266, 39);
            this.evoLabel1.TabIndex = 7;
            this.evoLabel1.Text = "Order Selection";
            // 
            // evoLabel2
            // 
            this.evoLabel2.AppearanceName = "";
            this.evoLabel2.ControlID = "";
            this.evoLabel2.Location = new System.Drawing.Point(21, 63);
            this.evoLabel2.Name = "evoLabel2";
            this.evoLabel2.PathString = null;
            this.evoLabel2.PathValue = "Delivery Date";
            this.evoLabel2.Size = new System.Drawing.Size(105, 28);
            this.evoLabel2.TabIndex = 5;
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
            this.dtPeriodEnd.Location = new System.Drawing.Point(344, 67);
            this.dtPeriodEnd.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtPeriodEnd.Name = "dtPeriodEnd";
            this.dtPeriodEnd.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtPeriodEnd.NZValue")));
            this.dtPeriodEnd.PathString = null;
            this.dtPeriodEnd.PathValue = ((object)(resources.GetObject("dtPeriodEnd.PathValue")));
            this.dtPeriodEnd.ReadOnly = false;
            this.dtPeriodEnd.ShowButton = true;
            this.dtPeriodEnd.Size = new System.Drawing.Size(185, 20);
            this.dtPeriodEnd.TabIndex = 1;
            this.dtPeriodEnd.Value = null;
            // 
            // evoLabel3
            // 
            this.evoLabel3.AppearanceName = "";
            this.evoLabel3.AutoSize = true;
            this.evoLabel3.ControlID = "";
            this.evoLabel3.Location = new System.Drawing.Point(323, 68);
            this.evoLabel3.Name = "evoLabel3";
            this.evoLabel3.PathString = null;
            this.evoLabel3.PathValue = "-";
            this.evoLabel3.Size = new System.Drawing.Size(15, 19);
            this.evoLabel3.TabIndex = 6;
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
            this.dtPeriodBegin.Location = new System.Drawing.Point(132, 67);
            this.dtPeriodBegin.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtPeriodBegin.Name = "dtPeriodBegin";
            this.dtPeriodBegin.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtPeriodBegin.NZValue")));
            this.dtPeriodBegin.PathString = null;
            this.dtPeriodBegin.PathValue = ((object)(resources.GetObject("dtPeriodBegin.PathValue")));
            this.dtPeriodBegin.ReadOnly = false;
            this.dtPeriodBegin.ShowButton = true;
            this.dtPeriodBegin.Size = new System.Drawing.Size(185, 20);
            this.dtPeriodBegin.TabIndex = 0;
            this.dtPeriodBegin.Value = null;
            // 
            // evoLabel4
            // 
            this.evoLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.evoLabel4.AppearanceName = "";
            this.evoLabel4.ControlID = "";
            this.evoLabel4.Location = new System.Drawing.Point(12, 433);
            this.evoLabel4.Name = "evoLabel4";
            this.evoLabel4.PathString = null;
            this.evoLabel4.PathValue = "** Show only orders that have remaining";
            this.evoLabel4.Size = new System.Drawing.Size(747, 32);
            this.evoLabel4.TabIndex = 100026;
            this.evoLabel4.Text = "** Show only orders that have remaining";
            this.evoLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnRefresh
            // 
            this.btnRefresh.AppearanceName = "";
            this.btnRefresh.AutoSize = true;
            this.btnRefresh.BackgroundImage = global::Rubik.Forms.Properties.Resources.REFRESH;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.ControlID = null;
            this.btnRefresh.Location = new System.Drawing.Point(537, 62);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(34, 29);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // TRN102_OrderSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(863, 515);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 396);
            this.Name = "TRN102_OrderSelection";
            this.Text = "TRN102: Order Selection";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Lot_Maintenance_Load);
            this.Shown += new System.EventHandler(this.TRN102_OrderSelection_Shown);
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
        private EVOFramework.Windows.Forms.EVOLabel evoLabel4;
        private EVOFramework.Windows.Forms.EVOButton btnRefresh;
    }
}
