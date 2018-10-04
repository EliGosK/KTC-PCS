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

namespace Rubik.Transaction
{
    [Screen("TRN180", "Customer Order List", eShowAction.Normal, eScreenType.ScreenPane, "Customer Order List")]
    public partial class TRN180_CustomerOrderList : SystemMaintenance.Forms.CustomizeListPaneBaseForm
    {
        #region Enum
        public enum eColView
        {
            ORDER_NO,
            ORDER_DETAIL_NO,
            RECEIVE_DATE,
            CUSTOMER_CD,
            LOC_DESC,
            ORDER_TYPE,
            CLS_DESC,
            PO_NO,
            PO_DATE,
            CURRENCY,
            EXCHANGE_RATE,
            REMARK,
            ITEM_CD,
            SHORT_NAME,
            ITEM_DELIVERY_DATE,
            QTY,
            PRICE,
            AMOUNT,
            AMOUNT_THB
        }
        #endregion

        #region Variables
        private readonly CustomerOrderController m_controller = new CustomerOrderController();
        private readonly TransactionValidator m_transactionValidator = new TransactionValidator();

        #endregion

        #region Constructor
        public TRN180_CustomerOrderList()
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

            dtPeriodBegin.Format = Common.CurrentUserInfomation.DateFormatString;
            dtPeriodEnd.Format = Common.CurrentUserInfomation.DateFormatString;

            CtrlUtil.EnabledControl(false, txtAmount, txtAmountTHB, txtQty);

            InventoryPeriodBIZ biz = new InventoryPeriodBIZ();
            InventoryPeriodDTO dto = biz.LoadCurrentPeriodWithQueryRange();
            if (dto != null)
            {
                dtPeriodBegin.Value = dto.PERIOD_BEGIN_DATE.StrongValue;
                dtPeriodEnd.Value = dto.PERIOD_END_DATE.StrongValue;
            }
        }

        private void InitializeSpread()
        {
            shtCustomerOrderList.ActiveSkin = Common.ACTIVE_SKIN;

            shtCustomerOrderList.Columns[(int)eColView.ORDER_DETAIL_NO].Visible = false;
            shtCustomerOrderList.Columns[(int)eColView.LOC_DESC].Visible = false;

            LookupDataBIZ biz = new LookupDataBIZ();

            NZString[] customerInfo = { (NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Customer)
                                      , (NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.CustomerVendor)
                                      , (NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Vendor)};

            LookupData customerLookup = biz.LoadLookupLocation(customerInfo);
            shtCustomerOrderList.Columns[(int)eColView.CUSTOMER_CD].CellType = CtrlUtil.CreateReadOnlyPairCellType(customerLookup);

            LookupData orderTypeLookup = biz.LoadLookupClassType(DataDefine.CUSTOMER_ORDER_TYPE.ToNZString());
            shtCustomerOrderList.Columns[(int)eColView.ORDER_TYPE].CellType = CtrlUtil.CreateReadOnlyPairCellType(orderTypeLookup);

            //LookupData umClassLookupData = biz.LoadLookupClassType(DataDefine.UM_CLS.ToNZString());
            //shtView.Columns[(int)eColView.ORDER_UM_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(umClassLookupData);
            //shtView.Columns[(int)eColView.INV_UM_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(umClassLookupData);

            //LookupData refTypeLookupData = biz.LoadLookupClassType(DataDefine.REF_SLIP_CLS.ToNZString());
            //shtView.Columns[(int)eColView.REF_SLIP_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(refTypeLookupData);

            //shtView.Columns[(int)eColView.TRANS_DATE].CellType = CtrlUtil.CreateDateTimeCellType();
            CtrlUtil.MappingDataFieldWithEnum(shtCustomerOrderList, typeof(eColView));
            CtrlUtil.SpreadUpdateColumnSorting(shtCustomerOrderList);

        }

