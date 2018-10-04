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


    [Screen("TRN330", "Unpack Entry", eShowAction.Normal, eScreenType.Screen, "Unpack Entry")]
    public partial class TRN330_UnpackEntry : CustomizeForm
    {
        #region Enum

        private enum eScreenMode
        {
            VIEW,
            ADD
        } ;

        public enum eColView
        {
            CHECKBOX,
            PACK_NO,
            FG_NO,
            LOT_NO,
            EXTERNAL_LOT_NO,
            ONHAND_QTY
            
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
        public TRN330_UnpackEntry()
        {
            InitializeComponent();
        }

        public TRN330_UnpackEntry(NZString transactionID)
        {
            InitializeComponent();

            m_editTransactionID = transactionID;
        }
        #endregion

        #region Initialize Screen
        private void InitializeScreen()
        {
            //CheckCurrentInvPeriod();

            InitializeComboBox();
            InitializeSpread();
            InitializeLookupData();
            InitialData();

            CtrlUtil.EnabledControl(false, txtPartNo, txtCustomerName, txtTotalQty);
            FormatUtil.SetNumberFormat(txtTotalQty, FormatUtil.eNumberFormat.Qty_PCS);

            InitlializeBindingControl();
            InitializeKeyPress();


            if (m_editTransactionID == null)
            {
                ClearAll();
                SetScreenMode(eScreenMode.ADD);
                InitialData();
            }

            CheckCurrentInvPeriod();

        }

        #region Sub-Initialize screen method

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

        private void InitializeComboBox()
        {
            this.cboShiftCls.Format += Common.ComboBox_Format;
            this.evoComboBox1.Format += Common.ComboBox_Format;
        }

        private void InitializeLookupData()
        {

            LookupData lookupShiftCls = m_bizLookupData.LoadLookupClassType(DataDefine.SHIFT_CLS.ToNZString());
            cboShiftCls.LoadLookupData(lookupShiftCls);
            cboShiftCls.SelectedIndex = -1;

            LookupData personInCharge = m_bizLookupData.LoadPersonInCharge();
            evoComboBox1.LoadLookupData(personInCharge);
            evoComboBox1.SelectedIndex = -1;

        }

        private void InitializeSpread()
        {
            shtView.ActiveSkin = Common.ACTIVE_SKIN;
            m_keyboardSpread = new KeyboardSpread(fpView);

            shtView.Columns[(int)eColView.CHECKBOX].CellType = CtrlUtil.CreateCheckboxCellType();
            shtView.Columns[(int)eColView.CHECKBOX].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;

            m_keyboardSpread.RowAdding += new KeyboardSpread.RowAddingHandler(m_keyboardSpread_RowAdding);
            m_keyboardSpread.RowAdded += new KeyboardSpread.RowAddedHandler(m_keyboardSpread_RowAdded);
            m_keyboardSpread.RowRemoving += new KeyboardSpread.RowRemovingHandler(m_keyboardSpread_RowRemoving);

            fpView.ContextMenuStrip = null;
            fpView.SubEditorOpening += CtrlUtil.SpreadDisableSubEditorOpening;
            LookupDataBIZ biz = new LookupDataBIZ();

            FormatUtil.SetNumberFormat(shtView.Columns[(int)eColView.ONHAND_QTY], FormatUtil.eNumberFormat.Qty_PCS);

            //shtView.Columns[(int)eColView.INV_UM_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(biz.LoadLookupClassType(DataDefine.UM_CLS.ToNZString()));
            CtrlUtil.MappingDataFieldWithEnum(shtView, typeof(eColView));
        }

        private void InitialFormat()
        {

            CommonLib.FormatUtil.SetDateFormat(dtWorkResultDate);
            CommonLib.FormatUtil.SetNumberFormat(txtTotalQty, FormatUtil.eNumberFormat.Total_Qty_PCS);
        }

        private void InitlializeBindingControl()
        {
            dmc.AddRangeControl(
                lblWorkResultNo,
                dtWorkResultDate,
                cboShiftCls,
                txtItemCode,
                txtPartNo,
                txtCustomerName,
                evoComboBox1,
                txtRemark,
                txtLotNo,
                txtTotalQty
                );
        }

        private void InitializeKeyPress()
        {

            dtWorkResultDate.KeyPress += CtrlUtil.SetNextControl;
            cboShiftCls.KeyPress += CtrlUtil.SetNextControl;
            txtItemCode.KeyPress += CtrlUtil.SetNextControl;
            txtPartNo.KeyPress += CtrlUtil.SetNextControl;
            txtCustomerName.KeyPress += CtrlUtil.SetNextControl;
            evoComboBox1.KeyPress += CtrlUtil.SetNextControl;
            txtRemark.KeyPress += CtrlUtil.SetNextControl;
            txtLotNo.KeyPress += CtrlUtil.SetNextControl;
            txtTotalQty.KeyPress += CtrlUtil.SetNextControl;
        }

        private void InitialData()
        {

            SysConfigBIZ sysBiz = new SysConfigBIZ();
            SysConfigDTO argScreenInfo = new SysConfigDTO();
            argScreenInfo.SYS_GROUP_ID = DataDefine.eSYSTEM_CONFIG.TRN330.SYS_GROUP_ID;
            argScreenInfo.SYS_KEY = (NZString)DataDefine.eSYSTEM_CONFIG.TRN330.SYS_KEY.DEFAULT_DATE.ToString();
            dtWorkResultDate.Value = sysBiz.GetDefaultDateForScreen(argScreenInfo);

            if (m_screenMode == eScreenMode.ADD)
            {
                SysConfigDTO defaultSourceLoc = sysBiz.LoadByPK(DataDefine.eSYSTEM_CONFIG.TRN330.SYS_GROUP_ID,
                                                                (NZString)DataDefine.eSYSTEM_CONFIG.TRN330.SYS_KEY.SOURCE_LOC.ToString());


                SysConfigDTO defaultDescLoc = sysBiz.LoadByPK(DataDefine.eSYSTEM_CONFIG.TRN330.SYS_GROUP_ID,
                                                                (NZString)DataDefine.eSYSTEM_CONFIG.TRN330.SYS_KEY.DEST_LOC.ToString());



                UnPackingEntryUIDM model = new UnPackingEntryUIDM();
                shtView.DataSource = model.DATA_VIEW;
                shtView.OperationMode = OperationMode.Normal;
            }
        }
        #endregion

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
                    CtrlUtil.EnabledControl(true, dtWorkResultDate, cboShiftCls);
                    CtrlUtil.EnabledControl(true, txtItemCode, btnItemCode);
                    CtrlUtil.EnabledControl(false, txtPartNo, txtCustomerName);
                    CtrlUtil.EnabledControl(true, evoComboBox1, txtRemark);
                    CtrlUtil.EnabledControl(true, txtLotNo, btnGenerate);
                    CtrlUtil.EnabledControl(false,txtTotalQty);

                    m_keyboardSpread.StartBind();

                    shtView.OperationMode = OperationMode.Normal;

                    CtrlUtil.FocusControl(dtWorkResultDate);
                    CtrlUtil.SpreadSetColumnsLocked(shtView, false, (int)eColView.CHECKBOX);
                    CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.PACK_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.LOT_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.EXTERNAL_LOT_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.ONHAND_QTY);

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

            try
            {
                UnPackingEntryUIDM model = dmc.SaveData(new UnPackingEntryUIDM());
                model.DATA_VIEW = (DataTable)shtView.DataSource;

                //UpdateRecord(model.DATA_VIEW);

                ValidateBeforeSave(model);

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, Message.LoadMessage(Messages.eConfirm.CFM9001.ToString()));

                if (dr == MessageDialogResult.Yes)
                {

                    for (int i = 0; i < shtView.RowCount; i++)
                    {
                        Boolean Flag = Convert.ToBoolean(shtView.Cells[i, (int)eColView.CHECKBOX].Value);
                        if (Flag == false)
                        {
                            model.DATA_VIEW.Rows.RemoveAt(i);
                            i = i - 1;
                        }
                    }

                    model.DATA_VIEW.AcceptChanges();

                    if (m_screenMode == eScreenMode.ADD)
                        m_controller.SaveNewUnPacking(model);
                    //else
                    //    m_controller.SaveUpdatePacking(model);

                    MessageDialog.ShowInformation(this, null, Message.LoadMessage(Messages.eInformation.INF9003.ToString()).MessageDescription);

                    ClearAllExceptDefaultValue();

                    SetScreenMode(eScreenMode.ADD);
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
                UnPackingEntryUIDM model = dmc.SaveData(new UnPackingEntryUIDM());
                model.DATA_VIEW = (DataTable)shtView.DataSource;

                //UpdateRecord(model.DATA_VIEW);

                ValidateBeforeSave(model);

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, Message.LoadMessage(Messages.eConfirm.CFM9001.ToString()));

                if (dr == MessageDialogResult.Yes)
                {

                    for (int i = 0; i < shtView.RowCount; i++)
                    {
                        Boolean Flag = Convert.ToBoolean(shtView.Cells[i, (int)eColView.CHECKBOX].Value);
                        if (Flag == false)
                        {
                            model.DATA_VIEW.Rows.RemoveAt(i);
                            i = i - 1;
                        }
                    }

                    model.DATA_VIEW.AcceptChanges();
                    if (m_screenMode == eScreenMode.ADD)
                        m_controller.SaveNewUnPacking(model);
                    //else
                    //    m_controller.SaveUpdatePacking(model);

                    MessageDialog.ShowInformation(this, null, Message.LoadMessage(Messages.eInformation.INF9003.ToString()).MessageDescription);

                    ClearAllExceptDefaultValue();

                    SetScreenMode(eScreenMode.ADD);
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
        /// <summary>
        /// Load new consumption list by input: item code, order location and qty.
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="orderLoc"></param>
        /// <param name="qty"></param>
        private void LoadData()
        {
            SysConfigBIZ sysBiz = new SysConfigBIZ();
            SysConfigDTO defaultSourceLoc = sysBiz.LoadByPK(DataDefine.eSYSTEM_CONFIG.TRN330.SYS_GROUP_ID,
                                                               (NZString)DataDefine.eSYSTEM_CONFIG.TRN330.SYS_KEY.SOURCE_LOC.ToString());

            DataTable model = m_controller.LoadPackingList(txtItemCode.Text.ToNZString(), defaultSourceLoc.CHAR_DATA, txtLotNo.Text.ToNZString());
            shtView.DataSource = model;

            for (int i = 0; i < shtView.RowCount; i++)
            {
                shtView.Cells[i, (int)eColView.CHECKBOX].Value = false;
            }

            CalculateTotalQty();
            
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

        private void ClearAll()
        {
            CtrlUtil.ClearControlData(lblWorkResultNo, dtWorkResultDate, cboShiftCls);
            CtrlUtil.ClearControlData(txtItemCode, txtPartNo, txtCustomerName, evoComboBox1, txtRemark);
            CtrlUtil.ClearControlData(txtLotNo);

            ClearSpread();
        }

        private void ClearSpread()
        {
            shtView.RowCount = 0;
            if (shtView.DataSource != null)
                ((DataTable)shtView.DataSource).Rows.Clear();
        }

        private void ClearAllExceptDefaultValue()
        {
            m_ClearControlBySystem = true;
            CtrlUtil.ClearControlData(lblWorkResultNo, dtWorkResultDate, cboShiftCls);
            CtrlUtil.ClearControlData(txtItemCode, txtPartNo, txtCustomerName, evoComboBox1, txtRemark);
            CtrlUtil.ClearControlData(txtLotNo);

            lblWorkResultNo.Text = string.Empty;
            shtView.RowCount = 0;
            if (shtView.DataSource != null)
                ((DataTable)shtView.DataSource).Rows.Clear();
            m_ClearControlBySystem = false;

            CalculateTotalQty();
        }

        private void ValidateBeforeSave(UnPackingEntryUIDM model)
        {
            PackingValidator validator = new PackingValidator();

            ValidateException.ThrowErrorItem(validator.CheckUnpackingDate(model.UNPACKING_DATE));
            ValidateException.ThrowErrorItem(validator.CheckEmptyShiftType(model.SHIFT_CLS));
            ValidateException.ThrowErrorItem(validator.CheckEmptyMasterNo(model.ITEM_CD));

            if (shtView.RowCount == 0)
                ValidateException.ThrowErrorItem(new ErrorItem(null, TKPMessages.eValidate.VLM0186.ToString()));

            int count = 0;
            for (int i = 0; i < shtView.RowCount; i++)
            {
                Boolean Flag = Convert.ToBoolean(shtView.Cells[i, (int)eColView.CHECKBOX].Value);
                if (Flag == false)
                {
                    count += 1;
                }
            }
            if (count == shtView.RowCount)
            {
                ValidateException.ThrowErrorItem(new ErrorItem(null, TKPMessages.eValidate.VLM0201.ToString()));
            }

        }

        private void UpdateRecord(DataTable dtView)
        {
            //update value
            foreach (DataRow dr in dtView.Rows)
            {
                if (dr.RowState == DataRowState.Unchanged)
                    dr.SetModified();
            }
        }

        protected void CalculateTotalQty()
        {
            decimal decTotalQty = 0;
            decimal decQty = 0;
            for (int i = 0; i < shtView.RowCount; i++)
            {
                if (shtView.Cells[i, (int)eColView.ONHAND_QTY].Value != null)
                {
                    Boolean check = Convert.ToBoolean(shtView.Cells[i, (int)eColView.CHECKBOX].Value);
                    if (check == true)
                    {
                        decQty = Convert.ToDecimal(shtView.Cells[i, (int)eColView.ONHAND_QTY].Value);
                        decTotalQty = decTotalQty + decQty;
                    }
                }
            }

            txtTotalQty.Decimal = decTotalQty;
        }

        #endregion

        #region Form event
        private void TRN080_Load(object sender, EventArgs e)
        {
            InitializeScreen();
        }

        private void TRN080_Shown(object sender, EventArgs e)
        {
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
                //tslControl.Select();
                //tsbSaveAndNew.Select();

            }
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
                bool CheckValue = Convert.ToBoolean(shtView.Cells[shtView.ActiveRowIndex, (int)eColView.CHECKBOX].Value);
                string PackNo = Convert.ToString(shtView.Cells[shtView.ActiveRowIndex,(int)eColView.PACK_NO].Value);

                for (int i = 0; i < shtView.RowCount; i++)
                {
                    if (Convert.ToString(shtView.Cells[i, (int)eColView.PACK_NO].Value) == PackNo)
                    {
                        shtView.Cells[i, (int)eColView.CHECKBOX].Value = CheckValue;
                    }
                }

                CalculateTotalQty();
            }

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
            if (column == (int)eColView.PACK_NO ||
                column == (int)eColView.LOT_NO)
            {
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

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_keyboardSpread.OnActionAddNewRow();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_keyboardSpread.OnActionRemoveRow();
            CalculateTotalQty();
        }

        private string GetConsumptionLocation(string argItemCode)
        {
            string ret = "";
            return ret;
        }

        private void dtWorkResultDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtWorkResultDate.Value.HasValue)
            {
                if (txtItemCode.SelectedItemData != null)
                {

                }

            }
        }

        private void txtItemCode_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.Empty.Equals(txtItemCode.Text.Trim()))
                {
                    txtCustomerName.Clear();
                    txtPartNo.Clear();
                    return;
                }

                //ValidateOnHandQty();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        //private void fpView_CellClick(object sender, CellClickEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Column == (int)eColView.CHECKBOX)
        //        {
        //            int check = Convert.ToInt32(shtView.Cells[e.Row, (int)eColView.CHECKBOX].Value);
        //            if (check == 0)
        //            {
        //                string checklot = (NZString)shtView.Cells[e.Row, (int)eColView.PACK_NO].Text;
        //                string iPriority;
        //                for (int i = 0; i < shtView.RowCount; i++)
        //                {
        //                    iPriority = (NZString)shtView.Cells[i, (int)eColView.PACK_NO].Text;

        //                    if (iPriority == checklot)
        //                    {
        //                        shtView.Cells[i, (int)eColView.CHECKBOX].Value = 1;
        //                    }
        //                }

        //            }

        //            else if (check == 1)
        //            {
        //                string checklot = (NZString)shtView.Cells[e.Row, (int)eColView.PACK_NO].Text;
        //                string iPriority;
        //                for (int i = 0; i < shtView.RowCount; i++)
        //                {
        //                    iPriority = (NZString)shtView.Cells[i, (int)eColView.PACK_NO].Text;

        //                    if (iPriority == checklot)
        //                    {
        //                        shtView.Cells[i, (int)eColView.CHECKBOX].Value = 0;
        //                    }
        //                }

        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageDialog.ShowBusiness(this, ex.Message);
        //    }
        //}

        private void fpView_ButtonClicked(object sender, EditorNotifyEventArgs e)
        {
            try
            {
                if (e.Column == (int)eColView.CHECKBOX)
                {
                    Boolean check = Convert.ToBoolean(shtView.Cells[e.Row, (int)eColView.CHECKBOX].Value);

                    if (check == true)
                    {
                        string checklot = (NZString)shtView.Cells[e.Row, (int)eColView.PACK_NO].Text;
                        string iPriority;
                        for (int i = 0; i < shtView.RowCount; i++)
                        {
                            iPriority = (NZString)shtView.Cells[i, (int)eColView.PACK_NO].Text;

                            if (iPriority == checklot)
                            {
                                shtView.Cells[i, (int)eColView.CHECKBOX].Value = true;
                            }
                        }

                    }

                    else if (check == false)
                    {
                        string checklot = (NZString)shtView.Cells[e.Row, (int)eColView.PACK_NO].Text;
                        string iPriority;
                        for (int i = 0; i < shtView.RowCount; i++)
                        {
                            iPriority = (NZString)shtView.Cells[i, (int)eColView.PACK_NO].Text;

                            if (iPriority == checklot)
                            {
                                shtView.Cells[i, (int)eColView.CHECKBOX].Value = false;
                            }
                        }

                    }

                    CalculateTotalQty();

                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }

        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            ClearSpread();
            CalculateTotalQty();
        }

        public override void OnSaveFormat()
        {
            base.OnSaveFormat();

            SheetWidthController ctrl = new SheetWidthController();
            ctrl.SaveSheetWidth(shtView, this.ScreenCode);
        }

        public override void OnResetFormat()
        {
            base.OnResetFormat();

            SheetWidthController ctrl = new SheetWidthController();
            ctrl.ResetSheetWidth(shtView);
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
            ctrl.SetSheetWidth(shtView, this.ScreenCode);
        }

        private void fpView_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }


    }

}
