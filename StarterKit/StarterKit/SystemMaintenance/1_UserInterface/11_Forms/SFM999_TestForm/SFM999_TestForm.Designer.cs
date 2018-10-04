namespace SystemMaintenance.Forms
{
    partial class SFM999_TestForm
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
            this.evoTextBox1 = new EVOFramework.Windows.Forms.EVOTextBox();
            this.evoButton1 = new EVOFramework.Windows.Forms.EVOButton();
            this.pnlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.evoButton1);
            this.pnlContainer.Controls.Add(this.evoTextBox1);
            this.pnlContainer.Size = new System.Drawing.Size(540, 346);
            // 
            // evoTextBox1
            // 
            this.evoTextBox1.ControlID = "";
            this.evoTextBox1.Location = new System.Drawing.Point(12, 12);
            this.evoTextBox1.Multiline = true;
            this.evoTextBox1.Name = "evoTextBox1";
            this.evoTextBox1.PathString = null;
            this.evoTextBox1.PathValue = "";
            this.evoTextBox1.Size = new System.Drawing.Size(272, 322);
            this.evoTextBox1.TabIndex = 0;
            // 
            // evoButton1
            // 
            this.evoButton1.ControlID = null;
            this.evoButton1.Location = new System.Drawing.Point(290, 12);
            this.evoButton1.Name = "evoButton1";
            this.evoButton1.Size = new System.Drawing.Size(75, 23);
            this.evoButton1.TabIndex = 1;
            this.evoButton1.Text = "evoButton1";
            this.evoButton1.UseVisualStyleBackColor = true;
            this.evoButton1.Click += new System.EventHandler(this.evoButton1_Click);
            // 
            // SFM999_TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 382);
            this.Name = "SFM999_TestForm";
            this.Text = "SFM999_TestForm";
            this.Load += new System.EventHandler(this.SFM999_TestForm_Load);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EVOFramework.Windows.Forms.EVOButton evoButton1;
        private EVOFramework.Windows.Forms.EVOTextBox evoTextBox1;


    }
}