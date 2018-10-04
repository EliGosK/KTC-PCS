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


namespace Rubik.Transaction
{
    [Screen("TRN020", "Receiving Entry", eShowAction.Normal, eScreenType.Screen, "Receiving Entry")]
    public partial class TRN020 : SystemMaintenance.Forms.CustomizeForm
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
            ITEM_CD,
            ITEM_CD_BTN,
            ITEM_DESC,
            LOT_NO,
            SUPP_LOT_NO,
            ORDER_QTY,
            LOT_SIZE,
            PRICE,
            AMOUNT,
            ORDER_UM_CLS,
            QTY,

            INV_UM_CLS,
            ORDER_UM_RATE,
            INV_UM_RATE,

            LOT_CONTROL_CLS,
        }
        #endregion

        #region Variables
        private Common.eScreenMode m_screenMode = Common.eScreenMode.ADD;
        private NZString m_editReceiveNo = null;
        //private KeyboardSpread m_keyboardSpread = null;

        private readonly ReceivingEntryController m_controller = new ReceivingEntryController();
        private readonly InventoryTransBIZ m_bizInventoryTransaction = new InventoryTransBIZ();
        private readonly TransactionValidator m_transactionValidator = new TransactionValidator();

        private ReceivingEntryUIDM m_model = new ReceivingEntryUIDM();
        private DialogResult m_dialogResult = DialogResult.Cancel;

        private string m_strDefaultLocation = "MAT'";
        #endregion

        #region Constructor
        public TRN020()
        {
            InitializeComponent();
        }

        public TRN020(NZString receiveNo)
        {
            InitializeComponent();

            m_editReceiveNo = receiveNo;
        }
        #endregion

        #region Initialize Screen
        private void InitializeScreen()
        {
            InitializeBindingControl();
            InitializeSetKeyPress();
            InitializeLookupData();
            InitializeComboBox();
            InitializeSpread();

            InitializeDefaultValue();

            dtReceiveDate.Format = Common.CurrentUserInfomation.DateFormatString;

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
            cboStoredLoc.Format += Common.ComboBox_Format;
            cboSupplierCode.Format += Common.ComboBox_Format;
        }
        private void InitializeLookupData()
        {
            LookupDataBIZ biz = new LookupDataBIZ();
            LookupData locationLookup = biz.LoadLookupLocation();
            NZString[] SupplierType = new NZString[] {(NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.CustomerVendor),
                                                           (NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Vendor)};
            LookupData SupplierLookup = biz.LoadLookupLocation(SupplierType);
            cboStoredLoc.LoadLookupData(locationLookup);
            cboSupplierCode.LoadLookupData(SupplierLookup);

            LookupData umClsData = biz.LoadLookupClassType(DataDefine.UM_CLS.ToNZString());
            shtView.Columns[(int)eColView.ORDER_UM_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(umClsData);
            shtView.Columns[(int)eColView.INV_UM_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(umClsData);
        }
        private void InitializeSpread()
        {
            shtView.ActiveSkin = Common.ACTIVE_SKIN;

            shtView.Columns[(int)eColView.ITEM_CD].ForeColor = Color.Blue;
            shtView.Columns[(int)eColView.ORDER_QTY].ForeColor = Color.Blue;
            shtView.Columns[(int)eColView.LOT_NO].ForeColor = Color.Blue;
            shtView.Columns[(int)eColView.SUPP_LOT_NO].ForeColor = Color.Blue;
            shtView.Columns[(int)eColView.PRICE].ForeColor = Color.Blue;

            fpView.SubEditorOpening += CtrlUtil.SpreadDisableSubEditorOpening;

            // Assign DataField.
            CtrlUtil.MappingDataFieldWithEnum(shtView, typeof(eColView));
        }
        private void InitializeBindingControl()
        {
            dmcReceive.AddRangeControl(
                lblReceiveNo,
                dtReceiveDate,
                rdoReceive,
                rdoReceiveReturn,
                txtInvoiceNo,
                txtPONo,
                txtRemark,
                cboStoredLoc,
                cboSupplierCode

                );
        }
        private void InitializeSetKeyPress()
        {
            dtReceiveDate.KeyPress += CtrlUtil.SetNextControl;
            txtInvoiceNo.KeyPress += CtrlUtil.SetNextControl;
            rdoReceive.KeyPress += CtrlUtil.SetNextControl;
            rdoReceiveReturn.KeyPress += CtrlUtil.SetNextControl;
            txtPONo.KeyPress += CtrlUtil.SetNextControl;
            txtRemark.KeyPress += CtrlUtil.SetNextControl;
            cboStoredLoc.KeyPress += CtrlUtil.SetNextControl;
            cboSupplierCode.KeyPress += CtrlUtil.SetNextControl;
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
            CtrlUtil.SpreadSetCellLocked(shtView, false, rowIndex, (int)eColView.ITEM_CD);
            CtrlUtil.SpreadSetCellLocked(shtView, false, rowIndex, (int)eColView.ITEM_CD_BTN);
            CtrlUtil.SpreadSetCellLocked(shtView, false, rowIndex, (int)eColView.ORDER_QTY);
            CtrlUtil.SpreadSetCellLocked(shtView, false, rowIndex, (int)eColView.LOT_NO);
            // CtrlUtil.SpreadSetCellLocked(shtView, false, rowIndex, (int)eColView.SUPP_LOT_NO);
            // CtrlUtil.SpreadSetCellLocked(shtView, false, rowIndex, (int)eColView.PRICE);
            if (rdoReceive.Checked)
            {
                shtView.Columns[(int)eColView.PRICE].Locked = false;
                shtView.Columns[(int)eColView.SUPP_LOT_NO].Locked = false;
            }
            if (rdoReceiveReturn.Checked)
            {
                shtView.Columns[(int)eColView.PRICE].Locked = true;
                shtView.Columns[(int)eColView.SUPP_LOT_NO].Locked = true;
                int row = shtView.Rows.Count;
                for (int i = 0; i < row; i++)
                {
                    shtView.Cells[i, (int)eColView.PRICE].Text = string.Empty;
                    shtView.Cells[i, (int)eColView.SUPP_LOT_NO].Text = string.Empty;
                }
            }
        }

        void m_keyboardSpread_RowAdding(object sender, EventRowAdding e)
        {
            if (m_bRowHasModified)
            { // ถ้า Row กำลังแก้ไขอยู่
                if (!ValidateRowSpread(shtView.ActiveRowIndex, false))
                {
                    e.Cancel = true;
                    return;
                }
            }
            else
            {
                // ถ้าไม่มีการแก้ไข Row  แต่ก่อนที่จะเพิ่มแถวใหม่ จะต้อง Validate แถวล่าสุด (ล่างสุด) ก่อน
                if (shtView.RowCount > 0 && shtView.ActiveRowIndex >= 0)
                {
                    if (!ValidateRowSpread(shtView.RowCount - 1, true))
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
                    CtrlUtil.EnabledControl(false, txtInvoiceNo, txtPONo, txtRemark, fpView);
                    CtrlUtil.EnabledControl(false, dtReceiveDate, rdoReceive, rdoReceiveReturn);
                    CtrlUtil.EnabledControl(false, txtInvoiceNo, txtPONo, txtRemark, cboStoredLoc, cboSupplierCode);

                    tsbSaveAndNew.Enabled = false;
                    tsbSaveAndClose.Enabled = false;
                    shtView.OperationMode = OperationMode.ReadOnly;

                    CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.ORDER_QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.SUPP_LOT_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.PRICE);
                    fpView.ContextMenuStrip = null;
                    break;
                case Common.eScreenMode.ADD:
                    CtrlUtil.EnabledControl(true, dtReceiveDate, txtInvoiceNo, txtPONo
                        , txtRemark, fpView, rdoReceiveReturn, rdoReceive, cboSupplierCode, cboStoredLoc);
                    //m_keyboardSpread.StartBind();
                    break;
                case Common.eScreenMode.EDIT:
                    CtrlUtil.EnabledControl(true, fpView);
                    CtrlUtil.EnabledControl(false, dtReceiveDate, rdoReceive, rdoReceiveReturn, cboStoredLoc, cboSupplierCode);
                    CtrlUtil.EnabledControl(true, txtInvoiceNo, txtPONo, txtRemark);
                    CtrlUtil.SpreadSetColumnsLocked(shtView, false, (int)eColView.ORDER_QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtView, false, (int)eColView.SUPP_LOT_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtView, false, (int)eColView.PRICE);
                    //m_keyboardSpread.StartBind();
                    break;
            }

            m_screenMode = mode;
        }

        private void ClearAll()
        {
            CtrlUtil.ClearControlData(dtReceiveDate, txtInvoiceNo, txtPONo, txtRemark
                , cboStoredLoc, cboSupplierCode);
            lblReceiveNo.Text = string.Empty;

            shtView.RowCount = 0;
            if (m_model.DATA_VIEW != null)
                m_model.DATA_VIEW.Rows.Clear();

            rdoReceive.Checked = true;
        }

        private void ClearAllExceptDefault()
        {
            CtrlUtil.ClearControlData(txtInvoiceNo, txtPONo, txtRemark, cboSupplierCode);
            lblReceiveNo.Text = string.Empty;

            shtView.RowCount = 0;
            if (m_model.DATA_VIEW != null)
                m_model.DATA_VIEW.Rows.Clear();

            rdoReceive.Checked = true;

            CtrlUtil.FocusControl(txtInvoiceNo);
        }

        #endregion

        #region Private method
        private void RemoveRowUnused(SheetView sheet)
        {
            int lastRowNonEmpty = shtView.GetLastNonEmptyRow(NonEmptyItemFlag.Data);
            if (lastRowNonEmpty != shtView.RowCount - 1)
            {
                shtView.RemoveRows(shtView.RowCount - 1, 1);
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
                    shtView.Cells[row, (int)eColView.ITEM_DESC].Value = null;
                    shtView.Cells[row, (int)eColView.ORDER_UM_CLS].Value = null;
                    shtView.Cells[row, (int)eColView.INV_UM_CLS].Value = null;
                    shtView.Cells[row, (int)eColView.ORDER_UM_RATE].Value = null;
                    shtView.Cells[row, (int)eColView.INV_UM_RATE].Value = null;
                    return false;
                }

                ItemBIZ itemBIZ = new ItemBIZ();
                ItemDTO itemDTO = itemBIZ.LoadItem(ITEM_CD);
                shtView.Cells[row, (int)eColView.ITEM_CD].Value = itemDTO.ITEM_CD.Value;
                shtView.Cells[row, (int)eColView.ITEM_DESC].Value = itemDTO.ITEM_DESC.Value;
                //shtView.Cells[row, (int)eColView.ORDER_UM_CLS].Value = itemDTO.ORDER_UM_CLS.Value;
                //shtView.Cells[row, (int)eColView.INV_UM_CLS].Value = itemDTO.INV_UM_CLS.Value;
                //shtView.Cells[row, (int)eColView.ORDER_UM_RATE].Value = itemDTO.ORDER_UM_RATE.Value;
                //shtView.Cells[row, (int)eColView.INV_UM_RATE].Value = itemDTO.INV_UM_RATE.Value;

                //shtView.Cells[row, (int)eColView.LOT_CONTROL_CLS].Value = itemDTO.LOT_CONTROL_CLS.Value;



                //if (itemDTO.LOT_CONTROL_CLS == DataDefine.Convert2ClassCode(DataDefine.eLOT_CONTROL_CLS.Yes))
                //{
                //    //shtView.Cells[row, (int)eColView.LOT_NO].Value = dtReceiveDate.Value.Value.ToString(DataDefine.LOT_NO_FORMAT);

                //    if (rdoReceive.Checked)
                //    {
                //        RunningNumberBIZ runningNoBiz = new RunningNumberBIZ();

                //        NZString strLotNoPrefix = runningNoBiz.GenerateLotNoPrefix(new NZDateTime(null, dtReceiveDate.Value));
                //        NZInt iLastRunningNo = runningNoBiz.GetLastLotNoRunningBox(strLotNoPrefix, new NZString(cboStoredLoc, (string)cboStoredLoc.SelectedValue), itemDTO.ITEM_CD, new NZInt(null, 0));

                //        ReceivingEntryController rcvController = new ReceivingEntryController();
                //        NZString strLotNo = rcvController.GenerateLotNo(strLotNoPrefix, ref iLastRunningNo);
                //        shtView.Cells[row, (int)eColView.LOT_NO].Value = strLotNo.StrongValue;

                //    }
                //}
                //else
                //{
                //    shtView.Cells[row, (int)eColView.LOT_NO].Value = null;
                //}

                ItemProcessDTO processDTO = itemBIZ.LoadItemProcess(ITEM_CD);
                //shtView.Cells[row, (int)eColView.LOT_SIZE].Value = processDTO.LOT_SIZE.NVL(0);



            }

            return true;
        }
        #endregion

        #region Overriden method
        public override void OnSaveAndNew()
        {
            fpView.StopCellEditing();
            if (m_bRowHasModified)
            { // ถ้า Row กำลังแก้ไขอยู่
                if (!ValidateRowSpread(shtView.ActiveRowIndex, false))
                {
                    return;
                }
            }

            // ต้องเรียกก่อน Save เสมอ  เพื่อ Commit ข้อมูลการแก้ไขล่าสุดบน Grid
            // ใช้ได้เฉพาะกับ Sheet ที่ผูก DataSource
            CtrlUtil.SpreadSheetRowEndEdit(shtView, shtView.ActiveRowIndex);

            RemoveRowUnused(shtView);

            try
            {
                ItemValidator itemValidator = new ItemValidator();
                int row = shtView.Rows.Count;
                for (int i = 0; i < row; i++)
                {
                    NZString ItemCD = new NZString(null, shtView.Cells[i, (int)eColView.ITEM_CD].Value);
                    BusinessException err = itemValidator.CheckItemNotExist(ItemCD);
                    if (err != null)
                        ValidateException.ThrowErrorItem(err.Error);
                }

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, Message.LoadMessage(Messages.eConfirm.CFM9001.ToString()));
                if (dr == MessageDialogResult.Cancel)
                {
                    return;
                }
                if (dr == MessageDialogResult.Yes)
                {

                    //== Prepare data.
                    ReceivingEntryUIDM newModel = dmcReceive.SaveData(new ReceivingEntryUIDM());
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
            fpView.StopCellEditing();
            if (m_bRowHasModified)
            { // ถ้า Row กำลังแก้ไขอยู่
                if (!ValidateRowSpread(shtView.ActiveRowIndex, false))
                {
                    return;
                }
            }
            // ต้องเรียกก่อน Save เสมอ  เพื่อ Commit ข้อมูลการแก้ไขล่าสุดบน Grid
            // ใช้ได้เฉพาะกับ Sheet ที่ผูก DataSource
            CtrlUtil.SpreadSheetRowEndEdit(shtView, shtView.ActiveRowIndex);

            RemoveRowUnused(shtView);

            try
            {
                ItemValidator itemValidator = new ItemValidator();
                int row = shtView.Rows.Count;
                for (int i = 0; i < row; i++)
                {
                    NZString ItemCD = new NZString(null, shtView.Cells[i, (int)eColView.ITEM_CD].Value);
                    BusinessException err = itemValidator.CheckItemNotExist(ItemCD);
                    if (err != null)
                        ValidateException.ThrowErrorItem(err.Error);
                }

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, Message.LoadMessage(Messages.eConfirm.CFM9001.ToString()));
                if (dr == MessageDialogResult.Cancel)
                {
                    return;
                }

                if (dr == MessageDialogResult.Yes)
                {
                    //== Prepare data.
                    ReceivingEntryUIDM newModel = dmcReceive.SaveData(new ReceivingEntryUIDM());
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
        private void TRN020_Load(object sender, EventArgs e)
        {
            InitializeScreen();

            if (m_editReceiveNo == null)
            {
                SetScreenMode(Common.eScreenMode.ADD);
                ClearAll();

                m_model = new ReceivingEntryUIDM();
                dmcReceive.LoadData(m_model);

                SysConfigBIZ sysBiz = new SysConfigBIZ();
                SysConfigDTO argScreenInfo = new SysConfigDTO();
                argScreenInfo.SYS_GROUP_ID = DataDefine.eSYSTEM_CONFIG.TRN020.SYS_GROUP_ID;
                argScreenInfo.SYS_KEY = (NZString)DataDefine.eSYSTEM_CONFIG.TRN020.SYS_KEY.DEFAULT_DATE.ToString();
                dtReceiveDate.Value = sysBiz.GetDefaultDateForScreen(argScreenInfo);


                shtView.RowCount = 0;
                shtView.DataSource = m_model.DATA_VIEW;
                try
                {
                    if (rdoReceive.Checked)
                    {
                        cboStoredLoc.SelectedValue = m_strDefaultLocation;
                    }
                }
                catch
                {
                }

            }
            else
            {
                InventoryBIZ bizInventory = new InventoryBIZ();
                ClearAll();

                m_model = m_controller.LoadData(m_editReceiveNo);

                List<InventoryTransactionViewDTO> dtos = DTOUtility.ConvertDataTableToList<InventoryTransactionViewDTO>(m_model.DATA_VIEW);
                // bizInventory.LoadTransactionViewByReceiveNo(m_editReceiveNo);
                if (dtos.Count > 0)
                {
                    bool bCanEdit = m_transactionValidator.DateIsInCurrentPeriod(dtos[0].TRANS_DATE.StrongValue) == null;
                    if (bCanEdit)
                    {
                        SetScreenMode(Common.eScreenMode.EDIT);
                    }
                    else
                    {
                        SetScreenMode(Common.eScreenMode.VIEW);
                    }
                }
                else
                {
                    SetScreenMode(Common.eScreenMode.VIEW);
                }


                dmcReceive.LoadData(m_model);

                shtView.RowCount = 0;
                shtView.DataSource = m_model.DATA_VIEW;

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

        private void TRN020_Shown(object sender, EventArgs e)
        {
            if (m_screenMode == Common.eScreenMode.ADD)
            {
                CtrlUtil.FocusControl(dtReceiveDate);
            }
            else
            {
                CtrlUtil.FocusControl(fpView);
            }
        }

        private void TRN020_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = m_dialogResult;
        }
        #endregion

        #region Control event
        private void miAdd_Click(object sender, EventArgs e)
        {
            //m_keyboardSpread.OnActionAddNewRow();
            // DEFAULT LOT VALUE
            //if (rdoReceive.Checked && dtReceiveDate.Value.HasValue)
            //    shtView.Cells[shtView.Rows.Count - 1, (int)eColView.LOT_NO].Value = dtReceiveDate.Value.Value.ToString(DataDefine.LOT_NO_FORMAT);
        }
        private void miDelete_Click(object sender, EventArgs e)
        {
            //m_keyboardSpread.OnActionRemoveRow();

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
            for (int i = 0; i < shtView.Columns.Count; i++)
            {
                m_mapCellValue.Put((eColView)i, shtView.Cells[rowIndex, i].Value);
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
                    shtView.Cells[rowIndex, (int)m_mapCellValue[i].Key].Value = m_mapCellValue[i].Value;
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
                StoreCellValues(shtView.ActiveRowIndex);
            }
        }

        private void fpView_EditModeOff(object sender, EventArgs e)
        {

            int rowIndex = shtView.ActiveRowIndex;
            int colIndex = shtView.ActiveColumnIndex;

            bool bValidateCellPass = ValidateCellEdited(rowIndex, colIndex);
            if (!bValidateCellPass)
            {
                shtView.SetActiveCell(rowIndex, colIndex);
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
                    int lastRowNonEmpty = shtView.GetLastNonEmptyRow(NonEmptyItemFlag.Data);
                    if (lastRowNonEmpty != shtView.RowCount - 1)
                    {
                        shtView.RemoveRows(shtView.RowCount - 1, 1);
                    }
                    else
                    {
                        RestoreCellValues(shtView.ActiveRowIndex);
                    }

                    m_bRowHasModified = false;
                }
                else
                {
                    RemoveRowUnused(shtView);
                }
            }
        }

        private void fpView_ButtonClicked(object sender, EditorNotifyEventArgs e)
        {
            if (e.Column == (int)eColView.ITEM_CD_BTN)
            {

                ItemFindDialog dialog = null;

                if (chkFilterItem.Checked)
                {
                    //if (cboSupplierCode.ToNZString().IsNull)
                    //{
                    //    ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0105.ToString(), new object[] { this.lblSupplierCode.Text });
                    //    MessageDialog.ShowBusiness(this, error.Message);

                    //    return;
                    //}

                    dialog = new ItemFindDialog(eSqlOperator.In, null, cboSupplierCode.ToNZString(), DataDefine.eDealingType.Supplier);
                }
                else
                {
                    dialog = new ItemFindDialog(eSqlOperator.In, null);
                }
                dialog.ShowDialog(this);

                if (dialog.IsSelected)
                {
                    LoadItemIntoRow(e.Row, dialog.SelectedItem.ITEM_CD);
                }
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

                object objItemCode = shtView.GetValue(row, column);
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
                    NZDecimal orderRate = new NZDecimal(null, shtView.Cells[row, (int)eColView.ORDER_UM_RATE].Value);
                    NZDecimal invRate = new NZDecimal(null, shtView.Cells[row, (int)eColView.INV_UM_RATE].Value);
                    NZDecimal orderQty = new NZDecimal(null, shtView.Cells[row, (int)eColView.ORDER_QTY].Value);
                    NZDecimal price = new NZDecimal(null, shtView.Cells[row, (int)eColView.PRICE].Value);

                    decimal invQty = (invRate.NVL(0) / orderRate.NVL(1)) * orderQty.NVL(0);
                    decimal amount = price.NVL(0) * orderQty.NVL(0);

                    shtView.Cells[row, (int)eColView.QTY].Value = invQty;
                    shtView.Cells[row, (int)eColView.AMOUNT].Value = amount;
                }
                catch
                {
                    shtView.Cells[row, (int)eColView.AMOUNT].Value = 0;
                    shtView.Cells[row, (int)eColView.QTY].Value = 0;
                }
            }

            else if (column == (int)eColView.PRICE)
            {
                try
                {
                    NZDecimal orderQty = new NZDecimal(null, shtView.Cells[row, (int)eColView.ORDER_QTY].Value);
                    NZDecimal price = new NZDecimal(null, shtView.Cells[row, (int)eColView.PRICE].Value);

                    decimal amount = price.NVL(0) * orderQty.NVL(0);

                    shtView.Cells[row, (int)eColView.AMOUNT].Value = amount;
                }
                catch
                {
                    shtView.Cells[row, (int)eColView.AMOUNT].Value = 0;
                }
            }

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
            if (!forceValidate && !m_bRowHasModified)
                return true;

            //Check item
            string itemCode = shtView.Cells[row, (int)eColView.ITEM_CD].Text;

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
            NZDecimal qty = new NZDecimal(null, shtView.Cells[row, (int)eColView.ORDER_QTY].Value);
            if (qty.IsNull || qty.StrongValue == decimal.Zero)
            {
                ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0043.ToString());
                MessageDialog.ShowBusiness(this, error.Message);
                return false;
            }

            // ถ้า Validate Row ผ่าน แสดงว่า แถวนั้นไม่จำเป็นต้องเช็คอีกรอบ
            m_bRowHasModified = false;
            return true;
        }
        #endregion

        #endregion

        private void rdoReceiveReturn_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoReceive.Checked)
            {
                shtView.Columns[(int)eColView.PRICE].Locked = false;
                shtView.Columns[(int)eColView.SUPP_LOT_NO].Locked = false;
            }
            if (rdoReceiveReturn.Checked)
            {
                shtView.Columns[(int)eColView.PRICE].Locked = true;
                shtView.Columns[(int)eColView.SUPP_LOT_NO].Locked = true;
                int row = shtView.Rows.Count;
                for (int i = 0; i < row; i++)
                {
                    shtView.Cells[i, (int)eColView.PRICE].Text = string.Empty;
                    shtView.Cells[i, (int)eColView.SUPP_LOT_NO].Text = string.Empty;
                }
            }

            shtView.RowCount = 0;
            if (m_model.DATA_VIEW != null)
                m_model.DATA_VIEW.Rows.Clear();
            m_bRowHasModified = false;
        }

        private void dtReceiveDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtReceiveDate.Value.HasValue)
            {
                int row = shtView.Rows.Count;
                if (row > 0)
                {

                    RunningNumberBIZ runningNoBiz = new RunningNumberBIZ();

                    for (int i = 0; i < row; i++)
                    {
                        //shtView.Cells[i, (int)eColView.LOT_NO].Value = dtReceiveDate.Value.Value.ToString(DataDefine.LOT_NO_FORMAT);

                        string oLotControlCls = Convert.ToString(shtView.Cells[i, (int)eColView.LOT_CONTROL_CLS].Value);

                        string strItemCode = Convert.ToString(shtView.Cells[i, (int)eColView.ITEM_CD].Value);

                        if (oLotControlCls == DataDefine.Convert2ClassCode(DataDefine.eLOT_CONTROL_CLS.Yes))
                        {
                            //shtView.Cells[row, (int)eColView.LOT_NO].Value = dtReceiveDate.Value.Value.ToString(DataDefine.LOT_NO_FORMAT);

                            if (rdoReceive.Checked)
                            {

                                NZString strLotNoPrefix = runningNoBiz.GenerateLotNoPrefix(new NZDateTime(null, dtReceiveDate.Value));
                                NZInt iLastRunningNo = runningNoBiz.GetLastLotNoRunningBox(strLotNoPrefix, new NZString(cboStoredLoc, (string)cboStoredLoc.SelectedValue), (NZString)strItemCode, new NZInt(null, 0));

                                ReceivingEntryController rcvController = new ReceivingEntryController();
                                NZString strLotNo = rcvController.GenerateLotNo(strLotNoPrefix, ref iLastRunningNo);
                                shtView.Cells[i, (int)eColView.LOT_NO].Value = strLotNo.StrongValue;

                            }
                        }
                        else
                        {
                            shtView.Cells[i, (int)eColView.LOT_NO].Value = null;
                        }



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

        private void fpView_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }
    }
}
