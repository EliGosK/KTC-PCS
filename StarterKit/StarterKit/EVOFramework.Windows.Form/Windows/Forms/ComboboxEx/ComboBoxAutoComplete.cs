/* Created by ASSI.Teerayut
 * Created On 2008-05-30
 * 
 * ComboBox within AutoComplete
 *  
 */
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.ComponentModel;

namespace EVOFramework.Windows.Forms
{
    [ToolboxItem(false)]
    public partial class ComboBoxAutoComplete : ComboBox
    {
        [DllImport("USER32.DLL", EntryPoint = "SendMessageW", SetLastError = true,
             CharSet = CharSet.Unicode, ExactSpelling = true,
             CallingConvention = CallingConvention.StdCall)]        
        private static extern IntPtr SendMessage(IntPtr Handle, Int32 msg, IntPtr wParam, IntPtr lParam);       

        public ComboBoxAutoComplete()
        {
            InitializeComponent();
        }

        public int ComboBox_SetCurSel(IntPtr hwndCtl, int index)
        {
            const int CB_SETCURSEL = 0x014E;
            return SendMessage(hwndCtl, CB_SETCURSEL, new IntPtr(index), IntPtr.Zero).ToInt32();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down || e.KeyData == Keys.Up)
            {
                //Show DropDown list
                if (this.DroppedDown == false)
                {
                    this.DroppedDown = true;
                    this.Cursor = Cursors.Default;
                    e.Handled = true;
                }
                return;
            }
            
            
            if (e.KeyData == Keys.Enter)
            {
                if (DroppedDown)
                    DroppedDown = false;

                if (this.Text.Trim() == String.Empty)
                {
                    this.SelectedIndex = -1;
                    this.Text = String.Empty;
                }
                else
                {
                    int iLine = FindString(this.Text);
                    if (iLine >= 0)
                    {
                        this.SelectedIndex = iLine;
                    }
                }
            }
            else if (e.Control)
            {
                //Not allow Control key
                e.Handled = true;
            }
            base.OnKeyDown(e);

        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            int iLine = -1;
            int selStart = this.SelectionStart;
            //ข้อความที่พิมพ์เข้ามา
            string strText = String.Empty;

            if (e.KeyChar == '\r')
            {
                if (this.Text.Trim() == String.Empty)
                {
                    this.SelectedIndex = -1;
                    this.Text = String.Empty;
                }
                else
                {
                    iLine = FindString(this.Text);

                    if (iLine >= 0)
                    {
                        this.SelectedIndex = iLine;
                    }
                    else  // กรณีเมื่อกด ENTER แล้วไม่พบรายการที่พิมพ์ไว้
                    {
                        string strOldText = this.Text;
                        this.SelectedIndex = iLine;
                        this.Text = strOldText;
                    }

                    this.SelectionStart = 0;
                    this.SelectionLength = 0;
                }

                base.OnKeyPress(e);

                return;
            }

            //กรณีทีการ drag เลือกข้อความ
            if (this.SelectionLength > 0)
            {
                //ลบข้อความที่เลือก  แล้วแทรกตัวอักษรที่พิมพ์เข้ามา
                strText = this.Text.Remove(selStart, this.SelectionLength);
                strText = strText.Insert(selStart, e.KeyChar.ToString());
            }
            else
            {
                //แทรกตัวอักษรที่พิมพ์เข้ามา
                strText = this.Text.Insert(selStart, e.KeyChar.ToString());
            }


            if (Char.IsLetterOrDigit(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar))
            {
                if (DroppedDown == false)
                {
                    DroppedDown = true;
                }

                //ค้นหาตำแหน่ง Item ที่ตรงกับข้อความที่พิมพ์
                //แล้ว Hilight รายการที่ตรงกัน
                iLine = FindString(strText);
                int iRet = ComboBox_SetCurSel(Handle, iLine);
                this.SelectedIndex = iRet;

                //Update text ใน Combobox
                this.Text = strText;
                this.SelectionStart = selStart + 1;
                e.Handled = true;

            }            
            base.OnKeyPress(e);
            
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.LostFocus"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnLostFocus(EventArgs e)
        {
            // Prevent selection  
            base.OnLostFocus(e);
            this.SelectionStart = 0;
            this.SelectionLength = 0;
        }
        
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Leave"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
        protected override void OnLeave(EventArgs e)
        {            
            // Prevent selection
            base.OnLeave(e);
            this.SelectionStart = 0;
            this.SelectionLength = 0;
            
        }
        
        
        protected override void OnDropDownClosed(EventArgs e)
        {            
            base.OnDropDownClosed(e);
            //int iLine = -1;
            //if (this.Text.Trim() == String.Empty)
            //{
            //    this.SelectedIndex = -1;
            //    this.Text = String.Empty;
            //}
            //else
            //{
            //    iLine = FindString(this.Text);

            //    if (iLine >= 0)
            //    {
            //        this.SelectedIndex = iLine;
            //    }
            //    else  // กรณีเมื่อกด ENTER แล้วไม่พบรายการที่พิมพ์ไว้
            //    {
            //        string strOldText = this.Text;
            //        this.SelectedIndex = iLine;
            //        this.Text = strOldText;
            //    }

            //    this.SelectionStart = 0;
            //    this.SelectionLength = 0;
            //}

            
        }
        /// <summary>
        /// Processes a command key.
        /// </summary>
        /// <returns>
        /// true if the character was processed by the control; otherwise, false.
        /// </returns>
        /// <param name="msg">A <see cref="T:System.Windows.Forms.Message"/>, passed by reference, that represents the window message to process. </param><param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys"/> values that represents the key to process. </param>
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                if (DroppedDown)
                {
                    DroppedDown = false;
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }     
    }
    
}
