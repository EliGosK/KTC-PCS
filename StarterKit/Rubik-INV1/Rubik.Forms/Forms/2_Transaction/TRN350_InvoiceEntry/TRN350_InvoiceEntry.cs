using System;
using System.Collections.Generic;
using CommonLib;
using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Windows.Forms;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using Rubik.BIZ;
using Rubik.Controller;
using Rubik.DTO;
using Rubik.Forms.FindDialog;
using Rubik.UIDataModel;
using Rubik.Validators;
using System.Windows.Forms;
using Message = EVOFramework.Message;
using System.Data;
using Rubik.Transaction;
using FarPoint.Win.Spread.Model;
using System.Drawing;


namespace Rubik.Transaction
{
    //[Screen("TRN350", "Invoice Entry", eShowAction.Normal, eScreenType.Screen, "Invoice Entry")]
    public partial class TRN350_InvoiceEntry : SystemMaintenance.Forms.CustomizeForm
    {
        #region Enum

        public enum eColView
        {
            PO_NO,
            ORDER_NO,
            ORDER_DETAIL_NO,
            ITEM_CD,
            SHORT_NAME,
            ITEM_DESC,
            UNIT,
            QTY,
            PRICE,
            AMOUNT,
            TRANS_ID
        }

        public enum eSaveMode
        {
            ADD, UPDATE, VIEW,
        }
        #endregion

        #region Variable

        private KeyboardSpread m_keyboardSpread;
        private SelectedDataRow m_SelectedDataRow = new SelectedDataRow();
        private Common.eScreenMode m_Mode = Common.eScreenMode.ADD;
        private InvoiceEntryUIDM m_uidm = new InvoiceEntryUIDM();

        private DataTable TempDataOrder = new DataTable();
        private DataTable TempDataLot = new DataTable();

        private readonly TransactionValidator m_transactionValidator = new TransactionValidator();
        //private DataTable m_dtShipList;

        /// <summary>
        /// เก็บสถานะว่าตอนนี้ Row นั้น มีบาง Cell ที่ถูกปรับเปลี่ยนค่า
        /// </summary>
        private bool m_bRowHasModified;
        /// <summary>
        /// เก็บรายการของแถวที่กำลังแก้
        /// </summary>
        private readonly Map<eColView, object> m_mapCellValue = new Map<eColView, object>();
        #endregion

        #region Constructor
        public TRN350_InvoiceEntry(InvoiceEntryUIDM uidm)
        {
            InitializeComponent();
            m_uidm = uidm;

            SetScreenMode(Common.eScreenMode.EDIT);

            // Check can edit ?
            /*if (m_transactionValidator.TransactionCanEditOrDelete(m_uidm.SLIP_NO))
            {
                SetScreenMode(Common.eScreenMode.EDIT);
            }
            else
            {

                SetScreenMode(Common.eScreenMode.VIEW);
            }*/
        }
        public TRN350_InvoiceEntry()
        {
            InitializeComponent();
            //SetScreenMode(Common.eScreenMode.ADD);
        }
        #endregion

