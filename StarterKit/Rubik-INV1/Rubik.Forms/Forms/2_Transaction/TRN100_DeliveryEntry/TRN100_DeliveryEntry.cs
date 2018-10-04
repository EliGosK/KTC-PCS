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
using System.IO;
using SystemMaintenance;


namespace Rubik.Transaction
{
    [Screen("TRN100", "Delivery Entry", eShowAction.Normal, eScreenType.Screen, "Delivery Entry")]
    public partial class TRN100_DeliveryEntry : SystemMaintenance.Forms.CustomizeForm
    {
        #region Enum

        private enum eColView
        {
            OTHER_DL_NO,
            PART_NO,
            PART_NO_BTN,
            PART_NAME,
            LOT_NO,
            PACK_NO,
            LOT_BTN,
            ONHAND_QTY,
            ISSUE_QTY,
            TRANS_ID,
        }
        public enum eColumnsOrder
        {
            // *** OLD ***
            //EDIT_FLAG,
            //LOT_NO,
            //ON_HAND_QTY,
            //Shipment,
            //Location,
            //Item_NO,
            //Item_Name

            EDIT_FLAG,
            ORDER_DETAIL_NO,
            PRICE,
            AMOUNT,
            ORDER_NO,
            PO_NO,
            ITEM_CD,
            SHORT_NAME,
            ITEM_DELIVERY_DATE,
            QTY,
            REMAIN_QTY,
            RETURN_QTY,
            SHIP_QTY,
            //Location,
            //Item_NO,
            //Item_Name

        }
        public enum eColumnsOrderDetail
        {
            CHECK_FLAG,
            LAST_RECEIVE_DATE,
            PACK_NO,
            FG_NO,
            LOT_NO,
            EXTERNAL_LOT_NO,
            ONHAND_QTY,
            RETURN_QTY

        }
        public enum eColFG
        {
            TRANS_ID,
            LOT_NO,
            EXTERNAL_LOT_NO,
            QTY
        } ;
        public enum eColCustomerOrder
        {
            //PONo,
            //PONo_Btn,
            //CustomerOrder,
            //OrderDetailNo,
            //ItemCode,
            //ShortName,
            //DeliveryDate,
            //OrderRemainQty,
            //DeliveryQty,
            //Price,
            //Amount,
            //ChoosePart,

            PO_NO,
            ORDER_NO,
            ORDER_DETAIL_NO,
            ITEM_CD,
            SHORT_NAME,
            ITEM_DELIVERY_DATE,
            ORDER_QTY,
            REMAIN_QTY,
            SHIP_QTY,
            SHIP_QTY2,
            PRICE,
            AMOUNT,
            RETURN_QTY,
            ChoosePart,
        }

        public enum eColCustomerOrderDetail
        {
            //OrderNo,
            //OrderDetailNo,
            //ItemCode,
            //ShortName,
            //DeliveryDate,
            //PackNo,
            //LotNo,
            //CustomerLotNo,
            //LotQty

            REF_NO,
            REF_SLIP_NO,
            TRANS_ID,
            ITEM_CD,
            SHORT_NAME,
            TRANS_DATE,
            PACK_NO,
            FG_NO,
            LOT_NO,
            EXTERNAL_LOT_NO,
            PRICE,
            AMOUNT,
            QTY,
            RETURN_QTY

        }

        public enum eSaveMode
        {
            ADD, UPDATE, VIEW,
        }
        #endregion

        #region Variable

        private KeyboardSpread m_keyboardSpreadOrder;
        private KeyboardSpread m_keyboardSpreadDetail;
        private SelectedDataRow m_SelectedDataRow = new SelectedDataRow();
        private Common.eScreenMode m_Mode = Common.eScreenMode.ADD;
        private ShipmentEntryUIDM m_uidm = new ShipmentEntryUIDM();

        private DataTable TempDataOrder = new DataTable();
        private DataTable TempDataLot = new DataTable();

        private string m_strDefaultLocation = "FG.";
        private string m_strExportPath = "";

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
        public TRN100_DeliveryEntry(ShipmentEntryUIDM uidm)
        {
            InitializeComponent();
            m_uidm = uidm;

            SetScreenMode(Common.eScreenMode.EDIT);

            // Check can edit ?
            //TransactionValidator m_transactionValidator = new TransactionValidator();

            //if (m_transactionValidator.TransactionCanEditOrDelete(m_uidm.SLIP_NO))
            //{
            //    SetScreenMode(Common.eScreenMode.EDIT);
            //}
            //else
            //{

            //    SetScreenMode(Common.eScreenMode.VIEW);
            //}
        }
        public TRN100_DeliveryEntry()
        {
            InitializeComponent();
            SetScreenMode(Common.eScreenMode.ADD);
        }
        #endregion

        #region Initialize Screen
        private void InitialScreen()
        {
            InitialSpread();
            InitialComboBox();
            InitialFormat();
            dmcShip.AddControl(lblDeliveryNo);
            dmcShip.AddControl(dtDeliveryDate);
            dmcShip.AddControl(cboFromLoc);
            dmcShip.AddControl(txtRemark);
            dmcShip.AddControl(cboCustomerCode);
            dmcShip.AddControl(cboCurrency);
            dmcShip.AddControl(txtInvoiceNo);



            CtrlUtil.EnabledControl(false, lblDeliveryNo, txtAmount, txtQty);
            dtDeliveryDate.KeyPress += CtrlUtil.SetNextControl;
            cboCustomerCode.KeyPress += CtrlUtil.SetNextControl;
            cboCurrency.KeyPress += CtrlUtil.SetNextControl;
            cboFromLoc.KeyPress += CtrlUtil.SetNextControl;
            txtInvoiceNo.KeyPress += CtrlUtil.SetNextControl;
            txtRemark.KeyPress += CtrlUtil.SetNextControl;

            //ClearAllControl();

            if (m_Mode == Common.eScreenMode.ADD)
            {
                cboFromLoc.SelectedValue = m_strDefaultLocation;

                SysConfigBIZ sysBiz = new SysConfigBIZ();
                SysConfigDTO argScreenInfo = new SysConfigDTO();
                argScreenInfo.SYS_GROUP_ID = DataDefine.eSYSTEM_CONFIG.TRN100.SYS_GROUP_ID;
                argScreenInfo.SYS_KEY = (NZString)DataDefine.eSYSTEM_CONFIG.TRN100.SYS_KEY.DEFAULT_DATE.ToString();
                dtDeliveryDate.Value = sysBiz.GetDefaultDateForScreen(argScreenInfo);                
            }
            if (m_Mode != Common.eScreenMode.ADD)
            {
                dmcShip.LoadData(m_uidm);
                LoadShipList(m_uidm.SLIP_NO);
            }

            CheckCurrentInvPeriod();

            if (shtCustomerOrderDetail.RowCount > 0)
            {
                //string strTransID = shtCustomerOrderDetail.Cells[0, (int)eColCustomerOrderDetail.TRANS_ID].Text;
                //TransactionValidator m_transactionValidator = new TransactionValidator();
                //if (m_transactionValidator.TransactionCanEditOrDelete(strTransID.ToNZString()))

                bool bCanEdit = m_transactionValidator.DateIsInCurrentPeriod(m_uidm.TRANS_DATE.StrongValue) == null;
                if (bCanEdit)
                {
                    SetScreenMode(Common.eScreenMode.EDIT);
                }
                else
                {

                    SetScreenMode(Common.eScreenMode.VIEW);
                }
            }


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
            dtDeliveryDate.Format = Common.CurrentUserInfomation.DateFormatString;
            CommonLib.FormatUtil.SetNumberFormat(this.txtQty, FormatUtil.eNumberFormat.Total_Qty_PCS);
            CommonLib.FormatUtil.SetNumberFormat(this.txtAmount, FormatUtil.eNumberFormat.Amount);

            // Set Spread Format
            FormatUtil.SetDateFormat(shtCustomerOrder.Columns[(int)eColCustomerOrder.ITEM_DELIVERY_DATE]);
            FormatUtil.SetNumberFormat(shtCustomerOrder.Columns[(int)eColCustomerOrder.REMAIN_QTY], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtCustomerOrder.Columns[(int)eColCustomerOrder.SHIP_QTY], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtCustomerOrder.Columns[(int)eColCustomerOrder.PRICE], FormatUtil.eNumberFormat.UnitPrice);
            FormatUtil.SetNumberFormat(shtCustomerOrder.Columns[(int)eColCustomerOrder.AMOUNT], FormatUtil.eNumberFormat.Amount);

            FormatUtil.SetDateFormat(shtCustomerOrderDetail.Columns[(int)eColCustomerOrderDetail.TRANS_DATE]);
            FormatUtil.SetNumberFormat(shtCustomerOrderDetail.Columns[(int)eColCustomerOrderDetail.PRICE], FormatUtil.eNumberFormat.UnitPrice);
            FormatUtil.SetNumberFormat(shtCustomerOrderDetail.Columns[(int)eColCustomerOrderDetail.AMOUNT], FormatUtil.eNumberFormat.Amount);
            FormatUtil.SetNumberFormat(shtCustomerOrderDetail.Columns[(int)eColCustomerOrderDetail.QTY], FormatUtil.eNumberFormat.Qty_PCS);
        }
        private void LoadShipList(NZString SlipNo)
        {
            dmcShip.LoadData(m_uidm);
            DeliveryController ctl = new DeliveryController();
            shtCustomerOrder.RowCount = 0;
            TempDataOrder = ctl.Load_OrderList(SlipNo);
            DataTable dtOrder = TempDataOrder.Copy();
            shtCustomerOrder.DataSource = dtOrder;

            TempDataLot = ctl.Load_LotList(SlipNo);
            DataTable dtOrderDetail = TempDataLot.Copy();
            shtCustomerOrderDetail.RowCount = 0;
            shtCustomerOrderDetail.DataSource = dtOrderDetail;

            CalTotatValue();
            CalAmountEditMode();

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
            cboFromLoc.Format += Common.ComboBox_Format;
            cboCustomerCode.Format += Common.ComboBox_Format;
            cboCurrency.Format += Common.ComboBox_Format;

            LookupDataBIZ bizLookup = new LookupDataBIZ();
            // Lookup From Loc
            LookupData lookupLocationFrom = bizLookup.LoadLookupLocation(new NZString[] { (NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Production) });
            cboFromLoc.LoadLookupData(lookupLocationFrom);
            //cboFromLoc.SelectedValue = "FG";

            // Lookup To CustomerLocation
            LookupData lookupCustomer = bizLookup.LoadLookupLocation(new NZString[]{(NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Customer)
            ,(NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.CustomerVendor)});
            cboCustomerCode.LoadLookupData(lookupCustomer);
            cboCustomerCode.SelectedIndex = -1;

            // Lookup To Currency
            LookupData currencyData = bizLookup.LoadLookupClassType(DataDefine.CURRENCY.ToNZString());
            cboCurrency.LoadLookupData(currencyData);
            cboCurrency.SelectedIndex = -1;
        }

