using System;
using System.Data;
using System.Windows.Forms;
using SystemMaintenance.BIZ;
using CommonLib;
using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Windows.Forms;
using SystemMaintenance.Controller;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.Model;

namespace SystemMaintenance.Forms
{
    [Screen("SFM008", "Sub Menu Maintenance", eShowAction.Normal, eScreenType.Screen, "Sub Menu Maintenance")]
    internal partial class SFM008_SubMenuMaintenance : CustomizeBaseForm
    {
        #region Constant
        private const string C_STR_READY = "Ready.";
        private const string C_STR_EDITING = "Editing.";
        private const string C_STR_SAVED = "Saved.";
        #endregion

        #region Fp Column Enum
        public enum eColView {
            MENU_SUB_CD = 0,
            MENU_SUB_NAME,
            MENU_SUB_DESC,
        }
        #endregion

        #region Variables
        private readonly SubMenuMaintenanceController m_subMenuController = new SubMenuMaintenanceController();
        private DataTable m_dataTableView = null;
        #endregion

        #region Constructor
        public SFM008_SubMenuMaintenance()
        {
            InitializeComponent();                        
        }        
        #endregion

        #region Methods
        private void InitializeScreen()
        {
            //txtFind.KeyPress += CommonLib.CtrlUtil.SetRestrictKeyInput;
            //txtFind.KeyUp += CommonLib.CtrlUtil.FilterRestrictChar;

            //###################
            //Bind Spread's DataField with Enum
            //###################
            shtView.ActiveSkin = Common.ACTIVE_SKIN;

            CtrlUtil.MappingDataFieldWithEnum(fpView.Sheets[0], typeof(eColView));

            //###################
            // Load lookup combobox data.
            //###################
            LookupData();

            //###################
            // Binding event to control (movenext).
            //###################
            cboLanguage.KeyPress += CtrlUtil.SetNextControl;
            txtFind.KeyPress += CtrlUtil.SetNextControl;

            //###################
            // Binding Model
            //###################
            dmcSubMenu.AddRangeControl(
                cboLanguage,
                txtFind
                );

            //###################
            // LoadData && Assign Value to control.
            //###################
            cboLanguage.SelectedValue = Common.CurrentUserInfomation.LanguageCD.Value;


            //###################
            // Startup Enable/Disable control.
            //###################
            CtrlUtil.EnabledControl(true, cboLanguage, txtFind, fpView);
            tslEditing.Text = C_STR_READY;
        }
        private void LookupData()
        {
            // Lookup Lang
            LangBIZ bizLang = new LangBIZ();
            LookupData lookupLangData = bizLang.LoadLookup(true);
            cboLanguage.LoadLookupData(lookupLangData);
        }
        private void LoadScreen(NZString languageCD, string filterText) {
            m_dataTableView = m_subMenuController.LoadDataWithLanguage(languageCD);
            fpView.DataSource = FilterData(m_dataTableView, filterText);
        }
        private DataTable FilterData(DataTable dtView, string filterText) {
            if (filterText.Trim() == String.Empty)
                return dtView;

            DataRow[] rows = dtView.Select(String.Format("MENU_SUB_NAME LIKE '%{0}%' OR MENU_SUB_DESC LIKE '%{0}%'", filterText));
            DataTable dtFilter = dtView.Clone();
            for (int i=0; i<rows.Length; i++) {
                dtFilter.ImportRow(rows[i]);
            }

            return dtFilter;
        }
        #endregion
        
        #region Cell-Modification State

        /// <summary>
        /// Store value before enter editing cell.
        /// </summary>
        private object m_objModify = null;

        private void fpView_EditModeOn(object sender, EventArgs e)
        {
            // Store data before editing.
            m_objModify = shtView.ActiveCell.Value;
            tslEditing.Text = C_STR_EDITING;
        }

        private void fpView_EditModeOff(object sender, EventArgs e)
        {
            // Check different between new value and old value.
            object newValue = shtView.ActiveCell.Value;
            if (!Equals(m_objModify, newValue)) {

                Cell cell = shtView.Cells.Get(shtView.ActiveRowIndex, (int) eColView.MENU_SUB_CD);

                // Raise event changed value on cell.
                m_subMenuController.SaveMenuSubDescription(
                    new NZString(cboLanguage, cboLanguage.SelectedValue),
                    new NZString(null, cell.Value),
                    new NZString(null, shtView.ActiveCell.Value));                
            }

            tslEditing.Text = C_STR_SAVED;
        }

 
        #endregion

        #region Form events
        private void SFM008_SubMenuMaintenance_Load(object sender, EventArgs e)
        {
            InitializeScreen();
        }

        private void cboLanguage_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboLanguage.SelectedValue != null)
                LoadScreen(new NZString(null, cboLanguage.SelectedValue), txtFind.Text.Trim());
        }

        private void txtFind_KeyUp(object sender, KeyEventArgs e)
        {
            fpView.DataSource = FilterData(m_dataTableView, txtFind.Text.Trim());
        }
        #endregion

        #region Spread events
        private void fpView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) {
                
                bool isClickOnCell = false;

                CellRange cellRange = fpView.GetCellFromPixel(0, 0, e.X, e.Y);
                if (cellRange.Column != -1 && cellRange.Row != -1) {
                    fpView.ActiveSheet.SetActiveCell(cellRange.Row, cellRange.Column);
                    isClickOnCell = true;
                }

                if (isClickOnCell) {
                    mnuAddSubMenu.Enabled = true;
                    mnuDeleteSubMenu.Enabled = true;
                    mnuProperties.Enabled = true;
                } else {
                    mnuAddSubMenu.Enabled = true;
                    mnuDeleteSubMenu.Enabled = false;
                    mnuProperties.Enabled = false;
                }

                ctxMenu.Show(fpView, e.Location);
            }


        }
        #endregion

        #region Context Menu events
        private void mnuAddSubMenu_Click(object sender, EventArgs e)
        {
            SFM0081_AddSubMenu form = new SFM0081_AddSubMenu();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                LoadScreen(
                    new NZString(null, cboLanguage.SelectedValue),
                    txtFind.Text.Trim()
                    );
            }
        }

        private void mnuDeleteSubMenu_Click(object sender, EventArgs e)
        {
            if (MessageDialog.ShowConfirmation(this, EVOFramework.Message.LoadMessage(Messages.eConfirm.CFM9002.ToString()), MessageDialogButtons.YesNo) == MessageDialogResult.No)
                return;

            try {

                NZString menuSubCD = new NZString(null, shtView.GetValue(shtView.ActiveRowIndex, (int) eColView.MENU_SUB_CD));
                m_subMenuController.DeleteMenuSub(menuSubCD);

                LoadScreen(
                    new NZString(null, cboLanguage.SelectedValue),
                    txtFind.Text.Trim()
                    );
            } catch (Exception err) {
                MessageDialog.ShowBusiness(this, err.Message);
            }
        }

        private void mnuProperties_Click(object sender, EventArgs e)
        {
            string menuSubCD = shtView.GetValue(shtView.ActiveRowIndex, (int)eColView.MENU_SUB_CD).ToString();
            string menuSubName = shtView.GetValue(shtView.ActiveRowIndex, (int) eColView.MENU_SUB_NAME).ToString();
            SFM0082_EditSubMenu form = new SFM0082_EditSubMenu(menuSubCD, menuSubName);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                LoadScreen(
                    new NZString(null, cboLanguage.SelectedValue),
                    txtFind.Text.Trim()
                    );
            }
        }
        #endregion



    }
}
