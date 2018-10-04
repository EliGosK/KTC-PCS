using System;
using System.ComponentModel;
using System.Drawing;

namespace EVOFramework.Windows.Forms
{
    internal partial class AlphaWindowForm : System.Windows.Forms.Form
    {        
        public AlphaWindowForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            int iExStyle = Win32.GetWindowLong(this.Handle, Win32.GWL_EXSTYLE);
            iExStyle |= Win32.WS_EX_LAYERED | Win32.WS_EX_CONTROLPARENT;

            Win32.SetWindowLong(this.Handle, Win32.GWL_EXSTYLE, iExStyle);

            //Prevent Flicker ตอนเปิดหน้าจอครั้งแรก
            SetAlpha(0);
            Win32.ShowWindow(this.Handle, Win32.SW_SHOW);

            // Redraw contents NOW - no flickering since the window's not visible
            Win32.RedrawWindow(this.Handle, IntPtr.Zero, IntPtr.Zero, Win32.RDW_UPDATENOW);

            SetAlpha(255);            
        }

        public void SetAlpha(byte b)
        {
            Win32.SetLayeredWindowAttributes(this.Handle, 0, b, Win32.LWA_ALPHA);
        }                

        /// <summary>
        /// Get System screen location and size.
        /// </summary>
        [Browsable(false)]
        public Rectangle SystemScreenRectangle
        {
            get { 
                Win32.RECT rect = new Win32.RECT();
                Win32.GetWindowRect(Handle, ref rect);
                return rect.ToRectangle();
            }
        }
    }
}