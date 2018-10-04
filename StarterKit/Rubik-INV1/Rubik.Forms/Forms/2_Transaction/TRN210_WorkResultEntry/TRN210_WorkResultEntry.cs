using SystemMaintenance.Forms;
using EVOFramework.Data;
using EVOFramework.Windows.Forms;
using FarPoint.Win.Spread;
using Rubik.BIZ;
using CommonLib;
using EVOFramework;
using Rubik.Controller;
using Rubik.Forms.FindDialog;
using Rubik.UIDataModel;
using Rubik.Validators;
using Rubik.DTO;
using SystemMaintenance;
using Message = EVOFramework.Message;
using System.Windows.Forms;
using System.Collections.Generic;
using System;
using System.Data;
using System.ComponentModel;
using SystemMaintenance.BIZ;
using FarPoint.Win.Spread.Model;
using System.Drawing;

namespace Rubik.Transaction
{
    [Screen("TRN210", "Production Report Entry", eShowAction.Normal, eScreenType.Screen, "Production Report Entry")]
    public partial class TRN210_WorkResultEntry : CustomizeForm
    {
        #region Enum

        protected enum eScreenMode
        {
            IDLE,
            VIEW,
            ADD,
            EDIT
        } ;
        protected enum eNGInfoCol
        {
            TRANS_ID,
            NG_TRANS_ID,
            PROCESS_CD,
            NG_CRITERIA_CD,
            NG_CRITERIA_DESC,
            NG_WEIGHT,
            NG_QTY
        };

        #endregion

        #region Variables

        //private const string CONST_STR_QC_H_LOC = "QC-H";

        readonly ProductionReportController m_controller = new ProductionReportController();

        private DealingConstraintBIZ bizConstraint = new DealingConstraintBIZ();
        protected readonly LookupDataBIZ m_bizLookupData = new LookupDataBIZ();
        protected readonly InventoryBIZ m_bizInventory = new InventoryBIZ();
        protected readonly InventoryTransBIZ m_bizInventoryTrans = new InventoryTransBIZ();
        //protected readonly BOMBIZ m_bizBOM = new BOMBIZ();
        //protected readonly ItemBIZ m_bizItem = new ItemBIZ();

        protected readonly TransactionValidator m_transactionValidator = new TransactionValidator();

        protected eScreenMode m_screenMode = eScreenMode.IDLE;
        protected DialogResult m_dialogResult = DialogResult.Cancel;
        protected KeyboardSpread m_keyboardSpread = null;
        protected NZString m_editTransactionID = null;

        //protected const string DEFAULT_STORE_LOC_FOR_FG = "QAWH";

        //เอาไว้ check ตอน clear control ไม่ให้ระบบมันเด้ง error เรื่องของ partcode ที่ empty
        protected bool m_ClearControlBySystem = false;

        /// <summary>
        /// เก็บรายการของ Child Item ที่จะใช้ทำ Consumption
        /// ค่านี้จะใช้ตรวจสอบก่อนที่จะ
        /// </summary>
        protected List<ProductionReportEntryViewDTO> m_listRequireChildItems = new List<ProductionReportEntryViewDTO>();

        #endregion

        #region Constructor
        public TRN210_WorkResultEntry()
        {
            InitializeComponent();
        }
        public TRN210_WorkResultEntry(NZString transactionID)
        {
            InitializeComponent();

            m_editTransactionID = transactionID;
        }
        #endregion

        #region Initialize Screen
        protected void InitializeScreen()
        {
            InitializeComboBox();
            InitializeLookupData();
            InitlializeBindingControl();
            InitialFormat();
            InitializeKeyPress();
            InitializeSpread();

            InitialScreenMode();

            CheckCurrentInvPeriod();
        }
        protected void InitializeComboBox()
        {
            cboShift.Format += Common.ComboBox_Format;
            cboProcess.Format += Common.ComboBox_Format;
            //cboMachineNo.Format += Common.ComboBox_Format;
            cboSupplier.Format += Common.ComboBox_Format;
            cboPersonInCharge.Format += Common.ComboBox_Format;
        }
        protected void InitializeLookupData()
        {
            LookupData dataShiftCls = m_bizLookupData.LoadLookupClassType(DataDefine.SHIFT_CLS.ToNZString());
            cboShift.LoadLookupData(dataShiftCls);
            cboShift.SelectedIndex = -1;

            //------------ Location --------------------//
            //NZString[] locationtype = new NZString[1];
            //locationtype[0] = DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Production).ToNZString();
            //NZString[] exceptLocation = null;

            //List<DealingConstraintDTO> listExceptProcess = bizConstraint.LoadConstraintByValue(
            //    new NZString(null, DealingConstraintDTO.eColumns.NO_PRODUCTION_REPORT_FLAG.ToString()),
            //    new NZInt(null, 1));

            //exceptLocation = new NZString[listExceptProcess.Count];

            //for (int i = 0; i < listExceptProcess.Count; i++)
            //{
            //    exceptLocation[i] = new NZString(null, listExceptProcess[i].LOC_CD.NVL(""));
            //}

            ////DealingConstraintDTO constriant = bizConstraint.LoadDealingConstraint(CONST_STR_QC_H_LOC.ToNZString());
            ////if (constriant != null && constriant.NO_PRODUCTION_REPORT_FLAG.StrongValue == 1)
            ////{
            ////    exceptLocation = new NZString[1];
            ////    exceptLocation[0] = new NZString(null, CONST_STR_QC_H_LOC);
            ////}

            //if(!(string.Empty.Equals(txtMasterNo.Text.Trim()))
            //{
            //    NZString MasterNo = new NZString(txtMasterNo, txtMasterNo.Text.Trim());
            //    LookupData dataProductionProcess = m_bizLookupData.LoadLookupLocationByItem(MasterNo, exceptLocation);
            //    //LookupData dataProductionProcess = m_bizLookupData.LoadLookupLocation(locationtype, exceptLocation);
            //    cboProcess.LoadLookupData(dataProductionProcess);
            //    cboProcess.SelectedIndex = -1;
            //}
            //------------ Location --------------------//

            //BindMachineData(string.Empty, string.Empty);

            NZString[] suppliertype = new NZString[2]; //04 = Supplier
            suppliertype[0] = DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Vendor).ToNZString();
            suppliertype[1] = DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.CustomerVendor).ToNZString();


            LookupData dataSupplier = m_bizLookupData.LoadLookupLocation(suppliertype);
            cboSupplier.LoadLookupData(dataSupplier);
            cboSupplier.SelectedIndex = -1;

