using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EVOFramework;
using SystemMaintenance.Controller;
using EVOFramework.Windows.Forms;

namespace SystemMaintenance.Forms
{
    [Screen("SFM009", "Menu Set Maintenance", eShowAction.Normal, eScreenType.Screen, "Menu Set Maintenance")]
    public partial class SFM009_MenuSetMaintenance : CustomizeBaseForm
    {
        #region Enum
        enum eColMenuSet
        {
            MENU_SET_CD,
            MENU_SET_NAME
        }
        enum eColMenuSub
        {
            MENU_SUB_CD,
            MENU_SUB_NAME,
            DISP_SEQ
        }
        enum eSeqUpdate
        {
            UP,
            DOWN
        }
        #endregion

        #region Variable
        string m_OldMenuSetDesc = string.Empty;
        int m_OldActiveRow = -1;
        #endregion

        #region Contructor
        public SFM009_MenuSetMaintenance()
        {
            InitializeComponent();
        }
        #endregion

        #region Form Event
        private void SFM009_MenuSetMaintenance_Load(object sender, EventArgs e)
        {
            InitialScreen();
        }
        #endregion

        #region Spread Event
        private void fpMenuSet_EditModeOn(object sender, EventArgs e)
        {
            int activeRow = shtMenuSet.ActiveRowIndex;
            m_OldMenuSetDesc = shtMenuSet.Cells[activeRow, (int)eColMenuSet.MENU_SET_NAME].Text;

        }

        private void fpMenuSet_EditModeOff(object sender, EventArgs e)
        {
            int activeRow = shtMenuSet.ActiveRowIndex;
            string menuSetDesc = shtMenuSet.Cells[activeRow, (int)eColMenuSet.MENU_SET_NAME].Text;
            string menuSetCD = shtMenuSet.Cells[activeRow, (int)eColMenuSet.MENU_SET_CD].Text;
            if (menuSetDesc == m_OldMenuSetDesc)
                return;
            SaveMenuSetDesc(menuSetCD, menuSetDesc);
        }

        private void fpMenuSet_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            if (shtMenuSet.Rows.Count == 0) return;

            int activeRow = shtMenuSet.ActiveRowIndex;

            if (shtMenuSet.ActiveRowIndex < 0) return;
            if (m_OldActiveRow == activeRow) return;
            LoadMenuSetDetail();
        }

        #endregion

