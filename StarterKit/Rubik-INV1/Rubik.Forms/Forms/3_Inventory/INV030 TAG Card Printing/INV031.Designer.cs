namespace Rubik.Inventory
{
    partial class INV031
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INV031));
            this.rptViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // rptViewer
            // 
            this.rptViewer.ActiveViewIndex = -1;
            this.rptViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rptViewer.DisplayGroupTree = false;
            this.rptViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptViewer.Location = new System.Drawing.Point(0, 0);
            this.rptViewer.Name = "rptViewer";
            this.rptViewer.SelectionFormula = "";
            this.rptViewer.ShowCloseButton = false;
            this.rptViewer.ShowGroupTreeButton = false;
            this.rptViewer.ShowRefreshButton = false;
            this.rptViewer.Size = new System.Drawing.Size(907, 510);
            this.rptViewer.TabIndex = 1;
            this.rptViewer.ViewTimeSelectionFormula = "";
            // 
            // INV031
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(907, 510);
            this.Controls.Add(this.rptViewer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "INV031";
            this.Text = "Print Preview";
            this.Load += new System.EventHandler(this.INV031_Load);
            this.ResumeLayout(false);

        }

        #endregion

        protected CrystalDecisions.Windows.Forms.CrystalReportViewer rptViewer;
    }
}
