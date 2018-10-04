using System;
using System.Data;
using SystemMaintenance;
using CommonLib;
using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Windows.Forms;
using Rubik.BIZ;
using Rubik.Controller;
using Rubik.UIDataModel;
using Rubik.DTO;
using System.Windows.Forms;
using Rubik.Validators;

namespace Rubik.Transaction
{
    [Screen("SMN010", "Transaction Log View", eShowAction.Normal, eScreenType.ScreenPane, "Transaction Log View")]
    public partial class SMN010 : SystemMaintenance.Forms.CustomizeListPaneBaseForm
    {
        #region Enum

        private enum eColView
        {
            SCREEN_TYPE,
            OPERATION_TYPE,
            OPERATION_DATE,
            OPERATION_MACHINE,
            UPD_BY,
            TRANS_ID,
            ITEM_CD,
            LOC_CD,
            LOT_NO,
            TRANS_DATE,
            TRANS_CLS,
            IN_OUT_CLS,
            QTY,
            OBJ_ITEM_CD,
            OBJ_ORDER_QTY,
            REF_NO,
            REF_SLIP_NO,
            //REF_SLIP_CLS,
            //OTHER_DL_NO,
            SLIP_NO,
            REMARK,
            //CRT_BY,
            //CRT_DATE,
            //CRT_MACHINE,

            //UPD_DATE,
            //UPD_MACHINE,
            DEALING_NO,
            //SUPP_LOT_NO,     Fixed by Pachara S. 20170908, SUPP_LOT_NO column is miss
            PRICE,
            FOR_CUSTOMER,
            FOR_MACHINE,
            SHIFT_CLS,
            REF_SLIP_NO2,
            NG_QTY,
            TRAN_SUB_CLS,
            GROUP_TRANS_ID,
            RESERVE_QTY,
            NG_REASON,
        }

        #endregion

        #region Variable

        private DataTable m_AllIssueTransData;

        #endregion

        #region Contructor

        public SMN010()
        {
            InitializeComponent();
        }



        #endregion

        #region Overriden Method


        public override void PermissionControl()
        {
            base.PermissionControl();

            //if (ActivePermission.View)
            //{
            //    cmsOperation.Items[0].Enabled = ActivePermission.Edit;
            //    cmsOperation.Items[1].Enabled = ActivePermission.Delete;
            //}
        }
        #endregion

        #region Private Method

        private void InitialScreen()
        {
            InitailSpread();
            InitialComboBox();

            tsbNew.Visible = false;
            tsSeperator1.Visible = false;
            //txtSearch.KeyPress += CommonLib.CtrlUtil.SetRestrictKeyInput;
            //txtSearch.KeyUp += CommonLib.CtrlUtil.FilterRestrictChar;

            dtPeriodBegin.Format = Common.CurrentUserInfomation.DateFormatString;
            dtPeriodEnd.Format = Common.CurrentUserInfomation.DateFormatString;

            //NZString YearMonth = new NZString(null, Common.GetDatabaseDateTime().ToString("yyyyMM"));
            InventoryPeriodBIZ biz = new InventoryPeriodBIZ();
            InventoryPeriodDTO dto = biz.LoadCurrentPeriod();
            if (dto != null)
            {
                dtPeriodBegin.Value = dto.PERIOD_BEGIN_DATE.StrongValue;
                dtPeriodEnd.Value = dto.PERIOD_END_DATE.StrongValue;
            }
            LoadData();
            dtPeriodBegin.Focus();
        }

        private void LoadData()
        {
            //DataDefine.ScreenType screenType = new DataDefine.ScreenType();
            NZString ScreenType = cboScreenType.SelectedValue == null ? new NZString() : cboScreenType.SelectedValue.ToString().ToNZString();
            InvTranLogController ctl = new InvTranLogController();
            m_AllIssueTransData = ctl.LoadAllInvTranLogPeriod(new NZDateTime(dtPeriodBegin, dtPeriodBegin.Value), new NZDateTime(dtPeriodEnd, dtPeriodEnd.Value), ScreenType);
            //shtView.DataSource = m_AllIssueTransData;
            FindDataFromMemory();
            // CtrlUtil.SpreadUpdateColumnSorting(shtView);
        }

        private void InitailSpread()
        {
            shtView.ActiveSkin = Common.ACTIVE_SKIN;
            string[] names = Enum.GetNames(typeof(eColView));
            for (int i = 0; i < names.Length; i++)
            {
                shtView.Columns[i].DataField = names[i];
                CtrlUtil.SpreadSetColumnsLocked(shtView, true, i);
            }

            shtView.Columns[(int)eColView.TRANS_DATE].CellType = CtrlUtil.CreateDateTimeCellType();
            shtView.Columns[(int)eColView.OPERATION_DATE].CellType = CtrlUtil.CreateDateTimeCellType("dd/MM/yyyy HH:mm:ss");
        }

