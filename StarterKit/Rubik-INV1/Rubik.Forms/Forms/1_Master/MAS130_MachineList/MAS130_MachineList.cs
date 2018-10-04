using System.Windows.Forms;
using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Windows.Forms;
using SystemMaintenance.Forms;
using Rubik.BIZ;
using System.Data;
using System;
using FarPoint.Win.Spread.Model;
using Rubik.Controller;
using Message = EVOFramework.Message;
using SystemMaintenance;
using CommonLib;
using Rubik.Validators;

namespace Rubik.Master
{
    [Screen("MAS130", "Machine List", eShowAction.Normal, eScreenType.ScreenPane, "Machine List")]
    [Permission(true, false, false, false)]
    public partial class MAS130_MachineList : CustomizeListPaneForm
    {
        #region Enumeration
        public enum eColView
        {
            //CRT_BY,
            //CRT_DATE,
            //CRT_MACHINE,
            //UPD_BY,
            //UPD_DATE,
            //UPD_MACHINE,
            MACHINE_CD,
            MACHINE_TYPE,
            MACHINE_TYPE_NAME,
            PROCESS_CD,
            PROCESS_NAME,
            MACHINE_GROUP,
            PROJECT,
            PROJECT_NAME,
            REMARK
        }
        #endregion

        #region Variables
        private readonly MachineController m_machineController = new MachineController();
        private DataTable m_dtView = null;
        #endregion

        #region Constructor
        public MAS130_MachineList()
        {
            InitializeComponent();
        }

        #endregion

        #region Private methods
        private void InitializeScreen()
        {
            shtView.ActiveSkin = CommonLib.Common.ACTIVE_SKIN;            

            LoadLookupCellType();

            shtView.Columns[(int)eColView.MACHINE_TYPE_NAME].StyleName = DataDefine.NO_EXPORT.ToString();

            shtView.Columns[(int)eColView.MACHINE_TYPE_NAME].Visible = false; 
            shtView.Columns[(int)eColView.PROCESS_NAME].Visible = false;            
            shtView.Columns[(int)eColView.PROJECT_NAME].Visible = false;

            CtrlUtil.MappingDataFieldWithEnum(shtView, typeof(eColView));

            LoadData(false);
        }

        private void LoadLookupCellType()
        {
            LookupDataBIZ bizLookup = new LookupDataBIZ();

            LookupData machineTypeData = bizLookup.LoadLookupClassType(DataDefine.MACHINE_TYPE.ToNZString());
            ReadOnlyPairCellType cellmachineType = new ReadOnlyPairCellType(machineTypeData, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtView.Columns[(int)eColView.MACHINE_TYPE].CellType = cellmachineType;

            LookupData machineProjectData = bizLookup.LoadLookupClassType(DataDefine.MACHINE_PROJECT.ToNZString());
            ReadOnlyPairCellType cellProjectType = new ReadOnlyPairCellType(machineProjectData, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtView.Columns[(int)eColView.PROJECT].CellType = cellProjectType;        

            NZString[] locationtype = new NZString[1];
            locationtype[0] = DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Production).ToNZString();
            LookupData locationData = bizLookup.LoadLookupLocation(locationtype);
            ReadOnlyPairCellType cellProcess = new ReadOnlyPairCellType(locationData, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtView.Columns[(int)eColView.PROCESS_CD].CellType = cellProcess;    
                
        }

        private void LoadData(bool LimitRow)
        {
            MachineBIZ biz = new MachineBIZ();
            m_dtView = biz.LoadMachineList();

            shtView.RowCount = 0;
            shtView.DataSource = FilterData(m_dtView, txtFind.Text.Trim());
            CtrlUtil.SpreadUpdateColumnSorting(shtView);
        }

        private void FindDataFromMemory()
        {            
            shtView.DataSource = FilterData(m_dtView, txtFind.Text.Trim());
            CtrlUtil.SpreadUpdateColumnSorting(shtView);
        }
        private DataTable FilterData(DataTable dtView, string filterText) {
            try 
            {        
                if (filterText.Trim() == String.Empty)
                    return dtView;

                //string[] colNames = Enum.GetNames(typeof(eColView));
                //string filterString = string.Empty;

                //for (int i = 0; i < colNames.Length; i++) {
                //    filterString += string.Format(@"CONVERT({0},'System.String') LIKE '%{1}%' ", colNames[i], filterText);
                //    if (i != colNames.Length - 1)
                //        filterString += " OR ";
                //}

                string filterString = FilterStringUtil.GetFilterstring(typeof(eColView), filterText);

                //get only the rows you want
                DataRow[] results = dtView.Select(filterString);
                DataTable dtFilter = dtView.Clone();

                //populate new destination table
                foreach (DataRow dr in results)
                    dtFilter.ImportRow(dr);

                return dtFilter;
            }
            catch (Exception ex) {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
            return null;
        }
        #endregion

        #region Form events
        private void MAS010_LocationList_Load(object sender, System.EventArgs e)
        {
            InitializeScreen();
        }

        private void MAS010_LocationList_Shown(object sender, System.EventArgs e)
        {
            PermissionControl();
            CtrlUtil.FocusControl(txtFind);
        }
        #endregion

        #region Control events
        private void txtFind_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (DataDefine.ENABLED_AUTO_SEARCH_WHEN_TEXT_CHANGED)
            {
                FindDataFromMemory();
            }
        }

        #region Spread
        private void fpView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                bool isClickOnCell = false;

                CellRange cellRange = fpView.GetCellFromPixel(0, 0, e.X, e.Y);
                if (cellRange.Column != -1 && cellRange.Row != -1)
                {
                    shtView.SetActiveCell(cellRange.Row, cellRange.Column);
                    shtView.AddSelection(cellRange.Row, cellRange.Column, 1, 1);
                    isClickOnCell = true;
                }

                if (isClickOnCell)
                {
                    mnuDelete.Enabled = ActivePermission.Delete;
                    mnuEdit.Enabled = ActivePermission.Edit;
                }
                else
                {
                    mnuDelete.Enabled = false;
                    mnuEdit.Enabled = false;
                }

                ctxMenu.Show(fpView, e.Location);
            }

        }
        private void fpView_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            OpenMachineMaster();
        }
        private void fpView_KeyPress(object sender, KeyPressEventArgs e)
        {
            //OpenMachineMaster();
        }
        #endregion

