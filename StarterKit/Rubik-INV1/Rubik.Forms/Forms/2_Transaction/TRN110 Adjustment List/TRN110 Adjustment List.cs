using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Windows.Forms;
using FarPoint.Win.Spread.Model;
using Rubik.Controller;
using Rubik.BIZ;
using CommonLib;
using Rubik.DTO;
using Rubik.Validators;
using Message = EVOFramework.Message;
using SystemMaintenance;

namespace Rubik.Transaction
{
    [Screen("TRN110", "Adjust List", eShowAction.Normal, eScreenType.ScreenPane, "Adjust List")]
    public partial class TRN110 : SystemMaintenance.Forms.CustomizeListPaneBaseForm
    {
        #region Enum
        public enum eColView
        {
            TRANS_DATE,
            TRANS_ID,
            SLIP_NO, //Adjust No.
            IN_OUT_CLS,
            IN_OUT_CLS_NAME,
            ITEM_CD,
            SHORT_NAME,
            CUSTOMER_NAME,
            TRAN_SUB_CLS,
            TRAN_SUB_CLS_NAME,
            QTY,
            PACK_NO,
            FG_NO,
            LOT_NO,
            LOC_CD,
            LOC_DESC,
            REMARK,
        }
        #endregion

        #region Variables
        private readonly AdjustmentListController m_controller = new AdjustmentListController();
        private readonly TransactionValidator m_transactionValidator = new TransactionValidator();
        #endregion

        #region Constructor
        public TRN110()
        {
            InitializeComponent();
        }
        #endregion

        #region Initialize Screen
        private void InitializeScreen()
        {
            InitializeSpread();
            InitializeLookupData();

            InitialFormat();

            dtPeriodBegin.KeyPress += CtrlUtil.SetNextControl;
            dtPeriodEnd.KeyPress += CtrlUtil.SetNextControl;

            dtPeriodBegin.Format = Common.CurrentUserInfomation.DateFormatString;
            dtPeriodEnd.Format = Common.CurrentUserInfomation.DateFormatString;

            //txtSearch.KeyPress += CommonLib.CtrlUtil.SetRestrictKeyInput;
            //txtSearch.KeyUp += CommonLib.CtrlUtil.FilterRestrictChar;

        }

        private void InitialFormat()
        {
            FormatUtil.SetNumberFormat(this.shtView.Columns[(int)eColView.ITEM_CD], FormatUtil.eNumberFormat.MasterNo);
        }

        private void InitializeSpread()
        {
            shtView.ActiveSkin = Common.ACTIVE_SKIN;

            shtView.Columns[(int)eColView.TRANS_DATE].CellType = CtrlUtil.CreateDateTimeCellType(Common.CurrentUserInfomation.DateFormatString);

            shtView.Columns[(int)eColView.TRANS_ID].StyleName = DataDefine.EXPORT_LAST.ToString();

            shtView.Columns[(int)eColView.TRANS_ID].Visible = false;
            shtView.Columns[(int)eColView.IN_OUT_CLS_NAME].Visible = false;
            shtView.Columns[(int)eColView.LOC_DESC].Visible = false;
            shtView.Columns[(int)eColView.TRAN_SUB_CLS_NAME].Visible = false;
            shtView.Columns[(int)eColView.PACK_NO].Visible = false;
            shtView.Columns[(int)eColView.FG_NO].Visible = false;
            shtView.Columns[(int)eColView.LOT_NO].Visible = false;

            CtrlUtil.MappingDataFieldWithEnum(shtView, typeof(eColView));
            
        }

        private void InitializeLookupData()
        {
            LookupDataBIZ lookupDataBiz = new LookupDataBIZ();
            LookupData adjustmentType = lookupDataBiz.LoadLookupClassType(DataDefine.IN_OUT_CLASS.ToNZString());
            shtView.Columns[(int)eColView.IN_OUT_CLS].CellType = new ReadOnlyPairCellType(adjustmentType, Common.COMBOBOX_SEPERATOR_SYMBOL);

            LookupData reasonCode = lookupDataBiz.LoadLookupClassType(DataDefine.ADJ_SUBTYPE.ToNZString());
            shtView.Columns[(int)eColView.TRAN_SUB_CLS].CellType = new ReadOnlyPairCellType(reasonCode, Common.COMBOBOX_SEPERATOR_SYMBOL);

            LookupData stockLocation = lookupDataBiz.LoadLookupLocation();
            shtView.Columns[(int)eColView.LOC_CD].CellType = new ReadOnlyPairCellType(stockLocation, Common.COMBOBOX_SEPERATOR_SYMBOL);
        }
        #endregion

        #region Private method
        private void LoadData(NZDateTime from, NZDateTime to)
        {
            m_dtAllData = DTOUtility.ConvertListToDataTable(m_controller.LoadAdjustmentList(from, to));

            shtView.RowCount = 0;
            shtView.DataSource = null;
            //shtView.DataSource = m_dtAllData;
            FindDataFromMemory();
            //CtrlUtil.SpreadUpdateColumnSorting(shtView);
        }

        private void EditItem(NZString transactionID)
        {
            if (!ActivePermission.Edit)
            {
                return;
            }
            TRN120 entry = new TRN120(transactionID);
            entry.ShowDialog();

            if (entry.IsSelected)
            {
                this.LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
            }
        }

