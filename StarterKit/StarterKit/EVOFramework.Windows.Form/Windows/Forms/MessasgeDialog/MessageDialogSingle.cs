using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EVOFramework.Windows.Forms
{
    /* �˹�Ҩ� MessageDialog �м١�Ѻ PointDummy Ẻ 1-1 ����
     * ��� MessageDialog ������к� Owner ��� �������� MessasgeDialog Ẻ���������鹵��˹�Ҩ��  �������ѡɳй�������ʴ� PointDummy
     * 
     * �ء���駷��Դ MessageDialog �е�ͧ������������ PointDummy �١ Close ��� Dispose ����
     */
    internal partial class MessageDialogSingle : MessageDialogBase
    {

        #region Variables
        //private Color colorBorder = Color.FromArgb(172, 168, 153);
        //private Color colorTitleBar = Color.FromArgb(193, 210, 238);
        //private Color colorTitleBarNoActive = Color.FromArgb(212, 208, 200);
        //private Color colorCode_BK = Color.FromArgb(236, 233, 216);
        private Color colorDesc_BK = Color.FromArgb(242, 240, 230);
        private Color colorLineSeperate = Color.FromArgb(221, 217, 207);

        private Icon m_icon = SystemIcons.Error;

        #endregion

        public MessageDialogSingle()
        {
            InitializeComponent();

            pnlDesc.BackColor = colorDesc_BK;
        }

        public MessageDialogSingle(IntPtr hWndControl) : this()
        {
            SetCaptureControl(hWndControl);
        }       

        #region Overriden base-class method
        /// <summary>
        /// �ҡ�ա�û�Ѻ����¹ Information ��� Run-time ���������ö��Ѻ��ا������㹡���ʴ��Ŵ��¤���觹��
        /// </summary>
        protected override void ReloadDialog()
        {
            base.ReloadDialog();

            //Draw MessageDialogIcon            
            if (MessageDialogIcon == MessageDialogIcon.None)
                picIcon.Image = null;
            else
                picIcon.Image = GetIcon(MessageDialogIcon).ToBitmap();            
        }

        protected override void UpdateControlLocation()
        {
            //Location of 
            // - lblCaption = (10, 3)
            // - Icon = (10, 5)
            // - lblDescription = (60, 10)      

            base.UpdateControlLocation();

            picIcon.Left = LeftPadding;
            lblDescription.Left = 60;

        }        

        protected override int CalcHeightSize
        {
            get
            {
                int HDescription = 20 + lblDescription.Height;

                return base.CalcHeightSize + HDescription;
            }
        }

        protected override int CalcWidthSize
        {
            get
            {
                int WDescription = lblDescription.Left + lblDescription.Width + (LeftPadding);
                return Math.Max(base.CalcWidthSize, WDescription);
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
        
        #region Private methods
        private void SetIcon(Icon icon)
        {            
            picIcon.Image = (icon == null) ? null : icon.ToBitmap();
        }        
        #endregion
    }
}