        private void InitialSpread()
        {
            shtCustomerOrder.ActiveSkin = Common.ACTIVE_SKIN;
            this.shtCustomerOrderDetail.ActiveSkin = Common.ACTIVE_SKIN;

            m_keyboardSpreadOrder = new KeyboardSpread(fpCustomerOrder);
            m_keyboardSpreadDetail = new KeyboardSpread(fpCustomerOrderDetail);

            fpCustomerOrder.SubEditorOpening += CtrlUtil.SpreadDisableSubEditorOpening;
            fpCustomerOrderDetail.SubEditorOpening += CtrlUtil.SpreadDisableSubEditorOpening;

            CtrlUtil.MappingDataFieldWithEnum(shtCustomerOrderDetail, typeof(eColCustomerOrderDetail));
            CtrlUtil.MappingDataFieldWithEnum(shtCustomerOrder, typeof(eColCustomerOrder));

            FormatUtil.SetNumberFormat(this.shtCustomerOrder.Columns[(int)eColCustomerOrder.ITEM_CD], FormatUtil.eNumberFormat.MasterNo);
            FormatUtil.SetNumberFormat(this.shtCustomerOrderDetail.Columns[(int)eColCustomerOrderDetail.ITEM_CD], FormatUtil.eNumberFormat.MasterNo);


            //m_keyboardSpread.IsBinded = true;
            //m_keyboardSpread.RowAdding += m_keyboardSpread_RowAdding;
            //m_keyboardSpread.RowAdded += m_keyboardSpread_RowAdded;
            //m_keyboardSpread.RowRemoved += m_keyboardSpread_RowRemoved;

            //m_keyboardSpread.IsBinded = true;
            //m_keyboardSpread.RowAdding += m_keyboardSpread_RowAdding;
            //m_keyboardSpread.RowAdded += m_keyboardSpread_RowAdded;
            //m_keyboardSpread.RowRemoved += m_keyboardSpread_RowRemoved;

            //CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColView.ONHAND_QTY);

            string[] name = Enum.GetNames(typeof(eColView));

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
            CtrlUtil.ClearControlData(txtRemark, cboCustomerCode, cboCurrency, txtInvoiceNo);
            //rdoShipType_Ship.Checked = true;
            shtCustomerOrder.Rows.Count = 0;
            if (shtCustomerOrder.DataSource != null)
            {
                DataTable dt = shtCustomerOrder.DataSource as DataTable;
                dt.Rows.Clear();
            }

            shtCustomerOrderDetail.Rows.Count = 0;
            if (shtCustomerOrderDetail.DataSource != null)
            {
                DataTable dt = shtCustomerOrderDetail.DataSource as DataTable;
                dt.Rows.Clear();
            }

            //m_SelectedDataRow = new SelectedDataRow();
        }

