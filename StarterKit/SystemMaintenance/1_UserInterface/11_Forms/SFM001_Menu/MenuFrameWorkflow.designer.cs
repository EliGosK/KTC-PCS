using SystemMaintenance.Forms;
namespace SystemMaintenance.Forms
{
    partial class MenuFrame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuFrame));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitBody = new System.Windows.Forms.SplitContainer();
            this.pnlContainerMenu = new System.Windows.Forms.Panel();
            this.menuTree1 = new SystemMaintenance.Forms.MenuTree();
            this.pnlLeftSideMenu = new System.Windows.Forms.Panel();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblUser = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblUpdateDate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlContainerContent = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlContentWorkflow = new System.Windows.Forms.Panel();
            this.workflowViewer1 = new WorkFlowDiagram.WorkflowViewer();
            this.pnlContentLabel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlContentTask = new System.Windows.Forms.Panel();
            this.flowFavorite = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlScreenPane = new SystemMaintenance.PanelScreenPane();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tblHeader = new System.Windows.Forms.TableLayoutPanel();
            this.picHeaderLogo = new System.Windows.Forms.PictureBox();
            this.pnlHeaderLine = new System.Windows.Forms.Panel();
            this.pcbLogoff = new EVOFramework.Windows.Forms.EVOPictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitBody)).BeginInit();
            this.splitBody.Panel1.SuspendLayout();
            this.splitBody.Panel2.SuspendLayout();
            this.splitBody.SuspendLayout();
            this.pnlContainerMenu.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlContainerContent.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlContentWorkflow.SuspendLayout();
            this.pnlContentLabel.SuspendLayout();
            this.pnlContentTask.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tblHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHeaderLogo)).BeginInit();
            this.pnlHeaderLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLogoff)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 275F));
            this.tableLayoutPanel1.Controls.Add(this.splitBody, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 68);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1016, 666);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // splitBody
            // 
            this.splitBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitBody.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitBody.Location = new System.Drawing.Point(0, 0);
            this.splitBody.Margin = new System.Windows.Forms.Padding(0);
            this.splitBody.Name = "splitBody";
            // 
            // splitBody.Panel1
            // 
            this.splitBody.Panel1.Controls.Add(this.pnlContainerMenu);
            this.splitBody.Panel1MinSize = 13;
            // 
            // splitBody.Panel2
            // 
            this.splitBody.Panel2.Controls.Add(this.pnlContainerContent);
            this.splitBody.Size = new System.Drawing.Size(1016, 666);
            this.splitBody.SplitterDistance = 253;
            this.splitBody.TabIndex = 3;
            // 
            // pnlContainerMenu
            // 
            this.pnlContainerMenu.BackColor = System.Drawing.Color.Transparent;
            this.pnlContainerMenu.Controls.Add(this.menuTree1);
            this.pnlContainerMenu.Controls.Add(this.pnlLeftSideMenu);
            this.pnlContainerMenu.Controls.Add(this.pnlFooter);
            this.pnlContainerMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainerMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlContainerMenu.Margin = new System.Windows.Forms.Padding(0);
            this.pnlContainerMenu.Name = "pnlContainerMenu";
            this.pnlContainerMenu.Size = new System.Drawing.Size(253, 666);
            this.pnlContainerMenu.TabIndex = 8;
            // 
            // menuTree1
            // 
            this.menuTree1.AllowDrop = true;
            this.menuTree1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.menuTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuTree1.Location = new System.Drawing.Point(13, 0);
            this.menuTree1.Margin = new System.Windows.Forms.Padding(0);
            this.menuTree1.MenuBarSelected = null;
            this.menuTree1.Name = "menuTree1";
            this.menuTree1.Size = new System.Drawing.Size(240, 585);
            this.menuTree1.TabIndex = 2;
            this.menuTree1.Text = "menuTree1";
            this.menuTree1.MenuBarSelectedChange += new SystemMaintenance.Forms.MenuTree.MenuBarClickHandler(this.menuTree1_MenuBarSelectedChange);
            this.menuTree1.MenuBarClick += new SystemMaintenance.Forms.MenuTree.MenuBarClickHandler(this.menuTree1_MenuBarClick);
            this.menuTree1.MenuItemClick += new SystemMaintenance.Forms.MenuTree.MenuItemClickHandler(this.menuTree1_MenuItemClick);
            this.menuTree1.MenuItemDown += new SystemMaintenance.Forms.MenuTree.MenuItemDownHandler(this.menuTree1_MenuItemDown);
            this.menuTree1.MenuItemMouseOver += new SystemMaintenance.Forms.MenuTree.MenuItemClickHandler(this.menuTree1_MenuItemMouseOver);
            this.menuTree1.DragDrop += new System.Windows.Forms.DragEventHandler(this.menuTree1_DragDrop);
            this.menuTree1.DragEnter += new System.Windows.Forms.DragEventHandler(this.menuTree1_DragEnter);
            this.menuTree1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.menuTree1_MouseMove);
            this.menuTree1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.menuTree1_MouseUp);
            // 
            // pnlLeftSideMenu
            // 
            this.pnlLeftSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeftSideMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftSideMenu.Margin = new System.Windows.Forms.Padding(0);
            this.pnlLeftSideMenu.Name = "pnlLeftSideMenu";
            this.pnlLeftSideMenu.Size = new System.Drawing.Size(13, 585);
            this.pnlLeftSideMenu.TabIndex = 1;
            this.pnlLeftSideMenu.DoubleClick += new System.EventHandler(this.pnlLeftSideMenu_DoubleClick);
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.pnlFooter.Controls.Add(this.lblUser);
            this.pnlFooter.Controls.Add(this.label6);
            this.pnlFooter.Controls.Add(this.lblUpdateDate);
            this.pnlFooter.Controls.Add(this.label5);
            this.pnlFooter.Controls.Add(this.lblVersion);
            this.pnlFooter.Controls.Add(this.label2);
            this.pnlFooter.Controls.Add(this.label3);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 585);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(0);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(253, 81);
            this.pnlFooter.TabIndex = 0;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.ForeColor = System.Drawing.Color.White;
            this.lblUser.Location = new System.Drawing.Point(79, 50);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(0, 13);
            this.lblUser.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "User";
            // 
            // lblUpdateDate
            // 
            this.lblUpdateDate.AutoSize = true;
            this.lblUpdateDate.ForeColor = System.Drawing.Color.White;
            this.lblUpdateDate.Location = new System.Drawing.Point(79, 35);
            this.lblUpdateDate.Name = "lblUpdateDate";
            this.lblUpdateDate.Size = new System.Drawing.Size(0, 13);
            this.lblUpdateDate.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Upd";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Location = new System.Drawing.Point(79, 20);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(0, 13);
            this.lblVersion.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ver ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Develop By CSI Groups. Tel. 022313851";
            // 
            // pnlContainerContent
            // 
            this.pnlContainerContent.BackColor = System.Drawing.Color.Transparent;
            this.pnlContainerContent.Controls.Add(this.pnlContent);
            this.pnlContainerContent.Controls.Add(this.pnlScreenPane);
            this.pnlContainerContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainerContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContainerContent.Margin = new System.Windows.Forms.Padding(0);
            this.pnlContainerContent.Name = "pnlContainerContent";
            this.pnlContainerContent.Size = new System.Drawing.Size(759, 666);
            this.pnlContainerContent.TabIndex = 7;
            // 
            // pnlContent
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.Controls.Add(this.pnlContentWorkflow);
            this.pnlContent.Controls.Add(this.splitter1);
            this.pnlContent.Controls.Add(this.pnlContentTask);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(759, 666);
            this.pnlContent.TabIndex = 5;
            // 
            // pnlContentWorkflow
            // 
            this.pnlContentWorkflow.Controls.Add(this.workflowViewer1);
            this.pnlContentWorkflow.Controls.Add(this.pnlContentLabel);
            this.pnlContentWorkflow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContentWorkflow.Location = new System.Drawing.Point(0, 0);
            this.pnlContentWorkflow.Name = "pnlContentWorkflow";
            this.pnlContentWorkflow.Size = new System.Drawing.Size(759, 584);
            this.pnlContentWorkflow.TabIndex = 2;
            // 
            // workflowViewer1
            // 
            this.workflowViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workflowViewer1.LineImage = null;
            this.workflowViewer1.Location = new System.Drawing.Point(0, 43);
            this.workflowViewer1.Name = "workflowViewer1";
            this.workflowViewer1.Size = new System.Drawing.Size(759, 541);
            this.workflowViewer1.TabIndex = 2;
            this.workflowViewer1.Text = "workflowViewer1";
            this.workflowViewer1.ButtonLoad += new WorkFlowDiagram.ButtonLoadHandler(this.workflowViewer1_ButtonLoad);
            this.workflowViewer1.ButtonClick += new WorkFlowDiagram.ButtonClickHandler(this.workflowViewer1_ButtonClick);
            // 
            // pnlContentLabel
            // 
            this.pnlContentLabel.BackColor = System.Drawing.Color.Transparent;
            this.pnlContentLabel.Controls.Add(this.label1);
            this.pnlContentLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlContentLabel.Location = new System.Drawing.Point(0, 0);
            this.pnlContentLabel.Name = "pnlContentLabel";
            this.pnlContentLabel.Size = new System.Drawing.Size(759, 43);
            this.pnlContentLabel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(406, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Workflow";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 584);
            this.splitter1.MinExtra = 100;
            this.splitter1.MinSize = 100;
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(759, 5);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // pnlContentTask
            // 
            this.pnlContentTask.AllowDrop = true;
            this.pnlContentTask.AutoScroll = true;
            this.pnlContentTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlContentTask.Controls.Add(this.flowFavorite);
            this.pnlContentTask.Controls.Add(this.label4);
            this.pnlContentTask.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlContentTask.Location = new System.Drawing.Point(0, 589);
            this.pnlContentTask.Margin = new System.Windows.Forms.Padding(0);
            this.pnlContentTask.Name = "pnlContentTask";
            this.pnlContentTask.Size = new System.Drawing.Size(759, 77);
            this.pnlContentTask.TabIndex = 0;
            this.pnlContentTask.DragDrop += new System.Windows.Forms.DragEventHandler(this.flowFavorite_DragDrop);
            this.pnlContentTask.DragEnter += new System.Windows.Forms.DragEventHandler(this.flowFavorite_DragEnter);
            // 
            // flowFavorite
            // 
            this.flowFavorite.AllowDrop = true;
            this.flowFavorite.AutoSize = true;
            this.flowFavorite.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowFavorite.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowFavorite.Location = new System.Drawing.Point(0, 25);
            this.flowFavorite.Name = "flowFavorite";
            this.flowFavorite.Size = new System.Drawing.Size(759, 0);
            this.flowFavorite.TabIndex = 1;
            this.flowFavorite.DragDrop += new System.Windows.Forms.DragEventHandler(this.flowFavorite_DragDrop);
            this.flowFavorite.DragEnter += new System.Windows.Forms.DragEventHandler(this.flowFavorite_DragEnter);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(759, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Favorites";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlScreenPane
            // 
            this.pnlScreenPane.AutoScroll = true;
            this.pnlScreenPane.BackColor = System.Drawing.SystemColors.Control;
            this.pnlScreenPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScreenPane.Location = new System.Drawing.Point(0, 0);
            this.pnlScreenPane.Name = "pnlScreenPane";
            this.pnlScreenPane.Size = new System.Drawing.Size(759, 666);
            this.pnlScreenPane.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tblHeader, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1016, 734);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // tblHeader
            // 
            this.tblHeader.ColumnCount = 2;
            this.tblHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 374F));
            this.tblHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblHeader.Controls.Add(this.picHeaderLogo, 0, 0);
            this.tblHeader.Controls.Add(this.pnlHeaderLine, 1, 0);
            this.tblHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblHeader.Location = new System.Drawing.Point(0, 0);
            this.tblHeader.Margin = new System.Windows.Forms.Padding(0);
            this.tblHeader.Name = "tblHeader";
            this.tblHeader.RowCount = 1;
            this.tblHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tblHeader.Size = new System.Drawing.Size(1016, 68);
            this.tblHeader.TabIndex = 1;
            // 
            // picHeaderLogo
            // 
            this.picHeaderLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picHeaderLogo.Location = new System.Drawing.Point(0, 0);
            this.picHeaderLogo.Margin = new System.Windows.Forms.Padding(0);
            this.picHeaderLogo.Name = "picHeaderLogo";
            this.picHeaderLogo.Size = new System.Drawing.Size(374, 68);
            this.picHeaderLogo.TabIndex = 0;
            this.picHeaderLogo.TabStop = false;
            // 
            // pnlHeaderLine
            // 
            this.pnlHeaderLine.Controls.Add(this.pcbLogoff);
            this.pnlHeaderLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeaderLine.Location = new System.Drawing.Point(374, 0);
            this.pnlHeaderLine.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHeaderLine.Name = "pnlHeaderLine";
            this.pnlHeaderLine.Size = new System.Drawing.Size(642, 68);
            this.pnlHeaderLine.TabIndex = 1;
            // 
            // pcbLogoff
            // 
            this.pcbLogoff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pcbLogoff.ControlID = "";
            this.pcbLogoff.Location = new System.Drawing.Point(596, 25);
            this.pcbLogoff.Name = "pcbLogoff";
            this.pcbLogoff.PathString = null;
            this.pcbLogoff.PathValue = null;
            this.pcbLogoff.Size = new System.Drawing.Size(40, 40);
            this.pcbLogoff.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbLogoff.TabIndex = 4;
            this.pcbLogoff.TabStop = false;
            this.pcbLogoff.Click += new System.EventHandler(this.pcbLogoff_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1016, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLogout});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // mnuLogout
            // 
            this.mnuLogout.Name = "mnuLogout";
            this.mnuLogout.Size = new System.Drawing.Size(107, 22);
            this.mnuLogout.Text = "Logout";
            this.mnuLogout.Click += new System.EventHandler(this.mnuLogout_Click);
            // 
            // MenuFrame
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 200);
            this.Name = "MenuFrame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Inventory Control System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuFrame_FormClosing);
            this.Load += new System.EventHandler(this.MenuFrame_Load);
            this.Shown += new System.EventHandler(this.MenuFrame_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitBody.Panel1.ResumeLayout(false);
            this.splitBody.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitBody)).EndInit();
            this.splitBody.ResumeLayout(false);
            this.pnlContainerMenu.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlContainerContent.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlContentWorkflow.ResumeLayout(false);
            this.pnlContentLabel.ResumeLayout(false);
            this.pnlContentTask.ResumeLayout(false);
            this.pnlContentTask.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tblHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picHeaderLogo)).EndInit();
            this.pnlHeaderLine.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbLogoff)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlContainerMenu;
        private System.Windows.Forms.Panel pnlLeftSideMenu;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel pnlContainerContent;
        private System.Windows.Forms.TableLayoutPanel tblHeader;
        private System.Windows.Forms.PictureBox picHeaderLogo;
        private System.Windows.Forms.Panel pnlHeaderLine;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlContentWorkflow;
        private System.Windows.Forms.Panel pnlContentLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pnlContentTask;
        private System.Windows.Forms.Label label4;
        private WorkFlowDiagram.WorkflowViewer workflowViewer1;
        private MenuTree menuTree1;
        private System.Windows.Forms.FlowLayoutPanel flowFavorite;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuLogout;
        private PanelScreenPane pnlScreenPane;
        private System.Windows.Forms.SplitContainer splitBody;
        private System.Windows.Forms.Label lblUpdateDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblUser;
        private EVOFramework.Windows.Forms.EVOPictureBox pcbLogoff;






    }
}