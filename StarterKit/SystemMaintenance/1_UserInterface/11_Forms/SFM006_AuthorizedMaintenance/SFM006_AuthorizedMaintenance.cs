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
using FarPoint.Win.Spread.CellType;
using SystemMaintenance.DTO;
using FarPoint.Win.Spread.Model;

namespace SystemMaintenance.Forms
{
    [Screen("SFM006", "Authorized Maintenance", eShowAction.Normal, eScreenType.Screen, "Authorized Maintenance")]
    public partial class SFM006_AuthorizedMaintenance : CustomizeBaseForm
    {
        #region Enum
        enum eColScreenList
        {
            SCREEN_CD,
            SCREEN_NAME
        }
        enum eColGroupScreenPermission
        {
            GROUP_NAME,
            FLG_VIEW,
            FLG_ADD,
            FLG_CHG,
            FLG_DEL,
            GROUP_CD
        }

        enum eColUserScreenPermission
        {
            USER_ACCOUNT,
            FLG_VIEW,
            FLG_ADD,
            FLG_CHG,
            FLG_DEL,
            USER_CD
        }

        private enum eSection
        {
            GroupScreenPermission,
            UserScreenPermission,
        }
        #endregion

        #region Member Variable
        DataTable m_dtScreenList;
        #endregion

        #region Constructor
        public SFM006_AuthorizedMaintenance()
        {
            InitializeComponent();
        }

        #endregion

        #region Form Event
        private void SFM006_AuthorizedMaintenance_Load(object sender, EventArgs e)
        {
            InitialScreen();
        }
        #endregion

        #region Private Method
        private void InitialScreen()
        {
            //txtFind.KeyPress += CommonLib.CtrlUtil.SetRestrictKeyInput;
            //txtFind.KeyUp += CommonLib.CtrlUtil.FilterRestrictChar;

            shtScreenList.Columns[(int)eColScreenList.SCREEN_CD].DataField = "SCREEN_CD";
            shtScreenList.Columns[(int)eColScreenList.SCREEN_NAME].DataField = "SCREEN_NAME";
            shtScreenList.ActiveSkin = CommonLib.Common.ACTIVE_SKIN;
            shtGroupPermission.ActiveSkin = CommonLib.Common.ACTIVE_SKIN;
            shtUserPermission.ActiveSkin = CommonLib.Common.ACTIVE_SKIN;

            LoadScreenList(CommonLib.Common.CurrentUserInfomation.UserCD.StrongValue, string.Empty);
            shtGroupPermission.Columns[(int)eColGroupScreenPermission.FLG_ADD].Locked = false;
            shtGroupPermission.Columns[(int)eColGroupScreenPermission.FLG_CHG].Locked = false;
            shtGroupPermission.Columns[(int)eColGroupScreenPermission.FLG_DEL].Locked = false;
            shtGroupPermission.Columns[(int)eColGroupScreenPermission.FLG_VIEW].Locked = false;

            shtUserPermission.Columns[(int)eColUserScreenPermission.FLG_ADD].Locked = false;
            shtUserPermission.Columns[(int)eColUserScreenPermission.FLG_CHG].Locked = false;
            shtUserPermission.Columns[(int)eColUserScreenPermission.FLG_DEL].Locked = false;
            shtUserPermission.Columns[(int)eColUserScreenPermission.FLG_VIEW].Locked = false;

            LoadScreenList(CommonLib.Common.CurrentUserInfomation.UserCD.StrongValue, txtFind.Text.Trim());

            this.tabPermission.TabPages.Remove(tpUsersAccount);
        }


        private void LoadScreenListFromMemory(string LangCD, string keyFilter)
        {
            DataTable dtView = m_dtScreenList.Clone();

            if (keyFilter != string.Empty)
            {
                //get only the rows you want
                DataRow[] results = m_dtScreenList.Select(string.Format("SCREEN_CD LIKE '%{0}%' OR SCREEN_NAME LIKE '%{0}%'", keyFilter));

                //populate new destination table
                foreach (DataRow dr in results)
                    dtView.ImportRow(dr);
            }
            else
            {
                foreach (DataRow dr in m_dtScreenList.Rows)
                    dtView.ImportRow(dr);
            }
            fpScreenList.DataSource = dtView;

            shtScreenList.Columns[(int)eColScreenList.SCREEN_CD].Locked = true;
            shtScreenList.Columns[(int)eColScreenList.SCREEN_NAME].Locked = true;
        }

