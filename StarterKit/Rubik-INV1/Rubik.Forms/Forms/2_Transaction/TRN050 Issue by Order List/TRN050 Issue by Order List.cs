using System;
using System.Data;
using System.Windows.Forms;
using SystemMaintenance;
using CommonLib;
using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Windows.Forms;
using Rubik.BIZ;
using Rubik.Controller;
using Rubik.UIDataModel;
using Rubik.DTO;
using FarPoint.Win.Spread.CellType;
using Rubik.Validators;
using Message = EVOFramework.Message;

namespace Rubik.Transaction
{
    //[Screen("TRN050", "Issue by Order List", eShowAction.Normal, eScreenType.ScreenPane, "Issue by Order List")]
    public partial class TRN050 : SystemMaintenance.Forms.CustomizeListPaneBaseForm
    {
        #region Enum

        private enum eColView
        {
            ISSUE_DATE,
            SLIP_NO,
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
            ISSUE_NO,

            OBJ_ITEM_CD,
            OBJ_ORDER_QTY,

            REF_NO
        }

        #endregion

        #region Variable

        private DataTable m_AllIssueTransData;

        #endregion

        #region Contructor

        public TRN050()
        {
            InitializeComponent();
        }



        #endregion

        #region Overriden Method
        public override void OnAddNew()
        {
            base.OnAddNew();
            TRN060 frmTRN060 = new TRN060();
            frmTRN060.ShowDialog();

            LoadData();
        }
        public override void OnRefresh()
        {
            base.OnRefresh();
            LoadData();
        }
        //private void OnAdd()
        //{
        //    TRN060 frmTRN060 = new TRN060();
        //    frmTRN060.ShowDialog();

        //    LoadData();
        //}
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

            //NZString YearMonth = new NZString(null, CommonLib.Common.GetDatabaseDateTime().ToString("yyyyMM"));
            //txtSearch.KeyPress += CommonLib.CtrlUtil.SetRestrictKeyInput;
            //txtSearch.KeyUp += CommonLib.CtrlUtil.FilterRestrictChar;

            dtPeriodBegin.Format = CommonLib.Common.CurrentUserInfomation.DateFormatString;
            dtPeriodEnd.Format = CommonLib.Common.CurrentUserInfomation.DateFormatString;

            InventoryPeriodBIZ biz = new InventoryPeriodBIZ();
            InventoryPeriodDTO dto = biz.LoadCurrentPeriodWithQueryRange();
            if (dto != null)
            {
                dtPeriodBegin.Value = dto.PERIOD_BEGIN_DATE.StrongValue;
                dtPeriodEnd.Value = dto.PERIOD_END_DATE.StrongValue;
            }
            LoadData();
        }

        private void LoadData()
        {
            InventoryIssueListController ctl = new InventoryIssueListController();
            m_AllIssueTransData = ctl.LoadAllIssueTransByPeriod(new NZDateTime(dtPeriodBegin, dtPeriodBegin.Value), new NZDateTime(dtPeriodEnd, dtPeriodEnd.Value), DataDefine.ScreenType.IssueByOrder);
            // shtView.DataSource = m_AllIssueTransData;
            FindDataFromMemory();
            //CtrlUtil.SpreadUpdateColumnSorting(shtView);
        }

        private void InitailSpread()
        {
            shtView.ActiveSkin = CommonLib.Common.ACTIVE_SKIN;
            string[] names = Enum.GetNames(typeof(eColView));
            for (int i = 0; i < names.Length; i++)
            {
                shtView.Columns[i].DataField = names[i];
                shtView.Columns[i].Locked = true;
            }
            shtView.Columns[(int)eColView.ISSUE_DATE].CellType = CommonLib.CtrlUtil.CreateDateTimeCellType();

        }

