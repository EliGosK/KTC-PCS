namespace SystemMaintenance.Forms
{
    partial class AdvanceSearchDialog
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
            this.pnlContainer = new EVOFramework.Windows.Forms.EVOPanel();
            this.btnCancel = new EVOFramework.Windows.Forms.EVOButton();
            this.btnOK = new EVOFramework.Windows.Forms.EVOButton();
            this.fpQueryList = new FarPoint.Win.Spread.FpSpread();
            this.shtQueryList = new FarPoint.Win.Spread.SheetView();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpQueryList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtQueryList)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.AppearanceName = "FormBGColor";
            this.pnlContainer.BackColor = System.Drawing.Color.AliceBlue;
            this.pnlContainer.Controls.Add(this.btnCancel);
            this.pnlContainer.Controls.Add(this.btnOK);
            this.pnlContainer.Controls.Add(this.fpQueryList);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(511, 457);
            this.pnlContainer.TabIndex = 49;
            // 
            // btnCancel
            // 
            this.btnCancel.AppearanceName = "";
            this.btnCancel.ControlID = null;
            this.btnCancel.Location = new System.Drawing.Point(424, 407);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 34);
            this.btnCancel.TabIndex = 49;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.AppearanceName = "";
            this.btnOK.ControlID = null;
            this.btnOK.Location = new System.Drawing.Point(327, 407);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 34);
            this.btnOK.TabIndex = 49;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // fpQueryList
            // 
            this.fpQueryList.About = "2.5.2015.2005";
            this.fpQueryList.AccessibleDescription = "fpQueryList, Sheet1, Row 0, Column 0, ";
            this.fpQueryList.BackColor = System.Drawing.Color.AliceBlue;
            this.fpQueryList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fpQueryList.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpQueryList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpQueryList.Location = new System.Drawing.Point(12, 12);
            this.fpQueryList.Name = "fpQueryList";
            this.fpQueryList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpQueryList.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpQueryList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpQueryList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtQueryList});
            this.fpQueryList.Size = new System.Drawing.Size(487, 389);
            this.fpQueryList.TabIndex = 48;
            this.fpQueryList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpQueryList.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.fpQueryList_ButtonClicked);
            // 
            // shtQueryList
            // 
            this.shtQueryList.Reset();
            this.shtQueryList.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtQueryList.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtQueryList.ColumnCount = 7;
            this.shtQueryList.RowCount = 3;
            this.shtQueryList.AutoCalculation = false;
            this.shtQueryList.AutoGenerateColumns = false;
            this.shtQueryList.ColumnHeader.Cells.Get(0, 0).Value = " ";
            this.shtQueryList.ColumnHeader.Cells.Get(0, 1).Value = "Column Index";
            this.shtQueryList.ColumnHeader.Cells.Get(0, 2).Value = "Column Name";
            this.shtQueryList.ColumnHeader.Cells.Get(0, 3).Value = "Column Type";
            this.shtQueryList.ColumnHeader.Cells.Get(0, 4).Value = "Sign";
            this.shtQueryList.ColumnHeader.Cells.Get(0, 5).Value = "Value1";
            this.shtQueryList.ColumnHeader.Cells.Get(0, 6).Value = "Value2";
            this.shtQueryList.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtQueryList.Columns.Get(0).CellType = checkBoxCellType1;
            this.shtQueryList.Columns.Get(0).Label = " ";
            this.shtQueryList.Columns.Get(0).Width = 22F;
            this.shtQueryList.Columns.Get(2).Label = "Column Name";
            this.shtQueryList.Columns.Get(2).Width = 142F;
            this.shtQueryList.Columns.Get(4).Label = "Sign";
            this.shtQueryList.Columns.Get(4).Width = 75F;
            this.shtQueryList.Columns.Get(5).Label = "Value1";
            this.shtQueryList.Columns.Get(5).Width = 100F;
            this.shtQueryList.Columns.Get(6).Label = "Value2";
            this.shtQueryList.Columns.Get(6).Width = 100F;
            this.shtQueryList.DataAutoSizeColumns = false;
            this.shtQueryList.RowHeader.Columns.Default.Resizable = true;
            this.shtQueryList.RowHeader.Columns.Get(0).Width = 36F;
            this.shtQueryList.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // AdvanceSearchDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(511, 457);
            this.Controls.Add(this.pnlContainer);
            this.MinimumSize = new System.Drawing.Size(402, 228);
            this.Name = "AdvanceSearchDialog";
            this.Text = "Advance Search";
            this.Load += new System.EventHandler(this.AdvanceSearchDialog_Load);
            this.pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpQueryList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtQueryList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EVOFramework.Windows.Forms.EVOPanel pnlContainer;
        private System.Windows.Forms.Timer tmrAutoComplete;
        private FarPoint.Win.Spread.FpSpread fpQueryList;
        private FarPoint.Win.Spread.SheetView shtQueryList;
        private EVOFramework.Windows.Forms.EVOButton btnCancel;
        private EVOFramework.Windows.Forms.EVOButton btnOK;
    }
}
