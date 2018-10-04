namespace SystemMaintenance.Forms
{
    partial class CustomizeInquiryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomizeInquiryForm));
            this.tslControl = new System.Windows.Forms.ToolStrip();
            this.tsbExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSaveFormat = new System.Windows.Forms.ToolStripButton();
            this.tsbDefaultSize = new System.Windows.Forms.ToolStripButton();
            this.pnlContainer = new EVOFramework.Windows.Forms.EVOPanel();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.tsbAdvanceSearch = new System.Windows.Forms.ToolStripButton();
            this.tslControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tslControl
            // 
            this.tslControl.GripMargin = new System.Windows.Forms.Padding(0);
            this.tslControl.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tslControl.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tslControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbExport,
            this.toolStripSeparator1,
            this.tsbSaveFormat,
            this.tsbDefaultSize,
            this.tsbAdvanceSearch});
            this.tslControl.Location = new System.Drawing.Point(0, 0);
            this.tslControl.Name = "tslControl";
            this.tslControl.Padding = new System.Windows.Forms.Padding(0);
            this.tslControl.Size = new System.Drawing.Size(630, 36);
            this.tslControl.TabIndex = 9999;
            this.tslControl.TabStop = true;
            // 
            // tsbExport
            // 
            this.tsbExport.Image = ((System.Drawing.Image)(resources.GetObject("tsbExport.Image")));
            this.tsbExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExport.Margin = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.tsbExport.Name = "tsbExport";
            this.tsbExport.Padding = new System.Windows.Forms.Padding(2);
            this.tsbExport.Size = new System.Drawing.Size(71, 32);
            this.tsbExport.Text = "Export";
            this.tsbExport.Click += new System.EventHandler(this.tsbExport_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 36);
            // 
            // tsbSaveFormat
            // 
            this.tsbSaveFormat.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbSaveFormat.Image = global::SystemMaintenance.Properties.Resources.MENU_IMAGE_COLLAPSE_STATE;
            this.tsbSaveFormat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveFormat.Name = "tsbSaveFormat";
            this.tsbSaveFormat.Size = new System.Drawing.Size(96, 33);
            this.tsbSaveFormat.Text = "Save Format";
            this.tsbSaveFormat.Visible = false;
            this.tsbSaveFormat.Click += new System.EventHandler(this.tsbSaveFormat_Click);
            // 
            // tsbDefaultSize
            // 
            this.tsbDefaultSize.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbDefaultSize.Image = global::SystemMaintenance.Properties.Resources.ERROR;
            this.tsbDefaultSize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDefaultSize.Name = "tsbDefaultSize";
            this.tsbDefaultSize.Size = new System.Drawing.Size(92, 33);
            this.tsbDefaultSize.Text = "Default Size";
            this.tsbDefaultSize.Visible = false;
            this.tsbDefaultSize.Click += new System.EventHandler(this.tsbDefaultSize_Click);
            // 
            // pnlContainer
            // 
            this.pnlContainer.AppearanceName = "FormBGColor";
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 36);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(630, 289);
            this.pnlContainer.TabIndex = 0;
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 325);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(630, 22);
            this.statusBar.TabIndex = 0;
            // 
            // tsbAdvanceSearch
            // 
            this.tsbAdvanceSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbAdvanceSearch.Image = ((System.Drawing.Image)(resources.GetObject("tsbAdvanceSearch.Image")));
            this.tsbAdvanceSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdvanceSearch.Name = "tsbAdvanceSearch";
            this.tsbAdvanceSearch.Size = new System.Drawing.Size(113, 33);
            this.tsbAdvanceSearch.Text = "Advance Search";
            this.tsbAdvanceSearch.Visible = false;
            this.tsbAdvanceSearch.Click += new System.EventHandler(this.tsbAdvanceSearch_Click);
            // 
            // CustomizeInquiryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 347);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.tslControl);
            this.Name = "CustomizeInquiryForm";
            this.Text = "CustomizeInquiryForm";
            this.Shown += new System.EventHandler(this.CustomizeInquiryForm_Shown);
            this.tslControl.ResumeLayout(false);
            this.tslControl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip tslControl;
        public System.Windows.Forms.ToolStripButton tsbExport;
        public EVOFramework.Windows.Forms.EVOPanel pnlContainer;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.StatusStrip statusBar;
        protected System.Windows.Forms.ToolStripButton tsbDefaultSize;
        protected System.Windows.Forms.ToolStripButton tsbSaveFormat;
        protected System.Windows.Forms.ToolStripButton tsbAdvanceSearch;
    }
}