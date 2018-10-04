using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EVOFramework.Windows.Forms
{
    internal partial class MessageDialogMulti : MessageDialogBase
    {
        #region Variables
        private WarningItemList m_warningList = new WarningItemList();
        #endregion

        #region Constructor
        public MessageDialogMulti()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get or set member of this collection.
        /// </summary>
        public WarningItemList Items
        {
            get { return m_warningList; }
        }
        #endregion

        #region Overriden base-class method
        /// <summary>
        /// หากมีการปรับเปลี่ยน Information ขณะ Run-time ผู้ใช้สามารถปรับปรุงข้อมูลในการแสดงผลด้วยคำสั่งนี้
        /// </summary>
        protected override void ReloadDialog()
        {            

            //Draw MessageDialogIcon            
            #region Set Icon to display
            if (MessageDialogIcon == MessageDialogIcon.None)
                picIcon.Image = null;
            else
                picIcon.Image = GetIcon(MessageDialogIcon).ToBitmap();
            #endregion

            //Load WarningItem fill into GridView
            #region Generate WarningList to GridView
            gridWarning.Rows.Clear();
            gridWarning.Rows.Add(m_warningList.Count);
            int iMaxWidthColumn = 10;
            using (Graphics g = gridWarning.CreateGraphics())
            {
                for (int i = 0; i < m_warningList.Count; i++)
                {
                    gridWarning.Rows[i].Cells[0].Value = Convert.ToString(i + 1);
                    gridWarning.Rows[i].Cells[1].Value = m_warningList[i].MessageCode;
                    gridWarning.Rows[i].Cells[2].Value = m_warningList[i].MessageDescription;

                    iMaxWidthColumn = Math.Max(iMaxWidthColumn, g.MeasureString(m_warningList[i].MessageDescription, gridWarning.Font).ToSize().Width);
                }

                //Set width-limit size
                if (iMaxWidthColumn > 500)
                    iMaxWidthColumn = 500;

                gridWarning.Columns[2].Width = iMaxWidthColumn;
            }

            //################3
            // Get sum row's height + column header height.
            // Sum Height of all row must < 500
            //################3
            int iSumRowHeight = 0;
            int iVScroll = 0;
            for (int i = 0; i < gridWarning.Rows.Count; i++)
            {
                iSumRowHeight += gridWarning.Rows[i].Height;
            }
            iSumRowHeight += gridWarning.ColumnHeadersHeight;

            if (iSumRowHeight > 600)
            {
                iSumRowHeight = 600;
                iVScroll = SystemInformation.VerticalScrollBarWidth;
            }

            gridWarning.Height = iSumRowHeight;

            //################3
            //Resize to fit Height and Width size GridView
            //################3
            gridWarning.Width = gridWarning.Columns[0].Width + gridWarning.Columns[1].Width + gridWarning.Columns[2].Width + 5 + iVScroll;
           
            #endregion

            base.ReloadDialog();
        }

        protected override void UpdateControlLocation()
        {
            base.UpdateControlLocation();

            //Location of 
            // - lblCaption = (10, 3)
            // - Icon = (10, 5)
            // - lblDescription = (60, 10)      

            picIcon.Left = LeftPadding;
            lblDescription.Left = 60;

            gridWarning.Top = Math.Max(picIcon.Bottom, lblDescription.Bottom) + 10;

        } 

        protected override int CalcWidthSize
        {
            get
            {
                int maxWidth = Math.Max(base.CalcWidthSize, gridWarning.Right + 10);
                return maxWidth;
            }
        }

        protected override int CalcHeightSize
        {
            get
            {
                return base.CalcHeightSize + gridWarning.Bottom + 10;
            }
        }
        #endregion

        #region Properties
        [Browsable(true)]
        public string TextDescription
        {
            get { return lblDescription.Text; }
            set { lblDescription.Text = value; }
        }
        #endregion 
    }

    
    public class WarningItemList : CollectionBase
    {
        public WarningLineItem this[int index]
        {
            get { return List[index] as WarningLineItem; }
            set { List[index] = value; }
        }

        public void Add(WarningLineItem item)
        {
            this.List.Add(item);
        }
        public void Remove(WarningLineItem item)
        {
            List.Remove(item);
        }        
    }
    public class WarningLineItem
    {
        private string m_strMsgCode = String.Empty;
        private string m_strMsgDesc = String.Empty;
        private IntPtr m_hWndControl = IntPtr.Zero;

        public WarningLineItem(string msgCode, string msgDesc, IntPtr hWndControl)
        {
            m_strMsgCode = msgCode;
            m_strMsgDesc = msgDesc;
            m_hWndControl = hWndControl;
        }

        public WarningLineItem(string msgCode, string msgDesc) : this(msgCode, msgDesc, IntPtr.Zero) { }

        /// <summary>
        /// Get Message code.
        /// </summary>
        public string MessageCode
        {
            get { return m_strMsgCode; }
        }

        /// <summary>
        /// Get Message description.
        /// </summary>
        public string MessageDescription
        {
            get { return m_strMsgDesc; }
        }

        /// <summary>
        /// Get handle control.
        /// </summary>
        public IntPtr HandleControl
        {
            get { return m_hWndControl; }
        }

        /// <summary>
        /// Check that HandleControl has specified.
        /// </summary>
        public bool HasHandleControl
        {
            get { return (m_hWndControl == IntPtr.Zero); }
        }

        public override string ToString()
        {
            return String.Format("{0},{1}", MessageCode, MessageDescription);
        }
    }
    
}