        private void InitialFormat()
        {
            FormatUtil.SetNumberFormat(this.shtCustomerOrderList.Columns[(int)eColView.AMOUNT], FormatUtil.eNumberFormat.Amount);
            FormatUtil.SetNumberFormat(this.shtCustomerOrderList.Columns[(int)eColView.AMOUNT_THB], FormatUtil.eNumberFormat.Amount_THB);
            FormatUtil.SetNumberFormat(this.shtCustomerOrderList.Columns[(int)eColView.EXCHANGE_RATE], FormatUtil.eNumberFormat.ExchangeRate);
            FormatUtil.SetNumberFormat(this.shtCustomerOrderList.Columns[(int)eColView.PRICE], FormatUtil.eNumberFormat.UnitPrice);
            FormatUtil.SetNumberFormat(this.shtCustomerOrderList.Columns[(int)eColView.QTY], FormatUtil.eNumberFormat.Qty_PCS);

            FormatUtil.SetDateFormat(this.shtCustomerOrderList.Columns[(int)eColView.ITEM_DELIVERY_DATE]);
            FormatUtil.SetDateFormat(this.shtCustomerOrderList.Columns[(int)eColView.RECEIVE_DATE]);
            FormatUtil.SetDateFormat(this.shtCustomerOrderList.Columns[(int)eColView.PO_DATE]);

            FormatUtil.SetNumberFormat(this.txtAmount, FormatUtil.eNumberFormat.Amount);
            FormatUtil.SetNumberFormat(this.txtAmountTHB, FormatUtil.eNumberFormat.Amount_THB);
            FormatUtil.SetNumberFormat(this.txtQty, FormatUtil.eNumberFormat.Total_Qty_PCS);

            FormatUtil.SetNumberFormat(this.shtCustomerOrderList.Columns[(int)eColView.ITEM_CD], FormatUtil.eNumberFormat.MasterNo);

            CtrlUtil.EnabledControl(false, txtAmount, txtAmountTHB, txtQty);
        }

        #endregion

