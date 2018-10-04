namespace SystemMaintenance.Forms
{
    partial class SFM0092_RegistSubMenu
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
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            this.fpMenuSub = new FarPoint.Win.Spread.FpSpread();
            this.cmsSelectHelper = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectNoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertSelectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shtMenuSub = new FarPoint.Win.Spread.SheetView();
            this.btnRegist = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtFind = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblFind = new EVOFramework.Windows.Forms.EVOLabel();
            ((System.ComponentModel.ISupportInitialize)(this.fpMenuSub)).BeginInit();
            this.cmsSelectHelper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shtMenuSub)).BeginInit();
            this.SuspendLayout();
            // 
            // fpMenuSub
            // 
            this.fpMenuSub.About = "2.5.2015.2005";
            this.fpMenuSub.AccessibleDescription = "fpMenuSub, Sheet1";
            this.fpMenuSub.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fpMenuSub.BackColor = System.Drawing.SystemColors.Control;
            this.fpMenuSub.ContextMenuStrip = this.cmsSelectHelper;
            this.fpMenuSub.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpMenuSub.Location = new System.Drawing.Point(12, 45);
            this.fpMenuSub.Name = "fpMenuSub";
            this.fpMenuSub.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpMenuSub.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpMenuSub.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtMenuSub});
            this.fpMenuSub.Size = new System.Drawing.Size(577, 256);
            this.fpMenuSub.TabIndex = 2;
            this.fpMenuSub.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // cmsSelectHelper
            // 
            this.cmsSelectHelper.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.selectNoneToolStripMenuItem,
            this.invertSelectToolStripMenuItem});
            this.cmsSelectHelper.Name = "cmsSelectHelper";
            this.cmsSelectHelper.Size = new System.Drawing.Size(137, 70);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // selectNoneToolStripMenuItem
            // 
            this.selectNoneToolStripMenuItem.Name = "selectNoneToolStripMenuItem";
            this.selectNoneToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.selectNoneToolStripMenuItem.Text = "Select None";
            this.selectNoneToolStripMenuItem.Click += new System.EventHandler(this.selectNoneToolStripMenuItem_Click);
            // 
            // invertSelectToolStripMenuItem
            // 
            this.invertSelectToolStripMenuItem.Name = "invertSelectToolStripMenuItem";
            this.invertSelectToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.invertSelectToolStripMenuItem.Text = "Invert Select";
            this.invertSelectToolStripMenuItem.Click += new System.EventHandler(this.invertSelectToolStripMenuItem_Click);
            // 
            // shtMenuSub
            // 
            this.shtMenuSub.Reset();
            this.shtMenuSub.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtMenuSub.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtMenuSub.ColumnCount = 3;
            this.shtMenuSub.RowCount = 0;
            this.shtMenuSub.AutoGenerateColumns = false;
            this.shtMenuSub.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.shtMenuSub.ColumnHeader.Cells.Get(0, 1).Value = "Sub Menu Code";
            this.shtMenuSub.ColumnHeader.Cells.Get(0, 2).Value = "Sub Menu Description";
            this.shtMenuSub.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtMenuSub.Columns.Get(0).CellType = checkBoxCellType1;
            this.shtMenuSub.Columns.Get(0).Label = "Sel";
            this.shtMenuSub.Columns.Get(0).Tag = "Sel";
            this.shtMenuSub.Columns.Get(0).Width = 30F;
            this.shtMenuSub.Columns.Get(1).Label = "Sub Menu Code";
            this.shtMenuSub.Columns.Get(1).Tag = "SubMenuCode";
            this.shtMenuSub.Columns.Get(1).Width = 189F;
            this.shtMenuSub.Columns.Get(2).Label = "Sub Menu Description";
            this.shtMenuSub.Columns.Get(2).Tag = "SubMenuDesc";
            this.shtMenuSub.Columns.Get(2).Width = 316F;
            this.shtMenuSub.DataAutoCellTypes = false;
            this.shtMenuSub.DataAutoHeadings = false;
            this.shtMenuSub.DataAutoSizeColumns = false;
            this.shtMenuSub.RowHeader.Columns.Default.Resizable = true;
            this.shtMenuSub.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpMenuSub.SetActiveViewport(0, 1, 0);
            // 
            // btnRegist
            // 
            this.btnRegist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegist.Location = new System.Drawing.Point(422, 307);
            this.btnRegist.Name = "btnRegist";
            this.btnRegist.Size = new System.Drawing.Size(75, 23);
            this.btnRegist.TabIndex = 3;
            this.btnRegist.Text = "Regist";
            this.btnRegist.UseVisualStyleBackColor = true;
            this.btnRegist.Click += new System.EventHandler(this.btnRegist_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(514, 307);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            this.txtFind.Location = new System.Drawing.Point(93, 12);
            this.txtFind.Name = "txtFind";
            this.txtFind.PathString = null;
            this.txtFind.PathValue = "";
            this.txtFind.Size = new System.Drawing.Size(193, 20);
            this.txtFind.TabIndex = 6;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // lblFind
            // 
            this.lblFind.AppearanceName = "";
            this.lblFind.AutoSize = true;
            this.lblFind.ControlID = "";
            this.lblFind.Location = new System.Drawing.Point(40, 15);
            this.lblFind.Name = "lblFind";
            this.lblFind.PathString = null;
            this.lblFind.PathValue = "Finding :";
            this.lblFind.Size = new System.Drawing.Size(47, 13);
            this.lblFind.TabIndex = 5;
            this.lblFind.Text = "Finding :";
            // 
            // SFM0092_RegistSubMenu
            // 
            this.ClientSize = new System.Drawing.Size(601, 346);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.lblFind);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRegist);
            this.Controls.Add(this.fpMenuSub);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SFM0092_RegistSubMenu";
            this.Text = "Regist Sub Menu to Menu Set";
            this.Load += new System.EventHandler(this.SFM0092_RegistSubMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fpMenuSub)).EndInit();
            this.cmsSelectHelper.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shtMenuSub)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread fpMenuSub;
        private FarPoint.Win.Spread.SheetView shtMenuSub;
        private System.Windows.Forms.Button btnRegist;
        private System.Windows.Forms.Button btnCancel;
        private EVOFramework.Windows.Forms.EVOTextBox txtFind;
        private EVOFramework.Windows.Forms.EVOLabel lblFind;
        private System.Windows.Forms.ContextMenuStrip cmsSelectHelper;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectNoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertSelectToolStripMenuItem;

    }
}
