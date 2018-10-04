namespace SystemMaintenance.Forms
{
    partial class SFM0101_ScreenList
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
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.stcFind = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtFind = new EVOFramework.Windows.Forms.EVOTextBox();
            this.fpScreen = new FarPoint.Win.Spread.FpSpread();
            this.shtScreen = new FarPoint.Win.Spread.SheetView();
            this.btnRegister = new EVOFramework.Windows.Forms.EVOButton();
            this.btnCancel = new EVOFramework.Windows.Forms.EVOButton();
            ((System.ComponentModel.ISupportInitialize)(this.fpScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // stcFind
            // 
            this.stcFind.AppearanceName = "";
            this.stcFind.ControlID = "";
            this.stcFind.Location = new System.Drawing.Point(3, 11);
            this.stcFind.Name = "stcFind";
            this.stcFind.PathString = null;
            this.stcFind.PathValue = "Finding:";
            this.stcFind.Size = new System.Drawing.Size(69, 23);
            this.stcFind.TabIndex = 0;
            this.stcFind.Text = "Finding:";
            this.stcFind.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtFind
            // 
            this.txtFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFind.AppearanceName = "";
            this.txtFind.AppearanceReadOnlyName = "";
            this.txtFind.ControlID = "";
            this.txtFind.DisableRestrictChar = true;
            this.txtFind.HelpButton = null;
            this.txtFind.Location = new System.Drawing.Point(78, 8);
            this.txtFind.Name = "txtFind";
            this.txtFind.PathString = null;
            this.txtFind.PathValue = "";
            this.txtFind.Size = new System.Drawing.Size(298, 20);
            this.txtFind.TabIndex = 1;
            this.txtFind.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFind_KeyUp);
            // 
            // fpScreen
            // 
            this.fpScreen.About = "2.5.2015.2005";
            this.fpScreen.AccessibleDescription = "fpScreen, Sheet1";
            this.fpScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fpScreen.BackColor = System.Drawing.SystemColors.Control;
            this.fpScreen.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpScreen.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpScreen.Location = new System.Drawing.Point(6, 37);
            this.fpScreen.Name = "fpScreen";
            this.fpScreen.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpScreen.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpScreen.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpScreen.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtScreen});
            this.fpScreen.Size = new System.Drawing.Size(370, 233);
            this.fpScreen.TabIndex = 2;
            this.fpScreen.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // shtScreen
            // 
            this.shtScreen.Reset();
            this.shtScreen.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtScreen.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtScreen.ColumnCount = 3;
            this.shtScreen.RowCount = 0;
            this.shtScreen.AutoCalculation = false;
            this.shtScreen.AutoGenerateColumns = false;
            this.shtScreen.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.shtScreen.ColumnHeader.Cells.Get(0, 1).Value = "Screen Code";
            this.shtScreen.ColumnHeader.Cells.Get(0, 2).Value = "Original Title";
            this.shtScreen.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtScreen.Columns.Get(0).CellType = checkBoxCellType1;
            this.shtScreen.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.shtScreen.Columns.Get(0).Label = "Sel";
            this.shtScreen.Columns.Get(0).Width = 38F;
            this.shtScreen.Columns.Get(1).AllowAutoFilter = true;
            this.shtScreen.Columns.Get(1).AllowAutoSort = true;
            this.shtScreen.Columns.Get(1).CellType = textCellType1;
            this.shtScreen.Columns.Get(1).Label = "Screen Code";
            this.shtScreen.Columns.Get(1).Locked = true;
            this.shtScreen.Columns.Get(1).Width = 137F;
            this.shtScreen.Columns.Get(2).AllowAutoFilter = true;
            this.shtScreen.Columns.Get(2).AllowAutoSort = true;
            this.shtScreen.Columns.Get(2).CellType = textCellType2;
            this.shtScreen.Columns.Get(2).Label = "Original Title";
            this.shtScreen.Columns.Get(2).Locked = true;
            this.shtScreen.Columns.Get(2).Width = 146F;
            this.shtScreen.DataAutoCellTypes = false;
            this.shtScreen.DataAutoHeadings = false;
            this.shtScreen.DataAutoSizeColumns = false;
            this.shtScreen.RowHeader.Columns.Default.Resizable = true;
            this.shtScreen.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpScreen.SetActiveViewport(0, 1, 0);
            // 
            // btnRegister
            // 
            this.btnRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegister.AppearanceName = "";
            this.btnRegister.ControlID = null;
            this.btnRegister.Location = new System.Drawing.Point(220, 276);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 23);
            this.btnRegister.TabIndex = 3;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AppearanceName = "";
            this.btnCancel.ControlID = null;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(301, 276);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SFM0101_ScreenList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(384, 307);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.fpScreen);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.stcFind);
            this.Name = "SFM0101_ScreenList";
            this.ShowInTaskbar = false;
            this.Text = "Screen List Dialog";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SFM011_ScreenList_Load);
            this.Shown += new System.EventHandler(this.SFM011_ScreenList_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.fpScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtScreen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EVOFramework.Windows.Forms.EVOLabel stcFind;
        private EVOFramework.Windows.Forms.EVOTextBox txtFind;
        private FarPoint.Win.Spread.FpSpread fpScreen;
        private FarPoint.Win.Spread.SheetView shtScreen;
        private EVOFramework.Windows.Forms.EVOButton btnRegister;
        private EVOFramework.Windows.Forms.EVOButton btnCancel;
    }
}