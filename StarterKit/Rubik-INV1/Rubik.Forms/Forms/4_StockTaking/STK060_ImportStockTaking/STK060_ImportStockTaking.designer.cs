namespace Rubik.StockTaking
{
    partial class STK060_ImportStockTaking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(STK060_ImportStockTaking));
            this.label8 = new EVOFramework.Windows.Forms.EVOLabel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.lblHeaderSTK020 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoGroupBox1 = new EVOFramework.Windows.Forms.EVOGroupBox();
            this.txtFileName = new EVOFramework.Windows.Forms.EVOTextBox();
            this.btnBrowse = new EVOFramework.Windows.Forms.EVOButton();
            this.lblFileName = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoPanel4 = new EVOFramework.Windows.Forms.EVOPanel();
            this.btnGetTemplate = new EVOFramework.Windows.Forms.EVOButton();
            this.btnClearAll = new EVOFramework.Windows.Forms.EVOButton();
            this.btnImport = new EVOFramework.Windows.Forms.EVOButton();
            this.pnlContainer = new EVOFramework.Windows.Forms.EVOPanel();
            this.evoGroupBox2 = new EVOFramework.Windows.Forms.EVOGroupBox();
            this.evoLabel5 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel3 = new EVOFramework.Windows.Forms.EVOLabel();
            this.dtpLastSTKDate = new EVOFramework.Windows.Forms.EVODateTextBox();
            this.evoLabel1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtLastPreProcessBy = new EVOFramework.Windows.Forms.EVOTextBox();
            this.txtLastRemark = new EVOFramework.Windows.Forms.EVOTextBox();
            this.tlpHeader2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7.SuspendLayout();
            this.evoGroupBox1.SuspendLayout();
            this.evoPanel4.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.evoGroupBox2.SuspendLayout();
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
            this.tableLayoutPanel7.Controls.Add(this.lblHeaderSTK020, 0, 0);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(8, 8);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(376, 27);
            this.tableLayoutPanel7.TabIndex = 12;
            // 
            // lblHeaderSTK020
            // 
            this.lblHeaderSTK020.AppearanceName = "Header";
            this.lblHeaderSTK020.AutoSize = true;
            this.lblHeaderSTK020.ControlID = "";
            this.lblHeaderSTK020.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblHeaderSTK020.ForeColor = System.Drawing.Color.Navy;
            this.lblHeaderSTK020.Location = new System.Drawing.Point(0, 0);
            this.lblHeaderSTK020.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblHeaderSTK020.Name = "lblHeaderSTK020";
            this.lblHeaderSTK020.PathString = null;
            this.lblHeaderSTK020.PathValue = "Import Stock Taking";
            this.lblHeaderSTK020.Size = new System.Drawing.Size(175, 24);
            this.lblHeaderSTK020.TabIndex = 0;
            this.lblHeaderSTK020.Text = "Import Stock Taking";
            // 
            // evoGroupBox1
            // 
            this.evoGroupBox1.AppearanceName = "";
            this.evoGroupBox1.Controls.Add(this.txtFileName);
            this.evoGroupBox1.Controls.Add(this.btnBrowse);
            this.evoGroupBox1.Controls.Add(this.lblFileName);
            this.evoGroupBox1.Location = new System.Drawing.Point(8, 41);
            this.evoGroupBox1.Name = "evoGroupBox1";
            this.evoGroupBox1.Size = new System.Drawing.Size(519, 56);
            this.evoGroupBox1.TabIndex = 1;
            this.evoGroupBox1.TabStop = false;
            // 
            // txtFileName
            // 
            this.txtFileName.AppearanceName = "";
            this.txtFileName.AppearanceReadOnlyName = "";
            this.txtFileName.ControlID = "";
            this.txtFileName.DisableRestrictChar = false;
            this.txtFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtFileName.HelpButton = null;
            this.txtFileName.Location = new System.Drawing.Point(95, 20);
            this.txtFileName.MaxLength = 20;
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.PathString = "";
            this.txtFileName.PathValue = "";
            this.txtFileName.Size = new System.Drawing.Size(281, 26);
            this.txtFileName.TabIndex = 0;
            // 
            // btnBrowse
            // 
            this.btnBrowse.AppearanceName = "";
            this.btnBrowse.ControlID = null;
            this.btnBrowse.Location = new System.Drawing.Point(382, 17);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(131, 30);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.AppearanceName = "";
            this.lblFileName.AutoSize = true;
            this.lblFileName.ControlID = "";
            this.lblFileName.Location = new System.Drawing.Point(10, 23);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.PathString = null;
            this.lblFileName.PathValue = "File Name";
            this.lblFileName.Size = new System.Drawing.Size(79, 19);
            this.lblFileName.TabIndex = 0;
            this.lblFileName.Text = "File Name";
            // 
            // evoPanel4
            // 
            this.evoPanel4.AppearanceName = "";
            this.evoPanel4.AutoSize = true;
            this.evoPanel4.Controls.Add(this.btnClearAll);
            this.evoPanel4.Controls.Add(this.btnImport);
            this.evoPanel4.Location = new System.Drawing.Point(8, 250);
            this.evoPanel4.Name = "evoPanel4";
            this.evoPanel4.Size = new System.Drawing.Size(519, 36);
            this.evoPanel4.TabIndex = 7;
            // 
            // btnGetTemplate
            // 
            this.btnGetTemplate.AppearanceName = "";
            this.btnGetTemplate.ControlID = null;
            this.btnGetTemplate.Location = new System.Drawing.Point(388, 12);
            this.btnGetTemplate.Name = "btnGetTemplate";
            this.btnGetTemplate.Size = new System.Drawing.Size(133, 30);
            this.btnGetTemplate.TabIndex = 2;
            this.btnGetTemplate.Text = "Save Template";
            this.btnGetTemplate.UseVisualStyleBackColor = true;
            this.btnGetTemplate.Click += new System.EventHandler(this.btnGetTemplate_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.AppearanceName = "";
            this.btnClearAll.ControlID = null;
            this.btnClearAll.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnClearAll.ForeColor = System.Drawing.Color.Red;
            this.btnClearAll.Location = new System.Drawing.Point(12, 2);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(212, 30);
            this.btnClearAll.TabIndex = 1;
            this.btnClearAll.Text = "Clear All Imported Data";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // btnImport
            // 
            this.btnImport.AppearanceName = "";
            this.btnImport.ControlID = null;
            this.btnImport.Location = new System.Drawing.Point(382, 2);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(131, 30);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // pnlContainer
            // 
            this.pnlContainer.AppearanceName = "FormBGColor";
            this.pnlContainer.BackColor = System.Drawing.Color.AliceBlue;
            this.pnlContainer.Controls.Add(this.btnGetTemplate);
            this.pnlContainer.Controls.Add(this.evoGroupBox2);
            this.pnlContainer.Controls.Add(this.evoGroupBox1);
            this.pnlContainer.Controls.Add(this.tableLayoutPanel7);
            this.pnlContainer.Controls.Add(this.evoPanel4);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Padding = new System.Windows.Forms.Padding(5);
            this.pnlContainer.Size = new System.Drawing.Size(535, 296);
            this.pnlContainer.TabIndex = 14;
            // 
            // evoGroupBox2
            // 
            this.evoGroupBox2.AppearanceName = "";
            this.evoGroupBox2.Controls.Add(this.evoLabel5);
            this.evoGroupBox2.Controls.Add(this.evoLabel3);
            this.evoGroupBox2.Controls.Add(this.dtpLastSTKDate);
            this.evoGroupBox2.Controls.Add(this.evoLabel1);
            this.evoGroupBox2.Controls.Add(this.txtLastPreProcessBy);
            this.evoGroupBox2.Controls.Add(this.txtLastRemark);
            this.evoGroupBox2.Location = new System.Drawing.Point(8, 102);
            this.evoGroupBox2.Name = "evoGroupBox2";
            this.evoGroupBox2.Size = new System.Drawing.Size(519, 135);
            this.evoGroupBox2.TabIndex = 13;
            this.evoGroupBox2.TabStop = false;
            this.evoGroupBox2.Text = "Last Stock Taking";
            // 
            // evoLabel5
            // 
            this.evoLabel5.AppearanceName = "";
            this.evoLabel5.ControlID = "";
            this.evoLabel5.Location = new System.Drawing.Point(6, 52);
            this.evoLabel5.Name = "evoLabel5";
            this.evoLabel5.PathString = null;
            this.evoLabel5.PathValue = "Operate By";
            this.evoLabel5.Size = new System.Drawing.Size(114, 35);
            this.evoLabel5.TabIndex = 13;
            this.evoLabel5.Text = "Operate By";
            this.evoLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // evoLabel3
            // 
            this.evoLabel3.AppearanceName = "";
            this.evoLabel3.ControlID = "";
            this.evoLabel3.Location = new System.Drawing.Point(7, 87);
            this.evoLabel3.Name = "evoLabel3";
            this.evoLabel3.PathString = null;
            this.evoLabel3.PathValue = "Remark";
            this.evoLabel3.Size = new System.Drawing.Size(114, 35);
            this.evoLabel3.TabIndex = 13;
            this.evoLabel3.Text = "Remark";
            this.evoLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpLastSTKDate
            // 
            this.dtpLastSTKDate.AppearanceName = "";
            this.dtpLastSTKDate.AppearanceReadOnlyName = "";
            this.dtpLastSTKDate.ControlID = "";
            this.dtpLastSTKDate.DateValue = null;
            this.dtpLastSTKDate.Format = "dd/MM/yyyy";
            this.dtpLastSTKDate.Location = new System.Drawing.Point(158, 24);
            this.dtpLastSTKDate.Mask = "00/00/0000";
            this.dtpLastSTKDate.MaxDateTime = new System.DateTime(9998, 12, 31, 23, 59, 59, 999);
            this.dtpLastSTKDate.MinDateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpLastSTKDate.Name = "dtpLastSTKDate";
            this.dtpLastSTKDate.PathString = null;
            this.dtpLastSTKDate.PathValue = "  /  /";
            this.dtpLastSTKDate.Size = new System.Drawing.Size(117, 27);
            this.dtpLastSTKDate.TabIndex = 1;
            this.dtpLastSTKDate.TabStop = false;
            this.dtpLastSTKDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // evoLabel1
            // 
            this.evoLabel1.AppearanceName = "";
            this.evoLabel1.AutoSize = true;
            this.evoLabel1.ControlID = "";
            this.evoLabel1.Location = new System.Drawing.Point(7, 27);
            this.evoLabel1.Name = "evoLabel1";
            this.evoLabel1.PathString = null;
            this.evoLabel1.PathValue = "Stock Taking Date";
            this.evoLabel1.Size = new System.Drawing.Size(137, 19);
            this.evoLabel1.TabIndex = 0;
            this.evoLabel1.Text = "Stock Taking Date";
            // 
            // txtLastPreProcessBy
            // 
            this.txtLastPreProcessBy.AppearanceName = "";
            this.txtLastPreProcessBy.AppearanceReadOnlyName = "";
            this.txtLastPreProcessBy.ControlID = "";
            this.txtLastPreProcessBy.DisableRestrictChar = false;
            this.txtLastPreProcessBy.HelpButton = null;
            this.txtLastPreProcessBy.Location = new System.Drawing.Point(158, 57);
            this.txtLastPreProcessBy.Name = "txtLastPreProcessBy";
            this.txtLastPreProcessBy.PathString = null;
            this.txtLastPreProcessBy.PathValue = "";
            this.txtLastPreProcessBy.ReadOnly = true;
            this.txtLastPreProcessBy.Size = new System.Drawing.Size(355, 27);
            this.txtLastPreProcessBy.TabIndex = 14;
            this.txtLastPreProcessBy.TabStop = false;
            // 
            // txtLastRemark
            // 
            this.txtLastRemark.AppearanceName = "";
            this.txtLastRemark.AppearanceReadOnlyName = "";
            this.txtLastRemark.ControlID = "";
            this.txtLastRemark.DisableRestrictChar = false;
            this.txtLastRemark.HelpButton = null;
            this.txtLastRemark.Location = new System.Drawing.Point(158, 92);
            this.txtLastRemark.MaxLength = 255;
            this.txtLastRemark.Name = "txtLastRemark";
            this.txtLastRemark.PathString = null;
            this.txtLastRemark.PathValue = "";
            this.txtLastRemark.ReadOnly = true;
            this.txtLastRemark.Size = new System.Drawing.Size(355, 27);
            this.txtLastRemark.TabIndex = 14;
            this.txtLastRemark.TabStop = false;
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
            // STK060_ImportStockTaking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(535, 296);
            this.Controls.Add(this.pnlContainer);
            this.Name = "STK060_ImportStockTaking";
            this.Text = "Import Stock Taking";
            this.Load += new System.EventHandler(this.STK020_PrintStockCheckingList_Load);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.evoGroupBox1.ResumeLayout(false);
            this.evoGroupBox1.PerformLayout();
            this.evoPanel4.ResumeLayout(false);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.evoGroupBox2.ResumeLayout(false);
            this.evoGroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpHeader2;
        private EVOFramework.Windows.Forms.EVOLabel label8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private EVOFramework.Windows.Forms.EVOLabel lblHeaderSTK020;
        private EVOFramework.Windows.Forms.EVOButton btnImport;
        private EVOFramework.Windows.Forms.EVOPanel evoPanel4;
        private EVOFramework.Windows.Forms.EVOPanel pnlContainer;
        private EVOFramework.Windows.Forms.EVOGroupBox evoGroupBox1;
        private EVOFramework.Windows.Forms.EVOLabel lblFileName;
        private EVOFramework.Windows.Forms.EVOTextBox txtFileName;
        private EVOFramework.Windows.Forms.EVOButton btnBrowse;
        private EVOFramework.Windows.Forms.EVOButton btnClearAll;
        private EVOFramework.Windows.Forms.EVOButton btnGetTemplate;
        private EVOFramework.Windows.Forms.EVOGroupBox evoGroupBox2;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel5;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel3;
        private EVOFramework.Windows.Forms.EVODateTextBox dtpLastSTKDate;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel1;
        private EVOFramework.Windows.Forms.EVOTextBox txtLastPreProcessBy;
        private EVOFramework.Windows.Forms.EVOTextBox txtLastRemark;
    }
}
