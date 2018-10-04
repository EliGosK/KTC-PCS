namespace SystemMaintenance.Forms
{
    partial class SFM007_ScreenDetailMaintenance
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
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.grpSystemScreenList = new EVOFramework.Windows.Forms.EVOGroupBox();
            this.grpIconDisplay = new EVOFramework.Windows.Forms.EVOGroupBox();
            this.btnChangeIcon = new EVOFramework.Windows.Forms.EVOButton();
            this.picIconDisplay = new System.Windows.Forms.PictureBox();
            this.cmsClearImage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtFindScreen = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblFindScreen = new EVOFramework.Windows.Forms.EVOLabel();
            this.fpScreenList = new FarPoint.Win.Spread.FpSpread();
            this.shtScreenList = new FarPoint.Win.Spread.SheetView();
            this.lblLanguage = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboLanguage = new EVOFramework.Windows.Forms.EVOComboBox();
            this.grpSystemDetailList = new EVOFramework.Windows.Forms.EVOGroupBox();
            this.txtFindScreenDetail = new EVOFramework.Windows.Forms.EVOTextBox();
            this.lblFindScreenDetail = new EVOFramework.Windows.Forms.EVOLabel();
            this.fpScreenDetailList = new FarPoint.Win.Spread.FpSpread();
            this.shtScreenDetailList = new FarPoint.Win.Spread.SheetView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.grpSystemScreenList.SuspendLayout();
            this.grpIconDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIconDisplay)).BeginInit();
            this.cmsClearImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpScreenList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtScreenList)).BeginInit();
            this.grpSystemDetailList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpScreenDetailList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtScreenDetailList)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSystemScreenList
            // 
            this.grpSystemScreenList.AppearanceName = "";
            this.grpSystemScreenList.Controls.Add(this.grpIconDisplay);
            this.grpSystemScreenList.Controls.Add(this.txtFindScreen);
            this.grpSystemScreenList.Controls.Add(this.lblFindScreen);
            this.grpSystemScreenList.Controls.Add(this.fpScreenList);
            this.grpSystemScreenList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSystemScreenList.Location = new System.Drawing.Point(3, 3);
            this.grpSystemScreenList.Name = "grpSystemScreenList";
            this.grpSystemScreenList.Size = new System.Drawing.Size(556, 293);
            this.grpSystemScreenList.TabIndex = 26;
            this.grpSystemScreenList.TabStop = false;
            this.grpSystemScreenList.Text = "System Screen List";
            // 
            // grpIconDisplay
            // 
            this.grpIconDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpIconDisplay.AppearanceName = "";
            this.grpIconDisplay.Controls.Add(this.btnChangeIcon);
            this.grpIconDisplay.Controls.Add(this.picIconDisplay);
            this.grpIconDisplay.Location = new System.Drawing.Point(452, 45);
            this.grpIconDisplay.Name = "grpIconDisplay";
            this.grpIconDisplay.Size = new System.Drawing.Size(98, 130);
            this.grpIconDisplay.TabIndex = 5;
            this.grpIconDisplay.TabStop = false;
            this.grpIconDisplay.Text = "Icon Display";
            // 
            // btnChangeIcon
            // 
            this.btnChangeIcon.AppearanceName = "";
            this.btnChangeIcon.ControlID = null;
            this.btnChangeIcon.Location = new System.Drawing.Point(9, 101);
            this.btnChangeIcon.Name = "btnChangeIcon";
            this.btnChangeIcon.Size = new System.Drawing.Size(75, 24);
            this.btnChangeIcon.TabIndex = 1;
            this.btnChangeIcon.Text = "Change";
            this.btnChangeIcon.UseVisualStyleBackColor = true;
            this.btnChangeIcon.Click += new System.EventHandler(this.btnChangeIcon_Click);
            // 
            // picIconDisplay
            // 
            this.picIconDisplay.ContextMenuStrip = this.cmsClearImage;
            this.picIconDisplay.Location = new System.Drawing.Point(9, 19);
            this.picIconDisplay.Name = "picIconDisplay";
            this.picIconDisplay.Size = new System.Drawing.Size(80, 76);
            this.picIconDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picIconDisplay.TabIndex = 0;
            this.picIconDisplay.TabStop = false;
            // 
            // cmsClearImage
            // 
            this.cmsClearImage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeImageToolStripMenuItem});
            this.cmsClearImage.Name = "cmsClearImage";
            this.cmsClearImage.Size = new System.Drawing.Size(147, 26);
            // 
            // removeImageToolStripMenuItem
            // 
            this.removeImageToolStripMenuItem.Name = "removeImageToolStripMenuItem";
            this.removeImageToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.removeImageToolStripMenuItem.Text = "Remove Image";
            this.removeImageToolStripMenuItem.Click += new System.EventHandler(this.removeImageToolStripMenuItem_Click);
            // 
            // txtFindScreen
            // 
            this.txtFindScreen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFindScreen.AppearanceName = "";
            this.txtFindScreen.AppearanceReadOnlyName = "";
            this.txtFindScreen.ControlID = "";
            this.txtFindScreen.DisableRestrictChar = true;
            this.txtFindScreen.HelpButton = null;
            this.txtFindScreen.Location = new System.Drawing.Point(88, 19);
            this.txtFindScreen.Name = "txtFindScreen";
            this.txtFindScreen.PathString = null;
            this.txtFindScreen.PathValue = "";
            this.txtFindScreen.Size = new System.Drawing.Size(357, 20);
            this.txtFindScreen.TabIndex = 4;
            this.txtFindScreen.TextChanged += new System.EventHandler(this.txtFindScreen_TextChanged);
            // 
            // lblFindScreen
            // 
            this.lblFindScreen.AppearanceName = "";
            this.lblFindScreen.ControlID = "";
            this.lblFindScreen.Location = new System.Drawing.Point(6, 22);
            this.lblFindScreen.Name = "lblFindScreen";
            this.lblFindScreen.PathString = null;
            this.lblFindScreen.PathValue = "Finding :";
            this.lblFindScreen.Size = new System.Drawing.Size(76, 20);
            this.lblFindScreen.TabIndex = 3;
            this.lblFindScreen.Text = "Finding :";
            this.lblFindScreen.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // fpScreenList
            // 
            this.fpScreenList.About = "2.5.2015.2005";
            this.fpScreenList.AccessibleDescription = "fpScreenList, Sheet1, Row 0, Column 0, ";
            this.fpScreenList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fpScreenList.BackColor = System.Drawing.Color.Transparent;
            this.fpScreenList.EditModeReplace = true;
            this.fpScreenList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpScreenList.Location = new System.Drawing.Point(6, 45);
            this.fpScreenList.Name = "fpScreenList";
            this.fpScreenList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpScreenList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtScreenList});
            this.fpScreenList.Size = new System.Drawing.Size(439, 242);
            this.fpScreenList.TabIndex = 1;
            this.fpScreenList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpScreenList.EditModeOn += new System.EventHandler(this.fpScreenList_EditModeOn);
            this.fpScreenList.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.fpScreenList_SelectionChanged);
            this.fpScreenList.EditModeOff += new System.EventHandler(this.fpScreenList_EditModeOff);
            // 
            // shtScreenList
            // 
            this.shtScreenList.Reset();
            this.shtScreenList.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtScreenList.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtScreenList.ColumnCount = 4;
            this.shtScreenList.RowCount = 0;
            this.shtScreenList.AutoGenerateColumns = false;
            this.shtScreenList.ColumnHeader.Cells.Get(0, 0).Value = "Screen Code";
            this.shtScreenList.ColumnHeader.Cells.Get(0, 1).Value = "Original Title";
            this.shtScreenList.ColumnHeader.Cells.Get(0, 2).Value = "Display Title";
            this.shtScreenList.ColumnHeader.Cells.Get(0, 3).Value = "Image Code";
            this.shtScreenList.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtScreenList.Columns.Get(0).CellType = textCellType1;
            this.shtScreenList.Columns.Get(0).Label = "Screen Code";
            this.shtScreenList.Columns.Get(0).Tag = "ScreenCode";
            this.shtScreenList.Columns.Get(0).Width = 117F;
            this.shtScreenList.Columns.Get(1).CellType = textCellType2;
            this.shtScreenList.Columns.Get(1).Label = "Original Title";
            this.shtScreenList.Columns.Get(1).Tag = "OriginalTitle";
            this.shtScreenList.Columns.Get(1).Width = 156F;
            this.shtScreenList.Columns.Get(2).CellType = textCellType3;
            this.shtScreenList.Columns.Get(2).Label = "Display Title";
            this.shtScreenList.Columns.Get(2).Tag = "DisplayTitle";
            this.shtScreenList.Columns.Get(2).Width = 184F;
            this.shtScreenList.Columns.Get(3).Label = "Image Code";
            this.shtScreenList.Columns.Get(3).TabStop = false;
            this.shtScreenList.Columns.Get(3).Tag = "ImageCode";
            this.shtScreenList.Columns.Get(3).Visible = false;
            this.shtScreenList.DataAutoCellTypes = false;
            this.shtScreenList.DataAutoHeadings = false;
            this.shtScreenList.DataAutoSizeColumns = false;
            this.shtScreenList.RowHeader.Columns.Default.Resizable = true;
            this.shtScreenList.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpScreenList.SetActiveViewport(0, 1, 0);
            // 
            // lblLanguage
            // 
            this.lblLanguage.AppearanceName = "";
            this.lblLanguage.ControlID = "";
            this.lblLanguage.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLanguage.Location = new System.Drawing.Point(3, 0);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.PathString = null;
            this.lblLanguage.PathValue = "Language :";
            this.lblLanguage.Size = new System.Drawing.Size(64, 24);
            this.lblLanguage.TabIndex = 27;
            this.lblLanguage.Text = "Language :";
            // 
            // cboLanguage
            // 
            this.cboLanguage.AppearanceName = "";
            this.cboLanguage.AppearanceReadOnlyName = "";
            this.cboLanguage.ControlID = null;
            this.cboLanguage.DropDownHeight = 180;
            this.cboLanguage.FormattingEnabled = true;
            this.cboLanguage.IntegralHeight = false;
            this.cboLanguage.Location = new System.Drawing.Point(73, 3);
            this.cboLanguage.Name = "cboLanguage";
            this.cboLanguage.PathString = null;
            this.cboLanguage.PathValue = null;
            this.cboLanguage.Size = new System.Drawing.Size(217, 21);
            this.cboLanguage.TabIndex = 28;
            this.cboLanguage.SelectedValueChanged += new System.EventHandler(this.cboLanguage_SelectedValueChanged);
            // 
            // grpSystemDetailList
            // 
            this.grpSystemDetailList.AppearanceName = "";
            this.grpSystemDetailList.Controls.Add(this.txtFindScreenDetail);
            this.grpSystemDetailList.Controls.Add(this.lblFindScreenDetail);
            this.grpSystemDetailList.Controls.Add(this.fpScreenDetailList);
            this.grpSystemDetailList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSystemDetailList.Location = new System.Drawing.Point(565, 3);
            this.grpSystemDetailList.Name = "grpSystemDetailList";
            this.grpSystemDetailList.Size = new System.Drawing.Size(369, 293);
            this.grpSystemDetailList.TabIndex = 27;
            this.grpSystemDetailList.TabStop = false;
            this.grpSystemDetailList.Text = "System Detail List";
            // 
            // txtFindScreenDetail
            // 
            this.txtFindScreenDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFindScreenDetail.AppearanceName = "";
            this.txtFindScreenDetail.AppearanceReadOnlyName = "";
            this.txtFindScreenDetail.ControlID = "";
            this.txtFindScreenDetail.DisableRestrictChar = false;
            this.txtFindScreenDetail.HelpButton = null;
            this.txtFindScreenDetail.Location = new System.Drawing.Point(88, 19);
            this.txtFindScreenDetail.Name = "txtFindScreenDetail";
            this.txtFindScreenDetail.PathString = null;
            this.txtFindScreenDetail.PathValue = "";
            this.txtFindScreenDetail.Size = new System.Drawing.Size(118, 20);
            this.txtFindScreenDetail.TabIndex = 4;
            this.txtFindScreenDetail.TextChanged += new System.EventHandler(this.txtFindScreenDetail_TextChanged);
            // 
            // lblFindScreenDetail
            // 
            this.lblFindScreenDetail.AppearanceName = "";
            this.lblFindScreenDetail.ControlID = "";
            this.lblFindScreenDetail.Location = new System.Drawing.Point(6, 22);
            this.lblFindScreenDetail.Name = "lblFindScreenDetail";
            this.lblFindScreenDetail.PathString = null;
            this.lblFindScreenDetail.PathValue = "Finding :";
            this.lblFindScreenDetail.Size = new System.Drawing.Size(76, 20);
            this.lblFindScreenDetail.TabIndex = 3;
            this.lblFindScreenDetail.Text = "Finding :";
            this.lblFindScreenDetail.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // fpScreenDetailList
            // 
            this.fpScreenDetailList.About = "2.5.2015.2005";
            this.fpScreenDetailList.AccessibleDescription = "fpScreenDetailList, Sheet1";
            this.fpScreenDetailList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fpScreenDetailList.BackColor = System.Drawing.Color.Transparent;
            this.fpScreenDetailList.EditModeReplace = true;
            this.fpScreenDetailList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpScreenDetailList.Location = new System.Drawing.Point(5, 45);
            this.fpScreenDetailList.Name = "fpScreenDetailList";
            this.fpScreenDetailList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpScreenDetailList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtScreenDetailList});
            this.fpScreenDetailList.Size = new System.Drawing.Size(357, 242);
            this.fpScreenDetailList.TabIndex = 1;
            this.fpScreenDetailList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpScreenDetailList.EditModeOn += new System.EventHandler(this.fpScreenDetailList_EditModeOn);
            this.fpScreenDetailList.EditModeOff += new System.EventHandler(this.fpScreenDetailList_EditModeOff);
            // 
            // shtScreenDetailList
            // 
            this.shtScreenDetailList.Reset();
            this.shtScreenDetailList.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtScreenDetailList.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtScreenDetailList.ColumnCount = 3;
            this.shtScreenDetailList.RowCount = 0;
            this.shtScreenDetailList.AutoGenerateColumns = false;
            this.shtScreenDetailList.ColumnHeader.Cells.Get(0, 0).Value = "Original Caption";
            this.shtScreenDetailList.ColumnHeader.Cells.Get(0, 1).Value = "Display Caption";
            this.shtScreenDetailList.ColumnHeader.Cells.Get(0, 2).Value = "ControlCD";
            this.shtScreenDetailList.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtScreenDetailList.Columns.Get(0).CellType = textCellType4;
            this.shtScreenDetailList.Columns.Get(0).Label = "Original Caption";
            this.shtScreenDetailList.Columns.Get(0).Tag = "OriginalCaption";
            this.shtScreenDetailList.Columns.Get(0).Width = 155F;
            this.shtScreenDetailList.Columns.Get(1).CellType = textCellType5;
            this.shtScreenDetailList.Columns.Get(1).Label = "Display Caption";
            this.shtScreenDetailList.Columns.Get(1).Tag = "DisplayCaption";
            this.shtScreenDetailList.Columns.Get(1).Width = 209F;
            this.shtScreenDetailList.Columns.Get(2).Label = "ControlCD";
            this.shtScreenDetailList.Columns.Get(2).Tag = "ControlCD";
            this.shtScreenDetailList.Columns.Get(2).Visible = false;
            this.shtScreenDetailList.DataAutoCellTypes = false;
            this.shtScreenDetailList.DataAutoHeadings = false;
            this.shtScreenDetailList.DataAutoSizeColumns = false;
            this.shtScreenDetailList.RowHeader.Columns.Default.Resizable = true;
            this.shtScreenDetailList.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpScreenDetailList.SetActiveViewport(0, 1, 0);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(943, 340);
            this.tableLayoutPanel1.TabIndex = 29;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lblLanguage, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cboLanguage, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(937, 29);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel3.Controls.Add(this.grpSystemScreenList, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.grpSystemDetailList, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 38);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(937, 299);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // SFM007_ScreenDetailMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(949, 346);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(800, 380);
            this.Name = "SFM007_ScreenDetailMaintenance";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Screen Detail Maintenance";
            this.Load += new System.EventHandler(this.SFM007_ScreenDetailMaintenance_Load);
            this.grpSystemScreenList.ResumeLayout(false);
            this.grpSystemScreenList.PerformLayout();
            this.grpIconDisplay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picIconDisplay)).EndInit();
            this.cmsClearImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpScreenList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtScreenList)).EndInit();
            this.grpSystemDetailList.ResumeLayout(false);
            this.grpSystemDetailList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpScreenDetailList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtScreenDetailList)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EVOFramework.Windows.Forms.EVOGroupBox grpSystemScreenList;
        private FarPoint.Win.Spread.FpSpread fpScreenList;
        private FarPoint.Win.Spread.SheetView shtScreenList;
        private EVOFramework.Windows.Forms.EVOLabel lblLanguage;
        private EVOFramework.Windows.Forms.EVOComboBox cboLanguage;
        private EVOFramework.Windows.Forms.EVOTextBox txtFindScreen;
        private EVOFramework.Windows.Forms.EVOLabel lblFindScreen;
        private EVOFramework.Windows.Forms.EVOGroupBox grpSystemDetailList;
        private EVOFramework.Windows.Forms.EVOTextBox txtFindScreenDetail;
        private EVOFramework.Windows.Forms.EVOLabel lblFindScreenDetail;
        private FarPoint.Win.Spread.FpSpread fpScreenDetailList;
        private FarPoint.Win.Spread.SheetView shtScreenDetailList;
        private EVOFramework.Windows.Forms.EVOGroupBox grpIconDisplay;
        private EVOFramework.Windows.Forms.EVOButton btnChangeIcon;
        private System.Windows.Forms.PictureBox picIconDisplay;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ContextMenuStrip cmsClearImage;
        private System.Windows.Forms.ToolStripMenuItem removeImageToolStripMenuItem;
    }
}
