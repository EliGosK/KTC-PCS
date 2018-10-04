namespace Rubik.Inventory
{
    partial class INV090_ProductionSummaryByMachine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INV090_ProductionSummaryByMachine));
            this.lblHeader = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblInventoryPeriod = new EVOFramework.Windows.Forms.EVOLabel();
            this.dtDateEnd = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.dtDateBegin = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.pivotMPA = new AxMicrosoft.Office.Interop.Owc11.AxPivotTable();
            this.lblInformation = new EVOFramework.Windows.Forms.EVOLabel();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pivotMPA)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.BackColor = System.Drawing.Color.AliceBlue;
            this.pnlContainer.Controls.Add(this.lblInformation);
            this.pnlContainer.Controls.Add(this.evoLabel1);
            this.pnlContainer.Controls.Add(this.lblInventoryPeriod);
            this.pnlContainer.Controls.Add(this.dtDateEnd);
            this.pnlContainer.Controls.Add(this.dtDateBegin);
            this.pnlContainer.Controls.Add(this.pivotMPA);
            this.pnlContainer.Controls.Add(this.lblHeader);
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlContainer.Size = new System.Drawing.Size(967, 519);
            // 
            // lblHeader
            // 
            this.lblHeader.AppearanceName = "Title";
            this.lblHeader.ControlID = "";
            this.lblHeader.Font = new System.Drawing.Font("Tahoma", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblHeader.Location = new System.Drawing.Point(3, 2);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.PathString = null;
            this.lblHeader.PathValue = "Production Summary By Machine";
            this.lblHeader.Size = new System.Drawing.Size(472, 38);
            this.lblHeader.TabIndex = 35;
            this.lblHeader.Text = "Production Summary By Machine";
            // 
            // evoLabel1
            // 
            this.evoLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.evoLabel1.AppearanceName = "";
            this.evoLabel1.ControlID = "";
            this.evoLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel1.Location = new System.Drawing.Point(782, 9);
            this.evoLabel1.Name = "evoLabel1";
            this.evoLabel1.PathString = null;
            this.evoLabel1.PathValue = "to";
            this.evoLabel1.Size = new System.Drawing.Size(34, 23);
            this.evoLabel1.TabIndex = 41;
            this.evoLabel1.Text = "to";
            this.evoLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblInventoryPeriod
            // 
            this.lblInventoryPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInventoryPeriod.AppearanceName = "";
            this.lblInventoryPeriod.ControlID = "";
            this.lblInventoryPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblInventoryPeriod.Location = new System.Drawing.Point(579, 9);
            this.lblInventoryPeriod.Name = "lblInventoryPeriod";
            this.lblInventoryPeriod.PathString = null;
            this.lblInventoryPeriod.PathValue = "Date";
            this.lblInventoryPeriod.Size = new System.Drawing.Size(56, 23);
            this.lblInventoryPeriod.TabIndex = 40;
            this.lblInventoryPeriod.Text = "Date";
            this.lblInventoryPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtDateEnd
            // 
            this.dtDateEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDateEnd.AppearanceName = "";
            this.dtDateEnd.AppearanceReadOnlyName = "";
            this.dtDateEnd.BackColor = System.Drawing.Color.Transparent;
            this.dtDateEnd.ControlID = "";
            this.dtDateEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtDateEnd.Format = "dd/MM/yyyy";
            this.dtDateEnd.Location = new System.Drawing.Point(822, 7);
            this.dtDateEnd.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtDateEnd.Name = "dtDateEnd";
            this.dtDateEnd.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtDateEnd.NZValue")));
            this.dtDateEnd.PathString = null;
            this.dtDateEnd.PathValue = ((object)(resources.GetObject("dtDateEnd.PathValue")));
            this.dtDateEnd.ReadOnly = false;
            this.dtDateEnd.ShowButton = true;
            this.dtDateEnd.Size = new System.Drawing.Size(139, 26);
            this.dtDateEnd.TabIndex = 43;
            this.dtDateEnd.Value = null;
            // 
            // dtDateBegin
            // 
            this.dtDateBegin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDateBegin.AppearanceName = "";
            this.dtDateBegin.AppearanceReadOnlyName = "";
            this.dtDateBegin.BackColor = System.Drawing.Color.Transparent;
            this.dtDateBegin.ControlID = "";
            this.dtDateBegin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtDateBegin.Format = "dd/MM/yyyy";
            this.dtDateBegin.Location = new System.Drawing.Point(641, 7);
            this.dtDateBegin.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtDateBegin.Name = "dtDateBegin";
            this.dtDateBegin.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtDateBegin.NZValue")));
            this.dtDateBegin.PathString = null;
            this.dtDateBegin.PathValue = ((object)(resources.GetObject("dtDateBegin.PathValue")));
            this.dtDateBegin.ReadOnly = false;
            this.dtDateBegin.ShowButton = true;
            this.dtDateBegin.Size = new System.Drawing.Size(139, 26);
            this.dtDateBegin.TabIndex = 42;
            this.dtDateBegin.Value = null;
            // 
            // pivotMPA
            // 
            this.pivotMPA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pivotMPA.DataSource = null;
            this.pivotMPA.Enabled = true;
            this.pivotMPA.Location = new System.Drawing.Point(3, 43);
            this.pivotMPA.MaximumSize = new System.Drawing.Size(1500, 700);
            this.pivotMPA.Name = "pivotMPA";
            this.pivotMPA.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pivotMPA.OcxState")));
            this.pivotMPA.Size = new System.Drawing.Size(961, 446);
            this.pivotMPA.TabIndex = 37;
            this.pivotMPA.TabStop = false;
            // 
            // lblInformation
            // 
            this.lblInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInformation.AppearanceName = "RequireText";
            this.lblInformation.AutoSize = true;
            this.lblInformation.ControlID = "";
            this.lblInformation.Location = new System.Drawing.Point(7, 494);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.PathString = null;
            this.lblInformation.PathValue = "** Not included rework data";
            this.lblInformation.Size = new System.Drawing.Size(210, 19);
            this.lblInformation.TabIndex = 44;
            this.lblInformation.Text = "** Not included rework data";
            // 
            // INV090_ProductionSummaryByMachine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(967, 577);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "INV090_ProductionSummaryByMachine";
            this.Text = "Production Summary By Machine";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.INV090_ProductionSummary_Load);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pivotMPA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EVOFramework.Windows.Forms.EVOLabel lblHeader;
        private AxMicrosoft.Office.Interop.Owc11.AxPivotTable pivotMPA;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel1;
        private EVOFramework.Windows.Forms.EVOLabel lblInventoryPeriod;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtDateEnd;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtDateBegin;
        private EVOFramework.Windows.Forms.EVOLabel lblInformation;

    }
}
