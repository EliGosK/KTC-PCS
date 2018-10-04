namespace Rubik.Inventory
{
    partial class INV040
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INV040));
            this.label8 = new EVOFramework.Windows.Forms.EVOLabel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new EVOFramework.Windows.Forms.EVOLabel();
            this.picWaiting = new EVOFramework.Windows.Forms.EVOPictureBox();
            this.txtInfo = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblInventoryMonth = new EVOFramework.Windows.Forms.EVOLabel();
            this.btnRollingUp = new EVOFramework.Windows.Forms.EVOButton();
            this.btnRollingDown = new EVOFramework.Windows.Forms.EVOButton();
            this.dtInventoryMonth = new EVOFramework.Windows.Forms.EVODateTextBox();
            this.pnlContainer = new EVOFramework.Windows.Forms.EVOPanel();
            this.tlpHeader2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWaiting)).BeginInit();
            this.pnlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AppearanceName = "";
            this.label8.AutoSize = true;
            this.label8.ControlID = "";
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label8.Name = "label8";
            this.label8.PathString = null;
            this.label8.PathValue = "Part Information";
            this.label8.Size = new System.Drawing.Size(142, 24);
            this.label8.TabIndex = 0;
            this.label8.Text = "Part Information";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.AutoSize = true;
            this.tableLayoutPanel7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel7.BackgroundImage")));
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(8, 8);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(527, 38);
            this.tableLayoutPanel7.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AppearanceName = "Header";
            this.label2.AutoSize = true;
            this.label2.ControlID = "";
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label2.Name = "label2";
            this.label2.PathString = null;
            this.label2.PathValue = "Inventory Period Closing Process";
            this.label2.Size = new System.Drawing.Size(287, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Inventory Period Closing Process";
            // 
            // picWaiting
            // 
            this.picWaiting.ControlID = "";
            this.picWaiting.Image = global::Rubik.Forms.Properties.Resources.bar_circle;
            this.picWaiting.Location = new System.Drawing.Point(250, 203);
            this.picWaiting.Name = "picWaiting";
            this.picWaiting.PathString = null;
            this.picWaiting.PathValue = global::Rubik.Forms.Properties.Resources.bar_circle;
            this.picWaiting.Size = new System.Drawing.Size(55, 50);
            this.picWaiting.TabIndex = 0;
            this.picWaiting.TabStop = false;
            // 
            // txtInfo
            // 
            this.txtInfo.AppearanceName = "";
            this.txtInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtInfo.ControlID = "";
            this.txtInfo.Location = new System.Drawing.Point(16, 91);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.PathString = null;
            this.txtInfo.PathValue = "The process will carry inventory on hand from current month to next month and cre" +
                "ate inventory for next month";
            this.txtInfo.Size = new System.Drawing.Size(519, 97);
            this.txtInfo.TabIndex = 0;
            this.txtInfo.Text = "The process will carry inventory on hand from current month to next month and cre" +
                "ate inventory for next month";
            // 
            // lblInventoryMonth
            // 
            this.lblInventoryMonth.AppearanceName = "";
            this.lblInventoryMonth.ControlID = "";
            this.lblInventoryMonth.Location = new System.Drawing.Point(12, 49);
            this.lblInventoryMonth.Name = "lblInventoryMonth";
            this.lblInventoryMonth.PathString = null;
            this.lblInventoryMonth.PathValue = "Inventory Month :";
            this.lblInventoryMonth.Size = new System.Drawing.Size(152, 26);
            this.lblInventoryMonth.TabIndex = 2;
            this.lblInventoryMonth.Text = "Inventory Month :";
            this.lblInventoryMonth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnRollingUp
            // 
            this.btnRollingUp.AppearanceName = "";
            this.btnRollingUp.ControlID = null;
            this.btnRollingUp.Image = ((System.Drawing.Image)(resources.GetObject("btnRollingUp.Image")));
            this.btnRollingUp.Location = new System.Drawing.Point(389, 210);
            this.btnRollingUp.Name = "btnRollingUp";
            this.btnRollingUp.Size = new System.Drawing.Size(148, 39);
            this.btnRollingUp.TabIndex = 4;
            this.btnRollingUp.Text = "Rolling Up";
            this.btnRollingUp.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnRollingUp.UseVisualStyleBackColor = true;
            this.btnRollingUp.Click += new System.EventHandler(this.btnRollingUp_Click);
            // 
            // btnRollingDown
            // 
            this.btnRollingDown.AppearanceName = "";
            this.btnRollingDown.ControlID = null;
            this.btnRollingDown.Image = ((System.Drawing.Image)(resources.GetObject("btnRollingDown.Image")));
            this.btnRollingDown.Location = new System.Drawing.Point(20, 210);
            this.btnRollingDown.Name = "btnRollingDown";
            this.btnRollingDown.Size = new System.Drawing.Size(148, 39);
            this.btnRollingDown.TabIndex = 5;
            this.btnRollingDown.Text = "Rolling Down";
            this.btnRollingDown.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRollingDown.UseVisualStyleBackColor = true;
            this.btnRollingDown.Click += new System.EventHandler(this.btnRollingDown_Click);
            // 
            // dtInventoryMonth
            // 
            this.dtInventoryMonth.AppearanceName = "";
            this.dtInventoryMonth.AppearanceReadOnlyName = "";
            this.dtInventoryMonth.ControlID = "";
            this.dtInventoryMonth.DateValue = null;
            this.dtInventoryMonth.Format = "dd/MM/yyyy";
            this.dtInventoryMonth.Location = new System.Drawing.Point(190, 49);
            this.dtInventoryMonth.Mask = "00/00/0000";
            this.dtInventoryMonth.MaxDateTime = new System.DateTime(9998, 12, 31, 23, 59, 59, 999);
            this.dtInventoryMonth.MinDateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtInventoryMonth.Name = "dtInventoryMonth";
            this.dtInventoryMonth.PathString = null;
            this.dtInventoryMonth.PathValue = "  /  /";
            this.dtInventoryMonth.Size = new System.Drawing.Size(152, 27);
            this.dtInventoryMonth.TabIndex = 8;
            this.dtInventoryMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlContainer
            // 
            this.pnlContainer.AppearanceName = "FormBGColor";
            this.pnlContainer.Controls.Add(this.picWaiting);
            this.pnlContainer.Controls.Add(this.tableLayoutPanel7);
            this.pnlContainer.Controls.Add(this.txtInfo);
            this.pnlContainer.Controls.Add(this.btnRollingUp);
            this.pnlContainer.Controls.Add(this.btnRollingDown);
            this.pnlContainer.Controls.Add(this.lblInventoryMonth);
            this.pnlContainer.Controls.Add(this.dtInventoryMonth);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Padding = new System.Windows.Forms.Padding(5);
            this.pnlContainer.Size = new System.Drawing.Size(549, 268);
            this.pnlContainer.TabIndex = 14;
            // 
            // tlpHeader2
            // 
            this.tlpHeader2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tlpHeader2.BackgroundImage")));
            this.tlpHeader2.ColumnCount = 1;
            this.tlpHeader2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpHeader2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHeader2.Location = new System.Drawing.Point(0, 0);
            this.tlpHeader2.Name = "tlpHeader2";
            this.tlpHeader2.RowCount = 1;
            this.tlpHeader2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpHeader2.Size = new System.Drawing.Size(200, 100);
            this.tlpHeader2.TabIndex = 0;
            // 
            // INV040
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(549, 268);
            this.Controls.Add(this.pnlContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "INV040";
            this.Text = "Inventory Period Closing Process";
            this.Load += new System.EventHandler(this.INV040_Load);
            this.Shown += new System.EventHandler(this.INV040_Shown);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWaiting)).EndInit();
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpHeader2;
        private EVOFramework.Windows.Forms.EVOLabel label8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private EVOFramework.Windows.Forms.EVOLabel label2;
        private EVOFramework.Windows.Forms.EVOLabel lblInventoryMonth;
        private EVOFramework.Windows.Forms.EVOButton btnRollingUp;
        private EVOFramework.Windows.Forms.EVOButton btnRollingDown;
        private EVOFramework.Windows.Forms.EVOPanel pnlContainer;
        private EVOFramework.Windows.Forms.EVOLabel txtInfo;
        private EVOFramework.Windows.Forms.EVODateTextBox dtInventoryMonth;
        private EVOFramework.Windows.Forms.EVOPictureBox picWaiting;
    }
}
