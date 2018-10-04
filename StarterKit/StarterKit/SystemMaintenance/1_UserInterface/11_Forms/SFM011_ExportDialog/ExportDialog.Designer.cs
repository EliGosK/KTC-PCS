using SystemMaintenance.Forms;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System;
namespace SystemMaintenance.Forms
{
    partial class ExportDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        ///// <summary>
        ///// Clean up any resources being used.
        ///// </summary>
        ///// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportDialog));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pnlSelector = new System.Windows.Forms.Panel();
            this.border2 = new EVOFramework.Windows.Forms.EVOBorder();
            this.btnExcel = new SystemMaintenance.Forms.StepButton();
            this.pnlExcel = new System.Windows.Forms.Panel();
            this.grpExcel_Condition = new System.Windows.Forms.GroupBox();
            this.chkExcel_Header = new System.Windows.Forms.CheckBox();
            this.pnlExcel_Bottom = new System.Windows.Forms.Panel();
            this.btnExcel_Browse = new System.Windows.Forms.Button();
            this.lblExcel_Filename = new System.Windows.Forms.Label();
            this.txtExcel_Filename = new System.Windows.Forms.TextBox();
            this.pnlExcel_Finish = new System.Windows.Forms.Panel();
            this.chkExcel_OpenFile = new System.Windows.Forms.CheckBox();
            this.btnCSV = new SystemMaintenance.Forms.StepButton();
            this.pnlCSV = new System.Windows.Forms.Panel();
            this.grpCSV_Condition = new System.Windows.Forms.GroupBox();
            this.grpCSV_Encoding = new System.Windows.Forms.GroupBox();
            this.rdoCSV_EncodingUnicode = new System.Windows.Forms.RadioButton();
            this.rdoCSV_EncodingANSI = new System.Windows.Forms.RadioButton();
            this.cboCSV_SplitBy = new System.Windows.Forms.ComboBox();
            this.chkCSV_Quote = new System.Windows.Forms.CheckBox();
            this.chkCSV_Header = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlCSV_Bottom = new System.Windows.Forms.Panel();
            this.btnCSV_Browse = new System.Windows.Forms.Button();
            this.lblCSV_Filename = new System.Windows.Forms.Label();
            this.txtCSV_Filename = new System.Windows.Forms.TextBox();
            this.pnlCSV_Finish = new System.Windows.Forms.Panel();
            this.chkCSV_OpenFile = new System.Windows.Forms.CheckBox();
            this.pnlCondition = new System.Windows.Forms.Panel();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.border1 = new EVOFramework.Windows.Forms.EVOBorder();
            this.prgExport = new System.Windows.Forms.ProgressBar();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlSelector.SuspendLayout();
            this.pnlExcel.SuspendLayout();
            this.grpExcel_Condition.SuspendLayout();
            this.pnlExcel_Bottom.SuspendLayout();
            this.pnlExcel_Finish.SuspendLayout();
            this.pnlCSV.SuspendLayout();
            this.grpCSV_Condition.SuspendLayout();
            this.grpCSV_Encoding.SuspendLayout();
            this.pnlCSV_Bottom.SuspendLayout();
            this.pnlCSV_Finish.SuspendLayout();
            this.pnlCondition.SuspendLayout();
            this.pnlButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSelector
            // 
            this.pnlSelector.Controls.Add(this.border2);
            this.pnlSelector.Controls.Add(this.btnExcel);
            this.pnlSelector.Controls.Add(this.btnCSV);
            this.pnlSelector.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSelector.Location = new System.Drawing.Point(0, 0);
            this.pnlSelector.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSelector.Name = "pnlSelector";
            this.pnlSelector.Size = new System.Drawing.Size(139, 189);
            this.pnlSelector.TabIndex = 3;
            // 
            // border2
            // 
            this.border2.BorderLineColor = System.Drawing.SystemColors.ControlDark;
            this.border2.Dock = System.Windows.Forms.DockStyle.Right;
            this.border2.Location = new System.Drawing.Point(136, 0);
            this.border2.Name = "border2";
            this.border2.Size = new System.Drawing.Size(3, 189);
            this.border2.Style = EVOFramework.Windows.Forms.EVOBorder.BorderEdgeStyle.Right;
            this.border2.TabIndex = 10;
            // 
            // btnExcel
            // 
            this.btnExcel.ContentPanel = this.pnlExcel;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Location = new System.Drawing.Point(10, 8);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(119, 38);
            this.btnExcel.TabIndex = 2;
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            // 
            // pnlExcel
            // 
            this.pnlExcel.Controls.Add(this.pnlExcel_Bottom);
            this.pnlExcel.Controls.Add(this.pnlExcel_Finish);
            this.pnlExcel.Controls.Add(this.grpExcel_Condition);
            this.pnlExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlExcel.Location = new System.Drawing.Point(2, 0);
            this.pnlExcel.Name = "pnlExcel";
            this.pnlExcel.Padding = new System.Windows.Forms.Padding(5, 5, 10, 5);
            this.pnlExcel.Size = new System.Drawing.Size(374, 189);
            this.pnlExcel.TabIndex = 0;
            // 
            // grpExcel_Condition
            // 
            this.grpExcel_Condition.Controls.Add(this.chkExcel_Header);
            this.grpExcel_Condition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpExcel_Condition.Location = new System.Drawing.Point(5, 5);
            this.grpExcel_Condition.Name = "grpExcel_Condition";
            this.grpExcel_Condition.Size = new System.Drawing.Size(359, 179);
            this.grpExcel_Condition.TabIndex = 3;
            this.grpExcel_Condition.TabStop = false;
            this.grpExcel_Condition.Text = "&Condition";
            // 
            // chkExcel_Header
            // 
            this.chkExcel_Header.AutoSize = true;
            this.chkExcel_Header.Checked = true;
            this.chkExcel_Header.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExcel_Header.Location = new System.Drawing.Point(30, 27);
            this.chkExcel_Header.Name = "chkExcel_Header";
            this.chkExcel_Header.Size = new System.Drawing.Size(154, 17);
            this.chkExcel_Header.TabIndex = 1;
            this.chkExcel_Header.Text = "Export with column header.";
            this.chkExcel_Header.UseVisualStyleBackColor = true;
            // 
            // pnlExcel_Bottom
            // 
            this.pnlExcel_Bottom.Controls.Add(this.btnExcel_Browse);
            this.pnlExcel_Bottom.Controls.Add(this.lblExcel_Filename);
            this.pnlExcel_Bottom.Controls.Add(this.txtExcel_Filename);
            this.pnlExcel_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlExcel_Bottom.Location = new System.Drawing.Point(5, 126);
            this.pnlExcel_Bottom.Name = "pnlExcel_Bottom";
            this.pnlExcel_Bottom.Size = new System.Drawing.Size(359, 32);
            this.pnlExcel_Bottom.TabIndex = 9;
            // 
            // btnExcel_Browse
            // 
            this.btnExcel_Browse.Location = new System.Drawing.Point(327, 3);
            this.btnExcel_Browse.Name = "btnExcel_Browse";
            this.btnExcel_Browse.Size = new System.Drawing.Size(27, 23);
            this.btnExcel_Browse.TabIndex = 8;
            this.btnExcel_Browse.Text = "...";
            this.btnExcel_Browse.UseVisualStyleBackColor = true;
            this.btnExcel_Browse.Click += new System.EventHandler(this.btnExcel_Browse_Click);
            // 
            // lblExcel_Filename
            // 
            this.lblExcel_Filename.AutoSize = true;
            this.lblExcel_Filename.Location = new System.Drawing.Point(15, 9);
            this.lblExcel_Filename.Name = "lblExcel_Filename";
            this.lblExcel_Filename.Size = new System.Drawing.Size(55, 13);
            this.lblExcel_Filename.TabIndex = 7;
            this.lblExcel_Filename.Text = "Filename :";
            // 
            // txtExcel_Filename
            // 
            this.txtExcel_Filename.Location = new System.Drawing.Point(76, 6);
            this.txtExcel_Filename.Name = "txtExcel_Filename";
            this.txtExcel_Filename.ReadOnly = true;
            this.txtExcel_Filename.Size = new System.Drawing.Size(245, 20);
            this.txtExcel_Filename.TabIndex = 6;
            // 
            // pnlExcel_Finish
            // 
            this.pnlExcel_Finish.Controls.Add(this.chkExcel_OpenFile);
            this.pnlExcel_Finish.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlExcel_Finish.Location = new System.Drawing.Point(5, 158);
            this.pnlExcel_Finish.Name = "pnlExcel_Finish";
            this.pnlExcel_Finish.Size = new System.Drawing.Size(359, 26);
            this.pnlExcel_Finish.TabIndex = 8;
            // 
            // chkExcel_OpenFile
            // 
            this.chkExcel_OpenFile.AutoSize = true;
            this.chkExcel_OpenFile.Checked = true;
            this.chkExcel_OpenFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExcel_OpenFile.Location = new System.Drawing.Point(30, 4);
            this.chkExcel_OpenFile.Name = "chkExcel_OpenFile";
            this.chkExcel_OpenFile.Size = new System.Drawing.Size(171, 17);
            this.chkExcel_OpenFile.TabIndex = 0;
            this.chkExcel_OpenFile.Text = "Open file when export finished.";
            this.chkExcel_OpenFile.UseVisualStyleBackColor = true;
            // 
            // btnCSV
            // 
            this.btnCSV.ContentPanel = this.pnlCSV;
            this.btnCSV.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCSV.Location = new System.Drawing.Point(10, 52);
            this.btnCSV.Name = "btnCSV";
            this.btnCSV.Size = new System.Drawing.Size(119, 38);
            this.btnCSV.TabIndex = 1;
            this.btnCSV.Text = "CSV";
            this.btnCSV.UseVisualStyleBackColor = true;
            // 
            // pnlCSV
            // 
            this.pnlCSV.Controls.Add(this.grpCSV_Condition);
            this.pnlCSV.Controls.Add(this.pnlCSV_Bottom);
            this.pnlCSV.Controls.Add(this.pnlCSV_Finish);
            this.pnlCSV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCSV.Location = new System.Drawing.Point(2, 0);
            this.pnlCSV.Name = "pnlCSV";
            this.pnlCSV.Padding = new System.Windows.Forms.Padding(5, 5, 10, 5);
            this.pnlCSV.Size = new System.Drawing.Size(374, 189);
            this.pnlCSV.TabIndex = 0;
            // 
            // grpCSV_Condition
            // 
            this.grpCSV_Condition.Controls.Add(this.grpCSV_Encoding);
            this.grpCSV_Condition.Controls.Add(this.cboCSV_SplitBy);
            this.grpCSV_Condition.Controls.Add(this.chkCSV_Quote);
            this.grpCSV_Condition.Controls.Add(this.chkCSV_Header);
            this.grpCSV_Condition.Controls.Add(this.label1);
            this.grpCSV_Condition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCSV_Condition.Location = new System.Drawing.Point(5, 5);
            this.grpCSV_Condition.Name = "grpCSV_Condition";
            this.grpCSV_Condition.Size = new System.Drawing.Size(359, 121);
            this.grpCSV_Condition.TabIndex = 2;
            this.grpCSV_Condition.TabStop = false;
            this.grpCSV_Condition.Text = "&Condition";
            // 
            // grpCSV_Encoding
            // 
            this.grpCSV_Encoding.Controls.Add(this.rdoCSV_EncodingUnicode);
            this.grpCSV_Encoding.Controls.Add(this.rdoCSV_EncodingANSI);
            this.grpCSV_Encoding.Location = new System.Drawing.Point(190, 20);
            this.grpCSV_Encoding.Name = "grpCSV_Encoding";
            this.grpCSV_Encoding.Size = new System.Drawing.Size(131, 68);
            this.grpCSV_Encoding.TabIndex = 6;
            this.grpCSV_Encoding.TabStop = false;
            this.grpCSV_Encoding.Text = "&Encoding";
            // 
            // rdoCSV_EncodingUnicode
            // 
            this.rdoCSV_EncodingUnicode.Location = new System.Drawing.Point(22, 41);
            this.rdoCSV_EncodingUnicode.Name = "rdoCSV_EncodingUnicode";
            this.rdoCSV_EncodingUnicode.Size = new System.Drawing.Size(103, 17);
            this.rdoCSV_EncodingUnicode.TabIndex = 1;
            this.rdoCSV_EncodingUnicode.TabStop = true;
            this.rdoCSV_EncodingUnicode.Text = "Unicode";
            this.rdoCSV_EncodingUnicode.UseVisualStyleBackColor = true;
            // 
            // rdoCSV_EncodingANSI
            // 
            this.rdoCSV_EncodingANSI.Location = new System.Drawing.Point(22, 16);
            this.rdoCSV_EncodingANSI.Name = "rdoCSV_EncodingANSI";
            this.rdoCSV_EncodingANSI.Size = new System.Drawing.Size(104, 24);
            this.rdoCSV_EncodingANSI.TabIndex = 0;
            this.rdoCSV_EncodingANSI.TabStop = true;
            this.rdoCSV_EncodingANSI.Text = "ANSI";
            this.rdoCSV_EncodingANSI.UseVisualStyleBackColor = true;
            // 
            // cboCSV_SplitBy
            // 
            this.cboCSV_SplitBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCSV_SplitBy.FormattingEnabled = true;
            this.cboCSV_SplitBy.Location = new System.Drawing.Point(80, 25);
            this.cboCSV_SplitBy.Name = "cboCSV_SplitBy";
            this.cboCSV_SplitBy.Size = new System.Drawing.Size(104, 21);
            this.cboCSV_SplitBy.TabIndex = 3;
            // 
            // chkCSV_Quote
            // 
            this.chkCSV_Quote.AutoSize = true;
            this.chkCSV_Quote.Location = new System.Drawing.Point(30, 85);
            this.chkCSV_Quote.Name = "chkCSV_Quote";
            this.chkCSV_Quote.Size = new System.Drawing.Size(117, 17);
            this.chkCSV_Quote.TabIndex = 2;
            this.chkCSV_Quote.Text = "Fill double quote (\")";
            this.chkCSV_Quote.UseVisualStyleBackColor = true;
            // 
            // chkCSV_Header
            // 
            this.chkCSV_Header.AutoSize = true;
            this.chkCSV_Header.Location = new System.Drawing.Point(30, 55);
            this.chkCSV_Header.Name = "chkCSV_Header";
            this.chkCSV_Header.Size = new System.Drawing.Size(154, 17);
            this.chkCSV_Header.TabIndex = 1;
            this.chkCSV_Header.Text = "Export with column header.";
            this.chkCSV_Header.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Split by :";
            // 
            // pnlCSV_Bottom
            // 
            this.pnlCSV_Bottom.Controls.Add(this.btnCSV_Browse);
            this.pnlCSV_Bottom.Controls.Add(this.lblCSV_Filename);
            this.pnlCSV_Bottom.Controls.Add(this.txtCSV_Filename);
            this.pnlCSV_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCSV_Bottom.Location = new System.Drawing.Point(5, 126);
            this.pnlCSV_Bottom.Name = "pnlCSV_Bottom";
            this.pnlCSV_Bottom.Size = new System.Drawing.Size(359, 32);
            this.pnlCSV_Bottom.TabIndex = 7;
            // 
            // btnCSV_Browse
            // 
            this.btnCSV_Browse.Location = new System.Drawing.Point(327, 3);
            this.btnCSV_Browse.Name = "btnCSV_Browse";
            this.btnCSV_Browse.Size = new System.Drawing.Size(27, 23);
            this.btnCSV_Browse.TabIndex = 5;
            this.btnCSV_Browse.Text = "...";
            this.btnCSV_Browse.UseVisualStyleBackColor = true;
            this.btnCSV_Browse.Click += new System.EventHandler(this.btnCSV_Browse_Click);
            // 
            // lblCSV_Filename
            // 
            this.lblCSV_Filename.AutoSize = true;
            this.lblCSV_Filename.Location = new System.Drawing.Point(15, 9);
            this.lblCSV_Filename.Name = "lblCSV_Filename";
            this.lblCSV_Filename.Size = new System.Drawing.Size(55, 13);
            this.lblCSV_Filename.TabIndex = 4;
            this.lblCSV_Filename.Text = "Filename :";
            // 
            // txtCSV_Filename
            // 
            this.txtCSV_Filename.Location = new System.Drawing.Point(76, 6);
            this.txtCSV_Filename.Name = "txtCSV_Filename";
            this.txtCSV_Filename.ReadOnly = true;
            this.txtCSV_Filename.Size = new System.Drawing.Size(245, 20);
            this.txtCSV_Filename.TabIndex = 3;
            // 
            // pnlCSV_Finish
            // 
            this.pnlCSV_Finish.Controls.Add(this.chkCSV_OpenFile);
            this.pnlCSV_Finish.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCSV_Finish.Location = new System.Drawing.Point(5, 158);
            this.pnlCSV_Finish.Name = "pnlCSV_Finish";
            this.pnlCSV_Finish.Size = new System.Drawing.Size(359, 26);
            this.pnlCSV_Finish.TabIndex = 7;
            // 
            // chkCSV_OpenFile
            // 
            this.chkCSV_OpenFile.AutoSize = true;
            this.chkCSV_OpenFile.Checked = true;
            this.chkCSV_OpenFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCSV_OpenFile.Location = new System.Drawing.Point(30, 4);
            this.chkCSV_OpenFile.Name = "chkCSV_OpenFile";
            this.chkCSV_OpenFile.Size = new System.Drawing.Size(171, 17);
            this.chkCSV_OpenFile.TabIndex = 0;
            this.chkCSV_OpenFile.Text = "Open file when export finished.";
            this.chkCSV_OpenFile.UseVisualStyleBackColor = true;
            // 
            // pnlCondition
            // 
            this.pnlCondition.Controls.Add(this.pnlExcel);
            this.pnlCondition.Controls.Add(this.pnlCSV);
            this.pnlCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCondition.Location = new System.Drawing.Point(139, 0);
            this.pnlCondition.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCondition.Name = "pnlCondition";
            this.pnlCondition.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.pnlCondition.Size = new System.Drawing.Size(376, 189);
            this.pnlCondition.TabIndex = 4;
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.border1);
            this.pnlButton.Controls.Add(this.prgExport);
            this.pnlButton.Controls.Add(this.btnOK);
            this.pnlButton.Controls.Add(this.btnCancel);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButton.Location = new System.Drawing.Point(0, 189);
            this.pnlButton.Margin = new System.Windows.Forms.Padding(0);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(515, 83);
            this.pnlButton.TabIndex = 3;
            // 
            // border1
            // 
            this.border1.BorderLineColor = System.Drawing.SystemColors.ControlDark;
            this.border1.Dock = System.Windows.Forms.DockStyle.Top;
            this.border1.Location = new System.Drawing.Point(0, 0);
            this.border1.Name = "border1";
            this.border1.Size = new System.Drawing.Size(515, 3);
            this.border1.Style = EVOFramework.Windows.Forms.EVOBorder.BorderEdgeStyle.Top;
            this.border1.TabIndex = 9;
            // 
            // prgExport
            // 
            this.prgExport.Location = new System.Drawing.Point(14, 8);
            this.prgExport.Name = "prgExport";
            this.prgExport.Size = new System.Drawing.Size(486, 23);
            this.prgExport.TabIndex = 8;
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(147, 38);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(94, 33);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "      OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(273, 38);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 33);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "       Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ExportDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(515, 272);
            this.Controls.Add(this.pnlCondition);
            this.Controls.Add(this.pnlSelector);
            this.Controls.Add(this.pnlButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ExportDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export By";
            this.Load += new System.EventHandler(this.ScrExportBy_Load);
            this.Shown += new System.EventHandler(this.ScrExportBy_Shown);
            this.pnlSelector.ResumeLayout(false);
            this.pnlExcel.ResumeLayout(false);
            this.grpExcel_Condition.ResumeLayout(false);
            this.grpExcel_Condition.PerformLayout();
            this.pnlExcel_Bottom.ResumeLayout(false);
            this.pnlExcel_Bottom.PerformLayout();
            this.pnlExcel_Finish.ResumeLayout(false);
            this.pnlExcel_Finish.PerformLayout();
            this.pnlCSV.ResumeLayout(false);
            this.grpCSV_Condition.ResumeLayout(false);
            this.grpCSV_Condition.PerformLayout();
            this.grpCSV_Encoding.ResumeLayout(false);
            this.pnlCSV_Bottom.ResumeLayout(false);
            this.pnlCSV_Bottom.PerformLayout();
            this.pnlCSV_Finish.ResumeLayout(false);
            this.pnlCSV_Finish.PerformLayout();
            this.pnlCondition.ResumeLayout(false);
            this.pnlButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel pnlSelector;
        private System.Windows.Forms.Panel pnlCondition;
        private System.Windows.Forms.Panel pnlButton;
        private System.Windows.Forms.Panel pnlCSV;
        private System.Windows.Forms.Panel pnlExcel;
        private System.Windows.Forms.GroupBox grpCSV_Condition;
        private System.Windows.Forms.ComboBox cboCSV_SplitBy;
        private System.Windows.Forms.CheckBox chkCSV_Quote;
        private System.Windows.Forms.CheckBox chkCSV_Header;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpExcel_Condition;
        private System.Windows.Forms.CheckBox chkExcel_Header;
        private System.Windows.Forms.Button btnExcel_Browse;
        private System.Windows.Forms.Label lblExcel_Filename;
        private System.Windows.Forms.TextBox txtExcel_Filename;
        private System.Windows.Forms.Button btnCSV_Browse;
        private System.Windows.Forms.Label lblCSV_Filename;
        private System.Windows.Forms.TextBox txtCSV_Filename;
        private StepButton btnExcel;
        private StepButton btnCSV;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ProgressBar prgExport;
        private System.Windows.Forms.GroupBox grpCSV_Encoding;
        private System.Windows.Forms.RadioButton rdoCSV_EncodingUnicode;
        private System.Windows.Forms.RadioButton rdoCSV_EncodingANSI;
        private System.Windows.Forms.Panel pnlExcel_Bottom;
        private System.Windows.Forms.Panel pnlCSV_Bottom;
        private EVOFramework.Windows.Forms.EVOBorder border1;
        private EVOFramework.Windows.Forms.EVOBorder border2;
        private Panel pnlCSV_Finish;
        private System.Windows.Forms.CheckBox chkCSV_OpenFile;
        private Panel pnlExcel_Finish;
        private System.Windows.Forms.CheckBox chkExcel_OpenFile;
    }
}
