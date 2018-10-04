using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using EVOFramework.Windows.Forms;
using CommonLib;
using FarPoint.Win.Spread;
using Rubik.BIZ;
using EVOFramework.Data;
using EVOFramework;
using Rubik.DTO;
using Rubik.Validators;
using Rubik.UIDataModel;
using Rubik.Controller;
using Message = EVOFramework.Message;
using SystemMaintenance;
using Rubik.Forms.FindDialog;
using SystemMaintenance.BIZ;
using System.Data;
using FarPoint.Win.Spread.Model;


namespace Rubik.Transaction
{
    [Screen("TRN190", "Customer Order Entry", eShowAction.Normal, eScreenType.Screen, "Customer Order Entry")]
    public partial class TRN190_CustomerOrderEntry : SystemMaintenance.Forms.CustomizeForm
    {
        #region Enum
        private enum eSaveMode
        {
            ADD, UPDATE, VIEW
        }

        private enum eUpdateValueStatus
        {
            ALL = -2,
            NONE = -1
        }

        public enum eColView
        {
            ORDER_DETAIL_NO,
            ITEM_CD,
            ITEM_CD_BTN,
            PART_NO,
            ITEM_DELIVERY_DATE,
            OLD_ITEM_DELIVERY_DATE,
            QTY,
            OLD_QTY,
            PRICE,
            AMOUNT,
            PRICE_THB,
            AMOUNT_THB
            //ITEM_DESC,
            //LOT_NO,
            //SUPP_LOT_NO,
            //ORDER_QTY,
            //LOT_SIZE,
            //ORDER_UM_CLS,
            //INV_UM_CLS,
            //ORDER_UM_RATE,
            //INV_UM_RATE,

            //LOT_CONTROL_CLS,
        }

        #endregion

        #region Variables
        private Common.eScreenMode m_screenMode = Common.eScreenMode.ADD;
        private NZString m_editOrderNo = null;
        private KeyboardSpread m_keyboardSpread = null;

        private readonly CustomerOrderController m_controller = new CustomerOrderController();
        private readonly CustomerOrderBIZ m_bizCustomer = new CustomerOrderBIZ();

        private CustomerOrderEntryUIDM m_screenModel = new CustomerOrderEntryUIDM();
        private DialogResult m_dialogResult = DialogResult.Cancel;

        // Define field of db when call manual field from datatable
        private string m_strDefaultLocation = "MAT'";
        private string DB_Field_Item_Cd = "ITEM_CD";
        private string DB_Field_Qty = "QTY";
        private string DB_Field_Price = "PRICE";
        private string DB_Field_Part_No = "PART_NO";
        private string DB_Field_Price_THB = "PRICE_THB";
        private bool skip_event_control = true;

        #endregion

        #region Constructor
        public TRN190_CustomerOrderEntry()
        {
            InitializeComponent();
        }

        public TRN190_CustomerOrderEntry(NZString OrderNo)
        {
            InitializeComponent();

            m_editOrderNo = OrderNo;
        }
        #endregion

        #region Initialize Screen
        private void InitializeScreen()
        {
            //CheckCurrentInvPeriod();

            InitializeBindingControl();
            InitializeSetKeyPress();


            InitializeLookupData();
            InitializeComboBox();
            InitialSpread();
            InitialFormat();
            InitializeDefaultValue();

            //CheckCurrentInvPeriod();


            //m_keyboardSpread = new KeyboardSpread(fpView);
            //m_keyboardSpread.RowAdding += new KeyboardSpread.RowAddingHandler(m_keyboardSpread_RowAdding);
            //m_keyboardSpread.RowAdded += new KeyboardSpread.RowAddedHandler(m_keyboardSpread_RowAdded);
            //m_keyboardSpread.RowRemoving += new KeyboardSpread.RowRemovingHandler(m_keyboardSpread_RowRemoving);
            //m_keyboardSpread.RowRemoved += new KeyboardSpread.RowRemovedHandler(m_keyboardSpread_RowRemoved);
            //m_keyboardSpread.KeyPressF5 += new KeyboardSpread.KeyPressF5Handler(m_keyboardSpread_KeyPressF5);

        }


        #region Check Inventory Period
        private void CheckCurrentInvPeriod()
        {

            try
            {
                InventoryPeriodValidator val = new InventoryPeriodValidator();
                ErrorItem err = val.CheckInventoryCurrentPeriod();
                if (err != null)
                {
                    MessageDialog.ShowInformation(this, "Out of period", err.Message.MessageDescription);
                }

            }
            catch (Exception)
            {

            }
        }
        #endregion

