using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Windows.Forms;
using FarPoint.Win.Spread.Model;
using Rubik.BIZ;
using CommonLib;
using Rubik.Controller;
using Rubik.DTO;
using SystemMaintenance;
using Message = EVOFramework.Message;
using Rubik.Validators;
using Rubik.UIDataModel;

namespace Rubik.Transaction
{
    [Screen("TRN290", "Move Process List", eShowAction.Normal, eScreenType.ScreenPane, "Move Process List")]
    public partial class TRN290_MovePartList : SystemMaintenance.Forms.CustomizeListPaneBaseForm
    {
        #region Enum
        public enum eColView
        {
            TRANS_ID_FROM,
            TRANS_ID_TO,
            MOVE_DATE,
            MASTER_NO,
            PART_NO,
            FROM_PROCESS,
            FROM_PROCESS_NAME,
            TO_PROCESS,
            TO_PROCESS_NAME,
            LOT_NO,
            MOVE_QTY,
            CUSTOMER_CD,
            CUSTOMER_NAME,
            SHIFT_CLS,
            SHIFT_CLS_NAME,
            MOVE_NO,
            REASON,
            REASON_NAME,
            REMARK,
            WEIGHT
        }
        #endregion

        #region Variables

        private readonly MovePartController m_controller = new MovePartController();
        private readonly TransactionValidator m_transactionValidator = new TransactionValidator();
        private DataTable m_dtAllData;

        #endregion

        #region Constructor
        public TRN290_MovePartList()
        {
            InitializeComponent();
        }
        #endregion

        #region InitializeScreen

        private void InitializeScreen()
        {
            InitializeSpread();
            InitialFormat();

            //txt.KeyPress += CommonLib.CtrlUtil.SetRestrictKeyInput;
            //txtSearch.KeyPress += CommonLib.CtrlUtil.SetRestrictKeyInput;
            //txtSearch.TextChanged += CommonLib.CtrlUtil.FilterRestrictChar;

            dtPeriodBegin.KeyPress += CtrlUtil.SetNextControl;
            dtPeriodEnd.KeyPress += CtrlUtil.SetNextControl;
        }
        private void InitializeSpread()
        {
            shtMovePartList.ActiveSkin = Common.ACTIVE_SKIN;

            LookupDataBIZ biz = new LookupDataBIZ();

            NZString[] locationtype = new NZString[1];
            locationtype[0] = DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Production).ToNZString();
            LookupData fromProcess = biz.LoadLookupLocation(locationtype);
            shtMovePartList.Columns[(int)eColView.FROM_PROCESS].CellType = CtrlUtil.CreateReadOnlyPairCellType(fromProcess);

            LookupData toProcess = biz.LoadLookupLocation(locationtype);
            shtMovePartList.Columns[(int)eColView.TO_PROCESS].CellType = CtrlUtil.CreateReadOnlyPairCellType(toProcess);

            LookupData moveReason = biz.LoadLookupClassType(DataDefine.MOVE_REASON.ToNZString());
            shtMovePartList.Columns[(int)eColView.REASON].CellType = CtrlUtil.CreateReadOnlyPairCellType(moveReason);

