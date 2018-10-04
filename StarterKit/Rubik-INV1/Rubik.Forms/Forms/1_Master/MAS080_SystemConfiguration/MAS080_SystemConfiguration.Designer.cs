
namespace Rubik.Master
{
    partial class MAS080_SystemConfiguration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAS080_SystemConfiguration));
            this.cmsOperation = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dmc = new EVOFramework.Data.UIDataModelController(this.components);
            this.fpView = new FarPoint.Win.Spread.FpSpread();
            this.shtView = new FarPoint.Win.Spread.SheetView();
            this.txtSysGroupId = new EVOFramework.Windows.Forms.EVOTextBox();
            this.txtSysKey = new EVOFramework.Windows.Forms.EVOTextBox();
            this.txtChrData = new EVOFramework.Windows.Forms.EVOTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.evoLabel1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.label4 = new System.Windows.Forms.Label();
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
            this.pnlContainer.Controls.Add(this.label4);
            this.pnlContainer.Controls.Add(this.label2);
            this.pnlContainer.Controls.Add(this.label3);
            this.pnlContainer.Controls.Add(this.label1);
            this.pnlContainer.Controls.Add(this.evoLabel1);
            this.pnlContainer.Controls.Add(this.txtChrData);
            this.pnlContainer.Controls.Add(this.txtSysKey);
            this.pnlContainer.Controls.Add(this.txtSysGroupId);
            this.pnlContainer.Controls.Add(this.fpView);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.None;
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlContainer.Location = new System.Drawing.Point(0, 25);
            this.pnlContainer.Size = new System.Drawing.Size(719, 566);
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
            this.fpView.Size = new System.Drawing.Size(695, 389);
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
            this.shtView.ColumnCount = 4;
            this.shtView.RowCount = 0;
            this.shtView.AutoCalculation = false;
            this.shtView.AutoGenerateColumns = false;
            this.shtView.ColumnHeader.Cells.Get(0, 0).Value = "Group ID";
            this.shtView.ColumnHeader.Cells.Get(0, 1).Value = "Key";
            this.shtView.ColumnHeader.Cells.Get(0, 2).Value = "Value";
            this.shtView.ColumnHeader.Cells.Get(0, 3).Value = "Edit";
            this.shtView.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtView.Columns.Get(0).Label = "Group ID";
            this.shtView.Columns.Get(0).Locked = true;
            this.shtView.Columns.Get(0).Tag = "SYS_GROUP_ID";
            this.shtView.Columns.Get(0).Width = 200F;
            this.shtView.Columns.Get(1).Label = "Key";
            this.shtView.Columns.Get(1).Locked = true;
            this.shtView.Columns.Get(1).Tag = "SYS_KEY";
            this.shtView.Columns.Get(1).Width = 200F;
            this.shtView.Columns.Get(2).Label = "Value";
            this.shtView.Columns.Get(2).Locked = false;
            this.shtView.Columns.Get(2).Tag = "CHAR_DATA";
            this.shtView.Columns.Get(2).Width = 122F;
            this.shtView.Columns.Get(3).CellType = checkBoxCellType1;
            this.shtView.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.shtView.Columns.Get(3).Label = "Edit";
            this.shtView.Columns.Get(3).Locked = true;
            this.shtView.Columns.Get(3).Tag = "Edit";
            this.shtView.Columns.Get(3).Width = 101F;
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
            // txtSysGroupId
            // 
            this.txtSysGroupId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSysGroupId.AppearanceName = "";
            this.txtSysGroupId.AppearanceReadOnlyName = "";
            this.txtSysGroupId.ControlID = "";
            this.txtSysGroupId.DisableRestrictChar = false;
            this.txtSysGroupId.Enabled = false;
            this.txtSysGroupId.HelpButton = null;
            this.txtSysGroupId.Location = new System.Drawing.Point(198, 449);
            this.txtSysGroupId.MaxLength = 50;
            this.txtSysGroupId.Name = "txtSysGroupId";
            this.txtSysGroupId.PathString = "SysGroupId.Value";
            this.txtSysGroupId.PathValue = "";
            this.txtSysGroupId.Size = new System.Drawing.Size(250, 27);
            this.txtSysGroupId.TabIndex = 6;
            this.txtSysGroupId.TabStop = false;
            // 
            // txtSysKey
            // 
            this.txtSysKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSysKey.AppearanceName = "";
            this.txtSysKey.AppearanceReadOnlyName = "";
            this.txtSysKey.ControlID = "";
            this.txtSysKey.DisableRestrictChar = false;
            this.txtSysKey.Enabled = false;
            this.txtSysKey.HelpButton = null;
            this.txtSysKey.Location = new System.Drawing.Point(198, 482);
            this.txtSysKey.MaxLength = 50;
            this.txtSysKey.Name = "txtSysKey";
            this.txtSysKey.PathString = "SysKey.Value";
            this.txtSysKey.PathValue = "";
            this.txtSysKey.Size = new System.Drawing.Size(250, 27);
            this.txtSysKey.TabIndex = 100013;
            this.txtSysKey.TabStop = false;
            // 
            // txtChrData
            // 
            this.txtChrData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtChrData.AppearanceName = "";
            this.txtChrData.AppearanceReadOnlyName = "";
            this.txtChrData.BackColor = System.Drawing.SystemColors.Window;
            this.txtChrData.ControlID = "";
            this.txtChrData.DisableRestrictChar = false;
            this.txtChrData.HelpButton = null;
            this.txtChrData.Location = new System.Drawing.Point(198, 516);
            this.txtChrData.MaxLength = 50;
            this.txtChrData.Name = "txtChrData";
            this.txtChrData.PathString = "ChrData.Value";
            this.txtChrData.PathValue = "";
            this.txtChrData.Size = new System.Drawing.Size(250, 27);
            this.txtChrData.TabIndex = 100015;
            this.txtChrData.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 452);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 19);
            this.label1.TabIndex = 100016;
            this.label1.Text = "Group ID :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 485);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 19);
            this.label2.TabIndex = 100017;
            this.label2.Text = "Key :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 519);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 19);
            this.label3.TabIndex = 100018;
            this.label3.Text = "Value :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.evoLabel1.PathValue = "System Configuration";
            this.evoLabel1.Size = new System.Drawing.Size(362, 39);
            this.evoLabel1.TabIndex = 100019;
            this.evoLabel1.Text = "System Configuration";
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
            // MAS080_SystemConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(719, 616);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 396);
            this.Name = "MAS080_SystemConfiguration";
            this.Text = "MAS080 System Configuration";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MAS080_SystemConfiguration_Load);
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
        private EVOFramework.Windows.Forms.EVOTextBox txtSysGroupId;
        private EVOFramework.Windows.Forms.EVOTextBox txtChrData;
        private EVOFramework.Windows.Forms.EVOTextBox txtSysKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel1;
        private System.Windows.Forms.Label label4;
    }
}
