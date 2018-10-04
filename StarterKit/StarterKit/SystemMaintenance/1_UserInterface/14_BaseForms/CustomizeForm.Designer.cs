using EVOFramework.Windows.Forms;
namespace SystemMaintenance.Forms
{
    partial class CustomizeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomizeForm));
            this.tslControl = new System.Windows.Forms.ToolStrip();
            this.tsbSaveAndNew = new System.Windows.Forms.ToolStripButton();
            this.tlsSeperator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSaveAndClose = new System.Windows.Forms.ToolStripButton();
            this.tlsSeperator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSaveFormat = new System.Windows.Forms.ToolStripButton();
            this.tsbDefaultSize = new System.Windows.Forms.ToolStripButton();
            this.pnlContainer = new EVOFramework.Windows.Forms.EVOPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tslControl
            // 
            this.tslControl.GripMargin = new System.Windows.Forms.Padding(0);
            this.tslControl.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tslControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSaveAndNew,
            this.tlsSeperator1,
            this.tsbSaveAndClose,
            this.tlsSeperator2,
            this.tsbSaveFormat,
            this.tsbDefaultSize});
            this.tslControl.Location = new System.Drawing.Point(0, 0);
            this.tslControl.Name = "tslControl";
            this.tslControl.Padding = new System.Windows.Forms.Padding(0);
            this.tslControl.Size = new System.Drawing.Size(686, 28);
            this.tslControl.TabIndex = 99999;
            this.tslControl.TabStop = true;
            // 
            // tsbSaveAndNew
            // 
            this.tsbSaveAndNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbSaveAndNew.Image")));
            this.tsbSaveAndNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveAndNew.Margin = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.tsbSaveAndNew.Name = "tsbSaveAndNew";
            this.tsbSaveAndNew.Padding = new System.Windows.Forms.Padding(2);
            this.tsbSaveAndNew.Size = new System.Drawing.Size(100, 24);
            this.tsbSaveAndNew.Text = "Save and New";
            this.tsbSaveAndNew.ToolTipText = "Save and New (Ctrl + Enter)";
            this.tsbSaveAndNew.Click += new System.EventHandler(this.tsbSaveAndNew_Click);
            // 
            // tlsSeperator1
            // 
            this.tlsSeperator1.Name = "tlsSeperator1";
            this.tlsSeperator1.Size = new System.Drawing.Size(6, 28);
            // 
            // tsbSaveAndClose
            // 
            this.tsbSaveAndClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbSaveAndClose.Image")));
            this.tsbSaveAndClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveAndClose.Margin = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.tsbSaveAndClose.Name = "tsbSaveAndClose";
            this.tsbSaveAndClose.Padding = new System.Windows.Forms.Padding(2);
            this.tsbSaveAndClose.Size = new System.Drawing.Size(105, 24);
            this.tsbSaveAndClose.Text = "Save and Close";
            this.tsbSaveAndClose.ToolTipText = "Save and Close (Ctrl + Shift + Enter)";
            this.tsbSaveAndClose.Click += new System.EventHandler(this.tsbSaveAndClose_Click);
            // 
            // tlsSeperator2
            // 
            this.tlsSeperator2.Name = "tlsSeperator2";
            this.tlsSeperator2.Size = new System.Drawing.Size(6, 28);
            // 
            // tsbSaveFormat
            // 
            this.tsbSaveFormat.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbSaveFormat.Image = global::SystemMaintenance.Properties.Resources.MENU_IMAGE_COLLAPSE_STATE;
            this.tsbSaveFormat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveFormat.Name = "tsbSaveFormat";
            this.tsbSaveFormat.Size = new System.Drawing.Size(88, 25);
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
            this.tsbDefaultSize.Size = new System.Drawing.Size(84, 25);
            this.tsbDefaultSize.Text = "Default Size";
            this.tsbDefaultSize.Visible = false;
            this.tsbDefaultSize.Click += new System.EventHandler(this.tsbDefaultSize_Click);
            // 
            // pnlContainer
            // 
            this.pnlContainer.AppearanceName = "FormBGColor";
            this.pnlContainer.AutoScroll = true;
            this.pnlContainer.BackColor = System.Drawing.Color.AliceBlue;
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 28);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(686, 439);
            this.pnlContainer.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 467);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(686, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // CustomizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightYellow;
            this.ClientSize = new System.Drawing.Size(686, 489);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tslControl);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(400, 210);
            this.Name = "CustomizeForm";
            this.Text = "CustomizeForm";
            this.Load += new System.EventHandler(this.CustomizeForm_Load);
            this.Shown += new System.EventHandler(this.CustomizeForm_Shown);
            this.tslControl.ResumeLayout(false);
            this.tslControl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public EVOPanel pnlContainer;
        public System.Windows.Forms.ToolStrip tslControl;
        public System.Windows.Forms.ToolStripButton tsbSaveAndNew;
        public System.Windows.Forms.ToolStripButton tsbSaveAndClose;
        private System.Windows.Forms.StatusStrip statusStrip1;
        protected System.Windows.Forms.ToolStripSeparator tlsSeperator1;
        protected System.Windows.Forms.ToolStripSeparator tlsSeperator2;
        protected System.Windows.Forms.ToolStripButton tsbDefaultSize;
        protected System.Windows.Forms.ToolStripButton tsbSaveFormat;
    }
}