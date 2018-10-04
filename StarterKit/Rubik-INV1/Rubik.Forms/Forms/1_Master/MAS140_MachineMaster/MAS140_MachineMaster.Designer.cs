namespace Rubik.Master
{
    partial class MAS140_MachineMaster
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAS140_MachineMaster));
            this.stcLocationName = new EVOFramework.Windows.Forms.EVOLabel();
            this.lblProcess = new EVOFramework.Windows.Forms.EVOLabel();
            this.stcLocationCode = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtMachineNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.txtMachineName = new EVOFramework.Windows.Forms.EVOTextBox();
            this.dmcMachine = new EVOFramework.Data.UIDataModelController(this.components);
            this.lblRemark = new EVOFramework.Windows.Forms.EVOLabel();
            this.tlpHeader2 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new EVOFramework.Windows.Forms.EVOLabel();
            this.label4 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtRemark = new EVOFramework.Windows.Forms.EVOTextBox();
            this.tlpTitle = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel2 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel3 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel4 = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboMachineGroup = new EVOFramework.Windows.Forms.EVOComboBoxInputNewData();
            this.evoLabel5 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel6 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel7 = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboMachineType = new EVOFramework.Windows.Forms.EVOComboBox();
            this.cboProcess = new EVOFramework.Windows.Forms.EVOComboBox();
            this.cboProject = new EVOFramework.Windows.Forms.EVOComboBox();
            this.pnlContainer.SuspendLayout();
            this.tlpHeader2.SuspendLayout();
            this.tlpTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.cboProject);
            this.pnlContainer.Controls.Add(this.cboProcess);
            this.pnlContainer.Controls.Add(this.cboMachineType);
            this.pnlContainer.Controls.Add(this.evoLabel7);
            this.pnlContainer.Controls.Add(this.evoLabel3);
            this.pnlContainer.Controls.Add(this.lblRemark);
            this.pnlContainer.Controls.Add(this.tlpTitle);
            this.pnlContainer.Controls.Add(this.txtRemark);
            this.pnlContainer.Controls.Add(this.tlpHeader2);
            this.pnlContainer.Controls.Add(this.label4);
            this.pnlContainer.Controls.Add(this.evoLabel6);
            this.pnlContainer.Controls.Add(this.evoLabel4);
            this.pnlContainer.Controls.Add(this.lblProcess);
            this.pnlContainer.Controls.Add(this.stcLocationCode);
            this.pnlContainer.Controls.Add(this.cboMachineGroup);
            this.pnlContainer.Controls.Add(this.txtMachineNo);
            this.pnlContainer.Controls.Add(this.txtMachineName);
            this.pnlContainer.Controls.Add(this.evoLabel2);
            this.pnlContainer.Controls.Add(this.stcLocationName);
            this.pnlContainer.Controls.Add(this.evoLabel5);
            this.pnlContainer.Controls.Add(this.evoLabel1);
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // stcLocationName
            // 
            this.stcLocationName.AppearanceName = "";
            this.stcLocationName.ControlID = "";
            this.stcLocationName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.stcLocationName.Location = new System.Drawing.Point(33, 377);
            this.stcLocationName.Name = "stcLocationName";
            this.stcLocationName.PathString = null;
            this.stcLocationName.PathValue = "Machine Name";
            this.stcLocationName.Size = new System.Drawing.Size(124, 21);
            this.stcLocationName.TabIndex = 7;
            this.stcLocationName.Text = "Machine Name";
            this.stcLocationName.Visible = false;
            // 
            // lblProcess
            // 
            this.lblProcess.AppearanceName = "";
            this.lblProcess.ControlID = "";
            this.lblProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblProcess.Location = new System.Drawing.Point(33, 159);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.PathString = null;
            this.lblProcess.PathValue = "Process";
            this.lblProcess.Size = new System.Drawing.Size(124, 25);
            this.lblProcess.TabIndex = 6;
            this.lblProcess.Text = "Process";
            // 
            // stcLocationCode
            // 
            this.stcLocationCode.AppearanceName = "";
            this.stcLocationCode.ControlID = "";
            this.stcLocationCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.stcLocationCode.Location = new System.Drawing.Point(33, 92);
            this.stcLocationCode.Name = "stcLocationCode";
            this.stcLocationCode.PathString = null;
            this.stcLocationCode.PathValue = "Machine No.";
            this.stcLocationCode.Size = new System.Drawing.Size(124, 21);
            this.stcLocationCode.TabIndex = 2;
            this.stcLocationCode.Text = "Machine No.";
            // 
            // txtMachineNo
            // 
            this.txtMachineNo.AppearanceName = "";
            this.txtMachineNo.AppearanceReadOnlyName = "";
            this.txtMachineNo.BackColor = System.Drawing.Color.White;
            this.txtMachineNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMachineNo.ControlID = "";
            this.txtMachineNo.DisableRestrictChar = false;
            this.txtMachineNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtMachineNo.ForeColor = System.Drawing.Color.Black;
            this.txtMachineNo.HelpButton = null;
            this.txtMachineNo.Location = new System.Drawing.Point(163, 89);
            this.txtMachineNo.MaxLength = 10;
            this.txtMachineNo.Name = "txtMachineNo";
            this.txtMachineNo.PathString = "MACHINE_CD.Value";
            this.txtMachineNo.PathValue = "";
            this.txtMachineNo.Size = new System.Drawing.Size(281, 26);
            this.txtMachineNo.TabIndex = 1;
            // 
            // txtMachineName
            // 
            this.txtMachineName.AppearanceName = "";
            this.txtMachineName.AppearanceReadOnlyName = "";
            this.txtMachineName.BackColor = System.Drawing.Color.White;
            this.txtMachineName.ControlID = "";
            this.txtMachineName.DisableRestrictChar = false;
            this.txtMachineName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtMachineName.ForeColor = System.Drawing.Color.Black;
            this.txtMachineName.HelpButton = null;
            this.txtMachineName.Location = new System.Drawing.Point(163, 374);
            this.txtMachineName.MaxLength = 50;
            this.txtMachineName.Name = "txtMachineName";
            this.txtMachineName.PathString = "MACHINE_NAME.Value";
            this.txtMachineName.PathValue = "";
            this.txtMachineName.Size = new System.Drawing.Size(281, 26);
            this.txtMachineName.TabIndex = 7;
            this.txtMachineName.Visible = false;
            // 
            // lblRemark
            // 
            this.lblRemark.AppearanceName = "";
            this.lblRemark.AutoSize = true;
            this.lblRemark.ControlID = "";
            this.lblRemark.Location = new System.Drawing.Point(33, 262);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.PathString = null;
            this.lblRemark.PathValue = "Remark";
            this.lblRemark.Size = new System.Drawing.Size(63, 19);
            this.lblRemark.TabIndex = 20;
            this.lblRemark.Text = "Remark";
            this.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpHeader2
            // 
            this.tlpHeader2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpHeader2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tlpHeader2.BackgroundImage")));
            this.tlpHeader2.ColumnCount = 1;
            this.tlpHeader2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpHeader2.Controls.Add(this.label3, 0, 0);
            this.tlpHeader2.Location = new System.Drawing.Point(10, 47);
            this.tlpHeader2.Name = "tlpHeader2";
            this.tlpHeader2.RowCount = 1;
            this.tlpHeader2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHeader2.Size = new System.Drawing.Size(664, 24);
            this.tlpHeader2.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AppearanceName = "Header";
            this.label3.AutoSize = true;
            this.label3.ControlID = "";
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label3.Name = "label3";
            this.label3.PathString = null;
            this.label3.PathValue = "Machine Information";
            this.label3.Size = new System.Drawing.Size(180, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Machine Information";
            // 
            // label4
            // 
            this.label4.AppearanceName = "RequireText";
            this.label4.AutoSize = true;
            this.label4.ControlID = "";
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label4.Location = new System.Drawing.Point(13, 93);
            this.label4.Name = "label4";
            this.label4.PathString = null;
            this.label4.PathValue = "*";
            this.label4.Size = new System.Drawing.Size(18, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "*";
            // 
            // evoLabel1
            // 
            this.evoLabel1.AppearanceName = "RequireText";
            this.evoLabel1.AutoSize = true;
            this.evoLabel1.ControlID = "";
            this.evoLabel1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel1.Location = new System.Drawing.Point(13, 162);
            this.evoLabel1.Name = "evoLabel1";
            this.evoLabel1.PathString = null;
            this.evoLabel1.PathValue = "*";
            this.evoLabel1.Size = new System.Drawing.Size(18, 19);
            this.evoLabel1.TabIndex = 12;
            this.evoLabel1.Text = "*";
            // 
            // txtRemark
            // 
            this.txtRemark.AppearanceName = "";
            this.txtRemark.AppearanceReadOnlyName = "";
            this.txtRemark.BackColor = System.Drawing.Color.White;
            this.txtRemark.ControlID = "";
            this.txtRemark.DisableRestrictChar = false;
            this.txtRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtRemark.ForeColor = System.Drawing.Color.Black;
            this.txtRemark.HelpButton = null;
            this.txtRemark.Location = new System.Drawing.Point(163, 259);
            this.txtRemark.MaxLength = 255;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.PathString = "REMARK.Value";
            this.txtRemark.PathValue = "";
            this.txtRemark.Size = new System.Drawing.Size(281, 109);
            this.txtRemark.TabIndex = 6;
            // 
            // tlpTitle
            // 
            this.tlpTitle.ColumnCount = 1;
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.Controls.Add(this.label1, 0, 0);
            this.tlpTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpTitle.Location = new System.Drawing.Point(0, 0);
            this.tlpTitle.Name = "tlpTitle";
            this.tlpTitle.RowCount = 1;
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpTitle.Size = new System.Drawing.Size(686, 41);
            this.tlpTitle.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AppearanceName = "Title";
            this.label1.AutoSize = true;
            this.label1.ControlID = "";
            this.label1.Font = new System.Drawing.Font("Tahoma", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.PathString = null;
            this.label1.PathValue = "Machine Information Entry";
            this.label1.Size = new System.Drawing.Size(448, 39);
            this.label1.TabIndex = 35;
            this.label1.Text = "Machine Information Entry";
            // 
            // evoLabel2
            // 
            this.evoLabel2.AppearanceName = "";
            this.evoLabel2.ControlID = "";
            this.evoLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel2.Location = new System.Drawing.Point(33, 127);
            this.evoLabel2.Name = "evoLabel2";
            this.evoLabel2.PathString = null;
            this.evoLabel2.PathValue = "Machine Type";
            this.evoLabel2.Size = new System.Drawing.Size(124, 21);
            this.evoLabel2.TabIndex = 7;
            this.evoLabel2.Text = "Machine Type";
            // 
            // evoLabel3
            // 
            this.evoLabel3.AppearanceName = "RequireText";
            this.evoLabel3.AutoSize = true;
            this.evoLabel3.ControlID = "";
            this.evoLabel3.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel3.Location = new System.Drawing.Point(13, 128);
            this.evoLabel3.Name = "evoLabel3";
            this.evoLabel3.PathString = null;
            this.evoLabel3.PathValue = "*";
            this.evoLabel3.Size = new System.Drawing.Size(18, 19);
            this.evoLabel3.TabIndex = 54;
            this.evoLabel3.Text = "*";
            // 
            // evoLabel4
            // 
            this.evoLabel4.AppearanceName = "";
            this.evoLabel4.ControlID = "";
            this.evoLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel4.Location = new System.Drawing.Point(33, 194);
            this.evoLabel4.Name = "evoLabel4";
            this.evoLabel4.PathString = null;
            this.evoLabel4.PathValue = "Machine Group";
            this.evoLabel4.Size = new System.Drawing.Size(124, 25);
            this.evoLabel4.TabIndex = 6;
            this.evoLabel4.Text = "Machine Group";
            // 
            // cboMachineGroup
            // 
            this.cboMachineGroup.AppearanceName = "";
            this.cboMachineGroup.AppearanceReadOnlyName = "";
            this.cboMachineGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboMachineGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMachineGroup.BackColor = System.Drawing.Color.White;
            this.cboMachineGroup.ControlID = null;
            this.cboMachineGroup.DropDownHeight = 180;
            this.cboMachineGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboMachineGroup.ForeColor = System.Drawing.Color.Black;
            this.cboMachineGroup.FormattingEnabled = true;
            this.cboMachineGroup.IntegralHeight = false;
            this.cboMachineGroup.Location = new System.Drawing.Point(163, 191);
            this.cboMachineGroup.MaxLength = 10;
            this.cboMachineGroup.Name = "cboMachineGroup";
            this.cboMachineGroup.PathString = "MACHINE_GROUP.Value";
            this.cboMachineGroup.PathValue = null;
            this.cboMachineGroup.Size = new System.Drawing.Size(281, 28);
            this.cboMachineGroup.TabIndex = 4;
            //this.cboMachineGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbo_KeyDown);
            // 
            // evoLabel5
            // 
            this.evoLabel5.AppearanceName = "RequireText";
            this.evoLabel5.AutoSize = true;
            this.evoLabel5.ControlID = "";
            this.evoLabel5.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel5.Location = new System.Drawing.Point(13, 194);
            this.evoLabel5.Name = "evoLabel5";
            this.evoLabel5.PathString = null;
            this.evoLabel5.PathValue = "*";
            this.evoLabel5.Size = new System.Drawing.Size(18, 19);
            this.evoLabel5.TabIndex = 12;
            this.evoLabel5.Text = "*";
            // 
            // evoLabel6
            // 
            this.evoLabel6.AppearanceName = "";
            this.evoLabel6.ControlID = "";
            this.evoLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel6.Location = new System.Drawing.Point(33, 228);
            this.evoLabel6.Name = "evoLabel6";
            this.evoLabel6.PathString = null;
            this.evoLabel6.PathValue = "Project";
            this.evoLabel6.Size = new System.Drawing.Size(124, 25);
            this.evoLabel6.TabIndex = 6;
            this.evoLabel6.Text = "Project";
            // 
            // evoLabel7
            // 
            this.evoLabel7.AppearanceName = "RequireText";
            this.evoLabel7.AutoSize = true;
            this.evoLabel7.ControlID = "";
            this.evoLabel7.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel7.Location = new System.Drawing.Point(13, 228);
            this.evoLabel7.Name = "evoLabel7";
            this.evoLabel7.PathString = null;
            this.evoLabel7.PathValue = "*";
            this.evoLabel7.Size = new System.Drawing.Size(18, 19);
            this.evoLabel7.TabIndex = 55;
            this.evoLabel7.Text = "*";
            // 
            // cboMachineType
            // 
            this.cboMachineType.AppearanceName = "";
            this.cboMachineType.AppearanceReadOnlyName = "";
            this.cboMachineType.ControlID = null;
            this.cboMachineType.DropDownHeight = 180;
            this.cboMachineType.FormattingEnabled = true;
            this.cboMachineType.IntegralHeight = false;
            this.cboMachineType.Location = new System.Drawing.Point(163, 121);
            this.cboMachineType.MaxLength = 30;
            this.cboMachineType.Name = "cboMachineType";
            this.cboMachineType.PathString = "MACHINE_TYPE.Value";
            this.cboMachineType.PathValue = null;
            this.cboMachineType.Size = new System.Drawing.Size(281, 27);
            this.cboMachineType.TabIndex = 2;
            this.cboMachineType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbo_KeyDown);
            // 
            // cboProcess
            // 
            this.cboProcess.AppearanceName = "";
            this.cboProcess.AppearanceReadOnlyName = "";
            this.cboProcess.ControlID = null;
            this.cboProcess.DropDownHeight = 180;
            this.cboProcess.FormattingEnabled = true;
            this.cboProcess.IntegralHeight = false;
            this.cboProcess.Location = new System.Drawing.Point(163, 154);
            this.cboProcess.MaxLength = 30;
            this.cboProcess.Name = "cboProcess";
            this.cboProcess.PathString = "PROCESS_CD.Value";
            this.cboProcess.PathValue = null;
            this.cboProcess.Size = new System.Drawing.Size(281, 27);
            this.cboProcess.TabIndex = 3;
            this.cboProcess.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbo_KeyDown);
            // 
            // cboProject
            // 
            this.cboProject.AppearanceName = "";
            this.cboProject.AppearanceReadOnlyName = "";
            this.cboProject.ControlID = null;
            this.cboProject.DropDownHeight = 180;
            this.cboProject.FormattingEnabled = true;
            this.cboProject.IntegralHeight = false;
            this.cboProject.Location = new System.Drawing.Point(163, 225);
            this.cboProject.MaxLength = 30;
            this.cboProject.Name = "cboProject";
            this.cboProject.PathString = "PROJECT.Value";
            this.cboProject.PathValue = null;
            this.cboProject.Size = new System.Drawing.Size(281, 27);
            this.cboProject.TabIndex = 5;
            this.cboProject.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbo_KeyDown);
            // 
            // MAS140_MachineMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(686, 489);
            this.Name = "MAS140_MachineMaster";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MAS020_LocationMaster_FormClosing);
            this.Load += new System.EventHandler(this.MAS020_LocationMaster_Load);
            this.Shown += new System.EventHandler(this.MAS020_LocationMaster_Shown);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.tlpHeader2.ResumeLayout(false);
            this.tlpHeader2.PerformLayout();
            this.tlpTitle.ResumeLayout(false);
            this.tlpTitle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EVOFramework.Windows.Forms.EVOLabel stcLocationName;
        private EVOFramework.Windows.Forms.EVOLabel lblProcess;
        private EVOFramework.Windows.Forms.EVOLabel stcLocationCode;
        private EVOFramework.Windows.Forms.EVOTextBox txtMachineNo;
        private EVOFramework.Windows.Forms.EVOTextBox txtMachineName;
        private EVOFramework.Data.UIDataModelController dmcMachine;
        private System.Windows.Forms.TableLayoutPanel tlpHeader2;
        private EVOFramework.Windows.Forms.EVOLabel label3;
        private System.Windows.Forms.TableLayoutPanel tlpTitle;
        private EVOFramework.Windows.Forms.EVOLabel label1;
        private EVOFramework.Windows.Forms.EVOLabel label4;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel1;
        private EVOFramework.Windows.Forms.EVOLabel lblRemark;
        private EVOFramework.Windows.Forms.EVOTextBox txtRemark;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel2;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel3;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel4;
        private EVOFramework.Windows.Forms.EVOComboBoxInputNewData cboMachineGroup;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel5;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel6;
        private EVOFramework.Windows.Forms.EVOLabel evoLabel7;
        protected EVOFramework.Windows.Forms.EVOComboBox cboProcess;
        protected EVOFramework.Windows.Forms.EVOComboBox cboMachineType;
        protected EVOFramework.Windows.Forms.EVOComboBox cboProject;
    }
}