        private void InitializeComboBox()
        {
            cboCustomerCode.Format += Common.ComboBox_Format;
            cboType.Format += Common.ComboBox_Format;
            cboCurrency.Format += Common.ComboBox_Format;
        }
        private void InitializeLookupData()
        {
            LookupDataBIZ biz = new LookupDataBIZ();
            NZString[] CustomerType = new NZString[] {(NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.CustomerVendor),
                                                           (NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Customer)};
            LookupData CustomerLookup = biz.LoadLookupLocation(CustomerType);
            cboCustomerCode.LoadLookupData(CustomerLookup);
            cboCustomerCode.SelectedIndex = -1;

            LookupData CustOrderType = biz.LoadLookupClassType(DataDefine.CUSTOMER_ORDER_TYPE.ToNZString());
            cboType.LoadLookupData(CustOrderType);
            cboType.SelectedIndex = 0;

            LookupData currencyData = biz.LoadLookupClassType(DataDefine.CURRENCY.ToNZString());
            cboCurrency.LoadLookupData(currencyData);
            cboCurrency.SelectedIndex = -1;
        }
        private void InitialSpread()
        {
            shtCustomerOrderList.ActiveSkin = Common.ACTIVE_SKIN;

            m_keyboardSpread = new KeyboardSpread(fpCustomerOrderList);
            m_keyboardSpread.RowAdding += m_keyboardSpread_RowAdding;
            m_keyboardSpread.RowAdded += m_keyboardSpread_RowAdded;
            m_keyboardSpread.RowRemoved += m_keyboardSpread_RowRemoved;
            if (m_screenMode != Common.eScreenMode.VIEW)
                m_keyboardSpread.StartBind();


            //fpNGInfo.SubEditorOpening += CtrlUtil.SpreadDisableSubEditorOpening;
            //CtrlUtil.MappingDataFieldWithEnum(shtNGInfo, typeof(eNGInfoCol));

            //fpCustomerOrderList.LeaveCell += new LeaveCellEventHandler(fpView_LeaveCell);
            fpCustomerOrderList.SubEditorOpening += CtrlUtil.SpreadDisableSubEditorOpening;
            CtrlUtil.MappingDataFieldWithEnum(shtCustomerOrderList, typeof(eColView));

            FormatUtil.SetNumberFormat(shtCustomerOrderList.Columns[(int)eColView.ITEM_CD], FormatUtil.eNumberFormat.MasterNo);

            string[] names = Enum.GetNames(typeof(eColView));
            for (int i = 0; i < names.Length; i++)
            {
                shtCustomerOrderList.Columns[i].DataField = names[i];
                CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, true, i);
            }
            if (m_screenMode == Common.eScreenMode.ADD || m_screenMode == Common.eScreenMode.EDIT)
            {
                CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, false, (int)eColView.ITEM_CD_BTN);
                CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, false, (int)eColView.ITEM_DELIVERY_DATE);
                CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, false, (int)eColView.QTY);

                //CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, false, (int)eColView.AMOUNT);
                //CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, false, (int)eColView.AMOUNT_THB);
                //CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, false, (int)eColView.PRICE);
                //CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, false, (int)eColView.PRICE_THB);
            }
            if (m_screenMode == Common.eScreenMode.ADD)
            {
                CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, false, (int)eColView.ITEM_CD_BTN);
                CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, false, (int)eColView.ITEM_DELIVERY_DATE);
                CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, false, (int)eColView.QTY);
            }
        }
        private void InitialFormat()
        {
            // Set Control Format
            CommonLib.FormatUtil.SetDateFormat(this.dtReceiveDate);
            CommonLib.FormatUtil.SetDateFormat(this.dtPODate);
            CommonLib.FormatUtil.SetNumberFormat(this.txtQty, FormatUtil.eNumberFormat.Qty_PCS);
            CommonLib.FormatUtil.SetNumberFormat(this.txtAmount, FormatUtil.eNumberFormat.Amount);
            CommonLib.FormatUtil.SetNumberFormat(this.txtAmountTHB, FormatUtil.eNumberFormat.Amount_THB);
            CommonLib.FormatUtil.SetNumberFormat(this.txtExchangeRate, FormatUtil.eNumberFormat.ExchangeRate);

            // Set Spread Format
            FormatUtil.SetDateFormat(shtCustomerOrderList.Columns[(int)eColView.ITEM_DELIVERY_DATE]);
            FormatUtil.SetNumberFormat(shtCustomerOrderList.Columns[(int)eColView.QTY], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtCustomerOrderList.Columns[(int)eColView.PRICE], FormatUtil.eNumberFormat.UnitPrice);
            FormatUtil.SetNumberFormat(shtCustomerOrderList.Columns[(int)eColView.PRICE_THB], FormatUtil.eNumberFormat.UnitPrice);
            FormatUtil.SetNumberFormat(shtCustomerOrderList.Columns[(int)eColView.AMOUNT], FormatUtil.eNumberFormat.Amount);
            FormatUtil.SetNumberFormat(shtCustomerOrderList.Columns[(int)eColView.AMOUNT_THB], FormatUtil.eNumberFormat.Amount_THB);

            FormatUtil.SetNumberFormat(this.shtCustomerOrderList.Columns[(int)eColView.ITEM_CD], FormatUtil.eNumberFormat.MasterNo);
        }
        private void InitializeBindingControl()
        {
            dmcCustomerOrderList.AddRangeControl(
                dtReceiveDate,
                lblOrderNo,
                cboCustomerCode,
                cboType,
                cboCurrency,
                txtPONo,
                dtPODate,
                txtExchangeRate,
                txtRemark,
                txtQty,
                txtAmount,
                txtAmountTHB
                );
        }
        private void InitializeSetKeyPress()
        {
            dtReceiveDate.KeyPress += CtrlUtil.SetNextControl;
            cboCustomerCode.KeyPress += CtrlUtil.SetNextControl;
            cboType.KeyPress += CtrlUtil.SetNextControl;
            cboCurrency.KeyPress += CtrlUtil.SetNextControl;
            dtPODate.KeyPress += CtrlUtil.SetNextControl;
            txtPONo.KeyPress += CtrlUtil.SetNextControl;
            txtExchangeRate.KeyPress += CtrlUtil.SetNextControl;
            txtRemark.KeyPress += CtrlUtil.SetNextControl;
        }

        private void InitializeDefaultValue()
        {
            SysConfigBIZ sysBiz = new SysConfigBIZ();
            SysConfigDTO default_StoreLoc = sysBiz.LoadByPK(DataDefine.eSYSTEM_CONFIG.TRN020.SYS_GROUP_ID, (NZString)DataDefine.eSYSTEM_CONFIG.TRN020.SYS_KEY.STORE_LOC.ToString());

            m_strDefaultLocation = default_StoreLoc.CHAR_DATA.NVL("MAT'");
        }
        #endregion

        #region Keyboard Spread
        void m_keyboardSpread_RowAdded(object sender, int rowIndex)
        {
            // Unlock cells

            CtrlUtil.SpreadSetCellLocked(shtCustomerOrderList, true, rowIndex, (int)eColView.ITEM_CD);
            CtrlUtil.SpreadSetCellLocked(shtCustomerOrderList, false, rowIndex, (int)eColView.ITEM_CD_BTN);
            CtrlUtil.SpreadSetCellLocked(shtCustomerOrderList, false, rowIndex, (int)eColView.ITEM_DELIVERY_DATE);
            CtrlUtil.SpreadSetCellLocked(shtCustomerOrderList, false, rowIndex, (int)eColView.QTY);
            CtrlUtil.SpreadSetCellLocked(shtCustomerOrderList, true, rowIndex, (int)eColView.PRICE);
            CtrlUtil.SpreadSetCellLocked(shtCustomerOrderList, true, rowIndex, (int)eColView.AMOUNT);
            CtrlUtil.SpreadSetCellLocked(shtCustomerOrderList, true, rowIndex, (int)eColView.PRICE_THB);
            CtrlUtil.SpreadSetCellLocked(shtCustomerOrderList, true, rowIndex, (int)eColView.AMOUNT_THB);
        }

        void m_keyboardSpread_RowAdding(object sender, EventRowAdding e)
        {
            if (m_bRowHasModified)
            { // ถ้า Row กำลังแก้ไขอยู่
                if (!ValidateRowSpread(shtCustomerOrderList.ActiveRowIndex, false))
                {
                    e.Cancel = true;
                    return;
                }
            }
            else
            {
                // ถ้าไม่มีการแก้ไข Row  แต่ก่อนที่จะเพิ่มแถวใหม่ จะต้อง Validate แถวล่าสุด (ล่างสุด) ก่อน
                if (shtCustomerOrderList.RowCount > 0 && shtCustomerOrderList.ActiveRowIndex >= 0)
                {
                    if (!ValidateRowSpread(shtCustomerOrderList.RowCount - 1, true))
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
        }

        void m_keyboardSpread_RowRemoving(object sender, EventRowRemoving e)
        {
            MessageDialogResult dr = MessageDialog.ShowConfirmation(this, Message.LoadMessage(Messages.eConfirm.CFM9002.ToString()), MessageDialogButtons.YesNo);
            if (dr == MessageDialogResult.No)
            {
                e.Cancel = true;
            }
        }

        void m_keyboardSpread_RowRemoved(object sender)
        {
            m_bRowHasModified = false;
        }

        void m_keyboardSpread_KeyPressF5(object sender, int rowIndex, int colIndex)
        {
            //throw new NotImplementedException();
        }
        #endregion

        #region Screen Mode
        private void SetScreenMode(Common.eScreenMode mode)
        {
            switch (mode)
            {
                case Common.eScreenMode.VIEW:
                    CtrlUtil.EnabledControl(false, dtReceiveDate, cboCustomerCode, cboType, cboCurrency);
                    CtrlUtil.EnabledControl(false, txtPONo, dtPODate, txtExchangeRate, txtRemark, lblOrderNo);
                    CtrlUtil.EnabledControl(false, fpCustomerOrderList);
                    CtrlUtil.EnabledControl(false, txtQty, txtAmount, txtAmountTHB);

                    tsbSaveAndNew.Enabled = false;
                    tsbSaveAndClose.Enabled = false;
                    shtCustomerOrderList.OperationMode = OperationMode.ReadOnly;

                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, true, (int)eColView.ITEM_CD);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, true, (int)eColView.ITEM_CD_BTN);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, true, (int)eColView.PART_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, true, (int)eColView.ITEM_DELIVERY_DATE);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, true, (int)eColView.QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, true, (int)eColView.PRICE);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, true, (int)eColView.AMOUNT);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, true, (int)eColView.PRICE_THB);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, true, (int)eColView.AMOUNT_THB);
                    fpCustomerOrderList.ContextMenuStrip = null;
                    break;
                case Common.eScreenMode.ADD:
                    shtCustomerOrderList.OperationMode = OperationMode.Normal;
                    CtrlUtil.EnabledControl(true, dtReceiveDate, cboCustomerCode, cboType, cboCurrency);
                    CtrlUtil.EnabledControl(true, txtPONo, dtPODate, txtExchangeRate, txtRemark, lblOrderNo);
                    CtrlUtil.EnabledControl(true, fpCustomerOrderList);
                    CtrlUtil.EnabledControl(false, txtQty, txtAmount, txtAmountTHB);

                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, true, (int)eColView.ITEM_CD);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, false, (int)eColView.ITEM_CD_BTN);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, true, (int)eColView.PART_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, false, (int)eColView.ITEM_DELIVERY_DATE);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, false, (int)eColView.QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, true, (int)eColView.PRICE);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, true, (int)eColView.AMOUNT);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, true, (int)eColView.PRICE_THB);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, true, (int)eColView.AMOUNT_THB);

                    txtExchangeRate.Text = DataDefine.DEFAULT_EXCHANGE_RATE;
                    break;
                case Common.eScreenMode.EDIT:
                    shtCustomerOrderList.OperationMode = OperationMode.Normal;
                    CtrlUtil.EnabledControl(true, dtReceiveDate, cboType, txtPONo, dtPODate, txtRemark);
                    CtrlUtil.EnabledControl(false, lblOrderNo, cboCustomerCode, cboCurrency, txtExchangeRate);
                    CtrlUtil.EnabledControl(true, fpCustomerOrderList);
                    CtrlUtil.EnabledControl(false, txtQty, txtAmount, txtAmountTHB);

                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, true, (int)eColView.ITEM_CD);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, false, (int)eColView.ITEM_CD_BTN);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, true, (int)eColView.PART_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, false, (int)eColView.ITEM_DELIVERY_DATE);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, false, (int)eColView.QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, true, (int)eColView.PRICE);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, true, (int)eColView.AMOUNT);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, true, (int)eColView.PRICE_THB);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, true, (int)eColView.AMOUNT_THB);

                    break;
            }
            m_screenMode = mode;
        }

        private void ClearAll()
        {
            skip_event_control = true;
            CtrlUtil.ClearControlData(dtReceiveDate, cboCustomerCode, cboType, cboCurrency, txtPONo, dtPODate
                , txtExchangeRate, txtRemark, txtQty, txtAmount, txtAmountTHB);
            lblOrderNo.Text = string.Empty;
            txtExchangeRate.Text = DataDefine.DEFAULT_EXCHANGE_RATE;

            shtCustomerOrderList.RowCount = 0;
            if (m_screenModel.DATA_VIEW != null)
                m_screenModel.DATA_VIEW.Rows.Clear();
            skip_event_control = false;
        }

        private void ClearAllExceptDefault()
        {
            skip_event_control = true;
            CtrlUtil.ClearControlData(cboCustomerCode, cboType, cboCurrency, txtPONo, dtPODate
                , txtExchangeRate, txtRemark, txtQty, txtAmount, txtAmountTHB);
            lblOrderNo.Text = string.Empty;
            txtExchangeRate.Text = DataDefine.DEFAULT_EXCHANGE_RATE;
            dtPODate.Value = DateTime.Today;
            SysConfigBIZ sysBiz = new SysConfigBIZ();
            SysConfigDTO argScreenInfo = new SysConfigDTO();
            argScreenInfo.SYS_GROUP_ID = DataDefine.eSYSTEM_CONFIG.TRN190.SYS_GROUP_ID;
            argScreenInfo.SYS_KEY = (NZString)DataDefine.eSYSTEM_CONFIG.TRN190.SYS_KEY.DEFAULT_DATE.ToString();
            dtReceiveDate.Value = sysBiz.GetDefaultDateForScreen(argScreenInfo);
            shtCustomerOrderList.RowCount = 0;
            if (m_screenModel.DATA_VIEW != null)
                m_screenModel.DATA_VIEW.Rows.Clear();

            CtrlUtil.FocusControl(cboCustomerCode);
            skip_event_control = false;
        }

        #endregion

        #region Private method
        private void RemoveRowUnused(SheetView sheet)
        {
            int lastRowNonEmpty = shtCustomerOrderList.GetLastNonEmptyRow(NonEmptyItemFlag.Data);
            if (lastRowNonEmpty != shtCustomerOrderList.RowCount - 1)
            {
                shtCustomerOrderList.RemoveRows(shtCustomerOrderList.RowCount - 1, 1);
            }
        }

        private bool LoadItemIntoRow(int row, NZString ITEM_CD)
        {
            ItemValidator itemValidator = new ItemValidator();

            if (ITEM_CD != null)
            {
                BusinessException error = itemValidator.CheckItemNotExist(ITEM_CD);
                if (error != null)
                {
                    shtCustomerOrderList.Cells[row, (int)eColView.ITEM_CD].Value = null;
                    shtCustomerOrderList.Cells[row, (int)eColView.PART_NO].Value = null;
                    shtCustomerOrderList.Cells[row, (int)eColView.ITEM_DELIVERY_DATE].Value = null;
                    shtCustomerOrderList.Cells[row, (int)eColView.QTY].Value = null;
                    shtCustomerOrderList.Cells[row, (int)eColView.OLD_QTY].Value = null;
                    shtCustomerOrderList.Cells[row, (int)eColView.PRICE].Value = null;
                    shtCustomerOrderList.Cells[row, (int)eColView.AMOUNT].Value = null;
                    shtCustomerOrderList.Cells[row, (int)eColView.PRICE_THB].Value = null;
                    shtCustomerOrderList.Cells[row, (int)eColView.AMOUNT_THB].Value = null;
                    return false;
                }

                // Load Header
                dmcCustomerOrderList.SaveData(m_screenModel);
                SalesUnitPriceBIZ bizPrice = new SalesUnitPriceBIZ();
                // Load Price by Currency combobox
                object temp_dt = shtCustomerOrderList.GetValue(row, (int)eColView.ITEM_DELIVERY_DATE);
                object temp_old_dt = shtCustomerOrderList.GetValue(row, (int)eColView.OLD_ITEM_DELIVERY_DATE);
                DateTime DeliveryDate = new DateTime();
                DateTime Old_DeliveryDate = new DateTime();

                ItemBIZ itemBIZ = new ItemBIZ();
                ItemDTO itemDTO = itemBIZ.LoadItem(ITEM_CD);
                shtCustomerOrderList.Cells[row, (int)eColView.ITEM_CD].Value = itemDTO.ITEM_CD.Value;
                shtCustomerOrderList.Cells[row, (int)eColView.PART_NO].Value = itemDTO.SHORT_NAME.Value;

                bool CheckConvertDeliveryDate = (temp_dt == null) ? false : DateTime.TryParse(temp_dt.ToString(), out DeliveryDate);
                bool CheckConvertOldDeliveryDate = (temp_old_dt == null) ? false : DateTime.TryParse(temp_old_dt.ToString(), out Old_DeliveryDate);
                //if ((CheckConvertDeliveryDate && !CheckConvertOldDeliveryDate)
                //    || (CheckConvertDeliveryDate && CheckConvertOldDeliveryDate && DeliveryDate.Date != Old_DeliveryDate.Date))
                if (CheckConvertDeliveryDate)
                {
                    SalesUnitPriceDTO dtoPrice = bizPrice.getSalesUnitPriceByEffectiveDate(ITEM_CD, m_screenModel.CURRENCY, DeliveryDate.Date.ToNZDateTime());
                    if (dtoPrice == null || dtoPrice.PRICE.IsNull)
                    {
                        shtCustomerOrderList.Cells[row, (int)eColView.PRICE].Value = 0;
                        shtCustomerOrderList.Cells[row, (int)eColView.PRICE_THB].Value = 0;
                        shtCustomerOrderList.Cells[row, (int)eColView.AMOUNT].Value = 0;
                        shtCustomerOrderList.Cells[row, (int)eColView.AMOUNT_THB].Value = 0;
                    }
                    else
                    {
                        shtCustomerOrderList.Cells[row, (int)eColView.PRICE].Value = dtoPrice.PRICE.StrongValue;
                        shtCustomerOrderList.Cells[row, (int)eColView.AMOUNT].Value = dtoPrice.PRICE.StrongValue * Convert.ToDecimal(shtCustomerOrderList.GetValue(row, (int)eColView.QTY));
                        shtCustomerOrderList.Cells[row, (int)eColView.PRICE_THB].Value = dtoPrice.PRICE.StrongValue * decimal.Parse(txtExchangeRate.Text);
                        shtCustomerOrderList.Cells[row, (int)eColView.AMOUNT_THB].Value = dtoPrice.PRICE.StrongValue * Convert.ToDecimal(shtCustomerOrderList.GetValue(row, (int)eColView.QTY)) * decimal.Parse(txtExchangeRate.Text);
                    }
                }
                //else if (CheckConvertDeliveryDate && CheckConvertOldDeliveryDate && DeliveryDate.Date == Old_DeliveryDate.Date)
                //{
                //    //Nothing to do.
                //}
                else
                {
                    shtCustomerOrderList.Cells[row, (int)eColView.PRICE].Value = 0;
                    shtCustomerOrderList.Cells[row, (int)eColView.PRICE_THB].Value = 0;
                    shtCustomerOrderList.Cells[row, (int)eColView.AMOUNT].Value = 0;
                    shtCustomerOrderList.Cells[row, (int)eColView.AMOUNT_THB].Value = 0;
                }

            }

            return true;
        }

        private void LoadDataTableIntoSpread(DataTable dtView)
        {
            shtCustomerOrderList.RowCount = 0;
            //if (cboConsumptionCls.SelectedValue == null)
            //{
            //    return;
            //}
            //string ConsumptionCls = cboConsumptionCls.SelectedValue.ToString();
            //DataDefine.eCONSUMPTION_CLS eConsumptionCls = DataDefine.ConvertValue2Enum<DataDefine.eCONSUMPTION_CLS>(ConsumptionCls);
            //if (eConsumptionCls == DataDefine.eCONSUMPTION_CLS.No)
            //{
            //    return;
            //}
            shtCustomerOrderList.DataSource = dtView;

            // update locked cell by condition on each row.
            for (int i = 0; i < shtCustomerOrderList.RowCount; i++)
            {
                DataRowView drv = CtrlUtil.SpreadGetDataRowFromRowIndex(shtCustomerOrderList, i);
                if (drv == null)
                    continue;

                bool bEditMode = m_screenMode == Common.eScreenMode.EDIT || m_screenMode == Common.eScreenMode.VIEW;
                //CtrlUtil.SpreadSetCellLocked(shtCustomerOrderList, bEditMode, i, (int)eColView.ITEM_CD);
                //CtrlUtil.SpreadSetCellLocked(shtCustomerOrderList, false, i, (int)eColView.ITEM_CD_BTN);
                //CtrlUtil.SpreadSetCellLocked(shtCustomerOrderList, false, i, (int)eColView.PART_NO);
                //CtrlUtil.SpreadSetCellLocked(shtCustomerOrderList, false, i, (int)eColView.ITEM_DELIITEM_DELIVERY_DATE);
                //CtrlUtil.SpreadSetCellLocked(shtCustomerOrderList, false, i, (int)eColView.QTY);
                //CtrlUtil.SpreadSetCellLocked(shtCustomerOrderList, bEditMode, i, (int)eColView.AMOUNT);
                //CtrlUtil.SpreadSetCellLocked(shtCustomerOrderList, bEditMode, i, (int)eColView.AMOUNT_THB);
                //CtrlUtil.SpreadSetCellLocked(shtCustomerOrderList, bEditMode, i, (int)eColView.AMOUNT_THB);

                //if (eConsumptionCls == DataDefine.eCONSUMPTION_CLS.Auto)
                //{
                //    CtrlUtil.SpreadSetCellLocked(shtView, true, i, (int)eColView.ITEM_CD);
                //    CtrlUtil.SpreadSetCellLocked(shtView, true, i, (int)eColView.ITEM_CD_BTN);
                //    CtrlUtil.SpreadSetCellLocked(shtView, true, i, (int)eColView.LOT_NO);
                //    CtrlUtil.SpreadSetCellLocked(shtView, true, i, (int)eColView.LOT_BTN);
                //    CtrlUtil.SpreadSetCellLocked(shtView, true, i, (int)eColView.LOC_BTN);
                //    CtrlUtil.SpreadSetCellLocked(shtView, true, i, (int)eColView.CONSUMPTION_QTY);
                //}
                //else
                //{
                //    CtrlUtil.SpreadSetCellLocked(shtView, false, i, (int)eColView.CONSUMPTION_QTY);
                //    if (!bEditMode && m_screenMode != eScreenMode.VIEW)
                //    {
                //        //if (Equals(drv[WorkResultEntryViewDTO.eColumns.LOT_CONTROL_CLS.ToString()], DataDefine.Convert2ClassCode(DataDefine.eLOT_CONTROL_CLS.No)))
                //        //{
                //        //    // Lot class == "NO"
                //        //    CtrlUtil.SpreadSetCellLocked(shtView, true, i, (int)eColView.LOT_NO);
                //        //    CtrlUtil.SpreadSetCellLocked(shtView, true, i, (int)eColView.LOT_BTN);
                //        //    CtrlUtil.SpreadSetCellLocked(shtView, false, i, (int)eColView.LOC_BTN);
                //        //}
                //        //else
                //        //{
                //        //    CtrlUtil.SpreadSetCellLocked(shtView, false, i, (int)eColView.LOT_NO);
                //        //    CtrlUtil.SpreadSetCellLocked(shtView, false, i, (int)eColView.LOT_BTN);
                //        //    CtrlUtil.SpreadSetCellLocked(shtView, false, i, (int)eColView.LOC_BTN);
                //        //    NZString itemCode = new NZString(null, shtView.Cells[i, (int)eColView.ITEM_CD].Value);

                //        //    // Lookup Lot No
                //        //    //LookupData lookupLotNo = m_bizLookupData.LoadLookupLotNo(itemCode, new NZString(null, cboOrderLoc.SelectedValue), dtWorkResultDate.Value.Value.ToString("yyyyMM").ToNZString());
                //        //    //shtView.Cells[i, (int)eColView.LOT_NO].CellType = CtrlUtil.CreateComboBoxCellType(lookupLotNo, false);
                //        //}
                //    }
                //}

            }

        }

        private void UpdateTotalValue(bool IsUpdateSpreadValue, int RowIndex)
        {

            //dmcCustomerOrderList.SaveData(m_screenModel);
            if (shtCustomerOrderList.Rows.Count > 0)
            {
                decimal temp_result_QTY = 0;
                decimal temp_result_AMOUNT = 0;
                decimal temp_result_AMOUNT_THB = 0;
                for (int i = 0; i < shtCustomerOrderList.Rows.Count; i++)
                {
                    // If some row no value of "QTY" and "Price" skip for cal total 
                    if (shtCustomerOrderList.GetValue(i, (int)eColView.QTY) == null
                        || shtCustomerOrderList.GetValue(i, (int)eColView.QTY).ToString() == ""
                        || shtCustomerOrderList.GetValue(i, (int)eColView.PRICE) == null
                        || shtCustomerOrderList.GetValue(i, (int)eColView.PRICE).ToString() == "") continue;
                    // Cal Amount
                    if (IsUpdateSpreadValue && (RowIndex.Equals(i) || RowIndex.Equals((int)eUpdateValueStatus.ALL)))
                    {
                        shtCustomerOrderList.Cells[i, (int)eColView.AMOUNT].Value = decimal.Parse(shtCustomerOrderList.Cells[i, (int)eColView.QTY].Value.ToString()) * decimal.Parse(shtCustomerOrderList.Cells[i, (int)eColView.PRICE].Value.ToString());
                        shtCustomerOrderList.Cells[i, (int)eColView.AMOUNT_THB].Value = decimal.Parse(shtCustomerOrderList.Cells[i, (int)eColView.QTY].Value.ToString()) * decimal.Parse(shtCustomerOrderList.Cells[i, (int)eColView.PRICE].Value.ToString()) * this.txtExchangeRate.Decimal;
                    }
                    // Set Total
                    temp_result_QTY += decimal.Parse(shtCustomerOrderList.Cells[i, (int)eColView.QTY].Value.ToString());
                    temp_result_AMOUNT += decimal.Parse(shtCustomerOrderList.Cells[i, (int)eColView.AMOUNT].Value.ToString());
                    temp_result_AMOUNT_THB += decimal.Parse(shtCustomerOrderList.Cells[i, (int)eColView.AMOUNT_THB].Value.ToString());
                }
                txtQty.Decimal = temp_result_QTY;
                txtAmount.Decimal = temp_result_AMOUNT;
                txtAmountTHB.Decimal = temp_result_AMOUNT_THB;
            }
        }

        private bool ValidateData()
        {
            if (!dtReceiveDate.Value.HasValue)
            {
                MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0105.ToString(), new object[] { "Receive Date" }));
                return false;
            }
            if (cboCustomerCode.SelectedValue == null)
            {
                MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0105.ToString(), new object[] { "Customer Code" }));
                return false;
            }
            if (cboType.SelectedValue == null)
            {
                MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0105.ToString(), new object[] { "Order Type" }));
                return false;
            }
            if (cboCurrency.SelectedValue == null)
            {
                MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0105.ToString(), new object[] { "Currency" }));
                return false;
            }
            if (txtExchangeRate.Text == "")
            {
                MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0105.ToString(), new object[] { "Exchange Rate" }));
                return false;
            }
            if (shtCustomerOrderList.RowCount <= 0)
            {
                MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0190.ToString()));
                return false;
            }

            bool ErrDeliveryDate = false;
            bool ErrQty = false;


            for (int i = 0; i < shtCustomerOrderList.RowCount; i++)
            {
                DateTime dtTemp;

                if (!ErrDeliveryDate
                    && (shtCustomerOrderList.GetValue(i, (int)eColView.ITEM_DELIVERY_DATE) == null
                        || !DateTime.TryParse(shtCustomerOrderList.GetValue(i, (int)eColView.ITEM_DELIVERY_DATE).ToString(), out dtTemp)))
                {
                    ErrDeliveryDate = true;
                }

                
                if (!ErrQty && cboType.SelectedValue.ToString() == "FORECAST")
                {
                    if ((shtCustomerOrderList.GetValue(i, (int)eColView.QTY) == null)
                           || Convert.ToDecimal(shtCustomerOrderList.GetValue(i, (int)eColView.QTY)) < 0)
                    {
                        ErrQty = true;
                    }
                }
                else if (!ErrQty
                        &&((shtCustomerOrderList.GetValue(i, (int)eColView.QTY) == null) || Convert.ToDecimal(shtCustomerOrderList.GetValue(i, (int)eColView.QTY)) <= 0))
                {
                    ErrQty = true;
                }
                
                //if (!ErrQty
                //    && (shtCustomerOrderList.GetValue(i, (int)eColView.QTY) == null
                //        || Convert.ToDecimal(shtCustomerOrderList.GetValue(i, (int)eColView.QTY)) <= 0))
                //{
                //    ErrQty = true;
                //}

                if (ErrDeliveryDate || ErrQty) shtCustomerOrderList.Rows[i].BackColor = Color.Red;
                else
                {
                    if (i % 2 > 0) shtCustomerOrderList.Rows[i].BackColor = Color.FromArgb(236, 247, 243);
                    else shtCustomerOrderList.Rows[i].BackColor = Color.White;
                }
            }
            if (ErrDeliveryDate || ErrQty)
            {
                //if (ErrDeliveryDate && ErrQty)
                //    MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0105.ToString(),new object[]{"Delivery Date and QTY"}));
                //else if (ErrDeliveryDate)
                //    MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0105.ToString(),new object[]{"Delivery Date"}));
                //else MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0105.ToString(),new object[]{"QTY"}));

                MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0105.ToString(), new object[] { "Delivery Date and QTY" }));
                return false;
            }
            // ตรวจสอบ DeliveryDate ที่เกิน Period
            ErrDeliveryDate = false;
            for (int i = 0; i < shtCustomerOrderList.RowCount; i++)
            {
                DateTime DeliveryDate = new DateTime();
                DateTime Old_DeliveryDate = new DateTime();

                object temp_dt = shtCustomerOrderList.GetValue(i, (int)eColView.ITEM_DELIVERY_DATE);
                object temp_old_dt = shtCustomerOrderList.GetValue(i, (int)eColView.OLD_ITEM_DELIVERY_DATE);

                bool CheckConvertDeliveryDate = (temp_dt == null) ? false : DateTime.TryParse(temp_dt.ToString(), out DeliveryDate);
                bool CheckConvertOldDeliveryDate = (temp_old_dt == null) ? false : DateTime.TryParse(temp_old_dt.ToString(), out Old_DeliveryDate);
                bool ErrChk = false;
                if (CheckConvertDeliveryDate)
                {
                    
                    SysConfigBIZ sysBiz = new SysConfigBIZ();
                    SysConfigDTO argScreenInfo = new SysConfigDTO();
                    argScreenInfo.SYS_GROUP_ID = DataDefine.eSYSTEM_CONFIG.TRN190.SYS_GROUP_ID;
                    argScreenInfo.SYS_KEY = (NZString)DataDefine.eSYSTEM_CONFIG.TRN190.SYS_KEY.BEFORE_DATE.ToString();
                    DateTime dtBefore = sysBiz.GetDefaultDateForScreen_No_Fix(argScreenInfo);
                    argScreenInfo.SYS_GROUP_ID = DataDefine.eSYSTEM_CONFIG.TRN190.SYS_GROUP_ID;
                    argScreenInfo.SYS_KEY = (NZString)DataDefine.eSYSTEM_CONFIG.TRN190.SYS_KEY.AFTER_DATE.ToString();
                    DateTime dtAfter = sysBiz.GetDefaultDateForScreen_No_Fix(argScreenInfo);
                    if (DeliveryDate > dtAfter || DeliveryDate < dtBefore)
                    {
                        //if (CheckConvertOldDeliveryDate)
                        //{
                        //    shtCustomerOrderList.Cells[i, (int)eColView.ITEM_DELIVERY_DATE].Value = Old_DeliveryDate;
                        //}
                        ErrChk = true;
                    }
                }

                if (ErrChk)
                {
                    shtCustomerOrderList.Rows[i].BackColor = Color.Red;
                    ErrDeliveryDate = true;
                }
                else
                {
                    if (i % 2 > 0) shtCustomerOrderList.Rows[i].BackColor = Color.FromArgb(236, 247, 243);
                    else shtCustomerOrderList.Rows[i].BackColor = Color.White;
                }

            }
            if (ErrDeliveryDate)
            {
                MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0222.ToString()));
                return false;
            }
            return true;
        }

        #endregion

        #region Overriden method
        public override void OnSaveAndNew()
        {
            stcHead.Focus();
            fpCustomerOrderList.StopCellEditing();
            if (m_bRowHasModified)
            { // ถ้า Row กำลังแก้ไขอยู่
                if (!ValidateRowSpread(shtCustomerOrderList.ActiveRowIndex, false))
                {
                    return;
                }
            }

            // ต้องเรียกก่อน Save เสมอ  เพื่อ Commit ข้อมูลการแก้ไขล่าสุดบน Grid
            // ใช้ได้เฉพาะกับ Sheet ที่ผูก DataSource
            CtrlUtil.SpreadSheetRowEndEdit(shtCustomerOrderList, shtCustomerOrderList.ActiveRowIndex);

            RemoveRowUnused(shtCustomerOrderList);

            try
            {
                if (!ValidateData()) return;
                CustomerOrderViewDTO itemValidator = new CustomerOrderViewDTO();
                int row = shtCustomerOrderList.Rows.Count;
                //for (int i = 0; i < row; i++)
                //{
                //    NZString ItemCD = new NZString(null, shtCustomerOrderList.Cells[i, (int)eColView.ITEM_CD].Value);
                //    BusinessException err = itemValidator.CheckItemNotExist(ItemCD);
                //    if (err != null)
                //        ValidateException.ThrowErrorItem(err.Error);
                //}

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, Message.LoadMessage(Messages.eConfirm.CFM9001.ToString()));
                if (dr == MessageDialogResult.Cancel)
                {
                    return;
                }
                if (dr == MessageDialogResult.Yes)
                {

                    //== Prepare data.
                    CustomerOrderEntryUIDM newModel = dmcCustomerOrderList.SaveData(new CustomerOrderEntryUIDM());
                    newModel.DATA_VIEW = (DataTable)shtCustomerOrderList.DataSource;

                    m_controller.Save(newModel, m_screenMode);

                    MessageDialog.ShowInformation(this, null, Message.LoadMessage(Messages.eInformation.INF9003.ToString()).MessageDescription);

                    //== return to Add new data screen mode.
                    SetScreenMode(Common.eScreenMode.ADD);
                    ClearAllExceptDefault();

                    // Gen Order Number for Add New.
                    //RunningNumberBIZ runningNumberBIZ = new RunningNumberBIZ();
                    //NZString runningNo = runningNumberBIZ.GetCompleteRunningNo((NZString)"CUSTOMER_ORDER_NO", (NZString)"TB_CUSTOMER_ORDERH_TR");
                    //lblOrderNo.Text = runningNo.Value.ToString();

                    m_bRowHasModified = false;
                }

            }
            catch (ValidateException err)
            {
                MessageDialog.ShowBusiness(this, err.ErrorResults[0].Message);
                err.ErrorResults[0].FocusOnControl();
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                err.Error.FocusOnControl();
            }
            catch (Exception err)
            {
                // ถ้าเป็น error ที่มาจากการหา FIFO Process
                if (err.Message.IndexOf('|') != -1)
                {
                    string[] msgs = err.Message.Split('|');
                    MessageDialog.ShowBusiness(this, Message.LoadMessage(msgs[0], new[] { msgs[1] }));
                }
                else
                    MessageDialog.ShowBusiness(this, null, err.Message);
                Console.WriteLine(err.StackTrace);
            }
        }

        public override void OnSaveAndClose()
        {
            stcHead.Focus();
            fpCustomerOrderList.StopCellEditing();
            if (m_bRowHasModified)
            { // ถ้า Row กำลังแก้ไขอยู่
                if (!ValidateRowSpread(shtCustomerOrderList.ActiveRowIndex, false))
                {
                    return;
                }
            }

            // ต้องเรียกก่อน Save เสมอ  เพื่อ Commit ข้อมูลการแก้ไขล่าสุดบน Grid
            // ใช้ได้เฉพาะกับ Sheet ที่ผูก DataSource
            CtrlUtil.SpreadSheetRowEndEdit(shtCustomerOrderList, shtCustomerOrderList.ActiveRowIndex);

            RemoveRowUnused(shtCustomerOrderList);

            try
            {
                if (!ValidateData()) return;
                CustomerOrderViewDTO itemValidator = new CustomerOrderViewDTO();
                int row = shtCustomerOrderList.Rows.Count;
                //for (int i = 0; i < row; i++)
                //{
                //    NZString ItemCD = new NZString(null, shtCustomerOrderList.Cells[i, (int)eColView.ITEM_CD].Value);
                //    BusinessException err = itemValidator.CheckItemNotExist(ItemCD);
                //    if (err != null)
                //        ValidateException.ThrowErrorItem(err.Error);
                //}

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, Message.LoadMessage(Messages.eConfirm.CFM9001.ToString()));
                if (dr == MessageDialogResult.Cancel)
                {
                    return;
                }
                if (dr == MessageDialogResult.Yes)
                {

                    //== Prepare data.
                    CustomerOrderEntryUIDM newModel = dmcCustomerOrderList.SaveData(new CustomerOrderEntryUIDM());
                    newModel.DATA_VIEW = (DataTable)shtCustomerOrderList.DataSource;

                    m_controller.Save(newModel, m_screenMode);

                    MessageDialog.ShowInformation(this, null, Message.LoadMessage(Messages.eInformation.INF9003.ToString()).MessageDescription);

                    //== Exit form.
                    m_dialogResult = DialogResult.OK;
                    this.Close();
                }

            }
            catch (ValidateException err)
            {
                MessageDialog.ShowBusiness(this, err.ErrorResults[0].Message);
                err.ErrorResults[0].FocusOnControl();
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                err.Error.FocusOnControl();
            }
            catch (Exception err)
            {
                // ถ้าเป็น error ที่มาจากการหา FIFO Process
                if (err.Message.IndexOf('|') != -1)
                {
                    string[] msgs = err.Message.Split('|');
                    MessageDialog.ShowBusiness(this, Message.LoadMessage(msgs[0], new[] { msgs[1] }));
                }
                else
                    MessageDialog.ShowBusiness(this, null, err.Message);
                Console.WriteLine(err.StackTrace);
            }
        }
        #endregion

        #region Form Event
        private void TRN190_Load(object sender, EventArgs e)
        {
            InitializeScreen();


            if (m_editOrderNo == null)
            {
                skip_event_control = false;
                SetScreenMode(Common.eScreenMode.ADD);
                ClearAll();

                m_screenModel = m_controller.CreateUIDMForAddMode();

                dmcCustomerOrderList.LoadData(m_screenModel);
                txtExchangeRate.Text = DataDefine.DEFAULT_EXCHANGE_RATE;
                dtPODate.Value = DateTime.Today;
                SysConfigBIZ sysBiz = new SysConfigBIZ();
                SysConfigDTO argScreenInfo = new SysConfigDTO();
                argScreenInfo.SYS_GROUP_ID = DataDefine.eSYSTEM_CONFIG.TRN190.SYS_GROUP_ID;
                argScreenInfo.SYS_KEY = (NZString)DataDefine.eSYSTEM_CONFIG.TRN190.SYS_KEY.DEFAULT_DATE.ToString();
                dtReceiveDate.Value = sysBiz.GetDefaultDateForScreen(argScreenInfo);

                shtCustomerOrderList.RowCount = 0;
                shtCustomerOrderList.DataSource = m_screenModel.DATA_VIEW;

                // Gen Order Number for Add mode.
                //RunningNumberBIZ runningNumberBIZ = new RunningNumberBIZ();
                //NZString runningNo = runningNumberBIZ.GetCompleteRunningNo((NZString)"CUSTOMER_ORDER_NO", (NZString)"TB_CUSTOMER_ORDERH_TR");
                //lblOrderNo.Text = runningNo.Value.ToString();
            }
            else
            {
                skip_event_control = true;
                CustomerOrderBIZ bizCustomerOrder = new CustomerOrderBIZ();
                SetScreenMode(Common.eScreenMode.EDIT);
                ClearAll();

                m_screenModel = m_controller.LoadData(m_editOrderNo);
                dmcCustomerOrderList.LoadData(m_screenModel);

                for (int i = 0; i < m_screenModel.DATA_VIEW.Rows.Count; i++)
                {
                    ItemBIZ itemBIZ = new ItemBIZ();
                    ItemDTO itemDTO = itemBIZ.LoadItem(((String)m_screenModel.DATA_VIEW.Rows[i][DB_Field_Item_Cd]).ToNZString());
                    m_screenModel.DATA_VIEW.Rows[i][DB_Field_Part_No] = itemDTO.SHORT_NAME.Value;
                    m_screenModel.DATA_VIEW.Rows[i][DB_Field_Price_THB] = ((Decimal)m_screenModel.DATA_VIEW.Rows[i][DB_Field_Price]) * decimal.Parse(txtExchangeRate.Text);
                }

                List<CustomerOrderViewDTO> dtos = DTOUtility.ConvertDataTableToList<CustomerOrderViewDTO>(m_screenModel.DATA_VIEW);
                //shtCustomerOrderList.RowCount = 0;
                //shtCustomerOrderList.DataSource = null;
                shtCustomerOrderList.DataSource = m_screenModel.DATA_VIEW;

                //CustomerOrderEntryUIDM uidmCustomer = new CustomerOrderEntryUIDM();


                if (dtos.Count > 0)
                {
                    // set price value
                    UpdateTotalValue(false, (int)eUpdateValueStatus.NONE);
                }
                else
                {
                    SetScreenMode(Common.eScreenMode.VIEW);
                }
                skip_event_control = false;
            }

            CheckCurrentInvPeriod();
        }

        private void TRN190_Shown(object sender, EventArgs e)
        {
            if (m_screenMode == Common.eScreenMode.ADD)
            {
                CtrlUtil.FocusControl(dtReceiveDate);
            }
            else
            {
                CtrlUtil.FocusControl(fpCustomerOrderList);
            }
        }

        private void TRN190_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cboCustomerCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (skip_event_control) return;

            if (cboCustomerCode.SelectedIndex == -1 || m_screenMode == Common.eScreenMode.EDIT) return;



            m_screenModel = m_controller.CreateUIDMForAddMode();

            shtCustomerOrderList.RowCount = 0;
            shtCustomerOrderList.DataSource = null;
            shtCustomerOrderList.DataSource = m_screenModel.DATA_VIEW;

            //if (cboCustomerCode.SelectedIndex == -1) return;
            //NZString CustomerCd = cboCustomerCode.SelectedValue.ToString().ToNZString();
            //List<CustomerOrderViewDTO> dtos = m_bizCustomer.LoadCustomerOrderEntryByCustomerCD(CustomerCd, false);
            //DataTable dt = DTOUtility.ConvertListToDataTable<CustomerOrderViewDTO>(dtos);
            //m_screenModel.DATA_VIEW = dt;
            //shtCustomerOrderList.RowCount = 0;
            //shtCustomerOrderList.DataSource = null;
            //shtCustomerOrderList.DataSource = m_screenModel.DATA_VIEW;

            //if (dtos.Count > 0)
            //{
            //    // Change Screen Mode to EDIT MODE when found data.
            //    SetScreenMode(Common.eScreenMode.EDIT);
            //    // set price value
            //    for (int i = 0; i < shtCustomerOrderList.RowCount; i++)
            //    {
            //        ItemBIZ itemBIZ = new ItemBIZ();
            //        ItemDTO itemDTO = itemBIZ.LoadItem(dtos[i].ITEM_CD);
            //        shtCustomerOrderList.Cells[i, (int)eColView.PART_NO].Value = itemDTO.SHORT_NAME.Value;

            //        shtCustomerOrderList.Cells[i, (int)eColView.PRICE_THB].Value = dtos[i].PRICE.StrongValue * decimal.Parse(txtExchangeRate.Text);
            //    }
            //}
        }

        private void dtReceiveDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtReceiveDate.Value.HasValue)
            {
                int row = shtCustomerOrderList.Rows.Count;
                if (row > 0)
                {

                    //RunningNumberBIZ runningNoBiz = new RunningNumberBIZ();

                    for (int i = 0; i < row; i++)
                    {
                        //shtCustomerOrderList.Cells[i, (int)eColView.LOT_NO].Value = dtReceiveDate.Value.Value.ToString(DataDefine.LOT_NO_FORMAT);

                        //string oLotControlCls = Convert.ToString(shtCustomerOrderList.Cells[i, (int)eColView.LOT_CONTROL_CLS].Value);

                        //string strItemCode = Convert.ToString(shtCustomerOrderList.Cells[i, (int)eColView.ITEM_CD].Value);

                        //if (oLotControlCls == DataDefine.Convert2ClassCode(DataDefine.eLOT_CONTROL_CLS.Yes))
                        //{
                        //    //shtCustomerOrderList.Cells[row, (int)eColView.LOT_NO].Value = dtReceiveDate.Value.Value.ToString(DataDefine.LOT_NO_FORMAT);

                        //    //if (rdoReceive.Checked)
                        //    //{

                        //    //    NZString strLotNoPrefix = runningNoBiz.GenerateLotNoPrefix(new NZDateTime(null, dtReceiveDate.Value));
                        //    //    NZInt iLastRunningNo = runningNoBiz.GetLastLotNoRunningBox(strLotNoPrefix, new NZString(cboStoredLoc, (string)cboStoredLoc.SelectedValue), (NZString)strItemCode, new NZInt(null, 0));

                        //    //    ReceivingEntryController rcvController = new ReceivingEntryController();
                        //    //    NZString strLotNo = rcvController.GenerateLotNo(strLotNoPrefix, ref iLastRunningNo);
                        //    //    shtCustomerOrderList.Cells[i, (int)eColView.LOT_NO].Value = strLotNo.StrongValue;

                        //    //}
                        //}
                        //else
                        //{
                        //    shtCustomerOrderList.Cells[i, (int)eColView.LOT_NO].Value = null;
                        //}



                    }
                }
            }
        }

        private void txtRemark_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                tslControl.Select();
                tsbSaveAndNew.Select();
            }
        }
        #endregion

        #region Control event
        private void miAdd_Click(object sender, EventArgs e)
        {
            m_keyboardSpread.OnActionAddNewRow();
            // DEFAULT LOT VALUE
            //if (rdoReceive.Checked && dtReceiveDate.Value.HasValue)
            //    shtCustomerOrderList.Cells[shtCustomerOrderList.Rows.Count - 1, (int)eColView.LOT_NO].Value = dtReceiveDate.Value.Value.ToString(DataDefine.LOT_NO_FORMAT);
        }

        private void miDelete_Click(object sender, EventArgs e)
        {
            if (shtCustomerOrderList.RowCount > 0)
            {
                int rowIndex = shtCustomerOrderList.ActiveRowIndex;
                InventoryBIZ biz = new InventoryBIZ();
                InventoryTransactionDTO dto = new InventoryTransactionDTO();
                dto.REF_NO = m_screenModel.ORDER_NO;
                if (shtCustomerOrderList.GetValue(rowIndex, (int)eColView.ORDER_DETAIL_NO) == null
                    || shtCustomerOrderList.GetValue(rowIndex, (int)eColView.ORDER_DETAIL_NO).ToString() == "")
                {
                    m_keyboardSpread.OnActionRemoveRow();
                    UpdateTotalValue(false, (int)eUpdateValueStatus.NONE);
                    return;
                }
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
            m_keyboardSpread.OnActionRemoveRow();
            UpdateTotalValue(false, (int)eUpdateValueStatus.NONE);
        }

        #endregion

        #region Spread event

        #region Variables
        /// <summary>
        /// เก็บรายการของแถวที่กำลังแก้
        /// </summary>
        private readonly Map<eColView, object> m_mapCellValue = new Map<eColView, object>();
        /// <summary>
        /// เก็บสถานะว่าตอนนี้ Row นั้น มีบาง Cell ที่ถูกปรับเปลี่ยนค่า
        /// </summary>
        private bool m_bRowHasModified = false;
        #endregion

        #region Utility method
        /// <summary>
        /// เก็บข้อมูลทุก Cell ของ Row ที่ระบุ
        /// </summary>
        /// <param name="rowIndex"></param>
        private void StoreCellValues(int rowIndex)
        {
            m_mapCellValue.RemoveAll();

            for (int i = 0; i < shtCustomerOrderList.Columns.Count; i++)
            {
                m_mapCellValue.Put((eColView)i, shtCustomerOrderList.Cells[rowIndex, i].Value);
            }

        }

        /// <summary>
        /// คืนค่า Cell ที่เก็บไว้ กลับคืนไปยัง Row ที่ระบุ
        /// </summary>
        /// <param name="rowIndex"></param>
        private void RestoreCellValues(int rowIndex)
        {
            if (m_mapCellValue.Count > 0)
            {
                for (int i = 0; i < m_mapCellValue.Count; i++)
                {
                    shtCustomerOrderList.Cells[rowIndex, (int)m_mapCellValue[i].Key].Value = m_mapCellValue[i].Value;
                }
            }
        }
        #endregion

        #region Spread trigger.
        private void fpView_EditModeOn(object sender, EventArgs e)
        {
            // ถ้าเป็นการแก้ไข Cell ใน Row เดียวกัน เป็นครั้งแรก
            if (!m_bRowHasModified)
            {
                m_bRowHasModified = true;
                StoreCellValues(shtCustomerOrderList.ActiveRowIndex);
            }
        }

        private void fpView_EditModeOff(object sender, EventArgs e)
        {

            int rowIndex = shtCustomerOrderList.ActiveRowIndex;
            int colIndex = shtCustomerOrderList.ActiveColumnIndex;

            bool bValidateCellPass = ValidateCellEdited(rowIndex, colIndex);
            if (!bValidateCellPass)
            {
                shtCustomerOrderList.SetActiveCell(rowIndex, colIndex);
            }
            // For check order qty more than delivery qty
            if (colIndex.Equals((int)eColView.QTY) || colIndex.Equals((int)eColView.PRICE))
            {
                if (skip_event_control) return;
                if (m_screenMode == Common.eScreenMode.EDIT && colIndex.Equals((int)eColView.QTY))
                {
                    if (shtCustomerOrderList.RowCount > 0
                        && shtCustomerOrderList.GetValue(rowIndex, (int)eColView.ORDER_DETAIL_NO) != null
                        && shtCustomerOrderList.GetValue(rowIndex, (int)eColView.ORDER_DETAIL_NO).ToString() != "")
                    {
                        UpdateTotalValue(true, rowIndex);

                        InventoryBIZ biz = new InventoryBIZ();
                        InventoryTransactionDTO dto = new InventoryTransactionDTO();
                        dto.REF_NO = m_screenModel.ORDER_NO;
                        dto.REF_SLIP_NO = shtCustomerOrderList.GetValue(rowIndex, (int)eColView.ORDER_DETAIL_NO).ToString().ToNZString();
                        dto.TRANS_CLS = DataDefine.eTRANS_TYPE_string.Shipment.ToNZString();
                        //CustomerOrderDDTO LoadCustomerOrderDetail(String Order_No, NZString Order_Detail_No)
                        List<InventoryTransactionDTO> listDTO = biz.LoadInventoryTrans(dto);
                        if (listDTO.Count > 0)
                        {
                            decimal ShipQTY = 0;
                            decimal OrderQTY = Convert.ToDecimal(shtCustomerOrderList.GetValue(rowIndex, (int)eColView.QTY));
                            foreach (InventoryTransactionDTO dtos in listDTO)
                            {
                                if (!dtos.QTY.IsNull && dtos.QTY.StrongValue > 0) ShipQTY += dtos.QTY.StrongValue;
                            }
                            if (OrderQTY < ShipQTY)
                            {
                                MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0204.ToString()));
                                shtCustomerOrderList.Cells[rowIndex, (int)eColView.QTY].Value = Convert.ToDecimal(shtCustomerOrderList.GetValue(rowIndex, (int)eColView.OLD_QTY));
                                shtCustomerOrderList.SetActiveCell(rowIndex, (int)eColView.QTY);
                                UpdateTotalValue(true, rowIndex);
                            }
                        }
                    }
                }
            }
            if (colIndex.Equals((int)eColView.ITEM_DELIVERY_DATE))
            {
                if (shtCustomerOrderList.GetValue(rowIndex, (int)eColView.ITEM_CD) == null
                    || shtCustomerOrderList.GetValue(rowIndex, (int)eColView.ITEM_CD).ToString() == "")
                {
                    return;
                }
                else
                {
                    LoadItemIntoRow(rowIndex, shtCustomerOrderList.GetValue(rowIndex, (int)eColView.ITEM_CD).ToString().ToNZString());
                    UpdateTotalValue(true, rowIndex);
                }
            }
        }

        private void fpView_LeaveCell(object sender, LeaveCellEventArgs e)
        {
            if (m_bRowHasModified)
            {  // เช็คว่า Cell ในแถวนั้น มีการแก้ไขค่าหรือไม่
                if (e.Row != e.NewRow)
                {  // ถ้าเป็นการเปลี่ยนแถว ต้องเช็คก่อนว่า Validate แถวผ่านหรือไม่?
                    if (!ValidateRowSpread(e.Row, false))
                    {
                        e.Cancel = true;
                    }

                }
            }
        }

        private void fpView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                if (m_bRowHasModified)
                {
                    int lastRowNonEmpty = shtCustomerOrderList.GetLastNonEmptyRow(NonEmptyItemFlag.Data);
                    if (lastRowNonEmpty != shtCustomerOrderList.RowCount - 1)
                    {
                        shtCustomerOrderList.RemoveRows(shtCustomerOrderList.RowCount - 1, 1);
                    }
                    else
                    {
                        RestoreCellValues(shtCustomerOrderList.ActiveRowIndex);
                    }

                    m_bRowHasModified = false;
                }
                else
                {
                    RemoveRowUnused(shtCustomerOrderList);
                }
            }
        }

        private void fpView_ButtonClicked(object sender, EditorNotifyEventArgs e)
        {
            if (e.Column == (int)eColView.ITEM_CD_BTN)
            {
                CtrlUtil.SpreadSetCellLocked(shtCustomerOrderList, false, e.Row, (int)eColView.ITEM_CD);

                if (cboCustomerCode.SelectedValue == null || cboCurrency.SelectedValue == null)
                {
                    if (cboCustomerCode.SelectedValue == null && cboCurrency.SelectedValue == null)
                        MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0105.ToString(), new object[] { "Customer Code and Currency" }));
                    else if (cboCustomerCode.SelectedValue == null)
                        MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0105.ToString(), new object[] { "Customer Code" }));
                    else if (cboCurrency.SelectedValue == null)
                        MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0105.ToString(), new object[] { "Currency" }));
                    return;
                }



                ItemFindDialog dialog = null;

                if (cboCustomerCode.SelectedIndex == -1)
                    dialog = new ItemFindDialog(eSqlOperator.In, null);
                else dialog = new ItemFindDialog(eSqlOperator.In, null, cboCustomerCode.ToNZString(), DataDefine.eDealingType.Customer);

                dialog.ShowDialog(this);

                if (dialog.IsSelected)
                {
                    //bool CheckkDuplicateItemCd = false;
                    //for (int i = 0; i < shtCustomerOrderList.RowCount; i++)
                    //{
                    //    object item_cd = shtCustomerOrderList.GetValue(i,(int)eColView.ITEM_CD);
                    //    if (item_cd != null && item_cd.ToString() != "" && item_cd.ToString() == dialog.SelectedItem.ITEM_CD.StrongValue)
                    //        CheckkDuplicateItemCd = true;
                    //}
                    //if (CheckkDuplicateItemCd)
                    //{
                    //    ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0185.ToString());
                    //    MessageDialog.ShowBusiness(this, error.Message);
                    //    return;
                    //}
                    LoadItemIntoRow(e.Row, dialog.SelectedItem.ITEM_CD);
                }

                CtrlUtil.SpreadSetCellLocked(shtCustomerOrderList, true, e.Row, (int)eColView.ITEM_CD);
            }
        }

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

                //if (isClickOnCell)
                //{
                //    NZString transID = new NZString(null, shtCustomerOrderList.Cells[cellRange.Row, (int)eColView.TRANS_ID].Value);
                //    bool canEditOrDelete = m_transactionValidator.TransactionCanEditOrDelete(transID);

                //    miDelete.Enabled = canEditOrDelete && ActivePermission.Delete;
                //    miEdit.Enabled = canEditOrDelete && ActivePermission.Edit;
                //}
                //else
                //{
                //    miAdd.Enabled = false;
                //    miDelete.Enabled = false;
                //}

            }

        }

        #endregion

        #region Spread Validate
        /// <summary>
        /// Validate เมื่อ Cell มีการแก้ไขเรียบร้อย  และค่าที่แก้ไขเป็นค่าใหม่
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        private bool ValidateCellEdited(int row, int column)
        {
            if (column == (int)eColView.ITEM_CD)
            {
                ItemValidator itemValidator = new ItemValidator();

                object objItemCode = shtCustomerOrderList.GetValue(row, column);
                if (objItemCode != null)
                {
                    NZString itemCode = new NZString(null, objItemCode);
                    bool bLoadItem = LoadItemIntoRow(row, itemCode);
                    if (!bLoadItem)
                        return false;
                }
            }
            if (column == (int)eColView.QTY)
            {
                UpdateTotalValue(true, row);
            }

            //else if (column == (int)eColView.ORDER_QTY)
            //{
            //    try
            //    {
            //        NZDecimal orderRate = new NZDecimal(null, shtCustomerOrderList.Cells[row, (int)eColView.ORDER_UM_RATE].Value);
            //        NZDecimal invRate = new NZDecimal(null, shtCustomerOrderList.Cells[row, (int)eColView.INV_UM_RATE].Value);
            //        NZDecimal orderQty = new NZDecimal(null, shtCustomerOrderList.Cells[row, (int)eColView.ORDER_QTY].Value);
            //        NZDecimal price = new NZDecimal(null, shtCustomerOrderList.Cells[row, (int)eColView.PRICE].Value);

            //        decimal invQty = (invRate.NVL(0) / orderRate.NVL(1)) * orderQty.NVL(0);
            //        decimal amount = price.NVL(0) * orderQty.NVL(0);

            //        shtCustomerOrderList.Cells[row, (int)eColView.QTY].Value = invQty;
            //        shtCustomerOrderList.Cells[row, (int)eColView.AMOUNT].Value = amount;
            //    }
            //    catch
            //    {
            //        shtCustomerOrderList.Cells[row, (int)eColView.AMOUNT].Value = 0;
            //        shtCustomerOrderList.Cells[row, (int)eColView.QTY].Value = 0;
            //    }
            //}

            //else if (column == (int)eColView.PRICE)
            //{
            //    try
            //    {
            //        NZDecimal orderQty = new NZDecimal(null, shtCustomerOrderList.Cells[row, (int)eColView.ORDER_QTY].Value);
            //        NZDecimal price = new NZDecimal(null, shtCustomerOrderList.Cells[row, (int)eColView.PRICE].Value);

            //        decimal amount = price.NVL(0) * orderQty.NVL(0);

            //        shtCustomerOrderList.Cells[row, (int)eColView.AMOUNT].Value = amount;
            //    }
            //    catch
            //    {
            //        shtCustomerOrderList.Cells[row, (int)eColView.AMOUNT].Value = 0;
            //    }
            //}

            return true;
        }

        /// <summary>
        /// Validate spread row.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="forceValidate">force to validate.</param>
        /// <returns></returns>
        private bool ValidateRowSpread(int row, bool forceValidate)
        {
            if (shtCustomerOrderList.RowCount <= 0) return true;

            if (!forceValidate && !m_bRowHasModified)
                return true;

            //Check item
            if (shtCustomerOrderList.RowCount > 0)
            {
                string itemCode = shtCustomerOrderList.Cells[row, (int)eColView.ITEM_CD].Text;

                if (String.IsNullOrEmpty(itemCode))
                {
                    ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0006.ToString());
                    MessageDialog.ShowBusiness(this, error.Message);
                    return false;
                }
                else
                {
                    ItemValidator itemValidator = new ItemValidator();
                    BusinessException error = itemValidator.CheckItemNotExist(itemCode.ToNZString());
                    if (error != null)
                    {

                        MessageDialog.ShowBusiness(this, error.Error.Message);
                        return false;
                    }
                }

                // Check ReceiveQty
                NZDecimal qty = new NZDecimal(null, shtCustomerOrderList.Cells[row, (int)eColView.QTY].Value);
                //if (qty.IsNull || qty.StrongValue == decimal.Zero)
                //{
                //    ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0153.ToString());
                //    MessageDialog.ShowBusiness(this, error.Message);
                //    return false;
                //}
                if (cboType.SelectedValue.ToString() == "FORECAST"  )
                {
                    if (qty.IsNull)
                    {
                        ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0225.ToString());
                        MessageDialog.ShowBusiness(this, error.Message);
                        return false;
                    }
                }
                else 
                {
                    if (qty.IsNull || qty.StrongValue == decimal.Zero)
                    {
                        ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0153.ToString());
                        MessageDialog.ShowBusiness(this, error.Message);
                        return false;
                    }
                }

                //Check Delivery Date
                if (shtCustomerOrderList.Cells[row, (int)eColView.ITEM_DELIVERY_DATE].Value == null
                    || shtCustomerOrderList.Cells[row, (int)eColView.ITEM_DELIVERY_DATE].Value.ToString() == "")
                {
                    ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0208.ToString());
                    MessageDialog.ShowBusiness(this, error.Message);
                    return false;
                }
            }
            // ถ้า Validate Row ผ่าน แสดงว่า แถวนั้นไม่จำเป็นต้องเช็คอีกรอบ
            m_bRowHasModified = false;
            return true;
        }
        #endregion

        private void cboCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCurrency.SelectedIndex != -1 && cboCurrency.SelectedValue.ToString() == DataDefine.CURRENCY_THB)
            {
                txtExchangeRate.Decimal = 1;
                CtrlUtil.EnabledControl(false, txtExchangeRate);
            }
            else
            {
                CtrlUtil.EnabledControl(true, txtExchangeRate);
            }

            if (skip_event_control) return;
            for (int i = 0; i < shtCustomerOrderList.RowCount; i++)
            {


                if (shtCustomerOrderList.Cells[i, (int)eColView.ITEM_CD].Value == null || shtCustomerOrderList.GetValue(i, (int)eColView.ITEM_CD).ToString() == "") continue;
                //LoadItemIntoRow(i, shtCustomerOrderList.GetValue(i, (int)eColView.ITEM_CD).ToString().ToNZString());

                SalesUnitPriceBIZ bizPrice = new SalesUnitPriceBIZ();
                DateTime DeliveryDate = new DateTime();



                bool ChkConvertDate = shtCustomerOrderList.GetValue(i, (int)eColView.ITEM_DELIVERY_DATE) == null ? false : DateTime.TryParse(shtCustomerOrderList.GetValue(i, (int)eColView.ITEM_DELIVERY_DATE).ToString(), out DeliveryDate);
                if (ChkConvertDate)
                {
                    SalesUnitPriceDTO dtoPrice = bizPrice.getSalesUnitPriceByEffectiveDate(shtCustomerOrderList.GetValue(i, (int)eColView.ITEM_CD).ToString().ToNZString(), cboCurrency.SelectedValue.ToString().ToNZString(), DeliveryDate.Date.ToNZDateTime());
                    shtCustomerOrderList.SetValue(i, (int)eColView.PRICE, dtoPrice == null ? 0 : dtoPrice.PRICE.StrongValue);
                    shtCustomerOrderList.SetValue(i, (int)eColView.PRICE_THB, dtoPrice == null ? 0 : dtoPrice.PRICE.StrongValue * decimal.Parse(txtExchangeRate.Text));
                    //shtCustomerOrderList.Cells[i, (int)eColView.PRICE].Value = dtoPrice == null ? 0 : dtoPrice.PRICE.StrongValue;
                    //shtCustomerOrderList.Cells[i, (int)eColView.PRICE_THB].Value = dtoPrice == null ? 0 : dtoPrice.PRICE.StrongValue * decimal.Parse(txtExchangeRate.Text);
                }
                else
                {
                    shtCustomerOrderList.SetValue(i, (int)eColView.PRICE, 0);
                    shtCustomerOrderList.SetValue(i, (int)eColView.PRICE_THB, 0);
                    //shtCustomerOrderList.Cells[i, (int)eColView.PRICE].Value = 0;
                    //shtCustomerOrderList.Cells[i, (int)eColView.PRICE_THB].Value = 0;
                }
            }
            UpdateTotalValue(true, (int)eUpdateValueStatus.ALL);
        }

        #endregion

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (skip_event_control) return;
            if (m_screenMode == Common.eScreenMode.EDIT && cboType.SelectedValue.ToString() == DataDefine.ORDER_TYPE_FORECAST)
            {
                if (shtCustomerOrderList.RowCount > 0)
                {
                    CustomerOrderBIZ biz = new CustomerOrderBIZ();
                    CustomerOrderDDTO dto = new CustomerOrderDDTO();
                    dto.ORDER_NO = m_screenModel.ORDER_NO;
                    //CustomerOrderDDTO LoadCustomerOrderDetail(String Order_No, NZString Order_Detail_No)
                    List<CustomerOrderDDTO> listDTO = biz.LoadCustomerOrderDetail(m_screenModel.ORDER_NO.StrongValue);

                    foreach (CustomerOrderDDTO dtos in listDTO)
                    {
                        if (!dtos.SHIP_QTY.IsNull && dtos.SHIP_QTY.StrongValue > 0)
                        {
                            MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0203.ToString()));
                            cboType.SelectedValue = DataDefine.ORDER_TYPE_FIX;
                            break;
                        }
                    }
                }
            }
        }

        private void fpCustomerOrderList_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }

        private void txtExchangeRate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (skip_event_control) return;
            decimal ExchangeRate = 1;
            if (!decimal.TryParse(txtExchangeRate.Text, out ExchangeRate) || shtCustomerOrderList.RowCount <= 0) return;
            if (ExchangeRate <= 0)
            {
                MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0223.ToString()));
                txtExchangeRate.Decimal = 1;
                return;
            }
            for (int i = 0; i < shtCustomerOrderList.RowCount; i++)
            {
                if (shtCustomerOrderList.GetValue(i, (int)eColView.QTY) == null
                        || shtCustomerOrderList.GetValue(i, (int)eColView.QTY).ToString() == ""
                        || shtCustomerOrderList.GetValue(i, (int)eColView.PRICE) == null
                        || shtCustomerOrderList.GetValue(i, (int)eColView.PRICE).ToString() == "") continue;

                decimal d_Price = 0;
                decimal d_Amount = 0;
                decimal.TryParse(shtCustomerOrderList.Cells[i, (int)eColView.PRICE].Value.ToString(), out d_Price);
                decimal.TryParse(shtCustomerOrderList.Cells[i, (int)eColView.QTY].Value.ToString(), out d_Amount);

                ItemBIZ itemBIZ = new ItemBIZ();
                ItemDTO itemDTO = itemBIZ.LoadItem(shtCustomerOrderList.Cells[i, (int)eColView.ITEM_CD].Value.ToString().ToNZString());
                shtCustomerOrderList.Cells[i, (int)eColView.PART_NO].Value = itemDTO.SHORT_NAME.Value;

                shtCustomerOrderList.Cells[i, (int)eColView.PRICE_THB].Value = d_Price * ExchangeRate;
                shtCustomerOrderList.Cells[i, (int)eColView.AMOUNT_THB].Value = d_Amount * d_Price * ExchangeRate;

            }
            UpdateTotalValue(true, (int)eUpdateValueStatus.ALL);

        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (Common.UserGroupShowFormatButton.ToUpper().Equals(Common.CurrentUserInfomation.GroupCode.NVL("").ToUpper()))
            {
                tsbDefaultSize.Visible = true;
                tsbSaveFormat.Visible = true;
            }

            SheetWidthController ctrl = new SheetWidthController();
            ctrl.SetSheetWidth(shtCustomerOrderList, this.ScreenCode);
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

    }
}