            LookupData shiftCls = biz.LoadLookupClassType(DataDefine.SHIFT_CLS.ToNZString());
            shtMovePartList.Columns[(int)eColView.SHIFT_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(shiftCls);

            shtMovePartList.Columns[(int)eColView.MOVE_DATE].CellType = CtrlUtil.CreateDateTimeCellType();

            shtMovePartList.Columns[(int)eColView.TRANS_ID_FROM].StyleName = DataDefine.EXPORT_LAST.ToString();
            shtMovePartList.Columns[(int)eColView.TRANS_ID_TO].StyleName = DataDefine.EXPORT_LAST.ToString();
            shtMovePartList.Columns[(int)eColView.CUSTOMER_CD].StyleName = DataDefine.NO_EXPORT.ToString();
            shtMovePartList.Columns[(int)eColView.WEIGHT].StyleName = DataDefine.NO_EXPORT.ToString();

            shtMovePartList.Columns[(int)eColView.TRANS_ID_FROM].Visible = false;
            shtMovePartList.Columns[(int)eColView.TRANS_ID_TO].Visible = false;
            shtMovePartList.Columns[(int)eColView.CUSTOMER_CD].Visible = false;
            shtMovePartList.Columns[(int)eColView.SHIFT_CLS_NAME].Visible = false;
            shtMovePartList.Columns[(int)eColView.FROM_PROCESS_NAME].Visible = false;
            shtMovePartList.Columns[(int)eColView.TO_PROCESS_NAME].Visible = false;
            shtMovePartList.Columns[(int)eColView.REASON_NAME].Visible = false;
            shtMovePartList.Columns[(int)eColView.WEIGHT].Visible = false;

            CtrlUtil.MappingDataFieldWithEnum(shtMovePartList, typeof(eColView));
        }
        private void InitialFormat()
        {
            FormatUtil.SetNumberFormat(shtMovePartList.Columns[(int)eColView.MOVE_QTY], FormatUtil.eNumberFormat.Qty_PCS);

            CommonLib.FormatUtil.SetDateFormat(shtMovePartList.Columns[(int)eColView.MOVE_DATE]);
            CommonLib.FormatUtil.SetDateFormat(dtPeriodBegin);
            CommonLib.FormatUtil.SetDateFormat(dtPeriodEnd);
        }

        #endregion

        #region Private method

        private void LoadData(NZDateTime from, NZDateTime to)
        {
            m_dtAllData = m_controller.LoadMovePartList(from, to);
            shtMovePartList.RowCount = 0;
            shtMovePartList.DataSource = null;
            FindDataFromMemory();
        }
        private void OpenMovePartEntryScreen()
        {
            if (!ActivePermission.Edit)
            {
                return;
            }

            MovePartUIDM uidm = new MovePartUIDM();
            uidm.CUSTOMER_CD = new NZString(null, shtMovePartList.GetValue(shtMovePartList.ActiveRowIndex, (int)eColView.CUSTOMER_CD));
            uidm.CUSTOMER_NAME = new NZString(null, shtMovePartList.GetValue(shtMovePartList.ActiveRowIndex, (int)eColView.CUSTOMER_NAME));
            uidm.FROM_PROCESS = new NZString(null, shtMovePartList.GetValue(shtMovePartList.ActiveRowIndex, (int)eColView.FROM_PROCESS));
            uidm.FROM_PROCESS_NAME = new NZString(null, shtMovePartList.GetValue(shtMovePartList.ActiveRowIndex, (int)eColView.FROM_PROCESS_NAME));
            uidm.LOT_NO = new NZString(null, shtMovePartList.GetValue(shtMovePartList.ActiveRowIndex, (int)eColView.LOT_NO));
            uidm.MASTER_NO = new NZString(null, shtMovePartList.GetValue(shtMovePartList.ActiveRowIndex, (int)eColView.MASTER_NO));
            uidm.MOVE_DATE = new NZDateTime(null, shtMovePartList.GetValue(shtMovePartList.ActiveRowIndex, (int)eColView.MOVE_DATE));
            uidm.MOVE_NO = new NZString(null, shtMovePartList.GetValue(shtMovePartList.ActiveRowIndex, (int)eColView.MOVE_NO));
            uidm.MOVE_QTY = new NZDecimal(null, shtMovePartList.GetValue(shtMovePartList.ActiveRowIndex, (int)eColView.MOVE_QTY));
            uidm.PART_NO = new NZString(null, shtMovePartList.GetValue(shtMovePartList.ActiveRowIndex, (int)eColView.PART_NO));
            uidm.REASON = new NZString(null, shtMovePartList.GetValue(shtMovePartList.ActiveRowIndex, (int)eColView.REASON));
            uidm.REASON_NAME = new NZString(null, shtMovePartList.GetValue(shtMovePartList.ActiveRowIndex, (int)eColView.REASON_NAME));
            uidm.REMARK = new NZString(null, shtMovePartList.GetValue(shtMovePartList.ActiveRowIndex, (int)eColView.REMARK));
            uidm.SHIFT_CLS = new NZString(null, shtMovePartList.GetValue(shtMovePartList.ActiveRowIndex, (int)eColView.SHIFT_CLS));
            uidm.SHIFT_CLS_NAME = new NZString(null, shtMovePartList.GetValue(shtMovePartList.ActiveRowIndex, (int)eColView.SHIFT_CLS_NAME));
            uidm.TO_PROCESS = new NZString(null, shtMovePartList.GetValue(shtMovePartList.ActiveRowIndex, (int)eColView.TO_PROCESS));
            uidm.TO_PROCESS_NAME = new NZString(null, shtMovePartList.GetValue(shtMovePartList.ActiveRowIndex, (int)eColView.TO_PROCESS_NAME));
            uidm.TRANS_ID_FROM = new NZString(null, shtMovePartList.GetValue(shtMovePartList.ActiveRowIndex, (int)eColView.TRANS_ID_FROM));
            uidm.TRANS_ID_TO = new NZString(null, shtMovePartList.GetValue(shtMovePartList.ActiveRowIndex, (int)eColView.TRANS_ID_TO));
            uidm.WEIGHT = new NZDecimal(null, shtMovePartList.GetValue(shtMovePartList.ActiveRowIndex, (int)eColView.WEIGHT));

            TRN300_MovePartEntry dialog = new TRN300_MovePartEntry(uidm);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
            }
        }
        private void FindDataFromMemory()
        {
            shtMovePartList.DataSource = FilterData(m_dtAllData, txtSearch.Text);
            CtrlUtil.SpreadUpdateColumnSorting(shtMovePartList);
        }
        private DataTable FilterData(DataTable dtView, string filterText)
        {
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
                DataRow[] results = m_dtAllData.Select(filterString);
                DataTable dtFilter = dtView.Clone();

                //populate new destination table
                foreach (DataRow dr in results)
                    dtFilter.ImportRow(dr);

                return dtFilter;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
            return null;
        }

