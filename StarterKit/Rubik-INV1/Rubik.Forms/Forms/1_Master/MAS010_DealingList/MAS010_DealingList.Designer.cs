namespace Rubik.Master
{
    partial class MAS010_DealingList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAS010_DealingList));
            this.txtFind = new EVOFramework.Windows.Forms.EVOTextBox();
            this.fpView = new FarPoint.Win.Spread.FpSpread();
            this.shtView = new FarPoint.Win.Spread.SheetView();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tlpTitle = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).BeginInit();
            this.ctxMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tlpTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.tlpTitle);
            this.pnlContainer.Controls.Add(this.pictureBox1);
            this.pnlContainer.Controls.Add(this.fpView);
            this.pnlContainer.Controls.Add(this.txtFind);
            this.pnlContainer.Size = new System.Drawing.Size(800, 434);
            // 
            // txtFind
            // 
            this.txtFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFind.AppearanceName = "";
            this.txtFind.AppearanceReadOnlyName = "";
            this.txtFind.BackColor = System.Drawing.Color.White;
            this.txtFind.ControlID = "";
            this.txtFind.DisableRestrictChar = true;
            this.txtFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtFind.ForeColor = System.Drawing.Color.Black;
            this.txtFind.HelpButton = null;
            this.txtFind.Location = new System.Drawing.Point(47, 50);
            this.txtFind.Name = "txtFind";
            this.txtFind.PathString = null;
            this.txtFind.PathValue = "";
            this.txtFind.Size = new System.Drawing.Size(741, 26);
            this.txtFind.TabIndex = 0;
            this.txtFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFind_KeyDown);
            this.txtFind.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFind_KeyUp);
            // 
            // fpView
            // 
            this.fpView.About = "2.5.2015.2005";
            this.fpView.AccessibleDescription = "fpView, Sheet1, Row 0, Column 0, ";
            this.fpView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fpView.BackColor = System.Drawing.Color.AliceBlue;
            this.fpView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fpView.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.Location = new System.Drawing.Point(13, 82);
            this.fpView.Name = "fpView";
            this.fpView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpView.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtView});
            this.fpView.Size = new System.Drawing.Size(775, 340);
            this.fpView.TabIndex = 3;
            this.fpView.TabStop = false;
            this.fpView.TextTipDelay = 1000;
            this.fpView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpView_CellDoubleClick);
            this.fpView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpView_KeyDown);
            this.fpView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fpView_KeyPress);
            this.fpView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fpView_MouseDown);
            // 
            // shtView
            // 
            this.shtView.Reset();
            this.shtView.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtView.ColumnCount = 24;
            this.shtView.RowCount = 0;
            this.shtView.AutoCalculation = false;
            this.shtView.AutoGenerateColumns = false;
            this.shtView.ColumnHeader.Cells.Get(0, 0).Value = "Dealing Code";
            this.shtView.ColumnHeader.Cells.Get(0, 1).Value = "Dealing Name";
            this.shtView.ColumnHeader.Cells.Get(0, 2).Value = "Dealing Type";
            this.shtView.ColumnHeader.Cells.Get(0, 3).Value = "Dealing Type Name";
            this.shtView.ColumnHeader.Cells.Get(0, 4).Value = "Term Of Payment";
            this.shtView.ColumnHeader.Cells.Get(0, 5).Value = "Invoice Pattern";
            this.shtView.ColumnHeader.Cells.Get(0, 6).Value = "Address1 - Address";
            this.shtView.ColumnHeader.Cells.Get(0, 7).Value = "Address1 - Tel";
            this.shtView.ColumnHeader.Cells.Get(0, 8).Value = "Address1 - Fax";
            this.shtView.ColumnHeader.Cells.Get(0, 9).Value = "Address1 - Email";
            this.shtView.ColumnHeader.Cells.Get(0, 10).Value = "Address1 - Contact Person";
            this.shtView.ColumnHeader.Cells.Get(0, 11).Value = "Address1 - Remark";
            this.shtView.ColumnHeader.Cells.Get(0, 12).Value = "Address2 - Address";
            this.shtView.ColumnHeader.Cells.Get(0, 13).Value = "Address2 - Tel";
            this.shtView.ColumnHeader.Cells.Get(0, 14).Value = "Address2 - Fax";
            this.shtView.ColumnHeader.Cells.Get(0, 15).Value = "Address2 - Email";
            this.shtView.ColumnHeader.Cells.Get(0, 16).Value = "Address2 - Contact Person";
            this.shtView.ColumnHeader.Cells.Get(0, 17).Value = "Address2 - Remark";
            this.shtView.ColumnHeader.Cells.Get(0, 18).Value = "Address3 - Address";
            this.shtView.ColumnHeader.Cells.Get(0, 19).Value = "Address3 - Tel";
            this.shtView.ColumnHeader.Cells.Get(0, 20).Value = "Address3 - Fax";
            this.shtView.ColumnHeader.Cells.Get(0, 21).Value = "Address3 - Email";
            this.shtView.ColumnHeader.Cells.Get(0, 22).Value = "Address3 - Contact Person";
            this.shtView.ColumnHeader.Cells.Get(0, 23).Value = "Address3 - Remark";
            this.shtView.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtView.Columns.Get(0).AllowAutoFilter = true;
            this.shtView.Columns.Get(0).AllowAutoSort = true;
            this.shtView.Columns.Get(0).CellType = textCellType1;
            this.shtView.Columns.Get(0).Label = "Dealing Code";
            this.shtView.Columns.Get(0).Locked = true;
            this.shtView.Columns.Get(0).Tag = "LOC_CD";
            this.shtView.Columns.Get(0).Width = 166F;
            this.shtView.Columns.Get(1).AllowAutoFilter = true;
            this.shtView.Columns.Get(1).AllowAutoSort = true;
            this.shtView.Columns.Get(1).CellType = textCellType2;
            this.shtView.Columns.Get(1).Label = "Dealing Name";
            this.shtView.Columns.Get(1).Locked = true;
            this.shtView.Columns.Get(1).Tag = "LOC_NAME";
            this.shtView.Columns.Get(1).Width = 239F;
            this.shtView.Columns.Get(2).AllowAutoFilter = true;
            this.shtView.Columns.Get(2).AllowAutoSort = true;
            this.shtView.Columns.Get(2).CellType = textCellType3;
            this.shtView.Columns.Get(2).Label = "Dealing Type";
            this.shtView.Columns.Get(2).Locked = true;
            this.shtView.Columns.Get(2).Tag = "LOC_TYPE";
            this.shtView.Columns.Get(2).Width = 181F;
            this.shtView.Columns.Get(3).AllowAutoFilter = true;
            this.shtView.Columns.Get(3).AllowAutoSort = true;
            this.shtView.Columns.Get(3).Label = "Dealing Type Name";
            this.shtView.Columns.Get(3).Width = 163F;
            this.shtView.Columns.Get(4).AllowAutoFilter = true;
            this.shtView.Columns.Get(4).AllowAutoSort = true;
            this.shtView.Columns.Get(4).Label = "Term Of Payment";
            this.shtView.Columns.Get(4).Width = 178F;
            this.shtView.Columns.Get(5).AllowAutoFilter = true;
            this.shtView.Columns.Get(5).AllowAutoSort = true;
            this.shtView.Columns.Get(5).Label = "Invoice Pattern";
            this.shtView.Columns.Get(5).Width = 116F;
            this.shtView.Columns.Get(6).AllowAutoFilter = true;
            this.shtView.Columns.Get(6).AllowAutoSort = true;
            this.shtView.Columns.Get(6).Label = "Address1 - Address";
            this.shtView.Columns.Get(6).Tag = "ADDRESS1";
            this.shtView.Columns.Get(6).Width = 120F;
            this.shtView.Columns.Get(7).AllowAutoFilter = true;
            this.shtView.Columns.Get(7).AllowAutoSort = true;
            this.shtView.Columns.Get(7).Label = "Address1 - Tel";
            this.shtView.Columns.Get(7).Tag = "TEL1";
            this.shtView.Columns.Get(7).Width = 120F;
            this.shtView.Columns.Get(8).AllowAutoFilter = true;
            this.shtView.Columns.Get(8).AllowAutoSort = true;
            this.shtView.Columns.Get(8).Label = "Address1 - Fax";
            this.shtView.Columns.Get(8).Tag = "FAX1";
            this.shtView.Columns.Get(8).Width = 120F;
            this.shtView.Columns.Get(9).AllowAutoFilter = true;
            this.shtView.Columns.Get(9).AllowAutoSort = true;
            this.shtView.Columns.Get(9).Label = "Address1 - Email";
            this.shtView.Columns.Get(9).Tag = "EMAIL1";
            this.shtView.Columns.Get(9).Width = 120F;
            this.shtView.Columns.Get(10).AllowAutoFilter = true;
            this.shtView.Columns.Get(10).AllowAutoSort = true;
            this.shtView.Columns.Get(10).Label = "Address1 - Contact Person";
            this.shtView.Columns.Get(10).Tag = "CONTACT_PERSON1";
            this.shtView.Columns.Get(10).Width = 130F;
            this.shtView.Columns.Get(11).AllowAutoFilter = true;
            this.shtView.Columns.Get(11).AllowAutoSort = true;
            this.shtView.Columns.Get(11).Label = "Address1 - Remark";
            this.shtView.Columns.Get(11).Tag = "REMARK1";
            this.shtView.Columns.Get(11).Width = 120F;
            this.shtView.Columns.Get(12).AllowAutoFilter = true;
            this.shtView.Columns.Get(12).AllowAutoSort = true;
            this.shtView.Columns.Get(12).Label = "Address2 - Address";
            this.shtView.Columns.Get(12).Tag = "ADDRESS2";
            this.shtView.Columns.Get(12).Width = 120F;
            this.shtView.Columns.Get(13).AllowAutoFilter = true;
            this.shtView.Columns.Get(13).AllowAutoSort = true;
            this.shtView.Columns.Get(13).Label = "Address2 - Tel";
            this.shtView.Columns.Get(13).Tag = "TEL2";
            this.shtView.Columns.Get(13).Width = 120F;
            this.shtView.Columns.Get(14).AllowAutoFilter = true;
            this.shtView.Columns.Get(14).AllowAutoSort = true;
            this.shtView.Columns.Get(14).Label = "Address2 - Fax";
            this.shtView.Columns.Get(14).Tag = "FAX2";
            this.shtView.Columns.Get(14).Width = 120F;
            this.shtView.Columns.Get(15).AllowAutoFilter = true;
            this.shtView.Columns.Get(15).AllowAutoSort = true;
            this.shtView.Columns.Get(15).Label = "Address2 - Email";
            this.shtView.Columns.Get(15).Tag = "EMAIL2";
            this.shtView.Columns.Get(15).Width = 120F;
            this.shtView.Columns.Get(16).AllowAutoFilter = true;
            this.shtView.Columns.Get(16).AllowAutoSort = true;
            this.shtView.Columns.Get(16).Label = "Address2 - Contact Person";
            this.shtView.Columns.Get(16).Tag = "CONTACT_PERSON2";
            this.shtView.Columns.Get(16).Width = 130F;
            this.shtView.Columns.Get(17).AllowAutoFilter = true;
            this.shtView.Columns.Get(17).AllowAutoSort = true;
            this.shtView.Columns.Get(17).Label = "Address2 - Remark";
            this.shtView.Columns.Get(17).Tag = "REMARK2";
            this.shtView.Columns.Get(17).Width = 120F;
            this.shtView.Columns.Get(18).AllowAutoFilter = true;
            this.shtView.Columns.Get(18).AllowAutoSort = true;
            this.shtView.Columns.Get(18).Label = "Address3 - Address";
            this.shtView.Columns.Get(18).Tag = "ADDRESS3";
            this.shtView.Columns.Get(18).Width = 120F;
            this.shtView.Columns.Get(19).AllowAutoFilter = true;
            this.shtView.Columns.Get(19).AllowAutoSort = true;
            this.shtView.Columns.Get(19).Label = "Address3 - Tel";
            this.shtView.Columns.Get(19).Tag = "TEL3";
            this.shtView.Columns.Get(19).Width = 120F;
            this.shtView.Columns.Get(20).AllowAutoFilter = true;
            this.shtView.Columns.Get(20).AllowAutoSort = true;
            this.shtView.Columns.Get(20).Label = "Address3 - Fax";
            this.shtView.Columns.Get(20).Tag = "FAX3";
            this.shtView.Columns.Get(20).Width = 120F;
            this.shtView.Columns.Get(21).AllowAutoFilter = true;
            this.shtView.Columns.Get(21).AllowAutoSort = true;
            this.shtView.Columns.Get(21).Label = "Address3 - Email";
            this.shtView.Columns.Get(21).Tag = "EMAIL3";
            this.shtView.Columns.Get(21).Width = 120F;
            this.shtView.Columns.Get(22).AllowAutoFilter = true;
            this.shtView.Columns.Get(22).AllowAutoSort = true;
            this.shtView.Columns.Get(22).Label = "Address3 - Contact Person";
            this.shtView.Columns.Get(22).Tag = "CONTACT_PERSON3";
            this.shtView.Columns.Get(22).Width = 130F;
            this.shtView.Columns.Get(23).AllowAutoFilter = true;
            this.shtView.Columns.Get(23).AllowAutoSort = true;
            this.shtView.Columns.Get(23).Label = "Address3 - Remark";
            this.shtView.Columns.Get(23).Tag = "REMARK3";
            this.shtView.Columns.Get(23).Width = 120F;
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
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEdit,
            this.mnuDelete});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(153, 70);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(152, 22);
            this.mnuEdit.Text = "Edit";
            this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(152, 22);
            this.mnuDelete.Text = "Delete";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Rubik.Forms.Properties.Resources.FIND_TEXT;
            this.pictureBox1.Location = new System.Drawing.Point(13, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // tlpTitle
            // 
            this.tlpTitle.AutoSize = true;
            this.tlpTitle.ColumnCount = 1;
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.Controls.Add(this.label1, 0, 0);
            this.tlpTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpTitle.Location = new System.Drawing.Point(0, 0);
            this.tlpTitle.Name = "tlpTitle";
            this.tlpTitle.RowCount = 1;
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpTitle.Size = new System.Drawing.Size(800, 39);
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
            this.label1.PathValue = "Dealing List";
            this.label1.Size = new System.Drawing.Size(205, 39);
            this.label1.TabIndex = 35;
            this.label1.Text = "Dealing List";
            // 
            // MAS010_DealingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 459);
            this.ExportObject = this.fpView;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MAS010_DealingList";
            this.Text = "Dealing List";
            this.Load += new System.EventHandler(this.MAS010_LocationList_Load);
            this.Shown += new System.EventHandler(this.MAS010_LocationList_Shown);
            this.Controls.SetChildIndex(this.pnlContainer, 0);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).EndInit();
            this.ctxMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tlpTitle.ResumeLayout(false);
            this.tlpTitle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EVOFramework.Windows.Forms.EVOTextBox txtFind;
        private FarPoint.Win.Spread.FpSpread fpView;
        private FarPoint.Win.Spread.SheetView shtView;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tlpTitle;
        private EVOFramework.Windows.Forms.EVOLabel label1;
    }
}