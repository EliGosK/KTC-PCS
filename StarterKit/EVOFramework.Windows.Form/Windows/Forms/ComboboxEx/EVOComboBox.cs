/* Created by Mr.Teerayut Sinlan
 * Department : ASSI-JE2
 * Created on 20080820
 */

/* Fixing Bug
 * 2009/10/21 
 *   - เมื่อกรอกค่าที่ไม่มีอยู่ใน List แล้วคลิกปุ่ม Operation ใดๆ (โดยไม่ได้กด enter ก่อน)  จะต้องคืนค่า SelectedIndex = -1
 * 2009/03/16
 *   - Fix support theme with virtual style and non virtual style (Theme windows classic).
 * 2008/10/03 ASSI.Teerayut
 *   - เมื่อเข้าสู่โหมด ReadOnly จะต้องเลื่อนขึ้น-ลงไม่ได้ และกด F4 ไม่ได้ (ไม่แสดง DrowDown)
 * 2008/09/11 ASSI.Teerayut
 *   - ถ้าเลือกรายการข้อมูลจาก AutoComplete ที่มาจาก Windows แล้วกดคีย์ลัด เช่น CTRL+A จะส่งผลให้ค่า SelectedIndex = -1 ทันที
 *     ดังนั้นตอนนี้จึงเปลี่ยนมาใช้การสืบทอดจาก ComboBoxAutoComplete แทน, ต่อไปไม่ต้องกำหนด Property AutoComplete  
 * 
 */
using System;
using System.ComponentModel;
using System.Drawing;

using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using EVOFramework.Data;
using System.Data;

