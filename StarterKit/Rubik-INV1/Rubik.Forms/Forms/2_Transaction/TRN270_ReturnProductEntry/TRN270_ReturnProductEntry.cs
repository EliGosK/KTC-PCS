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


namespace Rubik.Transaction
{
    [Screen("TRN270", "Return Product Entry", eShowAction.Normal, eScreenType.Screen, "Return Product Entry")]
    public partial class TRN270_ReturnProductEntry : SystemMaintenance.Forms.CustomizeForm
    {
        #region Enum
        //public enum eScreenMode
        //{
        //    VIEW,
        //    ADD,
        //    EDIT,
        //}

        public enum eColView
        {
            PO_NO,
            SLIP_NO,
            TRANS_ID,
            GROUP_TRANS_ID,
            REF_NO,
            ORDER_NO,
            REF_SLIP_NO,
            ITEM_CD,
            SHORT_NAME,
            TRANS_DATE,
            PACK_NO,
            FG_NO,
            LOT_NO,
            EXTERNAL_LOT_NO,
            SHIP_QTY,
            RETURNABLE_QTY,
            QTY
        }

        public enum eColChooseOrder
        {
            EDIT_FLAG,
            SLIP_NO,
            GROUP_TRANS_ID,
            TRANS_ID,
            CURRENCY,
            ORDER_NO,
            ORDER_DETAIL_NO,
            PO_NO,
            ITEM_CD,
            SHORT_NAME,
            TRANS_DATE,
            PACK_NO,
            FG_NO,
            LOT_NO,
            EXTERNAL_LOT_NO,
            LOT_QTY,
            RETURNABLE_QTY
        }

        #endregion

        #region Variables
        private Common.eScreenMode m_screenMode = Common.eScreenMode.ADD;
        private NZString m_editReturnNo = null;
        private KeyboardSpread m_keyboardSpread = null;

        private readonly ReturnController m_controller = new ReturnController();
        private readonly InventoryTransBIZ m_bizInventoryTransaction = new InventoryTransBIZ();
        private readonly TransactionValidator m_transactionValidator = new TransactionValidator();

        private ReturnEntryUIDM m_model = new ReturnEntryUIDM();
        private DialogResult m_dialogResult = DialogResult.Cancel;
        private bool m_Skip_Validate_Return_QTY;
        //private ReceivingEntryUIDM m_uidm = new ReceivingEntryUIDM();

        private string m_strDefaultLocation = "RETURN";
        #endregion

        #region Constructor
        public TRN270_ReturnProductEntry()
        {
            InitializeComponent();
        }