        private void LoadScreenList(string LangCD, string keyFilter)
        {
            try
            {
                AuthorizedMaintenanceController ctlAuthorize = new AuthorizedMaintenanceController();

                m_dtScreenList = (DataTable)ctlAuthorize.LoadAllDatabyLangCD(LangCD);
                LoadScreenListFromMemory(LangCD, keyFilter);

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

        private void LoadData(eSection section)
        {
            FarPoint.Win.Spread.Model.CellRange range = null;
            FarPoint.Win.Spread.Model.CellRange[] ranges = null;
            switch (section)
            {
                case eSection.GroupScreenPermission:
                    range = shtScreenList.GetSelection(0);
                    ranges = shtScreenList.GetSelections();

                    if (range != null && range.Row != -1)//&& range.Column != -1)
                    {
                        if (range.RowCount <= 1 && ranges.Length <= 1)
                        {
                            Load_GroupScreenPermission(shtScreenList.Cells[range.Row, (int)eColScreenList.SCREEN_CD].Text);

                            ((CheckBoxCellType)shtGroupPermission.Columns[(int)eColGroupScreenPermission.FLG_VIEW].CellType).ThreeState = false;
                            ((CheckBoxCellType)shtGroupPermission.Columns[(int)eColGroupScreenPermission.FLG_ADD].CellType).ThreeState = false;
                            ((CheckBoxCellType)shtGroupPermission.Columns[(int)eColGroupScreenPermission.FLG_CHG].CellType).ThreeState = false;
                            ((CheckBoxCellType)shtGroupPermission.Columns[(int)eColGroupScreenPermission.FLG_DEL].CellType).ThreeState = false;
                        }
                        else // selected screen info more than 1 row.
                        {
                            Load_GroupScreenPermission(shtScreenList.Cells[range.Row, (int)eColScreenList.SCREEN_CD].Text);

                            ((CheckBoxCellType)shtGroupPermission.Columns[(int)eColGroupScreenPermission.FLG_VIEW].CellType).ThreeState = true;
                            ((CheckBoxCellType)shtGroupPermission.Columns[(int)eColGroupScreenPermission.FLG_ADD].CellType).ThreeState = true;
                            ((CheckBoxCellType)shtGroupPermission.Columns[(int)eColGroupScreenPermission.FLG_CHG].CellType).ThreeState = true;
                            ((CheckBoxCellType)shtGroupPermission.Columns[(int)eColGroupScreenPermission.FLG_DEL].CellType).ThreeState = true;

                            for (int i = 0; i < shtGroupPermission.RowCount; i++)
                            {
                                shtGroupPermission.Cells[i, (int)eColGroupScreenPermission.FLG_VIEW].Value = 2;
                                shtGroupPermission.Cells[i, (int)eColGroupScreenPermission.FLG_ADD].Value = 2;
                                shtGroupPermission.Cells[i, (int)eColGroupScreenPermission.FLG_CHG].Value = 2;
                                shtGroupPermission.Cells[i, (int)eColGroupScreenPermission.FLG_DEL].Value = 2;
                            }
                        }
                    }
                    break;
                case eSection.UserScreenPermission:
                    range = shtScreenList.GetSelection(0);
                    ranges = shtScreenList.GetSelections();

                    if (range != null && range.Row != -1)
                    {
                        if (range.RowCount <= 1 && ranges.Length <= 1)
                        {
                            Load_UserScreenPermission(shtScreenList.Cells[range.Row, (int)eColScreenList.SCREEN_CD].Text);

                            ((CheckBoxCellType)shtUserPermission.Columns[(int)eColUserScreenPermission.FLG_VIEW].CellType).ThreeState = true;
                            ((CheckBoxCellType)shtUserPermission.Columns[(int)eColUserScreenPermission.FLG_ADD].CellType).ThreeState = true;
                            ((CheckBoxCellType)shtUserPermission.Columns[(int)eColUserScreenPermission.FLG_CHG].CellType).ThreeState = true;
                            ((CheckBoxCellType)shtUserPermission.Columns[(int)eColUserScreenPermission.FLG_DEL].CellType).ThreeState = true;
                        }
                        else // selected screen info more than 1 row.
                        {
                            Load_UserScreenPermission(shtScreenList.Cells[range.Row, (int)eColScreenList.SCREEN_CD].Text);

                            ((CheckBoxCellType)shtUserPermission.Columns[(int)eColUserScreenPermission.FLG_VIEW].CellType).ThreeState = true;
                            ((CheckBoxCellType)shtUserPermission.Columns[(int)eColUserScreenPermission.FLG_ADD].CellType).ThreeState = true;
                            ((CheckBoxCellType)shtUserPermission.Columns[(int)eColUserScreenPermission.FLG_CHG].CellType).ThreeState = true;
                            ((CheckBoxCellType)shtUserPermission.Columns[(int)eColUserScreenPermission.FLG_DEL].CellType).ThreeState = true;

                            for (int i = 0; i < shtUserPermission.RowCount; i++)
                            {
                                shtUserPermission.Cells[i, (int)eColGroupScreenPermission.FLG_VIEW].Value = 2;
                                shtUserPermission.Cells[i, (int)eColGroupScreenPermission.FLG_ADD].Value = 2;
                                shtUserPermission.Cells[i, (int)eColGroupScreenPermission.FLG_CHG].Value = 2;
                                shtUserPermission.Cells[i, (int)eColGroupScreenPermission.FLG_DEL].Value = 2;
                            }
                        }
                    }
                    break;

            }
        }

        private void Load_GroupScreenPermission(string ScreenCD)
        {
            AuthorizedMaintenanceController ctlAuthor = new AuthorizedMaintenanceController();
            shtGroupPermission.DataSource = ctlAuthor.LoadGroupPermissionJoinScreen(ScreenCD);

            shtGroupPermission.Columns[(int)eColGroupScreenPermission.GROUP_NAME].DataField = "GROUP_NAME";
            shtGroupPermission.Columns[(int)eColGroupScreenPermission.GROUP_CD].DataField = GroupScreenPermissionDTO.eColumns.GROUP_CD.ToString();
            shtGroupPermission.Columns[(int)eColGroupScreenPermission.FLG_VIEW].DataField = GroupScreenPermissionDTO.eColumns.FLG_VIEW.ToString();
            shtGroupPermission.Columns[(int)eColGroupScreenPermission.FLG_ADD].DataField = GroupScreenPermissionDTO.eColumns.FLG_ADD.ToString();
            shtGroupPermission.Columns[(int)eColGroupScreenPermission.FLG_CHG].DataField = GroupScreenPermissionDTO.eColumns.FLG_CHG.ToString();
            shtGroupPermission.Columns[(int)eColGroupScreenPermission.FLG_DEL].DataField = GroupScreenPermissionDTO.eColumns.FLG_DEL.ToString();
        }

        private void Load_UserScreenPermission(string ScreenCD)
        {
            AuthorizedMaintenanceController ctlAuthor = new AuthorizedMaintenanceController();
            shtUserPermission.DataSource = ctlAuthor.LoadUserPermissionJoinScreen(ScreenCD);

            shtUserPermission.Columns[(int)eColUserScreenPermission.USER_ACCOUNT].DataField = "USER_ACCOUNT";
            shtUserPermission.Columns[(int)eColUserScreenPermission.USER_CD].DataField = UserScreenPermissionDTO.eColumns.USER_CD.ToString();
            shtUserPermission.Columns[(int)eColUserScreenPermission.FLG_VIEW].DataField = UserScreenPermissionDTO.eColumns.FLG_VIEW.ToString();
            shtUserPermission.Columns[(int)eColUserScreenPermission.FLG_ADD].DataField = UserScreenPermissionDTO.eColumns.FLG_ADD.ToString();
            shtUserPermission.Columns[(int)eColUserScreenPermission.FLG_CHG].DataField = UserScreenPermissionDTO.eColumns.FLG_CHG.ToString();
            shtUserPermission.Columns[(int)eColUserScreenPermission.FLG_DEL].DataField = UserScreenPermissionDTO.eColumns.FLG_DEL.ToString();
        }

        private void SaveGroupScreenPermission(eColGroupScreenPermission eColGroupScreenPermission)
        {
            AuthorizedMaintenanceController ctlAuthor = new AuthorizedMaintenanceController();
            CellRange[] screen_ranges = shtScreenList.GetSelections();

            //Check if selected screen multiline.
            for (int iRange = 0; iRange < screen_ranges.Length; iRange++)
            {
                CellRange screen_range = screen_ranges[iRange];

                if (screen_range.RowCount > 1 || screen_ranges.Length > 1)
                {
                    // รวบรวมรายการ SCREEN_CD ทั้งหมด
                    List<string> listScreenCD = new List<string>();
                    for (int iScreen = 0; iScreen < screen_range.RowCount; iScreen++)
                    {
                        string SCREEN_CD = shtScreenList.GetText(screen_range.Row + iScreen, (int)eColScreenList.SCREEN_CD);
                        listScreenCD.Add(SCREEN_CD);
                    }

                    //for (int iGroup = 0; iGroup < shtGroupPermission.RowCount; iGroup++)
                    //{
                    //    string GROUP_CD = shtGroupPermission.GetText(iGroup, (int)eColGroupScreenPermission.GROUP_CD);
                    string GROUP_CD = shtGroupPermission.Cells[shtGroupPermission.ActiveRowIndex, (int)eColGroupScreenPermission.GROUP_CD].Text;
                    int iGroup = shtGroupPermission.ActiveRowIndex;
                    int objFLG_VIEW = Convert.ToInt32(shtGroupPermission.Cells[iGroup, (int)eColGroupScreenPermission.FLG_VIEW].Value);
                    int objFLG_ADD = Convert.ToInt32(shtGroupPermission.Cells[iGroup, (int)eColGroupScreenPermission.FLG_ADD].Value);
                    int objFLG_CHG = Convert.ToInt32(shtGroupPermission.Cells[iGroup, (int)eColGroupScreenPermission.FLG_CHG].Value);
                    int objFLG_DEL = Convert.ToInt32(shtGroupPermission.Cells[iGroup, (int)eColGroupScreenPermission.FLG_DEL].Value);

                    if (objFLG_VIEW != 0 && objFLG_VIEW != 1)
                        objFLG_VIEW = -1;

                    if (objFLG_ADD != 0 && objFLG_ADD != 1)
                        objFLG_ADD = -1;

                    if (objFLG_CHG != 0 && objFLG_CHG != 1)
                        objFLG_CHG = -1;

                    if (objFLG_DEL != 0 && objFLG_DEL != 1)
                        objFLG_DEL = -1;

                    // วนรอบทุก SCREEN_CD เพื่อ Update ค่าให้ตรงกับที่เลือกไว้
                    for (int i = 0; i < listScreenCD.Count; i++)
                    {
                        if (!ctlAuthor.isExistGroupScreenPermission(listScreenCD[i], GROUP_CD))
                        {
                            ctlAuthor.AddGroupScreenPermissionFlag(objFLG_VIEW, objFLG_ADD, objFLG_CHG, objFLG_DEL, GROUP_CD, listScreenCD[i]);
                        }
                        else
                        {
                            switch (eColGroupScreenPermission)
                            {
                                case eColGroupScreenPermission.FLG_VIEW:
                                    ctlAuthor.UpdateGroupScreenPermissionFlagVIEW(objFLG_VIEW, GROUP_CD, listScreenCD[i]);
                                    break;
                                case eColGroupScreenPermission.FLG_ADD:
                                    ctlAuthor.UpdateGroupScreenPermissionFlagADD(objFLG_ADD, GROUP_CD, listScreenCD[i]);
                                    break;
                                case eColGroupScreenPermission.FLG_CHG:
                                    ctlAuthor.UpdateGroupScreenPermissionFlagCHG(objFLG_CHG, GROUP_CD, listScreenCD[i]);
                                    break;
                                case eColGroupScreenPermission.FLG_DEL:
                                    ctlAuthor.UpdateGroupScreenPermissionFlagDEL(objFLG_DEL, GROUP_CD, listScreenCD[i]);
                                    break;
                            }
                        }
                    }


                }
                else
                {

                    string ScreenCD = shtScreenList.Cells[shtScreenList.ActiveRowIndex, (int)eColScreenList.SCREEN_CD].Text;
                    string GROUP_CD = shtGroupPermission.Cells[shtGroupPermission.ActiveRowIndex, (int)eColGroupScreenPermission.GROUP_CD].Text;

                    int objFLG_VIEW = Convert.ToInt32(shtGroupPermission.Cells[shtGroupPermission.ActiveRowIndex, (int)eColGroupScreenPermission.FLG_VIEW].Value);
                    int objFLG_ADD = Convert.ToInt32(shtGroupPermission.Cells[shtGroupPermission.ActiveRowIndex, (int)eColGroupScreenPermission.FLG_ADD].Value);
                    int objFLG_CHG = Convert.ToInt32(shtGroupPermission.Cells[shtGroupPermission.ActiveRowIndex, (int)eColGroupScreenPermission.FLG_CHG].Value);
                    int objFLG_DEL = Convert.ToInt32(shtGroupPermission.Cells[shtGroupPermission.ActiveRowIndex, (int)eColGroupScreenPermission.FLG_DEL].Value);

                    if (objFLG_VIEW != 0 && objFLG_VIEW != 1)
                        objFLG_VIEW = -1;

                    if (objFLG_ADD != 0 && objFLG_ADD != 1)
                        objFLG_ADD = -1;

                    if (objFLG_CHG != 0 && objFLG_CHG != 1)
                        objFLG_CHG = -1;

                    if (objFLG_DEL != 0 && objFLG_DEL != 1)
                        objFLG_DEL = -1;


                    if (!ctlAuthor.isExistGroupScreenPermission(ScreenCD, GROUP_CD))
                    {
                        ctlAuthor.AddGroupScreenPermissionFlag(objFLG_VIEW, objFLG_ADD, objFLG_CHG, objFLG_DEL, GROUP_CD, ScreenCD);
                    }
                    else
                    {
                        switch (eColGroupScreenPermission)
                        {
                            case eColGroupScreenPermission.FLG_VIEW:
                                ctlAuthor.UpdateGroupScreenPermissionFlagVIEW(objFLG_VIEW, GROUP_CD, ScreenCD);
                                break;
                            case eColGroupScreenPermission.FLG_ADD:
                                ctlAuthor.UpdateGroupScreenPermissionFlagADD(objFLG_ADD, GROUP_CD, ScreenCD);
                                break;
                            case eColGroupScreenPermission.FLG_CHG:
                                ctlAuthor.UpdateGroupScreenPermissionFlagCHG(objFLG_CHG, GROUP_CD, ScreenCD);
                                break;
                            case eColGroupScreenPermission.FLG_DEL:
                                ctlAuthor.UpdateGroupScreenPermissionFlagDEL(objFLG_DEL, GROUP_CD, ScreenCD);
                                break;
                        }
                    }
                }
            }
        }

        private void SaveUserScreenPermission(eColUserScreenPermission eColUserScreenPermission)
        {
            AuthorizedMaintenanceController ctlAuthor = new AuthorizedMaintenanceController();
            CellRange[] screen_ranges = shtScreenList.GetSelections();

            //Check if selected screen multiline.
            for (int iRange = 0; iRange < screen_ranges.Length; iRange++)
            {
                CellRange screen_range = screen_ranges[iRange];

                if (screen_range.RowCount > 1 || screen_ranges.Length > 1)
                {
                    // รวบรวมรายการ SCREEN_CD ทั้งหมด
                    List<string> listScreenCD = new List<string>();
                    for (int iScreen = 0; iScreen < screen_range.RowCount; iScreen++)
                    {
                        string SCREEN_CD = shtScreenList.GetText(screen_range.Row + iScreen, (int)eColScreenList.SCREEN_CD);
                        listScreenCD.Add(SCREEN_CD);
                    }

                    //for (int iGroup = 0; iGroup < shtUserPermission.RowCount; iGroup++)
                    //{
                    //    string GROUP_CD = shtUserPermission.GetText(iGroup, (int)eColUserScreenPermission.GROUP_CD);
                    string UserCD = shtUserPermission.Cells[shtUserPermission.ActiveRowIndex, (int)eColUserScreenPermission.USER_CD].Text;
                    int iGroup = shtUserPermission.ActiveRowIndex;
                    int objFLG_VIEW = Convert.ToInt32(shtUserPermission.Cells[iGroup, (int)eColUserScreenPermission.FLG_VIEW].Value);
                    int objFLG_ADD = Convert.ToInt32(shtUserPermission.Cells[iGroup, (int)eColUserScreenPermission.FLG_ADD].Value);
                    int objFLG_CHG = Convert.ToInt32(shtUserPermission.Cells[iGroup, (int)eColUserScreenPermission.FLG_CHG].Value);
                    int objFLG_DEL = Convert.ToInt32(shtUserPermission.Cells[iGroup, (int)eColUserScreenPermission.FLG_DEL].Value);

                    if (objFLG_VIEW != 0 && objFLG_VIEW != 1)
                        objFLG_VIEW = -1;

                    if (objFLG_ADD != 0 && objFLG_ADD != 1)
                        objFLG_ADD = -1;

                    if (objFLG_CHG != 0 && objFLG_CHG != 1)
                        objFLG_CHG = -1;

                    if (objFLG_DEL != 0 && objFLG_DEL != 1)
                        objFLG_DEL = -1;

                    // วนรอบทุก SCREEN_CD เพื่อ Update ค่าให้ตรงกับที่เลือกไว้
                    for (int i = 0; i < listScreenCD.Count; i++)
                    {
                        if (!ctlAuthor.isExistUserScreenPermission(listScreenCD[i], UserCD))
                        {
                            ctlAuthor.AddUserScreenPermissionFlag(objFLG_VIEW, objFLG_ADD, objFLG_CHG, objFLG_DEL, UserCD, listScreenCD[i]);
                        }
                        else
                        {
                            switch (eColUserScreenPermission)
                            {
                                case eColUserScreenPermission.FLG_VIEW:
                                    ctlAuthor.UpdateUserScreenPermissionFlagVIEW(objFLG_VIEW, UserCD, listScreenCD[i]);
                                    break;
                                case eColUserScreenPermission.FLG_ADD:
                                    ctlAuthor.UpdateUserScreenPermissionFlagADD(objFLG_ADD, UserCD, listScreenCD[i]);
                                    break;
                                case eColUserScreenPermission.FLG_CHG:
                                    ctlAuthor.UpdateUserScreenPermissionFlagCHG(objFLG_CHG, UserCD, listScreenCD[i]);
                                    break;
                                case eColUserScreenPermission.FLG_DEL:
                                    ctlAuthor.UpdateUserScreenPermissionFlagDEL(objFLG_DEL, UserCD, listScreenCD[i]);
                                    break;

                            }
                        }


                    }


                }
                else
                {

                    string ScreenCD = shtScreenList.Cells[shtScreenList.ActiveRowIndex, (int)eColScreenList.SCREEN_CD].Text;
                    string UserCD = shtUserPermission.Cells[shtUserPermission.ActiveRowIndex, (int)eColUserScreenPermission.USER_CD].Text;

                    int objFLG_VIEW = Convert.ToInt32(shtUserPermission.Cells[shtUserPermission.ActiveRowIndex, (int)eColUserScreenPermission.FLG_VIEW].Value);
                    int objFLG_ADD = Convert.ToInt32(shtUserPermission.Cells[shtUserPermission.ActiveRowIndex, (int)eColUserScreenPermission.FLG_ADD].Value);
                    int objFLG_CHG = Convert.ToInt32(shtUserPermission.Cells[shtUserPermission.ActiveRowIndex, (int)eColUserScreenPermission.FLG_CHG].Value);
                    int objFLG_DEL = Convert.ToInt32(shtUserPermission.Cells[shtUserPermission.ActiveRowIndex, (int)eColUserScreenPermission.FLG_DEL].Value);

                    if (objFLG_VIEW != 0 && objFLG_VIEW != 1)
                        objFLG_VIEW = -1;

                    if (objFLG_ADD != 0 && objFLG_ADD != 1)
                        objFLG_ADD = -1;

                    if (objFLG_CHG != 0 && objFLG_CHG != 1)
                        objFLG_CHG = -1;

                    if (objFLG_DEL != 0 && objFLG_DEL != 1)
                        objFLG_DEL = -1;


                    if (!ctlAuthor.isExistUserScreenPermission(ScreenCD, UserCD))
                    {
                        ctlAuthor.AddUserScreenPermissionFlag(objFLG_VIEW, objFLG_ADD, objFLG_CHG, objFLG_DEL, UserCD, ScreenCD);
                    }
                    else
                    {
                        switch (eColUserScreenPermission)
                        {
                            case eColUserScreenPermission.FLG_VIEW:
                                ctlAuthor.UpdateUserScreenPermissionFlagVIEW(objFLG_VIEW, UserCD, ScreenCD);
                                break;
                            case eColUserScreenPermission.FLG_ADD:
                                ctlAuthor.UpdateUserScreenPermissionFlagADD(objFLG_ADD, UserCD, ScreenCD);
                                break;
                            case eColUserScreenPermission.FLG_CHG:
                                ctlAuthor.UpdateUserScreenPermissionFlagCHG(objFLG_CHG, UserCD, ScreenCD);
                                break;
                            case eColUserScreenPermission.FLG_DEL:
                                ctlAuthor.UpdateUserScreenPermissionFlagDEL(objFLG_DEL, UserCD, ScreenCD);
                                break;

                        }
                    }
                }
            }
        }
        #endregion

        #region Control Event
        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            LoadScreenListFromMemory(CommonLib.Common.CurrentUserInfomation.UserCD.StrongValue, txtFind.Text.Trim());
            shtGroupPermission.Rows.Count = 0;
            shtUserPermission.Rows.Count = 0;
        }



        private void tabPermission_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabPermission.SelectedIndex)
            {
                case 0:  // Group Permission
                    LoadData(eSection.GroupScreenPermission);
                    break;
                case 1:  // User Permission
                    LoadData(eSection.UserScreenPermission);
                    break;
            }
        }
        #endregion

