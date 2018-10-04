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
    [Screen("TRN260", "Return Product List", eShowAction.Normal, eScreenType.ScreenPane, "Return Product List")]
    public partial class TRN260_ReturnProductList : SystemMaintenance.Forms.CustomizeListPaneBaseForm
    {
        #region Enum
        public enum eColView
        {
            SLIP_NO,
            RETURN_TRANS_ID,
            TRANS_ID,
            DELIVERY_TRANS_ID,
            TRANS_DATE,
            DEALING_NO,
            LOC_DESC,
            ITEM_CD,
            SHORT_NAME,
            PO_NO,
            ORDER_NO,
            PACK_NO,
            FG_NO,
            LOT_NO,
            EXTERNAL_LOT_NO,
            DELIVERY_DATE,
            RETURN_QTY,
            RETURN_NO,
            RETURN_LOC,
            REMARK
        }
        #endregion

        #region Variables
        private readonly ReturnController m_controller = new ReturnController();
        private readonly ShipmentListController ctrl_Shipment = new ShipmentListController();
        private readonly TransactionValidator m_transactionValidator = new TransactionValidator();

        private string m_strDefaultLocation = "RETURN";

        #endregion

        #region Constructor
        public TRN260_ReturnProductList()
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

            //dtPeriodBegin.Format = Common.CurrentUserInfomation.DateFormatString;
            //dtPeriodEnd.Format = Common.CurrentUserInfomation.DateFormatString;
        }

        private void InitializeSpread()
        {
            shtReturnProductList.ActiveSkin = Common.ACTIVE_SKIN;

            //LookupDataBIZ biz = new LookupDataBIZ();
            //NZString[] classInfos = {
            //                            (NZString) DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Receiving),
            //                            (NZString) DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Receive_Return)
            //                        };

            //LookupData receiveTypeLookupData = biz.LoadLookupClassType(DataDefine.TRANS_TYPE.ToNZString(), classInfos);
            //shtView.Columns[(int)eColView.TRANS_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(receiveTypeLookupData);

            //LookupData locationLookupData = biz.LoadLookupLocation();
            //shtView.Columns[(int)eColView.LOC_CD].CellType = CtrlUtil.CreateReadOnlyPairCellType(locationLookupData);
            //shtView.Columns[(int)eColView.DEALING_NO].CellType = CtrlUtil.CreateReadOnlyPairCellType(locationLookupData);

            //LookupData umClassLookupData = biz.LoadLookupClassType(DataDefine.UM_CLS.ToNZString());
            //shtView.Columns[(int)eColView.ORDER_UM_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(umClassLookupData);
            //shtView.Columns[(int)eColView.INV_UM_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(umClassLookupData);

            //LookupData refTypeLookupData = biz.LoadLookupClassType(DataDefine.REF_SLIP_CLS.ToNZString());
            //shtView.Columns[(int)eColView.REF_SLIP_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(refTypeLookupData);

            //shtView.Columns[(int)eColView.TRANS_DATE].CellType = CtrlUtil.CreateDateTimeCellType();

            shtReturnProductList.Columns[(int)eColView.SLIP_NO].StyleName = DataDefine.NO_EXPORT.ToString();
            shtReturnProductList.Columns[(int)eColView.RETURN_TRANS_ID].StyleName = DataDefine.EXPORT_LAST.ToString();
            shtReturnProductList.Columns[(int)eColView.TRANS_ID].StyleName = DataDefine.EXPORT_LAST.ToString();
            shtReturnProductList.Columns[(int)eColView.DELIVERY_TRANS_ID].StyleName = DataDefine.EXPORT_LAST.ToString();

            shtReturnProductList.Columns[(int)eColView.SLIP_NO].Visible = false;
            shtReturnProductList.Columns[(int)eColView.RETURN_TRANS_ID].Visible = false;
            shtReturnProductList.Columns[(int)eColView.TRANS_ID].Visible = false;
            shtReturnProductList.Columns[(int)eColView.DELIVERY_TRANS_ID].Visible = false;
            shtReturnProductList.Columns[(int)eColView.LOC_DESC].Visible = false;

            CtrlUtil.MappingDataFieldWithEnum(shtReturnProductList, typeof(eColView));


            LookupDataBIZ m_bizLookupData = new LookupDataBIZ();

            LookupData locData = m_bizLookupData.LoadLookupLocation();
            shtReturnProductList.Columns[(int)eColView.DEALING_NO].CellType = CtrlUtil.CreateReadOnlyPairCellType(locData);

        }

        private void InitialFormat()
        {
            // Set Control Format
            CommonLib.FormatUtil.SetDateFormat(this.dtPeriodBegin);
            CommonLib.FormatUtil.SetDateFormat(this.dtPeriodEnd);

            // Set Spread Format
            FormatUtil.SetDateFormat(shtReturnProductList.Columns[(int)eColView.TRANS_DATE]);
            FormatUtil.SetDateFormat(shtReturnProductList.Columns[(int)eColView.DELIVERY_DATE]);
            FormatUtil.SetNumberFormat(shtReturnProductList.Columns[(int)eColView.RETURN_QTY], FormatUtil.eNumberFormat.Qty_PCS);
        }
        #endregion

        #region Private method
        private void LoadData(NZDateTime from, NZDateTime to)
        {
            if (dtPeriodBegin.NZValue.IsNull || dtPeriodEnd.NZValue.IsNull)
            {
                if (dtPeriodBegin.NZValue.IsNull && dtPeriodEnd.NZValue.IsNull)
                    MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0105.ToString(), new object[] { "Return date begin and Delivery date end" }));
                else if (dtPeriodBegin.NZValue.IsNull)
                    MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0105.ToString(), new object[] { "Return date begin" }));
                else MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0105.ToString(), new object[] { "Return date end" }));
                return;
            }

            DataTable dt = m_controller.Load_ReturnProductionList(from, to, false);
            //DataTable dt = DTOUtility.ConvertListToDataTable(list);
            m_dtAllData = dt;
            shtReturnProductList.RowCount = 0;
            shtReturnProductList.DataSource = null;
            FindDataFromMemory();
            //shtReturnProductList.DataSource = m_dtAllData;

            CtrlUtil.SpreadUpdateColumnSorting(shtReturnProductList);
        }
        #endregion

        #region Form event
        private void TRN260_Load(object sender, EventArgs e)
        {
            InitializeScreen();

            InventoryPeriodBIZ biz = new InventoryPeriodBIZ();
            InventoryPeriodDTO dto = biz.LoadCurrentPeriodWithQueryRange();
            dtPeriodBegin.NZValue = dto.PERIOD_BEGIN_DATE;
            dtPeriodEnd.NZValue = dto.PERIOD_END_DATE;

            LoadData(dto.PERIOD_BEGIN_DATE, dto.PERIOD_END_DATE);
        }

        private void TRN260_Shown(object sender, EventArgs e)
        {
            CtrlUtil.FocusControl(txtSearch);
        }
        #endregion

        #region Control event
        #region Screen control
        //private void tsbRefresh_Click(object sender, EventArgs e)
        //{
        //    LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
        //}
        public override void OnRefresh()
        {
            base.OnRefresh();
            LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
        }
        //private void tsbNew_Click(object sender, EventArgs e)
        //{
        //    OnNew();
        //}
        //public override void OnExit()
        //{
        //    base.OnExit();
        //}
        //private void tsbExit_Click(object sender, EventArgs e)
        //{
        //    this.HidePane();
        //}
        #endregion

        #region Spread
        private void fpView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                bool isClickOnCell = false;

                CellRange cellRange = fpReturnProductList.GetCellFromPixel(0, 0, e.X, e.Y);
                if (cellRange.Column != -1 && cellRange.Row != -1)
                {
                    shtReturnProductList.SetActiveCell(cellRange.Row, cellRange.Column);
                    shtReturnProductList.AddSelection(cellRange.Row, cellRange.Column, 1, 1);
                    isClickOnCell = true;
                }

                if (isClickOnCell)
                {
                    NZString transID = new NZString(null, shtReturnProductList.Cells[cellRange.Row, (int)eColView.RETURN_TRANS_ID].Value);
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

                ctxMenu.Show(fpReturnProductList, e.Location);
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
        #endregion
        #endregion

        #region Operation
        public override void OnAddNew()
        {
            base.OnAddNew();
            TRN270_ReturnProductEntry dialog = new TRN270_ReturnProductEntry();
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
            if (!ActivePermission.Edit)
            {
                return;
            }
            if (shtReturnProductList.RowCount <= 0) return;
            int activeRow = shtReturnProductList.ActiveRowIndex;
            ReturnEntryUIDM uidm = new ReturnEntryUIDM();
            uidm.TRANS_DATE.Value = shtReturnProductList.Cells[activeRow, (int)eColView.TRANS_DATE].Value;
            uidm.REF_NO.Value = shtReturnProductList.Cells[activeRow, (int)eColView.DELIVERY_TRANS_ID].Value;
            uidm.SLIP_NO.Value = shtReturnProductList.Cells[activeRow, (int)eColView.SLIP_NO].Value;
            uidm.DEALING_NO.Value = shtReturnProductList.Cells[activeRow, (int)eColView.DEALING_NO].Value;
            uidm.LOC_DESC.Value = shtReturnProductList.Cells[activeRow, (int)eColView.LOC_DESC].Value;
            uidm.ITEM_CD.Value = shtReturnProductList.Cells[activeRow, (int)eColView.ITEM_CD].Value;
            uidm.SHORT_NAME.Value = shtReturnProductList.Cells[activeRow, (int)eColView.SHORT_NAME].Value;
            uidm.PO_ON.Value = shtReturnProductList.Cells[activeRow, (int)eColView.PO_NO].Value;
            uidm.ORDER_NO.Value = shtReturnProductList.Cells[activeRow, (int)eColView.ORDER_NO].Value;
            uidm.REMARK.Value = shtReturnProductList.Cells[activeRow, (int)eColView.REMARK].Value;
            uidm.PACK_NO.Value = shtReturnProductList.Cells[activeRow, (int)eColView.PACK_NO].Value;
            uidm.FG_NO.Value = shtReturnProductList.Cells[activeRow, (int)eColView.FG_NO].Value;
            uidm.LOT_NO.Value = shtReturnProductList.Cells[activeRow, (int)eColView.LOT_NO].Value;
            uidm.LOT_QTY.Value = shtReturnProductList.Cells[activeRow, (int)eColView.RETURN_QTY].Value;
            uidm.LOC_CD.Value = shtReturnProductList.Cells[activeRow, (int)eColView.RETURN_LOC].Value;

            TRN270_ReturnProductEntry dialog = new TRN270_ReturnProductEntry(uidm);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
            }
        }

        private void OnDelete()
        {
            try
            {
                NZString transID = new NZString(null, shtReturnProductList.GetValue(shtReturnProductList.ActiveRowIndex, (int)eColView.RETURN_TRANS_ID));
                NZDecimal ReturnQTY = new NZDecimal(null, shtReturnProductList.GetValue(shtReturnProductList.ActiveRowIndex, (int)eColView.RETURN_QTY));

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new Message(Messages.eConfirm.CFM9002.ToString()), MessageDialogButtons.YesNo);
                if (dr == MessageDialogResult.No)
                    return;

                ctrl_Shipment.DeleteItem_Return(transID);
                shtReturnProductList.RemoveRows(shtReturnProductList.ActiveRowIndex, 1);
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
                NZString SlipNo = new NZString(null, shtReturnProductList.GetValue(shtReturnProductList.ActiveRowIndex, (int)eColView.SLIP_NO));
                NZString TransID = new NZString(null, shtReturnProductList.GetValue(shtReturnProductList.ActiveRowIndex, (int)eColView.RETURN_TRANS_ID));
                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new Message(TKPMessages.eConfirm.CFM0010.ToString()), MessageDialogButtons.YesNo);
                if (dr == MessageDialogResult.No)
                    return;

                ctrl_Shipment.DeleteGroupTransaction(TransID);

                //ไล่ลบจากล่างขึ้นบน เพราะว่าไม่งั้นindex จะเลื่อนแล้วจะลบไม่ครบ
                for (int iRowIndex = shtReturnProductList.RowCount - 1; iRowIndex >= 0; iRowIndex--)
                {
                    if (SlipNo.NVL("").Equals(shtReturnProductList.GetValue(iRowIndex, (int)eColView.SLIP_NO)))
                    {
                        shtReturnProductList.Rows.Remove(iRowIndex, 1);
                    }
                }

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
            //CtrlUtil.FilterRestrictChar(txtSearch);
            shtReturnProductList.DataSource = FilterData(m_dtAllData, txtSearch.Text);
            CtrlUtil.SpreadUpdateColumnSorting(shtReturnProductList);
        }

        private DataTable FilterData(DataTable dtView, string filterText)
        {
            try
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
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
            return null;
        }

        private void miDeleteGroup_Click(object sender, EventArgs e)
        {
            OnDeleteGroup();
        }

        public override void OnSorting()
        {
            ShowMultiSortDialog(shtReturnProductList);
        }

        public override void OnSaveFormat()
        {
            base.OnSaveFormat();

            SheetWidthController ctrl = new SheetWidthController();
            ctrl.SaveSheetWidth(shtReturnProductList, this.ScreenCode);
        }

        public override void OnResetFormat()
        {
            base.OnResetFormat();

            SheetWidthController ctrl = new SheetWidthController();
            ctrl.ResetSheetWidth(shtReturnProductList);
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
            ctrl.SetSheetWidth(shtReturnProductList, this.ScreenCode);
        }

        private void fpReturnProductList_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }

        public override void OnAdvanceSearch()
        {
            base.OnAdvanceSearch();

            ShowAdvanceSearchDialog(shtReturnProductList, typeof(eColView), m_dtAllData);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (DataDefine.ENABLED_AUTO_SEARCH_WHEN_PRESS_ENTER_KEY && e.KeyCode == Keys.Enter)
                FindDataFromMemory();
        }
    }
}
