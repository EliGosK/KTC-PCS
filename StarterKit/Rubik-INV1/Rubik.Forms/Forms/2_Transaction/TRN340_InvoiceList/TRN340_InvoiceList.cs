using System;
using System.Data;
using System.Windows.Forms;
using SystemMaintenance;
using CommonLib;
using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Windows.Forms;
using FarPoint.Win.Spread.Model;
using Rubik.BIZ;
using Rubik.Controller;
using Rubik.DTO;
using Rubik.UIDataModel;
using Rubik.Validators;
using Message = EVOFramework.Message;


namespace Rubik.Transaction
{
    //[Screen("TRN340", "Invoice List", eShowAction.Normal, eScreenType.ScreenPane, "Invoice List")]
    public partial class TRN340_InvoiceList : SystemMaintenance.Forms.CustomizeListPaneBaseForm
    {
        private enum eColView
        {
            TRANS_ID,
            GROUP_TRANS_ID,
            TRANS_DATE,
            SLIP_NO,
            DEALING_NO,
            LOC_DESC,
            ITEM_CD,
            SHORT_NAME,
            PO_NO,
            ORDER_NO,
            ORDER_DETAIL_NO,
            SHIP_QTY,
            REMARK,
            PACK_NO,
            LOT_NO,
            LOC_CD,
            CURRENCY,
            LOT_QTY,
            RETURN_QTY,
            PRICE,
            AMOUNT
        }

        private enum eReturnType
        {
            PACK,
            ORDER,
            GROUP
        }

        #region Variable

        private DataTable m_AllShipTransData;
        private readonly TransactionValidator m_transactionValidator = new TransactionValidator();
        #endregion

        public TRN340_InvoiceList()
        {
            InitializeComponent();
        }


        #region Initialize Screen
        private void InitialScreen()
        {
            InitailSpread();
            //InitialComboBox();
            //InitialFormat();

            //dtPeriodBegin.KeyPress += CtrlUtil.SetNextControl;
            //dtPeriodEnd.KeyPress += CtrlUtil.SetNextControl;

            ////txtSearch.KeyPress += CommonLib.CtrlUtil.SetRestrictKeyInput;
            ////txtSearch.KeyUp += CommonLib.CtrlUtil.FilterRestrictChar;

            //InventoryPeriodBIZ biz = new InventoryPeriodBIZ();
            //InventoryPeriodDTO dto = biz.LoadCurrentPeriodWithQueryRange();
            //if (dto != null)
            //{
            //    dtPeriodBegin.Value = dto.PERIOD_BEGIN_DATE.StrongValue;
            //    dtPeriodEnd.Value = dto.PERIOD_END_DATE.StrongValue;
            //}
            //LoadData();
        }

        private void InitialComboBox()
        {
            LookupDataBIZ bizLookup = new LookupDataBIZ();

            // Lookup Lot Control
            LookupData lookupTransType = bizLookup.LoadLookupClassType(new NZString(null, "TRANS_TYPE"));

            //ReadOnlyPairCellType TransTypecellType = new ReadOnlyPairCellType(lookupTransType, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            //shtView.Columns[(int)eColView.SHIP_TYPE].CellType = TransTypecellType;

            //// Lookup OrderLoc
            //LookupData lookupStoreLoc = bizLookup.LoadLookupLocation();
            //ReadOnlyPairCellType StoreLoc = new ReadOnlyPairCellType(lookupStoreLoc, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            //shtView.Columns[(int)eColView.STORED_LOC].CellType = StoreLoc;
        }