        #endregion

        #region Override

        public override void OnRefresh()
        {
            base.OnRefresh();
            LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
        }
        public override void OnSorting()
        {
            ShowMultiSortDialog(shtMovePartList);
        }

        public override void OnSaveFormat()
        {
            base.OnSaveFormat();

            SheetWidthController ctrl = new SheetWidthController();
            ctrl.SaveSheetWidth(shtMovePartList, this.ScreenCode);
        }

        public override void OnResetFormat()
        {
            base.OnResetFormat();

            SheetWidthController ctrl = new SheetWidthController();
            ctrl.ResetSheetWidth(shtMovePartList);
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
            ctrl.SetSheetWidth(shtMovePartList, this.ScreenCode);
        }

        #endregion

        #region Form event

        private void TRN010_Load(object sender, EventArgs e)
        {
            InitializeScreen();

            InventoryPeriodBIZ biz = new InventoryPeriodBIZ();
            InventoryPeriodDTO dto = biz.LoadCurrentPeriodWithQueryRange();
            dtPeriodBegin.NZValue = dto.PERIOD_BEGIN_DATE;
            dtPeriodEnd.NZValue = dto.PERIOD_END_DATE;

            LoadData(dto.PERIOD_BEGIN_DATE, dto.PERIOD_END_DATE);
        }
        private void TRN010_Shown(object sender, EventArgs e)
        {
            CtrlUtil.FocusControl(txtSearch);
        }

        #endregion

