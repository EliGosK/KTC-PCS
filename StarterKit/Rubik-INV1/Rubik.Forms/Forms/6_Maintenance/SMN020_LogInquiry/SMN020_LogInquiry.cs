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
    [Screen("SMN020", "Log Inquiry", eShowAction.Normal, eScreenType.ScreenPane, "Log Inquiry")]
    public partial class SMN020_LogInquiry : SystemMaintenance.Forms.CustomizeListPaneForm
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
            SUPP_LOT_NO,
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

        private DataTable m_dtLog;

        #endregion

        #region Contructor

        public SMN020_LogInquiry()
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
            NZString TableName = cboDataType.SelectedValue == null ? new NZString() : cboDataType.SelectedValue.ToString().ToNZString();

            if (TableName.IsNull)
            {
                //MessageDialog.ShowBusiness(this, new EVOFramework.Message(TKPMessages.eValidate.VLM0183.ToString()));

                return;
            }

            InvTranLogController ctl = new InvTranLogController();

            LogInquiryCriteriaDTO cri = new LogInquiryCriteriaDTO();
            cri.FromDate = new NZDateTime(dtPeriodBegin, dtPeriodBegin.Value);
            cri.ToDate = new NZDateTime(dtPeriodEnd, dtPeriodEnd.Value);
            cri.TableName = TableName;


            m_dtLog = ctl.LoadLogData(cri);
            //shtView.DataSource = m_AllIssueTransData;
            FindDataFromMemory();
            // CtrlUtil.SpreadUpdateColumnSorting(shtView);
        }

        private void InitailSpread()
        {
            shtView.ActiveSkin = Common.ACTIVE_SKIN;
            //string[] names = Enum.GetNames(typeof(eColView));
            //for (int i = 0; i < names.Length; i++)
            //{
            //    shtView.Columns[i].DataField = names[i];
            //    CtrlUtil.SpreadSetColumnsLocked(shtView, true, i);
            //}

            //shtView.Columns[(int)eColView.TRANS_DATE].CellType = CtrlUtil.CreateDateTimeCellType();
            //shtView.Columns[(int)eColView.OPERATION_DATE].CellType = CtrlUtil.CreateDateTimeCellType("dd/MM/yyyy HH:mm:ss");
        }

        private void InitialComboBox()
        {
            LookupDataBIZ bizLookup = new LookupDataBIZ();


            //LookupData lookupOPERATION_TYPE = bizLookup.LoadLookupClassType(new NZString(null, DataDefine.OPERATION_TYPE));

            //ReadOnlyPairCellType OPERATION_TYPE = new ReadOnlyPairCellType(lookupOPERATION_TYPE, Common.COMBOBOX_SEPERATOR_SYMBOL);
            //shtView.Columns[(int)eColView.OPERATION_TYPE].CellType = OPERATION_TYPE;

            //LookupData lookupTRANS_CLS = bizLookup.LoadLookupClassType(new NZString(null, DataDefine.TRANS_TYPE));

            //ReadOnlyPairCellType TRANS_CLS = new ReadOnlyPairCellType(lookupTRANS_CLS, Common.COMBOBOX_SEPERATOR_SYMBOL);
            //shtView.Columns[(int)eColView.TRANS_CLS].CellType = TRANS_CLS;

            //LookupData lookupIN_OUT_CLS = bizLookup.LoadLookupClassType(new NZString(null, DataDefine.IN_OUT_CLASS));

            //ReadOnlyPairCellType IN_OUT_CLS = new ReadOnlyPairCellType(lookupIN_OUT_CLS, Common.COMBOBOX_SEPERATOR_SYMBOL);
            //shtView.Columns[(int)eColView.IN_OUT_CLS].CellType = IN_OUT_CLS;

            //// Lookup StoreLoc
            //LookupData lookupStoreLoc = bizLookup.LoadLookupLocation();
            //ReadOnlyPairCellType StoreLoc = new ReadOnlyPairCellType(lookupStoreLoc, Common.COMBOBOX_SEPERATOR_SYMBOL);
            //shtView.Columns[(int)eColView.LOC_CD].CellType = StoreLoc;

            //// Lookup CustomerLoc
            //LookupData lookupCustomerLoc = bizLookup.LoadLookupLocation();
            //ReadOnlyPairCellType CustomerLoc = new ReadOnlyPairCellType(lookupCustomerLoc, Common.COMBOBOX_SEPERATOR_SYMBOL);
            //shtView.Columns[(int)eColView.FOR_CUSTOMER].CellType = CustomerLoc;

            //// Lookup SubType
            //LookupData lookupSubType = bizLookup.LoadLookupClassType(DataDefine.ISSUE_SUBTYPE.ToNZString());
            //ReadOnlyPairCellType SubType = new ReadOnlyPairCellType(lookupSubType, Common.COMBOBOX_SEPERATOR_SYMBOL);
            //shtView.Columns[(int)eColView.TRAN_SUB_CLS].CellType = SubType;

            //LookupData lookupSHIFT_CLS = bizLookup.LoadLookupClassType(DataDefine.SHIFT_CLS.ToNZString());
            //ReadOnlyPairCellType SHIFT_CLS = new ReadOnlyPairCellType(lookupSHIFT_CLS, Common.COMBOBOX_SEPERATOR_SYMBOL);
            //shtView.Columns[(int)eColView.SHIFT_CLS].CellType = SHIFT_CLS;

            //LookupData lookupSCREEN_TYPE = bizLookup.LoadLookupClassType(DataDefine.SCREEN_TYPE.ToNZString());
            //ReadOnlyPairCellType SCREEN_TYPE = new ReadOnlyPairCellType(lookupSCREEN_TYPE, Common.COMBOBOX_SEPERATOR_SYMBOL);
            //shtView.Columns[(int)eColView.SCREEN_TYPE].CellType = SCREEN_TYPE;

            LookupData lookupLogTable = bizLookup.LoadLookupLogTable();
            cboDataType.LoadLookupData(lookupLogTable);
        }



        #endregion

        #region Form Event
        private void SMN010_Load(object sender, EventArgs e)
        {
            try
            {
                InitialScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
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
            shtView.RowCount = 0;
            shtView.ColumnCount = 0;
            shtView.DataSource = FilterData(m_dtLog, txtSearch.Text);
            CtrlUtil.SpreadUpdateColumnSorting(shtView);
        }

        private DataTable FilterData(DataTable dtView, string filterText)
        {
            if (filterText.Trim() == String.Empty)
                return dtView;

            string filterString = FilterStringUtil.GetFilterstring(dtView, filterText);

            //get only the rows you want
            DataRow[] results = m_dtLog.Select(filterString);
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


    }
}