        #region Initialize Screen
        private void InitialScreen()
        {
            InitialSpread();
            InitialComboBox();
            InitialFormat();
            dmcShip.AddControl(chkCancelInvoice);
            dmcShip.AddControl(lblTransactionNo);
            dmcShip.AddControl(txtDeliveryNo);
            dmcShip.AddControl(cboCustomerCode);
            dmcShip.AddControl(txtFullAddress);
            dmcShip.AddControl(txtInvoiceNo);
            dmcShip.AddControl(dtInvoiceDate);
            dmcShip.AddControl(cboTermOfPayment);
            dmcShip.AddControl(dtPaymentDueDate);
            dmcShip.AddControl(txtReferTemNo);
            dmcShip.AddControl(txtRemark);
            dmcShip.AddControl(txtSubTotal);
            dmcShip.AddControl(txtVat);
            dmcShip.AddControl(txtVatTotal);
            dmcShip.AddControl(txtTotal);

            CtrlUtil.EnabledControl(false, lblTransactionNo, txtTotal, txtSubTotal);

            txtDeliveryNo.KeyPress += CtrlUtil.SetNextControl;
            cboCustomerCode.KeyPress += CtrlUtil.SetNextControl;
            txtInvoiceNo.KeyPress += CtrlUtil.SetNextControl;
            dtInvoiceDate.KeyPress += CtrlUtil.SetNextControl;
            cboTermOfPayment.KeyPress += CtrlUtil.SetNextControl;
            dtPaymentDueDate.KeyPress += CtrlUtil.SetNextControl;
            txtReferTemNo.KeyPress += CtrlUtil.SetNextControl;
            txtRemark.KeyPress += CtrlUtil.SetNextControl;

            //ClearAllControl();

            if (m_Mode == Common.eScreenMode.ADD)
            {
                SysConfigBIZ sysBiz = new SysConfigBIZ();
                SysConfigDTO argScreenInfo = new SysConfigDTO();
                argScreenInfo.SYS_GROUP_ID = DataDefine.eSYSTEM_CONFIG.TRN350.SYS_GROUP_ID;
                argScreenInfo.SYS_KEY = (NZString)DataDefine.eSYSTEM_CONFIG.TRN350.SYS_KEY.DEFAULT_DATE.ToString();
                dtInvoiceDate.Value = sysBiz.GetDefaultDateForScreen(argScreenInfo);
            }
            if (m_Mode != Common.eScreenMode.ADD)
            {
                dmcShip.LoadData(m_uidm);
                LoadShipList();
            }

            CheckCurrentInvPeriod();

            //m_keyboardSpread = new KeyboardSpread(fpCustomerOrder);
            //m_keyboardSpread.RowAdding += m_keyboardSpread_RowAdding;
            //m_keyboardSpread.RowAdded += m_keyboardSpread_RowAdded;
            //m_keyboardSpread.RowRemoved += m_keyboardSpread_RowRemoved;

            //if (m_Mode != Common.eScreenMode.VIEW)
            //{
            //    m_keyboardSpread.StartBind();
            //}
        }
        private void InitialFormat()
        {
            // Set Control Format
            dtInvoiceDate.Format = Common.CurrentUserInfomation.DateFormatString;
            CommonLib.FormatUtil.SetNumberFormat(this.txtVat, FormatUtil.eNumberFormat.ExchangeRate);
            CommonLib.FormatUtil.SetNumberFormat(this.txtVatTotal, FormatUtil.eNumberFormat.Amount);
            CommonLib.FormatUtil.SetNumberFormat(this.txtSubTotal, FormatUtil.eNumberFormat.Total_Qty_PCS);
            CommonLib.FormatUtil.SetNumberFormat(this.txtTotal, FormatUtil.eNumberFormat.Amount);

            // Set Spread Format
            FormatUtil.SetNumberFormat(this.shtCustomerOrder.Columns[(int)eColView.ITEM_CD], FormatUtil.eNumberFormat.MasterNo);
            FormatUtil.SetNumberFormat(shtCustomerOrder.Columns[(int)eColView.QTY], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtCustomerOrder.Columns[(int)eColView.PRICE], FormatUtil.eNumberFormat.UnitPrice);
            FormatUtil.SetNumberFormat(shtCustomerOrder.Columns[(int)eColView.AMOUNT], FormatUtil.eNumberFormat.Amount);
        }
        private void LoadShipList()
        {
            dmcShip.LoadData(m_uidm);

            if (m_Mode == Common.eScreenMode.ADD)
            {
                InvoiceController ctrl = new InvoiceController();
                shtCustomerOrder.RowCount = 0;
                DataTable dtOrder = DTOUtility.ConvertListToDataTable<InvoiceDTO>(ctrl.Load_Delivery_Detail(m_uidm.DELIVERY_NO.StrongValue));
                shtCustomerOrder.DataSource = dtOrder;
            }
            else
            {
                InvoiceController ctrl = new InvoiceController();
                shtCustomerOrder.RowCount = 0;
                DataTable dtOrder = DTOUtility.ConvertListToDataTable<InvoiceDTO>(ctrl.Load_By_Bill_No(m_uidm.BILL_NO.StrongValue));
                shtCustomerOrder.DataSource = dtOrder;
            }

            ////ShipmentEntryController ctl = new ShipmentEntryController();
            //m_uidm.DATA_VIEW = ctl.LoadShipList(SlipNo);
            //CalculateOldInventoryOnhand();
            //this.shtCustomerOrder.DataSource = m_uidm.DATA_VIEW;
            //// load lot no
            //int row = shtCustomerOrder.Rows.Count;
            //for (int i = 0; i < row; i++)
            //{
            //    NZString ItemCD = new NZString(null, shtCustomerOrder.Cells[i, (int)eColView.PART_NO].Value);
            //    NZString LocCD = new NZString(null, cboFromLoc.SelectedValue);

            //    LookupLotNo(i, ItemCD, LocCD);
            //    shtCustomerOrder.Cells[i, (int)eColView.LOT_NO].Value =
            //        m_uidm.DATA_VIEW.Rows[i][eColView.LOT_NO.ToString()].ToString();
            //}
        }
        private void LookupLotNo(int ActiveRow, NZString ItemCD, NZString LocCD)
        {
            // Load Lot control
            LookupDataBIZ bizLookup = new LookupDataBIZ();
            // Lookup Lot No
            //LookupData lookupLotNo = bizLookup.LoadLookupLotNo(ItemCD, LocCD, dtDeliveryDate.Value.Value.ToString("yyyyMM").ToNZString());
            //shtCustomerOrder.Cells[ActiveRow, (int)eColView.LOT_NO].CellType = CreateLotNoCellType(lookupLotNo);
            //((ComboBoxCellType)shtCustomerOrder.Cells[ActiveRow, (int)eColView.LOT_NO].CellType).Editable = true;
            //((ComboBoxCellType)shtCustomerOrder.Cells[ActiveRow, (int)eColView.LOT_NO].CellType).AutoSearch = true;
        }

        private void InitialComboBox()
        {
            cboCustomerCode.Format += Common.ComboBox_Format;

            LookupDataBIZ bizLookup = new LookupDataBIZ();

            // Lookup To CustomerLocation
            LookupData lookupCustomer = bizLookup.LoadLookupLocation(new NZString[]{(NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Customer)
            ,(NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.CustomerVendor)});
            cboCustomerCode.LoadLookupData(lookupCustomer);
            cboCustomerCode.SelectedIndex = -1;

            ClassListBIZ biz = new ClassListBIZ();
            DataTable dt = DTOUtility.ConvertListToDataTable<ClassListDTO>(biz.LoadByClassInfo("term_of_payment".ToNZString()));
            cboTermOfPayment.DataSource = dt;
            cboTermOfPayment.ValueMember = "CLS_CD";
            cboTermOfPayment.DisplayMember = "TERM_OF_PAYMENT";
            cboTermOfPayment.SelectedIndex = -1;
        }

