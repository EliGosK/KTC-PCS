
namespace Rubik.Master
{
    partial class MAS090_ClassList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAS090_ClassList));
            this.cmsOperation = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dmc = new EVOFramework.Data.UIDataModelController(this.components);
            this.fpView = new FarPoint.Win.Spread.FpSpread();
            this.shtView = new FarPoint.Win.Spread.SheetView();
            this.txtClsInfoCd = new EVOFramework.Windows.Forms.EVOTextBox();
            this.txtClsCd = new EVOFramework.Windows.Forms.EVOTextBox();
            this.txtClsDesc = new EVOFramework.Windows.Forms.EVOTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.evoLabel1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSEQ = new EVOFramework.Windows.Forms.EVONumericTextBox();
            this.pnlContainer.SuspendLayout();
            this.cmsOperation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContainer.Controls.Add(this.label5);
            this.pnlContainer.Controls.Add(this.label4);
            this.pnlContainer.Controls.Add(this.label2);
            this.pnlContainer.Controls.Add(this.label3);
            this.pnlContainer.Controls.Add(this.label1);
            this.pnlContainer.Controls.Add(this.evoLabel1);
            this.pnlContainer.Controls.Add(this.txtClsDesc);
            this.pnlContainer.Controls.Add(this.txtClsCd);
            this.pnlContainer.Controls.Add(this.txtClsInfoCd);
            this.pnlContainer.Controls.Add(this.txtSEQ);
            this.pnlContainer.Controls.Add(this.fpView);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.None;
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlContainer.Location = new System.Drawing.Point(0, 25);
            this.pnlContainer.Size = new System.Drawing.Size(802, 566);
            // 
            // cmsOperation
            // 
            this.cmsOperation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.cmsOperation.Name = "cmsOperation";
            this.cmsOperation.Size = new System.Drawing.Size(106, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // fpView
            // 
            this.fpView.About = "2.5.2015.2005";
            this.fpView.AccessibleDescription = "fpView, Sheet1";
            this.fpView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fpView.BackColor = System.Drawing.Color.AliceBlue;
            this.fpView.ContextMenuStrip = this.cmsOperation;
            this.fpView.EditModeReplace = true;
            this.fpView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.Location = new System.Drawing.Point(12, 42);
            this.fpView.Name = "fpView";
            this.fpView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtView});
            this.fpView.Size = new System.Drawing.Size(778, 354);
            this.fpView.TabIndex = 100001;
            this.fpView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.fpView_SelectionChanged);
            this.fpView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpView_KeyDown);
            // 
            // shtView
            // 
            this.shtView.Reset();
            this.shtView.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtView.ColumnCount = 5;
            this.shtView.RowCount = 0;
            this.shtView.AutoCalculation = false;
            this.shtView.AutoGenerateColumns = false;
            this.shtView.ColumnHeader.Cells.Get(0, 0).Value = "Class Info Code";
            this.shtView.ColumnHeader.Cells.Get(0, 1).Value = "Class Code";
            this.shtView.ColumnHeader.Cells.Get(0, 2).Value = "Class Description";
            this.shtView.ColumnHeader.Cells.Get(0, 3).Value = "Seq";
            this.shtView.ColumnHeader.Cells.Get(0, 4).Value = "Edit";
            this.shtView.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtView.Columns.Get(0).Label = "Class Info Code";
            this.shtView.Columns.Get(0).Locked = true;
            this.shtView.Columns.Get(0).Tag = "CLS_INFO_CD";
            this.shtView.Columns.Get(0).Width = 200F;
            this.shtView.Columns.Get(1).Label = "Class Code";
            this.shtView.Columns.Get(1).Locked = true;
            this.shtView.Columns.Get(1).Tag = "CLS_CD";
            this.shtView.Columns.Get(1).Width = 200F;
            this.shtView.Columns.Get(2).Label = "Class Description";
            this.shtView.Columns.Get(2).Locked = false;
            this.shtView.Columns.Get(2).Tag = "CLS_DESC";
            this.shtView.Columns.Get(2).Width = 200F;
            this.shtView.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.shtView.Columns.Get(3).Label = "Seq";
            this.shtView.Columns.Get(3).Locked = false;
            this.shtView.Columns.Get(3).Tag = "SEQ";
            this.shtView.Columns.Get(3).Width = 61F;
            this.shtView.Columns.Get(4).CellType = checkBoxCellType1;
            this.shtView.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.shtView.Columns.Get(4).Label = "Edit";
            this.shtView.Columns.Get(4).Tag = "EDIT_FLAG";
            this.shtView.DataAutoCellTypes = false;
            this.shtView.DataAutoHeadings = false;
            this.shtView.DataAutoSizeColumns = false;
            this.shtView.DefaultStyle.ForeColor = System.Drawing.Color.Blue;
            this.shtView.DefaultStyle.Locked = true;
            this.shtView.DefaultStyle.Parent = "DataAreaDefault";
            this.shtView.LockForeColor = System.Drawing.Color.Black;
            this.shtView.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.shtView.RowHeader.Columns.Default.Resizable = true;
            this.shtView.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.shtView.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpView.SetActiveViewport(0, 1, 0);
            // 
            // txtClsInfoCd
            // 
            this.txtClsInfoCd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtClsInfoCd.AppearanceName = "";
            this.txtClsInfoCd.AppearanceReadOnlyName = "";
            this.txtClsInfoCd.ControlID = "";
            this.txtClsInfoCd.DisableRestrictChar = false;
            this.txtClsInfoCd.Enabled = false;
            this.txtClsInfoCd.HelpButton = null;
            this.txtClsInfoCd.Location = new System.Drawing.Point(194, 415);
            this.txtClsInfoCd.MaxLength = 50;
            this.txtClsInfoCd.Name = "txtClsInfoCd";
            this.txtClsInfoCd.PathString = "ClsInfoCd.Value";
            this.txtClsInfoCd.PathValue = "";
            this.txtClsInfoCd.Size = new System.Drawing.Size(250, 27);
            this.txtClsInfoCd.TabIndex = 6;
            this.txtClsInfoCd.TabStop = false;
            // 
            // txtClsCd
            // 
            this.txtClsCd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtClsCd.AppearanceName = "";
            this.txtClsCd.AppearanceReadOnlyName = "";
            this.txtClsCd.ControlID = "";
            this.txtClsCd.DisableRestrictChar = false;
            this.txtClsCd.HelpButton = null;
            this.txtClsCd.Location = new System.Drawing.Point(194, 448);
            this.txtClsCd.MaxLength = 50;
            this.txtClsCd.Name = "txtClsCd";
            this.txtClsCd.PathString = "ClsCd.Value";
            this.txtClsCd.PathValue = "";
            this.txtClsCd.Size = new System.Drawing.Size(250, 27);
            this.txtClsCd.TabIndex = 100013;
            this.txtClsCd.TabStop = false;
            // 
            // txtClsDesc
            // 
            this.txtClsDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtClsDesc.AppearanceName = "";
            this.txtClsDesc.AppearanceReadOnlyName = "";
            this.txtClsDesc.BackColor = System.Drawing.SystemColors.Window;
            this.txtClsDesc.ControlID = "";
            this.txtClsDesc.DisableRestrictChar = false;
            this.txtClsDesc.HelpButton = null;
            this.txtClsDesc.Location = new System.Drawing.Point(194, 482);
            this.txtClsDesc.MaxLength = 50;
            this.txtClsDesc.Name = "txtClsDesc";
            this.txtClsDesc.PathString = "ClsDesc.Value";
            this.txtClsDesc.PathValue = "";
            this.txtClsDesc.Size = new System.Drawing.Size(250, 27);
            this.txtClsDesc.TabIndex = 100015;
            this.txtClsDesc.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 418);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 19);
            this.label1.TabIndex = 100016;
            this.label1.Text = "Class Info Code :";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 451);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 19);
            this.label2.TabIndex = 100017;
            this.label2.Text = "Class Code :";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 485);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 19);
            this.label3.TabIndex = 100018;
            this.label3.Text = "Class Description :";
            // 
            // evoLabel1
            // 
            this.evoLabel1.AppearanceName = "Title";
            this.evoLabel1.AutoSize = true;
            this.evoLabel1.ControlID = "";
            this.evoLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.evoLabel1.Font = new System.Drawing.Font("Tahoma", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.evoLabel1.Location = new System.Drawing.Point(0, 0);
            this.evoLabel1.Name = "evoLabel1";
            this.evoLabel1.PathString = null;
            this.evoLabel1.PathValue = "Class List";
            this.evoLabel1.Size = new System.Drawing.Size(165, 39);
            this.evoLabel1.TabIndex = 100019;
            this.evoLabel1.Text = "Class List";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(431, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(230, 19);
            this.label4.TabIndex = 100020;
            this.label4.Text = "เมนูด้านบน set ค่าจาก form load";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 515);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 19);
            this.label5.TabIndex = 100022;
            this.label5.Text = "Seq :";
            // 
            // txtSEQ
            // 
            this.txtSEQ.AllowNegative = false;
            this.txtSEQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSEQ.AppearanceName = "";
            this.txtSEQ.AppearanceReadOnlyName = "";
            this.txtSEQ.ControlID = "";
            this.txtSEQ.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSEQ.DecimalPoint = '.';
            this.txtSEQ.DigitsInGroup = 3;
            this.txtSEQ.Double = 0D;
            this.txtSEQ.FixDecimalPosition = false;
            this.txtSEQ.Flags = 65536;
            this.txtSEQ.GroupSeparator = ',';
            this.txtSEQ.Int = 0;
            this.txtSEQ.Location = new System.Drawing.Point(194, 515);
            this.txtSEQ.Long = ((long)(0));
            this.txtSEQ.MaxDecimalPlaces = 6;
            this.txtSEQ.MaxWholeDigits = 10;
            this.txtSEQ.Name = "txtSEQ";
            this.txtSEQ.NegativeSign = '\0';
            this.txtSEQ.PathString = "SEQ.Value";
            this.txtSEQ.PathValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSEQ.Prefix = "";
            this.txtSEQ.RangeMax = 1.7976931348623157E+308D;
            this.txtSEQ.RangeMin = 0D;
            this.txtSEQ.Size = new System.Drawing.Size(250, 27);
            this.txtSEQ.TabIndex = 100023;
            this.txtSEQ.Text = "0";
            this.txtSEQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // MAS090_ClassList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(802, 616);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 396);
            this.Name = "MAS090_ClassList";
            this.Text = "MAS090 Class List";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MAS090_ClassList_Load);
            this.Controls.SetChildIndex(this.pnlContainer, 0);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.cmsOperation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EVOFramework.Data.UIDataModelController dmc;
        private System.Windows.Forms.ContextMenuStrip cmsOperation;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private FarPoint.Win.Spread.FpSpread fpView;
        private FarPoint.Win.Spread.SheetView shtView;
        private EVOFramework.Windows.Forms.EVOTextBox txtClsInfoCd;
        private EVOFramework.Windows.Forms.EVOTextBox txtClsDesc;
        private EVOFramework.Windows.Forms.EVOTextBox txtClsCd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private EVOFramework.Windows.Forms.EVONumericTextBox txtSEQ;
    }
}