            LookupData dataPersonInCharge = m_bizLookupData.LoadPersonInCharge();
            cboPersonInCharge.LoadLookupData(dataPersonInCharge);
            cboPersonInCharge.SelectedIndex = -1;
        }
        protected void InitlializeBindingControl()
        {
            dmc.AddRangeControl
                (
                    hiddenTransactionID,
                    hiddenRefNo,
                    lblProductionReportNo,
                    dtProductionReportDate,
                    cboShift,
                    txtMasterNo,
                    txtPartNo,
                    txtCustomerName,
                    cboProcess,
                    cboMachineNo,
                    chkRework,
                    txtLotNo,
                    txtCustLotNo,
                    cboSupplier,
                    txtQtyKG,
                    txtQtyPCS,
                    cboPersonInCharge,
                    txtRemark,
                    txtTotalNG,
                    hiddenGroupTransID
                );
        }
        protected void InitialFormat()
        {
            FormatUtil.SetNumberFormat(txtOnHandQtyKG, FormatUtil.eNumberFormat.Qty_KG);
            FormatUtil.SetNumberFormat(txtOnHandQtyPCS, FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(txtQtyKG, FormatUtil.eNumberFormat.Qty_KG);
            FormatUtil.SetNumberFormat(txtQtyPCS, FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(txtTotalNG, FormatUtil.eNumberFormat.Qty_PCS);

            FormatUtil.SetNumberFormat(shtNGInfo.Columns[(int)eNGInfoCol.NG_WEIGHT], FormatUtil.eNumberFormat.Qty_KG);
            FormatUtil.SetNumberFormat(shtNGInfo.Columns[(int)eNGInfoCol.NG_QTY], FormatUtil.eNumberFormat.Qty_PCS);

            FormatUtil.SetDateFormat(dtProductionReportDate);
        }
        protected void InitializeKeyPress()
        {
            lblProductionReportNo.KeyPress += CtrlUtil.SetNextControl;
            dtProductionReportDate.KeyPress += CtrlUtil.SetNextControl;
            cboShift.KeyPress += CtrlUtil.SetNextControl;
            txtMasterNo.KeyPress += CtrlUtil.SetNextControl;
            txtPartNo.KeyPress += CtrlUtil.SetNextControl;
            txtCustomerName.KeyPress += CtrlUtil.SetNextControl;
            cboProcess.KeyPress += CtrlUtil.SetNextControl;
            cboMachineNo.KeyPress += CtrlUtil.SetNextControl;
            chkRework.KeyPress += CtrlUtil.SetNextControl;
            txtLotNo.KeyPress += CtrlUtil.SetNextControl;
            txtCustLotNo.KeyPress += CtrlUtil.SetNextControl;
            cboSupplier.KeyPress += CtrlUtil.SetNextControl;
            //txtQtyKG.KeyPress += CtrlUtil.SetNextControl;
            txtQtyPCS.KeyPress += CtrlUtil.SetNextControl;
            cboPersonInCharge.KeyPress += CtrlUtil.SetNextControl;
            txtRemark.KeyPress += CtrlUtil.SetNextControl;

            fpNGInfo.KeyPress += CtrlUtil.SetNextControl;
        }
        protected void InitializeSpread()
        {
            this.shtNGInfo.ActiveSkin = Common.ACTIVE_SKIN;

            m_keyboardSpread = new KeyboardSpread(fpNGInfo);
            m_keyboardSpread.RowAdding += new KeyboardSpread.RowAddingHandler(m_keyboardSpread_RowAdding);
            m_keyboardSpread.RowAdded += new KeyboardSpread.RowAddedHandler(m_keyboardSpread_RowAdded);
            m_keyboardSpread.RowRemoving += new KeyboardSpread.RowRemovingHandler(m_keyboardSpread_RowRemoving);

            fpNGInfo.LeaveCell += new LeaveCellEventHandler(fpNGInfo_LeaveCell);
            fpNGInfo.SubEditorOpening += CtrlUtil.SpreadDisableSubEditorOpening;
            CtrlUtil.MappingDataFieldWithEnum(shtNGInfo, typeof(eNGInfoCol));

            CtrlUtil.SpreadSetColumnsLocked(shtNGInfo, true, (int)eNGInfoCol.NG_CRITERIA_CD);
            CtrlUtil.SpreadSetColumnsLocked(shtNGInfo, true, (int)eNGInfoCol.NG_CRITERIA_DESC);
            CtrlUtil.SpreadSetColumnsLocked(shtNGInfo, true, (int)eNGInfoCol.NG_TRANS_ID);
            CtrlUtil.SpreadSetColumnsLocked(shtNGInfo, true, (int)eNGInfoCol.PROCESS_CD);
            CtrlUtil.SpreadSetColumnsLocked(shtNGInfo, true, (int)eNGInfoCol.TRANS_ID);
        }

        protected void InitialScreenMode()
        {
            if (m_editTransactionID == null)
                SetScreenMode(eScreenMode.ADD);
            else
            {
                ProductionReportEntryUIDM model = m_controller.LoadProductionReport(m_editTransactionID);

                //Load Combobox
                BindProcess(model.MASTER_NO.StrongValue);
                BindMachineData(model.MASTER_NO.StrongValue, model.PROCESS.StrongValue);

                dmc.LoadData(model);

                // Binding spread sheet with data table which has shcema, but no has any row.
                LoadDataTableIntoSpread(model.DataView);

                bool bCanEdit = m_transactionValidator.TransactionCanEditOrDelete(m_editTransactionID);
                if (bCanEdit)
                    SetScreenMode(eScreenMode.EDIT);
                else
                    SetScreenMode(eScreenMode.VIEW);
            }
        }

        protected void ClearScreen()
        {
            CtrlUtil.ClearControlData(hiddenTransactionID, hiddenRefNo, hiddenGroupTransID);
            CtrlUtil.ClearControlData(lblProductionReportNo, dtProductionReportDate, cboShift);
            CtrlUtil.ClearControlData(txtMasterNo, txtPartNo, txtCustomerName);
            CtrlUtil.ClearControlData(cboProcess, cboMachineNo, chkRework, txtLotNo, txtCustLotNo, cboSupplier);
            CtrlUtil.ClearControlData(txtQtyKG, txtQtyPCS, cboPersonInCharge, txtRemark, txtOnHandQtyKG, txtOnHandQtyPCS);

            //BindMachineData(string.Empty, string.Empty);
            cboMachineNo.DataSource = null;
            //CtrlUtil.EnabledControl(false,cboSupplier, txtCustLotNo);

            ClearNG();
        }
        protected void ClearNG()
        {
            shtNGInfo.RowCount = 0;
            if (shtNGInfo.DataSource != null)
                ((DataTable)shtNGInfo.DataSource).Rows.Clear();
            CtrlUtil.ClearControlData(txtTotalNG);
        }

        #endregion

        #region Keyboard Spread
        protected void m_keyboardSpread_RowAdding(object sender, EventRowAdding e)
        {
            //KeyboardSpread a = (KeyboardSpread)sender;
            //if (a.IsBinded) {
            //    if (a.Owner == fpNGInfo) {
            //        int lastRowNonEmpty = shtNGInfo.GetLastNonEmptyRow(NonEmptyItemFlag.Data);
            //        if (lastRowNonEmpty == shtNGInfo.RowCount - 1) {
            //            if ("".Equals(shtNGInfo.Cells[lastRowNonEmpty, (int)eNGInfoCol.NG_QTY].Text)
            //                ) {
            //                e.Cancel = true;
            //            }
            //        }

            //    }
            //}
        }
        protected void m_keyboardSpread_RowAdded(object sender, int rowIndex)
        {
            //CtrlUtil.SpreadSetCellLocked(shtView, false, rowIndex, (int)eColView.LOC_BTN);

            //CtrlUtil.SpreadSetCellLocked(shtView, false, rowIndex, (int)eColView.ITEM_CD);
            //CtrlUtil.SpreadSetCellLocked(shtView, false, rowIndex, (int)eColView.ITEM_CD_BTN);

            // fix for Add New Row
            //((DataTable)shtView.DataSource).Rows[rowIndex][(int)eColView.CHILD_ORDER_LOC_CD] 

            //shtView.Cells[rowIndex, (int)eColView.CHILD_ORDER_LOC_CD].Value = cboOrderLoc.SelectedValue;


            // ((DataTable)shtView.DataSource).Rows[rowIndex][WorkResultEntryViewDTO.eColumns.ITEM_CD.ToString()]

            //((DataTable)shtView.DataSource).Rows[rowIndex][WorkResultEntryViewDTO.eColumns.LOC_CD.ToString()] = GetConsumptionLocation(Convert.ToString(shtView.Cells[rowIndex, (int)eColView.ITEM_CD].Value));

            //// fix for Add New Row
            //((DataTable)shtView.DataSource).Rows[rowIndex][(int)eColView.CHILD_ORDER_LOC_CD] = cboOrderLoc.SelectedValue;//.Cells[rowIndex, 2].Value = cboOrderLoc.SelectedValue;
        }

        protected void m_keyboardSpread_RowRemoving(object sender, EventRowRemoving e)
        {
            MessageDialogResult dr = MessageDialog.ShowConfirmation(this, Message.LoadMessage(Messages.eConfirm.CFM9002.ToString()), MessageDialogButtons.YesNo);
            if (dr == MessageDialogResult.No)
            {
                e.Cancel = true;
            }
        }
        #endregion

        #region Screen mode
        protected void SetScreenMode(eScreenMode mode)
        {
            m_screenMode = mode;

            switch (mode)
            {
                case eScreenMode.VIEW:

                    CtrlUtil.EnabledControl(false, dtProductionReportDate, cboShift);
                    CtrlUtil.EnabledControl(false, txtMasterNo, btnSearchMasterNo, txtPartNo, txtCustomerName);
                    CtrlUtil.EnabledControl(false, cboProcess, cboMachineNo, chkRework);
                    CtrlUtil.EnabledControl(false, txtLotNo, txtCustLotNo, cboSupplier);
                    CtrlUtil.EnabledControl(false, txtQtyKG, txtQtyPCS);
                    CtrlUtil.EnabledControl(false, cboPersonInCharge, txtRemark);
                    CtrlUtil.EnabledControl(false, txtOnHandQtyKG, txtOnHandQtyPCS, txtTotalNG);

                    shtNGInfo.OperationMode = OperationMode.ReadOnly;
                    CtrlUtil.SpreadSetColumnsLocked(shtNGInfo, true, (int)eNGInfoCol.NG_CRITERIA_DESC);
                    CtrlUtil.SpreadSetColumnsLocked(shtNGInfo, true, (int)eNGInfoCol.NG_WEIGHT);
                    CtrlUtil.SpreadSetColumnsLocked(shtNGInfo, true, (int)eNGInfoCol.NG_QTY);

                    tsbSaveAndNew.Enabled = false;
                    tsbSaveAndClose.Enabled = false;

                    break;
                case eScreenMode.ADD:

                    ClearScreen();

                    SysConfigBIZ sysBiz = new SysConfigBIZ();
                    SysConfigDTO argScreenInfo = new SysConfigDTO();
                    argScreenInfo.SYS_GROUP_ID = DataDefine.eSYSTEM_CONFIG.TRN210.SYS_GROUP_ID;
                    argScreenInfo.SYS_KEY = (NZString)DataDefine.eSYSTEM_CONFIG.TRN210.SYS_KEY.DEFAULT_DATE.ToString();
                    dtProductionReportDate.Value = sysBiz.GetDefaultDateForScreen(argScreenInfo);

                    CtrlUtil.EnabledControl(true, dtProductionReportDate, cboShift);
                    CtrlUtil.EnabledControl(true, txtMasterNo, btnSearchMasterNo);
                    CtrlUtil.EnabledControl(false, txtCustomerName, txtPartNo);
                    CtrlUtil.EnabledControl(true, cboProcess, cboMachineNo, chkRework);
                    CtrlUtil.EnabledControl(true, txtLotNo);
                    CtrlUtil.EnabledControl(true, txtQtyKG, txtQtyPCS);
                    CtrlUtil.EnabledControl(true, cboPersonInCharge, txtRemark);
                    CtrlUtil.EnabledControl(false, txtOnHandQtyKG, txtOnHandQtyPCS, txtTotalNG);
                    CtrlUtil.EnabledControl(false, txtCustLotNo, cboSupplier);

                    m_keyboardSpread.StartBind();
                    shtNGInfo.OperationMode = OperationMode.Normal;
                    CtrlUtil.SpreadSetColumnsLocked(shtNGInfo, true, (int)eNGInfoCol.NG_CRITERIA_DESC);
                    CtrlUtil.SpreadSetColumnsLocked(shtNGInfo, false, (int)eNGInfoCol.NG_WEIGHT);
                    CtrlUtil.SpreadSetColumnsLocked(shtNGInfo, false, (int)eNGInfoCol.NG_QTY);

                    tsbSaveAndNew.Enabled = true;
                    tsbSaveAndClose.Enabled = true;

                    dtProductionReportDate.Focus();

                    break;
                case eScreenMode.EDIT:

                    CtrlUtil.EnabledControl(false, dtProductionReportDate, cboShift);
                    CtrlUtil.EnabledControl(false, txtMasterNo, btnSearchMasterNo, txtCustomerName, cboProcess, txtPartNo);
                    CtrlUtil.EnabledControl(true, cboMachineNo, chkRework);
                    CtrlUtil.EnabledControl(true, txtLotNo);//, txtCustLotNo, cboSupplier);
                    CtrlUtil.EnabledControl(true, txtQtyKG, txtQtyPCS);
                    CtrlUtil.EnabledControl(true, cboPersonInCharge, txtRemark);
                    CtrlUtil.EnabledControl(false, txtOnHandQtyKG, txtOnHandQtyPCS, txtTotalNG);

                    m_keyboardSpread.StartBind();
                    shtNGInfo.OperationMode = OperationMode.Normal;
                    CtrlUtil.SpreadSetColumnsLocked(shtNGInfo, true, (int)eNGInfoCol.NG_CRITERIA_DESC);
                    CtrlUtil.SpreadSetColumnsLocked(shtNGInfo, false, (int)eNGInfoCol.NG_WEIGHT);
                    CtrlUtil.SpreadSetColumnsLocked(shtNGInfo, false, (int)eNGInfoCol.NG_QTY);

                    tsbSaveAndNew.Enabled = true;
                    tsbSaveAndClose.Enabled = true;

                    //Set contraint
                    if(cboProcess.SelectedValue != null)
                        EnableControlWithConstraint(cboProcess.SelectedValue.ToString());

                    break;
            }
        }
        #endregion

        #region Override method
        public override void OnSaveAndNew()
        {
            fpNGInfo.StopCellEditing();
            if (m_bRowHasModified)
            { // ถ้า Row กำลังแก้ไขอยู่
                if (!ValidateRowSpread(shtNGInfo.ActiveRowIndex, false))
                {
                    return;
                }
            }
            // ต้องเรียกก่อน Save เสมอ  เพื่อ Commit ข้อมูลการแก้ไขล่าสุดบน Grid
            // ใช้ได้เฉพาะกับ Sheet ที่ผูก DataSource
            CtrlUtil.SpreadSheetRowEndEdit(shtNGInfo, shtNGInfo.ActiveRowIndex);
            RemoveRowUnused(shtNGInfo);

            ////if (txtItemCode.SelectedItemData != null)
            ////    numWorkResultQty_KeyPress(numWorkResultQty, new KeyPressEventArgs((char)Keys.Return));

            try
            {
                CalculateTotalNG();

                ValidateBeforeSave();

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, Message.LoadMessage(Messages.eConfirm.CFM9001.ToString()));
                if (dr == MessageDialogResult.Cancel)
                {
                    return;
                }
                if (dr == MessageDialogResult.Yes)
                {
                    ProductionReportEntryUIDM model = dmc.SaveData(new ProductionReportEntryUIDM());
                    model.DataView = (DataTable)shtNGInfo.DataSource;
                    model.DataView.AcceptChanges();

                    if (m_screenMode == eScreenMode.ADD)
                        m_controller.SaveNewProductionReport(model);
                    else
                        m_controller.SaveUpdateProductionReport(model);

                    MessageDialog.ShowInformation(this, null, Message.LoadMessage(Messages.eInformation.INF9003.ToString()).MessageDescription);
                    SetScreenMode(eScreenMode.ADD);
                    m_dialogResult = DialogResult.OK;
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

        public override void OnSaveAndClose()
        {
            fpNGInfo.StopCellEditing();
            if (m_bRowHasModified)
            { // ถ้า Row กำลังแก้ไขอยู่
                if (!ValidateRowSpread(shtNGInfo.ActiveRowIndex, false))
                {
                    return;
                }
            }
            // ต้องเรียกก่อน Save เสมอ  เพื่อ Commit ข้อมูลการแก้ไขล่าสุดบน Grid
            // ใช้ได้เฉพาะกับ Sheet ที่ผูก DataSource
            CtrlUtil.SpreadSheetRowEndEdit(shtNGInfo, shtNGInfo.ActiveRowIndex);
            RemoveRowUnused(shtNGInfo);

            ////if (txtItemCode.SelectedItemData != null)
            ////    numWorkResultQty_KeyPress(numWorkResultQty, new KeyPressEventArgs((char)Keys.Return));

            try
            {
                CalculateTotalNG();
                
                ValidateBeforeSave();

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, Message.LoadMessage(Messages.eConfirm.CFM9001.ToString()));
                if (dr == MessageDialogResult.Cancel)
                {
                    return;
                }
                if (dr == MessageDialogResult.Yes)
                {
                    ProductionReportEntryUIDM model = dmc.SaveData(new ProductionReportEntryUIDM());
                    model.DataView = (DataTable)shtNGInfo.DataSource;
                    model.DataView.AcceptChanges();

                    if (m_screenMode == eScreenMode.ADD)
                        m_controller.SaveNewProductionReport(model);
                    else
                        m_controller.SaveUpdateProductionReport(model);

                    MessageDialog.ShowInformation(this, null, Message.LoadMessage(Messages.eInformation.INF9003.ToString()).MessageDescription);
                    m_dialogResult = DialogResult.OK;
                    this.Close();
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

        #region Load Data

        protected void BindProcess(string strMasterNo) 
        {
            cboProcess.Text = string.Empty;
            cboProcess.DataSource = null;

            if (string.Empty.Equals(strMasterNo))
                return;

            NZString[] locationtype = new NZString[1];
            locationtype[0] = DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Production).ToNZString();
            NZString[] exceptLocation = null;

            List<DealingConstraintDTO> listExceptProcess = bizConstraint.LoadConstraintByValue(
                new NZString(null, DealingConstraintDTO.eColumns.NO_PRODUCTION_REPORT_FLAG.ToString()),
                new NZInt(null, 1));

            exceptLocation = new NZString[listExceptProcess.Count];

            for (int i = 0; i < listExceptProcess.Count; i++) {
                exceptLocation[i] = new NZString(null, listExceptProcess[i].LOC_CD.NVL(""));
            }

            //DealingConstraintDTO constriant = bizConstraint.LoadDealingConstraint(CONST_STR_QC_H_LOC.ToNZString());
            //if (constriant != null && constriant.NO_PRODUCTION_REPORT_FLAG.StrongValue == 1)
            //{
            //    exceptLocation = new NZString[1];
            //    exceptLocation[0] = new NZString(null, CONST_STR_QC_H_LOC);
            //}

            LookupData dataProductionProcess = m_bizLookupData.LoadLookupLocationByItem(strMasterNo.ToNZString(), exceptLocation);
            DataTable dt = (DataTable)dataProductionProcess.DataSource;
            if (dt == null || dt.Rows.Count == 0)
                MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0217.ToString()));            
            
            //LookupData dataProductionProcess = m_bizLookupData.LoadLookupLocation(locationtype, exceptLocation);
            cboProcess.LoadLookupData(dataProductionProcess);
            cboProcess.SelectedIndex = -1;
            
        }
        private void BindMachineData(string strMasterNo, string strProcess)
        {
            if (string.Empty.Equals(strMasterNo))
                return;
            if (string.Empty.Equals(strProcess))
                return;

            NZString ItemCD = new NZString(txtMasterNo, strMasterNo);
            NZString Process = new NZString(cboProcess, strProcess);
            LookupData dataMachine = m_bizLookupData.LoadMachineByProcess(ItemCD, Process);

            //DataTable dt = dataMachine.DataSource;
            cboMachineNo.Text = string.Empty;
            cboMachineNo.LoadLookupData(dataMachine);
            if (cboMachineNo.Items.Count > 0)
                cboMachineNo.SelectedIndex = -1;
        }
        /// <summary>
        /// Load new consumption list by input: item code, order location and qty.
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="orderLoc"></param>
        /// <param name="qty"></param>
        protected void LoadDataByItem()
        {
#warning Waiting for implement new consumption style (no/manual/auto).

            //==============================
            // Load data into spread and set focus to spread.
            ProductionReportEntryUIDM model = dmc.SaveData(new ProductionReportEntryUIDM());

            List<ProductionReportEntryViewDTO> listItems = m_controller.LoadNGCriteria(model.PROCESS);

            //foreach (WorkResultEntryViewDTO dtoListConsumption in listItems)
            //{
            //    if (!dtoListConsumption.CHILD_ORDER_LOC_CD.IsNull)
            //    {
            //        dtoListConsumption.LOC_CD = dtoListConsumption.CHILD_ORDER_LOC_CD;
            //    }
            //}

            model.DataView = DTOUtility.ConvertListToDataTable(listItems);

            // Adjust state all rows to "Added".
            model.DataView.AcceptChanges();

            if (m_screenMode == eScreenMode.ADD)
            {
                for (int i = 0; i < model.DataView.Rows.Count; i++)
                {
                    model.DataView.Rows[i].SetAdded();
                }
            }

            // Initialize Require Child Item Consumption List.
            m_listRequireChildItems.Clear();
            m_listRequireChildItems.AddRange(listItems);

            // generate spread.
            if (m_screenMode == eScreenMode.ADD)
            {
                // If mode ADD will generate new data to display.
                LoadDataTableIntoSpread(model.DataView);
            }
            else
            {
                //    //Modify by Bunyapat L.
                //    //28 Apr 2011
                //    //ถ้า Auto consumption ให้คำนวณจาก BOM ใหม่เฉยๆแล้ว list มาเลยว่าต้องใช้เท่าไร
                //    //แล้วใน ตอน save ค่อยสั่ง clear consumption แทน
                //    if (model.CONSUMTION_CLS.StrongValue == DataDefine.Convert2ClassCode(DataDefine.eCONSUMPTION_CLS.Auto))
                //    {
                //        LoadDataTableIntoSpread(model.DataView);
                //    }
                //    else
                //    {
                //        // If mode Update, will calculate request qty again.
                //        for (int i = 0; i < shtView.RowCount; i++)
                //        {
                //            NZObject item_cd = new NZObject(null, shtView.Cells[i, (int)eColView.ITEM_CD].Value);
                //            NZObject lot_no = new NZObject(null, shtView.Cells[i, (int)eColView.LOT_NO].Value);

                //            for (int j = 0; j < listItems.Count; j++)
                //            {
                //                if (Equals(item_cd.Value, listItems[j].ITEM_CD.Value))
                //                {
                //                    shtView.Cells[i, (int)eColView.REQUEST_QTY].Value = listItems[j].REQUEST_QTY.Value;
                //                    shtView.Cells[i, (int)eColView.CONSUMPTION_QTY].Value = listItems[j].CONSUMPTION_QTY.Value;
                //                    break;
                //                }
                //            }
                //        }

                //        // Commit all row in DataTable.
                //        if (shtView.DataSource != null)
                //        {
                //            DataTable dtView = (DataTable)shtView.DataSource;
                //            for (int i = 0; i < dtView.Rows.Count; i++)
                //            {
                //                dtView.Rows[i].EndEdit();
                //            }
                //        }
                //    }
            }


        }
        private void LoadOnHandQty(NZString MasterNo, NZString Process, NZDecimal Qty)
        {
            decimal decOnHandQty = 0;

            //Load Onhand Qty
            InventoryBIZ bizInv = new InventoryBIZ();

            InventoryOnhandDTO dtoOnhand = bizInv.LoadInventoryOnHandByCurrentPeriod(MasterNo, Process, new NZString(), new NZString());
            if (dtoOnhand != null)
            {
                txtOnHandQtyPCS.Decimal = dtoOnhand.ON_HAND_QTY.StrongValue;
            }

            if (!Qty.IsNull)
                txtOnHandQtyPCS.Decimal = decOnHandQty + Qty;
        }
        protected void LoadDataTableIntoSpread(DataTable dtView)
        {
            shtNGInfo.RowCount = 0;
            shtNGInfo.DataSource = dtView;

            //if (dtView == null)
            //    return;

            //foreach (DataRow dr in dtView.Rows) 
            //{
            //    shtNGInfo.RowCount = shtNGInfo.RowCount + 1;
            //    shtNGInfo.Cells[shtNGInfo.RowCount - 1, (int)eNGInfoCol.TRANS_ID].Value = dr[(int)eNGInfoCol.TRANS_ID];
            //    shtNGInfo.Cells[shtNGInfo.RowCount - 1, (int)eNGInfoCol.NG_TRANS_ID].Value = dr[(int)eNGInfoCol.NG_TRANS_ID];
            //    shtNGInfo.Cells[shtNGInfo.RowCount - 1, (int)eNGInfoCol.PROCESS_CD].Value = dr[(int)eNGInfoCol.PROCESS_CD];
            //    shtNGInfo.Cells[shtNGInfo.RowCount - 1, (int)eNGInfoCol.NG_CRITERIA_CD].Value = dr[(int)eNGInfoCol.NG_CRITERIA_CD];
            //    shtNGInfo.Cells[shtNGInfo.RowCount - 1, (int)eNGInfoCol.NG_CRITERIA_DESC].Value = dr[(int)eNGInfoCol.NG_CRITERIA_DESC];
            //    shtNGInfo.Cells[shtNGInfo.RowCount - 1, (int)eNGInfoCol.NG_QTY].Value = dr[(int)eNGInfoCol.NG_QTY];
            //    shtNGInfo.Cells[shtNGInfo.RowCount - 1, (int)eNGInfoCol.NG_WEIGHT].Value = dr[(int)eNGInfoCol.NG_WEIGHT];                
            //}                

            //for (int i = 0; i < shtNGInfo.RowCount; i++) {
            //    DataRowView drv = CtrlUtil.SpreadGetDataRowFromRowIndex(shtNGInfo, i);
            //    if (drv == null)
            //        continue;

            //    bool bEditMode = m_screenMode == eScreenMode.ADD || m_screenMode == eScreenMode.EDIT;
            //    CtrlUtil.SpreadSetCellLocked(shtNGInfo, false, i, (int)eNGInfoCol.NG_WEIGHT);
            //    CtrlUtil.SpreadSetCellLocked(shtNGInfo, false, i, (int)eNGInfoCol.NG_QTY);
            //}

            //shtView.RowCount = 0;
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
            //shtView.DataSource = dtView;

            //// update locked cell by condition on each row.
            //for (int i = 0; i < shtView.RowCount; i++)
            //{
            //    DataRowView drv = CtrlUtil.SpreadGetDataRowFromRowIndex(shtView, i);
            //    if (drv == null)
            //        continue;

            //    bool bEditMode = m_screenMode == eScreenMode.EDIT || m_screenMode == eScreenMode.VIEW;
            //    CtrlUtil.SpreadSetCellLocked(shtView, bEditMode, i, (int)eColView.ITEM_CD);
            //    CtrlUtil.SpreadSetCellLocked(shtView, bEditMode, i, (int)eColView.ITEM_CD_BTN);
            //    CtrlUtil.SpreadSetCellLocked(shtView, bEditMode, i, (int)eColView.LOT_NO);
            //    CtrlUtil.SpreadSetCellLocked(shtView, bEditMode, i, (int)eColView.LOT_BTN);
            //    CtrlUtil.SpreadSetCellLocked(shtView, bEditMode, i, (int)eColView.LOC_BTN);
            //    if (eConsumptionCls == DataDefine.eCONSUMPTION_CLS.Auto)
            //    {
            //        CtrlUtil.SpreadSetCellLocked(shtView, true, i, (int)eColView.ITEM_CD);
            //        CtrlUtil.SpreadSetCellLocked(shtView, true, i, (int)eColView.ITEM_CD_BTN);
            //        CtrlUtil.SpreadSetCellLocked(shtView, true, i, (int)eColView.LOT_NO);
            //        CtrlUtil.SpreadSetCellLocked(shtView, true, i, (int)eColView.LOT_BTN);
            //        CtrlUtil.SpreadSetCellLocked(shtView, true, i, (int)eColView.LOC_BTN);
            //        CtrlUtil.SpreadSetCellLocked(shtView, true, i, (int)eColView.CONSUMPTION_QTY);
            //    }
            //    else
            //    {
            //        CtrlUtil.SpreadSetCellLocked(shtView, false, i, (int)eColView.CONSUMPTION_QTY);
            //        if (!bEditMode && m_screenMode != eScreenMode.VIEW)
            //        {
            //            if (Equals(drv[WorkResultEntryViewDTO.eColumns.LOT_CONTROL_CLS.ToString()], DataDefine.Convert2ClassCode(DataDefine.eLOT_CONTROL_CLS.No)))
            //            {
            //                // Lot class == "NO"
            //                CtrlUtil.SpreadSetCellLocked(shtView, true, i, (int)eColView.LOT_NO);
            //                CtrlUtil.SpreadSetCellLocked(shtView, true, i, (int)eColView.LOT_BTN);
            //                CtrlUtil.SpreadSetCellLocked(shtView, false, i, (int)eColView.LOC_BTN);
            //            }
            //            else
            //            {
            //                CtrlUtil.SpreadSetCellLocked(shtView, false, i, (int)eColView.LOT_NO);
            //                CtrlUtil.SpreadSetCellLocked(shtView, false, i, (int)eColView.LOT_BTN);
            //                CtrlUtil.SpreadSetCellLocked(shtView, false, i, (int)eColView.LOC_BTN);
            //                NZString itemCode = new NZString(null, shtView.Cells[i, (int)eColView.ITEM_CD].Value);

            //                // Lookup Lot No
            //                //LookupData lookupLotNo = m_bizLookupData.LoadLookupLotNo(itemCode, new NZString(null, cboOrderLoc.SelectedValue), dtWorkResultDate.Value.Value.ToString("yyyyMM").ToNZString());
            //                //shtView.Cells[i, (int)eColView.LOT_NO].CellType = CtrlUtil.CreateComboBoxCellType(lookupLotNo, false);
            //            }
            //        }
            //    }

            //}

        }

        #endregion

        #region Private method

        protected void RemoveRowUnused(SheetView sheet)
        {
            int lastRowNonEmpty = sheet.GetLastNonEmptyRow(NonEmptyItemFlag.Data);
            if (lastRowNonEmpty != sheet.RowCount - 1)
            {
                sheet.RemoveRows(sheet.RowCount - 1, 1);
            }
        }
        protected void CalculateTotalNG()
        {
            decimal decTotalNG = 0;
            decimal decNG = 0;
            for (int i = 0; i < shtNGInfo.RowCount; i++)
            {
                if (shtNGInfo.Cells[i, (int)eNGInfoCol.NG_QTY].Value != null)
                {
                    decNG = Convert.ToDecimal(shtNGInfo.Cells[i, (int)eNGInfoCol.NG_QTY].Value);
                    decTotalNG = decTotalNG + decNG;
                }
            }

            txtTotalNG.Decimal = decTotalNG;
        }
        private void ValidateBeforeSave()
        {
            ProductionReportValidator validator = new ProductionReportValidator();
            ValidateException error = new ValidateException();
            ErrorItem errorItem = null;

            string strLotNo = txtLotNo.Text.Trim();
            if (!(string.Empty.Equals(strLotNo)))            
                CommonLib.FormatUtil.CheckFormatLotNo(new NZString(txtLotNo, strLotNo));

            errorItem = validator.CheckWorkResultDate(new NZDateTime(dtProductionReportDate, dtProductionReportDate.Value));
            if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);//error.AddError(errorItem);

            errorItem = validator.CheckEmptyShiftType(new NZString(cboShift, cboShift.SelectedValue));
            if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);//error.AddError(errorItem);

            errorItem = validator.CheckEmptyMasterNo(new NZString(txtMasterNo, txtMasterNo.Text));
            if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);//error.AddError(errorItem);

            errorItem = validator.CheckMoveProcess(new NZString(cboProcess, cboProcess.SelectedValue));
            if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);//error.AddError(errorItem);           

            errorItem = validator.CheckProductionQty(txtQtyPCS.ToNZDecimal());
            if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);//error.AddError(errorItem);

            //error.ThrowIfHasError();
        }

        protected void ClearAll()
        {
            //m_ClearControlBySystem = true;
            //CtrlUtil.ClearControlData(txtWorkOrderNo, txtGoodQty, lblWorkResultNo, stcWorkResultNo
            //    , dtWorkResultDate, txtItemCode, txtItemDesc, cboOrderLoc, cboStoredLoc
            //    , txtLotNo, numWorkResultQty, txtGoodQty, txtNGQty, txtRemark, txtNGQty
            //    , txtReserveQty, txtNGReason, txtLotSize
            //    );
            //lblWorkResultNo.Text = string.Empty;
            //shtView.RowCount = 0;
            //if (shtView.DataSource != null)
            //    ((DataTable)shtView.DataSource).Rows.Clear();

            //m_ClearControlBySystem = false;
        }
        protected void ClearAllExceptDefaultValue()
        {
            //m_ClearControlBySystem = true;
            //CtrlUtil.ClearControlData(txtWorkOrderNo, txtGoodQty, lblWorkResultNo, stcWorkResultNo
            //    , txtItemCode, txtItemDesc, cboOrderLoc, cboStoredLoc
            //    , txtLotNo, numWorkResultQty, txtGoodQty, txtNGQty, txtRemark, txtNGQty
            //    , txtReserveQty, txtNGReason, txtLotSize
            //    );
            //lblWorkResultNo.Text = string.Empty;
            //shtView.RowCount = 0;
            //if (shtView.DataSource != null)
            //    ((DataTable)shtView.DataSource).Rows.Clear();
            //m_ClearControlBySystem = false;
        }

        private void EnableControlWithConstraint(string strProcess)
        {
            //----- Enable Customer Lot No ------//
            DealingConstraintDTO constriant = null;

            //string strProcess = cboProcess.SelectedValue.ToString();
            constriant = bizConstraint.LoadDealingConstraint(strProcess.ToNZString());

            if (constriant != null && constriant.ENABLE_CUST_LOT_FLAG.StrongValue == 1)
                CtrlUtil.EnabledControl(true, txtCustLotNo);
            else
                CtrlUtil.EnabledControl(false, txtCustLotNo);

            //----- Enable Supplier ------//                
            if (constriant != null && constriant.ENABLE_SUPPLIER_FLAG.StrongValue == 1)
                CtrlUtil.EnabledControl(true, cboSupplier);
            else
                CtrlUtil.EnabledControl(false, cboSupplier);
        }

        /// <summary>
        /// Get child item from List of ChildItems global variables.
        /// </summary>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        protected ProductionReportEntryViewDTO GetChildItem(NZString itemCode)
        {
            if (m_listRequireChildItems == null)
                return null;

            for (int i = 0; i < m_listRequireChildItems.Count; i++)
            {
                if (Equals(m_listRequireChildItems[i].NG_CRITERIA_CD.Value, itemCode.Value))
                {
                    return m_listRequireChildItems[i];
                }
            }

            return null;
        }
        protected NZDecimal SumConsumptionQtyByItem(NZString itemCode, params int[] excludeRow)
        {
            NZDecimal sumQty = new NZDecimal(null, 0);

            //for (int i = 0; i < shtView.RowCount; i++)
            //{

            //    // check row for not calculate.
            //    bool bExclude = false;
            //    for (int iExclude = 0; iExclude < excludeRow.Length; iExclude++)
            //    {
            //        if (i == excludeRow[iExclude])
            //        {
            //            bExclude = true;
            //            break;
            //        }
            //    }

            //    if (bExclude)
            //        continue;

            //    // summary.
            //    DataRowView drv = CtrlUtil.SpreadGetDataRowFromRowIndex(shtView, i);
            //    if (Equals(drv[WorkResultEntryViewDTO.eColumns.ITEM_CD.ToString()], itemCode.StrongValue))
            //    {
            //        NZDecimal qty = new NZDecimal(null, drv[WorkResultEntryViewDTO.eColumns.CONSUMPTION_QTY.ToString()]);
            //        sumQty.Value = sumQty.StrongValue + qty.NVL(0);
            //    }
            //}

            return sumQty;
        }
        #endregion

        #region Form event
        protected void TRN080_Load(object sender, EventArgs e)
        {
            InitializeScreen();
        }
        protected void TRN080_Shown(object sender, EventArgs e)
        {
            //if (m_screenMode == eScreenMode.ADD)
            //{
            //    CtrlUtil.FocusControl(txtWorkOrderNo);
            //    //if (dtWorkResultDate.Value.HasValue && txtLotNo.Text.Trim() == string.Empty) {
            //    //    txtLotNo.Text = dtWorkResultDate.Value.Value.ToString("yyyyMMdd");
            //    //}
            //}
            //else
            //{
            //    CtrlUtil.FocusControl(txtGoodQty);
            //}
        }
        protected void TRN080_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = m_dialogResult;
        }
        #endregion

        #region Control event

        protected void txtRemark_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == '\r')
            //{
            //    tslControl.Select();
            //    tsbSaveAndNew.Select();

            //}
        }
        protected void numWorkResultQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                txtQtyKG.Clear();
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
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
            //if (e.KeyChar == '\r')
            //{
            //    e.Handled = true;
            //    try
            //    {
            //        NZString ComsumptionCls = cboConsumptionCls.SelectedValue == null ? new NZString() : cboConsumptionCls.SelectedValue.ToString().ToNZString();
            //        // Validate data before load data into spread.
            //        WorkResultEntryValidator validator = new WorkResultEntryValidator();
            //        validator.ValidateBeforeLoadConsumption(txtItemCode.ToNZString(), cboOrderLoc.ToNZString(), numWorkResultQty.ToNZDecimal(), ComsumptionCls);

            //        LoadDataByItem(txtItemCode.ToNZString(), cboOrderLoc.ToNZString(), numWorkResultQty.ToNZDecimal());
            //        e.Handled = false;
            //    }
            //    catch (ValidateException err)
            //    {
            //        MessageDialog.ShowBusiness(this, err.ErrorResults[0].Message);
            //        err.ErrorResults[0].FocusOnControl();
            //    }
            //    catch (BusinessException err)
            //    {
            //        MessageDialog.ShowBusiness(this, err.Error.Message);
            //        err.Error.FocusOnControl();
            //    }
            //    catch (Exception err)
            //    {
            //        MessageDialog.ShowBusiness(this, err.Message);
            //        System.Diagnostics.Debug.WriteLine(err.StackTrace);
            //    }

            //}
        }
        private void cboProcess_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_screenMode == eScreenMode.IDLE)
                    return;

                if (cboProcess.SelectedIndex < 0) 
                {
                    txtQtyPCS.Text = !(string.Empty.Equals(txtQtyKG.Text.Trim())) ? string.Empty : txtQtyPCS.Text;
                    return;
                }

                BindMachineData(txtMasterNo.Text.Trim(), cboProcess.SelectedValue.ToString());

                if (m_screenMode == eScreenMode.ADD)
                    LoadDataByItem();

                if(cboProcess.SelectedValue != null)
                    EnableControlWithConstraint(cboProcess.SelectedValue.ToString());

                txtQtyKG_Validating(this, new CancelEventArgs());                
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }
        private void txtPartNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.Empty.Equals(txtPartNo.Text.Trim()))
                return;

            try
            {
                ItemBIZ biz = new ItemBIZ();
                ItemDescriptionDTO dto = biz.LoadItemDescription(new NZString(), txtPartNo.Text.Trim().ToNZString());
                if (dto == null)
                {
                    ErrorItem errorItem = new ErrorItem(txtPartNo, TKPMessages.eValidate.VLM0009.ToString());
                    throw new BusinessException(errorItem);
                }
                txtMasterNo.Text = dto.MASTER_NO;
                txtCustomerName.Text = dto.CUSTOMER_NAME;

                if (string.Empty.Equals(txtMasterNo.Text) || cboProcess.SelectedValue == null)
                    return;

                LoadOnHandQty(new NZString(txtMasterNo, txtMasterNo.Text.Trim()),
                              new NZString(cboProcess, cboProcess.SelectedValue.ToString()),
                              new NZDecimal());

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
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }
        private void txtQtyKG_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.Empty.Equals(txtQtyKG.Text.Trim()))
                    return;

                ItemBIZ biz = new ItemBIZ();

                ItemWeightDTO dto = biz.ConvertKGtoPCS(new NZString(txtMasterNo, txtMasterNo.Text.Trim()),
                                    new NZString(cboProcess, cboProcess.SelectedValue),
                                    new NZDecimal(txtQtyKG, txtQtyKG.Text.Trim()),
                                    new NZInt(null, 1));
                txtQtyPCS.Decimal = dto.QtyPCS == null ? 0 : dto.QtyPCS.StrongValue;

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
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }
        private void txtLotNo_Validating(object sender, CancelEventArgs e)
        {
            string strLotNo = txtLotNo.Text.Trim();
            if (string.Empty.Equals(strLotNo))
                return;

            try
            {
                FormatUtil.CheckFormatLotNo(new NZString(txtLotNo, strLotNo));

                if (m_screenMode != eScreenMode.ADD)
                    return;
                if (cboProcess.SelectedValue == null)
                    return;

                DealingConstraintDTO constriant = bizConstraint.LoadDealingConstraint(new NZString(cboProcess,cboProcess.SelectedValue.ToString()));
                if (constriant != null && constriant.CHECK_DUPLICATE_LOT_FLAG.StrongValue == 1) 
                {
                    InventoryBIZ biz = new InventoryBIZ();
                    if (biz.LotNoIsExist(new NZString(txtLotNo, txtLotNo.Text))) {
                        MessageDialog.ShowInformation(this, Message.LoadMessage(TKPMessages.eInformation.INF0003.ToString()).MessageCode, Message.LoadMessage(TKPMessages.eInformation.INF0003.ToString()).MessageDescription);
                    }
                }
                
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
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }
        private void txtQtyKG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (string.Empty.Equals(txtQtyKG.Text))
                    CtrlUtil.FocusControl(txtQtyPCS);
                else
                    CtrlUtil.FocusControl(cboPersonInCharge);
            }
        }
        private void txtMasterNo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (m_screenMode == eScreenMode.IDLE)
                    return;

                BindProcess(txtMasterNo.Text.Trim());

                if (cboProcess.SelectedIndex < 0)
                    return;

                BindMachineData(txtMasterNo.Text.Trim(), cboProcess.SelectedValue.ToString());

                txtQtyKG_Validating(this, new CancelEventArgs());      
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }
        #endregion

        #region Spread event

        #region Variables
        /// <summary>
        /// เก็บรายการของทุกฟิล์ดในแถวที่กำลังแก้
        /// </summary>
        protected readonly Map<eNGInfoCol, object> m_mapCellValue = new Map<eNGInfoCol, object>();
        /// <summary>
        /// เก็บสถานะว่าตอนนี้ Row นั้น มีบาง Cell ที่ถูกปรับเปลี่ยนค่า
        /// </summary>
        protected bool m_bRowHasModified = false;
        #endregion

        #region Utility method

        #endregion

        #region Spread trigger.

        protected void fpNGInfo_EditModeOff(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = shtNGInfo.ActiveRowIndex;
                int colIndex = shtNGInfo.ActiveColumnIndex;

                bool bValidateCellPass = ValidateCellEdited(rowIndex, colIndex);
                if (!bValidateCellPass)
                {
                    shtNGInfo.SetActiveCell(rowIndex, colIndex);
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

        protected void fpNGInfo_LeaveCell(object sender, LeaveCellEventArgs e)
        {
            try
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

        protected void fpNGInfo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                if (m_bRowHasModified)
                {
                    int lastRowNonEmpty = shtNGInfo.GetLastNonEmptyRow(NonEmptyItemFlag.Data);
                    if (lastRowNonEmpty != shtNGInfo.RowCount - 1)
                    {
                        shtNGInfo.RemoveRows(shtNGInfo.RowCount - 1, 1);
                    }

                    m_bRowHasModified = false;
                }
                else
                {
                    RemoveRowUnused(shtNGInfo);
                }
            }
        }

        protected void fpNGInfo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!ValidateRowSpread(shtNGInfo.ActiveRowIndex, false))
                {
                    e.Cancel = true;
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

        #region Spread Validate
        /// <summary>
        /// Validate เมื่อ Cell มีการแก้ไขเรียบร้อย  และค่าที่แก้ไขเป็นค่าใหม่
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        protected bool ValidateCellEdited(int row, int column)
        {
            try
            {
                switch (column)
                {
                    case (int)eNGInfoCol.NG_WEIGHT:

                        if (string.Empty.Equals(shtNGInfo.Cells[row, column].Text))
                        {
                            shtNGInfo.Cells[row, (int)eNGInfoCol.NG_QTY].Value = null;
                            return true;
                        }

                        ItemBIZ biz = new ItemBIZ();

                        ItemWeightDTO dto = biz.ConvertKGtoPCS(new NZString(txtMasterNo, txtMasterNo.Text.Trim()),
                                            new NZString(cboProcess, cboProcess.SelectedValue),
                                            new NZDecimal(null, shtNGInfo.Cells[row, column].Value),
                                            new NZInt(null, 1));

                        shtNGInfo.Cells[row, (int)eNGInfoCol.NG_QTY].Value = dto.QtyPCS == null ? 0 : dto.QtyPCS.StrongValue;
                        CalculateTotalNG();

                        break;

                    case (int)eNGInfoCol.NG_QTY:

                        shtNGInfo.Cells[row, (int)eNGInfoCol.NG_WEIGHT].Value = null;
                        if (string.Empty.Equals(shtNGInfo.Cells[row, column].Text))
                            return true;

                        CalculateTotalNG();

                        break;
                }

                return true;
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
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }

            //if (column == (int)eColView.ITEM_CD ||
            //    column == (int)eColView.LOT_NO)
            //{
            //    //ItemValidator itemValidator = new ItemValidator();

            //    //NZString itemCode = new NZString(null, shtView.GetValue(row, (int)eColView.ITEM_CD));

            //    //// Validate Input ItemCode.
            //    //if (column == (int)eColView.ITEM_CD)
            //    //{
            //    //    //== Not error, but clear content all columns.
            //    //    if (itemCode.IsNull || itemCode.StrongValue.Trim() == String.Empty)
            //    //    {
            //    //        // Clear content on row.
            //    //        shtView.Cells[row, (int)eColView.ON_HAND_QTY].Value = null;
            //    //        shtView.Cells[row, (int)eColView.REQUEST_QTY].Value = null;
            //    //        shtView.Cells[row, (int)eColView.CONSUMPTION_QTY].Value = null;
            //    //        shtView.Cells[row, (int)eColView.INV_UM_CLS].Value = null;
            //    //        return true;
            //    //    }

            //    //    // Lookup Lot No
            //    //    //LookupData lookupLotNo = m_bizLookupData.LoadLookupLotNo(itemCode, new NZString(null, cboOrderLoc.SelectedValue), dtWorkResultDate.Value.Value.ToString("yyyyMM").ToNZString());
            //    //    //shtView.Cells[row, (int)eColView.LOT_NO].CellType = CtrlUtil.CreateComboBoxCellType(lookupLotNo, false);
            //    //}

            //    //ItemDTO itemDTO = m_bizItem.LoadItem(itemCode);
            //    //if (itemDTO == null)
            //    //{
            //    //    CtrlUtil.SpreadSetCellLocked(shtView, true, row, (int)eColView.LOT_NO);
            //    //    CtrlUtil.SpreadSetCellLocked(shtView, true, row, (int)eColView.LOT_BTN);
            //    //    shtView.Cells[row, (int)eColView.LOT_NO].Value = null;
            //    //    shtView.Cells[row, (int)eColView.ON_HAND_QTY].Value = null;
            //    //    shtView.Cells[row, (int)eColView.REQUEST_QTY].Value = null;
            //    //    shtView.Cells[row, (int)eColView.CONSUMPTION_QTY].Value = null;
            //    //    shtView.Cells[row, (int)eColView.INV_UM_CLS].Value = null;
            //    //}
            //    //else
            //    //{
            //    //    //== Update LOT_CONTROL_CLS on DataTable's current row.
            //    //    DataRowView dataRowView = CtrlUtil.SpreadGetDataRowFromRowIndex(shtView, row);
            //    //    dataRowView[WorkResultEntryViewDTO.eColumns.LOT_CONTROL_CLS.ToString()] = itemDTO.LOT_CONTROL_CLS.Value;
            //    //    if (itemDTO.LOT_CONTROL_CLS.StrongValue == "00")
            //    //    {
            //    //        CtrlUtil.SpreadSetCellLocked(shtView, true, row, (int)eColView.LOT_NO);
            //    //        CtrlUtil.SpreadSetCellLocked(shtView, true, row, (int)eColView.LOT_BTN);
            //    //        shtView.Cells[row, (int)eColView.LOT_NO].Value = null;
            //    //    }
            //    //    else
            //    //    {
            //    //        CtrlUtil.SpreadSetCellLocked(shtView, false, row, (int)eColView.LOT_NO);
            //    //        CtrlUtil.SpreadSetCellLocked(shtView, false, row, (int)eColView.LOT_BTN);
            //    //    }

            //    //    // Load INV_UM_CLS
            //    //    shtView.Cells[row, (int)eColView.INV_UM_CLS].Value = itemDTO.INV_UM_CLS.Value;


            //    //    NZString lotNo = new NZString(null, shtView.GetValue(row, (int)eColView.LOT_NO));
            //    //    WorkResultEntryViewDTO viewDTO = GetChildItem(itemCode);

            //    //    //== Load stock onhand qty.
            //    //    InventoryOnhandDTO inventoryOnhandDTO = m_bizInventory.LoadInventoryOnHandByCurrentPeriod(itemCode, cboOrderLoc.ToNZString(), lotNo);
            //    //    // not found stock.
            //    //    if (inventoryOnhandDTO == null)
            //    //    {
            //    //        shtView.Cells[row, (int)eColView.ON_HAND_QTY].Value = 0;
            //    //    }
            //    //    else
            //    //    {
            //    //        shtView.Cells[row, (int)eColView.ON_HAND_QTY].Value = inventoryOnhandDTO.ON_HAND_QTY.Value;
            //    //    } // end check stock.



            //    //    //== Calculate next consumption qty.
            //    //    if (viewDTO == null)
            //    //    {
            //    //        // ถ้า item ที่ระบุ ไม่ใช่ของ Child Item ที่จะตัด Consumption
            //    //        // ให้ Default ค่า ConsumptionQty = 0;
            //    //        shtView.Cells[row, (int)eColView.REQUEST_QTY].Value = 0;
            //    //        shtView.Cells[row, (int)eColView.CONSUMPTION_QTY].Value = 0;
            //    //    }
            //    //    else
            //    //    {
            //    //        shtView.Cells[row, (int)eColView.REQUEST_QTY].Value = viewDTO.REQUEST_QTY.Value;

            //    //        NZDecimal consumptionQty = new NZDecimal(null, shtView.Cells[row, (int)eColView.CONSUMPTION_QTY].Value);

            //    //        // ถ้าค่า ConsumptionQty เป็นค่าว่างหรือศูนย์ หมายถึงผู้ใช้ยังไม่มีการ Assign ค่า  ดังนั้นจะ default ค่าให้ตรงกับค่าคงเหลือที่จะต้องตัด Consumption
            //    //        if (consumptionQty.IsNull || consumptionQty.StrongValue == 0)
            //    //        {
            //    //            // Find new consumptionQty.
            //    //            DataTable dtView = (DataTable)shtView.DataSource;
            //    //            if (dtView == null)
            //    //            {
            //    //                shtView.Cells[row, (int)eColView.CONSUMPTION_QTY].Value = 0;
            //    //                return true;
            //    //            }

            //    //            NZDecimal sumConsumption = SumConsumptionQtyByItem(itemCode, row);
            //    //            shtView.Cells[row, (int)eColView.CONSUMPTION_QTY].Value = Math.Max(0, viewDTO.REQUEST_QTY.NVL(0) - sumConsumption.NVL(0));

            //    //        }
            //    //    }
            //    //}
            //}



            return true;
        }

        /// <summary>
        /// Validate spread row.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="forceValidate">force to validate.</param>
        /// <returns></returns>
        protected bool ValidateRowSpread(int row, bool forceValidate)
        {
            CalculateTotalNG();

            //if (!forceValidate && !m_bRowHasModified)
            //    return true;

            //if (shtView.RowCount <= 0)
            //    return true;

            //object src_item_cd = shtView.Cells[row, (int)eColView.ITEM_CD].Value;
            //object src_lot_no = shtView.Cells[row, (int)eColView.LOT_NO].Value;
            //object src_loc_cd = shtView.Cells[row, (int)eColView.LOC_CD].Value;

            //for (int iRow = 0; iRow < shtView.Rows.Count; iRow++)
            //{
            //    if (iRow == row)
            //        continue;

            //    // Check key duplidate.
            //    object item_cd = shtView.Cells[iRow, (int)eColView.ITEM_CD].Value;
            //    object lot_no = shtView.Cells[iRow, (int)eColView.LOT_NO].Value;
            //    object loc_cd = shtView.Cells[iRow, (int)eColView.LOC_CD].Value;


            //    if (Equals(src_item_cd, item_cd)
            //        && Equals(src_lot_no, lot_no)
            //        && Equals(src_loc_cd, loc_cd)
            //        )
            //    {
            //        MessageDialog.ShowBusiness(this, null, "Data has already exist.");
            //        return false;
            //    }
            //}

            // ถ้า Validate Row ผ่าน แสดงว่า แถวนั้นไม่จำเป็นต้องเช็คอีกรอบ
            m_bRowHasModified = false;
            return true;
        }
        #endregion

        protected void txtItemCode_KeyPressResult(object sender, bool isFound, NZString ItemCD)
        {
            //if (!isFound)
            //{
            //    return;
            //}

            //// ItemProcessDTO itemProcessDTO = m_bizItem.LoadItemProcess(ItemCD);
            //cboOrderLoc.SelectedValue = txtItemCode.SelectedItemProcessData.ORDER_LOC_CD.Value;
            //cboStoredLoc.SelectedValue = txtItemCode.SelectedItemProcessData.STORE_LOC_CD.Value;
            //cboConsumptionCls.SelectedValue = txtItemCode.SelectedItemProcessData.CONSUMTION_CLS.Value;
            //txtLotSize.Text = txtItemCode.SelectedItemProcessData.LOT_SIZE.NVL(0).ToString("#,##0");

            ////if (txtItemCode.SelectedItemProcessData.ORDER_LOC_CD.StrongValue != DataDefine.LOCATION_INJECTION)
            ////{
            ////    cboStoredLoc.SelectedValue = DEFAULT_STORE_LOC_FOR_FG;
            ////}
            ////else
            ////{
            ////cboStoredLoc.SelectedValue = txtItemCode.SelectedItemProcessData.STORE_LOC_CD.Value;
            ////}

            //if (txtItemCode.SelectedItemData.LOT_CONTROL_CLS == DataDefine.Convert2ClassCode(DataDefine.eLOT_CONTROL_CLS.Yes) && dtWorkResultDate.Value.HasValue)
            //{
            //    RunningNumberBIZ runnningBiz = new RunningNumberBIZ();

            //    if (dtWorkResultDate.Value == null)
            //    {
            //        dtWorkResultDate.Value = DateTime.Today;
            //    }
            //    NZString strCompleteLotNo = runnningBiz.GetCompleteLotNo(new NZDateTime(null, dtWorkResultDate.Value), txtItemCode.SelectedItemProcessData.STORE_LOC_CD, txtItemCode.SelectedItemData.ITEM_CD, new NZInt(null, 0));
            //    txtLotNo.Text = strCompleteLotNo.StrongValue;
            //}

            //LoadDataByItem(txtItemCode.ToNZString(), cboOrderLoc.ToNZString(), numWorkResultQty.ToNZDecimal());



        }


        #endregion

        #region Check Inventory Period
        protected void CheckCurrentInvPeriod()
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

        protected void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_keyboardSpread.OnActionAddNewRow();
        }
        protected void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_keyboardSpread.OnActionRemoveRow();
        }
        protected void btnItemCode_Click(object sender, EventArgs e)
        {
            txtItemCode_KeyPressResult(txtMasterNo, (txtMasterNo.SelectedItemData != null), (NZString)txtMasterNo.Text);

        }
        protected void fpView_ButtonClicked(object sender, EditorNotifyEventArgs e)
        {
            //NZString ItemCD = new NZString(null, shtView.Cells[e.Row, (int)eColView.ITEM_CD].Value);
            //NZString LotNo = new NZString(null, shtView.Cells[e.Row, (int)eColView.LOT_NO].Value);
            //NZString LocCD = new NZString(cboOrderLoc, cboOrderLoc.SelectedValue);

            //if (e.Column == (int)eColView.ITEM_CD_BTN)
            //{
            //    ItemFindDialog dialog = new ItemFindDialog(eSqlOperator.In, null);
            //    dialog.ShowDialog(this);

            //    if (dialog.IsSelected)
            //    {
            //        shtView.Cells[e.Row, (int)eColView.ITEM_CD].Value = dialog.SelectedItem.ITEM_CD.Value;

            //        shtView.Cells[e.Row, (int)eColView.LOC_CD].Value = GetConsumptionLocation(dialog.SelectedItem.ITEM_CD.StrongValue);


            //        ValidateCellEdited(e.Row, (int)eColView.ITEM_CD);
            //    }
            //}
            //else if (e.Column == (int)eColView.LOT_BTN)
            //{
            //    //NZString locCD = new NZString(null, cboOrderLoc.SelectedValue);

            //    NZString locCD = new NZString(null, Convert.ToString(shtView.Cells[e.Row, (int)eColView.LOC_CD].Value));
            //    LotNoFindDialog dialog = new LotNoFindDialog(ItemCD, locCD, LotNoFindDialog.eSearchType.DependOnItemAndLocationIgnoreReserveLot);

            //    dialog.ShowDialog(this);
            //    if (dialog.IsSelected)
            //    {
            //        shtView.Cells[e.Row, (int)eColView.LOT_NO].Value = dialog.SelectedItem.NVL(string.Empty);
            //        LotNo = new NZString(null, shtView.Cells[e.Row, (int)eColView.LOT_NO].Value);
            //        //== Load stock onhand qty.
            //        InventoryOnhandDTO inventoryOnhandDTO = m_bizInventory.LoadInventoryOnHandByCurrentPeriod(ItemCD, locCD, LotNo);
            //        shtView.Cells[e.Row, (int)eColView.ON_HAND_QTY].Value = inventoryOnhandDTO.ON_HAND_QTY.StrongValue;

            //        decimal decOnHand = Convert.ToDecimal(shtView.Cells[e.Row, (int)eColView.ON_HAND_QTY].Value);
            //        decimal decConsumption = Convert.ToDecimal(shtView.Cells[e.Row, (int)eColView.CONSUMPTION_QTY].Value);

            //        //ค่า consumption มันจะถูกคำนวณมาตอน add row อยู่แล้ว 
            //        //ก็ check เรื่องของ on hand < consumption  ก็ set ให้เป็น on hand ก็พอ
            //        if (decOnHand < decConsumption)
            //        {
            //            shtView.Cells[e.Row, (int)eColView.CONSUMPTION_QTY].Value = shtView.Cells[e.Row, (int)eColView.ON_HAND_QTY].Value;
            //        }

            //        //txtLotNo_KeyPress(txtLotNo, new KeyPressEventArgs((char)Keys.Return));
            //    }
            //}
            //else if (e.Column == (int)eColView.LOC_BTN)
            //{
            //    DynamicFindDialog locDialog = new DynamicFindDialog("S_DynamicFindDialog_Location_LoadAll", "Location");
            //    locDialog.Parameters = new EVOFramework.Database.ParameterCollection();
            //    locDialog.Parameters.Add("@varPriorityLocation", LocCD.Value);
            //    if (locDialog.ShowDialog(this) == DialogResult.OK)
            //    {
            //        shtView.Cells[e.Row, (int)eColView.LOC_CD].Value = locDialog.SelectedKey;

            //        shtView.Cells[e.Row, (int)eColView.LOT_NO].Value = null;
            //    }

            //}
        }
        protected void cboConsumptionCls_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (cboConsumptionCls.SelectedValue != null)
            //{
            //    if (cboConsumptionCls.SelectedValue.ToString() != DataDefine.Convert2ClassCode(DataDefine.eCONSUMPTION_CLS.Manual))
            //    {
            //        cmsOperation.Enabled = false;
            //    }
            //    else
            //    {
            //        cmsOperation.Enabled = true;
            //    }
            //}

        }
        protected void numWorkResultQty_TextChanged(object sender, EventArgs e)
        {
            //LoadDataByItem(txtItemCode.ToNZString(), cboOrderLoc.ToNZString(), numWorkResultQty.ToNZDecimal());
        }
        protected void txtNGQty_TextChanged(object sender, EventArgs e)
        {
            //if (!m_ClearControlBySystem)
            //{
            //    //txtGoodQty.Double = numWorkResultQty.Double - txtNGQty.Double;
            //    numWorkResultQty.Double = txtGoodQty.Double + txtReserveQty.Double + txtNGQty.Double;
            //    CalculateConsumption();
            //}
        }
        protected void txtGoodQty_TextChanged(object sender, EventArgs e)
        {
            //if (!m_ClearControlBySystem)
            //{
            //    numWorkResultQty.Double = txtGoodQty.Double + txtReserveQty.Double + txtNGQty.Double;
            //    CalculateConsumption();
            //}
        }
        protected void txtReserveQty_TextChanged(object sender, EventArgs e)
        {
            //if (!m_ClearControlBySystem)
            //{
            //    numWorkResultQty.Double = txtGoodQty.Double + txtReserveQty.Double + txtNGQty.Double;
            //    CalculateConsumption();
            //}
        }
        //protected void numWorkResultQty_Leave(object sender, EventArgs e)
        //{
        //    numWorkResultQty_KeyPress(numWorkResultQty, new KeyPressEventArgs((char)Keys.Return));
        //}
        protected string GetConsumptionLocation(string argItemCode)
        {
            string ret = Convert.ToString(cboProcess.SelectedValue);

            //for (int i = 0; i < shtView.RowCount; i++)
            //{
            //    string strItemCode = Convert.ToString(shtView.Cells[i, (int)eColView.ITEM_CD].Value);
            //    if (strItemCode != null &&
            //        strItemCode.Equals(argItemCode, StringComparison.CurrentCultureIgnoreCase))
            //    {
            //        string strLocationCode = Convert.ToString(shtView.Cells[i, (int)eColView.LOC_CD].Value);

            //        //หา location code ที่ไม่ใช่ "" 
            //        if (strLocationCode != null
            //            && !"".Equals(strLocationCode.Trim()))
            //        {
            //            ret = strLocationCode;
            //            break;
            //        }
            //    }
            //}

            return ret;
        }
        protected void CalculateConsumption()
        {
            //try
            //{

            //    NZString ComsumptionCls = cboConsumptionCls.SelectedValue == null ? new NZString() : cboConsumptionCls.SelectedValue.ToString().ToNZString();
            //    // Validate data before load data into spread.
            //    WorkResultEntryValidator validator = new WorkResultEntryValidator();
            //    validator.ValidateBeforeLoadConsumption(txtItemCode.ToNZString(), cboOrderLoc.ToNZString(), numWorkResultQty.ToNZDecimal(), ComsumptionCls);

            //    LoadDataByItem(txtItemCode.ToNZString(), cboOrderLoc.ToNZString(), numWorkResultQty.ToNZDecimal());

            //    SetHilightWorkResultQty();
            //}
            //catch (ValidateException err)
            //{
            //    MessageDialog.ShowBusiness(this, err.ErrorResults[0].Message);
            //    err.ErrorResults[0].FocusOnControl();
            //}
            //catch (BusinessException err)
            //{
            //    MessageDialog.ShowBusiness(this, err.Error.Message);
            //    err.Error.FocusOnControl();
            //}
            //catch (Exception err)
            //{
            //    MessageDialog.ShowBusiness(this, err.Message);
            //    System.Diagnostics.Debug.WriteLine(err.StackTrace);
            //}
        }
        protected void cboOrderLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadDataByItem(txtMasterNo.ToNZString(), cboProcess.ToNZString(), txtQtyKG.ToNZDecimal());

            //if (cboOrderLoc.SelectedIndex != -1)
            //{
            //    DataTable dtConsumption = (DataTable)shtView.DataSource;
            //    if (dtConsumption != null)
            //    {
            //        foreach (DataRow dr in dtConsumption.Rows)
            //        {
            //            if (dr[WorkResultEntryViewDTO.eColumns.LOC_CD.ToString()] != dr[WorkResultEntryViewDTO.eColumns.CHILD_ORDER_LOC_CD.ToString()])
            //            {
            //                dr[WorkResultEntryViewDTO.eColumns.LOC_CD.ToString()] = cboOrderLoc.SelectedValue;
            //            }

            //        }
            //    }
            //    //for (int iConsumptionIndex = 0; iConsumptionIndex < shtView.RowCount; iConsumptionIndex++)
            //    //{
            //    //    shtView.Cells[iConsumptionIndex, (int)eColView.LOC_CD].Value = cboOrderLoc.SelectedValue;
            //    //}
            //}
            //else
            //{
            //    //for (int iConsumptionIndex = 0; iConsumptionIndex < shtView.RowCount; iConsumptionIndex++)
            //    //{
            //    //    shtView.Cells[iConsumptionIndex, (int)eColView.LOC_CD].Value = null;
            //    //}
            //    DataTable dtConsumption = (DataTable)shtView.DataSource;

            //    if (dtConsumption != null)
            //    {
            //        foreach (DataRow dr in dtConsumption.Rows)
            //        {
            //            if (dr[WorkResultEntryViewDTO.eColumns.LOC_CD.ToString()] != dr[WorkResultEntryViewDTO.eColumns.CHILD_ORDER_LOC_CD.ToString()])
            //            {
            //                dr[WorkResultEntryViewDTO.eColumns.LOC_CD.ToString()] = null;
            //            }

            //        }
            //    }
            //}
        }
        protected void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //int iActiveRowIndex = shtView.ActiveRowIndex;

            //NZString strItem = new NZString(null, shtView.Cells[iActiveRowIndex, (int)eColView.ITEM_CD].Value);
            //NZString strLotNo = new NZString(null, shtView.Cells[iActiveRowIndex, (int)eColView.LOT_NO].Value);

            //if (!strItem.IsNull && !strLotNo.IsNull)
            //{


            //    //sheet.AddRows(0, 1);


            //    //m_keyboardSpread.OnActionAddNewRow();


            //    if (iActiveRowIndex > -1)
            //    {
            //        int iAddingIndex = GetAddingIndex(strItem);

            //        shtView.AddRows(iAddingIndex, 1);

            //        //int iLastRow = shtView.RowCount - 1;

            //        shtView.Cells[iAddingIndex, (int)eColView.ITEM_CD].Value = shtView.Cells[iActiveRowIndex, (int)eColView.ITEM_CD].Value;
            //        shtView.Cells[iAddingIndex, (int)eColView.LOC_CD].Value = shtView.Cells[iActiveRowIndex, (int)eColView.LOC_CD].Value;
            //        shtView.Cells[iAddingIndex, (int)eColView.INV_UM_CLS].Value = shtView.Cells[iActiveRowIndex, (int)eColView.INV_UM_CLS].Value;
            //        ValidateCellEdited(iAddingIndex, (int)eColView.ITEM_CD);

            //        //SortConsumptionData(iLastRow);
            //    }


            //}
            //else
            //{
            //    MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0101.ToString()));
            //}
        }
        //protected void SortConsumptionData(int iAddedIndex)
        //{
        //    DefaultSheetDataModel dataModel = (DefaultSheetDataModel)shtView.Models.Data;


        //}


        //public int GetAddingIndex(NZString strItemCode)
        //{
        //    int iResult = shtView.RowCount - 1;

        //    for (int iIndex = 0; iIndex < shtView.RowCount; iIndex++)
        //    {
        //        if (strItemCode.NVL("").Equals(shtView.GetValue(iIndex, (int)eColView.ITEM_CD)))
        //        {
        //            iResult = iIndex;
        //        }
        //    }

        //    return iResult + 1;
        //}

        //protected void SetHilightWorkResultQty()
        //{
        //    decimal decLotSize = Convert.ToDecimal(txtLotSize.NumericText);
        //    decimal decWorkResultQty = Convert.ToDecimal(numWorkResultQty.NumericText);

        //    if (decLotSize != decWorkResultQty)
        //    {
        //        numWorkResultQty.Font = new Font(numWorkResultQty.Font, FontStyle.Bold);
        //        numWorkResultQty.ForeColor = Color.Red;
        //    }
        //    else
        //    {
        //        numWorkResultQty.Font = new Font(numWorkResultQty.Font, FontStyle.Regular);
        //        numWorkResultQty.ForeColor = Color.Empty;
        //    }
        //}
        protected void dtWorkResultDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtProductionReportDate.Value.HasValue)
            {
                if (txtMasterNo.SelectedItemData != null)
                {
                    //if (txtMasterNo.SelectedItemData.LOT_CONTROL_CLS == DataDefine.Convert2ClassCode(DataDefine.eLOT_CONTROL_CLS.Yes) && dtProductionReportDate.Value.HasValue)
                    //{
                    //    RunningNumberBIZ runnningBiz = new RunningNumberBIZ();

                    //    if (dtProductionReportDate.Value == null)
                    //    {
                    //        dtProductionReportDate.Value = DateTime.Today;
                    //    }
                    //    NZString strCompleteLotNo = runnningBiz.GetCompleteLotNo(new NZDateTime(null, dtProductionReportDate.Value), txtMasterNo.SelectedItemProcessData.STORE_LOC_CD, txtMasterNo.SelectedItemData.ITEM_CD, new NZInt(null, 0));
                    //    //txtLotNo.Text = strCompleteLotNo.StrongValue;
                    //}

                }

            }
        }
        protected void lblLotSize_Click(object sender, EventArgs e)
        {

        }
        protected void SetDefaultProcess()
        {
            //if (m_editTransactionID == null)
            //{
            //    SetScreenMode(eScreenMode.ADD);

            //    SysConfigBIZ sysBiz = new SysConfigBIZ();
            //    SysConfigDTO argScreenInfo = new SysConfigDTO();

            //    InternalScreen internalScreen = new InternalScreen(this.GetType());

            //    argScreenInfo.SYS_GROUP_ID = internalScreen.ScreenAttribute.ScreenCD.ToNZString();//DataDefine.eSYSTEM_CONFIG.TRN2101.SYS_GROUP_ID;
            //    argScreenInfo.SYS_KEY = (NZString)DataDefine.eSYSTEM_CONFIG.TRN210.SYS_KEY.PROCESS.ToString();


            //    SysConfigDTO conf = sysBiz.LoadByPK(argScreenInfo.SYS_GROUP_ID, argScreenInfo.SYS_KEY);
            //    if (conf != null)
            //    {
            //        cboProcess.SelectedValue = conf.CHAR_DATA;
            //        CtrlUtil.EnabledControl(false, cboProcess);
            //        //.Value = sysBiz.GetDefaultDateForScreen(argScreenInfo);
            //    }
            //}
        }


        public override void OnSaveFormat()
        {
            base.OnSaveFormat();

            SheetWidthController ctrl = new SheetWidthController();
            ctrl.SaveSheetWidth(shtNGInfo, this.ScreenCode);
        }

        public override void OnResetFormat()
        {
            base.OnResetFormat();

            SheetWidthController ctrl = new SheetWidthController();
            ctrl.ResetSheetWidth(shtNGInfo);
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
            ctrl.SetSheetWidth(shtNGInfo, this.ScreenCode);
        }

        private void cboProcess_TextChanged(object sender, EventArgs e) 
        {
            if (string.Empty.Equals(cboProcess.Text)) 
            {
                ClearNG();
                txtQtyPCS.Decimal = !(string.Empty.Equals(txtQtyKG.Text.Trim())) ? 0 : txtQtyPCS.Decimal;                
            }
        }

        private void fpNGInfo_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }


    }


}
