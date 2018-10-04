namespace Rubik.MRP
{
    partial class MRP011_SourceOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MRP011_SourceOrder));
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.evoLabel5 = new EVOFramework.Windows.Forms.EVOLabel();
            this.stdReceiveDate = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel2 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtStartDate = new EVOFramework.Windows.Forms.EVOTextBox();
            this.txtItemFrom = new EVOFramework.Windows.Forms.EVOTextBox();
            this.txtItemTo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.shtView = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.AutoSize = true;
            this.tableLayoutPanel7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel7.BackgroundImage")));
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.Location = new System.Drawing.Point(1, 12);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(665, 24);
            this.tableLayoutPanel7.TabIndex = 10004;
            // 
            // evoLabel5
            // 
            this.evoLabel5.AppearanceName = "Title";
            this.evoLabel5.AutoSize = true;
            this.evoLabel5.ControlID = "";
            this.evoLabel5.Font = new System.Drawing.Font("Tahoma", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.evoLabel5.Location = new System.Drawing.Point(1, 2);
            this.evoLabel5.Name = "evoLabel5";
            this.evoLabel5.PathString = null;
            this.evoLabel5.PathValue = "Working Calendar";
            this.evoLabel5.Size = new System.Drawing.Size(304, 39);
            this.evoLabel5.TabIndex = 10003;
            this.evoLabel5.Text = "Working Calendar";
            // 
            // stdReceiveDate
            // 
            this.stdReceiveDate.AppearanceName = "";
            this.stdReceiveDate.AutoSize = true;
            this.stdReceiveDate.ControlID = "";
            this.stdReceiveDate.Font = new System.Drawing.Font("Tahoma", 12F);
            this.stdReceiveDate.Location = new System.Drawing.Point(32, 52);
            this.stdReceiveDate.Name = "stdReceiveDate";
            this.stdReceiveDate.PathString = null;
            this.stdReceiveDate.PathValue = "Start Date";
            this.stdReceiveDate.Size = new System.Drawing.Size(79, 19);
            this.stdReceiveDate.TabIndex = 10005;
            this.stdReceiveDate.Text = "Start Date";
            // 
            // evoLabel1
            // 
            this.evoLabel1.AppearanceName = "";
            this.evoLabel1.AutoSize = true;
            this.evoLabel1.ControlID = "";
            this.evoLabel1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel1.Location = new System.Drawing.Point(32, 83);
            this.evoLabel1.Name = "evoLabel1";
            this.evoLabel1.PathString = null;
            this.evoLabel1.PathValue = "Part No.";
            this.evoLabel1.Size = new System.Drawing.Size(67, 19);
            this.evoLabel1.TabIndex = 10006;
            this.evoLabel1.Text = "Part No.";
            // 
            // evoLabel2
            // 
            this.evoLabel2.AppearanceName = "";
            this.evoLabel2.AutoSize = true;
            this.evoLabel2.ControlID = "";
            this.evoLabel2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel2.Location = new System.Drawing.Point(364, 83);
            this.evoLabel2.Name = "evoLabel2";
            this.evoLabel2.PathString = null;
            this.evoLabel2.PathValue = "To";
            this.evoLabel2.Size = new System.Drawing.Size(28, 19);
            this.evoLabel2.TabIndex = 10007;
            this.evoLabel2.Text = "To";
            // 
            // txtStartDate
            // 
            this.txtStartDate.AppearanceName = "";
            this.txtStartDate.AppearanceReadOnlyName = "";
            this.txtStartDate.ControlID = "";
            this.txtStartDate.DisableRestrictChar = false;
            this.txtStartDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtStartDate.HelpButton = null;
            this.txtStartDate.Location = new System.Drawing.Point(128, 49);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.PathString = null;
            this.txtStartDate.PathValue = "";
            this.txtStartDate.ReadOnly = true;
            this.txtStartDate.Size = new System.Drawing.Size(230, 27);
            this.txtStartDate.TabIndex = 10008;
            this.txtStartDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtItemFrom
            // 
            this.txtItemFrom.AppearanceName = "";
            this.txtItemFrom.AppearanceReadOnlyName = "";
            this.txtItemFrom.ControlID = "";
            this.txtItemFrom.DisableRestrictChar = false;
            this.txtItemFrom.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtItemFrom.HelpButton = null;
            this.txtItemFrom.Location = new System.Drawing.Point(128, 80);
            this.txtItemFrom.MaxLength = 50;
            this.txtItemFrom.Name = "txtItemFrom";
            this.txtItemFrom.PathString = null;
            this.txtItemFrom.PathValue = "";
            this.txtItemFrom.ReadOnly = true;
            this.txtItemFrom.Size = new System.Drawing.Size(230, 27);
            this.txtItemFrom.TabIndex = 10009;
            // 
            // txtItemTo
            // 
            this.txtItemTo.AppearanceName = "";
            this.txtItemTo.AppearanceReadOnlyName = "";
            this.txtItemTo.ControlID = "";
            this.txtItemTo.DisableRestrictChar = false;
            this.txtItemTo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtItemTo.HelpButton = null;
            this.txtItemTo.Location = new System.Drawing.Point(398, 80);
            this.txtItemTo.MaxLength = 50;
            this.txtItemTo.Name = "txtItemTo";
            this.txtItemTo.PathString = null;
            this.txtItemTo.PathValue = "";
            this.txtItemTo.ReadOnly = true;
            this.txtItemTo.Size = new System.Drawing.Size(230, 27);
            this.txtItemTo.TabIndex = 10010;
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "2.5.2015.2005";
            this.fpSpread1.AccessibleDescription = "fpSpread1, Sheet1, Row 0, Column 0, ";
            this.fpSpread1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fpSpread1.BackColor = System.Drawing.Color.AliceBlue;
            this.fpSpread1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.Location = new System.Drawing.Point(8, 113);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpSpread1.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtView});
            this.fpSpread1.Size = new System.Drawing.Size(658, 308);
            this.fpSpread1.TabIndex = 10011;
            this.fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpSpread1_KeyDown);
            // 
            // shtView
            // 
            this.shtView.Reset();
            this.shtView.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtView.ColumnCount = 0;
            this.shtView.RowCount = 0;
            this.shtView.AutoCalculation = false;
            this.shtView.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.shtView.ColumnHeader.Rows.Get(0).Height = 41F;
            this.shtView.DefaultStyle.ForeColor = System.Drawing.Color.Blue;
            this.shtView.DefaultStyle.Locked = true;
            this.shtView.DefaultStyle.Parent = "DataAreaDefault";
            this.shtView.LockForeColor = System.Drawing.Color.Black;
            this.shtView.RowHeader.Columns.Default.Resizable = true;
            this.shtView.RowHeader.Columns.Get(0).Width = 50F;
            this.shtView.RowHeader.Visible = false;
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpSpread1.SetActiveViewport(0, 1, 1);
            // 
            // MRP011_SourceOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(677, 433);
            this.Controls.Add(this.fpSpread1);
            this.Controls.Add(this.txtItemTo);
            this.Controls.Add(this.txtItemFrom);
            this.Controls.Add(this.txtStartDate);
            this.Controls.Add(this.evoLabel2);
            this.Controls.Add(this.evoLabel1);
            this.Controls.Add(this.stdReceiveDate);
            this.Controls.Add(this.evoLabel5);
            this.Controls.Add(this.tableLayoutPanel7);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(685, 467);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(685, 467);
            this.Name = "MRP011_SourceOrder";
            this.Text = "MRP011 - Source Order";
            this.Load += new System.EventHandler(this.MRP011_SourceOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EVOFramework.Windows.Forms.EVOLabel evoLabel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private EVOFramework.Windows.Forms.EVOLabel stdReceiveDate;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel1;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel2;
        private EVOFramework.Windows.Forms.EVOTextBox txtStartDate;
        private EVOFramework.Windows.Forms.EVOTextBox txtItemFrom;
        private EVOFramework.Windows.Forms.EVOTextBox txtItemTo;
        private FarPoint.Win.Spread.FpSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView shtView;


    }
}