        #region Private Method
        private void InitialScreen()
        {
            shtMenuSet.ActiveSkin = CommonLib.Common.ACTIVE_SKIN;
            shtMenuSub.ActiveSkin = CommonLib.Common.ACTIVE_SKIN;

            shtMenuSet.Columns[(int)eColMenuSet.MENU_SET_CD].Locked = true;
            shtMenuSub.Columns[(int)eColMenuSub.MENU_SUB_CD].Locked = true;
            shtMenuSub.Columns[(int)eColMenuSub.MENU_SUB_NAME].Locked = true;

            shtMenuSet.Columns[(int)eColMenuSet.MENU_SET_NAME].ForeColor = Color.Blue;

            MapDataField();

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                MenuSetMaintenanceController ctlMenuSet = new MenuSetMaintenanceController();
                DataTable dtMenuSet = ctlMenuSet.LoadAllMenuSet();
                if (dtMenuSet != null && dtMenuSet.Rows.Count > 0)
                {
                    shtMenuSet.DataSource = dtMenuSet;
                    shtMenuSet.AddSelection(0, 0, 1, 2);
                    string MenuSetCD = shtMenuSet.Cells[0, (int)eColMenuSet.MENU_SET_CD].Text;
                    DataTable dtMenuSub = ctlMenuSet.LoadMenuSubByMenuSetCD(MenuSetCD);
                    shtMenuSub.DataSource = dtMenuSub;
                }

            }
            catch (ValidateException err)
            {
                for (int i = 0; i < err.ErrorResults.Count; i++)
                {
                    MessageBox.Show(err.ErrorResults[i].Message.MessageDescription);
                    err.ErrorResults[i].FocusOnControl();
                }
                if (CommonLib.Common.CurrentDatabase.DBTransactionState == EVOFramework.Database.TransactionState.PROCESSING)
                    CommonLib.Common.CurrentDatabase.Rollback();
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message.MessageDescription);
                if (CommonLib.Common.CurrentDatabase.DBTransactionState == EVOFramework.Database.TransactionState.PROCESSING)
                    CommonLib.Common.CurrentDatabase.Rollback();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
                if (CommonLib.Common.CurrentDatabase.DBTransactionState == EVOFramework.Database.TransactionState.PROCESSING)
                    CommonLib.Common.CurrentDatabase.Rollback();
            }
        }

        private void MapDataField()
        {
            string[] MenuSetNames = Enum.GetNames(typeof(eColMenuSet));
            for (int i = 0; i < MenuSetNames.Length; i++)
            {
                shtMenuSet.Columns[i].DataField = MenuSetNames[i];
            }

            string[] MenuSubNames = Enum.GetNames(typeof(eColMenuSub));
            for (int i = 0; i < MenuSubNames.Length; i++)
            {
                shtMenuSub.Columns[i].DataField = MenuSubNames[i];
            }
        }

        private void SaveMenuSetDesc(string menuSetCD, string menuSetDesc)
        {
            try
            {
                CommonLib.Common.CurrentDatabase.KeepConnection = true;
                CommonLib.Common.CurrentDatabase.BeginTransaction();
                MenuSetMaintenanceController ctlMenuSet = new MenuSetMaintenanceController();
                ctlMenuSet.SaveMenuSetDesc(menuSetCD, menuSetDesc);

                CommonLib.Common.CurrentDatabase.Commit();
            }
            catch (ValidateException err)
            {
                for (int i = 0; i < err.ErrorResults.Count; i++)
                {
                    MessageBox.Show(err.ErrorResults[i].Message.MessageDescription);
                    err.ErrorResults[i].FocusOnControl();
                }
                if (CommonLib.Common.CurrentDatabase.DBTransactionState == EVOFramework.Database.TransactionState.PROCESSING)
                    CommonLib.Common.CurrentDatabase.Rollback();
                shtMenuSet.Cells[shtMenuSet.ActiveRowIndex, (int)eColMenuSet.MENU_SET_NAME].Text = m_OldMenuSetDesc;
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message.MessageDescription);
                if (CommonLib.Common.CurrentDatabase.DBTransactionState == EVOFramework.Database.TransactionState.PROCESSING)
                    CommonLib.Common.CurrentDatabase.Rollback();
                shtMenuSet.Cells[shtMenuSet.ActiveRowIndex, (int)eColMenuSet.MENU_SET_NAME].Text = m_OldMenuSetDesc;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
                if (CommonLib.Common.CurrentDatabase.DBTransactionState == EVOFramework.Database.TransactionState.PROCESSING)
                    CommonLib.Common.CurrentDatabase.Rollback();
                shtMenuSet.Cells[shtMenuSet.ActiveRowIndex, (int)eColMenuSet.MENU_SET_NAME].Text = m_OldMenuSetDesc;
            }
        }

        private void OpenAddMenuSetForm()
        {
            SFM0091_AddMenuSet frmAddMenu = new SFM0091_AddMenuSet();
            frmAddMenu.ShowDialog();

            LoadData();
        }

        private void deleteMenuSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (ShowConfirmMessage(Messages.eConfirm.CFM9002))
            {
                case MessageDialogResult.Cancel:
                case MessageDialogResult.No:
                    return;

                case MessageDialogResult.Yes:
                    break;

            }
            string menuSetCD = shtMenuSet.Cells[shtMenuSet.ActiveRowIndex, (int)eColMenuSet.MENU_SET_CD].Text;
            DeleteMenuSet(menuSetCD);
        }

        private MessageDialogResult ShowConfirmMessage(Messages.eConfirm msgCD)
        {
            // show confirm message
            MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new EVOFramework.Message(msgCD.ToString()).MessageDescription);
            return dr;
        }

        private void DeleteMenuSet(string menuSetCD)
        {
            try
            {
                MenuSetMaintenanceController ctlMenuSet = new MenuSetMaintenanceController();
                ctlMenuSet.DeleteMenuSet(menuSetCD);

                shtMenuSet.RemoveRows(shtMenuSet.ActiveRowIndex, 1);
            }
            catch (ValidateException err)
            {
                for (int i = 0; i < err.ErrorResults.Count; i++)
                {
                    MessageBox.Show(err.ErrorResults[i].Message.MessageDescription);
                    err.ErrorResults[i].FocusOnControl();
                }
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message.MessageDescription);

            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);

            }
        }

        private void LoadMenuSetDetail()
        {
            int activeRow = shtMenuSet.ActiveRowIndex;

            MenuSetMaintenanceController ctlMenuSet = new MenuSetMaintenanceController();
            string MenuSetCD = shtMenuSet.Cells[activeRow, (int)eColMenuSet.MENU_SET_CD].Text;
            DataTable dtMenuSub = ctlMenuSet.LoadMenuSubByMenuSetCD(MenuSetCD);
            shtMenuSub.DataSource = dtMenuSub;
            m_OldActiveRow = activeRow;
        }

        private void RemoveSubMenu(string menuSetCD, string menuSubCD)
        {
            try
            {
                MenuSetMaintenanceController ctlMenuSet = new MenuSetMaintenanceController();
                ctlMenuSet.DeleteMenuSetDetail(menuSetCD, menuSubCD);
                shtMenuSub.RemoveRows(shtMenuSub.ActiveRowIndex, 1);
            }
            catch (ValidateException err)
            {
                for (int i = 0; i < err.ErrorResults.Count; i++)
                {
                    MessageBox.Show(err.ErrorResults[i].Message.MessageDescription);
                    err.ErrorResults[i].FocusOnControl();
                }
                if (CommonLib.Common.CurrentDatabase.DBTransactionState == EVOFramework.Database.TransactionState.PROCESSING)
                    CommonLib.Common.CurrentDatabase.Rollback();
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message.MessageDescription);
                if (CommonLib.Common.CurrentDatabase.DBTransactionState == EVOFramework.Database.TransactionState.PROCESSING)
                    CommonLib.Common.CurrentDatabase.Rollback();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
                if (CommonLib.Common.CurrentDatabase.DBTransactionState == EVOFramework.Database.TransactionState.PROCESSING)
                    CommonLib.Common.CurrentDatabase.Rollback();
            }
        }
        #endregion

        #region Control Event
        private void addMenuSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenAddMenuSetForm();
        }
        private void registSubMenuToMenuSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (shtMenuSet.Rows.Count == 0) return;

            int activeRow = shtMenuSet.ActiveRowIndex;

            if (shtMenuSet.ActiveRowIndex < 0) return;

            string menuSetCD = shtMenuSet.Cells[activeRow, (int)eColMenuSet.MENU_SET_CD].Text;
            SFM0092_RegistSubMenu frmRegistSubMenu = new SFM0092_RegistSubMenu(menuSetCD);
            frmRegistSubMenu.ShowDialog();

            LoadMenuSetDetail();
        }

        private void removeSubMenuFromMenuSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (shtMenuSub.Rows.Count == 0) return;

            int activeRow = shtMenuSub.ActiveRowIndex;

            if (shtMenuSub.ActiveRowIndex < 0) return;

            switch (ShowConfirmMessage(Messages.eConfirm.CFM9002))
            {
                case MessageDialogResult.Cancel:
                case MessageDialogResult.No:
                    return;

                case MessageDialogResult.Yes:
                    break;

            }
            string menuSetCD = shtMenuSet.Cells[shtMenuSet.ActiveRowIndex, (int)eColMenuSet.MENU_SET_CD].Text;
            string menuSubCD = shtMenuSub.Cells[shtMenuSub.ActiveRowIndex, (int)eColMenuSub.MENU_SUB_CD].Text;
            RemoveSubMenu(menuSetCD, menuSubCD);
        }

        #endregion

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (shtMenuSub.Rows.Count < 2) return;
            if (shtMenuSub.ActiveRowIndex <= 0) return;
            string MenuSetCD = shtMenuSet.Cells[shtMenuSet.ActiveRowIndex, (int)eColMenuSet.MENU_SET_CD].Text;
            string MenuSubCD_UP = shtMenuSub.Cells[shtMenuSub.ActiveRowIndex, (int)eColMenuSub.MENU_SUB_CD].Text;
            string MenuSubCD_DOWN = shtMenuSub.Cells[shtMenuSub.ActiveRowIndex - 1, (int)eColMenuSub.MENU_SUB_CD].Text;
            int DisplaySQ_UP = Convert.ToInt32(shtMenuSub.Cells[shtMenuSub.ActiveRowIndex - 1, (int)eColMenuSub.DISP_SEQ].Value);
            int DisplaySQ_DOWN = Convert.ToInt32(shtMenuSub.Cells[shtMenuSub.ActiveRowIndex, (int)eColMenuSub.DISP_SEQ].Value);
            UpdateDisplaySEQ(eSeqUpdate.UP, MenuSetCD, MenuSubCD_UP, MenuSubCD_DOWN, DisplaySQ_UP, DisplaySQ_DOWN);
            LoadMenuSetDetail();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (shtMenuSub.Rows.Count < 2) return;
            if (shtMenuSub.ActiveRowIndex < 0) return;
            if (shtMenuSub.ActiveRowIndex == shtMenuSub.Rows.Count - 1) return;
            string MenuSetCD = shtMenuSet.Cells[shtMenuSet.ActiveRowIndex, (int)eColMenuSet.MENU_SET_CD].Text;
            string MenuSubCD_UP = shtMenuSub.Cells[shtMenuSub.ActiveRowIndex + 1, (int)eColMenuSub.MENU_SUB_CD].Text;
            string MenuSubCD_DOWN = shtMenuSub.Cells[shtMenuSub.ActiveRowIndex, (int)eColMenuSub.MENU_SUB_CD].Text;
            int DisplaySQ_UP = Convert.ToInt32(shtMenuSub.Cells[shtMenuSub.ActiveRowIndex, (int)eColMenuSub.DISP_SEQ].Value);
            int DisplaySQ_DOWN = Convert.ToInt32(shtMenuSub.Cells[shtMenuSub.ActiveRowIndex + 1, (int)eColMenuSub.DISP_SEQ].Value);
            UpdateDisplaySEQ(eSeqUpdate.DOWN, MenuSetCD, MenuSubCD_UP, MenuSubCD_DOWN, DisplaySQ_UP, DisplaySQ_DOWN);
            LoadMenuSetDetail();
        }

        private void UpdateDisplaySEQ(eSeqUpdate eSeqUpdate, string MenuSetCD, string MenuSubCD_UP, string MenuSubCD_DOWN, int DisplaySQ_UP, int DisplaySQ_DOWN)
        {
            try
            {
                MenuSetMaintenanceController ctlMenuSet = new MenuSetMaintenanceController();
                ctlMenuSet.UpdateDisplaySEQ(MenuSetCD, MenuSubCD_UP, MenuSubCD_DOWN, DisplaySQ_UP, DisplaySQ_DOWN);

            }
            catch (ValidateException err)
            {
                for (int i = 0; i < err.ErrorResults.Count; i++)
                {
                    MessageBox.Show(err.ErrorResults[i].Message.MessageDescription);
                    err.ErrorResults[i].FocusOnControl();
                }
                if (CommonLib.Common.CurrentDatabase.DBTransactionState == EVOFramework.Database.TransactionState.PROCESSING)
                    CommonLib.Common.CurrentDatabase.Rollback();
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message.MessageDescription);
                if (CommonLib.Common.CurrentDatabase.DBTransactionState == EVOFramework.Database.TransactionState.PROCESSING)
                    CommonLib.Common.CurrentDatabase.Rollback();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
                if (CommonLib.Common.CurrentDatabase.DBTransactionState == EVOFramework.Database.TransactionState.PROCESSING)
                    CommonLib.Common.CurrentDatabase.Rollback();
            }
        }


    }
}