        private void LoadData()
        {
            //ShipmentListController ctl = new ShipmentListController();
            //m_AllShipTransData = ctl.LoadAllShipTransByPeriod(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
            if (dtPeriodBegin.NZValue.IsNull || dtPeriodEnd.NZValue.IsNull)
            {
                if (dtPeriodBegin.NZValue.IsNull && dtPeriodEnd.NZValue.IsNull)
                    MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0105.ToString(), new object[] { "Delivery date begin and Delivery date end" }));
                else if (dtPeriodBegin.NZValue.IsNull)
                    MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0105.ToString(), new object[] { "Delivery date begin" }));
                else MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0105.ToString(), new object[] { "Delivery date end" }));
                return;
            }

            DeliveryController ctl = new DeliveryController();
            m_AllShipTransData = ctl.Load_DeliveryList(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
            //shtView.DataSource = m_AllShipTransData;
            FindDataFromMemory();
            //CtrlUtil.SpreadUpdateColumnSorting(shtView);
        }

        private void InitailSpread()
        {
            shtDelivery.ActiveSkin = CommonLib.Common.ACTIVE_SKIN;

            //CtrlUtil.MappingDataFieldWithEnum(shtDelivery, typeof(eColView));

            ////shtView.Columns[(int)eColView.SHIP_DATE].CellType = CtrlUtil.CreateDateTimeCellType();

            //shtDelivery.Columns[(int)eColView.TRANS_ID].StyleName = DataDefine.EXPORT_LAST.ToString();
            //shtDelivery.Columns[(int)eColView.GROUP_TRANS_ID].StyleName = DataDefine.EXPORT_LAST.ToString();
            //shtDelivery.Columns[(int)eColView.LOC_CD].StyleName = DataDefine.NO_EXPORT.ToString();
            //shtDelivery.Columns[(int)eColView.CURRENCY].StyleName = DataDefine.NO_EXPORT.ToString();
            //shtDelivery.Columns[(int)eColView.RETURN_QTY].StyleName = DataDefine.NO_EXPORT.ToString();

            //shtDelivery.Columns[(int)eColView.TRANS_ID].Visible = false;
            //shtDelivery.Columns[(int)eColView.GROUP_TRANS_ID].Visible = false;
            //shtDelivery.Columns[(int)eColView.ORDER_DETAIL_NO].Visible = false;
            //shtDelivery.Columns[(int)eColView.LOC_CD].Visible = false;
            //shtDelivery.Columns[(int)eColView.LOC_DESC].Visible = false;
            //shtDelivery.Columns[(int)eColView.CURRENCY].Visible = false;
            //shtDelivery.Columns[(int)eColView.RETURN_QTY].Visible = false;

            //LookupDataBIZ m_bizLookupData = new LookupDataBIZ();

            //LookupData locData = m_bizLookupData.LoadLookupLocation();
            //shtDelivery.Columns[(int)eColView.DEALING_NO].CellType = CtrlUtil.CreateReadOnlyPairCellType(locData);

        }
        private void InitialFormat()
        {
            dtPeriodBegin.Format = Common.CurrentUserInfomation.DateFormatString;
            dtPeriodEnd.Format = Common.CurrentUserInfomation.DateFormatString;

            //// Set Control Format
            //CommonLib.FormatUtil.SetNumberFormat(this.txtQty, FormatUtil.eNumberFormat.Total_Qty_PCS);
            //CommonLib.FormatUtil.SetNumberFormat(this.txtAmount, FormatUtil.eNumberFormat.Amount);

            // Set Spread Format
            FormatUtil.SetDateFormat(shtDelivery.Columns[(int)eColView.TRANS_DATE]);
            FormatUtil.SetNumberFormat(shtDelivery.Columns[(int)eColView.SHIP_QTY], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtDelivery.Columns[(int)eColView.LOT_QTY], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtDelivery.Columns[(int)eColView.PRICE], FormatUtil.eNumberFormat.UnitPrice);
            FormatUtil.SetNumberFormat(shtDelivery.Columns[(int)eColView.AMOUNT], FormatUtil.eNumberFormat.Amount);
        }
        #endregion

        #region Private method
        private void OpenIssueScreen()
        {
            int activeRow = shtDelivery.ActiveRowIndex;
            ShipmentEntryUIDM uidm = new ShipmentEntryUIDM();
            uidm.TRANS_DATE.Value = shtDelivery.Cells[activeRow, (int)eColView.TRANS_DATE].Value;
            uidm.SLIP_NO.Value = shtDelivery.Cells[activeRow, (int)eColView.SLIP_NO].Value;
            uidm.DEALING_NO.Value = shtDelivery.Cells[activeRow, (int)eColView.DEALING_NO].Value;
            uidm.LOC_DESC.Value = shtDelivery.Cells[activeRow, (int)eColView.LOC_DESC].Value;
            uidm.ITEM_CD.Value = shtDelivery.Cells[activeRow, (int)eColView.ITEM_CD].Value;
            uidm.SHORT_NAME.Value = shtDelivery.Cells[activeRow, (int)eColView.SHORT_NAME].Value;
            uidm.PO_ON.Value = shtDelivery.Cells[activeRow, (int)eColView.PO_NO].Value;
            uidm.ORDER_NO.Value = shtDelivery.Cells[activeRow, (int)eColView.ORDER_NO].Value;
            uidm.SHIP_QTY.Value = shtDelivery.Cells[activeRow, (int)eColView.SHIP_QTY].Value;
            uidm.REMARK.Value = shtDelivery.Cells[activeRow, (int)eColView.REMARK].Value;
            uidm.PACK_NO.Value = shtDelivery.Cells[activeRow, (int)eColView.PACK_NO].Value;
            uidm.LOT_NO.Value = shtDelivery.Cells[activeRow, (int)eColView.LOT_NO].Value;
            uidm.LOT_QTY.Value = shtDelivery.Cells[activeRow, (int)eColView.LOT_QTY].Value;
            uidm.LOC_CD.Value = shtDelivery.Cells[activeRow, (int)eColView.LOC_CD].Value;
            uidm.CURRENCY.Value = shtDelivery.Cells[activeRow, (int)eColView.CURRENCY].Value;
            uidm.GROUP_TRANS_ID.Value = shtDelivery.Cells[activeRow, (int)eColView.GROUP_TRANS_ID].Value;

            TRN100_DeliveryEntry frmTRN100 = new TRN100_DeliveryEntry(uidm);

            if (frmTRN100.ShowDialog(this) == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void CalTotatValue()
        {
            decimal TotalQTY = 0;
            decimal TotalAmount = 0;
            for (int i = 0; i < shtDelivery.RowCount; i++)
            {
                TotalQTY += Convert.ToDecimal(shtDelivery.GetValue(i, (int)eColView.LOT_QTY));
                TotalAmount += Convert.ToDecimal(shtDelivery.GetValue(i, (int)eColView.AMOUNT));
            }
        }

        private bool CheckReturnQTY(eReturnType type, string SlipNo, string OrderDetailNo, string PackNo)
        {
            bool result = false;
            for (int i = 0; i < shtDelivery.RowCount; i++)
            {
                switch (type)
                {
                    case eReturnType.GROUP:
                        if (Convert.ToString(shtDelivery.GetValue(i, (int)eColView.SLIP_NO)) == SlipNo
                            && Convert.ToDecimal(shtDelivery.GetValue(i, (int)eColView.RETURN_QTY)) > 0)
                        {
                            result = true;
                        }
                        break;
                    case eReturnType.ORDER:
                        if (Convert.ToString(shtDelivery.GetValue(i, (int)eColView.ORDER_DETAIL_NO)) == OrderDetailNo
                            && Convert.ToDecimal(shtDelivery.GetValue(i, (int)eColView.RETURN_QTY)) > 0)
                        {
                            result = true;
                        }
                        break;
                    case eReturnType.PACK:
                        if (Convert.ToString(shtDelivery.GetValue(i, (int)eColView.PACK_NO)) == PackNo
                            && Convert.ToDecimal(shtDelivery.GetValue(i, (int)eColView.RETURN_QTY)) > 0)
                        {
                            result = true;
                        }
                        break;
                    default:
                        break;
                }
                if (result) break;
            }
            return result;
        }
        #endregion

        #region Form event
        private void TRN090_Load(object sender, EventArgs e)
        {
            InitialScreen();
        }

        private void TRN090_Shown(object sender, EventArgs e)
        {
            CtrlUtil.FocusControl(txtSearch);
        }
        #endregion

        #region Control Event
        //private void tsbNew_Click(object sender, EventArgs e)
        //{
        //    OnNew();
        //}
        public override void OnAddNew()
        {
            base.OnAddNew();
            OnNew();
        }
        public override void OnRefresh()
        {
            base.OnRefresh();
            LoadData();
        }
        //private void tsbRefresh_Click(object sender, EventArgs e)
        //{
        //    LoadData();
        //}

        //private void tsbExit_Click(object sender, EventArgs e)
        //{
        //    HidePane();
        //}

        private void fpView_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {

            if (!ActivePermission.Edit)
            {
                return;
            }
            //NZString transID = new NZString(null, shtView.Cells[e.Row, (int)eColView.TRANSACTION_ID].Value);
            //bool canEditOrDelete = m_transactionValidator.TransactionCanEditOrDelete(transID);
            OnEdit();

            //miEdit.PerformClick();
            //LoadData();
        }

        private void fpView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                bool isClickOnCell = false;

                CellRange cellRange = fpDelivery.GetCellFromPixel(0, 0, e.X, e.Y);
                if (cellRange.Column != -1 && cellRange.Row != -1)
                {
                    shtDelivery.SetActiveCell(cellRange.Row, cellRange.Column);
                    shtDelivery.AddSelection(cellRange.Row, cellRange.Column, 1, 1);
                    isClickOnCell = true;
                }

                if (isClickOnCell)
                {
                    //NZString transID = new NZString(null,this.shtDelivery.Cells[cellRange.Row, (int)eColView.TRANS_ID].Value);
                    //bool canEditOrDelete = m_transactionValidator.TransactionCanEditOrDelete(transID);

                    //if (Convert.ToDecimal(shtDelivery.GetValue(cellRange.Row, (int)eColView.RETURN_QTY)) > 0)
                    //{
                    //    miDeletePack.Enabled = false;
                    //    miDeleteOrder.Enabled = false;
                    //    miDeleteGroup.Enabled = false;
                    //}
                    //else
                    //{
                    //    miDeletePack.Enabled = canEditOrDelete && ActivePermission.Delete;
                    //    miDeleteOrder.Enabled = canEditOrDelete && ActivePermission.Delete;
                    //    miDeleteGroup.Enabled = canEditOrDelete && ActivePermission.Delete;
                    //}

                    //miEdit.Enabled = canEditOrDelete && ActivePermission.Edit;

                    miEdit.Enabled = ActivePermission.Edit;
                    miDeletePack.Enabled = ActivePermission.Delete;
                    miDeleteOrder.Enabled = ActivePermission.Delete;
                    miDeleteGroup.Enabled = ActivePermission.Delete;
                }
                else
                {
                    miEdit.Enabled = false;
                    miDeletePack.Enabled = false;
                    miDeleteOrder.Enabled = false;
                    miDeleteGroup.Enabled = false;
                }

                ctxMenu.Show(fpDelivery, e.Location);
            }
        }

        private void miEdit_Click(object sender, EventArgs e)
        {
            OnEdit();
        }

        private void miDeletePack_Click(object sender, EventArgs e)
        {
            //if (CheckReturnQTY(eReturnType.PACK, null, null, shtDelivery.GetValue(shtDelivery.ActiveRowIndex, (int)eColView.PACK_NO).ToString()))
            //{
            //    MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0202.ToString()));
            //    return;
            //}
            //MessageDialogResult dr = MessageDialog.ShowConfirmation(this, Message.LoadMessage(TKPMessages.eConfirm.CFM0007.ToString()));
            //switch (dr)
            //{
            //    case MessageDialogResult.Cancel:
            //        return;

            //    case MessageDialogResult.No:
            //        return;

            //    case MessageDialogResult.Yes:
            //        break;

            //}
            //OnDeletePack();
            //CalTotatValue();
            //LoadData();
        }

        private void miDeleteOrder_Click(object sender, EventArgs e)
        {
            //if (CheckReturnQTY(eReturnType.ORDER, null, shtDelivery.GetValue(shtDelivery.ActiveRowIndex, (int)eColView.ORDER_DETAIL_NO).ToString(), null))
            //{
            //    MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0202.ToString()));
            //    return;
            //}
            //MessageDialogResult dr = MessageDialog.ShowConfirmation(this, Message.LoadMessage(TKPMessages.eConfirm.CFM0008.ToString()));
            //switch (dr)
            //{
            //    case MessageDialogResult.Cancel:
            //        return;

            //    case MessageDialogResult.No:
            //        return;

            //    case MessageDialogResult.Yes:
            //        break;

            //}
            //OnDeleteOrder();
            //CalTotatValue();
            //LoadData();
        }

        private void miDeleteGroup_Click(object sender, EventArgs e)
        {
            //if (CheckReturnQTY(eReturnType.GROUP, shtDelivery.GetValue(shtDelivery.ActiveRowIndex, (int)eColView.SLIP_NO).ToString(), null, null))
            //{
            //    MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0202.ToString()));
            //    return;
            //}

            //MessageDialogResult dr = MessageDialog.ShowConfirmation(this, Message.LoadMessage(TKPMessages.eConfirm.CFM0009.ToString()));
            //switch (dr)
            //{
            //    case MessageDialogResult.Cancel:
            //        return;

            //    case MessageDialogResult.No:
            //        return;

            //    case MessageDialogResult.Yes:
            //        break;

            //}
            //OnDeleteGroup();
            //CalTotatValue();
            //LoadData();
        }
        #endregion

        #region Operation
        private void OnNew()
        {
            TRN350_InvoiceEntry frmTRN350 = new TRN350_InvoiceEntry();
            frmTRN350.ShowDialog();

            LoadData();
        }

        private void OnEdit()
        {
            if (shtDelivery.RowCount <= 0) return;
            //OpenIssueScreen();
        }

        private void OnDeletePack()
        {
            try
            {
                //NZString ItemCode = new NZString(null, shtDelivery.GetValue(shtDelivery.ActiveRowIndex, (int)eColView.ITEM_CD));
                //NZString LotNo = new NZString(null, shtDelivery.GetValue(shtDelivery.ActiveRowIndex, (int)eColView.LOT_NO));
                //NZString PackNo = new NZString(null, shtDelivery.GetValue(shtDelivery.ActiveRowIndex, (int)eColView.PACK_NO));
                NZString transID = new NZString(null, shtDelivery.GetValue(shtDelivery.ActiveRowIndex, (int)eColView.TRANS_ID));

                //MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new Message(Messages.eConfirm.CFM9002.ToString()), MessageDialogButtons.YesNo);
                //if (dr != MessageDialogResult.Yes)
                //    return;

                ShipmentListController ctl = new ShipmentListController();
                ctl.DeletePack(transID);

                String PackNo = Convert.ToString(shtDelivery.GetValue(shtDelivery.ActiveRowIndex, (int)eColView.PACK_NO));
                for (int i = shtDelivery.RowCount - 1; i >= 0; i--)
                {
                    if (Convert.ToString(shtDelivery.GetValue(i, (int)eColView.PACK_NO)) == PackNo)
                        shtDelivery.RemoveRows(i, 1);
                }
                LoadData();

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

        private void OnDeleteOrder()
        {
            try
            {
                NZString OrderDetail = new NZString(null, shtDelivery.GetValue(shtDelivery.ActiveRowIndex, (int)eColView.ORDER_DETAIL_NO));
                NZString transID = new NZString(null, shtDelivery.GetValue(shtDelivery.ActiveRowIndex, (int)eColView.TRANS_ID));

                ShipmentListController ctl = new ShipmentListController();
                ctl.DeleteOrder(transID);

                for (int i = shtDelivery.RowCount - 1; i >= 0; i--)
                {
                    if (Convert.ToString(shtDelivery.GetValue(i, (int)eColView.ORDER_DETAIL_NO)) == OrderDetail.StrongValue)
                        shtDelivery.RemoveRows(i, 1);
                }

                //shtDelivery.RemoveRows(shtDelivery.ActiveRowIndex, 1);
                LoadData();

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
                ctxMenu.Items[2].Enabled = ActivePermission.Delete;
                ctxMenu.Items[3].Enabled = ActivePermission.Delete;
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
            //CtrlUtil.FilterRestrictChar(txtSearch);
            shtDelivery.DataSource = FilterData(m_AllShipTransData, txtSearch.Text);
            CtrlUtil.SpreadUpdateColumnSorting(shtDelivery);
            CalTotatValue();
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
            DataRow[] results = m_AllShipTransData.Select(filterString);
            DataTable dtFilter = dtView.Clone();

            //populate new destination table
            foreach (DataRow dr in results)
                dtFilter.ImportRow(dr);

            return dtFilter;
        }



        private void OnDeleteGroup()
        {
            try
            {
                NZString transID = new NZString(null, shtDelivery.GetValue(shtDelivery.ActiveRowIndex, (int)eColView.TRANS_ID));
                NZString SlipNo = new NZString(null, shtDelivery.GetValue(shtDelivery.ActiveRowIndex, (int)eColView.SLIP_NO));

                ShipmentListController ctl = new ShipmentListController();
                ctl.DeleteGroupTransaction(transID);

                //ไล่ลบจากล่างขึ้นบน เพราะว่าไม่งั้นindex จะเลื่อนแล้วจะลบไม่ครบ
                for (int i = shtDelivery.RowCount - 1; i >= 0; i--)
                {
                    if (Convert.ToString(shtDelivery.GetValue(i, (int)eColView.SLIP_NO)) == SlipNo.StrongValue)
                        shtDelivery.RemoveRows(i, 1);
                }

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

        public override void OnSorting()
        {
            ShowMultiSortDialog(shtDelivery);
        }

        public override void OnSaveFormat()
        {
            base.OnSaveFormat();

            SheetWidthController ctrl = new SheetWidthController();
            ctrl.SaveSheetWidth(shtDelivery, this.ScreenCode);
        }

        public override void OnResetFormat()
        {
            base.OnResetFormat();

            SheetWidthController ctrl = new SheetWidthController();
            ctrl.ResetSheetWidth(shtDelivery);
        }

        public override void OnAdvanceSearch()
        {
            base.OnAdvanceSearch();

            ShowAdvanceSearchDialog(shtDelivery, typeof(eColView), m_AllShipTransData);
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
            ctrl.SetSheetWidth(shtDelivery, this.ScreenCode);
        }

        private void fpDelivery_KeyDown(object sender, KeyEventArgs e)
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
