using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using EVOFramework.Windows.Forms;
using CommonLib;
using SystemMaintenance.Controller;
using SystemMaintenance.UIDM;
using EVOFramework;
using Message=EVOFramework.Message;

namespace SystemMaintenance.Forms
{
    [Screen("SFM010", "Menu Register", eShowAction.Normal, eScreenType.Screen, "Menu Register")]
    internal partial class SFM010_MenuRegister : CustomizeBaseForm
    {
        #region Enumerator
        public enum eColScreen {
            SEL,
            SCREEN_CD,
            SCREEN_NAME,
        }
        #endregion

        #region Variables
        private readonly MenuRegisterController m_menuRegisterController = new MenuRegisterController();
        #endregion

        #region Constructor
        public SFM010_MenuRegister()
        {
            InitializeComponent();
        }
        #endregion

        #region Private Methods
        private void InitializeScreen() {
            shtScreen.ActiveSkin = Common.ACTIVE_SKIN;
            CtrlUtil.MappingDataFieldWithEnum(shtScreen, typeof(eColScreen));

            ReloadMenuSetTree();
            trvMenu.ExpandAll();

            CtrlUtil.EnabledControl(false, fpScreen);
            CtrlUtil.EnabledControl(true, trvMenu);
        }

        private void ReloadMenuSetTree() {
            trvMenu.SuspendLayout();

            try {
                MenuRegisterUIDM model = m_menuRegisterController.LoadMenuList();
                trvMenu.Nodes.Clear();

                for (int i = 0; i < model.ListMenuHierachy.Count; i++) {
                    MenuRegisterUIDM.MenuSet menuSet = model.ListMenuHierachy[i];

                    
                    TreeNode rootNode = new TreeNode();                    
                    rootNode.Text = menuSet.MENU_SET_NAME.StrongValue;
                    rootNode.Tag = menuSet;

                    for (int iChild = 0; iChild < menuSet.ListMenuSub.Count; iChild++) {
                        MenuRegisterUIDM.MenuSub menuSub = menuSet.ListMenuSub[iChild];
                        
                        TreeNode childNode = new TreeNode();
                        childNode.Text = menuSub.MENU_SUB_DESC.NVL(String.Empty);
                        childNode.Tag = menuSub;
                        rootNode.Nodes.Add(childNode);
                    }

                    trvMenu.Nodes.Add(rootNode);
                }
            }
            finally {
                trvMenu.ResumeLayout(false);
            }
        }
        private void LoadScreens(NZString menuSubCD) {
            // Show screen list of selected MenuSub.
            DataTable dtView = m_menuRegisterController.LoadScreenFromMenuSub(menuSubCD);
            fpScreen.DataSource = dtView;
            CtrlUtil.EnabledControl(true, fpScreen);
        }

        private void UpdateButtonMoveEnable()
        {
            int rowIndex = shtScreen.ActiveRowIndex;
            int rowCount = shtScreen.RowCount;

            if (rowCount == 0 || rowIndex < 0 || (rowIndex == 0 && rowCount == 1))
            {
                CtrlUtil.EnabledControl(false, btnMoveUp, btnMoveDown);
                return;
            }

            if (rowIndex == 0)
            {
                CtrlUtil.EnabledControl(false, btnMoveUp);
                CtrlUtil.EnabledControl(true, btnMoveDown);
            }
            else if (rowIndex == rowCount - 1)
            {
                CtrlUtil.EnabledControl(true, btnMoveUp);
                CtrlUtil.EnabledControl(false, btnMoveDown);
            }
            else
            {
                CtrlUtil.EnabledControl(true, btnMoveUp);
                CtrlUtil.EnabledControl(true, btnMoveDown);
            }
        }
        /// <summary>
        /// Adjust position sequence to display.
        /// </summary>
        /// <param name="direction">UP, DOWN</param>
        /// <param name="menuSubCD">MenuSub Code.</param>
        /// <param name="rowIndex">Current selected row index on spread sheet.</param>
        private void AdjustScreenSequence(string direction, NZString menuSubCD, int rowIndex)
        {

            NZString screenCodeOld = shtScreen.GetValue(rowIndex, (int)eColScreen.SCREEN_CD).ToString().ToNZString();



            NZString screenCodeNew = null;
            if (direction == "UP")
            {
                screenCodeNew = shtScreen.GetValue(rowIndex - 1, (int)eColScreen.SCREEN_CD).ToString().ToNZString();
            }
            else
            {
                screenCodeNew = shtScreen.GetValue(rowIndex + 1, (int)eColScreen.SCREEN_CD).ToString().ToNZString();
            }

            m_menuRegisterController.SwapDisplaySequence(menuSubCD, screenCodeOld, menuSubCD, screenCodeNew);
        }
        #endregion

        #region  Events All
        #region Form event
        private void SFM010_MenuRegister_Load(object sender, EventArgs e)
        {
            InitializeScreen();
        }
        private void SFM010_MenuRegister_Shown(object sender, EventArgs e)
        {            
            trvMenu.Focus();
        }
        #endregion

