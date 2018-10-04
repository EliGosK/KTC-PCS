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


    [Screen("TRN320", "Packing Entry", eShowAction.Normal, eScreenType.Screen, "Packing Entry")]
    public partial class TRN320_PackingEntry : CustomizeForm
    {
        #region Enum

        private enum eScreenMode
        {
            IDLE,
            VIEW,
            ADD,
            EDIT
        } ;

        public enum eColView
        {
            TRANS_ID,
            LOT_NO,
            EXTERNAL_LOT_NO,
            QTY
        } ;
        #endregion

        #region Variables
        private readonly PackingController m_controller = new PackingController();

        private readonly LookupDataBIZ m_bizLookupData = new LookupDataBIZ();
        private readonly InventoryBIZ m_bizInventory = new InventoryBIZ();
        private readonly InventoryTransBIZ m_bizInventoryTrans = new InventoryTransBIZ();
        private readonly BOMBIZ m_bizBOM = new BOMBIZ();
        private readonly ItemBIZ m_bizItem = new ItemBIZ();

        private readonly TransactionValidator m_transactionValidator = new TransactionValidator();


        private eScreenMode m_screenMode = eScreenMode.IDLE;
        private DialogResult m_dialogResult = DialogResult.Cancel;
        private KeyboardSpread m_keyboardSpread = null;
        private NZString m_editPackingNo = null;

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
        public TRN320_PackingEntry()
        {
            InitializeComponent();
        }

        public TRN320_PackingEntry(NZString PackingNo)
        {
            InitializeComponent();

            m_editPackingNo = PackingNo;
        }
        #endregion

        #region Initialize Screen
        private void InitializeScreen()
        {
            InitializeComboBox();
            InitializeLookupData();
            InitializeSpread();
            InitialFormat();

            InitializeKeyPress();
            InitlializeBindingControl();

            if (m_editPackingNo == null)
            {
                ClearAll();
                SetScreenMode(eScreenMode.ADD);
                InitialData();
            }
            else
            {
                SetScreenMode(eScreenMode.EDIT);
                LoadData();
                //bool bCanEdit = m_transactionValidator.TransactionCanEditOrDelete(new NZString(null,(hiddenTransactionID.Text)));
                //if (bCanEdit)
                //    SetScreenMode(eScreenMode.EDIT);
                //else
                //    SetScreenMode(eScreenMode.VIEW);
            }

            CheckCurrentInvPeriod();

            //dtWorkResultDate.Format = Common.CurrentUserInfomation.DateFormatString;
            //txtGoodQty.AllowNegative = true;

            //LookupDataBIZ biz = new LookupDataBIZ();
            //LookupData locationLookupData = biz.LoadLookupLocation();
            //shtView.Columns[(int)eColView.LOC_CD].CellType = CtrlUtil.CreateReadOnlyPairCellType(locationLookupData);

            //CtrlUtil.EnabledControl(false, txtItemDesc, cboConsumptionCls, txtGoodQty);

        }

        private void InitializeComboBox()
        {
            this.cboSourceProcess.Format += Common.ComboBox_Format;
            this.cboDescProcess.Format += Common.ComboBox_Format;
            this.cboShift.Format += Common.ComboBox_Format;
            this.cboPersonInCharge.Format += Common.ComboBox_Format;
        }
        private void InitializeLookupData()
        {
            LookupData lookupShiftCls = m_bizLookupData.LoadLookupClassType(DataDefine.SHIFT_CLS.ToNZString());
            cboShift.LoadLookupData(lookupShiftCls);
            cboShift.SelectedIndex = -1;

            NZString[] locationtype = new NZString[1];
            locationtype[0] = DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Production).ToNZString();
            LookupData Process = m_bizLookupData.LoadLookupLocation(locationtype);
            cboSourceProcess.LoadLookupData(Process);
            cboSourceProcess.SelectedIndex = -1;

            cboDescProcess.LoadLookupData(Process.Clone());
            cboDescProcess.SelectedIndex = -1;

            LookupData personInCharge = m_bizLookupData.LoadPersonInCharge();
            cboPersonInCharge.LoadLookupData(personInCharge);
            cboPersonInCharge.SelectedIndex = -1;
        }
        private void InitializeSpread()
        {
            shtLotNoList.ActiveSkin = Common.ACTIVE_SKIN;

            m_keyboardSpread = new KeyboardSpread(fpLotNoList);
            m_keyboardSpread.RowAdding += new KeyboardSpread.RowAddingHandler(m_keyboardSpread_RowAdding);
            m_keyboardSpread.RowAdded += new KeyboardSpread.RowAddedHandler(m_keyboardSpread_RowAdded);
            m_keyboardSpread.RowRemoving += new KeyboardSpread.RowRemovingHandler(m_keyboardSpread_RowRemoving);

            fpLotNoList.SubEditorOpening += CtrlUtil.SpreadDisableSubEditorOpening;
            CtrlUtil.MappingDataFieldWithEnum(shtLotNoList, typeof(eColView));
        }
        private void InitialFormat()
        {
            CommonLib.FormatUtil.SetNumberFormat(txtOnHand, FormatUtil.eNumberFormat.Qty_PCS);
            CommonLib.FormatUtil.SetNumberFormat(txtTotalQty, FormatUtil.eNumberFormat.Qty_PCS);
            CommonLib.FormatUtil.SetNumberFormat(txtNumberOfBox, FormatUtil.eNumberFormat.Qty_Box);

            CommonLib.FormatUtil.SetDateFormat(dtPackingDate);

            FormatUtil.SetNumberFormat(shtLotNoList.Columns[(int)eColView.QTY], FormatUtil.eNumberFormat.Qty_PCS);
        }
        private void InitializeKeyPress()
        {
            dtPackingDate.KeyPress += CtrlUtil.SetNextControl;
            cboShift.KeyPress += CtrlUtil.SetNextControl;
            txtMasterNo.KeyPress += CtrlUtil.SetNextControl;
            txtPartNo.KeyPress += CtrlUtil.SetNextControl;
            txtCustomerName.KeyPress += CtrlUtil.SetNextControl;
            txtPackNo.KeyPress += CtrlUtil.SetNextControl;
            cboPersonInCharge.KeyPress += CtrlUtil.SetNextControl;
            txtOnHand.KeyPress += CtrlUtil.SetNextControl;
            txtFGNo.KeyPress += CtrlUtil.SetNextControl;
            txtNumberOfBox.KeyPress += CtrlUtil.SetNextControl;
            //fpLotNoList.KeyPress += CtrlUtil.SetNextControl;
            txtTotalQty.KeyPress += CtrlUtil.SetNextControl;
            txtRemark.KeyPress += CtrlUtil.SetNextControl;
        }
        private void InitlializeBindingControl()
        {
            dmc.AddRangeControl
            (
                hiddenTransactionID,
                lblPackingNo,
                dtPackingDate,
                cboShift,
                txtMasterNo,
                txtPartNo,
                txtCustomerName,
                txtPackNo,
                cboPersonInCharge,
                txtTotalQty,
                txtRemark,
                cboSourceProcess,
                cboDescProcess,
                txtFGNo
            );
        }
        private void InitialData()
        {
            SysConfigBIZ sysBiz = new SysConfigBIZ();
            //SysConfigDTO argScreenInfo = new SysConfigDTO();
            //argScreenInfo.SYS_GROUP_ID = DataDefine.eSYSTEM_CONFIG.TRN320.SYS_GROUP_ID;
            //argScreenInfo.SYS_KEY = (NZString)DataDefine.eSYSTEM_CONFIG.TRN320.SYS_KEY.DEFAULT_DATE.ToString();
            //dtPackingDate.Value = sysBiz.GetDefaultDateForScreen(argScreenInfo);

            if (m_screenMode == eScreenMode.ADD)
            {
                SysConfigDTO defaultSourceLoc = sysBiz.LoadByPK(DataDefine.eSYSTEM_CONFIG.TRN320.SYS_GROUP_ID,
                                                                (NZString)DataDefine.eSYSTEM_CONFIG.TRN320.SYS_KEY.SOURCE_LOC.ToString());

                cboSourceProcess.SelectedValue = defaultSourceLoc.CHAR_DATA.StrongValue;

                SysConfigDTO defaultDescLoc = sysBiz.LoadByPK(DataDefine.eSYSTEM_CONFIG.TRN320.SYS_GROUP_ID,
                                                                (NZString)DataDefine.eSYSTEM_CONFIG.TRN320.SYS_KEY.DEST_LOC.ToString());

                cboDescProcess.SelectedValue = defaultDescLoc.CHAR_DATA.StrongValue;

                PackingEntryUIDM model = new PackingEntryUIDM();
                shtLotNoList.DataSource = model.DATA_VIEW;
                CtrlUtil.SpreadSetColumnsLocked(shtLotNoList, false, (int)eColView.LOT_NO);
                CtrlUtil.SpreadSetColumnsLocked(shtLotNoList, false, (int)eColView.EXTERNAL_LOT_NO);
                CtrlUtil.SpreadSetColumnsLocked(shtLotNoList, false, (int)eColView.QTY);
            }
        }

        #endregion

        #region Keyboard Spread
        void m_keyboardSpread_RowAdding(object sender, EventRowAdding e)
        {
            if (m_bRowHasModified)
            { // ถ้า Row กำลังแก้ไขอยู่
                if (!ValidateRowSpread(shtLotNoList.ActiveRowIndex, false))
                {
                    e.Cancel = true;
                    return;
                }
            }
            else
            {
                // ถ้าไม่มีการแก้ไข Row  แต่ก่อนที่จะเพิ่มแถวใหม่ จะต้อง Validate แถวล่าสุด (ล่างสุด) ก่อน
                if (shtLotNoList.RowCount > 0 && shtLotNoList.ActiveRowIndex >= 0)
                {
                    if (!ValidateRowSpread(shtLotNoList.RowCount - 1, true))
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }

            //if (shtLotNoList.RowCount > 0 && shtLotNoList.ActiveRowIndex >= 0) 
            //{
            //    KeyboardSpread a = (KeyboardSpread)sender;
            //    if (a.IsBinded) {
            //        if (a.Owner == fpLotNoList) {
            //            int lastRowNonEmpty = shtLotNoList.GetLastNonEmptyRow(NonEmptyItemFlag.Data);
            //            if (lastRowNonEmpty == shtLotNoList.RowCount - 1) {
            //                if ("".Equals(shtLotNoList.Cells[lastRowNonEmpty, (int)eColView.LOT_NO].Text)) {
            //                    e.Cancel = true;
            //                }
            //            }

            //        }
            //    }
            //}
        }
        void m_keyboardSpread_RowAdded(object sender, int rowIndex)
        {
            shtLotNoList.SetActiveCell(shtLotNoList.RowCount - 1, (int)eColView.LOT_NO);

            CtrlUtil.SpreadSetCellLocked(shtLotNoList, false, rowIndex, (int)eColView.LOT_NO);
            CtrlUtil.SpreadSetCellLocked(shtLotNoList, false, rowIndex, (int)eColView.EXTERNAL_LOT_NO);
            CtrlUtil.SpreadSetCellLocked(shtLotNoList, false, rowIndex, (int)eColView.QTY);

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
                case eScreenMode.VIEW:

                    CtrlUtil.EnabledControl(false, dtPackingDate, cboShift);
                    CtrlUtil.EnabledControl(false, txtMasterNo, btnSearchMasterNo);
                    CtrlUtil.EnabledControl(false, txtPartNo, txtCustomerName);
                    CtrlUtil.EnabledControl(false, txtPackNo, cboPersonInCharge, txtRemark, txtFGNo);
                    CtrlUtil.EnabledControl(false, txtOnHand, txtTotalQty, txtNumberOfBox);                    

                    CtrlUtil.FocusControl(dtPackingDate);

                    shtLotNoList.OperationMode = OperationMode.ReadOnly;

                    tsbSaveAndNew.Enabled = false;
                    tsbSaveAndClose.Enabled = false;

                    break;
                case eScreenMode.ADD:

                    CtrlUtil.EnabledControl(true, dtPackingDate, cboShift);
                    CtrlUtil.EnabledControl(true, txtMasterNo, btnSearchMasterNo);
                    CtrlUtil.EnabledControl(false, txtPartNo, txtCustomerName, txtPackNo);
                    CtrlUtil.EnabledControl(true, cboPersonInCharge, txtRemark, txtFGNo, txtNumberOfBox);
                    CtrlUtil.EnabledControl(false, txtOnHand, txtTotalQty);
                    
                    m_keyboardSpread.StartBind();
                    shtLotNoList.OperationMode = OperationMode.Normal;                   

                    CtrlUtil.FocusControl(dtPackingDate);

                    tsbSaveAndNew.Enabled = true;
                    tsbSaveAndClose.Enabled = true;

                    break;
                case eScreenMode.EDIT:

                    CtrlUtil.EnabledControl(false, dtPackingDate, txtMasterNo, btnSearchMasterNo);
                    CtrlUtil.EnabledControl(false, cboShift, txtPackNo);
                    CtrlUtil.EnabledControl(false, txtPartNo, txtCustomerName);
                    CtrlUtil.EnabledControl(true, cboPersonInCharge, txtRemark, txtFGNo);
                    CtrlUtil.EnabledControl(false, txtOnHand, txtTotalQty, txtNumberOfBox);

                    m_keyboardSpread.StartBind();
                    shtLotNoList.OperationMode = OperationMode.Normal;

                    CtrlUtil.FocusControl(cboPersonInCharge);

                    tsbSaveAndNew.Enabled = true;
                    tsbSaveAndClose.Enabled = true;
                    break;
            }

            m_screenMode = mode;
        }
        #endregion

        #region Override method
        public override void OnSaveAndNew()
        {
            fpLotNoList.StopCellEditing();
            if (m_bRowHasModified)
            { // ถ้า Row กำลังแก้ไขอยู่
                if (!ValidateRowSpread(shtLotNoList.ActiveRowIndex, false))
                {
                    return;
                }
            }
            // ต้องเรียกก่อน Save เสมอ  เพื่อ Commit ข้อมูลการแก้ไขล่าสุดบน Grid
            // ใช้ได้เฉพาะกับ Sheet ที่ผูก DataSource
            CtrlUtil.SpreadSheetRowEndEdit(shtLotNoList, shtLotNoList.ActiveRowIndex);
            RemoveRowUnused(shtLotNoList);

            if (txtNumberOfBox.Int <= 0)
                txtNumberOfBox.Int = 1; 

            ////if (txtItemCode.SelectedItemData != null)
            ////    numWorkResultQty_KeyPress(numWorkResultQty, new KeyPressEventArgs((char)Keys.Return));

            try
            {
                PackingEntryUIDM model = dmc.SaveData(new PackingEntryUIDM());
                model.DATA_VIEW = (DataTable)shtLotNoList.DataSource;
                model.DATA_VIEW.AcceptChanges();


                UpdateRecord(model.DATA_VIEW);

                if (!ValidateBeforeSave(model))
                    return;

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, Message.LoadMessage(Messages.eConfirm.CFM9001.ToString()));

                if (dr == MessageDialogResult.Yes)
                {
                    if (m_screenMode == eScreenMode.ADD)
                        m_controller.SaveNewPacking(model, txtNumberOfBox.Int == 0 ? 1 : txtNumberOfBox.Int);
                    else
                        m_controller.SaveUpdatePacking(model);

                    MessageDialog.ShowInformation(this, null, Message.LoadMessage(Messages.eInformation.INF9003.ToString()).MessageDescription);

                    //ClearAllExceptDefaultValue();
                    ClearAll();
                    SetScreenMode(eScreenMode.ADD);
                    InitialData();

                    m_dialogResult = DialogResult.OK;
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
                MessageDialog.ShowBusiness(this, null, err.Message);
            }
        }

        public override void OnSaveAndClose()
        {
            fpLotNoList.StopCellEditing();
            if (m_bRowHasModified)
            {
                // ถ้า Row กำลังแก้ไขอยู่
                if (!ValidateRowSpread(shtLotNoList.ActiveRowIndex, false))
                {
                    return;
                }
            }
            // ต้องเรียกก่อน Save เสมอ  เพื่อ Commit ข้อมูลการแก้ไขล่าสุดบน Grid
            // ใช้ได้เฉพาะกับ Sheet ที่ผูก DataSource
            CtrlUtil.SpreadSheetRowEndEdit(shtLotNoList, shtLotNoList.ActiveRowIndex);
            RemoveRowUnused(shtLotNoList);

            if (txtNumberOfBox.Int <= 0)
                txtNumberOfBox.Int = 1; 

            ////if (txtItemCode.SelectedItemData != null)
            ////    numWorkResultQty_KeyPress(numWorkResultQty, new KeyPressEventArgs((char)Keys.Return));

            try
            {

                PackingEntryUIDM model = dmc.SaveData(new PackingEntryUIDM());
                model.DATA_VIEW = (DataTable)shtLotNoList.DataSource;

                UpdateRecord(model.DATA_VIEW);

                if (!ValidateBeforeSave(model))
                    return;

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, Message.LoadMessage(Messages.eConfirm.CFM9001.ToString()));

                if (dr == MessageDialogResult.Yes)
                {
                    if (m_screenMode == eScreenMode.ADD)
                        m_controller.SaveNewPacking(model, txtNumberOfBox.Int == 0 ? 1 : txtNumberOfBox.Int);
                    else
                        m_controller.SaveUpdatePacking(model);

                    MessageDialog.ShowInformation(this, null, Message.LoadMessage(Messages.eInformation.INF9003.ToString()).MessageDescription);

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
                MessageDialog.ShowBusiness(this, null, err.Message);
            }
        }


        #endregion

        #region Load Data

        private void LoadData()
        {

            PackingEntryUIDM model = m_controller.LoadPackingByPackingNo(m_editPackingNo);
            dmc.LoadData(model);

            // Binding spread sheet with data table which has shcema, but no has any row.
            LoadDataTableIntoSpread(model.DATA_VIEW);

            decimal decOnHandQty = LoadOnHandQty(new NZString(txtMasterNo, txtMasterNo.Text.Trim()),
                                                     new NZString(cboSourceProcess, cboSourceProcess.SelectedValue.ToString()),
                                                     new NZDecimal(txtTotalQty, txtTotalQty.Decimal));

            txtOnHand.Text = decOnHandQty.ToString();
        }

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

        private decimal LoadOnHandQty(NZString MasterNo, NZString ProcessCD, NZDecimal TotalQty)
        {
            decimal decOnHandQty = 0;

            //Load Onhand Qty
            InventoryBIZ bizInv = new InventoryBIZ();

            InventoryOnhandDTO dtoOnhand = bizInv.LoadInventoryOnHandByItem(MasterNo, ProcessCD);
            if (dtoOnhand != null)
                decOnHandQty = dtoOnhand.ON_HAND_QTY.StrongValue;

            if (!TotalQty.IsNull)
                decOnHandQty = decOnHandQty + TotalQty;

            return decOnHandQty;
        }
        protected void CalculateTotalQty()
        {
            decimal decTotalQty = 0;
            decimal decQty = 0;
            for (int i = 0; i < shtLotNoList.RowCount; i++)
            {
                if (shtLotNoList.Cells[i, (int)eColView.QTY].Value != null)
                {
                    decQty = Convert.ToDecimal(shtLotNoList.Cells[i, (int)eColView.QTY].Value);
                    decTotalQty = decTotalQty + decQty;
                }
            }

            txtTotalQty.Decimal = decTotalQty;
        }

        private void RemoveRowUnused(SheetView sheet)
        {
            //int lastRowNonEmpty = sheet.GetLastNonEmptyRow(NonEmptyItemFlag.Data);
            //if (lastRowNonEmpty != sheet.RowCount - 1) 
            //{
            //    sheet.RemoveRows(sheet.RowCount - 1, 1);
            //}

            for (int i = 0; i < sheet.RowCount; i++) 
            {
                if (string.Empty.Equals(shtLotNoList.Cells[i, (int)eColView.TRANS_ID].Text.Trim()) &&
                    string.Empty.Equals(shtLotNoList.Cells[i, (int)eColView.LOT_NO].Text.Trim()) &&
                    string.Empty.Equals(shtLotNoList.Cells[i, (int)eColView.EXTERNAL_LOT_NO].Text.Trim()) &&
                    string.Empty.Equals(shtLotNoList.Cells[i, (int)eColView.QTY].Text.Trim())) 
                {
                    sheet.RemoveRows(i, 1);
                    i--;
                }
            }
        }
        private void LoadDataTableIntoSpread(DataTable dtView)
        {
            shtLotNoList.RowCount = 0;
            shtLotNoList.DataSource = dtView;

            // update locked cell by condition on each row.
            for (int i = 0; i < shtLotNoList.RowCount; i++)
            {
                DataRowView drv = CtrlUtil.SpreadGetDataRowFromRowIndex(shtLotNoList, i);
                if (drv == null)
                    continue;

                bool bEditMode = m_screenMode == eScreenMode.EDIT;
                CtrlUtil.SpreadSetCellLocked(shtLotNoList, true, i, (int)eColView.LOT_NO);
                CtrlUtil.SpreadSetCellLocked(shtLotNoList, true, i, (int)eColView.EXTERNAL_LOT_NO);
                CtrlUtil.SpreadSetCellLocked(shtLotNoList, !bEditMode, i, (int)eColView.QTY);
            }

        }

        private void ClearAll()
        {
            CtrlUtil.ClearControlData(hiddenTransactionID, lblPackingNo, dtPackingDate, cboShift);
            CtrlUtil.ClearControlData(txtMasterNo, txtPartNo, txtCustomerName, cboSourceProcess, cboDescProcess);
            CtrlUtil.ClearControlData(txtPackNo, cboPersonInCharge, txtOnHand, txtTotalQty, txtRemark, txtFGNo);

            SysConfigBIZ sysBiz = new SysConfigBIZ();
            SysConfigDTO argScreenInfo = new SysConfigDTO();
            argScreenInfo.SYS_GROUP_ID = DataDefine.eSYSTEM_CONFIG.TRN320.SYS_GROUP_ID;
            argScreenInfo.SYS_KEY = (NZString)DataDefine.eSYSTEM_CONFIG.TRN320.SYS_KEY.DEFAULT_DATE.ToString();
            dtPackingDate.Value = sysBiz.GetDefaultDateForScreen(argScreenInfo);

            //default box = 1
            txtNumberOfBox.Text = "1";

            ClearSpread();

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
        private void ClearSpread()
        {
            shtLotNoList.RowCount = 0;
            if (shtLotNoList.DataSource != null)
                ((DataTable)shtLotNoList.DataSource).Rows.Clear();


            PackingEntryUIDM model = new PackingEntryUIDM();
            shtLotNoList.DataSource = model.DATA_VIEW;

            //shtLotNoList.RowCount = 5;
        }
        private void ClearAllExceptDefaultValue()
        {
            CtrlUtil.ClearControlData(hiddenTransactionID, lblPackingNo);
            CtrlUtil.ClearControlData(txtPackNo);

            //default box = 1
            txtNumberOfBox.Text = "1";

            PackingEntryUIDM model = dmc.SaveData(new PackingEntryUIDM());
            model.DATA_VIEW = (DataTable)shtLotNoList.DataSource;
            model.DATA_VIEW.AcceptChanges();

            foreach (DataRow dr in model.DATA_VIEW.Rows)
            {
                dr[(int)eColView.QTY] = DBNull.Value;
            }

            model.DATA_VIEW.AcceptChanges();
            shtLotNoList.DataSource = (DataTable)model.DATA_VIEW;

            for (int rowIndex = 0; rowIndex < shtLotNoList.RowCount; rowIndex++) 
            {
                CtrlUtil.SpreadSetCellLocked(shtLotNoList, false, rowIndex, (int)eColView.LOT_NO);
                CtrlUtil.SpreadSetCellLocked(shtLotNoList, false, rowIndex, (int)eColView.EXTERNAL_LOT_NO);
                CtrlUtil.SpreadSetCellLocked(shtLotNoList, false, rowIndex, (int)eColView.QTY);
            }

            decimal decOnHandQty = LoadOnHandQty(new NZString(txtMasterNo, txtMasterNo.Text.Trim()),
                                                     new NZString(cboSourceProcess, cboSourceProcess.SelectedValue.ToString()),
                                                     new NZDecimal());

            txtOnHand.Text = decOnHandQty.ToString();

            CalculateTotalQty();
        }

        private bool ValidateBeforeSave(PackingEntryUIDM model)
        {
            PackingValidator validator = new PackingValidator();

            ValidateException.ThrowErrorItem(validator.CheckPackingDate(model.PACKING_DATE));
            ValidateException.ThrowErrorItem(validator.CheckEmptyShiftType(model.SHIFT_CLS));
            ValidateException.ThrowErrorItem(validator.CheckEmptyMasterNo(model.MASTER_NO));
            //ValidateException.ThrowErrorItem(validator.CheckEmptyFGNo(model.FG_NO));
            //ValidateException.ThrowErrorItem(validator.CheckPackNo(model.PACK_NO));

            if (shtLotNoList.RowCount == 0)
                ValidateException.ThrowErrorItem(new ErrorItem(null, TKPMessages.eValidate.VLM0186.ToString()));

            for (int iRow = 0; iRow < shtLotNoList.RowCount; iRow++)
            {
                if (!ValidateRowSpread(iRow, true))
                    return false;
                //object src_qty = shtLotNoList.Cells[iRow, (int)eColView.QTY].Value;

                //if (src_qty == null || Convert.ToInt32(src_qty) <= 0)
                //{
                //    ValidateException.ThrowErrorItem(new ErrorItem(null, TKPMessages.eValidate.VLM0175.ToString()));
                //}
            }

            return true;
        }

        private void UpdateRecord(DataTable dtLotList)
        {
            //update value
            foreach (DataRow dr in dtLotList.Rows)
            {
                if (dr.RowState == DataRowState.Unchanged)
                    dr.SetModified();
            }
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
        #endregion

        #region Form event
        private void TRN080_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }

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
        #endregion

        #region Spread event

        #region Variables
        /// <summary>
        /// เก็บรายการของทุกฟิล์ดในแถวที่กำลังแก้
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
            for (int i = 0; i < shtLotNoList.Columns.Count; i++)
            {
                m_mapCellValue.Put((eColView)i, shtLotNoList.Cells[rowIndex, i].Value);
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
                    shtLotNoList.Cells[rowIndex, (int)m_mapCellValue[i].Key].Value = m_mapCellValue[i].Value;
                }
            }
        }
        #endregion

        #region Spread trigger.

        private void fpLotNoList_EditModeOff(object sender, EventArgs e)
        {
            int rowIndex = shtLotNoList.ActiveRowIndex;
            int colIndex = shtLotNoList.ActiveColumnIndex;

            bool bValidateCellPass = ValidateCellEdited(rowIndex, colIndex);
            if (!bValidateCellPass)
            {
                shtLotNoList.SetActiveCell(rowIndex, colIndex);
            }
        }

        private void fpLotNoList_LeaveCell(object sender, LeaveCellEventArgs e)
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

        private void fpLotNoList_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyData == Keys.Escape)
            //{
            //    if (m_bRowHasModified)
            //    {
            //        int lastRowNonEmpty = shtLotNoList.GetLastNonEmptyRow(NonEmptyItemFlag.Data);
            //        if (lastRowNonEmpty != shtLotNoList.RowCount - 1)
            //        {
            //            shtLotNoList.RemoveRows(shtLotNoList.RowCount - 1, 1);
            //        }
            //        else
            //        {
            //            RestoreCellValues(shtLotNoList.ActiveRowIndex);
            //        }

            //        m_bRowHasModified = false;
            //    }
            //    else
            //    {
            //        RemoveRowUnused(shtLotNoList);
            //    }
            //}


            //else if (e.KeyData == Keys.Enter)
            //{                
            //    CtrlUtil.SpreadSheetRowEndEdit(shtLotNoList, shtLotNoList.ActiveRowIndex);

            //    MoveNextCell(shtLotNoList);
            //    //m_bRowHasModified = false;                
            //}
        }

        private void MoveNextCell()
        {
            //if (shtLotNoList.ActiveRowIndex == shtLotNoList.RowCount - 1 && shtLotNoList.ActiveColumnIndex == (int)eColView.QTY)
            //{
            //    m_keyboardSpread.OnActionAddNewRow();
            //    return;
            //}

            int iNextRow = shtLotNoList.ActiveRowIndex;
            int iNextCol = shtLotNoList.ActiveColumnIndex;

            if (iNextCol == (int)eColView.QTY)
            {
                iNextRow = iNextRow + 1;
                iNextCol = 0;
            }
            else 
            {
                iNextCol = iNextCol + 1;
            }

            for (int iRow = iNextRow; iRow < shtLotNoList.RowCount; iRow++) 
            {
                for (int iCol = iNextCol; iCol < shtLotNoList.ColumnCount; iCol++)
                {
                    shtLotNoList.SetActiveCell(iRow, iCol);
                    fpLotNoList.ShowActiveCell(VerticalPosition.Nearest, HorizontalPosition.Nearest);

                    if (!shtLotNoList.Cells[iRow, iCol].Locked)
                        return;                    
                }
            }
        }

        private void fpLotNoList_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateRowSpread(shtLotNoList.ActiveRowIndex, false))
            {
                e.Cancel = true;
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
            try
            {
                switch (column)
                {
                    //case (int)eColView.LOT_NO:

                    //    if (string.Empty.Equals(shtLotNoList.Cells[row, column].Text))
                    //        return true;

                    //    FormatUtil.CheckFormatLotNo(new NZString(null, shtLotNoList.Cells[row, column].Text));

                    //    break;

                    case (int)eColView.QTY:

                        if (string.Empty.Equals(shtLotNoList.Cells[row, column].Text))
                            return true;

                        CalculateTotalQty();
                        break;
                }
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                //err.Error.FocusOnControl();
                //shtLotNoList.SetActiveCell(row, column); 
                return false;
            }
            catch (ValidateException err)
            {
                MessageDialog.ShowBusiness(this, err.ErrorResults[0].Message);
                //err.ErrorResults[0].FocusOnControl();
                //shtLotNoList.SetActiveCell(row, column);
                return false;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
                return false;
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

            if (shtLotNoList.RowCount <= 0)
                return true;

            object src_lot_no = shtLotNoList.Cells[row, (int)eColView.LOT_NO].Value;
            object src_cust_lot_no = shtLotNoList.Cells[row, (int)eColView.EXTERNAL_LOT_NO].Value;
            object src_qty = shtLotNoList.Cells[row, (int)eColView.QTY].Value;

            if (src_lot_no == null && src_cust_lot_no == null && src_qty == null)
                return false;

            if (string.Empty.Equals(shtLotNoList.Cells[row, (int)eColView.LOT_NO].Text.Trim())) 
            {
                MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0011.ToString()));
                return false;
            }

            //check format lotno
            if (!(string.Empty.Equals(shtLotNoList.Cells[row, (int)eColView.LOT_NO].Text)))
            {
                try
                {
                    FormatUtil.CheckFormatLotNo(new NZString(null, shtLotNoList.Cells[row, (int)eColView.LOT_NO].Text));
                }
                catch (ValidateException ex)
                {
                    MessageDialog.ShowBusiness(this, ex.ErrorResults[0].Message);
                    return false;
                }
            }

            //Check dupllicate lot
            for (int iRow = 0; iRow < shtLotNoList.Rows.Count; iRow++)
            {
                if (iRow == row)
                    continue;

                // Check key duplidate.
                object lot_no = shtLotNoList.Cells[iRow, (int)eColView.LOT_NO].Value;

                if (Equals(src_lot_no, lot_no))
                {
                    MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0189.ToString()));
                    return false;
                }
            }

            //Check Qty > 0
            if (src_qty == null || Convert.ToInt32(src_qty) <= 0)
            {
                MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0175.ToString()));
                return false;
            }

            // ถ้า Validate Row ผ่าน แสดงว่า แถวนั้นไม่จำเป็นต้องเช็คอีกรอบ
            m_bRowHasModified = false;
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

            try {
                InventoryPeriodValidator val = new InventoryPeriodValidator();
                ErrorItem err = val.CheckInventoryCurrentPeriod();
                if (err != null) {
                    MessageDialog.ShowInformation(this, "Out of period", err.Message.MessageDescription);
                }

            }
            catch (Exception) {

            }
        }
        #endregion

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_keyboardSpread.OnActionAddNewRow();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_keyboardSpread.OnActionRemoveRow();
            CalculateTotalQty();
        }

        private void btnItemCode_Click(object sender, EventArgs e)
        {
            //txtItemCode_KeyPressResult(txtMasterNo, (txtMasterNo.SelectedItemData != null), (NZString)txtMasterNo.Text);

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
            string ret = Convert.ToString(cboSourceProcess.SelectedValue);

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
            if (dtPackingDate.Value.HasValue)
            {
                //if (txtMasterNo.SelectedItemData != null)
                //{
                //if (txtPartNo.SelectedItemData.LOT_CONTROL_CLS == DataDefine.Convert2ClassCode(DataDefine.eLOT_CONTROL_CLS.Yes) && dtPackingDate.Value.HasValue)
                //{
                //    RunningNumberBIZ runnningBiz = new RunningNumberBIZ();

                //    if (dtPackingDate.Value == null)
                //    {
                //        dtPackingDate.Value = DateTime.Today;
                //    }
                //    NZString strCompleteLotNo = runnningBiz.GetCompleteLotNo(new NZDateTime(null, dtPackingDate.Value), txtPartNo.SelectedItemProcessData.STORE_LOC_CD, txtPartNo.SelectedItemData.ITEM_CD, new NZInt(null, 0));
                //    //txtLotNo.Text = strCompleteLotNo.StrongValue;
                //}

                //}

            }
        }

        private void txtMasterNo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.Empty.Equals(txtMasterNo.Text))
                    return;

                if (this.m_screenMode == eScreenMode.EDIT)
                    return;

                if (cboSourceProcess.SelectedIndex < 0)
                    return;

                decimal decOnHandQty = LoadOnHandQty(new NZString(txtMasterNo, txtMasterNo.Text.Trim()),
                                                     new NZString(cboSourceProcess, cboSourceProcess.SelectedValue.ToString()),
                                                     new NZDecimal());

                txtOnHand.Text = decOnHandQty.ToString();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }

        }

        private void txtPackNo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (m_screenMode != eScreenMode.ADD)
                    return;

                InventoryBIZ biz = new InventoryBIZ();
                if (biz.PackNoIsExist(new NZString(null, txtPackNo.Text)))
                {
                    MessageDialog.ShowInformation(this, Message.LoadMessage(TKPMessages.eInformation.INF0002.ToString()).MessageCode, Message.LoadMessage(TKPMessages.eInformation.INF0002.ToString()).MessageDescription);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }

        public override void OnSaveFormat()
        {
            base.OnSaveFormat();

            SheetWidthController ctrl = new SheetWidthController();
            ctrl.SaveSheetWidth(shtLotNoList, this.ScreenCode);
        }

        public override void OnResetFormat()
        {
            base.OnResetFormat();

            SheetWidthController ctrl = new SheetWidthController();
            ctrl.ResetSheetWidth(shtLotNoList);
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
            ctrl.SetSheetWidth(shtLotNoList, this.ScreenCode);
        }

        private void fpLotNoList_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }

        private void fpLotNoList_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Enter) 
            //{
            //  //  CtrlUtil.SpreadSheetRowEndEdit(shtLotNoList, shtLotNoList.ActiveRowIndex);
                
            //    MoveNextCell();
            //    m_bRowHasModified = false;
            //}
        }

        private void txtNumberOfBox_Validating(object sender, CancelEventArgs e)
        {
            if (txtNumberOfBox.Int <= 0)
                txtNumberOfBox.Int = 1; 
        }


        

       

      

    }


}
