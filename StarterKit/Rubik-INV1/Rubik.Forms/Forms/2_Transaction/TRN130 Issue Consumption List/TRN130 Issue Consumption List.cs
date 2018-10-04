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
    //[Screen("TRN130", "Issue Consumption List", eShowAction.Normal, eScreenType.ScreenPane, "Issue Consumption List")]
    public partial class TRN130 : SystemMaintenance.Forms.CustomizeListPaneBaseForm
    {
        #region Enum

        private enum eColView
        {
            ISSUE_DATE,
            ISSUE_NO,
            ISSUE_TYPE,
            TRAN_SUB_CLS,
            REF_SLIP_NO2,
            REF_SLIP_NO,
            FOR_CUSTOMER,
            FOR_MACHINE,
            PART_NO,
            PART_NAME,
            ISSUE_QTY,
            FROM_LOC,
            TO_LOC,
            LOT_NO,
            REMARK,
            REF_NO,
        }

        #endregion

        #region Variable

        private DataTable m_AllIssueTransData;

        #endregion

        #region Contructor

        public TRN130()
        {
            InitializeComponent();
        }



        #endregion

        #region Overriden Method

        //private void OnAdd()
        //{
        //    TRN040 frmTRN040 = new TRN040();
        //    frmTRN040.ShowDialog();

        //    LoadData();
        //}
        public override void OnAddNew()
        {
            base.OnAddNew();
            TRN140 frmTRN040 = new TRN140();
            frmTRN040.ShowDialog();

            LoadData();
        }
        public override void PermissionControl()
        {
            base.PermissionControl();

            if (ActivePermission.View)
            {
                cmsOperation.Items[0].Enabled = ActivePermission.Edit;
                cmsOperation.Items[1].Enabled = ActivePermission.Delete;
            }
        }
        #endregion

        #region Private Method

        private void InitialScreen()
        {
            InitailSpread();
            InitialComboBox();

            dtPeriodBegin.Format = Common.CurrentUserInfomation.DateFormatString;
            dtPeriodEnd.Format = Common.CurrentUserInfomation.DateFormatString;

            //txtSearch.KeyPress += CommonLib.CtrlUtil.SetRestrictKeyInput;
            //txtSearch.KeyUp += CommonLib.CtrlUtil.FilterRestrictChar;

            //NZString YearMonth = new NZString(null, Common.GetDatabaseDateTime().ToString("yyyyMM"));
            InventoryPeriodBIZ biz = new InventoryPeriodBIZ();
            InventoryPeriodDTO dto = biz.LoadCurrentPeriodWithQueryRange();
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
            InventoryIssueListController ctl = new InventoryIssueListController();
            m_AllIssueTransData = ctl.LoadAllIssueTransByPeriod(new NZDateTime(dtPeriodBegin, dtPeriodBegin.Value), new NZDateTime(dtPeriodEnd, dtPeriodEnd.Value), DataDefine.ScreenType.IssueConsumption);
            //shtView.DataSource = m_AllIssueTransData;
            FindDataFromMemory();
            //CtrlUtil.SpreadUpdateColumnSorting(shtView);
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

            shtView.Columns[(int)eColView.ISSUE_DATE].CellType = CtrlUtil.CreateDateTimeCellType();
        }

        private void InitialComboBox()
        {
            LookupDataBIZ bizLookup = new LookupDataBIZ();

            // Lookup Lot Control
            LookupData lookupIssueType = bizLookup.LoadLookupClassType(new NZString(null, "TRANS_TYPE"));

            ReadOnlyPairCellType ItemTypecellType = new ReadOnlyPairCellType(lookupIssueType, Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtView.Columns[(int)eColView.ISSUE_TYPE].CellType = ItemTypecellType;

            // Lookup OrderLoc
            LookupData lookupOrderLoc = bizLookup.LoadLookupLocation();
            ReadOnlyPairCellType OrderLoc = new ReadOnlyPairCellType(lookupOrderLoc, Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtView.Columns[(int)eColView.FROM_LOC].CellType = OrderLoc;

            // Lookup StoreLoc
            LookupData lookupStoreLoc = bizLookup.LoadLookupLocation();
            ReadOnlyPairCellType StoreLoc = new ReadOnlyPairCellType(lookupStoreLoc, Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtView.Columns[(int)eColView.TO_LOC].CellType = StoreLoc;

        }

        private void OpenIssueScreen(bool CanEdit)
        {
            int activeRow = shtView.ActiveRowIndex;
            IssueByItemUIDM uidm = new IssueByItemUIDM();
            uidm.TRANS_ID.Value = shtView.Cells[activeRow, (int)eColView.ISSUE_NO].Text;
            uidm.REF_NO.Value = shtView.Cells[activeRow, (int)eColView.REF_NO].Text;
            uidm.ITEM_CD.Value = shtView.Cells[activeRow, (int)eColView.PART_NO].Text;
            uidm.ITEM_DESC.Value = shtView.Cells[activeRow, (int)eColView.PART_NAME].Text;
            uidm.FROM_LOC_CD.Value = shtView.Cells[activeRow, (int)eColView.FROM_LOC].Text;
            uidm.TO_LOC_CD.Value = shtView.Cells[activeRow, (int)eColView.TO_LOC].Text;
            uidm.LOT_NO.Value = shtView.Cells[activeRow, (int)eColView.LOT_NO].Text;
            // uidm.ONHAND_QTY.Value = shtView.Cells[activeRow, (int) eColView.TRANS_ID].Text;
            uidm.QTY.Value = shtView.Cells[activeRow, (int)eColView.ISSUE_QTY].Text;
            uidm.REMARK.Value = shtView.Cells[activeRow, (int)eColView.REMARK].Text;
            uidm.TRANS_DATE.Value = Convert.ToDateTime(shtView.Cells[activeRow, (int)eColView.ISSUE_DATE].Value);
            uidm.TRANS_CLS.Value = shtView.Cells[activeRow, (int)eColView.ISSUE_TYPE].Text;

            uidm.REF_SLIP_NO.Value = shtView.Cells[activeRow, (int)eColView.REF_SLIP_NO].Text;
            uidm.REF_SLIP_NO2.Value = shtView.Cells[activeRow, (int)eColView.REF_SLIP_NO2].Text;
            uidm.FOR_CUSTOMER.Value = shtView.Cells[activeRow, (int)eColView.FOR_CUSTOMER].Text;
            uidm.FOR_MACHINE.Value = shtView.Cells[activeRow, (int)eColView.FOR_MACHINE].Text;
            uidm.TRAN_SUB_CLS.Value = shtView.Cells[activeRow, (int)eColView.TRAN_SUB_CLS].Text;


            TRN140 frmTRN140 = new TRN140(uidm, CanEdit);
            frmTRN140.ShowDialog();
        }

        #endregion

        #region Form Event
        private void TRN030_Load(object sender, EventArgs e)
        {
            InitialScreen();

        }
        #endregion

        #region Spread Event

        private void fpView_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (!ActivePermission.Edit)
            {
                return;
            }
            if (shtView.Rows.Count == 0) return;
            if (shtView.ActiveRowIndex < 0) return;

            NZString TranID = new NZString(null, shtView.Cells[shtView.ActiveRowIndex, (int)eColView.ISSUE_NO].Value);

            OpenIssueScreen(CheckIssueDate(TranID));

            LoadData();
        }

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

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnDelete();
        }

        private void OnDelete()
        {
            try
            {

                if (shtView.Rows.Count == 0)
                    return;
                if (shtView.ActiveRowIndex < 0) return;

                // show confirm message
                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new EVOFramework.Message(Messages.eConfirm.CFM9002.ToString()), MessageDialogButtons.YesNo);
                if (dr != MessageDialogResult.Yes)
                    return;

                IssueConsumptionController ctl = new IssueConsumptionController();
                NZString TransID = new NZString(null, shtView.Cells[shtView.ActiveRowIndex, (int)eColView.ISSUE_NO].Value);
                NZString RefNo = new NZString(null, shtView.Cells[shtView.ActiveRowIndex, (int)eColView.REF_NO].Value);
                NZString ConsumptionID = ctl.GetConsumptionTransID(TransID);

                ctl.DeleteTransaction(TransID, RefNo, ConsumptionID);

                shtView.RemoveRows(shtView.ActiveRowIndex, 1);
                //LoadData();
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                err.Error.FocusOnControl();
            }
            catch (ValidateException err)
            {
                MessageDialog.ShowBusiness(this, err.ErrorResults[0].Message);
                err.ErrorResults[0].FocusOnControl();
            }
            catch (Exception err)
            {
                MessageDialog.ShowBusiness(this, err.Message);
            }
        }

        private void fpView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (shtView.RowCount <= 0) return;
            if (e.KeyChar == (char)Keys.Return)
            {
                NZString TranID = new NZString(null, shtView.Cells[shtView.ActiveRowIndex, (int)eColView.ISSUE_NO].Value);

                OpenIssueScreen(CheckIssueDate(TranID));
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NZString TranID = new NZString(null, shtView.Cells[shtView.ActiveRowIndex, (int)eColView.ISSUE_NO].Value);

            OpenIssueScreen(CheckIssueDate(TranID));
        }

        private void fpView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                bool isClickOnCell = false;

                FarPoint.Win.Spread.Model.CellRange cellRange = fpView.GetCellFromPixel(0, 0, e.X, e.Y);
                if (cellRange.Column != -1 && cellRange.Row != -1)
                {
                    shtView.SetActiveCell(cellRange.Row, cellRange.Column);
                    shtView.AddSelection(cellRange.Row, cellRange.Column, 1, 1);
                    isClickOnCell = true;
                }

                if (isClickOnCell)
                {
                    NZString TranID = new NZString(null, shtView.Cells[shtView.ActiveRowIndex, (int)eColView.ISSUE_NO].Value);
                    bool canEdit = CheckIssueDate(TranID);
                    editToolStripMenuItem.Enabled = canEdit && ActivePermission.Edit;
                    deleteToolStripMenuItem.Enabled = canEdit && ActivePermission.Delete;
                }
                else
                {
                    editToolStripMenuItem.Enabled = false;
                    deleteToolStripMenuItem.Enabled = false;
                }
                cmsOperation.Show(fpView, e.Location);
            }
        }

        //private DataTable m_dtAllData;
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (DataDefine.ENABLED_AUTO_SEARCH_WHEN_TEXT_CHANGED)
            {
                FindDataFromMemory();
            }
        }
        private void FindDataFromMemory()
        {
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

    }
}
