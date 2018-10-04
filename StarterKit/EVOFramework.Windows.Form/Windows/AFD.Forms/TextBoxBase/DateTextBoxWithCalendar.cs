using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace EVOFramework.Windows.Forms
{
    [ToolboxItem(false)]
    public class DateTextBoxWithCalendar : System.Windows.Forms.UserControl, IReadOnly
    {
		[DllImport("USER32.DLL", EntryPoint="SendMessageW",  SetLastError=true,
			 CharSet=CharSet.Unicode, ExactSpelling=true,
			 CallingConvention=CallingConvention.StdCall)]
			//		public static extern long SendMessage(IntPtr hwnd , long wMsg, IntPtr wParam, IntPtr lParam);
		private static extern long SendMessage(IntPtr Handle, Int32 msg, IntPtr wParam, IntPtr lParam);

		private const int WM_KEYDOWN = 0x0100;

		// Comment by Nontawat L. [15-Sep-2008] ให้ไปใช้ Const ใน DateTextBox แทน
        //private const string YEAR = "yyyy";
        //private const string MONTH = "MM";
        //private const string DAY = "dd";
        //private const string HOUR = "HH";
        //private const string MINUTE = "mm";
        //private const string SECOND = "ss";
        //private const string MILLISECOND = "fff";

        // Constant
		private  static Calendar frmCalendar;
		const int SPACE_BEFORE_BUTTON = 2;
		
		private bool m_bShowButton = true;
		
		private System.Windows.Forms.Button btnCallCalendar;
		public DateTextBox dtb;
	
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public event System.EventHandler ValueChanged;

        public event System.EventHandler CalendarDateChanged;
		//		public event System.EventHandler DateTextChanged;

		public DateTextBoxWithCalendar() {
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			dtb.Location = new Point(0,0);
			btnCallCalendar.Location = new Point(dtb.Width+ SPACE_BEFORE_BUTTON,0);
			this.Width = dtb.Width + SPACE_BEFORE_BUTTON + btnCallCalendar.Width;

            btnCallCalendar.Height = dtb.Height;

			dtb.DateValue = System.DateTime.Now;
			btnCallCalendar.Visible = m_bShowButton;

			//Add By : Mr. Boonlert F. 1/12/2005
			dtb.KeyDown += new KeyEventHandler(this.On_KeyDown);
			dtb.KeyUp += new KeyEventHandler(this.On_KeyUp);
		    dtb.KeyPress += new KeyPressEventHandler(this.On_KeyPress);      
      
            this.UpdateBounds();
		}

		//Add By : Mr. Boonlert F. 1/12/2005
		private void On_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e) {                                                            
			base.OnKeyDown(e);
		}

		private void On_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e){
			base.OnKeyUp(e);
		}

		private void On_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e){
			base.OnKeyPress(e);
		}

		/// <summary>
		/// For set visible button.
		/// </summary>
		public bool ShowButton{
			get{
				return m_bShowButton;
			}
			set{
				m_bShowButton = value;
				btnCallCalendar.Visible = m_bShowButton;
                if (!m_bShowButton)
                    dtb.Width = this.Width;
                else
                {
                    dtb.Width = this.Width - btnCallCalendar.Width - 1;                    
                }
			}
		}

        public Button CalendarButton
        {
            get { return btnCallCalendar;}
        }
		
		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.dtb = new EVOFramework.Windows.Forms.DateTextBox();
            this.btnCallCalendar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtb
            // 
            this.dtb.DateValue = null;
            this.dtb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtb.Format = "dd/MM/yyyy";
            this.dtb.Location = new System.Drawing.Point(0, 0);
            this.dtb.Mask = "00/00/0000";
            this.dtb.MaxDateTime = new System.DateTime(9998, 12, 31, 23, 59, 59, 999);
            this.dtb.MinDateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtb.Name = "dtb";
            this.dtb.Size = new System.Drawing.Size(74, 20);
            this.dtb.TabIndex = 0;
            this.dtb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtb.ValueChanged += new System.EventHandler(this.dtb_ValueChanged);
            // 
            // btnCallCalendar
            // 
            this.btnCallCalendar.AutoSize = true;
            this.btnCallCalendar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCallCalendar.Location = new System.Drawing.Point(74, 0);
            this.btnCallCalendar.Name = "btnCallCalendar";
            this.btnCallCalendar.Size = new System.Drawing.Size(26, 22);
            this.btnCallCalendar.TabIndex = 1;
            this.btnCallCalendar.TabStop = false;
            this.btnCallCalendar.Text = "...";
            this.btnCallCalendar.Click += new System.EventHandler(this.btnCallCalendar_Click);
            // 
            // DateTextBoxWithCalendar
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.dtb);
            this.Controls.Add(this.btnCallCalendar);
            this.MinimumSize = new System.Drawing.Size(100, 0);
            this.Name = "DateTextBoxWithCalendar";
            this.Size = new System.Drawing.Size(100, 22);
            this.Resize += new System.EventHandler(this.DateTextBoxWithCalendar_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		
	
		private void btnCallCalendar_Click(object sender, System.EventArgs e) {
            //if(dtb.Text.Trim()==""){            // Modified by Nontawat L. [ 15-Sep-2008 Purpose : Fix bug. ]
            if(dtb.DateValue == null){
				if(frmCalendar == null) frmCalendar = new Calendar(System.DateTime.Now);
				frmCalendar.Date = System.DateTime.Now;

			}else{
				DateTime dtDate = Convert.ToDateTime(dtb.DateValue); 
				if(frmCalendar == null) frmCalendar = new Calendar(dtDate);
				frmCalendar.Date = dtDate;
			}
			frmCalendar.dHandle +=new Calendar.MyHandler(this.frmCalendar_handle1);
			
			Point p;
			int X = 0, Y = 0;
			if (MousePosition.Y + frmCalendar.Size.Height <= Screen.PrimaryScreen.WorkingArea.Height)
				Y = 0 + this.Size.Height;
			else
				Y = 0 - frmCalendar.Size.Height;

			if (MousePosition.X + frmCalendar.Size.Width > Screen.PrimaryScreen.WorkingArea.Width){
				X = 0 - (Screen.PrimaryScreen.WorkingArea.Width - MousePosition.X);

			}

			p = this.PointToScreen( new Point(X, Y));
			frmCalendar.StartPosition = FormStartPosition.Manual;
			frmCalendar.Location = p;
			frmCalendar.IsSelect = false;
			frmCalendar.Show();
		}

		protected virtual void OnValueChanged(EventArgs e) {
			if (ValueChanged != null) {
				// Invokes the delegates. 
				ValueChanged(this, e);
			}
		}

        protected virtual void OnCalendarDateChanged(EventArgs e)
        {
            if (CalendarDateChanged != null)
            {
                // Invokes the delegates. 
                CalendarDateChanged(this, e);
            }
        }


		private void frmCalendar_handle1() {
			bool bChange  = false;
			if (frmCalendar.IsSelect == true){
				if (this.Text.Trim() == string.Empty) {
					bChange = true;
				}
				else {
					if (this.Value != frmCalendar.GetDate )
						bChange = true;
					
				}
				
				dtb.DateValue = frmCalendar.GetDate;
                dtb.Focus();
                if (bChange) { 
                    OnValueChanged(new EventArgs());
                    OnCalendarDateChanged(new EventArgs());
                }
			}
			frmCalendar.dHandle -= new Calendar.MyHandler(this.frmCalendar_handle1);
		}
	
		/// <summary>
		/// กำหมดขนาดของ control โดยให้ขยายได้เฉพาะทางยาวเท่านั้น
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DateTextBoxWithCalendar_Resize(object sender, System.EventArgs e) {
			this.Height = dtb.Height;
            btnCallCalendar.Height = dtb.Height;

			//			dtb.Width = this.Width - btnCallCalendar.Width - SPACE_BEFORE_BUTTON;
			//			btnCallCalendar.Location = new Point(dtb.Width + SPACE_BEFORE_BUTTON,0);
		}

		private void dtb_ValueChanged(object sender, System.EventArgs e) {
			OnValueChanged(new EventArgs());
		}        

		//		protected virtual void OnDateTextChanged(EventArgs e)
		//		{
		//			if (DateTextChanged != null) 
		//			{
		//				// Invokes the delegates. 
		//				DateTextChanged(this, e);
		//			}
		//		}

		//		private void dtb_TextChanged(object sender, System.EventArgs e)
		//		{
		//			OnDateTextChanged(new EventArgs());
		//			
		//		}

		public string Format {
			get {
				return this.dtb.Format;
			}
			set {
                this.dtb.Format = value;

                //Modify by Nontawat L. [15-Sep-2008]
                //string strTempFormat = value;
                //if (strTempFormat == YEAR) {
                //    this.dtb.Format = strTempFormat;
                //}
                //else if (strTempFormat == YEAR + "/" + MONTH + "/" + DAY + " " + HOUR + ":" + MINUTE)
                //{
                //    this.dtb.Format = strTempFormat;
                //}
                //else if (strTempFormat == YEAR + "/" + MONTH + "/" + DAY)
                //{
                //    this.dtb.Format = strTempFormat;
                //}
                //else if (strTempFormat == YEAR + "/" + MONTH)
                //{
                //    this.dtb.Format = strTempFormat;
                //}
                //else if (strTempFormat == MONTH + "/" + YEAR)
                //{
                //    this.dtb.Format = strTempFormat;
                //}
                //else if (strTempFormat == DAY + "/" + MONTH + "/" + YEAR + " " + HOUR + ":" + MINUTE + ":" + SECOND)
                //{
                //    this.dtb.Format = strTempFormat;
                //}
                //else if (strTempFormat == DAY + "/" + MONTH + "/" + YEAR + " " + HOUR + ":" + MINUTE + ":" + SECOND + "." + MILLISECOND)
                //{
                //    this.dtb.Format = strTempFormat;
                //}
                //else if (strTempFormat == HOUR + ":" + MINUTE)
                //{
                //    this.dtb.Format = strTempFormat;
                //}
                //else
                //{
                //    this.dtb.Format = DAY + "/" + MONTH + "/" + YEAR;
                //}
			}
		}

		
		/// <summary>
		/// สร้างขึ้นมาเพื่อ เป้น property ใช้กำหนดค่า และ Assign ค่าให้กับ control
		/// </summary>
        [Browsable(true)]
		public DateTime? Value{
			get {
                // 20080808 Modify by ASSI.Teerayut
                if (dtb.DateValue == null || dtb.DateValue == DBNull.Value)                    
                    //return dtb.MinDateTime;
                    return null;
                else
                    return Convert.ToDateTime(this.dtb.DateValue);
			}
			set {
				this.dtb.DateValue = value;
			}
		}

        [Browsable(false)]
        public NZDateTime NZValue {
            get {
                DateTime? val = Value;
                if (val.HasValue)
                    return new NZDateTime(null, val.Value);

                return new NZDateTime();
            }
            set {
                if (value.IsNull) {
                    this.Value = null;
                    return;
                }

                this.Value = value.StrongValue;
            }
        }
		
		

		/// <summary>
		///  สร้างขึ้นมาเพื่อเป็น property ใช้ดูค่าที่ key เข้ามา
		/// </summary>        
		public override string Text{
			get{
				return this.dtb.Text;
			}
			set{
				this.dtb.Text = value;
			}
		}


        //Raktai 20080513
        //Empty date?
        public bool IsEmpty()
        {
            return dtb.IsEmpty();
        }

        //End Raktai 20080513

        //Teerayut 20080918
        // ReadOnly property
        public bool ReadOnly
        {
            set { dtb.ReadOnly = value; }
            get { return dtb.ReadOnly; }
        }

        //End Teerayut 20080918        
    }
}
