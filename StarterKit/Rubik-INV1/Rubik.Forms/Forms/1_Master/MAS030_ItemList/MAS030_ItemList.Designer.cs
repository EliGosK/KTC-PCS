namespace Rubik.Master
{
    partial class MAS030_ItemList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAS030_ItemList));
            this.txtSearch = new EVOFramework.Windows.Forms.EVOTextBox();
            this.fpItemView = new FarPoint.Win.Spread.FpSpread();
            this.cmsItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shtItemView = new FarPoint.Win.Spread.SheetView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tlpTitle = new System.Windows.Forms.TableLayoutPanel();
            this.tmrAutoComplete = new System.Windows.Forms.Timer(this.components);
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpItemView)).BeginInit();
            this.cmsItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shtItemView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tlpTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.tlpTitle);
            this.pnlContainer.Controls.Add(this.pictureBox1);
            this.pnlContainer.Controls.Add(this.fpItemView);
            this.pnlContainer.Controls.Add(this.txtSearch);
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 10F);
            this.pnlContainer.Size = new System.Drawing.Size(792, 441);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.AppearanceName = "";
            this.txtSearch.AppearanceReadOnlyName = "";
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.ControlID = "";
            this.txtSearch.DisableRestrictChar = true;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.HelpButton = null;
            this.txtSearch.Location = new System.Drawing.Point(44, 50);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PathString = null;
            this.txtSearch.PathValue = "";
            this.txtSearch.Size = new System.Drawing.Size(736, 26);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // fpItemView
            // 
            this.fpItemView.About = "2.5.2015.2005";
            this.fpItemView.AccessibleDescription = "fpItemView, Sheet1";
            this.fpItemView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fpItemView.BackColor = System.Drawing.Color.AliceBlue;
            this.fpItemView.ContextMenuStrip = this.cmsItem;
            this.fpItemView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpItemView.Location = new System.Drawing.Point(10, 82);
            this.fpItemView.Name = "fpItemView";
            this.fpItemView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpItemView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpItemView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtItemView});
            this.fpItemView.Size = new System.Drawing.Size(770, 347);
            this.fpItemView.TabIndex = 3;
            this.fpItemView.TabStop = false;
            this.fpItemView.TextTipDelay = 1000;
            this.fpItemView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpItemView.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpItemView_CellClick);
            this.fpItemView.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpItemView_CellDoubleClick);
            this.fpItemView.AutoFilteredColumn += new FarPoint.Win.Spread.AutoFilteredColumnEventHandler(this.fpItemView_AutoFilteredColumn);
            this.fpItemView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpItemView_KeyDown);
            this.fpItemView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fpItemView_KeyPress);
            this.fpItemView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fpItemView_MouseDown);
            // 
            // cmsItem
            // 
            this.cmsItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cmsItem.Name = "cmsItem";
            this.cmsItem.Size = new System.Drawing.Size(106, 48);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // shtItemView
            // 
            this.shtItemView.Reset();
            this.shtItemView.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtItemView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtItemView.ColumnCount = 97;
            this.shtItemView.RowCount = 0;
            this.shtItemView.AutoCalculation = false;
            this.shtItemView.AutoGenerateColumns = false;
            this.shtItemView.ColumnHeader.Cells.Get(0, 0).Value = "M/N";
            this.shtItemView.ColumnHeader.Cells.Get(0, 1).Value = "Part No.";
            this.shtItemView.ColumnHeader.Cells.Get(0, 2).Value = "Part Name";
            this.shtItemView.ColumnHeader.Cells.Get(0, 3).Value = "Product - Kind Of Product";
            this.shtItemView.ColumnHeader.Cells.Get(0, 4).Value = "Kind Of Product Name";
            this.shtItemView.ColumnHeader.Cells.Get(0, 5).Value = "Product - Customer";
            this.shtItemView.ColumnHeader.Cells.Get(0, 6).Value = "Customer Name";
            this.shtItemView.ColumnHeader.Cells.Get(0, 7).Value = "Product - Customer Use Point";
            this.shtItemView.ColumnHeader.Cells.Get(0, 8).Value = "Product - Weight (gram)";
            this.shtItemView.ColumnHeader.Cells.Get(0, 9).Value = "Product - BOI";
            this.shtItemView.ColumnHeader.Cells.Get(0, 10).Value = "BOI Name";
            this.shtItemView.ColumnHeader.Cells.Get(0, 11).Value = "Product - Production (D/I/DI)";
            this.shtItemView.ColumnHeader.Cells.Get(0, 12).Value = "Production Name DI";
            this.shtItemView.ColumnHeader.Cells.Get(0, 13).Value = "Product - Item Level";
            this.shtItemView.ColumnHeader.Cells.Get(0, 14).Value = "Item Level Name";
            this.shtItemView.ColumnHeader.Cells.Get(0, 15).Value = "Product - Mat. Name";
            this.shtItemView.ColumnHeader.Cells.Get(0, 16).Value = "Product - Mat. Size";
            this.shtItemView.ColumnHeader.Cells.Get(0, 17).Value = "Product - Supplier";
            this.shtItemView.ColumnHeader.Cells.Get(0, 18).Value = "Supplier Name";
            this.shtItemView.ColumnHeader.Cells.Get(0, 19).Value = "Product - Kind Of Mat.";
            this.shtItemView.ColumnHeader.Cells.Get(0, 20).Value = "Kind Of Mat Name";
            this.shtItemView.ColumnHeader.Cells.Get(0, 21).Value = "Product - Mat. D/I";
            this.shtItemView.ColumnHeader.Cells.Get(0, 22).Value = "Mat DI Name";
            this.shtItemView.ColumnHeader.Cells.Get(0, 23).Value = "Product - Remark";
            this.shtItemView.ColumnHeader.Cells.Get(0, 24).Value = "Screw - Kind";
            this.shtItemView.ColumnHeader.Cells.Get(0, 25).Value = "Kind Name";
            this.shtItemView.ColumnHeader.Cells.Get(0, 26).Value = "Screw - Head";
            this.shtItemView.ColumnHeader.Cells.Get(0, 27).Value = "Head Name";
            this.shtItemView.ColumnHeader.Cells.Get(0, 28).Value = "Screw - M";
            this.shtItemView.ColumnHeader.Cells.Get(0, 29).Value = "Screw - L";
            this.shtItemView.ColumnHeader.Cells.Get(0, 30).Value = "Screw - Type";
            this.shtItemView.ColumnHeader.Cells.Get(0, 31).Value = "Type Name";
            this.shtItemView.ColumnHeader.Cells.Get(0, 32).Value = "Screw - Remark1";
            this.shtItemView.ColumnHeader.Cells.Get(0, 33).Value = "Remark1 Name";
            this.shtItemView.ColumnHeader.Cells.Get(0, 34).Value = "Screw - Remark2";
            this.shtItemView.ColumnHeader.Cells.Get(0, 35).Value = "Remark2 Name";
            this.shtItemView.ColumnHeader.Cells.Get(0, 36).Value = "Screw - Hexalobular";
            this.shtItemView.ColumnHeader.Cells.Get(0, 37).Value = "Machine - Process1";
            this.shtItemView.ColumnHeader.Cells.Get(0, 38).Value = "Process1 Name";
            this.shtItemView.ColumnHeader.Cells.Get(0, 39).Value = "Machine - MC Type1";
            this.shtItemView.ColumnHeader.Cells.Get(0, 40).Value = "MC Type1 Name";
            this.shtItemView.ColumnHeader.Cells.Get(0, 41).Value = "Machine - Process2";
            this.shtItemView.ColumnHeader.Cells.Get(0, 42).Value = "Process2 Name";
            this.shtItemView.ColumnHeader.Cells.Get(0, 43).Value = "Machine - MC Type2";
            this.shtItemView.ColumnHeader.Cells.Get(0, 44).Value = "MC Type2 Name";
            this.shtItemView.ColumnHeader.Cells.Get(0, 45).Value = "Machine - Process3";
            this.shtItemView.ColumnHeader.Cells.Get(0, 46).Value = "Process3 Name";
            this.shtItemView.ColumnHeader.Cells.Get(0, 47).Value = "Machine - MC Type3";
            this.shtItemView.ColumnHeader.Cells.Get(0, 48).Value = "MC Type3 Name";
            this.shtItemView.ColumnHeader.Cells.Get(0, 49).Value = "Machine - Process4";
            this.shtItemView.ColumnHeader.Cells.Get(0, 50).Value = "Process4 Name";
            this.shtItemView.ColumnHeader.Cells.Get(0, 51).Value = "Machine - MC Type4";
            this.shtItemView.ColumnHeader.Cells.Get(0, 52).Value = "MC Type4 Name";
            this.shtItemView.ColumnHeader.Cells.Get(0, 53).Value = "Machine - Process5";
            this.shtItemView.ColumnHeader.Cells.Get(0, 54).Value = "Machine - ProcessName5";
            this.shtItemView.ColumnHeader.Cells.Get(0, 55).Value = "Machine - MC Type5";
            this.shtItemView.ColumnHeader.Cells.Get(0, 56).Value = "MC Type5 Name";
            this.shtItemView.ColumnHeader.Cells.Get(0, 57).Value = "Machine - Process6";
            this.shtItemView.ColumnHeader.Cells.Get(0, 58).Value = "Process6 Name";
            this.shtItemView.ColumnHeader.Cells.Get(0, 59).Value = "Machine - MC Type6";
            this.shtItemView.ColumnHeader.Cells.Get(0, 60).Value = "MC Type6 Name";
            this.shtItemView.ColumnHeader.Cells.Get(0, 61).Value = "Heat Treatment - Yes/No";
            this.shtItemView.ColumnHeader.Cells.Get(0, 62).Value = "Heat Treatment - Type";
            this.shtItemView.ColumnHeader.Cells.Get(0, 63).Value = "Type Name";
            this.shtItemView.ColumnHeader.Cells.Get(0, 64).Value = "Heat Treatment - Hardness";
            this.shtItemView.ColumnHeader.Cells.Get(0, 65).Value = "Heat Treatment - Core Hardness";
            this.shtItemView.ColumnHeader.Cells.Get(0, 66).Value = "Heat Treatment - Case Depth Condition";
            this.shtItemView.ColumnHeader.Cells.Get(0, 67).Value = "Plating - Yes / No";
            this.shtItemView.ColumnHeader.Cells.Get(0, 68).Value = "Plating - Kind";
            this.shtItemView.ColumnHeader.Cells.Get(0, 69).Value = "Plating - Supplier";
            this.shtItemView.ColumnHeader.Cells.Get(0, 70).Value = "Supplier Name";
            this.shtItemView.ColumnHeader.Cells.Get(0, 71).Value = "Plating - Thickness1";
            this.shtItemView.ColumnHeader.Cells.Get(0, 72).Value = "Plating - Thickness1";
            this.shtItemView.ColumnHeader.Cells.Get(0, 73).Value = "Plating - Thickness2";
            this.shtItemView.ColumnHeader.Cells.Get(0, 74).Value = "Plating - Thickness2";
            this.shtItemView.ColumnHeader.Cells.Get(0, 75).Value = "Plating - KTC Plating";
            this.shtItemView.ColumnHeader.Cells.Get(0, 76).Value = "KTC Plating Name";
            this.shtItemView.ColumnHeader.Cells.Get(0, 77).Value = "Plating - Baking";
            this.shtItemView.ColumnHeader.Cells.Get(0, 78).Value = "Baking - Time";
            this.shtItemView.ColumnHeader.Cells.Get(0, 79).Value = "Baking Time Name";
            this.shtItemView.ColumnHeader.Cells.Get(0, 80).Value = "Baking - Temp";
            this.shtItemView.ColumnHeader.Cells.Get(0, 81).Value = "Baking Temp Name";
            this.shtItemView.ColumnHeader.Cells.Get(0, 82).Value = "Other Process1 - Yes/No";
            this.shtItemView.ColumnHeader.Cells.Get(0, 83).Value = "Other Process1 - Kind";
            this.shtItemView.ColumnHeader.Cells.Get(0, 84).Value = "Kind Name";
            this.shtItemView.ColumnHeader.Cells.Get(0, 85).Value = "Other Process1 - Condition";
            this.shtItemView.ColumnHeader.Cells.Get(0, 86).Value = "Condition Name";
            this.shtItemView.ColumnHeader.Cells.Get(0, 87).Value = "Other Process2 - Yes/No";
            this.shtItemView.ColumnHeader.Cells.Get(0, 88).Value = "Other Process2 - Kind";
            this.shtItemView.ColumnHeader.Cells.Get(0, 89).Value = "Kind Name";
            this.shtItemView.ColumnHeader.Cells.Get(0, 90).Value = "Other Process2 - Condition";
            this.shtItemView.ColumnHeader.Cells.Get(0, 91).Value = "Condition Name";
            this.shtItemView.ColumnHeader.Cells.Get(0, 92).Value = "Routing";
            this.shtItemView.ColumnHeader.Cells.Get(0, 93).Value = "Product - Create Date";
            this.shtItemView.ColumnHeader.Cells.Get(0, 94).Value = "Product - Create By";
            this.shtItemView.ColumnHeader.Cells.Get(0, 95).Value = "Product - Revise Date";
            this.shtItemView.ColumnHeader.Cells.Get(0, 96).Value = "Product - Revise By";
            this.shtItemView.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtItemView.Columns.Get(0).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(0).AllowAutoSort = true;
            this.shtItemView.Columns.Get(0).Label = "M/N";
            this.shtItemView.Columns.Get(0).Tag = "ITEM_CD";
            this.shtItemView.Columns.Get(0).Width = 122F;
            this.shtItemView.Columns.Get(1).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(1).AllowAutoSort = true;
            this.shtItemView.Columns.Get(1).Label = "Part No.";
            this.shtItemView.Columns.Get(1).StyleName = "FIX";
            this.shtItemView.Columns.Get(1).Tag = "SHORT_NAME";
            this.shtItemView.Columns.Get(1).Width = 140F;
            this.shtItemView.Columns.Get(2).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(2).AllowAutoSort = true;
            this.shtItemView.Columns.Get(2).Label = "Part Name";
            this.shtItemView.Columns.Get(2).Tag = "ITEM_DESC";
            this.shtItemView.Columns.Get(2).Width = 179F;
            this.shtItemView.Columns.Get(3).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(3).AllowAutoSort = true;
            this.shtItemView.Columns.Get(3).Label = "Product - Kind Of Product";
            this.shtItemView.Columns.Get(3).Tag = "PRODUCT_TYPE";
            this.shtItemView.Columns.Get(3).Width = 163F;
            this.shtItemView.Columns.Get(4).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(4).AllowAutoSort = true;
            this.shtItemView.Columns.Get(4).Label = "Kind Of Product Name";
            this.shtItemView.Columns.Get(4).Tag = "";
            this.shtItemView.Columns.Get(4).Width = 89F;
            this.shtItemView.Columns.Get(5).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(5).AllowAutoSort = true;
            this.shtItemView.Columns.Get(5).Label = "Product - Customer";
            this.shtItemView.Columns.Get(5).Tag = "DEALING_CD";
            this.shtItemView.Columns.Get(5).Width = 150F;
            this.shtItemView.Columns.Get(6).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(6).AllowAutoSort = true;
            this.shtItemView.Columns.Get(6).Label = "Customer Name";
            this.shtItemView.Columns.Get(6).Width = 140F;
            this.shtItemView.Columns.Get(7).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(7).AllowAutoSort = true;
            this.shtItemView.Columns.Get(7).Label = "Product - Customer Use Point";
            this.shtItemView.Columns.Get(7).TabStop = true;
            this.shtItemView.Columns.Get(7).Tag = "CUSTOMER_USE_POINT";
            this.shtItemView.Columns.Get(7).Width = 188F;
            this.shtItemView.Columns.Get(8).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(8).AllowAutoSort = true;
            this.shtItemView.Columns.Get(8).Label = "Product - Weight (gram)";
            this.shtItemView.Columns.Get(8).Tag = "Weight";
            this.shtItemView.Columns.Get(8).Width = 100F;
            this.shtItemView.Columns.Get(9).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(9).AllowAutoSort = true;
            this.shtItemView.Columns.Get(9).Label = "Product - BOI";
            this.shtItemView.Columns.Get(9).Tag = "BOI";
            this.shtItemView.Columns.Get(9).Width = 100F;
            this.shtItemView.Columns.Get(10).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(10).AllowAutoSort = true;
            this.shtItemView.Columns.Get(10).Label = "BOI Name";
            this.shtItemView.Columns.Get(10).Width = 85F;
            this.shtItemView.Columns.Get(11).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(11).AllowAutoSort = true;
            this.shtItemView.Columns.Get(11).Label = "Product - Production (D/I/DI)";
            this.shtItemView.Columns.Get(11).Tag = "Production";
            this.shtItemView.Columns.Get(11).Width = 120F;
            this.shtItemView.Columns.Get(12).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(12).AllowAutoSort = true;
            this.shtItemView.Columns.Get(12).Label = "Production Name DI";
            this.shtItemView.Columns.Get(12).Width = 96F;
            this.shtItemView.Columns.Get(13).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(13).AllowAutoSort = true;
            this.shtItemView.Columns.Get(13).Label = "Product - Item Level";
            this.shtItemView.Columns.Get(13).Tag = "Item Level";
            this.shtItemView.Columns.Get(13).Width = 120F;
            this.shtItemView.Columns.Get(14).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(14).AllowAutoSort = true;
            this.shtItemView.Columns.Get(14).Label = "Item Level Name";
            this.shtItemView.Columns.Get(15).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(15).AllowAutoSort = true;
            this.shtItemView.Columns.Get(15).Label = "Product - Mat. Name";
            this.shtItemView.Columns.Get(15).Tag = "Mat. Name";
            this.shtItemView.Columns.Get(15).Width = 135F;
            this.shtItemView.Columns.Get(16).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(16).AllowAutoSort = true;
            this.shtItemView.Columns.Get(16).Label = "Product - Mat. Size";
            this.shtItemView.Columns.Get(16).Tag = "Mat. Size";
            this.shtItemView.Columns.Get(16).Width = 123F;
            this.shtItemView.Columns.Get(17).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(17).AllowAutoSort = true;
            this.shtItemView.Columns.Get(17).Label = "Product - Supplier";
            this.shtItemView.Columns.Get(17).Tag = "Supplier";
            this.shtItemView.Columns.Get(17).Width = 110F;
            this.shtItemView.Columns.Get(18).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(18).AllowAutoSort = true;
            this.shtItemView.Columns.Get(18).Label = "Supplier Name";
            this.shtItemView.Columns.Get(18).Width = 113F;
            this.shtItemView.Columns.Get(19).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(19).AllowAutoSort = true;
            this.shtItemView.Columns.Get(19).Label = "Product - Kind Of Mat.";
            this.shtItemView.Columns.Get(19).Tag = "Kind Of Mat.";
            this.shtItemView.Columns.Get(19).Width = 143F;
            this.shtItemView.Columns.Get(20).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(20).AllowAutoSort = true;
            this.shtItemView.Columns.Get(20).Label = "Kind Of Mat Name";
            this.shtItemView.Columns.Get(20).Width = 134F;
            this.shtItemView.Columns.Get(21).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(21).AllowAutoSort = true;
            this.shtItemView.Columns.Get(21).Label = "Product - Mat. D/I";
            this.shtItemView.Columns.Get(21).Tag = "Mat. D/I";
            this.shtItemView.Columns.Get(21).Width = 121F;
            this.shtItemView.Columns.Get(22).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(22).AllowAutoSort = true;
            this.shtItemView.Columns.Get(22).Label = "Mat DI Name";
            this.shtItemView.Columns.Get(23).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(23).AllowAutoSort = true;
            this.shtItemView.Columns.Get(23).Label = "Product - Remark";
            this.shtItemView.Columns.Get(23).Tag = "Remark";
            this.shtItemView.Columns.Get(23).Width = 100F;
            this.shtItemView.Columns.Get(24).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(24).AllowAutoSort = true;
            this.shtItemView.Columns.Get(24).Label = "Screw - Kind";
            this.shtItemView.Columns.Get(24).Tag = "SCREW_KIND";
            this.shtItemView.Columns.Get(24).Width = 150F;
            this.shtItemView.Columns.Get(25).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(25).AllowAutoSort = true;
            this.shtItemView.Columns.Get(25).Label = "Kind Name";
            this.shtItemView.Columns.Get(25).Width = 133F;
            this.shtItemView.Columns.Get(26).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(26).AllowAutoSort = true;
            this.shtItemView.Columns.Get(26).Label = "Screw - Head";
            this.shtItemView.Columns.Get(26).Tag = "SCREW_HEAD";
            this.shtItemView.Columns.Get(26).Width = 150F;
            this.shtItemView.Columns.Get(27).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(27).AllowAutoSort = true;
            this.shtItemView.Columns.Get(27).Label = "Head Name";
            this.shtItemView.Columns.Get(27).Width = 94F;
            this.shtItemView.Columns.Get(28).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(28).AllowAutoSort = true;
            this.shtItemView.Columns.Get(28).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.shtItemView.Columns.Get(28).Label = "Screw - M";
            this.shtItemView.Columns.Get(28).Locked = false;
            this.shtItemView.Columns.Get(28).Tag = "SCREW_M";
            this.shtItemView.Columns.Get(28).Width = 150F;
            this.shtItemView.Columns.Get(29).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(29).AllowAutoSort = true;
            this.shtItemView.Columns.Get(29).Label = "Screw - L";
            this.shtItemView.Columns.Get(29).Tag = "SCREW_L";
            this.shtItemView.Columns.Get(29).Width = 150F;
            this.shtItemView.Columns.Get(30).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(30).AllowAutoSort = true;
            this.shtItemView.Columns.Get(30).Label = "Screw - Type";
            this.shtItemView.Columns.Get(30).Tag = "SCREW_TYPE";
            this.shtItemView.Columns.Get(30).Width = 150F;
            this.shtItemView.Columns.Get(31).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(31).AllowAutoSort = true;
            this.shtItemView.Columns.Get(31).Label = "Type Name";
            this.shtItemView.Columns.Get(31).Width = 115F;
            this.shtItemView.Columns.Get(32).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(32).AllowAutoSort = true;
            this.shtItemView.Columns.Get(32).Label = "Screw - Remark1";
            this.shtItemView.Columns.Get(32).Tag = "SCREW_REMARK";
            this.shtItemView.Columns.Get(32).Width = 120F;
            this.shtItemView.Columns.Get(33).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(33).AllowAutoSort = true;
            this.shtItemView.Columns.Get(33).Label = "Remark1 Name";
            this.shtItemView.Columns.Get(33).Width = 116F;
            this.shtItemView.Columns.Get(34).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(34).AllowAutoSort = true;
            this.shtItemView.Columns.Get(34).Label = "Screw - Remark2";
            this.shtItemView.Columns.Get(34).Tag = "Remark2";
            this.shtItemView.Columns.Get(34).Width = 120F;
            this.shtItemView.Columns.Get(35).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(35).AllowAutoSort = true;
            this.shtItemView.Columns.Get(35).Label = "Remark2 Name";
            this.shtItemView.Columns.Get(35).Width = 114F;
            this.shtItemView.Columns.Get(36).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(36).AllowAutoSort = true;
            this.shtItemView.Columns.Get(36).Label = "Screw - Hexalobular";
            this.shtItemView.Columns.Get(36).Tag = "Hexalobular";
            this.shtItemView.Columns.Get(36).Width = 144F;
            this.shtItemView.Columns.Get(37).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(37).AllowAutoSort = true;
            this.shtItemView.Columns.Get(37).Label = "Machine - Process1";
            this.shtItemView.Columns.Get(37).Tag = "PROCESS1";
            this.shtItemView.Columns.Get(37).Width = 113F;
            this.shtItemView.Columns.Get(38).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(38).AllowAutoSort = true;
            this.shtItemView.Columns.Get(38).Label = "Process1 Name";
            this.shtItemView.Columns.Get(38).Width = 95F;
            this.shtItemView.Columns.Get(39).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(39).AllowAutoSort = true;
            this.shtItemView.Columns.Get(39).Label = "Machine - MC Type1";
            this.shtItemView.Columns.Get(39).Tag = "MACHINE_TYPE1";
            this.shtItemView.Columns.Get(39).Width = 123F;
            this.shtItemView.Columns.Get(40).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(40).AllowAutoSort = true;
            this.shtItemView.Columns.Get(40).Label = "MC Type1 Name";
            this.shtItemView.Columns.Get(40).Width = 111F;
            this.shtItemView.Columns.Get(41).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(41).AllowAutoSort = true;
            this.shtItemView.Columns.Get(41).Label = "Machine - Process2";
            this.shtItemView.Columns.Get(41).Tag = "PROCESS2";
            this.shtItemView.Columns.Get(41).Width = 100F;
            this.shtItemView.Columns.Get(42).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(42).AllowAutoSort = true;
            this.shtItemView.Columns.Get(42).Label = "Process2 Name";
            this.shtItemView.Columns.Get(42).Width = 121F;
            this.shtItemView.Columns.Get(43).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(43).AllowAutoSort = true;
            this.shtItemView.Columns.Get(43).Label = "Machine - MC Type2";
            this.shtItemView.Columns.Get(43).Tag = "MACHINE_TYPE2";
            this.shtItemView.Columns.Get(43).Width = 120F;
            this.shtItemView.Columns.Get(44).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(44).AllowAutoSort = true;
            this.shtItemView.Columns.Get(44).Label = "MC Type2 Name";
            this.shtItemView.Columns.Get(44).Width = 133F;
            this.shtItemView.Columns.Get(45).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(45).AllowAutoSort = true;
            this.shtItemView.Columns.Get(45).Label = "Machine - Process3";
            this.shtItemView.Columns.Get(45).Tag = "PROCESS3";
            this.shtItemView.Columns.Get(45).Width = 99F;
            this.shtItemView.Columns.Get(46).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(46).AllowAutoSort = true;
            this.shtItemView.Columns.Get(46).Label = "Process3 Name";
            this.shtItemView.Columns.Get(46).Width = 104F;
            this.shtItemView.Columns.Get(47).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(47).AllowAutoSort = true;
            this.shtItemView.Columns.Get(47).Label = "Machine - MC Type3";
            this.shtItemView.Columns.Get(47).Tag = "MACHINE_TYPE3";
            this.shtItemView.Columns.Get(47).Width = 103F;
            this.shtItemView.Columns.Get(48).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(48).AllowAutoSort = true;
            this.shtItemView.Columns.Get(48).Label = "MC Type3 Name";
            this.shtItemView.Columns.Get(48).Width = 94F;
            this.shtItemView.Columns.Get(49).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(49).AllowAutoSort = true;
            this.shtItemView.Columns.Get(49).Label = "Machine - Process4";
            this.shtItemView.Columns.Get(49).Tag = "PROCESS4";
            this.shtItemView.Columns.Get(49).Width = 108F;
            this.shtItemView.Columns.Get(50).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(50).AllowAutoSort = true;
            this.shtItemView.Columns.Get(50).Label = "Process4 Name";
            this.shtItemView.Columns.Get(50).Width = 117F;
            this.shtItemView.Columns.Get(51).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(51).AllowAutoSort = true;
            this.shtItemView.Columns.Get(51).Label = "Machine - MC Type4";
            this.shtItemView.Columns.Get(51).Tag = "MACHINE_TYPE4";
            this.shtItemView.Columns.Get(51).Width = 102F;
            this.shtItemView.Columns.Get(52).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(52).AllowAutoSort = true;
            this.shtItemView.Columns.Get(52).Label = "MC Type4 Name";
            this.shtItemView.Columns.Get(52).Width = 100F;
            this.shtItemView.Columns.Get(53).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(53).AllowAutoSort = true;
            this.shtItemView.Columns.Get(53).Label = "Machine - Process5";
            this.shtItemView.Columns.Get(53).Tag = "PROCESS5";
            this.shtItemView.Columns.Get(53).Width = 96F;
            this.shtItemView.Columns.Get(54).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(54).AllowAutoSort = true;
            this.shtItemView.Columns.Get(54).Label = "Machine - ProcessName5";
            this.shtItemView.Columns.Get(54).Width = 125F;
            this.shtItemView.Columns.Get(55).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(55).AllowAutoSort = true;
            this.shtItemView.Columns.Get(55).Label = "Machine - MC Type5";
            this.shtItemView.Columns.Get(55).Tag = "MACHINE_TYPE5";
            this.shtItemView.Columns.Get(55).Width = 103F;
            this.shtItemView.Columns.Get(56).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(56).AllowAutoSort = true;
            this.shtItemView.Columns.Get(56).Label = "MC Type5 Name";
            this.shtItemView.Columns.Get(57).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(57).AllowAutoSort = true;
            this.shtItemView.Columns.Get(57).Label = "Machine - Process6";
            this.shtItemView.Columns.Get(57).Tag = "PROCESS6";
            this.shtItemView.Columns.Get(57).Width = 96F;
            this.shtItemView.Columns.Get(58).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(58).AllowAutoSort = true;
            this.shtItemView.Columns.Get(58).Label = "Process6 Name";
            this.shtItemView.Columns.Get(59).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(59).AllowAutoSort = true;
            this.shtItemView.Columns.Get(59).Label = "Machine - MC Type6";
            this.shtItemView.Columns.Get(59).Tag = "MACHINE_TYPE6";
            this.shtItemView.Columns.Get(59).Width = 101F;
            this.shtItemView.Columns.Get(60).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(60).AllowAutoSort = true;
            this.shtItemView.Columns.Get(60).Label = "MC Type6 Name";
            this.shtItemView.Columns.Get(61).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(61).AllowAutoSort = true;
            this.shtItemView.Columns.Get(61).Label = "Heat Treatment - Yes/No";
            this.shtItemView.Columns.Get(61).Width = 148F;
            this.shtItemView.Columns.Get(62).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(62).AllowAutoSort = true;
            this.shtItemView.Columns.Get(62).Label = "Heat Treatment - Type";
            this.shtItemView.Columns.Get(62).Locked = false;
            this.shtItemView.Columns.Get(62).Tag = "HARDING_KIND";
            this.shtItemView.Columns.Get(62).Width = 132F;
            this.shtItemView.Columns.Get(63).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(63).AllowAutoSort = true;
            this.shtItemView.Columns.Get(63).Label = "Type Name";
            this.shtItemView.Columns.Get(63).Width = 103F;
            this.shtItemView.Columns.Get(64).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(64).AllowAutoSort = true;
            this.shtItemView.Columns.Get(64).Label = "Heat Treatment - Hardness";
            this.shtItemView.Columns.Get(64).Tag = "HARDING_SURFACE";
            this.shtItemView.Columns.Get(64).Width = 150F;
            this.shtItemView.Columns.Get(65).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(65).AllowAutoSort = true;
            this.shtItemView.Columns.Get(65).Label = "Heat Treatment - Core Hardness";
            this.shtItemView.Columns.Get(65).Tag = "HARDING_CORE";
            this.shtItemView.Columns.Get(65).Width = 150F;
            this.shtItemView.Columns.Get(66).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(66).AllowAutoSort = true;
            this.shtItemView.Columns.Get(66).Label = "Heat Treatment - Case Depth Condition";
            this.shtItemView.Columns.Get(66).Tag = "HARDING_DEPTH";
            this.shtItemView.Columns.Get(66).Width = 150F;
            this.shtItemView.Columns.Get(67).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(67).AllowAutoSort = true;
            this.shtItemView.Columns.Get(67).Label = "Plating - Yes / No";
            this.shtItemView.Columns.Get(67).Tag = "Plating";
            this.shtItemView.Columns.Get(67).Width = 110F;
            this.shtItemView.Columns.Get(68).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(68).AllowAutoSort = true;
            this.shtItemView.Columns.Get(68).Label = "Plating - Kind";
            this.shtItemView.Columns.Get(68).Tag = "PLATING_KIND";
            this.shtItemView.Columns.Get(68).Width = 150F;
            this.shtItemView.Columns.Get(69).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(69).AllowAutoSort = true;
            this.shtItemView.Columns.Get(69).Label = "Plating - Supplier";
            this.shtItemView.Columns.Get(69).Tag = "Supplier";
            this.shtItemView.Columns.Get(69).Width = 114F;
            this.shtItemView.Columns.Get(70).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(70).AllowAutoSort = true;
            this.shtItemView.Columns.Get(70).Label = "Supplier Name";
            this.shtItemView.Columns.Get(70).Width = 85F;
            this.shtItemView.Columns.Get(71).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(71).AllowAutoSort = true;
            this.shtItemView.Columns.Get(71).Label = "Plating - Thickness1";
            this.shtItemView.Columns.Get(71).Tag = "PLATING_THICKNESS";
            this.shtItemView.Columns.Get(71).Width = 130F;
            this.shtItemView.Columns.Get(72).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(72).AllowAutoSort = true;
            this.shtItemView.Columns.Get(72).Label = "Plating - Thickness1";
            this.shtItemView.Columns.Get(72).Tag = "- Thickness1";
            this.shtItemView.Columns.Get(72).Width = 153F;
            this.shtItemView.Columns.Get(73).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(73).AllowAutoSort = true;
            this.shtItemView.Columns.Get(73).Label = "Plating - Thickness2";
            this.shtItemView.Columns.Get(73).Tag = "Thickness2";
            this.shtItemView.Columns.Get(73).Width = 130F;
            this.shtItemView.Columns.Get(74).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(74).AllowAutoSort = true;
            this.shtItemView.Columns.Get(74).Label = "Plating - Thickness2";
            this.shtItemView.Columns.Get(74).Locked = true;
            this.shtItemView.Columns.Get(74).Tag = "- Thickness2";
            this.shtItemView.Columns.Get(74).Width = 139F;
            this.shtItemView.Columns.Get(75).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(75).AllowAutoSort = true;
            this.shtItemView.Columns.Get(75).Label = "Plating - KTC Plating";
            this.shtItemView.Columns.Get(75).Tag = "KTC Plating";
            this.shtItemView.Columns.Get(75).Width = 131F;
            this.shtItemView.Columns.Get(76).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(76).AllowAutoSort = true;
            this.shtItemView.Columns.Get(76).Label = "KTC Plating Name";
            this.shtItemView.Columns.Get(77).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(77).AllowAutoSort = true;
            this.shtItemView.Columns.Get(77).Label = "Plating - Baking";
            this.shtItemView.Columns.Get(77).Tag = "BAKING";
            this.shtItemView.Columns.Get(77).Width = 150F;
            this.shtItemView.Columns.Get(78).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(78).AllowAutoSort = true;
            this.shtItemView.Columns.Get(78).Label = "Baking - Time";
            this.shtItemView.Columns.Get(78).Tag = "Baking Time";
            this.shtItemView.Columns.Get(78).Width = 128F;
            this.shtItemView.Columns.Get(79).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(79).AllowAutoSort = true;
            this.shtItemView.Columns.Get(79).Label = "Baking Time Name";
            this.shtItemView.Columns.Get(80).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(80).AllowAutoSort = true;
            this.shtItemView.Columns.Get(80).Label = "Baking - Temp";
            this.shtItemView.Columns.Get(80).Tag = "Baking Temp";
            this.shtItemView.Columns.Get(80).Width = 96F;
            this.shtItemView.Columns.Get(81).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(81).AllowAutoSort = true;
            this.shtItemView.Columns.Get(81).Label = "Baking Temp Name";
            this.shtItemView.Columns.Get(82).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(82).AllowAutoSort = true;
            this.shtItemView.Columns.Get(82).Label = "Other Process1 - Yes/No";
            this.shtItemView.Columns.Get(82).Tag = "BOI";
            this.shtItemView.Columns.Get(82).Width = 130F;
            this.shtItemView.Columns.Get(83).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(83).AllowAutoSort = true;
            this.shtItemView.Columns.Get(83).Label = "Other Process1 - Kind";
            this.shtItemView.Columns.Get(83).Tag = "Kind";
            this.shtItemView.Columns.Get(83).Width = 133F;
            this.shtItemView.Columns.Get(84).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(84).AllowAutoSort = true;
            this.shtItemView.Columns.Get(84).Label = "Kind Name";
            this.shtItemView.Columns.Get(85).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(85).AllowAutoSort = true;
            this.shtItemView.Columns.Get(85).Label = "Other Process1 - Condition";
            this.shtItemView.Columns.Get(85).Tag = "Condition";
            this.shtItemView.Columns.Get(85).Width = 130F;
            this.shtItemView.Columns.Get(86).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(86).AllowAutoSort = true;
            this.shtItemView.Columns.Get(86).Label = "Condition Name";
            this.shtItemView.Columns.Get(87).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(87).AllowAutoSort = true;
            this.shtItemView.Columns.Get(87).Label = "Other Process2 - Yes/No";
            this.shtItemView.Columns.Get(87).Tag = "Other Process2";
            this.shtItemView.Columns.Get(87).Width = 130F;
            this.shtItemView.Columns.Get(88).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(88).AllowAutoSort = true;
            this.shtItemView.Columns.Get(88).Label = "Other Process2 - Kind";
            this.shtItemView.Columns.Get(88).TabStop = true;
            this.shtItemView.Columns.Get(88).Tag = "Kind";
            this.shtItemView.Columns.Get(88).Width = 130F;
            this.shtItemView.Columns.Get(89).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(89).AllowAutoSort = true;
            this.shtItemView.Columns.Get(89).Label = "Kind Name";
            this.shtItemView.Columns.Get(90).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(90).AllowAutoSort = true;
            this.shtItemView.Columns.Get(90).Label = "Other Process2 - Condition";
            this.shtItemView.Columns.Get(90).Tag = "Condition";
            this.shtItemView.Columns.Get(90).Width = 130F;
            this.shtItemView.Columns.Get(91).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(91).AllowAutoSort = true;
            this.shtItemView.Columns.Get(91).Label = "Condition Name";
            this.shtItemView.Columns.Get(92).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(92).AllowAutoSort = true;
            this.shtItemView.Columns.Get(92).Label = "Routing";
            this.shtItemView.Columns.Get(92).Tag = "Routing";
            this.shtItemView.Columns.Get(92).Width = 150F;
            this.shtItemView.Columns.Get(93).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(93).AllowAutoSort = true;
            this.shtItemView.Columns.Get(93).Label = "Product - Create Date";
            this.shtItemView.Columns.Get(93).Tag = "Product - Create Date";
            this.shtItemView.Columns.Get(93).Width = 119F;
            this.shtItemView.Columns.Get(94).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(94).AllowAutoSort = true;
            this.shtItemView.Columns.Get(94).Label = "Product - Create By";
            this.shtItemView.Columns.Get(94).Tag = "Product - Create By";
            this.shtItemView.Columns.Get(94).Width = 119F;
            this.shtItemView.Columns.Get(95).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(95).AllowAutoSort = true;
            this.shtItemView.Columns.Get(95).Label = "Product - Revise Date";
            this.shtItemView.Columns.Get(95).Tag = "Product - Revise Date";
            this.shtItemView.Columns.Get(95).Width = 119F;
            this.shtItemView.Columns.Get(96).AllowAutoFilter = true;
            this.shtItemView.Columns.Get(96).AllowAutoSort = true;
            this.shtItemView.Columns.Get(96).Label = "Product - Revise By";
            this.shtItemView.Columns.Get(96).Tag = "Product - Revise By";
            this.shtItemView.Columns.Get(96).Width = 119F;
            this.shtItemView.DataAutoCellTypes = false;
            this.shtItemView.DataAutoHeadings = false;
            this.shtItemView.DataAutoSizeColumns = false;
            this.shtItemView.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.shtItemView.RowHeader.Columns.Default.Resizable = true;
            this.shtItemView.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.shtItemView.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.shtItemView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpItemView.SetActiveViewport(0, 1, 0);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Rubik.Forms.Properties.Resources.FIND_TEXT;
            this.pictureBox1.Location = new System.Drawing.Point(6, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 39);
            this.label1.TabIndex = 35;
            this.label1.Text = "Master No. List";
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
            this.tlpTitle.Size = new System.Drawing.Size(792, 44);
            this.tlpTitle.TabIndex = 44;
            // 
            // tmrAutoComplete
            // 
            this.tmrAutoComplete.Tick += new System.EventHandler(this.tmrAutoComplete_Tick);
            // 
            // MAS030_ItemList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(792, 466);
            this.ExportObject = this.fpItemView;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MAS030_ItemList";
            this.Text = "Master No. List";
            this.Load += new System.EventHandler(this.MAS030_ItemList_Load);
            this.Shown += new System.EventHandler(this.MAS030_ItemList_Shown);
            this.Controls.SetChildIndex(this.pnlContainer, 0);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpItemView)).EndInit();
            this.cmsItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shtItemView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tlpTitle.ResumeLayout(false);
            this.tlpTitle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EVOFramework.Windows.Forms.EVOTextBox txtSearch;
        private FarPoint.Win.Spread.FpSpread fpItemView;
        private FarPoint.Win.Spread.SheetView shtItemView;
        private System.Windows.Forms.ContextMenuStrip cmsItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tlpTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer tmrAutoComplete;
    }
}
