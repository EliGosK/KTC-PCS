using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace EVOFramework.Windows.Forms
{
    internal partial class MessageDialogBase : AlphaWindowForm
    {
        protected enum eCloseButton
        {
            NORMAL,
            DISABLE,
            MOUSEOVER,
            MOUSEDOWN,
        }
        private enum SND
        {
            SND_SYNC = 0x0000,/* play synchronously (default) */
            SND_ASYNC = 0x0001, /* play asynchronously */
            SND_NODEFAULT = 0x0002, /* silence (!default) if sound not found */
            SND_MEMORY = 0x0004, /* pszSound points to a memory file */
            SND_LOOP = 0x0008, /* loop the sound until next sndPlaySound */
            SND_NOSTOP = 0x0010, /* don't stop any currently playing sound */
            SND_NOWAIT = 0x00002000, /* don't wait if the driver is busy */
            SND_ALIAS = 0x00010000,/* name is a registry alias */
            SND_ALIAS_ID = 0x00110000, /* alias is a pre d ID */
            SND_FILENAME = 0x00020000, /* name is file name */
            SND_RESOURCE = 0x00040004, /* name is resource name or atom */
            SND_PURGE = 0x0040,  /* purge non-static events for task */
            SND_APPLICATION = 0x0080 /* look for application specific association */
        }

        #region System Variables
        /// <summary>
        /// ผูกฟอร์ม PointDummy สำหรับสร้างพื้นที่วาด Graphics
        /// </summary>
        private PointDummy m_pointDummy = new PointDummy();

        /// <summary>
        /// Pointer to control's handle.
        /// </summary>
        private IntPtr m_hWndControl = IntPtr.Zero;

        /// <summary>
        /// เก็บตำแหน่ง Rectangle ล่าสุดของ CaptureControl
        /// </summary>
        private Rectangle m_rectLast = Rectangle.Empty;

        /// <summary>
        /// เก็บผลลัพธ์ของ MessageDialog หลังจาก Show เสร็จ
        /// </summary>
        private MessageDialogResult m_dialogResult = MessageDialogResult.Cancel;

        /// <summary>
        /// ปุ่มที่จะใช้สำหรับ MessageDialog ที่สร้างขึ้น
        /// </summary>
        private MessageDialogButtons m_dialogButtons = MessageDialogButtons.OK;

        /// <summary>
        /// เก็บปุ่มที่เป็น Default เมื่อแสดง MessageDialog
        /// </summary>
        private MessageDialogDefaultButtons m_dialogDefaultButton = MessageDialogDefaultButtons.Button1;

        /// <summary>
        /// รูป Icon ที่แสดงสำหรับ MessageDialog
        /// </summary>
        private MessageDialogIcon m_dialogIcon = MessageDialogIcon.None;

        /// <summary>
        /// เก็บข้อความปุ่มประเภท Custom
        /// </summary>
        private string[] m_strTextButtons = null;

        /// <summary>
        /// อนุญาติให้เปิดปุ่ม Close
        /// </summary>
        private bool m_bCloseButtonEnabled = true;

        #endregion

        #region Global Variables
        //private Color colorBorder = Color.FromArgb(172, 168, 153);
        //private Color colorTitleBar = Color.FromArgb(193, 210, 238);
        //private Color colorTitleBarNoActive = Color.FromArgb(212, 208, 200);
        //private Color colorCode_BK = Color.FromArgb(236, 233, 216);
        //private Color colorDesc_BK = Color.FromArgb(242, 240, 230);
        //private Color colorLineSeperate = Color.FromArgb(221, 217, 207);

        // Active
        private Color colorBorder = Color.FromArgb(0, 0, 255);
        private Color colorTitleBar = Color.FromArgb(0, 0, 255);                
        private Color colorLineSeperate = Color.FromArgb(0, 0, 255);

        // No-Active
        private Color colorBorderNoActive = Color.FromArgb(81, 168, 255);
        private Color colorTitleBarNoActive = Color.FromArgb(81, 168, 255);
        private Color colorLineSeperateNoActive = Color.FromArgb(81, 168, 255);

        // Background panel
        private Color colorCode_BK = Color.FromArgb(236, 233, 216);
        private Color colorDesc_BK = Color.FromArgb(242, 240, 230);

        private Icon m_icon = SystemIcons.Error;
        private bool m_bMove = false;
        private string m_strTitle = String.Empty;
        private string m_strSoundFilename = String.Empty;
        private byte m_iAlphaLevel = 180;

        /// <summary>
        /// ระยะห่างจากขอบซ้าย และขอบขวา
        /// </summary>
        private int m_iXSpace = 10;

        private bool m_bActive = true;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public MessageDialogBase()
        {
            InitializeComponent();

            pnlTitle.BackColor = colorTitleBar;            
            pnlButton.BackColor = colorDesc_BK;
        }

        #region Form Events
        private void MessageDialogBase_Paint(object sender, PaintEventArgs e)
        {            

            using (Pen pen = new Pen(m_bActive ? colorBorder : colorBorderNoActive,  1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            }
        }
        private void pnlTitle_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(m_bActive ? colorBorder : colorBorderNoActive, 1))
            {
                e.Graphics.DrawLine(pen, 0, e.ClipRectangle.Height - 1, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            }
        }

        private void pnlButton_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(m_bActive ? colorLineSeperate : colorLineSeperateNoActive, 1))
            {
                e.Graphics.DrawLine(pen, 0, 0, e.ClipRectangle.Width - 1, 0);
            }
        }

        private void MessageDialogBase_Move(object sender, EventArgs e)
        {
            if (m_bMove)
                SetAlpha(AlphaLevel);
        }
        private void MessageDialogBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer.Enabled = false;

            ////Destroy PointDummy
            PointDummyForm.Close();
            PointDummyForm.Dispose();
        }
        private void MessageDialogBase_Activated(object sender, EventArgs e)
        {
            this.m_bActive = true;
            this.Invalidate(true);
            pnlTitle.BackColor = colorTitleBar;

            if (CloseButtonEnabled)
                picClose.Image = GetCloseButtonImage(eCloseButton.NORMAL);
        }
        private void MessageDialogBase_Deactivate(object sender, EventArgs e)
        {
            this.m_bActive = false;
            this.Invalidate(true);

            pnlTitle.BackColor = colorTitleBarNoActive;

            if (CloseButtonEnabled)
                picClose.Image = GetCloseButtonImage(eCloseButton.DISABLE);
        }
        private void MessageDialogBase_Load(object sender, EventArgs e)
        {
            ReloadDialog();

            if (!DesignMode)
                this.Location = StartingLocation;
        }
        private void MessageDialogBase_Shown(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                // แสดงหน้าจอ Point Dummy
                PointDummyForm.Show(this.Owner);
            }
            else
            {

                PointDummyForm.Show();
                PointDummyForm.Owner = null;
                this.Owner = null;
            }

            this.UpdateClientRectanglePointDummy();
            Win32.SetForegroundWindow(Handle);

            PlaySound();

            pnlButtonContainer.Controls[(int)MessageDialogDefaultButton].Focus();
            
            this.Invalidate(true);
        }
        private void MessageDialogBase_KeyDown(object sender, KeyEventArgs e)
        {
            if (CloseButtonEnabled && e.KeyCode == Keys.Escape)
                this.Close();
        }


        protected override void WndProc(ref System.Windows.Forms.Message m)
        {            
            if (!DesignMode)
            {
                if (m.Msg == Win32.WM_SYSCOMMAND)
                {
                    if (m.WParam.ToInt32() == Win32.SC_CLOSE)
                    {
                        //ไม่อนุญาติให้กดปุ่ม ALT+F4 ได้
                        if (!CloseButtonEnabled)
                            return;
                    }
                }
                else if (m.Msg == Win32.WM_NCACTIVATE)
                {
                    bool bActive = Convert.ToBoolean(m.WParam.ToInt32());
                    if (bActive)
                        OnActivated(EventArgs.Empty);
                    else
                        OnDeactivate(EventArgs.Empty);
                }
            }

            base.WndProc(ref m);
        }
        #endregion

        #region Movable Form event
        private void pnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            m_bMove = true;

            PointDummyForm.SetAlpha(0);

            Application.DoEvents();

            int WM_NCLBUTTONDOWN = 0x00A1;

            if (e.Button == MouseButtons.Left)
            {                
                Win32.ReleaseCapture();
                Win32.SendMessage(this.Handle, WM_NCLBUTTONDOWN, new IntPtr(2), IntPtr.Zero);

                SetAlpha(255);
                m_bMove = false;
                
            }

            //Show PointDummyForm again in timer_tick() event when mouse up.
        }

        private void pnlTitle_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void pnlTitle_MouseUp(object sender, MouseEventArgs e)
        {
            SetAlpha(255);
            m_bMove = false;
            
        }
        #endregion

        #region Close button icon and events

        private void picClose_MouseEnter(object sender, EventArgs e)
        {
            if (CloseButtonEnabled)
                picClose.Image = GetCloseButtonImage(eCloseButton.MOUSEOVER);
        }
        private void picClose_MouseLeave(object sender, EventArgs e)
        {
            if (CloseButtonEnabled)
                picClose.Image = GetCloseButtonImage(eCloseButton.NORMAL);
        }

        private void picClose_MouseDown(object sender, MouseEventArgs e)
        {
            if (CloseButtonEnabled)
                picClose.Image = GetCloseButtonImage(eCloseButton.MOUSEDOWN);
        }

        private void picClose_MouseUp(object sender, MouseEventArgs e)
        {
            if (CloseButtonEnabled)
                picClose.Image = GetCloseButtonImage(eCloseButton.MOUSEOVER);
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            if (CloseButtonEnabled)
                this.Close();
        }
        #endregion       

        #region Virtual methods
        /// <summary>
        /// <para>Reload form again.</para>
        /// <para>1. Create Controls on dialog.</para>
        /// <para>2. Update Layout.</para>
        /// <para>3. Update Size and Location dialog.</para>
        /// </summary>
        protected virtual void ReloadDialog()
        {
            lblTitle.Text = this.Text;

            //วางตำแหน่ง Control ลงในจุดที่เหมาะสม
            CreateButtons();

            ////Update SystemMenu - Close button
            //if (!CloseButtonEnabled)
            //{
            //    RemoveCloseButton();
            //    picClose.Image = GetCloseButtonImage(eCloseButton.DISABLE);
            //}


            UpdateControlLocation();

            //กำหนดจุดเริ่มต้น และขนาดของ Form
            this.Size = new Size(CalcWidthSize, CalcHeightSize);

            UpdateTitleLocation();
            UpdateButtonLocation();
        }
        

        /// <summary>
        /// กำหนดตำแหน่งให้แก่ Control , คำสั่งนี้มีผลต่อการคำนวณความกว้างและความสูงของ Form 
        /// ดังนั้นจะต้อง Override method นี้ให้กำหนดตำแหน่งของ Control ให้ถูกต้องก่อนคำนวณความกว้างและความสูง
        /// </summary>
        protected virtual void UpdateControlLocation() 
        {
            
        }

        private void UpdateTitleLocation()
        {
            //Update TitleBar
            lblTitle.Location = new Point(LeftPadding, 5);
            pnlTitle.Height = 10 + lblTitle.Height;
        }

        private void UpdateButtonLocation()
        {
            //Update bottom button
            pnlButtonContainer.Left = (this.Width / 2) - (pnlButtonContainer.Width / 2);
            pnlButtonContainer.Top = 3;
            pnlButton.Height = 6 + pnlButtonContainer.Height;
        }

        /// <summary>
        /// คำนวณความกว้างของหน้าจอ
        /// </summary>
        protected virtual int CalcWidthSize
        {
            get {
                int WTitle = (LeftPadding * 2) + lblTitle.Width + 20 + picClose.Width;  // 20 = space between caption and close button.
                int WButtons = (LeftPadding * 2) + pnlButtonContainer.Width;

                return Math.Max(WTitle, WButtons); 
            }
        }

        /// <summary>
        /// คำนวณความสูงของหน้า
        /// </summary>
        protected virtual int CalcHeightSize
        {
            get {
                int HTitle = 10 + lblTitle.Height;
                int HButtons = 6 + pnlButtonContainer.Height;
                return HTitle + HButtons; 
            }
        }

        /// <summary>
        /// ระบุตำแหน่งเริ่มต้น (X,Y) เพื่อแสดงหน้าจอ
        /// </summary>
        public virtual Point StartingLocation
        {
            get {
                if (this.Owner != null)
                {
                    int iLeft = Owner.Left + (Owner.DesktopBounds.Width / 2) - (this.Width / 2);
                    int iTop = Owner.Top + (Owner.DesktopBounds.Height / 2) - (this.Height / 2);
                    return new Point(iLeft, iTop);
                }
                else
                {
                    Rectangle rect = Screen.FromPoint(Cursor.Position).Bounds;
                    int iLeft = (rect.Width / 2) - (this.Width / 2);
                    int iTop = (rect.Height / 2) - (this.Height / 2);
                    return new Point(iLeft, iTop);
                }   
           }
        }

        /// <summary>
        /// ใช้สำหรับบอกสถานะว่ากำลังเคลื่อนย้าย Form อยู่หรือไม่
        /// method นี้มีผลต่อ timer ที่ใช้ Update PointDummy and MessageDialog เมื่อ CaptureControl มีการเคลื่อนไหว
        /// </summary>
        public virtual bool IsMoving
        {
            get { return m_bMove; }
        }

        
        #endregion

        #region Protected methods
        /// <summary>
        /// กำหนด Handle ของ Control ที่ต้องการแสดงเส้นชี้
        /// </summary>
        /// <param name="handle"></param>
        public void SetCaptureControl(IntPtr handle)
        {
            m_hWndControl = handle;

            //เก็บตำแหน่งและขนาดเริ่มต้น เมื่อเริ่มดักจับ Control
            m_rectLast = CaptureControlRectangle;
        }

        /// <summary>
        /// คืนค่าพื้นที่ของ Control ที่ใช้สำหรับแสดงเส้นชี้
        /// </summary>
        protected Rectangle CaptureControlRectangle
        {
            get {
                if (m_hWndControl != IntPtr.Zero)
                {
                    Win32.RECT rect = new Win32.RECT();
                    Win32.GetWindowRect(m_hWndControl, ref rect);
                    return rect.ToRectangle();
                }
                else
                    return Rectangle.Empty;
            }
        }

        /// <summary>
        /// คืนค่า PointDummy instance.
        /// </summary>
        protected PointDummy PointDummyForm
        {
            get {
                return m_pointDummy;
            }
        }

        /// <summary>
        /// Get or set Handle ของ Control ที่ใช้ตรวจจับ
        /// </summary>
        protected IntPtr HandleCaptureControl
        {
            get { return m_hWndControl; }
            set { m_hWndControl = value; }
        }

        /// <summary>
        /// อ่านรูปจากค่าที่ระบุเข้ามา
        /// </summary>
        /// <param name="icon"></param>
        /// <returns></returns>
        protected Icon GetIcon(MessageDialogIcon icon)
        {
            switch (icon)
            {
                case MessageDialogIcon.None:
                    return null;

                case MessageDialogIcon.Error:  //Hand , Stop
                    return SystemIcons.Error;

                case MessageDialogIcon.Question:
                    return SystemIcons.Question;
                    
                case MessageDialogIcon.Exclamation:   //Warning                                 
                    return SystemIcons.Warning;
                    
                case MessageDialogIcon.Information: // Asterisk                
                    return SystemIcons.Information;
            }

            return null;
        }

        /// <summary>
        /// อ่านรูปปุ่ม Close
        /// </summary>
        /// <param name="button"></param>
        /// <returns></returns>
        protected Image GetCloseButtonImage(eCloseButton button)
        {
            return imageList.Images[button.ToString()];            
        }

        /// <summary>
        /// Flag บอกว่าปุ่ม CloseButton เปิดทำงานหรือไม่
        /// </summary>
        protected bool CloseButtonEnabled
        {
            get { return m_bCloseButtonEnabled; }
            set { m_bCloseButtonEnabled = value; }
            
        }
        
        #endregion

        #region Private methods
        private void CreateButtons()
        {
            // การสร้างปุ่มนี้  จะยังไม่รวมถึงการกำหนดตำแหน่งของ pnlButtonContainer
            // จะสร้างแค่ปุ่ม แล้วเพิ่มเข้าไปใน pnlButtonContainer เท่านั้น

            this.AcceptButton = null;
            this.CancelButton = null;

            MessageDialogButtons buttons = MessageDialogButtons;
            switch (buttons)
            {
                case MessageDialogButtons.OK:
                    CreateButtons_Instance(
                        new MessageDialogResult[] { MessageDialogResult.OK },
                        new string[] { "OK" }, 0);                    
                    MessageDialogResult = MessageDialogResult.OK;
                    MessageDialogDefaultButton = MessageDialogDefaultButtons.Button1;
                    CloseButtonEnabled = true;
                    break;

                case MessageDialogButtons.OKCancel:
                    CreateButtons_Instance(
                        new MessageDialogResult[] { MessageDialogResult.OK, MessageDialogResult.Cancel },
                        new string[] { "OK", "Cancel" }, 0);

                    MessageDialogResult = MessageDialogResult.Cancel;
                    MessageDialogDefaultButton = MessageDialogDefaultButtons.Button1;
                    CloseButtonEnabled = true;
                    break;

                case MessageDialogButtons.YesNo:
                    CreateButtons_Instance(
                        new MessageDialogResult[] { MessageDialogResult.Yes, MessageDialogResult.No },
                        new string[] { "Yes", "No" }, 0);

                    MessageDialogResult = MessageDialogResult.No;
                    MessageDialogDefaultButton = MessageDialogDefaultButtons.Button1;
                    CloseButtonEnabled = false;
                    break;
                case MessageDialogButtons.YesNoCancel:
                    CreateButtons_Instance(
                        new MessageDialogResult[] { MessageDialogResult.Yes, MessageDialogResult.No, MessageDialogResult.Cancel },
                        new string[] { "Yes", "No", "Cancel" }, 0);
                    MessageDialogResult = MessageDialogResult.Cancel;
                    MessageDialogDefaultButton = MessageDialogDefaultButtons.Button1;
                    CloseButtonEnabled = true;
                    break;
                case MessageDialogButtons.Custom1:
                    CreateButtons_Instance(
                        new MessageDialogResult[]{ 
                            MessageDialogResult.Custom1,  
                        }, TextButtons, 0);
                    MessageDialogResult = MessageDialogResult.Cancel;
                    //MessageDialogDefaultButton = MessageDialogDefaultButtons.Button1;
                    CloseButtonEnabled = false;
                    break;
                case MessageDialogButtons.Custom2:
                    CreateButtons_Instance(
                        new MessageDialogResult[]{ 
                            MessageDialogResult.Custom1,  
                            MessageDialogResult.Custom2,  
                        }, TextButtons, 0);

                    MessageDialogResult = MessageDialogResult.Custom1;
                    //MessageDialogDefaultButton = MessageDialogDefaultButtons.Button1;
                    CloseButtonEnabled = false;
                    break;
                case MessageDialogButtons.Custom3:
                    CreateButtons_Instance(
                        new MessageDialogResult[]{ 
                            MessageDialogResult.Custom1,  
                            MessageDialogResult.Custom2,  
                            MessageDialogResult.Custom3,  
                        }, TextButtons, 0);
                    MessageDialogResult = MessageDialogResult.Custom1;
                    //MessageDialogDefaultButton = MessageDialogDefaultButtons.Button1;
                    CloseButtonEnabled = false;
                    break;
                case MessageDialogButtons.Custom4:
                    CreateButtons_Instance(
                        new MessageDialogResult[]{ 
                            MessageDialogResult.Custom1,  
                            MessageDialogResult.Custom2,  
                            MessageDialogResult.Custom3,  
                            MessageDialogResult.Custom4,  
                        }, TextButtons, 0);
                    MessageDialogResult = MessageDialogResult.Custom1;
                    //MessageDialogDefaultButton = MessageDialogDefaultButtons.Button1;
                    CloseButtonEnabled = false;
                    break;
                case MessageDialogButtons.Custom5:
                    CreateButtons_Instance(
                        new MessageDialogResult[]{ 
                            MessageDialogResult.Custom1,  
                            MessageDialogResult.Custom2,  
                            MessageDialogResult.Custom3,  
                            MessageDialogResult.Custom4,  
                            MessageDialogResult.Custom5,  
                        }, TextButtons, 0);
                    MessageDialogResult = MessageDialogResult.Custom1;
                    //MessageDialogDefaultButton = MessageDialogDefaultButtons.Button1;
                    CloseButtonEnabled = false;
                    break;
                case MessageDialogButtons.Custom6:

                    CreateButtons_Instance(
                        new MessageDialogResult[]{ 
                            MessageDialogResult.Custom1,  
                            MessageDialogResult.Custom2,  
                            MessageDialogResult.Custom3,  
                            MessageDialogResult.Custom4,  
                            MessageDialogResult.Custom5,  
                            MessageDialogResult.Custom6
                        }, TextButtons, 0);
                    MessageDialogResult = MessageDialogResult.Custom1;
                    //MessageDialogDefaultButton = MessageDialogDefaultButtons.Button1;
                    CloseButtonEnabled = false;
                    break;
            }
        }
        private void CreateButtons_Instance(MessageDialogResult[] dialogResults, string[] textButtons, int defaultIndex)
        {
            int xPos = 0;
            int iSpace = 10;

            int iMaxHeight = 0;

            if (dialogResults.Length > textButtons.Length)
                throw new ApplicationException("Declare TextButtons less more than DialogResult.");

            pnlButtonContainer.Controls.Clear();
            for (int i = 0; i < dialogResults.Length; i++)
            {
                Button btn = new Button();
                btn.Name = "btn_" + i.ToString();
                btn.Text = textButtons[i];
                btn.Location = new Point(xPos, 0);
                btn.Tag = dialogResults[i];
                btn.Click += new EventHandler(Button_Click);

                if (dialogResults[i] == MessageDialogResult.OK)
                    this.AcceptButton = btn;
                else if (dialogResults[i] == MessageDialogResult.Cancel)
                    this.CancelButton = btn;

                if (i == defaultIndex)
                    btn.Focus();

                iMaxHeight = Math.Max(iMaxHeight, btn.Height);

                //Add into container
                pnlButtonContainer.Controls.Add(btn);

                if (i != textButtons.Length - 1)
                {
                    // ถ้าปุ่มที่สร้างไม่ใช่ตำแหน่งปุ่มสุดท้าย จะปรับ xPos ให้เป็นตำแหน่งเริ่มต้นของปุ่มถัดไป
                    xPos += btn.Width + iSpace;
                }
                else
                {
                    // ถ้าปุ่มที่สร้างเป็นปุ่มสุดท้าย  จะเลื่อน xPos ไปไว้ที่ตำแหน่งหลังสูด (ไม่รวม Space)
                    xPos += btn.Width;
                }

            }

            //ปรับความกว้างของ Panel Button Container
            pnlButtonContainer.Width = xPos;
            pnlButtonContainer.Height = iMaxHeight;
        }
        private void Button_Click(object sender, EventArgs e)
        {
            //เช็คว่าปุ่มที่คลิกนี้ มีค่า DialogResult เป็นอะไร
            MessageDialogResult = (MessageDialogResult)((Button)sender).Tag;
            this.Close();
        }

        /// <summary>
        /// Remove menu from SysCommand SC_CLOSE
        /// </summary>
        //private void RemoveCloseButton()
        //{
        //    //Obtain the handle to the form's system menu
        //    IntPtr hMenu = Win32.GetSystemMenu(Handle.ToInt32(), false);

        //    //Get the count of the items in the system menu.
        //    IntPtr menuItemCount = Win32.GetMenuItemCount(hMenu.ToInt32());

        //    //Remove the close menuitem.
        //    Win32.RemoveMenu(hMenu.ToInt32(), menuItemCount.ToInt32() - 1, Win32.MF_DISABLED | Win32.MF_BYPOSITION);

        //    //Remove the Separetor
        //    Win32.RemoveMenu(hMenu.ToInt32(), menuItemCount.ToInt32() - 2, Win32.MF_DISABLED | Win32.MF_BYPOSITION);

        //    //redraw the menu bar
        //    Win32.DrawMenuBar(Handle.ToInt32());
        //}

        private void UpdateClientRectanglePointDummy()
        {
            PointDummyForm.ClearLine();

            if (HandleCaptureControl == IntPtr.Zero)
            {
                PointDummyForm.Location = new Point(0, 0);
                PointDummyForm.Size = new Size(3, 3);
                return;
            }

        }

        /// <summary>
        /// เคลื่อนย้ายตำแหน่ง PointDummy ตามจำนวน deltaX และ deltaY
        /// </summary>
        /// <param name="deltaX"></param>
        /// <param name="deltaY"></param>
        private void OffsetPointDummy(int deltaX, int deltaY)
        {
            PointDummyForm.Left += deltaX;
            PointDummyForm.Top += deltaY;
        }

        /// <summary>
        /// เคลื่อนย้ายตำแหน่ง Dialog ตามจำนวน deltaX และ deltaY
        /// </summary>
        /// <param name="deltaX"></param>
        /// <param name="deltaY"></param>
        private void OffsetDialog(int deltaX, int deltaY)
        {
            const int iMargin = 15;
            bool bShouldUpdatePoint = false;

            //Offset MessageDialog and prevent outside WindowDesktop.
            Rectangle rect = this.DesktopBounds;

            rect.X += deltaX;
            rect.Y += deltaY;

            if (rect.X < iMargin)
                rect.X = iMargin;

            if (rect.Y < iMargin)
                rect.Y = iMargin;
            
#warning MessageDialog ยังคงลากใน 2 หน้าจอไม่ได้
            if (rect.Right > Screen.FromRectangle(rect).Bounds.Right - iMargin)
            {
                bShouldUpdatePoint = true;
                rect.X = Screen.FromRectangle(rect).Bounds.Right - iMargin - rect.Width;
            }

            if (rect.Bottom > Screen.FromRectangle(rect).Bounds.Bottom - iMargin)
            {
                bShouldUpdatePoint = true;
                rect.Y = Screen.FromRectangle(rect).Bounds.Bottom - iMargin - rect.Height;
            }

            if (bShouldUpdatePoint)
            {
#warning Re-calculate position of PointDummyForm and Redraw line
            }

            this.Left = rect.X;
            this.Top = rect.Y;            
        }

        /// <summary>
        /// Timer สำหรับ update หน้าจอ PointDummy เวลา CaptureControl มีการเปลี่ยนแปลง
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            //หน้าที่ของ Timer คือคอยจับดูว่า Control ที่ตรวจจับอยู่นี้มีการเปลี่ยนตำแหน่งรึเปล่า  เพื่อคอย Update ขนาด PointDummy
            //แบ่งการ Update PointDummy ออกเป็น 2 ฝั่งคือ  มีการเคลื่อนย้าย MessageDialog และมีการเคลื่อนย้ายที่ตัว Control เอง

            if (IsMoving)
            {
                
                //ถ้ามีการเคลื่อนย้าย Form อยู่ จะปิดการทำงานของ Timer
                PointDummyForm.SetAlpha(0);
            }
            else if (!IsMoving && HandleCaptureControl != IntPtr.Zero)
            {
                if (PointDummyForm.AlphaLevel == 0)
                {
                    PointDummyForm.SetAlpha(255);
                    Win32.SetForegroundWindow(Handle);

                    this.Invalidate(true);
                }

                //ถ้าตำแหน่งและขนาดไม่ตรงกับค่าล่าสุด  จะต้องมีการ Update
                else if (!m_rectLast.Equals(CaptureControlRectangle))
                {
                    //เก็บ Control เกินขอบเขตการแสดงผล จะซ่อน PointDummy และ MessageDialog
                    if (CaptureControlRectangle.Right < 0 ||
                        CaptureControlRectangle.Bottom < 0 ||
                        CaptureControlRectangle.Left > Screen.FromHandle(HandleCaptureControl).WorkingArea.Right ||
                        CaptureControlRectangle.Top > Screen.FromHandle(HandleCaptureControl).WorkingArea.Bottom)
                    {
                        PointDummyForm.Visible = false;
                        this.Visible = false;
                        return;
                    }
                    else
                    {
                        //เก็บ Window ที่กำลัง Capture mouse ไว้อยู่
                        IntPtr ptr = Win32.GetCapture();

                        PointDummyForm.Visible = true;
                        this.Visible = true;

                        // SetForeground ไปยัง window ตัวที่กำลังเคลื่อนตำแหน่ง
                        Win32.SetForegroundWindow(ptr);
                        
                    }

                    int deltaX = CaptureControlRectangle.Left - m_rectLast.Left;
                    int deltaY = CaptureControlRectangle.Top - m_rectLast.Top;
                    OffsetPointDummy(deltaX, deltaY);
                    OffsetDialog(deltaX, deltaY);
                    
                    //ปรับปรุง Rect ของ PointDummy ให้พอดีกับ Control ที่เปลี่ยนไป
                    //UpdateClientRectanglePointDummy(m_rectLast);

                    //เก็บค่าตำแหน่งตำแหน่ง และขนาดใหม่
                    m_rectLast = CaptureControlRectangle;


                } // end if : เช็ค Equal ของ CaptureControl Rectangle 
                
            }
        }

        private void PlaySound()
        {
            string strSoundFileName = String.Empty;
            switch (m_dialogIcon)
            {
                case MessageDialogIcon.None:
                    break;
                case MessageDialogIcon.Error: // MessageBoxIcon.Error = MessageBoxIcon.Hand = MessageBoxIcon.Stop
                    strSoundFileName = "SystemHand";
                    break;
                case MessageDialogIcon.Question:
                    strSoundFileName = "SystemAsterisk";
                    break;
                case MessageDialogIcon.Exclamation: // MessageBoxIcon.Warning = MessageBoxIcon.Exclamation
                    strSoundFileName = "SystemExclamation";
                    break;
                case MessageDialogIcon.Information: // MessageBoxIcon.Information = MessageBoxIcon.Asterisk
                    strSoundFileName = "SystemAsterisk";
                    break;
                default:
                    break;
            }

            if (strSoundFileName != String.Empty)
                Win32.PlaySound(strSoundFileName, 0, (int)(SND.SND_ASYNC | SND.SND_ALIAS | SND.SND_NOWAIT));

        }
        #endregion

        #region Public

        #region Properties
        /// <summary>
        /// Get or set ปุ่มที่จะเป็น Default เมื่อเปิด MessageDialog
        /// </summary>
        public MessageDialogDefaultButtons MessageDialogDefaultButton
        {
            get { return m_dialogDefaultButton; }
            set { m_dialogDefaultButton = value; }
        }

        /// <summary>
        /// อ่านค่าผลลัพธ์ MessageDialogResult หลังจากเลือกปุ่มของ Dialog
        /// </summary>
        public MessageDialogResult MessageDialogResult
        {
            get { return m_dialogResult; }
            set { m_dialogResult = value; }
        }

        /// <summary>
        /// อ่านค่าปุ่มที่ใช้สำหรับ MessageDialog นี้
        /// </summary>
        public MessageDialogButtons MessageDialogButtons
        {
            get { return m_dialogButtons; }
            set { m_dialogButtons = value; }
        }

        /// <summary>
        /// อ่านค่ารูป Icon ที่ใช้แสดงใน MessageDialog นี้
        /// </summary>
        public MessageDialogIcon MessageDialogIcon
        {
            get { return m_dialogIcon; }
            set { m_dialogIcon = value; }
        }

        /// <summary>
        /// อ่านค่าข้อความปุ่มสำหรับปุ่มประเภท Custom
        /// </summary>
        public string[] TextButtons
        {
            get { return m_strTextButtons; }
            set { m_strTextButtons = value; }
        }

        /// <summary>
        /// Get or set TitleBar text
        /// </summary>
        public override string Text
        {
            get
            {
                return m_strTitle;
            }
            set
            {
                m_strTitle = value;
            }
        }

        [Browsable(false)]
        public int LeftPadding
        {
            get { return m_iXSpace; }
            internal set { m_iXSpace = value; }
        }

        [Browsable(true)]
        [Description("Set default level alpha transparent form when moving")]
        public byte AlphaLevel
        {
            get { return m_iAlphaLevel; }
            set {
                //if (value < 0 || value > 255)
                //    throw new ApplicationException("Value should be in range [0..255]");

                m_iAlphaLevel = value;
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Reload information and update layout message dialog.
        /// </summary>
        public void Reload()
        {
            ReloadDialog();
        }  

        public new MessageDialogResult ShowDialog(IWin32Window owner)
        {
            base.ShowDialog(owner);
            return MessageDialogResult;
        }
        public new MessageDialogResult ShowDialog()
        {
            return ShowDialog(null);
        }
        #endregion

        #endregion


















    }
}

