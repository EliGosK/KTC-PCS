namespace Rubik.Master
{
    partial class MAS052_ChangeItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAS052_ChangeItem));
            this.pnlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtParentItemDesc
            // 
            this.txtParentItemDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(247)))), ((int)(((byte)(243)))));
            this.txtParentItemDesc.ForeColor = System.Drawing.Color.Black;
            this.txtParentItemDesc.ReadOnly = true;
            this.txtParentItemDesc.TabStop = false;
            // 
            // txtParentItemCode
            // 
            this.txtParentItemCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(247)))), ((int)(((byte)(243)))));
            this.txtParentItemCode.ForeColor = System.Drawing.Color.Black;
            this.txtParentItemCode.ReadOnly = true;
            this.txtParentItemCode.TabStop = false;
            // 
            // txtItemDesc
            // 
            this.txtItemDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(247)))), ((int)(((byte)(243)))));
            this.txtItemDesc.ForeColor = System.Drawing.Color.Black;
            this.txtItemDesc.ReadOnly = true;
            this.txtItemDesc.TabStop = false;
            // 
            // txtItemCode
            // 
            this.txtItemCode.BackColor = System.Drawing.Color.White;
            this.txtItemCode.ForeColor = System.Drawing.Color.Black;
            // 
            // txtUpperQty
            // 
            this.txtUpperQty.BackColor = System.Drawing.Color.White;
            this.txtUpperQty.Decimal = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtUpperQty.Double = 1D;
            this.txtUpperQty.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtUpperQty.ForeColor = System.Drawing.Color.Black;
            this.txtUpperQty.Int = 1;
            this.txtUpperQty.Long = ((long)(1));
            this.txtUpperQty.PathValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtUpperQty.Text = "1";
            // 
            // txtLowerQty
            // 
            this.txtLowerQty.BackColor = System.Drawing.Color.White;
            this.txtLowerQty.Decimal = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtLowerQty.Double = 1D;
            this.txtLowerQty.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtLowerQty.ForeColor = System.Drawing.Color.Black;
            this.txtLowerQty.Int = 1;
            this.txtLowerQty.Long = ((long)(1));
            this.txtLowerQty.PathValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtLowerQty.Text = "1";
            // 
            // pnlContainer
            // 
            this.pnlContainer.BackColor = System.Drawing.Color.AliceBlue;
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlContainer.Size = new System.Drawing.Size(507, 302);
            // 
            // cboOrderLoc
            // 
            this.cboOrderLoc.BackColor = System.Drawing.Color.White;
            this.cboOrderLoc.ForeColor = System.Drawing.Color.Black;
            // 
            // cboMRPFlag
            // 
            this.cboMRPFlag.BackColor = System.Drawing.Color.White;
            this.cboMRPFlag.ForeColor = System.Drawing.Color.Black;
            // 
            // MAS052_ChangeItem
            // 
            this.ClientSize = new System.Drawing.Size(507, 352);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MAS052_ChangeItem";
            this.Text = "Edit Item to BOM Setup";
            this.Load += new System.EventHandler(this.MAS052_ChangeItem_Load);
            this.Shown += new System.EventHandler(this.MAS052_ChangeItem_Shown);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
