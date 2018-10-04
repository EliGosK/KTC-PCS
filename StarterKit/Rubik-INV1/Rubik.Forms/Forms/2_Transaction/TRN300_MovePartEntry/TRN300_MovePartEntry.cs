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

    [Screen("TRN300", "Move Process Entry", eShowAction.Normal, eScreenType.Screen, "Move Process Entry")]
    public partial class TRN300_MovePartEntry : CustomizeForm
    {
        #region Enum

        private enum eScreenMode
        {
            VIEW,
            ADD,
            EDIT
        } ;

        #endregion

        #region Variables
        private const string CONST_STR_FG_LOC = "FG";

        private MovePartController m_movecontroller = new MovePartController();
        private MovePartUIDM m_uidm = null;

        DealingConstraintBIZ bizConstraint = new DealingConstraintBIZ();
        private readonly LookupDataBIZ m_bizLookupData = new LookupDataBIZ();
        private readonly InventoryBIZ m_bizInventory = new InventoryBIZ();
        private readonly InventoryTransBIZ m_bizInventoryTrans = new InventoryTransBIZ();
        private readonly BOMBIZ m_bizBOM = new BOMBIZ();
        private readonly ItemBIZ m_bizItem = new ItemBIZ();

        private readonly TransactionValidator m_transactionValidator = new TransactionValidator();


        private eScreenMode m_screenMode = eScreenMode.ADD;
        private DialogResult m_dialogResult = DialogResult.Cancel;
        private KeyboardSpread m_keyboardSpread = null;
        private NZString m_editTransactionID = null;

        private const string DEFAULT_STORE_LOC_FOR_FG = "QAWH";

        //เอาไว้ check ตอน clear control ไม่ให้ระบบมันเด้ง error เรื่องของ partcode ที่ empty
        private bool m_ClearControlBySystem = false;

        /// <summary>
        /// เก็บรายการของ Child Item ที่จะใช้ทำ Consumption
        /// ค่านี้จะใช้ตรวจสอบก่อนที่จะ
        /// </summary>
        private List<WorkResultEntryViewDTO> m_listRequireChildItems = new List<WorkResultEntryViewDTO>();
        #endregion

        #region Constructor
        public TRN300_MovePartEntry()
        {
            InitializeComponent();
        }

        public TRN300_MovePartEntry(MovePartUIDM uidm)
        {
            InitializeComponent();
            m_uidm = uidm;
        }
        #endregion

        #region Initialize Screen

        private void InitializeScreen()
        {
            InitializeComboBox();
            InitializeLookupData();
            InitlializeBindingControl();
            InitialFormat();
            InitializeKeyPress();

            if (m_uidm == null)
            {
                SetScreenMode(eScreenMode.ADD);
            }
            else
            {
                LoadData();
                bool bCanEdit = m_transactionValidator.TransactionCanEditOrDelete(m_uidm.TRANS_ID_FROM);
                if (bCanEdit)
                    SetScreenMode(eScreenMode.EDIT);
                else
                    SetScreenMode(eScreenMode.VIEW);
            }

            CheckCurrentInvPeriod();
        }

        private void InitializeComboBox()
        {
            this.cboShift.Format += Common.ComboBox_Format;
            this.cboFromProcess.Format += Common.ComboBox_Format;
            this.cboToProcess.Format += Common.ComboBox_Format;
            this.cboMoveReason.Format += Common.ComboBox_Format;
        }
        private void InitlializeBindingControl()
        {
            dmc.AddRangeControl
            (
                hiddenFromTransID,
                hiddenToTransID,
                lblMoveNo,
                dtMoveDate,
                cboShift,
                txtMasterNo,
                txtPartNo,
                txtCustomerName,
                cboFromProcess,
                cboToProcess,
                txtMoveQtyPCS,
                txtLotNo,
                cboMoveReason,
                txtRemark,
                txtMoveQtyKG
            );
        }
        private void InitializeKeyPress()
        {
            lblMoveNo.KeyPress += CtrlUtil.SetNextControl;
            dtMoveDate.KeyPress += CtrlUtil.SetNextControl;
            cboShift.KeyPress += CtrlUtil.SetNextControl;
            txtMasterNo.KeyPress += CtrlUtil.SetNextControl;
            txtPartNo.KeyPress += CtrlUtil.SetNextControl;
            txtCustomerName.KeyPress += CtrlUtil.SetNextControl;
            cboFromProcess.KeyPress += CtrlUtil.SetNextControl;
            cboToProcess.KeyPress += CtrlUtil.SetNextControl;
            txtOnHandQty.KeyPress += CtrlUtil.SetNextControl;
            //txtMoveQtyKG.KeyPress += CtrlUtil.SetNextControl;
            txtMoveQtyPCS.KeyPress += CtrlUtil.SetNextControl;
            txtLotNo.KeyPress += CtrlUtil.SetNextControl;
            cboMoveReason.KeyPress += CtrlUtil.SetNextControl;
            txtRemark.KeyPress += CtrlUtil.SetNextControl;
        }
        private void InitializeLookupData()
        {
            LookupData lookupShiftCls = m_bizLookupData.LoadLookupClassType(DataDefine.SHIFT_CLS.ToNZString());
            cboShift.LoadLookupData(lookupShiftCls);
            cboShift.SelectedIndex = -1;

            //------------ Location --------------------//
            NZString[] locationtype = new NZString[1];
            locationtype[0] = DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Production).ToNZString();

            NZString[] exceptLocation = null;
            DealingConstraintDTO constriant = bizConstraint.LoadDealingConstraint(CONST_STR_FG_LOC.ToNZString());
            if (constriant != null && constriant.NO_MOVE_FLAG.StrongValue == 1)
            {
                exceptLocation = new NZString[1];
                exceptLocation[0] = new NZString(null, CONST_STR_FG_LOC);
            }
            LookupData locationData = m_bizLookupData.LoadLookupLocation(locationtype, exceptLocation);
            cboFromProcess.LoadLookupData(locationData.Clone());
            cboFromProcess.SelectedIndex = -1;

            cboToProcess.LoadLookupData(locationData.Clone());
            cboToProcess.SelectedIndex = -1;

            //------------ Location --------------------//

            LookupData movereasonData = m_bizLookupData.LoadLookupClassType(DataDefine.MOVE_REASON.ToNZString());
            cboMoveReason.LoadLookupData(movereasonData.Clone());
            cboMoveReason.SelectedIndex = -1;

        }
        private void InitializeSpread()
        {
            //shtView.ActiveSkin = Common.ACTIVE_SKIN;

            //m_keyboardSpread = new KeyboardSpread(fpView);
            //m_keyboardSpread.RowAdding += new KeyboardSpread.RowAddingHandler(m_keyboardSpread_RowAdding);
            //m_keyboardSpread.RowAdded += new KeyboardSpread.RowAddedHandler(m_keyboardSpread_RowAdded);
            //m_keyboardSpread.RowRemoving += new KeyboardSpread.RowRemovingHandler(m_keyboardSpread_RowRemoving);

            //fpView.SubEditorOpening += CtrlUtil.SpreadDisableSubEditorOpening;
            //LookupDataBIZ biz = new LookupDataBIZ();

            //shtView.Columns[(int)eColView.INV_UM_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(biz.LoadLookupClassType(DataDefine.UM_CLS.ToNZString()));
            //CtrlUtil.MappingDataFieldWithEnum(shtView, typeof(eColView));
        }
        private void InitialFormat()
        {
            //FormatUtil.SetNumberFormat(shtView.Columns[(int)eColView.PRICE], FormatUtil.eNumberFormat.UnitPrice);            
            CommonLib.FormatUtil.SetNumberFormat(txtOnHandQty, FormatUtil.eNumberFormat.Qty_PCS);
            CommonLib.FormatUtil.SetNumberFormat(txtMoveQtyKG, FormatUtil.eNumberFormat.Qty_KG);
            CommonLib.FormatUtil.SetNumberFormat(txtMoveQtyPCS, FormatUtil.eNumberFormat.Qty_PCS);

            CommonLib.FormatUtil.SetDateFormat(dtMoveDate);
        }
        private void ClearScreen()
        {
            //dmc.LoadData(new MovePartUIDM());
            lblMoveNo.Text = string.Empty;
            hiddenFromTransID.Text = string.Empty;
            hiddenToTransID.Text = string.Empty;
            dtMoveDate.ResetText();
            cboShift.SelectedIndex = -1;
            txtMasterNo.Clear();
            txtPartNo.Clear();
            txtCustomerName.Clear();
            cboFromProcess.SelectedIndex = -1;
            cboToProcess.SelectedIndex = -1;
            txtOnHandQty.Clear();
            txtMoveQtyKG.Clear();
            txtMoveQtyPCS.Clear();
            txtLotNo.Clear();
            cboMoveReason.SelectedIndex = -1;
            txtRemark.Clear();
        }

        private void LoadData()
        {
            dmc.LoadData(m_uidm);

            decimal decOnHandQty = LoadOnHandQty(m_uidm.MASTER_NO, m_uidm.FROM_PROCESS, m_uidm.MOVE_QTY);
            txtOnHandQty.Text = decOnHandQty.ToString();
        }
        private decimal LoadOnHandQty(NZString MasterNo, NZString FromProcess, NZDecimal MoveQty)
        {
            decimal decOnHandQty = 0;

            //Load Onhand Qty
            InventoryBIZ bizInv = new InventoryBIZ();

            InventoryOnhandDTO dtoOnhand = bizInv.LoadInventoryOnHandByCurrentPeriod(MasterNo, FromProcess, new NZString(), new NZString());
            if (dtoOnhand != null)
                decOnHandQty = dtoOnhand.ON_HAND_QTY.StrongValue;

            if (!MoveQty.IsNull)
                decOnHandQty = decOnHandQty + MoveQty;

            return decOnHandQty;
        }
        private void ValidateOnHandQty()
        {
            decimal decOnHandQty = LoadOnHandQty(new NZString(txtMasterNo, txtMasterNo.Text.Trim()),
                                                    new NZString(cboFromProcess, cboFromProcess.SelectedValue.ToString()),
                                                    new NZDecimal());
            txtOnHandQty.Text = decOnHandQty.ToString();
        }
        private void SetDefaultProcess()
        {
            ItemProcessDTO dto = m_movecontroller.LoadDefaultProcessOfItem(new NZString(txtMasterNo, txtMasterNo.Text.Trim()),
                                                        new NZString(cboFromProcess, cboFromProcess.SelectedValue.ToString()));

            if (dto != null)
            {
                cboToProcess.SelectedValue = dto.PROCESS_CD;
            }
            else
            {
                cboToProcess.SelectedIndex = -1;
            }
        }
        void m_keyboardSpread_RowAdding(object sender, EventRowAdding e)
        {
            //KeyboardSpread a = (KeyboardSpread)sender;
            //if (a.IsBinded)
            //{
            //    if (a.Owner == fpView)
            //    {
            //        int lastRowNonEmpty = shtView.GetLastNonEmptyRow(NonEmptyItemFlag.Data);
            //        if (lastRowNonEmpty == shtView.RowCount - 1)
            //        {
            //            if ("".Equals(shtView.Cells[lastRowNonEmpty, (int)eColView.LOT_NO].Text)
            //                )
            //            {
            //                e.Cancel = true;
            //            }
            //        }

            //    }
            //}
        }

        #endregion

        #region Keyboard Spread
        void m_keyboardSpread_RowAdded(object sender, int rowIndex)
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

        void m_keyboardSpread_RowRemoving(object sender, EventRowRemoving e)
        {
            MessageDialogResult dr = MessageDialog.ShowConfirmation(this, Message.LoadMessage(Messages.eConfirm.CFM9002.ToString()), MessageDialogButtons.YesNo);
            if (dr == MessageDialogResult.No)
            {
                e.Cancel = true;
            }
        }
        #endregion

        #region Screen mode
        private void SetScreenMode(eScreenMode mode)
        {
            switch (mode)
            {
                case eScreenMode.ADD:

                    ClearScreen();

                    SysConfigBIZ sysBiz = new SysConfigBIZ();
                    SysConfigDTO argScreenInfo = new SysConfigDTO();
                    argScreenInfo.SYS_GROUP_ID = DataDefine.eSYSTEM_CONFIG.TRN300.SYS_GROUP_ID;
                    argScreenInfo.SYS_KEY = (NZString)DataDefine.eSYSTEM_CONFIG.TRN300.SYS_KEY.DEFAULT_DATE.ToString();
                    dtMoveDate.Value = sysBiz.GetDefaultDateForScreen(argScreenInfo);

                    CtrlUtil.EnabledControl(true, dtMoveDate, cboShift);
                    CtrlUtil.EnabledControl(true, txtMasterNo);
                    CtrlUtil.EnabledControl(true, cboFromProcess, cboToProcess);
                    CtrlUtil.EnabledControl(true, txtMoveQtyKG, txtMoveQtyPCS);
                    CtrlUtil.EnabledControl(true, txtLotNo, cboMoveReason, txtRemark);
                    CtrlUtil.EnabledControl(false, txtCustomerName, txtOnHandQty, txtPartNo);

                    tsbSaveAndNew.Enabled = true;
                    tsbSaveAndClose.Enabled = true;

                    break;

                case eScreenMode.EDIT:

                    CtrlUtil.EnabledControl(false, dtMoveDate);
                    CtrlUtil.EnabledControl(false, txtMasterNo, txtPartNo);
                    CtrlUtil.EnabledControl(false, cboFromProcess, cboToProcess);
                    CtrlUtil.EnabledControl(false, txtCustomerName, txtOnHandQty);
                    CtrlUtil.EnabledControl(false, btnSearchMasterNo);
                    CtrlUtil.EnabledControl(false, cboShift);
                    CtrlUtil.EnabledControl(true, txtLotNo, txtMoveQtyKG, txtMoveQtyPCS);
                    //CtrlUtil.EnabledControl(true, cboShift, txtLotNo, txtMoveQtyKG, txtMoveQtyPCS);
                    CtrlUtil.EnabledControl(true, cboMoveReason, txtRemark);
                    txtMoveQtyPCS.Focus();
                    tsbSaveAndNew.Enabled = true;
                    tsbSaveAndClose.Enabled = true;

                    break;

                case eScreenMode.VIEW:

                    CtrlUtil.EnabledControl(false, dtMoveDate, cboShift);
                    CtrlUtil.EnabledControl(false, txtMasterNo, txtPartNo, txtCustomerName);
                    CtrlUtil.EnabledControl(false, cboFromProcess, cboToProcess, txtOnHandQty);
                    CtrlUtil.EnabledControl(false, txtMoveQtyKG, txtMoveQtyPCS);
                    CtrlUtil.EnabledControl(false, txtLotNo, cboMoveReason, txtRemark);

                    tsbSaveAndNew.Enabled = false;
                    tsbSaveAndClose.Enabled = false;

                    break;
            }

            m_screenMode = mode;
        }
        #endregion

        #region Override method
        public override void OnSaveAndNew()
        {
            try
            {
                MovePartUIDM model = dmc.SaveData(new MovePartUIDM());

                ValidateBeforeSave();

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, Message.LoadMessage(Messages.eConfirm.CFM9001.ToString()));
                if (dr == MessageDialogResult.Yes)
                {
                    if (m_screenMode == eScreenMode.ADD)
                        m_movecontroller.SaveNewMovePart(model);
                    else
                        m_movecontroller.SaveUpdateMovePart(model);

                    MessageDialog.ShowInformation(this, null, new EVOFramework.Message(Messages.eInformation.INF9003.ToString()).MessageDescription);
                    m_uidm = null;
                    SetScreenMode(eScreenMode.ADD);
                    CtrlUtil.FocusControl(dtMoveDate);
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
            try
            {
                MovePartUIDM model = dmc.SaveData(new MovePartUIDM());

                ValidateBeforeSave();

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, Message.LoadMessage(Messages.eConfirm.CFM9001.ToString()));
                if (dr == MessageDialogResult.Yes)
                {

                    if (m_screenMode == eScreenMode.ADD)
                        m_movecontroller.SaveNewMovePart(model);
                    else
                        m_movecontroller.SaveUpdateMovePart(model);

                    MessageDialog.ShowInformation(this, null, new EVOFramework.Message(Messages.eInformation.INF9003.ToString()).MessageDescription);

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
        /// <summary>
        /// Load new consumption list by input: item code, order location and qty.
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="orderLoc"></param>
        /// <param name="qty"></param>
        private void LoadDataByItem(NZString itemCode, NZString orderLoc, NZDecimal qty)
        {
#warning Waiting for implement new consumption style (no/manual/auto).



            ////==============================
            //// Load data into spread and set focus to spread.
            //WorkResultEntryUIDM model = dmc.SaveData(new WorkResultEntryUIDM());

            //List<WorkResultEntryViewDTO> listItems = m_controller.LoadRequireConsumptionItems(model.ItemCode, model.OrderLoc, model.WorkResultQty);

            //foreach (WorkResultEntryViewDTO dtoListConsumption in listItems)
            //{
            //    if (!dtoListConsumption.CHILD_ORDER_LOC_CD.IsNull)
            //    {
            //        dtoListConsumption.LOC_CD = dtoListConsumption.CHILD_ORDER_LOC_CD;
            //    }
            //}

            //model.DataView = DTOUtility.ConvertListToDataTable(listItems);

            //// Adjust state all rows to "Added".
            //model.DataView.AcceptChanges();

            //if (m_screenMode == eScreenMode.ADD)
            //{
            //    for (int i = 0; i < model.DataView.Rows.Count; i++)
            //    {
            //        model.DataView.Rows[i].SetAdded();
            //    }
            //}

            //// Initialize Require Child Item Consumption List.
            //m_listRequireChildItems.Clear();
            //m_listRequireChildItems.AddRange(listItems);

            //// generate spread.
            //if (m_screenMode == eScreenMode.ADD)
            //{
            //    // If mode ADD will generate new data to display.
            //    LoadDataTableIntoSpread(model.DataView);
            //}
            //else
            //{
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
            //}


        }

        #endregion

        #region Private method
        private void RemoveRowUnused(SheetView sheet)
        {
            //int lastRowNonEmpty = sheet.GetLastNonEmptyRow(NonEmptyItemFlag.Data);
            //if (lastRowNonEmpty != sheet.RowCount - 1)
            //{
            //    sheet.RemoveRows(sheet.RowCount - 1, 1);
            //}
        }
        private void LoadDataTableIntoSpread(DataTable dtView)
        {
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
        private void ClearAll()
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
        private void ClearAllExceptDefaultValue()
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
        /// <summary>
        /// Get child item from List of ChildItems global variables.
        /// </summary>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        private WorkResultEntryViewDTO GetChildItem(NZString itemCode)
        {
            //if (m_listRequireChildItems == null)
            //    return null;

            //for (int i = 0; i < m_listRequireChildItems.Count; i++)
            //{
            //    if (Equals(m_listRequireChildItems[i].ITEM_CD.Value, itemCode.Value))
            //    {
            //        return m_listRequireChildItems[i];
            //    }
            //}

            return null;
        }
        private NZDecimal SumConsumptionQtyByItem(NZString itemCode, params int[] excludeRow)
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

        private void ValidateBeforeSave()
        {
            MovePartValidator validator = new MovePartValidator();
            ItemValidator itemValidator = new ItemValidator();
            ValidateException error = new ValidateException();
            ErrorItem errorItem = null;

            string strLotNo = txtLotNo.Text.Trim();
            if (!(string.Empty.Equals(strLotNo)))
                CommonLib.FormatUtil.CheckFormatLotNo(new NZString(txtLotNo, strLotNo));

            errorItem = validator.CheckEmptyMoveDate(new NZDateTime(dtMoveDate, dtMoveDate.Value));
            if (null != errorItem)
                ValidateException.ThrowErrorItem(errorItem);//error.AddError(errorItem);

            errorItem = validator.CheckMoveDate(new NZDateTime(dtMoveDate, dtMoveDate.Value));
            if (null != errorItem)
                ValidateException.ThrowErrorItem(errorItem);//error.AddError(errorItem);

            errorItem = validator.CheckEmptyShift(new NZString(cboShift, cboShift.SelectedValue));
            if (null != errorItem)
                ValidateException.ThrowErrorItem(errorItem);//error.AddError(errorItem);

            //errorItem = validator.CheckEmptyMasterNo(new NZString(txtMasterNo, txtMasterNo.Text));
            //if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);//error.AddError(errorItem);

            errorItem = itemValidator.CheckEmptyItemCode(new NZString(txtMasterNo, txtMasterNo.Text));
            if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

            errorItem = validator.CheckMoveProcess(new NZString(cboFromProcess, cboFromProcess.SelectedValue),
                                                    new NZString(cboToProcess, cboToProcess.SelectedValue));
            if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);//error.AddError(errorItem);           

            errorItem = validator.CheckMoveQty(txtMoveQtyPCS.ToNZDecimal(),
                                                txtOnHandQty.ToNZDecimal());
            
            if (null != errorItem )
            {
                if (string.Empty == txtMoveQtyKG.Text)
                {
                    ValidateException.ThrowErrorItem(errorItem);//error.AddError(errorItem);
                }
                else
                {
                    errorItem = new ErrorItem(txtMoveQtyKG, TKPMessages.eValidate.VLM0177.ToString());
                    ValidateException.ThrowErrorItem(errorItem);
                }
            }
           

            //error.ThrowIfHasError();
        }
        #endregion

        #region Form event
        private void TRN080_Load(object sender, EventArgs e)
        {
            InitializeScreen();

            //if (m_editTransactionID == null)
            //{
            //    SetScreenMode(eScreenMode.ADD);

            //    WorkResultEntryUIDM model = m_controller.CreateUIDMForAddMode();
            //    dmc.LoadData(model);

            //    // Binding spread sheet with data table which has shcema, but no has any row.
            //    LoadDataTableIntoSpread(model.DataView);

            //    SysConfigBIZ sysBiz = new SysConfigBIZ();
            //    SysConfigDTO argScreenInfo = new SysConfigDTO();
            //    argScreenInfo.SYS_GROUP_ID = DataDefine.eSYSTEM_CONFIG.TRN080.SYS_GROUP_ID;
            //    argScreenInfo.SYS_KEY = (NZString)DataDefine.eSYSTEM_CONFIG.TRN080.SYS_KEY.DEFAULT_DATE.ToString();
            //    dtWorkResultDate.Value = sysBiz.GetDefaultDateForScreen(argScreenInfo);
            //}
            //else
            //{
            //    bool bCanEdit = m_transactionValidator.TransactionCanEditOrDelete(m_editTransactionID);
            //    if (bCanEdit)
            //    {
            //        SetScreenMode(eScreenMode.EDIT);
            //    }
            //    else
            //    {
            //        SetScreenMode(eScreenMode.VIEW);
            //    }

            //    WorkResultEntryUIDM model = m_controller.LoadForEditWorkResult(m_editTransactionID);
            //    dmc.LoadData(model);

            //    //txtGoodQty.Double = numWorkResultQty.Double - txtNGQty.Double;

            //    // Binding spread sheet with data table which has shcema, but no has any row.
            //    LoadDataTableIntoSpread(model.DataView);

            //    SetHilightWorkResultQty();
            //}
        }
        private void TRN080_Shown(object sender, EventArgs e)
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
        private void TRN080_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = m_dialogResult;
        }
        #endregion

        #region Control event
        private void txtRemark_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                tslControl.Select();
                tsbSaveAndNew.Select();

            }
        }
        private void numWorkResultQty_KeyPress(object sender, KeyPressEventArgs e)
        {
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
        private void btnItemCode_Click(object sender, EventArgs e)
        {
            //txtItemCode_KeyPressResult(txtPartNo, (txtPartNo.SelectedItemData != null), (NZString)txtPartNo.Text);

        }
        private void fpView_ButtonClicked(object sender, EditorNotifyEventArgs e)
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
        private void cboConsumptionCls_SelectedValueChanged(object sender, EventArgs e)
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
        private void numWorkResultQty_TextChanged(object sender, EventArgs e)
        {
            //LoadDataByItem(txtItemCode.ToNZString(), cboOrderLoc.ToNZString(), numWorkResultQty.ToNZDecimal());
        }
        private void txtNGQty_TextChanged(object sender, EventArgs e)
        {
            //if (!m_ClearControlBySystem)
            //{
            //    //txtGoodQty.Double = numWorkResultQty.Double - txtNGQty.Double;
            //    numWorkResultQty.Double = txtGoodQty.Double + txtReserveQty.Double + txtNGQty.Double;
            //    CalculateConsumption();
            //}
        }
        private void txtGoodQty_TextChanged(object sender, EventArgs e)
        {
            //if (!m_ClearControlBySystem)
            //{
            //    numWorkResultQty.Double = txtGoodQty.Double + txtReserveQty.Double + txtNGQty.Double;
            //    CalculateConsumption();
            //}
        }
        private void txtReserveQty_TextChanged(object sender, EventArgs e)
        {
            //if (!m_ClearControlBySystem)
            //{
            //    numWorkResultQty.Double = txtGoodQty.Double + txtReserveQty.Double + txtNGQty.Double;
            //    CalculateConsumption();
            //}
        }
        //private void numWorkResultQty_Leave(object sender, EventArgs e)
        //{
        //    numWorkResultQty_KeyPress(numWorkResultQty, new KeyPressEventArgs((char)Keys.Return));
        //}
        private string GetConsumptionLocation(string argItemCode)
        {
            string ret = Convert.ToString(cboFromProcess.SelectedValue);

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
        private void CalculateConsumption()
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
        private void cboOrderLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadDataByItem(txtItemCode.ToNZString(), cboOrderLoc.ToNZString(), numWorkResultQty.ToNZDecimal());

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
        private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
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
        //private void SortConsumptionData(int iAddedIndex)
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

        //private void SetHilightWorkResultQty()
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
        private void dtWorkResultDate_ValueChanged(object sender, EventArgs e)
        {
            //if (dtMoveDate.Value.HasValue)
            //{
            //    if (txtPartNo.SelectedItemData != null)
            //    {
            //        //if (txtPartNo.SelectedItemData.LOT_CONTROL_CLS == DataDefine.Convert2ClassCode(DataDefine.eLOT_CONTROL_CLS.Yes) && dtMoveDate.Value.HasValue)
            //        //{
            //        //    RunningNumberBIZ runnningBiz = new RunningNumberBIZ();

            //        //    if (dtMoveDate.Value == null)
            //        //    {
            //        //        dtMoveDate.Value = DateTime.Today;
            //        //    }
            //        //    NZString strCompleteLotNo = runnningBiz.GetCompleteLotNo(new NZDateTime(null, dtMoveDate.Value), txtPartNo.SelectedItemProcessData.STORE_LOC_CD, txtPartNo.SelectedItemData.ITEM_CD, new NZInt(null, 0));
            //        //    //txtLotNo.Text = strCompleteLotNo.StrongValue;
            //        //}

            //    }

            //}
        }
        private void lblLotSize_Click(object sender, EventArgs e)
        {

        }
        private void cboOrderLoc_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void txtPartNo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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

                if (string.Empty.Equals(txtMasterNo.Text) || cboFromProcess.SelectedValue == null)
                    return;

                decimal decOnHandQty = LoadOnHandQty(new NZString(txtMasterNo, txtMasterNo.Text.Trim()),
                                                     new NZString(cboFromProcess, cboFromProcess.SelectedValue.ToString()),
                                                     new NZDecimal());
                txtOnHandQty.Text = decOnHandQty.ToString();
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
        private void cboFromProcess_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (cboFromProcess.SelectedValue == null)
                    return;

                if (string.Empty.Equals(txtMasterNo.Text))
                    return;

                ValidateOnHandQty();

                SetDefaultProcess();

                txtMoveQtyKG_Validating(sender, e);
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }
        private void txtMasterNo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.Empty.Equals(txtMasterNo.Text.Trim()))
                {
                    txtCustomerName.Clear();
                    txtPartNo.Clear();
                    txtOnHandQty.Clear();
                    return;
                }

                if (cboFromProcess.SelectedIndex < 0)
                    return;

                ValidateOnHandQty();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }

        private void txtMoveQtyKG_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.Empty.Equals(txtMoveQtyKG.Text.Trim()))
                    return;

                ItemBIZ biz = new ItemBIZ();

                ItemWeightDTO dto = biz.ConvertKGtoPCS(new NZString(txtMasterNo, txtMasterNo.Text.Trim()),
                                    new NZString(cboFromProcess, cboFromProcess.SelectedValue),
                                    new NZDecimal(txtMoveQtyKG, txtMoveQtyKG.Text.Trim()),
                                    new NZInt(null, 1));
                //txtMoveQtyPCS.Text = dto.QtyPCS == null ? string.Empty : dto.QtyPCS.ToString();
                if (dto.QtyPCS == null)
                {
                    txtMoveQtyPCS.Text = string.Empty;
                    if (txtMoveQtyKG.Text != "") MessageDialog.ShowBusiness(this, TKPMessages.eValidate.VLM0175.ToString());
                }
                else
                {
                    txtMoveQtyPCS.Text = dto.QtyPCS.ToString();
                    int iOnhand = Convert.ToInt32(txtOnHandQty.Text.Replace(",", ""));
                    if (dto.QtyPCS > iOnhand)
                    {
                        ErrorItem errorItem = new ErrorItem(txtMoveQtyKG, TKPMessages.eValidate.VLM0177.ToString());
                        throw new BusinessException(errorItem);
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
        private void txtMoveQtyPCS_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.Empty.Equals(txtMoveQtyPCS.Text.Trim()) || string.Empty.Equals(txtOnHandQty.Text.Trim()))
                    return;
                int iOnhand = Convert.ToInt32(txtOnHandQty.Text.Replace(",",""));
                int iQtyPCS = Convert.ToInt32(txtMoveQtyPCS.Text.Replace(",",""));
                if (iQtyPCS > iOnhand)
                {
                    ErrorItem errorItem = new ErrorItem(txtMoveQtyPCS, TKPMessages.eValidate.VLM0177.ToString());
                    throw new BusinessException(errorItem);
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
        private void txtMoveQtyPCS_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                txtMoveQtyKG.Clear();
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
        #endregion

        #region Spread event

        #region Variables
        ///// <summary>
        ///// เก็บรายการของทุกฟิล์ดในแถวที่กำลังแก้
        ///// </summary>
        //private readonly Map<eColView, object> m_mapCellValue = new Map<eColView, object>();
        ///// <summary>
        ///// เก็บสถานะว่าตอนนี้ Row นั้น มีบาง Cell ที่ถูกปรับเปลี่ยนค่า
        ///// </summary>
        //private bool m_bRowHasModified = false;
        #endregion

        #region Utility method
        /// <summary>
        /// เก็บข้อมูลทุก Cell ของ Row ที่ระบุ
        /// </summary>
        /// <param name="rowIndex"></param>
        private void StoreCellValues(int rowIndex)
        {
            //m_mapCellValue.RemoveAll();
            //for (int i = 0; i < shtView.Columns.Count; i++)
            //{
            //    m_mapCellValue.Put((eColView)i, shtView.Cells[rowIndex, i].Value);
            //}
        }

        /// <summary>
        /// คืนค่า Cell ที่เก็บไว้ กลับคืนไปยัง Row ที่ระบุ
        /// </summary>
        /// <param name="rowIndex"></param>
        private void RestoreCellValues(int rowIndex)
        {
            //if (m_mapCellValue.Count > 0)
            //{
            //    for (int i = 0; i < m_mapCellValue.Count; i++)
            //    {
            //        shtView.Cells[rowIndex, (int)m_mapCellValue[i].Key].Value = m_mapCellValue[i].Value;
            //    }
            //}
        }
        #endregion

        #region Spread trigger.
        private void fpView_EditModeOn(object sender, EventArgs e)
        {
            //// ถ้าเป็นการแก้ไข Cell ใน Row เดียวกัน เป็นครั้งแรก
            //if (!m_bRowHasModified)
            //{
            //    m_bRowHasModified = true;
            //    StoreCellValues(shtView.ActiveRowIndex);
            //}
        }

        private void fpView_EditModeOff(object sender, EventArgs e)
        {

            //int rowIndex = shtView.ActiveRowIndex;
            //int colIndex = shtView.ActiveColumnIndex;

            //bool bValidateCellPass = ValidateCellEdited(rowIndex, colIndex);
            //if (!bValidateCellPass)
            //{
            //    shtView.SetActiveCell(rowIndex, colIndex);
            //}
        }

        private void fpView_LeaveCell(object sender, LeaveCellEventArgs e)
        {
            //if (m_bRowHasModified)
            //{  // เช็คว่า Cell ในแถวนั้น มีการแก้ไขค่าหรือไม่
            //    if (e.Row != e.NewRow)
            //    {  // ถ้าเป็นการเปลี่ยนแถว ต้องเช็คก่อนว่า Validate แถวผ่านหรือไม่?
            //        if (!ValidateRowSpread(e.Row, false))
            //        {
            //            e.Cancel = true;
            //        }
            //    }
            //}
        }

        private void fpView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                //if (m_bRowHasModified)
                //{
                //    int lastRowNonEmpty = shtView.GetLastNonEmptyRow(NonEmptyItemFlag.Data);
                //    if (lastRowNonEmpty != shtView.RowCount - 1)
                //    {
                //        shtView.RemoveRows(shtView.RowCount - 1, 1);
                //    }
                //    else
                //    {
                //        RestoreCellValues(shtView.ActiveRowIndex);
                //    }

                //    m_bRowHasModified = false;
                //}
                //else
                //{
                //    RemoveRowUnused(shtView);
                //}
            }
        }

        private void fpView_Validating(object sender, CancelEventArgs e)
        {

            //if (!ValidateRowSpread(shtView.ActiveRowIndex, false))
            //{
            //    e.Cancel = true;
            //}
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
            //if (column == (int)eColView.ITEM_CD ||
            //    column == (int)eColView.LOT_NO)
            //{
            //ItemValidator itemValidator = new ItemValidator();

            //NZString itemCode = new NZString(null, shtView.GetValue(row, (int)eColView.ITEM_CD));

            //// Validate Input ItemCode.
            //if (column == (int)eColView.ITEM_CD)
            //{
            //    //== Not error, but clear content all columns.
            //    if (itemCode.IsNull || itemCode.StrongValue.Trim() == String.Empty)
            //    {
            //        // Clear content on row.
            //        shtView.Cells[row, (int)eColView.ON_HAND_QTY].Value = null;
            //        shtView.Cells[row, (int)eColView.REQUEST_QTY].Value = null;
            //        shtView.Cells[row, (int)eColView.CONSUMPTION_QTY].Value = null;
            //        shtView.Cells[row, (int)eColView.INV_UM_CLS].Value = null;
            //        return true;
            //    }

            //    // Lookup Lot No
            //    //LookupData lookupLotNo = m_bizLookupData.LoadLookupLotNo(itemCode, new NZString(null, cboOrderLoc.SelectedValue), dtWorkResultDate.Value.Value.ToString("yyyyMM").ToNZString());
            //    //shtView.Cells[row, (int)eColView.LOT_NO].CellType = CtrlUtil.CreateComboBoxCellType(lookupLotNo, false);
            //}

            //ItemDTO itemDTO = m_bizItem.LoadItem(itemCode);
            //if (itemDTO == null)
            //{
            //    CtrlUtil.SpreadSetCellLocked(shtView, true, row, (int)eColView.LOT_NO);
            //    CtrlUtil.SpreadSetCellLocked(shtView, true, row, (int)eColView.LOT_BTN);
            //    shtView.Cells[row, (int)eColView.LOT_NO].Value = null;
            //    shtView.Cells[row, (int)eColView.ON_HAND_QTY].Value = null;
            //    shtView.Cells[row, (int)eColView.REQUEST_QTY].Value = null;
            //    shtView.Cells[row, (int)eColView.CONSUMPTION_QTY].Value = null;
            //    shtView.Cells[row, (int)eColView.INV_UM_CLS].Value = null;
            //}
            //else
            //{
            //    //== Update LOT_CONTROL_CLS on DataTable's current row.
            //    DataRowView dataRowView = CtrlUtil.SpreadGetDataRowFromRowIndex(shtView, row);
            //    dataRowView[WorkResultEntryViewDTO.eColumns.LOT_CONTROL_CLS.ToString()] = itemDTO.LOT_CONTROL_CLS.Value;
            //    if (itemDTO.LOT_CONTROL_CLS.StrongValue == "00")
            //    {
            //        CtrlUtil.SpreadSetCellLocked(shtView, true, row, (int)eColView.LOT_NO);
            //        CtrlUtil.SpreadSetCellLocked(shtView, true, row, (int)eColView.LOT_BTN);
            //        shtView.Cells[row, (int)eColView.LOT_NO].Value = null;
            //    }
            //    else
            //    {
            //        CtrlUtil.SpreadSetCellLocked(shtView, false, row, (int)eColView.LOT_NO);
            //        CtrlUtil.SpreadSetCellLocked(shtView, false, row, (int)eColView.LOT_BTN);
            //    }

            //    // Load INV_UM_CLS
            //    shtView.Cells[row, (int)eColView.INV_UM_CLS].Value = itemDTO.INV_UM_CLS.Value;


            //    NZString lotNo = new NZString(null, shtView.GetValue(row, (int)eColView.LOT_NO));
            //    WorkResultEntryViewDTO viewDTO = GetChildItem(itemCode);

            //    //== Load stock onhand qty.
            //    InventoryOnhandDTO inventoryOnhandDTO = m_bizInventory.LoadInventoryOnHandByCurrentPeriod(itemCode, cboOrderLoc.ToNZString(), lotNo);
            //    // not found stock.
            //    if (inventoryOnhandDTO == null)
            //    {
            //        shtView.Cells[row, (int)eColView.ON_HAND_QTY].Value = 0;
            //    }
            //    else
            //    {
            //        shtView.Cells[row, (int)eColView.ON_HAND_QTY].Value = inventoryOnhandDTO.ON_HAND_QTY.Value;
            //    } // end check stock.



            //    //== Calculate next consumption qty.
            //    if (viewDTO == null)
            //    {
            //        // ถ้า item ที่ระบุ ไม่ใช่ของ Child Item ที่จะตัด Consumption
            //        // ให้ Default ค่า ConsumptionQty = 0;
            //        shtView.Cells[row, (int)eColView.REQUEST_QTY].Value = 0;
            //        shtView.Cells[row, (int)eColView.CONSUMPTION_QTY].Value = 0;
            //    }
            //    else
            //    {
            //        shtView.Cells[row, (int)eColView.REQUEST_QTY].Value = viewDTO.REQUEST_QTY.Value;

            //        NZDecimal consumptionQty = new NZDecimal(null, shtView.Cells[row, (int)eColView.CONSUMPTION_QTY].Value);

            //        // ถ้าค่า ConsumptionQty เป็นค่าว่างหรือศูนย์ หมายถึงผู้ใช้ยังไม่มีการ Assign ค่า  ดังนั้นจะ default ค่าให้ตรงกับค่าคงเหลือที่จะต้องตัด Consumption
            //        if (consumptionQty.IsNull || consumptionQty.StrongValue == 0)
            //        {
            //            // Find new consumptionQty.
            //            DataTable dtView = (DataTable)shtView.DataSource;
            //            if (dtView == null)
            //            {
            //                shtView.Cells[row, (int)eColView.CONSUMPTION_QTY].Value = 0;
            //                return true;
            //            }

            //            NZDecimal sumConsumption = SumConsumptionQtyByItem(itemCode, row);
            //            shtView.Cells[row, (int)eColView.CONSUMPTION_QTY].Value = Math.Max(0, viewDTO.REQUEST_QTY.NVL(0) - sumConsumption.NVL(0));

            //        }
            //    }
            //}
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
            //m_bRowHasModified = false;
            return true;
        }
        #endregion

        private void txtItemCode_KeyPressResult(object sender, bool isFound, NZString ItemCD)
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

        #region Context Menu
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_keyboardSpread.OnActionAddNewRow();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_keyboardSpread.OnActionRemoveRow();
        }
        #endregion

        private void txtMoveQtyKG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (string.Empty.Equals(txtMoveQtyKG.Text))
                    CtrlUtil.FocusControl(txtMoveQtyPCS);
                else
                    CtrlUtil.FocusControl(txtLotNo);
            }
        }



    }


}