        #region Control event
        #region Screen control

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (DataDefine.ENABLED_AUTO_SEARCH_WHEN_TEXT_CHANGED)
            {
                FindDataFromMemory();
            }
        }

        #endregion

        #region Spread
        private void fpView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                bool isClickOnCell = false;

                CellRange cellRange = fpMovePartList.GetCellFromPixel(0, 0, e.X, e.Y);
                if (cellRange.Column != -1 && cellRange.Row != -1)
                {
                    shtMovePartList.SetActiveCell(cellRange.Row, cellRange.Column);
                    shtMovePartList.AddSelection(cellRange.Row, cellRange.Column, 1, 1);
                    isClickOnCell = true;
                }

                if (isClickOnCell)
                {
                    NZString transID = new NZString(null, shtMovePartList.Cells[cellRange.Row, (int)eColView.TRANS_ID_FROM].Value);
                    bool canEditOrDelete = m_transactionValidator.TransactionCanEditOrDelete(transID);

                    miDelete.Enabled = canEditOrDelete && ActivePermission.Delete;
                    miDeleteGroup.Enabled = canEditOrDelete && ActivePermission.Delete;
                    miEdit.Enabled = canEditOrDelete && ActivePermission.Edit;
                }
                else
                {
                    miDelete.Enabled = false;
                    miDeleteGroup.Enabled = false;
                    miEdit.Enabled = false;
                }

                ctxMenu.Show(fpMovePartList, e.Location);
            }

        }
        private void fpView_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            OnEdit();
        }
        private void fpView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                OnEdit();
            }
        }
        #endregion

        #region Context Menu
        private void miEdit_Click(object sender, EventArgs e)
        {
            OnEdit();
        }
        private void miDelete_Click(object sender, EventArgs e)
        {
            OnDelete();
        }
        private void miDeleteGroup_Click(object sender, EventArgs e)
        {
            OnDeleteGroup();
        }
        #endregion
        #endregion

        #region Operation
        public override void OnAddNew()
        {
            base.OnAddNew();
            TRN300_MovePartEntry dialog = new TRN300_MovePartEntry();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
            }
        }
        //private void OnNew()
        //{
        //    TRN020 dialog = new TRN020();
        //    if (dialog.ShowDialog(this) == DialogResult.OK)
        //    {
        //        LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
        //    }
        //}

        private void OnEdit()
        {
            if (shtMovePartList.RowCount <= 0) return;
            OpenMovePartEntryScreen();
        }

        private void OnDelete()
        {
            try
            {
                NZString transIDFrom = new NZString(null, shtMovePartList.GetValue(shtMovePartList.ActiveRowIndex, (int)eColView.TRANS_ID_FROM));
                NZString transIDTo = new NZString(null, shtMovePartList.GetValue(shtMovePartList.ActiveRowIndex, (int)eColView.TRANS_ID_TO));

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new Message(Messages.eConfirm.CFM9002.ToString()), MessageDialogButtons.YesNo);
                if (dr == MessageDialogResult.No)
                    return;

                m_controller.DeleteMovePart(transIDFrom, transIDTo);
                LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);

                MessageDialog.ShowInformation(this, null, new Message(Messages.eInformation.INF9003.ToString()).MessageDescription);
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

        private void OnDeleteGroup()
        {
            try
            {
                //NZString receiveNo = new NZString(null, shtMovePartList.GetValue(shtMovePartList.ActiveRowIndex, (int)eColView.SLIP_NO));

                //MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new Message(Messages.eConfirm.CFM9002.ToString()), MessageDialogButtons.YesNo);
                //if (dr == MessageDialogResult.No)
                //    return;

                ////m_controller.DeleteGroupTransaction(receiveNo);

                ////ไล่ลบจากล่างขึ้นบน เพราะว่าไม่งั้นindex จะเลื่อนแล้วจะลบไม่ครบ
                //for (int iRowIndex = shtMovePartList.RowCount - 1; iRowIndex >= 0; iRowIndex--)
                //{
                //    if (receiveNo.NVL("").Equals(shtMovePartList.GetValue(iRowIndex, (int)eColView.SLIP_NO)))
                //    {
                //        shtMovePartList.Rows.Remove(iRowIndex, 1);
                //    }
                //}

                //LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);

                MessageDialog.ShowInformation(this, null, new Message(Messages.eInformation.INF9003.ToString()).MessageDescription);
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

        private void fpMovePartList_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }

        public override void OnAdvanceSearch()
        {
            base.OnAdvanceSearch();

            ShowAdvanceSearchDialog(shtMovePartList, typeof(eColView), m_dtAllData);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (DataDefine.ENABLED_AUTO_SEARCH_WHEN_PRESS_ENTER_KEY && e.KeyCode == Keys.Enter)
                FindDataFromMemory();
        }

    }
}
