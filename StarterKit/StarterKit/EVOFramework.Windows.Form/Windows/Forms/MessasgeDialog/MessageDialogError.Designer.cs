namespace EVOFramework.Windows.Forms
{
    partial class MessageDialogError
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
            this.pnlDesc = new System.Windows.Forms.Panel();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lnkDetail = new System.Windows.Forms.LinkLabel();
            this.pnlDesc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDesc
            // 
            this.pnlDesc.Controls.Add(this.lnkDetail);
            this.pnlDesc.Controls.Add(this.picIcon);
            this.pnlDesc.Controls.Add(this.lblDescription);
            this.pnlDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDesc.Location = new System.Drawing.Point(1, 24);
            this.pnlDesc.Name = "pnlDesc";
            this.pnlDesc.Size = new System.Drawing.Size(178, 72);
            this.pnlDesc.TabIndex = 4;
            // 
            // picIcon
            // 
            this.picIcon.Location = new System.Drawing.Point(10, 5);
            this.picIcon.Margin = new System.Windows.Forms.Padding(0);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(32, 32);
            this.picIcon.TabIndex = 2;
            this.picIcon.TabStop = false;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(60, 10);
            this.lblDescription.MaximumSize = new System.Drawing.Size(700, 0);
            this.lblDescription.MinimumSize = new System.Drawing.Size(30, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(30, 13);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "A";
            // 
            // lnkDetail
            // 
            this.lnkDetail.AutoSize = true;
            this.lnkDetail.Location = new System.Drawing.Point(114, 56);
            this.lnkDetail.Name = "lnkDetail";
            this.lnkDetail.Size = new System.Drawing.Size(60, 13);
            this.lnkDetail.TabIndex = 3;
            this.lnkDetail.TabStop = true;
            this.lnkDetail.Text = "View Detail";
            // 
            // MessageDialogError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(180, 126);
            this.Controls.Add(this.pnlDesc);
            this.MessageDialogResult = EVOFramework.Windows.Forms.MessageDialogResult.OK;
            this.Name = "MessageDialogError";
            this.Text = "MessageDialogError";
            this.Controls.SetChildIndex(this.pnlDesc, 0);
            this.pnlDesc.ResumeLayout(false);
            this.pnlDesc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDesc;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.LinkLabel lnkDetail;
    }
}