        private void DeleteItem(NZString transactionID)
        {
            if (MessageDialog.ShowConfirmation(this, Message.LoadMessage(Messages.eConfirm.CFM9002.ToString()), MessageDialogButtons.YesNo) == MessageDialogResult.No)
                return;

            InventoryBIZ biz = new InventoryBIZ();
            biz.DeleteInventoryTransaction(Common.CurrentDatabase, transactionID);

            //LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
            shtView.RemoveRows(shtView.ActiveRowIndex, 1);

            CtrlUtil.SpreadUpdateColumnSorting(shtView);
        }
        #endregion

        #region Form event
        private void TRN110_Load(object sender, EventArgs e)
        {
            InitializeScreen();

            InventoryPeriodBIZ biz = new InventoryPeriodBIZ();
            InventoryPeriodDTO dto = biz.LoadCurrentPeriodWithQueryRange();
            dtPeriodBegin.NZValue = dto.PERIOD_BEGIN_DATE;
            dtPeriodEnd.NZValue = dto.PERIOD_END_DATE;

            LoadData(dto.PERIOD_BEGIN_DATE, dto.PERIOD_END_DATE);
        }

        private void TRN110_Shown(object sender, EventArgs e)
        {
            CtrlUtil.FocusControl(txtSearch);
        }
        #endregion

        #region Control event
        private void miEdit_Click(object sender, EventArgs e)
        {
            NZString transactionID = new NZString(null, shtView.GetValue(shtView.ActiveRowIndex, (int)eColView.TRANS_ID));
            EditItem(transactionID);
        }
        private void miDelete_Click(object sender, EventArgs e)
        {
            try
            {
                NZString transactionID = new NZString(null, shtView.GetValue(shtView.ActiveRowIndex, (int)eColView.TRANS_ID));
                DeleteItem(transactionID);
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
                    NZString transID = new NZString(null, shtView.Cells[cellRange.Row, (int)eColView.TRANS_ID].Value);
                    bool canEditOrDelete = m_transactionValidator.TransactionCanEditOrDelete(transID);

                    miEdit.Enabled = canEditOrDelete && ActivePermission.Edit; ;
                    miDelete.Enabled = canEditOrDelete && ActivePermission.Delete; ;
                }
                else
                {
                    miEdit.Enabled = false;
                    miDelete.Enabled = false;
                }

                ctxMenu.Show(fpView, e.Location);
            }

        }
        private void fpView_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (shtView.RowCount <= 0) return;
            NZString transactionID = new NZString(null, shtView.GetValue(e.Row, (int)eColView.TRANS_ID));
            EditItem(transactionID);
        }
        private void fpView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (shtView.RowCount <= 0) return;
            if (e.KeyChar == '\r')
            {
                NZString transactionID = new NZString(null, shtView.GetValue(shtView.ActiveRowIndex, (int)eColView.TRANS_ID));
                EditItem(transactionID);
            }
        }

        public override void OnAddNew()
        {
            base.OnAddNew();
            TRN120 entry = new TRN120();
            entry.ShowDialog();
            if (entry.IsSelected)
            {
                this.LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
            }
        }
        //private void tsbNew_Click(object sender, EventArgs e)
        //{
        //    TRN120 entry = new TRN120();
        //    entry.ShowDialog();
        //    if (entry.IsSelected) {
        //        this.LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
        //    }
        //}

        //private void tsbSearch_Click(object sender, EventArgs e)
        //{
        //    this.LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
        //}
        public override void OnRefresh()
        {
            base.OnRefresh();
            LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
        }
        //private void tsbExit_Click(object sender, EventArgs e)
        //{
        //    HidePane();
        //}
        #endregion

        public override void PermissionControl()
        {
            base.PermissionControl();

            if (ActivePermission.View)
            {
                ctxMenu.Items[0].Enabled = ActivePermission.Edit;
                ctxMenu.Items[1].Enabled = ActivePermission.Delete;
            }
        }

        private DataTable m_dtAllData;
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (DataDefine.ENABLED_AUTO_SEARCH_WHEN_TEXT_CHANGED)
            {
                FindDataFromMemory();
            }
        }
        private void FindDataFromMemory()
        {
            shtView.DataSource = FilterData(m_dtAllData, txtSearch.Text);
            CtrlUtil.SpreadUpdateColumnSorting(shtView);
        }

        private DataTable FilterData(DataTable dtView, string filterText)
        {
            if (filterText.Trim() == String.Empty)
                return dtView;

            //string[] colNames = Enum.GetNames(typeof(eColView));
            //string filterString = string.Empty;

            //for (int i = 0; i < colNames.Length; i++)
            //{
            //    filterString += string.Format(@"CONVERT({0},'System.String') LIKE '%{1}%' ", colNames[i], filterText);
            //    if (i != colNames.Length - 1)
            //        filterString += " OR ";
            //}

            string filterString = FilterStringUtil.GetFilterstring(typeof(eColView), filterText);

            //get only the rows you want
            DataRow[] results = m_dtAllData.Select(filterString);
            DataTable dtFilter = dtView.Clone();

            //populate new destination table
            foreach (DataRow dr in results)
                dtFilter.ImportRow(dr);

            return dtFilter;
        }

        public override void OnSorting()
        {
            ShowMultiSortDialog(shtView);
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

        private void fpView_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }

        public override void OnAdvanceSearch()
        {
            base.OnAdvanceSearch();

            ShowAdvanceSearchDialog(shtView, typeof(eColView), m_dtAllData);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (DataDefine.ENABLED_AUTO_SEARCH_WHEN_PRESS_ENTER_KEY && e.KeyCode == Keys.Enter)
                FindDataFromMemory();
        }
    }
}