        #region Menu Item
        private void OpenMachineMaster() 
        {
            if (!ActivePermission.Edit) {
                return;
            }
            if (shtView.RowCount <= 0) return;
            string MACHINE_CD = shtView.GetValue(shtView.ActiveRowIndex, (int)eColView.MACHINE_CD).ToString();
            MAS140_MachineMaster form = new MAS140_MachineMaster(MACHINE_CD);
            if (form.ShowDialog(null) == DialogResult.OK) {
                LoadData(false);
            }
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            OpenMachineMaster();
        }
        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string MACHINE_CD = shtView.GetValue(shtView.ActiveRowIndex, (int)eColView.MACHINE_CD).ToString();

                MachineValidator validator = new MachineValidator();
                ErrorItem errorItem = null;
                errorItem = validator.ValidateBeforeDelete(MACHINE_CD.ToNZString());
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new Message(Messages.eConfirm.CFM9002.ToString()), MessageDialogButtons.YesNo);
                if (dr == MessageDialogResult.No)
                    return;


                m_machineController.DeleteMachine(MACHINE_CD.ToNZString());
                LoadData(false);

                MessageDialog.ShowInformation(this, null, new Message(Messages.eInformation.INF9003.ToString()).MessageDescription);
            }
            catch (ValidateException err)
            {
                MessageDialog.ShowBusiness(this, err.ErrorResults[0].Message);
                err.ErrorResults[0].FocusOnControl();
            }
            }
        #endregion

        #endregion

        public override void OnAddNew()
        {
            base.OnAddNew();
            MAS140_MachineMaster form = new MAS140_MachineMaster();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                LoadData(false);
            }
        }
        public override void OnRefresh()
        {
            base.OnRefresh();
            LoadData(false);
        }
        public override void OnShowAll()
        {
            base.OnShowAll();
            LoadData(false);
        }

        public override void PermissionControl()
        {
            base.PermissionControl();

            if (ActivePermission.View)
            {
                ctxMenu.Items[0].Enabled = ActivePermission.Edit;
                ctxMenu.Items[1].Enabled = ActivePermission.Delete;
            }

        }

        public override void OnSaveFormat()
        {
            base.OnSaveFormat();

            SheetWidthController ctrl = new SheetWidthController();
            ctrl.SaveSheetWidth(shtView, this.ScreenCode);
        }

        public override void OnResetFormat()
        {
            base.OnResetFormat();

            SheetWidthController ctrl = new SheetWidthController();
            ctrl.ResetSheetWidth(shtView);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (Common.UserGroupShowFormatButton.ToUpper().Equals(Common.CurrentUserInfomation.GroupCode.NVL("").ToUpper()))
            {
                tsbDefaultSize.Visible = true;
                tsbSaveFormat.Visible = true;
                tsbAdvanceSearch.Visible = true;
            }

            SheetWidthController ctrl = new SheetWidthController();
            ctrl.SetSheetWidth(shtView, this.ScreenCode);
        }

        public override void OnSorting()
        {
            ShowMultiSortDialog(shtView);
        }

        private void fpView_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }

        public override void OnAdvanceSearch()
        {
            base.OnAdvanceSearch();

            ShowAdvanceSearchDialog(shtView, typeof(eColView), m_dtView);
        }

        private void txtFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (DataDefine.ENABLED_AUTO_SEARCH_WHEN_PRESS_ENTER_KEY && e.KeyCode == Keys.Enter)
                FindDataFromMemory();
        }
    }

}
