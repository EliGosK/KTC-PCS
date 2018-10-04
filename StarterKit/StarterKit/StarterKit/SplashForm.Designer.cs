namespace StarterKit
{
    partial class SplashForm
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
            this.lblLoad = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblLoadCaption = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.SuspendLayout();
            // 
            // lblLoad
            // 
            this.lblLoad.Location = new System.Drawing.Point(68, 226);
            this.lblLoad.Name = "lblLoad";
            this.lblLoad.Size = new System.Drawing.Size(212, 31);
            this.lblLoad.TabIndex = 2;
            this.lblLoad.Text = "...";
            // 
            // lblLoadCaption
            // 
            this.lblLoadCaption.AutoSize = true;
            this.lblLoadCaption.Location = new System.Drawing.Point(13, 226);
            this.lblLoadCaption.Name = "lblLoadCaption";
            this.lblLoadCaption.Size = new System.Drawing.Size(48, 13);
            this.lblLoadCaption.TabIndex = 1;
            this.lblLoadCaption.Text = "Loading:";
            // 
            // evoLabel1
            // 
            this.evoLabel1.AutoSize = true;
            this.evoLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel1.Location = new System.Drawing.Point(87, 23);
            this.evoLabel1.Name = "evoLabel1";
            this.evoLabel1.Size = new System.Drawing.Size(99, 24);
            this.evoLabel1.TabIndex = 0;
            this.evoLabel1.Text = "Starter Kit";
            // 
            // SplashForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.lblLoad);
            this.Controls.Add(this.lblLoadCaption);
            this.Controls.Add(this.evoLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EVOFramework.Windows.Forms.EVOLabel evoLabel1;
        private EVOFramework.Windows.Forms.EVOLabel lblLoadCaption;
        private EVOFramework.Windows.Forms.EVOLabel lblLoad;
    }
}