        private void InitialComboBox()
        {
            LookupDataBIZ bizLookup = new LookupDataBIZ();

            // Lookup Lot Control
            LookupData lookupIssueType = bizLookup.LoadLookupClassType(new NZString(null, "TRANS_TYPE"));

            ReadOnlyPairCellType ItemTypecellType = new ReadOnlyPairCellType(lookupIssueType, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtView.Columns[(int)eColView.ISSUE_TYPE].CellType = ItemTypecellType;

            // Lookup OrderLoc
            LookupData lookupOrderLoc = bizLookup.LoadLookupLocation();
            ReadOnlyPairCellType OrderLoc = new ReadOnlyPairCellType(lookupOrderLoc, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtView.Columns[(int)eColView.FROM_LOC].CellType = OrderLoc;

            // Lookup StoreLoc
            LookupData lookupStoreLoc = bizLookup.LoadLookupLocation();
            ReadOnlyPairCellType StoreLoc = new ReadOnlyPairCellType(lookupStoreLoc, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtView.Columns[(int)eColView.TO_LOC].CellType = StoreLoc;

            // Lookup CustomerLoc
            LookupData lookupCustomerLoc = bizLookup.LoadLookupLocation();
            ReadOnlyPairCellType CustomerLoc = new ReadOnlyPairCellType(lookupCustomerLoc, Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtView.Columns[(int)eColView.FOR_CUSTOMER].CellType = CustomerLoc;

            // Lookup SubType
            LookupData lookupSubType = bizLookup.LoadLookupClassType(DataDefine.ISSUE_SUBTYPE.ToNZString());
            ReadOnlyPairCellType SubType = new ReadOnlyPairCellType(lookupSubType, Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtView.Columns[(int)eColView.TRAN_SUB_CLS].CellType = SubType;
        }

        private void OpenIssueScreen(bool CanEdit)
        {
            int activeRow = shtView.ActiveRowIndex;
            IssueByOrderUIDM uidm = new IssueByOrderUIDM();
            uidm.TRANS_ID.Value = shtView.Cells[activeRow, (int)eColView.ISSUE_NO].Value;
            //uidm.REF_NO.Value = shtView.Cells[activeRow, (int)eColView.REF_ID].Value;
            uidm.OBJ_ITEM_CD.Value = shtView.Cells[activeRow, (int)eColView.OBJ_ITEM_CD].Value;
            uidm.OBJ_ORDER_QTY.Value = shtView.Cells[activeRow, (int)eColView.OBJ_ORDER_QTY].Value;
            //uidm.ITEM_DESC.Value = shtView.Cells[activeRow, (int)eColView.PART_NAME].Value;
            uidm.FROM_LOC_CD.Value = shtView.Cells[activeRow, (int)eColView.FROM_LOC].Value;
            uidm.TO_LOC_CD.Value = shtView.Cells[activeRow, (int)eColView.TO_LOC].Value;
            uidm.LOT_NO.Value = shtView.Cells[activeRow, (int)eColView.LOT_NO].Value;
            // uidm.ONHAND_QTY.Value = shtView.Cells[activeRow, (int) eColView.TRANS_ID].Value;
            uidm.QTY.Value = shtView.Cells[activeRow, (int)eColView.ISSUE_QTY].Value;
            uidm.REMARK.Value = shtView.Cells[activeRow, (int)eColView.REMARK].Value;
            uidm.TRANS_DATE.Value = Convert.ToDateTime(shtView.Cells[activeRow, (int)eColView.ISSUE_DATE].Value);
            uidm.TRANS_CLS.Value = shtView.Cells[activeRow, (int)eColView.ISSUE_TYPE].Value;
            uidm.SLIP_NO.Value = shtView.Cells[activeRow, (int)eColView.SLIP_NO].Value;

            uidm.REF_SLIP_NO.Value = shtView.Cells[activeRow, (int)eColView.REF_SLIP_NO].Text;
            uidm.REF_SLIP_NO2.Value = shtView.Cells[activeRow, (int)eColView.REF_SLIP_NO2].Text;
            uidm.FOR_CUSTOMER.Value = shtView.Cells[activeRow, (int)eColView.FOR_CUSTOMER].Text;
            uidm.FOR_MACHINE.Value = shtView.Cells[activeRow, (int)eColView.FOR_MACHINE].Text;
            uidm.TRAN_SUB_CLS.Value = shtView.Cells[activeRow, (int)eColView.TRAN_SUB_CLS].Text;


            TRN060 frmTRN060 = new TRN060(uidm, CanEdit);
            frmTRN060.ShowDialog();
        }

        #endregion

        #region Form Event
        private void TRN050_Load(object sender, EventArgs e)
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

        #endregion

        #region Control Event
        //private void tsbNew_Click(object sender, EventArgs e)
        //{
        //    OnAdd();
        //}

        //private void tsbRefresh_Click(object sender, EventArgs e)
        //{
        //    LoadData();
        //}

        //private void tsbExit_Click(object sender, EventArgs e)
        //{
        //    HidePane();
        //}
        #endregion

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
                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new Message(Messages.eConfirm.CFM9002.ToString()), MessageDialogButtons.YesNo);
                if (dr != MessageDialogResult.Yes)
                    return;

                NZString TransID = new NZString(null, shtView.Cells[shtView.ActiveRowIndex, (int)eColView.ISSUE_NO].Value);
                NZString RefNo = new NZString(null, shtView.Cells[shtView.ActiveRowIndex, (int)eColView.REF_NO].Value);
                IssueByOrderController ctl = new IssueByOrderController();
                ctl.DeleteTransaction(TransID, RefNo);

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

        private void fpView_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
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


        private bool CheckIssueDate(NZString TranID)
        {
            TransactionValidator val = new TransactionValidator();
            return val.TransactionCanEditOrDelete(TranID);
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

        private void deleteGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnDeleteGroup();
        }


        private void OnDeleteGroup()
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

                //NZString TransID = new NZString(null, shtView.Cells[shtView.ActiveRowIndex, (int)eColView.ISSUE_NO].Value);
                //NZString RefNo = new NZString(null, shtView.Cells[shtView.ActiveRowIndex, (int)eColView.REF_NO].Value);
                NZString TransferNo = new NZString(null, shtView.Cells[shtView.ActiveRowIndex, (int)eColView.SLIP_NO].Value);


                IssueByOrderController ctl = new IssueByOrderController();
                ctl.DeleteGroupTransaction(TransferNo);

                //ไล่ลบจากล่างขึ้นบน เพราะว่าไม่งั้นindex จะเลื่อนแล้วจะลบไม่ครบ
                for (int iRowIndex = shtView.RowCount - 1; iRowIndex >= 0; iRowIndex--)
                {
                    if (TransferNo.NVL("").Equals(shtView.GetValue(iRowIndex, (int)eColView.SLIP_NO)))
                    {
                        shtView.Rows.Remove(iRowIndex, 1);
                    }
                }

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