        public TRN270_ReturnProductEntry(ReturnEntryUIDM uidm)
        {
            InitializeComponent();

            m_model = uidm;
            m_editReturnNo = uidm.SLIP_NO;
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
            InitializeSpread();
            InitialFormat();
            InitializeDefaultValue();

            m_keyboardSpread = new KeyboardSpread(fpReturnProductList);
            m_keyboardSpread.RowAdding += new KeyboardSpread.RowAddingHandler(m_keyboardSpread_RowAdding);
            m_keyboardSpread.RowAdded += new KeyboardSpread.RowAddedHandler(m_keyboardSpread_RowAdded);
            m_keyboardSpread.RowRemoving += new KeyboardSpread.RowRemovingHandler(m_keyboardSpread_RowRemoving);
            m_keyboardSpread.RowRemoved += new KeyboardSpread.RowRemovedHandler(m_keyboardSpread_RowRemoved);
            m_keyboardSpread.KeyPressF5 += new KeyboardSpread.KeyPressF5Handler(m_keyboardSpread_KeyPressF5);

            //CheckCurrentInvPeriod();
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
        private void InitialFormat()
        {
            // Set Control Format
            CommonLib.FormatUtil.SetDateFormat(this.dtReturnDate);

            // Set Spread Format
            FormatUtil.SetDateFormat(shtReturnProductList.Columns[(int)eColView.TRANS_DATE]);
            FormatUtil.SetNumberFormat(shtReturnProductList.Columns[(int)eColView.QTY], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtReturnProductList.Columns[(int)eColView.RETURNABLE_QTY], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtReturnProductList.Columns[(int)eColView.SHIP_QTY], FormatUtil.eNumberFormat.Qty_PCS);
        }
        private void InitializeComboBox()
        {
            this.cboReturnLoc.Format += Common.ComboBox_Format;
            this.cboCustomerCode.Format += Common.ComboBox_Format;

            //cboStoredLoc.Format += Common.ComboBox_Format;
            //cboSupplierCode.Format += Common.ComboBox_Format;
        }
        private void InitializeLookupData()
        {
            LookupDataBIZ biz = new LookupDataBIZ();
            LookupData locationLookup = biz.LoadLookupLocation();
            NZString[] CustomerType = new NZString[] {(NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.CustomerVendor),
                                                           (NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Customer)};
            LookupData CustomerLookup = biz.LoadLookupLocation(CustomerType);
            cboReturnLoc.LoadLookupData(locationLookup);
            cboReturnLoc.SelectedValue = "QC-H";
            cboCustomerCode.LoadLookupData(CustomerLookup);
            cboCustomerCode.SelectedIndex = -1;

            //LookupData umClsData = biz.LoadLookupClassType(DataDefine.UM_CLS.ToNZString());
            //shtView.Columns[(int)eColView.ORDER_UM_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(umClsData);
            //shtView.Columns[(int)eColView.INV_UM_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(umClsData);
        }
        private void InitializeSpread()
        {
            shtReturnProductList.ActiveSkin = Common.ACTIVE_SKIN;

            shtReturnProductList.Columns[(int)eColView.QTY].ForeColor = Color.Blue;
            //shtView.Columns[(int)eColView.ORDER_QTY].ForeColor = Color.Blue;
            //shtView.Columns[(int)eColView.LOT_NO].ForeColor = Color.Blue;
            //shtView.Columns[(int)eColView.SUPP_LOT_NO].ForeColor = Color.Blue;
            //shtView.Columns[(int)eColView.PRICE].ForeColor = Color.Blue;

            fpReturnProductList.SubEditorOpening += CtrlUtil.SpreadDisableSubEditorOpening;

            // Assign DataField.
            CtrlUtil.MappingDataFieldWithEnum(shtReturnProductList, typeof(eColView));
        }
        private void InitializeBindingControl()
        {
            dmcReturn.AddRangeControl(
                lblReturnNo,
                cboCustomerCode,
                cboReturnLoc,
                txtRemark,
                dtReturnDate
                );
        }
        private void InitializeSetKeyPress()
        {
            dtReturnDate.KeyPress += CtrlUtil.SetNextControl;
            cboCustomerCode.KeyPress += CtrlUtil.SetNextControl;
            cboReturnLoc.KeyPress += CtrlUtil.SetNextControl;
            txtRemark.KeyPress += CtrlUtil.SetNextControl;
        }

        private void InitializeDefaultValue()
        {
            SysConfigBIZ sysBiz = new SysConfigBIZ();
            SysConfigDTO default_StoreLoc = sysBiz.LoadByPK(DataDefine.eSYSTEM_CONFIG.TRN270.SYS_GROUP_ID, (NZString)DataDefine.eSYSTEM_CONFIG.TRN270.SYS_KEY.STORE_LOC.ToString());

            if (default_StoreLoc != null)
            {
                m_strDefaultLocation = default_StoreLoc.CHAR_DATA.NVL("RETURN");

                this.cboReturnLoc.SelectedValue = m_strDefaultLocation;
            }

        }


        #endregion

        #region Keyboard Spread
        void m_keyboardSpread_RowAdded(object sender, int rowIndex)
        {
            // Lock cells
            CtrlUtil.SpreadSetCellLocked(shtReturnProductList, false, rowIndex, (int)eColView.QTY);

            // Unlock cells
            CtrlUtil.SpreadSetCellLocked(shtReturnProductList, true, rowIndex, (int)eColView.PO_NO);
            CtrlUtil.SpreadSetCellLocked(shtReturnProductList, true, rowIndex, (int)eColView.ORDER_NO);
            CtrlUtil.SpreadSetCellLocked(shtReturnProductList, true, rowIndex, (int)eColView.ITEM_CD);
            CtrlUtil.SpreadSetCellLocked(shtReturnProductList, true, rowIndex, (int)eColView.SHORT_NAME);
            CtrlUtil.SpreadSetCellLocked(shtReturnProductList, true, rowIndex, (int)eColView.TRANS_DATE);
            CtrlUtil.SpreadSetCellLocked(shtReturnProductList, true, rowIndex, (int)eColView.PACK_NO);
            CtrlUtil.SpreadSetCellLocked(shtReturnProductList, true, rowIndex, (int)eColView.LOT_NO);
            CtrlUtil.SpreadSetCellLocked(shtReturnProductList, true, rowIndex, (int)eColView.EXTERNAL_LOT_NO);
            CtrlUtil.SpreadSetCellLocked(shtReturnProductList, true, rowIndex, (int)eColView.SHIP_QTY);
            CtrlUtil.SpreadSetCellLocked(shtReturnProductList, true, rowIndex, (int)eColView.RETURNABLE_QTY);
        }

        void m_keyboardSpread_RowAdding(object sender, EventRowAdding e)
        {
            if (m_bRowHasModified)
            { // ถ้า Row กำลังแก้ไขอยู่
                if (m_Skip_Validate_Return_QTY)
                {
                    return;
                }
                else if (!ValidateRowSpread(shtReturnProductList.ActiveRowIndex, false))
                {
                    e.Cancel = true;
                    return;
                }
            }
            else
            {
                // ถ้าไม่มีการแก้ไข Row  แต่ก่อนที่จะเพิ่มแถวใหม่ จะต้อง Validate แถวล่าสุด (ล่างสุด) ก่อน
                if (shtReturnProductList.RowCount > 0 && shtReturnProductList.ActiveRowIndex >= 0)
                {
                    if (m_Skip_Validate_Return_QTY)
                    {
                        return;
                    }
                    else if (!ValidateRowSpread(shtReturnProductList.RowCount - 1, true))
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
                    CtrlUtil.EnabledControl(false, dtReturnDate, cboCustomerCode, cboReturnLoc);
                    CtrlUtil.EnabledControl(false, txtRemark, fpReturnProductList);

                    CtrlUtil.EnabledControl(false, btnAddReturn);

                    tsbSaveAndNew.Enabled = false;
                    tsbSaveAndClose.Enabled = false;
                    shtReturnProductList.OperationMode = OperationMode.ReadOnly;

                    CtrlUtil.SpreadSetColumnsLocked(shtReturnProductList, true, (int)eColView.EXTERNAL_LOT_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtReturnProductList, true, (int)eColView.ITEM_CD);
                    CtrlUtil.SpreadSetColumnsLocked(shtReturnProductList, true, (int)eColView.LOT_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtReturnProductList, true, (int)eColView.ORDER_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtReturnProductList, true, (int)eColView.PACK_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtReturnProductList, true, (int)eColView.PO_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtReturnProductList, true, (int)eColView.QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtReturnProductList, true, (int)eColView.RETURNABLE_QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtReturnProductList, true, (int)eColView.SHIP_QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtReturnProductList, true, (int)eColView.SHORT_NAME);
                    CtrlUtil.SpreadSetColumnsLocked(shtReturnProductList, true, (int)eColView.TRANS_DATE);

                    fpReturnProductList.ContextMenuStrip = null;

                    break;
                case Common.eScreenMode.ADD:
                    CtrlUtil.EnabledControl(true, dtReturnDate, cboCustomerCode);
                    CtrlUtil.EnabledControl(true, txtRemark, fpReturnProductList);
                    CtrlUtil.EnabledControl(false, cboReturnLoc);

                    tsbSaveAndNew.Enabled = true;
                    tsbSaveAndClose.Enabled = true;
                    shtReturnProductList.OperationMode = OperationMode.Normal;

                    CtrlUtil.SpreadSetColumnsLocked(shtReturnProductList, true, (int)eColView.EXTERNAL_LOT_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtReturnProductList, true, (int)eColView.ITEM_CD);
                    CtrlUtil.SpreadSetColumnsLocked(shtReturnProductList, true, (int)eColView.LOT_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtReturnProductList, true, (int)eColView.ORDER_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtReturnProductList, true, (int)eColView.PACK_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtReturnProductList, true, (int)eColView.PO_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtReturnProductList, false, (int)eColView.QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtReturnProductList, true, (int)eColView.RETURNABLE_QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtReturnProductList, true, (int)eColView.SHIP_QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtReturnProductList, true, (int)eColView.SHORT_NAME);
                    CtrlUtil.SpreadSetColumnsLocked(shtReturnProductList, true, (int)eColView.TRANS_DATE);
                    m_keyboardSpread.StartBind();
                    break;
                case Common.eScreenMode.EDIT:
                    CtrlUtil.EnabledControl(false, cboCustomerCode);
                    CtrlUtil.EnabledControl(true, txtRemark, fpReturnProductList);
                    CtrlUtil.EnabledControl(false, dtReturnDate, cboReturnLoc);

                    tsbSaveAndNew.Enabled = true;
                    tsbSaveAndClose.Enabled = true;
                    shtReturnProductList.OperationMode = OperationMode.Normal;

                    CtrlUtil.SpreadSetColumnsLocked(shtReturnProductList, true, (int)eColView.EXTERNAL_LOT_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtReturnProductList, true, (int)eColView.ITEM_CD);
                    CtrlUtil.SpreadSetColumnsLocked(shtReturnProductList, true, (int)eColView.LOT_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtReturnProductList, true, (int)eColView.ORDER_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtReturnProductList, true, (int)eColView.PACK_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtReturnProductList, true, (int)eColView.PO_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtReturnProductList, false, (int)eColView.QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtReturnProductList, true, (int)eColView.RETURNABLE_QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtReturnProductList, true, (int)eColView.SHIP_QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtReturnProductList, true, (int)eColView.SHORT_NAME);
                    CtrlUtil.SpreadSetColumnsLocked(shtReturnProductList, true, (int)eColView.TRANS_DATE);
                    m_keyboardSpread.StartBind();
                    break;
            }

            m_screenMode = mode;
        }

        private void ClearAll()
        {
            CtrlUtil.ClearControlData(dtReturnDate, txtRemark, cboCustomerCode);
            lblReturnNo.Text = string.Empty;

            shtReturnProductList.RowCount = 0;
            if (m_model.DATA_VIEW != null)
                m_model.DATA_VIEW.Rows.Clear();
        }

        private void ClearAllExceptDefault()
        {
            CtrlUtil.ClearControlData(dtReturnDate, txtRemark, cboCustomerCode);
            lblReturnNo.Text = string.Empty;
            SysConfigBIZ sysBiz = new SysConfigBIZ();
            SysConfigDTO argScreenInfo = new SysConfigDTO();
            argScreenInfo.SYS_GROUP_ID = DataDefine.eSYSTEM_CONFIG.TRN270.SYS_GROUP_ID;
            argScreenInfo.SYS_KEY = (NZString)DataDefine.eSYSTEM_CONFIG.TRN270.SYS_KEY.STORE_LOC.ToString();
            dtReturnDate.Value = sysBiz.GetDefaultDateForScreen(argScreenInfo);
            shtReturnProductList.RowCount = 0;
            if (m_model.DATA_VIEW != null)
                m_model.DATA_VIEW.Rows.Clear();
        }

        #endregion

        #region Private method
        private void RemoveRowUnused(SheetView sheet)
        {
            int lastRowNonEmpty = shtReturnProductList.GetLastNonEmptyRow(NonEmptyItemFlag.Data);
            if (lastRowNonEmpty != shtReturnProductList.RowCount - 1)
            {
                shtReturnProductList.RemoveRows(shtReturnProductList.RowCount - 1, 1);
            }
        }

        private bool LoadItemIntoRow(int row, NZString ITEM_CD)
        {
            /* ItemValidator itemValidator = new ItemValidator();

             if (ITEM_CD != null)
             {
                 BusinessException error = itemValidator.CheckItemNotExist(ITEM_CD);
                 if (error != null)
                 {
                     shtReturnProductList.Cells[row, (int)eColView.ITEM_DESC].Value = null;
                     shtReturnProductList.Cells[row, (int)eColView.ORDER_UM_CLS].Value = null;
                     shtReturnProductList.Cells[row, (int)eColView.INV_UM_CLS].Value = null;
                     shtReturnProductList.Cells[row, (int)eColView.ORDER_UM_RATE].Value = null;
                     shtReturnProductList.Cells[row, (int)eColView.INV_UM_RATE].Value = null;
                     return false;
                 }

                 ItemBIZ itemBIZ = new ItemBIZ();
                 ItemDTO itemDTO = itemBIZ.LoadItem(ITEM_CD);
                 shtReturnProductList.Cells[row, (int)eColView.ITEM_CD].Value = itemDTO.ITEM_CD.Value;
                 shtReturnProductList.Cells[row, (int)eColView.ITEM_DESC].Value = itemDTO.ITEM_DESC.Value;
                 //shtReturnProductList.Cells[row, (int)eColView.ORDER_UM_CLS].Value = itemDTO.ORDER_UM_CLS.Value;
                 //shtReturnProductList.Cells[row, (int)eColView.INV_UM_CLS].Value = itemDTO.INV_UM_CLS.Value;
                 //shtReturnProductList.Cells[row, (int)eColView.ORDER_UM_RATE].Value = itemDTO.ORDER_UM_RATE.Value;
                 //shtReturnProductList.Cells[row, (int)eColView.INV_UM_RATE].Value = itemDTO.INV_UM_RATE.Value;

                 //shtReturnProductList.Cells[row, (int)eColView.LOT_CONTROL_CLS].Value = itemDTO.LOT_CONTROL_CLS.Value;



                 //if (itemDTO.LOT_CONTROL_CLS == DataDefine.Convert2ClassCode(DataDefine.eLOT_CONTROL_CLS.Yes))
                 //{
                 //    //shtView.Cells[row, (int)eColView.LOT_NO].Value = dtReceiveDate.Value.Value.ToString(DataDefine.LOT_NO_FORMAT);

                 //    //if (rdoReceive.Checked)
                 //    //{
                 //    //    RunningNumberBIZ runningNoBiz = new RunningNumberBIZ();

                 //    //    NZString strLotNoPrefix = runningNoBiz.GenerateLotNoPrefix(new NZDateTime(null, dtReceiveDate.Value));
                 //    //    NZInt iLastRunningNo = runningNoBiz.GetLastLotNoRunningBox(strLotNoPrefix, new NZString(cboStoredLoc, (string)cboStoredLoc.SelectedValue), itemDTO.ITEM_CD, new NZInt(null, 0));

                 //    //    ReceivingEntryController rcvController = new ReceivingEntryController();
                 //    //    NZString strLotNo = rcvController.GenerateLotNo(strLotNoPrefix, ref iLastRunningNo);
                 //    //    shtView.Cells[row, (int)eColView.LOT_NO].Value = strLotNo.StrongValue;

                 //    //}
                 //}
                 //else
                 //{
                 //    shtReturnProductList.Cells[row, (int)eColView.LOT_NO].Value = null;
                 //}

                 ItemProcessDTO processDTO = itemBIZ.LoadItemProcess(ITEM_CD);
                 //shtReturnProductList.Cells[row, (int)eColView.LOT_SIZE].Value = processDTO.LOT_SIZE.NVL(0);



             }
             */
            return true;
        }

        private bool ValidateMandatory()
        {
            // Validate Data before Save
            if (!dtReturnDate.Value.HasValue)
            {
                ValidateException.ThrowErrorItem(new ErrorItem(null, TKPMessages.eValidate.VLM0105.ToString(), new object[] { "Return Date" }));
                return false;
            }
            if (cboCustomerCode.SelectedValue == null)
            {
                ValidateException.ThrowErrorItem(new ErrorItem(null, TKPMessages.eValidate.VLM0105.ToString(), new object[] { "Customer Code" }));
                return false;
            }
            if (shtReturnProductList.Rows.Count == 0)
            {
                ValidateException.ThrowErrorItem(new ErrorItem(null, TKPMessages.eValidate.VLM0197.ToString()));
            }

            if (!CheckZeroReturnQTY())
            {
                ValidateException.ThrowErrorItem(new ErrorItem(null, TKPMessages.eValidate.VLM0196.ToString()));
            }

            TransactionValidator valTRN = new TransactionValidator();
            ErrorItem errorItem;
            errorItem = valTRN.DateIsInCurrentPeriod(new NZDateTime(dtReturnDate, dtReturnDate.Value));
            if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

            return true;
        }
        private bool CheckZeroReturnQTY()
        {
            bool result = true;
            for (int i = 0; i < shtReturnProductList.RowCount; i++)
            {
                bool chk = true;

                if (Convert.ToDecimal(shtReturnProductList.GetValue(i, (int)eColView.QTY)) <= 0)
                {
                    chk = false;
                    result = false;
                }

                if (!chk)
                {
                    shtReturnProductList.Rows[i].BackColor = Color.Red;
                }
                else
                {
                    if (i % 2 > 0) shtReturnProductList.Rows[i].BackColor = Color.FromArgb(236, 247, 243);
                    else shtReturnProductList.Rows[i].BackColor = Color.White;
                }

            }
            return result;
        }

        private void LoadData()
        {
            m_model.DATA_VIEW = m_controller.Load_ReturnListEntry(m_model.SLIP_NO, false);
            shtReturnProductList.RowCount = 0;
            shtReturnProductList.DataSource = m_model.DATA_VIEW;
        }

        #endregion

        #region Overriden method
        public override void OnSaveAndNew()
        {
            stcHead.Focus();
            fpReturnProductList.StopCellEditing();
            if (m_bRowHasModified)
            { // ถ้า Row กำลังแก้ไขอยู่
                if (!ValidateRowSpread(shtReturnProductList.ActiveRowIndex, false))
                {
                    return;
                }
            }

            // ต้องเรียกก่อน Save เสมอ  เพื่อ Commit ข้อมูลการแก้ไขล่าสุดบน Grid
            // ใช้ได้เฉพาะกับ Sheet ที่ผูก DataSource
            CtrlUtil.SpreadSheetRowEndEdit(shtReturnProductList, shtReturnProductList.ActiveRowIndex);

            RemoveRowUnused(shtReturnProductList);

            try
            {
                //ItemValidator itemValidator = new ItemValidator();
                //int row = shtReturnProductList.Rows.Count;
                //for (int i = 0; i < row; i++)
                //{
                //    NZString ItemCD = new NZString(null, shtReturnProductList.Cells[i, (int)eColView.ITEM_CD].Value);
                //    BusinessException err = itemValidator.CheckItemNotExist(ItemCD);
                //    if (err != null)
                //        ValidateException.ThrowErrorItem(err.Error);
                //}

                if (!ValidateMandatory())
                {
                    return;
                }

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, Message.LoadMessage(Messages.eConfirm.CFM9001.ToString()));
                if (dr == MessageDialogResult.Cancel || dr == MessageDialogResult.No)
                {
                    return;
                }
                if (dr == MessageDialogResult.Yes)
                {

                    //== Prepare data.
                    ReturnEntryUIDM newModel = dmcReturn.SaveData(new ReturnEntryUIDM());
                    newModel.DATA_VIEW = m_model.DATA_VIEW;

                    //== Save Process
                    m_controller.Save(newModel, m_screenMode);

                    // Post-process.
                    m_dialogResult = DialogResult.OK;

                    MessageDialog.ShowInformation(this, null, Message.LoadMessage(Messages.eInformation.INF9003.ToString()).MessageDescription);
                }

                //== return to Add new data screen mode.
                SetScreenMode(Common.eScreenMode.ADD);
                ClearAllExceptDefault();

                m_bRowHasModified = false;

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
            fpReturnProductList.StopCellEditing();
            if (m_bRowHasModified)
            { // ถ้า Row กำลังแก้ไขอยู่
                if (!ValidateRowSpread(shtReturnProductList.ActiveRowIndex, false))
                {
                    return;
                }
            }
            // ต้องเรียกก่อน Save เสมอ  เพื่อ Commit ข้อมูลการแก้ไขล่าสุดบน Grid
            // ใช้ได้เฉพาะกับ Sheet ที่ผูก DataSource
            CtrlUtil.SpreadSheetRowEndEdit(shtReturnProductList, shtReturnProductList.ActiveRowIndex);

            RemoveRowUnused(shtReturnProductList);

            try
            {
                //ItemValidator itemValidator = new ItemValidator();
                //int row = shtReturnProductList.Rows.Count;
                //for (int i = 0; i < row; i++)
                //{
                //    NZString ItemCD = new NZString(null, shtReturnProductList.Cells[i, (int)eColView.ITEM_CD].Value);
                //    BusinessException err = itemValidator.CheckItemNotExist(ItemCD);
                //    if (err != null)
                //        ValidateException.ThrowErrorItem(err.Error);
                //}

                if (!ValidateMandatory())
                {
                    return;
                }

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, Message.LoadMessage(Messages.eConfirm.CFM9001.ToString()));
                if (dr == MessageDialogResult.Cancel || dr == MessageDialogResult.No)
                {
                    return;
                }

                if (dr == MessageDialogResult.Yes)
                {
                    //== Prepare data.
                    ReturnEntryUIDM newModel = dmcReturn.SaveData(new ReturnEntryUIDM());
                    newModel.DATA_VIEW = m_model.DATA_VIEW;


                    //== Save Process
                    m_controller.Save(newModel, m_screenMode);

                    // Post-process.
                    m_dialogResult = DialogResult.OK;

                    MessageDialog.ShowInformation(this, null, Message.LoadMessage(Messages.eInformation.INF9003.ToString()).MessageDescription);
                }

                //== Exit form.
                this.Close();
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
        private void TRN270_Load(object sender, EventArgs e)
        {
            InitializeScreen();

            if (m_editReturnNo == null)
            {
                SetScreenMode(Common.eScreenMode.ADD);
                ClearAll();

                m_model = new ReturnEntryUIDM();
                dmcReturn.LoadData(m_model);

                SysConfigBIZ sysBiz = new SysConfigBIZ();
                SysConfigDTO argScreenInfo = new SysConfigDTO();
                argScreenInfo.SYS_GROUP_ID = DataDefine.eSYSTEM_CONFIG.TRN270.SYS_GROUP_ID;
                argScreenInfo.SYS_KEY = (NZString)DataDefine.eSYSTEM_CONFIG.TRN270.SYS_KEY.STORE_LOC.ToString();
                dtReturnDate.Value = sysBiz.GetDefaultDateForScreen(argScreenInfo);


                shtReturnProductList.RowCount = 0;
                shtReturnProductList.DataSource = m_model.DATA_VIEW;
                try
                {
                    //if (rdoReceive.Checked)
                    //{
                    //    cboStoredLoc.SelectedValue = m_strDefaultLocation;
                    //}
                }
                catch
                {
                }

            }
            else
            {
                InventoryBIZ bizInventory = new InventoryBIZ();
                ClearAll();
                dmcReturn.LoadData(m_model);

                LoadData();
                // m_model.DATA_VIEW = m_controller.Load_ReturnListEntry(m_model.SLIP_NO, false);

                //List<InventoryTransactionViewDTO> dtos = DTOUtility.ConvertDataTableToList<InventoryTransactionViewDTO>(m_model.DATA_VIEW);
                // bizInventory.LoadTransactionViewByReceiveNo(m_editReceiveNo);

                if (m_model.DATA_VIEW.Rows.Count > 0)
                {
                    bool bCanEdit = m_transactionValidator.DateIsInCurrentPeriod(m_model.TRANS_DATE.StrongValue) == null;
                    if (bCanEdit)
                    {
                        SetScreenMode(Common.eScreenMode.EDIT);
                    }
                    else
                    {
                        SetScreenMode(Common.eScreenMode.VIEW);
                    }
                    //SetScreenMode(Common.eScreenMode.EDIT);
                }
                else
                {
                    SetScreenMode(Common.eScreenMode.VIEW);
                }


                //dmcReturn.LoadData(m_model);

                //shtReturnProductList.RowCount = 0;
                //shtReturnProductList.DataSource = m_model.DATA_VIEW;

                //int row = shtView.Rows.Count;
                //// set amount value
                //if (row > 0)
                //{
                //    for (int i = 0; i < row; i++)
                //    {
                //        shtView.Cells[i, (int)eColView.AMOUNT].Value = Convert.ToDouble(shtView.Cells[i, (int)eColView.ORDER_QTY].Value) 
                //                                                        * Convert.ToDouble(shtView.Cells[i, (int)eColView.PRICE].Value);
                //    }
                //}
            }

            CheckCurrentInvPeriod();
        }

        private void TRN270_Shown(object sender, EventArgs e)
        {
            if (m_screenMode == Common.eScreenMode.ADD)
            {
                CtrlUtil.FocusControl(dtReturnDate);
            }
            else
            {
                CtrlUtil.FocusControl(fpReturnProductList);
            }
        }

        private void TRN020_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        #endregion

        #region Control event
        private void miAdd_Click(object sender, EventArgs e)
        {
            //m_keyboardSpread.OnActionAddNewRow();
            btnAddReturn_Click(sender, e);

            // DEFAULT LOT VALUE
            //if (rdoReceive.Checked && dtReceiveDate.Value.HasValue)
            //    shtView.Cells[shtView.Rows.Count - 1, (int)eColView.LOT_NO].Value = dtReceiveDate.Value.Value.ToString(DataDefine.LOT_NO_FORMAT);
        }
        private void miDelete_Click(object sender, EventArgs e)
        {
            m_keyboardSpread.OnActionRemoveRow();
        }

        #endregion

        #region Spread event

        #region Variables
        /// <summary>
        /// เก็บรายการของแถวที่กำลังแก้
        /// </summary>
        //private readonly Map<eColView, object> m_mapCellValue = new Map<eColView, object>();
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
        //private void StoreCellValues(int rowIndex)
        //{
        //    m_mapCellValue.RemoveAll();
        //    for (int i = 0; i < shtReturnProductList.Columns.Count; i++)
        //    {
        //        m_mapCellValue.Put((eColView)i, shtReturnProductList.Cells[rowIndex, i].Value);
        //    }
        //}

        /// <summary>
        /// คืนค่า Cell ที่เก็บไว้ กลับคืนไปยัง Row ที่ระบุ
        /// </summary>
        /// <param name="rowIndex"></param>
        //private void RestoreCellValues(int rowIndex)
        //{
        //    if (m_mapCellValue.Count > 0)
        //    {
        //        for (int i = 0; i < m_mapCellValue.Count; i++)
        //        {
        //            shtReturnProductList.Cells[rowIndex, (int)m_mapCellValue[i].Key].Value = m_mapCellValue[i].Value;
        //        }
        //    }
        //}
        #endregion

        #region Spread trigger.
        private void fpView_EditModeOn(object sender, EventArgs e)
        {
            // ถ้าเป็นการแก้ไข Cell ใน Row เดียวกัน เป็นครั้งแรก
            if (!m_bRowHasModified)
            {
                m_bRowHasModified = true;
                //StoreCellValues(shtReturnProductList.ActiveRowIndex);
            }
        }

        private void fpView_EditModeOff(object sender, EventArgs e)
        {

            int rowIndex = shtReturnProductList.ActiveRowIndex;
            int colIndex = shtReturnProductList.ActiveColumnIndex;

            //bool bValidateCellPass = ValidateCellEdited(rowIndex, colIndex);
            if (m_Skip_Validate_Return_QTY)
            {
                // nothing to do.
            }
            else if (!ValidateRowSpread(rowIndex, false))
            {
                shtReturnProductList.SetActiveCell(rowIndex, colIndex);
            }
        }

        private void fpView_LeaveCell(object sender, LeaveCellEventArgs e)
        {
            if (m_bRowHasModified)
            {  // เช็คว่า Cell ในแถวนั้น มีการแก้ไขค่าหรือไม่
                if (e.Row != e.NewRow)
                {  // ถ้าเป็นการเปลี่ยนแถว ต้องเช็คก่อนว่า Validate แถวผ่านหรือไม่?
                    if (!m_Skip_Validate_Return_QTY && !ValidateRowSpread(e.Row, false))
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        //private void fpView_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyData == Keys.Escape)
        //    {
        //        if (m_bRowHasModified)
        //        {
        //            int lastRowNonEmpty = shtReturnProductList.GetLastNonEmptyRow(NonEmptyItemFlag.Data);
        //            if (lastRowNonEmpty != shtReturnProductList.RowCount - 1)
        //            {
        //                shtReturnProductList.RemoveRows(shtReturnProductList.RowCount - 1, 1);
        //            }
        //            else
        //            {
        //                RestoreCellValues(shtReturnProductList.ActiveRowIndex);
        //            }

        //            m_bRowHasModified = false;
        //        }
        //        else
        //        {
        //            RemoveRowUnused(shtReturnProductList);
        //        }
        //    }
        //}

        //private void fpView_ButtonClicked(object sender, EditorNotifyEventArgs e)
        //{
        //    /*if (e.Column == (int)eColView.ITEM_CD_BTN)
        //    {

        //        ItemFindDialog dialog = null;

        //        //if (chkFilterItem.Checked)
        //        //{
        //        //    //if (cboSupplierCode.ToNZString().IsNull)
        //        //    //{
        //        //    //    ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0105.ToString(), new object[] { this.lblSupplierCode.Text });
        //        //    //    MessageDialog.ShowBusiness(this, error.Message);

        //        //    //    return;
        //        //    //}

        //        //    dialog = new ItemFindDialog(eSqlOperator.In, null, cboSupplierCode.ToNZString(), DataDefine.eDealingType.Supplier);
        //        //}
        //        //else
        //        //{
        //        dialog = new ItemFindDialog(eSqlOperator.In, null);
        //        //}
        //        dialog.ShowDialog(this);

        //        if (dialog.IsSelected)
        //        {
        //            LoadItemIntoRow(e.Row, dialog.SelectedItem.ITEM_CD);
        //        }
        //    }*/
        //}
        #endregion

        #region Spread Validate
        /// <summary>
        /// Validate เมื่อ Cell มีการแก้ไขเรียบร้อย  และค่าที่แก้ไขเป็นค่าใหม่
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        private bool ValidateCellEdited(int row, int column)
        {
            /* if (column == (int)eColView.ITEM_CD)
             {
                 ItemValidator itemValidator = new ItemValidator();

                 object objItemCode = shtReturnProductList.GetValue(row, column);
                 if (objItemCode != null)
                 {
                     NZString itemCode = new NZString(null, objItemCode);
                     bool bLoadItem = LoadItemIntoRow(row, itemCode);
                     if (!bLoadItem)
                         return false;
                 }
             }
             else if (column == (int)eColView.ORDER_QTY)
             {
                 try
                 {
                     NZDecimal orderRate = new NZDecimal(null, shtReturnProductList.Cells[row, (int)eColView.ORDER_UM_RATE].Value);
                     NZDecimal invRate = new NZDecimal(null, shtReturnProductList.Cells[row, (int)eColView.INV_UM_RATE].Value);
                     NZDecimal orderQty = new NZDecimal(null, shtReturnProductList.Cells[row, (int)eColView.ORDER_QTY].Value);
                     NZDecimal price = new NZDecimal(null, shtReturnProductList.Cells[row, (int)eColView.PRICE].Value);

                     decimal invQty = (invRate.NVL(0) / orderRate.NVL(1)) * orderQty.NVL(0);
                     decimal amount = price.NVL(0) * orderQty.NVL(0);

                     shtReturnProductList.Cells[row, (int)eColView.QTY].Value = invQty;
                     shtReturnProductList.Cells[row, (int)eColView.AMOUNT].Value = amount;
                 }
                 catch
                 {
                     shtReturnProductList.Cells[row, (int)eColView.AMOUNT].Value = 0;
                     shtReturnProductList.Cells[row, (int)eColView.QTY].Value = 0;
                 }
             }

             else if (column == (int)eColView.PRICE)
             {
                 try
                 {
                     NZDecimal orderQty = new NZDecimal(null, shtReturnProductList.Cells[row, (int)eColView.ORDER_QTY].Value);
                     NZDecimal price = new NZDecimal(null, shtReturnProductList.Cells[row, (int)eColView.PRICE].Value);

                     decimal amount = price.NVL(0) * orderQty.NVL(0);

                     shtReturnProductList.Cells[row, (int)eColView.AMOUNT].Value = amount;
                 }
                 catch
                 {
                     shtReturnProductList.Cells[row, (int)eColView.AMOUNT].Value = 0;
                 }
             }
             */
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
            /*if (!forceValidate && !m_bRowHasModified)
                return true;

            //Check item
            string itemCode = shtReturnProductList.Cells[row, (int)eColView.ITEM_CD].Text;

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
            NZDecimal qty = new NZDecimal(null, shtReturnProductList.Cells[row, (int)eColView.ORDER_QTY].Value);
            if (qty.IsNull || qty.StrongValue == decimal.Zero)
            {
                ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0043.ToString());
                MessageDialog.ShowBusiness(this, error.Message);
                return false;
            }

            // ถ้า Validate Row ผ่าน แสดงว่า แถวนั้นไม่จำเป็นต้องเช็คอีกรอบ
            m_bRowHasModified = false;
             */
            decimal ReturnableQTY = Convert.ToDecimal(shtReturnProductList.GetValue(row, (int)eColView.RETURNABLE_QTY));
            decimal QTY = Convert.ToDecimal(shtReturnProductList.GetValue(row, (int)eColView.QTY));
            if (ReturnableQTY < QTY)
            {
                ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0195.ToString());
                MessageDialog.ShowBusiness(this, error.Message);
                return false;
            }

            if (QTY <= 0)
            {
                ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0196.ToString());
                MessageDialog.ShowBusiness(this, error.Message);
                return false;
            }

            return true;
        }
        #endregion

        #endregion

        private void rdoReceiveReturn_CheckedChanged(object sender, EventArgs e)
        {
            //if (rdoReceive.Checked)
            //{
            //    shtView.Columns[(int)eColView.PRICE].Locked = false;
            //    shtView.Columns[(int)eColView.SUPP_LOT_NO].Locked = false;
            //}
            //if (rdoReceiveReturn.Checked)
            //{
            //    shtView.Columns[(int)eColView.PRICE].Locked = true;
            //    shtView.Columns[(int)eColView.SUPP_LOT_NO].Locked = true;
            //    int row = shtView.Rows.Count;
            //    for (int i = 0; i < row; i++)
            //    {
            //        shtView.Cells[i, (int)eColView.PRICE].Text = string.Empty;
            //        shtView.Cells[i, (int)eColView.SUPP_LOT_NO].Text = string.Empty;
            //    }
            //}

            //shtView.RowCount = 0;
            //if (m_model.DATA_VIEW != null)
            //    m_model.DATA_VIEW.Rows.Clear();
            //m_bRowHasModified = false;
        }

        private void dtReceiveDate_ValueChanged(object sender, EventArgs e)
        {
            //if (dtReceiveDate.Value.HasValue)
            //{
            //    int row = shtView.Rows.Count;
            //    if (row > 0)
            //    {

            //        RunningNumberBIZ runningNoBiz = new RunningNumberBIZ();

            //        for (int i = 0; i < row; i++)
            //        {
            //            //shtView.Cells[i, (int)eColView.LOT_NO].Value = dtReceiveDate.Value.Value.ToString(DataDefine.LOT_NO_FORMAT);

            //            string oLotControlCls = Convert.ToString(shtView.Cells[i, (int)eColView.LOT_CONTROL_CLS].Value);

            //            string strItemCode = Convert.ToString(shtView.Cells[i, (int)eColView.ITEM_CD].Value);

            //            if (oLotControlCls == DataDefine.Convert2ClassCode(DataDefine.eLOT_CONTROL_CLS.Yes))
            //            {
            //                //shtView.Cells[row, (int)eColView.LOT_NO].Value = dtReceiveDate.Value.Value.ToString(DataDefine.LOT_NO_FORMAT);

            //                if (rdoReceive.Checked)
            //                {

            //                    NZString strLotNoPrefix = runningNoBiz.GenerateLotNoPrefix(new NZDateTime(null, dtReceiveDate.Value));
            //                    NZInt iLastRunningNo = runningNoBiz.GetLastLotNoRunningBox(strLotNoPrefix, new NZString(cboStoredLoc, (string)cboStoredLoc.SelectedValue), (NZString)strItemCode, new NZInt(null, 0));

            //                    ReceivingEntryController rcvController = new ReceivingEntryController();
            //                    NZString strLotNo = rcvController.GenerateLotNo(strLotNoPrefix, ref iLastRunningNo);
            //                    shtView.Cells[i, (int)eColView.LOT_NO].Value = strLotNo.StrongValue;

            //                }
            //            }
            //            else
            //            {
            //                shtView.Cells[i, (int)eColView.LOT_NO].Value = null;
            //            }



            //        }
            //    }
            //}
        }

        private void txtRemark_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                //tslControl.Select();
                //tsbSaveAndNew.Select();
            }
        }

        private void btnAddReturn_Click(object sender, EventArgs e)
        {

            if (cboCustomerCode.SelectedValue == null || cboReturnLoc.SelectedValue == null)
            {
                if (cboCustomerCode.SelectedValue == null && cboReturnLoc.SelectedValue == null)
                    MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0105.ToString(), new object[] { "Customer Code and Return Loc" }));
                else if (cboCustomerCode.SelectedValue == null)
                    MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0105.ToString(), new object[] { "Customer Code" }));
                else MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0105.ToString(), new object[] { "Return Loc" }));
                return;
            }
            else
            {
                string strLocation = Convert.ToString(cboReturnLoc.SelectedValue);
                string strCustomer = Convert.ToString(cboCustomerCode.SelectedValue);
                string strReturnSlipNo = lblReturnNo.Text;

                TRN271_DeliveryOrderSelection f = new TRN271_DeliveryOrderSelection(strLocation, strCustomer, strReturnSlipNo, shtReturnProductList);
                if (DialogResult.OK == f.ShowDialog())
                {
                    m_Skip_Validate_Return_QTY = true;
                    for (int i = 0; i < f.shtData.RowCount; i++)
                    {
                        if (Convert.ToBoolean(f.shtData.Cells[i, (int)eColChooseOrder.EDIT_FLAG].Value) == true)
                        {
                            m_keyboardSpread.StartBind();
                            m_keyboardSpread.OnActionAddNewRow();
                            int j = shtReturnProductList.RowCount - 1;
                            //shtReturnProductList.Cells[j, (int)eColView.GROUP_TRANS_ID].Value = f.shtData.Cells[i, (int)eColChooseOrder.GROUP_TRANS_ID].Value;
                            shtReturnProductList.Cells[j, (int)eColView.REF_NO].Value = f.shtData.Cells[i, (int)eColChooseOrder.TRANS_ID].Value;
                            shtReturnProductList.Cells[j, (int)eColView.PO_NO].Value = f.shtData.Cells[i, (int)eColChooseOrder.PO_NO].Value;
                            shtReturnProductList.Cells[j, (int)eColView.REF_SLIP_NO].Value = f.shtData.Cells[i, (int)eColChooseOrder.ORDER_DETAIL_NO].Value;
                            shtReturnProductList.Cells[j, (int)eColView.ITEM_CD].Value = f.shtData.Cells[i, (int)eColChooseOrder.ITEM_CD].Value;
                            shtReturnProductList.Cells[j, (int)eColView.SHORT_NAME].Value = f.shtData.Cells[i, (int)eColChooseOrder.SHORT_NAME].Value;
                            shtReturnProductList.Cells[j, (int)eColView.TRANS_DATE].Value = f.shtData.Cells[i, (int)eColChooseOrder.TRANS_DATE].Value;
                            shtReturnProductList.Cells[j, (int)eColView.PACK_NO].Value = f.shtData.Cells[i, (int)eColChooseOrder.PACK_NO].Value;
                            shtReturnProductList.Cells[j, (int)eColView.FG_NO].Value = f.shtData.Cells[i, (int)eColChooseOrder.FG_NO].Value;
                            shtReturnProductList.Cells[j, (int)eColView.LOT_NO].Value = f.shtData.Cells[i, (int)eColChooseOrder.LOT_NO].Value;
                            shtReturnProductList.Cells[j, (int)eColView.EXTERNAL_LOT_NO].Value = f.shtData.Cells[i, (int)eColChooseOrder.EXTERNAL_LOT_NO].Value;
                            shtReturnProductList.Cells[j, (int)eColView.SHIP_QTY].Value = f.shtData.Cells[i, (int)eColChooseOrder.LOT_QTY].Value;
                            shtReturnProductList.Cells[j, (int)eColView.RETURNABLE_QTY].Value = f.shtData.Cells[i, (int)eColChooseOrder.RETURNABLE_QTY].Value;
                            shtReturnProductList.Cells[j, (int)eColView.ORDER_NO].Value = f.shtData.Cells[i, (int)eColChooseOrder.ORDER_NO].Value;
                            shtReturnProductList.Cells[j, (int)eColView.QTY].Value = 0;
                            fpReturnProductList.StopCellEditing();
                            shtReturnProductList.SetActiveCell(shtReturnProductList.RowCount - 1, (int)eColView.QTY);
                        }
                    }
                    m_Skip_Validate_Return_QTY = false;
                }
            }
        }

        private void cboCustomerCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_screenMode == Common.eScreenMode.ADD)
            {
                m_model.DATA_VIEW = new ReturnEntryUIDM().DATA_VIEW;
                shtReturnProductList.RowCount = 0;
                shtReturnProductList.DataSource = null;
                shtReturnProductList.DataSource = m_model.DATA_VIEW;
            }
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
            }

            SheetWidthController ctrl = new SheetWidthController();
            ctrl.SetSheetWidth(shtReturnProductList, this.ScreenCode);
        }

        private void fpReturnProductList_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }
    }
}