        private void InitialSpread()
        {
            shtCustomerOrder.ActiveSkin = Common.ACTIVE_SKIN;

            m_keyboardSpread = new KeyboardSpread(fpCustomerOrder);

            fpCustomerOrder.SubEditorOpening += CtrlUtil.SpreadDisableSubEditorOpening;

            CtrlUtil.MappingDataFieldWithEnum(shtCustomerOrder, typeof(eColView));




            //m_keyboardSpread.IsBinded = true;
            //m_keyboardSpread.RowAdding += m_keyboardSpread_RowAdding;
            //m_keyboardSpread.RowAdded += m_keyboardSpread_RowAdded;
            //m_keyboardSpread.RowRemoved += m_keyboardSpread_RowRemoved;

            //m_keyboardSpread.IsBinded = true;
            //m_keyboardSpread.RowAdding += m_keyboardSpread_RowAdding;
            //m_keyboardSpread.RowAdded += m_keyboardSpread_RowAdded;
            //m_keyboardSpread.RowRemoved += m_keyboardSpread_RowRemoved;

            //CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColView.ONHAND_QTY);

            //string[] name = Enum.GetNames(typeof(eColView));

            //shtCustomerOrder.DataSource = m_uidm.DATA_VIEW;

            //for (int i = 0; i < name.Length; i++)
            //{
            //    shtCustomerOrder.Columns[i].DataField = name[i];
            //}
            //if (m_Mode == Common.eScreenMode.EDIT)
            //{
            //    for (int i = 0; i < name.Length; i++)
            //    {
            //        CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, i);

            //    }
            //    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, false, (int)eColView.ISSUE_QTY);
            //    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, false, (int)eColView.OTHER_DL_NO);
            //    dmcShip.LoadData(m_uidm);

            //    shtCustomerOrder.RowCount = 0;

            //}


        }

        private void ClearAllControl()
        {
            CtrlUtil.ClearControlData(txtDeliveryNo, cboCustomerCode, txtInvoiceNo, dtInvoiceDate,
                                        cboTermOfPayment, dtPaymentDueDate,txtSubTotal,txtVat, txtVatTotal,txtTotal);
            //rdoShipType_Ship.Checked = true;
            shtCustomerOrder.Rows.Count = 0;
            if (shtCustomerOrder.DataSource != null)
            {
                DataTable dt = shtCustomerOrder.DataSource as DataTable;
                dt.Rows.Clear();
            }

            //m_SelectedDataRow = new SelectedDataRow();
        }

        private void ClearAllControlExceptDefault()
        {
            CtrlUtil.ClearControlData(txtDeliveryNo, cboCustomerCode, txtInvoiceNo, dtInvoiceDate,
                                        cboTermOfPayment, dtPaymentDueDate, txtSubTotal, txtVat, txtVatTotal, txtTotal);
            
            CtrlUtil.ClearControlData(txtRemark, cboCustomerCode);
            // Set Default Date
            SysConfigBIZ sysBiz = new SysConfigBIZ();
            SysConfigDTO argScreenInfo = new SysConfigDTO();
            argScreenInfo.SYS_GROUP_ID = DataDefine.eSYSTEM_CONFIG.TRN350.SYS_GROUP_ID;
            argScreenInfo.SYS_KEY = (NZString)DataDefine.eSYSTEM_CONFIG.TRN350.SYS_KEY.DEFAULT_DATE.ToString();
            dtInvoiceDate.Value = sysBiz.GetDefaultDateForScreen(argScreenInfo);

            argScreenInfo.SYS_KEY = (NZString)DataDefine.eSYSTEM_CONFIG.TRN350.SYS_KEY.DEFAULT_VAT.ToString();
            txtVat.Decimal = decimal.Parse(sysBiz.LoadByPK(DataDefine.eSYSTEM_CONFIG.TRN350.SYS_GROUP_ID, "DEFAULT_VAT".ToNZString()).CHAR_DATA);
            shtCustomerOrder.Rows.Count = 0;
            if (shtCustomerOrder.DataSource != null)
            {
                DataTable dt = shtCustomerOrder.DataSource as DataTable;
                dt.Rows.Clear();
            }

            //m_SelectedDataRow = new SelectedDataRow();
        }
        #endregion

