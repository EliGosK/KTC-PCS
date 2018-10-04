namespace SystemMaintenance
{
    partial class ErrorDialog
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pnlContainer = new EVOFramework.Windows.Forms.EVOPanel();
            this.pnlStackTrace = new EVOFramework.Windows.Forms.EVOPanel();
            this.txtStackTrace = new EVOFramework.Windows.Forms.EVOTextBox();
            this.pnlButton = new EVOFramework.Windows.Forms.EVOPanel();
            this.btnDetail = new EVOFramework.Windows.Forms.EVOButton();
            this.btnClose = new EVOFramework.Windows.Forms.EVOButton();
            this.tblMessage = new System.Windows.Forms.TableLayoutPanel();
            this.picIcon = new EVOFramework.Windows.Forms.EVOPictureBox();
            this.lblMessage = new EVOFramework.Windows.Forms.EVOLabel();
            this.pnlContainer.SuspendLayout();
            this.pnlStackTrace.SuspendLayout();
            this.pnlButton.SuspendLayout();
            this.tblMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 93);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(401, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Visible = false;
            // 
            // pnlContainer
            // 
            this.pnlContainer.AppearanceName = "";
            this.pnlContainer.Controls.Add(this.pnlStackTrace);
            this.pnlContainer.Controls.Add(this.pnlButton);
            this.pnlContainer.Controls.Add(this.tblMessage);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Padding = new System.Windows.Forms.Padding(3);
            this.pnlContainer.Size = new System.Drawing.Size(401, 94);
            this.pnlContainer.TabIndex = 1;
            // 
            // pnlStackTrace
            // 
            this.pnlStackTrace.AppearanceName = "";
            this.pnlStackTrace.Controls.Add(this.txtStackTrace);
            this.pnlStackTrace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStackTrace.Location = new System.Drawing.Point(3, 92);
            this.pnlStackTrace.Name = "pnlStackTrace";
            this.pnlStackTrace.Size = new System.Drawing.Size(395, 0);
            this.pnlStackTrace.TabIndex = 4;
            // 
            // txtStackTrace
            // 
            this.txtStackTrace.AppearanceName = "";
            this.txtStackTrace.AppearanceReadOnlyName = "";
            this.txtStackTrace.ControlID = "";
            this.txtStackTrace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStackTrace.Location = new System.Drawing.Point(0, 0);
            this.txtStackTrace.Multiline = true;
            this.txtStackTrace.Name = "txtStackTrace";
            this.txtStackTrace.PathString = null;
            this.txtStackTrace.PathValue = "";
            this.txtStackTrace.ReadOnly = true;
            this.txtStackTrace.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtStackTrace.Size = new System.Drawing.Size(395, 0);
            this.txtStackTrace.TabIndex = 0;
            this.txtStackTrace.Visible = false;
            this.txtStackTrace.WordWrap = false;
            // 
            // pnlButton
            // 
            this.pnlButton.AppearanceName = "";
            this.pnlButton.AutoSize = true;
            this.pnlButton.Controls.Add(this.btnDetail);
            this.pnlButton.Controls.Add(this.btnClose);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButton.Location = new System.Drawing.Point(3, 58);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(395, 34);
            this.pnlButton.TabIndex = 3;
            // 
            // btnDetail
            // 
            this.btnDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetail.AppearanceName = "";
            this.btnDetail.ControlID = null;
            this.btnDetail.Location = new System.Drawing.Point(317, 3);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(75, 28);
            this.btnDetail.TabIndex = 2;
            this.btnDetail.Text = "Detail >>";
            this.btnDetail.UseVisualStyleBackColor = true;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AppearanceName = "";
            this.btnClose.ControlID = null;
            this.btnClose.Location = new System.Drawing.Point(236, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 28);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tblMessage
            // 
            this.tblMessage.ColumnCount = 2;
            this.tblMessage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tblMessage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMessage.Controls.Add(this.picIcon, 0, 0);
            this.tblMessage.Controls.Add(this.lblMessage, 1, 0);
            this.tblMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblMessage.Location = new System.Drawing.Point(3, 3);
            this.tblMessage.MinimumSize = new System.Drawing.Size(0, 55);
            this.tblMessage.Name = "tblMessage";
            this.tblMessage.RowCount = 1;
            this.tblMessage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMessage.Size = new System.Drawing.Size(395, 55);
            this.tblMessage.TabIndex = 1;
            // 
            // picIcon
            // 
            this.picIcon.ControlID = "";
            this.picIcon.Image = global::SystemMaintenance.Properties.Resources.ERROR;
            this.picIcon.Location = new System.Drawing.Point(3, 3);
            this.picIcon.Name = "picIcon";
            this.picIcon.PathString = null;
            this.picIcon.PathValue = global::SystemMaintenance.Properties.Resources.ERROR;
            this.picIcon.Size = new System.Drawing.Size(48, 48);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picIcon.TabIndex = 0;
            this.picIcon.TabStop = false;
            // 
            // lblMessage
            // 
            this.lblMessage.AppearanceName = "";
            this.lblMessage.AutoSize = true;
            this.lblMessage.ControlID = "";
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMessage.Location = new System.Drawing.Point(58, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.lblMessage.PathString = null;
            this.lblMessage.PathValue = "Connection failed.";
            this.lblMessage.Size = new System.Drawing.Size(334, 28);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "Connection failed.";
            // 
            // ErrorDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(401, 94);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.statusStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(409, 128);
            this.Name = "ErrorDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Error Dialog";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ErrorDialog_Load);
            this.Shown += new System.EventHandler(this.ErrorDialog_Shown);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.pnlStackTrace.ResumeLayout(false);
            this.pnlStackTrace.PerformLayout();
            this.pnlButton.ResumeLayout(false);
            this.tblMessage.ResumeLayout(false);
            this.tblMessage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private EVOFramework.Windows.Forms.EVOPanel pnlContainer;
        private EVOFramework.Windows.Forms.EVOPictureBox picIcon;
        private System.Windows.Forms.TableLayoutPanel tblMessage;
        private EVOFramework.Windows.Forms.EVOButton btnDetail;
        private EVOFramework.Windows.Forms.EVOButton btnClose;
        private EVOFramework.Windows.Forms.EVOLabel lblMessage;
        private EVOFramework.Windows.Forms.EVOPanel pnlButton;
        private EVOFramework.Windows.Forms.EVOPanel pnlStackTrace;
        private EVOFramework.Windows.Forms.EVOTextBox txtStackTrace;
    }
}