namespace SystemMaintenance.Forms
{
    partial class CustomizeListPaneBaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomizeListPaneBaseForm));
            this.pnlContainer = new EVOFramework.Windows.Forms.EVOPanel();
            this.tsControl = new System.Windows.Forms.ToolStrip();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbShowAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.tsSeperator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsSeperator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExport = new System.Windows.Forms.ToolStripButton();
            this.tspSorting = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveFormat = new System.Windows.Forms.ToolStripButton();
            this.tsbDefaultSize = new System.Windows.Forms.ToolStripButton();
            this.tsbAdvanceSearch = new System.Windows.Forms.ToolStripButton();
            this.tsControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.AppearanceName = "FormBGColor";
            this.pnlContainer.BackColor = System.Drawing.Color.AliceBlue;
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 25);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(718, 241);
            this.pnlContainer.TabIndex = 4;
            // 
            // tsControl
            // 
            this.tsControl.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRefresh,
            this.tsbShowAll,
            this.toolStripSeparator1,
            this.tsbNew,
            this.tsbExit,
            this.tsSeperator2,
            this.tsSeperator1,
            this.tsbExport,
            this.tspSorting,
            this.tsbSaveFormat,
            this.tsbDefaultSize,
            this.tsbAdvanceSearch});
            this.tsControl.Location = new System.Drawing.Point(0, 0);
            this.tsControl.Name = "tsControl";
            this.tsControl.Size = new System.Drawing.Size(718, 25);
            this.tsControl.TabIndex = 1000;
            this.tsControl.TabStop = true;
            this.tsControl.Text = "tsControl";
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefresh.Image")));
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(65, 22);
            this.tsbRefresh.Text = "Refresh";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // tsbShowAll
            // 
            this.tsbShowAll.Image = ((System.Drawing.Image)(resources.GetObject("tsbShowAll.Image")));
            this.tsbShowAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShowAll.Name = "tsbShowAll";
            this.tsbShowAll.Size = new System.Drawing.Size(67, 22);
            this.tsbShowAll.Text = "Show All";
            this.tsbShowAll.Visible = false;
            this.tsbShowAll.Click += new System.EventHandler(this.tsbShowAll_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbNew
            // 
            this.tsbNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbNew.Image")));
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(70, 22);
            this.tsbNew.Text = "Add New";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // tsbExit
            // 
            this.tsbExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbExit.Image = ((System.Drawing.Image)(resources.GetObject("tsbExit.Image")));
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(53, 22);
            this.tsbExit.Text = "Close";
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // tsSeperator2
            // 
            this.tsSeperator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsSeperator2.Name = "tsSeperator2";
            this.tsSeperator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsSeperator1
            // 
            this.tsSeperator1.Name = "tsSeperator1";
            this.tsSeperator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbExport
            // 
            this.tsbExport.Image = ((System.Drawing.Image)(resources.GetObject("tsbExport.Image")));
            this.tsbExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExport.Name = "tsbExport";
            this.tsbExport.Size = new System.Drawing.Size(59, 22);
            this.tsbExport.Text = "Export";
            this.tsbExport.Click += new System.EventHandler(this.tsbExport_Click);
            // 
            // tspSorting
            // 
            this.tspSorting.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tspSorting.Image = global::SystemMaintenance.Properties.Resources.UP_BTN;
            this.tspSorting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspSorting.Name = "tspSorting";
            this.tspSorting.Size = new System.Drawing.Size(61, 22);
            this.tspSorting.Text = "Sorting";
            this.tspSorting.Click += new System.EventHandler(this.tspSorting_Click);
            // 
            // tsbSaveFormat
            // 
            this.tsbSaveFormat.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbSaveFormat.Image = global::SystemMaintenance.Properties.Resources.MENU_IMAGE_COLLAPSE_STATE;
            this.tsbSaveFormat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveFormat.Name = "tsbSaveFormat";
            this.tsbSaveFormat.Size = new System.Drawing.Size(88, 22);
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
            this.tsbDefaultSize.Size = new System.Drawing.Size(84, 22);
            this.tsbDefaultSize.Text = "Default Size";
            this.tsbDefaultSize.Visible = false;
            this.tsbDefaultSize.Click += new System.EventHandler(this.tsbDefaultSize_Click);
            // 
            // tsbAdvanceSearch
            // 
            this.tsbAdvanceSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbAdvanceSearch.Image = ((System.Drawing.Image)(resources.GetObject("tsbAdvanceSearch.Image")));
            this.tsbAdvanceSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdvanceSearch.Name = "tsbAdvanceSearch";
            this.tsbAdvanceSearch.Size = new System.Drawing.Size(105, 22);
            this.tsbAdvanceSearch.Text = "Advance Search";
            this.tsbAdvanceSearch.Visible = false;
            this.tsbAdvanceSearch.Click += new System.EventHandler(this.tsbAdvanceSearch_Click);
            // 
            // CustomizeListPaneBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(718, 266);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.tsControl);
            this.Name = "CustomizeListPaneBaseForm";
            this.Shown += new System.EventHandler(this.CustomizeListPaneBaseForm_Shown);
            this.tsControl.ResumeLayout(false);
            this.tsControl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public EVOFramework.Windows.Forms.EVOPanel pnlContainer;
        protected System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        protected System.Windows.Forms.ToolStripSeparator tsSeperator2;
        protected System.Windows.Forms.ToolStripSeparator tsSeperator1;
        protected System.Windows.Forms.ToolStrip tsControl;
        protected System.Windows.Forms.ToolStripButton tsbRefresh;
        protected System.Windows.Forms.ToolStripButton tsbShowAll;
        protected System.Windows.Forms.ToolStripButton tsbNew;
        protected System.Windows.Forms.ToolStripButton tsbExit;
        protected System.Windows.Forms.ToolStripButton tsbExport;
        protected System.Windows.Forms.ToolStripButton tspSorting;
        protected System.Windows.Forms.ToolStripButton tsbSaveFormat;
        protected System.Windows.Forms.ToolStripButton tsbDefaultSize;
        protected System.Windows.Forms.ToolStripButton tsbAdvanceSearch;
    }
}