        private void ClearAllControlExceptDefault()
        {
            CtrlUtil.ClearControlData(txtRemark, cboCustomerCode, cboCurrency, txtInvoiceNo);
            shtCustomerOrder.Rows.Count = 0;
            if (shtCustomerOrder.DataSource != null)
            {
                DataTable dt = shtCustomerOrder.DataSource as DataTable;
                dt.Rows.Clear();
            }

            shtCustomerOrderDetail.Rows.Count = 0;
            if (shtCustomerOrderDetail.DataSource != null)
            {
                DataTable dt = shtCustomerOrderDetail.DataSource as DataTable;
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
                    CtrlUtil.EnabledControl(false, cboFromLoc);
                    CtrlUtil.EnabledControl(true, txtInvoiceNo);

                    shtCustomerOrder.OperationMode = OperationMode.Normal;
                    shtCustomerOrderDetail.OperationMode = OperationMode.Normal;

                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColCustomerOrder.PO_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColCustomerOrder.ORDER_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColCustomerOrder.ORDER_DETAIL_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColCustomerOrder.ITEM_CD);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColCustomerOrder.SHORT_NAME);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColCustomerOrder.ITEM_DELIVERY_DATE);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColCustomerOrder.ORDER_QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColCustomerOrder.REMAIN_QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColCustomerOrder.SHIP_QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColCustomerOrder.PRICE);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColCustomerOrder.AMOUNT);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColCustomerOrder.RETURN_QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, false, (int)eColCustomerOrder.ChoosePart);

                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.REF_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.REF_SLIP_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.TRANS_ID);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.ITEM_CD);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.SHORT_NAME);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.TRANS_DATE);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.PACK_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.FG_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.LOT_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.EXTERNAL_LOT_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.PRICE);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.AMOUNT);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.RETURN_QTY);

                    break;
                case Common.eScreenMode.EDIT:
                    CtrlUtil.EnabledControl(true, txtRemark, txtRemark);
                    CtrlUtil.EnabledControl(false, lblDeliveryNo
                        , cboFromLoc, cboCustomerCode
                        , dtDeliveryDate
                        , cboCurrency);

                    shtCustomerOrder.OperationMode = OperationMode.Normal;
                    shtCustomerOrderDetail.OperationMode = OperationMode.Normal;

                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColCustomerOrder.PO_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColCustomerOrder.ORDER_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColCustomerOrder.ORDER_DETAIL_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColCustomerOrder.ITEM_CD);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColCustomerOrder.SHORT_NAME);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColCustomerOrder.ITEM_DELIVERY_DATE);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColCustomerOrder.ORDER_QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColCustomerOrder.REMAIN_QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColCustomerOrder.SHIP_QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColCustomerOrder.PRICE);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColCustomerOrder.AMOUNT);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColCustomerOrder.RETURN_QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, false, (int)eColCustomerOrder.ChoosePart);

                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.REF_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.REF_SLIP_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.TRANS_ID);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.ITEM_CD);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.SHORT_NAME);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.TRANS_DATE);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.PACK_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.FG_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.LOT_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.EXTERNAL_LOT_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.PRICE);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.AMOUNT);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.RETURN_QTY);

                    break;
                case Common.eScreenMode.VIEW:
                    CtrlUtil.EnabledControl(false, lblDeliveryNo
                        , txtRemark, cboFromLoc, cboCurrency
                        , dtDeliveryDate, cboCustomerCode
                        , txtInvoiceNo);
                    CtrlUtil.EnabledControl(false, btnAddOrder);
                    shtCustomerOrder.OperationMode = OperationMode.ReadOnly;
                    shtCustomerOrderDetail.OperationMode = OperationMode.ReadOnly;

                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColCustomerOrder.PO_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColCustomerOrder.ORDER_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColCustomerOrder.ORDER_DETAIL_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColCustomerOrder.ITEM_CD);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColCustomerOrder.SHORT_NAME);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColCustomerOrder.ITEM_DELIVERY_DATE);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColCustomerOrder.ORDER_QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColCustomerOrder.REMAIN_QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColCustomerOrder.SHIP_QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColCustomerOrder.PRICE);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColCustomerOrder.AMOUNT);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColCustomerOrder.RETURN_QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrder, true, (int)eColCustomerOrder.ChoosePart);

                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.REF_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.REF_SLIP_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.TRANS_ID);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.ITEM_CD);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.SHORT_NAME);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.TRANS_DATE);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.PACK_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.FG_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.LOT_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.EXTERNAL_LOT_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.PRICE);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.AMOUNT);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderDetail, true, (int)eColCustomerOrderDetail.RETURN_QTY);

                    fpCustomerOrder.ContextMenuStrip = null;
                    fpCustomerOrderDetail.ContextMenuStrip = null;

                    tsbSaveAndClose.Enabled = false;
                    tsbSaveAndNew.Enabled = false;
                    shtCustomerOrder.OperationMode = OperationMode.ReadOnly;
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
        private void CalculateOldInventoryOnhand()
        {
            if (m_uidm.DATA_VIEW == null || m_uidm.DATA_VIEW.Rows.Count == 0) return;
            int row = m_uidm.DATA_VIEW.Rows.Count;
            for (int i = 0; i < row; i++)
            {
                if (m_uidm.TRANS_CLS.StrongValue == DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Shipment))
                {
                    m_uidm.DATA_VIEW.Rows[i][eColView.ONHAND_QTY.ToString()] =
                        Convert.ToDouble(m_uidm.DATA_VIEW.Rows[i][eColView.ONHAND_QTY.ToString()]) +
                        Convert.ToDouble(m_uidm.DATA_VIEW.Rows[i][eColView.ISSUE_QTY.ToString()]);
                }
                else
                {
                    m_uidm.DATA_VIEW.Rows[i][eColView.ONHAND_QTY.ToString()] =
                       Convert.ToDouble(m_uidm.DATA_VIEW.Rows[i][eColView.ONHAND_QTY.ToString()]) -
                       Convert.ToDouble(m_uidm.DATA_VIEW.Rows[i][eColView.ISSUE_QTY.ToString()]);
                }
            }
            m_uidm.DATA_VIEW.AcceptChanges();
        }

        private bool ValidateMandatory()
        {
            if (!dtDeliveryDate.Value.HasValue)
            {
                ValidateException.ThrowErrorItem(new ErrorItem(null, TKPMessages.eValidate.VLM0105.ToString(), new object[] { "Delivery Date" }));
                return false;
            }
            if (cboCustomerCode.SelectedValue == null)
            {
                ValidateException.ThrowErrorItem(new ErrorItem(null, TKPMessages.eValidate.VLM0105.ToString(), new object[] { "Customer Code" }));
                return false;
            }
            if (cboCurrency.SelectedValue == null)
            {
                ValidateException.ThrowErrorItem(new ErrorItem(null, TKPMessages.eValidate.VLM0105.ToString(), new object[] { "Currency" }));
                return false;
            }

            // Validate Data before Save
            if (shtCustomerOrder.Rows.Count == 0)
            {
                ValidateException.ThrowErrorItem(new ErrorItem(null, TKPMessages.eValidate.VLM0190.ToString()));
            }

            if (shtCustomerOrderDetail.Rows.Count == 0)
            {
                ValidateException.ThrowErrorItem(new ErrorItem(null, TKPMessages.eValidate.VLM0190.ToString()));
            }
            if (!CheckChooseLotForOrder())
            {
                ValidateException.ThrowErrorItem(new ErrorItem(null, TKPMessages.eValidate.VLM0194.ToString()));
            }
            if (!CheckChooseLotOverRemain())
            {
                ValidateException.ThrowErrorItem(new ErrorItem(null, TKPMessages.eValidate.VLM0214.ToString()));
            }

            ShipEntryValidator valShip = new ShipEntryValidator();
            IssueEntryValidator valIssue = new IssueEntryValidator();
            InventoryOnhandValidator valINV = new InventoryOnhandValidator();
            TransactionValidator valTRN = new TransactionValidator();
            CommonBizValidator commonVal = new CommonBizValidator();
            ErrorItem errorItem;


            errorItem = valTRN.DateIsInCurrentPeriod(new NZDateTime(dtDeliveryDate, dtDeliveryDate.Value));
            if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

            errorItem = valShip.CheckShipDate(new NZDateTime(dtDeliveryDate, dtDeliveryDate.Value));
            if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

            errorItem = valShip.CheckEmptyLocCD(new NZString(cboFromLoc, cboFromLoc.SelectedValue));
            if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

            NZString LocCD = new NZString(cboFromLoc, cboFromLoc.SelectedValue);
            NZString YearMonth = new InventoryPeriodBIZ().LoadCurrentPeriod().YEAR_MONTH;

            for (int i = 0; i < shtCustomerOrder.Rows.Count; i++)
            {
                NZDecimal ShipQty = new NZDecimal(null, shtCustomerOrder.Cells[i, (int)eColCustomerOrder.SHIP_QTY].Value);

                NZString ItemCD = new NZString(null, shtCustomerOrder.Cells[i, (int)eColView.PART_NO].Value);
                NZString LotNo = new NZString(null, shtCustomerOrder.Cells[i, (int)eColView.LOT_NO].Value);
                NZString TransID = new NZString(null, shtCustomerOrder.Cells[i, (int)eColView.TRANS_ID].Value);

                //if (rdoShipType_Ship.Checked)
                //{
                //    //if (m_Mode == Common.eScreenMode.ADD || TransID.IsNull)
                //    //    errorItem = valINV.CheckOnhandQty(ShipQty, ItemCD, LocCD, LotNo);
                //    //else
                //    //{
                //    //    InventoryTransBIZ bizTrans = new InventoryTransBIZ();
                //    //    InventoryTransactionDTO dtoTran = bizTrans.LoadByTransactionID(TransID);
                //    //    NZDecimal oldOnhandQty = (NZDecimal)(dtoTran.QTY.StrongValue + GetOnhandQty(ItemCD, LocCD, LotNo));
                //    //    errorItem = new IssueEntryValidator().CheckOnhandQtyForEditMode(ShipQty, oldOnhandQty, ItemCD, LocCD);
                //    //}
                //    if (null != errorItem)
                //    {

                //        NZDateTime dd = new NZDateTime();

                //        fpShipList.Select();
                //        shtCustomerOrder.AddSelection(i, (int)eColView.ONHAND_QTY, 1, shtCustomerOrder.Columns.Count);

                //        ValidateException.ThrowErrorItem(errorItem);
                //    }


                //    errorItem = commonVal.CheckInputLot(ItemCD, LocCD, LotNo, true);
                //    if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);
                //    //errorItem = valIssue.CheckLotNo()
                //}
            }
            return true;
        }

        /// <summary>
        /// check item code and load item desc to spread if item exist
        /// </summary>
        /// <returns></returns>
        private bool CheckFromSpread_ItemCD(int ActiveRow)
        {
            NZString ItemCD = new NZString(null,
                                           shtCustomerOrder.Cells[ActiveRow, (int)eColView.PART_NO].
                                               Text);
            NZString LotNo = new NZString(null, shtCustomerOrder.Cells[ActiveRow, (int)eColView.LOT_NO].Value);
            NZString LocCD = new NZString(cboFromLoc, cboFromLoc.SelectedValue);
            NZString PackNo = new NZString(null, shtCustomerOrder.Cells[ActiveRow, (int)eColView.PACK_NO].Value);

            ItemBIZ bizItem = new ItemBIZ();
            ItemDTO dtoItem = bizItem.LoadItem(ItemCD);
            if (dtoItem != null)
            {

                shtCustomerOrder.Cells[ActiveRow, (int)eColView.PART_NO].Value = dtoItem.ITEM_CD.StrongValue;
                shtCustomerOrder.Cells[ActiveRow, (int)eColView.PART_NAME].Value = dtoItem.ITEM_DESC.StrongValue;
                shtCustomerOrder.Cells[ActiveRow, (int)eColView.ONHAND_QTY].Value = GetOnhandQty(ItemCD, LocCD, LotNo, PackNo);
                return true;
            }
            shtCustomerOrder.Cells[ActiveRow, (int)eColView.PART_NAME].Value = null;
            shtCustomerOrder.Cells[ActiveRow, (int)eColView.LOT_NO].Value = null;
            shtCustomerOrder.Cells[ActiveRow, (int)eColView.ONHAND_QTY].Value = 0;

            MessageDialog.ShowBusiness(this,
                                       Message.LoadMessage(TKPMessages.eValidate.VLM0009.ToString()).MessageDescription);
            return false;
        }

        private decimal GetOnhandQty(NZString ItemCD, NZString LocCD, NZString LotNo, NZString PackNo)
        {
            // get Onhand Qty
            //NZString YearMonth = new NZString(null, dtIssueDate.Value.Value.ToString("yyyyMM"));

            InventoryBIZ bizInv = new InventoryBIZ();
            InventoryOnhandDTO dto =
                bizInv.LoadInventoryOnHandOfDate(new NZDateTime(dtDeliveryDate, dtDeliveryDate.Value)
                                                 , ItemCD, LocCD, LotNo, PackNo);
            if (dto != null)
                return dto.ON_HAND_QTY.StrongValue;
            return 0;
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
                //object o = shtCustomerOrder.Cells[lastRowNonEmpty, (int)eColCustomerOrder.SHORT_NAME].Value;

                //if (o == null || o == DBNull.Value)
                //{
                //    shtCustomerOrder.RemoveRows(lastRowNonEmpty, 1);
                //}
            }
        }


        private bool SaveData()
        {
            ShipmentEntryController ctlShip = new ShipmentEntryController();
            NZString Group_Trans_ID = m_uidm.GROUP_TRANS_ID;
            ShipmentEntryUIDM uidm = dmcShip.SaveData(new ShipmentEntryUIDM());
            if (m_Mode != Common.eScreenMode.ADD) uidm.GROUP_TRANS_ID = Group_Trans_ID;
            uidm.DATA_VIEW = (DataTable)shtCustomerOrderDetail.DataSource;

            DataTable NewOrder = new DataTable();
            NewOrder = ((DataTable)shtCustomerOrder.DataSource).Copy();
            NewOrder.AcceptChanges();

            DataTable NewLot = new DataTable();
            NewLot = ((DataTable)shtCustomerOrderDetail.DataSource).Copy();
            NewLot.AcceptChanges();

            ExportData(ctlShip.SaveShipmentEntry(uidm, m_Mode, TempDataOrder, NewOrder, TempDataLot, NewLot));

            //ExportData(NZString SlipNo)

            //if (m_Mode == Common.eScreenMode.ADD && CheckChooseLotForOrder())
            //{
            //    for (int i = 0; i < shtCustomerOrder.RowCount;i++)
            //    {
            //        NZString strOrderDetailNo = shtCustomerOrder.GetValue(i,(int)eColCustomerOrder.ORDER_DETAIL_NO).ToString().ToNZString();
            //        decimal dQTY = Convert.ToDecimal(shtCustomerOrder.GetValue(i,(int)eColCustomerOrder.SHIP_QTY));
            //        if (dQTY == null || dQTY <= 0) continue;
            //        ctlShip.UpdateShipQTY(strOrderDetailNo, dQTY);
            //    }
            //}
            return true;
        }

        private bool CheckChooseLotForOrder()
        {
            bool result = true;

            for (int i = 0; i < shtCustomerOrder.RowCount; i++)
            {
                bool chk = false;
                for (int j = 0; j < shtCustomerOrderDetail.RowCount; j++)
                {
                    if (shtCustomerOrder.GetValue(i, (int)eColCustomerOrder.ORDER_DETAIL_NO).ToString() ==
                        shtCustomerOrderDetail.GetValue(j, (int)eColCustomerOrderDetail.REF_SLIP_NO).ToString())
                    {
                        chk = true;
                        continue;
                    }
                }
                if (!chk)
                {
                    shtCustomerOrder.Rows[i].BackColor = Color.Red;
                    result = false;
                }
                else
                {
                    shtCustomerOrder.Rows[i].ResetBackColor();
                    //if (i % 2 > 0) shtCustomerOrder.Rows[i].BackColor = Color.FromArgb(236, 247, 243);
                    //else shtCustomerOrder.Rows[i].BackColor = Color.White;
                }
            }
            return result;
        }
        private bool CheckChooseLotOverRemain()
        {
            bool result = true;

            for (int i = 0; i < shtCustomerOrder.RowCount; i++)
            {
                if (shtCustomerOrder.GetValue(i, (int)eColCustomerOrder.RETURN_QTY) != null && Convert.ToDecimal(shtCustomerOrder.GetValue(i, (int)eColCustomerOrder.RETURN_QTY)) > 0)
                {
                    shtCustomerOrder.Rows[i].ResetBackColor();
                    //if (i % 2 > 0) shtCustomerOrder.Rows[i].BackColor = Color.FromArgb(236, 247, 243);
                    //else shtCustomerOrder.Rows[i].BackColor = Color.White;
                }
                else if ((Convert.ToDecimal(shtCustomerOrder.GetValue(i, (int)eColCustomerOrder.ORDER_QTY)) - Convert.ToDecimal(shtCustomerOrder.GetValue(i, (int)eColCustomerOrder.SHIP_QTY))) < 0)
                {
                    shtCustomerOrder.Rows[i].BackColor = Color.Red;
                    result = false;
                }
                else
                {
                    shtCustomerOrder.Rows[i].ResetBackColor();
                    //if (i % 2 > 0) shtCustomerOrder.Rows[i].BackColor = Color.FromArgb(236, 247, 243);
                    //else shtCustomerOrder.Rows[i].BackColor = Color.White;
                }
            }
            return result;
        }


        private void CalAmountEditMode()
        {
            for (int i = 0; i < shtCustomerOrder.RowCount; i++)
            {
                for (int j = 0; j < shtCustomerOrderDetail.RowCount; j++)
                {
                    //if (shtCustomerOrder.GetValue(i, (int)eColCustomerOrder.ITEM_CD) == null || shtCustomerOrderDetail.GetValue(j, (int)eColCustomerOrderDetail.ITEM_CD) == null) continue;
                    if (shtCustomerOrder.GetValue(i, (int)eColCustomerOrder.ITEM_CD).ToString()
                        == shtCustomerOrderDetail.GetValue(j, (int)eColCustomerOrderDetail.ITEM_CD).ToString())
                    {
                        shtCustomerOrderDetail.Cells[j, (int)eColCustomerOrderDetail.PRICE].Value = shtCustomerOrder.GetValue(i, (int)eColCustomerOrder.PRICE).ToString();
                        shtCustomerOrderDetail.Cells[j, (int)eColCustomerOrderDetail.AMOUNT].Value
                            = Convert.ToDecimal(shtCustomerOrderDetail.Cells[j, (int)eColCustomerOrderDetail.PRICE].Value) * Convert.ToDecimal(shtCustomerOrderDetail.Cells[j, (int)eColCustomerOrderDetail.QTY].Value);
                    }
                }
            }
        }

        private void CalTotatValue()
        {
            decimal TotalQTY = 0;
            decimal TotalAmount = 0;
            for (int i = 0; i < shtCustomerOrderDetail.RowCount; i++)
            {
                TotalQTY += Convert.ToDecimal(shtCustomerOrderDetail.GetValue(i, (int)eColCustomerOrderDetail.QTY));
                TotalAmount += Convert.ToDecimal(shtCustomerOrderDetail.GetValue(i, (int)eColCustomerOrderDetail.AMOUNT));
            }
            txtQty.Decimal = TotalQTY;
            txtAmount.Decimal = TotalAmount;
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

                this.fpCustomerOrderDetail.StopCellEditing();
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
                CtrlUtil.SpreadSheetRowEndEdit(shtCustomerOrderDetail, shtCustomerOrderDetail.ActiveRowIndex);

                RemoveRowUnused(shtCustomerOrder);
                RemoveRowUnused(shtCustomerOrderDetail);

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

                    if (m_strExportPath != "")
                    {
                        DialogResult dialog = MessageBox.Show("Do you want to open file now ?", "Export Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                        if (dialog == DialogResult.Yes)
                        {
                            if (File.Exists(m_strExportPath))
                            {
                                System.Diagnostics.Process.Start(m_strExportPath);
                            }
                        }
                    }
                    //MessageDialog.ShowInformation(this, null, new EVOFramework.Message(Messages.eInformation.INF9003.ToString()).MessageDescription);



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

                this.fpCustomerOrderDetail.StopCellEditing();
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
                CtrlUtil.SpreadSheetRowEndEdit(shtCustomerOrderDetail, shtCustomerOrderDetail.ActiveRowIndex);

                RemoveRowUnused(shtCustomerOrder);
                RemoveRowUnused(shtCustomerOrderDetail);

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
                    lblDeliveryNo.Text = "";

                    SysConfigBIZ sysBiz = new SysConfigBIZ();
                    SysConfigDTO argScreenInfo = new SysConfigDTO();
                    argScreenInfo.SYS_GROUP_ID = DataDefine.eSYSTEM_CONFIG.TRN100.SYS_GROUP_ID;
                    argScreenInfo.SYS_KEY = (NZString)DataDefine.eSYSTEM_CONFIG.TRN100.SYS_KEY.DEFAULT_DATE.ToString();
                    dtDeliveryDate.Value = sysBiz.GetDefaultDateForScreen(argScreenInfo);

                    CtrlUtil.EnabledControl(true, txtRemark, dtDeliveryDate, cboCustomerCode, cboCurrency);
                    dtDeliveryDate.Focus();
                    dtDeliveryDate.Select();

                    if (m_strExportPath != "")
                    {
                        DialogResult dialog = MessageBox.Show("Do you want to open file now ?", "Export Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                        if (dialog == DialogResult.Yes)
                        {
                            if (File.Exists(m_strExportPath))
                            {
                                System.Diagnostics.Process.Start(m_strExportPath);
                            }
                        }
                    }
                    //MessageDialog.ShowInformation(this, null, new EVOFramework.Message(Messages.eInformation.INF9003.ToString()).MessageDescription);


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
            CtrlUtil.SpreadSetCellLocked(shtCustomerOrder, true, rowIndex, (int)eColCustomerOrder.PO_NO);
            CtrlUtil.SpreadSetCellLocked(shtCustomerOrder, true, rowIndex, (int)eColCustomerOrder.ORDER_NO);
            CtrlUtil.SpreadSetCellLocked(shtCustomerOrder, true, rowIndex, (int)eColCustomerOrder.ITEM_CD);
            CtrlUtil.SpreadSetCellLocked(shtCustomerOrder, true, rowIndex, (int)eColCustomerOrder.SHORT_NAME);
            CtrlUtil.SpreadSetCellLocked(shtCustomerOrder, true, rowIndex, (int)eColCustomerOrder.ITEM_DELIVERY_DATE);
            CtrlUtil.SpreadSetCellLocked(shtCustomerOrder, true, rowIndex, (int)eColCustomerOrder.REMAIN_QTY);
            CtrlUtil.SpreadSetCellLocked(shtCustomerOrder, true, rowIndex, (int)eColCustomerOrder.SHIP_QTY);
            CtrlUtil.SpreadSetCellLocked(shtCustomerOrder, true, rowIndex, (int)eColCustomerOrder.PRICE);
            CtrlUtil.SpreadSetCellLocked(shtCustomerOrder, true, rowIndex, (int)eColCustomerOrder.AMOUNT);
            CtrlUtil.SpreadSetCellLocked(shtCustomerOrder, false, rowIndex, (int)eColCustomerOrder.ChoosePart);

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
            string itemCode = shtCustomerOrder.Cells[row, (int)eColCustomerOrder.ITEM_CD].Text;

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
        private void LoadItemIntoRow(int row, NZString ItemCD)
        {
            NZString LotNo = new NZString(null, shtCustomerOrder.Cells[row, (int)eColView.LOT_NO].Value);
            NZString PackNo = new NZString(null, shtCustomerOrder.Cells[row, (int)eColView.PACK_NO].Value);
            NZString LocCD = new NZString(cboFromLoc, cboFromLoc.SelectedValue);

            // check item cd
            if (ItemCD.StrongValue == m_SelectedDataRow.ITEM_CODE.StrongValue)
            {
                return;
            }

            shtCustomerOrder.Cells[row, (int)eColView.PART_NO].Value = ItemCD.Value;
            if (CheckFromSpread_ItemCD(row))
            {
                // do something if item found
                // Lookup Lot No
                LookupLotNo(row, ItemCD, LocCD);
                // Load Onhand qty
                shtCustomerOrder.Cells[row, (int)eColView.ONHAND_QTY].Value = GetOnhandQty(ItemCD, LocCD, LotNo, PackNo);

                // re sort spread by item code
                //shtCustomerOrder.SortRows((int)eColView.PART_NO, true, true);
            }
        }

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

            NZString ItemCD = new NZString(null, shtCustomerOrder.Cells[ActiveRow, (int)eColView.PART_NO].Value);
            NZString LotNo = new NZString(null, shtCustomerOrder.Cells[ActiveRow, (int)eColView.LOT_NO].Value);
            NZString PackNo = new NZString(null, shtCustomerOrder.Cells[ActiveRow, (int)eColView.PACK_NO].Value);


            NZString LocCD = new NZString(cboFromLoc, cboFromLoc.SelectedValue);

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

                        // Lookup Lot No
                        //LookupData lookupLotNo = bizLookup.LoadLookupLotNo(ItemCD, LocCD);
                        //shtCustomerOrder.Cells[ActiveRow, (int)eColView.LOT_NO].CellType =
                        //    this.CreateLotNoCellType(lookupLotNo);
                        LookupLotNo(ActiveRow, ItemCD, LocCD);
                        // Load Onhand qty
                        shtCustomerOrder.Cells[ActiveRow, (int)eColView.ONHAND_QTY].Value = GetOnhandQty(ItemCD, LocCD, LotNo, PackNo);

                        // re sort spread by item code
                        //shtCustomerOrder.SortRows((int)eColView.PART_NO, true, true);
                    }
                    else
                    {
                        shtCustomerOrder.SetActiveCell(ActiveRow, shtCustomerOrder.ActiveColumnIndex);
                    }
                    break;
                case eColView.LOT_NO:
                    // Load Onhand qty
                    shtCustomerOrder.Cells[ActiveRow, (int)eColView.ONHAND_QTY].Value = GetOnhandQty(ItemCD, LocCD, LotNo, PackNo);
                    break;
            }
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

        private void fpShipList_ButtonClicked(object sender, EditorNotifyEventArgs e)
        {
            NZString ItemCD = new NZString(null, shtCustomerOrder.Cells[e.Row, (int)eColView.PART_NO].Value);
            NZString LotNo = new NZString(null, shtCustomerOrder.Cells[e.Row, (int)eColView.LOT_NO].Value);
            NZString PackNo = new NZString(null, shtCustomerOrder.Cells[e.Row, (int)eColView.PACK_NO].Value);
            NZString LocCD = new NZString(cboFromLoc, cboFromLoc.SelectedValue);

            if (e.Column == (int)eColView.PART_NO_BTN)
            {
                ItemFindDialog dialog = null;

                dialog = new ItemFindDialog(eSqlOperator.In, null);
                dialog.ShowDialog(this);

                if (dialog.IsSelected)
                {
                    LoadItemIntoRow(e.Row, dialog.SelectedItem.ITEM_CD);
                }
            }
            else if (e.Column == (int)eColView.LOT_BTN)
            {
                NZString locCD = new NZString(null, cboFromLoc.SelectedValue);
                LotNoFindDialog dialog = new LotNoFindDialog(ItemCD, locCD);

                dialog.ShowDialog(this);
                if (dialog.IsSelected)
                {
                    shtCustomerOrder.Cells[e.Row, (int)eColView.LOT_NO].Value = dialog.SelectedLotNo.NVL(string.Empty);
                    LotNo = new NZString(null, shtCustomerOrder.Cells[e.Row, (int)eColView.LOT_NO].Value);

                    decimal decOnHand = GetOnhandQty(ItemCD, LocCD, LotNo, PackNo);
                    shtCustomerOrder.Cells[e.Row, (int)eColView.ONHAND_QTY].Value = decOnHand;
                    shtCustomerOrder.Cells[e.Row, (int)eColView.ISSUE_QTY].Value = decOnHand;
                    //txtLotNo_KeyPress(txtLotNo, new KeyPressEventArgs((char)Keys.Return));
                }
            }
        }
        #endregion

        #region Form event
        private void TRN100_Load(object sender, EventArgs e)
        {
            InitializeDefaultValue();
            InitialScreen();

        }
        #endregion

        #region Control event

        private void InitializeDefaultValue()
        {
            SysConfigBIZ sysBiz = new SysConfigBIZ();
            SysConfigDTO default_StoreLoc = sysBiz.LoadByPK(DataDefine.eSYSTEM_CONFIG.TRN100.SYS_GROUP_ID, (NZString)DataDefine.eSYSTEM_CONFIG.TRN100.SYS_KEY.FROM_LOC.ToString());

            m_strDefaultLocation = default_StoreLoc.CHAR_DATA.NVL("FG");

            DataTable dtCustomerOrder = new DataTable();
            dtCustomerOrder.Columns.Add("PO_NO");
            dtCustomerOrder.Columns.Add("PONo_Btn");
            dtCustomerOrder.Columns.Add("ORDER_NO");
            dtCustomerOrder.Columns.Add("ORDER_DETAIL_NO");
            dtCustomerOrder.Columns.Add("ITEM_CD");
            dtCustomerOrder.Columns.Add("SHORT_NAME");
            dtCustomerOrder.Columns.Add("ITEM_DELIVERY_DATE");
            dtCustomerOrder.Columns.Add("REMAIN_QTY");
            dtCustomerOrder.Columns.Add("SHIP_QTY");
            dtCustomerOrder.Columns.Add("PRICE");
            dtCustomerOrder.Columns.Add("AMOUNT");
            dtCustomerOrder.Columns.Add("ChoosePart");


            shtCustomerOrder.DataSource = dtCustomerOrder;
            shtCustomerOrder.RowCount = 0;
            //shtCustomerOrder.DataSource = null;

            DataTable dtCustomerOrderDetail = new DataTable();
            dtCustomerOrderDetail.Columns.Add("REF_NO");
            dtCustomerOrderDetail.Columns.Add("REF_SLIP_NO");
            dtCustomerOrderDetail.Columns.Add("TRANS_ID");
            dtCustomerOrderDetail.Columns.Add("ITEM_CD");
            dtCustomerOrderDetail.Columns.Add("SHORT_NAME");
            dtCustomerOrderDetail.Columns.Add("TRANS_DATE");
            dtCustomerOrderDetail.Columns.Add("PACK_NO");
            dtCustomerOrderDetail.Columns.Add("FG_NO");
            dtCustomerOrderDetail.Columns.Add("LOT_NO");
            dtCustomerOrderDetail.Columns.Add("EXTERNAL_LOT_NO");
            dtCustomerOrderDetail.Columns.Add("PRICE");
            dtCustomerOrderDetail.Columns.Add("AMOUNT");
            dtCustomerOrderDetail.Columns.Add("QTY");

            shtCustomerOrderDetail.DataSource = dtCustomerOrderDetail;
            shtCustomerOrderDetail.RowCount = 0;
            //shtCustomerOrderDetail.DataSource = null;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (shtCustomerOrder.Rows.Count > 0)

            m_keyboardSpreadOrder.OnActionAddNewRow();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (shtCustomerOrder.Rows.Count > 0)
            {
                // Clear Lot Spread when remove order
                this.fpCustomerOrderDetail.StopCellEditing();
                CtrlUtil.SpreadSheetRowEndEdit(shtCustomerOrderDetail, shtCustomerOrderDetail.ActiveRowIndex);
                string ItemCD = Convert.ToString(shtCustomerOrder.GetValue(shtCustomerOrder.ActiveRowIndex, (int)eColCustomerOrder.ITEM_CD));
                string OrderNo = Convert.ToString(shtCustomerOrder.GetValue(shtCustomerOrder.ActiveRowIndex, (int)eColCustomerOrder.ORDER_NO));
                string OrderDetailNo = Convert.ToString(shtCustomerOrder.GetValue(shtCustomerOrder.ActiveRowIndex, (int)eColCustomerOrder.ORDER_DETAIL_NO));
                int shtCustomerOrderDetailRows = shtCustomerOrderDetail.RowCount;
                for (int i = shtCustomerOrderDetailRows - 1; i >= 0; i--)
                {
                    if (Convert.ToString(shtCustomerOrderDetail.GetValue(i, (int)eColCustomerOrderDetail.ITEM_CD)) == ItemCD
                        && Convert.ToString(shtCustomerOrderDetail.GetValue(i, (int)eColCustomerOrderDetail.REF_NO)) == OrderNo
                        && Convert.ToString(shtCustomerOrderDetail.GetValue(i, (int)eColCustomerOrderDetail.REF_SLIP_NO)) == OrderDetailNo)
                        shtCustomerOrderDetail.RemoveRows(i, 1);
                }
                shtCustomerOrder.RemoveRows(shtCustomerOrder.ActiveRowIndex, 1);

                CalTotatValue();
            }
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

        private void cboFromLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update display onhand on grid.
            for (int i = 0; i < shtCustomerOrder.RowCount; i++)
            {
                try
                {
                    NZString itemCD = new NZString(null, shtCustomerOrder.Cells[i, (int)eColView.PART_NO].Value);
                    NZString lotNo = new NZString(null, shtCustomerOrder.Cells[i, (int)eColView.LOT_NO].Value);
                    NZString PackNo = new NZString(null, shtCustomerOrder.Cells[i, (int)eColView.PACK_NO].Value);
                    NZString locCD = new NZString(null, cboFromLoc.SelectedValue);

                    decimal onhand = GetOnhandQty(itemCD, locCD, lotNo, PackNo);
                    shtCustomerOrder.Cells[i, (int)eColView.ONHAND_QTY].Value = onhand;

                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
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

        private void btnLotMaintenance_Click(object sender, EventArgs e)
        {
            if (cboFromLoc.SelectedValue == null)
            {
                MessageDialog.ShowBusiness(this,
                    Message.LoadMessage(TKPMessages.eValidate.VLM0103.ToString()));
                return;
            }
            else
            {
                //ถ้าไม่มี row ให้ add ได้ แต่ถ้ามี row ให้ check ว่า row สุดท้ายไม่ใช่ blank
                if ((shtCustomerOrder.RowCount == 0) || (shtCustomerOrder.RowCount > 0 && ValidateRowSpread(shtCustomerOrder.RowCount - 1, true)))
                {
                    //RemoveRowUnused(shtCustomerOrder);

                    string strLocation = Convert.ToString(cboFromLoc.SelectedValue);
                    string strCustomer = Convert.ToString(cboCustomerCode.SelectedValue);

                    //TRN101_LotMaintenance f = new TRN101_LotMaintenance(strLocation, strCustomer);
                    //if (DialogResult.OK == f.ShowDialog())
                    //{
                    //    for (int i = 0; i < f.shtData.Rows.Count; i++)
                    //    {
                    //        if (Convert.ToBoolean(f.shtData.Cells[i, (int)eColumns.EDIT_FLAG].Value) == true)
                    //        {
                    //            int j = shtCustomerOrder.RowCount;
                    //            //shtCustomerOrder.RowCount++;
                    //            m_keyboardSpread.OnActionAddNewRow();
                    //            //shtCustomerOrder.Cells[j, (int)eColView.PART_NO].Value = f.ItemNo.ToString();
                    //            //shtCustomerOrder.Cells[j, (int)eColView.PART_NAME].Value = f.ItemName.ToString(); 
                    //            shtCustomerOrder.Cells[j, (int)eColView.LOT_NO].Value = f.shtData.Cells[i, (int)eColumns.LOT_NO].Value;
                    //            shtCustomerOrder.Cells[j, (int)eColView.ONHAND_QTY].Value = f.shtData.Cells[i, (int)eColumns.ON_HAND_QTY].Value;
                    //            shtCustomerOrder.Cells[j, (int)eColView.ISSUE_QTY].Value = f.shtData.Cells[i, (int)eColumns.Shipment].Value;

                    //        }
                    //    }
                    //}

                }
            }
        }

        private void btnOrderMaintenance_Click(object sender, EventArgs e)
        {
            //if (cboFromLoc.SelectedValue == null)
            //{
            //    MessageDialog.ShowBusiness(this,
            //        Message.LoadMessage(TKPMessages.eValidate.VLM0103.ToString()));
            //    return;
            //}
            if (cboCustomerCode.SelectedValue == null || cboCurrency.SelectedValue == null)
            {
                if (cboCustomerCode.SelectedValue == null && cboCurrency.SelectedValue == null)
                    MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0105.ToString(), new object[] { "Customer Code and Currency" }));
                else if (cboCustomerCode.SelectedValue == null)
                    MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0105.ToString(), new object[] { "Customer Code" }));
                else MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0105.ToString(), new object[] { "Currency" }));
                return;
            }
            else
            {
                ////ถ้าไม่มี row ให้ add ได้ แต่ถ้ามี row ให้ check ว่า row สุดท้ายไม่ใช่ blank
                //if ((shtCustomerOrder.RowCount == 0) || (shtCustomerOrder.RowCount > 0 && ValidateRowSpread(shtCustomerOrder.RowCount - 1, true)))
                //{
                //    //RemoveRowUnused(shtCustomerOrder);

                string strLocation = Convert.ToString(cboFromLoc.SelectedValue);
                string strCustomer = Convert.ToString(cboCustomerCode.SelectedValue);
                string strCurrency = Convert.ToString(cboCurrency.SelectedValue);

                TRN102_OrderSelection f = new TRN102_OrderSelection(strLocation, strCustomer, strCurrency, m_uidm.SLIP_NO, shtCustomerOrder);
                if (DialogResult.OK == f.ShowDialog())
                {
                    for (int i = 0; i < f.shtData.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(f.shtData.Cells[i, (int)eColumnsOrder.EDIT_FLAG].Value) == true)
                        {

                            //shtCustomerOrder.RowCount++;
                            m_keyboardSpreadOrder.StartBind();
                            m_keyboardSpreadOrder.OnActionAddNewRow();
                            int j = shtCustomerOrder.RowCount - 1;
                            shtCustomerOrder.Cells[j, (int)eColCustomerOrder.PO_NO].Value = f.shtData.Cells[i, (int)eColumnsOrder.PO_NO].Value;
                            shtCustomerOrder.Cells[j, (int)eColCustomerOrder.ORDER_NO].Value = f.shtData.Cells[i, (int)eColumnsOrder.ORDER_NO].Value;
                            shtCustomerOrder.Cells[j, (int)eColCustomerOrder.ORDER_DETAIL_NO].Value = f.shtData.Cells[i, (int)eColumnsOrder.ORDER_DETAIL_NO].Value;
                            shtCustomerOrder.Cells[j, (int)eColCustomerOrder.ITEM_CD].Value = f.shtData.Cells[i, (int)eColumnsOrder.ITEM_CD].Value;
                            shtCustomerOrder.Cells[j, (int)eColCustomerOrder.SHORT_NAME].Value = f.shtData.Cells[i, (int)eColumnsOrder.SHORT_NAME].Value;
                            shtCustomerOrder.Cells[j, (int)eColCustomerOrder.ITEM_DELIVERY_DATE].Value = f.shtData.Cells[i, (int)eColumnsOrder.ITEM_DELIVERY_DATE].Value;
                            shtCustomerOrder.Cells[j, (int)eColCustomerOrder.REMAIN_QTY].Value = f.shtData.Cells[i, (int)eColumnsOrder.REMAIN_QTY].Value;
                            shtCustomerOrder.Cells[j, (int)eColCustomerOrder.SHIP_QTY].Value = 0; // f.shtData.Cells[i, (int)eColumnsOrder.SHIP_QTY].Value;
                            shtCustomerOrder.Cells[j, (int)eColCustomerOrder.PRICE].Value = f.shtData.Cells[i, (int)eColumnsOrder.PRICE].Value;
                            shtCustomerOrder.Cells[j, (int)eColCustomerOrder.AMOUNT].Value = f.shtData.Cells[i, (int)eColumnsOrder.AMOUNT].Value;
                            shtCustomerOrder.Cells[j, (int)eColCustomerOrder.ORDER_QTY].Value = f.shtData.Cells[i, (int)eColumnsOrder.QTY].Value;
                            if (m_Mode == Common.eScreenMode.ADD) shtCustomerOrder.Cells[j, (int)eColCustomerOrder.RETURN_QTY].Value = 0;
                            else shtCustomerOrder.Cells[j, (int)eColCustomerOrder.RETURN_QTY].Value = f.shtData.Cells[i, (int)eColumnsOrder.RETURN_QTY].Value;
                            //shtCustomerOrder.Cells[j, (int)eColView.PART_NAME].Value = f.shtData.Cells[i, (int)eColumns.SHORT_NAME].Value;
                            //shtCustomerOrder.Cells[j, (int)eColView.LOT_NO].Value = f.shtData.Cells[i, (int)eColumns.LOT_NO].Value;
                            ////shtCustomerOrder.Cells[j, (int)eColView.ONHAND_QTY].Value = f.shtData.Cells[i, (int)eColumns.ON_HAND_QTY].Value;
                            //shtCustomerOrder.Cells[j, (int)eColView.ISSUE_QTY].Value = f.shtData.Cells[i, (int)eColumns.SHIP_QTY].Value;

                        }
                    }
                }

                //}
            }
        }

        private void fpCustomerOrder_ButtonClicked(object sender, EditorNotifyEventArgs e)
        {
            if (e.Column == (int)eColCustomerOrder.ChoosePart)
            {
                if (Convert.ToDecimal(shtCustomerOrder.GetValue(e.Row, (int)eColCustomerOrder.RETURN_QTY)) > 0)
                {
                    MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0202.ToString()));
                    return;
                }
                string ItemCode = shtCustomerOrder.GetValue(e.Row, (int)eColCustomerOrder.ITEM_CD).ToString();
                string ShortName = shtCustomerOrder.GetValue(e.Row, (int)eColCustomerOrder.SHORT_NAME) == null ? "" : shtCustomerOrder.GetValue(e.Row, (int)eColCustomerOrder.SHORT_NAME).ToString();
                string OrderNo = shtCustomerOrder.GetValue(e.Row, (int)eColCustomerOrder.ORDER_NO).ToString();
                string OrderDetailNo = shtCustomerOrder.GetValue(e.Row, (int)eColCustomerOrder.ORDER_DETAIL_NO).ToString();
                decimal Price = Convert.ToDecimal(shtCustomerOrder.GetValue(e.Row, (int)eColCustomerOrder.PRICE));
                decimal RemainQty = Convert.ToDecimal(shtCustomerOrder.GetValue(e.Row, (int)eColCustomerOrder.REMAIN_QTY));

                DataTable dt = new DataTable();

                dt.Columns.Add("REF_NO");
                dt.Columns.Add("REF_SLIP_NO");
                dt.Columns.Add("TRANS_ID");
                dt.Columns.Add("ITEM_CD");
                dt.Columns.Add("SHORT_NAME");
                dt.Columns.Add("TRANS_DATE");
                dt.Columns.Add("PACK_NO");
                dt.Columns.Add("FG_NO");
                dt.Columns.Add("LOT_NO");
                dt.Columns.Add("EXTERNAL_LOT_NO");
                dt.Columns.Add("PRICE");
                dt.Columns.Add("AMOUNT");
                dt.Columns.Add("QTY");

                for (int j = 0; j < shtCustomerOrderDetail.RowCount; j++)
                {
                    DataRow row = dt.NewRow();
                    row["REF_NO"] = shtCustomerOrderDetail.Cells[j, (int)eColCustomerOrderDetail.REF_NO].Value;
                    row["TRANS_ID"] = shtCustomerOrderDetail.Cells[j, (int)eColCustomerOrderDetail.TRANS_ID].Value;
                    row["REF_SLIP_NO"] = shtCustomerOrderDetail.Cells[j, (int)eColCustomerOrderDetail.REF_SLIP_NO].Value;
                    row["ITEM_CD"] = shtCustomerOrderDetail.Cells[j, (int)eColCustomerOrderDetail.ITEM_CD].Value;
                    row["SHORT_NAME"] = shtCustomerOrderDetail.Cells[j, (int)eColCustomerOrderDetail.SHORT_NAME].Value;
                    row["LOT_NO"] = shtCustomerOrderDetail.Cells[j, (int)eColCustomerOrderDetail.LOT_NO].Value;
                    row["EXTERNAL_LOT_NO"] = shtCustomerOrderDetail.Cells[j, (int)eColCustomerOrderDetail.EXTERNAL_LOT_NO].Value;
                    row["PRICE"] = shtCustomerOrderDetail.Cells[j, (int)eColCustomerOrderDetail.PRICE].Value;
                    row["AMOUNT"] = shtCustomerOrderDetail.Cells[j, (int)eColCustomerOrderDetail.AMOUNT].Value;
                    row["QTY"] = shtCustomerOrderDetail.Cells[j, (int)eColCustomerOrderDetail.QTY].Value;
                    dt.Rows.Add(row);   
                }

                //decimal Amount = Convert.ToDecimal(shtCustomerOrder.GetValue(e.Row, (int)eColCustomerOrder.AMOUNT));
                TRN103_FGSelection dialog = new TRN103_FGSelection(OrderNo, OrderDetailNo, cboFromLoc.SelectedValue.ToString(), ItemCode, ShortName, RemainQty, m_uidm.SLIP_NO, shtCustomerOrderDetail, dt);
                //TRN101_LotMaintenance dialog = new TRN101_LotMaintenance(OrderDetailNo, cboFromLoc.SelectedValue.ToString(), ItemCode, ShortName, RemainQty, m_uidm.SLIP_NO, shtCustomerOrderDetail);
                DialogResult dr = dialog.ShowDialog();
                decimal TotalQTY = 0;                
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    // Clear Lot Spread For Insert New row.
                    if (dialog.shtData.RowCount > 0)
                    {
                        for (int i = shtCustomerOrderDetail.RowCount - 1; i >= 0; i--)
                        {
                            if (shtCustomerOrderDetail.GetValue(i, (int)eColCustomerOrderDetail.REF_SLIP_NO) == null || shtCustomerOrderDetail.GetValue(i, (int)eColCustomerOrderDetail.REF_SLIP_NO).ToString() == "") continue;
                            if (shtCustomerOrderDetail.GetValue(i, (int)eColCustomerOrderDetail.REF_SLIP_NO).ToString() == OrderDetailNo
                                && shtCustomerOrderDetail.GetValue(i, (int)eColCustomerOrderDetail.ITEM_CD).ToString() == ItemCode)
                                shtCustomerOrderDetail.RemoveRows(i, 1);
                        }
                    }
                    // Fill Row
                    for (int i = 0; i < dialog.shtData.RowCount; i++)
                    {
                        //if (Convert.ToBoolean(dialog.shtData.Cells[i, (int)eColumnsOrderDetail.CHECK_FLAG].Value))
                        //{
                            m_keyboardSpreadDetail.StartBind();
                            m_keyboardSpreadDetail.OnActionAddNewRow();
                            int j = shtCustomerOrderDetail.RowCount - 1;
                            shtCustomerOrderDetail.Cells[j, (int)eColCustomerOrderDetail.REF_NO].Value = OrderNo;
                            shtCustomerOrderDetail.Cells[j, (int)eColCustomerOrderDetail.REF_SLIP_NO].Value = OrderDetailNo;
                            shtCustomerOrderDetail.Cells[j, (int)eColCustomerOrderDetail.ITEM_CD].Value = ItemCode;
                            shtCustomerOrderDetail.Cells[j, (int)eColCustomerOrderDetail.SHORT_NAME].Value = ShortName;
                            //shtCustomerOrderDetail.Cells[j, (int)eColCustomerOrderDetail.TRANS_DATE].Value = dialog.shtData.Cells[i, (int)eColumnsOrderDetail.LAST_RECEIVE_DATE].Value;
                            //shtCustomerOrderDetail.Cells[j, (int)eColCustomerOrderDetail.PACK_NO].Value = dialog.shtData.Cells[i, (int)eColumnsOrderDetail.PACK_NO].Value;
                            //shtCustomerOrderDetail.Cells[j, (int)eColCustomerOrderDetail.FG_NO].Value = dialog.shtData.Cells[i, (int)eColumnsOrderDetail.FG_NO].Value;
                            shtCustomerOrderDetail.Cells[j, (int)eColCustomerOrderDetail.LOT_NO].Value = dialog.shtData.Cells[i, (int)eColFG.LOT_NO].Value;
                            shtCustomerOrderDetail.Cells[j, (int)eColCustomerOrderDetail.EXTERNAL_LOT_NO].Value = dialog.shtData.Cells[i, (int)eColFG.EXTERNAL_LOT_NO].Value;
                            shtCustomerOrderDetail.Cells[j, (int)eColCustomerOrderDetail.PRICE].Value = Price;
                            shtCustomerOrderDetail.Cells[j, (int)eColCustomerOrderDetail.AMOUNT].Value = Price * Convert.ToDecimal(dialog.shtData.Cells[i, (int)eColFG.QTY].Value);
                            shtCustomerOrderDetail.Cells[j, (int)eColCustomerOrderDetail.QTY].Value = dialog.shtData.Cells[i, (int)eColFG.QTY].Value;
                            //shtCustomerOrderDetail.Cells[j, (int)eColCustomerOrderDetail.RETURN_QTY].Value = dialog.shtData.Cells[i, (int)eColumnsOrderDetail.RETURN_QTY].Value;
                            TotalQTY += Convert.ToDecimal(dialog.shtData.Cells[i, (int)eColFG.QTY].Value);
                        //}
                    }
                    decimal OrderQTY = Convert.ToDecimal(shtCustomerOrder.Cells[e.Row, (int)eColCustomerOrder.ORDER_QTY].Value);
                    decimal RemainQTY = Convert.ToDecimal(shtCustomerOrder.Cells[e.Row, (int)eColCustomerOrder.REMAIN_QTY].Value);
                    decimal PriceOrder = Convert.ToDecimal(shtCustomerOrder.Cells[e.Row, (int)eColCustomerOrder.PRICE].Value);

                    shtCustomerOrder.Cells[e.Row, (int)eColCustomerOrder.SHIP_QTY].Value = TotalQTY;
                    shtCustomerOrder.Cells[e.Row, (int)eColCustomerOrder.AMOUNT].Value = TotalQTY * PriceOrder;

                    CalTotatValue();
                }
            }
        }

        private void cboCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (shtCustomerOrder.RowCount <= 0) return;
            if (m_Mode == Common.eScreenMode.ADD) InitializeDefaultValue();
            //dmcShip.SaveData(m_uidm);
            //for (int i = 0; i < shtCustomerOrder.RowCount; i++)
            //{
            //    NZString ItemCD = shtCustomerOrder.GetValue(i, (int)eColCustomerOrder.ITEM_CD).ToString().ToNZString();
            //    NZString CurrencyCode = m_uidm.CURRENCY;
            //    NZDateTime dtReceiveDate = m_uidm.TRANS_DATE;
            //    decimal d_Amount = decimal.Parse(shtCustomerOrder.GetValue(i, (int)eColCustomerOrder.AMOUNT).ToString());
            //    SalesUnitPriceBIZ bizPrice = new SalesUnitPriceBIZ();
            //    // Load Price by Currency combobox and Cal New Amount Value
            //    SalesUnitPriceDTO dtoPrice = bizPrice.getSalesUnitPriceByEffectiveDate(ItemCD, CurrencyCode, dtReceiveDate);
            //    if (dtoPrice == null || dtoPrice.PRICE.IsNull)
            //    {
            //        shtCustomerOrder.Cells[i, (int)eColCustomerOrder.PRICE].Value = 0;
            //        shtCustomerOrder.Cells[i, (int)eColCustomerOrder.AMOUNT].Value = 0;
            //    }
            //    else
            //    {
            //        shtCustomerOrder.Cells[i, (int)eColCustomerOrder.PRICE].Value = dtoPrice.PRICE.StrongValue;
            //        shtCustomerOrder.Cells[i, (int)eColCustomerOrder.AMOUNT].Value = dtoPrice.PRICE.StrongValue * decimal.Parse(shtCustomerOrder.Cells[i, (int)eColCustomerOrder.REMAIN_QTY].Value.ToString());
            //    }
            //}
        }

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

                    if (Convert.ToDecimal(shtCustomerOrder.GetValue(cellRange.Row, (int)eColCustomerOrder.RETURN_QTY)) > 0)
                    {
                        deleteToolStripMenuItem.Enabled = false;
                    }
                    else
                    {
                        deleteToolStripMenuItem.Enabled = true;
                    }

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
            ctrl.SaveSheetWidth(shtCustomerOrderDetail, this.ScreenCode);
        }

        public override void OnResetFormat()
        {
            base.OnResetFormat();

            SheetWidthController ctrl = new SheetWidthController();
            ctrl.ResetSheetWidth(shtCustomerOrder);
            ctrl.ResetSheetWidth(shtCustomerOrderDetail);
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
            ctrl.SetSheetWidth(shtCustomerOrderDetail, this.ScreenCode);
        }

        private void TRN100_DeliveryEntry_FormClosed(object sender, FormClosedEventArgs e)
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

        private void ExportData(NZString SlipNo)
        {
            string strFileName = GenerateFileName("INV_" + SlipNo.StrongValue);

            string strTemplateFileName = @"Report\TRN090_Invoice_Template.xls";
            string strTemplatePath = Path.Combine(Application.StartupPath, strTemplateFileName);

            string strExportPath = SaveDialogUtil.GetBrowseFileDialogForExport(strFileName);

            if (!"".Equals(strExportPath))
            {
                DeliveryController ctrl = new DeliveryController();
                DataSet ds = new DataSet();
                ds.Tables.Add(ctrl.Load_Invoice(SlipNo));

                ExportUtil.Export(ds, strTemplatePath, strExportPath);

                m_strExportPath = strExportPath;

                //DialogResult dr = MessageBox.Show("Do you want to open file now ?", "Export Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                //if (dr != DialogResult.Yes)
                //{
                //    return;
                //}
                ////MessageDialog.ShowInformation(this, null, new EVOFramework.Message(Messages.eInformation.INF9003.ToString()).MessageDescription);

                //if (File.Exists(strExportPath))
                //{
                //    System.Diagnostics.Process.Start(strExportPath);
                //}
            }
        }

        private string GenerateFileName(string strReportID)
        {
            string strFilename = "";

            strFilename = strReportID + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";

            return strFilename;
        }

        private void fpCustomerOrder_CellClick(object sender, CellClickEventArgs e)
        {
            if (shtCustomerOrder.RowCount > 0)
            {
                string order_detail_no = shtCustomerOrder.GetValue(e.Row, (int)eColCustomerOrder.ORDER_DETAIL_NO).ToString();

                for (int i = 0; i < shtCustomerOrderDetail.RowCount; i++)
                {
                    if (shtCustomerOrderDetail.GetValue(i, (int)eColCustomerOrderDetail.REF_SLIP_NO).ToString() == order_detail_no)
                        shtCustomerOrderDetail.Rows[i].BackColor = Color.Orange;
                    else
                    {
                        shtCustomerOrderDetail.Rows[i].ResetBackColor();

                        //if (i % 2 > 0) shtCustomerOrderDetail.Rows[i].BackColor = Color.FromArgb(236, 247, 243);
                        //else shtCustomerOrderDetail.Rows[i].BackColor = Color.White;
                    }
                }
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
