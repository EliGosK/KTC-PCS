namespace Rubik.Forms.FindDialog
{
    partial class DynamicFindDialog
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtSearch = new EVOFramework.Windows.Forms.EVOTextBox();
            this.pnlContainer = new EVOFramework.Windows.Forms.EVOPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.fpData = new FarPoint.Win.Spread.FpSpread();
            this.shtData = new FarPoint.Win.Spread.SheetView();
            this.lblTitle = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoPanel1 = new EVOFramework.Windows.Forms.EVOPanel();
            this.tmrAutoComplete = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlContainer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtData)).BeginInit();
            this.evoPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Rubik.Forms.Properties.Resources.FIND_TEXT;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 47;
            this.pictureBox1.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.AppearanceName = "";
            this.txtSearch.AppearanceReadOnlyName = "";
            this.txtSearch.ControlID = "";
            this.txtSearch.DisableRestrictChar = false;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtSearch.HelpButton = null;
            this.txtSearch.Location = new System.Drawing.Point(34, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PathString = null;
            this.txtSearch.PathValue = "";
            this.txtSearch.Size = new System.Drawing.Size(752, 26);
            this.txtSearch.TabIndex = 45;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // pnlContainer
            // 
            this.pnlContainer.AppearanceName = "FormBGColor";
            this.pnlContainer.Controls.Add(this.tableLayoutPanel1);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(792, 466);
            this.pnlContainer.TabIndex = 49;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.fpData, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.evoPanel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(792, 466);
            this.tableLayoutPanel1.TabIndex = 48;
            // 
            // fpData
            // 
            this.fpData.About = "2.5.2015.2005";
            this.fpData.AccessibleDescription = "fpData, Sheet1, Row 0, Column 0, ";
            this.fpData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fpData.BackColor = System.Drawing.SystemColors.Control;
            this.fpData.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpData.Location = new System.Drawing.Point(3, 59);
            this.fpData.Name = "fpData";
            this.fpData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtData});
            this.fpData.Size = new System.Drawing.Size(786, 404);
            this.fpData.TabIndex = 4;
            this.fpData.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpData.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpData_CellDoubleClick);
            this.fpData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpData_KeyDown);
            // 
            // shtData
            // 
            this.shtData.Reset();
            this.shtData.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtData.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtData.ColumnCount = 0;
            this.shtData.RowCount = 0;
            this.shtData.AutoCalculation = false;
            this.shtData.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtData.DataAutoCellTypes = false;
            this.shtData.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
            this.shtData.RowHeader.Columns.Default.Resizable = true;
            this.shtData.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpData.SetActiveViewport(0, 1, 1);
            // 
            // lblTitle
            // 
            this.lblTitle.AppearanceName = "Title";
            this.lblTitle.AutoSize = true;
            this.lblTitle.ControlID = "";
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(3);
            this.lblTitle.PathString = null;
            this.lblTitle.PathValue = "Data List";
            this.lblTitle.Size = new System.Drawing.Size(786, 19);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Data List";
            // 
            // evoPanel1
            // 
            this.evoPanel1.AppearanceName = "";
            this.evoPanel1.AutoSize = true;
            this.evoPanel1.Controls.Add(this.pictureBox1);
            this.evoPanel1.Controls.Add(this.txtSearch);
            this.evoPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.evoPanel1.Location = new System.Drawing.Point(3, 22);
            this.evoPanel1.Name = "evoPanel1";
            this.evoPanel1.Size = new System.Drawing.Size(786, 31);
            this.evoPanel1.TabIndex = 1;
            // 
            // tmrAutoComplete
            // 
            this.tmrAutoComplete.Tick += new System.EventHandler(this.tmrAutoComplete_Tick);
            // 
            // DynamicFindDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(792, 466);
            this.Controls.Add(this.pnlContainer);
            this.MinimumSize = new System.Drawing.Size(402, 228);
            this.Name = "DynamicFindDialog";
            this.Text = "Find Dialog";
            this.Activated += new System.EventHandler(this.DynamicFindDialog_Activated);
            this.Deactivate += new System.EventHandler(this.DynamicFindDialog_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DynamicFindDialog_FormClosing);
            this.Load += new System.EventHandler(this.DynamicFindDialog_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DynamicFindDialog_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlContainer.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtData)).EndInit();
            this.evoPanel1.ResumeLayout(false);
            this.evoPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private EVOFramework.Windows.Forms.EVOTextBox txtSearch;
        private EVOFramework.Windows.Forms.EVOPanel pnlContainer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private EVOFramework.Windows.Forms.EVOLabel lblTitle;
        private EVOFramework.Windows.Forms.EVOPanel evoPanel1;
        private FarPoint.Win.Spread.FpSpread fpItemView;
        private FarPoint.Win.Spread.SheetView shtData;
        private System.Windows.Forms.Timer tmrAutoComplete;
        private FarPoint.Win.Spread.FpSpread fpData;
    }
}