namespace EVOFramework.Windows.Forms
{
    [ToolboxItem(true)]
    public class EVOComboBox : ComboBoxAutoComplete, IReadOnly, IControlIdentify, IUIDataModelSupport, IAppearance, IReadOnlyAppearance
    {
        #region Unmanage method
        [DllImport("gdi32.dll", EntryPoint = "CreateSolidBrush", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        private static extern IntPtr CreateSolidBrush(int crColor);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int SetBkColor(IntPtr hDC, int clr);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern bool DeleteObject(IntPtr hObject);

        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hdc);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        public static int ColorToCOLORREF(Color color)
        {
            return ((color.R | (color.G << 8)) | (color.B << 0x10));
        }
        #endregion

        #region Variables
        private bool m_bReadOnly = false;
        private string m_appearanceName = string.Empty;
        private string m_appearanceReadOnlyName = string.Empty;
        private LookupData m_lookupData = null;
        private string m_selectedText = string.Empty;

        private bool m_bAutoOpenList = false;
        #endregion

        #region Events
        public event EventHandler ReadOnlyChanged;
        #endregion


        #region Constructor
        public EVOComboBox()
        {
            // ADD BY JESSADA C.
            // SET DEFAULT HIGHT OF DROPDOWN LIST
            DropDownHeight = 180;
        }
        #endregion

        #region Raise event
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <exception cref="ApplicationException"><c>ApplicationException</c>.</exception>
        protected virtual void OnReadOnlyChanged(EventArgs e)
        {
            if (ReadOnlyChanged != null)
                ReadOnlyChanged(this, e);

            if (DesignMode)
                return;

            InvalidateAppearance();
        }
        #endregion

        #region Overriden method
        #endregion

        #region Private method
        protected void UpdateAppearance(string appearanceName)
        {
            if (AppearanceName.Trim() == string.Empty)
            {
                return;
            }

            AppearanceList appearanceList = GetUsingAppearance();

            try
            {
                Appearance appearance = appearanceList[appearanceName];
                UpdateAppearance(appearance);
            }
            catch { }
        }
        protected void UpdateAppearance(Appearance appearance)
        {
            if (appearance == null)
                return;

            FontStyle fontStyle = appearance.FontStyle;

            Font font = new Font(appearance.FontName, appearance.FontSize, fontStyle);
            this.Font = font;
            this.BackColor = appearance.BackColor;
            this.ForeColor = appearance.ForeColor;

            this.Invalidate(false);
        }
        #endregion

        #region Protected method

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NullReferenceException">Not found EVOForm host.</exception>
        protected AppearanceList GetUsingAppearance()
        {
            EVOForm form = (EVOForm)FindForm();
            if (form == null)
                return null;

            if (form.AppearanceComponent != null)
            {
                return null;
            }

            return AppearanceManager.DefaultAppearanceSet;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Get or set ReadOnly.
        /// </summary>
        [DefaultValue(false)]
        public bool ReadOnly
        {
            get
            {
                return m_bReadOnly;
            }
            set
            {
                IntPtr textHwnd = Win32.GetWindow(this.Handle, Win32.GW_CHILD);
                IntPtr ptr = SendMessage(textHwnd, Win32.EM_SETREADONLY, new IntPtr(Convert.ToInt32(value)), IntPtr.Zero);

                if (ptr == IntPtr.Zero)
                    m_bReadOnly = false;
                else
                    m_bReadOnly = value;

                //Repaint client area.
                Invalidate();

                if (FindForm() == null)
                    return;

                // Raise event.
                OnReadOnlyChanged(EventArgs.Empty);
            }
        }

        [DefaultValue(false)]
        public bool AutoOpenList
        {
            get
            {
                return m_bAutoOpenList;
            }
            set
            {
                m_bAutoOpenList = value;
            }
        }
        #endregion

        #region Overriden Form
        protected override void OnGotFocus(EventArgs e)
        {
            if (ReadOnly)
            {
                this.SelectionStart = this.Text.Length;
                this.SelectionLength = 0;
            }
            else
            {
                if (AutoOpenList)
                {
                    this.DroppedDown = true;
                }
            }

            base.OnGotFocus(e);
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (ReadOnly)
            {
                e.Handled = true;
                return;
            }

            base.OnKeyPress(e);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (ReadOnly)
            {
                e.Handled = true;
                return;
            }

            base.OnKeyDown(e);
        }
        // ADD BY JESSADA C.  -- ADD TEXT PROCESS
        protected override void OnSelectedValueChanged(EventArgs e)
        {
            if (SelectedValue != null && Text != string.Empty)
            {
                m_selectedText = Text;
            }
            else
            {
                m_selectedText = string.Empty;
            }
            base.OnSelectedValueChanged(e);
        }
        protected override void OnLeave(EventArgs e)
        {
            if (Text == string.Empty)
            {
                //if (m_bAllowNullValue)
                //{
                SelectedIndex = -1;
                m_selectedText = Text;
                //}
                //else
                //{
                //    //SelectedIndex = -1;
                //    SelectedIndex = 0;
                //}
            }
            else
            {
                Text = m_selectedText;
            }


            base.OnLeave(e);
        }
        // ----- END ADD FOR TEXT PROCESS

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            //ถ้าอยู่ในโหมด ReadOnly จะไม่สามารถคลิกเมาส์ใดๆ ได้
            if (m_bReadOnly)
            {
                if (m.Msg == 0x201 //WM_LBUTTONDOWN
                    || m.Msg == 0x203) //WM_LBUTTONDBLCLK
                    return;

                if (m.Msg == 0x0102)  // WM_CHAR
                    return;
            }

            //System.Diagnostics.Debug.WriteLine(m.Msg);

            base.WndProc(ref m);
            switch (m.Msg)
            {
                case Win32.WM_CTLCOLORSTATIC:
                    base.WndProc(ref m);
                    IntPtr hdcEdit = m.WParam;
                    IntPtr hEdit = m.LParam;
                    if (hEdit != IntPtr.Zero && hdcEdit != IntPtr.Zero)
                    {
                        IntPtr hBrush = CreateSolidBrush(ColorToCOLORREF(this.BackColor));
                        SetBkColor(hdcEdit, ColorToCOLORREF(this.BackColor));
                        m.Result = hBrush;

                        //DeleteObject(hBrush);
                        return;
                    }
                    break;

                case Win32.WM_PAINT:

                    OnPaint();
                    return;
            }

        }
        #endregion

        public void OnPaint()
        {

            Rectangle rect = this.ClientRectangle;
            Graphics g = this.CreateGraphics();

            //Draw border
            if (Application.RenderWithVisualStyles)
            {
                TextBoxRenderer.DrawTextBox(g, rect, TextBoxState.Normal);
            }
            else
            {
                ControlPaint.DrawBorder3D(g, rect, Border3DStyle.Sunken, Border3DSide.All);
            }

            // Reduce rectangle by borderSize
            rect.Inflate(-SystemInformation.Border3DSize.Width, -SystemInformation.Border3DSize.Height);

            Rectangle rectButton = getButtonRect();
            if (Application.RenderWithVisualStyles)
            {
                if (m_bReadOnly || !Enabled)
                {
                    //Fill background
                    g.FillRectangle(new SolidBrush(this.BackColor), rect);
                    ComboBoxRenderer.DrawDropDownButton(g, rectButton, ComboBoxState.Disabled);
                }
                else
                {
                    //Fill background
                    g.FillRectangle(new SolidBrush(Color.White), rect);
                    ComboBoxRenderer.DrawDropDownButton(g, rectButton, ComboBoxState.Normal);
                }
            }
            else
            {
                if (m_bReadOnly || !Enabled)
                {
                    //Fill background
                    g.FillRectangle(new SolidBrush(this.BackColor), rect);
                    ControlPaint.DrawComboButton(g, rectButton, ButtonState.Inactive);
                }
                else
                {
                    //Fill background
                    g.FillRectangle(new SolidBrush(Color.White), rect);
                    ControlPaint.DrawComboButton(g, rectButton, ButtonState.Normal);
                }
            }


            g.Dispose();
        }

        /// <summary>
        /// Get Button rectangle area.
        /// </summary>
        /// <returns></returns>
        private Rectangle getButtonRect()
        {
            Rectangle rectButton = Rectangle.Empty;
            if (Application.RenderWithVisualStyles)
            {
                rectButton = this.ClientRectangle;
                rectButton.Inflate(0, -1);
                rectButton.Width = SystemInformation.VerticalScrollBarWidth;
                rectButton.Offset(this.Width - rectButton.Width - 1, 0);
            }
            else
            {
                rectButton = this.ClientRectangle;
                rectButton.Width = SystemInformation.VerticalScrollBarWidth;
                rectButton.Offset(this.Width - rectButton.Width - SystemInformation.Border3DSize.Width, 0);
                rectButton.Inflate(0, -SystemInformation.Border3DSize.Height);
            }

            return rectButton;
        }

        #region IControlIdentify Members

        /// <summary>
        /// Represents control's identify. It should be unique.
        /// It references multilanguage and mapping owner error.
        /// </summary>
        [Browsable(true)]
        [Description("Represents control's identify. It should be unique.\r\nIt references multilanguage and mapping owner error.")]
        public string ControlID { get; set; }

        #endregion

        #region IControlFocusable Members

        public void FocusOnControl()
        {
            this.Focus();
        }

        #endregion

        #region IDomainSupport Members

        /// <summary>
        /// Specifiy path value of variable's property.
        /// <para>style: [DomainName].[NestedPropertyName, ...].[ResultPropertyName]</para>
        /// <para>example: UserDomain.Username.Value</para>
        /// </summary>
        [Browsable(true)]
        [Description("Specifiy path value of variable's property.")]
        public string PathString { get; set; }

        /// <summary>
        /// Assign value.
        /// </summary>
        [Browsable(false)]
        public object PathValue
        {
            get
            {
                return this.SelectedValue;
            }
            set
            {
                if (value == null || value == DBNull.Value)
                {
                    return;
                }
                this.SelectedValue = value;
            }
        }

        #endregion

        #region IAppearance Members
        /// <summary>
        /// Name of appearance to apply.
        /// </summary>
        [DefaultValue("DataEdit")]
        public string AppearanceName
        {
            get { return m_appearanceName; }
            set { m_appearanceName = value; }
        }

        #endregion

        #region IReadOnlyAppearance Members

        /// <summary>
        /// Name of appearance to apply.
        /// </summary>
        [DefaultValue("DataReadOnly")]
        public string AppearanceReadOnlyName
        {
            get
            {
                return m_appearanceReadOnlyName;
            }
            set
            {
                m_appearanceReadOnlyName = value;
            }
        }

        #endregion

        #region Public methods
        /// <summary>
        /// Load lookup data.
        /// </summary>
        /// <param name="lookupData"></param>
        public void LoadLookupData(LookupData lookupData)
        {
            this.m_lookupData = lookupData;
            LoadLookupData(lookupData.DisplayMember, lookupData.ValueMember, lookupData.DataSource);
        }

        /// <summary>
        /// Load lookup data.
        /// </summary>
        /// <param name="displayMember"></param>
        /// <param name="valueMember"></param>
        /// <param name="dataSource"></param>
        public void LoadLookupData(string displayMember, string valueMember, object dataSource)
        {
            this.m_lookupData = new LookupData((DataTable)dataSource, displayMember, valueMember);

            DisplayMember = displayMember;
            ValueMember = valueMember;
            DataSource = dataSource;
        }

        /// <summary>
        /// Selected text on DisplayMember.
        /// </summary>
        [Browsable(false)]
        public string SelectedDisplayText
        {
            get
            {

                object objSelected = this.SelectedItem;
                if (objSelected != null)
                {
                    DataRowView view = objSelected as DataRowView;
                    if (view != null)
                    {
                        object objValue = view[this.DisplayMember];
                        if (objValue != null)
                            return objValue.ToString();
                        return string.Empty;
                    }
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// Get the last lookup data.
        /// </summary>
        public LookupData LookupData
        {
            get { return m_lookupData; }
        }

        #endregion



        #region IAppearanceUpdatable Members
        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ApplicationException"><c>ApplicationException</c>.</exception>
        public void InvalidateAppearance()
        {
            if (AppearanceReadOnlyName == null || AppearanceReadOnlyName.Trim() == string.Empty)
            {
                return;
            }

            AppearanceList appearanceList = GetUsingAppearance();
            if (appearanceList == null || appearanceList.Count <= 0)
                return;

            Appearance apr = null;
            if (this.ReadOnly)
            {
                apr = appearanceList[AppearanceReadOnlyName];
            }
            else
            {
                apr = appearanceList[AppearanceName];
            }

            UpdateAppearance(apr);
        }

        #endregion

        #region To Value
        /// <summary>
        /// Return self object.
        /// </summary>
        /// <returns></returns>
        public NZString ToNZString()
        {
            return new NZString(this, this.SelectedValue);
        }
        #endregion
    }
}

