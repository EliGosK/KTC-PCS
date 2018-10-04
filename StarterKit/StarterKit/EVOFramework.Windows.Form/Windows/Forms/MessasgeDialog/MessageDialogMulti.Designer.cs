namespace EVOFramework.Windows.Forms
{
    partial class MessageDialogMulti
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlDesc = new System.Windows.Forms.Panel();
            this.gridWarning = new System.Windows.Forms.DataGridView();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.colNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlDesc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridWarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDesc
            // 
            this.pnlDesc.Controls.Add(this.gridWarning);
            this.pnlDesc.Controls.Add(this.picIcon);
            this.pnlDesc.Controls.Add(this.lblDescription);
            this.pnlDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDesc.Location = new System.Drawing.Point(1, 24);
            this.pnlDesc.Name = "pnlDesc";
            this.pnlDesc.Size = new System.Drawing.Size(383, 142);
            this.pnlDesc.TabIndex = 4;
            // 
            // gridWarning
            // 
            this.gridWarning.AllowUserToAddRows = false;
            this.gridWarning.AllowUserToDeleteRows = false;
            this.gridWarning.AllowUserToResizeColumns = false;
            this.gridWarning.AllowUserToResizeRows = false;
            this.gridWarning.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridWarning.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridWarning.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridWarning.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridWarning.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNO,
            this.colCODE,
            this.colDesc});
            this.gridWarning.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridWarning.Location = new System.Drawing.Point(10, 40);
            this.gridWarning.MultiSelect = false;
            this.gridWarning.Name = "gridWarning";
            this.gridWarning.ReadOnly = true;
            this.gridWarning.RowHeadersVisible = false;
            this.gridWarning.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridWarning.RowTemplate.ReadOnly = true;
            this.gridWarning.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridWarning.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridWarning.ShowCellErrors = false;
            this.gridWarning.ShowCellToolTips = false;
            this.gridWarning.ShowEditingIcon = false;
            this.gridWarning.ShowRowErrors = false;
            this.gridWarning.Size = new System.Drawing.Size(371, 94);
            this.gridWarning.StandardTab = true;
            this.gridWarning.TabIndex = 3;
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
            this.lblDescription.Size = new System.Drawing.Size(66, 13);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "Warning List";
            // 
            // colNO
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.colNO.DefaultCellStyle = dataGridViewCellStyle1;
            this.colNO.HeaderText = "No";
            this.colNO.MinimumWidth = 30;
            this.colNO.Name = "colNO";
            this.colNO.ReadOnly = true;
            this.colNO.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colNO.Width = 30;
            // 
            // colCODE
            // 
            this.colCODE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.colCODE.DefaultCellStyle = dataGridViewCellStyle2;
            this.colCODE.HeaderText = "Code";
            this.colCODE.MinimumWidth = 80;
            this.colCODE.Name = "colCODE";
            this.colCODE.ReadOnly = true;
            this.colCODE.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colCODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCODE.Width = 80;
            // 
            // colDesc
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colDesc.DefaultCellStyle = dataGridViewCellStyle3;
            this.colDesc.HeaderText = "Description";
            this.colDesc.MinimumWidth = 250;
            this.colDesc.Name = "colDesc";
            this.colDesc.ReadOnly = true;
            this.colDesc.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDesc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDesc.Width = 250;
            // 
            // MessageDialogMulti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 196);
            this.Controls.Add(this.pnlDesc);
            this.MessageDialogResult = EVOFramework.Windows.Forms.MessageDialogResult.OK;
            this.Name = "MessageDialogMulti";
            this.Text = "MessageDialogMulti";
            this.Controls.SetChildIndex(this.pnlDesc, 0);
            this.pnlDesc.ResumeLayout(false);
            this.pnlDesc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridWarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDesc;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.DataGridView gridWarning;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesc;
    }
}