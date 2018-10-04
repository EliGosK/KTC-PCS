namespace Cube.AFD.Windows.Controls.CalendarControls.Design {
    partial class CalendarEditor {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Overall");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Calendar Header");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Week Header");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Normal Day");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Inactive Day");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Selected Day");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Active Day");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Today Day");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Day Style", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8});
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.trevStyle = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboTheme = new System.Windows.Forms.ComboBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.tpSetting = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rdSContinuous = new System.Windows.Forms.RadioButton();
            this.rdSMerge = new System.Windows.Forms.RadioButton();
            this.rdSSingle = new System.Windows.Forms.RadioButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.rdNo = new System.Windows.Forms.RadioButton();
            this.rdYes = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rdVDefault = new System.Windows.Forms.RadioButton();
            this.rdVForeControl = new System.Windows.Forms.RadioButton();
            this.rdVOwnerDraw = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdMAlway = new System.Windows.Forms.RadioButton();
            this.rdMDisplayWhenEdit = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelEditorPreview = new System.Windows.Forms.Panel();
            this.btnSelectEditor = new System.Windows.Forms.Button();
            this.txtEditorTypeName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.calendarLayoutControl1 = new Cube.AFD.Windows.Controls.CalendarControls.CalendarLayoutControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdCThaiBuddhist = new System.Windows.Forms.RadioButton();
            this.rdCGregorian = new System.Windows.Forms.RadioButton();
            this.rdCRegion = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.chkDoubleClick = new System.Windows.Forms.CheckBox();
            this.chkPressEnter = new System.Windows.Forms.CheckBox();
            this.chkPressF2 = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tpSetting.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(382, 412);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(463, 412);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tpSetting);
            this.tabControl1.Location = new System.Drawing.Point(6, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(539, 400);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.splitter1);
            this.tabPage1.Controls.Add(this.propertyGrid1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(655, 340);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Visual Style";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(288, 334);
            this.panel1.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.trevStyle);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(288, 294);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Calendar Item";
            // 
            // trevStyle
            // 
            this.trevStyle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trevStyle.HideSelection = false;
            this.trevStyle.Location = new System.Drawing.Point(3, 16);
            this.trevStyle.Name = "trevStyle";
            treeNode1.Name = "Node0";
            treeNode1.Text = "Overall";
            treeNode2.Name = "Node1";
            treeNode2.Text = "Calendar Header";
            treeNode3.Name = "Node3";
            treeNode3.Text = "Week Header";
            treeNode4.Name = "Node5";
            treeNode4.Text = "Normal Day";
            treeNode5.Name = "Node7";
            treeNode5.Text = "Inactive Day";
            treeNode6.Name = "Node8";
            treeNode6.Text = "Selected Day";
            treeNode7.Name = "Node9";
            treeNode7.Text = "Active Day";
            treeNode8.Name = "Node10";
            treeNode8.Text = "Today Day";
            treeNode9.Name = "Node4";
            treeNode9.Text = "Day Style";
            this.trevStyle.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode9});
            this.trevStyle.ShowLines = false;
            this.trevStyle.Size = new System.Drawing.Size(282, 275);
            this.trevStyle.TabIndex = 2;
            this.trevStyle.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trevStyle_AfterSelect);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboTheme);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 40);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Themes";
            // 
            // cboTheme
            // 
            this.cboTheme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTheme.FormattingEnabled = true;
            this.cboTheme.Location = new System.Drawing.Point(3, 16);
            this.cboTheme.Name = "cboTheme";
            this.cboTheme.Size = new System.Drawing.Size(282, 21);
            this.cboTheme.TabIndex = 0;
            this.cboTheme.SelectedIndexChanged += new System.EventHandler(this.cboTheme_SelectedIndexChanged);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(291, 3);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 334);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Right;
            this.propertyGrid1.Location = new System.Drawing.Point(294, 3);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.propertyGrid1.Size = new System.Drawing.Size(358, 334);
            this.propertyGrid1.TabIndex = 0;
            this.propertyGrid1.ToolbarVisible = false;
            this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged);
            // 
            // tpSetting
            // 
            this.tpSetting.Controls.Add(this.groupBox6);
            this.tpSetting.Controls.Add(this.groupBox7);
            this.tpSetting.Controls.Add(this.groupBox5);
            this.tpSetting.Controls.Add(this.groupBox4);
            this.tpSetting.Controls.Add(this.groupBox3);
            this.tpSetting.Location = new System.Drawing.Point(4, 22);
            this.tpSetting.Name = "tpSetting";
            this.tpSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tpSetting.Size = new System.Drawing.Size(531, 374);
            this.tpSetting.TabIndex = 1;
            this.tpSetting.Text = "Setting...";
            this.tpSetting.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.rdSContinuous);
            this.groupBox6.Controls.Add(this.rdSMerge);
            this.groupBox6.Controls.Add(this.rdSSingle);
            this.groupBox6.Location = new System.Drawing.Point(202, 13);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(376, 46);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Selection Policy";
            // 
            // rdSContinuous
            // 
            this.rdSContinuous.AutoSize = true;
            this.rdSContinuous.Location = new System.Drawing.Point(138, 19);
            this.rdSContinuous.Name = "rdSContinuous";
            this.rdSContinuous.Size = new System.Drawing.Size(78, 17);
            this.rdSContinuous.TabIndex = 5;
            this.rdSContinuous.TabStop = true;
            this.rdSContinuous.Text = "Continuous";
            this.rdSContinuous.UseVisualStyleBackColor = true;
            // 
            // rdSMerge
            // 
            this.rdSMerge.AutoSize = true;
            this.rdSMerge.Location = new System.Drawing.Point(77, 19);
            this.rdSMerge.Name = "rdSMerge";
            this.rdSMerge.Size = new System.Drawing.Size(55, 17);
            this.rdSMerge.TabIndex = 4;
            this.rdSMerge.TabStop = true;
            this.rdSMerge.Text = "Merge";
            this.rdSMerge.UseVisualStyleBackColor = true;
            // 
            // rdSSingle
            // 
            this.rdSSingle.AutoSize = true;
            this.rdSSingle.Location = new System.Drawing.Point(17, 19);
            this.rdSSingle.Name = "rdSSingle";
            this.rdSSingle.Size = new System.Drawing.Size(54, 17);
            this.rdSSingle.TabIndex = 3;
            this.rdSSingle.TabStop = true;
            this.rdSSingle.Text = "Single";
            this.rdSSingle.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox7.Controls.Add(this.rdNo);
            this.groupBox7.Controls.Add(this.rdYes);
            this.groupBox7.Location = new System.Drawing.Point(12, 269);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(184, 99);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Show Checkbox";
            // 
            // rdNo
            // 
            this.rdNo.AutoSize = true;
            this.rdNo.Location = new System.Drawing.Point(16, 42);
            this.rdNo.Name = "rdNo";
            this.rdNo.Size = new System.Drawing.Size(39, 17);
            this.rdNo.TabIndex = 2;
            this.rdNo.TabStop = true;
            this.rdNo.Text = "No";
            this.rdNo.UseVisualStyleBackColor = true;
            // 
            // rdYes
            // 
            this.rdYes.AutoSize = true;
            this.rdYes.Location = new System.Drawing.Point(16, 19);
            this.rdYes.Name = "rdYes";
            this.rdYes.Size = new System.Drawing.Size(43, 17);
            this.rdYes.TabIndex = 1;
            this.rdYes.TabStop = true;
            this.rdYes.Text = "Yes";
            this.rdYes.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.panel2);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.panel4);
            this.groupBox5.Controls.Add(this.panel3);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.panelEditorPreview);
            this.groupBox5.Controls.Add(this.btnSelectEditor);
            this.groupBox5.Controls.Add(this.txtEditorTypeName);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Location = new System.Drawing.Point(202, 65);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(323, 303);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Day Editor";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel4.Controls.Add(this.rdVDefault);
            this.panel4.Controls.Add(this.rdVForeControl);
            this.panel4.Controls.Add(this.rdVOwnerDraw);
            this.panel4.Location = new System.Drawing.Point(21, 273);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(296, 24);
            this.panel4.TabIndex = 13;
            // 
            // rdVDefault
            // 
            this.rdVDefault.AutoSize = true;
            this.rdVDefault.Location = new System.Drawing.Point(3, 3);
            this.rdVDefault.Name = "rdVDefault";
            this.rdVDefault.Size = new System.Drawing.Size(59, 17);
            this.rdVDefault.TabIndex = 9;
            this.rdVDefault.TabStop = true;
            this.rdVDefault.Text = "Default";
            this.rdVDefault.UseVisualStyleBackColor = true;
            // 
            // rdVForeControl
            // 
            this.rdVForeControl.AutoSize = true;
            this.rdVForeControl.Location = new System.Drawing.Point(68, 3);
            this.rdVForeControl.Name = "rdVForeControl";
            this.rdVForeControl.Size = new System.Drawing.Size(81, 17);
            this.rdVForeControl.TabIndex = 10;
            this.rdVForeControl.TabStop = true;
            this.rdVForeControl.Text = "Fore control";
            this.rdVForeControl.UseVisualStyleBackColor = true;
            // 
            // rdVOwnerDraw
            // 
            this.rdVOwnerDraw.AutoSize = true;
            this.rdVOwnerDraw.Location = new System.Drawing.Point(151, 3);
            this.rdVOwnerDraw.Name = "rdVOwnerDraw";
            this.rdVOwnerDraw.Size = new System.Drawing.Size(82, 17);
            this.rdVOwnerDraw.TabIndex = 11;
            this.rdVOwnerDraw.TabStop = true;
            this.rdVOwnerDraw.Text = "Owner draw";
            this.rdVOwnerDraw.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.Controls.Add(this.rdMAlway);
            this.panel3.Controls.Add(this.rdMDisplayWhenEdit);
            this.panel3.Location = new System.Drawing.Point(21, 230);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(296, 24);
            this.panel3.TabIndex = 12;
            // 
            // rdMAlway
            // 
            this.rdMAlway.AutoSize = true;
            this.rdMAlway.Location = new System.Drawing.Point(3, 3);
            this.rdMAlway.Name = "rdMAlway";
            this.rdMAlway.Size = new System.Drawing.Size(53, 17);
            this.rdMAlway.TabIndex = 6;
            this.rdMAlway.TabStop = true;
            this.rdMAlway.Text = "Alway";
            this.rdMAlway.UseVisualStyleBackColor = true;
            // 
            // rdMDisplayWhenEdit
            // 
            this.rdMDisplayWhenEdit.AutoSize = true;
            this.rdMDisplayWhenEdit.Location = new System.Drawing.Point(68, 3);
            this.rdMDisplayWhenEdit.Name = "rdMDisplayWhenEdit";
            this.rdMDisplayWhenEdit.Size = new System.Drawing.Size(108, 17);
            this.rdMDisplayWhenEdit.TabIndex = 7;
            this.rdMDisplayWhenEdit.TabStop = true;
            this.rdMDisplayWhenEdit.Text = "Display when edit";
            this.rdMDisplayWhenEdit.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "View";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Display Editor Style";
            // 
            // panelEditorPreview
            // 
            this.panelEditorPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEditorPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelEditorPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEditorPreview.Location = new System.Drawing.Point(10, 57);
            this.panelEditorPreview.Name = "panelEditorPreview";
            this.panelEditorPreview.Size = new System.Drawing.Size(304, 109);
            this.panelEditorPreview.TabIndex = 3;
            // 
            // btnSelectEditor
            // 
            this.btnSelectEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectEditor.Location = new System.Drawing.Point(291, 31);
            this.btnSelectEditor.Name = "btnSelectEditor";
            this.btnSelectEditor.Size = new System.Drawing.Size(26, 23);
            this.btnSelectEditor.TabIndex = 2;
            this.btnSelectEditor.Text = "...";
            this.btnSelectEditor.UseVisualStyleBackColor = true;
            this.btnSelectEditor.Click += new System.EventHandler(this.btnSelectEditor_Click);
            // 
            // txtEditorTypeName
            // 
            this.txtEditorTypeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEditorTypeName.Location = new System.Drawing.Point(10, 33);
            this.txtEditorTypeName.Name = "txtEditorTypeName";
            this.txtEditorTypeName.Size = new System.Drawing.Size(275, 20);
            this.txtEditorTypeName.TabIndex = 1;
            this.txtEditorTypeName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEditorTypeName_KeyPress);
            this.txtEditorTypeName.TextChanged += new System.EventHandler(this.txtEditorTypeName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Editor Control";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.calendarLayoutControl1);
            this.groupBox4.Location = new System.Drawing.Point(12, 109);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(184, 154);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Calendar View";
            // 
            // calendarLayoutControl1
            // 
            this.calendarLayoutControl1.LayoutType = Cube.AFD.Windows.Controls.CalendarControls.CalendarLayout.LayoutType.One;
            this.calendarLayoutControl1.Location = new System.Drawing.Point(6, 19);
            this.calendarLayoutControl1.Name = "calendarLayoutControl1";
            this.calendarLayoutControl1.Size = new System.Drawing.Size(172, 129);
            this.calendarLayoutControl1.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdCThaiBuddhist);
            this.groupBox3.Controls.Add(this.rdCGregorian);
            this.groupBox3.Controls.Add(this.rdCRegion);
            this.groupBox3.Location = new System.Drawing.Point(12, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(184, 90);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Calendar Type";
            // 
            // rdCThaiBuddhist
            // 
            this.rdCThaiBuddhist.AutoSize = true;
            this.rdCThaiBuddhist.Location = new System.Drawing.Point(18, 65);
            this.rdCThaiBuddhist.Name = "rdCThaiBuddhist";
            this.rdCThaiBuddhist.Size = new System.Drawing.Size(87, 17);
            this.rdCThaiBuddhist.TabIndex = 2;
            this.rdCThaiBuddhist.TabStop = true;
            this.rdCThaiBuddhist.Text = "ThaiBuddhist";
            this.rdCThaiBuddhist.UseVisualStyleBackColor = true;
            // 
            // rdCGregorian
            // 
            this.rdCGregorian.AutoSize = true;
            this.rdCGregorian.Location = new System.Drawing.Point(18, 42);
            this.rdCGregorian.Name = "rdCGregorian";
            this.rdCGregorian.Size = new System.Drawing.Size(71, 17);
            this.rdCGregorian.TabIndex = 1;
            this.rdCGregorian.TabStop = true;
            this.rdCGregorian.Text = "Gregorian";
            this.rdCGregorian.UseVisualStyleBackColor = true;
            // 
            // rdCRegion
            // 
            this.rdCRegion.AutoSize = true;
            this.rdCRegion.Location = new System.Drawing.Point(18, 19);
            this.rdCRegion.Name = "rdCRegion";
            this.rdCRegion.Size = new System.Drawing.Size(59, 17);
            this.rdCRegion.TabIndex = 0;
            this.rdCRegion.TabStop = true;
            this.rdCRegion.Text = "Region";
            this.rdCRegion.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.chkPressF2);
            this.panel2.Controls.Add(this.chkPressEnter);
            this.panel2.Controls.Add(this.chkDoubleClick);
            this.panel2.Location = new System.Drawing.Point(21, 185);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(296, 24);
            this.panel2.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Display Editor When";
            // 
            // chkDoubleClick
            // 
            this.chkDoubleClick.AutoSize = true;
            this.chkDoubleClick.Location = new System.Drawing.Point(3, 4);
            this.chkDoubleClick.Name = "chkDoubleClick";
            this.chkDoubleClick.Size = new System.Drawing.Size(86, 17);
            this.chkDoubleClick.TabIndex = 0;
            this.chkDoubleClick.Text = "Double Click";
            this.chkDoubleClick.UseVisualStyleBackColor = true;
            // 
            // chkPressEnter
            // 
            this.chkPressEnter.AutoSize = true;
            this.chkPressEnter.Location = new System.Drawing.Point(95, 4);
            this.chkPressEnter.Name = "chkPressEnter";
            this.chkPressEnter.Size = new System.Drawing.Size(90, 17);
            this.chkPressEnter.TabIndex = 1;
            this.chkPressEnter.Text = "Press \"Enter\"";
            this.chkPressEnter.UseVisualStyleBackColor = true;
            // 
            // chkPressF2
            // 
            this.chkPressF2.AutoSize = true;
            this.chkPressF2.Location = new System.Drawing.Point(191, 4);
            this.chkPressF2.Name = "chkPressF2";
            this.chkPressF2.Size = new System.Drawing.Size(77, 17);
            this.chkPressF2.TabIndex = 2;
            this.chkPressF2.Text = "Press \"F2\"";
            this.chkPressF2.UseVisualStyleBackColor = true;
            // 
            // CalendarEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 441);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CalendarEditor";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Calendar Designer";
            this.Load += new System.EventHandler(this.CalendarEditor_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tpSetting.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tpSetting;
        private System.Windows.Forms.TreeView trevStyle;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboTheme;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdCRegion;
        private System.Windows.Forms.RadioButton rdCThaiBuddhist;
        private System.Windows.Forms.RadioButton rdCGregorian;
        private System.Windows.Forms.RadioButton rdNo;
        private System.Windows.Forms.RadioButton rdYes;
        private System.Windows.Forms.RadioButton rdSContinuous;
        private System.Windows.Forms.RadioButton rdSMerge;
        private System.Windows.Forms.RadioButton rdSSingle;
        private CalendarLayoutControl calendarLayoutControl1;
        private System.Windows.Forms.Button btnSelectEditor;
        private System.Windows.Forms.TextBox txtEditorTypeName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelEditorPreview;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdVOwnerDraw;
        private System.Windows.Forms.RadioButton rdVForeControl;
        private System.Windows.Forms.RadioButton rdVDefault;
        private System.Windows.Forms.RadioButton rdMDisplayWhenEdit;
        private System.Windows.Forms.RadioButton rdMAlway;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkPressF2;
        private System.Windows.Forms.CheckBox chkPressEnter;
        private System.Windows.Forms.CheckBox chkDoubleClick;
    }
}