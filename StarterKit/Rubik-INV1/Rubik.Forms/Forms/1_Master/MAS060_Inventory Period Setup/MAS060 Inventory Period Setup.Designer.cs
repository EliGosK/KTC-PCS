namespace Rubik.Master
{
    partial class MAS060
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAS060));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new EVOFramework.Windows.Forms.EVOPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblHeader = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblInventoryMonth = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblInventoryPeriod = new EVOFramework.Windows.Forms.EVOLabel();
            this.label5 = new EVOFramework.Windows.Forms.EVOLabel();
            this.dtInventoryMonth = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.dtPeriodTo = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.dtPeriodFrom = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.tlpHeader2 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new EVOFramework.Windows.Forms.EVOLabel();
            this.pnlContainer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.tableLayoutPanel1);
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlContainer.Size = new System.Drawing.Size(585, 186);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 146F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 157F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 156F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 186F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblInventoryMonth, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblInventoryPeriod, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.dtInventoryMonth, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtPeriodTo, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.dtPeriodFrom, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(561, 171);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AppearanceName = "";
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 5);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(656, 41);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel2.BackgroundImage")));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 656F));
            this.tableLayoutPanel2.Controls.Add(this.lblHeader, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(656, 41);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // lblHeader
            // 
            this.lblHeader.AppearanceName = "Header";
            this.lblHeader.AutoSize = true;
            this.lblHeader.ControlID = "";
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblHeader.ForeColor = System.Drawing.Color.Navy;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.PathString = null;
            this.lblHeader.PathValue = "Inventory Period Information";
            this.lblHeader.Size = new System.Drawing.Size(243, 24);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Inventory Period Information";
            // 
            // lblInventoryMonth
            // 
            this.lblInventoryMonth.AppearanceName = "";
            this.lblInventoryMonth.ControlID = "";
            this.lblInventoryMonth.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInventoryMonth.Location = new System.Drawing.Point(3, 47);
            this.lblInventoryMonth.Name = "lblInventoryMonth";
            this.lblInventoryMonth.PathString = null;
            this.lblInventoryMonth.PathValue = "Inventory Month";
            this.lblInventoryMonth.Size = new System.Drawing.Size(140, 26);
            this.lblInventoryMonth.TabIndex = 1;
            this.lblInventoryMonth.Text = "Inventory Month";
            this.lblInventoryMonth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblInventoryPeriod
            // 
            this.lblInventoryPeriod.AppearanceName = "";
            this.lblInventoryPeriod.ControlID = "";
            this.lblInventoryPeriod.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInventoryPeriod.Location = new System.Drawing.Point(3, 83);
            this.lblInventoryPeriod.Name = "lblInventoryPeriod";
            this.lblInventoryPeriod.PathString = null;
            this.lblInventoryPeriod.PathValue = "Inventory Period";
            this.lblInventoryPeriod.Size = new System.Drawing.Size(140, 23);
            this.lblInventoryPeriod.TabIndex = 2;
            this.lblInventoryPeriod.Text = "Inventory Period";
            this.lblInventoryPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AppearanceName = "";
            this.label5.ControlID = "";
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(306, 83);
            this.label5.Name = "label5";
            this.label5.PathString = null;
            this.label5.PathValue = "-";
            this.label5.Size = new System.Drawing.Size(11, 23);
            this.label5.TabIndex = 3;
            this.label5.Text = "-";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtInventoryMonth
            // 
            this.dtInventoryMonth.AppearanceName = "";
            this.dtInventoryMonth.AppearanceReadOnlyName = "";
            this.dtInventoryMonth.BackColor = System.Drawing.Color.Transparent;
            this.dtInventoryMonth.ControlID = "";
            this.dtInventoryMonth.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtInventoryMonth.Format = "MM/yyyy";
            this.dtInventoryMonth.Location = new System.Drawing.Point(149, 50);
            this.dtInventoryMonth.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtInventoryMonth.Name = "dtInventoryMonth";
            this.dtInventoryMonth.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtInventoryMonth.NZValue")));
            this.dtInventoryMonth.PathString = null;
            this.dtInventoryMonth.PathValue = ((object)(resources.GetObject("dtInventoryMonth.PathValue")));
            this.dtInventoryMonth.ReadOnly = false;
            this.dtInventoryMonth.ShowButton = true;
            this.dtInventoryMonth.Size = new System.Drawing.Size(151, 20);
            this.dtInventoryMonth.TabIndex = 1;
            this.dtInventoryMonth.Value = null;
            this.dtInventoryMonth.ValueChanged += new System.EventHandler(this.dtInventoryMonth_ValueChanged);
            this.dtInventoryMonth.Leave += new System.EventHandler(this.dtInventoryMonth_Leave);
            // 
            // dtPeriodTo
            // 
            this.dtPeriodTo.AppearanceName = "";
            this.dtPeriodTo.AppearanceReadOnlyName = "";
            this.dtPeriodTo.BackColor = System.Drawing.Color.Transparent;
            this.dtPeriodTo.ControlID = "";
            this.dtPeriodTo.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtPeriodTo.Format = "dd/MM/yyyy";
            this.dtPeriodTo.Location = new System.Drawing.Point(323, 86);
            this.dtPeriodTo.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtPeriodTo.Name = "dtPeriodTo";
            this.dtPeriodTo.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtPeriodTo.NZValue")));
            this.dtPeriodTo.PathString = null;
            this.dtPeriodTo.PathValue = ((object)(resources.GetObject("dtPeriodTo.PathValue")));
            this.dtPeriodTo.ReadOnly = false;
            this.dtPeriodTo.ShowButton = true;
            this.dtPeriodTo.Size = new System.Drawing.Size(150, 20);
            this.dtPeriodTo.TabIndex = 3;
            this.dtPeriodTo.Value = null;
            // 
            // dtPeriodFrom
            // 
            this.dtPeriodFrom.AppearanceName = "";
            this.dtPeriodFrom.AppearanceReadOnlyName = "";
            this.dtPeriodFrom.BackColor = System.Drawing.Color.Transparent;
            this.dtPeriodFrom.ControlID = "";
            this.dtPeriodFrom.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtPeriodFrom.Format = "dd/MM/yyyy";
            this.dtPeriodFrom.Location = new System.Drawing.Point(149, 86);
            this.dtPeriodFrom.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtPeriodFrom.Name = "dtPeriodFrom";
            this.dtPeriodFrom.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtPeriodFrom.NZValue")));
            this.dtPeriodFrom.PathString = null;
            this.dtPeriodFrom.PathValue = ((object)(resources.GetObject("dtPeriodFrom.PathValue")));
            this.dtPeriodFrom.ReadOnly = false;
            this.dtPeriodFrom.ShowButton = true;
            this.dtPeriodFrom.Size = new System.Drawing.Size(151, 20);
            this.dtPeriodFrom.TabIndex = 2;
            this.dtPeriodFrom.Value = null;
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
            // label3
            // 
            this.label3.AppearanceName = "";
            this.label3.AutoSize = true;
            this.label3.ControlID = "";
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label3.Name = "label3";
            this.label3.PathString = null;
            this.label3.PathValue = "Location Information";
            this.label3.Size = new System.Drawing.Size(178, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Location Information";
            // 
            // MAS060
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(585, 236);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MAS060";
            this.Text = "Inventory Period Setup";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MAS060_Load);
            this.pnlContainer.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private EVOFramework.Windows.Forms.EVOPanel panel1;
        private System.Windows.Forms.TableLayoutPanel tlpHeader2;
        private EVOFramework.Windows.Forms.EVOLabel label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private EVOFramework.Windows.Forms.EVOLabel lblHeader;
        private EVOFramework.Windows.Forms.EVOLabel lblInventoryMonth;
        private EVOFramework.Windows.Forms.EVOLabel lblInventoryPeriod;
        private EVOFramework.Windows.Forms.EVOLabel label5;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtInventoryMonth;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtPeriodTo;
        private EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar dtPeriodFrom;
    }
}
