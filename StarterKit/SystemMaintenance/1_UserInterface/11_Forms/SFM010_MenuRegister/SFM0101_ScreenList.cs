using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EVOFramework.Windows.Forms;
using EVOFramework;
using CommonLib;
using SystemMaintenance.Controller;

namespace SystemMaintenance.Forms
{
    internal partial class SFM0101_ScreenList : CustomizeBaseForm
    {
        public enum eColScreen {
            SEL, 
            SCREEN_CD,
            SCREEN_NAME,
        }

        private readonly MenuRegisterController m_menuRegisterController = new MenuRegisterController();
        private readonly NZString m_menuSubCD = null;
        private List<NZString> m_selectedScreenList = new List<NZString>();
        private DataTable m_dtView = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="MENU_SUB_CD">Exclude screen code in specific the MenuSubCD</param>
        public SFM0101_ScreenList(NZString MENU_SUB_CD)
        {
            InitializeComponent();

            this.m_menuSubCD = MENU_SUB_CD;
            DialogResult = DialogResult.Cancel;
        }

        #region Properties
        public List<NZString> SelectedScreenList {
            get { return m_selectedScreenList; }
        }
        #endregion

        #region Private method
        private void InitializeScreen() {

            //txtFind.KeyPress += CommonLib.CtrlUtil.SetRestrictKeyInput;
            //txtFind.KeyUp += CommonLib.CtrlUtil.FilterRestrictChar;

            shtScreen.ActiveSkin = Common.ACTIVE_SKIN;
            CtrlUtil.MappingDataFieldWithEnum(shtScreen, typeof(eColScreen));

            txtFind.KeyPress += CtrlUtil.SetNextControl;
            
            CtrlUtil.EnabledControl(true, txtFind, fpScreen, btnCancel, btnRegister);

            m_dtView = m_menuRegisterController.LoadAllScreenForRegister(m_menuSubCD);
            fpScreen.DataSource = FilterData(m_dtView, txtFind.Text.Trim());
        }

        private DataTable FilterData(DataTable dtView, string filterText)
        {
            if (filterText.Trim() == String.Empty)
                return dtView;

            DataRow[] rows = dtView.Select(String.Format("SCREEN_CD LIKE '%{0}%' OR SCREEN_NAME LIKE '%{0}%'", filterText));
            DataTable dtFilter = dtView.Clone();
            for (int i = 0; i < rows.Length; i++)
            {
                dtFilter.ImportRow(rows[i]);
            }

            return dtFilter;
        }
        #endregion

        #region Form events
        private void SFM011_ScreenList_Load(object sender, EventArgs e)
        {
            InitializeScreen();
        }

        private void SFM011_ScreenList_Shown(object sender, EventArgs e)
        {

        }
        #endregion

        #region Control events
        private void txtFind_KeyUp(object sender, KeyEventArgs e)
        {
            fpScreen.DataSource = FilterData(m_dtView, txtFind.Text.Trim());
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            MessageDialogResult dr = MessageDialog.ShowConfirmation(this, EVOFramework.Message.LoadMessage(Messages.eConfirm.CFM9001.ToString()));
            if (dr == MessageDialogResult.Cancel)
                return;
            
            if (dr == MessageDialogResult.No) {
                DialogResult = DialogResult.Cancel;
                return;
            }

            fpScreen.StopCellEditing();

            SelectedScreenList.Clear();

            for (int i = 0; i < shtScreen.RowCount; i++ ) {
                object objValue = shtScreen.GetValue(i, (int) eColScreen.SEL);
                if (objValue == null || Convert.ToBoolean(objValue) == false)
                    continue;

                SelectedScreenList.Add(shtScreen.GetValue(i, (int) eColScreen.SCREEN_CD).ToString().ToNZString());
            }

            DialogResult = DialogResult.OK;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_selectedScreenList.Clear();
            DialogResult = DialogResult.Cancel;
        }
        #endregion

    }
}