        #region Screen Mode
        private void SetScreenMode(Common.eScreenMode mode)
        {
            switch (mode)
            {
                case Common.eScreenMode.ADD:
                    CtrlUtil.EnabledControl(true, txtDeliveryNo, cboAddress, txtInvoiceNo,
                                                    dtInvoiceDate,cboTermOfPayment,dtPaymentDueDate,
                                                    txtReferTemNo,txtRemark, txtVat, txtVatTotal);
                    CtrlUtil.EnabledControl(false, cboCustomerCode, txtFullAddress, txtSubTotal,txtTotal);
                    shtCustomerOrder.OperationMode = OperationMode.Normal;
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColView.PO_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColView.ORDER_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColView.ORDER_DETAIL_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColView.ITEM_CD);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColView.SHORT_NAME);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, false, (int)eColView.ITEM_DESC);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, false, (int)eColView.UNIT);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, false, (int)eColView.QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, false, (int)eColView.PRICE);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, false, (int)eColView.AMOUNT);


                    break;
                case Common.eScreenMode.EDIT:
                    CtrlUtil.EnabledControl(false, txtDeliveryNo, cboAddress, txtInvoiceNo,
                                                    dtInvoiceDate,cboTermOfPayment,dtPaymentDueDate,
                                                    txtVat, cboCustomerCode, txtFullAddress, txtSubTotal);
                    CtrlUtil.EnabledControl(true, txtReferTemNo, txtRemark, txtVatTotal, txtTotal);
                    shtCustomerOrder.OperationMode = OperationMode.Normal;
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColView.PO_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColView.ORDER_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColView.ORDER_DETAIL_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColView.ITEM_CD);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColView.SHORT_NAME);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, false, (int)eColView.ITEM_DESC);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, false, (int)eColView.UNIT);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, false, (int)eColView.QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, false, (int)eColView.PRICE);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, false, (int)eColView.AMOUNT);

                    break;
                case Common.eScreenMode.VIEW:

                    shtCustomerOrder.OperationMode = OperationMode.ReadOnly;
                    CtrlUtil.EnabledControl(false, txtDeliveryNo, cboAddress, txtInvoiceNo,
                                                    dtInvoiceDate,cboTermOfPayment,dtPaymentDueDate,
                                                    txtVat, cboCustomerCode, txtFullAddress, txtSubTotal);
                    CtrlUtil.EnabledControl(false, txtReferTemNo, txtRemark, txtVatTotal, txtTotal);
                    shtCustomerOrder.OperationMode = OperationMode.ReadOnly;
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColView.PO_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColView.ORDER_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColView.ORDER_DETAIL_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColView.ITEM_CD);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColView.SHORT_NAME);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColView.ITEM_DESC);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColView.UNIT);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColView.QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColView.PRICE);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColView.AMOUNT);


                    fpCustomerOrder.ContextMenuStrip = null;
                    tsbSaveAndClose.Enabled = false;
                    tsbSaveAndNew.Enabled = false;
                    break;
            }

            m_Mode = mode;
        }
        #endregion

        #region Private method
        private ComboBoxCellType CreateLotNoCellType(LookupData data)
        {
            ComboBoxCellType cell = new ComboBoxCellType();
            cell.Editable = true;
            cell.EditorValue = EditorValue.ItemData;

            if ((data.DataSource) != null)
            {
                DataTable dt = data.DataSource;

                string[] strItems = new string[dt.Rows.Count];
                string[] strItemData = new string[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strItemData[i] = dt.Rows[i][data.ValueMember] as string;
                    strItems[i] = strItemData[i];
                }

                cell.Items = strItems;
                cell.ItemData = strItemData;
            }

            return cell;
        }

        private bool ValidateMandatory()
        {
            if (!dtInvoiceDate.Value.HasValue)
            {
                ValidateException.ThrowErrorItem(new ErrorItem(null, TKPMessages.eValidate.VLM0105.ToString(), new object[] { "Delivery Date" }));
                return false;
            }
            if (cboCustomerCode.SelectedValue == null)
            {
                ValidateException.ThrowErrorItem(new ErrorItem(null, TKPMessages.eValidate.VLM0105.ToString(), new object[] { "Customer Code" }));
                return false;
            }

            // Validate Data before Save
            if (shtCustomerOrder.Rows.Count == 0)
            {
                ValidateException.ThrowErrorItem(new ErrorItem(null, TKPMessages.eValidate.VLM0190.ToString()));
            }

            //if (!CheckChooseLotForOrder())
            //{
            //    ValidateException.ThrowErrorItem(new ErrorItem(null, TKPMessages.eValidate.VLM0194.ToString()));
            //}
            //if (!CheckChooseLotOverRemain())
            //{
            //    ValidateException.ThrowErrorItem(new ErrorItem(null, TKPMessages.eValidate.VLM0214.ToString()));
            //}

            ShipEntryValidator valShip = new ShipEntryValidator();
            IssueEntryValidator valIssue = new IssueEntryValidator();
            InventoryOnhandValidator valINV = new InventoryOnhandValidator();
            TransactionValidator valTRN = new TransactionValidator();
            CommonBizValidator commonVal = new CommonBizValidator();
            ErrorItem errorItem;


            errorItem = valTRN.DateIsInCurrentPeriod(new NZDateTime(dtInvoiceDate, dtInvoiceDate.Value));
            if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);


            NZString YearMonth = new InventoryPeriodBIZ().LoadCurrentPeriod().YEAR_MONTH;

            return true;
        }

        /// <summary>
        /// check item code and load item desc to spread if item exist
        /// </summary>
        /// <returns></returns>
        private bool CheckFromSpread_ItemCD(int ActiveRow)
        {
            /*NZString ItemCD = new NZString(null,
                                           shtCustomerOrder.Cells[ActiveRow, (int)eColView.PART_NO].
                                               Text);
            NZString LotNo = new NZString(null, shtCustomerOrder.Cells[ActiveRow, (int)eColView.LOT_NO].Value);
            NZString PackNo = new NZString(null, shtCustomerOrder.Cells[ActiveRow, (int)eColView.PACK_NO].Value);

            ItemBIZ bizItem = new ItemBIZ();
            ItemDTO dtoItem = bizItem.LoadItem(ItemCD);
            if (dtoItem != null)
            {
                shtCustomerOrder.Cells[ActiveRow, (int)eColView.PART_NO].Value = dtoItem.ITEM_CD.StrongValue;
                shtCustomerOrder.Cells[ActiveRow, (int)eColView.PART_NAME].Value = dtoItem.ITEM_DESC.StrongValue;
                return true;
            }
            shtCustomerOrder.Cells[ActiveRow, (int)eColView.PART_NAME].Value = null;
            shtCustomerOrder.Cells[ActiveRow, (int)eColView.LOT_NO].Value = null;
            shtCustomerOrder.Cells[ActiveRow, (int)eColView.ONHAND_QTY].Value = 0;

            MessageDialog.ShowBusiness(this,
                                       Message.LoadMessage(TKPMessages.eValidate.VLM0009.ToString()).MessageDescription);
            * return false;
             */
            return true;
        }

        private void RemoveRowUnused(SheetView sheet)
        {
            int lastRowNonEmpty = shtCustomerOrder.GetLastNonEmptyRow(NonEmptyItemFlag.Data);
            if (lastRowNonEmpty != shtCustomerOrder.RowCount - 1)
            {
                shtCustomerOrder.RemoveRows(shtCustomerOrder.RowCount - 1, 1);
            }

            if (lastRowNonEmpty != -1)
            {
                object o = shtCustomerOrder.Cells[lastRowNonEmpty, (int)eColView.SHORT_NAME].Value;

                if (o == null || o == DBNull.Value)
                {
                    shtCustomerOrder.RemoveRows(lastRowNonEmpty, 1);
                }
            }
        }


        private bool SaveData()
        {
            InvoiceController ctrlInvoice = new InvoiceController();
            NZString TRANS_ID = m_uidm.TRANS_ID;
            InvoiceEntryUIDM uidm = dmcShip.SaveData(new InvoiceEntryUIDM());
            uidm.DATA_VIEW = (DataTable)shtCustomerOrder.DataSource;
            if (m_Mode != Common.eScreenMode.ADD) uidm.BILL_NO.Value = lblInvoiceNo.Text.Trim();
            ctrlInvoice.SaveInvoiceEntry(uidm, m_Mode);
            return true;
        }

        #endregion

        #region Overriden method
        public override void OnSaveAndClose()
        {
            try
            {
                label7.Focus();
                this.fpCustomerOrder.StopCellEditing();
                //if (m_bRowHasModified)
                //{ // ถ้า Row กำลังแก้ไขอยู่
                //    if (!ValidateRowSpread(shtCustomerOrder.ActiveRowIndex, false))
                //    {
                //        return;
                //    }
                //}

                //this.fpCustomerOrderDetail.StopCellEditing();
                //if (m_bRowHasModified)
                //{ // ถ้า Row กำลังแก้ไขอยู่
                //    if (!ValidateRowSpread(shtCustomerOrderDetail.ActiveRowIndex, false))
                //    {
                //        return;
                //    }
                //}

                // ต้องเรียกก่อน Save เสมอ  เพื่อ Commit ข้อมูลการแก้ไขล่าสุดบน Grid
                // ใช้ได้เฉพาะกับ Sheet ที่ผูก DataSource
                CtrlUtil.SpreadSheetRowEndEdit(shtCustomerOrder, shtCustomerOrder.ActiveRowIndex);
                //CtrlUtil.SpreadSheetRowEndEdit(shtCustomerOrderDetail, shtCustomerOrderDetail.ActiveRowIndex);

                RemoveRowUnused(shtCustomerOrder);
                //RemoveRowUnused(shtCustomerOrderDetail);

                if (!ValidateMandatory())
                {
                    return;
                }

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new Message(SystemMaintenance.Messages.eConfirm.CFM9001.ToString()).MessageDescription);
                switch (dr)
                {
                    case MessageDialogResult.Cancel:
                        return;

                    case MessageDialogResult.No:
                        //Close();
                        return;

                    case MessageDialogResult.Yes:
                        break;

                }
                if (SaveData())
                {
                    MessageDialog.ShowInformation(this, "Information", new Message(SystemMaintenance.Messages.eInformation.INF9003.ToString()).MessageDescription);
                    Close();
                }
            }
            catch (ValidateException err)
            {
                for (int i = 0; i < err.ErrorResults.Count; i++)
                {
                    MessageDialog.ShowBusiness(this, err.ErrorResults[i].Message);
                    err.ErrorResults[i].FocusOnControl();
                }

            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                err.Error.FocusOnControl();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }
        public override void OnSaveAndNew()
        {
            try
            {
                label7.Focus();

                this.fpCustomerOrder.StopCellEditing();
                //if (m_bRowHasModified)
                //{ // ถ้า Row กำลังแก้ไขอยู่
                //    if (!ValidateRowSpread(shtCustomerOrder.ActiveRowIndex, false))
                //    {
                //        return;
                //    }
                //}


                // ต้องเรียกก่อน Save เสมอ  เพื่อ Commit ข้อมูลการแก้ไขล่าสุดบน Grid
                // ใช้ได้เฉพาะกับ Sheet ที่ผูก DataSource
                CtrlUtil.SpreadSheetRowEndEdit(shtCustomerOrder, shtCustomerOrder.ActiveRowIndex);

                RemoveRowUnused(shtCustomerOrder);

                if (!ValidateMandatory())
                {
                    return;
                }

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new Message(SystemMaintenance.Messages.eConfirm.CFM9001.ToString()).MessageDescription);
                switch (dr)
                {
                    case MessageDialogResult.Cancel:
                        return;

                    case MessageDialogResult.No:
                        //Close();
                        return;

                    case MessageDialogResult.Yes:
                        break;

                }
                if (SaveData())
                {
                    MessageDialog.ShowInformation(this, "Information", new Message(SystemMaintenance.Messages.eInformation.INF9003.ToString()).MessageDescription);
                    ClearAllControlExceptDefault();
                    m_Mode = Common.eScreenMode.ADD;
                    lblTransactionNo.Text = "";

                    SysConfigBIZ sysBiz = new SysConfigBIZ();
                    SysConfigDTO argScreenInfo = new SysConfigDTO();
                    argScreenInfo.SYS_GROUP_ID = DataDefine.eSYSTEM_CONFIG.TRN100.SYS_GROUP_ID;
                    argScreenInfo.SYS_KEY = (NZString)DataDefine.eSYSTEM_CONFIG.TRN100.SYS_KEY.DEFAULT_DATE.ToString();
                    dtInvoiceDate.Value = sysBiz.GetDefaultDateForScreen(argScreenInfo);

                    CtrlUtil.EnabledControl(true, txtRemark, dtInvoiceDate, cboCustomerCode);
                    dtInvoiceDate.Focus();
                    dtInvoiceDate.Select();
                }
            }
            catch (ValidateException err)
            {
                for (int i = 0; i < err.ErrorResults.Count; i++)
                {
                    MessageDialog.ShowBusiness(this, err.ErrorResults[i].Message);
                    err.ErrorResults[i].FocusOnControl();
                }

            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                err.Error.FocusOnControl();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }

        }
        #endregion

        #region Utility method
        /// <summary>
        /// เก็บข้อมูลทุก Cell ของ Row ที่ระบุ
        /// </summary>
        /// <param name="rowIndex"></param>
        private void StoreCellValues(int rowIndex)
        {
            m_mapCellValue.RemoveAll();
            for (int i = 0; i < shtCustomerOrder.Columns.Count; i++)
            {
                m_mapCellValue.Put((eColView)i, shtCustomerOrder.Cells[rowIndex, i].Value);
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
                    shtCustomerOrder.Cells[rowIndex, (int)m_mapCellValue[i].Key].Value = m_mapCellValue[i].Value;
                }
            }
        }
        #endregion

        #region Keyboard Spread
        void m_keyboardSpread_RowAdded(object sender, int rowIndex)
        {

            // Unlock cells
                //CtrlUtil.SpreadSetCellLocked(shtCustomerOrder, true, rowIndex, (int)eColCustomerOrder.PO_NO);
                //CtrlUtil.SpreadSetCellLocked(shtCustomerOrder, true, rowIndex, (int)eColCustomerOrder.ORDER_NO);
                //CtrlUtil.SpreadSetCellLocked(shtCustomerOrder, true, rowIndex, (int)eColCustomerOrder.ITEM_CD);
                //CtrlUtil.SpreadSetCellLocked(shtCustomerOrder, true, rowIndex, (int)eColCustomerOrder.SHORT_NAME);
                //CtrlUtil.SpreadSetCellLocked(shtCustomerOrder, true, rowIndex, (int)eColCustomerOrder.ITEM_DELIVERY_DATE);
                //CtrlUtil.SpreadSetCellLocked(shtCustomerOrder, true, rowIndex, (int)eColCustomerOrder.REMAIN_QTY);
                //CtrlUtil.SpreadSetCellLocked(shtCustomerOrder, true, rowIndex, (int)eColCustomerOrder.SHIP_QTY);
                //CtrlUtil.SpreadSetCellLocked(shtCustomerOrder, true, rowIndex, (int)eColCustomerOrder.PRICE);
                //CtrlUtil.SpreadSetCellLocked(shtCustomerOrder, true, rowIndex, (int)eColCustomerOrder.AMOUNT);
                //CtrlUtil.SpreadSetCellLocked(shtCustomerOrder, false, rowIndex, (int)eColCustomerOrder.ChoosePart);
            CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColView.PO_NO);
            CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColView.ORDER_NO);
            CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColView.ORDER_DETAIL_NO);
            CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColView.ITEM_CD);
            CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColView.SHORT_NAME);
            CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, false, (int)eColView.ITEM_DESC);
            CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, false, (int)eColView.UNIT);
            CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, false, (int)eColView.QTY);
            CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, false, (int)eColView.PRICE);
            CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, false, (int)eColView.AMOUNT);

            //shtCustomerOrder.Cells[rowIndex, (int)eColView.ISSUE_QTY].Value = 0;
            //shtCustomerOrder.Cells[rowIndex, (int)eColView.ONHAND_QTY].Value = 0;
            //// DEFAULT LOT VALUE
            //if (dtShipDate.Value.HasValue)
            //    shtCustomerOrder.Cells[shtCustomerOrder.Rows.Count - 1, (int)eColView.LOT_NO].Value = dtShipDate.Value.Value.ToString(DataDefine.LOT_NO_FORMAT);
        }

        /// <summary>
        /// Validate spread row.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="forceValidate">force to validate.</param>
        /// <returns></returns>
        private bool ValidateRowSpread(int row, bool forceValidate)
        {
            if (!forceValidate && !m_bRowHasModified)
                return true;

            //Check item
            string itemCode = shtCustomerOrder.Cells[row, (int)eColView.ITEM_CD].Text;

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
            //NZDecimal qty = new NZDecimal(null, shtCustomerOrder.Cells[row, (int)eColView.ISSUE_QTY].Value);
            //if (qty.IsNull || qty.StrongValue == decimal.Zero)
            //{
            //    ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0039.ToString());
            //    MessageDialog.ShowBusiness(this, error.Message);
            //    return false;
            //}

            //NZDecimal onhandqty = new NZDecimal(null, shtCustomerOrder.Cells[row, (int)eColView.ONHAND_QTY].Value);
            //if (onhandqty.IsNull || onhandqty.StrongValue == decimal.Zero)
            //{
            //    onhandqty.Value = 0;
            //}
            //if (qty.StrongValue > onhandqty.StrongValue)
            //{
            //    ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0040.ToString());
            //    MessageDialog.ShowBusiness(this, error.Message);
            //    return false;
            //}

            // ถ้า Validate Row ผ่าน แสดงว่า แถวนั้นไม่จำเป็นต้องเช็คอีกรอบ
            m_bRowHasModified = false;
            return true;
        }

        void m_keyboardSpread_RowAdding(object sender, EventRowAdding e)
        {
            if (m_bRowHasModified)
            { // ถ้า Row กำลังแก้ไขอยู่
                if (!ValidateRowSpread(shtCustomerOrder.ActiveRowIndex, false))
                {
                    e.Cancel = true;
                    return;
                }
            }
            else
            {
                // ถ้าไม่มีการแก้ไข Row  แต่ก่อนที่จะเพิ่มแถวใหม่ จะต้อง Validate แถวล่าสุด (ล่างสุด) ก่อน
                if (shtCustomerOrder.RowCount > 0 && shtCustomerOrder.ActiveRowIndex >= 0)
                {
                    if (!ValidateRowSpread(shtCustomerOrder.RowCount - 1, true))
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
        }

        void m_keyboardSpread_RowRemoved(object sender)
        {
            m_bRowHasModified = false;
        }
        #endregion

        #region Spread trigger.

        private void fpView_EditModeOn(object sender, EventArgs e)
        {
            // ถ้าเป็นการแก้ไข Cell ใน Row เดียวกัน เป็นครั้งแรก
            if (!m_bRowHasModified)
            {
                m_bRowHasModified = true;
                StoreCellValues(shtCustomerOrder.ActiveRowIndex);
            }
        }

        private void fpShipList_EditModeOff(object sender, EventArgs e)
        {
            eColView eActiveCol = (eColView)shtCustomerOrder.ActiveColumnIndex;
            int ActiveRow = shtCustomerOrder.ActiveRowIndex;

            /*NZString ItemCD = new NZString(null, shtCustomerOrder.Cells[ActiveRow, (int)eColView.PART_NO].Value);
            NZString LotNo = new NZString(null, shtCustomerOrder.Cells[ActiveRow, (int)eColView.LOT_NO].Value);
            NZString PackNo = new NZString(null, shtCustomerOrder.Cells[ActiveRow, (int)eColView.PACK_NO].Value);


            switch (eActiveCol)
            {
                case eColView.PART_NO:
                    // check item cd
                    //if (ItemCD.StrongValue == m_SelectedDataRow.ITEM_CODE.StrongValue)
                    //{
                    //    break;
                    //}
                    if (CheckFromSpread_ItemCD(ActiveRow))
                    {
                        // do something if item found



                        // Load Lot control
                        LookupDataBIZ bizLookup = new LookupDataBIZ();

                        // Load Onhand qty


                        // re sort spread by item code
                        //shtCustomerOrder.SortRows((int)eColView.PART_NO, true, true);
                    }
                    else
                    {
                        shtCustomerOrder.SetActiveCell(ActiveRow, shtCustomerOrder.ActiveColumnIndex);
                    }
                    break;
            }*/
        }

        private void fpShipList_LeaveCell(object sender, LeaveCellEventArgs e)
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

        private void fpShipList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                if (m_bRowHasModified)
                {
                    int lastRowNonEmpty = shtCustomerOrder.GetLastNonEmptyRow(NonEmptyItemFlag.Data);
                    if (lastRowNonEmpty != shtCustomerOrder.RowCount - 1)
                    {
                        shtCustomerOrder.RemoveRows(shtCustomerOrder.RowCount - 1, 1);
                    }
                    else
                    {
                        RestoreCellValues(shtCustomerOrder.ActiveRowIndex);
                    }

                    m_bRowHasModified = false;
                }
                else
                {
                    RemoveRowUnused(shtCustomerOrder);
                }
            }
        }

        #endregion

        #region Form event
        private void TRN350_Load(object sender, EventArgs e)
        {
            InitializeDefaultValue();
            //InitialScreen();

        }
        #endregion

        #region Control event

        private void InitializeDefaultValue()
        {
            SysConfigBIZ sysBiz = new SysConfigBIZ();
            SysConfigDTO default_StoreLoc = sysBiz.LoadByPK(DataDefine.eSYSTEM_CONFIG.TRN100.SYS_GROUP_ID, (NZString)DataDefine.eSYSTEM_CONFIG.TRN100.SYS_KEY.FROM_LOC.ToString());

            InvoiceController ctrl = new InvoiceController();
            InvoiceEntryUIDM uidm = ctrl.CreateUIDMForAddMode();
            DataTable dt = uidm.DATA_VIEW;

            shtCustomerOrder.DataSource = dt;
            shtCustomerOrder.RowCount = 0;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (shtCustomerOrder.Rows.Count > 0)

            m_keyboardSpread.OnActionAddNewRow();
        }



        //private void dtShipDate_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar != (char)Keys.Return) return;
        //    txtInvoiceNo.Focus();
        //    txtInvoiceNo.SelectAll();
        //}

        //private void txtInvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar != (char)Keys.Return) return;
        //    cboFromLoc.Focus();
        //    cboFromLoc.SelectAll();
        //}

        //private void cboFromLoc_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar != (char)Keys.Return) return;
        //    txtRemark.Focus();
        //    txtRemark.SelectAll();
        //}

        private void txtRemark_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Return) return;
            //tslControl.Select();
            //tsbSaveAndNew.Select();
        }

        #endregion

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


        private void fpCustomerOrder_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {

                bool isClickOnCell = false;

                CellRange cellRange = fpCustomerOrder.GetCellFromPixel(0, 0, e.X, e.Y);
                if (cellRange.Column != -1 && cellRange.Row != -1)
                {
                    shtCustomerOrder.SetActiveCell(cellRange.Row, cellRange.Column);
                    shtCustomerOrder.AddSelection(cellRange.Row, cellRange.Column, 1, 1);
                    isClickOnCell = true;
                }

                if (isClickOnCell)
                {
                    //addToolStripMenuItem.Enabled = true;

                    deleteToolStripMenuItem.Enabled = true;

                    //if (Convert.ToDecimal(shtCustomerOrder.GetValue(cellRange.Row, (int)eColCustomerOrder.RETURN_QTY)) > 0)
                    //{
                    //    deleteToolStripMenuItem.Enabled = false;
                    //}
                    //else
                    //{
                    //    deleteToolStripMenuItem.Enabled = true;
                    //}

                    //NZString transID = new NZString(null, shtView.Cells[cellRange.Row, (int)eColView.TRANSACTION_ID].Value);
                    //bool canEditOrDelete = m_transactionValidator.TransactionCanEditOrDelete(transID);

                    //miDelete.Enabled = canEditOrDelete && ActivePermission.Delete;
                    //miDeleteGroup.Enabled = canEditOrDelete && ActivePermission.Delete;

                    //miEdit.Enabled = canEditOrDelete && ActivePermission.Edit;
                }
                else
                {
                    //addToolStripMenuItem.Enabled = false;
                    deleteToolStripMenuItem.Enabled = false;
                }

                //ctxMenu.Show(fpDelivery, e.Location);
            }
        }

        private void cboCustomerCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_Mode == Common.eScreenMode.ADD) InitializeDefaultValue();
        }

        public override void OnSaveFormat()
        {
            base.OnSaveFormat();

            SheetWidthController ctrl = new SheetWidthController();
            ctrl.SaveSheetWidth(shtCustomerOrder, this.ScreenCode);
        }

        public override void OnResetFormat()
        {
            base.OnResetFormat();

            SheetWidthController ctrl = new SheetWidthController();
            ctrl.ResetSheetWidth(shtCustomerOrder);
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
            ctrl.SetSheetWidth(shtCustomerOrder, this.ScreenCode);
        }

        private void TRN350_InvoiceEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void fpCustomerOrder_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }

        private void fpCustomerOrderDetail_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }

        private void btnDeliveryNo_Click(object sender, EventArgs e)
        {

        }

        private void txtDeliveryNo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (m_Mode != Common.eScreenMode.ADD || txtDeliveryNo.Text == "") return;
            InvoiceBIZ biz = new InvoiceBIZ();
            InvoiceController ctrl = new InvoiceController();
            List<InvoiceDTO> list = biz.Load_Delivery_Detail(txtDeliveryNo.Text);
            if (list.Count > 0)
            {
                dmcShip.LoadData(ctrl.MapDTOToUIDM(list[0]));
                shtCustomerOrder.DataSource = DTOUtility.ConvertListToDataTable<InvoiceDTO>(list);
            }
        }


        //private void dtShipDate_ValueChanged(object sender, EventArgs e)
        //{
        //    if (dtShipDate.Value.HasValue)
        //    {
        //        int row = shtCustomerOrder.Rows.Count;
        //        if (row > 0)
        //        {
        //            for (int i = 0; i < row; i++)
        //            {
        //                shtCustomerOrder.Cells[i, (int)eColView.LOT_NO].Value = dtShipDate.Value.Value.ToString(DataDefine.LOT_NO_FORMAT);
        //            }
        //        }
        //    }
        //}
    }
}