        #region Private method
        private void LoadData(NZDateTime from, NZDateTime to, NZInt filterType)
        {
            if (dtPeriodBegin.NZValue.IsNull || dtPeriodEnd.NZValue.IsNull)
            {
                if (dtPeriodBegin.NZValue.IsNull && dtPeriodEnd.NZValue.IsNull)
                    MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0105.ToString(), new object[] { "Period date begin and Delivery date end" }));
                else if (dtPeriodBegin.NZValue.IsNull)
                    MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0105.ToString(), new object[] { "Period date begin" }));
                else MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0105.ToString(), new object[] { "Period date end" }));
                return;
            }

            CustomerOrderBIZ biz = new CustomerOrderBIZ();
            DataTable dt = DTOUtility.ConvertListToDataTable<CustomerOrderViewDTO>(biz.LoadCustomerOrderList(from, to, filterType, false));
            shtCustomerOrderList.RowCount = 0;
            shtCustomerOrderList.DataSource = null;
            m_dtAllData = dt;
            FindDataFromMemory();
            CalculateTotal();
            //List<InventoryTransactionViewDTO> list = m_controller.LoadReceivingList(from, to);
            ////DataTable dt = DTOUtility.ConvertListToDataTable(list);
            //m_dtAllData = DTOUtility.ConvertListToDataTable(list);
            //shtCustomerOrderList.RowCount = 0;
            //shtCustomerOrderList.DataSource = null;
            //FindDataFromMemory();
            //shtView.DataSource = m_dtAllData;

            // CtrlUtil.SpreadUpdateColumnSorting(shtView);
        }
        #endregion

        #region Form event
        private void TRN180_Load(object sender, EventArgs e)
        {
            InitializeScreen();

            LookupDataBIZ biz = new LookupDataBIZ();
            LookupData CustOrderType = biz.LoadLookupClassType(DataDefine.CUSTOMER_ORDER_DATE_FILTER.ToNZString());
            cboFilterDate.LoadLookupData(CustOrderType);
            cboFilterDate.SelectedIndex = 0;

            NZInt dateType = null;
            int iDateValue = 0;
            object oDateValue = cboFilterDate.SelectedValue;

            if (oDateValue != null && Int32.TryParse(oDateValue.ToString(), out iDateValue))
            {
                dateType = new NZInt(null, iDateValue);
            }
            else
            {
                dateType = new NZInt(null, 1);
            }

            LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue, dateType);
        }

        private void TRN180_Shown(object sender, EventArgs e)
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

            NZInt dateType = null;
            int iDateValue = 0;
            object oDateValue = cboFilterDate.SelectedValue;

            if (oDateValue != null && Int32.TryParse(oDateValue.ToString(), out iDateValue))
            {
                dateType = new NZInt(null, iDateValue);
            }
            else
            {
                dateType = new NZInt(null, 1);
            }

            LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue, dateType);
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

                CellRange cellRange = fpCustomerOrderList.GetCellFromPixel(0, 0, e.X, e.Y);
                if (cellRange.Column != -1 && cellRange.Row != -1)
                {
                    shtCustomerOrderList.SetActiveCell(cellRange.Row, cellRange.Column);
                    shtCustomerOrderList.AddSelection(cellRange.Row, cellRange.Column, 1, 1);
                    isClickOnCell = true;
                }

                if (isClickOnCell)
                {
                    //NZString transID = new NZString(null,this.shtCustomerOrderList.Cells[cellRange.Row, (int)eColView.tr].Value);
                    //bool canEditOrDelete = m_transactionValidator.TransactionCanEditOrDelete(transID);

                    //miDelete.Enabled = canEditOrDelete && ActivePermission.Delete;
                    //miDeleteGroup.Enabled = canEditOrDelete && ActivePermission.Delete;
                    //miEdit.Enabled = canEditOrDelete && ActivePermission.Edit;

                    miDelete.Enabled = ActivePermission.Delete;
                    miDeleteGroup.Enabled = ActivePermission.Delete;
                    miEdit.Enabled = ActivePermission.Edit;
                }
                else
                {
                    miDelete.Enabled = false;
                    miDeleteGroup.Enabled = false;
                    miEdit.Enabled = false;
                }

                ctxMenu.Show(fpCustomerOrderList, e.Location);
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
            if (shtCustomerOrderList.RowCount > 0)
            {
                int rowIndex = shtCustomerOrderList.ActiveRowIndex;
                InventoryBIZ biz = new InventoryBIZ();
                InventoryTransactionDTO dto = new InventoryTransactionDTO();
                dto.REF_NO = shtCustomerOrderList.GetValue(rowIndex, (int)eColView.ORDER_NO).ToString().ToNZString();
                dto.REF_SLIP_NO = shtCustomerOrderList.GetValue(rowIndex, (int)eColView.ORDER_DETAIL_NO).ToString().ToNZString();
                dto.TRANS_CLS = DataDefine.eTRANS_TYPE_string.Shipment.ToNZString();
                //CustomerOrderDDTO LoadCustomerOrderDetail(String Order_No, NZString Order_Detail_No)
                List<InventoryTransactionDTO> listDTO = biz.LoadInventoryTrans(dto);
                decimal ShipQTY = 0;
                foreach (InventoryTransactionDTO dtos in listDTO)
                {
                    if (!dtos.QTY.IsNull && dtos.QTY.StrongValue > 0) ShipQTY += dtos.QTY.StrongValue;
                }
                if (ShipQTY > 0)
                {
                    MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0205.ToString()));
                    return;
                }
            }

            OnDelete();
        }
        #endregion
        #endregion

        #region Operation
        public override void OnAddNew()
        {
            base.OnAddNew();
            TRN190_CustomerOrderEntry dialog = new TRN190_CustomerOrderEntry();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                NZInt dateType = null;
                int iDateValue = 0;
                object oDateValue = cboFilterDate.SelectedValue;

                if (oDateValue != null && Int32.TryParse(oDateValue.ToString(), out iDateValue))
                {
                    dateType = new NZInt(null, iDateValue);
                }
                else
                {
                    dateType = new NZInt(null, 1);
                }

                LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue, dateType);
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
            if (shtCustomerOrderList.RowCount <= 0) return;
            NZString OrderNo = new NZString(null, shtCustomerOrderList.GetValue(shtCustomerOrderList.ActiveRowIndex, (int)eColView.ORDER_NO));
            TRN190_CustomerOrderEntry dialog = new TRN190_CustomerOrderEntry(OrderNo);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                NZInt dateType = null;
                int iDateValue = 0;
                object oDateValue = cboFilterDate.SelectedValue;

                if (oDateValue != null && Int32.TryParse(oDateValue.ToString(), out iDateValue))
                {
                    dateType = new NZInt(null, iDateValue);
                }
                else
                {
                    dateType = new NZInt(null, 1);
                }

                LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue, dateType);
            }
        }

        private void OnDelete()
        {
            try
            {
                NZString OrderNo = new NZString(null, shtCustomerOrderList.GetValue(shtCustomerOrderList.ActiveRowIndex, (int)eColView.ORDER_NO));
                NZString OrderDetailNo = new NZString(null, shtCustomerOrderList.GetValue(shtCustomerOrderList.ActiveRowIndex, (int)eColView.ORDER_DETAIL_NO));

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new Message(Messages.eConfirm.CFM9002.ToString()), MessageDialogButtons.YesNo);
                if (dr == MessageDialogResult.No)
                    return;

                m_controller.DeleteItem(OrderNo, OrderDetailNo);

                // When detail row <= 0 then delete header row
                CustomerOrderBIZ biz = new CustomerOrderBIZ();
                if (biz.LoadCustomerOrderEntry(OrderNo, false).Count <= 0)
                {
                    biz.DeleteCustomerOrderHeader(Common.CurrentDatabase, OrderNo);
                }

                shtCustomerOrderList.RemoveRows(shtCustomerOrderList.ActiveRowIndex, 1);

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
                NZString OrderNo = new NZString(null, shtCustomerOrderList.GetValue(shtCustomerOrderList.ActiveRowIndex, (int)eColView.ORDER_NO));

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new Message(Messages.eConfirm.CFM9002.ToString()), MessageDialogButtons.YesNo);
                if (dr == MessageDialogResult.No)
                    return;

                m_controller.DeleteGroupTransaction(OrderNo);

                //ไล่ลบจากล่างขึ้นบน เพราะว่าไม่งั้นindex จะเลื่อนแล้วจะลบไม่ครบ
                for (int iRowIndex = shtCustomerOrderList.RowCount - 1; iRowIndex >= 0; iRowIndex--)
                {
                    if (OrderNo.NVL("").Equals(shtCustomerOrderList.GetValue(iRowIndex, (int)eColView.ORDER_NO)))
                    {
                        shtCustomerOrderList.Rows.Remove(iRowIndex, 1);
                    }
                }

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
            shtCustomerOrderList.DataSource = FilterData(m_dtAllData, txtSearch.Text);
            CtrlUtil.SpreadUpdateColumnSorting(shtCustomerOrderList);
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
            if (shtCustomerOrderList.RowCount > 0)
            {
                int rowIndex = shtCustomerOrderList.ActiveRowIndex;
                InventoryBIZ biz = new InventoryBIZ();
                InventoryTransactionDTO dto = new InventoryTransactionDTO();
                dto.REF_NO = shtCustomerOrderList.GetValue(rowIndex, (int)eColView.ORDER_NO).ToString().ToNZString();
                dto.TRANS_CLS = DataDefine.eTRANS_TYPE_string.Shipment.ToNZString();
                //CustomerOrderDDTO LoadCustomerOrderDetail(String Order_No, NZString Order_Detail_No)
                List<InventoryTransactionDTO> listDTO = biz.LoadInventoryTrans(dto);
                decimal ShipQTY = 0;
                foreach (InventoryTransactionDTO dtos in listDTO)
                {
                    if (!dtos.QTY.IsNull && dtos.QTY.StrongValue > 0) ShipQTY += dtos.QTY.StrongValue;
                }
                if (ShipQTY > 0)
                {
                    MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0205.ToString()));
                    return;
                }
            }

            OnDeleteGroup();
        }

        public override void OnSorting()
        {
            ShowMultiSortDialog(shtCustomerOrderList);
        }

        public override void OnSaveFormat()
        {
            base.OnSaveFormat();

            SheetWidthController ctrl = new SheetWidthController();
            ctrl.SaveSheetWidth(shtCustomerOrderList, this.ScreenCode);
        }

        public override void OnResetFormat()
        {
            base.OnResetFormat();

            SheetWidthController ctrl = new SheetWidthController();
            ctrl.ResetSheetWidth(shtCustomerOrderList);
        }

        public override void OnAdvanceSearch()
        {
            base.OnAdvanceSearch();

            ShowAdvanceSearchDialog(shtCustomerOrderList, typeof(eColView), m_dtAllData);
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
            ctrl.SetSheetWidth(shtCustomerOrderList, this.ScreenCode);
        }


        private void CalculateTotal()
        {
            decimal decTotalQty = 0;
            decimal decTotalAmount = 0;
            decimal decTotalAmountTHB = 0;

            for (int i = 0; i < shtCustomerOrderList.RowCount; i++)
            {
                if (shtCustomerOrderList.GetRowVisible(i))
                {
                    decTotalQty += Convert.ToDecimal(shtCustomerOrderList.Cells[i, (int)eColView.QTY].Value);
                    decTotalAmount += Convert.ToDecimal(shtCustomerOrderList.Cells[i, (int)eColView.AMOUNT].Value);
                    decTotalAmountTHB += Convert.ToDecimal(shtCustomerOrderList.Cells[i, (int)eColView.AMOUNT_THB].Value);
                }
            }

            this.txtQty.Decimal = decTotalQty;
            this.txtAmount.Decimal = decTotalAmount;
            this.txtAmountTHB.Decimal = decTotalAmountTHB;
        }

        private void fpCustomerOrderList_AutoFilteredColumn(object sender, FarPoint.Win.Spread.AutoFilteredColumnEventArgs e)
        {
            CalculateTotal();
        }

        private void fpCustomerOrderList_KeyDown(object sender, KeyEventArgs e)
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