        #region TreeView event
        private void trvMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is MenuRegisterUIDM.MenuSub)
            {
                // Show screen list of selected MenuSub.
                MenuRegisterUIDM.MenuSub menuSub = e.Node.Tag as MenuRegisterUIDM.MenuSub;
                LoadScreens(menuSub.MENU_SUB_CD);

                
                shtScreen.SetActiveCell(0, 0);
                shtScreen.AddSelection(0, 0, 1, 1);
                UpdateButtonMoveEnable();
            }
            else
            {
                // Clear screen list.
                fpScreen.ActiveSheet.RowCount = 0;
                fpScreen.DataSource = null;
                UpdateButtonMoveEnable();
                CtrlUtil.EnabledControl(false, fpScreen);
                
            }
        }
        private void trvMenu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                mnuRegisterScreen.Enabled = true;
                mnuRemoveScreen.Enabled = false;

                ctxMenu.Show(trvMenu, e.Location);
            }
        }
        #endregion

        #region FarPoint event
        private void fpScreen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                fpScreen.StopCellEditing();

                bool bHasSelected = false;
                for (int i = 0; i < shtScreen.Rows.Count; i++) {
                    object objSEL = shtScreen.GetValue(i, (int) eColScreen.SEL);
                    if (objSEL == null || Convert.ToBoolean(objSEL) == false)
                        continue;

                    bHasSelected = true;
                    break;
                }

                if (bHasSelected) {
                    mnuRegisterScreen.Enabled = true;
                    mnuRemoveScreen.Enabled = true;
                } else {
                    mnuRegisterScreen.Enabled = true;
                    mnuRemoveScreen.Enabled = false;
                }
                
                ctxMenu.Show(fpScreen, e.Location);
            }
        }
        #endregion

        #region Context Menu Click events
        private void mnuRegisterScreen_Click(object sender, EventArgs e)
        {
            MenuRegisterUIDM.MenuSub menuSub = trvMenu.SelectedNode.Tag as MenuRegisterUIDM.MenuSub;
            if (menuSub == null)
                return;

            SFM0101_ScreenList form = new SFM0101_ScreenList(menuSub.MENU_SUB_CD);
            if (form.ShowDialog(this) == DialogResult.OK) {
                m_menuRegisterController.RegisterScreen(menuSub.MENU_SUB_CD, form.SelectedScreenList.ToArray());

                LoadScreens(menuSub.MENU_SUB_CD);
            }

            UpdateButtonMoveEnable();
        }

        private void mnuRemoveScreen_Click(object sender, EventArgs e)
        {
            if (MessageDialog.ShowConfirmation(this, Message.LoadMessage(Messages.eConfirm.CFM9002.ToString()), MessageDialogButtons.YesNo) == MessageDialogResult.No)
                return;

            List<NZString> listSCREEN_CD = new List<NZString>();
            for (int i=0; i<shtScreen.RowCount; i++) {
                object objSEL = shtScreen.GetValue(i, (int) eColScreen.SEL);
                if (objSEL == null || Convert.ToBoolean(objSEL) == false)
                    continue;

                listSCREEN_CD.Add(new NZString(null, shtScreen.GetValue(i, (int)eColScreen.SCREEN_CD).ToString()));
            }

            MenuRegisterUIDM.MenuSub menuSub = trvMenu.SelectedNode.Tag as MenuRegisterUIDM.MenuSub;
            if (menuSub == null)
                return;

            try {
                m_menuRegisterController.RemoveScreen(menuSub.MENU_SUB_CD, listSCREEN_CD.ToArray());
                LoadScreens(menuSub.MENU_SUB_CD);
                
            } catch (Exception err) {
                MessageDialog.ShowBusiness(this, err.Message);
            }

            UpdateButtonMoveEnable();
        }
        #endregion
        
        #region Button Move Sequence UP/DOWN        
        private void fpScreen_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            UpdateButtonMoveEnable();
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            MenuRegisterUIDM.MenuSub menuSub = trvMenu.SelectedNode.Tag as MenuRegisterUIDM.MenuSub;
            if (menuSub == null)
                return;

            int colIndex = shtScreen.ActiveColumnIndex;
            int rowIndex = shtScreen.ActiveRowIndex;            
            AdjustScreenSequence("UP", menuSub.MENU_SUB_CD, rowIndex);

            LoadScreens(menuSub.MENU_SUB_CD);

            shtScreen.SetActiveCell(rowIndex - 1, colIndex);
            shtScreen.AddSelection(rowIndex - 1, colIndex, 1, 1);

            UpdateButtonMoveEnable();
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            MenuRegisterUIDM.MenuSub menuSub = trvMenu.SelectedNode.Tag as MenuRegisterUIDM.MenuSub;
            if (menuSub == null)
                return;

            int colIndex = shtScreen.ActiveColumnIndex;
            int rowIndex = shtScreen.ActiveRowIndex;
            AdjustScreenSequence("DOWN", menuSub.MENU_SUB_CD, rowIndex);

            LoadScreens(menuSub.MENU_SUB_CD);

            shtScreen.SetActiveCell(rowIndex + 1, colIndex);
            shtScreen.AddSelection(rowIndex + 1, colIndex, 1, 1);

            UpdateButtonMoveEnable();
        }        
        #endregion        
        #endregion

    }
}