        private void InitialComboBox()
        {
            LookupDataBIZ bizLookup = new LookupDataBIZ();


            LookupData lookupOPERATION_TYPE = bizLookup.LoadLookupClassType(new NZString(null, DataDefine.OPERATION_TYPE));

            ReadOnlyPairCellType OPERATION_TYPE = new ReadOnlyPairCellType(lookupOPERATION_TYPE, Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtView.Columns[(int)eColView.OPERATION_TYPE].CellType = OPERATION_TYPE;

            LookupData lookupTRANS_CLS = bizLookup.LoadLookupClassType(new NZString(null, DataDefine.TRANS_TYPE));

            ReadOnlyPairCellType TRANS_CLS = new ReadOnlyPairCellType(lookupTRANS_CLS, Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtView.Columns[(int)eColView.TRANS_CLS].CellType = TRANS_CLS;

            LookupData lookupIN_OUT_CLS = bizLookup.LoadLookupClassType(new NZString(null, DataDefine.IN_OUT_CLASS));

            ReadOnlyPairCellType IN_OUT_CLS = new ReadOnlyPairCellType(lookupIN_OUT_CLS, Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtView.Columns[(int)eColView.IN_OUT_CLS].CellType = IN_OUT_CLS;

            // Lookup StoreLoc
            LookupData lookupStoreLoc = bizLookup.LoadLookupLocation();
            ReadOnlyPairCellType StoreLoc = new ReadOnlyPairCellType(lookupStoreLoc, Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtView.Columns[(int)eColView.LOC_CD].CellType = StoreLoc;

            // Lookup CustomerLoc
            LookupData lookupCustomerLoc = bizLookup.LoadLookupLocation();
            ReadOnlyPairCellType CustomerLoc = new ReadOnlyPairCellType(lookupCustomerLoc, Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtView.Columns[(int)eColView.FOR_CUSTOMER].CellType = CustomerLoc;

            // Lookup SubType
            LookupData lookupSubType = bizLookup.LoadLookupClassType(DataDefine.ISSUE_SUBTYPE.ToNZString());
            ReadOnlyPairCellType SubType = new ReadOnlyPairCellType(lookupSubType, Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtView.Columns[(int)eColView.TRAN_SUB_CLS].CellType = SubType;

            LookupData lookupSHIFT_CLS = bizLookup.LoadLookupClassType(DataDefine.SHIFT_CLS.ToNZString());
            ReadOnlyPairCellType SHIFT_CLS = new ReadOnlyPairCellType(lookupSHIFT_CLS, Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtView.Columns[(int)eColView.SHIFT_CLS].CellType = SHIFT_CLS;

            LookupData lookupSCREEN_TYPE = bizLookup.LoadLookupClassType(DataDefine.SCREEN_TYPE.ToNZString());
            ReadOnlyPairCellType SCREEN_TYPE = new ReadOnlyPairCellType(lookupSCREEN_TYPE, Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtView.Columns[(int)eColView.SCREEN_TYPE].CellType = SCREEN_TYPE;

            LookupData lookupSCREEN_TYPE_CBO = bizLookup.LoadLookupClassType(DataDefine.SCREEN_TYPE.ToNZString());

            cboScreenType.LoadLookupData(lookupSCREEN_TYPE_CBO);

        }



        #endregion

        #region Form Event
        private void SMN010_Load(object sender, EventArgs e)
        {
            InitialScreen();

        }
        #endregion

        #region Spread Event



        private bool CheckIssueDate(NZString TranID)
        {
            TransactionValidator val = new TransactionValidator();
            return val.TransactionCanEditOrDelete(TranID);
        }

        #endregion

        #region Control Event

        public override void OnRefresh()
        {
            base.OnRefresh();
            LoadData();
        }

        #endregion

        private void dtPeriodBegin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Return) return;

            dtPeriodEnd.Focus();
        }

        private void dtPeriodEnd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Return) return;

            tsControl.Select();
            tsbRefresh.Select();
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (DataDefine.ENABLED_AUTO_SEARCH_WHEN_TEXT_CHANGED)
            {
                FindDataFromMemory();
            }
        }
        private void FindDataFromMemory()
        {
            //CtrlUtil.FilterRestrictChar(txtSearch);
            shtView.DataSource = FilterData(m_AllIssueTransData, txtSearch.Text);
            CtrlUtil.SpreadUpdateColumnSorting(shtView);
        }

        private DataTable FilterData(DataTable dtView, string filterText)
        {
            if (filterText.Trim() == String.Empty)
                return dtView;

            string[] colNames = Enum.GetNames(typeof(eColView));
            string filterString = string.Empty;

            for (int i = 0; i < colNames.Length; i++)
            {
                filterString += string.Format(@"CONVERT({0},'System.String') LIKE '%{1}%' ", colNames[i], filterText);
                if (i != colNames.Length - 1)
                    filterString += " OR ";
            }

            //get only the rows you want
            DataRow[] results = m_AllIssueTransData.Select(filterString);
            DataTable dtFilter = dtView.Clone();

            //populate new destination table
            foreach (DataRow dr in results)
                dtFilter.ImportRow(dr);

            return dtFilter;
        }

        private void fpView_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (DataDefine.ENABLED_AUTO_SEARCH_WHEN_PRESS_ENTER_KEY && e.KeyCode == Keys.Enter)
                FindDataFromMemory();
        }

        private void cboScreenType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void fpView_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {

        }


    }
}