        #region Spread Event
        private void fpScreenList_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            if (shtScreenList.Rows.Count == 0) return;
            if (shtScreenList.ActiveRowIndex < 0) return;

            string ScreenCD = shtScreenList.Cells[shtScreenList.ActiveRowIndex, (int)eColScreenList.SCREEN_CD].Text;

            //LoadPermissionData(ScreenCD);
            tabPermission_SelectedIndexChanged(sender, e);
        }

        private void fpGroupPermission_EditModeOff(object sender, EventArgs e)
        {
            if (shtGroupPermission.Rows.Count == 0) return;
            if (shtGroupPermission.ActiveRowIndex < 0) return;
            if (shtGroupPermission.ActiveColumnIndex == (int)eColGroupScreenPermission.GROUP_NAME) return;

            SaveGroupScreenPermission((eColGroupScreenPermission)shtGroupPermission.ActiveColumnIndex);
        }


        private void fpUserPermission_EditModeOff(object sender, EventArgs e)
        {
            if (shtUserPermission.Rows.Count == 0) return;
            if (shtUserPermission.ActiveRowIndex < 0) return;
            if (shtUserPermission.ActiveColumnIndex == (int)eColUserScreenPermission.USER_ACCOUNT) return;

            SaveUserScreenPermission((eColUserScreenPermission)shtUserPermission.ActiveColumnIndex);
        }
        #endregion

        private void SFM006_AuthorizedMaintenance_Shown(object sender, EventArgs e)
        {
#if DEBUG
            shtScreenList.SelectionPolicy = SelectionPolicy.MultiRange;
#endif

        }

        private void fpScreenList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader)
                e.Cancel = true;
        }

    }
}
